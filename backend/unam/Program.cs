using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using unam.Application.UseCases;
using unam.Context;
using unam.Domain.Interfaces;
using unam.Domain.Repositories;
using unam.Middlewares;
using unam.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//interfaces
builder.Services.AddScoped<ISolicitudesRepository, SolicitudesRepository>();
builder.Services.AddScoped<IEstudiantesRepository, EstudiantesRepository>();
builder.Services.AddScoped<ISeccionesRepository, SeccionesRepository>();
builder.Services.AddScoped<IMaestrosRepository, MaestroRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//usecases
builder.Services.AddScoped<CrearSolicitud>();
builder.Services.AddScoped<VerSolicitudes>();
builder.Services.AddScoped<CrearCuenta>();

//trasient
builder.Services.AddTransient<IEnviarAviso>();

//appDbContext
builder.Services.AddDbContext<ApplicationDbContext>(conf => conf.UseSqlServer("connectionString"));
//automapper settings
builder.Services.AddAutoMapper(conf =>
{
    conf.AddProfile<AutoMapperProfile>();
});

//cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("global", options =>
    {
        options.AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://localhost:3000")
        .AllowCredentials();
    });
});

//jwt
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["jwt:issuer"],
        ValidAudience = builder.Configuration["jwt:audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration["jwt:key"]))
    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.HttpContext.Request.Cookies["AuthToken"];
            return Task.CompletedTask;
        }
    };
});


//ratelimiting
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    options.AddFixedWindowLimiter("fixed-ip", optionsLimiter =>
    {
        optionsLimiter.PermitLimit = 10;
        optionsLimiter.Window = TimeSpan.FromMinutes(1);
    });
});
//builder
var app = builder.Build();

//manejo de falta de autorizacion 401
app.UseStatusCodePages(async context =>
{
    context.HttpContext.Response.StatusCode = 401;
    var mensaje = JsonSerializer.Serialize(new
    {
        mensaje = "Debe estar autenticado para acceder"
    });
    await context.HttpContext.Response.WriteAsync(mensaje);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors("global");

app.UseMiddleware<HandleGlobalMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
