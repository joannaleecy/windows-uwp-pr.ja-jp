---
title: POST (/titles/{Title Id}/sessionhosts)
assetID: 8558b336-1af9-8143-9752-477ceb3a8e4e
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidsessionhosts-post.html
author: KevinAsgari
description: " POST (/titles/{Title Id}/sessionhosts)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dbbc7baf12daea485dec22389846e5e4acec16c1
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5760615"
---
# <a name="post-titlestitle-idsessionhosts"></a><span data-ttu-id="0adce-104">POST (/titles/{Title Id}/sessionhosts)</span><span class="sxs-lookup"><span data-stu-id="0adce-104">POST (/titles/{Title Id}/sessionhosts)</span></span>
<span data-ttu-id="0adce-105">新しいクラスターの要求を作成します。</span><span class="sxs-lookup"><span data-stu-id="0adce-105">Create new cluster request.</span></span> <span data-ttu-id="0adce-106">これらの Uri のドメインが`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="0adce-106">The domain for these URIs is `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="0adce-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0adce-107">URI Parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="0adce-108">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0adce-108">Required Request Headers</span></span>](#ID4EGB)
  * [<span data-ttu-id="0adce-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="0adce-109">Request Body</span></span>](#ID4E5B)
  * [<span data-ttu-id="0adce-110">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0adce-110">Required Response Headers</span></span>](#ID4ELD)
  * [<span data-ttu-id="0adce-111">応答本文</span><span class="sxs-lookup"><span data-stu-id="0adce-111">Response Body</span></span>](#ID4ESD)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="0adce-112">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0adce-112">URI Parameters</span></span>
 
| <span data-ttu-id="0adce-113">パラメーター</span><span class="sxs-lookup"><span data-stu-id="0adce-113">Parameter</span></span>| <span data-ttu-id="0adce-114">説明</span><span class="sxs-lookup"><span data-stu-id="0adce-114">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="0adce-115">titleId</span><span class="sxs-lookup"><span data-stu-id="0adce-115">titleId</span></span>| <span data-ttu-id="0adce-116">要求の操作のタイトルの ID です。</span><span class="sxs-lookup"><span data-stu-id="0adce-116">ID of the title that the request should operate on.</span></span>| 
  
<a id="ID5EG"></a>

 
## <a name="host-name"></a><span data-ttu-id="0adce-117">ホスト名</span><span class="sxs-lookup"><span data-stu-id="0adce-117">Host Name</span></span>

<span data-ttu-id="0adce-118">gameserverms.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="0adce-118">gameserverms.xboxlive.com</span></span>
 
<a id="ID4EGB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="0adce-119">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0adce-119">Required Request Headers</span></span>
 
<span data-ttu-id="0adce-120">要求を行う場合、次の表に示すようにヘッダーは必要です。</span><span class="sxs-lookup"><span data-stu-id="0adce-120">When making a request, the headers shown in the following table are required.</span></span>
 
| <span data-ttu-id="0adce-121">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0adce-121">Header</span></span>| <span data-ttu-id="0adce-122">設定値</span><span class="sxs-lookup"><span data-stu-id="0adce-122">Value</span></span>| <span data-ttu-id="0adce-123">説明</span><span class="sxs-lookup"><span data-stu-id="0adce-123">Description</span></span>| 
| --- | --- | --- | --- | --- | 
| <span data-ttu-id="0adce-124">Content-Type</span><span class="sxs-lookup"><span data-stu-id="0adce-124">Content-Type</span></span>| <span data-ttu-id="0adce-125">application/json</span><span class="sxs-lookup"><span data-stu-id="0adce-125">application/json</span></span>| <span data-ttu-id="0adce-126">送信されたデータの種類です。</span><span class="sxs-lookup"><span data-stu-id="0adce-126">Type of data being submitted.</span></span>| 
  
<a id="ID4E5B"></a>

 
## <a name="request-body"></a><span data-ttu-id="0adce-127">要求本文</span><span class="sxs-lookup"><span data-stu-id="0adce-127">Request Body</span></span>
 
<span data-ttu-id="0adce-128">要求は、次のメンバーを含む JSON オブジェクトを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="0adce-128">The request must contain a JSON object with the following members.</span></span>
 
| <span data-ttu-id="0adce-129">メンバー</span><span class="sxs-lookup"><span data-stu-id="0adce-129">Member</span></span>| <span data-ttu-id="0adce-130">説明</span><span class="sxs-lookup"><span data-stu-id="0adce-130">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0adce-131">sessionId</span><span class="sxs-lookup"><span data-stu-id="0adce-131">sessionId</span></span>| <span data-ttu-id="0adce-132">これは、指定した呼び出し元の識別子。</span><span class="sxs-lookup"><span data-stu-id="0adce-132">This is the caller specified identifier.</span></span> <span data-ttu-id="0adce-133">割り当てられ、返されるセッション ホストに割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="0adce-133">It is assigned to the session host that is allocated and returned.</span></span> <span data-ttu-id="0adce-134">後でこの識別子を特定 sessionhost を参照できます。</span><span class="sxs-lookup"><span data-stu-id="0adce-134">Later on you can reference the specific sessionhost by this identifier.</span></span> <span data-ttu-id="0adce-135">グローバルに一意である必要があります (つまり GUID)。</span><span class="sxs-lookup"><span data-stu-id="0adce-135">It must be globally unique (i.e. GUID).</span></span>| 
| <span data-ttu-id="0adce-136">SandboxId</span><span class="sxs-lookup"><span data-stu-id="0adce-136">SandboxId</span></span>| <span data-ttu-id="0adce-137">サンド ボックスで割り当てられるセッション ホストをします。</span><span class="sxs-lookup"><span data-stu-id="0adce-137">The sandbox you wish the session host to be allocated in.</span></span>| 
| <span data-ttu-id="0adce-138">cloudGameId</span><span class="sxs-lookup"><span data-stu-id="0adce-138">cloudGameId</span></span>| <span data-ttu-id="0adce-139">クラウド ゲームの識別子です。</span><span class="sxs-lookup"><span data-stu-id="0adce-139">The cloud game identifier.</span></span>| 
| <span data-ttu-id="0adce-140">場所</span><span class="sxs-lookup"><span data-stu-id="0adce-140">locations</span></span>| <span data-ttu-id="0adce-141">優先する場所の順序指定された一覧から割り当てられるセッションたいです。</span><span class="sxs-lookup"><span data-stu-id="0adce-141">The ordered list of preferred locations you would like the session to be allocated from.</span></span>| 
| <span data-ttu-id="0adce-142">sessionCookie</span><span class="sxs-lookup"><span data-stu-id="0adce-142">sessionCookie</span></span>| <span data-ttu-id="0adce-143">これは、呼び出し元が指定されている不透明な文字列です。</span><span class="sxs-lookup"><span data-stu-id="0adce-143">This is a caller specified opaque string.</span></span> <span data-ttu-id="0adce-144">これは、sessionhost に関連付けられたし、ゲームのコードで参照できます。</span><span class="sxs-lookup"><span data-stu-id="0adce-144">It is associated with the sessionhost and can be referenced in your game code.</span></span> <span data-ttu-id="0adce-145">このメンバーを使用して、クライアントから少量の情報を (最大サイズは 4 KB) サーバーに渡します。</span><span class="sxs-lookup"><span data-stu-id="0adce-145">Use this member to pass a small amount of information from the client to the server (Max size is 4KB).</span></span>| 
| <span data-ttu-id="0adce-146">gameModelId</span><span class="sxs-lookup"><span data-stu-id="0adce-146">gameModelId</span></span>| <span data-ttu-id="0adce-147">ゲーム モードの識別子です。</span><span class="sxs-lookup"><span data-stu-id="0adce-147">The game mode identifier.</span></span>| 
 
<a id="ID4EDD"></a>

 
### <a name="sample-request"></a><span data-ttu-id="0adce-148">要求の例</span><span class="sxs-lookup"><span data-stu-id="0adce-148">Sample Request</span></span>
 

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

 
## <a name="required-response-headers"></a><span data-ttu-id="0adce-149">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0adce-149">Required Response Headers</span></span>
 
<span data-ttu-id="0adce-150">なし。</span><span class="sxs-lookup"><span data-stu-id="0adce-150">None.</span></span>
  
<a id="ID4ESD"></a>

 
## <a name="response-body"></a><span data-ttu-id="0adce-151">応答本文</span><span class="sxs-lookup"><span data-stu-id="0adce-151">Response Body</span></span>
 
<span data-ttu-id="0adce-152">呼び出しが成功した場合、サービスは、次のメンバーを含む JSON オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="0adce-152">If the call is successful, the service will return a JSON object with the following members.</span></span>
 
| <span data-ttu-id="0adce-153">メンバー</span><span class="sxs-lookup"><span data-stu-id="0adce-153">Member</span></span>| <span data-ttu-id="0adce-154">説明</span><span class="sxs-lookup"><span data-stu-id="0adce-154">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0adce-155">ホスト名</span><span class="sxs-lookup"><span data-stu-id="0adce-155">hostName</span></span>| <span data-ttu-id="0adce-156">インスタンスのホスト名。</span><span class="sxs-lookup"><span data-stu-id="0adce-156">The host name of the instance.</span></span>| 
| <span data-ttu-id="0adce-157">portMappings</span><span class="sxs-lookup"><span data-stu-id="0adce-157">portMappings</span></span>| <span data-ttu-id="0adce-158">ポートのマッピングします。</span><span class="sxs-lookup"><span data-stu-id="0adce-158">The port mappings.</span></span>| 
| <span data-ttu-id="0adce-159">地域</span><span class="sxs-lookup"><span data-stu-id="0adce-159">region</span></span>| <span data-ttu-id="0adce-160">地域のインスタンスがでホストされています。</span><span class="sxs-lookup"><span data-stu-id="0adce-160">Region the instance is hosted in.</span></span>| 
| <span data-ttu-id="0adce-161">secureContext</span><span class="sxs-lookup"><span data-stu-id="0adce-161">secureContext</span></span>| <span data-ttu-id="0adce-162">セキュア デバイス アドレスです。</span><span class="sxs-lookup"><span data-stu-id="0adce-162">The secure device address.</span></span>| 
 
<a id="ID4ESE"></a>

 
### <a name="sample-response"></a><span data-ttu-id="0adce-163">応答の例</span><span class="sxs-lookup"><span data-stu-id="0adce-163">Sample Response</span></span>
 

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

 
## <a name="remarks"></a><span data-ttu-id="0adce-164">注釈</span><span class="sxs-lookup"><span data-stu-id="0adce-164">Remarks</span></span>
 
<span data-ttu-id="0adce-165">次の応答コードを受信したとき、タイトルはサービスに呼び出しをのみ再試行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0adce-165">A title should only retry the call to the service when the following response codes are received:</span></span>
 
   * <span data-ttu-id="0adce-166">200、成功の応答が返されます。</span><span class="sxs-lookup"><span data-stu-id="0adce-166">200—Success - response returned.</span></span>
   * <span data-ttu-id="0adce-167">400-無効なパラメーターまたは形式が正しくない要求本文。</span><span class="sxs-lookup"><span data-stu-id="0adce-167">400—Invalid parameters or malformed request body.</span></span>
   * <span data-ttu-id="0adce-168">401: Unauthorized</span><span class="sxs-lookup"><span data-stu-id="0adce-168">401—Unauthorized</span></span>
   * <span data-ttu-id="0adce-169">404-タイトル id を割り当てられているすべてのサブスクリプションはありません。</span><span class="sxs-lookup"><span data-stu-id="0adce-169">404—Title id doesnt have any subscriptions assigned to it.</span></span>
   * <span data-ttu-id="0adce-170">409-この応答が可能な場合、同じ要求が同時にほぼで (同じ sessionId) に加えられたします。</span><span class="sxs-lookup"><span data-stu-id="0adce-170">409—When identical request are made (same sessionId) at roughly the same time, this response is possible.</span></span> <span data-ttu-id="0adce-171">セッションのホストが既に指定した sessionId しアクティブになって、割り当て要求が行われた場合はその sessionhost に関する詳細情報が返されます。</span><span class="sxs-lookup"><span data-stu-id="0adce-171">If an allocate request is made and a session host already has the specified sessionId AND it is already Active we will return information detailing that sessionhost.</span></span> <span data-ttu-id="0adce-172">セッション ホストただしがない場合アクティブなは、まだ、競合が表示されます。</span><span class="sxs-lookup"><span data-stu-id="0adce-172">If the session host however, is NOT Active yet, you will receive a Conflict.</span></span>
   * <span data-ttu-id="0adce-173">500-サーバーの予期しないエラー。</span><span class="sxs-lookup"><span data-stu-id="0adce-173">500—Unexpected server error.</span></span>
   * <span data-ttu-id="0adce-174">503-sessionhosts StandingBy しません。</span><span class="sxs-lookup"><span data-stu-id="0adce-174">503—No sessionhosts StandingBy.</span></span> <span data-ttu-id="0adce-175">これらのリソースの一部は無料ときは、要求を再試行します。</span><span class="sxs-lookup"><span data-stu-id="0adce-175">Retry the request when some of these resources are free.</span></span>
   
<a id="ID4EFG"></a>

 
## <a name="see-also"></a><span data-ttu-id="0adce-176">関連項目</span><span class="sxs-lookup"><span data-stu-id="0adce-176">See also</span></span>
 [<span data-ttu-id="0adce-177">/titles/{titleId}/sessionhosts</span><span class="sxs-lookup"><span data-stu-id="0adce-177">/titles/{titleId}/sessionhosts</span></span>](uri-titlestitleidsessionhosts.md)

  