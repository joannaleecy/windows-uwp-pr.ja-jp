---
title: GET (/media/{marketplaceId}/contentRating)
assetID: e677acdb-d905-3bea-b0ca-6d8becd663c0
permalink: en-us/docs/xboxlive/rest/uri-medialocalecontentratingget.html
author: KevinAsgari
description: " GET (/media/{marketplaceId}/contentRating)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e4cfbbccea617a19d85b9f5601c33f94839dd9ae
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6264068"
---
# <a name="get-mediamarketplaceidcontentrating"></a><span data-ttu-id="1677e-104">GET (/media/{marketplaceId}/contentRating)</span><span class="sxs-lookup"><span data-stu-id="1677e-104">GET (/media/{marketplaceId}/contentRating)</span></span>
<span data-ttu-id="1677e-105">コンテンツの規制のトークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="1677e-105">Get the content rating token.</span></span> <span data-ttu-id="1677e-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="1677e-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="1677e-107">注釈</span><span class="sxs-lookup"><span data-stu-id="1677e-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="1677e-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1677e-108">URI parameters</span></span>](#ID4ELB)
  * [<span data-ttu-id="1677e-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="1677e-109">Query string parameters</span></span>](#ID4EWB)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="1677e-110">注釈</span><span class="sxs-lookup"><span data-stu-id="1677e-110">Remarks</span></span>
 
<span data-ttu-id="1677e-111">保護者子が表示できるコンテンツを適用することは、複雑な作業です。</span><span class="sxs-lookup"><span data-stu-id="1677e-111">Enforcing parental controls over the content children are allowed to see is a complicated task.</span></span> <span data-ttu-id="1677e-112">だけでなく各メディア項目の種類は、独自の評価システムがそれらの評価システムは国によって異なることができます。</span><span class="sxs-lookup"><span data-stu-id="1677e-112">Not only does each media item type have its own rating system, but those rating systems can vary from country to country.</span></span> <span data-ttu-id="1677e-113">これはすべての項目を正しくフィルターを指定する必要があるデータの複数の異なる部分があることを意味します。</span><span class="sxs-lookup"><span data-stu-id="1677e-113">This means that there are several different pieces of data that need to be specified to properly filter all items.</span></span>
 
<span data-ttu-id="1677e-114">すべての API 呼び出しでは、すべてのパラメーターを指定することではなくは、この API は、他の Api で**combinedContentRating**パラメーターに渡すし、引き続き同じ情報を伝える値を生成します。</span><span class="sxs-lookup"><span data-stu-id="1677e-114">Instead of specifying all of the parameters in all API calls, this API generates a value to pass into **combinedContentRating** parameters in other APIs and still communicate the same information.</span></span> <span data-ttu-id="1677e-115">これは、この API に渡されるいくつかのパラメーターは、その他の Api の 1 つの再利用可能な値に折りたたまれたとき、Api を使用し、保守、やすくするために設計されています。</span><span class="sxs-lookup"><span data-stu-id="1677e-115">This is designed to make the APIs easier to use and maintain, as the several parameters passed into this API are collapsed into a single, reusable value for the other APIs.</span></span>
 
<span data-ttu-id="1677e-116">頻繁に変更する必要がありますが、この API によって返される正確な値は変更が最終的に、(リリース エンターテイメント探索サービス (EDS) の間など)、したがって、長期間のキャッシュ可能性があります。</span><span class="sxs-lookup"><span data-stu-id="1677e-116">Although the exact values returned by this API may eventually change, they should change very infrequently (such as between releases of Entertainment Discovery Services (EDS)) and thus could be cached for long periods of time.</span></span> <span data-ttu-id="1677e-117">**CombinedContentRating**パラメーターにより、わかりやすいエラー メッセージで渡した値が有効である場合を受け入れることを意味する API 呼び出し元だけ必要があります、更新された値を取得するには、もう一度この API を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="1677e-117">Any API accepting a **combinedContentRating** parameter will give a meaningful error message if the value passed in is invalid, which is an indication the caller merely needs to call this API again to get an updated value.</span></span> <span data-ttu-id="1677e-118">指定されていなければ、API が**combinedContentRating**パラメーターを受け取る場合、コンテンツのフィルター処理は行われません保護者に基づいています。</span><span class="sxs-lookup"><span data-stu-id="1677e-118">If an API accepts a **combinedContentRating** parameter, but one isn't provided, no filtering of content will take place based on parental controls.</span></span> 

> [!NOTE] 
> <span data-ttu-id="1677e-119">これとは限りません。 のみ"安全"コンテンツが返されること - すべてのコンテンツが返されること、明示的な可能性のあるコンテンツを含むことを意味します。</span><span class="sxs-lookup"><span data-stu-id="1677e-119">This doesn't mean that only "safe" content is returned -- it means that all content is returned, including potentially explicit content.</span></span> 


  
<a id="ID4ELB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="1677e-120">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1677e-120">URI parameters</span></span>
 
| <span data-ttu-id="1677e-121">パラメーター</span><span class="sxs-lookup"><span data-stu-id="1677e-121">Parameter</span></span>| <span data-ttu-id="1677e-122">型</span><span class="sxs-lookup"><span data-stu-id="1677e-122">Type</span></span>| <span data-ttu-id="1677e-123">説明</span><span class="sxs-lookup"><span data-stu-id="1677e-123">Description</span></span>| 
| --- | --- | --- | --- | 
| <span data-ttu-id="1677e-124">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="1677e-124">marketplaceId</span></span>| <span data-ttu-id="1677e-125">string</span><span class="sxs-lookup"><span data-stu-id="1677e-125">string</span></span>| <span data-ttu-id="1677e-126">必須。</span><span class="sxs-lookup"><span data-stu-id="1677e-126">Required.</span></span> <span data-ttu-id="1677e-127"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="1677e-127">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EWB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="1677e-128">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="1677e-128">Query string parameters</span></span>
 
| <span data-ttu-id="1677e-129">パラメーター</span><span class="sxs-lookup"><span data-stu-id="1677e-129">Parameter</span></span>| <span data-ttu-id="1677e-130">型</span><span class="sxs-lookup"><span data-stu-id="1677e-130">Type</span></span>| <span data-ttu-id="1677e-131">説明</span><span class="sxs-lookup"><span data-stu-id="1677e-131">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="1677e-132">filterExplicit</span><span class="sxs-lookup"><span data-stu-id="1677e-132">filterExplicit</span></span>| <span data-ttu-id="1677e-133">ブール値</span><span class="sxs-lookup"><span data-stu-id="1677e-133">Boolean value</span></span>| <span data-ttu-id="1677e-134">省略可能。</span><span class="sxs-lookup"><span data-stu-id="1677e-134">Optional.</span></span> <span data-ttu-id="1677e-135">明示的な音楽をフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="1677e-135">Filters explicit music.</span></span>| 
| <span data-ttu-id="1677e-136">filterFamilyOnlyApps</span><span class="sxs-lookup"><span data-stu-id="1677e-136">filterFamilyOnlyApps</span></span>| <span data-ttu-id="1677e-137">ブール値</span><span class="sxs-lookup"><span data-stu-id="1677e-137">Boolean value</span></span>| <span data-ttu-id="1677e-138">省略可能。</span><span class="sxs-lookup"><span data-stu-id="1677e-138">Optional.</span></span> <span data-ttu-id="1677e-139">アプリとマークされていないファミリ フレンドリをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="1677e-139">Filter apps not marked as family friendly.</span></span>| 
| <span data-ttu-id="1677e-140">filterUnrated</span><span class="sxs-lookup"><span data-stu-id="1677e-140">filterUnrated</span></span>| <span data-ttu-id="1677e-141">ブール値</span><span class="sxs-lookup"><span data-stu-id="1677e-141">Boolean value</span></span>| <span data-ttu-id="1677e-142">省略可能。</span><span class="sxs-lookup"><span data-stu-id="1677e-142">Optional.</span></span> <span data-ttu-id="1677e-143">かどう、評価されるコンテンツを応答に含める必要があるかどうかを決定します。</span><span class="sxs-lookup"><span data-stu-id="1677e-143">Determines whether content that is unrated should be included in the response or not.</span></span>| 
| <span data-ttu-id="1677e-144">maxGameRating</span><span class="sxs-lookup"><span data-stu-id="1677e-144">maxGameRating</span></span>| <span data-ttu-id="1677e-145">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="1677e-145">32-bit signed integer</span></span>| <span data-ttu-id="1677e-146">省略可能。</span><span class="sxs-lookup"><span data-stu-id="1677e-146">Optional.</span></span> <span data-ttu-id="1677e-147">ゲームをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="1677e-147">Filters games.</span></span>| 
| <span data-ttu-id="1677e-148">maxMovieRating</span><span class="sxs-lookup"><span data-stu-id="1677e-148">maxMovieRating</span></span>| <span data-ttu-id="1677e-149">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="1677e-149">32-bit signed integer</span></span>| <span data-ttu-id="1677e-150">省略可能。</span><span class="sxs-lookup"><span data-stu-id="1677e-150">Optional.</span></span> <span data-ttu-id="1677e-151">特定のレベルよりも、ビデオをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="1677e-151">Filters movies above a specific level.</span></span>| 
| <span data-ttu-id="1677e-152">maxTVRating</span><span class="sxs-lookup"><span data-stu-id="1677e-152">maxTVRating</span></span>| <span data-ttu-id="1677e-153">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="1677e-153">32-bit signed integer</span></span>| <span data-ttu-id="1677e-154">省略可能。</span><span class="sxs-lookup"><span data-stu-id="1677e-154">Optional.</span></span> <span data-ttu-id="1677e-155">テレビをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="1677e-155">Filters TV.</span></span>| 
  
<a id="ID4E5D"></a>

 
## <a name="see-also"></a><span data-ttu-id="1677e-156">関連項目</span><span class="sxs-lookup"><span data-stu-id="1677e-156">See also</span></span>
 
<a id="ID4EAE"></a>

 
##### <a name="parent"></a><span data-ttu-id="1677e-157">Parent</span><span class="sxs-lookup"><span data-stu-id="1677e-157">Parent</span></span> 

[<span data-ttu-id="1677e-158">/media/{marketplaceId}/contentRating</span><span class="sxs-lookup"><span data-stu-id="1677e-158">/media/{marketplaceId}/contentRating</span></span>](uri-medialocalecontentrating.md)

  
<a id="ID4EKE"></a>

 
##### <a name="further-information"></a><span data-ttu-id="1677e-159">詳細情報</span><span class="sxs-lookup"><span data-stu-id="1677e-159">Further Information</span></span> 

[<span data-ttu-id="1677e-160">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1677e-160">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="1677e-161">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="1677e-161">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="1677e-162">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="1677e-162">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="1677e-163">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="1677e-163">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="1677e-164">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="1677e-164">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   