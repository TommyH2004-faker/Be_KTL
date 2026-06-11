using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;

public class Role : BaseEntity
{
    public string Name { get; private set; } = default!;

    public string? Description { get; private set; }

    public ICollection<UserRole> UserRoles { get; } = new List<UserRole>();

    public ICollection<RolePermission> RolePermissions { get; } = new List<RolePermission>();

    public Role() { }


   
}
