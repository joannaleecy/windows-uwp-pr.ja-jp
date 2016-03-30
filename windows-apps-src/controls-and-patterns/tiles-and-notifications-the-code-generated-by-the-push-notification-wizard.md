---
Xxxxxxxxxxx: Xx xxxxx x xxxxxx xx Xxxxxx Xxxxxx, xxx xxx xxxxxxxx xxxx xxxxxxxxxxxxx xxxx x xxxxxx xxxxxxx xxxx xxx xxxxxxx xxxx Xxxxx Xxxxxx Xxxxxxxx.
xxxxx: Xxxx xxxxxxxxx xx xxx xxxx xxxxxxxxxxxx xxxxxx
xx.xxxxxxx: YYYXYYXY-YXXX-YYYY-XYXY-XYYXXYYYYYYY
xxxxx: XXX
xxxxxxxx: xxxxxx.xxx
---

# Xxxx xxxxxxxxx xx xxx xxxx xxxxxxxxxxxx xxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xx xxxxx x xxxxxx xx Xxxxxx Xxxxxx, xxx xxx xxxxxxxx xxxx xxxxxxxxxxxxx xxxx x xxxxxx xxxxxxx xxxx xxx xxxxxxx xxxx Xxxxx Xxxxxx Xxxxxxxx. Xxx Xxxxxx Xxxxxx xxxxxx xxxxxxxxx xxxx xx xxxx xxx xxx xxxxxxx. Xxxx xxxxx xxxxxxxx xxx xxx xxxxxx xxxxxxxx xxxx xxxxxxx, xxxx xxx xxxxxxxxx xxxx xxxx, xxx xx xxx xxxx xxxx, xxx xxxx xxx xxx xx xxxx xx xxx xxx xxxx xxx xx xxxx xxxxxxxxxxxxx. Xxx [Xxxxxxx Xxxx Xxxxxxxxxxxx Xxxxxxxx (XXX) xxxxxxxx](tiles-and-notifications-windows-push-notification-services--wns--overview.md).

## <span id="How_the_wizard_modifies_your_project">
            </span>
            <span id="how_the_wizard_modifies_your_project">
            </span>
            <span id="HOW_THE_WIZARD_MODIFIES_YOUR_PROJECT">
            </span>Xxx xxx xxxxxx xxxxxxxx xxxx xxxxxxx


Xxx xxxx xxxxxxxxxxxx xxxxxx xxxxxxxx xxxx xxxxxxx xx xxx xxxxxxxxx xxxx:

-   Xxxx x xxxxxxxxx xx Xxxxxx Xxxxxxxx Xxxxxxx Xxxxxx (XxxxxxXxxxxxxxXxxxxxxXxxxxx.xxx). Xxx xxxxxxxxxx xx XxxxXxxxxx xxxxxxxx.
-   Xxxx x xxxx xx x xxxxxxxxx xxxxx xxxxxxxx, xxx xxxxx xxx xxxx xxxx.xxxxxxxx.xx, xxxx.xxxxxxxx.xx, xxxx.xxxxxxxx.xxx, xx xxxx.xxxxxxxx.xx.
-   Xxxxxxx x xxxxxxxx xxxxx xx xxx xxxxxxxx xxxxxx xxx xxx xxxxxx xxxxxxx. Xxx xxxxx xxxxxxxx xxxxxxxxxxx xxxx'x xxxxxxxx xx xxxx xxxx xxxxxxxxxxxxx xx xxx xxxxxxxxx.
-   Xxxxxxx xxxxxxx xxx xxxx xxxxxxxxx: xxxxxx, xxxxxx, xxxx xxx xxxxxx.
-   Xxxxxxx x xxxxxx xxxx x xxxxxx XXX, xxxxxxxxxxxxxx.xx, xxxxx xxxxx x xxxx xxxxxxxxxxxx xx xxx xxxxxxx.
-   Xxxx x xxxxxxxxxxx xx xxxx Xxx.xxxx.xx, Xxx.xxxx.xx, xx Xxx.xxxx.xxx xxxx, xx xxxx x xxxxxxxxxxx xx x xxx xxxx, xxxxxxx.xx, xxx XxxxXxxxxx xxxxxxxx. Xxx xxxxxxxxxxx xxxxxxxx x XxxxxxXxxxxxxXxxxxx xxxxxx, xxxxx xxxxxxxx xxx xxxxxxxxxxx xxxx'x xxxxxxxx xx xxxxxxx xx xxx xxxxxx xxxxxxx. Xxx xxx xxxxxx xxxx XxxxxxXxxxxxxXxxxxx xxxxxx, xxxxx xx xxxxx *XxXxxxxxxXxxx*Xxxxxx, xxxx xxx xxxx xx xxxx xxx xx xxxxx xxx xxxx Xxx.*XxXxxxxxxXxxx*Xxxxxx.

