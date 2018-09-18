---
title: ユニバーサル リソース識別子 (URI) リファレンス
assetID: cb7c6fe2-0376-dab4-9115-e4e3ebcfbd39
permalink: en-us/docs/xboxlive/rest/atoc-xboxlivews-reference-uris.html
author: KevinAsgari
description: " ユニバーサル リソース識別子 (URI) リファレンス"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2ff8e5444ec65de3665d593168e430a64f4d250e
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4024111"
---
# <a name="universal-resource-identifier-uri-reference"></a><span data-ttu-id="411cb-104">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="411cb-104">Universal Resource Identifier (URI) Reference</span></span>

<span data-ttu-id="411cb-105">このセクションでは、Uniform Resource Identifier (Uri) に関する詳細情報を提供し、および Xbox Live サービスで使用されるハイパー テキスト トランスポート プロトコル (HTTP) 方法。</span><span class="sxs-lookup"><span data-stu-id="411cb-105">This section provides detail about the Uniform Resource Identifiers (URIs) and and Hypertext Transport Protocol (HTTP) methods used with Xbox Live Services.</span></span>

<a id="ID4EAB"></a>


## <a name="in-this-section"></a><span data-ttu-id="411cb-106">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="411cb-106">In this section</span></span>

[<span data-ttu-id="411cb-107">実績 URI</span><span class="sxs-lookup"><span data-stu-id="411cb-107">Achievements URIs</span></span>](achievements/atoc-reference-achievementsv2.md)

<span data-ttu-id="411cb-108">&nbsp;&nbsp;Uri との実績に関連付けられている HTTP メソッドです。</span><span class="sxs-lookup"><span data-stu-id="411cb-108">&nbsp;&nbsp;URIs and associated HTTP methods for achievements.</span></span>

[<span data-ttu-id="411cb-109">ゲーム サーバー ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="411cb-109">Game Server Universal Resource Identifier (URI) Reference</span></span>](gsdk/atoc-gsdk-uri-reference.md)

<span data-ttu-id="411cb-110">&nbsp;&nbsp;Uri のクライアントで、タイトルのゲーム サーバー開発キット サーバーのインスタンスを作成するために使用します。</span><span class="sxs-lookup"><span data-stu-id="411cb-110">&nbsp;&nbsp;URIs used by clients to create Game Server Development Kit server instances for a title.</span></span>

[<span data-ttu-id="411cb-111">ゲーム DVR URI</span><span class="sxs-lookup"><span data-stu-id="411cb-111">Game DVR URIs</span></span>](dvr/atoc-reference-dvr.md)

<span data-ttu-id="411cb-112">&nbsp;&nbsp;Uri とゲーム DVR の HTTP メソッドが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="411cb-112">&nbsp;&nbsp;URIs and associated HTTP methods for game DVR.</span></span>

[<span data-ttu-id="411cb-113">ゲーマーアイコン URI</span><span class="sxs-lookup"><span data-stu-id="411cb-113">Gamerpic URIs</span></span>](gamerpic/atoc-reference-gamerpic.md)

<span data-ttu-id="411cb-114">&nbsp;&nbsp;Uri とタイトルによって生成された人々 に関連付けられている HTTP メソッドです。</span><span class="sxs-lookup"><span data-stu-id="411cb-114">&nbsp;&nbsp;URIs and associated HTTP methods for title-generated gamerpics.</span></span>

[<span data-ttu-id="411cb-115">ランキング URI</span><span class="sxs-lookup"><span data-stu-id="411cb-115">Leaderboards URIs</span></span>](leaderboard/atoc-reference-leaderboard.md)

<span data-ttu-id="411cb-116">&nbsp;&nbsp;Uri とランキングの HTTP メソッドが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="411cb-116">&nbsp;&nbsp;URIs and associated HTTP methods for leaderboards.</span></span>

[<span data-ttu-id="411cb-117">リスト URI</span><span class="sxs-lookup"><span data-stu-id="411cb-117">Lists URIs</span></span>](lists/atoc-reference-lists.md)

<span data-ttu-id="411cb-118">&nbsp;&nbsp;Uri とピンの HTTP メソッドが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="411cb-118">&nbsp;&nbsp;URIs and associated HTTP methods for PINs.</span></span>

[<span data-ttu-id="411cb-119">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="411cb-119">Marketplace URIs</span></span>](marketplace/atoc-reference-marketplace.md)

<span data-ttu-id="411cb-120">&nbsp;&nbsp;Uri と Xbox の市場のサービスの HTTP メソッドが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="411cb-120">&nbsp;&nbsp;URIs and associated HTTP methods for Xbox marketplace services.</span></span>

[<span data-ttu-id="411cb-121">マッチメイキング URI</span><span class="sxs-lookup"><span data-stu-id="411cb-121">Matchmaking URIs</span></span>](matchtickets/atoc-reference-matchtickets.md)

<span data-ttu-id="411cb-122">&nbsp;&nbsp;Uri とマッチメイ キングに関連付けられている HTTP/REST メソッドです。</span><span class="sxs-lookup"><span data-stu-id="411cb-122">&nbsp;&nbsp;URIs and associated HTTP/REST methods for matchmaking.</span></span>

[<span data-ttu-id="411cb-123">People URI</span><span class="sxs-lookup"><span data-stu-id="411cb-123">People URIs</span></span>](people/atoc-reference-people.md)

<span data-ttu-id="411cb-124">&nbsp;&nbsp;Uri と関連付けられている HTTP メソッド people システムです。</span><span class="sxs-lookup"><span data-stu-id="411cb-124">&nbsp;&nbsp;URIs and associated HTTP methods the people system.</span></span>

