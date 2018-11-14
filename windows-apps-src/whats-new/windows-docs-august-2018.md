---
author: QuinnRadich
title: Windows ドキュメントの最新情報で新 2018 年 8 月 - UWP アプリの開発
description: 2018 年 8 月の Windows 10 開発者向けドキュメントに、新しい機能、ビデオ、サンプル、および開発者向けガイダンスが追加されました。
keywords: 新機能, 更新, 機能, 開発者向けガイダンス, Windows 10, 8 月
ms.author: quradic
ms.date: 08/14/2018
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 76de6c5c1e8925dd8b166a8d99c39116bf66141d
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6195791"
---
# <a name="whats-new-in-the-windows-developer-docs-in-august-2018"></a><span data-ttu-id="f4577-104">新機能、Windows 開発者向けドキュメントの 2018 年 8 月</span><span class="sxs-lookup"><span data-stu-id="f4577-104">What's New in the Windows Developer Docs in August 2018</span></span>

<span data-ttu-id="f4577-105">Windows 開発者向けドキュメントは、Windows プラットフォームで開発者に提供される新機能の情報を反映して継続的に更新されています。</span><span class="sxs-lookup"><span data-stu-id="f4577-105">The Windows Developer Documentation is constantly being updated with information on new features available to developers across the Windows platform.</span></span> <span data-ttu-id="f4577-106">次の機能概要、開発者向けガイダンス、およびビデオには 8 月で利用可能ななりました。</span><span class="sxs-lookup"><span data-stu-id="f4577-106">The following feature overviews, developer guidance, and videos have been made available in the month of August.</span></span>

