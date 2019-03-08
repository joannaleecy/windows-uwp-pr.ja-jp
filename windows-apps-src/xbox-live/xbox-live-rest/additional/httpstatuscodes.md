---
title: 標準の HTTP 状態コード
assetID: 7a19de56-7acd-ad2b-e8e6-53126991093b
permalink: en-us/docs/xboxlive/rest/httpstatuscodes.html
description: " 標準の HTTP 状態コード"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c77972e88dbf4950f716594ee61220d1734a7fef
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57635557"
---
# <a name="standard-http-status-codes"></a><span data-ttu-id="a9fc6-104">標準の HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="a9fc6-104">Standard HTTP status codes</span></span>
 
<span data-ttu-id="a9fc6-105">標準的なハイパー テキスト転送プロトコル (HTTP) には、さまざまなサーバーはクライアント要求への応答で返されるステータス コードがについて説明します。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-105">The Hypertext Transport Protocol (HTTP) standard describes a number of status codes that are returned by the server in response to a client request.</span></span> <span data-ttu-id="a9fc6-106">Xbox Live サービス メソッドでは、要求の状態を記述する HTTP プロトコル準拠ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-106">Xbox Live Services methods return HTTP protocol-compliant status codes to describe the status of the request.</span></span>
 
<span data-ttu-id="a9fc6-107">Xbox Live サービス、およびその一般的な意味で返されるステータス コードの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-107">Here is a list of status codes returned by Xbox Live Services, and their typical meanings.</span></span>
 
<a id="ID4EAB"></a>

 
## <a name="xbox-live-services-status-codes"></a><span data-ttu-id="a9fc6-108">Xbox Live サービスの状態コード</span><span class="sxs-lookup"><span data-stu-id="a9fc6-108">Xbox Live Services Status Codes</span></span>
 
