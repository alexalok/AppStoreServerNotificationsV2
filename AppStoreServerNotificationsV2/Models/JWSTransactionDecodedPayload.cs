﻿namespace AppStoreServerNotificationsV2.Models;

public record JWSTransactionDecodedPayload(DateTimeOffset PurchaseDate, DateTimeOffset ExpiresDate, long OriginalTransactionId);