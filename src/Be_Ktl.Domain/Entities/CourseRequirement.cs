using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;

public class CourseRequirement : BaseEntity
{
    public Guid CourseId { get; private set; }

    public Course Course { get; private set; } = default!;

    public string Description { get; private set; } = default!;

    public int OrderIndex { get; private set; }

    public CourseRequirement() { }

}
