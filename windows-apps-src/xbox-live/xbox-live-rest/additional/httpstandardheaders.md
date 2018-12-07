---
title: 標準の HTTP 要求および応答ヘッダー
assetID: a5f8fd96-9393-5234-04ad-837e5c117c92
permalink: en-us/docs/xboxlive/rest/httpstandardheaders.html
description: " 標準の HTTP 要求および応答ヘッダー"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5dea70403b2a6a7c61be2761d1f5d1ff3d75ccb6
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8779411"
---
# <a name="standard-http-request-and-response-headers"></a><span data-ttu-id="2d13f-104">標準の HTTP 要求および応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2d13f-104">Standard HTTP Request and Response Headers</span></span>
 
<a id="ID4ES"></a>

 
## <a name="request-headers"></a><span data-ttu-id="2d13f-105">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2d13f-105">Request Headers</span></span>
 
<span data-ttu-id="2d13f-106">次の表では、Xbox Live サービス要求を作成するときに使用する標準的な HTTP ヘッダーを示します。</span><span class="sxs-lookup"><span data-stu-id="2d13f-106">The following table lists the standard HTTP headers used when making Xbox Live Services requests.</span></span>
 
| <span data-ttu-id="2d13f-107">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2d13f-107">Header</span></span>| <span data-ttu-id="2d13f-108">設定値</span><span class="sxs-lookup"><span data-stu-id="2d13f-108">Value</span></span>| <span data-ttu-id="2d13f-109">説明</span><span class="sxs-lookup"><span data-stu-id="2d13f-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="2d13f-110">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="2d13f-110">x-xbl-contract-version</span></span>| <span data-ttu-id="2d13f-111">1</span><span class="sxs-lookup"><span data-stu-id="2d13f-111">1</span></span>| <span data-ttu-id="2d13f-112">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="2d13f-112">API contract version.</span></span> <span data-ttu-id="2d13f-113">Xbox Live サービスのすべての要求に必要です。</span><span class="sxs-lookup"><span data-stu-id="2d13f-113">Required on all Xbox Live Services requests.</span></span>| 
| <span data-ttu-id="2d13f-114">Authorization</span><span class="sxs-lookup"><span data-stu-id="2d13f-114">Authorization</span></span>| <span data-ttu-id="2d13f-115">STSTokenString</span><span class="sxs-lookup"><span data-stu-id="2d13f-115">STSTokenString</span></span>| <span data-ttu-id="2d13f-116">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="2d13f-116">STS authentication token.</span></span> <span data-ttu-id="2d13f-117">このヘッダーの値は、 <b>GetTokenAndSignatureResult.Token</b>プロパティから取得されます。</span><span class="sxs-lookup"><span data-stu-id="2d13f-117">The value for this header is retrieved from the <b>GetTokenAndSignatureResult.Token</b> property.</span></span> | 
| <span data-ttu-id="2d13f-118">Content-Type</span><span class="sxs-lookup"><span data-stu-id="2d13f-118">Content-Type</span></span>| <span data-ttu-id="2d13f-119">アプリケーション/xml、アプリケーション/json、マルチパート/フォーム データまたはアプリケーション/x-。-form-urlencoded</span><span class="sxs-lookup"><span data-stu-id="2d13f-119">application/xml, application/json, multipart/form-data or application/x-www-form-urlencoded</span></span>| <span data-ttu-id="2d13f-120">要求で送信されるコンテンツの種類を指定します。</span><span class="sxs-lookup"><span data-stu-id="2d13f-120">Specifies the type of content being submitted with a request.</span></span>| 
| <span data-ttu-id="2d13f-121">Content-Length</span><span class="sxs-lookup"><span data-stu-id="2d13f-121">Content-Length</span></span>| <span data-ttu-id="2d13f-122">整数値</span><span class="sxs-lookup"><span data-stu-id="2d13f-122">Integer value</span></span>| <span data-ttu-id="2d13f-123">POST 要求で送信されたデータの長さを指定します。</span><span class="sxs-lookup"><span data-stu-id="2d13f-123">Specifies the length of the data being submitted in a POST request.</span></span>| 
| <span data-ttu-id="2d13f-124">同意言語</span><span class="sxs-lookup"><span data-stu-id="2d13f-124">Accept-Language</span></span> | <span data-ttu-id="2d13f-125">String</span><span class="sxs-lookup"><span data-stu-id="2d13f-125">String</span></span>| <span data-ttu-id="2d13f-126">返される任意の文字列をローカライズする方法を指定します。</span><span class="sxs-lookup"><span data-stu-id="2d13f-126">Specifies how to localize any strings returned.</span></span> <span data-ttu-id="2d13f-127">有効な言語/ロケールの組み合わせの一覧については、 <a href="http://msdn.microsoft.com/en-us/library/bb975829.aspx">Xbox 360 プログラミングの詳細</a>を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2d13f-127">See <a href="http://msdn.microsoft.com/en-us/library/bb975829.aspx">Advanced Xbox 360 Programming</a> for a list of valid language/locale combinations.</span></span>| 
  
<a id="ID4E6C"></a>

 
## <a name="response-headers"></a><span data-ttu-id="2d13f-128">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2d13f-128">Response Headers</span></span>
 
<span data-ttu-id="2d13f-129">次の表では、Xbox Live サービスの応答で使用される標準の HTTP ヘッダーを示します。</span><span class="sxs-lookup"><span data-stu-id="2d13f-129">The following table lists the standard HTTP header used in Xbox Live Services responses.</span></span>
 
| <span data-ttu-id="2d13f-130">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2d13f-130">Header</span></span>| <span data-ttu-id="2d13f-131">設定値</span><span class="sxs-lookup"><span data-stu-id="2d13f-131">Value</span></span>| <span data-ttu-id="2d13f-132">説明</span><span class="sxs-lookup"><span data-stu-id="2d13f-132">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2d13f-133">Content-Type</span><span class="sxs-lookup"><span data-stu-id="2d13f-133">Content-Type</span></span>| <span data-ttu-id="2d13f-134">アプリケーション xml/アプリケーション/json</span><span class="sxs-lookup"><span data-stu-id="2d13f-134">application/xml, application/json</span></span>| <span data-ttu-id="2d13f-135">返されるコンテンツの種類を指定します。</span><span class="sxs-lookup"><span data-stu-id="2d13f-135">Specifies the type of content being returned.</span></span>| 
| <span data-ttu-id="2d13f-136">Content-Length</span><span class="sxs-lookup"><span data-stu-id="2d13f-136">Content-Length</span></span>| <span data-ttu-id="2d13f-137">整数値</span><span class="sxs-lookup"><span data-stu-id="2d13f-137">Integer value</span></span>| <span data-ttu-id="2d13f-138">返されるデータの長さを指定します。</span><span class="sxs-lookup"><span data-stu-id="2d13f-138">Specifies the length of the data being returned.</span></span>| 
  
<a id="ID4EEE"></a>

 
## <a name="see-also"></a><span data-ttu-id="2d13f-139">関連項目</span><span class="sxs-lookup"><span data-stu-id="2d13f-139">See also</span></span>
 
<a id="ID4EGE"></a>

 
##### <a name="parent"></a><span data-ttu-id="2d13f-140">Parent</span><span class="sxs-lookup"><span data-stu-id="2d13f-140">Parent</span></span>  

[<span data-ttu-id="2d13f-141">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="2d13f-141">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

   