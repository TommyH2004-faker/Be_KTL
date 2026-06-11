using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;

public class UserRole : BaseEntity
{
    public Guid UserId { get; private set; }

    public User User { get; private set; } = default!;

    public Guid RoleId { get; private set; }

    public Role Role { get; private set; } = default!;

    public UserRole() { }

    public UserRole(Guid userId, User user, Guid roleId, Role role)
    {
        UserId = userId;
        User = user;
        RoleId = roleId;
        Role = role;
    }
}