using LojaNet.DAL.Data;
using LojaNet.Models.Entidades;
using LojaNet.Models.Interfaces;

namespace LojaNet.DAL
{
    public class ProdutoDAL : IProdutoData
    {
        public int Alterar(Produto entidade)
        {
            return DbHelper.ExecutarComando("ProdutoAlterar", entidade);
        }

        public int Criar(Produto entidade)
        {
            return DbHelper.ExecutarComando("ProdutoCriar", entidade);
        }

        public int Deletar(string id)
        {
            return DbHelper.ExecutarComando("ProdutoDeletar", new { Id = id });
        }

        public Produto ObterPorId(string id)
        {
            return DbHelper.GetEntidade<Produto>("ProdutoObterPorId", new { Id = id });
        }

        public IEnumerable<Produto> ObterTodos(string? nome)
        {
            return DbHelper.GetColecao<Produto>("ProdutoObterTodos", null);
        }
    }
}
