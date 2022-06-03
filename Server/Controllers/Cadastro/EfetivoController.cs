using Controle.Cadastro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Cadastro;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto_Contabilidade.Server.Controllers.Cadastro
{
    [Route("Efetivo")]
    [ApiController]
    public class EfetivoController : ControllerBase
    {
        [HttpPost]
        [Route("Gravar")]
        public async Task<IActionResult> Gravar([FromBody] Efetivo pEfetivo)
        {
            Efetivo efetivoRetorno = null;

            try
            {
                ControleEfetivo controleEfetivo = new ControleEfetivo();
                efetivoRetorno = await controleEfetivo.Gravar(pEfetivo);
                if (controleEfetivo != null)
                {
                    return Ok(controleEfetivo);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível gravar o efetivo.");
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
        public async Task<IActionResult> Atualizar([FromBody] Efetivo pEfetivo)
        {
            Efetivo efetivoRetorno = null;

            try
            {
                ControleEfetivo controleEfetivo = new ControleEfetivo();
                efetivoRetorno = await controleEfetivo.Atualizar(pEfetivo);
                if (efetivoRetorno != null)
                {
                    return Ok(efetivoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Atualizar o efetivo.");
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
        public async Task<IActionResult> Carregar(int pCodEfetivo)
        {
            Efetivo efetivoRetorno = null;

            try
            {
                ControleEfetivo controleEfetivo = new ControleEfetivo();
                efetivoRetorno = await controleEfetivo.Carregar(pCodEfetivo);
                if (efetivoRetorno != null)
                {
                    return Ok(efetivoRetorno);
                }
                else
                {
                    return NotFound("Não foi possível Carregar o efetivo.");
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
            List<Efetivo> efetivoRetorno = null;

            try
            {
                ControleEfetivo controleEfetivo= new ControleEfetivo();
                efetivoRetorno = await controleEfetivo.Listar();
                if (efetivoRetorno != null)
                {
                    return Ok(efetivoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Listar o efetivo.");
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
        public async Task<IActionResult> Excluir(int pCodEfetivo)
        {
            int efetivoRetorno = 0;

            try
            {
                ControleEfetivo controleEfetivo= new ControleEfetivo();
                efetivoRetorno = await controleEfetivo.Excluir(pCodEfetivo);

                if (efetivoRetorno == 1)
                {
                    return Ok(efetivoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Excluir o efetivo.");
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
