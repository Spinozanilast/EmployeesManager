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
        
        builder.HasData(GenerateSeedPermissions());
    }

    private static IReadOnlyCollection<Permission> GenerateSeedPermissions()
    {
        var permissions = new List<Permission>();
        var categories = new[]
        {
            "UserManagement", "RoleManagement", "DataAccess",
            "Reporting", "SystemConfig", "Workflow", "API",
            "Integration", "Security", "Audit"
        };

        var operations = new[]
        {
            "View", "Create", "Edit", "Delete", "Approve",
            "Reject", "Export", "Import", "Archive", "Restore",
            "Lock", "Unlock", "Grant", "Revoke", "Execute",
            "Schedule", "Monitor", "Configure", "Bypass", "Delegate"
        };

        var rnd = new Random();
        var permissionCount = 0;

        foreach (var category in categories)
        {
            foreach (var operation in operations)
            {
                var name = $"{category}.{operation}";
                var description = GetDescription(category, operation, rnd);

                permissions.Add(new Permission(
                    name: name,
                    description: description,
                    category: category)
                );
            }
        }

        return permissions;
    }

    private static string GetDescription(string category, string operation, Random rnd)
    {
        var descriptors = new[]
        {
            "Global access to",
            "Limited scope for",
            "Administrative control over",
            "Temporary permission to",
            "Audit capability for",
            "Emergency access to",
            "Delegated authority for",
            "Approval workflow covering",
            "Compliance-related access to",
            "Security-restricted"
        };

        var targets = new[]
        {
            "system resources",
            "sensitive data",
            "configuration settings",
            "user profiles",
            "audit logs",
            "reporting modules",
            "API endpoints",
            "integration pipelines",
            "security policies",
            "workflow definitions"
        };

        return
            $"{descriptors[rnd.Next(descriptors.Length)]} {operation} operations on {category} {targets[rnd.Next(targets.Length)]}";
    }
}