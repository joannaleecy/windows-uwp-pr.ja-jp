---
author: jken
ms.assetid: A77DA371-C0FE-4FAE-9E77-ADC3C9314EDF
title: "初めてのアプリの作成"
description: "Windows 10 用ユニバーサル Windows プラットフォーム (UWP) アプリの作成は、思っているよりも簡単です。"
ms.author: jken
ms.date: 03/16/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: fca180db42fcd5b8b9c30bd67fe2bb890a817c78
ms.sourcegitcommit: a2908889b3566882c7494dc81fa9ece7d1d19580
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/31/2017
---
# <a name="create-your-first-app"></a><span data-ttu-id="63331-104">初めてのアプリの作成</span><span class="sxs-lookup"><span data-stu-id="63331-104">Create your first app</span></span>

## <a name="write-a-uwp-app-using-your-favorite-programming-language"></a><span data-ttu-id="63331-105">好みのプログラミング言語を使って UWP アプリを作成する</span><span class="sxs-lookup"><span data-stu-id="63331-105">Write a UWP app using your favorite programming language</span></span>

![アプリの構築](images/build-your-app.png)

<span data-ttu-id="63331-107">UWP ([UWP とは何か](whats-a-uwp.md)) プラットフォームへようこそ。</span><span class="sxs-lookup"><span data-stu-id="63331-107">Welcome to the UWP ([what's UWP again?](whats-a-uwp.md)) platform!</span></span> <span data-ttu-id="63331-108">このチュートリアルは、好みの言語で初めての UWP アプリを作る際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="63331-108">These tutorials will help you create your first UWP app in the language of your choice.</span></span> <span data-ttu-id="63331-109">次の方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="63331-109">You'll learn how to:</span></span>

-   <span data-ttu-id="63331-110">Microsoft Visual Studio で UWP プロジェクトを作成する。</span><span class="sxs-lookup"><span data-stu-id="63331-110">Create UWP projects in Microsoft Visual Studio.</span></span>
-   <span data-ttu-id="63331-111">プロジェクトに UI 要素とコードを追加する。</span><span class="sxs-lookup"><span data-stu-id="63331-111">Add UI elements and code to your project.</span></span>
-   <span data-ttu-id="63331-112">アプリでインクと Dial を使用する。</span><span class="sxs-lookup"><span data-stu-id="63331-112">Use Ink and the Dial in your apps.</span></span>
-   <span data-ttu-id="63331-113">サード パーティ製ライブラリを使って新しい機能を追加する。</span><span class="sxs-lookup"><span data-stu-id="63331-113">Use third party libraries to add new functionality.</span></span>
-   <span data-ttu-id="63331-114">ローカル コンピューターでアプリをビルドしてデバッグする。</span><span class="sxs-lookup"><span data-stu-id="63331-114">Build and debug your app on your local machine.</span></span>

<span data-ttu-id="63331-115">最初に、好みの言語を選びます。</span><span class="sxs-lookup"><span data-stu-id="63331-115">To get started, choose your favorite language!</span></span>

## <a name="c-and-xaml"></a><span data-ttu-id="63331-116">C# と XAML</span><span class="sxs-lookup"><span data-stu-id="63331-116">C# and XAML</span></span>

<span data-ttu-id="63331-117">.NET、WPF、または Silverlight のスキルを活用し、XAML と C# を使ったアプリを作ります。</span><span class="sxs-lookup"><span data-stu-id="63331-117">Use your .NET, WPF, or Silverlight skills to build apps using XAML with C#.</span></span>

* [<span data-ttu-id="63331-118">XAML と C# で "Hello, world" アプリを作る</span><span class="sxs-lookup"><span data-stu-id="63331-118">Create a "Hello, world" app using XAML with C#</span></span>](create-a-hello-world-app-xaml-universal.md)

<span data-ttu-id="63331-119">基本を学習したり、知識を再確認したりする場合は、次のリソースをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="63331-119">If you want to learn the basics, or just refresh your memory, try reading these:</span></span>

* [<span data-ttu-id="63331-120">文字どおりの初心者のための C# の基本</span><span class="sxs-lookup"><span data-stu-id="63331-120">C# Fundamentals for Absolute Beginners</span></span>](https://go.microsoft.com/fwlink/?linkid=850801)
* [<span data-ttu-id="63331-121">文字どおりの初心者のための VB の基本</span><span class="sxs-lookup"><span data-stu-id="63331-121">VB Fundamentals for Absolute Beginners</span></span>](https://go.microsoft.com/fwlink/?linkid=850802)
* [<span data-ttu-id="63331-122">Windows 10 開発者向けガイド</span><span class="sxs-lookup"><span data-stu-id="63331-122">A Developer's Guide to Windows 10</span></span>](https://go.microsoft.com/fwlink/?linkid=850804)
* [<span data-ttu-id="63331-123">Microsoft Virtual Academy</span><span class="sxs-lookup"><span data-stu-id="63331-123">Microsoft Virtual Academy</span></span>](http://www.microsoftvirtualacademy.com/)

<span data-ttu-id="63331-124">"Hello, World!" よりも少し進んだ内容が必要な場合は、次の C# および MonoGame のチュートリアルを試してください。</span><span class="sxs-lookup"><span data-stu-id="63331-124">If you are ready to attempt something a little more fun than "Hello, World!", try this C# and MonoGame tutorial:</span></span>

* [<span data-ttu-id="63331-125">C# と MonoGame で記述された Windows ストア向けのシンプルな 2D UWP ゲーム</span><span class="sxs-lookup"><span data-stu-id="63331-125">A simple 2D UWP game for the Windows Store, written in C# and MonoGame</span></span>](get-started-tutorial-game-mg2d.md)

## <a name="javascript-and-html"></a><span data-ttu-id="63331-126">JavaScript と HTML</span><span class="sxs-lookup"><span data-stu-id="63331-126">JavaScript and HTML</span></span>

<span data-ttu-id="63331-127">Web のスキルを活用し、HTML5、CSS3、JavaScript を使ったアプリを作ります。</span><span class="sxs-lookup"><span data-stu-id="63331-127">Take advantage of your web skills to build apps using HTML5, CSS3, and JavaScript.</span></span>

* [<span data-ttu-id="63331-128">HTML と JavaScript を使った "Hello, world" アプリの作成</span><span class="sxs-lookup"><span data-stu-id="63331-128">Create a "Hello, world" app using HTML and JavaScript</span></span>](create-a-hello-world-app-js-uwp.md)
* [<span data-ttu-id="63331-129">JavaScript と CreateJS で記述された Windows ストア向けのシンプルな 2D UWP ゲーム</span><span class="sxs-lookup"><span data-stu-id="63331-129">A simple 2D UWP game for the Windows Store, written in JavaScript and CreateJS</span></span>](get-started-tutorial-game-js2d.md)
* [<span data-ttu-id="63331-130">JavaScript と threeJS で記述された Windows ストア向けの 3D UWP ゲーム</span><span class="sxs-lookup"><span data-stu-id="63331-130">A 3D UWP game for the Windows Store, written in JavaScript and threeJS</span></span>](get-started-tutorial-game-js3d.md)
* [<span data-ttu-id="63331-131">REST API を使った単一ページの Web アプリ</span><span class="sxs-lookup"><span data-stu-id="63331-131">A single-page web app with REST API</span></span>](get-started-tutorial-fullstack-web-app.md)

<span data-ttu-id="63331-132">Web のスキルをブラッシュアップする必要がある場合は、以下をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="63331-132">Need to brush up on your web skills?</span></span>

* [<span data-ttu-id="63331-133">文字どおりの初心者のための JavaScript の基本</span><span class="sxs-lookup"><span data-stu-id="63331-133">JavaScript Fundamentals for Absolute Beginners</span></span>](http://www.microsoftvirtualacademy.com/training-courses/javascript-fundamentals-for-absolute-beginners)
* [<span data-ttu-id="63331-134">文字どおりの初心者のための HTML5 と CSS3 の基本</span><span class="sxs-lookup"><span data-stu-id="63331-134">HTML5 & CSS3 Fundamentals for Absolute Beginners</span></span>](http://www.microsoftvirtualacademy.com/training-courses/html5-css3-fundamentals-development-for-absolute-beginners)
* [<span data-ttu-id="63331-135">Microsoft Virtual Academy</span><span class="sxs-lookup"><span data-stu-id="63331-135">Microsoft Virtual Academy</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=389916)

## <a name="visual-c-component-extensions-ccx-and-xaml"></a><span data-ttu-id="63331-136">Visual C++ コンポーネント拡張機能 (C++/CX) と XAML</span><span class="sxs-lookup"><span data-stu-id="63331-136">Visual C++ component extensions (C++/CX) and XAML</span></span>

<span data-ttu-id="63331-137">C++ プログラミングの専門知識を活用し、Visual C++ コンポーネント拡張機能 (C++/CX) と XAML を使ってアプリを作ります。</span><span class="sxs-lookup"><span data-stu-id="63331-137">Take advantage of your C++ programming expertise to build apps using Visual C++ component extensions (C++/CX) with XAML.</span></span>

* [<span data-ttu-id="63331-138">XAML と C++/CX で "Hello, world" アプリを作る</span><span class="sxs-lookup"><span data-stu-id="63331-138">Create a "Hello, world" app using XAML with C++/CX</span></span>](create-a-basic-windows-10-app-in-cpp.md)

<span data-ttu-id="63331-139">C++ の詳しい情報については、以下をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="63331-139">Learn more about C++ here:</span></span>

* [<span data-ttu-id="63331-140">C++: 汎用言語およびライブラリ ジャンプ スタート</span><span class="sxs-lookup"><span data-stu-id="63331-140">C++: A General Purpose Language and Library Jump Start</span></span>](http://www.microsoftvirtualacademy.com/training-courses/c-a-general-purpose-language-and-library-jump-start)
* [<span data-ttu-id="63331-141">Microsoft Virtual Academy</span><span class="sxs-lookup"><span data-stu-id="63331-141">Microsoft Virtual Academy</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=389916)

## <a name="using-features-unique-to-windows-10"></a><span data-ttu-id="63331-142">Windows 10 の独自の機能を使用する</span><span class="sxs-lookup"><span data-stu-id="63331-142">Using features unique to Windows 10</span></span>

<span data-ttu-id="63331-143">Windows 10 の一番の特徴は何でしょうか。</span><span class="sxs-lookup"><span data-stu-id="63331-143">What makes Windows 10 special?</span></span> <span data-ttu-id="63331-144">インクや Surface Dial のコントローラーは大きな特徴です。</span><span class="sxs-lookup"><span data-stu-id="63331-144">Among other things, Ink and the Surface Dial controller.</span></span>

* [<span data-ttu-id="63331-145">UWP アプリでのインクの使用</span><span class="sxs-lookup"><span data-stu-id="63331-145">Using ink in your UWP app</span></span>](ink-walkthrough.md)
* [<span data-ttu-id="63331-146">Surface Dial のサポート</span><span class="sxs-lookup"><span data-stu-id="63331-146">Support the Surface Dial</span></span>](radialcontroller-walkthrough.md)

## <a name="cutting-edge-ideas"></a><span data-ttu-id="63331-147">最先端のアイデア</span><span class="sxs-lookup"><span data-stu-id="63331-147">Cutting Edge ideas</span></span>

<span data-ttu-id="63331-148">仮想現実の活用に関心がありますか</span><span class="sxs-lookup"><span data-stu-id="63331-148">Interested in exploring Virtual Reality?</span></span>

* [<span data-ttu-id="63331-149">Babylon.js ゲームに WebVR を追加する</span><span class="sxs-lookup"><span data-stu-id="63331-149">Adding WebVR to a Babylon.js game</span></span>](adding-webvr-to-a-babylonjs-game.md)

## <a name="objective-c"></a><span data-ttu-id="63331-150">Objective-C</span><span class="sxs-lookup"><span data-stu-id="63331-150">Objective-C</span></span>

<span data-ttu-id="63331-151">どちらかといえば iOS 開発者である場合</span><span class="sxs-lookup"><span data-stu-id="63331-151">Are you more of an iOS developer?</span></span> 

* <span data-ttu-id="63331-152">[iOS 用 Windows ブリッジ](https://developer.microsoft.com/windows/bridges/ios)を使って既存のコードを UWP アプリに変換し、Objective-C での開発を続けてください。</span><span class="sxs-lookup"><span data-stu-id="63331-152">Use the [Windows Bridge for iOS](https://developer.microsoft.com/windows/bridges/ios) to convert your existing code to a UWP app, and keep developing in Objective-C.</span></span>


## <a name="cross-platform-and-mobile-development"></a><span data-ttu-id="63331-153">クロスプラットフォームとモバイル開発</span><span class="sxs-lookup"><span data-stu-id="63331-153">Cross-platform and mobile development</span></span>

* <span data-ttu-id="63331-154">Android や iOS をターゲットとする必要がある場合は、</span><span class="sxs-lookup"><span data-stu-id="63331-154">Need to target Android and iOS?</span></span> <span data-ttu-id="63331-155">[Xamarin](https://www.xamarin.com) をチェックしてください。</span><span class="sxs-lookup"><span data-stu-id="63331-155">Check out [Xamarin](https://www.xamarin.com).</span></span>

## <a name="see-also"></a><span data-ttu-id="63331-156">参照</span><span class="sxs-lookup"><span data-stu-id="63331-156">See Also</span></span>

* <span data-ttu-id="63331-157">[Windows ストア アプリの公開](https://developer.microsoft.com/store/publish-apps)</span><span class="sxs-lookup"><span data-stu-id="63331-157">[Publishing your Windows Store app](https://developer.microsoft.com/store/publish-apps).</span></span>
* [<span data-ttu-id="63331-158">UWP アプリの開発に関するハウツー記事</span><span class="sxs-lookup"><span data-stu-id="63331-158">How-to articles on developing UWP apps</span></span>](https://developer.microsoft.com/windows/apps/develop)
* [<span data-ttu-id="63331-159">UWP 開発者向けコード サンプル</span><span class="sxs-lookup"><span data-stu-id="63331-159">Code Samples for UWP developers</span></span>](https://developer.microsoft.com/windows/samples)
* [<span data-ttu-id="63331-160">ユニバーサル Windows アプリとは?</span><span class="sxs-lookup"><span data-stu-id="63331-160">What's a Universal Windows app?</span></span>](whats-a-uwp.md)
* [<span data-ttu-id="63331-161">準備</span><span class="sxs-lookup"><span data-stu-id="63331-161">Get set up</span></span>](get-set-up.md)
* [<span data-ttu-id="63331-162">Windows アカウントのサインアップ</span><span class="sxs-lookup"><span data-stu-id="63331-162">Sign up for Windows account</span></span>](sign-up.md)

