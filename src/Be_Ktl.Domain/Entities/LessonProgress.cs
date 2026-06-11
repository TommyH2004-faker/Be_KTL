using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;

public class LessonProgress : BaseEntity
{
    public Guid StudentId { get; private set; }

    public User Student { get; private set; } = default!;

    public Guid LessonId { get; private set; }

    public Lesson Lesson { get; private set; } = default!;

    public int LastPositionSeconds { get; private set; }

    public decimal WatchedPercentage { get; private set; }

    public bool IsCompleted { get; private set; }

    public DateTime? CompletedAt { get; private set; }

    public LessonProgress() { }

   
}