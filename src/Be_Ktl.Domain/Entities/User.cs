using Be_Ktl.Domain.Common;
using Be_Ktl.Domain.Events;

namespace Be_Ktl.Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; private set; } = default!;

    public string PasswordHash { get; private set; } = default!;

    public string FullName { get; private set; } = default!;

    public string? PhoneNumber { get; private set; }

    public string? AvatarUrl { get; private set; }

    public bool EmailConfirmed { get; private set; }

    public bool IsActive { get; private set; }

    public Guid? InstructorId { get; private set; }

    public Instructor? InstructorProfile { get; private set; }

    public ICollection<UserRole> UserRoles { get; } = new List<UserRole>();

    public ICollection<Enrollment> Enrollments { get; }
        = new List<Enrollment>();

    public ICollection<Review> Reviews { get; }
        = new List<Review>();

    public ICollection<Notification> Notifications { get; }
        = new List<Notification>();

    public ICollection<Cart> Carts { get; }
        = new List<Cart>();

    public ICollection<Order> Orders { get; }
        = new List<Order>();

    public ICollection<UserSession> Sessions { get; }
        = new List<UserSession>();

    public ICollection<Wishlist> Wishlists { get; }
        = new List<Wishlist>();

    public User() { }
    public static User Create(
        string email,
        string passwordHash)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            PasswordHash = passwordHash
        };

        user.AddDomainEvent(
            new UserRegisteredDomainEvent(
                user.Id,
                user.Email));

        return user;
    }
    
}