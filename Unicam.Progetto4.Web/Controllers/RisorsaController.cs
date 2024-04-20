using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Progetto4.Application.Abstractions.Services;
using Unicam.Progetto4.Application.Factories;
using Unicam.Progetto4.Application.Models.Dtos;
using Unicam.Progetto4.Application.Models.Requests;
using Unicam.Progetto4.Application.Models.Responses;
using Unicam.Progetto4.Application.Services;
using Unicam.Progetto4.Application.Validators;
using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Web.Controllers
{
    
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RisorsaController : ControllerBase
    {
        private readonly IRisorsaService _risorsaService;
        private readonly IValidator<CreateRisorsaRequest> _validator;

        public RisorsaController(IRisorsaService risorsaService, IValidator<CreateRisorsaRequest> validator)
        {
            _risorsaService = risorsaService;
            _validator = validator;
        }




        [HttpPost]
        [Route("list")]

        public IActionResult GetRisorse(GetRisorsaRequest request)
        {
            int totalNum = 0;
            var risorse = _risorsaService.GetRisorse(request.PageNumber * request.PageSize, request.PageSize, request.Name, out totalNum);


            var response = new GetRisorseResponse();
            var pageFounded = (totalNum / (decimal)request.PageSize);
            response.NumeroPagine = (int)Math.Ceiling(pageFounded);
            response.Risorse = risorse.Select(s =>
            new Application.Models.Dtos.RisorsaDto(s)).ToList();

            return Ok(ResponseFactory
                .WithSuccess(response)
                );

        }



        [HttpPost]
        [Route("Creazione con validazione")]
        public IActionResult CreateRisorsa(CreateRisorsaRequest request)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var risorsa = request.ToEntity();
            _risorsaService.AddRisorsa(risorsa);

            var response = new CreateRisorsaResponse
            {
                Risorsa = new RisorsaDto(risorsa)
            };

            return Ok(ResponseFactory.WithSuccess(response));
        }

        [HttpPost]
        [Route("Ricerca disponibilità con validazione")]
        public IActionResult GetDisponibilita(GetDisponibilitaRequest request)
        {
            int totalItems;
            var disponibilita = _risorsaService.GetDisponibilita(
                (request.PageNumber - 1) * request.PageSize,
                request.PageSize,
                request.DataInizio,
                request.DataFine,
                request.CodiceRisorsa,
                out totalItems);

            var totalPages = (int)Math.Ceiling((double)totalItems / request.PageSize);

            
            var response = new
            {
                Risorse = disponibilita, 
                TotalPages = totalPages,
                TotalItems = totalItems
            };

            return Ok(ResponseFactory.WithSuccess(response));
        }
    }
}
