---
author: v-angraf
title: Xbox One の UWP の新着情報
description: Xbox One の UWP アプリの新機能について説明します。
ms.author: v-angraf
ms.date: 03/29/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: fe63c527-8f06-43a5-868f-de909f5664b3
ms.localizationpriority: medium
ms.openlocfilehash: cbabe9d31b5b9762320df8e4a92d19ae4e33497d
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "301456"
---
# <a name="whats-new-for-developers-in-the-latest-update-of-uwp-on-xbox-one"></a><span data-ttu-id="3a775-104">Xbox One の UWP の最新の更新プログラムにおける開発者向け新着情報</span><span class="sxs-lookup"><span data-stu-id="3a775-104">What's new for developers in the latest update of UWP on Xbox One</span></span>

<span data-ttu-id="3a775-105">最新の更新プログラムどこからでも Windows プラットフォーム (UWP) Xbox 1 つ上にはには、次の新機能更新を既存の機能、バグの修正などにはが含まれています。</span><span class="sxs-lookup"><span data-stu-id="3a775-105">The latest update of Universal Windows Platform (UWP) on Xbox One contains the following new features, updates to existing features, and bug fixes.</span></span>

## <a name="x86-apps-and-games-are-no-longer-supported-on-xbox"></a><span data-ttu-id="3a775-106">x86 アプリとゲーム Xbox ではサポートされません。</span><span class="sxs-lookup"><span data-stu-id="3a775-106">x86 apps and games are no longer supported on Xbox</span></span>  
<span data-ttu-id="3a775-107">Xbox では、x86 アプリの開発または x86 アプリのストアへの申請をサポートしなくなりました。</span><span class="sxs-lookup"><span data-stu-id="3a775-107">Xbox no longer supports x86 app development or x86 app submissions to the store.</span></span>

## <a name="apps-can-now-support-navigating-back-to-the-previous-app"></a><span data-ttu-id="3a775-108">アプリが前アプリに移動をサポートできるようになりました</span><span class="sxs-lookup"><span data-stu-id="3a775-108">Apps can now support navigating back to the previous app</span></span> 
<span data-ttu-id="3a775-109">UWP の Xbox を 1 つのアプリでは、前のアプリケーションに戻ることができますなりました。</span><span class="sxs-lookup"><span data-stu-id="3a775-109">UWP on Xbox One apps can now support navigating back to the previous app.</span></span> <span data-ttu-id="3a775-110">これを行うには、 [**Windows.UI.Core.SystemNavigationManager.BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893595)イベントをサブスクライブし、 **false**イベント ハンドラーで**Handled**プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="3a775-110">To do this, subscribe to the [**Windows.UI.Core.SystemNavigationManager.BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893595) event and set the **Handled** property to **false** in your event handler.</span></span>

> [!NOTE]
> <span data-ttu-id="3a775-111">互換性のために、この機能を使用できるの UWP Xbox 1 つ上の最新リリースに組み込まれているアプリのみです。</span><span class="sxs-lookup"><span data-stu-id="3a775-111">For compatibility reasons, this functionality is available only to apps that are built with the most recent release of UWP on Xbox One.</span></span> 

## <a name="dev-home-is-now-the-default-home-experience-on-development-consoles"></a><span data-ttu-id="3a775-112">開発ホームが、既定のホーム エクスペリエンス開発コンソール</span><span class="sxs-lookup"><span data-stu-id="3a775-112">Dev Home is now the default home experience on development consoles</span></span>
<span data-ttu-id="3a775-113">開発コンソールとして、既定のホーム エクスペリエンス Dev ホームを起動します。</span><span class="sxs-lookup"><span data-stu-id="3a775-113">Development consoles now launch Dev Home as the default home experience.</span></span> <span data-ttu-id="3a775-114">これにより、販売のホーム画面から順にクリックする必要はありません。 作業を簡単に見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="3a775-114">This lets you get right to work without the need to click through from the retail Home screen.</span></span> <span data-ttu-id="3a775-115">開発ホームには、販売のホーム画面を起動するクイック操作が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3a775-115">Dev Home now includes a quick action to launch the retail Home screen.</span></span> <span data-ttu-id="3a775-116">また、新しい設定を使用すると、既定の動作を小売ホームことできます。</span><span class="sxs-lookup"><span data-stu-id="3a775-116">Also, a new setting allows you to make retail Home the default experience.</span></span> 

