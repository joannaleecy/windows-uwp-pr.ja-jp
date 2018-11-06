---
title: PermissionCheckResult (JSON)
assetID: 1cf147fa-4ff1-3299-0822-0fc1726d1600
permalink: en-us/docs/xboxlive/rest/json-permissioncheckresult.html
author: KevinAsgari
description: " PermissionCheckResult (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8c78fe5a0707797911ff9015cfa28378201b0939
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6040063"
---
# <a name="permissioncheckresult-json"></a><span data-ttu-id="3696e-104">PermissionCheckResult (JSON)</span><span class="sxs-lookup"><span data-stu-id="3696e-104">PermissionCheckResult (JSON)</span></span>
<span data-ttu-id="3696e-105">1 つの対象ユーザーに対して単一のアクセス許可の設定の 1 人のユーザーからのチェックの結果。</span><span class="sxs-lookup"><span data-stu-id="3696e-105">The results of a check from a single user for a single permission setting against a single target user.</span></span> 
<a id="ID4EP"></a>

 
## <a name="permissioncheckresult"></a><span data-ttu-id="3696e-106">PermissionCheckResult</span><span class="sxs-lookup"><span data-stu-id="3696e-106">PermissionCheckResult</span></span>
 
<span data-ttu-id="3696e-107">PermissionCheckResult オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="3696e-107">The PermissionCheckResult object has the following specification.</span></span>
 
| <span data-ttu-id="3696e-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="3696e-108">Member</span></span>| <span data-ttu-id="3696e-109">種類</span><span class="sxs-lookup"><span data-stu-id="3696e-109">Type</span></span>| <span data-ttu-id="3696e-110">説明</span><span class="sxs-lookup"><span data-stu-id="3696e-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="3696e-111">理由</span><span class="sxs-lookup"><span data-stu-id="3696e-111">reason</span></span>| <span data-ttu-id="3696e-112">string</span><span class="sxs-lookup"><span data-stu-id="3696e-112">string</span></span>| <span data-ttu-id="3696e-113">省略可能。</span><span class="sxs-lookup"><span data-stu-id="3696e-113">Optional.</span></span> <span data-ttu-id="3696e-114">アクセス許可が拒否された理由を示す<b>PermissionResultCode</b>値<b>どう</b>が false の場合。</span><span class="sxs-lookup"><span data-stu-id="3696e-114">A <b>PermissionResultCode</b> value that indicates why the permission was denied if <b>IsAllowed</b> was false.</span></span>| 
| <span data-ttu-id="3696e-115">restrictedSetting</span><span class="sxs-lookup"><span data-stu-id="3696e-115">restrictedSetting</span></span>| <span data-ttu-id="3696e-116">string</span><span class="sxs-lookup"><span data-stu-id="3696e-116">string</span></span>| <span data-ttu-id="3696e-117">省略可能。</span><span class="sxs-lookup"><span data-stu-id="3696e-117">Optional.</span></span> <span data-ttu-id="3696e-118"><b>理由</b>メンバーの<b>PermissionResultCode</b>値は、要求元の特権チェックが失敗したことを示している場合は、どの特権が失敗したを示します。</span><span class="sxs-lookup"><span data-stu-id="3696e-118">If the <b>PermissionResultCode</b> value in the <b>reason</b> member indicates that a privilege check for the requestor failed, this indicates which privilege failed.</span></span>| 
  
<a id="ID4E6B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="3696e-119">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="3696e-119">Sample JSON syntax</span></span>
 

```json
{
    "reason": "MissingPrivilege",
    "restrictedSetting": "VideoCommunications"
}
    
```

  
<a id="ID4EIC"></a>

 
## <a name="see-also"></a><span data-ttu-id="3696e-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="3696e-120">See also</span></span>
 
<a id="ID4EKC"></a>

 
##### <a name="parent"></a><span data-ttu-id="3696e-121">Parent</span><span class="sxs-lookup"><span data-stu-id="3696e-121">Parent</span></span> 

[<span data-ttu-id="3696e-122">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="3696e-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   