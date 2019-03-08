---
title: /media/{marketplaceId}/browse
assetID: 4fedc780-b3c2-c83b-e7af-9e18666a4771
permalink: en-us/docs/xboxlive/rest/uri-medialocalebrowse.html
description: " /media/{marketplaceId}/browse"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f692fb66580e20ffeefb3595b8cf9d795f504311
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589687"
---
# <a name="mediamarketplaceidbrowse"></a><span data-ttu-id="9096c-104">/media/{marketplaceId}/browse</span><span class="sxs-lookup"><span data-stu-id="9096c-104">/media/{marketplaceId}/browse</span></span>
<span data-ttu-id="9096c-105">1 つのメディアのグループ内の項目を参照できます。</span><span class="sxs-lookup"><span data-stu-id="9096c-105">Allows browsing for items within a single media group.</span></span> <span data-ttu-id="9096c-106">参照 API には、1 つのメディアのグループ内の項目を参照するクライアントが使用できます。</span><span class="sxs-lookup"><span data-stu-id="9096c-106">The browse API allows clients to browse for items from within a single media group.</span></span> <span data-ttu-id="9096c-107">データのページは、非連続的に継続トークンを使用する代わりに、skipItems パラメーターを使用してアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="9096c-107">Pages of data can be accessed non-sequentially using the skipItems parameter instead of using the continuation token.</span></span>
 
<span data-ttu-id="9096c-108">この API では、特定の項目の子内で参照できます。</span><span class="sxs-lookup"><span data-stu-id="9096c-108">This API also allows browsing within the children of a given item.</span></span> <span data-ttu-id="9096c-109">たとえばを Xbox 360 ゲームの ID と MediaItemType パラメーターに渡して、これにより、参照と diltering アバター項目やゲームの DLC など、その項目の子で。</span><span class="sxs-lookup"><span data-stu-id="9096c-109">For example, by passing in an ID and a MediaItemType parameter for an Xbox 360 Game, this allows browsing and diltering on the children of that item, such as Avatar items or DLC for the game.</span></span>
 
<span data-ttu-id="9096c-110">この API は、クエリの絞り込み条件を受け入れます。</span><span class="sxs-lookup"><span data-stu-id="9096c-110">This API accepts Query Refiners.</span></span>
 
<span data-ttu-id="9096c-111">子を取得するためのいくつかのシナリオは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="9096c-111">Some scenarios for retrieving children include:</span></span>
 
   * <span data-ttu-id="9096c-112">アルバム トラックを</span><span class="sxs-lookup"><span data-stu-id="9096c-112">Album to Tracks</span></span>
   * <span data-ttu-id="9096c-113">季節シリーズ</span><span class="sxs-lookup"><span data-stu-id="9096c-113">Series to Seasons</span></span>
   * <span data-ttu-id="9096c-114">エピソードに季節</span><span class="sxs-lookup"><span data-stu-id="9096c-114">Seasons to Episodes</span></span>
   * <span data-ttu-id="9096c-115">ミュージック ビデオへの追跡します。</span><span class="sxs-lookup"><span data-stu-id="9096c-115">Track to Music Video</span></span>
   * <span data-ttu-id="9096c-116">アーティストのアルバムに</span><span class="sxs-lookup"><span data-stu-id="9096c-116">Artist to Albums</span></span>
   * <span data-ttu-id="9096c-117">ゲームのアドオン (DLC、アバター、テーマなど) にゲーム</span><span class="sxs-lookup"><span data-stu-id="9096c-117">Games to Game Add-ons (DLC, Avatar, Themes, etc.)</span></span>
  
<span data-ttu-id="9096c-118">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="9096c-118">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="9096c-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9096c-119">URI parameters</span></span>](#ID4EMB)
 
<a id="ID4EMB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="9096c-120">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9096c-120">URI parameters</span></span>
 
| <span data-ttu-id="9096c-121">パラメーター</span><span class="sxs-lookup"><span data-stu-id="9096c-121">Parameter</span></span>| <span data-ttu-id="9096c-122">種類</span><span class="sxs-lookup"><span data-stu-id="9096c-122">Type</span></span>| <span data-ttu-id="9096c-123">説明</span><span class="sxs-lookup"><span data-stu-id="9096c-123">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="9096c-124">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="9096c-124">marketplaceId</span></span>| <span data-ttu-id="9096c-125">string</span><span class="sxs-lookup"><span data-stu-id="9096c-125">string</span></span>| <span data-ttu-id="9096c-126">必須。</span><span class="sxs-lookup"><span data-stu-id="9096c-126">Required.</span></span> <span data-ttu-id="9096c-127">文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。</span><span class="sxs-lookup"><span data-stu-id="9096c-127">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4ENC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="9096c-128">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="9096c-128">Valid methods</span></span>

[<span data-ttu-id="9096c-129">GET (media/{marketplaceId}/browse)</span><span class="sxs-lookup"><span data-stu-id="9096c-129">GET (media/{marketplaceId}/browse)</span></span>](uri-medialocalebrowseget.md)

<span data-ttu-id="9096c-130">&nbsp;&nbsp;1 つのメディアのグループ内の項目を参照できます。</span><span class="sxs-lookup"><span data-stu-id="9096c-130">&nbsp;&nbsp;Allows browsing for items within a single media group.</span></span> 
 
<a id="ID4EXC"></a>

 
## <a name="see-also"></a><span data-ttu-id="9096c-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="9096c-131">See also</span></span>
 
<a id="ID4EZC"></a>

 
##### <a name="parent"></a><span data-ttu-id="9096c-132">Parent</span><span class="sxs-lookup"><span data-stu-id="9096c-132">Parent</span></span> 

[<span data-ttu-id="9096c-133">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="9096c-133">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EDD"></a>

 
##### <a name="further-information"></a><span data-ttu-id="9096c-134">詳細情報</span><span class="sxs-lookup"><span data-stu-id="9096c-134">Further Information</span></span> 

[<span data-ttu-id="9096c-135">EDS の一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="9096c-135">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="9096c-136">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="9096c-136">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="9096c-137">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="9096c-137">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="9096c-138">その他の参照</span><span class="sxs-lookup"><span data-stu-id="9096c-138">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   