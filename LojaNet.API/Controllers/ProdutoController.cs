using LojaNet.API.ViewModels;
using LojaNet.BLL;
using LojaNet.Models.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LojaNet.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoBLL _produtoBLL;

        public ProdutoController(ProdutoBLL produtoBLL)
        {
            _produtoBLL = produtoBLL;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var produtos = _produtoBLL.ObterTodos(null);
            return Ok(produtos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObterPorId([FromRoute] string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var produto = _produtoBLL.ObterPorId(id);
                    return StatusCode(200, produto);
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

            return BadRequest();
        }

        [HttpPost]
        [Authorize(Roles = "Funcionario,Administrador")]
        public IActionResult Criar([FromBody] ProdutoCriarViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _produtoBLL.Criar(new Produto
                    {
                        Nome = model.Nome,
                        Preco = model.Preco,
                        Quantidade = model.Quantidade,
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

            return BadRequest();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Funcionario,Administrador")]
        public IActionResult Alterar([FromBody] ProdutoCriarViewModel model, [FromRoute] string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _produtoBLL.Alterar(new Produto
                    {
                        Id = id,
                        Nome = model.Nome,
                        Preco = model.Preco,
                        Quantidade = model.Quantidade,
                    });

                    return StatusCode(200);
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

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Deletar([FromRoute] string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _produtoBLL.Deletar(id);
                    return StatusCode(200);
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

            return BadRequest();
        }
    }
}
