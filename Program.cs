/*
    necessary packages to this project:
        - Microsoft.EntityFrameworkCore -v 7.0.0
        - Microsoft.EntityFrameworkCore.Tools -v 7.0.0
        - Microsoft.EntityFrameworkCore.Relational -v 7.0.0
        - Pomelo.EntityFrameworkCore.MySql -v 6.0.2
        - AutoMapper -v 12.0.0
        - AutoMapper.Extensions.Microsoft.DependencyInjection -v 12.0.0

    necessary tools for this project:
        - dotnet-ef -v 7.0.0

    Console commands:
        - dotnet add package Microsoft.EntityFrameworkCore -v 7.0.0
        - dotnet add package Microsoft.EntityFrameworkCore.Tools -v 7.0.0
        - dotnet add package Microsoft.EntityFrameworkCore.Relational -v 7.0.0
        - dotnet add package Pomelo.EntityFrameworkCore.MySql -v 6.0.2
        - dotnet add package AutoMapper -v 12.0.0
        - dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection -v 12.0.0
        - dotnet tool install --global dotnet-ef -v 7.0.0
        - dotnet ef migrations add <NomeDaMigration>
        - dotnet ef database update
*/


using DotNet6.Data;
using Microsoft.EntityFrameworkCore;

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
// adding automapper service to the whole application
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
