using LojaNet.BLL;
using LojaNet.Models.Interfaces;

namespace LojaNet.Test
{
    [TestClass]
    public class UsuarioBLLTest
    {
        private readonly string _emailUsuario = "email@email.com";
        private readonly string _senhaUsuario = "SenhaTeste";
        private readonly IUsuarioData _bll = new UsuarioBLL();

        [TestMethod]
        public void ObterPorEmailSenhaTest()
        {
            var usuario = _bll.ObterPorEmailSenha(_emailUsuario, _senhaUsuario);
            if (usuario == null)
            {
                Assert.Fail(@"Deveria retornar uma ApplicationException
                    informando que o email e a senha estão incorretos.");
            }
            else
            {
                Console.WriteLine($"Nome: {usuario.Nome} - Email: {usuario.Email}");
            }
        }
    }
}
