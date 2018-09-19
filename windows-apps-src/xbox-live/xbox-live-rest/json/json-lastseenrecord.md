---
title: LastSeenRecord (JSON)
assetID: 6a93202c-801c-03c6-8386-6acd0f366780
permalink: en-us/docs/xboxlive/rest/json-lastseenrecord.html
author: KevinAsgari
description: " LastSeenRecord (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: de0ffd7c9c6c42f2a0ebf633ebcbba8a89a1b8b8
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4058767"
---
# <a name="lastseenrecord-json"></a><span data-ttu-id="c5afa-104">LastSeenRecord (JSON)</span><span class="sxs-lookup"><span data-stu-id="c5afa-104">LastSeenRecord (JSON)</span></span>
<span data-ttu-id="c5afa-105">ユーザーには、有効な DeviceRecord があるないときに利用可能なユーザーが最後システムに表示されていた場合について説明します。</span><span class="sxs-lookup"><span data-stu-id="c5afa-105">Information about when the system last saw a user, available when the user has no valid DeviceRecord.</span></span> 
<a id="ID4EN"></a>

 
## <a name="lastseenrecord"></a><span data-ttu-id="c5afa-106">LastSeenRecord</span><span class="sxs-lookup"><span data-stu-id="c5afa-106">LastSeenRecord</span></span>
 
<span data-ttu-id="c5afa-107">LastSeenRecord オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="c5afa-107">The LastSeenRecord object has the following specification.</span></span>
 
| <span data-ttu-id="c5afa-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="c5afa-108">Member</span></span>| <span data-ttu-id="c5afa-109">種類</span><span class="sxs-lookup"><span data-stu-id="c5afa-109">Type</span></span>| <span data-ttu-id="c5afa-110">説明</span><span class="sxs-lookup"><span data-stu-id="c5afa-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="c5afa-111">deviceType</span><span class="sxs-lookup"><span data-stu-id="c5afa-111">deviceType</span></span>| <span data-ttu-id="c5afa-112">string</span><span class="sxs-lookup"><span data-stu-id="c5afa-112">string</span></span>| <span data-ttu-id="c5afa-113">ユーザーが過去の存在をでしたデバイスの種類。</span><span class="sxs-lookup"><span data-stu-id="c5afa-113">The type of the device on which the user was last present.</span></span>| 
| <span data-ttu-id="c5afa-114">titleId</span><span class="sxs-lookup"><span data-stu-id="c5afa-114">titleId</span></span>| <span data-ttu-id="c5afa-115">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="c5afa-115">32-bit unsigned integer</span></span>| <span data-ttu-id="c5afa-116">ユーザーが過去の存在をでしたタイトルの識別子です。</span><span class="sxs-lookup"><span data-stu-id="c5afa-116">The identifier of the title on which the user was last present.</span></span>| 
| <span data-ttu-id="c5afa-117">titleName</span><span class="sxs-lookup"><span data-stu-id="c5afa-117">titleName</span></span>| <span data-ttu-id="c5afa-118">string</span><span class="sxs-lookup"><span data-stu-id="c5afa-118">string</span></span>| <span data-ttu-id="c5afa-119">ユーザーが過去の存在をでしたタイトルの名前です。</span><span class="sxs-lookup"><span data-stu-id="c5afa-119">The name of the title on which the user was last present.</span></span>| 
| <span data-ttu-id="c5afa-120">タイムスタンプ</span><span class="sxs-lookup"><span data-stu-id="c5afa-120">timestamp</span></span>| <span data-ttu-id="c5afa-121">DateTime</span><span class="sxs-lookup"><span data-stu-id="c5afa-121">DateTime</span></span>| <span data-ttu-id="c5afa-122">ユーザーが過去の存在を示す UTC タイムスタンプ。</span><span class="sxs-lookup"><span data-stu-id="c5afa-122">UTC timestamp indicating when the user was last present.</span></span>| 
  
<a id="ID4EHC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="c5afa-123">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="c5afa-123">Sample JSON syntax</span></span>
 

```json
{
  deviceType:W8,    
  titleId:"23452345",
  titleName:"My Awesome Game",
  timestamp:"2012-09-17T07:15:23.4930000"
}
    
```

  
<a id="ID4EQC"></a>

 
## <a name="see-also"></a><span data-ttu-id="c5afa-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="c5afa-124">See also</span></span>
 
<a id="ID4ESC"></a>

 
##### <a name="parent"></a><span data-ttu-id="c5afa-125">Parent</span><span class="sxs-lookup"><span data-stu-id="c5afa-125">Parent</span></span> 

[<span data-ttu-id="c5afa-126">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="c5afa-126">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E5C"></a>

 
##### <a name="reference"></a><span data-ttu-id="c5afa-127">リファレンス</span><span class="sxs-lookup"><span data-stu-id="c5afa-127">Reference</span></span>   