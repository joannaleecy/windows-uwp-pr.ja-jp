---
title: /media/{marketplaceId}/details
assetID: bc8758ed-2f90-b501-5c3f-6f253f02d754
permalink: en-us/docs/xboxlive/rest/uri-medialocaledetails.html
author: KevinAsgari
description: " /media/{marketplaceId}/details"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d61d8f23936dc40648637df793d7610159498ac0
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7558696"
---
# <a name="mediamarketplaceiddetails"></a><span data-ttu-id="9e5fc-104">/media/{marketplaceId}/details</span><span class="sxs-lookup"><span data-stu-id="9e5fc-104">/media/{marketplaceId}/details</span></span>
<span data-ttu-id="9e5fc-105">返しますプランの詳細とメタデータについての 1 つまたは複数の項目。</span><span class="sxs-lookup"><span data-stu-id="9e5fc-105">Returns offer details and metadata about one or more items.</span></span> <span data-ttu-id="9e5fc-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="9e5fc-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
<span data-ttu-id="9e5fc-107">API は、関連する API と参照 API によって異なります詳細 (とき、ID で passin) 詳細 API には、追加の情報が返されますが、それらの Api は、暗黙的または明示的に、fiven ID に関連付けられているその他の項目に関する情報を返すよう。同じ項目。</span><span class="sxs-lookup"><span data-stu-id="9e5fc-107">The details API differs from the Related API and the Browse API (when passin in an ID) as those APIs return information about other items that are associated with the fiven ID, either explicitly or implicitly, whereas the details API returns additional information about the same item.</span></span>
 
