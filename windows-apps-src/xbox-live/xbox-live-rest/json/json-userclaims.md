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
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8334385"
---
# <a name="userclaims-json"></a><span data-ttu-id="caea9-104">UserClaims (JSON)</span><span class="sxs-lookup"><span data-stu-id="caea9-104">UserClaims (JSON)</span></span>
<span data-ttu-id="caea9-105">現在の認証されたユーザーに関する情報を返します。</span><span class="sxs-lookup"><span data-stu-id="caea9-105">Returns information about the current authenticated user.</span></span> 
<a id="ID4EN"></a>

 
## <a name="userclaims"></a><span data-ttu-id="caea9-106">UserClaims</span><span class="sxs-lookup"><span data-stu-id="caea9-106">UserClaims</span></span>
 
<span data-ttu-id="caea9-107">UserClaims オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="caea9-107">The UserClaims object has the following specification.</span></span>
 
| <span data-ttu-id="caea9-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="caea9-108">Member</span></span>| <span data-ttu-id="caea9-109">種類</span><span class="sxs-lookup"><span data-stu-id="caea9-109">Type</span></span>| <span data-ttu-id="caea9-110">説明</span><span class="sxs-lookup"><span data-stu-id="caea9-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="caea9-111">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="caea9-111">gamertag</span></span>| <span data-ttu-id="caea9-112">string</span><span class="sxs-lookup"><span data-stu-id="caea9-112">string</span></span>| <span data-ttu-id="caea9-113">ユーザーのゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="caea9-113">gamertag of the user.</span></span>| 
| <span data-ttu-id="caea9-114">xuid</span><span class="sxs-lookup"><span data-stu-id="caea9-114">xuid</span></span>| <span data-ttu-id="caea9-115">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="caea9-115">64-bit unsigned integer</span></span>| <span data-ttu-id="caea9-116">Xbox ユーザー ID (XUID) ユーザーのします。</span><span class="sxs-lookup"><span data-stu-id="caea9-116">The Xbox User ID (XUID) of the user.</span></span>| 
  
<a id="ID4EZB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="caea9-117">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="caea9-117">Sample JSON syntax</span></span>
 

```json
{
   "xuid" : 2533274790412952,
   "gamertag" : "gamer"

}
    
```

  
<a id="ID4ECC"></a>

 
## <a name="see-also"></a><span data-ttu-id="caea9-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="caea9-118">See also</span></span>
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a><span data-ttu-id="caea9-119">Parent</span><span class="sxs-lookup"><span data-stu-id="caea9-119">Parent</span></span> 

[<span data-ttu-id="caea9-120">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="caea9-120">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   