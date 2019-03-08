---
title: POST (/titles/{Title Id}/sessionhosts)
assetID: 8558b336-1af9-8143-9752-477ceb3a8e4e
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidsessionhosts-post.html
description: " POST (/titles/{Title Id}/sessionhosts)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 47e3ecbf0a519b92ae467199e5d454523864310a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655147"
---
# <a name="post-titlestitle-idsessionhosts"></a><span data-ttu-id="bc676-104">POST (/titles/{Title Id}/sessionhosts)</span><span class="sxs-lookup"><span data-stu-id="bc676-104">POST (/titles/{Title Id}/sessionhosts)</span></span>
<span data-ttu-id="bc676-105">クラスターの新しい要求を作成します。</span><span class="sxs-lookup"><span data-stu-id="bc676-105">Create new cluster request.</span></span> <span data-ttu-id="bc676-106">これらの Uri のドメインが`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="bc676-106">The domain for these URIs is `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="bc676-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bc676-107">URI Parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="bc676-108">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bc676-108">Required Request Headers</span></span>](#ID4EGB)
  * [<span data-ttu-id="bc676-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="bc676-109">Request Body</span></span>](#ID4E5B)
  * [<span data-ttu-id="bc676-110">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bc676-110">Required Response Headers</span></span>](#ID4ELD)
  * [<span data-ttu-id="bc676-111">応答本文</span><span class="sxs-lookup"><span data-stu-id="bc676-111">Response Body</span></span>](#ID4ESD)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="bc676-112">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bc676-112">URI Parameters</span></span>
 
| <span data-ttu-id="bc676-113">パラメーター</span><span class="sxs-lookup"><span data-stu-id="bc676-113">Parameter</span></span>| <span data-ttu-id="bc676-114">説明</span><span class="sxs-lookup"><span data-stu-id="bc676-114">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="bc676-115">titleId</span><span class="sxs-lookup"><span data-stu-id="bc676-115">titleId</span></span>| <span data-ttu-id="bc676-116">要求の操作対象のタイトルの ID。</span><span class="sxs-lookup"><span data-stu-id="bc676-116">ID of the title that the request should operate on.</span></span>| 
  
<a id="ID5EG"></a>

 
## <a name="host-name"></a><span data-ttu-id="bc676-117">ホスト名</span><span class="sxs-lookup"><span data-stu-id="bc676-117">Host Name</span></span>

<span data-ttu-id="bc676-118">gameserverms.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="bc676-118">gameserverms.xboxlive.com</span></span>
 
<a id="ID4EGB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="bc676-119">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bc676-119">Required Request Headers</span></span>
 
<span data-ttu-id="bc676-120">要求を行う場合は、次の表に示されているヘッダーが必要です。</span><span class="sxs-lookup"><span data-stu-id="bc676-120">When making a request, the headers shown in the following table are required.</span></span>
 
| <span data-ttu-id="bc676-121">Header</span><span class="sxs-lookup"><span data-stu-id="bc676-121">Header</span></span>| <span data-ttu-id="bc676-122">Value</span><span class="sxs-lookup"><span data-stu-id="bc676-122">Value</span></span>| <span data-ttu-id="bc676-123">説明</span><span class="sxs-lookup"><span data-stu-id="bc676-123">Description</span></span>| 
| --- | --- | --- | --- | --- | 
| <span data-ttu-id="bc676-124">Content-Type</span><span class="sxs-lookup"><span data-stu-id="bc676-124">Content-Type</span></span>| <span data-ttu-id="bc676-125">application/json</span><span class="sxs-lookup"><span data-stu-id="bc676-125">application/json</span></span>| <span data-ttu-id="bc676-126">送信されるデータの型。</span><span class="sxs-lookup"><span data-stu-id="bc676-126">Type of data being submitted.</span></span>| 
  
<a id="ID4E5B"></a>

 
## <a name="request-body"></a><span data-ttu-id="bc676-127">要求本文</span><span class="sxs-lookup"><span data-stu-id="bc676-127">Request Body</span></span>
 
<span data-ttu-id="bc676-128">要求には、次のメンバーを持つ JSON オブジェクトを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="bc676-128">The request must contain a JSON object with the following members.</span></span>
 
| <span data-ttu-id="bc676-129">メンバー</span><span class="sxs-lookup"><span data-stu-id="bc676-129">Member</span></span>| <span data-ttu-id="bc676-130">説明</span><span class="sxs-lookup"><span data-stu-id="bc676-130">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="bc676-131">sessionId</span><span class="sxs-lookup"><span data-stu-id="bc676-131">sessionId</span></span>| <span data-ttu-id="bc676-132">これは、指定された呼び出し元の識別子。</span><span class="sxs-lookup"><span data-stu-id="bc676-132">This is the caller specified identifier.</span></span> <span data-ttu-id="bc676-133">割り当てられているされ、返されるセッション ホストに割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="bc676-133">It is assigned to the session host that is allocated and returned.</span></span> <span data-ttu-id="bc676-134">後でこの識別子を使用して特定 sessionhost を参照することができます。</span><span class="sxs-lookup"><span data-stu-id="bc676-134">Later on you can reference the specific sessionhost by this identifier.</span></span> <span data-ttu-id="bc676-135">グローバルに一意である必要があります (つまり GUID)。</span><span class="sxs-lookup"><span data-stu-id="bc676-135">It must be globally unique (i.e. GUID).</span></span>| 
| <span data-ttu-id="bc676-136">sandboxId</span><span class="sxs-lookup"><span data-stu-id="bc676-136">SandboxId</span></span>| <span data-ttu-id="bc676-137">サンド ボックスで割り当てられるセッション ホストしたいです。</span><span class="sxs-lookup"><span data-stu-id="bc676-137">The sandbox you wish the session host to be allocated in.</span></span>| 
| <span data-ttu-id="bc676-138">cloudGameId</span><span class="sxs-lookup"><span data-stu-id="bc676-138">cloudGameId</span></span>| <span data-ttu-id="bc676-139">クラウド ゲームの識別子です。</span><span class="sxs-lookup"><span data-stu-id="bc676-139">The cloud game identifier.</span></span>| 
| <span data-ttu-id="bc676-140">場所</span><span class="sxs-lookup"><span data-stu-id="bc676-140">locations</span></span>| <span data-ttu-id="bc676-141">優先する場所の順序付きリストから割り当てられるセッションたいです。</span><span class="sxs-lookup"><span data-stu-id="bc676-141">The ordered list of preferred locations you would like the session to be allocated from.</span></span>| 
| <span data-ttu-id="bc676-142">sessionCookie</span><span class="sxs-lookup"><span data-stu-id="bc676-142">sessionCookie</span></span>| <span data-ttu-id="bc676-143">これは、呼び出し元が指定された非透過の文字列。</span><span class="sxs-lookup"><span data-stu-id="bc676-143">This is a caller specified opaque string.</span></span> <span data-ttu-id="bc676-144">関連付けられた、sessionhost と、ゲームのコードで参照できます。</span><span class="sxs-lookup"><span data-stu-id="bc676-144">It is associated with the sessionhost and can be referenced in your game code.</span></span> <span data-ttu-id="bc676-145">このメンバーを使用して、少量の情報をクライアントから (最大サイズは 4 KB) のサーバーに渡します。</span><span class="sxs-lookup"><span data-stu-id="bc676-145">Use this member to pass a small amount of information from the client to the server (Max size is 4KB).</span></span>| 
| <span data-ttu-id="bc676-146">gameModelId</span><span class="sxs-lookup"><span data-stu-id="bc676-146">gameModelId</span></span>| <span data-ttu-id="bc676-147">ゲーム モードの識別子です。</span><span class="sxs-lookup"><span data-stu-id="bc676-147">The game mode identifier.</span></span>| 
 
<a id="ID4EDD"></a>

 
### <a name="sample-request"></a><span data-ttu-id="bc676-148">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="bc676-148">Sample Request</span></span>
 

```cpp
{
        "sessionId": "3536d3e6-e85d-4f47-b898-9617d19dabcd",
        "sandboxId": "ISST.0",
        "cloudGameId": "1b7f9925-369c-4301-b1f7-1125dce25776",
        "locations": [
        "West US",
        "East US",
        "West Europe"
        ],
        "sessionCookie": "Caller provided opaque string",
        "gameModeId": "2162d32c-7ac8-40e9-9b1f-56676b8b2513"
        }
      
```

   
<a id="ID4ELD"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="bc676-149">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bc676-149">Required Response Headers</span></span>
 
<span data-ttu-id="bc676-150">なし。</span><span class="sxs-lookup"><span data-stu-id="bc676-150">None.</span></span>
  
<a id="ID4ESD"></a>

 
## <a name="response-body"></a><span data-ttu-id="bc676-151">応答本文</span><span class="sxs-lookup"><span data-stu-id="bc676-151">Response Body</span></span>
 
<span data-ttu-id="bc676-152">呼び出しが成功した場合、サービスは、次のメンバーを持つ JSON オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="bc676-152">If the call is successful, the service will return a JSON object with the following members.</span></span>
 
| <span data-ttu-id="bc676-153">メンバー</span><span class="sxs-lookup"><span data-stu-id="bc676-153">Member</span></span>| <span data-ttu-id="bc676-154">説明</span><span class="sxs-lookup"><span data-stu-id="bc676-154">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="bc676-155">ホスト名</span><span class="sxs-lookup"><span data-stu-id="bc676-155">hostName</span></span>| <span data-ttu-id="bc676-156">インスタンスのホスト名。</span><span class="sxs-lookup"><span data-stu-id="bc676-156">The host name of the instance.</span></span>| 
| <span data-ttu-id="bc676-157">portMappings</span><span class="sxs-lookup"><span data-stu-id="bc676-157">portMappings</span></span>| <span data-ttu-id="bc676-158">ポートのマッピング。</span><span class="sxs-lookup"><span data-stu-id="bc676-158">The port mappings.</span></span>| 
| <span data-ttu-id="bc676-159">リージョン</span><span class="sxs-lookup"><span data-stu-id="bc676-159">region</span></span>| <span data-ttu-id="bc676-160">リージョン、インスタンスがホストされます。</span><span class="sxs-lookup"><span data-stu-id="bc676-160">Region the instance is hosted in.</span></span>| 
| <span data-ttu-id="bc676-161">secureContext</span><span class="sxs-lookup"><span data-stu-id="bc676-161">secureContext</span></span>| <span data-ttu-id="bc676-162">セキュリティで保護されたデバイスのアドレス。</span><span class="sxs-lookup"><span data-stu-id="bc676-162">The secure device address.</span></span>| 
 
<a id="ID4ESE"></a>

 
### <a name="sample-response"></a><span data-ttu-id="bc676-163">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="bc676-163">Sample Response</span></span>
 

```cpp
{
        "hostName": "r111ybf4drgo12kq25tc-082yo7y9sz72f2odtq1ya5yhda-155169995-ncus.cloudapp.net",
        "portMappings": [
        {
        "Key": "GSDKTCPTest",
        "Value": {
        "internal": 10100,
        "external": 10103
        }
        },
        {
        "Key": "GSDKUDPTest",
        "Value": {
        "internal": 5000,
        "external": 5000
        }
        }
        ],
        "region": "WestUS",
        "secureContext": "AQDc8Hen/QCDJwWRPcW/1QEEAiABAACdOJU8JNujcXyUPwUBCnue+g=="
        }
      
```

   
<a id="remarks"></a>

 
## <a name="remarks"></a><span data-ttu-id="bc676-164">注釈</span><span class="sxs-lookup"><span data-stu-id="bc676-164">Remarks</span></span>
 
<span data-ttu-id="bc676-165">タイトルがサービスへの呼び出しを再試行する必要がありますは、次の応答コードが受信したときにのみ。</span><span class="sxs-lookup"><span data-stu-id="bc676-165">A title should only retry the call to the service when the following response codes are received:</span></span>
 
   * <span data-ttu-id="bc676-166">200: 成功の応答が返されます。</span><span class="sxs-lookup"><span data-stu-id="bc676-166">200—Success - response returned.</span></span>
   * <span data-ttu-id="bc676-167">400-無効なパラメーターまたは形式が正しくない要求の本文。</span><span class="sxs-lookup"><span data-stu-id="bc676-167">400—Invalid parameters or malformed request body.</span></span>
   * <span data-ttu-id="bc676-168">401-権限がありません</span><span class="sxs-lookup"><span data-stu-id="bc676-168">401—Unauthorized</span></span>
   * <span data-ttu-id="bc676-169">404-タイトル id はそれに割り当てられているすべてのサブスクリプションにありません。</span><span class="sxs-lookup"><span data-stu-id="bc676-169">404—Title id doesnt have any subscriptions assigned to it.</span></span>
   * <span data-ttu-id="bc676-170">409 — この応答は同じ要求には、ほぼ同時に (同じ sessionId) が終わったら、します。</span><span class="sxs-lookup"><span data-stu-id="bc676-170">409—When identical request are made (same sessionId) at roughly the same time, this response is possible.</span></span> <span data-ttu-id="bc676-171">場合は、割り当て要求が行われ、セッション ホストが既に指定したセッション Id が既にアクティブには、その sessionhost に関する詳細情報が返されます。</span><span class="sxs-lookup"><span data-stu-id="bc676-171">If an allocate request is made and a session host already has the specified sessionId AND it is already Active we will return information detailing that sessionhost.</span></span> <span data-ttu-id="bc676-172">セッション ホストがない場合アクティブなは、まだ、競合が表示されます。</span><span class="sxs-lookup"><span data-stu-id="bc676-172">If the session host however, is NOT Active yet, you will receive a Conflict.</span></span>
   * <span data-ttu-id="bc676-173">500-予期しないサーバー エラー。</span><span class="sxs-lookup"><span data-stu-id="bc676-173">500—Unexpected server error.</span></span>
   * <span data-ttu-id="bc676-174">503-ありません sessionhosts StandingBy します。</span><span class="sxs-lookup"><span data-stu-id="bc676-174">503—No sessionhosts StandingBy.</span></span> <span data-ttu-id="bc676-175">これらのリソースの一部は無料ときは、要求を再試行します。</span><span class="sxs-lookup"><span data-stu-id="bc676-175">Retry the request when some of these resources are free.</span></span>
   
<a id="ID4EFG"></a>

 
## <a name="see-also"></a><span data-ttu-id="bc676-176">関連項目</span><span class="sxs-lookup"><span data-stu-id="bc676-176">See also</span></span>
 [<span data-ttu-id="bc676-177">/titles/{titleId}/sessionhosts</span><span class="sxs-lookup"><span data-stu-id="bc676-177">/titles/{titleId}/sessionhosts</span></span>](uri-titlestitleidsessionhosts.md)

  