---
title: GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)
assetID: 0bbdfecd-5bf3-3e68-8855-12fe6701dbee
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypequeryrefinersget.html
description: " GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d4f35406dc8b9c290308c8990efa66f67c081c9f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57609557"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefiners"></a><span data-ttu-id="9c60c-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)</span><span class="sxs-lookup"><span data-stu-id="9c60c-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners)</span></span>
<span data-ttu-id="9c60c-105">特定のメディア項目の種類のクエリの絞り込み条件を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="9c60c-105">Lists the query refiners for the given media item type.</span></span> <span data-ttu-id="9c60c-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="9c60c-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="9c60c-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9c60c-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="9c60c-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9c60c-108">URI parameters</span></span>
 
| <span data-ttu-id="9c60c-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="9c60c-109">Parameter</span></span>| <span data-ttu-id="9c60c-110">種類</span><span class="sxs-lookup"><span data-stu-id="9c60c-110">Type</span></span>| <span data-ttu-id="9c60c-111">説明</span><span class="sxs-lookup"><span data-stu-id="9c60c-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="9c60c-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="9c60c-112">marketplaceId</span></span>| <span data-ttu-id="9c60c-113">string</span><span class="sxs-lookup"><span data-stu-id="9c60c-113">string</span></span>| <span data-ttu-id="9c60c-114">必須。</span><span class="sxs-lookup"><span data-stu-id="9c60c-114">Required.</span></span> <span data-ttu-id="9c60c-115">文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。</span><span class="sxs-lookup"><span data-stu-id="9c60c-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="9c60c-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="9c60c-116">mediaitemtype</span></span>| <span data-ttu-id="9c60c-117">string</span><span class="sxs-lookup"><span data-stu-id="9c60c-117">string</span></span>| <span data-ttu-id="9c60c-118">必須。</span><span class="sxs-lookup"><span data-stu-id="9c60c-118">Required.</span></span> <span data-ttu-id="9c60c-119">値の 1 つ[取得 (/media/{marketplaceId}/メタデータ/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="9c60c-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="9c60c-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="9c60c-120">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="9c60c-121">Parent</span><span class="sxs-lookup"><span data-stu-id="9c60c-121">Parent</span></span> 

[<span data-ttu-id="9c60c-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span><span class="sxs-lookup"><span data-stu-id="9c60c-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners</span></span>](uri-medialocalemetadatamediaitemtypequeryrefiners.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="9c60c-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="9c60c-123">Further Information</span></span> 

[<span data-ttu-id="9c60c-124">EDS の一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="9c60c-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="9c60c-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="9c60c-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="9c60c-126">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="9c60c-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="9c60c-127">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="9c60c-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="9c60c-128">その他の参照</span><span class="sxs-lookup"><span data-stu-id="9c60c-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   