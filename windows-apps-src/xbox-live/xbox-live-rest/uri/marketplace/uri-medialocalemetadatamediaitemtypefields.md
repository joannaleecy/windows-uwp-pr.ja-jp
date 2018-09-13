---
title: /media/{marketplaceId}/メタデータ mediaItemTypes/{mediaItemType} フィールド/
assetID: fc9b556a-7fc7-64ec-cb5c-b5cabd2ab4ce
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypefields.html
author: KevinAsgari
description: " /media/{marketplaceId}/メタデータ mediaItemTypes/{mediaItemType} フィールド/"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f5bdcb8b854a8b71f232c8a1cc73cd12bc587015
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3957309"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypefields"></a><span data-ttu-id="4bcc4-104">/media/{marketplaceId}/メタデータ mediaItemTypes/{mediaItemType} フィールド/</span><span class="sxs-lookup"><span data-stu-id="4bcc4-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields</span></span>
<span data-ttu-id="4bcc4-105">指定された mediaitemtype と EDS の特定のバージョンのデータを期待いずれかからアクセス フィールド。</span><span class="sxs-lookup"><span data-stu-id="4bcc4-105">Accesses fields from which one can expect data, for a given mediaitemtype and a given version of EDS.</span></span> <span data-ttu-id="4bcc4-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="4bcc4-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="4bcc4-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4bcc4-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="4bcc4-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4bcc4-108">URI parameters</span></span>
 
| <span data-ttu-id="4bcc4-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="4bcc4-109">Parameter</span></span>| <span data-ttu-id="4bcc4-110">型</span><span class="sxs-lookup"><span data-stu-id="4bcc4-110">Type</span></span>| <span data-ttu-id="4bcc4-111">説明</span><span class="sxs-lookup"><span data-stu-id="4bcc4-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="4bcc4-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="4bcc4-112">marketplaceId</span></span>| <span data-ttu-id="4bcc4-113">string</span><span class="sxs-lookup"><span data-stu-id="4bcc4-113">string</span></span>| <span data-ttu-id="4bcc4-114">必須。</span><span class="sxs-lookup"><span data-stu-id="4bcc4-114">Required.</span></span> <span data-ttu-id="4bcc4-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="4bcc4-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="4bcc4-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="4bcc4-116">mediaitemtype</span></span>| <span data-ttu-id="4bcc4-117">string</span><span class="sxs-lookup"><span data-stu-id="4bcc4-117">string</span></span>| <span data-ttu-id="4bcc4-118">必須。</span><span class="sxs-lookup"><span data-stu-id="4bcc4-118">Required.</span></span> <span data-ttu-id="4bcc4-119">値のいずれかの[を取得する (/media/{marketplaceId}/メタデータ mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="4bcc4-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EBC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="4bcc4-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="4bcc4-120">Valid methods</span></span>

[<span data-ttu-id="4bcc4-121">取得する (/media/{marketplaceId}/メタデータ mediaItemTypes/{mediaItemType}/フィールド)</span><span class="sxs-lookup"><span data-stu-id="4bcc4-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)</span></span>](uri-medialocalemetadatamediaitemtypefieldsget.md)

<span data-ttu-id="4bcc4-122">&nbsp;&nbsp;指定された mediaitemtype と EDS の特定のバージョンのデータを期待いずれかからフィールドを示します。</span><span class="sxs-lookup"><span data-stu-id="4bcc4-122">&nbsp;&nbsp;Lists fields from which one can expect data, for a given mediaitemtype and a given version of EDS.</span></span>
 
<a id="ID4ELC"></a>

 
## <a name="see-also"></a><span data-ttu-id="4bcc4-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="4bcc4-123">See also</span></span>
 
<a id="ID4ENC"></a>

 
##### <a name="parent"></a><span data-ttu-id="4bcc4-124">Parent</span><span class="sxs-lookup"><span data-stu-id="4bcc4-124">Parent</span></span> 

[<span data-ttu-id="4bcc4-125">Marketplace Uri</span><span class="sxs-lookup"><span data-stu-id="4bcc4-125">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EXC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="4bcc4-126">詳細情報</span><span class="sxs-lookup"><span data-stu-id="4bcc4-126">Further Information</span></span> 

[<span data-ttu-id="4bcc4-127">EDS 一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="4bcc4-127">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="4bcc4-128">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="4bcc4-128">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="4bcc4-129">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="4bcc4-129">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="4bcc4-130">その他の参照</span><span class="sxs-lookup"><span data-stu-id="4bcc4-130">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   