Xxx xxxxxxxx.xx xxxx xxxxxxxx xxx xxxxxxxxx xxxx:

```JavaScript
var <mobile-service-name>Client = new Microsoft.WindowsAzure.MobileServices.MobileServiceClient(
                "https://<mobile-service-name>.azure-mobile.net/",
                "<your client secret>");
```

## <span id="Registration_for_push_notifications">
            </span>
            <span id="registration_for_push_notifications">
            </span>
            <span id="REGISTRATION_FOR_PUSH_NOTIFICATIONS">
            </span>Xxxxxxxxxxxx xxx xxxx xxxxxxxxxxxxx


Xx xxxx.xxxxxxxx.\*, xxx XxxxxxXxxxxxx xxxxxx xxxxxxxxx xxx xxxxxx xx xxxxxxx xxxx xxxxxxxxxxxxx. Xxx Xxxxx xxxxxx xxxxxxxxx xxxxxxxxx xx xxxx xxx xxx xxxxxxxx xxx xxxx xxxxxxxxxxxx xxxxxxx. Xxx [**XxxxXxxxxxxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241284).

Xxx xxxxxx xxxx xx xxxxxxx xxx xxxx xxx XxxxXxxxxx xxxxxxx xxx xxx .XXX xxxxxxx. Xx xxxxxxx, xxxx xxx xxx xxxx xxxxxxxxxxxxx xxx x XxxxXxxxxx xxxxxxx xxxxxxx, x xxxxxx xxxx xx xxxxxxXxxXxxxx xxxxxx XXX xx xxxxxxxx xxxx xxx XxxxxxXxxxxxx xxxxxx.

```CSharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;

namespace App2
{
    internal class mymobileservice1234Push
    {
        public async static void UploadChannel()
        {
            var channel = await Windows.Networking.PushNotifications.PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();

            try
            {
                await App.mymobileservice1234Client.GetPush().RegisterNativeAsync(channel.Uri);
                await App.mymobileservice1234Client.InvokeApiAsync("notifyAllUsers");
            }
            catch (Exception exception)
            {
                HandleRegisterException(exception);
            }
        }

        private static void HandleRegisterException(Exception exception)
        {
            
        }
    }
}
```

```VisualBasic
Imports Microsoft.WindowsAzure.MobileServices
Imports Newtonsoft.Json.Linq

Friend Class mymobileservice1234Push
    Public Shared Async Sub UploadChannel()
        Dim channel = Await Windows.Networking.PushNotifications.PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync()

        Try
            Await App.mymobileservice1234Client.GetPush().RegisterNativeAsync(channel.Uri)
            Await App.mymobileservice1234Client.GetPush().RegisterNativeAsync(channel.Uri, New String() {"tag1", "tag2"})
            Await App.mymobileservice1234Client.InvokeApiAsync("notifyAllUsers")
        Catch exception As Exception
            HandleRegisterException(exception)
        End Try
    End Sub

    Private Shared Sub HandleRegisterException(exception As Exception)

    End Sub
End Class
```

```ManagedCPlusPlus
#include "pch.h"
#include "services\mobile services\mymobileservice1234\mymobileservice1234Push.h"

using namespace AzureMobileHelper;

using namespace web;
using namespace concurrency;

using namespace Windows::Networking::PushNotifications;

void mymobileservice1234Push::UploadChannel()
{
    create_task(PushNotificationChannelManager::CreatePushNotificationChannelForApplicationAsync()).
    then([] (PushNotificationChannel^ newChannel) 
    {
        return mymobileservice1234MobileService::GetClient().get_push().register_native(newChannel-&amp;gt;Uri-&amp;gt;Data());
    }).then([]()
    {
        return mymobileservice1234MobileService::GetClient().invoke_api(L"notifyAllUsers");
    }).then([](task&amp;lt;json::value&amp;gt; result)
    {
        try
        {
            result.wait();
        }
        catch(...)
        {
            HandleExceptionsComingFromTheServer();
        }
    });
}

void mymobileservice1234Push::HandleExceptionsComingFromTheServer()
{
}
```

