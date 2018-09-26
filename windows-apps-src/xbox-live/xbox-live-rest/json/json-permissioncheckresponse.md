---
title: PermissionCheckResponse (JSON)
assetID: 7a749001-b569-b0e0-2a35-f299474c8710
permalink: en-us/docs/xboxlive/rest/json-permissioncheckresponse.html
author: KevinAsgari
description: " PermissionCheckResponse (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f04da7d375b404a5d05dcf5d5e9905b00b7545d9
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4205935"
---
# <a name="permissioncheckresponse-json"></a><span data-ttu-id="b38ad-104">PermissionCheckResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="b38ad-104">PermissionCheckResponse (JSON)</span></span>
<span data-ttu-id="b38ad-105">1 つの対象ユーザーに対して 1 つのアクセス許可の設定を 1 人のユーザーからチェックの結果。</span><span class="sxs-lookup"><span data-stu-id="b38ad-105">The results of a check from a single user for a single permission setting against a single target user.</span></span> 
<a id="ID4EN"></a>

 
## <a name="permissioncheckresponse"></a><span data-ttu-id="b38ad-106">PermissionCheckResponse</span><span class="sxs-lookup"><span data-stu-id="b38ad-106">PermissionCheckResponse</span></span>
 
<span data-ttu-id="b38ad-107">PermissionCheckResponse オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="b38ad-107">The PermissionCheckResponse object has the following specification.</span></span>
 
| <span data-ttu-id="b38ad-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="b38ad-108">Member</span></span>| <span data-ttu-id="b38ad-109">種類</span><span class="sxs-lookup"><span data-stu-id="b38ad-109">Type</span></span>| <span data-ttu-id="b38ad-110">説明</span><span class="sxs-lookup"><span data-stu-id="b38ad-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b38ad-111">どう</span><span class="sxs-lookup"><span data-stu-id="b38ad-111">IsAllowed</span></span>| <span data-ttu-id="b38ad-112">ブール値</span><span class="sxs-lookup"><span data-stu-id="b38ad-112">Boolean value</span></span>| <span data-ttu-id="b38ad-113">必須。</span><span class="sxs-lookup"><span data-stu-id="b38ad-113">Required.</span></span> <span data-ttu-id="b38ad-114">このメンバーは、ターゲット ユーザーと要求された操作を実行する要求元のユーザーが許可されている場合<b>は true</b> 。</span><span class="sxs-lookup"><span data-stu-id="b38ad-114">This member is <b>true</b> if the requesting user is allowed to perform the requested action with the target user.</span></span>| 
| <span data-ttu-id="b38ad-115">結果</span><span class="sxs-lookup"><span data-stu-id="b38ad-115">Results</span></span>| <span data-ttu-id="b38ad-116">[PermissionCheckResult (JSON)](json-permissioncheckresult.md)の配列</span><span class="sxs-lookup"><span data-stu-id="b38ad-116">Array of [PermissionCheckResult (JSON)](json-permissioncheckresult.md)</span></span>| <span data-ttu-id="b38ad-117">省略可能。</span><span class="sxs-lookup"><span data-stu-id="b38ad-117">Optional.</span></span> <span data-ttu-id="b38ad-118"><b>どう</b>された false 要求者に関連するもので、チェックが拒否された場合は、アクセス許可が拒否された理由を示します。</span><span class="sxs-lookup"><span data-stu-id="b38ad-118">If <b>IsAllowed</b> was false and the check was denied by something related to the requester, indicates why the permission was denied.</span></span>| 
  
<a id="ID4E3B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="b38ad-119">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="b38ad-119">Sample JSON syntax</span></span>
 

```json
{
    "isAllowed": false,
    "reasons":
    [
        {"reason": "BlockedByRequestor"},
        {"reason": "MissingPrivilege", "restrictedSetting": "VideoCommunications"}
    ]
}
    
```

  
<a id="ID4EFC"></a>

 
## <a name="see-also"></a><span data-ttu-id="b38ad-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="b38ad-120">See also</span></span>
 
<a id="ID4EHC"></a>

 
##### <a name="parent"></a><span data-ttu-id="b38ad-121">Parent</span><span class="sxs-lookup"><span data-stu-id="b38ad-121">Parent</span></span> 

[<span data-ttu-id="b38ad-122">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="b38ad-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   