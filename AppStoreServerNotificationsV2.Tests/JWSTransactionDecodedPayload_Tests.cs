using System.Text.Json;
using AppStoreServerNotificationsV2.Converters;
using AppStoreServerNotificationsV2.Models;
using Xunit;

namespace AppStoreServerNotificationsV2.Tests;
public class JWSTransactionDecodedPayload_Tests
{
    [Fact]
    public void JWSTransactionDecodedPayload_With_OfferType_Deserializes_Successfully()
    {
        // Arrange
        var json = File.ReadAllText("Payloads/JWSTransactionDecodedPayload_With_OfferType.json");

        // Act
        var payload = JsonSerializer.Deserialize<JWSTransactionDecodedPayload>(json, JWSTransactionDecodedPayloadConverter.JsonSerializerOptions)!;

        // Assert
        Assert.Equal(OfferType.PromotionalOffer, payload.OfferType);
        Assert.Equal("basic_subscription_1_month", payload.ProductId);
        Assert.Equal(1000000831360853, payload.TransactionId);
    }
}
