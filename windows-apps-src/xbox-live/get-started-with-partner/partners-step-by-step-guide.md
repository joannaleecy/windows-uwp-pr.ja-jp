---
title: Xbox Live パートナー向けステップ バイ ステップ ガイド
author: KevinAsgari
description: 対象パートナー向けに Xbox Live を統合するための手順のガイドラインを説明します。
ms.assetid: f0c9db8f-f492-4955-8622-e1736f0a4509
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6c1b1741beaf1ffa2b034726a41c56339136e6f1
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4505596"
---
# <a name="step-by-step-guide-to-integrate-xbox-live-for-managed-partners-and-idxbox-members"></a><span data-ttu-id="6b228-104">対象パートナーおよび ID@Xbox メンバー向けに Xbox Live を統合するためのステップ バイ ステップ ガイド</span><span class="sxs-lookup"><span data-stu-id="6b228-104">Step by step guide to integrate Xbox Live for managed partners and ID@Xbox members</span></span>

<span data-ttu-id="6b228-105">このセクションは、Xbox Live を開始し実行する際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="6b228-105">This section will help you get up and running with Xbox Live:</span></span>

## <a name="1-choose-a-platform"></a><span data-ttu-id="6b228-106">1. プラットフォームを選択する</span><span class="sxs-lookup"><span data-stu-id="6b228-106">1. Choose a Platform</span></span>
<span data-ttu-id="6b228-107">Xbox 開発キット (XDK)、ユニバーサル Windows プラットフォーム (UWP)、またはクロスプレイ ゲームのどれを作成するかを決定します。</span><span class="sxs-lookup"><span data-stu-id="6b228-107">Decide between making an Xbox Development Kit (XDK), Universal Windows Platform (UWP), or cross-play game.</span></span>

- <span data-ttu-id="6b228-108">XDK ベースのゲームは Xbox One 本体のみで動作します。</span><span class="sxs-lookup"><span data-stu-id="6b228-108">XDK based games only run on the Xbox One console</span></span>
- <span data-ttu-id="6b228-109">UWP ゲームは、Windows PC、Windows Phone、Xbox One など、すべての Windows プラットフォームを対象にすることができます。</span><span class="sxs-lookup"><span data-stu-id="6b228-109">UWP games can target any Windows platform such as Windows PC, Windows Phone, or Xbox One</span></span>
  - <span data-ttu-id="6b228-110">Xbox One については、「[Xbox One の UWP](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/index)」をご覧ください。また、「[Xbox One 上の UWP アプリとゲームのシステム リソース](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/system-resource-allocation)」をご覧になることもお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6b228-110">For Xbox One, see [UWP on Xbox One](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/index) and specifically [System resources for UWP apps and games on Xbox One](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/system-resource-allocation)</span></span>
- <span data-ttu-id="6b228-111">クロスプレイ ゲームは、通常、XDK と UWP の両方のパスを使用する Xbox One と Windows PC を対象とするゲームです。</span><span class="sxs-lookup"><span data-stu-id="6b228-111">Cross-play games are typically games that target Xbox One and Windows PC using both the XDK and UWP paths.</span></span>

## <a name="2-ensure-you-have-a-title-created-on-dev-center-or-xdp"></a><span data-ttu-id="6b228-112">2. デベロッパー センターまたは XDP で作成されたタイトルがあることを確認する</span><span class="sxs-lookup"><span data-stu-id="6b228-112">2. Ensure you have a title created on Dev Center or XDP</span></span>
<span data-ttu-id="6b228-113">すべての Xbox Live タイトルは、サインインして Xbox Live サービスを呼び出すことができるようになるには、デベロッパー センターまたは Xbox デベロッパー ポータル (XDP) で定義されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b228-113">Every Xbox Live title must be defined on Dev Center or the Xbox Developer Portal (XDP) before you will be able to sign-in and make Xbox Live Service calls.</span></span>  <span data-ttu-id="6b228-114">これを行う方法は、「[新しいタイトルの作成](create-a-new-title.md)」で説明します。</span><span class="sxs-lookup"><span data-stu-id="6b228-114">[Creating A New Title](create-a-new-title.md) will show you how to do this.</span></span>

## <a name="3-follow-the-appropriate-guide-to-setup-your-ide-or-game-engine"></a><span data-ttu-id="6b228-115">3. 適切なガイドに従って、IDE やゲーム エンジンをセットアップする</span><span class="sxs-lookup"><span data-stu-id="6b228-115">3. Follow the appropriate guide to setup your IDE or Game Engine</span></span>
<span data-ttu-id="6b228-116">プラットフォームやエンジンに関する適切なファースト ステップ ガイドに従い、それに沿って学習することで、Xbox Live の基本を習得することができます。</span><span class="sxs-lookup"><span data-stu-id="6b228-116">You can follow the appropriate Getting Started guide for your platform and engine and learn the basics of Xbox Live as you go along.</span></span>

* <span data-ttu-id="6b228-117">「[UWP ゲーム用 Visual Studio の使用に関する概要](get-started-with-visual-studio-and-uwp.md)」では、デベロッパー センターで Xbox Live 構成を使用して Visual Studio プロジェクトをリンクする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="6b228-117">[Getting started using Visual Studio for UWP games](get-started-with-visual-studio-and-uwp.md) will show you how to link your Visual Studio project with your Xbox Live configuration on Dev Center.</span></span>

