---
title: DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})
assetID: d9ff3f21-aa70-af41-afa1-9a9244fcdb95
permalink: en-us/docs/xboxlive/rest/uri-scidhoppernameticketiddelete.html
description: " DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fdd28cb94b31102d9af98aa95afde45424dadce9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589667"
---
# <a name="delete-serviceconfigsscidhoppershoppernameticketsticketid"></a><span data-ttu-id="81efa-104">DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})</span><span class="sxs-lookup"><span data-stu-id="81efa-104">DELETE (/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid})</span></span>

<span data-ttu-id="81efa-105">一致のチケットを削除します。</span><span class="sxs-lookup"><span data-stu-id="81efa-105">Removes a match ticket.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="81efa-106">このメソッドは、コントラクト 103 以降で使用するためのものがし、X Xbl コントラクト バージョンのヘッダー要素が必要です。要求ごとに 103 で以降。</span><span class="sxs-lookup"><span data-stu-id="81efa-106">This method is intended for use with contract 103 or later, and requires a header element of X-Xbl-Contract-Version: 103 or later on every request.</span></span>

  * [<span data-ttu-id="81efa-107">注釈</span><span class="sxs-lookup"><span data-stu-id="81efa-107">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="81efa-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="81efa-108">URI parameters</span></span>](#ID4E2)
  * [<span data-ttu-id="81efa-109">承認</span><span class="sxs-lookup"><span data-stu-id="81efa-109">Authorization</span></span>](#ID4EGB)
  * [<span data-ttu-id="81efa-110">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="81efa-110">HTTP status codes</span></span>](#ID4EOC)
  * [<span data-ttu-id="81efa-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="81efa-111">Request body</span></span>](#ID4EXC)
  * [<span data-ttu-id="81efa-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="81efa-112">Response body</span></span>](#ID4ECD)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="81efa-113">注釈</span><span class="sxs-lookup"><span data-stu-id="81efa-113">Remarks</span></span>

<span data-ttu-id="81efa-114">この HTTP/REST メソッドでは、サービス構成の ID (SCID) レベルで名前付き hopper から指定したチケット ID を削除します。</span><span class="sxs-lookup"><span data-stu-id="81efa-114">This HTTP/REST method deletes the specified ticket ID from the named hopper at the service configuration ID (SCID) level.</span></span> <span data-ttu-id="81efa-115">このメソッドによってラップできる**Microsoft.Xbox.Services.Matchmaking.MatchmakingService.DeleteMatchTicketAsync**します。</span><span class="sxs-lookup"><span data-stu-id="81efa-115">This method can be wrapped by **Microsoft.Xbox.Services.Matchmaking.MatchmakingService.DeleteMatchTicketAsync**.</span></span>  
<a id="ID4E2"></a>


## <a name="uri-parameters"></a><span data-ttu-id="81efa-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="81efa-116">URI parameters</span></span>

| <span data-ttu-id="81efa-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="81efa-117">Parameter</span></span>| <span data-ttu-id="81efa-118">種類</span><span class="sxs-lookup"><span data-stu-id="81efa-118">Type</span></span>| <span data-ttu-id="81efa-119">説明</span><span class="sxs-lookup"><span data-stu-id="81efa-119">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="81efa-120">scid</span><span class="sxs-lookup"><span data-stu-id="81efa-120">scid</span></span>| <span data-ttu-id="81efa-121">GUID</span><span class="sxs-lookup"><span data-stu-id="81efa-121">GUID</span></span>| <span data-ttu-id="81efa-122">セッションのサービス構成識別子 (SCID)。</span><span class="sxs-lookup"><span data-stu-id="81efa-122">The service configuration identifier (SCID) for the session.</span></span>|
| <span data-ttu-id="81efa-123">name</span><span class="sxs-lookup"><span data-stu-id="81efa-123">name</span></span>| <span data-ttu-id="81efa-124">string</span><span class="sxs-lookup"><span data-stu-id="81efa-124">string</span></span>| <span data-ttu-id="81efa-125">Hopper の名前。</span><span class="sxs-lookup"><span data-stu-id="81efa-125">The name of the hopper.</span></span>|
| <span data-ttu-id="81efa-126">TicketId</span><span class="sxs-lookup"><span data-stu-id="81efa-126">ticketId</span></span>| <span data-ttu-id="81efa-127">GUID</span><span class="sxs-lookup"><span data-stu-id="81efa-127">GUID</span></span>| <span data-ttu-id="81efa-128">チケット id。</span><span class="sxs-lookup"><span data-stu-id="81efa-128">The ticket ID.</span></span>|

<a id="ID4EGB"></a>


## <a name="authorization"></a><span data-ttu-id="81efa-129">Authorization</span><span class="sxs-lookup"><span data-stu-id="81efa-129">Authorization</span></span>

| <span data-ttu-id="81efa-130">種類</span><span class="sxs-lookup"><span data-stu-id="81efa-130">Type</span></span>| <span data-ttu-id="81efa-131">必須</span><span class="sxs-lookup"><span data-stu-id="81efa-131">Required</span></span>| <span data-ttu-id="81efa-132">説明</span><span class="sxs-lookup"><span data-stu-id="81efa-132">Description</span></span>| <span data-ttu-id="81efa-133">不足している場合の応答</span><span class="sxs-lookup"><span data-stu-id="81efa-133">Response if missing</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="81efa-134">XUID (ユーザー ID)</span><span class="sxs-lookup"><span data-stu-id="81efa-134">XUID (user ID)</span></span>| <span data-ttu-id="81efa-135">○</span><span class="sxs-lookup"><span data-stu-id="81efa-135">yes</span></span>| <span data-ttu-id="81efa-136">要求を行うユーザーは、チケットによって参照されるチケット セッションのメンバーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="81efa-136">The user making the request must be a member of the ticket session referred to by the ticket.</span></span>| <span data-ttu-id="81efa-137">403</span><span class="sxs-lookup"><span data-stu-id="81efa-137">403</span></span>|
| <span data-ttu-id="81efa-138">特権とデバイスの種類</span><span class="sxs-lookup"><span data-stu-id="81efa-138">Privileges and Device Type</span></span>| <span data-ttu-id="81efa-139">○</span><span class="sxs-lookup"><span data-stu-id="81efa-139">yes</span></span>| <span data-ttu-id="81efa-140">ユーザーの deviceType は、コンソールに設定されている場合は、それぞれのクレームでマルチ プレーヤーの特権を持つユーザーのみがマッチメイ キング サービスを呼び出すことが許可されます。</span><span class="sxs-lookup"><span data-stu-id="81efa-140">When the user's deviceType is set to console, only users with the multiplayer privilege in their claims are allowed to make calls to the matchmaking service.</span></span>| <span data-ttu-id="81efa-141">403</span><span class="sxs-lookup"><span data-stu-id="81efa-141">403</span></span>|

<a id="ID4EOC"></a>


## <a name="http-status-codes"></a><span data-ttu-id="81efa-142">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="81efa-142">HTTP status codes</span></span>

<span data-ttu-id="81efa-143">MPSD に適用される、サービスは、HTTP 状態コードを返します。</span><span class="sxs-lookup"><span data-stu-id="81efa-143">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EXC"></a>


## <a name="request-body"></a><span data-ttu-id="81efa-144">要求本文</span><span class="sxs-lookup"><span data-stu-id="81efa-144">Request body</span></span>

<span data-ttu-id="81efa-145">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="81efa-145">No objects are sent in the body of this request.</span></span>

<a id="ID4ECD"></a>


## <a name="response-body"></a><span data-ttu-id="81efa-146">応答本文</span><span class="sxs-lookup"><span data-stu-id="81efa-146">Response body</span></span>

<span data-ttu-id="81efa-147">応答の本文では、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="81efa-147">No objects are sent in the body of the response.</span></span>

<a id="ID4EPD"></a>


## <a name="see-also"></a><span data-ttu-id="81efa-148">関連項目</span><span class="sxs-lookup"><span data-stu-id="81efa-148">See also</span></span>

<a id="ID4ERD"></a>


##### <a name="parent"></a><span data-ttu-id="81efa-149">Parent</span><span class="sxs-lookup"><span data-stu-id="81efa-149">Parent</span></span>  

[<span data-ttu-id="81efa-150">/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}</span><span class="sxs-lookup"><span data-stu-id="81efa-150">/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}</span></span>](uri-scidhoppernameticketid.md)
