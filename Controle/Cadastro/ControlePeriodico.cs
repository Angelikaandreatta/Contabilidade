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
    public class ControlePeriodico
    {
        public async Task<Periodico> Gravar(Periodico pPeriodico)
        {
            List<string> lstMensagemNegocio = new List<string>();
            lstMensagemNegocio = pPeriodico.validarObjeto(pPeriodico);

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
                Periodico periodicoGravado = new Periodico();
                DbPeriodico dbPeriodico = new DbPeriodico();

                periodicoGravado = dbPeriodico.Gravar(pPeriodico);

                if (periodicoGravado != null)
                {
                    periodicoGravado = new DbPeriodico().CarregarPeriodico(periodicoGravado.codigo_Periodico);
                    return periodicoGravado;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao gravar periodico no banco.");
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

        public async Task<Periodico> Atualizar(Periodico pPeriodico)
        {
            List<string> lstMensagemNegocio = new List<string>();
            lstMensagemNegocio = pPeriodico.validarObjeto(pPeriodico);

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
                Periodico periodicoGravado = new Periodico();
                DbPeriodico dbPeriodico = new DbPeriodico();

                periodicoGravado = dbPeriodico.Atualizar(pPeriodico);

                if (periodicoGravado != null)
                {
                    periodicoGravado = new DbPeriodico().CarregarPeriodico(periodicoGravado.codigo_Periodico);
                    return periodicoGravado;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao atualizar o periodico no banco.");
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

        public async Task<List<Periodico>> Listar(Periodico pPeriodico)
        {
            List<Periodico> lstPeriodicoRetorno = null;

            try
            {
                DbPeriodico dbPeriodico = new DbPeriodico();
                lstPeriodicoRetorno = dbPeriodico.Listar(pPeriodico);

                if (lstPeriodicoRetorno != null && lstPeriodicoRetorno.Count > 0)
                {
                    return lstPeriodicoRetorno;
                }
                else
                {
                    return lstPeriodicoRetorno;
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


        public async Task<Periodico> Carregar(int pCodPeriodico)
        {
            Periodico periodicoRetorno = null;

            if (pCodPeriodico <= 0)
            {
                throw new InvalidOperationException("Informe o código do periodico para carrega-lo.");
            }

            try
            {
                DbPeriodico dbPeriodico = new DbPeriodico();
                periodicoRetorno = dbPeriodico.CarregarPeriodico(pCodPeriodico);

                if (periodicoRetorno != null)
                {
                    return periodicoRetorno;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao carregar Periodico.");
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

        public async Task<int> Excluir(int pCodPeriodico)
        {
            int retorno = 0;

            if (pCodPeriodico <= 0)
            {
                throw new InvalidOperationException("Informe o código do periódico para exclui-lo.");
            }

            try
            {
                DbPeriodico dbPeriodico = new DbPeriodico();
                retorno = dbPeriodico.Excluir(pCodPeriodico);

                if (retorno == 1)
                {
                    return retorno;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao excluir periódico.");
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
