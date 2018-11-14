---
title: /media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields
assetID: fc9b556a-7fc7-64ec-cb5c-b5cabd2ab4ce
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypefields.html
author: KevinAsgari
description: " /media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 086538c2817e39cb80c66f9689327ae84a5feff2
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6255531"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypefields"></a><span data-ttu-id="11912-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields</span><span class="sxs-lookup"><span data-stu-id="11912-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields</span></span>
<span data-ttu-id="11912-105">特定の mediaitemtype と EDS の特定のバージョンのデータを期待いずれかからアクセス フィールド。</span><span class="sxs-lookup"><span data-stu-id="11912-105">Accesses fields from which one can expect data, for a given mediaitemtype and a given version of EDS.</span></span> <span data-ttu-id="11912-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="11912-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="11912-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="11912-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="11912-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="11912-108">URI parameters</span></span>
 
| <span data-ttu-id="11912-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="11912-109">Parameter</span></span>| <span data-ttu-id="11912-110">型</span><span class="sxs-lookup"><span data-stu-id="11912-110">Type</span></span>| <span data-ttu-id="11912-111">説明</span><span class="sxs-lookup"><span data-stu-id="11912-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="11912-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="11912-112">marketplaceId</span></span>| <span data-ttu-id="11912-113">string</span><span class="sxs-lookup"><span data-stu-id="11912-113">string</span></span>| <span data-ttu-id="11912-114">必須。</span><span class="sxs-lookup"><span data-stu-id="11912-114">Required.</span></span> <span data-ttu-id="11912-115"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="11912-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="11912-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="11912-116">mediaitemtype</span></span>| <span data-ttu-id="11912-117">string</span><span class="sxs-lookup"><span data-stu-id="11912-117">string</span></span>| <span data-ttu-id="11912-118">必須。</span><span class="sxs-lookup"><span data-stu-id="11912-118">Required.</span></span> <span data-ttu-id="11912-119">値のいずれか[GET (/media/{marketplaceId}//metadata/mediagroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="11912-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EBC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="11912-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="11912-120">Valid methods</span></span>

[<span data-ttu-id="11912-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)</span><span class="sxs-lookup"><span data-stu-id="11912-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)</span></span>](uri-medialocalemetadatamediaitemtypefieldsget.md)

<span data-ttu-id="11912-122">&nbsp;&nbsp;特定の mediaitemtype と EDS の特定のバージョンのデータを期待いずれかからフィールドを示します。</span><span class="sxs-lookup"><span data-stu-id="11912-122">&nbsp;&nbsp;Lists fields from which one can expect data, for a given mediaitemtype and a given version of EDS.</span></span>
 
<a id="ID4ELC"></a>

 
## <a name="see-also"></a><span data-ttu-id="11912-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="11912-123">See also</span></span>
 
<a id="ID4ENC"></a>

 
##### <a name="parent"></a><span data-ttu-id="11912-124">Parent</span><span class="sxs-lookup"><span data-stu-id="11912-124">Parent</span></span> 

[<span data-ttu-id="11912-125">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="11912-125">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EXC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="11912-126">詳細情報</span><span class="sxs-lookup"><span data-stu-id="11912-126">Further Information</span></span> 

[<span data-ttu-id="11912-127">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="11912-127">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="11912-128">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="11912-128">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="11912-129">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="11912-129">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="11912-130">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="11912-130">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   