using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using iMacros;

namespace ConsultaAutomatizadaBMG
{
    class CaptchaException : Exception { }
    class ContratoQuitadoException : Exception { }
    //class ContratoRefinanciadoException : Exception { }

    class AcessoImacros
    {
        iMacros.App iim;
        public bool logado = false;
        private int instanciaImacros = 0;
        private string erro_dinamico_consultas;

        public AcessoImacros(bool ocultaImacros)
        {
            iim = new iMacros.App();
            int timeout = 90;


            if (ocultaImacros)
            {
                // RODAR MACROS COM IMACROS INVISIVEL
                iMacros.Status status = iim.iimInit("-silent", true, timeout);
                instanciaImacros++;
            }
            else
            {
                iMacros.Status status = iim.iimOpen("", true, timeout);
                instanciaImacros++;
            }
        }

        ~AcessoImacros()
        {
            SairImacros();
        }

        public void SairImacros()
        {
            if (instanciaImacros > 0)
            {
                try
                {
                    /* Se o form por algum motivo fechar e a instância do imacros for destruída antes do método destrutor ser chamado,
                    a exceção ocorrerá e o número de instâncias será decrementado, evitando erro ao tentar destruir uma instância que não existe mais em memória*/
                    iim.iimExit();
                    instanciaImacros--;
                }
                catch (Exception)
                {
                    instanciaImacros--;
                }
            }
            else
            {
                instanciaImacros--;
            }
        }

        public string CriaStringMacro(string nomeMacro)
        {
            string pasta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + Path.DirectorySeparatorChar + nomeMacro + ".iim";
            pasta = pasta.Substring(6, pasta.Length - 6);
            StreamReader arquivo = new StreamReader(pasta);
            string macro = arquivo.ReadToEnd();

            return macro;
        }

        public void Recarregar_Formulario_Consulta(int portal)
        {
            int timeout = 90;
            string macroRecarregaConsulta = CriaStringMacro("Formulario_de_Consulta");


            if (portal != 0)
            {
                // 0 = BMG
                switch (portal)
                {
                    case 1: //Itaú
                        macroRecarregaConsulta = macroRecarregaConsulta.Replace("URL GOTO=https://ssoconsig.bancobmg.com.br/principal/fsconsignataria.jsp", "URL GOTO=https://www2.ibconsigweb.com.br");
                        break;
                    case 2: //BCV
                        macroRecarregaConsulta = macroRecarregaConsulta.Replace("URL GOTO=https://ssoconsig.bancobmg.com.br/principal/fsconsignataria.jsp", "URL GOTO=https://www.bcvconsig.com.br/");
                        break;
                    case 3: //CIFRA
                        macroRecarregaConsulta = macroRecarregaConsulta.Replace("URL GOTO=https://ssoconsig.bancobmg.com.br/principal/fsconsignataria.jsp", "URL GOTO=https://www.cifraconsig.com.br/");
                        break;
                }
            }    

            iMacros.Status statusConsulta = iim.iimPlayCode(macroRecarregaConsulta, timeout);
        }

