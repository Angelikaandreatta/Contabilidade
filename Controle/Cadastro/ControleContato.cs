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
    public class ControleContato
    {
        public async Task<Contato> Gravar(Contato pContato)
        {
            List<string> lstMensagemNegocio = new List<string>();
            lstMensagemNegocio = pContato.validarObjeto(pContato);

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
                Contato contatoGravado = new Contato();
                DbContato dbContato = new DbContato();

                contatoGravado = dbContato.Gravar(pContato);

                if (contatoGravado != null)
                {
                    return contatoGravado;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao gravar contato no banco.");
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

        public async Task<Contato> Atualizar(Contato pContato)
        {
            List<string> lstMensagemNegocio = new List<string>();
            lstMensagemNegocio = pContato.validarObjeto(pContato);

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
                Contato contatoGravado = new Contato();
                DbContato dbContato = new DbContato();

                contatoGravado = dbContato.Atualizar(pContato);

                if (contatoGravado != null)
                {
                    return contatoGravado;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao atualizar o contato no banco.");
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

        public async Task<List<Contato>> Listar(Contato pContato)
        {
            List<Contato> lstContatoRetorno = null;

            try
            {
                DbContato dbContato = new DbContato();
                lstContatoRetorno = dbContato.Listar(pContato);

                if (lstContatoRetorno != null && lstContatoRetorno.Count > 0)
                {
                    return lstContatoRetorno;
                }
                else
                {
                    return lstContatoRetorno;
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


        public async Task<Contato> Carregar(int pCodContato)
        {
            Contato contatoRetorno = null;

            if (pCodContato <= 0)
            {
                throw new InvalidOperationException("Informe o código do contato para carrega-lo.");
            }

            try
            {
                DbContato dbContato = new DbContato();
                contatoRetorno = dbContato.CarregarContato(pCodContato);

                if (contatoRetorno != null)
                {
                    return contatoRetorno;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao carregar contato.");
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

        public async Task<int> Excluir(int pCodContato)
        {
            int retorno = 0;

            if (pCodContato <= 0)
            {
                throw new InvalidOperationException("Informe o código do contato para exclui-lo.");
            }

            try
            {
                DbContato dbContato = new DbContato();
                retorno = dbContato.Excluir(pCodContato);

                if (retorno == 1)
                {
                    return retorno;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao excluir contato.");
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
