---
title: ユニバーサル リソース識別子 (URI) リファレンス
assetID: cb7c6fe2-0376-dab4-9115-e4e3ebcfbd39
permalink: en-us/docs/xboxlive/rest/atoc-xboxlivews-reference-uris.html
description: " ユニバーサル リソース識別子 (URI) リファレンス"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: cd86a6147c047a2925cdb931d9735712a4032adb
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623407"
---
# <a name="universal-resource-identifier-uri-reference"></a><span data-ttu-id="5de59-104">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="5de59-104">Universal Resource Identifier (URI) Reference</span></span>

<span data-ttu-id="5de59-105">このセクションでは、Uniform Resource Identifier (Uri) および Xbox Live サービスで使用されるハイパー テキスト転送プロトコル (HTTP) 方法の詳細を提供します。</span><span class="sxs-lookup"><span data-stu-id="5de59-105">This section provides detail about the Uniform Resource Identifiers (URIs) and Hypertext Transport Protocol (HTTP) methods used with Xbox Live Services.</span></span>

<a id="ID4EAB"></a>


## <a name="in-this-section"></a><span data-ttu-id="5de59-106">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="5de59-106">In this section</span></span>

[<span data-ttu-id="5de59-107">アチーブメントの Uri</span><span class="sxs-lookup"><span data-stu-id="5de59-107">Achievements URIs</span></span>](achievements/atoc-reference-achievementsv2.md)

<span data-ttu-id="5de59-108">&nbsp;&nbsp;Uri およびアチーブメントの関連する HTTP メソッド。</span><span class="sxs-lookup"><span data-stu-id="5de59-108">&nbsp;&nbsp;URIs and associated HTTP methods for achievements.</span></span>

[<span data-ttu-id="5de59-109">ゲーム サーバー Universal Resource Identifier (URI) のリファレンス</span><span class="sxs-lookup"><span data-stu-id="5de59-109">Game Server Universal Resource Identifier (URI) Reference</span></span>](gsdk/atoc-gsdk-uri-reference.md)

<span data-ttu-id="5de59-110">&nbsp;&nbsp;タイトルのゲーム Server 開発キットのサーバー インスタンスを作成するのに使用する Uri。</span><span class="sxs-lookup"><span data-stu-id="5de59-110">&nbsp;&nbsp;URIs used by clients to create Game Server Development Kit server instances for a title.</span></span>

[<span data-ttu-id="5de59-111">ゲーム録画 Uri</span><span class="sxs-lookup"><span data-stu-id="5de59-111">Game DVR URIs</span></span>](dvr/atoc-reference-dvr.md)

<span data-ttu-id="5de59-112">&nbsp;&nbsp;Uri およびゲーム録画の関連する HTTP メソッド。</span><span class="sxs-lookup"><span data-stu-id="5de59-112">&nbsp;&nbsp;URIs and associated HTTP methods for game DVR.</span></span>

[<span data-ttu-id="5de59-113">Gamerpic Uri</span><span class="sxs-lookup"><span data-stu-id="5de59-113">Gamerpic URIs</span></span>](gamerpic/atoc-reference-gamerpic.md)

<span data-ttu-id="5de59-114">&nbsp;&nbsp;Uri およびタイトル生成 gamerpics の関連する HTTP メソッド。</span><span class="sxs-lookup"><span data-stu-id="5de59-114">&nbsp;&nbsp;URIs and associated HTTP methods for title-generated gamerpics.</span></span>

[<span data-ttu-id="5de59-115">Uri のランキング</span><span class="sxs-lookup"><span data-stu-id="5de59-115">Leaderboards URIs</span></span>](leaderboard/atoc-reference-leaderboard.md)

<span data-ttu-id="5de59-116">&nbsp;&nbsp;Uri およびスコアボードの関連する HTTP メソッド。</span><span class="sxs-lookup"><span data-stu-id="5de59-116">&nbsp;&nbsp;URIs and associated HTTP methods for leaderboards.</span></span>

