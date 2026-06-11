using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;

public class Video : BaseEntity
{
    public Guid LessonId { get; private set; }

    public Lesson Lesson { get; private set; } = default!;

    public string StorageUrl { get; private set; } = default!;

    public string HlsUrl { get; private set; } = default!;

    public int DurationSeconds { get; private set; }

    public long SizeInBytes { get; private set; }

    public string? Provider { get; private set; }

    public Video() { }

   
}