using EmployeesManager.Infrastructure.Shared.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Roles.Application;
using Roles.Application.Services;
using Roles.Domain.Repositories;
using Roles.Infrastructure.Data;

namespace Roles.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddRolesModule(this IServiceCollection services, IConfiguration config)
    {
        // Repos
        services.AddScoped<IRolesRepository, RolesRepository>();

        // Services
        services.AddScoped<IRoleService, RoleService>();

        // Adapters
        services.AddScoped<IPermissionAdapterService, PermissionAdapterService>();

        // Contexts
        services.AddPostgreDbContext<RolesDbContext>(config);

        return services;
    }

    public static WebApplication MapRolesModuleEndpoints(this WebApplication app)
    {
        app.MapRolesEndpoints();
        return app;
    }
}