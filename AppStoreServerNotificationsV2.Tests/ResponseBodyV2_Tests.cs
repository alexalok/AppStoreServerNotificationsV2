using System.Text.Json;
using AppStoreServerNotificationsV2.Models;
using Xunit;

namespace AppStoreServerNotificationsV2.Tests
{
    public class ResponseBodyV2_Tests
    {
        [Fact]
        public void Ensure_Decode_Decodes_Sandbox_Resubscription()
        {
            // Arrange
            var contents = File.ReadAllText("Payloads/Sandbox_Resubscription.json");
            var payload = JsonSerializer.Deserialize<ResponseBodyV2>(contents);

            // Act
            var decoded = payload!.Decode();

            // Assert
            Assert.Equal("com.example.app", decoded.Data.BundleId);
            Assert.Equal(new DateTimeOffset(637767355230000000, TimeSpan.Zero), decoded.Data.SignedTransactionInfo.OriginalPurchaseDate);
            Assert.Equal(new DateTimeOffset(637777503980000000, TimeSpan.Zero), decoded.Data.SignedTransactionInfo.PurchaseDate);
        }

        [Fact]
        public void Ensure_Decode_Decodes_Sandbox_Trial()
        {
            // Arrange
            var contents = File.ReadAllText("Payloads/Sandbox_Trial.json");
            var payload = JsonSerializer.Deserialize<ResponseBodyV2>(contents);

            // Act
            var decoded = payload!.Decode();

            // Assert
            Assert.Equal("com.example.app", decoded.Data.BundleId);
        }
    }
}