---
title: Get started with Xbox Live as a partner
author: KevinAsgari
description: Provides links to help a managed partner or ID@Xbox member get started with Xbox Live development.
ms.assetid: 69ab75d1-c0e7-4bad-bf8f-5df5cfce13d5
ms.author: kevinasg
ms.date: 06-07-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, games, uwp, windows 10, xbox one, partner, ID@Xbox
ms.openlocfilehash: c39f0dfd07fd3e5d932c11391e58194268b64e6e
ms.sourcegitcommit: 2aa04e1ef925a6c2025b9ec2edc1d784d02eb94e
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2017
---
# <a name="get-started-with-xbox-live-as-a-managed-partner-or-an-idxbox-developer"></a><span data-ttu-id="cf0ac-104">対象パートナーまたは ID@Xbox 開発者として Xbox Live の利用を開始する</span><span class="sxs-lookup"><span data-stu-id="cf0ac-104">Get started with Xbox Live as a managed partner or an ID@Xbox developer</span></span>

<span data-ttu-id="cf0ac-105">This section covers getting started with Xbox Live as a managed partner or as an ID@Xbox developer.</span><span class="sxs-lookup"><span data-stu-id="cf0ac-105">This section covers getting started with Xbox Live as a managed partner or as an ID@Xbox developer.</span></span> <span data-ttu-id="cf0ac-106">Partners and ID developers can access the full range of Xbox Live features, including achievements, multiplayer, and more.</span><span class="sxs-lookup"><span data-stu-id="cf0ac-106">Partners and ID developers can access the full range of Xbox Live features, including achievements, multiplayer, and more.</span></span>

<span data-ttu-id="cf0ac-107">Managed partners and ID@Xbox developers can develop Xbox Live titles for both the Universal Windows Platform (UWP) or the Xbox Developer Kit (XDK) platform.</span><span class="sxs-lookup"><span data-stu-id="cf0ac-107">Managed partners and ID@Xbox developers can develop Xbox Live titles for both the Universal Windows Platform (UWP) or the Xbox Developer Kit (XDK) platform.</span></span>

