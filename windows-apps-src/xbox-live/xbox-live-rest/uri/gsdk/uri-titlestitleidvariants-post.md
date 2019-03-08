---
title: POST (/titles/{titleId}/variants)
assetID: 84303448-5a11-d96f-907d-77f57f859741
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidvariants-post.html
description: " POST (/titles/{titleId}/variants)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 17974ddf7dec26abac18ccee9fda5249bc9d656f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618497"
---
# <a name="post-titlestitleidvariants"></a><span data-ttu-id="fa7b2-104">POST (/titles/{titleId}/variants)</span><span class="sxs-lookup"><span data-stu-id="fa7b2-104">POST (/titles/{titleId}/variants)</span></span>
<span data-ttu-id="fa7b2-105">URI の id。 指定したタイトルのゲームのバリアントのリストを取得するクライアントによって呼び出されますこれらの Uri のドメインが`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-105">URI called by a client that retrieves a list of game variants for the specified title Id. The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="fa7b2-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="fa7b2-106">URI Parameters</span></span>](#ID4EZ)
  * [<span data-ttu-id="fa7b2-107">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fa7b2-107">Required Request Headers</span></span>](#ID4EIB)
  * [<span data-ttu-id="fa7b2-108">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fa7b2-108">Optional Request Headers</span></span>](#ID4EED)
  * [<span data-ttu-id="fa7b2-109">承認</span><span class="sxs-lookup"><span data-stu-id="fa7b2-109">Authorization</span></span>](#ID4E3D)
  * [<span data-ttu-id="fa7b2-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="fa7b2-110">Request Body</span></span>](#ID4EEE)
  * [<span data-ttu-id="fa7b2-111">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fa7b2-111">Required Response Headers</span></span>](#ID4ELF)
  * [<span data-ttu-id="fa7b2-112">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fa7b2-112">Optional Response Headers</span></span>](#ID4EMG)
  * [<span data-ttu-id="fa7b2-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="fa7b2-113">Response Body</span></span>](#ID4EEH)
 
<a id="ID4EZ"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="fa7b2-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="fa7b2-114">URI Parameters</span></span>
 
| <span data-ttu-id="fa7b2-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="fa7b2-115">Parameter</span></span>| <span data-ttu-id="fa7b2-116">説明</span><span class="sxs-lookup"><span data-stu-id="fa7b2-116">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="fa7b2-117">タイトル id</span><span class="sxs-lookup"><span data-stu-id="fa7b2-117">titleid</span></span>| <span data-ttu-id="fa7b2-118">要求の操作対象のタイトルの ID。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-118">ID of the title that the request should operate on.</span></span>| 
  
<a id="ID5EG"></a>

 
## <a name="host-name"></a><span data-ttu-id="fa7b2-119">ホスト名</span><span class="sxs-lookup"><span data-stu-id="fa7b2-119">Host Name</span></span>

<span data-ttu-id="fa7b2-120">gameserverds.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="fa7b2-120">gameserverds.xboxlive.com</span></span>
 
<a id="ID4EIB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="fa7b2-121">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fa7b2-121">Required Request Headers</span></span>
 
<span data-ttu-id="fa7b2-122">要求を行う場合は、次の表に示されているヘッダーが必要です。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-122">When making a request, the headers shown in the following table are required.</span></span>
 
| <span data-ttu-id="fa7b2-123">Header</span><span class="sxs-lookup"><span data-stu-id="fa7b2-123">Header</span></span>| <span data-ttu-id="fa7b2-124">Value</span><span class="sxs-lookup"><span data-stu-id="fa7b2-124">Value</span></span>| <span data-ttu-id="fa7b2-125">説明</span><span class="sxs-lookup"><span data-stu-id="fa7b2-125">Description</span></span>| 
| --- | --- | --- | --- | --- | 
| <span data-ttu-id="fa7b2-126">Content-Type</span><span class="sxs-lookup"><span data-stu-id="fa7b2-126">Content-Type</span></span>| <span data-ttu-id="fa7b2-127">application/json</span><span class="sxs-lookup"><span data-stu-id="fa7b2-127">application/json</span></span>| <span data-ttu-id="fa7b2-128">送信されるデータの型。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-128">Type of data being submitted.</span></span>| 
| <span data-ttu-id="fa7b2-129">Host</span><span class="sxs-lookup"><span data-stu-id="fa7b2-129">Host</span></span>| <span data-ttu-id="fa7b2-130">gameserverds.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="fa7b2-130">gameserverds.xboxlive.com</span></span>|  | 
| <span data-ttu-id="fa7b2-131">Content-Length</span><span class="sxs-lookup"><span data-stu-id="fa7b2-131">Content-Length</span></span>|  | <span data-ttu-id="fa7b2-132">要求オブジェクトの長さ。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-132">Length of the request object.</span></span>| 
| <span data-ttu-id="fa7b2-133">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="fa7b2-133">x-xbl-contract-version</span></span>| <span data-ttu-id="fa7b2-134">1</span><span class="sxs-lookup"><span data-stu-id="fa7b2-134">1</span></span>| <span data-ttu-id="fa7b2-135">API コントラクトのバージョン。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-135">API contract version.</span></span>| 
| <span data-ttu-id="fa7b2-136">Authorization</span><span class="sxs-lookup"><span data-stu-id="fa7b2-136">Authorization</span></span>| <span data-ttu-id="fa7b2-137">XBL3.0 x = [ハッシュ] です。[トークン]</span><span class="sxs-lookup"><span data-stu-id="fa7b2-137">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="fa7b2-138">認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-138">Authentication token.</span></span>| 
  
<a id="ID4EED"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="fa7b2-139">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fa7b2-139">Optional Request Headers</span></span>
 
<span data-ttu-id="fa7b2-140">要求を行う場合は、次の表に示されているヘッダーを省略できます。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-140">When making a request, the headers shown in the following table are optional.</span></span>
 
| <span data-ttu-id="fa7b2-141">Header</span><span class="sxs-lookup"><span data-stu-id="fa7b2-141">Header</span></span>| <span data-ttu-id="fa7b2-142">Value</span><span class="sxs-lookup"><span data-stu-id="fa7b2-142">Value</span></span>| <span data-ttu-id="fa7b2-143">説明</span><span class="sxs-lookup"><span data-stu-id="fa7b2-143">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="fa7b2-144">X-XblCorrelationId</span><span class="sxs-lookup"><span data-stu-id="fa7b2-144">X-XblCorrelationId</span></span>|  | <span data-ttu-id="fa7b2-145">要求の本文の mime の種類。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-145">The mime type of the body of the request.</span></span>| 
  
<a id="ID4E3D"></a>

 
## <a name="authorization"></a><span data-ttu-id="fa7b2-146">Authorization</span><span class="sxs-lookup"><span data-stu-id="fa7b2-146">Authorization</span></span>

<span data-ttu-id="fa7b2-147">要求には、有効な Xbox Live の authorization ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-147">The request must include a valid Xbox Live authorization header.</span></span> <span data-ttu-id="fa7b2-148">呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは応答 403 Forbidden を返します。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-148">If the caller is not allowed to access this resource, the service returns 403 Forbidden in response.</span></span> <span data-ttu-id="fa7b2-149">ヘッダーが無効であるか不足している場合、サービスは応答で 401 Unauthorized を返します。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-149">If the header is invalid or missing, the service returns 401 Unauthorized in response.</span></span>
 
<a id="ID4EEE"></a>

 
## <a name="request-body"></a><span data-ttu-id="fa7b2-150">要求本文</span><span class="sxs-lookup"><span data-stu-id="fa7b2-150">Request Body</span></span>
 
<span data-ttu-id="fa7b2-151">要求には、次のメンバーを持つ JSON オブジェクトを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-151">The request must contain a JSON object with the following members.</span></span>
 
| <span data-ttu-id="fa7b2-152">メンバー</span><span class="sxs-lookup"><span data-stu-id="fa7b2-152">Member</span></span>| <span data-ttu-id="fa7b2-153">説明</span><span class="sxs-lookup"><span data-stu-id="fa7b2-153">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="fa7b2-154">locale</span><span class="sxs-lookup"><span data-stu-id="fa7b2-154">locale</span></span>| <span data-ttu-id="fa7b2-155">返されるバリアントのローカルです。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-155">The local of variants to return.</span></span>| 
| <span data-ttu-id="fa7b2-156">maxVariants</span><span class="sxs-lookup"><span data-stu-id="fa7b2-156">maxVariants</span></span>| <span data-ttu-id="fa7b2-157">返されるバリアントの最大数。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-157">The maximum number of variants to return.</span></span>| 
| <span data-ttu-id="fa7b2-158">publisherOnly</span><span class="sxs-lookup"><span data-stu-id="fa7b2-158">publisherOnly</span></span>|  | 
| <span data-ttu-id="fa7b2-159">制限</span><span class="sxs-lookup"><span data-stu-id="fa7b2-159">restriction</span></span>|  | 
 
<a id="ID4EDF"></a>

 
### <a name="sample-request"></a><span data-ttu-id="fa7b2-160">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="fa7b2-160">Sample Request</span></span>
 

```cpp
{
  "locale": "en-us",
  "maxVariants": "100",
  "publisherOnly": "false",
  "restriction": null
}

