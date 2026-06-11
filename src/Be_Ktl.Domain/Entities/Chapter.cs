using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;

public class Chapter : BaseEntity
{
    public Guid CourseId { get; private set; }

    public Course Course { get; private set; } = default!;

    public string Title { get; private set; } = default!;

    public string? Description { get; private set; }

    public int OrderIndex { get; private set; }

    public ICollection<Lesson> Lessons { get; } = new List<Lesson>();

    public Chapter() { }

  
}
