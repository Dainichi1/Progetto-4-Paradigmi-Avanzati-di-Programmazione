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
        public async Task Invoke(HttpContext context
            , IPrenotazioneService risorsaService
            , IConfiguration configuration

            )
        {
            // Console.WriteLine(emailOption.Value.Host);
            context.RequestServices.GetRequiredService<IRisorsaService>();
            // Implemento il codice effettivo del middleware

            // per andare al middleware successivo devo chiamare _next.Ivoke

            await _next.Invoke(context);
            // await context.Response.WriteAsync("Blocco la chiamata");
        }

    }
}
