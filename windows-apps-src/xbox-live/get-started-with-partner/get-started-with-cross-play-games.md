---
title: クロスプレイ ゲームの概要
description: PC と Xbox One 本体の両方で実行されるクロスプレイ ゲームを開発する方法について説明します。
ms.assetid: 6c8e9d08-a3d2-4bfc-90ee-03c8fde3e66d
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, クロスプレイ, Play Anywhere
ms.localizationpriority: medium
ms.openlocfilehash: 79b0c211291d8a27456126ea0378f9093d1dccab
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57646727"
---
# <a name="get-started-with-cross-play-games"></a><span data-ttu-id="ae29b-104">クロスプレイ ゲームの概要</span><span class="sxs-lookup"><span data-stu-id="ae29b-104">Get started with cross-play games</span></span>

## <a name="summary"></a><span data-ttu-id="ae29b-105">概要</span><span class="sxs-lookup"><span data-stu-id="ae29b-105">Summary</span></span>

<span data-ttu-id="ae29b-106">Windows 10 の登場以降、ゲーム開発者は、1 つの製品を Xbox One (XDK ゲームとして) と Windows 10 (UWP ゲームとして) の両方に対応できるようにリリースすることが可能になっています。</span><span class="sxs-lookup"><span data-stu-id="ae29b-106">With the launch of Windows 10, game developers will be able to release single products both on Xbox One (as an XDK game) and Windows 10 (as a UWP game).</span></span> <span data-ttu-id="ae29b-107">また場合によっては、開発者はゲームでクロスプレイを有効にする必要があります。このようなゲームでは、ゲームの Xbox One バージョンと Windows 10 バージョンの間で、マルチプレイヤー、セーブ データ、実績などの Xbox Live サービスが統合されます。</span><span class="sxs-lookup"><span data-stu-id="ae29b-107">In some cases, developers will want to enable cross-play for these games, where the Xbox One and Windows 10 versions of their game are unified across Xbox Live services like Multiplayer, Game Save, Achievements, and more.</span></span> <span data-ttu-id="ae29b-108">クロスプレイを有効にするには、ゲームの XDK バージョンと UWP バージョンの両方で、1 つのタイトル ID と Xbox Live サービス構成を共有します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-108">To enable cross-play, these games will share a single Title ID and Xbox Live service configuration across both the XDK and UWP versions of the game.</span></span>

<span data-ttu-id="ae29b-109">現在、XDK+UWP ゲームを取り込んでクロスプレイ ゲームを開発するには、次の 4 つの主要な手順が必要になります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-109">Ingesting an XDK+UWP today game requires 4 major steps:</span></span>

1.  <span data-ttu-id="ae29b-110">パートナー センターで、UWP の製品を作成します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-110">Create your UWP product in Partner Center</span></span>

2.  <span data-ttu-id="ae29b-111">XDP で XDK ゲームを作成し、XBL 構成を共有するプラットフォームを選択する</span><span class="sxs-lookup"><span data-stu-id="ae29b-111">Create your XDK game in XDP, selecting the platforms you want to share XBL configuration across</span></span>

3.  <span data-ttu-id="ae29b-112">UWP 製品の情報を XDP の XDK 製品にバインドする</span><span class="sxs-lookup"><span data-stu-id="ae29b-112">Bind your UWP product information to your XDK product in XDP</span></span>

4.  <span data-ttu-id="ae29b-113">XDP で Xbox Live を構成して公開する</span><span class="sxs-lookup"><span data-stu-id="ae29b-113">Configure and publish Xbox Live through XDP</span></span>

<span data-ttu-id="ae29b-114">このドキュメントでは、これら 4 つの手順について詳しく説明し、Xbox の開発者ができるだけ簡単に XDK+UWP のクロスプラットフォーム ゲームを取り込めるようにすることが目的です。</span><span class="sxs-lookup"><span data-stu-id="ae29b-114">The purpose of this document is to further detail these 4 steps to make it as easy as possible for Xbox employees to ingest XDK+UWP cross-plat games</span></span>

## <a name="terminology"></a><span data-ttu-id="ae29b-115">用語</span><span class="sxs-lookup"><span data-stu-id="ae29b-115">Terminology</span></span>

### <a name="scenario-terms"></a><span data-ttu-id="ae29b-116">シナリオに関する用語</span><span class="sxs-lookup"><span data-stu-id="ae29b-116">Scenario Terms</span></span>

1.  <span data-ttu-id="ae29b-117">クロス プレイします。1 つ以上のプラットフォームでは、リリースが、1 つの Xbox を共有するゲームは、ID のタイトルし、サービス構成。</span><span class="sxs-lookup"><span data-stu-id="ae29b-117">Cross-Play: A game that is releasing on more than one platform, but shares a single Xbox title ID and service configuration.</span></span> <span data-ttu-id="ae29b-118">結果として、ゲームの両方のバージョンが同じ Xbox Live 構成 (実績、ランキング、セーブ データ、マルチプレイヤーなど) を共有することになります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-118">The end result is that both versions of the game share the same Xbox Live configuration - achievements, leaderboards, game saves, multiplayer, and more.</span></span>

