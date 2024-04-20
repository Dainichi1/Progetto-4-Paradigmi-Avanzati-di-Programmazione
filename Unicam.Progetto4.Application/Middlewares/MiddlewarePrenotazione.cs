using Unicam.Progetto4.Application.Abstractions.Services;

namespace Unicam.Progetto4.Application.Middlewares
{
    public class MiddlewarePrenotazione
    {
        private RequestDelegate _next; // serve per passare al middleware successivo

        public MiddlewarePrenotazione(RequestDelegate next
            )
        {
            _next = next;
        }

        // Implemento il codice effettivo del middleware
        public async Task Invoke(HttpContext context
            , IPrenotazioneService risorsaService
            , IConfiguration configuration

            )
        {
            
            context.RequestServices.GetRequiredService<IRisorsaService>();
            

            // per andare al middleware successivo devo chiamare _next.Ivoke

            await _next.Invoke(context);
        }

    }
}
