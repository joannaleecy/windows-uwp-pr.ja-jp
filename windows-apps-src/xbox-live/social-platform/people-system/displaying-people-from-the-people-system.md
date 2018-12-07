---
title: People システムからの人物の表示
description: Xbox Live People システムを使ってユーザーを表示するコード フローについて説明します。
ms.assetid: c97b699f-ebc2-4f65-8043-e99cca8cbe0c
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: 512de51f2a0e30a9b41a5e49f3dc3ababe30fc4d
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8755997"
---
# <a name="display-people-from-the-people-system"></a><span data-ttu-id="4c6b6-104">People システムからの人物の表示</span><span class="sxs-lookup"><span data-stu-id="4c6b6-104">Display People from the People System</span></span>

<span data-ttu-id="4c6b6-105">Xbox Live を横断するサービスは、そのサービスが保有するデータのみを返し、ユーザーへの XUID 参照のみを返します。たとえば People サービスは、ユーザーの People リストに存在する XUID と、それらの各 XUID に関する一部のごく基本的な情報 (お気に入りの状態など) のみを保有し、また返します。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-105">Services across Xbox Live return only data owned by that service and return only XUID references to users; for example, the People service only owns and returns the XUIDs that are on a user's People list and some very basic information about each of those XUIDs (such as favorite status).</span></span> <span data-ttu-id="4c6b6-106">プレゼンス サービスは XUID のオンライン状態情報に関するデータを保有します。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-106">The Presence service owns data about the online status information of XUIDs.</span></span> <span data-ttu-id="4c6b6-107">ランキング サービスは XUID のリストのランキング情報を保有します。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-107">The leaderboards service owns ranking information on lists of XUIDs.</span></span> <span data-ttu-id="4c6b6-108">表示名およびゲーマータグの情報はプロフィール サービス以外のどのサービスからも返されないので、エクスペリエンス内の人のリストを表示するには複数のサービスが必要です。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-108">Display name and gamertag information is never returned from any service other than the Profile service and, therefore, calling multiple services is necessary to render lists of people in experiences.</span></span>

<span data-ttu-id="4c6b6-109">サービス API の一般的な呼び出しパターンでは、1 回目のラウンド トリップで、リストの最適なフィルター処理または並べ替えを実行できるサービスから XUID のリストを最初に取得します。次に、各 XUID に必要な追加のメタデータを取得するために必要な他のサービスに対して同時にラウンド トリップ呼び出しを行います。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-109">The general calling pattern for the service APIs is to make one round trip to first obtain a list of XUIDs from the service that can best filter or sort the list, then make simultaneous round-trip calls to other services needed to obtain any additional metadata required for each XIUD.</span></span> <span data-ttu-id="4c6b6-110">画像の場合、画像の URL から画像を取得するために、3 回目のラウンド トリップ呼び出しが必要な場合があります。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-110">In the case of images, a third round trip of calls may be required to obtain images from the image URLs.</span></span>

<span data-ttu-id="4c6b6-111">ユーザーの People リストに関するデータの取得に必要なラウンド トリップ回数を減らすために、People *モニカー*が関連サービスに導入されつつあります。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-111">To reduce the number of round trips required to obtain data about a user's People list, a People *moniker* is being introduced to relevant services.</span></span> <span data-ttu-id="4c6b6-112">この新しい機能により、呼び出し元は、ユーザーの People のリストを People サービスから取得すること、また、戻り値のスコープを設定するためにその XUID のセットを使用することをプライマリー サービスに対して抽象的に表明することができます。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-112">This new feature allows callers to abstractly express to the primary service that the service should obtain the list of the user's People from the People service, and then use that set of XUIDs to scope the return.</span></span>

<span data-ttu-id="4c6b6-113">以下に、タイトルで People 関連のサービスからデータを取得する方法を示す呼び出しフローのシナリオをいくつか例示します。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-113">Following are some example call flow scenarios that illustrate how titles obtain data from services related to People:</span></span>

