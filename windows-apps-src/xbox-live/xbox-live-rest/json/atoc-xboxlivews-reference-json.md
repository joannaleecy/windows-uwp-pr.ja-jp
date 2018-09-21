---
title: JavaScript Object Notation (JSON) オブジェクト リファレンス
assetID: 8efcc6f3-d88a-1b15-bcfc-d79a24581b0a
permalink: en-us/docs/xboxlive/rest/atoc-xboxlivews-reference-json.html
author: KevinAsgari
description: " JavaScript Object Notation (JSON) オブジェクト リファレンス"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e65936d20923ecbdc2d9cfb0a0ec52bb7504b885
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4082738"
---
# <a name="javascript-object-notation-json-object-reference"></a><span data-ttu-id="852e2-104">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="852e2-104">JavaScript Object Notation (JSON) Object Reference</span></span>
 
<span data-ttu-id="852e2-105">JavaScript Object Notation (JSON) では、web 上のデータをカプセル化するための軽量な標準ベース、オブジェクト指向の表記です。</span><span class="sxs-lookup"><span data-stu-id="852e2-105">JavaScript Object Notation (JSON) is a lightweight, standards-based, object-oriented notation for encapsulating data on the web.</span></span>
 
<span data-ttu-id="852e2-106">Xbox Live サービスは、要求をし、サービスからの応答で使われる JSON オブジェクトを定義します。</span><span class="sxs-lookup"><span data-stu-id="852e2-106">Xbox Live Services defines JSON objects that are used in requests to, and responses from, the service.</span></span> <span data-ttu-id="852e2-107">このセクションでは、Xbox Live サービスで使用される各 JSON オブジェクトについての参照を説明します。</span><span class="sxs-lookup"><span data-stu-id="852e2-107">This section provides reference information about each JSON object used with Xbox Live Services.</span></span>
 
<a id="ID4EHB"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="852e2-108">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="852e2-108">In this section</span></span>

