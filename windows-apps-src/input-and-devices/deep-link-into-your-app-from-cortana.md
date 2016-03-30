---
Xxxxxxxxxxx: Xxxxxxx xxxx xxxxx xxxx xxx xxxxxxxxxx xxx xxxxxxx xx Xxxxxxx xx xxxxxx xxx xxx xx xxx xxxxxxxxxx xx x xxxxxxxx xxxxx xx xxxxxxx.
xxxxx: Xxxx xxxx xxxx Xxxxxxx xx x xxxxxxxxxx xxx
xx.xxxxxxx: XXYYYXYY-YYYY-YYYX-YYXY-YXYYXYYXYYYY
xxxxx: Xxxx xxxx xx x xxxxxxxxxx xxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxx xxxx xxxx Xxxxxxx xx x xxxxxxxxxx xxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**Xxxxxxx.XxxxxxxxxxxXxxxx.XxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn706594)
-   [**Xxxxx Xxxxxxx Xxxxxxxxxx (XXX) xxxxxxxx xxx xxxxxxxxxx xY.Y**](https://msdn.microsoft.com/library/windows/apps/dn706593)

Xxxxxxx xxxx xxxxx xxxx xxx xxxxxxxxxx xxx xxxxxxx xx **Xxxxxxx** xx xxxxxx xxx xxx xx xxx xxxxxxxxxx xx x xxxxxxxx xxxxx xx xxxxxxx.

X xxxx xxxx xx xxxxxxxxx xx xxxxxxx xx xxx **Xxxxxxx** xxxxxxxxxx xxxxxx, xxx xxx xxx xxxxxxx xxxx xxxxx xx xxxxxxx xxxxx xxxxxxx. Xxx xxxx xxxx, xxx [Xxxxxxxx xxxx x xxxxxxxxxx xxx xx Xxxxxxx](interact-with-a-background-app-in-cortana.md).

**Xxxxxxxxxxxxx:  **

Xxxx xxxxx xxxxxx xx [Xxxxxxxx xxxx x xxxxxxxxxx xxx xx Xxxxxxx](interact-with-a-background-app-in-cortana.md). Xx xxxxxxxx xxxxx x xxxx xxxxxxxx xxx xxxxxxxxxx xxx xxxxx **Xxxxxxxxx Xxxxx** xx xxxxxxxxxxx xxxxxxx **Xxxxxxx** xxxxxxxx.

Xx xxx'xx xxx xx xxxxxxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx, xxxx x xxxx xxxxxxx xxxxx xxxxxx xx xxx xxxxxxxx xxxx xxx xxxxxxxxxxxx xxxxxxxxx xxxx.

-   [Xxxxxx xxxx xxxxx xxx](https://msdn.microsoft.com/library/windows/apps/bg124288)
-   Xxxxx xxxxx xxxxxx xxxx [Xxxxxx xxx xxxxxx xxxxxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt185584)

**Xxxx xxxxxxxxxx xxxxxxxxxx:  **

Xxx [Xxxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn974233) xxx xxxx xxxxx xxx xx xxxxxxxxx xxxx xxx xxxx **Xxxxxxx** xxx [Xxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn596121) xxx xxxxxxx xxxx xx xxxxxxxxx x xxxxxx xxx xxxxxxxx xxxxxx-xxxxxxx xxx.

## <span id="Overview">
            </span>
            <span id="overview">
            </span>
            <span id="OVERVIEW">
            </span>Xxxxxxxx


Xxxxx xxx xxxxxx xxxx xxx xxxxxxx **Xxxxxxx** xx:

-   Xxxxxxxxx xx xx x xxxxxxxxxx xxx (xxx [Xxxxxx x xxxxxxxxxx xxx xxxx xxxxx xxxxxxxx xx Xxxxxxx](launch-a-foreground-app-with-voice-commands-in-cortana.md)).
-   Xxxxxxxx xxxxxxxx xxxxxxxxxxxxx xx x xxxxxxxxxx xxx xxxxxxx (xxx [Xxxxxx x xxxxxxxxxx xxx xxxx xxxxx xxxxxxxx xx Xxxxxxx](launch-a-background-app-with-voice-commands-in-cortana.md)).
-   Xxxx xxxxxxx xx xxxxxxxx xxxxx, xxxxxxx, xxx xxxxx xx xxxxxxx.

Xx xxxxxxx xxx xxxx xxxx xxxx.

Xxxx xxxxxxx xx xxxxxx xxxx Xxxxxxx xxx xxxx xxx xxxxxxx xxx x xxxxxxx xx xxx xxxx xxx (xxxxxxx xx xxxxxxxxx xxx xxxx xx xxxxxx xxxx xxx xxxxxxx xxx Xxxxx xxxx), xx xxx xxxxxxxxx xxxxxx xx xxxxxx xxxxxx xxx xxxxxxxxxxxxx xxxxxx xxxx xxx xxxx xx xxx xxxxxxxx xxxxxxx Xxxxxxx. Xxxx xxxxxxx xx xxxxxxx xxx xx xxxxxxxx xxxxxxxxx xxx xxxxxx xx xxxx xxx.

Xxxxx xxx xxxxx xxxx xx xxxxxxx xxxx xxxxx:

-   X "Xx xx &xx;xxx&xx;" xxxx xx xxxxxxx **Xxxxxxx** xxxxxxx.
-   X xxxx xxxxxxxx xx x xxxxxxx xxxx xx xxxxxxx **Xxxxxxx** xxxxxxx.
-   Xxx xxx xxxxxxx xxxxxxxxxxxxxxxx xxxxxxxx xxx xxxxxxxxxx xxx.

Xxxx **Xxxxxxx** xxx xxx xxxxxxxxxx xxx xxxxxxx xxx xxxxxxxxxx xxxx xxx xxxxxxxxxx xxx xx xxxxxxxx.

## <span id="Go_to__app__deep_link">
            </span>
            <span id="go_to__app__deep_link">
            </span>
            <span id="GO_TO__APP__DEEP_LINK">
            </span>"Xx xx &xx;xxx&xx;" xxxx xxxx


**Xxxxxxx** xxx xxxxxx x "Xx xx &xx;xxx&xx;" xxxx xxxx xxxxx xxx xxxxxxx xxxx xx xxxxxxx xxxxxxx.

![xxxxxxx xxxxxxxxxx xxx xxxxxxxxxx xxxxxx](images/cortana-completion-screen.png)

Xxx xxx xxxxxxx x xxxxxx xxxxxxxx xxx xxxx xxxx xx xxxx xxxx xxx xxxx xxxxxxx xxxxxxx xx xxx xxx xxxxxxx. Xx xxx xxx'x xxxxxxx x xxxxxx xxxxxxxx, xxx xxx xx xxxxxxxx xx xxx xxxx xxxxxx.

Xxxx, xx xxx xx [**XxxXxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974183) xxxxxxxxx xxxx x xxxxx xx "Xxx Xxxxx" xx x [**XxxxxXxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974182) xxxxxx xxxx xx xxx [**XxxxxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn706580) xxxx xx xxx [**XxxxxXxxxxxxXxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974204). xxxxxx

```CSharp
var userMessage = new VoiceCommandUserMessage();
string keepingTripToDestination = string.Format(
  cortanaResourceMap.GetValue("KeepingTripToDestination", 
    cortanaContext).ValueAsString, destination);
userMessage.DisplayMessage = userMessage.SpokenMessage = 
  keepingTripToDestination;

response = VoiceCommandResponse.CreateResponse(userMessage);
response.AppLaunchArgument = “Las Vegas”;
await voiceServiceConnection.ReportSuccessAsync(response);
```

## <span id="Content_tile_deep_link">
            </span>
            <span id="content_tile_deep_link">
            </span>
            <span id="CONTENT_TILE_DEEP_LINK">
            </span>Xxxxxxx xxxx xxxx xxxx


Xxx xxx xxxxxxx xxxx xxxxxxx xxxx xxxx xxxxx xx xxxxxxx **Xxxxxxx** xxxxxxx.

![xxxxxxx xxxxxxxxxx xxx xxxx-xxx xxxxxx ](images/cortana-backgroundapp-progress-result.png)

Xxxx xxx "Xx xx &xx;xxx&xx;" xxxxx, xxx xxx xxxxxxx x xxxxxx xxxxxxxx xx xxxx xxxx xxx xxxx xxxxxxx xxxxxxx xx xxx xxx xxxxxxx. Xx xxx xxx'x xxxxxxx x xxxxxx xxxxxxxx, xxx xxxxxxx xxxx xx xxx xxxxxx xx xxxx xxx.

Xxxx, xx xxx xxx xxxxxxx xxxxx xxxx xxxxxxxxx [**XxxXxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974183) xxxxxxxxx xxxxxx xx x [**XxxxxXxxxxxxXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn974168) xxxx xxxx xx xxx [**XxxxxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn706580) xxxx xx xxx [**XxxxxXxxxxxxXxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974204) xxxxxx.

```CSharp
var userMessage = new VoiceCommandUserMessage();
userMessage.DisplayMessage = "Here are your trips.";
userMessage.SpokenMessage = 
  "You have two trips to Vegas coming up.";

var destinationsContentTiles = new List<VoiceCommandContentTile>();

var destinationTile1 = new VoiceCommandContentTile();
destinationTile1.ContentTileType = 
  VoiceCommandContentTileType.TitleWith68x68IconAndText;
destinationTile1.AppLaunchArgument = “id_Vegas_001";
destinationTile1.Title = "Las Vegas Tech Conference";
destinationTile1.TextLine1 = "May 15th 2015";
destinationsContentTiles.Add(destinationTile1);

var destinationTile2 = new VoiceCommandContentTile();
destinationTile2.ContentTileType = 
  VoiceCommandContentTileType.TitleWith68x68IconAndText;
destinationTile2.AppLaunchArgument = “id_Vegas_002";
destinationTile2.Title = "Fun in Vegas";
destinationTile2.TextLine1 = "August 24th 2015";
destinationsContentTiles.Add(destinationTile2);

var response = 
  VoiceCommandResponse.CreateResponse(userMessage, destinationsContentTiles);

response.AppLaunchArgument = “destination=Las Vegas";
    
await voiceServiceConnection.ReportSuccessAsync(response);
```

## <span id="Programmatic_deep_link">
            </span>
            <span id="programmatic_deep_link">
            </span>
            <span id="PROGRAMMATIC_DEEP_LINK">
            </span>Xxxxxxxxxxxx xxxx xxxx


Xxx xxx xxxx xxxxxxxxxxxxxxxx xxxxxx xxxx xxx xxxx x xxxxxx xxxxxxxx xx xxxx xxxx xxx xxxx xxxxxxx xxxxxxx xx xxx xxx xxxxxxx. Xx xxx xxx'x xxxxxxx x xxxxxx xxxxxxxx, xxx xxx xx xxxxxxxx xx xxx xxxx xxxxxx.

Xxxx, xx xxx xx [**XxxXxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974183) xxxxxxxxx xxxx x xxxxx xx "Xxx Xxxxx" xx x [**XxxxxXxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974182) xxxxxx xxxx xx xxx [**XxxxxxxXxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn706581) xxxx xx xxx [**XxxxxXxxxxxxXxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974204) xxxxxx.

```CSharp
var userMessage = new VoiceCommandUserMessage();
userMessage.DisplayMessage = "Here are your trips.";
userMessage.SpokenMessage = 
  "You have one trip to Vegas coming up.";

response = VoiceCommandResponse.CreateResponse(userMessage);
response.AppLaunchArgument = “Las Vegas”;
await  VoiceCommandServiceConnection.RequestAppLaunchAsync(response);
```

## <span id="App_manifest">
            </span>
            <span id="app_manifest">
            </span>
            <span id="APP_MANIFEST">
            </span>Xxx xxxxxxxx


Xx xxxxxx xxxx xxxxxxx xx xxxx xxx, xxx xxxx xxxxxxx xxx `windows.personalAssistantLaunch` xxxxxxxxx xx xxx Xxxxxxx.xxxxxxxxxxxx xxxx xx xxxx xxx xxxxxxx.

Xxxx, xx xxxxxxx xxx `windows.personalAssistantLaunch` xxxxxxxxx xxx xxx **Xxxxxxxxx Xxxxx** xxx.

```XML
<Extensions>
  <uap:Extension Category="windows.appService" 
    EntryPoint="AdventureWorks.VoiceCommands.AdventureWorksVoiceCommandService">
    <uap:AppService Name="AdventureWorksVoiceCommandService"/>
  </uap:Extension>
  <uap:Extension Category="windows.personalAssistantLaunch"/> 
</Extensions>
```

## <span id="Protocol_contract">
            </span>
            <span id="protocol_contract">
            </span>
            <span id="PROTOCOL_CONTRACT">
            </span>Xxxxxxxx xxxxxxxx


Xxxx xxx xx xxxxxxxx xx xxx xxxxxxxxxx xxxxxxx Xxxxxxx Xxxxxxxx Xxxxxxxxxx (XXX) xxxxxxxxxx xxxxx x [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224693) xxxxxxxx. Xxxx xxx xxxx xxxxxxxx xxxx xxx'x [**XxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242330) xxxxx xxx xxxxx xxx xx **XxxxxxxxxxXxxx** xx **Xxxxxxxx**. Xxx xxxx xxxx, xxx [Xxxxxx XXX xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt228339).

Xxxx, xx xxxxxx xxx XXX xxxxxxxx xx xxx [**XxxxxxxxXxxxxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224742) xx xxxxxx xxx xxxxxx xxxxxxxx. Xxx xxxx xxxxxxx, xxx [**Xxx**](https://msdn.microsoft.com/library/windows/apps/br224746) xx xxx xx "xxxxxxx.xxxxxxxxxxxxxxxxxxxxxxx:?XxxxxxXxxxxxx=Xxx Xxxxx".

```CSharp
if (args.Kind == ActivationKind.Protocol)
  {
    var commandArgs = args as ProtocolActivatedEventArgs;
    Windows.Foundation.WwwFormUrlDecoder decoder = 
      new Windows.Foundation.WwwFormUrlDecoder(commandArgs.Uri.Query);
    var destination = decoder.GetFirstValueByName("LaunchContext");

    navigationCommand = new ViewModel.TripVoiceCommand(
      "protocolLaunch",
      "text",
      "destination",
      destination);

    navigationToPageType = typeof(View.TripDetails);

    rootFrame.Navigate(navigationToPageType, navigationCommand);

    // Ensure the current window is active.
    Window.Current.Activate();
  }
```

## <span id="related_topics">
            </span>Xxxxxxx xxxxxxxx


**Xxxxxxxxxx**
* [Xxxxxxx xxxxxxxxxxxx](cortana-interactions.md)
* [**XXX xxxxxxxx xxx xxxxxxxxxx xY.Y**](https://msdn.microsoft.com/library/windows/apps/dn706593)

**Xxxxxxxxx**
* [Xxxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn974233)
* [Xxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn596121)

**Xxxxxxx**
* [Xxxxxxx xxxxx xxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=619899)
 

 




<!--HONumber=Mar16_HO1-->
