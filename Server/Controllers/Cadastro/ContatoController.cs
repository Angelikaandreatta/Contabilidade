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
    [Route("Contato")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
       [HttpPost]
        [Route("Gravar")]
        public async Task<IActionResult> Gravar([FromBody] Contato pContato)
        {
            Contato contatoRetorno = null;

            try
            {
                ControleContato controleContato = new ControleContato();
                contatoRetorno = await controleContato.Gravar(pContato);
                if (contatoRetorno != null)
                {
                    return Ok(contatoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível gravar o contato.");
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
        public async Task<IActionResult> Atualizar([FromBody] Contato pContato)
        {
            Contato contatoRetorno = null;
            int retorno = 0;

            try
            {
                ControleContato controleContato = new ControleContato();
                 contatoRetorno = await controleContato.Atualizar(pContato);
                if (contatoRetorno != null)
                {
                    return Ok(contatoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Atualizar o contato.");
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
        public async Task<IActionResult> Carregar(int pCodContato)
        {
            Contato contatoRetorno = null;
            int retorno = 0;

            try
            {
                ControleContato controleContato = new ControleContato();
                contatoRetorno = await controleContato.Carregar(pCodContato);
                if (contatoRetorno != null)
                {
                    return Ok(contatoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Carregar o contato.");
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
        public async Task<IActionResult> Listar([FromBody] Contato pContato)
        {
            List<Contato> contatoRetorno = null;
            int retorno = 0;

            try
            {
                ControleContato controleContato = new ControleContato();
                contatoRetorno = await controleContato.Listar(pContato);
                if (contatoRetorno != null)
                {
                    return Ok(contatoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Listar o contato.");
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
        public async Task<IActionResult> Excluir(int pCodContato)
        {
            int contatoRetorno = 0;

            try
            {
                ControleContato controleContato = new ControleContato();
                contatoRetorno = await controleContato.Excluir(pCodContato);

                if (contatoRetorno == 1)
                {
                    return Ok(contatoRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível Excluir o contato.");
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
