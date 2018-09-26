---
title: /media/{marketplaceId}/details
assetID: bc8758ed-2f90-b501-5c3f-6f253f02d754
permalink: en-us/docs/xboxlive/rest/uri-medialocaledetails.html
author: KevinAsgari
description: " /media/{marketplaceId}/details"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7b8dcea7c0987a2bc783adae0398c9579ded2fe8
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4176708"
---
# <a name="mediamarketplaceiddetails"></a><span data-ttu-id="e9820-104">/media/{marketplaceId}/details</span><span class="sxs-lookup"><span data-stu-id="e9820-104">/media/{marketplaceId}/details</span></span>
<span data-ttu-id="e9820-105">返しますプランの詳細とメタデータについての 1 つまたは複数の項目です。</span><span class="sxs-lookup"><span data-stu-id="e9820-105">Returns offer details and metadata about one or more items.</span></span> <span data-ttu-id="e9820-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="e9820-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
<span data-ttu-id="e9820-107">API は、関連する API と参照 API によって異なります詳細 (とき、ID で passin) 詳細 API には、追加の情報が返されますが、それらの Api は、暗黙的または明示的に fiven ID に関連付けられているその他の項目に関する情報を返すよう。同じ項目。</span><span class="sxs-lookup"><span data-stu-id="e9820-107">The details API differs from the Related API and the Browse API (when passin in an ID) as those APIs return information about other items that are associated with the fiven ID, either explicitly or implicitly, whereas the details API returns additional information about the same item.</span></span>
 
<span data-ttu-id="e9820-108">別のメディア項目の種類の複数の Id は、1 つに渡すことができます (限り ProviderContentID - 以下を参照型のわからない)、呼び出しが同じメディア グループに属するすべてする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e9820-108">Multiple IDs of different media item types can be passed into a single call (as long as they're not of type ProviderContentID - see below), but they all must belong to the same media group.</span></span> <span data-ttu-id="e9820-109">ただし、これには、呼び出し元がメディアのグループを認識しないクライアントのシナリオのいくつかがあります。</span><span class="sxs-lookup"><span data-stu-id="e9820-109">However, there are a couple of client scenarios where the caller doesn't know the media group.</span></span> <span data-ttu-id="e9820-110">API では、これを使用して、次のような状況でのメディアのグループには、"Unknown"の特殊値のことを許可します。</span><span class="sxs-lookup"><span data-stu-id="e9820-110">The API supports this by allowing a sepcial value of "Unknown" for the media group in the following situations:</span></span>
 
   * <span data-ttu-id="e9820-111">idType = XboxHexTitle で、AppType またはゲームの種類のいずれかの項目が生成されます</span><span class="sxs-lookup"><span data-stu-id="e9820-111">idType = XboxHexTitle, which will yield either AppType or GameType items</span></span>
   * <span data-ttu-id="e9820-112">idType = ProviderContentId で、MovieType または TVType 項目が生成されます</span><span class="sxs-lookup"><span data-stu-id="e9820-112">idType = ProviderContentId, which will yield MovieType or TVType items</span></span>
  
<span data-ttu-id="e9820-113">次の図は、どのメディア グループと ID の種類を指定できます全体のマッピングをまとめたものです。</span><span class="sxs-lookup"><span data-stu-id="e9820-113">The following chart summarizes the entire mapping of which ID types can be provided with which media groups:</span></span>
 
