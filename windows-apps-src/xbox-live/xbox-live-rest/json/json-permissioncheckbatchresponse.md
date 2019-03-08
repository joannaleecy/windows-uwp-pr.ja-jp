---
title: PermissionCheckBatchResponse (JSON)
assetID: f157ed8d-7483-1b34-bc3d-e3fcf6a7d055
permalink: en-us/docs/xboxlive/rest/json-permissioncheckbatchresponse.html
description: " PermissionCheckBatchResponse (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6ac79d3361e83993c372b1d651e97e900788d39f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613347"
---
# <a name="permissioncheckbatchresponse-json"></a><span data-ttu-id="69cab-104">PermissionCheckBatchResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="69cab-104">PermissionCheckBatchResponse (JSON)</span></span>
<span data-ttu-id="69cab-105">バッチのアクセス許可の結果は、複数のユーザーのアクセス許可の値の一覧を確認します。</span><span class="sxs-lookup"><span data-stu-id="69cab-105">The results of a batch permission check for a list of permission values for multiple users.</span></span> 
<a id="ID4EN"></a>

 
## <a name="permissioncheckbatchresponse"></a><span data-ttu-id="69cab-106">PermissionCheckBatchResponse</span><span class="sxs-lookup"><span data-stu-id="69cab-106">PermissionCheckBatchResponse</span></span>
 
<span data-ttu-id="69cab-107">PermissionCheckBatchResponse オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="69cab-107">The PermissionCheckBatchResponse object has the following specification.</span></span>
 
| <span data-ttu-id="69cab-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="69cab-108">Member</span></span>| <span data-ttu-id="69cab-109">種類</span><span class="sxs-lookup"><span data-stu-id="69cab-109">Type</span></span>| <span data-ttu-id="69cab-110">説明</span><span class="sxs-lookup"><span data-stu-id="69cab-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="69cab-111">Responses</span><span class="sxs-lookup"><span data-stu-id="69cab-111">Responses</span></span>| <span data-ttu-id="69cab-112">配列[PermissionCheckBatchUserResponse (JSON)](json-permissioncheckbatchuserresponse.md)</span><span class="sxs-lookup"><span data-stu-id="69cab-112">Array of [PermissionCheckBatchUserResponse (JSON)](json-permissioncheckbatchuserresponse.md)</span></span>| <span data-ttu-id="69cab-113">必須。</span><span class="sxs-lookup"><span data-stu-id="69cab-113">Required.</span></span> <span data-ttu-id="69cab-114">A [PermissionCheckBatchUserResponse (JSON)](json-permissioncheckbatchuserresponse.md)権限ごとに、その要求と同じ順序で、元の要求で要求されているオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="69cab-114">A [PermissionCheckBatchUserResponse (JSON)](json-permissioncheckbatchuserresponse.md) object for each permission that was asked for in the original request, in the same order as in that request.</span></span>| 
  
<a id="ID4EQB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="69cab-115">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="69cab-115">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="69cab-116">関連項目</span><span class="sxs-lookup"><span data-stu-id="69cab-116">See also</span></span>
 
<a id="ID4E2B"></a>

 
##### <a name="parent"></a><span data-ttu-id="69cab-117">Parent</span><span class="sxs-lookup"><span data-stu-id="69cab-117">Parent</span></span> 

[<span data-ttu-id="69cab-118">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="69cab-118">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   