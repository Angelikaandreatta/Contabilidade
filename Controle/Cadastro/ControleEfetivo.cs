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
    public class ControleEfetivo
    {
        public async Task<Efetivo> Gravar(Efetivo pEfetivo)
        {
            List<string> lstMensagemNegocio = new List<string>();
            lstMensagemNegocio = pEfetivo.validarObjeto(pEfetivo);

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
                Efetivo efetivoGravado = new Efetivo();
                DbEfetivo dbEfetivo = new DbEfetivo();

                efetivoGravado = dbEfetivo.Gravar(pEfetivo);

                if (efetivoGravado != null)
                {
                    efetivoGravado = dbEfetivo.CarregarEfetivo(efetivoGravado.codigo_efetivo);
                    return efetivoGravado;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao gravar efetivo no banco.");
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

        public async Task<Efetivo> Atualizar(Efetivo pEfetivo)
        {
            List<string> lstMensagemNegocio = new List<string>();
            lstMensagemNegocio = pEfetivo.validarObjeto(pEfetivo);

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
                Efetivo efetivoGravado = new Efetivo();
                DbEfetivo dbEfetivo = new DbEfetivo();

                efetivoGravado = dbEfetivo.Atualizar(pEfetivo);

                if (efetivoGravado != null)
                {
                    efetivoGravado = dbEfetivo.CarregarEfetivo(efetivoGravado.codigo_efetivo);
                    return efetivoGravado;
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

        public async Task<List<Efetivo>> Listar()
        {
            List<Efetivo> lstEfetivoRetorno = null;

            try
            {
                DbEfetivo dbEfetivo = new DbEfetivo();
                lstEfetivoRetorno = dbEfetivo.Listar();

                if (lstEfetivoRetorno != null && lstEfetivoRetorno.Count > 0)
                {
                    return lstEfetivoRetorno;
                }
                else
                {
                    return lstEfetivoRetorno;
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

        public async Task<Efetivo> Carregar(int pCodEfetivo)
        {
            Efetivo efetivoRetrono= null;

            if (pCodEfetivo <= 0)
            {
                throw new InvalidOperationException("Informe o código do efetivo para carrega-lo.");
            }

            try
            {
                DbEfetivo dbEfetivo = new DbEfetivo();
                efetivoRetrono = dbEfetivo.CarregarEfetivo(pCodEfetivo);

                if (efetivoRetrono != null)
                {
                    return efetivoRetrono;
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

        public async Task<int> Excluir(int pCodEfetivo)
        {
            int retorno = 0;

            if (pCodEfetivo <= 0)
            {
                throw new InvalidOperationException("Informe o código do efetivo para exclui-lo.");
            }

            try
            {
                DbEfetivo dbEfetivo = new DbEfetivo();
                retorno = dbEfetivo.Excluir(pCodEfetivo);

                if (retorno == 1)
                {
                    return retorno;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao excluir efetivo.");
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
