---
title: ユニバーサル リソース識別子 (URI) の参照
assetID: cb7c6fe2-0376-dab4-9115-e4e3ebcfbd39
permalink: en-us/docs/xboxlive/rest/atoc-xboxlivews-reference-uris.html
author: KevinAsgari
description: " ユニバーサル リソース識別子 (URI) の参照"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2ff8e5444ec65de3665d593168e430a64f4d250e
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882261"
---
# <a name="universal-resource-identifier-uri-reference"></a><span data-ttu-id="5d2f8-104">ユニバーサル リソース識別子 (URI) の参照</span><span class="sxs-lookup"><span data-stu-id="5d2f8-104">Universal Resource Identifier (URI) Reference</span></span>

<span data-ttu-id="5d2f8-105">ここでは、Uniform Resource Identifier (Uri) に関する詳細と、Xbox Live サービスで使用されるハイパー テキスト トランスポート プロトコル (HTTP) 方法。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-105">This section provides detail about the Uniform Resource Identifiers (URIs) and and Hypertext Transport Protocol (HTTP) methods used with Xbox Live Services.</span></span>

<a id="ID4EAB"></a>


## <a name="in-this-section"></a><span data-ttu-id="5d2f8-106">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="5d2f8-106">In this section</span></span>

[<span data-ttu-id="5d2f8-107">実績 Uri</span><span class="sxs-lookup"><span data-stu-id="5d2f8-107">Achievements URIs</span></span>](achievements/atoc-reference-achievementsv2.md)

<span data-ttu-id="5d2f8-108">&nbsp;&nbsp;Uri との実績に関連付けられている HTTP メソッド。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-108">&nbsp;&nbsp;URIs and associated HTTP methods for achievements.</span></span>

[<span data-ttu-id="5d2f8-109">ゲーム サーバー ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="5d2f8-109">Game Server Universal Resource Identifier (URI) Reference</span></span>](gsdk/atoc-gsdk-uri-reference.md)

<span data-ttu-id="5d2f8-110">&nbsp;&nbsp;Uri がクライアントで、タイトルのゲーム サーバー開発キット サーバーのインスタンスを作成するために使用します。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-110">&nbsp;&nbsp;URIs used by clients to create Game Server Development Kit server instances for a title.</span></span>

[<span data-ttu-id="5d2f8-111">ゲーム DVR Uri</span><span class="sxs-lookup"><span data-stu-id="5d2f8-111">Game DVR URIs</span></span>](dvr/atoc-reference-dvr.md)

<span data-ttu-id="5d2f8-112">&nbsp;&nbsp;Uri とゲーム DVR の HTTP メソッドが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-112">&nbsp;&nbsp;URIs and associated HTTP methods for game DVR.</span></span>

[<span data-ttu-id="5d2f8-113">ゲーマー アイコン Uri</span><span class="sxs-lookup"><span data-stu-id="5d2f8-113">Gamerpic URIs</span></span>](gamerpic/atoc-reference-gamerpic.md)

<span data-ttu-id="5d2f8-114">&nbsp;&nbsp;Uri とタイトルによって生成された人々 に関連付けられている HTTP メソッド。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-114">&nbsp;&nbsp;URIs and associated HTTP methods for title-generated gamerpics.</span></span>

[<span data-ttu-id="5d2f8-115">ランキングの Uri</span><span class="sxs-lookup"><span data-stu-id="5d2f8-115">Leaderboards URIs</span></span>](leaderboard/atoc-reference-leaderboard.md)

<span data-ttu-id="5d2f8-116">&nbsp;&nbsp;Uri とランキングの HTTP メソッドが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-116">&nbsp;&nbsp;URIs and associated HTTP methods for leaderboards.</span></span>

