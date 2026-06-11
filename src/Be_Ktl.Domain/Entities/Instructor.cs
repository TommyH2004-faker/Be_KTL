using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;
public class Instructor : BaseEntity
{
    public Guid UserId { get; private set; }

    public User User { get; private set; } = default!;

    public string Biography { get; private set; } = default!;

    public string Specialization { get; private set; } = default!;

    public int ExperienceYears { get; private set; }

    public string? WebsiteUrl { get; private set; }

    public ICollection<Course> Courses { get; } = new List<Course>();

    public ICollection<Livestream> Livestreams { get; } = new List<Livestream>();

    public Instructor() { }

   
}
