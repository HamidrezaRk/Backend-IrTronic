namespace Domain.Enums;
public enum OrderStatus
{
    PendingPayment,
    Pending,
    Accepted,
    Processing,
    Ready,
    PendingForDriver,
    ReadyForDelivery,
    ReadyForPickup,
    AssignedToDriver,
    DriverAccepted,
    DriverOnWay,
    NearToYou,
    Completed,
    Cancelled
}

public enum OrderProgressBarColor
{
    Pink,
    Red,
    Green
}
public static class GetColorAdnProgressFunctions
{
    public static OrderProgressBarColor GetColor(this OrderStatus order)
    {
        return order switch
        {
            OrderStatus.PendingPayment => OrderProgressBarColor.Pink,
            OrderStatus.Pending => OrderProgressBarColor.Pink,
            OrderStatus.Accepted => OrderProgressBarColor.Pink,
            OrderStatus.Processing => OrderProgressBarColor.Pink,
            OrderStatus.Ready => OrderProgressBarColor.Pink,
            OrderStatus.PendingForDriver => OrderProgressBarColor.Pink,
            OrderStatus.ReadyForDelivery => OrderProgressBarColor.Pink,
            OrderStatus.ReadyForPickup => OrderProgressBarColor.Pink,
            OrderStatus.AssignedToDriver => OrderProgressBarColor.Pink,
            OrderStatus.DriverAccepted => OrderProgressBarColor.Pink,
            OrderStatus.DriverOnWay => OrderProgressBarColor.Pink,
            OrderStatus.NearToYou => OrderProgressBarColor.Pink,
            OrderStatus.Completed => OrderProgressBarColor.Green,
            OrderStatus.Cancelled => OrderProgressBarColor.Red,
            _ => OrderProgressBarColor.Pink,
        };
    }
    public static int GetOrderProgress(this OrderStatus order)
    {
        return order switch
        {
            OrderStatus.PendingPayment => 10,
            OrderStatus.Pending => 15,
            OrderStatus.Accepted => 20,
            OrderStatus.Processing => 25,
            OrderStatus.Ready => 50,
            OrderStatus.PendingForDriver => 50,
            OrderStatus.ReadyForDelivery => 50,
            OrderStatus.ReadyForPickup => 80,
            OrderStatus.AssignedToDriver => 50,
            OrderStatus.DriverAccepted => 50,
            OrderStatus.DriverOnWay => 70,
            OrderStatus.NearToYou => 80,
            OrderStatus.Completed => 100,
            OrderStatus.Cancelled => 100,
            _ => 0,
        };
    }
}

public enum ProductItemStatus
{
    Pending,
    Ready
}

public enum OrderDeliveyType
{
    Pickup,
    Delivery
}
public enum DriverStatus
{
    Pending,
    Accepted,
    Cancelled,
    Delivered,
    Ignored
}

public enum GetDeliveryHistoryStatus
{
    Delivered = 12,
    Cancelled = 13,
}
public static class OrderProgressBarColorFunctions
{
    public static string GetHexCode(this OrderProgressBarColor color)
    {
        return color switch
        {
            OrderProgressBarColor.Green => "#219653",
            OrderProgressBarColor.Red => "#AE2E45",
            OrderProgressBarColor.Pink => "#F1ADCD",
            _ => throw new NotImplementedException()
        };
    }
}