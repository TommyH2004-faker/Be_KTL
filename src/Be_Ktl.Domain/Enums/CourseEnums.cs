namespace Be_Ktl.Domain.Enums;

public enum CourseLevel
{
    Beginner = 1,
    Intermediate = 2,
    Advanced = 3,
    AllLevels = 4
}

public enum CourseStatus
{
    Draft = 1,
    Published = 2,
    Archived = 3
}

public enum EnrollmentStatus
{
    Pending = 1,
    Active = 2,
    Completed = 3,
    Cancelled = 4
}

public enum OrderStatus
{
    Pending = 1,
    Paid = 2,
    Failed = 3,
    Cancelled = 4,
    Refunded = 5
}

public enum PaymentStatus
{
    Pending = 1,
    Succeeded = 2,
    Failed = 3,
    Refunded = 4
}

public enum PaymentGateway
{
    VnPay = 1,
    MoMo = 2,
    Stripe = 3,
    BankTransfer = 4,
    Cash = 5
}

public enum CouponType
{
    Percentage = 1,
    FixedAmount = 2
}

public enum NotificationType
{
    System = 1,
    Course = 2,
    Payment = 3,
    Livestream = 4
}

public enum LivestreamStatus
{
    Scheduled = 1,
    Live = 2,
    Ended = 3,
    Cancelled = 4
}