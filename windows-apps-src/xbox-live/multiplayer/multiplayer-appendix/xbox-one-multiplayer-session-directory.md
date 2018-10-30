---
title: Xbox One マルチプレイヤー セッション ディレクトリ
author: KevinAsgari
description: Xbox Live マルチプレイヤー セッション ディレクトリ (MPSD) サービスを使用してマルチプレイヤー セッションを作成する方法について説明します。
ms.assetid: 70da1be3-5f39-4eed-b62d-9cdd47e413d2
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ad4070d84ca8df2a991eb3d44c7b1c1d7188c13a
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5763102"
---
# <a name="xbox-one-multiplayer-session-directory"></a><span data-ttu-id="beb28-104">Xbox One マルチプレイヤー セッション ディレクトリ</span><span class="sxs-lookup"><span data-stu-id="beb28-104">Xbox One Multiplayer Session Directory</span></span>

<span data-ttu-id="beb28-105">このトピックでは、新しい Xbox One マルチプレイヤー セッション ディレクトリ (MPSD) サービスを使用するマルチプレイヤー セッション作成の概要を示します。</span><span class="sxs-lookup"><span data-stu-id="beb28-105">This topic provides an overview of multiplayer session creation using the new Xbox One Multiplayer Session Directory (MPSD) service.</span></span> <span data-ttu-id="beb28-106">主な対象読者は、セッション テンプレートを Xbox デベロッパー ポータル (XDP) に直接提出する Xbox One タイトル デベロッパーです。</span><span class="sxs-lookup"><span data-stu-id="beb28-106">The paper is directed primarily toward Xbox One title developers who submit their session templates directly to Xbox Development Portal (XDP).</span></span> <span data-ttu-id="beb28-107">MPSD サービスは、同様に、Windows デベロッパー センターで構成できますが、この記事で重視されていません。</span><span class="sxs-lookup"><span data-stu-id="beb28-107">The MPSD service can be configured with the Windows Dev Center as well, but is not focused on in this article.</span></span> <span data-ttu-id="beb28-108">MPSD の構成に関連する用語と概念、使用方法、およびマルチプレイヤー セッションのトラブルシューティングについて理解を促進することを目的としています。</span><span class="sxs-lookup"><span data-stu-id="beb28-108">It is intended to familiarize them with terms and concepts associated with MPSD configuration, usage, and troubleshooting of multiplayer sessions.</span></span>

## <a name="revision-summary"></a><span data-ttu-id="beb28-109">改訂のまとめ</span><span class="sxs-lookup"><span data-stu-id="beb28-109">Revision summary</span></span>

