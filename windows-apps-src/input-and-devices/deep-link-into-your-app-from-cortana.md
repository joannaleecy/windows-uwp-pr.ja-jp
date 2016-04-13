---
Description: Cortana でバックグラウンド アプリのサービスからのディープ リンクを提供し、フォアグラウンドに特定の状態やコンテキストでアプリを起動します。
title: Cortana からバックグラウンド アプリへのディープ リンク
ms.assetid: BE811A87-8821-476A-90E4-2E20D37E4043
label: Deep link to a background app
template: detail.hbs
---

# Cortana からバックグラウンド アプリへのディープ リンク


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


**重要な API**

-   [**Windows.ApplicationModel.VoiceCommands**](https://msdn.microsoft.com/library/windows/apps/dn706594)
-   [**音声コマンド定義 (VCD) の要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)

**Cortana** でバックグラウンド アプリからのディープ リンクを提供し、フォアグラウンドに特定の状態やコンテキストでアプリを起動します。

> **注**  
フォアグラウンド アプリが起動すると、**Cortana** とバックグラウンド アプリ サービスはいずれも終了します。

既定では、ディープ リンクは、ここに示されているように **Cortana** の完了画面 ("AdventureWorks に移動") に表示されますが、他のさまざまな画面にもディープ リンクを表示できます。 

![Cortana のバックグラウンド アプリの完了画面](images/cortana-completion-screen-upcomingtrip-small.png)

**前提条件:  **

このトピックは、「[Cortana でのバックグラウンド アプリの操作](interact-with-a-background-app-in-cortana.md)」に基づいています。 引き続き **Adventure Works** という旅行の計画および管理アプリを使って、**Cortana** のさまざまな機能について説明します。

ユニバーサル Windows プラットフォーム (UWP) アプリを開発するのが初めての場合は、以下のトピックに目を通して、ここで説明されているテクノロジをよく理解できるようにしてください。

-   [初めてのアプリ作成](https://msdn.microsoft.com/library/windows/apps/bg124288)
-   「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」でイベントについて学習します。

**ユーザー エクスペリエンス ガイドライン:  **

アプリと **Cortana** を統合する方法については「[Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)」を、魅力的な音声認識対応アプリの設計に役立つ便利なヒントについては「[音声機能の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)」をご覧ください。

## <span id="Overview"></span><span id="overview"></span><span id="OVERVIEW"></span>概要


ユーザーは、次のような方法で **Cortana** 経由でアプリにアクセスできます。

-   アプリをフォアグラウンド アプリとしてアクティブ化する (「[Cortana の音声コマンドを使ったフォアグラウンド アプリのアクティブ化](launch-a-foreground-app-with-voice-commands-in-cortana.md)」をご覧ください)。
-   特定の機能をバックグラウンド アプリ サービスとして公開する (「[Cortana の音声コマンドを使ったバックグラウンド アプリのアクティブ化](launch-a-background-app-with-voice-commands-in-cortana.md)」をご覧ください)。
-   特定のページ、コンテンツ、状態やコンテキストへのディープ リンク。

ここでは、ディープ リンクについて説明します。

ディープ リンクは、(スタート メニューからアプリを起動することをユーザーに要求する代わりに) Cortana とアプリ サービスがすべての機能を備えたアプリへのゲートウェイとなっている場合や、Cortana 経由では不可能なアプリ内の充実した詳細情報や機能へのアクセスを提供する場合に便利です。 ディープ リンクは、操作性を向上させ、アプリを宣伝するためのもう 1 つの方法です。

ディープ リンクを提供するには、3 つの方法があります。

-   さまざまな **Cortana** 画面にある "&lt;アプリ&gt; に移動" リンク。
-   さまざまな **Cortana** 画面のコンテンツ タイルに埋め込まれているリンク。
-   プログラムによるバックグラウンド アプリ サービスからのフォアグラウンド アプリの起動。

## <span id="Go_to__app__deep_link"></span><span id="go_to__app__deep_link"></span><span id="GO_TO__APP__DEEP_LINK"></span>"&lt;アプリ&gt; に移動" ディープ リンク


**Cortana** では、ほとんどの画面のコンテンツ カードの下に "&lt;アプリ&gt; に移動" ディープ リンクが表示されます。

![Cortana のバックグラウンド アプリの完了画面](images/cortana-completion-screen.png)

このリンクに、アプリ サービスと同様のコンテキストでアプリを開く起動引数を指定できます。 起動引数を指定しない場合、アプリはメイン画面で起動されます。

この例では、指定した目的地をサンプルの **AdventureWorks** の AdventureWorksVoiceCommandService.cs から SendCompletionMessageForDestination メソッドに渡します。このメソッドは、一致するすべての旅行を受け取り、アプリへのディープ リンクを提供します。

最初に、**Cortana** に話させ、**Cortana** キャンバスに表示する [**VoiceCommandUserMessage**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.voicecommands.voicecommandusermessage.aspx) (```userMessage```) を作成します。 結果のカード コレクションをキャンバスに表示するための [**VoiceCommandContentTile**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.voicecommands.voicecommandcontenttile.aspx) リスト オブジェクトが作成されます。 

これら 2 つのオブジェクトが [**VoiceCommandResponse**](https://msdn.microsoft.com/library/windows/apps/dn974182) オブジェクトの [CreateResponse](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.voicecommands.voicecommandresponse.createresponse.aspx)メソッド (```response```) に渡されます。 次に、[**AppLaunchArgument**](https://msdn.microsoft.com/library/windows/apps/dn974183) プロパティの値を音声コマンドの目的地の値に設定します。

最後に、[**VoiceCommandServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn974204) の [**ReportSuccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn706580) メソッドを呼び出します。

```csharp
/// <summary>
/// Show details for a single trip, if the trip can be found. 
/// This demonstrates a simple response flow in Cortana.
/// </summary>
/// <param name="destination">The destination specified in the voice command.</param>
private async Task SendCompletionMessageForDestination(string destination)
{
...
    IEnumerable<Model.Trip> trips = store.Trips.Where(p => p.Destination == destination);

    var userMessage = new VoiceCommandUserMessage();
    var destinationsContentTiles = new List<VoiceCommandContentTile>();
...
    var response = VoiceCommandResponse.CreateResponse(userMessage, destinationsContentTiles);

    if (trips.Count() > 0)
    {
        response.AppLaunchArgument = destination;
    }

    await voiceServiceConnection.ReportSuccessAsync(response);
}
```


## <span id="Content_tile_deep_link"></span><span id="content_tile_deep_link"></span><span id="CONTENT_TILE_DEEP_LINK"></span>コンテンツ タイルのディープ リンク


ディープ リンクは、さまざまな **Cortana** 画面にあるコンテンツ カードに追加できます。

![Cortana のバックグラウンド アプリのハンドオフ画面 ](images/cortana-backgroundapp-progress-result.png)

"&lt;アプリ&gt; に移動" リンクと同様に、アプリ サービスと同様のコンテキストでアプリを開くために、起動引数を指定できます。 起動引数を指定しない場合、コンテンツ タイルはアプリにリンクされません。

この例では、指定した目的地をサンプルの **AdventureWorks** の AdventureWorksVoiceCommandService.cs から SendCompletionMessageForDestination メソッドに渡します。このメソッドは、一致するすべての旅行を受け取り、アプリへのディープ リンクをコンテンツ カードに提供します。

最初に、**Cortana** に話させ、**Cortana** キャンバスに表示する [**VoiceCommandUserMessage**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.voicecommands.voicecommandusermessage.aspx) (```userMessage```) を作成します。 結果のカード コレクションをキャンバスに表示するための [**VoiceCommandContentTile**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.voicecommands.voicecommandcontenttile.aspx) リスト オブジェクトが作成されます。 

これら 2 つのオブジェクトが [**VoiceCommandResponse**](https://msdn.microsoft.com/library/windows/apps/dn974182) オブジェクトの [CreateResponse](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.voicecommands.voicecommandresponse.createresponse.aspx)メソッド (```response```) に渡されます。 次に、[**AppLaunchArgument**](https://msdn.microsoft.com/library/windows/apps/dn974183) プロパティの値を音声コマンドの目的地の値に設定します。

最後に、[**VoiceCommandServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn974204) の [**ReportSuccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn706580) メソッドを呼び出します。
ここでは、[**VoiceCommandServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn974204) オブジェクトの [**ReportSuccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn706580) の呼び出しで使用される [**VoiceCommandContentTile**](https://msdn.microsoft.com/library/windows/apps/dn974168) リストに、異なる [**AppLaunchArgument**](https://msdn.microsoft.com/library/windows/apps/dn974183) パラメーター値を持つ 2 つのコンテンツ タイルを追加します。

```csharp
/// <summary>
/// Show details for a single trip, if the trip can be found. 
/// This demonstrates a simple response flow in Cortana.
/// </summary>
/// <param name="destination">The destination specified in the voice command.</param>
private async Task SendCompletionMessageForDestination(string destination)
{
    // If this operation is expected to take longer than 0.5 seconds, the task must
    // supply a progress response to Cortana before starting the operation, and
    // updates must be provided at least every 5 seconds.
    string loadingTripToDestination = string.Format(
               cortanaResourceMap.GetValue("LoadingTripToDestination", cortanaContext).ValueAsString,
               destination);
    await ShowProgressScreen(loadingTripToDestination);
    Model.TripStore store = new Model.TripStore();
    await store.LoadTrips();

    // Query for the specified trip. 
    // The destination should be in the phrase list. However, there might be  
    // multiple trips to the destination. We pick the first.
    IEnumerable<Model.Trip> trips = store.Trips.Where(p => p.Destination == destination);

    var userMessage = new VoiceCommandUserMessage();
    var destinationsContentTiles = new List<VoiceCommandContentTile>();
    if (trips.Count() == 0)
    {
        string foundNoTripToDestination = string.Format(
               cortanaResourceMap.GetValue("FoundNoTripToDestination", cortanaContext).ValueAsString,
               destination);
        userMessage.DisplayMessage = foundNoTripToDestination;
        userMessage.SpokenMessage = foundNoTripToDestination;
    }
    else
    {
        // Set plural or singular title.
        string message = "";
        if (trips.Count() > 1)
        {
            message = cortanaResourceMap.GetValue("PluralUpcomingTrips", cortanaContext).ValueAsString;
        }
        else
        {
            message = cortanaResourceMap.GetValue("SingularUpcomingTrip", cortanaContext).ValueAsString;
        }
        userMessage.DisplayMessage = message;
        userMessage.SpokenMessage = message;

        // Define a tile for each destination.
        foreach (Model.Trip trip in trips)
        {
            int i = 1;
            
            var destinationTile = new VoiceCommandContentTile();

            destinationTile.ContentTileType = VoiceCommandContentTileType.TitleWith68x68IconAndText;
            destinationTile.Image = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///AdventureWorks.VoiceCommands/Images/GreyTile.png"));

            destinationTile.AppLaunchArgument = trip.Destination;
            destinationTile.Title = trip.Destination;
            if (trip.StartDate != null)
            {
                destinationTile.TextLine1 = trip.StartDate.Value.ToString(dateFormatInfo.LongDatePattern);
            }
            else
            {
                destinationTile.TextLine1 = trip.Destination + " " + i;
            }

            destinationsContentTiles.Add(destinationTile);
            i++;
        }
    }

    var response = VoiceCommandResponse.CreateResponse(userMessage, destinationsContentTiles);

    if (trips.Count() > 0)
    {
        response.AppLaunchArgument = destination;
    }

    await voiceServiceConnection.ReportSuccessAsync(response);
}
```
## <span id="Programmatic_deep_link"></span><span id="programmatic_deep_link"></span><span id="PROGRAMMATIC_DEEP_LINK"></span>プログラムによるディープ リンク


アプリ サービスと同様のコンテキストでアプリを開くために、起動引数を指定して、プログラムによってアプリを起動することもできます。 起動引数を指定しない場合、アプリはメイン画面で起動されます。

ここでは、[**VoiceCommandServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn974204) オブジェクトの [**RequestAppLaunchAsync**](https://msdn.microsoft.com/library/windows/apps/dn706581) の呼び出しで使用される [**VoiceCommandResponse**](https://msdn.microsoft.com/library/windows/apps/dn974182) オブジェクトに、"Las Vegas" という値の [**AppLaunchArgument**](https://msdn.microsoft.com/library/windows/apps/dn974183) パラメーターを追加します。

```CSharp
var userMessage = new VoiceCommandUserMessage();
userMessage.DisplayMessage = "Here are your trips.";
userMessage.SpokenMessage = 
  "You have one trip to Vegas coming up.";

response = VoiceCommandResponse.CreateResponse(userMessage);
response.AppLaunchArgument = “Las Vegas”;
await  VoiceCommandServiceConnection.RequestAppLaunchAsync(response);
```

## <span id="App_manifest"></span><span id="app_manifest"></span><span id="APP_MANIFEST"></span>アプリ マニフェスト


アプリへのディープ リンクを有効にするには、アプリ プロジェクトの Package.appxmanifest ファイルで、`windows.personalAssistantLaunch` 拡張機能を宣言する必要があります

ここでは、**Adventure Works** アプリの `windows.personalAssistantLaunch` 拡張機能を宣言します。

```XML
<Extensions>
  <uap:Extension Category="windows.appService" 
    EntryPoint="AdventureWorks.VoiceCommands.AdventureWorksVoiceCommandService">
    <uap:AppService Name="AdventureWorksVoiceCommandService"/>
  </uap:Extension>
  <uap:Extension Category="windows.personalAssistantLaunch"/> 
</Extensions>
```

## <span id="Protocol_contract"></span><span id="protocol_contract"></span><span id="PROTOCOL_CONTRACT"></span>プロトコル コントラクト


アプリは、[**Protocol**](https://msdn.microsoft.com/library/windows/apps/br224693) コントラクトを使用して、Uniform Resource Identifier (URI) アクティブ化によってフォアグラウンドで起動されます。 アプリは、アプリの [**OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) イベントをオーバーライドし、**Protocol** の **ActivationKind** を確認する必要があります。 詳しくは、「[URI のアクティブ化の処理](https://msdn.microsoft.com/library/windows/apps/mt228339)」をご覧ください。

ここでは、[**ProtocolActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224742) によって提供される URI をデコードして、起動引数にアクセスします。 この例では、[**Uri**](https://msdn.microsoft.com/library/windows/apps/br224746) は "windows.personalassistantlaunch:?LaunchContext=Las Vegas" に設定されています。

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

## <span id="related_topics"></span>関連記事


**開発者向け**
* [Cortana の操作](cortana-interactions.md)
* [**VCD 要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)

**デザイナー向け**
* [Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)
* [音声認識の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)

**サンプル**
* [Cortana 音声コマンドのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619899)
 

 






<!--HONumber=Mar16_HO4-->


