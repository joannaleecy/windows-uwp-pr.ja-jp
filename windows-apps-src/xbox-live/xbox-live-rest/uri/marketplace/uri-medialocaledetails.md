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
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4680865"
---
# <a name="mediamarketplaceiddetails"></a><span data-ttu-id="8ca1b-104">/media/{marketplaceId}/details</span><span class="sxs-lookup"><span data-stu-id="8ca1b-104">/media/{marketplaceId}/details</span></span>
<span data-ttu-id="8ca1b-105">返しますの詳細とメタデータを提供する方法の 1 つまたは複数の項目。</span><span class="sxs-lookup"><span data-stu-id="8ca1b-105">Returns offer details and metadata about one or more items.</span></span> <span data-ttu-id="8ca1b-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="8ca1b-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
<span data-ttu-id="8ca1b-107">API は、関連する API と参照 API によって異なります詳細 (とき、ID で passin) 詳細 API には、追加の情報が返されますが、それらの Api は、暗黙的または明示的に fiven ID に関連付けられているその他の項目に関する情報を返すよう。同じ項目。</span><span class="sxs-lookup"><span data-stu-id="8ca1b-107">The details API differs from the Related API and the Browse API (when passin in an ID) as those APIs return information about other items that are associated with the fiven ID, either explicitly or implicitly, whereas the details API returns additional information about the same item.</span></span>
 