```JavaScript
(function () {
    "use strict";

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.addEventListener("activated", function (args) {
        if (args.detail.kind == activation.ActivationKind.launch) {
            Windows.Networking.PushNotifications.PushNotificationChannelManager.createPushNotificationChannelForApplicationAsync()
                .then(function (channel) {
                    mymobileserviceclient1234Client.push.registerNative(channel.Uri, new Array("tag1", "tag2"))
                    return mymobileservice1234Client.push.registerNative(channel.uri);
                })
                .done(function (registration) {
                    return mymobileservice1234Client.invokeApi("notifyAllUsers");
                }, function (error) {
                    // Error

                });
        }
    });
})();
```

Xxxx xxxxxxxxxxxx xxxx xxxxxxx x xxx xx xxxxxxxx xxxxxxxxxxxxx xx x xxxxxx xx xxxxxxx. Xxx xxx xxx xxx xxx xxx xxxxxxxxXxxxxx xxxxxx (xx XxxxxxxxXxxxxxXxxxx) xxxxxx xx xxxxxx xxxxxxxx xxx xxx xxxx xxxxxxxxxxxxx xxxxxxx xxxxxxxxxx xxxx, xx xxx xxx xxxxxxxx xxxx xxxx xx xxxxxxxxx xxx xxxxxx xxxxxxxx, xx xxxxx xx xxxx. Xx xxx xxxxxxxx xxxx xxx xx xxxx xxxx, xxx xxxx xxxxxxx xxxxxxxxxxxxx xxxx xxxxx xxxxx xxxx.

## <span id="Server-side_scripts__JavaScript_backend_only_">
            </span>
            <span id="server-side_scripts__javascript_backend_only_">
            </span>
            <span id="SERVER-SIDE_SCRIPTS__JAVASCRIPT_BACKEND_ONLY_">
            </span>Xxxxxx-xxxx xxxxxxx (XxxxXxxxxx xxxxxxx xxxx)


Xxx xxxxxx xxxxxxxx xxxx xxx xxx XxxxXxxxxx xxxxxxx, xxx xxxxxx-xxxx xxxxxxx xxx xxxx xxxxxx, xxxxxx, xxxx, xx xxxxxx xxxxxxxxxx xxxxx. Xxx xxxxxxx xxx'x xxxxxxxxx xxxxx xxxxxxxxxx, xxx xxxx xxx xxxx x xxxx xxxx xxx xxxxxx xx xxx Xxxxxxx Xxxxxx XXXX XXX xxxxxxxx xxxxx xxxxxx. Xxx xxxxxxx xxxx xxxx xxxxxxx xxxx xxx xxxxxxxxxx xxxxxxxxxx xx xxxxxxx xxxxxxx.xxxxxxx xx xxxxxxx.xxxxxxx xx xxxxx x xxxxxxxx xx xxx xxxxxxx xxxxxxx. Xxx [Xxxxx Xxxxxx Xxxxxxxx XXXX XXX Xxxxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=511139).

X xxxxxxx xx xxxxxxxxx xxx xxxxxxxxx xx xxx xxxxxx-xxxx xxxxxx. Xxx [Xxxxxxxx xxxxx xxxxxxxxxx xx Xxxxx Xxxxxx Xxxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=511140). Xxx x xxxxxxxxx xx xxx xxxxxxxxx xxxxxxxxx, xxx [Xxxxxx Xxxxxxxx xxxxxx xxxxxx xxxxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=257676).

Xxx xxxxxxxxx xxxxxx XXX xxxx xx Xxxxxxxxxxxxxx.xx xx xxxx xxxxxxx:

```JavaScript
exports.post = function(request, response) {
    response.send(statusCodes.OK,{ message : &#39;Hello World!&#39; })
    
    // The following call is for illustration purpose only
    // The call and function body should be moved to a script in your app
    // where you want to send a notification
    sendNotifications(request);
};

// The following code should be moved to appropriate script in your app where notification is sent
function sendNotifications(request) {
    var payload = &#39;<?xml version="1.0" encoding="utf-8"?><toast><visual><binding template="ToastText01">&#39; +
        &#39;<text id="1">Sample Toast</text></binding></visual></toast>&#39;;
    var push = request.service.push; 
    push.wns.send(null,
        payload,
        &#39;wns/toast&#39;, {
            success: function (pushResponse) {
                console.log("Sent push:", pushResponse);
            }
        });
}
```

Xxx xxxxXxxxxxxxxxxxx xxxxxxxx xxxxx x xxxxxx xxxxxxxxxxxx xx x xxxxx xxxxxxxxxxxx. Xxx xxx xxxx xxx xxxxx xxxxx xx xxxx xxxxxxxxxxxxx.

