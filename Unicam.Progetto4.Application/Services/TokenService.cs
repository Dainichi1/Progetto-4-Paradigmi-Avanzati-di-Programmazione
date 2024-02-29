using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Unicam.Progetto4.Application.Abstractions.Services;
using Unicam.Progetto4.Application.Models.Requests;
using Unicam.Progetto4.Application.Options;

namespace Unicam.Progetto4.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtAuthenticationOption _jwtAuthOption;
        public TokenService(IOptions<JwtAuthenticationOption> jwtAuthOption)
        {
            _jwtAuthOption = jwtAuthOption.Value;
        }
        public string CreateToken(CreateTokenRequest request)
        {
            // STEP 1: verificare esatezza della coppia username/password

            // STEP SUCCESSIVI
            
            
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Nome", "Marco"));
            claims.Add(new Claim("Cognome", "Torquati"));
            
            // chiave simmetrica
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtAuthOption.Key)
                );

            // creo credenziali di firma
            var credentials = new SigningCredentials(securityKey
                , SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(_jwtAuthOption.Issuer
                , null
                , claims
                , expires: DateTime.Now.AddMinutes(30)
                , signingCredentials : credentials
                );


            // prendo il token
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            // STEP 3: Restituisco il token 
            return token;

        }
    }
}
