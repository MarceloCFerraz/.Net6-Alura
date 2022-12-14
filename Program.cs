/*
    necessary packages to this project:
        - Microsoft.EntityFrameworkCore -v 7.0.0
        - Microsoft.EntityFrameworkCore.Tools -v 7.0.0
        - Microsoft.EntityFrameworkCore.Relational -v 7.0.0
        - Pomelo.EntityFrameworkCore.MySql -v 6.0.2
        - AutoMapper -v 12.0.0
        - AutoMapper.Extensions.Microsoft.DependencyInjection -v 12.0.0
        - Microsoft.AspNetCore.Mvc.NewtonsoftJson -v 6.0.10 <IN CASE IT'S NECESSARY TO USE HTTP PATCH INSTEAD OF PUT>

    necessary tools for this project:
        - dotnet-ef -v 7.0.0

    Console commands:
        - dotnet add package Microsoft.EntityFrameworkCore -v 7.0.0
        - dotnet add package Microsoft.EntityFrameworkCore.Tools -v 7.0.0
        - dotnet add package Microsoft.EntityFrameworkCore.Relational -v 7.0.0
        - dotnet add package Pomelo.EntityFrameworkCore.MySql -v 6.0.2
        - dotnet add package AutoMapper -v 12.0.0
        - dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection -v 12.0.0
        - dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson -v 6.0.10
        - dotnet tool install --global dotnet-ef -v 7.0.0
        - dotnet ef migrations add <NomeDaMigration>
        - dotnet ef database update
*/


using System.Reflection;
using DotNet6.Data;
using DotNet6.Services.Filme;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Database Connection
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");

builder.Services.AddDbContext<FilmeContext>(
    opts => opts.UseMySql(
        connectionString, 
        ServerVersion.AutoDetect(connectionString)
    )
);

// Add services to the container.
// adding controllers services
builder.Services.AddScoped<FilmeService, FilmeService>();

// adding automapper service to the whole application
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FilmesAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
