using LojaNet.Models.Entidades;

namespace LojaNet.API.ViewModels
{
    public class ResultadoLoginViewModel
    {
        public Usuario Usuario { get; set; }
        public string Token { get; set; }


        public ResultadoLoginViewModel(Usuario usuario, string token)
        {
            Usuario = usuario;
            Token = token;
        }
    }
}
