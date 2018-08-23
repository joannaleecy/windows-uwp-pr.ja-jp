---
author: QuinnRadich
title: 年 2018年 7 月で Windows ドキュメントの新機能 - UWP アプリの開発
description: Windows 10 年 2018年 7 月開発ドキュメント、新機能、ビデオ、サンプル、および開発者向けのガイダンスが追加されました。
keywords: 新機能、更新、機能、開発者向けのガイダンス、Windows 10 の場合は、年 7 月
ms.author: quradic
ms.date: 7/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: f41d25fd6757e5d3f80d00de341168de4f34e946
ms.sourcegitcommit: 9c79fdab9039ff592edf7984732d300a14e81d92
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/23/2018
ms.locfileid: "2822774"
---
# <a name="whats-new-in-the-windows-developer-docs-in-july-2018"></a><span data-ttu-id="79b7f-104">年 2018年 7 月では、Windows の開発ドキュメントの新機能します。</span><span class="sxs-lookup"><span data-stu-id="79b7f-104">What's New in the Windows Developer Docs in July 2018</span></span>

<span data-ttu-id="79b7f-105">Windows 開発者向けドキュメントは、Windows プラットフォームで開発者に提供される新機能の情報を反映して継続的に更新されています。</span><span class="sxs-lookup"><span data-stu-id="79b7f-105">The Windows Developer Documentation is constantly being updated with information on new features available to developers across the Windows platform.</span></span> <span data-ttu-id="79b7f-106">次の機能の概要、開発者向けのガイダンス、ビデオ、およびサンプル加えられた 6 月のでは使用できます。</span><span class="sxs-lookup"><span data-stu-id="79b7f-106">The following feature overviews, developer guidance, videos, and samples have been made available in the month of July.</span></span>

