using Microsoft.EntityFrameworkCore;
using Roles.Domain.Entities;
using Roles.Infrastructure.Configurations;

namespace Roles.Infrastructure.Data;

internal class RolesDbContext : DbContext
{
    public const string SchemaName = "roles";

    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }

    public RolesDbContext(DbContextOptions<RolesDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(SchemaName);
        
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
    }
}