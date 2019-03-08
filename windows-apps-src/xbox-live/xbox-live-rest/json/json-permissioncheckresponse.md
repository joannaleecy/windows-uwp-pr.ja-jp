---
title: PermissionCheckResponse (JSON)
assetID: 7a749001-b569-b0e0-2a35-f299474c8710
permalink: en-us/docs/xboxlive/rest/json-permissioncheckresponse.html
description: " PermissionCheckResponse (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7623a45fa21e30a015bd5c6a7c1f5add19cc189b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623367"
---
# <a name="permissioncheckresponse-json"></a><span data-ttu-id="dd8a2-104">PermissionCheckResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="dd8a2-104">PermissionCheckResponse (JSON)</span></span>
<span data-ttu-id="dd8a2-105">1 つのターゲット ユーザーに対して 1 つのアクセス許可の設定の 1 人のユーザーからのチェックの結果。</span><span class="sxs-lookup"><span data-stu-id="dd8a2-105">The results of a check from a single user for a single permission setting against a single target user.</span></span> 
<a id="ID4EN"></a>

 
## <a name="permissioncheckresponse"></a><span data-ttu-id="dd8a2-106">PermissionCheckResponse</span><span class="sxs-lookup"><span data-stu-id="dd8a2-106">PermissionCheckResponse</span></span>
 
<span data-ttu-id="dd8a2-107">PermissionCheckResponse オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="dd8a2-107">The PermissionCheckResponse object has the following specification.</span></span>
 
| <span data-ttu-id="dd8a2-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="dd8a2-108">Member</span></span>| <span data-ttu-id="dd8a2-109">種類</span><span class="sxs-lookup"><span data-stu-id="dd8a2-109">Type</span></span>| <span data-ttu-id="dd8a2-110">説明</span><span class="sxs-lookup"><span data-stu-id="dd8a2-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="dd8a2-111">IsAllowed</span><span class="sxs-lookup"><span data-stu-id="dd8a2-111">IsAllowed</span></span>| <span data-ttu-id="dd8a2-112">ブール値</span><span class="sxs-lookup"><span data-stu-id="dd8a2-112">Boolean value</span></span>| <span data-ttu-id="dd8a2-113">必須。</span><span class="sxs-lookup"><span data-stu-id="dd8a2-113">Required.</span></span> <span data-ttu-id="dd8a2-114">このメンバーは<b>true</b>対象ユーザーに要求された操作を実行する要求元のユーザーが許可されている場合。</span><span class="sxs-lookup"><span data-stu-id="dd8a2-114">This member is <b>true</b> if the requesting user is allowed to perform the requested action with the target user.</span></span>| 
| <span data-ttu-id="dd8a2-115">結果</span><span class="sxs-lookup"><span data-stu-id="dd8a2-115">Results</span></span>| <span data-ttu-id="dd8a2-116">配列[PermissionCheckResult (JSON)](json-permissioncheckresult.md)</span><span class="sxs-lookup"><span data-stu-id="dd8a2-116">Array of [PermissionCheckResult (JSON)](json-permissioncheckresult.md)</span></span>| <span data-ttu-id="dd8a2-117">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="dd8a2-117">Optional.</span></span> <span data-ttu-id="dd8a2-118">場合<b>IsAllowed</b>が false であったし、確認が拒否された、依頼者に関連するもので、アクセス許可が拒否された理由を示します。</span><span class="sxs-lookup"><span data-stu-id="dd8a2-118">If <b>IsAllowed</b> was false and the check was denied by something related to the requester, indicates why the permission was denied.</span></span>| 
  
<a id="ID4E3B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="dd8a2-119">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="dd8a2-119">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="dd8a2-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="dd8a2-120">See also</span></span>
 
<a id="ID4EHC"></a>

 
##### <a name="parent"></a><span data-ttu-id="dd8a2-121">Parent</span><span class="sxs-lookup"><span data-stu-id="dd8a2-121">Parent</span></span> 

[<span data-ttu-id="dd8a2-122">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="dd8a2-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   