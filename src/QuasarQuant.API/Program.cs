using QuasarQuant.Application.Signals;
using QuasarQuant.Repository.Signals;
using Scalar.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();  
builder.Services.AddScoped<ISignalService, SignalService>();
builder.Services.AddSingleton<ISignalRepository, InMemorySignalRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
