---
title: GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)
assetID: 1bbfdfd7-84e0-68e0-49e8-ba1c60fabaa3
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediagroupsmediaitemtypesget.html
description: " GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c48079e57d4d490ab75e8120eff81c77af855923
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57611447"
---
# <a name="get-mediamarketplaceidmetadatamediagroupsmediagroupmediaitemtypes"></a><span data-ttu-id="ffded-104">GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)</span><span class="sxs-lookup"><span data-stu-id="ffded-104">GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)</span></span>
<span data-ttu-id="ffded-105">EDS の特定のバージョンのメディアのグループごとの使用可能な mediaItemTypes を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="ffded-105">Lists the available mediaItemTypes per media group for the given version of EDS.</span></span> <span data-ttu-id="ffded-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="ffded-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="ffded-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ffded-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="ffded-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ffded-108">URI parameters</span></span>
 
| <span data-ttu-id="ffded-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ffded-109">Parameter</span></span>| <span data-ttu-id="ffded-110">種類</span><span class="sxs-lookup"><span data-stu-id="ffded-110">Type</span></span>| <span data-ttu-id="ffded-111">説明</span><span class="sxs-lookup"><span data-stu-id="ffded-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ffded-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="ffded-112">marketplaceId</span></span>| <span data-ttu-id="ffded-113">string</span><span class="sxs-lookup"><span data-stu-id="ffded-113">string</span></span>| <span data-ttu-id="ffded-114">必須。</span><span class="sxs-lookup"><span data-stu-id="ffded-114">Required.</span></span> <span data-ttu-id="ffded-115">文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。</span><span class="sxs-lookup"><span data-stu-id="ffded-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="ffded-116">mediagroup</span><span class="sxs-lookup"><span data-stu-id="ffded-116">mediagroup</span></span>| <span data-ttu-id="ffded-117">string</span><span class="sxs-lookup"><span data-stu-id="ffded-117">string</span></span>| <span data-ttu-id="ffded-118">必須。</span><span class="sxs-lookup"><span data-stu-id="ffded-118">Required.</span></span> <span data-ttu-id="ffded-119">値の 1 つ[GET (/media/{marketplaceId}/メタデータ/mediaGroups)](uri-medialocalemetadatamediagroupsget.md)します。</span><span class="sxs-lookup"><span data-stu-id="ffded-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups)](uri-medialocalemetadatamediagroupsget.md).</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="ffded-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="ffded-120">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="ffded-121">Parent</span><span class="sxs-lookup"><span data-stu-id="ffded-121">Parent</span></span> 

[<span data-ttu-id="ffded-122">/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes</span><span class="sxs-lookup"><span data-stu-id="ffded-122">/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes</span></span>](uri-medialocalemetadatamediagroupsmediaitemtypes.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="ffded-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="ffded-123">Further Information</span></span> 

[<span data-ttu-id="ffded-124">EDS の一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="ffded-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="ffded-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="ffded-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="ffded-126">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="ffded-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="ffded-127">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="ffded-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="ffded-128">その他の参照</span><span class="sxs-lookup"><span data-stu-id="ffded-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   