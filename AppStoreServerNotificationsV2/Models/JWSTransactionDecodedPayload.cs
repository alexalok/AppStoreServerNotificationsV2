namespace AppStoreServerNotificationsV2.Models;

public record JWSTransactionDecodedPayload(
    DateTimeOffset OriginalPurchaseDate, DateTimeOffset PurchaseDate, DateTimeOffset ExpiresDate,
    long OriginalTransactionId, OfferType? OfferType);