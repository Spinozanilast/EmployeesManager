using Employees.Application.Models;
using Employees.Domain.Entities;
using Roles.Application.Models.Shared;

namespace Employees.Application.Extensions;

public static class EmployeesMapping
{
    public static EmployeeDto ToDto(this Employee employee) =>
        new EmployeeDto(
            employee.Id,
            employee.FirstName,
            employee.LastName,
            employee.MiddleName,
            employee.FullName,
            new List<RoleDto>());

    public static EmployeeDto MapToDto(Employee employee) =>
        employee.ToDto();
}