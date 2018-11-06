---
title: /users/me/consumables/{itemID}
assetID: 45724827-5e35-326f-3f17-f49e606d9e08
permalink: en-us/docs/xboxlive/rest/uri-inventoryconsumablesitemurl.html
author: KevinAsgari
description: ユーザーの Xbox コンシューマブルの項目の rESTful エンドポイントです。
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: bbdf869cffae575f53555b31d9ed66647d3d09b2
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6046583"
---
# <a name="usersmeconsumablesitemid"></a><span data-ttu-id="d3c06-104">/users/me/consumables/{itemID}</span><span class="sxs-lookup"><span data-stu-id="d3c06-104">/users/me/consumables/{itemID}</span></span>
<span data-ttu-id="d3c06-105">特定のコンシューマブルなインベントリ項目の詳細情報の完全なセットにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="d3c06-105">Accesses the full set of details for a specific consumable inventory item.</span></span>
<span data-ttu-id="d3c06-106">これらの Uri のドメインが`inventory.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="d3c06-106">The domain for these URIs is `inventory.xboxlive.com`.</span></span>

  * [<span data-ttu-id="d3c06-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d3c06-107">URI parameters</span></span>](#ID4EV)

<a id="ID4EV"></a>


## <a name="uri-parameters"></a><span data-ttu-id="d3c06-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d3c06-108">URI parameters</span></span>

| <span data-ttu-id="d3c06-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d3c06-109">Parameter</span></span>| <span data-ttu-id="d3c06-110">型</span><span class="sxs-lookup"><span data-stu-id="d3c06-110">Type</span></span>| <span data-ttu-id="d3c06-111">説明</span><span class="sxs-lookup"><span data-stu-id="d3c06-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="d3c06-112">itemID</span><span class="sxs-lookup"><span data-stu-id="d3c06-112">itemID</span></span>| <span data-ttu-id="d3c06-113">string</span><span class="sxs-lookup"><span data-stu-id="d3c06-113">string</span></span>| <span data-ttu-id="d3c06-114">単数形インベントリ項目の各ユーザーに一意の ID</span><span class="sxs-lookup"><span data-stu-id="d3c06-114">the ID unique to each user for a singular inventory item</span></span>|

<a id="ID4ERB"></a>


## <a name="valid-methods"></a><span data-ttu-id="d3c06-115">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="d3c06-115">Valid methods</span></span>

[<span data-ttu-id="d3c06-116">POST ({itemID})</span><span class="sxs-lookup"><span data-stu-id="d3c06-116">POST ({itemID})</span></span>](uri-inventoryconsumablesitemurlpost.md)

<span data-ttu-id="d3c06-117">&nbsp;&nbsp;または、コンシューマブルなインベントリ項目の一部が使用されていることを示しますとデクリメント、要求された時間の長さによって、コンシューマブルの数量。</span><span class="sxs-lookup"><span data-stu-id="d3c06-117">&nbsp;&nbsp;Indicates that all or a portion of a consumable inventory item has been used and decrements the quantity of the consumable by the requested amount.</span></span>

<a id="ID4E4B"></a>


## <a name="see-also"></a><span data-ttu-id="d3c06-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="d3c06-118">See also</span></span>

<a id="ID4E6B"></a>


##### <a name="parent"></a><span data-ttu-id="d3c06-119">Parent</span><span class="sxs-lookup"><span data-stu-id="d3c06-119">Parent</span></span>

[<span data-ttu-id="d3c06-120">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="d3c06-120">Marketplace URIs</span></span>](atoc-reference-marketplace.md)


<a id="ID4EJC"></a>


##### <a name="further-information"></a><span data-ttu-id="d3c06-121">詳細情報</span><span class="sxs-lookup"><span data-stu-id="d3c06-121">Further Information</span></span>

[<span data-ttu-id="d3c06-122">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d3c06-122">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="d3c06-123">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="d3c06-123">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="d3c06-124">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="d3c06-124">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="d3c06-125">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="d3c06-125">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)
