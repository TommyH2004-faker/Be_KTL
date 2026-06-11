using Be_Ktl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Be_Ktl.Infrastructure.Configurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.UserId).IsRequired();

        builder.Property(i => i.Biography)
            .HasMaxLength(2000);

        builder.Property(i => i.Specialization)
            .HasMaxLength(256);

        builder.Property(i => i.WebsiteUrl)
            .HasMaxLength(500);

        // One-to-one with User
        builder.HasOne(i => i.User)
            .WithOne(u => u.InstructorProfile)
            .HasForeignKey<Instructor>(i => i.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-many with Courses
        builder.HasMany(i => i.Courses)
            .WithOne(c => c.Instructor)
            .HasForeignKey(c => c.InstructorId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-many with Livestreams
        builder.HasMany(i => i.Livestreams)
            .WithOne(l => l.Instructor)
            .HasForeignKey(l => l.InstructorId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(i => i.UserId).IsUnique();
        builder.HasIndex(i => i.IsDeleted);
    }
}

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(c => c.Description)
            .HasMaxLength(500);

        // Self-referential for parent category
        builder.HasOne(c => c.ParentCategory)
            .WithMany(c => c.Children)
            .HasForeignKey(c => c.ParentCategoryId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // One-to-many with Courses
        builder.HasMany(c => c.Courses)
            .WithOne(c => c.Category)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(c => c.Name);
        builder.HasIndex(c => c.IsDeleted);
    }
}
