using Permissions.Application.Models.Shared;
using Permissions.Domain.Entities;

namespace Permissions.Application.Extensions;

public static class PermissionsMapping
{
    public static PermissionDto ToDto(this Permission permission) =>
        new PermissionDto(
            permission.Id,
            permission.Name,
            permission.Description,
            permission.Category
        );

    public static PermissionDto MapToDto(Permission permission) =>
        permission.ToDto();
}