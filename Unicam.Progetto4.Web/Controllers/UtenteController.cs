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
    public class UtenteController : ControllerBase
    {
        private readonly IUtenteService _utenteService;


        public UtenteController (IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }
        

        

        [HttpPost] 
        [Route("list")]

        public IActionResult GetUtenti(GetUtenteRequest request)
        {
            int totalNum = 0;
            var utenti = _utenteService.GetUtenti(request.PageNumber * request.PageSize, request.PageSize, request.Name, out totalNum);


            var response = new GetUtentiResponse();
            var pageFounded = (totalNum / (decimal)request.PageSize);
            response.NumeroPagine = (int)Math.Ceiling(pageFounded);
            response.Utenti = utenti.Select(s =>
            new Application.Models.Dtos.UtenteDto(s)).ToList();

            return Ok(ResponseFactory
                .WithSuccess(response)
                );

        }

       

        [HttpPost]
        [Route("Creazione senza validazione")] 
        public IActionResult CreateUtente(CreateUtenteRequest request)
        {
            var utente = request.ToEntity();
            _utenteService.AddUtente(utente);

            var response = new CreateUtenteResponse();
            response.Utente = new Application.Models.Dtos.UtenteDto(utente);

            return Ok(
                ResponseFactory
                .WithSuccess(response)
                );
        }
    }
}
