using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using System.Text.Json.Serialization;
using AppStoreServerNotificationsV2.Models;
using Microsoft.IdentityModel.Tokens;

namespace AppStoreServerNotificationsV2.Converters;

class JWSRenewalInfoDecodedPayloadConverter : JsonConverter<JWSRenewalInfoDecodedPayload>
{
    internal static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        Converters = { new TimestampToDateTimeOffsetConverter() }
    };

    public override JWSRenewalInfoDecodedPayload? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var rawJws = reader.GetString();
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(rawJws);
        var payloadJson = Base64UrlEncoder.Decode(jwt.RawPayload);
        var payload = JsonSerializer.Deserialize<JWSRenewalInfoDecodedPayload>(payloadJson, JsonSerializerOptions);
        return payload;
    }
    
    public override void Write(Utf8JsonWriter writer, JWSRenewalInfoDecodedPayload value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}