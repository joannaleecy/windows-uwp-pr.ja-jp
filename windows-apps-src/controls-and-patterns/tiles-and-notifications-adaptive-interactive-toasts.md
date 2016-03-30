---
Xxxxxxxxxxx: Xxxxxxxx xxx xxxxxxxxxxx xxxxx xxxxxxxxxxxxx xxx xxx xxxxxx xxxxxxxx xxx-xx xxxxxxxxxxxxx xxxx xxxx xxxxxxx, xxxxxxxx xxxxxx xxxxxx, xxx xxxxxxxx xxxx xxxxxxxxxxx.
xxxxx: Xxxxxxxx xxx xxxxxxxxxxx xxxxx xxxxxxxxxxxxx
xx.xxxxxxx: YXXXYYXX-YYXY-YYYX-YXXY-XYXXYXXXYXYY
xxxxx: Xxxxxxxx xxx xxxxxxxxxxx xxxxx xxxxxxxxxxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxxxxx xxx xxxxxxxxxxx xxxxx xxxxxxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxxxxxx xxx xxxxxxxxxxx xxxxx xxxxxxxxxxxxx xxx xxx xxxxxx xxxxxxxx xxx-xx xxxxxxxxxxxxx xxxx xxxx xxxxxxx, xxxxxxxx xxxxxx xxxxxx, xxx xxxxxxxx xxxx xxxxxxxxxxx.

Xxx xxxxxxxx xxx xxxxxxxxxxx xxxxx xxxxxxxxxxxxx xxxxx xxx xxxxx xxxxxxx xxxx xxx xxxxxx xxxxx xxxxxxxx xxxxxxx:

-   Xxx xxxxxx xx xxxxxxx xxxxxxx xxx xxxxxx xx xxx xxxxxxxxxxxxx.
-   Xxxxx xxxxxxxxx xxxxxxxxxx xxxxx xxx xxx xxxx xxxxx xxxxxxxxxxxx xxx xxx xxxx xxxxxx.
-   Xxx xxxxxx xx xxxxxx x xxxxxxxxxxxx xxx xxxxxxx xxxxxxxxx, xxxxxxxxx xxxxxx, xxxxxxxxx, xxx xxxxxxxx xxxxx.

**Xxxx**   Xx xxx xxx xxxxxx xxxxxxxxx xxxx Xxxxxxx Y.Y xxx Xxxxxxx Xxxxx Y.Y, xxx xxx [xxxxxx xxxxx xxxxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/hh761494).

 

## <span id="toast_structure">
            </span>
            <span id="TOAST_STRUCTURE">
            </span>Xxxxx xxxxxxxxxxxx xxxxxxxxx


Xxxxx xxxxxxxxxxxxx xxx xxxxxxxxxxx xxxxx XXX, xxxxx xxxxx xxxxxxxxx xxxxxxx xxxxx xxx xxxxxxxx:

-   &xx;xxxxxx&xx; xxxxxx xxx xxxxxxx xxxxxxxxx xxx xxx xxxxx xx xxxxxxxx xxx, xxxxxxxxx xxxx xxx xxxxxx
-   &xx;xxxxxxx&xx; xxxxxxxx xxxxxxx/xxxxxx xxx xxxxxxxxx xxxxx xx xxx xxxxxx xxx xxxxxxxxxxxx
-   &xx;xxxxx&xx; xxxxxxxxx xxx xxxxx xxxxxx xxxx xxx xxxxxxxxxxxx xxxx

Xxxx'x x xxxx xxxxxxx:

```XML
<toast launch="app-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Sample</text>
      <text>This is a simple toast notification example</text>
      <image placement="AppLogoOverride" src="oneAlarm.png" />
    </binding>
  </visual>
  <actions>
    <action content="check" arguments="check" imageUri="check.png" />
    <action content="cancel" arguments="cancel" />
  </actions>
  <audio src="ms-winsoundevent:Notification.Reminder"/>
</toast>
```

Xxx x xxxxxx xxxxxxxxxxxxxx xx xxx xxxxxxxxx:

![xxxxx xxxxxxxxxxxx xxxxxxxxx](images/adaptivetoasts-structure.jpg)

### <span id="Visual">
            </span>
            <span id="visual">
            </span>
            <span id="VISUAL">
            </span>Xxxxxx

Xxxxxx xxx xxxxxx xxxxxxx, xxx xxxx xxxx xxxxxxx xxx xxxxxxx xxxxxxx xxxx xxxxxxxx xxx xxxxxx xxxxxxx xx xxx xxxxx.

Xxxx xxxxxxxxxxxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxxxxxx xxxxxxxx xxxxxxxxx xxxx xxx xxxxx xx xxxxxxxxx xxxx xxxxx. Xxxxx xxxxxxxxxxxxx, xxxxxxx, xxxx xxxx xxx xxxxxxxx xxxx: **XxxxxXxxxxxx**. Xxxxxx xxxx xxx xxx xxxxxxxx xxxx xxxxx:

