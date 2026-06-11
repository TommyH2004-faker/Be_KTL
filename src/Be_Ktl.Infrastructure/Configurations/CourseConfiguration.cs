using Be_Ktl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Be_Ktl.Infrastructure.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(c => c.Slug)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(c => c.ShortDescription)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(c => c.Description)
            .HasMaxLength(4000);

        builder.Property(c => c.ThumbnailUrl)
            .HasMaxLength(500);

        builder.Property(c => c.Level)
            .HasConversion<string>();

        builder.Property(c => c.Status)
            .HasConversion<string>();

        // Foreign keys
        builder.Property(c => c.CategoryId).IsRequired();
        builder.Property(c => c.InstructorId).IsRequired();

        // Relationships
        builder.HasOne(c => c.Category)
            .WithMany(c => c.Courses)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Instructor)
            .WithMany(i => i.Courses)
            .HasForeignKey(c => c.InstructorId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-many collections
        builder.HasMany(c => c.Chapters)
            .WithOne(ch => ch.Course)
            .HasForeignKey(ch => ch.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Objectives)
            .WithOne(co => co.Course)
            .HasForeignKey(co => co.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Requirements)
            .WithOne(cr => cr.Course)
            .HasForeignKey(cr => cr.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Enrollments)
            .WithOne(e => e.Course)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Reviews)
            .WithOne(r => r.Course)
            .HasForeignKey(r => r.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Wishlists)
            .WithOne(w => w.Course)
            .HasForeignKey(w => w.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(c => c.Slug).IsUnique();
        builder.HasIndex(c => c.IsDeleted);
    }
}

public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
{
    public void Configure(EntityTypeBuilder<Chapter> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(c => c.Description)
            .HasMaxLength(1000);

        builder.Property(c => c.OrderIndex);

        // Foreign key
        builder.Property(c => c.CourseId).IsRequired();

        // Relationship
        builder.HasOne(c => c.Course)
            .WithMany(c => c.Chapters)
            .HasForeignKey(c => c.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-many with Lessons
        builder.HasMany(c => c.Lessons)
            .WithOne(l => l.Chapter)
            .HasForeignKey(l => l.ChapterId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(c => c.OrderIndex);
        builder.HasIndex(c => c.IsDeleted);
    }
}

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Title)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(l => l.Content)
            .HasMaxLength(5000);

        builder.Property(l => l.OrderIndex);

        // Foreign key
        builder.Property(l => l.ChapterId).IsRequired();

        // Relationship
        builder.HasOne(l => l.Chapter)
            .WithMany(c => c.Lessons)
            .HasForeignKey(l => l.ChapterId)
            .OnDelete(DeleteBehavior.Cascade);

        // Optional one-to-one with Video
        builder.HasOne(l => l.Video)
            .WithOne()
            .HasForeignKey<Video>(v => v.LessonId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        // One-to-many with LessonResources
        builder.HasMany(l => l.Resources)
            .WithOne(lr => lr.Lesson)
            .HasForeignKey(lr => lr.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-many with LessonProgress
        builder.HasMany(l => l.Progresses)
            .WithOne(lp => lp.Lesson)
            .HasForeignKey(lp => lp.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(l => l.OrderIndex);
        builder.HasIndex(l => l.IsDeleted);
    }
}

public class VideoConfiguration : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        builder.HasKey(v => v.Id);

        builder.Property(v => v.StorageUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(v => v.HlsUrl)
            .HasMaxLength(500);

        builder.Property(v => v.Provider)
            .HasMaxLength(128);

        // Foreign key
        builder.Property(v => v.LessonId).IsRequired();

        // Relationship - one-to-one with Lesson
        builder.HasOne(v => v.Lesson)
            .WithOne(l => l.Video)
            .HasForeignKey<Video>(v => v.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(v => v.IsDeleted);
    }
}
