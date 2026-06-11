using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;

public class Wishlist : BaseEntity
{
    public Guid StudentId { get; private set; }

    public User Student { get; private set; } = default!;

    public Guid CourseId { get; private set; }

    public Course Course { get; private set; } = default!;

    public DateTime AddedAt { get; private set; }

    public Wishlist() { }

    public Wishlist(Guid studentId, User student, Guid courseId, Course course)
    {
        StudentId = studentId;
        Student = student;
        CourseId = courseId;
        Course = course;
        AddedAt = DateTime.UtcNow;
    }
}