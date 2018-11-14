---
title: LastSeenRecord (JSON)
assetID: 6a93202c-801c-03c6-8386-6acd0f366780
permalink: en-us/docs/xboxlive/rest/json-lastseenrecord.html
author: KevinAsgari
description: " LastSeenRecord (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8d4889ced5f8942c080b3336bda8c0d8d9b25af2
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6180637"
---
# <a name="lastseenrecord-json"></a><span data-ttu-id="80abf-104">LastSeenRecord (JSON)</span><span class="sxs-lookup"><span data-stu-id="80abf-104">LastSeenRecord (JSON)</span></span>
<span data-ttu-id="80abf-105">利用できるは、ユーザーには、有効な DeviceRecord があるないと、ユーザーが最後、システムに表示されていた場合について説明します。</span><span class="sxs-lookup"><span data-stu-id="80abf-105">Information about when the system last saw a user, available when the user has no valid DeviceRecord.</span></span> 
<a id="ID4EN"></a>

 
## <a name="lastseenrecord"></a><span data-ttu-id="80abf-106">LastSeenRecord</span><span class="sxs-lookup"><span data-stu-id="80abf-106">LastSeenRecord</span></span>
 
<span data-ttu-id="80abf-107">LastSeenRecord オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="80abf-107">The LastSeenRecord object has the following specification.</span></span>
 
| <span data-ttu-id="80abf-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="80abf-108">Member</span></span>| <span data-ttu-id="80abf-109">種類</span><span class="sxs-lookup"><span data-stu-id="80abf-109">Type</span></span>| <span data-ttu-id="80abf-110">説明</span><span class="sxs-lookup"><span data-stu-id="80abf-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="80abf-111">deviceType</span><span class="sxs-lookup"><span data-stu-id="80abf-111">deviceType</span></span>| <span data-ttu-id="80abf-112">string</span><span class="sxs-lookup"><span data-stu-id="80abf-112">string</span></span>| <span data-ttu-id="80abf-113">ユーザーが最後の存在をでしたデバイスの種類。</span><span class="sxs-lookup"><span data-stu-id="80abf-113">The type of the device on which the user was last present.</span></span>| 
| <span data-ttu-id="80abf-114">titleId</span><span class="sxs-lookup"><span data-stu-id="80abf-114">titleId</span></span>| <span data-ttu-id="80abf-115">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="80abf-115">32-bit unsigned integer</span></span>| <span data-ttu-id="80abf-116">ユーザーが最後の存在をでしたタイトルの識別子。</span><span class="sxs-lookup"><span data-stu-id="80abf-116">The identifier of the title on which the user was last present.</span></span>| 
| <span data-ttu-id="80abf-117">titleName</span><span class="sxs-lookup"><span data-stu-id="80abf-117">titleName</span></span>| <span data-ttu-id="80abf-118">string</span><span class="sxs-lookup"><span data-stu-id="80abf-118">string</span></span>| <span data-ttu-id="80abf-119">ユーザーが最後の存在をでしたタイトルの名前です。</span><span class="sxs-lookup"><span data-stu-id="80abf-119">The name of the title on which the user was last present.</span></span>| 
| <span data-ttu-id="80abf-120">タイムスタンプ</span><span class="sxs-lookup"><span data-stu-id="80abf-120">timestamp</span></span>| <span data-ttu-id="80abf-121">DateTime</span><span class="sxs-lookup"><span data-stu-id="80abf-121">DateTime</span></span>| <span data-ttu-id="80abf-122">Utc 形式のユーザーが過去の存在を示すタイムスタンプ。</span><span class="sxs-lookup"><span data-stu-id="80abf-122">UTC timestamp indicating when the user was last present.</span></span>| 
  
<a id="ID4EHC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="80abf-123">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="80abf-123">Sample JSON syntax</span></span>
 

```json
{
  deviceType:W8,    
  titleId:"23452345",
  titleName:"My Awesome Game",
  timestamp:"2012-09-17T07:15:23.4930000"
}
    
```

  
<a id="ID4EQC"></a>

 
## <a name="see-also"></a><span data-ttu-id="80abf-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="80abf-124">See also</span></span>
 
<a id="ID4ESC"></a>

 
##### <a name="parent"></a><span data-ttu-id="80abf-125">Parent</span><span class="sxs-lookup"><span data-stu-id="80abf-125">Parent</span></span> 

[<span data-ttu-id="80abf-126">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="80abf-126">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E5C"></a>

 
##### <a name="reference"></a><span data-ttu-id="80abf-127">リファレンス</span><span class="sxs-lookup"><span data-stu-id="80abf-127">Reference</span></span>   