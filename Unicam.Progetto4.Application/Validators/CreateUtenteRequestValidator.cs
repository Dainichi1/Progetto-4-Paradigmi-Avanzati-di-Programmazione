using FluentValidation;
using Unicam.Progetto4.Application.Models.Requests;

namespace Unicam.Progetto4.Application.Validators
{
    public class CreateUtenteRequestValidator : AbstractValidator<CreateUtenteRequest>
    {
        public CreateUtenteRequestValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("Il nome è obbligatorio.")
                .NotEmpty().WithMessage("Il nome è obbligatorio.")
                .Must(value => value.ToLower() != "string").WithMessage("Il nome non può essere 'string'.");

            RuleFor(x => x.Cognome)
                .NotNull().WithMessage("Il cognome è obbligatorio.")
                .NotEmpty().WithMessage("Il cognome è obbligatorio.")
                .Must(value => value.ToLower() != "string").WithMessage("Il cognome non può essere 'string'.");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("L'email è obbligatoria.")
                .NotEmpty().WithMessage("L'email è obbligatoria.")
                .EmailAddress().WithMessage("Formato email non valido.")
                .Must(value => value.ToLower() != "string").WithMessage("L'email non può essere 'string'.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("La password è obbligatoria.")
                .NotEmpty().WithMessage("La password è obbligatoria.")
                .Must(value => value.ToLower() != "string").WithMessage("La password non può essere 'string'.");
        }

    }
}