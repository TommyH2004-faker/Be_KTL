using Be_Ktl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Be_Ktl.Infrastructure.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(c => c.Id);

        // Foreign key
        builder.Property(c => c.StudentId).IsRequired();

        // Relationship
        builder.HasOne(c => c.Student)
            .WithMany(u => u.Carts)
            .HasForeignKey(c => c.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-many with CartItems
        builder.HasMany(c => c.Items)
            .WithOne(ci => ci.Cart)
            .HasForeignKey(ci => ci.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(c => c.IsDeleted);
    }
}

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(ci => ci.Id);

        // Foreign keys
        builder.Property(ci => ci.CartId).IsRequired();
        builder.Property(ci => ci.CourseId).IsRequired();

        // Relationships
        builder.HasOne(ci => ci.Cart)
            .WithMany(c => c.Items)
            .HasForeignKey(ci => ci.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ci => ci.Course)
            .WithMany()
            .HasForeignKey(ci => ci.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(ci => new { ci.CartId, ci.CourseId }).IsUnique();
        builder.HasIndex(ci => ci.IsDeleted);
    }
}

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.OrderCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(o => o.Status)
            .HasConversion<string>();

        // Foreign keys
        builder.Property(o => o.StudentId).IsRequired();

        // Relationships
        builder.HasOne(o => o.Student)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Optional one-to-one with Payment
        builder.HasOne(o => o.Payment)
            .WithOne(p => p.Order)
            .HasForeignKey<Payment>(p => p.OrderId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        // Optional many-to-one with Coupon
        builder.HasOne(o => o.Coupon)
            .WithMany()
            .HasForeignKey(o => o.CouponId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        // One-to-many with OrderItems
        builder.HasMany(o => o.Items)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(o => o.OrderCode).IsUnique();
        builder.HasIndex(o => o.Status);
        builder.HasIndex(o => o.IsDeleted);
    }
}

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(oi => oi.Id);

        // Foreign keys
        builder.Property(oi => oi.OrderId).IsRequired();
        builder.Property(oi => oi.CourseId).IsRequired();

        // Relationships
        builder.HasOne(oi => oi.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(oi => oi.Course)
            .WithMany()
            .HasForeignKey(oi => oi.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(oi => new { oi.OrderId, oi.CourseId }).IsUnique();
        builder.HasIndex(oi => oi.IsDeleted);
    }
}

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.TransactionCode)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(p => p.Gateway)
            .HasConversion<string>();

        builder.Property(p => p.Status)
            .HasConversion<string>();

        // Foreign key
        builder.Property(p => p.OrderId).IsRequired();

        // Relationship
        builder.HasOne(p => p.Order)
            .WithOne(o => o.Payment)
            .HasForeignKey<Payment>(p => p.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(p => p.TransactionCode).IsUnique();
        builder.HasIndex(p => p.Status);
        builder.HasIndex(p => p.IsDeleted);
    }
}

public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.Description)
            .HasMaxLength(500);

        builder.Property(c => c.Type)
            .HasConversion<string>();

        // Indexes
        builder.HasIndex(c => c.Code).IsUnique();
        builder.HasIndex(c => c.IsActive);
        builder.HasIndex(c => c.IsDeleted);
    }
}
