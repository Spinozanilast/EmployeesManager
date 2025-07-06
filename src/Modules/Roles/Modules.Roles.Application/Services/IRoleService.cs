using Permissions.Application.Models.Shared;
using Roles.Application.Models;
using Roles.Application.Models.Shared;

namespace Roles.Application.Services;

public interface IRoleService
{
    Task<IEnumerable<RoleDto>> GetAllRolesAsync(CancellationToken cancellationToken = default);
    Task<RoleDto> GetRoleByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> CreateRoleAsync(CreateRoleDto createRoleDto, CancellationToken cancellationToken = default);
    Task UpdateRoleAsync(Guid id, UpdateRoleDto updateRoleDto, CancellationToken cancellationToken = default);
    Task DeleteRoleAsync(Guid id, CancellationToken cancellationToken = default);

    Task AssignPermissionsToRoleAsync(Guid roleId, IEnumerable<Guid> permissionIds,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<PermissionDto>> GetRolePermissionsAsync(Guid roleId,
        CancellationToken cancellationToken = default);
}