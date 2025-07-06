using Microsoft.EntityFrameworkCore;
using Roles.Domain.Entities;
using RolesInfrastructure.Configurations;

namespace RolesInfrastructure.Data;

internal class RolesDbContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }

    public RolesDbContext(DbContextOptions<RolesDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
    }
}