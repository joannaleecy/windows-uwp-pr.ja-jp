---
title: Xbox Live サービス構成
author: KevinAsgari
description: Xbox Live サービスをゲーム向けに構成する方法について説明します。
ms.assetid: 631c415b-5366-4a84-ba4f-4f513b229c32
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, サービス構成
ms.localizationpriority: medium
ms.openlocfilehash: e36e37802855747426184aa9d8cec0e6db77acd7
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4426773"
---
# <a name="xbox-live-service-configuration"></a><span data-ttu-id="9eb1c-104">Xbox Live サービス構成</span><span class="sxs-lookup"><span data-stu-id="9eb1c-104">Xbox Live service configuration</span></span>

## <a name="what-is-service-configuration"></a><span data-ttu-id="9eb1c-105">サービス構成とは</span><span class="sxs-lookup"><span data-stu-id="9eb1c-105">What is Service Configuration?</span></span>

<span data-ttu-id="9eb1c-106">[実績](achievements-2017/achievements.md)、[ランキング](leaderboards-and-stats-2017/leaderboards.md)、[マッチメイキング](multiplayer/multiplayer-concepts.md#smartmatch-matchmaking)などのいくつかの Xbox Live 機能についてよくご存じかもしれません。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-106">You may be familiar with some of the Xbox Live features such as [Achievements](achievements-2017/achievements.md), [Leaderboards](leaderboards-and-stats-2017/leaderboards.md) and [Matchmaking](multiplayer/multiplayer-concepts.md#smartmatch-matchmaking).</span></span>

<span data-ttu-id="9eb1c-107">ご存じでない場合のために、例としてランキングについて簡単に説明します。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-107">In case you are not, we'll briefly explain Leaderboards as an example.</span></span> <span data-ttu-id="9eb1c-108">ランキングを使用すると、プレイヤーは実績を表す値を確認し、他のプレイヤーと比較できます。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-108">Leaderboards allow players to see a value representing an accomplishment, in comparison to other players.</span></span>  <span data-ttu-id="9eb1c-109">たとえば、アーケード ゲームのハイスコアやレーシング ゲームのラップ タイム、一人称視点のシューティング ゲームのヘッドショットなどです。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-109">For example high scores in an arcade game, lap times in a racing game, or headshots in a first-person shooter.</span></span> <span data-ttu-id="9eb1c-110">ただし、アーケード マシンでは特定のマシンでプレイしたプレイヤーのトップ スコアのみが示されますが、Xbox Live では、世界中からのハイスコアを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-110">But unlike an arcade machine which only shows the top scores from the players who have played on that physical machine, with Xbox Live it is possible to display high scores from around the world.</span></span>

<span data-ttu-id="9eb1c-111">また、これを実現するためには、Xbox Live でランキングを認識できるよう、一度限りの構成を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-111">But for this to happen, you need to perform some one-time configuration so that Xbox Live knows about your leaderboard.</span></span> <span data-ttu-id="9eb1c-112">たとえば、値を昇順で並び替えるか、降順で並び替えるか、データのどの部分を並び替えるかなどを構成します。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-112">For example whether the values should be sorted in ascending or descending value, and what piece of data it should be sorting.</span></span>

<span data-ttu-id="9eb1c-113">多くの場合、この構成は[デベロッパー センター](http://dev.windows.com)で行われます。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-113">This configuration happens on [Dev Center](http://dev.windows.com) most of the time.</span></span> <span data-ttu-id="9eb1c-114">しかし、[Xbox 開発者ポータル (XDP)](http://xdp.xboxlive.com) を使用する開発者もいます。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-114">But certain developers will use [Xbox Developer Portal (XDP)](http://xdp.xboxlive.com).</span></span>

<span data-ttu-id="9eb1c-115">Xbox Live クリエーターズ プログラムの一部としてタイトルを開発している場合は、[デベロッパー センター](http://dev.windows.com)をご利用ください。「[Xbox Live の概要](get-started-with-creators/get-started-with-xbox-live-creators.md)」にその設定方法が説明されています。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-115">If you are a developing your title as part of the Xbox Live Creators Program, you use [Dev Center](http://dev.windows.com), and you can read [Getting Started With Xbox Live](get-started-with-creators/get-started-with-xbox-live-creators.md) to learn how to get set up.</span></span>

<span data-ttu-id="9eb1c-116">ID@Xbox の開発者である場合、または Microsoft パートナーのパブリッシャーと共同で作業を行っている場合は、続きをお読みください。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-116">If you are an ID@Xbox Developer or working with a publisher that is a Microsoft Partner, please read on.</span></span>

## <a name="choose-your-development-portal"></a><span data-ttu-id="9eb1c-117">開発ポータルを選択する</span><span class="sxs-lookup"><span data-stu-id="9eb1c-117">Choose your development portal</span></span>

<span data-ttu-id="9eb1c-118">前述のとおり、Xbox Live サービスの構成には、異なる 2 つのポータルを使用できます。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-118">As mentioned above, there are two different portals that can be used to configure Xbox Live Services.</span></span> <span data-ttu-id="9eb1c-119">[http://dev.windows.com](http://dev.windows.com) の Windows デベロッパー センター [http://xdp.xboxlive.com](http://xdp.xboxlive.com) の Xbox デベロッパー ポータル (XDP)。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-119">Windows Dev Center at [http://dev.windows.com](http://dev.windows.com) and the Xbox Development Portal (XDP) at [http://xdp.xboxlive.com](http://xdp.xboxlive.com).</span></span>

<span data-ttu-id="9eb1c-120">今後のすべてのタイトルでは Windows デベロッパー センターが推奨されますが、機能によっては引き続き XDP を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-120">Windows Dev Center is recommended for all titles going forward, but for certain features, you may still want to use XDP.</span></span> <span data-ttu-id="9eb1c-121">このセクションでは、どこでタイトルを構成したらよいかを説明します。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-121">This section will help advise you where to configure your title.</span></span>

<span data-ttu-id="9eb1c-122">によっては、選択したポータルの構成ページの特定のサービスに関する情報をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-122">You can find information about specific service configuration pages depending on your chosen portal:</span></span>

* [<span data-ttu-id="9eb1c-123">Windows デベロッパー センターの構成</span><span class="sxs-lookup"><span data-stu-id="9eb1c-123">Windows Dev Center configuration</span></span>](configure-xbl/windows-dev-center.md)
* <span data-ttu-id="9eb1c-124">[Xbox デベロッパー ポータルの構成](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/atoc-service-configuration)- このリンクにアクセスすると、Microsoft アカウント (MSA) Xbox Live のフル アクセスが有効になっている必要があります。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-124">[Xbox Development Portal configuration](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/atoc-service-configuration) - To access this link, you must have a Microsoft Account (MSA) that has been enabled for full Xbox Live access.</span></span>

<span data-ttu-id="9eb1c-125">既にタイトルを構成済みの場合は、「[ID を取得する](#get_ids)」まで下にスクロールして、タイトルの設定に必要なさまざまな ID を取得する方法をご覧いただけます。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-125">If you already have a title configured, you can scroll down to [Get your IDs](#get_ids) to learn how to get the various identifiers required to setup your title.</span></span>

### <a name="pcmobile-uwp-game-only"></a><span data-ttu-id="9eb1c-126">PC/Mobile UWP ゲーム専用</span><span class="sxs-lookup"><span data-stu-id="9eb1c-126">PC/Mobile UWP game only</span></span>
<span data-ttu-id="9eb1c-127">Windows 10 PC と Windows 10 モバイル デバイスの一方または両方でのみ動作する UWP ゲームを構成および管理する場合は、Windows デベロッパー センターをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-127">Windows Dev Center is recommended for configuring and managing UWP games that run only on Windows 10 PCs and/or Windows 10 mobile devices.</span></span>

#### <a name="using-xdp-to-configure-uwp-titles"></a><span data-ttu-id="9eb1c-128">XDP の使用による UWP タイトルの構成</span><span class="sxs-lookup"><span data-stu-id="9eb1c-128">Using XDP to configure UWP titles</span></span>

<span data-ttu-id="9eb1c-129">次のいずれかの要件がある場合は、UWP タイトルの構成に XDP を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-129">You may want to use XDP to configure UWP titles if you have one of the following requirements:</span></span>

1. <span data-ttu-id="9eb1c-130">アリーナを使用している。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-130">You are using Arena.</span></span>
2. <span data-ttu-id="9eb1c-131">XDP に、引き続き使用したい既存のユーザー、グループ、アクセス許可の設定がある。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-131">You have existing users, groups, and permissions setup on XDP that you want to keep using.</span></span>
3. <span data-ttu-id="9eb1c-132">Tournaments Tool や マルチプレイヤー セッション ディレクトリ セッション履歴ビューアーなど、XDP でのみ動作するツールを使用している。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-132">You are using tools which only work on XDP such as the Tournaments Tool or Multiplayer Session Directory session history viewer.</span></span>
4. <span data-ttu-id="9eb1c-133">Xbox One XDK ベースのゲームと、同じゲームの UWP PC/モバイル バージョンとの間のクロスプラットフォーム プレイ機能を持つタイトルを開発している。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-133">You are developing a title that will have cross-platform play between an Xbox One XDK based game and UWP PC/mobile version of the same game.</span></span>

<span data-ttu-id="9eb1c-134">これらのカテゴリのいずれも該当しない場合は、Windows デベロッパー センターを使用してください。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-134">If you don't fall into one of those categories, then you should use Windows Dev Center.</span></span> <span data-ttu-id="9eb1c-135">いずれかが該当する場合は、以下に示す XDP を使用して UWP タイトルを構成する方法をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-135">Otherwise you can see below for how to use XDP to configure a UWP title.</span></span>

<span data-ttu-id="9eb1c-136">XDP を使用した UWP アプリケーション用の Xbox Live サービスの構成に関して、いくつかの重要な注意事項があります。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-136">Using XDP to configure Xbox Live Services for UWP applications has a few important caveats:</span></span>

* **<span data-ttu-id="9eb1c-137">ゲームの Xbox Live サービス構成をいったん XDP で CERT/RETAIL に公開すると、後戻りできません!</span><span class="sxs-lookup"><span data-stu-id="9eb1c-137">Once a game's Xbox Live service configuration is published to CERT/RETAIL in XDP, there is no going back!</span></span>** <span data-ttu-id="9eb1c-138">そのゲームの Xbox Live サービス構成は、ゲーム タイトルの寿命が終わるまで XDP にとどまる必要があります。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-138">The Xbox Live service configuration for that game needs to remain in XDP for the life of the game title.</span></span>
* **<span data-ttu-id="9eb1c-139">XDP から Windows デベロッパー センターへの移行パスはありません。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-139">There is no migration path from XDP to Windows Dev Center.</span></span>** <span data-ttu-id="9eb1c-140">Xbox Live 構成を XDP で開始する場合、構成を移動したい場合は Windows デベロッパー センターで構成を手動で作成し直す必要があります。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-140">If you start your Xbox Live configuration in XDP, you must manually recreate it in Windows Dev Center if you want to move it.</span></span>

<span data-ttu-id="9eb1c-141">これら 2 点の考慮事項により、PC/モバイル ゲームでは Windows デベロッパー センターを使用することをお勧めします。ただし、上記カテゴリのいずれかに該当する場合は除きます。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-141">Given these two considerations, we recommended using Windows Dev Center for PC/Mobile games, unless you fall into one of the categories described above.</span></span>

### <a name="cross-play-between-xbox-one-and-pcmobile-games"></a><span data-ttu-id="9eb1c-142">Xbox One ゲームと PC/モバイル ゲーム間のクロスプレイ</span><span class="sxs-lookup"><span data-stu-id="9eb1c-142">Cross-play between Xbox One and PC/Mobile games</span></span> ###
<span data-ttu-id="9eb1c-143">クロスプレイと呼ばれる、Xbox One および PC 間のクロスデバイス ゲーミングは、注目に値する Windows 10 エクスペリエンスです。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-143">Cross-device gaming between the Xbox One and the PC, known as cross-play, is a showcase Windows 10 experience.</span></span> <span data-ttu-id="9eb1c-144">このシナリオでは、ゲームの Xbox One バージョンと PC バージョンの両方が同じ Xbox Live 構成を共有します。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-144">In this scenario, both the Xbox One and PC versions of a game share the same Xbox Live configuration.</span></span>

<span data-ttu-id="9eb1c-145">このシナリオは、既存の Xbox One XDK ゲームがあり、ゲームの UWP バージョンのためにクロスプレイ サポートを追加したいケースにも対応します。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-145">This scenario also covers the case where you have an existing Xbox One XDK game, and want to add cross-play support for a UWP version of your game.</span></span>

<span data-ttu-id="9eb1c-146">クロスプレイを実装するには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-146">In order to implement cross-play, do the following:</span></span>

* **<span data-ttu-id="9eb1c-147">XDP を使用して XDK ゲームを構成し、公開します。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-147">Use XDP to configure and publish your XDK game.</span></span>** <span data-ttu-id="9eb1c-148">Windows デベロッパー センターは現時点で Xbox One XDK ゲームをサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-148">The Windows Dev Center does not support Xbox One XDK games at this time.</span></span>
* **<span data-ttu-id="9eb1c-149">XDP で作成した単一の Xbox Live サービス構成を、ゲームの XDK バージョンと UWP バージョンの両方に使用します。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-149">Use a single Xbox Live service configuration that you created in XDP for both the XDK and the UWP versions of a game.</span></span>** <span data-ttu-id="9eb1c-150">XDP の新しい機能により、ゲームの XDK バージョンと UWP バージョンで単一の Xbox Live サービス構成を共有できます。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-150">XDP now has new features that allow a game to share a single Xbox Live service configuration between the XDK version and the UWP version of a game.</span></span>
* **<span data-ttu-id="9eb1c-151">Windows デベロッパー センターを使用して UWP ゲームを取り込み、公開します。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-151">Use the Windows Dev Center to ingest and publish your UWP game.</span></span>** <span data-ttu-id="9eb1c-152">ただし、ゲームで使用するのは XDP で作成したサービス構成なので、Windows デベロッパー センターを使用して Xbox Live サービスを構成しないでください。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-152">However, do not use the Windows Dev Center to configure Xbox Live services, as your game will use the service configuration that you created in XDP.</span></span>
* **<span data-ttu-id="9eb1c-153">Xbox Live サービス構成を XDP と Windows デベロッパー センターに分割しないでください。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-153">Do not split Xbox Live service configuration between XDP and the Windows Dev Center.</span></span>** <span data-ttu-id="9eb1c-154">XDP と Windows デベロッパー センターは互いを認識せず、一方のソースからサービス構成を公開すると、もう一方のソースから公開された構成が上書きされます。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-154">XDP and the Windows Dev Center are not aware of each other, and publishing a service configuration from one source overwrites the configuration published from the other source.</span></span> <span data-ttu-id="9eb1c-155">これが原因でユーザー データが失われ (実績の達成状況が失われる、ゲームのセーブ データが消去されるなど)、ユーザー エクスペリエンスが損なわれる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-155">This could cause user data to be lost (missing achievements, erased game saves, etc.) which can create a bad user experience.</span></span> <span data-ttu-id="9eb1c-156">この理由から、**クロスプレイ対応の XDK + UWP ゲームについては、Xbox Live サービス構成の 100% が XDP で行われることを要件とします。**</span><span class="sxs-lookup"><span data-stu-id="9eb1c-156">For this reason, **we require that 100% of Xbox Live service configuration is done in XDP for cross-play XDK + UWP games.**</span></span>

<span data-ttu-id="9eb1c-157">セルフサービスでは*ない*アイテムなど、このプロセスの詳細については「[クロスプレイ ゲームの概要](get-started-with-partner/get-started-with-cross-play-games.md)」ガイドを参照してください。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-157">There's more detail on this process, including items which are *not* self-service in the [Getting started with cross-play games](get-started-with-partner/get-started-with-cross-play-games.md) guide</span></span>

### <a name="separate-versions-of-xbox-one-and-pcmobile-games-that-are-not-cross-play"></a><span data-ttu-id="9eb1c-158">クロスプレイに対応しない Xbox One ゲームと PC/モバイル ゲームのバージョンを分ける</span><span class="sxs-lookup"><span data-stu-id="9eb1c-158">Separate versions of Xbox One and PC/Mobile games that are not cross-play</span></span>
<span data-ttu-id="9eb1c-159">ゲームの Xbox One バージョンを、同じゲームの PC/モバイル バージョンとは分けたままにしておくこともできます。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-159">You may decide to keep your Xbox One version of a game separate from the PC/Mobile version of the same game.</span></span> <span data-ttu-id="9eb1c-160">この場合、2 つの独立したプロダクトを作成し、Xbox One XDK 専用のガイダンスと PC/モバイル UWP ゲーム専用のガイダンスにそれぞれ従います。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-160">In this case, you create two separate products, and follow the guidance for Xbox One XDK only and PC/Mobile UWP game only respectively.</span></span>

<span data-ttu-id="9eb1c-161">この場合、両方のバージョンで同じサービス構成を使用することはできず、XDP または Windows デベロッパー センターのどちらか適切なほうで、ゲームの独立したバージョンごとにサービス構成を手動で作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-161">You cannot use the same service configuration for both versions in this case, and you must manually create the service configuration for each separate version of your game, either in XDP or in the Windows Dev Center appropriately.</span></span>

<a name="get_ids"></a>

## <a name="get-your-ids"></a><span data-ttu-id="9eb1c-162">ID を取得する</span><span class="sxs-lookup"><span data-stu-id="9eb1c-162">Get your IDs</span></span>

<span data-ttu-id="9eb1c-163">Xbox Live サービスを有効にするには、開発キットとタイトルを構成するためのいくつかの ID を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-163">To enable Xbox Live services, you will need to obtain several IDs to configure your development kit and your title.</span></span> <span data-ttu-id="9eb1c-164">これらの ID は、Xbox Live サービスの構成を行うことによって取得できます。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-164">These can be obtained by doing Xbox Live service configuration.</span></span>

<span data-ttu-id="9eb1c-165">XDP またはデベロッパー センターにタイトルが現在ない場合、ガイダンスについて上記のセクション「[Xbox Live サービス構成ポータル](#xbox_live_portals)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-165">If you do not currently have a title in XDP or Dev Center, see the above section [Xbox Live Service Configuration portals](#xbox_live_portals) for guidance.</span></span>

### <a name="critical-ids"></a><span data-ttu-id="9eb1c-166">重要な ID</span><span class="sxs-lookup"><span data-stu-id="9eb1c-166">Critical IDs</span></span>

<span data-ttu-id="9eb1c-167">Xbox One 用のタイトルおよびアプリケーションの開発には、サンドボックス ID、タイトル ID、および SCID という 3 つの ID が重要です。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-167">There are three IDs which are critical for development of titles and applications for Xbox One: the sandbox ID, the Title ID, and the SCID.</span></span>

<span data-ttu-id="9eb1c-168">サンドボックス ID は開発キットを使用するために必要です。タイトル ID と SCID は初期開発には必要ありませんが、Xbox Live サービスを利用する場合に必要となります。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-168">While it is necessary to have a sandbox ID to use a development kit, the Title ID and SCID are not required for initial development but are required for any use of Xbox Live services.</span></span> <span data-ttu-id="9eb1c-169">したがって、3 つの ID すべてを一度に取得することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-169">We therefore recommend that you obtain all three at once.</span></span>

#### <a name="sandbox-ids"></a><span data-ttu-id="9eb1c-170">サンドボックス ID</span><span class="sxs-lookup"><span data-stu-id="9eb1c-170">Sandbox IDs</span></span>

<span data-ttu-id="9eb1c-171">サンドボックスは、開発中に開発キットのコンテンツを分離し、クリーンな環境でタイトルを開発およびテストできるようにします。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-171">The sandbox provides content isolation for your development kit during development, ensuring that you have a clean environment for developing and testing your title.</span></span> <span data-ttu-id="9eb1c-172">サンドボックス ID はサンドボックスを識別します。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-172">The Sandbox ID identifies your sandbox.</span></span> <span data-ttu-id="9eb1c-173">本体は、一度に 1 つのサンドボックスにのみアクセスできます。ただし、1 つのサンドボックスには複数の本体からアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-173">A console may only access one sandbox at any one time, though one sandbox may be accessed by multiple consoles.</span></span>

<span data-ttu-id="9eb1c-174">サンド ボックス ID は大文字と小文字を区別します。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-174">Sandbox IDs are case sensitive.</span></span>

**<span data-ttu-id="9eb1c-175">デベロッパー センター</span><span class="sxs-lookup"><span data-stu-id="9eb1c-175">Dev Center</span></span>**

<span data-ttu-id="9eb1c-176">デベロッパー センターでタイトルを構成する場合、以下に示す [Xbox Live] ルート構成ページでサンドボックス ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-176">If you are configuring your title on Dev Center, you get your Sandbox ID on the "Xbox Live" root configuration page as shown below:</span></span>

![](images/getting_started/devcenter_sandbox_id.png)

**<span data-ttu-id="9eb1c-177">XDP</span><span class="sxs-lookup"><span data-stu-id="9eb1c-177">XDP</span></span>**

<span data-ttu-id="9eb1c-178">XDP でタイトルを構成する場合、以下に示すプロダクトの概要ページでサンドボックス ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-178">If you are configuring your title on XDP, you get your Sandbox ID on the the overview page for your product as shown below:</span></span>

![](images/getting_started/xdp_sandbox_id.png)

#### <a name="service-configuration-id-scid"></a><span data-ttu-id="9eb1c-179">サービス構成 ID (SCID)</span><span class="sxs-lookup"><span data-stu-id="9eb1c-179">Service Configuration ID (SCID)</span></span>

<span data-ttu-id="9eb1c-180">開発の過程では、イベント、実績、他のオンライン機能のホストを作成します。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-180">As a part of development, you will create events, achievements, and a host of other online features.</span></span> <span data-ttu-id="9eb1c-181">これらはすべてサービス構成の一部であり、アクセスするには SCID が必要です。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-181">These are all part of your service configuration, and require the SCID for access.</span></span>

<span data-ttu-id="9eb1c-182">SCID は大文字と小文字を区別します。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-182">SCIDs are case sensitive.</span></span>

**<span data-ttu-id="9eb1c-183">デベロッパー センター</span><span class="sxs-lookup"><span data-stu-id="9eb1c-183">Dev Center</span></span>**

<span data-ttu-id="9eb1c-184">デベロッパー センターで SCID を取得するには、[Xbox Live サービス] セクション、*[Xbox Live Setup]* (Xbox Live のセットアップ) の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-184">To retrieve your SCID on Dev Center, navigate to the Xbox Live Services section and go to *Xbox Live Setup* .</span></span> <span data-ttu-id="9eb1c-185">以下に示すテーブルに SCID が表示されます。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-185">Your SCID is displayed in the table shown below:</span></span>

![](images/getting_started/devcenter_scid.png)

**<span data-ttu-id="9eb1c-186">XDP</span><span class="sxs-lookup"><span data-stu-id="9eb1c-186">XDP</span></span>**

<span data-ttu-id="9eb1c-187">XDP で SCID を取得するには、タイトルの下にある [Product Setup] に移動します。タイトル ID と SCID の両方が表示されます。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-187">To retrieve your SCID on XDP, navigate to the "Product Setup" section under your title and you will see both the Title ID and SCID.</span></span>

![](images/getting_started/xdp_scid.png)

#### <a name="title-id"></a><span data-ttu-id="9eb1c-188">タイトル ID</span><span class="sxs-lookup"><span data-stu-id="9eb1c-188">Title ID</span></span>

<span data-ttu-id="9eb1c-189">タイトル ID は Xbox Live サービスに対してタイトルを一意に識別するためのものです。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-189">The Title ID uniquely identifies your title to Xbox Live services.</span></span> <span data-ttu-id="9eb1c-190">タイトル ID は、タイトルの Live コンテンツ、ユーザー統計情報、実績などにユーザーがアクセスするために、また、Live のマルチプレイヤー機能を有効にするためにサービス全体を通して使用されます。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-190">It is used throughout the services to enable your users to access your title's Live content, their user statistics, achievements, and so forth, and to enable Live multiplayer functionality.</span></span>

<span data-ttu-id="9eb1c-191">タイトル ID は、使用される方法および場所によって、大文字と小文字が区別されることがあります。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-191">Title IDs can be case sensitive, depending on how and where they are used.</span></span>

**<span data-ttu-id="9eb1c-192">デベロッパー センター</span><span class="sxs-lookup"><span data-stu-id="9eb1c-192">Dev Center</span></span>**

<span data-ttu-id="9eb1c-193">デベロッパー センターでタイトル ID を確認するには、*[Xbox Live Setup]* (Xbox Live のセットアップ) ページの SCID と同じテーブルを参照してください。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-193">Your Title ID on Dev Center is found in the same table as the SCID in the *Xbox Live Setup* page.</span></span>

**<span data-ttu-id="9eb1c-194">XDP</span><span class="sxs-lookup"><span data-stu-id="9eb1c-194">XDP</span></span>**

<span data-ttu-id="9eb1c-195">XDP のタイトル ID は、SCID と同じ場所から取得されます。</span><span class="sxs-lookup"><span data-stu-id="9eb1c-195">Your Title ID on XDP is obtained from the same location as the SCID is.</span></span>

<a name="xbox_live_portals"></a>
