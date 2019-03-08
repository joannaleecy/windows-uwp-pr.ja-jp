---
title: /media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues
assetID: 7aa5a800-f69a-4f4b-23a7-424b50bb8afe
permalink: en-us/docs/xboxlive/rest/uri-medialocalemediaitemtypequeryrefinersubqueryrefinervalues.html
description: " /media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e09a0d755f8f88e009714a4ef11f885d1b646f99
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641517"
---
# <a name="mediamarketplaceidmetadatamediaitemtypesmediaitemtypequeryrefinersqueryrefinersubqueryrefinervalues"></a><span data-ttu-id="46742-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues</span><span class="sxs-lookup"><span data-stu-id="46742-104">/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues</span></span>
<span data-ttu-id="46742-105">指定されたクエリの調整値 ("subgenres には、特定のジャンル"など) のサブの値の一覧にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="46742-105">Access the list of sub-values for a given query refiner value (e.g., "subgenres in a given genre").</span></span> <span data-ttu-id="46742-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="46742-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="46742-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="46742-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="46742-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="46742-108">URI parameters</span></span>
 
| <span data-ttu-id="46742-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="46742-109">Parameter</span></span>| <span data-ttu-id="46742-110">種類</span><span class="sxs-lookup"><span data-stu-id="46742-110">Type</span></span>| <span data-ttu-id="46742-111">説明</span><span class="sxs-lookup"><span data-stu-id="46742-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="46742-112">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="46742-112">marketplaceId</span></span>| <span data-ttu-id="46742-113">string</span><span class="sxs-lookup"><span data-stu-id="46742-113">string</span></span>| <span data-ttu-id="46742-114">必須。</span><span class="sxs-lookup"><span data-stu-id="46742-114">Required.</span></span> <span data-ttu-id="46742-115">文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。</span><span class="sxs-lookup"><span data-stu-id="46742-115">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EWB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="46742-116">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="46742-116">Valid methods</span></span>

[<span data-ttu-id="46742-117">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)</span><span class="sxs-lookup"><span data-stu-id="46742-117">GET (/media/{marketplaceId}/metadata/mediaItemTypes/{mediaitemtype}/queryrefiners/{queryRefiner}/subQueryRefinerValues)</span></span>](uri-medialocalemediaitemtypequeryrefinersubqueryrefinervaluesget.md)

<span data-ttu-id="46742-118">&nbsp;&nbsp;指定されたクエリの調整値 ("subgenres には、特定のジャンル"など) のサブ値の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="46742-118">&nbsp;&nbsp;Get the list of sub-values for a given query refiner value (e.g., "subgenres in a given genre").</span></span> 
 
<a id="ID4EAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="46742-119">関連項目</span><span class="sxs-lookup"><span data-stu-id="46742-119">See also</span></span>
 
<a id="ID4ECC"></a>

 
##### <a name="parent"></a><span data-ttu-id="46742-120">Parent</span><span class="sxs-lookup"><span data-stu-id="46742-120">Parent</span></span> 

[<span data-ttu-id="46742-121">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="46742-121">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

  
<a id="ID4EMC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="46742-122">詳細情報</span><span class="sxs-lookup"><span data-stu-id="46742-122">Further Information</span></span> 

[<span data-ttu-id="46742-123">EDS の一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="46742-123">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="46742-124">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="46742-124">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="46742-125">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="46742-125">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="46742-126">その他の参照</span><span class="sxs-lookup"><span data-stu-id="46742-126">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   