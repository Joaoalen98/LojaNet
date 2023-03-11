using LojaNet.DAL;
using LojaNet.Models.Entidades;
using LojaNet.Models.Interfaces;

namespace LojaNet.BLL
{
    public class PedidoBLL : IPedidoData
    {
        private readonly IPedidoData _dal;

        public PedidoBLL()
        {
            _dal = new PedidoDAL();
        }

        public PedidoBLL(IPedidoData dal)
        {
            _dal = dal;
        }

        public int Alterar(Pedido entidade)
        {
            return _dal.Alterar(entidade);
        }

        public int Criar(Pedido entidade)
        {
            if (string.IsNullOrEmpty(entidade.Id))
            {
                entidade.Id = Guid.NewGuid().ToString();
            }

            foreach (var item in entidade.PedidoItems)
            {
                if (string.IsNullOrEmpty(item.Id))
                {
                    item.Id = Guid.NewGuid().ToString();
                }
            }

            return _dal.Criar(entidade);
        }

        public int Deletar(string id)
        {
            return _dal.Deletar(id);
        }

        public Pedido ObterPorId(string id)
        {
            return _dal.ObterPorId(id);
        }

        public IEnumerable<Pedido> ObterTodos(string usuarioId)
        {
            return _dal.ObterTodos(usuarioId);
        }
    }
}
