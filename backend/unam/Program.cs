using Microsoft.EntityFrameworkCore;
using unam.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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
