---
author: QuinnRadich
title: 年 2018年 8 月で Windows ドキュメントの新機能 - UWP アプリの開発
description: Windows 10 年 2018年 8 月開発ドキュメント、新機能、ビデオ、サンプル、および開発者向けのガイダンスが追加されました。
keywords: 新機能、更新、機能、開発については、Windows 10、年 8 月
ms.author: quradic
ms.date: 8/9/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 06eef0c115675ba9673a81459c91e0f08f6fab71
ms.sourcegitcommit: be5b71a8ec7b686d5f93d56d10cb9a50c3c5bb4a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/14/2018
ms.locfileid: "2748872"
---
# <a name="whats-new-in-the-windows-developer-docs-in-august-2018"></a><span data-ttu-id="45cda-104">年 2018年 8 月では、Windows の開発ドキュメントの新機能します。</span><span class="sxs-lookup"><span data-stu-id="45cda-104">What's New in the Windows Developer Docs in August 2018</span></span>

<span data-ttu-id="45cda-105">Windows 開発者向けドキュメントは、Windows プラットフォームで開発者に提供される新機能の情報を反映して継続的に更新されています。</span><span class="sxs-lookup"><span data-stu-id="45cda-105">The Windows Developer Documentation is constantly being updated with information on new features available to developers across the Windows platform.</span></span> <span data-ttu-id="45cda-106">次の機能の概要、開発者向けのガイダンスやビデオが行われました 8 月で利用できます。</span><span class="sxs-lookup"><span data-stu-id="45cda-106">The following feature overviews, developer guidance, and videos have been made available in the month of August.</span></span>

