---
title: Xbox Live サービス構成
author: KevinAsgari
description: Xbox Live サービスをゲーム向けに構成する方法について説明します。
ms.assetid: 631c415b-5366-4a84-ba4f-4f513b229c32
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, サービス構成
ms.localizationpriority: medium
ms.openlocfilehash: dc5db2d750f297c226f377d8f90ddc3ff900f6f3
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7147757"
---
# <a name="xbox-live-service-configuration"></a><span data-ttu-id="914f7-104">Xbox Live サービス構成</span><span class="sxs-lookup"><span data-stu-id="914f7-104">Xbox Live service configuration</span></span>

## <a name="what-is-service-configuration"></a><span data-ttu-id="914f7-105">サービス構成とは</span><span class="sxs-lookup"><span data-stu-id="914f7-105">What is Service Configuration?</span></span>

<span data-ttu-id="914f7-106">[実績](achievements-2017/achievements.md)、[ランキング](leaderboards-and-stats-2017/leaderboards.md)、[マッチメイキング](multiplayer/multiplayer-concepts.md#smartmatch-matchmaking)などのいくつかの Xbox Live 機能についてよくご存じかもしれません。</span><span class="sxs-lookup"><span data-stu-id="914f7-106">You may be familiar with some of the Xbox Live features such as [Achievements](achievements-2017/achievements.md), [Leaderboards](leaderboards-and-stats-2017/leaderboards.md) and [Matchmaking](multiplayer/multiplayer-concepts.md#smartmatch-matchmaking).</span></span>

<span data-ttu-id="914f7-107">ご存じでない場合のために、例としてランキングについて簡単に説明します。</span><span class="sxs-lookup"><span data-stu-id="914f7-107">In case you are not, we'll briefly explain Leaderboards as an example.</span></span> <span data-ttu-id="914f7-108">ランキングを使用すると、プレイヤーは実績を表す値を確認し、他のプレイヤーと比較できます。</span><span class="sxs-lookup"><span data-stu-id="914f7-108">Leaderboards allow players to see a value representing an accomplishment, in comparison to other players.</span></span>  <span data-ttu-id="914f7-109">たとえば、アーケード ゲームのハイスコアやレーシング ゲームのラップ タイム、一人称視点のシューティング ゲームのヘッドショットなどです。</span><span class="sxs-lookup"><span data-stu-id="914f7-109">For example high scores in an arcade game, lap times in a racing game, or headshots in a first-person shooter.</span></span> <span data-ttu-id="914f7-110">ただし、アーケード マシンでは特定のマシンでプレイしたプレイヤーのトップ スコアのみが示されますが、Xbox Live では、世界中からのハイスコアを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="914f7-110">But unlike an arcade machine which only shows the top scores from the players who have played on that physical machine, with Xbox Live it is possible to display high scores from around the world.</span></span>

<span data-ttu-id="914f7-111">また、これを実現するためには、Xbox Live でランキングを認識できるよう、一度限りの構成を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="914f7-111">But for this to happen, you need to perform some one-time configuration so that Xbox Live knows about your leaderboard.</span></span> <span data-ttu-id="914f7-112">たとえば、値を昇順で並び替えるか、降順で並び替えるか、データのどの部分を並び替えるかなどを構成します。</span><span class="sxs-lookup"><span data-stu-id="914f7-112">For example whether the values should be sorted in ascending or descending value, and what piece of data it should be sorting.</span></span>

<span data-ttu-id="914f7-113">この構成は、ほとんどの場合で、[パートナー センター](https://partner.microsoft.com/dashboard)で発生します。</span><span class="sxs-lookup"><span data-stu-id="914f7-113">This configuration happens on [Partner Center](https://partner.microsoft.com/dashboard) most of the time.</span></span> <span data-ttu-id="914f7-114">しかし、[Xbox 開発者ポータル (XDP)](http://xdp.xboxlive.com) を使用する開発者もいます。</span><span class="sxs-lookup"><span data-stu-id="914f7-114">But certain developers will use [Xbox Developer Portal (XDP)](http://xdp.xboxlive.com).</span></span>

<span data-ttu-id="914f7-115">Xbox Live クリエーターズ プログラムの一部としてタイトルを開発する場合は、[パートナー センター](https://partner.microsoft.com/dashboard)を使用して、 [Xbox Live の概要](get-started-with-creators/get-started-with-xbox-live-creators.md)をセットアップする方法についてを読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="914f7-115">If you are a developing your title as part of the Xbox Live Creators Program, you use [Partner Center](https://partner.microsoft.com/dashboard), and you can read [Getting Started With Xbox Live](get-started-with-creators/get-started-with-xbox-live-creators.md) to learn how to get set up.</span></span>

<span data-ttu-id="914f7-116">ID@Xbox の開発者である場合、または Microsoft パートナーのパブリッシャーと共同で作業を行っている場合は、続きをお読みください。</span><span class="sxs-lookup"><span data-stu-id="914f7-116">If you are an ID@Xbox Developer or working with a publisher that is a Microsoft Partner, please read on.</span></span>

## <a name="choose-your-development-portal"></a><span data-ttu-id="914f7-117">開発ポータルを選択する</span><span class="sxs-lookup"><span data-stu-id="914f7-117">Choose your development portal</span></span>

<span data-ttu-id="914f7-118">前述のとおり、Xbox Live サービスの構成には、異なる 2 つのポータルを使用できます。</span><span class="sxs-lookup"><span data-stu-id="914f7-118">As mentioned above, there are two different portals that can be used to configure Xbox Live Services.</span></span> <span data-ttu-id="914f7-119">パートナー センターで[https://partner.microsoft.com/dashboard](https://partner.microsoft.com/dashboard)と Xbox デベロッパー ポータル (XDP) で[http://xdp.xboxlive.com](http://xdp.xboxlive.com)します。</span><span class="sxs-lookup"><span data-stu-id="914f7-119">Partner Center at [https://partner.microsoft.com/dashboard](https://partner.microsoft.com/dashboard) and the Xbox Development Portal (XDP) at [http://xdp.xboxlive.com](http://xdp.xboxlive.com).</span></span>

<span data-ttu-id="914f7-120">今後は、すべてのタイトルのパートナー センターが推奨される特定の機能、可能性がある場合でも、XDP を使用します。</span><span class="sxs-lookup"><span data-stu-id="914f7-120">Partner Center is recommended for all titles going forward, but for certain features, you may still want to use XDP.</span></span> <span data-ttu-id="914f7-121">このセクションでは、どこでタイトルを構成したらよいかを説明します。</span><span class="sxs-lookup"><span data-stu-id="914f7-121">This section will help advise you where to configure your title.</span></span>

<span data-ttu-id="914f7-122">選んだポータルに応じて特定のサービス構成ページの情報をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="914f7-122">You can find information about specific service configuration pages depending on your chosen portal:</span></span>

* [<span data-ttu-id="914f7-123">パートナー センターの構成</span><span class="sxs-lookup"><span data-stu-id="914f7-123">Partner Center configuration</span></span>](configure-xbl/windows-dev-center.md)
* <span data-ttu-id="914f7-124">[Xbox デベロッパー ポータルの構成](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/atoc-service-configuration)- このリンクにアクセスすると、Microsoft アカウント (MSA) Xbox Live のフル アクセスが有効になっている必要があります。</span><span class="sxs-lookup"><span data-stu-id="914f7-124">[Xbox Development Portal configuration](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/atoc-service-configuration) - To access this link, you must have a Microsoft Account (MSA) that has been enabled for full Xbox Live access.</span></span>

<span data-ttu-id="914f7-125">既にタイトルを構成済みの場合は、「[ID を取得する](#get_ids)」まで下にスクロールして、タイトルの設定に必要なさまざまな ID を取得する方法をご覧いただけます。</span><span class="sxs-lookup"><span data-stu-id="914f7-125">If you already have a title configured, you can scroll down to [Get your IDs](#get_ids) to learn how to get the various identifiers required to setup your title.</span></span>

### <a name="pcmobile-uwp-game-only"></a><span data-ttu-id="914f7-126">PC/Mobile UWP ゲーム専用</span><span class="sxs-lookup"><span data-stu-id="914f7-126">PC/Mobile UWP game only</span></span>
<span data-ttu-id="914f7-127">Windows 10 Pc や Windows 10 mobile デバイスでのみ動作する UWP ゲームを構成およびは、パートナー センターをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="914f7-127">Partner Center is recommended for configuring and managing UWP games that run only on Windows 10 PCs and/or Windows 10 mobile devices.</span></span>

#### <a name="using-xdp-to-configure-uwp-titles"></a><span data-ttu-id="914f7-128">XDP の使用による UWP タイトルの構成</span><span class="sxs-lookup"><span data-stu-id="914f7-128">Using XDP to configure UWP titles</span></span>

<span data-ttu-id="914f7-129">次のいずれかの要件がある場合は、UWP タイトルの構成に XDP を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="914f7-129">You may want to use XDP to configure UWP titles if you have one of the following requirements:</span></span>

1. <span data-ttu-id="914f7-130">アリーナを使用している。</span><span class="sxs-lookup"><span data-stu-id="914f7-130">You are using Arena.</span></span>
2. <span data-ttu-id="914f7-131">XDP に、引き続き使用したい既存のユーザー、グループ、アクセス許可の設定がある。</span><span class="sxs-lookup"><span data-stu-id="914f7-131">You have existing users, groups, and permissions setup on XDP that you want to keep using.</span></span>
3. <span data-ttu-id="914f7-132">Tournaments Tool や マルチプレイヤー セッション ディレクトリ セッション履歴ビューアーなど、XDP でのみ動作するツールを使用している。</span><span class="sxs-lookup"><span data-stu-id="914f7-132">You are using tools which only work on XDP such as the Tournaments Tool or Multiplayer Session Directory session history viewer.</span></span>
4. <span data-ttu-id="914f7-133">Xbox One XDK ベースのゲームと、同じゲームの UWP PC/モバイル バージョンとの間のクロスプラットフォーム プレイ機能を持つタイトルを開発している。</span><span class="sxs-lookup"><span data-stu-id="914f7-133">You are developing a title that will have cross-platform play between an Xbox One XDK based game and UWP PC/mobile version of the same game.</span></span>

<span data-ttu-id="914f7-134">これらのカテゴリのいずれかに該当しない場合は、パートナー センターを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="914f7-134">If you don't fall into one of those categories, then you should use Partner Center.</span></span> <span data-ttu-id="914f7-135">いずれかが該当する場合は、以下に示す XDP を使用して UWP タイトルを構成する方法をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="914f7-135">Otherwise you can see below for how to use XDP to configure a UWP title.</span></span>

<span data-ttu-id="914f7-136">XDP を使用した UWP アプリケーション用の Xbox Live サービスの構成に関して、いくつかの重要な注意事項があります。</span><span class="sxs-lookup"><span data-stu-id="914f7-136">Using XDP to configure Xbox Live Services for UWP applications has a few important caveats:</span></span>

* **<span data-ttu-id="914f7-137">ゲームの Xbox Live サービス構成をいったん XDP で CERT/RETAIL に公開すると、後戻りできません!</span><span class="sxs-lookup"><span data-stu-id="914f7-137">Once a game's Xbox Live service configuration is published to CERT/RETAIL in XDP, there is no going back!</span></span>** <span data-ttu-id="914f7-138">そのゲームの Xbox Live サービス構成は、ゲーム タイトルの寿命が終わるまで XDP にとどまる必要があります。</span><span class="sxs-lookup"><span data-stu-id="914f7-138">The Xbox Live service configuration for that game needs to remain in XDP for the life of the game title.</span></span>
* **<span data-ttu-id="914f7-139">XDP からパートナー センターへの移行パスはありません。</span><span class="sxs-lookup"><span data-stu-id="914f7-139">There is no migration path from XDP to Partner Center.</span></span>** <span data-ttu-id="914f7-140">XDP で Xbox Live 構成を起動するとする必要があります手動で再作成する、パートナー センターで移動する場合。</span><span class="sxs-lookup"><span data-stu-id="914f7-140">If you start your Xbox Live configuration in XDP, you must manually recreate it in Partner Center if you want to move it.</span></span>

<span data-ttu-id="914f7-141">これら 2 つの考慮事項をお勧め PC/モバイル ゲームでは、パートナー センターを使用して上記カテゴリのいずれかに該当する場合は除きます。</span><span class="sxs-lookup"><span data-stu-id="914f7-141">Given these two considerations, we recommended using Partner Center for PC/Mobile games, unless you fall into one of the categories described above.</span></span>

### <a name="cross-play-between-xbox-one-and-pcmobile-games"></a><span data-ttu-id="914f7-142">Xbox One ゲームと PC/モバイル ゲーム間のクロスプレイ</span><span class="sxs-lookup"><span data-stu-id="914f7-142">Cross-play between Xbox One and PC/Mobile games</span></span> ###
<span data-ttu-id="914f7-143">クロスプレイと呼ばれる、Xbox One および PC 間のクロスデバイス ゲーミングは、注目に値する Windows 10 エクスペリエンスです。</span><span class="sxs-lookup"><span data-stu-id="914f7-143">Cross-device gaming between the Xbox One and the PC, known as cross-play, is a showcase Windows 10 experience.</span></span> <span data-ttu-id="914f7-144">このシナリオでは、ゲームの Xbox One バージョンと PC バージョンの両方が同じ Xbox Live 構成を共有します。</span><span class="sxs-lookup"><span data-stu-id="914f7-144">In this scenario, both the Xbox One and PC versions of a game share the same Xbox Live configuration.</span></span>

<span data-ttu-id="914f7-145">このシナリオは、既存の Xbox One XDK ゲームがあり、ゲームの UWP バージョンのためにクロスプレイ サポートを追加したいケースにも対応します。</span><span class="sxs-lookup"><span data-stu-id="914f7-145">This scenario also covers the case where you have an existing Xbox One XDK game, and want to add cross-play support for a UWP version of your game.</span></span>

<span data-ttu-id="914f7-146">クロスプレイを実装するには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="914f7-146">In order to implement cross-play, do the following:</span></span>

* **<span data-ttu-id="914f7-147">XDP を使用して XDK ゲームを構成し、公開します。</span><span class="sxs-lookup"><span data-stu-id="914f7-147">Use XDP to configure and publish your XDK game.</span></span>** <span data-ttu-id="914f7-148">パートナー センターは、この時点で Xbox One XDK ゲームをサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="914f7-148">Partner Center does not support Xbox One XDK games at this time.</span></span>
* **<span data-ttu-id="914f7-149">XDP で作成した単一の Xbox Live サービス構成を、ゲームの XDK バージョンと UWP バージョンの両方に使用します。</span><span class="sxs-lookup"><span data-stu-id="914f7-149">Use a single Xbox Live service configuration that you created in XDP for both the XDK and the UWP versions of a game.</span></span>** <span data-ttu-id="914f7-150">XDP の新しい機能により、ゲームの XDK バージョンと UWP バージョンで単一の Xbox Live サービス構成を共有できます。</span><span class="sxs-lookup"><span data-stu-id="914f7-150">XDP now has new features that allow a game to share a single Xbox Live service configuration between the XDK version and the UWP version of a game.</span></span>
* **<span data-ttu-id="914f7-151">取り込みして UWP ゲームを公開するには、パートナー センターを使用します。</span><span class="sxs-lookup"><span data-stu-id="914f7-151">Use Partner Center to ingest and publish your UWP game.</span></span>** <span data-ttu-id="914f7-152">ただし、ゲームが XDP で作成したサービス構成を使用して、Xbox Live サービスを構成するのにパートナー センターを使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="914f7-152">However, do not use Partner Center to configure Xbox Live services, as your game will use the service configuration that you created in XDP.</span></span>
* **<span data-ttu-id="914f7-153">XDP とパートナー センターで Xbox Live サービス構成を分割することはできません。</span><span class="sxs-lookup"><span data-stu-id="914f7-153">Do not split Xbox Live service configuration between XDP and Partner Center.</span></span>** <span data-ttu-id="914f7-154">XDP とパートナー センターは互いを認識されず、サービス構成を公開する 1 つのソースからその他のソースから公開された構成が上書きされます。</span><span class="sxs-lookup"><span data-stu-id="914f7-154">XDP and Partner Center are not aware of each other, and publishing a service configuration from one source overwrites the configuration published from the other source.</span></span> <span data-ttu-id="914f7-155">これが原因でユーザー データが失われ (実績の達成状況が失われる、ゲームのセーブ データが消去されるなど)、ユーザー エクスペリエンスが損なわれる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="914f7-155">This could cause user data to be lost (missing achievements, erased game saves, etc.) which can create a bad user experience.</span></span> <span data-ttu-id="914f7-156">この理由から、**クロスプレイ対応の XDK + UWP ゲームについては、Xbox Live サービス構成の 100% が XDP で行われることを要件とします。**</span><span class="sxs-lookup"><span data-stu-id="914f7-156">For this reason, **we require that 100% of Xbox Live service configuration is done in XDP for cross-play XDK + UWP games.**</span></span>

<span data-ttu-id="914f7-157">セルフサービスでは*ない*アイテムなど、このプロセスの詳細については「[クロスプレイ ゲームの概要](get-started-with-partner/get-started-with-cross-play-games.md)」ガイドを参照してください。</span><span class="sxs-lookup"><span data-stu-id="914f7-157">There's more detail on this process, including items which are *not* self-service in the [Getting started with cross-play games](get-started-with-partner/get-started-with-cross-play-games.md) guide</span></span>

### <a name="separate-versions-of-xbox-one-and-pcmobile-games-that-are-not-cross-play"></a><span data-ttu-id="914f7-158">クロスプレイに対応しない Xbox One ゲームと PC/モバイル ゲームのバージョンを分ける</span><span class="sxs-lookup"><span data-stu-id="914f7-158">Separate versions of Xbox One and PC/Mobile games that are not cross-play</span></span>
<span data-ttu-id="914f7-159">ゲームの Xbox One バージョンを、同じゲームの PC/モバイル バージョンとは分けたままにしておくこともできます。</span><span class="sxs-lookup"><span data-stu-id="914f7-159">You may decide to keep your Xbox One version of a game separate from the PC/Mobile version of the same game.</span></span> <span data-ttu-id="914f7-160">この場合、2 つの独立したプロダクトを作成し、Xbox One XDK 専用のガイダンスと PC/モバイル UWP ゲーム専用のガイダンスにそれぞれ従います。</span><span class="sxs-lookup"><span data-stu-id="914f7-160">In this case, you create two separate products, and follow the guidance for Xbox One XDK only and PC/Mobile UWP game only respectively.</span></span>

<span data-ttu-id="914f7-161">この場合、両方のバージョンの同じサービス構成を使うことはできません、作成する必要が手動で、ゲームの別のバージョンごとのサービス構成では、パートナー センターまたは XDP で適切にします。</span><span class="sxs-lookup"><span data-stu-id="914f7-161">You cannot use the same service configuration for both versions in this case, and you must manually create the service configuration for each separate version of your game, either in XDP or in Partner Center appropriately.</span></span>

<a name="get_ids"></a>

## <a name="get-your-ids"></a><span data-ttu-id="914f7-162">ID を取得する</span><span class="sxs-lookup"><span data-stu-id="914f7-162">Get your IDs</span></span>

<span data-ttu-id="914f7-163">Xbox Live サービスを有効にするには、開発キットとタイトルを構成するためのいくつかの ID を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="914f7-163">To enable Xbox Live services, you will need to obtain several IDs to configure your development kit and your title.</span></span> <span data-ttu-id="914f7-164">これらの ID は、Xbox Live サービスの構成を行うことによって取得できます。</span><span class="sxs-lookup"><span data-stu-id="914f7-164">These can be obtained by doing Xbox Live service configuration.</span></span>

<span data-ttu-id="914f7-165">XDP またはパートナー センターでタイトルがある現在ない場合は、上記のセクション[Xbox Live サービス構成ポータル](#xbox_live_portals)のガイダンスを参照してください。</span><span class="sxs-lookup"><span data-stu-id="914f7-165">If you do not currently have a title in XDP or Partner Center, see the above section [Xbox Live Service Configuration portals](#xbox_live_portals) for guidance.</span></span>

### <a name="critical-ids"></a><span data-ttu-id="914f7-166">重要な ID</span><span class="sxs-lookup"><span data-stu-id="914f7-166">Critical IDs</span></span>

<span data-ttu-id="914f7-167">Xbox One 用のタイトルおよびアプリケーションの開発には、サンドボックス ID、タイトル ID、および SCID という 3 つの ID が重要です。</span><span class="sxs-lookup"><span data-stu-id="914f7-167">There are three IDs which are critical for development of titles and applications for Xbox One: the sandbox ID, the Title ID, and the SCID.</span></span>

<span data-ttu-id="914f7-168">サンドボックス ID は開発キットを使用するために必要です。タイトル ID と SCID は初期開発には必要ありませんが、Xbox Live サービスを利用する場合に必要となります。</span><span class="sxs-lookup"><span data-stu-id="914f7-168">While it is necessary to have a sandbox ID to use a development kit, the Title ID and SCID are not required for initial development but are required for any use of Xbox Live services.</span></span> <span data-ttu-id="914f7-169">したがって、3 つの ID すべてを一度に取得することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="914f7-169">We therefore recommend that you obtain all three at once.</span></span>

#### <a name="sandbox-ids"></a><span data-ttu-id="914f7-170">サンドボックス ID</span><span class="sxs-lookup"><span data-stu-id="914f7-170">Sandbox IDs</span></span>

<span data-ttu-id="914f7-171">サンドボックスは、開発中に開発キットのコンテンツを分離し、クリーンな環境でタイトルを開発およびテストできるようにします。</span><span class="sxs-lookup"><span data-stu-id="914f7-171">The sandbox provides content isolation for your development kit during development, ensuring that you have a clean environment for developing and testing your title.</span></span> <span data-ttu-id="914f7-172">サンドボックス ID はサンドボックスを識別します。</span><span class="sxs-lookup"><span data-stu-id="914f7-172">The Sandbox ID identifies your sandbox.</span></span> <span data-ttu-id="914f7-173">本体は、一度に 1 つのサンドボックスにのみアクセスできます。ただし、1 つのサンドボックスには複数の本体からアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="914f7-173">A console may only access one sandbox at any one time, though one sandbox may be accessed by multiple consoles.</span></span>

<span data-ttu-id="914f7-174">サンド ボックス ID は大文字と小文字を区別します。</span><span class="sxs-lookup"><span data-stu-id="914f7-174">Sandbox IDs are case sensitive.</span></span>

**<span data-ttu-id="914f7-175">パートナー センター</span><span class="sxs-lookup"><span data-stu-id="914f7-175">Partner Center</span></span>**

<span data-ttu-id="914f7-176">パートナー センターでタイトルを構成する場合は、"Xbox Live] ルート構成ページで次に示すようにサンド ボックス ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="914f7-176">If you are configuring your title in Partner Center, you get your Sandbox ID on the "Xbox Live" root configuration page as shown below:</span></span>

![](images/getting_started/devcenter_sandbox_id.png)

**<span data-ttu-id="914f7-177">XDP</span><span class="sxs-lookup"><span data-stu-id="914f7-177">XDP</span></span>**

<span data-ttu-id="914f7-178">XDP でタイトルを構成する場合、概要ページで次に示すように、製品のサンド ボックス ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="914f7-178">If you are configuring your title on XDP, you get your Sandbox ID on the overview page for your product as shown below:</span></span>

![](images/getting_started/xdp_sandbox_id.png)

#### <a name="service-configuration-id-scid"></a><span data-ttu-id="914f7-179">サービス構成 ID (SCID)</span><span class="sxs-lookup"><span data-stu-id="914f7-179">Service Configuration ID (SCID)</span></span>

<span data-ttu-id="914f7-180">開発の過程では、イベント、実績、他のオンライン機能のホストを作成します。</span><span class="sxs-lookup"><span data-stu-id="914f7-180">As a part of development, you will create events, achievements, and a host of other online features.</span></span> <span data-ttu-id="914f7-181">これらはすべてサービス構成の一部であり、アクセスするには SCID が必要です。</span><span class="sxs-lookup"><span data-stu-id="914f7-181">These are all part of your service configuration, and require the SCID for access.</span></span>

<span data-ttu-id="914f7-182">SCID は大文字と小文字を区別します。</span><span class="sxs-lookup"><span data-stu-id="914f7-182">SCIDs are case sensitive.</span></span>

**<span data-ttu-id="914f7-183">パートナー センター</span><span class="sxs-lookup"><span data-stu-id="914f7-183">Partner Center</span></span>**

<span data-ttu-id="914f7-184">パートナー センターで SCID を取得するには、Xbox Live サービス] セクションに移動し、[ *Xbox Live のセットアップ*に移動します。</span><span class="sxs-lookup"><span data-stu-id="914f7-184">To retrieve your SCID in Partner Center, navigate to the Xbox Live Services section and go to *Xbox Live Setup* .</span></span> <span data-ttu-id="914f7-185">以下に示すテーブルに SCID が表示されます。</span><span class="sxs-lookup"><span data-stu-id="914f7-185">Your SCID is displayed in the table shown below:</span></span>

![](images/getting_started/devcenter_scid.png)

**<span data-ttu-id="914f7-186">XDP</span><span class="sxs-lookup"><span data-stu-id="914f7-186">XDP</span></span>**

<span data-ttu-id="914f7-187">XDP で SCID を取得するには、タイトルの下にある [Product Setup] に移動します。タイトル ID と SCID の両方が表示されます。</span><span class="sxs-lookup"><span data-stu-id="914f7-187">To retrieve your SCID on XDP, navigate to the "Product Setup" section under your title and you will see both the Title ID and SCID.</span></span>

![](images/getting_started/xdp_scid.png)

#### <a name="title-id"></a><span data-ttu-id="914f7-188">タイトル ID</span><span class="sxs-lookup"><span data-stu-id="914f7-188">Title ID</span></span>

<span data-ttu-id="914f7-189">タイトル ID は Xbox Live サービスに対してタイトルを一意に識別するためのものです。</span><span class="sxs-lookup"><span data-stu-id="914f7-189">The Title ID uniquely identifies your title to Xbox Live services.</span></span> <span data-ttu-id="914f7-190">タイトル ID は、タイトルの Live コンテンツ、ユーザー統計情報、実績などにユーザーがアクセスするために、また、Live のマルチプレイヤー機能を有効にするためにサービス全体を通して使用されます。</span><span class="sxs-lookup"><span data-stu-id="914f7-190">It is used throughout the services to enable your users to access your title's Live content, their user statistics, achievements, and so forth, and to enable Live multiplayer functionality.</span></span>

<span data-ttu-id="914f7-191">タイトル ID は、使用される方法および場所によって、大文字と小文字が区別されることがあります。</span><span class="sxs-lookup"><span data-stu-id="914f7-191">Title IDs can be case sensitive, depending on how and where they are used.</span></span>

**<span data-ttu-id="914f7-192">パートナー センター</span><span class="sxs-lookup"><span data-stu-id="914f7-192">Partner Center</span></span>**

<span data-ttu-id="914f7-193">パートナー センターでタイトル ID は、 *Xbox Live のセットアップ*] ページで SCID と同じテーブルにあります。</span><span class="sxs-lookup"><span data-stu-id="914f7-193">Your Title ID in Partner Center is found in the same table as the SCID in the *Xbox Live Setup* page.</span></span>

**<span data-ttu-id="914f7-194">XDP</span><span class="sxs-lookup"><span data-stu-id="914f7-194">XDP</span></span>**

<span data-ttu-id="914f7-195">XDP のタイトル ID は、SCID と同じ場所から取得されます。</span><span class="sxs-lookup"><span data-stu-id="914f7-195">Your Title ID on XDP is obtained from the same location as the SCID is.</span></span>

<a name="xbox_live_portals"></a>
