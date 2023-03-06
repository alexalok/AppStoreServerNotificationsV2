using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using AppStoreServerNotificationsV2.Models;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Xunit;

namespace AppStoreServerNotificationsV2.Tests
{
    public class ResponseBodyV2_Tests
    {
        public ResponseBodyV2_Tests()
        {
            IdentityModelEventSource.ShowPII = true;
        }

        [Fact]
        public async void Ensure_Decode_Decodes()
        {
            // Arrange
            var contents = await File.ReadAllTextAsync("Payloads/Sandbox_Resubscription.json");
            var payload = JsonSerializer.Deserialize<ResponseBodyV2>(contents);

            // Act
            var decoded = payload!.Decode();

            // Assert
            Assert.Equal("com.example.app", decoded.Data.BundleId);
            Assert.Equal(new DateTimeOffset(637767355230000000, TimeSpan.Zero), decoded.Data.SignedTransactionInfo.OriginalPurchaseDate);
            Assert.Equal(new DateTimeOffset(637777503980000000, TimeSpan.Zero), decoded.Data.SignedTransactionInfo.PurchaseDate);
        }
    }
}