---
title: DELETE (/users/xuid({xuid})/devices/current/titles/current)
assetID: 3bf75247-0a2a-0e4c-afcc-9e7654a89648
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddevicescurrenttitlescurrentdelete.html
description: " DELETE (/users/xuid({xuid})/devices/current/titles/current)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dd916fee5455276d45e4437e4ee90cacbde30bf9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57604217"
---
# <a name="delete-usersxuidxuiddevicescurrenttitlescurrent"></a><span data-ttu-id="e755d-104">DELETE (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="e755d-104">DELETE (/users/xuid({xuid})/devices/current/titles/current)</span></span>
<span data-ttu-id="e755d-105">待つのではなく、終了のタイトルのプレゼンスを削除、 [PresenceRecord](../../json/json-presencerecord.md)期限切れにします。</span><span class="sxs-lookup"><span data-stu-id="e755d-105">Remove the presence of a closing title, instead of waiting for the [PresenceRecord](../../json/json-presencerecord.md) to expire.</span></span> <span data-ttu-id="e755d-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="e755d-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="e755d-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e755d-107">URI parameters</span></span>](#ID4EZ)
  * [<span data-ttu-id="e755d-108">承認</span><span class="sxs-lookup"><span data-stu-id="e755d-108">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="e755d-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e755d-109">Required Request Headers</span></span>](#ID4ERD)
  * [<span data-ttu-id="e755d-110">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e755d-110">Optional Request Headers</span></span>](#ID4EVF)
  * [<span data-ttu-id="e755d-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="e755d-111">Request body</span></span>](#ID4EVG)
  * [<span data-ttu-id="e755d-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="e755d-112">Response body</span></span>](#ID4EAH)
 
<a id="ID4EZ"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="e755d-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e755d-113">URI parameters</span></span>
 
| <span data-ttu-id="e755d-114">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e755d-114">Parameter</span></span>| <span data-ttu-id="e755d-115">種類</span><span class="sxs-lookup"><span data-stu-id="e755d-115">Type</span></span>| <span data-ttu-id="e755d-116">説明</span><span class="sxs-lookup"><span data-stu-id="e755d-116">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="e755d-117">xuid</span><span class="sxs-lookup"><span data-stu-id="e755d-117">xuid</span></span>| <span data-ttu-id="e755d-118">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="e755d-118">64-bit unsigned integer</span></span>| <span data-ttu-id="e755d-119">Xbox ユーザー ID (XUID) の対象ユーザーです。</span><span class="sxs-lookup"><span data-stu-id="e755d-119">Xbox User ID (XUID) of the target user.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="e755d-120">Authorization</span><span class="sxs-lookup"><span data-stu-id="e755d-120">Authorization</span></span>
 
| <span data-ttu-id="e755d-121">種類</span><span class="sxs-lookup"><span data-stu-id="e755d-121">Type</span></span>| <span data-ttu-id="e755d-122">必須</span><span class="sxs-lookup"><span data-stu-id="e755d-122">Required</span></span>| <span data-ttu-id="e755d-123">説明</span><span class="sxs-lookup"><span data-stu-id="e755d-123">Description</span></span>| <span data-ttu-id="e755d-124">不足している場合の応答</span><span class="sxs-lookup"><span data-stu-id="e755d-124">Response if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e755d-125">XUID</span><span class="sxs-lookup"><span data-stu-id="e755d-125">XUID</span></span>| <span data-ttu-id="e755d-126">〇</span><span class="sxs-lookup"><span data-stu-id="e755d-126">Yes</span></span>| <span data-ttu-id="e755d-127">呼び出し元の Xbox ユーザー ID (XUID)</span><span class="sxs-lookup"><span data-stu-id="e755d-127">Xbox User ID (XUID) of the caller</span></span>| <span data-ttu-id="e755d-128">403 許可されていません</span><span class="sxs-lookup"><span data-stu-id="e755d-128">403 Forbidden</span></span>| 
| <span data-ttu-id="e755d-129">titleId</span><span class="sxs-lookup"><span data-stu-id="e755d-129">titleId</span></span>| <span data-ttu-id="e755d-130">〇</span><span class="sxs-lookup"><span data-stu-id="e755d-130">Yes</span></span>| <span data-ttu-id="e755d-131">タイトルのタイトルの Id</span><span class="sxs-lookup"><span data-stu-id="e755d-131">titleId of the title</span></span>| <span data-ttu-id="e755d-132">403 許可されていません</span><span class="sxs-lookup"><span data-stu-id="e755d-132">403 Forbidden</span></span>| 
| <span data-ttu-id="e755d-133">deviceId</span><span class="sxs-lookup"><span data-stu-id="e755d-133">deviceId</span></span>| <span data-ttu-id="e755d-134">Windows と Web 以外のすべての場合ははい</span><span class="sxs-lookup"><span data-stu-id="e755d-134">Yes for all except Windows and Web</span></span>| <span data-ttu-id="e755d-135">呼び出し元の deviceId</span><span class="sxs-lookup"><span data-stu-id="e755d-135">deviceId of the caller</span></span>| <span data-ttu-id="e755d-136">403 許可されていません</span><span class="sxs-lookup"><span data-stu-id="e755d-136">403 Forbidden</span></span>| 
| <span data-ttu-id="e755d-137">deviceType</span><span class="sxs-lookup"><span data-stu-id="e755d-137">deviceType</span></span>| <span data-ttu-id="e755d-138">Web 以外のすべての場合ははい</span><span class="sxs-lookup"><span data-stu-id="e755d-138">Yes for all except Web</span></span>| <span data-ttu-id="e755d-139">呼び出し元の deviceType</span><span class="sxs-lookup"><span data-stu-id="e755d-139">deviceType of the caller</span></span>| <span data-ttu-id="e755d-140">403 許可されていません</span><span class="sxs-lookup"><span data-stu-id="e755d-140">403 Forbidden</span></span>| 
  
<a id="ID4ERD"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="e755d-141">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e755d-141">Required Request Headers</span></span>
 
| <span data-ttu-id="e755d-142">Header</span><span class="sxs-lookup"><span data-stu-id="e755d-142">Header</span></span>| <span data-ttu-id="e755d-143">種類</span><span class="sxs-lookup"><span data-stu-id="e755d-143">Type</span></span>| <span data-ttu-id="e755d-144">説明</span><span class="sxs-lookup"><span data-stu-id="e755d-144">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e755d-145">Authorization</span><span class="sxs-lookup"><span data-stu-id="e755d-145">Authorization</span></span>| <span data-ttu-id="e755d-146">string</span><span class="sxs-lookup"><span data-stu-id="e755d-146">string</span></span>| <span data-ttu-id="e755d-147">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="e755d-147">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="e755d-148">値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="e755d-148">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="e755d-149">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="e755d-149">x-xbl-contract-version</span></span>| <span data-ttu-id="e755d-150">string</span><span class="sxs-lookup"><span data-stu-id="e755d-150">string</span></span>| <span data-ttu-id="e755d-151">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="e755d-151">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="e755d-152">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="e755d-152">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="e755d-153">値の例:3、vnext。</span><span class="sxs-lookup"><span data-stu-id="e755d-153">Example values: 3, vnext.</span></span>| 
| <span data-ttu-id="e755d-154">Content-Type</span><span class="sxs-lookup"><span data-stu-id="e755d-154">Content-Type</span></span>| <span data-ttu-id="e755d-155">string</span><span class="sxs-lookup"><span data-stu-id="e755d-155">string</span></span>| <span data-ttu-id="e755d-156">要求の値の例の本文の mime の種類: アプリケーション/json します。</span><span class="sxs-lookup"><span data-stu-id="e755d-156">The mime type of the body of the request Example value: application/json.</span></span>| 
| <span data-ttu-id="e755d-157">Content-Length</span><span class="sxs-lookup"><span data-stu-id="e755d-157">Content-Length</span></span>| <span data-ttu-id="e755d-158">string</span><span class="sxs-lookup"><span data-stu-id="e755d-158">string</span></span>| <span data-ttu-id="e755d-159">要求の本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="e755d-159">The length of the request body.</span></span> <span data-ttu-id="e755d-160">値の例:312.</span><span class="sxs-lookup"><span data-stu-id="e755d-160">Example value: 312.</span></span>| 
| <span data-ttu-id="e755d-161">Host</span><span class="sxs-lookup"><span data-stu-id="e755d-161">Host</span></span>| <span data-ttu-id="e755d-162">string</span><span class="sxs-lookup"><span data-stu-id="e755d-162">string</span></span>| <span data-ttu-id="e755d-163">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="e755d-163">Domain name of the server.</span></span> <span data-ttu-id="e755d-164">値の例: presencebeta.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="e755d-164">Example value: presencebeta.xboxlive.com.</span></span>| 
  
<a id="ID4EVF"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="e755d-165">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e755d-165">Optional Request Headers</span></span>
 
| <span data-ttu-id="e755d-166">Header</span><span class="sxs-lookup"><span data-stu-id="e755d-166">Header</span></span>| <span data-ttu-id="e755d-167">種類</span><span class="sxs-lookup"><span data-stu-id="e755d-167">Type</span></span>| <span data-ttu-id="e755d-168">説明</span><span class="sxs-lookup"><span data-stu-id="e755d-168">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e755d-169">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="e755d-169">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="e755d-170">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="e755d-170">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="e755d-171">要求はのみにルーティングし、サービスの認証トークンの要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="e755d-171">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="e755d-172">［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="e755d-172">Default value: 1.</span></span>| 
  
<a id="ID4EVG"></a>

 
## <a name="request-body"></a><span data-ttu-id="e755d-173">要求本文</span><span class="sxs-lookup"><span data-stu-id="e755d-173">Request body</span></span>
 
<span data-ttu-id="e755d-174">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="e755d-174">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EAH"></a>

 
## <a name="response-body"></a><span data-ttu-id="e755d-175">応答本文</span><span class="sxs-lookup"><span data-stu-id="e755d-175">Response body</span></span>
 
<span data-ttu-id="e755d-176">成功した場合が発生した場合、応答本文なしで HTTP ステータス コードが返されます。</span><span class="sxs-lookup"><span data-stu-id="e755d-176">In case of success, HTTP status code is returned with no response body.</span></span>
 
<span data-ttu-id="e755d-177">エラー (HTTP 4 xx または 5 xx) が発生した場合は、適切なエラー情報は、応答本文で返されます。</span><span class="sxs-lookup"><span data-stu-id="e755d-177">In case of error (HTTP 4xx or 5xx), appropriate error information is returned in the response body.</span></span>
  
<a id="ID4ELH"></a>

 
## <a name="see-also"></a><span data-ttu-id="e755d-178">関連項目</span><span class="sxs-lookup"><span data-stu-id="e755d-178">See also</span></span>
 
<a id="ID4ENH"></a>

 
##### <a name="parent"></a><span data-ttu-id="e755d-179">Parent</span><span class="sxs-lookup"><span data-stu-id="e755d-179">Parent</span></span> 

[<span data-ttu-id="e755d-180">/users/xuid({xuid})/devices/current/titles/current</span><span class="sxs-lookup"><span data-stu-id="e755d-180">/users/xuid({xuid})/devices/current/titles/current</span></span>](uri-usersxuiddevicescurrenttitlescurrent.md)

   