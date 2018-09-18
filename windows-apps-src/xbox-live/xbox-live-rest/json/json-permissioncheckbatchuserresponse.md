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
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4022729"
---
# <a name="permissioncheckbatchuserresponse-json"></a><span data-ttu-id="3b059-104">PermissionCheckBatchUserResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="3b059-104">PermissionCheckBatchUserResponse (JSON)</span></span>
<span data-ttu-id="3b059-105">バッチのアクセス許可の理由は、1 つの対象ユーザーのアクセス権の値の一覧を確認します。</span><span class="sxs-lookup"><span data-stu-id="3b059-105">The reasons of a batch permission check for list of permission values for a single target user.</span></span> 
<a id="ID4EN"></a>

 
## <a name="permissioncheckbatchuserresponse"></a><span data-ttu-id="3b059-106">PermissionCheckBatchUserResponse</span><span class="sxs-lookup"><span data-stu-id="3b059-106">PermissionCheckBatchUserResponse</span></span>
 
<span data-ttu-id="3b059-107">PermissionCheckBatchUserResponse オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="3b059-107">The PermissionCheckBatchUserResponse object has the following specification.</span></span>
 
| <span data-ttu-id="3b059-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="3b059-108">Member</span></span>| <span data-ttu-id="3b059-109">種類</span><span class="sxs-lookup"><span data-stu-id="3b059-109">Type</span></span>| <span data-ttu-id="3b059-110">説明</span><span class="sxs-lookup"><span data-stu-id="3b059-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="3b059-111">ユーザー</span><span class="sxs-lookup"><span data-stu-id="3b059-111">User</span></span>| <span data-ttu-id="3b059-112">string</span><span class="sxs-lookup"><span data-stu-id="3b059-112">string</span></span>| <span data-ttu-id="3b059-113">必須。</span><span class="sxs-lookup"><span data-stu-id="3b059-113">Required.</span></span> <span data-ttu-id="3b059-114">このメンバーは、ターゲット ユーザーと要求された操作を実行する要求元のユーザーが許可されている場合<b>は true</b> 。</span><span class="sxs-lookup"><span data-stu-id="3b059-114">This member is <b>true</b> if the requesting user is allowed to perform the requested action with the target user.</span></span>| 
| <span data-ttu-id="3b059-115">アクセス許可</span><span class="sxs-lookup"><span data-stu-id="3b059-115">Permissions</span></span>| <span data-ttu-id="3b059-116">[PermissionCheckResponse (JSON)](json-permissioncheckresponse.md)の配列</span><span class="sxs-lookup"><span data-stu-id="3b059-116">Array of [PermissionCheckResponse (JSON)](json-permissioncheckresponse.md)</span></span>| <span data-ttu-id="3b059-117">必須。</span><span class="sxs-lookup"><span data-stu-id="3b059-117">Required.</span></span> <span data-ttu-id="3b059-118">各アクセス許可の要求と同じ順序で元の要求が要求されている[PermissionCheckResponse (JSON)](json-permissioncheckresponse.md) 。</span><span class="sxs-lookup"><span data-stu-id="3b059-118">A [PermissionCheckResponse (JSON)](json-permissioncheckresponse.md) for each permission that was asked for in the original request, in the same order as in the request.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="3b059-119">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="3b059-119">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="3b059-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="3b059-120">See also</span></span>
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a><span data-ttu-id="3b059-121">Parent</span><span class="sxs-lookup"><span data-stu-id="3b059-121">Parent</span></span> 

[<span data-ttu-id="3b059-122">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="3b059-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   