-   <span data-ttu-id="4c6b6-114">ゲームに参加中のユーザーのリスト</span><span class="sxs-lookup"><span data-stu-id="4c6b6-114">List of users currently in game</span></span>
-   <span data-ttu-id="4c6b6-115">現在のユーザーの People に含まれるオンライン ユーザーのリスト</span><span class="sxs-lookup"><span data-stu-id="4c6b6-115">List of the current user's People who are online</span></span>
-   <span data-ttu-id="4c6b6-116">ランダムなユーザーを含むグローバル ランキング</span><span class="sxs-lookup"><span data-stu-id="4c6b6-116">Global Leaderboard containing random users</span></span>
-   <span data-ttu-id="4c6b6-117">ユーザーの People のランキング</span><span class="sxs-lookup"><span data-stu-id="4c6b6-117">Leaderboard of user's People</span></span>


## <a name="list-of-users-currently-in-game"></a><span data-ttu-id="4c6b6-118">ゲームに参加中のユーザーのリスト</span><span class="sxs-lookup"><span data-stu-id="4c6b6-118">List of users currently in game</span></span>

| <span data-ttu-id="4c6b6-119">タイトルが保持しているもの</span><span class="sxs-lookup"><span data-stu-id="4c6b6-119">Title has</span></span>  | <span data-ttu-id="4c6b6-120">目標</span><span class="sxs-lookup"><span data-stu-id="4c6b6-120">Goal</span></span>  | <span data-ttu-id="4c6b6-121">表示するフィールド</span><span class="sxs-lookup"><span data-stu-id="4c6b6-121">Field to render</span></span>  | <span data-ttu-id="4c6b6-122">呼び出しフロー</span><span class="sxs-lookup"><span data-stu-id="4c6b6-122">Call flow</span></span>
|-------------------------------------------------|----------------------------------------------------|--------------------|--------------------------------------|
| <span data-ttu-id="4c6b6-123">ゲームに参加している他のユーザーのランダムな XUID のリスト</span><span class="sxs-lookup"><span data-stu-id="4c6b6-123">List of random XUIDs of other users in the game</span></span> | <span data-ttu-id="4c6b6-124">他の各ユーザーについて最小限の情報を表示する</span><span class="sxs-lookup"><span data-stu-id="4c6b6-124">To render minimal info for each of the other users</span></span> | <span data-ttu-id="4c6b6-125">GameDisplayName  \[プロフィール\]</span><span class="sxs-lookup"><span data-stu-id="4c6b6-125">GameDisplayName  \[Profile\]</span></span> | <span data-ttu-id="4c6b6-126">XUID のリストを使用してプロフィールを呼び出す。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-126">Call Profile with the list of XUIDs.</span></span> |


## <a name="list-of-the-current-users-people-who-are-online"></a><span data-ttu-id="4c6b6-127">現在のユーザーの People に含まれるオンライン ユーザーのリスト</span><span class="sxs-lookup"><span data-stu-id="4c6b6-127">List of the current user's People who are online</span></span>

## <a name="title-has"></a><span data-ttu-id="4c6b6-128">タイトルが保持しているもの:</span><span class="sxs-lookup"><span data-stu-id="4c6b6-128">Title has:</span></span>
<span data-ttu-id="4c6b6-129">現在のユーザーの XUID</span><span class="sxs-lookup"><span data-stu-id="4c6b6-129">The current user's XUID</span></span>

## <a name="goal"></a><span data-ttu-id="4c6b6-130">目標</span><span class="sxs-lookup"><span data-stu-id="4c6b6-130">Goal</span></span>
<span data-ttu-id="4c6b6-131">現在のユーザーの People リストに含まれているオンライン ユーザーのリッチ リストを表示する</span><span class="sxs-lookup"><span data-stu-id="4c6b6-131">To render rich list of online users that are in the current user's people list</span></span>

## <a name="field-to-render-owning-service"></a><span data-ttu-id="4c6b6-132">表示するフィールド \[保有するサービス\]</span><span class="sxs-lookup"><span data-stu-id="4c6b6-132">Field to render \[owning service\]</span></span>
* <span data-ttu-id="4c6b6-133">お気に入りインジケーター [People]</span><span class="sxs-lookup"><span data-stu-id="4c6b6-133">Favorite indicator [People]</span></span>
* <span data-ttu-id="4c6b6-134">表示用画像 [プロフィール]</span><span class="sxs-lookup"><span data-stu-id="4c6b6-134">Display picture [Profile]</span></span>
* <span data-ttu-id="4c6b6-135">GameDisplayName [プロフィール]</span><span class="sxs-lookup"><span data-stu-id="4c6b6-135">GameDisplayName [Profile]</span></span>
* <span data-ttu-id="4c6b6-136">基本オンライン状態 (緑のボール) [プレゼンス]</span><span class="sxs-lookup"><span data-stu-id="4c6b6-136">Basic online status (green ball) [Presence]</span></span>

