---
title: 取得する (/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})
assetID: 05b2449f-3ef4-4fdf-df32-e72bcfc473d2
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinernameget.html
author: KevinAsgari
description: " 取得する (/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 230e92bf17ebf1cfdad1eb6a21277e038fbdef25
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882151"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefinersqueryrefinername"></a><span data-ttu-id="d9f5b-104">取得する (/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})</span><span class="sxs-lookup"><span data-stu-id="d9f5b-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})</span></span>
<span data-ttu-id="d9f5b-105">指定されたクエリの調整名と、特定のメディア項目の種類で許容される値の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="d9f5b-105">Lists the acceptable values for the given query refiner name and given media item type.</span></span> <span data-ttu-id="d9f5b-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="d9f5b-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="d9f5b-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d9f5b-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="d9f5b-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d9f5b-108">URI parameters</span></span>
 
| <span data-ttu-id="d9f5b-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d9f5b-109">Parameter</span></span>| <span data-ttu-id="d9f5b-110">型</span><span class="sxs-lookup"><span data-stu-id="d9f5b-110">Type</span></span>| <span data-ttu-id="d9f5b-111">説明</span><span class="sxs-lookup"><span data-stu-id="d9f5b-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d9f5b-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="d9f5b-112">marketplaceId</span></span>| <span data-ttu-id="d9f5b-113">string</span><span class="sxs-lookup"><span data-stu-id="d9f5b-113">string</span></span>| <span data-ttu-id="d9f5b-114">必須。</span><span class="sxs-lookup"><span data-stu-id="d9f5b-114">Required.</span></span> <span data-ttu-id="d9f5b-115"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="d9f5b-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="d9f5b-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="d9f5b-116">mediaitemtype</span></span>| <span data-ttu-id="d9f5b-117">string</span><span class="sxs-lookup"><span data-stu-id="d9f5b-117">string</span></span>| <span data-ttu-id="d9f5b-118">必須。</span><span class="sxs-lookup"><span data-stu-id="d9f5b-118">Required.</span></span> <span data-ttu-id="d9f5b-119">値のいずれか[取得 (/media/{marketplaceId}/メタデータ/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="d9f5b-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
| <span data-ttu-id="d9f5b-120">queryrefinername</span><span class="sxs-lookup"><span data-stu-id="d9f5b-120">queryrefinername</span></span>| <span data-ttu-id="d9f5b-121">string</span><span class="sxs-lookup"><span data-stu-id="d9f5b-121">string</span></span>| <span data-ttu-id="d9f5b-122">必須。</span><span class="sxs-lookup"><span data-stu-id="d9f5b-122">Required.</span></span> <span data-ttu-id="d9f5b-123">値が必要な「ジャンル」や「年」など、クエリの調整の名前。</span><span class="sxs-lookup"><span data-stu-id="d9f5b-123">Name of the query refiner for which values are needed, such as "Genre" or "Decade".</span></span> <span data-ttu-id="d9f5b-124">QueryRefiners を参照してください。</span><span class="sxs-lookup"><span data-stu-id="d9f5b-124">See QueryRefiners.</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="d9f5b-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="d9f5b-125">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="d9f5b-126">Parent</span><span class="sxs-lookup"><span data-stu-id="d9f5b-126">Parent</span></span> 

[<span data-ttu-id="d9f5b-127">/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}</span><span class="sxs-lookup"><span data-stu-id="d9f5b-127">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}</span></span>](uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinername.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="d9f5b-128">詳細情報</span><span class="sxs-lookup"><span data-stu-id="d9f5b-128">Further Information</span></span> 

[<span data-ttu-id="d9f5b-129">EDS 一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="d9f5b-129">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="d9f5b-130">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="d9f5b-130">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="d9f5b-131">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="d9f5b-131">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="d9f5b-132">Marketplace Uri</span><span class="sxs-lookup"><span data-stu-id="d9f5b-132">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="d9f5b-133">その他の参照</span><span class="sxs-lookup"><span data-stu-id="d9f5b-133">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   