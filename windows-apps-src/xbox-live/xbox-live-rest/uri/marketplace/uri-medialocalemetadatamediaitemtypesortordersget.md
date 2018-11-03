---
title: GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders)
assetID: 225e8cb2-44eb-6b7b-eaa0-1ea2d2602f6f
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypesortordersget.html
author: KevinAsgari
description: " GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 070df5fb2bbab51e07dcd4bfb488778c2d6b64c7
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5983120"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypesortorders"></a><span data-ttu-id="0f0a9-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders)</span><span class="sxs-lookup"><span data-stu-id="0f0a9-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders)</span></span>
<span data-ttu-id="0f0a9-105">特定 mediaitem 型と EDS の特定のバージョンで利用可能な並べ替え順の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="0f0a9-105">Lists available sort orders for a given mediaitem type and a given version of EDS.</span></span> <span data-ttu-id="0f0a9-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="0f0a9-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="0f0a9-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0f0a9-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="0f0a9-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0f0a9-108">URI parameters</span></span>
 
| <span data-ttu-id="0f0a9-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="0f0a9-109">Parameter</span></span>| <span data-ttu-id="0f0a9-110">型</span><span class="sxs-lookup"><span data-stu-id="0f0a9-110">Type</span></span>| <span data-ttu-id="0f0a9-111">説明</span><span class="sxs-lookup"><span data-stu-id="0f0a9-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="0f0a9-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="0f0a9-112">marketplaceId</span></span>| <span data-ttu-id="0f0a9-113">string</span><span class="sxs-lookup"><span data-stu-id="0f0a9-113">string</span></span>| <span data-ttu-id="0f0a9-114">必須。</span><span class="sxs-lookup"><span data-stu-id="0f0a9-114">Required.</span></span> <span data-ttu-id="0f0a9-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="0f0a9-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="0f0a9-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="0f0a9-116">mediaitemtype</span></span>| <span data-ttu-id="0f0a9-117">string</span><span class="sxs-lookup"><span data-stu-id="0f0a9-117">string</span></span>| <span data-ttu-id="0f0a9-118">必須。</span><span class="sxs-lookup"><span data-stu-id="0f0a9-118">Required.</span></span> <span data-ttu-id="0f0a9-119">値のいずれかの[GET (/media/{marketplaceId}//metadata/mediagroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="0f0a9-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="0f0a9-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="0f0a9-120">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="0f0a9-121">Parent</span><span class="sxs-lookup"><span data-stu-id="0f0a9-121">Parent</span></span> 

[<span data-ttu-id="0f0a9-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders</span><span class="sxs-lookup"><span data-stu-id="0f0a9-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders</span></span>](uri-medialocalemetadatamediaitemtypesortorders.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="0f0a9-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="0f0a9-123">Further Information</span></span> 

[<span data-ttu-id="0f0a9-124">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0f0a9-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="0f0a9-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="0f0a9-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="0f0a9-126">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="0f0a9-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="0f0a9-127">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="0f0a9-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="0f0a9-128">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="0f0a9-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   