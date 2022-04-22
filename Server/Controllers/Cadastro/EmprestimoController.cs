using Controle.Cadastro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Contabilidade.Server.Controllers.Cadastro
{
    [Route("Emprestimo")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {
        [HttpPost]
        [Route("Gravar")]
        public async Task<IActionResult> Gravar([FromBody] Emprestimo pEmprestimo)
        {
            Emprestimo emprestimoRetorno = null;

            try
            {
                ControleEmprestimo controleEmprestimo = new ControleEmprestimo();
                emprestimoRetorno = await controleEmprestimo.Gravar(pEmprestimo);
                if (emprestimoRetorno != null)
                {
                    return Ok(emprestimoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível gravar o emprestimo.");
                }

            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new InvalidOperationException(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Exception(ex.Message));
            }
        }

        [HttpPost]
        [Route("Atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] Emprestimo pEmprestimo)
        {
            Emprestimo emprestimoRetorno = null;
            int retorno = 0;

            try
            {
                ControleEmprestimo controleEmprestimo = new ControleEmprestimo();
                emprestimoRetorno = await controleEmprestimo.Atualizar(pEmprestimo);
                if (emprestimoRetorno != null)
                {
                    return Ok(emprestimoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Atualizar o emprestimo.");
                }

            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new InvalidOperationException(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Exception(ex.Message));
            }
        }

        [HttpPost]
        [Route("Carregar")]
        public async Task<IActionResult> Carregar([FromBody] Emprestimo pEmprestimo)
        {
            Emprestimo emprestimoRetorno = null;
            int retorno = 0;

            try
            {
                ControleEmprestimo controleEmprestimo = new ControleEmprestimo();
                emprestimoRetorno = await controleEmprestimo.Carregar(pEmprestimo);
                if (emprestimoRetorno != null)
                {
                    return Ok(emprestimoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Carregar o emprestimo.");
                }

            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new InvalidOperationException(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Exception(ex.Message));
            }
        }

        [HttpPost]
        [Route("Listar")]
        public async Task<IActionResult> Listar([FromBody] Emprestimo pEmprestimo)
        {
            List<Emprestimo> emprestimoRetorno = null;
            int retorno = 0;

            try
            {
                ControleEmprestimo controleEmprestimo = new ControleEmprestimo();
                emprestimoRetorno = await controleEmprestimo.Listar(pEmprestimo);
                if (emprestimoRetorno != null)
                {
                    return Ok(emprestimoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Listar o emprestimo.");
                }

            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new InvalidOperationException(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Exception(ex.Message));
            }
        }
    }
}
