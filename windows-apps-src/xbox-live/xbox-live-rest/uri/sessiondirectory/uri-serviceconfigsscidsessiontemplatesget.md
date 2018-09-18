---
title: GET (/serviceconfigs/{scid}/sessiontemplates)
assetID: 5172c7be-371b-f0b1-d1d0-f0981eb2bfa7
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatesget.html
author: KevinAsgari
description: " GET (/serviceconfigs/{scid}/sessiontemplates)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ebcc685b2828a5e7639b9a117fe4aed848b60b71
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4023001"
---
# <a name="get-serviceconfigsscidsessiontemplates"></a><span data-ttu-id="06657-104">GET (/serviceconfigs/{scid}/sessiontemplates)</span><span class="sxs-lookup"><span data-stu-id="06657-104">GET (/serviceconfigs/{scid}/sessiontemplates)</span></span>
<span data-ttu-id="06657-105">MPSD セッション テンプレートのセットを取得します。</span><span class="sxs-lookup"><span data-stu-id="06657-105">Retrieves a set of MPSD session templates.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="06657-106">この URI メソッドには、X Xbl コントラクト バージョンのヘッダーの要素が必要です: 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="06657-106">This URI method requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="06657-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="06657-107">URI parameters</span></span>](#ID4ET)
  * [<span data-ttu-id="06657-108">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="06657-108">HTTP status codes</span></span>](#ID4E5)
  * [<span data-ttu-id="06657-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="06657-109">Request body</span></span>](#ID4EFB)
  * [<span data-ttu-id="06657-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="06657-110">Response body</span></span>](#ID4EQB)

<a id="ID4ET"></a>


## <a name="uri-parameters"></a><span data-ttu-id="06657-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="06657-111">URI parameters</span></span>

| <span data-ttu-id="06657-112">パラメーター</span><span class="sxs-lookup"><span data-stu-id="06657-112">Parameter</span></span>| <span data-ttu-id="06657-113">型</span><span class="sxs-lookup"><span data-stu-id="06657-113">Type</span></span>| <span data-ttu-id="06657-114">説明</span><span class="sxs-lookup"><span data-stu-id="06657-114">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="06657-115">scid</span><span class="sxs-lookup"><span data-stu-id="06657-115">scid</span></span>| <span data-ttu-id="06657-116">GUID</span><span class="sxs-lookup"><span data-stu-id="06657-116">GUID</span></span>| <span data-ttu-id="06657-117">サービス構成の識別子 (SCID)。</span><span class="sxs-lookup"><span data-stu-id="06657-117">Service configuration identifer (SCID).</span></span> <span data-ttu-id="06657-118">パート 1 セッションの id。</span><span class="sxs-lookup"><span data-stu-id="06657-118">Part 1 of the session ID.</span></span>|
| <span data-ttu-id="06657-119">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="06657-119">sessionTemplateName</span></span>| <span data-ttu-id="06657-120">string</span><span class="sxs-lookup"><span data-stu-id="06657-120">string</span></span>| <span data-ttu-id="06657-121">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="06657-121">Name of the current instance of the session template.</span></span> <span data-ttu-id="06657-122">パート 2 セッションの id。</span><span class="sxs-lookup"><span data-stu-id="06657-122">Part 2 of the session ID.</span></span> |

<a id="ID4E5"></a>


## <a name="http-status-codes"></a><span data-ttu-id="06657-123">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="06657-123">HTTP status codes</span></span>
<span data-ttu-id="06657-124">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="06657-124">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EFB"></a>


## <a name="request-body"></a><span data-ttu-id="06657-125">要求本文</span><span class="sxs-lookup"><span data-stu-id="06657-125">Request body</span></span>

<span data-ttu-id="06657-126">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="06657-126">No objects are sent in the body of this request.</span></span>

<a id="ID4EQB"></a>


## <a name="response-body"></a><span data-ttu-id="06657-127">応答本文</span><span class="sxs-lookup"><span data-stu-id="06657-127">Response body</span></span>


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


## <a name="see-also"></a><span data-ttu-id="06657-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="06657-128">See also</span></span>

<a id="ID4E2B"></a>


##### <a name="parent"></a><span data-ttu-id="06657-129">Parent</span><span class="sxs-lookup"><span data-stu-id="06657-129">Parent</span></span>

[<span data-ttu-id="06657-130">/serviceconfigs/{scid}/sessiontemplates</span><span class="sxs-lookup"><span data-stu-id="06657-130">/serviceconfigs/{scid}/sessiontemplates</span></span>](uri-serviceconfigsscidsessiontemplates.md)
