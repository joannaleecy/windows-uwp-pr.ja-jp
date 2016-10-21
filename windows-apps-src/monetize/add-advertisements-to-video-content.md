---
author: mcleanbyron
ms.assetid: cc24ba75-a185-4488-b70c-fd4078bc4206
description: "AdScheduler クラスを使ってビデオ コンテンツに広告を追加する方法について説明します。"
title: "HTML 5 および JavaScript によるビデオ コンテンツへの広告の追加"
translationtype: Human Translation
ms.sourcegitcommit: 5f975d0a99539292e1ce91ca09dbd5fac11c4a49
ms.openlocfilehash: 5fd097d978b1960ed957a7e12ab7eece012c5b41

---

# HTML 5 および JavaScript によるビデオ コンテンツへの広告の追加


このチュートリアルでは、JavaScript と HTML を使って作成されたユニバーサル Windows プラットフォーム (UWP) アプリのビデオ コンテンツに、[AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) クラスを使って広告を追加する方法について説明します。

>**注**&nbsp;&nbsp;この機能は現在、JavaScript と HTML を使って作成された UWP アプリでのみサポートされています。

[AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) は、プログレッシブ メディアとストリーミング メディアの両方で機能し、IAB 標準の Video Ad Serving Template (VAST) 2.0/3.0 と VMAP ペイロード形式を使用します。 標準規格を使用しているため、[AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx)は、通信相手の広告サービスに依存しません。

ビデオ コンテンツの広告は、プログラムが 10 分未満 (短い形式) か、10 分 (長い形式) を超えるかによって異なります。 後者は前者よりもサービス上の設定が複雑ですが、クライアント側コードの作成方法にはほとんど違いはありません。 [AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) が、マニフェストの代わりに 1 つの広告のみを含む VAST ペイロードを受け取った場合、その VAST ペイロードは 1 つのプリロール広告 (00:00 の時点で再生) についてマニフェストが呼び出された場合と同様に処理されます。

## 前提条件

