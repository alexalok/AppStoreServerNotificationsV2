using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;

namespace AppStoreServerNotificationsV2.Models;

public record ResponseBodyV2([property: JsonPropertyName("signedPayload")] string SignedPayload)
{
    static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter() },
    };

    public ResponseBodyV2DecodedPayload Decode()
    {
        var rawPayload = GetDecodedRawPayload();
        var payload = JsonSerializer.Deserialize<ResponseBodyV2DecodedPayload>(rawPayload, SerializerOptions);
        return payload!;
    }

    public string GetDecodedRawPayload()
    {
        var handler = new JwtSecurityTokenHandler();
        var outerJwt = handler.ReadJwtToken(SignedPayload);
        var payloadJson = Base64UrlEncoder.Decode(outerJwt.RawPayload);
        return payloadJson;
    }
}