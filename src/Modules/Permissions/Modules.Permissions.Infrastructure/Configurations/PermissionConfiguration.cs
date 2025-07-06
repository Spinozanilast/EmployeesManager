using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Permissions.Domain.Entities;
using Permissions.Infrastructure.Data;

namespace Permissions.Infrastructure.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder
            .Property(p => p.Name).HasMaxLength(100);

        builder
            .Property(p => p.Description).HasMaxLength(300);

        builder
            .Property(p => p.Category).HasMaxLength(100);
        
        builder.ToTable("permissions", PermissionsDbContext.SchemaName);
    }
}