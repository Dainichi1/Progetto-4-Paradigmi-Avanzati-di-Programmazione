
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto4.Application.Abstractions.Services;

namespace Unicam.Progetto4.Application.Middlewares
{
    public class MiddlewareUtente
    {
        private RequestDelegate _next; // serve per passare al middleware successivo

        public MiddlewareUtente(RequestDelegate next
            )
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context
            , IUtenteService utenteService
            , IConfiguration configuration
           
            )
        {
            // Console.WriteLine(emailOption.Value.Host);
            context.RequestServices.GetRequiredService<IUtenteService>();
            // Implemento il codice effettivo del middleware

            // per andare al middleware successivo devo chiamare _next.Ivoke

            await _next.Invoke(context);
            // await context.Response.WriteAsync("Blocco la chiamata");
        }

    }
}
