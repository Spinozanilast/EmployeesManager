using System.Text.Json.Serialization;

namespace Roles.Domain.Entities;

public class RolePermission
{
    public Guid RoleId { get; private set; }
    public Guid PermissionId { get; private set; }
        
    [JsonIgnore]
    public Role Role { get; private set; }
        
    private RolePermission() { }
        
    public RolePermission(Guid roleId, Guid permissionId)
    {
        RoleId = roleId;
        PermissionId = permissionId;
    }
}