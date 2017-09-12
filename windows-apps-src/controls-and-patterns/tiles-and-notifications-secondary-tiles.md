---
author: anbare
Description: "セカンダリ タイルを使うと、ユーザーは特定のコンテンツやディープ リンクをアプリからスタート メニューにピン留めできます。これにより、その後はアプリ内の特定のコンテンツに簡単にアクセスできます。"
title: "セカンダリ タイル"
label: Secondary tiles
template: detail.hbs
ms.author: wdg-dev-content
ms.date: 05/25/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, セカンダリ タイル"
ms.openlocfilehash: b5f81f27c1e042f45882f026ff6d20e0e5f5456b
ms.sourcegitcommit: 6396a69aab081f5c7a9a59739c83538616d3b1c7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/30/2017
---
# <a name="secondary-tiles"></a><span data-ttu-id="e65f9-104">セカンダリ タイル</span><span class="sxs-lookup"><span data-stu-id="e65f9-104">Secondary tiles</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="e65f9-105">セカンダリ タイルを使うと、ユーザーは特定のコンテンツやディープ リンクをアプリからスタート メニューにピン留めできます。これにより、その後はアプリ内の特定のコンテンツに簡単にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-105">Secondary tiles allow users to pin specific content and deep links from your app onto their Start menu, providing easy future access to the content within your app.</span></span>

![セカンダリ タイルのスクリーン ショット](images/secondarytiles.png)

<span data-ttu-id="e65f9-107">たとえば、ユーザーは、さまざまな特定の場所の天気をスタート メニューにピン留めできます。これにより、(1) ライブ タイルを使って、容易にひとめでわかる最新の天気の情報を表示でき、(2) 詳しく知りたい特定の都市の天気にすばやくアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-107">For example, users can pin the weather for numerous specific locations on their Start menu, which provides (1) easy live glanceable information about the current weather thanks to Live Tiles, and (2) a quick entry point to the specific city's weather they care about.</span></span> <span data-ttu-id="e65f9-108">ユーザーは、特定の株価情報、ニュース記事、およびその他の必要なアイテムもピン留めできます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-108">Users can also pin specific stocks, news articles, and more items that are important to them.</span></span>

<span data-ttu-id="e65f9-109">アプリにセカンダリ タイルを追加すると、すばやく効率的にユーザーとの再エンゲージメントを行えます。セカンダリ タイルによる容易なアクセスのため、より高い頻度でのアプリの再利用を促すことができます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-109">By adding secondary tiles to your app, you help the user re-engage quickly and efficiently with your app, encouraging them to return more often thanks to the easy access that secondary tiles provides.</span></span>

<span data-ttu-id="e65f9-110">**セカンダリ タイルをピン留めできるのはユーザーだけです。アプリでプログラムによってユーザーの承認なくピン留めすることはできません**。</span><span class="sxs-lookup"><span data-stu-id="e65f9-110">**Only users can pin a secondary tile; apps cannot pin secondary tiles programmatically without user approval**.</span></span> <span data-ttu-id="e65f9-111">ユーザーは明示的にアプリ内から "ピン留め" ボタンをクリックする必要があります。これにより、API を使ってセカンダリ タイルの作成を要求します。システムによりダイアログ ボックスが表示され、ユーザーはタイルのピン留めの確認を求められます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-111">The user must explicitly click a "Pin" button within your app, at which point you then use the API to request to create a secondary tile, and then the system displays a dialog box asking the user to confirm whether they would like the tile pinned.</span></span>

## <a name="quick-links"></a><span data-ttu-id="e65f9-112">クイック リンク</span><span class="sxs-lookup"><span data-stu-id="e65f9-112">Quick links</span></span>

| <span data-ttu-id="e65f9-113">記事</span><span class="sxs-lookup"><span data-stu-id="e65f9-113">Article</span></span> | <span data-ttu-id="e65f9-114">説明</span><span class="sxs-lookup"><span data-stu-id="e65f9-114">Description</span></span> |
| --- | --- |
| [<span data-ttu-id="e65f9-115">セカンダリ タイルのガイダンス</span><span class="sxs-lookup"><span data-stu-id="e65f9-115">Guidance on secondary tiles</span></span>](tiles-and-notifications-secondary-tiles-guidance.md) | <span data-ttu-id="e65f9-116">セカンダリ タイルを使用する必要がある場合について説明します。</span><span class="sxs-lookup"><span data-stu-id="e65f9-116">Learn about when and where you should use secondary tiles.</span></span> |
| [<span data-ttu-id="e65f9-117">セカンダリ タイルをピン留めする</span><span class="sxs-lookup"><span data-stu-id="e65f9-117">Pin secondary tiles</span></span>](tiles-and-notifications-secondary-tiles-pinning.md) | <span data-ttu-id="e65f9-118">セカンダリ タイルをピン留めする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e65f9-118">Learn how to pin a secondary tile.</span></span> |
| [<span data-ttu-id="e65f9-119">デスクトップ アプリケーションからピン留めする</span><span class="sxs-lookup"><span data-stu-id="e65f9-119">Pin from desktop application</span></span>](tiles-and-notifications-secondary-tiles-desktop-pinning.md) | <span data-ttu-id="e65f9-120">Windows デスクトップ アプリケーションでは、デスクトップ ブリッジを利用して、セカンダリ タイルをピン留めできます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-120">Windows desktop applications can pin secondary tiles thanks to the Desktop Bridge!</span></span> |


