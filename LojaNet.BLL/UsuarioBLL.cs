using LojaNet.DAL;
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

        public int Criar(Usuario entidade)
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

        public Usuario ObterPorId(string id)
        {
            return _dal.ObterPorId(id);
        }
    }
}
