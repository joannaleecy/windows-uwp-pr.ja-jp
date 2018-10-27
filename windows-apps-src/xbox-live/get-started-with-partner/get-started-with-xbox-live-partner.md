---
title: パートナーとして Xbox Live を使用する際の概要
author: KevinAsgari
description: 対象パートナーや ID@Xbox メンバーが Xbox Live の開発を始める際に役立つリンクを紹介します。
ms.assetid: 69ab75d1-c0e7-4bad-bf8f-5df5cfce13d5
ms.author: kevinasg
ms.date: 06/07/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, パートナー, ID@Xbox
ms.localizationpriority: medium
ms.openlocfilehash: fc9f6831f3c759c9d49ea936a458c84cbf4c0edf
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5685908"
---
# <a name="get-started-with-xbox-live-as-a-managed-partner-or-an-idxbox-developer"></a><span data-ttu-id="0a77e-104">対象パートナーまたは ID@Xbox 開発者として Xbox Live の利用を開始する</span><span class="sxs-lookup"><span data-stu-id="0a77e-104">Get started with Xbox Live as a managed partner or an ID@Xbox developer</span></span>

<span data-ttu-id="0a77e-105">このセクションでは、パートナーまたは ID@Xbox 開発者として Xbox Live の利用を開始する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0a77e-105">This section covers getting started with Xbox Live as a managed partner or as an ID@Xbox developer.</span></span> <span data-ttu-id="0a77e-106">パートナーや ID 開発者は、実績やマルチプレイヤーなど、Xbox Live の機能をすべて利用できます。</span><span class="sxs-lookup"><span data-stu-id="0a77e-106">Partners and ID developers can access the full range of Xbox Live features, including achievements, multiplayer, and more.</span></span>

<span data-ttu-id="0a77e-107">対象パートナーおよび ID@Xbox 開発者は、ユニバーサル Windows プラットフォーム (UWP) や Xbox 開発キット (XDK) プラットフォームに対応した Xbox Live タイトルを開発できます。</span><span class="sxs-lookup"><span data-stu-id="0a77e-107">Managed partners and ID@Xbox developers can develop Xbox Live titles for both the Universal Windows Platform (UWP) or the Xbox Developer Kit (XDK) platform.</span></span>