[<span data-ttu-id="5de59-117">Uri が一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="5de59-117">Lists URIs</span></span>](lists/atoc-reference-lists.md)

<span data-ttu-id="5de59-118">&nbsp;&nbsp;Uri およびピンの関連する HTTP メソッド。</span><span class="sxs-lookup"><span data-stu-id="5de59-118">&nbsp;&nbsp;URIs and associated HTTP methods for PINs.</span></span>

[<span data-ttu-id="5de59-119">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="5de59-119">Marketplace URIs</span></span>](marketplace/atoc-reference-marketplace.md)

<span data-ttu-id="5de59-120">&nbsp;&nbsp;Uri および Xbox の marketplace サービスの関連する HTTP メソッド。</span><span class="sxs-lookup"><span data-stu-id="5de59-120">&nbsp;&nbsp;URIs and associated HTTP methods for Xbox marketplace services.</span></span>

[<span data-ttu-id="5de59-121">Uri のマッチメイ キング</span><span class="sxs-lookup"><span data-stu-id="5de59-121">Matchmaking URIs</span></span>](matchtickets/atoc-reference-matchtickets.md)

<span data-ttu-id="5de59-122">&nbsp;&nbsp;Uri およびマッチメイ キングに関連する HTTP/REST メソッド。</span><span class="sxs-lookup"><span data-stu-id="5de59-122">&nbsp;&nbsp;URIs and associated HTTP/REST methods for matchmaking.</span></span>

[<span data-ttu-id="5de59-123">ユーザーの Uri</span><span class="sxs-lookup"><span data-stu-id="5de59-123">People URIs</span></span>](people/atoc-reference-people.md)

<span data-ttu-id="5de59-124">&nbsp;&nbsp;Uri および HTTP メソッドが関連付けられているユーザーのシステムです。</span><span class="sxs-lookup"><span data-stu-id="5de59-124">&nbsp;&nbsp;URIs and associated HTTP methods the people system.</span></span>

[<span data-ttu-id="5de59-125">プレゼンスの Uri</span><span class="sxs-lookup"><span data-stu-id="5de59-125">Presence URIs</span></span>](presence/atoc-reference-presence.md)

<span data-ttu-id="5de59-126">&nbsp;&nbsp;Uri およびプレゼンスに関連する HTTP メソッド。</span><span class="sxs-lookup"><span data-stu-id="5de59-126">&nbsp;&nbsp;URIs and associated HTTP methods for presence.</span></span>

[<span data-ttu-id="5de59-127">プライバシーの Uri</span><span class="sxs-lookup"><span data-stu-id="5de59-127">Privacy URIs</span></span>](privacy/atoc-reference-privacyv2.md)

<span data-ttu-id="5de59-128">&nbsp;&nbsp;Uri およびプライバシーの関連する HTTP メソッド。</span><span class="sxs-lookup"><span data-stu-id="5de59-128">&nbsp;&nbsp;URIs and associated HTTP methods for privacy.</span></span>

[<span data-ttu-id="5de59-129">プロファイルの Uri</span><span class="sxs-lookup"><span data-stu-id="5de59-129">Profiles URIs</span></span>](profileV2/atoc-reference-profiles.md)

<span data-ttu-id="5de59-130">&nbsp;&nbsp;Uri およびプロファイルの関連する HTTP メソッド。</span><span class="sxs-lookup"><span data-stu-id="5de59-130">&nbsp;&nbsp;URIs and associated HTTP methods for profiles.</span></span>

[<span data-ttu-id="5de59-131">評価の Uri</span><span class="sxs-lookup"><span data-stu-id="5de59-131">Reputation URIs</span></span>](reputation/atoc-reference-reputation.md)

<span data-ttu-id="5de59-132">&nbsp;&nbsp;Uri と、reputation service に関連付けられている HTTP メソッド。</span><span class="sxs-lookup"><span data-stu-id="5de59-132">&nbsp;&nbsp;URIs and associated HTTP methods for the reputation service.</span></span>