* Visual Studio 2015 で [Microsoft Store Services SDK](http://aka.ms/store-em-sdk) をインストールします。

* 広告がスケジュールされるビデオ コンテンツを提供するためには、プロジェクトで [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) コントロールを使う必要があります。 このコントロールは、Microsoft の GitHub から入手できる [TVHelpers](https://github.com/Microsoft/TVHelpers) コレクションのライブラリにあります。

  次の例では、HTML マークアップで [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) を宣言する方法を示します。 通常、このマークアップは default.html ファイル (またはプロジェクトに対応するその他の html ファイル) の `<body>` セクションに含まれます。
  ``` html
  <div id="MediaPlayerDiv" data-win-control="TVJS.MediaPlayer">
    <video src="URL to your content">
    </video>
  </div>
  ```

  次の例では、JavaScript コードで [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) を確立する方法を示します。
  ``` javascript
  var mediaPlayerDiv = document.createElement("div");
  document.body.appendChild(mediaPlayerDiv);

  var videoElement = document.createElement("video");
  videoElement.src = "<URL to your content>";
  mediaPlayerDiv.appendChild(videoElement);

  var mediaPlayer = new TVJS.MediaPlayer(mediaPlayerDiv);
  ```

## コードで AdScheduler クラスを使用する方法

1. Visual Studio でプロジェクトを開くか、新しいプロジェクトを作ります。

2. プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。 プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising ライブラリへの参照を正常に追加できません。 詳しくは、「[プロジェクトのターゲットを "Any CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。

3. **Microsoft Advertising SDK for JavaScript** ライブラリへの参照をプロジェクトに追加します。

  a.  **ソリューション エクスプローラー**のウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。

  b.  **[参照マネージャー]** で、**[Universal Windows]** を展開し、**[拡張]** をクリックして、**[Microsoft Advertising SDK for JavaScript]** (バージョン 10.0) の横にあるチェック ボックスをオンにします。

  c.  **[参照マネージャー]** で、[OK] をクリックします。

4.  AdScheduler.js ファイルをプロジェクトに追加します。

  a.   Visual Studio で、**[プロジェクト]** と **[NuGet パッケージの管理]** をクリックします。

  b.   検索ボックスに、「**Microsoft.StoreServices.VideoAdScheduler**」と入力し、Microsoft.StoreServices.VideoAdScheduler パッケージをインストールします。 AdScheduler.js ファイルがプロジェクトの ../js サブディレクトリに追加されます。

5.  default.html ファイル (またはプロジェクトに対応するその他の html ファイル) を開きます。 `<head>` セクションで、プロジェクトの default.css と default.js の JavaScript 参照の後に、ad.js と adscheduler.js への参照を追加します。

    ``` html
    <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
    <script src="/js/adscheduler.js"></script>
    ```

    > **注**   この行は、`<head>` セクションの default.js のインクルードの後に配置する必要があります。そうでない場合、プロジェクトのビルド時にエラーが発生します。

6.  プロジェクトの default.js ファイルで、新しい [AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) オブジェクトを作成するコードを追加します。 ビデオ コンテンツをホストする **MediaPlayer** を渡します。 このコードは、[WinJS.UI.processAll](https://msdn.microsoft.com/library/windows/apps/hh440975.aspx) の後に実行されるように配置する必要があります。

    ``` javascript
    var myMediaPlayer = document.getElementById("MediaPlayerDiv");
    var myAdScheduler = new MicrosoftNSJS.Advertising.AdScheduler(myMediaPlayer);
    ```

7.  [requestSchedule](https://msdn.microsoft.com/library/windows/apps/mt732208.aspx) メソッドまたは [requestScheduleByUrl](https://msdn.microsoft.com/library/windows/apps/mt732210.aspx) メソッドを使用してサーバーに広告スケジュールを要求し、それを **MediaPlayer** タイムラインに挿入してからビデオ メディアを再生します。

  * Microsoft 広告サーバーに対して広告スケジュールを要求することを許可されている Microsoft パートナーは、[requestSchedule](https://msdn.microsoft.com/library/windows/apps/mt732208.aspx) を使用して、Microsoft の担当者が提供するアプリケーション ID と広告ユニット ID を指定します。 このメソッドは、非同期コンストラクトである **Promise** の形式を取り、成功と失敗のそれぞれの場合を処理する 2 つの関数ポインターを渡します。 詳しくは、「[JavaScript を使った UWP での非同期パターン](https://msdn.microsoft.com/windows/uwp/threading-async/asynchronous-programming-universal-windows-platform-apps#asynchronous-patterns-in-uwp-using-javascript)」をご覧ください。

      ``` javascript
  myAdScheduler.requestSchedule("your application ID", "your ad unit ID").then(
        function promiseSuccessHandler(schedule) {
           // Success: play the video content with the scheduled ads.
           myMediaPlayer.tvControl.play();
        },
        function promiseErrorHandler(err) {
           // Error: play the video content without the ads.
           myMediaPlayer.tvControl.play();
        });
  ```

  * Microsoft 以外の広告サーバーに広告スケジュールを要求するには、[requestScheduleByUrl](https://msdn.microsoft.com/library/windows/apps/mt732210.aspx) を使用し、サーバー URL を指定します。 このメソッドも **Promise** の形式を取ります。

      ``` javascript
  myAdScheduler.requestScheduleByUrl("your URL").then(
        function promiseSuccessHandler(schedule) {
            // Success: play the video content with the scheduled ads.
            myMediaPlayer.winControl.play();
        },
        function promiseErrorHandler(evt) {
            // Error: play the video content without the ads.
             myMediaPlayer.winControl.play();
        });
  ```

  >**注**&nbsp;&nbsp;関数が失敗した場合でも、**play** を呼び出す必要があります。[AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) によって **MediaPlayer** が広告をスキップし、直接コンテンツを再生するためです。 ビジネス要件によっては、広告がリモートで正常に取得できない場合に、ビルトイン広告を挿入するなどの処理を行うこともできます。

8.  再生中は、アプリが進行状況や、最初の広告マッチング プロセス後に発生したエラーを追跡するための追加のイベントが存在します。 次のコードでは、これらのイベントの一部を示します。
  * [onPodStart](https://msdn.microsoft.com/library/windows/apps/mt732206.aspx):

      ```javascript
      // Raised when an ad pod starts. Make the countdown timer visible.
      myAdScheduler.onPodStart = function (sender, data) {
          myCounterDiv.style.visibility= "visible";
      }  
      ```

  * [onPodEnd](https://msdn.microsoft.com/library/windows/apps/mt732205.aspx):

      ```javascript
      // Raised when an ad pod ends. Hide the countdown timer.
      myAdScheduler.onPodEnd = function (sender, data) {
          myCounterDiv.style.visibility= "hidden";
      }
      ```

  * [onPodCountdown](https://msdn.microsoft.com/library/windows/apps/mt732204.aspx):

      ```javascript
      // Raised when an ad is playing and indicates how many seconds remain in the current pod of ads. This is useful when the app wants to show a visual countdown until the video content resumes.
      myAdScheduler.onPodCountdown = function (sender, data) {
            myCounterText     = "Content resumes in: " +
            Math.ceil(data.remainingPodTime) + " seconds.";
      }  
      ```

  * [onAdProgress](https://msdn.microsoft.com/library/windows/apps/mt732201.aspx):

      ```javascript
      // Raised during each quartile of progress through the ad clip.
      myAdScheduler.onAdProgress = function (sender, data) {
      }
      ```

  * [onAllComplete](https://msdn.microsoft.com/library/windows/apps/mt732202.aspx):

      ```javascript
      // Raised when the ads and content are complete.
      myAdScheduler.onAllComplete = function (sender) {
      }
      ```

  * [onErrorOccurred](https://msdn.microsoft.com/library/windows/apps/mt732203.aspx):

      ```javascript
      // Raised when an error occurs during playback after successfully scheduling.
      myAdScheduler.onErrorOccurred = function (sender, data) {
      }
      ```



<!--HONumber=Aug16_HO5-->


