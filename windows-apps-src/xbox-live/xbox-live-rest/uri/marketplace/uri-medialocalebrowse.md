---
title: /media/{marketplaceId}/browse
assetID: 4fedc780-b3c2-c83b-e7af-9e18666a4771
permalink: en-us/docs/xboxlive/rest/uri-medialocalebrowse.html
author: KevinAsgari
description: " /media/{marketplaceId}/browse"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 776db1cf795ae964621d751d6b4b72d22ba82c2d
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4620383"
---
# <a name="mediamarketplaceidbrowse"></a><span data-ttu-id="bfe71-104">/media/{marketplaceId}/browse</span><span class="sxs-lookup"><span data-stu-id="bfe71-104">/media/{marketplaceId}/browse</span></span>
<span data-ttu-id="bfe71-105">1 つのメディア グループ内の項目を参照できます。</span><span class="sxs-lookup"><span data-stu-id="bfe71-105">Allows browsing for items within a single media group.</span></span> <span data-ttu-id="bfe71-106">参照 API では、クライアントから 1 つのメディア グループ内の項目を参照ができるようにします。</span><span class="sxs-lookup"><span data-stu-id="bfe71-106">The browse API allows clients to browse for items from within a single media group.</span></span> <span data-ttu-id="bfe71-107">非連続的に継続トークンを使用するのではなく skipItems パラメーターを使用してデータのページにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="bfe71-107">Pages of data can be accessed non-sequentially using the skipItems parameter instead of using the continuation token.</span></span>
 
<span data-ttu-id="bfe71-108">この API では、指定した項目の子内で参照できます。</span><span class="sxs-lookup"><span data-stu-id="bfe71-108">This API also allows browsing within the children of a given item.</span></span> <span data-ttu-id="bfe71-109">たとえば、Xbox 360 ゲームの ID と MediaItemType パラメーターに渡して、これにより、閲覧、diltering アバター項目やゲームの DLC など、その項目の子にします。</span><span class="sxs-lookup"><span data-stu-id="bfe71-109">For example, by passing in an ID and a MediaItemType parameter for an Xbox 360 Game, this allows browsing and diltering on the children of that item, such as Avatar items or DLC for the game.</span></span>
 
<span data-ttu-id="bfe71-110">この API は、クエリの絞り込み条件を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="bfe71-110">This API accepts Query Refiners.</span></span>
 
<span data-ttu-id="bfe71-111">子を取得するためのいくつかのシナリオは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="bfe71-111">Some scenarios for retrieving children include:</span></span>
 
   * <span data-ttu-id="bfe71-112">アルバムのトラックに</span><span class="sxs-lookup"><span data-stu-id="bfe71-112">Album to Tracks</span></span>
   * <span data-ttu-id="bfe71-113">時期にシリーズ</span><span class="sxs-lookup"><span data-stu-id="bfe71-113">Series to Seasons</span></span>
   * <span data-ttu-id="bfe71-114">エピソードする時期</span><span class="sxs-lookup"><span data-stu-id="bfe71-114">Seasons to Episodes</span></span>
   * <span data-ttu-id="bfe71-115">音楽ビデオへの追跡します。</span><span class="sxs-lookup"><span data-stu-id="bfe71-115">Track to Music Video</span></span>
   * <span data-ttu-id="bfe71-116">アルバムにアーティスト</span><span class="sxs-lookup"><span data-stu-id="bfe71-116">Artist to Albums</span></span>
   * <span data-ttu-id="bfe71-117">ゲームのアドオン (DLC、アバター、テーマなど) へのゲーム</span><span class="sxs-lookup"><span data-stu-id="bfe71-117">Games to Game Add-ons (DLC, Avatar, Themes, etc.)</span></span>
  
<span data-ttu-id="bfe71-118">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="bfe71-118">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="bfe71-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bfe71-119">URI parameters</span></span>](#ID4EMB)
 
<a id="ID4EMB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="bfe71-120">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bfe71-120">URI parameters</span></span>
 
| <span data-ttu-id="bfe71-121">パラメーター</span><span class="sxs-lookup"><span data-stu-id="bfe71-121">Parameter</span></span>| <span data-ttu-id="bfe71-122">型</span><span class="sxs-lookup"><span data-stu-id="bfe71-122">Type</span></span>| <span data-ttu-id="bfe71-123">説明</span><span class="sxs-lookup"><span data-stu-id="bfe71-123">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="bfe71-124">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="bfe71-124">marketplaceId</span></span>| <span data-ttu-id="bfe71-125">string</span><span class="sxs-lookup"><span data-stu-id="bfe71-125">string</span></span>| <span data-ttu-id="bfe71-126">必須。</span><span class="sxs-lookup"><span data-stu-id="bfe71-126">Required.</span></span> <span data-ttu-id="bfe71-127">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="bfe71-127">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4ENC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="bfe71-128">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="bfe71-128">Valid methods</span></span>

[<span data-ttu-id="bfe71-129">GET (media/{marketplaceId}/browse)</span><span class="sxs-lookup"><span data-stu-id="bfe71-129">GET (media/{marketplaceId}/browse)</span></span>](uri-medialocalebrowseget.md)

<span data-ttu-id="bfe71-130">&nbsp;&nbsp;1 つのメディア グループ内の項目を参照できます。</span><span class="sxs-lookup"><span data-stu-id="bfe71-130">&nbsp;&nbsp;Allows browsing for items within a single media group.</span></span> 
 
<a id="ID4EXC"></a>

 
## <a name="see-also"></a><span data-ttu-id="bfe71-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="bfe71-131">See also</span></span>
 
<a id="ID4EZC"></a>

 
##### <a name="parent"></a><span data-ttu-id="bfe71-132">Parent</span><span class="sxs-lookup"><span data-stu-id="bfe71-132">Parent</span></span> 

[<span data-ttu-id="bfe71-133">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="bfe71-133">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EDD"></a>

 
##### <a name="further-information"></a><span data-ttu-id="bfe71-134">詳細情報</span><span class="sxs-lookup"><span data-stu-id="bfe71-134">Further Information</span></span> 

[<span data-ttu-id="bfe71-135">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bfe71-135">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="bfe71-136">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="bfe71-136">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="bfe71-137">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="bfe71-137">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="bfe71-138">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="bfe71-138">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   