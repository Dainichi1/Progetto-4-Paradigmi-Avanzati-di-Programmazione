using FluentValidation;
using Unicam.Progetto4.Application.Abstractions.Services;
using Unicam.Progetto4.Application.Services;
using Unicam.Progetto4.Application.Validators;
using Unicam.Progetto4.Models.Context;
using Unicam.Progetto4.Models.Repositories;

namespace Unicam.Progetto4.Application.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddValidatorsFromAssembly(
                AppDomain.CurrentDomain.GetAssemblies().
                SingleOrDefault(assembly => assembly.GetName().Name == "Unicam.Progetto4.Application")
            );

            services.AddValidatorsFromAssemblyContaining<CreateRisorsaRequestValidator>(); //aggiunta

            services.AddScoped<IUtenteService, UtenteService>();
            services.AddScoped<IRisorsaService, RisorsaService> ();
            services.AddScoped<IPrenotazioneService, PrenotazioneService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }

    }
}
