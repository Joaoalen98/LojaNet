using LojaNet.DAL;
using LojaNet.Models.Entidades;
using LojaNet.Models.Interfaces;

namespace LojaNet.Test
{
    [TestClass]
    public class PedidoTest
    {
        private readonly Pedido _pedidoMock = new()
        {
            Id = "IdTeste",
            UsuarioId = "IdTeste",
            PedidoItems = new List<Pedido.PedidoItem>
            {
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    PedidoId = "IdTeste",
                    Preco = 30.0m,
                    ProdutoId = "IdTeste"
                }
            }

        };

        private IPedidoData _dal = new PedidoDAL();

        [TestMethod]
        public void CriarTest()
        {
            var criar = _dal.Criar(_pedidoMock);
            if (criar == 0)
            {
                Assert.Fail("O numero de linhas afetadas foi zero");
            }
        }

        [TestMethod]
        public void ObterPorIdTest()
        {
            var exec = _dal.ObterPorId(_pedidoMock.Id);
            if (exec != null)
            {
                Console.WriteLine($"Pedido Id: {exec.Id} - Usuario Id: {exec.UsuarioId}");
            }
        }

        [TestMethod]
        public void DeletarTest()
        {
            var criar = _dal.Deletar(_pedidoMock.Id);
            if (criar == 0)
            {
                Assert.Fail("O numero de linhas afetadas foi zero");
            }
        }

        [TestMethod]
        public void ObterTodosTest()
        {
            var lista = _dal.ObterTodos("IdTeste");
            foreach (var item in lista)
            {
                Console.WriteLine($"Pedido Id: {item.Id} - Usuario Id: {item.UsuarioId}");
            }
        }
    }
}
