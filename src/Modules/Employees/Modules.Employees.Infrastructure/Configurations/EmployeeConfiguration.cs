using Employees.Domain.Entities;
using Employees.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employees.Infrastructure.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    private const int NamePartMaxLength = 100;

    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(p => p.SearchName)
            .HasComputedColumnSql("\"first_name\" || ' ' || \"middle_name\" || ' ' || \"last_name\"", stored: true);

        // Create trigram index
        builder.HasIndex(p => p.SearchName)
            .HasMethod("GIN")
            .HasOperators("gin_trgm_ops");

        builder
            .Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(NamePartMaxLength);

        builder
            .Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(NamePartMaxLength);

        builder
            .Property(e => e.MiddleName)
            .HasMaxLength(NamePartMaxLength);
        
        builder.ToTable("employees", EmployeesDbContext.SchemaName);
    }
}