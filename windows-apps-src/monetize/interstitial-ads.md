---
author: Xansky
ms.assetid: 1f970d38-2338-470e-b5ba-811402752fc4
description: Microsoft Advertising SDK を使用して Windows 10 用 UWP アプリにスポット広告を組み込む方法について説明します。
title: スポット広告
ms.author: mhopkins
ms.date: 03/22/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 広告, 宣伝, 広告コントロール, スポット
ms.localizationpriority: medium
ms.openlocfilehash: 547a582064262d18467df4868df17a08e73b279c
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/23/2018
ms.locfileid: "5436850"
---
# <a name="interstitial-ads"></a><span data-ttu-id="df507-104">スポット広告</span><span class="sxs-lookup"><span data-stu-id="df507-104">Interstitial ads</span></span>

<span data-ttu-id="df507-105">このチュートリアルでは、Windows 10 用のユニバーサル Windows プラットフォーム (UWP) アプリとゲームにスポット広告を組み込む方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="df507-105">This walkthrough shows how to include interstitial ads in Universal Windows Platform (UWP) apps and games for Windows 10.</span></span> <span data-ttu-id="df507-106">C# と C++ を使って JavaScript/HTML アプリと XAML アプリにスポット広告を追加する方法を示す完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="df507-106">For complete sample projects that demonstrate how to add interstitial ads to JavaScript/HTML apps and XAML apps using C# and C++, see the [advertising samples on GitHub](http://aka.ms/githubads).</span></span>

<span id="whatareinterstitialads10"/>

## <a name="what-are-interstitial-ads"></a><span data-ttu-id="df507-107">スポット広告とは</span><span class="sxs-lookup"><span data-stu-id="df507-107">What are interstitial ads?</span></span>

<span data-ttu-id="df507-108">アプリやゲームの UI の一部分に表示が限定される標準のバナー広告とは異なり、スポット広告は画面全体に表示されます。</span><span class="sxs-lookup"><span data-stu-id="df507-108">Unlike standard banner ads, which are confined to a portion of a UI in an app or game, interstitial ads are shown on the entire screen.</span></span> <span data-ttu-id="df507-109">通常、ゲームでは、2 つの基本的な形式が使用されます。</span><span class="sxs-lookup"><span data-stu-id="df507-109">Two basic forms are frequently used in games.</span></span>

* <span data-ttu-id="df507-110">*ペイウォール*広告の場合、ユーザーは一定の間隔で広告を視聴する必要があります。</span><span class="sxs-lookup"><span data-stu-id="df507-110">With *Paywall* ads, the user must watch an ad at some regular interval.</span></span> <span data-ttu-id="df507-111">たとえば、ゲームのレベル間に表示される広告が該当します。</span><span class="sxs-lookup"><span data-stu-id="df507-111">For example between game levels:</span></span>

    ![whatisaninterstitial](images/13-ed0a333b-0fc8-4ca9-a4c8-11e8b4392831.png)

* <span data-ttu-id="df507-113">*報酬ベース*の広告の場合、ユーザーは明示的に特定のメリット (レベルを完了するためのヒントや追加の時間など) を求めていて、アプリのユーザー インターフェイスから広告を初期化します。</span><span class="sxs-lookup"><span data-stu-id="df507-113">With *Rewards Based* ads the user is explicitly seeking some benefit, such as a hint or extra time to complete the level, and initializes the ad through the app’s user interface.</span></span>

<span data-ttu-id="df507-114">アプリやゲームで使用するために、次の 2 種類のスポット広告が用意されています。**ビデオ スポット広告**と**バナー スポット広告**です。</span><span class="sxs-lookup"><span data-stu-id="df507-114">We provide two types of interstitial ads to use in your apps and games: **interstitial video ads** and **interstitial banner ads**.</span></span>

