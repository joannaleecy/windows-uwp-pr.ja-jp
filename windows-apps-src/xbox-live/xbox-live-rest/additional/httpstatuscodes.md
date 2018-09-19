---
title: 標準の HTTP 状態コード
assetID: 7a19de56-7acd-ad2b-e8e6-53126991093b
permalink: en-us/docs/xboxlive/rest/httpstatuscodes.html
author: KevinAsgari
description: " 標準の HTTP 状態コード"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 856b387825734fb7c6973293bc7004a79d05c207
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4060993"
---
# <a name="standard-http-status-codes"></a><span data-ttu-id="23a34-104">標準の HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="23a34-104">Standard HTTP status codes</span></span>
 
<span data-ttu-id="23a34-105">標準的なハイパー テキスト トランスポート プロトコル (HTTP) では、さまざまなクライアント要求に対する応答としてサーバーによって返されるステータス コードについて説明します。</span><span class="sxs-lookup"><span data-stu-id="23a34-105">The Hypertext Transport Protocol (HTTP) standard describes a number of status codes that are returned by the server in response to a client request.</span></span> <span data-ttu-id="23a34-106">Xbox Live サービスのメソッドは、要求の状態を記述する HTTP プロトコルに準拠した状態コードを返します。</span><span class="sxs-lookup"><span data-stu-id="23a34-106">Xbox Live Services methods return HTTP protocol-compliant status codes to describe the status of the request.</span></span>
 
<span data-ttu-id="23a34-107">Xbox Live サービスとその一般的な意味によって返されるステータス コードの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="23a34-107">Here is a list of status codes returned by Xbox Live Services, and their typical meanings.</span></span>
 
<a id="ID4EAB"></a>

 
## <a name="xbox-live-services-status-codes"></a><span data-ttu-id="23a34-108">Xbox Live サービスの状態コード</span><span class="sxs-lookup"><span data-stu-id="23a34-108">Xbox Live Services Status Codes</span></span>
 
