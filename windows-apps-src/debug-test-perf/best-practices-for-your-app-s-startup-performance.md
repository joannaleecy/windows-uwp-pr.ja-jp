---
ms.assetid: 00ECF6C7-0970-4D5F-8055-47EA49F92C12
title: アプリ起動時のパフォーマンスのベスト プラクティス
description: 起動とアクティブ化を処理する方法を向上させることによって、最適な起動時間のユニバーサル Windows プラットフォーム (UWP) アプリを作成します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: e50d3613e5f7058e99f2e71ba023fb4191e5c734
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57644537"
---
# <a name="best-practices-for-your-apps-startup-performance"></a><span data-ttu-id="e2de7-104">アプリ起動時のパフォーマンスのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="e2de7-104">Best practices for your app's startup performance</span></span>


<span data-ttu-id="e2de7-105">起動とアクティブ化を処理する方法を向上させることによって、最適な起動時間のユニバーサル Windows プラットフォーム (UWP) アプリを作成します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-105">Create Universal Windows Platform (UWP) apps with optimal startup times by improving the way you handle launch and activation.</span></span>

## <a name="best-practices-for-your-apps-startup-performance"></a><span data-ttu-id="e2de7-106">アプリ起動時のパフォーマンスのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="e2de7-106">Best practices for your app's startup performance</span></span>

<span data-ttu-id="e2de7-107">ユーザーがアプリを速いまたは遅いと判断する要因の 1 つとして、アプリの起動にかかる時間があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-107">In part, users perceive whether your app is fast or slow based on how long it takes to start up.</span></span> <span data-ttu-id="e2de7-108">このトピックの目的上、アプリの起動時間は、ユーザーがアプリを開始した際に始まり、ユーザーがアプリに対して何らかの意図を持つ操作を開始できるようになった時点で終わるものとします。</span><span class="sxs-lookup"><span data-stu-id="e2de7-108">For the purposes of this topic, an app's startup time begins when the user starts the app, and ends when the user can interact with the app in some meaningful way.</span></span> <span data-ttu-id="e2de7-109">このセクションでは、アプリ起動時のパフォーマンスを向上させるための推奨事項を紹介します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-109">This section provides suggestions on how to get better performance out of your app when it starts.</span></span>

### <a name="measuring-your-apps-startup-time"></a><span data-ttu-id="e2de7-110">アプリの起動時間の測定</span><span class="sxs-lookup"><span data-stu-id="e2de7-110">Measuring your app's startup time</span></span>

<span data-ttu-id="e2de7-111">アプリを数回起動してから、実際に起動時間を測定するようにしてください。</span><span class="sxs-lookup"><span data-stu-id="e2de7-111">Be sure to start your app a few times before you actually measure its startup time.</span></span> <span data-ttu-id="e2de7-112">これによって測定のベースラインが確立され、起動時間を合理的に可能な限り短縮できます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-112">This gives you a baseline for your measurement and ensures that you're measuring as reasonably short a startup time as possible.</span></span>

<span data-ttu-id="e2de7-113">UWP アプリがユーザーのコンピューターに届くまで、アプリは .NET ネイティブ ツール チェーンを使ってコンパイルされてきました。</span><span class="sxs-lookup"><span data-stu-id="e2de7-113">By the time your UWP app arrives on your customers' computers, your app has been compiled with the .NET Native toolchain.</span></span> <span data-ttu-id="e2de7-114">.NET ネイティブは、MSIL をネイティブに実行可能なマシン コードに変換する事前コンパイル テクノロジです。</span><span class="sxs-lookup"><span data-stu-id="e2de7-114">.NET Native is an ahead-of-time compilation technology that converts MSIL into natively-runnable machine code.</span></span> <span data-ttu-id="e2de7-115">.NET ネイティブ アプリは、MSIL アプリに比べて、すばやく起動し、メモリ使用量やバッテリ使用量は少なくなります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-115">.NET Native apps start faster, use less memory, and use less battery than their MSIL counterparts.</span></span> <span data-ttu-id="e2de7-116">.NET ネイティブを使ってビルドされたアプリケーションはカスタム ランタイムおよびあらゆるデバイスで実行できる新しい集約型の .NET Core にリンクされるため、インボックスの .NET の実装に依存しません。</span><span class="sxs-lookup"><span data-stu-id="e2de7-116">Applications built with .NET Native statically link in a custom runtime and the new converged .NET Core that can run on all devices, so they don’t depend on the in-box .NET implementation.</span></span> <span data-ttu-id="e2de7-117">開発コンピューターで、既定では、アプリを "リリース" モードでビルドしている場合、アプリは .NET ネイティブを使用し、"デバッグ" モードでビルドしている場合、アプリは CoreCLR を使用します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-117">On your development machine, by default your app uses .NET Native if you’re building it in “Release” mode, and it uses CoreCLR if you’re building it in “Debug” mode.</span></span> <span data-ttu-id="e2de7-118">Visual Studio では、[プロパティ] の [ビルド] ページ (C# の場合) または [マイ プロジェクト] の [コンパイル] -> [詳細設定] (VB の場合) でこれを構成できます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-118">You can configure this in Visual Studio from the Build page in “Properties” (C#) or Compile->Advanced in "My Project" (VB).</span></span> <span data-ttu-id="e2de7-119">[.NET ネイティブ ツール チェーンでコンパイルする] というチェック ボックスを探します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-119">Look for a checkbox that says “Compile with .NET Native Toolchain”.</span></span>

<span data-ttu-id="e2de7-120">当然、エンド ユーザーが一般的に経験する起動時間を測定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-120">Of course, you should take measurements that are representative of what the end user will experience.</span></span> <span data-ttu-id="e2de7-121">そのため、開発コンピューターでアプリをネイティブ コードにコンパイルしていることを確認していない場合は、起動時間を測定する前に、ネイティブ イメージ ジェネレーター (Ngen.exe) ツールを実行してアプリをプリコンパイルすることができます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-121">So, if you're not sure you're compiling your app to native code on your development machine, you could run the Native Image Generator (Ngen.exe) tool to precompile your app before you measure its startup time.</span></span>

<span data-ttu-id="e2de7-122">次の手順では、Ngen.exe を実行してアプリをプリコンパイルする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-122">The following procedure describes how to run Ngen.exe to precompile your app.</span></span>

<span data-ttu-id="e2de7-123">**Ngen.exe を実行するには**</span><span class="sxs-lookup"><span data-stu-id="e2de7-123">**To run Ngen.exe**</span></span>

1.  <span data-ttu-id="e2de7-124">少なくとも 1 回アプリを実行して、Ngen.exe にアプリを検出させます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-124">Run your app at least one time to ensure that Ngen.exe detects it.</span></span>
2.  <span data-ttu-id="e2de7-125">次のいずれかの方法で**タスク スケジューラ**を開きます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-125">Open the **Task Scheduler** by doing one of the following:</span></span>
    -   <span data-ttu-id="e2de7-126">スタート画面で「タスク スケジューラ」を検索します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-126">Search for "Task Scheduler" from the start screen.</span></span>
    -   <span data-ttu-id="e2de7-127">taskschd.msc を実行します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-127">Run "taskschd.msc."</span></span>
3.  <span data-ttu-id="e2de7-128">**タスク スケジューラ**の左ウィンドウで **[タスク スケジューラ ライブラリ]** を展開します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-128">In the left-hand pane of **Task Scheduler**, expand **Task Scheduler Library**.</span></span>
4.  <span data-ttu-id="e2de7-129">**[Microsoft]** を展開します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-129">Expand **Microsoft.**</span></span>
5.  <span data-ttu-id="e2de7-130">**[Windows]** を展開します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-130">Expand **Windows.**</span></span>
6.  <span data-ttu-id="e2de7-131">**[.NET Framework]** を展開します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-131">Select **.NET Framework**.</span></span>
7.  <span data-ttu-id="e2de7-132">タスクの一覧から **[.NET Framework NGEN 4.x]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-132">Select **.NET Framework NGEN 4.x** from the task list.</span></span>

    <span data-ttu-id="e2de7-133">64 ビット コンピューターを使っている場合は、**[.NET Framework NGEN v4.x 64]** も表示されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-133">If you are using a 64-bit computer, there is also a **.NET Framework NGEN v4.x 64**.</span></span> <span data-ttu-id="e2de7-134">64 ビット アプリを開発している場合は、**[NET Framework NGEN v4.x 64]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-134">If you are building a 64-bit app, select .**NET Framework NGEN v4.x 64**.</span></span>

