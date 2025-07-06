using EmployeesManager.Infrastructure.Shared.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Permissions.Application;
using Permissions.Application.Services;
using Permissions.Domain.Repositories;
using Permissions.Infrastructure.Data;

namespace Permissions.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPermissionsModule(this IServiceCollection services, IConfiguration config)
    {
        // Repos
        services.AddScoped<IPermissionsRepository, PermissionsRepository>();

        // Services
        services.AddScoped<IPermissionService, PermissionService>();

        // Contexts
        services.AddPostgreDbContext<PermissionsDbContext>(config);

        return services;
    }

    public static WebApplication MapPermissionsModuleEndpoints(this WebApplication app)
    {
        app.MapPermissionsEndpoints();
        return app;
    }
}