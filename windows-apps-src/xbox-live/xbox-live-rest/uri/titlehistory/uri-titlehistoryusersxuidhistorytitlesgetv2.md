---
title: GET (/users/xuid({xuid})/history/titles)
assetID: c0a6cb3b-bab6-03b8-a79e-87defaaa6421
permalink: en-us/docs/xboxlive/rest/uri-titlehistoryusersxuidhistorytitlesgetv2.html
author: KevinAsgari
description: " GET (/users/xuid({xuid})/history/titles)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 966ff94004d6fd6bfc404800c5ea6561ae3a3864
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/22/2018
ms.locfileid: "4128020"
---
# <a name="get-usersxuidxuidhistorytitles"></a><span data-ttu-id="05177-104">GET (/users/xuid({xuid})/history/titles)</span><span class="sxs-lookup"><span data-stu-id="05177-104">GET (/users/xuid({xuid})/history/titles)</span></span>
<span data-ttu-id="05177-105">タイトルは、ユーザーがロックを解除またはに対するその実績の進行状況の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="05177-105">Gets a list of titles for which the user has unlocked or made progress on its achievements.</span></span> <span data-ttu-id="05177-106">この API では、タイトルのプレイまたは起動のユーザーのすべての履歴は返されません。</span><span class="sxs-lookup"><span data-stu-id="05177-106">This API does not return a user's full history of titles played or launched.</span></span> <span data-ttu-id="05177-107">これらの Uri のドメインが`achievements.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="05177-107">The domain for these URIs is `achievements.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="05177-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="05177-108">URI parameters</span></span>](#ID4EY)
  * [<span data-ttu-id="05177-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="05177-109">Query string parameters</span></span>](#ID4EDB)
  * [<span data-ttu-id="05177-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="05177-110">Authorization</span></span>](#ID4EFD)
  * [<span data-ttu-id="05177-111">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="05177-111">Optional Request Headers</span></span>](#ID4EGE)
  * [<span data-ttu-id="05177-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="05177-112">Request body</span></span>](#ID4ERF)
 
<a id="ID4EY"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="05177-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="05177-113">URI parameters</span></span>
 
| <span data-ttu-id="05177-114">パラメーター</span><span class="sxs-lookup"><span data-stu-id="05177-114">Parameter</span></span>| <span data-ttu-id="05177-115">型</span><span class="sxs-lookup"><span data-stu-id="05177-115">Type</span></span>| <span data-ttu-id="05177-116">説明</span><span class="sxs-lookup"><span data-stu-id="05177-116">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="05177-117">xuid</span><span class="sxs-lookup"><span data-stu-id="05177-117">xuid</span></span>| <span data-ttu-id="05177-118">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="05177-118">64-bit unsigned integer</span></span>| <span data-ttu-id="05177-119">Xbox ユーザー ID (XUID)、ユーザーがタイトル履歴にアクセスしているのです。</span><span class="sxs-lookup"><span data-stu-id="05177-119">Xbox User ID (XUID) of the user whose title history is being accessed.</span></span>| 
  
<a id="ID4EDB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="05177-120">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="05177-120">Query string parameters</span></span>
 
| <span data-ttu-id="05177-121">パラメーター</span><span class="sxs-lookup"><span data-stu-id="05177-121">Parameter</span></span>| <span data-ttu-id="05177-122">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="05177-122">Required</span></span>| <span data-ttu-id="05177-123">種類</span><span class="sxs-lookup"><span data-stu-id="05177-123">Type</span></span>| <span data-ttu-id="05177-124">説明</span><span class="sxs-lookup"><span data-stu-id="05177-124">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="05177-125">skipItems</span><span class="sxs-lookup"><span data-stu-id="05177-125">skipItems</span></span>| <span data-ttu-id="05177-126">いいえ</span><span class="sxs-lookup"><span data-stu-id="05177-126">No</span></span>| <span data-ttu-id="05177-127">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="05177-127">32-bit signed integer</span></span>| <span data-ttu-id="05177-128">特定の項目数後以降の項目を返します。</span><span class="sxs-lookup"><span data-stu-id="05177-128">Return items beginning after the given number of items.</span></span> <span data-ttu-id="05177-129">たとえば、 <b>skipItems =「3」</b>項目を取得以降では、4 番目の項目を取得します。</span><span class="sxs-lookup"><span data-stu-id="05177-129">For example, <b>skipItems="3"</b> will retrieve items beginning with the fourth item retrieved.</span></span> | 
| <span data-ttu-id="05177-130">continuationToken</span><span class="sxs-lookup"><span data-stu-id="05177-130">continuationToken</span></span>| <span data-ttu-id="05177-131">いいえ</span><span class="sxs-lookup"><span data-stu-id="05177-131">No</span></span>| <span data-ttu-id="05177-132">string</span><span class="sxs-lookup"><span data-stu-id="05177-132">string</span></span>| <span data-ttu-id="05177-133">特定の継続トークンで始まる項目を返します。</span><span class="sxs-lookup"><span data-stu-id="05177-133">Return the items starting at the given continuation token.</span></span> | 
| <span data-ttu-id="05177-134">maxItems</span><span class="sxs-lookup"><span data-stu-id="05177-134">maxItems</span></span>| <span data-ttu-id="05177-135">いいえ</span><span class="sxs-lookup"><span data-stu-id="05177-135">No</span></span>| <span data-ttu-id="05177-136">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="05177-136">32-bit signed integer</span></span>| <span data-ttu-id="05177-137"><b>SkipItems</b>と項目の範囲を返す<b>continuationToken</b>と組み合わせることができるコレクションから返される項目の最大数。</span><span class="sxs-lookup"><span data-stu-id="05177-137">Maximum number of items to return from the collection, which can be combined with <b>skipItems</b> and <b>continuationToken</b> to return a range of items.</span></span> <span data-ttu-id="05177-138">サービスに結果の最後のページが返されていない場合でもは<b>maxItems</b>が存在しないと、 <b>maxItems</b>より少ないを返す可能性がある場合、既定値を提供可能性があります。</span><span class="sxs-lookup"><span data-stu-id="05177-138">The service may provide a default value if <b>maxItems</b> is not present, and may return fewer than <b>maxItems</b>, even if the last page of results has not yet been returned.</span></span> | 
  
<a id="ID4EFD"></a>

 
## <a name="authorization"></a><span data-ttu-id="05177-139">Authorization</span><span class="sxs-lookup"><span data-stu-id="05177-139">Authorization</span></span>
 
| <span data-ttu-id="05177-140">要求</span><span class="sxs-lookup"><span data-stu-id="05177-140">Claim</span></span>| <span data-ttu-id="05177-141">必須?</span><span class="sxs-lookup"><span data-stu-id="05177-141">Required?</span></span>| <span data-ttu-id="05177-142">説明</span><span class="sxs-lookup"><span data-stu-id="05177-142">Description</span></span>| <span data-ttu-id="05177-143">不足している場合の動作</span><span class="sxs-lookup"><span data-stu-id="05177-143">Behavior if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="05177-144">ユーザー</span><span class="sxs-lookup"><span data-stu-id="05177-144">User</span></span>| <span data-ttu-id="05177-145">呼び出し元が、承認された Xbox LIVE ユーザーです。</span><span class="sxs-lookup"><span data-stu-id="05177-145">Caller is an authorized Xbox LIVE user.</span></span>| <span data-ttu-id="05177-146">呼び出し元は、Xbox LIVE で有効なユーザーをする必要があります。</span><span class="sxs-lookup"><span data-stu-id="05177-146">The caller needs to be a valid user on Xbox LIVE.</span></span>| <span data-ttu-id="05177-147">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="05177-147">403 Forbidden</span></span>| 
  
<a id="ID4EGE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="05177-148">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="05177-148">Optional Request Headers</span></span>
 
| <span data-ttu-id="05177-149">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="05177-149">Header</span></span>| <span data-ttu-id="05177-150">型</span><span class="sxs-lookup"><span data-stu-id="05177-150">Type</span></span>| <span data-ttu-id="05177-151">説明</span><span class="sxs-lookup"><span data-stu-id="05177-151">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <b><span data-ttu-id="05177-152">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="05177-152">X-RequestedServiceVersion</span></span></b>| <span data-ttu-id="05177-153">string</span><span class="sxs-lookup"><span data-stu-id="05177-153">string</span></span>| <span data-ttu-id="05177-154">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="05177-154">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="05177-155">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。</span><span class="sxs-lookup"><span data-stu-id="05177-155">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc.</span></span>| 
| <b><span data-ttu-id="05177-156">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="05177-156">x-xbl-contract-version</span></span></b>| <span data-ttu-id="05177-157">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="05177-157">32-bit unsigned integer</span></span>| <span data-ttu-id="05177-158">存在する場合、2 に設定すると、この API の V2 バージョンが使用されます。</span><span class="sxs-lookup"><span data-stu-id="05177-158">If present and set to 2, the V2 version of this API will be used.</span></span> <span data-ttu-id="05177-159">それ以外の場合、V1 します。</span><span class="sxs-lookup"><span data-stu-id="05177-159">Otherwise, V1.</span></span>| 
  
<a id="ID4ERF"></a>

 
## <a name="request-body"></a><span data-ttu-id="05177-160">要求本文</span><span class="sxs-lookup"><span data-stu-id="05177-160">Request body</span></span>
 
<span data-ttu-id="05177-161">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="05177-161">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EDG"></a>

 
## <a name="see-also"></a><span data-ttu-id="05177-162">関連項目</span><span class="sxs-lookup"><span data-stu-id="05177-162">See also</span></span>
 
<a id="ID4EFG"></a>

 
##### <a name="parent"></a><span data-ttu-id="05177-163">Parent</span><span class="sxs-lookup"><span data-stu-id="05177-163">Parent</span></span> 

[<span data-ttu-id="05177-164">/users/xuid({xuid})/history/titles</span><span class="sxs-lookup"><span data-stu-id="05177-164">/users/xuid({xuid})/history/titles</span></span>](uri-titlehistoryusersxuidhistorytitlesv2.md)

  
<a id="ID4EPG"></a>

 
##### <a name="reference"></a><span data-ttu-id="05177-165">リファレンス</span><span class="sxs-lookup"><span data-stu-id="05177-165">Reference</span></span> 

[<span data-ttu-id="05177-166">UserTitle (JSON)</span><span class="sxs-lookup"><span data-stu-id="05177-166">UserTitle (JSON)</span></span>](../../json/json-usertitlev2.md)

 [<span data-ttu-id="05177-167">PagingInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="05177-167">PagingInfo (JSON)</span></span>](../../json/json-paginginfo.md)

 [<span data-ttu-id="05177-168">ページング パラメーター</span><span class="sxs-lookup"><span data-stu-id="05177-168">Paging Parameters</span></span>](../../additional/pagingparameters.md)

   