---
title: GET (/serviceconfigs/{scid}/hoppers/{name}/stats)
assetID: 4de5b07d-93e1-8ff0-05dd-1d3bb1802088
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidhoppershoppernamestatsget.html
description: " GET (/serviceconfigs/{scid}/hoppers/{name}/stats)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 95de95b35de496331dd3fe0a4c69f18e047c1020
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57621697"
---
# <a name="get-serviceconfigsscidhoppersnamestats"></a><span data-ttu-id="f466e-104">GET (/serviceconfigs/{scid}/hoppers/{name}/stats)</span><span class="sxs-lookup"><span data-stu-id="f466e-104">GET (/serviceconfigs/{scid}/hoppers/{name}/stats)</span></span>

<span data-ttu-id="f466e-105">Hopper の統計情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="f466e-105">Gets the statistics for a hopper.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="f466e-106">このメソッドは、コントラクト 103 以降で使用するためのものがし、X Xbl コントラクト バージョンのヘッダー要素が必要です。要求ごとに 103 で以降。</span><span class="sxs-lookup"><span data-stu-id="f466e-106">This method is intended for use with contract 103 or later, and requires a header element of X-Xbl-Contract-Version: 103 or later on every request.</span></span>

  * [<span data-ttu-id="f466e-107">注釈</span><span class="sxs-lookup"><span data-stu-id="f466e-107">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="f466e-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f466e-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="f466e-109">承認</span><span class="sxs-lookup"><span data-stu-id="f466e-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="f466e-110">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="f466e-110">HTTP status codes</span></span>](#ID4E3C)
  * [<span data-ttu-id="f466e-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="f466e-111">Request body</span></span>](#ID4EFD)
  * [<span data-ttu-id="f466e-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="f466e-112">Response body</span></span>](#ID4EQD)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="f466e-113">注釈</span><span class="sxs-lookup"><span data-stu-id="f466e-113">Remarks</span></span>
<span data-ttu-id="f466e-114">この HTTP/REST メソッドは、サービス構成の ID (SCID) レベルで名前付き hopper から統計を取得します。</span><span class="sxs-lookup"><span data-stu-id="f466e-114">This HTTP/REST method gets statistics from the named hopper at the service configuration ID (SCID) level.</span></span> <span data-ttu-id="f466e-115">このメソッドをラップすることができます、 **Microsoft.Xbox.Services.Matchmaking.MatchmakingService.GetHopperStatisticsAsync** API。</span><span class="sxs-lookup"><span data-stu-id="f466e-115">This method can be wrapped by the **Microsoft.Xbox.Services.Matchmaking.MatchmakingService.GetHopperStatisticsAsync** API.</span></span>  
<a id="ID4E5"></a>


## <a name="uri-parameters"></a><span data-ttu-id="f466e-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f466e-116">URI parameters</span></span>

| <span data-ttu-id="f466e-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f466e-117">Parameter</span></span>| <span data-ttu-id="f466e-118">種類</span><span class="sxs-lookup"><span data-stu-id="f466e-118">Type</span></span>| <span data-ttu-id="f466e-119">説明</span><span class="sxs-lookup"><span data-stu-id="f466e-119">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="f466e-120">scid</span><span class="sxs-lookup"><span data-stu-id="f466e-120">scid</span></span>| <span data-ttu-id="f466e-121">GUID</span><span class="sxs-lookup"><span data-stu-id="f466e-121">GUID</span></span>| <span data-ttu-id="f466e-122">セッションのサービス構成識別子 (SCID)。</span><span class="sxs-lookup"><span data-stu-id="f466e-122">The service configuration identifier (SCID) for the session.</span></span>|
| <span data-ttu-id="f466e-123">name</span><span class="sxs-lookup"><span data-stu-id="f466e-123">name</span></span>| <span data-ttu-id="f466e-124">string</span><span class="sxs-lookup"><span data-stu-id="f466e-124">string</span></span>| <span data-ttu-id="f466e-125">Hopper の名前。</span><span class="sxs-lookup"><span data-stu-id="f466e-125">The name of the hopper.</span></span>|

<a id="ID4EJB"></a>


## <a name="authorization"></a><span data-ttu-id="f466e-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="f466e-126">Authorization</span></span>

| <span data-ttu-id="f466e-127">種類</span><span class="sxs-lookup"><span data-stu-id="f466e-127">Type</span></span>| <span data-ttu-id="f466e-128">必須</span><span class="sxs-lookup"><span data-stu-id="f466e-128">Required</span></span>| <span data-ttu-id="f466e-129">説明</span><span class="sxs-lookup"><span data-stu-id="f466e-129">Description</span></span>| <span data-ttu-id="f466e-130">不足している場合の応答</span><span class="sxs-lookup"><span data-stu-id="f466e-130">Response if missing</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="f466e-131">XUID (ユーザー ID)</span><span class="sxs-lookup"><span data-stu-id="f466e-131">XUID (user ID)</span></span>| <span data-ttu-id="f466e-132">○</span><span class="sxs-lookup"><span data-stu-id="f466e-132">yes</span></span>| <span data-ttu-id="f466e-133">要求を行うユーザーは、チケットによって参照されるチケット セッションのメンバーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="f466e-133">The user making the request must be a member of the ticket session referred to by the ticket.</span></span> | <span data-ttu-id="f466e-134">403</span><span class="sxs-lookup"><span data-stu-id="f466e-134">403</span></span>|
| <span data-ttu-id="f466e-135">特権とデバイスの種類</span><span class="sxs-lookup"><span data-stu-id="f466e-135">Privileges and Device Type</span></span>| <span data-ttu-id="f466e-136">○</span><span class="sxs-lookup"><span data-stu-id="f466e-136">yes</span></span>| <span data-ttu-id="f466e-137">ユーザーの deviceType は、コンソールに設定されている場合は、それぞれのクレームでマルチ プレーヤーの特権を持つユーザーのみがマッチメイ キング サービスを呼び出すことが許可されます。</span><span class="sxs-lookup"><span data-stu-id="f466e-137">When the user's deviceType is set to console, only users with the multiplayer privilege in their claims are allowed to make calls to the matchmaking service.</span></span> | <span data-ttu-id="f466e-138">403</span><span class="sxs-lookup"><span data-stu-id="f466e-138">403</span></span>|
| <span data-ttu-id="f466e-139">タイトルの購入/デバイスの種類 ID/実証</span><span class="sxs-lookup"><span data-stu-id="f466e-139">Title ID/Proof of Purchase/Device Type</span></span>| <span data-ttu-id="f466e-140">○</span><span class="sxs-lookup"><span data-stu-id="f466e-140">yes</span></span>| <span data-ttu-id="f466e-141">一致するタイトルは、指定されたタイトルの要求、デバイスの種類の組み合わせのマッチメイ キングを許可する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f466e-141">The title that is being matched into must allow matchmaking for the specified title claim, device type combination.</span></span> | <span data-ttu-id="f466e-142">403</span><span class="sxs-lookup"><span data-stu-id="f466e-142">403</span></span>|

<a id="ID4E3C"></a>


## <a name="http-status-codes"></a><span data-ttu-id="f466e-143">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="f466e-143">HTTP status codes</span></span>
<span data-ttu-id="f466e-144">MPSD に適用される、サービスは、HTTP 状態コードを返します。</span><span class="sxs-lookup"><span data-stu-id="f466e-144">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EFD"></a>


## <a name="request-body"></a><span data-ttu-id="f466e-145">要求本文</span><span class="sxs-lookup"><span data-stu-id="f466e-145">Request body</span></span>

<span data-ttu-id="f466e-146">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="f466e-146">No objects are sent in the body of this request.</span></span>

<a id="ID4EQD"></a>


## <a name="response-body"></a><span data-ttu-id="f466e-147">応答本文</span><span class="sxs-lookup"><span data-stu-id="f466e-147">Response body</span></span>

| <span data-ttu-id="f466e-148">メンバー</span><span class="sxs-lookup"><span data-stu-id="f466e-148">Member</span></span>| <span data-ttu-id="f466e-149">種類</span><span class="sxs-lookup"><span data-stu-id="f466e-149">Type</span></span>| <span data-ttu-id="f466e-150">説明</span><span class="sxs-lookup"><span data-stu-id="f466e-150">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="f466e-151">hopperName</span><span class="sxs-lookup"><span data-stu-id="f466e-151">hopperName</span></span>| <span data-ttu-id="f466e-152">string</span><span class="sxs-lookup"><span data-stu-id="f466e-152">string</span></span>| <span data-ttu-id="f466e-153">選択した hopper の名前。</span><span class="sxs-lookup"><span data-stu-id="f466e-153">The name of the selected hopper.</span></span>|
| <span data-ttu-id="f466e-154">待機時間</span><span class="sxs-lookup"><span data-stu-id="f466e-154">waitTime</span></span>| <span data-ttu-id="f466e-155">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="f466e-155">32-bit signed integer</span></span>| <span data-ttu-id="f466e-156">平均時間 (秒単位の整数) hopper の一致します。</span><span class="sxs-lookup"><span data-stu-id="f466e-156">Average matching time for the hopper (an integral number of seconds).</span></span> |
| <span data-ttu-id="f466e-157">カタログの作成</span><span class="sxs-lookup"><span data-stu-id="f466e-157">population</span></span>| <span data-ttu-id="f466e-158">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="f466e-158">32-bit signed integer</span></span>| <span data-ttu-id="f466e-159">一致するもの、hopper で待機しているユーザーの数。</span><span class="sxs-lookup"><span data-stu-id="f466e-159">The number of people waiting for matches in the hopper.</span></span>|

<a id="ID4E1D"></a>


### <a name="sample-response"></a><span data-ttu-id="f466e-160">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="f466e-160">Sample response</span></span>


```cpp
{
      "hopperName":"contosoawesome2",
      "waitTime":30,
      "population":1
    }


```


<a id="ID4EJE"></a>


## <a name="see-also"></a><span data-ttu-id="f466e-161">関連項目</span><span class="sxs-lookup"><span data-stu-id="f466e-161">See also</span></span>

<a id="ID4ELE"></a>


##### <a name="parent"></a><span data-ttu-id="f466e-162">Parent</span><span class="sxs-lookup"><span data-stu-id="f466e-162">Parent</span></span>  

[<span data-ttu-id="f466e-163">/serviceconfigs/{scid}/hoppers/{name}/stats</span><span class="sxs-lookup"><span data-stu-id="f466e-163">/serviceconfigs/{scid}/hoppers/{name}/stats</span></span>](uri-serviceconfigsscidhoppershoppernamestats.md)