[<span data-ttu-id="5de59-133">セッション ディレクトリの Uri</span><span class="sxs-lookup"><span data-stu-id="5de59-133">Session Directory URIs</span></span>](sessiondirectory/atoc-reference-sessiondirectory.md)

<span data-ttu-id="5de59-134">&nbsp;&nbsp;Uri および関連する HTTP メソッドのマルチ プレーヤーのセッション ディレクトリ (MPSD)。</span><span class="sxs-lookup"><span data-stu-id="5de59-134">&nbsp;&nbsp;URIs and associated HTTP methods for Multiplayer Session Directory (MPSD).</span></span>

[<span data-ttu-id="5de59-135">アチーブメントのタイトルの履歴の Uri</span><span class="sxs-lookup"><span data-stu-id="5de59-135">Achievement Title History URIs</span></span>](titlehistory/atoc-reference-titlehistoryv2.md)

<span data-ttu-id="5de59-136">&nbsp;&nbsp;Uri および関連する HTTP メソッドの*履歴をタイトル*します。</span><span class="sxs-lookup"><span data-stu-id="5de59-136">&nbsp;&nbsp;URIs and associated HTTP methods for *title history*.</span></span>

[<span data-ttu-id="5de59-137">ストレージ Uri のタイトル</span><span class="sxs-lookup"><span data-stu-id="5de59-137">Title Storage URIs</span></span>](storage/atoc-reference-storagev2.md)

<span data-ttu-id="5de59-138">&nbsp;&nbsp;Uri およびタイトルのストレージに関連する HTTP メソッド。</span><span class="sxs-lookup"><span data-stu-id="5de59-138">&nbsp;&nbsp;URIs and associated HTTP methods for title storage.</span></span>

[<span data-ttu-id="5de59-139">システムが検証の Uri を文字列します。</span><span class="sxs-lookup"><span data-stu-id="5de59-139">System Strings Validatation URIs</span></span>](stringserver/atoc-reference-systemstringsvalidate.md)

<span data-ttu-id="5de59-140">&nbsp;&nbsp;文字列の受け入れを検証するシステム リソース。</span><span class="sxs-lookup"><span data-stu-id="5de59-140">&nbsp;&nbsp;System resource to validate acceptance of strings on .</span></span>

[<span data-ttu-id="5de59-141">ユーザーの Uri</span><span class="sxs-lookup"><span data-stu-id="5de59-141">Users URIs</span></span>](users/atoc-reference-users.md)

<span data-ttu-id="5de59-142">&nbsp;&nbsp;Uri とユーザーに関連付けられている HTTP メソッド。</span><span class="sxs-lookup"><span data-stu-id="5de59-142">&nbsp;&nbsp;URIs and associated HTTP methods for users.</span></span>

[<span data-ttu-id="5de59-143">ユーザーの統計情報の Uri</span><span class="sxs-lookup"><span data-stu-id="5de59-143">User Statistics URIs</span></span>](userstats/atoc-reference-userstats.md)

<span data-ttu-id="5de59-144">&nbsp;&nbsp;Uri とユーザーの統計情報に関連付けられている HTTP メソッド。</span><span class="sxs-lookup"><span data-stu-id="5de59-144">&nbsp;&nbsp;URIs and associated HTTP methods for user statistics.</span></span>

<a id="ID4E5C"></a>


## <a name="see-also"></a><span data-ttu-id="5de59-145">関連項目</span><span class="sxs-lookup"><span data-stu-id="5de59-145">See also</span></span>

<a id="ID4EAD"></a>


##### <a name="parent"></a><span data-ttu-id="5de59-146">Parent</span><span class="sxs-lookup"><span data-stu-id="5de59-146">Parent</span></span>

[<span data-ttu-id="5de59-147">Xbox Live Services RESTful のリファレンス</span><span class="sxs-lookup"><span data-stu-id="5de59-147">Xbox Live Services RESTful Reference</span></span>](../atoc-xboxlivews-reference.md)
