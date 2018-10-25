---
title: POST (/system/strings/validate)
assetID: 6a59bc0b-8edd-87bf-efaf-f16efa3bedf7
permalink: en-us/docs/xboxlive/rest/uri-systemstringsvalidatepost.html
author: KevinAsgari
description: " POST (/system/strings/validate)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4795b1ee19017e5598655117a41617e348986503
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5474143"
---
# <a name="post-systemstringsvalidate"></a><span data-ttu-id="2186a-104">POST (/system/strings/validate)</span><span class="sxs-lookup"><span data-stu-id="2186a-104">POST (/system/strings/validate)</span></span>
<span data-ttu-id="2186a-105">検証のための文字列の配列を受け取り、同じサイズの結果の配列を返します。</span><span class="sxs-lookup"><span data-stu-id="2186a-105">Accepts an array of strings for validation and returns an array of results of equal size.</span></span> <span data-ttu-id="2186a-106">これらの Uri のドメインが`client-strings.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="2186a-106">The domain for these URIs is `client-strings.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="2186a-107">注釈</span><span class="sxs-lookup"><span data-stu-id="2186a-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="2186a-108">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2186a-108">Required Request Headers</span></span>](#ID4EIB)
  * [<span data-ttu-id="2186a-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="2186a-109">Request body</span></span>](#ID4ELC)
  * [<span data-ttu-id="2186a-110">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="2186a-110">HTTP status codes</span></span>](#ID4E4C)
  * [<span data-ttu-id="2186a-111">応答本文</span><span class="sxs-lookup"><span data-stu-id="2186a-111">Response body</span></span>](#ID4ETF)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="2186a-112">注釈</span><span class="sxs-lookup"><span data-stu-id="2186a-112">Remarks</span></span>
 
<span data-ttu-id="2186a-113">各結果は、対応する文字列が Xbox live で許容されると、該当する場合、問題のある文字列が含まれて かどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="2186a-113">Each result indicates whether the corresponding string is acceptable on Xbox LIVE, and contains the offending string if applicable.</span></span>
 
<span data-ttu-id="2186a-114">同一の文字列には、常に同一の結果が得られます。</span><span class="sxs-lookup"><span data-stu-id="2186a-114">Identical strings will always give identical results.</span></span> <span data-ttu-id="2186a-115">非成功の結果が発生した場合は、結果を分析し、適宜変更して、文字列。</span><span class="sxs-lookup"><span data-stu-id="2186a-115">If you recieve a non-successful result, analyze the result and modify the string accordingly.</span></span>
 
 

> [!NOTE] 
> <span data-ttu-id="2186a-116">結果として得られる<b>VerifyStringResult</b>のみ、文字列の最初の問題のある単語を報告します。</span><span class="sxs-lookup"><span data-stu-id="2186a-116">The resulting <b>VerifyStringResult</b> will only report the first offending word in the string.</span></span> <span data-ttu-id="2186a-117">ある可能性問題の文字列内の単語を追加します。</span><span class="sxs-lookup"><span data-stu-id="2186a-117">There might be additional offending words within the string.</span></span> <span data-ttu-id="2186a-118">文字列を使用できるようにする問題のある単語を置換する場合は、問題のある単語または部分文字列を置き換えるし、問題のあるその他の部分文字列を検索する文字列を再検証する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2186a-118">If you plan to replace the offending words to make the string usable, you should replace the offending word or substring and then re-verify the string to look for additional offending substrings.</span></span>  

 
  
<a id="ID4EIB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="2186a-119">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2186a-119">Required Request Headers</span></span>
 
| <span data-ttu-id="2186a-120">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2186a-120">Header</span></span>| <span data-ttu-id="2186a-121">説明</span><span class="sxs-lookup"><span data-stu-id="2186a-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="2186a-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="2186a-122">Authorization</span></span>| <span data-ttu-id="2186a-123">認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="2186a-123">Authentication Token.</span></span> <span data-ttu-id="2186a-124">例: XBL3.0 x = [ハッシュ]。[トークン]。</span><span class="sxs-lookup"><span data-stu-id="2186a-124">Example: XBL3.0 x=[hash];[token].</span></span>| 
| <span data-ttu-id="2186a-125">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="2186a-125">x-xbl-contract-version</span></span>| <span data-ttu-id="2186a-126">整数 API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="2186a-126">Integer API contract version.</span></span> <span data-ttu-id="2186a-127">この API を 1 または 2 をする必要があります。</span><span class="sxs-lookup"><span data-stu-id="2186a-127">Must be 1 or 2 for this API.</span></span>| 
  
<a id="ID4ELC"></a>

 
## <a name="request-body"></a><span data-ttu-id="2186a-128">要求本文</span><span class="sxs-lookup"><span data-stu-id="2186a-128">Request body</span></span>
 
<span data-ttu-id="2186a-129">要求本文は、配列のサイズに制限のない、文字列ごとの 512 文字の文字列の配列です。</span><span class="sxs-lookup"><span data-stu-id="2186a-129">The request body is an array of strings, with no limits on the size of the array, and 512 characters per string.</span></span>
 
<a id="ID4ETC"></a>

 
### <a name="sample-request"></a><span data-ttu-id="2186a-130">要求の例</span><span class="sxs-lookup"><span data-stu-id="2186a-130">Sample request</span></span>
 

```cpp
{
    "stringstoVerify":
    [
        "Poppycock",
        "The quick brown fox jumped over the lazy dog.",
        "Hey, want to hang out?",
        "oh noes"
    ]
}
      
```

   
<a id="ID4E4C"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="2186a-131">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="2186a-131">HTTP status codes</span></span>
 
<span data-ttu-id="2186a-132">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="2186a-132">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="2186a-133">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2186a-133">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="2186a-134">コード</span><span class="sxs-lookup"><span data-stu-id="2186a-134">Code</span></span>| <span data-ttu-id="2186a-135">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="2186a-135">Reason phrase</span></span>| <span data-ttu-id="2186a-136">説明</span><span class="sxs-lookup"><span data-stu-id="2186a-136">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2186a-137">200</span><span class="sxs-lookup"><span data-stu-id="2186a-137">200</span></span>| <span data-ttu-id="2186a-138">OK</span><span class="sxs-lookup"><span data-stu-id="2186a-138">OK</span></span>| <span data-ttu-id="2186a-139">すべての文字列が正常に処理されました。</span><span class="sxs-lookup"><span data-stu-id="2186a-139">All strings were processed successfully.</span></span> <span data-ttu-id="2186a-140">これは、必ずしもとすべての文字列が正の値の Hresult。</span><span class="sxs-lookup"><span data-stu-id="2186a-140">This does not necessarily mean all strings had positive HResults.</span></span>| 
| <span data-ttu-id="2186a-141">401</span><span class="sxs-lookup"><span data-stu-id="2186a-141">401</span></span>| <span data-ttu-id="2186a-142">権限がありません</span><span class="sxs-lookup"><span data-stu-id="2186a-142">Unauthorized</span></span>| <span data-ttu-id="2186a-143">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="2186a-143">The request requires user authentication.</span></span>| 
| <span data-ttu-id="2186a-144">403</span><span class="sxs-lookup"><span data-stu-id="2186a-144">403</span></span>| <span data-ttu-id="2186a-145">Forbidden</span><span class="sxs-lookup"><span data-stu-id="2186a-145">Forbidden</span></span>| <span data-ttu-id="2186a-146">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="2186a-146">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="2186a-147">406</span><span class="sxs-lookup"><span data-stu-id="2186a-147">406</span></span>| <span data-ttu-id="2186a-148">許容できません。</span><span class="sxs-lookup"><span data-stu-id="2186a-148">Not Acceptable</span></span>| <span data-ttu-id="2186a-149">不足している<b>コンテンツの種類: アプリケーション/json</b>ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="2186a-149">Missing <b>Content-type: application/json</b> header.</span></span>| 
| <span data-ttu-id="2186a-150">408</span><span class="sxs-lookup"><span data-stu-id="2186a-150">408</span></span>| <span data-ttu-id="2186a-151">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="2186a-151">Request Timeout</span></span>| <span data-ttu-id="2186a-152">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="2186a-152">Service could not understand malformed request.</span></span> <span data-ttu-id="2186a-153">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="2186a-153">Typically an invalid parameter.</span></span>| 
  
<a id="ID4ETF"></a>

 
## <a name="response-body"></a><span data-ttu-id="2186a-154">応答本文</span><span class="sxs-lookup"><span data-stu-id="2186a-154">Response body</span></span>
 
<span data-ttu-id="2186a-155">[VerifyStringResult (JSON)](../../json/json-verifystringresult.md)の要求配列と同じサイズの配列を返します。</span><span class="sxs-lookup"><span data-stu-id="2186a-155">Returns an array of [VerifyStringResult (JSON)](../../json/json-verifystringresult.md), of the same size as the request array.</span></span>
  
<a id="ID4EAG"></a>

 
## <a name="see-also"></a><span data-ttu-id="2186a-156">関連項目</span><span class="sxs-lookup"><span data-stu-id="2186a-156">See also</span></span>
 
<a id="ID4ECG"></a>

 
##### <a name="parent"></a><span data-ttu-id="2186a-157">Parent</span><span class="sxs-lookup"><span data-stu-id="2186a-157">Parent</span></span> 

[<span data-ttu-id="2186a-158">/system/strings/validate</span><span class="sxs-lookup"><span data-stu-id="2186a-158">/system/strings/validate</span></span>](uri-systemstringsvalidate.md)

   