## <a name="call-flow"></a><span data-ttu-id="4c6b6-137">呼び出しフロー</span><span class="sxs-lookup"><span data-stu-id="4c6b6-137">Call flow</span></span>
1. <span data-ttu-id="4c6b6-138">People モニカーを渡してプレゼンスを呼び出し、ユーザーの People に含まれる各ユーザーの XUID とオンライン状態を取得する。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-138">Call Presence, passing in the People moniker to get the XUIDs and online status for each of the user's People.</span></span>
1. <span data-ttu-id="4c6b6-139">並行して:</span><span class="sxs-lookup"><span data-stu-id="4c6b6-139">In parallel:</span></span>
 1. <span data-ttu-id="4c6b6-140">XUID のリスト全体を渡してプロフィールを呼び出し、各ユーザーの表示名と画像 URL を取得する。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-140">Call Profile, passing in the entire list of XUIDs to get the display name and picture URL for each.</span></span>
 1. <span data-ttu-id="4c6b6-141">XUID のリストを渡して People を呼び出し、ユーザーのお気に入りがいるかどうか調べる。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-141">Call People, passing in the list of XUIDs to find out if any are favorites of the user.</span></span>
1. <span data-ttu-id="4c6b6-142">プロフィールの呼び出し後:</span><span class="sxs-lookup"><span data-stu-id="4c6b6-142">After calling Profile:</span></span>
 1. <span data-ttu-id="4c6b6-143">各画像 URL の画像を取得する。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-143">Get images for each picture URL</span></span>

## <a name="global-leaderboard-containing-random-users"></a><span data-ttu-id="4c6b6-144">ランダムなユーザーを含むグローバル ランキング</span><span class="sxs-lookup"><span data-stu-id="4c6b6-144">Global Leaderboard containing random users</span></span>

## <a name="title-has"></a><span data-ttu-id="4c6b6-145">タイトルが保持しているもの:</span><span class="sxs-lookup"><span data-stu-id="4c6b6-145">Title has:</span></span>
<span data-ttu-id="4c6b6-146">ランキングの ID/名前</span><span class="sxs-lookup"><span data-stu-id="4c6b6-146">The ID/name of the leaderboard</span></span>

## <a name="goal"></a><span data-ttu-id="4c6b6-147">目標</span><span class="sxs-lookup"><span data-stu-id="4c6b6-147">Goal</span></span>
<span data-ttu-id="4c6b6-148">ランキング上の各ユーザーの基本情報を表示する</span><span class="sxs-lookup"><span data-stu-id="4c6b6-148">To render basic info for each user on the leaderboard</span></span>

## <a name="field-to-render-owning-service"></a><span data-ttu-id="4c6b6-149">表示するフィールド [保有するサービス]</span><span class="sxs-lookup"><span data-stu-id="4c6b6-149">Field to render [owning service]</span></span>
* <span data-ttu-id="4c6b6-150">お気に入りインジケーター [People]</span><span class="sxs-lookup"><span data-stu-id="4c6b6-150">Favorite indicator [People]</span></span>
* <span data-ttu-id="4c6b6-151">GameDisplayName [プロフィール]</span><span class="sxs-lookup"><span data-stu-id="4c6b6-151">GameDisplayName [Profile]</span></span>
* <span data-ttu-id="4c6b6-152">ランク [ランキング]</span><span class="sxs-lookup"><span data-stu-id="4c6b6-152">Rank [Leaderboards]</span></span>
* <span data-ttu-id="4c6b6-153">スコア [ランキング]</span><span class="sxs-lookup"><span data-stu-id="4c6b6-153">Score [Leaderboards]</span></span>

