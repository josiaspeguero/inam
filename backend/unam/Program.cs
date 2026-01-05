using Microsoft.EntityFrameworkCore;
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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
