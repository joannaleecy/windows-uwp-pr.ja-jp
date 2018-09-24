---
title: /media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes
assetID: fc096def-ac64-76c6-09f8-8f33a6bb47a0
permalink: en-us/docs/xboxlive/rest/uri-medialocalemetadatamediagroupsmediaitemtypes.html
author: KevinAsgari
description: " /media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9a5f7e0808f6d9392ea738440779e477b7c999b1
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4151824"
---
# <a name="mediamarketplaceidmetadatamediagroupsmediagroupmediaitemtypes"></a><span data-ttu-id="086b5-104">/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes</span><span class="sxs-lookup"><span data-stu-id="086b5-104">/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes</span></span>
<span data-ttu-id="086b5-105">指定されたバージョン EDS のメディアのグループごとの利用可能な mediaItemTypes にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="086b5-105">Accesses the available mediaItemTypes per media group for the given version of EDS.</span></span> <span data-ttu-id="086b5-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="086b5-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="086b5-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="086b5-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="086b5-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="086b5-108">URI parameters</span></span>
 
| <span data-ttu-id="086b5-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="086b5-109">Parameter</span></span>| <span data-ttu-id="086b5-110">型</span><span class="sxs-lookup"><span data-stu-id="086b5-110">Type</span></span>| <span data-ttu-id="086b5-111">説明</span><span class="sxs-lookup"><span data-stu-id="086b5-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="086b5-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="086b5-112">marketplaceId</span></span>| <span data-ttu-id="086b5-113">string</span><span class="sxs-lookup"><span data-stu-id="086b5-113">string</span></span>| <span data-ttu-id="086b5-114">必須。</span><span class="sxs-lookup"><span data-stu-id="086b5-114">Required.</span></span> <span data-ttu-id="086b5-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="086b5-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
| <span data-ttu-id="086b5-116">mediagroup</span><span class="sxs-lookup"><span data-stu-id="086b5-116">mediagroup</span></span>| <span data-ttu-id="086b5-117">string</span><span class="sxs-lookup"><span data-stu-id="086b5-117">string</span></span>| <span data-ttu-id="086b5-118">必須。</span><span class="sxs-lookup"><span data-stu-id="086b5-118">Required.</span></span> <span data-ttu-id="086b5-119">[GET (/media/{marketplaceId} メタデータ/mediaGroups)](uri-medialocalemetadatamediagroupsget.md)からの値のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="086b5-119">One of the values from [GET (/media/{marketplaceId}/metadata/mediaGroups)](uri-medialocalemetadatamediagroupsget.md).</span></span>| 
  
<a id="ID4EBC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="086b5-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="086b5-120">Valid methods</span></span>

[<span data-ttu-id="086b5-121">GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)</span><span class="sxs-lookup"><span data-stu-id="086b5-121">GET (/media/{marketplaceId}/metadata/mediaGroups/{mediagroup}/mediaItemTypes)</span></span>](uri-medialocalemetadatamediagroupsmediaitemtypesget.md)

<span data-ttu-id="086b5-122">&nbsp;&nbsp;指定されたバージョン EDS のメディアのグループごとの利用可能な mediaItemTypes の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="086b5-122">&nbsp;&nbsp;Lists the available mediaItemTypes per media group for the given version of EDS.</span></span>
 
<a id="ID4ELC"></a>

 
## <a name="see-also"></a><span data-ttu-id="086b5-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="086b5-123">See also</span></span>
 
<a id="ID4ENC"></a>

 
##### <a name="parent"></a><span data-ttu-id="086b5-124">Parent</span><span class="sxs-lookup"><span data-stu-id="086b5-124">Parent</span></span> 

[<span data-ttu-id="086b5-125">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="086b5-125">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EXC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="086b5-126">詳細情報</span><span class="sxs-lookup"><span data-stu-id="086b5-126">Further Information</span></span> 

[<span data-ttu-id="086b5-127">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="086b5-127">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="086b5-128">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="086b5-128">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="086b5-129">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="086b5-129">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="086b5-130">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="086b5-130">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   