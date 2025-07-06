using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Roles.Domain.Entities;
using Roles.Infrastructure.Data;

namespace Roles.Infrastructure.Configurations;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder
            .Property(e => e.Name).IsRequired().HasMaxLength(100);

        builder
            .Property(e => e.Description).IsRequired().HasMaxLength(300);
        
        builder.ToTable("roles", RolesDbContext.SchemaName);
    }
}