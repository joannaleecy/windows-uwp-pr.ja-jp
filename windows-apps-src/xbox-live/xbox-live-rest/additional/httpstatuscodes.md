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
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4385572"
---
# <a name="standard-http-status-codes"></a><span data-ttu-id="66976-104">標準の HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="66976-104">Standard HTTP status codes</span></span>
 
<span data-ttu-id="66976-105">標準的なハイパー テキスト トランスポート プロトコル (HTTP) では、さまざまなクライアント要求に対する応答としてサーバーによって返されるステータス コードについて説明します。</span><span class="sxs-lookup"><span data-stu-id="66976-105">The Hypertext Transport Protocol (HTTP) standard describes a number of status codes that are returned by the server in response to a client request.</span></span> <span data-ttu-id="66976-106">Xbox Live サービスのメソッドは、要求の状態を記述する HTTP プロトコルに準拠した状態コードを返します。</span><span class="sxs-lookup"><span data-stu-id="66976-106">Xbox Live Services methods return HTTP protocol-compliant status codes to describe the status of the request.</span></span>
 
<span data-ttu-id="66976-107">Xbox Live サービスとその一般的な意味によって返されるステータス コードの一覧を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="66976-107">Here is a list of status codes returned by Xbox Live Services, and their typical meanings.</span></span>
 
<a id="ID4EAB"></a>

 
## <a name="xbox-live-services-status-codes"></a><span data-ttu-id="66976-108">Xbox Live サービスの状態コード</span><span class="sxs-lookup"><span data-stu-id="66976-108">Xbox Live Services Status Codes</span></span>
 
