using Employees.Infrastructure.Data;
using EmployeesManager.Infrastructure.Shared.Extensions;
using Microsoft.AspNetCore.Builder;

namespace Employees.Infrastructure.Extensions;

public static class Migrator
{
    public static async Task MigrateEmployeesDbContext(this WebApplication app)
    {
        await app.ApplyMigrations<EmployeesDbContext>();
    }
}