---
title: POST (/titles/{Title Id}/sessionhosts)
assetID: 8558b336-1af9-8143-9752-477ceb3a8e4e
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidsessionhosts-post.html
author: KevinAsgari
description: " POST (/titles/{Title Id}/sessionhosts)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 147df5a3032aa950b7b301f7990c5456db200d2c
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4468346"
---
# <a name="post-titlestitle-idsessionhosts"></a><span data-ttu-id="e532e-104">POST (/titles/{Title Id}/sessionhosts)</span><span class="sxs-lookup"><span data-stu-id="e532e-104">POST (/titles/{Title Id}/sessionhosts)</span></span>
<span data-ttu-id="e532e-105">新しいクラスターの要求を作成します。</span><span class="sxs-lookup"><span data-stu-id="e532e-105">Create new cluster request.</span></span> <span data-ttu-id="e532e-106">これらの Uri のドメインが`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="e532e-106">The domain for these URIs is `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="e532e-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e532e-107">URI Parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="e532e-108">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e532e-108">Required Request Headers</span></span>](#ID4EGB)
  * [<span data-ttu-id="e532e-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="e532e-109">Request Body</span></span>](#ID4E5B)
  * [<span data-ttu-id="e532e-110">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e532e-110">Required Response Headers</span></span>](#ID4ELD)
  * [<span data-ttu-id="e532e-111">応答本文</span><span class="sxs-lookup"><span data-stu-id="e532e-111">Response Body</span></span>](#ID4ESD)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="e532e-112">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e532e-112">URI Parameters</span></span>
 
| <span data-ttu-id="e532e-113">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e532e-113">Parameter</span></span>| <span data-ttu-id="e532e-114">説明</span><span class="sxs-lookup"><span data-stu-id="e532e-114">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="e532e-115">titleId</span><span class="sxs-lookup"><span data-stu-id="e532e-115">titleId</span></span>| <span data-ttu-id="e532e-116">要求の操作のタイトルの ID です。</span><span class="sxs-lookup"><span data-stu-id="e532e-116">ID of the title that the request should operate on.</span></span>| 
  
<a id="ID5EG"></a>

 
## <a name="host-name"></a><span data-ttu-id="e532e-117">ホスト名</span><span class="sxs-lookup"><span data-stu-id="e532e-117">Host Name</span></span>

<span data-ttu-id="e532e-118">gameserverms.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="e532e-118">gameserverms.xboxlive.com</span></span>
 
<a id="ID4EGB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="e532e-119">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e532e-119">Required Request Headers</span></span>
 
<span data-ttu-id="e532e-120">要求を行う場合、次の表に示すようにヘッダーは必要です。</span><span class="sxs-lookup"><span data-stu-id="e532e-120">When making a request, the headers shown in the following table are required.</span></span>
 
| <span data-ttu-id="e532e-121">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e532e-121">Header</span></span>| <span data-ttu-id="e532e-122">設定値</span><span class="sxs-lookup"><span data-stu-id="e532e-122">Value</span></span>| <span data-ttu-id="e532e-123">説明</span><span class="sxs-lookup"><span data-stu-id="e532e-123">Description</span></span>| 
| --- | --- | --- | --- | --- | 
| <span data-ttu-id="e532e-124">Content-Type</span><span class="sxs-lookup"><span data-stu-id="e532e-124">Content-Type</span></span>| <span data-ttu-id="e532e-125">application/json</span><span class="sxs-lookup"><span data-stu-id="e532e-125">application/json</span></span>| <span data-ttu-id="e532e-126">送信されたデータの種類です。</span><span class="sxs-lookup"><span data-stu-id="e532e-126">Type of data being submitted.</span></span>| 
  
<a id="ID4E5B"></a>

 
## <a name="request-body"></a><span data-ttu-id="e532e-127">要求本文</span><span class="sxs-lookup"><span data-stu-id="e532e-127">Request Body</span></span>
 
<span data-ttu-id="e532e-128">要求は、次のメンバーを含む JSON オブジェクトを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="e532e-128">The request must contain a JSON object with the following members.</span></span>
 
| <span data-ttu-id="e532e-129">メンバー</span><span class="sxs-lookup"><span data-stu-id="e532e-129">Member</span></span>| <span data-ttu-id="e532e-130">説明</span><span class="sxs-lookup"><span data-stu-id="e532e-130">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e532e-131">sessionId</span><span class="sxs-lookup"><span data-stu-id="e532e-131">sessionId</span></span>| <span data-ttu-id="e532e-132">これは、指定した呼び出し元の識別子。</span><span class="sxs-lookup"><span data-stu-id="e532e-132">This is the caller specified identifier.</span></span> <span data-ttu-id="e532e-133">割り当てられ、返されるセッション ホストに割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="e532e-133">It is assigned to the session host that is allocated and returned.</span></span> <span data-ttu-id="e532e-134">後でこの識別子を特定 sessionhost を参照できます。</span><span class="sxs-lookup"><span data-stu-id="e532e-134">Later on you can reference the specific sessionhost by this identifier.</span></span> <span data-ttu-id="e532e-135">グローバルに一意である必要があります (つまり GUID)。</span><span class="sxs-lookup"><span data-stu-id="e532e-135">It must be globally unique (i.e. GUID).</span></span>| 
| <span data-ttu-id="e532e-136">SandboxId</span><span class="sxs-lookup"><span data-stu-id="e532e-136">SandboxId</span></span>| <span data-ttu-id="e532e-137">サンド ボックスで割り当てられるセッション ホストをします。</span><span class="sxs-lookup"><span data-stu-id="e532e-137">The sandbox you wish the session host to be allocated in.</span></span>| 
| <span data-ttu-id="e532e-138">cloudGameId</span><span class="sxs-lookup"><span data-stu-id="e532e-138">cloudGameId</span></span>| <span data-ttu-id="e532e-139">クラウド ゲームの識別子です。</span><span class="sxs-lookup"><span data-stu-id="e532e-139">The cloud game identifier.</span></span>| 
| <span data-ttu-id="e532e-140">場所</span><span class="sxs-lookup"><span data-stu-id="e532e-140">locations</span></span>| <span data-ttu-id="e532e-141">優先する場所の順序指定された一覧から割り当てられるセッションたいです。</span><span class="sxs-lookup"><span data-stu-id="e532e-141">The ordered list of preferred locations you would like the session to be allocated from.</span></span>| 
| <span data-ttu-id="e532e-142">sessionCookie</span><span class="sxs-lookup"><span data-stu-id="e532e-142">sessionCookie</span></span>| <span data-ttu-id="e532e-143">これは、呼び出し元が指定されている不透明な文字列です。</span><span class="sxs-lookup"><span data-stu-id="e532e-143">This is a caller specified opaque string.</span></span> <span data-ttu-id="e532e-144">関連付け、sessionhost られているし、ゲームのコードで参照できます。</span><span class="sxs-lookup"><span data-stu-id="e532e-144">It is associated with the sessionhost and can be referenced in your game code.</span></span> <span data-ttu-id="e532e-145">このメンバーを使用して、クライアントから少量の情報を (最大サイズは 4 KB) サーバーに渡します。</span><span class="sxs-lookup"><span data-stu-id="e532e-145">Use this member to pass a small amount of information from the client to the server (Max size is 4KB).</span></span>| 
| <span data-ttu-id="e532e-146">gameModelId</span><span class="sxs-lookup"><span data-stu-id="e532e-146">gameModelId</span></span>| <span data-ttu-id="e532e-147">ゲーム モードの識別子です。</span><span class="sxs-lookup"><span data-stu-id="e532e-147">The game mode identifier.</span></span>| 
 
<a id="ID4EDD"></a>

 
### <a name="sample-request"></a><span data-ttu-id="e532e-148">要求の例</span><span class="sxs-lookup"><span data-stu-id="e532e-148">Sample Request</span></span>
 

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

 
## <a name="required-response-headers"></a><span data-ttu-id="e532e-149">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e532e-149">Required Response Headers</span></span>
 
<span data-ttu-id="e532e-150">なし。</span><span class="sxs-lookup"><span data-stu-id="e532e-150">None.</span></span>
  
<a id="ID4ESD"></a>

 
## <a name="response-body"></a><span data-ttu-id="e532e-151">応答本文</span><span class="sxs-lookup"><span data-stu-id="e532e-151">Response Body</span></span>
 
<span data-ttu-id="e532e-152">呼び出しが成功した場合は、サービスは、次のメンバーを含む JSON オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="e532e-152">If the call is successful, the service will return a JSON object with the following members.</span></span>
 
| <span data-ttu-id="e532e-153">メンバー</span><span class="sxs-lookup"><span data-stu-id="e532e-153">Member</span></span>| <span data-ttu-id="e532e-154">説明</span><span class="sxs-lookup"><span data-stu-id="e532e-154">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e532e-155">ホスト名</span><span class="sxs-lookup"><span data-stu-id="e532e-155">hostName</span></span>| <span data-ttu-id="e532e-156">インスタンスのホスト名。</span><span class="sxs-lookup"><span data-stu-id="e532e-156">The host name of the instance.</span></span>| 
| <span data-ttu-id="e532e-157">portMappings</span><span class="sxs-lookup"><span data-stu-id="e532e-157">portMappings</span></span>| <span data-ttu-id="e532e-158">ポートのマッピングです。</span><span class="sxs-lookup"><span data-stu-id="e532e-158">The port mappings.</span></span>| 
| <span data-ttu-id="e532e-159">地域</span><span class="sxs-lookup"><span data-stu-id="e532e-159">region</span></span>| <span data-ttu-id="e532e-160">地域のインスタンスがでホストされています。</span><span class="sxs-lookup"><span data-stu-id="e532e-160">Region the instance is hosted in.</span></span>| 
| <span data-ttu-id="e532e-161">secureContext</span><span class="sxs-lookup"><span data-stu-id="e532e-161">secureContext</span></span>| <span data-ttu-id="e532e-162">セキュア デバイス アドレスです。</span><span class="sxs-lookup"><span data-stu-id="e532e-162">The secure device address.</span></span>| 
 
<a id="ID4ESE"></a>

 
### <a name="sample-response"></a><span data-ttu-id="e532e-163">応答の例</span><span class="sxs-lookup"><span data-stu-id="e532e-163">Sample Response</span></span>
 

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

 
## <a name="remarks"></a><span data-ttu-id="e532e-164">注釈</span><span class="sxs-lookup"><span data-stu-id="e532e-164">Remarks</span></span>
 
<span data-ttu-id="e532e-165">次の応答コードを受け取ったとき、タイトルはサービスに呼び出しをのみ再試行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e532e-165">A title should only retry the call to the service when the following response codes are received:</span></span>
 
   * <span data-ttu-id="e532e-166">200-成功の応答が返されます。</span><span class="sxs-lookup"><span data-stu-id="e532e-166">200—Success - response returned.</span></span>
   * <span data-ttu-id="e532e-167">400-無効なパラメーターまたは形式が正しくない要求本文。</span><span class="sxs-lookup"><span data-stu-id="e532e-167">400—Invalid parameters or malformed request body.</span></span>
   * <span data-ttu-id="e532e-168">401: Unauthorized</span><span class="sxs-lookup"><span data-stu-id="e532e-168">401—Unauthorized</span></span>
   * <span data-ttu-id="e532e-169">404-タイトル id を割り当てられているすべてのサブスクリプションはありません。</span><span class="sxs-lookup"><span data-stu-id="e532e-169">404—Title id doesnt have any subscriptions assigned to it.</span></span>
   * <span data-ttu-id="e532e-170">409-この応答が可能な場合、同じ要求が同時にほぼで (同じ sessionId) に加えられたします。</span><span class="sxs-lookup"><span data-stu-id="e532e-170">409—When identical request are made (same sessionId) at roughly the same time, this response is possible.</span></span> <span data-ttu-id="e532e-171">セッションのホストが既に指定した sessionId しアクティブになって、割り当て要求が行われた場合はその sessionhost に関する詳細情報が返されます。</span><span class="sxs-lookup"><span data-stu-id="e532e-171">If an allocate request is made and a session host already has the specified sessionId AND it is already Active we will return information detailing that sessionhost.</span></span> <span data-ttu-id="e532e-172">セッション ホストただしがない場合アクティブなは、まだ、競合が表示されます。</span><span class="sxs-lookup"><span data-stu-id="e532e-172">If the session host however, is NOT Active yet, you will receive a Conflict.</span></span>
   * <span data-ttu-id="e532e-173">500-予期しないサーバー エラー。</span><span class="sxs-lookup"><span data-stu-id="e532e-173">500—Unexpected server error.</span></span>
   * <span data-ttu-id="e532e-174">503-なし sessionhosts StandingBy します。</span><span class="sxs-lookup"><span data-stu-id="e532e-174">503—No sessionhosts StandingBy.</span></span> <span data-ttu-id="e532e-175">これらのリソースの一部は無料ときは、要求を再試行します。</span><span class="sxs-lookup"><span data-stu-id="e532e-175">Retry the request when some of these resources are free.</span></span>
   
<a id="ID4EFG"></a>

 
## <a name="see-also"></a><span data-ttu-id="e532e-176">関連項目</span><span class="sxs-lookup"><span data-stu-id="e532e-176">See also</span></span>
 [<span data-ttu-id="e532e-177">/titles/{titleId}/sessionhosts</span><span class="sxs-lookup"><span data-stu-id="e532e-177">/titles/{titleId}/sessionhosts</span></span>](uri-titlestitleidsessionhosts.md)

  