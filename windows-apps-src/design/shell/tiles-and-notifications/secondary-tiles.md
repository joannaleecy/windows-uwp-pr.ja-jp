---
author: andrewleader
Description: Secondary tiles allow users to pin specific content and deep links from your app onto their Start menu, providing easy future access to the content within your app.
title: セカンダリ タイル
label: Secondary tiles
template: detail.hbs
ms.author: wdg-dev-content
ms.date: 05/25/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, セカンダリ タイル
ms.localizationpriority: medium
ms.openlocfilehash: d8d6a79ddd497bc3ada777af25791e9938355c79
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4692878"
---
# <a name="secondary-tiles"></a><span data-ttu-id="8e0a4-103">セカンダリ タイル</span><span class="sxs-lookup"><span data-stu-id="8e0a4-103">Secondary tiles</span></span>


<span data-ttu-id="8e0a4-104">セカンダリ タイルを使うと、ユーザーは特定のコンテンツやディープ リンクをアプリからスタート メニューにピン留めできます。これにより、その後はアプリ内の特定のコンテンツに簡単にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-104">Secondary tiles allow users to pin specific content and deep links from your app onto their Start menu, providing easy future access to the content within your app.</span></span>

![セカンダリ タイルのスクリーン ショット](images/secondarytiles.png)

<span data-ttu-id="8e0a4-106">たとえば、ユーザーは、さまざまな特定の場所の天気をスタート メニューにピン留めできます。これにより、(1) ライブ タイルを使って、容易にひとめでわかる最新の天気の情報を表示でき、(2) 詳しく知りたい特定の都市の天気にすばやくアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-106">For example, users can pin the weather for numerous specific locations on their Start menu, which provides (1) easy live glanceable information about the current weather thanks to Live Tiles, and (2) a quick entry point to the specific city's weather they care about.</span></span> <span data-ttu-id="8e0a4-107">ユーザーは、特定の株価情報、ニュース記事、およびその他の必要なアイテムもピン留めできます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-107">Users can also pin specific stocks, news articles, and more items that are important to them.</span></span>

<span data-ttu-id="8e0a4-108">アプリにセカンダリ タイルを追加すると、すばやく効率的にユーザーとの再エンゲージメントを行えます。セカンダリ タイルによる容易なアクセスのため、より高い頻度でのアプリの再利用を促すことができます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-108">By adding secondary tiles to your app, you help the user re-engage quickly and efficiently with your app, encouraging them to return more often thanks to the easy access that secondary tiles provides.</span></span>

<span data-ttu-id="8e0a4-109">**セカンダリ タイルをピン留めできるのはユーザーだけです。アプリでプログラムによってユーザーの承認なくピン留めすることはできません**。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-109">**Only users can pin a secondary tile; apps cannot pin secondary tiles programmatically without user approval**.</span></span> <span data-ttu-id="8e0a4-110">ユーザーは明示的にアプリ内から "ピン留め" ボタンをクリックする必要があります。これにより、API を使ってセカンダリ タイルの作成を要求します。システムによりダイアログ ボックスが表示され、ユーザーはタイルのピン留めの確認を求められます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-110">The user must explicitly click a "Pin" button within your app, at which point you then use the API to request to create a secondary tile, and then the system displays a dialog box asking the user to confirm whether they would like the tile pinned.</span></span>

## <a name="quick-links"></a><span data-ttu-id="8e0a4-111">クイック リンク</span><span class="sxs-lookup"><span data-stu-id="8e0a4-111">Quick links</span></span>

| <span data-ttu-id="8e0a4-112">記事</span><span class="sxs-lookup"><span data-stu-id="8e0a4-112">Article</span></span> | <span data-ttu-id="8e0a4-113">説明</span><span class="sxs-lookup"><span data-stu-id="8e0a4-113">Description</span></span> |
| --- | --- |
| [<span data-ttu-id="8e0a4-114">セカンダリ タイルのガイダンス</span><span class="sxs-lookup"><span data-stu-id="8e0a4-114">Guidance on secondary tiles</span></span>](secondary-tiles-guidance.md) | <span data-ttu-id="8e0a4-115">セカンダリ タイルを使用する必要がある場合について説明します。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-115">Learn about when and where you should use secondary tiles.</span></span> |
| [<span data-ttu-id="8e0a4-116">セカンダリ タイルをピン留めする</span><span class="sxs-lookup"><span data-stu-id="8e0a4-116">Pin secondary tiles</span></span>](secondary-tiles-pinning.md) | <span data-ttu-id="8e0a4-117">セカンダリ タイルをピン留めする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-117">Learn how to pin a secondary tile.</span></span> |
| [<span data-ttu-id="8e0a4-118">デスクトップ アプリケーションからピン留めする</span><span class="sxs-lookup"><span data-stu-id="8e0a4-118">Pin from desktop application</span></span>](secondary-tiles-desktop-pinning.md) | <span data-ttu-id="8e0a4-119">Windows デスクトップ アプリケーションでは、デスクトップ ブリッジを利用して、セカンダリ タイルをピン留めできます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-119">Windows desktop applications can pin secondary tiles thanks to the Desktop Bridge!</span></span> |


