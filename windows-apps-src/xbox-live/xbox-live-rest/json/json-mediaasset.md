---
title: MediaAsset (JSON)
assetID: 858c720a-1648-738b-bb43-f050e7cac19e
permalink: en-us/docs/xboxlive/rest/json-mediaasset.html
description: " MediaAsset (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 308a65b7c049a6aba0405865bab63fb9d28b8506
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623477"
---
# <a name="mediaasset-json"></a><span data-ttu-id="7b88d-104">MediaAsset (JSON)</span><span class="sxs-lookup"><span data-stu-id="7b88d-104">MediaAsset (JSON)</span></span>
<span data-ttu-id="7b88d-105">実績またはその報酬に関連付けられたメディア資産。</span><span class="sxs-lookup"><span data-stu-id="7b88d-105">The media assets associated with the achievement or its rewards.</span></span>
<a id="ID4EN"></a>


## <a name="mediaasset"></a><span data-ttu-id="7b88d-106">MediaAsset</span><span class="sxs-lookup"><span data-stu-id="7b88d-106">MediaAsset</span></span>

<span data-ttu-id="7b88d-107">MediaAsset オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="7b88d-107">The MediaAsset object has the following specification.</span></span>

| <span data-ttu-id="7b88d-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="7b88d-108">Member</span></span>| <span data-ttu-id="7b88d-109">種類</span><span class="sxs-lookup"><span data-stu-id="7b88d-109">Type</span></span>| <span data-ttu-id="7b88d-110">説明</span><span class="sxs-lookup"><span data-stu-id="7b88d-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="7b88d-111">name</span><span class="sxs-lookup"><span data-stu-id="7b88d-111">name</span></span>| <span data-ttu-id="7b88d-112">string</span><span class="sxs-lookup"><span data-stu-id="7b88d-112">string</span></span>| <span data-ttu-id="7b88d-113">"Tile01"など、MediaAsset の名前。</span><span class="sxs-lookup"><span data-stu-id="7b88d-113">The name of the MediaAsset, such as "tile01".</span></span>|
| <span data-ttu-id="7b88d-114">type</span><span class="sxs-lookup"><span data-stu-id="7b88d-114">type</span></span>| <span data-ttu-id="7b88d-115">MediaAssetType 列挙型</span><span class="sxs-lookup"><span data-stu-id="7b88d-115">MediaAssetType enumeration</span></span>| <span data-ttu-id="7b88d-116">メディア資産の種類:</span><span class="sxs-lookup"><span data-stu-id="7b88d-116">The type of the media asset:</span></span> <ul><li><span data-ttu-id="7b88d-117">アイコン (0):アチーブメントのアイコン。</span><span class="sxs-lookup"><span data-stu-id="7b88d-117">icon (0): The achievement icon.</span></span></li><li><span data-ttu-id="7b88d-118">アート (1):デジタル アート資産。</span><span class="sxs-lookup"><span data-stu-id="7b88d-118">art (1): The digital art asset.</span></span></li></ul> | 
| <span data-ttu-id="7b88d-119">url</span><span class="sxs-lookup"><span data-stu-id="7b88d-119">url</span></span>| <span data-ttu-id="7b88d-120">string</span><span class="sxs-lookup"><span data-stu-id="7b88d-120">string</span></span>| <span data-ttu-id="7b88d-121">MediaAsset の URL。</span><span class="sxs-lookup"><span data-stu-id="7b88d-121">The URL of the MediaAsset.</span></span>|

<a id="ID4EFC"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="7b88d-122">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="7b88d-122">Sample JSON syntax</span></span>


```json
{
  "name":"Icon Name",
  "type":"Icon",
  "url":"https://www.xbox.com"
}

```


<a id="ID4EOC"></a>


## <a name="see-also"></a><span data-ttu-id="7b88d-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="7b88d-123">See also</span></span>

<a id="ID4EQC"></a>


##### <a name="parent"></a><span data-ttu-id="7b88d-124">Parent</span><span class="sxs-lookup"><span data-stu-id="7b88d-124">Parent</span></span>

[<span data-ttu-id="7b88d-125">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="7b88d-125">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)
