---
author: anbare
Description: "UWP アプリでセカンダリ タイルを使用する必要がある場合について説明します。"
title: "セカンダリ タイル"
label: Secondary tiles
template: detail.hbs
ms.author: wdg-dev-content
ms.date: 05/25/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP、セカンダリ タイル、ガイダンス、ガイドライン、ベスト プラクティス"
ms.openlocfilehash: 8836dfbcd96de52aa08b25c767cc413aee1d8ac8
ms.sourcegitcommit: 6396a69aab081f5c7a9a59739c83538616d3b1c7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/30/2017
---
# <a name="secondary-tile-guidance"></a><span data-ttu-id="bac74-104">セカンダリ タイルのガイダンス</span><span class="sxs-lookup"><span data-stu-id="bac74-104">Secondary tile guidance</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="bac74-105">セカンダリ タイルを使うと、スタート メニューからアプリ内の特定の領域に、一貫した方法で効率的に直接アクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="bac74-105">A secondary tile provides a consistent, efficient way for users to directly access specific areas within an app from the Start menu.</span></span> <span data-ttu-id="bac74-106">ユーザーはセカンダリ タイルをスタート メニューに "ピン留め" するかどうかを選択できますが、アプリ内のピン留めできる領域は開発者によって決められます。</span><span class="sxs-lookup"><span data-stu-id="bac74-106">Although a user chooses whether or not to "pin" a secondary tile to the Start menu, the pinnable areas in an app are determined by the developer.</span></span> <span data-ttu-id="bac74-107">詳しくは、「[セカンダリ タイルの概要](tiles-and-notifications-secondary-tiles.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bac74-107">For a more detailed summary, see [Secondary tiles overview](tiles-and-notifications-secondary-tiles.md).</span></span> <span data-ttu-id="bac74-108">アプリでセカンダリ タイルを有効にし、関連する UI を設計するときは、次のガイドラインを考慮してください。</span><span class="sxs-lookup"><span data-stu-id="bac74-108">Consider these guidelines when you enable secondary tiles and design the associated UI in your app.</span></span>

> [!NOTE]
> <span data-ttu-id="bac74-109">セカンダリ タイルをスタート メニューにピン留めできるのはユーザーだけです。アプリでプログラムによってピン留めすることはできません。</span><span class="sxs-lookup"><span data-stu-id="bac74-109">Only users can pin a secondary tile to the Start menu; apps can't programmatically pin secondary tiles.</span></span> <span data-ttu-id="bac74-110">タイルの削除もユーザーがコントロールし、セカンダリ タイルをスタート メニューや親アプリ内から削除することができます。</span><span class="sxs-lookup"><span data-stu-id="bac74-110">Users also control tile removal, and can remove a secondary tile from the Start menu or from within the parent app.</span></span>


## <a name="recommendations"></a><span data-ttu-id="bac74-111">推奨事項</span><span class="sxs-lookup"><span data-stu-id="bac74-111">Recommendations</span></span>

<span data-ttu-id="bac74-112">アプリでセカンダリ タイルを有効にするときは、以下の推奨事項を考慮してください。</span><span class="sxs-lookup"><span data-stu-id="bac74-112">Consider the following recommendations when enabling secondary tiles in your app:</span></span>

