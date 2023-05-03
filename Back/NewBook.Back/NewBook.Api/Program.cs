using AutoMapper;
using IA.Api.Service;
using IA.Api.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NewBook.Api.Authenticate;
using NewBook.Api.Authenticate.Interface;
using NewBook.Api.Filters;
using NewBook.Api.Model;
using NewBook.Application.Application;
using NewBook.Application.Interface.Application;
using NewBook.CrossCutting;
using NewBook.Data.Context;
using NewBook.Data.Repositories;
using NewBook.Domain.Entities;
using NewBook.Domain.Interfaces.Repositories;
using NewBook.Domain.Interfaces.Services;
using NewBook.Domain.Services;
using Newtonsoft.Json.Serialization;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

MapperConfiguration configurationMapper;

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilter>(1);
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    options.SerializerSettings.ContractResolver = new DefaultContractResolver
    {
        NamingStrategy = new CamelCaseNamingStrategy()
    };
});

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

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

var mappingConfig = configurarMapper();

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<AuthenticateValidator>();

builder.Services.AddScoped<ServicesGeral>();

var key = Encoding.ASCII.GetBytes(configuration.GetSection("KeyApiAuth").Value);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

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

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ContextDb>();
    context.Database.Migrate();
}

app.Run();

MapperConfiguration configurarMapper()
{
    configurationMapper = new MapperConfiguration(mapper =>
    {
        mapper.CreateMap<EntityBase, EntityBaseModel>();
        mapper.CreateMap<Livro, LivroModel>();
        mapper.CreateMap<Usuario, UsuarioModel>();

        mapper.CreateMap<EntityBaseModel, EntityBase>();
        mapper.CreateMap<LivroModel, Livro>();
        mapper.CreateMap<UsuarioModel, Usuario>();
    });

    return configurationMapper;
}

void DependencyInjection()
{
    builder.Services.AddScoped(typeof(IApplicationBase<>), typeof(ApplicationBase<>));
    builder.Services.AddScoped<ILivroApplication, LivroApplication>();
    builder.Services.AddScoped<IUsuarioApplication, UsuarioApplication>();
    builder.Services.AddScoped<IInformacoesPessoaisApplication, InformacoesPessoaisApplication>();
    builder.Services.AddScoped<IInformacoesAdicionaisApplication, InformacoesAdicionaisApplication>();
    builder.Services.AddScoped<IEnderecoApplication, EnderecoApplication>();



    builder.Services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
    builder.Services.AddScoped<ILivroService, LivroService>();
    builder.Services.AddScoped<IUsuarioService, UsuarioService>();
    builder.Services.AddScoped<IInformacoesPessoaisService, InformacoesPessoaisService>();
    builder.Services.AddScoped<IInformacoesAdicionaisService, InformacoesAdicionaisService>();
    builder.Services.AddScoped<IEnderecoService, EnderecoService>();

    builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
    builder.Services.AddScoped<ILivroRepository, LivroRepository>();
    builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    builder.Services.AddScoped<IInformacoesPessoaisRepository, InformacoesPessoaisRepository>();
    builder.Services.AddScoped<IInformacoesAdicionaisRepository, InformacoesAdicionaisRepository>();
    builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();

    builder.Services.AddScoped<IIAService, IAService>();

    builder.Services.AddScoped<IAuthenticateValidator, AuthenticateValidator>();
}