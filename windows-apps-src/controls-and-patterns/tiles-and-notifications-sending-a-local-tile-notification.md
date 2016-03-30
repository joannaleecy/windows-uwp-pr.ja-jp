---
Xxxxxxxxxxx: Xxxx xxxxxxx xxxxxxxxx xxx xx xxxx x xxxxx xxxx xxxxxxxxxxxx xx x xxxxxxx xxxx xxx x xxxxxxxxx xxxx xxxxx xxxxxxxx xxxx xxxxxxxxx.
xxxxx: Xxxx x xxxxx xxxx xxxxxxxxxxxx
xx.xxxxxxx: XYYXYYYY-XXXY-YXYY-XYYY-XYYYYXYYXXYX
xxxxx: XXX
xxxxxxxx: xxxxxx.xxx
---

# Xxxx x xxxxx xxxx xxxxxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxxxxx xxx xxxxx xx Xxxxxxx YY xxx xxxxxxx xx xxxx xxx xxxxxxxx, xxxxx xxxxxxxxx xxxxx xxx xxxxxxxxxxxxxxxx xxxxxxx xxx xxxxxxx xx xxxx xxx xxxx. Xxxx xxxxxxx xxxxxxxxx xxx xx xxxx x xxxxx xxxx xxxxxxxxxxxx xx x xxxxxxx xxxx xxx x xxxxxxxxx xxxx xxxxx xxxxxxxx xxxx xxxxxxxxx. (X xxxxx xxxxxxxxxxxx xx xxx xxxx'x xxxx xxxx xxx xxxx xx xxxxxxx xx xxx xxxx'x xxxxxx xx xxxxxx xxxx x xxx xxxxxx.)

![xxxxxxx xxxx xxx xxxx xxxx xxxxxxxxxxxx](images/sending-local-tile-01.png)

**Xxxx**   Xxxxx xxxxx [xxxxxxxx xxxxxxxx xxxxx](tiles-and-notifications-create-adaptive-tiles.md) xxx [xxxxxxxx xxxx xxxxxxxx xxxxxx](tiles-and-notifications-adaptive-tiles-schema.md).

 

## <span id="Install_the_NuGet_package">
            </span>
            <span id="install_the_nuget_package">
            </span>
            <span id="INSTALL_THE_NUGET_PACKAGE">
            </span>Xxxxxxx xxx XxXxx xxxxxxx


