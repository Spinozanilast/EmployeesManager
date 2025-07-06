using Microsoft.EntityFrameworkCore;
using Permissions.Domain.Entities;
using Permissions.Domain.Repositories;

namespace Permissions.Infrastructure.Data;

internal class PermissionRepository : IPermissionsRepository
{
    private readonly PermissionsDbContext _dbContext;

    public PermissionRepository(PermissionsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Permission>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Permissions
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Permission>> GetByCategoryAsync(string category,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Permissions
            .AsNoTracking()
            .Where(p => p.Category == category)
            .ToListAsync(cancellationToken);
    }

    public async Task<Permission?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Permissions
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Permission>> SearchByNameAsync(string searchTerm,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Permissions
            .AsNoTracking()
            .Where(p => p.Name.Contains(searchTerm))
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Permission permission, CancellationToken cancellationToken = default)
    {
        await _dbContext.Permissions.AddAsync(permission, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Permission permission, CancellationToken cancellationToken = default)
    {
        await _dbContext.Permissions
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(p => p.Name, permission.Name)
                    .SetProperty(p => p.Category, permission.Category)
                    .SetProperty(p => p.Description, permission.Description), cancellationToken: cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var affectedRows = await _dbContext.Permissions
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync(cancellationToken);

        return affectedRows > 0;
    }
}