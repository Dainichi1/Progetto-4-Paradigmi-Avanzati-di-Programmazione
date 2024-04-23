using Unicam.Progetto4.Application.Abstractions.Services;

namespace Unicam.Progetto4.Application.Middlewares
{
    public class MiddlewareRisorsa
    {
        private RequestDelegate _next; 

        public MiddlewareRisorsa(RequestDelegate next
            )
        {
            _next = next;
        }

   
        public async Task Invoke(HttpContext context
            , IRisorsaService risorsaService
            , IConfiguration configuration

            )
        {
            
            context.RequestServices.GetRequiredService<IRisorsaService>();
            

           

            await _next.Invoke(context);
        }

    }
}
