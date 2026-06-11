using Be_Ktl.Domain.Common;
using Be_Ktl.Domain.Enums;

namespace Be_Ktl.Domain.Entities;

public class Enrollment : BaseEntity
{
    public Guid StudentId { get; private set; }

    public User Student { get; private set; } = default!;

    public Guid CourseId { get; private set; }

    public Course Course { get; private set; } = default!;

    public decimal CompletionPercentage { get; private set; }

    public EnrollmentStatus Status { get; private set; }

    public DateTime EnrolledAt { get; private set; }

    public DateTime? CompletedAt { get; private set; }

    public Enrollment() { }

    
}