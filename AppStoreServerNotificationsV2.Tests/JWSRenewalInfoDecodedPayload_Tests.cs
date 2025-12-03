using System.Text.Json;
using AppStoreServerNotificationsV2.Converters;
using AppStoreServerNotificationsV2.Models;
using Xunit;

namespace AppStoreServerNotificationsV2.Tests;

public class JWSRenewalInfoDecodedPayload_Tests
{
    [Fact]
    public void JWSRenewalInfoDecodedPayload_Deserializes_Successfully()
    {
        var json = File.ReadAllText("Payloads/JWSRenewalInfoDecodedPayload.json");
        // Arrange
        var expectedPayload = new JWSRenewalInfoDecodedPayload(
            "com.example.autorenew",
            1,
            "Production",
            2,
            DateTimeOffset.FromUnixTimeMilliseconds(1624446641000),
            true,
            "offer_123",
            1,
            "1000000123456789",
            0,
            "com.example.product",
            DateTimeOffset.FromUnixTimeMilliseconds(1624446641000),
            DateTimeOffset.FromUnixTimeMilliseconds(1624446641000), 
            DateTimeOffset.FromUnixTimeMilliseconds(1624446641000),
            "fd12746f-2d3a-46c8-bff8-55b75ed06aca"
        );

        // Act
        var actualPayload = JsonSerializer.Deserialize<JWSRenewalInfoDecodedPayload>(json, JWSTransactionDecodedPayloadConverter.JsonSerializerOptions)!;

        // Assert
        Assert.Equal(expectedPayload.AutoRenewProductId, actualPayload.AutoRenewProductId);
        Assert.Equal(expectedPayload.AutoRenewStatus, actualPayload.AutoRenewStatus);
        Assert.Equal(expectedPayload.Environment, actualPayload.Environment);
        Assert.Equal(expectedPayload.ExpirationIntent, actualPayload.ExpirationIntent);
        Assert.Equal(expectedPayload.GracePeriodExpiresDate, actualPayload.GracePeriodExpiresDate);
        Assert.Equal(expectedPayload.IsInBillingRetryPeriod, actualPayload.IsInBillingRetryPeriod);
        Assert.Equal(expectedPayload.OfferIdentifier, actualPayload.OfferIdentifier);
        Assert.Equal(expectedPayload.OfferType, actualPayload.OfferType);
        Assert.Equal(expectedPayload.OriginalTransactionId, actualPayload.OriginalTransactionId);
        Assert.Equal(expectedPayload.PriceIncreaseStatus, actualPayload.PriceIncreaseStatus);
        Assert.Equal(expectedPayload.ProductId, actualPayload.ProductId);
        Assert.Equal(expectedPayload.RecentSubscriptionStartDate, actualPayload.RecentSubscriptionStartDate);
        Assert.Equal(expectedPayload.RenewalDate, actualPayload.RenewalDate);
        Assert.Equal(expectedPayload.SignedDate, actualPayload.SignedDate);
        Assert.Equal(expectedPayload.AppAccountToken, actualPayload.AppAccountToken);
    }
}