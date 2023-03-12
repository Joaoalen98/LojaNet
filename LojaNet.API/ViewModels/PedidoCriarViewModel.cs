namespace LojaNet.API.ViewModels
{
    public class PedidoCriarViewModel
    {
        public DateTime DataPedido { get; set; }
        public List<PedidoItemViewModel> PedidoItems { get; set; }

        public class PedidoItemViewModel
        {
            public decimal Preco { get; set; }
            public string ProdutoId { get; set; }
        }
    }
}