**Xxx**  Xxx xxxxxxxxxxx xxxxx xxx xx xxx xxxx xxxxx xxxxxxx xxxxxxx, xxx [Xxxxxxxx XxxxxxxXxxxx xxx xxxxxx-xxxx XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=309275).

 

## <span id="Push_notification_types">
            </span>
            <span id="push_notification_types">
            </span>
            <span id="PUSH_NOTIFICATION_TYPES">
            </span>Xxxx xxxxxxxxxxxx xxxxx


Xxxxxxx xxxxxxxx xxxxxxxxxxxxx xxxx xxxx'x xxxx xxxxxxxxxxxxx. Xxx xxxxxxx xxxxxxxxxxx xxxxx xxxxxxxxxxxxx, xxx [Xxxxxxxxxx xxxxxxxxx, xxxxxxxx, xxx xxxx xxxxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/hh761484).

Xxxxx xxxxxxxxxxxxx xxx xxxx xx xxx, xxx xxx xxx xxxxxx xx xxxxxxx xx xxx Xxxxxx.xx xxxx xx xxx xxxxxxx'x xxxxx xxxx'x xxxxxxxxx xxx xxx. Xx xxx xxxx xx xxx xxxx xx xxxxx xxxxxxxxxxxxx, xxx xxxx xxxxxx xx XXX xxxxxxxx xxx xxx xxxx xxx xxxxx, xxx xxx xxxx xxxxxxx xxx xxxxxxxx xx xxxxxxxx xxxxxxxxxxx xx xxx xxxxxxxx. Xxx [Xxxxxxx xxxx xxxxx, xxxxxx, xxx xxxxx xxxxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/hh868259).

Xxxxxxx Xxxxxxx xxxxxxxx xx xxxx xxxxxxxxxxxxx, xx xxx xxxxxx xxxx xx xxxxx xxxxxxxxxxxxx xxxx xxx xxx xxx'x xxxxxxx. Xxx xxxxxxx, x xxxx xxxxxxxxxxxx xxxxx xxx x xxxx xxxx xxxx x xxx xxxx xxxxxxx xx xxxxxxxxx xxxx xxxx xxx xxxxx xxxx xxx xxx'x xxxxxxx. Xxxxxxx xxxxxxx x xxxxx xxxxxxxxxxxx xx xxxxxxxxxx x xxxxxxx, xxxx xx xxx xxxxx xxxx xx x xxxx xxxxxxx. Xxxxxxx xxxxxxx x xxxx xx xxxxx xxxxxxxxxxxx xx xxxxxxxx xx xxx'x xxxx xxxx xx xxxxxxx xxx xxxxxx xx xxx xxxx xxxxxxxx. Xx xxxx xxx, xxx xxx xxxxxx xxxxx xx xxxx xxx xx xxxxx xx xxx xxx xxxxxxxxxxx. Xxxx xxx xxx xxxxxxx xxx xxxxxxxxxxxxx xxxx xx'x xxxxxxx, xxx xxx xxx xxx xxxx xx xxxx xxxx xx xxxx xxx. Xx xxxx xxx xxx'x xxxxxxx, xxx xxx xxx xx x xxxxxxxxxx xxxx xx xxxxxxx xxxx xxxxxxxxxxxxx.

Xxx xxxxxx xxx xxxx xxxxxxxxxxxxx xxxxxxxxx xx xxx xxxxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx, xxxxxxx xxxxx xxxxxxxxxxxxx xxx xx x xxxx'x xxxxxxxxx xxx xxx xx xxxxxxxxxxx xx xxxxxxxx. Xxx [Xxxxxxxxxx xxx xxxxxxxxx xxx xxxx xxxxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/hh761462).

Xx xxx'xx xxxxxxxx xxxx xxxxx xxxx xxxx xxxxxxxxxxxxx, xxx xxxxxx xxxx xxxxxx xxx xxxxxxxxxx xx [Xxxxxxxxxx xxx xxxxxxxxx xxx xxxxx xxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/hh465403).

## <span id="Next_steps">
            </span>
            <span id="next_steps">
            </span>
            <span id="NEXT_STEPS">
            </span>Xxxx xxxxx


### <span id="Using_the_Windows_Push_Notification_Services__WNS_">
            </span>
            <span id="using_the_windows_push_notification_services__wns_">
            </span>
            <span id="USING_THE_WINDOWS_PUSH_NOTIFICATION_SERVICES__WNS_">
            </span>Xxxxx xxx Xxxxxxx Xxxx Xxxxxxxxxxxx Xxxxxxxx (XXX)

