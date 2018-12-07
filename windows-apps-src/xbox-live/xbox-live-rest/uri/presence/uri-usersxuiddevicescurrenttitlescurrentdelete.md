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
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8786224"
---
# <a name="delete-usersxuidxuiddevicescurrenttitlescurrent"></a><span data-ttu-id="49e41-104">DELETE (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="49e41-104">DELETE (/users/xuid({xuid})/devices/current/titles/current)</span></span>
<span data-ttu-id="49e41-105">[PresenceRecord](../../json/json-presencerecord.md)有効期限が切れるのを待っているではなく、終了のタイトルのプレゼンスを削除します。</span><span class="sxs-lookup"><span data-stu-id="49e41-105">Remove the presence of a closing title, instead of waiting for the [PresenceRecord](../../json/json-presencerecord.md) to expire.</span></span> <span data-ttu-id="49e41-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="49e41-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="49e41-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="49e41-107">URI parameters</span></span>](#ID4EZ)
  * [<span data-ttu-id="49e41-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="49e41-108">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="49e41-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="49e41-109">Required Request Headers</span></span>](#ID4ERD)
  * [<span data-ttu-id="49e41-110">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="49e41-110">Optional Request Headers</span></span>](#ID4EVF)
  * [<span data-ttu-id="49e41-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="49e41-111">Request body</span></span>](#ID4EVG)
  * [<span data-ttu-id="49e41-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="49e41-112">Response body</span></span>](#ID4EAH)
 
<a id="ID4EZ"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="49e41-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="49e41-113">URI parameters</span></span>
 
| <span data-ttu-id="49e41-114">パラメーター</span><span class="sxs-lookup"><span data-stu-id="49e41-114">Parameter</span></span>| <span data-ttu-id="49e41-115">型</span><span class="sxs-lookup"><span data-stu-id="49e41-115">Type</span></span>| <span data-ttu-id="49e41-116">説明</span><span class="sxs-lookup"><span data-stu-id="49e41-116">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="49e41-117">xuid</span><span class="sxs-lookup"><span data-stu-id="49e41-117">xuid</span></span>| <span data-ttu-id="49e41-118">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="49e41-118">64-bit unsigned integer</span></span>| <span data-ttu-id="49e41-119">Xbox ユーザー ID (XUID) 対象ユーザーのします。</span><span class="sxs-lookup"><span data-stu-id="49e41-119">Xbox User ID (XUID) of the target user.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="49e41-120">Authorization</span><span class="sxs-lookup"><span data-stu-id="49e41-120">Authorization</span></span>
 
| <span data-ttu-id="49e41-121">型</span><span class="sxs-lookup"><span data-stu-id="49e41-121">Type</span></span>| <span data-ttu-id="49e41-122">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="49e41-122">Required</span></span>| <span data-ttu-id="49e41-123">説明</span><span class="sxs-lookup"><span data-stu-id="49e41-123">Description</span></span>| <span data-ttu-id="49e41-124">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="49e41-124">Response if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="49e41-125">XUID</span><span class="sxs-lookup"><span data-stu-id="49e41-125">XUID</span></span>| <span data-ttu-id="49e41-126">はい</span><span class="sxs-lookup"><span data-stu-id="49e41-126">Yes</span></span>| <span data-ttu-id="49e41-127">呼び出し元の Xbox ユーザー ID (XUID)</span><span class="sxs-lookup"><span data-stu-id="49e41-127">Xbox User ID (XUID) of the caller</span></span>| <span data-ttu-id="49e41-128">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="49e41-128">403 Forbidden</span></span>| 
| <span data-ttu-id="49e41-129">titleId</span><span class="sxs-lookup"><span data-stu-id="49e41-129">titleId</span></span>| <span data-ttu-id="49e41-130">はい</span><span class="sxs-lookup"><span data-stu-id="49e41-130">Yes</span></span>| <span data-ttu-id="49e41-131">タイトルの titleId</span><span class="sxs-lookup"><span data-stu-id="49e41-131">titleId of the title</span></span>| <span data-ttu-id="49e41-132">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="49e41-132">403 Forbidden</span></span>| 
| <span data-ttu-id="49e41-133">deviceId</span><span class="sxs-lookup"><span data-stu-id="49e41-133">deviceId</span></span>| <span data-ttu-id="49e41-134">Windows と Web 以外のすべての [はい] します。</span><span class="sxs-lookup"><span data-stu-id="49e41-134">Yes for all except Windows and Web</span></span>| <span data-ttu-id="49e41-135">呼び出し元の deviceId</span><span class="sxs-lookup"><span data-stu-id="49e41-135">deviceId of the caller</span></span>| <span data-ttu-id="49e41-136">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="49e41-136">403 Forbidden</span></span>| 
| <span data-ttu-id="49e41-137">deviceType</span><span class="sxs-lookup"><span data-stu-id="49e41-137">deviceType</span></span>| <span data-ttu-id="49e41-138">Web 以外のすべての [はい]</span><span class="sxs-lookup"><span data-stu-id="49e41-138">Yes for all except Web</span></span>| <span data-ttu-id="49e41-139">呼び出し元の deviceType</span><span class="sxs-lookup"><span data-stu-id="49e41-139">deviceType of the caller</span></span>| <span data-ttu-id="49e41-140">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="49e41-140">403 Forbidden</span></span>| 
  
<a id="ID4ERD"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="49e41-141">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="49e41-141">Required Request Headers</span></span>
 
| <span data-ttu-id="49e41-142">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="49e41-142">Header</span></span>| <span data-ttu-id="49e41-143">型</span><span class="sxs-lookup"><span data-stu-id="49e41-143">Type</span></span>| <span data-ttu-id="49e41-144">説明</span><span class="sxs-lookup"><span data-stu-id="49e41-144">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="49e41-145">Authorization</span><span class="sxs-lookup"><span data-stu-id="49e41-145">Authorization</span></span>| <span data-ttu-id="49e41-146">string</span><span class="sxs-lookup"><span data-stu-id="49e41-146">string</span></span>| <span data-ttu-id="49e41-147">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="49e41-147">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="49e41-148">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="49e41-148">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
| <span data-ttu-id="49e41-149">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="49e41-149">x-xbl-contract-version</span></span>| <span data-ttu-id="49e41-150">string</span><span class="sxs-lookup"><span data-stu-id="49e41-150">string</span></span>| <span data-ttu-id="49e41-151">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="49e41-151">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="49e41-152">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="49e41-152">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="49e41-153">値の例: 3, vnext します。</span><span class="sxs-lookup"><span data-stu-id="49e41-153">Example values: 3, vnext.</span></span>| 
| <span data-ttu-id="49e41-154">Content-Type</span><span class="sxs-lookup"><span data-stu-id="49e41-154">Content-Type</span></span>| <span data-ttu-id="49e41-155">string</span><span class="sxs-lookup"><span data-stu-id="49e41-155">string</span></span>| <span data-ttu-id="49e41-156">値の例の要求の本文の mime タイプ: アプリケーション/json します。</span><span class="sxs-lookup"><span data-stu-id="49e41-156">The mime type of the body of the request Example value: application/json.</span></span>| 
| <span data-ttu-id="49e41-157">Content-Length</span><span class="sxs-lookup"><span data-stu-id="49e41-157">Content-Length</span></span>| <span data-ttu-id="49e41-158">string</span><span class="sxs-lookup"><span data-stu-id="49e41-158">string</span></span>| <span data-ttu-id="49e41-159">要求の本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="49e41-159">The length of the request body.</span></span> <span data-ttu-id="49e41-160">値の例: 312 します。</span><span class="sxs-lookup"><span data-stu-id="49e41-160">Example value: 312.</span></span>| 
| <span data-ttu-id="49e41-161">Host</span><span class="sxs-lookup"><span data-stu-id="49e41-161">Host</span></span>| <span data-ttu-id="49e41-162">string</span><span class="sxs-lookup"><span data-stu-id="49e41-162">string</span></span>| <span data-ttu-id="49e41-163">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="49e41-163">Domain name of the server.</span></span> <span data-ttu-id="49e41-164">値の例: presencebeta.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="49e41-164">Example value: presencebeta.xboxlive.com.</span></span>| 
  
<a id="ID4EVF"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="49e41-165">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="49e41-165">Optional Request Headers</span></span>
 
| <span data-ttu-id="49e41-166">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="49e41-166">Header</span></span>| <span data-ttu-id="49e41-167">型</span><span class="sxs-lookup"><span data-stu-id="49e41-167">Type</span></span>| <span data-ttu-id="49e41-168">説明</span><span class="sxs-lookup"><span data-stu-id="49e41-168">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="49e41-169">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="49e41-169">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="49e41-170">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="49e41-170">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="49e41-171">要求がのみにルーティングと、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="49e41-171">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="49e41-172">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="49e41-172">Default value: 1.</span></span>| 
  
<a id="ID4EVG"></a>

 
## <a name="request-body"></a><span data-ttu-id="49e41-173">要求本文</span><span class="sxs-lookup"><span data-stu-id="49e41-173">Request body</span></span>
 
<span data-ttu-id="49e41-174">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="49e41-174">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EAH"></a>

 
## <a name="response-body"></a><span data-ttu-id="49e41-175">応答本文</span><span class="sxs-lookup"><span data-stu-id="49e41-175">Response body</span></span>
 
<span data-ttu-id="49e41-176">、成功した場合、応答本文の HTTP ステータス コードが返されません。</span><span class="sxs-lookup"><span data-stu-id="49e41-176">In case of success, HTTP status code is returned with no response body.</span></span>
 
<span data-ttu-id="49e41-177">エラー (4 xx の HTTP または 5 xx) の場合は、適切なエラー情報は、応答本文で返されます。</span><span class="sxs-lookup"><span data-stu-id="49e41-177">In case of error (HTTP 4xx or 5xx), appropriate error information is returned in the response body.</span></span>
  
<a id="ID4ELH"></a>

 
## <a name="see-also"></a><span data-ttu-id="49e41-178">関連項目</span><span class="sxs-lookup"><span data-stu-id="49e41-178">See also</span></span>
 
<a id="ID4ENH"></a>

 
##### <a name="parent"></a><span data-ttu-id="49e41-179">Parent</span><span class="sxs-lookup"><span data-stu-id="49e41-179">Parent</span></span> 

[<span data-ttu-id="49e41-180">/users/xuid({xuid})/devices/current/titles/current</span><span class="sxs-lookup"><span data-stu-id="49e41-180">/users/xuid({xuid})/devices/current/titles/current</span></span>](uri-usersxuiddevicescurrenttitlescurrent.md)

   