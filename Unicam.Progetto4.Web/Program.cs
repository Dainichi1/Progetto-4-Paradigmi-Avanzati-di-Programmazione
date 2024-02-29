using Unicam.Progetto4.Application.Extensions;
using Unicam.Progetto4.Application.Middlewares;
using Unicam.Progetto4.Models.Extensions;
using Unicam.Progetto4.Web.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddModelServices(builder.Configuration);

var app = builder.Build();

app.AddWebMiddleware()
    .AddApplicationMiddleware();

app.Run();
