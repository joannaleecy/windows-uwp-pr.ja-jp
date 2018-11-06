---
title: GET (/serviceconfigs/{scid}/hoppers/{name}/stats)
assetID: 4de5b07d-93e1-8ff0-05dd-1d3bb1802088
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidhoppershoppernamestatsget.html
author: KevinAsgari
description: " GET (/serviceconfigs/{scid}/hoppers/{name}/stats)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3e072ffa2ced07982247cebd633564606d1e9bb4
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6023390"
---
# <a name="get-serviceconfigsscidhoppersnamestats"></a><span data-ttu-id="c02a5-104">GET (/serviceconfigs/{scid}/hoppers/{name}/stats)</span><span class="sxs-lookup"><span data-stu-id="c02a5-104">GET (/serviceconfigs/{scid}/hoppers/{name}/stats)</span></span>

<span data-ttu-id="c02a5-105">ホッパーの統計情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="c02a5-105">Gets the statistics for a hopper.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="c02a5-106">このメソッドは、コントラクト 103 以降で使用するものでは、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 103 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="c02a5-106">This method is intended for use with contract 103 or later, and requires a header element of X-Xbl-Contract-Version: 103 or later on every request.</span></span>

  * [<span data-ttu-id="c02a5-107">注釈</span><span class="sxs-lookup"><span data-stu-id="c02a5-107">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="c02a5-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c02a5-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="c02a5-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="c02a5-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="c02a5-110">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="c02a5-110">HTTP status codes</span></span>](#ID4E3C)
  * [<span data-ttu-id="c02a5-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="c02a5-111">Request body</span></span>](#ID4EFD)
  * [<span data-ttu-id="c02a5-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="c02a5-112">Response body</span></span>](#ID4EQD)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="c02a5-113">注釈</span><span class="sxs-lookup"><span data-stu-id="c02a5-113">Remarks</span></span>
<span data-ttu-id="c02a5-114">この HTTP/REST メソッドは、サービス構成 ID (SCID) レベルで名前付きのホッパーからの統計情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="c02a5-114">This HTTP/REST method gets statistics from the named hopper at the service configuration ID (SCID) level.</span></span> <span data-ttu-id="c02a5-115">このメソッドは、 **Microsoft.Xbox.Services.Matchmaking.MatchmakingService.GetHopperStatisticsAsync** API でラップすることができます。</span><span class="sxs-lookup"><span data-stu-id="c02a5-115">This method can be wrapped by the **Microsoft.Xbox.Services.Matchmaking.MatchmakingService.GetHopperStatisticsAsync** API.</span></span>  
<a id="ID4E5"></a>


## <a name="uri-parameters"></a><span data-ttu-id="c02a5-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c02a5-116">URI parameters</span></span>

| <span data-ttu-id="c02a5-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c02a5-117">Parameter</span></span>| <span data-ttu-id="c02a5-118">型</span><span class="sxs-lookup"><span data-stu-id="c02a5-118">Type</span></span>| <span data-ttu-id="c02a5-119">説明</span><span class="sxs-lookup"><span data-stu-id="c02a5-119">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="c02a5-120">scid</span><span class="sxs-lookup"><span data-stu-id="c02a5-120">scid</span></span>| <span data-ttu-id="c02a5-121">GUID</span><span class="sxs-lookup"><span data-stu-id="c02a5-121">GUID</span></span>| <span data-ttu-id="c02a5-122">セッションのサービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="c02a5-122">The service configuration identifier (SCID) for the session.</span></span>|
| <span data-ttu-id="c02a5-123">name</span><span class="sxs-lookup"><span data-stu-id="c02a5-123">name</span></span>| <span data-ttu-id="c02a5-124">string</span><span class="sxs-lookup"><span data-stu-id="c02a5-124">string</span></span>| <span data-ttu-id="c02a5-125">ホッパーの名前。</span><span class="sxs-lookup"><span data-stu-id="c02a5-125">The name of the hopper.</span></span>|

<a id="ID4EJB"></a>


## <a name="authorization"></a><span data-ttu-id="c02a5-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="c02a5-126">Authorization</span></span>

| <span data-ttu-id="c02a5-127">型</span><span class="sxs-lookup"><span data-stu-id="c02a5-127">Type</span></span>| <span data-ttu-id="c02a5-128">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="c02a5-128">Required</span></span>| <span data-ttu-id="c02a5-129">説明</span><span class="sxs-lookup"><span data-stu-id="c02a5-129">Description</span></span>| <span data-ttu-id="c02a5-130">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="c02a5-130">Response if missing</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="c02a5-131">XUID (ユーザー ID)</span><span class="sxs-lookup"><span data-stu-id="c02a5-131">XUID (user ID)</span></span>| <span data-ttu-id="c02a5-132">必須</span><span class="sxs-lookup"><span data-stu-id="c02a5-132">yes</span></span>| <span data-ttu-id="c02a5-133">要求を行っているユーザーは、チケットによって参照される、チケット セッションのメンバーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="c02a5-133">The user making the request must be a member of the ticket session referred to by the ticket.</span></span> | <span data-ttu-id="c02a5-134">403</span><span class="sxs-lookup"><span data-stu-id="c02a5-134">403</span></span>|
| <span data-ttu-id="c02a5-135">特権とデバイスの種類</span><span class="sxs-lookup"><span data-stu-id="c02a5-135">Privileges and Device Type</span></span>| <span data-ttu-id="c02a5-136">必須</span><span class="sxs-lookup"><span data-stu-id="c02a5-136">yes</span></span>| <span data-ttu-id="c02a5-137">ユーザーの deviceType がコンソールに設定されている場合、マッチメイ キング サービスへの呼び出しには、要求のマルチプレイヤー権限を持つユーザーのみが許可されています。</span><span class="sxs-lookup"><span data-stu-id="c02a5-137">When the user's deviceType is set to console, only users with the multiplayer privilege in their claims are allowed to make calls to the matchmaking service.</span></span> | <span data-ttu-id="c02a5-138">403</span><span class="sxs-lookup"><span data-stu-id="c02a5-138">403</span></span>|
| <span data-ttu-id="c02a5-139">タイトル ID/実証購入/デバイスの種類</span><span class="sxs-lookup"><span data-stu-id="c02a5-139">Title ID/Proof of Purchase/Device Type</span></span>| <span data-ttu-id="c02a5-140">必須</span><span class="sxs-lookup"><span data-stu-id="c02a5-140">yes</span></span>| <span data-ttu-id="c02a5-141">タイトルに一致するには、指定されたタイトルの要求、デバイスの種類の組み合わせのマッチメイ キングを許可する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c02a5-141">The title that is being matched into must allow matchmaking for the specified title claim, device type combination.</span></span> | <span data-ttu-id="c02a5-142">403</span><span class="sxs-lookup"><span data-stu-id="c02a5-142">403</span></span>|

<a id="ID4E3C"></a>


## <a name="http-status-codes"></a><span data-ttu-id="c02a5-143">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="c02a5-143">HTTP status codes</span></span>
<span data-ttu-id="c02a5-144">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="c02a5-144">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EFD"></a>


## <a name="request-body"></a><span data-ttu-id="c02a5-145">要求本文</span><span class="sxs-lookup"><span data-stu-id="c02a5-145">Request body</span></span>

<span data-ttu-id="c02a5-146">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="c02a5-146">No objects are sent in the body of this request.</span></span>

<a id="ID4EQD"></a>


## <a name="response-body"></a><span data-ttu-id="c02a5-147">応答本文</span><span class="sxs-lookup"><span data-stu-id="c02a5-147">Response body</span></span>

| <span data-ttu-id="c02a5-148">メンバー</span><span class="sxs-lookup"><span data-stu-id="c02a5-148">Member</span></span>| <span data-ttu-id="c02a5-149">種類</span><span class="sxs-lookup"><span data-stu-id="c02a5-149">Type</span></span>| <span data-ttu-id="c02a5-150">説明</span><span class="sxs-lookup"><span data-stu-id="c02a5-150">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="c02a5-151">hopperName</span><span class="sxs-lookup"><span data-stu-id="c02a5-151">hopperName</span></span>| <span data-ttu-id="c02a5-152">string</span><span class="sxs-lookup"><span data-stu-id="c02a5-152">string</span></span>| <span data-ttu-id="c02a5-153">選択したホッパーの名前。</span><span class="sxs-lookup"><span data-stu-id="c02a5-153">The name of the selected hopper.</span></span>|
| <span data-ttu-id="c02a5-154">待機時間</span><span class="sxs-lookup"><span data-stu-id="c02a5-154">waitTime</span></span>| <span data-ttu-id="c02a5-155">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="c02a5-155">32-bit signed integer</span></span>| <span data-ttu-id="c02a5-156">照合時間 (秒の整数)、ホッパーの平均です。</span><span class="sxs-lookup"><span data-stu-id="c02a5-156">Average matching time for the hopper (an integral number of seconds).</span></span> |
| <span data-ttu-id="c02a5-157">カタログの作成</span><span class="sxs-lookup"><span data-stu-id="c02a5-157">population</span></span>| <span data-ttu-id="c02a5-158">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="c02a5-158">32-bit signed integer</span></span>| <span data-ttu-id="c02a5-159">一致するものをホッパーで待機しているユーザーの数。</span><span class="sxs-lookup"><span data-stu-id="c02a5-159">The number of people waiting for matches in the hopper.</span></span>|

<a id="ID4E1D"></a>


### <a name="sample-response"></a><span data-ttu-id="c02a5-160">応答の例</span><span class="sxs-lookup"><span data-stu-id="c02a5-160">Sample response</span></span>


```cpp
{
      "hopperName":"contosoawesome2",
      "waitTime":30,
      "population":1
    }


```


<a id="ID4EJE"></a>


## <a name="see-also"></a><span data-ttu-id="c02a5-161">関連項目</span><span class="sxs-lookup"><span data-stu-id="c02a5-161">See also</span></span>

<a id="ID4ELE"></a>


##### <a name="parent"></a><span data-ttu-id="c02a5-162">Parent</span><span class="sxs-lookup"><span data-stu-id="c02a5-162">Parent</span></span>  

[<span data-ttu-id="c02a5-163">/serviceconfigs/{scid}/hoppers/{name}/stats</span><span class="sxs-lookup"><span data-stu-id="c02a5-163">/serviceconfigs/{scid}/hoppers/{name}/stats</span></span>](uri-serviceconfigsscidhoppershoppernamestats.md)
