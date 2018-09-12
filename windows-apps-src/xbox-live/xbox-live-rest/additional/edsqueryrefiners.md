---
title: EDS は、絞り込み条件をクエリします。
assetID: ab5c066a-a48b-3042-351d-d0a15f663276
permalink: en-us/docs/xboxlive/rest/edsqueryrefiners.html
author: KevinAsgari
description: " EDS は、絞り込み条件をクエリします。"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b049965d619a7c25108e2b6308b18f1e402fecab
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3932620"
---
# <a name="eds-query-refiners"></a><span data-ttu-id="ecdff-104">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="ecdff-104">EDS Query Refiners</span></span>
 
<a id="ID4EO"></a>

  
 
<span data-ttu-id="ecdff-105">対象を絞り込む一連の項目をエンターテイメント探索サービス (EDS) クエリを絞り込むは、次のパラメーターを使用できます。</span><span class="sxs-lookup"><span data-stu-id="ecdff-105">The following parameters can be used to refine an Entertainment Discovery Services (EDS) query to a more targeted set of items.</span></span> <span data-ttu-id="ecdff-106">いずれかの API に none これらのパラメーターが必要ですが、クエリの絞り込み条件を受け入れるいずれかの API でこれらを使用しています。</span><span class="sxs-lookup"><span data-stu-id="ecdff-106">None of these parameters are required in any API, but they're accepted in any API that accepts query refiners.</span></span>
 
<span data-ttu-id="ecdff-107">パラメーターの名前は、その値として"queryRefiners"パラメーターにで渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="ecdff-107">The parameter names can be passed in as values into any "queryRefiners" parameter.</span></span> <span data-ttu-id="ecdff-108">このは、戻り値、要求されたクエリの調整を繰り返し発生する場合に返される項目の数が適用されると、クエリの調整の各値ごとに分類します。</span><span class="sxs-lookup"><span data-stu-id="ecdff-108">This will then return the number of items that would be returned if the request were repeated with the query refiner applied, broken down by each value of the query refiner.</span></span>
 
<span data-ttu-id="ecdff-109">この作業の実践方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="ecdff-109">Here's how this might work in practice:</span></span>
 
   * <span data-ttu-id="ecdff-110">参照 API への呼び出しが行われたなど、パラメーターは、"queryRefiners ジャンルを ="します。</span><span class="sxs-lookup"><span data-stu-id="ecdff-110">A call to the browse API is made, including the parameter "queryRefiners=genre".</span></span>
   * <span data-ttu-id="ecdff-111">この API は、8 ゲームを返します。</span><span class="sxs-lookup"><span data-stu-id="ecdff-111">The API returns eight games.</span></span> <span data-ttu-id="ecdff-112">だけでなく、項目の項目が各ジャンルの一覧が返されます、と共にそのジャンルに属している項目の数。</span><span class="sxs-lookup"><span data-stu-id="ecdff-112">In addition to the items, a list of each genre that has items will be returned, along with how many items belong to that genre.</span></span> <span data-ttu-id="ecdff-113">ゲームの場合があります"一人称視点のシューティング: 3、パズル: 5"します。</span><span class="sxs-lookup"><span data-stu-id="ecdff-113">For a game, this might be "Shooter: 3, Puzzle: 5".</span></span>
   * <span data-ttu-id="ecdff-114">2 番目のクエリが行われます。</span><span class="sxs-lookup"><span data-stu-id="ecdff-114">A second query is made.</span></span> <span data-ttu-id="ecdff-115">最初のと同じことを除けば"ジャンル一人称視点のシューティング ="が追加されます。</span><span class="sxs-lookup"><span data-stu-id="ecdff-115">It's identical to the first, except that "genre=Shooter" is added.</span></span>
   * <span data-ttu-id="ecdff-116">応答には、「一人称視点のシューティング」カテゴリに属するすべての 3 つのゲームにはできるようになりましたが含まれます。</span><span class="sxs-lookup"><span data-stu-id="ecdff-116">The response now contains only three games, all of which belong to the "Shooter" category.</span></span>
  
