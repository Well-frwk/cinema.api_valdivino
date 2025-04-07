using Shared.Interfaces;
using Ticket.API.Repositories;
using Ticket.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<BilheteService>();
builder.Services.AddScoped<IBilheteRepository, BilheteRepositoryEmMemoria>();

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