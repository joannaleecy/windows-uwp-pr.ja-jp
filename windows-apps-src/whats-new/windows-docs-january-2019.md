---
title: Windows ドキュメントの年 1 月 2019 - UWP アプリの開発
description: 新機能、ビデオ、および開発者向けガイダンスが 2019年 1 月の Windows 10 開発者向けドキュメントに追加されました
keywords: 新機能, 更新, 機能, 開発者向けガイダンス, Windows 10 年 1 月
ms.date: 01/17/2019
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: beb80c28866b8f8207f203b70cb504dcd034098d
ms.sourcegitcommit: 079801609165bc7eb69670d771a05bffe236d483
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/27/2019
ms.locfileid: "9116254"
---
# <a name="whats-new-in-the-windows-developer-docs-in-january-2019"></a><span data-ttu-id="91bf2-104">新機能、Windows 開発者向けドキュメントの年 2019年 1 月</span><span class="sxs-lookup"><span data-stu-id="91bf2-104">What's New in the Windows Developer Docs in January 2019</span></span>

<span data-ttu-id="91bf2-105">Windows 開発者向けドキュメントは、Windows プラットフォームで開発者に提供される新機能の情報を反映して継続的に更新されています。</span><span class="sxs-lookup"><span data-stu-id="91bf2-105">The Windows Developer Documentation is constantly being updated with information on new features available to developers across the Windows platform.</span></span> <span data-ttu-id="91bf2-106">次の機能概要、開発者向けガイダンス、およびビデオには 1 月で利用可能ななりました。</span><span class="sxs-lookup"><span data-stu-id="91bf2-106">The following feature overviews, developer guidance, and videos have been made available in the month of January.</span></span>

