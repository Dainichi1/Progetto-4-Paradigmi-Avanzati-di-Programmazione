using Microsoft.AspNetCore.Mvc;
using Unicam.Progetto4.Application.Abstractions.Services;
using Unicam.Progetto4.Application.Models.Requests;

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
        [Route("create")] //serve per creare un token
        public IActionResult Create(CreateTokenRequest request)
        {
            // STEP 0: validazione della richiesta
            string token = _tokenService.CreateToken(request);
            return Ok(token);
        }
    }
}
