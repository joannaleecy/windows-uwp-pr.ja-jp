---
title: マルチプレイヤーの付録
author: KevinAsgari
description: Xbox Live マルチプレイヤー 2015 サービスの詳細情報へのリンクがあります。
ms.assetid: 412ae5f4-6975-4a8b-9cc2-9747e093ec4d
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: low
ms.openlocfilehash: 4629f4935ec68d711f27b3cbe45767207b78730e
ms.sourcegitcommit: 01760b73fa8cdb423a9aa1f63e72e70647d8f6ab
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/24/2018
---
# <a name="multiplayer-appendix"></a><span data-ttu-id="2fa26-104">マルチプレイヤーの付録</span><span class="sxs-lookup"><span data-stu-id="2fa26-104">Multiplayer appendix</span></span>

<span data-ttu-id="2fa26-105">Xbox One のマルチプレイヤー システムにより、ゲーム プレイやゲーム プレイヤーをグループにまとめることができます。</span><span class="sxs-lookup"><span data-stu-id="2fa26-105">The multiplayer system in Xbox One enables game play and the assembly of game players into groups.</span></span> <span data-ttu-id="2fa26-106">このシステムは、安全で、使いやすく、柔軟であるため、シンプルな機能をすばやく作成できるだけでなく、さらに複雑な機能を作成し、独自のサービスを組み込むこともできます。</span><span class="sxs-lookup"><span data-stu-id="2fa26-106">The system is secure, easy to use, and flexible, allowing you not only to build simple features quickly, but also to build more complex features and plug in your own services.</span></span>

> **<span data-ttu-id="2fa26-107">注意</span><span class="sxs-lookup"><span data-stu-id="2fa26-107">Note</span></span>**  
<span data-ttu-id="2fa26-108">ここでは、API の高度な使用方法を示します。</span><span class="sxs-lookup"><span data-stu-id="2fa26-108">This article is for advanced API usage.</span></span>  <span data-ttu-id="2fa26-109">まず最初に、開発が大幅に簡素化される [Multiplayer Manager API](../multiplayer-manager.md) を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2fa26-109">As a starting point, please take a look at the [Multiplayer Manager API](../multiplayer-manager.md) which significantly simplifies development.</span></span>  <span data-ttu-id="2fa26-110">Multiplayer Manager でサポートされていないシナリオが見つかった場合は、担当の DAM までご連絡ください。</span><span class="sxs-lookup"><span data-stu-id="2fa26-110">Please let your DAM know if you find an unsupported scenario in the Multiplayer Manager.</span></span>

<span data-ttu-id="2fa26-111">マルチプレイヤー システムの現在のバージョンは 2015 マルチプレイヤーです。</span><span class="sxs-lookup"><span data-stu-id="2fa26-111">The current version of the multiplayer system is 2015 Multiplayer.</span></span> <span data-ttu-id="2fa26-112">このバージョンは、"ゲーム パーティー" の概念を抽象化し、マルチプレイヤー セッション ディレクトリ (MPSD) を使用してゲーム セッションを制御します。</span><span class="sxs-lookup"><span data-stu-id="2fa26-112">This version abstracts the "game party" concept and uses the multiplayer session directory (MPSD) to control game sessions.</span></span>

> **<span data-ttu-id="2fa26-113">注意</span><span class="sxs-lookup"><span data-stu-id="2fa26-113">Note</span></span>**  
<span data-ttu-id="2fa26-114">マルチプレイヤー システムの以前のバージョンは 2014 マルチプレイヤーです。</span><span class="sxs-lookup"><span data-stu-id="2fa26-114">The previous version of the multiplayer system is 2014 Multiplayer.</span></span> <span data-ttu-id="2fa26-115">このバージョンは、ゲーム パーティーの概念およびパーティーを通じてのゲームへの参加に基づいています。</span><span class="sxs-lookup"><span data-stu-id="2fa26-115">This version is based on the concept of the game party and participation in games through parties.</span></span> <span data-ttu-id="2fa26-116">このバージョンは、ソース コードが XDK で提供されていますが、現在は非推奨となっています。</span><span class="sxs-lookup"><span data-stu-id="2fa26-116">This version is now deprecated, although source code for it is still provided with the XDK.</span></span> <span data-ttu-id="2fa26-117">2014 マルチプレイヤーのマニュアルは、XDK に付属しなくなりました。</span><span class="sxs-lookup"><span data-stu-id="2fa26-117">The 2014 Multiplayer documentation is no longer included with the XDK.</span></span> <span data-ttu-id="2fa26-118">このドキュメントを使用する場合は、2014 年のリリースの XDK を使用してください。</span><span class="sxs-lookup"><span data-stu-id="2fa26-118">If you need this documentation, please use a 2014 release of the XDK.</span></span>


## <a name="in-this-section"></a><span data-ttu-id="2fa26-119">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="2fa26-119">In this section</span></span>

[<span data-ttu-id="2fa26-120">概要</span><span class="sxs-lookup"><span data-stu-id="2fa26-120">Introduction</span></span>](introduction-to-the-multiplayer-system.md)  
<span data-ttu-id="2fa26-121">マルチプレイヤー システムについて説明します。</span><span class="sxs-lookup"><span data-stu-id="2fa26-121">Introduces the multiplayer system.</span></span>

[<span data-ttu-id="2fa26-122">マルチプレイヤー セッション ディレクトリ (MPSD)</span><span class="sxs-lookup"><span data-stu-id="2fa26-122">Multiplayer Session Directory (mpsd)</span></span>](multiplayer-session-directory.md)  
<span data-ttu-id="2fa26-123">すべてのタイトルにわたってゲームのマルチプレイヤー API メタデータを一元化し、ゲーム セッションを管理するマルチプレイヤー セッション ディレクトリ (MPSD) について説明します。</span><span class="sxs-lookup"><span data-stu-id="2fa26-123">Describes multiplayer session directory (MPSD), which centralizes a game's multiplayer API metadata across all the titles and manages game sessions.</span></span>

