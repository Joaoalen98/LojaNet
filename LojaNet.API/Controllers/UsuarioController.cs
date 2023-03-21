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
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(ErroViewModel), 400)]
        [ProducesResponseType(typeof(ErroViewModel), 500)]
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
                    return StatusCode(400, new ErroViewModel(ex.Message));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new ErroViewModel(ex.Message, ex.StackTrace!));
                }
            }

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(ResultadoLoginViewModel), 200)]
        [ProducesResponseType(typeof(ErroViewModel), 400)]
        [ProducesResponseType(typeof(ErroViewModel), 500)]
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
                    return Ok(new ResultadoLoginViewModel(usuario, token));
                }
                catch (ApplicationException ex)
                {
                    return StatusCode(400, new ErroViewModel(ex.Message));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new ErroViewModel(ex.Message, ex.StackTrace!));
                }
            }

            return Ok();
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(Usuario), 200)]
        [ProducesResponseType(401)]
        public IActionResult Dados()
        {
            var usuarioId = User.FindFirst("Id")!.Value;
            var usuario = _bllUsuario.ObterPorId(usuarioId);
            usuario.Senha = null!;
            return Ok(usuario);
        }
    }
}
