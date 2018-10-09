---
title: EDS クエリの絞り込み条件
assetID: ab5c066a-a48b-3042-351d-d0a15f663276
permalink: en-us/docs/xboxlive/rest/edsqueryrefiners.html
author: KevinAsgari
description: " EDS クエリの絞り込み条件"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b049965d619a7c25108e2b6308b18f1e402fecab
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4462302"
---
# <a name="eds-query-refiners"></a><span data-ttu-id="220dd-104">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="220dd-104">EDS Query Refiners</span></span>
 
<a id="ID4EO"></a>

  
 
<span data-ttu-id="220dd-105">対象を絞り込む一連の項目をエンターテイメント探索サービス (EDS) クエリを絞り込むは、次のパラメーターを使用できます。</span><span class="sxs-lookup"><span data-stu-id="220dd-105">The following parameters can be used to refine an Entertainment Discovery Services (EDS) query to a more targeted set of items.</span></span> <span data-ttu-id="220dd-106">いずれかの API で必要はないと、これらのパラメーターが、クエリの絞り込み条件を受け入れるいずれかの API でこれらを使用しています。</span><span class="sxs-lookup"><span data-stu-id="220dd-106">None of these parameters are required in any API, but they're accepted in any API that accepts query refiners.</span></span>
 
<span data-ttu-id="220dd-107">パラメーター名は、その値として"queryRefiners"パラメーターにで渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="220dd-107">The parameter names can be passed in as values into any "queryRefiners" parameter.</span></span> <span data-ttu-id="220dd-108">このその後、要求されたクエリの絞り込み条件で繰り返される場合に返される項目の数が適用されると、クエリの絞り込み条件のそれぞれの値を別の戻り値。</span><span class="sxs-lookup"><span data-stu-id="220dd-108">This will then return the number of items that would be returned if the request were repeated with the query refiner applied, broken down by each value of the query refiner.</span></span>
 
<span data-ttu-id="220dd-109">この作業の実践方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="220dd-109">Here's how this might work in practice:</span></span>
 
   * <span data-ttu-id="220dd-110">参照 API への呼び出しが行われたなど、パラメーターは、"queryRefiners ジャンルを ="。</span><span class="sxs-lookup"><span data-stu-id="220dd-110">A call to the browse API is made, including the parameter "queryRefiners=genre".</span></span>
   * <span data-ttu-id="220dd-111">この API は、8 つのゲームを返します。</span><span class="sxs-lookup"><span data-stu-id="220dd-111">The API returns eight games.</span></span> <span data-ttu-id="220dd-112">だけでなく、項目の項目が各ジャンルの一覧が返されますと共にそのジャンルに属している項目の数。</span><span class="sxs-lookup"><span data-stu-id="220dd-112">In addition to the items, a list of each genre that has items will be returned, along with how many items belong to that genre.</span></span> <span data-ttu-id="220dd-113">ゲームの場合があります"一人称視点のシューティング: 3、パズル: 5"。</span><span class="sxs-lookup"><span data-stu-id="220dd-113">For a game, this might be "Shooter: 3, Puzzle: 5".</span></span>
   * <span data-ttu-id="220dd-114">2 番目のクエリが行われます。</span><span class="sxs-lookup"><span data-stu-id="220dd-114">A second query is made.</span></span> <span data-ttu-id="220dd-115">最初のと同じことを除けば"ジャンル一人称視点のシューティング ="が追加されます。</span><span class="sxs-lookup"><span data-stu-id="220dd-115">It's identical to the first, except that "genre=Shooter" is added.</span></span>
   * <span data-ttu-id="220dd-116">応答には、「一人称視点のシューティング」カテゴリに属するすべての 3 つのゲームにはできるようになりましたが含まれています。</span><span class="sxs-lookup"><span data-stu-id="220dd-116">The response now contains only three games, all of which belong to the "Shooter" category.</span></span>
  