* <span data-ttu-id="6b228-118">「[UWP ゲーム用 Unity の使用に関する概要](partner-add-xbox-live-to-unity-uwp.md)」では、Xbox Live 対応の新しい Unity タイトルを作成する方法、ランキングなどの機能をタイトルに追加する方法、およびネイティブの Visual Studio プロジェクトを生成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="6b228-118">[Getting started using Unity for UWP games](partner-add-xbox-live-to-unity-uwp.md) will show you how to create a new Xbox Live enabled Unity title, add features such as Leaderboards to your title, and generate a native Visual Studio project.</span></span>

* <span data-ttu-id="6b228-119">「[XDK ベースのゲームで Visual Studio を使用する際の概要](xdk-developers.md)」では、XDK を使用して Xbox One タイトルを作成する場合に Visual Studio プロジェクトをセットアップする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="6b228-119">[Getting started using Visual Studio for XDK based games](xdk-developers.md) will show you how to get your Visual Studio project setup if you are making an Xbox One title using the XDK.</span></span>

* <span data-ttu-id="6b228-120">「[クロスプレイ ゲームの作成に関する概要](get-started-with-cross-play-games.md)」では、Xbox One 向けの XDK ベースのゲームと Windows 10 PC 向けの UWP ベースのゲームを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="6b228-120">[Getting started making a cross-play game](get-started-with-cross-play-games.md) explains how to make a product that is an XDK based game for Xbox One and a UWP based game for Windows 10 PC.</span></span>

## <a name="4-xbox-live-concepts"></a><span data-ttu-id="6b228-121">4. Xbox Live の概念</span><span class="sxs-lookup"><span data-stu-id="6b228-121">4. Xbox Live Concepts</span></span>
<span data-ttu-id="6b228-122">タイトルを作成したら、タイトルの開発エクスペリエンスに影響を与える Xbox Live の概念について理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b228-122">Once you have a title created, you should learn about the Xbox Live concepts that will affect your experience developing titles.</span></span>

- [<span data-ttu-id="6b228-123">Xbox Live のサンドボックス</span><span class="sxs-lookup"><span data-stu-id="6b228-123">Xbox Live sandboxes</span></span>](../xbox-live-sandboxes.md)
- [<span data-ttu-id="6b228-124">Xbox Live テスト アカウント</span><span class="sxs-lookup"><span data-stu-id="6b228-124">Xbox Live test accounts</span></span>](../xbox-live-test-accounts.md)
- [<span data-ttu-id="6b228-125">Xbox Live API の概要</span><span class="sxs-lookup"><span data-stu-id="6b228-125">Introduction to Xbox Live APIs</span></span>](../introduction-to-xbox-live-apis.md)

## <a name="5-add-xbox-live-features"></a><span data-ttu-id="6b228-126">5. Xbox Live の機能を追加する</span><span class="sxs-lookup"><span data-stu-id="6b228-126">5. Add Xbox Live Features</span></span>

<span data-ttu-id="6b228-127">Xbox Live の機能をゲームに追加します。</span><span class="sxs-lookup"><span data-stu-id="6b228-127">Add Xbox Live features to your game:</span></span>

- [<span data-ttu-id="6b228-128">Xbox Live ソーシャル プラットフォーム - プロフィール、フレンド、プレゼンス</span><span class="sxs-lookup"><span data-stu-id="6b228-128">Xbox Live Social Platform - Profile, Friends, Presence</span></span>](../social-platform/social-platform.md)
- [<span data-ttu-id="6b228-129">Xbox Live データ プラットフォーム - 統計、ランキング、実績</span><span class="sxs-lookup"><span data-stu-id="6b228-129">Xbox Live Data Platform - Stats, Leaderboards, Achievements</span></span>](../data-platform/data-platform.md)
- [<span data-ttu-id="6b228-130">Xbox Live マルチプレイヤー プラットフォーム - 招待、マッチメイキング、トーナメント</span><span class="sxs-lookup"><span data-stu-id="6b228-130">Xbox Live Multiplayer Platform - Invite, Matchmaking, Tournaments</span></span>](../multiplayer/multiplayer-intro.md)
- [<span data-ttu-id="6b228-131">Xbox Live ストレージ プラットフォーム - 接続ストレージ、タイトル ストレージ</span><span class="sxs-lookup"><span data-stu-id="6b228-131">Xbox Live Storage Platform - Connected Storage, Title Storage</span></span>](../storage-platform/storage-platform.md)
- [<span data-ttu-id="6b228-132">コンテキスト検索</span><span class="sxs-lookup"><span data-stu-id="6b228-132">Contextual Search</span></span>](../contextual-search/introduction-to-contextual-search.md)

## <a name="6-release-your-title"></a><span data-ttu-id="6b228-133">6. タイトルをリリースする</span><span class="sxs-lookup"><span data-stu-id="6b228-133">6. Release Your Title</span></span>

<span data-ttu-id="6b228-134">ID@Xbox タイトルとゲーム パブリッシャーがリリースするタイトルの場合、リリースまでに Microsoft パートナーが認定プロセスに合格する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b228-134">ID@Xbox titles and titles released by game publisher is this a Microsoft Partner must go through a certification process before release.</span></span>  <span data-ttu-id="6b228-135">その理由は、こうしたタイトルでは、マルチプレイヤー、実績、リッチ プレゼンスなどの追加機能へアクセスする場合があるためです。</span><span class="sxs-lookup"><span data-stu-id="6b228-135">This is because these titles have access to additional features such as Multiplayer, Achievements, and Rich Presence.</span></span>  <span data-ttu-id="6b228-136">タイトルをリリースする準備ができたら、Microsoft の担当者に申請とリリースのプロセスに関する詳細を問い合わせてください。</span><span class="sxs-lookup"><span data-stu-id="6b228-136">Once you are ready to release your title, contact your Microsoft representative for more detail on the submission and release process.</span></span>
