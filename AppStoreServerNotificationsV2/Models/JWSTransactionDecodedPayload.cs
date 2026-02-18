namespace AppStoreServerNotificationsV2.Models;

public record JWSTransactionDecodedPayload(
    DateTimeOffset OriginalPurchaseDate, DateTimeOffset PurchaseDate, DateTimeOffset ExpiresDate,
    long OriginalTransactionId, OfferType? OfferType, string ProductId, long TransactionId, 
    long Price, string Currency, string Storefront, string Environment, bool IsUpgraded, string StorefrontId, 
    string InAppOwnershipType, string? AppAccountToken, string? AppTransactionId,
    DateTimeOffset? RevocationDate, int? RevocationPercentage, RevocationType? RevocationType);