        public string Realizar_Consulta(string cpf, string convenio, int interpretador_Captcha, bool nova_tentativa, int portal)
        {
            string macroConsulta = CriaStringMacro("Formulario_de_Consulta");

           if(portal != 0)
            {
                macroConsulta = macroConsulta.Replace("https://ssoconsig.bancobmg.com.br/principal/fsconsignataria.jsp", "https://www2.ibconsigweb.com.br");
            }                          

            if (interpretador_Captcha == 0)
            {
                if (!nova_tentativa)
                {
                    macroConsulta += CriaStringMacro("Captcha Boss Consulta");
                }
                else
                {
                    macroConsulta = "";
                    macroConsulta += CriaStringMacro("Nova Consulta CaptchaBoss");
                }
            }

            else if (interpretador_Captcha == 1)
            {
                if (!nova_tentativa)
                {
                    macroConsulta += CriaStringMacro("DeathByCaptcha Consulta");
                }
                else
                {
                    macroConsulta = "";
                    macroConsulta += CriaStringMacro("Nova Consulta DeathByCaptcha");
                }
            }

            macroConsulta = macroConsulta.Replace("#TEMP_FOLDER#", Path.GetTempPath());

            if (Convert.ToInt32(convenio) != 164)
            {
                // Quando o convênio não for SIAPE, ele não precisa aguardar 3 segundos para a troca do captcha, isso só ocorre no caso de SIAPE.
                macroConsulta = macroConsulta.Replace("#CPF#", cpf).Replace("#convenio#", convenio);
            }
            else
            {
                macroConsulta = macroConsulta.Replace("#CPF#", cpf).Replace("#convenio#", convenio);
                macroConsulta = macroConsulta.Replace(@"'--comentario", "");
            }

            int timeoutConsulta = 90;

            if (this.QuandoOcorrerMensagem != null)
            {
                QuandoOcorrerMensagem(cpf, convenio, "CONSULTANDO...");
            }
            string retornoPreConsulta;

            iMacros.Status statusConsulta = iim.iimPlayCode(macroConsulta, timeoutConsulta);
            erro_dinamico_consultas = iim.iimGetErrorText();
            retornoPreConsulta = iim.iimGetExtract(0).Replace("#EANF#[EXTRACT]", "").Replace("AlertaSimNão","").Trim();

            return retornoPreConsulta;
        }
        
        public string VerificaConsulta()
        {
            int timeout = 90;
            string VerificaRetornoConsulta = CriaStringMacro("VerificaConsulta");
            iMacros.Status statusConsulta = iim.iimPlayCode(VerificaRetornoConsulta, timeout);
            VerificaRetornoConsulta = iim.iimGetExtract(0).Replace("#EANF#[EXTRACT]", "");

            return VerificaRetornoConsulta;
        }

        public string Logout()
        {
            string pasta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + Path.DirectorySeparatorChar + "logout.iim";
            pasta = pasta.Substring(6, pasta.Length - 6);
            StreamReader arquivo = new StreamReader(pasta);

            string macro = arquivo.ReadToEnd();

            int timeout = 90;
            iMacros.Status status = iim.iimPlayCode(macro, timeout);
            SairImacros();

            return macro;
        }

        public string SelecionarPortalLogin(int indicePortal, int interpretadorCaptcha)
        {
            string macro = String.Empty;

            if (interpretadorCaptcha == 0)
            {
                switch (indicePortal)
                {
                    case 0: //BMG
                        macro = CriaStringMacro("login_CaptchaBoss");
                        break;

                    case 1: //Itaú
                        macro = CriaStringMacro("login_CaptchaBossItau");
                        break;
                    case 2: //BCV
                        macro = CriaStringMacro("login_CaptchaBossBCV");
                        break;
                    case 3: //CIFRA
                        macro = CriaStringMacro("login_CaptchaBossCIFRA"); ;
                        break;
                }
            }

            else
            {
                switch (indicePortal)
                {
                    case 0: //BMG
                        macro = CriaStringMacro("Login_DeathByCaptcha");
                        break;

                    case 1: //Itaú
                        macro = CriaStringMacro("Login_DeathByCaptchaItau");
                        break;
                    case 2: //BCV
                        macro = CriaStringMacro("Login_DeathByCaptchaBCV");
                        break;
                    case 3: //CIFRA
                        macro = CriaStringMacro("Login_DeathByCaptchaCIFRA"); ;
                        break;
                }
            }

            return macro;
        }