| <span data-ttu-id="66976-109">コード</span><span class="sxs-lookup"><span data-stu-id="66976-109">Code</span></span>| <span data-ttu-id="66976-110">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="66976-110">Reason phrase</span></span>| <span data-ttu-id="66976-111">説明</span><span class="sxs-lookup"><span data-stu-id="66976-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="66976-112">200</span><span class="sxs-lookup"><span data-stu-id="66976-112">200</span></span>| <span data-ttu-id="66976-113">OK</span><span class="sxs-lookup"><span data-stu-id="66976-113">OK</span></span>| <span data-ttu-id="66976-114">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="66976-114">The request was successful.</span></span>| 
| <span data-ttu-id="66976-115">201</span><span class="sxs-lookup"><span data-stu-id="66976-115">201</span></span>| <span data-ttu-id="66976-116">Created</span><span class="sxs-lookup"><span data-stu-id="66976-116">Created</span></span>| <span data-ttu-id="66976-117">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="66976-117">The entity was created.</span></span>| 
| <span data-ttu-id="66976-118">202</span><span class="sxs-lookup"><span data-stu-id="66976-118">202</span></span>| <span data-ttu-id="66976-119">Accepted</span><span class="sxs-lookup"><span data-stu-id="66976-119">Accepted</span></span>| <span data-ttu-id="66976-120">要求は受け入れられましたが、まだ完了していません。</span><span class="sxs-lookup"><span data-stu-id="66976-120">The request was accepted, but has not been completed yet.</span></span>| 
| <span data-ttu-id="66976-121">204</span><span class="sxs-lookup"><span data-stu-id="66976-121">204</span></span>| <span data-ttu-id="66976-122">No Content</span><span class="sxs-lookup"><span data-stu-id="66976-122">No Content</span></span>| <span data-ttu-id="66976-123">要求では、完了しましたが、コンテンツに戻すことはありません。</span><span class="sxs-lookup"><span data-stu-id="66976-123">The request has completed, but does not have content to return.</span></span>| 
| <span data-ttu-id="66976-124">301</span><span class="sxs-lookup"><span data-stu-id="66976-124">301</span></span>| <span data-ttu-id="66976-125">完全に移動</span><span class="sxs-lookup"><span data-stu-id="66976-125">Moved Permanently</span></span>| <span data-ttu-id="66976-126">サービスは、さまざまな URI に移動しました。</span><span class="sxs-lookup"><span data-stu-id="66976-126">The service has moved to a different URI.</span></span>| 
| <span data-ttu-id="66976-127">302</span><span class="sxs-lookup"><span data-stu-id="66976-127">302</span></span>| <span data-ttu-id="66976-128">見つかった</span><span class="sxs-lookup"><span data-stu-id="66976-128">Found</span></span>| <span data-ttu-id="66976-129">要求されたリソースは、さまざまな URI で一時的に存在します。</span><span class="sxs-lookup"><span data-stu-id="66976-129">The requested resource resides temporarily under a different URI.</span></span>| 
| <span data-ttu-id="66976-130">307</span><span class="sxs-lookup"><span data-stu-id="66976-130">307</span></span>| <span data-ttu-id="66976-131">一時的なリダイレクト</span><span class="sxs-lookup"><span data-stu-id="66976-131">Temporary Redirect</span></span>| <span data-ttu-id="66976-132">このリソースの URI が一時的に変更されました。</span><span class="sxs-lookup"><span data-stu-id="66976-132">The URI for this resource has temporarily changed.</span></span>| 
| <span data-ttu-id="66976-133">400</span><span class="sxs-lookup"><span data-stu-id="66976-133">400</span></span>| <span data-ttu-id="66976-134">Bad Request</span><span class="sxs-lookup"><span data-stu-id="66976-134">Bad Request</span></span>| <span data-ttu-id="66976-135">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="66976-135">Service could not understand malformed request.</span></span> <span data-ttu-id="66976-136">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="66976-136">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="66976-137">401</span><span class="sxs-lookup"><span data-stu-id="66976-137">401</span></span>| <span data-ttu-id="66976-138">権限がありません</span><span class="sxs-lookup"><span data-stu-id="66976-138">Unauthorized</span></span>| <span data-ttu-id="66976-139">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="66976-139">The request requires user authentication.</span></span>| 
| <span data-ttu-id="66976-140">403</span><span class="sxs-lookup"><span data-stu-id="66976-140">403</span></span>| <span data-ttu-id="66976-141">Forbidden</span><span class="sxs-lookup"><span data-stu-id="66976-141">Forbidden</span></span>| <span data-ttu-id="66976-142">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="66976-142">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="66976-143">404</span><span class="sxs-lookup"><span data-stu-id="66976-143">404</span></span>| <span data-ttu-id="66976-144">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="66976-144">Not Found</span></span>| <span data-ttu-id="66976-145">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="66976-145">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="66976-146">406</span><span class="sxs-lookup"><span data-stu-id="66976-146">406</span></span>| <span data-ttu-id="66976-147">許容できません。</span><span class="sxs-lookup"><span data-stu-id="66976-147">Not Acceptable</span></span>| <span data-ttu-id="66976-148">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="66976-148">Resource version is not supported.</span></span>| 
| <span data-ttu-id="66976-149">408</span><span class="sxs-lookup"><span data-stu-id="66976-149">408</span></span>| <span data-ttu-id="66976-150">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="66976-150">Request Timeout</span></span>| <span data-ttu-id="66976-151">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="66976-151">The request took too long to complete.</span></span>| 
| <span data-ttu-id="66976-152">409</span><span class="sxs-lookup"><span data-stu-id="66976-152">409</span></span>| <span data-ttu-id="66976-153">Conflict</span><span class="sxs-lookup"><span data-stu-id="66976-153">Conflict</span></span>| <span data-ttu-id="66976-154">リソースの現在の状態と競合するため、要求を完了しませんでした。</span><span class="sxs-lookup"><span data-stu-id="66976-154">The request was not completed due to a conflict with the current state of the resource.</span></span>| 
| <span data-ttu-id="66976-155">410</span><span class="sxs-lookup"><span data-stu-id="66976-155">410</span></span>| <span data-ttu-id="66976-156">なった</span><span class="sxs-lookup"><span data-stu-id="66976-156">Gone</span></span>| <span data-ttu-id="66976-157">要求されたリソースが利用可能ではなくなりました。</span><span class="sxs-lookup"><span data-stu-id="66976-157">The requested resource is no longer available.</span></span>| 
| <span data-ttu-id="66976-158">412</span><span class="sxs-lookup"><span data-stu-id="66976-158">412</span></span>| <span data-ttu-id="66976-159">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="66976-159">Precondition Failed</span></span>| <span data-ttu-id="66976-160">サーバーには、要求者は、要求に前提条件が満たしていません。</span><span class="sxs-lookup"><span data-stu-id="66976-160">The server does not meet one of the preconditions that the requester put on the request.</span></span>| 
| <span data-ttu-id="66976-161">416</span><span class="sxs-lookup"><span data-stu-id="66976-161">416</span></span>| <span data-ttu-id="66976-162">範囲が満たされていませんが要求</span><span class="sxs-lookup"><span data-stu-id="66976-162">Requested Range Not Satisfiable</span></span>| <span data-ttu-id="66976-163">要求された範囲は利用できません。</span><span class="sxs-lookup"><span data-stu-id="66976-163">The requested range is not available.</span></span>| 
| <span data-ttu-id="66976-164">500</span><span class="sxs-lookup"><span data-stu-id="66976-164">500</span></span>| <span data-ttu-id="66976-165">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="66976-165">Internal Server Error</span></span>| <span data-ttu-id="66976-166">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="66976-166">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="66976-167">501</span><span class="sxs-lookup"><span data-stu-id="66976-167">501</span></span>| <span data-ttu-id="66976-168">実装されていません。</span><span class="sxs-lookup"><span data-stu-id="66976-168">Not Implemented</span></span>| <span data-ttu-id="66976-169">サーバーは、要求を満たすために必要な機能をサポートしません。</span><span class="sxs-lookup"><span data-stu-id="66976-169">The server does not support the functionality required to fulfill the request.</span></span>| 
| <span data-ttu-id="66976-170">503</span><span class="sxs-lookup"><span data-stu-id="66976-170">503</span></span>| <span data-ttu-id="66976-171">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="66976-171">Service Unavailable</span></span>| <span data-ttu-id="66976-172">要求が調整された、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="66976-172">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
 

