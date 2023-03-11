using LojaNet.Models.Entidades;

namespace LojaNet.Models.Interfaces
{
    public interface IProdutoData : IEntidadeData<Produto>
    {
        IEnumerable<Produto> ObterTodos(string? nome);
    }
}
