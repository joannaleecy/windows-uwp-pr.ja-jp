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
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8921348"
---
# <a name="get-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname"></a><span data-ttu-id="92770-104">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span><span class="sxs-lookup"><span data-stu-id="92770-104">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span></span>
<span data-ttu-id="92770-105">セッション オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="92770-105">Gets a session object.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="92770-106">この URI メソッドには、X Xbl コントラクト バージョンのヘッダーの要素が必要があります: 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="92770-106">This URI method requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="92770-107">注釈</span><span class="sxs-lookup"><span data-stu-id="92770-107">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="92770-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="92770-108">URI parameters</span></span>](#ID4EMB)
  * [<span data-ttu-id="92770-109">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="92770-109">HTTP status codes</span></span>](#ID4EZB)
  * [<span data-ttu-id="92770-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="92770-110">Request body</span></span>](#ID4E6B)
  * [<span data-ttu-id="92770-111">応答本文</span><span class="sxs-lookup"><span data-stu-id="92770-111">Response body</span></span>](#ID4EKC)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="92770-112">注釈</span><span class="sxs-lookup"><span data-stu-id="92770-112">Remarks</span></span>

<span data-ttu-id="92770-113">この HTTP/REST メソッドでは、指定した名前のセッション ドキュメントを読み取り、セッションを取得します。</span><span class="sxs-lookup"><span data-stu-id="92770-113">This HTTP/REST method reads a session document for the specified name and retrieves the session.</span></span> <span data-ttu-id="92770-114">成功した場合、そのすべての属性を使用して、セッション オブジェクトがサーバーから取得を返します。</span><span class="sxs-lookup"><span data-stu-id="92770-114">On success, it returns the session object, with all its attributes, obtained from the server.</span></span> <span data-ttu-id="92770-115">このメソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionAsync**でラップすることができます。</span><span class="sxs-lookup"><span data-stu-id="92770-115">This method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionAsync**.</span></span> <span data-ttu-id="92770-116">直接 GET メソッドのパラメーターでは指定されている**MultiplayerSessionReference**オブジェクトで、セッションでは、 **GetCurrentSessionAsync**の*sessionReference*パラメーターで渡されたは似ています。</span><span class="sxs-lookup"><span data-stu-id="92770-116">The parameters for the GET method directly parallel those specified in the **MultiplayerSessionReference** object for the session, passed in the *sessionReference* parameter of **GetCurrentSessionAsync**.</span></span>

<span data-ttu-id="92770-117">GET メソッドのワイヤ形式は、次に示します。</span><span class="sxs-lookup"><span data-stu-id="92770-117">The wire format for the GET method is shown below.</span></span>

```cpp
GET /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/00000000-0000-0000-0000-000000000001 HTTP/1.1
      Content-Type: application/json

```



<a id="ID4EMB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="92770-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="92770-118">URI parameters</span></span>

| <span data-ttu-id="92770-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="92770-119">Parameter</span></span>| <span data-ttu-id="92770-120">型</span><span class="sxs-lookup"><span data-stu-id="92770-120">Type</span></span>| <span data-ttu-id="92770-121">説明</span><span class="sxs-lookup"><span data-stu-id="92770-121">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="92770-122">scid</span><span class="sxs-lookup"><span data-stu-id="92770-122">scid</span></span>| <span data-ttu-id="92770-123">GUID</span><span class="sxs-lookup"><span data-stu-id="92770-123">GUID</span></span>| <span data-ttu-id="92770-124">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="92770-124">Service configuration identifier (SCID).</span></span> <span data-ttu-id="92770-125">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="92770-125">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="92770-126">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="92770-126">sessionTemplateName</span></span>| <span data-ttu-id="92770-127">string</span><span class="sxs-lookup"><span data-stu-id="92770-127">string</span></span>| <span data-ttu-id="92770-128">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="92770-128">Name of the current instance of the session template.</span></span> <span data-ttu-id="92770-129">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="92770-129">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="92770-130">セッション名</span><span class="sxs-lookup"><span data-stu-id="92770-130">sessionName</span></span>| <span data-ttu-id="92770-131">GUID</span><span class="sxs-lookup"><span data-stu-id="92770-131">GUID</span></span>| <span data-ttu-id="92770-132">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="92770-132">Unique ID of the session.</span></span> <span data-ttu-id="92770-133">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="92770-133">Part 3 of the session identifier.</span></span>|

<a id="ID4EZB"></a>


## <a name="http-status-codes"></a><span data-ttu-id="92770-134">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="92770-134">HTTP status codes</span></span>
<span data-ttu-id="92770-135">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="92770-135">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4E6B"></a>


## <a name="request-body"></a><span data-ttu-id="92770-136">要求本文</span><span class="sxs-lookup"><span data-stu-id="92770-136">Request body</span></span>

<span data-ttu-id="92770-137">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="92770-137">No objects are sent in the body of this request.</span></span>

<a id="ID4EKC"></a>


## <a name="response-body"></a><span data-ttu-id="92770-138">応答本文</span><span class="sxs-lookup"><span data-stu-id="92770-138">Response body</span></span>
<span data-ttu-id="92770-139">[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)で応答構造を参照してください。</span><span class="sxs-lookup"><span data-stu-id="92770-139">See the response structure in [MultiplayerSession (JSON)](../../json/json-multiplayersession.md).</span></span>  
<a id="ID4ETC"></a>


## <a name="see-also"></a><span data-ttu-id="92770-140">関連項目</span><span class="sxs-lookup"><span data-stu-id="92770-140">See also</span></span>

<a id="ID4EVC"></a>


##### <a name="parent"></a><span data-ttu-id="92770-141">Parent</span><span class="sxs-lookup"><span data-stu-id="92770-141">Parent</span></span>

[<span data-ttu-id="92770-142">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span><span class="sxs-lookup"><span data-stu-id="92770-142">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionname.md)
