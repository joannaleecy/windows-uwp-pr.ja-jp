---
title: PermissionCheckBatchResponse (JSON)
assetID: f157ed8d-7483-1b34-bc3d-e3fcf6a7d055
permalink: en-us/docs/xboxlive/rest/json-permissioncheckbatchresponse.html
author: KevinAsgari
description: " PermissionCheckBatchResponse (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9bc3d574274bdef6d0033e9f5313457706dd509e
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3932646"
---
# <a name="permissioncheckbatchresponse-json"></a><span data-ttu-id="225a0-104">PermissionCheckBatchResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="225a0-104">PermissionCheckBatchResponse (JSON)</span></span>
<span data-ttu-id="225a0-105">バッチのアクセス許可の結果は、複数のユーザーのアクセス許可の値の一覧を確認します。</span><span class="sxs-lookup"><span data-stu-id="225a0-105">The results of a batch permission check for a list of permission values for multiple users.</span></span> 
<a id="ID4EN"></a>

 
## <a name="permissioncheckbatchresponse"></a><span data-ttu-id="225a0-106">PermissionCheckBatchResponse</span><span class="sxs-lookup"><span data-stu-id="225a0-106">PermissionCheckBatchResponse</span></span>
 
<span data-ttu-id="225a0-107">PermissionCheckBatchResponse オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="225a0-107">The PermissionCheckBatchResponse object has the following specification.</span></span>
 
| <span data-ttu-id="225a0-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="225a0-108">Member</span></span>| <span data-ttu-id="225a0-109">種類</span><span class="sxs-lookup"><span data-stu-id="225a0-109">Type</span></span>| <span data-ttu-id="225a0-110">説明</span><span class="sxs-lookup"><span data-stu-id="225a0-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="225a0-111">Responses</span><span class="sxs-lookup"><span data-stu-id="225a0-111">Responses</span></span>| <span data-ttu-id="225a0-112">[PermissionCheckBatchUserResponse (JSON)](json-permissioncheckbatchuserresponse.md)の配列</span><span class="sxs-lookup"><span data-stu-id="225a0-112">Array of [PermissionCheckBatchUserResponse (JSON)](json-permissioncheckbatchuserresponse.md)</span></span>| <span data-ttu-id="225a0-113">必須。</span><span class="sxs-lookup"><span data-stu-id="225a0-113">Required.</span></span> <span data-ttu-id="225a0-114">その要求と同じ順序で、元の要求で要求されている各アクセス許可に対して[PermissionCheckBatchUserResponse (JSON)](json-permissioncheckbatchuserresponse.md)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="225a0-114">A [PermissionCheckBatchUserResponse (JSON)](json-permissioncheckbatchuserresponse.md) object for each permission that was asked for in the original request, in the same order as in that request.</span></span>| 
  
<a id="ID4EQB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="225a0-115">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="225a0-115">Sample JSON syntax</span></span>
 

```json
{
    "responses":
    [
        {
            "user": {"xuid":"12345"},
            "permissions":
            [
                {
                    "isAllowed":true
                },
                {
                    "isAllowed":true
                }
            ]
        },
        {
            "user": {"xuid":"54321"},
            "permissions":
            [
                {
                    "isAllowed":false,
                    "reasons":
                    [
                        {"reason":"NotAllowed"}
                    ]
                },
                {
                    "isAllowed":false,
                    "reasons":
                    [
                        {"reason":"PrivilegeRestrictsTarget", "restrictedSetting":"AllowProfileViewing"}
                    ]
                }
            ]
        }
    ]
}
    
```

  
<a id="ID4EZB"></a>

 
## <a name="see-also"></a><span data-ttu-id="225a0-116">関連項目</span><span class="sxs-lookup"><span data-stu-id="225a0-116">See also</span></span>
 
<a id="ID4E2B"></a>

 
##### <a name="parent"></a><span data-ttu-id="225a0-117">Parent</span><span class="sxs-lookup"><span data-stu-id="225a0-117">Parent</span></span> 

[<span data-ttu-id="225a0-118">JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="225a0-118">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   