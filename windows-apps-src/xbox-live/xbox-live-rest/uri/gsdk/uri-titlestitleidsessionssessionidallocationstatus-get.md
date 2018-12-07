---
title: GET (/titles/{titleId}/sessions/{sessionId}/allocationStatus)
assetID: 613ba53f-03cb-5ed3-a5ba-be59e5a146d1
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidsessionssessionidallocationstatus-get.html
description: " GET (/titles/{titleId}/sessions/{sessionId}/allocationStatus)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 793d634bc1e3dc431b3797759751afb6dfd9c00a
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8731034"
---
# <a name="get-titlestitleidsessionssessionidallocationstatus"></a><span data-ttu-id="40565-104">GET (/titles/{titleId}/sessions/{sessionId}/allocationStatus)</span><span class="sxs-lookup"><span data-stu-id="40565-104">GET (/titles/{titleId}/sessions/{sessionId}/allocationStatus)</span></span>
<span data-ttu-id="40565-105">その sessionId で識別される sessionhost の割り当ての状態を返します。</span><span class="sxs-lookup"><span data-stu-id="40565-105">Returns the allocation status of the sessionhost identified by its sessionId.</span></span> <span data-ttu-id="40565-106">これらの Uri のドメインは、`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="40565-106">The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="40565-107">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="40565-107">Required Request Headers</span></span>](#ID4E4)
  * [<span data-ttu-id="40565-108">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="40565-108">Required Response Headers</span></span>](#ID4EEB)
  * [<span data-ttu-id="40565-109">応答本文</span><span class="sxs-lookup"><span data-stu-id="40565-109">Response Body</span></span>](#ID4ELB)
 
<a id="ID4E4"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="40565-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="40565-110">Required Request Headers</span></span>
 
<span data-ttu-id="40565-111">なし。</span><span class="sxs-lookup"><span data-stu-id="40565-111">None.</span></span>
  
<a id="ID4EEB"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="40565-112">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="40565-112">Required Response Headers</span></span>
 
<span data-ttu-id="40565-113">なし。</span><span class="sxs-lookup"><span data-stu-id="40565-113">None.</span></span>
  
<a id="ID4ELB"></a>

 
## <a name="response-body"></a><span data-ttu-id="40565-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="40565-114">Response Body</span></span>
 
<span data-ttu-id="40565-115">呼び出しが成功した場合は、サービスは、次のメンバーを含む JSON オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="40565-115">If the call is successful, the service will return a JSON object with the following members.</span></span>
 
| <span data-ttu-id="40565-116">メンバー</span><span class="sxs-lookup"><span data-stu-id="40565-116">Member</span></span>| <span data-ttu-id="40565-117">説明</span><span class="sxs-lookup"><span data-stu-id="40565-117">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="40565-118">description</span><span class="sxs-lookup"><span data-stu-id="40565-118">description</span></span>| <span data-ttu-id="40565-119">空の文字列 (左での下位互換性) を返します。</span><span class="sxs-lookup"><span data-stu-id="40565-119">Returns empty string (left in for backwards compatibility).</span></span>| 
| <span data-ttu-id="40565-120">clusterId</span><span class="sxs-lookup"><span data-stu-id="40565-120">clusterId</span></span>| <span data-ttu-id="40565-121">空の文字列 (左での下位互換性) を返します。</span><span class="sxs-lookup"><span data-stu-id="40565-121">Returns empty string (left in for backwards compatibility).</span></span>| 
| <span data-ttu-id="40565-122">ホスト名</span><span class="sxs-lookup"><span data-stu-id="40565-122">hostName</span></span>| <span data-ttu-id="40565-123">セッション ホストの URL。</span><span class="sxs-lookup"><span data-stu-id="40565-123">The URL of the session host.</span></span>| 
| <span data-ttu-id="40565-124">status</span><span class="sxs-lookup"><span data-stu-id="40565-124">status</span></span>| <span data-ttu-id="40565-125">キューに入れ、満たされると、または中止されたことを示します。</span><span class="sxs-lookup"><span data-stu-id="40565-125">Indicates either Queued, Fulfilled, or Aborted.</span></span>| 
| <span data-ttu-id="40565-126">sessionHostId</span><span class="sxs-lookup"><span data-stu-id="40565-126">sessionHostId</span></span>| <span data-ttu-id="40565-127">セッション ホストの id。</span><span class="sxs-lookup"><span data-stu-id="40565-127">The session host ID.</span></span>| 
| <span data-ttu-id="40565-128">sessionId</span><span class="sxs-lookup"><span data-stu-id="40565-128">sessionId</span></span>| <span data-ttu-id="40565-129">(割り当て時) に提供されるクライアント セッション id。</span><span class="sxs-lookup"><span data-stu-id="40565-129">The client provided (at allocation time) session ID.</span></span>| 
| <span data-ttu-id="40565-130">secureContext</span><span class="sxs-lookup"><span data-stu-id="40565-130">secureContext</span></span>| <span data-ttu-id="40565-131">セキュア デバイス アドレスです。</span><span class="sxs-lookup"><span data-stu-id="40565-131">The secure device address.</span></span>| 
| <span data-ttu-id="40565-132">portMappings</span><span class="sxs-lookup"><span data-stu-id="40565-132">portMappings</span></span>| <span data-ttu-id="40565-133">インスタンスのポート マッピングします。</span><span class="sxs-lookup"><span data-stu-id="40565-133">The port mappings for the instance.</span></span>| 
| <span data-ttu-id="40565-134">地域</span><span class="sxs-lookup"><span data-stu-id="40565-134">region</span></span>| <span data-ttu-id="40565-135">インスタンスの場所です。</span><span class="sxs-lookup"><span data-stu-id="40565-135">The location of the instance.</span></span>| 
| <span data-ttu-id="40565-136">ticketId</span><span class="sxs-lookup"><span data-stu-id="40565-136">ticketId</span></span>| <span data-ttu-id="40565-137">(左での下位互換性) の現在のセッション ID。</span><span class="sxs-lookup"><span data-stu-id="40565-137">The current session ID (left in for backwards compatibility).</span></span>| 
| <span data-ttu-id="40565-138">gameHostId</span><span class="sxs-lookup"><span data-stu-id="40565-138">gameHostId</span></span>| <span data-ttu-id="40565-139">(左での下位互換性) 現在 sessionHostId します。</span><span class="sxs-lookup"><span data-stu-id="40565-139">The current sessionHostId (left in for backwards compatibility).</span></span>| 
 
<a id="ID4EGD"></a>

 
### <a name="sample-response"></a><span data-ttu-id="40565-140">応答の例</span><span class="sxs-lookup"><span data-stu-id="40565-140">Sample Response</span></span>
 

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
        "status",:"Fulfilled",
        "region": "WestUS",
        "secureContext": "AQDc8Hen/QCDJwWRPcW/1QEEAiABAACdOJU8JNujcXyUPwUBCnue+g==",
        "sessionId": "05328154-1bbe-4f5b-8caa-4e44106712f9",
        "description": "",
        "clusterId": "",
        "sessionHostId": "r111ybf4drgo12kq25tc-082yo7y9sz72f2odtq1ya5yhda-155169995-ncus.GSDKAgent_IN_0.0",
        "ticketId": "05328154-1bbe-4f5b-8caa-4e44106712f9",
        "gameHostId": "r111ybf4drgo12kq25tc-082yo7y9sz72f2odtq1ya5yhda-155169995-ncus.GSDKAgent_IN_0.0"

      
```

  
<a id="remarks"></a>

 
### <a name="remarks"></a><span data-ttu-id="40565-141">注釈</span><span class="sxs-lookup"><span data-stu-id="40565-141">Remarks</span></span>
 
<span data-ttu-id="40565-142">次の応答コードを受け取ったとき、タイトルはサービスに呼び出しをのみ再試行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="40565-142">A title should only retry the call to the service when the following response codes are received:</span></span>
 
   * <span data-ttu-id="40565-143">200-成功</span><span class="sxs-lookup"><span data-stu-id="40565-143">200—Success</span></span> 
   * <span data-ttu-id="40565-144">400-要求が無効なパラメーターが含まれています</span><span class="sxs-lookup"><span data-stu-id="40565-144">400—Request contains invalid parameters</span></span> 
   * <span data-ttu-id="40565-145">401: Unauthorized</span><span class="sxs-lookup"><span data-stu-id="40565-145">401—Unauthorized</span></span> 
   * <span data-ttu-id="40565-146">404-チケット ID、タイトル ID が無効であるか、または見つかりません。</span><span class="sxs-lookup"><span data-stu-id="40565-146">404—The title ID or ticket ID was invalid or not found</span></span> 
   * <span data-ttu-id="40565-147">500-サーバーの予期しないエラー。</span><span class="sxs-lookup"><span data-stu-id="40565-147">500—Unexpected server error.</span></span> 
    