---
title: /media/{marketplaceId}/contentRating
assetID: 573cf378-36a4-cc82-0029-37d268da933c
permalink: en-us/docs/xboxlive/rest/uri-medialocalecontentrating.html
author: KevinAsgari
description: " /media/{marketplaceId}/contentRating"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 632d49e0fa7dbb99f9096e70f790d0c9a3f31e0c
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/22/2018
ms.locfileid: "4128032"
---
# <a name="mediamarketplaceidcontentrating"></a><span data-ttu-id="425ea-104">/media/{marketplaceId}/contentRating</span><span class="sxs-lookup"><span data-stu-id="425ea-104">/media/{marketplaceId}/contentRating</span></span>
<span data-ttu-id="425ea-105">コンテンツの規制トークンにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="425ea-105">Access the content rating token.</span></span> <span data-ttu-id="425ea-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="425ea-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="425ea-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="425ea-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="425ea-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="425ea-108">URI parameters</span></span>
 
| <span data-ttu-id="425ea-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="425ea-109">Parameter</span></span>| <span data-ttu-id="425ea-110">型</span><span class="sxs-lookup"><span data-stu-id="425ea-110">Type</span></span>| <span data-ttu-id="425ea-111">説明</span><span class="sxs-lookup"><span data-stu-id="425ea-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="425ea-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="425ea-112">marketplaceId</span></span>| <span data-ttu-id="425ea-113">string</span><span class="sxs-lookup"><span data-stu-id="425ea-113">string</span></span>| <span data-ttu-id="425ea-114">必須。</span><span class="sxs-lookup"><span data-stu-id="425ea-114">Required.</span></span> <span data-ttu-id="425ea-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="425ea-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EUB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="425ea-116">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="425ea-116">Valid methods</span></span>

[<span data-ttu-id="425ea-117">GET (/media/{marketplaceId}/contentRating)</span><span class="sxs-lookup"><span data-stu-id="425ea-117">GET (/media/{marketplaceId}/contentRating)</span></span>](uri-medialocalecontentratingget.md)

<span data-ttu-id="425ea-118">&nbsp;&nbsp;コンテンツの規制のトークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="425ea-118">&nbsp;&nbsp;Get the content rating token.</span></span>
 
<a id="ID4E5B"></a>

 
## <a name="see-also"></a><span data-ttu-id="425ea-119">関連項目</span><span class="sxs-lookup"><span data-stu-id="425ea-119">See also</span></span>
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="425ea-120">Parent</span><span class="sxs-lookup"><span data-stu-id="425ea-120">Parent</span></span> 

[<span data-ttu-id="425ea-121">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="425ea-121">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EKC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="425ea-122">詳細情報</span><span class="sxs-lookup"><span data-stu-id="425ea-122">Further Information</span></span> 

[<span data-ttu-id="425ea-123">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="425ea-123">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="425ea-124">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="425ea-124">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="425ea-125">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="425ea-125">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="425ea-126">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="425ea-126">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   