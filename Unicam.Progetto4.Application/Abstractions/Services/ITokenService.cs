using Unicam.Progetto4.Application.Models.Requests;

namespace Unicam.Progetto4.Application.Abstractions.Services
{
    public interface ITokenService
    {
        string CreateToken(CreateTokenRequest request);
    }
}