[<span data-ttu-id="2fa26-124">MPSD セッションの詳細</span><span class="sxs-lookup"><span data-stu-id="2fa26-124">MPSD Session Details</span></span>](mpsd-session-details.md)  
<span data-ttu-id="2fa26-125">MPSD セッションの詳細について説明します。</span><span class="sxs-lookup"><span data-stu-id="2fa26-125">Provides details of an MPSD session.</span></span>

[<span data-ttu-id="2fa26-126">タイトルを 2015 マルチプレイヤーに適合させるときの一般的な問題</span><span class="sxs-lookup"><span data-stu-id="2fa26-126">Common Issues When Adapting Your Titles for 2015 Multiplayer</span></span>](common-issues-when-adapting-multiplayer.md)  
<span data-ttu-id="2fa26-127">2015 マルチプレイヤーで動作するようにタイトルを適合させるときに考慮する一般的な問題について説明します。</span><span class="sxs-lookup"><span data-stu-id="2fa26-127">Describes common issues to consider when you adapt titles to operate with 2015 Multiplayer.</span></span>

[<span data-ttu-id="2fa26-128">SmartMatch マッチメイキング</span><span class="sxs-lookup"><span data-stu-id="2fa26-128">SmartMatch Matchmaking</span></span>](smartmatch-matchmaking.md)  
<span data-ttu-id="2fa26-129">Xbox Live によって使用されるマッチメイキング システムについて説明します。</span><span class="sxs-lookup"><span data-stu-id="2fa26-129">Describes the matchmaking system used by Xbox Live.</span></span>

[<span data-ttu-id="2fa26-130">アービターの移行</span><span class="sxs-lookup"><span data-stu-id="2fa26-130">Migrating an Arbiter</span></span>](migrating-an-arbiter.md)  
<span data-ttu-id="2fa26-131">MPSD のアービター移行プロセスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="2fa26-131">Describes the MPSD process for arbiter migration.</span></span>

[<span data-ttu-id="2fa26-132">SmartMatch マッチメイキングの使用</span><span class="sxs-lookup"><span data-stu-id="2fa26-132">Using SmartMatch Matchmaking</span></span>](using-smartmatch-matchmaking.md)  
<span data-ttu-id="2fa26-133">SmartMatch マッチメイキングを使用する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="2fa26-133">Describes how to use SmartMatch matchmaking.</span></span>

[<span data-ttu-id="2fa26-134">マルチプレイヤーの実行方法</span><span class="sxs-lookup"><span data-stu-id="2fa26-134">Multiplayer How To's</span></span>](multiplayer-how-tos.md)  
<span data-ttu-id="2fa26-135">タイトルで 2015 マルチプレイヤーを使用するための手順を説明します。</span><span class="sxs-lookup"><span data-stu-id="2fa26-135">Provides procedures for using 2015 Multiplayer in titles.</span></span>

[<span data-ttu-id="2fa26-136">マルチプレイヤー セッション ステータス コード</span><span class="sxs-lookup"><span data-stu-id="2fa26-136">Multiplayer Session Status Codes</span></span>](multiplayer-session-status-codes.md)  
<span data-ttu-id="2fa26-137">Xbox One のマルチプレイヤー セッション ステータス コードを定義します。</span><span class="sxs-lookup"><span data-stu-id="2fa26-137">Defines multiplayer session status codes for Xbox One.</span></span>

[<span data-ttu-id="2fa26-138">2015 マルチプレイヤーの FAQ とトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="2fa26-138">2015 Multiplayer FAQs and Troubleshooting</span></span>](multiplayer-2015-faq.md)  
<span data-ttu-id="2fa26-139">マルチプレイヤーの FAQ とトラブルシューティングを定義します。</span><span class="sxs-lookup"><span data-stu-id="2fa26-139">Defines FAQs and troubleshooting for Multiplayer.</span></span>

<span data-ttu-id="2fa26-140">[Xbox One マルチプレイヤー セッション ディレクトリ](xbox-one-multiplayer-session-directory.md): 新しい Xbox One マルチプレイヤー セッション ディレクトリ (MPSD) サービスを使用するマルチプレイヤー セッション作成の概要を示します。</span><span class="sxs-lookup"><span data-stu-id="2fa26-140">[Xbox One multiplayer session directory](xbox-one-multiplayer-session-directory.md) Provides an overview of multiplayer session creation using the new Xbox One Multiplayer Session Directory (MPSD) service.</span></span>

<span data-ttu-id="2fa26-141">[マルチプレイヤー ゲームへの招待に関するフロー](flows-for-multiplayer-game-invites.md): 別のプレイヤーをマルチプレイヤー ゲームに招待する際に伴うエクスペリエンスのフローを説明します。</span><span class="sxs-lookup"><span data-stu-id="2fa26-141">[Flows for multiplayer game invites](flows-for-multiplayer-game-invites.md) Describes the flow of experiences involved in inviting another player to a multiplayer game.</span></span>

<span data-ttu-id="2fa26-142">[ゲーム セッションおよびゲーム パーティーの可視性と参加可能性](game-session-and-game-party-visibility-and-joinability.md): マルチプレイヤー ゲーム セッションに関連する可視性と参加可能性の相違点を説明します。</span><span class="sxs-lookup"><span data-stu-id="2fa26-142">[Game session and game party visibility and joinability](game-session-and-game-party-visibility-and-joinability.md) Describes the differences between visibility and joinability as relates to a multiplayer game session.</span></span>
