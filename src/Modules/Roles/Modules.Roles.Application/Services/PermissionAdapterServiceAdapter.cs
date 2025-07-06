using Permissions.Application.Models.Shared;
using Permissions.Application.Services;

namespace Roles.Application.Services;

/// <summary>
/// Адаптер для сервиса прав доступа, который использует IPermissionService из модуля Permissions
/// </summary>
internal class PermissionAdapterServiceAdapter : IPermissionAdapterService
{
    private readonly IPermissionService _permissionService;

    public PermissionAdapterServiceAdapter(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    public async Task<PermissionDto> GetPermissionByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var permissionDto = await _permissionService.GetPermissionByIdAsync(id, cancellationToken);
        return permissionDto;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<PermissionDto>> GetPermissionsByIdsAsync(IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default)
    {
        var permissions = new List<PermissionDto>();

        foreach (var id in ids)
        {
            try
            {
                permissions.Add(await _permissionService.GetPermissionByIdAsync(id, cancellationToken));
            }
            catch (KeyNotFoundException)
            {
            }
        }

        return permissions;
    }
}