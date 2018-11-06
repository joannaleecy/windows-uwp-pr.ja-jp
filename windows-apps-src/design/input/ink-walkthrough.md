---
author: Karl-Bridge-Microsoft
ms.assetid: ''
title: UWP アプリでインクをサポートする
description: 作成した UWP アプリにインクのサポートを追加するための、ステップ バイ ステップ チュートリアルです。
keywords: インク, 手描き入力, チュートリアル
ms.author: kbridge
ms.date: 01/25/2018
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 62c62aacd894163ef2c65b9ddfe6d8299733a2e5
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6042252"
---
# <a name="tutorial-support-ink-in-your-uwp-app"></a><span data-ttu-id="1de27-104">チュートリアル: UWP アプリでインクをサポートする</span><span class="sxs-lookup"><span data-stu-id="1de27-104">Tutorial: Support ink in your UWP app</span></span>

![Surface ペン](images/ink/ink-hero-small.png)  
<span data-ttu-id="1de27-106">*Surface ペン* ([Microsoft ストア](https://aka.ms/purchasesurfacepen)で購入できます)。</span><span class="sxs-lookup"><span data-stu-id="1de27-106">*Surface Pen* (available for purchase at the [Microsoft Store](https://aka.ms/purchasesurfacepen)).</span></span>

<span data-ttu-id="1de27-107">このチュートリアルでは、Windows Ink を使った描画と手書きをサポートする、基本的な ユニバーサル Windows プラットフォーム (UWP) アプリを作成する手順を示します。</span><span class="sxs-lookup"><span data-stu-id="1de27-107">This tutorial steps through how to create a basic Universal Windows Platform (UWP) app that supports writing and drawing with Windows Ink.</span></span> <span data-ttu-id="1de27-108">使用するサンプル アプリは GitHub ([サンプル コード](#sample-code)) からダウンロードできます。このサンプル アプリのスニペットは、各手順でのさまざまな機能と関連する Windows Ink API ([Windows Ink プラットフォームのコンポーネント](#components-of-the-windows-ink-platform)をご覧ください) の使い方を示します。</span><span class="sxs-lookup"><span data-stu-id="1de27-108">We use snippets from a sample app, which you can download from GitHub (see [Sample code](#sample-code)), to demonstrate the various features and associated Windows Ink APIs (see [Components of the Windows Ink platform](#components-of-the-windows-ink-platform)) discussed in each step.</span></span>

<span data-ttu-id="1de27-109">次の点を中心に説明します。</span><span class="sxs-lookup"><span data-stu-id="1de27-109">We focus on the following:</span></span>
* <span data-ttu-id="1de27-110">基本的なインクのサポートを追加する</span><span class="sxs-lookup"><span data-stu-id="1de27-110">Adding basic ink support</span></span>
* <span data-ttu-id="1de27-111">インク ツールバーを追加する</span><span class="sxs-lookup"><span data-stu-id="1de27-111">Adding an ink toolbar</span></span>
* <span data-ttu-id="1de27-112">手書き認識をサポートする</span><span class="sxs-lookup"><span data-stu-id="1de27-112">Supporting handwriting recognition</span></span>
* <span data-ttu-id="1de27-113">基本的な図形の認識をサポートする</span><span class="sxs-lookup"><span data-stu-id="1de27-113">Supporting basic shape recognition</span></span>
* <span data-ttu-id="1de27-114">インクを保存して読み込む</span><span class="sxs-lookup"><span data-stu-id="1de27-114">Saving and loading ink</span></span>

<span data-ttu-id="1de27-115">これらの機能の実装について詳しくは「[UWP アプリでのペン操作と Windows Ink](https://docs.microsoft.com/windows/uwp/input/pen-and-stylus-interactions)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1de27-115">For more detail about implementing these features, see [Pen interactions and Windows Ink in UWP apps](https://docs.microsoft.com/windows/uwp/input/pen-and-stylus-interactions).</span></span>

## <a name="introduction"></a><span data-ttu-id="1de27-116">概要</span><span class="sxs-lookup"><span data-stu-id="1de27-116">Introduction</span></span>

<span data-ttu-id="1de27-117">Windows Ink を使うと、ユーザーに、ペンと紙の体験とほぼ同等のデジタル エクスペリエンスを提供できます。すばやく手書きでメモを取ったり、ホワイトボードのデモに注釈を書き込んだり、建築製図や工業図面の作成から、個人的な作品の制作まで行えます。</span><span class="sxs-lookup"><span data-stu-id="1de27-117">With Windows Ink, you can provide your customers with the digital equivalent of almost any pen-and-paper experience imaginable, from quick, handwritten notes and annotations to whiteboard demos, and from architectural and engineering drawings to personal masterpieces.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="1de27-118">前提条件</span><span class="sxs-lookup"><span data-stu-id="1de27-118">Prerequisites</span></span>

* <span data-ttu-id="1de27-119">現在のバージョンの Windows 10 を実行するコンピューター (または仮想マシン)。</span><span class="sxs-lookup"><span data-stu-id="1de27-119">A computer (or a virtual machine) running the current version of Windows 10</span></span>
* [<span data-ttu-id="1de27-120">Visual Studio 2017 および RS2 SDK</span><span class="sxs-lookup"><span data-stu-id="1de27-120">Visual Studio 2017 and the RS2 SDK</span></span>](https://developer.microsoft.com/windows/downloads)
* [<span data-ttu-id="1de27-121">Windows 10 SDK (10.0.15063.0)</span><span class="sxs-lookup"><span data-stu-id="1de27-121">Windows10 SDK (10.0.15063.0)</span></span>](https://developer.microsoft.com/windows/downloads/windows-10-sdk)
* <span data-ttu-id="1de27-122">構成によっては、 [Microsoft.NETCore.UniversalWindowsPlatform](https://www.nuget.org/packages/Microsoft.NETCore.UniversalWindowsPlatform/6.1.9) NuGet パッケージをインストールして、システムの設定で**開発者モード**を有効にする必要があります (設定の更新]-> [&、セキュリティでは、開発者向け]-> [の]-> [開発者向け機能を使用)。</span><span class="sxs-lookup"><span data-stu-id="1de27-122">Depending on your configuration, you might have to install the [Microsoft.NETCore.UniversalWindowsPlatform](https://www.nuget.org/packages/Microsoft.NETCore.UniversalWindowsPlatform/6.1.9) NuGet package and enable **Developer mode** in your system settings (Settings -> Update & Security -> For developers -> Use developer features).</span></span>
* <span data-ttu-id="1de27-123">Visual Studio を使ってユニバーサル Windows プラットフォーム (UWP) アプリの開発を初めて行う場合は、このチュートリアルを開始する前に、次のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1de27-123">If you're new to Universal Windows Platform (UWP) app development with Visual Studio, have a look through these topics before you start this tutorial:</span></span>  
    * [<span data-ttu-id="1de27-124">準備</span><span class="sxs-lookup"><span data-stu-id="1de27-124">Get set up</span></span>](https://docs.microsoft.com/windows/uwp/get-started/get-set-up)
    * [<span data-ttu-id="1de27-125">"Hello, world" アプリを作成する (XAML)</span><span class="sxs-lookup"><span data-stu-id="1de27-125">Create a "Hello, world" app (XAML)</span></span>](https://docs.microsoft.com/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)
* <span data-ttu-id="1de27-126">**[オプション]** デジタル ペンと、そのデジタル ペンからの入力をサポートしているディスプレイを搭載したコンピューター。</span><span class="sxs-lookup"><span data-stu-id="1de27-126">**[OPTIONAL]** A digital pen and a computer with a display that supports input from that digital pen.</span></span>

> [!NOTE] 
> <span data-ttu-id="1de27-127">Windows Ink は、マウスとタッチを使った描画をサポートします (これについては、このチュートリアルの手順 3 で説明します) が、最適なWindows Ink エクスペリエンスのためには、デジタル ペンとそのデジタル ペンからの入力をサポートしているディスプレイを備えたコンピューターの使用を推奨します。</span><span class="sxs-lookup"><span data-stu-id="1de27-127">While Windows Ink can support drawing with a mouse and touch (we show how to do this in Step 3 of this tutorial) for an optimal Windows Ink experience, we recommend that you have a digital pen and a computer with a display that supports input from that digital pen.</span></span>

## <a name="sample-code"></a><span data-ttu-id="1de27-128">サンプル コード</span><span class="sxs-lookup"><span data-stu-id="1de27-128">Sample code</span></span>
<span data-ttu-id="1de27-129">このチュートリアル全体で、1 つサンプル インク アプリを使って概念と機能を説明します。</span><span class="sxs-lookup"><span data-stu-id="1de27-129">Throughout this tutorial, we use a sample ink app to demonstrate the concepts and functionality discussed.</span></span>

<span data-ttu-id="1de27-130">この Visual Studio サンプルとソース コードは [GitHub](https://github.com/) の [windows-appsample-get-started-ink sample](https://aka.ms/appsample-ink) からダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="1de27-130">Download this Visual Studio sample and source code from [GitHub](https://github.com/) at [windows-appsample-get-started-ink sample](https://aka.ms/appsample-ink):</span></span>

1. <span data-ttu-id="1de27-131">緑の [**Clone or download**] (複製またはダウンロード) ボタンを選択します。</span><span class="sxs-lookup"><span data-stu-id="1de27-131">Select the green **Clone or download** button</span></span>  
![リポジトリを複製する](images/ink/ink-clone.png)
2. <span data-ttu-id="1de27-133">GitHub のアカウントを使っている場合には、[**Open in Visual Studio**] (Visual Studio で開く) を選択して、リポジトリをローカル コンピューターに複製できます。</span><span class="sxs-lookup"><span data-stu-id="1de27-133">If you have a GitHub account, you can clone the repo to your local machine by choosing **Open in Visual Studio**</span></span> 
3. <span data-ttu-id="1de27-134">GitHub アカウントを使っていない場合、またはプロジェクトのローカル コピーのみが必要な場合には、[**Download ZIP**] (ZIP をダウンロードする) を選択します (最新の更新をダウンロードするには、定期的に確認する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="1de27-134">If you don't have a GitHub account, or you just want a local copy of the project, choose **Download ZIP** (you'll have to check back regularly to download the latest updates)</span></span>

> [!IMPORTANT]
> <span data-ttu-id="1de27-135">サンプル コードのほとんどの部分はコメント アウトされています。各手順を進めていく際に、コードの各セクションのコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="1de27-135">Most of the code in the sample is commented out. As we go through each step, you'll be asked to uncomment various sections of the code.</span></span> <span data-ttu-id="1de27-136">Visual Studio では、コードの行を強調表示して Ctrl + K キーを押して Ctrl + U キーを押します。</span><span class="sxs-lookup"><span data-stu-id="1de27-136">In Visual Studio, just highlight the lines of code, and press CTRL-K and then CTRL-U.</span></span>

## <a name="components-of-the-windows-ink-platform"></a><span data-ttu-id="1de27-137">Windows Ink プラットフォームのコンポーネント</span><span class="sxs-lookup"><span data-stu-id="1de27-137">Components of the Windows Ink platform</span></span>

<span data-ttu-id="1de27-138">これらのオブジェクトは、UWP アプリ用の手描き入力エクスペリエンスの大部分を提供します。</span><span class="sxs-lookup"><span data-stu-id="1de27-138">These objects provide the bulk of the inking experience for UWP apps.</span></span>

| <span data-ttu-id="1de27-139">コンポーネント</span><span class="sxs-lookup"><span data-stu-id="1de27-139">Component</span></span> | <span data-ttu-id="1de27-140">説明</span><span class="sxs-lookup"><span data-stu-id="1de27-140">Description</span></span> |
| --- | --- |
| [**<span data-ttu-id="1de27-141">InkCanvas</span><span class="sxs-lookup"><span data-stu-id="1de27-141">InkCanvas</span></span>**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) | <span data-ttu-id="1de27-142">XAMLUI プラットフォーム コントロール、既定では、受信し、ペンからのすべての入力をインク ストロークか消去ストロークとして表示します。</span><span class="sxs-lookup"><span data-stu-id="1de27-142">A XAMLUI platform control that, by default, receives and displays all input from a pen as either an ink stroke or an erase stroke.</span></span> |
| [**<span data-ttu-id="1de27-143">InkPresenter</span><span class="sxs-lookup"><span data-stu-id="1de27-143">InkPresenter</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn922011) | <span data-ttu-id="1de27-144">[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールと共にインスタンス化される分離コード オブジェクトです ([**InkCanvas.InkPresenter**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas.InkPresenter) プロパティによって公開されます)。</span><span class="sxs-lookup"><span data-stu-id="1de27-144">A code-behind object, instantiated along with an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) control (exposed through the [**InkCanvas.InkPresenter**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas.InkPresenter) property).</span></span> <span data-ttu-id="1de27-145">[**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) によって公開される既定の手描き入力機能のすべてと、追加のカスタマイズや個人用設定のための包括的な API のセットを提供します。</span><span class="sxs-lookup"><span data-stu-id="1de27-145">This object provides all default inking functionality exposed by the [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas), along with a comprehensive set of APIs for additional customization and personalization.</span></span> |
| [**<span data-ttu-id="1de27-146">InkToolbar</span><span class="sxs-lookup"><span data-stu-id="1de27-146">InkToolbar</span></span>**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) | <span data-ttu-id="1de27-147">関連付けられた[**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas)のインク関連機能をアクティブ化するボタンのカスタマイズと拡張可能なコレクションを含む XAMLUI プラットフォーム コントロールです。</span><span class="sxs-lookup"><span data-stu-id="1de27-147">A XAMLUI platform control containing a customizable and extensible collection of buttons that activate ink-related features in an associated [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas).</span></span> |
| [**<span data-ttu-id="1de27-148">IInkD2DRenderer</span><span class="sxs-lookup"><span data-stu-id="1de27-148">IInkD2DRenderer</span></span>**](https://msdn.microsoft.com/library/mt147263)<br/><span data-ttu-id="1de27-149">この機能は、このドキュメントの対象範囲外です。詳しくは、「[複雑なインクのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=620314)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1de27-149">We do not cover this functionality here, for more information, see the [Complex ink sample](http://go.microsoft.com/fwlink/p/?LinkID=620314).</span></span> | <span data-ttu-id="1de27-150">既定の [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールの代わりに、ユニバーサル Windows アプリが指定した Direct2D デバイス コンテキストにインク ストロークをレンダリングできます。</span><span class="sxs-lookup"><span data-stu-id="1de27-150">Enables the rendering of ink strokes onto the designated Direct2D device context of a Universal Windows app, instead of the default [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) control.</span></span> |

## <a name="step-1-run-the-sample"></a><span data-ttu-id="1de27-151">手順 1: サンプルを実行する</span><span class="sxs-lookup"><span data-stu-id="1de27-151">Step 1: Run the sample</span></span>

<span data-ttu-id="1de27-152">RadialController サンプル アプリをダウンロードしたら、実行できることを確認します。</span><span class="sxs-lookup"><span data-stu-id="1de27-152">After you've downloaded the RadialController sample app, verify that it runs:</span></span>
1. <span data-ttu-id="1de27-153">Visual Studio でサンプル プロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="1de27-153">Open the sample project in Visual Studio.</span></span>
2. <span data-ttu-id="1de27-154">[**ソリューション プラットフォーム**] のドロップダウンを ARM 以外の選択肢に設定します。</span><span class="sxs-lookup"><span data-stu-id="1de27-154">Set the **Solution Platforms** dropdown to a non-ARM selection.</span></span>
3. <span data-ttu-id="1de27-155">F5 キーを押して、コンパイル、展開、および実行します。</span><span class="sxs-lookup"><span data-stu-id="1de27-155">Press F5 to compile, deploy, and run.</span></span>  

   > [!NOTE]
   > <span data-ttu-id="1de27-156">または、[**デバッグ**] > [**デバッグの開始**] メニュー項目を選択するか、または次のように [**ローカル コンピューター**] の実行ボタンを選択することもできます。</span><span class="sxs-lookup"><span data-stu-id="1de27-156">Alternatively, you can select **Debug** > **Start debugging** menu item, or select the **Local Machine** Run button shown here.</span></span>
   > ![Visual Studio のプロジェクトのビルド ボタン](images/ink/ink-vsrun-small.png)

<span data-ttu-id="1de27-158">アプリ ウィンドウが開き、スプラッシュ画面が数秒表示されて、次のような初期画面が表示されます。</span><span class="sxs-lookup"><span data-stu-id="1de27-158">The app window opens, and after a splash screen appears for a few seconds, you’ll see this initial screen.</span></span>

![空のアプリ](images/ink/ink-app-step1-empty-small.png)

<span data-ttu-id="1de27-160">これでチュートリアルの残りの部分で使う、基本的な UWP アプリの準備ができました。</span><span class="sxs-lookup"><span data-stu-id="1de27-160">Okay, we now have the basic UWP app that we’ll use throughout the rest of this tutorial.</span></span> <span data-ttu-id="1de27-161">これ以降の手順では、インク機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="1de27-161">In the following steps, we add our ink functionality.</span></span>

## <a name="step-2-use-inkcanvas-to-support-basic-inking"></a><span data-ttu-id="1de27-162">手順 2: InkCanvas を使って基本的な手描き入力をサポートする</span><span class="sxs-lookup"><span data-stu-id="1de27-162">Step 2: Use InkCanvas to support basic inking</span></span>

<span data-ttu-id="1de27-163">お気付きのように、このアプリは初期状態では、ペンを使って手描きを行うことはできません (ただし、標準のポインター デバイスとしてペンを使用してアプリを操作することはできます)。</span><span class="sxs-lookup"><span data-stu-id="1de27-163">Perhaps you've probably already noticed that the app, in it's initial form, doesn't let you draw anything with the pen (although you can use the pen as a standard pointer device to interact with the app).</span></span> 

<span data-ttu-id="1de27-164">この手順では、その欠点を修正します。</span><span class="sxs-lookup"><span data-stu-id="1de27-164">Let's fix that little shortcoming in this step.</span></span>

<span data-ttu-id="1de27-165">基本的な手描き機能を追加するには、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) UWP プラットフォーム コントロールをアプリの適切なページに配置します。</span><span class="sxs-lookup"><span data-stu-id="1de27-165">To add basic inking functionality, just place an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) UWP platform control on the appropriate page in your app.</span></span>

> [!NOTE]
> <span data-ttu-id="1de27-166">InkCanvas の[**高さ**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.Height)と[**幅**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.Width)のプロパティは、子要素のサイズを自動的に設定する要素の子である場合を除き、既定では 0 です。</span><span class="sxs-lookup"><span data-stu-id="1de27-166">An InkCanvas has default [**Height**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.Height) and [**Width**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.Width) properties of zero, unless it is the child of an element that automatically sizes its child elements.</span></span> 

### <a name="in-the-sample"></a><span data-ttu-id="1de27-167">このサンプルを使って、次を行います:</span><span class="sxs-lookup"><span data-stu-id="1de27-167">In the sample:</span></span>
1. <span data-ttu-id="1de27-168">MainPage.xaml.cs ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="1de27-168">Open the MainPage.xaml.cs file.</span></span>
2. <span data-ttu-id="1de27-169">この手順のタイトル ("// Step 2: Use InkCanvas to support basic inking") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="1de27-169">Find the code marked with the title of this step ("// Step 2: Use InkCanvas to support basic inking").</span></span>
3. <span data-ttu-id="1de27-170">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="1de27-170">Uncomment the following lines.</span></span> <span data-ttu-id="1de27-171">(これらの参照は、これ以降の手順で使用される機能に必要です。)</span><span class="sxs-lookup"><span data-stu-id="1de27-171">(These references are required for the functionality used in the subsequent steps).</span></span>  

``` csharp
    using Windows.UI.Input.Inking;
    using Windows.UI.Input.Inking.Analysis;
    using Windows.UI.Xaml.Shapes;
    using Windows.Storage.Streams;
```

4. <span data-ttu-id="1de27-172">MainPage.xaml ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="1de27-172">Open the MainPage.xaml file.</span></span>
5. <span data-ttu-id="1de27-173">この手順のタイトル ("\<!-- Step 2: Basic inking with InkCanvas -->") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="1de27-173">Find the code marked with the title of this step ("\<!-- Step 2: Basic inking with InkCanvas -->").</span></span>
6. <span data-ttu-id="1de27-174">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="1de27-174">Uncomment the following line.</span></span>  

``` xaml
    <InkCanvas x:Name="inkCanvas" />
```

<span data-ttu-id="1de27-175">以上です。</span><span class="sxs-lookup"><span data-stu-id="1de27-175">That's it!</span></span> 

<span data-ttu-id="1de27-176">では、アプリを再度実行します。</span><span class="sxs-lookup"><span data-stu-id="1de27-176">Now run the app again.</span></span> <span data-ttu-id="1de27-177">何でも自由に書き込んだり、自画像の絵などを描いてみてください。</span><span class="sxs-lookup"><span data-stu-id="1de27-177">Go ahead and scribble, write your name, or (if you're holding a mirror or have a very good memory) draw your self-portrait.</span></span>

![基本的な手描き入力](images/ink/ink-app-step1-name-small.png)

## <a name="step-3-support-inking-with-touch-and-mouse"></a><span data-ttu-id="1de27-179">手順 3: タッチとマウスを使って手描き入力をサポートする</span><span class="sxs-lookup"><span data-stu-id="1de27-179">Step 3: Support inking with touch and mouse</span></span>

<span data-ttu-id="1de27-180">お気付きのように、既定では、インクはペン入力のみをサポートします。</span><span class="sxs-lookup"><span data-stu-id="1de27-180">You'll notice that, by default, ink is supported for pen input only.</span></span> <span data-ttu-id="1de27-181">指、マウス、またはタッチパッドを使って描画することはできません。</span><span class="sxs-lookup"><span data-stu-id="1de27-181">If you try to write or draw with your finger, your mouse, or your touchpad, you'll be disappointed.</span></span>

<span data-ttu-id="1de27-182">それを可能にするには、コードの 2 行目を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1de27-182">To turn that frown upside down , you need to add a second line of code.</span></span> <span data-ttu-id="1de27-183">それは、[**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) を宣言した XAML ファイルのコードビハインドにあります。</span><span class="sxs-lookup"><span data-stu-id="1de27-183">This time it’s in the code-behind for the XAML file in which you declared your [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas).</span></span> 

<span data-ttu-id="1de27-184">この手順では、[**InkPresenter**](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkpresenter) オブジェクトを説明します。このオブジェクトは [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) の手描き入力 (標準および変更) の入力、処理、レンダリングの細かい管理を提供します。</span><span class="sxs-lookup"><span data-stu-id="1de27-184">In this step, we introduce the [**InkPresenter**](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkpresenter) object, which provides finer-grained management of the input, processing, and rendering of ink input (standard and modified) on your [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas).</span></span>

> [!NOTE]
> <span data-ttu-id="1de27-185">標準のインク入力 (ペン先または消しゴムの先端やボタン) は、セカンダリ ハードウェア アフォーダンス (ペン バレル ボタン、マウスの右ボタン、または類似のメカニズムなど) で変更されません。</span><span class="sxs-lookup"><span data-stu-id="1de27-185">Standard ink input (pen tip or eraser tip/button) is not modified with a secondary hardware affordance, such as a pen barrel button, right mouse button, or similar mechanism.</span></span> 

<span data-ttu-id="1de27-186">マウスとタッチによる手描き入力を有効化するには、[**InkPresenter**](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkpresenter) の [**InputDeviceTypes**](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkpresenter.InputDeviceTypes) プロパティを、必要な [**CoreInputDeviceTypes**](https://docs.microsoft.com/uwp/api/windows.ui.core.coreinputdevicetypes) 値の組み合わせに設定します。</span><span class="sxs-lookup"><span data-stu-id="1de27-186">To enable mouse and touch inking, set the [**InputDeviceTypes**](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkpresenter.InputDeviceTypes) property of the [**InkPresenter**](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkpresenter) to the combination of [**CoreInputDeviceTypes**](https://docs.microsoft.com/uwp/api/windows.ui.core.coreinputdevicetypes) values that you want.</span></span>

### <a name="in-the-sample"></a><span data-ttu-id="1de27-187">このサンプルを使って、次を行います:</span><span class="sxs-lookup"><span data-stu-id="1de27-187">In the sample:</span></span>
1. <span data-ttu-id="1de27-188">MainPage.xaml.cs ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="1de27-188">Open the MainPage.xaml.cs file.</span></span>
2. <span data-ttu-id="1de27-189">この手順のタイトル ("// Step 3: Support inking with touch and mouse") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="1de27-189">Find the code marked with the title of this step ("// Step 3: Support inking with touch and mouse").</span></span>
3. <span data-ttu-id="1de27-190">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="1de27-190">Uncomment the following lines.</span></span>  

``` csharp
    inkCanvas.InkPresenter.InputDeviceTypes =
        Windows.UI.Core.CoreInputDeviceTypes.Mouse | 
        Windows.UI.Core.CoreInputDeviceTypes.Touch | 
        Windows.UI.Core.CoreInputDeviceTypes.Pen;
```

<span data-ttu-id="1de27-191">アプリをもう一度実行して、指を使って手描き入力ができることを確認します。</span><span class="sxs-lookup"><span data-stu-id="1de27-191">Run the app again and you'll find that all your finger-painting-on-a-computer-screen dreams have come true!</span></span>

> [!NOTE]
> <span data-ttu-id="1de27-192">入力デバイスの種類を指定する場合は、特定の入力の種類のサポート (ペンを含む) を指定する必要があります。このプロパティの設定は既定の [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) 設定を上書きするためです。</span><span class="sxs-lookup"><span data-stu-id="1de27-192">When specifying input device types, you must indicate support for each specific input type (including pen), because setting this property overrides the default [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) setting.</span></span>

## <a name="step-4-add-an-ink-toolbar"></a><span data-ttu-id="1de27-193">手順 4: インク ツールバーを追加する</span><span class="sxs-lookup"><span data-stu-id="1de27-193">Step 4: Add an ink toolbar</span></span>

<span data-ttu-id="1de27-194">[**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) は、インク関連の機能を有効化するための、カスタマイズと拡張が可能なボタンのコレクションを提供する、UWP プラットフォーム コントロールです。</span><span class="sxs-lookup"><span data-stu-id="1de27-194">The [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) is a UWP platform control that provides a customizable and extensible collection of buttons for activating ink-related features.</span></span> 

<span data-ttu-id="1de27-195">[**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) には、既定では、ボタンの基本的なセットが含まれています。ユーザーはこれを使って、ペン、鉛筆、蛍光ペン、消しゴムをすばやく選択でき、これらはいずれもステンシル (ルーラーまたは分度器) と共に使用できます。</span><span class="sxs-lookup"><span data-stu-id="1de27-195">By default, the [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) includes a basic set of buttons that let users quickly select between a pen, a pencil, a highlighter, or an eraser, any of which can be used together with a stencil (ruler or protractor).</span></span> <span data-ttu-id="1de27-196">ペン、鉛筆、および蛍光ペンのボタンは、インクの色と線のサイズを選択できるポップアップも提供します。</span><span class="sxs-lookup"><span data-stu-id="1de27-196">The pen, pencil, and highlighter buttons each also provide a flyout for selecting ink color and stroke size.</span></span>

<span data-ttu-id="1de27-197">既定の [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) を手描き入力のアプリに追加するには、[**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) と同じページに配置して、2 つのコントロールを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="1de27-197">To add a default [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) to an inking app, just place it on the same page as your [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) and associate the two controls.</span></span>

### <a name="in-the-sample"></a><span data-ttu-id="1de27-198">このサンプルを使って、次を行います:</span><span class="sxs-lookup"><span data-stu-id="1de27-198">In the sample</span></span>
1. <span data-ttu-id="1de27-199">MainPage.xaml ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="1de27-199">Open the MainPage.xaml file.</span></span>
2. <span data-ttu-id="1de27-200">この手順のタイトル ("\<!-- Step 4: Add an ink toolbar -->") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="1de27-200">Find the code marked with the title of this step ("\<!-- Step 4: Add an ink toolbar -->").</span></span>
3. <span data-ttu-id="1de27-201">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="1de27-201">Uncomment the following lines.</span></span>  

``` xaml
    <InkToolbar x:Name="inkToolbar" 
                        VerticalAlignment="Top" 
                        Margin="10,0,10,0"
                        TargetInkCanvas="{x:Bind inkCanvas}">
    </InkToolbar>
```

> [!NOTE]
> <span data-ttu-id="1de27-202">UI とコードをなるべくクリーンでシンプルにするため、基本的なグリッド レイアウトを使って、グリッド行で [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) の後で、[**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) を宣言します。</span><span class="sxs-lookup"><span data-stu-id="1de27-202">To keep the UI and code as uncluttered and simple as possible, we use a basic Grid layout and declare the [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) after the [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) in a grid row.</span></span> <span data-ttu-id="1de27-203">[**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) の前で宣言すると、キャンバスの下で [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) が先にレンダリングされ、ユーザーはアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="1de27-203">If you declare it before the [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas), the [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) is rendered first, below the canvas and inaccessible to the user.</span></span>  

<span data-ttu-id="1de27-204">アプリを再度実行し、[**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) が表示されることを確認してツールを試します。</span><span class="sxs-lookup"><span data-stu-id="1de27-204">Now run the app again to see the [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) and try out some of the tools.</span></span>

![Windows Ink ワークスペースのスケッチパッドの InkToolbar](images/ink/ink-inktoolbar-default-small.png)

### <a name="challenge-add-a-custom-button"></a><span data-ttu-id="1de27-206">課題: カスタム ボタンを追加する</span><span class="sxs-lookup"><span data-stu-id="1de27-206">Challenge: Add a custom button</span></span>
<table class="wdg-noborder">
<tr>
<td>

![Windows Ink ワークスペースのスケッチパッドの InkToolbar](images/challenge-icon.png)

</td>
<td>

<span data-ttu-id="1de27-208">カスタムの **[InkToolbar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar)** の例 (Windows Ink ワークスペースのスケッチパッド) を示します。</span><span class="sxs-lookup"><span data-stu-id="1de27-208">Here's an example of a custom **[InkToolbar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar)** (from Sketchpad in the Windows Ink Workspace).</span></span>

![Windows Ink ワークスペースのスケッチパッドの InkToolbar](images/ink/ink-inktoolbar-sketchpad-small.png)

<span data-ttu-id="1de27-210">[InkToolbar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) のカスタマイズについて詳しくは、[「InkToolbar をユニバーサル Windows プラットフォーム (UWP) 手描き入力アプリに追加する」](ink-toolbar.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1de27-210">For more details about customizing an [InkToolbar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar), see [Add an InkToolbar to a Universal Windows Platform (UWP) inking app](ink-toolbar.md).</span></span>

</td>
</tr>
</table>

## <a name="step-5-support-handwriting-recognition"></a><span data-ttu-id="1de27-211">手順 5: 手書き認識をサポートする</span><span class="sxs-lookup"><span data-stu-id="1de27-211">Step 5: Support handwriting recognition</span></span>

<span data-ttu-id="1de27-212">これでアプリで手描きや描画ができるようになりました。これを使って、さらに便利な機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="1de27-212">Now that you can write and draw in your app, let's try to do something useful with those scribbles.</span></span>

<span data-ttu-id="1de27-213">この手順では、Windows Ink の手書き認識機能を使用して、手描き入力を解読します。</span><span class="sxs-lookup"><span data-stu-id="1de27-213">In this step, we use the handwriting recognition features of Windows Ink to try to decipher what you've written.</span></span>

> [!NOTE]
> <span data-ttu-id="1de27-214">手書き認識は [**ペンと Windows Ink**] の設定を使って改善できます。</span><span class="sxs-lookup"><span data-stu-id="1de27-214">Handwriting recognition can be improved through the **Pen & Windows Ink** settings:</span></span>
> 1. <span data-ttu-id="1de27-215">スタート メニューを開き、[**設定**] を選択します。</span><span class="sxs-lookup"><span data-stu-id="1de27-215">Open the Start menu and select **Settings**.</span></span>
> 2. <span data-ttu-id="1de27-216">設定画面から [**デバイス**] > [**ペンと Windows Ink**] を選択します。</span><span class="sxs-lookup"><span data-stu-id="1de27-216">From the Settings screen select **Devices** > **Pen & Windows Ink**.</span></span>
> ![Windows Ink ワークスペースのスケッチパッドの InkToolbar](images/ink/ink-settings-small.png)
> 3. <span data-ttu-id="1de27-218">[**手書き入力を認識します**] を選択して、[**手書き認識の個人用設定**] ダイアログを開きます。</span><span class="sxs-lookup"><span data-stu-id="1de27-218">Select **Get to know my handwriting** to open the **Handwriting Personalization** dialog.</span></span>
> ![Windows Ink ワークスペースのスケッチパッドの InkToolbar](images/ink/ink-settings-handwritingpersonalization-small.png)

### <a name="in-the-sample"></a><span data-ttu-id="1de27-220">このサンプルを使って、次を行います:</span><span class="sxs-lookup"><span data-stu-id="1de27-220">In the sample:</span></span>
1. <span data-ttu-id="1de27-221">MainPage.xaml ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="1de27-221">Open the MainPage.xaml file.</span></span>
2. <span data-ttu-id="1de27-222">この手順のタイトル ("\<!-- Step 5: Support handwriting recognition -->") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="1de27-222">Find the code marked with the title of this step ("\<!-- Step 5: Support handwriting recognition -->").</span></span>
3. <span data-ttu-id="1de27-223">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="1de27-223">Uncomment the following lines.</span></span>  

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

4. <span data-ttu-id="1de27-224">MainPage.xaml.cs ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="1de27-224">Open the MainPage.xaml.cs file.</span></span>
5. <span data-ttu-id="1de27-225">この手順のタイトル  (" Step 5: Support handwriting recognition") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="1de27-225">Find the code marked with the title of this step (" Step 5: Support handwriting recognition").</span></span>
6. <span data-ttu-id="1de27-226">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="1de27-226">Uncomment the following lines.</span></span>  

- <span data-ttu-id="1de27-227">これらは、この手順で必要なグローバル変数です。</span><span class="sxs-lookup"><span data-stu-id="1de27-227">These are the global variables required for this step.</span></span>

``` csharp
    InkAnalyzer analyzerText = new InkAnalyzer();
    IReadOnlyList<InkStroke> strokesText = null;
    InkAnalysisResult resultText = null;
    IReadOnlyList<IInkAnalysisNode> words = null;
```

- <span data-ttu-id="1de27-228">これは、[**Recognize text**] (テキストの認識) ボタンのハンドラーで、これにより認識処理を行います。</span><span class="sxs-lookup"><span data-stu-id="1de27-228">This is the handler for the **Recognize text** button, where we do the recognition processing.</span></span>

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

7. <span data-ttu-id="1de27-229">アプリを再び実行し、何かを書き込んで、[**Recognize text**] (テキストの認識) ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="1de27-229">Run the app again, write something, and then click the **Recognize text** button</span></span>
8. <span data-ttu-id="1de27-230">認識の結果は、ボタンの横に表示されます。</span><span class="sxs-lookup"><span data-stu-id="1de27-230">The results of the recognition are displayed beside the button</span></span>

### <a name="challenge-1-international-recognition"></a><span data-ttu-id="1de27-231">課題1: 地域と言語の認識</span><span class="sxs-lookup"><span data-stu-id="1de27-231">Challenge 1: International recognition</span></span>
<table class="wdg-noborder">
<tr>
<td>

![Windows Ink ワークスペースのスケッチパッドの InkToolbar](images/challenge-icon.png)

</td>
<td>

<span data-ttu-id="1de27-233">Windows Ink は、Windowsでサポートされている多くの言語のテキスト認識をサポートします。</span><span class="sxs-lookup"><span data-stu-id="1de27-233">Windows Ink supports text recognition for many of the of the languages supported by Windows.</span></span> <span data-ttu-id="1de27-234">各言語パックには、言語パックと共にインストールできる、手書き認識エンジンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="1de27-234">Each language pack includes a handwriting recognition engine that can be installed with the language pack.</span></span>

<span data-ttu-id="1de27-235">インストール済みの手書き認識エンジンにクエリを行って、特定の言語をターゲットにします。</span><span class="sxs-lookup"><span data-stu-id="1de27-235">Target a specific language by querying the installed handwriting recognition engines.</span></span>

<span data-ttu-id="1de27-236">地域と言語の手書き認識について詳しくは、「[Windows Ink でのストロークのテキスト認識](convert-ink-to-text.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1de27-236">For more details about international handwriting recognition, see [Recognize Windows Ink strokes as text](convert-ink-to-text.md).</span></span>

</td>
</tr>
</table>

### <a name="challenge-2-dynamic-recognition"></a><span data-ttu-id="1de27-237">課題 2: 動的な認識</span><span class="sxs-lookup"><span data-stu-id="1de27-237">Challenge 2: Dynamic recognition</span></span>
<table class="wdg-noborder">
<tr>
<td>

![Windows Ink ワークスペースのスケッチパッドの InkToolbar](images/challenge-icon.png)

</td>
<td>

<span data-ttu-id="1de27-239">このチュートリアルでは、認識を開始するためにボタンを押す必要があります。</span><span class="sxs-lookup"><span data-stu-id="1de27-239">For this tutorial, we require that a button be pressed to initiate recognition.</span></span> <span data-ttu-id="1de27-240">基本的なタイミング関数を使って、動的な認識を実行することもできます。</span><span class="sxs-lookup"><span data-stu-id="1de27-240">You can also perform dynamic recognition by using a basic timing function.</span></span>

<span data-ttu-id="1de27-241">動的な認識について詳しくは、「[Windows Ink でのストロークのテキスト認識](convert-ink-to-text.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1de27-241">For more details about dynamic recognition, see [Recognize Windows Ink strokes as text](convert-ink-to-text.md).</span></span>

</td>
</tr>
</table>

## <a name="step-6-recognize-shapes"></a><span data-ttu-id="1de27-242">手順 6: 図形を認識する</span><span class="sxs-lookup"><span data-stu-id="1de27-242">Step 6: Recognize shapes</span></span>

<span data-ttu-id="1de27-243">これで手書きのメモを判読可能なものに変換できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="1de27-243">Ok, so now you can convert your handwritten notes into something a little more legible.</span></span> <span data-ttu-id="1de27-244">では、手書きのフローチャートなどを認識することはできるでしょうか。</span><span class="sxs-lookup"><span data-stu-id="1de27-244">But what about those shaky, caffeinated doodles from your morning Flowcharters Anonymous meeting?</span></span>

<span data-ttu-id="1de27-245">インクの分析を使うと、アプリは次のような基本的な図形を認識することができます。</span><span class="sxs-lookup"><span data-stu-id="1de27-245">Using ink analysis, your app can also recognize a set of core shapes, including:</span></span>

- <span data-ttu-id="1de27-246">円形</span><span class="sxs-lookup"><span data-stu-id="1de27-246">Circle</span></span>
- <span data-ttu-id="1de27-247">ひし形</span><span class="sxs-lookup"><span data-stu-id="1de27-247">Diamond</span></span>
- <span data-ttu-id="1de27-248">線</span><span class="sxs-lookup"><span data-stu-id="1de27-248">Drawing</span></span>
- <span data-ttu-id="1de27-249">楕円形</span><span class="sxs-lookup"><span data-stu-id="1de27-249">Ellipse</span></span>
- <span data-ttu-id="1de27-250">正三角形</span><span class="sxs-lookup"><span data-stu-id="1de27-250">EquilateralTriangle</span></span>
- <span data-ttu-id="1de27-251">六角形</span><span class="sxs-lookup"><span data-stu-id="1de27-251">Hexagon</span></span>
- <span data-ttu-id="1de27-252">二等辺三角形</span><span class="sxs-lookup"><span data-stu-id="1de27-252">IsoscelesTriangle</span></span>
- <span data-ttu-id="1de27-253">平行四辺形</span><span class="sxs-lookup"><span data-stu-id="1de27-253">Parallelogram</span></span>
- <span data-ttu-id="1de27-254">五角形</span><span class="sxs-lookup"><span data-stu-id="1de27-254">Pentagon</span></span>
- <span data-ttu-id="1de27-255">四辺形</span><span class="sxs-lookup"><span data-stu-id="1de27-255">Quadrilateral</span></span>
- <span data-ttu-id="1de27-256">長方形</span><span class="sxs-lookup"><span data-stu-id="1de27-256">Rectangle</span></span>
- <span data-ttu-id="1de27-257">直角三角形</span><span class="sxs-lookup"><span data-stu-id="1de27-257">RightTriangle</span></span>
- <span data-ttu-id="1de27-258">正方形</span><span class="sxs-lookup"><span data-stu-id="1de27-258">Square</span></span>
- <span data-ttu-id="1de27-259">台形</span><span class="sxs-lookup"><span data-stu-id="1de27-259">Trapezoid</span></span>
- <span data-ttu-id="1de27-260">三角形</span><span class="sxs-lookup"><span data-stu-id="1de27-260">Triangle</span></span>

<span data-ttu-id="1de27-261">この手順では、Windows Ink の図形認識機能を使用して、手書きの図形をクリーンにします。</span><span class="sxs-lookup"><span data-stu-id="1de27-261">In this step, we use the shape-recognition features of Windows Ink to try to clean up your doodles.</span></span>

<span data-ttu-id="1de27-262">この例では、インク ストロークの再描画は (可能ですが) 行いません。</span><span class="sxs-lookup"><span data-stu-id="1de27-262">For this example, we don't attempt to redraw ink strokes (although that's possible).</span></span> <span data-ttu-id="1de27-263">代わりに、InkCanvas の下に標準のキャンバスを追加し、元の手書き図形から作成された、楕円や多角形オブジェクトをそこに描画します。</span><span class="sxs-lookup"><span data-stu-id="1de27-263">Instead, we add a standard canvas under the InkCanvas where we draw equivalent Ellipse or Polygon objects derived from the original ink.</span></span> <span data-ttu-id="1de27-264">次に、対応するインク ストロークを削除します。</span><span class="sxs-lookup"><span data-stu-id="1de27-264">We then delete the corresponding ink strokes.</span></span>

### <a name="in-the-sample"></a><span data-ttu-id="1de27-265">このサンプルを使って、次を行います:</span><span class="sxs-lookup"><span data-stu-id="1de27-265">In the sample:</span></span>
1. <span data-ttu-id="1de27-266">MainPage.xaml ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="1de27-266">Open the MainPage.xaml file</span></span>
2. <span data-ttu-id="1de27-267">この手順のタイトル ("\<!-- Step 6: Recognize shapes -->") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="1de27-267">Find the code marked with the title of this step ("\<!-- Step 6: Recognize shapes -->")</span></span>
3. <span data-ttu-id="1de27-268">この行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="1de27-268">Uncomment this line.</span></span>  

``` xaml
   <Canvas x:Name="canvas" />

   And these lines.

    <Button Grid.Row="1" x:Name="recognizeShape" Click="recognizeShape_ClickAsync"
        Content="Recognize shape" 
        Margin="10,10,10,10" />
```

4. <span data-ttu-id="1de27-269">MainPage.xaml.cs ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="1de27-269">Open the MainPage.xaml.cs file</span></span>
5. <span data-ttu-id="1de27-270">この手順のタイトル ("// Step 6: Recognize shapes") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="1de27-270">Find the code marked with the title of this step ("// Step 6: Recognize shapes")</span></span>
6. <span data-ttu-id="1de27-271">これらの行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="1de27-271">Uncomment these lines:</span></span>  

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

7. <span data-ttu-id="1de27-272">アプリを実行し、いくつかの図形を描画して、[**Recognize shape**] (図形の認識) ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="1de27-272">Run the app, draw some shapes, and click the **Recognize shape** button</span></span>

<span data-ttu-id="1de27-273">デジタルの走り書きを使った、基本的なフローチャートの例を示します。</span><span class="sxs-lookup"><span data-stu-id="1de27-273">Here's an example of a rudimentary flowchart from a digital napkin.</span></span>

![元のインクのフローチャート](images/ink/ink-app-step6-shapereco1-small.png)

<span data-ttu-id="1de27-275">図形認識後の同じフローチャートを次に示します。</span><span class="sxs-lookup"><span data-stu-id="1de27-275">Here's the same flowchart after shape recognition.</span></span>

![元のインクのフローチャート](images/ink/ink-app-step6-shapereco2-small.png)


## <a name="step-7-save-and-load-ink"></a><span data-ttu-id="1de27-277">手順 7: インクの保存と読み込み</span><span class="sxs-lookup"><span data-stu-id="1de27-277">Step 7: Save and load ink</span></span>

<span data-ttu-id="1de27-278">手書きの文字や図形の認識ができるようになりましたが、それらを後から使いたい場合にはどうすればよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="1de27-278">So, you're done doodling and you like what you see, but think you might like to tweak a couple of things later?</span></span> <span data-ttu-id="1de27-279">インク ストロークを Ink Serialized Format (ISF) ファイルに保存し、後でそれを読み込んで編集することができます。</span><span class="sxs-lookup"><span data-stu-id="1de27-279">You can save your ink strokes to an Ink Serialized Format (ISF) file and load them for editing whenever the inspiration strikes.</span></span> 

<span data-ttu-id="1de27-280">ISF ファイルは、インク ストロークのプロパティと動作に関する追加のメタデータを含む、基本的な GIF 画像です。</span><span class="sxs-lookup"><span data-stu-id="1de27-280">The ISF file is a basic GIF image that includes additional metadata describing ink-stroke properties and behaviors.</span></span> <span data-ttu-id="1de27-281">インク対応でないアプリでは、追加のメタデータを無視して、基本的な GIF 画像 (アルファ チャンネルの背景の透明度を含む) を読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="1de27-281">Apps that are not ink enabled can ignore the extra metadata and still load the basic GIF image (including alpha-channel background transparency).</span></span>

<span data-ttu-id="1de27-282">この手順では、インク ツールバーの横にある、[**保存**] と [**読み込み**] ボタンをフックします。</span><span class="sxs-lookup"><span data-stu-id="1de27-282">In this step, we hook up the **Save** and **Load** buttons located beside the ink toolbar.</span></span>

### <a name="in-the-sample"></a><span data-ttu-id="1de27-283">このサンプルを使って、次を行います:</span><span class="sxs-lookup"><span data-stu-id="1de27-283">In the sample:</span></span>
1. <span data-ttu-id="1de27-284">MainPage.xaml ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="1de27-284">Open the MainPage.xaml file.</span></span>
2. <span data-ttu-id="1de27-285">この手順のタイトル ("\<!-- Step 7: Saving and loading ink -->") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="1de27-285">Find the code marked with the title of this step ("\<!-- Step 7: Saving and loading ink -->").</span></span>
3. <span data-ttu-id="1de27-286">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="1de27-286">Uncomment the following lines.</span></span> 

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

4. <span data-ttu-id="1de27-287">MainPage.xaml.cs ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="1de27-287">Open the MainPage.xaml.cs file.</span></span>
5. <span data-ttu-id="1de27-288">この手順のタイトル ("// Step 7: Save and load ink") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="1de27-288">Find the code marked with the title of this step ("// Step 7: Save and load ink").</span></span>
6. <span data-ttu-id="1de27-289">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="1de27-289">Uncomment the following lines.</span></span>  

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

7. <span data-ttu-id="1de27-290">アプリを実行し、何かを描画します。</span><span class="sxs-lookup"><span data-stu-id="1de27-290">Run the app and draw something.</span></span>
8. <span data-ttu-id="1de27-291">[**保存**] ボタンを選択し、描画を保存します。</span><span class="sxs-lookup"><span data-stu-id="1de27-291">Select the **Save** button and save your drawing.</span></span>
9. <span data-ttu-id="1de27-292">インクを消去するか、またはアプリを再起動します。</span><span class="sxs-lookup"><span data-stu-id="1de27-292">Erase the ink or restart the app.</span></span>
10. <span data-ttu-id="1de27-293">[**読み込み**] ボタンを選択して、保存したインク ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="1de27-293">Select the **Load** button and open the ink file you just saved.</span></span>

### <a name="challenge-use-the-clipboard-to-copy-and-paste-ink-strokes"></a><span data-ttu-id="1de27-294">課題: クリップボードを使って、インク ストロークをコピーして貼り付ける</span><span class="sxs-lookup"><span data-stu-id="1de27-294">Challenge: Use the clipboard to copy and paste ink strokes</span></span> 
<table class="wdg-noborder">
<tr>
<td>

![Windows Ink ワークスペースのスケッチパッドの InkToolbar](images/challenge-icon.png)

</td>

<td>

<span data-ttu-id="1de27-296">Windows Ink は、インク ストロークのクリップボードへのコピーと貼り付けもサポートしています。</span><span class="sxs-lookup"><span data-stu-id="1de27-296">Windows ink also supports copying and pasting ink strokes to and from the clipboard.</span></span>

<span data-ttu-id="1de27-297">Windows Ink とクリップボードの使用について詳しくは、「[Windows Ink ストローク データの保存と取得](save-and-load-ink.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1de27-297">For more details about using the clipboard with ink, see [Store and retrieve Windows Ink stroke data](save-and-load-ink.md).</span></span>

</td>
</tr>
</table>

## <a name="summary"></a><span data-ttu-id="1de27-298">まとめ</span><span class="sxs-lookup"><span data-stu-id="1de27-298">Summary</span></span>

<span data-ttu-id="1de27-299">これで、**入力: UWP アプリでインクをサポートする**チュートリアルは完了です。</span><span class="sxs-lookup"><span data-stu-id="1de27-299">Congratulations, you've completed the **Input: Support ink in your UWP app** tutorial !</span></span> <span data-ttu-id="1de27-300">UWP アプリでインクをサポートするために必要な基本的なコードについて説明しました。また Windows Ink プラットフォームでサポートされる、優れたユーザー エクスペリエンスを提供する方法を説明しました。</span><span class="sxs-lookup"><span data-stu-id="1de27-300">We showed you the basic code required for supporting ink in your UWP apps, and how to provide some of the richer user experiences supported by the Windows Ink platform.</span></span>

## <a name="related-articles"></a><span data-ttu-id="1de27-301">関連記事</span><span class="sxs-lookup"><span data-stu-id="1de27-301">Related articles</span></span>

* [<span data-ttu-id="1de27-302">UWP アプリでのペン操作と Windows Ink</span><span class="sxs-lookup"><span data-stu-id="1de27-302">Pen interactions and Windows Ink in UWP apps</span></span>](pen-and-stylus-interactions.md)

### <a name="samples"></a><span data-ttu-id="1de27-303">サンプル</span><span class="sxs-lookup"><span data-stu-id="1de27-303">Samples</span></span>

* [<span data-ttu-id="1de27-304">インクの分析のサンプル (基本) (C#)</span><span class="sxs-lookup"><span data-stu-id="1de27-304">Ink analysis sample (basic) (C#)</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-analysis-basic.zip)
* [<span data-ttu-id="1de27-305">インクの手書き認識のサンプル (C#)</span><span class="sxs-lookup"><span data-stu-id="1de27-305">Ink handwriting recognition sample (C#)</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-handwriting-reco.zip)
* [<span data-ttu-id="1de27-306">インク ストロークを Ink Serialized Format (ISF) ファイルに保存し、読み込む</span><span class="sxs-lookup"><span data-stu-id="1de27-306">Save and load ink strokes from an Ink Serialized Format (ISF) file</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store.zip)
* [<span data-ttu-id="1de27-307">インク ストロークをクリップボードに保存し、読み込む</span><span class="sxs-lookup"><span data-stu-id="1de27-307">Save and load ink strokes from the clipboard</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-store-clipboard.zip)
* [<span data-ttu-id="1de27-308">インク ツール バーの位置と向きのサンプル (基本)</span><span class="sxs-lookup"><span data-stu-id="1de27-308">Ink toolbar location and orientation sample (basic)</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-toolbar-handedness.zip)
* [<span data-ttu-id="1de27-309">インク ツール バーの位置と向きのサンプル (動的)</span><span class="sxs-lookup"><span data-stu-id="1de27-309">Ink toolbar location and orientation sample (dynamic)</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-toolbar-handedness-dynamic.zip)
* [<span data-ttu-id="1de27-310">単純なインクのサンプル (C#/C++)</span><span class="sxs-lookup"><span data-stu-id="1de27-310">Simple ink sample (C#/C++)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620312)
* [<span data-ttu-id="1de27-311">複雑なインクのサンプル (C++)</span><span class="sxs-lookup"><span data-stu-id="1de27-311">Complex ink sample (C++)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620314)
* [<span data-ttu-id="1de27-312">インクのサンプル (JavaScript)</span><span class="sxs-lookup"><span data-stu-id="1de27-312">Ink sample (JavaScript)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620308)
* [<span data-ttu-id="1de27-313">入門チュートリアル: UWP アプリでのインクのサポート</span><span class="sxs-lookup"><span data-stu-id="1de27-313">Get Started Tutorial: Support ink in your UWP app</span></span>](https://aka.ms/appsample-ink)
* [<span data-ttu-id="1de27-314">塗り絵帳のサンプル</span><span class="sxs-lookup"><span data-stu-id="1de27-314">Coloring book sample</span></span>](https://aka.ms/cpubsample-coloringbook)
* [<span data-ttu-id="1de27-315">Family Notes のサンプル</span><span class="sxs-lookup"><span data-stu-id="1de27-315">Family notes sample</span></span>](https://aka.ms/cpubsample-familynotessample)