| <span data-ttu-id="a9fc6-109">コード</span><span class="sxs-lookup"><span data-stu-id="a9fc6-109">Code</span></span>| <span data-ttu-id="a9fc6-110">理由語句</span><span class="sxs-lookup"><span data-stu-id="a9fc6-110">Reason phrase</span></span>| <span data-ttu-id="a9fc6-111">説明</span><span class="sxs-lookup"><span data-stu-id="a9fc6-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="a9fc6-112">200</span><span class="sxs-lookup"><span data-stu-id="a9fc6-112">200</span></span>| <span data-ttu-id="a9fc6-113">OK</span><span class="sxs-lookup"><span data-stu-id="a9fc6-113">OK</span></span>| <span data-ttu-id="a9fc6-114">要求が成功します。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-114">The request was successful.</span></span>| 
| <span data-ttu-id="a9fc6-115">201</span><span class="sxs-lookup"><span data-stu-id="a9fc6-115">201</span></span>| <span data-ttu-id="a9fc6-116">作成日</span><span class="sxs-lookup"><span data-stu-id="a9fc6-116">Created</span></span>| <span data-ttu-id="a9fc6-117">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-117">The entity was created.</span></span>| 
| <span data-ttu-id="a9fc6-118">202</span><span class="sxs-lookup"><span data-stu-id="a9fc6-118">202</span></span>| <span data-ttu-id="a9fc6-119">Accepted</span><span class="sxs-lookup"><span data-stu-id="a9fc6-119">Accepted</span></span>| <span data-ttu-id="a9fc6-120">要求は受け入れられましたが、まだ完了していません。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-120">The request was accepted, but has not been completed yet.</span></span>| 
| <span data-ttu-id="a9fc6-121">204</span><span class="sxs-lookup"><span data-stu-id="a9fc6-121">204</span></span>| <span data-ttu-id="a9fc6-122">コンテンツはありません</span><span class="sxs-lookup"><span data-stu-id="a9fc6-122">No Content</span></span>| <span data-ttu-id="a9fc6-123">要求が完了したらが、コンテンツを返すことはありません。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-123">The request has completed, but does not have content to return.</span></span>| 
| <span data-ttu-id="a9fc6-124">301</span><span class="sxs-lookup"><span data-stu-id="a9fc6-124">301</span></span>| <span data-ttu-id="a9fc6-125">完全に移動</span><span class="sxs-lookup"><span data-stu-id="a9fc6-125">Moved Permanently</span></span>| <span data-ttu-id="a9fc6-126">サービスが別の URI に移動します。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-126">The service has moved to a different URI.</span></span>| 
| <span data-ttu-id="a9fc6-127">302</span><span class="sxs-lookup"><span data-stu-id="a9fc6-127">302</span></span>| <span data-ttu-id="a9fc6-128">見つかりません</span><span class="sxs-lookup"><span data-stu-id="a9fc6-128">Found</span></span>| <span data-ttu-id="a9fc6-129">別の uri、要求されたリソースが一時的に存在します。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-129">The requested resource resides temporarily under a different URI.</span></span>| 
| <span data-ttu-id="a9fc6-130">307</span><span class="sxs-lookup"><span data-stu-id="a9fc6-130">307</span></span>| <span data-ttu-id="a9fc6-131">一時的なリダイレクト</span><span class="sxs-lookup"><span data-stu-id="a9fc6-131">Temporary Redirect</span></span>| <span data-ttu-id="a9fc6-132">このリソースの URI が一時的に変更されました。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-132">The URI for this resource has temporarily changed.</span></span>| 
| <span data-ttu-id="a9fc6-133">400</span><span class="sxs-lookup"><span data-stu-id="a9fc6-133">400</span></span>| <span data-ttu-id="a9fc6-134">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="a9fc6-134">Bad Request</span></span>| <span data-ttu-id="a9fc6-135">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-135">Service could not understand malformed request.</span></span> <span data-ttu-id="a9fc6-136">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-136">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="a9fc6-137">401</span><span class="sxs-lookup"><span data-stu-id="a9fc6-137">401</span></span>| <span data-ttu-id="a9fc6-138">権限がありません</span><span class="sxs-lookup"><span data-stu-id="a9fc6-138">Unauthorized</span></span>| <span data-ttu-id="a9fc6-139">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-139">The request requires user authentication.</span></span>| 
| <span data-ttu-id="a9fc6-140">403</span><span class="sxs-lookup"><span data-stu-id="a9fc6-140">403</span></span>| <span data-ttu-id="a9fc6-141">Forbidden</span><span class="sxs-lookup"><span data-stu-id="a9fc6-141">Forbidden</span></span>| <span data-ttu-id="a9fc6-142">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-142">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="a9fc6-143">404</span><span class="sxs-lookup"><span data-stu-id="a9fc6-143">404</span></span>| <span data-ttu-id="a9fc6-144">検出不可</span><span class="sxs-lookup"><span data-stu-id="a9fc6-144">Not Found</span></span>| <span data-ttu-id="a9fc6-145">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-145">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="a9fc6-146">406</span><span class="sxs-lookup"><span data-stu-id="a9fc6-146">406</span></span>| <span data-ttu-id="a9fc6-147">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="a9fc6-147">Not Acceptable</span></span>| <span data-ttu-id="a9fc6-148">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-148">Resource version is not supported.</span></span>| 
| <span data-ttu-id="a9fc6-149">408</span><span class="sxs-lookup"><span data-stu-id="a9fc6-149">408</span></span>| <span data-ttu-id="a9fc6-150">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="a9fc6-150">Request Timeout</span></span>| <span data-ttu-id="a9fc6-151">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-151">The request took too long to complete.</span></span>| 
| <span data-ttu-id="a9fc6-152">409</span><span class="sxs-lookup"><span data-stu-id="a9fc6-152">409</span></span>| <span data-ttu-id="a9fc6-153">Conflict</span><span class="sxs-lookup"><span data-stu-id="a9fc6-153">Conflict</span></span>| <span data-ttu-id="a9fc6-154">リソースの現在の状態と競合するため、要求が完了しませんでした。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-154">The request was not completed due to a conflict with the current state of the resource.</span></span>| 
| <span data-ttu-id="a9fc6-155">410</span><span class="sxs-lookup"><span data-stu-id="a9fc6-155">410</span></span>| <span data-ttu-id="a9fc6-156">なった</span><span class="sxs-lookup"><span data-stu-id="a9fc6-156">Gone</span></span>| <span data-ttu-id="a9fc6-157">要求されたリソースは使用できなくします。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-157">The requested resource is no longer available.</span></span>| 
| <span data-ttu-id="a9fc6-158">412</span><span class="sxs-lookup"><span data-stu-id="a9fc6-158">412</span></span>| <span data-ttu-id="a9fc6-159">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="a9fc6-159">Precondition Failed</span></span>| <span data-ttu-id="a9fc6-160">サーバーには、要求元は、要求に前提条件が満たしていません。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-160">The server does not meet one of the preconditions that the requester put on the request.</span></span>| 
| <span data-ttu-id="a9fc6-161">416</span><span class="sxs-lookup"><span data-stu-id="a9fc6-161">416</span></span>| <span data-ttu-id="a9fc6-162">要求の範囲が満たされていません</span><span class="sxs-lookup"><span data-stu-id="a9fc6-162">Requested Range Not Satisfiable</span></span>| <span data-ttu-id="a9fc6-163">要求された範囲は、ご利用いただけません。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-163">The requested range is not available.</span></span>| 
| <span data-ttu-id="a9fc6-164">500</span><span class="sxs-lookup"><span data-stu-id="a9fc6-164">500</span></span>| <span data-ttu-id="a9fc6-165">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="a9fc6-165">Internal Server Error</span></span>| <span data-ttu-id="a9fc6-166">サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-166">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="a9fc6-167">501</span><span class="sxs-lookup"><span data-stu-id="a9fc6-167">501</span></span>| <span data-ttu-id="a9fc6-168">実装されていません</span><span class="sxs-lookup"><span data-stu-id="a9fc6-168">Not Implemented</span></span>| <span data-ttu-id="a9fc6-169">サーバーは、要求を満たすために必要な機能をサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-169">The server does not support the functionality required to fulfill the request.</span></span>| 
| <span data-ttu-id="a9fc6-170">503</span><span class="sxs-lookup"><span data-stu-id="a9fc6-170">503</span></span>| <span data-ttu-id="a9fc6-171">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="a9fc6-171">Service Unavailable</span></span>| <span data-ttu-id="a9fc6-172">要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-172">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
 

