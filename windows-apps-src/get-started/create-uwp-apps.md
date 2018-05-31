---
author: QuinnRadich
title: ユニバーサル Windows プラットフォームを使用してアプリを作成する
description: Windows 10 用ユニバーサル Windows プラットフォーム (UWP) アプリの作成は、思っているよりも簡単です。
ms.author: quradic
ms.date: 08/24/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 66536a3059ea6d9b17709c836f4149b1ec583165
ms.sourcegitcommit: 1eabcf511c7c7803a19eb31f600c6ac4a0067786
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1692713"
---
# <a name="create-apps-for-windows-10"></a><span data-ttu-id="98310-104">Windows 10 のアプリの作成</span><span class="sxs-lookup"><span data-stu-id="98310-104">Create apps for Windows 10</span></span>

![アプリの構築](images/build-your-app.png)

<span data-ttu-id="98310-106">[UWP プラットフォーム](universal-application-platform-guide.md)へようこそ。</span><span class="sxs-lookup"><span data-stu-id="98310-106">Welcome to the [UWP platform](universal-application-platform-guide.md)!</span></span> <span data-ttu-id="98310-107">初めての UWP アプリを作ろうとしている場合も、高度な機能を組み込もうとしている場合も、このチュートリアルで以下の方法を学習できます。</span><span class="sxs-lookup"><span data-stu-id="98310-107">Whether you're looking to get started with your first UWP app or are looking to use more advanced features, these tutorials will put you on the right track. You'll learn how to:</span></span>

-   <span data-ttu-id="98310-108">Microsoft Visual Studio で UWP プロジェクトを作成する。</span><span class="sxs-lookup"><span data-stu-id="98310-108">Create UWP projects in Microsoft Visual Studio.</span></span>
-   <span data-ttu-id="98310-109">プロジェクトに UI 要素とコードを追加する。</span><span class="sxs-lookup"><span data-stu-id="98310-109">Add UI elements and code to your project.</span></span>
-   <span data-ttu-id="98310-110">XAML、データ バインディング、およびその他の基本的な UWP 要素を使用する。</span><span class="sxs-lookup"><span data-stu-id="98310-110">Use XAML, data binding, and other fundamental UWP elements.</span></span>
-   <span data-ttu-id="98310-111">インクやダイヤルなどのユニークな UWP 機能をアプリに組み込む。</span><span class="sxs-lookup"><span data-stu-id="98310-111">Incorporate unique UWP features such as Ink and Dial into your app.</span></span>
-   <span data-ttu-id="98310-112">サード パーティ製ライブラリを使って新しい機能を追加する。</span><span class="sxs-lookup"><span data-stu-id="98310-112">Use third party libraries to add new functionality.</span></span>
-   <span data-ttu-id="98310-113">ローカル コンピューターでアプリをビルドしてデバッグする。</span><span class="sxs-lookup"><span data-stu-id="98310-113">Build and debug your app on your local machine.</span></span>

## <a name="ask-a-bot"></a><span data-ttu-id="98310-114">ボットに尋ねてみる</span><span class="sxs-lookup"><span data-stu-id="98310-114">Ask a bot!</span></span>

<span data-ttu-id="98310-115">行き詰った場合や適切なドキュメントを探せない場合は、下の実験的なボットに尋ねてみてください。</span><span class="sxs-lookup"><span data-stu-id="98310-115">If you're stuck or need some help finding the right docs, try asking the experimental chat bot below.</span></span> <span data-ttu-id="98310-116">たとえば、"Where can I download Visual Studio?" (Visual Studio はどこでダウンロードできますか?" </span><span class="sxs-lookup"><span data-stu-id="98310-116">For example, ask 'Where can I download Visual Studio?'</span></span> <span data-ttu-id="98310-117">または "Tell me about Fluent Design" (Fluent Design について教えてください) のように質問します。</span><span class="sxs-lookup"><span data-stu-id="98310-117">or 'Tell me about Fluent Design".</span></span> <span data-ttu-id="98310-118">有用な回答を得られない場合は、少し質問文を変更してみてください。</span><span class="sxs-lookup"><span data-stu-id="98310-118">If you don't get a useful answer, try rewording your query slightly.</span></span>

<iframe src='https://webchat.botframework.com/embed/DocBot4?s=T2nP6qZUXC8.cwA.lvc.AR-ZBwtULpaITu6_dAhMwrmg4R2GSLNzIoiMNFL8M7M' height="400" width="400"></iframe>

## <a name="write-your-first-uwp-app-in-your-favorite-programming-language"></a><span data-ttu-id="98310-119">好みのプログラミング言語で初めての UWP アプリを作成する</span><span class="sxs-lookup"><span data-stu-id="98310-119">Write your first UWP app in your favorite programming language</span></span>

