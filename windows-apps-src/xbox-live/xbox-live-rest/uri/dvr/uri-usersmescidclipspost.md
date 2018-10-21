---
title: POST (/users/me/scids/{scid}/clips)
assetID: 44535926-9fb8-5498-b1c8-514c0763e6c9
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclipspost.html
author: KevinAsgari
description: " POST (/users/me/scids/{scid}/clips)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2e6cee1adbe9e9401bec2ce578ab0d04da921170
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5158601"
---
# <a name="post-usersmescidsscidclips"></a><span data-ttu-id="7ea5a-104">POST (/users/me/scids/{scid}/clips)</span><span class="sxs-lookup"><span data-stu-id="7ea5a-104">POST (/users/me/scids/{scid}/clips)</span></span>
<span data-ttu-id="7ea5a-105">初期のアップロード要求を実行します。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-105">Make an initial upload request.</span></span> <span data-ttu-id="7ea5a-106">これらの Uri のドメイン`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`に対象の URI の機能に依存します。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="7ea5a-107">注釈</span><span class="sxs-lookup"><span data-stu-id="7ea5a-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="7ea5a-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7ea5a-108">URI parameters</span></span>](#ID4EFB)
  * [<span data-ttu-id="7ea5a-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="7ea5a-109">Authorization</span></span>](#ID4EQB)
  * [<span data-ttu-id="7ea5a-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7ea5a-110">Required Request Headers</span></span>](#ID4EKC)
  * [<span data-ttu-id="7ea5a-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7ea5a-111">Optional Request Headers</span></span>](#ID4ENE)
  * [<span data-ttu-id="7ea5a-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="7ea5a-112">Request body</span></span>](#ID4ENF)
  * [<span data-ttu-id="7ea5a-113">要求の例</span><span class="sxs-lookup"><span data-stu-id="7ea5a-113">Sample request</span></span>](#ID4E1F)
  * [<span data-ttu-id="7ea5a-114">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="7ea5a-114">HTTP status codes</span></span>](#ID4EDG)
  * [<span data-ttu-id="7ea5a-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="7ea5a-115">Response body</span></span>](#ID4EVAAC)
  * [<span data-ttu-id="7ea5a-116">応答の例</span><span class="sxs-lookup"><span data-stu-id="7ea5a-116">Sample response</span></span>](#ID4EFBAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a><span data-ttu-id="7ea5a-117">注釈</span><span class="sxs-lookup"><span data-stu-id="7ea5a-117">Remarks</span></span>
 
<span data-ttu-id="7ea5a-118">これは、GameClip アップロード プロセスの最初の部分です。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-118">This is the first part of the GameClip upload process.</span></span> <span data-ttu-id="7ea5a-119">ビデオのキャプチャ時をすぐに開始アップロードがスケジュールされていない場合でも、ビットのアップロードの ID と URI を取得するには、すぐに GameClips サービスを呼び出すことお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-119">Upon capture of a video, it's recommended to call the GameClips service immediately to obtain the ID and URI for the upload of the bits, even if the upload is not scheduled to start right away.</span></span> <span data-ttu-id="7ea5a-120">この呼び出しは、ユーザーのクォータ チェックとその他のチェックにして、ビデオがする必要がありますクライアントによってアップロードもスケジュールするかどうかは、プライバシー、コンテンツの分離を通じて実行されます。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-120">This call will perform user quota checks and other checks through content isolation, privacy, and so on to see if a video should even be scheduled for upload by the client.</span></span> <span data-ttu-id="7ea5a-121">この呼び出しからの正の応答では、サービスが許容アップロード用のビデオ クリップを示します。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-121">A positive response from this call indicates the service is willing to accept the video clip for upload.</span></span> <span data-ttu-id="7ea5a-122">アップロードされたすべてのクリップを承諾するのには、システムと、(SCID) を通じて、特定のタイトルに関連付けられたする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-122">All clips uploaded must be associated with a specific title (through a SCID) to be accepted in the system.</span></span>
 
<span data-ttu-id="7ea5a-123">この呼び出しでない等です。後続の呼び出しには、別の Id と Uri が発行されるが発生します。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-123">This call is not idempotent; subsequent calls will cause different IDs and URIs to be issued.</span></span> <span data-ttu-id="7ea5a-124">エラー発生時における再試行は、標準的なクライアント側バックオフ動作に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-124">Retries on failure should follow standard client-side back-off behavior.</span></span>
  
<a id="ID4EFB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="7ea5a-125">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7ea5a-125">URI parameters</span></span>
 
| <span data-ttu-id="7ea5a-126">パラメーター</span><span class="sxs-lookup"><span data-stu-id="7ea5a-126">Parameter</span></span>| <span data-ttu-id="7ea5a-127">型</span><span class="sxs-lookup"><span data-stu-id="7ea5a-127">Type</span></span>| <span data-ttu-id="7ea5a-128">説明</span><span class="sxs-lookup"><span data-stu-id="7ea5a-128">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="7ea5a-129">scid</span><span class="sxs-lookup"><span data-stu-id="7ea5a-129">scid</span></span>| <span data-ttu-id="7ea5a-130">string</span><span class="sxs-lookup"><span data-stu-id="7ea5a-130">string</span></span>| <span data-ttu-id="7ea5a-131">アクセスされているリソースのサービス構成 ID。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-131">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="7ea5a-132">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-132">Must match the SCID of the authenticated user.</span></span>| 
  
<a id="ID4EQB"></a>

 
## <a name="authorization"></a><span data-ttu-id="7ea5a-133">Authorization</span><span class="sxs-lookup"><span data-stu-id="7ea5a-133">Authorization</span></span>
 
<span data-ttu-id="7ea5a-134">次の要求は、このメソッドでは必要があります。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-134">The following claims are required for this method:</span></span>
 
   * <span data-ttu-id="7ea5a-135">Xuid</span><span class="sxs-lookup"><span data-stu-id="7ea5a-135">Xuid</span></span>
   * <span data-ttu-id="7ea5a-136">DeviceType - デバイスにアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-136">DeviceType - Must be device to upload</span></span>
   * <span data-ttu-id="7ea5a-137">DeviceId</span><span class="sxs-lookup"><span data-stu-id="7ea5a-137">DeviceId</span></span>
   * <span data-ttu-id="7ea5a-138">TitleId</span><span class="sxs-lookup"><span data-stu-id="7ea5a-138">TitleId</span></span>
   * <span data-ttu-id="7ea5a-139">TitleSandboxId</span><span class="sxs-lookup"><span data-stu-id="7ea5a-139">TitleSandboxId</span></span>
   
<a id="ID4EKC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="7ea5a-140">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7ea5a-140">Required Request Headers</span></span>
 
| <span data-ttu-id="7ea5a-141">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7ea5a-141">Header</span></span>| <span data-ttu-id="7ea5a-142">型</span><span class="sxs-lookup"><span data-stu-id="7ea5a-142">Type</span></span>| <span data-ttu-id="7ea5a-143">説明</span><span class="sxs-lookup"><span data-stu-id="7ea5a-143">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="7ea5a-144">Authorization</span><span class="sxs-lookup"><span data-stu-id="7ea5a-144">Authorization</span></span>| <span data-ttu-id="7ea5a-145">string</span><span class="sxs-lookup"><span data-stu-id="7ea5a-145">string</span></span>| <span data-ttu-id="7ea5a-146">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-146">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="7ea5a-147">値の例: <b>Xauth =&lt;authtoken ></b></span><span class="sxs-lookup"><span data-stu-id="7ea5a-147">Example values: <b>Xauth=&lt;authtoken></b></span></span>| 
| <span data-ttu-id="7ea5a-148">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="7ea5a-148">X-RequestedServiceVersion</span></span>| <span data-ttu-id="7ea5a-149">string</span><span class="sxs-lookup"><span data-stu-id="7ea5a-149">string</span></span>| <span data-ttu-id="7ea5a-150">この要求する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-150">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="7ea5a-151">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。例: 1、vnext します。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-151">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="7ea5a-152">Content-Type</span><span class="sxs-lookup"><span data-stu-id="7ea5a-152">Content-Type</span></span>| <span data-ttu-id="7ea5a-153">string</span><span class="sxs-lookup"><span data-stu-id="7ea5a-153">string</span></span>| <span data-ttu-id="7ea5a-154">応答本文の MIME タイプ。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-154">MIME type of the response body.</span></span> <span data-ttu-id="7ea5a-155">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-155">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="7ea5a-156">Accept</span><span class="sxs-lookup"><span data-stu-id="7ea5a-156">Accept</span></span>| <span data-ttu-id="7ea5a-157">string</span><span class="sxs-lookup"><span data-stu-id="7ea5a-157">string</span></span>| <span data-ttu-id="7ea5a-158">コンテンツの種類の利用可能な値です。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-158">Acceptable values of Content-Type.</span></span> <span data-ttu-id="7ea5a-159">例:<b>アプリケーション/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-159">Example: <b>application/json</b>.</span></span>| 
  
<a id="ID4ENE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="7ea5a-160">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7ea5a-160">Optional Request Headers</span></span>
 
| <span data-ttu-id="7ea5a-161">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7ea5a-161">Header</span></span>| <span data-ttu-id="7ea5a-162">型</span><span class="sxs-lookup"><span data-stu-id="7ea5a-162">Type</span></span>| <span data-ttu-id="7ea5a-163">説明</span><span class="sxs-lookup"><span data-stu-id="7ea5a-163">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="7ea5a-164">Accept-Encoding</span><span class="sxs-lookup"><span data-stu-id="7ea5a-164">Accept-Encoding</span></span>| <span data-ttu-id="7ea5a-165">string</span><span class="sxs-lookup"><span data-stu-id="7ea5a-165">string</span></span>| <span data-ttu-id="7ea5a-166">受け入れ可能な圧縮エンコードします。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-166">Acceptable compression encodings.</span></span> <span data-ttu-id="7ea5a-167">値の例: gzip、圧縮の id。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-167">Example values: gzip, deflate, identity.</span></span>| 
  
<a id="ID4ENF"></a>

 
## <a name="request-body"></a><span data-ttu-id="7ea5a-168">要求本文</span><span class="sxs-lookup"><span data-stu-id="7ea5a-168">Request body</span></span>
 
<span data-ttu-id="7ea5a-169">要求の本文には、JSON 形式で[InitialUploadRequest](../../json/json-initialuploadrequest.md)オブジェクトを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-169">The body of the request should be an [InitialUploadRequest](../../json/json-initialuploadrequest.md) object in JSON format.</span></span>
  
<a id="ID4E1F"></a>

 
## <a name="sample-request"></a><span data-ttu-id="7ea5a-170">要求の例</span><span class="sxs-lookup"><span data-stu-id="7ea5a-170">Sample request</span></span>
 

```cpp
{
   "clipNameStringId": "1193045",
   "userCaption": "OMG Look at this!",
   "sessionRef": "4587552a-a5ad-4c4c-a787-5bc5af70e4c9",
   "dateRecorded": "2012-12-23T11:08:08Z",
   "durationInSeconds": 27,
   "expectedBlocks": 7,
   "fileSize": 1234567,
   "type": "MagicMoment, Achievement",
   "source": "Console",
   "visibility": "Default",
   "titleData": "{ 'Boss': 'The Invincible' }",
   "systemProperties": "{ 'Id': '123456', 'Location': 'C:\\videos\\123456.mp4' }",
   "thumbnailSource": "Offset",
   "thumbnailOffsetMillseconds": 20000,
   "savedByUser": false
 }
      
```

  
<a id="ID4EDG"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="7ea5a-171">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="7ea5a-171">HTTP status codes</span></span>
 
<span data-ttu-id="7ea5a-172">サービスでは、このリソースには、この方法で行った要求に応答には、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-172">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="7ea5a-173">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-173">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="7ea5a-174">コード</span><span class="sxs-lookup"><span data-stu-id="7ea5a-174">Code</span></span>| <span data-ttu-id="7ea5a-175">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="7ea5a-175">Reason phrase</span></span>| <span data-ttu-id="7ea5a-176">説明</span><span class="sxs-lookup"><span data-stu-id="7ea5a-176">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="7ea5a-177">200</span><span class="sxs-lookup"><span data-stu-id="7ea5a-177">200</span></span>| <span data-ttu-id="7ea5a-178">OK</span><span class="sxs-lookup"><span data-stu-id="7ea5a-178">OK</span></span>| <span data-ttu-id="7ea5a-179">セッションが正常に取得されました。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-179">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="7ea5a-180">400</span><span class="sxs-lookup"><span data-stu-id="7ea5a-180">400</span></span>| <span data-ttu-id="7ea5a-181">Bad Request</span><span class="sxs-lookup"><span data-stu-id="7ea5a-181">Bad Request</span></span>| <span data-ttu-id="7ea5a-182">要求本文でエラーが発生しましたまたはユーザーがそのクォータを超えています。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-182">There was an error in the request body, or the user is over their quota.</span></span>| 
| <span data-ttu-id="7ea5a-183">401</span><span class="sxs-lookup"><span data-stu-id="7ea5a-183">401</span></span>| <span data-ttu-id="7ea5a-184">権限がありません</span><span class="sxs-lookup"><span data-stu-id="7ea5a-184">Unauthorized</span></span>| <span data-ttu-id="7ea5a-185">要求の認証トークンの形式で問題があります。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-185">There is a problem with the auth token format in the request.</span></span>| 
| <span data-ttu-id="7ea5a-186">403</span><span class="sxs-lookup"><span data-stu-id="7ea5a-186">403</span></span>| <span data-ttu-id="7ea5a-187">Forbidden</span><span class="sxs-lookup"><span data-stu-id="7ea5a-187">Forbidden</span></span>| <span data-ttu-id="7ea5a-188">一部の必須の要求がないか、または DeviceType はありません。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-188">Some required claims are missing, or DeviceType is not .</span></span>| 
| <span data-ttu-id="7ea5a-189">503</span><span class="sxs-lookup"><span data-stu-id="7ea5a-189">503</span></span>| <span data-ttu-id="7ea5a-190">許容できません。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-190">Not Acceptable</span></span>| <span data-ttu-id="7ea5a-191">サービスまたは一部ダウン ストリームの依存関係ダウンしています。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-191">The service or some downstream dependencies are down.</span></span> <span data-ttu-id="7ea5a-192">標準的なバックオフ動作を指定して再試行します。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-192">Retry with standard back-off behavior.</span></span>| 
  
<a id="ID4EVAAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="7ea5a-193">応答本文</span><span class="sxs-lookup"><span data-stu-id="7ea5a-193">Response body</span></span>
 
<span data-ttu-id="7ea5a-194">応答には、 [InitialUploadResponse](../../json/json-initialuploadresponse.md)オブジェクト、または JSON 形式で[ServiceErrorResponse](../../json/json-serviceerrorresponse.md)オブジェクトを指定します。</span><span class="sxs-lookup"><span data-stu-id="7ea5a-194">The response can be an [InitialUploadResponse](../../json/json-initialuploadresponse.md) object or a [ServiceErrorResponse](../../json/json-serviceerrorresponse.md) object in JSON format.</span></span>
  
<a id="ID4EFBAC"></a>

 
## <a name="sample-response"></a><span data-ttu-id="7ea5a-195">応答の例</span><span class="sxs-lookup"><span data-stu-id="7ea5a-195">Sample response</span></span>
 

```cpp
{
   "clipName": "ClipName",
   "gameClipId": "6b364924-5650-480f-86a7-fc002a1ee752",  
   "titleName": "TitleName",
   "uploadUri": "https://gameclips.xbox.live/upload/xuid(2716903703773872)/6b364924-5650-480f-86a7-fc002a1ee752/container",
   "largeThumbnailUri": "https://gameclips.xbox.live/upload/xuid(2716903703773872)/6b364924-5650-480f-86a7-fc002a1ee752/container/thumbnails/large",
   "smallThumbnailUri": "https://gameclips.xbox.live/upload/xuid(2716903703773872)/6b364924-5650-480f-86a7-fc002a1ee752/container/thumbnails/small"
 }
         
```

  
<a id="ID4EOBAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="7ea5a-196">関連項目</span><span class="sxs-lookup"><span data-stu-id="7ea5a-196">See also</span></span>
 
<a id="ID4EQBAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="7ea5a-197">Parent</span><span class="sxs-lookup"><span data-stu-id="7ea5a-197">Parent</span></span> 

[<span data-ttu-id="7ea5a-198">/users/me/scids/{scid}/clips</span><span class="sxs-lookup"><span data-stu-id="7ea5a-198">/users/me/scids/{scid}/clips</span></span>](uri-usersmescidclips.md)

   