---
title: GET (/qosservers)
assetID: 8b940c1b-947c-eab3-78ed-4384f57ea0bd
permalink: en-us/docs/xboxlive/rest/uri-qosservers-get.html
author: KevinAsgari
description: " GET (/qosservers)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 71a4787bf6b139d1a638ec783c0293d70a8ee239
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5169236"
---
# <a name="get-qosservers"></a><span data-ttu-id="b5179-104">GET (/qosservers)</span><span class="sxs-lookup"><span data-stu-id="b5179-104">GET (/qosservers)</span></span>
<span data-ttu-id="b5179-105">URI が利用可能な QoS サーバーの一覧を取得する Xbox Live エンジンで使用するためにクライアントによって呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="b5179-105">URI called by a client to get the list of QoS servers available for use with Xbox Live Compute.</span></span> <span data-ttu-id="b5179-106">これらの Uri のドメイン`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b5179-106">The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="b5179-107">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b5179-107">Required Request Headers</span></span>](#ID4EBB)
  * [<span data-ttu-id="b5179-108">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b5179-108">Required Response Headers</span></span>](#ID4EUC)
  * [<span data-ttu-id="b5179-109">応答本文</span><span class="sxs-lookup"><span data-stu-id="b5179-109">Response Body</span></span>](#ID4EVD)
 
<a id="ID5EG"></a>

 
## <a name="host-name"></a><span data-ttu-id="b5179-110">ホスト名</span><span class="sxs-lookup"><span data-stu-id="b5179-110">Host Name</span></span>

<span data-ttu-id="b5179-111">gameserverds.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="b5179-111">gameserverds.xboxlive.com</span></span>
 
<a id="ID4EBB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="b5179-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b5179-112">Required Request Headers</span></span>
 
<span data-ttu-id="b5179-113">要求を行う場合、次の表に示すようにヘッダーは、必要があります。</span><span class="sxs-lookup"><span data-stu-id="b5179-113">When making a request, the headers shown in the following table are required.</span></span>
 
| <span data-ttu-id="b5179-114">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b5179-114">Header</span></span>| <span data-ttu-id="b5179-115">設定値</span><span class="sxs-lookup"><span data-stu-id="b5179-115">Value</span></span>| <span data-ttu-id="b5179-116">説明</span><span class="sxs-lookup"><span data-stu-id="b5179-116">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b5179-117">Content-Type</span><span class="sxs-lookup"><span data-stu-id="b5179-117">Content-Type</span></span>| <span data-ttu-id="b5179-118">application/json</span><span class="sxs-lookup"><span data-stu-id="b5179-118">application/json</span></span>| <span data-ttu-id="b5179-119">送信されたデータの種類です。</span><span class="sxs-lookup"><span data-stu-id="b5179-119">Type of data being submitted.</span></span>| 
| <span data-ttu-id="b5179-120">Host</span><span class="sxs-lookup"><span data-stu-id="b5179-120">Host</span></span>| <span data-ttu-id="b5179-121">gameserverds.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="b5179-121">gameserverds.xboxlive.com</span></span>|  | 
| <span data-ttu-id="b5179-122">Content-Length</span><span class="sxs-lookup"><span data-stu-id="b5179-122">Content-Length</span></span>|  | <span data-ttu-id="b5179-123">要求のオブジェクトの長さ。</span><span class="sxs-lookup"><span data-stu-id="b5179-123">Length of the request object.</span></span>| 
| <span data-ttu-id="b5179-124">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="b5179-124">x-xbl-contract-version</span></span>| <span data-ttu-id="b5179-125">1</span><span class="sxs-lookup"><span data-stu-id="b5179-125">1</span></span>| <span data-ttu-id="b5179-126">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="b5179-126">API contract version.</span></span>| 
  
<a id="ID4EUC"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="b5179-127">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b5179-127">Required Response Headers</span></span>
 
<span data-ttu-id="b5179-128">応答には、常に、次の表に示すようにヘッダーが含まれます。</span><span class="sxs-lookup"><span data-stu-id="b5179-128">A response will always include the headers shown in the following table.</span></span>
 
| <span data-ttu-id="b5179-129">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b5179-129">Header</span></span>| <span data-ttu-id="b5179-130">設定値</span><span class="sxs-lookup"><span data-stu-id="b5179-130">Value</span></span>| <span data-ttu-id="b5179-131">説明</span><span class="sxs-lookup"><span data-stu-id="b5179-131">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="b5179-132">Content-Type</span><span class="sxs-lookup"><span data-stu-id="b5179-132">Content-Type</span></span>| <span data-ttu-id="b5179-133">application/json</span><span class="sxs-lookup"><span data-stu-id="b5179-133">application/json</span></span>| <span data-ttu-id="b5179-134">応答本文内のデータの種類です。</span><span class="sxs-lookup"><span data-stu-id="b5179-134">Type of data in the response body.</span></span>| 
| <span data-ttu-id="b5179-135">Content-Length</span><span class="sxs-lookup"><span data-stu-id="b5179-135">Content-Length</span></span>|  | <span data-ttu-id="b5179-136">応答本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="b5179-136">Length of the response body.</span></span>| 
  
<a id="ID4EVD"></a>

 
## <a name="response-body"></a><span data-ttu-id="b5179-137">応答本文</span><span class="sxs-lookup"><span data-stu-id="b5179-137">Response Body</span></span>
 
<span data-ttu-id="b5179-138">呼び出しが成功した場合は、サービスは、次のメンバーを含む JSON オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="b5179-138">If the call is successful, the service will return a JSON object with the following members.</span></span>
 
| <span data-ttu-id="b5179-139">メンバー</span><span class="sxs-lookup"><span data-stu-id="b5179-139">Member</span></span>| <span data-ttu-id="b5179-140">説明</span><span class="sxs-lookup"><span data-stu-id="b5179-140">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="b5179-141">qosservers</span><span class="sxs-lookup"><span data-stu-id="b5179-141">qosservers</span></span>| <span data-ttu-id="b5179-142">サーバー情報の配列です。</span><span class="sxs-lookup"><span data-stu-id="b5179-142">An array of server information.</span></span>| 
| <span data-ttu-id="b5179-143">serverFqdn</span><span class="sxs-lookup"><span data-stu-id="b5179-143">serverFqdn</span></span>| <span data-ttu-id="b5179-144">サーバーの完全修飾ドメイン名。</span><span class="sxs-lookup"><span data-stu-id="b5179-144">The fully qualified domain name of the server.</span></span>| 
| <span data-ttu-id="b5179-145">serverSecureDeviceAddress</span><span class="sxs-lookup"><span data-stu-id="b5179-145">serverSecureDeviceAddress</span></span>| <span data-ttu-id="b5179-146">サーバーのセキュア デバイス アドレス。</span><span class="sxs-lookup"><span data-stu-id="b5179-146">The secure device address of the server.</span></span>| 
| <span data-ttu-id="b5179-147">targetLocation</span><span class="sxs-lookup"><span data-stu-id="b5179-147">targetLocation</span></span>| <span data-ttu-id="b5179-148">サーバーの地理的な場所です。</span><span class="sxs-lookup"><span data-stu-id="b5179-148">The geographic location of the server.</span></span>| 
 
<a id="ID4EUE"></a>

 
### <a name="sample-response"></a><span data-ttu-id="b5179-149">応答の例</span><span class="sxs-lookup"><span data-stu-id="b5179-149">Sample Response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="b5179-150">関連項目</span><span class="sxs-lookup"><span data-stu-id="b5179-150">See also</span></span>
 [<span data-ttu-id="b5179-151">/qosservers</span><span class="sxs-lookup"><span data-stu-id="b5179-151">/qosservers</span></span>](uri-qosservers.md)

  