## <a name="secondary-tiles-in-relation-to-primary-tiles"></a><span data-ttu-id="8e0a4-120">セカンダリ タイルとプライマリ タイルの関係</span><span class="sxs-lookup"><span data-stu-id="8e0a4-120">Secondary tiles in relation to primary tiles</span></span>

<span data-ttu-id="8e0a4-121">セカンダリ タイルは、1 つの親アプリに関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-121">Secondary tiles are associated with a single parent app.</span></span> <span data-ttu-id="8e0a4-122">ユーザーは、セカンダリ タイルをスタート メニューにピン留めしておくことで、よく使う親アプリの領域を一貫した方法で効率的に直接起動できます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-122">They are pinned to the Start menu to provide a user with a consistent and efficient way to launch directly into a frequently used area of the parent app.</span></span> <span data-ttu-id="8e0a4-123">対象となる領域は、頻繁に更新されるコンテンツを含んだ親アプリの総合サブセクションか、またはアプリの特定の領域へのディープ リンクです。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-123">This can be either a general subsection of the parent app that contains frequently updated content, or a deep link to a specific area in the app.</span></span>

<span data-ttu-id="8e0a4-124">セカンダリ タイルを使うシナリオには次のようなものがあります。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-124">Examples of secondary tile scenarios include:</span></span>

* <span data-ttu-id="8e0a4-125">天気予報アプリでの特定の都市の天気予報の更新情報</span><span class="sxs-lookup"><span data-stu-id="8e0a4-125">Weather updates for a specific city in a weather app</span></span>
* <span data-ttu-id="8e0a4-126">カレンダー アプリでの予定イベントの要約</span><span class="sxs-lookup"><span data-stu-id="8e0a4-126">A summary of upcoming events in a calendar app</span></span>
* <span data-ttu-id="8e0a4-127">ソーシャル アプリでの大事な連絡先のステータスと更新情報</span><span class="sxs-lookup"><span data-stu-id="8e0a4-127">Status and updates from an important contact in a social app</span></span>
* <span data-ttu-id="8e0a4-128">RSS リーダーでの特定のフィード</span><span class="sxs-lookup"><span data-stu-id="8e0a4-128">Specific feeds in an RSS reader</span></span>
* <span data-ttu-id="8e0a4-129">音楽の再生リスト</span><span class="sxs-lookup"><span data-stu-id="8e0a4-129">A music playlist</span></span>
* <span data-ttu-id="8e0a4-130">ブログ</span><span class="sxs-lookup"><span data-stu-id="8e0a4-130">A blog</span></span>

<span data-ttu-id="8e0a4-131">ユーザーが注目しているコンテンツが頻繁に変更される場合も、セカンダリ タイルが役立ちます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-131">Any frequently changing content that a user wants to monitor is a good candidate for a secondary tile.</span></span> <span data-ttu-id="8e0a4-132">セカンダリ タイルをピン留めすると、ユーザーはタイルから更新情報をひとめで確認できるようになるほか、タイルから親アプリを直接起動できます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-132">After the secondary tile is pinned, users can receive at-a-glance updates through the tile and use it to launch directly into the parent app.</span></span>

<span data-ttu-id="8e0a4-133">セカンダリ タイルは多くの点でプライマリ タイルに似ています。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-133">Secondary tiles are similar to primary tiles in many ways:</span></span>

* <span data-ttu-id="8e0a4-134">タイル通知を使用して、リッチ コンテンツを表示できます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-134">They use tile notifications to display rich content.</span></span>
* <span data-ttu-id="8e0a4-135">既定のタイル コンテンツ用の 150 x 150 ピクセルのロゴを入れる必要があります。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-135">They must include a 150 x 150 pixel logo for the default tile content.</span></span>
* <span data-ttu-id="8e0a4-136">オプションとして、より大きなタイル サイズを有効にするために他のロゴ サイズを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-136">They can optionally include the other logo sizes to enable larger tile sizes.</span></span>
* <span data-ttu-id="8e0a4-137">通知とバッジを表示できます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-137">They can show notifications and badges.</span></span>
* <span data-ttu-id="8e0a4-138">スタート メニューで並べ替えることができます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-138">They can be rearranged on the Start menu.</span></span>
* <span data-ttu-id="8e0a4-139">アプリがアンインストールされると自動的に削除されます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-139">They are automatically deleted when the app is uninstalled.</span></span>
* <span data-ttu-id="8e0a4-140">ロック画面に、バッジとロックの詳細情報テキストを表示できます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-140">Their badge and lock detailed status text can be shown on lock.</span></span>

