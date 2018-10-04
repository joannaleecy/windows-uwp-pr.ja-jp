---
title: GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})
assetID: 05b2449f-3ef4-4fdf-df32-e72bcfc473d2
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinernameget.html
author: KevinAsgari
description: " GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 230e92bf17ebf1cfdad1eb6a21277e038fbdef25
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4308483"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefinersqueryrefinername"></a><span data-ttu-id="77f75-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})</span><span class="sxs-lookup"><span data-stu-id="77f75-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})</span></span>
<span data-ttu-id="77f75-105">メディア項目の種類が与えられると、指定されたクエリの調整名は、利用可能な値の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="77f75-105">Lists the acceptable values for the given query refiner name and given media item type.</span></span> <span data-ttu-id="77f75-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="77f75-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="77f75-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="77f75-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="77f75-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="77f75-108">URI parameters</span></span>
 
| <span data-ttu-id="77f75-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="77f75-109">Parameter</span></span>| <span data-ttu-id="77f75-110">型</span><span class="sxs-lookup"><span data-stu-id="77f75-110">Type</span></span>| <span data-ttu-id="77f75-111">説明</span><span class="sxs-lookup"><span data-stu-id="77f75-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="77f75-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="77f75-112">marketplaceId</span></span>| <span data-ttu-id="77f75-113">string</span><span class="sxs-lookup"><span data-stu-id="77f75-113">string</span></span>| <span data-ttu-id="77f75-114">必須。</span><span class="sxs-lookup"><span data-stu-id="77f75-114">Required.</span></span> <span data-ttu-id="77f75-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="77f75-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="77f75-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="77f75-116">mediaitemtype</span></span>| <span data-ttu-id="77f75-117">string</span><span class="sxs-lookup"><span data-stu-id="77f75-117">string</span></span>| <span data-ttu-id="77f75-118">必須。</span><span class="sxs-lookup"><span data-stu-id="77f75-118">Required.</span></span> <span data-ttu-id="77f75-119">値のいずれかの[を取得する (/media/{marketplaceId}/メタデータ mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="77f75-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
| <span data-ttu-id="77f75-120">queryrefinername</span><span class="sxs-lookup"><span data-stu-id="77f75-120">queryrefinername</span></span>| <span data-ttu-id="77f75-121">string</span><span class="sxs-lookup"><span data-stu-id="77f75-121">string</span></span>| <span data-ttu-id="77f75-122">必須。</span><span class="sxs-lookup"><span data-stu-id="77f75-122">Required.</span></span> <span data-ttu-id="77f75-123">どの値が必要な「ジャンル」や「年」など、クエリの調整の名前です。</span><span class="sxs-lookup"><span data-stu-id="77f75-123">Name of the query refiner for which values are needed, such as "Genre" or "Decade".</span></span> <span data-ttu-id="77f75-124">QueryRefiners を参照してください。</span><span class="sxs-lookup"><span data-stu-id="77f75-124">See QueryRefiners.</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="77f75-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="77f75-125">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="77f75-126">Parent</span><span class="sxs-lookup"><span data-stu-id="77f75-126">Parent</span></span> 

[<span data-ttu-id="77f75-127">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}</span><span class="sxs-lookup"><span data-stu-id="77f75-127">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}</span></span>](uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinername.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="77f75-128">詳細情報</span><span class="sxs-lookup"><span data-stu-id="77f75-128">Further Information</span></span> 

[<span data-ttu-id="77f75-129">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="77f75-129">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="77f75-130">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="77f75-130">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="77f75-131">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="77f75-131">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="77f75-132">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="77f75-132">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="77f75-133">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="77f75-133">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   