namespace Employees.Domain.Entities;

public class EmployeeRole
{
    public Guid EmployeeId { get; private set; }
    public Guid RoleId { get; private set; }

    public Employee Employee { get; private set; }

    private EmployeeRole()
    {
    }

    public EmployeeRole(Guid employeeId, Guid roleId)
    {
        EmployeeId = employeeId;
        RoleId = roleId;
    }
}