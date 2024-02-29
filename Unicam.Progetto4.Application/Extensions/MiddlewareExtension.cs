using Unicam.Progetto4.Application.Middlewares;

namespace Unicam.Progetto4.Application.Extensions
{
    public static class MiddlewareExtension
    {
        public static WebApplication? AddApplicationMiddleware (this WebApplication? app) 
        {
            app.UseMiddleware<MiddlewareUtente>();
            app.UseMiddleware<MiddlewareRisorsa>();
            app.UseMiddleware<MiddlewarePrenotazione>();
            return app;
        }
    }
}
