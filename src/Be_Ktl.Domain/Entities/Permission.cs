using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;

public class Permission : BaseEntity
{
    public string Name { get; private set; } = default!;

    public string Description { get; private set; } = default!;

    public string Code { get; private set; } = default!;

    public ICollection<RolePermission> RolePermissions { get; } = new List<RolePermission>();

    public Permission() { }


}
