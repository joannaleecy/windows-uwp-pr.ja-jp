---
title: Xbox Live クリエーターズ サービス構成
author: KevinAsgari
description: クリエーターズ プログラムの Xbox Live サービス構成について説明します。
ms.assetid: 22b8f893-abb3-426e-9840-f79de0753702
ms.author: kevinasg
ms.date: 10/03/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f42379b5225553f03b9b9af8149d6cb888377a36
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4151274"
---
# <a name="xbox-live-service-configuration-for-the-creators-program"></a><span data-ttu-id="deff8-104">クリエーターズ プログラムの Xbox Live サービス構成</span><span class="sxs-lookup"><span data-stu-id="deff8-104">Xbox Live service configuration for the Creators Program</span></span>

## <a name="what-is-service-configuration"></a><span data-ttu-id="deff8-105">サービス構成とは</span><span class="sxs-lookup"><span data-stu-id="deff8-105">What is Service Configuration?</span></span>

<span data-ttu-id="deff8-106">[ランキング](../leaderboards-and-stats-2017/leaderboards.md)や[接続ストレージ](../storage-platform/connected-storage/connected-storage-technical-overview.md)などのいくつかの Xbox Live 機能についてよくご存じかもしれません。</span><span class="sxs-lookup"><span data-stu-id="deff8-106">You may be familiar with some of the Xbox Live features such as [Leaderboards](../leaderboards-and-stats-2017/leaderboards.md) and [Connected Storage](../storage-platform/connected-storage/connected-storage-technical-overview.md).</span></span>

<span data-ttu-id="deff8-107">ご存じでない場合のために、例としてランキングについて簡単に説明します。</span><span class="sxs-lookup"><span data-stu-id="deff8-107">In case you are not, we'll briefly explain Leaderboards as an example.</span></span> <span data-ttu-id="deff8-108">ランキングを使用すると、プレイヤーは実績を表す値を確認し、他のプレイヤーと比較できます。</span><span class="sxs-lookup"><span data-stu-id="deff8-108">Leaderboards allow players to see a value representing an accomplishment, in comparison to other players.</span></span> <span data-ttu-id="deff8-109">たとえば、アーケード ゲームのハイスコアやレーシング ゲームのラップ タイム、一人称視点のシューティング ゲームのヘッドショットなどです。</span><span class="sxs-lookup"><span data-stu-id="deff8-109">For example high scores in an arcade game, lap times in a racing game, or headshots in a first-person shooter.</span></span> <span data-ttu-id="deff8-110">ただし、アーケード マシンでは特定のマシンでプレイしたプレイヤーのトップ スコアのみが示されますが、Xbox Live では、世界中からのハイスコアを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="deff8-110">But unlike an arcade machine which only shows the top scores from the players who have played on that physical machine, with Xbox Live it is possible to display high scores from around the world.</span></span>

<span data-ttu-id="deff8-111">また、これを実現するためには、Xbox Live でランキングを認識できるよう、一度限りの構成を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="deff8-111">But for this to happen, you need to perform some one-time configuration so that Xbox Live knows about your leaderboard.</span></span> <span data-ttu-id="deff8-112">たとえば、値を昇順で並び替えるか、降順で並び替えるか、データのどの部分を並び替えるかなどを構成します。</span><span class="sxs-lookup"><span data-stu-id="deff8-112">For example whether the values should be sorted in ascending or descending value, and what piece of data it should be sorting.</span></span>

