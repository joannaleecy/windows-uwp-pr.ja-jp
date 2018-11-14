---
title: /media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders
assetID: 221c440d-c448-11e9-f455-6d0f95fc16ef
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypesortorders.html
author: KevinAsgari
description: " /media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 59b2e59315d9b787f75221391c39cdc6a0faf89b
ms.sourcegitcommit: bdc40b08cbcd46fc379feeda3c63204290e055af
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/08/2018
ms.locfileid: "6163628"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypesortorders"></a><span data-ttu-id="66439-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders</span><span class="sxs-lookup"><span data-stu-id="66439-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders</span></span>
<span data-ttu-id="66439-105">利用可能なアクセスは、特定 mediaitem 型と EDS の特定のバージョン向けの注文を並べ替えます。</span><span class="sxs-lookup"><span data-stu-id="66439-105">Accesses available sort orders for a given mediaitem type and a given version of EDS.</span></span> <span data-ttu-id="66439-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="66439-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="66439-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="66439-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="66439-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="66439-108">URI parameters</span></span>
 
| <span data-ttu-id="66439-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="66439-109">Parameter</span></span>| <span data-ttu-id="66439-110">型</span><span class="sxs-lookup"><span data-stu-id="66439-110">Type</span></span>| <span data-ttu-id="66439-111">説明</span><span class="sxs-lookup"><span data-stu-id="66439-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="66439-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="66439-112">marketplaceId</span></span>| <span data-ttu-id="66439-113">string</span><span class="sxs-lookup"><span data-stu-id="66439-113">string</span></span>| <span data-ttu-id="66439-114">必須。</span><span class="sxs-lookup"><span data-stu-id="66439-114">Required.</span></span> <span data-ttu-id="66439-115"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="66439-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="66439-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="66439-116">mediaitemtype</span></span>| <span data-ttu-id="66439-117">string</span><span class="sxs-lookup"><span data-stu-id="66439-117">string</span></span>| <span data-ttu-id="66439-118">必須。</span><span class="sxs-lookup"><span data-stu-id="66439-118">Required.</span></span> <span data-ttu-id="66439-119">値のいずれか[GET (/media/{marketplaceId}//metadata/mediagroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="66439-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EBC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="66439-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="66439-120">Valid methods</span></span>

[<span data-ttu-id="66439-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders)</span><span class="sxs-lookup"><span data-stu-id="66439-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders)</span></span>](uri-medialocalemetadatamediaitemtypesortordersget.md)

<span data-ttu-id="66439-122">&nbsp;&nbsp;Mediaitem の特定の種類と EDS の特定のバージョンで利用可能な並べ替え順の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="66439-122">&nbsp;&nbsp;Lists available sort orders for a given mediaitem type and a given version of EDS.</span></span>
 
<a id="ID4ELC"></a>

 
## <a name="see-also"></a><span data-ttu-id="66439-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="66439-123">See also</span></span>
 
<a id="ID4ENC"></a>

 
##### <a name="parent"></a><span data-ttu-id="66439-124">Parent</span><span class="sxs-lookup"><span data-stu-id="66439-124">Parent</span></span> 

[<span data-ttu-id="66439-125">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="66439-125">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EXC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="66439-126">詳細情報</span><span class="sxs-lookup"><span data-stu-id="66439-126">Further Information</span></span> 

[<span data-ttu-id="66439-127">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="66439-127">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="66439-128">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="66439-128">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="66439-129">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="66439-129">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="66439-130">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="66439-130">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   