---
title: PermissionCheckResult (JSON)
assetID: 1cf147fa-4ff1-3299-0822-0fc1726d1600
permalink: en-us/docs/xboxlive/rest/json-permissioncheckresult.html
description: " PermissionCheckResult (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dc13826be1b6f81201d069f5ade7ea5ba6668cd0
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57598447"
---
# <a name="permissioncheckresult-json"></a><span data-ttu-id="004f3-104">PermissionCheckResult (JSON)</span><span class="sxs-lookup"><span data-stu-id="004f3-104">PermissionCheckResult (JSON)</span></span>
<span data-ttu-id="004f3-105">1 つのターゲット ユーザーに対して 1 つのアクセス許可の設定の 1 人のユーザーからのチェックの結果。</span><span class="sxs-lookup"><span data-stu-id="004f3-105">The results of a check from a single user for a single permission setting against a single target user.</span></span> 
<a id="ID4EP"></a>

 
## <a name="permissioncheckresult"></a><span data-ttu-id="004f3-106">PermissionCheckResult</span><span class="sxs-lookup"><span data-stu-id="004f3-106">PermissionCheckResult</span></span>
 
<span data-ttu-id="004f3-107">PermissionCheckResult オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="004f3-107">The PermissionCheckResult object has the following specification.</span></span>
 
| <span data-ttu-id="004f3-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="004f3-108">Member</span></span>| <span data-ttu-id="004f3-109">種類</span><span class="sxs-lookup"><span data-stu-id="004f3-109">Type</span></span>| <span data-ttu-id="004f3-110">説明</span><span class="sxs-lookup"><span data-stu-id="004f3-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="004f3-111">reason</span><span class="sxs-lookup"><span data-stu-id="004f3-111">reason</span></span>| <span data-ttu-id="004f3-112">string</span><span class="sxs-lookup"><span data-stu-id="004f3-112">string</span></span>| <span data-ttu-id="004f3-113">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="004f3-113">Optional.</span></span> <span data-ttu-id="004f3-114">A <b>PermissionResultCode</b> 、アクセス許可が拒否された理由を示す値場合<b>IsAllowed</b>が false であった。</span><span class="sxs-lookup"><span data-stu-id="004f3-114">A <b>PermissionResultCode</b> value that indicates why the permission was denied if <b>IsAllowed</b> was false.</span></span>| 
| <span data-ttu-id="004f3-115">restrictedSetting</span><span class="sxs-lookup"><span data-stu-id="004f3-115">restrictedSetting</span></span>| <span data-ttu-id="004f3-116">string</span><span class="sxs-lookup"><span data-stu-id="004f3-116">string</span></span>| <span data-ttu-id="004f3-117">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="004f3-117">Optional.</span></span> <span data-ttu-id="004f3-118">場合、 <b>PermissionResultCode</b>値、<b>理由</b>メンバーは、要求元の権限の確認が失敗したことを示す特権の失敗を示します。</span><span class="sxs-lookup"><span data-stu-id="004f3-118">If the <b>PermissionResultCode</b> value in the <b>reason</b> member indicates that a privilege check for the requestor failed, this indicates which privilege failed.</span></span>| 
  
<a id="ID4E6B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="004f3-119">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="004f3-119">Sample JSON syntax</span></span>
 

```json
{
    "reason": "MissingPrivilege",
    "restrictedSetting": "VideoCommunications"
}
    
```

  
<a id="ID4EIC"></a>

 
## <a name="see-also"></a><span data-ttu-id="004f3-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="004f3-120">See also</span></span>
 
<a id="ID4EKC"></a>

 
##### <a name="parent"></a><span data-ttu-id="004f3-121">Parent</span><span class="sxs-lookup"><span data-stu-id="004f3-121">Parent</span></span> 

[<span data-ttu-id="004f3-122">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="004f3-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   