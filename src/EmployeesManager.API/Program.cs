using Serilog;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSerilog((_, loggerConfig) =>
{
    loggerConfig.WriteTo.Console();
    loggerConfig.ReadFrom.Configuration(builder.Configuration);
});

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.Run();