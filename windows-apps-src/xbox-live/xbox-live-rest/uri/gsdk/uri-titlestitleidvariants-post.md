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
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4015895"
---
# <a name="post-titlestitleidvariants"></a><span data-ttu-id="eb8b0-104">POST (/titles/{titleId}/variants)</span><span class="sxs-lookup"><span data-stu-id="eb8b0-104">POST (/titles/{titleId}/variants)</span></span>
<span data-ttu-id="eb8b0-105">指定されたタイトル id。 用のバリアントをゲームの一覧を取得するクライアントによって呼び出される URIこれらの Uri のドメインは、`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-105">URI called by a client that retrieves a list of game variants for the specified title Id. The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="eb8b0-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="eb8b0-106">URI Parameters</span></span>](#ID4EZ)
  * [<span data-ttu-id="eb8b0-107">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="eb8b0-107">Required Request Headers</span></span>](#ID4EIB)
  * [<span data-ttu-id="eb8b0-108">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="eb8b0-108">Optional Request Headers</span></span>](#ID4EED)
  * [<span data-ttu-id="eb8b0-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="eb8b0-109">Authorization</span></span>](#ID4E3D)
  * [<span data-ttu-id="eb8b0-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="eb8b0-110">Request Body</span></span>](#ID4EEE)
  * [<span data-ttu-id="eb8b0-111">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="eb8b0-111">Required Response Headers</span></span>](#ID4ELF)
  * [<span data-ttu-id="eb8b0-112">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="eb8b0-112">Optional Response Headers</span></span>](#ID4EMG)
  * [<span data-ttu-id="eb8b0-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="eb8b0-113">Response Body</span></span>](#ID4EEH)
 
<a id="ID4EZ"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="eb8b0-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="eb8b0-114">URI Parameters</span></span>
 
| <span data-ttu-id="eb8b0-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="eb8b0-115">Parameter</span></span>| <span data-ttu-id="eb8b0-116">説明</span><span class="sxs-lookup"><span data-stu-id="eb8b0-116">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="eb8b0-117">タイトル id</span><span class="sxs-lookup"><span data-stu-id="eb8b0-117">titleid</span></span>| <span data-ttu-id="eb8b0-118">要求の操作のタイトルの ID です。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-118">ID of the title that the request should operate on.</span></span>| 
  
<a id="ID5EG"></a>

 
## <a name="host-name"></a><span data-ttu-id="eb8b0-119">ホスト名</span><span class="sxs-lookup"><span data-stu-id="eb8b0-119">Host Name</span></span>

<span data-ttu-id="eb8b0-120">gameserverds.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="eb8b0-120">gameserverds.xboxlive.com</span></span>
 
<a id="ID4EIB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="eb8b0-121">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="eb8b0-121">Required Request Headers</span></span>
 
<span data-ttu-id="eb8b0-122">要求を行う場合、次の表に示すようにヘッダーは必要です。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-122">When making a request, the headers shown in the following table are required.</span></span>
 
| <span data-ttu-id="eb8b0-123">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="eb8b0-123">Header</span></span>| <span data-ttu-id="eb8b0-124">設定値</span><span class="sxs-lookup"><span data-stu-id="eb8b0-124">Value</span></span>| <span data-ttu-id="eb8b0-125">説明</span><span class="sxs-lookup"><span data-stu-id="eb8b0-125">Description</span></span>| 
| --- | --- | --- | --- | --- | 
| <span data-ttu-id="eb8b0-126">Content-Type</span><span class="sxs-lookup"><span data-stu-id="eb8b0-126">Content-Type</span></span>| <span data-ttu-id="eb8b0-127">application/json</span><span class="sxs-lookup"><span data-stu-id="eb8b0-127">application/json</span></span>| <span data-ttu-id="eb8b0-128">送信されたデータの種類です。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-128">Type of data being submitted.</span></span>| 
| <span data-ttu-id="eb8b0-129">Host</span><span class="sxs-lookup"><span data-stu-id="eb8b0-129">Host</span></span>| <span data-ttu-id="eb8b0-130">gameserverds.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="eb8b0-130">gameserverds.xboxlive.com</span></span>|  | 
| <span data-ttu-id="eb8b0-131">Content-Length</span><span class="sxs-lookup"><span data-stu-id="eb8b0-131">Content-Length</span></span>|  | <span data-ttu-id="eb8b0-132">要求オブジェクトの長さ。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-132">Length of the request object.</span></span>| 
| <span data-ttu-id="eb8b0-133">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="eb8b0-133">x-xbl-contract-version</span></span>| <span data-ttu-id="eb8b0-134">1</span><span class="sxs-lookup"><span data-stu-id="eb8b0-134">1</span></span>| <span data-ttu-id="eb8b0-135">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-135">API contract version.</span></span>| 
| <span data-ttu-id="eb8b0-136">Authorization</span><span class="sxs-lookup"><span data-stu-id="eb8b0-136">Authorization</span></span>| <span data-ttu-id="eb8b0-137">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="eb8b0-137">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="eb8b0-138">認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-138">Authentication token.</span></span>| 
  
<a id="ID4EED"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="eb8b0-139">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="eb8b0-139">Optional Request Headers</span></span>
 
<span data-ttu-id="eb8b0-140">要求を行う場合は、次の表に示すようにヘッダーはオプションです。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-140">When making a request, the headers shown in the following table are optional.</span></span>
 
| <span data-ttu-id="eb8b0-141">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="eb8b0-141">Header</span></span>| <span data-ttu-id="eb8b0-142">設定値</span><span class="sxs-lookup"><span data-stu-id="eb8b0-142">Value</span></span>| <span data-ttu-id="eb8b0-143">説明</span><span class="sxs-lookup"><span data-stu-id="eb8b0-143">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="eb8b0-144">X XblCorrelationId</span><span class="sxs-lookup"><span data-stu-id="eb8b0-144">X-XblCorrelationId</span></span>|  | <span data-ttu-id="eb8b0-145">要求の本文の mime タイプ。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-145">The mime type of the body of the request.</span></span>| 
  
<a id="ID4E3D"></a>

 
## <a name="authorization"></a><span data-ttu-id="eb8b0-146">Authorization</span><span class="sxs-lookup"><span data-stu-id="eb8b0-146">Authorization</span></span>

<span data-ttu-id="eb8b0-147">要求は、Xbox Live の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-147">The request must include a valid Xbox Live authorization header.</span></span> <span data-ttu-id="eb8b0-148">呼び出し元がこのリソースへのアクセスを許可しない場合、サービスは応答に 403 Forbidden を返します。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-148">If the caller is not allowed to access this resource, the service returns 403 Forbidden in response.</span></span> <span data-ttu-id="eb8b0-149">ヘッダーが見つからないか無効な場合は、サービスは応答で 401 Unauthorized を返します。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-149">If the header is invalid or missing, the service returns 401 Unauthorized in response.</span></span>
 
<a id="ID4EEE"></a>

 
## <a name="request-body"></a><span data-ttu-id="eb8b0-150">要求本文</span><span class="sxs-lookup"><span data-stu-id="eb8b0-150">Request Body</span></span>
 
<span data-ttu-id="eb8b0-151">要求は、次のメンバーを含む JSON オブジェクトを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-151">The request must contain a JSON object with the following members.</span></span>
 
| <span data-ttu-id="eb8b0-152">メンバー</span><span class="sxs-lookup"><span data-stu-id="eb8b0-152">Member</span></span>| <span data-ttu-id="eb8b0-153">説明</span><span class="sxs-lookup"><span data-stu-id="eb8b0-153">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="eb8b0-154">locale</span><span class="sxs-lookup"><span data-stu-id="eb8b0-154">locale</span></span>| <span data-ttu-id="eb8b0-155">返されるバリエーションのローカルです。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-155">The local of variants to return.</span></span>| 
| <span data-ttu-id="eb8b0-156">maxVariants</span><span class="sxs-lookup"><span data-stu-id="eb8b0-156">maxVariants</span></span>| <span data-ttu-id="eb8b0-157">返されるバリアントの最大数。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-157">The maximum number of variants to return.</span></span>| 
| <span data-ttu-id="eb8b0-158">publisherOnly</span><span class="sxs-lookup"><span data-stu-id="eb8b0-158">publisherOnly</span></span>|  | 
| <span data-ttu-id="eb8b0-159">制限</span><span class="sxs-lookup"><span data-stu-id="eb8b0-159">restriction</span></span>|  | 
 
<a id="ID4EDF"></a>

 
### <a name="sample-request"></a><span data-ttu-id="eb8b0-160">要求の例</span><span class="sxs-lookup"><span data-stu-id="eb8b0-160">Sample Request</span></span>
 

```cpp
{
  "locale": "en-us",
  "maxVariants": "100",
  "publisherOnly": "false",
  "restriction": null
}

