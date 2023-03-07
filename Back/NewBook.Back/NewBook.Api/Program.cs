using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NewBook.Api.Model;
using NewBook.Application.Application;
using NewBook.Application.Interface.Application;
using NewBook.Data.Context;
using NewBook.Data.Repositories;
using NewBook.Domain.Entities;
using NewBook.Domain.Interfaces.Repositories;
using NewBook.Domain.Interfaces.Services;
using NewBook.Domain.Services;
using SimpleInjector;
using SimpleInjector.Lifestyles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

MapperConfiguration configurationMapper;

builder.Services.AddControllers();

builder.Services.AddAuthentication()
    .AddJwtBearer("Firebase", options =>
    {
        options.Authority = "https://securetoken.google.com/autenticacaonewbook";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "autenticacaonewbook",
            ValidateAudience = true,
            ValidAudience = "autenticacaonewbook",
            ValidateLifetime = true
        };
    })
    .AddJwtBearer("Custom", options =>
    {
        // Configuration for your custom
        // JWT tokens here
    });

builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .AddAuthenticationSchemes("Firebase", "Custom")
        .Build();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfiguration configuration = builder.Configuration;

Container container = new Container();
container.Options.DefaultLifestyle = Lifestyle.Scoped;
container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

builder.Services.AddMvc();
builder.Services.AddHealthChecks();

DependencyInjection();

builder.Services.AddDbContext<ContextDb>();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app cors
app.UseCors("corsapp");
app.UseHttpsRedirection();
//app.UseCors(prodCorsPolicy);

configurarMapper();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ContextDb>();
    context.Database.Migrate();
}

app.Run();

void configurarMapper()
{
    configurationMapper = new MapperConfiguration(mapper =>
    {
        mapper.CreateMap<EntityBase, EntityBaseModel>();
        mapper.CreateMap<Livro, LivroModel>();
    });
}

void DependencyInjection()
{
    builder.Services.AddScoped(typeof(IApplicationBase<>), typeof(ApplicationBase<>));
    builder.Services.AddScoped<ILivroApplication, LivroApplication>();
    builder.Services.AddScoped<IUsuarioApplication, UsuarioApplication>();


    builder.Services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
    builder.Services.AddScoped<ILivroService, LivroService>();
    builder.Services.AddScoped<IUsuarioService, UsuarioService>();

    builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
    builder.Services.AddScoped<ILivroRepository, LivroRepository>();
    builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
}