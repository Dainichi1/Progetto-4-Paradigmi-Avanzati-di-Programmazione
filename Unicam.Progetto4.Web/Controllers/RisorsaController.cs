using Microsoft.AspNetCore.Mvc;
using Unicam.Progetto4.Application.Abstractions.Services;
using Unicam.Progetto4.Application.Models.Requests;
using Unicam.Progetto4.Application.Models.Responses;
using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Web.Controllers
{
    
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RisorsaController : ControllerBase
    {
        private readonly IRisorsaService _risorsaService;

        public RisorsaController(IRisorsaService risorsaService)
        {
            _risorsaService = risorsaService;
        }




        [HttpGet]
        [Route("list")]

        public IEnumerable<Risorsa> GetRisorsa()
        {
            return null;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public Risorsa GetRisorsa(int id)
        {
            // return utenti.Where(w => w.IdUtente == id).First();
            return null;
        }

        [HttpPost]
        [Route("Creazione con validazione")]
        public IActionResult CreateRisorsa(CreateRisorsaRequest request)
        {
            var risorsa = request.ToEntity();
            _risorsaService.AddRisorsa(risorsa);

            var response = new CreateRisorsaResponse();
            response.Risorsa = new Application.Models.Dto.RisorsaDto(risorsa);
            
            return Ok(response);
        }
    }
}
