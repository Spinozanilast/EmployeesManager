using Employees.Application.Models;
using Permissions.Application.Models.Shared;
using Roles.Application.Models.Shared;

namespace Employees.Application.Services;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync(CancellationToken cancellationToken = default);
    Task<EmployeeDto> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<EmployeeDto>> SearchEmployeesByNameAsync(string searchTerm,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<EmployeeDto>>
        GetEmployeesByRoleIdAsync(Guid roleId, CancellationToken cancellationToken = default);

    Task<Guid> CreateEmployeeAsync(CreateEmployeeDto dto, CancellationToken cancellationToken = default);

    Task UpdateEmployeeAsync(Guid id, UpdateEmployeeDto dto,
        CancellationToken cancellationToken = default);

    Task DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken = default);

    Task AssignRolesToEmployeeAsync(Guid employeeId, IEnumerable<Guid> roleIds,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<RoleDto>> GetEmployeeRolesAsync(Guid employeeId, CancellationToken cancellationToken = default);

    Task<IEnumerable<PermissionDto>> GetEmployeePermissionsAsync(Guid employeeId,
        CancellationToken cancellationToken = default);
}