> [!NOTE] 
> <span data-ttu-id="66976-173">一部のリソースとメソッドは、そのリソースやメソッドのコンテキスト内で特定の状態コードの意味の特定の情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="66976-173">Some resources and methods provide specific information about the meaning of particular status codes within the context of that resource or method.</span></span> <span data-ttu-id="66976-174">詳細については、リソースまたはを使用しているメソッドのドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="66976-174">For more details, refer to the documentation for the resources or methods that you are using.</span></span> 

  
<a id="ID4E3BAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="66976-175">関連項目</span><span class="sxs-lookup"><span data-stu-id="66976-175">See also</span></span>
 
<a id="ID4E5BAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="66976-176">Parent</span><span class="sxs-lookup"><span data-stu-id="66976-176">Parent</span></span>  

[<span data-ttu-id="66976-177">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="66976-177">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4EKCAC"></a>

 
##### <a name="reference--universal-resource-identifier-uri-referenceuriatoc-xboxlivews-reference-urismd"></a><span data-ttu-id="66976-178">参照[ユニバーサル リソース識別子 (URI) リファレンス](../uri/atoc-xboxlivews-reference-uris.md)</span><span class="sxs-lookup"><span data-stu-id="66976-178">Reference  [Universal Resource Identifier (URI) Reference](../uri/atoc-xboxlivews-reference-uris.md)</span></span>

 [<span data-ttu-id="66976-179">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="66976-179">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4EZCAC"></a>

 
##### <a name="external-links--w3org-http11-status-code-definitionshttpwwww3orgprotocolsrfc2616rfc2616-sec10htmlsec10"></a><span data-ttu-id="66976-180">外部リンク[W3.org: http/1.1 ステータス コード定義](http://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html#sec10)</span><span class="sxs-lookup"><span data-stu-id="66976-180">External links  [W3.org: HTTP/1.1 Status Code Definitions](http://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html#sec10)</span></span>

   