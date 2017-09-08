---
title: "Xbox Live クリエーターズ サービス構成"
author: KevinAsgari
description: "クリエーターズ プログラムの Xbox Live サービス構成について説明します。"
ms.assetid: 22b8f893-abb3-426e-9840-f79de0753702
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One"
ms.openlocfilehash: 5cb146f3cd316a88a66bcc3057e30d11baa3aab1
ms.sourcegitcommit: a7a1b41c7dce6d56250ce3113137391d65d9e401
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/11/2017
---
# <a name="xbox-live-service-configuration-for-the-creators-program"></a><span data-ttu-id="5793d-104">クリエーターズ プログラムの Xbox Live サービス構成</span><span class="sxs-lookup"><span data-stu-id="5793d-104">Xbox Live service configuration for the Creators Program</span></span>

## <a name="what-is-service-configuration"></a><span data-ttu-id="5793d-105">サービス構成とは</span><span class="sxs-lookup"><span data-stu-id="5793d-105">What is Service Configuration?</span></span>

<span data-ttu-id="5793d-106">[実績](../achievements-2017/achievements.md)、[ランキング](../leaderboards-and-stats-2017/leaderboards.md)、[マッチメイキング](../multiplayer/multiplayer-concepts.md#SmartMatch)などのいくつかの Xbox Live 機能についてよくご存じかもしれません。</span><span class="sxs-lookup"><span data-stu-id="5793d-106">You may be familiar with some of the Xbox Live features such as [Achievements](../achievements-2017/achievements.md), [Leaderboards](../leaderboards-and-stats-2017/leaderboards.md) and [Matchmaking](../multiplayer/multiplayer-concepts.md#SmartMatch).</span></span>

<span data-ttu-id="5793d-107">ご存じでない場合のために、例としてランキングについて簡単に説明します。</span><span class="sxs-lookup"><span data-stu-id="5793d-107">In case you are not, we'll briefly explain Leaderboards as an example.</span></span>  <span data-ttu-id="5793d-108">ランキングを使用すると、プレイヤーは実績を表す値を確認し、他のプレイヤーと比較できます。</span><span class="sxs-lookup"><span data-stu-id="5793d-108">Leaderboards allow players to see a value representing an accomplishment, in comparison to other players.</span></span>  <span data-ttu-id="5793d-109">たとえば、アーケード ゲームのハイスコアやレーシング ゲームのラップ タイム、一人称視点のシューティング ゲームのヘッドショットなどです。</span><span class="sxs-lookup"><span data-stu-id="5793d-109">For example high scores in an arcade game, lap times in a racing game, or headshots in a first-person shooter.</span></span>  <span data-ttu-id="5793d-110">ただし、アーケード マシンでは特定のマシンでプレイしたプレイヤーのトップ スコアのみが示されますが、Xbox Live では、世界中からのハイスコアを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="5793d-110">But unlike an arcade machine which only shows the top scores from the players who have played on that physical machine, with Xbox Live it is possible to display high scores from around the world.</span></span>

<span data-ttu-id="5793d-111">また、これを実現するためには、Xbox Live でランキングを認識できるよう、一度限りの構成を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5793d-111">But for this to happen, you need to perform some one-time configuration so that Xbox Live knows about your leaderboard.</span></span>  <span data-ttu-id="5793d-112">たとえば、値を昇順で並び替えるか、降順で並び替えるか、データのどの部分を並び替えるかなどを構成します。</span><span class="sxs-lookup"><span data-stu-id="5793d-112">For example whether the values should be sorted in ascending or descending value, and what piece of data it should be sorting.</span></span>

<span data-ttu-id="5793d-113">この構成は、Xbox Live クリエーターズ プログラム用の[デベロッパー センター](http://dev.windows.com)で行われます。セットアップ方法については、「[Xbox Live の概要](get-started-with-xbox-live-creators.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5793d-113">This configuration happens on [Dev Center](http://dev.windows.com) for Xbox Live Creators Program, and you can read [Getting Started With Xbox Live](get-started-with-xbox-live-creators.md) to learn how to get set up.</span></span>

## <a name="get-your-ids"></a><span data-ttu-id="5793d-114">ID を取得する</span><span class="sxs-lookup"><span data-stu-id="5793d-114">Get your IDs</span></span>

<span data-ttu-id="5793d-115">Xbox Live サービスを有効にするには、開発キットとタイトルを構成するためのいくつかの ID を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5793d-115">To enable Xbox Live services, you will need to obtain several IDs to configure your development kit and your title.</span></span> <span data-ttu-id="5793d-116">これらの ID は、Xbox Live サービスの構成を行うことによって取得できます。</span><span class="sxs-lookup"><span data-stu-id="5793d-116">These can be obtained by doing Xbox Live service configuration.</span></span>

<span data-ttu-id="5793d-117">デベロッパー センターに現在タイトルがない場合は、ガイダンスについて、「[新しいクリエーターズ タイトルを作成し、テストする](create-and-test-a-new-creators-title.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5793d-117">If you do not currently have a title in Dev Center, see [Create and test a new Creators title](create-and-test-a-new-creators-title.md) for guidance.</span></span>

### <a name="critical-ids"></a><span data-ttu-id="5793d-118">重要な ID</span><span class="sxs-lookup"><span data-stu-id="5793d-118">Critical IDs</span></span>

<span data-ttu-id="5793d-119">Xbox One 用のタイトルおよびアプリケーションの開発には、サンドボックス ID、タイトル ID、およびサービス構成 ID (SCID) という 3 つの ID が重要です。</span><span class="sxs-lookup"><span data-stu-id="5793d-119">There are three IDs which are critical for development of titles and applications for Xbox One: the sandbox ID, the TitleID, and the service configuration ID (SCID).</span></span>

<span data-ttu-id="5793d-120">サンドボックス ID は開発キットを使用するために必要です。タイトル ID と SCID は初期開発には必要ありませんが、Xbox Live サービスを利用する場合に必要となります。</span><span class="sxs-lookup"><span data-stu-id="5793d-120">While it is necessary to have a sandbox ID to use a development kit, the TitleID and SCID are not required for initial development but are required for any use of Xbox Live services.</span></span> <span data-ttu-id="5793d-121">したがって、3 つの ID すべてを一度に取得することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5793d-121">We therefore recommend that you obtain all three at once.</span></span>

#### <a name="sandbox-ids"></a><span data-ttu-id="5793d-122">サンドボックス ID</span><span class="sxs-lookup"><span data-stu-id="5793d-122">Sandbox IDs</span></span>

<span data-ttu-id="5793d-123">サンドボックスは、開発中に開発キットのコンテンツを分離し、クリーンな環境でタイトルを開発およびテストできるようにします。</span><span class="sxs-lookup"><span data-stu-id="5793d-123">The sandbox provides content isolation for your development kit during development, ensuring that you have a clean environment for developing and testing your title.</span></span> <span data-ttu-id="5793d-124">サンドボックス ID はサンドボックスを識別します。</span><span class="sxs-lookup"><span data-stu-id="5793d-124">The Sandbox ID identifies your sandbox.</span></span> <span data-ttu-id="5793d-125">本体は、一度に 1 つのサンドボックスにのみアクセスできます。ただし、1 つのサンドボックスには複数の本体からアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="5793d-125">A console may only access one sandbox at any one time, though one sandbox may be accessed by multiple consoles.</span></span>

<span data-ttu-id="5793d-126">サンド ボックス ID は大文字と小文字を区別します。</span><span class="sxs-lookup"><span data-stu-id="5793d-126">Sandbox IDs are case sensitive.</span></span>

<span data-ttu-id="5793d-127">サンドボックス ID は、以下に示す ”Xbox Live” のルート構成ページで取得できます。</span><span class="sxs-lookup"><span data-stu-id="5793d-127">You can get your Sandbox ID on the "Xbox Live" root configuration page as shown below:</span></span>

![](../images/getting_started/devcenter_sandbox_id.png)

#### <a name="service-configuration-id-scid"></a><span data-ttu-id="5793d-128">サービス構成 ID (SCID)</span><span class="sxs-lookup"><span data-stu-id="5793d-128">Service Configuration ID (SCID)</span></span>

<span data-ttu-id="5793d-129">開発の過程では、イベント、実績、他のオンライン機能のホストを作成します。</span><span class="sxs-lookup"><span data-stu-id="5793d-129">As a part of development, you will create events, achievements, and a host of other online features.</span></span> <span data-ttu-id="5793d-130">これらはすべてサービス構成の一部であり、アクセスするには SCID が必要です。</span><span class="sxs-lookup"><span data-stu-id="5793d-130">These are all part of your Service Configuration, and require the SCID for access.</span></span> <span data-ttu-id="5793d-131">1 つのタイトルに複数のサービス構成が存在する場合があり、構成ごとに独自の SCID が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="5793d-131">A given title may have multiple Service Configurations; each will have its own SCID.</span></span>

<span data-ttu-id="5793d-132">SCID は大文字と小文字を区別します。</span><span class="sxs-lookup"><span data-stu-id="5793d-132">SCIDs are case sensitive.</span></span>

<span data-ttu-id="5793d-133">デベロッパー センターで SCID を取得するには、[Xbox Live サービス] セクション、*[Xbox Live Setup]* (Xbox Live のセットアップ) の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="5793d-133">To retrieve your SCID on Dev Center, navigate to the Xbox Live Services section and go to *Xbox Live Setup* .</span></span>  <span data-ttu-id="5793d-134">以下に示すテーブルに SCID が表示されます。</span><span class="sxs-lookup"><span data-stu-id="5793d-134">Your SCID is displayed in the table shown below:</span></span>

![](../images/getting_started/devcenter_scid.png)

#### <a name="titleid"></a><span data-ttu-id="5793d-135">タイトル ID</span><span class="sxs-lookup"><span data-stu-id="5793d-135">TitleID</span></span>

<span data-ttu-id="5793d-136">タイトル ID は Xbox Live サービスに対してタイトルを一意に識別するためのものです。</span><span class="sxs-lookup"><span data-stu-id="5793d-136">The TitleID uniquely identifies your title to Xbox Live services.</span></span> <span data-ttu-id="5793d-137">タイトル ID は、タイトルの Live コンテンツ、ユーザー統計情報、実績などにユーザーがアクセスするために、また、Live のマルチプレイヤー機能を有効にするためにサービス全体を通して使用されます。</span><span class="sxs-lookup"><span data-stu-id="5793d-137">It is used throughout the services to enable your users to access your title's Live content, their user statistics, achievements, and so forth, and to enable Live multiplayer functionality.</span></span>

<span data-ttu-id="5793d-138">タイトル ID は、使用される方法および場所によって、大文字と小文字が区別されることがあります。</span><span class="sxs-lookup"><span data-stu-id="5793d-138">Title IDs can be case sensitive, depending on how and where they are used.</span></span>

<span data-ttu-id="5793d-139">デベロッパー センターでタイトル ID を確認するには、*[Xbox Live Setup]* (Xbox Live のセットアップ) ページの SCID と同じテーブルを参照してください。</span><span class="sxs-lookup"><span data-stu-id="5793d-139">Your Title ID on Dev Center is found in the same table as the SCID in the *Xbox Live Setup* page.</span></span>
