using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;

public class Lesson : BaseEntity
{
    public Guid ChapterId { get; private set; }

    public Chapter Chapter { get; private set; } = default!;

    public string Title { get; private set; } = default!;

    public string? Content { get; private set; }

    public bool IsPreview { get; private set; }

    public int OrderIndex { get; private set; }

    public Video? Video { get; private set; }

    public ICollection<LessonResource> Resources { get; } = new List<LessonResource>();

    public ICollection<LessonProgress> Progresses { get; } = new List<LessonProgress>();

    public Lesson() { }

    
}
