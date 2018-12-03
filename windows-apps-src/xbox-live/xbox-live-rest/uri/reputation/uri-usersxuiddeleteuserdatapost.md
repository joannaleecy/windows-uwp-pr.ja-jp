---
title: POST (/users/xuid({xuid})/deleteuserdata)
assetID: 8be13ff9-5d42-43a1-f2fa-d550d845a552
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddeleteuserdatapost.html
description: " POST (/users/xuid({xuid})/deleteuserdata)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dab43079dbba3729ff39f3a2116c377c3b73142a
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8339790"
---
# <a name="post-usersxuidxuiddeleteuserdata"></a><span data-ttu-id="8bad3-104">POST (/users/xuid({xuid})/deleteuserdata)</span><span class="sxs-lookup"><span data-stu-id="8bad3-104">POST (/users/xuid({xuid})/deleteuserdata)</span></span>
<span data-ttu-id="8bad3-105">テスト ユーザーの評判のデータを完全にリセットします。</span><span class="sxs-lookup"><span data-stu-id="8bad3-105">Completely resets the reputation data for a test user.</span></span> <span data-ttu-id="8bad3-106">テストのみです。</span><span class="sxs-lookup"><span data-stu-id="8bad3-106">For testing only.</span></span>

  * [<span data-ttu-id="8bad3-107">注釈</span><span class="sxs-lookup"><span data-stu-id="8bad3-107">Remarks</span></span>](#ID4EQ)
  * [<span data-ttu-id="8bad3-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8bad3-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="8bad3-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="8bad3-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="8bad3-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8bad3-110">Required Request Headers</span></span>](#ID4E3B)
  * [<span data-ttu-id="8bad3-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="8bad3-111">HTTP status codes</span></span>](#ID4EHC)
  * [<span data-ttu-id="8bad3-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="8bad3-112">Response body</span></span>](#ID4EJF)

<a id="ID4EQ"></a>


## <a name="remarks"></a><span data-ttu-id="8bad3-113">注釈</span><span class="sxs-lookup"><span data-stu-id="8bad3-113">Remarks</span></span>

<span data-ttu-id="8bad3-114">この API を呼び出すと、ユーザーからすべてのフィードバック項目と評判のデータが削除されます。</span><span class="sxs-lookup"><span data-stu-id="8bad3-114">Calling this API will remove all Feedback items and reputation data from a user.</span></span> <span data-ttu-id="8bad3-115">パートナーは、Retail を除くすべてのサンド ボックスに対してこの API を呼び出すことがあります。</span><span class="sxs-lookup"><span data-stu-id="8bad3-115">Partners may call this API against any sandbox except Retail.</span></span> <span data-ttu-id="8bad3-116">執行チームは、サンド ボックス ID を持つには、この API を呼び出すことがあります。</span><span class="sxs-lookup"><span data-stu-id="8bad3-116">The Enforcement Team may call this API with any Sandbox ID.</span></span>

<span data-ttu-id="8bad3-117">これらの Uri のドメインが`reputation.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="8bad3-117">The domain for these URIs is `reputation.xboxlive.com`.</span></span> <span data-ttu-id="8bad3-118">この URI は、常にポート 10443 で呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="8bad3-118">This URI is always called on port 10443.</span></span>

<a id="ID4E5"></a>


## <a name="uri-parameters"></a><span data-ttu-id="8bad3-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8bad3-119">URI parameters</span></span>

| <span data-ttu-id="8bad3-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8bad3-120">Parameter</span></span>| <span data-ttu-id="8bad3-121">型</span><span class="sxs-lookup"><span data-stu-id="8bad3-121">Type</span></span>| <span data-ttu-id="8bad3-122">説明</span><span class="sxs-lookup"><span data-stu-id="8bad3-122">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="8bad3-123">xuid</span><span class="sxs-lookup"><span data-stu-id="8bad3-123">xuid</span></span>| <span data-ttu-id="8bad3-124">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="8bad3-124">64-bit unsigned integer</span></span>| <span data-ttu-id="8bad3-125">Xbox ユーザー ID (XUID)、ユーザーがデータを削除しています。</span><span class="sxs-lookup"><span data-stu-id="8bad3-125">Xbox User ID (XUID) of the user whose data is being deleted.</span></span>|

<a id="ID4EJB"></a>


## <a name="authorization"></a><span data-ttu-id="8bad3-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="8bad3-126">Authorization</span></span>

<span data-ttu-id="8bad3-127">Retail サンド ボックスで、執行チームから**PartnerClaim**します。</span><span class="sxs-lookup"><span data-stu-id="8bad3-127">For the Retail sandbox, **PartnerClaim** from the Enforcement team.</span></span>

<span data-ttu-id="8bad3-128">すべての他のサンド ボックスに対して、 **PartnerClaim**と**SandboxIdClaim**します。</span><span class="sxs-lookup"><span data-stu-id="8bad3-128">For all other sandboxes, **PartnerClaim** and **SandboxIdClaim**.</span></span>

<a id="ID4E3B"></a>


## <a name="required-request-headers"></a><span data-ttu-id="8bad3-129">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8bad3-129">Required Request Headers</span></span>

<span data-ttu-id="8bad3-130">**コンテンツの種類: アプリケーション/json**と**X Xbl コントラクト バージョン**(現在のバージョンは 101)。</span><span class="sxs-lookup"><span data-stu-id="8bad3-130">**Content-Type: application/json** and **X-Xbl-Contract-Version** (current version is 101).</span></span>

<a id="ID4EHC"></a>


## <a name="http-status-codes"></a><span data-ttu-id="8bad3-131">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="8bad3-131">HTTP status codes</span></span>

<span data-ttu-id="8bad3-132">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="8bad3-132">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="8bad3-133">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8bad3-133">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="8bad3-134">コード</span><span class="sxs-lookup"><span data-stu-id="8bad3-134">Code</span></span>| <span data-ttu-id="8bad3-135">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="8bad3-135">Reason phrase</span></span>| <span data-ttu-id="8bad3-136">説明</span><span class="sxs-lookup"><span data-stu-id="8bad3-136">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="8bad3-137">200</span><span class="sxs-lookup"><span data-stu-id="8bad3-137">200</span></span>| <span data-ttu-id="8bad3-138">OK</span><span class="sxs-lookup"><span data-stu-id="8bad3-138">OK</span></span>| <span data-ttu-id="8bad3-139">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="8bad3-139">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="8bad3-140">400</span><span class="sxs-lookup"><span data-stu-id="8bad3-140">400</span></span>| <span data-ttu-id="8bad3-141">Bad Request</span><span class="sxs-lookup"><span data-stu-id="8bad3-141">Bad Request</span></span>| <span data-ttu-id="8bad3-142">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8bad3-142">Service could not understand malformed request.</span></span> <span data-ttu-id="8bad3-143">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="8bad3-143">Typically an invalid parameter.</span></span>|
| <span data-ttu-id="8bad3-144">401</span><span class="sxs-lookup"><span data-stu-id="8bad3-144">401</span></span>| <span data-ttu-id="8bad3-145">権限がありません</span><span class="sxs-lookup"><span data-stu-id="8bad3-145">Unauthorized</span></span>| <span data-ttu-id="8bad3-146">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="8bad3-146">The request requires user authentication.</span></span>|
| <span data-ttu-id="8bad3-147">404</span><span class="sxs-lookup"><span data-stu-id="8bad3-147">404</span></span>| <span data-ttu-id="8bad3-148">見つかりません。</span><span class="sxs-lookup"><span data-stu-id="8bad3-148">Not Found</span></span>| <span data-ttu-id="8bad3-149">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="8bad3-149">The specified resource could not be found.</span></span>|
| <span data-ttu-id="8bad3-150">500</span><span class="sxs-lookup"><span data-stu-id="8bad3-150">500</span></span>| <span data-ttu-id="8bad3-151">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="8bad3-151">Internal Server Error</span></span>| <span data-ttu-id="8bad3-152">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="8bad3-152">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>|
| <span data-ttu-id="8bad3-153">503</span><span class="sxs-lookup"><span data-stu-id="8bad3-153">503</span></span>| <span data-ttu-id="8bad3-154">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="8bad3-154">Service Unavailable</span></span>| <span data-ttu-id="8bad3-155">要求が調整された、秒 (例: 5 秒後) のクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="8bad3-155">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>|

<a id="ID4EJF"></a>


## <a name="response-body"></a><span data-ttu-id="8bad3-156">応答本文</span><span class="sxs-lookup"><span data-stu-id="8bad3-156">Response body</span></span>

<span data-ttu-id="8bad3-157">成功した場合はなしそれ以外の場合、 [ServiceError (JSON)](../../json/json-serviceerror.md)ドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="8bad3-157">None on success; otherwise, a [ServiceError (JSON)](../../json/json-serviceerror.md) document.</span></span>

<a id="ID4EWF"></a>


## <a name="see-also"></a><span data-ttu-id="8bad3-158">関連項目</span><span class="sxs-lookup"><span data-stu-id="8bad3-158">See also</span></span>

<a id="ID4EYF"></a>


##### <a name="parent"></a><span data-ttu-id="8bad3-159">Parent</span><span class="sxs-lookup"><span data-stu-id="8bad3-159">Parent</span></span>

[<span data-ttu-id="8bad3-160">/users/xuid({xuid})/deleteuserdata</span><span class="sxs-lookup"><span data-stu-id="8bad3-160">/users/xuid({xuid})/deleteuserdata</span></span>](uri-usersxuiddeleteuserdata.md)
