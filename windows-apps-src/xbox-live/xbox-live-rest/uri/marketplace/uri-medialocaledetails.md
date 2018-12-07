---
title: /media/{marketplaceId}/details
assetID: bc8758ed-2f90-b501-5c3f-6f253f02d754
permalink: en-us/docs/xboxlive/rest/uri-medialocaledetails.html
description: " /media/{marketplaceId}/details"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f58e5247c3fd52e84a3a9bab28c6926f74e864e3
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8789905"
---
# <a name="mediamarketplaceiddetails"></a><span data-ttu-id="7a59d-104">/media/{marketplaceId}/details</span><span class="sxs-lookup"><span data-stu-id="7a59d-104">/media/{marketplaceId}/details</span></span>
<span data-ttu-id="7a59d-105">返します提供の詳細とメタデータについての 1 つまたは複数の項目です。</span><span class="sxs-lookup"><span data-stu-id="7a59d-105">Returns offer details and metadata about one or more items.</span></span> <span data-ttu-id="7a59d-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="7a59d-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
<span data-ttu-id="7a59d-107">API は、関連する API と参照 API によって異なります詳細 (とき、ID で passin) 詳細 API には、追加の情報が返されますが、それらの Api は、暗黙的または明示的に fiven ID に関連付けられているその他の項目に関する情報を返すよう。同じ項目。</span><span class="sxs-lookup"><span data-stu-id="7a59d-107">The details API differs from the Related API and the Browse API (when passin in an ID) as those APIs return information about other items that are associated with the fiven ID, either explicitly or implicitly, whereas the details API returns additional information about the same item.</span></span>
 
<span data-ttu-id="7a59d-108">別のメディア項目の種類の複数の Id は、1 つに渡すことができます (限り ProviderContentID - 以下を参照型のわからない)、呼び出しが同じメディア グループに属するすべてする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a59d-108">Multiple IDs of different media item types can be passed into a single call (as long as they're not of type ProviderContentID - see below), but they all must belong to the same media group.</span></span> <span data-ttu-id="7a59d-109">ただし、これには、呼び出し元がメディアのグループを認識しないクライアントのシナリオのいくつかがあります。</span><span class="sxs-lookup"><span data-stu-id="7a59d-109">However, there are a couple of client scenarios where the caller doesn't know the media group.</span></span> <span data-ttu-id="7a59d-110">API は、次のような状況でのメディアのグループには、"Unknown"の特殊値を許可することでこれをサポートします。</span><span class="sxs-lookup"><span data-stu-id="7a59d-110">The API supports this by allowing a sepcial value of "Unknown" for the media group in the following situations:</span></span>
 
   * <span data-ttu-id="7a59d-111">idType = XboxHexTitle で、AppType またはゲームの種類のいずれかの項目が生成されます</span><span class="sxs-lookup"><span data-stu-id="7a59d-111">idType = XboxHexTitle, which will yield either AppType or GameType items</span></span>
   * <span data-ttu-id="7a59d-112">idType = ProviderContentId で、MovieType または TVType 項目が生成されます</span><span class="sxs-lookup"><span data-stu-id="7a59d-112">idType = ProviderContentId, which will yield MovieType or TVType items</span></span>
  
<span data-ttu-id="7a59d-113">次の図は、どのメディア グループと ID の種類を指定できます全体のマッピングをまとめたものです。</span><span class="sxs-lookup"><span data-stu-id="7a59d-113">The following chart summarizes the entire mapping of which ID types can be provided with which media groups:</span></span>
 
