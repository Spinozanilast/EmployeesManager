using Permissions.Application.Models;
using Permissions.Application.Models.Shared;

namespace Permissions.Application.Services;

public interface IPermissionService
{
    Task<IEnumerable<PermissionDto>> GetAllPermissionsAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<PermissionDto>> GetPermissionsByCategoryAsync(string category,
        CancellationToken cancellationToken = default);

    Task<PermissionDto> GetPermissionByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<PermissionDto>> GetPermissionsByIdsAsync(IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<PermissionDto>> SearchPermissionsByNameAsync(string searchTerm,
        CancellationToken cancellationToken = default);

    Task<Guid> CreatePermissionAsync(CreatePermissionDto createPermissionDto,
        CancellationToken cancellationToken = default);

    Task UpdatePermissionAsync(Guid id, UpdatePermissionDto updatePermissionDto,
        CancellationToken cancellationToken = default);

    Task DeletePermissionAsync(Guid id, CancellationToken cancellationToken = default);
}