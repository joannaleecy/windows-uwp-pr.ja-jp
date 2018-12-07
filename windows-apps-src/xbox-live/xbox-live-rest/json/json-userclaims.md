---
title: UserClaims (JSON)
assetID: f88d5ee0-2875-fcfb-3098-3cd6afce8748
permalink: en-us/docs/xboxlive/rest/json-userclaims.html
description: " UserClaims (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 21b4322d002747145c3b09e0f3cd7eb03874380b
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8798089"
---
# <a name="userclaims-json"></a><span data-ttu-id="d5b11-104">UserClaims (JSON)</span><span class="sxs-lookup"><span data-stu-id="d5b11-104">UserClaims (JSON)</span></span>
<span data-ttu-id="d5b11-105">現在の認証されたユーザーに関する情報を返します。</span><span class="sxs-lookup"><span data-stu-id="d5b11-105">Returns information about the current authenticated user.</span></span> 
<a id="ID4EN"></a>

 
## <a name="userclaims"></a><span data-ttu-id="d5b11-106">UserClaims</span><span class="sxs-lookup"><span data-stu-id="d5b11-106">UserClaims</span></span>
 
<span data-ttu-id="d5b11-107">UserClaims オブジェクトには、次仕様があります。</span><span class="sxs-lookup"><span data-stu-id="d5b11-107">The UserClaims object has the following specification.</span></span>
 
| <span data-ttu-id="d5b11-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="d5b11-108">Member</span></span>| <span data-ttu-id="d5b11-109">種類</span><span class="sxs-lookup"><span data-stu-id="d5b11-109">Type</span></span>| <span data-ttu-id="d5b11-110">説明</span><span class="sxs-lookup"><span data-stu-id="d5b11-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d5b11-111">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="d5b11-111">gamertag</span></span>| <span data-ttu-id="d5b11-112">string</span><span class="sxs-lookup"><span data-stu-id="d5b11-112">string</span></span>| <span data-ttu-id="d5b11-113">ユーザーのゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="d5b11-113">gamertag of the user.</span></span>| 
| <span data-ttu-id="d5b11-114">xuid</span><span class="sxs-lookup"><span data-stu-id="d5b11-114">xuid</span></span>| <span data-ttu-id="d5b11-115">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="d5b11-115">64-bit unsigned integer</span></span>| <span data-ttu-id="d5b11-116">Xbox ユーザー ID (XUID) ユーザーのします。</span><span class="sxs-lookup"><span data-stu-id="d5b11-116">The Xbox User ID (XUID) of the user.</span></span>| 
  
<a id="ID4EZB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="d5b11-117">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="d5b11-117">Sample JSON syntax</span></span>
 

```json
{
   "xuid" : 2533274790412952,
   "gamertag" : "gamer"

}
    
```

  
<a id="ID4ECC"></a>

 
## <a name="see-also"></a><span data-ttu-id="d5b11-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="d5b11-118">See also</span></span>
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a><span data-ttu-id="d5b11-119">Parent</span><span class="sxs-lookup"><span data-stu-id="d5b11-119">Parent</span></span> 

[<span data-ttu-id="d5b11-120">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="d5b11-120">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   