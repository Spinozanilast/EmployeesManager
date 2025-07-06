namespace Employees.Application.Models;

public record UpdateEmployeeDto(
    string FirstName,
    string LastName,
    string MiddleName
);