-   Xxx xxx xxxxxx xxx xxxxx xxxxxxx, xxxx xx xxxxxx xxxxxxx xxxx xx xxxx, xxxxxx xx xxxxxx xxxxx, xx xxxxxxxx xxx xxxxxxxxx xxxxx xxxx xxxxxxxxxx xxx xxx xxxx xx xxxxxxxxx xxxx, xxx xx xxx xx xxxxx xxxxxx xxxxxxx xxxxxxxx xxxxx xxxxxxxx xxx xxxxxx xxxxxxxx xx xxxxxxxx xx xxxxxxx xxxxxxx xxx xx x xxxxxxxx xxxxxxx xxx xxxxxxxx xxxx xxx xxx xxxxxxx.
-   Xxx xxx xxx xxx xxxx xxxx xx xxxxxxxxx xxx xxxx xxxxxxx xxx xxx **xxxxx xxxxxxxxxxxx** xxxx xxxxxxx xx xxxxxxx xx xxxxxxxxx xxxxx xx Xxxxxxxxx Xxxxxxx xxxxxxx, xxxxxxxxx xxxxxx, xxxxxxx, XXx, xxx Xxxx Xxx. Xxxx xx xxxxx xxxxxxx xxxx xxxxxx xxx xxxxxxxxxxxx xxx xxxxxxx xx xx xxx xxxx xxxxx xxxxx XX xxxxxxxx xxxx xxx xxxxxxxxxxx xxxxxx xxxxxxxxxxx xxx xxxxxxxxxxx xxxxx.

Xxx xxx xxxxxxxxxx xxxxxxxxx xx xxx xxxxxx xxxxxxx xxx xxx xxxxx xxxxxxxx, xxx xxx Xxxxxx xxxxxxx xxxxx. Xxx xxxx xxxxxxxx, xxx xxx XXX xxxxxxxx xxxxxxx xxxxx.

### <span id="Actions">
            </span>
            <span id="actions">
            </span>
            <span id="ACTIONS">
            </span>Xxxxxxx

Xx XXX xxxx, xxx xxx xxx xxxxxxx xxx xxxxx xxxxxx xx xxxx xxxxx xxxxxxxxxxxxx, xxxxx xxxx xxxxx xx xxxx xxxxxxx xx xxx xxx. Xxxxx xxxxxxx xxx xxxxxxxxx xxxxx xxx &xx;xxxxxxx&xx; xxxxxxx, xx xxxxx xxxxx xxx xxx xxxxx xxxx xxx xxx xxxxxxx:

-   &xx;xxxxxx&xx; Xxxx xxxxxxx xx x xxxxxx xx xxxxxxx xxx xxxxxx xxxxxxx. Xxx xxx xxxxxxx xx xx xxxx xxxxxx xx xxxxxx xxxxxxx xxxxxx x xxxxx xxxxxxxxxxxx.
-   &xx;xxxxx&xx; Xxxx xxxxxx xxxxx xx xxxxxxx xxxxx, xxxx xx xxxxx xxxxxxxx xx x xxxxxxx, xx xxxxxxxxx xx xxxxxx xxxx x xxxx-xxxx xxxx.

Xxxx &xx;xxxxxx&xx; xxx &xx;xxxxx&xx; xxx xxxxxxxx xxxxxx xxx Xxxxxxx xxxxxx xx xxxxxxx. Xxx xxxxxxx, xx xxxxxx xx xxxxxxx xxxxxxx, xx &xx;xxxxxx&xx; xx x xxxx xx x xxxxxx xx xxxxx xx xxx/xxxxx. X xxxx &xx;xxxxx&xx; xx x xxx xx xxxxx xxxxx xxx xxxxx xxxx xxxxx xxxxxx x xxxxxxxx xxxxxxxx xx xx xx-xxxxxx xxxxxxxx. Xxxxx xxxxxxxx xxxx xxxx xxxxx xx xxxxxx xxxxxxxxxxx xxxxxxxxx, xxxx xx xx xxxxxx xxxxxxxxx xx xxxxx xx x xxxx xxxxx xxxxx xx xxxxxxxxx.

Xxxx xx xxxxxx xx xxxxx xx xxx xxxx, xxx xxx xx xxx xx xxx xxxxxxxxx xx xxxxxxxxxx xxx [**XxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/dn408447) xxxxxxxxx xxxxxx xxx &xx;xxxxxx&xx; xxxxxxx:

-   Xxxxxxxxxx xxx xxx xx xxx xxxxxxxxxx, xxxx xx xxxxxx-xxxxxxxx xxxxxxxx xxxx xxx xx xxxx xx xxxxxxxx xx x xxxxxxxx xxxx/xxxxxxx.
-   Xxxxxxxxxx xxx xxx'x xxxxxxxxxx xxxx xxxxxxx xxxxxxxxx xxx xxxx.
-   Xxxxxxxxxx xxxxxxx xxx xxx xxxxxxxx xxxxxx.
-   Xxxxxxx x xxxxxx xxxxxx xx xxxxxxx. Xxx xxxxxxx xxxxxxxxx xxxxxx xxxxxxx xxx xxxxxxxx xxx xxxxxxxxxx xxxxxxxxx xxxxx/xxxxxxxx, xxxxx xxxx xx xxxxxxx xxxxxxxxx xx x xxxxxxx xxxxx.

Xxx xxx xxxxxxxxxx xxxxxxxxx xx xxx xxxxxx xxxxxxx xxx xxx xxxxx xxxxxxxx, xxx xxx Xxxxxx xxxxxxx xxxxx. Xxx xxxx xxxxxxxx, xxx xxx XXX xxxxxxxx xxxxxxx xxxxx.

### <span id="Audio">
            </span>
            <span id="audio">
            </span>
            <span id="AUDIO">
            </span>Xxxxx

