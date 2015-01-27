using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;
using System.IO;

namespace ConsultaAutomatizadaBMG
{
    class AcessoExcel //: IDisposable
    {
        //Declarando Planílha de saída dos contratos encontrados
        Excel.Application App;
        Excel.Workbook Planilha;
        Excel.Workbook PlanilhaErros;
        Excel.Workbook PlanilhaContratos;

        private int linhaColada;
        private int linhaErro;
        private string _caminho;
        public string NomeArquivoResultado = String.Empty;
        public string NomeArquivoErro = String.Empty;

        public AcessoExcel(string caminho)
        {
            App = new Excel.Application();
            Planilha = App.Workbooks.Open(caminho);
            _caminho = caminho;
        }

        public void Dispose()
        {
            try
            {
                GC.SuppressFinalize(this);
            }
            catch (Exception)
            {
            }
        }

        ~AcessoExcel()
        {
            if (App != null)
            {
                Dispose();
            }

            if (Planilha != null || PlanilhaErros != null || PlanilhaContratos != null)
            {
                Dispose();
            }
        }

        public void LerArquivo(int linha, out string cpf, out string convenio)
        {
            Planilha.Activate();
            cpf = Utilitarios.AdicionaZeros(Utilitarios.SoNumeros(Planilha.ActiveSheet.Cells[linha, 1].Value.ToString()), 11);
            convenio = Utilitarios.SoNumeros(Planilha.ActiveSheet.Cells[linha, 2].Value.ToString());
        }

        public int QtdeLinhas
        {
            get
            {
                int linha = 2;
                int contador = 0;

                while (Planilha.ActiveSheet.Cells[linha, 1].Value != null)
                {
                    contador++;
                    linha++;
                }

                return contador;
            }

        }

        public void CriarSaida()
        {
            try
            {
                PlanilhaContratos = App.Workbooks.Add(Type.Missing);
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível criar o arquivo de contratos consultados, devido a um erro no Excel.");
            }
        }

        public void CriarSaidaErro()
        {
            try
            {
                PlanilhaErros = App.Workbooks.Add(Type.Missing);
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível criar o arquivo de erro, devido a um erro no Excel.");
            }
        }


        public void ColarDados(List<string[]> Tabela, string mensagem)
        {
            if (PlanilhaContratos == null)
            {
                CriarSaida();
                Excel.Worksheet ws = PlanilhaContratos.ActiveSheet;
                ws.Cells.NumberFormat = "@";

                ws.Cells[1, 1] = "CPF"; 
                ws.Cells[1, 2] = "Origem Contrato";
                ws.Cells[1, 3] = "Contrato";
                ws.Cells[1, 4] = "Matrícula";
                ws.Cells[1, 5] = "Data de Nascimento";
                ws.Cells[1, 6] = "Órgão/Filial"; 
                ws.Cells[1, 7] = "Saldo p/ Refin.(*)";
                ws.Cells[1, 8] = "Parc. Refin. (*)";
                ws.Cells[1, 9] = "Parc. Abertas";
                ws.Cells[1, 10] = "Prz. do Contrato";
                ws.Cells[1, 11] = "Vlr Parcela (R$)";
                ws.Cells[1, 12] = "% Parc. Pagas";
                ws.Cells[1, 13] = "Ação";
                ws.Cells[1, 14] = "Mensagem";

                linhaColada = 2;
            }

            PlanilhaContratos.Activate();
            Excel.Worksheet ws2 = PlanilhaContratos.ActiveSheet;

            foreach (var linha in Tabela)
            {
                for (int coluna = 0; coluna < linha.Length; coluna++)
                {
                    ws2.Cells[linhaColada, coluna + 1] = linha[coluna];
                }

                ws2.Cells[linhaColada, 14] = mensagem;
                linhaColada++;
            }
            SalvarPlanilhas();
        }

        public void SalvarPlanilhas()
        {
            if (PlanilhaContratos != null)
            {
                if (NomeArquivoResultado == String.Empty)
                {

                    int i = 1;

                    NomeArquivoResultado = Path.GetDirectoryName(_caminho) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(_caminho) + "_resultado" + Path.GetExtension(_caminho);
                    while (File.Exists(NomeArquivoResultado))
                    {
                        NomeArquivoResultado = Path.GetDirectoryName(_caminho) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(_caminho) + "_resultado_" + i.ToString() + Path.GetExtension(_caminho);
                        i++;
                    }
                    PlanilhaContratos.SaveAs(NomeArquivoResultado);
                }
                else
                {
                    try
                    {
                        PlanilhaContratos.Save();
                    }
                    catch(Exception)
                    {
                        throw new Exception("Erro ao tentar salvar planilha com contratos obtidos na consulta.");
                    }
                }
            }
            
          
            if (PlanilhaErros != null)
            {
                if (NomeArquivoErro == String.Empty)
                {
                    int i = 1;
                    NomeArquivoErro = Path.GetDirectoryName(_caminho) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(_caminho) + "_erro" + Path.GetExtension(_caminho);
                    while (File.Exists(NomeArquivoErro))
                    {
                        NomeArquivoErro = Path.GetDirectoryName(_caminho) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(_caminho) + "_erro_" + i.ToString() + Path.GetExtension(_caminho);
                        i++;
                    }
                    PlanilhaErros.SaveAs(NomeArquivoErro);
                }
                else {
                        try
                        {
                            PlanilhaErros.Save();
                        }
                        
                        catch(Exception)
                        {
                            throw new Exception("ERRO ao tentar salvar planílha com erros de consulta.");    
                        }
                }
            }
        }

        public void FecharExcel()
        {
            if (PlanilhaContratos != null)
            {
                PlanilhaContratos.Close();
                PlanilhaContratos = null;
            }

            if (PlanilhaErros != null)
            {
                PlanilhaErros.Close();
                PlanilhaErros = null;
            }

            if (Planilha != null)
            {
                Planilha.Close();
                Planilha = null;
            }
            App.Quit();
            App = null;
        }

        public void PreencherErro(string erro, string cpf, string convenio)
        {
            if (PlanilhaErros == null)
            {
                CriarSaidaErro();
                Excel.Worksheet ws = PlanilhaErros.ActiveSheet;

                ws.Cells.NumberFormat = "@";
                ws.Cells[1, 1] = "CPF";
                ws.Cells[1, 2] = "Convênio";
                ws.Cells[1, 3] = "Erro";

                linhaErro = 2;
            }

            PlanilhaErros.Activate();
            Excel.Worksheet ws2 = PlanilhaErros.ActiveSheet;

            ws2.Cells[linhaErro, 1] = cpf;
            ws2.Cells[linhaErro, 2] = convenio;
            ws2.Cells[linhaErro, 3] = erro;

            linhaErro++;
            SalvarPlanilhas();
        }
    }
}
