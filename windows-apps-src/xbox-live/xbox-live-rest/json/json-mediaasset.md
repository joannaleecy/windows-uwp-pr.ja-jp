---
title: MediaAsset (JSON)
assetID: 858c720a-1648-738b-bb43-f050e7cac19e
permalink: en-us/docs/xboxlive/rest/json-mediaasset.html
author: KevinAsgari
description: " MediaAsset (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b50cb58f6c6262d653e90e1e6ca9666cecadf680
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5975198"
---
# <a name="mediaasset-json"></a><span data-ttu-id="6e558-104">MediaAsset (JSON)</span><span class="sxs-lookup"><span data-stu-id="6e558-104">MediaAsset (JSON)</span></span>
<span data-ttu-id="6e558-105">実績やそのリワードに関連付けられているメディア アセット。</span><span class="sxs-lookup"><span data-stu-id="6e558-105">The media assets associated with the achievement or its rewards.</span></span>
<a id="ID4EN"></a>


## <a name="mediaasset"></a><span data-ttu-id="6e558-106">MediaAsset</span><span class="sxs-lookup"><span data-stu-id="6e558-106">MediaAsset</span></span>

<span data-ttu-id="6e558-107">MediaAsset オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="6e558-107">The MediaAsset object has the following specification.</span></span>

| <span data-ttu-id="6e558-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="6e558-108">Member</span></span>| <span data-ttu-id="6e558-109">種類</span><span class="sxs-lookup"><span data-stu-id="6e558-109">Type</span></span>| <span data-ttu-id="6e558-110">説明</span><span class="sxs-lookup"><span data-stu-id="6e558-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="6e558-111">name</span><span class="sxs-lookup"><span data-stu-id="6e558-111">name</span></span>| <span data-ttu-id="6e558-112">string</span><span class="sxs-lookup"><span data-stu-id="6e558-112">string</span></span>| <span data-ttu-id="6e558-113">"Tile01"など、MediaAsset の名前。</span><span class="sxs-lookup"><span data-stu-id="6e558-113">The name of the MediaAsset, such as "tile01".</span></span>|
| <span data-ttu-id="6e558-114">type</span><span class="sxs-lookup"><span data-stu-id="6e558-114">type</span></span>| <span data-ttu-id="6e558-115">MediaAssetType 列挙型</span><span class="sxs-lookup"><span data-stu-id="6e558-115">MediaAssetType enumeration</span></span>| <span data-ttu-id="6e558-116">メディア アセットの種類。</span><span class="sxs-lookup"><span data-stu-id="6e558-116">The type of the media asset:</span></span> <ul><li><span data-ttu-id="6e558-117">アイコン (0): 実績アイコンです。</span><span class="sxs-lookup"><span data-stu-id="6e558-117">icon (0): The achievement icon.</span></span></li><li><span data-ttu-id="6e558-118">アート (1): デジタル アート アセット。</span><span class="sxs-lookup"><span data-stu-id="6e558-118">art (1): The digital art asset.</span></span></li></ul> | 
| <span data-ttu-id="6e558-119">url</span><span class="sxs-lookup"><span data-stu-id="6e558-119">url</span></span>| <span data-ttu-id="6e558-120">string</span><span class="sxs-lookup"><span data-stu-id="6e558-120">string</span></span>| <span data-ttu-id="6e558-121">MediaAsset の URL。</span><span class="sxs-lookup"><span data-stu-id="6e558-121">The URL of the MediaAsset.</span></span>|

<a id="ID4EFC"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="6e558-122">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="6e558-122">Sample JSON syntax</span></span>


```json
{
  "name":"Icon Name",
  "type":"Icon",
  "url":"http://www.xbox.com"
}

```


<a id="ID4EOC"></a>


## <a name="see-also"></a><span data-ttu-id="6e558-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="6e558-123">See also</span></span>

<a id="ID4EQC"></a>


##### <a name="parent"></a><span data-ttu-id="6e558-124">Parent</span><span class="sxs-lookup"><span data-stu-id="6e558-124">Parent</span></span>

[<span data-ttu-id="6e558-125">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="6e558-125">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)
