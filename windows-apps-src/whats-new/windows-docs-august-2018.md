---
title: 8 月の 2018 年に Windows Docs の新 - UWP アプリを開発します。
description: Windows 10 の開発者向けドキュメント 2018 の年 8 月の新機能、ビデオ、サンプル、および開発者向けガイダンスが追加されました。
keywords: 新機能については、更新、機能、開発者向けガイダンスについては、Windows 10、8 月
ms.date: 08/14/2018
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 9922aa1ad2442153dcc2c13d05520c05c3b56d31
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57616487"
---
# <a name="whats-new-in-the-windows-developer-docs-in-august-2018"></a><span data-ttu-id="b087b-104">新機能については、Windows 開発者向けドキュメントで 2018 の年 8 月です。</span><span class="sxs-lookup"><span data-stu-id="b087b-104">What's New in the Windows Developer Docs in August 2018</span></span>

<span data-ttu-id="b087b-105">Windows 開発者向けドキュメントは、Windows プラットフォームで開発者に提供される新機能の情報を反映して継続的に更新されています。</span><span class="sxs-lookup"><span data-stu-id="b087b-105">The Windows Developer Documentation is constantly being updated with information on new features available to developers across the Windows platform.</span></span> <span data-ttu-id="b087b-106">次の機能の概要、開発者ガイド、およびビデオが 8 月以降の月の使用可能な加えられました。</span><span class="sxs-lookup"><span data-stu-id="b087b-106">The following feature overviews, developer guidance, and videos have been made available in the month of August.</span></span>

