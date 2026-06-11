using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;

public class Review : BaseEntity
{
    public Guid StudentId { get; private set; }

    public User Student { get; private set; } = default!;

    public Guid CourseId { get; private set; }

    public Course Course { get; private set; } = default!;

    public int Rating { get; private set; }

    public string Comment { get; private set; } = default!;

    public Review() { }

  
}