> [!NOTE] 
> <span data-ttu-id="a9fc6-173">一部のリソースとメソッドは、そのリソースまたはメソッドのコンテキスト内で特定のステータス コードの意味について特定の情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-173">Some resources and methods provide specific information about the meaning of particular status codes within the context of that resource or method.</span></span> <span data-ttu-id="a9fc6-174">詳細については、リソースまたは使用しているメソッドは、ドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="a9fc6-174">For more details, refer to the documentation for the resources or methods that you are using.</span></span> 

  
<a id="ID4E3BAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="a9fc6-175">関連項目</span><span class="sxs-lookup"><span data-stu-id="a9fc6-175">See also</span></span>
 
<a id="ID4E5BAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="a9fc6-176">Parent</span><span class="sxs-lookup"><span data-stu-id="a9fc6-176">Parent</span></span>  

[<span data-ttu-id="a9fc6-177">その他の参照</span><span class="sxs-lookup"><span data-stu-id="a9fc6-177">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4EKCAC"></a>

 
##### <a name="reference--universal-resource-identifier-uri-referenceuriatoc-xboxlivews-reference-urismd"></a><span data-ttu-id="a9fc6-178">参照[Universal Resource Identifier (URI) のリファレンス](../uri/atoc-xboxlivews-reference-uris.md)</span><span class="sxs-lookup"><span data-stu-id="a9fc6-178">Reference  [Universal Resource Identifier (URI) Reference](../uri/atoc-xboxlivews-reference-uris.md)</span></span>

 [<span data-ttu-id="a9fc6-179">その他の参照</span><span class="sxs-lookup"><span data-stu-id="a9fc6-179">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4EZCAC"></a>

 
##### <a name="external-links--w3org-http11-status-code-definitionshttpswwww3orgprotocolsrfc2616rfc2616-sec10htmlsec10"></a><span data-ttu-id="a9fc6-180">外部リンク[W3.org:Http/1.1 ステータス コードの定義](https://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html#sec10)</span><span class="sxs-lookup"><span data-stu-id="a9fc6-180">External links  [W3.org: HTTP/1.1 Status Code Definitions](https://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html#sec10)</span></span>

   