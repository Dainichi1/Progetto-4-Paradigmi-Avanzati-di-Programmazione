using Unicam.Progetto4.Application.Abstractions.Services;

namespace Unicam.Progetto4.Application.Middlewares
{
    public class MiddlewarePrenotazione
    {
        private RequestDelegate _next; 

        public MiddlewarePrenotazione(RequestDelegate next
            )
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context
            , IPrenotazioneService risorsaService
            , IConfiguration configuration

            )
        { 
            context.RequestServices.GetRequiredService<IRisorsaService>();
            await _next.Invoke(context);
        }
    }
}
