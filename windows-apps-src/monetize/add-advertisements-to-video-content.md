---
author: mcleanbyron
ms.assetid: cc24ba75-a185-4488-b70c-fd4078bc4206
description: "AdScheduler クラスを使ってビデオ コンテンツに広告を追加する方法について説明します。"
title: "HTML 5 および JavaScript によるビデオ コンテンツへの広告の追加"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP、広告、宣伝、ビデオ、スケジューラ、javascript"
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: b42b57f385857301bb74037dbb5c0c7200653316
ms.lasthandoff: 02/07/2017

---

# <a name="add-advertisements-to-video-content-in-html-5-and-javascript"></a>HTML 5 および JavaScript によるビデオ コンテンツへの広告の追加


このチュートリアルでは、JavaScript と HTML を使って作成されたユニバーサル Windows プラットフォーム (UWP) アプリのビデオ コンテンツに、[AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) クラスを使って広告を追加する方法について説明します。

>**注**&nbsp;&nbsp;この機能は現在、JavaScript と HTML を使って作成された UWP アプリでのみサポートされています。

[AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) は、プログレッシブ メディアとストリーミング メディアの両方で機能し、IAB 標準の Video Ad Serving Template (VAST) 2.0/3.0 と VMAP ペイロード形式を使用します。 標準規格を使用しているため、[AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx)は、通信相手の広告サービスに依存しません。

ビデオ コンテンツの広告は、プログラムが 10 分未満 (短い形式) か、10 分 (長い形式) を超えるかによって異なります。 後者は前者よりもサービス上の設定が複雑ですが、クライアント側コードの作成方法にはほとんど違いはありません。 [AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) が、マニフェストの代わりに 1 つの広告のみを含む VAST ペイロードを受け取った場合、その VAST ペイロードは 1 つのプリロール広告 (00:00 の時点で再生) についてマニフェストが呼び出された場合と同様に処理されます。

## <a name="prerequisites"></a>前提条件

