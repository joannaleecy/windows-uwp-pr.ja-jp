---
title: UpdateMetadataRequest (JSON)
assetID: 0bc210e3-c1dc-9267-e322-aadb9f0a074a
permalink: en-us/docs/xboxlive/rest/json-updatemetadatarequest.html
author: KevinAsgari
description: " UpdateMetadataRequest (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 72b4a7b971647304e08fe52e7696be9fcd39e584
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3931468"
---
# <a name="updatemetadatarequest-json"></a><span data-ttu-id="c79fa-104">UpdateMetadataRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="c79fa-104">UpdateMetadataRequest (JSON)</span></span>
<span data-ttu-id="c79fa-105">このメタデータは、クリップを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c79fa-105">The metadata that should be updated for a clip.</span></span> 
<a id="ID4EN"></a>

 
## <a name="updatemetadatarequest"></a><span data-ttu-id="c79fa-106">UpdateMetadataRequest</span><span class="sxs-lookup"><span data-stu-id="c79fa-106">UpdateMetadataRequest</span></span>
 
<span data-ttu-id="c79fa-107">UpdateMetadataRequest オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="c79fa-107">The UpdateMetadataRequest object has the following specification.</span></span>
 
| <span data-ttu-id="c79fa-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="c79fa-108">Member</span></span>| <span data-ttu-id="c79fa-109">種類</span><span class="sxs-lookup"><span data-stu-id="c79fa-109">Type</span></span>| <span data-ttu-id="c79fa-110">説明</span><span class="sxs-lookup"><span data-stu-id="c79fa-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="c79fa-111">userCaption</span><span class="sxs-lookup"><span data-stu-id="c79fa-111">userCaption</span></span>| <span data-ttu-id="c79fa-112">string</span><span class="sxs-lookup"><span data-stu-id="c79fa-112">string</span></span>| <span data-ttu-id="c79fa-113">ゲーム クリップのユーザーが入力した以外にローカライズされた文字列を変更します。</span><span class="sxs-lookup"><span data-stu-id="c79fa-113">Changes the user entered non-localized string for the game clip.</span></span>| 
| <span data-ttu-id="c79fa-114">visibility</span><span class="sxs-lookup"><span data-stu-id="c79fa-114">visibility</span></span>| [<span data-ttu-id="c79fa-115">GameClipVisibility 列挙</span><span class="sxs-lookup"><span data-stu-id="c79fa-115">GameClipVisibility Enumeration</span></span>](../enums/gvr-enum-gameclipvisibility.md)| <span data-ttu-id="c79fa-116">これは、システムで公開されるゲーム クリップの可視性を変更します。</span><span class="sxs-lookup"><span data-stu-id="c79fa-116">Changes the visibility of the game clip as it is published in the system.</span></span>| 
| <span data-ttu-id="c79fa-117">titleData</span><span class="sxs-lookup"><span data-stu-id="c79fa-117">titleData</span></span>| <span data-ttu-id="c79fa-118">string</span><span class="sxs-lookup"><span data-stu-id="c79fa-118">string</span></span>| <span data-ttu-id="c79fa-119">タイトルに固有のプロパティ バッグです。</span><span class="sxs-lookup"><span data-stu-id="c79fa-119">The title-specific property bag.</span></span> <span data-ttu-id="c79fa-120">最大サイズ: 10 kb です。</span><span class="sxs-lookup"><span data-stu-id="c79fa-120">Maximum size: 10 KB.</span></span>| 
  
<a id="ID4EBC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="c79fa-121">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="c79fa-121">Sample JSON syntax</span></span>
 
<span data-ttu-id="c79fa-122">ユーザーのクリップの名前を変更して表示します。</span><span class="sxs-lookup"><span data-stu-id="c79fa-122">Changing User Clip Name and Visibility:</span></span>
 

```json
{
  "userCaption": "I've changed this 100 Times!",
  "visibility": "Owner"
}

```

 
<span data-ttu-id="c79fa-123">タイトルのプロパティ (これは単なる例、このフィールドのスキーマは、呼び出し元であるため) だけを変更するには。</span><span class="sxs-lookup"><span data-stu-id="c79fa-123">Changing just title properties (this is just an example, since the schema of this field is up to the caller):</span></span>
 

```json
{
  "titleData": "{ 'Id': '123456', 'Location': 'C:\\videos\\123456.mp4' }"
}

```

  
<a id="ID4EQC"></a>

 
## <a name="see-also"></a><span data-ttu-id="c79fa-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="c79fa-124">See also</span></span>
 
<a id="ID4ESC"></a>

 
##### <a name="parent"></a><span data-ttu-id="c79fa-125">Parent</span><span class="sxs-lookup"><span data-stu-id="c79fa-125">Parent</span></span> 

[<span data-ttu-id="c79fa-126">JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="c79fa-126">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E3C"></a>

 
##### <a name="reference"></a><span data-ttu-id="c79fa-127">リファレンス</span><span class="sxs-lookup"><span data-stu-id="c79fa-127">Reference</span></span> 

[<span data-ttu-id="c79fa-128">POST (ユーザー/me/clips//global/scids/{scid} {gameClipId})</span><span class="sxs-lookup"><span data-stu-id="c79fa-128">POST (/users/me/scids/{scid}/clips/{gameClipId})</span></span>](../uri/dvr/uri-usersmescidclipsgameclipidpost.md)

   