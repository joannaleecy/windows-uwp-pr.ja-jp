---
title: PermissionCheckResult (JSON)
assetID: 1cf147fa-4ff1-3299-0822-0fc1726d1600
permalink: en-us/docs/xboxlive/rest/json-permissioncheckresult.html
author: KevinAsgari
description: " PermissionCheckResult (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 308301b41b407291ffad74337172c5be8f4d2c59
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4058703"
---
# <a name="permissioncheckresult-json"></a><span data-ttu-id="cb298-104">PermissionCheckResult (JSON)</span><span class="sxs-lookup"><span data-stu-id="cb298-104">PermissionCheckResult (JSON)</span></span>
<span data-ttu-id="cb298-105">1 つの対象ユーザーに対して 1 つのアクセス許可の設定を 1 人のユーザーからチェックの結果。</span><span class="sxs-lookup"><span data-stu-id="cb298-105">The results of a check from a single user for a single permission setting against a single target user.</span></span> 
<a id="ID4EP"></a>

 
## <a name="permissioncheckresult"></a><span data-ttu-id="cb298-106">PermissionCheckResult</span><span class="sxs-lookup"><span data-stu-id="cb298-106">PermissionCheckResult</span></span>
 
<span data-ttu-id="cb298-107">PermissionCheckResult オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="cb298-107">The PermissionCheckResult object has the following specification.</span></span>
 
| <span data-ttu-id="cb298-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="cb298-108">Member</span></span>| <span data-ttu-id="cb298-109">種類</span><span class="sxs-lookup"><span data-stu-id="cb298-109">Type</span></span>| <span data-ttu-id="cb298-110">説明</span><span class="sxs-lookup"><span data-stu-id="cb298-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="cb298-111">理由</span><span class="sxs-lookup"><span data-stu-id="cb298-111">reason</span></span>| <span data-ttu-id="cb298-112">string</span><span class="sxs-lookup"><span data-stu-id="cb298-112">string</span></span>| <span data-ttu-id="cb298-113">省略可能。</span><span class="sxs-lookup"><span data-stu-id="cb298-113">Optional.</span></span> <span data-ttu-id="cb298-114">アクセス許可が拒否された理由を示す<b>PermissionResultCode</b>値<b>どう</b>が false の場合。</span><span class="sxs-lookup"><span data-stu-id="cb298-114">A <b>PermissionResultCode</b> value that indicates why the permission was denied if <b>IsAllowed</b> was false.</span></span>| 
| <span data-ttu-id="cb298-115">restrictedSetting</span><span class="sxs-lookup"><span data-stu-id="cb298-115">restrictedSetting</span></span>| <span data-ttu-id="cb298-116">string</span><span class="sxs-lookup"><span data-stu-id="cb298-116">string</span></span>| <span data-ttu-id="cb298-117">省略可能。</span><span class="sxs-lookup"><span data-stu-id="cb298-117">Optional.</span></span> <span data-ttu-id="cb298-118">リクエスターの特権チェックが失敗した<b>理由</b>メンバーの<b>PermissionResultCode</b>値が示されている場合は、どの特権が失敗したを示します。</span><span class="sxs-lookup"><span data-stu-id="cb298-118">If the <b>PermissionResultCode</b> value in the <b>reason</b> member indicates that a privilege check for the requestor failed, this indicates which privilege failed.</span></span>| 
  
<a id="ID4E6B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="cb298-119">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="cb298-119">Sample JSON syntax</span></span>
 

```json
{
    "reason": "MissingPrivilege",
    "restrictedSetting": "VideoCommunications"
}
    
```

  
<a id="ID4EIC"></a>

 
## <a name="see-also"></a><span data-ttu-id="cb298-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="cb298-120">See also</span></span>
 
<a id="ID4EKC"></a>

 
##### <a name="parent"></a><span data-ttu-id="cb298-121">Parent</span><span class="sxs-lookup"><span data-stu-id="cb298-121">Parent</span></span> 

[<span data-ttu-id="cb298-122">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="cb298-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   