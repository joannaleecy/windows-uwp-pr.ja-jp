---
title: 取得する (/media/{marketplaceId}/メタデータ/mediaGroups/{mediagroup}/mediaItemTypes)
assetID: 1bbfdfd7-84e0-68e0-49e8-ba1c60fabaa3
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediagroupsmediaitemtypesget.html
author: KevinAsgari
description: " 取得する (/media/{marketplaceId}/メタデータ/mediaGroups/{mediagroup}/mediaItemTypes)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f9131026fe64f18ded49fa7394b54696dbbc44f8
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882168"
---
# <a name="get-mediamarketplaceidmetadatamediagroupsmediagroupmediaitemtypes"></a><span data-ttu-id="d909d-104">取得する (/media/{marketplaceId}/メタデータ/mediaGroups/{mediagroup}/mediaItemTypes)</span><span class="sxs-lookup"><span data-stu-id="d909d-104">GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)</span></span>
<span data-ttu-id="d909d-105">指定されたバージョン EDS のメディアのグループごとの利用可能な mediaItemTypes の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="d909d-105">Lists the available mediaItemTypes per media group for the given version of EDS.</span></span> <span data-ttu-id="d909d-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="d909d-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="d909d-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d909d-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="d909d-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d909d-108">URI parameters</span></span>
 
| <span data-ttu-id="d909d-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d909d-109">Parameter</span></span>| <span data-ttu-id="d909d-110">型</span><span class="sxs-lookup"><span data-stu-id="d909d-110">Type</span></span>| <span data-ttu-id="d909d-111">説明</span><span class="sxs-lookup"><span data-stu-id="d909d-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d909d-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="d909d-112">marketplaceId</span></span>| <span data-ttu-id="d909d-113">string</span><span class="sxs-lookup"><span data-stu-id="d909d-113">string</span></span>| <span data-ttu-id="d909d-114">必須。</span><span class="sxs-lookup"><span data-stu-id="d909d-114">Required.</span></span> <span data-ttu-id="d909d-115"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="d909d-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="d909d-116">mediagroup</span><span class="sxs-lookup"><span data-stu-id="d909d-116">mediagroup</span></span>| <span data-ttu-id="d909d-117">string</span><span class="sxs-lookup"><span data-stu-id="d909d-117">string</span></span>| <span data-ttu-id="d909d-118">必須。</span><span class="sxs-lookup"><span data-stu-id="d909d-118">Required.</span></span> <span data-ttu-id="d909d-119">[取得 (/media/{marketplaceId}/メタデータ/mediaGroups)](uri-medialocalemetadatamediagroupsget.md)からの値のいずれか。</span><span class="sxs-lookup"><span data-stu-id="d909d-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups)](uri-medialocalemetadatamediagroupsget.md).</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="d909d-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="d909d-120">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="d909d-121">Parent</span><span class="sxs-lookup"><span data-stu-id="d909d-121">Parent</span></span> 

[<span data-ttu-id="d909d-122">/media/{marketplaceId}/メタデータ/mediaGroups/{mediagroup}/mediaItemTypes</span><span class="sxs-lookup"><span data-stu-id="d909d-122">/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes</span></span>](uri-medialocalemetadatamediagroupsmediaitemtypes.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="d909d-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="d909d-123">Further Information</span></span> 

[<span data-ttu-id="d909d-124">EDS 一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="d909d-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="d909d-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="d909d-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="d909d-126">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="d909d-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="d909d-127">Marketplace Uri</span><span class="sxs-lookup"><span data-stu-id="d909d-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="d909d-128">その他の参照</span><span class="sxs-lookup"><span data-stu-id="d909d-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   