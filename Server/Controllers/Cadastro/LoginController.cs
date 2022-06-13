using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Negocio.Cadastro;
using Controle.Cadastro;

namespace Projeto_Contabilidade.Server.Controllers.Cadastro
{

    [Route("Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("Gravar")]
        public async Task<IActionResult> Gravar([FromBody] Login pLogin)
        {
            Login loginRetorno = null;

            try
            {
                ControleLogin controleLogin = new ControleLogin();
                loginRetorno = await controleLogin.Gravar(pLogin);
                if (loginRetorno != null)
                {
                    return Ok(loginRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível gravar o login.");
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
        public async Task<IActionResult> Atualizar([FromBody] Login pLogin)
        {
            Login loginRetorno = null;
            try
            {
                ControleLogin controleLogin = new ControleLogin();
                loginRetorno = await controleLogin.Atualizar(pLogin);
                if (loginRetorno != null)
                {
                    return Ok(loginRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível atualizar o login.");
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
        public async Task<IActionResult> Carregar(int pIdLogin)
        {
            Login loginRetorno = null;

            try
            {
                ControleLogin controleLogin = new ControleLogin();
                loginRetorno = await controleLogin.Carregar(pIdLogin);
                if (loginRetorno != null)
                {
                    return Ok(loginRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível carregar o login.");
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
        public async Task<IActionResult> Listar([FromBody] Login pLogin)
        {
            List<Login> loginRetorno = null;

            try
            {
                ControleLogin controleLogin = new ControleLogin();
                loginRetorno = await controleLogin.Listar(pLogin);
                if (loginRetorno != null)
                {
                    return Ok(loginRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível listar o login.");
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
        public async Task<IActionResult> Excluir(int pIdLogin)
        {
            int loginRetorno = 0;

            try
            {
                ControleLogin controleLogin = new ControleLogin();
                loginRetorno = await controleLogin.Excluir(pIdLogin);
                if (loginRetorno != null)
                {
                    return Ok(loginRetorno);
                }
                else
                {
                    throw new InvalidOperationException("Não foi possível excluir o login.");
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