* <span data-ttu-id="bac74-113">対象のコンテンツがピン留めできる場合は、セカンダリ タイルを作る [スタートにピン留めする] ボタンをアプリ バーに表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bac74-113">When the content in focus is pinnable, the app bar should contain a "Pin to Start" button to create a secondary tile for the user.</span></span>
* <span data-ttu-id="bac74-114">ユーザーが [スタートにピン留めする] をクリックした場合、UI スレッドから直ちに API を呼び出して、[セカンダリ タイルをピン留め](tiles-and-notifications-secondary-tiles-pinning.md)する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bac74-114">When the user clicks "Pin to Start", you should immediately call the API from the UI thread to [pin the secondary tile](tiles-and-notifications-secondary-tiles-pinning.md).</span></span>
* <span data-ttu-id="bac74-115">対象のコンテンツが既にピン留めされている場合は、アプリ バーの [スタートにピン留めする] ボタンを [スタートからピン留めを外す] ボタンに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="bac74-115">If the content in focus is already pinned, replace the "Pin to Start" button on the app bar with an "Unpin from Start" button.</span></span> <span data-ttu-id="bac74-116">[スタートからピン留めを外す] ボタンは、既存のセカンダリ タイルを削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bac74-116">The "Unpin from Start" button should remove the existing secondary tile.</span></span>
* <span data-ttu-id="bac74-117">対象のコンテンツがピン留めできない場合は、[スタートにピン留めする] ボタンを表示しません (または、[スタートにピン留めする] ボタンを無効にします)。</span><span class="sxs-lookup"><span data-stu-id="bac74-117">When the content in focus is not pinnable, don't show a "Pin to Start" button (or show a disabled "Pin to Start" button).</span></span>
* <span data-ttu-id="bac74-118">[スタートにピン留めする] ボタンと [スタートからピン留めを外す] ボタンには、システムが提供するグリフを使います (Windows.UI.Xaml.Controls.Symbol または WinJS.UI.AppBarIcon のピン留めとピン止め解除のメンバーをご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="bac74-118">Use the system-provided glyphs for your "Pin to Start" and "Unpin from Start" buttons (see the pin and unpin members in Windows.UI.Xaml.Controls.Symbol or WinJS.UI.AppBarIcon).</span></span>
* <span data-ttu-id="bac74-119">ボタンのテキストは標準の "スタートにピン留めする" と "スタートからピン留めを外す" を使います。</span><span class="sxs-lookup"><span data-stu-id="bac74-119">Use the standard button text: "Pin to Start" and "Unpin from Start".</span></span> <span data-ttu-id="bac74-120">システムによって提供されるピン留めとピン留め解除のグリフを使うときは、既定のテキストをオーバーライドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="bac74-120">You'll have to override the default text when using the system-provided pin and unpin glyphs.</span></span>
* <span data-ttu-id="bac74-121">"次のトラックにスキップ" タイルのように、親アプリと対話するための、事実上のコマンド ボタンとしてセカンダリ タイルを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="bac74-121">Don't use a secondary tile as a virtual command button to interact with the parent app, such as a "skip to next track" tile.</span></span>


## <a name="additional-usage-guidance-for-devs"></a><span data-ttu-id="bac74-122">開発者向けのその他の使い方のガイダンス</span><span class="sxs-lookup"><span data-stu-id="bac74-122">Additional usage guidance for devs</span></span>

* <span data-ttu-id="bac74-123">アプリの起動時には、常にセカンダリ タイルを列挙する必要があります。セカンダリ タイルの追加や削除を把握していない場合があるためです。</span><span class="sxs-lookup"><span data-stu-id="bac74-123">When an app launches, it should always enumerate its secondary tiles, in case there were any additions or deletions of which it was unaware.</span></span> <span data-ttu-id="bac74-124">スタート画面のアプリ バーを使ってセカンダリ タイルを削除すると、タイトルも削除されます。</span><span class="sxs-lookup"><span data-stu-id="bac74-124">When a secondary tile is deleted through the Start screen app bar, Windows simply removes the tile.</span></span> <span data-ttu-id="bac74-125">セカンダリ タイルによって使われていたリソースは、アプリ自体で解放する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bac74-125">The app itself is responsible for releasing any resources that were used by the secondary tile.</span></span> <span data-ttu-id="bac74-126">クラウドを通じてセカンダリ タイルがコピーされた場合、セカンダリ タイル上のタイルまたはバッジの現在の通知、スケジュールされた通知、プッシュ通知チャネル、定期的な通知で使われる URI (Uniform Resource Identifier) はタイルと共にコピーされないので、再設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bac74-126">When secondary tiles are copied through the cloud, current tile or badge notifications on the secondary tile, scheduled notifications, push notification channels, and Uniform Resource Identifiers (URIs) used with periodic notifications are not copied with the secondary tile and must be set up again.</span></span>
* <span data-ttu-id="bac74-127">アプリでは、セカンダリ タイルに意味のある再作成可能な一意の ID を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="bac74-127">An app should use meaningful, re-creatable, unique IDs for secondary tiles.</span></span> <span data-ttu-id="bac74-128">アプリにとって意味のある予測可能なセカンダリ タイル ID を使うことにより、新しいコンピューターの新規インストールでセカンダリ タイルが表示されたときに、アプリはそれらのタイルで実行する処理を判断できるようになります。</span><span class="sxs-lookup"><span data-stu-id="bac74-128">Using predictable secondary tile IDs that are meaningful to an app helps the app understand what to do with these tiles when they are seen in a fresh installation on a new computer.</span></span>
  * <span data-ttu-id="bac74-129">実行時に、アプリは特定のタイルが存在するかどうかを照会できます。</span><span class="sxs-lookup"><span data-stu-id="bac74-129">At runtime, the app can query whether a specific tile exists.</span></span>
  * <span data-ttu-id="bac74-130">セカンダリ タイルのプラットフォームに、特定のアプリに属するすべてのセカンダリ タイルのセットを返すよう要求できます。</span><span class="sxs-lookup"><span data-stu-id="bac74-130">The secondary tile platform can be asked to return the set of all secondary tiles belonging to a specific app.</span></span> <span data-ttu-id="bac74-131">これらのタイルに意味のある一意の ID を使うことにより、アプリはセカンダリ タイルのセットを調べ、適切なアクションを実行できます。</span><span class="sxs-lookup"><span data-stu-id="bac74-131">Using meaningful, unique IDs for these tiles can help the app examine the set of secondary tiles and perform appropriate actions.</span></span> <span data-ttu-id="bac74-132">たとえば、ソーシャル メディア アプリの場合、ID によってタイルの作成対象である個々の連絡先を識別できます。</span><span class="sxs-lookup"><span data-stu-id="bac74-132">For instance, for a social media app, IDs could identify individual contacts for whom tiles were created.</span></span>
* <span data-ttu-id="bac74-133">スタート画面のすべてのタイルと同様に、セカンダリ タイルは新しいコンテンツで頻繁に更新できる動的な表示機能です。</span><span class="sxs-lookup"><span data-stu-id="bac74-133">Secondary tiles, like all tiles on the Start screen, are dynamic outlets that can be frequently updated with new content.</span></span> <span data-ttu-id="bac74-134">セカンダリ タイルでは、他のタイルと同じメカニズムを使って通知や最新情報を表示できます。</span><span class="sxs-lookup"><span data-stu-id="bac74-134">Secondary tiles can surface notifications and updates by using the same mechanisms as any other tile.</span></span> <span data-ttu-id="bac74-135">詳しくは、「[通知配信方法の選択](tiles-and-notifications-choosing-a-notification-delivery-method.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bac74-135">See [Choose a notification delivery method](tiles-and-notifications-choosing-a-notification-delivery-method.md) to learn more.</span></span>


## <a name="related"></a><span data-ttu-id="bac74-136">関連</span><span class="sxs-lookup"><span data-stu-id="bac74-136">Related</span></span>

* [<span data-ttu-id="bac74-137">セカンダリ タイルの概要</span><span class="sxs-lookup"><span data-stu-id="bac74-137">Secondary tiles overview</span></span>](tiles-and-notifications-secondary-tiles.md)
* [<span data-ttu-id="bac74-138">セカンダリ タイルをピン留めする</span><span class="sxs-lookup"><span data-stu-id="bac74-138">Pin secondary tiles</span></span>](tiles-and-notifications-secondary-tiles-pinning.md)
* [<span data-ttu-id="bac74-139">タイル アセット</span><span class="sxs-lookup"><span data-stu-id="bac74-139">Tile assets</span></span>](tiles-and-notifications-app-assets.md)
* [<span data-ttu-id="bac74-140">タイル コンテンツのドキュメント</span><span class="sxs-lookup"><span data-stu-id="bac74-140">Tile content documentation</span></span>](tiles-and-notifications-create-adaptive-tiles.md)
* [<span data-ttu-id="bac74-141">ローカル タイル通知の送信</span><span class="sxs-lookup"><span data-stu-id="bac74-141">Send a local tile notification</span></span>](tiles-and-notifications-sending-a-local-tile-notification.md)