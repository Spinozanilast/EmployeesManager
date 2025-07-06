namespace Permissions.Application.Models;

public record CreatePermissionDto(
    string Name,
    string Description,
    string Category
);