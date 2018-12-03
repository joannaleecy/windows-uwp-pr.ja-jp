---
title: GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)
assetID: 0bbdfecd-5bf3-3e68-8855-12fe6701dbee
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypequeryrefinersget.html
description: " GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d4f35406dc8b9c290308c8990efa66f67c081c9f
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8346950"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefiners"></a><span data-ttu-id="cd7b3-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)</span><span class="sxs-lookup"><span data-stu-id="cd7b3-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)</span></span>
<span data-ttu-id="cd7b3-105">指定したメディア項目の種類のクエリの絞り込み条件の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="cd7b3-105">Lists the query refiners for the given media item type.</span></span> <span data-ttu-id="cd7b3-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="cd7b3-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="cd7b3-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cd7b3-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="cd7b3-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cd7b3-108">URI parameters</span></span>
 
| <span data-ttu-id="cd7b3-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="cd7b3-109">Parameter</span></span>| <span data-ttu-id="cd7b3-110">型</span><span class="sxs-lookup"><span data-stu-id="cd7b3-110">Type</span></span>| <span data-ttu-id="cd7b3-111">説明</span><span class="sxs-lookup"><span data-stu-id="cd7b3-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="cd7b3-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="cd7b3-112">marketplaceId</span></span>| <span data-ttu-id="cd7b3-113">string</span><span class="sxs-lookup"><span data-stu-id="cd7b3-113">string</span></span>| <span data-ttu-id="cd7b3-114">必須。</span><span class="sxs-lookup"><span data-stu-id="cd7b3-114">Required.</span></span> <span data-ttu-id="cd7b3-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="cd7b3-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="cd7b3-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="cd7b3-116">mediaitemtype</span></span>| <span data-ttu-id="cd7b3-117">string</span><span class="sxs-lookup"><span data-stu-id="cd7b3-117">string</span></span>| <span data-ttu-id="cd7b3-118">必須。</span><span class="sxs-lookup"><span data-stu-id="cd7b3-118">Required.</span></span> <span data-ttu-id="cd7b3-119">値のいずれかの[GET (/media/{marketplaceId}//metadata/mediagroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="cd7b3-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="cd7b3-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="cd7b3-120">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="cd7b3-121">Parent</span><span class="sxs-lookup"><span data-stu-id="cd7b3-121">Parent</span></span> 

[<span data-ttu-id="cd7b3-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span><span class="sxs-lookup"><span data-stu-id="cd7b3-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span></span>](uri-medialocalemetadatamediaitemtypequeryrefiners.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="cd7b3-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="cd7b3-123">Further Information</span></span> 

[<span data-ttu-id="cd7b3-124">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd7b3-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="cd7b3-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="cd7b3-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="cd7b3-126">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="cd7b3-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="cd7b3-127">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="cd7b3-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="cd7b3-128">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="cd7b3-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   