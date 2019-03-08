---
ms.assetid: cc24ba75-a185-4488-b70c-fd4078bc4206
description: AdScheduler クラスを使ってビデオ コンテンツに広告を表示する方法について説明します。
title: ビデオ コンテンツに広告を表示する
ms.date: 03/22/2018
ms.topic: article
keywords: Windows 10, UWP, 広告, 宣伝, ビデオ, スケジューラ, Javascript
ms.localizationpriority: medium
ms.openlocfilehash: 69fef2bc5deb21be8685badb0cf18f38769170cb
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57603847"
---
# <a name="show-ads-in-video-content"></a>ビデオ コンテンツに広告を表示する

このチュートリアルでは、JavaScript と HTML を使って作成されたユニバーサル Windows プラットフォーム (UWP) アプリのビデオ コンテンツに、**AdScheduler** クラスを使って広告を表示する方法について説明します。

> [!NOTE]
> この機能は現在、JavaScript と HTML を使って作成された UWP アプリでのみサポートされています。

**AdScheduler** は、プログレッシブ メディアとストリーミング メディアの両方で機能し、IAB 標準の Video Ad Serving Template (VAST) 2.0/3.0 と VMAP ペイロード形式を使用します。 標準規格を使用しているため、**AdScheduler**は、通信相手の広告サービスに依存しません。

ビデオ コンテンツの広告は、プログラムが 10 分未満 (短い形式) か、10 分 (長い形式) を超えるかによって異なります。 後者は前者よりもサービス上の設定が複雑ですが、クライアント側コードの作成方法にはほとんど違いはありません。 **AdScheduler** が、マニフェストの代わりに 1 つの広告のみを含む VAST ペイロードを受け取った場合、その VAST ペイロードは 1 つのプリロール広告 (00:00 の時点で再生) についてマニフェストが呼び出された場合と同様に処理されます。

## <a name="prerequisites"></a>前提条件

