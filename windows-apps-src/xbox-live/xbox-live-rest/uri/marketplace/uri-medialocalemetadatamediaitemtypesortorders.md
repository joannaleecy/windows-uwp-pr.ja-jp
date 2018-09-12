---
title: /media/{marketplaceId}/メタデータ mediaItemTypes/{mediaitemtype}/sortorders
assetID: 221c440d-c448-11e9-f455-6d0f95fc16ef
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypesortorders.html
author: KevinAsgari
description: " /media/{marketplaceId}/メタデータ mediaItemTypes/{mediaitemtype}/sortorders"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c453dc1800770547623fc4920f6d2c964a4b2f88
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3932178"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypesortorders"></a><span data-ttu-id="18fa5-104">/media/{marketplaceId}/メタデータ mediaItemTypes/{mediaitemtype}/sortorders</span><span class="sxs-lookup"><span data-stu-id="18fa5-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders</span></span>
<span data-ttu-id="18fa5-105">利用可能なアクセスは、特定 mediaitem 型と EDS の特定のバージョン向けの注文を並べ替えます。</span><span class="sxs-lookup"><span data-stu-id="18fa5-105">Accesses available sort orders for a given mediaitem type and a given version of EDS.</span></span> <span data-ttu-id="18fa5-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="18fa5-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="18fa5-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="18fa5-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="18fa5-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="18fa5-108">URI parameters</span></span>
 
| <span data-ttu-id="18fa5-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="18fa5-109">Parameter</span></span>| <span data-ttu-id="18fa5-110">型</span><span class="sxs-lookup"><span data-stu-id="18fa5-110">Type</span></span>| <span data-ttu-id="18fa5-111">説明</span><span class="sxs-lookup"><span data-stu-id="18fa5-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="18fa5-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="18fa5-112">marketplaceId</span></span>| <span data-ttu-id="18fa5-113">string</span><span class="sxs-lookup"><span data-stu-id="18fa5-113">string</span></span>| <span data-ttu-id="18fa5-114">必須。</span><span class="sxs-lookup"><span data-stu-id="18fa5-114">Required.</span></span> <span data-ttu-id="18fa5-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="18fa5-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="18fa5-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="18fa5-116">mediaitemtype</span></span>| <span data-ttu-id="18fa5-117">string</span><span class="sxs-lookup"><span data-stu-id="18fa5-117">string</span></span>| <span data-ttu-id="18fa5-118">必須。</span><span class="sxs-lookup"><span data-stu-id="18fa5-118">Required.</span></span> <span data-ttu-id="18fa5-119">値のいずれかの[を取得する (/media/{marketplaceId}/メタデータ mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="18fa5-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EBC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="18fa5-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="18fa5-120">Valid methods</span></span>

[<span data-ttu-id="18fa5-121">取得する (/media/{marketplaceId}/メタデータ mediaItemTypes/{mediaitemtype}/sortorders)</span><span class="sxs-lookup"><span data-stu-id="18fa5-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders)</span></span>](uri-medialocalemetadatamediaitemtypesortordersget.md)

<span data-ttu-id="18fa5-122">&nbsp;&nbsp;特定 mediaitem 型と EDS の特定のバージョンで利用可能な並べ替え順の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="18fa5-122">&nbsp;&nbsp;Lists available sort orders for a given mediaitem type and a given version of EDS.</span></span>
 
<a id="ID4ELC"></a>

 
## <a name="see-also"></a><span data-ttu-id="18fa5-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="18fa5-123">See also</span></span>
 
<a id="ID4ENC"></a>

 
##### <a name="parent"></a><span data-ttu-id="18fa5-124">Parent</span><span class="sxs-lookup"><span data-stu-id="18fa5-124">Parent</span></span> 

[<span data-ttu-id="18fa5-125">Marketplace Uri</span><span class="sxs-lookup"><span data-stu-id="18fa5-125">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EXC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="18fa5-126">詳細情報</span><span class="sxs-lookup"><span data-stu-id="18fa5-126">Further Information</span></span> 

[<span data-ttu-id="18fa5-127">EDS 一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="18fa5-127">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="18fa5-128">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="18fa5-128">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="18fa5-129">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="18fa5-129">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="18fa5-130">その他の参照</span><span class="sxs-lookup"><span data-stu-id="18fa5-130">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   