---
title: /media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders
assetID: 221c440d-c448-11e9-f455-6d0f95fc16ef
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypesortorders.html
description: " /media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e807f1a29712f55fc2e404e3905c7c69eb50d166
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57640927"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypesortorders"></a><span data-ttu-id="ce04b-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders</span><span class="sxs-lookup"><span data-stu-id="ce04b-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders</span></span>
<span data-ttu-id="ce04b-105">使用可能なアクセスは、特定 mediaitem 型と EDS の特定バージョンの注文を並べ替えます。</span><span class="sxs-lookup"><span data-stu-id="ce04b-105">Accesses available sort orders for a given mediaitem type and a given version of EDS.</span></span> <span data-ttu-id="ce04b-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="ce04b-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="ce04b-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ce04b-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="ce04b-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ce04b-108">URI parameters</span></span>
 
| <span data-ttu-id="ce04b-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ce04b-109">Parameter</span></span>| <span data-ttu-id="ce04b-110">種類</span><span class="sxs-lookup"><span data-stu-id="ce04b-110">Type</span></span>| <span data-ttu-id="ce04b-111">説明</span><span class="sxs-lookup"><span data-stu-id="ce04b-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ce04b-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="ce04b-112">marketplaceId</span></span>| <span data-ttu-id="ce04b-113">string</span><span class="sxs-lookup"><span data-stu-id="ce04b-113">string</span></span>| <span data-ttu-id="ce04b-114">必須。</span><span class="sxs-lookup"><span data-stu-id="ce04b-114">Required.</span></span> <span data-ttu-id="ce04b-115">文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。</span><span class="sxs-lookup"><span data-stu-id="ce04b-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="ce04b-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="ce04b-116">mediaitemtype</span></span>| <span data-ttu-id="ce04b-117">string</span><span class="sxs-lookup"><span data-stu-id="ce04b-117">string</span></span>| <span data-ttu-id="ce04b-118">必須。</span><span class="sxs-lookup"><span data-stu-id="ce04b-118">Required.</span></span> <span data-ttu-id="ce04b-119">値の 1 つ[取得 (/media/{marketplaceId}/メタデータ/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="ce04b-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EBC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="ce04b-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="ce04b-120">Valid methods</span></span>

[<span data-ttu-id="ce04b-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders)</span><span class="sxs-lookup"><span data-stu-id="ce04b-121">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders)</span></span>](uri-medialocalemetadatamediaitemtypesortordersget.md)

<span data-ttu-id="ce04b-122">&nbsp;&nbsp;特定 mediaitem 型および EDS の特定のバージョンの使用可能な並べ替え順序を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="ce04b-122">&nbsp;&nbsp;Lists available sort orders for a given mediaitem type and a given version of EDS.</span></span>
 
<a id="ID4ELC"></a>

 
## <a name="see-also"></a><span data-ttu-id="ce04b-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="ce04b-123">See also</span></span>
 
<a id="ID4ENC"></a>

 
##### <a name="parent"></a><span data-ttu-id="ce04b-124">Parent</span><span class="sxs-lookup"><span data-stu-id="ce04b-124">Parent</span></span> 

[<span data-ttu-id="ce04b-125">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="ce04b-125">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EXC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="ce04b-126">詳細情報</span><span class="sxs-lookup"><span data-stu-id="ce04b-126">Further Information</span></span> 

[<span data-ttu-id="ce04b-127">EDS の一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="ce04b-127">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="ce04b-128">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="ce04b-128">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="ce04b-129">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="ce04b-129">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="ce04b-130">その他の参照</span><span class="sxs-lookup"><span data-stu-id="ce04b-130">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   