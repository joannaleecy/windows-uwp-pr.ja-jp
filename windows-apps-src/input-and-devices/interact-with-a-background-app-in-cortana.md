---
Xxxxxxxxxxx: Xxxxx xxx x xxxx xxx xxxxxxxx xxxx x xxxxxxxxxx xxx xxxxxxx xxx Xxxxxxx xxxxx xxx xxxxxx xxxxxx xxx xxxxxxxxx xx x xxxxx xxxxxxx.
xxxxx: Xxxxxxxx xxxx x xxxxxxxxxx xxx
xx.xxxxxxx: YXYYXYYX-XYYY-YYYX-YYXX-YYYYYYXXYXXY
xxxxx: Xxxxxxxx xxxx x xxxxxxxxxx xxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxxxxx xxxx x xxxxxxxxxx xxx xx Xxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**Xxxxxxx.XxxxxxxxxxxXxxxx.XxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn706594)
-   [**Xxxxx Xxxxxxx Xxxxxxxxxx (XXX) xxxxxxxx xxx xxxxxxxxxx xY.Y**](https://msdn.microsoft.com/library/windows/apps/dn706593)

Xxxxx xxx x xxxx xxx xxxxxxxx xxxx x xxxxxxxxxx xxx xxxxxxx xxx **Xxxxxxx** xxxxx xxx xxxxxx xxxxxx xxx xxxxxxxxx xx x xxxxx xxxxxxx.

Xxxxx xxxxxxxx xxxx **Xxxxxxx** xxx xxxxxxx x xxxx xxxx xxxxxxxxxx xxx xxxxxxxxxxx xxxx xxxxxx **Xxxxxxx** xxxx xx xxxxxxxxxx xx xxx xxxxxxxxxx xxx. Xxx xxx xxx xxxxxxx x xxxxxx xx xxxxxxxxx xxxxx xx xxxxxxx xx xxxxxxx xxxxxxxxxxxxx xxxx xxxxxxxx:

-   Xxxxxxxxxx xxxxxxxxxx
-   Xxxx-xxx
-   Xxxxxxxx
-   Xxxxxxxxxxxx
-   Xxxxxxxxxxxxxx
-   Xxxxx

**Xxxxxxxxxxxxx:  **

Xxxx xxxxx xxxxxx xx [Xxxxxx x xxxxxxxxxx xxx xxxx xxxxx xxxxxxxx xx Xxxxxxx](launch-a-background-app-with-voice-commands-in-cortana.md). Xx xxxxxxxx xxxx xx xxxxxxxxxxx xxxxxxxx xxxx x xxxx xxxxxxxx xxx xxxxxxxxxx xxx xxxxx **Xxxxxxxxx Xxxxx**.

Xx xxx'xx xxx xx xxxxxxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx, xxxx x xxxx xxxxxxx xxxxx xxxxxx xx xxx xxxxxxxx xxxx xxx xxxxxxxxxxxx xxxxxxxxx xxxx.

-   [Xxxxxx xxxx xxxxx xxx](https://msdn.microsoft.com/library/windows/apps/bg124288)
-   Xxxxx xxxxx xxxxxx xxxx [Xxxxxx xxx xxxxxx xxxxxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt185584)

**Xxxx xxxxxxxxxx xxxxxxxxxx:  **

Xxx [Xxxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn974233) xxx xxxx xxxxx xxx xx xxxxxxxxx xxxx xxx xxxx **Xxxxxxx** xxx [Xxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn596121) xxx xxxxxxx xxxx xx xxxxxxxxx x xxxxxx xxx xxxxxxxx xxxxxx-xxxxxxx xxx.

## <span id="Completion_screen">
            </span>
            <span id="completion_screen">
            </span>
            <span id="COMPLETION_SCREEN">
            </span>Xxxxxxxxxx xxxxxx


X xxxxxxxxxx xxxxxx xxxxxxxx xxx xxxx xxxx xxxxxxxxxxx xxxxx xxx xxxxxxxxx xxxxx xxxxxxx xxxx.

Xxxxx xxxx xxxx xxxx xxxx YYY xxxxxxxxxxxx xxx xxxx xxx xx xxxxxxx, xxx xxxxxxx xx xxxxxxxxxx xxxxxxxxxxx xxxx xxx xxxx, xxx xx xxxxxxxxx xxxxxxx xxxxxxx xxxxxxxxxxxxx xxxx **Xxxxxxx**, xxxxx xxxx xxxxxxxxxx xxx xxxxxxxxxx xxxxxx.

Xxxx, xx xxxx xxx **Xxxxxxx** xxx xxxxxxx x xxxxxxxxxxxx xxxxxx xxxx xxx **Xxxxxxxxx Xxxxx** xxx xxx xx xxxxxxxx xxxx xx Xxx Xxxxx.

![xxxxxxx xxxxxxxxxx xxx xxxxxxxxxx xxxxxx](images/cortana-completion-screen.png)

1.  **Xxxxxx xxx xxxxxxxx xxxxxxx xx xx xxxxxxxxx xxx xxxxxx xx Xxxxxxx**

    Xxxxxx xxx [Xxxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn974233) xxx xxxxxxxxxxxxxxx xx xxxxxxxxx xxxxxxx xxxx **Xxxxxxx** xxxxx xxx xxxxxx.

2.  **Xxxxxx xxxxxxx xxxxx xxxxx xx xxx xxxxxx xxxxxxxxx (xxxxxxxx)**

    Xxxxxxx xxxxx xxx xxxxxxx xxxxxxxxxx xxxxxxx xxx xxx xxxx xxx xxxx xxxx xxx xxxxxxxx xxxxxxx xxxxxxx.

    **Xxxxxxx** xxxxxxxx xxx xxxxxxxxx xxxxxxx xxxx xxxxxxxxx (xxxx xxx xxxxxxxx xxx xx xxxx xx xxx xxxxxxxxxx xxxxxx):

    -   Xxxxx xxxx
    -   Xxxxx xxxx xx xx xxxxx xxxxx xx xxxx
    -   Xxxxx xxxx xxxx
    -   Xxxxx xxxx xxxx xxx xx xx xxxxx xxxxx xx xxxx

    Xxx xxxx xxx xx:

    -   YYx x YYx
    -   YYx x YYx
    -   YYYx x YYYx

    Xxx xxx xxxx xxx xxxxx xxxxxx xxxx xxx xx xxx xxxxxxxxxx xx xxxxxx xxxxxxx x xxxx xx xxx xxxx xxxx xx xxxx xxx.

3.  **Xxxx xxx xxxxxxxxxx xxxxxxxxxx xxxxxx**

    Xxxx'x xx xxxxxxx xx x xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xxxxxxxx xxxxxxx xxxxx.

```    CSharp
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

    response.AppLaunchArgument = “Las Vegas";
        
    await voiceServiceConnection.ReportSuccessAsync(response);
```

## <span id="Hand-off_screen">
            </span>
            <span id="hand-off_screen">
            </span>
            <span id="HAND-OFF_SCREEN">
            </span>Xxxx-xxx xxxxxx


Xxxx x xxxxx xxxxxxx xx xxxxxxxxxx, **Xxxxxxx** xxxx xxxxxxx xxxxxxxx xxxxxx xxxxxxxxxxxxx YYY xxxxxxxxxxxx. Xx xxx xxx xxxxxxx xxxxxx xxxxxxxx xxx xxxxxx xxxxxxxxx xx xxx xxxxx xxxxxxx xxxxxx YYYxx, **Xxxxxxx** xxxxxxxx x xxxx-xxx xxxxxx xxxx xx xxxxx xxx xx xx Y xxxxxxx.

Xxx xxx xxxx xxx xxxx xxx xxxxxxxxx xx xxx xxxx-xxx xxxxxx, xxx xxx xxxx xxxxxxx xxxx XXX xxx xxxx-xx-xxxxxx (XXX) xxxxxxx xxxxxxx xx xxxxxxxx xxxx xxx xxxxx xxxxxxx xxx xxxxxxxxx xxxxxxxxxx.

Xxxx'x xx xxxxxxx xx x xxxx-xxx xxxxxx xxx xxx **Xxxxxxxxx Xxxxx** xxx. Xx xxxx xxxxxxx, x xxxx xxx xxxxxxx **Xxxxxxx** xxx xxxxxxxx xxxxx. Xxx xxxx-xxx xxxxxx xxxxxxxx x xxxxxxx xxxxxxxxxx xxxx xxx xxx xxxxxxx xxxx, xx xxxx, xxx xxx **Xxxxxxxx** xxxxxx xxxxxxxx xx xxx XXX xxxx.

![xxxxxxx xxxxxxxxxx xxx xxxx-xxx xxxxxx](images/cortana-backgroundapp-progress-result.png)

## <span id="Progress_screen">
            </span>
            <span id="progress_screen">
            </span>
            <span id="PROGRESS_SCREEN">
            </span>Xxxxxxxx xxxxxx


Xx xxx xxx xxxxxxx xxxxx xxxx xxxx YYYxx xxxxxxx xxxxx, **Xxxxxxx** xxxxxxx xxx xxxx xx xxxx’x xxxxxxxxx xxxx x xxxxxxxx xxxxxx. Xxx xxx xxxx xx xxxxxxxxx, xxx xxx xxxx xxxxxxx xxxx XXX xxx XXX xxxxxxxx xxxxxxx xx xxxxxxxx xxxx xxx xxxx xx xxxxx xxxxxxxx xxxxxxx.

**Xxxxxxx** xxxxx x xxxxxxxx xxxxxx xxx x xxxxxxx xx Y xxxxxxx. Xxxxx Y xxxxxxx, **Xxxxxxx** xxxxxxxx xxx xxxx xxxx xx xxxxx xxxxxxx xxx xxx xxx xxxxxxx xx xxxxxx. Xx xxx xxx xxxxxxx xxxxx xxxx xxxx Y xxxxxxx xx xxxxxxxx xxx xxxxxx, xx xxx xxxxxxxx xx xxxxxx **Xxxxxxx** xxxx xxxxxxxx xxxxxxx.

Xxxx'x xx xxxxxxx xx x xxxx-xxx xxxxxx xxx xxx **Xxxxxxxxx Xxxxx** xxx. Xx xxxx xxxxxxx, x xxxx xxx xxxxxxxx x xxxx xx Xxx Xxxxx xxxxxxx **Xxxxxxx**. Xxx xxxxxxxx xxxxxx xxxxxxxx x xxxxxxx xxxxxxxxxx xxx xxx xxxxxx, xx xxxx, xxx x xxxxxxx xxxx xxxx xxxxxxxxxxx xxxxx xxx xxxx xxxxx xxxxxxxx.

![xxxxxxx xxxxxxxxxx xxx xxxxxxxx xxxxxx ](images/cortana-progress-screen.png)

1.  **Xxxxxx xxx xxxxxxxx xxxxxxx xx xx xxxxxxxxx xxx xxxxxx xx Xxxxxxx**

    Xxxxxx xxx [Xxxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn974233) xxx xxxxxxxxxxxxxxx xx xxxxxxxxx xxxxxxx xxxx **Xxxxxxx** xxxxx xxx xxxxxx.

2.  **Xxxxxx xxxxxxx xxxxx xxxxx xx xxx xxxxxx xxxxxxxxx (xxxxxxxx)**

    Xxxxxxx xxxxx xxx xxxxxxx xxxxxxxxxx xxxxxxx xxx xxx xxxx xxx xxxx xxxx xxx xxxxxxxx xxxxxxx xxxxxxx.

    **Xxxxxxx** xxxxxxxx xxx xxxxxxxxx xxxxxxx xxxx xxxxxxxxx (xxxx xxx xxxxxxxx xxx xx xxxx xx xxx xxxxxxxxxx xxxxxx):

    -   Xxxxx xxxx
    -   Xxxxx xxxx xx xx xxxxx xxxxx xx xxxx
    -   Xxxxx xxxx xxxx
    -   Xxxxx xxxx xxxx xxx xx xx xxxxx xxxxx xx xxxx

    Xxx xxxx xxx xx:

    -   YYx x YYx
    -   YYx x YYx
    -   YYYx x YYYx

    Xxx xxx xxxx xxx xxxxx xxxxxx xxxx xxx xx xxx xxxxxxxxxx xx xxxxxx xxxxxxx x xxxx xx xxx xxxx xxxx xx xxxx xxx.

3.  **Xxxxx xxx xxxxxxxx**

    Xxxx [**XxxxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn706579) xx xxxx xxx xxxxxxxx xxxxxx xx **Xxxxxxx**.

4.  **Xxxx xxx xxxxxxxx xxxxxx**

    Xxxx'x xx xxxxxxx xx x xxxxxxxx xxxxxx xxxx x xxxxxxx xxxx.

```    CSharp
var userMessage = new VoiceCommandUserMessage();

    var destinationsContentTiles = new List<VoiceCommandContentTile>();

    destinationsContentTiles.Add(selectedDestination);

    var response = 
      VoiceCommandResponse.CreateResponse(userMessage, destinationsContentTiles);

    response.AppLaunchArgument = "destination=Las Vegas";
    await voiceServiceConnection.ReportProgressAsync(response);
```

## <span id="Confirmation_screen">
            </span>
            <span id="confirmation_screen">
            </span>
            <span id="CONFIRMATION_SCREEN">
            </span>Xxxxxxxxxxxx xxxxxx


Xxxx xx xxxxxx xxxxxxxxx xx x xxxxx xxxxxxx xx xxxxxxxxxxxx, xxx x xxxxxxxxxxx xxxxxx, xx xxx xxxxxxxxxxx xxxxxxxxxx xx xxx xxxx, xx xxx xxxxxxx xxx xxxxxxx xxxxxxxxxxxx.

Xxxx'x xx xxxxxxx xx x xxxxxxxxxxxx xxxxxx xxx xxx **Xxxxxxxxx Xxxxx** xxx. Xx xxxx xxxxxxx, x xxxx xxx xxxxxxxxxx xxx xxx xxxxxxx xx xxxxxx x xxxx xx Xxx Xxxxx xxxxxxx **Xxxxxxx**. Xxx xxx xxxxxxx xxx xxxxxxxx **Xxxxxxx** xxxx x xxxxxxxxxxxx xxxxxx xxxx xxxxxxx xxx xxxx xxx x xxx xx xx xxxxxx xxxxxx xxxxxxxxx xxx xxxx.

Xx xxx xxxx xxxx xxxxxxxxx xxxxx xxxx "Xxx" xx "Xx", **Xxxxxxx** xxxxxx xxxxxxxxx xxx xxxxxx xx xxx xxxxxxxx. Xx xxxx xxxx, **Xxxxxxx** xxxxxxx xxx xxxx xxxx x xxxxxxx xxxxxxxx xxxxxxxx xx xxx xxx xxxxxxx.

Xx xxx xxxxxx xxxxxx, xx xxx xxxx xxxxx xxxxx’x xxx "Xxx" xx "Xx", **Xxxxxxx** xxxxxxx xxx xxxx x xxxxx xxxx xxxx xxx xxxx xxxxxxxx xxxxxxxx xxxx xx xxxxxxx. Xx xxx xxxx xxxxx xxxxx’x xxx "Xxx" xx "Xx", **Xxxxxxx** xxxxx xxxxxxxxx xxx xxxxx xxxxx xxx xxxx xxx xxxx xx xxx xxx xx xxx xxxxxxx xxxxxxx.

Xxx xxxxxxxxxxxx xxxxxx xxxxxxxx x xxxxxxx xxxxxxxxxx xxx xxx xxxxxx, xx xxxx, xxx x xxxxxxx xxxx xxxx xxxxxxxxxxx xxxxx xxx xxxx xxxxx xxxxxxxx.

![xxxxxxx xxxxxxxxxx xxx xxxxxxxxxxxx xxxxxx](images/cortana-confirmation-screen.png)

1.  **Xxxxxx xxx xxxxxxxx xxxxxxx xx xx xxxxxxxxx xxx xxxxxx xx Xxxxxxx**

    Xxxxxx xxx [Xxxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn974233) xxx xxxxxxxxxxxxxxx xx xxxxxxxxx xxxxxxx xxxx **Xxxxxxx** xxxxx xxx xxxxxx.

2.  **Xxxxxx xxxxxxx xxxxx xxxxx xx xxx xxxxxx xxxxxxxxx (xxxxxxxx)**

    Xxxxxxx xxxxx xxx xxxxxxx xxxxxxxxxx xxxxxxx xxx xxx xxxx xxx xxxx xxxx xxx xxxxxxxx xxxxxxx xxxxxxx.

    **Xxxxxxx** xxxxxxxx xxx xxxxxxxxx xxxxxxx xxxx xxxxxxxxx (xxxx xxx xxxxxxxx xxx xx xxxx xx xxx xxxxxxxxxx xxxxxx):

    -   Xxxxx xxxx
    -   Xxxxx xxxx xx xx xxxxx xxxxx xx xxxx
    -   Xxxxx xxxx xxxx
    -   Xxxxx xxxx xxxx xxx xx xx xxxxx xxxxx xx xxxx

    Xxx xxxx xxx xx:

    -   YYx x YYx
    -   YYx x YYx
    -   YYYx x YYYx

    Xxx xxx xxxx xxx xxxxx xxxxxx xxxx xxx xx xxx xxxxxxxxxx xx xxxxxx xxxxxxx x xxxx xx xxx xxxx xxxx xx xxxx xxx.

3.  **Xxxxx xxx xxxxxxxx**

    Xxxx [**XxxxxxxXxxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn706582) xx xxxx xxx xxxxxxxxxxxx xxxxxx xx **Xxxxxxx**.

4.  **Xxxx xxx xxxxxxxxxxxx xxxxxx**

    Xxxx'x xx xxxxxxx xx x xxxxxxxxxxxx xxxxxx xxxx x xxxxxxx xxxx.

```    CSharp
var userPrompt = new VoiceCommandUserMessage();
    userPrompt.DisplayMessage = userPrompt.SpokenMessage = 
      "Are you sure you want to cancel the trip to Las Vegas?”;

    var userReprompt = new VoiceCommandUserMessage();
    userReprompt.DisplayMessage = 
      userReprompt.SpokenMessage = "Do you want to cancel this trip to Las Vegas?"; 

    userPrompt.DisplayMessage = “Cancel this trip?”;
    userPrompt.SpokenMessage ="Do you wanna cancel this trip to Vegas?”;

    var userReprompt = new VoiceCommandUserMessage();
    userReprompt.DisplayMessage = “Did you want to cancel this trip?”;
    userReprompt.SpokenMessage = "Did you wanna cancel this trip?"; 

    var destinationsContentTiles = new List<VoiceCommandContentTile>();

    var destinationTile = new VoiceCommandContentTile();
    destinationTile.ContentTileType = 
      VoiceCommandContentTileType.TitleWith68x68IconAndText;
    destinationTile.Title = "Vegas Tech Conference";

    destinationTile.TextLine1 = "May 15th";


    destinationsContentTiles.Add(destinationTile);

    var response = 
      VoiceCommandResponse.CreateResponseForPrompt(
        userPrompt, userReprompt, destinationsContentTiles);

    var voiceCommandConfirmation = 
      await voiceServiceConnection.RequestConfirmationAsync(response);

    if (voiceCommandConfirmation != null)
    {
       // Use the voiceCommandConfirmation.Confirmed to take action.
       // Call Cortana to present the next screen in .5 seconds 
       // and avoid a transition screen.
    }
```

## <span id="Disambiguation_screen">
            </span>
            <span id="disambiguation_screen">
            </span>
            <span id="DISAMBIGUATION_SCREEN">
            </span>Xxxxxxxxxxxxxx xxxxxx


Xxxx xx xxxxxx xxxxxxxxx xx x xxxxx xxxxxxx xxx xxxx xxxx xxx xxxxxxxx xxxxxxx, xx xxx xxxxxxx xxx xxxxxxx xxxx xxxx xxxx xxx xxxx.

Xxxx'x xx xxxxxxx xx x xxxxxxxxxxxxxx xxxxxx xxx xxx **Xxxxxxxxx Xxxxx** xxx. Xx xxxx xxxxxxx, x xxxx xxx xxxxxxxxxx xxx xxx xxxxxxx xx xxxxxx x xxxx xx Xxx Xxxxx xxxxxxx **Xxxxxxx**. Xxxxxxx, xxx xxxx xxx xxx xxxxx xx Xxx Xxxxx xx xxxxxxxxx xxxxx xxx xxx xxx xxxxxxx xxxxxx xxxxxxxx xxx xxxxxx xxxxxxx xxx xxxx xxxxxxxxx xxx xxxxxxxx xxxx.

Xxx xxx xxxxxxx xxxxxxxx **Xxxxxxx** xxxx x xxxxxxxxxxxxxx xxxxxx xxxx xxxxxxx xxx xxxx xx xxxx x xxxxxxxxx xxxx x xxxx xx xxxxxxxx xxxxx, xxxxxx xx xxxxxxx xxx.

Xx xxxx xxxx, **Xxxxxxx** xxxxxxx xxx xxxx xxxx x xxxxxxx xxxxxxxx xxxxxxxx xx xxx xxx xxxxxxx.

Xx xxx xxxxxx xxxxxx, xx xxx xxxx xxxxx xxxxx’x xxx xxxxxxxxx xxxx xxx xx xxxx xx xxxxxxxx xxx xxxxxxxxx, **Xxxxxxx** xxxxxxx xxx xxxx x xxxxx xxxx xxxx xxx xxxx xxxxxxxx xxxxxxxx xxxx xx xxxxxxx. Xx xxx xxxx xxxxx xxxxx’x xxx xxxxxxxxx xxxx xxx xx xxxx xx xxxxxxxx xxx xxxxxxxxx, **Xxxxxxx** xxxxx xxxxxxxxx xxx xxxxx xxxxx xxx xxxx xxx xxxx xx xxx xxx xx xxx xxxxxxx xxxxxxx.

Xxx xxxxxxxxxxxxxx xxxxxx xxxxxxxx x xxxxxxx xxxxxxxxxx xxx xxx xxxxxx, xx xxxx, xxx x xxxxxxx xxxx xxxx xxxxxxxxxxx xxxxx xxx xxxx xxxxx xxxxxxxx.

![xxxxxxx xxxxxxxxxx xxx xxxxxxxxxxxxxx xxxxxx ](images/cortana-disambiguation-screen.png)

1.  **Xxxxxx xxx xxxxxxxx xxxxxxx xx xx xxxxxxxxx xxx xxxxxx xx Xxxxxxx**

    Xxxxxx xxx [Xxxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn974233) xxx xxxxxxxxxxxxxxx xx xxxxxxxxx xxxxxxx xxxx **Xxxxxxx** xxxxx xxx xxxxxx.

2.  **Xxxxxx xxxxxxx xxxxx xxxxx xx xxx xxxxxx xxxxxxxxx (xxxxxxxx)**

    Xxxxxxx xxxxx xxx xxxxxxx xxxxxxxxxx xxxxxxx xxx xxx xxxx xxx xxxx xxxx xxx xxxxxxxx xxxxxxx xxxxxxx.

    **Xxxxxxx** xxxxxxxx xxx xxxxxxxxx xxxxxxx xxxx xxxxxxxxx (xxxx xxx xxxxxxxx xxx xx xxxx xx xxx xxxxxxxxxx xxxxxx):

    -   Xxxxx xxxx
    -   Xxxxx xxxx xx xx xxxxx xxxxx xx xxxx
    -   Xxxxx xxxx xxxx
    -   Xxxxx xxxx xxxx xxx xx xx xxxxx xxxxx xx xxxx

    Xxx xxxx xxx xx:

    -   YYx x YYx
    -   YYx x YYx
    -   YYYx x YYYx

    Xxx xxx xxxx xxx xxxxx xxxxxx xxxx xxx xx xxx xxxxxxxxxx xx xxxxxx xxxxxxx x xxxx xx xxx xxxx xxxx xx xxxx xxx.

3.  **Xxxxx xxx xxxxxxxx**

    Xxxx [**XxxxxxxXxxxxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn706583) xx xxxx xxx xxxxxxxxxxxxxx xxxxxx xx **Xxxxxxx**.

4.  **Xxxx xxx xxxxxxxxxxxxxx xxxxxx**

    Xxxx'x xx xxxxxxx xx x xxxxxxxxxxxxxx xxxxxx xxxx xxxxxxx xxxxx.

```    CSharp
// Create a VoiceCommandUserMessage for the initial question.  
    var userPrompt = new VoiceCommandUserMessage();
    userPrompt.DisplayMessage = "Which one do you want to cancel?";
    userPrompt.SpokenMessage = 
      “Which Vegas trip do you wanna cancel? Vegas Tech Conference or Fun in Vegas?”;


    // Create a VoiceCommandUserMessage for the second question,
    // in case Cortana needs to reprompt. 
    var userReprompt = new VoiceCommandUserMessage();
    userReprompt.DisplayMessage = “Which one did you want to cancel?”;
    userReprompt.SpokenMessage = "Which one did you wanna to cancel?";

    // Create the list of content tiles to show the selection items.
    var destinationsContentTiles = new List<VoiceCommandContentTile>();

    var destinationTile = new VoiceCommandContentTile();
    destinationTile.ContentTileType = 
      VoiceCommandContentTileType.TitleWith68x68IconAndText;
      
    // The AppContext is optional. 
    // Replace this value with something specific to your app. 
    destinationTile.AppContext = "id_Vegas_001";
    destinationTile.Title = "Vegas Tech Conference";

    destinationTile.TextLine1 = "May 15th";


    destinationsContentTiles.Add(destinationTile);

    var destination2 = new VoiceCommandContentTile();
    destination2.ContentTileType = 
      VoiceCommandContentTileType.TitleWith68x68IconAndText;
    // The AppContext is optional. 
    // Replace this value with something specific to your app. 
    destination2.AppContext = "id_LasVegas_002";

    destination2.Title = "Fun in Vegas";

    destination2.TextLine1 = "August 24th";

    destinationsContentTiles.Add(destination2);

    // Create the disambiguation response.
    var response = 
      VoiceCommandResponse.CreateResponseForPrompt(
        userPrompt, userReprompt, destinationsContentTiles);

    // Request that Cortana shows the Disambiguation screen.
    var voiceCommandDisambiguationResult = 
      await voiceServiceConnection.RequestDisambiguationAsync(response);

    if (voiceCommandDisambiguationResult != null)
    {
       // Use the voiceCommandDisambiguationResult.SelectedItem to take action.
       // Call Cortana to present the next screen in .5 seconds   
       // and avoid a transition screen. 
    }
```

## <span id="Error_screen">
            </span>
            <span id="error_screen">
            </span>
            <span id="ERROR_SCREEN">
            </span>Xxxxx xxxxxx


Xxxx xx xxxxxx xxxxxxxxx xx x xxxxx xxxxxxx xxxxxx xx xxxxxxxxx, xx xxx xxxxxxx xxx xxxxxxx xx xxxxx xxxxxx.

Xxxx'x xx xxxxxxx xx xx xxxxx xxxxxx xxx xxx **Xxxxxxxxx Xxxxx** xxx. Xx xxxx xxxxxxx, x xxxx xxx xxxxxxxxxx xxx xxx xxxxxxx xx xxxxxx x xxxx xx Xxx Xxxxx xxxxxxx **Xxxxxxx**. Xxxxxxx, xxx xxxx xxxx xxx xxxx xxx xxxxx xxxxxxxxx xx Xxx Xxxxx.

Xxx xxx xxxxxxx xxxxxxxx **Xxxxxxx** xxxx xx xxxxx xxxxxx xxxx xxxxxxxx x xxxxxxx xxxxxxxxxx xxx xxx xxxxxx, xx xxxx, xxx xxx xxxxxxxx xxxxx xxxxxxx.

1.  **Xxxxxx xxx xxxxxxxx xxxxxxx xx xx xxxxxxxxx xxx xxxxxx xx Xxxxxxx**

    Xxxxxx xxx [Xxxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn974233) xxx xxxxxxxxxxxxxxx xx xxxxxxxxx xxxxxxx xxxx **Xxxxxxx** xxxxx xxx xxxxxx.

2.  **Xxxxxx xxxxxxx xxxxx xxxxx xx xxx xxxxxx xxxxxxxxx (xxxxxxxx)**

    Xxxxxxx xxxxx xxx xxxxxxx xxxxxxxxxx xxxxxxx xxx xxx xxxx xxx xxxx xxxx xxx xxxxxxxx xxxxxxx xxxxxxx.

    **Xxxxxxx** xxxxxxxx xxx xxxxxxxxx xxxxxxx xxxx xxxxxxxxx (xxxx xxx xxxxxxxx xxx xx xxxx xx xxx xxxxxxxxxx xxxxxx):

    -   Xxxxx xxxx
    -   Xxxxx xxxx xx xx xxxxx xxxxx xx xxxx
    -   Xxxxx xxxx xxxx
    -   Xxxxx xxxx xxxx xxx xx xx xxxxx xxxxx xx xxxx

    Xxx xxxx xxx xx:

    -   YYx x YYx
    -   YYx x YYx
    -   YYYx x YYYx

    Xxx xxx xxxx xxx xxxxx xxxxxx xxxx xxx xx xxx xxxxxxxxxx xx xxxxxx xxxxxxx x xxxx xx xxx xxxx xxxx xx xxxx xxx.

3.  **Xxxxx xxx xxxxxxxx**

    Xxxx [**XxxxxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn706578) xx xxxx xxx xxxxx xxxxxx xx **Xxxxxxx**.

4.  **Xxxx xxx xxxxx xxxxxx**

    Xxxx'x xx xxxxxxx xx xx xxxxx xxxxxx.

```    CSharp
var userMessage = new VoiceCommandUserMessage();
    userMessage.DisplayMessage = userMessage.SpokenMessage = 
      "Sorry, you don&#39;t have any trips to Las Vegas";
                
    var response = VoiceCommandResponse.CreateResponse(userMessage);

    response.AppLaunchArgument = "showUpcomingTrips";
    await voiceServiceConnection.ReportFailureAsync(response);
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
