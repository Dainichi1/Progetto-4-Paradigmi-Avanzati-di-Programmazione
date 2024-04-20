using Unicam.Progetto4.Application.Abstractions.Services;

namespace Unicam.Progetto4.Application.Middlewares
{
    public class MiddlewareRisorsa
    {
        private RequestDelegate _next; // serve per passare al middleware successivo

        public MiddlewareRisorsa(RequestDelegate next
            )
        {
            _next = next;
        }

        // Implemento il codice effettivo del middleware
        public async Task Invoke(HttpContext context
            , IRisorsaService risorsaService
            , IConfiguration configuration

            )
        {
            
            context.RequestServices.GetRequiredService<IRisorsaService>();
            

            // per andare al middleware successivo devo chiamare _next.Ivoke

            await _next.Invoke(context);
        }

    }
}
