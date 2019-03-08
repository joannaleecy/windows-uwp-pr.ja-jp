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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57603167"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefiners"></a><span data-ttu-id="e4e85-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span><span class="sxs-lookup"><span data-stu-id="e4e85-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span></span>
<span data-ttu-id="e4e85-105">特定のメディア項目の種類のクエリの絞り込み条件にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="e4e85-105">Accesses the query refiners for the given media item type.</span></span> <span data-ttu-id="e4e85-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="e4e85-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="e4e85-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e4e85-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="e4e85-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e4e85-108">URI parameters</span></span>
 
| <span data-ttu-id="e4e85-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e4e85-109">Parameter</span></span>| <span data-ttu-id="e4e85-110">種類</span><span class="sxs-lookup"><span data-stu-id="e4e85-110">Type</span></span>| <span data-ttu-id="e4e85-111">説明</span><span class="sxs-lookup"><span data-stu-id="e4e85-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="e4e85-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="e4e85-112">marketplaceId</span></span>| <span data-ttu-id="e4e85-113">string</span><span class="sxs-lookup"><span data-stu-id="e4e85-113">string</span></span>| <span data-ttu-id="e4e85-114">必須。</span><span class="sxs-lookup"><span data-stu-id="e4e85-114">Required.</span></span> <span data-ttu-id="e4e85-115">文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。</span><span class="sxs-lookup"><span data-stu-id="e4e85-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="e4e85-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="e4e85-116">mediaitemtype</span></span>| <span data-ttu-id="e4e85-117">string</span><span class="sxs-lookup"><span data-stu-id="e4e85-117">string</span></span>| <span data-ttu-id="e4e85-118">必須。</span><span class="sxs-lookup"><span data-stu-id="e4e85-118">Required.</span></span> <span data-ttu-id="e4e85-119">値の 1 つ[取得 (/media/{marketplaceId}/メタデータ/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="e4e85-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EBC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="e4e85-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="e4e85-120">Valid methods</span></span>

[<span data-ttu-id="e4e85-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)</span><span class="sxs-lookup"><span data-stu-id="e4e85-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)</span></span>](uri-medialocalemetadatamediaitemtypequeryrefinersget.md)

<span data-ttu-id="e4e85-122">&nbsp;&nbsp;特定のメディア項目の種類のクエリの絞り込み条件を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="e4e85-122">&nbsp;&nbsp;Lists the query refiners for the given media item type.</span></span>
 
<a id="ID4ELC"></a>

 
## <a name="see-also"></a><span data-ttu-id="e4e85-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="e4e85-123">See also</span></span>
 
<a id="ID4ENC"></a>

 
##### <a name="parent"></a><span data-ttu-id="e4e85-124">Parent</span><span class="sxs-lookup"><span data-stu-id="e4e85-124">Parent</span></span> 

[<span data-ttu-id="e4e85-125">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="e4e85-125">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EXC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="e4e85-126">詳細情報</span><span class="sxs-lookup"><span data-stu-id="e4e85-126">Further Information</span></span> 

[<span data-ttu-id="e4e85-127">EDS の一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="e4e85-127">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="e4e85-128">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="e4e85-128">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="e4e85-129">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="e4e85-129">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="e4e85-130">その他の参照</span><span class="sxs-lookup"><span data-stu-id="e4e85-130">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   