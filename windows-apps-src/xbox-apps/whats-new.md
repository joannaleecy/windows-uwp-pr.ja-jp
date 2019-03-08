---
title: Xbox One の UWP の新着情報
description: Xbox One の UWP アプリの新機能について説明します。
ms.date: 03/29/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: fe63c527-8f06-43a5-868f-de909f5664b3
ms.localizationpriority: medium
ms.openlocfilehash: aff65e5f1b4771cbb33bc8b8219224042b7bf7e2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57660687"
---
# <a name="whats-new-for-developers-in-the-latest-update-of-uwp-on-xbox-one"></a><span data-ttu-id="40933-104">Xbox One の UWP の最新の更新プログラムでの開発者向けの新機能</span><span class="sxs-lookup"><span data-stu-id="40933-104">What's new for developers in the latest update of UWP on Xbox One</span></span>

<span data-ttu-id="40933-105">Xbox One のユニバーサル Windows プラットフォーム (UWP) の最新の更新プログラムには、次の新しい機能、既存の機能の更新、バグ修正が含まれています。</span><span class="sxs-lookup"><span data-stu-id="40933-105">The latest update of Universal Windows Platform (UWP) on Xbox One contains the following new features, updates to existing features, and bug fixes.</span></span>

## <a name="x86-apps-and-games-are-no-longer-supported-on-xbox"></a><span data-ttu-id="40933-106">x86 アプリおよびゲームの Xbox でのサポート停止</span><span class="sxs-lookup"><span data-stu-id="40933-106">x86 apps and games are no longer supported on Xbox</span></span>  
<span data-ttu-id="40933-107">Xbox では、x86 アプリの開発または x86 アプリのストアへの申請をサポートしなくなりました。</span><span class="sxs-lookup"><span data-stu-id="40933-107">Xbox no longer supports x86 app development or x86 app submissions to the store.</span></span>

## <a name="apps-can-now-support-navigating-back-to-the-previous-app"></a><span data-ttu-id="40933-108">アプリは前のアプリに戻る移動をサポート可能に</span><span class="sxs-lookup"><span data-stu-id="40933-108">Apps can now support navigating back to the previous app</span></span> 
<span data-ttu-id="40933-109">Xbox One アプリの UWP では、前のアプリに戻る移動をサポートできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="40933-109">UWP on Xbox One apps can now support navigating back to the previous app.</span></span> <span data-ttu-id="40933-110">これを行うには、[**Windows.UI.Core.SystemNavigationManager.BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893595) イベントにサブスクライブし、イベント ハンドラーで **Handled** プロパティを **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="40933-110">To do this, subscribe to the [**Windows.UI.Core.SystemNavigationManager.BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893595) event and set the **Handled** property to **false** in your event handler.</span></span>

> [!NOTE]
> <span data-ttu-id="40933-111">互換性の理由から、この機能は Xbox One で最新リリースの UWP を使って構築されたアプリでのみ利用できます。</span><span class="sxs-lookup"><span data-stu-id="40933-111">For compatibility reasons, this functionality is available only to apps that are built with the most recent release of UWP on Xbox One.</span></span> 

## <a name="dev-home-is-now-the-default-home-experience-on-development-consoles"></a><span data-ttu-id="40933-112">Dev Home が開発コンソールにおける既定のホーム エクスペリエンスに</span><span class="sxs-lookup"><span data-stu-id="40933-112">Dev Home is now the default home experience on development consoles</span></span>
<span data-ttu-id="40933-113">開発コンソールでは、既定のホーム エクスペリエンスとして Dev Home が起動するようになりました。</span><span class="sxs-lookup"><span data-stu-id="40933-113">Development consoles now launch Dev Home as the default home experience.</span></span> <span data-ttu-id="40933-114">これにより、製品版のホーム画面でクリックしなくてもすぐに作業を始めることができるようになりました。</span><span class="sxs-lookup"><span data-stu-id="40933-114">This lets you get right to work without the need to click through from the retail Home screen.</span></span> <span data-ttu-id="40933-115">Dev Home には、製品版のホーム画面を起動するクイックアクションが追加されました。</span><span class="sxs-lookup"><span data-stu-id="40933-115">Dev Home now includes a quick action to launch the retail Home screen.</span></span> <span data-ttu-id="40933-116">また、新しい設定では製品版のホーム画面を既定のエクスペリエンスにすることができます。</span><span class="sxs-lookup"><span data-stu-id="40933-116">Also, a new setting allows you to make retail Home the default experience.</span></span> 

