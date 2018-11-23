---
title: GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)
assetID: 0ecf27d8-905d-af52-4060-43353d7a3e29
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypefieldsget.html
author: KevinAsgari
description: " GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1d6ac92839e9969df807d39b01f1ec5a67de3e30
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7553132"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypefields"></a><span data-ttu-id="38fe6-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)</span><span class="sxs-lookup"><span data-stu-id="38fe6-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)</span></span>
<span data-ttu-id="38fe6-105">特定の mediaitemtype と EDS の特定のバージョンのデータを期待いずれかからフィールドを示します。</span><span class="sxs-lookup"><span data-stu-id="38fe6-105">Lists fields from which one can expect data, for a given mediaitemtype and a given version of EDS.</span></span> <span data-ttu-id="38fe6-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="38fe6-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="38fe6-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="38fe6-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="38fe6-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="38fe6-108">URI parameters</span></span>
 
| <span data-ttu-id="38fe6-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="38fe6-109">Parameter</span></span>| <span data-ttu-id="38fe6-110">型</span><span class="sxs-lookup"><span data-stu-id="38fe6-110">Type</span></span>| <span data-ttu-id="38fe6-111">説明</span><span class="sxs-lookup"><span data-stu-id="38fe6-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="38fe6-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="38fe6-112">marketplaceId</span></span>| <span data-ttu-id="38fe6-113">string</span><span class="sxs-lookup"><span data-stu-id="38fe6-113">string</span></span>| <span data-ttu-id="38fe6-114">必須。</span><span class="sxs-lookup"><span data-stu-id="38fe6-114">Required.</span></span> <span data-ttu-id="38fe6-115"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="38fe6-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="38fe6-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="38fe6-116">mediaitemtype</span></span>| <span data-ttu-id="38fe6-117">string</span><span class="sxs-lookup"><span data-stu-id="38fe6-117">string</span></span>| <span data-ttu-id="38fe6-118">必須。</span><span class="sxs-lookup"><span data-stu-id="38fe6-118">Required.</span></span> <span data-ttu-id="38fe6-119">値のいずれか[GET (/media/{marketplaceId}//metadata/mediagroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="38fe6-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="38fe6-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="38fe6-120">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="38fe6-121">Parent</span><span class="sxs-lookup"><span data-stu-id="38fe6-121">Parent</span></span> 

[<span data-ttu-id="38fe6-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields</span><span class="sxs-lookup"><span data-stu-id="38fe6-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields</span></span>](uri-medialocalemetadatamediaitemtypefields.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="38fe6-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="38fe6-123">Further Information</span></span> 

[<span data-ttu-id="38fe6-124">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="38fe6-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="38fe6-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="38fe6-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="38fe6-126">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="38fe6-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="38fe6-127">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="38fe6-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="38fe6-128">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="38fe6-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   