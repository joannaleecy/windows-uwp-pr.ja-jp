---
title: GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)
assetID: 0bbdfecd-5bf3-3e68-8855-12fe6701dbee
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypequeryrefinersget.html
author: KevinAsgari
description: " GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 103ca7677777cd874cc0b5a4e771952e6ac03498
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7160783"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefiners"></a><span data-ttu-id="4e11a-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)</span><span class="sxs-lookup"><span data-stu-id="4e11a-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)</span></span>
<span data-ttu-id="4e11a-105">指定したメディア項目の種類のクエリの絞り込み条件の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="4e11a-105">Lists the query refiners for the given media item type.</span></span> <span data-ttu-id="4e11a-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="4e11a-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="4e11a-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4e11a-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="4e11a-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4e11a-108">URI parameters</span></span>
 
| <span data-ttu-id="4e11a-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="4e11a-109">Parameter</span></span>| <span data-ttu-id="4e11a-110">型</span><span class="sxs-lookup"><span data-stu-id="4e11a-110">Type</span></span>| <span data-ttu-id="4e11a-111">説明</span><span class="sxs-lookup"><span data-stu-id="4e11a-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="4e11a-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="4e11a-112">marketplaceId</span></span>| <span data-ttu-id="4e11a-113">string</span><span class="sxs-lookup"><span data-stu-id="4e11a-113">string</span></span>| <span data-ttu-id="4e11a-114">必須。</span><span class="sxs-lookup"><span data-stu-id="4e11a-114">Required.</span></span> <span data-ttu-id="4e11a-115"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="4e11a-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="4e11a-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="4e11a-116">mediaitemtype</span></span>| <span data-ttu-id="4e11a-117">string</span><span class="sxs-lookup"><span data-stu-id="4e11a-117">string</span></span>| <span data-ttu-id="4e11a-118">必須。</span><span class="sxs-lookup"><span data-stu-id="4e11a-118">Required.</span></span> <span data-ttu-id="4e11a-119">値のいずれか[GET (/media/{marketplaceId}//metadata/mediagroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="4e11a-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="4e11a-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="4e11a-120">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="4e11a-121">Parent</span><span class="sxs-lookup"><span data-stu-id="4e11a-121">Parent</span></span> 

[<span data-ttu-id="4e11a-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span><span class="sxs-lookup"><span data-stu-id="4e11a-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span></span>](uri-medialocalemetadatamediaitemtypequeryrefiners.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="4e11a-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="4e11a-123">Further Information</span></span> 

[<span data-ttu-id="4e11a-124">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="4e11a-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="4e11a-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="4e11a-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="4e11a-126">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="4e11a-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="4e11a-127">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="4e11a-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="4e11a-128">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="4e11a-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   