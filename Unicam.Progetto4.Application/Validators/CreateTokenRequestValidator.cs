using FluentValidation;
using FluentValidation.AspNetCore;
using Unicam.Progetto4.Application.Extensions;
using Unicam.Progetto4.Application.Models.Requests;

namespace Unicam.Progetto4.Application.Validators
{
    public class CreateTokenRequestValidator : AbstractValidator<CreateTokenRequest>
    {
        public CreateTokenRequestValidator() 
        {
            RuleFor(r => r.Username)
                .NotEmpty()
                .WithMessage("Il campo Username è obbligatorio")
                .NotNull()
                .WithMessage("Il campo Username non può essere nullo");

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Il campo Password è obbligatorio")
                .NotNull()
                .WithMessage("Il campo Password non può essere nullo")
                .MinimumLength(6)
                .WithMessage("Il campo password deve essere almeno lungo 6 caratteri")
                .RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$"
                , "Il campo password deve essere lungo almeno 6 caratteri e deve contenere almeno un carattere maiuscolo, uno minuscolo, un numero e un carattere speciale"
                );
        }
    }
}