[<span data-ttu-id="411cb-125">プレゼンス URI</span><span class="sxs-lookup"><span data-stu-id="411cb-125">Presence URIs</span></span>](presence/atoc-reference-presence.md)

<span data-ttu-id="411cb-126">&nbsp;&nbsp;Uri とプレゼンスに関連する HTTP メソッドです。</span><span class="sxs-lookup"><span data-stu-id="411cb-126">&nbsp;&nbsp;URIs and associated HTTP methods for presence.</span></span>

[<span data-ttu-id="411cb-127">プライバシー URI</span><span class="sxs-lookup"><span data-stu-id="411cb-127">Privacy URIs</span></span>](privacy/atoc-reference-privacyv2.md)

<span data-ttu-id="411cb-128">&nbsp;&nbsp;Uri とプライバシーの HTTP メソッドが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="411cb-128">&nbsp;&nbsp;URIs and associated HTTP methods for privacy.</span></span>

[<span data-ttu-id="411cb-129">プロフィール URI</span><span class="sxs-lookup"><span data-stu-id="411cb-129">Profiles URIs</span></span>](profileV2/atoc-reference-profiles.md)

<span data-ttu-id="411cb-130">&nbsp;&nbsp;Uri とプロファイルの関連付けの HTTP メソッドです。</span><span class="sxs-lookup"><span data-stu-id="411cb-130">&nbsp;&nbsp;URIs and associated HTTP methods for profiles.</span></span>

[<span data-ttu-id="411cb-131">評判 URI</span><span class="sxs-lookup"><span data-stu-id="411cb-131">Reputation URIs</span></span>](reputation/atoc-reference-reputation.md)

<span data-ttu-id="411cb-132">&nbsp;&nbsp;Uri と評判サービスの HTTP メソッドが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="411cb-132">&nbsp;&nbsp;URIs and associated HTTP methods for the reputation service.</span></span>

[<span data-ttu-id="411cb-133">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="411cb-133">Session Directory URIs</span></span>](sessiondirectory/atoc-reference-sessiondirectory.md)

<span data-ttu-id="411cb-134">&nbsp;&nbsp;Uri と関連付けられている HTTP メソッドのマルチプレイヤー セッション ディレクトリ (MPSD)。</span><span class="sxs-lookup"><span data-stu-id="411cb-134">&nbsp;&nbsp;URIs and associated HTTP methods for Multiplayer Session Directory (MPSD).</span></span>

[<span data-ttu-id="411cb-135">実績タイトル履歴 URI</span><span class="sxs-lookup"><span data-stu-id="411cb-135">Achievement Title History URIs</span></span>](titlehistory/atoc-reference-titlehistoryv2.md)

<span data-ttu-id="411cb-136">&nbsp;&nbsp;Uri と*タイトルの履歴*の HTTP メソッドが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="411cb-136">&nbsp;&nbsp;URIs and associated HTTP methods for *title history*.</span></span>

[<span data-ttu-id="411cb-137">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="411cb-137">Title Storage URIs</span></span>](storage/atoc-reference-storagev2.md)

<span data-ttu-id="411cb-138">&nbsp;&nbsp;Uri とタイトル ストレージの HTTP メソッドが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="411cb-138">&nbsp;&nbsp;URIs and associated HTTP methods for title storage.</span></span>

[<span data-ttu-id="411cb-139">システム文字列の検証 URI</span><span class="sxs-lookup"><span data-stu-id="411cb-139">System Strings Validatation URIs</span></span>](stringserver/atoc-reference-systemstringsvalidate.md)

<span data-ttu-id="411cb-140">&nbsp;&nbsp;システム リソースの文字列の受け入れを検証します。</span><span class="sxs-lookup"><span data-stu-id="411cb-140">&nbsp;&nbsp;System resource to validate acceptance of strings on .</span></span>

[<span data-ttu-id="411cb-141">ユーザー URI</span><span class="sxs-lookup"><span data-stu-id="411cb-141">Users URIs</span></span>](users/atoc-reference-users.md)

<span data-ttu-id="411cb-142">&nbsp;&nbsp;Uri とユーザーの関連付けの HTTP メソッドです。</span><span class="sxs-lookup"><span data-stu-id="411cb-142">&nbsp;&nbsp;URIs and associated HTTP methods for users.</span></span>

[<span data-ttu-id="411cb-143">ユーザー統計 URI</span><span class="sxs-lookup"><span data-stu-id="411cb-143">User Statistics URIs</span></span>](userstats/atoc-reference-userstats.md)

<span data-ttu-id="411cb-144">&nbsp;&nbsp;Uri とユーザーの統計情報の HTTP メソッドが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="411cb-144">&nbsp;&nbsp;URIs and associated HTTP methods for user statistics.</span></span>

<a id="ID4E5C"></a>


## <a name="see-also"></a><span data-ttu-id="411cb-145">関連項目</span><span class="sxs-lookup"><span data-stu-id="411cb-145">See also</span></span>

<a id="ID4EAD"></a>


##### <a name="parent"></a><span data-ttu-id="411cb-146">Parent</span><span class="sxs-lookup"><span data-stu-id="411cb-146">Parent</span></span>

[<span data-ttu-id="411cb-147">Xbox Live サービス RESTful リファレンス</span><span class="sxs-lookup"><span data-stu-id="411cb-147">Xbox Live Services RESTful Reference</span></span>](../atoc-xboxlivews-reference.md)