| <span data-ttu-id="7a59d-114">ID の種類</span><span class="sxs-lookup"><span data-stu-id="7a59d-114">ID Type</span></span>| <span data-ttu-id="7a59d-115">AppType</span><span class="sxs-lookup"><span data-stu-id="7a59d-115">AppType</span></span>| <span data-ttu-id="7a59d-116">ゲームの種類</span><span class="sxs-lookup"><span data-stu-id="7a59d-116">GameType</span></span>| <span data-ttu-id="7a59d-117">MovieType</span><span class="sxs-lookup"><span data-stu-id="7a59d-117">MovieType</span></span>| <span data-ttu-id="7a59d-118">MusicArtistType</span><span class="sxs-lookup"><span data-stu-id="7a59d-118">MusicArtistType</span></span>| <span data-ttu-id="7a59d-119">MusicType</span><span class="sxs-lookup"><span data-stu-id="7a59d-119">MusicType</span></span>| <span data-ttu-id="7a59d-120">TVType</span><span class="sxs-lookup"><span data-stu-id="7a59d-120">TVType</span></span>| <span data-ttu-id="7a59d-121">WebVideoType</span><span class="sxs-lookup"><span data-stu-id="7a59d-121">WebVideoType</span></span>| <span data-ttu-id="7a59d-122">Unknown</span><span class="sxs-lookup"><span data-stu-id="7a59d-122">Unknown</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="7a59d-123">正規</span><span class="sxs-lookup"><span data-stu-id="7a59d-123">Canonical</span></span>| <span data-ttu-id="7a59d-124">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-124">Y</span></span>| <span data-ttu-id="7a59d-125">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-125">Y</span></span>| <span data-ttu-id="7a59d-126">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-126">Y</span></span>| <span data-ttu-id="7a59d-127">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-127">Y</span></span>| <span data-ttu-id="7a59d-128">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-128">Y</span></span>| <span data-ttu-id="7a59d-129">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-129">Y</span></span>| <span data-ttu-id="7a59d-130">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-130">Y</span></span>| <span data-ttu-id="7a59d-131">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-131">N</span></span>| 
| <span data-ttu-id="7a59d-132">ZuneCatalog</span><span class="sxs-lookup"><span data-stu-id="7a59d-132">ZuneCatalog</span></span>| <span data-ttu-id="7a59d-133">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-133">N</span></span>| <span data-ttu-id="7a59d-134">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-134">N</span></span>| <span data-ttu-id="7a59d-135">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-135">Y</span></span>| <span data-ttu-id="7a59d-136">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-136">Y</span></span>| <span data-ttu-id="7a59d-137">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-137">Y</span></span>| <span data-ttu-id="7a59d-138">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-138">Y</span></span>| <span data-ttu-id="7a59d-139">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-139">N</span></span>| <span data-ttu-id="7a59d-140">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-140">N</span></span>| 
| <span data-ttu-id="7a59d-141">ZuneMediaInstance</span><span class="sxs-lookup"><span data-stu-id="7a59d-141">ZuneMediaInstance</span></span>| <span data-ttu-id="7a59d-142">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-142">N</span></span>| <span data-ttu-id="7a59d-143">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-143">N</span></span>| <span data-ttu-id="7a59d-144">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-144">Y</span></span>| <span data-ttu-id="7a59d-145">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-145">N</span></span>| <span data-ttu-id="7a59d-146">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-146">Y</span></span>| <span data-ttu-id="7a59d-147">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-147">Y</span></span>| <span data-ttu-id="7a59d-148">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-148">N</span></span>| <span data-ttu-id="7a59d-149">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-149">N</span></span>| 
| <span data-ttu-id="7a59d-150">提案</span><span class="sxs-lookup"><span data-stu-id="7a59d-150">Offer</span></span>| <span data-ttu-id="7a59d-151">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-151">Y</span></span>| <span data-ttu-id="7a59d-152">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-152">Y</span></span>| <span data-ttu-id="7a59d-153">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-153">Y</span></span>| <span data-ttu-id="7a59d-154">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-154">N</span></span>| <span data-ttu-id="7a59d-155">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-155">Y</span></span>| <span data-ttu-id="7a59d-156">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-156">Y</span></span>| <span data-ttu-id="7a59d-157">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-157">N</span></span>| <span data-ttu-id="7a59d-158">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-158">N</span></span>| 
| <span data-ttu-id="7a59d-159">AMG</span><span class="sxs-lookup"><span data-stu-id="7a59d-159">AMG</span></span>| <span data-ttu-id="7a59d-160">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-160">N</span></span>| <span data-ttu-id="7a59d-161">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-161">N</span></span>| <span data-ttu-id="7a59d-162">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-162">N</span></span>| <span data-ttu-id="7a59d-163">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-163">N</span></span>| <span data-ttu-id="7a59d-164">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-164">Y</span></span>| <span data-ttu-id="7a59d-165">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-165">N</span></span>| <span data-ttu-id="7a59d-166">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-166">N</span></span>| <span data-ttu-id="7a59d-167">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-167">N</span></span>| 
| <span data-ttu-id="7a59d-168">MediaNet</span><span class="sxs-lookup"><span data-stu-id="7a59d-168">MediaNet</span></span>| <span data-ttu-id="7a59d-169">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-169">N</span></span>| <span data-ttu-id="7a59d-170">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-170">N</span></span>| <span data-ttu-id="7a59d-171">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-171">N</span></span>| <span data-ttu-id="7a59d-172">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-172">N</span></span>| <span data-ttu-id="7a59d-173">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-173">Y</span></span>| <span data-ttu-id="7a59d-174">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-174">N</span></span>| <span data-ttu-id="7a59d-175">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-175">N</span></span>| <span data-ttu-id="7a59d-176">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-176">N</span></span>| 
| <span data-ttu-id="7a59d-177">XboxHexTitle</span><span class="sxs-lookup"><span data-stu-id="7a59d-177">XboxHexTitle</span></span>| <span data-ttu-id="7a59d-178">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-178">Y</span></span>| <span data-ttu-id="7a59d-179">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-179">Y</span></span>| <span data-ttu-id="7a59d-180">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-180">N</span></span>| <span data-ttu-id="7a59d-181">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-181">N</span></span>| <span data-ttu-id="7a59d-182">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-182">N</span></span>| <span data-ttu-id="7a59d-183">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-183">N</span></span>| <span data-ttu-id="7a59d-184">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-184">N</span></span>| <span data-ttu-id="7a59d-185">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-185">Y</span></span>| 
| <span data-ttu-id="7a59d-186">ProviderContentId</span><span class="sxs-lookup"><span data-stu-id="7a59d-186">ProviderContentId</span></span>| <span data-ttu-id="7a59d-187">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-187">N</span></span>| <span data-ttu-id="7a59d-188">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-188">N</span></span>| <span data-ttu-id="7a59d-189">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-189">Y</span></span>| <span data-ttu-id="7a59d-190">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-190">N</span></span>| <span data-ttu-id="7a59d-191">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-191">N</span></span>| <span data-ttu-id="7a59d-192">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-192">Y</span></span>| <span data-ttu-id="7a59d-193">N</span><span class="sxs-lookup"><span data-stu-id="7a59d-193">N</span></span>| <span data-ttu-id="7a59d-194">Y</span><span class="sxs-lookup"><span data-stu-id="7a59d-194">Y</span></span>| 
 
  * [<span data-ttu-id="7a59d-195">パラメーターの注意事項</span><span class="sxs-lookup"><span data-stu-id="7a59d-195">Parameter Notes</span></span>](#ID4EEH)
  * [<span data-ttu-id="7a59d-196">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7a59d-196">URI parameters</span></span>](#ID4EUH)
 
<a id="ID4EEH"></a>

 
## <a name="parameter-notes"></a><span data-ttu-id="7a59d-197">パラメーターの注意事項</span><span class="sxs-lookup"><span data-stu-id="7a59d-197">Parameter Notes</span></span>
 
<a id="ID4EIH"></a>

 
### <a name="providercontentid"></a><span data-ttu-id="7a59d-198">ProviderContentId</span><span class="sxs-lookup"><span data-stu-id="7a59d-198">ProviderContentId</span></span>
 
<span data-ttu-id="7a59d-199">これは、検索プロバイダーを使用特定 id。 例。</span><span class="sxs-lookup"><span data-stu-id="7a59d-199">This is used to lookup provider specific Id. E.g.</span></span> <span data-ttu-id="7a59d-200">Netflix Id または Hulu id。</span><span class="sxs-lookup"><span data-stu-id="7a59d-200">Netflix Id or Hulu Id.</span></span>
 
<span data-ttu-id="7a59d-201">IdType ProviderContentId がある場合は、1 つの値のみが受け入れられます。</span><span class="sxs-lookup"><span data-stu-id="7a59d-201">When idType is ProviderContentId, only a single value is accepted.</span></span> <span data-ttu-id="7a59d-202">これは、ProviderContentIds は種類の ID が含まれるだけであるため、'.' 文字です。</span><span class="sxs-lookup"><span data-stu-id="7a59d-202">This is because ProviderContentIds are the only type of ID that can contain the '.' character.</span></span> <span data-ttu-id="7a59d-203">'.' 文字はする Id 間の区切り文字でも、新機能、delimieter Id 間の間にあいまいさがおよび新機能自体 ID の一部です。</span><span class="sxs-lookup"><span data-stu-id="7a59d-203">Since the '.' character is also the separator that we use between IDs, there's ambiguity between what's a delimieter between IDs and what's part of the ID itself.</span></span> <span data-ttu-id="7a59d-204">API の残りの部分一括検索機能を除く、ProviderContentIds の同じように動作します。</span><span class="sxs-lookup"><span data-stu-id="7a59d-204">The rest of the API works the same way for ProviderContentIds, except for the bulk lookup functionality.</span></span>
   
<a id="ID4EUH"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="7a59d-205">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7a59d-205">URI parameters</span></span>
 
| <span data-ttu-id="7a59d-206">パラメーター</span><span class="sxs-lookup"><span data-stu-id="7a59d-206">Parameter</span></span>| <span data-ttu-id="7a59d-207">型</span><span class="sxs-lookup"><span data-stu-id="7a59d-207">Type</span></span>| <span data-ttu-id="7a59d-208">説明</span><span class="sxs-lookup"><span data-stu-id="7a59d-208">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="7a59d-209">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="7a59d-209">marketplaceId</span></span>| <span data-ttu-id="7a59d-210">string</span><span class="sxs-lookup"><span data-stu-id="7a59d-210">string</span></span>| <span data-ttu-id="7a59d-211">必須。</span><span class="sxs-lookup"><span data-stu-id="7a59d-211">Required.</span></span> <span data-ttu-id="7a59d-212"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="7a59d-212">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EWAAC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="7a59d-213">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="7a59d-213">Valid methods</span></span>

[<span data-ttu-id="7a59d-214">GET (/media/{marketplaceId}/details)</span><span class="sxs-lookup"><span data-stu-id="7a59d-214">GET (/media/{marketplaceId}/details)</span></span>](uri-medialocaledetailsget.md)

<span data-ttu-id="7a59d-215">&nbsp;&nbsp;返します提供の詳細とメタデータについての 1 つまたは複数の項目です。</span><span class="sxs-lookup"><span data-stu-id="7a59d-215">&nbsp;&nbsp;Returns offer details and metadata about one or more items.</span></span> 
 
<a id="ID4EABAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="7a59d-216">関連項目</span><span class="sxs-lookup"><span data-stu-id="7a59d-216">See also</span></span>
 
<a id="ID4ECBAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="7a59d-217">Parent</span><span class="sxs-lookup"><span data-stu-id="7a59d-217">Parent</span></span> 

[<span data-ttu-id="7a59d-218">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="7a59d-218">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EMBAC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="7a59d-219">詳細情報</span><span class="sxs-lookup"><span data-stu-id="7a59d-219">Further Information</span></span> 

[<span data-ttu-id="7a59d-220">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7a59d-220">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="7a59d-221">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="7a59d-221">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="7a59d-222">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="7a59d-222">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="7a59d-223">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="7a59d-223">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   