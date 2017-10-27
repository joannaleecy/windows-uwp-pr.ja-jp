---
author: QuinnRadich
title: "Windows ドキュメントの最新情報、2017 年 8 月 - UWP アプリの開発"
description: "2017 年 8 月版の Windows 10 開発者向けドキュメントには、新しい機能、ビデオ、開発者向けガイダンスが追加されました"
keywords: "最新情報, 更新, 機能, 開発者向けガイダンス, Windows 10, 1708"
ms.author: quradic
ms.date: 08/03/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: 30d2ed9a1da56faaacf45f25e2c57e59344f0815
ms.sourcegitcommit: 77bbd060f9253f2b03f0b9d74954c187bceb4a30
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/11/2017
---
# <a name="whats-new-in-the-windows-developer-docs-in-august-2017"></a><span data-ttu-id="502d5-104">Windows 開発者向けドキュメントの最新情報、2017 年 8 月</span><span class="sxs-lookup"><span data-stu-id="502d5-104">What's New in the Windows Developer Docs in August 2017</span></span>

<span data-ttu-id="502d5-105">Windows 開発者向けドキュメントは、Windows プラットフォームで開発者に提供される新機能の情報を反映して継続的に更新されています。</span><span class="sxs-lookup"><span data-stu-id="502d5-105">The Windows Developer Documentation is constantly being updated with information on new features available to developers across the Windows platform.</span></span> <span data-ttu-id="502d5-106">ここに示す機能概要、開発者向けガイダンス、ビデオは最近公開されたもので、Windows 開発者向けの新しい情報や更新情報を含んでいます。</span><span class="sxs-lookup"><span data-stu-id="502d5-106">The following feature overviews, developer guidance, and videos have recently been made available, containing new and updated information for Windows developers.</span></span>

