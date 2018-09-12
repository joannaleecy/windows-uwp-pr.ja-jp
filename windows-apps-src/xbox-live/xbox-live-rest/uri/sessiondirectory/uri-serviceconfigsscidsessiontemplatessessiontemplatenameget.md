---
title: (/Serviceconfigs/sessiontemplates/{sessionTemplateName}) を取得します。
assetID: 81139619-dc27-1601-30ba-08f6c45aaaca
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenameget.html
author: KevinAsgari
description: " (/Serviceconfigs/sessiontemplates/{sessionTemplateName}) を取得します。"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: eaa7314b2cb2c8459f4bd2aae78794685c277c70
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881689"
---
# <a name="get-serviceconfigsscidsessiontemplatessessiontemplatename"></a><span data-ttu-id="dc201-104">(/Serviceconfigs/sessiontemplates/{sessionTemplateName}) を取得します。</span><span class="sxs-lookup"><span data-stu-id="dc201-104">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName})</span></span>
<span data-ttu-id="dc201-105">一連のセッション テンプレート名を取得します。</span><span class="sxs-lookup"><span data-stu-id="dc201-105">Retrieves a set of session template names.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="dc201-106">この URI メソッドには、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="dc201-106">This URI method requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="dc201-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="dc201-107">URI parameters</span></span>](#ID4ET)
  * [<span data-ttu-id="dc201-108">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="dc201-108">HTTP status codes</span></span>](#ID4E5)
  * [<span data-ttu-id="dc201-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="dc201-109">Request body</span></span>](#ID4EFB)
  * [<span data-ttu-id="dc201-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="dc201-110">Response body</span></span>](#ID4EQB)

<a id="ID4ET"></a>


## <a name="uri-parameters"></a><span data-ttu-id="dc201-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="dc201-111">URI parameters</span></span>

| <span data-ttu-id="dc201-112">パラメーター</span><span class="sxs-lookup"><span data-stu-id="dc201-112">Parameter</span></span>| <span data-ttu-id="dc201-113">型</span><span class="sxs-lookup"><span data-stu-id="dc201-113">Type</span></span>| <span data-ttu-id="dc201-114">説明</span><span class="sxs-lookup"><span data-stu-id="dc201-114">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="dc201-115">scid</span><span class="sxs-lookup"><span data-stu-id="dc201-115">scid</span></span>| <span data-ttu-id="dc201-116">GUID</span><span class="sxs-lookup"><span data-stu-id="dc201-116">GUID</span></span>| <span data-ttu-id="dc201-117">サービス構成の識別子 (SCID)。</span><span class="sxs-lookup"><span data-stu-id="dc201-117">Service configuration identifer (SCID).</span></span> <span data-ttu-id="dc201-118">パート 1 セッションの id。</span><span class="sxs-lookup"><span data-stu-id="dc201-118">Part 1 of the session ID.</span></span>|
| <span data-ttu-id="dc201-119">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="dc201-119">sessionTemplateName</span></span>| <span data-ttu-id="dc201-120">string</span><span class="sxs-lookup"><span data-stu-id="dc201-120">string</span></span>| <span data-ttu-id="dc201-121">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="dc201-121">Name of the current instance of the session template.</span></span> <span data-ttu-id="dc201-122">パート 2、セッションの id。</span><span class="sxs-lookup"><span data-stu-id="dc201-122">Part 2 of the session ID.</span></span> |

<a id="ID4E5"></a>


## <a name="http-status-codes"></a><span data-ttu-id="dc201-123">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="dc201-123">HTTP status codes</span></span>
<span data-ttu-id="dc201-124">サービスは、MPSD に適用される、HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="dc201-124">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EFB"></a>


## <a name="request-body"></a><span data-ttu-id="dc201-125">要求本文</span><span class="sxs-lookup"><span data-stu-id="dc201-125">Request body</span></span>

<span data-ttu-id="dc201-126">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="dc201-126">No objects are sent in the body of this request.</span></span>

<a id="ID4EQB"></a>


## <a name="response-body"></a><span data-ttu-id="dc201-127">応答本文</span><span class="sxs-lookup"><span data-stu-id="dc201-127">Response body</span></span>


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


## <a name="see-also"></a><span data-ttu-id="dc201-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="dc201-128">See also</span></span>

<a id="ID4E2B"></a>


##### <a name="parent"></a><span data-ttu-id="dc201-129">Parent</span><span class="sxs-lookup"><span data-stu-id="dc201-129">Parent</span></span>

[<span data-ttu-id="dc201-130">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}</span><span class="sxs-lookup"><span data-stu-id="dc201-130">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatename.md)
