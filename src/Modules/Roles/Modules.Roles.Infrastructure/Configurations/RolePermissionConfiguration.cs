using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Roles.Domain.Entities;
using Roles.Infrastructure.Data;

namespace Roles.Infrastructure.Configurations;

internal class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder
            .HasKey(rp => new { rp.PermissionId, rp.RoleId });

        builder
            .HasOne(rp => rp.Role)
            .WithMany(r => r.Permissions)
            .HasForeignKey(rp => rp.RoleId);

        builder.ToTable("role_permissions", RolesDbContext.SchemaName);
    }
}