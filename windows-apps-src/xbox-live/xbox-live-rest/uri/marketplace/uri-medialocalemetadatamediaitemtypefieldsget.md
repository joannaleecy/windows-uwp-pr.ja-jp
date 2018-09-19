---
title: GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)
assetID: 0ecf27d8-905d-af52-4060-43353d7a3e29
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypefieldsget.html
author: KevinAsgari
description: " GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 56dc6067cfe559b5684fa93878e771257ecc8bc0
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4055857"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypefields"></a><span data-ttu-id="36743-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)</span><span class="sxs-lookup"><span data-stu-id="36743-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)</span></span>
<span data-ttu-id="36743-105">指定された mediaitemtype と EDS の特定のバージョンのデータを想定いずれかからフィールドを示します。</span><span class="sxs-lookup"><span data-stu-id="36743-105">Lists fields from which one can expect data, for a given mediaitemtype and a given version of EDS.</span></span> <span data-ttu-id="36743-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="36743-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="36743-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="36743-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="36743-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="36743-108">URI parameters</span></span>
 
| <span data-ttu-id="36743-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="36743-109">Parameter</span></span>| <span data-ttu-id="36743-110">型</span><span class="sxs-lookup"><span data-stu-id="36743-110">Type</span></span>| <span data-ttu-id="36743-111">説明</span><span class="sxs-lookup"><span data-stu-id="36743-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="36743-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="36743-112">marketplaceId</span></span>| <span data-ttu-id="36743-113">string</span><span class="sxs-lookup"><span data-stu-id="36743-113">string</span></span>| <span data-ttu-id="36743-114">必須。</span><span class="sxs-lookup"><span data-stu-id="36743-114">Required.</span></span> <span data-ttu-id="36743-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="36743-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="36743-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="36743-116">mediaitemtype</span></span>| <span data-ttu-id="36743-117">string</span><span class="sxs-lookup"><span data-stu-id="36743-117">string</span></span>| <span data-ttu-id="36743-118">必須。</span><span class="sxs-lookup"><span data-stu-id="36743-118">Required.</span></span> <span data-ttu-id="36743-119">値のいずれかの[を取得する (/media/{marketplaceId}/メタデータ mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="36743-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="36743-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="36743-120">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="36743-121">Parent</span><span class="sxs-lookup"><span data-stu-id="36743-121">Parent</span></span> 

[<span data-ttu-id="36743-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields</span><span class="sxs-lookup"><span data-stu-id="36743-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields</span></span>](uri-medialocalemetadatamediaitemtypefields.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="36743-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="36743-123">Further Information</span></span> 

[<span data-ttu-id="36743-124">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="36743-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="36743-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="36743-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="36743-126">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="36743-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="36743-127">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="36743-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="36743-128">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="36743-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   