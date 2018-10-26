---
title: GET (/qosservers)
assetID: 8b940c1b-947c-eab3-78ed-4384f57ea0bd
permalink: en-us/docs/xboxlive/rest/uri-qosservers-get.html
author: KevinAsgari
description: " GET (/qosservers)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 88ea56c99259b5b6fa0d20939d9f6434f80f9246
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5547115"
---
# <a name="get-qosservers"></a><span data-ttu-id="8d4a7-104">GET (/qosservers)</span><span class="sxs-lookup"><span data-stu-id="8d4a7-104">GET (/qosservers)</span></span>
<span data-ttu-id="8d4a7-105">URI が利用可能な QoS サーバーの一覧を取得する Xbox Live エンジンで使用するためにクライアントによって呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="8d4a7-105">URI called by a client to get the list of QoS servers available for use with Xbox Live Compute.</span></span> <span data-ttu-id="8d4a7-106">これらの Uri のドメインは、`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="8d4a7-106">The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="8d4a7-107">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8d4a7-107">Required Request Headers</span></span>](#ID4EBB)
  * [<span data-ttu-id="8d4a7-108">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8d4a7-108">Required Response Headers</span></span>](#ID4EUC)
  * [<span data-ttu-id="8d4a7-109">応答本文</span><span class="sxs-lookup"><span data-stu-id="8d4a7-109">Response Body</span></span>](#ID4EVD)
 
<a id="ID5EG"></a>

 
## <a name="host-name"></a><span data-ttu-id="8d4a7-110">ホスト名</span><span class="sxs-lookup"><span data-stu-id="8d4a7-110">Host Name</span></span>

<span data-ttu-id="8d4a7-111">gameserverds.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="8d4a7-111">gameserverds.xboxlive.com</span></span>
 
<a id="ID4EBB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="8d4a7-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8d4a7-112">Required Request Headers</span></span>
 
<span data-ttu-id="8d4a7-113">要求を行う場合、次の表に示すようにヘッダーは必要です。</span><span class="sxs-lookup"><span data-stu-id="8d4a7-113">When making a request, the headers shown in the following table are required.</span></span>
 
| <span data-ttu-id="8d4a7-114">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8d4a7-114">Header</span></span>| <span data-ttu-id="8d4a7-115">設定値</span><span class="sxs-lookup"><span data-stu-id="8d4a7-115">Value</span></span>| <span data-ttu-id="8d4a7-116">説明</span><span class="sxs-lookup"><span data-stu-id="8d4a7-116">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="8d4a7-117">Content-Type</span><span class="sxs-lookup"><span data-stu-id="8d4a7-117">Content-Type</span></span>| <span data-ttu-id="8d4a7-118">application/json</span><span class="sxs-lookup"><span data-stu-id="8d4a7-118">application/json</span></span>| <span data-ttu-id="8d4a7-119">送信されたデータの種類です。</span><span class="sxs-lookup"><span data-stu-id="8d4a7-119">Type of data being submitted.</span></span>| 
| <span data-ttu-id="8d4a7-120">Host</span><span class="sxs-lookup"><span data-stu-id="8d4a7-120">Host</span></span>| <span data-ttu-id="8d4a7-121">gameserverds.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="8d4a7-121">gameserverds.xboxlive.com</span></span>|  | 
| <span data-ttu-id="8d4a7-122">Content-Length</span><span class="sxs-lookup"><span data-stu-id="8d4a7-122">Content-Length</span></span>|  | <span data-ttu-id="8d4a7-123">要求のオブジェクトの長さ。</span><span class="sxs-lookup"><span data-stu-id="8d4a7-123">Length of the request object.</span></span>| 
| <span data-ttu-id="8d4a7-124">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="8d4a7-124">x-xbl-contract-version</span></span>| <span data-ttu-id="8d4a7-125">1</span><span class="sxs-lookup"><span data-stu-id="8d4a7-125">1</span></span>| <span data-ttu-id="8d4a7-126">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="8d4a7-126">API contract version.</span></span>| 
  
<a id="ID4EUC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="8d4a7-127">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8d4a7-127">Required Response Headers</span></span>
 
<span data-ttu-id="8d4a7-128">応答には常に、次の表に示すようにヘッダーが含まれます。</span><span class="sxs-lookup"><span data-stu-id="8d4a7-128">A response will always include the headers shown in the following table.</span></span>
 
| <span data-ttu-id="8d4a7-129">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8d4a7-129">Header</span></span>| <span data-ttu-id="8d4a7-130">設定値</span><span class="sxs-lookup"><span data-stu-id="8d4a7-130">Value</span></span>| <span data-ttu-id="8d4a7-131">説明</span><span class="sxs-lookup"><span data-stu-id="8d4a7-131">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="8d4a7-132">Content-Type</span><span class="sxs-lookup"><span data-stu-id="8d4a7-132">Content-Type</span></span>| <span data-ttu-id="8d4a7-133">application/json</span><span class="sxs-lookup"><span data-stu-id="8d4a7-133">application/json</span></span>| <span data-ttu-id="8d4a7-134">応答本文内のデータの種類です。</span><span class="sxs-lookup"><span data-stu-id="8d4a7-134">Type of data in the response body.</span></span>| 
| <span data-ttu-id="8d4a7-135">Content-Length</span><span class="sxs-lookup"><span data-stu-id="8d4a7-135">Content-Length</span></span>|  | <span data-ttu-id="8d4a7-136">応答本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="8d4a7-136">Length of the response body.</span></span>| 
  
<a id="ID4EVD"></a>

 
## <a name="response-body"></a><span data-ttu-id="8d4a7-137">応答本文</span><span class="sxs-lookup"><span data-stu-id="8d4a7-137">Response Body</span></span>
 
<span data-ttu-id="8d4a7-138">呼び出しが成功した場合、サービスは、次のメンバーを含む JSON オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="8d4a7-138">If the call is successful, the service will return a JSON object with the following members.</span></span>
 
| <span data-ttu-id="8d4a7-139">メンバー</span><span class="sxs-lookup"><span data-stu-id="8d4a7-139">Member</span></span>| <span data-ttu-id="8d4a7-140">説明</span><span class="sxs-lookup"><span data-stu-id="8d4a7-140">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="8d4a7-141">qosservers</span><span class="sxs-lookup"><span data-stu-id="8d4a7-141">qosservers</span></span>| <span data-ttu-id="8d4a7-142">サーバーの情報の配列です。</span><span class="sxs-lookup"><span data-stu-id="8d4a7-142">An array of server information.</span></span>| 
| <span data-ttu-id="8d4a7-143">serverFqdn</span><span class="sxs-lookup"><span data-stu-id="8d4a7-143">serverFqdn</span></span>| <span data-ttu-id="8d4a7-144">サーバーの完全修飾ドメイン名。</span><span class="sxs-lookup"><span data-stu-id="8d4a7-144">The fully qualified domain name of the server.</span></span>| 
| <span data-ttu-id="8d4a7-145">serverSecureDeviceAddress</span><span class="sxs-lookup"><span data-stu-id="8d4a7-145">serverSecureDeviceAddress</span></span>| <span data-ttu-id="8d4a7-146">サーバーのセキュア デバイス アドレス。</span><span class="sxs-lookup"><span data-stu-id="8d4a7-146">The secure device address of the server.</span></span>| 
| <span data-ttu-id="8d4a7-147">targetLocation</span><span class="sxs-lookup"><span data-stu-id="8d4a7-147">targetLocation</span></span>| <span data-ttu-id="8d4a7-148">サーバーの地理的な場所です。</span><span class="sxs-lookup"><span data-stu-id="8d4a7-148">The geographic location of the server.</span></span>| 
 
<a id="ID4EUE"></a>

 
### <a name="sample-response"></a><span data-ttu-id="8d4a7-149">応答の例</span><span class="sxs-lookup"><span data-stu-id="8d4a7-149">Sample Response</span></span>
 

```cpp
{ 
  "qosServers" : 
  [ 
    { "serverFqdn" : "xblqosncus.cloudapp.net", "serverSecureDeviceAddress" : "&lt;base-64 encoded blob>", "targetLocation" : "North Central US" },
    { "serverFqdn" : "xblqoswus.cloudapp.net", "serverSecureDeviceAddress" : "&lt;base-64 encoded blob>", "targetLocation" : "West US" },
  ]
}

      
```

   
<a id="ID4EBF"></a>

 
## <a name="see-also"></a><span data-ttu-id="8d4a7-150">関連項目</span><span class="sxs-lookup"><span data-stu-id="8d4a7-150">See also</span></span>
 [<span data-ttu-id="8d4a7-151">/qosservers</span><span class="sxs-lookup"><span data-stu-id="8d4a7-151">/qosservers</span></span>](uri-qosservers.md)

  