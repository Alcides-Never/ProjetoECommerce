using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceAPI.Services
{
    public class TokenService
    {
        public string GenerateToken(string email)
        {
            // Claims - Informações do Usuário que quero guardar

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email)
            };

            // Criar uma chave de segurança e criptografar ela

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-secreta-senai"));

        }

    }
}
