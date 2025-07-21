using Domain.Entites.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

public class ProductEntity : BaseEntity
{
    public string Name { get; set; } = null!;
    public ProductType ProductType { get; set; }
    public int Stock { get; set; }
    public bool IsStockManageable { get; set; }
    public bool IsVisible { get; set; }
    public bool IsEnabled { get; set; }
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal? TempPrice { get; set; }
    public DateTime? TempPriceStart { get; set; }
    public DateTime? TempPriceEnd { get; set; }
    public int SalesCount { get; set; }
    public int PrepreationTime { get; set; } = 0;
    public bool FlowerAndCakeCombinations { get; set; }
    public List<CategoryEntity> Categories { get; } = [];
    public List<ProductCategory> ProductCategories { get; } = [];
    public List<ProductImageEntity> Images { get; } = [];
    public List<UserEntity> Vendors { get; } = [];
    public int Likes { get; set; } = 0;
    public List<BookmarkedProduct> BookmarkedBy { get; } = [];
    public List<LikedProduct> LikedBy { get; } = [];
    public List<ProductEntity> RelatedProducts { get; } = [];
    public List<ProductEntity> RelatedToProducts { get; } = [];
}
public enum ProductType
{
    Basic,
    Bundle
}
public class ProductCategory
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
}

public class RelatedProduct
{
    public int Id { get; set; }
    public int ProductRelatee { get; set; }
    public int ProductRelated { get; set; }
}