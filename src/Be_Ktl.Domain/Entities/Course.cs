using Be_Ktl.Domain.Common;
using Be_Ktl.Domain.Enums;

namespace Be_Ktl.Domain.Entities;

public class Course : BaseEntity
{
    public string Title { get; private set; } = default!;

    public string Slug { get; private set; } = default!;

    public string ShortDescription { get; private set; } = default!;

    public string Description { get; private set; } = default!;

    public string? ThumbnailUrl { get; private set; }

    public CourseLevel Level { get; private set; }

    public CourseStatus Status { get; private set; }

    public decimal OriginalPrice { get; private set; }

    public decimal? DiscountPrice { get; private set; }

    public Guid CategoryId { get; private set; }

    public Category Category { get; private set; } = default!;

    public Guid InstructorId { get; private set; }

    public Instructor Instructor { get; private set; } = default!;

    public ICollection<Chapter> Chapters { get; } = new List<Chapter>();

    public ICollection<CourseObjective> Objectives { get; } = new List<CourseObjective>();

    public ICollection<CourseRequirement> Requirements { get; } = new List<CourseRequirement>();

    public ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();

    public ICollection<Review> Reviews { get; } = new List<Review>();

    public ICollection<Wishlist> Wishlists { get; } = new List<Wishlist>();

    public Course() { }

}