8.  <span data-ttu-id="e2de7-135">**[操作]** メニューの **[実行]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="e2de7-135">From the **Action** menu, click **Run**.</span></span>

<span data-ttu-id="e2de7-136">Ngen.exe は、使用されたことがありネイティブ イメージを持たない、コンピューター上のすべてのアプリをプリコンパイルします。</span><span class="sxs-lookup"><span data-stu-id="e2de7-136">Ngen.exe precompiles all the apps on the machine that have been used and do not have native images.</span></span> <span data-ttu-id="e2de7-137">プリコンパイルが必要なアプリが多い場合には時間がかかりますが、その後の実行時間が大幅に高速化されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-137">If there are a lot of apps that need to be precompiled, this can take a long time, but subsequent runs are much faster.</span></span>

<span data-ttu-id="e2de7-138">アプリが再コンパイルされると、ネイティブ イメージは使われなくなります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-138">When you recompile your app, the native image is no longer used.</span></span> <span data-ttu-id="e2de7-139">一方、アプリをジャスト イン タイムでコンパイルする場合は、アプリは実行時にコンパイルされます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-139">Instead, the app is just-in-time compiled, which means that it is compiled as the app runs.</span></span> <span data-ttu-id="e2de7-140">新しいネイティブ イメージを取得するためには Ngen.exe をもう一度実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-140">You must rerun Ngen.exe to get a new native image.</span></span>

### <a name="defer-work-as-long-as-possible"></a><span data-ttu-id="e2de7-141">可能な限りの処理の遅延</span><span class="sxs-lookup"><span data-stu-id="e2de7-141">Defer work as long as possible</span></span>

<span data-ttu-id="e2de7-142">アプリの起動時間を短縮するには、ユーザーがアプリの操作を開始するために絶対に必要な処理だけを実行します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-142">To improve your app's startup time, do only the work that absolutely needs to be done to let the user start interacting with the app.</span></span> <span data-ttu-id="e2de7-143">これが特に有効なのは、追加のアセンブリの読み込みを遅延できる場合です。</span><span class="sxs-lookup"><span data-stu-id="e2de7-143">This can be especially beneficial if you can delay loading additional assemblies.</span></span> <span data-ttu-id="e2de7-144">共通言語ランタイムを最初に使用する際に、アセンブリが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-144">The common language runtime loads an assembly the first time it is used.</span></span> <span data-ttu-id="e2de7-145">ここで読み込まれるアセンブリの数を最小化できれば、アプリの起動時間とメモリ消費を改善できる場合があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-145">If you can minimize the number of assemblies that are loaded, you might be able to improve your app's startup time and its memory consumption.</span></span>

### <a name="do-long-running-work-independently"></a><span data-ttu-id="e2de7-146">長時間の処理の個別実行</span><span class="sxs-lookup"><span data-stu-id="e2de7-146">Do long-running work independently</span></span>

<span data-ttu-id="e2de7-147">アプリが部分的に機能していない場合でも、アプリで操作を受け付けることができます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-147">Your app can be interactive even though there are parts of the app that aren't fully functional.</span></span> <span data-ttu-id="e2de7-148">たとえば、アプリが表示するデータの取得に時間がかかっている場合に、データを非同期で取得することによって、そのコードをアプリの起動コードとは別に実行できます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-148">For example, if your app displays data that takes a while to retrieve, you can make that code execute independently of the app's startup code by retrieving the data asynchronously.</span></span> <span data-ttu-id="e2de7-149">データが利用できる状態であれば、アプリのユーザー インターフェイスにデータを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-149">When the data is available, populate the app's user interface with the data.</span></span>

<span data-ttu-id="e2de7-150">データを取得するユニバーサル Windows プラットフォーム (UWP) API の多くは非同期であるため、その状態でも、ほとんどの場合はデータが非同期で取得されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-150">Many of the Universal Windows Platform (UWP) APIs that retrieve data are asynchronous, so you will probably be retrieving data asynchronously anyway.</span></span> <span data-ttu-id="e2de7-151">非同期 API について詳しくは、「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/Mt187337)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e2de7-151">For more info about asynchronous APIs, see [Call asynchronous APIs in C# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/Mt187337).</span></span> <span data-ttu-id="e2de7-152">非同期 API を使わない処理を実行する場合、Task クラスを使って長時間の処理を実行することで、ユーザーによるアプリの操作がブロックされないようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-152">If you do work that doesn't use asynchronous APIs, you can use the Task class to do long running work so that you don't block the user from interacting with the app.</span></span> <span data-ttu-id="e2de7-153">これによってデータの読み込み中もアプリの応答性が維持されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-153">This will keep your app responsive to the user while the data loads.</span></span>

<span data-ttu-id="e2de7-154">アプリによる UI の一部の読み込みで特に長い時間がかかっている場合、ユーザーにアプリが処理中であることを通知する "最新データの取得中" などの文字列を該当する領域に追加することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="e2de7-154">If your app takes an especially long time to load part of its UI, consider adding a string in that area that says something like, "Getting latest data," so that your users know that the app is still processing.</span></span>

## <a name="minimize-startup-time"></a><span data-ttu-id="e2de7-155">起動時間の最小化</span><span class="sxs-lookup"><span data-stu-id="e2de7-155">Minimize startup time</span></span>

<span data-ttu-id="e2de7-156">非常にシンプルなアプリを除くほとんどのアプリでは、アクティブ化の際に、リソースを読み込む、XAML を解析する、データ構造をセットアップする、ロジックを実行するという一連の処理に、ユーザーが気付くレベルの時間が必要です。</span><span class="sxs-lookup"><span data-stu-id="e2de7-156">All but the simplest apps require a perceivable amount of time to load resources, parse XAML, set up data structures, and run logic at activation.</span></span> <span data-ttu-id="e2de7-157">ここでは、アクティブ化のプロセスを 3 つのフェーズに分けて見ていきます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-157">Here, we analyze the process of activation by breaking it into three phases.</span></span> <span data-ttu-id="e2de7-158">また、各フェーズにかかる時間を短縮するためのヒントのほか、アプリの起動の各フェーズを調整し、ユーザーに受け入れられるようにする方法も紹介します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-158">We also provide tips for reducing the time spent in each phase, and techniques for making each phase of your app's startup more palatable to the user.</span></span>

<span data-ttu-id="e2de7-159">アクティブ化期間とは、ユーザーがアプリを起動してからアプリが機能するまでの時間のことです。</span><span class="sxs-lookup"><span data-stu-id="e2de7-159">The activation period is the time between the moment a user starts the app and the moment the app is functional.</span></span> <span data-ttu-id="e2de7-160">これは、ユーザーがアプリから受ける第一印象となるため、重要な時間です。</span><span class="sxs-lookup"><span data-stu-id="e2de7-160">This is a critical time because it’s a user’s first impression of your app.</span></span> <span data-ttu-id="e2de7-161">ユーザーは、システムやアプリから途切れることなく即座にフィードバックが返ってくることを求めています。</span><span class="sxs-lookup"><span data-stu-id="e2de7-161">They expect instant and continuous feedback from the system and apps.</span></span> <span data-ttu-id="e2de7-162">アプリの起動が遅いと、システムやアプリが壊れているか、設計が不完全と受け取られます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-162">The system and the app are perceived to be broken or poorly designed when apps don't start quickly.</span></span> <span data-ttu-id="e2de7-163">そのうえ、アプリのアクティブ化に時間がかかりすぎると、プロセス有効期間マネージャー (PLM) によってアプリが強制終了されることや、ユーザーがアプリをアンインストールすることさえあります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-163">Even worse, if an app takes too long to activate, the Process Lifetime Manager (PLM) might kill it, or the user might uninstall it.</span></span>

### <a name="introduction-to-the-stages-of-startup"></a><span data-ttu-id="e2de7-164">起動の各段階の概要</span><span class="sxs-lookup"><span data-stu-id="e2de7-164">Introduction to the stages of startup</span></span>

<span data-ttu-id="e2de7-165">起動には、多くの移動要素があり、最適なユーザー エクスペリエンスのためにそのすべてを正しく調整する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-165">Startup involves a number of moving pieces, and all of them need to be correctly coordinated for the best user experience.</span></span> <span data-ttu-id="e2de7-166">次の手順は、ユーザーがアプリのタイルをクリックしてから、アプリケーションのコンテンツが表示されるまでの間に発生します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-166">The following steps occur between your user clicking on your app tile and the application content being shown.</span></span>

-   <span data-ttu-id="e2de7-167">Windows シェルがプロセスを開始し、Main が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-167">The Windows shell starts the process and Main is called.</span></span>
-   <span data-ttu-id="e2de7-168">Application オブジェクトが作成されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-168">The Application object is created.</span></span>
    -   <span data-ttu-id="e2de7-169">(プロジェクト テンプレート) コンストラクターが InitializeComponent を呼び出し、これにより App.xaml が解析され、オブジェクトが作成されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-169">(Project template) Constructor calls InitializeComponent, which causes App.xaml to be parsed and objects created.</span></span>
-   <span data-ttu-id="e2de7-170">Application.OnLaunched イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-170">Application.OnLaunched event is raised.</span></span>
    -   <span data-ttu-id="e2de7-171">(ProjectTemplate) アプリ コードがフレームを作成し、MainPage に移動します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-171">(ProjectTemplate) App code creates a Frame and navigates to MainPage.</span></span>
    -   <span data-ttu-id="e2de7-172">(ProjectTemplate) メインページのコンストラクターが InitializeComponent を呼び出し、これにより MainPage.xaml が解析され、オブジェクトが作成されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-172">(ProjectTemplate) Mainpage constructor calls InitializeComponent which causes MainPage.xaml to be parsed and objects created.</span></span>
    -   <span data-ttu-id="e2de7-173">ProjectTemplate) Window.Current.Activate() が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-173">ProjectTemplate) Window.Current.Activate() is called.</span></span>
