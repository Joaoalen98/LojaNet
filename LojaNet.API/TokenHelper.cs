using LojaNet.Models.Entidades;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace LojaNet.API
{
    public class TokenHelper
    {
        private IConfiguration _configuration;

        public TokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GerarTokenUsuario(Usuario usuario)
        {
            var key = _configuration.GetSection("JwtKey").Value;
            var bytesKey = Encoding.ASCII.GetBytes(key);

            var tokenHandler = new JsonWebTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, usuario.Nome),
                    new(ClaimTypes.Email, usuario.Email),
                    new(ClaimTypes.OtherPhone, usuario.Telefone),
                    new("Id", usuario.Id),
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(bytesKey), SecurityAlgorithms.HmacSha256),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return token;
        }
    }
}
