using LojaNet.DAL;
using LojaNet.Helpers;
using LojaNet.Models.Entidades;
using LojaNet.Models.Enums;

namespace LojaNet.Test
{
    [TestClass]
    public class UsuarioDALTest
    {
        private readonly UsuarioDAL _usuarioDAL = new();
        private static readonly string _usuarioMockSenha = "SenhaTeste";
        private readonly Usuario _usuarioMock = new()
        {
            Id = "IdTeste",
            Email = "email@email.com",
            Nome = "Nome Teste",
            Role = RoleEnum.Cliente,
            Senha = HashHelper.HashSenha(_usuarioMockSenha),
            Telefone = "11955554444"
        };

        [TestMethod]
        public void CriarTest()
        {
            var criar = _usuarioDAL.Criar(_usuarioMock);

            if (criar == 0)
            {
                Assert.Fail("O numero de linhas afetadas foi zero");
            }
        }

        [TestMethod]
        public void ObterPorIdTest()
        {
            var usuario = _usuarioDAL.ObterPorId(_usuarioMock.Id);
            if (usuario != null)
            {
                Console.WriteLine($"Nome: {usuario.Nome} - Email: {usuario.Email}");
            }
        }


        [TestMethod]
        public void AlterarTest()
        {
            var alterar = _usuarioDAL.Alterar(_usuarioMock);

            if (alterar == 0)
            {
                Assert.Fail("O numero de linhas afetadas foi zero");
            }
        }

        [TestMethod]
        public void DeletarTest()
        {
            var del = _usuarioDAL.Deletar(_usuarioMock.Id);

            if (del == 0)
            {
                Assert.Fail("O numero de linhas afetadas foi zero");
            }
        }

        [TestMethod]
        public void ObterPorEmailTest()
        {
            var usuario = _usuarioDAL.ObterPorEmail(_usuarioMock.Email);
            if (usuario != null)
            {
                Console.WriteLine($"Nome: {usuario.Nome} - Email: {usuario.Email}");
            }
        }
    }
}
