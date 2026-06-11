using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;

public class LessonResource : BaseEntity
{
    public Guid LessonId { get; private set; }

    public Lesson Lesson { get; private set; } = default!;

    public string FileName { get; private set; } = default!;

    public string FileUrl { get; private set; } = default!;

    public string? FileType { get; private set; }

    public LessonResource() { }

   
}