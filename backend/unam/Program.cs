using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using unam.Application.UseCases;
using unam.Context;
using unam.Domain.Interfaces;
using unam.Domain.Repositories;
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

//usecases
builder.Services.AddScoped<CrearSolicitud>();
builder.Services.AddScoped<VerSolicitudes>();

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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors("global");

app.UseAuthorization();

app.MapControllers();

app.Run();
