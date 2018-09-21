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
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4082578"
---
# <a name="usersmeconsumablesitemid"></a><span data-ttu-id="cb248-104">/users/me/consumables/{itemID}</span><span class="sxs-lookup"><span data-stu-id="cb248-104">/users/me/consumables/{itemID}</span></span>
<span data-ttu-id="cb248-105">特定のコンシューマブルなインベントリ項目の詳細情報の完全なセットにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="cb248-105">Accesses the full set of details for a specific consumable inventory item.</span></span>
<span data-ttu-id="cb248-106">これらの Uri のドメインが`inventory.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="cb248-106">The domain for these URIs is `inventory.xboxlive.com`.</span></span>

  * [<span data-ttu-id="cb248-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cb248-107">URI parameters</span></span>](#ID4EV)

<a id="ID4EV"></a>


## <a name="uri-parameters"></a><span data-ttu-id="cb248-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cb248-108">URI parameters</span></span>

| <span data-ttu-id="cb248-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="cb248-109">Parameter</span></span>| <span data-ttu-id="cb248-110">型</span><span class="sxs-lookup"><span data-stu-id="cb248-110">Type</span></span>| <span data-ttu-id="cb248-111">説明</span><span class="sxs-lookup"><span data-stu-id="cb248-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="cb248-112">itemID</span><span class="sxs-lookup"><span data-stu-id="cb248-112">itemID</span></span>| <span data-ttu-id="cb248-113">string</span><span class="sxs-lookup"><span data-stu-id="cb248-113">string</span></span>| <span data-ttu-id="cb248-114">単数形インベントリ項目の各ユーザーに一意の ID</span><span class="sxs-lookup"><span data-stu-id="cb248-114">the ID unique to each user for a singular inventory item</span></span>|

<a id="ID4ERB"></a>


## <a name="valid-methods"></a><span data-ttu-id="cb248-115">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="cb248-115">Valid methods</span></span>

[<span data-ttu-id="cb248-116">POST ({itemID})</span><span class="sxs-lookup"><span data-stu-id="cb248-116">POST ({itemID})</span></span>](uri-inventoryconsumablesitemurlpost.md)

<span data-ttu-id="cb248-117">&nbsp;&nbsp;またはのコンシューマブルなインベントリ項目の一部が使用されていることを示しますデクリメントし、要求された時間の長さによって、コンシューマブルの数量。</span><span class="sxs-lookup"><span data-stu-id="cb248-117">&nbsp;&nbsp;Indicates that all or a portion of a consumable inventory item has been used and decrements the quantity of the consumable by the requested amount.</span></span>

<a id="ID4E4B"></a>


## <a name="see-also"></a><span data-ttu-id="cb248-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="cb248-118">See also</span></span>

<a id="ID4E6B"></a>


##### <a name="parent"></a><span data-ttu-id="cb248-119">Parent</span><span class="sxs-lookup"><span data-stu-id="cb248-119">Parent</span></span>

[<span data-ttu-id="cb248-120">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="cb248-120">Marketplace URIs</span></span>](atoc-reference-marketplace.md)


<a id="ID4EJC"></a>


##### <a name="further-information"></a><span data-ttu-id="cb248-121">詳細情報</span><span class="sxs-lookup"><span data-stu-id="cb248-121">Further Information</span></span>

[<span data-ttu-id="cb248-122">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cb248-122">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="cb248-123">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="cb248-123">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="cb248-124">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="cb248-124">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="cb248-125">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="cb248-125">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)
