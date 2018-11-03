---
title: PermissionCheckBatchRequest (JSON)
assetID: 3100b17c-1b60-fdf2-3af9-7e424f1903ee
permalink: en-us/docs/xboxlive/rest/json-permissioncheckbatchrequest.html
author: KevinAsgari
description: " PermissionCheckBatchRequest (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d781f472dc9179f25002d3e103af2cedf3ebd931
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5991409"
---
# <a name="permissioncheckbatchrequest-json"></a><span data-ttu-id="0735f-104">PermissionCheckBatchRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="0735f-104">PermissionCheckBatchRequest (JSON)</span></span>
<span data-ttu-id="0735f-105">PermissionCheckBatchRequest オブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="0735f-105">Collection of PermissionCheckBatchRequest objects.</span></span> 
<a id="ID4EP"></a>

 
## <a name="permissioncheckbatchrequest"></a><span data-ttu-id="0735f-106">PermissionCheckBatchRequest</span><span class="sxs-lookup"><span data-stu-id="0735f-106">PermissionCheckBatchRequest</span></span>
 
<span data-ttu-id="0735f-107">PermissionCheckBatchRequest オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="0735f-107">The PermissionCheckBatchRequest object has the following specification.</span></span>
 
| <span data-ttu-id="0735f-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="0735f-108">Member</span></span>| <span data-ttu-id="0735f-109">種類</span><span class="sxs-lookup"><span data-stu-id="0735f-109">Type</span></span>| <span data-ttu-id="0735f-110">説明</span><span class="sxs-lookup"><span data-stu-id="0735f-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="0735f-111">Users</span><span class="sxs-lookup"><span data-stu-id="0735f-111">Users</span></span>| <span data-ttu-id="0735f-112">ユーザーの配列</span><span class="sxs-lookup"><span data-stu-id="0735f-112">Array of Users</span></span>| <span data-ttu-id="0735f-113">必須。</span><span class="sxs-lookup"><span data-stu-id="0735f-113">Required.</span></span> <span data-ttu-id="0735f-114">に対するアクセス許可を確認する対象の配列です。</span><span class="sxs-lookup"><span data-stu-id="0735f-114">Array of targets to check permission against.</span></span> <span data-ttu-id="0735f-115">この配列内の各エントリは、Xbox ユーザー ID (XUID) またはクロス ネットワークのシナリオの匿名のネットワークに接続してユーザーのいずれか (「匿名」:"allUsers")。</span><span class="sxs-lookup"><span data-stu-id="0735f-115">Each entry in this array is either an Xbox User ID (XUID) or an anonymous off-network user for cross-network scenarios ("anonymousUser":"allUsers").</span></span> | 
| <span data-ttu-id="0735f-116">アクセス許可</span><span class="sxs-lookup"><span data-stu-id="0735f-116">Permissions</span></span>| <span data-ttu-id="0735f-117">[PermissionId 列挙型](../enums/privacy-enum-permissionid.md)の配列</span><span class="sxs-lookup"><span data-stu-id="0735f-117">Array of [PermissionId Enumeration](../enums/privacy-enum-permissionid.md)</span></span>| <span data-ttu-id="0735f-118">必須。</span><span class="sxs-lookup"><span data-stu-id="0735f-118">Required.</span></span> <span data-ttu-id="0735f-119">各ユーザーに照らしてチェックするアクセス許可します。</span><span class="sxs-lookup"><span data-stu-id="0735f-119">The permissions to check against each user.</span></span>| 
  
<a id="ID4E3B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="0735f-120">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="0735f-120">Sample JSON syntax</span></span>
 

```json
{
    "users":
    [
        {"xuid":"12345"},
        {"xuid":"54321"}
    ],
    "permissions":
    [
        "ShareFriendList",
        "ShareGameHistory"
    ]
}
    
```

  
<a id="ID4EFC"></a>

 
## <a name="see-also"></a><span data-ttu-id="0735f-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="0735f-121">See also</span></span>
 
<a id="ID4EHC"></a>

 
##### <a name="parent"></a><span data-ttu-id="0735f-122">Parent</span><span class="sxs-lookup"><span data-stu-id="0735f-122">Parent</span></span> 

[<span data-ttu-id="0735f-123">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="0735f-123">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   