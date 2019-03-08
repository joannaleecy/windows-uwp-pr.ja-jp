---
title: GET (/media/{marketplaceId}/contentRating)
assetID: e677acdb-d905-3bea-b0ca-6d8becd663c0
permalink: en-us/docs/xboxlive/rest/uri-medialocalecontentratingget.html
description: " GET (/media/{marketplaceId}/contentRating)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8d1cb9d09de8671d4cd3d61e96a8335412237e5c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641587"
---
# <a name="get-mediamarketplaceidcontentrating"></a><span data-ttu-id="515ab-104">GET (/media/{marketplaceId}/contentRating)</span><span class="sxs-lookup"><span data-stu-id="515ab-104">GET (/media/{marketplaceId}/contentRating)</span></span>
<span data-ttu-id="515ab-105">コンテンツのレーティング トークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="515ab-105">Get the content rating token.</span></span> <span data-ttu-id="515ab-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="515ab-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="515ab-107">注釈</span><span class="sxs-lookup"><span data-stu-id="515ab-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="515ab-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="515ab-108">URI parameters</span></span>](#ID4ELB)
  * [<span data-ttu-id="515ab-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="515ab-109">Query string parameters</span></span>](#ID4EWB)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="515ab-110">注釈</span><span class="sxs-lookup"><span data-stu-id="515ab-110">Remarks</span></span>
 
<span data-ttu-id="515ab-111">複雑なタスクは、子が参照を許可するコンテンツに対する保護者による制御を適用します。</span><span class="sxs-lookup"><span data-stu-id="515ab-111">Enforcing parental controls over the content children are allowed to see is a complicated task.</span></span> <span data-ttu-id="515ab-112">だけでなくは各メディア項目の種類が、独自の評価システムが、これらの評価システムは、国を変更できます。</span><span class="sxs-lookup"><span data-stu-id="515ab-112">Not only does each media item type have its own rating system, but those rating systems can vary from country to country.</span></span> <span data-ttu-id="515ab-113">これはすべての項目を適切にフィルターを指定する必要があるデータのいくつかの異なる部分があることを意味します。</span><span class="sxs-lookup"><span data-stu-id="515ab-113">This means that there are several different pieces of data that need to be specified to properly filter all items.</span></span>
 
<span data-ttu-id="515ab-114">すべてのパラメーターを指定する、すべての API 呼び出しで、代わりに、この API に渡す値を生成**combinedContentRating**他の Api でのパラメーターと同じ情報を引き続き通信します。</span><span class="sxs-lookup"><span data-stu-id="515ab-114">Instead of specifying all of the parameters in all API calls, this API generates a value to pass into **combinedContentRating** parameters in other APIs and still communicate the same information.</span></span> <span data-ttu-id="515ab-115">これは、やすく Api を使用して、保守がその他の Api の 1 つの再利用可能な値にこの API に渡されるいくつかのパラメーターが折りたたまれている設計されています。</span><span class="sxs-lookup"><span data-stu-id="515ab-115">This is designed to make the APIs easier to use and maintain, as the several parameters passed into this API are collapsed into a single, reusable value for the other APIs.</span></span>
 
<span data-ttu-id="515ab-116">頻繁に変更する必要がありますが、この API によって返される正確な値は変更が最終的に、(リリース エンターテイメント検出サービス (EDS) の間など)、したがって、長期間のキャッシュ可能性があります。</span><span class="sxs-lookup"><span data-stu-id="515ab-116">Although the exact values returned by this API may eventually change, they should change very infrequently (such as between releases of Entertainment Discovery Services (EDS)) and thus could be cached for long periods of time.</span></span> <span data-ttu-id="515ab-117">API を受け入れる、 **combinedContentRating**パラメーターに渡された値が有効でない場合は、意味のあるエラー メッセージは、呼び出し元が単なる更新後の値を取得するには、もう一度この API を呼び出す必要がありますを示す値。</span><span class="sxs-lookup"><span data-stu-id="515ab-117">Any API accepting a **combinedContentRating** parameter will give a meaningful error message if the value passed in is invalid, which is an indication the caller merely needs to call this API again to get an updated value.</span></span> <span data-ttu-id="515ab-118">API を受け入れる場合、 **combinedContentRating**コンテンツのフィルター処理は行われません保護者による制限に基づいて、指定されたパラメーターが 1 つにはありません。</span><span class="sxs-lookup"><span data-stu-id="515ab-118">If an API accepts a **combinedContentRating** parameter, but one isn't provided, no filtering of content will take place based on parental controls.</span></span> 

> [!NOTE] 
> <span data-ttu-id="515ab-119">わけでは「安全」のみのコンテンツが返されるか--すべてのコンテンツが返されるか、明示的な可能性のあるコンテンツを含むことを意味します。</span><span class="sxs-lookup"><span data-stu-id="515ab-119">This doesn't mean that only "safe" content is returned -- it means that all content is returned, including potentially explicit content.</span></span> 


  
<a id="ID4ELB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="515ab-120">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="515ab-120">URI parameters</span></span>
 
| <span data-ttu-id="515ab-121">パラメーター</span><span class="sxs-lookup"><span data-stu-id="515ab-121">Parameter</span></span>| <span data-ttu-id="515ab-122">種類</span><span class="sxs-lookup"><span data-stu-id="515ab-122">Type</span></span>| <span data-ttu-id="515ab-123">説明</span><span class="sxs-lookup"><span data-stu-id="515ab-123">Description</span></span>| 
| --- | --- | --- | --- | 
| <span data-ttu-id="515ab-124">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="515ab-124">marketplaceId</span></span>| <span data-ttu-id="515ab-125">string</span><span class="sxs-lookup"><span data-stu-id="515ab-125">string</span></span>| <span data-ttu-id="515ab-126">必須。</span><span class="sxs-lookup"><span data-stu-id="515ab-126">Required.</span></span> <span data-ttu-id="515ab-127">文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。</span><span class="sxs-lookup"><span data-stu-id="515ab-127">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EWB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="515ab-128">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="515ab-128">Query string parameters</span></span>
 
| <span data-ttu-id="515ab-129">パラメーター</span><span class="sxs-lookup"><span data-stu-id="515ab-129">Parameter</span></span>| <span data-ttu-id="515ab-130">種類</span><span class="sxs-lookup"><span data-stu-id="515ab-130">Type</span></span>| <span data-ttu-id="515ab-131">説明</span><span class="sxs-lookup"><span data-stu-id="515ab-131">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="515ab-132">filterExplicit</span><span class="sxs-lookup"><span data-stu-id="515ab-132">filterExplicit</span></span>| <span data-ttu-id="515ab-133">ブール値</span><span class="sxs-lookup"><span data-stu-id="515ab-133">Boolean value</span></span>| <span data-ttu-id="515ab-134">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="515ab-134">Optional.</span></span> <span data-ttu-id="515ab-135">明示的な音楽をフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="515ab-135">Filters explicit music.</span></span>| 
| <span data-ttu-id="515ab-136">filterFamilyOnlyApps</span><span class="sxs-lookup"><span data-stu-id="515ab-136">filterFamilyOnlyApps</span></span>| <span data-ttu-id="515ab-137">ブール値</span><span class="sxs-lookup"><span data-stu-id="515ab-137">Boolean value</span></span>| <span data-ttu-id="515ab-138">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="515ab-138">Optional.</span></span> <span data-ttu-id="515ab-139">フィルター アプリのわかりやすいファミリとしてマークされません。</span><span class="sxs-lookup"><span data-stu-id="515ab-139">Filter apps not marked as family friendly.</span></span>| 
| <span data-ttu-id="515ab-140">filterUnrated</span><span class="sxs-lookup"><span data-stu-id="515ab-140">filterUnrated</span></span>| <span data-ttu-id="515ab-141">ブール値</span><span class="sxs-lookup"><span data-stu-id="515ab-141">Boolean value</span></span>| <span data-ttu-id="515ab-142">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="515ab-142">Optional.</span></span> <span data-ttu-id="515ab-143">かどうか、評価済みでないコンテンツを応答に含める必要があるかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="515ab-143">Determines whether content that is unrated should be included in the response or not.</span></span>| 
| <span data-ttu-id="515ab-144">maxGameRating</span><span class="sxs-lookup"><span data-stu-id="515ab-144">maxGameRating</span></span>| <span data-ttu-id="515ab-145">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="515ab-145">32-bit signed integer</span></span>| <span data-ttu-id="515ab-146">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="515ab-146">Optional.</span></span> <span data-ttu-id="515ab-147">ゲームをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="515ab-147">Filters games.</span></span>| 
| <span data-ttu-id="515ab-148">maxMovieRating</span><span class="sxs-lookup"><span data-stu-id="515ab-148">maxMovieRating</span></span>| <span data-ttu-id="515ab-149">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="515ab-149">32-bit signed integer</span></span>| <span data-ttu-id="515ab-150">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="515ab-150">Optional.</span></span> <span data-ttu-id="515ab-151">特定のレベルより上の映画をフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="515ab-151">Filters movies above a specific level.</span></span>| 
| <span data-ttu-id="515ab-152">maxTVRating</span><span class="sxs-lookup"><span data-stu-id="515ab-152">maxTVRating</span></span>| <span data-ttu-id="515ab-153">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="515ab-153">32-bit signed integer</span></span>| <span data-ttu-id="515ab-154">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="515ab-154">Optional.</span></span> <span data-ttu-id="515ab-155">テレビをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="515ab-155">Filters TV.</span></span>| 
  
<a id="ID4E5D"></a>

 
## <a name="see-also"></a><span data-ttu-id="515ab-156">関連項目</span><span class="sxs-lookup"><span data-stu-id="515ab-156">See also</span></span>
 
<a id="ID4EAE"></a>

 
##### <a name="parent"></a><span data-ttu-id="515ab-157">Parent</span><span class="sxs-lookup"><span data-stu-id="515ab-157">Parent</span></span> 

[<span data-ttu-id="515ab-158">/media/{marketplaceId}/contentRating</span><span class="sxs-lookup"><span data-stu-id="515ab-158">/media/{marketplaceId}/contentRating</span></span>](uri-medialocalecontentrating.md)

  
<a id="ID4EKE"></a>

 
##### <a name="further-information"></a><span data-ttu-id="515ab-159">詳細情報</span><span class="sxs-lookup"><span data-stu-id="515ab-159">Further Information</span></span> 

[<span data-ttu-id="515ab-160">EDS の一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="515ab-160">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="515ab-161">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="515ab-161">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="515ab-162">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="515ab-162">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="515ab-163">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="515ab-163">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="515ab-164">その他の参照</span><span class="sxs-lookup"><span data-stu-id="515ab-164">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   