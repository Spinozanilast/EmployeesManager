namespace Employees.Domain.Entities;

public class Employee
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string MiddleName { get; private set; }
    public string FullName => $"{LastName} {FirstName} {MiddleName}".Trim();
    
    // This property holds the search vector for full-text search
    public string SearchName { get; set; }

    private readonly List<EmployeeRole> _roles = new();
    public IReadOnlyCollection<EmployeeRole> Roles => _roles.AsReadOnly();

    // Для EF Core
    private Employee()
    {
    }

    public Employee(string firstName, string lastName, string middleName = "")
    {
        Id = Guid.NewGuid();
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        MiddleName = middleName ?? string.Empty;
    }

    public void Update(string firstName, string lastName, string middleName = "")
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        MiddleName = middleName ?? string.Empty;
    }

    public void AddRole(Guid roleId)
    {
        if (!_roles.Exists(r => r.RoleId == roleId))
        {
            _roles.Add(new EmployeeRole(Id, roleId));
        }
    }

    public void RemoveRole(Guid roleId)
    {
        var role = _roles.Find(r => r.RoleId == roleId);
        if (role != null)
        {
            _roles.Remove(role);
        }
    }

    public void ClearRoles()
    {
        _roles.Clear();
    }
}