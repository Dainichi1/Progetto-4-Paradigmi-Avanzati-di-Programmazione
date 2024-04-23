
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
        private RequestDelegate _next; 

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
            
            context.RequestServices.GetRequiredService<IUtenteService>();

   

            await _next.Invoke(context);
        }

    }
}