        public string Login(string usuario, string senha, int interpretadorCaptcha, int portal)
        {
            string macroLogin = "";

            macroLogin = SelecionarPortalLogin(portal, interpretadorCaptcha);

            macroLogin = macroLogin.Replace("#TEMP_FOLDER#", Path.GetTempPath());
            macroLogin = macroLogin.Replace("{{USUARIO}}", usuario);
            macroLogin = macroLogin.Replace("{{SENHA}}", senha);
            
            int timeout = 90;
            string retornoMacro = "";
            string erro = "";

            iMacros.Status estadoLogin = iim.iimPlayCode(macroLogin, timeout);
            retornoMacro = iim.iimGetExtract(0).Replace("#EANF#", "").Replace("[EXTRACT]", "");
            if (retornoMacro == "")
            {
                macroLogin = "";
                macroLogin = CriaStringMacro("Verifica logado");
                iMacros.Status statusLogin = iim.iimPlayCode(macroLogin, timeout);
                retornoMacro = iim.iimGetExtract(0).Replace("#EANF#", "").Replace("[EXTRACT]", "");
                erro = iim.iimGetErrorText().Replace("OK (1)", "");
            }

            if (retornoMacro != "Correspondente:")
            {
                if (retornoMacro != "")
                {
                    iim.iimClose();
                    throw new Exception("ERRO: " + retornoMacro);
                }

                else if (erro != "")
                {
                    iim.iimClose();
                    //Mensagem de erro do imacros.
                    throw new Exception("ERRO IMACROS: " + erro);
                }

                else
                {
                    iim.iimClose();
                    throw new Exception("ERRO: O site não está respondendo, tente mais tarde!\n\nDetalhe: " + retornoMacro);
                }
            }
            logado = true;
            return retornoMacro;
        }

