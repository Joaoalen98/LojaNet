using LojaNet.DAL;
using LojaNet.Helpers;
using LojaNet.Models.Entidades;
using LojaNet.Models.Interfaces;

namespace LojaNet.BLL
{
    public class UsuarioBLL : IUsuarioData
    {
        private IUsuarioData _dal;

        public UsuarioBLL()
        {
            _dal = new UsuarioDAL();
        }

        public UsuarioBLL(IUsuarioData dal)
        {
            _dal = dal;
        }

        public int Alterar(Usuario entidade)
        {
            return _dal.Alterar(entidade);
        }

        public Usuario ObterPorEmailSenha(string email, string senha)
        {
            var usuario = _dal.ObterPorEmail(email);

            if (usuario == null)
            {
                throw new ApplicationException("Email e/ou senha incorreta");
            }

            var senhaCorreta = HashHelper.ComparaSenha(senha, usuario.Senha);

            if (!senhaCorreta)
            {
                throw new ApplicationException("Email e/ou senha incorreta");
            }

            return usuario;
        }

        public int Criar(Usuario entidade)
        {
            if (entidade.Id == null)
            {
                entidade.Id = Guid.NewGuid().ToString();
            }

            var usuarioExistente = ObterPorEmail(entidade.Email);
            if (usuarioExistente != null)
            {
                throw new ApplicationException("Email já cadastrado");
            }

            entidade.Senha = HashHelper.HashSenha(entidade.Senha);
            return _dal.Criar(entidade);
        }

        public int Deletar(string id)
        {
            return _dal.Deletar(id);
        }

        public Usuario ObterPorEmail(string email)
        {
            return _dal.ObterPorEmail(email);
        }

        public Usuario ObterPorId(string id)
        {
            return _dal.ObterPorId(id);
        }
    }
}
