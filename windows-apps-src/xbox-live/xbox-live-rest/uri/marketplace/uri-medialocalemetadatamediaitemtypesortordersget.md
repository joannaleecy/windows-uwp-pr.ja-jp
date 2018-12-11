---
title: GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders)
assetID: 225e8cb2-44eb-6b7b-eaa0-1ea2d2602f6f
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypesortordersget.html
description: " GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5cec9bf585e1d885c4c1b6950e94923908cc06e8
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8930300"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypesortorders"></a><span data-ttu-id="b686c-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders)</span><span class="sxs-lookup"><span data-stu-id="b686c-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders)</span></span>
<span data-ttu-id="b686c-105">Mediaitem の特定の種類と EDS の特定のバージョンで利用可能な並べ替え順の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="b686c-105">Lists available sort orders for a given mediaitem type and a given version of EDS.</span></span> <span data-ttu-id="b686c-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b686c-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="b686c-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b686c-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="b686c-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b686c-108">URI parameters</span></span>
 
| <span data-ttu-id="b686c-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b686c-109">Parameter</span></span>| <span data-ttu-id="b686c-110">型</span><span class="sxs-lookup"><span data-stu-id="b686c-110">Type</span></span>| <span data-ttu-id="b686c-111">説明</span><span class="sxs-lookup"><span data-stu-id="b686c-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b686c-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="b686c-112">marketplaceId</span></span>| <span data-ttu-id="b686c-113">string</span><span class="sxs-lookup"><span data-stu-id="b686c-113">string</span></span>| <span data-ttu-id="b686c-114">必須。</span><span class="sxs-lookup"><span data-stu-id="b686c-114">Required.</span></span> <span data-ttu-id="b686c-115"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="b686c-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="b686c-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="b686c-116">mediaitemtype</span></span>| <span data-ttu-id="b686c-117">string</span><span class="sxs-lookup"><span data-stu-id="b686c-117">string</span></span>| <span data-ttu-id="b686c-118">必須。</span><span class="sxs-lookup"><span data-stu-id="b686c-118">Required.</span></span> <span data-ttu-id="b686c-119">値のいずれか[GET (/media/{marketplaceId}//metadata/mediagroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="b686c-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="b686c-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="b686c-120">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="b686c-121">Parent</span><span class="sxs-lookup"><span data-stu-id="b686c-121">Parent</span></span> 

[<span data-ttu-id="b686c-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders</span><span class="sxs-lookup"><span data-stu-id="b686c-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders</span></span>](uri-medialocalemetadatamediaitemtypesortorders.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="b686c-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="b686c-123">Further Information</span></span> 

[<span data-ttu-id="b686c-124">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b686c-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="b686c-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="b686c-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="b686c-126">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="b686c-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="b686c-127">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="b686c-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="b686c-128">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="b686c-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   