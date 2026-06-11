using Be_Ktl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Be_Ktl.Infrastructure.Configurations;

public class LessonResourceConfiguration : IEntityTypeConfiguration<LessonResource>
{
    public void Configure(EntityTypeBuilder<LessonResource> builder)
    {
        builder.HasKey(lr => lr.Id);

        builder.Property(lr => lr.FileName)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(lr => lr.FileUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(lr => lr.FileType)
            .HasMaxLength(50);

        // Foreign key
        builder.Property(lr => lr.LessonId).IsRequired();

        // Relationship
        builder.HasOne(lr => lr.Lesson)
            .WithMany(l => l.Resources)
            .HasForeignKey(lr => lr.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(lr => lr.IsDeleted);
    }
}

public class CourseObjectiveConfiguration : IEntityTypeConfiguration<CourseObjective>
{
    public void Configure(EntityTypeBuilder<CourseObjective> builder)
    {
        builder.HasKey(co => co.Id);

        builder.Property(co => co.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(co => co.OrderIndex);

        // Foreign key
        builder.Property(co => co.CourseId).IsRequired();

        // Relationship
        builder.HasOne(co => co.Course)
            .WithMany(c => c.Objectives)
            .HasForeignKey(co => co.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(co => co.OrderIndex);
        builder.HasIndex(co => co.IsDeleted);
    }
}

public class CourseRequirementConfiguration : IEntityTypeConfiguration<CourseRequirement>
{
    public void Configure(EntityTypeBuilder<CourseRequirement> builder)
    {
        builder.HasKey(cr => cr.Id);

        builder.Property(cr => cr.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(cr => cr.OrderIndex);

        // Foreign key
        builder.Property(cr => cr.CourseId).IsRequired();

        // Relationship
        builder.HasOne(cr => cr.Course)
            .WithMany(c => c.Requirements)
            .HasForeignKey(cr => cr.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(cr => cr.OrderIndex);
        builder.HasIndex(cr => cr.IsDeleted);
    }
}
