using Be_Ktl.Domain.Common;
using Be_Ktl.Domain.Enums;

namespace Be_Ktl.Domain.Entities;

public class Livestream : BaseEntity
{
    public Guid InstructorId { get; private set; }

    public Instructor Instructor { get; private set; } = default!;

    public Guid? CourseId { get; private set; }

    public Course? Course { get; private set; }

    public string Title { get; private set; } = default!;

    public string? Description { get; private set; }

    public string StreamKey { get; private set; } = default!;

    public string PlaybackUrl { get; private set; } = default!;

    public string? RecordedVideoUrl { get; private set; }

    public LivestreamStatus Status { get; private set; }

    public DateTime StartTime { get; private set; }

    public DateTime? EndTime { get; private set; }

    public Livestream() { }

    
}