<span data-ttu-id="beb28-110">クライアント側 XSAPI (Xbox Services API) ライブラリは現在、MPSD サービスとの通信時にコントラクト バージョン 104 を使用します。</span><span class="sxs-lookup"><span data-stu-id="beb28-110">The client-side XSAPI (Xbox Services API) libraries currently use contract version 104 when communicating to the MPSD services.</span></span> <span data-ttu-id="beb28-111">ドキュメントのこのバージョンでは、セッション テンプレート スキーマをコントラクト バージョン 107 に更新します。これは、MPSD サービスでサポートされている最新のコントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="beb28-111">This version of the document updates the session template schema to contract version 107, which is the latest contract version supported by the MPSD services.</span></span> <span data-ttu-id="beb28-112">バージョン 104 から 107 までの間の変更について、「[コントラクト スキーマの変更](#_Contract_schema_update)」セクションにまとめています。</span><span class="sxs-lookup"><span data-stu-id="beb28-112">The changes between version 104 and 107 are summarized in the section entitled [Contract schema update](#_Contract_schema_update).</span></span>

<span data-ttu-id="beb28-113">コントラクト バージョン 104 に合わせて記述されたテンプレートは、107 として再発行する場合は更新が必要なことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="beb28-113">Note that templates that were written for contract version 104 will need to be updated if they are republished as 107.</span></span> <span data-ttu-id="beb28-114">ただし、サービスは後方互換性があるので、現在のライブラリ (将来の XDK リリースで更新予定) を使用し続けることができます。</span><span class="sxs-lookup"><span data-stu-id="beb28-114">However, the services are backward-compatible so you can continue to use the current libraries, which will be updated in a future XDK release.</span></span>

<span data-ttu-id="beb28-115">このドキュメントの前回の改訂では、サーバー セッションに関する情報を更新し、Xbox Live Service API と RESTful サービス呼び出しに関する新しいセクションを追加しました。</span><span class="sxs-lookup"><span data-stu-id="beb28-115">The previous revision of this document updated information regarding server sessions and added a new section about Xbox Live Service APIs and RESTful service calls.</span></span> <span data-ttu-id="beb28-116">また、「セッション状態情報のクエリ」セクションの表が更新され、「サービス品質 (QoS) テンプレート」セクションが改訂されました。</span><span class="sxs-lookup"><span data-stu-id="beb28-116">In addition, the table found in the Query for Session State Information section was updated and the Quality of Service (QoS) Templates section was revised.</span></span>

## <a name="introduction"></a><span data-ttu-id="beb28-117">概要</span><span class="sxs-lookup"><span data-stu-id="beb28-117">Introduction</span></span>

<span data-ttu-id="beb28-118">Xbox One のマルチプレイヤー セッションは、クラウドのマルチプレイヤー セッション ディレクトリ (MPSD) に保存されるセキュリティで保護されたドキュメントであり、このドキュメントはゲームをプレイしているユーザーのグループを表します。</span><span class="sxs-lookup"><span data-stu-id="beb28-118">On Xbox One, a multiplayer session is a secure document that lives in the cloud on the Multiplayer Session Directory (MPSD), and this document represents a group of people playing a game.</span></span> <span data-ttu-id="beb28-119">マルチプレイヤー セッションの具体的な性質を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="beb28-119">Specifically, multiplayer sessions have the following qualities:</span></span>

-   <span data-ttu-id="beb28-120">各セッションが一意の URI を持つ。</span><span class="sxs-lookup"><span data-stu-id="beb28-120">Each session has a unique URI.</span></span>

-   <span data-ttu-id="beb28-121">セッション ドキュメントには、現在のメンバー、ゲーム設定、ブートストラップ データ、およびゲーム サーバー情報が含まれる。</span><span class="sxs-lookup"><span data-stu-id="beb28-121">The session document contains the current members, game settings, bootstrapping data, and game server information.</span></span>

-   <span data-ttu-id="beb28-122">タイトルがそれぞれのセッションを作成および管理する。</span><span class="sxs-lookup"><span data-stu-id="beb28-122">Titles create and manage their own sessions.</span></span>

-   <span data-ttu-id="beb28-123">セッションがそのメンバー間の接続を実現する。</span><span class="sxs-lookup"><span data-stu-id="beb28-123">A session enables connectivity between its members.</span></span>

<span data-ttu-id="beb28-124">マルチプレイヤー セッション ディレクトリは、すべてのクライアントにわたってゲーム セッションのメタデータを集中管理します。</span><span class="sxs-lookup"><span data-stu-id="beb28-124">The Multiplayer Session Directory centralizes game session metadata across all the clients.</span></span> <span data-ttu-id="beb28-125">セッションに関して必要な基本情報を提供することによって、クライアント間のセキュア デバイス アソシエーションのセットアップを支援します。</span><span class="sxs-lookup"><span data-stu-id="beb28-125">It provides the basic information needed about a session to help set up the secure device associations between clients.</span></span> <span data-ttu-id="beb28-126">また、基本的な初回起動のメタデータも提供します。このメタデータは、より具体的なゲーム データの受け渡しを開始する前に、クライアントがゲームに接続するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-126">It also provides basic first-boot metadata for a client to connect to the game before it starts passing around more specific game data.</span></span> <span data-ttu-id="beb28-127">プロセス ライフタイム管理 (PLM) と Xbox One アプリケーションのタスク切り替えの性質のため、MPSD は、アクティブなゲーム セッションの一部として識別されるピアおよびサーバーと通信するための正しい情報がクライアントにあることを確実にし、シェルおよびコンソール オペレーティング システムと調整を図ってゲーム セッションにおけるプレイヤーの有効期間を予約、アクティブ化、および管理します。</span><span class="sxs-lookup"><span data-stu-id="beb28-127">With Process Lifetime Management (PLM) and the task-switching nature of applications on Xbox One, the MPSD ensures that clients have the correct information for contacting peers and servers that are identified as part of the active game session, and coordinates with the shell and console operating system to reserve, activate, and manage player lifetime for a game session.</span></span>

## <a name="terminology-used-in-this-document"></a><span data-ttu-id="beb28-128">このドキュメントで使用されている用語</span><span class="sxs-lookup"><span data-stu-id="beb28-128">Terminology used in this document</span></span>

| <span data-ttu-id="beb28-129">用語</span><span class="sxs-lookup"><span data-stu-id="beb28-129">Term</span></span>                 | <span data-ttu-id="beb28-130">説明</span><span class="sxs-lookup"><span data-stu-id="beb28-130">Definition</span></span>                                                                                                                                                                                                                                                                                  |
|----------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="beb28-131">マルチプレイヤー セッション</span><span class="sxs-lookup"><span data-stu-id="beb28-131">Multiplayer session</span></span>  | <span data-ttu-id="beb28-132">Xbox Live クラウドに配置され、Xbox One でタイトルをプレイするときに結び付けられる (または結び付けられる予定の) ユーザーのグループを表すセキュリティで保護されたドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="beb28-132">A secure document that resides in the Xbox Live cloud and represents a group of users who are (or will be) connected together while playing a title on Xbox One.</span></span> <span data-ttu-id="beb28-133">マルチプレイヤーのすべての側面 (マッチメイキング、パーティー、途中参加など) で、マルチプレイヤー セッションが利用されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-133">All the aspects of multiplayer—such as matchmaking, parties, join-in-progress, and so on—leverage the multiplayer session.</span></span> |
| <span data-ttu-id="beb28-134">ゲーム セッション</span><span class="sxs-lookup"><span data-stu-id="beb28-134">Game session</span></span>         | <span data-ttu-id="beb28-135">これは、実際のゲーム セッションでユーザーが一緒にプレイ、MPSD で公開されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-135">This is the actual game session, exposed in the MPSD, in which users are playing together.</span></span> <span data-ttu-id="beb28-136">マルチプレイヤーのすべてのシナリオは、最終的にはゲーム セッションになります。</span><span class="sxs-lookup"><span data-stu-id="beb28-136">All multiplayer scenarios ultimately end up in a game session.</span></span>                                                                                                                               |
| <span data-ttu-id="beb28-137">マッチ チケット セッション</span><span class="sxs-lookup"><span data-stu-id="beb28-137">Match ticket session</span></span> | <span data-ttu-id="beb28-138">マッチメイキング中にマッチ チケットの送信を追跡するために使用されるセッションです。</span><span class="sxs-lookup"><span data-stu-id="beb28-138">This is a session used to track match ticket submission during matchmaking.</span></span>                                                                                                                                                                                                                 |
| <span data-ttu-id="beb28-139">非アクティブなプレイヤー</span><span class="sxs-lookup"><span data-stu-id="beb28-139">Inactive player</span></span>      | <span data-ttu-id="beb28-140">セッション内で Inactive 状態に設定されているプレイヤーです。</span><span class="sxs-lookup"><span data-stu-id="beb28-140">A player who has been set to the Inactive state within the session.</span></span> <span data-ttu-id="beb28-141">ゲームが制限モードである、一時停止されている、またはタイトルで定義されているそれ以外の非アクティブ状態であるときに、タイトルがユーザーを Inactive 状態に設定します。</span><span class="sxs-lookup"><span data-stu-id="beb28-141">The title sets a user to the Inactive state when the game is constrained, suspended, or otherwise inactive as defined by the title.</span></span>                                                                                     |

## <a name="the-multiplayer-session-directory"></a><span data-ttu-id="beb28-142">マルチプレイヤー セッション ディレクトリ</span><span class="sxs-lookup"><span data-stu-id="beb28-142">The Multiplayer Session Directory</span></span>

<span data-ttu-id="beb28-143">タイトルでは、MPSD を利用して、オンラインのプレイヤーの間でセッション情報を調整します。</span><span class="sxs-lookup"><span data-stu-id="beb28-143">The MPSD facilitates and helps titles coordinate session information between online players.</span></span> <span data-ttu-id="beb28-144">マルチプレイヤー プレイのさまざまなタスクを実行するために、さまざまな種類のセッションが作成される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="beb28-144">There can be different types of sessions created to accomplish different tasks of multiplayer play.</span></span> <span data-ttu-id="beb28-145">次の表で、Xbox 360 と Xbox One のタスク実行方式の違いについて説明しています。</span><span class="sxs-lookup"><span data-stu-id="beb28-145">The following table lays out the differences in how such tasks were done on Xbox 360 versus how they are accomplished on Xbox One.</span></span>

| <span data-ttu-id="beb28-146">機能またはタスク</span><span class="sxs-lookup"><span data-stu-id="beb28-146">Function or task</span></span>                     | <span data-ttu-id="beb28-147">Xbox 360</span><span class="sxs-lookup"><span data-stu-id="beb28-147">Xbox 360</span></span>                                                                                                        | <span data-ttu-id="beb28-148">Xbox One</span><span class="sxs-lookup"><span data-stu-id="beb28-148">Xbox One</span></span>                                                                                                   |
|--------------------------------------|-----------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------|
| **<span data-ttu-id="beb28-149">ゲーム セッション情報の取得</span><span class="sxs-lookup"><span data-stu-id="beb28-149">Get game session information</span></span>**     | <span data-ttu-id="beb28-150">**XSessionGetDetails**、**XSessionSearchByID**、または独自に追跡。</span><span class="sxs-lookup"><span data-stu-id="beb28-150">**XSessionGetDetails**, **XSessionSearchByID**, or track yourself.</span></span>                                              | <span data-ttu-id="beb28-151">サービスからセッション情報を要求する。</span><span class="sxs-lookup"><span data-stu-id="beb28-151">Request the session information from the service.</span></span>                                                          |
| **<span data-ttu-id="beb28-152">ホストの移行</span><span class="sxs-lookup"><span data-stu-id="beb28-152">Migrate host</span></span>**                     | <span data-ttu-id="beb28-153">必要なときにタイトルが **XSessionMigrateHost** を呼び出す。</span><span class="sxs-lookup"><span data-stu-id="beb28-153">When needed, the title calls **XSessionMigrateHost.**</span></span>                                                           | <span data-ttu-id="beb28-154">新しいセッションの作成は不要、SessionID に新しいホストを割り当てるだけ。</span><span class="sxs-lookup"><span data-stu-id="beb28-154">Don’t need to create a new session, just assign a new host for SessionID.</span></span>                                  |
| **<span data-ttu-id="beb28-155">複数のプレイヤー セッションの管理</span><span class="sxs-lookup"><span data-stu-id="beb28-155">Manage multiple player sessions</span></span>**  | <span data-ttu-id="beb28-156">複数のセッションを一度に扱うことが難しい。</span><span class="sxs-lookup"><span data-stu-id="beb28-156">Tricky to handle more than one session at a time.</span></span> <span data-ttu-id="beb28-157">たとえば、**XNetReplaceKey** と **XNetUnregisterKey** のどちらが適切か。</span><span class="sxs-lookup"><span data-stu-id="beb28-157">For example, **XNetReplaceKey** versus **XNetUnregisterKey**.</span></span> | <span data-ttu-id="beb28-158">サービス ベースのセッションにより、1 つのセッションの管理がより整理され、複数のセッションの扱いが容易になる。</span><span class="sxs-lookup"><span data-stu-id="beb28-158">Service-based session makes managing one session cleaner and makes it easy to handle multiple sessions.</span></span>    |
| **<span data-ttu-id="beb28-159">サインアウトと切断の処理</span><span class="sxs-lookup"><span data-stu-id="beb28-159">Handle sign-outs and disconnects</span></span>** | <span data-ttu-id="beb28-160">それぞれ **XCloseHandle** または **XSessionDelete** によって切断とサインアウトを別々に処理する必要がある。</span><span class="sxs-lookup"><span data-stu-id="beb28-160">Have to handle disconnects and sign-out differently, with **XCloseHandle** or **XSessionDelete**, respectively.</span></span> | <span data-ttu-id="beb28-161">集中管理されたサービスがサインアウトと切断の処理を簡素化し、タイムアウトはゲーム構成内で設定される。</span><span class="sxs-lookup"><span data-stu-id="beb28-161">Centralized service simplifies sign-outs and disconnect handling, and timeouts are set in the game config.</span></span> |

### <a name="session-patterns"></a><span data-ttu-id="beb28-162">セッションのパターン</span><span class="sxs-lookup"><span data-stu-id="beb28-162">Session patterns</span></span>

-   <span data-ttu-id="beb28-163">ゲーム セッション</span><span class="sxs-lookup"><span data-stu-id="beb28-163">Game sessions</span></span>

    -   <span data-ttu-id="beb28-164">プレイヤーの XUID、セキュリティで保護されたデバイス アドレス データ、およびプロパティ状態を保持するセッション。</span><span class="sxs-lookup"><span data-stu-id="beb28-164">Session with players’ XUIDs, secure device address data, and property states.</span></span> <span data-ttu-id="beb28-165">これが、実際のゲームプレイ セッションと見なされます。</span><span class="sxs-lookup"><span data-stu-id="beb28-165">This is thought of as the actual gameplay session.</span></span>

    -   <span data-ttu-id="beb28-166">ピアツーピア、ピアツーホスト、ピアツーサーバー、またはハイブリッドの構成が可能です。</span><span class="sxs-lookup"><span data-stu-id="beb28-166">Can be peer-to-peer, peer-to-host, peer-to-server, or hybrid.</span></span>

-   <span data-ttu-id="beb28-167">マッチ チケット セッション</span><span class="sxs-lookup"><span data-stu-id="beb28-167">Match ticket sessions</span></span>

    -   <span data-ttu-id="beb28-168">一緒にプレイする他のプレイヤーを見つけるためにマッチメイキングに送信されるセッション。</span><span class="sxs-lookup"><span data-stu-id="beb28-168">A session that is submitted to matchmaking to find other players to play with.</span></span> <span data-ttu-id="beb28-169">ゲームで追加のプレイヤーを探している場合は、ゲーム セッションがチケット セッションでもある場合があります。</span><span class="sxs-lookup"><span data-stu-id="beb28-169">Note that a game session can also be a ticket session, if the game is looking for more players.</span></span>

-   <span data-ttu-id="beb28-170">サーバー セッション</span><span class="sxs-lookup"><span data-stu-id="beb28-170">Server sessions</span></span>

    -   <span data-ttu-id="beb28-171">Xbox Live エンジンの処理を通じて作成および使用されるゲーム セッション。</span><span class="sxs-lookup"><span data-stu-id="beb28-171">Game sessions created and used through Xbox Live Compute processing.</span></span>

<span data-ttu-id="beb28-172">図 1 は MPSD セッションの使用法を示しています。青のボックスは MPSD セッションを表し、赤のボックスはそれらを使用しているサービスです。</span><span class="sxs-lookup"><span data-stu-id="beb28-172">Figure 1 illustrates usages of MPSD sessions, where the blue boxes represent MPSD sessions and the red boxes are the services that are using them.</span></span>

<span data-ttu-id="beb28-173">図 1: </span><span class="sxs-lookup"><span data-stu-id="beb28-173">Figure 1.</span></span> <span data-ttu-id="beb28-174">MPSD セッションの使用</span><span class="sxs-lookup"><span data-stu-id="beb28-174">MPSD session use.</span></span>

## <a name="mpsd-sessions"></a><span data-ttu-id="beb28-175">MPSD セッション</span><span class="sxs-lookup"><span data-stu-id="beb28-175">MPSD sessions</span></span>

<span data-ttu-id="beb28-176">セッションは関連するエンティティの 2 つのリストを維持しています。</span><span class="sxs-lookup"><span data-stu-id="beb28-176">Sessions maintain two lists of related entities:</span></span>

1.  <span data-ttu-id="beb28-177">セッションに参加したか、または招待されたメンバー (ユーザー)</span><span class="sxs-lookup"><span data-stu-id="beb28-177">Members (users) that have joined or been invited into a session.</span></span>

2.  <span data-ttu-id="beb28-178">セッションに参加したサーバー (クラウド サーバーまたは専用サーバー)</span><span class="sxs-lookup"><span data-stu-id="beb28-178">Servers (cloud servers or dedicated servers) that have joined the session.</span></span>

<span data-ttu-id="beb28-179">各エンティティには以下のデータが含まれます。</span><span class="sxs-lookup"><span data-stu-id="beb28-179">Each entity has:</span></span>

1.  <span data-ttu-id="beb28-180">作成時に設定される定数値</span><span class="sxs-lookup"><span data-stu-id="beb28-180">Constant values set at creation time.</span></span>

2.  <span data-ttu-id="beb28-181">可変プロパティ</span><span class="sxs-lookup"><span data-stu-id="beb28-181">Mutable properties.</span></span>

3.  <span data-ttu-id="beb28-182">読み取り専用のメタデータ</span><span class="sxs-lookup"><span data-stu-id="beb28-182">Read-only metadata.</span></span>

### <a name="xbox-live-service-apis-and-restful-service-calls"></a><span data-ttu-id="beb28-183">Xbox Live Service API と RESTful サービスの呼び出し</span><span class="sxs-lookup"><span data-stu-id="beb28-183">Xbox Live Service APIs and RESTful service calls</span></span>

<span data-ttu-id="beb28-184">Xbox One のセッションおよびマッチメイキング サービスとインターフェイスで接続するための方法は 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="beb28-184">There are two ways to interface with the Xbox One Sessions and Matchmaking services.</span></span> <span data-ttu-id="beb28-185">1 つ目の方法は、RESTful Xbox Live サービス URI の標準 HTTPS を呼び出すものです。</span><span class="sxs-lookup"><span data-stu-id="beb28-185">The first way is to use standard HTTPS calls to the RESTful Xbox Live Services URIs.</span></span> <span data-ttu-id="beb28-186">これにより、タイトルはサーバー構成およびゲーム構成に応じて、柔軟にこれらのサービスを呼び出し、連動することができます。</span><span class="sxs-lookup"><span data-stu-id="beb28-186">This allows titles flexibility in calling and interfacing with these services depending on their server and game configurations.</span></span> <span data-ttu-id="beb28-187">これらの URI の一覧については、「Xbox Live サービス RESTful リファレンス」以下の [Xbox One 開発キット (XDK) ドキュメント](https://developer.xboxlive.com/en-us/platform/development/documentation/software/Pages/home.aspx)を参照してください。[1]</span><span class="sxs-lookup"><span data-stu-id="beb28-187">A list of these URIs can be found in the [Xbox One Development Kit (XDK) documentation](https://developer.xboxlive.com/en-us/platform/development/documentation/software/Pages/home.aspx) under “Xbox Live Services RESTful Reference.”[1]</span></span>

<span data-ttu-id="beb28-188">2 つ目の方法は、RESTful サービス URI のラッパーとして機能する Xbox Live Service API を使用するものです。</span><span class="sxs-lookup"><span data-stu-id="beb28-188">The second method is to use the Xbox Live Service APIs, which act as wrappers for the RESTful service URIs.</span></span> <span data-ttu-id="beb28-189">これらによって、コードではより従来的なアプローチで API を使用することができ、呼び出しごとに HTTPS トラフィックを処理する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="beb28-189">These allow for a more traditional approach to using APIs in code without having to handle HTTPS traffic for each call.</span></span> <span data-ttu-id="beb28-190">Xbox Live Service API のソース コードは Xbox 開発キット (XDK) に付属しており、必要に応じて、修正を加えてタイトルに取り込むことができます。</span><span class="sxs-lookup"><span data-stu-id="beb28-190">The source code for the Xbox Live Service APIs is shipped with the Xbox Development Kit (XDK) and can be modified and incorporated into your title as needed.</span></span> <span data-ttu-id="beb28-191">サンプルは Xbox Live Service API を使用して記述されています。</span><span class="sxs-lookup"><span data-stu-id="beb28-191">The samples are written using the Xbox Live Service APIs.</span></span> <span data-ttu-id="beb28-192">Xbox Live Service API の詳細については、「Xbox Live サービス リファレンス」以下の Xbox One [XDK ドキュメント](https://developer.xboxlive.com/en-us/platform/development/documentation/software/Pages/home.aspx)を参照してください。[2]</span><span class="sxs-lookup"><span data-stu-id="beb28-192">More information about the Xbox Live Services APIs can be found in the Xbox One [XDK documentation](https://developer.xboxlive.com/en-us/platform/development/documentation/software/Pages/home.aspx) under “Xbox Live Services Reference.”[2]</span></span>

### <a name="mpsd-sessions-and-templates"></a><span data-ttu-id="beb28-193">MPSD セッションとテンプレート</span><span class="sxs-lookup"><span data-stu-id="beb28-193">MPSD sessions and templates</span></span>

<span data-ttu-id="beb28-194">MPSD セッションは、Xbox デベロッパー ポータル (XDP) から取り込まれるテンプレートを使用して作成されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-194">MPSD sessions are created with templates ingested through the Xbox Development Portal (XDP).</span></span> <span data-ttu-id="beb28-195">テンプレートは、作成中のセッションのフレームワークを定義する JSON ドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="beb28-195">The templates are JSON documents that define the framework for the session being created.</span></span> <span data-ttu-id="beb28-196">テンプレートでは、新しいセッションの定数が提供されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-196">The template provides constants for the new session.</span></span>

<span data-ttu-id="beb28-197">次に示すテンプレート構成の例は [Player Rendezvous コード サンプル](https://developer.xboxlive.com/en-us/platform/development/education/Pages/Samples.aspx)から引用したものです。</span><span class="sxs-lookup"><span data-stu-id="beb28-197">The following excerpt from the [Player Rendezvous code sample](https://developer.xboxlive.com/en-us/platform/development/education/Pages/Samples.aspx) is a template config example.</span></span>

```json
// Used for creating the session that you then pass into your match ticket request. This *should* not have any QoS requirements.
MatchTicketSession (Contract Version: 107)
{
    "constants": {
        "system": {
            "version": 1,
            "maxMembersCount": 10,
            "visibility": "private",
            "capabilities": {},
            "memberInitialization": {
                "joinTimeout": 20000,
                "externalEvaluation": false,
                "membersNeededToStart": 1
            }
        },
        "custom": {}
    }
}

// This is the new game session that is returned after you’ve been matched.
// Note: This is used for in-game QoS. For out-of-game QoS, you will need P2P/HTP requirements.
GameSession (Contract Version:107)
{
    "constants": {
        "system": {
            "maxMembersCount": 12,
            "capabilities": {"connectivity": true }
        },
        "memberInitialization": {
         "joinTimeout": 20000,
         "measurementTimeout": 15000,
         "externalEvaluation": false,
         "membersNeededToStart": 4
         },

   "custom": {}
  }
}
```

<span data-ttu-id="beb28-198">マッチ チケット セッションは、**memberInitialization** オブジェクトに QoS タイムアウト値が設定されたゲーム セッション テンプレートと共に使用してください。</span><span class="sxs-lookup"><span data-stu-id="beb28-198">The match ticket session should be used with a game session template set up with QoS timeout values in its **memberInitialization** object.</span></span>

<span data-ttu-id="beb28-199">図 2: </span><span class="sxs-lookup"><span data-stu-id="beb28-199">Figure 2.</span></span> <span data-ttu-id="beb28-200">サンプル ホッパー</span><span class="sxs-lookup"><span data-stu-id="beb28-200">Sample hopper.</span></span>

![](../../images/whitepapers/mpsd_image1.png)

<span data-ttu-id="beb28-201">次に引用するコードは、ピア ツー ピア ゲーム セッション テンプレート (タイトル管理 QoS) の例です。</span><span class="sxs-lookup"><span data-stu-id="beb28-201">The code excerpt that follows is an example of a peer-to-peer game session template (title-managed QoS).</span></span>

```
{
    "constants": {
        "system": {
            "version": 1,
            "maxMembersCount": 10,
            "visibility": "private",
            "capabilities": {
                "connectivity": true
            },
            "memberInitialization": {
                "joinTimeout": 20000,
                "externalEvaluation": false,
                "membersNeededToStart": 2
            }
        },
        "custom": {}
    }
}

```

<span data-ttu-id="beb28-202">次に示すのは、ピア ツー サーバー セッションと RAW テンプレートの例です。</span><span class="sxs-lookup"><span data-stu-id="beb28-202">This is an example of a peer-to-server session and RAW template.</span></span>

```
{
    "constants": {
        "system": {
            "version": 1,
            "maxMembersCount": 10,
            "visibility": "private",
            "capabilities": {}
        },
        "custom": {}
    }
}
```

<span data-ttu-id="beb28-203">次のコードは、スマート マッチに使用されるマッチ チケット セッション テンプレートの例を示します。</span><span class="sxs-lookup"><span data-stu-id="beb28-203">The following code shows an example of a match ticket session template, which is used for Smart Match.</span></span>

```
{
    "constants": {
        "system": {
            "version": 1,
            "maxMembersCount": 10,
            "visibility": "private",
            "capabilities": {},
            "memberInitialization": {
                "joinTimeout": 20000,
                "externalEvaluation": false,
                "membersNeededToStart": 1
            }
        },
        "custom": {}
    }
}

```

### <a name="checking-which-templates-are-configured-for-your-scid"></a><span data-ttu-id="beb28-204">どのテンプレートが SCID に設定されているかを確認</span><span class="sxs-lookup"><span data-stu-id="beb28-204">Checking which templates are configured for your SCID</span></span>

#### <a name="session-templates"></a><span data-ttu-id="beb28-205">セッション テンプレート</span><span class="sxs-lookup"><span data-stu-id="beb28-205">Session templates</span></span>

<span data-ttu-id="beb28-206">SCID 内に存在するセッション テンプレートのリストと、特定のセッション テンプレートの詳細を MPSD から取得できます。</span><span class="sxs-lookup"><span data-stu-id="beb28-206">The list of session templates that exist within a SCID, as well as the details of a specific session template, can be retrieved from MPSD:</span></span>

```
GET /serviceconfigs/{scid}/sessiontemplates

GET /serviceconfigs/{scid}/sessiontemplates/{session-template-name}
```

#### <a name="query-for-session-state-information"></a><span data-ttu-id="beb28-207">セッション状態情報のクエリ</span><span class="sxs-lookup"><span data-stu-id="beb28-207">Query for session state information</span></span>

<span data-ttu-id="beb28-208">セッションのクエリは、サービス構成レベルおよびセッション テンプレート レベルで行えます。</span><span class="sxs-lookup"><span data-stu-id="beb28-208">Sessions can be queried at the service config and session template levels:</span></span>

```
GET /serviceconfigs/{scid}/sessions

GET /serviceconfigs/{scid}/sessiontemplates/{session-template-name}/sessions
```

<span data-ttu-id="beb28-209">既定では、最大 100 件の非プライベート セッションが返されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-209">By default, this will return up to 100 non-private sessions.</span></span> <span data-ttu-id="beb28-210">以下のクエリ文字列パラメーターを使用してクエリを修正できます。</span><span class="sxs-lookup"><span data-stu-id="beb28-210">The query can be modified using these query-string parameters:</span></span>

| <span data-ttu-id="beb28-211">クエリ文字列</span><span class="sxs-lookup"><span data-stu-id="beb28-211">Query string</span></span>             | <span data-ttu-id="beb28-212">効果</span><span class="sxs-lookup"><span data-stu-id="beb28-212">Effect</span></span>                                                                                                         | <span data-ttu-id="beb28-213">説明</span><span class="sxs-lookup"><span data-stu-id="beb28-213">Description</span></span>                                                                                         |
|--------------------------|----------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------|
| <span data-ttu-id="beb28-214">keyword=foo</span><span class="sxs-lookup"><span data-stu-id="beb28-214">keyword=foo</span></span>              | <span data-ttu-id="beb28-215">"foo" というキーワードがあるセッションのみを含めます。</span><span class="sxs-lookup"><span data-stu-id="beb28-215">Only include sessions that have the keyword ”foo.”</span></span>                                                             |                                                                                                     |
| <span data-ttu-id="beb28-216">XUID=123</span><span class="sxs-lookup"><span data-stu-id="beb28-216">XUID=123</span></span>                 | <span data-ttu-id="beb28-217">ユーザー "123" が参加しているセッションのみを含めます。</span><span class="sxs-lookup"><span data-stu-id="beb28-217">Only include sessions that the user “123” is in.</span></span>                                                               | <span data-ttu-id="beb28-218">既定では、含まれるユーザーはセッション内でアクティブである必要があります。</span><span class="sxs-lookup"><span data-stu-id="beb28-218">By default, the user must be active in the session to be included.</span></span>                                  |
| <span data-ttu-id="beb28-219">*reservations*=**true**</span><span class="sxs-lookup"><span data-stu-id="beb28-219">*reservations*=**true**</span></span> | <span data-ttu-id="beb28-220">ユーザーが予約済みプレイヤーとして設定されているが、まだ参加しておらずアクティブ プレイヤーになっていないセッションを含めます。</span><span class="sxs-lookup"><span data-stu-id="beb28-220">Include sessions for which the user is set as a reserved player but has not joined to become an active player.</span></span> | <span data-ttu-id="beb28-221">自分自身のセッションをクエリするとき、または特定ユーザーのセッションをサーバー間でクエリするときに限定されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-221">Only when querying your own sessions, or when querying a specific user’s sessions server-to-server.</span></span> |
| <span data-ttu-id="beb28-222">*inactive*=**true**</span><span class="sxs-lookup"><span data-stu-id="beb28-222">*inactive*=**true**</span></span>      | <span data-ttu-id="beb28-223">ユーザーが受け入れたがアクティブにプレイしていないセッションを含めます。</span><span class="sxs-lookup"><span data-stu-id="beb28-223">Include sessions that the user has accepted but isn’t actively playing in.</span></span>                                     | <span data-ttu-id="beb28-224">ユーザーが "準備完了" しているが "アクティブ" ではないセッションは非アクティブとしてカウントされます。</span><span class="sxs-lookup"><span data-stu-id="beb28-224">Sessions in which the user is “ready” but not “active” count as inactive.</span></span>                           |
| <span data-ttu-id="beb28-225">*private*=**true**</span><span class="sxs-lookup"><span data-stu-id="beb28-225">*private*=**true**</span></span>       | <span data-ttu-id="beb28-226">プライベート セッションを含めます。</span><span class="sxs-lookup"><span data-stu-id="beb28-226">Include private sessions.</span></span>                                                                                      | <span data-ttu-id="beb28-227">自分自身のセッションをクエリするとき、またはサーバー間でクエリするときに限定されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-227">Only when querying your own sessions, or when querying server-to-server.</span></span>                            |
| <span data-ttu-id="beb28-228">*visibility*=open</span><span class="sxs-lookup"><span data-stu-id="beb28-228">*visibility*=open</span></span>        | <span data-ttu-id="beb28-229">"open" であるセッションのみを含めます。</span><span class="sxs-lookup"><span data-stu-id="beb28-229">Only include sessions that are ”open.”</span></span>                                                                         | <span data-ttu-id="beb28-230">"private" に設定する場合、"private=true" ディレクティブも設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="beb28-230">If set to ”private,” the ”private=true” directive must also be set.</span></span>                                 |
| <span data-ttu-id="beb28-231">*take*=5</span><span class="sxs-lookup"><span data-stu-id="beb28-231">*take*=5</span></span>                 | <span data-ttu-id="beb28-232">最大 5 つのセッションを返します。</span><span class="sxs-lookup"><span data-stu-id="beb28-232">Return up to five sessions.</span></span>                                                                                    | <span data-ttu-id="beb28-233">0 ～ 100 の範囲で指定します。</span><span class="sxs-lookup"><span data-stu-id="beb28-233">Must be between 0 and 100.</span></span>                                                                          |

<span data-ttu-id="beb28-234">結果はセッション参照の JSON 配列です。</span><span class="sxs-lookup"><span data-stu-id="beb28-234">The result is a JSON array of session references.</span></span> <span data-ttu-id="beb28-235">一部のセッション データがインラインで含まれます。</span><span class="sxs-lookup"><span data-stu-id="beb28-235">Some session data is included inline.</span></span>

<span data-ttu-id="beb28-236">**注意** すべてのクエリにキーワード フィルターと XUID フィルターのどちらかまたは両方を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="beb28-236">**Note** Every query must include either a keyword filter, a XUID filter, or both.</span></span>

<span data-ttu-id="beb28-237">*private* (プライベート セッションを返す) または *reservations* (ユーザーが参加していないセッションを返す) を **true** に設定するには、呼び出し元がサーバー レベルでセッションにアクセスできるか、または呼び出し元の XUID クレームが URI の XUID フィルターに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="beb28-237">Setting either *private* (which returns private sessions) or *reservations* (which returns sessions the user hasn't joined) to **true** requires the caller to have server-level access to the session, or for the caller's XUID claim to match the XUID filter in the URI.</span></span> <span data-ttu-id="beb28-238">それ以外の場合は、(そのようなセッションが実際に存在するかどうかに関係なく) 403 Forbidden が返されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-238">Otherwise, 403 Forbidden is returned (whether or not any such sessions actually exist).</span></span>

<span data-ttu-id="beb28-239">次に引用するコードはクエリ応答の例を示します。</span><span class="sxs-lookup"><span data-stu-id="beb28-239">The following code excerpt shows an example of a query response.</span></span>

```
{
"results": [ {
"xuid": "9876",  // If the session was found from a xuid, that xuid.
"startTime": "2009-06-15T13:45:30.0900000Z",
"sessionRef": {
  "scid": "foo",
  "templateName": "bar",
  "name": "session-seven"
},
"accepted": 4,        // Approximate number of non-reserved members.
"status": "active",   // or "reserved" or "inactive". This is the state of the user in the session, not the session itself. Only present if the session was found using a xuid.
"visibility": "open", // or "private", "visible", or "full"
"myTurn": true,       // Not present is the same as 'false'. Only present if the session was found using a xuid.
"keywords": [ "one", "two" ]
} ]
}

```

## <a name="session-template-attributes"></a><span data-ttu-id="beb28-240">セッション テンプレートの属性</span><span class="sxs-lookup"><span data-stu-id="beb28-240">Session template attributes</span></span>

<div id="_Contract_schema_update"/>

## <a name="contract-schema-update"></a><span data-ttu-id="beb28-241">コントラクト スキーマの更新</span><span class="sxs-lookup"><span data-stu-id="beb28-241">Contract schema update</span></span>

<span data-ttu-id="beb28-242">このドキュメントで最初に述べたように、最新のセッション テンプレート コントラクト バージョンは 107 であり、前のバージョン 104 と比べてスキーマにいくつかの変更点があります。</span><span class="sxs-lookup"><span data-stu-id="beb28-242">As was mentioned in the beginning of this document, the latest session template contract version is 107, which introduces some changes to the schema from the prior version of 104.</span></span> <span data-ttu-id="beb28-243">コントラクト バージョン 104 に合わせて記述されたテンプレートを、107 として再発行する場合は更新が必要です。</span><span class="sxs-lookup"><span data-stu-id="beb28-243">Templates that were written for contract version 104 will need to be updated if they are republished as 107.</span></span> <span data-ttu-id="beb28-244">変更内容の概要は以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="beb28-244">The following is a summary of the changes.</span></span>

-   <span data-ttu-id="beb28-245">**/constants/system/managedInitialization** の名前が **/constants/system/memberInitialization** に変更されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-245">**/constants/system/managedInitialization** is renamed to **/constants/system/memberInitialization**.</span></span>

    -   <span data-ttu-id="beb28-246">**autoEvaluate** フィールドの名前が **externalEvaluation** に変更され、**false** が既定のままであることを除いて、その極性が変わります。</span><span class="sxs-lookup"><span data-stu-id="beb28-246">The **autoEvaluate** field is renamed to **externalEvaluation** and its polarity changes, except that **false** remains the default.</span></span>

    -   <span data-ttu-id="beb28-247">**membersNeededToStart** の既定値を 2 から 1 に変更します。</span><span class="sxs-lookup"><span data-stu-id="beb28-247">The default value of **membersNeededToStart** changes from 2 to 1.</span></span>

    -   <span data-ttu-id="beb28-248">**joinTimeout** の既定値を 5 秒から 10 秒に変更します。</span><span class="sxs-lookup"><span data-stu-id="beb28-248">The default value of **joinTimeout** changes from 5 seconds to 10 seconds.</span></span>

    -   <span data-ttu-id="beb28-249">**measurementTimeout** の既定値を 5 秒から 30 秒に変更します。</span><span class="sxs-lookup"><span data-stu-id="beb28-249">The **measurementTimeout** default changes from 5 seconds to 30 seconds.</span></span>

-   <span data-ttu-id="beb28-250">**/constants/system/timeouts** は削除され、タイムアウトの名前は変更され、**/constants/system** に再配置されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-250">**/constants/system/timeouts** is removed, and the timeouts are renamed and relocated under **/constants/system**.</span></span>

    -   <span data-ttu-id="beb28-251">**reserved** タイムアウトは **reservedRemovalTimeout** になります。</span><span class="sxs-lookup"><span data-stu-id="beb28-251">The **reserved** timeout becomes **reservedRemovalTimeout**.</span></span>

    -   <span data-ttu-id="beb28-252">**inactive** タイムアウトは **inactiveRemovalTimeout** になり、その新しい既定値は 2 時間ではなく 0 になります。</span><span class="sxs-lookup"><span data-stu-id="beb28-252">The **inactive** timeout becomes **inactiveRemovalTimeout** and its new default is 0 instead of 2 hours.</span></span>

    -   <span data-ttu-id="beb28-253">**ready** タイムアウトは **readyRemovalTimeout** になります。</span><span class="sxs-lookup"><span data-stu-id="beb28-253">The **ready** timeout becomes **readyRemovalTimeout**.</span></span>

    -   <span data-ttu-id="beb28-254">**sessionEmpty** タイムアウトは **sessionEmptyTimeout** になります。</span><span class="sxs-lookup"><span data-stu-id="beb28-254">The **sessionEmpty** timeout becomes **sessionEmptyTimeout**.</span></span>

-   <span data-ttu-id="beb28-255">**/constants/system/capabilities/gameplay** を **true** と指定する必要があります。対象となるのは、(マッチ セッションやロビー セッションのようなヘルパー セッションと異なり) 実際のゲームプレイを表すセッションであり、この指定は最近のプレイヤーおよび評判レポートを有効にするために必要です。</span><span class="sxs-lookup"><span data-stu-id="beb28-255">**/constants/system/capabilities/gameplay** must be specified as **true** on sessions that represent actual gameplay (as opposed to helper sessions such as match and lobby sessions) in order to enable recent players and reputation reporting.</span></span>

### <a name="system-objects"></a><span data-ttu-id="beb28-256">システム オブジェクト</span><span class="sxs-lookup"><span data-stu-id="beb28-256">System objects</span></span>

<span data-ttu-id="beb28-257">セッション ドキュメント内の各システム オブジェクトには固定スキーマがあり、MPSD によって適用および解釈されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-257">Each of the system objects in the session document has a fixed schema that is enforced and interpreted by MPSD.</span></span>

<span data-ttu-id="beb28-258">PUT 要求の本体内で、システム オブジェクトは検証されてカスタム オブジェクトと同様に結合されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-258">Within the body of PUT requests, the system objects are validated and merged just like the custom objects.</span></span> <span data-ttu-id="beb28-259">ただし、カスタム オブジェクトと異なり、システム オブジェクトは結合された後も、これらのスキーマに基づいてさらに検証および処理されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-259">But unlike custom objects, after they are merged the system objects are further validated and acted upon based on these schemas.</span></span>

**<span data-ttu-id="beb28-260">/constants/system</span><span class="sxs-lookup"><span data-stu-id="beb28-260">/constants/system</span></span>**

```json
{
"version": 1,  //Document Version (FAL release version 1, service contract 107)
"maxMembersCount": 100,  // Defaults to 100 if not set on creation. Must be between 1 and 100.
"visibility": "private",  // Or "visible" or "open", defaults to "open" if not set on creation.

"initiators": [ "1234" ],  // If specified on a new session, the creators xuid must be in the list (or the creator must be a server).
"inviteProtocol": "party",  // Optional URI scheme of the launch URI for invite toasts.

"reservedRemovalTimeout": 10000, // Default is 30 seconds. Member is removed from the session.
"inactiveRemovalTimeout": 0, // Default is zero. Member is removed from the session.
"readyRemovalTimeout": 60000, // Default is three minutes. Member is removed from the session.
"sessionEmptyTimeout": 0, // Default is zero. Session is deleted.

// Capabilities are boolean values that are optionally set in the session template. If no capabilities are needed, an empty "capabilities" object should be in the template in order to prevent capabilities from being specified on session creation, unless the title desires dynamic session capabilities.
"capabilities": {
"clientMatchmaking": true,
"connectivity": true, // Cannot be set if ‘large’ is specified.
     "suppressPresenceActivityCheck": false,
     "gameplay": false,
     "large": false
},
/* If a "memberInitialization" object is set, the session expects the client system or title to perform initialization following session creation and/or as new members join the session. The timeouts and initialization stages are automatically tracked by the session, including QoS measurements if any metrics are set. These timeouts override the session's reservation and ready timeouts for members that have 'initializationEpisode' set. */
"memberInitialization": {
"joinTimeout": 20000,  // Milliseconds. Unspecified counts as 10 seconds.
"externalEvaluation": false,
"membersNeededToStart": 2  // Unspecified counts as 1. Must be between 0 and maxMembersCount. Only applies to episode 1. If 00 and the session is created with no members to initialize, episode 1 is skipped..
},
```

**<span data-ttu-id="beb28-261">/properties/system</span><span class="sxs-lookup"><span data-stu-id="beb28-261">/properties/system</span></span>**

```
{
// Optional array of case-insensitive strings. Cannot be set if the session's visibility is "private".
"keywords": [ "hello" ],

// Array of integer indices of members whose turn it is. Defaults to empty. Can't be set (and doesn't appear) on large sessions.
"turn": [ 0 ],

/* Restricts who can join "open" sessions. (Has no effect on reservations, which means it has no impact on "private" and "visible" sessions.) Defaults to "none". On large sessions, "none" is the only valid value.
If "local", only users whose token's DeviceId matches someone else already in the session and "active": true.
If "followed", only local users (as defined above) and users who are followed by an existing (not reserved) member of the session can join without a reservation. */
"joinRestriction": "none",

// Device token of the host. Must match the "deviceToken" of at least one member, otherwise this field is deleted.
// If "peerToHostRequirements" is set and "host" is set, the measurement stage assumes the given host is the correct host and only measures metrics to that host.
// Can't be set on large sessions.
"host": "99e4c701",

// Can only be set while "initializing/stage" is "evaluating". True indicates success, and false indicates failure. Once set, "initializing/stage" is immediately updated, and this field is removed.
"initializationSucceeded": true,

/* The ordered list of case-insensitive connection strings that the session could use to connect to a game server. Generally titles should use the first on the list, but sophisticated titles could use a custom mechanism (e.g. Thunderhead) for choosing one of the others (e.g. based on load). */
"serverConnectionStringCandidates": [ "datacenter b", "serverfarm a" ],

"matchmaking": {
    "targetSessionConstants": { },
    // Force a specific connection string to be used (useful in preserveSession=always cases).
    "serverConnectionString": "datacenter b",
},

// True if the match that was found didn't work out and needs to be resubmitted. Set to false to signal that the match did work, and the matchmaking service can release the session.
"matchmakingResubmit": true
}

```

### <a name="timeouts"></a><span data-ttu-id="beb28-262">タイムアウト</span><span class="sxs-lookup"><span data-stu-id="beb28-262">Timeouts</span></span>

<span data-ttu-id="beb28-263">タイマーおよびその他の外部イベントによってセッションを変更できます。</span><span class="sxs-lookup"><span data-stu-id="beb28-263">Sessions can be changed by timers and other external events.</span></span> <span data-ttu-id="beb28-264">MPSD の **Timeouts** オブジェクトは、セッションの有効期間とメンバーを管理するための基本的なメカニズムを提供します。</span><span class="sxs-lookup"><span data-stu-id="beb28-264">The **Timeouts** object in MPSD provides a basic mechanism to manage session lifetime and members.</span></span>

<span data-ttu-id="beb28-265">セッションの **nextTimer** フィールドは次のタイマーの日時を表します。</span><span class="sxs-lookup"><span data-stu-id="beb28-265">The **nextTimer** field of the session gives the time of the next timer.</span></span> <span data-ttu-id="beb28-266">クライアントは、この情報を使用して、次のポーリングの適切な間隔を選択できます。</span><span class="sxs-lookup"><span data-stu-id="beb28-266">Clients can use this information to pick a good interval for the next poll.</span></span> <span data-ttu-id="beb28-267">この値は **Expires** HTTP ヘッダーでも返されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-267">This value is also returned in the **Expires** HTTP header.</span></span>

<span data-ttu-id="beb28-268">タイムアウトはミリ秒単位で指定します。</span><span class="sxs-lookup"><span data-stu-id="beb28-268">Timeouts are specified in milliseconds.</span></span> <span data-ttu-id="beb28-269">タイムアウトが即時であることを示す 0 を指定できます。</span><span class="sxs-lookup"><span data-stu-id="beb28-269">Zero is allowed and signifies that the timeout should be immediate.</span></span> <span data-ttu-id="beb28-270">特定のタイムアウトが指定されない場合は、無期限と見なされます。</span><span class="sxs-lookup"><span data-stu-id="beb28-270">If a given timeout isn’t specified, it’s considered infinite.</span></span> <span data-ttu-id="beb28-271">タイムアウトには既定値があるため、タイムアウトを無期限にするにはセッション テンプレートで "null" を明示的に指定してください。</span><span class="sxs-lookup"><span data-stu-id="beb28-271">Because the timeouts have defaults, the session template should explicitly specify “null” for an infinite timeout.</span></span>

#### <a name="sessionemptytimeout"></a><span data-ttu-id="beb28-272">SessionEmptyTimeout</span><span class="sxs-lookup"><span data-stu-id="beb28-272">SessionEmptyTimeout</span></span>

<span data-ttu-id="beb28-273">**/constants/system/sessionEmptyTimeout** の値は、セッションが空になってから削除されるまでのミリ秒数を構成します。</span><span class="sxs-lookup"><span data-stu-id="beb28-273">The **/constants/system/sessionEmptyTimeout** value configures the number of milliseconds after a session becomes empty that it will be deleted.</span></span> <span data-ttu-id="beb28-274">既定値は 0 であり、セッションは直ちに削除されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-274">The default is zero, meaning that the session will be deleted immediately.</span></span> <span data-ttu-id="beb28-275">値を指定しないと、空のセッションは無期限に存在します。</span><span class="sxs-lookup"><span data-stu-id="beb28-275">If the value is unspecified, empty sessions will live on indefinitely.</span></span>

#### <a name="member-timeouts"></a><span data-ttu-id="beb28-276">メンバー タイムアウト</span><span class="sxs-lookup"><span data-stu-id="beb28-276">Member timeouts</span></span>

<span data-ttu-id="beb28-277">**/constants/system** に含まれる他の 3 つのタイムアウトは、メンバーが特定の状態にとどまることができる時間を制御します。</span><span class="sxs-lookup"><span data-stu-id="beb28-277">The three other timeouts within **/constants/system** control the amount of time a member can remain in a particular state:</span></span>

-   **<span data-ttu-id="beb28-278">reservedRemovalTimeout</span><span class="sxs-lookup"><span data-stu-id="beb28-278">reservedRemovalTimeout</span></span>**

    -   <span data-ttu-id="beb28-279">タイムアウト期限が過ぎると予約は削除されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-279">The reservation is deleted when the timeout expires.</span></span> <span data-ttu-id="beb28-280">既定は 30 秒です。</span><span class="sxs-lookup"><span data-stu-id="beb28-280">The default is 30 seconds.</span></span>

-   **<span data-ttu-id="beb28-281">inactiveRemovalTimeout</span><span class="sxs-lookup"><span data-stu-id="beb28-281">inactiveRemovalTimeout</span></span>**

    -   <span data-ttu-id="beb28-282">非アクティブ メンバーは、既定では 2 時間後にセッションから削除されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-282">An inactive member is removed from the session after two hours by default.</span></span>

-   **<span data-ttu-id="beb28-283">readyRemovalTimeout</span><span class="sxs-lookup"><span data-stu-id="beb28-283">readyRemovalTimeout</span></span>**

    -   <span data-ttu-id="beb28-284">"ready" のメンバーは、既定では 3 分後に非アクティブ状態に戻ります。</span><span class="sxs-lookup"><span data-stu-id="beb28-284">Members who are “ready” revert to the inactive state after three minutes by default.</span></span>

<div id="_Member_initialization_in"/>

## <a name="member-initialization-in-session-documents"></a><span data-ttu-id="beb28-285">セッション ドキュメントでのメンバー初期化</span><span class="sxs-lookup"><span data-stu-id="beb28-285">Member initialization in session documents</span></span>

### <a name="member-initialization"></a><span data-ttu-id="beb28-286">メンバー初期化</span><span class="sxs-lookup"><span data-stu-id="beb28-286">Member initialization</span></span>


<span data-ttu-id="beb28-287">**memberInitialization** オブジェクトは、セッションの作成後と新しいメンバーのセッション参加時のいずれかまたは両方の初期化ステージを制御します。</span><span class="sxs-lookup"><span data-stu-id="beb28-287">The **memberInitialization** object controls the initialization stages following session creation and/or as new members join the session.</span></span> <span data-ttu-id="beb28-288">タイムアウトおよび初期化ステージは、セッションによって自動的に追跡されます。これには、メトリックが設定されている場合の QoS 測定が含まれます。</span><span class="sxs-lookup"><span data-stu-id="beb28-288">The timeouts and initialization stages are automatically tracked by the session, including QoS measurements if any metrics are set.</span></span>

<span data-ttu-id="beb28-289">これらのタイムアウト値は、**initializationEpisode** プロパティが設定されたメンバーに関して、セッションの予約タイムアウトおよび準備完了タイムアウトを上書きします。</span><span class="sxs-lookup"><span data-stu-id="beb28-289">These timeouts override the session’s reservation and ready timeouts for members that have the **initializationEpisode** property set.</span></span>

<span data-ttu-id="beb28-290">以下に例を示します。</span><span class="sxs-lookup"><span data-stu-id="beb28-290">Example:</span></span>

```
"memberInitialization": {
        "joinTimeout": 5000,
        "measurementTimeout": 5000,
        "evaluationTimeout": 5000,  // only specify for external evaluation
        "externalEvaluation": true,
       "membersNeededToStart": 2
    },
```


![](../../images/whitepapers/mpsd_image2.png)

**<span data-ttu-id="beb28-291">図 3: </span><span class="sxs-lookup"><span data-stu-id="beb28-291">Figure 3.</span></span> <span data-ttu-id="beb28-292">メンバー初期化フロー</span><span class="sxs-lookup"><span data-stu-id="beb28-292">Member initialization flow.</span></span>**

<span data-ttu-id="beb28-293">メンバー初期化の 3 つの各ステージで、以下のようにタイムアウトする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="beb28-293">Each of the three stages of member initialization can time out:</span></span>

1.  **<span data-ttu-id="beb28-294">joiningTimeout</span><span class="sxs-lookup"><span data-stu-id="beb28-294">joiningTimeout</span></span>**

    -   <span data-ttu-id="beb28-295">ユーザーがセッションに参加しなければならない時間 (ミリ秒)。</span><span class="sxs-lookup"><span data-stu-id="beb28-295">The amount of time, in milliseconds, that users have to join the session.</span></span> <span data-ttu-id="beb28-296">参加に失敗したメンバーの予約は削除されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-296">Reservations of members that fail to join are removed.</span></span>

2.  **<span data-ttu-id="beb28-297">measuringTimeout</span><span class="sxs-lookup"><span data-stu-id="beb28-297">measuringTimeout</span></span>**

    -   <span data-ttu-id="beb28-298">メンバーが測定値をアップロードしなければならない時間。</span><span class="sxs-lookup"><span data-stu-id="beb28-298">The amount of time that members have to upload their measurements.</span></span> <span data-ttu-id="beb28-299">測定値をアップロードできなかったメンバーは *failureReason* が "timeout" に設定されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-299">Members that fail to upload measurements are marked with a *failureReason* of "timeout".</span></span>

3.  **<span data-ttu-id="beb28-300">evaluationTimeout</span><span class="sxs-lookup"><span data-stu-id="beb28-300">evaluationTimeout</span></span>**

    -   <span data-ttu-id="beb28-301">メンバーが評価を決定してアップロードしなければならない時間。</span><span class="sxs-lookup"><span data-stu-id="beb28-301">The amount of time for a member to make and upload the evaluation decision.</span></span> <span data-ttu-id="beb28-302">決定が受信されない場合、失敗としてカウントされます。</span><span class="sxs-lookup"><span data-stu-id="beb28-302">If no decision is received, it counts as a failure.</span></span>

**<span data-ttu-id="beb28-303">externalEvaluation</span><span class="sxs-lookup"><span data-stu-id="beb28-303">externalEvaluation</span></span>**

-   <span data-ttu-id="beb28-304">MPSD は、セッション テンプレートで定義された要件に基づいて自動 QoS 評価を実行できます。</span><span class="sxs-lookup"><span data-stu-id="beb28-304">MPSD can do an automatic QoS evaluation based on requirements provided in the session template.</span></span> <span data-ttu-id="beb28-305">評価は externalEvaluation が false に設定されている場合に実行されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-305">The evaluation is performed when externalEvaluation is set to false.</span></span> <span data-ttu-id="beb28-306">**evaluationTimeout** が設定されている場合は、**externalEvaluation** は **true** である必要があります。</span><span class="sxs-lookup"><span data-stu-id="beb28-306">**externalEvaluation** needs to be **true** when an **evaluationTimeout** is set.</span></span> <span data-ttu-id="beb28-307">2 つのピア ツー ピアまたはピア ツー ホスト要件が存在する場合は、セッションに自動で初期化を完了させるために、引き続き **externalEvaluation** を **false** に設定してください。</span><span class="sxs-lookup"><span data-stu-id="beb28-307">If there are two peer-to-peer or peer-to-host requirements, you should still set **externalEvaluation** to **false** in order to have the session automatically finish initialization.</span></span>

**<span data-ttu-id="beb28-308">membersNeededToStart</span><span class="sxs-lookup"><span data-stu-id="beb28-308">membersNeededToStart</span></span>**

-   <span data-ttu-id="beb28-309">これは、"initialize":"true" のときに、QoS に合格して自動評価が成功するために存在する必要があるメンバー予約数の下限です。</span><span class="sxs-lookup"><span data-stu-id="beb28-309">This is the minimum number of member reservations that need to exist with “initialize”:”true” and pass QoS for automatic evaluation to succeed.</span></span>

### <a name="initialization-episodes"></a><span data-ttu-id="beb28-310">初期化エピソード</span><span class="sxs-lookup"><span data-stu-id="beb28-310">Initialization episodes</span></span>


<span data-ttu-id="beb28-311">**memberInitialization** オブジェクトが設定されているとき、MPSD は初期化フェーズをエピソード単位で進めます。</span><span class="sxs-lookup"><span data-stu-id="beb28-311">When the **memberInitialization** object is set, MPSD will progress the initialization phases by episode.</span></span> <span data-ttu-id="beb28-312">最初のエピソードはセッションが作成されたときに開始され、テンプレートで定義されているすべてのフェーズを含みます。</span><span class="sxs-lookup"><span data-stu-id="beb28-312">The first episode is started when the session is created and will include all the phases defined in the template.</span></span>

<span data-ttu-id="beb28-313">エピソードが既に実行されているときに招待されたか参加した新しいメンバーは、次のエピソードに対してマークされます。</span><span class="sxs-lookup"><span data-stu-id="beb28-313">Any new members invited or joined while an episode is already running will be marked for the next episode.</span></span> <span data-ttu-id="beb28-314">エピソードまたは **memberInitialization** 全般の状態は、セッションの **initializing** オブジェクトから取得できます。</span><span class="sxs-lookup"><span data-stu-id="beb28-314">The status of an episode or **memberInitialization** in general can be retrieving from the **initializing** object of the session.</span></span>

<span data-ttu-id="beb28-315">**注意** このオブジェクトは初期化が完了した後に削除されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-315">**Note** Be aware, this object is removed after initialization is complete.</span></span>

<span data-ttu-id="beb28-316">以下に例を示します。</span><span class="sxs-lookup"><span data-stu-id="beb28-316">Example:</span></span>

```
"initializing": {
    "stage": "measuring",
    "stageStartTime": "2009-06-15T13:45:30.0900000Z",
    "episode": 1
},

```

<span data-ttu-id="beb28-317">ステージは、参加、測定、評価の順に遷移します。</span><span class="sxs-lookup"><span data-stu-id="beb28-317">The stage goes from joining to measuring to evaluating.</span></span> <span data-ttu-id="beb28-318">エピソードが失敗した場合、ステージは *failed* に設定され、セッションは初期化できません。</span><span class="sxs-lookup"><span data-stu-id="beb28-318">If an episode fails, then stage is set to *failed* and the session cannot be initialized.</span></span> <span data-ttu-id="beb28-319">それ以外の場合、初期化エピソードが完了すると、**initializing** オブジェクトは削除されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-319">Otherwise, when an initialization episode completes, the **initializing** object is removed.</span></span>

<span data-ttu-id="beb28-320">初期化の失敗は、各メンバーについても追跡できます。</span><span class="sxs-lookup"><span data-stu-id="beb28-320">Initialization failures can also be tracked for each member.</span></span> <span data-ttu-id="beb28-321">joining または measuring ステージからの遷移時にこのメンバーが成功しなかった場合に設定されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-321">They are set when transitioning out of the joining or measuring stage if this member doesn't pass.</span></span>

<span data-ttu-id="beb28-322">以下に例を示します。</span><span class="sxs-lookup"><span data-stu-id="beb28-322">Example:</span></span>
```
"initializationFailure": "latency",
```
<span data-ttu-id="beb28-323">優先度順に、この属性の値は *timeout、latency、bandwidthdown、bandwidthup、network、group*、または *episode* に設定できます。</span><span class="sxs-lookup"><span data-stu-id="beb28-323">In order of precedence, the value for this attribute could be set to *timeout, latency, bandwidthdown, bandwidthup, network, group*, or *episode*.</span></span> <span data-ttu-id="beb28-324">network の値は、ネットワークの構成や、状況 (ネットワーク アドレス変換 \[NAT\] の競合など) が原因で QoS メトリックを測定できなかったことを意味します。</span><span class="sxs-lookup"><span data-stu-id="beb28-324">The network value means the network configuration and/or conditions (such as conflicting network address translation \[NAT\]) prevented the QoS metrics from being measured.</span></span> <span data-ttu-id="beb28-325">joining の終了時の値として可能性があるのは *group* だけです </span><span class="sxs-lookup"><span data-stu-id="beb28-325">The only possible value at the end of joining is *group*.</span></span> <span data-ttu-id="beb28-326">(joining からのタイムアウト時に予約は削除されます)。</span><span class="sxs-lookup"><span data-stu-id="beb28-326">(On timeout from joining, the reservation is removed.)</span></span>

<span data-ttu-id="beb28-327">**memberInitialization** が設定されていて、メンバーに "initialize": true が追加された場合、これはメンバーが参加しようとしている初期化エピソードに追加されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-327">If **memberInitialization** is set and the member was added with "initialize": true, this is set to the initialization episode that the member will participate in.</span></span> <span data-ttu-id="beb28-328">値 1 は、その作成時に新しいセッションに追加されるメンバーに使用され、初期化エピソードの終了時に削除されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-328">A value of 1 is used for the members added to a new session at the time it is created, and it is removed when the initialization episode ends.</span></span>
```
"initializationEpisode": 1,
```

## <a name="match-ticket-session"></a><span data-ttu-id="beb28-329">マッチ チケット セッション</span><span class="sxs-lookup"><span data-stu-id="beb28-329">Match ticket session</span></span>

<span data-ttu-id="beb28-330">MPSD セッションがマッチ チケット セッションとして使用されているとき、いくつかの特別なセッション プロパティおよび定数が使用されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-330">When an MPSD session is being used as a match ticket session, some special session properties and constants are used.</span></span>

**<span data-ttu-id="beb28-331">/members/{index}/constants/system</span><span class="sxs-lookup"><span data-stu-id="beb28-331">/members/{index}/constants/system</span></span>**

```json
{

  {
  "xuid": "12345678",

  "initialize": "false", // Run initialization for this user (if “memberInitialization” is set). Defaults to false.

```

<span data-ttu-id="beb28-332">マッチメイキング サービスでユーザーがセッションに追加されるとき、ユーザーがセッションにマッチングされた過程および理由に関するいくつかのコンテキストが **matchmakingResult** フィールドで提供されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-332">When the Matchmaking service adds users to a session, it provides some context around how and why they were matched into the session, in the **matchmakingResult** field.</span></span>

```
"matchmakingResult": {
```

<span data-ttu-id="beb28-333">これは、マッチメイキング セッションから抜粋したユーザーの **serverMeasurements** のコピーです。</span><span class="sxs-lookup"><span data-stu-id="beb28-333">This is a copy of a user’s **serverMeasurements** from the matchmaking session.</span></span>

```json
"serverMeasurements": {
    "east.thunderhead.azure.com": {
        "latency": 233  // Milliseconds
      }
    }
  }
}

```

## <a name="quality-of-service-qos-templates"></a><span data-ttu-id="beb28-334">サービス品質 (QoS) テンプレート</span><span class="sxs-lookup"><span data-stu-id="beb28-334">Quality of Service (QoS) templates</span></span>

<span data-ttu-id="beb28-335">MPSD がネットワーク レイヤーおよび本体のソーシャル プラットフォームと調整を行うために必要な値をゲーム セッション テンプレートに追加することができます。</span><span class="sxs-lookup"><span data-stu-id="beb28-335">For game session templates, values can be added that inform MPSD to coordinate with the network layer and console social platform.</span></span> <span data-ttu-id="beb28-336">この調整の目的は、セッションが作成される前と、ゲームの参加準備が整ったことがユーザーに通知される前に、接続状態の品質を検証することです。</span><span class="sxs-lookup"><span data-stu-id="beb28-336">The purpose of this coordination is to validate the quality of the connection state before a session is created and before a user is informed that the game is ready to join.</span></span>

<span data-ttu-id="beb28-337">次に引用するコードは、QoS 付きピア ツー ホスト ゲーム セッション テンプレートの例です。</span><span class="sxs-lookup"><span data-stu-id="beb28-337">The following code excerpt is an example of a peer-to-host game session template with QoS:</span></span>

```json
{
    "constants": {
        "system": {
            "version": 1,
            "maxMembersCount": 20,
            "visibility": "private",
            "capabilities": {
                "connectivity": true
            },
            "memberInitialization": {
                "joinTimeout": 20000,
                "externalEvaluation": false,
                "membersNeededToStart": 1
            },
            "peerToHostRequirements": {
                "latencyMaximum": 350,
                "bandwidthDownMinimum": 1000,
                "bandwidthUpMinimum": 100,
                "hostSelectionMetric": "latency"
            }
        },
        "custom": {}
    }
}
```

<span data-ttu-id="beb28-338">次に引用するコードは、QoS 付きピア ツー ピア ゲーム セッション テンプレートの例です。</span><span class="sxs-lookup"><span data-stu-id="beb28-338">This code excerpt is an example of a peer-to-peer game session template with QoS:</span></span>

```json
{
    "constants": {
        "system": {
            "version": 1,
            "maxMembersCount": 20,
            "visibility": "private",
            "capabilities": {
                "connectivity": true
            },
            "memberInitialization": {
                "joinTimeout": 20000,
                "externalEvaluation": false,
                "membersNeededToStart": 1
            },
            "peerToPeerRequirements": {
                "latencyMaximum": 250,
                "bandwidthMinimum": 10000
            }
        },
        "custom": {}
    }
}

```

### <a name="qos-session-template-attributes"></a><span data-ttu-id="beb28-339">QoS セッション テンプレート属性</span><span class="sxs-lookup"><span data-stu-id="beb28-339">QoS session template attributes</span></span>

<span data-ttu-id="beb28-340">**memberInitialization** オブジェクトが設定されている場合、セッションの作成後と新しいメンバーのセッション参加時のいずれかまたは両方で、クライアント システムまたはタイトルが初期化を実行することが期待されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-340">If a **memberInitialization** object is set, the session expects the client system or title to perform initialization following session creation and/or as new members join the session.</span></span>

<span data-ttu-id="beb28-341">タイムアウトおよび初期化ステージは、セッションによって自動的に追跡されます。これには、メトリックが設定されている場合の QoS 測定が含まれます。</span><span class="sxs-lookup"><span data-stu-id="beb28-341">The timeouts and initialization stages are automatically tracked by the session, including QoS measurements if any metrics are set.</span></span>

<span data-ttu-id="beb28-342">これらのタイムアウト値は、**initializationEpisode** プロパティが設定されたメンバーに関して、セッションの予約タイムアウトおよび準備完了タイムアウトを上書きします。</span><span class="sxs-lookup"><span data-stu-id="beb28-342">These timeouts override the session’s reservation and ready timeouts for members that have the **initializationEpisode** property set.</span></span>

```json
"memberInitialization": {
"joinTimeout": 5000,  // Milliseconds. Unspecified counts as 10 seconds.
"measurementTimeout": 5000,  // Milliseconds. Unspecified counts as 30 seconds.
"evaluationTimeout": 5000,  // Milliseconds. Can only be set if 'externalEvaluation' is true. Unspecified counts as 5 seconds.
"externalEvaluation": true,
"membersNeededToStart": 2  // Unspecified counts as 1. Must be between 0 and maxMembersCount. Only applies to episode 1. If 0 and the session is created with no members to initialize, episode 1 is skipped.
},

```

<span data-ttu-id="beb28-343">QoS のあるゲーム セッションには接続機能が必要です。</span><span class="sxs-lookup"><span data-stu-id="beb28-343">A game session with QoS requires connectivity capability.</span></span> <span data-ttu-id="beb28-344">metrics を指定しない場合、QoS 要件を満たすために必要な既定値が使用されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-344">If no metrics are specified, they default to what would be needed to satisfy the QoS requirements.</span></span> <span data-ttu-id="beb28-345">"metrics" が指定されている場合は、QoS 要件を満たすために十分なものである必要があります。</span><span class="sxs-lookup"><span data-stu-id="beb28-345">If they are specified, they must be sufficient to satisfy the QoS requirements.</span></span>

```json
"metrics": {
    "latency": true,
    "bandwidthDown": true,
    "bandwidthUp": true,
    "custom": true

```

<span data-ttu-id="beb28-346">以下のしきい値は、セッション内のすべてのメンバーのペアになっている接続ごとに適用されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-346">The following thresholds apply to each pairwise connection for all members in a session:</span></span>

```json
"peerToPeerRequirements": {
    "latencyMaximum": 250,  // Milliseconds
    "bandwidthMinimum": 10000  // Kilobits per second
},

```

<span data-ttu-id="beb28-347">以下のしきい値は、ホスト候補からの接続ごとに適用されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-347">The following thresholds apply to each connection from a host candidate:</span></span>

```json
"peerToHostRequirements": {
    "latencyMaximum": 250,  // Milliseconds
    "bandwidthDownMinimum": 100000,  // Kilobits per second
    "bandwidthUpMinimum": 1000,  // Kilobits per second
    "hostSelectionMetric": "bandwidthup"  // Or "bandwidthdown" or "latency". Not specified is the same as "latency".
},

```

<span data-ttu-id="beb28-348">以下の潜在的なサーバー接続文字列が評価される必要があります (接続文字列は小文字でなければならない点に注意してください)。</span><span class="sxs-lookup"><span data-stu-id="beb28-348">The following potential server connection strings should be evaluated (note that the connection strings must be lowercase):</span></span>

```json
"measurementServerAddresses": {
        "east.thunderhead.azure.com": {
            "secureDeviceAddress": "r5Y="  // Base-64 encoded secure-device-address
        },
        "west.thunderhead.azure.com": {
            "secureDeviceAddress": "rwY="
        }
    }
}

```

**<span data-ttu-id="beb28-349">members/{index}/properties/system</span><span class="sxs-lookup"><span data-stu-id="beb28-349">members/{index}/properties/system</span></span>**

<span data-ttu-id="beb28-350">これらのフラグはメンバーの状態と **activeTitle** を制御し、相互に排他的です (両方を **true** に設定するとエラーになります)。</span><span class="sxs-lookup"><span data-stu-id="beb28-350">These flags control the member status and **activeTitle**, and they are mutually exclusive (it’s an error to set both to **true**).</span></span> <span data-ttu-id="beb28-351">それぞれ、**false** は "存在しない" ことと同じです。</span><span class="sxs-lookup"><span data-stu-id="beb28-351">For each, **false** is the same as “not present.”</span></span> <span data-ttu-id="beb28-352">既定の状態は "inactive" であり、どちらも存在しないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="beb28-352">The default status is “inactive,” that is, neither is present.</span></span>

```json
"ready": true,
"active": false,

// Base-64 blob, or not present. Empty-string is the same as not present.
// 'capabilities/connectivity' must be enabled in order for this to be set.
"secureDeviceAddress": "ryY=",

// List of members in my group, by index. Each element must be an integer 0 <= n < 'membersInfo/next'.  
// During member initialization, if any members in the list fail, this member will also fail.
"group": [ 5 ],

// QoS measurements by lower-case device token.
// Like all fields, "measurements" must be updated as a whole. It should be set once when measurement is complete, not incrementally.
// Metrics can me omitted if they weren't successfully measured, i.e. the peer is unreachable.
// If a "measurements" object is set, it can't contain an entry for the member's own address.
"measurements": {
"e69c43a8": {
"latency": 5953,  // Milliseconds
"bandwidthDown": 19342,  // Kilobits per second
"bandwidthUp": 944,  // Kilobits per second
"custom": { }
     }
},

// QoS measurements by game-server connection string. Like all fields, "serverMeasurements" must be updated as a whole, so it should be set once when measurement is complete.
// If empty, it means that none of the measurements completed within the "serverMeasurementTimeout".
    "serverMeasurements": {
        "east.thunderhead.azure.com": {
            "latency": 233  // Milliseconds
        }
    },

// Subscriptions for shoulder taps on session changes. The 'profile' indicates which session changes to tap as well as other properties of the registration like the min time between taps.
// The subscription is named with a client-generated GUID that is also sent back with the tap as a context ID.
// Subscriptions can be added and removed individually, without affecting other subscriptions in the "subscriptions" object.
// To remove a subscription, set its context ID to null.
// (Like the "ready" and "active" flags, the "subscriptions" data is copied out and maintained internally, so the normal replace-all rule on system fields doesn't apply to "subscriptions".)
"subscriptions": {
"961dc162-3a8c-4982-b58b-0347ed086bc9": {
"profile": "party",  // Or "matchmaking", "initialization", "roster", "queueHost", or "queue"
"onBehalfOfTitleId": "3948320593",  // Optional decimal title ID of the registered channel.  If not set the title ID is taken from the token.
},
"709fef70-4638-4b94-905b-24cb02706eb5": null
}
}

```

## <a name="qos-phase-and-session-initialization-details"></a><span data-ttu-id="beb28-353">QoS フェーズとセッション初期化の詳細</span><span class="sxs-lookup"><span data-stu-id="beb28-353">QoS phase and session initialization details</span></span>

<span data-ttu-id="beb28-354">テンプレートがメンバー初期化を完了した後、MPSD がゲーム作成の QoS 結果を追跡し、レポートします。</span><span class="sxs-lookup"><span data-stu-id="beb28-354">MPSD will track and report QoS results for game creation after the template has completed member initialization.</span></span> <span data-ttu-id="beb28-355">この処理の進行状況は、前の「[メンバー初期化](#_Member_initialization_in)」のセクションで説明したように、セッション ドキュメントの *initializing* オブジェクトによって表されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-355">The progress of this operation will be represented by an *initializing* object in the session document as described in the [Member initialization](#_Member_initialization_in) section above.</span></span> <span data-ttu-id="beb28-356">*initializing* オブジェクトには、初期化の現在のステージを表す *stage* 属性があります。</span><span class="sxs-lookup"><span data-stu-id="beb28-356">The *initializing* object has a *stage* attribute, which represents the current stage of initialization.</span></span> <span data-ttu-id="beb28-357">ステージは *joining* から *measuring*、*evaluating* の順に進行します。</span><span class="sxs-lookup"><span data-stu-id="beb28-357">The stage progresses from *joining* to *measuring* to *evaluating*.</span></span>

-   <span data-ttu-id="beb28-358">エピソード \#1 の初期化が失敗した場合、ステージは *failed* に設定され、セッションは初期化できません。</span><span class="sxs-lookup"><span data-stu-id="beb28-358">If initializing episode \#1 fails, then stage is set to *failed* and the session cannot be initialized.</span></span> <span data-ttu-id="beb28-359">それ以外の場合、初期化エピソードが完了すると、"initializing" オブジェクトは削除されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-359">Otherwise, when an initialization episode completes, the "initializing" object is removed.</span></span> <span data-ttu-id="beb28-360">**externalEvaluation** が **false** に設定されている場合、evaluating ステージはスキップされます。</span><span class="sxs-lookup"><span data-stu-id="beb28-360">If **externalEvaluation** is set to **false**, the evaluating stage is skipped.</span></span> <span data-ttu-id="beb28-361">**metrics** と **measurementServerAddresses** のどちらも設定されていない場合、measuring ステージはスキップされます。</span><span class="sxs-lookup"><span data-stu-id="beb28-361">If neither **metrics** nor **measurementServerAddresses** is set, the measuring stage is skipped.</span></span>

```json
"initializing": {
    "stage": "measuring",
    "stageStartTime": "2009-06-15T13:45:30.0900000Z",
    "episode": 1
},

```

-   <span data-ttu-id="beb28-362">ホスト候補はデバイス トークンを優先度順に列挙したものです。</span><span class="sxs-lookup"><span data-stu-id="beb28-362">Host candidates are device tokens listed in order of preference.</span></span> <span data-ttu-id="beb28-363">**peerToHostRequirements** が設定されており、**/properties/system/host** が設定されていない場合、初期化エピソード \#1 の *measuring* ステージの後に設定されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-363">They are set after the *measuring* stage of initialization episode \#1 if **peerToHostRequirements** is set and **/properties/system/host** is not set.</span></span> <span data-ttu-id="beb28-364">**/properties/system/host** オブジェクトが設定された後にクリアされます。</span><span class="sxs-lookup"><span data-stu-id="beb28-364">They are cleared after a **/properties/system/host** object is set.</span></span>

```json
"hostCandidates": [ "ab90a362", "99582e67" ],

"constants": { /* Property Bag */ },
"properties": { /* Property Bag */ },
"members": {
    "1": {
        "constants": { /* Property Bag */ },
        "properties": { /* Property Bag */ },

```

-   <span data-ttu-id="beb28-365">*gamertag* 属性は、メンバーが受け入れた場合と、そのメンバーのゲーマータグ クレームが見つかった場合にのみ設定されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-365">The *gamertag* attribute will only be set if the member has accepted and if a gamertag claim was found for that member.</span></span>

```json
"gamertag": "stacy",
```

-   <span data-ttu-id="beb28-366">*deviceToken* 属性は、メンバーがセキュア デバイス アドレスをアップロードするときに設定されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-366">The *deviceToken* attribute is set when the member uploads a secure device address.</span></span> <span data-ttu-id="beb28-367">同等比較に使用できる、大文字と小文字を区別しない文字列です。</span><span class="sxs-lookup"><span data-stu-id="beb28-367">It's a case-insensitive string that can be used for equality comparisons.</span></span>

```json
"deviceToken": "9f4032ba7",
```

-   <span data-ttu-id="beb28-368">*reserved* の値は、ユーザーがセッション ドキュメントへの最初の PUT 要求を実行した後に削除されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-368">The *reserved* value is removed after the user executes his or her first PUT request to the session document.</span></span> <span data-ttu-id="beb28-369">プレイヤーが予約されているとき、それは、プレイヤーがゲーム セッションに招待されたが、招待を受け入れておらず、プレイヤーの接続も評価されていないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="beb28-369">When players are reserved, that means that they have been invited to the game session but have neither accepted nor had their connections evaluated.</span></span>

```json
"reserved": true,
```

-   <span data-ttu-id="beb28-370">メンバーがアクティブな場合、*activeTitleId* はメンバーがアクティブであるタイトルです。10 進数で示されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-370">If the member is active, *activeTitleId* is the title in which the member is active, in decimal.</span></span>

```json
"activeTitleId": "8397267",
```

-   <span data-ttu-id="beb28-371">次の属性は、ユーザーがセッションに参加した日時を指します。</span><span class="sxs-lookup"><span data-stu-id="beb28-371">This attribute refers to the time that the user joined the session.</span></span> <span data-ttu-id="beb28-372">*reserved* が **true** の場合、*joinTime* は予約が行われた日時になります。</span><span class="sxs-lookup"><span data-stu-id="beb28-372">If *reserved* is **true**, then *joinTime* will be the time at which the reservation was made.</span></span>

```json
"joinTime": "2009-06-15T13:45:30.0900000Z",
```

-   <span data-ttu-id="beb28-373">このメンバーが properties/system/turn 配列内にある場合に存在し、それ以外の場合は存在しません。</span><span class="sxs-lookup"><span data-stu-id="beb28-373">Present if this member is in the properties/system/turn array, otherwise not.</span></span>

```json
"turn": true,
```

-   <span data-ttu-id="beb28-374">メンバーがステージを正常に通過しなかった場合、joining または measuring ステージからの遷移時に、メンバー オブジェクトの *initializationFailure* 属性が設定されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-374">The *initializationFailure* attribute is set on the member object when transitioning out of the joining or measuring stage if the member hasn’t successfully passed the stage.</span></span> <span data-ttu-id="beb28-375">優先順位に従って、*timeout*、*latency*、*bandwidthdown*、*bandwidthup*、*network*、*group*、または *episode* に設定できます。</span><span class="sxs-lookup"><span data-stu-id="beb28-375">In order of precedence, it could be set to *timeout*, *latency*, *bandwidthdown*, *bandwidthup*, *network*, *group*, or *episode*.</span></span>
    <span data-ttu-id="beb28-376">*network* の値は、ネットワークの構成や、状況 (ネットワーク アドレス変換 \[NATs\] の競合など) が原因で QoS メトリックを測定できなかったことを意味します。</span><span class="sxs-lookup"><span data-stu-id="beb28-376">The *network* value means that the network configuration and/or conditions (such as conflicting network address translations \[NATs\]) prevented the QoS metrics from being measured.</span></span> <span data-ttu-id="beb28-377">joining の終了時の値として可能性があるのは *group* だけです </span><span class="sxs-lookup"><span data-stu-id="beb28-377">The only possible value at the end of joining is *group*.</span></span> <span data-ttu-id="beb28-378">(joining からのタイムアウト時に予約は削除されます)。*episode* の値は、joining または measuring の間に失敗しなかった初期化エピソードのすべてのメンバーについて "evaluation" ステージが失敗した後に設定されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-378">(On timeout from joining, the reservation is removed.) The *episode* value is set after a failed “evaluation” stage on all members of the initialization episode that didn't fail during joining or measuring.</span></span>

```json
"initializationFailure": "latency",
```

-   <span data-ttu-id="beb28-379">**memberInitialization** が設定されていて、メンバーに "initialize": true が追加された場合、これはメンバーが参加しようとしている初期化エピソードに追加されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-379">If **memberInitialization** is set and the member was added with "initialize": true, this is set to the initialization episode that the member will participate in.</span></span> <span data-ttu-id="beb28-380">1 の値は、作成時に新しいセッションに追加されるメンバーに対して使用されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-380">A value of 1 is used for the members added to a new session at create time.</span></span> <span data-ttu-id="beb28-381">初期化エピソードが終了すると削除されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-381">Removed when the initialization episode ends.</span></span>

```json
"initializationEpisode": 1,
```

-   <span data-ttu-id="beb28-382">*next* 属性は、セッション内の次のメンバーのインデックス値を表します。</span><span class="sxs-lookup"><span data-stu-id="beb28-382">The *next* attribute represents the index value of the next member in the session.</span></span> <span data-ttu-id="beb28-383">追加するメンバーがもういない場合、後続の **membersInfo** オブジェクトの *next* 属性と同じ値になります。</span><span class="sxs-lookup"><span data-stu-id="beb28-383">It will be the same value as the *next* attribute in the **membersInfo** object below if there are no more members to add.</span></span>

```json
            "next": 4
        },
        "4": { "next": 5 /* etc */ }
    },
    "membersInfo": {
        "first": 1,  // The first member's index.
        "next": 5,  // The index that the next member added will get.
        "count": 2,  // The number of members.
        "accepted": 1  // The number of members that are no longer 'pending'.
    },
    "servers": {
        "name": {
            "constants": { /* Property Bag */ },
            "properties": { /* Property Bag */ }
        }
    }
}

```

## <a name="xbox-cloud-compute-session"></a><span data-ttu-id="beb28-384">Xbox クラウド コンピューティング セッション</span><span class="sxs-lookup"><span data-stu-id="beb28-384">Xbox Cloud Compute session</span></span>

<span data-ttu-id="beb28-385">Xbox クラウド コンピューティング セッションには、セッションがゲーム サーバーに接続するために使用できる、大文字と小文字を区別しない接続文字列の順序付きリストが含まれます。</span><span class="sxs-lookup"><span data-stu-id="beb28-385">An Xbox Cloud Compute session contains the ordered list of case-insensitive connection strings that the session could use to connect to a game server.</span></span> <span data-ttu-id="beb28-386">一般的に、タイトルはリストの最初の文字列を使用してください。ただし、高度なタイトルでは、(負荷などの条件に基づいて) 他のいずれかを選択するための (Xbox Live Compute のような) カスタム メカニズムを使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="beb28-386">Generally, titles should use the first string on the list, but sophisticated titles could use a custom mechanism (such as Xbox Live Compute) for choosing one of the others (for instance, based on load).</span></span>

```json
    "serverConnectionStringCandidates": [ "west.thunderhead.azure.com", "east.thunderhead.azure.com" ],

    "matchmaking": {
        "clientResult": {  // Requires the clientMatchmaking property.
            "status": "searching",  // Or "expired", "found", "failed", or "canceled".
            "statusDetails": "Description",  // Default is empty string.
            "typicalWait": 30,  // The expected number of seconds waiting as a non-negative integer.
            "targetSessionRef": {
                "scid": "1ECFDB89-36EB-4E59-8901-11F7393689AE",
                "templateName": "capture-the-flag",
                "name": "2D58F65F-0E3C-4F1F-8277-2BC9873FDB23"
            }
        },

        "targetSessionConstants": { },

        // Force a specific connection string to be used (useful in preserveSession=always cases).
        "serverConnectionString": "west.thunderhead.azure.com",

        // True if the match that was found didn't work out and needs to be resubmitted. Set to false
        // to signal that the match did work, and the matchmaking service can release the session.
        "resubmit": true
    }
}

```

<span data-ttu-id="beb28-387">\*\*/servers/{server-name}/properties/system \*\*</span><span class="sxs-lookup"><span data-stu-id="beb28-387">\*\*/servers/{server-name}/properties/system \*\*</span></span>

```json
{
    "lockId": "opaque56789",  // If set, a matchmaking service is servicing this session.
    "status": "searching",  // Or "expired", "found", "failed", or "canceled". Optional.
    "statusDetails": "Description",  // Optional free-form text. Default is empty string.
    "typicalWait": 30,  // Optional. The expected number of seconds waiting as a non-negative integer.
    "targetSessionRef": {  // Optional.
        "scid": "1ECFDB89-36EB-4E59-8901-11F7393689AE",
        "templateName": "capture-the-flag",
        "name": "2D58F65F-0E3C-4F1F-8277-2BC9873FDB23"
    }
}

```

## <a name="raw-session-and-custom-title-properties"></a><span data-ttu-id="beb28-388">RAW セッションとカスタム タイトル プロパティ</span><span class="sxs-lookup"><span data-stu-id="beb28-388">Raw session and custom title properties</span></span>

<span data-ttu-id="beb28-389">マルチプレイヤー ゲームに関連したカスタムのハウスキーピング情報 (メタデータ) を格納するためにセッションを使用できます。</span><span class="sxs-lookup"><span data-stu-id="beb28-389">A session can be used to store custom housekeeping information (metadata) around a multiplayer game.</span></span> <span data-ttu-id="beb28-390">ゲーム データまたは保存される情報は TMS++ に格納される必要があります。</span><span class="sxs-lookup"><span data-stu-id="beb28-390">Game data or saved information should be stored in TMS++.</span></span>

### <a name="property-bags"></a><span data-ttu-id="beb28-391">プロパティ バッグ</span><span class="sxs-lookup"><span data-stu-id="beb28-391">Property bags</span></span>

<span data-ttu-id="beb28-392">これまでの例で "プロパティ バッグ" の注記が付いた各オブジェクトは、オプションの内部オブジェクトである system と custom の 2 種類から構成されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-392">Each of the above objects marked as a property bag consists of two optional inner objects, system and custom.</span></span>

<span data-ttu-id="beb28-393">custom オブジェクトには任意の JSON を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="beb28-393">The custom objects can contain any JSON.</span></span>

```json
"custom": {
    "myField1": true,
    "myField2": "string",
    "myField3": 5.5,
    "myField4": { "myObject": null },
    "myField5": [ "my", "array" ]
}

```

## <a name="active-member-decay"></a><span data-ttu-id="beb28-394">アクティブ メンバーの無効化</span><span class="sxs-lookup"><span data-stu-id="beb28-394">Active member decay</span></span>

<span data-ttu-id="beb28-395">MPSD は、ユーザーがタイトルに参加していないことを検出すると、アクティブなメンバーを自動的に非アクティブとしてマークします。</span><span class="sxs-lookup"><span data-stu-id="beb28-395">Active members are automatically marked inactive when MPSD detects that the user is no longer engaged in the title.</span></span> <span data-ttu-id="beb28-396">たとえば、プレゼンスがユーザー レコードをタイムアウトすると、このようなことが起きる場合があります。</span><span class="sxs-lookup"><span data-stu-id="beb28-396">This can happen, for example, if the Presence times out the user record.</span></span> <span data-ttu-id="beb28-397">このメカニズムは単なる安全装置です。つまり、メンバーがタイトルを終了するか切り替えたとき、サインアウトしたとき、または他の何らかの形で関与しなくなったときに、タイトルが事前にメンバーを非アクティブとしてマークする (または、メンバーをセッションから削除する) 必要があることには変わりありません。</span><span class="sxs-lookup"><span data-stu-id="beb28-397">This mechanism is just a backstop; that is,titles are still required to proactively mark members as inactive (or remove them from the session) when the members leave or switch away from the title, sign out, or otherwise become disengaged.</span></span>

## <a name="faq-and-troubleshooting"></a><span data-ttu-id="beb28-398">FAQ とトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="beb28-398">FAQ and troubleshooting</span></span>

### <a name="how-do-i-call-mpsd-"></a><span data-ttu-id="beb28-399">MPSD はどのように呼び出しますか。</span><span class="sxs-lookup"><span data-stu-id="beb28-399">How do I call MPSD ?</span></span>

<span data-ttu-id="beb28-400">証明書認証の使用: client-sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="beb28-400">Using certificate authentication: client-sessiondirectory.xboxlive.com</span></span>

<span data-ttu-id="beb28-401">以下に例を示します。</span><span class="sxs-lookup"><span data-stu-id="beb28-401">Example:</span></span>

```
PUT https://client-sessiondirectory-stress.xboxlive.com/serviceconfigs/8cvda84-2606-4bab-8eda-d12313e65143/sessiontemplates/teamDeathmatch/sessions/3baafc35-816d-49cd-9656-5772506c988a
```

<span data-ttu-id="beb28-402">XToken 認証の使用: sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="beb28-402">Using XToken authentication: sessiondirectory.xboxlive.com</span></span>

<span data-ttu-id="beb28-403">以下に例を示します。</span><span class="sxs-lookup"><span data-stu-id="beb28-403">Example:</span></span>

```
PUT https://sessiondirectory-stress.xboxlive.com/serviceconfigs/8cvda84-2606-4bab-8eda-d12313e65143/sessiontemplates/teamDeathmatch/sessions/3baafc35-816d-49cd-9656-5772506c988a
```

### <a name="how-do-i-find-out-what-scid-session-template-and-sandbox-to-use"></a><span data-ttu-id="beb28-404">使用する SCID、セッション テンプレート、サンドボックスを調べる方法を教えてください。</span><span class="sxs-lookup"><span data-stu-id="beb28-404">How do I find out what SCID, session template, and sandbox to use?</span></span>

<span data-ttu-id="beb28-405">この情報はタイトルの XDP サイトで調べることができます。</span><span class="sxs-lookup"><span data-stu-id="beb28-405">This information can be found on the XDP site for your title.</span></span> <span data-ttu-id="beb28-406">まだ XDP にアクセスできない場合は、情報の入手を支援できる、担当のデベロッパー アカウント マネージャーに問い合わせてください。</span><span class="sxs-lookup"><span data-stu-id="beb28-406">If you do not yet have access to XDP contact your developer account manager, who can assist in getting the information for you.</span></span>

### <a name="is-there-an-example-of-a-request-body-that-i-can-compare-my-own-to"></a><span data-ttu-id="beb28-407">自分のものと比較できる要求本文の例はありますか。</span><span class="sxs-lookup"><span data-stu-id="beb28-407">Is there an example of a request body that I can compare my own to?</span></span>


### <a name="i-am-getting-a-404-error-when-calling-mpsd"></a><span data-ttu-id="beb28-408">MPSD の呼び出し時に 404 エラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="beb28-408">I am getting a 404 error when calling MPSD.</span></span>

<span data-ttu-id="beb28-409">Fiddler トレースを収集して詳細な情報を取得した後、次のことを行います。</span><span class="sxs-lookup"><span data-stu-id="beb28-409">Collect Fiddler traces to help get more information and then do the following:</span></span>

1.  <span data-ttu-id="beb28-410">一般的な 404 メッセージの HttpResponse 本文の一部として返されたメッセージを確認します。</span><span class="sxs-lookup"><span data-stu-id="beb28-410">Check the message returned as part of the HttpResponse body for common 404 messages:</span></span>

    -   <span data-ttu-id="beb28-411">*要求されたサービス構成は無効であるか、またはセッション用に構成されていません。*</span><span class="sxs-lookup"><span data-stu-id="beb28-411">*The requested service config is either invalid or not configured for sessions*.</span></span> <span data-ttu-id="beb28-412">正しい SCID を使用していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="beb28-412">Verify that the SCID being used is correct.</span></span>

    -   <span data-ttu-id="beb28-413">*要求されたセッションが見つかりませんでした。*</span><span class="sxs-lookup"><span data-stu-id="beb28-413">*The requested session wasn't found*.</span></span> <span data-ttu-id="beb28-414">セッションを取得する前に、セッションが作成されておりセッション テンプレートが正しいことを確認します。</span><span class="sxs-lookup"><span data-stu-id="beb28-414">Verify that the session is created and the session template is correct before retrieving it.</span></span> <span data-ttu-id="beb28-415">PUT 呼び出しを使用してセッションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="beb28-415">You can create a session with a PUT call.</span></span>

2.  <span data-ttu-id="beb28-416">使用している URI を確認します。</span><span class="sxs-lookup"><span data-stu-id="beb28-416">Check the URI you are using.</span></span>

3.  <span data-ttu-id="beb28-417">本体を再起動するか、新しいユーザーで試行するか、その両方を行います。</span><span class="sxs-lookup"><span data-stu-id="beb28-417">Reboot the console and/or try again with a new user.</span></span>

4.  <span data-ttu-id="beb28-418">エラー コードやその他の可能な解決方法を[エンターテイメント デベロッパー フォーラム](https://developer.xboxlive.com/en-us/platform/community/forums/Pages/home.aspx)で検索します。</span><span class="sxs-lookup"><span data-stu-id="beb28-418">Search the [Entertainment Developer Forums](https://developer.xboxlive.com/en-us/platform/community/forums/Pages/home.aspx) for the error code or other potential solutions.</span></span>

### <a name="i-am-getting-a-403-error-when-calling-mpsd"></a><span data-ttu-id="beb28-419">MPSD の呼び出し時に 403 エラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="beb28-419">I am getting a 403 error when calling MPSD.</span></span>

<span data-ttu-id="beb28-420">通常、これはアクセス許可またはスコープの問題です。</span><span class="sxs-lookup"><span data-stu-id="beb28-420">This is usually a permissions or scope issue.</span></span> <span data-ttu-id="beb28-421">Fiddler トレースを収集して詳細な情報を取得した後、次のことを行います。</span><span class="sxs-lookup"><span data-stu-id="beb28-421">Collect Fiddler traces to help get more information and then do the following:</span></span>

1.  <span data-ttu-id="beb28-422">一般的な 403 メッセージの HttpResponse の本文の一部として返されるメッセージを確認します。</span><span class="sxs-lookup"><span data-stu-id="beb28-422">Check messages returned as part of the HttpResponse body for common 403 messages:</span></span>

-   <span data-ttu-id="beb28-423">\*要求されたサービス構成にアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="beb28-423">\*The requested service config cannot be accessed.</span></span> *

    -   <span data-ttu-id="beb28-424">サンドボックスにアクセスできるアカウントを使用していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="beb28-424">Verify that you are using an account that has access to the sandbox.</span></span>

    -   <span data-ttu-id="beb28-425">正しいサンドボックス内にいることを確認します。</span><span class="sxs-lookup"><span data-stu-id="beb28-425">Verify that you are within the correct sandbox.</span></span>

    -   <span data-ttu-id="beb28-426">証明書認証を使用していてこのエラーが発生する場合は、担当の DAM に問い合わせてください。</span><span class="sxs-lookup"><span data-stu-id="beb28-426">If you are using certificate authentication and getting this error, contact your DAM.</span></span>

-   *<span data-ttu-id="beb28-427">要求されたセッションにアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="beb28-427">The requested session cannot be accessed.</span></span> <span data-ttu-id="beb28-428">Private Sessions can only be read by members of the session. (プライベート セッションは、セッションのメンバーによってのみ読み取り可能です。)</span><span class="sxs-lookup"><span data-stu-id="beb28-428">Private Sessions can only be read by members of the session.</span></span>*

    -   <span data-ttu-id="beb28-429">可視性が "private" のセッションにアクセスしようとしています。</span><span class="sxs-lookup"><span data-stu-id="beb28-429">You are trying to access a session that has a visibility of “private.”</span></span> <span data-ttu-id="beb28-430">セッション内のメンバーのみがセッション ドキュメントを読むことができます。</span><span class="sxs-lookup"><span data-stu-id="beb28-430">Only members within the session can read the session document.</span></span>

-   *<span data-ttu-id="beb28-431">認証プリンシパルにサーバーが含まれていない場合、要求本文に既存メンバーの参照を含めることはできません。</span><span class="sxs-lookup"><span data-stu-id="beb28-431">The request body can't contain existing member references unless the authentication principal includes a server.</span></span>*

    -   <span data-ttu-id="beb28-432">ユーザーの代わりに別のユーザーをセッションに参加させることはできません。</span><span class="sxs-lookup"><span data-stu-id="beb28-432">You cannot join another user to a session on behalf of a user.</span></span> <span data-ttu-id="beb28-433">招待のみ可能です。</span><span class="sxs-lookup"><span data-stu-id="beb28-433">You can only invite.</span></span> <span data-ttu-id="beb28-434">プレイヤーを招待するには、インデックスを “reserve\_&lt;number&gt;” に設定します。</span><span class="sxs-lookup"><span data-stu-id="beb28-434">Set the index to “reserve\_&lt;number&gt;” to invite a player.</span></span>

### <a name="i-am-getting-a-412-precondition-failed-error"></a><span data-ttu-id="beb28-435">412 Precondition Failed エラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="beb28-435">I am getting a 412 Precondition Failed error.</span></span>

<span data-ttu-id="beb28-436">次の例は、セッションが既に存在する場合に 412 Precondition Failed を返します。</span><span class="sxs-lookup"><span data-stu-id="beb28-436">This will return 412 Precondition Failed if the session already exists:</span></span>

> <span data-ttu-id="beb28-437">PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/foo HTTP/1.1 Content-Type: application/json If-None-Match: \*</span><span class="sxs-lookup"><span data-stu-id="beb28-437">PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/foo HTTP/1.1 Content-Type: application/json If-None-Match: \*</span></span>

<span data-ttu-id="beb28-438">次の例は、セッションの etag が If-Match ヘッダーと一致しない場合に 412 Precondition Failed を返します。</span><span class="sxs-lookup"><span data-stu-id="beb28-438">This will return 412 Precondition Failed if the session etag doesn’t match the If-Match header:</span></span>

> <span data-ttu-id="beb28-439">PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/foo HTTP/1.1 Content-Type: application/json If--Match: 9555A7DE-8B91-40E4-8CFB-0629312C9C7D</span><span class="sxs-lookup"><span data-stu-id="beb28-439">PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/foo HTTP/1.1 Content-Type: application/json If--Match: 9555A7DE-8B91-40E4-8CFB-0629312C9C7D</span></span>

### <a name="i-am-getting-errors-such-as-405-409-503-and-400when-calling-mpsd"></a><span data-ttu-id="beb28-440">MPSD の呼び出し時に 405、409、503、400 などのエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="beb28-440">I am getting errors such as 405, 409, 503, and 400when calling MPSD.</span></span>

<span data-ttu-id="beb28-441">Fiddler トレースを収集して詳しい情報を入手した後、HttpResponse の本文の一部として返されるメッセージを確認します。</span><span class="sxs-lookup"><span data-stu-id="beb28-441">Collect Fiddler traces to help get more information and then check the messages returned as part of the HttpResponse body.</span></span> <span data-ttu-id="beb28-442">これにより、エラーを識別して修正したり、可能な解決方法を[エンターテイメント デベロッパー フォーラム](https://developer.xboxlive.com/en-us/platform/community/forums/Pages/home.aspx)で検索したりするための十分な情報が得られるはずです。</span><span class="sxs-lookup"><span data-stu-id="beb28-442">This should give you enough information to identify and fix the error or to search the [Entertainment Developer Forums](https://developer.xboxlive.com/en-us/platform/community/forums/Pages/home.aspx) for possible solutions.</span></span>

<span data-ttu-id="beb28-443">Xbox Live Service API を使用している場合は **DiagnosticsTraceLevel** プロパティを Error (デバッグ出力に情報を出力する) に設定することで、応答本文を取得することもできます。または、いくつかのサンプルで例を示しているように、**XboxLiveContextSettings.ServiceCallRouted** イベントを使用してタイトルの UI に出力できます。</span><span class="sxs-lookup"><span data-stu-id="beb28-443">You can also get the response body if you are using the Xbox Live Service APIs by setting the **DiagnosticsTraceLevel** property to Error, which will output the information in the debug output, or you can use the **XboxLiveContextSettings.ServiceCallRouted** event as demonstrated in multiple samples to output to your title UI.</span></span>

### <a name="what-can-or-should-i-change-in-the-templates-for-my-title"></a><span data-ttu-id="beb28-444">タイトルのテンプレートでは何を変更できますか、または何を変更する必要がありますか。</span><span class="sxs-lookup"><span data-stu-id="beb28-444">What can or should I change in the templates for my title?</span></span>

<span data-ttu-id="beb28-445">セッション テンプレートは既定値ではなく鋳型のようなものです。</span><span class="sxs-lookup"><span data-stu-id="beb28-445">Session templates are not defaults, but are more of a mold.</span></span> <span data-ttu-id="beb28-446">ただし、テンプレートに定数を追加することは可能ですが、既に設定されている定数を上書きすることはできません。</span><span class="sxs-lookup"><span data-stu-id="beb28-446">However, you cannot override the constants already set in the templates, although you can add to them.</span></span>

### <a name="im-getting-an-error-that-is-saying-my-session-isnt-initialized"></a><span data-ttu-id="beb28-447">セッションが初期化されていないことを示すエラーが示されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-447">I’m getting an error that is saying my session isn’t initialized.</span></span>

<span data-ttu-id="beb28-448">この問題を修正するには、(通常はゲーム、パーティー、およびマッチ チケットの各シナリオで) メンバー初期化がテンプレートに存在する場合に、QoS に合格するために十分なメンバー予約 (開始するために必要なメンバー数) の分だけ "initialize=true" が設定されていることを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="beb28-448">When member initialization is present in your template (game, party, and match ticket scenarios, usually), you need to make sure that “initialize=true” is set for enough of the member reservations (members needed to start) to pass QoS to fix this issue.</span></span>

### <a name="my-session-is-not-being-created-and-im-getting-an-http-204-error"></a><span data-ttu-id="beb28-449">セッションが作成されず HTTP 204 エラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="beb28-449">My session is not being created and I’m getting an HTTP 204 error.</span></span>

<span data-ttu-id="beb28-450">これは、セッションを作成したときにセッションにユーザーが追加されなかったことを示します。</span><span class="sxs-lookup"><span data-stu-id="beb28-450">This indicates that there were no users added to the session when you created it.</span></span> <span data-ttu-id="beb28-451">作成の時点でセッションのユーザーがいない場合、セッションは作成されません。</span><span class="sxs-lookup"><span data-stu-id="beb28-451">If there are no users for a session at the time of creation, the session will not be created.</span></span> <span data-ttu-id="beb28-452">必ず、少なくとも 1 人のプレイヤーを作成時にセッションに追加してください。</span><span class="sxs-lookup"><span data-stu-id="beb28-452">Make sure that you add at least one player to a session on creation.</span></span> <span data-ttu-id="beb28-453">専用サーバーのシナリオの場合は、マッチを作成しようとしているプレイヤーか、マッチを作成する必要があるユーザーを識別して、そのユーザーをマッチ内の最初のプレイヤーにします。</span><span class="sxs-lookup"><span data-stu-id="beb28-453">For dedicated server scenarios, obtain a player who is trying to create a match, or who needs to create a match, and make that user the initial player in that match.</span></span> <span data-ttu-id="beb28-454">別の方法として、**sessionEmptyTimeout** を変更または削除できます。</span><span class="sxs-lookup"><span data-stu-id="beb28-454">Alternatively you can change or remove the **sessionEmptyTimeout**.</span></span>

### <a name="when-should-i-poll-the-mpsd"></a><span data-ttu-id="beb28-455">MPSD をポーリングすべきタイミングを教えてください。</span><span class="sxs-lookup"><span data-stu-id="beb28-455">When should I poll the MPSD?</span></span>

<span data-ttu-id="beb28-456">MPSD セッションのポーリングは避ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="beb28-456">You should avoid polling MPSD sessions.</span></span> <span data-ttu-id="beb28-457">一般に、各クライアントのネットワーク接続の初期確立と、接続を失った 1 つまたは複数のクライアントのネットワーク状態の再確立のみに MPSD セッションを利用するようにコードを設計することによって、この指針に従うことができます。</span><span class="sxs-lookup"><span data-stu-id="beb28-457">At a high level, you can do this by designing your code in a way that utilizes the MPSD session only for initial establishment of network connectivity for each client, and for reestablishing network state for a client or clients that have lost connectivity.</span></span> <span data-ttu-id="beb28-458">競合状態を解決するためにセッション状態をリフレッシュする必要性を排除するために、MPSD の etag ベースの同期プリミティブを利用することも重要です。</span><span class="sxs-lookup"><span data-stu-id="beb28-458">It’s also important to take advantage of MPSD’s etag-based synchronization primitives to eliminate the need to refresh session state to resolve race conditions.</span></span>

<span data-ttu-id="beb28-459">N 個のクライアントの集合が存在し、すべてのクライアントが相互接続してピア ツー ピア メッシュでプレイする必要がある場合に、これらの原則がよく適用されます。</span><span class="sxs-lookup"><span data-stu-id="beb28-459">A common application of these principles is when you have a set of N clients that all need to connect together and play in a peer-to-peer mesh.</span></span> <span data-ttu-id="beb28-460">セッションを定期的にクエリして新しいメンバーを検出しなくても、それぞれのメンバーは、セッションに参加したり、セッションに参加中のメンバーに接続したり、後続の参加者が同じ行動をすると想定したりできます。</span><span class="sxs-lookup"><span data-stu-id="beb28-460">Rather than regularly querying the session for new members, each member can join the session, connect to the members already in the session, and assume that any later joiners will do the same.</span></span> <span data-ttu-id="beb28-461">これを実装する方法の例については、Chat サンプルおよび Player Rendezvous サンプルを参照してください。</span><span class="sxs-lookup"><span data-stu-id="beb28-461">See the Chat and Player Rendezvous samples for examples of how to implement this.</span></span>

<span data-ttu-id="beb28-462">ごく一部の状況で、短期間のポーリングが必要な場合があります。ポーリングが必要と思われる場合は、担当のデベロッパー アカウント マネージャーに問い合わせてください。</span><span class="sxs-lookup"><span data-stu-id="beb28-462">There are some rare cases where polling may be necessary for brief periods; contact your developer account manager if you believe you need to do this.</span></span>
