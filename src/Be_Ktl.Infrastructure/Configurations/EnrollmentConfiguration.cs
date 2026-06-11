using Be_Ktl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Be_Ktl.Infrastructure.Configurations;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Status)
            .HasConversion<string>();

        // Foreign keys
        builder.Property(e => e.StudentId).IsRequired();
        builder.Property(e => e.CourseId).IsRequired();

        // Relationships
        builder.HasOne(e => e.Student)
            .WithMany(u => u.Enrollments)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(e => new { e.StudentId, e.CourseId }).IsUnique();
        builder.HasIndex(e => e.Status);
        builder.HasIndex(e => e.IsDeleted);
    }
}

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Comment)
            .IsRequired()
            .HasMaxLength(1000);

        // Foreign keys
        builder.Property(r => r.StudentId).IsRequired();
        builder.Property(r => r.CourseId).IsRequired();

        // Relationships
        builder.HasOne(r => r.Student)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Course)
            .WithMany(c => c.Reviews)
            .HasForeignKey(r => r.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(r => new { r.StudentId, r.CourseId }).IsUnique();
        builder.HasIndex(r => r.Rating);
        builder.HasIndex(r => r.IsDeleted);
    }
}

public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
{
    public void Configure(EntityTypeBuilder<Certificate> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.CertificateCode)
            .IsRequired()
            .HasMaxLength(128);

        // Foreign keys
        builder.Property(c => c.StudentId).IsRequired();
        builder.Property(c => c.CourseId).IsRequired();

        // Relationships
        builder.HasOne(c => c.Student)
            .WithMany()
            .HasForeignKey(c => c.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.Course)
            .WithMany()
            .HasForeignKey(c => c.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(c => c.CertificateCode).IsUnique();
        builder.HasIndex(c => new { c.StudentId, c.CourseId }).IsUnique();
        builder.HasIndex(c => c.IsDeleted);
    }
}

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(n => n.Id);

        builder.Property(n => n.Title)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(n => n.Content)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(n => n.Type)
            .HasConversion<string>();

        // Foreign key
        builder.Property(n => n.UserId).IsRequired();

        // Relationship
        builder.HasOne(n => n.User)
            .WithMany(u => u.Notifications)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(n => n.IsRead);
        builder.HasIndex(n => n.Type);
        builder.HasIndex(n => n.IsDeleted);
    }
}

public class LessonProgressConfiguration : IEntityTypeConfiguration<LessonProgress>
{
    public void Configure(EntityTypeBuilder<LessonProgress> builder)
    {
        builder.HasKey(lp => lp.Id);

        // Foreign keys
        builder.Property(lp => lp.StudentId).IsRequired();
        builder.Property(lp => lp.LessonId).IsRequired();

        // Relationships
        builder.HasOne(lp => lp.Student)
            .WithMany()
            .HasForeignKey(lp => lp.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(lp => lp.Lesson)
            .WithMany(l => l.Progresses)
            .HasForeignKey(lp => lp.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(lp => new { lp.StudentId, lp.LessonId }).IsUnique();
        builder.HasIndex(lp => lp.IsCompleted);
        builder.HasIndex(lp => lp.IsDeleted);
    }
}

public class LivestreamConfiguration : IEntityTypeConfiguration<Livestream>
{
    public void Configure(EntityTypeBuilder<Livestream> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Title)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(l => l.Description)
            .HasMaxLength(1000);

        builder.Property(l => l.StreamKey)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(l => l.PlaybackUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(l => l.RecordedVideoUrl)
            .HasMaxLength(500);

        builder.Property(l => l.Status)
            .HasConversion<string>();

        // Foreign keys
        builder.Property(l => l.InstructorId).IsRequired();

        // Relationships
        builder.HasOne(l => l.Instructor)
            .WithMany(i => i.Livestreams)
            .HasForeignKey(l => l.InstructorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(l => l.Course)
            .WithMany()
            .HasForeignKey(l => l.CourseId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        // Indexes
        builder.HasIndex(l => l.Status);
        builder.HasIndex(l => l.StartTime);
        builder.HasIndex(l => l.IsDeleted);
    }
}

public class UserSessionConfiguration : IEntityTypeConfiguration<UserSession>
{
    public void Configure(EntityTypeBuilder<UserSession> builder)
    {
        builder.HasKey(us => us.Id);

        builder.Property(us => us.DeviceId)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(us => us.IpAddress)
            .IsRequired()
            .HasMaxLength(45); // IPv6 max length

        builder.Property(us => us.RefreshToken)
            .IsRequired()
            .HasMaxLength(1000);

        // Foreign key
        builder.Property(us => us.UserId).IsRequired();

        // Relationship
        builder.HasOne(us => us.User)
            .WithMany(u => u.Sessions)
            .HasForeignKey(us => us.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(us => us.RefreshToken);
        builder.HasIndex(us => us.ExpiredAt);
        builder.HasIndex(us => us.IsDeleted);
    }
}

public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
{
    public void Configure(EntityTypeBuilder<Wishlist> builder)
    {
        builder.HasKey(w => w.Id);

        // Foreign keys
        builder.Property(w => w.StudentId).IsRequired();
        builder.Property(w => w.CourseId).IsRequired();

        // Relationships
        builder.HasOne(w => w.Student)
            .WithMany(u => u.Wishlists)
            .HasForeignKey(w => w.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(w => w.Course)
            .WithMany(c => c.Wishlists)
            .HasForeignKey(w => w.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(w => new { w.StudentId, w.CourseId }).IsUnique();
        builder.HasIndex(w => w.IsDeleted);
    }
}
