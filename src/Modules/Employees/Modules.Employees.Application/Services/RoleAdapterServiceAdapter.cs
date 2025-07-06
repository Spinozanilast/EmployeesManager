using Permissions.Application.Models.Shared;
using Roles.Application.Models.Shared;
using Roles.Application.Services;

namespace Employees.Application.Services;

/// <summary>
/// Адаптер для сервиса ролей, который использует IRoleService из модуля Roles
/// </summary>
internal class RoleAdapterServiceAdapter : IRoleAdapterService
{
    private readonly IRoleService _roleService;

    public RoleAdapterServiceAdapter(IRoleService roleService)
    {
        _roleService = roleService;
    }

    /// <inheritdoc/>
    public async Task<RoleDto> GetRoleByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _roleService.GetRoleByIdAsync(id, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<RoleDto>> GetRolesByIdsAsync(IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default)
    {
        var roles = new List<RoleDto>();

        foreach (var id in ids)
        {
            try
            {
                var roleDto = await _roleService.GetRoleByIdAsync(id, cancellationToken);
                if (roleDto is not null)
                {
                    roles.Add(roleDto);
                }
            }
            catch (KeyNotFoundException)
            {
            }
        }

        return roles;
    }
}