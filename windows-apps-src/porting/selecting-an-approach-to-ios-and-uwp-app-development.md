---
author: mcleblanc
description: クロスプラットフォーム アプリを開発するときの選択肢
title: iOS と UWP のアプリ開発方法の選択
ms.assetid: 5CDAB313-07B7-4A32-A49B-026361DCC853
ms.author: markl
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: ccacfc1257af529fcc2363285c6dd9e4ab2315ac
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "243750"
---
# <a name="selecting-an-approach-to-ios-and-uwp-app-development"></a><span data-ttu-id="39253-104">iOS と UWP のアプリ開発方法の選択</span><span class="sxs-lookup"><span data-stu-id="39253-104">Selecting an approach to iOS and UWP app development</span></span>

<span data-ttu-id="39253-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="39253-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="39253-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="39253-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="39253-107">クロスプラットフォーム アプリを開発するときの選択肢</span><span class="sxs-lookup"><span data-stu-id="39253-107">What are the choices when developing cross-platform apps?</span></span>

## <a name="whats-the-best-way-to-support-both-ios-and-windows"></a><span data-ttu-id="39253-108">iOS と Windows の両方をサポートするための最適な方法</span><span class="sxs-lookup"><span data-stu-id="39253-108">What's the best way to support both iOS and Windows?</span></span>

<span data-ttu-id="39253-109">Windows と iOS はまったく違うものに見えるかもしれませんが、増え続けるツールと手法が、両方のプラットフォーム (Android も含めて) をサポートするアプリを作成する場合に非常に役に立ちます。</span><span class="sxs-lookup"><span data-stu-id="39253-109">Windows and iOS may seem to be very different beasts, but a growing number of tools and techniques can greatly assist you if you need to write apps that support both platforms (and Android too).</span></span> <span data-ttu-id="39253-110">最適なソリューションは、作成するアプリの種類によって、またゼロから始めるか既存のプロジェクトを移植するかによって異なります。</span><span class="sxs-lookup"><span data-stu-id="39253-110">The best solution depends on the type of app you are writing, and whether you are starting from scratch or porting an existing project.</span></span>

## <a name="writing-a-new-app"></a><span data-ttu-id="39253-111">新しいアプリの作成</span><span class="sxs-lookup"><span data-stu-id="39253-111">Writing a new app</span></span>

<span data-ttu-id="39253-112">ゼロから始める場合、次のように自由に選べる多くのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="39253-112">With a clean slate, you have many options at your disposal, including:</span></span>

-   [<span data-ttu-id="39253-113">Xamarin</span><span class="sxs-lookup"><span data-stu-id="39253-113">Xamarin</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=320484)

    <span data-ttu-id="39253-114">Xamarin を使うと、C# でアプリを作成して Windows 上で実行することができ、ネイティブの iOS アプリを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="39253-114">With Xamarin, you can write your app in C#, have it run on Windows, and create native iOS apps too.</span></span> <span data-ttu-id="39253-115">Xamarin のサポートは Visual Studio に組み込まれており、適切なプロジェクトの種類を選ぶだけです。</span><span class="sxs-lookup"><span data-stu-id="39253-115">Support for Xamarin is built into Visual Studio; just select the correct project type.</span></span>

-   [<span data-ttu-id="39253-116">Apache Cordova</span><span class="sxs-lookup"><span data-stu-id="39253-116">Apache Cordova</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=400439)

    <span data-ttu-id="39253-117">Javascript と HTML の方がよい場合は、Apache Cordova (PhoneGap とも呼ばれる) を使うと、iOS、Windows、および Android 向けのクロスプラットフォーム アプリを容易に作成できます。</span><span class="sxs-lookup"><span data-stu-id="39253-117">If Javascript and HTML is more your thing, Apache Cordova (aka PhoneGap) will help you create cross-platform apps for iOS, Windows, and Android.</span></span> <span data-ttu-id="39253-118">このプロジェクトの種類は、Visual Studio にも組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="39253-118">This project type is also built into Visual Studio.</span></span>

