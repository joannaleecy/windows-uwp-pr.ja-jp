---
title: GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})
assetID: 6a4c4a13-c968-3271-cbc3-b742a8de98b3
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameget.html
description: " GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 21d534d7b55934d7174c925838ed88980acff609
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655067"
---
# <a name="get-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname"></a><span data-ttu-id="3bab3-104">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span><span class="sxs-lookup"><span data-stu-id="3bab3-104">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span></span>
<span data-ttu-id="3bab3-105">セッション オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="3bab3-105">Gets a session object.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="3bab3-106">この URI メソッドでは、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。</span><span class="sxs-lookup"><span data-stu-id="3bab3-106">This URI method requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="3bab3-107">注釈</span><span class="sxs-lookup"><span data-stu-id="3bab3-107">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="3bab3-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3bab3-108">URI parameters</span></span>](#ID4EMB)
  * [<span data-ttu-id="3bab3-109">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="3bab3-109">HTTP status codes</span></span>](#ID4EZB)
  * [<span data-ttu-id="3bab3-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="3bab3-110">Request body</span></span>](#ID4E6B)
  * [<span data-ttu-id="3bab3-111">応答本文</span><span class="sxs-lookup"><span data-stu-id="3bab3-111">Response body</span></span>](#ID4EKC)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="3bab3-112">注釈</span><span class="sxs-lookup"><span data-stu-id="3bab3-112">Remarks</span></span>

<span data-ttu-id="3bab3-113">この HTTP/REST メソッドは、指定した名前のセッションのドキュメントを読み取って、セッションを取得します。</span><span class="sxs-lookup"><span data-stu-id="3bab3-113">This HTTP/REST method reads a session document for the specified name and retrieves the session.</span></span> <span data-ttu-id="3bab3-114">成功した場合、サーバーから取得して、そのすべての属性を持つ、セッション オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="3bab3-114">On success, it returns the session object, with all its attributes, obtained from the server.</span></span> <span data-ttu-id="3bab3-115">このメソッドによってラップできる**Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionAsync**します。</span><span class="sxs-lookup"><span data-stu-id="3bab3-115">This method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionAsync**.</span></span> <span data-ttu-id="3bab3-116">GET メソッドのパラメーターで指定されている並列直接、 **MultiplayerSessionReference**で渡されたセッションのオブジェクト、 *sessionReference*パラメーターの**GetCurrentSessionAsync**します。</span><span class="sxs-lookup"><span data-stu-id="3bab3-116">The parameters for the GET method directly parallel those specified in the **MultiplayerSessionReference** object for the session, passed in the *sessionReference* parameter of **GetCurrentSessionAsync**.</span></span>

<span data-ttu-id="3bab3-117">GET メソッドのワイヤ形式は、以下に示します。</span><span class="sxs-lookup"><span data-stu-id="3bab3-117">The wire format for the GET method is shown below.</span></span>

```cpp
GET /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/00000000-0000-0000-0000-000000000001 HTTP/1.1
      Content-Type: application/json

```



<a id="ID4EMB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="3bab3-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3bab3-118">URI parameters</span></span>

| <span data-ttu-id="3bab3-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3bab3-119">Parameter</span></span>| <span data-ttu-id="3bab3-120">種類</span><span class="sxs-lookup"><span data-stu-id="3bab3-120">Type</span></span>| <span data-ttu-id="3bab3-121">説明</span><span class="sxs-lookup"><span data-stu-id="3bab3-121">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="3bab3-122">scid</span><span class="sxs-lookup"><span data-stu-id="3bab3-122">scid</span></span>| <span data-ttu-id="3bab3-123">GUID</span><span class="sxs-lookup"><span data-stu-id="3bab3-123">GUID</span></span>| <span data-ttu-id="3bab3-124">サービス構成の識別子 (SCID) です。</span><span class="sxs-lookup"><span data-stu-id="3bab3-124">Service configuration identifier (SCID).</span></span> <span data-ttu-id="3bab3-125">パート 1 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="3bab3-125">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="3bab3-126">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="3bab3-126">sessionTemplateName</span></span>| <span data-ttu-id="3bab3-127">string</span><span class="sxs-lookup"><span data-stu-id="3bab3-127">string</span></span>| <span data-ttu-id="3bab3-128">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="3bab3-128">Name of the current instance of the session template.</span></span> <span data-ttu-id="3bab3-129">パート 2 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="3bab3-129">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="3bab3-130">セッション名</span><span class="sxs-lookup"><span data-stu-id="3bab3-130">sessionName</span></span>| <span data-ttu-id="3bab3-131">GUID</span><span class="sxs-lookup"><span data-stu-id="3bab3-131">GUID</span></span>| <span data-ttu-id="3bab3-132">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="3bab3-132">Unique ID of the session.</span></span> <span data-ttu-id="3bab3-133">パート 3 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="3bab3-133">Part 3 of the session identifier.</span></span>|

<a id="ID4EZB"></a>


## <a name="http-status-codes"></a><span data-ttu-id="3bab3-134">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="3bab3-134">HTTP status codes</span></span>
<span data-ttu-id="3bab3-135">MPSD に適用される、サービスは、HTTP 状態コードを返します。</span><span class="sxs-lookup"><span data-stu-id="3bab3-135">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4E6B"></a>


## <a name="request-body"></a><span data-ttu-id="3bab3-136">要求本文</span><span class="sxs-lookup"><span data-stu-id="3bab3-136">Request body</span></span>

<span data-ttu-id="3bab3-137">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="3bab3-137">No objects are sent in the body of this request.</span></span>

<a id="ID4EKC"></a>


## <a name="response-body"></a><span data-ttu-id="3bab3-138">応答本文</span><span class="sxs-lookup"><span data-stu-id="3bab3-138">Response body</span></span>
<span data-ttu-id="3bab3-139">応答の構造で表示[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)します。</span><span class="sxs-lookup"><span data-stu-id="3bab3-139">See the response structure in [MultiplayerSession (JSON)](../../json/json-multiplayersession.md).</span></span>  
<a id="ID4ETC"></a>


## <a name="see-also"></a><span data-ttu-id="3bab3-140">関連項目</span><span class="sxs-lookup"><span data-stu-id="3bab3-140">See also</span></span>

<a id="ID4EVC"></a>


##### <a name="parent"></a><span data-ttu-id="3bab3-141">Parent</span><span class="sxs-lookup"><span data-stu-id="3bab3-141">Parent</span></span>

[<span data-ttu-id="3bab3-142">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span><span class="sxs-lookup"><span data-stu-id="3bab3-142">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.md)