        public string LerCPF(string cpf, string convenio, out string mensagem, int interpretadorCaptcha, bool novaTentativa, int portal)
        {
            string Contratos = "";
            mensagem = "";
            string erroPreConsulta;

            if (convenio == "423")
            {
                if (this.QuandoOcorrerMensagem != null)
                {
                    QuandoOcorrerMensagem(cpf, convenio, "ERRO");
                }
                throw new Exception("ERRO: Entidade não relacionada para a loja.");
            }

            string macroConsulta = "";

            macroConsulta = Realizar_Consulta(cpf, convenio, interpretadorCaptcha, novaTentativa,portal);
            erroPreConsulta = erro_dinamico_consultas;
            macroConsulta = macroConsulta.Replace("AlertaSimNão","");
            macroConsulta = macroConsulta.Replace("#EANF##EANF#", "");
            macroConsulta = macroConsulta.Replace("* Campo obrigatório", "");

            if (macroConsulta == "")
            {
                int tempoLimiteConsulta = 0;
                while ((macroConsulta == "") && (tempoLimiteConsulta < 30))
                {
                    macroConsulta = VerificaConsulta();
                    macroConsulta = macroConsulta.Replace("AlertaSimNão", "");
                    macroConsulta = macroConsulta.Replace("#EANF##EANF#", "");
                    macroConsulta = macroConsulta.Replace("* Campo obrigatório", "");
                    macroConsulta = macroConsulta.Replace("[EXTRACT]", "");
                    macroConsulta = macroConsulta.Replace("#EANF#", "");

                    if (macroConsulta == " ")
                    {
                        macroConsulta = macroConsulta.Replace(" ", "");
                    }
                    tempoLimiteConsulta++;
                }
            }

            if (macroConsulta.Contains("Palavra de verificação da imagem está incorreta, por favor tente novamente.")) // Primeiro possível erro, digitação incorreta do captcha
            {
                Recarregar_Formulario_Consulta(portal);

                //Caso o captcha da consulta atual esteja incorreto ele faz + 9 tentativas
                if (this.QuandoOcorrerMensagem != null)
                {
                    QuandoOcorrerMensagem(cpf, convenio, "ERRO");
                }
                throw new CaptchaException();
            }

            if (macroConsulta.Contains("Não foi localizado nenhum contrato com os dados fornecidos.") || macroConsulta.Contains("Não foi possível localizar código do cliente com o CPF. ") || macroConsulta.Contains("Não foi encontrado nenhum contrato"))
            {
                if (this.QuandoOcorrerMensagem != null)
                {
                    QuandoOcorrerMensagem(cpf, convenio, "OK");
                }
                mensagem = "CONTRATO QUITADO";
                return "";
            }

            if ((macroConsulta.Contains("Já existe uma proposta em andamento para esse CPF")))
            {
                if (this.QuandoOcorrerMensagem != null)
                {
                    QuandoOcorrerMensagem(cpf, convenio, "OK");
                }
                mensagem = "CONTRATO REFINANCIADO";

                return "";
            }

            if ((erroPreConsulta.Replace("OK (1)", "") != ""))
            {
                if (erroPreConsulta.Contains("Não foi localizado nenhum contrato com os dados fornecidos.") || erroPreConsulta.Contains("Não foi possível localizar código do cliente com o CPF. "))
                {
                    if (this.QuandoOcorrerMensagem != null)
                    {
                        QuandoOcorrerMensagem(cpf, convenio, "OK");
                    }
                    mensagem = "CONTRATO QUITADO";
                    return "";
                }

                if ((erroPreConsulta.Contains("Já existe uma proposta em andamento para esse CPF")))
                {
                    if (this.QuandoOcorrerMensagem != null)
                    {
                        QuandoOcorrerMensagem(cpf, convenio, "OK");
                    }
                    mensagem = "CONTRATO REFINANCIADO";
                    return "";
                }

                else
                {
                    if (this.QuandoOcorrerMensagem != null)
                    {
                        QuandoOcorrerMensagem(cpf, convenio, "ERRO");
                    }
                    throw new Exception("ERRO: " + erroPreConsulta);
                }
            }

            if (macroConsulta.Contains("Selecione o(s) contrato(s):")) // CONSULTA FEITA COM SUCESSO
            {
                string macroContratos = CriaStringMacro("Extrator_tabela_Consulta");
                int timeoutExtrator = 90;
                iMacros.Status statusExtrator = iim.iimPlayCode(macroContratos, timeoutExtrator);
                Contratos = iim.iimGetExtract(1);
                string erroExtrator = iim.iimGetErrorText();

                if (erroExtrator.Contains("Refinanciavel: Nao (2) - TEC"))
                {
                    if (this.QuandoOcorrerMensagem != null)
                    {
                        QuandoOcorrerMensagem(cpf, convenio, "OK");
                    }
                    mensagem = "CONTRATO QUITADO";

                    return "";
                }

                if (erroExtrator.Replace("OK (1)", "") != "")
                {
                    if (this.QuandoOcorrerMensagem != null)
                    {
                        QuandoOcorrerMensagem(cpf, convenio, "ERRO");
                    }
                    throw new Exception("ERRO: " + erroExtrator.ToString());
                    // LINHA COM ERRO
                }

                if (this.QuandoOcorrerMensagem != null)
                {
                    QuandoOcorrerMensagem(cpf, convenio, "OK");
                }
                return Contratos;
            }

            if (macroConsulta != "" && macroConsulta != " " && !macroConsulta.Contains("Selecione o(s) contrato(s):"))
            {
                if (this.QuandoOcorrerMensagem != null)
                {
                    QuandoOcorrerMensagem(cpf, convenio, "ERRO");
                }
                throw new Exception("ERRO: " + macroConsulta.ToString());
            }

            if (macroConsulta == "")
            {
                if (this.QuandoOcorrerMensagem != null)
                {
                    QuandoOcorrerMensagem(cpf, convenio, "ERRO");
                }
                Recarregar_Formulario_Consulta(portal);

                throw new Exception("ERRO INTERMITENTE DO PORTAL BMG. ERRO INTERNO DO SISTEMA");

            }

            return macroConsulta;
        }

        public List<string[]> FormataTabela(string tabela, string cpf)
        {
            string[] origem;
            tabela = tabela.Replace("#EANF#", "").Replace("[EXTRACT]", "#NEWLINE#").Replace("#NEWLINE#", "|").Replace("#NEXT#", "@");
            origem = tabela.Split('|');
            List<string[]> contrato = new List<string[]>();

            for (int i = 0; i < origem.Length; i++)
            {

                if (!origem[i].Equals("") && "0123456789".Contains(origem[i].Substring(origem[i].IndexOf("@") + 1, 1)))
                {
                    origem[i] = cpf + "@" + origem[i];
                    contrato.Add(origem[i].Split('@'));
                }
            }

            return contrato;
        }

        public delegate void MensagemDelegate(string cpf, string convenio, string mensagem);
        public event MensagemDelegate QuandoOcorrerMensagem;
    }
}
