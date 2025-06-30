using Domain.Entites.BaseEntities;

namespace Domain.Entites;

public class ProductImageEntity : BaseEntity
{
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
    public string ThumbnailPath { get; set; } = null!;
}
