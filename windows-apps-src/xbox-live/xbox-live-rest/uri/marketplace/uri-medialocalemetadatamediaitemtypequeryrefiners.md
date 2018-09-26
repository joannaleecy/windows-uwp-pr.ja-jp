---
title: /media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners
assetID: 5a519314-1df1-cbdc-cb04-3a8b663003de
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypequeryrefiners.html
author: KevinAsgari
description: " /media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9273282ab20f06998a2d510f6c3d2b7e61ecf4a9
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4206663"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefiners"></a><span data-ttu-id="284fb-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span><span class="sxs-lookup"><span data-stu-id="284fb-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span></span>
<span data-ttu-id="284fb-105">指定したメディア項目の種類のクエリの絞り込み条件にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="284fb-105">Accesses the query refiners for the given media item type.</span></span> <span data-ttu-id="284fb-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="284fb-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="284fb-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="284fb-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="284fb-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="284fb-108">URI parameters</span></span>
 
| <span data-ttu-id="284fb-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="284fb-109">Parameter</span></span>| <span data-ttu-id="284fb-110">型</span><span class="sxs-lookup"><span data-stu-id="284fb-110">Type</span></span>| <span data-ttu-id="284fb-111">説明</span><span class="sxs-lookup"><span data-stu-id="284fb-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="284fb-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="284fb-112">marketplaceId</span></span>| <span data-ttu-id="284fb-113">string</span><span class="sxs-lookup"><span data-stu-id="284fb-113">string</span></span>| <span data-ttu-id="284fb-114">必須。</span><span class="sxs-lookup"><span data-stu-id="284fb-114">Required.</span></span> <span data-ttu-id="284fb-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="284fb-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="284fb-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="284fb-116">mediaitemtype</span></span>| <span data-ttu-id="284fb-117">string</span><span class="sxs-lookup"><span data-stu-id="284fb-117">string</span></span>| <span data-ttu-id="284fb-118">必須。</span><span class="sxs-lookup"><span data-stu-id="284fb-118">Required.</span></span> <span data-ttu-id="284fb-119">値のいずれかの[を取得する (/media/{marketplaceId}/メタデータ mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="284fb-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EBC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="284fb-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="284fb-120">Valid methods</span></span>

[<span data-ttu-id="284fb-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)</span><span class="sxs-lookup"><span data-stu-id="284fb-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)</span></span>](uri-medialocalemetadatamediaitemtypequeryrefinersget.md)

<span data-ttu-id="284fb-122">&nbsp;&nbsp;指定したメディア項目の種類のクエリの絞り込み条件の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="284fb-122">&nbsp;&nbsp;Lists the query refiners for the given media item type.</span></span>
 
<a id="ID4ELC"></a>

 
## <a name="see-also"></a><span data-ttu-id="284fb-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="284fb-123">See also</span></span>
 
<a id="ID4ENC"></a>

 
##### <a name="parent"></a><span data-ttu-id="284fb-124">Parent</span><span class="sxs-lookup"><span data-stu-id="284fb-124">Parent</span></span> 

[<span data-ttu-id="284fb-125">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="284fb-125">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EXC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="284fb-126">詳細情報</span><span class="sxs-lookup"><span data-stu-id="284fb-126">Further Information</span></span> 

[<span data-ttu-id="284fb-127">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="284fb-127">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="284fb-128">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="284fb-128">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="284fb-129">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="284fb-129">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="284fb-130">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="284fb-130">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   