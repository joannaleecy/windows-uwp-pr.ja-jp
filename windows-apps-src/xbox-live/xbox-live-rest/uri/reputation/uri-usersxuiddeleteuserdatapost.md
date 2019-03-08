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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57604067"
---
# <a name="post-usersxuidxuiddeleteuserdata"></a><span data-ttu-id="a26a8-104">POST (/users/xuid({xuid})/deleteuserdata)</span><span class="sxs-lookup"><span data-stu-id="a26a8-104">POST (/users/xuid({xuid})/deleteuserdata)</span></span>
<span data-ttu-id="a26a8-105">テスト ユーザーの評価データを完全にリセットします。</span><span class="sxs-lookup"><span data-stu-id="a26a8-105">Completely resets the reputation data for a test user.</span></span> <span data-ttu-id="a26a8-106">テスト目的専用です。</span><span class="sxs-lookup"><span data-stu-id="a26a8-106">For testing only.</span></span>

  * [<span data-ttu-id="a26a8-107">注釈</span><span class="sxs-lookup"><span data-stu-id="a26a8-107">Remarks</span></span>](#ID4EQ)
  * [<span data-ttu-id="a26a8-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a26a8-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="a26a8-109">承認</span><span class="sxs-lookup"><span data-stu-id="a26a8-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="a26a8-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a26a8-110">Required Request Headers</span></span>](#ID4E3B)
  * [<span data-ttu-id="a26a8-111">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="a26a8-111">HTTP status codes</span></span>](#ID4EHC)
  * [<span data-ttu-id="a26a8-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="a26a8-112">Response body</span></span>](#ID4EJF)

<a id="ID4EQ"></a>


## <a name="remarks"></a><span data-ttu-id="a26a8-113">注釈</span><span class="sxs-lookup"><span data-stu-id="a26a8-113">Remarks</span></span>

<span data-ttu-id="a26a8-114">この API を呼び出すと、ユーザーから、すべてのフィードバック項目と評価データの設定が削除されます。</span><span class="sxs-lookup"><span data-stu-id="a26a8-114">Calling this API will remove all Feedback items and reputation data from a user.</span></span> <span data-ttu-id="a26a8-115">パートナーは、製品版を除く任意のサンド ボックスに対してこの API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="a26a8-115">Partners may call this API against any sandbox except Retail.</span></span> <span data-ttu-id="a26a8-116">強制チームは、サンド ボックス id には、この API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="a26a8-116">The Enforcement Team may call this API with any Sandbox ID.</span></span>

<span data-ttu-id="a26a8-117">これらの Uri のドメインが`reputation.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="a26a8-117">The domain for these URIs is `reputation.xboxlive.com`.</span></span> <span data-ttu-id="a26a8-118">この URI は常にポート 10443 で呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="a26a8-118">This URI is always called on port 10443.</span></span>

<a id="ID4E5"></a>


## <a name="uri-parameters"></a><span data-ttu-id="a26a8-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a26a8-119">URI parameters</span></span>

| <span data-ttu-id="a26a8-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a26a8-120">Parameter</span></span>| <span data-ttu-id="a26a8-121">種類</span><span class="sxs-lookup"><span data-stu-id="a26a8-121">Type</span></span>| <span data-ttu-id="a26a8-122">説明</span><span class="sxs-lookup"><span data-stu-id="a26a8-122">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="a26a8-123">xuid</span><span class="sxs-lookup"><span data-stu-id="a26a8-123">xuid</span></span>| <span data-ttu-id="a26a8-124">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="a26a8-124">64-bit unsigned integer</span></span>| <span data-ttu-id="a26a8-125">Xbox ユーザー ID (XUID) のデータが削除されるユーザーです。</span><span class="sxs-lookup"><span data-stu-id="a26a8-125">Xbox User ID (XUID) of the user whose data is being deleted.</span></span>|

<a id="ID4EJB"></a>


## <a name="authorization"></a><span data-ttu-id="a26a8-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="a26a8-126">Authorization</span></span>

<span data-ttu-id="a26a8-127">小売サンド ボックスの**PartnerClaim**強制チームから。</span><span class="sxs-lookup"><span data-stu-id="a26a8-127">For the Retail sandbox, **PartnerClaim** from the Enforcement team.</span></span>

<span data-ttu-id="a26a8-128">他のすべてのサンド ボックスの**PartnerClaim**と**SandboxIdClaim**します。</span><span class="sxs-lookup"><span data-stu-id="a26a8-128">For all other sandboxes, **PartnerClaim** and **SandboxIdClaim**.</span></span>

<a id="ID4E3B"></a>


## <a name="required-request-headers"></a><span data-ttu-id="a26a8-129">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a26a8-129">Required Request Headers</span></span>

<span data-ttu-id="a26a8-130">**コンテンツの種類: アプリケーション/json**と**X Xbl コントラクト バージョン**(現在のバージョンでは 101 です)。</span><span class="sxs-lookup"><span data-stu-id="a26a8-130">**Content-Type: application/json** and **X-Xbl-Contract-Version** (current version is 101).</span></span>

<a id="ID4EHC"></a>


## <a name="http-status-codes"></a><span data-ttu-id="a26a8-131">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="a26a8-131">HTTP status codes</span></span>

<span data-ttu-id="a26a8-132">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="a26a8-132">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="a26a8-133">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="a26a8-133">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>

| <span data-ttu-id="a26a8-134">コード</span><span class="sxs-lookup"><span data-stu-id="a26a8-134">Code</span></span>| <span data-ttu-id="a26a8-135">理由語句</span><span class="sxs-lookup"><span data-stu-id="a26a8-135">Reason phrase</span></span>| <span data-ttu-id="a26a8-136">説明</span><span class="sxs-lookup"><span data-stu-id="a26a8-136">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="a26a8-137">200</span><span class="sxs-lookup"><span data-stu-id="a26a8-137">200</span></span>| <span data-ttu-id="a26a8-138">OK</span><span class="sxs-lookup"><span data-stu-id="a26a8-138">OK</span></span>| <span data-ttu-id="a26a8-139">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="a26a8-139">The session was successfully retrieved.</span></span>|
| <span data-ttu-id="a26a8-140">400</span><span class="sxs-lookup"><span data-stu-id="a26a8-140">400</span></span>| <span data-ttu-id="a26a8-141">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="a26a8-141">Bad Request</span></span>| <span data-ttu-id="a26a8-142">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="a26a8-142">Service could not understand malformed request.</span></span> <span data-ttu-id="a26a8-143">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="a26a8-143">Typically an invalid parameter.</span></span>|
| <span data-ttu-id="a26a8-144">401</span><span class="sxs-lookup"><span data-stu-id="a26a8-144">401</span></span>| <span data-ttu-id="a26a8-145">権限がありません</span><span class="sxs-lookup"><span data-stu-id="a26a8-145">Unauthorized</span></span>| <span data-ttu-id="a26a8-146">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="a26a8-146">The request requires user authentication.</span></span>|
| <span data-ttu-id="a26a8-147">404</span><span class="sxs-lookup"><span data-stu-id="a26a8-147">404</span></span>| <span data-ttu-id="a26a8-148">検出不可</span><span class="sxs-lookup"><span data-stu-id="a26a8-148">Not Found</span></span>| <span data-ttu-id="a26a8-149">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="a26a8-149">The specified resource could not be found.</span></span>|
| <span data-ttu-id="a26a8-150">500</span><span class="sxs-lookup"><span data-stu-id="a26a8-150">500</span></span>| <span data-ttu-id="a26a8-151">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="a26a8-151">Internal Server Error</span></span>| <span data-ttu-id="a26a8-152">サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="a26a8-152">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>|
| <span data-ttu-id="a26a8-153">503</span><span class="sxs-lookup"><span data-stu-id="a26a8-153">503</span></span>| <span data-ttu-id="a26a8-154">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="a26a8-154">Service Unavailable</span></span>| <span data-ttu-id="a26a8-155">要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。</span><span class="sxs-lookup"><span data-stu-id="a26a8-155">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>|

<a id="ID4EJF"></a>


## <a name="response-body"></a><span data-ttu-id="a26a8-156">応答本文</span><span class="sxs-lookup"><span data-stu-id="a26a8-156">Response body</span></span>

<span data-ttu-id="a26a8-157">成功した場合は noneそれ以外の場合、[サービス エラー (JSON)](../../json/json-serviceerror.md)ドキュメント。</span><span class="sxs-lookup"><span data-stu-id="a26a8-157">None on success; otherwise, a [ServiceError (JSON)](../../json/json-serviceerror.md) document.</span></span>

<a id="ID4EWF"></a>


## <a name="see-also"></a><span data-ttu-id="a26a8-158">関連項目</span><span class="sxs-lookup"><span data-stu-id="a26a8-158">See also</span></span>

<a id="ID4EYF"></a>


##### <a name="parent"></a><span data-ttu-id="a26a8-159">Parent</span><span class="sxs-lookup"><span data-stu-id="a26a8-159">Parent</span></span>

[<span data-ttu-id="a26a8-160">/users/xuid({xuid})/deleteuserdata</span><span class="sxs-lookup"><span data-stu-id="a26a8-160">/users/xuid({xuid})/deleteuserdata</span></span>](uri-usersxuiddeleteuserdata.md)
