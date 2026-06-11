using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;

public class Certificate : BaseEntity
{
    public Guid StudentId { get; private set; }

    public User Student { get; private set; } = default!;

    public Guid CourseId { get; private set; }

    public Course Course { get; private set; } = default!;

    public string CertificateCode { get; private set; } = default!;

    public DateTime IssuedAt { get; private set; }

    public DateTime? ExpiredAt { get; private set; }

    public Certificate() { }

    public Certificate(Guid studentId, User student, Guid courseId, Course course, string certificateCode, DateTime? expiredAt = null)
    {
        StudentId = studentId;
        Student = student;
        CourseId = courseId;
        Course = course;
        CertificateCode = certificateCode;
        IssuedAt = DateTime.UtcNow;
        ExpiredAt = expiredAt;
    }

    public bool IsValid()
    {
        return ExpiredAt == null || DateTime.UtcNow <= ExpiredAt;
    }
}