<span data-ttu-id="45cda-107">Windows 10 の[ツールと SDK をインストール](http://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/create-uwp-apps.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="45cda-107">[Install the tools and SDK](http://go.microsoft.com/fwlink/?LinkId=821431) on Windows 10 and you’re ready to either [create a new Universal Windows app](../get-started/create-uwp-apps.md) or explore how you can use your [existing app code on Windows](../porting/index.md).</span></span>

## <a name="features"></a><span data-ttu-id="45cda-108">機能</span><span class="sxs-lookup"><span data-stu-id="45cda-108">Features</span></span>

### <a name="design"></a><span data-ttu-id="45cda-109">設計</span><span class="sxs-lookup"><span data-stu-id="45cda-109">Design</span></span>

<span data-ttu-id="45cda-110">次の機能に追加された、Windows の内部のプレビュー ビルド、 [Windows の内部](https://insider.windows.com/)プログラムを使用します。</span><span class="sxs-lookup"><span data-stu-id="45cda-110">The following features have been added to the Windows Insider Preview builds, available through the [Windows Insider](https://insider.windows.com/) program.</span></span>

* <span data-ttu-id="45cda-111">[Windows の UI ライブラリ](https://aka.ms/winui-docs)は、UWP アプリのコントロールとその他のユーザーの interfact 要素を提供する NuGet パッケージのセットです。</span><span class="sxs-lookup"><span data-stu-id="45cda-111">The [Windows UI Library](https://aka.ms/winui-docs) is a set of NuGet packages that provide controls and other user interfact elements for UWP apps.</span></span> <span data-ttu-id="45cda-112">これらのパッケージも、以前のバージョンの Windows 10 の場合は、互換アプリには、ユーザーは、最新の OS のバージョンを持っていない場合でもようにします。</span><span class="sxs-lookup"><span data-stu-id="45cda-112">These packages are also compatable with earlier versions of Windows 10, so your app works even if your users don't have the latest OS version.</span></span>

* <span data-ttu-id="45cda-113">[DropDownButton、分割ボタンと ToggleSplitButton](../design/controls-and-patterns/buttons.md)ボタン コントロールのアプリのユーザー エクスペリエンスを強化するために特殊な機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="45cda-113">[DropDownButton, SplitButton, and ToggleSplitButton](../design/controls-and-patterns/buttons.md) provide button controls with specialized features to enhance your app's user experience.</span></span>

* <span data-ttu-id="45cda-114">今すぐ、NavigationView は、アプリをナビゲーション オプションの数を減らして場合の[上部のナビゲーション](../design/controls-and-patterns/navigationview.md)をサポートしていて、アプリのコンテンツのスペースを要求します。</span><span class="sxs-lookup"><span data-stu-id="45cda-114">NavigationView now supports [Top navigation,](../design/controls-and-patterns/navigationview.md) for cases in which your app has a smaller number of navigation options and require more space for your app's content.</span></span>

* <span data-ttu-id="45cda-115">ツリー ビューがサポートする強化[データ バインド、項目テンプレート、およびドラゴンおよびドロップ](../design/controls-and-patterns/tree-view.md)。</span><span class="sxs-lookup"><span data-stu-id="45cda-115">TreeView has been enhanced to support [data binding, item templates, and dragon and drop.](../design/controls-and-patterns/tree-view.md)</span></span>

![背景色を選ぶための分割] ボタン](../design/controls-and-patterns/images/split-button-rtb.png)

### <a name="package-support-framework"></a><span data-ttu-id="45cda-117">パッケージのサポート フレームワーク</span><span class="sxs-lookup"><span data-stu-id="45cda-117">Package Support Framework</span></span>

<span data-ttu-id="45cda-118">パッケージのサポート フレームワークが、修正を適用、win32 アプリケーションいないときに、ソース コードへのアクセスを MSIX コンテナーで実行できるようにするために役立つ、ファイルを開くキットします。</span><span class="sxs-lookup"><span data-stu-id="45cda-118">The package support framework is an open source kit that helps you apply fixes to your win32 application when you don’t have access to the source code, so that it can run in an MSIX container.</span></span>  

<span data-ttu-id="45cda-119">詳細については、[適用ランタイム修正パッケージ サポート フレームワークを使用して MSIX パッケージを](../porting/package-support-framework.md)参照してください。</span><span class="sxs-lookup"><span data-stu-id="45cda-119">To learn more, see [Apply runtime fixes to an MSIX package by using the Package Support Framework](../porting/package-support-framework.md).</span></span>

## <a name="developer-guidance"></a><span data-ttu-id="45cda-120">開発者向けガイダンス</span><span class="sxs-lookup"><span data-stu-id="45cda-120">Developer Guidance</span></span>

### <a name="web-api-extensions"></a><span data-ttu-id="45cda-121">Web API 拡張</span><span class="sxs-lookup"><span data-stu-id="45cda-121">Web API extensions</span></span>

<span data-ttu-id="45cda-122">ブラウザーの間の web 開発 Mozilla 開発ネットワークのマニュアルを[従来の Microsoft API 拡張子](https://developer.mozilla.org/docs/Web/API/Microsoft_API_extensions)の一覧が追加されました。</span><span class="sxs-lookup"><span data-stu-id="45cda-122">A list of [legacy Microsoft API extensions](https://developer.mozilla.org/docs/Web/API/Microsoft_API_extensions) has been added to the Mozilla Developer Network documentation for cross-browser web development.</span></span> <span data-ttu-id="45cda-123">これらの API 拡張機能は、Internet Explorer または Microsoft Edge に固有 MDN の web ドキュメントの互換性とブラウザーのサポートについての既存の情報を追加します。従来の Microsoft [CSS 拡張子](https://developer.mozilla.org/docs/Web/CSS/Microsoft_Extensions)と[JavaScript 拡張](https://developer.mozilla.org/docs/Web/JavaScript/Microsoft_JavaScript_extensions)機能が、およびリッチ web MDN から API 情報の提示で見つかることが[Visual Studio コード](https://code.visualstudio.com/updates/v1_25#_new-css-pseudo-selectors-and-pseudo-elements-from-mdn)。</span><span class="sxs-lookup"><span data-stu-id="45cda-123">These API extensions are unique to Internet Explorer or Microsoft Edge, and supplement existing information about compatibility and broswer support in the MDN web docs. Legacy Microsoft [CSS extensions](https://developer.mozilla.org/docs/Web/CSS/Microsoft_Extensions) and [JavaScript extensions](https://developer.mozilla.org/docs/Web/JavaScript/Microsoft_JavaScript_extensions) are also available, and you can find rich web API information from MDN surfaced directly in [Visual Studio Code.](https://code.visualstudio.com/updates/v1_25#_new-css-pseudo-selectors-and-pseudo-elements-from-mdn)</span></span>

### <a name="cwinrt-code-examples"></a><span data-ttu-id="45cda-124">C + +/WinRT コードの例</span><span class="sxs-lookup"><span data-stu-id="45cda-124">C++/WinRT Code examples</span></span>

<span data-ttu-id="45cda-125">250 が追加されました[C + +/WinRT](../cpp-and-winrt-apis/index.md)コード スニペットのトピックで、ドキュメント、記録されている既存の C + +/CX コードの例です。</span><span class="sxs-lookup"><span data-stu-id="45cda-125">We've added 250 [C++/WinRT](../cpp-and-winrt-apis/index.md) code snippets to topics in our docs, accompanying existing C++/CX code examples.</span></span>

### <a name="project-rome"></a><span data-ttu-id="45cda-126">Project Rome</span><span class="sxs-lookup"><span data-stu-id="45cda-126">Project Rome</span></span>

<span data-ttu-id="45cda-127">[プロジェクト ローマ ドキュメント](https://docs.microsoft.com/windows/project-rome/)サイトは、機能のアプローチを再編成されました。</span><span class="sxs-lookup"><span data-stu-id="45cda-127">The [Project Rome docs](https://docs.microsoft.com/windows/project-rome/) site has been reorganized into a feature-first approach.</span></span> <span data-ttu-id="45cda-128">これは、ため、開発者が探している情報を検索して、複数のプラットフォームの任意の機能を実装するために簡単に、必要があります。</span><span class="sxs-lookup"><span data-stu-id="45cda-128">This should make it easier for developers to find what they're looking for, and to implement features of their choice across multiple platforms.</span></span>

## <a name="videos"></a><span data-ttu-id="45cda-129">ビデオ</span><span class="sxs-lookup"><span data-stu-id="45cda-129">Videos</span></span>

### <a name="xbox-live-unity-plugin"></a><span data-ttu-id="45cda-130">Xbox Live Unity プラグイン</span><span class="sxs-lookup"><span data-stu-id="45cda-130">Xbox Live Unity plugin</span></span>

<span data-ttu-id="45cda-131">Unity の Xbox Live プラグインには、タイトルに Xbox Live のサインイン、統計、友人リスト、クラウド ストレージ、およびスコアボードを追加するためのサポートが含まれています。</span><span class="sxs-lookup"><span data-stu-id="45cda-131">The Xbox Live plugin for Unity contains support for adding Xbox Live signing, stats, friends lists, cloud storage, and leaderboards to your title.</span></span> <span data-ttu-id="45cda-132">詳しくは、[ビデオを見る](https://youtu.be/fVQZ-YgwNpY)を [ [GitHub パッケージのダウンロード](https://aka.ms/UnityPlugin)を開始するのにはします。</span><span class="sxs-lookup"><span data-stu-id="45cda-132">[Watch the video](https://youtu.be/fVQZ-YgwNpY) to learn more, then [download the GitHub package](https://aka.ms/UnityPlugin) to get started.</span></span>

### <a name="one-dev-question"></a><span data-ttu-id="45cda-133">1 つの開発質問</span><span class="sxs-lookup"><span data-stu-id="45cda-133">One Dev Question</span></span>

<span data-ttu-id="45cda-134">1 つの開発質問ビデオ シリーズでは、長い Microsoft 開発者は、一連の Windows の開発、チームのカルチャと履歴に関する質問を説明します。</span><span class="sxs-lookup"><span data-stu-id="45cda-134">In the One Dev Question video series, longtime Microsoft developers cover a series of questions about Windows development, team culture, and history.</span></span> <span data-ttu-id="45cda-135">回答を最新の質問は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="45cda-135">Here's the latest questions that we've answered!</span></span>

<span data-ttu-id="45cda-136">Raymond 氏チェンの場合:</span><span class="sxs-lookup"><span data-stu-id="45cda-136">Raymond Chen:</span></span>

* [<span data-ttu-id="45cda-137">カーネル情報はどのビデオ ドライバーを再起動する場合ですか。</span><span class="sxs-lookup"><span data-stu-id="45cda-137">How does the kernel know when to restart a video driver?</span></span>](https://youtu.be/3SNAdyO1l5c)

<span data-ttu-id="45cda-138">ラリー Osterman:</span><span class="sxs-lookup"><span data-stu-id="45cda-138">Larry Osterman:</span></span>

* [<span data-ttu-id="45cda-139">Windows の Burgermaster オブジェクトの背面にあるストーリーとは何ですか。</span><span class="sxs-lookup"><span data-stu-id="45cda-139">What's the story behind the Burgermaster object in Windows?</span></span>](https://youtu.be/0TDSbyAIvX0)