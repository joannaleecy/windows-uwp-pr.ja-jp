---
title: LastSeenRecord (JSON)
assetID: 6a93202c-801c-03c6-8386-6acd0f366780
permalink: en-us/docs/xboxlive/rest/json-lastseenrecord.html
description: " LastSeenRecord (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e06de31cabaedb68ed57d3d4f2ff30614ceb6317
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613377"
---
# <a name="lastseenrecord-json"></a><span data-ttu-id="5f5c4-104">LastSeenRecord (JSON)</span><span class="sxs-lookup"><span data-stu-id="5f5c4-104">LastSeenRecord (JSON)</span></span>
<span data-ttu-id="5f5c4-105">システムが最終ユーザー、ユーザーが有効な DeviceRecord を持たないときに使用できるを見た場合について説明します。</span><span class="sxs-lookup"><span data-stu-id="5f5c4-105">Information about when the system last saw a user, available when the user has no valid DeviceRecord.</span></span> 
<a id="ID4EN"></a>

 
## <a name="lastseenrecord"></a><span data-ttu-id="5f5c4-106">LastSeenRecord</span><span class="sxs-lookup"><span data-stu-id="5f5c4-106">LastSeenRecord</span></span>
 
<span data-ttu-id="5f5c4-107">LastSeenRecord オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="5f5c4-107">The LastSeenRecord object has the following specification.</span></span>
 
| <span data-ttu-id="5f5c4-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="5f5c4-108">Member</span></span>| <span data-ttu-id="5f5c4-109">種類</span><span class="sxs-lookup"><span data-stu-id="5f5c4-109">Type</span></span>| <span data-ttu-id="5f5c4-110">説明</span><span class="sxs-lookup"><span data-stu-id="5f5c4-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="5f5c4-111">deviceType</span><span class="sxs-lookup"><span data-stu-id="5f5c4-111">deviceType</span></span>| <span data-ttu-id="5f5c4-112">string</span><span class="sxs-lookup"><span data-stu-id="5f5c4-112">string</span></span>| <span data-ttu-id="5f5c4-113">ユーザーが最後にあるデバイスの種類。</span><span class="sxs-lookup"><span data-stu-id="5f5c4-113">The type of the device on which the user was last present.</span></span>| 
| <span data-ttu-id="5f5c4-114">titleId</span><span class="sxs-lookup"><span data-stu-id="5f5c4-114">titleId</span></span>| <span data-ttu-id="5f5c4-115">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="5f5c4-115">32-bit unsigned integer</span></span>| <span data-ttu-id="5f5c4-116">ユーザーが最後の現在のタイトルの識別子です。</span><span class="sxs-lookup"><span data-stu-id="5f5c4-116">The identifier of the title on which the user was last present.</span></span>| 
| <span data-ttu-id="5f5c4-117">titleName</span><span class="sxs-lookup"><span data-stu-id="5f5c4-117">titleName</span></span>| <span data-ttu-id="5f5c4-118">string</span><span class="sxs-lookup"><span data-stu-id="5f5c4-118">string</span></span>| <span data-ttu-id="5f5c4-119">ユーザーが最後の現在のタイトルの名前。</span><span class="sxs-lookup"><span data-stu-id="5f5c4-119">The name of the title on which the user was last present.</span></span>| 
| <span data-ttu-id="5f5c4-120">タイムスタンプ</span><span class="sxs-lookup"><span data-stu-id="5f5c4-120">timestamp</span></span>| <span data-ttu-id="5f5c4-121">DateTime</span><span class="sxs-lookup"><span data-stu-id="5f5c4-121">DateTime</span></span>| <span data-ttu-id="5f5c4-122">ユーザーが最後の存在を示す UTC タイムスタンプ。</span><span class="sxs-lookup"><span data-stu-id="5f5c4-122">UTC timestamp indicating when the user was last present.</span></span>| 
  
<a id="ID4EHC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="5f5c4-123">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="5f5c4-123">Sample JSON syntax</span></span>
 

```json
{
  deviceType:W8,    
  titleId:"23452345",
  titleName:"My Awesome Game",
  timestamp:"2012-09-17T07:15:23.4930000"
}
    
```

  
<a id="ID4EQC"></a>

 
## <a name="see-also"></a><span data-ttu-id="5f5c4-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="5f5c4-124">See also</span></span>
 
<a id="ID4ESC"></a>

 
##### <a name="parent"></a><span data-ttu-id="5f5c4-125">Parent</span><span class="sxs-lookup"><span data-stu-id="5f5c4-125">Parent</span></span> 

[<span data-ttu-id="5f5c4-126">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="5f5c4-126">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E5C"></a>

 
##### <a name="reference"></a><span data-ttu-id="5f5c4-127">リファレンス</span><span class="sxs-lookup"><span data-stu-id="5f5c4-127">Reference</span></span>   