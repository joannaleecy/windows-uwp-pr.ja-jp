---
author: mcleanbyron
ms.assetid: cc24ba75-a185-4488-b70c-fd4078bc4206
description: AdScheduler クラスを使ってビデオ コンテンツに広告を表示する方法について説明します。
title: ビデオ コンテンツに広告を表示する
ms.author: mcleans
ms.date: 03/22/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 広告, 宣伝, ビデオ, スケジューラ, Javascript
ms.localizationpriority: medium
ms.openlocfilehash: 9142770c6063aba34977c20309bcaeb6ac46450e
ms.sourcegitcommit: 6618517dc0a4e4100af06e6d27fac133d317e545
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1690648"
---
# <a name="show-ads-in-video-content"></a><span data-ttu-id="117bc-104">ビデオ コンテンツに広告を表示する</span><span class="sxs-lookup"><span data-stu-id="117bc-104">Show ads in video content</span></span>

<span data-ttu-id="117bc-105">このチュートリアルでは、JavaScript と HTML を使って作成されたユニバーサル Windows プラットフォーム (UWP) アプリのビデオ コンテンツに、**AdScheduler** クラスを使って広告を表示する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="117bc-105">This walkthrough shows how to use the **AdScheduler** class to show ads in video content in a Universal Windows Platform (UWP) app that was written using JavaScript with HTML.</span></span>

> [!NOTE]
> <span data-ttu-id="117bc-106">この機能は現在、JavaScript と HTML を使って作成された UWP アプリでのみサポートされています。</span><span class="sxs-lookup"><span data-stu-id="117bc-106">This feature is currently supported only for UWP apps that are written using JavaScript with HTML.</span></span>

<span data-ttu-id="117bc-107">**AdScheduler** は、プログレッシブ メディアとストリーミング メディアの両方で機能し、IAB 標準の Video Ad Serving Template (VAST) 2.0/3.0 と VMAP ペイロード形式を使用します。</span><span class="sxs-lookup"><span data-stu-id="117bc-107">**AdScheduler** works with both progressive and streaming media, and uses IAB standard Video Ad Serving Template (VAST) 2.0/3.0 and VMAP payload formats.</span></span> <span data-ttu-id="117bc-108">標準規格を使用しているため、**AdScheduler**は、通信相手の広告サービスに依存しません。</span><span class="sxs-lookup"><span data-stu-id="117bc-108">By using standards, **AdScheduler** is agnostic to the ad service with which it interacts.</span></span>

<span data-ttu-id="117bc-109">ビデオ コンテンツの広告は、プログラムが 10 分未満 (短い形式) か、10 分 (長い形式) を超えるかによって異なります。</span><span class="sxs-lookup"><span data-stu-id="117bc-109">Advertising for video content differs based upon whether the program is under ten minutes (short form), or over ten minutes (long form).</span></span> <span data-ttu-id="117bc-110">後者は前者よりもサービス上の設定が複雑ですが、クライアント側コードの作成方法にはほとんど違いはありません。</span><span class="sxs-lookup"><span data-stu-id="117bc-110">Although the latter is more complicated to set up on the service, there is actually no difference in how one writes the client side code.</span></span> <span data-ttu-id="117bc-111">**AdScheduler** が、マニフェストの代わりに 1 つの広告のみを含む VAST ペイロードを受け取った場合、その VAST ペイロードは 1 つのプリロール広告 (00:00 の時点で再生) についてマニフェストが呼び出された場合と同様に処理されます。</span><span class="sxs-lookup"><span data-stu-id="117bc-111">If the **AdScheduler** receives a VAST payload with a single ad instead of a manifest, it is treated as if the manifest called for a single pre-roll ad (one break at time 00:00).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="117bc-112">前提条件</span><span class="sxs-lookup"><span data-stu-id="117bc-112">Prerequisites</span></span>

* <span data-ttu-id="117bc-113">Visual Studio 2015 以降のリリースと共に [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="117bc-113">Install the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) with Visual Studio 2015 or a later release.</span></span>

