---
author: v-angraf
title: Xbox One の UWP の新着情報
description: Xbox One の UWP アプリの新機能について説明します。
ms.author: v-angraf
ms.date: 03/29/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: fe63c527-8f06-43a5-868f-de909f5664b3
ms.localizationpriority: medium
ms.openlocfilehash: cc2168014e714de0b43b6ffffe84126764f0a4a3
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6024291"
---
# <a name="whats-new-for-developers-in-the-latest-update-of-uwp-on-xbox-one"></a><span data-ttu-id="1859e-104">Xbox One の UWP の最新の更新プログラムにおける開発者向け新着情報</span><span class="sxs-lookup"><span data-stu-id="1859e-104">What's new for developers in the latest update of UWP on Xbox One</span></span>

<span data-ttu-id="1859e-105">最新の更新プログラム ユニバーサル Windows プラットフォーム (UWP) Xbox One でにはは、次の新機能、既存の機能やバグ修正する更新プログラムが含まれます。</span><span class="sxs-lookup"><span data-stu-id="1859e-105">The latest update of Universal Windows Platform (UWP) on Xbox One contains the following new features, updates to existing features, and bug fixes.</span></span>

## <a name="x86-apps-and-games-are-no-longer-supported-on-xbox"></a><span data-ttu-id="1859e-106">x86 アプリやゲームは Xbox でサポートされなくなった</span><span class="sxs-lookup"><span data-stu-id="1859e-106">x86 apps and games are no longer supported on Xbox</span></span>  
<span data-ttu-id="1859e-107">Xbox では、x86 アプリの開発または x86 アプリのストアへの申請をサポートしなくなりました。</span><span class="sxs-lookup"><span data-stu-id="1859e-107">Xbox no longer supports x86 app development or x86 app submissions to the store.</span></span>

## <a name="apps-can-now-support-navigating-back-to-the-previous-app"></a><span data-ttu-id="1859e-108">アプリは、前のアプリに戻る移動でサポートできます。</span><span class="sxs-lookup"><span data-stu-id="1859e-108">Apps can now support navigating back to the previous app</span></span> 
<span data-ttu-id="1859e-109">アプリが Xbox One の UWP では、前のアプリに戻る移動をサポートできますできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="1859e-109">UWP on Xbox One apps can now support navigating back to the previous app.</span></span> <span data-ttu-id="1859e-110">これを行うには、 [**Windows.UI.Core.SystemNavigationManager.BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893595)イベントをサブスクライブし、 **false**イベント ハンドラーで**Handled**プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="1859e-110">To do this, subscribe to the [**Windows.UI.Core.SystemNavigationManager.BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893595) event and set the **Handled** property to **false** in your event handler.</span></span>

> [!NOTE]
> <span data-ttu-id="1859e-111">互換性の理由から、この機能は、Xbox One の UWP の最新リリースに組み込まれているアプリでのみ利用可能です。</span><span class="sxs-lookup"><span data-stu-id="1859e-111">For compatibility reasons, this functionality is available only to apps that are built with the most recent release of UWP on Xbox One.</span></span> 

## <a name="dev-home-is-now-the-default-home-experience-on-development-consoles"></a><span data-ttu-id="1859e-112">Dev Home は開発コンソールで既定のホーム エクスペリエンスができるようになりました。</span><span class="sxs-lookup"><span data-stu-id="1859e-112">Dev Home is now the default home experience on development consoles</span></span>
<span data-ttu-id="1859e-113">今すぐ開発コンソールは、既定のホーム エクスペリエンスとして Dev Home を起動します。</span><span class="sxs-lookup"><span data-stu-id="1859e-113">Development consoles now launch Dev Home as the default home experience.</span></span> <span data-ttu-id="1859e-114">これにより、製品版ホーム画面からクリックスルーすることがなく動作する適切なできます。</span><span class="sxs-lookup"><span data-stu-id="1859e-114">This lets you get right to work without the need to click through from the retail Home screen.</span></span> <span data-ttu-id="1859e-115">Dev Home には、製品版ホーム画面を起動するクイック アクションが含まれています。</span><span class="sxs-lookup"><span data-stu-id="1859e-115">Dev Home now includes a quick action to launch the retail Home screen.</span></span> <span data-ttu-id="1859e-116">また、新しい設定には、既定のエクスペリエンスを小売ホームようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="1859e-116">Also, a new setting allows you to make retail Home the default experience.</span></span> 

