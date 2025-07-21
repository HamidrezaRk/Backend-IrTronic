using Domain.Entites.BaseEntities;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

 public class BannerEntity : BaseEntity
 {
    public required string Title { get; set; }
    public required string Description { get; set; }
    public string? PathToImage { get; set; }
    public required bool IsEnabled { get; set; }

    [ForeignKey(nameof(Category))]
    public int? CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }

    public BannerType? Type { get; set; }

    [ForeignKey(nameof(Product))]
    public int? ProductId { get; set; }
    public ProductEntity? Product { get; set; }
}
