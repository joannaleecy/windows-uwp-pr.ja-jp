---
title: /media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}
assetID: 1e2f5fd3-3d14-9a97-ffbf-ab2a18ff4f15
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinername.html
description: " /media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 356c7d6eb30eb14156e434f717530d6f4f48a990
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57611477"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefinersqueryrefinername"></a><span data-ttu-id="23830-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}</span><span class="sxs-lookup"><span data-stu-id="23830-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername}</span></span>
<span data-ttu-id="23830-105">指定されたクエリ絞り込み条件の名前と特定のメディア項目の種類は、使用可能な値にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="23830-105">Accesses the acceptable values for the given query refiner name and given media item type.</span></span> <span data-ttu-id="23830-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="23830-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="23830-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="23830-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="23830-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="23830-108">URI parameters</span></span>
 
| <span data-ttu-id="23830-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="23830-109">Parameter</span></span>| <span data-ttu-id="23830-110">種類</span><span class="sxs-lookup"><span data-stu-id="23830-110">Type</span></span>| <span data-ttu-id="23830-111">説明</span><span class="sxs-lookup"><span data-stu-id="23830-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="23830-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="23830-112">marketplaceId</span></span>| <span data-ttu-id="23830-113">string</span><span class="sxs-lookup"><span data-stu-id="23830-113">string</span></span>| <span data-ttu-id="23830-114">必須。</span><span class="sxs-lookup"><span data-stu-id="23830-114">Required.</span></span> <span data-ttu-id="23830-115">文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。</span><span class="sxs-lookup"><span data-stu-id="23830-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="23830-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="23830-116">mediaitemtype</span></span>| <span data-ttu-id="23830-117">string</span><span class="sxs-lookup"><span data-stu-id="23830-117">string</span></span>| <span data-ttu-id="23830-118">必須。</span><span class="sxs-lookup"><span data-stu-id="23830-118">Required.</span></span> <span data-ttu-id="23830-119">値の 1 つ[取得 (/media/{marketplaceId}/メタデータ/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="23830-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
| <span data-ttu-id="23830-120">queryrefinername</span><span class="sxs-lookup"><span data-stu-id="23830-120">queryrefinername</span></span>| <span data-ttu-id="23830-121">string</span><span class="sxs-lookup"><span data-stu-id="23830-121">string</span></span>| <span data-ttu-id="23830-122">必須。</span><span class="sxs-lookup"><span data-stu-id="23830-122">Required.</span></span> <span data-ttu-id="23830-123">値が必要か、"Genre"または「10 年」など、クエリ絞り込み条件の名前です。</span><span class="sxs-lookup"><span data-stu-id="23830-123">Name of the query refiner for which values are needed, such as "Genre" or "Decade".</span></span> <span data-ttu-id="23830-124">QueryRefiners を参照してください。</span><span class="sxs-lookup"><span data-stu-id="23830-124">See QueryRefiners.</span></span>| 
  
<a id="ID4EKC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="23830-125">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="23830-125">Valid methods</span></span>

[<span data-ttu-id="23830-126">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})</span><span class="sxs-lookup"><span data-stu-id="23830-126">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryrefinername})</span></span>](uri-medialocalemetadatamediaitemtypequeryrefinersqueryrefinernameget.md)

<span data-ttu-id="23830-127">&nbsp;&nbsp;指定されたクエリ絞り込み条件の名前と特定のメディア項目の種類は、使用可能な値を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="23830-127">&nbsp;&nbsp;Lists the acceptable values for the given query refiner name and given media item type.</span></span>
 
<a id="ID4EUC"></a>

 
## <a name="see-also"></a><span data-ttu-id="23830-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="23830-128">See also</span></span>
 
<a id="ID4EWC"></a>

 
##### <a name="parent"></a><span data-ttu-id="23830-129">Parent</span><span class="sxs-lookup"><span data-stu-id="23830-129">Parent</span></span> 

[<span data-ttu-id="23830-130">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="23830-130">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EAD"></a>

 
##### <a name="further-information"></a><span data-ttu-id="23830-131">詳細情報</span><span class="sxs-lookup"><span data-stu-id="23830-131">Further Information</span></span> 

[<span data-ttu-id="23830-132">EDS の一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="23830-132">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="23830-133">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="23830-133">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="23830-134">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="23830-134">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="23830-135">その他の参照</span><span class="sxs-lookup"><span data-stu-id="23830-135">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   