[<span data-ttu-id="5d2f8-117">Uri が一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-117">Lists URIs</span></span>](lists/atoc-reference-lists.md)

<span data-ttu-id="5d2f8-118">&nbsp;&nbsp;Uri とピンの HTTP メソッドが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-118">&nbsp;&nbsp;URIs and associated HTTP methods for PINs.</span></span>

[<span data-ttu-id="5d2f8-119">Marketplace Uri</span><span class="sxs-lookup"><span data-stu-id="5d2f8-119">Marketplace URIs</span></span>](marketplace/atoc-reference-marketplace.md)

<span data-ttu-id="5d2f8-120">&nbsp;&nbsp;Uri と Xbox の市場のサービスの HTTP メソッドが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-120">&nbsp;&nbsp;URIs and associated HTTP methods for Xbox marketplace services.</span></span>

[<span data-ttu-id="5d2f8-121">マッチメイ キング Uri</span><span class="sxs-lookup"><span data-stu-id="5d2f8-121">Matchmaking URIs</span></span>](matchtickets/atoc-reference-matchtickets.md)

<span data-ttu-id="5d2f8-122">&nbsp;&nbsp;Uri とマッチメイ キング用の関連の HTTP/REST メソッドです。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-122">&nbsp;&nbsp;URIs and associated HTTP/REST methods for matchmaking.</span></span>

[<span data-ttu-id="5d2f8-123">ユーザーの Uri</span><span class="sxs-lookup"><span data-stu-id="5d2f8-123">People URIs</span></span>](people/atoc-reference-people.md)

<span data-ttu-id="5d2f8-124">&nbsp;&nbsp;Uri と関連付けられている HTTP メソッド people システム。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-124">&nbsp;&nbsp;URIs and associated HTTP methods the people system.</span></span>

[<span data-ttu-id="5d2f8-125">プレゼンス Uri</span><span class="sxs-lookup"><span data-stu-id="5d2f8-125">Presence URIs</span></span>](presence/atoc-reference-presence.md)

<span data-ttu-id="5d2f8-126">&nbsp;&nbsp;Uri とプレゼンスの HTTP メソッドが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-126">&nbsp;&nbsp;URIs and associated HTTP methods for presence.</span></span>

[<span data-ttu-id="5d2f8-127">プライバシー Uri</span><span class="sxs-lookup"><span data-stu-id="5d2f8-127">Privacy URIs</span></span>](privacy/atoc-reference-privacyv2.md)

<span data-ttu-id="5d2f8-128">&nbsp;&nbsp;Uri とプライバシーの HTTP メソッドが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-128">&nbsp;&nbsp;URIs and associated HTTP methods for privacy.</span></span>

[<span data-ttu-id="5d2f8-129">プロファイルの Uri</span><span class="sxs-lookup"><span data-stu-id="5d2f8-129">Profiles URIs</span></span>](profileV2/atoc-reference-profiles.md)

<span data-ttu-id="5d2f8-130">&nbsp;&nbsp;Uri とプロファイルの関連付けの HTTP メソッドです。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-130">&nbsp;&nbsp;URIs and associated HTTP methods for profiles.</span></span>

[<span data-ttu-id="5d2f8-131">評判 Uri</span><span class="sxs-lookup"><span data-stu-id="5d2f8-131">Reputation URIs</span></span>](reputation/atoc-reference-reputation.md)

<span data-ttu-id="5d2f8-132">&nbsp;&nbsp;Uri と評判サービスの HTTP メソッドが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-132">&nbsp;&nbsp;URIs and associated HTTP methods for the reputation service.</span></span>

[<span data-ttu-id="5d2f8-133">セッション ディレクトリ Uri</span><span class="sxs-lookup"><span data-stu-id="5d2f8-133">Session Directory URIs</span></span>](sessiondirectory/atoc-reference-sessiondirectory.md)

<span data-ttu-id="5d2f8-134">&nbsp;&nbsp;Uri と関連付けられている HTTP メソッドのマルチプレイヤー セッション ディレクトリ (MPSD)。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-134">&nbsp;&nbsp;URIs and associated HTTP methods for Multiplayer Session Directory (MPSD).</span></span>

[<span data-ttu-id="5d2f8-135">実績タイトル履歴 Uri</span><span class="sxs-lookup"><span data-stu-id="5d2f8-135">Achievement Title History URIs</span></span>](titlehistory/atoc-reference-titlehistoryv2.md)

<span data-ttu-id="5d2f8-136">&nbsp;&nbsp;Uri と*タイトルの履歴*の HTTP メソッドが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-136">&nbsp;&nbsp;URIs and associated HTTP methods for *title history*.</span></span>

[<span data-ttu-id="5d2f8-137">タイトル ストレージ Uri</span><span class="sxs-lookup"><span data-stu-id="5d2f8-137">Title Storage URIs</span></span>](storage/atoc-reference-storagev2.md)

<span data-ttu-id="5d2f8-138">&nbsp;&nbsp;Uri とタイトル ストレージの HTTP メソッドが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-138">&nbsp;&nbsp;URIs and associated HTTP methods for title storage.</span></span>

[<span data-ttu-id="5d2f8-139">システムが Validatation Uri を示す文字列します。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-139">System Strings Validatation URIs</span></span>](stringserver/atoc-reference-systemstringsvalidate.md)

<span data-ttu-id="5d2f8-140">&nbsp;&nbsp;システム リソースの文字列の受け入れを検証します。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-140">&nbsp;&nbsp;System resource to validate acceptance of strings on .</span></span>

[<span data-ttu-id="5d2f8-141">ユーザーの Uri</span><span class="sxs-lookup"><span data-stu-id="5d2f8-141">Users URIs</span></span>](users/atoc-reference-users.md)

<span data-ttu-id="5d2f8-142">&nbsp;&nbsp;Uri とユーザーの関連付けの HTTP メソッドです。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-142">&nbsp;&nbsp;URIs and associated HTTP methods for users.</span></span>

[<span data-ttu-id="5d2f8-143">ユーザーの統計情報の Uri</span><span class="sxs-lookup"><span data-stu-id="5d2f8-143">User Statistics URIs</span></span>](userstats/atoc-reference-userstats.md)

<span data-ttu-id="5d2f8-144">&nbsp;&nbsp;Uri とユーザーの統計情報の関連付けの HTTP メソッドです。</span><span class="sxs-lookup"><span data-stu-id="5d2f8-144">&nbsp;&nbsp;URIs and associated HTTP methods for user statistics.</span></span>

<a id="ID4E5C"></a>


## <a name="see-also"></a><span data-ttu-id="5d2f8-145">関連項目</span><span class="sxs-lookup"><span data-stu-id="5d2f8-145">See also</span></span>

<a id="ID4EAD"></a>


##### <a name="parent"></a><span data-ttu-id="5d2f8-146">Parent</span><span class="sxs-lookup"><span data-stu-id="5d2f8-146">Parent</span></span>

[<span data-ttu-id="5d2f8-147">Xbox Live サービス RESTful リファレンス</span><span class="sxs-lookup"><span data-stu-id="5d2f8-147">Xbox Live Services RESTful Reference</span></span>](../atoc-xboxlivews-reference.md)