<span data-ttu-id="8ca1b-108">別のメディア項目の種類の複数の Id は、1 つに渡すことができます (だけの時間とは違う型 ProviderContentID - 以下を参照してください)、呼び出しが同じメディア グループに属するすべてする必要があります。</span><span class="sxs-lookup"><span data-stu-id="8ca1b-108">Multiple IDs of different media item types can be passed into a single call (as long as they're not of type ProviderContentID - see below), but they all must belong to the same media group.</span></span> <span data-ttu-id="8ca1b-109">ただし、これには、呼び出し元がメディアのグループを認識しないクライアントのシナリオのいくつかがあります。</span><span class="sxs-lookup"><span data-stu-id="8ca1b-109">However, there are a couple of client scenarios where the caller doesn't know the media group.</span></span> <span data-ttu-id="8ca1b-110">API では、これを使用して、次のような状況でのメディアのグループには、"Unknown"の特殊値のことを許可します。</span><span class="sxs-lookup"><span data-stu-id="8ca1b-110">The API supports this by allowing a sepcial value of "Unknown" for the media group in the following situations:</span></span>
 
   * <span data-ttu-id="8ca1b-111">idType = XboxHexTitle、AppType またはゲームの種類のいずれかの項目を生成します。</span><span class="sxs-lookup"><span data-stu-id="8ca1b-111">idType = XboxHexTitle, which will yield either AppType or GameType items</span></span>
   * <span data-ttu-id="8ca1b-112">idType = ProviderContentId で、MovieType または TVType 項目が生成されます</span><span class="sxs-lookup"><span data-stu-id="8ca1b-112">idType = ProviderContentId, which will yield MovieType or TVType items</span></span>
  
<span data-ttu-id="8ca1b-113">次の図は、どのメディア グループと ID の種類を指定できます全体のマッピングをまとめたものです。</span><span class="sxs-lookup"><span data-stu-id="8ca1b-113">The following chart summarizes the entire mapping of which ID types can be provided with which media groups:</span></span>
 
| <span data-ttu-id="8ca1b-114">ID の種類</span><span class="sxs-lookup"><span data-stu-id="8ca1b-114">ID Type</span></span>| <span data-ttu-id="8ca1b-115">AppType</span><span class="sxs-lookup"><span data-stu-id="8ca1b-115">AppType</span></span>| <span data-ttu-id="8ca1b-116">ゲームの種類</span><span class="sxs-lookup"><span data-stu-id="8ca1b-116">GameType</span></span>| <span data-ttu-id="8ca1b-117">MovieType</span><span class="sxs-lookup"><span data-stu-id="8ca1b-117">MovieType</span></span>| <span data-ttu-id="8ca1b-118">MusicArtistType</span><span class="sxs-lookup"><span data-stu-id="8ca1b-118">MusicArtistType</span></span>| <span data-ttu-id="8ca1b-119">MusicType</span><span class="sxs-lookup"><span data-stu-id="8ca1b-119">MusicType</span></span>| <span data-ttu-id="8ca1b-120">TVType</span><span class="sxs-lookup"><span data-stu-id="8ca1b-120">TVType</span></span>| <span data-ttu-id="8ca1b-121">WebVideoType</span><span class="sxs-lookup"><span data-stu-id="8ca1b-121">WebVideoType</span></span>| <span data-ttu-id="8ca1b-122">Unknown</span><span class="sxs-lookup"><span data-stu-id="8ca1b-122">Unknown</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="8ca1b-123">正規</span><span class="sxs-lookup"><span data-stu-id="8ca1b-123">Canonical</span></span>| <span data-ttu-id="8ca1b-124">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-124">Y</span></span>| <span data-ttu-id="8ca1b-125">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-125">Y</span></span>| <span data-ttu-id="8ca1b-126">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-126">Y</span></span>| <span data-ttu-id="8ca1b-127">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-127">Y</span></span>| <span data-ttu-id="8ca1b-128">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-128">Y</span></span>| <span data-ttu-id="8ca1b-129">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-129">Y</span></span>| <span data-ttu-id="8ca1b-130">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-130">Y</span></span>| <span data-ttu-id="8ca1b-131">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-131">N</span></span>| 
| <span data-ttu-id="8ca1b-132">ZuneCatalog</span><span class="sxs-lookup"><span data-stu-id="8ca1b-132">ZuneCatalog</span></span>| <span data-ttu-id="8ca1b-133">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-133">N</span></span>| <span data-ttu-id="8ca1b-134">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-134">N</span></span>| <span data-ttu-id="8ca1b-135">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-135">Y</span></span>| <span data-ttu-id="8ca1b-136">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-136">Y</span></span>| <span data-ttu-id="8ca1b-137">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-137">Y</span></span>| <span data-ttu-id="8ca1b-138">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-138">Y</span></span>| <span data-ttu-id="8ca1b-139">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-139">N</span></span>| <span data-ttu-id="8ca1b-140">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-140">N</span></span>| 
| <span data-ttu-id="8ca1b-141">ZuneMediaInstance</span><span class="sxs-lookup"><span data-stu-id="8ca1b-141">ZuneMediaInstance</span></span>| <span data-ttu-id="8ca1b-142">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-142">N</span></span>| <span data-ttu-id="8ca1b-143">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-143">N</span></span>| <span data-ttu-id="8ca1b-144">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-144">Y</span></span>| <span data-ttu-id="8ca1b-145">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-145">N</span></span>| <span data-ttu-id="8ca1b-146">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-146">Y</span></span>| <span data-ttu-id="8ca1b-147">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-147">Y</span></span>| <span data-ttu-id="8ca1b-148">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-148">N</span></span>| <span data-ttu-id="8ca1b-149">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-149">N</span></span>| 
| <span data-ttu-id="8ca1b-150">提案</span><span class="sxs-lookup"><span data-stu-id="8ca1b-150">Offer</span></span>| <span data-ttu-id="8ca1b-151">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-151">Y</span></span>| <span data-ttu-id="8ca1b-152">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-152">Y</span></span>| <span data-ttu-id="8ca1b-153">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-153">Y</span></span>| <span data-ttu-id="8ca1b-154">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-154">N</span></span>| <span data-ttu-id="8ca1b-155">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-155">Y</span></span>| <span data-ttu-id="8ca1b-156">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-156">Y</span></span>| <span data-ttu-id="8ca1b-157">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-157">N</span></span>| <span data-ttu-id="8ca1b-158">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-158">N</span></span>| 
| <span data-ttu-id="8ca1b-159">AMG</span><span class="sxs-lookup"><span data-stu-id="8ca1b-159">AMG</span></span>| <span data-ttu-id="8ca1b-160">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-160">N</span></span>| <span data-ttu-id="8ca1b-161">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-161">N</span></span>| <span data-ttu-id="8ca1b-162">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-162">N</span></span>| <span data-ttu-id="8ca1b-163">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-163">N</span></span>| <span data-ttu-id="8ca1b-164">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-164">Y</span></span>| <span data-ttu-id="8ca1b-165">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-165">N</span></span>| <span data-ttu-id="8ca1b-166">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-166">N</span></span>| <span data-ttu-id="8ca1b-167">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-167">N</span></span>| 
| <span data-ttu-id="8ca1b-168">MediaNet</span><span class="sxs-lookup"><span data-stu-id="8ca1b-168">MediaNet</span></span>| <span data-ttu-id="8ca1b-169">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-169">N</span></span>| <span data-ttu-id="8ca1b-170">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-170">N</span></span>| <span data-ttu-id="8ca1b-171">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-171">N</span></span>| <span data-ttu-id="8ca1b-172">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-172">N</span></span>| <span data-ttu-id="8ca1b-173">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-173">Y</span></span>| <span data-ttu-id="8ca1b-174">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-174">N</span></span>| <span data-ttu-id="8ca1b-175">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-175">N</span></span>| <span data-ttu-id="8ca1b-176">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-176">N</span></span>| 
| <span data-ttu-id="8ca1b-177">XboxHexTitle</span><span class="sxs-lookup"><span data-stu-id="8ca1b-177">XboxHexTitle</span></span>| <span data-ttu-id="8ca1b-178">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-178">Y</span></span>| <span data-ttu-id="8ca1b-179">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-179">Y</span></span>| <span data-ttu-id="8ca1b-180">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-180">N</span></span>| <span data-ttu-id="8ca1b-181">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-181">N</span></span>| <span data-ttu-id="8ca1b-182">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-182">N</span></span>| <span data-ttu-id="8ca1b-183">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-183">N</span></span>| <span data-ttu-id="8ca1b-184">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-184">N</span></span>| <span data-ttu-id="8ca1b-185">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-185">Y</span></span>| 
| <span data-ttu-id="8ca1b-186">ProviderContentId</span><span class="sxs-lookup"><span data-stu-id="8ca1b-186">ProviderContentId</span></span>| <span data-ttu-id="8ca1b-187">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-187">N</span></span>| <span data-ttu-id="8ca1b-188">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-188">N</span></span>| <span data-ttu-id="8ca1b-189">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-189">Y</span></span>| <span data-ttu-id="8ca1b-190">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-190">N</span></span>| <span data-ttu-id="8ca1b-191">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-191">N</span></span>| <span data-ttu-id="8ca1b-192">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-192">Y</span></span>| <span data-ttu-id="8ca1b-193">N</span><span class="sxs-lookup"><span data-stu-id="8ca1b-193">N</span></span>| <span data-ttu-id="8ca1b-194">Y</span><span class="sxs-lookup"><span data-stu-id="8ca1b-194">Y</span></span>| 
 
  * [<span data-ttu-id="8ca1b-195">パラメーターの注意事項</span><span class="sxs-lookup"><span data-stu-id="8ca1b-195">Parameter Notes</span></span>](#ID4EEH)
  * [<span data-ttu-id="8ca1b-196">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8ca1b-196">URI parameters</span></span>](#ID4EUH)
 
<a id="ID4EEH"></a>

 
## <a name="parameter-notes"></a><span data-ttu-id="8ca1b-197">パラメーターの注意事項</span><span class="sxs-lookup"><span data-stu-id="8ca1b-197">Parameter Notes</span></span>
 
<a id="ID4EIH"></a>

 
### <a name="providercontentid"></a><span data-ttu-id="8ca1b-198">ProviderContentId</span><span class="sxs-lookup"><span data-stu-id="8ca1b-198">ProviderContentId</span></span>
 
<span data-ttu-id="8ca1b-199">これは、検索プロバイダーを使用特定 id。 例。</span><span class="sxs-lookup"><span data-stu-id="8ca1b-199">This is used to lookup provider specific Id. E.g.</span></span> <span data-ttu-id="8ca1b-200">Netflix Id または Hulu id。</span><span class="sxs-lookup"><span data-stu-id="8ca1b-200">Netflix Id or Hulu Id.</span></span>
 
<span data-ttu-id="8ca1b-201">IdType ProviderContentId がある場合は、1 つの値のみが受け入れられます。</span><span class="sxs-lookup"><span data-stu-id="8ca1b-201">When idType is ProviderContentId, only a single value is accepted.</span></span> <span data-ttu-id="8ca1b-202">これは、ProviderContentIds は種類の ID が含まれるだけであるため、'.' 文字です。</span><span class="sxs-lookup"><span data-stu-id="8ca1b-202">This is because ProviderContentIds are the only type of ID that can contain the '.' character.</span></span> <span data-ttu-id="8ca1b-203">'.' 文字もする Id 間の区切り文字は Id 間 delimieter 間にあいまいさが、新機能自体 ID の一部です。</span><span class="sxs-lookup"><span data-stu-id="8ca1b-203">Since the '.' character is also the separator that we use between IDs, there's ambiguity between what's a delimieter between IDs and what's part of the ID itself.</span></span> <span data-ttu-id="8ca1b-204">API の残りの部分一括検索機能を除く、ProviderContentIds の同じように動作します。</span><span class="sxs-lookup"><span data-stu-id="8ca1b-204">The rest of the API works the same way for ProviderContentIds, except for the bulk lookup functionality.</span></span>
   
<a id="ID4EUH"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="8ca1b-205">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8ca1b-205">URI parameters</span></span>
 
| <span data-ttu-id="8ca1b-206">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8ca1b-206">Parameter</span></span>| <span data-ttu-id="8ca1b-207">型</span><span class="sxs-lookup"><span data-stu-id="8ca1b-207">Type</span></span>| <span data-ttu-id="8ca1b-208">説明</span><span class="sxs-lookup"><span data-stu-id="8ca1b-208">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="8ca1b-209">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="8ca1b-209">marketplaceId</span></span>| <span data-ttu-id="8ca1b-210">string</span><span class="sxs-lookup"><span data-stu-id="8ca1b-210">string</span></span>| <span data-ttu-id="8ca1b-211">必須。</span><span class="sxs-lookup"><span data-stu-id="8ca1b-211">Required.</span></span> <span data-ttu-id="8ca1b-212">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="8ca1b-212">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EWAAC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="8ca1b-213">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="8ca1b-213">Valid methods</span></span>

[<span data-ttu-id="8ca1b-214">GET (/media/{marketplaceId}/details)</span><span class="sxs-lookup"><span data-stu-id="8ca1b-214">GET (/media/{marketplaceId}/details)</span></span>](uri-medialocaledetailsget.md)

<span data-ttu-id="8ca1b-215">&nbsp;&nbsp;返しますの詳細とメタデータを提供する方法の 1 つまたは複数の項目。</span><span class="sxs-lookup"><span data-stu-id="8ca1b-215">&nbsp;&nbsp;Returns offer details and metadata about one or more items.</span></span> 
 
<a id="ID4EABAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="8ca1b-216">関連項目</span><span class="sxs-lookup"><span data-stu-id="8ca1b-216">See also</span></span>
 
<a id="ID4ECBAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="8ca1b-217">Parent</span><span class="sxs-lookup"><span data-stu-id="8ca1b-217">Parent</span></span> 

[<span data-ttu-id="8ca1b-218">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="8ca1b-218">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EMBAC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="8ca1b-219">詳細情報</span><span class="sxs-lookup"><span data-stu-id="8ca1b-219">Further Information</span></span> 

[<span data-ttu-id="8ca1b-220">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8ca1b-220">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="8ca1b-221">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="8ca1b-221">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="8ca1b-222">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="8ca1b-222">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="8ca1b-223">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="8ca1b-223">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   