<span data-ttu-id="91bf2-107">Windows 10 の[ツールと SDK をインストール](https://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/create-uwp-apps.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="91bf2-107">[Install the tools and SDK](https://go.microsoft.com/fwlink/?LinkId=821431) on Windows 10 and you’re ready to either [create a new Universal Windows app](../get-started/create-uwp-apps.md) or explore how you can use your [existing app code on Windows](../porting/index.md).</span></span>

## <a name="features"></a><span data-ttu-id="91bf2-108">機能</span><span class="sxs-lookup"><span data-stu-id="91bf2-108">Features</span></span>

### <a name="windows-development-on-microsoft-learn"></a><span data-ttu-id="91bf2-109">Microsoft の学習で Windows の開発</span><span class="sxs-lookup"><span data-stu-id="91bf2-109">Windows development on Microsoft Learn</span></span>

<span data-ttu-id="91bf2-110">Microsoft については、Microsoft の開発者に新しい実践的な学習とトレーニングを提供します。</span><span class="sxs-lookup"><span data-stu-id="91bf2-110">Microsoft Learn provides new hands-on learning and training opportunities to Microsoft developers.</span></span> <span data-ttu-id="91bf2-111">Windows アプリを開発する方法を学習する場合[、新しい学習パス](https://docs.microsoft.com/learn/paths/develop-windows10-apps/)徹底的な紹介については、プラットフォーム、ツール、および、最初のいくつかのアプリを記述する方法をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="91bf2-111">If you're interested in learning how to develop Windows apps, check out [our new learning path](https://docs.microsoft.com/learn/paths/develop-windows10-apps/) for a thorough introduction to the platform, the tools, and how to write your first few apps.</span></span>

![パスの学習 Windows 開発用の画像](images/windows-learn.png)

### <a name="direct-3d-12"></a><span data-ttu-id="91bf2-113">Direct 3D 12</span><span class="sxs-lookup"><span data-stu-id="91bf2-113">Direct 3D 12</span></span>

<span data-ttu-id="91bf2-114">[Direct3d12 のレンダリング パスが](/windows/desktop/direct3d12/direct3d-12-render-passes)するはその他の手法の間でタイル ベースの遅延レンダリング (TBDR) に基づいている場合に、レンダラーのパフォーマンスが向上することができます。</span><span class="sxs-lookup"><span data-stu-id="91bf2-114">[Direct3D 12 render passes](/windows/desktop/direct3d12/direct3d-12-render-passes) can improve the performance of your renderer if it's based on Tile-Based Deferred Rendering (TBDR), among other techniques.</span></span> <span data-ttu-id="91bf2-115">手法は、レンダラーをリソース レンダリング順序指定の要件とデータの依存関係を識別しやすく、アプリケーションを有効にして、短く、メモリへのトラフィックをオフ チップ メモリから GPU の効率を向上させるために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="91bf2-115">The technique helps your renderer to improve GPU efficiency by enabling your application to better identify resource rendering ordering requirements and data dependencies, and thus reducing memory traffic to/from off-chip memory.</span></span>

### <a name="msix-modification-packages"></a><span data-ttu-id="91bf2-116">MSIX 変更パッケージ</span><span class="sxs-lookup"><span data-stu-id="91bf2-116">MSIX modification packages</span></span>

<span data-ttu-id="91bf2-117">[MSIX 変更用のパッケージ](https://docs.microsoft.com/windows/msix/modification-package-1809-update)の Windows 10 version 1809 の向上のサポート。</span><span class="sxs-lookup"><span data-stu-id="91bf2-117">Windows 10 version 1809 improved support for [MSIX modification packages](https://docs.microsoft.com/windows/msix/modification-package-1809-update).</span></span> <span data-ttu-id="91bf2-118">変更パッケージでは、レジストリ ベースのプラグインと関連付けられたカスタマイズは、含めることができ、仮想レジストリを使用して、期待どおりに動作 MSIX を通じて展開されたアプリケーションを有効になります。</span><span class="sxs-lookup"><span data-stu-id="91bf2-118">Modification packages can include registry-based plugins and associated customization, and will enable an application deployed through MSIX to use a virtual registry and run as expected.</span></span>

![MSIX 変更パッケージの作成](images/msix-modification-package.png)

### <a name="open-source-of-wpf-windows-forms-and-winui"></a><span data-ttu-id="91bf2-120">WPF、Windows フォーム、および WinUI のオープン ソース</span><span class="sxs-lookup"><span data-stu-id="91bf2-120">Open Source of WPF, Windows Forms, and WinUI</span></span>

<span data-ttu-id="91bf2-121">Github のオープン ソースの貢献度の WPF、Windows フォーム、および WinUI UX のフレームワークが利用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="91bf2-121">The WPF, Windows Forms, and WinUI UX frameworks are now available for open-source contributions on GitHub.</span></span> <span data-ttu-id="91bf2-122">詳細とリンクは、[ビルドの Windows アプリのブログ](https://blogs.windows.com/buildingapps/2018/12/04/announcing-open-source-of-wpf-windows-forms-and-winui-at-microsoft-connect-2018/#OKZjJs1VVTrMMtkL.97)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="91bf2-122">For more information and links, see the [building Windows apps blog](https://blogs.windows.com/buildingapps/2018/12/04/announcing-open-source-of-wpf-windows-forms-and-winui-at-microsoft-connect-2018/#OKZjJs1VVTrMMtkL.97).</span></span>

### <a name="progressive-web-apps-for-xbox"></a><span data-ttu-id="91bf2-123">Xbox 用のプログレッシブ Web アプリ</span><span class="sxs-lookup"><span data-stu-id="91bf2-123">Progressive Web Apps for Xbox</span></span>

<span data-ttu-id="91bf2-124">[Xbox One のプログレッシブ Web アプリ](https://docs.microsoft.com/microsoft-edge/progressive-web-apps/xbox-considerations)、web アプリケーションの拡張でき、利用できるように、Xbox One アプリとして Microsoft Store 経由でながら、引き続き、既存のフレームワーク、CDN とサーバーのバックエンドを使用できます。</span><span class="sxs-lookup"><span data-stu-id="91bf2-124">With [Progressive Web Apps for Xbox One](https://docs.microsoft.com/microsoft-edge/progressive-web-apps/xbox-considerations), you can extend a web application and make it available as an Xbox One app via Microsoft Store while still continuing to use your existing frameworks, CDN and server backend.</span></span> <span data-ttu-id="91bf2-125">ほとんどの場合、パッケージ化して、PWA Xbox One の Windows の場合と同じ方法で、ただし、このガイドの説明をいくつかの主な違いがあります。</span><span class="sxs-lookup"><span data-stu-id="91bf2-125">For the most part, you can package your PWA for Xbox One in the same way you would for Windows, however, there are several key differences this guide will walk you through.</span></span>

### <a name="windows-machine-learning"></a><span data-ttu-id="91bf2-126">Windows Machine learning</span><span class="sxs-lookup"><span data-stu-id="91bf2-126">Windows Machine learning</span></span>

<span data-ttu-id="91bf2-127">[WinML Api のランディング ページ](https://docs.microsoft.com/windows/ai/api-reference)で、再構築して、ネイティブ Api とカスタムの演算子を WinML 用の新しいドキュメントを追加しますがあります。</span><span class="sxs-lookup"><span data-stu-id="91bf2-127">We've restructured [the landing page for WinML APIs](https://docs.microsoft.com/windows/ai/api-reference), and added new documentation for WinML custom operator and native APIs.</span></span>

<span data-ttu-id="91bf2-128">[PyTorch、モデルのトレーニング](https://docs.microsoft.com/windows/ai/train-model-pytorch)PyTorch フレームワークを使用して、ローカルとクラウドのモデルをトレーニングする方法のガイダンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="91bf2-128">[Train a model with PyTorch](https://docs.microsoft.com/windows/ai/train-model-pytorch) provides guidance on how to train a model using the PyTorch framework either locally or in the cloud.</span></span> <span data-ttu-id="91bf2-129">このモデルを ONNX ファイルとしてダウンロードし、WinML アプリケーションで使用します。</span><span class="sxs-lookup"><span data-stu-id="91bf2-129">You can then download this model as an ONNX file and use it in your WinML applications.</span></span>

![WinML グラフィック](images/winml-graphic.png)

## <a name="developer-guidance"></a><span data-ttu-id="91bf2-131">開発者向けガイダンス</span><span class="sxs-lookup"><span data-stu-id="91bf2-131">Developer Guidance</span></span>

### <a name="choose-your-platform"></a><span data-ttu-id="91bf2-132">プラットフォームを選択します。</span><span class="sxs-lookup"><span data-stu-id="91bf2-132">Choose your platform</span></span>

<span data-ttu-id="91bf2-133">新しいデスクトップ アプリケーションの作成に関心があるかどうか。</span><span class="sxs-lookup"><span data-stu-id="91bf2-133">Interested in creating a new desktop application?</span></span> <span data-ttu-id="91bf2-134">詳しい説明については、UWP、Windows フォーム、WPF、プラットフォーム、および詳細については、Win32 API の比較の改良、[プラットフォームの選択](https://docs.microsoft.com/windows/desktop/choose-your-technology)] ページを確認します。</span><span class="sxs-lookup"><span data-stu-id="91bf2-134">Check out our revamped [Choose your platform](https://docs.microsoft.com/windows/desktop/choose-your-technology) page for detailed descriptions and comparisons of the UWP, WPF, and Windows Forms platforms, and further information on the Win32 API.</span></span>

### <a name="faqs-on-win32-webview"></a><span data-ttu-id="91bf2-135">Win32 WebView の Faq</span><span class="sxs-lookup"><span data-stu-id="91bf2-135">FAQs on Win32 WebView</span></span>

<span data-ttu-id="91bf2-136">サンプルとその他のリソースへのリンクと同様に、デスクトップ アプリケーションで Microsoft Edge WebView を使用すると、当社の[よく寄せられる質問](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/webview#frequently-asked-questions-faqs)、よく寄せられる質問に対する回答が提供されます。</span><span class="sxs-lookup"><span data-stu-id="91bf2-136">Our [frequently asked questions](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/webview#frequently-asked-questions-faqs) provides answers to common questions when using the Microsoft Edge WebView in desktop applications, as well as links to samples and additional resources.</span></span>

### <a name="japanese-era-change"></a><span data-ttu-id="91bf2-137">日本語の era 変更</span><span class="sxs-lookup"><span data-stu-id="91bf2-137">Japanese era change</span></span>

<span data-ttu-id="91bf2-138">[日本語の era のためにアプリケーションの環境の準備を変更する](../design/globalizing/japanese-era-change.md)と、アプリケーションは、日本語の時代を設定を変更する準備が、Windows が 2019 年 5 月 1 日に配置することを確認する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="91bf2-138">[Prepare your application for the Japanese era change](../design/globalizing/japanese-era-change.md) shows you how to ensure your Windows application is ready for the Japanese era change set to take place on May 1, 2019.</span></span> <span data-ttu-id="91bf2-139">[このページは日本語でも利用できます](https://docs.microsoft.com/ja-jp/windows/uwp/design/globalizing/japanese-era-change)。</span><span class="sxs-lookup"><span data-stu-id="91bf2-139">[This page is also available in Japanese](https://docs.microsoft.com/ja-jp/windows/uwp/design/globalizing/japanese-era-change).</span></span>

## <a name="videos"></a><span data-ttu-id="91bf2-140">ビデオ</span><span class="sxs-lookup"><span data-stu-id="91bf2-140">Videos</span></span>

### <a name="progressive-web-apps"></a><span data-ttu-id="91bf2-141">プログレッシブ Web アプリ</span><span class="sxs-lookup"><span data-stu-id="91bf2-141">Progressive Web Apps</span></span>

<span data-ttu-id="91bf2-142">プログレッシブ Web アプリは、さまざまなブラウザーやさまざまな Windows 10 デバイス間でネイティブのアプリと同様に機能する web サイトです。</span><span class="sxs-lookup"><span data-stu-id="91bf2-142">Progressive Web Apps are web sites that function like native apps across different browsers and a wide variety of Windows 10 devices.</span></span> <span data-ttu-id="91bf2-143">について[は、ビデオ](https://youtu.be/ugAewC3308Y)をし、[チェック アウト、ドキュメント](https://aka.ms/Windows-PWA)を開始します。</span><span class="sxs-lookup"><span data-stu-id="91bf2-143">[Watch the video](https://youtu.be/ugAewC3308Y) to learn more, and then [check out the docs](https://aka.ms/Windows-PWA) to get started.</span></span>

### <a name="vs-code-series"></a><span data-ttu-id="91bf2-144">VS コード シリーズ</span><span class="sxs-lookup"><span data-stu-id="91bf2-144">VS Code series</span></span>

<span data-ttu-id="91bf2-145">VSCode は、それを使用する方法およびがその作成方法については、 [Visual Studio Code で新しいビデオ シリーズ](https://www.youtube.com/playlist?list=PLlrxD0HtieHjQX77y-0sWH9IZBTmv1tTx)を確認します。</span><span class="sxs-lookup"><span data-stu-id="91bf2-145">Check out our [new video series on Visual Studio Code](https://www.youtube.com/playlist?list=PLlrxD0HtieHjQX77y-0sWH9IZBTmv1tTx) for information about what VSCode is, how to use it, and how it was created.</span></span>

### <a name="one-dev-question"></a><span data-ttu-id="91bf2-146">1 つのデベロッパー質問</span><span class="sxs-lookup"><span data-stu-id="91bf2-146">One Dev Question</span></span>

<span data-ttu-id="91bf2-147">デベロッパー質問の 1 つのビデオ シリーズの長い Microsoft 開発者は一連の Windows の開発、チームのカルチャと履歴に関する質問について説明します。</span><span class="sxs-lookup"><span data-stu-id="91bf2-147">In the One Dev Question video series, longtime Microsoft developers cover a series of questions about Windows development, team culture, and history.</span></span> <span data-ttu-id="91bf2-148">お答えした最新の質問を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="91bf2-148">Here's the latest questions that we've answered!</span></span>

<span data-ttu-id="91bf2-149">Raymond Chen:</span><span class="sxs-lookup"><span data-stu-id="91bf2-149">Raymond Chen:</span></span>

* [<span data-ttu-id="91bf2-150">Program Files と Program Files (x86) と理由があるかどうか。</span><span class="sxs-lookup"><span data-stu-id="91bf2-150">Why have Program Files and Program Files (x86)?</span></span>](https://youtu.be/N7o9eJpFYco)

<span data-ttu-id="91bf2-151">Larry Osterman:</span><span class="sxs-lookup"><span data-stu-id="91bf2-151">Larry Osterman:</span></span>

* [<span data-ttu-id="91bf2-152">COM はなぜですので複雑なかどうか。</span><span class="sxs-lookup"><span data-stu-id="91bf2-152">Why is COM so complicated?</span></span>](https://youtu.be/-gkXAV-StVA )
* [<span data-ttu-id="91bf2-153">Microsoft のように、最初のインタビューされたかどうか。</span><span class="sxs-lookup"><span data-stu-id="91bf2-153">What was your first interview like for Microsoft?</span></span>](https://youtu.be/qRb6otsHG5c)
