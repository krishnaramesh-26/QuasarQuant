using QuasarQuant.Application.Signals;
using QuasarQuant.Repository.Signals;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();  
builder.Services.AddScoped<ISignalService, SignalService>();
builder.Services.AddScoped<ISignalRepository, SignalRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>  
    options
    .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    .UseSnakeCaseNamingConvention()
    );
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
