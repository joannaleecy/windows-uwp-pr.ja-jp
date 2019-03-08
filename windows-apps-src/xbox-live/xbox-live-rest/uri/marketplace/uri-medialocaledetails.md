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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655707"
---
# <a name="mediamarketplaceiddetails"></a><span data-ttu-id="ac533-104">/media/{marketplaceId}/details</span><span class="sxs-lookup"><span data-stu-id="ac533-104">/media/{marketplaceId}/details</span></span>
<span data-ttu-id="ac533-105">プランの詳細、メタデータを返しますについて 1 つまたは複数の項目。</span><span class="sxs-lookup"><span data-stu-id="ac533-105">Returns offer details and metadata about one or more items.</span></span> <span data-ttu-id="ac533-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="ac533-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
<span data-ttu-id="ac533-107">API は、関連する API と参照 API によって異なります詳細 (と ID で passin) 詳細 API には、追加情報が返されますが、これらの Api が明示的または暗黙的に、fiven ID に関連付けられているその他の項目に関する情報を返すよう。同じ項目。</span><span class="sxs-lookup"><span data-stu-id="ac533-107">The details API differs from the Related API and the Browse API (when passin in an ID) as those APIs return information about other items that are associated with the fiven ID, either explicitly or implicitly, whereas the details API returns additional information about the same item.</span></span>
 
