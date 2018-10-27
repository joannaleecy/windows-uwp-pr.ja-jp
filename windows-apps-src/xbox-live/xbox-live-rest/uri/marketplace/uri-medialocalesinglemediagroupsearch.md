---
title: /media/{marketplaceId}/singleMediaGroupSearch
assetID: f5599db7-4050-640e-db96-2df01a007c07
permalink: en-us/docs/xboxlive/rest/uri-medialocalesinglemediagroupsearch.html
author: KevinAsgari
description: " /media/{marketplaceId}/singleMediaGroupSearch"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3157f7152d7bf4d864d706e04a7ea345e248a431
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5692531"
---
# <a name="mediamarketplaceidsinglemediagroupsearch"></a><span data-ttu-id="2fd01-104">/media/{marketplaceId}/singleMediaGroupSearch</span><span class="sxs-lookup"><span data-stu-id="2fd01-104">/media/{marketplaceId}/singleMediaGroupSearch</span></span>
<span data-ttu-id="2fd01-105">1 つのメディア グループ内の項目を検索をできます。</span><span class="sxs-lookup"><span data-stu-id="2fd01-105">Allows search for items within a single media group.</span></span> <span data-ttu-id="2fd01-106">非連続的に継続トークンを使用するのではなく skipItems パラメーターを使用してこの検索から返されるデータのページにアクセスできることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="2fd01-106">Note that pages of data returned from this search can be accessed non-sequentially using the skipItems parameter instead of using the continuation token.</span></span> <span data-ttu-id="2fd01-107">この API は、クエリの絞り込み条件を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="2fd01-107">This API accepts Query Refiners.</span></span>
 
<span data-ttu-id="2fd01-108">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="2fd01-108">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="2fd01-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2fd01-109">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="2fd01-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2fd01-110">URI parameters</span></span>
 
| <span data-ttu-id="2fd01-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="2fd01-111">Parameter</span></span>| <span data-ttu-id="2fd01-112">型</span><span class="sxs-lookup"><span data-stu-id="2fd01-112">Type</span></span>| <span data-ttu-id="2fd01-113">説明</span><span class="sxs-lookup"><span data-stu-id="2fd01-113">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="2fd01-114">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="2fd01-114">marketplaceId</span></span>| <span data-ttu-id="2fd01-115">string</span><span class="sxs-lookup"><span data-stu-id="2fd01-115">string</span></span>| <span data-ttu-id="2fd01-116">必須。</span><span class="sxs-lookup"><span data-stu-id="2fd01-116">Required.</span></span> <span data-ttu-id="2fd01-117">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="2fd01-117">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EYB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="2fd01-118">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="2fd01-118">Valid methods</span></span>

[<span data-ttu-id="2fd01-119">GET (media/{marketplaceId}/singleMediaGroupSearch)</span><span class="sxs-lookup"><span data-stu-id="2fd01-119">GET (media/{marketplaceId}/singleMediaGroupSearch)</span></span>](uri-medialocalesinglemediagroupsearchget.md)

<span data-ttu-id="2fd01-120">&nbsp;&nbsp;1 つのメディア グループ内の項目を検索をできます。</span><span class="sxs-lookup"><span data-stu-id="2fd01-120">&nbsp;&nbsp;Allows search for items within a single media group.</span></span> 
 
<a id="ID4ECC"></a>

 
## <a name="see-also"></a><span data-ttu-id="2fd01-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="2fd01-121">See also</span></span>
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a><span data-ttu-id="2fd01-122">Parent</span><span class="sxs-lookup"><span data-stu-id="2fd01-122">Parent</span></span> 

[<span data-ttu-id="2fd01-123">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="2fd01-123">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EOC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="2fd01-124">詳細情報</span><span class="sxs-lookup"><span data-stu-id="2fd01-124">Further Information</span></span> 

[<span data-ttu-id="2fd01-125">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2fd01-125">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="2fd01-126">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="2fd01-126">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="2fd01-127">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="2fd01-127">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="2fd01-128">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="2fd01-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   