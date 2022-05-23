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

        [HttpGet]
        [Route("Carregar")]
        public async Task<IActionResult> Carregar(string pCodCliente)
        {
            Cliente clienteRetorno = null;

            try
            {
                ControleCliente controleCliente = new ControleCliente();
                clienteRetorno = await controleCliente.Carregar(pCodCliente);
                if (clienteRetorno != null)
                {
                    return Ok(clienteRetorno);
                }
                else
                {
                    return NotFound("Não foi possível Carregar o cliente.");
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


        [HttpDelete]
        [Route("Excluir")]
        public async Task<IActionResult> Excluir(int pCodCliente)
        {
            int clienteRetorno = 0;

            try
            {
                ControleCliente controleCliente = new ControleCliente();
                clienteRetorno = await controleCliente.Excluir(pCodCliente);

                if (clienteRetorno == 1)
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
