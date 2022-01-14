namespace AppStoreServerNotificationsV2.Models;

/// <summary>
/// The notificationType describes the event that led to this notification.
/// </summary>
public enum NotificationType
{
    /// <summary>
    /// Indicates that the customer initiated a refund request for a consumable in-app purchase, and the App Store is requesting that you provide consumption data.
    /// </summary>
    CONSUMPTION_REQUEST,

    /// <summary>
    /// A notification type that along with its subtype indicates that the user made a change to their subscription plan. 
    /// </summary>
    DID_CHANGE_RENEWAL_PREF,

    /// <summary>
    /// A notification type that along with its subtype indicates that the user made a change to the subscription renewal status.
    /// </summary>
    DID_CHANGE_RENEWAL_STATUS,

    /// <summary>
    /// A notification type that along with its subtype indicates that the subscription failed to renew due to a billing issue.
    /// </summary>
    DID_FAIL_TO_RENEW,

    /// <summary>
    /// A notification type that along with its subtype indicates that the subscription successfully renewed.
    /// </summary>
    DID_RENEW,

    /// <summary>
    /// A notification type that along with its subtype indicates that a subscription expired.
    /// </summary>
    EXPIRED,

    /// <summary>
    /// Indicates that the billing grace period has ended without renewing the subscription, so you can turn off access to service or content.
    /// </summary>
    GRACE_PERIOD_EXPIRED,

    /// <summary>
    /// A notification type that along with its subtype indicates that the user redeemed a promotional offer or offer code.
    /// </summary>
    OFFER_REDEEMED,

    /// <summary>
    /// A notification type that along with its subtype indicates that the system has informed the user of a subscription price increase.
    /// </summary>
    PRICE_INCREASE,

    /// <summary>
    /// Indicates that the App Store successfully refunded a transaction for a consumable in-app purchase, a non-consumable in-app purchase, an auto-renewable subscription, or a non-renewing subscription.
    /// </summary>
    REFUND,

    /// <summary>
    /// Indicates that the App Store declined a refund request initiated by the app developer.
    /// </summary>
    REFUND_DECLINED,

    /// <summary>
    /// Indicates that the App Store extended the subscription renewal date that the developer requested.
    /// </summary>
    RENEWAL_EXTENDED,

    /// <summary>
    /// Indicates that an in-app purchase the user was entitled to through Family Sharing is no longer available through sharing.
    /// </summary>
    REVOKE,

    /// <summary>
    /// A notification type that along with its subtype indicates that the user subscribed to a product.
    /// </summary>
    SUBSCRIBED
}