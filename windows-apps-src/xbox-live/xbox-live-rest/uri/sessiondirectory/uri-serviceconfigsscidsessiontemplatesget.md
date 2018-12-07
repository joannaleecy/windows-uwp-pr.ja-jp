---
title: GET (/serviceconfigs/{scid}/sessiontemplates)
assetID: 5172c7be-371b-f0b1-d1d0-f0981eb2bfa7
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatesget.html
description: " GET (/serviceconfigs/{scid}/sessiontemplates)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5cb51ea751ca843dfc2a08cda2e79f79409d97b5
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8737076"
---
# <a name="get-serviceconfigsscidsessiontemplates"></a><span data-ttu-id="1ac09-104">GET (/serviceconfigs/{scid}/sessiontemplates)</span><span class="sxs-lookup"><span data-stu-id="1ac09-104">GET (/serviceconfigs/{scid}/sessiontemplates)</span></span>
<span data-ttu-id="1ac09-105">MPSD セッション テンプレートのセットを取得します。</span><span class="sxs-lookup"><span data-stu-id="1ac09-105">Retrieves a set of MPSD session templates.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="1ac09-106">この URI メソッドには、X Xbl コントラクト バージョンのヘッダーの要素が必要があります: 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="1ac09-106">This URI method requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="1ac09-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1ac09-107">URI parameters</span></span>](#ID4ET)
  * [<span data-ttu-id="1ac09-108">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="1ac09-108">HTTP status codes</span></span>](#ID4E5)
  * [<span data-ttu-id="1ac09-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="1ac09-109">Request body</span></span>](#ID4EFB)
  * [<span data-ttu-id="1ac09-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="1ac09-110">Response body</span></span>](#ID4EQB)

<a id="ID4ET"></a>


## <a name="uri-parameters"></a><span data-ttu-id="1ac09-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1ac09-111">URI parameters</span></span>

| <span data-ttu-id="1ac09-112">パラメーター</span><span class="sxs-lookup"><span data-stu-id="1ac09-112">Parameter</span></span>| <span data-ttu-id="1ac09-113">型</span><span class="sxs-lookup"><span data-stu-id="1ac09-113">Type</span></span>| <span data-ttu-id="1ac09-114">説明</span><span class="sxs-lookup"><span data-stu-id="1ac09-114">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="1ac09-115">scid</span><span class="sxs-lookup"><span data-stu-id="1ac09-115">scid</span></span>| <span data-ttu-id="1ac09-116">GUID</span><span class="sxs-lookup"><span data-stu-id="1ac09-116">GUID</span></span>| <span data-ttu-id="1ac09-117">サービス構成の識別子 (SCID)。</span><span class="sxs-lookup"><span data-stu-id="1ac09-117">Service configuration identifer (SCID).</span></span> <span data-ttu-id="1ac09-118">パート 1 セッションの id。</span><span class="sxs-lookup"><span data-stu-id="1ac09-118">Part 1 of the session ID.</span></span>|
| <span data-ttu-id="1ac09-119">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="1ac09-119">sessionTemplateName</span></span>| <span data-ttu-id="1ac09-120">string</span><span class="sxs-lookup"><span data-stu-id="1ac09-120">string</span></span>| <span data-ttu-id="1ac09-121">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="1ac09-121">Name of the current instance of the session template.</span></span> <span data-ttu-id="1ac09-122">パート 2、セッションの id。</span><span class="sxs-lookup"><span data-stu-id="1ac09-122">Part 2 of the session ID.</span></span> |

<a id="ID4E5"></a>


## <a name="http-status-codes"></a><span data-ttu-id="1ac09-123">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="1ac09-123">HTTP status codes</span></span>
<span data-ttu-id="1ac09-124">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="1ac09-124">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EFB"></a>


## <a name="request-body"></a><span data-ttu-id="1ac09-125">要求本文</span><span class="sxs-lookup"><span data-stu-id="1ac09-125">Request body</span></span>

<span data-ttu-id="1ac09-126">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="1ac09-126">No objects are sent in the body of this request.</span></span>

<a id="ID4EQB"></a>


## <a name="response-body"></a><span data-ttu-id="1ac09-127">応答本文</span><span class="sxs-lookup"><span data-stu-id="1ac09-127">Response body</span></span>


```cpp
{
    "results": [ {
            "xuid": "9876",    // If the session was found from a xuid, that xuid.
            "startTime": "2009-06-15T13:45:30.0900000Z",
            "sessionRef": {
                "scid": "foo",
                "templateName": "bar",
                "name": "session-seven"
            },
            "accepted": 4,    // Approximate number of non-reserved members.
            "status": "active",    // or "reserved" or "inactive". This is the state of the user in the session, not the session itself. Only present if the session was found using a xuid.
            "visibility": "open",    // or "private", "visible", or "full"
            "joinRestriction": "local",    // or "followed". Only present if 'visibility' is "open" or "full" and the session has a join restriction.
            "myTurn": true,    // Not present is the same as 'false'. Only present if the session was found using a xuid.
            "keywords": [ "one", "two" ]
        }
    ]
}

```


<a id="ID4EZB"></a>


## <a name="see-also"></a><span data-ttu-id="1ac09-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="1ac09-128">See also</span></span>

<a id="ID4E2B"></a>


##### <a name="parent"></a><span data-ttu-id="1ac09-129">Parent</span><span class="sxs-lookup"><span data-stu-id="1ac09-129">Parent</span></span>

[<span data-ttu-id="1ac09-130">/serviceconfigs/{scid}/sessiontemplates</span><span class="sxs-lookup"><span data-stu-id="1ac09-130">/serviceconfigs/{scid}/sessiontemplates</span></span>](uri-serviceconfigsscidsessiontemplates.md)
