namespace LojaNet.Models.Interfaces
{
    public interface IEntidadeData<T>
    {
        int Criar(T entidade);

        T ObterPorId(string id);

        int Alterar(T entidade);

        int Deletar(string id);
    }
}