<span data-ttu-id="79b7f-107">Windows 10 の[ツールと SDK をインストール](http://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/create-uwp-apps.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="79b7f-107">[Install the tools and SDK](http://go.microsoft.com/fwlink/?LinkId=821431) on Windows 10 and you’re ready to either [create a new Universal Windows app](../get-started/create-uwp-apps.md) or explore how you can use your [existing app code on Windows](../porting/index.md).</span></span>

## <a name="features"></a><span data-ttu-id="79b7f-108">機能</span><span class="sxs-lookup"><span data-stu-id="79b7f-108">Features</span></span>

### <a name="progressive-web-apps-on-windows"></a><span data-ttu-id="79b7f-109">Windows でプログレッシブ Web アプリ</span><span class="sxs-lookup"><span data-stu-id="79b7f-109">Progressive Web Apps on Windows</span></span>

<span data-ttu-id="79b7f-110">[プログレッシブ Web Apps (PWAs)](https://developer.microsoft.com/windows/pwa)は[徐々 に拡張](https://wikipedia.org/wiki/Progressive_enhancement)プラットフォームおよびサイド バー-からのホーム画面に設定インストール、オフライン作業のサポート プッシュなどのブラウザー エンジンのサポートのネイティブ アプリのような機能には、web アプリケーションだけです。通知します。</span><span class="sxs-lookup"><span data-stu-id="79b7f-110">[Progressive Web Apps (PWAs)](https://developer.microsoft.com/windows/pwa) are simply web apps that are [progressively enhanced](https://wikipedia.org/wiki/Progressive_enhancement) with native app-like features on supporting platforms and browser engines, such as launch-from-homescreen installation, offline support, and push notifications.</span></span> <span data-ttu-id="79b7f-111">Microsoft Edge (EdgeHTML) エンジンと Windows 10 で PWAs が実行中の利点を享受[UWP アプリとしては、ブラウザー ウィンドウとは独立させて](https://docs.microsoft.com/microsoft-edge/progressive-web-apps/windows-features)。</span><span class="sxs-lookup"><span data-stu-id="79b7f-111">On Windows 10 with the Microsoft Edge (EdgeHTML) engine, PWAs enjoy the added advantage of running [independently of the browser window as UWP apps.](https://docs.microsoft.com/microsoft-edge/progressive-web-apps/windows-features)</span></span>

![アクションの PWAs の画像](images/progressive-web-apps.jpg)

<span data-ttu-id="79b7f-113">PWA ガイドをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="79b7f-113">Check out our PWA guides to:</span></span>

* [<span data-ttu-id="79b7f-114">PWA として単純な web アプリを作成します。</span><span class="sxs-lookup"><span data-stu-id="79b7f-114">Build a simple web app as a PWA</span></span>](https://docs.microsoft.com/microsoft-edge/progressive-web-apps/get-started)
* [<span data-ttu-id="79b7f-115">Windows の実行時に、PWA を強化します。</span><span class="sxs-lookup"><span data-stu-id="79b7f-115">Enhance your PWA with the Windows Runtime</span></span>](https://docs.microsoft.com/en-us/microsoft-edge/progressive-web-apps/windows-features)
* [<span data-ttu-id="79b7f-116">Microsoft ストアに、PWA を発行します。</span><span class="sxs-lookup"><span data-stu-id="79b7f-116">Publish your PWA to the Microsoft Store</span></span>](https://docs.microsoft.com/microsoft-edge/progressive-web-apps/microsoft-store)

### <a name="notepad"></a><span data-ttu-id="79b7f-117">メモ帳</span><span class="sxs-lookup"><span data-stu-id="79b7f-117">Notepad</span></span>

<span data-ttu-id="79b7f-118">Windows 10 内部 Preview ビルド 17713、[多くの新機能の更新されたメモ帳](http://aka.ms/ant-man)で使用できます。</span><span class="sxs-lookup"><span data-stu-id="79b7f-118">Available in Windows 10 Insider Preview Build 17713, [Notepad has been updated with many new features](http://aka.ms/ant-man).</span></span> <span data-ttu-id="79b7f-119">ズーム、検索/置換、折り返してと Unix/Linux (LF) と Mac (変更リクエスト) 行末のサポートは[Windows の関係者](https://insider.windows.com/)に利用できます。</span><span class="sxs-lookup"><span data-stu-id="79b7f-119">Zooming, wrap-around find/replace, and support for Unix/Linux (LF) and Mac (CR) line endings are now available to [Windows Insiders](https://insider.windows.com/).</span></span> 

## <a name="developer-guidance"></a><span data-ttu-id="79b7f-120">開発者向けガイダンス</span><span class="sxs-lookup"><span data-stu-id="79b7f-120">Developer Guidance</span></span>

### <a name="design-landing-page"></a><span data-ttu-id="79b7f-121">デザインのランディング ページ</span><span class="sxs-lookup"><span data-stu-id="79b7f-121">Design landing page</span></span>

<span data-ttu-id="79b7f-122">[デザインのランディング ページを更新](https://developer.microsoft.com/windows/apps/design)UWP デザイン領域に、および Fluent デザインへの最新の追加についての概要についてはの概要をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="79b7f-122">Check out the [updated Design landing page](https://developer.microsoft.com/windows/apps/design) for an at-a-glance overview of UWP design areas, and information on the latest additions to Fluent Design.</span></span>

### <a name="design-toolkits"></a><span data-ttu-id="79b7f-123">設計ツールキット</span><span class="sxs-lookup"><span data-stu-id="79b7f-123">Design toolkits</span></span>

<span data-ttu-id="79b7f-124">新機能では、Adobe XD、Adobe Illustrator ツールキットが更新されました。</span><span class="sxs-lookup"><span data-stu-id="79b7f-124">The Adobe XD and Adobe Illustrator toolkits have been updated with new features.</span></span> <span data-ttu-id="79b7f-125">これらのデザイン ツールキットは、UWP アプリをデザインするためのコントロールとレイアウトのテンプレートを提供します。</span><span class="sxs-lookup"><span data-stu-id="79b7f-125">These design toolkits provide controls and layout templates for designing UWP apps.</span></span> [<span data-ttu-id="79b7f-126">ここでは、それらを確認します。</span><span class="sxs-lookup"><span data-stu-id="79b7f-126">Check them out here.</span></span>](../design/downloads/index.md)

### <a name="webvr"></a><span data-ttu-id="79b7f-127">WebVR</span><span class="sxs-lookup"><span data-stu-id="79b7f-127">WebVR</span></span>

<span data-ttu-id="79b7f-128">[WebVR ドキュメント](https://docs.microsoft.com/microsoft-edge/webvr/
)をいくつかの新しいトピックが追加されました。</span><span class="sxs-lookup"><span data-stu-id="79b7f-128">We've added several new topics to the [WebVR documentation](https://docs.microsoft.com/microsoft-edge/webvr/
):</span></span>

* [<span data-ttu-id="79b7f-129">WebVR とは何ですか。</span><span class="sxs-lookup"><span data-stu-id="79b7f-129">What is WebVR?</span></span>](https://docs.microsoft.com/microsoft-edge/webvr/what-is-webvr
) <span data-ttu-id="79b7f-130">WebVR の機能、使用する理由、およびの開発を始める方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="79b7f-130">Explains what WebVR is, why you should use it, and how to get started developing for it.</span></span>

* <span data-ttu-id="79b7f-131">[プログレッシブ Web Apps で WebVR](https://docs.microsoft.com/microsoft-edge/webvr/webvr-in-pwas): WebVR にプログレッシブ Web App (PWA) を追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="79b7f-131">[WebVR in Progressive Web Apps](https://docs.microsoft.com/microsoft-edge/webvr/webvr-in-pwas): Learn how to add WebVR to a Progressive Web App (PWA).</span></span>

* <span data-ttu-id="79b7f-132">[Web ビューで WebVR](https://docs.microsoft.com/microsoft-edge/webvr/webvr-in-webview): Windows 10 のアプリケーションでビューのコントロールに WebVR を追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="79b7f-132">[WebVR in WebView](https://docs.microsoft.com/microsoft-edge/webvr/webvr-in-webview): Learn how to add WebVR to a WebView control in a Windows 10 application.</span></span>

* <span data-ttu-id="79b7f-133">[WebVR デモ](https://docs.microsoft.com/microsoft-edge/webvr/demos): Microsoft Edge と Windows の混在実際の効果的なヘッドセットを使用して、いくつかの WebVR デモをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="79b7f-133">[WebVR demos](https://docs.microsoft.com/microsoft-edge/webvr/demos): Check out some WebVR demos using Microsoft Edge and a Windows Mixed Reality immersive headset.</span></span>

<span data-ttu-id="79b7f-134">さらに、既存のページに一部の更新を行っています。</span><span class="sxs-lookup"><span data-stu-id="79b7f-134">In addition, we've made some updates to existing pages:</span></span>

* <span data-ttu-id="79b7f-135">目次がより 4 つの異なる最上位のグループに分類されたようになりました。**基礎**、**開発**、**リソース**、および**デモ**します。</span><span class="sxs-lookup"><span data-stu-id="79b7f-135">The table of contents is now better organized into four distinct top-level buckets: **Fundamentals**, **Development**, **Resources**, and **Demos**.</span></span>

* <span data-ttu-id="79b7f-136">[(ランディング ページ) WebVR 開発者向けガイド](https://docs.microsoft.com/microsoft-edge/webvr/): 更新された外観をより大きな画像アイコンと新しいデモします。</span><span class="sxs-lookup"><span data-stu-id="79b7f-136">[WebVR Developer's Guide (landing page)](https://docs.microsoft.com/microsoft-edge/webvr/): Refreshed look and feel, with larger images and icons and new demo.</span></span>

* <span data-ttu-id="79b7f-137">[Microsoft Edge と WebVR を使用する](https://docs.microsoft.com/microsoft-edge/webvr/webvr-with-edge): Windows に関する情報を追加するのには更新 10 年 2018年 4 月を更新します。</span><span class="sxs-lookup"><span data-stu-id="79b7f-137">[Using WebVR with Microsoft Edge](https://docs.microsoft.com/microsoft-edge/webvr/webvr-with-edge): Updated to include information about the Windows 10 April 2018 Update.</span></span>

## <a name="videos"></a><span data-ttu-id="79b7f-138">ビデオ</span><span class="sxs-lookup"><span data-stu-id="79b7f-138">Videos</span></span>

### <a name="get-started-for-devs-create-and-customize-a-form-on-windows-10"></a><span data-ttu-id="79b7f-139">デバイスを開始する: を作成して、Windows 10 でフォームをカスタマイズします。</span><span class="sxs-lookup"><span data-stu-id="79b7f-139">Get Started for Devs: Create and customize a form on Windows 10</span></span>

<span data-ttu-id="79b7f-140">Windows 開発者向けの[ドキュメントの作業を開始する](../get-started/index.md)基本的なアプリ開発のタスクを実際に体験を提供します。</span><span class="sxs-lookup"><span data-stu-id="79b7f-140">Our [Get Started docs](../get-started/index.md) for Windows developers now provide hands-on experience with basic app development task.</span></span> <span data-ttu-id="79b7f-141">このビデオでは、これらのトピックを紹介して、フォームを作成する UI のアプリでの基本について説明します。</span><span class="sxs-lookup"><span data-stu-id="79b7f-141">This video walks you through one of those topics, and covers the basics of creating a form UI in your app.</span></span> <span data-ttu-id="79b7f-142">[操作] で、コードを表示する[ビデオを見る](https://www.youtube.com/watch?v=AgngKzq4hKI&feature=youtu.be)[のトピックを確認します](http://aka.ms/CreateForms)。</span><span class="sxs-lookup"><span data-stu-id="79b7f-142">[Watch the video](https://www.youtube.com/watch?v=AgngKzq4hKI&feature=youtu.be) to see the code in action, then [check out the topic yourself.](http://aka.ms/CreateForms)</span></span>

### <a name="enhance-your-bot-with-project-personality-chat"></a><span data-ttu-id="79b7f-143">プロジェクトの個性チャットと、結果を強化します。</span><span class="sxs-lookup"><span data-stu-id="79b7f-143">Enhance your Bot with Project Personality chat</span></span>

<span data-ttu-id="79b7f-144">プロジェクトの個性チャットでは、あなたのチャット ロボットにカスタマイズ可能なユーザーを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="79b7f-144">Project Personality Chat lets you add a customizable persona to your chat bots.</span></span> <span data-ttu-id="79b7f-145">Microsoft 結果 Framework SDK との統合、顧客とやり取りする会話の他の方法については、小さな説明を追加できます。</span><span class="sxs-lookup"><span data-stu-id="79b7f-145">By integrating with the Microsoft Bot Framework SDK, you can add small-talk capabilities for a more conversational way to interact with the customers.</span></span> <span data-ttu-id="79b7f-146">[ビデオを見る](https://www.youtube.com/watch?v=5C_uD8g2QKg&feature=youtu.be)をから、[インタラクティブなデモを試す](http://aka.ms/PersonalityChat)を実践的な操作性を実装する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="79b7f-146">[Watch the video](https://www.youtube.com/watch?v=5C_uD8g2QKg&feature=youtu.be) to learn how to implement it, then [try out the interactive demo](http://aka.ms/PersonalityChat) for a hands-on experience.</span></span>

### <a name="one-dev-question"></a><span data-ttu-id="79b7f-147">1 つの開発質問</span><span class="sxs-lookup"><span data-stu-id="79b7f-147">One Dev Question</span></span>

<span data-ttu-id="79b7f-148">1 つの開発質問ビデオ シリーズでは、長い Microsoft 開発者は、一連の Windows の開発、チームのカルチャと履歴に関する質問を説明します。</span><span class="sxs-lookup"><span data-stu-id="79b7f-148">In the One Dev Question video series, longtime Microsoft developers cover a series of questions about Windows development, team culture, and history.</span></span> <span data-ttu-id="79b7f-149">回答を最新の質問は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="79b7f-149">Here's the latest questions that we've answered!</span></span>

<span data-ttu-id="79b7f-150">Raymond 氏チェンの場合:</span><span class="sxs-lookup"><span data-stu-id="79b7f-150">Raymond Chen:</span></span>

* [<span data-ttu-id="79b7f-151">Microsoft に理由を適用するでしたか。</span><span class="sxs-lookup"><span data-stu-id="79b7f-151">Why did you apply to Microsoft?</span></span>](https://www.youtube.com/watch?v=oL8ymamkEMU&feature=youtu.be)

<span data-ttu-id="79b7f-152">ラリー Osterman:</span><span class="sxs-lookup"><span data-stu-id="79b7f-152">Larry Osterman:</span></span>

* [<span data-ttu-id="79b7f-153">開発者が既定のオーディオ デバイスを変更しない理由使用するのですか。</span><span class="sxs-lookup"><span data-stu-id="79b7f-153">Why don't we let developers change the default audio device?</span></span>](https://www.youtube.com/watch?v=6aNUoVfbnmg&feature=youtu.be)
* [<span data-ttu-id="79b7f-154">多くの UWP 関数の非同期はなぜですか。</span><span class="sxs-lookup"><span data-stu-id="79b7f-154">Why are so many UWP functions async?</span></span>](https://www.youtube.com/watch?v=5M724QIy1Mk&feature=youtu.be)

## <a name="samples"></a><span data-ttu-id="79b7f-155">サンプル</span><span class="sxs-lookup"><span data-stu-id="79b7f-155">Samples</span></span>

### <a name="photo-editor-cwinrt"></a><span data-ttu-id="79b7f-156">写真の編集者 C + +/WinRT</span><span class="sxs-lookup"><span data-stu-id="79b7f-156">Photo Editor C++/WinRT</span></span>

<span data-ttu-id="79b7f-157">フォト エディター サンプル アプリの開発の紹介、 [C + +/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md)言語投影します。</span><span class="sxs-lookup"><span data-stu-id="79b7f-157">The Photo Editor sample app showcases development with the [C++/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md) language projection.</span></span> <span data-ttu-id="79b7f-158">アプリを使用すると、**画像**ライブラリから写真を取得し、[選択の画像に関連付けられている画像の効果を編集できます。</span><span class="sxs-lookup"><span data-stu-id="79b7f-158">The app allows you to retrieve photos from the **Pictures** library, and then edit a elected image with associated photo effects.</span></span> [<span data-ttu-id="79b7f-159">複製するか、次の例をダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="79b7f-159">Clone or download the sample here.</span></span>](https://github.com/Microsoft/Windows-appsample-photo-editor)

![アクションのサンプルの例](images/photo-editor-banner.png)
