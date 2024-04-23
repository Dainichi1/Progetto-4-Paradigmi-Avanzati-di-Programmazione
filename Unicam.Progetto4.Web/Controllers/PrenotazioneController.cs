using Azure.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Progetto4.Application.Abstractions.Services;
using Unicam.Progetto4.Application.Factories;
using Unicam.Progetto4.Application.Models.Requests;
using Unicam.Progetto4.Application.Models.Responses;
using Unicam.Progetto4.Application.Services;
using Unicam.Progetto4.Models.Entities;


namespace Unicam.Progetto4.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PrenotazioneController : ControllerBase
    {
        private readonly IPrenotazioneService _prenotazioneService;
        private readonly IRisorsaService _risorsaService;
        public PrenotazioneController(IPrenotazioneService prenotazioneService, IRisorsaService risorsaService)
        {
            _prenotazioneService = prenotazioneService;
            _risorsaService = risorsaService;
        }


        [HttpPost]
        [Route("Lista Prenotazioni")]

        public IActionResult GetPrenotazioni(GetPrenotazioneRequest request)
        {
            if (request.PageSize <= 0)
            {
                return BadRequest("Il campo Page Size non può essere 0");
            }
            int? idRisorsa = null;
            if (!string.IsNullOrWhiteSpace(request.Id))
            {
                if (!int.TryParse(request.Id, out int idParsed))
                {
                    return BadRequest("Id Risorsa non valido");
                }
                idRisorsa = idParsed;
                if (idRisorsa.HasValue && !_risorsaService.RisorsaExists(idRisorsa.Value))
                {
                    return NotFound("Id Risorsa non presente");
                }

            }
            int totalNum = 0;
            var prenotazioni = _prenotazioneService.GetPrenotazioni(request.PageNumber * request.PageSize, request.PageSize, request.Id, out totalNum);
            var response = new GetPrenotazioniResponse();
            var pageFounded = (totalNum / (decimal)request.PageSize);
            response.NumeroPagine = (int)Math.Ceiling(pageFounded);
            response.Prenotazioni = prenotazioni.Select(s =>
            new Application.Models.Dtos.PrenotazioneDto(s)).ToList();
            if (idRisorsa.HasValue && !response.Prenotazioni.Any())
            {
                return NotFound("Nessuna prenotazione trovata per l'Id Risorsa specificato.");
            }

            return Ok(ResponseFactory
            .WithSuccess(response)
                 ); 
        }


        [HttpPost]
        [Route("Creazione con validazione")]
        public IActionResult CreatePrenotazione(CreatePrenotazioneRequest request)
        {
            
            var prenotazione = request.ToEntity();
            _prenotazioneService.AddPrenotazione(prenotazione);

            var response = new CreatePrenotazioneResponse();
            response.Prenotazione = new Application.Models.Dtos.PrenotazioneDto(prenotazione);

            return Ok(ResponseFactory
                .WithSuccess(response)
                );
        }
    }
}