<span data-ttu-id="cf0ac-108">In addition to the content available here, there is also additional documentation that is available to partners with an authorized Dev Center account.</span><span class="sxs-lookup"><span data-stu-id="cf0ac-108">In addition to the content available here, there is also additional documentation that is available to partners with an authorized Dev Center account.</span></span> <span data-ttu-id="cf0ac-109">You can access that content here: [Xbox Live partner content](https://developer.microsoft.com/en-us/games/xbox/docs/xboxlive/xbox-live-partners/partner-content).</span><span class="sxs-lookup"><span data-stu-id="cf0ac-109">You can access that content here: [Xbox Live partner content](https://developer.microsoft.com/en-us/games/xbox/docs/xboxlive/xbox-live-partners/partner-content).</span></span>

## <a name="why-should-you-use-xbox-live"></a><span data-ttu-id="cf0ac-110">Why should you use Xbox Live?</span><span class="sxs-lookup"><span data-stu-id="cf0ac-110">Why should you use Xbox Live?</span></span>

<span data-ttu-id="cf0ac-111">Xbox Live offers an array of features designed to help promote your game and keep gamers engaged:</span><span class="sxs-lookup"><span data-stu-id="cf0ac-111">Xbox Live offers an array of features designed to help promote your game and keep gamers engaged:</span></span>

- <span data-ttu-id="cf0ac-112">Xbox Live social platform lets gamers connect with friends and talk about your game.</span><span class="sxs-lookup"><span data-stu-id="cf0ac-112">Xbox Live social platform lets gamers connect with friends and talk about your game.</span></span>
- <span data-ttu-id="cf0ac-113">Xbox Live achievements helps your game get popular by giving your game free promotion to the Xbox Live social graph when gamers unlock achievements.</span><span class="sxs-lookup"><span data-stu-id="cf0ac-113">Xbox Live achievements helps your game get popular by giving your game free promotion to the Xbox Live social graph when gamers unlock achievements.</span></span>
- <span data-ttu-id="cf0ac-114">Xbox Live leaderboards helps drive engagement of your game by letting gamers compete to beat their friends and move up the ranks.</span><span class="sxs-lookup"><span data-stu-id="cf0ac-114">Xbox Live leaderboards helps drive engagement of your game by letting gamers compete to beat their friends and move up the ranks.</span></span>
- <span data-ttu-id="cf0ac-115">Xbox Live multiplayer lets gamers play with their friends or a get matched with other players to compete or cooperate in your game.</span><span class="sxs-lookup"><span data-stu-id="cf0ac-115">Xbox Live multiplayer lets gamers play with their friends or a get matched with other players to compete or cooperate in your game.</span></span>
- <span data-ttu-id="cf0ac-116">Xbox Live connected storage offers free save game roaming between devices so gamers can easily continue game progress between Xbox One and Windows PC.</span><span class="sxs-lookup"><span data-stu-id="cf0ac-116">Xbox Live connected storage offers free save game roaming between devices so gamers can easily continue game progress between Xbox One and Windows PC.</span></span>

## <a name="1-choose-a-platform"></a><span data-ttu-id="cf0ac-117">1. プラットフォームを選択する</span><span class="sxs-lookup"><span data-stu-id="cf0ac-117">1. Choose a platform</span></span>
<span data-ttu-id="cf0ac-118">Xbox 開発キット (XDK)、ユニバーサル Windows プラットフォーム (UWP)、またはクロスプレイ ゲームのどれを作成するかを決定します。</span><span class="sxs-lookup"><span data-stu-id="cf0ac-118">Decide between making an Xbox Development Kit (XDK), Universal Windows Platform (UWP), or cross-play game:</span></span>

- <span data-ttu-id="cf0ac-119">XDK ベースのゲームは Xbox One 本体でのみ動作します。</span><span class="sxs-lookup"><span data-stu-id="cf0ac-119">XDK based games only run on the Xbox One console</span></span>
- <span data-ttu-id="cf0ac-120">UWP games can target any Windows platform such as Windows PC, Windows Phone, or Xbox One</span><span class="sxs-lookup"><span data-stu-id="cf0ac-120">UWP games can target any Windows platform such as Windows PC, Windows Phone, or Xbox One</span></span>
  - <span data-ttu-id="cf0ac-121">For Xbox One, see [UWP on Xbox One](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/index) and specifically [System resources for UWP apps and games on Xbox One](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/system-resource-allocation)</span><span class="sxs-lookup"><span data-stu-id="cf0ac-121">For Xbox One, see [UWP on Xbox One](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/index) and specifically [System resources for UWP apps and games on Xbox One](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/system-resource-allocation)</span></span>
- <span data-ttu-id="cf0ac-122">クロスプレイ ゲームは、通常、XDK と UWP の両方のパスを使用する Xbox One と Windows PC を対象とするゲームです。</span><span class="sxs-lookup"><span data-stu-id="cf0ac-122">Cross-play games are typically games that target Xbox One and Windows PC using both the XDK and UWP paths.</span></span>

## <a name="2-ensure-that-you-have-a-title-created-on-dev-center-or-xdp"></a><span data-ttu-id="cf0ac-123">2. デベロッパー センターまたは XDP でタイトルが作成されていることを確認する</span><span class="sxs-lookup"><span data-stu-id="cf0ac-123">2. Ensure that you have a title created on Dev Center or XDP</span></span>
<span data-ttu-id="cf0ac-124">Every Xbox Live title must be defined on Dev Center or the Xbox Developer Portal (XDP) before you will be able to sign-in and make Xbox Live Service calls.</span><span class="sxs-lookup"><span data-stu-id="cf0ac-124">Every Xbox Live title must be defined on Dev Center or the Xbox Developer Portal (XDP) before you will be able to sign-in and make Xbox Live Service calls.</span></span>  <span data-ttu-id="cf0ac-125">これを行う方法は、「[新しいタイトルの作成](create-a-new-title.md)」で説明します。</span><span class="sxs-lookup"><span data-stu-id="cf0ac-125">[Creating A New Title](create-a-new-title.md) will show you how to do this.</span></span>

## <a name="3-follow-the-appropriate-guide-to-setup-your-ide-or-game-engine"></a><span data-ttu-id="cf0ac-126">3. 適切なガイドに従って IDE やゲーム エンジンをセットアップする</span><span class="sxs-lookup"><span data-stu-id="cf0ac-126">3. Follow the appropriate guide to setup your IDE or game engine</span></span>
<span data-ttu-id="cf0ac-127">You can follow the appropriate Getting Started guide for your platform and engine and learn the basics of Xbox Live as you go along.</span><span class="sxs-lookup"><span data-stu-id="cf0ac-127">You can follow the appropriate Getting Started guide for your platform and engine and learn the basics of Xbox Live as you go along.</span></span>

* <span data-ttu-id="cf0ac-128">[Getting started using Visual Studio for UWP games](get-started-with-visual-studio-and-uwp.md) will show you how to link your Visual Studio project with your Xbox Live configuration on Dev Center.</span><span class="sxs-lookup"><span data-stu-id="cf0ac-128">[Getting started using Visual Studio for UWP games](get-started-with-visual-studio-and-uwp.md) will show you how to link your Visual Studio project with your Xbox Live configuration on Dev Center.</span></span>
* <span data-ttu-id="cf0ac-129">[Getting started using Unity for UWP games](partner-add-xbox-live-to-unity-uwp.md) will show you how to create a new Xbox Live enabled Unity title, add features such as Leaderboards to your title, and generate a native Visual Studio project.</span><span class="sxs-lookup"><span data-stu-id="cf0ac-129">[Getting started using Unity for UWP games](partner-add-xbox-live-to-unity-uwp.md) will show you how to create a new Xbox Live enabled Unity title, add features such as Leaderboards to your title, and generate a native Visual Studio project.</span></span>
* <span data-ttu-id="cf0ac-130">[Getting started using Visual Studio for XDK based games](xdk-developers.md) will show you how to get your Visual Studio project setup if you are making an Xbox One title using the XDK.</span><span class="sxs-lookup"><span data-stu-id="cf0ac-130">[Getting started using Visual Studio for XDK based games](xdk-developers.md) will show you how to get your Visual Studio project setup if you are making an Xbox One title using the XDK.</span></span>
* <span data-ttu-id="cf0ac-131">[Getting started making a cross-play game](get-started-with-cross-play-games.md) explains how to make a product that is an XDK based game for Xbox One and a UWP based game for Windows 10 PC.</span><span class="sxs-lookup"><span data-stu-id="cf0ac-131">[Getting started making a cross-play game](get-started-with-cross-play-games.md) explains how to make a product that is an XDK based game for Xbox One and a UWP based game for Windows 10 PC.</span></span>

## <a name="4-xbox-live-concepts"></a><span data-ttu-id="cf0ac-132">4. Xbox Live の概念</span><span class="sxs-lookup"><span data-stu-id="cf0ac-132">4. Xbox Live Concepts</span></span>
<span data-ttu-id="cf0ac-133">タイトルを作成したら、タイトルの開発エクスペリエンスに影響を与える Xbox Live の概念について理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf0ac-133">Once you have a title created, you should learn about the Xbox Live concepts that will affect your experience developing titles:</span></span>

- [<span data-ttu-id="cf0ac-134">Xbox Live のサンドボックス</span><span class="sxs-lookup"><span data-stu-id="cf0ac-134">Xbox Live sandboxes</span></span>](../xbox-live-sandboxes.md)
- [<span data-ttu-id="cf0ac-135">Xbox Live test accounts</span><span class="sxs-lookup"><span data-stu-id="cf0ac-135">Xbox Live test accounts</span></span>](../xbox-live-test-accounts.md)
- [<span data-ttu-id="cf0ac-136">Introduction to Xbox Live APIs</span><span class="sxs-lookup"><span data-stu-id="cf0ac-136">Introduction to Xbox Live APIs</span></span>](../introduction-to-xbox-live-apis.md)

## <a name="5-add-xbox-live-features"></a><span data-ttu-id="cf0ac-137">5. Add Xbox Live Features</span><span class="sxs-lookup"><span data-stu-id="cf0ac-137">5. Add Xbox Live Features</span></span>

<span data-ttu-id="cf0ac-138">Add Xbox Live features to your game:</span><span class="sxs-lookup"><span data-stu-id="cf0ac-138">Add Xbox Live features to your game:</span></span>

- [<span data-ttu-id="cf0ac-139">Xbox Live Social Platform - Profile, Friends, Presence</span><span class="sxs-lookup"><span data-stu-id="cf0ac-139">Xbox Live Social Platform - Profile, Friends, Presence</span></span>](../social-platform/social-platform.md)
- [<span data-ttu-id="cf0ac-140">Xbox Live Data Platform - Stats, Leaderboards, Achievements</span><span class="sxs-lookup"><span data-stu-id="cf0ac-140">Xbox Live Data Platform - Stats, Leaderboards, Achievements</span></span>](../data-platform/data-platform.md)
- [<span data-ttu-id="cf0ac-141">Xbox Live Multiplayer Platform - Invite, Matchmaking, Tournaments</span><span class="sxs-lookup"><span data-stu-id="cf0ac-141">Xbox Live Multiplayer Platform - Invite, Matchmaking, Tournaments</span></span>](../multiplayer/multiplayer-intro.md)
- [<span data-ttu-id="cf0ac-142">Xbox Live Storage Platform - Connected Storage, Title Storage</span><span class="sxs-lookup"><span data-stu-id="cf0ac-142">Xbox Live Storage Platform - Connected Storage, Title Storage</span></span>](../storage-platform/storage-platform.md)
- [<span data-ttu-id="cf0ac-143">Contextual Search</span><span class="sxs-lookup"><span data-stu-id="cf0ac-143">Contextual Search</span></span>](../contextual-search/introduction-to-contextual-search.md)

## <a name="6-release-your-title"></a><span data-ttu-id="cf0ac-144">6. タイトルをリリースする</span><span class="sxs-lookup"><span data-stu-id="cf0ac-144">6. Release Your Title</span></span>

<span data-ttu-id="cf0ac-145">ID@Xbox および対象パートナーは、タイトルをリリースする前に認定プロセスに合格する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf0ac-145">ID@Xbox and managed partners must go through a certification process before releasing their titles.</span></span>  <span data-ttu-id="cf0ac-146">この理由は、タイトルがオンライン マルチプレイヤー、実績、リッチ プレゼンスなどの追加機能にアクセスする場合があるためです。</span><span class="sxs-lookup"><span data-stu-id="cf0ac-146">This is because the titles have access to additional features such as online multiplayer, achievements, and rich presence.</span></span>  <span data-ttu-id="cf0ac-147">タイトルをリリースする準備ができたら、Microsoft の担当者に申請とリリースのプロセスに関する詳細をお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="cf0ac-147">Once you are ready to release your title, contact your Microsoft representative for more details on the submission and release process.</span></span>
