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
    public class PedidoController : ControllerBase
    {
        private PedidoBLL _pedidoBLL;
        private PedidoItemBLL _pedidoItemBLL;

        public PedidoController(PedidoBLL pedidoBLL, PedidoItemBLL pedidoItemBLL)
        {
            _pedidoBLL = pedidoBLL;
            _pedidoItemBLL = pedidoItemBLL;
        }


        [HttpGet]
        public IActionResult ObterTodos([FromQuery] bool items = false)
        {
            var usuarioId = User.FindFirst("Id")!.Value;
            var produtos = _pedidoBLL.ObterTodos(usuarioId);

            if (items)
            {
                foreach (var produto in produtos)
                {
                    produto.PedidoItems = _pedidoItemBLL.ObterPorPedido(produto.Id).ToList();
                }
            }

            return Ok(produtos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObterPorId([FromRoute] string id, [FromQuery] bool items = false)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var pedido = _pedidoBLL.ObterPorId(id);
                    return StatusCode(200, new
                    {
                        pedido.Id,
                        pedido.DataPedido,
                        PedidoItems = items ? _pedidoItemBLL.ObterPorPedido(id) : pedido.PedidoItems,
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

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Criar([FromBody] PedidoCriarViewModel model)
        {
            try
            {
                var usuarioId = User.FindFirst("Id")!.Value;

                var pedido = new Pedido
                {
                    PedidoItems = new List<Pedido.PedidoItem>(),
                    UsuarioId = usuarioId,
                    DataPedido = model.DataPedido,
                };

                foreach (var item in model.PedidoItems)
                {
                    var pedidoItem = new Pedido.PedidoItem
                    {
                        Preco = item.Preco,
                        ProdutoId = item.ProdutoId,
                    };
                    pedido.PedidoItems.Add(pedidoItem);
                }

                _pedidoBLL.Criar(pedido);

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

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Deletar([FromRoute] string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _pedidoBLL.Deletar(id);
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
