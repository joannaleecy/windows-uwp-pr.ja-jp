---
title: /media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes
assetID: fc096def-ac64-76c6-09f8-8f33a6bb47a0
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediagroupsmediaitemtypes.html
description: " /media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d014cbcf4e42e2f07c3cc32ceeb557a3c8537871
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57637067"
---
# <a name="mediamarketplaceidmetadatamediagroupsmediagroupmediaitemtypes"></a><span data-ttu-id="b8407-104">/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes</span><span class="sxs-lookup"><span data-stu-id="b8407-104">/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes</span></span>
<span data-ttu-id="b8407-105">EDS の特定のバージョンのメディアのグループごとの使用可能な mediaItemTypes にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="b8407-105">Accesses the available mediaItemTypes per media group for the given version of EDS.</span></span> <span data-ttu-id="b8407-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b8407-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="b8407-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b8407-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="b8407-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b8407-108">URI parameters</span></span>
 
| <span data-ttu-id="b8407-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b8407-109">Parameter</span></span>| <span data-ttu-id="b8407-110">種類</span><span class="sxs-lookup"><span data-stu-id="b8407-110">Type</span></span>| <span data-ttu-id="b8407-111">説明</span><span class="sxs-lookup"><span data-stu-id="b8407-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b8407-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="b8407-112">marketplaceId</span></span>| <span data-ttu-id="b8407-113">string</span><span class="sxs-lookup"><span data-stu-id="b8407-113">string</span></span>| <span data-ttu-id="b8407-114">必須。</span><span class="sxs-lookup"><span data-stu-id="b8407-114">Required.</span></span> <span data-ttu-id="b8407-115">文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。</span><span class="sxs-lookup"><span data-stu-id="b8407-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="b8407-116">mediagroup</span><span class="sxs-lookup"><span data-stu-id="b8407-116">mediagroup</span></span>| <span data-ttu-id="b8407-117">string</span><span class="sxs-lookup"><span data-stu-id="b8407-117">string</span></span>| <span data-ttu-id="b8407-118">必須。</span><span class="sxs-lookup"><span data-stu-id="b8407-118">Required.</span></span> <span data-ttu-id="b8407-119">値の 1 つ[GET (/media/{marketplaceId}/メタデータ/mediaGroups)](uri-medialocalemetadatamediagroupsget.md)します。</span><span class="sxs-lookup"><span data-stu-id="b8407-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups)](uri-medialocalemetadatamediagroupsget.md).</span></span>| 
  
<a id="ID4EBC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="b8407-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="b8407-120">Valid methods</span></span>

[<span data-ttu-id="b8407-121">取得 (/media/{marketplaceId}/メタデータ/mediaGroups/{mediagroup}/mediaItemTypes)</span><span class="sxs-lookup"><span data-stu-id="b8407-121">GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)</span></span>](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)

<span data-ttu-id="b8407-122">&nbsp;&nbsp;EDS の特定のバージョンのメディアのグループごとの使用可能な mediaItemTypes を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="b8407-122">&nbsp;&nbsp;Lists the available mediaItemTypes per media group for the given version of EDS.</span></span>
 
<a id="ID4ELC"></a>

 
## <a name="see-also"></a><span data-ttu-id="b8407-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="b8407-123">See also</span></span>
 
<a id="ID4ENC"></a>

 
##### <a name="parent"></a><span data-ttu-id="b8407-124">Parent</span><span class="sxs-lookup"><span data-stu-id="b8407-124">Parent</span></span> 

[<span data-ttu-id="b8407-125">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="b8407-125">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EXC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="b8407-126">詳細情報</span><span class="sxs-lookup"><span data-stu-id="b8407-126">Further Information</span></span> 

[<span data-ttu-id="b8407-127">EDS の一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="b8407-127">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="b8407-128">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="b8407-128">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="b8407-129">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="b8407-129">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="b8407-130">その他の参照</span><span class="sxs-lookup"><span data-stu-id="b8407-130">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   