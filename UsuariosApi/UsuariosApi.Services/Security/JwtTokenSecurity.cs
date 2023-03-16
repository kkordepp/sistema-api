using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Data.Entities;

namespace UsuariosApi.Services.Security
{
    public class JwtTokenSecurity
    {
        #region Atributos para parametrizar a geração dos tokens

        public static string SecretKey = "aeb718a2-e0be-4b95-9dcc-0f8712db6ee7";

        public static int ExpirationInHours = 6;

        #endregion

        public static string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, usuario.Email) }),

                Expires = DateTime.Now.AddHours(ExpirationInHours),

                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}