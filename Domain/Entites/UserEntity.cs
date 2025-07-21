using Domain.Entites.BaseEntities;
using Domain.Entities;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

public class UserEntity : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? HashedPassword { get; set; }
    public string? Phone { get; set; }
    [InverseProperty(nameof(UserRolesEntity.User))]
    public List<UserRolesEntity>? Roles { get; set; }

    [InverseProperty(nameof(AddressEntity.User))]
    public List<AddressEntity>? Addresses { get; set; }
    public bool IsSuspended { get; set; }   
    public string? CountryCode { get; set; }
    public decimal Wallet { get; set; }
    public string? SocialNumber { get; set; }
    public Gender? Gender { get; set; }
    [InverseProperty(nameof(LikedProduct.User))]
    public List<LikedProduct> LikedProducts { get; } = []; // Exclusive to Customer
    [InverseProperty(nameof(BookmarkedProduct.User))]
    public List<BookmarkedProduct> BookmarkedProducts { get; } = []; // Exclusive to Customer
    [InverseProperty(nameof(TransactionEntity.User))]
    public List<TransactionEntity> Transactions { get; } = [];
    public string? DeletedAccountInformation { get; set; }
    public bool IsChangedFullName { get; set; }
    public string CartId { get; set; } = Guid.NewGuid().ToString();
    public List<OrderEntity> Orders { get; set; } = [];
}

public class LikedProduct
{
    public int Id { get; set; }
    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    public ProductEntity? Product { get; set; }
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public UserEntity? User { get; set; }
}

public class BookmarkedProduct
{
    public int Id { get; set; }
    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    public ProductEntity? Product { get; set; }
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public UserEntity? User { get; set; }
}