<span data-ttu-id="8e0a4-141">一方で、セカンダリ タイルにはプライマリ タイルと大きく異なる点があります。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-141">However, secondary tiles differ from primary tiles in some noticeable ways:</span></span>

* <span data-ttu-id="8e0a4-142">ユーザーは親アプリを削除することなくいつでもセカンダリ タイルを削除できます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-142">Users can delete their secondary tiles at any time without deleting the parent app.</span></span>
* <span data-ttu-id="8e0a4-143">セカンダリ タイルは実行時に作成できます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-143">Secondary tiles can be created at run time.</span></span> <span data-ttu-id="8e0a4-144">アプリ タイルはインストール時にしか作成できません。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-144">App tiles can be created only during installation.</span></span>
* <span data-ttu-id="8e0a4-145">セカンダリ タイルを追加する前に、ポップアップでユーザーへの確認が行われます。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-145">A flyout prompts the user for confirmation before adding a secondary tile.</span></span>
* <span data-ttu-id="8e0a4-146">プログラムでユーザーへの要求を使ってロック画面にセカンダリ タイルを選択することはできません。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-146">They cannot be programmatically selected for the lock screen through a request to the user.</span></span> <span data-ttu-id="8e0a4-147">ユーザーは、PC の設定でパーソナル設定] ページで、セカンダリ タイルを手動で追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-147">The user must manually add the secondary tile through the Personalize page in PC Settings.</span></span>

<span data-ttu-id="8e0a4-148">通知の送信のため、セカンダリ タイルで使われるタイル/バッジ アップデーターとプッシュ通知チャネル用に特定のメソッドが用意されています。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-148">For sending notifications, specific methods are provided for tile and badge updaters and push notification channels used with secondary tiles.</span></span> <span data-ttu-id="8e0a4-149">これらは、プライマリ タイルで使われるバージョンと似ています。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-149">These parallel the versions used with primary tiles.</span></span> <span data-ttu-id="8e0a4-150">たとえば、CreateBadgeUpdaterForApplication に対して CreateBadgeUpdaterForSecondaryTile があります。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-150">For instance, CreateBadgeUpdaterForApplication vs. CreateBadgeUpdaterForSecondaryTile.</span></span>


## <a name="guidance-on-secondary-tiles"></a><span data-ttu-id="8e0a4-151">セカンダリ タイルのガイダンス</span><span class="sxs-lookup"><span data-stu-id="8e0a4-151">Guidance on secondary tiles</span></span>
<span data-ttu-id="8e0a4-152">セカンダリ タイルを使う場合についての説明や、その他の使用のガイダンスについては、「[セカンダリ タイルのガイダンス](secondary-tiles-guidance.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-152">To learn about when and where you should use secondary tiles, and other usage guidance, please see [Guidance on secondary tiles](secondary-tiles-guidance.md)</span></span>


## <a name="pinning-secondary-tiles"></a><span data-ttu-id="8e0a4-153">セカンダリ タイルのピン留め</span><span class="sxs-lookup"><span data-stu-id="8e0a4-153">Pinning secondary tiles</span></span>
<span data-ttu-id="8e0a4-154">セカンダリ タイルをピン留めする方法については、「[セカンダリ タイルをピン留めする](secondary-tiles-pinning.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-154">To learn how to pin secondary tiles, please see [Pin secondary tiles](secondary-tiles-pinning.md).</span></span>


## <a name="desktop-applications-and-secondary-tiles"></a><span data-ttu-id="8e0a4-155">デスクトップ アプリケーションとセカンダリ タイル</span><span class="sxs-lookup"><span data-stu-id="8e0a4-155">Desktop applications and secondary tiles</span></span>
<span data-ttu-id="8e0a4-156">デスクトップ ブリッジを使って、デスクトップ アプリケーションからセカンダリ タイルを使用する方法については、「[デスクトップ アプリケーションからセカンダリ タイルをピン留めする](secondary-tiles-desktop-pinning.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8e0a4-156">To learn how to use secondary tiles from your desktop application via the Desktop Bridge, please see [Pin secondary tiles from desktop application](secondary-tiles-desktop-pinning.md).</span></span>