* Visual Studio 2015 以降のリリースと共に [Microsoft Advertising SDK](https://aka.ms/ads-sdk-uwp) をインストールします。

* 広告がスケジュールされるビデオ コンテンツを提供するためには、プロジェクトで [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) コントロールを使う必要があります。 このコントロールは、Microsoft の GitHub から入手できる [TVHelpers](https://github.com/Microsoft/TVHelpers) コレクションのライブラリにあります。

  次の例では、HTML マークアップで [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) を宣言する方法を示します。 通常、このマークアップは index.html ファイル (またはプロジェクトに対応するその他の html ファイル) の `<body>` セクションに含まれます。

  ``` html
  <div id="MediaPlayerDiv" data-win-control="TVJS.MediaPlayer">
    <video src="URL to your content">
    </video>
  </div>
  ```

  次の例では、JavaScript コードで [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) を確立する方法を示します。

  [!code-javascript[TrialVersion](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet1)]

## <a name="how-to-use-the-adscheduler-class-in-your-code"></a>コードで AdScheduler クラスを使用する方法

1. Visual Studio でプロジェクトを開くか、新しいプロジェクトを作ります。

2. プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。 プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising ライブラリへの参照を正常に追加できません。 詳しくは、「[プロジェクトのターゲットを "Any CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。

3. **Microsoft Advertising SDK for JavaScript** ライブラリへの参照をプロジェクトに追加します。

    1. **[ソリューション エクスプローラー]** ウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。
    2. **[参照マネージャー]** で、**[ユニバーサル Windows]** を展開し、**[拡張]** をクリックして、**[Microsoft Advertising SDK for JavaScript]** (バージョン 10.0) の横にあるチェック ボックスをオンにします。
    3. **[参照マネージャー]** で、[OK] をクリックします。

4.  AdScheduler.js ファイルをプロジェクトに追加します。

    1. Visual Studio で、**[プロジェクト]** と **[NuGet パッケージの管理]** をクリックします。
    2. 検索ボックスに、「**Microsoft.StoreServices.VideoAdScheduler**」と入力し、Microsoft.StoreServices.VideoAdScheduler パッケージをインストールします。 AdScheduler.js ファイルがプロジェクトの ../js サブディレクトリに追加されます。

5.  index.html ファイル (またはプロジェクトに対応するその他の html ファイル) を開きます。 `<head>` セクションで、プロジェクトの default.css と main.js の JavaScript 参照の後に、ad.js と adscheduler.js への参照を追加します。

    ``` html
    <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
    <script src="/js/adscheduler.js"></script>
    ```

    > [!NOTE]
    > この行は、`<head>` セクションの main.js のインクルードの後に配置する必要があります。そうでない場合、プロジェクトのビルド時にエラーが発生します。

6.  プロジェクトの main.js ファイルで、新しい **AdScheduler** オブジェクトを作成するコードを追加します。 ビデオ コンテンツをホストする **MediaPlayer** を渡します。 このコードは、[WinJS.UI.processAll](https://docs.microsoft.com/en-us/previous-versions/windows/apps/hh440975) の後に実行されるように配置する必要があります。

    [!code-javascript[TrialVersion](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet2)]

7.  **AdScheduler** オブジェクトの **requestSchedule** メソッドまたは **requestScheduleByUrl** メソッドを使ってサーバーに広告スケジュールを要求し、それを **MediaPlayer** タイムラインに挿入してから、ビデオ メディアを再生します。

    * Microsoft 広告サーバーに対して広告スケジュールを要求することを許可されている Microsoft パートナーは、**requestSchedule** を使用して、Microsoft の担当者が提供するアプリケーション ID と広告ユニット ID を指定します。

        このメソッドでは、非同期コンストラクトである [Promise](https://docs.microsoft.com/windows/uwp/threading-async/asynchronous-programming-universal-windows-platform-apps#asynchronous-patterns-in-uwp-using-javascript) の形式を使い、2 つの関数ポインターを渡します。2 つとは、promise の正常完了時に呼び出される **onComplete** 関数へのポインターと、エラーが発生した場合に呼び出される **onError** 関数へのポインターです。 **onComplete** 関数で、ビデオ コンテンツの再生を開始します。 スケジュールされた時間に広告の再生が始まります。 **onError** 関数では、エラーを処理してからビデオの再生を開始します。 ビデオ コンテンツは広告なしで再生されます。 **onError** 関数の引数は、次のメンバーを含むオブジェクトです。

        [!code-javascript[TrialVersion](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet3)]

    * Microsoft 以外の広告サーバーに広告スケジュールを要求するには、**requestScheduleByUrl** を使用し、サーバー URI を指定します。 このメソッドも **Promise** の形式を使い、**onComplete** 関数と **onError** 関数へのポインターを受け取ります。 サーバーから返される広告ペイロードは、Video Ad Serving Template (VAST) または Video Multiple Ad Playlist (VMAP) ペイロード形式に準拠している必要があります。

        [!code-javascript[TrialVersion](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet4)]

    > [!NOTE]
    > **MediaPlayer** でメインのビデオ コンテンツの再生を開始する前に、**requestSchedule** または **requestScheduleByUrl** が戻るまで待機する必要があります。 **requestSchedule** が戻る前にメディアの再生を開始すると (プリロール広告の場合)、プリロールによってメインのビデオ コンテンツが中断されます。 関数が失敗した場合でも、**play** を呼び出す必要があります。**AdScheduler** は、広告をスキップしてコンテンツに直接移動するように **MediaPlayer** に通知するためです。 ビジネス要件によっては、広告がリモートで正常に取得できない場合に、ビルトイン広告を挿入するなどの処理を行うこともできます。

8.  再生中に、アプリが進行状況や、最初の広告マッチング プロセス後に発生したエラーを追跡するための追加のイベントを処理できます。 次のコードでは、これらのイベントのいくつか (**onPodStart**、**onPodEnd**、**onPodCountdown**、**onAdProgress**、**onAllComplete**、および **onErrorOccurred**) を示します。

    [!code-javascript[TrialVersion](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet5)]

## <a name="adscheduler-members"></a>AdScheduler のメンバー

このセクションでは、**AdScheduler** オブジェクトのメンバーについて説明します。 これらのメンバーについて詳しくは、プロジェクトに含まれている AdScheduler.js ファイル内のコメントと定義をご覧ください。

### <a name="requestschedule"></a>requestSchedule

このメソッドは、Microsoft 広告サーバーに広告スケジュールを要求し、それを **AdScheduler** コンストラクターに渡された **MediaPlayer** のタイムラインに挿入します。

省略可能な第 3 パラメーター (*adTags*) は、名前と値のペアを含む JSON コレクションで、高度なターゲット設定を必要とするアプリで使用できます。 たとえば、自動車関連のさまざまなビデオを再生するアプリでは、広告ユニット ID に加えて、表示する自動車のメーカーとモデルを渡すことができます。 このパラメーターは、広告タグの使用について Microsoft から承認を受けたパートナーのみが使うことを想定しています。

*adTags* を参照するときは次の点に注意する必要があります。

* このパラメーターはほとんど使用されないオプションです。 発行元は、adTags を使用する前に Microsoft とよく相談する必要があります。
* 名前と値はどちらも、広告サービスで事前に決定されている必要があります。 広告タグは自由な検索用語やキーワードではありません。
* サポートされている最大のタグ数は 10 です。
* タグ名は 16 文字に制限されています。
* タグの値は最大 128 文字です。

### <a name="requestschedulebyuri"></a>requestScheduleByUri

このメソッドは、URI で指定された Microsoft 以外の広告サーバーに広告スケジュールを要求し、それを **AdScheduler** コンストラクターに渡された **MediaPlayer** のタイムラインに挿入します。 広告サーバーから返される広告ペイロードは、Video Ad Serving Template (VAST) または Video Multiple Ad Playlist (VMAP) ペイロード形式に準拠している必要があります。

### <a name="mediatimeout"></a>mediaTimeout

このプロパティは、メディアを再生可能にする時間をミリ秒単位で取得または設定します。 値 0 は、タイムアウトしないようにシステムに通知します。 既定値は 30000 ミリ秒 (30 秒) です。

### <a name="playskippedmedia"></a>playSkippedMedia

このプロパティは、スケジュールされた開始時間よりも先の位置までユーザーがスキップした場合に、スケジュールされたメディアを再生するかどうかを示す**ブール**値を取得または設定します。

メインのビデオ コンテンツの早送り中や巻き戻し中の広告の動作については、広告クライアントとメディア プレイヤーによってルールが適用されます。 通常、アプリ開発者は広告を完全にスキップできるようにはしませんが、妥当なエクスペリエンスをユーザーに提供することを望みます。 次の 2 つのオプションは、ほとんどの開発者のニーズに対応します。

1. エンド ユーザーが自由に広告ポッドをスキップできるようにします。
2. ユーザーが広告ポッドをスキップできるようにしますが、再生を再開するときは最後のポッドを再生します。

**playSkippedMedia** プロパティには次の条件があります。

* いったん広告が開始されたら、広告をスキップしたり早送りしたりできない。
* いったんポッドが開始されたら、広告ポッド内のすべての広告を再生する。
* いったん再生されたら、メインのコンテンツ (映画、エピソードなど) の間は広告を再び再生しない。広告マーカーは再生済みまたは削除済みとマークされる。
* プリロール広告はスキップできない。

広告を含んでいるコンテンツを再開するときは、**playSkippedMedia** を **false** に設定することで、プリロール広告をスキップして最新の広告ブレークの再生を回避します。 次に、コンテンツの開始後に **playSkippedMedia** を **true** に設定して、ユーザーが後続の広告を早送りできないようにします。

> [!NOTE]
> ポッドとは、連続して再生される広告のグループです。広告ブレークの間に再生される広告のグループなどがあります。 詳しくは、IAB Digital Video Ad Serving Template (VAST) の仕様をご覧ください。

### <a name="requesttimeout"></a>requestTimeout

このプロパティを取得またはタイムアウトする前に、ad 要求の応答を待機するミリ秒数を設定します。値 0 は、タイムアウトしないようにシステムに通知します。 既定値は 30000 ミリ秒 (30 秒) です。

### <a name="schedule"></a>schedule

このプロパティは、広告サーバーから受け取ったスケジュール データを取得します。 このオブジェクトには、Video Ad Serving Template (VAST) または Video Multiple Ad Playlist (VMAP) ペイロードの構造に対応する完全なデータ階層が含まれます。

### <a name="onadprogress"></a>onAdProgress  

このイベントは、広告の再生が 4 分の 1 ごとのチェックポイントに到達したときに発生します。 イベント ハンドラーの第 2 パラメーター (*eventInfo*) は、次のメンバーを含む JSON オブジェクトです。

* **進行状況**:広告の再生状態 (の 1 つ、 **MediaProgress** AdScheduler.js で定義された列挙型の値)。
* **クリップ**:再生中のビデオ クリップします。 このオブジェクトは、ユーザーのコードで使用するためのものではありません。
* **adPackage**:再生されている広告に対応する ad ペイロードの一部を表すオブジェクト。 このオブジェクトは、ユーザーのコードで使用するためのものではありません。

### <a name="onallcomplete"></a>onAllComplete  

このイベントは、メイン コンテンツが終了し、スケジュールされたポストロール広告も終了したときに発生します。

### <a name="onerroroccurred"></a>onErrorOccurred  

このイベントは、**AdScheduler** でエラーが発生したときに生成されます。 エラー コードの値について詳しくは、「[ErrorCode](https://docs.microsoft.com/uwp/api/microsoft.advertising.errorcode)」をご覧ください。

### <a name="onpodcountdown"></a>onPodCountdown

このイベントは、広告の再生中に発生し、現在のポッドの残り時間を通知します。 イベント ハンドラーの第 2 パラメーター (*eventData*) は、次のメンバーを含む JSON オブジェクトです。

* **remainingAdTime**:現在の ad の残りの秒数。
* **remainingPodTime**:現在のポッドの残りの秒数。

> [!NOTE]
> ポッドとは、連続して再生される広告のグループです。広告ブレークの間に再生される広告のグループなどがあります。 詳しくは、IAB Digital Video Ad Serving Template (VAST) の仕様をご覧ください。

### <a name="onpodend"></a>onPodEnd  

このイベントは、広告ポッドが終了したときに発生します。 イベント ハンドラーの第 2 パラメーター (*eventData*) は、次のメンバーを含む JSON オブジェクトです。

* **startTime**:ポッドの開始時間 (秒)。
* **ポッド**:ポッドを表すオブジェクト。 このオブジェクトは、ユーザーのコードで使用するためのものではありません。

### <a name="onpodstart"></a>onPodStart

このイベントは、広告ポッドが開始されたときに発生します。 イベント ハンドラーの第 2 パラメーター (*eventData*) は、次のメンバーを含む JSON オブジェクトです。

* **startTime**:ポッドの開始時間 (秒)。
* **ポッド**:ポッドを表すオブジェクト。 このオブジェクトは、ユーザーのコードで使用するためのものではありません。
