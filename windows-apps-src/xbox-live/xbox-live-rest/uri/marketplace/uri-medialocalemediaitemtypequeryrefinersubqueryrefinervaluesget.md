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
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/22/2018
ms.locfileid: "4124350"
---
# <a name="get-mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefinersqueryrefinersubqueryrefinervalues"></a><span data-ttu-id="8cc91-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)</span><span class="sxs-lookup"><span data-stu-id="8cc91-104">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)</span></span>
<span data-ttu-id="8cc91-105">指定されたクエリの調整値 ("subgenres には、指定したジャンル"など) のサブ値の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="8cc91-105">Get the list of sub-values for a given query refiner value (e.g., "subgenres in a given genre").</span></span> <span data-ttu-id="8cc91-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="8cc91-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="8cc91-107">注釈</span><span class="sxs-lookup"><span data-stu-id="8cc91-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="8cc91-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8cc91-108">URI parameters</span></span>](#ID4EDB)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="8cc91-109">注釈</span><span class="sxs-lookup"><span data-stu-id="8cc91-109">Remarks</span></span>
 
<span data-ttu-id="8cc91-110">クエリの調整値はで**queryRefinerValue**クエリに渡される URI 語幹で禁止されている文字の調整値を許可する動作を行うという名前のクエリ文字列パラメーターとして渡されます。</span><span class="sxs-lookup"><span data-stu-id="8cc91-110">The query refiner value is passed in as a query string parameter named **queryRefinerValue**, which is done to allow query refiner values with characters forbidden in URI stems to be passed.</span></span>
 
<span data-ttu-id="8cc91-111">この API は、音楽ののみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="8cc91-111">This API is only supported for Music.</span></span>
  
<a id="ID4EDB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="8cc91-112">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8cc91-112">URI parameters</span></span>
 
| <span data-ttu-id="8cc91-113">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8cc91-113">Parameter</span></span>| <span data-ttu-id="8cc91-114">型</span><span class="sxs-lookup"><span data-stu-id="8cc91-114">Type</span></span>| <span data-ttu-id="8cc91-115">説明</span><span class="sxs-lookup"><span data-stu-id="8cc91-115">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="8cc91-116">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="8cc91-116">marketplaceId</span></span>| <span data-ttu-id="8cc91-117">string</span><span class="sxs-lookup"><span data-stu-id="8cc91-117">string</span></span>| <span data-ttu-id="8cc91-118">必須。</span><span class="sxs-lookup"><span data-stu-id="8cc91-118">Required.</span></span> <span data-ttu-id="8cc91-119">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="8cc91-119">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EOB"></a>

 
## <a name="see-also"></a><span data-ttu-id="8cc91-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="8cc91-120">See also</span></span>
 
<a id="ID4EQB"></a>

 
##### <a name="parent"></a><span data-ttu-id="8cc91-121">Parent</span><span class="sxs-lookup"><span data-stu-id="8cc91-121">Parent</span></span> 

[<span data-ttu-id="8cc91-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues</span><span class="sxs-lookup"><span data-stu-id="8cc91-122">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues</span></span>](uri-medialocalemediaitemtypequeryrefinersubqueryrefinervalues.md)

  
<a id="ID4E1B"></a>

 
##### <a name="further-information"></a><span data-ttu-id="8cc91-123">詳細情報</span><span class="sxs-lookup"><span data-stu-id="8cc91-123">Further Information</span></span> 

[<span data-ttu-id="8cc91-124">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8cc91-124">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="8cc91-125">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="8cc91-125">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="8cc91-126">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="8cc91-126">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="8cc91-127">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="8cc91-127">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="8cc91-128">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="8cc91-128">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   