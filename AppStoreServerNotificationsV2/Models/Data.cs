using System.Text.Json.Serialization;
using AppStoreServerNotificationsV2.Converters;

namespace AppStoreServerNotificationsV2.Models;

public record Data(string BundleId, string BundleVersion, Environment Environment,
    [property: JsonConverter(typeof(JWSTransactionDecodedPayloadConverter))] JWSTransactionDecodedPayload SignedTransactionInfo,
    [property: JsonConverter(typeof(JWSRenewalInfoDecodedPayloadConverter))] JWSRenewalInfoDecodedPayload? SignedRenewalInfo);