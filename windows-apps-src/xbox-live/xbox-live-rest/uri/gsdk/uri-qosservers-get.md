---
title: GET (/qosservers)
assetID: 8b940c1b-947c-eab3-78ed-4384f57ea0bd
permalink: en-us/docs/xboxlive/rest/uri-qosservers-get.html
description: " GET (/qosservers)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 02d24dbf1d189b759784dbbfa7052e2c218ec27e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57632067"
---
# <a name="get-qosservers"></a><span data-ttu-id="b84e3-104">GET (/qosservers)</span><span class="sxs-lookup"><span data-stu-id="b84e3-104">GET (/qosservers)</span></span>
<span data-ttu-id="b84e3-105">Xbox Live コンピューティングで使用するために使用できる QoS サーバーの一覧を取得するクライアントから呼び出す URI。</span><span class="sxs-lookup"><span data-stu-id="b84e3-105">URI called by a client to get the list of QoS servers available for use with Xbox Live Compute.</span></span> <span data-ttu-id="b84e3-106">これらの Uri のドメインが`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b84e3-106">The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="b84e3-107">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b84e3-107">Required Request Headers</span></span>](#ID4EBB)
  * [<span data-ttu-id="b84e3-108">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b84e3-108">Required Response Headers</span></span>](#ID4EUC)
  * [<span data-ttu-id="b84e3-109">応答本文</span><span class="sxs-lookup"><span data-stu-id="b84e3-109">Response Body</span></span>](#ID4EVD)
 
<a id="ID5EG"></a>

 
## <a name="host-name"></a><span data-ttu-id="b84e3-110">ホスト名</span><span class="sxs-lookup"><span data-stu-id="b84e3-110">Host Name</span></span>

<span data-ttu-id="b84e3-111">gameserverds.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="b84e3-111">gameserverds.xboxlive.com</span></span>
 
<a id="ID4EBB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="b84e3-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b84e3-112">Required Request Headers</span></span>
 
<span data-ttu-id="b84e3-113">要求を行う場合は、次の表に示されているヘッダーが必要です。</span><span class="sxs-lookup"><span data-stu-id="b84e3-113">When making a request, the headers shown in the following table are required.</span></span>
 
| <span data-ttu-id="b84e3-114">Header</span><span class="sxs-lookup"><span data-stu-id="b84e3-114">Header</span></span>| <span data-ttu-id="b84e3-115">Value</span><span class="sxs-lookup"><span data-stu-id="b84e3-115">Value</span></span>| <span data-ttu-id="b84e3-116">説明</span><span class="sxs-lookup"><span data-stu-id="b84e3-116">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b84e3-117">Content-Type</span><span class="sxs-lookup"><span data-stu-id="b84e3-117">Content-Type</span></span>| <span data-ttu-id="b84e3-118">application/json</span><span class="sxs-lookup"><span data-stu-id="b84e3-118">application/json</span></span>| <span data-ttu-id="b84e3-119">送信されるデータの型。</span><span class="sxs-lookup"><span data-stu-id="b84e3-119">Type of data being submitted.</span></span>| 
| <span data-ttu-id="b84e3-120">Host</span><span class="sxs-lookup"><span data-stu-id="b84e3-120">Host</span></span>| <span data-ttu-id="b84e3-121">gameserverds.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="b84e3-121">gameserverds.xboxlive.com</span></span>|  | 
| <span data-ttu-id="b84e3-122">Content-Length</span><span class="sxs-lookup"><span data-stu-id="b84e3-122">Content-Length</span></span>|  | <span data-ttu-id="b84e3-123">要求オブジェクトの長さ。</span><span class="sxs-lookup"><span data-stu-id="b84e3-123">Length of the request object.</span></span>| 
| <span data-ttu-id="b84e3-124">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="b84e3-124">x-xbl-contract-version</span></span>| <span data-ttu-id="b84e3-125">1</span><span class="sxs-lookup"><span data-stu-id="b84e3-125">1</span></span>| <span data-ttu-id="b84e3-126">API コントラクトのバージョン。</span><span class="sxs-lookup"><span data-stu-id="b84e3-126">API contract version.</span></span>| 
  
<a id="ID4EUC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="b84e3-127">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b84e3-127">Required Response Headers</span></span>
 
<span data-ttu-id="b84e3-128">応答には、常に、次の表に示すようにヘッダーが含まれます。</span><span class="sxs-lookup"><span data-stu-id="b84e3-128">A response will always include the headers shown in the following table.</span></span>
 
| <span data-ttu-id="b84e3-129">Header</span><span class="sxs-lookup"><span data-stu-id="b84e3-129">Header</span></span>| <span data-ttu-id="b84e3-130">Value</span><span class="sxs-lookup"><span data-stu-id="b84e3-130">Value</span></span>| <span data-ttu-id="b84e3-131">説明</span><span class="sxs-lookup"><span data-stu-id="b84e3-131">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="b84e3-132">Content-Type</span><span class="sxs-lookup"><span data-stu-id="b84e3-132">Content-Type</span></span>| <span data-ttu-id="b84e3-133">application/json</span><span class="sxs-lookup"><span data-stu-id="b84e3-133">application/json</span></span>| <span data-ttu-id="b84e3-134">応答本文でデータの型。</span><span class="sxs-lookup"><span data-stu-id="b84e3-134">Type of data in the response body.</span></span>| 
| <span data-ttu-id="b84e3-135">Content-Length</span><span class="sxs-lookup"><span data-stu-id="b84e3-135">Content-Length</span></span>|  | <span data-ttu-id="b84e3-136">応答本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="b84e3-136">Length of the response body.</span></span>| 
  
<a id="ID4EVD"></a>

 
## <a name="response-body"></a><span data-ttu-id="b84e3-137">応答本文</span><span class="sxs-lookup"><span data-stu-id="b84e3-137">Response Body</span></span>
 
<span data-ttu-id="b84e3-138">呼び出しが成功した場合、サービスは、次のメンバーを持つ JSON オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="b84e3-138">If the call is successful, the service will return a JSON object with the following members.</span></span>
 
| <span data-ttu-id="b84e3-139">メンバー</span><span class="sxs-lookup"><span data-stu-id="b84e3-139">Member</span></span>| <span data-ttu-id="b84e3-140">説明</span><span class="sxs-lookup"><span data-stu-id="b84e3-140">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="b84e3-141">qosservers</span><span class="sxs-lookup"><span data-stu-id="b84e3-141">qosservers</span></span>| <span data-ttu-id="b84e3-142">サーバー情報の配列。</span><span class="sxs-lookup"><span data-stu-id="b84e3-142">An array of server information.</span></span>| 
| <span data-ttu-id="b84e3-143">serverFqdn</span><span class="sxs-lookup"><span data-stu-id="b84e3-143">serverFqdn</span></span>| <span data-ttu-id="b84e3-144">サーバーの完全修飾ドメイン名。</span><span class="sxs-lookup"><span data-stu-id="b84e3-144">The fully qualified domain name of the server.</span></span>| 
| <span data-ttu-id="b84e3-145">serverSecureDeviceAddress</span><span class="sxs-lookup"><span data-stu-id="b84e3-145">serverSecureDeviceAddress</span></span>| <span data-ttu-id="b84e3-146">サーバーのセキュリティで保護されたデバイスのアドレス。</span><span class="sxs-lookup"><span data-stu-id="b84e3-146">The secure device address of the server.</span></span>| 
| <span data-ttu-id="b84e3-147">TargetLocation</span><span class="sxs-lookup"><span data-stu-id="b84e3-147">targetLocation</span></span>| <span data-ttu-id="b84e3-148">サーバーの地理的な場所。</span><span class="sxs-lookup"><span data-stu-id="b84e3-148">The geographic location of the server.</span></span>| 
 
<a id="ID4EUE"></a>

 
### <a name="sample-response"></a><span data-ttu-id="b84e3-149">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="b84e3-149">Sample Response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="b84e3-150">関連項目</span><span class="sxs-lookup"><span data-stu-id="b84e3-150">See also</span></span>
 [<span data-ttu-id="b84e3-151">/qosservers</span><span class="sxs-lookup"><span data-stu-id="b84e3-151">/qosservers</span></span>](uri-qosservers.md)

  