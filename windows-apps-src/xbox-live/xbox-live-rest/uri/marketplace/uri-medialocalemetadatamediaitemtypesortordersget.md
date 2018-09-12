---
title: 取得する (/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/sortorders)
assetID: 225e8cb2-44eb-6b7b-eaa0-1ea2d2602f6f
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypesortordersget.html
author: KevinAsgari
description: " 取得する (/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/sortorders)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 656a8df9a810252e4bc77f1537428ae0104ef98f
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881602"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypesortorders"></a><span data-ttu-id="b6f81-104">取得する (/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/sortorders)</span><span class="sxs-lookup"><span data-stu-id="b6f81-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders)</span></span>
<span data-ttu-id="b6f81-105">特定 mediaitem 型と EDS の特定のバージョンで利用可能な並べ替え順の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="b6f81-105">Lists available sort orders for a given mediaitem type and a given version of EDS.</span></span> <span data-ttu-id="b6f81-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b6f81-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="b6f81-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b6f81-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="b6f81-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b6f81-108">URI parameters</span></span>
 
| <span data-ttu-id="b6f81-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b6f81-109">Parameter</span></span>| <span data-ttu-id="b6f81-110">型</span><span class="sxs-lookup"><span data-stu-id="b6f81-110">Type</span></span>| <span data-ttu-id="b6f81-111">説明</span><span class="sxs-lookup"><span data-stu-id="b6f81-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b6f81-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="b6f81-112">marketplaceId</span></span>| <span data-ttu-id="b6f81-113">string</span><span class="sxs-lookup"><span data-stu-id="b6f81-113">string</span></span>| <span data-ttu-id="b6f81-114">必須。</span><span class="sxs-lookup"><span data-stu-id="b6f81-114">Required.</span></span> <span data-ttu-id="b6f81-115"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="b6f81-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="b6f81-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="b6f81-116">mediaitemtype</span></span>| <span data-ttu-id="b6f81-117">string</span><span class="sxs-lookup"><span data-stu-id="b6f81-117">string</span></span>| <span data-ttu-id="b6f81-118">必須。</span><span class="sxs-lookup"><span data-stu-id="b6f81-118">Required.</span></span> <span data-ttu-id="b6f81-119">値のいずれか[取得 (/media/{marketplaceId}/メタデータ/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="b6f81-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="b6f81-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="b6f81-120">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="b6f81-121">Parent</span><span class="sxs-lookup"><span data-stu-id="b6f81-121">Parent</span></span> 

[<span data-ttu-id="b6f81-122">/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/sortorders</span><span class="sxs-lookup"><span data-stu-id="b6f81-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders</span></span>](uri-medialocalemetadatamediaitemtypesortorders.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="b6f81-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="b6f81-123">Further Information</span></span> 

[<span data-ttu-id="b6f81-124">EDS 一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="b6f81-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="b6f81-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="b6f81-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="b6f81-126">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="b6f81-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="b6f81-127">Marketplace Uri</span><span class="sxs-lookup"><span data-stu-id="b6f81-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="b6f81-128">その他の参照</span><span class="sxs-lookup"><span data-stu-id="b6f81-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   