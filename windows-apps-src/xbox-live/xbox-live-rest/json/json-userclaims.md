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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623347"
---
# <a name="userclaims-json"></a><span data-ttu-id="5e641-104">UserClaims (JSON)</span><span class="sxs-lookup"><span data-stu-id="5e641-104">UserClaims (JSON)</span></span>
<span data-ttu-id="5e641-105">現在の認証済みユーザーに関する情報を返します。</span><span class="sxs-lookup"><span data-stu-id="5e641-105">Returns information about the current authenticated user.</span></span> 
<a id="ID4EN"></a>

 
## <a name="userclaims"></a><span data-ttu-id="5e641-106">UserClaims</span><span class="sxs-lookup"><span data-stu-id="5e641-106">UserClaims</span></span>
 
<span data-ttu-id="5e641-107">UserClaims オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="5e641-107">The UserClaims object has the following specification.</span></span>
 
| <span data-ttu-id="5e641-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="5e641-108">Member</span></span>| <span data-ttu-id="5e641-109">種類</span><span class="sxs-lookup"><span data-stu-id="5e641-109">Type</span></span>| <span data-ttu-id="5e641-110">説明</span><span class="sxs-lookup"><span data-stu-id="5e641-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="5e641-111">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="5e641-111">gamertag</span></span>| <span data-ttu-id="5e641-112">string</span><span class="sxs-lookup"><span data-stu-id="5e641-112">string</span></span>| <span data-ttu-id="5e641-113">ユーザーのゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="5e641-113">gamertag of the user.</span></span>| 
| <span data-ttu-id="5e641-114">xuid</span><span class="sxs-lookup"><span data-stu-id="5e641-114">xuid</span></span>| <span data-ttu-id="5e641-115">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="5e641-115">64-bit unsigned integer</span></span>| <span data-ttu-id="5e641-116">Xbox ユーザー ID (XUID) のユーザー。</span><span class="sxs-lookup"><span data-stu-id="5e641-116">The Xbox User ID (XUID) of the user.</span></span>| 
  
<a id="ID4EZB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="5e641-117">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="5e641-117">Sample JSON syntax</span></span>
 

```json
{
   "xuid" : 2533274790412952,
   "gamertag" : "gamer"

}
    
```

  
<a id="ID4ECC"></a>

 
## <a name="see-also"></a><span data-ttu-id="5e641-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="5e641-118">See also</span></span>
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a><span data-ttu-id="5e641-119">Parent</span><span class="sxs-lookup"><span data-stu-id="5e641-119">Parent</span></span> 

[<span data-ttu-id="5e641-120">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="5e641-120">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   