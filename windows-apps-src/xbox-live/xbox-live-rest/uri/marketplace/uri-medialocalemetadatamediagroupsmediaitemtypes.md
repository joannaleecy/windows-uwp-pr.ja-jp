---
title: /media/{marketplaceId}/メタデータ mediaGroups/{mediagroup}/mediaItemTypes
assetID: fc096def-ac64-76c6-09f8-8f33a6bb47a0
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediagroupsmediaitemtypes.html
author: KevinAsgari
description: " /media/{marketplaceId}/メタデータ mediaGroups/{mediagroup}/mediaItemTypes"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9a5f7e0808f6d9392ea738440779e477b7c999b1
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3961173"
---
# <a name="mediamarketplaceidmetadatamediagroupsmediagroupmediaitemtypes"></a><span data-ttu-id="de5dd-104">/media/{marketplaceId}/メタデータ mediaGroups/{mediagroup}/mediaItemTypes</span><span class="sxs-lookup"><span data-stu-id="de5dd-104">/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes</span></span>
<span data-ttu-id="de5dd-105">指定されたバージョン EDS のメディアのグループごとの利用可能な mediaItemTypes にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="de5dd-105">Accesses the available mediaItemTypes per media group for the given version of EDS.</span></span> <span data-ttu-id="de5dd-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="de5dd-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="de5dd-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="de5dd-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="de5dd-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="de5dd-108">URI parameters</span></span>
 
| <span data-ttu-id="de5dd-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="de5dd-109">Parameter</span></span>| <span data-ttu-id="de5dd-110">型</span><span class="sxs-lookup"><span data-stu-id="de5dd-110">Type</span></span>| <span data-ttu-id="de5dd-111">説明</span><span class="sxs-lookup"><span data-stu-id="de5dd-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="de5dd-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="de5dd-112">marketplaceId</span></span>| <span data-ttu-id="de5dd-113">string</span><span class="sxs-lookup"><span data-stu-id="de5dd-113">string</span></span>| <span data-ttu-id="de5dd-114">必須。</span><span class="sxs-lookup"><span data-stu-id="de5dd-114">Required.</span></span> <span data-ttu-id="de5dd-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="de5dd-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="de5dd-116">mediagroup</span><span class="sxs-lookup"><span data-stu-id="de5dd-116">mediagroup</span></span>| <span data-ttu-id="de5dd-117">string</span><span class="sxs-lookup"><span data-stu-id="de5dd-117">string</span></span>| <span data-ttu-id="de5dd-118">必須。</span><span class="sxs-lookup"><span data-stu-id="de5dd-118">Required.</span></span> <span data-ttu-id="de5dd-119">[GET (/media/{marketplaceId} メタデータ/mediaGroups)](uri-medialocalemetadatamediagroupsget.md)からの値のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="de5dd-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups)](uri-medialocalemetadatamediagroupsget.md).</span></span>| 
  
<a id="ID4EBC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="de5dd-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="de5dd-120">Valid methods</span></span>

[<span data-ttu-id="de5dd-121">取得する (/media/{marketplaceId}/メタデータ mediaGroups/{mediagroup}/mediaItemTypes)</span><span class="sxs-lookup"><span data-stu-id="de5dd-121">GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)</span></span>](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)

<span data-ttu-id="de5dd-122">&nbsp;&nbsp;指定されたバージョン EDS のメディアのグループごとの利用可能な mediaItemTypes の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="de5dd-122">&nbsp;&nbsp;Lists the available mediaItemTypes per media group for the given version of EDS.</span></span>
 
<a id="ID4ELC"></a>

 
## <a name="see-also"></a><span data-ttu-id="de5dd-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="de5dd-123">See also</span></span>
 
<a id="ID4ENC"></a>

 
##### <a name="parent"></a><span data-ttu-id="de5dd-124">Parent</span><span class="sxs-lookup"><span data-stu-id="de5dd-124">Parent</span></span> 

[<span data-ttu-id="de5dd-125">Marketplace Uri</span><span class="sxs-lookup"><span data-stu-id="de5dd-125">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EXC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="de5dd-126">詳細情報</span><span class="sxs-lookup"><span data-stu-id="de5dd-126">Further Information</span></span> 

[<span data-ttu-id="de5dd-127">EDS 一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="de5dd-127">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="de5dd-128">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="de5dd-128">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="de5dd-129">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="de5dd-129">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="de5dd-130">その他の参照</span><span class="sxs-lookup"><span data-stu-id="de5dd-130">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   