| <span data-ttu-id="23a34-109">コード</span><span class="sxs-lookup"><span data-stu-id="23a34-109">Code</span></span>| <span data-ttu-id="23a34-110">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="23a34-110">Reason phrase</span></span>| <span data-ttu-id="23a34-111">説明</span><span class="sxs-lookup"><span data-stu-id="23a34-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="23a34-112">200</span><span class="sxs-lookup"><span data-stu-id="23a34-112">200</span></span>| <span data-ttu-id="23a34-113">OK</span><span class="sxs-lookup"><span data-stu-id="23a34-113">OK</span></span>| <span data-ttu-id="23a34-114">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="23a34-114">The request was successful.</span></span>| 
| <span data-ttu-id="23a34-115">201</span><span class="sxs-lookup"><span data-stu-id="23a34-115">201</span></span>| <span data-ttu-id="23a34-116">Created</span><span class="sxs-lookup"><span data-stu-id="23a34-116">Created</span></span>| <span data-ttu-id="23a34-117">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="23a34-117">The entity was created.</span></span>| 
| <span data-ttu-id="23a34-118">202</span><span class="sxs-lookup"><span data-stu-id="23a34-118">202</span></span>| <span data-ttu-id="23a34-119">Accepted</span><span class="sxs-lookup"><span data-stu-id="23a34-119">Accepted</span></span>| <span data-ttu-id="23a34-120">要求は受け入れられましたが、まだ完了していません。</span><span class="sxs-lookup"><span data-stu-id="23a34-120">The request was accepted, but has not been completed yet.</span></span>| 
| <span data-ttu-id="23a34-121">204</span><span class="sxs-lookup"><span data-stu-id="23a34-121">204</span></span>| <span data-ttu-id="23a34-122">No Content</span><span class="sxs-lookup"><span data-stu-id="23a34-122">No Content</span></span>| <span data-ttu-id="23a34-123">要求では、完了しましたが、コンテンツに戻すことはありません。</span><span class="sxs-lookup"><span data-stu-id="23a34-123">The request has completed, but does not have content to return.</span></span>| 
| <span data-ttu-id="23a34-124">301</span><span class="sxs-lookup"><span data-stu-id="23a34-124">301</span></span>| <span data-ttu-id="23a34-125">完全に移動</span><span class="sxs-lookup"><span data-stu-id="23a34-125">Moved Permanently</span></span>| <span data-ttu-id="23a34-126">サービスは、さまざまな URI に移動しました。</span><span class="sxs-lookup"><span data-stu-id="23a34-126">The service has moved to a different URI.</span></span>| 
| <span data-ttu-id="23a34-127">302</span><span class="sxs-lookup"><span data-stu-id="23a34-127">302</span></span>| <span data-ttu-id="23a34-128">見つかった</span><span class="sxs-lookup"><span data-stu-id="23a34-128">Found</span></span>| <span data-ttu-id="23a34-129">要求されたリソースは、さまざまな URI で一時的に存在します。</span><span class="sxs-lookup"><span data-stu-id="23a34-129">The requested resource resides temporarily under a different URI.</span></span>| 
| <span data-ttu-id="23a34-130">307</span><span class="sxs-lookup"><span data-stu-id="23a34-130">307</span></span>| <span data-ttu-id="23a34-131">一時的なリダイレクト</span><span class="sxs-lookup"><span data-stu-id="23a34-131">Temporary Redirect</span></span>| <span data-ttu-id="23a34-132">このリソースの URI が一時的に変更されました。</span><span class="sxs-lookup"><span data-stu-id="23a34-132">The URI for this resource has temporarily changed.</span></span>| 
| <span data-ttu-id="23a34-133">400</span><span class="sxs-lookup"><span data-stu-id="23a34-133">400</span></span>| <span data-ttu-id="23a34-134">Bad Request</span><span class="sxs-lookup"><span data-stu-id="23a34-134">Bad Request</span></span>| <span data-ttu-id="23a34-135">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="23a34-135">Service could not understand malformed request.</span></span> <span data-ttu-id="23a34-136">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="23a34-136">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="23a34-137">401</span><span class="sxs-lookup"><span data-stu-id="23a34-137">401</span></span>| <span data-ttu-id="23a34-138">権限がありません</span><span class="sxs-lookup"><span data-stu-id="23a34-138">Unauthorized</span></span>| <span data-ttu-id="23a34-139">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="23a34-139">The request requires user authentication.</span></span>| 
| <span data-ttu-id="23a34-140">403</span><span class="sxs-lookup"><span data-stu-id="23a34-140">403</span></span>| <span data-ttu-id="23a34-141">Forbidden</span><span class="sxs-lookup"><span data-stu-id="23a34-141">Forbidden</span></span>| <span data-ttu-id="23a34-142">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="23a34-142">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="23a34-143">404</span><span class="sxs-lookup"><span data-stu-id="23a34-143">404</span></span>| <span data-ttu-id="23a34-144">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="23a34-144">Not Found</span></span>| <span data-ttu-id="23a34-145">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="23a34-145">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="23a34-146">406</span><span class="sxs-lookup"><span data-stu-id="23a34-146">406</span></span>| <span data-ttu-id="23a34-147">許容できません。</span><span class="sxs-lookup"><span data-stu-id="23a34-147">Not Acceptable</span></span>| <span data-ttu-id="23a34-148">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="23a34-148">Resource version is not supported.</span></span>| 
| <span data-ttu-id="23a34-149">408</span><span class="sxs-lookup"><span data-stu-id="23a34-149">408</span></span>| <span data-ttu-id="23a34-150">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="23a34-150">Request Timeout</span></span>| <span data-ttu-id="23a34-151">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="23a34-151">The request took too long to complete.</span></span>| 
| <span data-ttu-id="23a34-152">409</span><span class="sxs-lookup"><span data-stu-id="23a34-152">409</span></span>| <span data-ttu-id="23a34-153">Conflict</span><span class="sxs-lookup"><span data-stu-id="23a34-153">Conflict</span></span>| <span data-ttu-id="23a34-154">リソースの現在の状態と競合するための要求を完了しませんでした。</span><span class="sxs-lookup"><span data-stu-id="23a34-154">The request was not completed due to a conflict with the current state of the resource.</span></span>| 
| <span data-ttu-id="23a34-155">410</span><span class="sxs-lookup"><span data-stu-id="23a34-155">410</span></span>| <span data-ttu-id="23a34-156">なった</span><span class="sxs-lookup"><span data-stu-id="23a34-156">Gone</span></span>| <span data-ttu-id="23a34-157">要求されたリソースが利用可能ではありません。</span><span class="sxs-lookup"><span data-stu-id="23a34-157">The requested resource is no longer available.</span></span>| 
| <span data-ttu-id="23a34-158">412</span><span class="sxs-lookup"><span data-stu-id="23a34-158">412</span></span>| <span data-ttu-id="23a34-159">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="23a34-159">Precondition Failed</span></span>| <span data-ttu-id="23a34-160">サーバーには、要求者は、要求に前提条件が満たしていません。</span><span class="sxs-lookup"><span data-stu-id="23a34-160">The server does not meet one of the preconditions that the requester put on the request.</span></span>| 
| <span data-ttu-id="23a34-161">416</span><span class="sxs-lookup"><span data-stu-id="23a34-161">416</span></span>| <span data-ttu-id="23a34-162">要求が満たされていない範囲</span><span class="sxs-lookup"><span data-stu-id="23a34-162">Requested Range Not Satisfiable</span></span>| <span data-ttu-id="23a34-163">要求された範囲は利用できません。</span><span class="sxs-lookup"><span data-stu-id="23a34-163">The requested range is not available.</span></span>| 
| <span data-ttu-id="23a34-164">500</span><span class="sxs-lookup"><span data-stu-id="23a34-164">500</span></span>| <span data-ttu-id="23a34-165">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="23a34-165">Internal Server Error</span></span>| <span data-ttu-id="23a34-166">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="23a34-166">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="23a34-167">501</span><span class="sxs-lookup"><span data-stu-id="23a34-167">501</span></span>| <span data-ttu-id="23a34-168">実装されていません。</span><span class="sxs-lookup"><span data-stu-id="23a34-168">Not Implemented</span></span>| <span data-ttu-id="23a34-169">サーバーは、要求を満たすために必要な機能をサポートしません。</span><span class="sxs-lookup"><span data-stu-id="23a34-169">The server does not support the functionality required to fulfill the request.</span></span>| 
| <span data-ttu-id="23a34-170">503</span><span class="sxs-lookup"><span data-stu-id="23a34-170">503</span></span>| <span data-ttu-id="23a34-171">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="23a34-171">Service Unavailable</span></span>| <span data-ttu-id="23a34-172">要求が調整された、クライアント再試行値 (例: 5 秒後) を秒単位で後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="23a34-172">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
 