* Visual Studio 2015 で [Microsoft Store Services SDK](http://aka.ms/store-em-sdk) をインストールします。

* 広告がスケジュールされるビデオ コンテンツを提供するためには、プロジェクトで [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) コントロールを使う必要があります。 このコントロールは、Microsoft の GitHub から入手できる [TVHelpers](https://github.com/Microsoft/TVHelpers) コレクションのライブラリにあります。

  次の例では、HTML マークアップで [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) を宣言する方法を示します。 通常、このマークアップは index.html ファイル (またはプロジェクトに対応するその他の html ファイル) の `<body>` セクションに含まれます。

  > [!div class="tabbedCodeSnippets"]
  ``` html
  <div id="MediaPlayerDiv" data-win-control="TVJS.MediaPlayer">
    <video src="URL to your content">
    </video>
  </div>
  ```

  次の例では、JavaScript コードで [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) を確立する方法を示します。

  > [!div class="tabbedCodeSnippets"]
  [!code-javascript[TrialVersion](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet1)]

## <a name="how-to-use-the-adscheduler-class-in-your-code"></a>コードで AdScheduler クラスを使用する方法

1. Visual Studio でプロジェクトを開くか、新しいプロジェクトを作ります。

2. プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。 プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising ライブラリへの参照を正常に追加できません。 詳しくは、「[プロジェクトのターゲットを "Any CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。

3. **Microsoft Advertising SDK for JavaScript** ライブラリへの参照をプロジェクトに追加します。

  a.  **ソリューション エクスプローラー**のウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。

  b.  **[参照マネージャー]** で、**[Universal Windows]** を展開し、**[拡張]** をクリックして、**[Microsoft Advertising SDK for JavaScript]** (バージョン 10.0) の横にあるチェック ボックスをオンにします。

  c.  **[参照マネージャー]** で、[OK] をクリックします。

4.  AdScheduler.js ファイルをプロジェクトに追加します。

  a.   Visual Studio で、**[プロジェクト]** と **[NuGet パッケージの管理]** をクリックします。

  b.   検索ボックスに、「**Microsoft.StoreServices.VideoAdScheduler**」と入力し、Microsoft.StoreServices.VideoAdScheduler パッケージをインストールします。 AdScheduler.js ファイルがプロジェクトの ../js サブディレクトリに追加されます。

5.  index.html ファイル (またはプロジェクトに対応するその他の html ファイル) を開きます。 `<head>` セクションで、プロジェクトの default.css と main.js の JavaScript 参照の後に、ad.js と adscheduler.js への参照を追加します。

  > [!div class="tabbedCodeSnippets"]
  ``` html
  <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
  <script src="/js/adscheduler.js"></script>
  ```

  <span/>
  > **注**&nbsp;&nbsp;この行は、`<head>` セクションの main.js のインクルードの後に配置する必要があります。そうでない場合、プロジェクトのビルド時にエラーが発生します。

6.  プロジェクトの main.js ファイルで、新しい [AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) オブジェクトを作成するコードを追加します。 ビデオ コンテンツをホストする **MediaPlayer** を渡します。 このコードは、[WinJS.UI.processAll](https://msdn.microsoft.com/library/windows/apps/hh440975.aspx) の後に実行されるように配置する必要があります。

  > [!div class="tabbedCodeSnippets"]
  [!code-javascript[TrialVersion](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet2)]

7.  [requestSchedule](https://msdn.microsoft.com/library/windows/apps/mt732208.aspx) メソッドまたは [requestScheduleByUrl](https://msdn.microsoft.com/library/windows/apps/mt732210.aspx) メソッドを使用してサーバーに広告スケジュールを要求し、それを **MediaPlayer** タイムラインに挿入してからビデオ メディアを再生します。

  * Microsoft 広告サーバーに対して広告スケジュールを要求することを許可されている Microsoft パートナーは、[requestSchedule](https://msdn.microsoft.com/library/windows/apps/mt732208.aspx) を使用して、Microsoft の担当者が提供するアプリケーション ID と広告ユニット ID を指定します。 このメソッドは、非同期コンストラクトである **Promise** の形式を取り、成功と失敗のそれぞれの場合を処理する 2 つの関数ポインターを渡します。 詳しくは、「[JavaScript を使った UWP での非同期パターン](https://msdn.microsoft.com/windows/uwp/threading-async/asynchronous-programming-universal-windows-platform-apps#asynchronous-patterns-in-uwp-using-javascript)」をご覧ください。

      > [!div class="tabbedCodeSnippets"]
      [!code-javascript[TrialVersion](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet3)]

  * Microsoft 以外の広告サーバーに広告スケジュールを要求するには、[requestScheduleByUrl](https://msdn.microsoft.com/library/windows/apps/mt732210.aspx) を使用し、サーバー URL を指定します。 このメソッドも **Promise** の形式を取ります。

      > [!div class="tabbedCodeSnippets"]
      [!code-javascript[TrialVersion](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet4)]

    <span/>
    >**注**&nbsp;&nbsp;関数が失敗した場合でも、**play** を呼び出す必要があります。[AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) によって **MediaPlayer** が広告をスキップし、直接コンテンツを再生するためです。 ビジネス要件によっては、広告がリモートで正常に取得できない場合に、ビルトイン広告を挿入するなどの処理を行うこともできます。

8.  再生中に、アプリが進行状況や、最初の広告マッチング プロセス後に発生したエラーを追跡するための追加のイベントを処理できます。 次のコードでは、これらのイベントのいくつか ([onPodStart](https://msdn.microsoft.com/library/windows/apps/mt732206.aspx)、[onPodEnd](https://msdn.microsoft.com/library/windows/apps/mt732205.aspx)、[onPodCountdown](https://msdn.microsoft.com/library/windows/apps/mt732204.aspx)、[onAdProgress](https://msdn.microsoft.com/library/windows/apps/mt732201.aspx)、[onAllComplete](https://msdn.microsoft.com/library/windows/apps/mt732202.aspx)、および [onErrorOccurred](https://msdn.microsoft.com/library/windows/apps/mt732203.aspx)) を示します。

  > [!div class="tabbedCodeSnippets"]
  [!code-javascript[TrialVersion](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet5)]

