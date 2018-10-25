---
author: Karl-Bridge-Microsoft
ms.assetid: ''
title: UWP アプリで Surface Dial (およびその他のホイール デバイス) をサポートする
description: 作成した UWP アプリに Surface Dial (およびその他のホイール デバイス) のサポートを追加するための、ステップ バイ ステップ チュートリアルです。
keywords: ダイヤル, ラジアル, チュートリアル
ms.author: kbridge
ms.date: 01/25/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: c7dc6436e1a233a6b0a74a787b5c30de47899eff
ms.sourcegitcommit: 2c4daa36fb9fd3e8daa83c2bd0825f3989d24be8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5521150"
---
# <a name="tutorial-support-the-surface-dial-and-other-wheel-devices-in-your-uwp-app"></a><span data-ttu-id="a671b-104">チュートリアル: UWP アプリで Surface Dial (およびその他のホイール デバイス) をサポートする</span><span class="sxs-lookup"><span data-stu-id="a671b-104">Tutorial: Support the Surface Dial (and other wheel devices) in your UWP app</span></span>

![Surface Dial と Surface Studio の画像](images/radialcontroller/dial-pen-studio-600px.png)  
<span data-ttu-id="a671b-106">*Surface Dial と Surface Studio、Surface ペン* ([Microsoft ストア](https://aka.ms/purchasesurfacedial)で購入できます)。</span><span class="sxs-lookup"><span data-stu-id="a671b-106">*Surface Dial with Surface Studio and Surface Pen* (available for purchase at the [Microsoft Store](https://aka.ms/purchasesurfacedial)).</span></span>

<span data-ttu-id="a671b-107">このチュートリアルでは、Surface Dial などのホイール デバイスでサポートされている、ユーザー操作エクスペリエンスをカスタマイズする手順を示します。</span><span class="sxs-lookup"><span data-stu-id="a671b-107">This tutorial steps through how to customize the user interaction experiences supported by wheel devices such as the Surface Dial.</span></span> <span data-ttu-id="a671b-108">使用するサンプル アプリは GitHub ([サンプル コード](#sample-code)) からダウンロードできます。このサンプル アプリのスニペットは、各手順でのさまざまな機能と関連する [**RadialController**](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller) API の使い方を示します。</span><span class="sxs-lookup"><span data-stu-id="a671b-108">We use snippets from a sample app, which you can download from GitHub (see [Sample code](#sample-code)), to demonstrate the various features and associated [**RadialController**](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller) APIs discussed in each step.</span></span>

<span data-ttu-id="a671b-109">次の点を中心に説明します。</span><span class="sxs-lookup"><span data-stu-id="a671b-109">We focus on the following:</span></span>
* <span data-ttu-id="a671b-110">[**RadialController**](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller) メニューに表示される組み込みのツールを指定する</span><span class="sxs-lookup"><span data-stu-id="a671b-110">Specifying which built-in tools are displayed on the [**RadialController**](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller) menu</span></span>
* <span data-ttu-id="a671b-111">メニューにカスタム ツールを追加する</span><span class="sxs-lookup"><span data-stu-id="a671b-111">Adding a custom tool to the menu</span></span>
* <span data-ttu-id="a671b-112">触覚フィードバックを制御する</span><span class="sxs-lookup"><span data-stu-id="a671b-112">Controlling haptic feedback</span></span>
* <span data-ttu-id="a671b-113">クリック操作をカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="a671b-113">Customizing click interactions</span></span>
* <span data-ttu-id="a671b-114">回転操作をカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="a671b-114">Customizing rotation interactions</span></span>

<span data-ttu-id="a671b-115">これらおよびその他の機能の実装について詳しくは、「[UWP アプリでの Surface Dial の操作](windows-wheel-interactions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a671b-115">For more about implementing these and other features, see [Surface Dial interactions in UWP apps](windows-wheel-interactions.md).</span></span>

## <a name="introduction"></a><span data-ttu-id="a671b-116">概要</span><span class="sxs-lookup"><span data-stu-id="a671b-116">Introduction</span></span>

<span data-ttu-id="a671b-117">Surface Dial は、ペン、タッチ、マウスなどの主要な入力デバイスと共に使ってユーザーの生産性を向上させるための、セカンダリ入力デバイスです。</span><span class="sxs-lookup"><span data-stu-id="a671b-117">The Surface Dial is a secondary input device that helps users to be more productive when used together with a primary input device such as pen, touch, or mouse.</span></span> <span data-ttu-id="a671b-118">Dial は、セカンダリ入力デバイスとして、通常は利き手以外の手で使用し、システム コマンドおよびその他のコンテキスト依存のツールや機能へのアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="a671b-118">As a secondary input device, the Dial is typically used with the non-dominant hand to provide access both to system commands and to other, more contextual, tools and functionality.</span></span> 

<span data-ttu-id="a671b-119">Dial は、次の 3 つの基本的なジェスチャをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="a671b-119">The Dial supports three basic gestures:</span></span> 
- <span data-ttu-id="a671b-120">長押しすると、組み込みのコマンド メニューを表示します。</span><span class="sxs-lookup"><span data-stu-id="a671b-120">Press and hold to display the built-in menu of commands.</span></span>
- <span data-ttu-id="a671b-121">回転させると、(メニューがアクティブな場合は) メニュー項目を強調表示します。(メニューがアクティブでない場合は) アプリの現在の動作を変更します。</span><span class="sxs-lookup"><span data-stu-id="a671b-121">Rotate to highlight a menu item (if the menu is active) or to modify the current action in the app (if the menu is not active).</span></span>
- <span data-ttu-id="a671b-122">クリックすると、(メニューがアクティブな場合は) 強調表示されたメニュー項目を選択します。(メニューがアクティブでない場合は) アプリのコマンドを起動します。</span><span class="sxs-lookup"><span data-stu-id="a671b-122">Click to select the highlighted menu item (if the menu is active) or to invoke a command in the app (if the menu is not active).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="a671b-123">前提条件</span><span class="sxs-lookup"><span data-stu-id="a671b-123">Prerequisites</span></span>

* <span data-ttu-id="a671b-124">Windows 10 Creators Update またはそれ以降を実行しているコンピューター (または、仮想マシン)</span><span class="sxs-lookup"><span data-stu-id="a671b-124">A computer (or a virtual machine) running Windows 10 Creators Update, or newer</span></span>
* [<span data-ttu-id="a671b-125">Visual Studio 2017 (10.0.15063.0)</span><span class="sxs-lookup"><span data-stu-id="a671b-125">Visual Studio 2017 (10.0.15063.0)</span></span>](https://developer.microsoft.com/windows/downloads)
* [<span data-ttu-id="a671b-126">Windows 10 SDK (10.0.15063.0)</span><span class="sxs-lookup"><span data-stu-id="a671b-126">Windows10 SDK (10.0.15063.0)</span></span>](https://developer.microsoft.com/windows/downloads/windows-10-sdk)
* <span data-ttu-id="a671b-127">ホイール デバイス (現時点では [Surface Dial](https://aka.ms/purchasesurfacedial) のみ)</span><span class="sxs-lookup"><span data-stu-id="a671b-127">A wheel device (only the [Surface Dial](https://aka.ms/purchasesurfacedial) at this time)</span></span>
* <span data-ttu-id="a671b-128">Visual Studio を使ってユニバーサル Windows プラットフォーム (UWP) アプリの開発を初めて行う場合は、このチュートリアルを開始する前に、次のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a671b-128">If you're new to Universal Windows Platform (UWP) app development with Visual Studio, have a look through these topics before you start this tutorial:</span></span>  
    * [<span data-ttu-id="a671b-129">準備</span><span class="sxs-lookup"><span data-stu-id="a671b-129">Get set up</span></span>](https://docs.microsoft.com/windows/uwp/get-started/get-set-up)
    * [<span data-ttu-id="a671b-130">"Hello, world" アプリを作成する (XAML)</span><span class="sxs-lookup"><span data-stu-id="a671b-130">Create a "Hello, world" app (XAML)</span></span>](https://docs.microsoft.com/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)

## <a name="set-up-your-devices"></a><span data-ttu-id="a671b-131">デバイスをセットアップする</span><span class="sxs-lookup"><span data-stu-id="a671b-131">Set up your devices</span></span>

1. <span data-ttu-id="a671b-132">Windows デバイスがオンになっていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="a671b-132">Make sure your Windows device is on.</span></span>
2. <span data-ttu-id="a671b-133">[**スタート**] に移動し、[**設定**] > [**デバイス]** > [**Bluetooth とその他のデバイス**] の順に選択して、[**Bluetooth**] をオンにします。</span><span class="sxs-lookup"><span data-stu-id="a671b-133">Go to **Start**, select **Settings** > **Devices** > **Bluetooth & other devices**, and then turn **Bluetooth** on.</span></span>
3. <span data-ttu-id="a671b-134">Surface Dial の下部のバッテリ収納部を開き、単 4 電池が 2 本入っていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="a671b-134">Remove the bottom of the Surface Dial to open the battery compartment, and make sure that there are two AAA batteries inside.</span></span>
4. <span data-ttu-id="a671b-135">Dial の底面にバッテリのタブが残っている場合には、それを取り外します。</span><span class="sxs-lookup"><span data-stu-id="a671b-135">If the battery tab is present on the underside of the Dial, remove it.</span></span>
5. <span data-ttu-id="a671b-136">バッテリの横にある小さな押しボタンを、Bluetooth のライトが点滅するまで長押しします。</span><span class="sxs-lookup"><span data-stu-id="a671b-136">Press and hold the small, inset button next to the batteries until the Bluetooth light flashes.</span></span>
6. <span data-ttu-id="a671b-137">Windows デバイスに戻り、[**Bluetooth またはその他のデバイスを追加する**] を選びます。</span><span class="sxs-lookup"><span data-stu-id="a671b-137">Go back to your Windows device and select **Add Bluetooth or other device**.</span></span>
7. <span data-ttu-id="a671b-138">[**デバイスの追加**] ダイアログ ボックスで、[**Bluetooth**] > [**Surface Dial**] の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="a671b-138">In the **Add a device** dialog, select **Bluetooth** > **Surface Dial**.</span></span> <span data-ttu-id="a671b-139">Surface Dial が接続されて、[**Bluetooth とその他のデバイス**] 設定ページの [**マウス、キーボード、ペン**] の下のデバイスの一覧に追加されます。</span><span class="sxs-lookup"><span data-stu-id="a671b-139">Your Surface Dial should now connect and be added to the list of devices under **Mouse, keyboard, & pen** on the **Bluetooth & other devices** settings page.</span></span>
8. <span data-ttu-id="a671b-140">Dial を数秒ほど長押しして、組み込みのメニューが表示されるかどうかテストします。</span><span class="sxs-lookup"><span data-stu-id="a671b-140">Test the Dial by pressing and holding it down for a few seconds to display the built-in menu.</span></span>
9. <span data-ttu-id="a671b-141">(Dial ダイヤルはバイブレーションします)、画面にメニューが表示されない場合は、Bluetooth の設定に戻すには、デバイスを削除し、もう一度デバイスを接続してみてくださいに移動します。</span><span class="sxs-lookup"><span data-stu-id="a671b-141">If the menu isn't displayed on your screen (the Dial should also vibrate), go back to the Bluetooth settings, remove the device, and try connecting the device again.</span></span>

> [!NOTE]
> <span data-ttu-id="a671b-142">ホイール デバイスは [**ホイール**] 設定から構成できます。</span><span class="sxs-lookup"><span data-stu-id="a671b-142">Wheel devices can be configured through the **Wheel** settings:</span></span>
> 1. <span data-ttu-id="a671b-143">[**スタート**] メニューで [**設定**] を選びます。</span><span class="sxs-lookup"><span data-stu-id="a671b-143">On the **Start** menu, select **Settings**.</span></span>
> 2. <span data-ttu-id="a671b-144">[**デバイス**] > [**ホイール**] の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="a671b-144">Select **Devices** > **Wheel**.</span></span>    
> ![ホイール設定画面](images/radialcontroller/wheel-settings.png)

<span data-ttu-id="a671b-146">これでチュートリアルを開始する準備ができました。</span><span class="sxs-lookup"><span data-stu-id="a671b-146">Now you’re ready to start this tutorial.</span></span> 

## <a name="sample-code"></a><span data-ttu-id="a671b-147">サンプル コード</span><span class="sxs-lookup"><span data-stu-id="a671b-147">Sample code</span></span>
<span data-ttu-id="a671b-148">このチュートリアル全体で、1 つサンプル アプリを使って概念と機能を説明します。</span><span class="sxs-lookup"><span data-stu-id="a671b-148">Throughout this tutorial, we use a sample app to demonstrate the concepts and functionality discussed.</span></span>

<span data-ttu-id="a671b-149">この Visual Studio サンプルとソース コードは [GitHub](https://github.com/) の [windows-appsample-get-started-radialcontroller sample](https://aka.ms/appsample-radialcontroller) からダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="a671b-149">Download this Visual Studio sample and source code from [GitHub](https://github.com/) at [windows-appsample-get-started-radialcontroller sample](https://aka.ms/appsample-radialcontroller):</span></span>

1. <span data-ttu-id="a671b-150">緑の [**Clone or download**] (複製またはダウンロード) ボタンを選択します。</span><span class="sxs-lookup"><span data-stu-id="a671b-150">Select the green **Clone or download** button.</span></span>  
![リポジトリを複製する](images/radialcontroller/wheel-clone.png)
2. <span data-ttu-id="a671b-152">GitHub のアカウントを使っている場合には、[**Open in Visual Studio**] (Visual Studio で開く) を選択して、リポジトリをローカル コンピューターに複製できます。</span><span class="sxs-lookup"><span data-stu-id="a671b-152">If you have a GitHub account, you can clone the repo to your local machine by choosing **Open in Visual Studio**.</span></span> 
3. <span data-ttu-id="a671b-153">GitHub アカウントを使っていない場合、またはプロジェクトのローカル コピーのみが必要な場合には、[**Download ZIP**] (ZIP をダウンロードする) を選択します (最新の更新をダウンロードするには、定期的に確認する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="a671b-153">If you don't have a GitHub account, or you just want a local copy of the project, choose **Download ZIP** (you'll have to check back regularly to download the latest updates).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="a671b-154">サンプル コードのほとんどの部分はコメント アウトされています。このトピックの各手順を進めていく際に、コードの各セクションのコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="a671b-154">Most of the code in the sample is commented out. As we go through each step in this topic, you'll be asked to uncomment various sections of the code.</span></span> <span data-ttu-id="a671b-155">Visual Studio では、コードの行を強調表示して Ctrl + K キーを押して Ctrl + U キーを押します。</span><span class="sxs-lookup"><span data-stu-id="a671b-155">In Visual Studio, just highlight the lines of code, and press CTRL-K and then CTRL-U.</span></span>

## <a name="components-that-support-wheel-functionality"></a><span data-ttu-id="a671b-156">ホイール機能をサポートするコンポーネント</span><span class="sxs-lookup"><span data-stu-id="a671b-156">Components that support wheel functionality</span></span>

<span data-ttu-id="a671b-157">これらのオブジェクトは、UWP アプリにホイール デバイスのさまざまなエクスペリエンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="a671b-157">These objects provide the bulk of the wheel device experience for UWP apps.</span></span>

| <span data-ttu-id="a671b-158">コンポーネント</span><span class="sxs-lookup"><span data-stu-id="a671b-158">Component</span></span> | <span data-ttu-id="a671b-159">説明</span><span class="sxs-lookup"><span data-stu-id="a671b-159">Description</span></span> |
| --- | --- |
| <span data-ttu-id="a671b-160">[**RadialController** クラス](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController)および関連</span><span class="sxs-lookup"><span data-stu-id="a671b-160">[**RadialController** class](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController) and related</span></span> | <span data-ttu-id="a671b-161">Surface Dial などのホイール入力デバイスまたはアクセサリを表します。</span><span class="sxs-lookup"><span data-stu-id="a671b-161">Represents a wheel input device or accessory such as the Surface Dial.</span></span> |
| <span data-ttu-id="a671b-162">[**IRadialControllerConfigurationInterop**](https://msdn.microsoft.com/library/windows/desktop/mt790709) / [**IRadialControllerInterop**](https://msdn.microsoft.com/library/windows/desktop/mt790711)</span><span class="sxs-lookup"><span data-stu-id="a671b-162">[**IRadialControllerConfigurationInterop**](https://msdn.microsoft.com/library/windows/desktop/mt790709) / [**IRadialControllerInterop**](https://msdn.microsoft.com/library/windows/desktop/mt790711)</span></span><br/><span data-ttu-id="a671b-163">この機能はこのドキュメントの範囲外です。詳しくは、「[Windows クラシック デスクトップ サンプル](https://aka.ms/radialcontrollerclassicsample)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a671b-163">We do not cover this functionality here, for more information, see the [Windows classic desktop sample](https://aka.ms/radialcontrollerclassicsample).</span></span> | <span data-ttu-id="a671b-164">UWP アプリとの相互運用性を提供します。</span><span class="sxs-lookup"><span data-stu-id="a671b-164">Enables interoperability with a UWP app.</span></span> |

## <a name="step-1-run-the-sample"></a><span data-ttu-id="a671b-165">手順 1: サンプルを実行する</span><span class="sxs-lookup"><span data-stu-id="a671b-165">Step 1: Run the sample</span></span>

<span data-ttu-id="a671b-166">RadialController サンプル アプリをダウンロードしたら、実行できることを確認します。</span><span class="sxs-lookup"><span data-stu-id="a671b-166">After you've downloaded the RadialController sample app, verify that it runs:</span></span>
1. <span data-ttu-id="a671b-167">Visual Studio でサンプル プロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="a671b-167">Open the sample project in Visual Studio .</span></span>
2. <span data-ttu-id="a671b-168">[**ソリューション プラットフォーム**] のドロップダウンを ARM 以外の選択肢に設定します。</span><span class="sxs-lookup"><span data-stu-id="a671b-168">Set the **Solution Platforms** dropdown to a non-ARM selection.</span></span>
3. <span data-ttu-id="a671b-169">F5 キーを押して、コンパイル、展開、および実行します。</span><span class="sxs-lookup"><span data-stu-id="a671b-169">Press F5 to compile, deploy, and run.</span></span> 

> [!NOTE]
> <span data-ttu-id="a671b-170">または、[**デバッグ**] > [**デバッグの開始**] メニュー項目を選択するか、または [**ローカル コンピューター**] の実行ボタンを選択することもできます。![Visual Studio のプロジェクトのビルドのボタン</span><span class="sxs-lookup"><span data-stu-id="a671b-170">Alternatively, you can select **Debug** > **Start debugging** menu item, or select the **Local Machine** Run button shown here: ![Visual Studio Build project button</span></span>](images/radialcontroller/wheel-vsrun.png)

<span data-ttu-id="a671b-171">アプリ ウィンドウが開き、スプラッシュ画面が数秒表示されて、次のような初期画面が表示されます。</span><span class="sxs-lookup"><span data-stu-id="a671b-171">The app window opens, and after a splash screen appears for a few seconds, you’ll see this initial screen.</span></span>

![空のアプリ](images/radialcontroller/wheel-app-step1-empty.png)

<span data-ttu-id="a671b-173">これでチュートリアルの残りの部分で使う、基本的な UWP アプリの準備ができました。</span><span class="sxs-lookup"><span data-stu-id="a671b-173">Okay, we now have the basic UWP app that we’ll use throughout the rest of this tutorial.</span></span> <span data-ttu-id="a671b-174">これ以降の手順では、**RadialController** の機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="a671b-174">In the following steps, we add our **RadialController** functionality.</span></span>

## <a name="step-2-basic-radialcontroller-functionality"></a><span data-ttu-id="a671b-175">手順 2: 基本的な RadialController 機能</span><span class="sxs-lookup"><span data-stu-id="a671b-175">Step 2: Basic RadialController functionality</span></span>

<span data-ttu-id="a671b-176">アプリを実行して、フォア グラウンドで Surface Dial を長押しすると、\*\*RadialController \*\* メニューが表示されます。</span><span class="sxs-lookup"><span data-stu-id="a671b-176">With the app running and in the foreground, press and hold the Surface Dial to display the \*\*RadialController \*\* menu.</span></span>

<span data-ttu-id="a671b-177">まだアプリ用のカスタマイズを行っていないため、メニューにはコンテキスト依存の既定のツールのセットが含まれています。</span><span class="sxs-lookup"><span data-stu-id="a671b-177">We haven't done any customization for our app yet, so the menu contains a default set of contextual tools.</span></span> 

<span data-ttu-id="a671b-178">次の画像は、既定のメニューの 2 つのバリエーションを示しています。</span><span class="sxs-lookup"><span data-stu-id="a671b-178">These images show two variations of the default menu.</span></span> <span data-ttu-id="a671b-179">(既定のメニューは他にも多数あります。たとえば、Windows デスクトップがアクティブで、他にフォアグラウンドのアプリがない場合の基本的なシステム ツールのみのメニューや、InkToolbar が表示されているときに手描き入力ツールが追加されているメニューや、マップ アプリを使っているときのマッピング ツールなどがあります。)</span><span class="sxs-lookup"><span data-stu-id="a671b-179">(There are many others, including just basic system tools when the Windows Desktop is active and no apps are in the foreground, additional inking tools when an InkToolbar is present, and mapping tools when you’re using the Maps app.</span></span>

| <span data-ttu-id="a671b-180">RadialController メニュー (既定)</span><span class="sxs-lookup"><span data-stu-id="a671b-180">RadialController menu (default)</span></span>  | <span data-ttu-id="a671b-181">RadialController メニュー (メディアの再生時の既定)</span><span class="sxs-lookup"><span data-stu-id="a671b-181">RadialController menu (default with media playing)</span></span>  |
|---|---|
| ![既定の RadialController メニュー](images/radialcontroller/wheel-app-step2-basic-default.png) | ![音楽再生時の既定の RadialController メニュー](images/radialcontroller/wheel-app-step2-basic-withmusic.png) |

<span data-ttu-id="a671b-184">これで基本的なカスタマイズを始める準備ができました。</span><span class="sxs-lookup"><span data-stu-id="a671b-184">Now we'll start with some basic customization.</span></span>

## <a name="step-3-add-controls-for-wheel-input"></a><span data-ttu-id="a671b-185">手順 3: ホイール入力のコントロールを追加する</span><span class="sxs-lookup"><span data-stu-id="a671b-185">Step 3: Add controls for wheel input</span></span>

<span data-ttu-id="a671b-186">まず、アプリの UI を追加します。</span><span class="sxs-lookup"><span data-stu-id="a671b-186">First, let's add the UI for our app:</span></span>

1. <span data-ttu-id="a671b-187">MainPage_Basic.xaml ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="a671b-187">Open the MainPage_Basic.xaml file.</span></span>
2. <span data-ttu-id="a671b-188">この手順のタイトル ("\<!-- Step 3: Add controls for wheel input -->") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="a671b-188">Find the code marked with the title of this step ("\<!-- Step 3: Add controls for wheel input -->").</span></span>
3. <span data-ttu-id="a671b-189">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="a671b-189">Uncomment the following lines.</span></span>

    ```xaml
    <Button x:Name="InitializeSampleButton" 
            HorizontalAlignment="Center" 
            Margin="10" 
            Content="Initialize sample" />
    <ToggleButton x:Name="AddRemoveToggleButton"
                    HorizontalAlignment="Center" 
                    Margin="10" 
                    Content="Remove Item"
                    IsChecked="True" 
                    IsEnabled="False"/>
    <Button x:Name="ResetControllerButton" 
            HorizontalAlignment="Center" 
            Margin="10" 
            Content="Reset RadialController menu" 
            IsEnabled="False"/>
    <Slider x:Name="RotationSlider" Minimum="0" Maximum="10"
            Width="300"
            HorizontalAlignment="Center"/>
    <TextBlock Text="{Binding ElementName=RotationSlider, Mode=OneWay, Path=Value}"
                Margin="0,0,0,20"
                HorizontalAlignment="Center"/>
    <ToggleSwitch x:Name="ClickToggle"
                    MinWidth="0" 
                    Margin="0,0,0,20"
                    HorizontalAlignment="center"/>
    ```
<span data-ttu-id="a671b-190">この時点では、[**Initialize sample**] (サンプルの初期化) ボタン、スライダー、トグル スイッチのみを有効にします。</span><span class="sxs-lookup"><span data-stu-id="a671b-190">At this point, only the **Initialize sample** button, slider, and toggle switch are enabled.</span></span> <span data-ttu-id="a671b-191">他のボタンは後の手順で使用して、スライダーとトグル スイッチへのアクセスを提供する **RadialController** のメニュー項目の追加と削除を行います。</span><span class="sxs-lookup"><span data-stu-id="a671b-191">The other buttons are used in later steps to add and remove **RadialController** menu items that provide access to the slider and toggle switch.</span></span>

![基本的なサンプル アプリの UI](images/radialcontroller/wheel-app-step3-basicui.png)

## <a name="step-4-customize-the-basic-radialcontroller-menu"></a><span data-ttu-id="a671b-193">手順 4: 基本的な RadialController メニューをカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="a671b-193">Step 4: Customize the basic RadialController menu</span></span>

<span data-ttu-id="a671b-194">**RadialController** のアクセスを有効にするために必要なコードをコントロールに追加します。</span><span class="sxs-lookup"><span data-stu-id="a671b-194">Now let's add the code required to enable **RadialController** access to our controls.</span></span>

1. <span data-ttu-id="a671b-195">MainPage_Basic.xaml.cs ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="a671b-195">Open the MainPage_Basic.xaml.cs file.</span></span>
2. <span data-ttu-id="a671b-196">この手順のタイトル ("// Step 4: Basic RadialController menu customization") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="a671b-196">Find the code marked with the title of this step ("// Step 4: Basic RadialController menu customization").</span></span>
3. <span data-ttu-id="a671b-197">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="a671b-197">Uncomment the following lines:</span></span>
    - <span data-ttu-id="a671b-198">[Windows.UI.Input](https://docs.microsoft.com/uwp/api/windows.ui.input) および [Windows.Storage.Streams](https://docs.microsoft.com/uwp/api/windows.storage.streams) 型参照は、以降の手順の機能に使用されます。</span><span class="sxs-lookup"><span data-stu-id="a671b-198">The [Windows.UI.Input](https://docs.microsoft.com/uwp/api/windows.ui.input) and [Windows.Storage.Streams](https://docs.microsoft.com/uwp/api/windows.storage.streams) type references are used for functionality in subsequent steps:</span></span>  
    
        ```csharp
        // Using directives for RadialController functionality.
        using Windows.UI.Input;
        ```

    - <span data-ttu-id="a671b-199">次のグローバル オブジェクト ([RadialController](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller)、[RadialControllerConfiguration](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontrollerconfiguration)、[RadialControllerMenuItem](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontrollermenuitem)) はアプリ全体で使用されます。</span><span class="sxs-lookup"><span data-stu-id="a671b-199">These global objects ([RadialController](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller), [RadialControllerConfiguration](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontrollerconfiguration), [RadialControllerMenuItem](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontrollermenuitem)) are used throughout our app.</span></span>
    
        ```csharp
        private RadialController radialController;
        private RadialControllerConfiguration radialControllerConfig;
        private RadialControllerMenuItem radialControllerMenuItem;
        ```

    - <span data-ttu-id="a671b-200">ここでは、ボタンに **Click** ハンドラーを指定して、コントロールを有効化し、カスタムの **RadialController** メニュー項目を初期化します。</span><span class="sxs-lookup"><span data-stu-id="a671b-200">Here, we specify the **Click** handler for the button that enables our controls and initializes our custom **RadialController** menu item.</span></span>

        ```csharp
        InitializeSampleButton.Click += (sender, args) =>
        { InitializeSample(sender, args); };
        ``` 

    - <span data-ttu-id="a671b-201">次に、[RadialController](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller) オブジェクトを初期化し、[RotationChanged](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.RotationChanged) および [ButtonClicked](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.ButtonClicked) イベントのハンドラーを設定します。</span><span class="sxs-lookup"><span data-stu-id="a671b-201">Next, we initialize our [RadialController](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller) object and set up handlers for the [RotationChanged](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.RotationChanged) and [ButtonClicked](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.ButtonClicked) events.</span></span>

        ```csharp
        // Set up the app UI and RadialController.
        private void InitializeSample(object sender, RoutedEventArgs e)
        {
            ResetControllerButton.IsEnabled = true;
            AddRemoveToggleButton.IsEnabled = true;

            ResetControllerButton.Click += (resetsender, args) =>
            { ResetController(resetsender, args); };
            AddRemoveToggleButton.Click += (togglesender, args) =>
            { AddRemoveItem(togglesender, args); };

            InitializeController(sender, e);
        }
        ```

    - <span data-ttu-id="a671b-202">ここでは、カスタムの RadialController メニュー項目を初期化します。</span><span class="sxs-lookup"><span data-stu-id="a671b-202">Here, we initialize our custom RadialController menu item.</span></span> <span data-ttu-id="a671b-203">[CreateForCurrentView](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.CreateForCurrentView) を使って [RadialController](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller) オブジェクトへの参照を取得します。[RotationResolutionInDegrees](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.RotationResolutionInDegrees) プロパティを使って、回転の感度を "1" に設定します。次に [CreateFromFontGlyph](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontrollermenuitem.CreateFromFontGlyph) を使って [RadialControllerMenuItem](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontrollermenuitem) を作成します。**RadialController** メニュー項目コレクションにメニュー項目を追加します。最後に、[SetDefaultMenuItems](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontrollerconfiguration.setdefaultmenuitems) を使って既定のメニュー項目をクリアして、カスタム ツールのみを残します。</span><span class="sxs-lookup"><span data-stu-id="a671b-203">We use [CreateForCurrentView](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.CreateForCurrentView) to get a reference to our [RadialController](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller) object, we set the rotation sensitivity to "1" by using the [RotationResolutionInDegrees](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.RotationResolutionInDegrees) property, we then create our [RadialControllerMenuItem](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontrollermenuitem) by using [CreateFromFontGlyph](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontrollermenuitem.CreateFromFontGlyph), we add the menu item to the **RadialController** menu item collection, and finally, we use [SetDefaultMenuItems](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontrollerconfiguration.setdefaultmenuitems) to clear the default menu items and leave only our custom tool.</span></span> 

        ```csharp
        // Configure RadialController menu and custom tool.
        private void InitializeController(object sender, RoutedEventArgs args)
        {
            // Create a reference to the RadialController.
            radialController = RadialController.CreateForCurrentView();
            // Set rotation resolution to 1 degree of sensitivity.
            radialController.RotationResolutionInDegrees = 1;

            // Create the custom menu items.
            // Here, we use a font glyph for our custom tool.
            radialControllerMenuItem =
                RadialControllerMenuItem.CreateFromFontGlyph("SampleTool", "\xE1E3", "Segoe MDL2 Assets");

            // Add the item to the RadialController menu.
            radialController.Menu.Items.Add(radialControllerMenuItem);

            // Remove built-in tools to declutter the menu.
            // NOTE: The Surface Dial menu must have at least one menu item. 
            // If all built-in tools are removed before you add a custom 
            // tool, the default tools are restored and your tool is appended 
            // to the default collection.
            radialControllerConfig =
                RadialControllerConfiguration.GetForCurrentView();
            radialControllerConfig.SetDefaultMenuItems(
                new RadialControllerSystemMenuItemKind[] { });

            // Declare input handlers for the RadialController.
            // NOTE: These events are only fired when a custom tool is active.
            radialController.ButtonClicked += (clicksender, clickargs) =>
            { RadialController_ButtonClicked(clicksender, clickargs); };
            radialController.RotationChanged += (rotationsender, rotationargs) =>
            { RadialController_RotationChanged(rotationsender, rotationargs); };
        }

        // Connect wheel device rotation to slider control.
        private void RadialController_RotationChanged(
            object sender, RadialControllerRotationChangedEventArgs args)
        {
            if (RotationSlider.Value + args.RotationDeltaInDegrees >= RotationSlider.Maximum)
            {
                RotationSlider.Value = RotationSlider.Maximum;
            }
            else if (RotationSlider.Value + args.RotationDeltaInDegrees < RotationSlider.Minimum)
            {
                RotationSlider.Value = RotationSlider.Minimum;
            }
            else
            {
                RotationSlider.Value += args.RotationDeltaInDegrees;
            }
        }

        // Connect wheel device click to toggle switch control.
        private void RadialController_ButtonClicked(
            object sender, RadialControllerButtonClickedEventArgs args)
        {
            ClickToggle.IsOn = !ClickToggle.IsOn;
        }
        ```
4. <span data-ttu-id="a671b-204">では、アプリを再度実行します。</span><span class="sxs-lookup"><span data-stu-id="a671b-204">Now, run the app again.</span></span>
5. <span data-ttu-id="a671b-205">[**Initialize radial controller**] (リング コントローラーの初期化) ボタンを選択します。</span><span class="sxs-lookup"><span data-stu-id="a671b-205">Select the **Initialize radial controller** button.</span></span>  
6. <span data-ttu-id="a671b-206">アプリをフォア グラウンドにして、Surface Dial を長押しすると、メニューが表示されます。</span><span class="sxs-lookup"><span data-stu-id="a671b-206">With the app in the foreground, press and hold the Surface Dial to display the menu.</span></span> <span data-ttu-id="a671b-207">(**RadialControllerConfiguration.SetDefaultMenuItems** メソッドにより) すべての既定のツールが削除されていること、カスタム ツールのみが残っていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="a671b-207">Notice that all default tools have been removed (by using the **RadialControllerConfiguration.SetDefaultMenuItems** method), leaving only the custom tool.</span></span> <span data-ttu-id="a671b-208">作成したカスタム ツールを含むメニューは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="a671b-208">Here’s the menu with our custom tool.</span></span> 

| <span data-ttu-id="a671b-209">RadialController メニュー (カスタム)</span><span class="sxs-lookup"><span data-stu-id="a671b-209">RadialController menu (custom)</span></span>  | 
|---|
| ![カスタムの RadialController メニュー](images/radialcontroller/wheel-app-step3-custom.png) |

7. <span data-ttu-id="a671b-211">カスタム ツールを選択して、Surface Dial によってサポートされている操作を試します。</span><span class="sxs-lookup"><span data-stu-id="a671b-211">Select the custom tool and try out the interactions now supported through the Surface Dial:</span></span>
    * <span data-ttu-id="a671b-212">回転操作によって、スライダーを移動します。</span><span class="sxs-lookup"><span data-stu-id="a671b-212">A rotate action moves the slider.</span></span> 
    * <span data-ttu-id="a671b-213">クリックによって、オン/オフが切り替わります。</span><span class="sxs-lookup"><span data-stu-id="a671b-213">A click sets the toggle to on or off.</span></span>

<span data-ttu-id="a671b-214">では、次にボタンを接続しましょう。</span><span class="sxs-lookup"><span data-stu-id="a671b-214">Ok, let's hook up those buttons.</span></span>

## <a name="step-5-configure-menu-at-runtime"></a><span data-ttu-id="a671b-215">手順 5: 実行時にメニューを構成する</span><span class="sxs-lookup"><span data-stu-id="a671b-215">Step 5: Configure menu at runtime</span></span>

<span data-ttu-id="a671b-216">この手順では、[**Add/Remove item**] (項目の追加と削除) ボタンと [**Reset RadialController menu**] (RadialController メニューのリセット) ボタンを接続して、メニューを動的にカスタマイズする方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="a671b-216">In this step, we hook up the **Add/Remove item** and **Reset RadialController menu** buttons to show how you can dynamically customize the menu.</span></span>

1. <span data-ttu-id="a671b-217">MainPage_Basic.xaml.cs ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="a671b-217">Open the MainPage_Basic.xaml.cs file.</span></span>
2. <span data-ttu-id="a671b-218">この手順のタイトル ("// Step 5: Configure menu at runtime") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="a671b-218">Find the code marked with the title of this step ("// Step 5: Configure menu at runtime").</span></span>
3. <span data-ttu-id="a671b-219">次のメソッドのコードのコメントを解除し、アプリをもう一度実行します。ただし、どのボタンも選択しないでください (それは次の手順で行います)。</span><span class="sxs-lookup"><span data-stu-id="a671b-219">Uncomment the code in the following methods and run the app again, but don't select any buttons (save that for the next step).</span></span>  

    ``` csharp
    // Add or remove the custom tool.
    private void AddRemoveItem(object sender, RoutedEventArgs args)
    {
        if (AddRemoveToggleButton?.IsChecked == true)
        {
            AddRemoveToggleButton.Content = "Remove item";
            if (!radialController.Menu.Items.Contains(radialControllerMenuItem))
            {
                radialController.Menu.Items.Add(radialControllerMenuItem);
            }
        }
        else if (AddRemoveToggleButton?.IsChecked == false)
        {
            AddRemoveToggleButton.Content = "Add item";
            if (radialController.Menu.Items.Contains(radialControllerMenuItem))
            {
                radialController.Menu.Items.Remove(radialControllerMenuItem);
                // Attempts to select and activate the previously selected tool.
                // NOTE: Does not differentiate between built-in and custom tools.
                radialController.Menu.TrySelectPreviouslySelectedMenuItem();
            }
        }
    }

    // Reset the RadialController to initial state.
    private void ResetController(object sender, RoutedEventArgs arg)
    {
        if (!radialController.Menu.Items.Contains(radialControllerMenuItem))
        {
            radialController.Menu.Items.Add(radialControllerMenuItem);
        }
        AddRemoveToggleButton.Content = "Remove item";
        AddRemoveToggleButton.IsChecked = true;
        radialControllerConfig.SetDefaultMenuItems(
            new RadialControllerSystemMenuItemKind[] { });
    }
    ```
4. <span data-ttu-id="a671b-220">[**Remove item**] (項目を削除する) ボタンを選択し、次に Dial を長押しして、再度メニューを表示させます。</span><span class="sxs-lookup"><span data-stu-id="a671b-220">Select the **Remove item** button and then press and hold the Dial to display the menu again.</span></span>

    <span data-ttu-id="a671b-221">メニューにツールの既定のコレクションが含まれていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="a671b-221">Notice that the menu now contains the default collection of tools.</span></span> <span data-ttu-id="a671b-222">手順 3 でカスタム メニューをセットアップしたときに、すべての既定のツールを削除して、カスタム ツールだけを追加したことを思い出してください。</span><span class="sxs-lookup"><span data-stu-id="a671b-222">Recall that, in Step 3, while setting up our custom menu, we removed all the default tools and added just our custom tool.</span></span> <span data-ttu-id="a671b-223">さらに、メニューを空のコレクションに設定すると、現在のコンテキストに既定の項目が再配置されたことにも注意します。</span><span class="sxs-lookup"><span data-stu-id="a671b-223">We also noted that, when the menu is set to an empty collection, the default items for the current context are reinstated.</span></span> <span data-ttu-id="a671b-224">(既定のツールを削除する前にカスタム ツールを追加しました。)</span><span class="sxs-lookup"><span data-stu-id="a671b-224">(We added our custom tool before removing the default tools.)</span></span>

5. <span data-ttu-id="a671b-225">[**Add item**] (項目の追加) ボタンを選択して、次に Dial を長押しします。</span><span class="sxs-lookup"><span data-stu-id="a671b-225">Select the **Add item** button and then press and hold the Dial.</span></span>

    <span data-ttu-id="a671b-226">メニューに、既定のツールのコレクションと、カスタム ツールの両方が含まれていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="a671b-226">Notice that the menu now contains both the default collection of tools and our custom tool.</span></span>

6. <span data-ttu-id="a671b-227">[**Reset RadialController menu**] (RadialController メニューのリセット) ボタンを選択し、次に Dial を長押しします。</span><span class="sxs-lookup"><span data-stu-id="a671b-227">Select the **Reset RadialController menu** button and then press and hold the Dial.</span></span>

    <span data-ttu-id="a671b-228">メニューが元の状態に戻ったことを確認します。</span><span class="sxs-lookup"><span data-stu-id="a671b-228">Notice that the menu is back to its original state.</span></span>

## <a name="step-6-customize-the-device-haptics"></a><span data-ttu-id="a671b-229">手順 6: デバイスのハプティクス (触覚) をカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="a671b-229">Step 6: Customize the device haptics</span></span>
<span data-ttu-id="a671b-230">Surface Dial およびその他のホイール デバイスは、現在の操作に対応する触覚フィードバック (クリックまたは回転のいずれかに基づく) をユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="a671b-230">The Surface Dial, and other wheel devices, can provide users with haptic feedback corresponding to the current interaction (based on either click or rotation).</span></span>

<span data-ttu-id="a671b-231">この手順では、触覚フィードバックをカスタマイズする方法を説明します。ここでは、スライダーとトグル スイッチ コントロールを関連付け、それらを使って動的に触覚フィードバック動作を指定します。</span><span class="sxs-lookup"><span data-stu-id="a671b-231">In this step, we show how you can customize haptic feedback by associating our slider and toggle switch controls and using them to dynamically specify haptic feedback behavior.</span></span> <span data-ttu-id="a671b-232">この例では、フィードバックを有効にするには、トグル スイッチをオンにする必要があります。スライダーの値により、クリックのフィードバックの反復頻度を指定します。</span><span class="sxs-lookup"><span data-stu-id="a671b-232">For this example, the toggle switch must be set to on for feedback to be enabled while the slider value specifies how often the click feedback is repeated.</span></span> 

> [!NOTE]
> <span data-ttu-id="a671b-233">触覚フィードバックは、ユーザーにより [**設定**] >  [**デバイス**] > [**ホイール**] ページで無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="a671b-233">Haptic feedback can be disabled by the user in the **Settings** >  **Devices** > **Wheel** page.</span></span>

1. <span data-ttu-id="a671b-234">App.xaml.cs ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="a671b-234">Open the App.xaml.cs file.</span></span>
2. <span data-ttu-id="a671b-235">この手順のタイトル ("Step 6: Customize the device haptics") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="a671b-235">Find the code marked with the title of this step ("Step 6: Customize the device haptics").</span></span>
3. <span data-ttu-id="a671b-236">1 行目と 3 行目 ("MainPage_Basic" と "MainPage") をコメントのままとして、2 行目 ("MainPage_Haptics") のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="a671b-236">Comment the first and third lines ("MainPage_Basic" and "MainPage") and uncomment the second ("MainPage_Haptics").</span></span>  

    ``` csharp
    rootFrame.Navigate(typeof(MainPage_Basic), e.Arguments);
    rootFrame.Navigate(typeof(MainPage_Haptics), e.Arguments);
    rootFrame.Navigate(typeof(MainPage), e.Arguments);
    ```
4. <span data-ttu-id="a671b-237">MainPage_Haptics.xaml ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="a671b-237">Open the MainPage_Haptics.xaml file.</span></span>
5. <span data-ttu-id="a671b-238">この手順のタイトル ("\<!-- Step 6: Customize the device haptics -->") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="a671b-238">Find the code marked with the title of this step ("\<!-- Step 6: Customize the device haptics -->").</span></span>
6. <span data-ttu-id="a671b-239">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="a671b-239">Uncomment the following lines.</span></span> <span data-ttu-id="a671b-240">(この UI コードは、単に現在のデバイスでサポートされているハプティックス機能を示します。)</span><span class="sxs-lookup"><span data-stu-id="a671b-240">(This UI code simply indicates what haptics features are supported by the current device.)</span></span>    

    ```xaml
    <StackPanel x:Name="HapticsStack" 
                Orientation="Vertical" 
                HorizontalAlignment="Center" 
                BorderBrush="Gray" 
                BorderThickness="1">
        <TextBlock Padding="10" 
                    Text="Supported haptics properties:" />
        <CheckBox x:Name="CBDefault" 
                    Content="Default" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsChecked="True" />
        <CheckBox x:Name="CBIntensity" 
                    Content="Intensity" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsThreeState="True" 
                    IsChecked="{x:Null}" />
        <CheckBox x:Name="CBPlayCount" 
                    Content="Play count" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsThreeState="True" 
                    IsChecked="{x:Null}" />
        <CheckBox x:Name="CBPlayDuration" 
                    Content="Play duration" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsThreeState="True" 
                    IsChecked="{x:Null}" />
        <CheckBox x:Name="CBReplayPauseInterval" 
                    Content="Replay/pause interval" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsThreeState="True" 
                    IsChecked="{x:Null}" />
        <CheckBox x:Name="CBBuzzContinuous" 
                    Content="Buzz continuous" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsThreeState="True" 
                    IsChecked="{x:Null}" />
        <CheckBox x:Name="CBClick" 
                    Content="Click" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsThreeState="True" 
                    IsChecked="{x:Null}" />
        <CheckBox x:Name="CBPress" 
                    Content="Press" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsThreeState="True" 
                    IsChecked="{x:Null}" />
        <CheckBox x:Name="CBRelease" 
                    Content="Release" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsThreeState="True" 
                    IsChecked="{x:Null}" />
        <CheckBox x:Name="CBRumbleContinuous" 
                    Content="Rumble continuous" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsThreeState="True" 
                    IsChecked="{x:Null}" />
    </StackPanel>
    ```
7. <span data-ttu-id="a671b-241">MainPage_Haptics.xaml.cs ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="a671b-241">Open the MainPage_Haptics.xaml.cs file</span></span>
8. <span data-ttu-id="a671b-242">この手順のタイトル ("Step 6: Haptics customization") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="a671b-242">Find the code marked with the title of this step ("Step 6: Haptics customization")</span></span>
9. <span data-ttu-id="a671b-243">以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="a671b-243">Uncomment the following lines:</span></span>  

    - <span data-ttu-id="a671b-244">[Windows.Devices.Haptics](https://docs.microsoft.com/uwp/api/windows.devices.haptics) 型参照は、以降の手順の機能に使用されます。</span><span class="sxs-lookup"><span data-stu-id="a671b-244">The [Windows.Devices.Haptics](https://docs.microsoft.com/uwp/api/windows.devices.haptics) type reference is used for functionality in subsequent steps.</span></span>  
    
        ```csharp
        using Windows.Devices.Haptics;
        ```

    - <span data-ttu-id="a671b-245">ここでは、[ControlAcquired](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.ControlAcquired) イベントのハンドラーを指定します。これはカスタムの **RadialController** メニュー項目が選択されたときにトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="a671b-245">Here, we specify the handler for the [ControlAcquired](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.ControlAcquired) event that is triggered when our custom **RadialController** menu item is selected.</span></span>

        ```csharp
        radialController.ControlAcquired += (rc_sender, args) =>
        { RadialController_ControlAcquired(rc_sender, args); };
        ``` 

    - <span data-ttu-id="a671b-246">次に、[ControlAcquired](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.ControlAcquired) ハンドラーを定義します。ここでは、既定の触覚フィードバックを無効化して、ハプティクス UI を初期化します。</span><span class="sxs-lookup"><span data-stu-id="a671b-246">Next, we define the [ControlAcquired](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.ControlAcquired) handler, where we disable default haptic feedback and initialize our haptics UI.</span></span>

        ```csharp
        private void RadialController_ControlAcquired(
            RadialController rc_sender,
            RadialControllerControlAcquiredEventArgs args)
        {
            // Turn off default haptic feedback.
            radialController.UseAutomaticHapticFeedback = false;

            SimpleHapticsController hapticsController =
                args.SimpleHapticsController;

            // Enumerate haptic support.
            IReadOnlyCollection<SimpleHapticsControllerFeedback> supportedFeedback =
                hapticsController.SupportedFeedback;

            foreach (SimpleHapticsControllerFeedback feedback in supportedFeedback)
            {
                if (feedback.Waveform == KnownSimpleHapticsControllerWaveforms.BuzzContinuous)
                {
                    CBBuzzContinuous.IsEnabled = true;
                    CBBuzzContinuous.IsChecked = true;
                }
                else if (feedback.Waveform == KnownSimpleHapticsControllerWaveforms.Click)
                {
                    CBClick.IsEnabled = true;
                    CBClick.IsChecked = true;
                }
                else if (feedback.Waveform == KnownSimpleHapticsControllerWaveforms.Press)
                {
                    CBPress.IsEnabled = true;
                    CBPress.IsChecked = true;
                }
                else if (feedback.Waveform == KnownSimpleHapticsControllerWaveforms.Release)
                {
                    CBRelease.IsEnabled = true;
                    CBRelease.IsChecked = true;
                }
                else if (feedback.Waveform == KnownSimpleHapticsControllerWaveforms.RumbleContinuous)
                {
                    CBRumbleContinuous.IsEnabled = true;
                    CBRumbleContinuous.IsChecked = true;
                }
            }

            if (hapticsController?.IsIntensitySupported == true)
            {
                CBIntensity.IsEnabled = true;
                CBIntensity.IsChecked = true;
            }
            if (hapticsController?.IsPlayCountSupported == true)
            {
                CBPlayCount.IsEnabled = true;
                CBPlayCount.IsChecked = true;
            }
            if (hapticsController?.IsPlayDurationSupported == true)
            {
                CBPlayDuration.IsEnabled = true;
                CBPlayDuration.IsChecked = true;
            }
            if (hapticsController?.IsReplayPauseIntervalSupported == true)
            {
                CBReplayPauseInterval.IsEnabled = true;
                CBReplayPauseInterval.IsChecked = true;
            }
        }
        ```

    - <span data-ttu-id="a671b-247">[RotationChanged](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.RotationChanged) および [ButtonClicked](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.ButtonClicked) イベント ハンドラーで、対応するスライダーとトグル ボタン コントロールをカスタム ハプティクスに接続します。</span><span class="sxs-lookup"><span data-stu-id="a671b-247">In our [RotationChanged](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.RotationChanged) and [ButtonClicked](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.ButtonClicked) event handlers, we connect the corresponding slider and toggle button controls to our custom haptics.</span></span> 

        ```csharp
        // Connect wheel device rotation to slider control.
        private void RadialController_RotationChanged(
            object sender, RadialControllerRotationChangedEventArgs args)
        {
            ...
            if (ClickToggle.IsOn && 
                (RotationSlider.Value > RotationSlider.Minimum) && 
                (RotationSlider.Value < RotationSlider.Maximum))
            {
                SimpleHapticsControllerFeedback waveform = 
                    FindWaveform(args.SimpleHapticsController, 
                    KnownSimpleHapticsControllerWaveforms.BuzzContinuous);
                if (waveform != null)
                {
                    args.SimpleHapticsController.SendHapticFeedback(waveform);
                }
            }
        }

        private void RadialController_ButtonClicked(
            object sender, RadialControllerButtonClickedEventArgs args)
        {
            ...

            if (RotationSlider?.Value > 0)
            {
                SimpleHapticsControllerFeedback waveform = 
                    FindWaveform(args.SimpleHapticsController, 
                    KnownSimpleHapticsControllerWaveforms.Click);

                if (waveform != null)
                {
                    args.SimpleHapticsController.SendHapticFeedbackForPlayCount(
                        waveform, 1.0, 
                        (int)RotationSlider.Value, 
                        TimeSpan.Parse("1"));
                }
            }
        }
        ```
    - <span data-ttu-id="a671b-248">最後に、触覚フィードバックに要求した**[波形](https://docs.microsoft.com/uwp/api/windows.devices.haptics.simplehapticscontrollerfeedback.Waveform)** (サポートされている場合) を取得します。</span><span class="sxs-lookup"><span data-stu-id="a671b-248">Finally, we get the requested **[Waveform](https://docs.microsoft.com/uwp/api/windows.devices.haptics.simplehapticscontrollerfeedback.Waveform)** (if supported) for the haptic feedback.</span></span> 

        ```csharp
        // Get the requested waveform.
        private SimpleHapticsControllerFeedback FindWaveform(
            SimpleHapticsController hapticsController,
            ushort waveform)
        {
            foreach (var hapticInfo in hapticsController.SupportedFeedback)
            {
                if (hapticInfo.Waveform == waveform)
                {
                    return hapticInfo;
                }
            }
            return null;
        }
        ```

<span data-ttu-id="a671b-249">アプリを再度実行し、スライダーの値とトグル スイッチの状態を変更して、カスタム ハプティクスを試します。</span><span class="sxs-lookup"><span data-stu-id="a671b-249">Now run the app again to try out the custom haptics by changing the slider value and toggle-switch state.</span></span>

## <a name="step-7-define-on-screen-interactions-for-surface-studio-and-similar-devices"></a><span data-ttu-id="a671b-250">手順 7: Surface Studio や類似のデバイスのオンスクリーンの操作を定義する</span><span class="sxs-lookup"><span data-stu-id="a671b-250">Step 7: Define on-screen interactions for Surface Studio and similar devices</span></span>
<span data-ttu-id="a671b-251">Surface Dial は Surface Studio と一緒に使うことによって、さらに独創的なユーザー エクスペリエンスを提供できます。</span><span class="sxs-lookup"><span data-stu-id="a671b-251">Paired with the Surface Studio, the Surface Dial can provide an even more distinctive user experience.</span></span> 

<span data-ttu-id="a671b-252">先ほど説明した既定の長押しメニューのエクスペリエンスに加えて、Surface Dial は Surface Studio の画面上に直接配置できます。</span><span class="sxs-lookup"><span data-stu-id="a671b-252">In addition to the default press and hold menu experience described, the Surface Dial can also be placed directly on the screen of the Surface Studio.</span></span> <span data-ttu-id="a671b-253">これにより、特殊な "オンスクリーン" メニューが実現されます。</span><span class="sxs-lookup"><span data-stu-id="a671b-253">This enables a special "on-screen" menu.</span></span> 

<span data-ttu-id="a671b-254">Surface Dial の接触位置と境界の両方を検出することにより、システムはデバイスによるオクルージョンを処理し、Dial の外側を囲むように大きいバージョンのメニューを表示します。</span><span class="sxs-lookup"><span data-stu-id="a671b-254">By detecting both the contact location and bounds of the Surface Dial, the system handles occlusion by the device and displays a larger version of the menu that wraps around the outside of the Dial.</span></span> <span data-ttu-id="a671b-255">この同じ情報をアプリで使用して、デバイスの存在とその予想される使用状況 (ユーザーの手や腕の配置など) の両方に合わせて UI を調整することもできます。</span><span class="sxs-lookup"><span data-stu-id="a671b-255">This same info can also be used by your app to adapt the UI for both the presence of the device and its anticipated usage, such as the placement of the user's hand and arm.</span></span> 

<span data-ttu-id="a671b-256">このチュートリアルのサンプルには、これらの機能の一部を使った、より高度な例が含まれています。</span><span class="sxs-lookup"><span data-stu-id="a671b-256">The sample that accompanies this tutorial includes a slightly more complex example that demonstrates some of these capabilities.</span></span>

<span data-ttu-id="a671b-257">この例を実行するには、次の手順を行います (Surface Studio が必要となります)。</span><span class="sxs-lookup"><span data-stu-id="a671b-257">To see this in action (you'll need a Surface Studio):</span></span>

1. <span data-ttu-id="a671b-258">(Visual Studio がインストールされている) Surface Studio デバイスで、サンプルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="a671b-258">Download the sample on a Surface Studio device (with Visual Studio installed)</span></span>
2. <span data-ttu-id="a671b-259">Visual Studio でサンプルを開きます</span><span class="sxs-lookup"><span data-stu-id="a671b-259">Open the sample in Visual Studio</span></span>
3. <span data-ttu-id="a671b-260">App.xaml.cs ファイルを開きます</span><span class="sxs-lookup"><span data-stu-id="a671b-260">Open the App.xaml.cs file</span></span>
4. <span data-ttu-id="a671b-261">この手順のタイトル  ("Step 7: Define on-screen interactions for Surface Studio and similar devices") が付いているコードを見つけます。</span><span class="sxs-lookup"><span data-stu-id="a671b-261">Find the code marked with the title of this step ("Step 7: Define on-screen interactions for Surface Studio and similar devices")</span></span>
5. <span data-ttu-id="a671b-262">1 行目と 2 行目 ("MainPage_Basic" と "MainPage_Haptics") をコメントのままとして、3 行目 ("MainPage") のコメントを解除します</span><span class="sxs-lookup"><span data-stu-id="a671b-262">Comment the first and second lines ("MainPage_Basic" and "MainPage_Haptics") and uncomment the third ("MainPage")</span></span>  

    ``` csharp
    rootFrame.Navigate(typeof(MainPage_Basic), e.Arguments);
    rootFrame.Navigate(typeof(MainPage_Haptics), e.Arguments);
    rootFrame.Navigate(typeof(MainPage), e.Arguments);
    ```
6. <span data-ttu-id="a671b-263">アプリを実行し、2 つのコントロール領域に、交互に Surface Dial を配置します。</span><span class="sxs-lookup"><span data-stu-id="a671b-263">Run the app and place the Surface Dial in each of the two control regions, alternating between them.</span></span>    
![オンスクリーンの RadialController](images/radialcontroller/wheel-app-step5-onscreen2.png) 

    <span data-ttu-id="a671b-265">このサンプルの動作のビデオを次に示します。</span><span class="sxs-lookup"><span data-stu-id="a671b-265">Here's a video of this sample in action:</span></span>  

    <iframe src="https://channel9.msdn.com/Blogs/One-Dev-Minute/Programming-the-Microsoft-Surface-Dial/player" width="600" height="400" allowFullScreen frameBorder="0"></iframe>  

## <a name="summary"></a><span data-ttu-id="a671b-266">まとめ</span><span class="sxs-lookup"><span data-stu-id="a671b-266">Summary</span></span>

<span data-ttu-id="a671b-267">*入門チュートリアル: UWP アプリで Surface Dial (およびその他のホイール デバイス) をサポートする*はこれで完成です。</span><span class="sxs-lookup"><span data-stu-id="a671b-267">Congratulations, you've completed the *Get Started Tutorial: Support the Surface Dial (and other wheel devices) in your UWP app*!</span></span> <span data-ttu-id="a671b-268">このチュートリアルでは、UWP アプリでホイール デバイスをサポートするために必要となる基本的なコードを示し、さらに **RadialController** API でサポートされる高度なユーザー エクスペリエンスを提供する方法について説明しました。</span><span class="sxs-lookup"><span data-stu-id="a671b-268">We showed you the basic code required for supporting a wheel device in your UWP apps, and how to provide some of the richer user experiences supported by the **RadialController** APIs.</span></span>
