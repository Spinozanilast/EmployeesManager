using EmployeesManager.Infrastructure.Shared.Extensions;
using Microsoft.AspNetCore.Builder;
using Roles.Infrastructure.Data;

namespace Roles.Infrastructure.Extensions;

public static class Migrator
{
    public static async Task<WebApplication> MigrateRolesDbContext(this WebApplication app)
    {
        await app.ApplyMigrations<RolesDbContext>();

        return app;
    }
}