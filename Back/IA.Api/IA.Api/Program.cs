using AutoMapper;
using SimpleInjector.Lifestyles;
using SimpleInjector;
using MediatR;
using IA.Domain.Interfaces.Services;
using IA.Domain.Services;
using IA.Domain.Interfaces.Repositories;
using IA.Data.Repositories;
using System.Reflection;
using IA.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using IA.Api.Models;
using IA.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

MapperConfiguration configurationMapper;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfiguration configuration = builder.Configuration;

var mappingConfig = configurarMapper();

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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

Container container = new Container();
container.Options.DefaultLifestyle = Lifestyle.Scoped;
container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

builder.Services.AddHealthChecks();

DependencyInjection();

builder.Services.AddDbContext<ContextDb>();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();


//app cors
app.UseCors("corsapp");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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
        mapper.CreateMap<InteligenciaArtificialModel, InteligenciaArtificial>();

        mapper.CreateMap<EntityBaseModel, EntityBase>();
        mapper.CreateMap<InteligenciaArtificial, InteligenciaArtificialModel>();
    });

    return configurationMapper;
}

void DependencyInjection()
{
    builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
    builder.Services.AddMediatR(typeof(IConfiguration).GetTypeInfo().Assembly);

    builder.Services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
    builder.Services.AddScoped<IInteligenciaArtificialService, InteligenciaArtificialService>();
    builder.Services.AddScoped<IMensagensService, MensagensService>();
    builder.Services.AddScoped<IChatIAService, ChatIAService>();
    builder.Services.AddScoped<IUsuarioService, UsuarioService>();

    builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
    builder.Services.AddScoped<IInteligenciaArtificialRepository, InteligenciaArtificialRepository>();
    builder.Services.AddScoped<IMensagensRepository, MensagensRepository>();
    builder.Services.AddScoped<IChatIARepository, ChatIARepository>();
    builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
}