<span data-ttu-id="0a77e-108">ここで紹介するコンテンツ以外にも、承認されているデベロッパー センター アカウントを持っているパートナーが利用できるその他のドキュメントが用意されています。</span><span class="sxs-lookup"><span data-stu-id="0a77e-108">In addition to the content available here, there is also additional documentation that is available to partners with an authorized Dev Center account.</span></span> <span data-ttu-id="0a77e-109">そのようなコンテンツには、[Xbox Live パートナー コンテンツ](https://developer.microsoft.com/en-us/games/xbox/docs/xboxlive/xbox-live-partners/partner-content)でアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="0a77e-109">You can access that content here: [Xbox Live partner content](https://developer.microsoft.com/en-us/games/xbox/docs/xboxlive/xbox-live-partners/partner-content).</span></span>

## <a name="why-should-you-use-xbox-live"></a><span data-ttu-id="0a77e-110">Xbox Live を使用する理由</span><span class="sxs-lookup"><span data-stu-id="0a77e-110">Why should you use Xbox Live?</span></span>

<span data-ttu-id="0a77e-111">Xbox Live には、ゲームの販売を促進し、ゲーマーの関心を引き付けておくために設計された一連の機能が用意されています。</span><span class="sxs-lookup"><span data-stu-id="0a77e-111">Xbox Live offers an array of features designed to help promote your game and keep gamers engaged:</span></span>

- <span data-ttu-id="0a77e-112">Xbox Live ソーシャル プラットフォームを使用すると、ゲーマーはフレンドと接続してゲームについて会話することができます。</span><span class="sxs-lookup"><span data-stu-id="0a77e-112">Xbox Live social platform lets gamers connect with friends and talk about your game.</span></span>
- <span data-ttu-id="0a77e-113">Xbox Live の実績を利用すると、ゲーマーが実績のロックを解除したときに、Xbox Live のソーシャル グラフにゲームの無料プロモーションが提供され、ゲームの人気を高める際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="0a77e-113">Xbox Live achievements helps your game get popular by giving your game free promotion to the Xbox Live social graph when gamers unlock achievements.</span></span>
- <span data-ttu-id="0a77e-114">Xbox Live のランキングを利用すると、ゲーマーがフレンドに勝ってランクを上げることが可能になり、ゲームに対するユーザーの関心を高めることができます。</span><span class="sxs-lookup"><span data-stu-id="0a77e-114">Xbox Live leaderboards helps drive engagement of your game by letting gamers compete to beat their friends and move up the ranks.</span></span>
- <span data-ttu-id="0a77e-115">Xbox Live のマルチプレイヤーを利用すると、ゲーマーがフレンドと一緒にプレイしたり、他のプレイヤーとのマッチメイキングによってゲーム内で戦ったり協力したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="0a77e-115">Xbox Live multiplayer lets gamers play with their friends or a get matched with other players to compete or cooperate in your game.</span></span>
- <span data-ttu-id="0a77e-116">Xbox Live の接続ストレージでは、デバイス間でゲームのセーブ データを無料でローミングでき、ゲーマーは Xbox One と Windows PC の間で簡単にゲームの進行を継続することができます。</span><span class="sxs-lookup"><span data-stu-id="0a77e-116">Xbox Live connected storage offers free save game roaming between devices so gamers can easily continue game progress between Xbox One and Windows PC.</span></span>

## <a name="1-choose-a-platform"></a><span data-ttu-id="0a77e-117">1. プラットフォームを選択する</span><span class="sxs-lookup"><span data-stu-id="0a77e-117">1. Choose a platform</span></span>
<span data-ttu-id="0a77e-118">Xbox 開発キット (XDK)、ユニバーサル Windows プラットフォーム (UWP)、またはクロスプレイ ゲームのどれを作成するかを決定します。</span><span class="sxs-lookup"><span data-stu-id="0a77e-118">Decide between making an Xbox Development Kit (XDK), Universal Windows Platform (UWP), or cross-play game:</span></span>

- <span data-ttu-id="0a77e-119">XDK ベースのゲームは Xbox One 本体でのみ動作します。</span><span class="sxs-lookup"><span data-stu-id="0a77e-119">XDK based games only run on the Xbox One console</span></span>
- <span data-ttu-id="0a77e-120">UWP ゲームは、Windows PC、Windows Phone、Xbox One など、すべての Windows プラットフォームを対象にすることができます。</span><span class="sxs-lookup"><span data-stu-id="0a77e-120">UWP games can target any Windows platform such as Windows PC, Windows Phone, or Xbox One</span></span>
  - <span data-ttu-id="0a77e-121">Xbox One については、「[Xbox One の UWP](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/index)」をご覧ください。また、「[Xbox One 上の UWP アプリとゲームのシステム リソース](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/system-resource-allocation)」をご覧になることもお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0a77e-121">For Xbox One, see [UWP on Xbox One](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/index) and specifically [System resources for UWP apps and games on Xbox One](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/system-resource-allocation)</span></span>
- <span data-ttu-id="0a77e-122">クロスプレイ ゲームは、通常、XDK と UWP の両方のパスを使用する Xbox One と Windows PC を対象とするゲームです。</span><span class="sxs-lookup"><span data-stu-id="0a77e-122">Cross-play games are typically games that target Xbox One and Windows PC using both the XDK and UWP paths.</span></span>

## <a name="2-ensure-that-you-have-a-title-created-on-dev-center-or-xdp"></a><span data-ttu-id="0a77e-123">2. デベロッパー センターまたは XDP でタイトルが作成されていることを確認する</span><span class="sxs-lookup"><span data-stu-id="0a77e-123">2. Ensure that you have a title created on Dev Center or XDP</span></span>
<span data-ttu-id="0a77e-124">すべての Xbox Live タイトルは、サインインして Xbox Live サービスを呼び出すことができるようになるには、デベロッパー センターまたは Xbox デベロッパー ポータル (XDP) で定義されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="0a77e-124">Every Xbox Live title must be defined on Dev Center or the Xbox Developer Portal (XDP) before you will be able to sign-in and make Xbox Live Service calls.</span></span>  <span data-ttu-id="0a77e-125">これを行う方法は、「[新しいタイトルの作成](create-a-new-title.md)」で説明します。</span><span class="sxs-lookup"><span data-stu-id="0a77e-125">[Creating A New Title](create-a-new-title.md) will show you how to do this.</span></span>

## <a name="3-follow-the-appropriate-guide-to-setup-your-ide-or-game-engine"></a><span data-ttu-id="0a77e-126">3. 適切なガイドに従って IDE やゲーム エンジンをセットアップする</span><span class="sxs-lookup"><span data-stu-id="0a77e-126">3. Follow the appropriate guide to setup your IDE or game engine</span></span>
<span data-ttu-id="0a77e-127">プラットフォームやエンジンに関する適切なファースト ステップ ガイドに従い、それに沿って学習することで、Xbox Live の基本を習得することができます。</span><span class="sxs-lookup"><span data-stu-id="0a77e-127">You can follow the appropriate Getting Started guide for your platform and engine and learn the basics of Xbox Live as you go along.</span></span>

* <span data-ttu-id="0a77e-128">「[UWP ゲーム用 Visual Studio の使用に関する概要](get-started-with-visual-studio-and-uwp.md)」では、デベロッパー センターで Xbox Live 構成を使用して Visual Studio プロジェクトをリンクする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0a77e-128">[Getting started using Visual Studio for UWP games](get-started-with-visual-studio-and-uwp.md) will show you how to link your Visual Studio project with your Xbox Live configuration on Dev Center.</span></span>
* <span data-ttu-id="0a77e-129">「[UWP ゲーム用 Unity の使用に関する概要](partner-add-xbox-live-to-unity-uwp.md)」では、Xbox Live 対応の新しい Unity タイトルを作成する方法、ランキングなどの機能をタイトルに追加する方法、およびネイティブの Visual Studio プロジェクトを生成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0a77e-129">[Getting started using Unity for UWP games](partner-add-xbox-live-to-unity-uwp.md) will show you how to create a new Xbox Live enabled Unity title, add features such as Leaderboards to your title, and generate a native Visual Studio project.</span></span>
* <span data-ttu-id="0a77e-130">「[XDK ベースのゲームで Visual Studio を使用する際の概要](xdk-developers.md)」では、XDK を使用して Xbox One タイトルを作成する場合に Visual Studio プロジェクトをセットアップする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0a77e-130">[Getting started using Visual Studio for XDK based games](xdk-developers.md) will show you how to get your Visual Studio project setup if you are making an Xbox One title using the XDK.</span></span>
* <span data-ttu-id="0a77e-131">「[クロスプレイ ゲームの作成に関する概要](get-started-with-cross-play-games.md)」では、Xbox One 向けの XDK ベースのゲームと Windows 10 PC 向けの UWP ベースのゲームを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0a77e-131">[Getting started making a cross-play game](get-started-with-cross-play-games.md) explains how to make a product that is an XDK based game for Xbox One and a UWP based game for Windows 10 PC.</span></span>

## <a name="4-xbox-live-concepts"></a><span data-ttu-id="0a77e-132">4. Xbox Live の概念</span><span class="sxs-lookup"><span data-stu-id="0a77e-132">4. Xbox Live Concepts</span></span>
<span data-ttu-id="0a77e-133">タイトルを作成したら、タイトルの開発エクスペリエンスに影響を与える Xbox Live の概念について理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0a77e-133">Once you have a title created, you should learn about the Xbox Live concepts that will affect your experience developing titles:</span></span>

- [<span data-ttu-id="0a77e-134">Xbox Live のサンドボックス</span><span class="sxs-lookup"><span data-stu-id="0a77e-134">Xbox Live sandboxes</span></span>](../xbox-live-sandboxes.md)
- [<span data-ttu-id="0a77e-135">Xbox Live テスト アカウント</span><span class="sxs-lookup"><span data-stu-id="0a77e-135">Xbox Live test accounts</span></span>](../xbox-live-test-accounts.md)
- [<span data-ttu-id="0a77e-136">Xbox Live API の概要</span><span class="sxs-lookup"><span data-stu-id="0a77e-136">Introduction to Xbox Live APIs</span></span>](../introduction-to-xbox-live-apis.md)

## <a name="5-add-xbox-live-features"></a><span data-ttu-id="0a77e-137">5. Xbox Live の機能を追加する</span><span class="sxs-lookup"><span data-stu-id="0a77e-137">5. Add Xbox Live Features</span></span>

<span data-ttu-id="0a77e-138">Xbox Live の機能をゲームに追加します。</span><span class="sxs-lookup"><span data-stu-id="0a77e-138">Add Xbox Live features to your game:</span></span>

- [<span data-ttu-id="0a77e-139">Xbox Live ソーシャル プラットフォーム - プロフィール、フレンド、プレゼンス</span><span class="sxs-lookup"><span data-stu-id="0a77e-139">Xbox Live Social Platform - Profile, Friends, Presence</span></span>](../social-platform/social-platform.md)
- [<span data-ttu-id="0a77e-140">Xbox Live データ プラットフォーム - 統計、ランキング、実績</span><span class="sxs-lookup"><span data-stu-id="0a77e-140">Xbox Live Data Platform - Stats, Leaderboards, Achievements</span></span>](../data-platform/data-platform.md)
- [<span data-ttu-id="0a77e-141">Xbox Live マルチプレイヤー プラットフォーム - 招待、マッチメイキング、トーナメント</span><span class="sxs-lookup"><span data-stu-id="0a77e-141">Xbox Live Multiplayer Platform - Invite, Matchmaking, Tournaments</span></span>](../multiplayer/multiplayer-intro.md)
- [<span data-ttu-id="0a77e-142">Xbox Live ストレージ プラットフォーム - 接続ストレージ、タイトル ストレージ</span><span class="sxs-lookup"><span data-stu-id="0a77e-142">Xbox Live Storage Platform - Connected Storage, Title Storage</span></span>](../storage-platform/storage-platform.md)
- [<span data-ttu-id="0a77e-143">コンテキスト検索</span><span class="sxs-lookup"><span data-stu-id="0a77e-143">Contextual Search</span></span>](../contextual-search/introduction-to-contextual-search.md)

## <a name="6-release-your-title"></a><span data-ttu-id="0a77e-144">6. タイトルをリリースする</span><span class="sxs-lookup"><span data-stu-id="0a77e-144">6. Release Your Title</span></span>

<span data-ttu-id="0a77e-145">ID@Xbox および対象パートナーは、タイトルをリリースする前に認定プロセスに合格する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0a77e-145">ID@Xbox and managed partners must go through a certification process before releasing their titles.</span></span>  <span data-ttu-id="0a77e-146">この理由は、タイトルがオンライン マルチプレイヤー、実績、リッチ プレゼンスなどの追加機能にアクセスする場合があるためです。</span><span class="sxs-lookup"><span data-stu-id="0a77e-146">This is because the titles have access to additional features such as online multiplayer, achievements, and rich presence.</span></span>  <span data-ttu-id="0a77e-147">タイトルをリリースする準備ができたら、Microsoft の担当者に申請とリリースのプロセスに関する詳細をお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="0a77e-147">Once you are ready to release your title, contact your Microsoft representative for more details on the submission and release process.</span></span>
