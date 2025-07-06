using EmployeesManager.Infrastructure.Shared.Extensions;
using Microsoft.AspNetCore.Builder;
using Permissions.Infrastructure.Data;

namespace Permissions.Infrastructure.Extensions;

public static class Migrator
{
    public static async Task MigratePermissionsDbContext(this WebApplication app)
    {
        await app.ApplyMigrations<PermissionsDbContext>();
    }
}