<span data-ttu-id="9e5fc-108">1 つの異なるメディア項目の種類の複数の Id を渡すことができます (限り ProviderContentID - 以下を参照型のわからない)、呼び出しが同じメディア グループに属するすべてする必要があります。</span><span class="sxs-lookup"><span data-stu-id="9e5fc-108">Multiple IDs of different media item types can be passed into a single call (as long as they're not of type ProviderContentID - see below), but they all must belong to the same media group.</span></span> <span data-ttu-id="9e5fc-109">ただし、これには、呼び出し元がメディアのグループを認識しないクライアントのシナリオのいくつかがあります。</span><span class="sxs-lookup"><span data-stu-id="9e5fc-109">However, there are a couple of client scenarios where the caller doesn't know the media group.</span></span> <span data-ttu-id="9e5fc-110">API では、これを使用して、次のような状況でのメディアのグループには、"Unknown"の特殊値のことを許可します。</span><span class="sxs-lookup"><span data-stu-id="9e5fc-110">The API supports this by allowing a sepcial value of "Unknown" for the media group in the following situations:</span></span>
 
   * <span data-ttu-id="9e5fc-111">idType = XboxHexTitle で、AppType またはゲームの種類のいずれかの項目が生成されます</span><span class="sxs-lookup"><span data-stu-id="9e5fc-111">idType = XboxHexTitle, which will yield either AppType or GameType items</span></span>
   * <span data-ttu-id="9e5fc-112">idType = ProviderContentId で、MovieType または TVType 項目が生成されます</span><span class="sxs-lookup"><span data-stu-id="9e5fc-112">idType = ProviderContentId, which will yield MovieType or TVType items</span></span>
  
<span data-ttu-id="9e5fc-113">次の図は、どのメディア グループと ID の種類を指定できます全体のマッピングをまとめたものです。</span><span class="sxs-lookup"><span data-stu-id="9e5fc-113">The following chart summarizes the entire mapping of which ID types can be provided with which media groups:</span></span>
 
| <span data-ttu-id="9e5fc-114">ID の種類</span><span class="sxs-lookup"><span data-stu-id="9e5fc-114">ID Type</span></span>| <span data-ttu-id="9e5fc-115">AppType</span><span class="sxs-lookup"><span data-stu-id="9e5fc-115">AppType</span></span>| <span data-ttu-id="9e5fc-116">ゲームの種類</span><span class="sxs-lookup"><span data-stu-id="9e5fc-116">GameType</span></span>| <span data-ttu-id="9e5fc-117">MovieType</span><span class="sxs-lookup"><span data-stu-id="9e5fc-117">MovieType</span></span>| <span data-ttu-id="9e5fc-118">MusicArtistType</span><span class="sxs-lookup"><span data-stu-id="9e5fc-118">MusicArtistType</span></span>| <span data-ttu-id="9e5fc-119">MusicType</span><span class="sxs-lookup"><span data-stu-id="9e5fc-119">MusicType</span></span>| <span data-ttu-id="9e5fc-120">TVType</span><span class="sxs-lookup"><span data-stu-id="9e5fc-120">TVType</span></span>| <span data-ttu-id="9e5fc-121">WebVideoType</span><span class="sxs-lookup"><span data-stu-id="9e5fc-121">WebVideoType</span></span>| <span data-ttu-id="9e5fc-122">Unknown</span><span class="sxs-lookup"><span data-stu-id="9e5fc-122">Unknown</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="9e5fc-123">正規</span><span class="sxs-lookup"><span data-stu-id="9e5fc-123">Canonical</span></span>| <span data-ttu-id="9e5fc-124">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-124">Y</span></span>| <span data-ttu-id="9e5fc-125">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-125">Y</span></span>| <span data-ttu-id="9e5fc-126">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-126">Y</span></span>| <span data-ttu-id="9e5fc-127">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-127">Y</span></span>| <span data-ttu-id="9e5fc-128">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-128">Y</span></span>| <span data-ttu-id="9e5fc-129">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-129">Y</span></span>| <span data-ttu-id="9e5fc-130">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-130">Y</span></span>| <span data-ttu-id="9e5fc-131">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-131">N</span></span>| 
| <span data-ttu-id="9e5fc-132">ZuneCatalog</span><span class="sxs-lookup"><span data-stu-id="9e5fc-132">ZuneCatalog</span></span>| <span data-ttu-id="9e5fc-133">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-133">N</span></span>| <span data-ttu-id="9e5fc-134">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-134">N</span></span>| <span data-ttu-id="9e5fc-135">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-135">Y</span></span>| <span data-ttu-id="9e5fc-136">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-136">Y</span></span>| <span data-ttu-id="9e5fc-137">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-137">Y</span></span>| <span data-ttu-id="9e5fc-138">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-138">Y</span></span>| <span data-ttu-id="9e5fc-139">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-139">N</span></span>| <span data-ttu-id="9e5fc-140">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-140">N</span></span>| 
| <span data-ttu-id="9e5fc-141">ZuneMediaInstance</span><span class="sxs-lookup"><span data-stu-id="9e5fc-141">ZuneMediaInstance</span></span>| <span data-ttu-id="9e5fc-142">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-142">N</span></span>| <span data-ttu-id="9e5fc-143">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-143">N</span></span>| <span data-ttu-id="9e5fc-144">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-144">Y</span></span>| <span data-ttu-id="9e5fc-145">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-145">N</span></span>| <span data-ttu-id="9e5fc-146">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-146">Y</span></span>| <span data-ttu-id="9e5fc-147">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-147">Y</span></span>| <span data-ttu-id="9e5fc-148">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-148">N</span></span>| <span data-ttu-id="9e5fc-149">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-149">N</span></span>| 
| <span data-ttu-id="9e5fc-150">提案</span><span class="sxs-lookup"><span data-stu-id="9e5fc-150">Offer</span></span>| <span data-ttu-id="9e5fc-151">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-151">Y</span></span>| <span data-ttu-id="9e5fc-152">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-152">Y</span></span>| <span data-ttu-id="9e5fc-153">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-153">Y</span></span>| <span data-ttu-id="9e5fc-154">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-154">N</span></span>| <span data-ttu-id="9e5fc-155">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-155">Y</span></span>| <span data-ttu-id="9e5fc-156">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-156">Y</span></span>| <span data-ttu-id="9e5fc-157">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-157">N</span></span>| <span data-ttu-id="9e5fc-158">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-158">N</span></span>| 
| <span data-ttu-id="9e5fc-159">AMG</span><span class="sxs-lookup"><span data-stu-id="9e5fc-159">AMG</span></span>| <span data-ttu-id="9e5fc-160">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-160">N</span></span>| <span data-ttu-id="9e5fc-161">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-161">N</span></span>| <span data-ttu-id="9e5fc-162">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-162">N</span></span>| <span data-ttu-id="9e5fc-163">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-163">N</span></span>| <span data-ttu-id="9e5fc-164">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-164">Y</span></span>| <span data-ttu-id="9e5fc-165">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-165">N</span></span>| <span data-ttu-id="9e5fc-166">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-166">N</span></span>| <span data-ttu-id="9e5fc-167">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-167">N</span></span>| 
| <span data-ttu-id="9e5fc-168">MediaNet</span><span class="sxs-lookup"><span data-stu-id="9e5fc-168">MediaNet</span></span>| <span data-ttu-id="9e5fc-169">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-169">N</span></span>| <span data-ttu-id="9e5fc-170">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-170">N</span></span>| <span data-ttu-id="9e5fc-171">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-171">N</span></span>| <span data-ttu-id="9e5fc-172">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-172">N</span></span>| <span data-ttu-id="9e5fc-173">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-173">Y</span></span>| <span data-ttu-id="9e5fc-174">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-174">N</span></span>| <span data-ttu-id="9e5fc-175">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-175">N</span></span>| <span data-ttu-id="9e5fc-176">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-176">N</span></span>| 
| <span data-ttu-id="9e5fc-177">XboxHexTitle</span><span class="sxs-lookup"><span data-stu-id="9e5fc-177">XboxHexTitle</span></span>| <span data-ttu-id="9e5fc-178">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-178">Y</span></span>| <span data-ttu-id="9e5fc-179">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-179">Y</span></span>| <span data-ttu-id="9e5fc-180">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-180">N</span></span>| <span data-ttu-id="9e5fc-181">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-181">N</span></span>| <span data-ttu-id="9e5fc-182">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-182">N</span></span>| <span data-ttu-id="9e5fc-183">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-183">N</span></span>| <span data-ttu-id="9e5fc-184">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-184">N</span></span>| <span data-ttu-id="9e5fc-185">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-185">Y</span></span>| 
| <span data-ttu-id="9e5fc-186">ProviderContentId</span><span class="sxs-lookup"><span data-stu-id="9e5fc-186">ProviderContentId</span></span>| <span data-ttu-id="9e5fc-187">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-187">N</span></span>| <span data-ttu-id="9e5fc-188">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-188">N</span></span>| <span data-ttu-id="9e5fc-189">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-189">Y</span></span>| <span data-ttu-id="9e5fc-190">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-190">N</span></span>| <span data-ttu-id="9e5fc-191">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-191">N</span></span>| <span data-ttu-id="9e5fc-192">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-192">Y</span></span>| <span data-ttu-id="9e5fc-193">N</span><span class="sxs-lookup"><span data-stu-id="9e5fc-193">N</span></span>| <span data-ttu-id="9e5fc-194">Y</span><span class="sxs-lookup"><span data-stu-id="9e5fc-194">Y</span></span>| 
 
  * [<span data-ttu-id="9e5fc-195">パラメーターの注意事項</span><span class="sxs-lookup"><span data-stu-id="9e5fc-195">Parameter Notes</span></span>](#ID4EEH)
  * [<span data-ttu-id="9e5fc-196">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9e5fc-196">URI parameters</span></span>](#ID4EUH)
 
<a id="ID4EEH"></a>

 
## <a name="parameter-notes"></a><span data-ttu-id="9e5fc-197">パラメーターの注意事項</span><span class="sxs-lookup"><span data-stu-id="9e5fc-197">Parameter Notes</span></span>
 
<a id="ID4EIH"></a>

 
### <a name="providercontentid"></a><span data-ttu-id="9e5fc-198">ProviderContentId</span><span class="sxs-lookup"><span data-stu-id="9e5fc-198">ProviderContentId</span></span>
 
<span data-ttu-id="9e5fc-199">これは、検索プロバイダーを使用特定 id。 例。</span><span class="sxs-lookup"><span data-stu-id="9e5fc-199">This is used to lookup provider specific Id. E.g.</span></span> <span data-ttu-id="9e5fc-200">Netflix Id または Hulu id。</span><span class="sxs-lookup"><span data-stu-id="9e5fc-200">Netflix Id or Hulu Id.</span></span>
 
<span data-ttu-id="9e5fc-201">IdType ProviderContentId がある場合は、1 つの値のみが受け入れられます。</span><span class="sxs-lookup"><span data-stu-id="9e5fc-201">When idType is ProviderContentId, only a single value is accepted.</span></span> <span data-ttu-id="9e5fc-202">これは、ProviderContentIds は種類の ID が含まれるだけであるため、'.' 文字です。</span><span class="sxs-lookup"><span data-stu-id="9e5fc-202">This is because ProviderContentIds are the only type of ID that can contain the '.' character.</span></span> <span data-ttu-id="9e5fc-203">'.' 文字もする Id 間の区切り文字は Id 間 delimieter 間にあいまいさが、新機能自体 ID の一部です。</span><span class="sxs-lookup"><span data-stu-id="9e5fc-203">Since the '.' character is also the separator that we use between IDs, there's ambiguity between what's a delimieter between IDs and what's part of the ID itself.</span></span> <span data-ttu-id="9e5fc-204">API の残りの部分一括検索機能を除く、ProviderContentIds の同じように動作します。</span><span class="sxs-lookup"><span data-stu-id="9e5fc-204">The rest of the API works the same way for ProviderContentIds, except for the bulk lookup functionality.</span></span>
   
<a id="ID4EUH"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="9e5fc-205">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9e5fc-205">URI parameters</span></span>
 
| <span data-ttu-id="9e5fc-206">パラメーター</span><span class="sxs-lookup"><span data-stu-id="9e5fc-206">Parameter</span></span>| <span data-ttu-id="9e5fc-207">型</span><span class="sxs-lookup"><span data-stu-id="9e5fc-207">Type</span></span>| <span data-ttu-id="9e5fc-208">説明</span><span class="sxs-lookup"><span data-stu-id="9e5fc-208">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="9e5fc-209">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="9e5fc-209">marketplaceId</span></span>| <span data-ttu-id="9e5fc-210">string</span><span class="sxs-lookup"><span data-stu-id="9e5fc-210">string</span></span>| <span data-ttu-id="9e5fc-211">必須。</span><span class="sxs-lookup"><span data-stu-id="9e5fc-211">Required.</span></span> <span data-ttu-id="9e5fc-212"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="9e5fc-212">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EWAAC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="9e5fc-213">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="9e5fc-213">Valid methods</span></span>

[<span data-ttu-id="9e5fc-214">GET (/media/{marketplaceId}/details)</span><span class="sxs-lookup"><span data-stu-id="9e5fc-214">GET (/media/{marketplaceId}/details)</span></span>](uri-medialocaledetailsget.md)

<span data-ttu-id="9e5fc-215">&nbsp;&nbsp;返しますプランの詳細とメタデータについての 1 つまたは複数の項目。</span><span class="sxs-lookup"><span data-stu-id="9e5fc-215">&nbsp;&nbsp;Returns offer details and metadata about one or more items.</span></span> 
 
<a id="ID4EABAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="9e5fc-216">関連項目</span><span class="sxs-lookup"><span data-stu-id="9e5fc-216">See also</span></span>
 
<a id="ID4ECBAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="9e5fc-217">Parent</span><span class="sxs-lookup"><span data-stu-id="9e5fc-217">Parent</span></span> 

[<span data-ttu-id="9e5fc-218">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="9e5fc-218">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EMBAC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="9e5fc-219">詳細情報</span><span class="sxs-lookup"><span data-stu-id="9e5fc-219">Further Information</span></span> 

[<span data-ttu-id="9e5fc-220">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9e5fc-220">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="9e5fc-221">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="9e5fc-221">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="9e5fc-222">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="9e5fc-222">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="9e5fc-223">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="9e5fc-223">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   