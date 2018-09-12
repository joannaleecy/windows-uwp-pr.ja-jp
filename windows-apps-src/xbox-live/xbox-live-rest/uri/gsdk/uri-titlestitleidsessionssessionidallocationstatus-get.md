---
title: 取得する (/titles/{titleId}/sessions/{sessionId}/allocationStatus)
assetID: 613ba53f-03cb-5ed3-a5ba-be59e5a146d1
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidsessionssessionidallocationstatus-get.html
author: KevinAsgari
description: " 取得する (/titles/{titleId}/sessions/{sessionId}/allocationStatus)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1e351bed37e0761be1f884400f81a3da537967d2
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882107"
---
# <a name="get-titlestitleidsessionssessionidallocationstatus"></a><span data-ttu-id="26052-104">取得する (/titles/{titleId}/sessions/{sessionId}/allocationStatus)</span><span class="sxs-lookup"><span data-stu-id="26052-104">GET (/titles/{titleId}/sessions/{sessionId}/allocationStatus)</span></span>
<span data-ttu-id="26052-105">その sessionId によって識別 sessionhost の割り当てを取得します。</span><span class="sxs-lookup"><span data-stu-id="26052-105">Returns the allocation status of the sessionhost identified by its sessionId.</span></span> <span data-ttu-id="26052-106">これらの Uri のドメイン`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="26052-106">The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="26052-107">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="26052-107">Required Request Headers</span></span>](#ID4E4)
  * [<span data-ttu-id="26052-108">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="26052-108">Required Response Headers</span></span>](#ID4EEB)
  * [<span data-ttu-id="26052-109">応答本文</span><span class="sxs-lookup"><span data-stu-id="26052-109">Response Body</span></span>](#ID4ELB)
 
<a id="ID4E4"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="26052-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="26052-110">Required Request Headers</span></span>
 
<span data-ttu-id="26052-111">なし。</span><span class="sxs-lookup"><span data-stu-id="26052-111">None.</span></span>
  
<a id="ID4EEB"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="26052-112">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="26052-112">Required Response Headers</span></span>
 
<span data-ttu-id="26052-113">なし。</span><span class="sxs-lookup"><span data-stu-id="26052-113">None.</span></span>
  
<a id="ID4ELB"></a>

 
## <a name="response-body"></a><span data-ttu-id="26052-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="26052-114">Response Body</span></span>
 
<span data-ttu-id="26052-115">呼び出しが成功した場合、サービスは、次のメンバーを含む JSON オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="26052-115">If the call is successful, the service will return a JSON object with the following members.</span></span>
 
| <span data-ttu-id="26052-116">メンバー</span><span class="sxs-lookup"><span data-stu-id="26052-116">Member</span></span>| <span data-ttu-id="26052-117">説明</span><span class="sxs-lookup"><span data-stu-id="26052-117">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="26052-118">description</span><span class="sxs-lookup"><span data-stu-id="26052-118">description</span></span>| <span data-ttu-id="26052-119">返します空の文字列 (左での下位互換性)。</span><span class="sxs-lookup"><span data-stu-id="26052-119">Returns empty string (left in for backwards compatibility).</span></span>| 
| <span data-ttu-id="26052-120">clusterId</span><span class="sxs-lookup"><span data-stu-id="26052-120">clusterId</span></span>| <span data-ttu-id="26052-121">返します空の文字列 (左での下位互換性)。</span><span class="sxs-lookup"><span data-stu-id="26052-121">Returns empty string (left in for backwards compatibility).</span></span>| 
| <span data-ttu-id="26052-122">ホスト名</span><span class="sxs-lookup"><span data-stu-id="26052-122">hostName</span></span>| <span data-ttu-id="26052-123">セッション ホストの URL。</span><span class="sxs-lookup"><span data-stu-id="26052-123">The URL of the session host.</span></span>| 
| <span data-ttu-id="26052-124">status</span><span class="sxs-lookup"><span data-stu-id="26052-124">status</span></span>| <span data-ttu-id="26052-125">キューに入れ、フルフィルメントの完了、または中止いずれかを示します。</span><span class="sxs-lookup"><span data-stu-id="26052-125">Indicates either Queued, Fulfilled, or Aborted.</span></span>| 
| <span data-ttu-id="26052-126">sessionHostId</span><span class="sxs-lookup"><span data-stu-id="26052-126">sessionHostId</span></span>| <span data-ttu-id="26052-127">セッション ホストの id。</span><span class="sxs-lookup"><span data-stu-id="26052-127">The session host ID.</span></span>| 
| <span data-ttu-id="26052-128">sessionId</span><span class="sxs-lookup"><span data-stu-id="26052-128">sessionId</span></span>| <span data-ttu-id="26052-129">(割り当て時) に提供されるクライアント セッション id。</span><span class="sxs-lookup"><span data-stu-id="26052-129">The client provided (at allocation time) session ID.</span></span>| 
| <span data-ttu-id="26052-130">secureContext</span><span class="sxs-lookup"><span data-stu-id="26052-130">secureContext</span></span>| <span data-ttu-id="26052-131">セキュア デバイス アドレス。</span><span class="sxs-lookup"><span data-stu-id="26052-131">The secure device address.</span></span>| 
| <span data-ttu-id="26052-132">portMappings</span><span class="sxs-lookup"><span data-stu-id="26052-132">portMappings</span></span>| <span data-ttu-id="26052-133">インスタンスのポート マッピングします。</span><span class="sxs-lookup"><span data-stu-id="26052-133">The port mappings for the instance.</span></span>| 
| <span data-ttu-id="26052-134">地域</span><span class="sxs-lookup"><span data-stu-id="26052-134">region</span></span>| <span data-ttu-id="26052-135">インスタンスの場所。</span><span class="sxs-lookup"><span data-stu-id="26052-135">The location of the instance.</span></span>| 
| <span data-ttu-id="26052-136">ticketId</span><span class="sxs-lookup"><span data-stu-id="26052-136">ticketId</span></span>| <span data-ttu-id="26052-137">現在のセッション ID (左での下位互換性) です。</span><span class="sxs-lookup"><span data-stu-id="26052-137">The current session ID (left in for backwards compatibility).</span></span>| 
| <span data-ttu-id="26052-138">gameHostId</span><span class="sxs-lookup"><span data-stu-id="26052-138">gameHostId</span></span>| <span data-ttu-id="26052-139">(左での下位互換性) 現在 sessionHostId します。</span><span class="sxs-lookup"><span data-stu-id="26052-139">The current sessionHostId (left in for backwards compatibility).</span></span>| 
 
<a id="ID4EGD"></a>

 
### <a name="sample-response"></a><span data-ttu-id="26052-140">応答の例</span><span class="sxs-lookup"><span data-stu-id="26052-140">Sample Response</span></span>
 

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

 
### <a name="remarks"></a><span data-ttu-id="26052-141">注釈</span><span class="sxs-lookup"><span data-stu-id="26052-141">Remarks</span></span>
 
<span data-ttu-id="26052-142">次の応答コードを受信すると、タイトルはサービスに呼び出しを再試行のみする必要があります。</span><span class="sxs-lookup"><span data-stu-id="26052-142">A title should only retry the call to the service when the following response codes are received:</span></span>
 
   * <span data-ttu-id="26052-143">200-成功</span><span class="sxs-lookup"><span data-stu-id="26052-143">200—Success</span></span> 
   * <span data-ttu-id="26052-144">400-要求が無効なパラメーターが含まれています</span><span class="sxs-lookup"><span data-stu-id="26052-144">400—Request contains invalid parameters</span></span> 
   * <span data-ttu-id="26052-145">401: Unauthorized</span><span class="sxs-lookup"><span data-stu-id="26052-145">401—Unauthorized</span></span> 
   * <span data-ttu-id="26052-146">404-チケット ID、タイトル ID が無効であるか、または見つかりません。</span><span class="sxs-lookup"><span data-stu-id="26052-146">404—The title ID or ticket ID was invalid or not found</span></span> 
   * <span data-ttu-id="26052-147">500-サーバーの予期しないエラー。</span><span class="sxs-lookup"><span data-stu-id="26052-147">500—Unexpected server error.</span></span> 
    