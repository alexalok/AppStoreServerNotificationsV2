using System.Text.Json;
using AppStoreServerNotificationsV2.Models;
using System.Text.Json.Serialization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace AppStoreServerNotificationsV2.Converters;

class JWSTransactionDecodedPayloadConverter : JsonConverter<JWSTransactionDecodedPayload>
{
    public override JWSTransactionDecodedPayload? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var rawJws = reader.GetString();
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(rawJws);
        var payloadJson = Base64UrlEncoder.Decode(jwt.RawPayload);
        var opt = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            NumberHandling =
                JsonNumberHandling.AllowReadingFromString
        };
        opt.Converters.Add(new TimestampToDateTimeOffsetConverter());
        var payload = JsonSerializer.Deserialize<JWSTransactionDecodedPayload>(payloadJson, opt);
        return payload;
    }

    public override void Write(Utf8JsonWriter writer, JWSTransactionDecodedPayload value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

}