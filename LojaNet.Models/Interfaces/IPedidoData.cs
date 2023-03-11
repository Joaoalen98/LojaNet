using LojaNet.Models.Entidades;

namespace LojaNet.Models.Interfaces
{
    public interface IPedidoData : IEntidadeData<Pedido>
    {
        IEnumerable<Pedido> ObterTodos(string usuarioId);
    }
}