```

   
<a id="ID4ELF"></a>

 
## <a name="required-response-headers"></a><span data-ttu-id="eb8b0-161">必要な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="eb8b0-161">Required Response Headers</span></span>
 
<span data-ttu-id="eb8b0-162">応答は常に、次の表に示すようにヘッダーを含めます。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-162">A response will always include the headers shown in the following table.</span></span>
 
| <span data-ttu-id="eb8b0-163">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="eb8b0-163">Header</span></span>| <span data-ttu-id="eb8b0-164">設定値</span><span class="sxs-lookup"><span data-stu-id="eb8b0-164">Value</span></span>| <span data-ttu-id="eb8b0-165">説明</span><span class="sxs-lookup"><span data-stu-id="eb8b0-165">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="eb8b0-166">Content-Type</span><span class="sxs-lookup"><span data-stu-id="eb8b0-166">Content-Type</span></span>| <span data-ttu-id="eb8b0-167">application/json</span><span class="sxs-lookup"><span data-stu-id="eb8b0-167">application/json</span></span>| <span data-ttu-id="eb8b0-168">応答本文内のデータの種類です。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-168">Type of data in the response body.</span></span>| 
| <span data-ttu-id="eb8b0-169">Content-Length</span><span class="sxs-lookup"><span data-stu-id="eb8b0-169">Content-Length</span></span>|  | <span data-ttu-id="eb8b0-170">応答本文の長さ。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-170">Length of the response body.</span></span>| 
  
<a id="ID4EMG"></a>

 
## <a name="optional-response-headers"></a><span data-ttu-id="eb8b0-171">省略可能な応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="eb8b0-171">Optional Response Headers</span></span>
 
<span data-ttu-id="eb8b0-172">応答には、次に示すようにヘッダー各自が可能性があります。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-172">A response may inlcude the headers shown in the following.</span></span>
 
| <span data-ttu-id="eb8b0-173">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="eb8b0-173">Header</span></span>| <span data-ttu-id="eb8b0-174">設定値</span><span class="sxs-lookup"><span data-stu-id="eb8b0-174">Value</span></span>| <span data-ttu-id="eb8b0-175">説明</span><span class="sxs-lookup"><span data-stu-id="eb8b0-175">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="eb8b0-176">X XblCorrelationId</span><span class="sxs-lookup"><span data-stu-id="eb8b0-176">X-XblCorrelationId</span></span>|  | <span data-ttu-id="eb8b0-177">応答本文の mime タイプ。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-177">The mime type of the response body.</span></span>| 
  
<a id="ID4EEH"></a>

 
## <a name="response-body"></a><span data-ttu-id="eb8b0-178">応答本文</span><span class="sxs-lookup"><span data-stu-id="eb8b0-178">Response Body</span></span>
 
<span data-ttu-id="eb8b0-179">呼び出しが成功した場合は、サービスは、次のメンバーを含む JSON オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-179">If the call is successful, the service will return a JSON object with the following members.</span></span>
 
| <span data-ttu-id="eb8b0-180">メンバー</span><span class="sxs-lookup"><span data-stu-id="eb8b0-180">Member</span></span>| <span data-ttu-id="eb8b0-181">説明</span><span class="sxs-lookup"><span data-stu-id="eb8b0-181">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="eb8b0-182">バリエーション</span><span class="sxs-lookup"><span data-stu-id="eb8b0-182">variants</span></span>| <span data-ttu-id="eb8b0-183">バリアントの配列です。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-183">An array of variants.</span></span>| 
| <span data-ttu-id="eb8b0-184">バリエーション</span><span class="sxs-lookup"><span data-stu-id="eb8b0-184">variantId</span></span>| <span data-ttu-id="eb8b0-185">バリアントの Id です。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-185">The Id of a variant.</span></span>| 
| <span data-ttu-id="eb8b0-186">name</span><span class="sxs-lookup"><span data-stu-id="eb8b0-186">name</span></span>| <span data-ttu-id="eb8b0-187">バリアントの名前です。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-187">The name of a variant.</span></span>| 
| <span data-ttu-id="eb8b0-188">isPublisher</span><span class="sxs-lookup"><span data-stu-id="eb8b0-188">isPublisher</span></span>|  | 
| <span data-ttu-id="eb8b0-189">ランク</span><span class="sxs-lookup"><span data-stu-id="eb8b0-189">rank</span></span>|  | 
| <span data-ttu-id="eb8b0-190">gameVariantSchemaId</span><span class="sxs-lookup"><span data-stu-id="eb8b0-190">gameVariantSchemaId</span></span>|  | 
| <span data-ttu-id="eb8b0-191">variantSchemas</span><span class="sxs-lookup"><span data-stu-id="eb8b0-191">variantSchemas</span></span>| <span data-ttu-id="eb8b0-192">バリアントのスキーマの配列です。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-192">An array of variant schemas.</span></span>| 
| <span data-ttu-id="eb8b0-193">variantSchemaId</span><span class="sxs-lookup"><span data-stu-id="eb8b0-193">variantSchemaId</span></span>| <span data-ttu-id="eb8b0-194">スキーマの Id です。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-194">The Id of the schema.</span></span>| 
| <span data-ttu-id="eb8b0-195">schemaContent</span><span class="sxs-lookup"><span data-stu-id="eb8b0-195">schemaContent</span></span>| <span data-ttu-id="eb8b0-196">スキーマの内容</span><span class="sxs-lookup"><span data-stu-id="eb8b0-196">The schema contents</span></span>| 
| <span data-ttu-id="eb8b0-197">name</span><span class="sxs-lookup"><span data-stu-id="eb8b0-197">name</span></span>| <span data-ttu-id="eb8b0-198">スキーマの名前</span><span class="sxs-lookup"><span data-stu-id="eb8b0-198">Name of the schema</span></span>| 
| <span data-ttu-id="eb8b0-199">gsiSets</span><span class="sxs-lookup"><span data-stu-id="eb8b0-199">gsiSets</span></span>| <span data-ttu-id="eb8b0-200">GSI セットの配列です。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-200">An array of GSI sets.</span></span>| 
| <span data-ttu-id="eb8b0-201">minRequiredPlayers</span><span class="sxs-lookup"><span data-stu-id="eb8b0-201">minRequiredPlayers</span></span>| <span data-ttu-id="eb8b0-202">バリアントのプレイヤーの最小数。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-202">The minimum number of players for the variant.</span></span>| 
| <span data-ttu-id="eb8b0-203">maxAllowedPlayers</span><span class="sxs-lookup"><span data-stu-id="eb8b0-203">maxAllowedPlayers</span></span>| <span data-ttu-id="eb8b0-204">バリアントのプレイヤーの最大数。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-204">The maximum number of players for the variant.</span></span>| 
| <span data-ttu-id="eb8b0-205">は</span><span class="sxs-lookup"><span data-stu-id="eb8b0-205">gsiSetId</span></span>| <span data-ttu-id="eb8b0-206">GSI セットの Id です。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-206">The Id of the GSI set.</span></span>| 
| <span data-ttu-id="eb8b0-207">gsiSetName</span><span class="sxs-lookup"><span data-stu-id="eb8b0-207">gsiSetName</span></span>| <span data-ttu-id="eb8b0-208">GSI セットの名前です。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-208">The name of the GSI set.</span></span>| 
| <span data-ttu-id="eb8b0-209">selectionOrder</span><span class="sxs-lookup"><span data-stu-id="eb8b0-209">selectionOrder</span></span>|  | 
| <span data-ttu-id="eb8b0-210">variantSchemaId</span><span class="sxs-lookup"><span data-stu-id="eb8b0-210">variantSchemaId</span></span>| <span data-ttu-id="eb8b0-211">GSI で使われる varaint スキーマの id を設定します。</span><span class="sxs-lookup"><span data-stu-id="eb8b0-211">Id of the varaint schema used in the GSI set.</span></span>| 
 
<a id="ID4EYBAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="eb8b0-212">応答の例</span><span class="sxs-lookup"><span data-stu-id="eb8b0-212">Sample Response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="eb8b0-213">関連項目</span><span class="sxs-lookup"><span data-stu-id="eb8b0-213">See also</span></span>
 [<span data-ttu-id="eb8b0-214">/titles/{titleId}/variants</span><span class="sxs-lookup"><span data-stu-id="eb8b0-214">/titles/{titleId}/variants</span></span>](uri-titlestitleidvariants.md)

  