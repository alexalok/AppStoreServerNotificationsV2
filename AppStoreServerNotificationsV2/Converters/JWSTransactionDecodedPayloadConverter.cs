using System.Text.Json;
using System.Text.Json.Serialization;
using AppStoreServerNotificationsV2.Models;
using JWT.Builder;

namespace AppStoreServerNotificationsV2.Converters;

class JWSTransactionDecodedPayloadConverter : JsonConverter<JWSTransactionDecodedPayload>
{
    internal static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        Converters = { new TimestampToDateTimeOffsetConverter() }
    };

    static readonly JwtBuilder JwtReader = JwtBuilder.Create().DoNotVerifySignature();

    public override JWSTransactionDecodedPayload? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var rawJws = reader.GetString();
        var payloadJson = JwtReader.Decode(rawJws);
        var payload = JsonSerializer.Deserialize<JWSTransactionDecodedPayload>(payloadJson, JsonSerializerOptions);
        return payload;
    }

    public override void Write(Utf8JsonWriter writer, JWSTransactionDecodedPayload value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}