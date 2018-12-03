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
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8331750"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefiners"></a><span data-ttu-id="9b932-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span><span class="sxs-lookup"><span data-stu-id="9b932-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span></span>
<span data-ttu-id="9b932-105">指定したメディア項目の種類のクエリの絞り込み条件にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="9b932-105">Accesses the query refiners for the given media item type.</span></span> <span data-ttu-id="9b932-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="9b932-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="9b932-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9b932-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="9b932-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9b932-108">URI parameters</span></span>
 
| <span data-ttu-id="9b932-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="9b932-109">Parameter</span></span>| <span data-ttu-id="9b932-110">型</span><span class="sxs-lookup"><span data-stu-id="9b932-110">Type</span></span>| <span data-ttu-id="9b932-111">説明</span><span class="sxs-lookup"><span data-stu-id="9b932-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="9b932-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="9b932-112">marketplaceId</span></span>| <span data-ttu-id="9b932-113">string</span><span class="sxs-lookup"><span data-stu-id="9b932-113">string</span></span>| <span data-ttu-id="9b932-114">必須。</span><span class="sxs-lookup"><span data-stu-id="9b932-114">Required.</span></span> <span data-ttu-id="9b932-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="9b932-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="9b932-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="9b932-116">mediaitemtype</span></span>| <span data-ttu-id="9b932-117">string</span><span class="sxs-lookup"><span data-stu-id="9b932-117">string</span></span>| <span data-ttu-id="9b932-118">必須。</span><span class="sxs-lookup"><span data-stu-id="9b932-118">Required.</span></span> <span data-ttu-id="9b932-119">値のいずれかの[GET (/media/{marketplaceId}//metadata/mediagroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="9b932-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EBC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="9b932-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="9b932-120">Valid methods</span></span>

[<span data-ttu-id="9b932-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)</span><span class="sxs-lookup"><span data-stu-id="9b932-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)</span></span>](uri-medialocalemetadatamediaitemtypequeryrefinersget.md)

<span data-ttu-id="9b932-122">&nbsp;&nbsp;指定したメディア項目の種類のクエリの絞り込み条件の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="9b932-122">&nbsp;&nbsp;Lists the query refiners for the given media item type.</span></span>
 
<a id="ID4ELC"></a>

 
## <a name="see-also"></a><span data-ttu-id="9b932-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="9b932-123">See also</span></span>
 
<a id="ID4ENC"></a>

 
##### <a name="parent"></a><span data-ttu-id="9b932-124">Parent</span><span class="sxs-lookup"><span data-stu-id="9b932-124">Parent</span></span> 

[<span data-ttu-id="9b932-125">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="9b932-125">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EXC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="9b932-126">詳細情報</span><span class="sxs-lookup"><span data-stu-id="9b932-126">Further Information</span></span> 

[<span data-ttu-id="9b932-127">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9b932-127">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="9b932-128">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="9b932-128">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="9b932-129">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="9b932-129">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="9b932-130">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="9b932-130">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   