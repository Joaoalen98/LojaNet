using LojaNet.DAL.Data;
using LojaNet.Models.Entidades;
using LojaNet.Models.Interfaces;

namespace LojaNet.DAL
{
    public class PedidoItemDAL : IPedidoItemData
    {
        public int Alterar(Pedido.PedidoItem entidade)
        {
            return DbHelper.ExecutarComando("PedidoItemAlterar", entidade);
        }

        public int Criar(Pedido.PedidoItem entidade)
        {
            return DbHelper.ExecutarComando("PedidoItemCriar", entidade);
        }

        public int Deletar(string id)
        {
            return DbHelper.ExecutarComando("PedidoItemDeletar", new { Id = id });
        }

        public Pedido.PedidoItem ObterPorId(string id)
        {
            return DbHelper.GetEntidade<Pedido.PedidoItem>("PedidoItemObterPorId", new { Id = id });
        }

        public IEnumerable<Pedido.PedidoItem> ObterPorPedido(string pedidoId)
        {
            return DbHelper.GetColecao<Pedido.PedidoItem>("PedidoItemObterPorPedido", new { PedidoId = pedidoId });
        }
    }
}