Xxxxxx xxxxxx xxxx'x xxxxxxxxx xxxxxxxxx xx XXX xxxx xxxx xxxxxx xxx xxxxxxx xxxxxxxx; xxxxxxx, xxx xxx xxxxxx xxxx xxx xxxx xx xx-xxxxxxxxxxxxxx xxx xxxx xxx xx xxxxxxx. XXX xxxx xx xxxxxx xxxxxxxxx xxxxxxx xxxx xx-xxxxxxxxxxxxxx, xxxxx xxxx xxxxxx xxxxxx xx xxxxx xxxxxxx:

-   xx-xxxx:///
-   xx-xxxxxxx:///

Xxx xxx [xxxxx xxxxxx xxxx](https://msdn.microsoft.com/library/windows/apps/br230842) xxx xxxxxxxxxxx xx xxxxx xx xxxxx xxxxxxxxxxxxx, xxxxx xxxxxxxx x xxxxxxxx xxxx xx xx-xxxxxxxxxxxxxx.

## <span id="Alarms__reminders__and_incoming_calls">
            </span>
            <span id="alarms__reminders__and_incoming_calls">
            </span>
            <span id="ALARMS__REMINDERS__AND_INCOMING_CALLS">
            </span>Xxxxxx, xxxxxxxxx, xxx xxxxxxxx xxxxx


Xxx xxx xxx xxxxx xxxxxxxxxxxxx xxx xxxxxx, xxxxxxxxx, xxx xxxxxxxx xxxxx. Xxxxx xxxxxxx xxxxxx xxxx xx xxxxxxxxxx xxxx'x xxxxxxxxxx xxxx xxxxxxxx xxxxxx, xxxxxx xxxxxxx xxxxxx xxxxxxx xxxx xxxxxx, xxxxxxxx-xxxxx XX xxx xxxxxxxx:

-   X xxxxxxxx xxxxx xxxxxxxxxxxx xxxx xxxx xx xxxxxx xxxxx xxx xxxx xxxxxxxxx xx xx xxxxx xxxxxx. Xx Xxxxxxx Xxxxxx, xxx xxxxxxxx xxxxx xxxxxxxxxxxxx xxxx xxxx xxxx xx xxx-xxxxxxxx.
-   Xx xxxxxxxx xx xxxxxxx xxx xxxxx xxxxxxxxx xxxx xxxxxxxx xxxxxxxxxxxxx, xxxxx xxxxxxxxxxxxx xxxx xxxxxxxxxxxxx xxxx xxxxxxx xxxxx.
-   Xxxxxxxx xxxx xxxxxxxxxxxxx xxx xxxxxxxxx xxxx xxxxxx xx Xxxxxxx Xxxxxx xxxxxxx. Xxxx xx xxxx xx xxxxxxxxxx xxx xxxxxxxx xxxxxxxxx xxxxxx xxx xxxx xxxxxxx xx x xxxxx xxxxxxxxxxxx – &xx;xxxxx&xx;:
    &xx;xxxxx xxxxxxxx=" { xxxxxxx | xxxxx | xxxxxxxx | xxxxxxxxXxxx } " &xx;

## <span id="xml_examples">
            </span>
            <span id="XML_EXAMPLES">
            </span>XXX xxxxxxxx


**Xxxx**  Xxx xxxxx xxxxxxxxxxxx xxxxxxxxxxx xxx xxxxx xxxxxxxx xxxx xxxxx xxxx xx xxx xx xxxxxxx. Xx xxxxxx xxxxxxx, x xxxxx xxxxxxxxxxxx xxx xx xxxxxxxxx xxxx xx xxxx xx, xxxx x xxxxxxx xx xxx xxxxxx xx xxx xxxxx xx xxxxxx xx.

 

**Xxxxxxxxxxxx xxxx xxxx xxxxxx xxxxxxxx**

Xxxx xxxxxxx xxxxx xxx xxx xxx xxxx xxxxxxxx xxxxx xx xxxx, xx xxxxxxxx xxxxx xxxxx xx xxxxxxxx xxx xxxxxxxxxxx xxxx, xxx xx xxxxxxxx xxxxxx xxxxx xxxxxxxxx.

```XML
<toast launch="app-defined-string">
  <visual>
<binding template="ToastGeneric">
    <text>Photo Share</text>
      <text>Andrew sent you a picture</text>
      <text>See it in full size!</text>
      <image placement="appLogoOverride" src="A.png" />
    <image placement="inline" src="hiking.png" />
    </binding>
  </visual>
</toast>
```

![xxxxxxxxxxxx xxxx xxxx xxxxxx xxxxxxxx](images/adaptivetoasts-xmlsample01.png)

 

**Xxxxxxxxxxxx xxxx xxxxxxx, xxxxxxx Y**

Xxxx xxxxxxx xxxxx...

```XML
<toast launch="app-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Microsoft Company Store</text>
      <text>New Halo game is back in stock!</text>
      <image placement="appLogoOverride" src="A.png" />
    </binding>
  </visual>
  <actions>
    <action activationType="foreground" content="see more details" arguments="details" imageUri="check.png"/>
    <action activationType="background" content="remind me later" arguments="later" imageUri="cancel.png"/>
  </actions>
</toast>
```

![xxxxxxxxxxxx xxxx xxxxxxx, xxxxxxx Y](images/adaptivetoasts-xmlsample02.png)

 

**Xxxxxxxxxxxx xxxx xxxxxxx, xxxxxxx Y**

Xxxx xxxxxxx xxxxx...

```XML
<toast launch="app-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Cortana</text>
      <text>We noticed that you are near Wasaki.</text>
      <text>Thomas left a 5 star rating after his last visit, do you want to try?</text>
      <image placement="appLogoOverride" src="A.png" />
    </binding>
  </visual>
  <actions>
    <action activationType="foreground" content="reviews" arguments="reviews" />
    <action activationType="protocol" content="show map" arguments="bingmaps:?q=sushi" />
  </actions>
</toast>
```

![xxxxxxxxxxxx xxxx xxxxxxx, xxxxxxx Y](images/adaptivetoasts-xmlsample03.png)

 

**Xxxxxxxxxxxx xxxx xxxx xxxxx xxx xxxxxxx, xxxxxxx Y**

Xxxx xxxxxxx xxxxx...

```XML
<toast launch="developer-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Andrew B.</text>
      <text>Shall we meet up at 8?</text>
      <image placement="appLogoOverride" src="A.png" />
    </binding>
  </visual>
  <actions>
    <input id="message" type="text" placeHolderContent="reply here" />
    <action activationType="background" content="reply" arguments="reply" />
    <action activationType="foreground" content="video call" arguments="video" />
  </actions>
</toast>
```

![xxxxxxxxxxxx xxxx xxxx xxx xxxxx xxxxxxx](images/adaptivetoasts-xmlsample04.png)

 

**Xxxxxxxxxxxx xxxx xxxx xxxxx xxx xxxxxxx, xxxxxxx Y**

Xxxx xxxxxxx xxxxx...

```XML
<toast launch="developer-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Andrew B.</text>
      <text>Shall we meet up at 8?</text>
      <image placement="appLogoOverride" src="A.png" />
    </binding>
  </visual>
  <actions>
    <input id="message" type="text" placeHolderContent="reply here" />
    <action activationType="background" content="reply" arguments="reply" imageUri="send.png" hint-inputId="message"/>
  </actions>
</toast>
```

![xxxxxxxxxxxx xxxx xxxx xxxxx xxx xxxxxxx](images/adaptivetoasts-xmlsample05.png)

 

**Xxxxxxxxxxxx xxxx xxxxxxxxx xxxxx xxx xxxxxxx**

Xxxx xxxxxxx xxxxx...

```XML
<toast launch="developer-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Spicy Heaven</text>
      <text>When do you plan to come in tomorrow?</text>
      <image placement="appLogoOverride" src="A.png" />
    </binding>
  </visual>
  <actions>
    <input id="time" type="selection" defaultInput="2" >
  <selection id="1" content="Breakfast" />
  <selection id="2" content="Lunch" />
  <selection id="3" content="Dinner" />
    </input>
    <action activationType="background" content="Reserve" arguments="reserve" />
    <action activationType="background" content="Call Restaurant" arguments="call" />
  </actions>
</toast>
```

![xxxxxxxxxxxx xxxx xxxxxxxxx xxxxx xxx xxxxxxx](images/adaptivetoasts-xmlsample06.png)

 

**Xxxxxxxx xxxxxxxxxxxx**

Xxxx xxxxxxx xxxxx...

```XML
<toast scenario="reminder" launch="developer-pre-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Adam&#39;s Hiking Camp</text>
      <text>You have an upcoming event for this Friday!</text>
      <text>RSVP before it"s too late.</text>
      <image placement="appLogoOverride" src="A.png" />
      <image placement="inline" src="hiking.png" />
    </binding>
  </visual>
  <actions>
    <action activationType="background" content="RSVP" arguments="rsvp" />
    <action activationType="background" content="Reminder me later" arguments="later" />
  </actions>
</toast>
```

![xxxxxxxx xxxxxxxxxxxx](images/adaptivetoasts-xmlsample07.png)

 

## <span id="Activation_samples">
            </span>
            <span id="activation_samples">
            </span>
            <span id="ACTIVATION_SAMPLES">
            </span>Xxxxxxxxxx xxxxxxx


Xxxx xxxxxxxxx xxxxx, xxx xxxx xxx xxxxxxx xx xxx xxxxx xxx xxxxxxx xx xxxxxxxxxx xxxx xx xxxxxxxxx xxxx. Xxx xxxxx xxxxxx xxxx xxxx xxx xxx xx xxxxxx xxxxxxxxx xxxx xx xxxxxxxxxxx xxxx xxx xxxxx xxxx xxx/xx xxxxx xxxxxxx.

**Xxxxxxxxxx**

Xx xxxx xxxxxxxx, xx xxx xxxx xxxxxxxxxx xxxxxxxxxx xx xxxxxxx xx xx xxxxxx xxxxxx xx xxxxxxxxxx xxxxx xxxxxxxxxxxx xx xxxxxxxxx xxx xxx xxx xxxxxxxxxx xx xxx xxxxxxx xxxxxxx.

Xxxxxxxxxx xxxx xxxxx xxxxxxxxxxxxx xxxx xx xxxxxx XxXxxxxxxx(). Xx Xxxxxxx YY, xxxxx xxx xxx xxx xxxxxxxxxx xxxx xxx xxxx xxxxxx XxXxxxxxxxx().

```
async protected override void OnActivated(IActivatedEventArgs args)
{
        //Initialize your app if it&#39;s not yet initialized;
    //Find out if this is activated from a toast;
    If (args.Kind == ActivationKind.ToastNotification)
    {
                //Get the pre-defined arguments and user inputs from the eventargs;
        var toastArgs = args as ToastNotificationActivatedEventArgs;
        var arguments = toastArgs.Arguments;
        var input = toastArgs.UserInput["1"]; 
}
     
    //...
}
```

**Xxxxxxxxxx**

Xx xxxx xxxxxxxx, xx xxx xxxx x xxxxxxxxxx xxxx xx xxxxxx xx xxxxxx xxxxxx xx xxxxxxxxxxx xxxxx xxxxxxxxxxxx. Xxx xxxxx xxxx xxxxx xxx xx xxxxxxx xxxx xxxxxxxxxx xxxx xxx xxxxxxxx xxxxx xxxxxxxxxxx xxxxxx xxxx xxx xxxxxxxx, xxx xxx xx xxx xxxxxxxxx xxxx xxx xxxxxx xxx xxxx xxxxxx xxxx xxx xxxxxxx xxx xxxxxxx.

```
<!-- Manifest Declaration -->
<!-- A new task type toastNotification is added -->
<Extension Category = "windows.backgroundTasks" 
EntryPoint = "Tasks.BackgroundTaskClass" >
  <BackgroundTasks>
    <Task Type="systemEvent" />
  </BackgroundTasks>
</Extension>
```

```
namespace ToastNotificationTask
{
    public sealed class ToastNotificationBackgroundTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
        //Inside here developer can retrieve and consume the pre-defined 
        //arguments and user inputs;
        var details = taskInstance.TriggerDetails as ToastNotificationActionTriggerDetail;
        var arguments = details.Arguments;
        var input = details.Input.Lookup("1");

            // ...
        }        
    }
}
```

## <span id="Schemas___visual__and__audio_">
            </span>
            <span id="schemas___visual__and__audio_">
            </span>
            <span id="SCHEMAS___VISUAL__AND__AUDIO_">
            </span>Xxxxxxx: &xx;xxxxxx&xx; xxx &xx;xxxxx&xx;


Xx xxx xxxxxxxxx xxxxxxx, x "?" xxxxxx xxxxx xxxx xx xxxxxxxxx xx xxxxxxxx.

```
<toast launch? duration? activationType? scenario? >
    <visual version? lang? baseUri? addImageQuery? >
        <binding template? lang? baseUri? addImageQuery? >
            <text lang? >content</text>
            <text />
            <image src placement? alt? addImageQuery? hint-crop? />
        </binding>
    </visual>
    <audio src? loop? silent? />
    <actions>
    </actions>
</toast>
```

**Xxxxxxxxxx xx &xx;xxxxx&xx;**

xxxxxx?

-   xxxxxx? = xxxxxx
-   Xxxx xx xx xxxxxxxx xxxxxxxxx.
-   X xxxxxx xxxx xx xxxxxx xx xxx xxxxxxxxxxx xxxx xx xx xxxxxxxxx xx xxx xxxxx.
-   Xxxxxxxxx xx xxx xxxxx xx xxxxxxxxxxXxxx, xxxx xxxxx xxx xx xxxxxxxx xx xxx xxx xx xxx xxxxxxxxxx, xxxxxx xxx xxxxxxxxxx xxxx, xx xx xxxxxxx xxx xxxx'x xxxxxxxx xxxxxxxx xxxx xxx xxxxxxxx xxx.
-   Xxx xxxxxx xxx xxxxxxxx xx xxxx xxxxxx xxx xxxxxxx xx xxx xxx xxx xxx xxx xxx.
-   Xxxx xxx xxxx xxxx xx xxxxxx xxx xxxxx xx xxxxxx xxx xxxxxxxxxx xxx, xxx xxxxxx xxxxxx xxxxxxxx xxx xxxxxxx xx xxx xxx xxxx xxxxxx xx xx xxxx xxx xxxx x xxxx xxxxxxxx xx xxx xxxxx xxxxxxx, xxxxxx xxxx xxxxxxxxx xx xxx xxxxxxx xxx.
-   Xx xxx xxxxxxxxxx xx xxxxxxxx xxxxxxx xxxx xxxxxxx xx xx xxxxxx, xxxxxxx xx xxx xxxx xx xxx xxxxx, xxx xxxxxxxxx xxxxxxxxx xxxx xxx "xxxxxxxxx" xxx-xxxxxxx xx xxxx &xx;xxxxxx&xx; xxx, xxxxxxx xx "xxxxxx" xxx-xxxxxxx xx xxx &xx;xxxxx&xx; xxx.

xxxxxxxx?

-   xxxxxxxx? = "xxxxx|xxxx"
-   Xxxx xx xx xxxxxxxx xxxxxxxxx. Xxxxxxx xxxxx xx "xxxxx".
-   Xxxx xx xxxx xxxx xxx xxxxxxxx xxxxxxxxx xxx xxxXxxxxx. Xxx xxx'x xxxx xxxx xxx xxx xxxxx xxxxxxxx xxxxxxx.
-   Xx xxx'x xxxxxxxxx xxxxx xxxx xxxxxxxx.

xxxxxxxxxxXxxx?

-   xxxxxxxxxxXxxx? = "xxxxxxxxxx | xxxxxxxxxx | xxxxxxxx | xxxxxx"
-   Xxxx xx xx xxxxxxxx xxxxxxxxx.
-   Xxx xxxxxxx xxxxx xx "xxxxxxxxxx".

xxxxxxxx?

-   xxxxxxxx? = "xxxxxxx | xxxxx | xxxxxxxx | xxxxxxxxXxxx"
-   Xxxx xx xx xxxxxxxx xxxxxxxxx, xxxxxxx xxxxx xx "xxxxxxx".
-   Xxx xx xxx xxxx xxxx xxxxxx xxxx xxxxxxxx xx xx xxx xx xxxxx, xxxxxxxx, xx xxxxxxxx xxxx.
-   Xx xxx xxx xxxx xxxx xxx xxxxxxx xxxx xxxxxxxxxxxx xxxxxxxxxx xx xxxxxx.

**Xxxxxxxxxx xx &xx;xxxxxx&xx;**

xxxxxxx?

-   xxxxxxx? = xxxXxxxxxxxXxxxxxx
-   Xxxx xxxxxxxxx xxx'x xxxxxxxxx xxxxxxx xxxxxxxxxx xxxx xx xxxxxxxxxx xx &xx;xxxxxx&xx;. Xxxx xxxxx xxx x xxx xxxxxxxxxx xxxxx xxxx xxx'xx xxxxxxx xxxx x xxxxxx xxxxxxxxx, xx xxxxxx.

xxxx?

-   Xxx [xxxx xxxxxxx xxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/br230847) xxx xxxxxxx xx xxxx xxxxxxxx xxxxxxxxx.

xxxxXxx?

-   Xxx [xxxx xxxxxxx xxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/br230847) xxx xxxxxxx xx xxxx xxxxxxxx xxxxxxxxx.

xxxXxxxxXxxxx?

-   Xxx [xxxx xxxxxxx xxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/br230847) xxx xxxxxxx xx xxxx xxxxxxxx xxxxxxxxx.

**Xxxxxxxxxx xx &xx;xxxxxxx&xx;**

xxxxxxxx?

-   \[Xxxxxxxxx\] xxxxxxxx? = "XxxxxXxxxxxx"
-   Xx xxx xxx xxxxx xxx xx xxx xxx xxxxxxxx xxx xxxxxxxxxxx xxxxxxxxxxxx xxxxxxxx, xxxxxx xxxx xxxx xxx xxxxx xxxxx "XxxxxXxxxxxx" xxxxxxxx xxxxxxx xx xxx xxxxxx xxxxxxxx.
-   Xxxxx xxx xxxxxx xxxxxxxxx xxxx xxx xxx xxxxxxx xxxxx xxxx xxx, xxx xxxx xx xxx xxx xxxxxxxx xxx xxxx, xxx xx xxxxxx xxxxxxxxx xxxx xxxx xxxxxxxx xxxxxxx.

xxxx?

-   Xxx [xxxx xxxxxxx xxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/br230847) xxx xxxxxxx xx xxxx xxxxxxxx xxxxxxxxx.

xxxxXxx?

-   Xxx [xxxx xxxxxxx xxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/br230847) xxx xxxxxxx xx xxxx xxxxxxxx xxxxxxxxx.

xxxXxxxxXxxxx?

-   Xxx [xxxx xxxxxxx xxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/br230847) xxx xxxxxxx xx xxxx xxxxxxxx xxxxxxxxx.

**Xxxxxxxxxx xx &xx;xxxx&xx;**

xxxx?

-   Xxx [xxxx xxxxxxx xxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/br230847) xxx xxxxxxx xx xxxx xxxxxxxx xxxxxxxxx.

**Xxxxxxxxxx xx &xx;xxxxx&xx;**

xxx

-   Xxx [xxxx xxxxxxx xxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/br230844) xxx xxxxxxx xx xxxx xxxxxxxx xxxxxxxxx.

xxxxxxxxx?

-   xxxxxxxxx? = "xxxxxx" | "xxxXxxxXxxxxxxx"
-   Xxxx xxxxxxxxx xx xxxxxxxx.
-   Xxxx xxxxxxxxx xxxxx xxxx xxxxx xxxx xx xxxxxxxxx.
-   "xxxxxx" xxxxx xxxxxx xxx xxxxx xxxx, xxxxx xxx xxxx; "xxxXxxxXxxxxxxx" xxxxx xxxxxxx xxx xxxxxxxxxxx xxxx (xxxx xxxxx xx xx xxx xxx xxxx xxxxxx xx xxx xxxxx).
-   Xxx xxx xxxx xx xx xxx xxxxx xxx xxxx xxxxxxxxx xxxxx.

xxx?

-   Xxx [xxxx xxxxxxx xxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/br230844) xxx xxxxxxx xx xxxx xxxxxxxx xxxxxxxxx.

xxxXxxxxXxxxx?

-   Xxx [xxxx xxxxxxx xxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/br230844) xxx xxxxxxx xx xxxx xxxxxxxx xxxxxxxxx.

xxxx-xxxx?

-   xxxx-xxxx? = "xxxx" | "xxxxxx"
-   Xxxx xxxxxxxxx xx xxxxxxxx.
-   "xxxx" xx xxx xxxxxxx xxxxx xxxxx xxxxx xx xxxxxxxx.
-   "xxxxxx" xxxxx xxx xxxxx xx x xxxxxxxx xxxxx. Xxx xxxx xxx xxxxxxx xxxxxx xx x xxxxxxx, xxxxxx xx x xxxxxx, xxx xx xx.

**Xxxxxxxxxx xx &xx;xxxxx&xx;**

xxx?

-   Xxx [xxxx xxxxxxx xxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/br230842) xxx xxxxxxx xx xxxx xxxxxxxx xxxxxxxxx.

xxxx?

-   Xxx [xxxx xxxxxxx xxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/br230842) xxx xxxxxxx xx xxxx xxxxxxxx xxxxxxxxx.

xxxxxx?

-   Xxx [xxxx xxxxxxx xxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/br230842) xxx xxxxxxx xx xxxx xxxxxxxx xxxxxxxxx.

## <span id="Schemas___action_">
            </span>
            <span id="schemas___action_">
            </span>
            <span id="SCHEMAS___ACTION_">
            </span>Xxxxxxx: &xx;xxxxxx&xx;


Xx xxx xxxxxxxxx xxxxxxx, x "?" xxxxxx xxxxx xxxx xx xxxxxxxxx xx xxxxxxxx.

```
<toast>
    <visual>
    </visual>
    <audio />
    <actions>
        <input id type title? placeHolderContent? defaultInput? >
            <selection id content />
        </input>
        <action content arguments activationType? imageUri? hint-inputId />
    </actions>
</toast>
```

**Xxxxxxxxxx xx &xx;xxxxx&xx;**

xx

-   xx = xxxxxx
-   Xxxx xxxxxxxxx xx xxxxxxxx.
-   Xxx xx xxxxxxxxx xx xxxxxxxx xxx xx xxxx xx xxxxxxxxxx xx xxxxxxxx xxxx xxxxxx xxxx xxx xxx xx xxxxxxxxx (xx xxx xxxxxxxxxx xx xxxxxxxxxx).

xxxx

-   xxxx = "xxxx | xxxxxxxxx"
-   Xxxx xxxxxxxxx xx xxxxxxxx.
-   Xx xx xxxx xx xxxxxxx x xxxx xxxxx xx xxxxx xxxx x xxxx xx xxx-xxxxxxx xxxxxxxxxx.
-   Xx xxxxxx xxx xxxxxxx, xxxx xx xx xxxxxxx xxxxxxx xxx xxxx x xxxxxxx xxxxx xx x xxxxxxx xxxxx.

xxxxx?

-   xxxxx? = xxxxxx
-   Xxx xxxxx xxxxxxxxx xx xxxxxxxx xxx xx xxx xxxxxxxxxx xx xxxxxxx x xxxxx xxx xxx xxxxx xxx xxxxxx xx xxxxxx xxxx xxxxx xx xxxxxxxxxx.
-   Xxx xxxxxx xxx xxxxxxx, xxxx xxxxx xxxx xx xxxxxxxxx xxxxx xxx xxxxx.

xxxxxXxxxxxXxxxxxx?

-   xxxxxXxxxxxXxxxxxx? = xxxxxx
-   Xxx xxxxxXxxxxxXxxxxxx xxxxxxxxx xx xxxxxxxx xxx xx xxx xxxx-xxx xxxx xxxx xxx xxxx xxxxx xxxx. Xxxx xxxxxxxxx xx xxxxxxx xxxx xxx xxxxx xxxx xx xxx "xxxx".

xxxxxxxXxxxx?

-   xxxxxxxXxxxx? = xxxxxx
-   Xxx xxxxxxxXxxxx xxxxxxxxx xx xxxxxxxx xxx xx xxxx xx xxxxxxx x xxxxxxx xxxxx xxxxx.
-   Xx xxx xxxxx xxxx xx "xxxx", xxxx xxxx xx xxxxxxx xx x xxxxxx xxxxx.
-   Xx xxx xxxxx xxxx xx "xxxxxxxxx", xxxx xx xxxxxxxx xx xx xxx xx xx xxx xx xxx xxxxxxxxx xxxxxxxxxx xxxxxx xxxx xxxxx'x xxxxxxxx.

**Xxxxxxxxxx xx &xx;xxxxxxxxx&xx;**

xx

-   Xxxx xxxxxxxxx xx xxxxxxxx. Xx'x xxxx xx xxxxxxxx xxxx xxxxxxxxxx. Xxx xx xx xxxxxxxx xx xxxx xxx.

xxxxxxx

-   Xxxx xxxxxxxxx xx xxxxxxxx. Xx xxxxxxxx xxx xxxxxx xx xxxxxxx xxx xxxx xxxxxxxxx xxxxxxx.

**Xxxxxxxxxx xx &xx;xxxxxx&xx;**

xxxxxxx

-   xxxxxxx = xxxxxx
-   Xxx xxxxxxx xxxxxxxxx xx xxxxxxxx. Xx xxxxxxxx xxx xxxx xxxxxx xxxxxxxxx xx xxx xxxxxx.

xxxxxxxxx

-   xxxxxxxxx = xxxxxx
-   Xxx xxxxxxxxx xxxxxxxxx xx xxxxxxxx. Xx xxxxxxxxx xxx xxx-xxxxxxx xxxx xxxx xxx xxx xxx xxxxx xxxxxxxx xxxx xx xx xxxxxxxxx xxxx xxxx xxxxxx xxxx xxxxxx.

xxxxxxxxxxXxxx?

-   xxxxxxxxxxXxxx? = "xxxxxxxxxx | xxxxxxxxxx | xxxxxxxx | xxxxxx"
-   Xxx xxxxxxxxxxXxxx xxxxxxxxx xx xxxxxxxx xxx xxx xxxxxxx xxxxx xx "xxxxxxxxxx".
-   Xx xxxxxxxxx xxx xxxx xx xxxxxxxxxx xxxx xxxxxx xxxx xxxxx: xxxxxxxxxx, xxxxxxxxxx, xx xxxxxxxxx xxxxxxx xxx xxx xxxxxxxx xxxxxx, xx xxxxxxxx x xxxxxx xxxxxx.

xxxxxXxx?

-   xxxxxXxx? = xxxxxx
-   xxxxxXxx xx xxxxxxxx xxx xx xxxx xx xxxxxxx xx xxxxx xxxx xxx xxxx xxxxxx xx xxxxxxx xxxxxx xxx xxxxxx xxxxx xxxx xxx xxxx xxxxxxx.

xxxx-xxxxxXx

-   xxxx-xxxxxXx = xxxxxx
-   Xxx xxxx-xxxxxXx xxxxxxxxx xx xxxxxxxx. Xx'x xxxxxxxxxxxx xxxx xxx xxx xxxxx xxxxx xxxxxxxx.
-   Xxx xxxxx xxxxx xx xx xxx xx xx xxx xxxxx xxxxxxx xxxxxxx xx xx xxxxxxxxxx xxxx.
-   Xx xxxxxx xxx xxxxxxx, xxxx xxxx xxx xxx xxxxxx xxxxx xxxx xx xxx xxxxx xxx.

## <span id="Attributes_for_system-handled_actions">
            </span>
            <span id="attributes_for_system-handled_actions">
            </span>
            <span id="ATTRIBUTES_FOR_SYSTEM-HANDLED_ACTIONS">
            </span>Xxxxxxxxxx xxx xxxxxx-xxxxxxx xxxxxxx


Xxx xxxxxx xxx xxxxxx xxxxxxx xxx xxxxxxxx xxx xxxxxxxxxx xxxxxxxxxxxxx xx xxx xxx'x xxxx xxxx xxx xx xxxxxx xxx xxxxxxxx/xxxxxxxxxxxx xx xxxxxxxxxxxxx xx x xxxxxxxxxx xxxx. Xxxxxx-xxxxxxx xxxxxxx xxx xx xxxxxxxx (xx xxxxxxxxxxxx xxxxxxxxx), xxx xx xxx'x xxxxxxxxx xxxxxxxxxxxx x xxxxxx xxxxxx xxxxxxx x xxxxxxx xxxxxx.

Xxxxxx xxxxxxxx xxxxx: XxxxxxXxxXxxxxxx

```
<toast>
    <visual>
    </visual>
    <audio />
    <actions hint-systemCommands? = "SnoozeAndDismiss" />
</toast>
```

Xxxxxxxxxx xxxxxx-xxxxxxx xxxxxxx

```
<toast>
    <visual>
    </visual>
    <audio />
<actions>
<input id="snoozeTime" type="selection" defaultInput="10">
  <selection id="5" content="5 minutes" />
  <selection id="10" content="10 minutes" />
  <selection id="20" content="20 minutes" />
  <selection id="30" content="30 minutes" />
  <selection id="60" content="1 hour" />
</input>
<action activationType="system" arguments="snooze" hint-inputId="snoozeTime" content=""/>
<action activationType="system" arguments="dismiss" content=""/>
</actions>
</toast>
```

Xx xxxxxxxxx xxxxxxxxxx xxxxxx xxx xxxxxxx xxxxxxx, xx xxx xxxxxxxxx:

-   Xxxxxxx xxxxxxxxxxXxxx = "xxxxxx"
-   Xxxxxxx xxxxxxxxx = "xxxxxx" | "xxxxxxx"
-   Xxxxxxx xxxxxxx:
    -   Xx xxx xxxx xxxxxxxxx xxxxxxx xx "xxxxxx" xxx "xxxxxxx" xx xx xxxxxxxxx xx xxx xxxxxxx, xxxxxxx xxxxxxx xx xx xx xxxxx xxxxxx: &xx;xxxxxx xxxxxxx = ""/&xx;
    -   Xx xxx xxxx x xxxxxxxxxx xxxxxx, xxxx xxxxxxx xxx xxxxx: &xx;xxxxxx xxxxxxx="Xxxxxx xx xxxxx" /&xx;
-   Xxxxxxx xxxxx:
    -   Xx xxx xxx'x xxxx xxx xxxx xx xxxxxx x xxxxxx xxxxxxxx xxx xxxxxxx xxxx xxxx xxxx xxxxxxxxxxxx xx xxxxxx xxxx xxxx xxx x xxxxxx-xxxxxxx xxxx xxxxxxxx (xxxx xx xxxxxxxxxx xxxxxx xxx XX), xxxx xxx'x xxxxxxxxx xxx &xx;xxxxx&xx; xx xxx.
    -   Xx xxx xxxx xx xxxxxxx xxxxxx xxxxxxxx xxxxxxxxxx:
        -   Xxxxxxx xxxx-xxxxxXx xx xxx xxxxxx xxxxxx
        -   Xxxxx xxx xx xx xxx xxxxx xxxx xxx xxxx-xxxxxXx xx xxx xxxxxx xxxxxx: &xx;xxxxx xx="xxxxxxXxxx"&xx;&xx;/xxxxx&xx;&xx;xxxxxx xxxx-xxxxxXx="xxxxxxXxxx"/&xx;
        -   Xxxxxxx xxxxxxxxx xx xx xx x xxxXxxxxxxxXxxxxxx xxxxx xxxxxxxxxx xxxxxx xxxxxxxx xx xxxxxxx: &xx;xxxxxxxxx xx="YYY" /&xx; xxxxx xxxxxxxx xxx Y xxxxx
        -   Xxxx xxxx xxxx xxx xxxxx xx xxxxxxxXxxxx xx &xx;xxxxx&xx; xxxxxxx xxxx xxx xx xxx xxx xx xxx &xx;xxxxxxxxx&xx; xxxxxxxx xxxxxxxx
        -   Xxxxxxx xx xx (xxx xx xxxx xxxx) Y &xx;xxxxxxxxx&xx; xxxxxx

 

 




<!--HONumber=Mar16_HO1-->
