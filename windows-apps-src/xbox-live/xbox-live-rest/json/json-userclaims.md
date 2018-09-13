---
title: UserClaims (JSON)
assetID: f88d5ee0-2875-fcfb-3098-3cd6afce8748
permalink: en-us/docs/xboxlive/rest/json-userclaims.html
author: KevinAsgari
description: " UserClaims (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a5ec9878845b7d93cd4db18ff9825d728897a5c0
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3961561"
---
# <a name="userclaims-json"></a><span data-ttu-id="215b2-104">UserClaims (JSON)</span><span class="sxs-lookup"><span data-stu-id="215b2-104">UserClaims (JSON)</span></span>
<span data-ttu-id="215b2-105">現在の認証されたユーザーに関する情報を返します。</span><span class="sxs-lookup"><span data-stu-id="215b2-105">Returns information about the current authenticated user.</span></span> 
<a id="ID4EN"></a>

 
## <a name="userclaims"></a><span data-ttu-id="215b2-106">UserClaims</span><span class="sxs-lookup"><span data-stu-id="215b2-106">UserClaims</span></span>
 
<span data-ttu-id="215b2-107">UserClaims オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="215b2-107">The UserClaims object has the following specification.</span></span>
 
| <span data-ttu-id="215b2-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="215b2-108">Member</span></span>| <span data-ttu-id="215b2-109">種類</span><span class="sxs-lookup"><span data-stu-id="215b2-109">Type</span></span>| <span data-ttu-id="215b2-110">説明</span><span class="sxs-lookup"><span data-stu-id="215b2-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="215b2-111">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="215b2-111">gamertag</span></span>| <span data-ttu-id="215b2-112">string</span><span class="sxs-lookup"><span data-stu-id="215b2-112">string</span></span>| <span data-ttu-id="215b2-113">ユーザーのゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="215b2-113">gamertag of the user.</span></span>| 
| <span data-ttu-id="215b2-114">xuid</span><span class="sxs-lookup"><span data-stu-id="215b2-114">xuid</span></span>| <span data-ttu-id="215b2-115">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="215b2-115">64-bit unsigned integer</span></span>| <span data-ttu-id="215b2-116">Xbox ユーザー ID (XUID) ユーザーのします。</span><span class="sxs-lookup"><span data-stu-id="215b2-116">The Xbox User ID (XUID) of the user.</span></span>| 
  
<a id="ID4EZB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="215b2-117">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="215b2-117">Sample JSON syntax</span></span>
 

```json
{
   "xuid" : 2533274790412952,
   "gamertag" : "gamer"

}
    
```

  
<a id="ID4ECC"></a>

 
## <a name="see-also"></a><span data-ttu-id="215b2-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="215b2-118">See also</span></span>
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a><span data-ttu-id="215b2-119">Parent</span><span class="sxs-lookup"><span data-stu-id="215b2-119">Parent</span></span> 

[<span data-ttu-id="215b2-120">JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="215b2-120">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   