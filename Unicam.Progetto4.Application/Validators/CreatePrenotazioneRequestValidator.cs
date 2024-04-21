using FluentValidation;
using Unicam.Progetto4.Application.Models.Requests;
using Unicam.Progetto4.Models.Context;

namespace Unicam.Progetto4.Application.Validators
{
    public class CreatePrenotazioneValidator : AbstractValidator<CreatePrenotazioneRequest>
    {
        public CreatePrenotazioneValidator(MyDbContext dbContext)
        {
            RuleFor(x => x.DataInizio)
                .NotNull().WithMessage("La data di inizio è obbligatoria.")
                .NotEmpty().WithMessage("La data di inizio è obbligatoria.");

            RuleFor(x => x.DataFine)
                .NotNull().WithMessage("La data di fine è obbligatoria.")
                .NotEmpty().WithMessage("La data di fine è obbligatoria.")
                .GreaterThan(x => x.DataInizio).WithMessage("La data di fine deve essere maggiore della data di inizio.");

            RuleFor(x => x.IdRisorsa)
                .NotNull().WithMessage("L'id della risorsa è obbligatorio.")
                .NotEmpty().WithMessage("L'id della risorsa è obbligatorio.")
                .Must(id => dbContext.Risorse.Any(r => r.IdRisorsa == id)).WithMessage("La risorsa specificata non esiste.");

            RuleFor(x => x)
                .Must(request =>
                    !dbContext.Prenotazioni.Any(p =>
                        p.IdRisorsa == request.IdRisorsa &&
                        ((request.DataInizio <= p.DataFine && request.DataFine >= p.DataInizio))
                    )
                ).WithMessage("La risorsa non è libera nell'intervallo di tempo specificato.");

        }
    }
}
