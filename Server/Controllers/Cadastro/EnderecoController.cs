using Controle.Cadastro;
using Microsoft.AspNetCore.Mvc;
using Negocio.Cadastro;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto_Contabilidade.Server.Controllers.Cadastro
{
    [Route("Endereco")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        [HttpPost]
        [Route("Gravar")]
        public async Task<IActionResult> Gravar([FromBody] Endereco pEndereco)
        {
            Endereco enderecoRetorno = null;

            try
            {
                ControleEndereco controleEndereco = new ControleEndereco();
                enderecoRetorno = await controleEndereco.Gravar(pEndereco);
                if (enderecoRetorno != null)
                {
                    return Ok(enderecoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível gravar o endereço.");
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
        public async Task<IActionResult> Atualizar([FromBody] Endereco pEndereco)
        {
            Endereco enderecoRetorno = null;

            try
            {
                ControleEndereco controlEndereco = new ControleEndereco();
                enderecoRetorno = await controlEndereco.Atualizar(pEndereco);
                if (enderecoRetorno != null)
                {
                    return Ok(enderecoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Atualizar o endereço.");
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
        public async Task<IActionResult> Carregar(int pCodEndereco)
        {
            Endereco enderecoRetorno = null;

            try
            {
                ControleEndereco controleEndereco = new ControleEndereco();
                enderecoRetorno = await controleEndereco.Carregar(pCodEndereco);
                if (enderecoRetorno != null)
                {
                    return Ok(enderecoRetorno);
                }
                else
                {
                    return NotFound("Não foi possível Carregar o endereço.");
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
        public async Task<IActionResult> Listar([FromBody] Endereco pEndereco)
        {
            List<Endereco> enderecoRetorno = null;

            try
            {
                ControleEndereco controleEndereco = new ControleEndereco();
                enderecoRetorno = await controleEndereco.Listar(pEndereco);
                if (enderecoRetorno != null)
                {
                    return Ok(enderecoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Listar o endereço.");
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
