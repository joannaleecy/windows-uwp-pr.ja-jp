---
title: GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders)
assetID: 225e8cb2-44eb-6b7b-eaa0-1ea2d2602f6f
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediaitemtypesortordersget.html
description: " GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5cec9bf585e1d885c4c1b6950e94923908cc06e8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618357"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypesortorders"></a><span data-ttu-id="4814c-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders)</span><span class="sxs-lookup"><span data-stu-id="4814c-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders)</span></span>
<span data-ttu-id="4814c-105">特定 mediaitem 型および EDS の特定のバージョンの使用可能な並べ替え順序を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="4814c-105">Lists available sort orders for a given mediaitem type and a given version of EDS.</span></span> <span data-ttu-id="4814c-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="4814c-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="4814c-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4814c-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="4814c-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4814c-108">URI parameters</span></span>
 
| <span data-ttu-id="4814c-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="4814c-109">Parameter</span></span>| <span data-ttu-id="4814c-110">種類</span><span class="sxs-lookup"><span data-stu-id="4814c-110">Type</span></span>| <span data-ttu-id="4814c-111">説明</span><span class="sxs-lookup"><span data-stu-id="4814c-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="4814c-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="4814c-112">marketplaceId</span></span>| <span data-ttu-id="4814c-113">string</span><span class="sxs-lookup"><span data-stu-id="4814c-113">string</span></span>| <span data-ttu-id="4814c-114">必須。</span><span class="sxs-lookup"><span data-stu-id="4814c-114">Required.</span></span> <span data-ttu-id="4814c-115">文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。</span><span class="sxs-lookup"><span data-stu-id="4814c-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="4814c-116">mediaitemtype</span><span class="sxs-lookup"><span data-stu-id="4814c-116">mediaitemtype</span></span>| <span data-ttu-id="4814c-117">string</span><span class="sxs-lookup"><span data-stu-id="4814c-117">string</span></span>| <span data-ttu-id="4814c-118">必須。</span><span class="sxs-lookup"><span data-stu-id="4814c-118">Required.</span></span> <span data-ttu-id="4814c-119">値の 1 つ[取得 (/media/{marketplaceId}/メタデータ/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)します。</span><span class="sxs-lookup"><span data-stu-id="4814c-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)](uri-medialocalemetadatamediagroupsmediaitemtypesget.md).</span></span>| 
  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="4814c-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="4814c-120">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="4814c-121">Parent</span><span class="sxs-lookup"><span data-stu-id="4814c-121">Parent</span></span> 

[<span data-ttu-id="4814c-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders</span><span class="sxs-lookup"><span data-stu-id="4814c-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/sortorders</span></span>](uri-medialocalemetadatamediaitemtypesortorders.md)

  
<a id="ID4EMB"></a>

 
##### <a name="further-information"></a><span data-ttu-id="4814c-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="4814c-123">Further Information</span></span> 

[<span data-ttu-id="4814c-124">EDS の一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="4814c-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="4814c-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="4814c-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="4814c-126">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="4814c-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="4814c-127">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="4814c-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="4814c-128">その他の参照</span><span class="sxs-lookup"><span data-stu-id="4814c-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   