-   <span data-ttu-id="39253-119">ゲーム エンジン</span><span class="sxs-lookup"><span data-stu-id="39253-119">Game-engines</span></span>

    <span data-ttu-id="39253-120">[Unity3D](http://go.microsoft.com/fwlink/p/?LinkID=320479) や [Unreal Engine](http://go.microsoft.com/fwlink/p/?LinkID=394062) などのツールを自由に利用することで、Windows のほか、iOS など多くのプラットフォーム用に最高品質のゲームを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="39253-120">With tools like [Unity3D](http://go.microsoft.com/fwlink/p/?LinkID=320479) and [Unreal Engine](http://go.microsoft.com/fwlink/p/?LinkID=394062) at your disposal, you can write AAA-quality games for Windows and many other platforms, including iOS.</span></span> <span data-ttu-id="39253-121">Unity は C# スクリプトをサポートし、Unreal は C++ を使います。</span><span class="sxs-lookup"><span data-stu-id="39253-121">Unity supports C# scripting; Unreal uses C++.</span></span>

-   [<span data-ttu-id="39253-122">MonoGame</span><span class="sxs-lookup"><span data-stu-id="39253-122">MonoGame</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=320483)

    <span data-ttu-id="39253-123">XNA の後継にあたります。</span><span class="sxs-lookup"><span data-stu-id="39253-123">The spiritual successor to XNA.</span></span> <span data-ttu-id="39253-124">これは、オープン ソースのクロスプラットフォーム フレームワークです。つまり、物理エンジン、2D および 3D グラフィック サポートにより、多くのプラットフォーム向けに C# でアプリを作成できます。</span><span class="sxs-lookup"><span data-stu-id="39253-124">Now, it's an open-source cross-platform framework, which means you can write apps in C# for many platforms with support for physics engines, and 2D and 3D graphics.</span></span>

## <a name="adapting-an-existing-app"></a><span data-ttu-id="39253-125">既存のアプリの適応変更</span><span class="sxs-lookup"><span data-stu-id="39253-125">Adapting an existing app</span></span>

<span data-ttu-id="39253-126">既存の iOS アプリを使う場合、オプションが少し制限されます。</span><span class="sxs-lookup"><span data-stu-id="39253-126">With an existing iOS app, your options are a little more limited.</span></span> <span data-ttu-id="39253-127">ただし、何も失われません。</span><span class="sxs-lookup"><span data-stu-id="39253-127">However, all is most certainly not lost.</span></span>

-   [<span data-ttu-id="39253-128">Windows Bridge for iOS</span><span class="sxs-lookup"><span data-stu-id="39253-128">Windows Bridge for iOS</span></span>](https://go.microsoft.com/fwlink/p/?LinkId=619014)

    <span data-ttu-id="39253-129">Project Islandwood とも呼ばれます。これはまだ開発中のツールで、Xcode プロジェクトを Visual Studio に直接インポートできます。</span><span class="sxs-lookup"><span data-stu-id="39253-129">Also known as Project Islandwood, this is a still-in-development tool that can import Xcode projects directly into Visual Studio.</span></span> <span data-ttu-id="39253-130">Objective-C コードは Visual Studio からビルドおよびデバッグできます。</span><span class="sxs-lookup"><span data-stu-id="39253-130">Objective-C code can be built and debugged from within Visual Studio.</span></span> <span data-ttu-id="39253-131">プロジェクトでグラフィックス用に Cocos などのライブラリを使用している場合、これはアプリを迅速に移植するための便利な方法です。</span><span class="sxs-lookup"><span data-stu-id="39253-131">If your project makes use of libraries such as Cocos for graphics, you might find this a useful way to quickly port your app.</span></span>

-   <span data-ttu-id="39253-132">C++ コードの目的変更</span><span class="sxs-lookup"><span data-stu-id="39253-132">Repurpose your C++ code.</span></span>

    <span data-ttu-id="39253-133">主要なビジネス ロジックが、Objective-C や Swift ではなく C++ で作成されている場合、そのコードを少し変更するだけでプロジェクトで使用できます。</span><span class="sxs-lookup"><span data-stu-id="39253-133">If your core business logic is written in C++, rather than Objective-C or Swift, you can often use this code with only minor changes in your project.</span></span> <span data-ttu-id="39253-134">そして、他の Windows でアプリと同様に、XAML を使って UI を定義し、必要に応じて C++ コードを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="39253-134">You can then use XAML to define your UI, as with other Windows apps, and call into the C++ code when necessary.</span></span>

-   [<span data-ttu-id="39253-135">ANGLE を使った Windows での OpenGL ES の実行</span><span class="sxs-lookup"><span data-stu-id="39253-135">Use ANGLE to run OpenGL ES on Windows</span></span>](http://go.microsoft.com/fwlink/p/?linkid=618387)

    <span data-ttu-id="39253-136">OpenGL ES 2.0 プロジェクトを移植する中間の手順で ANGLE を使います。</span><span class="sxs-lookup"><span data-stu-id="39253-136">An intermediate step to porting your OpenGL ES 2.0 project is to use ANGLE.</span></span> <span data-ttu-id="39253-137">ANGLE では、OpenGL ES API 呼び出しを DirectX 11 API 呼び出しに変換することにより、Windows で OpenGL ES コンテンツを実行することができます。</span><span class="sxs-lookup"><span data-stu-id="39253-137">ANGLE allows you to run OpenGL ES content on Windows by translating OpenGL ES API calls to DirectX 11 API calls.</span></span>

## <a name="other-cross-platform-authoring-tools"></a><span data-ttu-id="39253-138">その他のクロスプラットフォームの作成ツール</span><span class="sxs-lookup"><span data-stu-id="39253-138">Other cross-platform authoring tools</span></span>

-   [<span data-ttu-id="39253-139">GameSalad</span><span class="sxs-lookup"><span data-stu-id="39253-139">GameSalad</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=320480)

    <span data-ttu-id="39253-140">ゲーム作成環境。</span><span class="sxs-lookup"><span data-stu-id="39253-140">A game authoring environment.</span></span>

-   [<span data-ttu-id="39253-141">Construct 2</span><span class="sxs-lookup"><span data-stu-id="39253-141">Construct 2</span></span>]( http://go.microsoft.com/fwlink/p/?LinkID=320481)

    <span data-ttu-id="39253-142">ゲーム作成環境。</span><span class="sxs-lookup"><span data-stu-id="39253-142">A game authoring environment.</span></span>

-   [<span data-ttu-id="39253-143">Titanium Studio</span><span class="sxs-lookup"><span data-stu-id="39253-143">Titanium Studio</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=320482)

    <span data-ttu-id="39253-144">クロスプラットフォームの作成環境。</span><span class="sxs-lookup"><span data-stu-id="39253-144">A cross-platform authoring environment.</span></span>

-   [<span data-ttu-id="39253-145">Cocos2D-x</span><span class="sxs-lookup"><span data-stu-id="39253-145">Cocos2D-x</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=320485)

    <span data-ttu-id="39253-146">スプライト処理と物理モデリング用のクロスプラットフォームのコード ライブラリ。</span><span class="sxs-lookup"><span data-stu-id="39253-146">A cross-platform code library for sprite handling and physics modeling.</span></span>

-   [<span data-ttu-id="39253-147">Impact.js</span><span class="sxs-lookup"><span data-stu-id="39253-147">Impact.js</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=320486)

    <span data-ttu-id="39253-148">HTML ベースのゲーム ライブラリ。</span><span class="sxs-lookup"><span data-stu-id="39253-148">An HTML based game library.</span></span>

-   [<span data-ttu-id="39253-149">Marmalade</span><span class="sxs-lookup"><span data-stu-id="39253-149">Marmalade</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=320487)

    <span data-ttu-id="39253-150">クロスプラットフォーム SDK。</span><span class="sxs-lookup"><span data-stu-id="39253-150">A cross-platform SDK.</span></span>

-   [<span data-ttu-id="39253-151">OpenFL</span><span class="sxs-lookup"><span data-stu-id="39253-151">OpenFL</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=320488)

    <span data-ttu-id="39253-152">クロスプラットフォームの開発ツール。</span><span class="sxs-lookup"><span data-stu-id="39253-152">A cross-platform development tool.</span></span>

-   [<span data-ttu-id="39253-153">GameMaker</span><span class="sxs-lookup"><span data-stu-id="39253-153">GameMaker</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=320490)

    <span data-ttu-id="39253-154">特にゲーム用の作成環境。</span><span class="sxs-lookup"><span data-stu-id="39253-154">An authoring environment specifically for games.</span></span>

-   [<span data-ttu-id="39253-155">PlayCanvas</span><span class="sxs-lookup"><span data-stu-id="39253-155">PlayCanvas</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=394061)

    <span data-ttu-id="39253-156">HTML ベースのゲーム開発用ツール。</span><span class="sxs-lookup"><span data-stu-id="39253-156">An HTML based game development tool.</span></span>

