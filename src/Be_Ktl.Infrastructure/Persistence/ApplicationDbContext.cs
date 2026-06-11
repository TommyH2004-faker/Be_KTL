using Be_Ktl.Application.Interfaces;
using Be_Ktl.Domain.Common;
using Be_Ktl.Domain.Entities;
using Be_Ktl.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Be_Ktl.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
     private readonly IDomainEventDispatcher _dispatcher;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventDispatcher dispatcher) : base(options)
    {
        _dispatcher = dispatcher;
    }

    // Domain entities
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();

    public DbSet<Instructor> Instructors => Set<Instructor>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Chapter> Chapters => Set<Chapter>();
    public DbSet<Lesson> Lessons => Set<Lesson>();
    public DbSet<Video> Videos => Set<Video>();
    public DbSet<LessonResource> LessonResources => Set<LessonResource>();
    public DbSet<CourseObjective> CourseObjectives => Set<CourseObjective>();
    public DbSet<CourseRequirement> CourseRequirements => Set<CourseRequirement>();

    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartItem> CartItems => Set<CartItem>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Coupon> Coupons => Set<Coupon>();

    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Certificate> Certificates => Set<Certificate>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<LessonProgress> LessonProgresses => Set<LessonProgress>();
    public DbSet<Livestream> Livestreams => Set<Livestream>();
    public DbSet<UserSession> UserSessions => Set<UserSession>();
    public DbSet<Wishlist> Wishlists => Set<Wishlist>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
      public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        var entities = ChangeTracker
            .Entries<BaseEntity>()
            .Where(x => x.Entity.DomainEvents.Any())
            .Select(x => x.Entity)
            .ToList();

        var result =
            await base.SaveChangesAsync(cancellationToken);

        var domainEvents = entities
            .SelectMany(x => x.DomainEvents)
            .ToList();

        entities.ForEach(x => x.ClearDomainEvents());

        await _dispatcher.DispatchAsync(
            domainEvents,
            cancellationToken);

        return result;
    }
}
