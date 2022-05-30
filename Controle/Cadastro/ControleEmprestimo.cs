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
    public class ControleEmprestimo
    {
        public async Task<Emprestimo> Gravar(Emprestimo pEmprestimo)
        {
            List<string> lstMensagemNegocio = new List<string>();
            lstMensagemNegocio = pEmprestimo.validarObjeto(pEmprestimo);

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
                Emprestimo emprestimoGravado = new Emprestimo();
                DbEmprestimo dbEmprestimo = new DbEmprestimo();

                emprestimoGravado = dbEmprestimo.Gravar(pEmprestimo);

                if (emprestimoGravado != null)
                {
                    if (new DbPeriodico().AtualizarStatusPeriodico("indisponivel", pEmprestimo.periodico.codigo_Periodico) == 1)
                    {
                        return emprestimoGravado;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    throw new InvalidOperationException("Erro ao gravar emprestimo no banco.");
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

        public async Task<Emprestimo> Atualizar(Emprestimo pEmprestimo)
        {
            List<string> lstMensagemNegocio = new List<string>();
            lstMensagemNegocio = pEmprestimo.validarObjeto(pEmprestimo);

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
                Emprestimo emprestimoGravado = new Emprestimo();
                DbEmprestimo dbEmprestimo = new DbEmprestimo();

                emprestimoGravado = dbEmprestimo.Atualizar(pEmprestimo);

                if (emprestimoGravado != null)
                {
                    return emprestimoGravado;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao atualizar o emprestimo no banco.");
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

        public async Task<List<Emprestimo>> Listar(Emprestimo pEmprestimo)
        {
            List<Emprestimo> lstEmprestimoRetorno = null;

            try
            {
                DbEmprestimo dbEmprestimo = new DbEmprestimo();
                lstEmprestimoRetorno = dbEmprestimo.Listar(pEmprestimo);

                if (lstEmprestimoRetorno != null && lstEmprestimoRetorno.Count > 0)
                {
                    return lstEmprestimoRetorno;
                }
                else
                {
                    return lstEmprestimoRetorno;
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


        public async Task<Emprestimo> Carregar(Emprestimo pEmprestimo)
        {
            Emprestimo emprestimoRetorno = null;

            if (pEmprestimo.cod_Emprestimo <= 0)
            {
                throw new InvalidOperationException("Informe o código do emprestimo para carrega-lo.");
            }

            try
            {
                DbEmprestimo dbEmprestimo = new DbEmprestimo();
                emprestimoRetorno = dbEmprestimo.CarregarEmprestimo(pEmprestimo);

                if (emprestimoRetorno != null)
                {
                    return emprestimoRetorno;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao carregar emprestimo.");
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
