namespace Permissions.Application.Models;

public record UpdatePermissionDto(
    string Name,
    string Description,
    string Category
);