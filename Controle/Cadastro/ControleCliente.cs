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
    public class ControleCliente
    {
        public async Task<Cliente> Gravar(Cliente pCliente)
        {
            List<string> lstMensagemNegocio = new List<string>();
            lstMensagemNegocio = pCliente.validarObjeto(pCliente);

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
                Cliente clienteGravado = new Cliente();
                DbCliente dbCliente = new DbCliente();

                clienteGravado = dbCliente.Gravar(pCliente);

                if (clienteGravado != null)
                {
                    return clienteGravado;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao gravar cliente no banco.");
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

        public async Task<Cliente> Atualizar(Cliente pCliente)
        {
            List<string> lstMensagemNegocio = new List<string>();
            lstMensagemNegocio = pCliente.validarObjeto(pCliente);

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
                Cliente clienteGravado = new Cliente();
                DbCliente dbCliente = new DbCliente();

                clienteGravado = dbCliente.Atualizar(pCliente);

                if (clienteGravado != null)
                {
                    return clienteGravado;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao atualizar o cliente no banco.");
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

        public async Task<List<Cliente>> Listar(Cliente pCliente)
        {
            List<Cliente> lstClienteRetorno = null;

            try
            {
                DbCliente dbCliente = new DbCliente();
                lstClienteRetorno = dbCliente.Listar(pCliente);

                if (lstClienteRetorno != null && lstClienteRetorno.Count > 0)
                {
                    return lstClienteRetorno;
                }
                else
                {
                    return lstClienteRetorno;
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


        public async Task<Cliente> Carregar(Cliente pCliente)
        {
            Cliente clienteRetorno = null;

            if (pCliente.cod_Cliente <= 0)
            {
                throw new InvalidOperationException("Informe o código do cliente para carrega-lo.");
            }

            try
            {
                DbCliente dbCliente = new DbCliente();
                clienteRetorno = dbCliente.CarregarCliente(pCliente);

                if (clienteRetorno != null)
                {
                    return clienteRetorno;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao carregar cliente.");
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
