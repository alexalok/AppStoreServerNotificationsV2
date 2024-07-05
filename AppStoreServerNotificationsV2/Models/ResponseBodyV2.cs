using System.Text.Json;
using System.Text.Json.Serialization;
using JWT.Builder;

namespace AppStoreServerNotificationsV2.Models;

public record ResponseBodyV2([property: JsonPropertyName("signedPayload")] string SignedPayload)
{
    static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter() },
    };

    static readonly JwtBuilder JwtReader = JwtBuilder.Create().DoNotVerifySignature();


    public ResponseBodyV2DecodedPayload Decode()
    {
        var rawPayload = GetDecodedRawPayload();
        var payload = JsonSerializer.Deserialize<ResponseBodyV2DecodedPayload>(rawPayload, SerializerOptions);
        return payload!;
    }

    public string GetDecodedRawPayload()
    {
        var payloadJson = JwtReader.Decode(SignedPayload);
        return payloadJson;
    }
}