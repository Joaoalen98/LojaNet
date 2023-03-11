using static BCrypt.Net.BCrypt;

namespace LojaNet.Helpers
{
    public static class HashHelper
    {
        public static string HashSenha(string senha)
        {
            var salt = GenerateSalt(10);
            return HashPassword(senha, salt);
        }

        public static bool ComparaSenha(string senha, string hash)
            => Verify(senha, hash);
    }
}
