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
    [Route("Periodico")]
    [ApiController]
    public class PeriodicoController : ControllerBase
    {
        [HttpPost]
        [Route("Gravar")]
        public async Task<IActionResult> Gravar([FromBody] Periodico pPeriodico)
        {
            Periodico periodicoRetorno = null;

            try
            {
                ControlePeriodico controlePeriodico = new ControlePeriodico();
                periodicoRetorno = await controlePeriodico.Gravar(pPeriodico);
                if (periodicoRetorno != null)
                {
                    return Ok(periodicoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível gravar o periodico.");
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
        public async Task<IActionResult> Atualizar([FromBody] Periodico pPeriodico)
        {
            Periodico periodicoRetorno = null;
            int retorno = 0;

            try
            {
                ControlePeriodico controlePeriodico = new ControlePeriodico();
                periodicoRetorno = await controlePeriodico.Atualizar(pPeriodico);
                if (periodicoRetorno != null)
                {
                    return Ok(periodicoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Atualizar o periodico.");
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
        public async Task<IActionResult> Carregar([FromBody] Periodico pPeriodico)
        {
            Periodico periodicoRetorno = null;
            int retorno = 0;

            try
            {
                ControlePeriodico controlePeriodico = new ControlePeriodico();
                periodicoRetorno = await controlePeriodico.Carregar(pPeriodico);
                if (periodicoRetorno != null)
                {
                    return Ok(periodicoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Carregar o periodico.");
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
        public async Task<IActionResult> Listar([FromBody] Periodico pPeriodico)
        {
            List<Periodico> periodicoRetorno = null;
            int retorno = 0;

            try
            {
                ControlePeriodico controlePeriodico = new ControlePeriodico();
                periodicoRetorno = await controlePeriodico.Listar(pPeriodico);
                if (periodicoRetorno != null)
                {
                    return Ok(periodicoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Listar o periodico.");
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
