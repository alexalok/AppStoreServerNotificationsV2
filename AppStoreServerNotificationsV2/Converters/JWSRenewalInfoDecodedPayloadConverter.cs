using System.Text.Json;
using System.Text.Json.Serialization;
using AppStoreServerNotificationsV2.Models;
using JWT.Builder;

namespace AppStoreServerNotificationsV2.Converters;

class JWSRenewalInfoDecodedPayloadConverter : JsonConverter<JWSRenewalInfoDecodedPayload>
{
    internal static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        Converters = { new TimestampToDateTimeOffsetConverter() }
    };

    static readonly JwtBuilder JwtReader = JwtBuilder.Create().DoNotVerifySignature();

    public override JWSRenewalInfoDecodedPayload? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var rawJws = reader.GetString();
        var payloadJson = JwtReader.Decode(rawJws);
        var payload = JsonSerializer.Deserialize<JWSRenewalInfoDecodedPayload>(payloadJson, JsonSerializerOptions);
        return payload;
    }

    public override void Write(Utf8JsonWriter writer, JWSRenewalInfoDecodedPayload value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}