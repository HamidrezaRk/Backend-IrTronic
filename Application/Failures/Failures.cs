namespace Application.Failures;

public class Failures
{
    public class AuthorizationFailure() : Exception();
    public class UserIsSuspendedFailure() : AuthorizationFailure();
    public class InvalidTokenFailure() : AuthorizationFailure();
    public class TokenIsExpired() : AuthorizationFailure();
    public class Failure(int Code, string Massage) : Exception()
    {
        public int Code { get; } = Code;
        public string Massage { get; } = Massage;
        public object? MetaData { get; set; }
    }

    public class BannerFailure(int Code, string Message) : Failure(Code, Message);
    public class LoginFailure(int Code, string Massage) : Failure(Code, Massage);
    public class TermsAndConditionsFailure(int Code, string Massage) : Failure(Code, Massage);
    public class TokenDeadLineFailure(int Code, string Massage) : Failure(Code, Massage);
    public class UserFailure(int Code, string Massage) : Failure(Code, Massage);
    public class ZoneFailure(int Code, string Massage) : Failure(Code, Massage);
    public class AddressFailure(int Code, string Massage) : Failure(Code, Massage);
    public class CategoryFailure(int Code, string Massage) : Failure(Code, Massage);
    public class ProductFailure(int Code, string Massage) : Failure(Code, Massage);
    public class CheckFileFailure(int Code, string Massage) : Failure(Code, Massage);
    public class RoleFailure(int Code, string Massage) : Failure(Code, Massage);
    public class InputFailure(int Code, string Massage) : Failure(Code, Massage);
    public class OrderFailure(int Code, string Massage) : Failure(Code, Massage);
    public class CartFailure(int Code, string Massage) : Failure(Code, Massage);

