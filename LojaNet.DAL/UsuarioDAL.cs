using LojaNet.DAL.Data;
using LojaNet.Models.Entidades;
using LojaNet.Models.Interfaces;

namespace LojaNet.DAL
{
    public class UsuarioDAL : IUsuarioData
    {
        public int Alterar(Usuario entidade)
        {
            return DbHelper.ExecutarComando("UsuarioAlterar", entidade);
        }

        public Usuario ObterPorEmailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public int Criar(Usuario entidade)
        {
            return DbHelper.ExecutarComando("UsuarioCriar", entidade);
        }

        public int Deletar(string id)
        {
            return DbHelper.ExecutarComando("UsuarioDeletar", new { Id = id });
        }

        public Usuario ObterPorEmail(string email)
        {
            return DbHelper.GetEntidade<Usuario>("UsuarioObterPorEmail", new { Email = email });
        }

        public Usuario ObterPorId(string id)
        {
            return DbHelper.GetEntidade<Usuario>("UsuarioObterPorId", new { Id = id });
        }
    }
}
