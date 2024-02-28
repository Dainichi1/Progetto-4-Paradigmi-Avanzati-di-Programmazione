using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Unicam.Progetto4.Application.Abstractions.Services;
using Unicam.Progetto4.Application.Middlewares;
using Unicam.Progetto4.Application.Options;
using Unicam.Progetto4.Application.Services;
using Unicam.Progetto4.Models.Context;
using Unicam.Progetto4.Models.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Unicam Paradigmi Progetto 4",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(
    AppDomain.CurrentDomain.GetAssemblies().
        SingleOrDefault(assembly  => assembly.GetName().Name == "Unicam.Progetto4.Application") 
        );

builder.Services.AddDbContext<MyDbContext>(conf =>
{
    conf.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext"));
});

builder.Services.AddScoped<IUtenteService, UtenteService>();
builder.Services.AddScoped<UtenteRepository>();

builder.Services.AddScoped<IRisorsaService, RisorsaService>();
builder.Services.AddScoped<RisorsaRepository>();

builder.Services.AddScoped<IPrenotazioneService, PrenotazioneService>();
builder.Services.AddScoped<PrenotazioneRepository>();

builder.Services.AddScoped<ITokenService, TokenService>();

var jwtAuthenticationOption = new JwtAuthenticationOption();
builder.Configuration.GetSection("JwtAuthentication")
    .Bind(jwtAuthenticationOption);

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        string key = jwtAuthenticationOption.Key;
        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key)
            );
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtAuthenticationOption.Issuer,
            IssuerSigningKey = securityKey

        };
        
    });





builder.Services.Configure<JwtAuthenticationOption>(
    builder.Configuration.GetSection("JwtAuthentication")
    );

var app = builder.Build();


app.UseMiddleware<MiddlewareUtente>();
app.UseMiddleware<MiddlewareRisorsa>();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
