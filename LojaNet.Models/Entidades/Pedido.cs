namespace LojaNet.Models.Entidades
{
    public class Pedido : BaseEntidade
    {
        public DateTime DataPedido { get; set; }
        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public List<PedidoItem> PedidoItems { get; set; }


        public Pedido()
        {
            PedidoItems = new List<PedidoItem>();
        }

        public class PedidoItem : BaseEntidade
        {
            public decimal Preco { get; set; }
            public string ProdutoId { get; set; }
            public virtual Produto Produto { get; set; }
            public string PedidoId { get; set; }
            public virtual Pedido Pedido { get; set; }
        }
    }
}
