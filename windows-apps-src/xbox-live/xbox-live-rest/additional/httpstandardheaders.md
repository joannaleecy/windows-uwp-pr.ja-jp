---
title: 標準の HTTP 要求および応答ヘッダー
assetID: a5f8fd96-9393-5234-04ad-837e5c117c92
permalink: en-us/docs/xboxlive/rest/httpstandardheaders.html
author: KevinAsgari
description: " 標準の HTTP 要求および応答ヘッダー"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b1d86a870e32457b903053c7a8c3b1d722c9c559
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5825761"
---
# <a name="standard-http-request-and-response-headers"></a><span data-ttu-id="3d41c-104">標準の HTTP 要求および応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3d41c-104">Standard HTTP Request and Response Headers</span></span>
 
<a id="ID4ES"></a>

 
## <a name="request-headers"></a><span data-ttu-id="3d41c-105">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3d41c-105">Request Headers</span></span>
 
<span data-ttu-id="3d41c-106">次の表では、Xbox Live サービス要求を作成するときに使用される標準の HTTP ヘッダーを示します。</span><span class="sxs-lookup"><span data-stu-id="3d41c-106">The following table lists the standard HTTP headers used when making Xbox Live Services requests.</span></span>
 
| <span data-ttu-id="3d41c-107">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3d41c-107">Header</span></span>| <span data-ttu-id="3d41c-108">設定値</span><span class="sxs-lookup"><span data-stu-id="3d41c-108">Value</span></span>| <span data-ttu-id="3d41c-109">説明</span><span class="sxs-lookup"><span data-stu-id="3d41c-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="3d41c-110">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="3d41c-110">x-xbl-contract-version</span></span>| <span data-ttu-id="3d41c-111">1</span><span class="sxs-lookup"><span data-stu-id="3d41c-111">1</span></span>| <span data-ttu-id="3d41c-112">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="3d41c-112">API contract version.</span></span> <span data-ttu-id="3d41c-113">すべての Xbox Live サービス要求に必要です。</span><span class="sxs-lookup"><span data-stu-id="3d41c-113">Required on all Xbox Live Services requests.</span></span>| 
| <span data-ttu-id="3d41c-114">Authorization</span><span class="sxs-lookup"><span data-stu-id="3d41c-114">Authorization</span></span>| <span data-ttu-id="3d41c-115">STSTokenString</span><span class="sxs-lookup"><span data-stu-id="3d41c-115">STSTokenString</span></span>| <span data-ttu-id="3d41c-116">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="3d41c-116">STS authentication token.</span></span> <span data-ttu-id="3d41c-117">このヘッダーの値は、 <b>GetTokenAndSignatureResult.Token</b>プロパティから取得されます。</span><span class="sxs-lookup"><span data-stu-id="3d41c-117">The value for this header is retrieved from the <b>GetTokenAndSignatureResult.Token</b> property.</span></span> | 
| <span data-ttu-id="3d41c-118">Content-Type</span><span class="sxs-lookup"><span data-stu-id="3d41c-118">Content-Type</span></span>| <span data-ttu-id="3d41c-119">アプリケーション/xml、アプリケーション/json、マルチパート/フォーム データまたはアプリケーション/x-。-form-urlencoded</span><span class="sxs-lookup"><span data-stu-id="3d41c-119">application/xml, application/json, multipart/form-data or application/x-www-form-urlencoded</span></span>| <span data-ttu-id="3d41c-120">要求で送信されるコンテンツの種類を指定します。</span><span class="sxs-lookup"><span data-stu-id="3d41c-120">Specifies the type of content being submitted with a request.</span></span>| 
| <span data-ttu-id="3d41c-121">Content-Length</span><span class="sxs-lookup"><span data-stu-id="3d41c-121">Content-Length</span></span>| <span data-ttu-id="3d41c-122">整数値</span><span class="sxs-lookup"><span data-stu-id="3d41c-122">Integer value</span></span>| <span data-ttu-id="3d41c-123">POST 要求で送信されたデータの長さを指定します。</span><span class="sxs-lookup"><span data-stu-id="3d41c-123">Specifies the length of the data being submitted in a POST request.</span></span>| 
| <span data-ttu-id="3d41c-124">同意言語</span><span class="sxs-lookup"><span data-stu-id="3d41c-124">Accept-Language</span></span> | <span data-ttu-id="3d41c-125">String</span><span class="sxs-lookup"><span data-stu-id="3d41c-125">String</span></span>| <span data-ttu-id="3d41c-126">返される任意の文字列をローカライズする方法を指定します。</span><span class="sxs-lookup"><span data-stu-id="3d41c-126">Specifies how to localize any strings returned.</span></span> <span data-ttu-id="3d41c-127">有効な言語/ロケールの組み合わせの一覧については、<a href="http://msdn.microsoft.com/en-us/library/bb975829.aspx">高度な Xbox 360 のプログラミング</a>を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3d41c-127">See <a href="http://msdn.microsoft.com/en-us/library/bb975829.aspx">Advanced Xbox 360 Programming</a> for a list of valid language/locale combinations.</span></span>| 
  
<a id="ID4E6C"></a>

 
## <a name="response-headers"></a><span data-ttu-id="3d41c-128">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3d41c-128">Response Headers</span></span>
 
<span data-ttu-id="3d41c-129">次の表では、Xbox Live サービスの応答で使用される標準の HTTP ヘッダーを示します。</span><span class="sxs-lookup"><span data-stu-id="3d41c-129">The following table lists the standard HTTP header used in Xbox Live Services responses.</span></span>
 
| <span data-ttu-id="3d41c-130">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3d41c-130">Header</span></span>| <span data-ttu-id="3d41c-131">設定値</span><span class="sxs-lookup"><span data-stu-id="3d41c-131">Value</span></span>| <span data-ttu-id="3d41c-132">説明</span><span class="sxs-lookup"><span data-stu-id="3d41c-132">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3d41c-133">Content-Type</span><span class="sxs-lookup"><span data-stu-id="3d41c-133">Content-Type</span></span>| <span data-ttu-id="3d41c-134">アプリケーション/xml、アプリケーション/json</span><span class="sxs-lookup"><span data-stu-id="3d41c-134">application/xml, application/json</span></span>| <span data-ttu-id="3d41c-135">返されるコンテンツの種類を指定します。</span><span class="sxs-lookup"><span data-stu-id="3d41c-135">Specifies the type of content being returned.</span></span>| 
| <span data-ttu-id="3d41c-136">Content-Length</span><span class="sxs-lookup"><span data-stu-id="3d41c-136">Content-Length</span></span>| <span data-ttu-id="3d41c-137">整数値</span><span class="sxs-lookup"><span data-stu-id="3d41c-137">Integer value</span></span>| <span data-ttu-id="3d41c-138">返されるデータの長さを指定します。</span><span class="sxs-lookup"><span data-stu-id="3d41c-138">Specifies the length of the data being returned.</span></span>| 
  
<a id="ID4EEE"></a>

 
## <a name="see-also"></a><span data-ttu-id="3d41c-139">関連項目</span><span class="sxs-lookup"><span data-stu-id="3d41c-139">See also</span></span>
 
<a id="ID4EGE"></a>

 
##### <a name="parent"></a><span data-ttu-id="3d41c-140">Parent</span><span class="sxs-lookup"><span data-stu-id="3d41c-140">Parent</span></span>  

[<span data-ttu-id="3d41c-141">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="3d41c-141">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

   