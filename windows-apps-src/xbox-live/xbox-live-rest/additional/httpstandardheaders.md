---
title: 標準の HTTP 要求および応答ヘッダー
assetID: a5f8fd96-9393-5234-04ad-837e5c117c92
permalink: en-us/docs/xboxlive/rest/httpstandardheaders.html
description: " 標準の HTTP 要求および応答ヘッダー"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ca97e82365eab40266b3ffdd84924f71289eede6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57636517"
---
# <a name="standard-http-request-and-response-headers"></a><span data-ttu-id="38a91-104">標準の HTTP 要求および応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="38a91-104">Standard HTTP Request and Response Headers</span></span>
 
<a id="ID4ES"></a>

 
## <a name="request-headers"></a><span data-ttu-id="38a91-105">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="38a91-105">Request Headers</span></span>
 
<span data-ttu-id="38a91-106">次の表では、Xbox Live サービスを要求する場合に使用する標準 HTTP ヘッダーを示します。</span><span class="sxs-lookup"><span data-stu-id="38a91-106">The following table lists the standard HTTP headers used when making Xbox Live Services requests.</span></span>
 
| <span data-ttu-id="38a91-107">Header</span><span class="sxs-lookup"><span data-stu-id="38a91-107">Header</span></span>| <span data-ttu-id="38a91-108">Value</span><span class="sxs-lookup"><span data-stu-id="38a91-108">Value</span></span>| <span data-ttu-id="38a91-109">説明</span><span class="sxs-lookup"><span data-stu-id="38a91-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="38a91-110">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="38a91-110">x-xbl-contract-version</span></span>| <span data-ttu-id="38a91-111">1</span><span class="sxs-lookup"><span data-stu-id="38a91-111">1</span></span>| <span data-ttu-id="38a91-112">API コントラクトのバージョン。</span><span class="sxs-lookup"><span data-stu-id="38a91-112">API contract version.</span></span> <span data-ttu-id="38a91-113">すべての Xbox Live サービス要求に必要です。</span><span class="sxs-lookup"><span data-stu-id="38a91-113">Required on all Xbox Live Services requests.</span></span>| 
| <span data-ttu-id="38a91-114">Authorization</span><span class="sxs-lookup"><span data-stu-id="38a91-114">Authorization</span></span>| <span data-ttu-id="38a91-115">STSTokenString</span><span class="sxs-lookup"><span data-stu-id="38a91-115">STSTokenString</span></span>| <span data-ttu-id="38a91-116">STS の認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="38a91-116">STS authentication token.</span></span> <span data-ttu-id="38a91-117">このヘッダーの値を取得してから、 <b>GetTokenAndSignatureResult.Token</b>プロパティ。</span><span class="sxs-lookup"><span data-stu-id="38a91-117">The value for this header is retrieved from the <b>GetTokenAndSignatureResult.Token</b> property.</span></span> | 
| <span data-ttu-id="38a91-118">Content-Type</span><span class="sxs-lookup"><span data-stu-id="38a91-118">Content-Type</span></span>| <span data-ttu-id="38a91-119">application/xml、application/json、マルチパート/フォーム データやアプリケーション/x-www-form-urlencoded</span><span class="sxs-lookup"><span data-stu-id="38a91-119">application/xml, application/json, multipart/form-data or application/x-www-form-urlencoded</span></span>| <span data-ttu-id="38a91-120">要求と共に送信されるコンテンツの種類を指定します。</span><span class="sxs-lookup"><span data-stu-id="38a91-120">Specifies the type of content being submitted with a request.</span></span>| 
| <span data-ttu-id="38a91-121">Content-Length</span><span class="sxs-lookup"><span data-stu-id="38a91-121">Content-Length</span></span>| <span data-ttu-id="38a91-122">整数値</span><span class="sxs-lookup"><span data-stu-id="38a91-122">Integer value</span></span>| <span data-ttu-id="38a91-123">POST 要求で送信されるデータの長さを指定します。</span><span class="sxs-lookup"><span data-stu-id="38a91-123">Specifies the length of the data being submitted in a POST request.</span></span>| 
| <span data-ttu-id="38a91-124">Accept Language</span><span class="sxs-lookup"><span data-stu-id="38a91-124">Accept-Language</span></span> | <span data-ttu-id="38a91-125">String</span><span class="sxs-lookup"><span data-stu-id="38a91-125">String</span></span>| <span data-ttu-id="38a91-126">返される任意の文字列をローカライズする方法を指定します。</span><span class="sxs-lookup"><span data-stu-id="38a91-126">Specifies how to localize any strings returned.</span></span> <span data-ttu-id="38a91-127">参照してください<a href="https://msdn.microsoft.com/en-us/library/bb975829.aspx">Xbox 360 のプログラミングの高度な</a>言語/ロケールの有効な組み合わせの一覧についてはします。</span><span class="sxs-lookup"><span data-stu-id="38a91-127">See <a href="https://msdn.microsoft.com/en-us/library/bb975829.aspx">Advanced Xbox 360 Programming</a> for a list of valid language/locale combinations.</span></span>| 
  
<a id="ID4E6C"></a>

 
## <a name="response-headers"></a><span data-ttu-id="38a91-128">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="38a91-128">Response Headers</span></span>
 
<span data-ttu-id="38a91-129">次の表では、Xbox Live サービスの応答で使用される標準の HTTP ヘッダーを示します。</span><span class="sxs-lookup"><span data-stu-id="38a91-129">The following table lists the standard HTTP header used in Xbox Live Services responses.</span></span>
 
| <span data-ttu-id="38a91-130">Header</span><span class="sxs-lookup"><span data-stu-id="38a91-130">Header</span></span>| <span data-ttu-id="38a91-131">Value</span><span class="sxs-lookup"><span data-stu-id="38a91-131">Value</span></span>| <span data-ttu-id="38a91-132">説明</span><span class="sxs-lookup"><span data-stu-id="38a91-132">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="38a91-133">Content-Type</span><span class="sxs-lookup"><span data-stu-id="38a91-133">Content-Type</span></span>| <span data-ttu-id="38a91-134">application/xml, application/json</span><span class="sxs-lookup"><span data-stu-id="38a91-134">application/xml, application/json</span></span>| <span data-ttu-id="38a91-135">返されるコンテンツの種類を指定します。</span><span class="sxs-lookup"><span data-stu-id="38a91-135">Specifies the type of content being returned.</span></span>| 
| <span data-ttu-id="38a91-136">Content-Length</span><span class="sxs-lookup"><span data-stu-id="38a91-136">Content-Length</span></span>| <span data-ttu-id="38a91-137">整数値</span><span class="sxs-lookup"><span data-stu-id="38a91-137">Integer value</span></span>| <span data-ttu-id="38a91-138">返されるデータの長さを指定します。</span><span class="sxs-lookup"><span data-stu-id="38a91-138">Specifies the length of the data being returned.</span></span>| 
  
<a id="ID4EEE"></a>

 
## <a name="see-also"></a><span data-ttu-id="38a91-139">関連項目</span><span class="sxs-lookup"><span data-stu-id="38a91-139">See also</span></span>
 
<a id="ID4EGE"></a>

 
##### <a name="parent"></a><span data-ttu-id="38a91-140">Parent</span><span class="sxs-lookup"><span data-stu-id="38a91-140">Parent</span></span>  

[<span data-ttu-id="38a91-141">その他の参照</span><span class="sxs-lookup"><span data-stu-id="38a91-141">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

   