## <a name="new-dev-home-user-interface"></a><span data-ttu-id="40933-117">新しい Dev Home ユーザー インターフェイス</span><span class="sxs-lookup"><span data-stu-id="40933-117">New Dev Home user interface</span></span>
<span data-ttu-id="40933-118">Dev Home のユーザー インターフェイスに、次の生産性強化機能が追加されました。</span><span class="sxs-lookup"><span data-stu-id="40933-118">The Dev Home user interface now includes the following productivity enhancements:</span></span>
 - <span data-ttu-id="40933-119">IP アドレスや回復バージョンなどの重要なデータが、見やすいように画面の上部に表示されるようになりました。</span><span class="sxs-lookup"><span data-stu-id="40933-119">Important data like IP address and recovery version is now displayed at the top of the screen for visibility.</span></span> 
 - <span data-ttu-id="40933-120">Dev Home は、ツールが論理セットにグループ化されるタブ付き UI になり、すばやいナビゲーションが可能になりました。</span><span class="sxs-lookup"><span data-stu-id="40933-120">Dev Home now has a tabbed UI that groups tools into logical sets, allowing quick navigation.</span></span>
 - <span data-ttu-id="40933-121">Dev Home の最初のタブにあるクイックアクション ボタンにより、最もよく使われる操作にすばやくアクセスできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="40933-121">Quick-action buttons on the first tab of Dev Home allow fast access to the most commonly used actions.</span></span> 

## <a name="wdp-for-xbox-enhancements"></a><span data-ttu-id="40933-122">Xbox の機能を強化するための WDP</span><span class="sxs-lookup"><span data-stu-id="40933-122">WDP for Xbox enhancements</span></span>
<span data-ttu-id="40933-123">Windows Device Portal (WDP) にコンソール設定のサポートが追加されました。</span><span class="sxs-lookup"><span data-stu-id="40933-123">The Windows Device Portal (WDP) now includes additional support for console settings.</span></span> 

## <a name="you-can-now-switch-the-type-of-your-uwp-title-between-app-and-game"></a><span data-ttu-id="40933-124">"アプリ" と "ゲーム" の間で、UWP タイトルの種類を切り替えることができるようになりました。</span><span class="sxs-lookup"><span data-stu-id="40933-124">You can now switch the type of your UWP title between "App" and "Game"</span></span>
<span data-ttu-id="40933-125">"アプリ" と "ゲーム" の間で UWP タイトルの種類を切り替えると、ストアに公開しなくてもゲーム シナリオをテストすることができます。</span><span class="sxs-lookup"><span data-stu-id="40933-125">Switching the type of your UWP title between "App" and "Game" allows you to test game scenarios without publishing to the store.</span></span> <span data-ttu-id="40933-126">Dev Home の **[アプリ+ゲーム]** ウィンドウでアプリを選んでコントローラーで [表示] ボタンを押し、**[アプリの詳細]** を選んで種類を "アプリ" または "ゲーム" に変更します。</span><span class="sxs-lookup"><span data-stu-id="40933-126">In Dev Home, select the app in the **Games & Apps** pane, press the View button on the controller, select **App details** and then change the type to "App" or "Game".</span></span>

## <a name="see-also"></a><span data-ttu-id="40933-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="40933-127">See also</span></span>
- [<span data-ttu-id="40933-128">既知の問題</span><span class="sxs-lookup"><span data-stu-id="40933-128">Known issues</span></span>](known-issues.md)
- [<span data-ttu-id="40933-129">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="40933-129">UWP on Xbox One</span></span>](index.md)
 - <span data-ttu-id="40933-130">コンソールのスクリーンショットをキャプチャできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="40933-130">You can now capture a screenshot of the console.</span></span> <span data-ttu-id="40933-131">スクリーンショットのキャプチャについて詳しくは、「[/ext/screenshot](wdp-media-capture-api.md)」リファレンス トピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="40933-131">For more information about taking a screenshot, see the [/ext/screenshot](wdp-media-capture-api.md) reference topic.</span></span>
 - <span data-ttu-id="40933-132">このツールでは、アプリの緩やかなファイル ビルドを展開できます。</span><span class="sxs-lookup"><span data-stu-id="40933-132">The tool can deploy a loose file build of your app.</span></span> <span data-ttu-id="40933-133">緩やかなファイル ビルドについて詳しくは、「[/api/app/packagemanager/register](wdp-loose-folder-register-api.md)」リファレンス トピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="40933-133">For more information about loose file builds, see the [/api/app/packagemanager/register](wdp-loose-folder-register-api.md) reference topic.</span></span>
 - <span data-ttu-id="40933-134">コンソールの開発者ファイルには、開発用 PC のエクスプローラーからアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="40933-134">Developer files on your console can be accessed from File Explorer on your development PC.</span></span> <span data-ttu-id="40933-135">エクスプローラーを介したファイルのアクセスについて詳しくは、「[/ext/smb/developerfolder](wdp-smb-api.md)」リファレンス トピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="40933-135">For more information about accessing files through File Explorer, see the [/ext/smb/developerfolder](wdp-smb-api.md) reference topic.</span></span>

## <a name="see-also"></a><span data-ttu-id="40933-136">関連項目</span><span class="sxs-lookup"><span data-stu-id="40933-136">See also</span></span>
- [<span data-ttu-id="40933-137">既知の問題</span><span class="sxs-lookup"><span data-stu-id="40933-137">Known issues</span></span>](known-issues.md)
- [<span data-ttu-id="40933-138">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="40933-138">UWP on Xbox One</span></span>](index.md)