[<span data-ttu-id="852e2-109">Achievement (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-109">Achievement (JSON)</span></span>](json-achievementv2.md)

<span data-ttu-id="852e2-110">&nbsp;&nbsp;実績オブジェクト (バージョン 2)。</span><span class="sxs-lookup"><span data-stu-id="852e2-110">&nbsp;&nbsp;An Achievement object (version 2).</span></span>

[<span data-ttu-id="852e2-111">ActivityRecord (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-111">ActivityRecord (JSON)</span></span>](json-activityrecord.md)

<span data-ttu-id="852e2-112">&nbsp;&nbsp;1 つまたは複数のユーザーのリッチ プレゼンスの書式設定されたとローカライズされた文字列です。</span><span class="sxs-lookup"><span data-stu-id="852e2-112">&nbsp;&nbsp;A formatted and localized string about one or more users' rich presence.</span></span>

[<span data-ttu-id="852e2-113">ActivityRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-113">ActivityRequest (JSON)</span></span>](json-activityrequest.md)

<span data-ttu-id="852e2-114">&nbsp;&nbsp;1 つまたは複数のユーザーのリッチ プレゼンスに関する情報を要求します。</span><span class="sxs-lookup"><span data-stu-id="852e2-114">&nbsp;&nbsp;A request for information about one or more users' rich presence.</span></span>

[<span data-ttu-id="852e2-115">AggregateSessionsResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-115">AggregateSessionsResponse (JSON)</span></span>](json-aggregatesessionsresponse.md)

<span data-ttu-id="852e2-116">&nbsp;&nbsp;ユーザーの適合性のセッションの集計データが含まれています。</span><span class="sxs-lookup"><span data-stu-id="852e2-116">&nbsp;&nbsp;Contains aggregated data for a user's fitness sessions.</span></span>

[<span data-ttu-id="852e2-117">BatchRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-117">BatchRequest (JSON)</span></span>](json-batchrequest.md)

<span data-ttu-id="852e2-118">&nbsp;&nbsp;ユーザー、デバイス、およびタイトルなどのプレゼンス情報をフィルター処理するためのプロパティの配列です。</span><span class="sxs-lookup"><span data-stu-id="852e2-118">&nbsp;&nbsp;An array of properties with which to filter presence information, such as users, devices, and titles.</span></span>

[<span data-ttu-id="852e2-119">DeviceEndpoint (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-119">DeviceEndpoint (JSON)</span></span>](json-deviceendpoint.md)

[<span data-ttu-id="852e2-120">DeviceRecord (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-120">DeviceRecord (JSON)</span></span>](json-devicerecord.md)

<span data-ttu-id="852e2-121">&nbsp;&nbsp;その型とそれに対するアクティブなタイトルを含む、デバイスに関する情報。</span><span class="sxs-lookup"><span data-stu-id="852e2-121">&nbsp;&nbsp;Information about a device, including its type and the titles active on it.</span></span>

[<span data-ttu-id="852e2-122">Feedback (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-122">Feedback (JSON)</span></span>](json-feedback.md)

<span data-ttu-id="852e2-123">&nbsp;&nbsp;プレイヤーに関するフィードバックの情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="852e2-123">&nbsp;&nbsp;Contains feedback information about a player.</span></span>

[<span data-ttu-id="852e2-124">GameClip (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-124">GameClip (JSON)</span></span>](json-gameclip.md)

[<span data-ttu-id="852e2-125">GameClipsServiceErrorResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-125">GameClipsServiceErrorResponse (JSON)</span></span>](json-gameclipsserviceerrorresponse.md)

<span data-ttu-id="852e2-126">&nbsp;&nbsp;/Users/{ownerId} {scid}/scids//clips/{gameClipId} への応答の省略可能な部分/uri 形式/{gameClipUriType} API です。</span><span class="sxs-lookup"><span data-stu-id="852e2-126">&nbsp;&nbsp;An optional part of the response to the /users/{ownerId}/scids/{scid}/clips/{gameClipId}/uris/format/{gameClipUriType} API.</span></span>

[<span data-ttu-id="852e2-127">GameClipThumbnail (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-127">GameClipThumbnail (JSON)</span></span>](json-gameclipthumbnail.md)

<span data-ttu-id="852e2-128">&nbsp;&nbsp;個々 のサムネイルに関連する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="852e2-128">&nbsp;&nbsp;Contains the information related to an individual thumbnail.</span></span> <span data-ttu-id="852e2-129">1 つのクリップを複数のサイズが存在することができ、表示用の適切なものを選択するクライアントがします。</span><span class="sxs-lookup"><span data-stu-id="852e2-129">There can be multiple sizes per clip, and it is up to the client to select the proper one for display.</span></span>

[<span data-ttu-id="852e2-130">GameClipUri (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-130">GameClipUri (JSON)</span></span>](json-gameclipuri.md)

[<span data-ttu-id="852e2-131">GameMessage (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-131">GameMessage (JSON)</span></span>](json-gamemessage.md)

<span data-ttu-id="852e2-132">&nbsp;&nbsp;ゲーム セッションのメッセージ キューにメッセージのデータを定義する JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="852e2-132">&nbsp;&nbsp;A JSON object defining data for a message in a game session's message queue.</span></span>

[<span data-ttu-id="852e2-133">GameResult (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-133">GameResult (JSON)</span></span>](json-gameresult.md)

<span data-ttu-id="852e2-134">&nbsp;&nbsp;ゲーム セッションの結果を示すデータを表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="852e2-134">&nbsp;&nbsp;A JSON object representing data that describes the results of a game session.</span></span>

[<span data-ttu-id="852e2-135">GameSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-135">GameSession (JSON)</span></span>](json-gamesession.md)

<span data-ttu-id="852e2-136">&nbsp;&nbsp;マルチプレイヤー セッションのゲーム データを表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="852e2-136">&nbsp;&nbsp;A JSON object representing game data for a multiplayer session.</span></span>

[<span data-ttu-id="852e2-137">GameSessionSummary (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-137">GameSessionSummary (JSON)</span></span>](json-gamesessionsummary.md)

<span data-ttu-id="852e2-138">&nbsp;&nbsp;ゲーム セッションの集計データを表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="852e2-138">&nbsp;&nbsp;A JSON object representing summary data for a game session.</span></span>

[<span data-ttu-id="852e2-139">GetClipResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-139">GetClipResponse (JSON)</span></span>](json-getclipresponse.md)

<span data-ttu-id="852e2-140">&nbsp;&nbsp;ゲーム クリップをラップします。</span><span class="sxs-lookup"><span data-stu-id="852e2-140">&nbsp;&nbsp;Wraps the game clip.</span></span>

[<span data-ttu-id="852e2-141">HopperStatsResults (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-141">HopperStatsResults (JSON)</span></span>](json-hopperstatsresults.md)

<span data-ttu-id="852e2-142">&nbsp;&nbsp;ホッパーの統計情報を表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="852e2-142">&nbsp;&nbsp;A JSON object representing the statistics for a hopper.</span></span>

[<span data-ttu-id="852e2-143">InitialUploadRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-143">InitialUploadRequest (JSON)</span></span>](json-initialuploadrequest.md)

<span data-ttu-id="852e2-144">&nbsp;&nbsp;POST ゲーム クリップだったの本文は、要求をアップロードします。</span><span class="sxs-lookup"><span data-stu-id="852e2-144">&nbsp;&nbsp;The body of a POST GameClip upload request.</span></span>

[<span data-ttu-id="852e2-145">InitialUploadResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-145">InitialUploadResponse (JSON)</span></span>](json-initialuploadresponse.md)

[<span data-ttu-id="852e2-146">inventoryItem (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-146">inventoryItem (JSON)</span></span>](json-inventoryitem.md)

<span data-ttu-id="852e2-147">&nbsp;&nbsp;コア インベントリ項目の権利を付与できる標準的な項目を表します。</span><span class="sxs-lookup"><span data-stu-id="852e2-147">&nbsp;&nbsp;The core inventory item represents the standard item on which an entitlement can be granted.</span></span>

[<span data-ttu-id="852e2-148">LastSeenRecord (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-148">LastSeenRecord (JSON)</span></span>](json-lastseenrecord.md)

<span data-ttu-id="852e2-149">&nbsp;&nbsp;ユーザーには、有効な DeviceRecord があるないときに利用可能なユーザーが最後システムに表示されていた場合について説明します。</span><span class="sxs-lookup"><span data-stu-id="852e2-149">&nbsp;&nbsp;Information about when the system last saw a user, available when the user has no valid DeviceRecord.</span></span>

[<span data-ttu-id="852e2-150">MatchTicket (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-150">MatchTicket (JSON)</span></span>](json-matchticket.md)

<span data-ttu-id="852e2-151">&nbsp;&nbsp;プレイヤーがマルチプレイヤー セッション ディレクトリ (MPSD) を通じて他のプレイヤーを検索に使用するマッチ チケットを表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="852e2-151">&nbsp;&nbsp;A JSON object representing a match ticket, used by players to locate other players through the multiplayer session directory (MPSD).</span></span>

[<span data-ttu-id="852e2-152">MediaAsset (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-152">MediaAsset (JSON)</span></span>](json-mediaasset.md)

<span data-ttu-id="852e2-153">&nbsp;&nbsp;実績やそのリワードに関連付けられているメディア アセット。</span><span class="sxs-lookup"><span data-stu-id="852e2-153">&nbsp;&nbsp;The media assets associated with the achievement or its rewards.</span></span>

[<span data-ttu-id="852e2-154">MediaRecord (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-154">MediaRecord (JSON)</span></span>](json-mediarecord.md)

[<span data-ttu-id="852e2-155">MediaRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-155">MediaRequest (JSON)</span></span>](json-mediarequest.md)

[<span data-ttu-id="852e2-156">MultiplayerActivityDetails (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-156">MultiplayerActivityDetails (JSON)</span></span>](json-multiplayeractivitydetails.md)

<span data-ttu-id="852e2-157">&nbsp;&nbsp;**Microsoft.Xbox.Services.Multiplayer.MultiplayerActivityDetails**を表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="852e2-157">&nbsp;&nbsp;A JSON object representing the **Microsoft.Xbox.Services.Multiplayer.MultiplayerActivityDetails**.</span></span>

[<span data-ttu-id="852e2-158">MultiplayerSessionReference (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-158">MultiplayerSessionReference (JSON)</span></span>](json-multiplayersessionreference.md)

<span data-ttu-id="852e2-159">&nbsp;&nbsp;**MultiplayerSessionReference**を表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="852e2-159">&nbsp;&nbsp;A JSON object representing the **MultiplayerSessionReference**.</span></span> 

[<span data-ttu-id="852e2-160">MultiplayerSessionRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-160">MultiplayerSessionRequest (JSON)</span></span>](json-multiplayersessionrequest.md)

<span data-ttu-id="852e2-161">&nbsp;&nbsp;**MultiplayerSession**オブジェクト上の操作に対して要求の JSON オブジェクトが渡されます。</span><span class="sxs-lookup"><span data-stu-id="852e2-161">&nbsp;&nbsp;The request JSON object passed for an operation on a **MultiplayerSession** object.</span></span>

[<span data-ttu-id="852e2-162">MultiplayerSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-162">MultiplayerSession (JSON)</span></span>](json-multiplayersession.md)

<span data-ttu-id="852e2-163">&nbsp;&nbsp;**MultiplayerSession**を表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="852e2-163">&nbsp;&nbsp;A JSON object representing the **MultiplayerSession**.</span></span> 

[<span data-ttu-id="852e2-164">PagingInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-164">PagingInfo (JSON)</span></span>](json-paginginfo.md)

<span data-ttu-id="852e2-165">&nbsp;&nbsp;データのページで返される結果のページング情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="852e2-165">&nbsp;&nbsp;Contains paging information for results that are returned in pages of data.</span></span>

[<span data-ttu-id="852e2-166">PeopleList (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-166">PeopleList (JSON)</span></span>](json-peoplelist.md)

<span data-ttu-id="852e2-167">&nbsp;&nbsp;[Person](json-person.md)オブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="852e2-167">&nbsp;&nbsp;Collection of [Person](json-person.md) objects.</span></span>

[<span data-ttu-id="852e2-168">PermissionCheckBatchRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-168">PermissionCheckBatchRequest (JSON)</span></span>](json-permissioncheckbatchrequest.md)

<span data-ttu-id="852e2-169">&nbsp;&nbsp;PermissionCheckBatchRequest オブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="852e2-169">&nbsp;&nbsp;Collection of PermissionCheckBatchRequest objects.</span></span>

[<span data-ttu-id="852e2-170">PermissionCheckBatchResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-170">PermissionCheckBatchResponse (JSON)</span></span>](json-permissioncheckbatchresponse.md)

<span data-ttu-id="852e2-171">&nbsp;&nbsp;バッチのアクセス許可の結果は、複数のユーザーのアクセス許可の値の一覧を確認します。</span><span class="sxs-lookup"><span data-stu-id="852e2-171">&nbsp;&nbsp;The results of a batch permission check for a list of permission values for multiple users.</span></span>

[<span data-ttu-id="852e2-172">PermissionCheckBatchUserResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-172">PermissionCheckBatchUserResponse (JSON)</span></span>](json-permissioncheckbatchuserresponse.md)

<span data-ttu-id="852e2-173">&nbsp;&nbsp;バッチのアクセス許可の理由は、1 つの対象ユーザーのアクセス権の値の一覧を確認します。</span><span class="sxs-lookup"><span data-stu-id="852e2-173">&nbsp;&nbsp;The reasons of a batch permission check for list of permission values for a single target user.</span></span>

[<span data-ttu-id="852e2-174">PermissionCheckResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-174">PermissionCheckResponse (JSON)</span></span>](json-permissioncheckresponse.md)

<span data-ttu-id="852e2-175">&nbsp;&nbsp;1 つの対象ユーザーに対して 1 つのアクセス許可の設定を 1 人のユーザーからチェックの結果。</span><span class="sxs-lookup"><span data-stu-id="852e2-175">&nbsp;&nbsp;The results of a check from a single user for a single permission setting against a single target user.</span></span>

[<span data-ttu-id="852e2-176">PermissionCheckResult (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-176">PermissionCheckResult (JSON)</span></span>](json-permissioncheckresult.md)

<span data-ttu-id="852e2-177">&nbsp;&nbsp;1 つの対象ユーザーに対して 1 つのアクセス許可の設定を 1 人のユーザーからチェックの結果。</span><span class="sxs-lookup"><span data-stu-id="852e2-177">&nbsp;&nbsp;The results of a check from a single user for a single permission setting against a single target user.</span></span>

[<span data-ttu-id="852e2-178">Person (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-178">Person (JSON)</span></span>](json-person.md)

<span data-ttu-id="852e2-179">&nbsp;&nbsp;People システムで 1 人のユーザーに関するメタデータ。</span><span class="sxs-lookup"><span data-stu-id="852e2-179">&nbsp;&nbsp;Metadata about a single Person in the People system.</span></span>

[<span data-ttu-id="852e2-180">PersonSummary (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-180">PersonSummary (JSON)</span></span>](json-personsummary.md)

<span data-ttu-id="852e2-181">&nbsp;&nbsp;[ユーザー (JSON)](json-person.md)オブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="852e2-181">&nbsp;&nbsp;Collection of [Person (JSON)](json-person.md) objects.</span></span>

[<span data-ttu-id="852e2-182">Player (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-182">Player (JSON)</span></span>](json-player.md)

<span data-ttu-id="852e2-183">&nbsp;&nbsp;ゲーム セッションにプレイヤーのデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="852e2-183">&nbsp;&nbsp;Contains data for a player in a game session.</span></span>

[<span data-ttu-id="852e2-184">PresenceRecord (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-184">PresenceRecord (JSON)</span></span>](json-presencerecord.md)

<span data-ttu-id="852e2-185">&nbsp;&nbsp;1 人のユーザーのオンライン プレゼンスに関するデータ。</span><span class="sxs-lookup"><span data-stu-id="852e2-185">&nbsp;&nbsp;Data about the online presence of a single user.</span></span>

[<span data-ttu-id="852e2-186">Profile (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-186">Profile (JSON)</span></span>](json-profile.md)

<span data-ttu-id="852e2-187">&nbsp;&nbsp;ユーザーの個人用プロファイル設定します。</span><span class="sxs-lookup"><span data-stu-id="852e2-187">&nbsp;&nbsp;The personal profile settings for a user.</span></span>

[<span data-ttu-id="852e2-188">Progression (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-188">Progression (JSON)</span></span>](json-progression.md)

<span data-ttu-id="852e2-189">&nbsp;&nbsp;実績をロック解除に向けたユーザーの進行します。</span><span class="sxs-lookup"><span data-stu-id="852e2-189">&nbsp;&nbsp;The user's progression toward unlocking the achievement.</span></span>

[<span data-ttu-id="852e2-190">Property (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-190">Property (JSON)</span></span>](json-property.md)

<span data-ttu-id="852e2-191">&nbsp;&nbsp;マッチメイ キング要求条件のクライアントによって提供されるプロパティのデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="852e2-191">&nbsp;&nbsp;Contains property data provided by the client for matchmaking request criteria.</span></span>

[<span data-ttu-id="852e2-192">QueryClipsResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-192">QueryClipsResponse (JSON)</span></span>](json-queryclipsresponse.md)

<span data-ttu-id="852e2-193">&nbsp;&nbsp;一覧のページング情報と共にゲーム クリップの戻り値の一覧をラップします。</span><span class="sxs-lookup"><span data-stu-id="852e2-193">&nbsp;&nbsp;Wraps the list of return game clips along with paging information for the list.</span></span>

[<span data-ttu-id="852e2-194">quotaInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-194">quotaInfo (JSON)</span></span>](json-quota.md)

<span data-ttu-id="852e2-195">&nbsp;&nbsp;クォータ タイトル グループについてを説明します。</span><span class="sxs-lookup"><span data-stu-id="852e2-195">&nbsp;&nbsp;Contains quota information about a title group.</span></span>

[<span data-ttu-id="852e2-196">Requirement (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-196">Requirement (JSON)</span></span>](json-requirement.md)

<span data-ttu-id="852e2-197">&nbsp;&nbsp;実績とそれらに対応するため、ユーザーは、どのくらいのロック解除条件。</span><span class="sxs-lookup"><span data-stu-id="852e2-197">&nbsp;&nbsp;The unlock criteria for the Achievement and how far the user is toward meeting them.</span></span>

[<span data-ttu-id="852e2-198">ResetReputation (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-198">ResetReputation (JSON)</span></span>](json-resetreputation.md)

<span data-ttu-id="852e2-199">&nbsp;&nbsp;ユーザーの既存のスコアを変更する必要があります新しい基本評判スコアが含まれています。</span><span class="sxs-lookup"><span data-stu-id="852e2-199">&nbsp;&nbsp;Contains the new base Reputation scores to which a user's existing scores should be changed.</span></span>

[<span data-ttu-id="852e2-200">Reward (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-200">Reward (JSON)</span></span>](json-reward.md)

<span data-ttu-id="852e2-201">&nbsp;&nbsp;実績に関連付けられているリワードです。</span><span class="sxs-lookup"><span data-stu-id="852e2-201">&nbsp;&nbsp;The reward associated with the achievement.</span></span>

[<span data-ttu-id="852e2-202">RichPresenceRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-202">RichPresenceRequest (JSON)</span></span>](json-richpresencerequest.md)

<span data-ttu-id="852e2-203">&nbsp;&nbsp;リッチ プレゼンス情報の使用に関する情報を要求します。</span><span class="sxs-lookup"><span data-stu-id="852e2-203">&nbsp;&nbsp;Request for information about which rich presence information should be used.</span></span>

[<span data-ttu-id="852e2-204">ServiceError (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-204">ServiceError (JSON)</span></span>](json-serviceerror.md)

<span data-ttu-id="852e2-205">&nbsp;&nbsp;サービスへの呼び出しが失敗したときに返されるエラーに関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="852e2-205">&nbsp;&nbsp;Contains information about an error returned when a call to the service failed.</span></span>

[<span data-ttu-id="852e2-206">ServiceErrorResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-206">ServiceErrorResponse (JSON)</span></span>](json-serviceerrorresponse.md)

<span data-ttu-id="852e2-207">&nbsp;&nbsp;サービスのエラーが発生したときは、適切な HTTP エラー コードが返されます。</span><span class="sxs-lookup"><span data-stu-id="852e2-207">&nbsp;&nbsp;When a service error is encountered, an appropriate HTTP error code will be returned.</span></span> <span data-ttu-id="852e2-208">必要に応じて、サービスもあります ServiceErrorResponse オブジェクトの下で定義されています。</span><span class="sxs-lookup"><span data-stu-id="852e2-208">Optionally, the service may also include a ServiceErrorResponse object as defined below.</span></span> <span data-ttu-id="852e2-209">運用環境での低いデータを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="852e2-209">In production environments, less data may be included.</span></span>

[<span data-ttu-id="852e2-210">SessionEntry (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-210">SessionEntry (JSON)</span></span>](json-sessionentry.md)

<span data-ttu-id="852e2-211">&nbsp;&nbsp;フィットネス セッションのデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="852e2-211">&nbsp;&nbsp;Contains data for a fitness session.</span></span>

[<span data-ttu-id="852e2-212">TitleAssociation (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-212">TitleAssociation (JSON)</span></span>](json-titleassociation.md)

<span data-ttu-id="852e2-213">&nbsp;&nbsp;実績に関連付けられているタイトルです。</span><span class="sxs-lookup"><span data-stu-id="852e2-213">&nbsp;&nbsp;A title that is associated with the achievement.</span></span>

[<span data-ttu-id="852e2-214">TitleBlob (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-214">TitleBlob (JSON)</span></span>](json-titleblob.md)

<span data-ttu-id="852e2-215">&nbsp;&nbsp;記憶域からタイトルに関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="852e2-215">&nbsp;&nbsp;Contains information about a title from storage.</span></span>

[<span data-ttu-id="852e2-216">TitleRecord (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-216">TitleRecord (JSON)</span></span>](json-titlerecord.md)

<span data-ttu-id="852e2-217">&nbsp;&nbsp;その名前と最終変更日のタイムスタンプを含む、タイトルに関する情報。</span><span class="sxs-lookup"><span data-stu-id="852e2-217">&nbsp;&nbsp;Information about a title, including its name and a last-modified timestamp.</span></span>

[<span data-ttu-id="852e2-218">TitleRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-218">TitleRequest (JSON)</span></span>](json-titlerequest.md)

<span data-ttu-id="852e2-219">&nbsp;&nbsp;タイトルに関する情報を要求します。</span><span class="sxs-lookup"><span data-stu-id="852e2-219">&nbsp;&nbsp;Request for information about a title.</span></span>

[<span data-ttu-id="852e2-220">UpdateMetadataRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-220">UpdateMetadataRequest (JSON)</span></span>](json-updatemetadatarequest.md)

<span data-ttu-id="852e2-221">&nbsp;&nbsp;このメタデータは、クリップを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="852e2-221">&nbsp;&nbsp;The metadata that should be updated for a clip.</span></span>

[<span data-ttu-id="852e2-222">User (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-222">User (JSON)</span></span>](json-user.md)

<span data-ttu-id="852e2-223">&nbsp;&nbsp;ユーザーのランキング データが含まれています。</span><span class="sxs-lookup"><span data-stu-id="852e2-223">&nbsp;&nbsp;Contains user leaderboard data.</span></span>

[<span data-ttu-id="852e2-224">UserClaims (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-224">UserClaims (JSON)</span></span>](json-userclaims.md)

<span data-ttu-id="852e2-225">&nbsp;&nbsp;現在の認証されたユーザーに関する情報を返します。</span><span class="sxs-lookup"><span data-stu-id="852e2-225">&nbsp;&nbsp;Returns information about the current authenticated user.</span></span>

[<span data-ttu-id="852e2-226">UserList (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-226">UserList (JSON)</span></span>](json-userlist.md)

<span data-ttu-id="852e2-227">&nbsp;&nbsp;[ユーザー](json-user.md)オブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="852e2-227">&nbsp;&nbsp;A collection of [User](json-user.md) objects.</span></span>

[<span data-ttu-id="852e2-228">UserSettings (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-228">UserSettings (JSON)</span></span>](json-usersettings.md)

<span data-ttu-id="852e2-229">&nbsp;&nbsp;現在の認証されたユーザーの設定を返します。</span><span class="sxs-lookup"><span data-stu-id="852e2-229">&nbsp;&nbsp;Returns settings for current authenticated user.</span></span>

[<span data-ttu-id="852e2-230">UserTitle (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-230">UserTitle (JSON)</span></span>](json-usertitlev2.md)

<span data-ttu-id="852e2-231">&nbsp;&nbsp;タイトルのユーザー データが含まれています。</span><span class="sxs-lookup"><span data-stu-id="852e2-231">&nbsp;&nbsp;Contains user title data.</span></span>

[<span data-ttu-id="852e2-232">VerifyStringResult (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-232">VerifyStringResult (JSON)</span></span>](json-verifystringresult.md)

<span data-ttu-id="852e2-233">&nbsp;&nbsp;[/System/strings/validate](../uri/stringserver/uri-systemstringsvalidate.md)に送信された各文字列に対応する結果コード。</span><span class="sxs-lookup"><span data-stu-id="852e2-233">&nbsp;&nbsp;Result codes corresponding to each string submitted to [/system/strings/validate](../uri/stringserver/uri-systemstringsvalidate.md).</span></span>

[<span data-ttu-id="852e2-234">XuidList (JSON)</span><span class="sxs-lookup"><span data-stu-id="852e2-234">XuidList (JSON)</span></span>](json-xuidlist.md)

<span data-ttu-id="852e2-235">&nbsp;&nbsp;操作を実行する Xuid のリスト。</span><span class="sxs-lookup"><span data-stu-id="852e2-235">&nbsp;&nbsp;List of XUIDs on which to perform an operation.</span></span>
 
<a id="ID4ENH"></a>

 
## <a name="see-also"></a><span data-ttu-id="852e2-236">関連項目</span><span class="sxs-lookup"><span data-stu-id="852e2-236">See also</span></span>
 
<a id="ID4EPH"></a>

 
##### <a name="parent"></a><span data-ttu-id="852e2-237">Parent</span><span class="sxs-lookup"><span data-stu-id="852e2-237">Parent</span></span> 

[<span data-ttu-id="852e2-238">Xbox Live サービス RESTful リファレンス</span><span class="sxs-lookup"><span data-stu-id="852e2-238">Xbox Live Services RESTful Reference</span></span>](../atoc-xboxlivews-reference.md)

  
<a id="ID4EZH"></a>

 
##### <a name="external-links-ecma-international-standard-262-ecmascript-language-specificationhttpwwwecma-internationalorgpublicationsfilesecma-stecma-262pdf"></a><span data-ttu-id="852e2-239">外部リンク[ECMA 国際標準 262: ECMAScript 言語仕様](http://www.ecma-international.org/publications/files/ECMA-ST/ECMA-262.pdf)</span><span class="sxs-lookup"><span data-stu-id="852e2-239">External links [ECMA International Standard 262: ECMAScript Language Specification](http://www.ecma-international.org/publications/files/ECMA-ST/ECMA-262.pdf)</span></span>

   