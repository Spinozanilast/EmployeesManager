using Permissions.Application.Models.Shared;
using Roles.Application.Models.Shared;
using Roles.Domain.Entities;

namespace Roles.Application.Extensions;

internal static class RolesMapping
{
    public static RoleDto ToDto(this Role role) =>
        new RoleDto(
            role.Id,
            role.Name,
            role.Description,
            Permissions: new List<PermissionDto>()
        );
}