<span data-ttu-id="98310-120">新人の開発者や Windows プラットフォームについての知識があり UWP を始める開発者は、以下の基本的なチュートリアルをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="98310-120">If you're a new developer or if you're familiar with the Windows platform and want to get started with UWP, check out these basic tutorials:</span></span>

* [<span data-ttu-id="98310-121">C#、Visual C++、または JavaScript を使って初めての UWP アプリを作成する</span><span class="sxs-lookup"><span data-stu-id="98310-121">Create your first UWP app with C#, Visual C++, or JavaScript</span></span>](your-first-app.md)

<span data-ttu-id="98310-122">iOS 開発者の方:</span><span class="sxs-lookup"><span data-stu-id="98310-122">Are you an IOS developer?</span></span>

* <span data-ttu-id="98310-123">[iOS 用 Windows ブリッジ](https://developer.microsoft.com/windows/bridges/ios)を使って既存のコードを UWP アプリに変換し、Objective-C での開発を続けてください。</span><span class="sxs-lookup"><span data-stu-id="98310-123">Use the [Windows Bridge for iOS](https://developer.microsoft.com/windows/bridges/ios) to convert your existing code to a UWP app, and keep developing in Objective-C.</span></span>

<span data-ttu-id="98310-124">まだ学習中の場合や記憶している内容を確認する必要がある場合は、以下の外部リソースをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="98310-124">If you're still learning or need to refresh your memory, try reading these external resources:</span></span>

* [<span data-ttu-id="98310-125">Windows 10 開発者向けガイド</span><span class="sxs-lookup"><span data-stu-id="98310-125">A Developer's Guide to Windows 10</span></span>](https://go.microsoft.com/fwlink/?linkid=850804)
* [<span data-ttu-id="98310-126">Microsoft Virtual Academy</span><span class="sxs-lookup"><span data-stu-id="98310-126">Microsoft Virtual Academy</span></span>](http://www.microsoftvirtualacademy.com/)

## <a name="customize-your-apps-layout-and-appearance-with-xaml"></a><span data-ttu-id="98310-127">XAML を使ってアプリのレイアウトと外観をカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="98310-127">Customize your app's layout and appearance with XAML</span></span>

<span data-ttu-id="98310-128">ほとんどの UWP アプリでは、XAML マークアップ言語を使用して UI を作成します。</span><span class="sxs-lookup"><span data-stu-id="98310-128">Most UWP apps use the XAML markup language to create their UI.</span></span> <span data-ttu-id="98310-129">コア機能を使用してアプリの外観をカスタマイズする方法について説明し、このガイダンスに従って独自のアプリの外観を作成します。</span><span class="sxs-lookup"><span data-stu-id="98310-129">Learn how you can use its core features to customize your app's visual presentation, and explore this guidance for creating a unique look for your app.</span></span>

* [<span data-ttu-id="98310-130">アプリの UI 設計の概要</span><span class="sxs-lookup"><span data-stu-id="98310-130">Intro to app UI design</span></span>](../design/basics/design-and-ui-intro.md)
* [<span data-ttu-id="98310-131">チュートリアル: XAML でユーザー インターフェイスを作成する</span><span class="sxs-lookup"><span data-stu-id="98310-131">Tutorial: Create a user interface in XAML</span></span>](../design/basics/xaml-basics-ui.md)
* [<span data-ttu-id="98310-132">UWP アプリのレイアウト</span><span class="sxs-lookup"><span data-stu-id="98310-132">Layout for UWP apps</span></span>](../design/layout/index.md)
* [<span data-ttu-id="98310-133">UWP アプリのコントロールとパターン</span><span class="sxs-lookup"><span data-stu-id="98310-133">Controls and patterns for UWP apps</span></span>](../design/controls-and-patterns/index.md)

## <a name="use-features-unique-to-windows-10"></a><span data-ttu-id="98310-134">Windows 10 の独自の機能を使用する</span><span class="sxs-lookup"><span data-stu-id="98310-134">Use features unique to Windows 10</span></span>

<span data-ttu-id="98310-135">Windows 10 の一番の特徴は何でしょうか。</span><span class="sxs-lookup"><span data-stu-id="98310-135">What makes Windows 10 special?</span></span> <span data-ttu-id="98310-136">Windows 10 のユニークな機能の使用方法を少しだけご紹介します。</span><span class="sxs-lookup"><span data-stu-id="98310-136">Learn to use just some of its unique features.</span></span>

* [<span data-ttu-id="98310-137">チュートリアル: UWP アプリでインクをサポートする</span><span class="sxs-lookup"><span data-stu-id="98310-137">Tutorial: Support ink in your UWP app</span></span>](../design/input/ink-walkthrough.md)
* [<span data-ttu-id="98310-138">チュートリアル: Surface Dial のサポート</span><span class="sxs-lookup"><span data-stu-id="98310-138">Tutorial: Support the Surface Dial</span></span>](../design/input/radialcontroller-walkthrough.md)
* [<span data-ttu-id="98310-139">最新バージョンの Windows の新機能</span><span class="sxs-lookup"><span data-stu-id="98310-139">Explore what's new in the latest vesion of Windows</span></span>](../whats-new/windows-10-version-latest.md)

<span data-ttu-id="98310-140">Windows 10 開発のためのハウツー記事と詳細なドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="98310-140">Explore how-to articles and detailed documentation for Windows 10 development:</span></span>

* [<span data-ttu-id="98310-141">UWP アプリの開発に関するハウツー記事</span><span class="sxs-lookup"><span data-stu-id="98310-141">How-to articles on developing UWP apps</span></span>](https://developer.microsoft.com/windows/apps/develop)
* [<span data-ttu-id="98310-142">UWP アプリ用 API リファレンス</span><span class="sxs-lookup"><span data-stu-id="98310-142">API reference for UWP apps</span></span>](https://docs.microsoft.com/en-us/uwp/)

## <a name="develop-javascript-and-web-apps"></a><span data-ttu-id="98310-143">JavaScript アプリと Web アプリの開発</span><span class="sxs-lookup"><span data-stu-id="98310-143">Develop JavaScript and web apps</span></span>

<span data-ttu-id="98310-144">UWP はきわめて柔軟なプラットフォームであり、多様な言語およびフレームワークをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="98310-144">UWP is an extremely flexible platform that supports a wide variety of languages and frameworks.</span></span> <span data-ttu-id="98310-145">UWP アプリを JavaScript で構築し、ホストされた Web アプリを自分のスキルで構築して、Microsoft Store で販売促進できます。</span><span class="sxs-lookup"><span data-stu-id="98310-145">Build UWP apps with JavaScript, and use your skills to build hosted web apps which can be featured in the Microsoft Store.</span></span>

* [<span data-ttu-id="98310-146">Web のスキルを活用し、HTML5、CSS3、JavaScript を使ったアプリを作ります。</span><span class="sxs-lookup"><span data-stu-id="98310-146">Take advantage of your web skills to build apps using HTML5, CSS3, and JavaScript.</span></span>](your-first-app.md#javascript-and-html)

<span data-ttu-id="98310-147">Web アプリの構築について詳しくは、以下をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="98310-147">Interested in more information on building web apps?</span></span>

* [<span data-ttu-id="98310-148">Microsoft Edge 開発者ドキュメント</span><span class="sxs-lookup"><span data-stu-id="98310-148">Microsoft Edge developer documentation</span></span>](https://docs.microsoft.com/microsoft-edge/)

## <a name="cross-platform-and-mobile-development"></a><span data-ttu-id="98310-149">クロスプラットフォームとモバイル開発</span><span class="sxs-lookup"><span data-stu-id="98310-149">Cross-platform and mobile development</span></span>

* <span data-ttu-id="98310-150">Android や iOS をターゲットとする必要がある場合は、</span><span class="sxs-lookup"><span data-stu-id="98310-150">Need to target Android and iOS?</span></span> <span data-ttu-id="98310-151">[Xamarin](https://www.xamarin.com) をチェックしてください。</span><span class="sxs-lookup"><span data-stu-id="98310-151">Check out [Xamarin](https://www.xamarin.com).</span></span>

## <a name="see-also"></a><span data-ttu-id="98310-152">関連項目</span><span class="sxs-lookup"><span data-stu-id="98310-152">See Also</span></span>

* <span data-ttu-id="98310-153">[UWP アプリを公開する](https://developer.microsoft.com/store/publish-apps)</span><span class="sxs-lookup"><span data-stu-id="98310-153">[Publishing your UWP app](https://developer.microsoft.com/store/publish-apps).</span></span>
* [<span data-ttu-id="98310-154">UWP アプリの開発に関するハウツー記事</span><span class="sxs-lookup"><span data-stu-id="98310-154">How-to articles on developing UWP apps</span></span>](https://developer.microsoft.com/windows/apps/develop)
* [<span data-ttu-id="98310-155">UWP 開発者向けコード サンプル</span><span class="sxs-lookup"><span data-stu-id="98310-155">Code Samples for UWP developers</span></span>](https://developer.microsoft.com/windows/samples)
* [<span data-ttu-id="98310-156">UWP アプリとは</span><span class="sxs-lookup"><span data-stu-id="98310-156">What's a UWP app?</span></span>](universal-application-platform-guide.md)
* [<span data-ttu-id="98310-157">準備</span><span class="sxs-lookup"><span data-stu-id="98310-157">Get set up</span></span>](get-set-up.md)
* [<span data-ttu-id="98310-158">Windows アカウントのサインアップ</span><span class="sxs-lookup"><span data-stu-id="98310-158">Sign up for Windows account</span></span>](sign-up.md)