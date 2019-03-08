---
title: EDS クエリの絞り込み条件
assetID: ab5c066a-a48b-3042-351d-d0a15f663276
permalink: en-us/docs/xboxlive/rest/edsqueryrefiners.html
description: " EDS クエリの絞り込み条件"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c00ff971e05003ec88c47d3803e565f6e9406c47
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57611467"
---
# <a name="eds-query-refiners"></a><span data-ttu-id="d7444-104">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="d7444-104">EDS Query Refiners</span></span>
 
<a id="ID4EO"></a>

  
 
<span data-ttu-id="d7444-105">対象が絞られた一連の項目をエンターテイメント検出サービス (EDS) クエリを絞り込むには、次のパラメーターを使用できます。</span><span class="sxs-lookup"><span data-stu-id="d7444-105">The following parameters can be used to refine an Entertainment Discovery Services (EDS) query to a more targeted set of items.</span></span> <span data-ttu-id="d7444-106">これらのパラメーターのいずれもが任意の API で必要ですが、クエリ絞り込みの条件を受け入れる任意の API でこれらを使用しています。</span><span class="sxs-lookup"><span data-stu-id="d7444-106">None of these parameters are required in any API, but they're accepted in any API that accepts query refiners.</span></span>
 
<span data-ttu-id="d7444-107">パラメーター名は"queryRefiners"パラメーターに値としてで渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="d7444-107">The parameter names can be passed in as values into any "queryRefiners" parameter.</span></span> <span data-ttu-id="d7444-108">このは、戻り値が、要求されたクエリの調整を繰り返し表示する場合に返される項目の数が適用される、クエリ絞り込み条件のそれぞれの値によって分類します。</span><span class="sxs-lookup"><span data-stu-id="d7444-108">This will then return the number of items that would be returned if the request were repeated with the query refiner applied, broken down by each value of the query refiner.</span></span>
 
<span data-ttu-id="d7444-109">この実習で作業する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="d7444-109">Here's how this might work in practice:</span></span>
 
   * <span data-ttu-id="d7444-110">参照 API への呼び出しが行われるパラメーターを含める"queryRefiners ジャンルを ="。</span><span class="sxs-lookup"><span data-stu-id="d7444-110">A call to the browse API is made, including the parameter "queryRefiners=genre".</span></span>
   * <span data-ttu-id="d7444-111">API は、8 つのゲームを返します。</span><span class="sxs-lookup"><span data-stu-id="d7444-111">The API returns eight games.</span></span> <span data-ttu-id="d7444-112">項目に加えて項目が含まれている各ジャンルの一覧と共に返される、項目の数がそのジャンルに属しています。</span><span class="sxs-lookup"><span data-stu-id="d7444-112">In addition to the items, a list of each genre that has items will be returned, along with how many items belong to that genre.</span></span> <span data-ttu-id="d7444-113">この可能性があります、ゲームの"Shooter:3、パズル:5".</span><span class="sxs-lookup"><span data-stu-id="d7444-113">For a game, this might be "Shooter: 3, Puzzle: 5".</span></span>
   * <span data-ttu-id="d7444-114">2 番目のクエリが行われます。</span><span class="sxs-lookup"><span data-stu-id="d7444-114">A second query is made.</span></span> <span data-ttu-id="d7444-115">1 番目と同じことを除いて"ジャンル Shooter ="が追加されます。</span><span class="sxs-lookup"><span data-stu-id="d7444-115">It's identical to the first, except that "genre=Shooter" is added.</span></span>
   * <span data-ttu-id="d7444-116">応答には、"Shooter"カテゴリに属するすべての 3 つだけのゲームが含まれるようになりました。</span><span class="sxs-lookup"><span data-stu-id="d7444-116">The response now contains only three games, all of which belong to the "Shooter" category.</span></span>
  
