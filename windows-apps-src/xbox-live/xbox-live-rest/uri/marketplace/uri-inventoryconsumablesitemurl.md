---
title: /users/me/consumables/{itemID}
assetID: 45724827-5e35-326f-3f17-f49e606d9e08
permalink: en-us/docs/xboxlive/rest/uri-inventoryconsumablesitemurl.html
author: KevinAsgari
description: ユーザーの Xbox コンシューマブルの項目の rESTful エンドポイントです。
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7ed278542fa538a1297069b0f7d67d413e180f30
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4532967"
---
# <a name="usersmeconsumablesitemid"></a><span data-ttu-id="31983-104">/users/me/consumables/{itemID}</span><span class="sxs-lookup"><span data-stu-id="31983-104">/users/me/consumables/{itemID}</span></span>
<span data-ttu-id="31983-105">特定のコンシューマブルなインベントリ項目の詳細情報の完全なセットにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="31983-105">Accesses the full set of details for a specific consumable inventory item.</span></span>
<span data-ttu-id="31983-106">これらの Uri のドメインが`inventory.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="31983-106">The domain for these URIs is `inventory.xboxlive.com`.</span></span>

  * [<span data-ttu-id="31983-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="31983-107">URI parameters</span></span>](#ID4EV)

<a id="ID4EV"></a>


## <a name="uri-parameters"></a><span data-ttu-id="31983-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="31983-108">URI parameters</span></span>

| <span data-ttu-id="31983-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="31983-109">Parameter</span></span>| <span data-ttu-id="31983-110">型</span><span class="sxs-lookup"><span data-stu-id="31983-110">Type</span></span>| <span data-ttu-id="31983-111">説明</span><span class="sxs-lookup"><span data-stu-id="31983-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="31983-112">itemID</span><span class="sxs-lookup"><span data-stu-id="31983-112">itemID</span></span>| <span data-ttu-id="31983-113">string</span><span class="sxs-lookup"><span data-stu-id="31983-113">string</span></span>| <span data-ttu-id="31983-114">単数形インベントリ項目の各ユーザーに一意の ID</span><span class="sxs-lookup"><span data-stu-id="31983-114">the ID unique to each user for a singular inventory item</span></span>|

<a id="ID4ERB"></a>


## <a name="valid-methods"></a><span data-ttu-id="31983-115">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="31983-115">Valid methods</span></span>

[<span data-ttu-id="31983-116">POST ({itemID})</span><span class="sxs-lookup"><span data-stu-id="31983-116">POST ({itemID})</span></span>](uri-inventoryconsumablesitemurlpost.md)

<span data-ttu-id="31983-117">&nbsp;&nbsp;または、コンシューマブルなインベントリ項目の一部が使用されていることを示しますとデクリメント、コンシューマブルを要求した量の数量。</span><span class="sxs-lookup"><span data-stu-id="31983-117">&nbsp;&nbsp;Indicates that all or a portion of a consumable inventory item has been used and decrements the quantity of the consumable by the requested amount.</span></span>

<a id="ID4E4B"></a>


## <a name="see-also"></a><span data-ttu-id="31983-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="31983-118">See also</span></span>

<a id="ID4E6B"></a>


##### <a name="parent"></a><span data-ttu-id="31983-119">Parent</span><span class="sxs-lookup"><span data-stu-id="31983-119">Parent</span></span>

[<span data-ttu-id="31983-120">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="31983-120">Marketplace URIs</span></span>](atoc-reference-marketplace.md)


<a id="ID4EJC"></a>


##### <a name="further-information"></a><span data-ttu-id="31983-121">詳細情報</span><span class="sxs-lookup"><span data-stu-id="31983-121">Further Information</span></span>

[<span data-ttu-id="31983-122">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="31983-122">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="31983-123">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="31983-123">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="31983-124">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="31983-124">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="31983-125">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="31983-125">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)
