namespace Roles.Application.Models;

public record CreateRoleDto(
    string Name,
    string Description,
    IEnumerable<Guid> PermissionIds
);