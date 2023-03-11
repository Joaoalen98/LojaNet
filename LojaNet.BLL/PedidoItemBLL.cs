using LojaNet.DAL;
using LojaNet.Models.Entidades;
using LojaNet.Models.Interfaces;

namespace LojaNet.BLL
{
    public class PedidoItemBLL : IPedidoItemData
    {
        private readonly IPedidoItemData _dal;

        public PedidoItemBLL(IPedidoItemData dal)
        {
            _dal = dal;
        }

        public PedidoItemBLL()
        {
            _dal = new PedidoItemDAL();
        }

        public int Alterar(Pedido.PedidoItem entidade)
        {
            return _dal.Alterar(entidade);
        }

        public int Criar(Pedido.PedidoItem entidade)
        {
            if (string.IsNullOrEmpty(entidade.Id))
            {
                entidade.Id = Guid.NewGuid().ToString();
            }

            return _dal.Criar(entidade);
        }

        public int Deletar(string id)
        {
            return _dal.Deletar(id);
        }

        public Pedido.PedidoItem ObterPorId(string id)
        {
            return _dal.ObterPorId(id);
        }

        public IEnumerable<Pedido.PedidoItem> ObterPorPedido(string pedidoId)
        {
            return _dal.ObterPorPedido(pedidoId);
        }
    }
}
