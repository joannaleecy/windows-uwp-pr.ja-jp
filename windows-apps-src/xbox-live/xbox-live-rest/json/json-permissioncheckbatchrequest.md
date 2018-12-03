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
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8324979"
---
# <a name="permissioncheckbatchrequest-json"></a><span data-ttu-id="82a18-104">PermissionCheckBatchRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="82a18-104">PermissionCheckBatchRequest (JSON)</span></span>
<span data-ttu-id="82a18-105">PermissionCheckBatchRequest オブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="82a18-105">Collection of PermissionCheckBatchRequest objects.</span></span> 
<a id="ID4EP"></a>

 
## <a name="permissioncheckbatchrequest"></a><span data-ttu-id="82a18-106">PermissionCheckBatchRequest</span><span class="sxs-lookup"><span data-stu-id="82a18-106">PermissionCheckBatchRequest</span></span>
 
<span data-ttu-id="82a18-107">PermissionCheckBatchRequest オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="82a18-107">The PermissionCheckBatchRequest object has the following specification.</span></span>
 
| <span data-ttu-id="82a18-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="82a18-108">Member</span></span>| <span data-ttu-id="82a18-109">種類</span><span class="sxs-lookup"><span data-stu-id="82a18-109">Type</span></span>| <span data-ttu-id="82a18-110">説明</span><span class="sxs-lookup"><span data-stu-id="82a18-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="82a18-111">Users</span><span class="sxs-lookup"><span data-stu-id="82a18-111">Users</span></span>| <span data-ttu-id="82a18-112">ユーザーの配列</span><span class="sxs-lookup"><span data-stu-id="82a18-112">Array of Users</span></span>| <span data-ttu-id="82a18-113">必須。</span><span class="sxs-lookup"><span data-stu-id="82a18-113">Required.</span></span> <span data-ttu-id="82a18-114">に対するアクセス許可を確認する対象の配列です。</span><span class="sxs-lookup"><span data-stu-id="82a18-114">Array of targets to check permission against.</span></span> <span data-ttu-id="82a18-115">この配列内の各エントリは、Xbox ユーザー ID (XUID) またはクロス ネットワークのシナリオの匿名のネットワークに接続してユーザーのいずれか (「匿名」:"allUsers")。</span><span class="sxs-lookup"><span data-stu-id="82a18-115">Each entry in this array is either an Xbox User ID (XUID) or an anonymous off-network user for cross-network scenarios ("anonymousUser":"allUsers").</span></span> | 
| <span data-ttu-id="82a18-116">アクセス許可</span><span class="sxs-lookup"><span data-stu-id="82a18-116">Permissions</span></span>| <span data-ttu-id="82a18-117">[PermissionId 列挙型](../enums/privacy-enum-permissionid.md)の配列</span><span class="sxs-lookup"><span data-stu-id="82a18-117">Array of [PermissionId Enumeration](../enums/privacy-enum-permissionid.md)</span></span>| <span data-ttu-id="82a18-118">必須。</span><span class="sxs-lookup"><span data-stu-id="82a18-118">Required.</span></span> <span data-ttu-id="82a18-119">各ユーザーに照らしてチェックするアクセス許可します。</span><span class="sxs-lookup"><span data-stu-id="82a18-119">The permissions to check against each user.</span></span>| 
  
<a id="ID4E3B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="82a18-120">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="82a18-120">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="82a18-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="82a18-121">See also</span></span>
 
<a id="ID4EHC"></a>

 
##### <a name="parent"></a><span data-ttu-id="82a18-122">Parent</span><span class="sxs-lookup"><span data-stu-id="82a18-122">Parent</span></span> 

[<span data-ttu-id="82a18-123">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="82a18-123">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   