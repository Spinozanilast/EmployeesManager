namespace Employees.Application.Models;

public record CreateEmployeeDto(
    string FirstName,
    string LastName,
    string MiddleName,
    IEnumerable<Guid> RoleIds
);