## <a name="new-dev-home-user-interface"></a><span data-ttu-id="1859e-117">Dev Home の新しいユーザー インターフェイス</span><span class="sxs-lookup"><span data-stu-id="1859e-117">New Dev Home user interface</span></span>
<span data-ttu-id="1859e-118">Dev Home のユーザー インターフェイスには、次の生産性向上にはできるようになりましたが含まれています。</span><span class="sxs-lookup"><span data-stu-id="1859e-118">The Dev Home user interface now includes the following productivity enhancements:</span></span>
 - <span data-ttu-id="1859e-119">重要なデータなどの IP アドレスと回復のバージョンがの可視性で、画面の上部に表示されるようになりました。</span><span class="sxs-lookup"><span data-stu-id="1859e-119">Important data like IP address and recovery version is now displayed at the top of the screen for visibility.</span></span> 
 - <span data-ttu-id="1859e-120">Dev Home は、タブ UI 論理セットにツールをグループ化されているすばやいナビゲーションを許可するようになりました。</span><span class="sxs-lookup"><span data-stu-id="1859e-120">Dev Home now has a tabbed UI that groups tools into logical sets, allowing quick navigation.</span></span>
 - <span data-ttu-id="1859e-121">Dev Home の最初のタブのクイック アクション ボタンでは、最もよく使われる操作を高速アクセスを許可します。</span><span class="sxs-lookup"><span data-stu-id="1859e-121">Quick-action buttons on the first tab of Dev Home allow fast access to the most commonly used actions.</span></span> 

## <a name="wdp-for-xbox-enhancements"></a><span data-ttu-id="1859e-122">Xbox の機能強化 WDP</span><span class="sxs-lookup"><span data-stu-id="1859e-122">WDP for Xbox enhancements</span></span>
<span data-ttu-id="1859e-123">Windows Device Portal (WDP) には、コンソールの設定の追加のサポートが含まれています。</span><span class="sxs-lookup"><span data-stu-id="1859e-123">The Windows Device Portal (WDP) now includes additional support for console settings.</span></span> 

## <a name="you-can-now-switch-the-type-of-your-uwp-title-between-app-and-game"></a><span data-ttu-id="1859e-124">これで、"App"と"Game"の間で UWP タイトルの種類を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="1859e-124">You can now switch the type of your UWP title between "App" and "Game"</span></span>
<span data-ttu-id="1859e-125">"App"と「ゲーム」の間で UWP タイトルの種類を切り替えるには、ストアに公開することがなくゲーム シナリオをテストすることができます。</span><span class="sxs-lookup"><span data-stu-id="1859e-125">Switching the type of your UWP title between "App" and "Game" allows you to test game scenarios without publishing to the store.</span></span> <span data-ttu-id="1859e-126">Dev home では、**ゲームとアプリ**のウィンドウで、アプリを選択、コント ローラーのビュー ボタンを押して、**アプリの詳細**を選択およびの種類を"App"または"Game"に変更します。</span><span class="sxs-lookup"><span data-stu-id="1859e-126">In Dev Home, select the app in the **Games & Apps** pane, press the View button on the controller, select **App details** and then change the type to "App" or "Game".</span></span>

## <a name="see-also"></a><span data-ttu-id="1859e-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="1859e-127">See also</span></span>
- [<span data-ttu-id="1859e-128">既知の問題</span><span class="sxs-lookup"><span data-stu-id="1859e-128">Known issues</span></span>](known-issues.md)
- [<span data-ttu-id="1859e-129">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="1859e-129">UWP on Xbox One</span></span>](index.md)
 - <span data-ttu-id="1859e-130">コンソールのスクリーンショットをキャプチャできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="1859e-130">You can now capture a screenshot of the console.</span></span> <span data-ttu-id="1859e-131">スクリーンショットのキャプチャについて詳しくは、「[/ext/screenshot](wdp-media-capture-api.md)」リファレンス トピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1859e-131">For more information about taking a screenshot, see the [/ext/screenshot](wdp-media-capture-api.md) reference topic.</span></span>
 - <span data-ttu-id="1859e-132">このツールでは、アプリの緩やかなファイル ビルドを展開できます。</span><span class="sxs-lookup"><span data-stu-id="1859e-132">The tool can deploy a loose file build of your app.</span></span> <span data-ttu-id="1859e-133">緩やかなファイル ビルドについて詳しくは、「[/api/app/packagemanager/register](wdp-loose-folder-register-api.md)」リファレンス トピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1859e-133">For more information about loose file builds, see the [/api/app/packagemanager/register](wdp-loose-folder-register-api.md) reference topic.</span></span>
 - <span data-ttu-id="1859e-134">コンソールの開発者ファイルには、開発用 PC のエクスプローラーからアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="1859e-134">Developer files on your console can be accessed from File Explorer on your development PC.</span></span> <span data-ttu-id="1859e-135">エクスプローラーを介したファイルのアクセスについて詳しくは、「[/ext/smb/developerfolder](wdp-smb-api.md)」リファレンス トピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1859e-135">For more information about accessing files through File Explorer, see the [/ext/smb/developerfolder](wdp-smb-api.md) reference topic.</span></span>

## <a name="see-also"></a><span data-ttu-id="1859e-136">関連項目</span><span class="sxs-lookup"><span data-stu-id="1859e-136">See also</span></span>
- [<span data-ttu-id="1859e-137">既知の問題</span><span class="sxs-lookup"><span data-stu-id="1859e-137">Known issues</span></span>](known-issues.md)
- [<span data-ttu-id="1859e-138">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="1859e-138">UWP on Xbox One</span></span>](index.md)
