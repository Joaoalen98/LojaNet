using System.ComponentModel.DataAnnotations;

namespace LojaNet.API.ViewModels
{
    public class UsuarioLoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
