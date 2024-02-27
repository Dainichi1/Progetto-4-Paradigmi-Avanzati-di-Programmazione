using FluentValidation;
using Unicam.Progetto4.Application.Models.Requests;

namespace Unicam.Progetto4.Application.Validators
{
    public class CreateUtenteRequestValidator : AbstractValidator<CreateUtenteRequest>
    {
        public CreateUtenteRequestValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Il nome è obbligatorio.");

            RuleFor(x => x.Cognome)
                .NotEmpty().WithMessage("Il cognome è obbligatorio.");

            
        }
    }

}