using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;

public class RolePermission : BaseEntity
{
    public Guid RoleId { get; private set; }

    public Role Role { get; private set; } = default!;

    public Guid PermissionId { get; private set; }

    public Permission Permission { get; private set; } = default!;

    public RolePermission() { }

    public RolePermission(Guid roleId, Role role, Guid permissionId, Permission permission)
    {
        RoleId = roleId;
        Role = role;
        PermissionId = permissionId;
        Permission = permission;
    }
}