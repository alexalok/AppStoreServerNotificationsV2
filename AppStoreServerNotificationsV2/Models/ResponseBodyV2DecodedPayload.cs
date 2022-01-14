namespace AppStoreServerNotificationsV2.Models;

public record ResponseBodyV2DecodedPayload(NotificationType NotificationType, NotificationSubtype Subtype, Guid NotificationUuid, Version Version, Data Data);