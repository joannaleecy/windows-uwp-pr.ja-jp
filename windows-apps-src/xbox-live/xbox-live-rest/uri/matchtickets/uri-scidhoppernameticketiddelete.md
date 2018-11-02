---
title: DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})
assetID: d9ff3f21-aa70-af41-afa1-9a9244fcdb95
permalink: en-us/docs/xboxlive/rest/uri-scidhoppernameticketiddelete.html
author: KevinAsgari
description: " DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7808b8dc9a8b83553ae6b09e7008fab238409958
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5936043"
---
# <a name="delete-serviceconfigsscidhoppershoppernameticketsticketid"></a><span data-ttu-id="8e68e-104">DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})</span><span class="sxs-lookup"><span data-stu-id="8e68e-104">DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})</span></span>

<span data-ttu-id="8e68e-105">マッチ チケットを削除します。</span><span class="sxs-lookup"><span data-stu-id="8e68e-105">Removes a match ticket.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="8e68e-106">このメソッドは、コントラクト 103 以降で使用するものでは、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 103 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="8e68e-106">This method is intended for use with contract 103 or later, and requires a header element of X-Xbl-Contract-Version: 103 or later on every request.</span></span>

  * [<span data-ttu-id="8e68e-107">注釈</span><span class="sxs-lookup"><span data-stu-id="8e68e-107">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="8e68e-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8e68e-108">URI parameters</span></span>](#ID4E2)
  * [<span data-ttu-id="8e68e-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="8e68e-109">Authorization</span></span>](#ID4EGB)
  * [<span data-ttu-id="8e68e-110">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="8e68e-110">HTTP status codes</span></span>](#ID4EOC)
  * [<span data-ttu-id="8e68e-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="8e68e-111">Request body</span></span>](#ID4EXC)
  * [<span data-ttu-id="8e68e-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="8e68e-112">Response body</span></span>](#ID4ECD)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="8e68e-113">注釈</span><span class="sxs-lookup"><span data-stu-id="8e68e-113">Remarks</span></span>

<span data-ttu-id="8e68e-114">この HTTP/REST メソッドは、サービス構成 ID (SCID) レベルで名前付きのホッパーから、指定されたチケット ID を削除します。</span><span class="sxs-lookup"><span data-stu-id="8e68e-114">This HTTP/REST method deletes the specified ticket ID from the named hopper at the service configuration ID (SCID) level.</span></span> <span data-ttu-id="8e68e-115">このメソッドは、 **Microsoft.Xbox.Services.Matchmaking.MatchmakingService.DeleteMatchTicketAsync**でラップすることができます。</span><span class="sxs-lookup"><span data-stu-id="8e68e-115">This method can be wrapped by **Microsoft.Xbox.Services.Matchmaking.MatchmakingService.DeleteMatchTicketAsync**.</span></span>  
<a id="ID4E2"></a>


## <a name="uri-parameters"></a><span data-ttu-id="8e68e-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8e68e-116">URI parameters</span></span>

| <span data-ttu-id="8e68e-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8e68e-117">Parameter</span></span>| <span data-ttu-id="8e68e-118">型</span><span class="sxs-lookup"><span data-stu-id="8e68e-118">Type</span></span>| <span data-ttu-id="8e68e-119">説明</span><span class="sxs-lookup"><span data-stu-id="8e68e-119">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="8e68e-120">scid</span><span class="sxs-lookup"><span data-stu-id="8e68e-120">scid</span></span>| <span data-ttu-id="8e68e-121">GUID</span><span class="sxs-lookup"><span data-stu-id="8e68e-121">GUID</span></span>| <span data-ttu-id="8e68e-122">セッションのサービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="8e68e-122">The service configuration identifier (SCID) for the session.</span></span>|
| <span data-ttu-id="8e68e-123">name</span><span class="sxs-lookup"><span data-stu-id="8e68e-123">name</span></span>| <span data-ttu-id="8e68e-124">string</span><span class="sxs-lookup"><span data-stu-id="8e68e-124">string</span></span>| <span data-ttu-id="8e68e-125">ホッパーの名前。</span><span class="sxs-lookup"><span data-stu-id="8e68e-125">The name of the hopper.</span></span>|
| <span data-ttu-id="8e68e-126">ticketId</span><span class="sxs-lookup"><span data-stu-id="8e68e-126">ticketId</span></span>| <span data-ttu-id="8e68e-127">GUID</span><span class="sxs-lookup"><span data-stu-id="8e68e-127">GUID</span></span>| <span data-ttu-id="8e68e-128">チケットの id。</span><span class="sxs-lookup"><span data-stu-id="8e68e-128">The ticket ID.</span></span>|

<a id="ID4EGB"></a>


## <a name="authorization"></a><span data-ttu-id="8e68e-129">Authorization</span><span class="sxs-lookup"><span data-stu-id="8e68e-129">Authorization</span></span>

| <span data-ttu-id="8e68e-130">型</span><span class="sxs-lookup"><span data-stu-id="8e68e-130">Type</span></span>| <span data-ttu-id="8e68e-131">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="8e68e-131">Required</span></span>| <span data-ttu-id="8e68e-132">説明</span><span class="sxs-lookup"><span data-stu-id="8e68e-132">Description</span></span>| <span data-ttu-id="8e68e-133">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="8e68e-133">Response if missing</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="8e68e-134">XUID (ユーザー ID)</span><span class="sxs-lookup"><span data-stu-id="8e68e-134">XUID (user ID)</span></span>| <span data-ttu-id="8e68e-135">必須</span><span class="sxs-lookup"><span data-stu-id="8e68e-135">yes</span></span>| <span data-ttu-id="8e68e-136">要求を行っているユーザーは、チケットによって参照される、チケット セッションのメンバーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="8e68e-136">The user making the request must be a member of the ticket session referred to by the ticket.</span></span>| <span data-ttu-id="8e68e-137">403</span><span class="sxs-lookup"><span data-stu-id="8e68e-137">403</span></span>|
| <span data-ttu-id="8e68e-138">特権とデバイスの種類</span><span class="sxs-lookup"><span data-stu-id="8e68e-138">Privileges and Device Type</span></span>| <span data-ttu-id="8e68e-139">必須</span><span class="sxs-lookup"><span data-stu-id="8e68e-139">yes</span></span>| <span data-ttu-id="8e68e-140">ユーザーの deviceType がコンソールに設定されている場合、マッチメイ キング サービスへの呼び出しには、要求のマルチプレイヤー権限を持つユーザーのみが許可されています。</span><span class="sxs-lookup"><span data-stu-id="8e68e-140">When the user's deviceType is set to console, only users with the multiplayer privilege in their claims are allowed to make calls to the matchmaking service.</span></span>| <span data-ttu-id="8e68e-141">403</span><span class="sxs-lookup"><span data-stu-id="8e68e-141">403</span></span>|

<a id="ID4EOC"></a>


## <a name="http-status-codes"></a><span data-ttu-id="8e68e-142">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="8e68e-142">HTTP status codes</span></span>

<span data-ttu-id="8e68e-143">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="8e68e-143">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EXC"></a>


## <a name="request-body"></a><span data-ttu-id="8e68e-144">要求本文</span><span class="sxs-lookup"><span data-stu-id="8e68e-144">Request body</span></span>

<span data-ttu-id="8e68e-145">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="8e68e-145">No objects are sent in the body of this request.</span></span>

<a id="ID4ECD"></a>


## <a name="response-body"></a><span data-ttu-id="8e68e-146">応答本文</span><span class="sxs-lookup"><span data-stu-id="8e68e-146">Response body</span></span>

<span data-ttu-id="8e68e-147">応答の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="8e68e-147">No objects are sent in the body of the response.</span></span>

<a id="ID4EPD"></a>


## <a name="see-also"></a><span data-ttu-id="8e68e-148">関連項目</span><span class="sxs-lookup"><span data-stu-id="8e68e-148">See also</span></span>

<a id="ID4ERD"></a>


##### <a name="parent"></a><span data-ttu-id="8e68e-149">Parent</span><span class="sxs-lookup"><span data-stu-id="8e68e-149">Parent</span></span>  

[<span data-ttu-id="8e68e-150">/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}</span><span class="sxs-lookup"><span data-stu-id="8e68e-150">/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}</span></span>](uri-scidhoppernameticketid.md)
