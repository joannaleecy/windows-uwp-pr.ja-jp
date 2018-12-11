---
title: Xbox One の UWP の新着情報
description: Xbox One の UWP アプリの新機能について説明します。
ms.date: 03/29/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: fe63c527-8f06-43a5-868f-de909f5664b3
ms.localizationpriority: medium
ms.openlocfilehash: aff65e5f1b4771cbb33bc8b8219224042b7bf7e2
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8890529"
---
# <a name="whats-new-for-developers-in-the-latest-update-of-uwp-on-xbox-one"></a><span data-ttu-id="acaa5-104">Xbox One の UWP の最新の更新プログラムにおける開発者向け新着情報</span><span class="sxs-lookup"><span data-stu-id="acaa5-104">What's new for developers in the latest update of UWP on Xbox One</span></span>

<span data-ttu-id="acaa5-105">最新の更新プログラム ユニバーサル Windows プラットフォーム (UWP) Xbox One でにはは、次の新機能、既存の機能やバグ修正する更新プログラムが含まれます。</span><span class="sxs-lookup"><span data-stu-id="acaa5-105">The latest update of Universal Windows Platform (UWP) on Xbox One contains the following new features, updates to existing features, and bug fixes.</span></span>

## <a name="x86-apps-and-games-are-no-longer-supported-on-xbox"></a><span data-ttu-id="acaa5-106">x86 アプリとゲームが Xbox でサポートされていません</span><span class="sxs-lookup"><span data-stu-id="acaa5-106">x86 apps and games are no longer supported on Xbox</span></span>  
<span data-ttu-id="acaa5-107">Xbox では、x86 アプリの開発または x86 アプリのストアへの申請をサポートしなくなりました。</span><span class="sxs-lookup"><span data-stu-id="acaa5-107">Xbox no longer supports x86 app development or x86 app submissions to the store.</span></span>

## <a name="apps-can-now-support-navigating-back-to-the-previous-app"></a><span data-ttu-id="acaa5-108">アプリが以前のアプリに戻る移動をサポートできますできるようになりました</span><span class="sxs-lookup"><span data-stu-id="acaa5-108">Apps can now support navigating back to the previous app</span></span> 
<span data-ttu-id="acaa5-109">アプリが Xbox One の UWP では、前のアプリに戻る移動をサポートできますできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="acaa5-109">UWP on Xbox One apps can now support navigating back to the previous app.</span></span> <span data-ttu-id="acaa5-110">これを行うには、 [**Windows.UI.Core.SystemNavigationManager.BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893595)イベントをサブスクライブし、 **false**イベント ハンドラーで**Handled**プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="acaa5-110">To do this, subscribe to the [**Windows.UI.Core.SystemNavigationManager.BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893595) event and set the **Handled** property to **false** in your event handler.</span></span>

> [!NOTE]
> <span data-ttu-id="acaa5-111">互換性の理由から、この機能は、Xbox One の UWP の最新リリースに組み込まれているアプリでのみ利用可能です。</span><span class="sxs-lookup"><span data-stu-id="acaa5-111">For compatibility reasons, this functionality is available only to apps that are built with the most recent release of UWP on Xbox One.</span></span> 

## <a name="dev-home-is-now-the-default-home-experience-on-development-consoles"></a><span data-ttu-id="acaa5-112">Dev Home は開発コンソールで既定のホーム エクスペリエンスができるようになりました。</span><span class="sxs-lookup"><span data-stu-id="acaa5-112">Dev Home is now the default home experience on development consoles</span></span>
<span data-ttu-id="acaa5-113">今すぐ開発コンソールは既定のホーム エクスペリエンスとして Dev Home を起動します。</span><span class="sxs-lookup"><span data-stu-id="acaa5-113">Development consoles now launch Dev Home as the default home experience.</span></span> <span data-ttu-id="acaa5-114">これにより、製品版ホーム画面からクリックスルーすることがなく動作する適切なできます。</span><span class="sxs-lookup"><span data-stu-id="acaa5-114">This lets you get right to work without the need to click through from the retail Home screen.</span></span> <span data-ttu-id="acaa5-115">Dev Home には、製品版ホーム画面を起動するクイック アクションが含まれています。</span><span class="sxs-lookup"><span data-stu-id="acaa5-115">Dev Home now includes a quick action to launch the retail Home screen.</span></span> <span data-ttu-id="acaa5-116">また、新しい設定には、既定のエクスペリエンスを小売ホームようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="acaa5-116">Also, a new setting allows you to make retail Home the default experience.</span></span> 

