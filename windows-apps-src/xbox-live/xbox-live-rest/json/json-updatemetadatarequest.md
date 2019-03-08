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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57597767"
---
# <a name="updatemetadatarequest-json"></a><span data-ttu-id="f1bb4-104">UpdateMetadataRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="f1bb4-104">UpdateMetadataRequest (JSON)</span></span>
<span data-ttu-id="f1bb4-105">このメタデータは、クリップを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f1bb4-105">The metadata that should be updated for a clip.</span></span> 
<a id="ID4EN"></a>

 
## <a name="updatemetadatarequest"></a><span data-ttu-id="f1bb4-106">UpdateMetadataRequest</span><span class="sxs-lookup"><span data-stu-id="f1bb4-106">UpdateMetadataRequest</span></span>
 
<span data-ttu-id="f1bb4-107">UpdateMetadataRequest オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="f1bb4-107">The UpdateMetadataRequest object has the following specification.</span></span>
 
| <span data-ttu-id="f1bb4-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="f1bb4-108">Member</span></span>| <span data-ttu-id="f1bb4-109">種類</span><span class="sxs-lookup"><span data-stu-id="f1bb4-109">Type</span></span>| <span data-ttu-id="f1bb4-110">説明</span><span class="sxs-lookup"><span data-stu-id="f1bb4-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f1bb4-111">userCaption</span><span class="sxs-lookup"><span data-stu-id="f1bb4-111">userCaption</span></span>| <span data-ttu-id="f1bb4-112">string</span><span class="sxs-lookup"><span data-stu-id="f1bb4-112">string</span></span>| <span data-ttu-id="f1bb4-113">ゲームのクリップをユーザーが入力した非ローカライズ文字列を変更します。</span><span class="sxs-lookup"><span data-stu-id="f1bb4-113">Changes the user entered non-localized string for the game clip.</span></span>| 
| <span data-ttu-id="f1bb4-114">visibility</span><span class="sxs-lookup"><span data-stu-id="f1bb4-114">visibility</span></span>| [<span data-ttu-id="f1bb4-115">GameClipVisibility 列挙型</span><span class="sxs-lookup"><span data-stu-id="f1bb4-115">GameClipVisibility Enumeration</span></span>](../enums/gvr-enum-gameclipvisibility.md)| <span data-ttu-id="f1bb4-116">システムでパブリッシュされるゲームのクリップの可視性を変更します。</span><span class="sxs-lookup"><span data-stu-id="f1bb4-116">Changes the visibility of the game clip as it is published in the system.</span></span>| 
| <span data-ttu-id="f1bb4-117">titleData</span><span class="sxs-lookup"><span data-stu-id="f1bb4-117">titleData</span></span>| <span data-ttu-id="f1bb4-118">string</span><span class="sxs-lookup"><span data-stu-id="f1bb4-118">string</span></span>| <span data-ttu-id="f1bb4-119">タイトルに固有のプロパティ バッグ。</span><span class="sxs-lookup"><span data-stu-id="f1bb4-119">The title-specific property bag.</span></span> <span data-ttu-id="f1bb4-120">最大サイズ:10 KB。</span><span class="sxs-lookup"><span data-stu-id="f1bb4-120">Maximum size: 10 KB.</span></span>| 
  
<a id="ID4EBC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="f1bb4-121">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="f1bb4-121">Sample JSON syntax</span></span>
 
<span data-ttu-id="f1bb4-122">ユーザーのクリップの名前を変更して、可視性:</span><span class="sxs-lookup"><span data-stu-id="f1bb4-122">Changing User Clip Name and Visibility:</span></span>
 

```json
{
  "userCaption": "I've changed this 100 Times!",
  "visibility": "Owner"
}

```

 
<span data-ttu-id="f1bb4-123">(これはほんの一例であるため、このフィールドのスキーマは、呼び出し元) のタイトルのプロパティだけを変更するには。</span><span class="sxs-lookup"><span data-stu-id="f1bb4-123">Changing just title properties (this is just an example, since the schema of this field is up to the caller):</span></span>
 

```json
{
  "titleData": "{ 'Id': '123456', 'Location': 'C:\\videos\\123456.mp4' }"
}

```

  
<a id="ID4EQC"></a>

 
## <a name="see-also"></a><span data-ttu-id="f1bb4-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="f1bb4-124">See also</span></span>
 
<a id="ID4ESC"></a>

 
##### <a name="parent"></a><span data-ttu-id="f1bb4-125">Parent</span><span class="sxs-lookup"><span data-stu-id="f1bb4-125">Parent</span></span> 

[<span data-ttu-id="f1bb4-126">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="f1bb4-126">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E3C"></a>

 
##### <a name="reference"></a><span data-ttu-id="f1bb4-127">リファレンス</span><span class="sxs-lookup"><span data-stu-id="f1bb4-127">Reference</span></span> 

[<span data-ttu-id="f1bb4-128">POST (/users/me/scids/{scid}/clips/{gameClipId})</span><span class="sxs-lookup"><span data-stu-id="f1bb4-128">POST (/users/me/scids/{scid}/clips/{gameClipId})</span></span>](../uri/dvr/uri-usersmescidclipsgameclipidpost.md)

   