## <a name="new-dev-home-user-interface"></a><span data-ttu-id="3a775-117">新しい開発ホーム ユーザー インターフェイス</span><span class="sxs-lookup"><span data-stu-id="3a775-117">New Dev Home user interface</span></span>
<span data-ttu-id="3a775-118">開発ホーム ユーザー インターフェイスでは、次の生産性の向上できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="3a775-118">The Dev Home user interface now includes the following productivity enhancements:</span></span>
 - <span data-ttu-id="3a775-119">IP アドレス重要なデータを見やすくするための画面の上部にある回復のバージョンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3a775-119">Important data like IP address and recovery version is now displayed at the top of the screen for visibility.</span></span> 
 - <span data-ttu-id="3a775-120">開発ホームのタブ表示の UI 論理セットにツールをグループ化されているクイック操作するようになりました。</span><span class="sxs-lookup"><span data-stu-id="3a775-120">Dev Home now has a tabbed UI that groups tools into logical sets, allowing quick navigation.</span></span>
 - <span data-ttu-id="3a775-121">開発ホームの最初のタブにクイック アクション ボタンは、最も頻繁に使われるアクションにすばやくアクセスを使用します。</span><span class="sxs-lookup"><span data-stu-id="3a775-121">Quick-action buttons on the first tab of Dev Home allow fast access to the most commonly used actions.</span></span> 

## <a name="wdp-for-xbox-enhancements"></a><span data-ttu-id="3a775-122">Xbox の機能強化 WDP</span><span class="sxs-lookup"><span data-stu-id="3a775-122">WDP for Xbox enhancements</span></span>
<span data-ttu-id="3a775-123">Windows デバイス ポータル (WDP) には、コンソール設定の追加のサポートが含まれています。</span><span class="sxs-lookup"><span data-stu-id="3a775-123">The Windows Device Portal (WDP) now includes additional support for console settings.</span></span> 

## <a name="you-can-now-switch-the-type-of-your-uwp-title-between-app-and-game"></a><span data-ttu-id="3a775-124">"App"と「ゲーム」の UWP タイトルの種類を切り替えることができるようになりました</span><span class="sxs-lookup"><span data-stu-id="3a775-124">You can now switch the type of your UWP title between "App" and "Game"</span></span>
<span data-ttu-id="3a775-125">"App"と「ゲーム」の UWP タイトルの種類の移行するには、ストアに公開せずにゲームのシナリオをテストすることができます。</span><span class="sxs-lookup"><span data-stu-id="3a775-125">Switching the type of your UWP title between "App" and "Game" allows you to test game scenarios without publishing to the store.</span></span> <span data-ttu-id="3a775-126">開発ホーム]、[は、**ゲームとアプリ**のウィンドウで、アプリを選びます、コント ローラーの表示] ボタンを押して、[**アプリの詳細**を選択し、「アプリ」または「ゲーム」の種類を変更します。</span><span class="sxs-lookup"><span data-stu-id="3a775-126">In Dev Home, select the app in the **Games & Apps** pane, press the View button on the controller, select **App details** and then change the type to "App" or "Game".</span></span>

## <a name="see-also"></a><span data-ttu-id="3a775-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="3a775-127">See also</span></span>
- [<span data-ttu-id="3a775-128">既知の問題</span><span class="sxs-lookup"><span data-stu-id="3a775-128">Known issues</span></span>](known-issues.md)
- [<span data-ttu-id="3a775-129">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="3a775-129">UWP on Xbox One</span></span>](index.md)
 - <span data-ttu-id="3a775-130">コンソールのスクリーンショットをキャプチャできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="3a775-130">You can now capture a screenshot of the console.</span></span> <span data-ttu-id="3a775-131">スクリーンショットのキャプチャについて詳しくは、「[/ext/screenshot](wdp-media-capture-api.md)」リファレンス トピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a775-131">For more information about taking a screenshot, see the [/ext/screenshot](wdp-media-capture-api.md) reference topic.</span></span>
 - <span data-ttu-id="3a775-132">このツールでは、アプリの緩やかなファイル ビルドを展開できます。</span><span class="sxs-lookup"><span data-stu-id="3a775-132">The tool can deploy a loose file build of your app.</span></span> <span data-ttu-id="3a775-133">緩やかなファイル ビルドについて詳しくは、「[/api/app/packagemanager/register](wdp-loose-folder-register-api.md)」リファレンス トピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a775-133">For more information about loose file builds, see the [/api/app/packagemanager/register](wdp-loose-folder-register-api.md) reference topic.</span></span>
 - <span data-ttu-id="3a775-134">コンソールの開発者ファイルには、開発用 PC のエクスプローラーからアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="3a775-134">Developer files on your console can be accessed from File Explorer on your development PC.</span></span> <span data-ttu-id="3a775-135">エクスプローラーを介したファイルのアクセスについて詳しくは、「[/ext/smb/developerfolder](wdp-smb-api.md)」リファレンス トピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a775-135">For more information about accessing files through File Explorer, see the [/ext/smb/developerfolder](wdp-smb-api.md) reference topic.</span></span>

## <a name="see-also"></a><span data-ttu-id="3a775-136">関連項目</span><span class="sxs-lookup"><span data-stu-id="3a775-136">See also</span></span>
- [<span data-ttu-id="3a775-137">既知の問題</span><span class="sxs-lookup"><span data-stu-id="3a775-137">Known issues</span></span>](known-issues.md)
- [<span data-ttu-id="3a775-138">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="3a775-138">UWP on Xbox One</span></span>](index.md)