<span data-ttu-id="f4577-107">Windows 10 の[ツールと SDK をインストール](http://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/create-uwp-apps.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="f4577-107">[Install the tools and SDK](http://go.microsoft.com/fwlink/?LinkId=821431) on Windows 10 and you’re ready to either [create a new Universal Windows app](../get-started/create-uwp-apps.md) or explore how you can use your [existing app code on Windows](../porting/index.md).</span></span>

## <a name="features"></a><span data-ttu-id="f4577-108">機能</span><span class="sxs-lookup"><span data-stu-id="f4577-108">Features</span></span>

### <a name="design"></a><span data-ttu-id="f4577-109">設計</span><span class="sxs-lookup"><span data-stu-id="f4577-109">Design</span></span>

<span data-ttu-id="f4577-110">次の機能が Insider Preview ビルドの[Windows Insider](https://insider.windows.com/) program で利用できる、Windows に追加されました。</span><span class="sxs-lookup"><span data-stu-id="f4577-110">The following features have been added to the Windows Insider Preview builds, available through the [Windows Insider](https://insider.windows.com/) program.</span></span>

* <span data-ttu-id="f4577-111">[Windows UI のライブラリ](https://aka.ms/winui-docs)とは、UWP アプリのコントロールとその他のユーザーの interfact 要素を提供する NuGet パッケージのセットです。</span><span class="sxs-lookup"><span data-stu-id="f4577-111">The [Windows UI Library](https://aka.ms/winui-docs) is a set of NuGet packages that provide controls and other user interfact elements for UWP apps.</span></span> <span data-ttu-id="f4577-112">これらのパッケージも以前のバージョンの Windows 10 互換、ユーザーが最新の OS バージョンに存在しない場合でも、アプリが動作するようにします。</span><span class="sxs-lookup"><span data-stu-id="f4577-112">These packages are also compatable with earlier versions of Windows 10, so your app works even if your users don't have the latest OS version.</span></span>

* <span data-ttu-id="f4577-113">[DropDownButton](../design/controls-and-patterns/buttons.md#create-a-drop-down-button)、 [SplitButton](../design/controls-and-patterns/buttons.md#create-a-split-button)、および[ToggleSplitButton](../design/controls-and-patterns/buttons.md#create-a-toggle-split-button)は、アプリのユーザー インターフェイスを強化するために特殊な機能を備えたボタン コントロールを提供します。</span><span class="sxs-lookup"><span data-stu-id="f4577-113">[DropDownButton](../design/controls-and-patterns/buttons.md#create-a-drop-down-button), [SplitButton](../design/controls-and-patterns/buttons.md#create-a-split-button), and [ToggleSplitButton](../design/controls-and-patterns/buttons.md#create-a-toggle-split-button) provide button controls with specialized features to enhance your app's user interface.</span></span>

![前景色を選択するための分割ボタン](../design/controls-and-patterns/images/split-button-rtb.png)

* <span data-ttu-id="f4577-115">NavigationView がアプリのナビゲーション オプションの数を減らしてがあり、アプリのコンテンツの空き領域が必要な場合[上部のナビゲーション](../design/controls-and-patterns/navigationview.md)をサポートします。</span><span class="sxs-lookup"><span data-stu-id="f4577-115">NavigationView now supports [Top navigation](../design/controls-and-patterns/navigationview.md), for cases in which your app has a smaller number of navigation options and require more space for your app's content.</span></span>

* <span data-ttu-id="f4577-116">ツリー ビューがサポートするために拡張されて[データ バインディング、項目テンプレート、ドラッグ アンド ドロップします](../design/controls-and-patterns/tree-view.md)。</span><span class="sxs-lookup"><span data-stu-id="f4577-116">TreeView has been enhanced to support [data binding, item templates, and drag and drop.](../design/controls-and-patterns/tree-view.md)</span></span>

### <a name="package-support-framework"></a><span data-ttu-id="f4577-117">パッケージのサポート フレームワーク</span><span class="sxs-lookup"><span data-stu-id="f4577-117">Package Support Framework</span></span>

<span data-ttu-id="f4577-118">パッケージのサポート フレームワークでは、修正プログラムの適用、win32 アプリケーションをソース コードにアクセスできないとき MSIX コンテナーで実行できるようにするために役立つ、オープン ソースのキットです。</span><span class="sxs-lookup"><span data-stu-id="f4577-118">The package support framework is an open-source kit that helps you apply fixes to your win32 application when you don’t have access to the source code, so that it can run in an MSIX container.</span></span>

<span data-ttu-id="f4577-119">詳細については、[パッケージのサポートのフレームワークを使用して、MSIX パッケージを適用ランタイムの修正プログラム](../porting/package-support-framework.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f4577-119">To learn more, see [Apply runtime fixes to an MSIX package by using the Package Support Framework](../porting/package-support-framework.md).</span></span>

## <a name="developer-guidance"></a><span data-ttu-id="f4577-120">開発者向けガイダンス</span><span class="sxs-lookup"><span data-stu-id="f4577-120">Developer Guidance</span></span>

### <a name="web-api-extensions"></a><span data-ttu-id="f4577-121">Web API の拡張機能</span><span class="sxs-lookup"><span data-stu-id="f4577-121">Web API extensions</span></span>

<span data-ttu-id="f4577-122">Mozilla Developer Network ドキュメントには、ブラウザー間の web 開発、[従来の Microsoft API の拡張機能](https://developer.mozilla.org/docs/Web/API/Microsoft_API_extensions)の一覧が追加されました。</span><span class="sxs-lookup"><span data-stu-id="f4577-122">A list of [legacy Microsoft API extensions](https://developer.mozilla.org/docs/Web/API/Microsoft_API_extensions) has been added to the Mozilla Developer Network documentation for cross-browser web development.</span></span> <span data-ttu-id="f4577-123">これらの API の拡張機能は、Internet Explorer または Microsoft Edge に固有のもの MDN web ドキュメントの互換性とブラウザーのサポートに関する既存の情報を補足します。従来の Microsoft [CSS 拡張機能](https://developer.mozilla.org/docs/Web/CSS/Microsoft_Extensions)と[JavaScript の拡張機能](https://developer.mozilla.org/docs/Web/JavaScript/Microsoft_JavaScript_extensions)は、利用可能なもとで直接リッチ web MDN から API の情報が表示されるかを確認できます[Visual Studio Code](https://code.visualstudio.com/updates/v1_25#_new-css-pseudo-selectors-and-pseudo-elements-from-mdn) 。</span><span class="sxs-lookup"><span data-stu-id="f4577-123">These API extensions are unique to Internet Explorer or Microsoft Edge, and supplement existing information about compatibility and broswer support in the MDN web docs. Legacy Microsoft [CSS extensions](https://developer.mozilla.org/docs/Web/CSS/Microsoft_Extensions) and [JavaScript extensions](https://developer.mozilla.org/docs/Web/JavaScript/Microsoft_JavaScript_extensions) are also available, and you can find rich web API information from MDN surfaced directly in [Visual Studio Code.](https://code.visualstudio.com/updates/v1_25#_new-css-pseudo-selectors-and-pseudo-elements-from-mdn)</span></span>

### <a name="cwinrt-code-examples"></a><span data-ttu-id="f4577-124">C++/WinRT のコード例</span><span class="sxs-lookup"><span data-stu-id="f4577-124">C++/WinRT Code examples</span></span>

<span data-ttu-id="f4577-125">250 が追加されました[、C++/WinRT](../cpp-and-winrt-apis/index.md)付属している既存の C + 当社のドキュメントのトピックへの登録情報をコード/CX コード例を紹介します。</span><span class="sxs-lookup"><span data-stu-id="f4577-125">We've added 250 [C++/WinRT](../cpp-and-winrt-apis/index.md) code listings to topics in our docs, accompanying existing C++/CX code examples.</span></span>

### <a name="project-rome"></a><span data-ttu-id="f4577-126">Project Rome</span><span class="sxs-lookup"><span data-stu-id="f4577-126">Project Rome</span></span>

<span data-ttu-id="f4577-127">["Rome"プロジェクト ドキュメント](https://docs.microsoft.com/windows/project-rome/)サイトは、機能のアプローチに再編成されました。</span><span class="sxs-lookup"><span data-stu-id="f4577-127">The [Project Rome docs](https://docs.microsoft.com/windows/project-rome/) site has been reorganized into a feature-first approach.</span></span> <span data-ttu-id="f4577-128">これは、ため、開発者、求めているを検索して、任意の機能を実装し、複数のプラットフォーム間で簡単にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4577-128">This should make it easier for developers to find what they're looking for, and to implement features of their choice across multiple platforms.</span></span>

## <a name="videos"></a><span data-ttu-id="f4577-129">ビデオ</span><span class="sxs-lookup"><span data-stu-id="f4577-129">Videos</span></span>

### <a name="xbox-live-unity-plugin"></a><span data-ttu-id="f4577-130">Xbox Live Unity プラグイン</span><span class="sxs-lookup"><span data-stu-id="f4577-130">Xbox Live Unity plugin</span></span>

<span data-ttu-id="f4577-131">Unity の Xbox Live プラグインには、Xbox Live への署名、統計情報、フレンド リスト、クラウド ストレージ、およびランキングをタイトルに追加するためのサポートが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f4577-131">The Xbox Live plugin for Unity contains support for adding Xbox Live signing, stats, friends lists, cloud storage, and leaderboards to your title.</span></span> <span data-ttu-id="f4577-132">について[は、ビデオ](https://youtu.be/fVQZ-YgwNpY)をし、 [GitHub のパッケージをダウンロード](https://aka.ms/UnityPlugin)を開始します。</span><span class="sxs-lookup"><span data-stu-id="f4577-132">[Watch the video](https://youtu.be/fVQZ-YgwNpY) to learn more, then [download the GitHub package](https://aka.ms/UnityPlugin) to get started.</span></span>

### <a name="one-dev-question"></a><span data-ttu-id="f4577-133">1 つのデベロッパー質問</span><span class="sxs-lookup"><span data-stu-id="f4577-133">One Dev Question</span></span>

<span data-ttu-id="f4577-134">デベロッパー質問の 1 つのビデオ シリーズの長い Microsoft 開発者は一連の Windows の開発、チームのカルチャと履歴に関する質問について説明します。</span><span class="sxs-lookup"><span data-stu-id="f4577-134">In the One Dev Question video series, longtime Microsoft developers cover a series of questions about Windows development, team culture, and history.</span></span> <span data-ttu-id="f4577-135">お答えした最新の質問を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="f4577-135">Here's the latest questions that we've answered!</span></span>

<span data-ttu-id="f4577-136">Raymond Chen:</span><span class="sxs-lookup"><span data-stu-id="f4577-136">Raymond Chen:</span></span>

* [<span data-ttu-id="f4577-137">カーネルを知るビデオ ドライバーを再起動するかどうか。</span><span class="sxs-lookup"><span data-stu-id="f4577-137">How does the kernel know when to restart a video driver?</span></span>](https://youtu.be/3SNAdyO1l5c)

<span data-ttu-id="f4577-138">Larry Osterman:</span><span class="sxs-lookup"><span data-stu-id="f4577-138">Larry Osterman:</span></span>

* [<span data-ttu-id="f4577-139">Windows で Burgermaster オブジェクトの背後にあるストーリーとは何ですか。</span><span class="sxs-lookup"><span data-stu-id="f4577-139">What's the story behind the Burgermaster object in Windows?</span></span>](https://youtu.be/0TDSbyAIvX0)