Xxx xxx xxxx Xxxxxxx Xxxx Xxxxxxxxxxxx Xxxxxxxx (XXX) xxxxxxxx xx Xxxxxx Xxxxxxxx xxxxx'x xxxxxxx xxxxxx xxxxxxxxxxx, xx xxx xxxx xx xxxxx xxxx xxxxxx xxxx xx X# xx Xxxxxx Xxxxx, xx xx xxx xxxxxxx xxxx x xxxxx xxxxxxx xxx xxx xxxx xx xxxx xxxx xxxxxxxxxxxxx xxxx xx. Xx xxxxxxx XXX xxxxxxxx, xxx xxx xxxx xxxx xxxxxxxxxxxxx xxxx xxxx xxx xxxxx xxxxxxx, xxxx xx x xxxxxx xxxx xxxx xxxxxxxx xxxx xxxx x xxxxxxxx xx xxxxxxx xxx xxxxxxx. Xxxx xxxxx xxxxxxx xxxx xxxxxxxxxxxx xxxx XXX xx xxxx xxxx xxxxxxxxxxxxx xx xxxx xxxx. Xxx [Xxx xx xxxxxxxxxxxx xxxx xxx Xxxxxxx Xxxx Xxxxxxxxxxxx Xxxxxxx (XxxxXxxxxx)](https://msdn.microsoft.com/library/windows/apps/hh465407) xx [(X#/X++/XX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh868206).

Xxx xxx xxxx xxxx xxxx xxxxxxxxxxxxx xx xxxxxxx x xxxxxxxxx xxxx xx xxxx xxxxxx xxxxxxx. Xxx [Xxxxxxxx xxxxxxxxx xxxx xx Xxxxxx Xxxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=301694).

**Xxxxxxx**  Xxxx xxx'xx xxx xxx xxxx xxxxxxxxxxxx xxxxxx xxxx, xxx'x xxx xxx xxxxxx x xxxxxx xxxx xx xxx xxxxxxxxxxxx xxxx xxx xxxxxxx xxxxxx xxxxxxx. Xxxxxxx xxx xxxxxx xxxx xxxx xxxx xxx xxxxxxx xxxxxxxxx xxxx xxxx xxxxxxx xx xxxxxxxxxxx xxxxx xx xxx [**XxxxxxXxxxXxxxxxxxxxxxXxxxxxxXxxXxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br241287) xxxxxx, xxxxx xxxxx xx x xxxxxxx xxxxxxxxx. Xx xxx xxxx xx xxxxxxxx xxx xxxx xxxxxxxxxxxxx xxx xxxx xxxx xxx xxxxxx xxxxxxx, xxx xxx xxxxxx xxxx xxx xxxx xxxxxxx xxx xxxxxxxxxxxx xxxx xx xxxxxx xxxx xxxxx xx **XxxxxxXxxxXxxxxxxxxxxxXxxxxxxXxxXxxxxxxxxxxXxxxx** xx xxx xxx xx xxx xxxx xxxx. Xxx xxxxxxx, xxx xxx xxxxxxxxxx xxxx xx xxxxxx xxx xxxxxx-xxxxxxxxx xxxx xx xxxx.xxxxxxxx.\* (xxxxxxxxx xxx xxxx xx **XxxxxxXxxxXxxxxxxxxxxxXxxxxxxXxxXxxxxxxxxxxXxxxx**) xxxxxxx xx xxx XxXxxxxxxx xxxxx, xxx xxx xxxxxxxxx xx xxxx xxxx xxxxxx xx xxxx xxx'x xxxxxxxxxxxx.

 

## <span id="related_topics">
            </span>Xxxxxxx xxxxxx


* [Xxxxxxx Xxxx Xxxxxxxxxxxx Xxxxxxxx (XXX) xxxxxxxx](tiles-and-notifications-windows-push-notification-services--wns--overview.md)
* [Xxx xxxxxxxxxxxx xxxxxxxx](tiles-and-notifications-raw-notification-overview.md)
* [Xxxxxxxxxx xx Xxxxxxx Xxxxx Xxxxxx Xxxxxxxx (XxxxXxxxxx)](https://msdn.microsoft.com/library/windows/apps/dn263160)
* [Xxxxxxxxxx xx Xxxxxxx Xxxxx Xxxxxx Xxxxxxxx (X#/X++/XX)](https://msdn.microsoft.com/library/windows/apps/xaml/dn263175)
* [Xxxxxxxxxx: Xxxxxx xxxx xxxxxxxxxxxxx xxx x xxxxxx xxxxxxx (XxxxXxxxxx)](https://msdn.microsoft.com/library/windows/apps/dn263163)
 

 




<!--HONumber=Mar16_HO1-->
