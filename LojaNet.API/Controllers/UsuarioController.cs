using LojaNet.API.ViewModels;
using LojaNet.BLL;
using LojaNet.Models.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LojaNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioBLL _bllUsuario;
        private readonly TokenHelper _tokenHelper;

        public UsuarioController(UsuarioBLL usuarioBLL, TokenHelper tokenHelper)
        {
            _bllUsuario = usuarioBLL;
            _tokenHelper = tokenHelper;
        }

        [HttpPost]
        [Route("criar")]
        public IActionResult Criar([FromBody] UsuarioCriarViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var criar = _bllUsuario.Criar(new Usuario
                    {
                        Email = model.Email,
                        Nome = model.Nome,
                        Senha = model.Senha,
                        Telefone = model.Telefone,
                    });

                    return StatusCode(201);
                }
                catch (ApplicationException ex)
                {
                    return StatusCode(400, new { erro = ex.Message });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { erro = ex.Message });
                }
            }

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UsuarioLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = _bllUsuario.ObterPorEmailSenha(
                        model.Email, model.Senha);

                    var token = _tokenHelper.GerarTokenUsuario(usuario);

                    usuario.Senha = null!;
                    return Ok(new
                    {
                        Usuario = new
                        {
                            usuario.Nome,
                            usuario.Email,
                            usuario.Telefone,
                            Role = usuario.Role.ToString()
                        },
                        Token = token,
                    });
                }
                catch (ApplicationException ex)
                {
                    return StatusCode(400, new { erro = ex.Message });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { erro = ex.Message });
                }
            }

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Dados()
        {
            var usuarioId = User.FindFirst("Id")!.Value;
            var usuario = _bllUsuario.ObterPorId(usuarioId);
            return Ok(new
            {
                usuario.Nome,
                usuario.Email,
                usuario.Telefone,
                Role = usuario.Role.ToString()
            });
        }
    }
}
