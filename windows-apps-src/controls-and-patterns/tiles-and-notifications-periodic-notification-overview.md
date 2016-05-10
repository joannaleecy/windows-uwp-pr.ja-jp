---
author: mijacobs
Description: Periodic notifications, which are also called polled notifications, update tiles and badges at a fixed interval by downloading content from a cloud service.
title: Periodic notification overview
ms.assetid: 1EB79BF6-4B94-451F-9FAB-0A1B45B4D01C
label: TBD
template: detail.hbs
---

# Periodic notification overview





Periodic notifications, which are also called polled notifications, update tiles and badges at a fixed interval by downloading content from a cloud service. To use periodic notifications, your client app code needs to provide two pieces of information:

-   The Uniform Resource Identifier (URI) of a web location for Windows to poll for tile or badge updates for your app
-   How often that URI should be polled

Periodic notifications enable your app to get live tile updates with minimal cloud service and client investment. Periodic notifications are a good delivery method for distributing the same content to a wide audience.

**Note**   You can learn more by downloading the [Push and periodic notifications sample](http://go.microsoft.com/fwlink/p/?linkid=231476) for Windows 8.1 and re-using its source code in your Windows 10 app.

 

## <span id="How_it_works"></span><span id="how_it_works"></span><span id="HOW_IT_WORKS"></span>How it works


Periodic notifications require that your app hosts a cloud service. The service will be polled periodically by all users who have the app installed. At each polling interval, such as once an hour, Windows sends an HTTP GET request to the URI, downloads the requested tile or badge content (as XML) that is supplied in response to the request, and displays the content on the app's tile.

Note that periodic updates cannot be used with toast notifications. Toast is best delivered through [scheduled](https://msdn.microsoft.com/library/windows/apps/hh465417) or [push](https://msdn.microsoft.com/library/windows/apps/xaml/hh868252) notifications.

## <span id="URI_location_and_XML_content"></span><span id="uri_location_and_xml_content"></span><span id="URI_LOCATION_AND_XML_CONTENT"></span>URI location and XML content


Any valid HTTP or HTTPS web address can be used as the URI to be polled.

The cloud server's response includes the downloaded content. The content returned from the URI must conform to the [Tile](tiles-and-notifications-adaptive-tiles-schema.md) or [Badge](https://msdn.microsoft.com/library/windows/apps/br212851) XML schema specification, and must be UTF-8 encoded. You can use defined HTTP headers to specify the [expiration time](#expiry) or [tag](#taggo) for the notification.

## <span id="Polling_Behavior"></span><span id="polling_behavior"></span><span id="POLLING_BEHAVIOR"></span>Polling Behavior


Call one of these methods to begin polling:

-   [**StartPeriodicUpdate**](https://msdn.microsoft.com/library/windows/apps/hh701684) (Tile)
-   [**StartPeriodicUpdate**](https://msdn.microsoft.com/library/windows/apps/hh701611) (Badge)
-   [**StartPeriodicUpdateBatch**](https://msdn.microsoft.com/library/windows/apps/hh967945) (Tile)

When you call one of these methods, the URI is immediately polled and the tile or badge is updated with the received contents. After this initial poll, Windows continues to provide updates at the requested interval. Polling continues until you explicitly stop it (with [**TileUpdater.StopPeriodicUpdate**](https://msdn.microsoft.com/library/windows/apps/hh701697)), your app is uninstalled, or, in the case of a secondary tile, the tile is removed. Otherwise, Windows continues to poll for updates to your tile or badge even if your app is never launched again.

### <span id="The_recurrence_interval"></span><span id="the_recurrence_interval"></span><span id="THE_RECURRENCE_INTERVAL"></span>The recurrence interval

You specify the recurrence interval as a parameter of the methods listed above. Note that while Windows makes a best effort to poll as requested, the interval is not precise. The requested poll interval can be delayed by up to 15 minutes at the discretion of Windows.

### <span id="The_start_time"></span><span id="the_start_time"></span><span id="THE_START_TIME"></span>The start time

You optionally can specify a particular time of day to begin polling. Consider an app that changes its tile content just once a day. In such a case, we recommend that you poll close to the time that you update your cloud service. For example, if a daily shopping site publishes the day's offers at 8 AM, poll for new tile content shortly after 8 AM.

If you provide a start time, the first call to the method polls for content immediately. Then, regular polling starts within 15 minutes of the provided start time.

### <span id="Automatic_retry_behavior"></span><span id="automatic_retry_behavior"></span><span id="AUTOMATIC_RETRY_BEHAVIOR"></span>Automatic retry behavior

The URI is polled only if the device is online. If the network is available but the URI cannot be contacted for any reason, this iteration of the polling interval is skipped, and the URI will be polled again at the next interval. If the device is in an off, sleep, or hibernated state when a polling interval is reached, the URI is polled when the device returns from its off or sleep state.

## <span id="expiry"></span><span id="EXPIRY"></span>Expiration of tile and badge notifications


By default, periodic tile and badge notifications expire three days from the time they are downloaded. When a notification expires, the content is removed from the badge, tile, or queue and is no longer shown to the user. It is a best practice to set an explicit expiration time on all periodic tile and badge notifications, using a time that makes sense for your app or notification, to ensure that the content does not persist longer than it is relevant. An explicit expiration time is essential for content with a defined life span. It also assures the removal of stale content if your cloud service becomes unreachable, or if the user disconnects from the network for an extended period of time.

Your cloud service sets an expiration date and time for a notification by including the X-WNS-Expires HTTP header in the response payload. The X-WNS-Expires HTTP header conforms to the [HTTP-date format](http://go.microsoft.com/fwlink/p/?linkid=253706). For more information, see [**StartPeriodicUpdate**](https://msdn.microsoft.com/library/windows/apps/hh701684) or [**StartPeriodicUpdateBatch**](https://msdn.microsoft.com/library/windows/apps/hh967945).

For example, during a stock market's active trading day, you can set the expiration for a stock price update to twice that of your polling interval (such as one hour after receipt if you are polling every half-hour). As another example, a news app might determine that one day is an appropriate expiration time for a daily news tile update.

## <span id="taggo"></span><span id="TAGGO"></span>Periodic notifications in the notification queue


You can use periodic tile updates with [notification cycling](https://msdn.microsoft.com/library/windows/apps/hh781199). By default, a tile on the Start screen shows the content of a single notification until it is replaced by a new notification. When you enable cycling, up to five notifications are maintained in a queue and the tile cycles through them.

If the queue has reached its capacity of five notifications, the next new notification replaces the oldest notification in the queue. However, by setting tags on your notifications, you can affect the queue's replacement policy. A tag is an app-specific, case-insensitive string of up to 16 alphanumeric characters, specified in the [X-WNS-Tag](https://msdn.microsoft.com/library/windows/apps/hh465435.aspx#pncodes_x_wns_tag) HTTP header in the response payload. Windows compares the tag of an incoming notification with the tags of all notifications already in the queue. If a match is found, the new notification replaces the queued notification with the same tag. If no match is found, the default replacement rule is applied and the new notification replaces the oldest notification in the queue.

You can use notification queuing and tagging to implement a variety of rich notification scenarios. For example, a stock app could send five notifications, each about a different stock and each tagged with a stock name. This prevents the queue from ever containing two notifications for the same stock, the older of which is out of date.

For more information, see [Using the notification queue](https://msdn.microsoft.com/library/windows/apps/hh781199).

### <span id="Enabling_the_notification_queue"></span><span id="enabling_the_notification_queue"></span><span id="ENABLING_THE_NOTIFICATION_QUEUE"></span>Enabling the notification queue

To implement a notification queue, first enable the queue for your tile (see [How to use the notification queue with local notifications](https://msdn.microsoft.com/library/windows/apps/hh465429)). The call to enable the queue needs to be done only once in your app's lifetime, but there is no harm in calling it each time your app is launched.

### <span id="Polling_for_more_than_one_notification_at_a_time"></span><span id="polling_for_more_than_one_notification_at_a_time"></span><span id="POLLING_FOR_MORE_THAN_ONE_NOTIFICATION_AT_A_TIME"></span>Polling for more than one notification at a time

You must provide a unique URI for each notification that you'd like Windows to download for your tile. By using the [**StartPeriodicUpdateBatch**](https://msdn.microsoft.com/library/windows/apps/hh967945) method, you can provide up to five URIs at once for use with the notification queue. Each URI is polled for a single notification payload, at or near the same time. Each polled URI can return its own expiration and tag value.

## <span id="related_topics"></span>Related topics


* [Guidelines for periodic notifications](https://msdn.microsoft.com/library/windows/apps/hh761461)
* [How to set up periodic notifications for badges](https://msdn.microsoft.com/library/windows/apps/hh761476)
* [How to set up periodic notifications for tiles](https://msdn.microsoft.com/library/windows/apps/hh761476)
 

 




