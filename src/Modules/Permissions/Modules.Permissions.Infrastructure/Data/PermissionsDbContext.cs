using Microsoft.EntityFrameworkCore;
using Permissions.Domain.Entities;
using Permissions.Infrastructure.Configurations;

namespace Permissions.Infrastructure.Data;

internal class PermissionsDbContext : DbContext
{
    public DbSet<Permission> Permissions { get; set; }

    public PermissionsDbContext(DbContextOptions<PermissionsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PermissionConfiguration());
    }
}