## <a name="new-dev-home-user-interface"></a><span data-ttu-id="acaa5-117">Dev Home の新しいユーザー インターフェイス</span><span class="sxs-lookup"><span data-stu-id="acaa5-117">New Dev Home user interface</span></span>
<span data-ttu-id="acaa5-118">Dev Home のユーザー インターフェイスには、次の生産性の向上にはできるようになりましたが含まれています。</span><span class="sxs-lookup"><span data-stu-id="acaa5-118">The Dev Home user interface now includes the following productivity enhancements:</span></span>
 - <span data-ttu-id="acaa5-119">重要なデータなどの IP アドレスと、表示用に、画面の上部に回復のバージョンが表示されるようになりました。</span><span class="sxs-lookup"><span data-stu-id="acaa5-119">Important data like IP address and recovery version is now displayed at the top of the screen for visibility.</span></span> 
 - <span data-ttu-id="acaa5-120">Dev Home は、タブ UI 論理セットにツールをグループ化されているすばやいナビゲーションを許可するようになりました。</span><span class="sxs-lookup"><span data-stu-id="acaa5-120">Dev Home now has a tabbed UI that groups tools into logical sets, allowing quick navigation.</span></span>
 - <span data-ttu-id="acaa5-121">Dev Home の最初のタブのクイック アクション ボタンは、最もよく使われる操作を高速アクセスを許可します。</span><span class="sxs-lookup"><span data-stu-id="acaa5-121">Quick-action buttons on the first tab of Dev Home allow fast access to the most commonly used actions.</span></span> 

## <a name="wdp-for-xbox-enhancements"></a><span data-ttu-id="acaa5-122">Xbox の機能強化 WDP</span><span class="sxs-lookup"><span data-stu-id="acaa5-122">WDP for Xbox enhancements</span></span>
<span data-ttu-id="acaa5-123">Windows Device Portal (WDP) には、コンソールの設定の追加のサポートが含まれています。</span><span class="sxs-lookup"><span data-stu-id="acaa5-123">The Windows Device Portal (WDP) now includes additional support for console settings.</span></span> 

## <a name="you-can-now-switch-the-type-of-your-uwp-title-between-app-and-game"></a><span data-ttu-id="acaa5-124">ここで、"App"と「ゲーム」の間で UWP タイトルの種類を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="acaa5-124">You can now switch the type of your UWP title between "App" and "Game"</span></span>
<span data-ttu-id="acaa5-125">"App"と「ゲーム」の間で UWP タイトルの種類を切り替えるには、ストアに公開することがなくゲーム シナリオをテストすることができます。</span><span class="sxs-lookup"><span data-stu-id="acaa5-125">Switching the type of your UWP title between "App" and "Game" allows you to test game scenarios without publishing to the store.</span></span> <span data-ttu-id="acaa5-126">Dev Home で**ゲームとアプリ**のウィンドウで、アプリを選択、コント ローラーのビュー ボタンを押して**アプリの詳細**を選択し、種類を"App"または"Game"に変更します。</span><span class="sxs-lookup"><span data-stu-id="acaa5-126">In Dev Home, select the app in the **Games & Apps** pane, press the View button on the controller, select **App details** and then change the type to "App" or "Game".</span></span>

## <a name="see-also"></a><span data-ttu-id="acaa5-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="acaa5-127">See also</span></span>
- [<span data-ttu-id="acaa5-128">既知の問題</span><span class="sxs-lookup"><span data-stu-id="acaa5-128">Known issues</span></span>](known-issues.md)
- [<span data-ttu-id="acaa5-129">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="acaa5-129">UWP on Xbox One</span></span>](index.md)
 - <span data-ttu-id="acaa5-130">コンソールのスクリーンショットをキャプチャできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="acaa5-130">You can now capture a screenshot of the console.</span></span> <span data-ttu-id="acaa5-131">スクリーンショットのキャプチャについて詳しくは、「[/ext/screenshot](wdp-media-capture-api.md)」リファレンス トピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="acaa5-131">For more information about taking a screenshot, see the [/ext/screenshot](wdp-media-capture-api.md) reference topic.</span></span>
 - <span data-ttu-id="acaa5-132">このツールでは、アプリの緩やかなファイル ビルドを展開できます。</span><span class="sxs-lookup"><span data-stu-id="acaa5-132">The tool can deploy a loose file build of your app.</span></span> <span data-ttu-id="acaa5-133">緩やかなファイル ビルドについて詳しくは、「[/api/app/packagemanager/register](wdp-loose-folder-register-api.md)」リファレンス トピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="acaa5-133">For more information about loose file builds, see the [/api/app/packagemanager/register](wdp-loose-folder-register-api.md) reference topic.</span></span>
 - <span data-ttu-id="acaa5-134">コンソールの開発者ファイルには、開発用 PC のエクスプローラーからアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="acaa5-134">Developer files on your console can be accessed from File Explorer on your development PC.</span></span> <span data-ttu-id="acaa5-135">エクスプローラーを介したファイルのアクセスについて詳しくは、「[/ext/smb/developerfolder](wdp-smb-api.md)」リファレンス トピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="acaa5-135">For more information about accessing files through File Explorer, see the [/ext/smb/developerfolder](wdp-smb-api.md) reference topic.</span></span>

## <a name="see-also"></a><span data-ttu-id="acaa5-136">関連項目</span><span class="sxs-lookup"><span data-stu-id="acaa5-136">See also</span></span>
- [<span data-ttu-id="acaa5-137">既知の問題</span><span class="sxs-lookup"><span data-stu-id="acaa5-137">Known issues</span></span>](known-issues.md)
- [<span data-ttu-id="acaa5-138">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="acaa5-138">UWP on Xbox One</span></span>](index.md)
