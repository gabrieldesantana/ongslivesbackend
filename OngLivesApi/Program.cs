using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ONGLIVES.API.Persistence.Context;
using ONGLIVESAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRegisterServices();

builder.Services.AddDbContext<OngLivesContext>(options => {options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"));});

// builder.Services.AddApiVersioning(x => 
// {
//     x.DefaultApiVersion = new ApiVersion(1, 0);
//     x.ReportApiVersions = true;
//     x.AssumeDefaultVersionWhenUnspecified = true;
//     }
// ); //

builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => 
{
    x.SwaggerDoc("v1",
    new OpenApiInfo {
        Title = "RESTAPi for OngLives",
                        Version = "v1",
                        Description = "API RESTful developed to a Non Governamental Organization called 'OngLives' ",

                        Contact = new OpenApiContact 
                        {
                            Name = "Gabriel Gomes",
                            Url = new Uri("https://github.com/gabrieldesantana/")
                        }});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
    options => options
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();