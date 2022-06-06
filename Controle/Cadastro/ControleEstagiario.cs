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
    public class ControleEstagiario
    {
        public async Task<Estagiario> Gravar(Estagiario pEstagiario)
        {
            List<string> lstMensagemNegocio = new List<string>();
            lstMensagemNegocio = pEstagiario.validarObjeto(pEstagiario);

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
                Estagiario estagiarioGravado = new Estagiario();
                DbEstagiario dbEstagiario = new DbEstagiario();

                estagiarioGravado = dbEstagiario.Gravar(pEstagiario);

                if (estagiarioGravado != null)
                {
                    estagiarioGravado = dbEstagiario.CarregarEstagiario(estagiarioGravado.codigo_Estagiario);
                    return estagiarioGravado;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao gravar estagiario no banco.");
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

        public async Task<Estagiario> Atualizar(Estagiario pEstagiario)
        {
            List<string> lstMensagemNegocio = new List<string>();
            lstMensagemNegocio = pEstagiario.validarObjeto(pEstagiario);

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
                Estagiario estagiarioGravado = new Estagiario();
                DbEstagiario dbEstagiario = new DbEstagiario();

                estagiarioGravado = dbEstagiario.Atualizar(pEstagiario);

                if (estagiarioGravado != null)
                {
                    estagiarioGravado = dbEstagiario.CarregarEstagiario(estagiarioGravado.codigo_Estagiario);
                    return estagiarioGravado;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao atualizar o efetivo no banco.");
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

        public async Task<List<Estagiario>> Listar()
        {
            List<Estagiario> lstEstagiario = null;

            try
            {
                DbEstagiario dbEstagiario = new DbEstagiario();
                lstEstagiario = dbEstagiario.Listar();

                if (lstEstagiario != null && lstEstagiario.Count > 0)
                {
                    return lstEstagiario;
                }
                else
                {
                    return lstEstagiario;
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

        public async Task<Estagiario> Carregar(int pCodEstagiario)
        {
            Estagiario estagiarioRetorno = null;

            if (pCodEstagiario <= 0)
            {
                throw new InvalidOperationException("Informe o código do estagiario para carrega-lo.");
            }

            try
            {
                DbEstagiario dbEstagiario = new DbEstagiario();
                estagiarioRetorno = dbEstagiario.CarregarEstagiario(pCodEstagiario);

                if (estagiarioRetorno != null)
                {
                    return estagiarioRetorno;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao carregar efetivo.");
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

        public async Task<int> Excluir(int pCodEstagiario)
        {
            int retorno = 0;

            if (pCodEstagiario <= 0)
            {
                throw new InvalidOperationException("Informe o código do estagiario para exclui-lo.");
            }

            try
            {
                DbEstagiario dbEstagiario = new DbEstagiario();
                retorno = dbEstagiario.Excluir(pCodEstagiario);

                if (retorno == 1)
                {
                    return retorno;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao excluir estagiario.");
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
