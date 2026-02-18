using System.Text.Json.Serialization;

namespace AppStoreServerNotificationsV2.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RevocationType
{
    REFUND_FULL = 0,
    REFUND_PRORATED = 1,
    FAMILY_REVOKE = 2
}