-   <span data-ttu-id="e2de7-174">XAML プラットフォームが、測定と配置を含むレイアウト パスを実行します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-174">XAML Platform runs the Layout pass including Measure & Arrange.</span></span>
    -   <span data-ttu-id="e2de7-175">ApplyTemplate によって、各コントロールについてコントロール テンプレートのコンテンツが作成されます。これは、通常、起動のレイアウトの時間の大部分を占めます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-175">ApplyTemplate will cause control template content to be created for each control, which is typically the bulk of Layout time for startup.</span></span>
-   <span data-ttu-id="e2de7-176">Render が呼び出されて、すべてのウィンドウのコンテンツの視覚効果が作成されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-176">Render is called to create visuals for all the window contents.</span></span>
-   <span data-ttu-id="e2de7-177">デスクトップ ウィンドウ マネージャー (DWM) にフレームが表示されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-177">Frame is presented to the Desktop Windows Manager (DWM).</span></span>

### <a name="do-less-in-your-startup-path"></a><span data-ttu-id="e2de7-178">起動パスでの処理を少なくする</span><span class="sxs-lookup"><span data-stu-id="e2de7-178">Do less in your Startup path</span></span>

<span data-ttu-id="e2de7-179">起動コード パスには、最初のフレームで不要なものは含めないでください。</span><span class="sxs-lookup"><span data-stu-id="e2de7-179">Keep your startup code path free from anything that is not needed for your first frame.</span></span>

-   <span data-ttu-id="e2de7-180">最初のフレームで不要なコントロールが含まれているユーザー dll を使っている場合は、読み込みを遅らせることを検討します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-180">If you have user dlls containing controls that are not needed during first frame, consider delay loading them.</span></span>
-   <span data-ttu-id="e2de7-181">UI の一部をクラウドからデータに依存している場合は、その UI を分割します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-181">If you have a portion of your UI dependent on data from the cloud, then split that UI.</span></span> <span data-ttu-id="e2de7-182">最初に、クラウド データに依存しない UI を表示し、非同期的にクラウドに依存する UI を表示します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-182">First, bring up the UI that is not dependent on cloud data and asynchronously bring up the cloud-dependent UI.</span></span> <span data-ttu-id="e2de7-183">アプリケーションがオフラインで動作したり、低速ネットワーク接続に影響されないようにするために、データをローカルにキャッシュすることも検討します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-183">You should also consider caching data locally so that the application will work offline or not be affected by slow network connectivity.</span></span>
-   <span data-ttu-id="e2de7-184">UI がデータを待機している場合は、進行状況 UI を表示します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-184">Show progress UI if your UI is waiting for data.</span></span>
-   <span data-ttu-id="e2de7-185">大量の構成ファイルの解析やコードにより動的に生成される UI が含まれているアプリの設計には注意してください。</span><span class="sxs-lookup"><span data-stu-id="e2de7-185">Be cautious of app designs that involve a lot of parsing of configuration files, or UI that is dynamically generated by code.</span></span>

### <a name="reduce-element-count"></a><span data-ttu-id="e2de7-186">要素数の削減</span><span class="sxs-lookup"><span data-stu-id="e2de7-186">Reduce element count</span></span>

<span data-ttu-id="e2de7-187">XAML アプリの起動時のパフォーマンスは、起動時に作成する要素の数に直接関連しています。</span><span class="sxs-lookup"><span data-stu-id="e2de7-187">Startup performance in a XAML app is directly correlated to the number of elements you create during startup.</span></span> <span data-ttu-id="e2de7-188">作成する要素が少ないほど、アプリの起動時間は短くなります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-188">The fewer elements you create, the less time your app will take to start up.</span></span> <span data-ttu-id="e2de7-189">大まかなベンチマークとしては、各要素の作成に 1 ミリ秒かかることを考慮します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-189">As a rough benchmark, consider each element to take 1ms to create.</span></span>

-   <span data-ttu-id="e2de7-190">項目コントロールで使用されるテンプレートは、何度も繰り返されるため、最も大きな影響を受けます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-190">Templates used in items controls can have the biggest impact, as they are repeated multiple times.</span></span> <span data-ttu-id="e2de7-191">「[ListView と GridView の UI の最適化](optimize-gridview-and-listview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e2de7-191">See [ListView and GridView UI optimization](optimize-gridview-and-listview.md).</span></span>
-   <span data-ttu-id="e2de7-192">UserControl とコントロール テンプレートが展開されるため、これらも考慮する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-192">UserControls and control templates will be expanded, so those should also be taken into account.</span></span>
-   <span data-ttu-id="e2de7-193">画面に表示されない任意の XAML を作成する場合、XAML のそれらの部分を起動時に作成する必要があるかどうかを判断する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-193">If you create any XAML that does not appear on the screen, then you should justify whether those pieces of XAML should be created during your startup.</span></span>

