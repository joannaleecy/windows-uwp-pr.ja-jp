---
title: GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)
assetID: 0ecf27d8-905d-af52-4060-43353d7a3e29
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypefieldsget.html
description: " GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 70b43719f3daa86f8e34289545e454cb5d209545
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8337821"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypefields"></a><span data-ttu-id="ed293-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)</span><span class="sxs-lookup"><span data-stu-id="ed293-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields)</span></span>
<span data-ttu-id="ed293-105">指定された mediaitemtype と EDS の特定のバージョンのデータを期待いずれかからフィールドを示します。</span><span class="sxs-lookup"><span data-stu-id="ed293-105">Lists fields from which one can expect data, for a given mediaitemtype and a given version of EDS.</span></span> <span data-ttu-id="ed293-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="ed293-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="ed293-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ed293-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="ed293-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ed293-108">URI parameters</span></span>
 
| <span data-ttu-id="ed293-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ed293-109">Parameter</span></span>| <span data-ttu-id="ed293-110">型</span><span class="sxs-lookup"><span data-stu-id="ed293-110">Type</span></span>| <span data-ttu-id="ed293-111">説明</span><span class="sxs-lookup"><span data-stu-id="ed293-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ed293-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="ed293-112">marketplaceId</span></span>| <span data-ttu-id="ed293-113">string</span><span class="sxs-lookup"><span data-stu-id="ed293-113">string</span></span>| <span data-ttu-id="ed293-114">必須。</span><span class="sxs-lookup"><span data-stu-id="ed293-114">Required.</span></span> <span data-ttu-id="ed293-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="ed293-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="ed293-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="ed293-116">mediaitemtype</span></span>| <span data-ttu-id="ed293-117">string</span><span class="sxs-lookup"><span data-stu-id="ed293-117">string</span></span>| <span data-ttu-id="ed293-118">必須。</span><span class="sxs-lookup"><span data-stu-id="ed293-118">Required.</span></span> <span data-ttu-id="ed293-119">値のいずれかの[GET (/media/{marketplaceId}//metadata/mediagroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="ed293-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="ed293-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="ed293-120">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="ed293-121">Parent</span><span class="sxs-lookup"><span data-stu-id="ed293-121">Parent</span></span> 

[<span data-ttu-id="ed293-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields</span><span class="sxs-lookup"><span data-stu-id="ed293-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaItemType}/fields</span></span>](uri-medialocalemetadatamediaitemtypefields.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="ed293-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="ed293-123">Further Information</span></span> 

[<span data-ttu-id="ed293-124">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ed293-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="ed293-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="ed293-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="ed293-126">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="ed293-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="ed293-127">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="ed293-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="ed293-128">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="ed293-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   