<span data-ttu-id="ac533-108">1 つに、別のメディア項目の種類の複数の Id を渡すことができます (限り ProviderContentID - 以下を参照型のない)、呼び出しが同じメディア グループに属している必要がありますすべて。</span><span class="sxs-lookup"><span data-stu-id="ac533-108">Multiple IDs of different media item types can be passed into a single call (as long as they're not of type ProviderContentID - see below), but they all must belong to the same media group.</span></span> <span data-ttu-id="ac533-109">ただし、呼び出し元がメディアのグループを認識しないクライアント シナリオをいくつかがあります。</span><span class="sxs-lookup"><span data-stu-id="ac533-109">However, there are a couple of client scenarios where the caller doesn't know the media group.</span></span> <span data-ttu-id="ac533-110">API は、media group の「不明」の次の状況での特殊値を許可することでこれをサポートします。</span><span class="sxs-lookup"><span data-stu-id="ac533-110">The API supports this by allowing a sepcial value of "Unknown" for the media group in the following situations:</span></span>
 
   * <span data-ttu-id="ac533-111">idType = XboxHexTitle、AppType またはゲームの種類のいずれかの項目が得られます</span><span class="sxs-lookup"><span data-stu-id="ac533-111">idType = XboxHexTitle, which will yield either AppType or GameType items</span></span>
   * <span data-ttu-id="ac533-112">idType = ProviderContentId、MovieType または TVType 項目が得られます</span><span class="sxs-lookup"><span data-stu-id="ac533-112">idType = ProviderContentId, which will yield MovieType or TVType items</span></span>
  
<span data-ttu-id="ac533-113">次の図は、ID の型に提供できるメディア グループ全体のマッピングをまとめたものです。</span><span class="sxs-lookup"><span data-stu-id="ac533-113">The following chart summarizes the entire mapping of which ID types can be provided with which media groups:</span></span>
 
| <span data-ttu-id="ac533-114">ID の種類</span><span class="sxs-lookup"><span data-stu-id="ac533-114">ID Type</span></span>| <span data-ttu-id="ac533-115">appType</span><span class="sxs-lookup"><span data-stu-id="ac533-115">AppType</span></span>| <span data-ttu-id="ac533-116">ゲームの種類</span><span class="sxs-lookup"><span data-stu-id="ac533-116">GameType</span></span>| <span data-ttu-id="ac533-117">MovieType</span><span class="sxs-lookup"><span data-stu-id="ac533-117">MovieType</span></span>| <span data-ttu-id="ac533-118">MusicArtistType</span><span class="sxs-lookup"><span data-stu-id="ac533-118">MusicArtistType</span></span>| <span data-ttu-id="ac533-119">MusicType</span><span class="sxs-lookup"><span data-stu-id="ac533-119">MusicType</span></span>| <span data-ttu-id="ac533-120">TVType</span><span class="sxs-lookup"><span data-stu-id="ac533-120">TVType</span></span>| <span data-ttu-id="ac533-121">WebVideoType</span><span class="sxs-lookup"><span data-stu-id="ac533-121">WebVideoType</span></span>| <span data-ttu-id="ac533-122">Unknown</span><span class="sxs-lookup"><span data-stu-id="ac533-122">Unknown</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ac533-123">Canonical</span><span class="sxs-lookup"><span data-stu-id="ac533-123">Canonical</span></span>| <span data-ttu-id="ac533-124">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-124">Y</span></span>| <span data-ttu-id="ac533-125">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-125">Y</span></span>| <span data-ttu-id="ac533-126">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-126">Y</span></span>| <span data-ttu-id="ac533-127">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-127">Y</span></span>| <span data-ttu-id="ac533-128">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-128">Y</span></span>| <span data-ttu-id="ac533-129">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-129">Y</span></span>| <span data-ttu-id="ac533-130">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-130">Y</span></span>| <span data-ttu-id="ac533-131">N</span><span class="sxs-lookup"><span data-stu-id="ac533-131">N</span></span>| 
| <span data-ttu-id="ac533-132">ZuneCatalog</span><span class="sxs-lookup"><span data-stu-id="ac533-132">ZuneCatalog</span></span>| <span data-ttu-id="ac533-133">N</span><span class="sxs-lookup"><span data-stu-id="ac533-133">N</span></span>| <span data-ttu-id="ac533-134">N</span><span class="sxs-lookup"><span data-stu-id="ac533-134">N</span></span>| <span data-ttu-id="ac533-135">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-135">Y</span></span>| <span data-ttu-id="ac533-136">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-136">Y</span></span>| <span data-ttu-id="ac533-137">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-137">Y</span></span>| <span data-ttu-id="ac533-138">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-138">Y</span></span>| <span data-ttu-id="ac533-139">N</span><span class="sxs-lookup"><span data-stu-id="ac533-139">N</span></span>| <span data-ttu-id="ac533-140">N</span><span class="sxs-lookup"><span data-stu-id="ac533-140">N</span></span>| 
| <span data-ttu-id="ac533-141">ZuneMediaInstance</span><span class="sxs-lookup"><span data-stu-id="ac533-141">ZuneMediaInstance</span></span>| <span data-ttu-id="ac533-142">N</span><span class="sxs-lookup"><span data-stu-id="ac533-142">N</span></span>| <span data-ttu-id="ac533-143">N</span><span class="sxs-lookup"><span data-stu-id="ac533-143">N</span></span>| <span data-ttu-id="ac533-144">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-144">Y</span></span>| <span data-ttu-id="ac533-145">N</span><span class="sxs-lookup"><span data-stu-id="ac533-145">N</span></span>| <span data-ttu-id="ac533-146">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-146">Y</span></span>| <span data-ttu-id="ac533-147">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-147">Y</span></span>| <span data-ttu-id="ac533-148">N</span><span class="sxs-lookup"><span data-stu-id="ac533-148">N</span></span>| <span data-ttu-id="ac533-149">N</span><span class="sxs-lookup"><span data-stu-id="ac533-149">N</span></span>| 
| <span data-ttu-id="ac533-150">プラン</span><span class="sxs-lookup"><span data-stu-id="ac533-150">Offer</span></span>| <span data-ttu-id="ac533-151">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-151">Y</span></span>| <span data-ttu-id="ac533-152">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-152">Y</span></span>| <span data-ttu-id="ac533-153">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-153">Y</span></span>| <span data-ttu-id="ac533-154">N</span><span class="sxs-lookup"><span data-stu-id="ac533-154">N</span></span>| <span data-ttu-id="ac533-155">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-155">Y</span></span>| <span data-ttu-id="ac533-156">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-156">Y</span></span>| <span data-ttu-id="ac533-157">N</span><span class="sxs-lookup"><span data-stu-id="ac533-157">N</span></span>| <span data-ttu-id="ac533-158">N</span><span class="sxs-lookup"><span data-stu-id="ac533-158">N</span></span>| 
| <span data-ttu-id="ac533-159">AMG</span><span class="sxs-lookup"><span data-stu-id="ac533-159">AMG</span></span>| <span data-ttu-id="ac533-160">N</span><span class="sxs-lookup"><span data-stu-id="ac533-160">N</span></span>| <span data-ttu-id="ac533-161">N</span><span class="sxs-lookup"><span data-stu-id="ac533-161">N</span></span>| <span data-ttu-id="ac533-162">N</span><span class="sxs-lookup"><span data-stu-id="ac533-162">N</span></span>| <span data-ttu-id="ac533-163">N</span><span class="sxs-lookup"><span data-stu-id="ac533-163">N</span></span>| <span data-ttu-id="ac533-164">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-164">Y</span></span>| <span data-ttu-id="ac533-165">N</span><span class="sxs-lookup"><span data-stu-id="ac533-165">N</span></span>| <span data-ttu-id="ac533-166">N</span><span class="sxs-lookup"><span data-stu-id="ac533-166">N</span></span>| <span data-ttu-id="ac533-167">N</span><span class="sxs-lookup"><span data-stu-id="ac533-167">N</span></span>| 
| <span data-ttu-id="ac533-168">MediaNet</span><span class="sxs-lookup"><span data-stu-id="ac533-168">MediaNet</span></span>| <span data-ttu-id="ac533-169">N</span><span class="sxs-lookup"><span data-stu-id="ac533-169">N</span></span>| <span data-ttu-id="ac533-170">N</span><span class="sxs-lookup"><span data-stu-id="ac533-170">N</span></span>| <span data-ttu-id="ac533-171">N</span><span class="sxs-lookup"><span data-stu-id="ac533-171">N</span></span>| <span data-ttu-id="ac533-172">N</span><span class="sxs-lookup"><span data-stu-id="ac533-172">N</span></span>| <span data-ttu-id="ac533-173">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-173">Y</span></span>| <span data-ttu-id="ac533-174">N</span><span class="sxs-lookup"><span data-stu-id="ac533-174">N</span></span>| <span data-ttu-id="ac533-175">N</span><span class="sxs-lookup"><span data-stu-id="ac533-175">N</span></span>| <span data-ttu-id="ac533-176">N</span><span class="sxs-lookup"><span data-stu-id="ac533-176">N</span></span>| 
| <span data-ttu-id="ac533-177">XboxHexTitle</span><span class="sxs-lookup"><span data-stu-id="ac533-177">XboxHexTitle</span></span>| <span data-ttu-id="ac533-178">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-178">Y</span></span>| <span data-ttu-id="ac533-179">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-179">Y</span></span>| <span data-ttu-id="ac533-180">N</span><span class="sxs-lookup"><span data-stu-id="ac533-180">N</span></span>| <span data-ttu-id="ac533-181">N</span><span class="sxs-lookup"><span data-stu-id="ac533-181">N</span></span>| <span data-ttu-id="ac533-182">N</span><span class="sxs-lookup"><span data-stu-id="ac533-182">N</span></span>| <span data-ttu-id="ac533-183">N</span><span class="sxs-lookup"><span data-stu-id="ac533-183">N</span></span>| <span data-ttu-id="ac533-184">N</span><span class="sxs-lookup"><span data-stu-id="ac533-184">N</span></span>| <span data-ttu-id="ac533-185">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-185">Y</span></span>| 
| <span data-ttu-id="ac533-186">ProviderContentId</span><span class="sxs-lookup"><span data-stu-id="ac533-186">ProviderContentId</span></span>| <span data-ttu-id="ac533-187">N</span><span class="sxs-lookup"><span data-stu-id="ac533-187">N</span></span>| <span data-ttu-id="ac533-188">N</span><span class="sxs-lookup"><span data-stu-id="ac533-188">N</span></span>| <span data-ttu-id="ac533-189">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-189">Y</span></span>| <span data-ttu-id="ac533-190">N</span><span class="sxs-lookup"><span data-stu-id="ac533-190">N</span></span>| <span data-ttu-id="ac533-191">N</span><span class="sxs-lookup"><span data-stu-id="ac533-191">N</span></span>| <span data-ttu-id="ac533-192">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-192">Y</span></span>| <span data-ttu-id="ac533-193">N</span><span class="sxs-lookup"><span data-stu-id="ac533-193">N</span></span>| <span data-ttu-id="ac533-194">Y</span><span class="sxs-lookup"><span data-stu-id="ac533-194">Y</span></span>| 
 
  * [<span data-ttu-id="ac533-195">パラメーターのノート</span><span class="sxs-lookup"><span data-stu-id="ac533-195">Parameter Notes</span></span>](#ID4EEH)
  * [<span data-ttu-id="ac533-196">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ac533-196">URI parameters</span></span>](#ID4EUH)
 
<a id="ID4EEH"></a>

 
## <a name="parameter-notes"></a><span data-ttu-id="ac533-197">パラメーターのノート</span><span class="sxs-lookup"><span data-stu-id="ac533-197">Parameter Notes</span></span>
 
<a id="ID4EIH"></a>

 
### <a name="providercontentid"></a><span data-ttu-id="ac533-198">ProviderContentId</span><span class="sxs-lookup"><span data-stu-id="ac533-198">ProviderContentId</span></span>
 
<span data-ttu-id="ac533-199">これは、使用する検索プロバイダー固有の id。例:</span><span class="sxs-lookup"><span data-stu-id="ac533-199">This is used to lookup provider specific Id. E.g.</span></span> <span data-ttu-id="ac533-200">Netflix Id または Hulu id</span><span class="sxs-lookup"><span data-stu-id="ac533-200">Netflix Id or Hulu Id.</span></span>
 
<span data-ttu-id="ac533-201">IdType ProviderContentId がある場合は、1 つの値のみが受け入れられます。</span><span class="sxs-lookup"><span data-stu-id="ac533-201">When idType is ProviderContentId, only a single value is accepted.</span></span> <span data-ttu-id="ac533-202">これは、ProviderContentIds が唯一の種類の ID を含めることができるため、'.' 文字。</span><span class="sxs-lookup"><span data-stu-id="ac533-202">This is because ProviderContentIds are the only type of ID that can contain the '.' character.</span></span> <span data-ttu-id="ac533-203">'.' 文字が Id 間で使用される区切り記号でも、新機能、delimieter Id 間の間であいまいさがあるし、新機能、ID 自体の一部です。</span><span class="sxs-lookup"><span data-stu-id="ac533-203">Since the '.' character is also the separator that we use between IDs, there's ambiguity between what's a delimieter between IDs and what's part of the ID itself.</span></span> <span data-ttu-id="ac533-204">API の rest 一括ルックアップ機能を除く、ProviderContentIds の同じように動作します。</span><span class="sxs-lookup"><span data-stu-id="ac533-204">The rest of the API works the same way for ProviderContentIds, except for the bulk lookup functionality.</span></span>
   
<a id="ID4EUH"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="ac533-205">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ac533-205">URI parameters</span></span>
 
| <span data-ttu-id="ac533-206">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ac533-206">Parameter</span></span>| <span data-ttu-id="ac533-207">種類</span><span class="sxs-lookup"><span data-stu-id="ac533-207">Type</span></span>| <span data-ttu-id="ac533-208">説明</span><span class="sxs-lookup"><span data-stu-id="ac533-208">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ac533-209">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="ac533-209">marketplaceId</span></span>| <span data-ttu-id="ac533-210">string</span><span class="sxs-lookup"><span data-stu-id="ac533-210">string</span></span>| <span data-ttu-id="ac533-211">必須。</span><span class="sxs-lookup"><span data-stu-id="ac533-211">Required.</span></span> <span data-ttu-id="ac533-212">文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。</span><span class="sxs-lookup"><span data-stu-id="ac533-212">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EWAAC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="ac533-213">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="ac533-213">Valid methods</span></span>

[<span data-ttu-id="ac533-214">GET (/media/{marketplaceId}/details)</span><span class="sxs-lookup"><span data-stu-id="ac533-214">GET (/media/{marketplaceId}/details)</span></span>](uri-medialocaledetailsget.md)

<span data-ttu-id="ac533-215">&nbsp;&nbsp;プランの詳細、メタデータを返しますについて 1 つまたは複数の項目。</span><span class="sxs-lookup"><span data-stu-id="ac533-215">&nbsp;&nbsp;Returns offer details and metadata about one or more items.</span></span> 
 
<a id="ID4EABAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="ac533-216">関連項目</span><span class="sxs-lookup"><span data-stu-id="ac533-216">See also</span></span>
 
<a id="ID4ECBAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="ac533-217">Parent</span><span class="sxs-lookup"><span data-stu-id="ac533-217">Parent</span></span> 

[<span data-ttu-id="ac533-218">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="ac533-218">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EMBAC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="ac533-219">詳細情報</span><span class="sxs-lookup"><span data-stu-id="ac533-219">Further Information</span></span> 

[<span data-ttu-id="ac533-220">EDS の一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="ac533-220">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="ac533-221">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="ac533-221">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="ac533-222">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="ac533-222">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="ac533-223">その他の参照</span><span class="sxs-lookup"><span data-stu-id="ac533-223">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   