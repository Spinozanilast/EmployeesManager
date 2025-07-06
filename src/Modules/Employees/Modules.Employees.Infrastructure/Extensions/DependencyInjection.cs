using Employees.Application;
using Employees.Application.Services;
using Employees.Domain.Repositories;
using Employees.Infrastructure.Data;
using EmployeesManager.Infrastructure.Shared.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Employees.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddEmployeesModule(this IServiceCollection services, IConfiguration config)
    {
        // Repos
        services.AddScoped<IEmployeesRepository, EmployeesRepository>();

        // Services
        services.AddScoped<IEmployeeService, EmployeeService>();

        // Adapters
        services
            .AddScoped<IPermissionAdapterService, PermissionAdapterService>()
            .AddScoped<IRoleAdapterService, RoleAdapterService>();

        // Contexts
        services.AddPostgreDbContext<EmployeesDbContext>(config);

        return services;
    }

    public static WebApplication MapEmployeesModuleEndpoints(this WebApplication app)
    {
        app.MapEmployeesEndpoints();
        return app;
    }
}