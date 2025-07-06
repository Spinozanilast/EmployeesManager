using Microsoft.Extensions.DependencyInjection;
using Roles.Domain.Repositories;
using RolesInfrastructure.Data;

namespace RolesInfrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddRolesModule(this IServiceCollection services)
    {
        services.AddScoped<IRolesRepository, RolesRepository>();

        return services;
    }
}