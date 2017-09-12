---
author: mcleanbyron
ms.assetid: cc24ba75-a185-4488-b70c-fd4078bc4206
description: "AdScheduler クラスを使ってビデオ コンテンツに広告を表示する方法について説明します。"
title: "ビデオ コンテンツに広告を表示する"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, 宣伝, ビデオ, スケジューラ, Javascript"
ms.openlocfilehash: 834547db2d58291e3bbf75a738d9775e25fbb8e5
ms.sourcegitcommit: 9d1ca16a7edcbbcae03fad50a4a10183a319c63a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/09/2017
---
# <a name="show-ads-in-video-content"></a><span data-ttu-id="d88a1-104">ビデオ コンテンツに広告を表示する</span><span class="sxs-lookup"><span data-stu-id="d88a1-104">Show ads in video content</span></span>


<span data-ttu-id="d88a1-105">このチュートリアルでは、JavaScript と HTML を使って作成されたユニバーサル Windows プラットフォーム (UWP) アプリのビデオ コンテンツに、[AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) クラスを使って広告を表示する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="d88a1-105">This walkthrough shows how to use the [AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) class to show ads in video content in a Universal Windows Platform (UWP) app that was written using JavaScript with HTML.</span></span>

> [!NOTE]
> <span data-ttu-id="d88a1-106">この機能は現在、JavaScript と HTML を使って作成された UWP アプリでのみサポートされています。</span><span class="sxs-lookup"><span data-stu-id="d88a1-106">This feature is currently supported only for UWP apps that are written using JavaScript with HTML.</span></span>

<span data-ttu-id="d88a1-107">[AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) は、プログレッシブ メディアとストリーミング メディアの両方で機能し、IAB 標準の Video Ad Serving Template (VAST) 2.0/3.0 と VMAP ペイロード形式を使用します。</span><span class="sxs-lookup"><span data-stu-id="d88a1-107">[AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) works with both progressive and streaming media, and uses IAB standard Video Ad Serving Template (VAST) 2.0/3.0 and VMAP payload formats.</span></span> <span data-ttu-id="d88a1-108">標準規格を使用しているため、[AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx)は、通信相手の広告サービスに依存しません。</span><span class="sxs-lookup"><span data-stu-id="d88a1-108">By using standards, [AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) is agnostic to the ad service with which it interacts.</span></span>

<span data-ttu-id="d88a1-109">ビデオ コンテンツの広告は、プログラムが 10 分未満 (短い形式) か、10 分 (長い形式) を超えるかによって異なります。</span><span class="sxs-lookup"><span data-stu-id="d88a1-109">Advertising for video content differs based upon whether the program is under ten minutes (short form), or over ten minutes (long form).</span></span> <span data-ttu-id="d88a1-110">後者は前者よりもサービス上の設定が複雑ですが、クライアント側コードの作成方法にはほとんど違いはありません。</span><span class="sxs-lookup"><span data-stu-id="d88a1-110">Although the latter is more complicated to set up on the service, there is actually no difference in how one writes the client side code.</span></span> <span data-ttu-id="d88a1-111">[AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) が、マニフェストの代わりに 1 つの広告のみを含む VAST ペイロードを受け取った場合、その VAST ペイロードは 1 つのプリロール広告 (00:00 の時点で再生) についてマニフェストが呼び出された場合と同様に処理されます。</span><span class="sxs-lookup"><span data-stu-id="d88a1-111">If the [AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) receives a VAST payload with a single ad instead of a manifest, it is treated as if the manifest called for a single pre-roll ad (one break at time 00:00).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="d88a1-112">前提条件</span><span class="sxs-lookup"><span data-stu-id="d88a1-112">Prerequisites</span></span>

* <span data-ttu-id="d88a1-113">Visual Studio 2015 以降のリリースと共に [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="d88a1-113">Install the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) with Visual Studio 2015 or a later release.</span></span>

