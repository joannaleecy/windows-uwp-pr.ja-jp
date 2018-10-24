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
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5483521"
---
# <a name="get-serviceconfigsscidsessiontemplates"></a><span data-ttu-id="de586-104">GET (/serviceconfigs/{scid}/sessiontemplates)</span><span class="sxs-lookup"><span data-stu-id="de586-104">GET (/serviceconfigs/{scid}/sessiontemplates)</span></span>
<span data-ttu-id="de586-105">MPSD セッション テンプレートのセットを取得します。</span><span class="sxs-lookup"><span data-stu-id="de586-105">Retrieves a set of MPSD session templates.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="de586-106">この URI メソッドには、X の Xbl の契約のバージョンのヘッダーの要素が必要です: 104/105 またはすべての要求を後で。</span><span class="sxs-lookup"><span data-stu-id="de586-106">This URI method requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="de586-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="de586-107">URI parameters</span></span>](#ID4ET)
  * [<span data-ttu-id="de586-108">HTTP ステータス ・ コード</span><span class="sxs-lookup"><span data-stu-id="de586-108">HTTP status codes</span></span>](#ID4E5)
  * [<span data-ttu-id="de586-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="de586-109">Request body</span></span>](#ID4EFB)
  * [<span data-ttu-id="de586-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="de586-110">Response body</span></span>](#ID4EQB)

<a id="ID4ET"></a>


## <a name="uri-parameters"></a><span data-ttu-id="de586-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="de586-111">URI parameters</span></span>

| <span data-ttu-id="de586-112">パラメーター</span><span class="sxs-lookup"><span data-stu-id="de586-112">Parameter</span></span>| <span data-ttu-id="de586-113">型</span><span class="sxs-lookup"><span data-stu-id="de586-113">Type</span></span>| <span data-ttu-id="de586-114">説明</span><span class="sxs-lookup"><span data-stu-id="de586-114">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="de586-115">scid</span><span class="sxs-lookup"><span data-stu-id="de586-115">scid</span></span>| <span data-ttu-id="de586-116">GUID</span><span class="sxs-lookup"><span data-stu-id="de586-116">GUID</span></span>| <span data-ttu-id="de586-117">サービス構成の識別子 (SCID)。</span><span class="sxs-lookup"><span data-stu-id="de586-117">Service configuration identifer (SCID).</span></span> <span data-ttu-id="de586-118">パート 1 のセッションの id。</span><span class="sxs-lookup"><span data-stu-id="de586-118">Part 1 of the session ID.</span></span>|
| <span data-ttu-id="de586-119">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="de586-119">sessionTemplateName</span></span>| <span data-ttu-id="de586-120">string</span><span class="sxs-lookup"><span data-stu-id="de586-120">string</span></span>| <span data-ttu-id="de586-121">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="de586-121">Name of the current instance of the session template.</span></span> <span data-ttu-id="de586-122">パート 2 セッションの id。</span><span class="sxs-lookup"><span data-stu-id="de586-122">Part 2 of the session ID.</span></span> |

<a id="ID4E5"></a>


## <a name="http-status-codes"></a><span data-ttu-id="de586-123">HTTP ステータス ・ コード</span><span class="sxs-lookup"><span data-stu-id="de586-123">HTTP status codes</span></span>
<span data-ttu-id="de586-124">MPSD に適用されるサービスは HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="de586-124">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EFB"></a>


## <a name="request-body"></a><span data-ttu-id="de586-125">要求本文</span><span class="sxs-lookup"><span data-stu-id="de586-125">Request body</span></span>

<span data-ttu-id="de586-126">オブジェクトはこの要求の本文に送信されません。</span><span class="sxs-lookup"><span data-stu-id="de586-126">No objects are sent in the body of this request.</span></span>

<a id="ID4EQB"></a>


## <a name="response-body"></a><span data-ttu-id="de586-127">応答本文</span><span class="sxs-lookup"><span data-stu-id="de586-127">Response body</span></span>


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


## <a name="see-also"></a><span data-ttu-id="de586-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="de586-128">See also</span></span>

<a id="ID4E2B"></a>


##### <a name="parent"></a><span data-ttu-id="de586-129">Parent</span><span class="sxs-lookup"><span data-stu-id="de586-129">Parent</span></span>

[<span data-ttu-id="de586-130">/serviceconfigs/{scid}/sessiontemplates</span><span class="sxs-lookup"><span data-stu-id="de586-130">/serviceconfigs/{scid}/sessiontemplates</span></span>](uri-serviceconfigsscidsessiontemplates.md)
