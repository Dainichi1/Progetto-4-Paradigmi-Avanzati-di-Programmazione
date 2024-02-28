using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Progetto4.Application.Abstractions.Services;
using Unicam.Progetto4.Application.Models.Requests;
using Unicam.Progetto4.Application.Models.Responses;
using Unicam.Progetto4.Models.Entities;


namespace Unicam.Progetto4.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PrenotazioneController : ControllerBase
    {
        private readonly IPrenotazioneService _prenotazioneService;

        public PrenotazioneController(IPrenotazioneService prenotazioneService)
        {
            _prenotazioneService = prenotazioneService;
        }




        [HttpGet]
        [Route("list")]

        public IEnumerable<Prenotazione> GetPrenotazione()
        {
            return null;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public Prenotazione GetPrenotazione(int id)
        {
            // return utenti.Where(w => w.IdUtente == id).First();
            return null;
        }

        [HttpPost]
        [Route("Creazione con validazione")]
        public IActionResult CreatePrenotazione(CreatePrenotazioneRequest request)
        {
            var prenotazione = request.ToEntity();
            _prenotazioneService.AddPrenotazione(prenotazione);

            var response = new CreatePrenotazioneResponse();
            response.Prenotazione = new Application.Models.Dtos.PrenotazioneDto(prenotazione);

            return Ok(prenotazione);
        }
    }
}
