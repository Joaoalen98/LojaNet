using System.ComponentModel.DataAnnotations;

namespace LojaNet.API.ViewModels
{
    public class ProdutoCriarViewModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public int Quantidade { get; set; }
    }
}
