---
title: /media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners
assetID: 5a519314-1df1-cbdc-cb04-3a8b663003de
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypequeryrefiners.html
description: " /media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c0a891e7ba1b111d00593de55561c89988d2a4ad
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8931144"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefiners"></a><span data-ttu-id="cf79b-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span><span class="sxs-lookup"><span data-stu-id="cf79b-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span></span>
<span data-ttu-id="cf79b-105">指定したメディア項目の種類のクエリの絞り込み条件にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="cf79b-105">Accesses the query refiners for the given media item type.</span></span> <span data-ttu-id="cf79b-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="cf79b-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="cf79b-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cf79b-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="cf79b-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cf79b-108">URI parameters</span></span>
 
| <span data-ttu-id="cf79b-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="cf79b-109">Parameter</span></span>| <span data-ttu-id="cf79b-110">型</span><span class="sxs-lookup"><span data-stu-id="cf79b-110">Type</span></span>| <span data-ttu-id="cf79b-111">説明</span><span class="sxs-lookup"><span data-stu-id="cf79b-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="cf79b-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="cf79b-112">marketplaceId</span></span>| <span data-ttu-id="cf79b-113">string</span><span class="sxs-lookup"><span data-stu-id="cf79b-113">string</span></span>| <span data-ttu-id="cf79b-114">必須。</span><span class="sxs-lookup"><span data-stu-id="cf79b-114">Required.</span></span> <span data-ttu-id="cf79b-115"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="cf79b-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="cf79b-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="cf79b-116">mediaitemtype</span></span>| <span data-ttu-id="cf79b-117">string</span><span class="sxs-lookup"><span data-stu-id="cf79b-117">string</span></span>| <span data-ttu-id="cf79b-118">必須。</span><span class="sxs-lookup"><span data-stu-id="cf79b-118">Required.</span></span> <span data-ttu-id="cf79b-119">値のいずれか[GET (/media/{marketplaceId}//metadata/mediagroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="cf79b-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EBC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="cf79b-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="cf79b-120">Valid methods</span></span>

[<span data-ttu-id="cf79b-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)</span><span class="sxs-lookup"><span data-stu-id="cf79b-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)</span></span>](uri-medialocalemetadatamediaitemtypequeryrefinersget.md)

<span data-ttu-id="cf79b-122">&nbsp;&nbsp;指定したメディア項目の種類のクエリの絞り込み条件の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="cf79b-122">&nbsp;&nbsp;Lists the query refiners for the given media item type.</span></span>
 
<a id="ID4ELC"></a>

 
## <a name="see-also"></a><span data-ttu-id="cf79b-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="cf79b-123">See also</span></span>
 
<a id="ID4ENC"></a>

 
##### <a name="parent"></a><span data-ttu-id="cf79b-124">Parent</span><span class="sxs-lookup"><span data-stu-id="cf79b-124">Parent</span></span> 

[<span data-ttu-id="cf79b-125">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="cf79b-125">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EXC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="cf79b-126">詳細情報</span><span class="sxs-lookup"><span data-stu-id="cf79b-126">Further Information</span></span> 

[<span data-ttu-id="cf79b-127">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cf79b-127">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="cf79b-128">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="cf79b-128">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="cf79b-129">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="cf79b-129">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="cf79b-130">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="cf79b-130">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   