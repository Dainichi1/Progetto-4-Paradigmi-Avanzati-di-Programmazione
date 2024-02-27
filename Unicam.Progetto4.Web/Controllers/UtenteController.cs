using Microsoft.AspNetCore.Mvc;
using Unicam.Progetto4.Application.Abstractions.Services;
using Unicam.Progetto4.Application.Models.Requests;
using Unicam.Progetto4.Application.Models.Responses;
using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UtenteController : ControllerBase
    {
        private readonly IUtenteService _utenteService;

        public UtenteController (IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }
        

        

        [HttpGet] 
        [Route("list")] 

        public IEnumerable<Utente> GetUtenti()
        {
            return null;
        }

        [HttpGet]
        [Route("get/{id:int}")] 
        public Utente GetUtente(int id)
        {
            // return utenti.Where(w => w.IdUtente == id).First();
            return null;
        }

        [HttpPost]
        [Route("Creazione senza validazione")] 
        public IActionResult CreateUtente(CreateUtenteRequest request)
        {
            var utente = request.ToEntity();
            _utenteService.AddUtente(utente);

            var response = new CreateUtenteResponse();
            response.Utente = new Application.Models.Dto.UtenteDto(utente);

            return Ok(response);
        }
    }
}
