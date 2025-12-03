namespace AppStoreServerNotificationsV2.Models;

public record JWSRenewalInfoDecodedPayload(string AutoRenewProductId, int AutoRenewStatus,
    string Environment, int ExpirationIntent, DateTimeOffset GracePeriodExpiresDate,
    bool IsInBillingRetryPeriod, string OfferIdentifier, int OfferType, string OriginalTransactionId,
    int PriceIncreaseStatus, string ProductId, DateTimeOffset RecentSubscriptionStartDate, 
    DateTimeOffset RenewalDate, DateTimeOffset SignedDate, string? AppAccountToken = null);
