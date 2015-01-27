using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultaAutomatizadaBMG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        AcessoImacros Ai;
        AcessoExcel Ae;
        private int linhaGrid = 0;
        bool interrompeConsulta = false;
        bool consultando = false;
        public bool consultarNovamente { get; set; }
        public int ConsultaPortalBmg { get; set; }

        private void FocarJanelaAplicacao()
        {
            this.TopMost = true;
            this.Focus();
            this.TopMost = false;
        }

        private void abrirButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                caminhoTextBox.Text = openFileDialog.FileName.ToString();
                consultaButton.Enabled = true;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            ConsultaPortalBmg = 0; // Padrão é consulta BMG

            if (cb_portal.SelectedIndex != 0)
            {
                // Caso a consulta não seja a padrão BMG, valor fica falso para a macro não acessar o portal bmg
                ConsultaPortalBmg = cb_portal.SelectedIndex;
            }

            if (usuarioTextBox.Text == "" || senhaTextBox.Text == "")
            {
                MessageBox.Show("Para continuar o processo é necessário digitar usuário e senha.", "ERRO",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Criação da String que receberá texto de erro do site ou imacros
                string respostaLogin = "";

                Ai = new AcessoImacros(ocultaImacrosCheckBox.Checked);
                Ai.QuandoOcorrerMensagem += Ai_QuandoOcorrerMensagem;

                try
                {
                    respostaLogin = Ai.Login(usuarioTextBox.Text, senhaTextBox.Text, cb_Captcha.SelectedIndex, ConsultaPortalBmg);
                    FocarJanelaAplicacao();

                    //Estes campos só deverão ser ativados se o login for feito!
                    loginSucessoLabel.Visible = true;
                    abrirButton.Enabled = true;
                    caminhoTextBox.Enabled = true;
                }

                catch (Exception erro)
                {
                    if (erro.Message.ToString() != "ERRO: NODATA")
                    {
                        MessageBox.Show(erro.Message.ToString(), "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string cpf_anterior = "", convenio_anterior = "";

        private void Ai_QuandoOcorrerMensagem(string cpf, string convenio, string mensagem)
        {
            if ((cpf != cpf_anterior) || (convenio != convenio_anterior))
            {
                linhaGrid = dataGridView.Rows.Add();
                cpf_anterior = cpf;
                convenio_anterior = convenio;
                dataGridView.Rows[linhaGrid].Cells[0].Value = cpf;
                dataGridView.Rows[linhaGrid].Cells[1].Value = convenio;
            }
            dataGridView.Rows[linhaGrid].Cells[2].Value = mensagem;
        }

        private void consultaButton_Click(object sender, EventArgs e)
        {
            interromperConsultaButton.Enabled = true;

            Ae = new AcessoExcel(openFileDialog.FileName);

            int contador = Ae.QtdeLinhas;
            progressBar.Maximum = contador;
            int contadorErroCaptcha = 0;
            consultarNovamente = false;
            for (int i = 2; i <= contador + 1; i++)
            {
                string cpf = "", convenio = "";

                try
                {
                    Ae.LerArquivo(i, out cpf, out convenio);
                    consultando = true;

                    if (interrompeConsulta)
                    {
                        Ai_QuandoOcorrerMensagem(cpf, convenio, "CONSULTA CANCELADA");
                        MessageBox.Show("Consulta interrompida, último CPF consultado: " + cpf_anterior, "CONSULTA FINALIZADA PELO USUÁRIO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cancelarConsultalabel.Visible = false;
                        break;
                    }

                    if (!Utilitarios.VerificaCpf(cpf))
                    {
                        FocarJanelaAplicacao();
                        Ai_QuandoOcorrerMensagem(cpf, convenio, "ERRO");
                        throw new Exception("CPF inválido.");
                    }

                    string msg;
                    string tabela = Ai.LerCPF(cpf, convenio, out msg, cb_Captcha.SelectedIndex, consultarNovamente, ConsultaPortalBmg);
                    FocarJanelaAplicacao();

                    if (tabela != "")
                    {
                        List<string[]> tabelaContratos = Ai.FormataTabela(tabela, cpf);
                        if (tabelaContratos != null)
                        {
                            Ae.ColarDados(tabelaContratos, msg);
                            progressBar.Value = i - 1;
                        }
                        contadorErroCaptcha = 0;
                        consultarNovamente = false;
                    }
                    else
                    {
                        var tabelaSemContratos = new List<string[]>();
                        tabelaSemContratos.Add(new string[] { cpf });
                        Ae.ColarDados(tabelaSemContratos, msg);
                        Ai_QuandoOcorrerMensagem(cpf, convenio, "OK");
                        progressBar.Value = i - 1;
                        consultarNovamente = false;
                    }
                }
                catch (CaptchaException)
                {
                    contadorErroCaptcha++;
                    if (contadorErroCaptcha <= 10)
                    {
                        FocarJanelaAplicacao();
                        consultarNovamente = true;
                        i--;
                    }
                    else
                    {
                        try
                        {
                            Ae.FecharExcel();
                        }
                        catch(Exception)
                        {
                        }

                        break;
                    }
                }

                catch (Exception erro)
                {
                    if (erro.Message != "")
                    {
                        FocarJanelaAplicacao();
                        try
                        {
                            Ae.PreencherErro(erro.Message, cpf, convenio);
                        }
                        catch(Exception erroSaidaPlanilha)
                        {
                            MessageBox.Show(erroSaidaPlanilha.Message + "\nReinicie a consulta clicando em " + @" ""Consultar Contratos"". " ,"ERRO",MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            progressBar.Value = 0;
                            return;
                        }
                        progressBar.Value = i - 1;
                    }

                    contadorErroCaptcha = 0;
                }
            }
            FocarJanelaAplicacao();

            try
            {
                Ae.SalvarPlanilhas();
            }
            catch (Exception erroSalvarPlanilha)
            {
                MessageBox.Show(erroSalvarPlanilha.Message,"ERRO",MessageBoxButtons.OK, MessageBoxIcon.Stop);
                progressBar.Value = 0;
                return;
            }

            try
            {
                Ae.FecharExcel();
            }
            catch (Exception)
            {
            }

            Ai.Logout();
            loginSucessoLabel.Visible = false;
            caminhoTextBox.Text = "";
            consultaButton.Enabled = false;

            if (contadorErroCaptcha > 10)
                MessageBox.Show("O limite de erros consecutivos de decifração de captcha para este CPF excedeu.", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //Habilitando as labels e botões para abrir o arquivo
            if (File.Exists(Ae.NomeArquivoResultado))
            {
                abrirResultadoButton.Enabled = true;
            }

            if (File.Exists(Ae.NomeArquivoErro))
            {
                abrirErrosButton.Enabled = true;
            }

            MessageBox.Show("Processo Finalizado!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBar.Value = 0;
            consultando = false;
        }

        private void abrirResultadoButton_Click(object sender, EventArgs e)
        {
            //catch caso arquivo não seja encontrado
            try
            {
                System.Diagnostics.Process.Start(Ae.NomeArquivoResultado);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void abrirErrosButton_Click(object sender, EventArgs e)
        {
            //catch caso arquivo não seja encontrado
            try
            {
                System.Diagnostics.Process.Start(Ae.NomeArquivoErro);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void interromperConsultaClick(object sender, EventArgs e)
        {
            interrompeConsulta = true;
            cancelarConsultalabel.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cb_Captcha.SelectedIndex = 0;
            cb_portal.SelectedIndex = 0; // Padrão é que ele faça a consulta no BMG.
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* Desta forma ele só vai fechar o form quando a instância de AI (Imacros) não existir mais, caso contrário
            ele ficará chamando sempre a mensagem */
            e.Cancel = false;
            if (Ai != null)
            {
                e.Cancel = true;

                if (Ai.logado && consultando)
                {
                    MessageBox.Show("Para fechar o form é necessário antes interromper a consulta.\nSe você já clicou em interromper, aguarde a finalização da última consulta.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (Ai.logado && !consultando)
                {
                    this.Cursor = Cursors.WaitCursor;
                    Ai.Logout();
                    e.Cancel = false;
                }
                if (!Ai.logado && !consultando)
                {
                    Ai.SairImacros();
                    e.Cancel = false;
                }

                else
                {
                    Ai.SairImacros();
                    e.Cancel = false;
                }
            }

            if (consultando)
            {
                Ai.SairImacros();
            }
            else
            {
                e.Cancel = false;
            }

        }
    }
}
