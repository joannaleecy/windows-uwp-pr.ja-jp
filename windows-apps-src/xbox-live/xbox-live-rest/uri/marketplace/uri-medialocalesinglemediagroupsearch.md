---
title: /media/{marketplaceId}/singleMediaGroupSearch
assetID: f5599db7-4050-640e-db96-2df01a007c07
permalink: en-us/docs/xboxlive/rest/uri-medialocalesinglemediagroupsearch.html
author: KevinAsgari
description: " /media/{marketplaceId}/singleMediaGroupSearch"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e99fc70db836c36d8f92a4b4c4b12ec8e75c47e1
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4421681"
---
# <a name="mediamarketplaceidsinglemediagroupsearch"></a><span data-ttu-id="f07c9-104">/media/{marketplaceId}/singleMediaGroupSearch</span><span class="sxs-lookup"><span data-stu-id="f07c9-104">/media/{marketplaceId}/singleMediaGroupSearch</span></span>
<span data-ttu-id="f07c9-105">1 つのメディア グループ内の項目の検索を許可します。</span><span class="sxs-lookup"><span data-stu-id="f07c9-105">Allows search for items within a single media group.</span></span> <span data-ttu-id="f07c9-106">非連続的に継続トークンを使用するのではなく skipItems パラメーターを使用してこの検索から返されるデータのページにアクセスできることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="f07c9-106">Note that pages of data returned from this search can be accessed non-sequentially using the skipItems parameter instead of using the continuation token.</span></span> <span data-ttu-id="f07c9-107">この API は、クエリの絞り込み条件を受け入れます。</span><span class="sxs-lookup"><span data-stu-id="f07c9-107">This API accepts Query Refiners.</span></span>
 
<span data-ttu-id="f07c9-108">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="f07c9-108">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="f07c9-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f07c9-109">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="f07c9-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f07c9-110">URI parameters</span></span>
 
| <span data-ttu-id="f07c9-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f07c9-111">Parameter</span></span>| <span data-ttu-id="f07c9-112">型</span><span class="sxs-lookup"><span data-stu-id="f07c9-112">Type</span></span>| <span data-ttu-id="f07c9-113">説明</span><span class="sxs-lookup"><span data-stu-id="f07c9-113">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f07c9-114">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="f07c9-114">marketplaceId</span></span>| <span data-ttu-id="f07c9-115">string</span><span class="sxs-lookup"><span data-stu-id="f07c9-115">string</span></span>| <span data-ttu-id="f07c9-116">必須。</span><span class="sxs-lookup"><span data-stu-id="f07c9-116">Required.</span></span> <span data-ttu-id="f07c9-117">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="f07c9-117">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EYB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="f07c9-118">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="f07c9-118">Valid methods</span></span>

[<span data-ttu-id="f07c9-119">GET (media/{marketplaceId}/singleMediaGroupSearch)</span><span class="sxs-lookup"><span data-stu-id="f07c9-119">GET (media/{marketplaceId}/singleMediaGroupSearch)</span></span>](uri-medialocalesinglemediagroupsearchget.md)

<span data-ttu-id="f07c9-120">&nbsp;&nbsp;1 つのメディア グループ内の項目の検索を許可します。</span><span class="sxs-lookup"><span data-stu-id="f07c9-120">&nbsp;&nbsp;Allows search for items within a single media group.</span></span> 
 
<a id="ID4ECC"></a>

 
## <a name="see-also"></a><span data-ttu-id="f07c9-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="f07c9-121">See also</span></span>
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a><span data-ttu-id="f07c9-122">Parent</span><span class="sxs-lookup"><span data-stu-id="f07c9-122">Parent</span></span> 

[<span data-ttu-id="f07c9-123">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="f07c9-123">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EOC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="f07c9-124">詳細情報</span><span class="sxs-lookup"><span data-stu-id="f07c9-124">Further Information</span></span> 

[<span data-ttu-id="f07c9-125">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f07c9-125">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="f07c9-126">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="f07c9-126">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="f07c9-127">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="f07c9-127">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="f07c9-128">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="f07c9-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   