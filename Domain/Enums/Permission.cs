namespace Domain.Enums;

public enum Permission
{
    Admin = 1,
    Customer = 2,
    ShopAdmin = 3,
    Dispatcher = 4,
    Operator = 5,
    ContentManagement = 6,
    Finance = 7,

}
public static class PermissionConstants
{
    public const string Admin = "Admin";
    public const string ShopAdmin = "ShopAdmin";
    public const string Customer = "Customer";
    public const string Dispatcher = "Dispatcher";
    public const string Operator = "Operator";
    public const string ContentManagement = "ContentManagement";
    public const string Finance = "Finance";

    public const string AdminId = "1";
    public const string CustomerId = "2";
    public const string ShopAdminId = "3";
    public const string DispatcherId = "4";
    public const string OperatorId = "5";
    public const string ContentManagementId = "6";
    public const string FinanceId = "7";

    public static string GetPermissionName(this Permission permission)
    {
        switch (permission)
        {
            case Permission.Admin:
                return Admin;
            case Permission.Customer:
                return Customer;
            case Permission.ShopAdmin:
                return ShopAdmin;
            case Permission.Dispatcher:
                return Dispatcher;
            case Permission.Operator:
                return Operator;
            case Permission.ContentManagement:
                return ContentManagement;
            case Permission.Finance:
                return Finance;

            default:
                break;
        }
        return "";
    }


    public static string GetPermissionId(this Permission permission)
    {
        return permission switch
        {
            Permission.Admin => AdminId,
            Permission.Customer => CustomerId,
            Permission.ShopAdmin => ShopAdminId,
            Permission.Dispatcher => DispatcherId,
            Permission.Operator => OperatorId,
            Permission.ContentManagement => ContentManagementId,
            Permission.Finance => FinanceId,
            _ => throw new ArgumentOutOfRangeException(nameof(permission), permission, null)
        };
    }

    public static List<int> GetStaticRoleIds() =>
        [(int)Permission.Admin, (int)Permission.Customer,
        (int)Permission.ShopAdmin, (int)Permission.Dispatcher,
        (int)Permission.Operator, (int)Permission.ContentManagement, (int)Permission.Finance];

    public static List<int> GetAdminRoleIds() =>
        [(int)Permission.Admin, (int)Permission.ShopAdmin, (int)Permission.Dispatcher,
        (int)Permission.Operator, (int)Permission.ContentManagement, (int)Permission.Finance];

    public static List<(int, string)> GetStaticRoleIdAndNames() =>
        [((int)Permission.Admin, Admin),
        ((int)Permission.Customer, Customer),((int)Permission.ShopAdmin, ShopAdmin),
        ((int)Permission.Dispatcher, Dispatcher), ((int)Permission.Operator, Operator),
        ((int)Permission.ContentManagement, ContentManagement),
        ((int)Permission.Finance, Finance)];


}
