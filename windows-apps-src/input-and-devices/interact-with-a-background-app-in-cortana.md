---
Description: 音声コマンドの実行時に Cortana の音声とキャンバスを通じてバックグラウンド アプリを操作する方法について説明します。
title: バックグラウンド アプリの操作
ms.assetid: 6C60F03C-A242-435D-96BB-736892CC1CA6
label: バックグラウンド アプリの操作
template: detail.hbs
---

# Cortana でのバックグラウンド アプリの操作


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


**重要な API**

-   [**Windows.ApplicationModel.VoiceCommands**](https://msdn.microsoft.com/library/windows/apps/dn706594)
-   [**音声コマンド定義 (VCD) の要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)

音声コマンドの実行時に **Cortana** の音声とキャンバスを通じてバックグラウンド アプリを操作する方法について説明します。

**Cortana** の音声コマンドには、バックグラウンド アプリによって制御される、**Cortana** 内での多彩なユーザー エクスペリエンスとの操作フローを含めることができます。 アプリでは、以下のような機能をサポートするさまざまな種類の画面を指定できます。

-   正常完了
-   ハンドオフ
-   進行状況
-   確認
-   不明瞭解消
-   エラー

**前提条件:  **

このトピックは、「[Cortana の音声コマンドを使ったバックグラウンド アプリの起動](launch-a-background-app-with-voice-commands-in-cortana.md)」に基づいています。 ここでは、引き続き **Adventure Works** という旅行の計画および管理アプリを使って機能について説明します。

ユニバーサル Windows プラットフォーム (UWP) アプリを開発するのが初めての場合は、以下のトピックに目を通して、ここで説明されているテクノロジをよく理解できるようにしてください。

-   [初めてのアプリ作成](https://msdn.microsoft.com/library/windows/apps/bg124288)
-   「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」に記載されているイベントの説明

**ユーザー エクスペリエンス ガイドライン:  **

アプリと **Cortana** を統合する方法については「[Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)」を、便利で魅力的な音声認識対応アプリの設計に役立つヒントについては「[音声機能の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)」をご覧ください。

## <span id="Completion_screen"></span><span id="completion_screen"></span><span id="COMPLETION_SCREEN"></span>完了画面


完了画面には、完了した音声コマンド タスクに関する情報が表示されます。

アプリが応答するまでの時間が 500 ミリ秒未満で、ユーザーからの追加の情報が必要ないタスクは、**Cortana** からそれ以上のサポートを受けずに、完了画面を表示して完了することができます。

ここでは、**Cortana** に、ラスベガスへの旅行予定に関する取り消しの結果を **Adventure Works** アプリから取得して表示する方法について説明します。

![Cortana のバックグラウンド アプリの完了画面](images/cortana-completion-screen.png)

1.  **Cortana に表示して読み上げるフィードバック文字列を選ぶ**

    「[Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)」に記載された、**Cortana** が表示して読み上げる文字列を作成する際の推奨事項に従います。

2.  **実行するアクションに基づいてコンテンツ タイルを選ぶ (省略可能)**

    コンテンツ タイルは、ユーザーに追加のコンテキストを示し、フィードバック文字列を簡潔に保つのに役立ちます。

    **Cortana** では、次のコンテンツ タイル テンプレートがサポートされます (完了画面で使うことができるテンプレートは 1 つだけです)。

    -   タイトルのみ
    -   最大 3 行のテキストを含むタイトル
    -   アイコン付きのタイトル
    -   アイコン付きで最大 3 行のテキストを含むタイトル

    以下のアイコンを使うことができます。

    -   幅 68 x 高さ 68
    -   幅 68 x 高さ 92
    -   幅 280 x 高さ 140

    ユーザーのタイルやアプリへのテキスト リンクをタップして、アプリをフォアグラウンドで起動できるようにすることもできます。

3.  **正常完了画面を表示する**

    複数のコンテンツ タイルが表示された正常完了画面の例を次に示します。

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

## <span id="Hand-off_screen"></span><span id="hand-off_screen"></span><span id="HAND-OFF_SCREEN"></span>ハンドオフ画面


音声コマンドが認識されたら、**Cortana** は約 500 ミリ秒以内にフィードバックを表示する必要があります。 アプリ サービスが 500 ミリ秒以内に音声コマンドにより指定されたアクションを完了できない場合、**Cortana** は最大 5 秒間ハンドオフ画面をユーザーに表示します。

ハンドオフ画面にはアプリ アイコンと名前が表示されます。音声コマンドが正しく理解されたことを示すために、GUI と音声合成 (TTS) の両方のハンドオフ文字列を提供する必要があります。

**Adventure Works** アプリのハンドオフ画面の例を次に示します。 この例では、ユーザーは **Cortana** に旅行の予定を照会しました。 ハンドオフ画面には、アプリ サービス名を使ってカスタマイズされたメッセージ、アイコン、VCD ファイルで宣言された**フィードバック**文字列が表示されます。

![Cortana のバックグラウンド アプリのハンドオフ画面](images/cortana-backgroundapp-progress-result.png)

## <span id="Progress_screen"></span><span id="progress_screen"></span><span id="PROGRESS_SCREEN"></span>進行状況画面


アプリ サービスがステップ間で 500 ミリ秒以上時間がかかっている場合、**Cortana** は何が起こっているのかを進行状況画面でユーザーに伝えます。 アプリ アイコンが表示されます。タスクがアクティブに処理されていることを示すため、GUI と TTS の両方の進行状況文字列を提供する必要があります。

**Cortana** には、最大 5 秒間進行状況画面が表示されます。 5 秒後、**Cortana** はユーザーにエラー メッセージを表示し、アプリ サービスが終了します。 アプリ サービスがアクションを完了するのに 5 秒以上必要とする場合、進行状況画面を表示して **Cortana** の更新を続けます。

**Adventure Works** アプリのハンドオフ画面の例を次に示します。 この例では、ユーザーは **Cortana** を使ってラスベガス旅行を取り消しました。 進行状況画面には、アクションに合わせてカスタマイズされたメッセージ、アイコン、および取り消す旅行についての情報を含むコンテンツ タイルが表示されます。

![Cortana のバックグラウンド アプリの進行状況画面 ](images/cortana-progress-screen.png)

1.  **Cortana に表示して読み上げるフィードバック文字列を選ぶ**

    「[Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)」に記載された、**Cortana** が表示して読み上げる文字列を作成する際の推奨事項に従います。

2.  **実行するアクションに基づいてコンテンツ タイルを選ぶ (省略可能)**

    コンテンツ タイルは、ユーザーに追加のコンテキストを示し、フィードバック文字列を簡潔に保つのに役立ちます。

    **Cortana** では、次のコンテンツ タイル テンプレートがサポートされます (完了画面で使うことができるテンプレートは 1 つだけです)。

    -   タイトルのみ
    -   最大 3 行のテキストを含むタイトル
    -   アイコン付きのタイトル
    -   アイコン付きで最大 3 行のテキストを含むタイトル

    以下のアイコンを使うことができます。

    -   幅 68 x 高さ 68
    -   幅 68 x 高さ 92
    -   幅 280 x 高さ 140

    ユーザーのタイルやアプリへのテキスト リンクをタップして、アプリをフォアグラウンドで起動できるようにすることもできます。

3.  **応答を構築する**

    [
            **ReportProgressAsync**](https://msdn.microsoft.com/library/windows/apps/dn706579) を呼び出して、**Cortana** に進行状況画面を表示します。

4.  **進行状況画面を表示する**

    コンテンツ タイルを含む進行状況画面の例を次に示します。

```    CSharp
var userMessage = new VoiceCommandUserMessage();

    var destinationsContentTiles = new List<VoiceCommandContentTile>();

    destinationsContentTiles.Add(selectedDestination);

    var response = 
      VoiceCommandResponse.CreateResponse(userMessage, destinationsContentTiles);

    response.AppLaunchArgument = "destination=Las Vegas";
    await voiceServiceConnection.ReportProgressAsync(response);
```

## <span id="Confirmation_screen"></span><span id="confirmation_screen"></span><span id="CONFIRMATION_SCREEN"></span>確認画面


音声コマンドにより指定されたアクションが、元に戻すことができないアクション、大きな影響を与えるアクション、認識の信頼性が高くないアクションの場合、アプリ サービスは確認を要求できます。

**Adventure Works** アプリの確認画面の例を次に示します。 この例では、**Cortana** を使って、アプリ サービスに対してラスベガス旅行を取り消すように指示しました。 アプリ サービスは、旅行を取り消す前にユーザーに「はい」または「いいえ」の回答を求める確認画面を **Cortana** に提供しました。

ユーザーが「はい」または「いいえ」以外のことを言った場合、**Cortana** は質問に対する回答を特定できません。 この場合、**Cortana** はアプリ サービスによって提供されたものと同様の質問をユーザーに表示します。

2 つ目のプロンプトでもユーザーが「はい」または「いいえ」と言わない場合、**Cortana** はお詫びの言葉を前に添えて 3 度目の同じ質問をユーザーに表示します。 それでもユーザーが「はい」または「いいえ」と言わない場合、**Cortana** は音声入力の待機をやめ、代わりにボタンのタップをユーザーに求めます。

確認画面には、アクションに合わせてカスタマイズされたメッセージ、アイコン、および取り消す旅行についての情報を含むコンテンツ タイルが表示されます。

![Cortana のバックグラウンド アプリの確認画面](images/cortana-confirmation-screen.png)

1.  **Cortana に表示して読み上げるフィードバック文字列を選ぶ**

    「[Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)」に記載された、**Cortana** が表示して読み上げる文字列を作成する際の推奨事項に従います。

2.  **実行するアクションに基づいてコンテンツ タイルを選ぶ (省略可能)**

    コンテンツ タイルは、ユーザーに追加のコンテキストを示し、フィードバック文字列を簡潔に保つのに役立ちます。

    **Cortana** では、次のコンテンツ タイル テンプレートがサポートされます (完了画面で使うことができるテンプレートは 1 つだけです)。

    -   タイトルのみ
    -   最大 3 行のテキストを含むタイトル
    -   アイコン付きのタイトル
    -   アイコン付きで最大 3 行のテキストを含むタイトル

    以下のアイコンを使うことができます。

    -   幅 68 x 高さ 68
    -   幅 68 x 高さ 92
    -   幅 280 x 高さ 140

    ユーザーのタイルやアプリへのテキスト リンクをタップして、アプリをフォアグラウンドで起動できるようにすることもできます。

3.  **応答を構築する**

    [
            **RequestConfirmationAsync**](https://msdn.microsoft.com/library/windows/apps/dn706582) を呼び出して、**Cortana** に確認画面を表示します。

4.  **確認画面を表示する**

    コンテンツ タイルを含む確認画面の例を次に示します。

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

## <span id="Disambiguation_screen"></span><span id="disambiguation_screen"></span><span id="DISAMBIGUATION_SCREEN"></span>不明瞭解消画面


音声コマンドにより指定されたアクションに考えれる結果が複数ある場合、アプリ サービスはユーザーに詳細情報を要求できます。

**Adventure Works** アプリの不明瞭解消画面の例を次に示します。 この例では、**Cortana** を使って、アプリ サービスに対してラスベガス旅行を取り消すように指示しました。 ただし、ユーザーには異なる日付のラスベガス旅行が 2 つあるため、アプリ サービスはユーザーが目的の旅行を選ばないとアクションを完了できません。

アプリ サービスは、取り消す前に、一致する旅行の一覧から選ぶように求める不明瞭解消画面を **Cortana** に提供します。

この場合、**Cortana** はアプリ サービスによって提供されたものと同様の質問をユーザーに表示します。

2 つ目のプロンプトでもユーザーが選択内容を特定できる内容を言わない場合、**Cortana** はお詫びの言葉を前に添えて 3 度目の同じ質問をユーザーに表示します。 それでもユーザーが選択内容を特定できる内容を言わない場合、**Cortana** は音声入力の待機をやめ、代わりにボタンのタップをユーザーに求めます。

不明瞭解消画面には、アクションに合わせてカスタマイズされたメッセージ、アイコン、および取り消す旅行についての情報を含むコンテンツ タイルが表示されます。

![Cortana のバックグラウンド アプリの不明瞭解消画面 ](images/cortana-disambiguation-screen.png)

1.  **Cortana に表示して読み上げるフィードバック文字列を選ぶ**

    「[Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)」に記載された、**Cortana** が表示して読み上げる文字列を作成する際の推奨事項に従います。

2.  **実行するアクションに基づいてコンテンツ タイルを選ぶ (省略可能)**

    コンテンツ タイルは、ユーザーに追加のコンテキストを示し、フィードバック文字列を簡潔に保つのに役立ちます。

    **Cortana** では、次のコンテンツ タイル テンプレートがサポートされます (完了画面で使うことができるテンプレートは 1 つだけです)。

    -   タイトルのみ
    -   最大 3 行のテキストを含むタイトル
    -   アイコン付きのタイトル
    -   アイコン付きで最大 3 行のテキストを含むタイトル

    以下のアイコンを使うことができます。

    -   幅 68 x 高さ 68
    -   幅 68 x 高さ 92
    -   幅 280 x 高さ 140

    ユーザーのタイルやアプリへのテキスト リンクをタップして、アプリをフォアグラウンドで起動できるようにすることもできます。

3.  **応答を構築する**

    [
            **RequestDisambiguationAsync**](https://msdn.microsoft.com/library/windows/apps/dn706583) を呼び出して、**Cortana** に不明瞭解消画面を表示します。

4.  **不明瞭解消画面を表示する**

    コンテンツ タイルを含む不明瞭解消画面の例を次に示します。

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

## <span id="Error_screen"></span><span id="error_screen"></span><span id="ERROR_SCREEN"></span>エラー画面


音声コマンドにより指定されたアクションを完了できない場合、アプリ サービスにエラー画面を表示できます。

**Adventure Works** アプリのエラー画面の例を次に示します。 この例では、**Cortana** を使って、アプリ サービスに対してラスベガス旅行を取り消すように指示しました。 ただし、ユーザーには予定されているラスベガス旅行がありません。

アプリ サービスは、アクションに合わせてカスタマイズされたメッセージ、アイコン、特定のエラー メッセージが表示されるエラー画面を **Cortana** に提供します。

1.  **Cortana に表示して読み上げるフィードバック文字列を選ぶ**

    「[Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)」に記載された、**Cortana** が表示して読み上げる文字列を作成する際の推奨事項に従います。

2.  **実行するアクションに基づいてコンテンツ タイルを選ぶ (省略可能)**

    コンテンツ タイルは、ユーザーに追加のコンテキストを示し、フィードバック文字列を簡潔に保つのに役立ちます。

    **Cortana** では、次のコンテンツ タイル テンプレートがサポートされます (完了画面で使うことができるテンプレートは 1 つだけです)。

    -   タイトルのみ
    -   最大 3 行のテキストを含むタイトル
    -   アイコン付きのタイトル
    -   アイコン付きで最大 3 行のテキストを含むタイトル

    以下のアイコンを使うことができます。

    -   幅 68 x 高さ 68
    -   幅 68 x 高さ 92
    -   幅 280 x 高さ 140

    ユーザーのタイルやアプリへのテキスト リンクをタップして、アプリをフォアグラウンドで起動できるようにすることもできます。

3.  **応答を構築する**

    [
            **ReportFailureAsync**](https://msdn.microsoft.com/library/windows/apps/dn706578) を呼び出して、**Cortana** にエラー画面を表示します。

4.  **エラー画面を表示する**

    次に示すのは、エラー画面の例です。

```    CSharp
var userMessage = new VoiceCommandUserMessage();
    userMessage.DisplayMessage = userMessage.SpokenMessage = 
      "Sorry, you don&#39;t have any trips to Las Vegas";
                
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
 

 






<!--HONumber=Mar16_HO1-->


