using Events_PLUS.Context;
using Events_PLUS.Repositories;
using Microsoft.EntityFrameworkCore;
using Events_PLUS.Domains;
using Events_PLUS.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configura��o de servi�os
builder.Services // Acessa a cole��o de servi�os da aplica��o (Dependency Injection)
    .AddControllers() // Adiciona suporte a controladores na API (MVC ou Web API)
    .AddJsonOptions(options => // Configura as op��es do serializador JSON padr�o (System.Text.Json)
    {
        // Configura��o para ignorar propriedades nulas ao serializar objetos em JSON
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;

        // Configura��o para evitar refer�ncia circular ao serializar objetos que possuem relacionamentos recursivos
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<Events_PLUS_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inje��o de depend�ncia dos reposit�rios
builder.Services.AddScoped<ITiposEventosRepository, TipoEventoRepository>();
builder.Services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();


//Adiciona o servi�o de Controllers
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();