## <a name="call-flow"></a><span data-ttu-id="4c6b6-154">呼び出しフロー</span><span class="sxs-lookup"><span data-stu-id="4c6b6-154">Call Flow</span></span>
1. <span data-ttu-id="4c6b6-155">ランキングを呼び出して特定のランキングの XUID、ランク、スコアを取得する。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-155">Call Leaderboards to get the XUIDs, rank, and scores for the particular leaderboard.</span></span>
1. <span data-ttu-id="4c6b6-156">並行して:</span><span class="sxs-lookup"><span data-stu-id="4c6b6-156">In parallel:</span></span>
 1. <span data-ttu-id="4c6b6-157">XUID のリストを渡してプロフィールを呼び出し、各ユーザーの表示名と画像 URL を取得する。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-157">Call Profile, passing in the list of XUIDs to get the display name and picture URL for each.</span></span>
 1. <span data-ttu-id="4c6b6-158">XUID のリストを渡して People を呼び出し、ユーザーのお気に入りがいるかどうか調べる。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-158">Call People, passing in the list of XUIDs to find out if any are favorites of the user.</span></span>

## <a name="leaderboard-of-users-people"></a><span data-ttu-id="4c6b6-159">ユーザーの People のランキング</span><span class="sxs-lookup"><span data-stu-id="4c6b6-159">Leaderboard of user's People</span></span>

## <a name="title-has"></a><span data-ttu-id="4c6b6-160">タイトルが保持しているもの:</span><span class="sxs-lookup"><span data-stu-id="4c6b6-160">Title has:</span></span>
* <span data-ttu-id="4c6b6-161">ランキングの ID/名前</span><span class="sxs-lookup"><span data-stu-id="4c6b6-161">The ID/name of the leaderboard</span></span>
* <span data-ttu-id="4c6b6-162">現在のユーザーの XUID</span><span class="sxs-lookup"><span data-stu-id="4c6b6-162">The current user's XUID</span></span>

## <a name="goal"></a><span data-ttu-id="4c6b6-163">目標</span><span class="sxs-lookup"><span data-stu-id="4c6b6-163">Goal</span></span>
<span data-ttu-id="4c6b6-164">ランキング上の各ユーザーの基本情報を表示する</span><span class="sxs-lookup"><span data-stu-id="4c6b6-164">To render basic info for each user on the leaderboard</span></span>

## <a name="field-to-render-owning-service"></a><span data-ttu-id="4c6b6-165">表示するフィールド [保有するサービス]</span><span class="sxs-lookup"><span data-stu-id="4c6b6-165">Field to render [owning service]</span></span>
* <span data-ttu-id="4c6b6-166">お気に入りインジケーター [People]</span><span class="sxs-lookup"><span data-stu-id="4c6b6-166">Favorite indicator [People]</span></span>
* <span data-ttu-id="4c6b6-167">GameDisplayName [プロフィール]</span><span class="sxs-lookup"><span data-stu-id="4c6b6-167">GameDisplayName [Profile]</span></span>
* <span data-ttu-id="4c6b6-168">ランク [ランキング]</span><span class="sxs-lookup"><span data-stu-id="4c6b6-168">Rank [Leaderboards]</span></span>
* <span data-ttu-id="4c6b6-169">スコア [ランキング]</span><span class="sxs-lookup"><span data-stu-id="4c6b6-169">Score [Leaderboards]</span></span>

## <a name="call-flow"></a><span data-ttu-id="4c6b6-170">呼び出しフロー</span><span class="sxs-lookup"><span data-stu-id="4c6b6-170">Call Flow</span></span>
1. <span data-ttu-id="4c6b6-171">People モニカーを渡してランキングを呼び出し、ユーザーの People リストに限定した特定のランキングの XUID、ランク、スコアを取得する。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-171">Call Leaderboards, passing in the People moniker to get the XUIDs, rank, and scores for the particular leaderboard limited to the user's People list.</span></span>
1. <span data-ttu-id="4c6b6-172">並行して:</span><span class="sxs-lookup"><span data-stu-id="4c6b6-172">In parallel:</span></span>
 1. <span data-ttu-id="4c6b6-173">XUID のリストを渡してプロフィールを呼び出し、各ユーザーの表示名と画像 URL を取得する。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-173">Call Profile, passing in the list of XUIDs to get the display name and picture URL for each.</span></span>
 1. <span data-ttu-id="4c6b6-174">XUID のリストを渡して People を呼び出し、ユーザーのお気に入りがいるかどうか調べる。</span><span class="sxs-lookup"><span data-stu-id="4c6b6-174">Call People, passing in the list of XUIDs to find out if any are favorites of the user.</span></span>
