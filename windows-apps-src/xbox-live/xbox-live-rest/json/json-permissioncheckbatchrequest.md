---
title: PermissionCheckBatchRequest (JSON)
assetID: 3100b17c-1b60-fdf2-3af9-7e424f1903ee
permalink: en-us/docs/xboxlive/rest/json-permissioncheckbatchrequest.html
description: " PermissionCheckBatchRequest (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 538547c85648970ab3e9fe3ae413e8a03df814ad
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623507"
---
# <a name="permissioncheckbatchrequest-json"></a><span data-ttu-id="2c977-104">PermissionCheckBatchRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="2c977-104">PermissionCheckBatchRequest (JSON)</span></span>
<span data-ttu-id="2c977-105">PermissionCheckBatchRequest オブジェクトのコレクション。</span><span class="sxs-lookup"><span data-stu-id="2c977-105">Collection of PermissionCheckBatchRequest objects.</span></span> 
<a id="ID4EP"></a>

 
## <a name="permissioncheckbatchrequest"></a><span data-ttu-id="2c977-106">PermissionCheckBatchRequest</span><span class="sxs-lookup"><span data-stu-id="2c977-106">PermissionCheckBatchRequest</span></span>
 
<span data-ttu-id="2c977-107">PermissionCheckBatchRequest オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="2c977-107">The PermissionCheckBatchRequest object has the following specification.</span></span>
 
| <span data-ttu-id="2c977-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="2c977-108">Member</span></span>| <span data-ttu-id="2c977-109">種類</span><span class="sxs-lookup"><span data-stu-id="2c977-109">Type</span></span>| <span data-ttu-id="2c977-110">説明</span><span class="sxs-lookup"><span data-stu-id="2c977-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="2c977-111">Users</span><span class="sxs-lookup"><span data-stu-id="2c977-111">Users</span></span>| <span data-ttu-id="2c977-112">ユーザーの配列</span><span class="sxs-lookup"><span data-stu-id="2c977-112">Array of Users</span></span>| <span data-ttu-id="2c977-113">必須。</span><span class="sxs-lookup"><span data-stu-id="2c977-113">Required.</span></span> <span data-ttu-id="2c977-114">に対するアクセス許可を確認するターゲットの配列。</span><span class="sxs-lookup"><span data-stu-id="2c977-114">Array of targets to check permission against.</span></span> <span data-ttu-id="2c977-115">この配列内の各エントリは Xbox ユーザー ID (XUID) またはネットワーク間のシナリオに対する匿名のネットワークに接続してユーザーのいずれか (「匿名」:"allUsers")。</span><span class="sxs-lookup"><span data-stu-id="2c977-115">Each entry in this array is either an Xbox User ID (XUID) or an anonymous off-network user for cross-network scenarios ("anonymousUser":"allUsers").</span></span> | 
| <span data-ttu-id="2c977-116">アクセス許可</span><span class="sxs-lookup"><span data-stu-id="2c977-116">Permissions</span></span>| <span data-ttu-id="2c977-117">配列[PermissionId 列挙型](../enums/privacy-enum-permissionid.md)</span><span class="sxs-lookup"><span data-stu-id="2c977-117">Array of [PermissionId Enumeration](../enums/privacy-enum-permissionid.md)</span></span>| <span data-ttu-id="2c977-118">必須。</span><span class="sxs-lookup"><span data-stu-id="2c977-118">Required.</span></span> <span data-ttu-id="2c977-119">各ユーザーに対して確認するアクセス許可。</span><span class="sxs-lookup"><span data-stu-id="2c977-119">The permissions to check against each user.</span></span>| 
  
<a id="ID4E3B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="2c977-120">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="2c977-120">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="2c977-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="2c977-121">See also</span></span>
 
<a id="ID4EHC"></a>

 
##### <a name="parent"></a><span data-ttu-id="2c977-122">Parent</span><span class="sxs-lookup"><span data-stu-id="2c977-122">Parent</span></span> 

[<span data-ttu-id="2c977-123">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="2c977-123">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   