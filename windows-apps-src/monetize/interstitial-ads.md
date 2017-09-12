---
author: mcleanbyron
ms.assetid: 1f970d38-2338-470e-b5ba-811402752fc4
description: "Microsoft Advertising ライブラリを使って Windows 10、Windows 8.1、または Windows Phone 8.1 アプリにスポット広告を組み込む方法について説明します。"
title: "スポット広告"
ms.author: mcleans
ms.date: 06/26/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, 宣伝, 広告コントロール, スポット"
ms.openlocfilehash: 16cb78d9419d54a1bd56fb855ca1fad6fedf665a
ms.sourcegitcommit: 8c4d50ef819ed1a2f8cac4eebefb5ccdaf3fa898
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/27/2017
---
# <a name="interstitial-ads"></a><span data-ttu-id="73a1d-104">スポット広告</span><span class="sxs-lookup"><span data-stu-id="73a1d-104">Interstitial ads</span></span>

<span data-ttu-id="73a1d-105">このチュートリアルでは、Windows 10 用のユニバーサル Windows プラットフォーム (UWP) アプリとゲーム、および Windows 8.1 または Windows Phone 8.1 用のアプリにスポット広告を組み込む方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-105">This walkthrough shows how to include interstitial ads in Universal Windows Platform (UWP) apps and games for Windows 10 and in apps for Windows 8.1 or Windows Phone 8.1.</span></span> <span data-ttu-id="73a1d-106">C# と C++ を使って JavaScript/HTML アプリと XAML アプリにスポット広告を追加する方法を示す完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="73a1d-106">For complete sample projects that demonstrate how to add interstitial ads to JavaScript/HTML apps and XAML apps using C# and C++, see the [advertising samples on GitHub](http://aka.ms/githubads).</span></span>

<span id="whatareinterstitialads10"/>
## <a name="what-are-interstitial-ads"></a><span data-ttu-id="73a1d-107">スポット広告とは</span><span class="sxs-lookup"><span data-stu-id="73a1d-107">What are interstitial ads?</span></span>

<span data-ttu-id="73a1d-108">アプリやゲームの UI の一部分に表示が限定される標準のバナー広告とは異なり、スポット広告は画面全体に表示されます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-108">Unlike standard banner ads, which are confined to a portion of a UI in an app or game, interstitial ads are shown on the entire screen.</span></span> <span data-ttu-id="73a1d-109">通常、ゲームでは、2 つの基本的な形式が使用されます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-109">Two basic forms are frequently used in games.</span></span>

* <span data-ttu-id="73a1d-110">*ペイウォール*広告の場合、ユーザーは一定の間隔で広告を視聴する必要があります。</span><span class="sxs-lookup"><span data-stu-id="73a1d-110">With *Paywall* ads, the user must watch an ad at some regular interval.</span></span> <span data-ttu-id="73a1d-111">たとえば、ゲームのレベル間に表示される広告が該当します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-111">For example between game levels:</span></span>

    ![whatisaninterstitial](images/13-ed0a333b-0fc8-4ca9-a4c8-11e8b4392831.png)

* <span data-ttu-id="73a1d-113">*報酬ベース*の広告の場合、ユーザーは明示的に特定のメリット (レベルを完了するためのヒントや追加の時間など) を求めていて、アプリのユーザー インターフェイスから広告を初期化します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-113">With *Rewards Based* ads the user is explicitly seeking some benefit, such as a hint or extra time to complete the level, and initializes the ad through the app’s user interface.</span></span>

<span data-ttu-id="73a1d-114">アプリやゲームで使用するために、次の 2 種類のスポット広告が用意されています。</span><span class="sxs-lookup"><span data-stu-id="73a1d-114">We provide two types of interstitial ads to use in your apps and games:</span></span>

* <span data-ttu-id="73a1d-115">**ビデオ スポット広告**: このスポット広告は、Windows 10 用のユニバーサル Windows プラットフォーム (UWP) アプリと、Windows 8.1 または Windows Phone 8.1 用のアプリで利用できます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-115">**Interstitial video ads**: These are available for Universal Windows Platform (UWP) apps for Windows 10 and in apps for Windows 8.1 or Windows Phone 8.1.</span></span>

* <span data-ttu-id="73a1d-116">**バナー スポット広告**: このスポット広告は、Windows 10 用の UWP アプリでのみ利用できます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-116">**Interstitial banner ads**: These are only available for UWP apps for Windows 10.</span></span>

