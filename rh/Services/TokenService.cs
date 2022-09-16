

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using Microsoft.OpenApi.Extensions;
using rh.Models;
using rh.Security;

namespace rh.Services {
    public static class TokenService {


        public static string GenerateToken(Funcionario funcionario){

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var claims = new Claim[]{
                new Claim(ClaimTypes.Name, funcionario.Nome),
                new Claim(ClaimTypes.Role, funcionario.Permissao.GetDisplayName())
            };
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}