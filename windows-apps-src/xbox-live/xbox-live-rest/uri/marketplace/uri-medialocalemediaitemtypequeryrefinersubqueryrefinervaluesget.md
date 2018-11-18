---
title: GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)
assetID: 0fcbef77-4607-765e-72e1-d2e7620e2c61
permalink: en-us/docs/xboxlive/rest/uri-medialocalemediaitemtypequeryrefinersubqueryrefinervaluesget.html
author: KevinAsgari
description: " GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1974a6a2affeca26bc52cd2fdfabf3364b20bd61
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7150271"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefinersqueryrefinersubqueryrefinervalues"></a><span data-ttu-id="b4ab8-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)</span><span class="sxs-lookup"><span data-stu-id="b4ab8-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)</span></span>
<span data-ttu-id="b4ab8-105">指定されたクエリの絞り込み条件値 ("subgenres には、指定されたジャンル"など) のサブ値の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="b4ab8-105">Get the list of sub-values for a given query refiner value (e.g., "subgenres in a given genre").</span></span> <span data-ttu-id="b4ab8-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b4ab8-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="b4ab8-107">注釈</span><span class="sxs-lookup"><span data-stu-id="b4ab8-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="b4ab8-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b4ab8-108">URI parameters</span></span>](#ID4EDB)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="b4ab8-109">注釈</span><span class="sxs-lookup"><span data-stu-id="b4ab8-109">Remarks</span></span>
 
<span data-ttu-id="b4ab8-110">クエリの絞り込み条件値はでという名前の**queryRefinerValue**値を許可するクエリ絞り込み条件を渡すことが URI 語幹で禁止されている文字で行われますクエリ文字列パラメーターとして渡されます。</span><span class="sxs-lookup"><span data-stu-id="b4ab8-110">The query refiner value is passed in as a query string parameter named **queryRefinerValue**, which is done to allow query refiner values with characters forbidden in URI stems to be passed.</span></span>
 
<span data-ttu-id="b4ab8-111">この API は、音楽ののみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="b4ab8-111">This API is only supported for Music.</span></span>
  
<a id="ID4EDB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="b4ab8-112">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b4ab8-112">URI parameters</span></span>
 
| <span data-ttu-id="b4ab8-113">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b4ab8-113">Parameter</span></span>| <span data-ttu-id="b4ab8-114">型</span><span class="sxs-lookup"><span data-stu-id="b4ab8-114">Type</span></span>| <span data-ttu-id="b4ab8-115">説明</span><span class="sxs-lookup"><span data-stu-id="b4ab8-115">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b4ab8-116">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="b4ab8-116">marketplaceId</span></span>| <span data-ttu-id="b4ab8-117">string</span><span class="sxs-lookup"><span data-stu-id="b4ab8-117">string</span></span>| <span data-ttu-id="b4ab8-118">必須。</span><span class="sxs-lookup"><span data-stu-id="b4ab8-118">Required.</span></span> <span data-ttu-id="b4ab8-119"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="b4ab8-119">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EOB"></a>

 
## <a name="see-also"></a><span data-ttu-id="b4ab8-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="b4ab8-120">See also</span></span>
 
<a id="ID4EQB"></a>

 
##### <a name="parent"></a><span data-ttu-id="b4ab8-121">Parent</span><span class="sxs-lookup"><span data-stu-id="b4ab8-121">Parent</span></span> 

[<span data-ttu-id="b4ab8-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues</span><span class="sxs-lookup"><span data-stu-id="b4ab8-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues</span></span>](uri-medialocalemediaitemtypequeryrefinersubqueryrefinervalues.md)

  
<a id="ID4E1B"></a>

 
##### <a name="further-information"></a><span data-ttu-id="b4ab8-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="b4ab8-123">Further Information</span></span> 

[<span data-ttu-id="b4ab8-124">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b4ab8-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="b4ab8-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="b4ab8-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="b4ab8-126">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="b4ab8-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="b4ab8-127">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="b4ab8-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="b4ab8-128">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="b4ab8-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   