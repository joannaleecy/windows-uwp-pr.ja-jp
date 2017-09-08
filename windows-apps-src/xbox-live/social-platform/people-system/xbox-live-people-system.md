---
title: "Xbox Live People システム"
author: KevinAsgari
description: "Xbox Live People システムについて説明します。"
ms.assetid: f1881a52-8e65-4364-9937-d2b8b8476cbf
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "xbox live, xbox, ゲーム, uwp, windows 10, xbox one, ソーシャル, People システム, フレンド"
ms.openlocfilehash: bddafe769bd00d311df0a54aac0bdc13638f1c3f
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="xbox-live-people-system"></a><span data-ttu-id="559be-104">Xbox Live People システム</span><span class="sxs-lookup"><span data-stu-id="559be-104">Xbox Live People System</span></span>

<span data-ttu-id="559be-105">Xbox One のリリースから、Xbox Live は、Xbox Live のソーシャル ファブリックを発展するために、以前の Xbox 360 _フレンド_ システムから新しい _People_ システムに移行しています。</span><span class="sxs-lookup"><span data-stu-id="559be-105">For the Xbox One launch, Xbox Live migrated from the previous Xbox 360 era _friends_ system to a new _people_ system that reworks the social fabric in Xbox Live.</span></span> <span data-ttu-id="559be-106">People システムの目的は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="559be-106">The goals of the people system include:</span></span>

- <span data-ttu-id="559be-107">ユーザーが自分の知っている人物を見つけやすくします。</span><span class="sxs-lookup"><span data-stu-id="559be-107">Make it easy for users to recognize people they know.</span></span>

  <span data-ttu-id="559be-108">すべてのエクスペリエンスで実名を使用できます。実名は、匿名ではない対話関係を築くための基礎となります。</span><span class="sxs-lookup"><span data-stu-id="559be-108">Real names are available in all experiences and are the foundation of interaction for non-anonymous relationships.</span></span>

- <span data-ttu-id="559be-109">既存の Xbox Live の関係を Xbox One に移行します。</span><span class="sxs-lookup"><span data-stu-id="559be-109">Existing Xbox Live relationships migrate to Xbox One.</span></span>

  <span data-ttu-id="559be-110">Xbox 360 で追加したフレンドを持つユーザーは、最新のエクスペリエンスを使用するときにリストがリセットされません。</span><span class="sxs-lookup"><span data-stu-id="559be-110">Users who have friends they've added in Xbox 360 don't have their lists reset when they use a modern experience.</span></span>

- <span data-ttu-id="559be-111">ゲーマータグによる匿名の関係も引き続きサポートします。</span><span class="sxs-lookup"><span data-stu-id="559be-111">Continue to support maintaining anonymous gamertag relationships.</span></span>

  <span data-ttu-id="559be-112">マッチメイキング サービスによって作成されたマッチからのすばらしいゲームプレイ セッションの後、ユーザーはその人を自分のユーザー リストに追加し、後で簡単にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="559be-112">After a great gameplay session from a match made by the matchmaking service, a user can add that person to his or her people list for easy access later.</span></span>

- <span data-ttu-id="559be-113">長いユーザー リストを簡便な方法で管理できるようにします。</span><span class="sxs-lookup"><span data-stu-id="559be-113">Provide a simple way to manage long lists of people.</span></span>

  <span data-ttu-id="559be-114">ユーザーは人々をお気に入りとしてマークして、Xbox One エクスペリエンスでそれらの人々を最初に表示できます。</span><span class="sxs-lookup"><span data-stu-id="559be-114">Users can mark people as favorites so that Xbox One experiences show those people first.</span></span>

- <span data-ttu-id="559be-115">Xbox Live のプライバシー システムを進化させて、ユーザーが信頼する実世界の関係により多くの権利を与え、匿名 (ゲーマータグのみ) の関係に与える権利を減らすことができるようにします。</span><span class="sxs-lookup"><span data-stu-id="559be-115">Evolve the Xbox Live privacy system to enable users to give more rights to trusted real-world relationships and fewer rights to anonymous (gamertag-only) relationships.</span></span>
- <span data-ttu-id="559be-116">下位互換性を確保します。</span><span class="sxs-lookup"><span data-stu-id="559be-116">Ensure backward compatibility.</span></span>

  <span data-ttu-id="559be-117">従来のクライアントおよび従来のサービス コードは、新しいシステムに移行しなくても、引き続き以前のソーシャル インフラストラクチャに対する処理を実行します。</span><span class="sxs-lookup"><span data-stu-id="559be-117">Legacy clients and legacy service code continue to operate against the previous social infrastructure without requiring a move to the new system.</span></span>