## <a name="secondary-tiles-in-relation-to-primary-tiles"></a><span data-ttu-id="e65f9-121">セカンダリ タイルとプライマリ タイルの関係</span><span class="sxs-lookup"><span data-stu-id="e65f9-121">Secondary tiles in relation to primary tiles</span></span>

<span data-ttu-id="e65f9-122">セカンダリ タイルは、1 つの親アプリに関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-122">Secondary tiles are associated with a single parent app.</span></span> <span data-ttu-id="e65f9-123">ユーザーは、セカンダリ タイルをスタート メニューにピン留めしておくことで、よく使う親アプリの領域を一貫した方法で効率的に直接起動できます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-123">They are pinned to the Start menu to provide a user with a consistent and efficient way to launch directly into a frequently used area of the parent app.</span></span> <span data-ttu-id="e65f9-124">対象となる領域は、頻繁に更新されるコンテンツを含んだ親アプリの総合サブセクションか、またはアプリの特定の領域へのディープ リンクです。</span><span class="sxs-lookup"><span data-stu-id="e65f9-124">This can be either a general subsection of the parent app that contains frequently updated content, or a deep link to a specific area in the app.</span></span>

<span data-ttu-id="e65f9-125">セカンダリ タイルを使うシナリオには次のようなものがあります。</span><span class="sxs-lookup"><span data-stu-id="e65f9-125">Examples of secondary tile scenarios include:</span></span>

* <span data-ttu-id="e65f9-126">天気予報アプリでの特定の都市の天気予報の更新情報</span><span class="sxs-lookup"><span data-stu-id="e65f9-126">Weather updates for a specific city in a weather app</span></span>
* <span data-ttu-id="e65f9-127">カレンダー アプリでの予定イベントの要約</span><span class="sxs-lookup"><span data-stu-id="e65f9-127">A summary of upcoming events in a calendar app</span></span>
* <span data-ttu-id="e65f9-128">ソーシャル アプリでの大事な連絡先のステータスと更新情報</span><span class="sxs-lookup"><span data-stu-id="e65f9-128">Status and updates from an important contact in a social app</span></span>
* <span data-ttu-id="e65f9-129">RSS リーダーでの特定のフィード</span><span class="sxs-lookup"><span data-stu-id="e65f9-129">Specific feeds in an RSS reader</span></span>
* <span data-ttu-id="e65f9-130">音楽の再生リスト</span><span class="sxs-lookup"><span data-stu-id="e65f9-130">A music playlist</span></span>
* <span data-ttu-id="e65f9-131">ブログ</span><span class="sxs-lookup"><span data-stu-id="e65f9-131">A blog</span></span>

<span data-ttu-id="e65f9-132">ユーザーが注目しているコンテンツが頻繁に変更される場合も、セカンダリ タイルが役立ちます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-132">Any frequently changing content that a user wants to monitor is a good candidate for a secondary tile.</span></span> <span data-ttu-id="e65f9-133">セカンダリ タイルをピン留めすると、ユーザーはタイルから更新情報をひとめで確認できるようになるほか、タイルから親アプリを直接起動できます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-133">After the secondary tile is pinned, users can receive at-a-glance updates through the tile and use it to launch directly into the parent app.</span></span>

<span data-ttu-id="e65f9-134">セカンダリ タイルは多くの点でプライマリ タイルに似ています。</span><span class="sxs-lookup"><span data-stu-id="e65f9-134">Secondary tiles are similar to primary tiles in many ways:</span></span>

* <span data-ttu-id="e65f9-135">タイル通知を使用して、リッチ コンテンツを表示できます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-135">They use tile notifications to display rich content.</span></span>
* <span data-ttu-id="e65f9-136">既定のタイル コンテンツ用の 150 x 150 ピクセルのロゴを入れる必要があります。</span><span class="sxs-lookup"><span data-stu-id="e65f9-136">They must include a 150 x 150 pixel logo for the default tile content.</span></span>
* <span data-ttu-id="e65f9-137">オプションとして、より大きなタイル サイズを有効にするために他のロゴ サイズを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-137">They can optionally include the other logo sizes to enable larger tile sizes.</span></span>
* <span data-ttu-id="e65f9-138">通知とバッジを表示できます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-138">They can show notifications and badges.</span></span>
* <span data-ttu-id="e65f9-139">スタート メニューで並べ替えることができます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-139">They can be rearranged on the Start menu.</span></span>
* <span data-ttu-id="e65f9-140">アプリがアンインストールされると自動的に削除されます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-140">They are automatically deleted when the app is uninstalled.</span></span>
* <span data-ttu-id="e65f9-141">ロック画面に、バッジとロックの詳細情報テキストを表示できます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-141">Their badge and lock detailed status text can be shown on lock.</span></span>

