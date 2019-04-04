---
title: 2019 年 1 月の新 Windows ドキュメント - UWP アプリを開発します。
description: 2019 年 1 月の Windows 10 開発者向けドキュメントに追加された新機能、ビデオ、および開発者向けガイダンス
keywords: 新機能については、更新、機能、開発者ガイド、Windows 10 では、年 1 月
ms.date: 01/17/2019
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: beb80c28866b8f8207f203b70cb504dcd034098d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57636577"
---
# <a name="whats-new-in-the-windows-developer-docs-in-january-2019"></a><span data-ttu-id="9128b-104">新機能については、Windows 開発者向けドキュメントで 2019 年 1 月です。</span><span class="sxs-lookup"><span data-stu-id="9128b-104">What's New in the Windows Developer Docs in January 2019</span></span>

<span data-ttu-id="9128b-105">Windows 開発者向けドキュメントは、Windows プラットフォームで開発者に提供される新機能の情報を反映して継続的に更新されています。</span><span class="sxs-lookup"><span data-stu-id="9128b-105">The Windows Developer Documentation is constantly being updated with information on new features available to developers across the Windows platform.</span></span> <span data-ttu-id="9128b-106">次の機能の概要、開発者ガイド、およびビデオが年 1 月の 1 か月間利用可能な加えられました。</span><span class="sxs-lookup"><span data-stu-id="9128b-106">The following feature overviews, developer guidance, and videos have been made available in the month of January.</span></span>

