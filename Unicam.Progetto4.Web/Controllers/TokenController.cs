using Microsoft.AspNetCore.Mvc;
using Unicam.Progetto4.Application.Abstractions.Services;
using Unicam.Progetto4.Application.Factories;
using Unicam.Progetto4.Application.Models.Requests;
using Unicam.Progetto4.Application.Models.Responses;

namespace Unicam.Progetto4.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TokenController : Controller
    {

        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Creazione di un token")] //serve per creare un token
        public IActionResult Create(CreateTokenRequest request)
        {
            
            // validazione della richiesta
            string token = _tokenService.CreateToken(request);
            return Ok(
                ResponseFactory.WithSuccess(
                    new CreateTokenResponse(token)
                    )
                );
                
        }
    }
}
