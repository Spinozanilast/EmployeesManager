using Permissions.Application.Models.Shared;
using Permissions.Application.Services;

namespace Employees.Application.Services;

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

    /// <inheritdoc/>
    public async Task<PermissionDto> GetPermissionByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _permissionService.GetPermissionByIdAsync(id, cancellationToken);
    }
}