## <a name="identity-and-display-of-real-names-on-xbox-one"></a><span data-ttu-id="559be-118">Xbox One での実名の識別と表示</span><span class="sxs-lookup"><span data-stu-id="559be-118">Identity and display of real names on Xbox One</span></span>
<span data-ttu-id="559be-119">Xbox One 上のユーザーは Microsoft アカウント ID で認証されます。</span><span class="sxs-lookup"><span data-stu-id="559be-119">Users on Xbox One are authenticated by their Microsoft account identity.</span></span> <span data-ttu-id="559be-120">ユーザーが自分の Microsoft アカウントを使用して本体にサインインすると、シェル全体を通じて、そのユーザーに関連付けられている名前と画像が表示されます。</span><span class="sxs-lookup"><span data-stu-id="559be-120">A user signs into the console by using his or her Microsoft account, and the user's associated name and picture is displayed throughout the shell.</span></span> <span data-ttu-id="559be-121">ユーザーは、実名を提供する外部のソーシャル ネットワークに Xbox Live のプロフィールをリンクしていない場合、システムではゲーマータグとゲーマーアイコンによって表されます (そして、以前の Xbox Live ゲーマータグによる関係は Xbox One に移行されます)。</span><span class="sxs-lookup"><span data-stu-id="559be-121">If a user has not linked his or her Xbox Live profile to an external social network that provides real names, that user will be represented in the system by his or her gamertag and gamerpic (and previous Xbox Live gamertag relationships are migrated to Xbox One).</span></span>

<span data-ttu-id="559be-122">外部ネットワークにリンクすることが推奨されますが、必須ではありません。</span><span class="sxs-lookup"><span data-stu-id="559be-122">Linking to external networks is promoted, but linking is optional.</span></span> <span data-ttu-id="559be-123">ユーザーがプロフィールを外部のソーシャル ネットワークにリンクしているときに、そのネットワークの他のフレンドが Xbox Live アカウントを持っていてプロフィールもリンクしている場合、フレンドは本体では Microsoft アカウント名と画像によって、外部ネットワークで接続を共有するフレンドに対して表されます。</span><span class="sxs-lookup"><span data-stu-id="559be-123">If a user has linked his or her profile to an external social network, when other friends on that network have Xbox Live accounts and they have also linked their profiles, they are represented on the console by their Microsoft account names and pictures to those friends with whom they share a connection in the external network.</span></span> <span data-ttu-id="559be-124">一方、この方法で接続されているユーザーは、外部ネットワークで接続されていない人々に対しては、引き続きゲーマータグとゲーマーアイコンで表されます。</span><span class="sxs-lookup"><span data-stu-id="559be-124">However, users who are connected in this way continue to be represented by their gamertags and gamerpics to people to whom they are not connected in the external network.</span></span>

<span data-ttu-id="559be-125">このセクションの後のトピックでは、これらの関係について説明します。</span><span class="sxs-lookup"><span data-stu-id="559be-125">The subsequent topics in this section elaborate on these relationships.</span></span> <span data-ttu-id="559be-126">関連する API については、「**Microsoft.Xbox.Services.Social 名前空間**」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="559be-126">For information about the related API, see **Microsoft.Xbox.Services.Social Namespace**.</span></span>

## <a name="in-this-section"></a><span data-ttu-id="559be-127">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="559be-127">In this section</span></span>
[<span data-ttu-id="559be-128">一方向の関係</span><span class="sxs-lookup"><span data-stu-id="559be-128">One Way Relationships</span></span>](one-way-relationships.md)  
<span data-ttu-id="559be-129">Xbox Live People システムの一方向関係モデルについて説明します。</span><span class="sxs-lookup"><span data-stu-id="559be-129">Describes the one-way relationship model in the Xbox Live People system.</span></span>

