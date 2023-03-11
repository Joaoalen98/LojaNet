using LojaNet.Models.Entidades;

namespace LojaNet.Models.Interfaces
{
    public interface IUsuarioData : IEntidadeData<Usuario>
    {
        Usuario ObterPorEmailSenha(string email, string senha);
        Usuario ObterPorEmail(string email);
    }
}
