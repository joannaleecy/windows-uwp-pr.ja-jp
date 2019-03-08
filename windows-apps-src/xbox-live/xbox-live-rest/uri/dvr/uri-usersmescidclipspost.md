---
title: POST (/users/me/scids/{scid}/clips)
assetID: 44535926-9fb8-5498-b1c8-514c0763e6c9
permalink: en-us/docs/xboxlive/rest/uri-usersmescidclipspost.html
description: " POST (/users/me/scids/{scid}/clips)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7a8973390ccbf5dd9980410f60f03a7edd78c134
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608787"
---
# <a name="post-usersmescidsscidclips"></a><span data-ttu-id="3431b-104">POST (/users/me/scids/{scid}/clips)</span><span class="sxs-lookup"><span data-stu-id="3431b-104">POST (/users/me/scids/{scid}/clips)</span></span>
<span data-ttu-id="3431b-105">初期アップロード要求を行います。</span><span class="sxs-lookup"><span data-stu-id="3431b-105">Make an initial upload request.</span></span> <span data-ttu-id="3431b-106">これらの Uri のドメインが`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`、対象の URI の機能によって異なります。</span><span class="sxs-lookup"><span data-stu-id="3431b-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="3431b-107">注釈</span><span class="sxs-lookup"><span data-stu-id="3431b-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="3431b-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3431b-108">URI parameters</span></span>](#ID4EFB)
  * [<span data-ttu-id="3431b-109">承認</span><span class="sxs-lookup"><span data-stu-id="3431b-109">Authorization</span></span>](#ID4EQB)
  * [<span data-ttu-id="3431b-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3431b-110">Required Request Headers</span></span>](#ID4EKC)
  * [<span data-ttu-id="3431b-111">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3431b-111">Optional Request Headers</span></span>](#ID4ENE)
  * [<span data-ttu-id="3431b-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="3431b-112">Request body</span></span>](#ID4ENF)
  * [<span data-ttu-id="3431b-113">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="3431b-113">Sample request</span></span>](#ID4E1F)
  * [<span data-ttu-id="3431b-114">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="3431b-114">HTTP status codes</span></span>](#ID4EDG)
  * [<span data-ttu-id="3431b-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="3431b-115">Response body</span></span>](#ID4EVAAC)
  * [<span data-ttu-id="3431b-116">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="3431b-116">Sample response</span></span>](#ID4EFBAC)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a><span data-ttu-id="3431b-117">注釈</span><span class="sxs-lookup"><span data-stu-id="3431b-117">Remarks</span></span>
 
<span data-ttu-id="3431b-118">これは、ゲーム クリップだったアップロード プロセスの最初の部分です。</span><span class="sxs-lookup"><span data-stu-id="3431b-118">This is the first part of the GameClip upload process.</span></span> <span data-ttu-id="3431b-119">ビデオのキャプチャ時をすぐに開始、アップロードがスケジュールされていない場合でも、bits のアップロードの ID と URI を取得するには、すぐにゲーム クリップ サービスを呼び出すことが推奨されます。</span><span class="sxs-lookup"><span data-stu-id="3431b-119">Upon capture of a video, it's recommended to call the GameClips service immediately to obtain the ID and URI for the upload of the bits, even if the upload is not scheduled to start right away.</span></span> <span data-ttu-id="3431b-120">この呼び出しはユーザーのクォータ チェックとビデオがする必要があります、クライアントによってアップロードもスケジュールされるかどうかを参照してください、という具合に、プライバシー、コンテンツの分離によるその他のチェックを実行します。</span><span class="sxs-lookup"><span data-stu-id="3431b-120">This call will perform user quota checks and other checks through content isolation, privacy, and so on to see if a video should even be scheduled for upload by the client.</span></span> <span data-ttu-id="3431b-121">この呼び出しから肯定応答では、サービスがアップロードのビデオ クリップを許容できることを示します。</span><span class="sxs-lookup"><span data-stu-id="3431b-121">A positive response from this call indicates the service is willing to accept the video clip for upload.</span></span> <span data-ttu-id="3431b-122">承諾するのには、システムには、(、SCID) を通じて特定のタイトルのアップロードのすべてのクリップが関連付けられている必要があります。</span><span class="sxs-lookup"><span data-stu-id="3431b-122">All clips uploaded must be associated with a specific title (through a SCID) to be accepted in the system.</span></span>
 
<span data-ttu-id="3431b-123">この呼び出しはべき等です。後続の呼び出しは、別の Id と Uri を発行できるになります。</span><span class="sxs-lookup"><span data-stu-id="3431b-123">This call is not idempotent; subsequent calls will cause different IDs and URIs to be issued.</span></span> <span data-ttu-id="3431b-124">エラー発生時の再試行は、標準的なクライアント側、バックオフ動作に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="3431b-124">Retries on failure should follow standard client-side back-off behavior.</span></span>
  
<a id="ID4EFB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="3431b-125">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3431b-125">URI parameters</span></span>
 
| <span data-ttu-id="3431b-126">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3431b-126">Parameter</span></span>| <span data-ttu-id="3431b-127">種類</span><span class="sxs-lookup"><span data-stu-id="3431b-127">Type</span></span>| <span data-ttu-id="3431b-128">説明</span><span class="sxs-lookup"><span data-stu-id="3431b-128">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="3431b-129">scid</span><span class="sxs-lookup"><span data-stu-id="3431b-129">scid</span></span>| <span data-ttu-id="3431b-130">string</span><span class="sxs-lookup"><span data-stu-id="3431b-130">string</span></span>| <span data-ttu-id="3431b-131">サービス アクセスされているリソースの ID を構成します。</span><span class="sxs-lookup"><span data-stu-id="3431b-131">Service Config ID of the resource that is being accessed.</span></span> <span data-ttu-id="3431b-132">認証されたユーザーの SCID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3431b-132">Must match the SCID of the authenticated user.</span></span>| 
  
<a id="ID4EQB"></a>

 
## <a name="authorization"></a><span data-ttu-id="3431b-133">Authorization</span><span class="sxs-lookup"><span data-stu-id="3431b-133">Authorization</span></span>
 
<span data-ttu-id="3431b-134">次の要求は、このメソッドに必要です。</span><span class="sxs-lookup"><span data-stu-id="3431b-134">The following claims are required for this method:</span></span>
 
   * <span data-ttu-id="3431b-135">xuid</span><span class="sxs-lookup"><span data-stu-id="3431b-135">Xuid</span></span>
   * <span data-ttu-id="3431b-136">DeviceType - デバイスをアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3431b-136">DeviceType - Must be device to upload</span></span>
   * <span data-ttu-id="3431b-137">DeviceId</span><span class="sxs-lookup"><span data-stu-id="3431b-137">DeviceId</span></span>
   * <span data-ttu-id="3431b-138">TitleId</span><span class="sxs-lookup"><span data-stu-id="3431b-138">TitleId</span></span>
   * <span data-ttu-id="3431b-139">TitleSandboxId</span><span class="sxs-lookup"><span data-stu-id="3431b-139">TitleSandboxId</span></span>
   
<a id="ID4EKC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="3431b-140">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3431b-140">Required Request Headers</span></span>
 
| <span data-ttu-id="3431b-141">Header</span><span class="sxs-lookup"><span data-stu-id="3431b-141">Header</span></span>| <span data-ttu-id="3431b-142">種類</span><span class="sxs-lookup"><span data-stu-id="3431b-142">Type</span></span>| <span data-ttu-id="3431b-143">説明</span><span class="sxs-lookup"><span data-stu-id="3431b-143">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3431b-144">Authorization</span><span class="sxs-lookup"><span data-stu-id="3431b-144">Authorization</span></span>| <span data-ttu-id="3431b-145">string</span><span class="sxs-lookup"><span data-stu-id="3431b-145">string</span></span>| <span data-ttu-id="3431b-146">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="3431b-146">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="3431b-147">値の例:<b>Xauth=&lt;authtoken></b></span><span class="sxs-lookup"><span data-stu-id="3431b-147">Example values: <b>Xauth=&lt;authtoken></b></span></span>| 
| <span data-ttu-id="3431b-148">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="3431b-148">X-RequestedServiceVersion</span></span>| <span data-ttu-id="3431b-149">string</span><span class="sxs-lookup"><span data-stu-id="3431b-149">string</span></span>| <span data-ttu-id="3431b-150">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="3431b-150">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="3431b-151">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。例:1、vnext。</span><span class="sxs-lookup"><span data-stu-id="3431b-151">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Examples: 1, vnext.</span></span>| 
| <span data-ttu-id="3431b-152">Content-Type</span><span class="sxs-lookup"><span data-stu-id="3431b-152">Content-Type</span></span>| <span data-ttu-id="3431b-153">string</span><span class="sxs-lookup"><span data-stu-id="3431b-153">string</span></span>| <span data-ttu-id="3431b-154">応答本文の MIME の種類。</span><span class="sxs-lookup"><span data-stu-id="3431b-154">MIME type of the response body.</span></span> <span data-ttu-id="3431b-155">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="3431b-155">Example: <b>application/json</b>.</span></span>| 
| <span data-ttu-id="3431b-156">OK</span><span class="sxs-lookup"><span data-stu-id="3431b-156">Accept</span></span>| <span data-ttu-id="3431b-157">string</span><span class="sxs-lookup"><span data-stu-id="3431b-157">string</span></span>| <span data-ttu-id="3431b-158">コンテンツの種類の許容される値。</span><span class="sxs-lookup"><span data-stu-id="3431b-158">Acceptable values of Content-Type.</span></span> <span data-ttu-id="3431b-159">例: <b>、application/json</b>します。</span><span class="sxs-lookup"><span data-stu-id="3431b-159">Example: <b>application/json</b>.</span></span>| 
  
<a id="ID4ENE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="3431b-160">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3431b-160">Optional Request Headers</span></span>
 
| <span data-ttu-id="3431b-161">Header</span><span class="sxs-lookup"><span data-stu-id="3431b-161">Header</span></span>| <span data-ttu-id="3431b-162">種類</span><span class="sxs-lookup"><span data-stu-id="3431b-162">Type</span></span>| <span data-ttu-id="3431b-163">説明</span><span class="sxs-lookup"><span data-stu-id="3431b-163">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3431b-164">Accept-Encoding</span><span class="sxs-lookup"><span data-stu-id="3431b-164">Accept-Encoding</span></span>| <span data-ttu-id="3431b-165">string</span><span class="sxs-lookup"><span data-stu-id="3431b-165">string</span></span>| <span data-ttu-id="3431b-166">許容される圧縮エンコーディング。</span><span class="sxs-lookup"><span data-stu-id="3431b-166">Acceptable compression encodings.</span></span> <span data-ttu-id="3431b-167">値の例: gzip、deflate の id。</span><span class="sxs-lookup"><span data-stu-id="3431b-167">Example values: gzip, deflate, identity.</span></span>| 
  
<a id="ID4ENF"></a>

 
## <a name="request-body"></a><span data-ttu-id="3431b-168">要求本文</span><span class="sxs-lookup"><span data-stu-id="3431b-168">Request body</span></span>
 
<span data-ttu-id="3431b-169">要求の本文にする必要があります、 [InitialUploadRequest](../../json/json-initialuploadrequest.md) JSON 形式のオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="3431b-169">The body of the request should be an [InitialUploadRequest](../../json/json-initialuploadrequest.md) object in JSON format.</span></span>
  
<a id="ID4E1F"></a>

 
## <a name="sample-request"></a><span data-ttu-id="3431b-170">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="3431b-170">Sample request</span></span>
 

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

 
## <a name="http-status-codes"></a><span data-ttu-id="3431b-171">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="3431b-171">HTTP status codes</span></span>
 
<span data-ttu-id="3431b-172">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="3431b-172">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="3431b-173">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="3431b-173">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="3431b-174">コード</span><span class="sxs-lookup"><span data-stu-id="3431b-174">Code</span></span>| <span data-ttu-id="3431b-175">理由語句</span><span class="sxs-lookup"><span data-stu-id="3431b-175">Reason phrase</span></span>| <span data-ttu-id="3431b-176">説明</span><span class="sxs-lookup"><span data-stu-id="3431b-176">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3431b-177">200</span><span class="sxs-lookup"><span data-stu-id="3431b-177">200</span></span>| <span data-ttu-id="3431b-178">OK</span><span class="sxs-lookup"><span data-stu-id="3431b-178">OK</span></span>| <span data-ttu-id="3431b-179">セッションが正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="3431b-179">The session was successfully retrieved.</span></span>| 
| <span data-ttu-id="3431b-180">400</span><span class="sxs-lookup"><span data-stu-id="3431b-180">400</span></span>| <span data-ttu-id="3431b-181">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="3431b-181">Bad Request</span></span>| <span data-ttu-id="3431b-182">要求の本文にエラーが発生しました。 または、ユーザーは、そのクォータを超えて。</span><span class="sxs-lookup"><span data-stu-id="3431b-182">There was an error in the request body, or the user is over their quota.</span></span>| 
| <span data-ttu-id="3431b-183">401</span><span class="sxs-lookup"><span data-stu-id="3431b-183">401</span></span>| <span data-ttu-id="3431b-184">権限がありません</span><span class="sxs-lookup"><span data-stu-id="3431b-184">Unauthorized</span></span>| <span data-ttu-id="3431b-185">要求の認証トークンの形式に問題があります。</span><span class="sxs-lookup"><span data-stu-id="3431b-185">There is a problem with the auth token format in the request.</span></span>| 
| <span data-ttu-id="3431b-186">403</span><span class="sxs-lookup"><span data-stu-id="3431b-186">403</span></span>| <span data-ttu-id="3431b-187">Forbidden</span><span class="sxs-lookup"><span data-stu-id="3431b-187">Forbidden</span></span>| <span data-ttu-id="3431b-188">一部の必須の要求がないか、または DeviceType はありません。</span><span class="sxs-lookup"><span data-stu-id="3431b-188">Some required claims are missing, or DeviceType is not .</span></span>| 
| <span data-ttu-id="3431b-189">503</span><span class="sxs-lookup"><span data-stu-id="3431b-189">503</span></span>| <span data-ttu-id="3431b-190">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="3431b-190">Not Acceptable</span></span>| <span data-ttu-id="3431b-191">サービスまたはいくつかのダウン ストリームの依存関係がダウンします。</span><span class="sxs-lookup"><span data-stu-id="3431b-191">The service or some downstream dependencies are down.</span></span> <span data-ttu-id="3431b-192">標準的なバックオフ動作で再試行してください。</span><span class="sxs-lookup"><span data-stu-id="3431b-192">Retry with standard back-off behavior.</span></span>| 
  
<a id="ID4EVAAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="3431b-193">応答本文</span><span class="sxs-lookup"><span data-stu-id="3431b-193">Response body</span></span>
 
<span data-ttu-id="3431b-194">応答ができます、 [InitialUploadResponse](../../json/json-initialuploadresponse.md)オブジェクトまたは[ServiceErrorResponse](../../json/json-serviceerrorresponse.md) JSON 形式のオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="3431b-194">The response can be an [InitialUploadResponse](../../json/json-initialuploadresponse.md) object or a [ServiceErrorResponse](../../json/json-serviceerrorresponse.md) object in JSON format.</span></span>
  
<a id="ID4EFBAC"></a>

 
## <a name="sample-response"></a><span data-ttu-id="3431b-195">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="3431b-195">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="3431b-196">関連項目</span><span class="sxs-lookup"><span data-stu-id="3431b-196">See also</span></span>
 
<a id="ID4EQBAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="3431b-197">Parent</span><span class="sxs-lookup"><span data-stu-id="3431b-197">Parent</span></span> 

[<span data-ttu-id="3431b-198">/users/me/scids/{scid}/clips</span><span class="sxs-lookup"><span data-stu-id="3431b-198">/users/me/scids/{scid}/clips</span></span>](uri-usersmescidclips.md)

   