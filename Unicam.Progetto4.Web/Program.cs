using FluentValidation;
using FluentValidation.AspNetCore;

using Microsoft.EntityFrameworkCore;
using Unicam.Progetto4.Application.Abstractions.Services;
using Unicam.Progetto4.Application.Middlewares;
using Unicam.Progetto4.Application.Services;
using Unicam.Progetto4.Models.Context;
using Unicam.Progetto4.Models.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(
    AppDomain.CurrentDomain.GetAssemblies().
        SingleOrDefault(assembly  => assembly.GetName().Name == "Unicam.Progetto4.Application") 
        );

builder.Services.AddDbContext<MyDbContext>(conf =>
{
    conf.UseSqlServer("data source=localhost;Initial catalog=Progetto;User Id=progetto;Password=progetto;TrustServerCertificate=True");
});

builder.Services.AddScoped<IUtenteService, UtenteService>();
builder.Services.AddScoped<UtenteRepository>();

builder.Services.AddScoped<IRisorsaService, RisorsaService>();
builder.Services.AddScoped<RisorsaRepository>();


var app = builder.Build();


app.UseMiddleware<MiddlewareUtente>();
app.UseMiddleware<MiddlewareRisorsa>();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
