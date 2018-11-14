---
title: DELETE (/users/xuid({xuid})/devices/current/titles/current)
assetID: 3bf75247-0a2a-0e4c-afcc-9e7654a89648
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddevicescurrenttitlescurrentdelete.html
author: KevinAsgari
description: " DELETE (/users/xuid({xuid})/devices/current/titles/current)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 92d2586662121b48701c7eb33f3b8f91e5243bd6
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6251222"
---
# <a name="delete-usersxuidxuiddevicescurrenttitlescurrent"></a><span data-ttu-id="353d6-104">DELETE (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="353d6-104">DELETE (/users/xuid({xuid})/devices/current/titles/current)</span></span>
<span data-ttu-id="353d6-105">[PresenceRecord](../../json/json-presencerecord.md)有効期限が切れるまで待つの終了タイトルのプレゼンスを削除します。</span><span class="sxs-lookup"><span data-stu-id="353d6-105">Remove the presence of a closing title, instead of waiting for the [PresenceRecord](../../json/json-presencerecord.md) to expire.</span></span> <span data-ttu-id="353d6-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="353d6-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="353d6-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="353d6-107">URI parameters</span></span>](#ID4EZ)
  * [<span data-ttu-id="353d6-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="353d6-108">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="353d6-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="353d6-109">Required Request Headers</span></span>](#ID4ERD)
  * [<span data-ttu-id="353d6-110">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="353d6-110">Optional Request Headers</span></span>](#ID4EVF)
  * [<span data-ttu-id="353d6-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="353d6-111">Request body</span></span>](#ID4EVG)
  * [<span data-ttu-id="353d6-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="353d6-112">Response body</span></span>](#ID4EAH)
 
<a id="ID4EZ"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="353d6-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="353d6-113">URI parameters</span></span>
 
| <span data-ttu-id="353d6-114">パラメーター</span><span class="sxs-lookup"><span data-stu-id="353d6-114">Parameter</span></span>| <span data-ttu-id="353d6-115">型</span><span class="sxs-lookup"><span data-stu-id="353d6-115">Type</span></span>| <span data-ttu-id="353d6-116">説明</span><span class="sxs-lookup"><span data-stu-id="353d6-116">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="353d6-117">xuid</span><span class="sxs-lookup"><span data-stu-id="353d6-117">xuid</span></span>| <span data-ttu-id="353d6-118">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="353d6-118">64-bit unsigned integer</span></span>| <span data-ttu-id="353d6-119">Xbox ユーザー ID (XUID) 対象ユーザーのです。</span><span class="sxs-lookup"><span data-stu-id="353d6-119">Xbox User ID (XUID) of the target user.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="353d6-120">Authorization</span><span class="sxs-lookup"><span data-stu-id="353d6-120">Authorization</span></span>
 
| <span data-ttu-id="353d6-121">型</span><span class="sxs-lookup"><span data-stu-id="353d6-121">Type</span></span>| <span data-ttu-id="353d6-122">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="353d6-122">Required</span></span>| <span data-ttu-id="353d6-123">説明</span><span class="sxs-lookup"><span data-stu-id="353d6-123">Description</span></span>| <span data-ttu-id="353d6-124">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="353d6-124">Response if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="353d6-125">XUID</span><span class="sxs-lookup"><span data-stu-id="353d6-125">XUID</span></span>| <span data-ttu-id="353d6-126">はい</span><span class="sxs-lookup"><span data-stu-id="353d6-126">Yes</span></span>| <span data-ttu-id="353d6-127">呼び出し元の Xbox ユーザー ID (XUID)</span><span class="sxs-lookup"><span data-stu-id="353d6-127">Xbox User ID (XUID) of the caller</span></span>| <span data-ttu-id="353d6-128">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="353d6-128">403 Forbidden</span></span>| 
| <span data-ttu-id="353d6-129">titleId</span><span class="sxs-lookup"><span data-stu-id="353d6-129">titleId</span></span>| <span data-ttu-id="353d6-130">はい</span><span class="sxs-lookup"><span data-stu-id="353d6-130">Yes</span></span>| <span data-ttu-id="353d6-131">タイトルの titleId</span><span class="sxs-lookup"><span data-stu-id="353d6-131">titleId of the title</span></span>| <span data-ttu-id="353d6-132">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="353d6-132">403 Forbidden</span></span>| 
| <span data-ttu-id="353d6-133">deviceId</span><span class="sxs-lookup"><span data-stu-id="353d6-133">deviceId</span></span>| <span data-ttu-id="353d6-134">Windows と Web 以外のすべての [はい] します。</span><span class="sxs-lookup"><span data-stu-id="353d6-134">Yes for all except Windows and Web</span></span>| <span data-ttu-id="353d6-135">呼び出し元の deviceId</span><span class="sxs-lookup"><span data-stu-id="353d6-135">deviceId of the caller</span></span>| <span data-ttu-id="353d6-136">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="353d6-136">403 Forbidden</span></span>| 
| <span data-ttu-id="353d6-137">deviceType</span><span class="sxs-lookup"><span data-stu-id="353d6-137">deviceType</span></span>| <span data-ttu-id="353d6-138">Web 以外のすべての [はい]</span><span class="sxs-lookup"><span data-stu-id="353d6-138">Yes for all except Web</span></span>| <span data-ttu-id="353d6-139">呼び出し元の deviceType</span><span class="sxs-lookup"><span data-stu-id="353d6-139">deviceType of the caller</span></span>| <span data-ttu-id="353d6-140">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="353d6-140">403 Forbidden</span></span>| 
  
<a id="ID4ERD"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="353d6-141">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="353d6-141">Required Request Headers</span></span>
 
| <span data-ttu-id="353d6-142">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="353d6-142">Header</span></span>| <span data-ttu-id="353d6-143">型</span><span class="sxs-lookup"><span data-stu-id="353d6-143">Type</span></span>| <span data-ttu-id="353d6-144">説明</span><span class="sxs-lookup"><span data-stu-id="353d6-144">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="353d6-145">Authorization</span><span class="sxs-lookup"><span data-stu-id="353d6-145">Authorization</span></span>| <span data-ttu-id="353d6-146">string</span><span class="sxs-lookup"><span data-stu-id="353d6-146">string</span></span>| <span data-ttu-id="353d6-147">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="353d6-147">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="353d6-148">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="353d6-148">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="353d6-149">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="353d6-149">x-xbl-contract-version</span></span>| <span data-ttu-id="353d6-150">string</span><span class="sxs-lookup"><span data-stu-id="353d6-150">string</span></span>| <span data-ttu-id="353d6-151">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="353d6-151">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="353d6-152">要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの妥当性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="353d6-152">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="353d6-153">値の例: 3, vnext します。</span><span class="sxs-lookup"><span data-stu-id="353d6-153">Example values: 3, vnext.</span></span>| 
| <span data-ttu-id="353d6-154">Content-Type</span><span class="sxs-lookup"><span data-stu-id="353d6-154">Content-Type</span></span>| <span data-ttu-id="353d6-155">string</span><span class="sxs-lookup"><span data-stu-id="353d6-155">string</span></span>| <span data-ttu-id="353d6-156">値の例の要求の本文の mime タイプ: アプリケーション/json します。</span><span class="sxs-lookup"><span data-stu-id="353d6-156">The mime type of the body of the request Example value: application/json.</span></span>| 
| <span data-ttu-id="353d6-157">Content-Length</span><span class="sxs-lookup"><span data-stu-id="353d6-157">Content-Length</span></span>| <span data-ttu-id="353d6-158">string</span><span class="sxs-lookup"><span data-stu-id="353d6-158">string</span></span>| <span data-ttu-id="353d6-159">要求の本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="353d6-159">The length of the request body.</span></span> <span data-ttu-id="353d6-160">値の例: 312 します。</span><span class="sxs-lookup"><span data-stu-id="353d6-160">Example value: 312.</span></span>| 
| <span data-ttu-id="353d6-161">Host</span><span class="sxs-lookup"><span data-stu-id="353d6-161">Host</span></span>| <span data-ttu-id="353d6-162">string</span><span class="sxs-lookup"><span data-stu-id="353d6-162">string</span></span>| <span data-ttu-id="353d6-163">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="353d6-163">Domain name of the server.</span></span> <span data-ttu-id="353d6-164">値の例: presencebeta.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="353d6-164">Example value: presencebeta.xboxlive.com.</span></span>| 
  
<a id="ID4EVF"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="353d6-165">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="353d6-165">Optional Request Headers</span></span>
 
| <span data-ttu-id="353d6-166">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="353d6-166">Header</span></span>| <span data-ttu-id="353d6-167">型</span><span class="sxs-lookup"><span data-stu-id="353d6-167">Type</span></span>| <span data-ttu-id="353d6-168">説明</span><span class="sxs-lookup"><span data-stu-id="353d6-168">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="353d6-169">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="353d6-169">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="353d6-170">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="353d6-170">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="353d6-171">要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの妥当性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="353d6-171">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="353d6-172">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="353d6-172">Default value: 1.</span></span>| 
  
<a id="ID4EVG"></a>

 
## <a name="request-body"></a><span data-ttu-id="353d6-173">要求本文</span><span class="sxs-lookup"><span data-stu-id="353d6-173">Request body</span></span>
 
<span data-ttu-id="353d6-174">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="353d6-174">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EAH"></a>

 
## <a name="response-body"></a><span data-ttu-id="353d6-175">応答本文</span><span class="sxs-lookup"><span data-stu-id="353d6-175">Response body</span></span>
 
<span data-ttu-id="353d6-176">、成功した場合、応答本文の HTTP ステータス コードが返されません。</span><span class="sxs-lookup"><span data-stu-id="353d6-176">In case of success, HTTP status code is returned with no response body.</span></span>
 
<span data-ttu-id="353d6-177">エラー (4 xx の HTTP または 5 xx) の場合は、適切なエラー情報は、応答本文で返されます。</span><span class="sxs-lookup"><span data-stu-id="353d6-177">In case of error (HTTP 4xx or 5xx), appropriate error information is returned in the response body.</span></span>
  
<a id="ID4ELH"></a>

 
## <a name="see-also"></a><span data-ttu-id="353d6-178">関連項目</span><span class="sxs-lookup"><span data-stu-id="353d6-178">See also</span></span>
 
<a id="ID4ENH"></a>

 
##### <a name="parent"></a><span data-ttu-id="353d6-179">Parent</span><span class="sxs-lookup"><span data-stu-id="353d6-179">Parent</span></span> 

[<span data-ttu-id="353d6-180">/users/xuid({xuid})/devices/current/titles/current</span><span class="sxs-lookup"><span data-stu-id="353d6-180">/users/xuid({xuid})/devices/current/titles/current</span></span>](uri-usersxuiddevicescurrenttitlescurrent.md)

   