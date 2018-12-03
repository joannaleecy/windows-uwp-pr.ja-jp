---
title: UpdateMetadataRequest (JSON)
assetID: 0bc210e3-c1dc-9267-e322-aadb9f0a074a
permalink: en-us/docs/xboxlive/rest/json-updatemetadatarequest.html
description: " UpdateMetadataRequest (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a76e4b12e0ffadb112913775b500ac0d39d413d5
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8337475"
---
# <a name="updatemetadatarequest-json"></a><span data-ttu-id="44b6f-104">UpdateMetadataRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="44b6f-104">UpdateMetadataRequest (JSON)</span></span>
<span data-ttu-id="44b6f-105">このメタデータは、クリップを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="44b6f-105">The metadata that should be updated for a clip.</span></span> 
<a id="ID4EN"></a>

 
## <a name="updatemetadatarequest"></a><span data-ttu-id="44b6f-106">UpdateMetadataRequest</span><span class="sxs-lookup"><span data-stu-id="44b6f-106">UpdateMetadataRequest</span></span>
 
<span data-ttu-id="44b6f-107">UpdateMetadataRequest オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="44b6f-107">The UpdateMetadataRequest object has the following specification.</span></span>
 
| <span data-ttu-id="44b6f-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="44b6f-108">Member</span></span>| <span data-ttu-id="44b6f-109">種類</span><span class="sxs-lookup"><span data-stu-id="44b6f-109">Type</span></span>| <span data-ttu-id="44b6f-110">説明</span><span class="sxs-lookup"><span data-stu-id="44b6f-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="44b6f-111">userCaption</span><span class="sxs-lookup"><span data-stu-id="44b6f-111">userCaption</span></span>| <span data-ttu-id="44b6f-112">string</span><span class="sxs-lookup"><span data-stu-id="44b6f-112">string</span></span>| <span data-ttu-id="44b6f-113">ゲーム クリップのユーザーが入力した以外にローカライズされた文字列を変更します。</span><span class="sxs-lookup"><span data-stu-id="44b6f-113">Changes the user entered non-localized string for the game clip.</span></span>| 
| <span data-ttu-id="44b6f-114">visibility</span><span class="sxs-lookup"><span data-stu-id="44b6f-114">visibility</span></span>| [<span data-ttu-id="44b6f-115">GameClipVisibility 列挙型</span><span class="sxs-lookup"><span data-stu-id="44b6f-115">GameClipVisibility Enumeration</span></span>](../enums/gvr-enum-gameclipvisibility.md)| <span data-ttu-id="44b6f-116">これは、システムで公開されるゲーム クリップの可視性を変更します。</span><span class="sxs-lookup"><span data-stu-id="44b6f-116">Changes the visibility of the game clip as it is published in the system.</span></span>| 
| <span data-ttu-id="44b6f-117">titleData</span><span class="sxs-lookup"><span data-stu-id="44b6f-117">titleData</span></span>| <span data-ttu-id="44b6f-118">string</span><span class="sxs-lookup"><span data-stu-id="44b6f-118">string</span></span>| <span data-ttu-id="44b6f-119">タイトルに固有のプロパティ バッグです。</span><span class="sxs-lookup"><span data-stu-id="44b6f-119">The title-specific property bag.</span></span> <span data-ttu-id="44b6f-120">最大サイズ: 10 kb です。</span><span class="sxs-lookup"><span data-stu-id="44b6f-120">Maximum size: 10 KB.</span></span>| 
  
<a id="ID4EBC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="44b6f-121">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="44b6f-121">Sample JSON syntax</span></span>
 
<span data-ttu-id="44b6f-122">ユーザーのクリップの名前を変更して表示します。</span><span class="sxs-lookup"><span data-stu-id="44b6f-122">Changing User Clip Name and Visibility:</span></span>
 

```json
{
  "userCaption": "I've changed this 100 Times!",
  "visibility": "Owner"
}

```

 
<span data-ttu-id="44b6f-123">タイトルのプロパティ (これは単なる例、このフィールドのスキーマは、呼び出し元であるため) だけを変更するには。</span><span class="sxs-lookup"><span data-stu-id="44b6f-123">Changing just title properties (this is just an example, since the schema of this field is up to the caller):</span></span>
 

```json
{
  "titleData": "{ 'Id': '123456', 'Location': 'C:\\videos\\123456.mp4' }"
}

```

  
<a id="ID4EQC"></a>

 
## <a name="see-also"></a><span data-ttu-id="44b6f-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="44b6f-124">See also</span></span>
 
<a id="ID4ESC"></a>

 
##### <a name="parent"></a><span data-ttu-id="44b6f-125">Parent</span><span class="sxs-lookup"><span data-stu-id="44b6f-125">Parent</span></span> 

[<span data-ttu-id="44b6f-126">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="44b6f-126">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E3C"></a>

 
##### <a name="reference"></a><span data-ttu-id="44b6f-127">リファレンス</span><span class="sxs-lookup"><span data-stu-id="44b6f-127">Reference</span></span> 

[<span data-ttu-id="44b6f-128">POST (/users/me/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="44b6f-128">POST (/users/me/scids/{scid}/clips/{gameClipId})</span></span>](../uri/dvr/uri-usersmescidclipsgameclipidpost.md)

   