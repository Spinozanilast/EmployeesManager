using Permissions.Domain.Entities;

namespace Permissions.Domain.Repositories;

public interface IPermissionsRepository
{
    Task<IEnumerable<Permission>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Permission>> GetByCategoryAsync(string category, CancellationToken cancellationToken = default);
    Task<Permission?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Permission>> SearchByNameAsync(string searchTerm, CancellationToken cancellationToken = default);
    Task AddAsync(Permission permission, CancellationToken cancellationToken = default);
    Task UpdateAsync(Permission permission, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}