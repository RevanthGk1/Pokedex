using System.Reflection;
using Microsoft.OpenApi.Models;
using Pokedex.Cache;
using Pokedex.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMemoryCache();

builder.Services.AddSingleton(typeof(StandardCacheManager));

builder.Services.AddSingleton(typeof(TranslatedCacheManager));

builder.Services.AddSingleton(typeof(StandardPokemonService));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pokedex Api", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


builder.Services.AddScoped<Pokedex.Filters.ValidationFilter>();

builder.Services.AddScoped<Pokedex.Filters.CustomExceptionFilter>();

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
