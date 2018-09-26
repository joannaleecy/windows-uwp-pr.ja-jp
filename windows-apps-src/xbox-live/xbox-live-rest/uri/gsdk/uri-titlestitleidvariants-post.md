---
title: POST (/titles/{titleId}/variants)
assetID: 84303448-5a11-d96f-907d-77f57f859741
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidvariants-post.html
author: KevinAsgari
description: " POST (/titles/{titleId}/variants)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 246427b772403ca07adac2a4b1b07ec159142049
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4179922"
---
# <a name="post-titlestitleidvariants"></a><span data-ttu-id="81ceb-104">POST (/titles/{titleId}/variants)</span><span class="sxs-lookup"><span data-stu-id="81ceb-104">POST (/titles/{titleId}/variants)</span></span>
<span data-ttu-id="81ceb-105">指定されたタイトル id。 用のバリアントをゲームの一覧を取得するクライアントによって呼び出される URIこれらの Uri のドメインは、`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="81ceb-105">URI called by a client that retrieves a list of game variants for the specified title Id. The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="81ceb-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="81ceb-106">URI Parameters</span></span>](#ID4EZ)
  * [<span data-ttu-id="81ceb-107">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="81ceb-107">Required Request Headers</span></span>](#ID4EIB)
  * [<span data-ttu-id="81ceb-108">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="81ceb-108">Optional Request Headers</span></span>](#ID4EED)
  * [<span data-ttu-id="81ceb-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="81ceb-109">Authorization</span></span>](#ID4E3D)
  * [<span data-ttu-id="81ceb-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="81ceb-110">Request Body</span></span>](#ID4EEE)
  * [<span data-ttu-id="81ceb-111">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="81ceb-111">Required Response Headers</span></span>](#ID4ELF)
  * [<span data-ttu-id="81ceb-112">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="81ceb-112">Optional Response Headers</span></span>](#ID4EMG)
  * [<span data-ttu-id="81ceb-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="81ceb-113">Response Body</span></span>](#ID4EEH)
 
<a id="ID4EZ"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="81ceb-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="81ceb-114">URI Parameters</span></span>
 
| <span data-ttu-id="81ceb-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="81ceb-115">Parameter</span></span>| <span data-ttu-id="81ceb-116">説明</span><span class="sxs-lookup"><span data-stu-id="81ceb-116">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="81ceb-117">タイトル id</span><span class="sxs-lookup"><span data-stu-id="81ceb-117">titleid</span></span>| <span data-ttu-id="81ceb-118">要求の操作のタイトルの ID です。</span><span class="sxs-lookup"><span data-stu-id="81ceb-118">ID of the title that the request should operate on.</span></span>| 
  
<a id="ID5EG"></a>

 
## <a name="host-name"></a><span data-ttu-id="81ceb-119">ホスト名</span><span class="sxs-lookup"><span data-stu-id="81ceb-119">Host Name</span></span>

<span data-ttu-id="81ceb-120">gameserverds.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="81ceb-120">gameserverds.xboxlive.com</span></span>
 
<a id="ID4EIB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="81ceb-121">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="81ceb-121">Required Request Headers</span></span>
 
<span data-ttu-id="81ceb-122">要求を行う場合、次の表に示すようにヘッダーは必要です。</span><span class="sxs-lookup"><span data-stu-id="81ceb-122">When making a request, the headers shown in the following table are required.</span></span>
 
| <span data-ttu-id="81ceb-123">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="81ceb-123">Header</span></span>| <span data-ttu-id="81ceb-124">設定値</span><span class="sxs-lookup"><span data-stu-id="81ceb-124">Value</span></span>| <span data-ttu-id="81ceb-125">説明</span><span class="sxs-lookup"><span data-stu-id="81ceb-125">Description</span></span>| 
| --- | --- | --- | --- | --- | 
| <span data-ttu-id="81ceb-126">Content-Type</span><span class="sxs-lookup"><span data-stu-id="81ceb-126">Content-Type</span></span>| <span data-ttu-id="81ceb-127">application/json</span><span class="sxs-lookup"><span data-stu-id="81ceb-127">application/json</span></span>| <span data-ttu-id="81ceb-128">送信されたデータの種類です。</span><span class="sxs-lookup"><span data-stu-id="81ceb-128">Type of data being submitted.</span></span>| 
| <span data-ttu-id="81ceb-129">Host</span><span class="sxs-lookup"><span data-stu-id="81ceb-129">Host</span></span>| <span data-ttu-id="81ceb-130">gameserverds.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="81ceb-130">gameserverds.xboxlive.com</span></span>|  | 
| <span data-ttu-id="81ceb-131">Content-Length</span><span class="sxs-lookup"><span data-stu-id="81ceb-131">Content-Length</span></span>|  | <span data-ttu-id="81ceb-132">要求オブジェクトの長さ。</span><span class="sxs-lookup"><span data-stu-id="81ceb-132">Length of the request object.</span></span>| 
| <span data-ttu-id="81ceb-133">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="81ceb-133">x-xbl-contract-version</span></span>| <span data-ttu-id="81ceb-134">1</span><span class="sxs-lookup"><span data-stu-id="81ceb-134">1</span></span>| <span data-ttu-id="81ceb-135">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="81ceb-135">API contract version.</span></span>| 
| <span data-ttu-id="81ceb-136">Authorization</span><span class="sxs-lookup"><span data-stu-id="81ceb-136">Authorization</span></span>| <span data-ttu-id="81ceb-137">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="81ceb-137">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="81ceb-138">認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="81ceb-138">Authentication token.</span></span>| 
  
<a id="ID4EED"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="81ceb-139">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="81ceb-139">Optional Request Headers</span></span>
 
<span data-ttu-id="81ceb-140">要求を行う場合は、次の表に示すようにヘッダーはオプションです。</span><span class="sxs-lookup"><span data-stu-id="81ceb-140">When making a request, the headers shown in the following table are optional.</span></span>
 
| <span data-ttu-id="81ceb-141">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="81ceb-141">Header</span></span>| <span data-ttu-id="81ceb-142">設定値</span><span class="sxs-lookup"><span data-stu-id="81ceb-142">Value</span></span>| <span data-ttu-id="81ceb-143">説明</span><span class="sxs-lookup"><span data-stu-id="81ceb-143">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="81ceb-144">X XblCorrelationId</span><span class="sxs-lookup"><span data-stu-id="81ceb-144">X-XblCorrelationId</span></span>|  | <span data-ttu-id="81ceb-145">要求の本文の mime タイプ。</span><span class="sxs-lookup"><span data-stu-id="81ceb-145">The mime type of the body of the request.</span></span>| 
  
<a id="ID4E3D"></a>

 
## <a name="authorization"></a><span data-ttu-id="81ceb-146">Authorization</span><span class="sxs-lookup"><span data-stu-id="81ceb-146">Authorization</span></span>

<span data-ttu-id="81ceb-147">要求は、Xbox Live の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="81ceb-147">The request must include a valid Xbox Live authorization header.</span></span> <span data-ttu-id="81ceb-148">呼び出し元がこのリソースへのアクセスを許可しない場合、サービスは応答に 403 Forbidden を返します。</span><span class="sxs-lookup"><span data-stu-id="81ceb-148">If the caller is not allowed to access this resource, the service returns 403 Forbidden in response.</span></span> <span data-ttu-id="81ceb-149">ヘッダーが見つからないか無効な場合は、サービスは応答で 401 Unauthorized を返します。</span><span class="sxs-lookup"><span data-stu-id="81ceb-149">If the header is invalid or missing, the service returns 401 Unauthorized in response.</span></span>
 
<a id="ID4EEE"></a>

 
## <a name="request-body"></a><span data-ttu-id="81ceb-150">要求本文</span><span class="sxs-lookup"><span data-stu-id="81ceb-150">Request Body</span></span>
 
<span data-ttu-id="81ceb-151">要求は、次のメンバーを含む JSON オブジェクトを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="81ceb-151">The request must contain a JSON object with the following members.</span></span>
 
| <span data-ttu-id="81ceb-152">メンバー</span><span class="sxs-lookup"><span data-stu-id="81ceb-152">Member</span></span>| <span data-ttu-id="81ceb-153">説明</span><span class="sxs-lookup"><span data-stu-id="81ceb-153">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="81ceb-154">locale</span><span class="sxs-lookup"><span data-stu-id="81ceb-154">locale</span></span>| <span data-ttu-id="81ceb-155">返されるバリエーションのローカルです。</span><span class="sxs-lookup"><span data-stu-id="81ceb-155">The local of variants to return.</span></span>| 
| <span data-ttu-id="81ceb-156">maxVariants</span><span class="sxs-lookup"><span data-stu-id="81ceb-156">maxVariants</span></span>| <span data-ttu-id="81ceb-157">返されるバリアントの最大数。</span><span class="sxs-lookup"><span data-stu-id="81ceb-157">The maximum number of variants to return.</span></span>| 
| <span data-ttu-id="81ceb-158">publisherOnly</span><span class="sxs-lookup"><span data-stu-id="81ceb-158">publisherOnly</span></span>|  | 
| <span data-ttu-id="81ceb-159">制限</span><span class="sxs-lookup"><span data-stu-id="81ceb-159">restriction</span></span>|  | 
 
<a id="ID4EDF"></a>

 
### <a name="sample-request"></a><span data-ttu-id="81ceb-160">要求の例</span><span class="sxs-lookup"><span data-stu-id="81ceb-160">Sample Request</span></span>
 

```cpp
{
  "locale": "en-us",
  "maxVariants": "100",
  "publisherOnly": "false",
  "restriction": null
}