    public class EmailOrPasswordIsInvalid() : LoginFailure(1, "Email Or Password Is Invalid");
    public class EmailOrOtpIsInvalid() : LoginFailure(2, "Email Or Otp Is Invalid");
    public class TermsAndConditionsNotFound() : TermsAndConditionsFailure(3, "Terms And Conditions Not Found");
    public class UseHelpAndCustomerServiceApi() : TermsAndConditionsFailure(4, "Use HelpAndCustomerService Api");
    public class OtpOrPhoneIsInvalid() : LoginFailure(5, "Otp Or Phone Number Is Invalid");
    public class NoDeadLineFound() : TokenDeadLineFailure(6, "No Dead Line Found");
    public class NoTokenCreateDateFound() : TokenDeadLineFailure(7, "No Token Create Date Found");
    public class UserNotFound() : UserFailure(8, "User Not Found");
    public class InvalidRequest() : UserFailure(9, "Invalid Request");
    public class ZoneNotFound() : ZoneFailure(10, "Zone Not Found");
    public class FullNameFormat() : UserFailure(11, "Full name must be in English characters");
    public class UserNameDuplicate() : UserFailure(12, "This username exists");
    public class EmailDuplicate() : UserFailure(13, "This email exists");
    public class AnyUserExistInDatabase() : UserFailure(14, "Any User Exist In Database");
    public class UseContactApi() : TermsAndConditionsFailure(15, "Use Contact Api");
    public class PhoneNumberDuplicate() : UserFailure(16, "This PhoneNumber exists");
    public class UserSuspendError() : UserFailure(17, "User Is Suspended");
    public class AddressNotFound() : AddressFailure(20, "Address Not Found");
    public class CategoryPathNotFound() : CheckFileFailure(21, "Category Paths Not Found");
    public class IsChangedFullnameError() : UserFailure(22, " User already changed fullname");
    public class CategoryNotFound() : CategoryFailure(23, "Category not found!");
    public class ProductNotFound() : ProductFailure(24, "Product not found!");
    public class UserCannotDeleteAccount() : UserFailure(25, "User cannot delete account because wallet have values");
    public class BannerNotFound() : BannerFailure(26, "Banner not found!");
    public class BannerArgumentsNotValid() : BannerFailure(27, "Banner arguments are not valid");
    public class CategoryOrProductNotFound() : BannerFailure(28, "Category or product not found!");
    public class ParentCategoryNotFound() : CategoryFailure(29, "Parent Category Not Found");
    public class ParentIdSameAsCategoryId() : CategoryFailure(30, "Parent Category UserId Can't Be Same As Category UserId");
    public class VendorPropertiesNotAvailable() : UserFailure(31, "Vendor properties are not available!");
    public class RoleIsExist() : RoleFailure(32, "Role is exist!");
    public class RoleNotFound() : RoleFailure(33, "Role Not Found!");
    public class BannerThumbnailPathNotFound() : BannerFailure(34, "Banner thumbnail path not found!");
    public class InputTypeFailure() : InputFailure(35, "Invalid Input For Type");
    public class AttributeItemsNotFound() : ProductFailure(36, "Attribute Items Not Found");
    public class ProductAttributeNotFound() : ProductFailure(37, "Product Attribute Not Found");
    public class ProductImageThumbnailPathInvalid() : ProductFailure(38, "Product image/thumbnail path is invalid!");
    public class OrderArchivedOrNotFound() : OrderFailure(39, "Order Is Already Archived or Not Found!");
    public class OrderNotFoundFailure() : OrderFailure(40, "Order Not Found!");
    public class EmailNotValid() : UserFailure(41, "Email Address Is Invalid!");
    public class CustomizedProductNotExists() : ProductFailure(42, "Customized Product Does Not Exists.");
    public class InvalidCartId() : CartFailure(43, "Invalid Cart Id");
    public class CannotEditCustomizedProduct() : OrderFailure(44, "Cannot Edit This Customized Product");
    public class CanNotChangeOrderStatus() : OrderFailure(47, "Can Not Change Order Status!");
    public class ProductAttributesNotValid() : CartFailure(48, "Product Attribute Are Not Valid!");
    public class CartIdNotValid() : CartFailure(49, "Cart ID is Not in Valid Form!");
    public class PermissionDeniedForCart() : CartFailure(50, "You Do not Have Access to This Cart!");
    public class OutOfStock() : ProductFailure(51, "Out Of Stock!");
    public class ItemOutOfStock() : ProductFailure(52, "Item Out Of Stock!");
    public class WalletNoBalance() : OrderFailure(53, "The wallet has no balance");
    public class InvoiceNotFound() : OrderFailure(54, "Invoice Not Found!");
    public class TheSelectedTimeForThisOrderIsFull() : OrderFailure(55, "The selected time for this order is full");
    public class StatusNotPendingPayment() : OrderFailure(56, "The status of this order is not pending payment");
    public class AddressOrDeliveryTypeEmpty() : OrderFailure(57, "Address Or Delivery Type Cant Be Null");
    public class CartIsEmpty() : CartFailure(58, "The shopping cart is empty");
    public class DriverIsOnline() : UserFailure(59, "Driver Is Online!");
    public class DriverIsOffline() : UserFailure(60, "Driver Is Offline!");
    public class DriverIdCannotbeNull() : OrderFailure(61, "DriverId Cannot be Null");
    public class PickupIdCannotbeNull() : OrderFailure(62, "PickupLocationId Cannot be Null");
    public class CanNotAddProductAsItem() : ProductFailure(63, "Can not Add Product Itself as Item!");
    public class CanNotAddBundleProductAsItem() : ProductFailure(64, "Can not Add Bundle Product as Item!");
    public class CanNotConnectedToFileApi() : CheckFileFailure(65, "Can Not Connected To File Api");
    public class ItemsEmpty() : ProductFailure(66, "Items Can Not Be Empty!");
    public class TitleForPickUpEmpty() : OrderFailure(67, "Title For PickUp Can Not Be Empty!");
    public class EmailAndPhoneEmpty() : UserFailure(68, "Email or Phone Should Be Filled!");
    public class FieldsEmpty() : OrderFailure(69, "can not change order Details, because Zone and Name and Phone Can Not Be Empty!");
    public class InvalidDeliveryTime() : OrderFailure(70, "Invalid Delivery Time");
}
