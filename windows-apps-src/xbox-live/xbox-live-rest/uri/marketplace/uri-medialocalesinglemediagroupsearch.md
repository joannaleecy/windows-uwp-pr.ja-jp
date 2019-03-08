---
title: /media/{marketplaceId}/singleMediaGroupSearch
assetID: f5599db7-4050-640e-db96-2df01a007c07
permalink: en-us/docs/xboxlive/rest/uri-medialocalesinglemediagroupsearch.html
description: " /media/{marketplaceId}/singleMediaGroupSearch"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b26b4c2dc51ef5591480372aa9908a49d2f8cbe2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661757"
---
# <a name="mediamarketplaceidsinglemediagroupsearch"></a><span data-ttu-id="333c5-104">/media/{marketplaceId}/singleMediaGroupSearch</span><span class="sxs-lookup"><span data-stu-id="333c5-104">/media/{marketplaceId}/singleMediaGroupSearch</span></span>
<span data-ttu-id="333c5-105">1 つのメディアのグループ内の項目を検索をできます。</span><span class="sxs-lookup"><span data-stu-id="333c5-105">Allows search for items within a single media group.</span></span> <span data-ttu-id="333c5-106">継続トークンを使用する代わりに非連続的に skipItems パラメーターを使用してこの検索で返されるデータのページにアクセスできることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="333c5-106">Note that pages of data returned from this search can be accessed non-sequentially using the skipItems parameter instead of using the continuation token.</span></span> <span data-ttu-id="333c5-107">この API は、クエリの絞り込み条件を受け入れます。</span><span class="sxs-lookup"><span data-stu-id="333c5-107">This API accepts Query Refiners.</span></span>
 
<span data-ttu-id="333c5-108">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="333c5-108">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="333c5-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="333c5-109">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="333c5-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="333c5-110">URI parameters</span></span>
 
| <span data-ttu-id="333c5-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="333c5-111">Parameter</span></span>| <span data-ttu-id="333c5-112">種類</span><span class="sxs-lookup"><span data-stu-id="333c5-112">Type</span></span>| <span data-ttu-id="333c5-113">説明</span><span class="sxs-lookup"><span data-stu-id="333c5-113">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="333c5-114">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="333c5-114">marketplaceId</span></span>| <span data-ttu-id="333c5-115">string</span><span class="sxs-lookup"><span data-stu-id="333c5-115">string</span></span>| <span data-ttu-id="333c5-116">必須。</span><span class="sxs-lookup"><span data-stu-id="333c5-116">Required.</span></span> <span data-ttu-id="333c5-117">文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。</span><span class="sxs-lookup"><span data-stu-id="333c5-117">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EYB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="333c5-118">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="333c5-118">Valid methods</span></span>

[<span data-ttu-id="333c5-119">取得 (メディア/{marketplaceId}/singleMediaGroupSearch)</span><span class="sxs-lookup"><span data-stu-id="333c5-119">GET (media/{marketplaceId}/singleMediaGroupSearch)</span></span>](uri-medialocalesinglemediagroupsearchget.md)

<span data-ttu-id="333c5-120">&nbsp;&nbsp;1 つのメディアのグループ内の項目を検索をできます。</span><span class="sxs-lookup"><span data-stu-id="333c5-120">&nbsp;&nbsp;Allows search for items within a single media group.</span></span> 
 
<a id="ID4ECC"></a>

 
## <a name="see-also"></a><span data-ttu-id="333c5-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="333c5-121">See also</span></span>
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a><span data-ttu-id="333c5-122">Parent</span><span class="sxs-lookup"><span data-stu-id="333c5-122">Parent</span></span> 

[<span data-ttu-id="333c5-123">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="333c5-123">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EOC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="333c5-124">詳細情報</span><span class="sxs-lookup"><span data-stu-id="333c5-124">Further Information</span></span> 

[<span data-ttu-id="333c5-125">EDS の一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="333c5-125">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="333c5-126">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="333c5-126">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="333c5-127">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="333c5-127">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="333c5-128">その他の参照</span><span class="sxs-lookup"><span data-stu-id="333c5-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   