| <span data-ttu-id="d7444-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d7444-117">Parameter</span></span>| <span data-ttu-id="d7444-118">データ型</span><span class="sxs-lookup"><span data-stu-id="d7444-118">Data Type</span></span>| <span data-ttu-id="d7444-119">説明</span><span class="sxs-lookup"><span data-stu-id="d7444-119">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d7444-120"><b>10 年間</b></span><span class="sxs-lookup"><span data-stu-id="d7444-120"><b>decade</b></span></span>| <span data-ttu-id="d7444-121">string</span><span class="sxs-lookup"><span data-stu-id="d7444-121">string</span></span>| <span data-ttu-id="d7444-122">10 年間ですべての項目する必要がありますがリリースされています。</span><span class="sxs-lookup"><span data-stu-id="d7444-122">The decade in which all items must have been released.</span></span>| 
| <span data-ttu-id="d7444-123"><b>genre</b></span><span class="sxs-lookup"><span data-stu-id="d7444-123"><b>genre</b></span></span>| <span data-ttu-id="d7444-124">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="d7444-124">array of string</span></span>| <span data-ttu-id="d7444-125">すべての項目が必要なジャンルのリスト。</span><span class="sxs-lookup"><span data-stu-id="d7444-125">The list of genres that all items must have.</span></span>| 
| <span data-ttu-id="d7444-126"><b>labelOwner</b></span><span class="sxs-lookup"><span data-stu-id="d7444-126"><b>labelOwner</b></span></span>| <span data-ttu-id="d7444-127">string</span><span class="sxs-lookup"><span data-stu-id="d7444-127">string</span></span>| <span data-ttu-id="d7444-128">アーティスト、アルバム、またはトラックに関連付けられている音楽のラベル。</span><span class="sxs-lookup"><span data-stu-id="d7444-128">The music label associated with the artist, album, or track.</span></span>| 
| <span data-ttu-id="d7444-129"><b>network</b></span><span class="sxs-lookup"><span data-stu-id="d7444-129"><b>network</b></span></span>| <span data-ttu-id="d7444-130">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="d7444-130">array of string</span></span>| <span data-ttu-id="d7444-131">このネットワークは、アイテムを作成します。</span><span class="sxs-lookup"><span data-stu-id="d7444-131">The network that created the items.</span></span>| 
| <span data-ttu-id="d7444-132"><b>studio</b></span><span class="sxs-lookup"><span data-stu-id="d7444-132"><b>studio</b></span></span>| <span data-ttu-id="d7444-133">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="d7444-133">array of string</span></span>| <span data-ttu-id="d7444-134">アイテムを作成、studio。</span><span class="sxs-lookup"><span data-stu-id="d7444-134">The studio that created the items.</span></span>| 
| <span data-ttu-id="d7444-135"><b>xboxAppCategories</b></span><span class="sxs-lookup"><span data-stu-id="d7444-135"><b>xboxAppCategories</b></span></span>| <span data-ttu-id="d7444-136">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="d7444-136">array of string</span></span>| <span data-ttu-id="d7444-137">すべての Xbox アプリに必要なカテゴリの一覧。</span><span class="sxs-lookup"><span data-stu-id="d7444-137">The list of categories that all Xbox Apps must have.</span></span>| 
| <span data-ttu-id="d7444-138"><b>xboxAvatarClothes</b></span><span class="sxs-lookup"><span data-stu-id="d7444-138"><b>xboxAvatarClothes</b></span></span>| <span data-ttu-id="d7444-139">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="d7444-139">array of string</span></span>| <span data-ttu-id="d7444-140">Clothing の種類の一覧に Xbox アバターのすべての項目が必要です。</span><span class="sxs-lookup"><span data-stu-id="d7444-140">The list of clothing types all Xbox Avatar items must have.</span></span>| 
| <span data-ttu-id="d7444-141"><b>xboxAvatarStores</b></span><span class="sxs-lookup"><span data-stu-id="d7444-141"><b>xboxAvatarStores</b></span></span>| <span data-ttu-id="d7444-142">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="d7444-142">array of string</span></span>| <span data-ttu-id="d7444-143">アバターの項目が属する必要がありますすべてを Xbox にストアの一覧。</span><span class="sxs-lookup"><span data-stu-id="d7444-143">The list of stores to which all Xbox avatar items must belong.</span></span>| 
| <span data-ttu-id="d7444-144"><b>xboxGamePublisherBits</b></span><span class="sxs-lookup"><span data-stu-id="d7444-144"><b>xboxGamePublisherBits</b></span></span>| <span data-ttu-id="d7444-145">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="d7444-145">array of string</span></span>| <span data-ttu-id="d7444-146">すべてのゲームの種類の項目または AppType 項目で設定する必要がありますゲームの発行元のビットの一覧。</span><span class="sxs-lookup"><span data-stu-id="d7444-146">The list of game publisher bits that must be set on all GameType items or AppType items.</span></span>| 
| <span data-ttu-id="d7444-147"><b>xboxIsBrowsable</b></span><span class="sxs-lookup"><span data-stu-id="d7444-147"><b>xboxIsBrowsable</b></span></span>| <span data-ttu-id="d7444-148">ブール値</span><span class="sxs-lookup"><span data-stu-id="d7444-148">Boolean value</span></span>| <span data-ttu-id="d7444-149">場合<b>true</b>、実践的なコンテンツだけでなく、直接操作ではない完全なゲームが返されます。</span><span class="sxs-lookup"><span data-stu-id="d7444-149">If <b>true</b>, will return full games which are not directly actionable in addition to actionable content.</span></span> <span data-ttu-id="d7444-150">既定値は<b>false</b>します。</span><span class="sxs-lookup"><span data-stu-id="d7444-150">Defaults to <b>false</b>.</span></span>| 
| <span data-ttu-id="d7444-151"><b>xboxHasChildMediaItemTypes</b></span><span class="sxs-lookup"><span data-stu-id="d7444-151"><b>xboxHasChildMediaItemTypes</b></span></span>| <span data-ttu-id="d7444-152">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="d7444-152">array of string</span></span>| <span data-ttu-id="d7444-153">ゲームのメディアのグループにすべての返された項目のメディア項目の種類が指定された値のいずれかの子が必要です。</span><span class="sxs-lookup"><span data-stu-id="d7444-153">All returned items with a media group of Game must have children whose media item type is one of the provided values.</span></span>| 
  
<a id="ID4EEF"></a>

 
## <a name="see-also"></a><span data-ttu-id="d7444-154">関連項目</span><span class="sxs-lookup"><span data-stu-id="d7444-154">See also</span></span>
 
<a id="ID4EGF"></a>

 
##### <a name="parent"></a><span data-ttu-id="d7444-155">Parent</span><span class="sxs-lookup"><span data-stu-id="d7444-155">Parent</span></span>  

[<span data-ttu-id="d7444-156">その他の参照</span><span class="sxs-lookup"><span data-stu-id="d7444-156">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4ESF"></a>

 
##### <a name="further-information"></a><span data-ttu-id="d7444-157">詳細情報</span><span class="sxs-lookup"><span data-stu-id="d7444-157">Further Information</span></span> 

[<span data-ttu-id="d7444-158">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="d7444-158">Marketplace URIs</span></span>](../uri/marketplace/atoc-reference-marketplace.md)

   