<span data-ttu-id="502d5-107">Windows 10 の[ツールと SDK をインストール](http://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/your-first-app.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="502d5-107">[Install the tools and SDK](http://go.microsoft.com/fwlink/?LinkId=821431) on Windows 10 and you’re ready to either [create a new Universal Windows app](../get-started/your-first-app.md) or explore how you can use your [existing app code on Windows](../porting/index.md).</span></span>

## <a name="features"></a><span data-ttu-id="502d5-108">機能</span><span class="sxs-lookup"><span data-stu-id="502d5-108">Features</span></span>

### <a name="windows-template-studio"></a><span data-ttu-id="502d5-109">Windows Template Studio</span><span class="sxs-lookup"><span data-stu-id="502d5-109">Windows Template Studio</span></span>

<span data-ttu-id="502d5-110">Visual Studio 2017 用の新しい [Windows Template Studio](https://aka.ms/wtsinstall) 拡張機能を使うと、必要なページ、フレームワーク、機能を組み込んだ UWP アプリをすばやく作成できます。</span><span class="sxs-lookup"><span data-stu-id="502d5-110">Use the new [Windows Template Studio](https://aka.ms/wtsinstall) extension for Visual Studio 2017 to quickly build a UWP app with the pages, framework, and features that you want.</span></span> <span data-ttu-id="502d5-111">このウィザード ベースのエクスペリエンスには、実証済みのパターンとベスト プラクティスが実装されています。これにより、アプリに機能を追加するときにかかる時間を短縮し、よくある問題を避けることができます。</span><span class="sxs-lookup"><span data-stu-id="502d5-111">This wizard-based experience implements proven patterns and best practices to save you time and trouble adding features to your app.</span></span>

![Windows Template Studio](images/template-studio.png)

### <a name="conditional-xaml"></a><span data-ttu-id="502d5-113">条件付き XAML</span><span class="sxs-lookup"><span data-stu-id="502d5-113">Conditional XAML</span></span>

<span data-ttu-id="502d5-114">[バージョン アダプティブ アプリ](../debug-test-perf/version-adaptive-apps.md)の作成を可能にする[条件付き XAML](../debug-test-perf/conditional-xaml.md) をプレビューできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="502d5-114">You can now preview [conditional XAML](../debug-test-perf/conditional-xaml.md) to create [version adaptive apps](../debug-test-perf/version-adaptive-apps.md).</span></span> <span data-ttu-id="502d5-115">条件付き XAML では、XAML マークアップで ApiInformation.IsApiContractPresent メソッドを使用できるため、分離コードを使わなくても、API の有無に基づいてマークアップでプロパティの設定やオブジェクトのインスタンス化を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="502d5-115">Conditional XAML lets you use the ApiInformation.IsApiContractPresent method in XAML markup, so you can set properties and instantiate objects in markup based on the presence of an API, without needing to use code behind.</span></span>

### <a name="game-mode"></a><span data-ttu-id="502d5-116">ゲーム モード</span><span class="sxs-lookup"><span data-stu-id="502d5-116">Game Mode</span></span>

<span data-ttu-id="502d5-117">ユニバーサル Windows プラットフォーム (UWP) 用の[ゲーム モード](https://msdn.microsoft.com/library/windows/desktop/mt808808) API では、Windows 10 のゲーム モードを利用することで最適化されたゲーム エクスペリエンスを実現できます。</span><span class="sxs-lookup"><span data-stu-id="502d5-117">The [Game Mode](https://msdn.microsoft.com/library/windows/desktop/mt808808) APIs for the Universal Windows Platform (UWP) allow you to produce the most optimized gaming experience by taking advantage of Game Mode in Windows 10.</span></span> <span data-ttu-id="502d5-118">これらの API は **&lt;expandedresources.h&gt;** ヘッダーに含まれています。</span><span class="sxs-lookup"><span data-stu-id="502d5-118">These APIs are located in the **&lt;expandedresources.h&gt;** header.</span></span>

![ゲーム モード](images/game-mode.png)

### <a name="submission-api-supports-video-trailers-and-gaming-options"></a><span data-ttu-id="502d5-120">申請 API でのビデオ トレーラーとゲーム オプションのサポート</span><span class="sxs-lookup"><span data-stu-id="502d5-120">Submission API supports video trailers and gaming options</span></span>

<span data-ttu-id="502d5-121">[Windows ストア申請 API](../monetize/create-and-manage-submissions-using-windows-store-services.md) で、アプリの申請に[ビデオ トレーラー](../monetize/manage-app-submissions.md#trailer-object)や[ゲーム オプション](../monetize/manage-app-submissions.md#gaming-options-object)を含めることができるようになりました。</span><span class="sxs-lookup"><span data-stu-id="502d5-121">The [Windows Store submission API](../monetize/create-and-manage-submissions-using-windows-store-services.md) now enables you to include [video trailers](../monetize/manage-app-submissions.md#trailer-object) and [gaming options](../monetize/manage-app-submissions.md#gaming-options-object) with your app submissions.</span></span>


## <a name="developer-guidance"></a><span data-ttu-id="502d5-122">開発者向けガイダンス</span><span class="sxs-lookup"><span data-stu-id="502d5-122">Developer Guidance</span></span>

### <a name="data-schemas-for-store-products"></a><span data-ttu-id="502d5-123">ストア製品のデータ スキーマ</span><span class="sxs-lookup"><span data-stu-id="502d5-123">Data schemas for Store products</span></span>

<span data-ttu-id="502d5-124">記事「[ストア製品のデータ スキーマ](../monetize/data-schemas-for-store-products.md)」が追加されました。</span><span class="sxs-lookup"><span data-stu-id="502d5-124">We've added the [Data schemas for Store products](../monetize/data-schemas-for-store-products.md) article.</span></span> <span data-ttu-id="502d5-125">この記事では、[StoreProduct](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct) や [StoreAppLicense](https://docs.microsoft.com/uwp/api/windows.services.store.storeapplicense) など、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間のいくつかのオブジェクトで利用できるストア関連のデータ用のスキーマを示します。</span><span class="sxs-lookup"><span data-stu-id="502d5-125">This article provides schemas for the Store-related data available for several objects in the [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) namespace, including [StoreProduct](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct) and [StoreAppLicense](https://docs.microsoft.com/uwp/api/windows.services.store.storeapplicense).</span></span>

### <a name="desktop-bridge"></a><span data-ttu-id="502d5-126">デスクトップ ブリッジ</span><span class="sxs-lookup"><span data-stu-id="502d5-126">Desktop Bridge</span></span>

<span data-ttu-id="502d5-127">Windows 10 ユーザーの利便性を高める最新のエクスペリエンスを実装するために役立つ 2 つのガイドが追加されました。</span><span class="sxs-lookup"><span data-stu-id="502d5-127">We've added two guides that help you to add modern experiences that light up for Windows 10 users.</span></span>

<span data-ttu-id="502d5-128">「[Windows 10 向けのデスクトップ アプリを強化する](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-enhance)」では、適切なファイルを見つけて参照し、Windows 10 ユーザーの UWP エクスペリエンスを向上させるコードを記述する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="502d5-128">See [Enhance your desktop application for Windows 10](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-enhance) to find and reference the correct files, and then write code to light up UWP experiences for Windows 10 users.</span></span>  

<span data-ttu-id="502d5-129">「[最新の UWP コンポーネントによるデスクトップ アプリケーションの拡張](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-extend)」では、UWP アプリ コンテナーで実行される最新の XAML UI やその他の UWP エクスペリエンスを組み込む方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="502d5-129">See [Extend your desktop application with modern UWP components](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-extend) to incorporate modern XAML UIs and other UWP experiences that must run in a UWP app container.</span></span>

### <a name="getting-started-with-point-of-service"></a><span data-ttu-id="502d5-130">POS (店舗販売時点管理) の概要</span><span class="sxs-lookup"><span data-stu-id="502d5-130">Getting started with point of service</span></span>

<span data-ttu-id="502d5-131">[POS (店舗販売時点管理) サービス](https://docs.microsoft.com/en-us/windows/uwp/devices-sensors/pos-get-started)を利用する場合に役立つ新しいガイドが追加されました。</span><span class="sxs-lookup"><span data-stu-id="502d5-131">We've added a new guide to help you [get started with point of service devices](https://docs.microsoft.com/en-us/windows/uwp/devices-sensors/pos-get-started).</span></span> <span data-ttu-id="502d5-132">このガイドでは、デバイスの列挙、デバイス機能の確認、デバイスの要求、デバイスの共有といったトピックについて説明します。</span><span class="sxs-lookup"><span data-stu-id="502d5-132">It covers topics like device enumeration, checking device capabilities, claiming devices, and device sharing.</span></span> 

### <a name="xbox-live"></a><span data-ttu-id="502d5-133">Xbox Live</span><span class="sxs-lookup"><span data-stu-id="502d5-133">Xbox Live</span></span>

<span data-ttu-id="502d5-134">Xbox Live 開発者向けに、UWP ゲームと Xbox 開発キット (XDK) のゲームの両方に関するドキュメントが追加されました。</span><span class="sxs-lookup"><span data-stu-id="502d5-134">We've added docs for Xbox Live developers, for both UWP and Xbox Developer Kit (XDK) games.</span></span>

<span data-ttu-id="502d5-135">「[Xbox Live 開発者向けガイド](https://docs.microsoft.com/en-us/windows/uwp/xbox-live/)」では、Xbox Live API を使ってゲームを Xbox Live ソーシャル ゲーミング ネットワークに接続する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="502d5-135">See the [Xbox Live developer guide](https://docs.microsoft.com/en-us/windows/uwp/xbox-live/) to learn how to use the Xbox Live APIs to connect your game to the Xbox Live social gaming network.</span></span>

<span data-ttu-id="502d5-136">[Xbox Live クリエーターズ プログラム](https://docs.microsoft.com/en-us/windows/uwp/xbox-live/get-started-with-creators/get-started-with-xbox-live-creators)を利用すると、UWP ゲーム開発者はだれでも、PC と Xbox One の両方で Xbox Live 対応ゲームを開発して公開できます。</span><span class="sxs-lookup"><span data-stu-id="502d5-136">With the [Xbox Live Creators Program](https://docs.microsoft.com/en-us/windows/uwp/xbox-live/get-started-with-creators/get-started-with-xbox-live-creators), any UWP game developer can develop and publish an Xbox Live-enabled game on both the PC and Xbox One.</span></span>

<span data-ttu-id="502d5-137">Xbox Live 開発者向けに提供されているプログラムと機能については、「[Xbox Live 開発者プログラムの概要](https://docs.microsoft.com/en-us/windows/uwp/xbox-live/developer-program-overview)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="502d5-137">See the [Xbox Live developer program overview](https://docs.microsoft.com/en-us/windows/uwp/xbox-live/developer-program-overview) for information about the programs and features available to Xbox Live developers.</span></span>

## <a name="videos"></a><span data-ttu-id="502d5-138">ビデオ</span><span class="sxs-lookup"><span data-stu-id="502d5-138">Videos</span></span>

### <a name="mixed-reality"></a><span data-ttu-id="502d5-139">Mixed Reality</span><span class="sxs-lookup"><span data-stu-id="502d5-139">Mixed Reality</span></span>

<span data-ttu-id="502d5-140">[Microsoft HoloLens Course 250](https://developer.microsoft.com/en-us/windows/mixed-reality/mixed_reality_250) 向けに一連のチュートリアル ビデオが公開されました。</span><span class="sxs-lookup"><span data-stu-id="502d5-140">A series of new tutorial videos have been released for [Microsoft HoloLens Course 250](https://developer.microsoft.com/en-us/windows/mixed-reality/mixed_reality_250).</span></span> <span data-ttu-id="502d5-141">既にツールをインストールしていて、Mixed Reality の開発の基本を理解している場合は、これらのビデオ コースをチェックして、Mixed Reality デバイス間で共通のエクスペリエンスを作成する方法をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="502d5-141">If you've already installed the tools and are famiilar with the basics of development for Mixed Reality, check out these video courses for information upon creating shared experiences across Mixed Reality devices.</span></span>

### <a name="narrator-and-dev-mode"></a><span data-ttu-id="502d5-142">ナレーターと開発者モード</span><span class="sxs-lookup"><span data-stu-id="502d5-142">Narrator and Dev Mode</span></span>

<span data-ttu-id="502d5-143">[ナレーター](https://support.microsoft.com/help/22798/windows-10-narrator-get-started)を使うと、アプリの読み上げをテストできます。</span><span class="sxs-lookup"><span data-stu-id="502d5-143">You might already know that you can use [Narrator](https://support.microsoft.com/help/22798/windows-10-narrator-get-started) to test the screen reading experience of your app.</span></span> <span data-ttu-id="502d5-144">ナレーターには開発者モードもあり、このモードでは、ナレーターに公開されている情報が視覚的にわかりやすく表示されます。</span><span class="sxs-lookup"><span data-stu-id="502d5-144">But Narrator also features a developer mode, which gives you a good visual representation of the information exposed to it.</span></span> <span data-ttu-id="502d5-145">[ビデオ](https://channel9.msdn.com/Blogs/One-Dev-Minute/Using-Narrator-and-Dev-Mode)をご覧になってから、[ナレーター開発者モード](https://channel9.msdn.com/Blogs/One-Dev-Minute/Using-Narrator-and-Dev-Mode)の詳細を確認してください。</span><span class="sxs-lookup"><span data-stu-id="502d5-145">[Watch the video](https://channel9.msdn.com/Blogs/One-Dev-Minute/Using-Narrator-and-Dev-Mode), then learn more about [Narrator developer mode](https://channel9.msdn.com/Blogs/One-Dev-Minute/Using-Narrator-and-Dev-Mode).</span></span>

### <a name="windows-template-studio"></a><span data-ttu-id="502d5-146">Windows Template Studio</span><span class="sxs-lookup"><span data-stu-id="502d5-146">Windows Template Studio</span></span>

<span data-ttu-id="502d5-147">[このビデオ](https://channel9.msdn.com/Blogs/One-Dev-Minute/Getting-Started-with-Windows-Template-Studio)では、Windows Template Studio の概要について詳しく紹介しています。</span><span class="sxs-lookup"><span data-stu-id="502d5-147">A more detailed overview of the Windows Template Studio is given in [this video](https://channel9.msdn.com/Blogs/One-Dev-Minute/Getting-Started-with-Windows-Template-Studio).</span></span> <span data-ttu-id="502d5-148">準備ができたら、[拡張機能をインストール](https://aka.ms/wtsinstall)することも、[ソース コードとドキュメントを確認](https://aka.ms/wtsinstall)することもできます。</span><span class="sxs-lookup"><span data-stu-id="502d5-148">When you're ready, [install the extension](https://aka.ms/wtsinstall) or [check out the source code and documentation](https://aka.ms/wtsinstall).</span></span>