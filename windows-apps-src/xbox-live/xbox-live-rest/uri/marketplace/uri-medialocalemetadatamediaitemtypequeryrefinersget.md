---
title: GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)
assetID: 0bbdfecd-5bf3-3e68-8855-12fe6701dbee
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypequeryrefinersget.html
author: KevinAsgari
description: " GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0aab24ca7ebb5df367ba2d594b909b3ab6668f76
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4019077"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefiners"></a><span data-ttu-id="3c8b1-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)</span><span class="sxs-lookup"><span data-stu-id="3c8b1-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)</span></span>
<span data-ttu-id="3c8b1-105">指定したメディア項目の種類のクエリの絞り込み条件の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="3c8b1-105">Lists the query refiners for the given media item type.</span></span> <span data-ttu-id="3c8b1-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="3c8b1-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="3c8b1-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3c8b1-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="3c8b1-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3c8b1-108">URI parameters</span></span>
 
| <span data-ttu-id="3c8b1-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3c8b1-109">Parameter</span></span>| <span data-ttu-id="3c8b1-110">型</span><span class="sxs-lookup"><span data-stu-id="3c8b1-110">Type</span></span>| <span data-ttu-id="3c8b1-111">説明</span><span class="sxs-lookup"><span data-stu-id="3c8b1-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="3c8b1-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="3c8b1-112">marketplaceId</span></span>| <span data-ttu-id="3c8b1-113">string</span><span class="sxs-lookup"><span data-stu-id="3c8b1-113">string</span></span>| <span data-ttu-id="3c8b1-114">必須。</span><span class="sxs-lookup"><span data-stu-id="3c8b1-114">Required.</span></span> <span data-ttu-id="3c8b1-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="3c8b1-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="3c8b1-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="3c8b1-116">mediaitemtype</span></span>| <span data-ttu-id="3c8b1-117">string</span><span class="sxs-lookup"><span data-stu-id="3c8b1-117">string</span></span>| <span data-ttu-id="3c8b1-118">必須。</span><span class="sxs-lookup"><span data-stu-id="3c8b1-118">Required.</span></span> <span data-ttu-id="3c8b1-119">値のいずれかの[を取得する (/media/{marketplaceId}/メタデータ mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="3c8b1-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="3c8b1-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="3c8b1-120">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="3c8b1-121">Parent</span><span class="sxs-lookup"><span data-stu-id="3c8b1-121">Parent</span></span> 

[<span data-ttu-id="3c8b1-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span><span class="sxs-lookup"><span data-stu-id="3c8b1-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span></span>](uri-medialocalemetadatamediaitemtypequeryrefiners.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="3c8b1-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="3c8b1-123">Further Information</span></span> 

[<span data-ttu-id="3c8b1-124">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3c8b1-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="3c8b1-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="3c8b1-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="3c8b1-126">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="3c8b1-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="3c8b1-127">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="3c8b1-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="3c8b1-128">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="3c8b1-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   