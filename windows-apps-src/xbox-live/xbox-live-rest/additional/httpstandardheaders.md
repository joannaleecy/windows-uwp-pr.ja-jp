---
title: 標準の HTTP 要求および応答ヘッダー
assetID: a5f8fd96-9393-5234-04ad-837e5c117c92
permalink: en-us/docs/xboxlive/rest/httpstandardheaders.html
author: KevinAsgari
description: " 標準の HTTP 要求および応答ヘッダー"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 31499f8d6fa41d888afd84bea64f7f9de0585b96
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4537883"
---
# <a name="standard-http-request-and-response-headers"></a><span data-ttu-id="25364-104">標準の HTTP 要求および応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="25364-104">Standard HTTP Request and Response Headers</span></span>
 
<a id="ID4ES"></a>

 
## <a name="request-headers"></a><span data-ttu-id="25364-105">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="25364-105">Request Headers</span></span>
 
<span data-ttu-id="25364-106">次の表は、Xbox Live サービス要求を作成するときに使用する標準的な HTTP ヘッダーを示します。</span><span class="sxs-lookup"><span data-stu-id="25364-106">The following table lists the standard HTTP headers used when making Xbox Live Services requests.</span></span>
 
| <span data-ttu-id="25364-107">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="25364-107">Header</span></span>| <span data-ttu-id="25364-108">設定値</span><span class="sxs-lookup"><span data-stu-id="25364-108">Value</span></span>| <span data-ttu-id="25364-109">説明</span><span class="sxs-lookup"><span data-stu-id="25364-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="25364-110">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="25364-110">x-xbl-contract-version</span></span>| <span data-ttu-id="25364-111">1</span><span class="sxs-lookup"><span data-stu-id="25364-111">1</span></span>| <span data-ttu-id="25364-112">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="25364-112">API contract version.</span></span> <span data-ttu-id="25364-113">Xbox Live サービスのすべての要求に必要です。</span><span class="sxs-lookup"><span data-stu-id="25364-113">Required on all Xbox Live Services requests.</span></span>| 
| <span data-ttu-id="25364-114">Authorization</span><span class="sxs-lookup"><span data-stu-id="25364-114">Authorization</span></span>| <span data-ttu-id="25364-115">STSTokenString</span><span class="sxs-lookup"><span data-stu-id="25364-115">STSTokenString</span></span>| <span data-ttu-id="25364-116">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="25364-116">STS authentication token.</span></span> <span data-ttu-id="25364-117">このヘッダーの値は、 <b>GetTokenAndSignatureResult.Token</b>プロパティから取得されます。</span><span class="sxs-lookup"><span data-stu-id="25364-117">The value for this header is retrieved from the <b>GetTokenAndSignatureResult.Token</b> property.</span></span> | 
| <span data-ttu-id="25364-118">Content-Type</span><span class="sxs-lookup"><span data-stu-id="25364-118">Content-Type</span></span>| <span data-ttu-id="25364-119">アプリケーション/xml、アプリケーション/json、マルチパート/フォーム データまたはアプリケーション/x-www-form-urlencoded</span><span class="sxs-lookup"><span data-stu-id="25364-119">application/xml, application/json, multipart/form-data or application/x-www-form-urlencoded</span></span>| <span data-ttu-id="25364-120">要求で送信されているコンテンツの種類を指定します。</span><span class="sxs-lookup"><span data-stu-id="25364-120">Specifies the type of content being submitted with a request.</span></span>| 
| <span data-ttu-id="25364-121">Content-Length</span><span class="sxs-lookup"><span data-stu-id="25364-121">Content-Length</span></span>| <span data-ttu-id="25364-122">整数値</span><span class="sxs-lookup"><span data-stu-id="25364-122">Integer value</span></span>| <span data-ttu-id="25364-123">POST 要求で送信されたデータの長さを指定します。</span><span class="sxs-lookup"><span data-stu-id="25364-123">Specifies the length of the data being submitted in a POST request.</span></span>| 
| <span data-ttu-id="25364-124">受け入れる言語</span><span class="sxs-lookup"><span data-stu-id="25364-124">Accept-Language</span></span> | <span data-ttu-id="25364-125">String</span><span class="sxs-lookup"><span data-stu-id="25364-125">String</span></span>| <span data-ttu-id="25364-126">返される任意の文字列をローカライズする方法を指定します。</span><span class="sxs-lookup"><span data-stu-id="25364-126">Specifies how to localize any strings returned.</span></span> <span data-ttu-id="25364-127">有効な言語/ロケールの組み合わせの一覧については、 <a href="http://msdn.microsoft.com/en-us/library/bb975829.aspx">Xbox 360 プログラミングの詳細</a>を参照してください。</span><span class="sxs-lookup"><span data-stu-id="25364-127">See <a href="http://msdn.microsoft.com/en-us/library/bb975829.aspx">Advanced Xbox 360 Programming</a> for a list of valid language/locale combinations.</span></span>| 
  
<a id="ID4E6C"></a>

 
## <a name="response-headers"></a><span data-ttu-id="25364-128">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="25364-128">Response Headers</span></span>
 
<span data-ttu-id="25364-129">次の表は、Xbox Live サービスの応答で使用される標準の HTTP ヘッダーを示します。</span><span class="sxs-lookup"><span data-stu-id="25364-129">The following table lists the standard HTTP header used in Xbox Live Services responses.</span></span>
 
| <span data-ttu-id="25364-130">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="25364-130">Header</span></span>| <span data-ttu-id="25364-131">設定値</span><span class="sxs-lookup"><span data-stu-id="25364-131">Value</span></span>| <span data-ttu-id="25364-132">説明</span><span class="sxs-lookup"><span data-stu-id="25364-132">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="25364-133">Content-Type</span><span class="sxs-lookup"><span data-stu-id="25364-133">Content-Type</span></span>| <span data-ttu-id="25364-134">アプリケーション/xml、アプリケーション/json</span><span class="sxs-lookup"><span data-stu-id="25364-134">application/xml, application/json</span></span>| <span data-ttu-id="25364-135">返されるコンテンツの種類を指定します。</span><span class="sxs-lookup"><span data-stu-id="25364-135">Specifies the type of content being returned.</span></span>| 
| <span data-ttu-id="25364-136">Content-Length</span><span class="sxs-lookup"><span data-stu-id="25364-136">Content-Length</span></span>| <span data-ttu-id="25364-137">整数値</span><span class="sxs-lookup"><span data-stu-id="25364-137">Integer value</span></span>| <span data-ttu-id="25364-138">返されるデータの長さを指定します。</span><span class="sxs-lookup"><span data-stu-id="25364-138">Specifies the length of the data being returned.</span></span>| 
  
<a id="ID4EEE"></a>

 
## <a name="see-also"></a><span data-ttu-id="25364-139">関連項目</span><span class="sxs-lookup"><span data-stu-id="25364-139">See also</span></span>
 
<a id="ID4EGE"></a>

 
##### <a name="parent"></a><span data-ttu-id="25364-140">Parent</span><span class="sxs-lookup"><span data-stu-id="25364-140">Parent</span></span>  

[<span data-ttu-id="25364-141">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="25364-141">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

   