| <span data-ttu-id="220dd-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="220dd-117">Parameter</span></span>| <span data-ttu-id="220dd-118">データ型</span><span class="sxs-lookup"><span data-stu-id="220dd-118">Data Type</span></span>| <span data-ttu-id="220dd-119">説明</span><span class="sxs-lookup"><span data-stu-id="220dd-119">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="220dd-120">10 年</span><span class="sxs-lookup"><span data-stu-id="220dd-120">decade</span></span></b>| <span data-ttu-id="220dd-121">string</span><span class="sxs-lookup"><span data-stu-id="220dd-121">string</span></span>| <span data-ttu-id="220dd-122">10 年間ですべての項目する必要がありますリリースされています。</span><span class="sxs-lookup"><span data-stu-id="220dd-122">The decade in which all items must have been released.</span></span>| 
| <b><span data-ttu-id="220dd-123">ジャンル</span><span class="sxs-lookup"><span data-stu-id="220dd-123">genre</span></span></b>| <span data-ttu-id="220dd-124">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="220dd-124">array of string</span></span>| <span data-ttu-id="220dd-125">すべての項目が必要なジャンルの一覧。</span><span class="sxs-lookup"><span data-stu-id="220dd-125">The list of genres that all items must have.</span></span>| 
| <b><span data-ttu-id="220dd-126">labelOwner</span><span class="sxs-lookup"><span data-stu-id="220dd-126">labelOwner</span></span></b>| <span data-ttu-id="220dd-127">string</span><span class="sxs-lookup"><span data-stu-id="220dd-127">string</span></span>| <span data-ttu-id="220dd-128">アーティスト、アルバム、またはトラックに関連付けられているミュージック ラベル。</span><span class="sxs-lookup"><span data-stu-id="220dd-128">The music label associated with the artist, album, or track.</span></span>| 
| <b><span data-ttu-id="220dd-129">ネットワーク</span><span class="sxs-lookup"><span data-stu-id="220dd-129">network</span></span></b>| <span data-ttu-id="220dd-130">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="220dd-130">array of string</span></span>| <span data-ttu-id="220dd-131">項目を作成するネットワーク。</span><span class="sxs-lookup"><span data-stu-id="220dd-131">The network that created the items.</span></span>| 
| <b><span data-ttu-id="220dd-132">studio</span><span class="sxs-lookup"><span data-stu-id="220dd-132">studio</span></span></b>| <span data-ttu-id="220dd-133">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="220dd-133">array of string</span></span>| <span data-ttu-id="220dd-134">項目の作成、studio します。</span><span class="sxs-lookup"><span data-stu-id="220dd-134">The studio that created the items.</span></span>| 
| <b><span data-ttu-id="220dd-135">xboxAppCategories</span><span class="sxs-lookup"><span data-stu-id="220dd-135">xboxAppCategories</span></span></b>| <span data-ttu-id="220dd-136">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="220dd-136">array of string</span></span>| <span data-ttu-id="220dd-137">すべての Xbox アプリに必要なカテゴリの一覧。</span><span class="sxs-lookup"><span data-stu-id="220dd-137">The list of categories that all Xbox Apps must have.</span></span>| 
| <b><span data-ttu-id="220dd-138">xboxAvatarClothes</span><span class="sxs-lookup"><span data-stu-id="220dd-138">xboxAvatarClothes</span></span></b>| <span data-ttu-id="220dd-139">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="220dd-139">array of string</span></span>| <span data-ttu-id="220dd-140">洋服の種類の一覧のすべての Xbox アバター項目が必要です。</span><span class="sxs-lookup"><span data-stu-id="220dd-140">The list of clothing types all Xbox Avatar items must have.</span></span>| 
| <b><span data-ttu-id="220dd-141">xboxAvatarStores</span><span class="sxs-lookup"><span data-stu-id="220dd-141">xboxAvatarStores</span></span></b>| <span data-ttu-id="220dd-142">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="220dd-142">array of string</span></span>| <span data-ttu-id="220dd-143">アバター品目所属するすべての Xbox にストアの一覧。</span><span class="sxs-lookup"><span data-stu-id="220dd-143">The list of stores to which all Xbox avatar items must belong.</span></span>| 
| <b><span data-ttu-id="220dd-144">xboxGamePublisherBits</span><span class="sxs-lookup"><span data-stu-id="220dd-144">xboxGamePublisherBits</span></span></b>| <span data-ttu-id="220dd-145">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="220dd-145">array of string</span></span>| <span data-ttu-id="220dd-146">すべてのゲームの種類の項目や AppType 項目に対して設定する必要がありますゲーム パブリッシャー ビットの一覧。</span><span class="sxs-lookup"><span data-stu-id="220dd-146">The list of game publisher bits that must be set on all GameType items or AppType items.</span></span>| 
| <b><span data-ttu-id="220dd-147">xboxIsBrowsable</span><span class="sxs-lookup"><span data-stu-id="220dd-147">xboxIsBrowsable</span></span></b>| <span data-ttu-id="220dd-148">ブール値</span><span class="sxs-lookup"><span data-stu-id="220dd-148">Boolean value</span></span>| <span data-ttu-id="220dd-149"><b>True</b>を返す場合は、実践的なコンテンツだけでなく、直接操作できる完全なゲームです。</span><span class="sxs-lookup"><span data-stu-id="220dd-149">If <b>true</b>, will return full games which are not directly actionable in addition to actionable content.</span></span> <span data-ttu-id="220dd-150">既定値は<b>false</b>。</span><span class="sxs-lookup"><span data-stu-id="220dd-150">Defaults to <b>false</b>.</span></span>| 
| <b><span data-ttu-id="220dd-151">xboxHasChildMediaItemTypes</span><span class="sxs-lookup"><span data-stu-id="220dd-151">xboxHasChildMediaItemTypes</span></span></b>| <span data-ttu-id="220dd-152">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="220dd-152">array of string</span></span>| <span data-ttu-id="220dd-153">ゲームのメディアのグループで返されたすべての項目がメディア項目の種類は、指定された値のいずれかの子が必要です。</span><span class="sxs-lookup"><span data-stu-id="220dd-153">All returned items with a media group of Game must have children whose media item type is one of the provided values.</span></span>| 
  
<a id="ID4EEF"></a>

 
## <a name="see-also"></a><span data-ttu-id="220dd-154">関連項目</span><span class="sxs-lookup"><span data-stu-id="220dd-154">See also</span></span>
 
<a id="ID4EGF"></a>

 
##### <a name="parent"></a><span data-ttu-id="220dd-155">Parent</span><span class="sxs-lookup"><span data-stu-id="220dd-155">Parent</span></span>  

[<span data-ttu-id="220dd-156">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="220dd-156">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4ESF"></a>

 
##### <a name="further-information"></a><span data-ttu-id="220dd-157">詳細情報</span><span class="sxs-lookup"><span data-stu-id="220dd-157">Further Information</span></span> 

[<span data-ttu-id="220dd-158">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="220dd-158">Marketplace URIs</span></span>](../uri/marketplace/atoc-reference-marketplace.md)

   