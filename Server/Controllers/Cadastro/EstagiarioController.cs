using Controle.Cadastro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Cadastro;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto_Contabilidade.Server.Controllers.Cadastro
{
    [Route("Estagiario")]
    [ApiController]
    public class EstagiarioController : ControllerBase
    {
        [HttpPost]
        [Route("Gravar")]
        public async Task<IActionResult> Gravar([FromBody] Estagiario pEstagiario)
        {
            Estagiario estagiarioRetorno = null;

            try
            {
                ControleEstagiario controleEstagiario = new ControleEstagiario();
                estagiarioRetorno = await controleEstagiario.Gravar(pEstagiario);
                if (estagiarioRetorno != null)
                {
                    return Ok(estagiarioRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível gravar o estagiario.");
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
        public async Task<IActionResult> Atualizar([FromBody] Estagiario pEstagiario)
        {
            Estagiario estagiarioRetorno = null;

            try
            {
                ControleEstagiario controleEstagiario = new ControleEstagiario();
                estagiarioRetorno = await controleEstagiario.Atualizar(pEstagiario);
                if (estagiarioRetorno != null)
                {
                    return Ok(estagiarioRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Atualizar o estagiario.");
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

        [HttpGet]
        [Route("Carregar")]
        public async Task<IActionResult> Carregar(int pCodEstagiario)
        {
            Estagiario estagiarioRetorno = null;

            try
            {
                ControleEstagiario controleEstagiario = new ControleEstagiario();
                estagiarioRetorno = await controleEstagiario.Carregar(pCodEstagiario);
                if (estagiarioRetorno != null)
                {
                    return Ok(estagiarioRetorno);
                }
                else
                {
                    return NotFound("Não foi possível Carregar o estagiario.");
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

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            List<Estagiario> lstEstagiario = null;

            try
            {
                ControleEstagiario controleEstagiario = new ControleEstagiario();
                lstEstagiario = await controleEstagiario.Listar();
                if (lstEstagiario != null)
                {
                    return Ok(lstEstagiario);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Listar o estagiario.");
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

        [HttpDelete]
        [Route("Excluir")]
        public async Task<IActionResult> Excluir(int pCodEstagiario)
        {
            int estagiarioRetorno = 0;

            try
            {
                ControleEfetivo controleEfetivo = new ControleEfetivo();
                estagiarioRetorno = await controleEfetivo.Excluir(pCodEstagiario);

                if (estagiarioRetorno == 1)
                {
                    return Ok(estagiarioRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Excluir o estagiario.");
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
