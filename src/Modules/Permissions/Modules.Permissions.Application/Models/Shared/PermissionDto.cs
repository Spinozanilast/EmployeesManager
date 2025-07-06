namespace Permissions.Application.Models.Shared;

public record PermissionDto(
    Guid Id,
    string Name,
    string Description,
    string Category
);