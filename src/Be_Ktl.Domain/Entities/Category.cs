using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; private set; } = default!;

    public string Slug { get; private set; } = default!;

    public string? Description { get; private set; }

    public Guid? ParentCategoryId { get; private set; }

    public Category? ParentCategory { get; private set; }

    public ICollection<Category> Children { get; } = new List<Category>();

    public ICollection<Course> Courses { get; } = new List<Course>();

    public Category() { }

   
}