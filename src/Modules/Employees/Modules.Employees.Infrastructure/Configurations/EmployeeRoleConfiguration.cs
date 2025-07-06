using Employees.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employees.Infrastructure.Configurations;

public class EmployeeRoleConfiguration : IEntityTypeConfiguration<EmployeeRole>
{
    public void Configure(EntityTypeBuilder<EmployeeRole> builder)
    {
        builder
            .HasKey(er => new { er.EmployeeId, er.RoleId });

        builder
            .HasOne(er => er.Employee)
            .WithMany(e => e.Roles)
            .HasForeignKey(er => er.EmployeeId);
    }
}