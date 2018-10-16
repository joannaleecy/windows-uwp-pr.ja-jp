---
title: /media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues
assetID: 7aa5a800-f69a-4f4b-23a7-424b50bb8afe
permalink: en-us/docs/xboxlive/rest/uri-medialocalemediaitemtypequeryrefinersubqueryrefinervalues.html
author: KevinAsgari
description: " /media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e9c78ca27407a26212e5a778807c0e28ae5fda2f
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4616380"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefinersqueryrefinersubqueryrefinervalues"></a><span data-ttu-id="b4ba6-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues</span><span class="sxs-lookup"><span data-stu-id="b4ba6-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues</span></span>
<span data-ttu-id="b4ba6-105">指定されたクエリの絞り込み条件値 ("subgenres には、指定されたジャンル"など) のサブ値の一覧にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="b4ba6-105">Access the list of sub-values for a given query refiner value (e.g., "subgenres in a given genre").</span></span> <span data-ttu-id="b4ba6-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b4ba6-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="b4ba6-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b4ba6-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="b4ba6-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b4ba6-108">URI parameters</span></span>
 
| <span data-ttu-id="b4ba6-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b4ba6-109">Parameter</span></span>| <span data-ttu-id="b4ba6-110">型</span><span class="sxs-lookup"><span data-stu-id="b4ba6-110">Type</span></span>| <span data-ttu-id="b4ba6-111">説明</span><span class="sxs-lookup"><span data-stu-id="b4ba6-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b4ba6-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="b4ba6-112">marketplaceId</span></span>| <span data-ttu-id="b4ba6-113">string</span><span class="sxs-lookup"><span data-stu-id="b4ba6-113">string</span></span>| <span data-ttu-id="b4ba6-114">必須。</span><span class="sxs-lookup"><span data-stu-id="b4ba6-114">Required.</span></span> <span data-ttu-id="b4ba6-115">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="b4ba6-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EWB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="b4ba6-116">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="b4ba6-116">Valid methods</span></span>

[<span data-ttu-id="b4ba6-117">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)</span><span class="sxs-lookup"><span data-stu-id="b4ba6-117">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)</span></span>](uri-medialocalemediaitemtypequeryrefinersubqueryrefinervaluesget.md)

<span data-ttu-id="b4ba6-118">&nbsp;&nbsp;指定されたクエリの絞り込み条件値 ("subgenres には、指定されたジャンル"など) のサブ値の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="b4ba6-118">&nbsp;&nbsp;Get the list of sub-values for a given query refiner value (e.g., "subgenres in a given genre").</span></span> 
 
<a id="ID4EAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="b4ba6-119">関連項目</span><span class="sxs-lookup"><span data-stu-id="b4ba6-119">See also</span></span>
 
<a id="ID4ECC"></a>

 
##### <a name="parent"></a><span data-ttu-id="b4ba6-120">Parent</span><span class="sxs-lookup"><span data-stu-id="b4ba6-120">Parent</span></span> 

[<span data-ttu-id="b4ba6-121">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="b4ba6-121">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EMC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="b4ba6-122">詳細情報</span><span class="sxs-lookup"><span data-stu-id="b4ba6-122">Further Information</span></span> 

[<span data-ttu-id="b4ba6-123">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b4ba6-123">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="b4ba6-124">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="b4ba6-124">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="b4ba6-125">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="b4ba6-125">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="b4ba6-126">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="b4ba6-126">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   