2.  <span data-ttu-id="ae29b-119">パートナー センター:[ポータル](https://partner.microsoft.com/dashboard)構成で使用する UWP 開発今日とセットアップ Xbox Live UWP 用のアプリ id を予約することができます。</span><span class="sxs-lookup"><span data-stu-id="ae29b-119">Partner Center: The [portal](https://partner.microsoft.com/dashboard) where you can reserve app identities for use in UWP development today and setup Xbox Live configuration for UWP.</span></span>

3.  <span data-ttu-id="ae29b-120">XDP:Xbox 開発者ポータルが現在存在取り込むは、構成、および Xbox One XDK と SRA のゲームを公開し、取り込み、構成、および XDK + UWP のクロス Play ゲームを公開する追加の使用が表示されます。</span><span class="sxs-lookup"><span data-stu-id="ae29b-120">XDP: The Xbox Developer Portal, which exists today to ingest, configure, and publish Xbox One XDK and SRA games, and will see added use to ingest, configure, and publish XDK+UWP Cross-Play games.</span></span>

### <a name="identity-terms"></a><span data-ttu-id="ae29b-121">ID に関する用語</span><span class="sxs-lookup"><span data-stu-id="ae29b-121">Identity Terms</span></span>

1.  <span data-ttu-id="ae29b-122">タイトルの ID。これは、各ゲームに Xbox Live を識別するために使用される、Xbox タイトル ID です。</span><span class="sxs-lookup"><span data-stu-id="ae29b-122">Title ID: This is the Xbox Title ID, used to identify each game to Xbox Live.</span></span> <span data-ttu-id="ae29b-123">タイトル ID は 1 つの製品に対応します。ただし、1 つの製品が複数のプラットフォームに対応する場合があります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-123">A Title ID maps to a single product, which may span multiple platforms.</span></span>

2.  <span data-ttu-id="ae29b-124">サービス構成の ID (SCID):(タイトル、ID によって識別される) 各 Xbox タイトルが、対応するサービス構成の ID (SCID とも呼ばれます)。</span><span class="sxs-lookup"><span data-stu-id="ae29b-124">Service Configuration ID (SCID): Each Xbox title (identified by a Title ID) has a corresponding Service Configuration ID (aka SCID).</span></span> <span data-ttu-id="ae29b-125">この ID により、Xbox Live はタイトルを操作するときに使用するルール/構成を一意に識別できます。</span><span class="sxs-lookup"><span data-stu-id="ae29b-125">This ID allows Xbox Live to uniquely identify the rules / configuration to use when interacting with your title.</span></span>

3.  <span data-ttu-id="ae29b-126">パッケージ ファミリ名 (PFN):これは、パートナー センターで作成された各製品に割り当てられている id です。</span><span class="sxs-lookup"><span data-stu-id="ae29b-126">Package Family Name (PFN): This is an identity assigned to each product created in Partner Center.</span></span> <span data-ttu-id="ae29b-127">このパートナー センターの製品の id に、UWP をバインドすると後でこの PFN かかります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-127">Once you bind your UWP to the identity of this Partner Center product, it will take on this PFN.</span></span> <span data-ttu-id="ae29b-128">PFN は一意の製品 ID であり、複数のプラットフォームに対応する場合があります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-128">PFNs are unique product identifiers, which may span multiple platforms.</span></span> <span data-ttu-id="ae29b-129">PFN は Xbox タイトル ID と 1 対 1 に対応します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-129">PFNs are 1:1 with Xbox Title IDs.</span></span>

4.  <span data-ttu-id="ae29b-130">MSA アプリ ID:呼ばれます MSA クライアント ID、パートナー センターでは、製品の作成時に、MSA によって割り当てられた別のアプリ id になります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-130">MSA App ID: Also known as MSA Client ID, this is another app identity assigned by MSA at product creation time in Partner Center.</span></span> <span data-ttu-id="ae29b-131">この ID によって、Microsoft サービスはアプリを識別することができます。</span><span class="sxs-lookup"><span data-stu-id="ae29b-131">This identity helps Microsoft services identify your app.</span></span> <span data-ttu-id="ae29b-132">MSA アプリ ID は PFN と 1 対 1 に対応します (したがって Xbox タイトル ID とも 1 対 1 に対応します)。</span><span class="sxs-lookup"><span data-stu-id="ae29b-132">MSA App IDs are 1:1 with PFNs (and accordingly with Xbox Title IDs).</span></span>

## <a name="scenario-overview"></a><span data-ttu-id="ae29b-133">シナリオの概要</span><span class="sxs-lookup"><span data-stu-id="ae29b-133">Scenario Overview</span></span>

### <a name="what-is-cross-play"></a><span data-ttu-id="ae29b-134">クロスプレイとは</span><span class="sxs-lookup"><span data-stu-id="ae29b-134">What is Cross-Play?</span></span>

<span data-ttu-id="ae29b-135">注目すべき Windows 10 エクスペリエンスの 1 つであるクロスプレイとは、Xbox One と PC といった異なるデバイス間でゲームをプレイすることです。ゲームは複数のデバイス バージョンの間で 1 つの Xbox Live 構成を共有し、クロスデバイス マルチプレイヤー、実績とランキング、セーブ データなどのシナリオを実現します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-135">A showcase Windows 10 experience; cross-play is cross-device gaming between the Xbox One and PC, with games sharing a single Xbox Live configuration across device versions to light up scenarios like cross-device multiplayer, achievements & leaderboards, and game saves.</span></span>

### <a name="what-are-the-pros-and-cons-of-cross-play"></a><span data-ttu-id="ae29b-136">クロスプレイの長所と短所</span><span class="sxs-lookup"><span data-stu-id="ae29b-136">What are the pros and cons of Cross-Play?</span></span>

<span data-ttu-id="ae29b-137">ゲームの XDK と UWP のバージョンで以下のことを行いたい場合、クロスプレイが適しています。</span><span class="sxs-lookup"><span data-stu-id="ae29b-137">Cross-Play is likely the right approach for you if you want the XDK and UWP versions of your game to:</span></span>

-   <span data-ttu-id="ae29b-138">マルチ プレーヤーのクロス デバイス (Xbox One とに参加します。PC) で少なくとも 1 つのマルチ プレーヤー ゲーム モード</span><span class="sxs-lookup"><span data-stu-id="ae29b-138">Engage in cross-device multiplayer (Xbox One vs. PC) in at least one multiplayer game mode</span></span>

-   <span data-ttu-id="ae29b-139">1 つのセーブ データを共有し、ユーザーが両方のデバイスで利用できるようにする</span><span class="sxs-lookup"><span data-stu-id="ae29b-139">Share a single game save that the user can use on both devices</span></span>

-   <span data-ttu-id="ae29b-140">両方のデバイスで付加的に達成できる、実績とゲーマースコア/チャレンジ/ランキングの単一のセットを設定する</span><span class="sxs-lookup"><span data-stu-id="ae29b-140">Have a single set of achievements & Gamerscore / challenges / leaderboards that they can additively progress against on both devices</span></span>

<span data-ttu-id="ae29b-141">以下の場合にはクロスプレイは適していません。</span><span class="sxs-lookup"><span data-stu-id="ae29b-141">Cross-Play is likely not the right approach for you if:</span></span>

-   <span data-ttu-id="ae29b-142">どのようなマルチプレイヤー ゲーム モードでも、ゲームの PC プレイヤーと Xbox One プレイヤーが、複数デバイスを対象としたマルチプレイヤー ゲームに参加できないようにする</span><span class="sxs-lookup"><span data-stu-id="ae29b-142">You want to prevent the PC and Xbox One players of your game from engaging in multiplayer across devices in any and all multiplayer game modes</span></span>

-   <span data-ttu-id="ae29b-143">Xbox One と PC のセーブ データを分離しておく必要がある (セキュリティや信頼性を理由とする場合など)</span><span class="sxs-lookup"><span data-stu-id="ae29b-143">You want to keep Xbox One and PC game save separate (perhaps for security or trust reasons)</span></span>

-   <span data-ttu-id="ae29b-144">ゲームの Xbox One バージョンと PC バージョンでゲーマースコアを分けておく必要がある (Xbox One と PC 両方のバージョンを購入したユーザーが、まとめて 1000 ゲーマースコアを受け取るのではなく、プラットフォームごとに 1000 ゲーマースコアを受け取るようにする)</span><span class="sxs-lookup"><span data-stu-id="ae29b-144">You want the Xbox One and PC versions of your game to have separate Gamerscore (aka users who buy both Xbox One and PC can receive 1000 Gamerscore for each platform instead of a shared 1000)</span></span>

<span data-ttu-id="ae29b-145">一般に、クロスプレイが最も役立つのは次のような場合です。</span><span class="sxs-lookup"><span data-stu-id="ae29b-145">In general, Cross-Play adds the most value to:</span></span>

-   <span data-ttu-id="ae29b-146">ゲームの Xbox One バージョンと PC バージョンの間の連続性が特徴の無料プレイ/Xbox Play Anywhere ゲーム</span><span class="sxs-lookup"><span data-stu-id="ae29b-146">Free-to-Play / Xbox Play Anywhere games, that emphasize continuity between the Xbox One and PC versions of the game</span></span>

-   <span data-ttu-id="ae29b-147">Xbox One と PC 間のクロスデバイス マルチプレイヤーに対応したゲーム</span><span class="sxs-lookup"><span data-stu-id="ae29b-147">Games featuring cross-device multiplayer between Xbox One and PC</span></span>

<span data-ttu-id="ae29b-148">**注**:クロス プレイでは、両方をゲーム XDK、既に出荷されたが、UWP バージョンの追加ができるだけでなく、ゲームの XDK および UWP のバージョンを同時にリリースする新しいゲームで使用できます。</span><span class="sxs-lookup"><span data-stu-id="ae29b-148">**NOTE**: Cross-Play is available both to new games that are releasing the XDK and UWP versions of their game simultaneously, as well as games that have already shipped an XDK, but are adding a UWP version.</span></span>

### <a name="what-are-the-restrictions-of-cross-play"></a><span data-ttu-id="ae29b-149">クロスプレイの制限事項</span><span class="sxs-lookup"><span data-stu-id="ae29b-149">What are the restrictions of Cross-Play?</span></span>

<span data-ttu-id="ae29b-150">Xbox One が UWP ゲームをサポートするようになるまでは、クロスプレイ ゲームには、ゲームの XDK バージョン (Xbox One 本体用) と UWP バージョン (Windows 10 PC 用) が必要です。</span><span class="sxs-lookup"><span data-stu-id="ae29b-150">Until Xbox One supports UWP games, Cross-Play games require an XDK (for Xbox One console) and UWP (for Windows 10 PC) version of the game.</span></span>

<span data-ttu-id="ae29b-151">XDK+UWP のすべてのクロスプレイ ゲームにはいくつかの重要な制限事項があります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-151">Any XDK + UWP Cross-Play game comes with some important restrictions:</span></span>

1.  <span data-ttu-id="ae29b-152">**XDK タイトルは XDP に取り込む必要があります**。</span><span class="sxs-lookup"><span data-stu-id="ae29b-152">**XDK titles must be ingested in XDP**.</span></span> <span data-ttu-id="ae29b-153">両方、サービスの構成とメインライン発行エクスペリエンスから、パートナー センターをベースの XDK タイトルをサポートするために搭載されていません。</span><span class="sxs-lookup"><span data-stu-id="ae29b-153">Both from a service configuration and mainline publishing experience, Partner Center is not equipped to support XDK based titles.</span></span>

2.  <span data-ttu-id="ae29b-154">**XDP で作成した 1 つのサービス構成を、ゲームの XDK バージョンと UWP バージョンの両方で使用できます**。</span><span class="sxs-lookup"><span data-stu-id="ae29b-154">**A single service configuration created in XDP can be used both by the XDK and UWP version of a game**.</span></span> <span data-ttu-id="ae29b-155">ゲームの XDK バージョンと UWP バージョンで 1 つのサービス構成を共有できる新しい機能が XDP に追加されています。</span><span class="sxs-lookup"><span data-stu-id="ae29b-155">We’ve added new features to XDP to allow a game to share a single service configuration between its XDK and UWP versions.</span></span> <span data-ttu-id="ae29b-156">UWP バージョンは、パートナー センターでのパッケージ用にパブリッシュする必要があります]、[カタログがすべてのサービス構成の公開を XDP で実行できます。</span><span class="sxs-lookup"><span data-stu-id="ae29b-156">The UWP version will still need to be published in Partner Center for packages / catalog, but all service configuration publishing can be done in XDP.</span></span>

3.  <span data-ttu-id="ae29b-157">**サービスの構成は XDP とパートナー センターの間で分割することはできません**します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-157">**Service configuration cannot be split between XDP and Partner Center**.</span></span> <span data-ttu-id="ae29b-158">XDP とパートナー センターでは、1 つ別の – から別の発行、既存の 1 つの上書きで発行認識しません。</span><span class="sxs-lookup"><span data-stu-id="ae29b-158">XDP and Partner Center are not aware of one another – publishing in one over-writes any existing publishes from the other.</span></span> <span data-ttu-id="ae29b-159">これにより、サービス構成が復元できないほど壊れたり、非常に悪いユーザー エクスペリエンス (実績やセーブ データの消失など) が生じる可能性があります。これを避けるため、XDK+UWP のクロスプレイ ゲーム用のサービス構成は、すべて XDP で行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-159">This has the potential to irreparably break service configuration and create terrible user experiences (vanishing achievements, lost game saves, etc.), and as a result we require 100% of service configuration to be done in XDP for XDK+UWP cross-play games.</span></span>

### <a name="create-your-uwp-product-in-partner-center"></a><span data-ttu-id="ae29b-160">パートナー センターで、UWP の製品を作成します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-160">Create your UWP product in Partner Center</span></span>

<span data-ttu-id="ae29b-161">パートナー センターで UWP 製品を作成するには、次のガイド。[Xbox Live を新規または既存の UWP プロジェクトに追加します。](get-started-with-visual-studio-and-uwp.md)</span><span class="sxs-lookup"><span data-stu-id="ae29b-161">Create a UWP product in Partner Center by following the guide: [Adding Xbox Live to a new or existing UWP project](get-started-with-visual-studio-and-uwp.md)</span></span>

## <a name="setup-your-xdk-product-in-xdp"></a><span data-ttu-id="ae29b-162">XDP で XDK 製品をセットアップする</span><span class="sxs-lookup"><span data-stu-id="ae29b-162">Setup your XDK product in XDP</span></span>

<span data-ttu-id="ae29b-163">UWP 製品を作成したので、XDP で XDK 製品をセットアップする準備が整いました。</span><span class="sxs-lookup"><span data-stu-id="ae29b-163">Now that your UWP is created, you are ready to setup your XDK product in XDP.</span></span> <span data-ttu-id="ae29b-164">XDK タイトルがまだない場合は、作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-164">If you do not already have an XDK title, you must create one.</span></span>

### <a name="create-your-xdp-product"></a><span data-ttu-id="ae29b-165">XDP 製品を作成する</span><span class="sxs-lookup"><span data-stu-id="ae29b-165">Create your XDP Product</span></span>

<span data-ttu-id="ae29b-166">XDP で、パブリッシャーでの新しい製品を作成する、アカウント マネージャーを使用 ([https://xdp.xboxlive.com/](https://xdp.xboxlive.com/User/Publisher))。</span><span class="sxs-lookup"><span data-stu-id="ae29b-166">Work with your account manager to create a new product under your publisher in XDP ([https://xdp.xboxlive.com/](https://xdp.xboxlive.com/User/Publisher)).</span></span>

<span data-ttu-id="ae29b-167">XDP で製品を作成するときは、UI の左側のセクションを一番下までスクロールしてプラットフォームを選択します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-167">When creating the product in XDP, make sure that you scroll to the bottom of the left section of the UI to select your platforms.</span></span> <span data-ttu-id="ae29b-168">Xbox Live クロスプレイを統合してゲームをリリースすることが**予定されている**プラットフォームをすべてオンにしてください。</span><span class="sxs-lookup"><span data-stu-id="ae29b-168">Check every platform that you **intend to someday** release the game on with Xbox Live cross-play integration.</span></span>

<span data-ttu-id="ae29b-169">プラットフォームを選択した後、ゲーム (ほとんどの場合 XDK タイトル) のリソース アクセスの種類と、その製品に対して採用するリリース形態を指定します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-169">Once you have selected your platforms, specify the type of resource access for your game (most likely a XDK title) and the intended release mechanisms for this product.</span></span>


![](../images/ingesting_crossplay_games_xdp/image4.png)
### <a name="update-your-xdp-product-platforms"></a><span data-ttu-id="ae29b-170">XDP 製品のプラットフォームを更新する</span><span class="sxs-lookup"><span data-stu-id="ae29b-170">Update your XDP Product Platforms</span></span>

<span data-ttu-id="ae29b-171">既に XDP に XDK 製品が取り込まれている場合は、PC プラットフォームをサポートするように更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-171">If you have an existing XDK product in XDP already, it needs to be updated to support the PC platform.</span></span> <span data-ttu-id="ae29b-172">そのためには、製品を選択して、[Product Setup] (製品のセットアップ) &gt; [プラットフォームの種類] の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-172">To do this, once on the product, navigate to Product Setup &gt; Platform Type.</span></span>

![](../images/ingesting_crossplay_games_xdp/image10.png)

<span data-ttu-id="ae29b-173">このページで、サポートするプラットフォームを選択します (オプションは Xbox One、Threshold PC、Windows Mobile)。</span><span class="sxs-lookup"><span data-stu-id="ae29b-173">On this page, select the platforms you want to support (options are Xbox One, Threshold PC, and Windows Mobile).</span></span> <span data-ttu-id="ae29b-174">選択に問題がなければ、[Submit Platforms] (プラットフォームの提出) ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="ae29b-174">Once you are happy with your selection, select the “Submit Platforms” button.</span></span>

<span data-ttu-id="ae29b-175">この変更はすぐに有効になります (有効にするためにサービス構成、カタログ、またはバイナリを公開する必要はありません)。</span><span class="sxs-lookup"><span data-stu-id="ae29b-175">This change will immediately be made live (no need for a service configuration, catalog, or binary publish for this to take affect).</span></span> <span data-ttu-id="ae29b-176">この構成はサンドボックス全体に適用されることに注意してください。ゲームのサンドボックスごとにプラットフォームの種類を変えることはできません。</span><span class="sxs-lookup"><span data-stu-id="ae29b-176">Note that this configuration spans sandboxes – you cannot have different platform types per sandbox for your game.</span></span>

### <a name="enter-your-msa-app-id"></a><span data-ttu-id="ae29b-177">MSA アプリ ID を入力する</span><span class="sxs-lookup"><span data-stu-id="ae29b-177">Enter your MSA App ID</span></span>

<span data-ttu-id="ae29b-178">XDP 製品を作成したら、製品の [Product Setup] (製品のセットアップ) ページに移動して、前の手順で作成した MSA アプリ ID を入力します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-178">Once the XDP product is created, go to the Product Setup page for the product to enter the MSA App ID created earlier.</span></span> <span data-ttu-id="ae29b-179">[Product Setup] (製品のセットアップ) ページに移動するには、XDP で、製品のタスク バーの左端にある "状態ボックス" をクリックします (下図を参照)。</span><span class="sxs-lookup"><span data-stu-id="ae29b-179">Product Setup can be reached by clicking on the left-most “status box” in the Tasks bar for the product in XDP, as shown below.</span></span>

![](../images/ingesting_crossplay_games_xdp/image11.png)

<span data-ttu-id="ae29b-180">[Product Setup] (製品のセットアップ) ページに移動したら、[Application ID Setup] (アプリケーション ID のセットアップ) セクションを選択します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-180">Once you make it to the Product Setup page, select the “Application ID Setup” section.</span></span> <span data-ttu-id="ae29b-181">このセクションでは、取得した MSA アプリ ID を [アプリケーション ID] フィールドに入力できます (下図を参照)。</span><span class="sxs-lookup"><span data-stu-id="ae29b-181">In this area, you can enter the MSA App ID you retrieved and place it in the “Application ID” field, as shown below.</span></span>

![](../images/ingesting_crossplay_games_xdp/image12.png)

<span data-ttu-id="ae29b-182">\*\*\*\* **名前とパブリッシャーの属性を入力する必要はありません**、**具体的には、ページの"アプリケーション ID の取得"リンクを使用する必要がありますいない**などにこれを入力する必要がある MSA アプリ ID が既にあります。フィールドし、アプリケーションの新しいものをしないようにします。</span><span class="sxs-lookup"><span data-stu-id="ae29b-182">**You** **do not need to enter Name and Publisher attribution**, **and specifically should not use the “Get Application ID” link on the page**, as you already have an MSA App ID you need to enter in this field and do not want a new one generated for your application.</span></span>

<span data-ttu-id="ae29b-183">MSA アプリ ID を [アプリケーション ID] フィールドに入力したら、[Submit Application ID Setup] (アプリケーション ID 設定の提出) ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="ae29b-183">Once you’ve entered your MSA App ID in the “Application ID” field, click the “Submit Application ID Setup” button.</span></span> <span data-ttu-id="ae29b-184">Xbox Live のセキュリティ –、MSA アプリ ID の情報を保存するには、これは、UWP から、XToken を取得する要求を行うたびに、タイトルに含まれるようになりましたにマップするこの XDP 製品である限り、UWP AppX マニフェストの Id を作成するを使用して正しくは、d パートナー センターで!)</span><span class="sxs-lookup"><span data-stu-id="ae29b-184">This will save your MSA App ID information with Xbox Live security – whenever you make a request to retrieve an XToken from your UWP, the title claim contained within will now map to this XDP product (as long as the UWP is properly using the AppX Manifest Identity you created in Partner Center!)</span></span>

### <a name="enter-the-partner-center-pfn-into-xdp"></a><span data-ttu-id="ae29b-185">XDP にパートナー センターの PFN を入力します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-185">Enter the Partner Center PFN into XDP</span></span>

<span data-ttu-id="ae29b-186">UWP ゲームを認証し、XDP で作成および公開したサービス構成で Xbox Live を使用するには、以上の手順で十分ですが、特定の Xbox Live 機能 (マルチプレイヤーの招待など) が正常に動作するには、これらの機能で UWP ゲームの PFN を認識する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-186">While the above steps are enough to get your UWP game authenticated and using Xbox Live with the Service Configuration you create and publish in XDP, certain Xbox Live features (like multiplayer invites) need to be aware of your UWP game’s PFN in order to work correctly.</span></span>

<span data-ttu-id="ae29b-187">そのためには、[Product Setup] (製品のセットアップ) &gt; [Dev Center Binding] (デベロッパー センターのバインディング) に移動します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-187">To do this, navigate to Product Setup &gt; Dev Center Binding</span></span>

![](../images/ingesting_crossplay_games_xdp/image13.png)

<span data-ttu-id="ae29b-188">このページで、UWP アプリの PFN (セクション 4.1.1 で取得したもの) を入力して、[保存] ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="ae29b-188">On this page, enter the PFN for your UWP app (as retrieved in section 4.1.1), then select the “save” button.</span></span>

<span data-ttu-id="ae29b-189">この構成はすぐには有効になりません。</span><span class="sxs-lookup"><span data-stu-id="ae29b-189">This configuration is not immediately made live.</span></span> <span data-ttu-id="ae29b-190">後でサービス構成をサンドボックスに公開することによって有効になります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-190">It is brought live through future Service Configuration publishes to a sandbox.</span></span> <span data-ttu-id="ae29b-191">この情報はサンドボックス化されるので、使用できるサンドボックスごとに公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-191">As such, this information is sandboxed, and needs to be published to each sandbox to be available.</span></span>

### <a name="flag-your-app-for-xbox-cert-in-partner-center"></a><span data-ttu-id="ae29b-192">パートナー センターの証明書を Xbox アプリをフラグします。</span><span class="sxs-lookup"><span data-stu-id="ae29b-192">Flag your App for Xbox Cert in Partner Center</span></span>

<span data-ttu-id="ae29b-193">現時点では、Xbox の認定を受けるために、ゲームを Xbox Live 対応として認識されるようにするには、手動で対応する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-193">Today, getting your game recognized as Xbox Live enabled for Xbox Cert requires some manual intervention.</span></span> <span data-ttu-id="ae29b-194">リリース マネージャーにアプリをフラグでの作業は、Xbox Live SmartCert 検出のパートナー センターで有効になっています。</span><span class="sxs-lookup"><span data-stu-id="ae29b-194">Work with your release manager to flag your app is Xbox Live enabled in Partner Center for SmartCert detection.</span></span>

### <a name="update-your-uwp-game-in-the-xbox-app"></a><span data-ttu-id="ae29b-195">Xbox アプリで UWP ゲームを更新する</span><span class="sxs-lookup"><span data-stu-id="ae29b-195">Update your UWP Game in the Xbox App</span></span>

<span data-ttu-id="ae29b-196">通常、Xbox アプリでは、Xbox アプリ内で Xbox Live エクスペリエンスを提供するために、すべての UWP ゲームに対して自動生成された 1 つのタイトル ID を使用します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-196">Normally, the Xbox App uses an auto-generated Title ID for all UWP games to power the Xbox Live experiences within the Xbox App.</span></span> <span data-ttu-id="ae29b-197">UWP ゲームで Xbox アプリ タイトル XDP によって生成された ID を正しく使用するために、データ更新は、パートナー センター内にする必要があります**UWP のリリースのゲームを送信する前にします。**</span><span class="sxs-lookup"><span data-stu-id="ae29b-197">In order to have your UWP game properly use the XDP-generated Title ID in the Xbox App, a data update needs to be made within Partner Center, **before you submit your UWP game for release.**</span></span>

<span data-ttu-id="ae29b-198">そのためには、担当の DAM に連絡し、タイトル名に対して Xbox アプリのタイトル ID を更新する必要があることを伝えてください。</span><span class="sxs-lookup"><span data-stu-id="ae29b-198">To do this, please contact your DAM and tell them you want to update your Xbox App Title ID for your title name.</span></span>  <span data-ttu-id="ae29b-199">XDP で作成したタイトルの ID を含めるようにしてください (XDP 製品の設定の下に表示される&gt;製品の詳細) と、UWP 用 Windows 10 の URL (パートナー センターでアプリの管理下に表示される&gt;アプリ id)。</span><span class="sxs-lookup"><span data-stu-id="ae29b-199">Be sure to include the Title ID created in XDP (visible in XDP under Product Setup &gt; Product Details) and the URL for Windows 10 for your UWP (visible in Partner Center under App management &gt; App identity).</span></span>

## <a name="configure-xbox-live-in-xdp"></a><span data-ttu-id="ae29b-200">XDP で Xbox Live を構成する</span><span class="sxs-lookup"><span data-stu-id="ae29b-200">Configure Xbox Live in XDP</span></span>

### <a name="service-configuration"></a><span data-ttu-id="ae29b-201">サービス構成</span><span class="sxs-lookup"><span data-stu-id="ae29b-201">Service Configuration</span></span>

<span data-ttu-id="ae29b-202">XDP とパートナー センターの製品適切に構成し、バインドでは自由の XDK のタイトルを通常どおりに XDP 内で共有 Xbox Live 構成をセットアップします。</span><span class="sxs-lookup"><span data-stu-id="ae29b-202">With our XDP and Partner Center products properly configured and bound, you are free to setup your shared Xbox Live configuration within XDP as you would normally for an XDK title.</span></span>

<span data-ttu-id="ae29b-203">**アラーム**– バインド XDK + UWP ゲームする必要があります、状況でも有効にする、構成、または、パートナー センターのサービス構成の Xbox Live を発行します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-203">**REMINDER** – Bound XDK+UWP games should, under no circumstances, enable, configure, or publish Xbox Live service configuration through the Partner Center.</span></span> <span data-ttu-id="ae29b-204">このガイダンスに従わない場合、ゲームの Xbox Live 構成が破損して修復できなくなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-204">Failure to follow this guidance can permanently harm the Xbox Live configuration for your game.</span></span>

### <a name="catalog-configuration"></a><span data-ttu-id="ae29b-205">カタログの構成</span><span class="sxs-lookup"><span data-stu-id="ae29b-205">Catalog Configuration</span></span>

<span data-ttu-id="ae29b-206">XDK + UWP ゲームでは、カタログの構成は 2 回設定をする必要があります: XDP XDK、用に 1 回とも、UWP 用のパートナー センターでします。</span><span class="sxs-lookup"><span data-stu-id="ae29b-206">For an XDK+UWP game, catalog configuration needs to be setup twice: once in XDP for your XDK, and also in Partner Center for your UWP.</span></span>

<span data-ttu-id="ae29b-207">XDP での構成のセットアップは、通常の XDK 製品の場合とまったく同じです。</span><span class="sxs-lookup"><span data-stu-id="ae29b-207">For the XDP configuration, this is exactly the same as a normal XDK product.</span></span> <span data-ttu-id="ae29b-208">パートナー センターの構成の詳細な手順を参照して[ここ](https://dev.windows.com/en-us/publish)します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-208">For the Partner Center configuration, more detailed steps can be found [here](https://dev.windows.com/en-us/publish).</span></span>

<table>
  <tr>
    <td>
      <span data-ttu-id="ae29b-209">UWP 専用ゲームの場合は、セットアップする必要のあるカタログ構成は限られています。</span><span class="sxs-lookup"><span data-stu-id="ae29b-209">For UWP-only games, only a limited set of catalog configuration needs to be setup.</span></span> <span data-ttu-id="ae29b-210">具体的には、UWP 専用ゲームの場合はマーケティング情報を入力する必要があります。サービス構成は、XDP で構成される Xbox Live ゲームに対して、入力されたマーケティング情報の文字列を使用します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-210">In particular, Marketing Info should be filled out for UWP-only games, as service configuration consumes the strings entered here for any XDP configure Xbox Live game.</span></span> <span data-ttu-id="ae29b-211">また、ゲームのカタログ情報が公開された場合にゲームが Xbox One カタログに表示されないように、利用できるかどうかの情報を "利用不可" に設定する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-211">Additionally, availabilities should be setup with “not available” to ensure that the game will never appear in the Xbox One catalog if/when the catalog info for the game gets published.</span></span>
    </td>
  </tr>
</table>

### <a name="binary-configuration"></a><span data-ttu-id="ae29b-212">バイナリの構成</span><span class="sxs-lookup"><span data-stu-id="ae29b-212">Binary Configuration</span></span>

<span data-ttu-id="ae29b-213">セットアップを 2 回の XDK + UWP ゲームでは、バイナリの構成が必要があります: XDP XDK、用に 1 回とも、UWP 用のパートナー センターでします。</span><span class="sxs-lookup"><span data-stu-id="ae29b-213">For an XDK+UWP game, binary configuration needs to be setup twice: once in XDP for your XDK, and also in Partner Center for your UWP.</span></span>

<span data-ttu-id="ae29b-214">XDP での構成のセットアップは、通常の XDK 製品の場合とまったく同じです。</span><span class="sxs-lookup"><span data-stu-id="ae29b-214">For the XDP configuration, this is exactly the same as a normal XDK product.</span></span> <span data-ttu-id="ae29b-215">パートナー センターの構成の詳細な手順を参照して[ここ](https://dev.windows.com/en-us/publish)します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-215">For the Partner Center configuration, more detailed steps can be found [here](https://dev.windows.com/en-us/publish).</span></span>

<table>
  <tr>
    <td>
      <span data-ttu-id="ae29b-216">UWP 専用ゲームの場合、XDP でバイナリを構成する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="ae29b-216">For UWP-only games, there is no need for binary configuration in XDP.</span></span> <span data-ttu-id="ae29b-217">この手順全体を省略できます。</span><span class="sxs-lookup"><span data-stu-id="ae29b-217">You can skip this step entirely.</span></span>
    </td>
  </tr>
</table>

## <a name="publish-in-xdp"></a><span data-ttu-id="ae29b-218">XDP で公開する</span><span class="sxs-lookup"><span data-stu-id="ae29b-218">Publish in XDP</span></span>

<span data-ttu-id="ae29b-219">一般的に言えば、XDK + UWP、ゲームの発行とは別に XDP とパートナー センターで、UWP、XDK タイトルのパブリッシュと同じプロセスに従います。</span><span class="sxs-lookup"><span data-stu-id="ae29b-219">Generally speaking, publishing an XDK+UWP game follows the same process as separately publishing an XDK title in XDP and your UWP in Partner Center.</span></span> <span data-ttu-id="ae29b-220">そのため、以下では、クロスプレイ ゲームに固有のプロセスまたは考慮事項を中心に説明します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-220">As such the below focuses on unique process or considerations to make for cross-play games.</span></span>

### <a name="dev-sandbox-publishing"></a><span data-ttu-id="ae29b-221">開発サンドボックスの公開</span><span class="sxs-lookup"><span data-stu-id="ae29b-221">Dev Sandbox Publishing</span></span>

### <a name="no-dev-sandbox-catalog-equivalent-for-microsoft-store"></a><span data-ttu-id="ae29b-222">Microsoft Store の場合は開発サンドボックス カタログに相当するものがない</span><span class="sxs-lookup"><span data-stu-id="ae29b-222">No Dev Sandbox Catalog Equivalent for Microsoft Store</span></span>

<span data-ttu-id="ae29b-223">XDP ではカタログとバイナリを Xbox One カタログの開発サンドボックス バージョンに公開できますが、Microsoft Store のカタログにはサンドボックスのサポートはありません。</span><span class="sxs-lookup"><span data-stu-id="ae29b-223">While XDP allows you to publish your catalog & binary to the dev sandbox version of the Xbox One catalog, the Microsoft Store catalog has no sandbox support.</span></span> <span data-ttu-id="ae29b-224">そのため、開発サンドボックスで UWP をテストするには、その UWP をサイドロードして直接プレイする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-224">As such, testing your UWP in a dev sandbox requires you to sideload that UWP and play it directly.</span></span> <span data-ttu-id="ae29b-225">これによる Xbox Live のテストへの影響はありませんが、標準のテスト プロセスで変更が必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-225">This doesn’t impact Xbox Live testing, but may alter your standard testing processes.</span></span>

<table>
  <tr>
    <td>
      <span data-ttu-id="ae29b-226">UWP 専用ゲームの場合、Xbox One カタログは存在しませんが、XDK タイトルのカタログ情報を公開して、サービス構成の公開のブロックを解除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-226">For a UWP-only game, it is still required to publish the XDK title catalog information to unblock service configuration publish, even though the UWP-only game has not Xbox One catalog presence.</span></span>
    </td>
  </tr>
</table>

### <a name="cert-sandbox-publishing"></a><span data-ttu-id="ae29b-227">CERT サンドボックスの公開</span><span class="sxs-lookup"><span data-stu-id="ae29b-227">CERT Sandbox Publishing</span></span>

### <a name="coordination-between-xdp-publishing-and-partner-center-publishing"></a><span data-ttu-id="ae29b-228">XDP 公開およびパートナー センターの公開の間の調整</span><span class="sxs-lookup"><span data-stu-id="ae29b-228">Coordination between XDP publishing and Partner Center publishing</span></span>

<span data-ttu-id="ae29b-229">XDP では、CERT から RETAIL への移行は、2 つの独立した、明示的なアクションです。</span><span class="sxs-lookup"><span data-stu-id="ae29b-229">In XDP, moving from CERT to RETAIL are two separate, explicit actions.</span></span> <span data-ttu-id="ae29b-230">ただし、パートナー センターの送信プロセスに自動的に移動します認定と小売にゲーム。</span><span class="sxs-lookup"><span data-stu-id="ae29b-230">However, in Partner Center, the submission process automatically moves your game through certification and on to retail.</span></span> <span data-ttu-id="ae29b-231">そのため、正しい順序で操作する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-231">As such, there is an order of operations to respect.</span></span>

<span data-ttu-id="ae29b-232">認定に提出する準備ができたら、以下の手順を順番に実行してください。</span><span class="sxs-lookup"><span data-stu-id="ae29b-232">When you’re ready to go to certification, you should follow the following steps in order:</span></span>

1.  <span data-ttu-id="ae29b-233">XDP で XDK 製品を CERT に公開します (カタログ、バイナリ、サービス構成を含みます)</span><span class="sxs-lookup"><span data-stu-id="ae29b-233">Publish your XDK product in XDP to CERT (including catalog, binary, and service config)</span></span>

2.  <span data-ttu-id="ae29b-234">パートナー センターの提出、UWP の製品の開始します。</span><span class="sxs-lookup"><span data-stu-id="ae29b-234">Start your Partner Center submission for your UWP product</span></span>

    1.  <span data-ttu-id="ae29b-235">**[このアプリを手動で発行] を選択することを確認するまたは"すぐ\[日付\]"発行日 フィールドに!**</span><span class="sxs-lookup"><span data-stu-id="ae29b-235">**Be sure to select “Publish this app manually” or “No sooner than \[date\]” in the Publish date field!**</span></span> <span data-ttu-id="ae29b-236">そのようにしないと、操作を行っていないにもかかわらず、UWP ゲームが自動的に製品版としてリリースされる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-236">If you don’t do this, your UWP game could be released to retail automatically without your intervention</span></span>

<table>
  <tr>
    <td>
      <span data-ttu-id="ae29b-237">UWP 専用のゲームを発行する XDK タイトル バイナリがあるない場合でも、パートナー センターの送信を開始する前に XDP で証明書に、カタログとサービスの構成を発行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae29b-237">For a UWP-only game, it is still required to publish your catalog and service config to CERT in XDP before starting your Partner Center submission, even though you don’t have an XDK title binary that you’re publishing.</span></span>
    </td>
  </tr>
</table>

### <a name="retail-sandbox-publishing"></a><span data-ttu-id="ae29b-238">RETAIL サンドボックスの公開</span><span class="sxs-lookup"><span data-stu-id="ae29b-238">RETAIL Sandbox Publishing</span></span>

### <a name="coordination-between-xdp-publishing-and-partner-center-publishing"></a><span data-ttu-id="ae29b-239">XDP 公開およびパートナー センターの公開の間の調整</span><span class="sxs-lookup"><span data-stu-id="ae29b-239">Coordination between XDP publishing and Partner Center publishing</span></span>

<span data-ttu-id="ae29b-240">XDK タイトルの認定が完了し、UWP の認定が終わって公開できる状態になったら、アプリを RETAIL に公開できます。</span><span class="sxs-lookup"><span data-stu-id="ae29b-240">Once certification of your XDK title has completed, and your UWP has left certification and is ready to publish, you are ready to publish your app to RETAIL.</span></span> <span data-ttu-id="ae29b-241">この場合も、XDK タイトルと UWP の足並みが揃うように、特定の順序でこのプロセスを行うことが重要です。</span><span class="sxs-lookup"><span data-stu-id="ae29b-241">Again, it’s important to follow this process in a specific order to ensure that your XDK title and UWP stay aligned.</span></span>

1.  <span data-ttu-id="ae29b-242">準備ができたら、XDP で XDK 製品を RETAIL に公開します (カタログ、バイナリ、サービス構成を含みます)</span><span class="sxs-lookup"><span data-stu-id="ae29b-242">Once you’re ready, publish your XDK product in XDP to RETAIL (including catalog, binary, and service config)</span></span>

2.  <span data-ttu-id="ae29b-243">パートナー センターの証明書 ページで、製品の選択「を今すぐ発行」「このアプリは手動で公開」、以前選択した場合か、選択した場合に発生する発行を待ちます"すぐ\[日付\]"。</span><span class="sxs-lookup"><span data-stu-id="ae29b-243">In Partner Center, on the certification page of your product, select “Publish now” if you had previously selected “Publish this app manually”, or wait for the publish to occur if you selected “No sooner than \[date\]”.</span></span>

<span data-ttu-id="ae29b-244">以上の手順が完了すると、共有サービス構成が RETAIL の状態になり、XDK タイトルおよび UWP ゲームが全世界に向けて公開されます。</span><span class="sxs-lookup"><span data-stu-id="ae29b-244">Once these steps have completed, you should have your XDK title and UWP game published to the world, with a shared service configuration in RETAIL.</span></span> <span data-ttu-id="ae29b-245">これで終了です。</span><span class="sxs-lookup"><span data-stu-id="ae29b-245">Congratulations!</span></span>

<table>
  <tr>
    <td>
      <span data-ttu-id="ae29b-246">UWP 専用のゲームは、カタログを公開する必要があり、それ以外の場合、リリースされた UWP のパートナー センターで、発行が完了する前に XDP で RETAIL にサービス構成では、Xbox Live にアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="ae29b-246">For a UWP-only game, it is still required to publish your catalog and service config to RETAIL in XDP before publishing completes in Partner Center, otherwise the released UWP will not be able to access Xbox Live.</span></span>
    </td>
  </tr>
</table>
