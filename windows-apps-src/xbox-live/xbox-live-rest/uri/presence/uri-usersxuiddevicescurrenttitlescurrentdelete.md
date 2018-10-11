---
title: DELETE (/users/xuid({xuid})/devices/current/titles/current)
assetID: 3bf75247-0a2a-0e4c-afcc-9e7654a89648
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddevicescurrenttitlescurrentdelete.html
author: KevinAsgari
description: " DELETE (/users/xuid({xuid})/devices/current/titles/current)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 512cb5d65279a461937d91929284b2eb1921ec00
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4540835"
---
# <a name="delete-usersxuidxuiddevicescurrenttitlescurrent"></a><span data-ttu-id="64c51-104">DELETE (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="64c51-104">DELETE (/users/xuid({xuid})/devices/current/titles/current)</span></span>
<span data-ttu-id="64c51-105">[PresenceRecord](../../json/json-presencerecord.md)有効期限が切れるまで待つの終了タイトルのプレゼンスを削除します。</span><span class="sxs-lookup"><span data-stu-id="64c51-105">Remove the presence of a closing title, instead of waiting for the [PresenceRecord](../../json/json-presencerecord.md) to expire.</span></span> <span data-ttu-id="64c51-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="64c51-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="64c51-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="64c51-107">URI parameters</span></span>](#ID4EZ)
  * [<span data-ttu-id="64c51-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="64c51-108">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="64c51-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="64c51-109">Required Request Headers</span></span>](#ID4ERD)
  * [<span data-ttu-id="64c51-110">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="64c51-110">Optional Request Headers</span></span>](#ID4EVF)
  * [<span data-ttu-id="64c51-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="64c51-111">Request body</span></span>](#ID4EVG)
  * [<span data-ttu-id="64c51-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="64c51-112">Response body</span></span>](#ID4EAH)
 
<a id="ID4EZ"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="64c51-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="64c51-113">URI parameters</span></span>
 
| <span data-ttu-id="64c51-114">パラメーター</span><span class="sxs-lookup"><span data-stu-id="64c51-114">Parameter</span></span>| <span data-ttu-id="64c51-115">型</span><span class="sxs-lookup"><span data-stu-id="64c51-115">Type</span></span>| <span data-ttu-id="64c51-116">説明</span><span class="sxs-lookup"><span data-stu-id="64c51-116">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="64c51-117">xuid</span><span class="sxs-lookup"><span data-stu-id="64c51-117">xuid</span></span>| <span data-ttu-id="64c51-118">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="64c51-118">64-bit unsigned integer</span></span>| <span data-ttu-id="64c51-119">Xbox ユーザー ID (XUID) 対象ユーザーのします。</span><span class="sxs-lookup"><span data-stu-id="64c51-119">Xbox User ID (XUID) of the target user.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="64c51-120">Authorization</span><span class="sxs-lookup"><span data-stu-id="64c51-120">Authorization</span></span>
 
| <span data-ttu-id="64c51-121">型</span><span class="sxs-lookup"><span data-stu-id="64c51-121">Type</span></span>| <span data-ttu-id="64c51-122">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="64c51-122">Required</span></span>| <span data-ttu-id="64c51-123">説明</span><span class="sxs-lookup"><span data-stu-id="64c51-123">Description</span></span>| <span data-ttu-id="64c51-124">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="64c51-124">Response if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="64c51-125">XUID</span><span class="sxs-lookup"><span data-stu-id="64c51-125">XUID</span></span>| <span data-ttu-id="64c51-126">はい</span><span class="sxs-lookup"><span data-stu-id="64c51-126">Yes</span></span>| <span data-ttu-id="64c51-127">呼び出し元の Xbox ユーザー ID (XUID)</span><span class="sxs-lookup"><span data-stu-id="64c51-127">Xbox User ID (XUID) of the caller</span></span>| <span data-ttu-id="64c51-128">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="64c51-128">403 Forbidden</span></span>| 
| <span data-ttu-id="64c51-129">titleId</span><span class="sxs-lookup"><span data-stu-id="64c51-129">titleId</span></span>| <span data-ttu-id="64c51-130">はい</span><span class="sxs-lookup"><span data-stu-id="64c51-130">Yes</span></span>| <span data-ttu-id="64c51-131">タイトルのタイトル Id</span><span class="sxs-lookup"><span data-stu-id="64c51-131">titleId of the title</span></span>| <span data-ttu-id="64c51-132">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="64c51-132">403 Forbidden</span></span>| 
| <span data-ttu-id="64c51-133">deviceId</span><span class="sxs-lookup"><span data-stu-id="64c51-133">deviceId</span></span>| <span data-ttu-id="64c51-134">Windows と Web 以外のすべての [はい] します。</span><span class="sxs-lookup"><span data-stu-id="64c51-134">Yes for all except Windows and Web</span></span>| <span data-ttu-id="64c51-135">呼び出し元の deviceId</span><span class="sxs-lookup"><span data-stu-id="64c51-135">deviceId of the caller</span></span>| <span data-ttu-id="64c51-136">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="64c51-136">403 Forbidden</span></span>| 
| <span data-ttu-id="64c51-137">deviceType</span><span class="sxs-lookup"><span data-stu-id="64c51-137">deviceType</span></span>| <span data-ttu-id="64c51-138">Web 以外のすべての [はい]</span><span class="sxs-lookup"><span data-stu-id="64c51-138">Yes for all except Web</span></span>| <span data-ttu-id="64c51-139">呼び出し元の deviceType</span><span class="sxs-lookup"><span data-stu-id="64c51-139">deviceType of the caller</span></span>| <span data-ttu-id="64c51-140">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="64c51-140">403 Forbidden</span></span>| 
  
<a id="ID4ERD"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="64c51-141">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="64c51-141">Required Request Headers</span></span>
 
| <span data-ttu-id="64c51-142">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="64c51-142">Header</span></span>| <span data-ttu-id="64c51-143">型</span><span class="sxs-lookup"><span data-stu-id="64c51-143">Type</span></span>| <span data-ttu-id="64c51-144">説明</span><span class="sxs-lookup"><span data-stu-id="64c51-144">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="64c51-145">Authorization</span><span class="sxs-lookup"><span data-stu-id="64c51-145">Authorization</span></span>| <span data-ttu-id="64c51-146">string</span><span class="sxs-lookup"><span data-stu-id="64c51-146">string</span></span>| <span data-ttu-id="64c51-147">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="64c51-147">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="64c51-148">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="64c51-148">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="64c51-149">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="64c51-149">x-xbl-contract-version</span></span>| <span data-ttu-id="64c51-150">string</span><span class="sxs-lookup"><span data-stu-id="64c51-150">string</span></span>| <span data-ttu-id="64c51-151">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="64c51-151">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="64c51-152">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="64c51-152">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="64c51-153">値の例: 3, vnext します。</span><span class="sxs-lookup"><span data-stu-id="64c51-153">Example values: 3, vnext.</span></span>| 
| <span data-ttu-id="64c51-154">Content-Type</span><span class="sxs-lookup"><span data-stu-id="64c51-154">Content-Type</span></span>| <span data-ttu-id="64c51-155">string</span><span class="sxs-lookup"><span data-stu-id="64c51-155">string</span></span>| <span data-ttu-id="64c51-156">値の例の要求の本文の mime タイプ: アプリケーション/json します。</span><span class="sxs-lookup"><span data-stu-id="64c51-156">The mime type of the body of the request Example value: application/json.</span></span>| 
| <span data-ttu-id="64c51-157">Content-Length</span><span class="sxs-lookup"><span data-stu-id="64c51-157">Content-Length</span></span>| <span data-ttu-id="64c51-158">string</span><span class="sxs-lookup"><span data-stu-id="64c51-158">string</span></span>| <span data-ttu-id="64c51-159">要求の本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="64c51-159">The length of the request body.</span></span> <span data-ttu-id="64c51-160">値の例: 312 します。</span><span class="sxs-lookup"><span data-stu-id="64c51-160">Example value: 312.</span></span>| 
| <span data-ttu-id="64c51-161">Host</span><span class="sxs-lookup"><span data-stu-id="64c51-161">Host</span></span>| <span data-ttu-id="64c51-162">string</span><span class="sxs-lookup"><span data-stu-id="64c51-162">string</span></span>| <span data-ttu-id="64c51-163">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="64c51-163">Domain name of the server.</span></span> <span data-ttu-id="64c51-164">値の例: presencebeta.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="64c51-164">Example value: presencebeta.xboxlive.com.</span></span>| 
  
<a id="ID4EVF"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="64c51-165">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="64c51-165">Optional Request Headers</span></span>
 
| <span data-ttu-id="64c51-166">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="64c51-166">Header</span></span>| <span data-ttu-id="64c51-167">型</span><span class="sxs-lookup"><span data-stu-id="64c51-167">Type</span></span>| <span data-ttu-id="64c51-168">説明</span><span class="sxs-lookup"><span data-stu-id="64c51-168">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="64c51-169">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="64c51-169">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="64c51-170">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="64c51-170">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="64c51-171">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="64c51-171">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="64c51-172">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="64c51-172">Default value: 1.</span></span>| 
  
<a id="ID4EVG"></a>

 
## <a name="request-body"></a><span data-ttu-id="64c51-173">要求本文</span><span class="sxs-lookup"><span data-stu-id="64c51-173">Request body</span></span>
 
<span data-ttu-id="64c51-174">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="64c51-174">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EAH"></a>

 
## <a name="response-body"></a><span data-ttu-id="64c51-175">応答本文</span><span class="sxs-lookup"><span data-stu-id="64c51-175">Response body</span></span>
 
<span data-ttu-id="64c51-176">、成功した場合、応答本文の HTTP ステータス コードが返されません。</span><span class="sxs-lookup"><span data-stu-id="64c51-176">In case of success, HTTP status code is returned with no response body.</span></span>
 
<span data-ttu-id="64c51-177">エラー (HTTP 4 xx または 5 xx) の場合は、適切なエラー情報は、応答本文で返されます。</span><span class="sxs-lookup"><span data-stu-id="64c51-177">In case of error (HTTP 4xx or 5xx), appropriate error information is returned in the response body.</span></span>
  
<a id="ID4ELH"></a>

 
## <a name="see-also"></a><span data-ttu-id="64c51-178">関連項目</span><span class="sxs-lookup"><span data-stu-id="64c51-178">See also</span></span>
 
<a id="ID4ENH"></a>

 
##### <a name="parent"></a><span data-ttu-id="64c51-179">Parent</span><span class="sxs-lookup"><span data-stu-id="64c51-179">Parent</span></span> 

[<span data-ttu-id="64c51-180">/users/xuid({xuid})/devices/current/titles/current</span><span class="sxs-lookup"><span data-stu-id="64c51-180">/users/xuid({xuid})/devices/current/titles/current</span></span>](uri-usersxuiddevicescurrenttitlescurrent.md)

   