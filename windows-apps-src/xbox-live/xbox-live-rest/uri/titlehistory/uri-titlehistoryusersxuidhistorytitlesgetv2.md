---
title: GET (/users/xuid({xuid})/history/titles)
assetID: c0a6cb3b-bab6-03b8-a79e-87defaaa6421
permalink: en-us/docs/xboxlive/rest/uri-titlehistoryusersxuidhistorytitlesgetv2.html
description: " GET (/users/xuid({xuid})/history/titles)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: cadbf38385bbc321ef5bf23eb93c3fbc5c1a2417
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8938691"
---
# <a name="get-usersxuidxuidhistorytitles"></a><span data-ttu-id="0c56b-104">GET (/users/xuid({xuid})/history/titles)</span><span class="sxs-lookup"><span data-stu-id="0c56b-104">GET (/users/xuid({xuid})/history/titles)</span></span>
<span data-ttu-id="0c56b-105">タイトルは、ユーザーがロックを解除またはに対するその実績の進行状況の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="0c56b-105">Gets a list of titles for which the user has unlocked or made progress on its achievements.</span></span> <span data-ttu-id="0c56b-106">この API では、タイトルのプレイまたは起動のユーザーのすべての履歴は返されません。</span><span class="sxs-lookup"><span data-stu-id="0c56b-106">This API does not return a user's full history of titles played or launched.</span></span> <span data-ttu-id="0c56b-107">これらの Uri のドメインが`achievements.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="0c56b-107">The domain for these URIs is `achievements.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="0c56b-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0c56b-108">URI parameters</span></span>](#ID4EY)
  * [<span data-ttu-id="0c56b-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="0c56b-109">Query string parameters</span></span>](#ID4EDB)
  * [<span data-ttu-id="0c56b-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="0c56b-110">Authorization</span></span>](#ID4EFD)
  * [<span data-ttu-id="0c56b-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0c56b-111">Optional Request Headers</span></span>](#ID4EGE)
  * [<span data-ttu-id="0c56b-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="0c56b-112">Request body</span></span>](#ID4ERF)
 
<a id="ID4EY"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="0c56b-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0c56b-113">URI parameters</span></span>
 
| <span data-ttu-id="0c56b-114">パラメーター</span><span class="sxs-lookup"><span data-stu-id="0c56b-114">Parameter</span></span>| <span data-ttu-id="0c56b-115">型</span><span class="sxs-lookup"><span data-stu-id="0c56b-115">Type</span></span>| <span data-ttu-id="0c56b-116">説明</span><span class="sxs-lookup"><span data-stu-id="0c56b-116">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="0c56b-117">xuid</span><span class="sxs-lookup"><span data-stu-id="0c56b-117">xuid</span></span>| <span data-ttu-id="0c56b-118">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="0c56b-118">64-bit unsigned integer</span></span>| <span data-ttu-id="0c56b-119">Xbox ユーザー ID (XUID) がタイトル履歴にアクセスしているユーザー。</span><span class="sxs-lookup"><span data-stu-id="0c56b-119">Xbox User ID (XUID) of the user whose title history is being accessed.</span></span>| 
  
<a id="ID4EDB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="0c56b-120">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="0c56b-120">Query string parameters</span></span>
 
| <span data-ttu-id="0c56b-121">パラメーター</span><span class="sxs-lookup"><span data-stu-id="0c56b-121">Parameter</span></span>| <span data-ttu-id="0c56b-122">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="0c56b-122">Required</span></span>| <span data-ttu-id="0c56b-123">種類</span><span class="sxs-lookup"><span data-stu-id="0c56b-123">Type</span></span>| <span data-ttu-id="0c56b-124">説明</span><span class="sxs-lookup"><span data-stu-id="0c56b-124">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0c56b-125">skipItems</span><span class="sxs-lookup"><span data-stu-id="0c56b-125">skipItems</span></span>| <span data-ttu-id="0c56b-126">いいえ</span><span class="sxs-lookup"><span data-stu-id="0c56b-126">No</span></span>| <span data-ttu-id="0c56b-127">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="0c56b-127">32-bit signed integer</span></span>| <span data-ttu-id="0c56b-128">特定の項目数後以降の項目を返します。</span><span class="sxs-lookup"><span data-stu-id="0c56b-128">Return items beginning after the given number of items.</span></span> <span data-ttu-id="0c56b-129">たとえば、 <b>skipItems =「3」</b>項目を取得以降では、4 番目の項目を取得します。</span><span class="sxs-lookup"><span data-stu-id="0c56b-129">For example, <b>skipItems="3"</b> will retrieve items beginning with the fourth item retrieved.</span></span> | 
| <span data-ttu-id="0c56b-130">continuationToken</span><span class="sxs-lookup"><span data-stu-id="0c56b-130">continuationToken</span></span>| <span data-ttu-id="0c56b-131">いいえ</span><span class="sxs-lookup"><span data-stu-id="0c56b-131">No</span></span>| <span data-ttu-id="0c56b-132">string</span><span class="sxs-lookup"><span data-stu-id="0c56b-132">string</span></span>| <span data-ttu-id="0c56b-133">特定の継続トークンで始まる項目を返します。</span><span class="sxs-lookup"><span data-stu-id="0c56b-133">Return the items starting at the given continuation token.</span></span> | 
| <span data-ttu-id="0c56b-134">maxItems</span><span class="sxs-lookup"><span data-stu-id="0c56b-134">maxItems</span></span>| <span data-ttu-id="0c56b-135">いいえ</span><span class="sxs-lookup"><span data-stu-id="0c56b-135">No</span></span>| <span data-ttu-id="0c56b-136">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="0c56b-136">32-bit signed integer</span></span>| <span data-ttu-id="0c56b-137">組み合わせた<b>skipItems</b>と<b>continuationToken</b>項目の範囲を返すことができるコレクションから返される項目の最大数。</span><span class="sxs-lookup"><span data-stu-id="0c56b-137">Maximum number of items to return from the collection, which can be combined with <b>skipItems</b> and <b>continuationToken</b> to return a range of items.</span></span> <span data-ttu-id="0c56b-138">サービスに結果の最後のページが返されていない場合でもは<b>maxItems</b>が存在しないと、 <b>maxItems</b>より少ないを返す可能性がある場合、既定値を提供可能性があります。</span><span class="sxs-lookup"><span data-stu-id="0c56b-138">The service may provide a default value if <b>maxItems</b> is not present, and may return fewer than <b>maxItems</b>, even if the last page of results has not yet been returned.</span></span> | 
  
<a id="ID4EFD"></a>

 
## <a name="authorization"></a><span data-ttu-id="0c56b-139">Authorization</span><span class="sxs-lookup"><span data-stu-id="0c56b-139">Authorization</span></span>
 
| <span data-ttu-id="0c56b-140">要求</span><span class="sxs-lookup"><span data-stu-id="0c56b-140">Claim</span></span>| <span data-ttu-id="0c56b-141">必須?</span><span class="sxs-lookup"><span data-stu-id="0c56b-141">Required?</span></span>| <span data-ttu-id="0c56b-142">説明</span><span class="sxs-lookup"><span data-stu-id="0c56b-142">Description</span></span>| <span data-ttu-id="0c56b-143">不足している場合の動作</span><span class="sxs-lookup"><span data-stu-id="0c56b-143">Behavior if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0c56b-144">ユーザー</span><span class="sxs-lookup"><span data-stu-id="0c56b-144">User</span></span>| <span data-ttu-id="0c56b-145">呼び出し元が、承認された Xbox LIVE ユーザーです。</span><span class="sxs-lookup"><span data-stu-id="0c56b-145">Caller is an authorized Xbox LIVE user.</span></span>| <span data-ttu-id="0c56b-146">呼び出し元では、Xbox LIVE で有効なユーザーを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0c56b-146">The caller needs to be a valid user on Xbox LIVE.</span></span>| <span data-ttu-id="0c56b-147">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="0c56b-147">403 Forbidden</span></span>| 
  
<a id="ID4EGE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="0c56b-148">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0c56b-148">Optional Request Headers</span></span>
 
| <span data-ttu-id="0c56b-149">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0c56b-149">Header</span></span>| <span data-ttu-id="0c56b-150">型</span><span class="sxs-lookup"><span data-stu-id="0c56b-150">Type</span></span>| <span data-ttu-id="0c56b-151">説明</span><span class="sxs-lookup"><span data-stu-id="0c56b-151">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <b><span data-ttu-id="0c56b-152">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="0c56b-152">X-RequestedServiceVersion</span></span></b>| <span data-ttu-id="0c56b-153">string</span><span class="sxs-lookup"><span data-stu-id="0c56b-153">string</span></span>| <span data-ttu-id="0c56b-154">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="0c56b-154">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="0c56b-155">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。</span><span class="sxs-lookup"><span data-stu-id="0c56b-155">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc.</span></span>| 
| <b><span data-ttu-id="0c56b-156">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="0c56b-156">x-xbl-contract-version</span></span></b>| <span data-ttu-id="0c56b-157">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="0c56b-157">32-bit unsigned integer</span></span>| <span data-ttu-id="0c56b-158">存在する場合、2 に設定すると、この API の V2 バージョンが使用されます。</span><span class="sxs-lookup"><span data-stu-id="0c56b-158">If present and set to 2, the V2 version of this API will be used.</span></span> <span data-ttu-id="0c56b-159">それ以外の場合、V1 します。</span><span class="sxs-lookup"><span data-stu-id="0c56b-159">Otherwise, V1.</span></span>| 
  
<a id="ID4ERF"></a>

 
## <a name="request-body"></a><span data-ttu-id="0c56b-160">要求本文</span><span class="sxs-lookup"><span data-stu-id="0c56b-160">Request body</span></span>
 
<span data-ttu-id="0c56b-161">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="0c56b-161">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EDG"></a>

 
## <a name="see-also"></a><span data-ttu-id="0c56b-162">関連項目</span><span class="sxs-lookup"><span data-stu-id="0c56b-162">See also</span></span>
 
<a id="ID4EFG"></a>

 
##### <a name="parent"></a><span data-ttu-id="0c56b-163">Parent</span><span class="sxs-lookup"><span data-stu-id="0c56b-163">Parent</span></span> 

[<span data-ttu-id="0c56b-164">/users/xuid({xuid})/history/titles</span><span class="sxs-lookup"><span data-stu-id="0c56b-164">/users/xuid({xuid})/history/titles</span></span>](uri-titlehistoryusersxuidhistorytitlesv2.md)

  
<a id="ID4EPG"></a>

 
##### <a name="reference"></a><span data-ttu-id="0c56b-165">リファレンス</span><span class="sxs-lookup"><span data-stu-id="0c56b-165">Reference</span></span> 

[<span data-ttu-id="0c56b-166">UserTitle (JSON)</span><span class="sxs-lookup"><span data-stu-id="0c56b-166">UserTitle (JSON)</span></span>](../../json/json-usertitlev2.md)

 [<span data-ttu-id="0c56b-167">PagingInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="0c56b-167">PagingInfo (JSON)</span></span>](../../json/json-paginginfo.md)

 [<span data-ttu-id="0c56b-168">ページング パラメーター</span><span class="sxs-lookup"><span data-stu-id="0c56b-168">Paging Parameters</span></span>](../../additional/pagingparameters.md)

   