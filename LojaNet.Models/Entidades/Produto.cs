namespace LojaNet.Models.Entidades
{
    public class Produto : BaseEntidade
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