> [!NOTE]
> <span data-ttu-id="73a1d-117">スポット広告用の API は、ビデオの再生時を除き、どのようなユーザー インターフェイスも処理しません。</span><span class="sxs-lookup"><span data-stu-id="73a1d-117">The API for interstitial ads does not handle any user interface except at the time of video playback.</span></span> <span data-ttu-id="73a1d-118">スポット広告をアプリに統合する方法を検討するときは、何をすべきであり何をすべきでないかに関するガイドラインとして、[スポットのベスト プラクティス](ui-and-user-experience-guidelines.md#interstitialbestpractices10)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="73a1d-118">Refer to the [interstitial best practices](ui-and-user-experience-guidelines.md#interstitialbestpractices10) for guidelines on what to do, and avoid, as you consider how to integrate interstitial ads in your app.</span></span>

## <a name="build-an-app-with-interstitial-ads"></a><span data-ttu-id="73a1d-119">スポット広告を含むアプリの構築</span><span class="sxs-lookup"><span data-stu-id="73a1d-119">Build an app with interstitial ads</span></span>

<span data-ttu-id="73a1d-120">アプリでスポット広告を表示するには、次のプロジェクトの種類の指示に従います。</span><span class="sxs-lookup"><span data-stu-id="73a1d-120">To show interstitial ads in your app, follow the instructions for project type:</span></span>

* [<span data-ttu-id="73a1d-121">XAML/.NET</span><span class="sxs-lookup"><span data-stu-id="73a1d-121">XAML/.NET</span></span>](#interstitialadsxaml10)
* [<span data-ttu-id="73a1d-122">HTML/JavaScript</span><span class="sxs-lookup"><span data-stu-id="73a1d-122">HTML/JavaScript</span></span>](#interstitialadshtml10)
* [<span data-ttu-id="73a1d-123">C++ (DirectX Interop)</span><span class="sxs-lookup"><span data-stu-id="73a1d-123">C++ (DirectX Interop)</span></span>](#interstitialadsdirectx10)

<span/>
### <a name="prerequisites"></a><span data-ttu-id="73a1d-124">前提条件</span><span class="sxs-lookup"><span data-stu-id="73a1d-124">Prerequisites</span></span>

* <span data-ttu-id="73a1d-125">UWP アプリの場合: Visual Studio 2015 以降のリリースと共に [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="73a1d-125">For UWP apps: install the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) with Visual Studio 2015 or a later release.</span></span>

* <span data-ttu-id="73a1d-126">Windows 8.1 アプリまたは Windows Phone 8.1 アプリ: Visual Studio 2015 または Visual Studio 2013 と共に [Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="73a1d-126">For Windows 8.1 or Windows Phone 8.1 apps: install the [Microsoft Advertising SDK for Windows and Windows Phone 8.x](http://aka.ms/store-8-sdk) with Visual Studio 2015 or Visual Studio 2013.</span></span>

<span id="interstitialadsxaml10"/>
### <a name="xamlnet"></a><span data-ttu-id="73a1d-127">XAML/.NET</span><span class="sxs-lookup"><span data-stu-id="73a1d-127">XAML/.NET</span></span>

<span data-ttu-id="73a1d-128">ここでは C# の例を紹介していますが、XAML/.NET プロジェクトでは Visual Basic と C++ もサポートされています。</span><span class="sxs-lookup"><span data-stu-id="73a1d-128">This section provides C# examples, but Visual Basic and C++ are also supported for XAML/.NET projects.</span></span> <span data-ttu-id="73a1d-129">完全な C# コードの例については、「[C# を使ったスポット広告のサンプル コード](interstitial-ad-sample-code-in-c.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="73a1d-129">For a complete C# code example, see [Interstitial ad sample code in C#](interstitial-ad-sample-code-in-c.md).</span></span>

1. <span data-ttu-id="73a1d-130">Visual Studio でプロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-130">Open your project in Visual Studio.</span></span>

2. <span data-ttu-id="73a1d-131">**[参照マネージャー]** で、プロジェクトの種類に応じて次のいずれかの参照を選択します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-131">In **Reference Manager**, select one of the following references depending on your project type:</span></span>

  * <span data-ttu-id="73a1d-132">ユニバーサル Windows プラットフォーム (UWP) プロジェクトの場合: **[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for XAML]** (Version 10.0) の横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="73a1d-132">For a Universal Windows Platform (UWP) project: Expand **Universal Windows**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for XAML** (Version 10.0).</span></span>

  * <span data-ttu-id="73a1d-133">Windows 8.1 プロジェクトの場合: **[Windows 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Ad Mediator SDK for Windows 8.1 XAML]** の横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="73a1d-133">For a Windows 8.1 project: Expand **Windows 8.1**, click **Extensions**, and then select the check box next to **Ad Mediator SDK for Windows 8.1 XAML**.</span></span> <span data-ttu-id="73a1d-134">この場合、Microsoft Advertising ライブラリと広告メディエーター ライブラリの両方がプロジェクトに追加されますが、広告メディエーター ライブラリは無視してかまいません。</span><span class="sxs-lookup"><span data-stu-id="73a1d-134">This option will add both the Microsoft advertising and ad mediator libraries to your project, but you can ignore the ad mediator libraries.</span></span>

  * <span data-ttu-id="73a1d-135">Windows Phone 8.1 プロジェクトの場合: **[Windows Phone 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Ad Mediator SDK for Windows Phone 8.1 XAML]** の横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="73a1d-135">For a Windows Phone 8.1 project: Expand **Windows Phone 8.1**, click **Extensions**, and then select the check box next to **Ad Mediator SDK for Windows Phone 8.1 XAML**.</span></span> <span data-ttu-id="73a1d-136">この場合、Microsoft Advertising ライブラリと広告メディエーター ライブラリの両方がプロジェクトに追加されますが、広告メディエーター ライブラリは無視してかまいません。</span><span class="sxs-lookup"><span data-stu-id="73a1d-136">This option will add both the Microsoft advertising and ad mediator libraries to your project, but you can ignore the ad mediator libraries.</span></span>

3.  <span data-ttu-id="73a1d-137">アプリの適切なコード ファイル (たとえば、MainPage.xaml.cs またはその他のページのコード ファイル) に、次の名前空間の参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-137">In the appropriate code file in your app (for example, in MainPage.xaml.cs or a code file for some other page), add the following namespace reference.</span></span>

  [!code-cs[<span data-ttu-id="73a1d-138">InterstitialAd</span><span class="sxs-lookup"><span data-stu-id="73a1d-138">InterstitialAd</span></span>](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#Snippet1)]

4.  <span data-ttu-id="73a1d-139">アプリの適切な場所 (たとえば、```MainPage``` またはその他のページ) で、[InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) オブジェクトと、スポット広告のアプリケーション ID および広告ユニット ID を表す複数の文字列フィールドを宣言します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-139">In an appropriate location in your app (for example, in ```MainPage``` or some other page), declare an [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) object and several string fields that represent the application ID and ad unit ID for your interstitial ad.</span></span> <span data-ttu-id="73a1d-140">次のコード例では、`myAppId` フィールドおよび `myAdUnitId` フィールドを、「[テスト モードの値](test-mode-values.md)」で提供されているビデオ スポット広告のテスト値に割り当てています。</span><span class="sxs-lookup"><span data-stu-id="73a1d-140">The following code example assigns the `myAppId` and `myAdUnitId` fields to the test values for interstitial video ads provided in [Test mode values](test-mode-values.md).</span></span>

  > [!NOTE]
  > <span data-ttu-id="73a1d-141">各 **InterstitialAd** に、対応する*広告ユニット*があります。広告ユニットは、コントロールに広告を提供するためにサービスで使用されます。すべての広告ユニットは、*広告ユニット ID* と*アプリケーション ID* で構成されます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-141">Every **InterstitialAd** has a corresponding *ad unit* that is used by our services to serve ads to the control, and every ad unit consists of an *ad unit ID* and *application ID*.</span></span> <span data-ttu-id="73a1d-142">ここでは、広告ユニット ID とアプリケーション ID のテスト値をコントロールに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-142">In these steps, you assign test ad unit ID and application ID values to your control.</span></span> <span data-ttu-id="73a1d-143">これらのテスト値は、テスト バージョンのアプリでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-143">These test values can only be used in a test version of your app.</span></span> <span data-ttu-id="73a1d-144">ストアにアプリを公開する前に、[これらのテスト値を Windows デベロッパー センターから取得した実際の値に置き換える](#release) 必要があります。</span><span class="sxs-lookup"><span data-stu-id="73a1d-144">Before you publish your app to the Store, you must [replace these test values with live values](#release) from Windows Dev Center.</span></span>

  [!code-cs[<span data-ttu-id="73a1d-145">InterstitialAd</span><span class="sxs-lookup"><span data-stu-id="73a1d-145">InterstitialAd</span></span>](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#Snippet2)]

5.  <span data-ttu-id="73a1d-146">起動時に実行されるコード (たとえば、ページのコンストラクター) 内で、**InterstitialAd** オブジェクトをインスタンス化し、このオブジェクトのイベント用のイベント ハンドラーを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-146">In code that runs on startup (for example, in the constructor for the page), instantiate the **InterstitialAd** object and wire up event handlers for events of the object.</span></span>

  [!code-cs[<span data-ttu-id="73a1d-147">InterstitialAd</span><span class="sxs-lookup"><span data-stu-id="73a1d-147">InterstitialAd</span></span>](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#Snippet3)]

6.  <span data-ttu-id="73a1d-148">*ビデオ スポット*広告を表示する場合: 広告が必要になる約 30 ～ 60 秒前に、[RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) メソッドを使用して事前に広告を取得しておきます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-148">If you want to show an *interstitial video* ad: Approximately 30-60 seconds before you need the ad, use the [RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) method to pre-fetch the ad.</span></span> <span data-ttu-id="73a1d-149">これにより、広告を表示する前に、その広告を要求して準備するための十分な時間が与えられます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-149">This allows enough time to request and prepare the ad before it should be shown.</span></span> <span data-ttu-id="73a1d-150">広告の種類として、必ず **AdType.Video** を指定してください。</span><span class="sxs-lookup"><span data-stu-id="73a1d-150">Be sure to specify **AdType.Video** for the ad type.</span></span>

  [!code-cs[<span data-ttu-id="73a1d-151">InterstitialAd</span><span class="sxs-lookup"><span data-stu-id="73a1d-151">InterstitialAd</span></span>](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#Snippet4)]

  <span data-ttu-id="73a1d-152">*バナー スポット*広告を表示する場合 (UWP アプリのみ): 広告が必要になる約 5 ～ 8 秒前に、[RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) メソッドを使用して事前に広告を取得しておきます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-152">If you want to show an *interstitial banner* ad (for UWP apps only): Approximately 5-8 seconds before you need the ad, use the [RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) method to pre-fetch the ad.</span></span> <span data-ttu-id="73a1d-153">これにより、広告を表示する前に、その広告を要求して準備するための十分な時間が与えられます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-153">This allows enough time to request and prepare the ad before it should be shown.</span></span> <span data-ttu-id="73a1d-154">広告の種類として、必ず **AdType.Display** を指定してください。</span><span class="sxs-lookup"><span data-stu-id="73a1d-154">Be sure to specify **AdType.Display** for the ad type.</span></span>

  ```csharp
  myInterstitialAd.RequestAd(AdType.Display, myAppId, myAdUnitId);
  ```

6.  <span data-ttu-id="73a1d-155">ビデオ スポット広告やバナー スポット広告を表示するコード内のポイントで、**InterstitialAd** を表示する準備ができていることを確認してから、[Show](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.show.aspx) メソッドを使用して広告を表示します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-155">At the point in your code where you want to show the interstitial video or interstitial banner ad, confirm that the **InterstitialAd** is ready to be shown and then show it by using the [Show](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.show.aspx) method.</span></span>

  [!code-cs[<span data-ttu-id="73a1d-156">InterstitialAd</span><span class="sxs-lookup"><span data-stu-id="73a1d-156">InterstitialAd</span></span>](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#Snippet5)]

7.  <span data-ttu-id="73a1d-157">**InterstitialAd** オブジェクトのイベント ハンドラーを定義します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-157">Define the event handlers for the **InterstitialAd** object.</span></span>

  [!code-cs[<span data-ttu-id="73a1d-158">InterstitialAd</span><span class="sxs-lookup"><span data-stu-id="73a1d-158">InterstitialAd</span></span>](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#Snippet6)]

8.  <span data-ttu-id="73a1d-159">アプリをビルドした後テストして、テスト広告が表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-159">Build and test your app to confirm it is showing test ads.</span></span>

<span id="interstitialadshtml10"/>
### <a name="htmljavascript"></a><span data-ttu-id="73a1d-160">HTML/JavaScript</span><span class="sxs-lookup"><span data-stu-id="73a1d-160">HTML/JavaScript</span></span>

<span data-ttu-id="73a1d-161">次の手順では、Visual Studio で JavaScript 用のユニバーサル Windows プロジェクトを作成済みであり、特定の CPU をターゲットとしているものと想定しています。</span><span class="sxs-lookup"><span data-stu-id="73a1d-161">The following instructions assume you have created a Universal Windows project for JavaScript in Visual Studio and are targeting a specific CPU.</span></span> <span data-ttu-id="73a1d-162">完全なコード サンプルについては、「[JavaScript を使ったスポット広告のサンプル コード](interstitial-ad-sample-code-in-javascript.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="73a1d-162">For a complete code sample, see [Interstitial ad sample code in JavaScript](interstitial-ad-sample-code-in-javascript.md).</span></span>

1. <span data-ttu-id="73a1d-163">Visual Studio でプロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-163">Open your project in Visual Studio.</span></span>

2.  <span data-ttu-id="73a1d-164">**[参照マネージャー]** で、プロジェクトの種類に応じて次のいずれかの参照を選択します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-164">In **Reference Manager**, select one of the following references depending on your project type:</span></span>

  * <span data-ttu-id="73a1d-165">ユニバーサル Windows プラットフォーム (UWP) プロジェクトの場合: **[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for JavaScript]** (Version 10.0) の横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="73a1d-165">For a Universal Windows Platform (UWP) project: Expand **Universal Windows**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for JavaScript** (Version 10.0).</span></span>

  * <span data-ttu-id="73a1d-166">Windows 8.1 プロジェクトの場合: **[Windows 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for Windows 8.1 Native (JS)]** の横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="73a1d-166">For a Windows 8.1 project: Expand **Windows 8.1**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for Windows 8.1 Native (JS)**.</span></span>

  * <span data-ttu-id="73a1d-167">Windows 8.1 プロジェクトの場合: **[Windows Phone 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for Windows Phone 8.1 Native (JS)]** の横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="73a1d-167">For a Windows 8.1 project: Expand **Windows Phone 8.1**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for Windows Phone 8.1 Native (JS)**.</span></span>

3.  <span data-ttu-id="73a1d-168">プロジェクト内の HTML ファイルの **&lt;head&gt;** セクションで、プロジェクトの default.css と default.js の JavaScript 参照の後に ad.js への参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-168">In the **&lt;head&gt;** section of the HTML file in the project, after the project’s JavaScript references of default.css and default.js, add the reference to ad.js.</span></span> <span data-ttu-id="73a1d-169">UWP プロジェクトでは、次の参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-169">In a UWP project, add the following reference.</span></span>

  ``` HTML
  <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
  ```

  <span data-ttu-id="73a1d-170">Windows 8.1 または Windows Phone 8.1 のプロジェクトでは、次の参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-170">In a Windows 8.1 or Windows Phone 8.1 project, add the following reference.</span></span>

  ``` HTML
  <script src="/MSAdvertisingJS/ads/ad.js"></script>
  ```

4.  <span data-ttu-id="73a1d-171">プロジェクト内の .js ファイルで、[InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) オブジェクトと、スポット広告のアプリケーション ID および広告ユニット ID を含む複数のフィールドを宣言します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-171">In a .js file in your project, declare an [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) object and several fields that contain the application ID and ad unit ID for your interstitial ad.</span></span> <span data-ttu-id="73a1d-172">次のコード例では、`applicationId` フィールドおよび `adUnitId` フィールドを、「[テスト モードの値](test-mode-values.md)」で提供されているビデオ スポット広告のテスト値に割り当てています。</span><span class="sxs-lookup"><span data-stu-id="73a1d-172">The following code example assigns the `applicationId` and `adUnitId` fields to the test values for interstitial video ads provided in [Test mode values](test-mode-values.md).</span></span>

  > [!NOTE]
  > <span data-ttu-id="73a1d-173">各 **InterstitialAd** に、対応する*広告ユニット*があります。広告ユニットは、コントロールに広告を提供するためにサービスで使用されます。すべての広告ユニットは、*広告ユニット ID* と*アプリケーション ID* で構成されます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-173">Every **InterstitialAd** has a corresponding *ad unit* that is used by our services to serve ads to the control, and every ad unit consists of an *ad unit ID* and *application ID*.</span></span> <span data-ttu-id="73a1d-174">ここでは、広告ユニット ID とアプリケーション ID のテスト値をコントロールに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-174">In these steps, you assign test ad unit ID and application ID values to your control.</span></span> <span data-ttu-id="73a1d-175">これらのテスト値は、テスト バージョンのアプリでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-175">These test values can only be used in a test version of your app.</span></span> <span data-ttu-id="73a1d-176">ストアにアプリを公開する前に、[これらのテスト値を Windows デベロッパー センターから取得した実際の値に置き換える](#release) 必要があります。</span><span class="sxs-lookup"><span data-stu-id="73a1d-176">Before you publish your app to the Store, you must [replace these test values with live values](#release) from Windows Dev Center.</span></span>

  [!code-javascript[<span data-ttu-id="73a1d-177">InterstitialAd</span><span class="sxs-lookup"><span data-stu-id="73a1d-177">InterstitialAd</span></span>](./code/AdvertisingSamples/InterstitialAdSamples/js/script.js#Snippet1)]

5.  <span data-ttu-id="73a1d-178">起動時に実行されるコード (たとえば、ページのコンストラクター) 内で、**InterstitialAd** オブジェクトをインスタンス化し、このオブジェクトのイベント ハンドラーを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-178">In code that runs on startup (for example, in the constructor for the page), instantiate the **InterstitialAd** object and wire up event handlers for the object.</span></span>

  [!code-javascript[<span data-ttu-id="73a1d-179">InterstitialAd</span><span class="sxs-lookup"><span data-stu-id="73a1d-179">InterstitialAd</span></span>](./code/AdvertisingSamples/InterstitialAdSamples/js/script.js#Snippet2)]

5. <span data-ttu-id="73a1d-180">*ビデオ スポット*広告を表示する場合: 広告が必要になる約 30 ～ 60 秒前に、[RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) メソッドを使用して事前に広告を取得しておきます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-180">If you want to show an *interstitial video* ad: Approximately 30-60 seconds before you need the ad, use the [RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) method to pre-fetch the ad.</span></span> <span data-ttu-id="73a1d-181">これにより、広告を表示する前に、その広告を要求して準備するための十分な時間が与えられます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-181">This allows enough time to request and prepare the ad before it should be shown.</span></span> <span data-ttu-id="73a1d-182">広告の種類として、必ず **InterstitialAdType.video** を指定してください。</span><span class="sxs-lookup"><span data-stu-id="73a1d-182">Be sure to specify **InterstitialAdType.video** for the ad type.</span></span>

  [!code-javascript[<span data-ttu-id="73a1d-183">InterstitialAd</span><span class="sxs-lookup"><span data-stu-id="73a1d-183">InterstitialAd</span></span>](./code/AdvertisingSamples/InterstitialAdSamples/js/script.js#Snippet3)]

  <span data-ttu-id="73a1d-184">*バナー スポット*広告を表示する場合 (UWP アプリのみ): 広告が必要になる約 5 ～ 8 秒前に、[RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) メソッドを使用して事前に広告を取得しておきます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-184">If you want to show an *interstitial banner* ad (for UWP apps only): Approximately 5-8 seconds before you need the ad, use the [RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) method to pre-fetch the ad.</span></span> <span data-ttu-id="73a1d-185">これにより、広告を表示する前に、その広告を要求して準備するための十分な時間が与えられます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-185">This allows enough time to request and prepare the ad before it should be shown.</span></span> <span data-ttu-id="73a1d-186">広告の種類として、必ず **InterstitialAdType.display** を指定してください。</span><span class="sxs-lookup"><span data-stu-id="73a1d-186">Be sure to specify **InterstitialAdType.display** for the ad type.</span></span>

  ```js
  if (interstitialAd) {
      interstitialAd.requestAd(MicrosoftNSJS.Advertising.InterstitialAdType.display, applicationId, adUnitId);
  }
  ```

6.  <span data-ttu-id="73a1d-187">広告を表示するコード内のポイントで、**InterstitialAd** を表示する準備ができていることを確認してから、[Show](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.show.aspx) メソッドを使用して広告を表示します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-187">At the point in your code where you want to show the ad, confirm that the **InterstitialAd** is ready to be shown and then show it by using the [Show](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.show.aspx) method.</span></span>

  [!code-javascript[<span data-ttu-id="73a1d-188">InterstitialAd</span><span class="sxs-lookup"><span data-stu-id="73a1d-188">InterstitialAd</span></span>](./code/AdvertisingSamples/InterstitialAdSamples/js/samples.js#Snippet4)]

7.  <span data-ttu-id="73a1d-189">**InterstitialAd** オブジェクトのイベント ハンドラーを定義します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-189">Define the event handlers for the **InterstitialAd** object.</span></span>

  [!code-javascript[<span data-ttu-id="73a1d-190">InterstitialAd</span><span class="sxs-lookup"><span data-stu-id="73a1d-190">InterstitialAd</span></span>](./code/AdvertisingSamples/InterstitialAdSamples/js/samples.js#Snippet5)]

9.  <span data-ttu-id="73a1d-191">アプリをビルドした後テストして、テスト広告が表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-191">Build and test your app to confirm it is showing test ads.</span></span>

<span id="interstitialadsdirectx10"/>
### <a name="c-directx-interop"></a><span data-ttu-id="73a1d-192">C++ (DirectX Interop)</span><span class="sxs-lookup"><span data-stu-id="73a1d-192">C++ (DirectX Interop)</span></span>

<span data-ttu-id="73a1d-193">このサンプルでは、Visual Studio で C++ **DirectX および XAML アプリ (ユニバーサル Windows)** プロジェクトを作成済みであり、特定の CPU アーキテクチャをターゲットとしているものと想定しています。</span><span class="sxs-lookup"><span data-stu-id="73a1d-193">This sample assumes you have created a C++ **DirectX and XAML App (Universal Windows)** project in Visual Studio and are targeting a specific CPU architecture.</span></span>
 
1. <span data-ttu-id="73a1d-194">Visual Studio でプロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-194">Open your project in Visual Studio.</span></span>

1.  <span data-ttu-id="73a1d-195">**[参照マネージャー]** で、プロジェクトの種類に応じて次のいずれかの参照を選択します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-195">In **Reference Manager**, select one of the following references depending on your project type:</span></span>

  * <span data-ttu-id="73a1d-196">ユニバーサル Windows プラットフォーム (UWP) プロジェクトの場合: **[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for XAML]** (Version 10.0) の横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="73a1d-196">For a Universal Windows Platform (UWP) project: Expand **Universal Windows**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for XAML** (Version 10.0).</span></span>

  * <span data-ttu-id="73a1d-197">Windows 8.1 プロジェクトの場合: **[Windows 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Ad Mediator SDK for Windows 8.1 XAML]** の横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="73a1d-197">For a Windows 8.1 project: Expand **Windows 8.1**, click **Extensions**, and then select the check box next to **Ad Mediator SDK for Windows 8.1 XAML**.</span></span> <span data-ttu-id="73a1d-198">この場合、Microsoft Advertising ライブラリと広告メディエーター ライブラリの両方がプロジェクトに追加されますが、広告メディエーター ライブラリは無視してかまいません。</span><span class="sxs-lookup"><span data-stu-id="73a1d-198">This option will add both the Microsoft advertising and ad mediator libraries to your project, but you can ignore the ad mediator libraries.</span></span>

  * <span data-ttu-id="73a1d-199">Windows Phone 8.1 プロジェクトの場合: **[Windows Phone 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Ad Mediator SDK for Windows Phone 8.1 XAML]** の横のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="73a1d-199">For a Windows Phone 8.1 project: Expand **Windows Phone 8.1**, click **Extensions**, and then select the check box next to **Ad Mediator SDK for Windows Phone 8.1 XAML**.</span></span> <span data-ttu-id="73a1d-200">この場合、Microsoft Advertising ライブラリと広告メディエーター ライブラリの両方がプロジェクトに追加されますが、広告メディエーター ライブラリは無視してかまいません。</span><span class="sxs-lookup"><span data-stu-id="73a1d-200">This option will add both the Microsoft advertising and ad mediator libraries to your project, but you can ignore the ad mediator libraries.</span></span>

2.  <span data-ttu-id="73a1d-201">アプリの適切なヘッダー ファイル (例: DirectXPage.xaml.h) 内で、[InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) オブジェクトと関連するイベント ハンドラー メソッドを宣言します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-201">In an appropriate header file for your app (for example, DirectXPage.xaml.h), declare an [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) object and related event handler methods.</span></span>  

  [!code-cpp[<span data-ttu-id="73a1d-202">InterstitialAd</span><span class="sxs-lookup"><span data-stu-id="73a1d-202">InterstitialAd</span></span>](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.h#Snippet1)]

3.  <span data-ttu-id="73a1d-203">同じヘッダー ファイル内で、スポット広告のアプリケーション ID と広告ユニット ID を表す複数の文字列フィールドを宣言します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-203">In the same header file, declare several string fields that represent the application ID and ad unit ID for your interstitial ad.</span></span> <span data-ttu-id="73a1d-204">次のコード例では、`myAppId` フィールドおよび `myAdUnitId` フィールドを、「[テスト モードの値](test-mode-values.md)」で提供されているビデオ スポット広告のテスト値に割り当てています。</span><span class="sxs-lookup"><span data-stu-id="73a1d-204">The following code example assigns the `myAppId` and `myAdUnitId` fields to the test values for interstitial video ads provided in [Test mode values](test-mode-values.md).</span></span>

  > [!NOTE]
  > <span data-ttu-id="73a1d-205">各 **InterstitialAd** に、対応する*広告ユニット*があります。広告ユニットは、コントロールに広告を提供するためにサービスで使用されます。すべての広告ユニットは、*広告ユニット ID* と*アプリケーション ID* で構成されます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-205">Every **InterstitialAd** has a corresponding *ad unit* that is used by our services to serve ads to the control, and every ad unit consists of an *ad unit ID* and *application ID*.</span></span> <span data-ttu-id="73a1d-206">ここでは、広告ユニット ID とアプリケーション ID のテスト値をコントロールに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-206">In these steps, you assign test ad unit ID and application ID values to your control.</span></span> <span data-ttu-id="73a1d-207">これらのテスト値は、テスト バージョンのアプリでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-207">These test values can only be used in a test version of your app.</span></span> <span data-ttu-id="73a1d-208">ストアにアプリを公開する前に、[これらのテスト値を Windows デベロッパー センターから取得した実際の値に置き換える](#release) 必要があります。</span><span class="sxs-lookup"><span data-stu-id="73a1d-208">Before you publish your app to the Store, you must [replace these test values with live values](#release) from Windows Dev Center.</span></span>

  [!code-cpp[<span data-ttu-id="73a1d-209">InterstitialAd</span><span class="sxs-lookup"><span data-stu-id="73a1d-209">InterstitialAd</span></span>](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.h#Snippet2)]

4.  <span data-ttu-id="73a1d-210">スポット広告を表示するためのコードを追加する .cpp ファイルに、次の名前空間の参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-210">In the .cpp file where you want to add code to show an interstitial ad, add the following namespace reference.</span></span> <span data-ttu-id="73a1d-211">次の例では、アプリの DirectXPage.xaml.cpp ファイルにそのコードを追加しているものと想定しています。</span><span class="sxs-lookup"><span data-stu-id="73a1d-211">The following examples assume you are adding the code to DirectXPage.xaml.cpp file in your app.</span></span>

  [!code-cpp[<span data-ttu-id="73a1d-212">InterstitialAd</span><span class="sxs-lookup"><span data-stu-id="73a1d-212">InterstitialAd</span></span>](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.cpp#Snippet3)]

6.  <span data-ttu-id="73a1d-213">起動時に実行されるコード (たとえば、ページのコンストラクター) 内で、**InterstitialAd** オブジェクトをインスタンス化し、このオブジェクトのイベント用のイベント ハンドラーを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-213">In code that runs on startup (for example, in the constructor for the page), instantiate the **InterstitialAd** object and wire up event handlers for events of the object.</span></span> <span data-ttu-id="73a1d-214">次の例では、```InterstitialAdSamplesCpp``` がプロジェクトの名前空間です。コードでは、必要に応じてこの名前を変更します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-214">In the following example, ```InterstitialAdSamplesCpp``` is the namespace for your project; change this name as necessary for your code.</span></span>

  [!code-cpp[<span data-ttu-id="73a1d-215">InterstitialAd</span><span class="sxs-lookup"><span data-stu-id="73a1d-215">InterstitialAd</span></span>](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.cpp#Snippet4)]

7. <span data-ttu-id="73a1d-216">*ビデオ スポット*広告を表示する場合: スポット広告が必要になる約 30 ～ 60 秒前に、[RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) メソッドを使用して事前に広告を取得しておきます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-216">If you want to show an *interstitial video* ad: Approximately 30-60 seconds before you need the interstitial ad, use the [RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) method to pre-fetch the ad.</span></span> <span data-ttu-id="73a1d-217">これにより、広告を表示する前に、その広告を要求して準備するための十分な時間が与えられます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-217">This allows enough time to request and prepare the ad before it should be shown.</span></span> <span data-ttu-id="73a1d-218">広告の種類として、必ず **AdType::Video** を指定してください。</span><span class="sxs-lookup"><span data-stu-id="73a1d-218">Be sure to specify **AdType::Video** for the ad type.</span></span>

  [!code-cpp[<span data-ttu-id="73a1d-219">InterstitialAd</span><span class="sxs-lookup"><span data-stu-id="73a1d-219">InterstitialAd</span></span>](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.cpp#Snippet5)]

  <span data-ttu-id="73a1d-220">*バナー スポット*広告を表示する場合 (UWP アプリのみ): 広告が必要になる約 5 ～ 8 秒前に、[RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) メソッドを使用して事前に広告を取得しておきます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-220">If you want to show an *interstitial banner* ad (for UWP apps only): Approximately 5-8 seconds before you need the ad, use the [RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) method to pre-fetch the ad.</span></span> <span data-ttu-id="73a1d-221">これにより、広告を表示する前に、その広告を要求して準備するための十分な時間が与えられます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-221">This allows enough time to request and prepare the ad before it should be shown.</span></span> <span data-ttu-id="73a1d-222">広告の種類として、必ず **AdType::Display** を指定してください。</span><span class="sxs-lookup"><span data-stu-id="73a1d-222">Be sure to specify **AdType::Display** for the ad type.</span></span>

  ```cpp
  m_interstitialAd->RequestAd(AdType::Display, myAppId, myAdUnitId);
  ```

7.  <span data-ttu-id="73a1d-223">広告を表示するコード内のポイントで、**InterstitialAd** を表示する準備ができていることを確認してから、[Show](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.show.aspx) メソッドを使用して広告を表示します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-223">At the point in your code where you want to show the ad, confirm that the **InterstitialAd** is ready to be shown and then show it by using the [Show](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.show.aspx) method.</span></span>

  [!code-cpp[<span data-ttu-id="73a1d-224">InterstitialAd</span><span class="sxs-lookup"><span data-stu-id="73a1d-224">InterstitialAd</span></span>](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.cpp#Snippet6)]

8.  <span data-ttu-id="73a1d-225">**InterstitialAd** オブジェクトのイベント ハンドラーを定義します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-225">Define the event handlers for the **InterstitialAd** object.</span></span>

  [!code-cpp[<span data-ttu-id="73a1d-226">InterstitialAd</span><span class="sxs-lookup"><span data-stu-id="73a1d-226">InterstitialAd</span></span>](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.cpp#Snippet7)]

9. <span data-ttu-id="73a1d-227">アプリをビルドした後テストして、テスト広告が表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-227">Build and test your app to confirm it is showing test ads.</span></span>

<span id="release" />
## <a name="release-your-app-with-live-ads-using-windows-dev-center"></a><span data-ttu-id="73a1d-228">Windows デベロッパー センターを使用して、ライブ広告を表示するアプリをリリースする</span><span class="sxs-lookup"><span data-stu-id="73a1d-228">Release your app with live ads using Windows Dev Center</span></span>

1.  <span data-ttu-id="73a1d-229">デベロッパー センターのダッシュボードで、アプリの [[広告で収入を増やす]](../publish/monetize-with-ads.md) ページに移動し、[広告ユニットを作成](../monetize/set-up-ad-units-in-your-app.md)します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-229">In the Dev Center dashboard, go to the [Monetize with ads](../publish/monetize-with-ads.md) page for your app and [create an ad unit](../monetize/set-up-ad-units-in-your-app.md).</span></span> <span data-ttu-id="73a1d-230">表示するスポット広告の種類に応じて、広告ユニットの種類として、**[ビデオ (スポット)]** または **[バナー (スポット)]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-230">For the ad unit type, choose **Video interstitial** or **Banner interstitial**, depending on what type of interstitial ad you are showing.</span></span> <span data-ttu-id="73a1d-231">広告ユニット ID とアプリケーション ID の両方をメモしておきます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-231">Make note of both the ad unit ID and the application ID.</span></span>

2. <span data-ttu-id="73a1d-232">アプリが Windows 10 用 UWP アプリである場合、[[広告で収入を増やす]](../publish/monetize-with-ads.md) ページの [[広告仲介]](../publish/monetize-with-ads.md#mediation) セクションで設定を構成することにより、必要に応じて **InterstitialAd** の広告仲介を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-232">If your app is a UWP app for Windows 10, you can optionally enable ad mediation for the **InterstitialAd** by configuring the settings in the [Ad mediation](../publish/monetize-with-ads.md#mediation) section on the [Monetize with ads](../publish/monetize-with-ads.md) page.</span></span> <span data-ttu-id="73a1d-233">広告仲介を使うと、複数の広告ネットワークから広告を表示して、広告収益とアプリ プロモーションの機能を最大限に引き出すことができます。表示される広告には、Taboola や Smaato などの他の有料広告ネットワークからの広告や、Microsoft のアプリ プロモーション キャンペーン用の広告などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-233">Ad mediation enables you to maximize your ad revenue and app promotion capabilities by displaying ads from multiple ad networks, including ads from other paid ad networks such as Taboola and Smaato and ads for Microsoft app promotion campaigns.</span></span>

3.  <span data-ttu-id="73a1d-234">コードで、広告ユニットのテスト値を、デベロッパー センターで生成した実際の値に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-234">In your code, replace the test ad unit values with the live values you generated in Dev Center.</span></span>

4.  <span data-ttu-id="73a1d-235">Windows デベロッパー センター ダッシュボードを使用して、ストアに[アプリを提出](../publish/app-submissions.md)します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-235">[Submit your app](../publish/app-submissions.md) to the Store using the Windows Dev Center dashboard.</span></span>

5.  <span data-ttu-id="73a1d-236">デベロッパー センター ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-236">Review your [advertising performance reports](../publish/advertising-performance-report.md) in the Dev Center dashboard.</span></span>

<span id="manage" />
## <a name="manage-ad-units-for-multiple-interstitial-ad-controls-in-your-app"></a><span data-ttu-id="73a1d-237">アプリで複数のスポット広告コントロールの広告ユニットを管理します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-237">Manage ad units for multiple interstitial ad controls in your app</span></span>

<span data-ttu-id="73a1d-238">1 つのアプリに複数の **InterstitialAd** コントロールを使用できます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-238">You can use multiple **InterstitialAd** controls in a single app.</span></span> <span data-ttu-id="73a1d-239">このシナリオでは、各コントロールに異なる広告ユニットを割り当てることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="73a1d-239">In this scenario, we recommend that you assign a different ad unit to each control.</span></span> <span data-ttu-id="73a1d-240">各コントロールに異なる広告ユニットを使用することで、別々に[仲介の設定を構成](../publish/monetize-with-ads.md#mediation)して、個別の[報告データ](../publish/advertising-performance-report.md)を取得することが可能です。</span><span class="sxs-lookup"><span data-stu-id="73a1d-240">Using different ad units for each control enables you to separately [configure the mediation settings](../publish/monetize-with-ads.md#mediation) and get discrete [reporting data](../publish/advertising-performance-report.md) for each control.</span></span> <span data-ttu-id="73a1d-241">また、これにより、Microsoft のサービスはアプリに提供する広告を最適化できます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-241">This also enables our services to better optimize the ads we serve to your app.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="73a1d-242">各広告ユニットは 1 つのアプリのみで使用できます。</span><span class="sxs-lookup"><span data-stu-id="73a1d-242">You can use each ad unit in only one app.</span></span> <span data-ttu-id="73a1d-243">複数のアプリで広告ユニットを使うと、広告ユニットに広告が提供されません。</span><span class="sxs-lookup"><span data-stu-id="73a1d-243">If you use an ad unit in more than one app, ads will not be served for that ad unit.</span></span>

<span id="interstitialbestpractices10"/>
## <a name="interstitial-best-practices-and-policies"></a><span data-ttu-id="73a1d-244">スポット広告に関するベスト プラクティスとポリシー</span><span class="sxs-lookup"><span data-stu-id="73a1d-244">Interstitial best practices and policies</span></span>


<span data-ttu-id="73a1d-245">スポット広告を効果的に使用する方法と、従う必要があるポリシーについて詳しくは、「[スポットのベスト プラクティスとポリシー](ui-and-user-experience-guidelines.md#interstitialbestpractices10)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="73a1d-245">For more information about how to use interstitial ads effectively and policies that you must follow, see [Interstitial best practices and policies](ui-and-user-experience-guidelines.md#interstitialbestpractices10).</span></span>

<span id="targetplatform10"/>
## <a name="remove-reference-errors-target-a-specific-cpu-platform-xaml-and-html"></a><span data-ttu-id="73a1d-246">参照エラーの解決: 特定の CPU プラットフォームをターゲットにする (XAML と HTML)</span><span class="sxs-lookup"><span data-stu-id="73a1d-246">Remove reference errors: target a specific CPU platform (XAML and HTML)</span></span>


<span data-ttu-id="73a1d-247">Microsoft Advertising ライブラリを使う場合、プロジェクトで **"Any CPU"** をターゲットにすることはできません。</span><span class="sxs-lookup"><span data-stu-id="73a1d-247">When using the Microsoft advertising libraries, you cannot target **Any CPU** in your project.</span></span> <span data-ttu-id="73a1d-248">プロジェクトでのターゲットを **Any CPU** プラットフォームに設定している場合は、Microsoft Advertising ライブラリに参照を追加した後で警告メッセージが表示される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="73a1d-248">If your project targets the **Any CPU** platform, you may see a warning in your project after you add a reference to the Microsoft advertising libraries.</span></span> <span data-ttu-id="73a1d-249">この警告を解決するには、アーキテクチャ固有のビルド出力 (たとえば、**x86**) を使用するようにプロジェクトを更新します。</span><span class="sxs-lookup"><span data-stu-id="73a1d-249">To remove this warning, update your project to use an architecture-specific build output (for example, **x86**).</span></span> <span data-ttu-id="73a1d-250">詳しくは、「[既知の問題](known-issues-for-the-advertising-libraries.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="73a1d-250">For more information, see [Known issues](known-issues-for-the-advertising-libraries.md).</span></span>

## <a name="related-topics"></a><span data-ttu-id="73a1d-251">関連トピック</span><span class="sxs-lookup"><span data-stu-id="73a1d-251">Related topics</span></span>


* [<span data-ttu-id="73a1d-252">C# を使ったスポット広告のサンプル コード</span><span class="sxs-lookup"><span data-stu-id="73a1d-252">Interstitial ad sample code in C#</span></span>](interstitial-ad-sample-code-in-c.md)
* [<span data-ttu-id="73a1d-253">JavaScript を使ったスポット広告のサンプル コード</span><span class="sxs-lookup"><span data-stu-id="73a1d-253">Interstitial ad sample code in JavaScript</span></span>](interstitial-ad-sample-code-in-javascript.md)
* [<span data-ttu-id="73a1d-254">GitHub の広告サンプル</span><span class="sxs-lookup"><span data-stu-id="73a1d-254">Advertising samples on GitHub</span></span>](http://aka.ms/githubads)
* [<span data-ttu-id="73a1d-255">アプリの広告ユニットをセットアップする</span><span class="sxs-lookup"><span data-stu-id="73a1d-255">Set up ad units for your app</span></span>](../monetize/set-up-ad-units-in-your-app.md)
