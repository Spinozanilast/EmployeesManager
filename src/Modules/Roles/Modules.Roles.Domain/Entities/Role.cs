namespace Roles.Domain.Entities;

public class Role
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    private readonly List<RolePermission> _permissions = new();
    public IReadOnlyCollection<RolePermission> Permissions => _permissions.AsReadOnly();
    public IEnumerable<RolePermission> GetPermissions() => _permissions.AsEnumerable();

    private Role()
    {
    }

    public Role(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }

    public void Update(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void AddPermission(Guid permissionId)
    {
        if (!_permissions.Exists(p => p.PermissionId == permissionId))
        {
            _permissions.Add(new RolePermission(Id, permissionId));
        }
    }

    public void RemovePermission(Guid permissionId)
    {
        var permission = _permissions.Find(p => p.PermissionId == permissionId);
        if (permission != null)
        {
            _permissions.Remove(permission);
        }
    }

    public void ClearPermissions()
    {
        _permissions.Clear();
    }
}