---
title: MediaAsset (JSON)
assetID: 858c720a-1648-738b-bb43-f050e7cac19e
permalink: en-us/docs/xboxlive/rest/json-mediaasset.html
description: " MediaAsset (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 42a2a6e62494bd8fd5872e7664da8ac71cccbf57
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8778970"
---
# <a name="mediaasset-json"></a><span data-ttu-id="9f0a6-104">MediaAsset (JSON)</span><span class="sxs-lookup"><span data-stu-id="9f0a6-104">MediaAsset (JSON)</span></span>
<span data-ttu-id="9f0a6-105">実績やそのリワードに関連付けられているメディア アセット。</span><span class="sxs-lookup"><span data-stu-id="9f0a6-105">The media assets associated with the achievement or its rewards.</span></span>
<a id="ID4EN"></a>


## <a name="mediaasset"></a><span data-ttu-id="9f0a6-106">MediaAsset</span><span class="sxs-lookup"><span data-stu-id="9f0a6-106">MediaAsset</span></span>

<span data-ttu-id="9f0a6-107">MediaAsset オブジェクトには、次仕様があります。</span><span class="sxs-lookup"><span data-stu-id="9f0a6-107">The MediaAsset object has the following specification.</span></span>

| <span data-ttu-id="9f0a6-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="9f0a6-108">Member</span></span>| <span data-ttu-id="9f0a6-109">種類</span><span class="sxs-lookup"><span data-stu-id="9f0a6-109">Type</span></span>| <span data-ttu-id="9f0a6-110">説明</span><span class="sxs-lookup"><span data-stu-id="9f0a6-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="9f0a6-111">name</span><span class="sxs-lookup"><span data-stu-id="9f0a6-111">name</span></span>| <span data-ttu-id="9f0a6-112">string</span><span class="sxs-lookup"><span data-stu-id="9f0a6-112">string</span></span>| <span data-ttu-id="9f0a6-113">"Tile01"など、MediaAsset の名前です。</span><span class="sxs-lookup"><span data-stu-id="9f0a6-113">The name of the MediaAsset, such as "tile01".</span></span>|
| <span data-ttu-id="9f0a6-114">type</span><span class="sxs-lookup"><span data-stu-id="9f0a6-114">type</span></span>| <span data-ttu-id="9f0a6-115">MediaAssetType 列挙型</span><span class="sxs-lookup"><span data-stu-id="9f0a6-115">MediaAssetType enumeration</span></span>| <span data-ttu-id="9f0a6-116">メディア アセットの種類。</span><span class="sxs-lookup"><span data-stu-id="9f0a6-116">The type of the media asset:</span></span> <ul><li><span data-ttu-id="9f0a6-117">アイコン (0): 実績アイコンです。</span><span class="sxs-lookup"><span data-stu-id="9f0a6-117">icon (0): The achievement icon.</span></span></li><li><span data-ttu-id="9f0a6-118">アート (1): デジタル アート アセット。</span><span class="sxs-lookup"><span data-stu-id="9f0a6-118">art (1): The digital art asset.</span></span></li></ul> | 
| <span data-ttu-id="9f0a6-119">url</span><span class="sxs-lookup"><span data-stu-id="9f0a6-119">url</span></span>| <span data-ttu-id="9f0a6-120">string</span><span class="sxs-lookup"><span data-stu-id="9f0a6-120">string</span></span>| <span data-ttu-id="9f0a6-121">MediaAsset の URL。</span><span class="sxs-lookup"><span data-stu-id="9f0a6-121">The URL of the MediaAsset.</span></span>|

<a id="ID4EFC"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="9f0a6-122">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="9f0a6-122">Sample JSON syntax</span></span>


```json
{
  "name":"Icon Name",
  "type":"Icon",
  "url":"http://www.xbox.com"
}

```


<a id="ID4EOC"></a>


## <a name="see-also"></a><span data-ttu-id="9f0a6-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="9f0a6-123">See also</span></span>

<a id="ID4EQC"></a>


##### <a name="parent"></a><span data-ttu-id="9f0a6-124">Parent</span><span class="sxs-lookup"><span data-stu-id="9f0a6-124">Parent</span></span>

[<span data-ttu-id="9f0a6-125">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="9f0a6-125">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)
