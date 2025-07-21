using Domain.Entites;
using Domain.Entites.BaseEntities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Infrastructure.DbContext;

public class MasterDbContext(DbContextOptions<MasterDbContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<UserRolesEntity> UserRoles { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<BannerEntity> Banners { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<PaymentEntity> Payments { get; set; }
    public DbSet<RolePermissionEntity> RolePermissions { get; set; }
    public DbSet<LikedProduct> LikedProducts { get; set; }
    public DbSet<BookmarkedProduct> BookmarkedProducts { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderLogEntity> OrderLogs { get; set; }
    public DbSet<TransactionEntity> Transactions { get; set; }
    public DbSet<DeliveryEntity> Deliveries { get; set; }
    public DbSet<InvoiceEntity> Invoices { get; set; }
    public DbSet<OrderCommentEntity> OrderComments { get; set; }
    public DbSet<ProductCategory> ProductCategory { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.NoAction;
        }
        modelBuilder.Entity<ProductEntity>()
            .HasMany(p => p.Categories)
            .WithMany(c => c.Products)
            .UsingEntity<ProductCategory>(
                l => l.HasOne<CategoryEntity>().WithMany(e => e.ProductCategories).HasForeignKey(e => e.CategoryId),
                r => r.HasOne<ProductEntity>().WithMany(e => e.ProductCategories).HasForeignKey(e => e.ProductId)
            );
        modelBuilder
            .Entity<ProductEntity>()
            .HasMany(x => x.RelatedProducts)
            .WithMany(x => x.RelatedToProducts)
            .UsingEntity<RelatedProduct>(
                l => l.HasOne<ProductEntity>().WithMany().HasForeignKey(x => x.ProductRelated),
                r => r.HasOne<ProductEntity>().WithMany().HasForeignKey(x => x.ProductRelatee)
            );

         modelBuilder.Entity<UserEntity>()
            .HasMany(x => x.Orders)
            .WithOne(x => x.User);
        Expression<Func<ISoftDeleteBaseEntity, bool>> filterExpr = bm => !bm.IsDeleted;
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(ISoftDeleteBaseEntity).IsAssignableFrom(entityType.ClrType))
            {

                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var body = ReplacingExpressionVisitor.Replace(filterExpr.Parameters.First(), parameter, filterExpr.Body);
                var lambdaExpression = Expression.Lambda(body, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(Expression.Lambda(body, parameter));
            }
        }
    }

}