* <span data-ttu-id="d88a1-114">広告がスケジュールされるビデオ コンテンツを提供するためには、プロジェクトで [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) コントロールを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="d88a1-114">Your project must use the [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) control to serve the video content in which the ads will be scheduled.</span></span> <span data-ttu-id="d88a1-115">このコントロールは、Microsoft の GitHub から入手できる [TVHelpers](https://github.com/Microsoft/TVHelpers) コレクションのライブラリにあります。</span><span class="sxs-lookup"><span data-stu-id="d88a1-115">This control is available in the [TVHelpers](https://github.com/Microsoft/TVHelpers) collection of libraries available from Microsoft on GitHub.</span></span>

  <span data-ttu-id="d88a1-116">次の例では、HTML マークアップで [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) を宣言する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="d88a1-116">The following example shows how to declare a [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) in HTML markup.</span></span> <span data-ttu-id="d88a1-117">通常、このマークアップは index.html ファイル (またはプロジェクトに対応するその他の html ファイル) の `<body>` セクションに含まれます。</span><span class="sxs-lookup"><span data-stu-id="d88a1-117">Typically, this markup belongs in the `<body>` section in the index.html file (or another html file as appropriate for your project).</span></span>

  ``` html
  <div id="MediaPlayerDiv" data-win-control="TVJS.MediaPlayer">
    <video src="URL to your content">
    </video>
  </div>
  ```

  <span data-ttu-id="d88a1-118">次の例では、JavaScript コードで [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) を確立する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="d88a1-118">The following example shows how to establish a [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) in JavaScript code.</span></span>

  [!code-javascript[<span data-ttu-id="d88a1-119">TrialVersion</span><span class="sxs-lookup"><span data-stu-id="d88a1-119">TrialVersion</span></span>](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet1)]

## <a name="how-to-use-the-adscheduler-class-in-your-code"></a><span data-ttu-id="d88a1-120">コードで AdScheduler クラスを使用する方法</span><span class="sxs-lookup"><span data-stu-id="d88a1-120">How to use the AdScheduler class in your code</span></span>

1. <span data-ttu-id="d88a1-121">Visual Studio でプロジェクトを開くか、新しいプロジェクトを作ります。</span><span class="sxs-lookup"><span data-stu-id="d88a1-121">In Visual Studio, open your project or create a new project.</span></span>

2. <span data-ttu-id="d88a1-122">プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。</span><span class="sxs-lookup"><span data-stu-id="d88a1-122">If your project targets **Any CPU**, update your project to use an architecture-specific build output (for example, **x86**).</span></span> <span data-ttu-id="d88a1-123">プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising ライブラリへの参照を正常に追加できません。</span><span class="sxs-lookup"><span data-stu-id="d88a1-123">If your project targets **Any CPU**, you will not be able to successfully add a reference to the Microsoft advertising library in the following steps.</span></span> <span data-ttu-id="d88a1-124">詳しくは、「[プロジェクトのターゲットを "Any CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d88a1-124">For more information, see [Reference errors caused by targeting Any CPU in your project](known-issues-for-the-advertising-libraries.md#reference_errors).</span></span>

3. <span data-ttu-id="d88a1-125">**Microsoft Advertising SDK for JavaScript** ライブラリへの参照をプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="d88a1-125">Add a reference to the **Microsoft Advertising SDK for JavaScript** library to your project.</span></span>

  <span data-ttu-id="d88a1-126">a. </span><span class="sxs-lookup"><span data-stu-id="d88a1-126">a.</span></span> <span data-ttu-id="d88a1-127">**ソリューション エクスプローラー**のウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="d88a1-127">From the **Solution Explorer** window, right click **References**, and select **Add Reference…**</span></span>

  <span data-ttu-id="d88a1-128">b. </span><span class="sxs-lookup"><span data-stu-id="d88a1-128">b.</span></span> <span data-ttu-id="d88a1-129">**[参照マネージャー]** で、**[Universal Windows]** を展開し、**[拡張]** をクリックして、**[Microsoft Advertising SDK for JavaScript]** (バージョン 10.0) の横にあるチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="d88a1-129">In **Reference Manager**, expand **Universal Windows**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for JavaScript** (Version 10.0).</span></span>

  <span data-ttu-id="d88a1-130">c. </span><span class="sxs-lookup"><span data-stu-id="d88a1-130">c.</span></span> <span data-ttu-id="d88a1-131">**[参照マネージャー]** で、[OK] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="d88a1-131">In **Reference Manager**, click OK.</span></span>

4.  <span data-ttu-id="d88a1-132">AdScheduler.js ファイルをプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="d88a1-132">Add the AdScheduler.js file to your project:</span></span>

  <span data-ttu-id="d88a1-133">a. </span><span class="sxs-lookup"><span data-stu-id="d88a1-133">a.</span></span>  <span data-ttu-id="d88a1-134">Visual Studio で、**[プロジェクト]** と **[NuGet パッケージの管理]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="d88a1-134">In Visual Studio, click **Project** and **Manage NuGet Packages**.</span></span>

  <span data-ttu-id="d88a1-135">b. </span><span class="sxs-lookup"><span data-stu-id="d88a1-135">b.</span></span>  <span data-ttu-id="d88a1-136">検索ボックスに、「**Microsoft.StoreServices.VideoAdScheduler**」と入力し、Microsoft.StoreServices.VideoAdScheduler パッケージをインストールします。</span><span class="sxs-lookup"><span data-stu-id="d88a1-136">In the search box, type **Microsoft.StoreServices.VideoAdScheduler** and install the Microsoft.StoreServices.VideoAdScheduler package.</span></span> <span data-ttu-id="d88a1-137">AdScheduler.js ファイルがプロジェクトの ../js サブディレクトリに追加されます。</span><span class="sxs-lookup"><span data-stu-id="d88a1-137">The AdScheduler.js file is added to the ../js subdirectory in your project.</span></span>

5.  <span data-ttu-id="d88a1-138">index.html ファイル (またはプロジェクトに対応するその他の html ファイル) を開きます。</span><span class="sxs-lookup"><span data-stu-id="d88a1-138">Open the index.html file (or other html file as appropriate for your project).</span></span> <span data-ttu-id="d88a1-139">`<head>` セクションで、プロジェクトの default.css と main.js の JavaScript 参照の後に、ad.js と adscheduler.js への参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="d88a1-139">In the `<head>` section, after the project’s JavaScript references of default.css and main.js, add the reference to ad.js and adscheduler.js.</span></span>

  ``` html
  <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
  <script src="/js/adscheduler.js"></script>
  ```

  <span/>
  > <span data-ttu-id="d88a1-140">**注**&nbsp;&nbsp;この行は、`<head>` セクションの main.js のインクルードの後に配置する必要があります。そうでない場合、プロジェクトのビルド時にエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="d88a1-140">**Note**&nbsp;&nbsp;This line must be placed in the `<head>` section after the include of main.js; otherwise, you will encounter an error when you build your project.</span></span>

6.  <span data-ttu-id="d88a1-141">プロジェクトの main.js ファイルで、新しい [AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) オブジェクトを作成するコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="d88a1-141">In the main.js file in your project, add code that creates a new [AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) object.</span></span> <span data-ttu-id="d88a1-142">ビデオ コンテンツをホストする **MediaPlayer** を渡します。</span><span class="sxs-lookup"><span data-stu-id="d88a1-142">Pass in the **MediaPlayer** that hosts your video content.</span></span> <span data-ttu-id="d88a1-143">このコードは、[WinJS.UI.processAll](https://msdn.microsoft.com/library/windows/apps/hh440975.aspx) の後に実行されるように配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d88a1-143">The code must be placed so that it runs after [WinJS.UI.processAll](https://msdn.microsoft.com/library/windows/apps/hh440975.aspx).</span></span>

  [!code-javascript[<span data-ttu-id="d88a1-144">TrialVersion</span><span class="sxs-lookup"><span data-stu-id="d88a1-144">TrialVersion</span></span>](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet2)]

7.  <span data-ttu-id="d88a1-145">[requestSchedule](https://msdn.microsoft.com/library/windows/apps/mt732208.aspx) メソッドまたは [requestScheduleByUrl](https://msdn.microsoft.com/library/windows/apps/mt732210.aspx) メソッドを使用してサーバーに広告スケジュールを要求し、それを **MediaPlayer** タイムラインに挿入してからビデオ メディアを再生します。</span><span class="sxs-lookup"><span data-stu-id="d88a1-145">Use the [requestSchedule](https://msdn.microsoft.com/library/windows/apps/mt732208.aspx) or [requestScheduleByUrl](https://msdn.microsoft.com/library/windows/apps/mt732210.aspx) methods to request an ad schedule from the server and insert it into the **MediaPlayer** timeline, and then play the video media.</span></span>

  * <span data-ttu-id="d88a1-146">Microsoft 広告サーバーに対して広告スケジュールを要求することを許可されている Microsoft パートナーは、[requestSchedule](https://msdn.microsoft.com/library/windows/apps/mt732208.aspx) を使用して、Microsoft の担当者が提供するアプリケーション ID と広告ユニット ID を指定します。</span><span class="sxs-lookup"><span data-stu-id="d88a1-146">If you are a Microsoft partner who has received permission to request an ad schedule from the Microsoft ad server, use [requestSchedule](https://msdn.microsoft.com/library/windows/apps/mt732208.aspx) and specify the application ID and ad unit ID that were provided to you by your Microsoft representative.</span></span> <span data-ttu-id="d88a1-147">このメソッドは、非同期コンストラクトである **Promise** の形式を取り、成功と失敗のそれぞれの場合を処理する 2 つの関数ポインターを渡します。</span><span class="sxs-lookup"><span data-stu-id="d88a1-147">This method takes the form of a **Promise**, which is an asynchronous construct where two function pointers are passed to handle the success and failure cases, respectively.</span></span> <span data-ttu-id="d88a1-148">詳しくは、「[JavaScript を使った UWP での非同期パターン](https://msdn.microsoft.com/windows/uwp/threading-async/asynchronous-programming-universal-windows-platform-apps#asynchronous-patterns-in-uwp-using-javascript)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d88a1-148">For more information, see [Asynchronous patterns in UWP using JavaScript](https://msdn.microsoft.com/windows/uwp/threading-async/asynchronous-programming-universal-windows-platform-apps#asynchronous-patterns-in-uwp-using-javascript).</span></span>

      [!code-javascript[<span data-ttu-id="d88a1-149">TrialVersion</span><span class="sxs-lookup"><span data-stu-id="d88a1-149">TrialVersion</span></span>](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet3)]

  * <span data-ttu-id="d88a1-150">Microsoft 以外の広告サーバーに広告スケジュールを要求するには、[requestScheduleByUrl](https://msdn.microsoft.com/library/windows/apps/mt732210.aspx) を使用し、サーバー URL を指定します。</span><span class="sxs-lookup"><span data-stu-id="d88a1-150">To request an ad schedule from a non-Microsoft ad server, use [requestScheduleByUrl](https://msdn.microsoft.com/library/windows/apps/mt732210.aspx), and pass in the server URL.</span></span> <span data-ttu-id="d88a1-151">このメソッドも **Promise** の形式を取ります。</span><span class="sxs-lookup"><span data-stu-id="d88a1-151">This method also takes the form of a **Promise**.</span></span>

      [!code-javascript[<span data-ttu-id="d88a1-152">TrialVersion</span><span class="sxs-lookup"><span data-stu-id="d88a1-152">TrialVersion</span></span>](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet4)]

    <span/>
    ><span data-ttu-id="d88a1-153">**注**&nbsp;&nbsp;関数が失敗した場合でも、**play** を呼び出す必要があります。[AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) によって **MediaPlayer** が広告をスキップし、直接コンテンツを再生するためです。</span><span class="sxs-lookup"><span data-stu-id="d88a1-153">**Note**&nbsp;&nbsp;You must call **play** even if the function fails, because the [AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) will tell the **MediaPlayer** to skip the ad(s) and move straight to the content.</span></span> <span data-ttu-id="d88a1-154">ビジネス要件によっては、広告がリモートで正常に取得できない場合に、ビルトイン広告を挿入するなどの処理を行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="d88a1-154">You may have a different business requirement, such as inserting a built-in ad if an ad can't be successfully fetched remotely.</span></span>

8.  <span data-ttu-id="d88a1-155">再生中に、アプリが進行状況や、最初の広告マッチング プロセス後に発生したエラーを追跡するための追加のイベントを処理できます。</span><span class="sxs-lookup"><span data-stu-id="d88a1-155">During playback, you can handle additional events that let your app track progress and/or errors which may occur after the initial ad matching process.</span></span> <span data-ttu-id="d88a1-156">次のコードでは、これらのイベントのいくつか ([onPodStart](https://msdn.microsoft.com/library/windows/apps/mt732206.aspx)、[onPodEnd](https://msdn.microsoft.com/library/windows/apps/mt732205.aspx)、[onPodCountdown](https://msdn.microsoft.com/library/windows/apps/mt732204.aspx)、[onAdProgress](https://msdn.microsoft.com/library/windows/apps/mt732201.aspx)、[onAllComplete](https://msdn.microsoft.com/library/windows/apps/mt732202.aspx)、および [onErrorOccurred](https://msdn.microsoft.com/library/windows/apps/mt732203.aspx)) を示します。</span><span class="sxs-lookup"><span data-stu-id="d88a1-156">The following code shows some of these events, including [onPodStart](https://msdn.microsoft.com/library/windows/apps/mt732206.aspx), [onPodEnd](https://msdn.microsoft.com/library/windows/apps/mt732205.aspx), [onPodCountdown](https://msdn.microsoft.com/library/windows/apps/mt732204.aspx), [onAdProgress](https://msdn.microsoft.com/library/windows/apps/mt732201.aspx), [onAllComplete](https://msdn.microsoft.com/library/windows/apps/mt732202.aspx), and [onErrorOccurred](https://msdn.microsoft.com/library/windows/apps/mt732203.aspx).</span></span>

  [!code-javascript[<span data-ttu-id="d88a1-157">TrialVersion</span><span class="sxs-lookup"><span data-stu-id="d88a1-157">TrialVersion</span></span>](./code/AdvertisingSamples/AdSchedulerSamples/js/js/main.js#Snippet5)]
