using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Unicam.Progetto4.Application.Models.Requests;
using Unicam.Progetto4.Models.Context;

namespace Unicam.Progetto4.Application.Validators
{
    public class CreateRisorsaRequestValidator : AbstractValidator<CreateRisorsaRequest>
    {
        private readonly MyDbContext _dbContext;

        public CreateRisorsaRequestValidator(MyDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Il nome della risorsa è obbligatorio.");

            RuleFor(x => x.IdRisorsaTipologia)
                .InclusiveBetween(1, 5).WithMessage("IdRisorsaTipologia deve essere tra 1 e 5.");

            RuleFor(x => x)
            .Must((request) => {
                var esiste = _dbContext.Risorse.Any(r => r.IdRisorsa == request.IdRisorsa && r.Nome != request.Nome);
                return !esiste;
            }).WithMessage("Esiste già una risorsa con lo stesso ID ma con un nome diverso.");

            RuleFor(x => x.IdRisorsaTipologia)
                .Must((idRisorsaTipologia) => {
                    return _dbContext.RisorseTipologia.Any(rt => rt.IdRisorsaTipologia == idRisorsaTipologia);
                }).WithMessage("IdRisorsaTipologia non valido.");
        }
    }
}
