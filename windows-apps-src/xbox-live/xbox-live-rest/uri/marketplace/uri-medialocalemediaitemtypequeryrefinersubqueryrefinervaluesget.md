---
title: GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)
assetID: 0fcbef77-4607-765e-72e1-d2e7620e2c61
permalink: en-us/docs/xboxlive/rest/uri-medialocalemediaitemtypequeryrefinersubqueryrefinervaluesget.html
author: KevinAsgari
description: " GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 036a64f893ab1581d42f1601204b383968c607e3
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4024137"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefinersqueryrefinersubqueryrefinervalues"></a><span data-ttu-id="a7833-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)</span><span class="sxs-lookup"><span data-stu-id="a7833-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)</span></span>
<span data-ttu-id="a7833-105">指定されたクエリの調整値 ("subgenres には、指定したジャンル"など) のサブ値の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="a7833-105">Get the list of sub-values for a given query refiner value (e.g., "subgenres in a given genre").</span></span> <span data-ttu-id="a7833-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="a7833-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="a7833-107">注釈</span><span class="sxs-lookup"><span data-stu-id="a7833-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="a7833-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a7833-108">URI parameters</span></span>](#ID4EDB)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="a7833-109">注釈</span><span class="sxs-lookup"><span data-stu-id="a7833-109">Remarks</span></span>
 
<span data-ttu-id="a7833-110">クエリの調整値はで**queryRefinerValue**クエリに渡される URI 語幹で禁止されている文字の調整値を許可する動作を行うという名前のクエリ文字列パラメーターとして渡されます。</span><span class="sxs-lookup"><span data-stu-id="a7833-110">The query refiner value is passed in as a query string parameter named **queryRefinerValue**, which is done to allow query refiner values with characters forbidden in URI stems to be passed.</span></span>
 
<span data-ttu-id="a7833-111">この API は、音楽ののみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="a7833-111">This API is only supported for Music.</span></span>
  
<a id="ID4EDB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="a7833-112">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a7833-112">URI parameters</span></span>
 
| <span data-ttu-id="a7833-113">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a7833-113">Parameter</span></span>| <span data-ttu-id="a7833-114">型</span><span class="sxs-lookup"><span data-stu-id="a7833-114">Type</span></span>| <span data-ttu-id="a7833-115">説明</span><span class="sxs-lookup"><span data-stu-id="a7833-115">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="a7833-116">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="a7833-116">marketplaceId</span></span>| <span data-ttu-id="a7833-117">string</span><span class="sxs-lookup"><span data-stu-id="a7833-117">string</span></span>| <span data-ttu-id="a7833-118">必須。</span><span class="sxs-lookup"><span data-stu-id="a7833-118">Required.</span></span> <span data-ttu-id="a7833-119">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="a7833-119">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EOB"></a>

 
## <a name="see-also"></a><span data-ttu-id="a7833-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="a7833-120">See also</span></span>
 
<a id="ID4EQB"></a>

 
##### <a name="parent"></a><span data-ttu-id="a7833-121">Parent</span><span class="sxs-lookup"><span data-stu-id="a7833-121">Parent</span></span> 

[<span data-ttu-id="a7833-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues</span><span class="sxs-lookup"><span data-stu-id="a7833-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues</span></span>](uri-medialocalemediaitemtypequeryrefinersubqueryrefinervalues.md)

  
<a id="ID4E1B"></a>

 
##### <a name="further-information"></a><span data-ttu-id="a7833-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="a7833-123">Further Information</span></span> 

[<span data-ttu-id="a7833-124">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a7833-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="a7833-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="a7833-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="a7833-126">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="a7833-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="a7833-127">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="a7833-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="a7833-128">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="a7833-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   