```

   
<a id="ID4ELF"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="81ceb-161">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="81ceb-161">Required Response Headers</span></span>
 
<span data-ttu-id="81ceb-162">応答は常に、次の表に示すようにヘッダーを含めます。</span><span class="sxs-lookup"><span data-stu-id="81ceb-162">A response will always include the headers shown in the following table.</span></span>
 
| <span data-ttu-id="81ceb-163">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="81ceb-163">Header</span></span>| <span data-ttu-id="81ceb-164">設定値</span><span class="sxs-lookup"><span data-stu-id="81ceb-164">Value</span></span>| <span data-ttu-id="81ceb-165">説明</span><span class="sxs-lookup"><span data-stu-id="81ceb-165">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="81ceb-166">Content-Type</span><span class="sxs-lookup"><span data-stu-id="81ceb-166">Content-Type</span></span>| <span data-ttu-id="81ceb-167">application/json</span><span class="sxs-lookup"><span data-stu-id="81ceb-167">application/json</span></span>| <span data-ttu-id="81ceb-168">応答本文内のデータの種類です。</span><span class="sxs-lookup"><span data-stu-id="81ceb-168">Type of data in the response body.</span></span>| 
| <span data-ttu-id="81ceb-169">Content-Length</span><span class="sxs-lookup"><span data-stu-id="81ceb-169">Content-Length</span></span>|  | <span data-ttu-id="81ceb-170">応答本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="81ceb-170">Length of the response body.</span></span>| 
  
<a id="ID4EMG"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="81ceb-171">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="81ceb-171">Optional Response Headers</span></span>
 
<span data-ttu-id="81ceb-172">応答には、次に示すようにヘッダー各自が可能性があります。</span><span class="sxs-lookup"><span data-stu-id="81ceb-172">A response may inlcude the headers shown in the following.</span></span>
 
| <span data-ttu-id="81ceb-173">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="81ceb-173">Header</span></span>| <span data-ttu-id="81ceb-174">設定値</span><span class="sxs-lookup"><span data-stu-id="81ceb-174">Value</span></span>| <span data-ttu-id="81ceb-175">説明</span><span class="sxs-lookup"><span data-stu-id="81ceb-175">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="81ceb-176">X XblCorrelationId</span><span class="sxs-lookup"><span data-stu-id="81ceb-176">X-XblCorrelationId</span></span>|  | <span data-ttu-id="81ceb-177">応答本文の mime タイプ。</span><span class="sxs-lookup"><span data-stu-id="81ceb-177">The mime type of the response body.</span></span>| 
  
<a id="ID4EEH"></a>

 
## <a name="response-body"></a><span data-ttu-id="81ceb-178">応答本文</span><span class="sxs-lookup"><span data-stu-id="81ceb-178">Response Body</span></span>
 
<span data-ttu-id="81ceb-179">呼び出しが成功した場合は、サービスは、次のメンバーを含む JSON オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="81ceb-179">If the call is successful, the service will return a JSON object with the following members.</span></span>
 
| <span data-ttu-id="81ceb-180">メンバー</span><span class="sxs-lookup"><span data-stu-id="81ceb-180">Member</span></span>| <span data-ttu-id="81ceb-181">説明</span><span class="sxs-lookup"><span data-stu-id="81ceb-181">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="81ceb-182">バリエーション</span><span class="sxs-lookup"><span data-stu-id="81ceb-182">variants</span></span>| <span data-ttu-id="81ceb-183">バリアントの配列です。</span><span class="sxs-lookup"><span data-stu-id="81ceb-183">An array of variants.</span></span>| 
| <span data-ttu-id="81ceb-184">バリエーション</span><span class="sxs-lookup"><span data-stu-id="81ceb-184">variantId</span></span>| <span data-ttu-id="81ceb-185">バリアントの Id です。</span><span class="sxs-lookup"><span data-stu-id="81ceb-185">The Id of a variant.</span></span>| 
| <span data-ttu-id="81ceb-186">name</span><span class="sxs-lookup"><span data-stu-id="81ceb-186">name</span></span>| <span data-ttu-id="81ceb-187">バリアントの名前です。</span><span class="sxs-lookup"><span data-stu-id="81ceb-187">The name of a variant.</span></span>| 
| <span data-ttu-id="81ceb-188">isPublisher</span><span class="sxs-lookup"><span data-stu-id="81ceb-188">isPublisher</span></span>|  | 
| <span data-ttu-id="81ceb-189">ランク</span><span class="sxs-lookup"><span data-stu-id="81ceb-189">rank</span></span>|  | 
| <span data-ttu-id="81ceb-190">gameVariantSchemaId</span><span class="sxs-lookup"><span data-stu-id="81ceb-190">gameVariantSchemaId</span></span>|  | 
| <span data-ttu-id="81ceb-191">variantSchemas</span><span class="sxs-lookup"><span data-stu-id="81ceb-191">variantSchemas</span></span>| <span data-ttu-id="81ceb-192">バリアントのスキーマの配列です。</span><span class="sxs-lookup"><span data-stu-id="81ceb-192">An array of variant schemas.</span></span>| 
| <span data-ttu-id="81ceb-193">variantSchemaId</span><span class="sxs-lookup"><span data-stu-id="81ceb-193">variantSchemaId</span></span>| <span data-ttu-id="81ceb-194">スキーマの Id です。</span><span class="sxs-lookup"><span data-stu-id="81ceb-194">The Id of the schema.</span></span>| 
| <span data-ttu-id="81ceb-195">schemaContent</span><span class="sxs-lookup"><span data-stu-id="81ceb-195">schemaContent</span></span>| <span data-ttu-id="81ceb-196">スキーマの内容</span><span class="sxs-lookup"><span data-stu-id="81ceb-196">The schema contents</span></span>| 
| <span data-ttu-id="81ceb-197">name</span><span class="sxs-lookup"><span data-stu-id="81ceb-197">name</span></span>| <span data-ttu-id="81ceb-198">スキーマの名前</span><span class="sxs-lookup"><span data-stu-id="81ceb-198">Name of the schema</span></span>| 
| <span data-ttu-id="81ceb-199">gsiSets</span><span class="sxs-lookup"><span data-stu-id="81ceb-199">gsiSets</span></span>| <span data-ttu-id="81ceb-200">GSI セットの配列です。</span><span class="sxs-lookup"><span data-stu-id="81ceb-200">An array of GSI sets.</span></span>| 
| <span data-ttu-id="81ceb-201">minRequiredPlayers</span><span class="sxs-lookup"><span data-stu-id="81ceb-201">minRequiredPlayers</span></span>| <span data-ttu-id="81ceb-202">バリアントのプレイヤーの最小数。</span><span class="sxs-lookup"><span data-stu-id="81ceb-202">The minimum number of players for the variant.</span></span>| 
| <span data-ttu-id="81ceb-203">maxAllowedPlayers</span><span class="sxs-lookup"><span data-stu-id="81ceb-203">maxAllowedPlayers</span></span>| <span data-ttu-id="81ceb-204">バリアントのプレイヤーの最大数。</span><span class="sxs-lookup"><span data-stu-id="81ceb-204">The maximum number of players for the variant.</span></span>| 
| <span data-ttu-id="81ceb-205">は</span><span class="sxs-lookup"><span data-stu-id="81ceb-205">gsiSetId</span></span>| <span data-ttu-id="81ceb-206">GSI セットの Id です。</span><span class="sxs-lookup"><span data-stu-id="81ceb-206">The Id of the GSI set.</span></span>| 
| <span data-ttu-id="81ceb-207">gsiSetName</span><span class="sxs-lookup"><span data-stu-id="81ceb-207">gsiSetName</span></span>| <span data-ttu-id="81ceb-208">GSI セットの名前です。</span><span class="sxs-lookup"><span data-stu-id="81ceb-208">The name of the GSI set.</span></span>| 
| <span data-ttu-id="81ceb-209">selectionOrder</span><span class="sxs-lookup"><span data-stu-id="81ceb-209">selectionOrder</span></span>|  | 
| <span data-ttu-id="81ceb-210">variantSchemaId</span><span class="sxs-lookup"><span data-stu-id="81ceb-210">variantSchemaId</span></span>| <span data-ttu-id="81ceb-211">GSI で使われる varaint スキーマの id を設定します。</span><span class="sxs-lookup"><span data-stu-id="81ceb-211">Id of the varaint schema used in the GSI set.</span></span>| 
 
<a id="ID4EYBAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="81ceb-212">応答の例</span><span class="sxs-lookup"><span data-stu-id="81ceb-212">Sample Response</span></span>
 

```cpp
{
 "variants": [
     { 
       "variantId": "8B6EF8A0-7807-42C4-9CB0-1D9B8B8CE742", 
       "name": "tankWarsV2.0",
       "isPublisher": "true",
       "rank": "1",
       "gameVariantSchemaId": "9742DBA5-23FD-4760-9D74-6CFA211B9CFB"
     }],
  "variantSchemas": [
     {
        "variantSchemaId": "9742DBA5-23FD-4760-9D74-6CFA211B9CFB",
        "schemaContent": "&lt;?xml version=\"1.0\" encoding=\"UTF-8\" ?>&lt;xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">&lt;xs:element name=\"root\">&lt;/xs:element>&lt;/xs:schema>"
        "name": "tanksSchema"
     }],
     "gsiSets":
     [{ 
          "minRequiredPlayers": "5", 
          "maxAllowedPlayers": "10", 
          "gsiSetId": "B28047F5-B52F-477E-97C2-4C1C39E31D42",
          "gsiSetName": "TanksGSISet",
          "selectionOrder": "1",
          "variantSchemaId": "9742DBA5-23FD-4760-9D74-6CFA211B9CFB"
     }]
 }

  

```

   
<a id="ID4ERCAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="81ceb-213">関連項目</span><span class="sxs-lookup"><span data-stu-id="81ceb-213">See also</span></span>
 [<span data-ttu-id="81ceb-214">/titles/{titleId}/variants</span><span class="sxs-lookup"><span data-stu-id="81ceb-214">/titles/{titleId}/variants</span></span>](uri-titlestitleidvariants.md)

  