> [!NOTE] 
> <span data-ttu-id="23a34-173">一部のリソースとメソッドは、そのリソースやメソッドのコンテキスト内で特定の状態コードの意味に関する特定の情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="23a34-173">Some resources and methods provide specific information about the meaning of particular status codes within the context of that resource or method.</span></span> <span data-ttu-id="23a34-174">詳細については、リソースやを使用しているメソッドのドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="23a34-174">For more details, refer to the documentation for the resources or methods that you are using.</span></span> 

  
<a id="ID4E3BAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="23a34-175">関連項目</span><span class="sxs-lookup"><span data-stu-id="23a34-175">See also</span></span>
 
<a id="ID4E5BAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="23a34-176">Parent</span><span class="sxs-lookup"><span data-stu-id="23a34-176">Parent</span></span>  

[<span data-ttu-id="23a34-177">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="23a34-177">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4EKCAC"></a>

 
##### <a name="reference--universal-resource-identifier-uri-referenceuriatoc-xboxlivews-reference-urismd"></a><span data-ttu-id="23a34-178">参照[ユニバーサル リソース識別子 (URI) リファレンス](../uri/atoc-xboxlivews-reference-uris.md)</span><span class="sxs-lookup"><span data-stu-id="23a34-178">Reference  [Universal Resource Identifier (URI) Reference](../uri/atoc-xboxlivews-reference-uris.md)</span></span>

 [<span data-ttu-id="23a34-179">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="23a34-179">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4EZCAC"></a>

 
##### <a name="external-links--w3org-http11-status-code-definitionshttpwwww3orgprotocolsrfc2616rfc2616-sec10htmlsec10"></a><span data-ttu-id="23a34-180">外部リンク[W3.org: http/1.1 ステータス コード定義](http://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html#sec10)</span><span class="sxs-lookup"><span data-stu-id="23a34-180">External links  [W3.org: HTTP/1.1 Status Code Definitions](http://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html#sec10)</span></span>

   