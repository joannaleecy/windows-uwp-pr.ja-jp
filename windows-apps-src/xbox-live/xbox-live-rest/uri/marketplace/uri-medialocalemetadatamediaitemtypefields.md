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
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5919469"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypefields"></a><span data-ttu-id="82cdd-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields</span><span class="sxs-lookup"><span data-stu-id="82cdd-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields</span></span>
<span data-ttu-id="82cdd-105">指定された mediaitemtype と EDS の特定のバージョンのデータを想定いずれかからアクセス フィールド。</span><span class="sxs-lookup"><span data-stu-id="82cdd-105">Accesses fields from which one can expect data, for a given mediaitemtype and a given version of EDS.</span></span> <span data-ttu-id="82cdd-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="82cdd-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="82cdd-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="82cdd-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="82cdd-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="82cdd-108">URI parameters</span></span>
 
| <span data-ttu-id="82cdd-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="82cdd-109">Parameter</span></span>| <span data-ttu-id="82cdd-110">型</span><span class="sxs-lookup"><span data-stu-id="82cdd-110">Type</span></span>| <span data-ttu-id="82cdd-111">説明</span><span class="sxs-lookup"><span data-stu-id="82cdd-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="82cdd-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="82cdd-112">marketplaceId</span></span>| <span data-ttu-id="82cdd-113">string</span><span class="sxs-lookup"><span data-stu-id="82cdd-113">string</span></span>| <span data-ttu-id="82cdd-114">必須。</span><span class="sxs-lookup"><span data-stu-id="82cdd-114">Required.</span></span> <span data-ttu-id="82cdd-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="82cdd-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="82cdd-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="82cdd-116">mediaitemtype</span></span>| <span data-ttu-id="82cdd-117">string</span><span class="sxs-lookup"><span data-stu-id="82cdd-117">string</span></span>| <span data-ttu-id="82cdd-118">必須。</span><span class="sxs-lookup"><span data-stu-id="82cdd-118">Required.</span></span> <span data-ttu-id="82cdd-119">値のいずれかの[GET (/media/{marketplaceId}//metadata/mediagroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="82cdd-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EBC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="82cdd-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="82cdd-120">Valid methods</span></span>

[<span data-ttu-id="82cdd-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)</span><span class="sxs-lookup"><span data-stu-id="82cdd-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)</span></span>](uri-medialocalemetadatamediaitemtypefieldsget.md)

<span data-ttu-id="82cdd-122">&nbsp;&nbsp;指定された mediaitemtype と EDS の特定のバージョンのデータを想定いずれかからフィールドを示します。</span><span class="sxs-lookup"><span data-stu-id="82cdd-122">&nbsp;&nbsp;Lists fields from which one can expect data, for a given mediaitemtype and a given version of EDS.</span></span>
 
<a id="ID4ELC"></a>

 
## <a name="see-also"></a><span data-ttu-id="82cdd-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="82cdd-123">See also</span></span>
 
<a id="ID4ENC"></a>

 
##### <a name="parent"></a><span data-ttu-id="82cdd-124">Parent</span><span class="sxs-lookup"><span data-stu-id="82cdd-124">Parent</span></span> 

[<span data-ttu-id="82cdd-125">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="82cdd-125">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EXC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="82cdd-126">詳細情報</span><span class="sxs-lookup"><span data-stu-id="82cdd-126">Further Information</span></span> 

[<span data-ttu-id="82cdd-127">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="82cdd-127">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="82cdd-128">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="82cdd-128">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="82cdd-129">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="82cdd-129">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="82cdd-130">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="82cdd-130">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   