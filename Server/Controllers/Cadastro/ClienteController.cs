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
    [Route("Cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        [Route("Gravar")]
        public async Task<IActionResult> Gravar([FromBody] Cliente pCliente)
        {
            Cliente clienteRetorno = null;

            try
            {
                ControleCliente controleCliente = new ControleCliente();
                clienteRetorno = await controleCliente.Gravar(pCliente);
                if (clienteRetorno != null)
                {
                    return Ok(clienteRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível gravar o cliente.");
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
        public async Task<IActionResult> Atualizar([FromBody] Cliente pCliente)
        {
            Cliente clienteRetorno = null;
            int retorno = 0;

            try
            {
                ControleCliente controleCliente = new ControleCliente();
                clienteRetorno = await controleCliente.Atualizar(pCliente);
                if (clienteRetorno != null)
                {
                    return Ok(clienteRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Atualizar o cliente.");
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
        public async Task<IActionResult> Carregar([FromBody] Cliente pCliente)
        {
            Cliente clienteRetorno = null;
            int retorno = 0;

            try
            {
                ControleCliente controleCliente = new ControleCliente();
                clienteRetorno = await controleCliente.Carregar(pCliente);
                if (clienteRetorno != null)
                {
                    return Ok(clienteRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Carregar o cliente.");
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
        public async Task<IActionResult> Listar([FromBody] Cliente pCliente)
        {
            List<Cliente> clienteRetorno = null;
            int retorno = 0;

            try
            {
                ControleCliente controleCliente = new ControleCliente();
                clienteRetorno = await controleCliente.Listar(pCliente);
                if (clienteRetorno != null)
                {
                    return Ok(clienteRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Listar o cliente.");
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
