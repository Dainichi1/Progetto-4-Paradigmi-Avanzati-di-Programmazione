using FluentValidation;
using Unicam.Progetto4.Application.Models.Requests;
using Unicam.Progetto4.Models.Context;

namespace Unicam.Progetto4.Application.Validators
{
    public class CreateDisponibilitaRequestValidator : AbstractValidator<GetDisponibilitaRequest>
    {
        
        public CreateDisponibilitaRequestValidator(MyDbContext dbContext)
        {
            RuleFor(x => x.DataInizio)
            .NotEmpty().WithMessage("Data di Inizio obbligatoria")
            .Must(date => BeAValidDate(date)).WithMessage("Data di Inizio non valida.");

            RuleFor(x => x.DataFine)
                .NotEmpty().WithMessage("Data fine obbligatoria")
                .Must(date => BeAValidDate(date)).WithMessage("Data fine non valida.")
                .GreaterThanOrEqualTo(x => x.DataInizio).WithMessage("La data di fine deve essere maggiore o uguale alla data di inizio.");


            When(x => x.IdRisorsa.HasValue, () =>
            {
                RuleFor(x => x.IdRisorsa)
                    .Must(codice => dbContext.Risorse.Any(r => r.IdRisorsa == codice))
                    .WithMessage("La risorsa specificata non esiste.");

                RuleFor(x => x)
                    .Must(request => IsRisorsaAvailable(request, dbContext))
                    .WithMessage("Risorsa non disponibile per le date selezionate.");
            });
        }

        public static bool BeAValidDate(DateTime? date)
        {
            return date != null && date.Value > DateTime.MinValue && date.Value < DateTime.MaxValue;
        }

        private bool IsRisorsaAvailable(GetDisponibilitaRequest request, MyDbContext dbContext)
        {
            if (!request.IdRisorsa.HasValue)
            {
                return true;
            }
            return !dbContext.Prenotazioni.Any(p =>
                p.IdRisorsa == request.IdRisorsa.Value &&
                ((p.DataInizio < request.DataFine) && (request.DataInizio < p.DataFine)));
        }
    }
}
