---
title: GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)
assetID: 1bbfdfd7-84e0-68e0-49e8-ba1c60fabaa3
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediagroupsmediaitemtypesget.html
author: KevinAsgari
description: " GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f9131026fe64f18ded49fa7394b54696dbbc44f8
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4687212"
---
# <a name="get-mediamarketplaceidmetadatamediagroupsmediagroupmediaitemtypes"></a><span data-ttu-id="db5d4-104">GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)</span><span class="sxs-lookup"><span data-stu-id="db5d4-104">GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)</span></span>
<span data-ttu-id="db5d4-105">EDS の特定のバージョンのメディアのグループごとの利用可能な mediaItemTypes の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="db5d4-105">Lists the available mediaItemTypes per media group for the given version of EDS.</span></span> <span data-ttu-id="db5d4-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="db5d4-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="db5d4-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="db5d4-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="db5d4-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="db5d4-108">URI parameters</span></span>
 
| <span data-ttu-id="db5d4-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="db5d4-109">Parameter</span></span>| <span data-ttu-id="db5d4-110">型</span><span class="sxs-lookup"><span data-stu-id="db5d4-110">Type</span></span>| <span data-ttu-id="db5d4-111">説明</span><span class="sxs-lookup"><span data-stu-id="db5d4-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="db5d4-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="db5d4-112">marketplaceId</span></span>| <span data-ttu-id="db5d4-113">string</span><span class="sxs-lookup"><span data-stu-id="db5d4-113">string</span></span>| <span data-ttu-id="db5d4-114">必須。</span><span class="sxs-lookup"><span data-stu-id="db5d4-114">Required.</span></span> <span data-ttu-id="db5d4-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="db5d4-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="db5d4-116">mediagroup</span><span class="sxs-lookup"><span data-stu-id="db5d4-116">mediagroup</span></span>| <span data-ttu-id="db5d4-117">string</span><span class="sxs-lookup"><span data-stu-id="db5d4-117">string</span></span>| <span data-ttu-id="db5d4-118">必須。</span><span class="sxs-lookup"><span data-stu-id="db5d4-118">Required.</span></span> <span data-ttu-id="db5d4-119">[GET (/media/{marketplaceId} メタデータ/mediaGroups)](uri-medialocalemetadatamediagroupsget.md)からの値のいずれか。</span><span class="sxs-lookup"><span data-stu-id="db5d4-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups)](uri-medialocalemetadatamediagroupsget.md).</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="db5d4-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="db5d4-120">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="db5d4-121">Parent</span><span class="sxs-lookup"><span data-stu-id="db5d4-121">Parent</span></span> 

[<span data-ttu-id="db5d4-122">/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes</span><span class="sxs-lookup"><span data-stu-id="db5d4-122">/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes</span></span>](uri-medialocalemetadatamediagroupsmediaitemtypes.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="db5d4-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="db5d4-123">Further Information</span></span> 

[<span data-ttu-id="db5d4-124">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="db5d4-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="db5d4-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="db5d4-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="db5d4-126">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="db5d4-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="db5d4-127">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="db5d4-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="db5d4-128">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="db5d4-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   