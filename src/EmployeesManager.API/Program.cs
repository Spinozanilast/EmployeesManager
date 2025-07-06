using Employees.Infrastructure.Extensions;
using Permissions.Infrastructure.Extensions;
using Roles.Infrastructure.Extensions;
using Serilog;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSerilog((_, loggerConfig) =>
{
    loggerConfig.WriteTo.Console();
    loggerConfig.ReadFrom.Configuration(builder.Configuration);
});

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()));

var configuration = builder.Configuration;
builder.Services
    .AddEmployeesModule(configuration)
    .AddRolesModule(configuration)
    .AddPermissionsModule(configuration);

var app = builder.Build();

app
    .MapEmployeesModuleEndpoints()
    .MapRolesModuleEndpoints()
    .MapPermissionsModuleEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(opt =>
    {
        opt.Title = "Employees API";
        opt.Theme = ScalarTheme.Mars;
        opt.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
    });

    await app.MigrateEmployeesDbContext().ConfigureAwait(false);
    await app.MigrateRolesDbContext().ConfigureAwait(false);
    await app.MigratePermissionsDbContext().ConfigureAwait(false);
}

// For dev purposes only
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.Run();