using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeesManager.Infrastructure.Shared.Extensions;

public static class DbContextsInjector
{
    public static IServiceCollection AddPostgreDbContext<TDbContext>(
        this IServiceCollection services,
        IConfiguration configuration,
        Action<DbContextOptionsBuilder>? configureOptions = null,
        bool usePooling = true,
        int poolSize = 128,
        string connectionName = "PostgresConnection") where TDbContext : DbContext
    {
        var connectionString = configuration.GetConnectionString(connectionName);

        ArgumentException.ThrowIfNullOrEmpty(connectionString);

        if (usePooling)
        {
            services.AddDbContextPool<TDbContext>(options =>
            {
                configureOptions?.Invoke(options);
                ApplyDefaultPostgreConfiguration(options, connectionString);
            }, poolSize);
        }
        else
        {
            services.AddDbContext<TDbContext>(options =>
            {
                configureOptions?.Invoke(options);
                ApplyDefaultPostgreConfiguration(options, connectionString);
            });
        }

        return services;
    }

    private static void ApplyDefaultPostgreConfiguration(
        DbContextOptionsBuilder options,
        string connectionString)
    {
        options
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention()
            .ConfigureWarnings(warnings => { warnings.Ignore(RelationalEventId.PendingModelChangesWarning); });
    }
}