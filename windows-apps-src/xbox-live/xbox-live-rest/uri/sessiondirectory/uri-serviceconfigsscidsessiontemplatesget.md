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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658087"
---
# <a name="get-serviceconfigsscidsessiontemplates"></a><span data-ttu-id="bc154-104">GET (/serviceconfigs/{scid}/sessiontemplates)</span><span class="sxs-lookup"><span data-stu-id="bc154-104">GET (/serviceconfigs/{scid}/sessiontemplates)</span></span>
<span data-ttu-id="bc154-105">MPSD セッション テンプレートのセットを取得します。</span><span class="sxs-lookup"><span data-stu-id="bc154-105">Retrieves a set of MPSD session templates.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="bc154-106">この URI メソッドでは、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。</span><span class="sxs-lookup"><span data-stu-id="bc154-106">This URI method requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="bc154-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bc154-107">URI parameters</span></span>](#ID4ET)
  * [<span data-ttu-id="bc154-108">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="bc154-108">HTTP status codes</span></span>](#ID4E5)
  * [<span data-ttu-id="bc154-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="bc154-109">Request body</span></span>](#ID4EFB)
  * [<span data-ttu-id="bc154-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="bc154-110">Response body</span></span>](#ID4EQB)

<a id="ID4ET"></a>


## <a name="uri-parameters"></a><span data-ttu-id="bc154-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bc154-111">URI parameters</span></span>

| <span data-ttu-id="bc154-112">パラメーター</span><span class="sxs-lookup"><span data-stu-id="bc154-112">Parameter</span></span>| <span data-ttu-id="bc154-113">種類</span><span class="sxs-lookup"><span data-stu-id="bc154-113">Type</span></span>| <span data-ttu-id="bc154-114">説明</span><span class="sxs-lookup"><span data-stu-id="bc154-114">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="bc154-115">scid</span><span class="sxs-lookup"><span data-stu-id="bc154-115">scid</span></span>| <span data-ttu-id="bc154-116">GUID</span><span class="sxs-lookup"><span data-stu-id="bc154-116">GUID</span></span>| <span data-ttu-id="bc154-117">サービス構成の識別子 (SCID)。</span><span class="sxs-lookup"><span data-stu-id="bc154-117">Service configuration identifer (SCID).</span></span> <span data-ttu-id="bc154-118">セッションの第 1 部 id。</span><span class="sxs-lookup"><span data-stu-id="bc154-118">Part 1 of the session ID.</span></span>|
| <span data-ttu-id="bc154-119">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="bc154-119">sessionTemplateName</span></span>| <span data-ttu-id="bc154-120">string</span><span class="sxs-lookup"><span data-stu-id="bc154-120">string</span></span>| <span data-ttu-id="bc154-121">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="bc154-121">Name of the current instance of the session template.</span></span> <span data-ttu-id="bc154-122">セッションの第 2 部 id。</span><span class="sxs-lookup"><span data-stu-id="bc154-122">Part 2 of the session ID.</span></span> |

<a id="ID4E5"></a>


## <a name="http-status-codes"></a><span data-ttu-id="bc154-123">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="bc154-123">HTTP status codes</span></span>
<span data-ttu-id="bc154-124">MPSD に適用される、サービスは、HTTP 状態コードを返します。</span><span class="sxs-lookup"><span data-stu-id="bc154-124">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EFB"></a>


## <a name="request-body"></a><span data-ttu-id="bc154-125">要求本文</span><span class="sxs-lookup"><span data-stu-id="bc154-125">Request body</span></span>

<span data-ttu-id="bc154-126">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="bc154-126">No objects are sent in the body of this request.</span></span>

<a id="ID4EQB"></a>


## <a name="response-body"></a><span data-ttu-id="bc154-127">応答本文</span><span class="sxs-lookup"><span data-stu-id="bc154-127">Response body</span></span>


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


## <a name="see-also"></a><span data-ttu-id="bc154-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="bc154-128">See also</span></span>

<a id="ID4E2B"></a>


##### <a name="parent"></a><span data-ttu-id="bc154-129">Parent</span><span class="sxs-lookup"><span data-stu-id="bc154-129">Parent</span></span>

[<span data-ttu-id="bc154-130">/serviceconfigs/{scid}/sessiontemplates</span><span class="sxs-lookup"><span data-stu-id="bc154-130">/serviceconfigs/{scid}/sessiontemplates</span></span>](uri-serviceconfigsscidsessiontemplates.md)
