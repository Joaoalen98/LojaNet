using LojaNet.DAL;
using LojaNet.Models.Entidades;
using LojaNet.Models.Interfaces;

namespace LojaNet.Test
{
    [TestClass]
    public class ProdutoDALTest
    {
        private readonly IProdutoData _dal = new ProdutoDAL();
        private Produto _produtoMock = new Produto()
        {
            Id = "IdTeste",
            Nome = "Nome Produto Teste",
            Preco = 10.90m,
            Quantidade = 100,
        };


        [TestMethod]
        public void CriarTest()
        {
            var exec = _dal.Criar(_produtoMock);

            if (exec == 0)
            {
                Assert.Fail("O numero de linhas afetadas foi 0");
            }
        }

        [TestMethod]
        public void AlterarTest()
        {
            var exec = _dal.Alterar(_produtoMock);

            if (exec == 0)
            {
                Assert.Fail("O numero de linhas afetadas foi 0");
            }
        }

        [TestMethod]
        public void ObterPorIdTest()
        {
            var exec = _dal.ObterPorId(_produtoMock.Id);

            if (exec != null)
            {
                Console.WriteLine($"Nome: {exec.Nome} - Preco: {exec.Preco}");
            }
        }

        [TestMethod]
        public void ObterTodosTest()
        {
            var exec = _dal.ObterTodos(null);

            foreach (var item in exec)
            {
                Console.WriteLine($"Nome: {item.Nome} - Preco: {item.Preco}");
            }
        }

        [TestMethod]
        public void DeletarTest()
        {
            var exec = _dal.Deletar(_produtoMock.Id);

            if (exec == 0)
            {
                Assert.Fail("O numero de linhas afetadas foi 0");
            }
        }
    }
}
