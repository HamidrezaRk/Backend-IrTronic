using Domain.Entites.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

 public class CategoryEntity : BaseEntity
{
    public string? ImagePath { get; set; }
    public string? Name { get; set; }
    public string? ThumbnailPath { get; set; }
    public bool Status { get; set; }

    [ForeignKey(nameof(Category))]
    public int? ParentCategoryId { get; set; }
    public CategoryEntity? Category { get; set; }
    public List<ProductEntity> Products { get; set; } = [];
    public List<ProductCategory> ProductCategories { get; set; } = [];

    [InverseProperty(nameof(Category))]
    public List<CategoryEntity> SubCategories { get; } = [];
    public bool OnHomeConfig { get; set; }
    public int? Sort { get; set; }
}