Xx xxxxxxxxx xxxxxxxxxx xxx [XxxxxxxxxxxxxXxxxxxxxxx XxXxx xxxxxxx](https://www.nuget.org/packages/NotificationsExtensions.Win10/), xxxxx xxxxxxxxxx xxxxxx xx xxxxxxxxxx xxxx xxxxxxxx xxxx xxxxxxx xxxxxxx xx xxx XXX.

Xxx xxxxxx xxxx xxxxxxxx xx xxxx xxxxxxx xxx xxx X# xxxx xxx [XxxxxxxxxxxxxXxxxxxxxxx](https://github.com/WindowsNotifications/NotificationsExtensions/wiki) XxXxx xxxxxxx xxxxxxxxx. (Xx xxx'x xxxxxx xx xxxxxx xxxx xxx XXX, xxx xxx xxxx xxxx xxxxxxxx xxxxxxx [XxxxxxxxxxxxxXxxxxxxxxx](https://github.com/WindowsNotifications/NotificationsExtensions/wiki) xxxxxx xxx xxx xx xxx xxxxxxx.)

## <span id="Add_namespace_declarations">
            </span>
            <span id="add_namespace_declarations">
            </span>
            <span id="ADD_NAMESPACE_DECLARATIONS">
            </span>Xxx xxxxxxxxx xxxxxxxxxxxx


Xx xxxxxx xxx xxxx XXXx, xxxxxxx xxx [**Xxxxxxx.XX.Xxxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208661) xxxxxxxxx. Xx xxxx xxxxxxxxx xxxxxxxxx xxx **XxxxxxxxxxxxxXxxxxxxxxx.Xxxxx** xxxxxxxxx xx xxxx xxx xxx xxxx xxxxxxxxx xx xxx xxxx xxxxxx XXXx (xxx xxxx xxxxxxx xxx [XxxxxxxxxxxxxXxxxxxxxxx](https://github.com/WindowsNotifications/NotificationsExtensions/wiki) XxXxx xxxxxxx xx xxxxxx xxxxx XXXx).

```
using Windows.UI.Notifications;
using NotificationsExtensions.Tiles; // NotificationsExtensions.Win10
```

## <span id="Create_the_notification_content">
            </span>
            <span id="create_the_notification_content">
            </span>
            <span id="CREATE_THE_NOTIFICATION_CONTENT">
            </span>Xxxxxx xxx xxxxxxxxxxxx xxxxxxx


Xx Xxxxxxx YY, xxxx xxxxxxxx xxx xxxxxxx xxxxx xxxxxxxx xxxx xxxxxxxxx, xxxxx xxxxx xxx xx xxxxxx xxxxxx xxxxxx xxxxxxx xxx xxxx xxxxxxxxxxxxx. (Xx xxxxx xxxx'x xxxxxxxx xxxx xxxxxxxx xxxxx, xxx xxx [Xxxxxx xxxxxxxx xxxxx](tiles-and-notifications-create-adaptive-tiles.md) xxx [Xxxxxxxx xxxx xxxxxxxxx](tiles-and-notifications-adaptive-tiles-schema.md) xxxxxxxx.)

Xxxx xxxx xxxxxxx xxxxxxx xxxxxxxx xxxx xxxxxxx xxx xxxxxx xxx xxxx xxxxx.

```
// In a real app, these would be initialized with actual data
string from = "Jennifer Parker";
string subject = "Photos from our trip";
string body = "Check out these awesome photos I took while in New Zealand!";
 
 
// Construct the tile content
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        TileMedium = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new TileText()
                    {
                        Text = from
                    },
 
                    new TileText()
                    {
                        Text = subject,
                        Style = TileTextStyle.CaptionSubtle
                    },
 
                    new TileText()
                    {
                        Text = body,
                        Style = TileTextStyle.CaptionSubtle
                    }
                }
            }
        },
 
        TileWide = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new TileText()
                    {
                        Text = from,
                        Style = TileTextStyle.Subtitle
                    },
 
                    new TileText()
                    {
                        Text = subject,
                        Style = TileTextStyle.CaptionSubtle
                    },
 
                    new TileText()
                    {
                        Text = body,
                        Style = TileTextStyle.CaptionSubtle
                    }
                }
            }
        }
    }
};
```

Xxx xxxxxxxxxxxx xxxxxxx xxxxx xxxx xxx xxxxxxxxx xxxx xxxxxxxxx xx x xxxxxx xxxx:

![xxxxxxxxxxxx xxxxxxx xx x xxxxxx xxxx](images/sending-local-tile-02.png)

## <span id="Create_the_notification">
            </span>
            <span id="create_the_notification">
            </span>
            <span id="CREATE_THE_NOTIFICATION">
            </span>Xxxxxx xxx xxxxxxxxxxxx


Xxxx xxx xxxx xxxx xxxxxxxxxxxx xxxxxxx, xxx'xx xxxx xx xxxxxx x xxx [**XxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208616). Xxx **XxxxXxxxxxxxxxxx** xxxxxxxxxxx xxxxx x Xxxxxxx Xxxxxxx [**XxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208620) xxxxxx, xxxxx xxx xxx xxxxxx xxxx xxx **XxxxXxxxxxx.XxxXxx** xxxxxx xx xxx'xx xxxxx [XxxxxxxxxxxxxXxxxxxxxxx](https://github.com/WindowsNotifications/NotificationsExtensions/wiki).

Xxxx xxxx xxxxxxx xxxxxxx x xxxxxxxxxxxx xxx x xxx xxxx.

```
// Create the tile notification
var notification = new TileNotification(content.GetXml());
```

## <span id="Set_an_expiration_time_for_the_notification__optional_">
            </span>
            <span id="set_an_expiration_time_for_the_notification__optional_">
            </span>
            <span id="SET_AN_EXPIRATION_TIME_FOR_THE_NOTIFICATION__OPTIONAL_">
            </span>Xxx xx xxxxxxxxxx xxxx xxx xxx xxxxxxxxxxxx (xxxxxxxx)


Xx xxxxxxx, xxxxx xxxx xxx xxxxx xxxxxxxxxxxxx xxx'x xxxxxx, xxxxx xxxx, xxxxxxxx, xxx xxxxxxxxx xxxxxxxxxxxxx xxxxxx xxxxx xxxxx xxxx. Xxxxxxx xxxx xxxxxxx xxxxxxx'x xxxxxxx xxxxxx xxxx xxxxxxxxx, xx'x x xxxx xxxxxxxx xx xxx xx xxxxxxxxxx xxxx xxxx xxxxx xxxxx xxx xxxx xxx, xxxxxxxxxx xx xxxxx xxxx xxx xxxxx xxxxxxxxxxxxx.

Xxxx xxxx xxxxxxx xxxxxxx x xxxxxxxxxxxx xxxx xxxxxxx xxx xxxx xx xxxxxxx xxxx xxx xxxx xxxxx xxx xxxxxxx.

```
tileNotification.ExpirationTime = DateTimeOffset.UtcNow.AddMinutes(10);</code></pre></td>
</tr>
</tbody>
</table>
```

## <span id="Send_the_notification">
            </span>
            <span id="send_the_notification">
            </span>
            <span id="SEND_THE_NOTIFICATION">
            </span>Xxxx xxx xxxxxxxxxxxx


Xxxxxxxx xxxxxxx xxxxxxx x xxxx xxxxxxxxxxxx xx xxxxxx, xxxxxxx xxx xxxxxxxxxxxx xx x xxxxxxx xx xxxxxxxxx xxxx xx x xxx xxxxxxxxx.

**Xxxxxxx xxxx**

Xx xxxx x xxxxxxxxxxxx xx x xxxxxxx xxxx, xxx xxx [**XxxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208622) xx xxxxxx x xxxx xxxxxxx xxx xxx xxxxxxx xxxx, xxx xxxx xxx xxxxxxxxxxxx xx xxxxxxx "Xxxxxx". Xxxxxxxxxx xx xxxxxxx xx'x xxxxxxx, xxxx xxx'x xxxxxxx xxxx xxxxxx xxxxxx, xx xxx xxx xxxx xxxxxxxxxxxxx xx xx xxxx xxxx xx'x xxx xxxxxx. Xx xxx xxxx xxxx xxxx xxxxxxx xxxx xxxxx, xxx xxxxxxxxxxxxx xxxx xxx xxxx xxxx xxxxxx xxxx.

Xxxx xxxx xxxxxxx xxxxx x xxxxxxxxxxxx xx x xxxxxxx xxxx.

<span codelanguage=""></span>
```
<colgroup>
<col width="100%" />
</colgroup>
<tbody>
<tr class="odd">
// And send the notification
TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
```

**Xxxxxxxxx xxxx**

Xx xxxx x xxxxxxxxxxxx xx x xxxxxxxxx xxxx, xxxxx xxxx xxxx xxxx xxx xxxxxxxxx xxxx xxxxxx. Xx xxx xxx xx xxxxxx x xxxx xxxxxxx xxx x xxxxxxxxx xxxx xxxx xxxxx'x xxxxx (xxx xxxxxxx, xx xxx xxxx xxxxxxxx xxx xxxxxxxxx xxxx), xx xxxxxxxxx xxxx xx xxxxxx. Xxx xxx xxx [**XxxxxxxxxXxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242205)(xxxxXx) xx xxxxxxxx xx xxxx xxxxxxxxx xxxx xx xxxxxx, xxx xxxx xxxxxx x xxxx xxxxxxx xxx xxx xxxxxxxxx xxxx xxx xxxx xxx xxxxxxxxxxxx.

Xxxx xxxx xxxxxxx xxxxx x xxxxxxxxxxxx xx x xxxxxxxxx xxxx.

```
// If the secondary tile is pinned
if (SecondaryTile.Exists("MySecondaryTile"))
{
    // Get its updater
    var updater = TileUpdateManager.CreateTileUpdaterForSecondaryTile("MySecondaryTile");
 
    // And send the notification
    updater.Update(notification);
}
```

![xxxxxxx xxxx xxx xxxx xxxx xxxxxxxxxxxx](images/sending-local-tile-01.png)

## <span id="Clear_notifications_on_the_tile__optional_">
            </span>
            <span id="clear_notifications_on_the_tile__optional_">
            </span>
            <span id="CLEAR_NOTIFICATIONS_ON_THE_TILE__OPTIONAL_">
            </span>Xxxxx xxxxxxxxxxxxx xx xxx xxxx (xxxxxxxx)


Xx xxxx xxxxx, xxx xxxxxx xxxxx x xxxxxxxxxxxx xxxx xxx xxxx xxx xxxxxxxxxx xxxx xxxx xxxxxxx. Xxx xxxxxxx, xxxx xxx xxxx xxxxxxxx xxxx xxx, xxx xxxxx xxxx xx xxxxx xxx xxx xxxxxxxxxxxxx xxxx xxx xxxx. Xx xxxx xxxxxxxxxxxxx xxx xxxx-xxxxx, xx xxxxxxxxx xxxx xxx xxx xx xxxxxxxxxx xxxx xx xxx xxxxxxxxxxxx xxxxxxx xx xxxxxxxxxx xxxxxxxx xxx xxxxxxxxxxxx.

Xxxx xxxx xxxxxxx xxxxxx xxx xxxx xxxxxxxxxxxx.

```
TileUpdateManager.CreateTileUpdaterForApplication().Clear();</code></pre></td>
</tr>
</tbody>
</table>
```

Xxx x xxxx xxxx xxx xxxxxxxxxxxx xxxxx xxxxxxx xxx xxxxxxxxxxxxx xx xxx xxxxx, xxxxxxx xxx Xxxxx xxxxxx xxxxxxx xxx xxxxx. Xxx xxx'x, xxxxxxx, xxxxx x xxxxxxxxxxxx xxx xxxx xxx'x xxxxxx; xxxx xxx xxxxx xxx xxxx xxx xxxxx xxxxxxxxxxxxx.

Xxxxxxxx xx xxxx xxxxxxxxxxxxx xxx xxxx xxx xxx xxxxxxxxxxxxx xx xxxxxxx xxxxxxxx xxxxxxxxxxxxx. X xxxxx xxxx xx xxx Xxxxx xxxxxx xxxx xxxxx xxx xxxx xxxxxxx xx xxx xxx xxxxxxxxxxxxx xxxxxxxxxx xxxx xxx xxxx, xxxxxxxx, xx xxxxx. Xxxxxxxxx xxxxxxxxxxxxx xxxx xxxxx'x xxx xxxxxxxx xxx xxx xxxxxxx xx xxxx xxxxxx.

![xxxx xxxx xxxxxxxxxxxx xxx xxxx xxxxx xxxxx xxxxxxx](images/sending-local-tile-03.png)

## <span id="Next_steps">
            </span>
            <span id="next_steps">
            </span>
            <span id="NEXT_STEPS">
            </span>Xxxx xxxxx


**Xxxxx xxx xxxxxxxxxxxx xxxxx**

Xxx xxxx xxx xxxx xxxx xxxx xxxxx xxxx xxxxxx, xxx xxx xxxxxx xxx xxxxxxxxxxxxx xx xxx xxxx xx xxxxxxxx x [xxxxxxxxxxxx xxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/hh868234).

**Xxxxx xxxxxxxxxxxx xxxxxxxx xxxxxxx**

Xxxx xxxxxxx xxxxx xxx xxx xx xxxx xxx xxxx xxxxxx xx x xxxxxxxxxxxx. Xx xxxxxxx xxxxx xxxxxxx xx xxxxxxxxxxxx xxxxxxxx, xxxxxxxxx xxxxxxxxx, xxxxxxxx, xxx xxxx, xxx [Xxxxxxxxxx xxxxxxxxxxxxx](tiles-and-notifications-choosing-a-notification-delivery-method.md).

**XxxXxxxxx xxxxxxxx xxxxxx**

Xx xxx'xx xxx xxxxx [XxxxxxxxxxxxxXxxxxxxxxx](https://github.com/WindowsNotifications/NotificationsExtensions/wiki), xxxx xxxxxxxxxxxx xxxxxxxx xxxxxx xx xxxxxxx xxxxxxxxxxx.

<span codelanguage=""></span>
```
<colgroup>
<col width="100%" />
</colgroup>
<tbody>
<tr class="odd">
public string XmlEncode(string text)
{
    StringBuilder builder = new StringBuilder();
    using (var writer = XmlWriter.Create(builder))
    {
        writer.WriteString(text);
    }

    return builder.ToString();
}
```

## <span id="Code_examples_without_NotificationsExtensions">
            </span>
            <span id="code_examples_without_notificationsextensions">
            </span>
            <span id="CODE_EXAMPLES_WITHOUT_NOTIFICATIONSEXTENSIONS">
            </span>Xxxx xxxxxxxx xxxxxxx XxxxxxxxxxxxxXxxxxxxxxx


Xx xxx xxxxxx xx xxxx xxxx xxx XXX xxxxxxx xx xxx [XxxxxxxxxxxxxXxxxxxxxxx](https://github.com/WindowsNotifications/NotificationsExtensions/wiki) XxXxx xxxxxxx, xxx xxxxx xxxxxxxxx xxxx xxxxxxxx xx xxxxx xxxxx xxxxxxxx xxxxxxxx xx xxxx xxxxxxx. Xxx xxxx xx xxx xxxx xxxxxxxx xxx xx xxxx xxxxxx xxxx [XxxxxxxxxxxxxXxxxxxxxxx](https://github.com/WindowsNotifications/NotificationsExtensions/wiki) xx xxxx xxx XXX.

Xxx xxxxxxxxx xxxxxxxxxxxx

```
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
```

Xxxxxx xxx xxxxxxxxxxxx xxxxxxx

```
// In a real app, these would be initialized with actual data
string from = "Jennifer Parker";
string subject = "Photos from our trip";
string body = "Check out these awesome photos I took while in New Zealand!";
 
 
// TODO - all values need to be XML escaped
 
 
// Construct the tile content as a string
string content = $@"
<tile>
    <visual>
 
        <binding template=&#39;TileMedium&#39;>
            <text>{from}</text>
            <text hint-style=&#39;captionSubtle&#39;>{subject}</text>
            <text hint-style=&#39;captionSubtle&#39;>{body}</text>
        </binding>
 
        <binding template=&#39;TileWide&#39;>
            <text hint-style=&#39;subtitle&#39;>{from}</text>
            <text hint-style=&#39;captionSubtle&#39;>{subject}</text>
            <text hint-style=&#39;captionSubtle&#39;>{body}</text>
        </binding>
 
    </visual>
</tile>";
```

Xxxxxx xxx xxxxxxxxxxxx

```
// Load the string into an XmlDocument
XmlDocument doc = new XmlDocument();
doc.LoadXml(content);
 
// Then create the tile notification
var notification = new TileNotification(doc);
```

## <span id="related_topics">
            </span>Xxxxxxx xxxxxx


* [Xxxxxx xxxxxxxx xxxxx](tiles-and-notifications-create-adaptive-tiles.md)
* [Xxxxxxxx xxxx xxxxxxxxx: xxxxxx xxx xxxxxxxxxxxxx](tiles-and-notifications-adaptive-tiles-schema.md)
* [XxxxxxxxxxxxxXxxxxxxxxx.XxxYY (XxXxx xxxxxxx)](https://www.nuget.org/packages/NotificationsExtensions.Win10/)
* [XxxxxxxxxxxxxXxxxxxxxxx xx XxxXxx](https://github.com/WindowsNotifications/NotificationsExtensions/wiki)
* [Xxxx xxxx xxxxxx xx XxxXxx](https://github.com/WindowsNotifications/quickstart-sending-local-tile-win10)
* [**Xxxxxxx.XX.Xxxxxxxxxxxxx xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208661)
* [Xxx xx xxx xxx xxxxxxxxxxxx xxxxx (XXXX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh868234)
* [Xxxxxxxxxx xxxxxxxxxxxxx](tiles-and-notifications-choosing-a-notification-delivery-method.md)
 

 




<!--HONumber=Mar16_HO1-->
