---
Description: 音声コマンドの実行時に Cortana の音声とキャンバスを通じてバックグラウンド アプリを操作する方法について説明します。
title: バックグラウンド アプリの操作
ms.assetid: 6C60F03C-A242-435D-96BB-736892CC1CA6
label: Interact with a background app
template: detail.hbs
---

# Cortana でのバックグラウンド アプリの操作


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


**重要な API**

-   [**Windows.ApplicationModel.VoiceCommands**](https://msdn.microsoft.com/library/windows/apps/dn706594)
-   [**音声コマンド定義 (VCD) の要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)

音声コマンドの実行中に、**Cortana** キャンバスでの音声認識とテキストの入力により、バック グラウンド アプリへのユーザー操作が可能になります。

Cortana は、アプリでの完全なターン バイ ターン方式のワークフローをサポートします。 このワークフローはアプリによって定義され、次の機能をサポートできます。 

-   正常完了
-   ハンドオフ
-   進行状況
-   確認
-   不明瞭解消
-   エラー

**前提条件:**

このトピックは、「[Cortana の音声コマンドを使ったバックグラウンド アプリの起動](launch-a-background-app-with-voice-commands-in-cortana.md)」に基づいています。 ここでは、引き続き **Adventure Works** という旅行の計画および管理アプリを使って機能について説明します。

ユニバーサル Windows プラットフォーム (UWP) アプリを開発するのが初めての場合は、以下のトピックに目を通して、ここで説明されているテクノロジをよく理解できるようにしてください。

-   [初めてのアプリ作成](https://msdn.microsoft.com/library/windows/apps/bg124288)
-   「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」でイベントについて学習します。

**ユーザー エクスペリエンス ガイドライン:  **

アプリと **Cortana** を統合する方法については「[Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)」を、魅力的な音声認識対応アプリの設計に役立つ便利なヒントについては「[音声機能の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)」をご覧ください。

## <span id="Feedback_strings"></span><span id="feedback_strings"></span><span id="FEEDBACK_STRINGS"></span>フィードバック文字列

**Cortana** が表示または会話するフィードバック文字列を構成します。

「[Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)」では、**Cortana** の文字列の構成に関する推奨事項を提供しています。

## <span id="Feedback_strings"></span><span id="feedback_strings"></span><span id="FEEDBACK_STRINGS"></span>フィードバック文字列

コンテンツ カードは、ユーザーに追加のコンテキストを示し、フィードバック文字列を簡潔に保つのに役立ちます。

**Cortana** では、次のコンテンツ カード テンプレートがサポートされます (完了画面で使うことができるテンプレートは 1 つだけです)。

    -   Title only
    -   Title with up to three lines of text
    -   Title with image
    -   Title with image and up to three lines of text

以下の画像を使うことができます。

    -   68w x 68h
    -   68w x 92h
    -   280w x 140h

ユーザーのカードやアプリへのテキスト リンクをクリックして、アプリをフォアグラウンドで起動できるようにすることもできます。

## <span id="Completion_screen"></span><span id="completion_screen"></span><span id="COMPLETION_SCREEN"></span>完了画面

完了画面には、完了した音声コマンド タスクに関する情報が表示されます。

アプリの応答に 500 ミリ秒未満しかかからず、ユーザーからの追加情報を必要としないタスクは、それ以上の **Cortana** とのやり取りなしで完了します。 Cortana は、単に完了画面を表示します。

ここでは、**Adventure Works** アプリを使って、ロンドンへの旅行予定を表示して、音声コマンドを要求する完了画面を表示します。 

![Cortana のバックグラウンド アプリの完了画面](images/cortana-completion-screen-upcomingtrip-small.png)

音声コマンドは AdventureWorksCommands.xml で定義されています。
```
<Command Name="whenIsTripToDestination">
  <Example> When is my trip to Las Vegas?</Example>
  <ListenFor RequireAppName="BeforeOrAfterPhrase"> when is [my] trip to {destination}</ListenFor>
  <ListenFor RequireAppName="ExplicitlySpecified"> when is [my] {builtin:AppName} trip to {destination} </ListenFor>
  <Feedback> Looking for trip to {destination}</Feedback>
  <VoiceCommandService Target="AdventureWorksVoiceCommandService"/>
</Command>
```

AdventureWorksVoiceCommandService.cs には、完了メッセージのメソッドが含まれています。

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

## <span id="Hand-off_screen"></span><span id="hand-off_screen"></span><span id="HAND-OFF_SCREEN"></span>ハンドオフ画面

音声コマンドが認識されると、**Cortana** は ReportSuccessAsync を呼び出し、フィードバックを約 500 ミリ秒内に表示する必要があります。 アプリ サービスが 500 ミリ秒以内に音声コマンドにより指定されたアクションを完了できない場合、**Cortana** はアプリが ReportSuccessAsync を呼び出すまでの間、または最大 5 秒間、ハンドオフ画面をユーザーに表示します。

アプリ サービスが ReportSuccessAsync を呼び出さないか、または他の VoiceCommandServiceConnection メソッドを呼び出さない場合、エラー メッセージが表示されてアプリ サービス呼び出しがキャンセルされます。

**Adventure Works** アプリのハンドオフ画面の例を次に示します。 この例では、ユーザーは **Cortana** に旅行の予定を照会しました。 ハンドオフ画面には、アプリ サービス名を使ってカスタマイズされたメッセージ、アイコン、VCD ファイルで宣言された**フィードバック**文字列が表示されます。

![Cortana のバックグラウンド アプリのハンドオフ画面](images/cortana-backgroundapp-progress-result.png)


## <span id="Progress_screen"></span><span id="progress_screen"></span><span id="PROGRESS_SCREEN"></span>進行状況画面


アプリ サービスが ReportSuccessAsync を呼び出すために 500 ミリ秒より多くの時間がかかる場合、**Cortana** は進行状況画面をユーザーに表示します。 アプリ アイコンが表示されます。タスクがアクティブに処理されていることを示すため、GUI と TTS の両方の進行状況文字列を提供する必要があります。

**Cortana** には、最大 5 秒間進行状況画面が表示されます。 5 秒後、**Cortana** はユーザーにエラー メッセージを表示し、アプリ サービスが終了します。 アプリ サービスがアクションを完了するのに 5 秒以上必要とする場合、進行状況画面を表示して **Cortana** の更新を続けます。

**Adventure Works** アプリの進行状況画面の例を次に示します。 この例では、ユーザーはラスベガス旅行をキャンセルしました。 進行状況画面には、アクションに合わせてカスタマイズされたメッセージ、アイコン、および取り消す旅行についての情報を含むコンテンツ タイルが表示されます。

![Cortana のバックグラウンド アプリの進行状況画面 ](images/cortana-progress-screen.png)

AdventureWorksVoiceCommandService.cs には、次の進行状況メッセージ メソッドが含まれています。このメソッドは [**ReportProgressAsync**](https://msdn.microsoft.com/library/windows/apps/dn706579) を呼び出して、**Cortana** に進行状況画面を表示します。


```    CSharp
/// <summary>
/// Show a progress screen. These should be posted at least every 5 seconds for a 
/// long-running operation.
/// </summary>
/// <param name="message">The message to display, relating to the task being performed.</param>
/// <returns></returns>
private async Task ShowProgressScreen(string message)
{
    var userProgressMessage = new VoiceCommandUserMessage();
    userProgressMessage.DisplayMessage = userProgressMessage.SpokenMessage = message;

    VoiceCommandResponse response = VoiceCommandResponse.CreateResponse(userProgressMessage);
    await voiceServiceConnection.ReportProgressAsync(response);
}
```

## <span id="Confirmation_screen"></span><span id="confirmation_screen"></span><span id="CONFIRMATION_SCREEN"></span>確認画面


音声コマンドにより指定されたアクションが、元に戻すことができないアクション、大きな影響を与えるアクション、認識の信頼性が高くないアクションの場合、アプリ サービスは確認を要求できます。

**Adventure Works** アプリの確認画面の例を次に示します。 この例では、**Cortana** を使って、アプリ サービスに対してラスベガス旅行を取り消すように指示しました。 アプリ サービスは、旅行を取り消す前にユーザーに「はい」または「いいえ」の回答を求める確認画面を **Cortana** に提供しました。

ユーザーが「はい」または「いいえ」以外のことを言った場合、**Cortana** は質問に対する回答を特定できません。 この場合、**Cortana** はアプリ サービスによって提供されたものと同様の質問をユーザーに表示します。

2 つ目のプロンプトでもユーザーが「はい」または「いいえ」と言わない場合、**Cortana** はお詫びの言葉を前に添えて 3 度目の同じ質問をユーザーに表示します。 それでもユーザーが「はい」または「いいえ」と言わない場合、**Cortana** は音声入力の待機をやめ、代わりにボタンのタップをユーザーに求めます。

確認画面には、アクションに合わせてカスタマイズされたメッセージ、アイコン、および取り消す旅行についての情報を含むコンテンツ タイルが表示されます。

![Cortana のバックグラウンド アプリの確認画面](images/cortana-confirmation-screen.png)

AdventureWorksVoiceCommandService.cs には、次の旅行取り消しメソッドが含まれています。このメソッドは [**RequestConfirmationAsync**](https://msdn.microsoft.com/library/windows/apps/dn706582) を呼び出して、**Cortana** に確認画面を表示します。

```    CSharp
/// <summary>
/// Handle the Trip Cancellation task. This task demonstrates how to prompt a user
/// for confirmation of an operation, show users a progress screen while performing
/// a long-running task, and show a completion screen.
/// </summary>
/// <param name="destination">The name of a destination.</param>
/// <returns></returns>
private async Task SendCompletionMessageForCancellation(string destination)
{
    // Begin loading data to search for the target store. 
    // Consider inserting a progress screen here, in order to prevent Cortana from timing out. 
    string progressScreenString = string.Format(
        cortanaResourceMap.GetValue("ProgressLookingForTripToDest", cortanaContext).ValueAsString,
        destination);
    await ShowProgressScreen(progressScreenString);

    Model.TripStore store = new Model.TripStore();
    await store.LoadTrips();

    IEnumerable<Model.Trip> trips = store.Trips.Where(p => p.Destination == destination);
    Model.Trip trip = null;
    if (trips.Count() > 1)
    {
        // If there is more than one trip, provide a disambiguation screen.
        // However, if a significant number of items are returned, you might want to 
        // just display a link to your app and provide a deeper search experience.
        string disambiguationDestinationString = string.Format(
            cortanaResourceMap.GetValue("DisambiguationWhichTripToDest", cortanaContext).ValueAsString,
            destination);
        string disambiguationRepeatString = cortanaResourceMap.GetValue("DisambiguationRepeat", cortanaContext).ValueAsString;
        trip = await DisambiguateTrips(trips, disambiguationDestinationString, disambiguationRepeatString);
    }
    else
    {
        trip = trips.FirstOrDefault();
    }

    var userPrompt = new VoiceCommandUserMessage();
    
    VoiceCommandResponse response;
    if (trip == null)
    {
        var userMessage = new VoiceCommandUserMessage();
        string noSuchTripToDestination = string.Format(
            cortanaResourceMap.GetValue("NoSuchTripToDestination", cortanaContext).ValueAsString,
            destination);
        userMessage.DisplayMessage = userMessage.SpokenMessage = noSuchTripToDestination;

        response = VoiceCommandResponse.CreateResponse(userMessage);
        await voiceServiceConnection.ReportSuccessAsync(response);
    }
    else
    {
        // Prompt the user for confirmation that this is the correct trip to cancel.
        string cancelTripToDestination = string.Format(
            cortanaResourceMap.GetValue("CancelTripToDestination", cortanaContext).ValueAsString,
            destination);
        userPrompt.DisplayMessage = userPrompt.SpokenMessage = cancelTripToDestination;
        var userReprompt = new VoiceCommandUserMessage();
        string confirmCancelTripToDestination = string.Format(
            cortanaResourceMap.GetValue("ConfirmCancelTripToDestination", cortanaContext).ValueAsString,
            destination);
        userReprompt.DisplayMessage = userReprompt.SpokenMessage = confirmCancelTripToDestination;
        
        response = VoiceCommandResponse.CreateResponseForPrompt(userPrompt, userReprompt);

        var voiceCommandConfirmation = await voiceServiceConnection.RequestConfirmationAsync(response);

        // If RequestConfirmationAsync returns null, Cortana has likely been dismissed.
        if (voiceCommandConfirmation != null)
        {
            if (voiceCommandConfirmation.Confirmed == true)
            {
                string cancellingTripToDestination = string.Format(
               cortanaResourceMap.GetValue("CancellingTripToDestination", cortanaContext).ValueAsString,
               destination);
                await ShowProgressScreen(cancellingTripToDestination);

                // Perform the operation to remove the trip from app data. 
                // As the background task runs within the app package of the installed app,
                // we can access local files belonging to the app without issue.
                await store.DeleteTrip(trip);

                // Provide a completion message to the user.
                var userMessage = new VoiceCommandUserMessage();
                string cancelledTripToDestination = string.Format(
                    cortanaResourceMap.GetValue("CancelledTripToDestination", cortanaContext).ValueAsString,
                    destination);
                userMessage.DisplayMessage = userMessage.SpokenMessage = cancelledTripToDestination;
                response = VoiceCommandResponse.CreateResponse(userMessage);
                await voiceServiceConnection.ReportSuccessAsync(response);
            }
            else
            {
                // Confirm no action for the user.
                var userMessage = new VoiceCommandUserMessage();
                string keepingTripToDestination = string.Format(
                    cortanaResourceMap.GetValue("KeepingTripToDestination", cortanaContext).ValueAsString,
                    destination);
                userMessage.DisplayMessage = userMessage.SpokenMessage = keepingTripToDestination;

                response = VoiceCommandResponse.CreateResponse(userMessage);
                await voiceServiceConnection.ReportSuccessAsync(response);
            }
        }
    }
}
```

## <span id="Disambiguation_screen"></span><span id="disambiguation_screen"></span><span id="DISAMBIGUATION_SCREEN"></span>不明瞭解消画面


音声コマンドにより指定されたアクションに考えれる結果が複数ある場合、アプリ サービスはユーザーに詳細情報を要求できます。

**Adventure Works** アプリの不明瞭解消画面の例を次に示します。 この例では、**Cortana** を使って、アプリ サービスに対してラスベガス旅行を取り消すように指示しました。 ただし、ユーザーには異なる日付のラスベガス旅行が 2 つあるため、アプリ サービスはユーザーが目的の旅行を選ばないとアクションを完了できません。

アプリ サービスは、取り消す前に、一致する旅行の一覧から選ぶように求める不明瞭解消画面を **Cortana** に提供します。

この場合、**Cortana** はアプリ サービスによって提供されたものと同様の質問をユーザーに表示します。

2 つ目のプロンプトでもユーザーが選択内容を特定できる内容を言わない場合、**Cortana** はお詫びの言葉を前に添えて 3 度目の同じ質問をユーザーに表示します。 それでもユーザーが選択内容を特定できる内容を言わない場合、**Cortana** は音声入力の待機をやめ、代わりにボタンのタップをユーザーに求めます。

不明瞭解消画面には、アクションに合わせてカスタマイズされたメッセージ、アイコン、および取り消す旅行についての情報を含むコンテンツ タイルが表示されます。

![Cortana のバックグラウンド アプリの不明瞭解消画面 ](images/cortana-disambiguation-screen.png)

AdventureWorksVoiceCommandService.cs には、次の旅行取り消しメソッドが含まれています。このメソッドは [**RequestDisambiguationAsync**](https://msdn.microsoft.com/library/windows/apps/dn706583) を呼び出して、**Cortana** に不明瞭解消画面を表示します。

```csharp
/// <summary>
/// Provide the user with a way to identify which trip to cancel. 
/// </summary>
/// <param name="trips">The set of trips</param>
/// <param name="disambiguationMessage">The initial disambiguation message</param>
/// <param name="secondDisambiguationMessage">Repeat prompt retry message</param>
private async Task<Model.Trip> DisambiguateTrips(IEnumerable<Model.Trip> trips, string disambiguationMessage, string secondDisambiguationMessage)
{
    // Create the first prompt message.
    var userPrompt = new VoiceCommandUserMessage();
    userPrompt.DisplayMessage =
        userPrompt.SpokenMessage = disambiguationMessage;

    // Create a re-prompt message if the user responds with an out-of-grammar response.
    var userReprompt = new VoiceCommandUserMessage();
    userReprompt.DisplayMessage =
        userReprompt.SpokenMessage = secondDisambiguationMessage;

    // Create card for each item. 
    var destinationContentTiles = new List<VoiceCommandContentTile>();
    int i = 1;
    foreach (Model.Trip trip in trips)
    {
        var destinationTile = new VoiceCommandContentTile();

        destinationTile.ContentTileType = VoiceCommandContentTileType.TitleWith68x68IconAndText;
        destinationTile.Image = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///AdventureWorks.VoiceCommands/Images/GreyTile.png"));
        
        // The AppContext can be any arbitrary object.
        destinationTile.AppContext = trip;
        string dateFormat = "";
        if (trip.StartDate != null)
        {
            dateFormat = trip.StartDate.Value.ToString(dateFormatInfo.LongDatePattern);
        }
        else
        {
            // The app allows a trip to have no date.
            // However, the choices must be unique so they can be distinguished.
            // Here, we add a number to identify them.
            dateFormat = string.Format("{0}", i);
        } 

        destinationTile.Title = trip.Destination + " " + dateFormat;
        destinationTile.TextLine1 = trip.Description;

        destinationContentTiles.Add(destinationTile);
        i++;
    }

    // Cortana handles re-prompting if no valid response.
    var response = VoiceCommandResponse.CreateResponseForPrompt(userPrompt, userReprompt, destinationContentTiles);

    // If cortana is dismissed in this operation, null is returned.
    var voiceCommandDisambiguationResult = await
        voiceServiceConnection.RequestDisambiguationAsync(response);
    if (voiceCommandDisambiguationResult != null)
    {
        return (Model.Trip)voiceCommandDisambiguationResult.SelectedItem.AppContext;
    }

    return null;
}
```

## <span id="Error_screen"></span><span id="error_screen"></span><span id="ERROR_SCREEN"></span>エラー画面


音声コマンドにより指定されたアクションを完了できない場合、アプリ サービスにエラー画面を表示できます。

**Adventure Works** アプリのエラー画面の例を次に示します。 この例では、**Cortana** を使って、アプリ サービスに対してラスベガス旅行を取り消すように指示しました。 ただし、ユーザーには予定されているラスベガス旅行がありません。

アプリ サービスは、アクションに合わせてカスタマイズされたメッセージ、アイコン、特定のエラー メッセージが表示されるエラー画面を **Cortana** に提供します。

[
            **ReportFailureAsync**](https://msdn.microsoft.com/library/windows/apps/dn706578) を呼び出して、**Cortana** にエラー画面を表示します。

```csharp
var userMessage = new VoiceCommandUserMessage();
    userMessage.DisplayMessage = userMessage.SpokenMessage = 
      "Sorry, you don't have any trips to Las Vegas";
                
    var response = VoiceCommandResponse.CreateResponse(userMessage);

    response.AppLaunchArgument = "showUpcomingTrips";
    await voiceServiceConnection.ReportFailureAsync(response);
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


