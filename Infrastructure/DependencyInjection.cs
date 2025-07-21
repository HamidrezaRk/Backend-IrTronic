using Domain.Entites;
using Domain.Enums;
using Domain.IServices;
using Infrastructure.DbContext;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LinqKit;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, string MasterDbConnectionString, string SlaveDbConnectionString, string baseUrl)
    {
        services.AddDbContext<MasterDbContext>(options => options.UseSqlServer(MasterDbConnectionString).WithExpressionExpanding());
        services.AddDbContext<SlaveDbContext>(options => options.UseSqlServer(SlaveDbConnectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).WithExpressionExpanding());
        services.AddHttpClient("httpClient", x => x.BaseAddress = new Uri(baseUrl));
        //services.AddScoped<IPasswordHasherService, HashFunctionsService>();
        services.AddScoped<IUserService, UserService>();
        //services.AddScoped<IAddressService, AddressService>();
        //services.AddScoped<IZoneService, ZoneService>();
        //services.AddScoped<IFirstUserService, FirstUserService>();
        //services.AddScoped<ICategoryService, CategoryService>();
        //services.AddScoped<IBannerServices, BannerServices>();
        //services.AddScoped<IProductService, ProductService>();
        //services.AddScoped<IRoleService, RoleService>();
        //services.AddScoped<IPaymentService, PaymentService>();
        //services.AddSingleton<IUrlService, UrlService>();
        //services.AddScoped<ICartService, CartService>();
        //services.AddScoped<IOrderService, OrderService>();
        //services.AddScoped<ISearchService, SearchService>();
        //services.AddScoped<IWalletService, WalletService>();
        //services.AddScoped<ITransactionService, TransactionService>();
        //services.AddScoped<ITransactionalService, TransactionalService>();
        var serviceProvider = services.BuildServiceProvider();
        var dbContext = serviceProvider.GetService<MasterDbContext>();
        var SlaveContext = serviceProvider.GetService<SlaveDbContext>();
        InitializeDatabase(dbContext!, SlaveContext!);

    }
    private static void InitializeDatabase(MasterDbContext MasterContext, SlaveDbContext SlaveContext)
    {
        MasterContext.Database.Migrate();
        SlaveContext.Database.Migrate();
        foreach (var role in PermissionConstants.GetStaticRoleIdAndNames())
        {
            var record = MasterContext.Roles.Where(x => x.Id == role.Item1).FirstOrDefault();
            if (record == null)
            {
                MasterContext.Roles.Add(new RoleEntity()
                {
                    Id = role.Item1,
                    IsChangeable = false,
                    RoleName = role.Item2
                });
            }
            else
            {
                record.RoleName = role.Item2;
                record.IsChangeable = false;
            }
        }

        foreach (var role in PermissionConstants.GetStaticRoleIdAndNames())
        {
            var record = MasterContext.RolePermissions.Where(x => x.RoleId == role.Item1 && x.Permission == (Permission)role.Item1).FirstOrDefault();
            if (record == null)
            {
                MasterContext.RolePermissions.Add(new RolePermissionEntity()
                {
                    RoleId = role.Item1,
                    Permission = (Permission)role.Item1
                });
            }
        }

        foreach (var type in Enum.GetValues(typeof(PaymentType)))
        {
            var record = MasterContext.Payments.Where(x => x.PaymentType == (PaymentType)type).FirstOrDefault();
            if (record == null)
            {
                //MasterContext.Payments.Add(new PaymentEntity
                //{
                //    TitleForDelivery = new(" ", ""),
                //    TitleForPickUp = null,
                //    AppIconPath = "",
                //    PaymentType = (PaymentType)type,
                //    IsEnable = false
                //});
            }
        }
      
        MasterContext.Users.Where(x => x.CartId == "")
                           .ExecuteUpdate(x => x.SetProperty(x => x.CartId,
                                                             Guid.NewGuid().ToString()));
        MasterContext.SaveChanges();
    }

}