> [!NOTE]
> <span data-ttu-id="df507-115">スポット広告用の API は、ビデオの再生時を除き、どのようなユーザー インターフェイスも処理しません。</span><span class="sxs-lookup"><span data-stu-id="df507-115">The API for interstitial ads does not handle any user interface except at the time of video playback.</span></span> <span data-ttu-id="df507-116">スポット広告をアプリに統合する方法を検討するときは、何をすべきであり何をすべきでないかに関するガイドラインとして、[スポットのベスト プラクティス](ui-and-user-experience-guidelines.md#interstitialbestpractices10)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="df507-116">Refer to the [interstitial best practices](ui-and-user-experience-guidelines.md#interstitialbestpractices10) for guidelines on what to do, and avoid, as you consider how to integrate interstitial ads in your app.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="df507-117">前提条件</span><span class="sxs-lookup"><span data-stu-id="df507-117">Prerequisites</span></span>

* <span data-ttu-id="df507-118">Visual Studio 2015 以降の Visual Studio のリリースと共に [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="df507-118">Install the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) with Visual Studio 2015 or a later release of Visual Studio.</span></span> <span data-ttu-id="df507-119">インストール手順については、[この記事](install-the-microsoft-advertising-libraries.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="df507-119">For installation instructions, see [this article](install-the-microsoft-advertising-libraries.md).</span></span>

## <a name="integrate-an-interstitial-ad-into-your-app"></a><span data-ttu-id="df507-120">スポット広告をアプリに統合する</span><span class="sxs-lookup"><span data-stu-id="df507-120">Integrate an interstitial ad into your app</span></span>

<span data-ttu-id="df507-121">アプリでスポット広告を表示するには、次のプロジェクトの種類の指示に従います。</span><span class="sxs-lookup"><span data-stu-id="df507-121">To show interstitial ads in your app, follow the instructions for project type:</span></span>

* [<span data-ttu-id="df507-122">XAML/.NET</span><span class="sxs-lookup"><span data-stu-id="df507-122">XAML/.NET</span></span>](#interstitialadsxaml10)
* [<span data-ttu-id="df507-123">HTML/JavaScript</span><span class="sxs-lookup"><span data-stu-id="df507-123">HTML/JavaScript</span></span>](#interstitialadshtml10)
* [<span data-ttu-id="df507-124">C++ (DirectX Interop)</span><span class="sxs-lookup"><span data-stu-id="df507-124">C++ (DirectX Interop)</span></span>](#interstitialadsdirectx10)

<span id="interstitialadsxaml10"/>

### <a name="xamlnet"></a><span data-ttu-id="df507-125">XAML/.NET</span><span class="sxs-lookup"><span data-stu-id="df507-125">XAML/.NET</span></span>

<span data-ttu-id="df507-126">ここでは C# の例を紹介していますが、XAML/.NET プロジェクトでは Visual Basic と C++ もサポートされています。</span><span class="sxs-lookup"><span data-stu-id="df507-126">This section provides C# examples, but Visual Basic and C++ are also supported for XAML/.NET projects.</span></span> <span data-ttu-id="df507-127">完全な C# コードの例については、「[C# を使ったスポット広告のサンプル コード](interstitial-ad-sample-code-in-c.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="df507-127">For a complete C# code example, see [Interstitial ad sample code in C#](interstitial-ad-sample-code-in-c.md).</span></span>

1. <span data-ttu-id="df507-128">Visual Studio でプロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="df507-128">Open your project in Visual Studio.</span></span>
    > [!NOTE]
    > <span data-ttu-id="df507-129">既存のプロジェクトを使用している場合、プロジェクトの Package.appxmanifest ファイルを開き、**インターネット (クライアント)** 機能が選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="df507-129">If you're using an existing project, open the Package.appxmanifest file in your project and ensure that the **Internet (Client)** capability is selected.</span></span> <span data-ttu-id="df507-130">アプリでは、テスト広告やライブ広告を受信するためにこの機能が必要になります。</span><span class="sxs-lookup"><span data-stu-id="df507-130">Your app needs this capability to receive test ads and live ads.</span></span>

2. <span data-ttu-id="df507-131">プロジェクトのターゲットが **[任意の CPU]** になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。</span><span class="sxs-lookup"><span data-stu-id="df507-131">If your project targets **Any CPU**, update your project to use an architecture-specific build output (for example, **x86**).</span></span> <span data-ttu-id="df507-132">プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising ライブラリへの参照を正常に追加できません。</span><span class="sxs-lookup"><span data-stu-id="df507-132">If your project targets **Any CPU**, you will not be able to successfully add a reference to the Microsoft advertising library in the following steps.</span></span> <span data-ttu-id="df507-133">詳しくは、「[プロジェクトのターゲットを "任意の CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="df507-133">For more information, see [Reference errors caused by targeting Any CPU in your project](known-issues-for-the-advertising-libraries.md#reference_errors).</span></span>

3. <span data-ttu-id="df507-134">プロジェクトで Microsoft Advertising SDK への参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="df507-134">Add a reference to the Microsoft Advertising SDK in your project:</span></span>

    1. <span data-ttu-id="df507-135">**[ソリューション エクスプローラー]** ウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="df507-135">From the **Solution Explorer** window, right click **References**, and select **Add Reference…**</span></span>
    2.  <span data-ttu-id="df507-136">**[参照マネージャー]** で、**[Universal Windows]** を展開し、**[拡張]** をクリックして、**[Microsoft Advertising SDK for XAML]** (バージョン 10.0) の横にあるチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="df507-136">In **Reference Manager**, expand **Universal Windows**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for XAML** (Version 10.0).</span></span>
    3.  <span data-ttu-id="df507-137">**[参照マネージャー]** で、[OK] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="df507-137">In **Reference Manager**, click OK.</span></span>

3.  <span data-ttu-id="df507-138">アプリの適切なコード ファイル (たとえば、MainPage.xaml.cs またはその他のページのコード ファイル) に、次の名前空間の参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="df507-138">In the appropriate code file in your app (for example, in MainPage.xaml.cs or a code file for some other page), add the following namespace reference.</span></span>

    [!code-cs[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#Snippet1)]

4.  <span data-ttu-id="df507-139">アプリの適切な場所 (たとえば、```MainPage``` またはその他のページ) で、[InterstitialAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad) オブジェクトと、スポット広告のアプリケーション ID および広告ユニット ID を表す複数の文字列フィールドを宣言します。</span><span class="sxs-lookup"><span data-stu-id="df507-139">In an appropriate location in your app (for example, in ```MainPage``` or some other page), declare an [InterstitialAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad) object and several string fields that represent the application ID and ad unit ID for your interstitial ad.</span></span> <span data-ttu-id="df507-140">次のコード例では、`myAppId` フィールドと `myAdUnitId` フィールドをスポット広告の[テスト値](set-up-ad-units-in-your-app.md#test-ad-units)に割り当てています。</span><span class="sxs-lookup"><span data-stu-id="df507-140">The following code example assigns the `myAppId` and `myAdUnitId` fields to the [test values](set-up-ad-units-in-your-app.md#test-ad-units) for interstitial ads.</span></span>

    > [!NOTE]
    > <span data-ttu-id="df507-141">各 **InterstitialAd** に、対応する*広告ユニット*があります。広告ユニットは、コントロールに広告を提供するためにサービスで使用されます。すべての広告ユニットは、*広告ユニット ID* と*アプリケーション ID* で構成されます。</span><span class="sxs-lookup"><span data-stu-id="df507-141">Every **InterstitialAd** has a corresponding *ad unit* that is used by our services to serve ads to the control, and every ad unit consists of an *ad unit ID* and *application ID*.</span></span> <span data-ttu-id="df507-142">ここでは、広告ユニット ID とアプリケーション ID のテスト値をコントロールに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="df507-142">In these steps, you assign test ad unit ID and application ID values to your control.</span></span> <span data-ttu-id="df507-143">これらのテスト値は、テスト バージョンのアプリでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="df507-143">These test values can only be used in a test version of your app.</span></span> <span data-ttu-id="df507-144">ストアにアプリを公開する前に、[これらのテスト値を Windows デベロッパー センターから取得した実際の値に置き換える](#release) 必要があります。</span><span class="sxs-lookup"><span data-stu-id="df507-144">Before you publish your app to the Store, you must [replace these test values with live values](#release) from Windows Dev Center.</span></span>

    [!code-cs[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#Snippet2)]

5.  <span data-ttu-id="df507-145">起動時に実行されるコード (たとえば、ページのコンストラクター) 内で、**InterstitialAd** オブジェクトをインスタンス化し、このオブジェクトのイベント用のイベント ハンドラーを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="df507-145">In code that runs on startup (for example, in the constructor for the page), instantiate the **InterstitialAd** object and wire up event handlers for events of the object.</span></span>

    [!code-cs[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#Snippet3)]

6.  <span data-ttu-id="df507-146">*ビデオ スポット*広告を表示する場合: 広告が必要になる約 30 ～ 60 秒前に、[RequestAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.requestad) メソッドを使用して事前に広告を取得しておきます。</span><span class="sxs-lookup"><span data-stu-id="df507-146">If you want to show an *interstitial video* ad: Approximately 30-60 seconds before you need the ad, use the [RequestAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.requestad) method to pre-fetch the ad.</span></span> <span data-ttu-id="df507-147">これにより、広告を表示する前に、その広告を要求して準備するための十分な時間が与えられます。</span><span class="sxs-lookup"><span data-stu-id="df507-147">This allows enough time to request and prepare the ad before it should be shown.</span></span> <span data-ttu-id="df507-148">広告の種類として、必ず **AdType.Video** を指定してください。</span><span class="sxs-lookup"><span data-stu-id="df507-148">Be sure to specify **AdType.Video** for the ad type.</span></span>

    [!code-cs[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#Snippet4)]

    <span data-ttu-id="df507-149">*バナー スポット*広告を表示する場合: 広告が必要になる約 5 ～ 8 秒前に、[RequestAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.requestad) メソッドを使用して事前に広告を取得しておきます。</span><span class="sxs-lookup"><span data-stu-id="df507-149">If you want to show an *interstitial banner* ad: Approximately 5-8 seconds before you need the ad, use the [RequestAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.requestad) method to pre-fetch the ad.</span></span> <span data-ttu-id="df507-150">これにより、広告を表示する前に、その広告を要求して準備するための十分な時間が与えられます。</span><span class="sxs-lookup"><span data-stu-id="df507-150">This allows enough time to request and prepare the ad before it should be shown.</span></span> <span data-ttu-id="df507-151">広告の種類として、必ず **AdType.Display** を指定してください。</span><span class="sxs-lookup"><span data-stu-id="df507-151">Be sure to specify **AdType.Display** for the ad type.</span></span>

    ```csharp
    myInterstitialAd.RequestAd(AdType.Display, myAppId, myAdUnitId);
    ```

6.  <span data-ttu-id="df507-152">ビデオ スポット広告やバナー スポット広告を表示するコード内のポイントで、**InterstitialAd** を表示する準備ができていることを確認してから、[Show](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.show) メソッドを使用して広告を表示します。</span><span class="sxs-lookup"><span data-stu-id="df507-152">At the point in your code where you want to show the interstitial video or interstitial banner ad, confirm that the **InterstitialAd** is ready to be shown and then show it by using the [Show](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.show) method.</span></span>

    [!code-cs[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#Snippet5)]

7.  <span data-ttu-id="df507-153">**InterstitialAd** オブジェクトのイベント ハンドラーを定義します。</span><span class="sxs-lookup"><span data-stu-id="df507-153">Define the event handlers for the **InterstitialAd** object.</span></span>

    [!code-cs[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#Snippet6)]

8.  <span data-ttu-id="df507-154">アプリをビルドした後テストして、テスト広告が表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="df507-154">Build and test your app to confirm it is showing test ads.</span></span>

<span id="interstitialadshtml10"/>

### <a name="htmljavascript"></a><span data-ttu-id="df507-155">HTML/JavaScript</span><span class="sxs-lookup"><span data-stu-id="df507-155">HTML/JavaScript</span></span>

<span data-ttu-id="df507-156">次の手順では、Visual Studio で JavaScript 用のユニバーサル Windows プロジェクトを作成済みであり、特定の CPU をターゲットとしているものと想定しています。</span><span class="sxs-lookup"><span data-stu-id="df507-156">The following instructions assume you have created a Universal Windows project for JavaScript in Visual Studio and are targeting a specific CPU.</span></span> <span data-ttu-id="df507-157">完全なコード サンプルについては、「[JavaScript を使ったスポット広告のサンプル コード](interstitial-ad-sample-code-in-javascript.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="df507-157">For a complete code sample, see [Interstitial ad sample code in JavaScript](interstitial-ad-sample-code-in-javascript.md).</span></span>

1. <span data-ttu-id="df507-158">Visual Studio でプロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="df507-158">Open your project in Visual Studio.</span></span>

2. <span data-ttu-id="df507-159">プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。</span><span class="sxs-lookup"><span data-stu-id="df507-159">If your project targets **Any CPU**, update your project to use an architecture-specific build output (for example, **x86**).</span></span> <span data-ttu-id="df507-160">プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising ライブラリへの参照を正常に追加できません。</span><span class="sxs-lookup"><span data-stu-id="df507-160">If your project targets **Any CPU**, you will not be able to successfully add a reference to the Microsoft advertising library in the following steps.</span></span> <span data-ttu-id="df507-161">詳しくは、「[プロジェクトのターゲットを "任意の CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="df507-161">For more information, see [Reference errors caused by targeting Any CPU in your project](known-issues-for-the-advertising-libraries.md#reference_errors).</span></span>

3. <span data-ttu-id="df507-162">プロジェクトで Microsoft Advertising SDK への参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="df507-162">Add a reference to the Microsoft Advertising SDK in your project:</span></span>

    1. <span data-ttu-id="df507-163">**[ソリューション エクスプローラー]** ウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="df507-163">From the **Solution Explorer** window, right click **References**, and select **Add Reference…**</span></span>
    2.  <span data-ttu-id="df507-164">**[参照マネージャー]** で、**[ユニバーサル Windows]** を展開し、**[拡張]** をクリックして、**[Microsoft Advertising SDK for JavaScript]** (バージョン 10.0) の横にあるチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="df507-164">In **Reference Manager**, expand **Universal Windows**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for JavaScript** (Version 10.0).</span></span>
    3.  <span data-ttu-id="df507-165">**[参照マネージャー]** で、[OK] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="df507-165">In **Reference Manager**, click OK.</span></span>

3.  <span data-ttu-id="df507-166">プロジェクト内の HTML ファイルの **&lt;head&gt;** セクションで、プロジェクトの default.css と default.js の JavaScript 参照の後に ad.js への参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="df507-166">In the **&lt;head&gt;** section of the HTML file in the project, after the project’s JavaScript references of default.css and default.js, add the reference to ad.js.</span></span>

    ``` HTML
    <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
    ```

4.  <span data-ttu-id="df507-167">プロジェクト内の .js ファイルで、[InterstitialAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad) オブジェクトと、スポット広告のアプリケーション ID および広告ユニット ID を含む複数のフィールドを宣言します。</span><span class="sxs-lookup"><span data-stu-id="df507-167">In a .js file in your project, declare an [InterstitialAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad) object and several fields that contain the application ID and ad unit ID for your interstitial ad.</span></span> <span data-ttu-id="df507-168">次のコード例では、`applicationId` フィールドと `adUnitId` フィールドをスポット広告の[テスト値](set-up-ad-units-in-your-app.md#test-ad-units)に割り当てています。</span><span class="sxs-lookup"><span data-stu-id="df507-168">The following code example assigns the `applicationId` and `adUnitId` fields to the [test values](set-up-ad-units-in-your-app.md#test-ad-units) for interstitial ads.</span></span>

    > [!NOTE]
    > <span data-ttu-id="df507-169">各 **InterstitialAd** に、対応する*広告ユニット*があります。広告ユニットは、コントロールに広告を提供するためにサービスで使用されます。すべての広告ユニットは、*広告ユニット ID* と*アプリケーション ID* で構成されます。</span><span class="sxs-lookup"><span data-stu-id="df507-169">Every **InterstitialAd** has a corresponding *ad unit* that is used by our services to serve ads to the control, and every ad unit consists of an *ad unit ID* and *application ID*.</span></span> <span data-ttu-id="df507-170">ここでは、広告ユニット ID とアプリケーション ID のテスト値をコントロールに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="df507-170">In these steps, you assign test ad unit ID and application ID values to your control.</span></span> <span data-ttu-id="df507-171">これらのテスト値は、テスト バージョンのアプリでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="df507-171">These test values can only be used in a test version of your app.</span></span> <span data-ttu-id="df507-172">Microsoft Store にアプリを公開する前に、[これらのテスト値を Windows デベロッパー センターから取得した実際の値に置き換える](#release)必要があります。</span><span class="sxs-lookup"><span data-stu-id="df507-172">Before you publish your app to the Store, you must [replace these test values with live values](#release) from Windows Dev Center.</span></span>

    [!code-javascript[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/js/script.js#Snippet1)]

5.  <span data-ttu-id="df507-173">起動時に実行されるコード (たとえば、ページのコンストラクター) 内で、**InterstitialAd** オブジェクトをインスタンス化し、このオブジェクトのイベント ハンドラーを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="df507-173">In code that runs on startup (for example, in the constructor for the page), instantiate the **InterstitialAd** object and wire up event handlers for the object.</span></span>

    [!code-javascript[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/js/script.js#Snippet2)]

5. <span data-ttu-id="df507-174">*ビデオ スポット*広告を表示する場合: 広告が必要になる約 30 ～ 60 秒前に、[RequestAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.requestad) メソッドを使用して事前に広告を取得しておきます。</span><span class="sxs-lookup"><span data-stu-id="df507-174">If you want to show an *interstitial video* ad: Approximately 30-60 seconds before you need the ad, use the [RequestAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.requestad) method to pre-fetch the ad.</span></span> <span data-ttu-id="df507-175">これにより、広告を表示する前に、その広告を要求して準備するための十分な時間が与えられます。</span><span class="sxs-lookup"><span data-stu-id="df507-175">This allows enough time to request and prepare the ad before it should be shown.</span></span> <span data-ttu-id="df507-176">広告の種類として、必ず **InterstitialAdType.video** を指定してください。</span><span class="sxs-lookup"><span data-stu-id="df507-176">Be sure to specify **InterstitialAdType.video** for the ad type.</span></span>

    [!code-javascript[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/js/script.js#Snippet3)]

    <span data-ttu-id="df507-177">*バナー スポット*広告を表示する場合: 広告が必要になる約 5 ～ 8 秒前に、[RequestAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.requestad) メソッドを使用して事前に広告を取得しておきます。</span><span class="sxs-lookup"><span data-stu-id="df507-177">If you want to show an *interstitial banner* ad: Approximately 5-8 seconds before you need the ad, use the [RequestAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.requestad) method to pre-fetch the ad.</span></span> <span data-ttu-id="df507-178">これにより、広告を表示する前に、その広告を要求して準備するための十分な時間が与えられます。</span><span class="sxs-lookup"><span data-stu-id="df507-178">This allows enough time to request and prepare the ad before it should be shown.</span></span> <span data-ttu-id="df507-179">広告の種類として、必ず **InterstitialAdType.display** を指定してください。</span><span class="sxs-lookup"><span data-stu-id="df507-179">Be sure to specify **InterstitialAdType.display** for the ad type.</span></span>

    ```js
    if (interstitialAd) {
        interstitialAd.requestAd(MicrosoftNSJS.Advertising.InterstitialAdType.display, applicationId, adUnitId);
    }
    ```

6.  <span data-ttu-id="df507-180">広告を表示するコード内のポイントで、**InterstitialAd** を表示する準備ができていることを確認してから、[Show](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.show) メソッドを使用して広告を表示します。</span><span class="sxs-lookup"><span data-stu-id="df507-180">At the point in your code where you want to show the ad, confirm that the **InterstitialAd** is ready to be shown and then show it by using the [Show](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.show) method.</span></span>

    [!code-javascript[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/js/samples.js#Snippet4)]

7.  <span data-ttu-id="df507-181">**InterstitialAd** オブジェクトのイベント ハンドラーを定義します。</span><span class="sxs-lookup"><span data-stu-id="df507-181">Define the event handlers for the **InterstitialAd** object.</span></span>

    [!code-javascript[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/js/samples.js#Snippet5)]

9.  <span data-ttu-id="df507-182">アプリをビルドした後テストして、テスト広告が表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="df507-182">Build and test your app to confirm it is showing test ads.</span></span>

<span id="interstitialadsdirectx10"/>

### <a name="c-directx-interop"></a><span data-ttu-id="df507-183">C++ (DirectX Interop)</span><span class="sxs-lookup"><span data-stu-id="df507-183">C++ (DirectX Interop)</span></span>

<span data-ttu-id="df507-184">このサンプルでは、Visual Studio で C++ **DirectX および XAML アプリ (ユニバーサル Windows)** プロジェクトを作成済みであり、特定の CPU アーキテクチャをターゲットとしているものと想定しています。</span><span class="sxs-lookup"><span data-stu-id="df507-184">This sample assumes you have created a C++ **DirectX and XAML App (Universal Windows)** project in Visual Studio and are targeting a specific CPU architecture.</span></span>
 
1. <span data-ttu-id="df507-185">Visual Studio でプロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="df507-185">Open your project in Visual Studio.</span></span>

3. <span data-ttu-id="df507-186">プロジェクトで Microsoft Advertising SDK への参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="df507-186">Add a reference to the Microsoft Advertising SDK in your project:</span></span>

    1. <span data-ttu-id="df507-187">**[ソリューション エクスプローラー]** ウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="df507-187">From the **Solution Explorer** window, right click **References**, and select **Add Reference…**</span></span>
    2.  <span data-ttu-id="df507-188">**[参照マネージャー]** で、**[Universal Windows]** を展開し、**[拡張]** をクリックして、**[Microsoft Advertising SDK for XAML]** (バージョン 10.0) の横にあるチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="df507-188">In **Reference Manager**, expand **Universal Windows**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for XAML** (Version 10.0).</span></span>
    3.  <span data-ttu-id="df507-189">**[参照マネージャー]** で、[OK] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="df507-189">In **Reference Manager**, click OK.</span></span>

2.  <span data-ttu-id="df507-190">アプリの適切なヘッダー ファイル (例: DirectXPage.xaml.h) 内で、[InterstitialAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad) オブジェクトおよび関連するイベント ハンドラー メソッドを宣言します。</span><span class="sxs-lookup"><span data-stu-id="df507-190">In an appropriate header file for your app (for example, DirectXPage.xaml.h), declare an [InterstitialAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad) object and related event handler methods.</span></span>  

    [!code-cpp[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.h#Snippet1)]

3.  <span data-ttu-id="df507-191">同じヘッダー ファイル内で、スポット広告のアプリケーション ID と広告ユニット ID を表す複数の文字列フィールドを宣言します。</span><span class="sxs-lookup"><span data-stu-id="df507-191">In the same header file, declare several string fields that represent the application ID and ad unit ID for your interstitial ad.</span></span> <span data-ttu-id="df507-192">次のコード例では、`myAppId` フィールドと `myAdUnitId` フィールドをスポット広告の[テスト値](set-up-ad-units-in-your-app.md#test-ad-units)に割り当てています。</span><span class="sxs-lookup"><span data-stu-id="df507-192">The following code example assigns the `myAppId` and `myAdUnitId` fields to the [test values](set-up-ad-units-in-your-app.md#test-ad-units) for interstitial ads.</span></span>

    > [!NOTE]
    > <span data-ttu-id="df507-193">各 **InterstitialAd** に、対応する*広告ユニット*があります。広告ユニットは、コントロールに広告を提供するためにサービスで使用されます。すべての広告ユニットは、*広告ユニット ID* と*アプリケーション ID* で構成されます。</span><span class="sxs-lookup"><span data-stu-id="df507-193">Every **InterstitialAd** has a corresponding *ad unit* that is used by our services to serve ads to the control, and every ad unit consists of an *ad unit ID* and *application ID*.</span></span> <span data-ttu-id="df507-194">ここでは、広告ユニット ID とアプリケーション ID のテスト値をコントロールに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="df507-194">In these steps, you assign test ad unit ID and application ID values to your control.</span></span> <span data-ttu-id="df507-195">これらのテスト値は、テスト バージョンのアプリでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="df507-195">These test values can only be used in a test version of your app.</span></span> <span data-ttu-id="df507-196">Microsoft Store にアプリを公開する前に、[これらのテスト値を Windows デベロッパー センターから取得した実際の値に置き換える](#release)必要があります。</span><span class="sxs-lookup"><span data-stu-id="df507-196">Before you publish your app to the Store, you must [replace these test values with live values](#release) from Windows Dev Center.</span></span>

    [!code-cpp[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.h#Snippet2)]

4.  <span data-ttu-id="df507-197">スポット広告を表示するためのコードを追加する .cpp ファイルに、次の名前空間の参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="df507-197">In the .cpp file where you want to add code to show an interstitial ad, add the following namespace reference.</span></span> <span data-ttu-id="df507-198">次の例では、アプリの DirectXPage.xaml.cpp ファイルにそのコードを追加しているものと想定しています。</span><span class="sxs-lookup"><span data-stu-id="df507-198">The following examples assume you are adding the code to DirectXPage.xaml.cpp file in your app.</span></span>

    [!code-cpp[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.cpp#Snippet3)]

6.  <span data-ttu-id="df507-199">起動時に実行されるコード (たとえば、ページのコンストラクター) 内で、**InterstitialAd** オブジェクトをインスタンス化し、このオブジェクトのイベント用のイベント ハンドラーを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="df507-199">In code that runs on startup (for example, in the constructor for the page), instantiate the **InterstitialAd** object and wire up event handlers for events of the object.</span></span> <span data-ttu-id="df507-200">次の例では、```InterstitialAdSamplesCpp``` がプロジェクトの名前空間です。コードでは、必要に応じてこの名前を変更します。</span><span class="sxs-lookup"><span data-stu-id="df507-200">In the following example, ```InterstitialAdSamplesCpp``` is the namespace for your project; change this name as necessary for your code.</span></span>

    [!code-cpp[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.cpp#Snippet4)]

7. <span data-ttu-id="df507-201">*ビデオ スポット*広告を表示する場合: スポット広告が必要になる約 30 ～ 60 秒前に、[RequestAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.requestad) メソッドを使用して事前に広告を取得しておきます。</span><span class="sxs-lookup"><span data-stu-id="df507-201">If you want to show an *interstitial video* ad: Approximately 30-60 seconds before you need the interstitial ad, use the [RequestAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.requestad) method to pre-fetch the ad.</span></span> <span data-ttu-id="df507-202">これにより、広告を表示する前に、その広告を要求して準備するための十分な時間が与えられます。</span><span class="sxs-lookup"><span data-stu-id="df507-202">This allows enough time to request and prepare the ad before it should be shown.</span></span> <span data-ttu-id="df507-203">広告の種類として、必ず **AdType::Video** を指定してください。</span><span class="sxs-lookup"><span data-stu-id="df507-203">Be sure to specify **AdType::Video** for the ad type.</span></span>

    [!code-cpp[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.cpp#Snippet5)]

    <span data-ttu-id="df507-204">*バナー スポット*広告を表示する場合: 広告が必要になる約 5 ～ 8 秒前に、[RequestAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.requestad) メソッドを使用して事前に広告を取得しておきます。</span><span class="sxs-lookup"><span data-stu-id="df507-204">If you want to show an *interstitial banner* ad: Approximately 5-8 seconds before you need the ad, use the [RequestAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.requestad) method to pre-fetch the ad.</span></span> <span data-ttu-id="df507-205">これにより、広告を表示する前に、その広告を要求して準備するための十分な時間が与えられます。</span><span class="sxs-lookup"><span data-stu-id="df507-205">This allows enough time to request and prepare the ad before it should be shown.</span></span> <span data-ttu-id="df507-206">広告の種類として、必ず **AdType::Display** を指定してください。</span><span class="sxs-lookup"><span data-stu-id="df507-206">Be sure to specify **AdType::Display** for the ad type.</span></span>

    ```cpp
    m_interstitialAd->RequestAd(AdType::Display, myAppId, myAdUnitId);
    ```

7.  <span data-ttu-id="df507-207">広告を表示するコード内のポイントで、**InterstitialAd** を表示する準備ができていることを確認してから、[Show](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.show) メソッドを使用して広告を表示します。</span><span class="sxs-lookup"><span data-stu-id="df507-207">At the point in your code where you want to show the ad, confirm that the **InterstitialAd** is ready to be shown and then show it by using the [Show](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.show) method.</span></span>

    [!code-cpp[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.cpp#Snippet6)]

8.  <span data-ttu-id="df507-208">**InterstitialAd** オブジェクトのイベント ハンドラーを定義します。</span><span class="sxs-lookup"><span data-stu-id="df507-208">Define the event handlers for the **InterstitialAd** object.</span></span>

    [!code-cpp[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.cpp#Snippet7)]

9. <span data-ttu-id="df507-209">アプリをビルドした後テストして、テスト広告が表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="df507-209">Build and test your app to confirm it is showing test ads.</span></span>

<span id="release" />

## <a name="release-your-app-with-live-ads"></a><span data-ttu-id="df507-210">ライブ広告を表示するアプリをリリースする</span><span class="sxs-lookup"><span data-stu-id="df507-210">Release your app with live ads</span></span>

1. <span data-ttu-id="df507-211">アプリでのスポット広告の使用方法が[スポット広告のガイドライン](ui-and-user-experience-guidelines.md#interstitialbestpractices10)に従っていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="df507-211">Make sure your use of interstitial ads in your app follows our [guidelines for interstitial ads](ui-and-user-experience-guidelines.md#interstitialbestpractices10).</span></span>

2.  <span data-ttu-id="df507-212">デベロッパー センター ダッシュボードで、[[アプリ内広告]](../publish/in-app-ads.md) ページに移動し、[広告ユニットを作成](set-up-ad-units-in-your-app.md#live-ad-units)します。</span><span class="sxs-lookup"><span data-stu-id="df507-212">In the Dev Center dashboard, go to the [In-app ads](../publish/in-app-ads.md) page and [create an ad unit](set-up-ad-units-in-your-app.md#live-ad-units).</span></span> <span data-ttu-id="df507-213">表示するスポット広告の種類に応じて、広告ユニットの種類として、**[ビデオ (スポット)]** または **[バナー (スポット)]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="df507-213">For the ad unit type, choose **Video interstitial** or **Banner interstitial**, depending on what type of interstitial ad you are showing.</span></span> <span data-ttu-id="df507-214">広告ユニット ID とアプリケーション ID の両方を書き留めておきます。</span><span class="sxs-lookup"><span data-stu-id="df507-214">Make note of both the ad unit ID and the application ID.</span></span>
    > [!NOTE]
    > <span data-ttu-id="df507-215">テスト広告ユニットとライブ UWP 広告ユニットでは、アプリケーション ID の値の形式が異なります。</span><span class="sxs-lookup"><span data-stu-id="df507-215">The application ID values for test ad units and live UWP ad units have different formats.</span></span> <span data-ttu-id="df507-216">テスト アプリケーション ID の値は GUID です。</span><span class="sxs-lookup"><span data-stu-id="df507-216">Test application ID values are GUIDs.</span></span> <span data-ttu-id="df507-217">ダッシュボードでライブ UWP 広告ユニットを作成する場合、広告ユニットのアプリケーション ID の値は常にアプリの Store ID に一致します (Store ID 値は、たとえば 9NBLGGH4R315 のようになります)。</span><span class="sxs-lookup"><span data-stu-id="df507-217">When you create a live UWP ad unit in the dashboard, the application ID value for the ad unit always matches the Store ID for your app (an example Store ID value looks like 9NBLGGH4R315).</span></span>

3. <span data-ttu-id="df507-218">必要に応じて、[[アプリ内広告]](../publish/in-app-ads.md) ページの [[仲介設定]](../publish/in-app-ads.md#mediation) セクションで設定を構成することで、**InterstitialAd** の広告仲介を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="df507-218">You can optionally enable ad mediation for the **InterstitialAd** by configuring the settings in the [Mediation settings](../publish/in-app-ads.md#mediation) section on the [In-app ads](../publish/in-app-ads.md) page.</span></span> <span data-ttu-id="df507-219">広告仲介を使うと、複数の広告ネットワークから広告を表示して、広告収益とアプリ プロモーションの機能を最大限に引き出すことができます。表示される広告には、Taboola や Smaato などの他の有料広告ネットワークからの広告や、Microsoft のアプリ プロモーション キャンペーン用の広告などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="df507-219">Ad mediation enables you to maximize your ad revenue and app promotion capabilities by displaying ads from multiple ad networks, including ads from other paid ad networks such as Taboola and Smaato and ads for Microsoft app promotion campaigns.</span></span>

4.  <span data-ttu-id="df507-220">コードで、広告ユニットのテスト値を、デベロッパー センターで生成した実際の値に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="df507-220">In your code, replace the test ad unit values with the live values you generated in Dev Center.</span></span>

5.  <span data-ttu-id="df507-221">Windows デベロッパー センター ダッシュボードを使用して、ストアに[アプリを提出](../publish/app-submissions.md)します。</span><span class="sxs-lookup"><span data-stu-id="df507-221">[Submit your app](../publish/app-submissions.md) to the Store using the Windows Dev Center dashboard.</span></span>

6.  <span data-ttu-id="df507-222">デベロッパー センター ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認します。</span><span class="sxs-lookup"><span data-stu-id="df507-222">Review your [advertising performance reports](../publish/advertising-performance-report.md) in the Dev Center dashboard.</span></span>

<span id="manage" />

## <a name="manage-ad-units-for-multiple-interstitial-ad-controls-in-your-app"></a><span data-ttu-id="df507-223">アプリで複数のスポット広告コントロールの広告ユニットを管理します。</span><span class="sxs-lookup"><span data-stu-id="df507-223">Manage ad units for multiple interstitial ad controls in your app</span></span>

<span data-ttu-id="df507-224">1 つのアプリに複数の **InterstitialAd** コントロールを使用できます。</span><span class="sxs-lookup"><span data-stu-id="df507-224">You can use multiple **InterstitialAd** controls in a single app.</span></span> <span data-ttu-id="df507-225">このシナリオでは、各コントロールに異なる広告ユニットを割り当てることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="df507-225">In this scenario, we recommend that you assign a different ad unit to each control.</span></span> <span data-ttu-id="df507-226">各コントロールに異なる広告ユニットを使用することで、別々に[仲介の設定を構成](../publish/in-app-ads.md#mediation)して、個別の[報告データ](../publish/advertising-performance-report.md)を取得することが可能です。</span><span class="sxs-lookup"><span data-stu-id="df507-226">Using different ad units for each control enables you to separately [configure the mediation settings](../publish/in-app-ads.md#mediation) and get discrete [reporting data](../publish/advertising-performance-report.md) for each control.</span></span> <span data-ttu-id="df507-227">また、これにより、Microsoft のサービスはアプリに提供する広告を最適化できます。</span><span class="sxs-lookup"><span data-stu-id="df507-227">This also enables our services to better optimize the ads we serve to your app.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="df507-228">各広告ユニットは 1 つのアプリのみで使用できます。</span><span class="sxs-lookup"><span data-stu-id="df507-228">You can use each ad unit in only one app.</span></span> <span data-ttu-id="df507-229">複数のアプリで広告ユニットを使うと、広告ユニットに広告が提供されません。</span><span class="sxs-lookup"><span data-stu-id="df507-229">If you use an ad unit in more than one app, ads will not be served for that ad unit.</span></span>

## <a name="related-topics"></a><span data-ttu-id="df507-230">関連トピック</span><span class="sxs-lookup"><span data-stu-id="df507-230">Related topics</span></span>

* [<span data-ttu-id="df507-231">スポット広告のガイドライン</span><span class="sxs-lookup"><span data-stu-id="df507-231">Guidelines for interstitial ads</span></span>](ui-and-user-experience-guidelines.md#interstitialbestpractices10)
* [<span data-ttu-id="df507-232">C# を使ったスポット広告のサンプル コード</span><span class="sxs-lookup"><span data-stu-id="df507-232">Interstitial ad sample code in C#</span></span>](interstitial-ad-sample-code-in-c.md)
* [<span data-ttu-id="df507-233">JavaScript を使ったスポット広告のサンプル コード</span><span class="sxs-lookup"><span data-stu-id="df507-233">Interstitial ad sample code in JavaScript</span></span>](interstitial-ad-sample-code-in-javascript.md)
* [<span data-ttu-id="df507-234">GitHub の広告サンプル</span><span class="sxs-lookup"><span data-stu-id="df507-234">Advertising samples on GitHub</span></span>](http://aka.ms/githubads)
* [<span data-ttu-id="df507-235">アプリの広告ユニットをセットアップする</span><span class="sxs-lookup"><span data-stu-id="df507-235">Set up ad units for your app</span></span>](set-up-ad-units-in-your-app.md)
