using Controle.Cadastro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Cadastro;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto_Contabilidade.Server.Controllers.Cadastro
{
    [Route("Cargo")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        [HttpGet]
        [Route("Carregar")]
        public async Task<IActionResult> Carregar(int pCodCargo)
        {
            Cargo cargoRetorno = null;

            try
            {
                ControleCargo controleCargo = new ControleCargo();
                cargoRetorno = await controleCargo.Carregar(pCodCargo);
                if (cargoRetorno != null)
                {
                    return Ok(cargoRetorno);
                }
                else
                {
                    return NotFound("Não foi possível carregar o cargo.");
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
            List<Cargo> cargoRetorno = null;

            try
            {
                ControleCargo controleCargo = new ControleCargo();
                cargoRetorno = await controleCargo.Listar();
                if (cargoRetorno != null)
                {
                    return Ok(cargoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível listar os cargos.");
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