| <span data-ttu-id="e9820-114">ID の種類</span><span class="sxs-lookup"><span data-stu-id="e9820-114">ID Type</span></span>| <span data-ttu-id="e9820-115">AppType</span><span class="sxs-lookup"><span data-stu-id="e9820-115">AppType</span></span>| <span data-ttu-id="e9820-116">ゲームの種類</span><span class="sxs-lookup"><span data-stu-id="e9820-116">GameType</span></span>| <span data-ttu-id="e9820-117">MovieType</span><span class="sxs-lookup"><span data-stu-id="e9820-117">MovieType</span></span>| <span data-ttu-id="e9820-118">MusicArtistType</span><span class="sxs-lookup"><span data-stu-id="e9820-118">MusicArtistType</span></span>| <span data-ttu-id="e9820-119">MusicType</span><span class="sxs-lookup"><span data-stu-id="e9820-119">MusicType</span></span>| <span data-ttu-id="e9820-120">TVType</span><span class="sxs-lookup"><span data-stu-id="e9820-120">TVType</span></span>| <span data-ttu-id="e9820-121">WebVideoType</span><span class="sxs-lookup"><span data-stu-id="e9820-121">WebVideoType</span></span>| <span data-ttu-id="e9820-122">Unknown</span><span class="sxs-lookup"><span data-stu-id="e9820-122">Unknown</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e9820-123">正規</span><span class="sxs-lookup"><span data-stu-id="e9820-123">Canonical</span></span>| <span data-ttu-id="e9820-124">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-124">Y</span></span>| <span data-ttu-id="e9820-125">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-125">Y</span></span>| <span data-ttu-id="e9820-126">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-126">Y</span></span>| <span data-ttu-id="e9820-127">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-127">Y</span></span>| <span data-ttu-id="e9820-128">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-128">Y</span></span>| <span data-ttu-id="e9820-129">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-129">Y</span></span>| <span data-ttu-id="e9820-130">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-130">Y</span></span>| <span data-ttu-id="e9820-131">N</span><span class="sxs-lookup"><span data-stu-id="e9820-131">N</span></span>| 
| <span data-ttu-id="e9820-132">ZuneCatalog</span><span class="sxs-lookup"><span data-stu-id="e9820-132">ZuneCatalog</span></span>| <span data-ttu-id="e9820-133">N</span><span class="sxs-lookup"><span data-stu-id="e9820-133">N</span></span>| <span data-ttu-id="e9820-134">N</span><span class="sxs-lookup"><span data-stu-id="e9820-134">N</span></span>| <span data-ttu-id="e9820-135">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-135">Y</span></span>| <span data-ttu-id="e9820-136">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-136">Y</span></span>| <span data-ttu-id="e9820-137">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-137">Y</span></span>| <span data-ttu-id="e9820-138">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-138">Y</span></span>| <span data-ttu-id="e9820-139">N</span><span class="sxs-lookup"><span data-stu-id="e9820-139">N</span></span>| <span data-ttu-id="e9820-140">N</span><span class="sxs-lookup"><span data-stu-id="e9820-140">N</span></span>| 
| <span data-ttu-id="e9820-141">ZuneMediaInstance</span><span class="sxs-lookup"><span data-stu-id="e9820-141">ZuneMediaInstance</span></span>| <span data-ttu-id="e9820-142">N</span><span class="sxs-lookup"><span data-stu-id="e9820-142">N</span></span>| <span data-ttu-id="e9820-143">N</span><span class="sxs-lookup"><span data-stu-id="e9820-143">N</span></span>| <span data-ttu-id="e9820-144">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-144">Y</span></span>| <span data-ttu-id="e9820-145">N</span><span class="sxs-lookup"><span data-stu-id="e9820-145">N</span></span>| <span data-ttu-id="e9820-146">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-146">Y</span></span>| <span data-ttu-id="e9820-147">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-147">Y</span></span>| <span data-ttu-id="e9820-148">N</span><span class="sxs-lookup"><span data-stu-id="e9820-148">N</span></span>| <span data-ttu-id="e9820-149">N</span><span class="sxs-lookup"><span data-stu-id="e9820-149">N</span></span>| 
| <span data-ttu-id="e9820-150">提案</span><span class="sxs-lookup"><span data-stu-id="e9820-150">Offer</span></span>| <span data-ttu-id="e9820-151">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-151">Y</span></span>| <span data-ttu-id="e9820-152">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-152">Y</span></span>| <span data-ttu-id="e9820-153">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-153">Y</span></span>| <span data-ttu-id="e9820-154">N</span><span class="sxs-lookup"><span data-stu-id="e9820-154">N</span></span>| <span data-ttu-id="e9820-155">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-155">Y</span></span>| <span data-ttu-id="e9820-156">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-156">Y</span></span>| <span data-ttu-id="e9820-157">N</span><span class="sxs-lookup"><span data-stu-id="e9820-157">N</span></span>| <span data-ttu-id="e9820-158">N</span><span class="sxs-lookup"><span data-stu-id="e9820-158">N</span></span>| 
| <span data-ttu-id="e9820-159">AMG</span><span class="sxs-lookup"><span data-stu-id="e9820-159">AMG</span></span>| <span data-ttu-id="e9820-160">N</span><span class="sxs-lookup"><span data-stu-id="e9820-160">N</span></span>| <span data-ttu-id="e9820-161">N</span><span class="sxs-lookup"><span data-stu-id="e9820-161">N</span></span>| <span data-ttu-id="e9820-162">N</span><span class="sxs-lookup"><span data-stu-id="e9820-162">N</span></span>| <span data-ttu-id="e9820-163">N</span><span class="sxs-lookup"><span data-stu-id="e9820-163">N</span></span>| <span data-ttu-id="e9820-164">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-164">Y</span></span>| <span data-ttu-id="e9820-165">N</span><span class="sxs-lookup"><span data-stu-id="e9820-165">N</span></span>| <span data-ttu-id="e9820-166">N</span><span class="sxs-lookup"><span data-stu-id="e9820-166">N</span></span>| <span data-ttu-id="e9820-167">N</span><span class="sxs-lookup"><span data-stu-id="e9820-167">N</span></span>| 
| <span data-ttu-id="e9820-168">MediaNet</span><span class="sxs-lookup"><span data-stu-id="e9820-168">MediaNet</span></span>| <span data-ttu-id="e9820-169">N</span><span class="sxs-lookup"><span data-stu-id="e9820-169">N</span></span>| <span data-ttu-id="e9820-170">N</span><span class="sxs-lookup"><span data-stu-id="e9820-170">N</span></span>| <span data-ttu-id="e9820-171">N</span><span class="sxs-lookup"><span data-stu-id="e9820-171">N</span></span>| <span data-ttu-id="e9820-172">N</span><span class="sxs-lookup"><span data-stu-id="e9820-172">N</span></span>| <span data-ttu-id="e9820-173">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-173">Y</span></span>| <span data-ttu-id="e9820-174">N</span><span class="sxs-lookup"><span data-stu-id="e9820-174">N</span></span>| <span data-ttu-id="e9820-175">N</span><span class="sxs-lookup"><span data-stu-id="e9820-175">N</span></span>| <span data-ttu-id="e9820-176">N</span><span class="sxs-lookup"><span data-stu-id="e9820-176">N</span></span>| 
| <span data-ttu-id="e9820-177">XboxHexTitle</span><span class="sxs-lookup"><span data-stu-id="e9820-177">XboxHexTitle</span></span>| <span data-ttu-id="e9820-178">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-178">Y</span></span>| <span data-ttu-id="e9820-179">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-179">Y</span></span>| <span data-ttu-id="e9820-180">N</span><span class="sxs-lookup"><span data-stu-id="e9820-180">N</span></span>| <span data-ttu-id="e9820-181">N</span><span class="sxs-lookup"><span data-stu-id="e9820-181">N</span></span>| <span data-ttu-id="e9820-182">N</span><span class="sxs-lookup"><span data-stu-id="e9820-182">N</span></span>| <span data-ttu-id="e9820-183">N</span><span class="sxs-lookup"><span data-stu-id="e9820-183">N</span></span>| <span data-ttu-id="e9820-184">N</span><span class="sxs-lookup"><span data-stu-id="e9820-184">N</span></span>| <span data-ttu-id="e9820-185">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-185">Y</span></span>| 
| <span data-ttu-id="e9820-186">ProviderContentId</span><span class="sxs-lookup"><span data-stu-id="e9820-186">ProviderContentId</span></span>| <span data-ttu-id="e9820-187">N</span><span class="sxs-lookup"><span data-stu-id="e9820-187">N</span></span>| <span data-ttu-id="e9820-188">N</span><span class="sxs-lookup"><span data-stu-id="e9820-188">N</span></span>| <span data-ttu-id="e9820-189">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-189">Y</span></span>| <span data-ttu-id="e9820-190">N</span><span class="sxs-lookup"><span data-stu-id="e9820-190">N</span></span>| <span data-ttu-id="e9820-191">N</span><span class="sxs-lookup"><span data-stu-id="e9820-191">N</span></span>| <span data-ttu-id="e9820-192">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-192">Y</span></span>| <span data-ttu-id="e9820-193">N</span><span class="sxs-lookup"><span data-stu-id="e9820-193">N</span></span>| <span data-ttu-id="e9820-194">Y</span><span class="sxs-lookup"><span data-stu-id="e9820-194">Y</span></span>| 
 
  * [<span data-ttu-id="e9820-195">パラメーターの注意事項</span><span class="sxs-lookup"><span data-stu-id="e9820-195">Parameter Notes</span></span>](#ID4EEH)
  * [<span data-ttu-id="e9820-196">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e9820-196">URI parameters</span></span>](#ID4EUH)
 
<a id="ID4EEH"></a>

 
## <a name="parameter-notes"></a><span data-ttu-id="e9820-197">パラメーターの注意事項</span><span class="sxs-lookup"><span data-stu-id="e9820-197">Parameter Notes</span></span>
 
<a id="ID4EIH"></a>

 
### <a name="providercontentid"></a><span data-ttu-id="e9820-198">ProviderContentId</span><span class="sxs-lookup"><span data-stu-id="e9820-198">ProviderContentId</span></span>
 
<span data-ttu-id="e9820-199">これは、検索プロバイダーを使用特定 id。 例。</span><span class="sxs-lookup"><span data-stu-id="e9820-199">This is used to lookup provider specific Id. E.g.</span></span> <span data-ttu-id="e9820-200">Netflix Id または Hulu id。</span><span class="sxs-lookup"><span data-stu-id="e9820-200">Netflix Id or Hulu Id.</span></span>
 
<span data-ttu-id="e9820-201">IdType ProviderContentId がある場合は、1 つの値のみが受け入れられます。</span><span class="sxs-lookup"><span data-stu-id="e9820-201">When idType is ProviderContentId, only a single value is accepted.</span></span> <span data-ttu-id="e9820-202">これは、ProviderContentIds は種類の ID が含まれるだけであるため、'.' 文字です。</span><span class="sxs-lookup"><span data-stu-id="e9820-202">This is because ProviderContentIds are the only type of ID that can contain the '.' character.</span></span> <span data-ttu-id="e9820-203">'.' 文字は使用 Id 間の区切り文字でも、新機能の Id の間で delimieter の間にあいまいさがおよび ID 自体の一部は何です。</span><span class="sxs-lookup"><span data-stu-id="e9820-203">Since the '.' character is also the separator that we use between IDs, there's ambiguity between what's a delimieter between IDs and what's part of the ID itself.</span></span> <span data-ttu-id="e9820-204">API の残りの部分一括検索機能を除く、ProviderContentIds の同じように動作します。</span><span class="sxs-lookup"><span data-stu-id="e9820-204">The rest of the API works the same way for ProviderContentIds, except for the bulk lookup functionality.</span></span>
   
<a id="ID4EUH"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="e9820-205">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e9820-205">URI parameters</span></span>
 
| <span data-ttu-id="e9820-206">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e9820-206">Parameter</span></span>| <span data-ttu-id="e9820-207">型</span><span class="sxs-lookup"><span data-stu-id="e9820-207">Type</span></span>| <span data-ttu-id="e9820-208">説明</span><span class="sxs-lookup"><span data-stu-id="e9820-208">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e9820-209">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="e9820-209">marketplaceId</span></span>| <span data-ttu-id="e9820-210">string</span><span class="sxs-lookup"><span data-stu-id="e9820-210">string</span></span>| <span data-ttu-id="e9820-211">必須。</span><span class="sxs-lookup"><span data-stu-id="e9820-211">Required.</span></span> <span data-ttu-id="e9820-212">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="e9820-212">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EWAAC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="e9820-213">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="e9820-213">Valid methods</span></span>

[<span data-ttu-id="e9820-214">GET (/media/{marketplaceId}/details)</span><span class="sxs-lookup"><span data-stu-id="e9820-214">GET (/media/{marketplaceId}/details)</span></span>](uri-medialocaledetailsget.md)

<span data-ttu-id="e9820-215">&nbsp;&nbsp;返しますプランの詳細とメタデータについての 1 つまたは複数の項目です。</span><span class="sxs-lookup"><span data-stu-id="e9820-215">&nbsp;&nbsp;Returns offer details and metadata about one or more items.</span></span> 
 
<a id="ID4EABAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="e9820-216">関連項目</span><span class="sxs-lookup"><span data-stu-id="e9820-216">See also</span></span>
 
<a id="ID4ECBAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="e9820-217">Parent</span><span class="sxs-lookup"><span data-stu-id="e9820-217">Parent</span></span> 

[<span data-ttu-id="e9820-218">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="e9820-218">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EMBAC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="e9820-219">詳細情報</span><span class="sxs-lookup"><span data-stu-id="e9820-219">Further Information</span></span> 

[<span data-ttu-id="e9820-220">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e9820-220">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="e9820-221">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="e9820-221">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="e9820-222">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="e9820-222">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="e9820-223">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="e9820-223">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   