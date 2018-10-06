---
title: PermissionCheckBatchUserResponse (JSON)
assetID: c587dbc1-9436-4d55-afcb-deb47e3c2664
permalink: en-us/docs/xboxlive/rest/json-permissioncheckbatchuserresponse.html
author: KevinAsgari
description: " PermissionCheckBatchUserResponse (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 36726153d1364f384358471324452422f67741d2
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4393061"
---
# <a name="permissioncheckbatchuserresponse-json"></a><span data-ttu-id="1dec8-104">PermissionCheckBatchUserResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="1dec8-104">PermissionCheckBatchUserResponse (JSON)</span></span>
<span data-ttu-id="1dec8-105">バッチのアクセス許可の理由は、1 つの対象ユーザーのアクセス権の値の一覧を確認します。</span><span class="sxs-lookup"><span data-stu-id="1dec8-105">The reasons of a batch permission check for list of permission values for a single target user.</span></span> 
<a id="ID4EN"></a>

 
## <a name="permissioncheckbatchuserresponse"></a><span data-ttu-id="1dec8-106">PermissionCheckBatchUserResponse</span><span class="sxs-lookup"><span data-stu-id="1dec8-106">PermissionCheckBatchUserResponse</span></span>
 
<span data-ttu-id="1dec8-107">PermissionCheckBatchUserResponse オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="1dec8-107">The PermissionCheckBatchUserResponse object has the following specification.</span></span>
 
| <span data-ttu-id="1dec8-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="1dec8-108">Member</span></span>| <span data-ttu-id="1dec8-109">種類</span><span class="sxs-lookup"><span data-stu-id="1dec8-109">Type</span></span>| <span data-ttu-id="1dec8-110">説明</span><span class="sxs-lookup"><span data-stu-id="1dec8-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="1dec8-111">ユーザー</span><span class="sxs-lookup"><span data-stu-id="1dec8-111">User</span></span>| <span data-ttu-id="1dec8-112">string</span><span class="sxs-lookup"><span data-stu-id="1dec8-112">string</span></span>| <span data-ttu-id="1dec8-113">必須。</span><span class="sxs-lookup"><span data-stu-id="1dec8-113">Required.</span></span> <span data-ttu-id="1dec8-114">このメンバーは、ターゲット ユーザーと要求された操作を実行する要求元のユーザーが許可されている場合<b>は true</b> 。</span><span class="sxs-lookup"><span data-stu-id="1dec8-114">This member is <b>true</b> if the requesting user is allowed to perform the requested action with the target user.</span></span>| 
| <span data-ttu-id="1dec8-115">アクセス許可</span><span class="sxs-lookup"><span data-stu-id="1dec8-115">Permissions</span></span>| <span data-ttu-id="1dec8-116">[PermissionCheckResponse (JSON)](json-permissioncheckresponse.md)の配列</span><span class="sxs-lookup"><span data-stu-id="1dec8-116">Array of [PermissionCheckResponse (JSON)](json-permissioncheckresponse.md)</span></span>| <span data-ttu-id="1dec8-117">必須。</span><span class="sxs-lookup"><span data-stu-id="1dec8-117">Required.</span></span> <span data-ttu-id="1dec8-118">各アクセス許可の要求と同じ順序で、元の要求で要求されている[PermissionCheckResponse (JSON)](json-permissioncheckresponse.md) 。</span><span class="sxs-lookup"><span data-stu-id="1dec8-118">A [PermissionCheckResponse (JSON)](json-permissioncheckresponse.md) for each permission that was asked for in the original request, in the same order as in the request.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="1dec8-119">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="1dec8-119">Sample JSON syntax</span></span>
 

```json
{
    "User": {"Xuid": "12345"},
    "Permissions":
    [
        {
            "isAllowed": true
        },
        {
            "isAllowed": false
        },
        {
            "isAllowed": false,
            "reasons":
            [
                {"reason": "BlockedByRequestor"},
                {"reason": "MissingPrivilege", "restrictedSetting": "VideoCommunications"}
            ]
        }
    ]
}
    
```

  
<a id="ID4EGC"></a>

 
## <a name="see-also"></a><span data-ttu-id="1dec8-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="1dec8-120">See also</span></span>
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a><span data-ttu-id="1dec8-121">Parent</span><span class="sxs-lookup"><span data-stu-id="1dec8-121">Parent</span></span> 

[<span data-ttu-id="1dec8-122">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="1dec8-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   