---
title: POST (/users/xuid({xuid})/deleteuserdata)
assetID: 8be13ff9-5d42-43a1-f2fa-d550d845a552
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddeleteuserdatapost.html
author: KevinAsgari
description: " POST (/users/xuid({xuid})/deleteuserdata)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7bcb7b1c6c23f39846084ba4e6583553e2ff04a1
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4260708"
---
# <a name="post-usersxuidxuiddeleteuserdata"></a><span data-ttu-id="3291d-104">POST (/users/xuid({xuid})/deleteuserdata)</span><span class="sxs-lookup"><span data-stu-id="3291d-104">POST (/users/xuid({xuid})/deleteuserdata)</span></span>
<span data-ttu-id="3291d-105">テスト ユーザーの評判のデータを完全にリセットします。</span><span class="sxs-lookup"><span data-stu-id="3291d-105">Completely resets the reputation data for a test user.</span></span> <span data-ttu-id="3291d-106">テストのみです。</span><span class="sxs-lookup"><span data-stu-id="3291d-106">For testing only.</span></span>

  * [<span data-ttu-id="3291d-107">注釈</span><span class="sxs-lookup"><span data-stu-id="3291d-107">Remarks</span></span>](#ID4EQ)
  * [<span data-ttu-id="3291d-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3291d-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="3291d-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="3291d-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="3291d-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3291d-110">Required Request Headers</span></span>](#ID4E3B)
  * [<span data-ttu-id="3291d-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="3291d-111">HTTP status codes</span></span>](#ID4EHC)
  * [<span data-ttu-id="3291d-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="3291d-112">Response body</span></span>](#ID4EJF)

<a id="ID4EQ"></a>


## <a name="remarks"></a><span data-ttu-id="3291d-113">注釈</span><span class="sxs-lookup"><span data-stu-id="3291d-113">Remarks</span></span>

<span data-ttu-id="3291d-114">この API を呼び出すと、ユーザーからすべてのフィードバック項目と評判のデータが削除されます。</span><span class="sxs-lookup"><span data-stu-id="3291d-114">Calling this API will remove all Feedback items and reputation data from a user.</span></span> <span data-ttu-id="3291d-115">パートナーは、Retail を除くすべてのサンド ボックスに対してこの API を呼び出すことがあります。</span><span class="sxs-lookup"><span data-stu-id="3291d-115">Partners may call this API against any sandbox except Retail.</span></span> <span data-ttu-id="3291d-116">執行チームは、サンド ボックス ID を持つには、この API を呼び出すことがあります。</span><span class="sxs-lookup"><span data-stu-id="3291d-116">The Enforcement Team may call this API with any Sandbox ID.</span></span>

<span data-ttu-id="3291d-117">これらの Uri のドメインが`reputation.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="3291d-117">The domain for these URIs is `reputation.xboxlive.com`.</span></span> <span data-ttu-id="3291d-118">この URI は、常にポート 10443 で呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="3291d-118">This URI is always called on port 10443.</span></span>

<a id="ID4E5"></a>


## <a name="uri-parameters"></a><span data-ttu-id="3291d-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3291d-119">URI parameters</span></span>

| <span data-ttu-id="3291d-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3291d-120">Parameter</span></span>| <span data-ttu-id="3291d-121">型</span><span class="sxs-lookup"><span data-stu-id="3291d-121">Type</span></span>| <span data-ttu-id="3291d-122">説明</span><span class="sxs-lookup"><span data-stu-id="3291d-122">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="3291d-123">xuid</span><span class="sxs-lookup"><span data-stu-id="3291d-123">xuid</span></span>| <span data-ttu-id="3291d-124">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="3291d-124">64-bit unsigned integer</span></span>| <span data-ttu-id="3291d-125">Xbox ユーザー ID (XUID)、ユーザーがデータが削除されるのです。</span><span class="sxs-lookup"><span data-stu-id="3291d-125">Xbox User ID (XUID) of the user whose data is being deleted.</span></span>|

<a id="ID4EJB"></a>


## <a name="authorization"></a><span data-ttu-id="3291d-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="3291d-126">Authorization</span></span>

<span data-ttu-id="3291d-127">Retail サンド ボックスで、執行チームから**PartnerClaim**します。</span><span class="sxs-lookup"><span data-stu-id="3291d-127">For the Retail sandbox, **PartnerClaim** from the Enforcement team.</span></span>

<span data-ttu-id="3291d-128">すべての他のサンド ボックスに対して、 **PartnerClaim**と**SandboxIdClaim**します。</span><span class="sxs-lookup"><span data-stu-id="3291d-128">For all other sandboxes, **PartnerClaim** and **SandboxIdClaim**.</span></span>

<a id="ID4E3B"></a>


## <a name="required-request-headers"></a><span data-ttu-id="3291d-129">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3291d-129">Required Request Headers</span></span>

<span data-ttu-id="3291d-130">**コンテンツの種類: アプリケーション/json**と**X Xbl コントラクト バージョン**(現在のバージョンは 101)。</span><span class="sxs-lookup"><span data-stu-id="3291d-130">**Content-Type: application/json** and **X-Xbl-Contract-Version** (current version is 101).</span></span>

<a id="ID4EHC"></a>


## <a name="http-status-codes"></a><span data-ttu-id="3291d-131">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="3291d-131">HTTP status codes</span></span>

<span data-ttu-id="3291d-132">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="3291d-132">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="3291d-133">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3291d-133">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="3291d-134">コード</span><span class="sxs-lookup"><span data-stu-id="3291d-134">Code</span></span>| <span data-ttu-id="3291d-135">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="3291d-135">Reason phrase</span></span>| <span data-ttu-id="3291d-136">説明</span><span class="sxs-lookup"><span data-stu-id="3291d-136">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="3291d-137">200</span><span class="sxs-lookup"><span data-stu-id="3291d-137">200</span></span>| <span data-ttu-id="3291d-138">OK</span><span class="sxs-lookup"><span data-stu-id="3291d-138">OK</span></span>| <span data-ttu-id="3291d-139">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="3291d-139">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="3291d-140">400</span><span class="sxs-lookup"><span data-stu-id="3291d-140">400</span></span>| <span data-ttu-id="3291d-141">Bad Request</span><span class="sxs-lookup"><span data-stu-id="3291d-141">Bad Request</span></span>| <span data-ttu-id="3291d-142">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3291d-142">Service could not understand malformed request.</span></span> <span data-ttu-id="3291d-143">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="3291d-143">Typically an invalid parameter.</span></span>|
| <span data-ttu-id="3291d-144">401</span><span class="sxs-lookup"><span data-stu-id="3291d-144">401</span></span>| <span data-ttu-id="3291d-145">権限がありません</span><span class="sxs-lookup"><span data-stu-id="3291d-145">Unauthorized</span></span>| <span data-ttu-id="3291d-146">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="3291d-146">The request requires user authentication.</span></span>|
| <span data-ttu-id="3291d-147">404</span><span class="sxs-lookup"><span data-stu-id="3291d-147">404</span></span>| <span data-ttu-id="3291d-148">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="3291d-148">Not Found</span></span>| <span data-ttu-id="3291d-149">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="3291d-149">The specified resource could not be found.</span></span>|
| <span data-ttu-id="3291d-150">500</span><span class="sxs-lookup"><span data-stu-id="3291d-150">500</span></span>| <span data-ttu-id="3291d-151">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="3291d-151">Internal Server Error</span></span>| <span data-ttu-id="3291d-152">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="3291d-152">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>|
| <span data-ttu-id="3291d-153">503</span><span class="sxs-lookup"><span data-stu-id="3291d-153">503</span></span>| <span data-ttu-id="3291d-154">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="3291d-154">Service Unavailable</span></span>| <span data-ttu-id="3291d-155">要求が調整された、クライアント再試行値 (例: 5 秒後) を秒単位で後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="3291d-155">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>|

<a id="ID4EJF"></a>


## <a name="response-body"></a><span data-ttu-id="3291d-156">応答本文</span><span class="sxs-lookup"><span data-stu-id="3291d-156">Response body</span></span>

<span data-ttu-id="3291d-157">成功した場合はなしそれ以外の場合、 [ServiceError (JSON)](../../json/json-serviceerror.md)ドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="3291d-157">None on success; otherwise, a [ServiceError (JSON)](../../json/json-serviceerror.md) document.</span></span>

<a id="ID4EWF"></a>


## <a name="see-also"></a><span data-ttu-id="3291d-158">関連項目</span><span class="sxs-lookup"><span data-stu-id="3291d-158">See also</span></span>

<a id="ID4EYF"></a>


##### <a name="parent"></a><span data-ttu-id="3291d-159">Parent</span><span class="sxs-lookup"><span data-stu-id="3291d-159">Parent</span></span>

[<span data-ttu-id="3291d-160">/users/xuid({xuid})/deleteuserdata</span><span class="sxs-lookup"><span data-stu-id="3291d-160">/users/xuid({xuid})/deleteuserdata</span></span>](uri-usersxuiddeleteuserdata.md)