```

   
<a id="ID4ELF"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="fa7b2-161">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fa7b2-161">Required Response Headers</span></span>
 
<span data-ttu-id="fa7b2-162">応答には、常に、次の表に示すようにヘッダーが含まれます。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-162">A response will always include the headers shown in the following table.</span></span>
 
| <span data-ttu-id="fa7b2-163">Header</span><span class="sxs-lookup"><span data-stu-id="fa7b2-163">Header</span></span>| <span data-ttu-id="fa7b2-164">Value</span><span class="sxs-lookup"><span data-stu-id="fa7b2-164">Value</span></span>| <span data-ttu-id="fa7b2-165">説明</span><span class="sxs-lookup"><span data-stu-id="fa7b2-165">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="fa7b2-166">Content-Type</span><span class="sxs-lookup"><span data-stu-id="fa7b2-166">Content-Type</span></span>| <span data-ttu-id="fa7b2-167">application/json</span><span class="sxs-lookup"><span data-stu-id="fa7b2-167">application/json</span></span>| <span data-ttu-id="fa7b2-168">応答本文でデータの型。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-168">Type of data in the response body.</span></span>| 
| <span data-ttu-id="fa7b2-169">Content-Length</span><span class="sxs-lookup"><span data-stu-id="fa7b2-169">Content-Length</span></span>|  | <span data-ttu-id="fa7b2-170">応答本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-170">Length of the response body.</span></span>| 
  
<a id="ID4EMG"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="fa7b2-171">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fa7b2-171">Optional Response Headers</span></span>
 
<span data-ttu-id="fa7b2-172">応答には、各自では、次に示すようにヘッダーが可能性があります。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-172">A response may inlcude the headers shown in the following.</span></span>
 
| <span data-ttu-id="fa7b2-173">Header</span><span class="sxs-lookup"><span data-stu-id="fa7b2-173">Header</span></span>| <span data-ttu-id="fa7b2-174">Value</span><span class="sxs-lookup"><span data-stu-id="fa7b2-174">Value</span></span>| <span data-ttu-id="fa7b2-175">説明</span><span class="sxs-lookup"><span data-stu-id="fa7b2-175">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="fa7b2-176">X-XblCorrelationId</span><span class="sxs-lookup"><span data-stu-id="fa7b2-176">X-XblCorrelationId</span></span>|  | <span data-ttu-id="fa7b2-177">応答本文の mime の種類。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-177">The mime type of the response body.</span></span>| 
  
<a id="ID4EEH"></a>

 
## <a name="response-body"></a><span data-ttu-id="fa7b2-178">応答本文</span><span class="sxs-lookup"><span data-stu-id="fa7b2-178">Response Body</span></span>
 
<span data-ttu-id="fa7b2-179">呼び出しが成功した場合、サービスは、次のメンバーを持つ JSON オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-179">If the call is successful, the service will return a JSON object with the following members.</span></span>
 
| <span data-ttu-id="fa7b2-180">メンバー</span><span class="sxs-lookup"><span data-stu-id="fa7b2-180">Member</span></span>| <span data-ttu-id="fa7b2-181">説明</span><span class="sxs-lookup"><span data-stu-id="fa7b2-181">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="fa7b2-182">バリアント</span><span class="sxs-lookup"><span data-stu-id="fa7b2-182">variants</span></span>| <span data-ttu-id="fa7b2-183">Variant の配列。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-183">An array of variants.</span></span>| 
| <span data-ttu-id="fa7b2-184">バリエーション</span><span class="sxs-lookup"><span data-stu-id="fa7b2-184">variantId</span></span>| <span data-ttu-id="fa7b2-185">バリアント型の Id。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-185">The Id of a variant.</span></span>| 
| <span data-ttu-id="fa7b2-186">name</span><span class="sxs-lookup"><span data-stu-id="fa7b2-186">name</span></span>| <span data-ttu-id="fa7b2-187">バリアントの名前。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-187">The name of a variant.</span></span>| 
| <span data-ttu-id="fa7b2-188">isPublisher</span><span class="sxs-lookup"><span data-stu-id="fa7b2-188">isPublisher</span></span>|  | 
| <span data-ttu-id="fa7b2-189">ランク</span><span class="sxs-lookup"><span data-stu-id="fa7b2-189">rank</span></span>|  | 
| <span data-ttu-id="fa7b2-190">gameVariantSchemaId</span><span class="sxs-lookup"><span data-stu-id="fa7b2-190">gameVariantSchemaId</span></span>|  | 
| <span data-ttu-id="fa7b2-191">variantSchemas</span><span class="sxs-lookup"><span data-stu-id="fa7b2-191">variantSchemas</span></span>| <span data-ttu-id="fa7b2-192">バリアント型のスキーマの配列。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-192">An array of variant schemas.</span></span>| 
| <span data-ttu-id="fa7b2-193">variantSchemaId</span><span class="sxs-lookup"><span data-stu-id="fa7b2-193">variantSchemaId</span></span>| <span data-ttu-id="fa7b2-194">スキーマの Id。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-194">The Id of the schema.</span></span>| 
| <span data-ttu-id="fa7b2-195">schemaContent</span><span class="sxs-lookup"><span data-stu-id="fa7b2-195">schemaContent</span></span>| <span data-ttu-id="fa7b2-196">スキーマの内容</span><span class="sxs-lookup"><span data-stu-id="fa7b2-196">The schema contents</span></span>| 
| <span data-ttu-id="fa7b2-197">name</span><span class="sxs-lookup"><span data-stu-id="fa7b2-197">name</span></span>| <span data-ttu-id="fa7b2-198">スキーマの名前</span><span class="sxs-lookup"><span data-stu-id="fa7b2-198">Name of the schema</span></span>| 
| <span data-ttu-id="fa7b2-199">gsiSets</span><span class="sxs-lookup"><span data-stu-id="fa7b2-199">gsiSets</span></span>| <span data-ttu-id="fa7b2-200">GSI の配列を設定します。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-200">An array of GSI sets.</span></span>| 
| <span data-ttu-id="fa7b2-201">minRequiredPlayers</span><span class="sxs-lookup"><span data-stu-id="fa7b2-201">minRequiredPlayers</span></span>| <span data-ttu-id="fa7b2-202">バリアントのプレイヤーの最小数。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-202">The minimum number of players for the variant.</span></span>| 
| <span data-ttu-id="fa7b2-203">maxAllowedPlayers</span><span class="sxs-lookup"><span data-stu-id="fa7b2-203">maxAllowedPlayers</span></span>| <span data-ttu-id="fa7b2-204">バリアントのプレイヤーの最大数。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-204">The maximum number of players for the variant.</span></span>| 
| <span data-ttu-id="fa7b2-205">gsiSetId</span><span class="sxs-lookup"><span data-stu-id="fa7b2-205">gsiSetId</span></span>| <span data-ttu-id="fa7b2-206">GSI セットの Id。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-206">The Id of the GSI set.</span></span>| 
| <span data-ttu-id="fa7b2-207">gsiSetName</span><span class="sxs-lookup"><span data-stu-id="fa7b2-207">gsiSetName</span></span>| <span data-ttu-id="fa7b2-208">GSI セットの名前。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-208">The name of the GSI set.</span></span>| 
| <span data-ttu-id="fa7b2-209">selectionOrder</span><span class="sxs-lookup"><span data-stu-id="fa7b2-209">selectionOrder</span></span>|  | 
| <span data-ttu-id="fa7b2-210">variantSchemaId</span><span class="sxs-lookup"><span data-stu-id="fa7b2-210">variantSchemaId</span></span>| <span data-ttu-id="fa7b2-211">GSI で使用される varaint スキーマの id を設定します。</span><span class="sxs-lookup"><span data-stu-id="fa7b2-211">Id of the varaint schema used in the GSI set.</span></span>| 
 
<a id="ID4EYBAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="fa7b2-212">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="fa7b2-212">Sample Response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="fa7b2-213">関連項目</span><span class="sxs-lookup"><span data-stu-id="fa7b2-213">See also</span></span>
 [<span data-ttu-id="fa7b2-214">/titles/{titleId}/variants</span><span class="sxs-lookup"><span data-stu-id="fa7b2-214">/titles/{titleId}/variants</span></span>](uri-titlestitleidvariants.md)

  