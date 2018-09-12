---
title: 取得する (/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaItemType} フィールド/)
assetID: 0ecf27d8-905d-af52-4060-43353d7a3e29
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypefieldsget.html
author: KevinAsgari
description: " 取得する (/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaItemType} フィールド/)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 56dc6067cfe559b5684fa93878e771257ecc8bc0
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882219"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypefields"></a><span data-ttu-id="7a548-104">取得する (/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaItemType} フィールド/)</span><span class="sxs-lookup"><span data-stu-id="7a548-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)</span></span>
<span data-ttu-id="7a548-105">いずれか、特定の mediaitemtype と EDS の特定のバージョンのデータとフィールドの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="7a548-105">Lists fields from which one can expect data, for a given mediaitemtype and a given version of EDS.</span></span> <span data-ttu-id="7a548-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="7a548-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="7a548-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7a548-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="7a548-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7a548-108">URI parameters</span></span>
 
| <span data-ttu-id="7a548-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="7a548-109">Parameter</span></span>| <span data-ttu-id="7a548-110">型</span><span class="sxs-lookup"><span data-stu-id="7a548-110">Type</span></span>| <span data-ttu-id="7a548-111">説明</span><span class="sxs-lookup"><span data-stu-id="7a548-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="7a548-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="7a548-112">marketplaceId</span></span>| <span data-ttu-id="7a548-113">string</span><span class="sxs-lookup"><span data-stu-id="7a548-113">string</span></span>| <span data-ttu-id="7a548-114">必須。</span><span class="sxs-lookup"><span data-stu-id="7a548-114">Required.</span></span> <span data-ttu-id="7a548-115"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="7a548-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="7a548-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="7a548-116">mediaitemtype</span></span>| <span data-ttu-id="7a548-117">string</span><span class="sxs-lookup"><span data-stu-id="7a548-117">string</span></span>| <span data-ttu-id="7a548-118">必須。</span><span class="sxs-lookup"><span data-stu-id="7a548-118">Required.</span></span> <span data-ttu-id="7a548-119">値のいずれか[取得 (/media/{marketplaceId}/メタデータ/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="7a548-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="7a548-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="7a548-120">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="7a548-121">Parent</span><span class="sxs-lookup"><span data-stu-id="7a548-121">Parent</span></span> 

[<span data-ttu-id="7a548-122">/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaItemType}/フィールド</span><span class="sxs-lookup"><span data-stu-id="7a548-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields</span></span>](uri-medialocalemetadatamediaitemtypefields.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="7a548-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="7a548-123">Further Information</span></span> 

[<span data-ttu-id="7a548-124">EDS 一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="7a548-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="7a548-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="7a548-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="7a548-126">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="7a548-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="7a548-127">Marketplace Uri</span><span class="sxs-lookup"><span data-stu-id="7a548-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="7a548-128">その他の参照</span><span class="sxs-lookup"><span data-stu-id="7a548-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   