| <span data-ttu-id="ecdff-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ecdff-117">Parameter</span></span>| <span data-ttu-id="ecdff-118">データ型</span><span class="sxs-lookup"><span data-stu-id="ecdff-118">Data Type</span></span>| <span data-ttu-id="ecdff-119">説明</span><span class="sxs-lookup"><span data-stu-id="ecdff-119">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="ecdff-120">年</span><span class="sxs-lookup"><span data-stu-id="ecdff-120">decade</span></span></b>| <span data-ttu-id="ecdff-121">string</span><span class="sxs-lookup"><span data-stu-id="ecdff-121">string</span></span>| <span data-ttu-id="ecdff-122">10 年間ですべての項目する必要がありますリリースされています。</span><span class="sxs-lookup"><span data-stu-id="ecdff-122">The decade in which all items must have been released.</span></span>| 
| <b><span data-ttu-id="ecdff-123">ジャンル</span><span class="sxs-lookup"><span data-stu-id="ecdff-123">genre</span></span></b>| <span data-ttu-id="ecdff-124">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="ecdff-124">array of string</span></span>| <span data-ttu-id="ecdff-125">すべての項目が必要なジャンルの一覧。</span><span class="sxs-lookup"><span data-stu-id="ecdff-125">The list of genres that all items must have.</span></span>| 
| <b><span data-ttu-id="ecdff-126">labelOwner</span><span class="sxs-lookup"><span data-stu-id="ecdff-126">labelOwner</span></span></b>| <span data-ttu-id="ecdff-127">string</span><span class="sxs-lookup"><span data-stu-id="ecdff-127">string</span></span>| <span data-ttu-id="ecdff-128">アーティスト、アルバム、またはトラックに関連付けられているミュージック ラベル。</span><span class="sxs-lookup"><span data-stu-id="ecdff-128">The music label associated with the artist, album, or track.</span></span>| 
| <b><span data-ttu-id="ecdff-129">ネットワーク</span><span class="sxs-lookup"><span data-stu-id="ecdff-129">network</span></span></b>| <span data-ttu-id="ecdff-130">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="ecdff-130">array of string</span></span>| <span data-ttu-id="ecdff-131">項目を作成するネットワーク。</span><span class="sxs-lookup"><span data-stu-id="ecdff-131">The network that created the items.</span></span>| 
| <b><span data-ttu-id="ecdff-132">studio</span><span class="sxs-lookup"><span data-stu-id="ecdff-132">studio</span></span></b>| <span data-ttu-id="ecdff-133">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="ecdff-133">array of string</span></span>| <span data-ttu-id="ecdff-134">項目の作成、studio します。</span><span class="sxs-lookup"><span data-stu-id="ecdff-134">The studio that created the items.</span></span>| 
| <b><span data-ttu-id="ecdff-135">xboxAppCategories</span><span class="sxs-lookup"><span data-stu-id="ecdff-135">xboxAppCategories</span></span></b>| <span data-ttu-id="ecdff-136">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="ecdff-136">array of string</span></span>| <span data-ttu-id="ecdff-137">すべての Xbox アプリに必要なカテゴリの一覧。</span><span class="sxs-lookup"><span data-stu-id="ecdff-137">The list of categories that all Xbox Apps must have.</span></span>| 
| <b><span data-ttu-id="ecdff-138">xboxAvatarClothes</span><span class="sxs-lookup"><span data-stu-id="ecdff-138">xboxAvatarClothes</span></span></b>| <span data-ttu-id="ecdff-139">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="ecdff-139">array of string</span></span>| <span data-ttu-id="ecdff-140">洋服の種類の一覧にすべての Xbox アバター項目が必要です。</span><span class="sxs-lookup"><span data-stu-id="ecdff-140">The list of clothing types all Xbox Avatar items must have.</span></span>| 
| <b><span data-ttu-id="ecdff-141">xboxAvatarStores</span><span class="sxs-lookup"><span data-stu-id="ecdff-141">xboxAvatarStores</span></span></b>| <span data-ttu-id="ecdff-142">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="ecdff-142">array of string</span></span>| <span data-ttu-id="ecdff-143">アバター品目所属するすべての Xbox にストアの一覧。</span><span class="sxs-lookup"><span data-stu-id="ecdff-143">The list of stores to which all Xbox avatar items must belong.</span></span>| 
| <b><span data-ttu-id="ecdff-144">xboxGamePublisherBits</span><span class="sxs-lookup"><span data-stu-id="ecdff-144">xboxGamePublisherBits</span></span></b>| <span data-ttu-id="ecdff-145">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="ecdff-145">array of string</span></span>| <span data-ttu-id="ecdff-146">すべてのゲームの種類の項目や AppType 項目に対して設定する必要がありますゲーム パブリッシャー ビットの一覧。</span><span class="sxs-lookup"><span data-stu-id="ecdff-146">The list of game publisher bits that must be set on all GameType items or AppType items.</span></span>| 
| <b><span data-ttu-id="ecdff-147">xboxIsBrowsable</span><span class="sxs-lookup"><span data-stu-id="ecdff-147">xboxIsBrowsable</span></span></b>| <span data-ttu-id="ecdff-148">ブール値</span><span class="sxs-lookup"><span data-stu-id="ecdff-148">Boolean value</span></span>| <span data-ttu-id="ecdff-149"><b>True</b>を返す場合は、実践的なコンテンツだけでなく、直接操作できる完全なゲームです。</span><span class="sxs-lookup"><span data-stu-id="ecdff-149">If <b>true</b>, will return full games which are not directly actionable in addition to actionable content.</span></span> <span data-ttu-id="ecdff-150">既定値は<b>false</b>。</span><span class="sxs-lookup"><span data-stu-id="ecdff-150">Defaults to <b>false</b>.</span></span>| 
| <b><span data-ttu-id="ecdff-151">xboxHasChildMediaItemTypes</span><span class="sxs-lookup"><span data-stu-id="ecdff-151">xboxHasChildMediaItemTypes</span></span></b>| <span data-ttu-id="ecdff-152">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="ecdff-152">array of string</span></span>| <span data-ttu-id="ecdff-153">ゲームのメディアのグループで返されたすべての項目には、子のメディア項目の種類は、指定された値のいずれかが必要です。</span><span class="sxs-lookup"><span data-stu-id="ecdff-153">All returned items with a media group of Game must have children whose media item type is one of the provided values.</span></span>| 
  
<a id="ID4EEF"></a>

 
## <a name="see-also"></a><span data-ttu-id="ecdff-154">関連項目</span><span class="sxs-lookup"><span data-stu-id="ecdff-154">See also</span></span>
 
<a id="ID4EGF"></a>

 
##### <a name="parent"></a><span data-ttu-id="ecdff-155">Parent</span><span class="sxs-lookup"><span data-stu-id="ecdff-155">Parent</span></span>  

[<span data-ttu-id="ecdff-156">その他の参照</span><span class="sxs-lookup"><span data-stu-id="ecdff-156">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4ESF"></a>

 
##### <a name="further-information"></a><span data-ttu-id="ecdff-157">詳細情報</span><span class="sxs-lookup"><span data-stu-id="ecdff-157">Further Information</span></span> 

[<span data-ttu-id="ecdff-158">Marketplace Uri</span><span class="sxs-lookup"><span data-stu-id="ecdff-158">Marketplace URIs</span></span>](../uri/marketplace/atoc-reference-marketplace.md)

   