<span data-ttu-id="e2de7-194">[Visual Studio のライブ ビジュアル ツリー](https://blogs.msdn.com/b/visualstudio/archive/2015/02/24/introducing-the-ui-debugging-tools-for-xaml.aspx) には、ツリー内の各ノードの子要素数が示されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-194">The [Visual Studio Live Visual Tree](https://blogs.msdn.com/b/visualstudio/archive/2015/02/24/introducing-the-ui-debugging-tools-for-xaml.aspx) window shows the child element counts for each node in the tree.</span></span>

![ライブ ビジュアル ツリー。](images/live-visual-tree.png)

<span data-ttu-id="e2de7-196">**延期を使用します**。</span><span class="sxs-lookup"><span data-stu-id="e2de7-196">**Use deferral**.</span></span> <span data-ttu-id="e2de7-197">要素を折りたたむか、不透明度を 0 に設定すると、要素は作成されなくなります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-197">Collapsing an element, or setting its opacity to 0, will not prevent the element from being created.</span></span> <span data-ttu-id="e2de7-198">x:Load または x:DeferLoadStrategy を使って、UI の要素の読み込みを遅らせて、必要に応じて読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-198">Using x:Load or x:DeferLoadStrategy, you can delay the loading of a piece of UI, and load it when needed.</span></span> <span data-ttu-id="e2de7-199">これは、起動画面に表示されない UI の処理を遅延させ、必要に応じて読み込んだり、遅延させた一連のロジックの一部として読み込む場合に適した方法です。</span><span class="sxs-lookup"><span data-stu-id="e2de7-199">This is good way to delay processing UI that is not visible during the startup screen, so that you can load it when needed, or as part of a set of delayed logic.</span></span> <span data-ttu-id="e2de7-200">読み込みをトリガーするために必要なことは、要素の FindName を呼び出すことだけです。</span><span class="sxs-lookup"><span data-stu-id="e2de7-200">To trigger the loading, you need only call FindName for the element.</span></span> <span data-ttu-id="e2de7-201">詳しい説明と例については、「[x:Load 属性](../xaml-platform/x-load-attribute.md)」と「[x:DeferLoadStrategy 属性](https://msdn.microsoft.com/library/windows/apps/Mt204785)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e2de7-201">For an example and more information, see [x:Load attribute](../xaml-platform/x-load-attribute.md) and [x:DeferLoadStrategy attribute](https://msdn.microsoft.com/library/windows/apps/Mt204785).</span></span>

<span data-ttu-id="e2de7-202">**仮想化**。</span><span class="sxs-lookup"><span data-stu-id="e2de7-202">**Virtualization**.</span></span> <span data-ttu-id="e2de7-203">UI に一覧またはリピーター コンテンツがある場合、UI の仮想化を使うことを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e2de7-203">If you have list or repeater content in your UI then it’s highly advised that you use UI virtualization.</span></span> <span data-ttu-id="e2de7-204">一覧の UI が仮想化されていない場合、すべての要素を作成するコストを前払いすることになり、起動が遅くなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-204">If list UI is not virtualized then you are paying the cost of creating all the elements up front, and that can slow down your startup.</span></span> <span data-ttu-id="e2de7-205">「[ListView と GridView の UI の最適化](optimize-gridview-and-listview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e2de7-205">See [ListView and GridView UI optimization](optimize-gridview-and-listview.md).</span></span>

<span data-ttu-id="e2de7-206">アプリケーションのパフォーマンスには、生のパフォーマンスだけでなく、印象も関連します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-206">Application performance is not only about raw performance, it’s also about perception.</span></span> <span data-ttu-id="e2de7-207">視覚的側面が最初に実行されるように処理の順序を変更すると、ユーザーにアプリケーションが高速であるという印象を与えます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-207">Changing the order of operations so that visual aspects occur first will commonly make the user feel like the application is faster.</span></span> <span data-ttu-id="e2de7-208">ユーザーは、画面にコンテンツが表示されると、アプリケーションが読み込まれたと見なします。</span><span class="sxs-lookup"><span data-stu-id="e2de7-208">Users will consider the application loaded when the content is on the screen.</span></span> <span data-ttu-id="e2de7-209">一般的には、アプリケーションは起動処理の一環として複数の処理を実行する必要がありますが、そのすべてが UI を表示する必要はないため、そのような処理は遅延させたり、UI よりも優先順位を下げたりする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-209">Commonly, applications need to do multiple things as part of the startup, and not all of that is required to bring up the UI, so those should be delayed or prioritized lower than the UI.</span></span>

<span data-ttu-id="e2de7-210">このトピックでは、アニメーション/テレビに由来する "最初のフレーム" について説明します。これは、エンド ユーザーに対してコンテンツが表示されるまでの時間を測定する方法です。</span><span class="sxs-lookup"><span data-stu-id="e2de7-210">This topic talks about the “first frame” which comes from animation/TV, and is a measure of how long until content is seen by the end user.</span></span>

### <a name="improve-startup-perception"></a><span data-ttu-id="e2de7-211">起動時の印象の改善</span><span class="sxs-lookup"><span data-stu-id="e2de7-211">Improve startup perception</span></span>

<span data-ttu-id="e2de7-212">それでは、簡単なオンライン ゲームの例を使って、起動の各フェーズを示した後、プロセス全体を通じてユーザーにフィードバックを返すさまざまな手法を紹介します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-212">Let’s use the example of a simple online game to identify each phase of startup and different techniques to give the user feedback throughout the process.</span></span> <span data-ttu-id="e2de7-213">この例の場合、アクティブ化の最初のフェーズは、ユーザーがゲームのタイルをタップしてからゲームがコードの実行を開始するまでの時間になります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-213">For this example, the first phase of activation is the time between the user tapping the game’s tile and the game starting to run its code.</span></span> <span data-ttu-id="e2de7-214">この間、システムには、正しいゲームが起動したことを示すためにユーザーに表示するコンテンツがありません。</span><span class="sxs-lookup"><span data-stu-id="e2de7-214">During this time, the system doesn’t have any content to display to the user to even indicate that the correct game has started.</span></span> <span data-ttu-id="e2de7-215">ただし、スプラッシュ画面を指定することによって、このコンテンツをシステムに提供できます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-215">But providing a splash screen gives that content to the system.</span></span> <span data-ttu-id="e2de7-216">次に、ゲームがコードの実行を開始すると、動かないスプラッシュ画面をアプリ独自の UI に置き換えて、アクティブ化の最初のフェーズが完了したことをユーザーに示します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-216">The game then informs the user that the first phase of activation has completed by replacing the static splash screen with its own UI when it begins running code.</span></span>

<span data-ttu-id="e2de7-217">アクティブ化の 2 番目のフェーズでは、ゲームにとって重要な構造の作成と初期化を行います。</span><span class="sxs-lookup"><span data-stu-id="e2de7-217">The second phase of activation encompasses creating and initializing structures critical for the game.</span></span> <span data-ttu-id="e2de7-218">アクティブ化の最初のフェーズの後に、利用できるデータを使って最初の UI をすばやく作成できれば、2 番目のフェーズは短時間で終わり、UI をすぐに表示できます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-218">If an app can quickly create its initial UI with the data available after the first phase of activation, then the second phase is trivial and you can display the UI immediately.</span></span> <span data-ttu-id="e2de7-219">それができない場合は、初期化中に読み込みページを表示することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e2de7-219">Otherwise we recommend that the app display a loading page while it is initialized.</span></span>

<span data-ttu-id="e2de7-220">読み込みページはどのようなものでもかまいません。単純に進行状況バーや進行状況リングを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-220">What the loading page looks like is up to you and it can be as simple as displaying a progress bar or a progress ring.</span></span> <span data-ttu-id="e2de7-221">重要な点は、アプリがタスクを実行していて、まだ応答できないことを示すことです。</span><span class="sxs-lookup"><span data-stu-id="e2de7-221">The key point is that the app indicates that it is performing tasks before becoming responsive.</span></span> <span data-ttu-id="e2de7-222">ゲームの場合は、初期画面を表示することがありますが、その UI のために画像やサウンドをディスクからメモリに読み込む必要があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-222">In the case of the game, it would like to display its initial screen but that UI requires that some images and sounds be loaded from disk into memory.</span></span> <span data-ttu-id="e2de7-223">これらのタスクには数秒かかるため、スプラッシュ画面を、ゲームのテーマに沿った簡単なアニメーションを表示する読み込みページに置き換えて、ユーザーにアプリの情報を提供し続けます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-223">These tasks take a couple of seconds, so the app keeps the user informed by replacing the splash screen with a loading page, which shows a simple animation related to the theme of the game.</span></span>

<span data-ttu-id="e2de7-224">読み込みページを置き換える対話型 UI を作成するための最小限の情報が準備できると、3 番目のフェーズが開始します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-224">The third stage begins after the game has a minimal set of info to create an interactive UI, which replaces the loading page.</span></span> <span data-ttu-id="e2de7-225">この時点でオンライン ゲームが使うことができる情報は、ディスクからアプリに読み込まれているコンテンツだけです。</span><span class="sxs-lookup"><span data-stu-id="e2de7-225">At this point the only info available to the online game is the content that the app loaded from disk.</span></span> <span data-ttu-id="e2de7-226">対話型 UI を作成できるだけの十分なコンテンツをゲームに組み込むこともできますが、これはオンライン ゲームであるため、インターネットに接続して追加情報をダウンロードするまで機能しません。</span><span class="sxs-lookup"><span data-stu-id="e2de7-226">The game can ship with enough content to create an interactive UI; but because it’s an online game it won’t be functional until it connects to the internet and downloads some additional info.</span></span> <span data-ttu-id="e2de7-227">機能するために必要なすべての情報が準備できるまでの間、ユーザーは UI を操作できますが、Web からの追加データを必要とする機能については、コンテンツがまだ読み込み中であることを示すフィードバックを返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-227">Until it has all the info it needs to be functional, the user can interact with the UI, but features that need additional data from the web should give feedback that content is still loading.</span></span> <span data-ttu-id="e2de7-228">アプリが完全に機能するまでには、多少時間がかかる場合があります。そのため、できるだけ早く機能を使えるようにすることが重要です。</span><span class="sxs-lookup"><span data-stu-id="e2de7-228">It may take some time for an app to become fully functional, so it’s important that functionality be made available as soon as possible.</span></span>

<span data-ttu-id="e2de7-229">これでオンライン ゲームにおけるアクティブ化の 3 つのフェーズを特定できたので、次にそれらを実際のコードと結び付けて考えてみましょう。</span><span class="sxs-lookup"><span data-stu-id="e2de7-229">Now that we have identified the three stages of activation in the online game, let’s tie them to actual code.</span></span>

### <a name="phase-1"></a><span data-ttu-id="e2de7-230">フェーズ 1</span><span class="sxs-lookup"><span data-stu-id="e2de7-230">Phase 1</span></span>

<span data-ttu-id="e2de7-231">アプリが起動する前に、スプラッシュ画面として表示するものをシステムに通知する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-231">Before an app starts, it needs to tell the system what it wants to display as the splash screen.</span></span> <span data-ttu-id="e2de7-232">それには、例に示すように、アプリのマニフェストの SplashScreen 要素に画像と背景色を指定します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-232">It does so by providing an image and background color to the SplashScreen element in an app’s manifest, as in the example.</span></span> <span data-ttu-id="e2de7-233">アプリがアクティブ化を開始すると、それが Windows によって表示されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-233">Windows displays this after the app begins activation.</span></span>

```xml
<Package ...>
  ...
  <Applications>
    <Application ...>
      <VisualElements ...>
        ...
        <SplashScreen Image="Images\splashscreen.png" BackgroundColor="#000000" />
        ...
      </VisualElements>
    </Application>
  </Applications>
</Package>
```

<span data-ttu-id="e2de7-234">詳しくは、「[スプラッシュ画面の追加](https://msdn.microsoft.com/library/windows/apps/Mt187306)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e2de7-234">For more info, see [Add a splash screen](https://msdn.microsoft.com/library/windows/apps/Mt187306).</span></span>

<span data-ttu-id="e2de7-235">アプリのコンストラクターを使って、アプリにとって重要なデータ構造だけを初期化します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-235">Use the app’s constructor only to initialize data structures that are critical to the app.</span></span> <span data-ttu-id="e2de7-236">コンストラクターは、最初にアプリを実行したときにのみ呼び出されます。アプリがアクティブ化されるたびに必ず呼び出されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="e2de7-236">The constructor is called only the first time the app is run and not necessarily each time the app is activated.</span></span> <span data-ttu-id="e2de7-237">たとえば、既に実行され、バックグラウンドで動いているアプリが検索コントラクトを介してアクティブ化された場合、コンストラクターは呼び出されません。</span><span class="sxs-lookup"><span data-stu-id="e2de7-237">For example, the constructor isn't called for an app that has been run, placed in the background, and then activated via the search contract.</span></span>

### <a name="phase-2"></a><span data-ttu-id="e2de7-238">フェーズ 2</span><span class="sxs-lookup"><span data-stu-id="e2de7-238">Phase 2</span></span>

<span data-ttu-id="e2de7-239">アプリはさまざまな理由でアクティブ化され、それぞれの対応を変えることが必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-239">There are a number of reasons for an app to be activated, each of which you may want to handle differently.</span></span> <span data-ttu-id="e2de7-240">[  **OnActivated**](https://msdn.microsoft.com/library/windows/apps/BR242330)、[**OnCachedFileUpdaterActivated**](https://msdn.microsoft.com/library/windows/apps/Hh701797)、[**OnFileActivated**](https://msdn.microsoft.com/library/windows/apps/BR242331)、[**OnFileOpenPickerActivated**](https://msdn.microsoft.com/library/windows/apps/Hh701799)、[**OnFileSavePickerActivated**](https://msdn.microsoft.com/library/windows/apps/Hh701801)、[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/BR242335)、[**OnSearchActivated**](https://msdn.microsoft.com/library/windows/apps/BR242336)、[**OnShareTargetActivated**](https://msdn.microsoft.com/library/windows/apps/Hh701806) メソッドを上書きして、さまざまなアクティブ化の理由に対応することができます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-240">You can override [**OnActivated**](https://msdn.microsoft.com/library/windows/apps/BR242330), [**OnCachedFileUpdaterActivated**](https://msdn.microsoft.com/library/windows/apps/Hh701797), [**OnFileActivated**](https://msdn.microsoft.com/library/windows/apps/BR242331), [**OnFileOpenPickerActivated**](https://msdn.microsoft.com/library/windows/apps/Hh701799), [**OnFileSavePickerActivated**](https://msdn.microsoft.com/library/windows/apps/Hh701801), [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/BR242335), [**OnSearchActivated**](https://msdn.microsoft.com/library/windows/apps/BR242336), and [**OnShareTargetActivated**](https://msdn.microsoft.com/library/windows/apps/Hh701806) methods to handle each reason of activation.</span></span> <span data-ttu-id="e2de7-241">アプリがこれらのメソッドで実行する必要がある作業の 1 つが UI を作成して [**Window.Content**](https://msdn.microsoft.com/library/windows/apps/BR209051) に割り当て、[**Window.Activate**](https://msdn.microsoft.com/library/windows/apps/BR209046) を呼び出すことです。</span><span class="sxs-lookup"><span data-stu-id="e2de7-241">One of the things that an app must do in these methods is create a UI, assign it to [**Window.Content**](https://msdn.microsoft.com/library/windows/apps/BR209051), and then call [**Window.Activate**](https://msdn.microsoft.com/library/windows/apps/BR209046).</span></span> <span data-ttu-id="e2de7-242">この時点で、スプラッシュ画面が、アプリによって作成された UI に置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-242">At this point the splash screen is replaced by the UI that the app created.</span></span> <span data-ttu-id="e2de7-243">ここで表示するものは、読み込み画面でも、アクティブ化時に実際の UI を作成するための十分な情報を利用できる場合は、アプリの実際の UI でもかまいません。</span><span class="sxs-lookup"><span data-stu-id="e2de7-243">This visual could either be loading screen or the app's actual UI if enough info is available at activation to create it.</span></span>

> [!div class="tabbedCodeSnippets"]
> ```csharp
> public partial class App : Application
> {
>     // A handler for regular activation.
>     async protected override void OnLaunched(LaunchActivatedEventArgs args)
>     {
>         base.OnLaunched(args);
> 
>         // Asynchronously restore state based on generic launch.
> 
>         // Create the ExtendedSplash screen which serves as a loading page while the
>         // reader downloads the section information.
>         ExtendedSplash eSplash = new ExtendedSplash();
> 
>         // Set the content of the window to the extended splash screen.
>         Window.Current.Content = eSplash;
> 
>         // Notify the Window that the process of activation is completed
>         Window.Current.Activate();
>     }
> 
>     // a different handler for activation via the search contract
>     async protected override void OnSearchActivated(SearchActivatedEventArgs args)
>     {
>         base.OnSearchActivated(args);
> 
>         // Do an asynchronous restore based on Search activation
> 
>         // the rest of the code is the same as the OnLaunched method
>     }
> }
> 
> partial class ExtendedSplash : Page
> {
>     // This is the UIELement that's the game's home page.
>     private GameHomePage homePage;
> 
>     public ExtendedSplash()
>     {
>         InitializeComponent();
>         homePage = new GameHomePage();
>     }
> 
>     // Shown for demonstration purposes only.
>     // This is typically autogenerated by Visual Studio.
>     private void InitializeComponent()
>     {
>     }
> }
> ```
> ```vb
>     Partial Public Class App
>     Inherits Application
> 
>     ' A handler for regular activation.
>     Protected Overrides Async Sub OnLaunched(ByVal args As LaunchActivatedEventArgs)
>         MyBase.OnLaunched(args)
> 
>         ' Asynchronously restore state based on generic launch.
> 
>         ' Create the ExtendedSplash screen which serves as a loading page while the
>         ' reader downloads the section information.
>         Dim eSplash As New ExtendedSplash()
> 
>         ' Set the content of the window to the extended splash screen.
>         Window.Current.Content = eSplash
> 
>         ' Notify the Window that the process of activation is completed
>         Window.Current.Activate()
>     End Sub
> 
>     ' a different handler for activation via the search contract
>     Protected Overrides Async Sub OnSearchActivated(ByVal args As SearchActivatedEventArgs)
>         MyBase.OnSearchActivated(args)
> 
>         ' Do an asynchronous restore based on Search activation
> 
>         ' the rest of the code is the same as the OnLaunched method
>     End Sub
> End Class
> 
> Partial Friend Class ExtendedSplash
>     Inherits Page
> 
>     Public Sub New()
>         InitializeComponent()
> 
>         ' Downloading the data necessary for 
>         ' initial UI on a background thread.
>         Task.Run(Sub() DownloadData())
>     End Sub
> 
>     Private Sub DownloadData()
>         ' Download data to populate the initial UI.
> 
>         ' Create the first page. 
>         Dim firstPage As New MainPage()
> 
>         ' Add the data just downloaded to the first page
> 
>         ' Replace the loading page, which is currently 
>         ' set as the window's content, with the initial UI for the app
>         Window.Current.Content = firstPage
>     End Sub
> 
>     ' Shown for demonstration purposes only.
>     ' This is typically autogenerated by Visual Studio.
>     Private Sub InitializeComponent()
>     End Sub
> End Class 
> ```

<span data-ttu-id="e2de7-244">アクティブ化ハンドラーで読み込みページを表示するアプリは、バックグラウンドで UI の作成作業を開始します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-244">Apps that display a loading page in the activation handler begin work to create the UI in the background.</span></span> <span data-ttu-id="e2de7-245">その要素が作成されると、[**FrameworkElement.Loaded**](https://msdn.microsoft.com/library/windows/apps/BR208723) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-245">After that element has been created, its [**FrameworkElement.Loaded**](https://msdn.microsoft.com/library/windows/apps/BR208723) event occurs.</span></span> <span data-ttu-id="e2de7-246">このイベント ハンドラーで、現在は読み込み画面になっているウィンドウのコンテンツを、新しく作成したホーム ページに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-246">In the event handler you replace the window's content, which is currently the loading screen, with the newly created home page.</span></span>

<span data-ttu-id="e2de7-247">初期化時間が長いアプリの場合は読み込みページを表示することが重要です。</span><span class="sxs-lookup"><span data-stu-id="e2de7-247">It’s critical that an app with an extended initialization period show a loading page.</span></span> <span data-ttu-id="e2de7-248">アクティブ化プロセスに関するユーザー フィードバックを返すこととは別に、アクティブ化プロセスの開始から 15 秒以内に [**Window.Activate**](https://msdn.microsoft.com/library/windows/apps/BR209046) が呼び出されないと、プロセスは終了されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-248">Aside from providing the user feedback about the activation process, the process will be terminated if [**Window.Activate**](https://msdn.microsoft.com/library/windows/apps/BR209046) is not called within 15 seconds of the start of the activation process.</span></span>

> [!div class="tabbedCodeSnippets"]
> ```csharp
> partial class GameHomePage : Page
> {
>     public GameHomePage()
>     {
>         InitializeComponent();
> 
>         // add a handler to be called when the home page has been loaded
>         this.Loaded += ReaderHomePageLoaded;
> 
>         // load the minimal amount of image and sound data from disk necessary to create the home page.        
>     }
>     
>     void ReaderHomePageLoaded(object sender, RoutedEventArgs e)
>     {
>         // set the content of the window to the home page now that it's ready to be displayed.
>         Window.Current.Content = this;
>     }
> 
>     // Shown for demonstration purposes only.
>     // This is typically autogenerated by Visual Studio.
>     private void InitializeComponent()
>     {
>     }
> }
> ```
> ```vb
>     Partial Friend Class GameHomePage
>     Inherits Page
> 
>     Public Sub New()
>         InitializeComponent()
> 
>         ' add a handler to be called when the home page has been loaded
>         AddHandler Me.Loaded, AddressOf ReaderHomePageLoaded
> 
>         ' load the minimal amount of image and sound data from disk necessary to create the home page.        
>     End Sub
> 
>     Private Sub ReaderHomePageLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
>         ' set the content of the window to the home page now that it's ready to be displayed.
>         Window.Current.Content = Me
>     End Sub
> 
>     ' Shown for demonstration purposes only.
>     ' This is typically autogenerated by Visual Studio.
>     Private Sub InitializeComponent()
>     End Sub
> End Class
> ```

<span data-ttu-id="e2de7-249">追加スプラッシュ画面の使用例については、[スプラッシュ画面のサンプル](https://go.microsoft.com/fwlink/p/?linkid=234889)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e2de7-249">For an example of using extended splash screens, see [Splash screen sample](https://go.microsoft.com/fwlink/p/?linkid=234889).</span></span>

### <a name="phase-3"></a><span data-ttu-id="e2de7-250">フェーズ 3</span><span class="sxs-lookup"><span data-stu-id="e2de7-250">Phase 3</span></span>

<span data-ttu-id="e2de7-251">アプリに UI が表示されたからといって、アプリが完全に使える状態になったわけではありません。</span><span class="sxs-lookup"><span data-stu-id="e2de7-251">Just because the app displayed the UI doesn't mean it is completely ready for use.</span></span> <span data-ttu-id="e2de7-252">このゲームの場合は、インターネットからのデータを必要とする機能に対してプレースホルダーを使って UI を表示します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-252">In the case of our game, the UI is displayed with placeholders for features that require data from the internet.</span></span> <span data-ttu-id="e2de7-253">この時点で、アプリが完全に機能するために必要な追加データがゲームにダウンロードされ、データを取得するたびに機能が段階的に有効になります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-253">At this point the game downloads the additional data needed to make the app fully functional and progressively enables features as data is acquired.</span></span>

<span data-ttu-id="e2de7-254">アクティブ化に必要なコンテンツの多くがアプリにパッケージされている場合があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-254">Sometimes much of the content needed for activation can be packaged with the app.</span></span> <span data-ttu-id="e2de7-255">単純なゲームなどがそうです。</span><span class="sxs-lookup"><span data-stu-id="e2de7-255">Such is the case with a simple game.</span></span> <span data-ttu-id="e2de7-256">このようにすると、アクティブ化プロセスが非常に単純になります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-256">This makes the activation process quite simple.</span></span> <span data-ttu-id="e2de7-257">しかし、多くのプログラム (ニュース リーダー、フォト ビューアーなど) では、機能するために Web から情報を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-257">But many programs (such as news readers and photo viewers) must pull information from the web to become functional.</span></span> <span data-ttu-id="e2de7-258">こうしたデータは大きく、ダウンロードするのにかなりの時間がかかる場合があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-258">This data can be large and take a fair amount of time to download.</span></span> <span data-ttu-id="e2de7-259">アプリがアクティブ化プロセス中にこうしたデータを取得する方法によっては、アプリの体感的なパフォーマンスに大きく影響することがあります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-259">How the app gets this data during the activation process can have a huge impact on the perceived performance of an app.</span></span>

<span data-ttu-id="e2de7-260">アクティブ化のフェーズ 1 または 2 で、機能するために必要なデータ セット全体をダウンロードしようとして、読み込みページ (さらに悪い場合は、スプラッシュ画面) を数分間表示すると、</span><span class="sxs-lookup"><span data-stu-id="e2de7-260">You could display a loading page, or worse, a splash screen, for minutes if an app tried to download an entire data set it needs for functionality in phase one or two of activation.</span></span> <span data-ttu-id="e2de7-261">アプリがハングしているように見えたり、システムによって終了されたりします。</span><span class="sxs-lookup"><span data-stu-id="e2de7-261">This makes an app look like it’s hung or cause it to be terminated by the system.</span></span> <span data-ttu-id="e2de7-262">フェーズ 2 ではプレースホルダー要素を使って対話型 UI を表示するための最小限のデータをダウンロードし、フェーズ 3 でプレースホルダー要素を置き換えるデータを段階的に読み込むことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e2de7-262">We recommend that an app download the minimal amount of data to show an interactive UI with placeholder elements in phase 2 and then progressively load data, which replaces the placeholder elements, in phase 3.</span></span> <span data-ttu-id="e2de7-263">データの処理について詳しくは、「[ListView と GridView の最適化](optimize-gridview-and-listview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e2de7-263">For more info on dealing with data, see [Optimize ListView and GridView](optimize-gridview-and-listview.md).</span></span>

<span data-ttu-id="e2de7-264">起動の各フェーズにどれだけ厳密に対応するかはまったくの任意ですが、できるだけ多くのフィードバック (スプラッシュ画面、読み込み画面、データの読み込み中の UI) をユーザーに提供すると、ユーザーはアプリとシステム全体が軽快だと感じます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-264">How exactly an app reacts to each phase of startup is completely up to you, but providing the user as much feedback as possible (splash screen, loading screen, UI while data loads) makes the user feel as though an app, and the system as a whole, are fast.</span></span>

### <a name="minimize-managed-assemblies-in-the-startup-path"></a><span data-ttu-id="e2de7-265">スタートアップ パス内のマネージ アセンブリを最小限に抑える</span><span class="sxs-lookup"><span data-stu-id="e2de7-265">Minimize managed assemblies in the startup path</span></span>

<span data-ttu-id="e2de7-266">多くの場合、再利用可能なコードは、プロジェクトに含まれるモジュール (DLL) の形で提供されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-266">Reusable code often comes in the form of modules (DLLs) included in a project.</span></span> <span data-ttu-id="e2de7-267">こうしたモジュールを読み込むには、ディスクにアクセスする必要があります。それには、当然負荷が発生します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-267">Loading these modules requires accessing the disk, and as you can imagine, the cost of doing so can add up.</span></span> <span data-ttu-id="e2de7-268">これにより、コールド起動に大きな影響が及びますが、ウォーム起動にも影響が及ぶ場合があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-268">This has the greatest impact on cold startup, but it can have an impact on warm startup, too.</span></span> <span data-ttu-id="e2de7-269">C# と Visual Basic の場合、CLR はアセンブリをオンデマンドで読み込むことで、その負荷の発生をできるだけ遅らせようとします。</span><span class="sxs-lookup"><span data-stu-id="e2de7-269">In the case of C# and Visual Basic, the CLR tries to delay that cost as much as possible by loading assemblies on demand.</span></span> <span data-ttu-id="e2de7-270">つまり、モジュールは実行されたメソッドによって参照されるまで読み込まれません。</span><span class="sxs-lookup"><span data-stu-id="e2de7-270">That is, the CLR doesn’t load a module until an executed method references it.</span></span> <span data-ttu-id="e2de7-271">そのため、CLR によって不要なモジュールが読み込まれないように、スタートアップ コードではアプリの起動に必要なアセンブリだけを参照するようにします。</span><span class="sxs-lookup"><span data-stu-id="e2de7-271">So, reference only assemblies that are necessary to the launch of your app in startup code so that the CLR doesn’t load unnecessary modules.</span></span> <span data-ttu-id="e2de7-272">スタートアップ パス内の使われないコード パスに不必要な参照が含まれている場合は、それらのコード パスを別のメソッドに移動すると、不必要な読み込みを回避できます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-272">If you have unused code paths in your startup path that have unnecessary references, you can move these code paths to other methods to avoid the unnecessary loads.</span></span>

<span data-ttu-id="e2de7-273">また、アプリ モジュールを結合して、モジュールの読み込みを減らすこともできます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-273">Another way to reduce module loads is to combine your app modules.</span></span> <span data-ttu-id="e2de7-274">一般的に、2 つの小さなアセンブリよりも、1 つの大きなアセンブリの方が短い時間で読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-274">Loading one large assembly typically takes less time than loading two small ones.</span></span> <span data-ttu-id="e2de7-275">常に短くなるわけではないため、開発者の生産性やコードの再利用性に実質的な違いがない場合にのみ、モジュールを結合してください。</span><span class="sxs-lookup"><span data-stu-id="e2de7-275">This is not always possible, and you should combine modules only if it doesn't make a material difference to developer productivity or code reusability.</span></span> <span data-ttu-id="e2de7-276">[PerfView](https://go.microsoft.com/fwlink/p/?linkid=251609) や [Windows Performance Analyzer (WPA)](https://msdn.microsoft.com/library/windows/apps/xaml/ff191077.aspx) などのツールを使うと、起動時に読み込まれるモジュールを調べることができます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-276">You can use tools such as [PerfView](https://go.microsoft.com/fwlink/p/?linkid=251609) or the [Windows Performance Analyzer (WPA)](https://msdn.microsoft.com/library/windows/apps/xaml/ff191077.aspx) to find out what modules are loaded on startup.</span></span>

### <a name="make-smart-web-requests"></a><span data-ttu-id="e2de7-277">効率的に Web 要求を行う</span><span class="sxs-lookup"><span data-stu-id="e2de7-277">Make smart web requests</span></span>

<span data-ttu-id="e2de7-278">XAML や画像など、アプリに重要なファイルをローカルでパッケージ化することで、アプリの読み込み時間を大幅に短縮できます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-278">You can dramatically improve the loading time of an app by packaging its contents locally, including XAML, images, and any other files important to the app.</span></span> <span data-ttu-id="e2de7-279">ネットワーク操作よりも、ディスク操作の方が処理が速くなります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-279">Disk operations are faster than network operations.</span></span> <span data-ttu-id="e2de7-280">アプリの初期化時に特定のファイルが必要な場合は、ファイルをリモート サーバーから取得する代わりに、ディスクから読み取ることで起動時間全体を短縮できます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-280">If an app needs a particular file at initialization, you can reduce the overall startup time by loading it from disk instead of retrieving it from a remote server.</span></span>

## <a name="journal-and-cache-pages-efficiently"></a><span data-ttu-id="e2de7-281">効率的なジャーナルとページのキャッシュ</span><span class="sxs-lookup"><span data-stu-id="e2de7-281">Journal and Cache Pages Efficiently</span></span>

<span data-ttu-id="e2de7-282">Frame コントロールには、ナビゲーション機能が用意されています。</span><span class="sxs-lookup"><span data-stu-id="e2de7-282">The Frame control provides navigation features.</span></span> <span data-ttu-id="e2de7-283">このコントロールは、ページへのナビゲーション (Navigate メソッド)、ナビゲーションのジャーナル (BackStack/ForwardStack プロパティ、GoForward/GoBack メソッド)、ページのキャッシュ (Page.NavigationCacheMode)、およびシリアル化のサポート (GetNavigationState メソッド) を提供します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-283">It offers navigation to a Page (Navigate method), navigation journaling (BackStack/ForwardStack properties, GoForward/GoBack method), Page caching (Page.NavigationCacheMode), and serialization support (GetNavigationState method).</span></span>

<span data-ttu-id="e2de7-284">フレームについて注意が必要なパフォーマンスは、主に、ジャーナルとページのキャッシュに関連するものです。</span><span class="sxs-lookup"><span data-stu-id="e2de7-284">The performance to be aware of with Frame is primarily around the journaling and page caching.</span></span>

<span data-ttu-id="e2de7-285">**フレーム ジャーナル**。</span><span class="sxs-lookup"><span data-stu-id="e2de7-285">**Frame journaling**.</span></span> <span data-ttu-id="e2de7-286">Frame.Navigate() を使ってページに移動すると、現在のページの PageStackEntry が Frame.BackStack コレクションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-286">When you navigate to a page with Frame.Navigate(), a PageStackEntry for the current page is added to Frame.BackStack collection.</span></span> <span data-ttu-id="e2de7-287">PageStackEntry は比較的小さいサイズですが、BackStack コレクションのサイズに組み込みの制限はありません。</span><span class="sxs-lookup"><span data-stu-id="e2de7-287">PageStackEntry is relatively small, but there’s no built-in limit to the size of the BackStack collection.</span></span> <span data-ttu-id="e2de7-288">ユーザーはループ内を移動することができ、このコレクションは無制限に増大する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-288">Potentially, a user could navigate in a loop and grow this collection indefinitely.</span></span>

<span data-ttu-id="e2de7-289">PageStackEntry には、Frame.Navigate() メソッドに渡されたパラメーターも含まれます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-289">The PageStackEntry also includes the parameter that was passed to the Frame.Navigate() method.</span></span> <span data-ttu-id="e2de7-290">Frame.GetNavigationState() メソッドを使用するために、このパラメーターをシリアル化できるプリミティブ型 (int や string など) にすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e2de7-290">It’s recommended that that parameter be a primitive serializable type (such as an int or string), in order to allow the Frame.GetNavigationState() method to work.</span></span> <span data-ttu-id="e2de7-291">ただし、このパラメーターは、大量のワーキング セットやその他のリソースの原因となるオブジェクトを参照している可能性があり、BackStack の各エントリのコストがそれだけ高くなります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-291">But that parameter could potentially reference an object that accounts for more significant amounts of working set or other resources, making each entry in the BackStack that much more expensive.</span></span> <span data-ttu-id="e2de7-292">たとえば、パラメーターとして StorageFile を使用できますが、その結果、BackStack には開いた無数のファイルが保持されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-292">For example, you could potentially use a StorageFile as a parameter, and consequently the BackStack is keeping an indefinite number of files open.</span></span>

<span data-ttu-id="e2de7-293">したがって、ナビゲーション パラメーターを小さくし、BackStack のサイズを制限することが推奨されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-293">Therefore it’s recommended to keep the navigation parameters small, and to limit the size of the BackStack.</span></span> <span data-ttu-id="e2de7-294">BackStack は、標準ベクター (C# では IList、C++/CX では Platform::Vector) であるため、エントリを削除するだけでトリミングできます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-294">The BackStack is a standard vector (IList in C#, Platform::Vector in C++/CX), and so can be trimmed simply by removing entries.</span></span>

<span data-ttu-id="e2de7-295">**ページのキャッシュ**。</span><span class="sxs-lookup"><span data-stu-id="e2de7-295">**Page caching**.</span></span> <span data-ttu-id="e2de7-296">既定では、Frame.Navigate メソッドを使ってページに移動すると、ページの新しいインスタンスがインスタンス化されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-296">By default, when you navigate to a page with the Frame.Navigate method, a new instance of the page is instantiated.</span></span> <span data-ttu-id="e2de7-297">同様に、Frame.GoBack で前のページに戻ると、前のページの新しいインスタンスが割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-297">Similarly, if you then navigate back to the previous page with Frame.GoBack, a new instance of the previous page is allocated.</span></span>

<span data-ttu-id="e2de7-298">ただし、Frame には、これらのインスタンス化を回避できる、オプションのページ キャッシュが用意されています。</span><span class="sxs-lookup"><span data-stu-id="e2de7-298">Frame, though, offers an optional page cache that can avoid these instantiations.</span></span> <span data-ttu-id="e2de7-299">ページをキャッシュに保存するには、Page.NavigationCacheMode プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="e2de7-299">To get a page put into the cache, use the Page.NavigationCacheMode property.</span></span> <span data-ttu-id="e2de7-300">このモードを Required に設定するとページは強制的にキャッシュに保存され、Enabled に設定するとページのキャッシュへの保存が許可されます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-300">Setting that mode to Required will force the page to be cached, setting it to Enabled will allow it to be cached.</span></span> <span data-ttu-id="e2de7-301">既定では、キャッシュのサイズは 10 ページですが、Frame.CacheSize プロパティを使ってオーバーライドすることができます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-301">By default the cache size is 10 pages, but this can be overridden with the Frame.CacheSize property.</span></span> <span data-ttu-id="e2de7-302">Required ページはすべてキャッシュされ、Required ページが CacheSize よりも少ない場合は、Enabled ページもキャッシュすることができます。</span><span class="sxs-lookup"><span data-stu-id="e2de7-302">All Required pages will be cached, and if there are fewer than CacheSize Required pages, Enabled pages can be cached as well.</span></span>

<span data-ttu-id="e2de7-303">ページをキャッシュすると、インスタンス化が回避され、ナビゲーションのパフォーマンスが向上することにより、パフォーマンス面のメリットとなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-303">Page caching can help performance by avoiding instantiations, and therefore improving navigation performance.</span></span> <span data-ttu-id="e2de7-304">ページのキャッシュが過剰になると、ワーキング セットに影響を及ぼすため、パフォーマンスが低下する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e2de7-304">Page caching can hurt performance by over-caching and therefore impacting working set.</span></span>

<span data-ttu-id="e2de7-305">したがって、アプリケーションで適切なページのキャッシュを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e2de7-305">Therefore it’s recommended to use page caching as appropriate for your application.</span></span> <span data-ttu-id="e2de7-306">たとえば、アプリがフレームに項目の一覧を表示する場合、項目をタップすると、アプリはフレームをその項目の詳細ページに移動します。</span><span class="sxs-lookup"><span data-stu-id="e2de7-306">For example, say you have an app that shows a list of items in a Frame, and when you tap on an item, it navigates the frame to a detail page for that item.</span></span> <span data-ttu-id="e2de7-307">この一覧ページは、キャッシュするように設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e2de7-307">The list page should probably be set to cache.</span></span> <span data-ttu-id="e2de7-308">詳細ページがすべての項目で同じである場合、このページもキャッシュすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e2de7-308">If the detail page is the same for all items, it should probably be cached as well.</span></span> <span data-ttu-id="e2de7-309">ただし、詳細ページの種類が異なる場合は、キャッシュを無効のままにしておくことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e2de7-309">But if the detail page is more heterogeneous, it might be better to leave caching off.</span></span>
