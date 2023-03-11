using LojaNet.Models.Enums;

namespace LojaNet.Models.Entidades
{
    public class Usuario : BaseEntidade
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }

        public RoleEnum Role { get; set; }

        public Usuario()
        {
            Role = RoleEnum.Cliente;
        }
    }
}
