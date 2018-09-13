---
title: /media/{marketplaceId}/メタデータ mediaItemTypes/{mediaitemtype}/queryrefiners
assetID: 5a519314-1df1-cbdc-cb04-3a8b663003de
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypequeryrefiners.html
author: KevinAsgari
description: " /media/{marketplaceId}/メタデータ mediaItemTypes/{mediaitemtype}/queryrefiners"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9273282ab20f06998a2d510f6c3d2b7e61ecf4a9
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3962331"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefiners"></a><span data-ttu-id="c724a-104">/media/{marketplaceId}/メタデータ mediaItemTypes/{mediaitemtype}/queryrefiners</span><span class="sxs-lookup"><span data-stu-id="c724a-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span></span>
<span data-ttu-id="c724a-105">指定したメディア項目の種類のクエリ絞り込み条件にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="c724a-105">Accesses the query refiners for the given media item type.</span></span> <span data-ttu-id="c724a-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="c724a-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="c724a-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c724a-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="c724a-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c724a-108">URI parameters</span></span>
 
| <span data-ttu-id="c724a-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c724a-109">Parameter</span></span>| <span data-ttu-id="c724a-110">型</span><span class="sxs-lookup"><span data-stu-id="c724a-110">Type</span></span>| <span data-ttu-id="c724a-111">説明</span><span class="sxs-lookup"><span data-stu-id="c724a-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="c724a-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="c724a-112">marketplaceId</span></span>| <span data-ttu-id="c724a-113">string</span><span class="sxs-lookup"><span data-stu-id="c724a-113">string</span></span>| <span data-ttu-id="c724a-114">必須。</span><span class="sxs-lookup"><span data-stu-id="c724a-114">Required.</span></span> <span data-ttu-id="c724a-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="c724a-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="c724a-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="c724a-116">mediaitemtype</span></span>| <span data-ttu-id="c724a-117">string</span><span class="sxs-lookup"><span data-stu-id="c724a-117">string</span></span>| <span data-ttu-id="c724a-118">必須。</span><span class="sxs-lookup"><span data-stu-id="c724a-118">Required.</span></span> <span data-ttu-id="c724a-119">値のいずれかの[を取得する (/media/{marketplaceId}/メタデータ mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="c724a-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EBC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="c724a-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="c724a-120">Valid methods</span></span>

[<span data-ttu-id="c724a-121">取得する (/media/{marketplaceId}/メタデータ mediaItemTypes/{mediaitemtype}/queryrefiners)</span><span class="sxs-lookup"><span data-stu-id="c724a-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)</span></span>](uri-medialocalemetadatamediaitemtypequeryrefinersget.md)

<span data-ttu-id="c724a-122">&nbsp;&nbsp;指定したメディア項目の種類のクエリの絞り込み条件の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="c724a-122">&nbsp;&nbsp;Lists the query refiners for the given media item type.</span></span>
 
<a id="ID4ELC"></a>

 
## <a name="see-also"></a><span data-ttu-id="c724a-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="c724a-123">See also</span></span>
 
<a id="ID4ENC"></a>

 
##### <a name="parent"></a><span data-ttu-id="c724a-124">Parent</span><span class="sxs-lookup"><span data-stu-id="c724a-124">Parent</span></span> 

[<span data-ttu-id="c724a-125">Marketplace Uri</span><span class="sxs-lookup"><span data-stu-id="c724a-125">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EXC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="c724a-126">詳細情報</span><span class="sxs-lookup"><span data-stu-id="c724a-126">Further Information</span></span> 

[<span data-ttu-id="c724a-127">EDS 一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="c724a-127">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="c724a-128">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="c724a-128">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="c724a-129">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="c724a-129">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="c724a-130">その他の参照</span><span class="sxs-lookup"><span data-stu-id="c724a-130">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   