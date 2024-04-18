using Azure.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Progetto4.Application.Abstractions.Services;
using Unicam.Progetto4.Application.Factories;
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




        [HttpPost]
        [Route("list")]

        public IActionResult GetPrenotazioni(GetPrenotazioneRequest request)
        {
            int totalNum = 0;
            var prenotazioni = _prenotazioneService.GetPrenotazioni(request.PageNumber * request.PageSize, request.PageSize, request.Id, out totalNum);
            var response = new GetPrenotazioniResponse();
            var pageFounded = (totalNum / (decimal)request.PageSize);
            response.NumeroPagine = (int)Math.Ceiling(pageFounded);
            response.Prenotazioni = prenotazioni.Select(s =>
            new Application.Models.Dtos.PrenotazioneDto(s)).ToList();
            
            return Ok(ResponseFactory
            .WithSuccess(response)
                 ); 
        }

        [HttpPost]
        [Route("get/{id:int}")]
        public Prenotazione GetPrenotazione(int id)
        {
            // return utenti.Where(w => w.IdUtente == id).First();
            return null ;
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
