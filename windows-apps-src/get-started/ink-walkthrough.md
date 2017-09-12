---
author: kbridge
ms.assetid: 
title: "UWP アカデミー - 入力トラック - UWP アプリでインクをサポートする"
description: "UWP アカデミー。 入力トラック。 作成した UWP アプリにインクのサポートを追加するための、ステップ バイ ステップ チュートリアルです。"
keywords: "UWP アカデミー"
ms.author: kbridge
ms.date: 04/17/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: a70ac88773907edb7e5d02708be19fb9feec01a9
ms.sourcegitcommit: 7540962003b38811e6336451bb03d46538b35671
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/26/2017
---
# <a name="support-ink-in-your-uwp-app"></a><span data-ttu-id="e50b7-106">UWP アプリで手書き入力をサポートする</span><span class="sxs-lookup"><span data-stu-id="e50b7-106">Support ink in your UWP app</span></span>

![Surface ペン](images/ink/ink-hero-small.png)  
<span data-ttu-id="e50b7-108">*Surface ペン* ([Microsoft ストア](https://aka.ms/purchasesurfacepen)で購入できます)。</span><span class="sxs-lookup"><span data-stu-id="e50b7-108">*Surface Pen* (available for purchase at the [Microsoft Store](https://aka.ms/purchasesurfacepen)).</span></span>

<span data-ttu-id="e50b7-109">このチュートリアルでは、Windows Ink を使った描画と手書きをサポートする、基本的な ユニバーサル Windows プラットフォーム (UWP) アプリを作成する手順を示します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-109">This tutorial steps through how to create a basic Universal Windows Platform (UWP) app that supports writing and drawing with Windows Ink.</span></span> <span data-ttu-id="e50b7-110">使用するサンプル アプリは GitHub ([サンプル コード](#sample-code)) からダウンロードできます。このサンプル アプリのスニペットは、各手順でのさまざまな機能と関連する Windows Ink API ([Windows Ink プラットフォームのコンポーネント](#components-of-the-windows-ink-platform)をご覧ください) の使い方を示します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-110">We use snippets from a sample app, which you can download from GitHub (see [Sample code](#sample-code)), to demonstrate the various features and associated Windows Ink APIs (see [Components of the Windows Ink platform](#components-of-the-windows-ink-platform)) discussed in each step.</span></span>

<span data-ttu-id="e50b7-111">次の点を中心に説明します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-111">We focus on the following:</span></span>
* <span data-ttu-id="e50b7-112">基本的なインクのサポートを追加する</span><span class="sxs-lookup"><span data-stu-id="e50b7-112">Adding basic ink support</span></span>
* <span data-ttu-id="e50b7-113">インク ツールバーを追加する</span><span class="sxs-lookup"><span data-stu-id="e50b7-113">Adding an ink toolbar</span></span>
* <span data-ttu-id="e50b7-114">手書き認識をサポートする</span><span class="sxs-lookup"><span data-stu-id="e50b7-114">Supporting handwriting recognition</span></span>
* <span data-ttu-id="e50b7-115">基本的な図形の認識をサポートする</span><span class="sxs-lookup"><span data-stu-id="e50b7-115">Supporting basic shape recognition</span></span>
* <span data-ttu-id="e50b7-116">インクを保存して読み込む</span><span class="sxs-lookup"><span data-stu-id="e50b7-116">Saving and loading ink</span></span>

<span data-ttu-id="e50b7-117">これらの機能の実装について詳しくは「[UWP アプリでのペン操作と Windows Ink](https://docs.microsoft.com/windows/uwp/input-and-devices/pen-and-stylus-interactions)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e50b7-117">For more detail about implementing these features, see [Pen interactions and Windows Ink in UWP apps](https://docs.microsoft.com/windows/uwp/input-and-devices/pen-and-stylus-interactions).</span></span>

## <a name="introduction"></a><span data-ttu-id="e50b7-118">概要</span><span class="sxs-lookup"><span data-stu-id="e50b7-118">Introduction</span></span>

<span data-ttu-id="e50b7-119">Windows Ink を使うと、ユーザーに、ペンと紙の体験とほぼ同等のデジタル エクスペリエンスを提供できます。すばやく手書きでメモを取ったり、ホワイトボードのデモに注釈を書き込んだり、建築製図や工業図面の作成から、個人的な作品の制作まで行えます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-119">With Windows Ink, you can provide your customers with the digital equivalent of almost any pen-and-paper experience imaginable, from quick, handwritten notes and annotations to whiteboard demos, and from architectural and engineering drawings to personal masterpieces.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="e50b7-120">前提条件</span><span class="sxs-lookup"><span data-stu-id="e50b7-120">Prerequisites</span></span>

* <span data-ttu-id="e50b7-121">現在のバージョンの Windows 10 を実行するコンピューター (または仮想マシン)。</span><span class="sxs-lookup"><span data-stu-id="e50b7-121">A computer (or a virtual machine) running the current version of Windows 10</span></span>
* [<span data-ttu-id="e50b7-122">Visual Studio 2017 および RS2 SDK</span><span class="sxs-lookup"><span data-stu-id="e50b7-122">Visual Studio 2017 and the RS2 SDK</span></span>](https://developer.microsoft.com/windows/downloads)
* [<span data-ttu-id="e50b7-123">Windows 10 SDK (10.0.15063.0)</span><span class="sxs-lookup"><span data-stu-id="e50b7-123">Windows 10 SDK (10.0.15063.0)</span></span>](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk)
* <span data-ttu-id="e50b7-124">Visual Studio を使ってユニバーサル Windows プラットフォーム (UWP) アプリの開発を初めて行う場合は、このチュートリアルを開始する前に、次のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e50b7-124">If you're new to Universal Windows Platform (UWP) app development with Visual Studio, have a look through these topics before you start this tutorial:</span></span>  
    * [<span data-ttu-id="e50b7-125">準備</span><span class="sxs-lookup"><span data-stu-id="e50b7-125">Get set up</span></span>](https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up)
    * [<span data-ttu-id="e50b7-126">"Hello, world" アプリを作成する (XAML)</span><span class="sxs-lookup"><span data-stu-id="e50b7-126">Create a "Hello, world" app (XAML)</span></span>](https://docs.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)
* <span data-ttu-id="e50b7-127">**[オプション]** デジタル ペンと、そのデジタル ペンからの入力をサポートしているディスプレイを搭載したコンピューター。</span><span class="sxs-lookup"><span data-stu-id="e50b7-127">**[OPTIONAL]** A digital pen and a computer with a display that supports input from that digital pen.</span></span>  
   > [!NOTE] 
   > <span data-ttu-id="e50b7-128">Windows Ink は、マウスとタッチを使った描画をサポートします (これについては、このチュートリアルの手順 3 で説明します) が、最適なWindows Ink エクスペリエンスのためには、デジタル ペンとそのデジタル ペンからの入力をサポートしているディスプレイを備えたコンピューターの使用を推奨します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-128">While Windows Ink can support drawing with a mouse and touch (we show how to do this in Step 3 of this tutorial) for an optimal Windows Ink experience, we recommend that you have a digital pen and a computer with a display that supports input from that digital pen.</span></span>

## <a name="sample-code"></a><span data-ttu-id="e50b7-129">サンプル コード</span><span class="sxs-lookup"><span data-stu-id="e50b7-129">Sample code</span></span>
<span data-ttu-id="e50b7-130">このチュートリアル全体で、1 つサンプル インク アプリを使って概念と機能を説明します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-130">Throughout this tutorial, we use a sample ink app to demonstrate the concepts and functionality discussed.</span></span>

<span data-ttu-id="e50b7-131">この Visual Studio サンプルとソース コードは [GitHub](https://github.com/) の [windows-appsample-get-started-ink sample](https://aka.ms/appsample-ink) からダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-131">Download this Visual Studio sample and source code from [GitHub](https://github.com/) at [windows-appsample-get-started-ink sample](https://aka.ms/appsample-ink):</span></span>

1. <span data-ttu-id="e50b7-132">緑の [**Clone or download**] (複製またはダウンロード) ボタンを選択します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-132">Select the green **Clone or download** button</span></span>  
![リポジトリを複製する](images/ink/ink-clone.png)
2. <span data-ttu-id="e50b7-134">GitHub のアカウントを使っている場合には、[**Open in Visual Studio**] (Visual Studio で開く) を選択して、リポジトリをローカル コンピューターに複製できます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-134">If you have a GitHub account, you can clone the repo to your local machine by choosing **Open in Visual Studio**</span></span> 
3. <span data-ttu-id="e50b7-135">GitHub アカウントを使っていない場合、またはプロジェクトのローカル コピーのみが必要な場合には、[**Download ZIP**] (ZIP をダウンロードする) を選択します (最新の更新をダウンロードするには、定期的に確認する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="e50b7-135">If you don't have a GitHub account, or you just want a local copy of the project, choose **Download ZIP** (you'll have to check back regularly to download the latest updates)</span></span>

> [!IMPORTANT]
> <span data-ttu-id="e50b7-136">サンプル コードのほとんどの部分はコメント アウトされています。</span><span class="sxs-lookup"><span data-stu-id="e50b7-136">Most of the code in the sample is commented out.</span></span> <span data-ttu-id="e50b7-137">各手順を進めていく際に、コードの各セクションのコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-137">As we go through each step, you'll be asked to uncomment various sections of the code.</span></span> <span data-ttu-id="e50b7-138">Visual Studio では、コードの行を強調表示して Ctrl + K キーを押して Ctrl + U キーを押します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-138">In Visual Studio, just highlight the lines of code, and press CTRL-K and then CTRL-U.</span></span>

## <a name="components-of-the-windows-ink-platform"></a><span data-ttu-id="e50b7-139">Windows Ink プラットフォームのコンポーネント</span><span class="sxs-lookup"><span data-stu-id="e50b7-139">Components of the Windows Ink platform</span></span>

<span data-ttu-id="e50b7-140">これらのオブジェクトは、UWP アプリ用の手描き入力エクスペリエンスの大部分を提供します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-140">These objects provide the bulk of the inking experience for UWP apps.</span></span>

| <span data-ttu-id="e50b7-141">コンポーネント</span><span class="sxs-lookup"><span data-stu-id="e50b7-141">Component</span></span> | <span data-ttu-id="e50b7-142">説明</span><span class="sxs-lookup"><span data-stu-id="e50b7-142">Description</span></span> |
| --- | --- |
| [**<span data-ttu-id="e50b7-143">InkCanvas</span><span class="sxs-lookup"><span data-stu-id="e50b7-143">InkCanvas</span></span>**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) | <span data-ttu-id="e50b7-144">既定でペンからのすべての入力を受け取ってインク ストロークか消去ストロークとして表示する XAML UI プラットフォーム コントロールです。</span><span class="sxs-lookup"><span data-stu-id="e50b7-144">A XAML UI platform control that, by default, receives and displays all input from a pen as either an ink stroke or an erase stroke.</span></span> |
| [**<span data-ttu-id="e50b7-145">InkPresenter</span><span class="sxs-lookup"><span data-stu-id="e50b7-145">InkPresenter</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn922011) | <span data-ttu-id="e50b7-146">[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールと共にインスタンス化される分離コード オブジェクトです ([**InkCanvas.InkPresenter**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.inkcanvas#Windows_UI_Xaml_Controls_InkCanvas_InkPresenter) プロパティによって公開されます)。</span><span class="sxs-lookup"><span data-stu-id="e50b7-146">A code-behind object, instantiated along with an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) control (exposed through the [**InkCanvas.InkPresenter**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.inkcanvas#Windows_UI_Xaml_Controls_InkCanvas_InkPresenter) property).</span></span> <span data-ttu-id="e50b7-147">[**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) によって公開される既定の手描き入力機能のすべてと、追加のカスタマイズや個人用設定のための包括的な API のセットを提供します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-147">This object provides all default inking functionality exposed by the [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas), along with a comprehensive set of APIs for additional customization and personalization.</span></span> |
| [**<span data-ttu-id="e50b7-148">InkToolbar</span><span class="sxs-lookup"><span data-stu-id="e50b7-148">InkToolbar</span></span>**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) | <span data-ttu-id="e50b7-149">関連付けられた [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) のインク関連機能をアクティブ化する、カスタマイズと拡張が可能なボタンのコレクションが含まれている XAML UI プラットフォーム コントロールです。</span><span class="sxs-lookup"><span data-stu-id="e50b7-149">A XAML UI platform control containing a customizable and extensible collection of buttons that activate ink-related features in an associated [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas).</span></span> |
| [**<span data-ttu-id="e50b7-150">IInkD2DRenderer</span><span class="sxs-lookup"><span data-stu-id="e50b7-150">IInkD2DRenderer</span></span>**](https://msdn.microsoft.com/library/mt147263)<br/><span data-ttu-id="e50b7-151">この機能は、このドキュメントの対象範囲外です。詳しくは、「[複雑なインクのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=620314)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e50b7-151">We do not cover this functionality here, for more information, see the [Complex ink sample](http://go.microsoft.com/fwlink/p/?LinkID=620314).</span></span> | <span data-ttu-id="e50b7-152">既定の [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールの代わりに、ユニバーサル Windows アプリが指定した Direct2D デバイス コンテキストにインク ストロークをレンダリングできます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-152">Enables the rendering of ink strokes onto the designated Direct2D device context of a Universal Windows app, instead of the default [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) control.</span></span> |

## <a name="step-1-run-the-sample"></a><span data-ttu-id="e50b7-153">手順 1: サンプルを実行する</span><span class="sxs-lookup"><span data-stu-id="e50b7-153">Step 1: Run the sample</span></span>

<span data-ttu-id="e50b7-154">RadialController サンプル アプリをダウンロードしたら、実行できることを確認します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-154">After you've downloaded the RadialController sample app, verify that it runs:</span></span>
1. <span data-ttu-id="e50b7-155">Visual Studio でサンプル プロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-155">Open the sample project in Visual Studio.</span></span>
2. <span data-ttu-id="e50b7-156">[**ソリューション プラットフォーム**] のドロップダウンを ARM 以外の選択肢に設定します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-156">Set the **Solution Platforms** dropdown to a non-ARM selection.</span></span>
3. <span data-ttu-id="e50b7-157">F5 キーを押して、コンパイル、展開、および実行します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-157">Press F5 to compile, deploy, and run.</span></span>  

   > [!NOTE]
   > <span data-ttu-id="e50b7-158">または、[**デバッグ**] > [**デバッグの開始**] メニュー項目を選択するか、または次のように [**ローカル コンピューター**] の実行ボタンを選択することもできます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-158">Alternatively, you can select **Debug** > **Start debugging** menu item, or select the **Local Machine** Run button shown here.</span></span>
   > ![Visual Studio のプロジェクトのビルド ボタン](images/ink/ink-vsrun.png)

<span data-ttu-id="e50b7-160">アプリ ウィンドウが開き、スプラッシュ画面が数秒表示されて、次のような初期画面が表示されます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-160">The app window opens, and after a splash screen appears for a few seconds, you’ll see this initial screen.</span></span>

![空のアプリ](images/ink/ink-app-step1-empty.png)

<span data-ttu-id="e50b7-162">これでチュートリアルの残りの部分で使う、基本的な UWP アプリの準備ができました。</span><span class="sxs-lookup"><span data-stu-id="e50b7-162">Okay, we now have the basic UWP app that we’ll use throughout the rest of this tutorial.</span></span> <span data-ttu-id="e50b7-163">これ以降の手順では、インク機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-163">In the following steps, we add our ink functionality.</span></span>

## <a name="step-2-use-inkcanvas-to-support-basic-inking"></a><span data-ttu-id="e50b7-164">手順 2: InkCanvas を使って基本的な手描き入力をサポートする</span><span class="sxs-lookup"><span data-stu-id="e50b7-164">Step 2: Use InkCanvas to support basic inking</span></span>

<span data-ttu-id="e50b7-165">お気付きのように、このアプリは初期状態では、ペンを使って手描きを行うことはできません (ただし、標準のポインター デバイスとしてペンを使用してアプリを操作することはできます)。</span><span class="sxs-lookup"><span data-stu-id="e50b7-165">Perhaps you've probably already noticed that the app, in it's initial form, doesn't let you draw anything with the pen (although you can use the pen as a standard pointer device to interact with the app).</span></span> 

<span data-ttu-id="e50b7-166">この手順では、その欠点を修正します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-166">Let's fix that little shortcoming in this step.</span></span>

<span data-ttu-id="e50b7-167">基本的な手描き機能を追加するには、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) UWP プラットフォーム コントロールをアプリの適切なページに配置します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-167">To add basic inking functionality, just place an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) UWP platform control on the appropriate page in your app.</span></span>

> [!NOTE]
> <span data-ttu-id="e50b7-168">InkCanvas の[**高さ**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_Height)と[**幅**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_Width)のプロパティは、子要素のサイズを自動的に設定する要素の子である場合を除き、既定では 0 です。</span><span class="sxs-lookup"><span data-stu-id="e50b7-168">An InkCanvas has default [**Height**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_Height) and [**Width**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement#Windows_UI_Xaml_FrameworkElement_Width) properties of zero, unless it is the child of an element that automatically sizes its child elements.</span></span> 

### <a name="in-the-sample"></a><span data-ttu-id="e50b7-169">このサンプルを使って、次を行います:</span><span class="sxs-lookup"><span data-stu-id="e50b7-169">In the sample:</span></span>
1. <span data-ttu-id="e50b7-170">MainPage.xaml.cs ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-170">Open the MainPage.xaml.cs file.</span></span>
2. <span data-ttu-id="e50b7-171">この手順のタイトル ("// Step 2: Use InkCanvas to support basic inking") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-171">Find the code marked with the title of this step ("// Step 2: Use InkCanvas to support basic inking").</span></span>
3. <span data-ttu-id="e50b7-172">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-172">Uncomment the following lines.</span></span> <span data-ttu-id="e50b7-173">(これらの参照は、これ以降の手順で使用される機能に必要です。)</span><span class="sxs-lookup"><span data-stu-id="e50b7-173">(These references are required for the functionality used in the subsequent steps).</span></span>  

``` csharp
    using Windows.UI.Input.Inking;
    using Windows.UI.Input.Inking.Analysis;
    using Windows.UI.Xaml.Shapes;
    using Windows.Storage.Streams;
```

4. <span data-ttu-id="e50b7-174">MainPage.xaml ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-174">Open the MainPage.xaml file.</span></span>
5. <span data-ttu-id="e50b7-175">この手順のタイトル ("\<!-- Step 2: Basic inking with InkCanvas -->") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-175">Find the code marked with the title of this step ("\<!-- Step 2: Basic inking with InkCanvas -->").</span></span>
6. <span data-ttu-id="e50b7-176">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-176">Uncomment the following line.</span></span>  

``` xaml
    <InkCanvas x:Name="inkCanvas" />
```

<span data-ttu-id="e50b7-177">以上です。</span><span class="sxs-lookup"><span data-stu-id="e50b7-177">That's it!</span></span> 

<span data-ttu-id="e50b7-178">では、アプリを再度実行します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-178">Now run the app again.</span></span> <span data-ttu-id="e50b7-179">何でも自由に書き込んだり、自画像の絵などを描いてみてください。</span><span class="sxs-lookup"><span data-stu-id="e50b7-179">Go ahead and scribble, write your name, or (if you're holding a mirror or have a very good memory) draw your self-portrait.</span></span>

![基本的な手描き入力](images/ink/ink-app-step1-name.png)

## <a name="step-3-support-inking-with-touch-and-mouse"></a><span data-ttu-id="e50b7-181">手順 3: タッチとマウスを使って手描き入力をサポートする</span><span class="sxs-lookup"><span data-stu-id="e50b7-181">Step 3: Support inking with touch and mouse</span></span>

<span data-ttu-id="e50b7-182">お気付きのように、既定では、インクはペン入力のみをサポートします。</span><span class="sxs-lookup"><span data-stu-id="e50b7-182">You'll notice that, by default, ink is supported for pen input only.</span></span> <span data-ttu-id="e50b7-183">指、マウス、またはタッチパッドを使って描画することはできません。</span><span class="sxs-lookup"><span data-stu-id="e50b7-183">If you try to write or draw with your finger, your mouse, or your touchpad, you'll be disappointed.</span></span>

<span data-ttu-id="e50b7-184">それを可能にするには、コードの 2 行目を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e50b7-184">To turn that frown upside down , you need to add a second line of code.</span></span> <span data-ttu-id="e50b7-185">それは、[**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) を宣言した XAML ファイルのコードビハインドにあります。</span><span class="sxs-lookup"><span data-stu-id="e50b7-185">This time it’s in the code-behind for the XAML file in which you declared your [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas).</span></span> 

<span data-ttu-id="e50b7-186">この手順では、[**InkPresenter**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkpresenter) オブジェクトを説明します。このオブジェクトは [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) の手描き入力 (標準および変更) の入力、処理、レンダリングの細かい管理を提供します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-186">In this step, we introduce the [**InkPresenter**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkpresenter) object, which provides finer-grained management of the input, processing, and rendering of ink input (standard and modified) on your [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas).</span></span>

> [!NOTE]
> <span data-ttu-id="e50b7-187">標準のインク入力 (ペン先または消しゴムの先端やボタン) は、セカンダリ ハードウェア アフォーダンス (ペン バレル ボタン、マウスの右ボタン、または類似のメカニズムなど) で変更されません。</span><span class="sxs-lookup"><span data-stu-id="e50b7-187">Standard ink input (pen tip or eraser tip/button) is not modified with a secondary hardware affordance, such as a pen barrel button, right mouse button, or similar mechanism.</span></span> 

<span data-ttu-id="e50b7-188">マウスとタッチによる手描き入力を有効化するには、[**InkPresenter**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkpresenter) の [**InputDeviceTypes**](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkpresenter#Windows_UI_Input_Inking_InkPresenter_InputDeviceTypes) プロパティを、必要な [**CoreInputDeviceTypes**](https://docs.microsoft.com/uwp/api/windows.ui.core.coreinputdevicetypes) 値の組み合わせに設定します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-188">To enable mouse and touch inking, set the [**InputDeviceTypes**](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkpresenter#Windows_UI_Input_Inking_InkPresenter_InputDeviceTypes) property of the [**InkPresenter**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkpresenter) to the combination of [**CoreInputDeviceTypes**](https://docs.microsoft.com/uwp/api/windows.ui.core.coreinputdevicetypes) values that you want.</span></span>

### <a name="in-the-sample"></a><span data-ttu-id="e50b7-189">このサンプルを使って、次を行います:</span><span class="sxs-lookup"><span data-stu-id="e50b7-189">In the sample:</span></span>
1. <span data-ttu-id="e50b7-190">MainPage.xaml.cs ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-190">Open the MainPage.xaml.cs file.</span></span>
2. <span data-ttu-id="e50b7-191">この手順のタイトル ("// Step 3: Support inking with touch and mouse") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-191">Find the code marked with the title of this step ("// Step 3: Support inking with touch and mouse").</span></span>
3. <span data-ttu-id="e50b7-192">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-192">Uncomment the following lines.</span></span>  

``` csharp
    inkCanvas.InkPresenter.InputDeviceTypes =
        Windows.UI.Core.CoreInputDeviceTypes.Mouse | 
        Windows.UI.Core.CoreInputDeviceTypes.Touch | 
        Windows.UI.Core.CoreInputDeviceTypes.Pen;
```

<span data-ttu-id="e50b7-193">アプリをもう一度実行して、指を使って手描き入力ができることを確認します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-193">Run the app again and you'll find that all your finger-painting-on-a-computer-screen dreams have come true!</span></span>

> [!NOTE]
> <span data-ttu-id="e50b7-194">入力デバイスの種類を指定する場合は、特定の入力の種類のサポート (ペンを含む) を指定する必要があります。このプロパティの設定は既定の [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) 設定を上書きするためです。</span><span class="sxs-lookup"><span data-stu-id="e50b7-194">When specifying input device types, you must indicate support for each specific input type (including pen), because setting this property overrides the default [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) setting.</span></span>

## <a name="step-4-add-an-ink-toolbar"></a><span data-ttu-id="e50b7-195">手順 4: インク ツールバーを追加する</span><span class="sxs-lookup"><span data-stu-id="e50b7-195">Step 4: Add an ink toolbar</span></span>

<span data-ttu-id="e50b7-196">[**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) は、インク関連の機能を有効化するための、カスタマイズと拡張が可能なボタンのコレクションを提供する、UWP プラットフォーム コントロールです。</span><span class="sxs-lookup"><span data-stu-id="e50b7-196">The [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) is a UWP platform control that provides a customizable and extensible collection of buttons for activating ink-related features.</span></span> 

<span data-ttu-id="e50b7-197">[**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) には、既定では、ボタンの基本的なセットが含まれています。ユーザーはこれを使って、ペン、鉛筆、蛍光ペン、消しゴムをすばやく選択でき、これらはいずれもステンシル (ルーラーまたは分度器) と共に使用できます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-197">By default, the [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) includes a basic set of buttons that let users quickly select between a pen, a pencil, a highlighter, or an eraser, any of which can be used together with a stencil (ruler or protractor).</span></span> <span data-ttu-id="e50b7-198">ペン、鉛筆、および蛍光ペンのボタンは、インクの色と線のサイズを選択できるポップアップも提供します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-198">The pen, pencil, and highlighter buttons each also provide a flyout for selecting ink color and stroke size.</span></span>

<span data-ttu-id="e50b7-199">既定の [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) を手描き入力のアプリに追加するには、[**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) と同じページに配置して、2 つのコントロールを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-199">To add a default [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) to an inking app, just place it on the same page as your [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) and associate the two controls.</span></span>

### <a name="in-the-sample"></a><span data-ttu-id="e50b7-200">このサンプルを使って、次を行います:</span><span class="sxs-lookup"><span data-stu-id="e50b7-200">In the sample</span></span>
1. <span data-ttu-id="e50b7-201">MainPage.xaml ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-201">Open the MainPage.xaml file.</span></span>
2. <span data-ttu-id="e50b7-202">この手順のタイトル ("\<!-- Step 4: Add an ink toolbar -->") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-202">Find the code marked with the title of this step ("\<!-- Step 4: Add an ink toolbar -->").</span></span>
3. <span data-ttu-id="e50b7-203">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-203">Uncomment the following lines.</span></span>  

``` xaml
    <InkToolbar x:Name="inkToolbar" 
                        VerticalAlignment="Top" 
                        Margin="10,0,10,0"
                        TargetInkCanvas="{x:Bind inkCanvas}">
    </InkToolbar>
```

> [!NOTE]
> <span data-ttu-id="e50b7-204">UI とコードをなるべくクリーンでシンプルにするため、基本的なグリッド レイアウトを使って、グリッド行で [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) の後で、[**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) を宣言します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-204">To keep the UI and code as uncluttered and simple as possible, we use a basic Grid layout and declare the [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) after the [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) in a grid row.</span></span> <span data-ttu-id="e50b7-205">[**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) の前で宣言すると、キャンバスの下で [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) が先にレンダリングされ、ユーザーはアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="e50b7-205">If you declare it before the [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas), the [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) is rendered first, below the canvas and inaccessible to the user.</span></span>  

<span data-ttu-id="e50b7-206">アプリを再度実行し、[**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) が表示されることを確認してツールを試します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-206">Now run the app again to see the [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) and try out some of the tools.</span></span>

![Windows Ink ワークスペースのスケッチパッドの InkToolbar](images/ink/ink-inktoolbar-default.png)

### <a name="challenge-add-a-custom-button"></a><span data-ttu-id="e50b7-208">課題: カスタム ボタンを追加する</span><span class="sxs-lookup"><span data-stu-id="e50b7-208">Challenge: Add a custom button</span></span>
<table class="wdg-noborder">
<tr>
 <td width=125><img src="images/challenge-icon.png"></td>
    <td width=500><span data-ttu-id="e50b7-209">カスタムの <strong><a href="https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar">InkToolbar</a></strong> の例 (Windows Ink ワークスペースのスケッチパッド) を示します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-209">Here's an example of a custom <strong><a href="https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar">InkToolbar</a></strong> (from Sketchpad in the Windows Ink Workspace).</span></span>

![Windows Ink ワークスペースのスケッチパッドの InkToolbar](images/ink/ink-inktoolbar-sketchpad.png)

<span data-ttu-id="e50b7-211">[**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) のカスタマイズについて詳しくは、「[InkToolbar をユニバーサル Windows プラットフォーム (UWP) 手描き入力アプリに追加する](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/ink-toolbar)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e50b7-211">For more details about customizing an [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar), see [Add an InkToolbar to a Universal Windows Platform (UWP) inking app](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/ink-toolbar).</span></span>

</tr>
</table>

## <a name="step-5-support-handwriting-recognition"></a><span data-ttu-id="e50b7-212">手順 5: 手書き認識をサポートする</span><span class="sxs-lookup"><span data-stu-id="e50b7-212">Step 5: Support handwriting recognition</span></span>

<span data-ttu-id="e50b7-213">これでアプリで手描きや描画ができるようになりました。これを使って、さらに便利な機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-213">Now that you can write and draw in your app, let's try to do something useful with those scribbles.</span></span>

<span data-ttu-id="e50b7-214">この手順では、Windows Ink の手書き認識機能を使用して、手描き入力を解読します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-214">In this step, we use the handwriting recognition features of Windows Ink to try to decipher what you've written.</span></span>

> [!NOTE]
> <span data-ttu-id="e50b7-215">手書き認識は [**ペンと Windows Ink**] の設定を使って改善できます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-215">Handwriting recognition can be improved through the **Pen & Windows Ink** settings:</span></span>
> 1. <span data-ttu-id="e50b7-216">スタート メニューを開き、[**設定**] を選択します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-216">Open the Start menu and select **Settings**.</span></span>
> 2. <span data-ttu-id="e50b7-217">設定画面から [**デバイス**] > [**ペンと Windows Ink**] を選択します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-217">From the Settings screen select **Devices** > **Pen & Windows Ink**.</span></span>
> ![Windows Ink ワークスペースのスケッチパッドの InkToolbar](images/ink/ink-settings-large.png)
> 3. <span data-ttu-id="e50b7-219">[**手書き入力を認識します**] を選択して、[**手書き認識の個人用設定**] ダイアログを開きます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-219">Select **Get to know my handwriting** to open the **Handwriting Personalization** dialog.</span></span>
> ![Windows Ink ワークスペースのスケッチパッドの InkToolbar](images/ink/ink-settings-handwritingpersonalization-large.png)

### <a name="in-the-sample"></a><span data-ttu-id="e50b7-221">このサンプルを使って、次を行います:</span><span class="sxs-lookup"><span data-stu-id="e50b7-221">In the sample:</span></span>
1. <span data-ttu-id="e50b7-222">MainPage.xaml ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-222">Open the MainPage.xaml file.</span></span>
2. <span data-ttu-id="e50b7-223">この手順のタイトル ("\<!-- Step 5: Support handwriting recognition -->") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-223">Find the code marked with the title of this step ("\<!-- Step 5: Support handwriting recognition -->").</span></span>
3. <span data-ttu-id="e50b7-224">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-224">Uncomment the following lines.</span></span>  

``` xaml
    <Button x:Name="recognizeText" 
            Content="Recognize text"  
            Grid.Row="0" Grid.Column="0"
            Margin="10,10,10,10"
            Click="recognizeText_ClickAsync"/>
    <TextBlock x:Name="recognitionResult" 
                Text="Recognition results: "
                VerticalAlignment="Center" 
                Grid.Row="0" Grid.Column="1"
                Margin="50,0,0,0" />
```

4. <span data-ttu-id="e50b7-225">MainPage.xaml.cs ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-225">Open the MainPage.xaml.cs file.</span></span>
5. <span data-ttu-id="e50b7-226">この手順のタイトル  (" Step 5: Support handwriting recognition") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-226">Find the code marked with the title of this step (" Step 5: Support handwriting recognition").</span></span>
6. <span data-ttu-id="e50b7-227">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-227">Uncomment the following lines.</span></span>  

- <span data-ttu-id="e50b7-228">これらは、この手順で必要なグローバル変数です。</span><span class="sxs-lookup"><span data-stu-id="e50b7-228">These are the global variables required for this step.</span></span>

``` csharp
    InkAnalyzer analyzerText = new InkAnalyzer();
    IReadOnlyList<InkStroke> strokesText = null;
    InkAnalysisResult resultText = null;
    IReadOnlyList<IInkAnalysisNode> words = null;
```

- <span data-ttu-id="e50b7-229">これは、[**Recognize text**] (テキストの認識) ボタンのハンドラーで、これにより認識処理を行います。</span><span class="sxs-lookup"><span data-stu-id="e50b7-229">This is the handler for the **Recognize text** button, where we do the recognition processing.</span></span>

``` csharp
    private async void recognizeText_ClickAsync(object sender, RoutedEventArgs e)
    {
        strokesText = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
        // Ensure an ink stroke is present.
        if (strokesText.Count > 0)
        {
            analyzerText.AddDataForStrokes(strokesText);

            resultText = await analyzerText.AnalyzeAsync();

            if (resultText.Status == InkAnalysisStatus.Updated)
            {
                words = analyzerText.AnalysisRoot.FindNodes(InkAnalysisNodeKind.InkWord);
                foreach (var word in words)
                {
                    InkAnalysisInkWord concreteWord = (InkAnalysisInkWord)word;
                    foreach (string s in concreteWord.TextAlternates)
                    {
                        recognitionResult.Text += s;
                    }
                }
            }
            analyzerText.ClearDataForAllStrokes();
        }
    }
```

7. <span data-ttu-id="e50b7-230">アプリを再び実行し、何かを書き込んで、[**Recognize text**] (テキストの認識) ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="e50b7-230">Run the app again, write something, and then click the **Recognize text** button</span></span>
8. <span data-ttu-id="e50b7-231">認識の結果は、ボタンの横に表示されます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-231">The results of the recognition are displayed beside the button</span></span>

### <a name="challenge-1-international-recognition"></a><span data-ttu-id="e50b7-232">課題1: 地域と言語の認識</span><span class="sxs-lookup"><span data-stu-id="e50b7-232">Challenge 1: International recognition</span></span>
<table class="wdg-noborder">
<tr>
 <td width=125><img src="images/challenge-icon.png"></td>
    <td width=500><p><span data-ttu-id="e50b7-233">Windows Ink は、Windowsでサポートされている多くの言語のテキスト認識をサポートします。</span><span class="sxs-lookup"><span data-stu-id="e50b7-233">Windows Ink supports text recognition for many of the of the languages supported by Windows.</span></span> <span data-ttu-id="e50b7-234">各言語パックには、言語パックと共にインストールできる、手書き認識エンジンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="e50b7-234">Each language pack includes a handwriting recognition engine that can be installed with the language pack.</span></span></p>
    <p><span data-ttu-id="e50b7-235">インストール済みの手書き認識エンジンにクエリを行って、特定の言語をターゲットにします。</span><span class="sxs-lookup"><span data-stu-id="e50b7-235">Target a specific language by querying the installed handwriting recognition engines.</span></span></p>
    <p><span data-ttu-id="e50b7-236">地域と言語の手書き認識について詳しくは、「<a href="https://docs.microsoft.com/windows/uwp/input-and-devices/convert-ink-to-text">Windows Ink でのストロークのテキスト認識</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e50b7-236">For more details about international handwriting recognition, see <a href="https://docs.microsoft.com/windows/uwp/input-and-devices/convert-ink-to-text">Recognize Windows Ink strokes as text</a>.</span></span></p>
</tr>
</table>

### <a name="challenge-2-dynamic-recognition"></a><span data-ttu-id="e50b7-237">課題 2: 動的な認識</span><span class="sxs-lookup"><span data-stu-id="e50b7-237">Challenge 2: Dynamic recognition</span></span>
<table class="wdg-noborder">
<tr>
 <td width=125><img src="images/challenge-icon.png"></td>
    <td width=500><p><span data-ttu-id="e50b7-238">このチュートリアルでは、認識を開始するためにボタンを押す必要があります。</span><span class="sxs-lookup"><span data-stu-id="e50b7-238">For this tutorial, we require that a button be pressed to initiate recognition.</span></span> <span data-ttu-id="e50b7-239">基本的なタイミング関数を使って、動的な認識を実行することもできます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-239">You can also perform dynamic recognition by using a basic timing function.</span></span></p>

<span data-ttu-id="e50b7-240">動的な認識について詳しくは、「[Windows Ink でのストロークのテキスト認識](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/convert-ink-to-text)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e50b7-240">For more details about dynamic recognition, see [Recognize Windows Ink strokes as text](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/convert-ink-to-text).</span></span>
</tr>
</table>

## <a name="step-6-recognize-shapes"></a><span data-ttu-id="e50b7-241">手順 6: 図形を認識する</span><span class="sxs-lookup"><span data-stu-id="e50b7-241">Step 6: Recognize shapes</span></span>

<span data-ttu-id="e50b7-242">これで手書きのメモを判読可能なものに変換できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="e50b7-242">Ok, so now you can convert your handwritten notes into something a little more legible.</span></span> <span data-ttu-id="e50b7-243">では、手書きのフローチャートなどを認識することはできるでしょうか。</span><span class="sxs-lookup"><span data-stu-id="e50b7-243">But what about those shaky, caffeinated doodles from your morning Flowcharters Anonymous meeting?</span></span>

<span data-ttu-id="e50b7-244">インクの分析を使うと、アプリは次のような基本的な図形を認識することができます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-244">Using ink analysis, your app can also recognize a set of core shapes, including:</span></span>
- <span data-ttu-id="e50b7-245">円形</span><span class="sxs-lookup"><span data-stu-id="e50b7-245">Circle</span></span>
- <span data-ttu-id="e50b7-246">ひし形</span><span class="sxs-lookup"><span data-stu-id="e50b7-246">Diamond</span></span>
- <span data-ttu-id="e50b7-247">線</span><span class="sxs-lookup"><span data-stu-id="e50b7-247">Drawing</span></span>
- <span data-ttu-id="e50b7-248">楕円形</span><span class="sxs-lookup"><span data-stu-id="e50b7-248">Ellipse</span></span>
- <span data-ttu-id="e50b7-249">正三角形</span><span class="sxs-lookup"><span data-stu-id="e50b7-249">EquilateralTriangle</span></span>
- <span data-ttu-id="e50b7-250">六角形</span><span class="sxs-lookup"><span data-stu-id="e50b7-250">Hexagon</span></span>
- <span data-ttu-id="e50b7-251">二等辺三角形</span><span class="sxs-lookup"><span data-stu-id="e50b7-251">IsoscelesTriangle</span></span>
- <span data-ttu-id="e50b7-252">平行四辺形</span><span class="sxs-lookup"><span data-stu-id="e50b7-252">Parallelogram</span></span>
- <span data-ttu-id="e50b7-253">五角形</span><span class="sxs-lookup"><span data-stu-id="e50b7-253">Pentagon</span></span>
- <span data-ttu-id="e50b7-254">四辺形</span><span class="sxs-lookup"><span data-stu-id="e50b7-254">Quadrilateral</span></span>
- <span data-ttu-id="e50b7-255">長方形</span><span class="sxs-lookup"><span data-stu-id="e50b7-255">Rectangle</span></span>
- <span data-ttu-id="e50b7-256">直角三角形</span><span class="sxs-lookup"><span data-stu-id="e50b7-256">RightTriangle</span></span>
- <span data-ttu-id="e50b7-257">正方形</span><span class="sxs-lookup"><span data-stu-id="e50b7-257">Square</span></span>
- <span data-ttu-id="e50b7-258">台形</span><span class="sxs-lookup"><span data-stu-id="e50b7-258">Trapezoid</span></span>
- <span data-ttu-id="e50b7-259">三角形</span><span class="sxs-lookup"><span data-stu-id="e50b7-259">Triangle</span></span>

<span data-ttu-id="e50b7-260">この手順では、Windows Ink の図形認識機能を使用して、手書きの図形をクリーンにします。</span><span class="sxs-lookup"><span data-stu-id="e50b7-260">In this step, we use the shape-recognition features of Windows Ink to try to clean up your doodles.</span></span>

<span data-ttu-id="e50b7-261">この例では、インク ストロークの再描画は (可能ですが) 行いません。</span><span class="sxs-lookup"><span data-stu-id="e50b7-261">For this example, we don't attempt to redraw ink strokes (although that's possible).</span></span> <span data-ttu-id="e50b7-262">代わりに、InkCanvas の下に標準のキャンバスを追加し、元の手書き図形から作成された、楕円や多角形オブジェクトをそこに描画します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-262">Instead, we add a standard canvas under the InkCanvas where we draw equivalent Ellipse or Polygon objects derived from the original ink.</span></span> <span data-ttu-id="e50b7-263">次に、対応するインク ストロークを削除します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-263">We then delete the corresponding ink strokes.</span></span>

### <a name="in-the-sample"></a><span data-ttu-id="e50b7-264">このサンプルを使って、次を行います:</span><span class="sxs-lookup"><span data-stu-id="e50b7-264">In the sample:</span></span>
1. <span data-ttu-id="e50b7-265">MainPage.xaml ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-265">Open the MainPage.xaml file</span></span>
2. <span data-ttu-id="e50b7-266">この手順のタイトル ("\<!-- Step 6: Recognize shapes -->") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-266">Find the code marked with the title of this step ("\<!-- Step 6: Recognize shapes -->")</span></span>
3. <span data-ttu-id="e50b7-267">この行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-267">Uncomment this line.</span></span>  

``` xaml
   <Canvas x:Name="canvas" />

   And these lines.

    <Button Grid.Row="1" x:Name="recognizeShape" Click="recognizeShape_ClickAsync"
        Content="Recognize shape" 
        Margin="10,10,10,10" />
```

4. <span data-ttu-id="e50b7-268">MainPage.xaml.cs ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-268">Open the MainPage.xaml.cs file</span></span>
5. <span data-ttu-id="e50b7-269">この手順のタイトル ("// Step 6: Recognize shapes") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-269">Find the code marked with the title of this step ("// Step 6: Recognize shapes")</span></span>
6. <span data-ttu-id="e50b7-270">これらの行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-270">Uncomment these lines:</span></span>  

``` csharp
    private async void recognizeShape_ClickAsync(object sender, RoutedEventArgs e)
    {
        ...
    }

    private void DrawEllipse(InkAnalysisInkDrawing shape)
    {
        ...
    }

    private void DrawPolygon(InkAnalysisInkDrawing shape)
    {
        ...
    }
```

7. <span data-ttu-id="e50b7-271">アプリを実行し、いくつかの図形を描画して、[**Recognize shape**] (図形の認識) ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="e50b7-271">Run the app, draw some shapes, and click the **Recognize shape** button</span></span>

<span data-ttu-id="e50b7-272">デジタルの走り書きを使った、基本的なフローチャートの例を示します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-272">Here's an example of a rudimentary flowchart from a digital napkin.</span></span>

![元のインクのフローチャート](images/ink/ink-app-step6-shapereco1.png)

<span data-ttu-id="e50b7-274">図形認識後の同じフローチャートを次に示します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-274">Here's the same flowchart after shape recognition.</span></span>

![元のインクのフローチャート](images/ink/ink-app-step6-shapereco2.png)


## <a name="step-7-save-and-load-ink"></a><span data-ttu-id="e50b7-276">手順 7: インクの保存と読み込み</span><span class="sxs-lookup"><span data-stu-id="e50b7-276">Step 7: Save and load ink</span></span>

<span data-ttu-id="e50b7-277">手書きの文字や図形の認識ができるようになりましたが、それらを後から使いたい場合にはどうすればよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="e50b7-277">So, you're done doodling and you like what you see, but think you might like to tweak a couple of things later?</span></span> <span data-ttu-id="e50b7-278">インク ストロークを Ink Serialized Format (ISF) ファイルに保存し、後でそれを読み込んで編集することができます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-278">You can save your ink strokes to an Ink Serialized Format (ISF) file and load them for editing whenever the inspiration strikes.</span></span> 

<span data-ttu-id="e50b7-279">ISF ファイルは、インク ストロークのプロパティと動作に関する追加のメタデータを含む、基本的な GIF 画像です。</span><span class="sxs-lookup"><span data-stu-id="e50b7-279">The ISF file is a basic GIF image that includes additional metadata describing ink-stroke properties and behaviors.</span></span> <span data-ttu-id="e50b7-280">インク対応でないアプリでは、追加のメタデータを無視して、基本的な GIF 画像 (アルファ チャンネルの背景の透明度を含む) を読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-280">Apps that are not ink enabled can ignore the extra metadata and still load the basic GIF image (including alpha-channel background transparency).</span></span>

<span data-ttu-id="e50b7-281">この手順では、インク ツールバーの横にある、[**保存**] と [**読み込み**] ボタンをフックします。</span><span class="sxs-lookup"><span data-stu-id="e50b7-281">In this step, we hook up the **Save** and **Load** buttons located beside the ink toolbar.</span></span>

### <a name="in-the-sample"></a><span data-ttu-id="e50b7-282">このサンプルを使って、次を行います:</span><span class="sxs-lookup"><span data-stu-id="e50b7-282">In the sample:</span></span>
1. <span data-ttu-id="e50b7-283">MainPage.xaml ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-283">Open the MainPage.xaml file.</span></span>
2. <span data-ttu-id="e50b7-284">この手順のタイトル ("\<!-- Step 7: Saving and loading ink -->") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-284">Find the code marked with the title of this step ("\<!-- Step 7: Saving and loading ink -->").</span></span>
3. <span data-ttu-id="e50b7-285">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-285">Uncomment the following lines.</span></span> 

``` xaml
    <Button x:Name="buttonSave" 
            Content="Save" 
            Click="buttonSave_ClickAsync"
            Width="100"
            Margin="5,0,0,0"/>
    <Button x:Name="buttonLoad" 
            Content="Load"  
            Click="buttonLoad_ClickAsync"
            Width="100"
            Margin="5,0,0,0"/>
```

4. <span data-ttu-id="e50b7-286">MainPage.xaml.cs ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-286">Open the MainPage.xaml.cs file.</span></span>
5. <span data-ttu-id="e50b7-287">この手順のタイトル ("// Step 7: Save and load ink") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-287">Find the code marked with the title of this step ("// Step 7: Save and load ink").</span></span>
6. <span data-ttu-id="e50b7-288">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-288">Uncomment the following lines.</span></span>  

``` csharp
    private async void buttonSave_ClickAsync(object sender, RoutedEventArgs e)
    {
        ...
    }

    private async void buttonLoad_ClickAsync(object sender, RoutedEventArgs e)
    {
        ...
    }
```

7. <span data-ttu-id="e50b7-289">アプリを実行し、何かを描画します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-289">Run the app and draw something.</span></span>
8. <span data-ttu-id="e50b7-290">[**保存**] ボタンを選択し、描画を保存します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-290">Select the **Save** button and save your drawing.</span></span>
9. <span data-ttu-id="e50b7-291">インクを消去するか、またはアプリを再起動します。</span><span class="sxs-lookup"><span data-stu-id="e50b7-291">Erase the ink or restart the app.</span></span>
10. <span data-ttu-id="e50b7-292">[**読み込み**] ボタンを選択して、保存したインク ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="e50b7-292">Select the **Load** button and open the ink file you just saved.</span></span>

### <a name="challenge-use-the-clipboard-to-copy-and-paste-ink-strokes"></a><span data-ttu-id="e50b7-293">課題: クリップボードを使って、インク ストロークをコピーして貼り付ける</span><span class="sxs-lookup"><span data-stu-id="e50b7-293">Challenge: Use the clipboard to copy and paste ink strokes</span></span> 
<table class="wdg-noborder">
<tr>
 <td width=125><img src="images/challenge-icon.png"></td>
    <td width=500><p><span data-ttu-id="e50b7-294">Windows Ink は、インク ストロークのクリップボードへのコピーと貼り付けもサポートしています。</span><span class="sxs-lookup"><span data-stu-id="e50b7-294">Windows ink also supports copying and pasting ink strokes to and from the clipboard.</span></span>

<span data-ttu-id="e50b7-295">Windows Ink とクリップボードの使用について詳しくは、「[Windows Ink ストローク データの保存と取得](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/save-and-load-ink)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e50b7-295">For more details about using the clipboard with ink, see [Store and retrieve Windows Ink stroke data](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/save-and-load-ink).</span></span>
</tr>
</table>

## <a name="summary"></a><span data-ttu-id="e50b7-296">まとめ</span><span class="sxs-lookup"><span data-stu-id="e50b7-296">Summary</span></span>

<span data-ttu-id="e50b7-297">これで、**入力: UWP アプリでインクをサポートする**チュートリアルは完了です。</span><span class="sxs-lookup"><span data-stu-id="e50b7-297">Congratulations, you've completed the **Input: Support ink in your UWP app** tutorial !</span></span> <span data-ttu-id="e50b7-298">UWP アプリでインクをサポートするために必要な基本的なコードについて説明しました。また Windows Ink プラットフォームでサポートされる、優れたユーザー エクスペリエンスを提供する方法を説明しました。</span><span class="sxs-lookup"><span data-stu-id="e50b7-298">We showed you the basic code required for supporting ink in your UWP apps, and how to provide some of the richer user experiences supported by the Windows Ink platform.</span></span>

## <a name="related-articles"></a><span data-ttu-id="e50b7-299">関連記事</span><span class="sxs-lookup"><span data-stu-id="e50b7-299">Related articles</span></span>

* [<span data-ttu-id="e50b7-300">UWP アプリでのペン操作と Windows Ink</span><span class="sxs-lookup"><span data-stu-id="e50b7-300">Pen interactions and Windows Ink in UWP apps</span></span>](https://docs.microsoft.com/windows/uwp/input-and-devices/pen-and-stylus-interactions)

**<span data-ttu-id="e50b7-301">サンプル</span><span class="sxs-lookup"><span data-stu-id="e50b7-301">Samples</span></span>**
* [<span data-ttu-id="e50b7-302">単純なインクのサンプル (C#/C++)</span><span class="sxs-lookup"><span data-stu-id="e50b7-302">Simple ink sample (C#/C++)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620312)
* [<span data-ttu-id="e50b7-303">複雑なインクのサンプル (C++)</span><span class="sxs-lookup"><span data-stu-id="e50b7-303">Complex ink sample (C++)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620314)
* [<span data-ttu-id="e50b7-304">インクのサンプル (JavaScript)</span><span class="sxs-lookup"><span data-stu-id="e50b7-304">Ink sample (JavaScript)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620308)
* [<span data-ttu-id="e50b7-305">入門チュートリアル: UWP アプリでのインクのサポート</span><span class="sxs-lookup"><span data-stu-id="e50b7-305">Get Started Tutorial: Support ink in your UWP app</span></span>](https://aka.ms/appsample-ink)
* [<span data-ttu-id="e50b7-306">塗り絵帳のサンプル</span><span class="sxs-lookup"><span data-stu-id="e50b7-306">Coloring book sample</span></span>](https://aka.ms/cpubsample-coloringbook)
* [<span data-ttu-id="e50b7-307">Family Notes のサンプル</span><span class="sxs-lookup"><span data-stu-id="e50b7-307">Family notes sample</span></span>](https://aka.ms/cpubsample-familynotessample)
