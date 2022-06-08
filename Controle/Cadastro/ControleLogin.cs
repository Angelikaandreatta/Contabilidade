using BancoDeDados.Cadastro;
using Controle.UtilControle;
using Negocio.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Cadastro
{
    public class ControleLogin
    {
        public async Task<Login> Gravar(Login pLogin)
        {
            List<string> lstMensagemNegocio = new List<string>();
            lstMensagemNegocio = pLogin.validarObjeto(pLogin);

            if (lstMensagemNegocio != null)
            {
                Validacoes validacao = new Validacoes();

                foreach (string mensagem in lstMensagemNegocio)
                {
                    validacao.strMensagemLista.Add(mensagem);
                }
                validacao.RetornarMensagem();
            }

            try
            {
                Login loginGravado = new Login();
                DbLogin dbLogin = new DbLogin();

                loginGravado = dbLogin.Gravar(pLogin);

                if (loginGravado != null)
                {
                    return loginGravado;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao gravar login no banco.");
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Login> Atualizar(Login pLogin)
        {
            //List<string> lstMensagemNegocio = new List<string>();
            //lstMensagemNegocio = pLogin.validarObjeto(pLogin);

            //if (lstMensagemNegocio != null)
            //{
            //    Validacoes validacao = new Validacoes();

            //    foreach (string mensagem in lstMensagemNegocio)
            //    {
            //        validacao.strMensagemLista.Add(mensagem);
            //    }
            //    validacao.RetornarMensagem();
            //}

            try
            {
                Login loginGravado = new Login();
                DbLogin dbLogin = new DbLogin();

                loginGravado = dbLogin.Atualizar(pLogin);

                if (loginGravado != null)
                {
                    loginGravado = new DbLogin().CarregarLogin(loginGravado.codigo_Login);
                    return loginGravado;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao atualizar o login no banco.");
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Login>> Listar(Login pLogin)
        {
            List<Login> lstLoginRetorno = null;

            try
            {
                DbLogin dbLogin = new DbLogin();
                lstLoginRetorno = dbLogin.Listar(pLogin);

                if (lstLoginRetorno != null && lstLoginRetorno.Count > 0)
                {
                    return lstLoginRetorno;
                }
                else
                {
                    return lstLoginRetorno;
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Login> Carregar(int pCodLogin)
        {
            Login loginRetorno = null;

            if (pCodLogin <= 0)
            {
                throw new InvalidOperationException("Informe o código do login para carrega-lo.");
            }

            try
            {
                DbLogin dbLogin = new DbLogin();
                loginRetorno = dbLogin.CarregarLogin(pCodLogin);

                if (loginRetorno != null)
                {
                    return loginRetorno;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao carregar login.");
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> Excluir(int pCodLogin)
        {
            int loginRetorno = 0;

            if (pCodLogin <= 0)
            {
                throw new InvalidOperationException("Informe o código do login para carrega-lo.");
            }

            try
            {
                DbLogin dbLogin = new DbLogin();
                loginRetorno = dbLogin.Excluir(pCodLogin);

                if (loginRetorno == 1)
                {
                    return loginRetorno;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao carregar login.");
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

