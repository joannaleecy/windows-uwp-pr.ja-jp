---
title: /media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues
assetID: 7aa5a800-f69a-4f4b-23a7-424b50bb8afe
permalink: en-us/docs/xboxlive/rest/uri-medialocalemediaitemtypequeryrefinersubqueryrefinervalues.html
author: KevinAsgari
description: " /media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e9c78ca27407a26212e5a778807c0e28ae5fda2f
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881548"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefinersqueryrefinersubqueryrefinervalues"></a><span data-ttu-id="d5792-104">/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues</span><span class="sxs-lookup"><span data-stu-id="d5792-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues</span></span>
<span data-ttu-id="d5792-105">指定されたクエリの調整値 ("subgenres には、指定されたジャンル"など) のサブ値の一覧にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="d5792-105">Access the list of sub-values for a given query refiner value (e.g., "subgenres in a given genre").</span></span> <span data-ttu-id="d5792-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="d5792-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="d5792-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d5792-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="d5792-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d5792-108">URI parameters</span></span>
 
| <span data-ttu-id="d5792-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d5792-109">Parameter</span></span>| <span data-ttu-id="d5792-110">型</span><span class="sxs-lookup"><span data-stu-id="d5792-110">Type</span></span>| <span data-ttu-id="d5792-111">説明</span><span class="sxs-lookup"><span data-stu-id="d5792-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d5792-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="d5792-112">marketplaceId</span></span>| <span data-ttu-id="d5792-113">string</span><span class="sxs-lookup"><span data-stu-id="d5792-113">string</span></span>| <span data-ttu-id="d5792-114">必須。</span><span class="sxs-lookup"><span data-stu-id="d5792-114">Required.</span></span> <span data-ttu-id="d5792-115"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="d5792-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EWB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="d5792-116">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="d5792-116">Valid methods</span></span>

[<span data-ttu-id="d5792-117">取得する (/media/{marketplaceId}/メタデータ/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)</span><span class="sxs-lookup"><span data-stu-id="d5792-117">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)</span></span>](uri-medialocalemediaitemtypequeryrefinersubqueryrefinervaluesget.md)

<span data-ttu-id="d5792-118">&nbsp;&nbsp;指定されたクエリの調整値 ("subgenres には、指定されたジャンル"など) のサブ値の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="d5792-118">&nbsp;&nbsp;Get the list of sub-values for a given query refiner value (e.g., "subgenres in a given genre").</span></span> 
 
<a id="ID4EAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="d5792-119">関連項目</span><span class="sxs-lookup"><span data-stu-id="d5792-119">See also</span></span>
 
<a id="ID4ECC"></a>

 
##### <a name="parent"></a><span data-ttu-id="d5792-120">Parent</span><span class="sxs-lookup"><span data-stu-id="d5792-120">Parent</span></span> 

[<span data-ttu-id="d5792-121">Marketplace Uri</span><span class="sxs-lookup"><span data-stu-id="d5792-121">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EMC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="d5792-122">詳細情報</span><span class="sxs-lookup"><span data-stu-id="d5792-122">Further Information</span></span> 

[<span data-ttu-id="d5792-123">EDS 一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="d5792-123">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="d5792-124">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="d5792-124">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="d5792-125">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="d5792-125">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="d5792-126">その他の参照</span><span class="sxs-lookup"><span data-stu-id="d5792-126">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   