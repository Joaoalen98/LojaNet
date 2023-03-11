using LojaNet.DAL;
using LojaNet.Models.Entidades;
using LojaNet.Models.Interfaces;

namespace LojaNet.BLL
{
    public class ProdutoBLL : IProdutoData
    {
        private readonly IProdutoData _dal;

        public ProdutoBLL(IProdutoData dal)
        {
            _dal = dal;
        }

        public ProdutoBLL()
        {
            _dal = new ProdutoDAL();
        }

        public int Alterar(Produto entidade)
        {
            return _dal.Alterar(entidade);
        }

        public int Criar(Produto entidade)
        {
            if (entidade.Id == null)
            {
                entidade.Id = Guid.NewGuid().ToString();
            }

            return _dal.Criar(entidade);
        }

        public int Deletar(string id)
        {
            return _dal.Deletar(id);
        }

        public Produto ObterPorId(string id)
        {
            return _dal.ObterPorId(id);
        }

        public IEnumerable<Produto> ObterTodos(string? nome)
        {
            return _dal.ObterTodos(nome);
        }
    }
}
