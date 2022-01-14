using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace AppStoreServerNotificationsV2.Models;

public record ResponseBodyV2([property: JsonPropertyName("signedPayload")] string SignedPayload)
{
    public ResponseBodyV2DecodedPayload Decode()
    {
        var opt = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };
        opt.Converters.Add(new JsonStringEnumConverter());

        var handler = new JwtSecurityTokenHandler();
        var outerJwt = handler.ReadJwtToken(SignedPayload);

        var payloadJson = Base64UrlEncoder.Decode(outerJwt.RawPayload);
        var payload = JsonSerializer.Deserialize<ResponseBodyV2DecodedPayload>(payloadJson, opt);

        return payload!;
    }
}