<span data-ttu-id="e65f9-142">一方で、セカンダリ タイルにはプライマリ タイルと大きく異なる点があります。</span><span class="sxs-lookup"><span data-stu-id="e65f9-142">However, secondary tiles differ from primary tiles in some noticeable ways:</span></span>

* <span data-ttu-id="e65f9-143">ユーザーは親アプリを削除することなくいつでもセカンダリ タイルを削除できます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-143">Users can delete their secondary tiles at any time without deleting the parent app.</span></span>
* <span data-ttu-id="e65f9-144">セカンダリ タイルは実行時に作成できます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-144">Secondary tiles can be created at run time.</span></span> <span data-ttu-id="e65f9-145">アプリ タイルはインストール時にしか作成できません。</span><span class="sxs-lookup"><span data-stu-id="e65f9-145">App tiles can be created only during installation.</span></span>
* <span data-ttu-id="e65f9-146">セカンダリ タイルを追加する前に、ポップアップでユーザーへの確認が行われます。</span><span class="sxs-lookup"><span data-stu-id="e65f9-146">A flyout prompts the user for confirmation before adding a secondary tile.</span></span>
* <span data-ttu-id="e65f9-147">プログラムでユーザーへの要求を使ってロック画面にセカンダリ タイルを選択することはできません。</span><span class="sxs-lookup"><span data-stu-id="e65f9-147">They cannot be programmatically selected for the lock screen through a request to the user.</span></span> <span data-ttu-id="e65f9-148">セカンダリ タイルは、ユーザーが [PC 設定] の [パーソナル設定] ページを使って手動で追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e65f9-148">The user must manually add the the secondary tile through the Personalize page in PC Settings.</span></span>

<span data-ttu-id="e65f9-149">通知の送信のため、セカンダリ タイルで使われるタイル/バッジ アップデーターとプッシュ通知チャネル用に特定のメソッドが用意されています。</span><span class="sxs-lookup"><span data-stu-id="e65f9-149">For sending notifications, specific methods are provided for tile and badge updaters and push notification channels used with secondary tiles.</span></span> <span data-ttu-id="e65f9-150">これらは、プライマリ タイルで使われるバージョンと似ています。</span><span class="sxs-lookup"><span data-stu-id="e65f9-150">These parallel the versions used with primary tiles.</span></span> <span data-ttu-id="e65f9-151">たとえば、CreateBadgeUpdaterForApplication に対して CreateBadgeUpdaterForSecondaryTile があります。</span><span class="sxs-lookup"><span data-stu-id="e65f9-151">For instance, CreateBadgeUpdaterForApplication vs. CreateBadgeUpdaterForSecondaryTile.</span></span>


## <a name="guidance-on-secondary-tiles"></a><span data-ttu-id="e65f9-152">セカンダリ タイルのガイダンス</span><span class="sxs-lookup"><span data-stu-id="e65f9-152">Guidance on secondary tiles</span></span>
<span data-ttu-id="e65f9-153">セカンダリ タイルを使う場合についての説明や、その他の使用のガイダンスについては、「[セカンダリ タイルのガイダンス](tiles-and-notifications-secondary-tiles-guidance.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e65f9-153">To learn about when and where you should use secondary tiles, and other usage guidance, please see [Guidance on secondary tiles](tiles-and-notifications-secondary-tiles-guidance.md)</span></span>


## <a name="pinning-secondary-tiles"></a><span data-ttu-id="e65f9-154">セカンダリ タイルのピン留め</span><span class="sxs-lookup"><span data-stu-id="e65f9-154">Pinning secondary tiles</span></span>
<span data-ttu-id="e65f9-155">セカンダリ タイルをピン留めする方法については、「[セカンダリ タイルをピン留めする](tiles-and-notifications-secondary-tiles-pinning.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e65f9-155">To learn how to pin secondary tiles, please see [Pin secondary tiles](tiles-and-notifications-secondary-tiles-pinning.md).</span></span>


## <a name="desktop-applications-and-secondary-tiles"></a><span data-ttu-id="e65f9-156">デスクトップ アプリケーションとセカンダリ タイル</span><span class="sxs-lookup"><span data-stu-id="e65f9-156">Desktop applications and secondary tiles</span></span>
<span data-ttu-id="e65f9-157">デスクトップ ブリッジを使って、デスクトップ アプリケーションからセカンダリ タイルを使用する方法については、「[デスクトップ アプリケーションからセカンダリ タイルをピン留めする](tiles-and-notifications-secondary-tiles-desktop-pinning.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e65f9-157">To learn how to use secondary tiles from your desktop application via the Desktop Bridge, please see [Pin secondary tiles from desktop application](tiles-and-notifications-secondary-tiles-desktop-pinning.md).</span></span>