---
title: POST (/system/strings/validate)
assetID: 6a59bc0b-8edd-87bf-efaf-f16efa3bedf7
permalink: en-us/docs/xboxlive/rest/uri-systemstringsvalidatepost.html
description: " POST (/system/strings/validate)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 70e86567f449674c7a046e072437d9ee715dc6d6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57595507"
---
# <a name="post-systemstringsvalidate"></a><span data-ttu-id="51c6b-104">POST (/system/strings/validate)</span><span class="sxs-lookup"><span data-stu-id="51c6b-104">POST (/system/strings/validate)</span></span>
<span data-ttu-id="51c6b-105">検証のための文字列の配列を受け取り、等しいサイズの結果の配列を返します。</span><span class="sxs-lookup"><span data-stu-id="51c6b-105">Accepts an array of strings for validation and returns an array of results of equal size.</span></span> <span data-ttu-id="51c6b-106">これらの Uri のドメインが`client-strings.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="51c6b-106">The domain for these URIs is `client-strings.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="51c6b-107">注釈</span><span class="sxs-lookup"><span data-stu-id="51c6b-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="51c6b-108">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="51c6b-108">Required Request Headers</span></span>](#ID4EIB)
  * [<span data-ttu-id="51c6b-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="51c6b-109">Request body</span></span>](#ID4ELC)
  * [<span data-ttu-id="51c6b-110">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="51c6b-110">HTTP status codes</span></span>](#ID4E4C)
  * [<span data-ttu-id="51c6b-111">応答本文</span><span class="sxs-lookup"><span data-stu-id="51c6b-111">Response body</span></span>](#ID4ETF)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="51c6b-112">注釈</span><span class="sxs-lookup"><span data-stu-id="51c6b-112">Remarks</span></span>
 
<span data-ttu-id="51c6b-113">各結果は、対応する文字列が Xbox LIVE では容認でき、該当する場合は、問題のある文字列を含むかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="51c6b-113">Each result indicates whether the corresponding string is acceptable on Xbox LIVE, and contains the offending string if applicable.</span></span>
 
<span data-ttu-id="51c6b-114">同じ文字列が常に同じ結果になります。</span><span class="sxs-lookup"><span data-stu-id="51c6b-114">Identical strings will always give identical results.</span></span> <span data-ttu-id="51c6b-115">非成功の結果を受信する場合は、結果を分析し、それに応じて、文字列を変更します。</span><span class="sxs-lookup"><span data-stu-id="51c6b-115">If you receive a non-successful result, analyze the result and modify the string accordingly.</span></span>
 
 

> [!NOTE] 
> <span data-ttu-id="51c6b-116">結果の<b>VerifyStringResult</b>文字列の最初の問題のある単語をレポートのみになります。</span><span class="sxs-lookup"><span data-stu-id="51c6b-116">The resulting <b>VerifyStringResult</b> will only report the first offending word in the string.</span></span> <span data-ttu-id="51c6b-117">ある可能性があります、文字列内での問題のある追加します。</span><span class="sxs-lookup"><span data-stu-id="51c6b-117">There might be additional offending words within the string.</span></span> <span data-ttu-id="51c6b-118">文字列を使用できるようにする問題のある単語を置換する場合は、問題のある単語または部分文字列の置換、追加の問題が発生した部分文字列を検索する文字列を再検証してください。</span><span class="sxs-lookup"><span data-stu-id="51c6b-118">If you plan to replace the offending words to make the string usable, you should replace the offending word or substring and then re-verify the string to look for additional offending substrings.</span></span>  

 
  
<a id="ID4EIB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="51c6b-119">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="51c6b-119">Required Request Headers</span></span>
 
| <span data-ttu-id="51c6b-120">Header</span><span class="sxs-lookup"><span data-stu-id="51c6b-120">Header</span></span>| <span data-ttu-id="51c6b-121">説明</span><span class="sxs-lookup"><span data-stu-id="51c6b-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="51c6b-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="51c6b-122">Authorization</span></span>| <span data-ttu-id="51c6b-123">認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="51c6b-123">Authentication Token.</span></span> <span data-ttu-id="51c6b-124">以下に例を示します。XBL3.0 x = [ハッシュ] です。[トークン] です。</span><span class="sxs-lookup"><span data-stu-id="51c6b-124">Example: XBL3.0 x=[hash];[token].</span></span>| 
| <span data-ttu-id="51c6b-125">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="51c6b-125">x-xbl-contract-version</span></span>| <span data-ttu-id="51c6b-126">整数 API コントラクトのバージョン。</span><span class="sxs-lookup"><span data-stu-id="51c6b-126">Integer API contract version.</span></span> <span data-ttu-id="51c6b-127">この api は、1 または 2 を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="51c6b-127">Must be 1 or 2 for this API.</span></span>| 
  
<a id="ID4ELC"></a>

 
## <a name="request-body"></a><span data-ttu-id="51c6b-128">要求本文</span><span class="sxs-lookup"><span data-stu-id="51c6b-128">Request body</span></span>
 
<span data-ttu-id="51c6b-129">要求本文は、文字列、配列のサイズに制限はありませんし、文字列あたり 512 文字の配列です。</span><span class="sxs-lookup"><span data-stu-id="51c6b-129">The request body is an array of strings, with no limits on the size of the array, and 512 characters per string.</span></span>
 
<a id="ID4ETC"></a>

 
### <a name="sample-request"></a><span data-ttu-id="51c6b-130">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="51c6b-130">Sample request</span></span>
 

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

 
## <a name="http-status-codes"></a><span data-ttu-id="51c6b-131">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="51c6b-131">HTTP status codes</span></span>
 
<span data-ttu-id="51c6b-132">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="51c6b-132">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="51c6b-133">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="51c6b-133">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="51c6b-134">コード</span><span class="sxs-lookup"><span data-stu-id="51c6b-134">Code</span></span>| <span data-ttu-id="51c6b-135">理由語句</span><span class="sxs-lookup"><span data-stu-id="51c6b-135">Reason phrase</span></span>| <span data-ttu-id="51c6b-136">説明</span><span class="sxs-lookup"><span data-stu-id="51c6b-136">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="51c6b-137">200</span><span class="sxs-lookup"><span data-stu-id="51c6b-137">200</span></span>| <span data-ttu-id="51c6b-138">OK</span><span class="sxs-lookup"><span data-stu-id="51c6b-138">OK</span></span>| <span data-ttu-id="51c6b-139">すべての文字列が正常に処理されました。</span><span class="sxs-lookup"><span data-stu-id="51c6b-139">All strings were processed successfully.</span></span> <span data-ttu-id="51c6b-140">これは必ずしもすべての文字列には、正の値の Hresult が必要があります。</span><span class="sxs-lookup"><span data-stu-id="51c6b-140">This does not necessarily mean all strings had positive HResults.</span></span>| 
| <span data-ttu-id="51c6b-141">401</span><span class="sxs-lookup"><span data-stu-id="51c6b-141">401</span></span>| <span data-ttu-id="51c6b-142">権限がありません</span><span class="sxs-lookup"><span data-stu-id="51c6b-142">Unauthorized</span></span>| <span data-ttu-id="51c6b-143">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="51c6b-143">The request requires user authentication.</span></span>| 
| <span data-ttu-id="51c6b-144">403</span><span class="sxs-lookup"><span data-stu-id="51c6b-144">403</span></span>| <span data-ttu-id="51c6b-145">Forbidden</span><span class="sxs-lookup"><span data-stu-id="51c6b-145">Forbidden</span></span>| <span data-ttu-id="51c6b-146">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="51c6b-146">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="51c6b-147">406</span><span class="sxs-lookup"><span data-stu-id="51c6b-147">406</span></span>| <span data-ttu-id="51c6b-148">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="51c6b-148">Not Acceptable</span></span>| <span data-ttu-id="51c6b-149">不足している<b>コンテンツの種類: アプリケーション/json</b>ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="51c6b-149">Missing <b>Content-type: application/json</b> header.</span></span>| 
| <span data-ttu-id="51c6b-150">408</span><span class="sxs-lookup"><span data-stu-id="51c6b-150">408</span></span>| <span data-ttu-id="51c6b-151">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="51c6b-151">Request Timeout</span></span>| <span data-ttu-id="51c6b-152">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="51c6b-152">Service could not understand malformed request.</span></span> <span data-ttu-id="51c6b-153">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="51c6b-153">Typically an invalid parameter.</span></span>| 
  
<a id="ID4ETF"></a>

 
## <a name="response-body"></a><span data-ttu-id="51c6b-154">応答本文</span><span class="sxs-lookup"><span data-stu-id="51c6b-154">Response body</span></span>
 
<span data-ttu-id="51c6b-155">配列を返します[VerifyStringResult (JSON)](../../json/json-verifystringresult.md)要求の配列と同じサイズの。</span><span class="sxs-lookup"><span data-stu-id="51c6b-155">Returns an array of [VerifyStringResult (JSON)](../../json/json-verifystringresult.md), of the same size as the request array.</span></span>
  
<a id="ID4EAG"></a>

 
## <a name="see-also"></a><span data-ttu-id="51c6b-156">関連項目</span><span class="sxs-lookup"><span data-stu-id="51c6b-156">See also</span></span>
 
<a id="ID4ECG"></a>

 
##### <a name="parent"></a><span data-ttu-id="51c6b-157">Parent</span><span class="sxs-lookup"><span data-stu-id="51c6b-157">Parent</span></span> 

[<span data-ttu-id="51c6b-158">/system/strings/validate</span><span class="sxs-lookup"><span data-stu-id="51c6b-158">/system/strings/validate</span></span>](uri-systemstringsvalidate.md)

   