---
title: /media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}
assetID: 1e2f5fd3-3d14-9a97-ffbf-ab2a18ff4f15
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinername.html
author: KevinAsgari
description: " /media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: af1090dd5dc33d3070ddafc9c79105d09c400a3c
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3962699"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefinersqueryrefinername"></a><span data-ttu-id="6ed6c-104">/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}</span><span class="sxs-lookup"><span data-stu-id="6ed6c-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}</span></span>
<span data-ttu-id="6ed6c-105">メディア項目の種類が与えられると、指定されたクエリの絞り込み条件名は、利用可能な値にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="6ed6c-105">Accesses the acceptable values for the given query refiner name and given media item type.</span></span> <span data-ttu-id="6ed6c-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="6ed6c-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="6ed6c-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6ed6c-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="6ed6c-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6ed6c-108">URI parameters</span></span>
 
| <span data-ttu-id="6ed6c-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="6ed6c-109">Parameter</span></span>| <span data-ttu-id="6ed6c-110">型</span><span class="sxs-lookup"><span data-stu-id="6ed6c-110">Type</span></span>| <span data-ttu-id="6ed6c-111">説明</span><span class="sxs-lookup"><span data-stu-id="6ed6c-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="6ed6c-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="6ed6c-112">marketplaceId</span></span>| <span data-ttu-id="6ed6c-113">string</span><span class="sxs-lookup"><span data-stu-id="6ed6c-113">string</span></span>| <span data-ttu-id="6ed6c-114">必須。</span><span class="sxs-lookup"><span data-stu-id="6ed6c-114">Required.</span></span> <span data-ttu-id="6ed6c-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="6ed6c-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="6ed6c-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="6ed6c-116">mediaitemtype</span></span>| <span data-ttu-id="6ed6c-117">string</span><span class="sxs-lookup"><span data-stu-id="6ed6c-117">string</span></span>| <span data-ttu-id="6ed6c-118">必須。</span><span class="sxs-lookup"><span data-stu-id="6ed6c-118">Required.</span></span> <span data-ttu-id="6ed6c-119">値のいずれかの[を取得する (/media/{marketplaceId}/メタデータ mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="6ed6c-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
| <span data-ttu-id="6ed6c-120">queryrefinername</span><span class="sxs-lookup"><span data-stu-id="6ed6c-120">queryrefinername</span></span>| <span data-ttu-id="6ed6c-121">string</span><span class="sxs-lookup"><span data-stu-id="6ed6c-121">string</span></span>| <span data-ttu-id="6ed6c-122">必須。</span><span class="sxs-lookup"><span data-stu-id="6ed6c-122">Required.</span></span> <span data-ttu-id="6ed6c-123">どの値が必要なため、「ジャンル」や「年」などのクエリの調整の名前です。</span><span class="sxs-lookup"><span data-stu-id="6ed6c-123">Name of the query refiner for which values are needed, such as "Genre" or "Decade".</span></span> <span data-ttu-id="6ed6c-124">QueryRefiners を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6ed6c-124">See QueryRefiners.</span></span>| 
  
<a id="ID4EKC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="6ed6c-125">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="6ed6c-125">Valid methods</span></span>

[<span data-ttu-id="6ed6c-126">取得する (/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})</span><span class="sxs-lookup"><span data-stu-id="6ed6c-126">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})</span></span>](uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinernameget.md)

<span data-ttu-id="6ed6c-127">&nbsp;&nbsp;メディア項目の種類が与えられると、指定されたクエリの絞り込み条件名は、利用可能な値の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="6ed6c-127">&nbsp;&nbsp;Lists the acceptable values for the given query refiner name and given media item type.</span></span>
 
<a id="ID4EUC"></a>

 
## <a name="see-also"></a><span data-ttu-id="6ed6c-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="6ed6c-128">See also</span></span>
 
<a id="ID4EWC"></a>

 
##### <a name="parent"></a><span data-ttu-id="6ed6c-129">Parent</span><span class="sxs-lookup"><span data-stu-id="6ed6c-129">Parent</span></span> 

[<span data-ttu-id="6ed6c-130">Marketplace Uri</span><span class="sxs-lookup"><span data-stu-id="6ed6c-130">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EAD"></a>

 
##### <a name="further-information"></a><span data-ttu-id="6ed6c-131">詳細情報</span><span class="sxs-lookup"><span data-stu-id="6ed6c-131">Further Information</span></span> 

[<span data-ttu-id="6ed6c-132">EDS 一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="6ed6c-132">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="6ed6c-133">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="6ed6c-133">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="6ed6c-134">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="6ed6c-134">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="6ed6c-135">その他の参照</span><span class="sxs-lookup"><span data-stu-id="6ed6c-135">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   