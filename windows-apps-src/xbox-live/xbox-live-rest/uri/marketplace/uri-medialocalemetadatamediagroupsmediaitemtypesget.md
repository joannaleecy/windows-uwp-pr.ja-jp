---
title: GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)
assetID: 1bbfdfd7-84e0-68e0-49e8-ba1c60fabaa3
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediagroupsmediaitemtypesget.html
author: KevinAsgari
description: " GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a7ad60197979e24c5ed89e768aba916189cc0918
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7164946"
---
# <a name="get-mediamarketplaceidmetadatamediagroupsmediagroupmediaitemtypes"></a><span data-ttu-id="6b901-104">GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)</span><span class="sxs-lookup"><span data-stu-id="6b901-104">GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)</span></span>
<span data-ttu-id="6b901-105">EDS の特定のバージョンのメディアのグループごとの利用可能な mediaItemTypes の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="6b901-105">Lists the available mediaItemTypes per media group for the given version of EDS.</span></span> <span data-ttu-id="6b901-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="6b901-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="6b901-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6b901-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="6b901-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6b901-108">URI parameters</span></span>
 
| <span data-ttu-id="6b901-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="6b901-109">Parameter</span></span>| <span data-ttu-id="6b901-110">型</span><span class="sxs-lookup"><span data-stu-id="6b901-110">Type</span></span>| <span data-ttu-id="6b901-111">説明</span><span class="sxs-lookup"><span data-stu-id="6b901-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="6b901-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="6b901-112">marketplaceId</span></span>| <span data-ttu-id="6b901-113">string</span><span class="sxs-lookup"><span data-stu-id="6b901-113">string</span></span>| <span data-ttu-id="6b901-114">必須。</span><span class="sxs-lookup"><span data-stu-id="6b901-114">Required.</span></span> <span data-ttu-id="6b901-115"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="6b901-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="6b901-116">mediagroup</span><span class="sxs-lookup"><span data-stu-id="6b901-116">mediagroup</span></span>| <span data-ttu-id="6b901-117">string</span><span class="sxs-lookup"><span data-stu-id="6b901-117">string</span></span>| <span data-ttu-id="6b901-118">必須。</span><span class="sxs-lookup"><span data-stu-id="6b901-118">Required.</span></span> <span data-ttu-id="6b901-119">[GET (/media/{marketplaceId} メタデータ/mediaGroups)](uri-medialocalemetadatamediagroupsget.md)からの値のいずれか。</span><span class="sxs-lookup"><span data-stu-id="6b901-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups)](uri-medialocalemetadatamediagroupsget.md).</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="6b901-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="6b901-120">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="6b901-121">Parent</span><span class="sxs-lookup"><span data-stu-id="6b901-121">Parent</span></span> 

[<span data-ttu-id="6b901-122">/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes</span><span class="sxs-lookup"><span data-stu-id="6b901-122">/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes</span></span>](uri-medialocalemetadatamediagroupsmediaitemtypes.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="6b901-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="6b901-123">Further Information</span></span> 

[<span data-ttu-id="6b901-124">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6b901-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="6b901-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="6b901-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="6b901-126">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="6b901-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="6b901-127">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="6b901-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="6b901-128">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="6b901-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   