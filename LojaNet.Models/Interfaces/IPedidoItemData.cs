using LojaNet.Models.Entidades;

namespace LojaNet.Models.Interfaces
{
    public interface IPedidoItemData : IEntidadeData<Pedido.PedidoItem>
    {
        IEnumerable<Pedido.PedidoItem> ObterPorPedido(string pedidoId);
    }
}
