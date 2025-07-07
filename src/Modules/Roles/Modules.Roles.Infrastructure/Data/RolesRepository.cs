using Microsoft.EntityFrameworkCore;
using Roles.Domain.Entities;
using Roles.Domain.Repositories;

namespace Roles.Infrastructure.Data;

internal class RolesRepository : IRolesRepository
{
    private readonly RolesDbContext _dbContext;

    public RolesRepository(RolesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Role>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Roles
            .AsNoTracking()
            .Include(x => x.Permissions)
            .ToListAsync(cancellationToken);
    }

    public async Task<Role?> GetByIdTrackedAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Roles
            .AsNoTracking()
            .Include(x => x.Permissions)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public async Task<Role?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Roles
            .Include(x => x.Permissions)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public async Task AddAsync(Role role, CancellationToken cancellationToken = default)
    {
        await _dbContext.Roles.AddAsync(role, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Role role, CancellationToken cancellationToken = default)
    {
        _dbContext.Roles
            .Update(role);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var affectedRows = await _dbContext.Roles
            .Where(r => r.Id == id)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);

        return affectedRows > 0;
    }
}