<span data-ttu-id="9128b-107">Windows 10 の[ツールと SDK をインストール](https://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/create-uwp-apps.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="9128b-107">[Install the tools and SDK](https://go.microsoft.com/fwlink/?LinkId=821431) on Windows 10 and you’re ready to either [create a new Universal Windows app](../get-started/create-uwp-apps.md) or explore how you can use your [existing app code on Windows](../porting/index.md).</span></span>

## <a name="features"></a><span data-ttu-id="9128b-108">機能</span><span class="sxs-lookup"><span data-stu-id="9128b-108">Features</span></span>

### <a name="windows-development-on-microsoft-learn"></a><span data-ttu-id="9128b-109">Microsoft の学習での Windows 開発</span><span class="sxs-lookup"><span data-stu-id="9128b-109">Windows development on Microsoft Learn</span></span>

<span data-ttu-id="9128b-110">Microsoft の学習は、Microsoft の開発者に新しい実践的な学習とトレーニングの機会を提供します。</span><span class="sxs-lookup"><span data-stu-id="9128b-110">Microsoft Learn provides new hands-on learning and training opportunities to Microsoft developers.</span></span> <span data-ttu-id="9128b-111">Windows アプリを開発する方法を学習する場合は、チェック アウト[、新規のラーニング パス](https://docs.microsoft.com/learn/paths/develop-windows10-apps/)徹底的な概要については、プラットフォーム、ツール、および、最初のいくつかのアプリを記述する方法。</span><span class="sxs-lookup"><span data-stu-id="9128b-111">If you're interested in learning how to develop Windows apps, check out [our new learning path](https://docs.microsoft.com/learn/paths/develop-windows10-apps/) for a thorough introduction to the platform, the tools, and how to write your first few apps.</span></span>

![ラーニング パス Windows 開発の画像](images/windows-learn.png)

### <a name="direct-3d-12"></a><span data-ttu-id="9128b-113">Direct 3D 12</span><span class="sxs-lookup"><span data-stu-id="9128b-113">Direct 3D 12</span></span>

<span data-ttu-id="9128b-114">[Direct3d12 のレンダリング パス](/windows/desktop/direct3d12/direct3d-12-render-passes)パフォーマンスを向上できます、レンダラーの延期タイル ベースのレンダリング (TBDR) に基づく場合などのテクニックです。</span><span class="sxs-lookup"><span data-stu-id="9128b-114">[Direct3D 12 render passes](/windows/desktop/direct3d12/direct3d-12-render-passes) can improve the performance of your renderer if it's based on Tile-Based Deferred Rendering (TBDR), among other techniques.</span></span> <span data-ttu-id="9128b-115">リソースの表示順序要件とデータの依存関係を識別するために、アプリケーションを有効にするチップをメモリとの間のメモリ トラフィックを削減して GPU の効率を向上させるために、このレンダラーをによりします。</span><span class="sxs-lookup"><span data-stu-id="9128b-115">The technique helps your renderer to improve GPU efficiency by enabling your application to better identify resource rendering ordering requirements and data dependencies, and thus reducing memory traffic to/from off-chip memory.</span></span>

### <a name="msix-modification-packages"></a><span data-ttu-id="9128b-116">MSIX 変更パッケージ</span><span class="sxs-lookup"><span data-stu-id="9128b-116">MSIX modification packages</span></span>

<span data-ttu-id="9128b-117">Windows 10 バージョン 1809 のサポート強化[MSIX 変更パッケージ](https://docs.microsoft.com/windows/msix/modification-package-1809-update)します。</span><span class="sxs-lookup"><span data-stu-id="9128b-117">Windows 10 version 1809 improved support for [MSIX modification packages](https://docs.microsoft.com/windows/msix/modification-package-1809-update).</span></span> <span data-ttu-id="9128b-118">変更のパッケージは、レジストリ ベースのプラグインと、関連付けられているカスタマイズを含めることができます、MSIX 仮想レジストリを使用して、想定どおりに実行を使用してデプロイされたアプリケーションを有効になります。</span><span class="sxs-lookup"><span data-stu-id="9128b-118">Modification packages can include registry-based plugins and associated customization, and will enable an application deployed through MSIX to use a virtual registry and run as expected.</span></span>

![MSIX 修正パッケージの作成](images/msix-modification-package.png)

### <a name="open-source-of-wpf-windows-forms-and-winui"></a><span data-ttu-id="9128b-120">WPF、Windows フォーム、および WinUI のオープン ソース</span><span class="sxs-lookup"><span data-stu-id="9128b-120">Open Source of WPF, Windows Forms, and WinUI</span></span>

<span data-ttu-id="9128b-121">GitHub のオープン ソース コントリビューションの WPF、Windows フォーム、および WinUI UX のフレームワークがあるようになりました。</span><span class="sxs-lookup"><span data-stu-id="9128b-121">The WPF, Windows Forms, and WinUI UX frameworks are now available for open-source contributions on GitHub.</span></span> <span data-ttu-id="9128b-122">詳細な情報とリンクについては、、 [building Windows アプリのブログ](https://blogs.windows.com/buildingapps/2018/12/04/announcing-open-source-of-wpf-windows-forms-and-winui-at-microsoft-connect-2018/#OKZjJs1VVTrMMtkL.97)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9128b-122">For more information and links, see the [building Windows apps blog](https://blogs.windows.com/buildingapps/2018/12/04/announcing-open-source-of-wpf-windows-forms-and-winui-at-microsoft-connect-2018/#OKZjJs1VVTrMMtkL.97).</span></span>

### <a name="progressive-web-apps-for-xbox"></a><span data-ttu-id="9128b-123">プログレッシブ Web Apps for Xbox</span><span class="sxs-lookup"><span data-stu-id="9128b-123">Progressive Web Apps for Xbox</span></span>

<span data-ttu-id="9128b-124">[Xbox One の Web アプリをプログレッシブ](https://docs.microsoft.com/microsoft-edge/progressive-web-apps/xbox-considerations)、web アプリケーションを拡張し、使用できるように Xbox One のアプリケーションとして Microsoft Store を使用して、既存のフレームワーク、CDN、およびサーバーのバックエンドを使用する継続しているときにすることができます。</span><span class="sxs-lookup"><span data-stu-id="9128b-124">With [Progressive Web Apps for Xbox One](https://docs.microsoft.com/microsoft-edge/progressive-web-apps/xbox-considerations), you can extend a web application and make it available as an Xbox One app via Microsoft Store while still continuing to use your existing frameworks, CDN and server backend.</span></span> <span data-ttu-id="9128b-125">ほとんどの場合、パッケージ化して、PWA Xbox One の Windows の場合と同じ方法で、ただし、このガイドの説明をいくつかの主な違いがあります。</span><span class="sxs-lookup"><span data-stu-id="9128b-125">For the most part, you can package your PWA for Xbox One in the same way you would for Windows, however, there are several key differences this guide will walk you through.</span></span>

### <a name="windows-machine-learning"></a><span data-ttu-id="9128b-126">Windows Machine learning</span><span class="sxs-lookup"><span data-stu-id="9128b-126">Windows Machine learning</span></span>

<span data-ttu-id="9128b-127">私たちにして再構築した[WinML Api のランディング ページ](https://docs.microsoft.com/windows/ai/api-reference)、WinML カスタム演算子とネイティブ Api の新しいドキュメントを追加します。</span><span class="sxs-lookup"><span data-stu-id="9128b-127">We've restructured [the landing page for WinML APIs](https://docs.microsoft.com/windows/ai/api-reference), and added new documentation for WinML custom operator and native APIs.</span></span>

<span data-ttu-id="9128b-128">[PyTorch を持つモデルをトレーニング](https://docs.microsoft.com/windows/ai/train-model-pytorch)PyTorch フレームワークをローカルまたはクラウドのいずれかを使用してモデルをトレーニングする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="9128b-128">[Train a model with PyTorch](https://docs.microsoft.com/windows/ai/train-model-pytorch) provides guidance on how to train a model using the PyTorch framework either locally or in the cloud.</span></span> <span data-ttu-id="9128b-129">このモデルを ONNX ファイルとしてダウンロードし、WinML アプリケーションで使用します。</span><span class="sxs-lookup"><span data-stu-id="9128b-129">You can then download this model as an ONNX file and use it in your WinML applications.</span></span>

![WinML グラフィック](images/winml-graphic.png)

## <a name="developer-guidance"></a><span data-ttu-id="9128b-131">開発者向けガイダンス</span><span class="sxs-lookup"><span data-stu-id="9128b-131">Developer Guidance</span></span>

### <a name="choose-your-platform"></a><span data-ttu-id="9128b-132">プラットフォームを選択します</span><span class="sxs-lookup"><span data-stu-id="9128b-132">Choose your platform</span></span>

<span data-ttu-id="9128b-133">新しいデスクトップ アプリケーションの作成に興味はあるでしょうか。</span><span class="sxs-lookup"><span data-stu-id="9128b-133">Interested in creating a new desktop application?</span></span> <span data-ttu-id="9128b-134">チェック アウト、刷新[プラットフォームを選択](https://docs.microsoft.com/windows/desktop/choose-your-technology)詳細な説明と、UWP、WPF、および Windows フォームのプラットフォームと Win32 API の詳細についての比較ページ。</span><span class="sxs-lookup"><span data-stu-id="9128b-134">Check out our revamped [Choose your platform](https://docs.microsoft.com/windows/desktop/choose-your-technology) page for detailed descriptions and comparisons of the UWP, WPF, and Windows Forms platforms, and further information on the Win32 API.</span></span>

### <a name="faqs-on-win32-webview"></a><span data-ttu-id="9128b-135">Win32 の WebView でよく寄せられる質問</span><span class="sxs-lookup"><span data-stu-id="9128b-135">FAQs on Win32 WebView</span></span>

<span data-ttu-id="9128b-136">この[よく寄せられる質問](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/webview#frequently-asked-questions-faqs)サンプルとその他のリソースにリンクするほかのデスクトップ アプリケーションで Microsoft Edge の WebView を使用する場合は、よく寄せられる質問に対する回答を提供します。</span><span class="sxs-lookup"><span data-stu-id="9128b-136">Our [frequently asked questions](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/webview#frequently-asked-questions-faqs) provides answers to common questions when using the Microsoft Edge WebView in desktop applications, as well as links to samples and additional resources.</span></span>

### <a name="japanese-era-change"></a><span data-ttu-id="9128b-137">日本語の時代 (年号) の変更</span><span class="sxs-lookup"><span data-stu-id="9128b-137">Japanese era change</span></span>

<span data-ttu-id="9128b-138">[日本語の時代 (年号) 変更するアプリケーションを準備](../design/globalizing/japanese-era-change.md)アプリケーションは、日本語の時代 (年号) をセットの変更の準備ができて、Windows は、2019 年 5 月 1 日に配置することを確認する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="9128b-138">[Prepare your application for the Japanese era change](../design/globalizing/japanese-era-change.md) shows you how to ensure your Windows application is ready for the Japanese era change set to take place on May 1, 2019.</span></span> <span data-ttu-id="9128b-139">[このページは日本語で利用可能なも](https://docs.microsoft.com/ja-jp/windows/uwp/design/globalizing/japanese-era-change)します。</span><span class="sxs-lookup"><span data-stu-id="9128b-139">[This page is also available in Japanese](https://docs.microsoft.com/ja-jp/windows/uwp/design/globalizing/japanese-era-change).</span></span>

## <a name="videos"></a><span data-ttu-id="9128b-140">ビデオ</span><span class="sxs-lookup"><span data-stu-id="9128b-140">Videos</span></span>

### <a name="progressive-web-apps"></a><span data-ttu-id="9128b-141">プログレッシブ Web アプリ</span><span class="sxs-lookup"><span data-stu-id="9128b-141">Progressive Web Apps</span></span>

<span data-ttu-id="9128b-142">プログレッシブ Web アプリは、さまざまなブラウザーおよび Windows 10 デバイスのさまざまなネイティブ アプリのように機能する web サイトです。</span><span class="sxs-lookup"><span data-stu-id="9128b-142">Progressive Web Apps are web sites that function like native apps across different browsers and a wide variety of Windows 10 devices.</span></span> <span data-ttu-id="9128b-143">[ビデオを見る](https://youtu.be/ugAewC3308Y)詳細については、し[ドキュメントのチェック アウト](https://aka.ms/Windows-PWA)を開始します。</span><span class="sxs-lookup"><span data-stu-id="9128b-143">[Watch the video](https://youtu.be/ugAewC3308Y) to learn more, and then [check out the docs](https://aka.ms/Windows-PWA) to get started.</span></span>

### <a name="vs-code-series"></a><span data-ttu-id="9128b-144">VS コード シリーズ</span><span class="sxs-lookup"><span data-stu-id="9128b-144">VS Code series</span></span>

<span data-ttu-id="9128b-145">チェック アウト、 [Visual Studio Code での新しいビデオ シリーズ](https://www.youtube.com/playlist?list=PLlrxD0HtieHjQX77y-0sWH9IZBTmv1tTx)VSCode は、それを使用する方法との作成方法についてはします。</span><span class="sxs-lookup"><span data-stu-id="9128b-145">Check out our [new video series on Visual Studio Code](https://www.youtube.com/playlist?list=PLlrxD0HtieHjQX77y-0sWH9IZBTmv1tTx) for information about what VSCode is, how to use it, and how it was created.</span></span>

### <a name="one-dev-question"></a><span data-ttu-id="9128b-146">開発用の 1 つの質問</span><span class="sxs-lookup"><span data-stu-id="9128b-146">One Dev Question</span></span>

<span data-ttu-id="9128b-147">開発用の 1 つの質問のビデオ シリーズでは、マイクロソフトのベテランの開発者は、一連の Windows の開発、チームのカルチャ、および履歴に関する質問を説明します。</span><span class="sxs-lookup"><span data-stu-id="9128b-147">In the One Dev Question video series, longtime Microsoft developers cover a series of questions about Windows development, team culture, and history.</span></span> <span data-ttu-id="9128b-148">お答えした最新の質問を次に示します。</span><span class="sxs-lookup"><span data-stu-id="9128b-148">Here's the latest questions that we've answered!</span></span>

<span data-ttu-id="9128b-149">Raymond Chen:</span><span class="sxs-lookup"><span data-stu-id="9128b-149">Raymond Chen:</span></span>

* [<span data-ttu-id="9128b-150">プログラム ファイルとプログラム ファイル (x86) があるなぜでしょうか。</span><span class="sxs-lookup"><span data-stu-id="9128b-150">Why have Program Files and Program Files (x86)?</span></span>](https://youtu.be/N7o9eJpFYco)

<span data-ttu-id="9128b-151">Larry Osterman の場合:</span><span class="sxs-lookup"><span data-stu-id="9128b-151">Larry Osterman:</span></span>

* [<span data-ttu-id="9128b-152">COM を理由には複雑ではなさそうですか?</span><span class="sxs-lookup"><span data-stu-id="9128b-152">Why is COM so complicated?</span></span>](https://youtu.be/-gkXAV-StVA )
* [<span data-ttu-id="9128b-153">Microsoft のように、最初のインタビューとは何でしたか。</span><span class="sxs-lookup"><span data-stu-id="9128b-153">What was your first interview like for Microsoft?</span></span>](https://youtu.be/qRb6otsHG5c)
