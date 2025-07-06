using Roles.Application.Models.Shared;

namespace Employees.Application.Models;

public class EmployeeDto(
    Guid id,
    string firstName,
    string lastName,
    string middleName,
    string fullName,
    IEnumerable<RoleDto> roles
)
{
    public Guid Id { get; init; } = id;
    public string FirstName { get; init; } = firstName;
    public string LastName { get; init; } = lastName;
    public string MiddleName { get; init; } = middleName;
    public string FullName { get; init; } = fullName;
    public IEnumerable<RoleDto> Roles { get; internal set; } = roles;
}