[<span data-ttu-id="559be-130">People システムでのゲーマータグと実名</span><span class="sxs-lookup"><span data-stu-id="559be-130">Gamertags and real names in the People System</span></span>](gamertags-and-real-names.md)  
<span data-ttu-id="559be-131">Xbox Live People システムは、知り合いのユーザーに対しては実名の表示が可能なように設計されています。これは、新しい Xbox Live エクスペリエンスではどの場所でもコンテキストにかかわらず一貫して可能であり、FPS オンライン ゲームでキャラクターがマップ上を走り回っているときの頭上にも表示できます。</span><span class="sxs-lookup"><span data-stu-id="559be-131">The Xbox Live People system is designed to allow the display of real names to people the user knows; consistently everywhere in new Xbox Live experiences regardless of context...even over the character's head when running around a map in an FPS online game.</span></span>

[<span data-ttu-id="559be-132">お気に入りユーザー</span><span class="sxs-lookup"><span data-stu-id="559be-132">Favorite People</span></span>](favorite-people.md)  
<span data-ttu-id="559be-133">Xbox Live People システムでのお気に入り。</span><span class="sxs-lookup"><span data-stu-id="559be-133">Favorites in the Xbox Live People system.</span></span>

[<span data-ttu-id="559be-134">People システムからの人物の表示</span><span class="sxs-lookup"><span data-stu-id="559be-134">Display People from the People System</span></span>](displaying-people-from-the-people-system.md)  
<span data-ttu-id="559be-135">Xbox Live People システムから返される人を表示する方法。</span><span class="sxs-lookup"><span data-stu-id="559be-135">How to display people returned from the Xbox Live People system.</span></span>

[<span data-ttu-id="559be-136">Xbox 360 フレンドの下位互換性</span><span class="sxs-lookup"><span data-stu-id="559be-136">Xbox 360 Friends Backward Compatibility</span></span>](xbox-360-friends-backward-compatibility.md)  
<span data-ttu-id="559be-137">新しい Xbox Live People システムでの Xbox 360 のフレンドの取り扱い方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="559be-137">How to work with Xbox 360 friends in the new Xbox Live People system.</span></span>

[<span data-ttu-id="559be-138">プライバシーと知り合いのユーザー</span><span class="sxs-lookup"><span data-stu-id="559be-138">Privacy and People I Know</span></span>](privacy-and-people-i-know.md)  
<span data-ttu-id="559be-139">People システムでプライバシーを保護します。</span><span class="sxs-lookup"><span data-stu-id="559be-139">Protecting privacy in the People system.</span></span>

[<span data-ttu-id="559be-140">評判</span><span class="sxs-lookup"><span data-stu-id="559be-140">Reputation</span></span>](reputation.md)  
<span data-ttu-id="559be-141">評判システムを使用してプレイヤーのユーザー レポートを集計し、Xbox のサービスで高品質のゲームプレイと行動への動機付けを提供できるようにする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="559be-141">Describes how the reputation system is used to aggregate user reports of players, allowing Xbox services to provide high-quality game play, as well as to incentivize behavior.</span></span>

[<span data-ttu-id="559be-142">タイトルからのプレイヤー フィードバックの送信</span><span class="sxs-lookup"><span data-stu-id="559be-142">Sending Player Feedback From Your Title</span></span>](sending-player-feedback-from-your-title.md)  
<span data-ttu-id="559be-143">タイトルがどのように、ユーザーの評判に影響を与えるフィードバックを提供する助けとなるかを説明します。</span><span class="sxs-lookup"><span data-stu-id="559be-143">Describes how your title can help provide feedback that affects a user's reputation.</span></span>

[<span data-ttu-id="559be-144">Xbox Live ソーシャル サービスのプログラミング</span><span class="sxs-lookup"><span data-stu-id="559be-144">Programming Xbox Live Social Services</span></span>](programming-social-services.md)  
<span data-ttu-id="559be-145">Xbox Live で提供されるソーシャル サービスの使用方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="559be-145">Demonstrates how to use social services provided by Xbox Live.</span></span>