<span data-ttu-id="b087b-107">Windows 10 の[ツールと SDK をインストール](https://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/create-uwp-apps.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="b087b-107">[Install the tools and SDK](https://go.microsoft.com/fwlink/?LinkId=821431) on Windows 10 and you’re ready to either [create a new Universal Windows app](../get-started/create-uwp-apps.md) or explore how you can use your [existing app code on Windows](../porting/index.md).</span></span>

## <a name="features"></a><span data-ttu-id="b087b-108">機能</span><span class="sxs-lookup"><span data-stu-id="b087b-108">Features</span></span>

### <a name="design"></a><span data-ttu-id="b087b-109">設計</span><span class="sxs-lookup"><span data-stu-id="b087b-109">Design</span></span>

<span data-ttu-id="b087b-110">次の機能に加え、Windows Insider Preview ビルドの利用、 [Windows Insider](https://insider.windows.com/)プログラム。</span><span class="sxs-lookup"><span data-stu-id="b087b-110">The following features have been added to the Windows Insider Preview builds, available through the [Windows Insider](https://insider.windows.com/) program.</span></span>

* <span data-ttu-id="b087b-111">[Windows UI ライブラリ](https://aka.ms/winui-docs)は UWP アプリ用、interfact 要素でコントロールおよびその他のユーザーが提供する NuGet パッケージのセットです。</span><span class="sxs-lookup"><span data-stu-id="b087b-111">The [Windows UI Library](https://aka.ms/winui-docs) is a set of NuGet packages that provide controls and other user interfact elements for UWP apps.</span></span> <span data-ttu-id="b087b-112">これらのパッケージは以前のバージョンの Windows 10 では、プレリリースではも、ユーザーは最新の OS バージョンがあるない場合でも、アプリが動作するようにします。</span><span class="sxs-lookup"><span data-stu-id="b087b-112">These packages are also compatable with earlier versions of Windows 10, so your app works even if your users don't have the latest OS version.</span></span>

* <span data-ttu-id="b087b-113">[DropDownButton](../design/controls-and-patterns/buttons.md#create-a-drop-down-button)、 [SplitButton](../design/controls-and-patterns/buttons.md#create-a-split-button)、および[ToggleSplitButton](../design/controls-and-patterns/buttons.md#create-a-toggle-split-button)ボタン コントロールをアプリのユーザー インターフェイスを強化するために特別な機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="b087b-113">[DropDownButton](../design/controls-and-patterns/buttons.md#create-a-drop-down-button), [SplitButton](../design/controls-and-patterns/buttons.md#create-a-split-button), and [ToggleSplitButton](../design/controls-and-patterns/buttons.md#create-a-toggle-split-button) provide button controls with specialized features to enhance your app's user interface.</span></span>

![前景色を選択するための分割ボタン](../design/controls-and-patterns/images/split-button-rtb.png)

* <span data-ttu-id="b087b-115">NavigationView ようになりました[トップ ナビゲーション](../design/controls-and-patterns/navigationview.md)、ケースをアプリが、少数のナビゲーション オプションと、アプリのコンテンツの空き領域が必要です。</span><span class="sxs-lookup"><span data-stu-id="b087b-115">NavigationView now supports [Top navigation](../design/controls-and-patterns/navigationview.md), for cases in which your app has a smaller number of navigation options and require more space for your app's content.</span></span>

* <span data-ttu-id="b087b-116">ツリー ビューがサポートするために強化されました[データ バインディング、項目テンプレート、およびドラッグ アンド ドロップします。](../design/controls-and-patterns/tree-view.md)</span><span class="sxs-lookup"><span data-stu-id="b087b-116">TreeView has been enhanced to support [data binding, item templates, and drag and drop.](../design/controls-and-patterns/tree-view.md)</span></span>

### <a name="package-support-framework"></a><span data-ttu-id="b087b-117">パッケージ サポート フレームワーク</span><span class="sxs-lookup"><span data-stu-id="b087b-117">Package Support Framework</span></span>

<span data-ttu-id="b087b-118">パッケージのサポート、フレームワークは、修正プログラムを適用、win32 アプリケーションに、ソース コードへのアクセス権がないときに、MSIX コンテナーで実行できるようにするのに役立つオープン ソース キット。</span><span class="sxs-lookup"><span data-stu-id="b087b-118">The package support framework is an open-source kit that helps you apply fixes to your win32 application when you don’t have access to the source code, so that it can run in an MSIX container.</span></span>

<span data-ttu-id="b087b-119">詳細についてを参照してください。[パッケージ サポートのフレームワークを使用して、MSIX パッケージに修正プログラム適用ランタイム](../porting/package-support-framework.md)します。</span><span class="sxs-lookup"><span data-stu-id="b087b-119">To learn more, see [Apply runtime fixes to an MSIX package by using the Package Support Framework](../porting/package-support-framework.md).</span></span>

## <a name="developer-guidance"></a><span data-ttu-id="b087b-120">開発者向けガイダンス</span><span class="sxs-lookup"><span data-stu-id="b087b-120">Developer Guidance</span></span>

### <a name="web-api-extensions"></a><span data-ttu-id="b087b-121">Web API の拡張機能</span><span class="sxs-lookup"><span data-stu-id="b087b-121">Web API extensions</span></span>

<span data-ttu-id="b087b-122">一連の[従来の Microsoft API 拡張機能](https://developer.mozilla.org/docs/Web/API/Microsoft_API_extensions)クロスブラウザー web 開発用 Mozilla Developer Network のドキュメントに追加されました。</span><span class="sxs-lookup"><span data-stu-id="b087b-122">A list of [legacy Microsoft API extensions](https://developer.mozilla.org/docs/Web/API/Microsoft_API_extensions) has been added to the Mozilla Developer Network documentation for cross-browser web development.</span></span> <span data-ttu-id="b087b-123">これらの API 拡張機能は Internet Explorer または Microsoft Edge、一意であり、MDN の web ドキュメントの互換性とブラウザーのサポートに関する既存の情報を補完します。レガシの Microsoft [CSS の拡張機能](https://developer.mozilla.org/docs/Web/CSS/Microsoft_Extensions)と[JavaScript 拡張](https://developer.mozilla.org/docs/Web/JavaScript/Microsoft_JavaScript_extensions)も利用してリッチな web API については、MDN の表示で直接を検索できます[Visual Studio Code。](https://code.visualstudio.com/updates/v1_25#_new-css-pseudo-selectors-and-pseudo-elements-from-mdn)</span><span class="sxs-lookup"><span data-stu-id="b087b-123">These API extensions are unique to Internet Explorer or Microsoft Edge, and supplement existing information about compatibility and broswer support in the MDN web docs. Legacy Microsoft [CSS extensions](https://developer.mozilla.org/docs/Web/CSS/Microsoft_Extensions) and [JavaScript extensions](https://developer.mozilla.org/docs/Web/JavaScript/Microsoft_JavaScript_extensions) are also available, and you can find rich web API information from MDN surfaced directly in [Visual Studio Code.](https://code.visualstudio.com/updates/v1_25#_new-css-pseudo-selectors-and-pseudo-elements-from-mdn)</span></span>

### <a name="cwinrt-code-examples"></a><span data-ttu-id="b087b-124">C +/cli WinRT のコード例</span><span class="sxs-lookup"><span data-stu-id="b087b-124">C++/WinRT Code examples</span></span>

<span data-ttu-id="b087b-125">250 を追加しました[C +/cli WinRT](../cpp-and-winrt-apis/index.md)コード、既存の C + に付属する、ドキュメントのトピックを一覧/cli CX のコード例です。</span><span class="sxs-lookup"><span data-stu-id="b087b-125">We've added 250 [C++/WinRT](../cpp-and-winrt-apis/index.md) code listings to topics in our docs, accompanying existing C++/CX code examples.</span></span>

### <a name="project-rome"></a><span data-ttu-id="b087b-126">Project Rome</span><span class="sxs-lookup"><span data-stu-id="b087b-126">Project Rome</span></span>

<span data-ttu-id="b087b-127">[プロジェクト ローマ docs](https://docs.microsoft.com/windows/project-rome/)機能優先のアプローチにサイトが再編成されました。</span><span class="sxs-lookup"><span data-stu-id="b087b-127">The [Project Rome docs](https://docs.microsoft.com/windows/project-rome/) site has been reorganized into a feature-first approach.</span></span> <span data-ttu-id="b087b-128">これは、ため、開発者が探しているものを検索して、複数のプラットフォームでの任意の機能を実装するために簡単に、必要があります。</span><span class="sxs-lookup"><span data-stu-id="b087b-128">This should make it easier for developers to find what they're looking for, and to implement features of their choice across multiple platforms.</span></span>

## <a name="videos"></a><span data-ttu-id="b087b-129">ビデオ</span><span class="sxs-lookup"><span data-stu-id="b087b-129">Videos</span></span>

### <a name="xbox-live-unity-plugin"></a><span data-ttu-id="b087b-130">Xbox Live の Unity プラグイン</span><span class="sxs-lookup"><span data-stu-id="b087b-130">Xbox Live Unity plugin</span></span>

<span data-ttu-id="b087b-131">Unity の Xbox Live プラグインには、タイトルを署名 Xbox Live、統計、フレンド リスト、クラウドの記憶域、およびスコアボードを追加するためのサポートが含まれています。</span><span class="sxs-lookup"><span data-stu-id="b087b-131">The Xbox Live plugin for Unity contains support for adding Xbox Live signing, stats, friends lists, cloud storage, and leaderboards to your title.</span></span> <span data-ttu-id="b087b-132">[ビデオを見る](https://youtu.be/fVQZ-YgwNpY)、詳細については、 [GitHub パッケージをダウンロード](https://aka.ms/UnityPlugin)を開始します。</span><span class="sxs-lookup"><span data-stu-id="b087b-132">[Watch the video](https://youtu.be/fVQZ-YgwNpY) to learn more, then [download the GitHub package](https://aka.ms/UnityPlugin) to get started.</span></span>

### <a name="one-dev-question"></a><span data-ttu-id="b087b-133">開発用の 1 つの質問</span><span class="sxs-lookup"><span data-stu-id="b087b-133">One Dev Question</span></span>

<span data-ttu-id="b087b-134">開発用の 1 つの質問のビデオ シリーズでは、マイクロソフトのベテランの開発者は、一連の Windows の開発、チームのカルチャ、および履歴に関する質問を説明します。</span><span class="sxs-lookup"><span data-stu-id="b087b-134">In the One Dev Question video series, longtime Microsoft developers cover a series of questions about Windows development, team culture, and history.</span></span> <span data-ttu-id="b087b-135">お答えした最新の質問を次に示します。</span><span class="sxs-lookup"><span data-stu-id="b087b-135">Here's the latest questions that we've answered!</span></span>

<span data-ttu-id="b087b-136">Raymond Chen:</span><span class="sxs-lookup"><span data-stu-id="b087b-136">Raymond Chen:</span></span>

* [<span data-ttu-id="b087b-137">カーネルを認識する方法、ビデオ ドライバーを再起動するタイミングですか。</span><span class="sxs-lookup"><span data-stu-id="b087b-137">How does the kernel know when to restart a video driver?</span></span>](https://youtu.be/3SNAdyO1l5c)

<span data-ttu-id="b087b-138">Larry Osterman の場合:</span><span class="sxs-lookup"><span data-stu-id="b087b-138">Larry Osterman:</span></span>

* [<span data-ttu-id="b087b-139">Windows で Burgermaster オブジェクトの背後にあるストーリーとは何ですか。</span><span class="sxs-lookup"><span data-stu-id="b087b-139">What's the story behind the Burgermaster object in Windows?</span></span>](https://youtu.be/0TDSbyAIvX0)