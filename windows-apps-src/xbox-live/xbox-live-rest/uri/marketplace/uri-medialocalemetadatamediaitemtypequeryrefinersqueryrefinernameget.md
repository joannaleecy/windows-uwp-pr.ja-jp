---
title: GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})
assetID: 05b2449f-3ef4-4fdf-df32-e72bcfc473d2
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinernameget.html
description: " GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: aaff80d0b3ec3caa0439ec23f3deeff280f0309d
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8882901"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefinersqueryrefinername"></a><span data-ttu-id="0341c-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})</span><span class="sxs-lookup"><span data-stu-id="0341c-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})</span></span>
<span data-ttu-id="0341c-105">指定されたクエリの絞り込み条件名と、特定のメディア項目の種類に利用可能な値の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="0341c-105">Lists the acceptable values for the given query refiner name and given media item type.</span></span> <span data-ttu-id="0341c-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="0341c-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="0341c-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0341c-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="0341c-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0341c-108">URI parameters</span></span>
 
| <span data-ttu-id="0341c-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="0341c-109">Parameter</span></span>| <span data-ttu-id="0341c-110">型</span><span class="sxs-lookup"><span data-stu-id="0341c-110">Type</span></span>| <span data-ttu-id="0341c-111">説明</span><span class="sxs-lookup"><span data-stu-id="0341c-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="0341c-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="0341c-112">marketplaceId</span></span>| <span data-ttu-id="0341c-113">string</span><span class="sxs-lookup"><span data-stu-id="0341c-113">string</span></span>| <span data-ttu-id="0341c-114">必須。</span><span class="sxs-lookup"><span data-stu-id="0341c-114">Required.</span></span> <span data-ttu-id="0341c-115"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="0341c-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="0341c-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="0341c-116">mediaitemtype</span></span>| <span data-ttu-id="0341c-117">string</span><span class="sxs-lookup"><span data-stu-id="0341c-117">string</span></span>| <span data-ttu-id="0341c-118">必須。</span><span class="sxs-lookup"><span data-stu-id="0341c-118">Required.</span></span> <span data-ttu-id="0341c-119">値のいずれか[GET (/media/{marketplaceId}//metadata/mediagroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="0341c-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
| <span data-ttu-id="0341c-120">queryrefinername</span><span class="sxs-lookup"><span data-stu-id="0341c-120">queryrefinername</span></span>| <span data-ttu-id="0341c-121">string</span><span class="sxs-lookup"><span data-stu-id="0341c-121">string</span></span>| <span data-ttu-id="0341c-122">必須。</span><span class="sxs-lookup"><span data-stu-id="0341c-122">Required.</span></span> <span data-ttu-id="0341c-123">どの値が必要な「ジャンル」や「年」など、クエリの絞り込み条件の名前です。</span><span class="sxs-lookup"><span data-stu-id="0341c-123">Name of the query refiner for which values are needed, such as "Genre" or "Decade".</span></span> <span data-ttu-id="0341c-124">QueryRefiners を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0341c-124">See QueryRefiners.</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="0341c-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="0341c-125">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="0341c-126">Parent</span><span class="sxs-lookup"><span data-stu-id="0341c-126">Parent</span></span> 

[<span data-ttu-id="0341c-127">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}</span><span class="sxs-lookup"><span data-stu-id="0341c-127">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}</span></span>](uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinername.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="0341c-128">詳細情報</span><span class="sxs-lookup"><span data-stu-id="0341c-128">Further Information</span></span> 

[<span data-ttu-id="0341c-129">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0341c-129">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="0341c-130">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="0341c-130">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="0341c-131">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="0341c-131">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="0341c-132">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="0341c-132">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="0341c-133">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="0341c-133">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   