<span data-ttu-id="deff8-113">この構成は、Xbox Live クリエーターズ プログラム用の[デベロッパー センター](http://dev.windows.com)で行われます。セットアップ方法については、「[Xbox Live の概要](get-started-with-xbox-live-creators.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="deff8-113">This configuration happens on [Dev Center](http://dev.windows.com) for Xbox Live Creators Program, and you can read [Getting Started With Xbox Live](get-started-with-xbox-live-creators.md) to learn how to get set up.</span></span>

## <a name="get-your-ids"></a><span data-ttu-id="deff8-114">ID を取得する</span><span class="sxs-lookup"><span data-stu-id="deff8-114">Get your IDs</span></span>

<span data-ttu-id="deff8-115">Xbox Live サービスを有効にするには、開発環境とタイトルを構成するためのいくつかの ID を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="deff8-115">To enable Xbox Live services, you will need to obtain several IDs to configure your development environment and title.</span></span> <span data-ttu-id="deff8-116">これらの ID は、Xbox Live サービスの構成を更新することによって取得できます。</span><span class="sxs-lookup"><span data-stu-id="deff8-116">These can be obtained by updating your Xbox Live service configuration.</span></span>

<span data-ttu-id="deff8-117">デベロッパー センターに現在タイトルがない場合は、ガイダンスについて、「[新しいクリエーターズ タイトルを作成し、テストする](create-and-test-a-new-creators-title.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="deff8-117">If you do not currently have a title in Dev Center, see [Create and test a new Creators title](create-and-test-a-new-creators-title.md) for guidance.</span></span>

### <a name="critical-ids"></a><span data-ttu-id="deff8-118">重要な ID</span><span class="sxs-lookup"><span data-stu-id="deff8-118">Critical IDs</span></span>

<span data-ttu-id="deff8-119">Xbox One 用のタイトルおよびアプリケーションの開発には、サンドボックス ID、タイトル ID、およびサービス構成 ID (SCID) という 3 つの ID が重要です。</span><span class="sxs-lookup"><span data-stu-id="deff8-119">There are three IDs which are critical for development of titles and applications for Xbox One: the Sandbox ID, the Title ID, and the service configuration ID (SCID).</span></span>

<span data-ttu-id="deff8-120">サンドボックス ID は開発環境をセットアップするために必要です。タイトル ID と SCID は初期開発には必要ありませんが、Xbox Live サービスを利用する場合に必要となります。</span><span class="sxs-lookup"><span data-stu-id="deff8-120">While it is necessary to have a Sandbox ID to setup your development environment, the Title ID and SCID are not required for initial development but are required for any use of Xbox Live services.</span></span> <span data-ttu-id="deff8-121">したがって、3 つの ID すべてを一度に取得することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="deff8-121">We therefore recommend that you obtain all three at once.</span></span> <span data-ttu-id="deff8-122">すべての ID は、以下に示す ”Xbox Live” のルート構成ページで取得できます。</span><span class="sxs-lookup"><span data-stu-id="deff8-122">You can view all of the IDs on the "Xbox Live" root configuration page as shown below:</span></span>

![](../images/getting_started/devcenter_sandbox_id.png)

#### <a name="sandbox-ids"></a><span data-ttu-id="deff8-123">サンドボックス ID</span><span class="sxs-lookup"><span data-stu-id="deff8-123">Sandbox IDs</span></span>

<span data-ttu-id="deff8-124">サンドボックスは、開発中に環境のコンテンツを分離し、クリーンにタイトルを開発およびテストできるようにします。</span><span class="sxs-lookup"><span data-stu-id="deff8-124">The sandbox provides content isolation for your environment during development, ensuring that it is clean for developing and testing your title.</span></span> <span data-ttu-id="deff8-125">サンドボックス ID はサンドボックスを識別します。</span><span class="sxs-lookup"><span data-stu-id="deff8-125">The Sandbox ID identifies your sandbox.</span></span> <span data-ttu-id="deff8-126">本体は、一度に 1 つのサンドボックスにのみアクセスできます。ただし、1 つのサンドボックスには複数の本体からアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="deff8-126">A console may only access one sandbox at any one time, though one sandbox may be accessed by multiple consoles.</span></span>

<span data-ttu-id="deff8-127">サンド ボックス ID は大文字と小文字を区別します。</span><span class="sxs-lookup"><span data-stu-id="deff8-127">Sandbox IDs are case sensitive.</span></span>

#### <a name="service-configuration-id-scid"></a><span data-ttu-id="deff8-128">サービス構成 ID (SCID)</span><span class="sxs-lookup"><span data-stu-id="deff8-128">Service Configuration ID (SCID)</span></span>

<span data-ttu-id="deff8-129">開発の過程では、統計、ランキング、他のオンライン機能のホストを作成します。</span><span class="sxs-lookup"><span data-stu-id="deff8-129">As a part of development, you will create stats, leaderboards and a host of other online features.</span></span> <span data-ttu-id="deff8-130">これらはすべてサービス構成の一部であり、アクセスするには SCID が必要です。</span><span class="sxs-lookup"><span data-stu-id="deff8-130">These are all part of your service configuration, and require the SCID for access.</span></span> <span data-ttu-id="deff8-131">SCID は大文字と小文字を区別します。</span><span class="sxs-lookup"><span data-stu-id="deff8-131">SCIDs are case sensitive.</span></span>

#### <a name="title-id"></a><span data-ttu-id="deff8-132">タイトル ID</span><span class="sxs-lookup"><span data-stu-id="deff8-132">Title ID</span></span>

<span data-ttu-id="deff8-133">タイトル ID は Xbox Live サービスに対してタイトルを一意に識別するためのものです。</span><span class="sxs-lookup"><span data-stu-id="deff8-133">The Title ID uniquely identifies your title to Xbox Live services.</span></span> <span data-ttu-id="deff8-134">タイトル ID は、タイトルの Live コンテンツ、ユーザー統計情報、実績などにユーザーがアクセスするために、また、Live のマルチプレイヤー機能を有効にするためにサービス全体を通して使用されます。</span><span class="sxs-lookup"><span data-stu-id="deff8-134">It is used throughout the services to enable your users to access your title's Live content, their user statistics, achievements, and so forth, and to enable Live multiplayer functionality.</span></span>

<span data-ttu-id="deff8-135">タイトル ID は、使用される方法および場所によって、大文字と小文字が区別されることがあります。</span><span class="sxs-lookup"><span data-stu-id="deff8-135">Title IDs can be case sensitive, depending on how and where they are used.</span></span>

## <a name="publish-your-xbox-live-service-configuration"></a><span data-ttu-id="deff8-136">Xbox Live サービス構成を公開する</span><span class="sxs-lookup"><span data-stu-id="deff8-136">Publish your Xbox Live service configuration</span></span>

<span data-ttu-id="deff8-137">ゲーム用の Xbox Live 構成に変更を加える場合、それらの変更を Xbox Live の残りの部分が取得してゲームに表示されるには、変更を公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="deff8-137">When you make changes to the Xbox Live configuration for your game, you need to publish the changes before they are picked up by the rest of Xbox Live and can be seen by your game.</span></span> <span data-ttu-id="deff8-138">ゲームに対する作業を継続している間は、独自の開発サンドボックスに公開します。</span><span class="sxs-lookup"><span data-stu-id="deff8-138">When you are still working on your game, you publish to your own development sandbox.</span></span> <span data-ttu-id="deff8-139">開発サンドボックスでは、分離された環境でゲームへの変更に取り組むことができます。</span><span class="sxs-lookup"><span data-stu-id="deff8-139">The development sandbox allows you to work on changes to your game in an isolated environment.</span></span> <span data-ttu-id="deff8-140">ゲームを一般向けにリリースすると、Xbox Live 構成は自動的に RETAIL サンドボックスに公開されます。</span><span class="sxs-lookup"><span data-stu-id="deff8-140">When your game is released to the public, the Xbox Live configuration will automatically be published to the RETAIL sandbox.</span></span>
<span data-ttu-id="deff8-141">既定では、Xbox One 本体と Windows 10 PC は RETAIL サンドボックスになっています。</span><span class="sxs-lookup"><span data-stu-id="deff8-141">By default, Xbox One Consoles and Windows 10 PCs are in the RETAIL sandbox.</span></span>

<span data-ttu-id="deff8-142">現在の Xbox Live 構成を開発サンドボックスに公開するには、Xbox Live 構成ページで **[テスト]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="deff8-142">On the Xbox Live configuration page, click the **Test** button to publish the current Xbox Live configuration to your development sandbox.</span></span>

![](../images/creators_udc/creators_udc_xboxlive_config_test.png)