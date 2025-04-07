using Movie.API.Repositories;
using Movie.API.Services;
using Shared.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddScoped<FilmeService>();

// Aqui você ainda precisa de uma implementação real:
builder.Services.AddScoped<IFilmeRepository, FilmeRepositoryEmMemoria>(); // Exemplo temporário

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();