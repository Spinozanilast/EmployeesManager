using Employees.Application.Extensions;
using Employees.Application.Models;
using Employees.Domain.Entities;
using Employees.Domain.Repositories;
using Permissions.Application.Models.Shared;
using Roles.Application.Models.Shared;

namespace Employees.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeesRepository _employeeRepository;
    private readonly IRoleAdapterService _roleAdapterService;

    public EmployeeService(IEmployeesRepository employeeRepository, IRoleAdapterService roleAdapterService)
    {
        _employeeRepository = employeeRepository;
        _roleAdapterService = roleAdapterService;
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync(CancellationToken cancellationToken = default)
    {
        var employees = await _employeeRepository.GetAllAsync(cancellationToken);
        var result = new List<EmployeeDto>();

        foreach (var employee in employees)
        {
            var employeeDto = employee.ToDto();
            var roles = await GetEmployeeRolesAsync(employee.Id, cancellationToken);
            employeeDto.Roles = roles;
            result.Add(employeeDto);
        }

        return result;
    }

    public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var employee = await _employeeRepository.GetByIdTrackedAsync(id, cancellationToken);

        if (employee is null)
        {
            throw new KeyNotFoundException($"Сотрудник с идентификатором {id} не найден");
        }

        var employeeDto = employee.ToDto();
        var roles = await GetEmployeeRolesAsync(id, cancellationToken);
        employeeDto.Roles = roles;

        return employeeDto;
    }

    public async Task<IEnumerable<EmployeeDto>> SearchEmployeesByNameAsync(string searchTerm,
        CancellationToken cancellationToken = default)
    {
        var employees = await _employeeRepository.SearchByNameAsync(searchTerm, cancellationToken);
        var result = new List<EmployeeDto>();

        foreach (var employee in employees)
        {
            var employeeDto = employee.ToDto();
            var roles = await GetEmployeeRolesAsync(employee.Id, cancellationToken);
            employeeDto.Roles = roles;
            result.Add(employeeDto);
        }

        return result;
    }

    public async Task<IEnumerable<EmployeeDto>> GetEmployeesByRoleIdAsync(Guid roleId,
        CancellationToken cancellationToken = default)
    {
        var employees = await _employeeRepository.GetByRoleIdAsync(roleId, cancellationToken);
        var result = new List<EmployeeDto>();

        foreach (var employee in employees)
        {
            var employeeDto = employee.ToDto();
            var roles = await GetEmployeeRolesAsync(employee.Id, cancellationToken);
            employeeDto.Roles = roles;
            result.Add(employeeDto);
        }

        return result;
    }

    public async Task<Guid> CreateEmployeeAsync(CreateEmployeeDto dto,
        CancellationToken cancellationToken = default)
    {
        var employee = new Employee(
            dto.FirstName,
            dto.LastName,
            dto.MiddleName);

        if (dto.RoleIds is not null && dto.RoleIds.Any())
        {
            foreach (var roleId in dto.RoleIds)
            {
                employee.AddRole(roleId);
            }
        }

        await _employeeRepository.AddAsync(employee, cancellationToken);

        return employee.Id;
    }

    public async Task UpdateEmployeeAsync(Guid id, UpdateEmployeeDto dto,
        CancellationToken cancellationToken = default)
    {
        var employee = await _employeeRepository.GetByIdTrackedAsync(id, cancellationToken);
        if (employee is null)
        {
            throw new KeyNotFoundException($"Сотрудник с идентификатором {id} не найден");
        }

        employee.Update(
            dto.FirstName,
            dto.LastName,
            dto.MiddleName);

        await _employeeRepository.UpdateAsync(employee, cancellationToken);
    }

    public async Task DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var employee = await _employeeRepository.GetByIdTrackedAsync(id, cancellationToken);
        if (employee is null)
        {
            throw new KeyNotFoundException($"Сотрудник с идентификатором {id} не найден");
        }

        await _employeeRepository.DeleteAsync(id, cancellationToken);
    }

    public async Task AssignRolesToEmployeeAsync(Guid employeeId, IEnumerable<Guid> roleIds,
        CancellationToken cancellationToken = default)
    {
        var employee = await _employeeRepository.GetByIdAsync(employeeId, cancellationToken);
        if (employee is null)
        {
            throw new KeyNotFoundException($"Сотрудник с идентификатором {employeeId} не найден");
        }

        // Очищаем текущие роли и добавляем новые
        employee.ClearRoles();

        foreach (var roleId in roleIds)
        {
            employee.AddRole(roleId);
        }

        await _employeeRepository.UpdateAsync(employee, cancellationToken);
    }

    public async Task<IEnumerable<RoleDto>> GetEmployeeRolesAsync(Guid employeeId,
        CancellationToken cancellationToken = default)
    {
        var employee = await _employeeRepository.GetByIdTrackedAsync(employeeId, cancellationToken);
        if (employee is null)
        {
            throw new KeyNotFoundException($"Сотрудник с идентификатором {employeeId} не найден");
        }

        var roleIds = employee.Roles.Select(r => r.RoleId).ToList();
        var roles = new List<RoleDto>();

        foreach (var roleId in roleIds)
        {
            try
            {
                var role = await _roleAdapterService.GetRoleByIdAsync(roleId, cancellationToken);
                if (role is not null)
                {
                    roles.Add(role);
                }
            }
            catch (KeyNotFoundException)
            {
            }
        }

        return roles;
    }

    public async Task<IEnumerable<PermissionDto>> GetEmployeePermissionsAsync(Guid employeeId,
        CancellationToken cancellationToken = default)
    {
        var roles = await GetEmployeeRolesAsync(employeeId, cancellationToken);
        var permissions = new Dictionary<Guid, PermissionDto>();

        foreach (var role in roles)
        {
            foreach (var permission in role.Permissions)
            {
                permissions.TryAdd(permission.Id, permission);
            }
        }

        return permissions.Values;
    }
}