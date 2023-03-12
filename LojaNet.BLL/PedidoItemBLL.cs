using LojaNet.DAL;
using LojaNet.Models.Entidades;
using LojaNet.Models.Interfaces;
using static LojaNet.Models.Entidades.Pedido;

namespace LojaNet.BLL
{
    public class PedidoItemBLL : IPedidoItemData
    {
        private readonly IPedidoItemData _dal;
        private readonly IProdutoData _produtoBLL;
        public PedidoItemBLL(IPedidoItemData dal, IProdutoData produtoData)
        {
            _dal = dal;
            _produtoBLL = produtoData;
        }

        public PedidoItemBLL()
        {
            _dal = new PedidoItemDAL();
            _produtoBLL = new ProdutoBLL();
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
            var pedidoItem = _dal.ObterPorId(id);
            pedidoItem.Produto = _produtoBLL.ObterPorId(pedidoItem.ProdutoId);
            return pedidoItem;
        }

        public IEnumerable<Pedido.PedidoItem> ObterPorPedido(string pedidoId)
        {
            var pedidoItems = _dal.ObterPorPedido(pedidoId);

            foreach (var item in pedidoItems)
            {
                item.Produto = _produtoBLL.ObterPorId(item.ProdutoId);
            }
            return pedidoItems;
        }
    }
}
