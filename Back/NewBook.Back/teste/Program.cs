using Microsoft.AspNetCore.Mvc;
using NewBook.Application.Application;
using NewBook.Application.Interface.Application;
using NewBook.Data.Repositories;
using NewBook.Domain.Entities;
using NewBook.Domain.Interfaces.Repositories;
using NewBook.Domain.Interfaces.Services;
using NewBook.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddScoped(typeof(IApplicationBase<>), typeof(ApplicationBase<>));
builder.Services.AddScoped<ILivroApplication, LivroApplication>();
builder.Services.AddScoped<IUsuarioApplication, UsuarioApplication>();
builder.Services.AddScoped<IAuthApplication, AuthApplication>();
builder.Services.AddScoped<IInformacoesPessoaisApplication, InformacoesPessoaisApplication>();


builder.Services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IInformacoesPessoaisService, InformacoesPessoaisService>();

builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IInformacoesPessoaisRepository, InformacoesPessoaisRepository>();

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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};


app.MapGet("/Usuarios", ([FromServicesAttribute] IUsuarioApplication UsuarioApplication) =>
{
    //var forecast = Enumerable.Range(1, 5).Select(index =>
    //    new WeatherForecast
    //    (
    //        DateTime.Now.AddDays(index),
    //        Random.Shared.Next(-20, 55),
    //        summaries[Random.Shared.Next(summaries.Length)]
    //    ))
    //    .ToArray();

    var teste = UsuarioApplication.GetAll();

    return teste;
})
.WithName("GetUsuarios");

app.Run();

class UsuarioApplicationsad 
{
    //private readonly IUsuarioApplication _aplication;

    //public UsuarioApplication(IUsuarioApplication aplication)
    //{
    //    _aplication = aplication;
    //}

    //public List<Usuario> GetAll()
    //{
    //    return _aplication.GetAll().ToList();
    //}
}

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}