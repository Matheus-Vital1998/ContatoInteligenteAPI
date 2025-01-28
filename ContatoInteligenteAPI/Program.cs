using ContatoInteligenteAPI.Repositorys.Interface;
using ContatoInteligenteAPI.Repositorys;
using ContatoInteligenteAPI.Services.Interfaces;
using ContatoInteligenteAPI.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "GitHub API - Blip Challenge",
        Description = "API intermediária para acessar a API pública do GitHub, criada como parte do desafio técnico. Esta API fornece informações sobre os repositórios da organização Takenet, incluindo avatar e detalhes específicos.",
        Contact = new OpenApiContact
        {
            Name = "Matheus Vital dos Santos de Oliveira",
            Email = "mat_vital@yahoo.com.br",
            Url = new Uri("https://github.com/Matheus-Vital1998?tab=repositories")
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });
});


// Adiciona serviços
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IGitHubRepository, GitHubRepository>();
builder.Services.AddScoped<IGitHubRepository, GitHubRepository>();
builder.Services.AddScoped<IGitHubService, GitHubService>();

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
