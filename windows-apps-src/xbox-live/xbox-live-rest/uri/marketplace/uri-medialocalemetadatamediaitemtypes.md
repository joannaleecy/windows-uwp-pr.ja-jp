---
title: /media/{marketplaceId}/metadata/mediaItemTypes
assetID: a88f4c31-082a-45d2-e5d7-b881e829e357
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypes.html
description: " /media/{marketplaceId}/metadata/mediaItemTypes"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: bd5884b2d416c74fa7043791c8e817e66dd6e5ef
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8924777"
---
# <a name="mediamarketplaceidmetadatamediaitemtypes"></a><span data-ttu-id="6b44c-104">/media/{marketplaceId}/metadata/mediaItemTypes</span><span class="sxs-lookup"><span data-stu-id="6b44c-104">/media/{marketplaceId}/metadata/mediaItemTypes</span></span>
<span data-ttu-id="6b44c-105">EDS の特定のバージョンのサポートされているすべての mediaItemTypes にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="6b44c-105">Accesses all supported mediaItemTypes for the given EDS version.</span></span> <span data-ttu-id="6b44c-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="6b44c-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="6b44c-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6b44c-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="6b44c-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6b44c-108">URI parameters</span></span>
 
| <span data-ttu-id="6b44c-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="6b44c-109">Parameter</span></span>| <span data-ttu-id="6b44c-110">型</span><span class="sxs-lookup"><span data-stu-id="6b44c-110">Type</span></span>| <span data-ttu-id="6b44c-111">説明</span><span class="sxs-lookup"><span data-stu-id="6b44c-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="6b44c-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="6b44c-112">marketplaceId</span></span>| <span data-ttu-id="6b44c-113">string</span><span class="sxs-lookup"><span data-stu-id="6b44c-113">string</span></span>| <span data-ttu-id="6b44c-114">必須。</span><span class="sxs-lookup"><span data-stu-id="6b44c-114">Required.</span></span> <span data-ttu-id="6b44c-115"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="6b44c-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EUB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="6b44c-116">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="6b44c-116">Valid methods</span></span>

[<span data-ttu-id="6b44c-117">GET (/media/{marketplaceId}/metadata/mediaItemTypes)</span><span class="sxs-lookup"><span data-stu-id="6b44c-117">GET (/media/{marketplaceId}/metadata/mediaItemTypes)</span></span>](uri-medialocalemetadatamediaitemtypesget.md)

<span data-ttu-id="6b44c-118">&nbsp;&nbsp;EDS の特定のバージョンのサポートされているすべての mediaItemTypes の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="6b44c-118">&nbsp;&nbsp;Lists all supported mediaItemTypes for the given EDS version.</span></span>
 
<a id="ID4E5B"></a>

 
## <a name="see-also"></a><span data-ttu-id="6b44c-119">関連項目</span><span class="sxs-lookup"><span data-stu-id="6b44c-119">See also</span></span>
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="6b44c-120">Parent</span><span class="sxs-lookup"><span data-stu-id="6b44c-120">Parent</span></span> 

[<span data-ttu-id="6b44c-121">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="6b44c-121">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EKC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="6b44c-122">詳細情報</span><span class="sxs-lookup"><span data-stu-id="6b44c-122">Further Information</span></span> 

[<span data-ttu-id="6b44c-123">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6b44c-123">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="6b44c-124">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="6b44c-124">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="6b44c-125">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="6b44c-125">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="6b44c-126">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="6b44c-126">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   