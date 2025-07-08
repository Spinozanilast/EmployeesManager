using Employees.Domain.Entities;
using Employees.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Employees.Infrastructure.Data;

internal class EmployeesRepository : IEmployeesRepository
{
    private readonly EmployeesDbContext _dbContext;

    public EmployeesRepository(EmployeesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Employees
            .AsNoTracking()
            .Include(e => e.Roles)
            .ToListAsync(cancellationToken);
    }

    public async Task<Employee?> GetByIdTrackedAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Employees
            .AsNoTracking()
            .Include(e => e.Roles)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Employees
            .Include(e => e.Roles)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Employee>> SearchByNameAsync(string searchTerm,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Employees
            .AsNoTracking()
            .Where(p => EF.Functions.TrigramsAreSimilar(p.SearchName, searchTerm))
            .OrderBy(p => EF.Functions.TrigramsSimilarityDistance(p.SearchName, searchTerm))
            .Take(30)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Employee>> GetByRoleIdAsync(Guid roleId,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Employees
            .AsNoTracking()
            .Include(e => e.Roles)
            .Where(e => e.Roles.Any(r => r.RoleId == roleId))
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        await _dbContext.Employees.AddAsync(employee, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        _dbContext.Employees.Update(employee);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var affectedRows = await _dbContext.Employees
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync(cancellationToken);

        return affectedRows > 0;
    }
}