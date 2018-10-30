---
title: GET (/titles/{titleId}/sessions/{sessionId}/allocationStatus)
assetID: 613ba53f-03cb-5ed3-a5ba-be59e5a146d1
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidsessionssessionidallocationstatus-get.html
author: KevinAsgari
description: " GET (/titles/{titleId}/sessions/{sessionId}/allocationStatus)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4da982d9ce3c1f24b00c62a3668253f086b41f55
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5741191"
---
# <a name="get-titlestitleidsessionssessionidallocationstatus"></a><span data-ttu-id="8f39a-104">GET (/titles/{titleId}/sessions/{sessionId}/allocationStatus)</span><span class="sxs-lookup"><span data-stu-id="8f39a-104">GET (/titles/{titleId}/sessions/{sessionId}/allocationStatus)</span></span>
<span data-ttu-id="8f39a-105">その sessionId によって識別 sessionhost の割り当てを取得します。</span><span class="sxs-lookup"><span data-stu-id="8f39a-105">Returns the allocation status of the sessionhost identified by its sessionId.</span></span> <span data-ttu-id="8f39a-106">これらの Uri のドメインは、`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="8f39a-106">The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="8f39a-107">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8f39a-107">Required Request Headers</span></span>](#ID4E4)
  * [<span data-ttu-id="8f39a-108">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8f39a-108">Required Response Headers</span></span>](#ID4EEB)
  * [<span data-ttu-id="8f39a-109">応答本文</span><span class="sxs-lookup"><span data-stu-id="8f39a-109">Response Body</span></span>](#ID4ELB)
 
<a id="ID4E4"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="8f39a-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8f39a-110">Required Request Headers</span></span>
 
<span data-ttu-id="8f39a-111">なし。</span><span class="sxs-lookup"><span data-stu-id="8f39a-111">None.</span></span>
  
<a id="ID4EEB"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="8f39a-112">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8f39a-112">Required Response Headers</span></span>
 
<span data-ttu-id="8f39a-113">なし。</span><span class="sxs-lookup"><span data-stu-id="8f39a-113">None.</span></span>
  
<a id="ID4ELB"></a>

 
## <a name="response-body"></a><span data-ttu-id="8f39a-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="8f39a-114">Response Body</span></span>
 
<span data-ttu-id="8f39a-115">呼び出しが成功した場合、サービスは、次のメンバーを含む JSON オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="8f39a-115">If the call is successful, the service will return a JSON object with the following members.</span></span>
 
| <span data-ttu-id="8f39a-116">メンバー</span><span class="sxs-lookup"><span data-stu-id="8f39a-116">Member</span></span>| <span data-ttu-id="8f39a-117">説明</span><span class="sxs-lookup"><span data-stu-id="8f39a-117">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="8f39a-118">description</span><span class="sxs-lookup"><span data-stu-id="8f39a-118">description</span></span>| <span data-ttu-id="8f39a-119">空の文字列 (左での下位互換性) を返します。</span><span class="sxs-lookup"><span data-stu-id="8f39a-119">Returns empty string (left in for backwards compatibility).</span></span>| 
| <span data-ttu-id="8f39a-120">clusterId</span><span class="sxs-lookup"><span data-stu-id="8f39a-120">clusterId</span></span>| <span data-ttu-id="8f39a-121">空の文字列 (左での下位互換性) を返します。</span><span class="sxs-lookup"><span data-stu-id="8f39a-121">Returns empty string (left in for backwards compatibility).</span></span>| 
| <span data-ttu-id="8f39a-122">ホスト名</span><span class="sxs-lookup"><span data-stu-id="8f39a-122">hostName</span></span>| <span data-ttu-id="8f39a-123">セッションのホストの URL。</span><span class="sxs-lookup"><span data-stu-id="8f39a-123">The URL of the session host.</span></span>| 
| <span data-ttu-id="8f39a-124">status</span><span class="sxs-lookup"><span data-stu-id="8f39a-124">status</span></span>| <span data-ttu-id="8f39a-125">キューに入れ、満たされると、または中止されたことを示します。</span><span class="sxs-lookup"><span data-stu-id="8f39a-125">Indicates either Queued, Fulfilled, or Aborted.</span></span>| 
| <span data-ttu-id="8f39a-126">sessionHostId</span><span class="sxs-lookup"><span data-stu-id="8f39a-126">sessionHostId</span></span>| <span data-ttu-id="8f39a-127">セッション ホストの id。</span><span class="sxs-lookup"><span data-stu-id="8f39a-127">The session host ID.</span></span>| 
| <span data-ttu-id="8f39a-128">sessionId</span><span class="sxs-lookup"><span data-stu-id="8f39a-128">sessionId</span></span>| <span data-ttu-id="8f39a-129">(割り当て時) に提供されるクライアント セッション id。</span><span class="sxs-lookup"><span data-stu-id="8f39a-129">The client provided (at allocation time) session ID.</span></span>| 
| <span data-ttu-id="8f39a-130">secureContext</span><span class="sxs-lookup"><span data-stu-id="8f39a-130">secureContext</span></span>| <span data-ttu-id="8f39a-131">セキュア デバイス アドレスです。</span><span class="sxs-lookup"><span data-stu-id="8f39a-131">The secure device address.</span></span>| 
| <span data-ttu-id="8f39a-132">portMappings</span><span class="sxs-lookup"><span data-stu-id="8f39a-132">portMappings</span></span>| <span data-ttu-id="8f39a-133">インスタンスのポート マッピングします。</span><span class="sxs-lookup"><span data-stu-id="8f39a-133">The port mappings for the instance.</span></span>| 
| <span data-ttu-id="8f39a-134">地域</span><span class="sxs-lookup"><span data-stu-id="8f39a-134">region</span></span>| <span data-ttu-id="8f39a-135">インスタンスの場所です。</span><span class="sxs-lookup"><span data-stu-id="8f39a-135">The location of the instance.</span></span>| 
| <span data-ttu-id="8f39a-136">ticketId</span><span class="sxs-lookup"><span data-stu-id="8f39a-136">ticketId</span></span>| <span data-ttu-id="8f39a-137">現在のセッション ID です (左での下位互換性)。</span><span class="sxs-lookup"><span data-stu-id="8f39a-137">The current session ID (left in for backwards compatibility).</span></span>| 
| <span data-ttu-id="8f39a-138">gameHostId</span><span class="sxs-lookup"><span data-stu-id="8f39a-138">gameHostId</span></span>| <span data-ttu-id="8f39a-139">(左での下位互換性) 現在 sessionHostId します。</span><span class="sxs-lookup"><span data-stu-id="8f39a-139">The current sessionHostId (left in for backwards compatibility).</span></span>| 
 
<a id="ID4EGD"></a>

 
### <a name="sample-response"></a><span data-ttu-id="8f39a-140">応答の例</span><span class="sxs-lookup"><span data-stu-id="8f39a-140">Sample Response</span></span>
 

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

 
### <a name="remarks"></a><span data-ttu-id="8f39a-141">注釈</span><span class="sxs-lookup"><span data-stu-id="8f39a-141">Remarks</span></span>
 
<span data-ttu-id="8f39a-142">次の応答コードを受信したとき、タイトルはサービスに呼び出しをのみ再試行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8f39a-142">A title should only retry the call to the service when the following response codes are received:</span></span>
 
   * <span data-ttu-id="8f39a-143">200-成功</span><span class="sxs-lookup"><span data-stu-id="8f39a-143">200—Success</span></span> 
   * <span data-ttu-id="8f39a-144">400-要求が無効なパラメーターが含まれています</span><span class="sxs-lookup"><span data-stu-id="8f39a-144">400—Request contains invalid parameters</span></span> 
   * <span data-ttu-id="8f39a-145">401: Unauthorized</span><span class="sxs-lookup"><span data-stu-id="8f39a-145">401—Unauthorized</span></span> 
   * <span data-ttu-id="8f39a-146">404-チケット ID、タイトル ID が無効であるか、または見つかりません。</span><span class="sxs-lookup"><span data-stu-id="8f39a-146">404—The title ID or ticket ID was invalid or not found</span></span> 
   * <span data-ttu-id="8f39a-147">500-サーバーの予期しないエラー。</span><span class="sxs-lookup"><span data-stu-id="8f39a-147">500—Unexpected server error.</span></span> 
    