using Permissions.Application.Models.Shared;

namespace Roles.Application.Models.Shared;

public class RoleDto(
    Guid Id,
    string Name,
    string Description,
    IEnumerable<PermissionDto> Permissions
)
{
    public Guid Id { get; init; } = Id;
    public string Name { get; init; } = Name;
    public string Description { get; init; } = Description;
    public IEnumerable<PermissionDto> Permissions { get; internal set; } = Permissions;
}