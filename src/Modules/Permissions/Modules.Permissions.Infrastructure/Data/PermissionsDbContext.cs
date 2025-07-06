using Microsoft.EntityFrameworkCore;
using Permissions.Domain.Entities;
using Permissions.Infrastructure.Configurations;

namespace Permissions.Infrastructure.Data;

internal class PermissionsDbContext : DbContext
{
    public const string SchemaName = "permissions";

    public DbSet<Permission> Permissions { get; set; }

    public PermissionsDbContext(DbContextOptions<PermissionsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(SchemaName);

        modelBuilder.ApplyConfiguration(new PermissionConfiguration());
    }
}