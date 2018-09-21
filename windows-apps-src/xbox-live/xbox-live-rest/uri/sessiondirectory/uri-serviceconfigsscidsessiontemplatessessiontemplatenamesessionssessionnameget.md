---
title: GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})
assetID: 6a4c4a13-c968-3271-cbc3-b742a8de98b3
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameget.html
author: KevinAsgari
description: " GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f1b1c9d15cc1bc06c14a44d395b478cdc536fd74
ms.sourcegitcommit: 5dda01da4702cbc49c799c750efe0e430b699502
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/21/2018
ms.locfileid: "4111107"
---
# <a name="get-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname"></a><span data-ttu-id="3e798-104">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span><span class="sxs-lookup"><span data-stu-id="3e798-104">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span></span>
<span data-ttu-id="3e798-105">セッション オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="3e798-105">Gets a session object.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="3e798-106">この URI メソッドには、X Xbl コントラクト バージョンのヘッダーの要素が必要です: 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="3e798-106">This URI method requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="3e798-107">注釈</span><span class="sxs-lookup"><span data-stu-id="3e798-107">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="3e798-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3e798-108">URI parameters</span></span>](#ID4EMB)
  * [<span data-ttu-id="3e798-109">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="3e798-109">HTTP status codes</span></span>](#ID4EZB)
  * [<span data-ttu-id="3e798-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="3e798-110">Request body</span></span>](#ID4E6B)
  * [<span data-ttu-id="3e798-111">応答本文</span><span class="sxs-lookup"><span data-stu-id="3e798-111">Response body</span></span>](#ID4EKC)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="3e798-112">注釈</span><span class="sxs-lookup"><span data-stu-id="3e798-112">Remarks</span></span>

<span data-ttu-id="3e798-113">この HTTP/REST メソッドは、指定した名前のセッション ドキュメントを読み込んで、セッションを取得します。</span><span class="sxs-lookup"><span data-stu-id="3e798-113">This HTTP/REST method reads a session document for the specified name and retrieves the session.</span></span> <span data-ttu-id="3e798-114">成功した場合、サーバーから取得したすべての属性と、セッション オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="3e798-114">On success, it returns the session object, with all its attributes, obtained from the server.</span></span> <span data-ttu-id="3e798-115">このメソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionAsync**でラップすることができます。</span><span class="sxs-lookup"><span data-stu-id="3e798-115">This method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionAsync**.</span></span> <span data-ttu-id="3e798-116">直接 GET メソッドのパラメーターでは指定されている**MultiplayerSessionReference**オブジェクトで、セッションの**GetCurrentSessionAsync**の*sessionReference*パラメーターで渡されたは似ています。</span><span class="sxs-lookup"><span data-stu-id="3e798-116">The parameters for the GET method directly parallel those specified in the **MultiplayerSessionReference** object for the session, passed in the *sessionReference* parameter of **GetCurrentSessionAsync**.</span></span>

<span data-ttu-id="3e798-117">GET メソッドのワイヤ形式は、次に示します。</span><span class="sxs-lookup"><span data-stu-id="3e798-117">The wire format for the GET method is shown below.</span></span>

```cpp
GET /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/00000000-0000-0000-0000-000000000001 HTTP/1.1
      Content-Type: application/json

```



<a id="ID4EMB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="3e798-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3e798-118">URI parameters</span></span>

| <span data-ttu-id="3e798-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3e798-119">Parameter</span></span>| <span data-ttu-id="3e798-120">型</span><span class="sxs-lookup"><span data-stu-id="3e798-120">Type</span></span>| <span data-ttu-id="3e798-121">説明</span><span class="sxs-lookup"><span data-stu-id="3e798-121">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="3e798-122">scid</span><span class="sxs-lookup"><span data-stu-id="3e798-122">scid</span></span>| <span data-ttu-id="3e798-123">GUID</span><span class="sxs-lookup"><span data-stu-id="3e798-123">GUID</span></span>| <span data-ttu-id="3e798-124">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="3e798-124">Service configuration identifier (SCID).</span></span> <span data-ttu-id="3e798-125">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="3e798-125">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="3e798-126">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="3e798-126">sessionTemplateName</span></span>| <span data-ttu-id="3e798-127">string</span><span class="sxs-lookup"><span data-stu-id="3e798-127">string</span></span>| <span data-ttu-id="3e798-128">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="3e798-128">Name of the current instance of the session template.</span></span> <span data-ttu-id="3e798-129">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="3e798-129">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="3e798-130">セッション名</span><span class="sxs-lookup"><span data-stu-id="3e798-130">sessionName</span></span>| <span data-ttu-id="3e798-131">GUID</span><span class="sxs-lookup"><span data-stu-id="3e798-131">GUID</span></span>| <span data-ttu-id="3e798-132">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="3e798-132">Unique ID of the session.</span></span> <span data-ttu-id="3e798-133">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="3e798-133">Part 3 of the session identifier.</span></span>|

<a id="ID4EZB"></a>


## <a name="http-status-codes"></a><span data-ttu-id="3e798-134">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="3e798-134">HTTP status codes</span></span>
<span data-ttu-id="3e798-135">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="3e798-135">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4E6B"></a>


## <a name="request-body"></a><span data-ttu-id="3e798-136">要求本文</span><span class="sxs-lookup"><span data-stu-id="3e798-136">Request body</span></span>

<span data-ttu-id="3e798-137">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="3e798-137">No objects are sent in the body of this request.</span></span>

<a id="ID4EKC"></a>


## <a name="response-body"></a><span data-ttu-id="3e798-138">応答本文</span><span class="sxs-lookup"><span data-stu-id="3e798-138">Response body</span></span>
<span data-ttu-id="3e798-139">[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)の応答構造を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3e798-139">See the response structure in [MultiplayerSession (JSON)](../../json/json-multiplayersession.md).</span></span>  
<a id="ID4ETC"></a>


## <a name="see-also"></a><span data-ttu-id="3e798-140">関連項目</span><span class="sxs-lookup"><span data-stu-id="3e798-140">See also</span></span>

<a id="ID4EVC"></a>


##### <a name="parent"></a><span data-ttu-id="3e798-141">Parent</span><span class="sxs-lookup"><span data-stu-id="3e798-141">Parent</span></span>

[<span data-ttu-id="3e798-142">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span><span class="sxs-lookup"><span data-stu-id="3e798-142">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.md)
