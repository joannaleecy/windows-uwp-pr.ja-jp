---
title: /media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}
assetID: 1e2f5fd3-3d14-9a97-ffbf-ab2a18ff4f15
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinername.html
author: KevinAsgari
description: " /media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: af1090dd5dc33d3070ddafc9c79105d09c400a3c
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5479902"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefinersqueryrefinername"></a><span data-ttu-id="a4404-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}</span><span class="sxs-lookup"><span data-stu-id="a4404-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}</span></span>
<span data-ttu-id="a4404-105">指定されたクエリの絞り込み条件名と、特定のメディア項目の種類に利用可能な値にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="a4404-105">Accesses the acceptable values for the given query refiner name and given media item type.</span></span> <span data-ttu-id="a4404-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="a4404-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="a4404-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a4404-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="a4404-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a4404-108">URI parameters</span></span>
 
| <span data-ttu-id="a4404-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a4404-109">Parameter</span></span>| <span data-ttu-id="a4404-110">型</span><span class="sxs-lookup"><span data-stu-id="a4404-110">Type</span></span>| <span data-ttu-id="a4404-111">説明</span><span class="sxs-lookup"><span data-stu-id="a4404-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="a4404-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="a4404-112">marketplaceId</span></span>| <span data-ttu-id="a4404-113">string</span><span class="sxs-lookup"><span data-stu-id="a4404-113">string</span></span>| <span data-ttu-id="a4404-114">必須。</span><span class="sxs-lookup"><span data-stu-id="a4404-114">Required.</span></span> <span data-ttu-id="a4404-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="a4404-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="a4404-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="a4404-116">mediaitemtype</span></span>| <span data-ttu-id="a4404-117">string</span><span class="sxs-lookup"><span data-stu-id="a4404-117">string</span></span>| <span data-ttu-id="a4404-118">必須。</span><span class="sxs-lookup"><span data-stu-id="a4404-118">Required.</span></span> <span data-ttu-id="a4404-119">値のいずれかの[GET (/media/{marketplaceId}//metadata/mediagroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="a4404-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
| <span data-ttu-id="a4404-120">queryrefinername</span><span class="sxs-lookup"><span data-stu-id="a4404-120">queryrefinername</span></span>| <span data-ttu-id="a4404-121">string</span><span class="sxs-lookup"><span data-stu-id="a4404-121">string</span></span>| <span data-ttu-id="a4404-122">必須。</span><span class="sxs-lookup"><span data-stu-id="a4404-122">Required.</span></span> <span data-ttu-id="a4404-123">どの値が必要な「ジャンル」や「年」など、クエリの絞り込み条件の名前です。</span><span class="sxs-lookup"><span data-stu-id="a4404-123">Name of the query refiner for which values are needed, such as "Genre" or "Decade".</span></span> <span data-ttu-id="a4404-124">QueryRefiners を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a4404-124">See QueryRefiners.</span></span>| 
  
<a id="ID4EKC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="a4404-125">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="a4404-125">Valid methods</span></span>

[<span data-ttu-id="a4404-126">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})</span><span class="sxs-lookup"><span data-stu-id="a4404-126">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})</span></span>](uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinernameget.md)

<span data-ttu-id="a4404-127">&nbsp;&nbsp;指定されたクエリの絞り込み条件名と、特定のメディア項目の種類に利用可能な値の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="a4404-127">&nbsp;&nbsp;Lists the acceptable values for the given query refiner name and given media item type.</span></span>
 
<a id="ID4EUC"></a>

 
## <a name="see-also"></a><span data-ttu-id="a4404-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="a4404-128">See also</span></span>
 
<a id="ID4EWC"></a>

 
##### <a name="parent"></a><span data-ttu-id="a4404-129">Parent</span><span class="sxs-lookup"><span data-stu-id="a4404-129">Parent</span></span> 

[<span data-ttu-id="a4404-130">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="a4404-130">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EAD"></a>

 
##### <a name="further-information"></a><span data-ttu-id="a4404-131">詳細情報</span><span class="sxs-lookup"><span data-stu-id="a4404-131">Further Information</span></span> 

[<span data-ttu-id="a4404-132">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a4404-132">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="a4404-133">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="a4404-133">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="a4404-134">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="a4404-134">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="a4404-135">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="a4404-135">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   