* <span data-ttu-id="117bc-114">広告がスケジュールされるビデオ コンテンツを提供するためには、プロジェクトで [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) コントロールを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="117bc-114">Your project must use the [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) control to serve the video content in which the ads will be scheduled.</span></span> <span data-ttu-id="117bc-115">このコントロールは、Microsoft の GitHub から入手できる [TVHelpers](https://github.com/Microsoft/TVHelpers) コレクションのライブラリにあります。</span><span class="sxs-lookup"><span data-stu-id="117bc-115">This control is available in the [TVHelpers](https://github.com/Microsoft/TVHelpers) collection of libraries available from Microsoft on GitHub.</span></span>

  <span data-ttu-id="117bc-116">次の例では、HTML マークアップで [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) を宣言する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="117bc-116">The following example shows how to declare a [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) in HTML markup.</span></span> <span data-ttu-id="117bc-117">通常、このマークアップは index.html ファイル (またはプロジェクトに対応するその他の html ファイル) の `<body>` セクションに含まれます。</span><span class="sxs-lookup"><span data-stu-id="117bc-117">Typically, this markup belongs in the `<body>` section in the index.html file (or another html file as appropriate for your project).</span></span>

  ``` html
  <div id="MediaPlayerDiv" data-win-control="TVJS.MediaPlayer">
    <video src="URL to your content">
    </video>
  </div>
  ```

  <span data-ttu-id="117bc-118">次の例では、JavaScript コードで [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) を確立する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="117bc-118">The following example shows how to establish a [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) in JavaScript code.</span></span>

  [!code-javascript[TrialVersion](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet1)]

## <a name="how-to-use-the-adscheduler-class-in-your-code"></a><span data-ttu-id="117bc-119">コードで AdScheduler クラスを使用する方法</span><span class="sxs-lookup"><span data-stu-id="117bc-119">How to use the AdScheduler class in your code</span></span>

1. <span data-ttu-id="117bc-120">Visual Studio でプロジェクトを開くか、新しいプロジェクトを作ります。</span><span class="sxs-lookup"><span data-stu-id="117bc-120">In Visual Studio, open your project or create a new project.</span></span>

2. <span data-ttu-id="117bc-121">プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。</span><span class="sxs-lookup"><span data-stu-id="117bc-121">If your project targets **Any CPU**, update your project to use an architecture-specific build output (for example, **x86**).</span></span> <span data-ttu-id="117bc-122">プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising ライブラリへの参照を正常に追加できません。</span><span class="sxs-lookup"><span data-stu-id="117bc-122">If your project targets **Any CPU**, you will not be able to successfully add a reference to the Microsoft advertising library in the following steps.</span></span> <span data-ttu-id="117bc-123">詳しくは、「[プロジェクトのターゲットを "Any CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="117bc-123">For more information, see [Reference errors caused by targeting Any CPU in your project](known-issues-for-the-advertising-libraries.md#reference_errors).</span></span>

3. <span data-ttu-id="117bc-124">**Microsoft Advertising SDK for JavaScript** ライブラリへの参照をプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="117bc-124">Add a reference to the **Microsoft Advertising SDK for JavaScript** library to your project.</span></span>

    1. <span data-ttu-id="117bc-125">**[ソリューション エクスプローラー]** ウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="117bc-125">From the **Solution Explorer** window, right click **References**, and select **Add Reference…**</span></span>
    2. <span data-ttu-id="117bc-126">**[参照マネージャー]** で、**[ユニバーサル Windows]** を展開し、**[拡張]** をクリックして、**[Microsoft Advertising SDK for JavaScript]** (バージョン 10.0) の横にあるチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="117bc-126">In **Reference Manager**, expand **Universal Windows**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for JavaScript** (Version 10.0).</span></span>
    3. <span data-ttu-id="117bc-127">**[参照マネージャー]** で、[OK] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="117bc-127">In **Reference Manager**, click OK.</span></span>

4.  <span data-ttu-id="117bc-128">AdScheduler.js ファイルをプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="117bc-128">Add the AdScheduler.js file to your project:</span></span>

    1. <span data-ttu-id="117bc-129">Visual Studio で、**[プロジェクト]**、**[NuGet パッケージの管理]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="117bc-129">In Visual Studio, click **Project** and **Manage NuGet Packages**.</span></span>
    2. <span data-ttu-id="117bc-130">検索ボックスに、「**Microsoft.StoreServices.VideoAdScheduler**」と入力し、Microsoft.StoreServices.VideoAdScheduler パッケージをインストールします。</span><span class="sxs-lookup"><span data-stu-id="117bc-130">In the search box, type **Microsoft.StoreServices.VideoAdScheduler** and install the Microsoft.StoreServices.VideoAdScheduler package.</span></span> <span data-ttu-id="117bc-131">AdScheduler.js ファイルがプロジェクトの ../js サブディレクトリに追加されます。</span><span class="sxs-lookup"><span data-stu-id="117bc-131">The AdScheduler.js file is added to the ../js subdirectory in your project.</span></span>

5.  <span data-ttu-id="117bc-132">index.html ファイル (またはプロジェクトに対応するその他の html ファイル) を開きます。</span><span class="sxs-lookup"><span data-stu-id="117bc-132">Open the index.html file (or other html file as appropriate for your project).</span></span> <span data-ttu-id="117bc-133">`<head>` セクションで、プロジェクトの default.css と main.js の JavaScript 参照の後に、ad.js と adscheduler.js への参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="117bc-133">In the `<head>` section, after the project’s JavaScript references of default.css and main.js, add the reference to ad.js and adscheduler.js.</span></span>

    ``` html
    <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
    <script src="/js/adscheduler.js"></script>
    ```

    > [!NOTE]
    > <span data-ttu-id="117bc-134">この行は、`<head>` セクションの main.js のインクルードの後に配置する必要があります。そうでない場合、プロジェクトのビルド時にエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="117bc-134">This line must be placed in the `<head>` section after the include of main.js; otherwise, you will encounter an error when   you build your project.</span></span>

6.  <span data-ttu-id="117bc-135">プロジェクトの main.js ファイルで、新しい **AdScheduler** オブジェクトを作成するコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="117bc-135">In the main.js file in your project, add code that creates a new **AdScheduler** object.</span></span> <span data-ttu-id="117bc-136">ビデオ コンテンツをホストする **MediaPlayer** を渡します。</span><span class="sxs-lookup"><span data-stu-id="117bc-136">Pass in the **MediaPlayer** that hosts your video content.</span></span> <span data-ttu-id="117bc-137">このコードは、[WinJS.UI.processAll](https://docs.microsoft.com/en-us/previous-versions/windows/apps/hh440975) の後に実行されるように配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="117bc-137">The code must be placed so that it runs after [WinJS.UI.processAll](https://docs.microsoft.com/en-us/previous-versions/windows/apps/hh440975).</span></span>

    [!code-javascript[TrialVersion](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet2)]

7.  <span data-ttu-id="117bc-138">**AdScheduler** オブジェクトの **requestSchedule** メソッドまたは **requestScheduleByUrl** メソッドを使ってサーバーに広告スケジュールを要求し、それを **MediaPlayer** タイムラインに挿入してから、ビデオ メディアを再生します。</span><span class="sxs-lookup"><span data-stu-id="117bc-138">Use the **requestSchedule** or **requestScheduleByUrl** methods of the **AdScheduler** object to request an ad schedule from the server and insert it into the **MediaPlayer** timeline, and then play the video media.</span></span>

    * <span data-ttu-id="117bc-139">Microsoft 広告サーバーに対して広告スケジュールを要求することを許可されている Microsoft パートナーは、**requestSchedule** を使用して、Microsoft の担当者が提供するアプリケーション ID と広告ユニット ID を指定します。</span><span class="sxs-lookup"><span data-stu-id="117bc-139">If you are a Microsoft partner who has received permission to request an ad schedule from the Microsoft ad server, use **requestSchedule** and specify the application ID and ad unit ID that were provided to you by your Microsoft representative.</span></span>

        <span data-ttu-id="117bc-140">このメソッドでは、非同期コンストラクトである [Promise](https://docs.microsoft.com/windows/uwp/threading-async/asynchronous-programming-universal-windows-platform-apps#asynchronous-patterns-in-uwp-using-javascript) の形式を使い、2 つの関数ポインターを渡します。2 つとは、promise の正常完了時に呼び出される **onComplete** 関数へのポインターと、エラーが発生した場合に呼び出される **onError** 関数へのポインターです。</span><span class="sxs-lookup"><span data-stu-id="117bc-140">This method takes the form of a [Promise](https://docs.microsoft.com/windows/uwp/threading-async/asynchronous-programming-universal-windows-platform-apps#asynchronous-patterns-in-uwp-using-javascript), which is an asynchronous construct where two function pointers are passed: a pointer for the **onComplete** function to call when the promise completes successfully and a pointer for the **onError** function to call if an error is encountered.</span></span> <span data-ttu-id="117bc-141">**onComplete** 関数で、ビデオ コンテンツの再生を開始します。</span><span class="sxs-lookup"><span data-stu-id="117bc-141">In the **onComplete** function, start playback of your video content.</span></span> <span data-ttu-id="117bc-142">スケジュールされた時間に広告の再生が始まります。</span><span class="sxs-lookup"><span data-stu-id="117bc-142">The ad will start playing at the scheduled time.</span></span> <span data-ttu-id="117bc-143">**onError** 関数では、エラーを処理してからビデオの再生を開始します。</span><span class="sxs-lookup"><span data-stu-id="117bc-143">In your **onError** function, handle the error and then start playback of your video.</span></span> <span data-ttu-id="117bc-144">ビデオ コンテンツは広告なしで再生されます。</span><span class="sxs-lookup"><span data-stu-id="117bc-144">Your video content will play without an ad.</span></span> <span data-ttu-id="117bc-145">**onError** 関数の引数は、次のメンバーを含むオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="117bc-145">The argument of the **onError** function is an object that contains the following members.</span></span>

        [!code-javascript[TrialVersion](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet3)]

    * <span data-ttu-id="117bc-146">Microsoft 以外の広告サーバーに広告スケジュールを要求するには、**requestScheduleByUrl** を使用し、サーバー URI を指定します。</span><span class="sxs-lookup"><span data-stu-id="117bc-146">To request an ad schedule from a non-Microsoft ad server, use **requestScheduleByUrl**, and pass in the server URI.</span></span> <span data-ttu-id="117bc-147">このメソッドも **Promise** の形式を使い、**onComplete** 関数と **onError** 関数へのポインターを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="117bc-147">This method also takes the form of a **Promise** that accepts pointers for the **onComplete** and **onError** functions.</span></span> <span data-ttu-id="117bc-148">サーバーから返される広告ペイロードは、Video Ad Serving Template (VAST) または Video Multiple Ad Playlist (VMAP) ペイロード形式に準拠している必要があります。</span><span class="sxs-lookup"><span data-stu-id="117bc-148">The ad payload that is returned from the server must conform to the Video Ad Serving Template (VAST) or Video Multiple Ad Playlist (VMAP) payload formats.</span></span>

        [!code-javascript[TrialVersion](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet4)]

    > [!NOTE]
    > <span data-ttu-id="117bc-149">**MediaPlayer** でメインのビデオ コンテンツの再生を開始する前に、**requestSchedule** または **requestScheduleByUrl** が戻るまで待機する必要があります。</span><span class="sxs-lookup"><span data-stu-id="117bc-149">You should wait for **requestSchedule** or **requestScheduleByUrl** to return before starting to play the primary video content in the **MediaPlayer**.</span></span> <span data-ttu-id="117bc-150">**requestSchedule** が戻る前にメディアの再生を開始すると (プリロール広告の場合)、プリロールによってメインのビデオ コンテンツが中断されます。</span><span class="sxs-lookup"><span data-stu-id="117bc-150">Starting to play media before **requestSchedule** returns (in the case of a pre-roll advertisement) will result in the pre-roll interrupting the primary video content.</span></span> <span data-ttu-id="117bc-151">関数が失敗した場合でも、**play** を呼び出す必要があります。**AdScheduler** は、広告をスキップしてコンテンツに直接移動するように **MediaPlayer** に通知するためです。</span><span class="sxs-lookup"><span data-stu-id="117bc-151">You must call **play** even if the function fails, because the **AdScheduler** will tell the **MediaPlayer** to skip the ad(s) and move straight to the content.</span></span> <span data-ttu-id="117bc-152">ビジネス要件によっては、広告がリモートで正常に取得できない場合に、ビルトイン広告を挿入するなどの処理を行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="117bc-152">You may have a different business requirement, such as inserting a built-in ad if an ad can't be successfully fetched remotely.</span></span>

8.  <span data-ttu-id="117bc-153">再生中に、アプリが進行状況や、最初の広告マッチング プロセス後に発生したエラーを追跡するための追加のイベントを処理できます。</span><span class="sxs-lookup"><span data-stu-id="117bc-153">During playback, you can handle additional events that let your app track progress and/or errors which may occur after the initial ad matching process.</span></span> <span data-ttu-id="117bc-154">次のコードでは、このようなイベントのうち、**onPodStart**、**onPodEnd**、**onPodCountdown**、**onAdProgress**、**onAllComplete**、**onErrorOccurred** を示します。</span><span class="sxs-lookup"><span data-stu-id="117bc-154">The following code shows some of these events, including **onPodStart**, **onPodEnd**, **onPodCountdown**, **onAdProgress**, **onAllComplete**, and **onErrorOccurred**.</span></span>

    [!code-javascript[TrialVersion](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet5)]

## <a name="adscheduler-members"></a><span data-ttu-id="117bc-155">AdScheduler のメンバー</span><span class="sxs-lookup"><span data-stu-id="117bc-155">AdScheduler members</span></span>

<span data-ttu-id="117bc-156">このセクションでは、**AdScheduler** オブジェクトのメンバーについて説明します。</span><span class="sxs-lookup"><span data-stu-id="117bc-156">This section provides some details about the members of the **AdScheduler** object.</span></span> <span data-ttu-id="117bc-157">これらのメンバーについて詳しくは、プロジェクトに含まれている AdScheduler.js ファイル内のコメントと定義をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="117bc-157">For more information about these members, see the comments and definitions in the AdScheduler.js file in your project.</span></span>

### <a name="requestschedule"></a><span data-ttu-id="117bc-158">requestSchedule</span><span class="sxs-lookup"><span data-stu-id="117bc-158">requestSchedule</span></span>

<span data-ttu-id="117bc-159">このメソッドは、Microsoft 広告サーバーに広告スケジュールを要求し、それを **AdScheduler** コンストラクターに渡された **MediaPlayer** のタイムラインに挿入します。</span><span class="sxs-lookup"><span data-stu-id="117bc-159">This method requests an ad schedule from the Microsoft ad server and inserts it into the timeline of the **MediaPlayer** that was passed to the **AdScheduler** constructor.</span></span>

<span data-ttu-id="117bc-160">省略可能な第 3 パラメーター (*adTags*) は、名前と値のペアを含む JSON コレクションで、高度なターゲット設定を必要とするアプリで使用できます。</span><span class="sxs-lookup"><span data-stu-id="117bc-160">The optional third paramter (*adTags*) is a JSON collection of name/value pairs that can be used for apps that have advanced targeting.</span></span> <span data-ttu-id="117bc-161">たとえば、自動車関連のさまざまなビデオを再生するアプリでは、広告ユニット ID に加えて、表示する自動車のメーカーとモデルを渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="117bc-161">For example, an app that plays a variety of auto-related videos might supplement the ad unit ID with the make and model of the car being shown.</span></span> <span data-ttu-id="117bc-162">このパラメーターは、広告タグの使用について Microsoft から承認を受けたパートナーのみが使うことを想定しています。</span><span class="sxs-lookup"><span data-stu-id="117bc-162">This parameter is intended to be used only by partners who receive approval from Microsoft to use ad tags.</span></span>

<span data-ttu-id="117bc-163">*adTags* を参照するときは次の点に注意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="117bc-163">The following items should be noted when referring to *adTags*:</span></span>

* <span data-ttu-id="117bc-164">このパラメーターはほとんど使用されないオプションです。</span><span class="sxs-lookup"><span data-stu-id="117bc-164">This parameter is a very rarely used option.</span></span> <span data-ttu-id="117bc-165">発行元は、adTags を使用する前に Microsoft とよく相談する必要があります。</span><span class="sxs-lookup"><span data-stu-id="117bc-165">The publisher must work closely with Microsoft before using adTags.</span></span>
* <span data-ttu-id="117bc-166">名前と値はどちらも、広告サービスで事前に決定されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="117bc-166">Both the names and the values must be predetermined on the ad service.</span></span> <span data-ttu-id="117bc-167">広告タグは自由な検索用語やキーワードではありません。</span><span class="sxs-lookup"><span data-stu-id="117bc-167">Ad tags are not open ended search terms or keywords.</span></span>
* <span data-ttu-id="117bc-168">サポートされている最大のタグ数は 10 です。</span><span class="sxs-lookup"><span data-stu-id="117bc-168">The maximum supported number of tags is 10.</span></span>
* <span data-ttu-id="117bc-169">タグ名は 16 文字に制限されています。</span><span class="sxs-lookup"><span data-stu-id="117bc-169">Tag names are restricted to 16 characters.</span></span>
* <span data-ttu-id="117bc-170">タグの値は最大 128 文字です。</span><span class="sxs-lookup"><span data-stu-id="117bc-170">Tag values have a maximum of 128 characters.</span></span>

### <a name="requestschedulebyuri"></a><span data-ttu-id="117bc-171">requestScheduleByUri</span><span class="sxs-lookup"><span data-stu-id="117bc-171">requestScheduleByUri</span></span>

<span data-ttu-id="117bc-172">このメソッドは、URI で指定された Microsoft 以外の広告サーバーに広告スケジュールを要求し、それを **AdScheduler** コンストラクターに渡された **MediaPlayer** のタイムラインに挿入します。</span><span class="sxs-lookup"><span data-stu-id="117bc-172">This method requests an ad schedule from the non-Microsoft ad server specified in the URI and inserts it into the timeline of the **MediaPlayer** that was passed to the **AdScheduler** constructor.</span></span> <span data-ttu-id="117bc-173">広告サーバーから返される広告ペイロードは、Video Ad Serving Template (VAST) または Video Multiple Ad Playlist (VMAP) ペイロード形式に準拠している必要があります。</span><span class="sxs-lookup"><span data-stu-id="117bc-173">The ad payload that is returned by the ad server must conform to the Video Ad Serving Template (VAST) or Video Multiple Ad Playlist (VMAP) payload formats.</span></span>

### <a name="mediatimeout"></a><span data-ttu-id="117bc-174">mediaTimeout</span><span class="sxs-lookup"><span data-stu-id="117bc-174">mediaTimeout</span></span>

<span data-ttu-id="117bc-175">このプロパティは、メディアを再生可能にする時間をミリ秒単位で取得または設定します。</span><span class="sxs-lookup"><span data-stu-id="117bc-175">This property gets or sets the number of milliseconds that the media must be playable.</span></span> <span data-ttu-id="117bc-176">値 0 は、タイムアウトしないようにシステムに通知します。</span><span class="sxs-lookup"><span data-stu-id="117bc-176">A value of 0 informs the system to never timeout.</span></span> <span data-ttu-id="117bc-177">既定値は 30000 ミリ秒 (30 秒) です。</span><span class="sxs-lookup"><span data-stu-id="117bc-177">The default is 30000 ms (30 seconds).</span></span>

### <a name="playskippedmedia"></a><span data-ttu-id="117bc-178">playSkippedMedia</span><span class="sxs-lookup"><span data-stu-id="117bc-178">playSkippedMedia</span></span>

<span data-ttu-id="117bc-179">このプロパティは、スケジュールされた開始時間よりも先の位置までユーザーがスキップした場合に、スケジュールされたメディアを再生するかどうかを示す**ブール**値を取得または設定します。</span><span class="sxs-lookup"><span data-stu-id="117bc-179">This property gets or sets a **Boolean** value that indicates whether scheduled media will play if user skips ahead to a point past a scheduled start time.</span></span>

<span data-ttu-id="117bc-180">メインのビデオ コンテンツの早送り中や巻き戻し中の広告の動作については、広告クライアントとメディア プレイヤーによってルールが適用されます。</span><span class="sxs-lookup"><span data-stu-id="117bc-180">The ad client and media player will enforce rules in terms what happens to advertisements during fast forwarding and rewinding of the primary video content.</span></span> <span data-ttu-id="117bc-181">通常、アプリ開発者は広告を完全にスキップできるようにはしませんが、妥当なエクスペリエンスをユーザーに提供することを望みます。</span><span class="sxs-lookup"><span data-stu-id="117bc-181">In most cases, app developers do not allow advertisements to be entirely skipped over but do want to provide a reasonable experience for the user.</span></span> <span data-ttu-id="117bc-182">次の 2 つのオプションは、ほとんどの開発者のニーズに対応します。</span><span class="sxs-lookup"><span data-stu-id="117bc-182">The following two options fall within the needs of most developers:</span></span>

1. <span data-ttu-id="117bc-183">エンド ユーザーが自由に広告ポッドをスキップできるようにします。</span><span class="sxs-lookup"><span data-stu-id="117bc-183">Allow end-users to skip over advertisement pods at will.</span></span>
2. <span data-ttu-id="117bc-184">ユーザーが広告ポッドをスキップできるようにしますが、再生を再開するときは最後のポッドを再生します。</span><span class="sxs-lookup"><span data-stu-id="117bc-184">Allow users to skip over advertisement pods but play the most recent pod when playback resumes.</span></span>

<span data-ttu-id="117bc-185">**playSkippedMedia** プロパティには次の条件があります。</span><span class="sxs-lookup"><span data-stu-id="117bc-185">The **playSkippedMedia** property has the following conditions:</span></span>

* <span data-ttu-id="117bc-186">いったん広告が開始されたら、広告をスキップしたり早送りしたりできない。</span><span class="sxs-lookup"><span data-stu-id="117bc-186">Advertisements cannot be skipped or fast forwarded once the advertisement begins.</span></span>
* <span data-ttu-id="117bc-187">いったんポッドが開始されたら、広告ポッド内のすべての広告を再生する。</span><span class="sxs-lookup"><span data-stu-id="117bc-187">All advertisements in an advertisement pod will play once the pod has started.</span></span>
* <span data-ttu-id="117bc-188">いったん再生されたら、メインのコンテンツ (映画、エピソードなど) の間は広告を再び再生しない。広告マーカーは再生済みまたは削除済みとマークされる。</span><span class="sxs-lookup"><span data-stu-id="117bc-188">Once played, an advertisement will not play again during the primary content (movie, episode, etc.); advertisement markers will be marked as played or removed.</span></span>
* <span data-ttu-id="117bc-189">プリロール広告はスキップできない。</span><span class="sxs-lookup"><span data-stu-id="117bc-189">Pre-rollout advertisements cannot be skipped.</span></span>

<span data-ttu-id="117bc-190">広告を含んでいるコンテンツを再開するときは、**playSkippedMedia** を **false** に設定することで、プリロール広告をスキップして最新の広告ブレークの再生を回避します。</span><span class="sxs-lookup"><span data-stu-id="117bc-190">When resuming content that contains advertising, set **playSkippedMedia** to **false** to skip pre-rolls and prevent the most recent ad break from playing.</span></span> <span data-ttu-id="117bc-191">次に、コンテンツの開始後に **playSkippedMedia** を **true** に設定して、ユーザーが後続の広告を早送りできないようにします。</span><span class="sxs-lookup"><span data-stu-id="117bc-191">Then, after the content starts, set **playSkippedMedia** to **true** to ensure that users cannot fast-forward through subsequent ads.</span></span>

> [!NOTE]
> <span data-ttu-id="117bc-192">ポッドとは、連続して再生される広告のグループです。広告ブレークの間に再生される広告のグループなどがあります。</span><span class="sxs-lookup"><span data-stu-id="117bc-192">A pod is a group of ads that play in a sequence, such as a group of ads that play during a commercial break.</span></span> <span data-ttu-id="117bc-193">詳しくは、IAB Digital Video Ad Serving Template (VAST) の仕様をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="117bc-193">For more details, see the IAB Digital Video Ad Serving Template (VAST) specification.</span></span>

### <a name="requesttimeout"></a><span data-ttu-id="117bc-194">requestTimeout</span><span class="sxs-lookup"><span data-stu-id="117bc-194">requestTimeout</span></span>

<span data-ttu-id="117bc-195">このプロパティは、広告要求の応答がタイムアウトするまでの待ち時間をミリ秒単位で取得または設定します。値 0 は、タイムアウトしないようにシステムに通知します。</span><span class="sxs-lookup"><span data-stu-id="117bc-195">This property gets or sets the number of milliseconds to wait for an ad request response before timing out. A value of 0 informs the system to never timeout.</span></span> <span data-ttu-id="117bc-196">既定値は 30000 ミリ秒 (30 秒) です。</span><span class="sxs-lookup"><span data-stu-id="117bc-196">The default is 30000 ms (30 seconds).</span></span>

### <a name="schedule"></a><span data-ttu-id="117bc-197">schedule</span><span class="sxs-lookup"><span data-stu-id="117bc-197">schedule</span></span>

<span data-ttu-id="117bc-198">このプロパティは、広告サーバーから受け取ったスケジュール データを取得します。</span><span class="sxs-lookup"><span data-stu-id="117bc-198">This property gets the schedule data that was retrieved from the ad server.</span></span> <span data-ttu-id="117bc-199">このオブジェクトには、Video Ad Serving Template (VAST) または Video Multiple Ad Playlist (VMAP) ペイロードの構造に対応する完全なデータ階層が含まれます。</span><span class="sxs-lookup"><span data-stu-id="117bc-199">This object includes the full hierarchy of data that corresponds to the structure of the Video Ad Serving Template (VAST) or Video Multiple Ad Playlist (VMAP) payload.</span></span>

### <a name="onadprogress"></a><span data-ttu-id="117bc-200">onAdProgress</span><span class="sxs-lookup"><span data-stu-id="117bc-200">onAdProgress</span></span>  

<span data-ttu-id="117bc-201">このイベントは、広告の再生が 4 分の 1 ごとのチェックポイントに到達したときに発生します。</span><span class="sxs-lookup"><span data-stu-id="117bc-201">This event is raised when ad playback reaches quartile checkpoints.</span></span> <span data-ttu-id="117bc-202">イベント ハンドラーの第 2 パラメーター (*eventInfo*) は、次のメンバーを含む JSON オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="117bc-202">The second parameter of the event handler (*eventInfo*) is a JSON object with the following members:</span></span>

* <span data-ttu-id="117bc-203">**progress**: 広告の再生状態 (AdScheduler.js に定義されている **MediaProgress** 列挙型の値のいずれか)。</span><span class="sxs-lookup"><span data-stu-id="117bc-203">**progress**: The ad playback status (one of the **MediaProgress** enum values defined in AdScheduler.js).</span></span>
* <span data-ttu-id="117bc-204">**clip**: 再生中のビデオ クリップ。</span><span class="sxs-lookup"><span data-stu-id="117bc-204">**clip**: The video clip that is being played.</span></span> <span data-ttu-id="117bc-205">このオブジェクトは、ユーザーのコードで使用するためのものではありません。</span><span class="sxs-lookup"><span data-stu-id="117bc-205">This object is not intended to be used in your code.</span></span>
* <span data-ttu-id="117bc-206">**adPackage**: 再生中の広告に対応する広告ペイロードの部分を表すオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="117bc-206">**adPackage**: An object that represents the part of the ad payload that corresponds to the ad that is playing.</span></span> <span data-ttu-id="117bc-207">このオブジェクトは、ユーザーのコードで使用するためのものではありません。</span><span class="sxs-lookup"><span data-stu-id="117bc-207">This object is not intended to be used in your code.</span></span>

### <a name="onallcomplete"></a><span data-ttu-id="117bc-208">onAllComplete</span><span class="sxs-lookup"><span data-stu-id="117bc-208">onAllComplete</span></span>  

<span data-ttu-id="117bc-209">このイベントは、メイン コンテンツが終了し、スケジュールされたポストロール広告も終了したときに発生します。</span><span class="sxs-lookup"><span data-stu-id="117bc-209">This event is raised when the main content reaches the end and any scheduled post-roll ads are also ended.</span></span>

### <a name="onerroroccurred"></a><span data-ttu-id="117bc-210">onErrorOccurred</span><span class="sxs-lookup"><span data-stu-id="117bc-210">onErrorOccurred</span></span>  

<span data-ttu-id="117bc-211">このイベントは、**AdScheduler** でエラーが発生したときに生成されます。</span><span class="sxs-lookup"><span data-stu-id="117bc-211">This event is raised when the **AdScheduler** encounters an error.</span></span> <span data-ttu-id="117bc-212">エラー コードの値について詳しくは、「[ErrorCode](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.errorcode.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="117bc-212">For more information about the error code values, see [ErrorCode](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.errorcode.aspx).</span></span>

### <a name="onpodcountdown"></a><span data-ttu-id="117bc-213">onPodCountdown</span><span class="sxs-lookup"><span data-stu-id="117bc-213">onPodCountdown</span></span>

<span data-ttu-id="117bc-214">このイベントは、広告の再生中に発生し、現在のポッドの残り時間を通知します。</span><span class="sxs-lookup"><span data-stu-id="117bc-214">This event is raised when an ad is playing and indicates how much time remains in the current pod.</span></span> <span data-ttu-id="117bc-215">イベント ハンドラーの第 2 パラメーター (*eventData*) は、次のメンバーを含む JSON オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="117bc-215">The second parameter of the event handler (*eventData*) is a JSON object with the following members:</span></span>

* <span data-ttu-id="117bc-216">**remainingAdTime**: 現在の広告の残り時間を示す秒数。</span><span class="sxs-lookup"><span data-stu-id="117bc-216">**remainingAdTime**: The number of seconds left for the current ad.</span></span>
* <span data-ttu-id="117bc-217">**remainingPodTime**: 現在のポッドの残り時間を示す秒数。</span><span class="sxs-lookup"><span data-stu-id="117bc-217">**remainingPodTime**: The number of seconds left for the current pod.</span></span>

> [!NOTE]
> <span data-ttu-id="117bc-218">ポッドとは、連続して再生される広告のグループです。広告ブレークの間に再生される広告のグループなどがあります。</span><span class="sxs-lookup"><span data-stu-id="117bc-218">A pod is a group of ads that play in a sequence, such as a group of ads that play during a commercial break.</span></span> <span data-ttu-id="117bc-219">詳しくは、IAB Digital Video Ad Serving Template (VAST) の仕様をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="117bc-219">For more details, see the IAB Digital Video Ad Serving Template (VAST) specification.</span></span>

### <a name="onpodend"></a><span data-ttu-id="117bc-220">onPodEnd</span><span class="sxs-lookup"><span data-stu-id="117bc-220">onPodEnd</span></span>  

<span data-ttu-id="117bc-221">このイベントは、広告ポッドが終了したときに発生します。</span><span class="sxs-lookup"><span data-stu-id="117bc-221">This event is raised when an ad pod ends.</span></span> <span data-ttu-id="117bc-222">イベント ハンドラーの第 2 パラメーター (*eventData*) は、次のメンバーを含む JSON オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="117bc-222">The second parameter of the event handler (*eventData*) is a JSON object with the following members:</span></span>

* <span data-ttu-id="117bc-223">**startTime**: ポッドの開始時間 (秒単位)。</span><span class="sxs-lookup"><span data-stu-id="117bc-223">**startTime**: The pod's start time, in seconds.</span></span>
* <span data-ttu-id="117bc-224">**pod**: ポッドを表すオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="117bc-224">**pod**: An object that represents the pod.</span></span> <span data-ttu-id="117bc-225">このオブジェクトは、ユーザーのコードで使用するためのものではありません。</span><span class="sxs-lookup"><span data-stu-id="117bc-225">This object is not intended to be used in your code.</span></span>

### <a name="onpodstart"></a><span data-ttu-id="117bc-226">onPodStart</span><span class="sxs-lookup"><span data-stu-id="117bc-226">onPodStart</span></span>

<span data-ttu-id="117bc-227">このイベントは、広告ポッドが開始されたときに発生します。</span><span class="sxs-lookup"><span data-stu-id="117bc-227">This event is raised when an ad pod starts.</span></span> <span data-ttu-id="117bc-228">イベント ハンドラーの第 2 パラメーター (*eventData*) は、次のメンバーを含む JSON オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="117bc-228">The second parameter of the event handler (*eventData*) is a JSON object with the following members:</span></span>

* <span data-ttu-id="117bc-229">**startTime**: ポッドの開始時間 (秒単位)。</span><span class="sxs-lookup"><span data-stu-id="117bc-229">**startTime**: The pod's start time, in seconds.</span></span>
* <span data-ttu-id="117bc-230">**pod**: ポッドを表すオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="117bc-230">**pod**: An object that represents the pod.</span></span> <span data-ttu-id="117bc-231">このオブジェクトは、ユーザーのコードで使用するためのものではありません。</span><span class="sxs-lookup"><span data-stu-id="117bc-231">This object is not intended to be used in your code.</span></span>
