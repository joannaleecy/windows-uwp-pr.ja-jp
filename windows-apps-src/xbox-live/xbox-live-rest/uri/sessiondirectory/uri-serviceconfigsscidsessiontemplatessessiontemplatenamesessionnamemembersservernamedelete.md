---
title: DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})
assetID: 39c921d1-a166-74b9-fcbc-ea3c0c58cc40
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservernamedelete.html
description: " DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 65da52284d49d4d9384685d073f13bd93b10a30b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658317"
---
# <a name="delete-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameserversserver-name"></a><span data-ttu-id="94b64-104">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})</span><span class="sxs-lookup"><span data-stu-id="94b64-104">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})</span></span>
<span data-ttu-id="94b64-105">セッションから、指定したサーバーを削除します。</span><span class="sxs-lookup"><span data-stu-id="94b64-105">Removes the specified server from a session.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="94b64-106">この URI メソッドでは、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。</span><span class="sxs-lookup"><span data-stu-id="94b64-106">This URI method requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="94b64-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="94b64-107">URI parameters</span></span>](#ID4ET)
  * [<span data-ttu-id="94b64-108">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="94b64-108">HTTP status codes</span></span>](#ID4E5)
  * [<span data-ttu-id="94b64-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="94b64-109">Request body</span></span>](#ID4EFB)
  * [<span data-ttu-id="94b64-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="94b64-110">Response body</span></span>](#ID4EOB)

<a id="ID4ET"></a>


## <a name="uri-parameters"></a><span data-ttu-id="94b64-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="94b64-111">URI parameters</span></span>

| <span data-ttu-id="94b64-112">パラメーター</span><span class="sxs-lookup"><span data-stu-id="94b64-112">Parameter</span></span>| <span data-ttu-id="94b64-113">種類</span><span class="sxs-lookup"><span data-stu-id="94b64-113">Type</span></span>| <span data-ttu-id="94b64-114">説明</span><span class="sxs-lookup"><span data-stu-id="94b64-114">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="94b64-115">scid</span><span class="sxs-lookup"><span data-stu-id="94b64-115">scid</span></span>| <span data-ttu-id="94b64-116">GUID</span><span class="sxs-lookup"><span data-stu-id="94b64-116">GUID</span></span>| <span data-ttu-id="94b64-117">サービス構成の識別子 (SCID) です。</span><span class="sxs-lookup"><span data-stu-id="94b64-117">Service configuration identifier (SCID).</span></span> <span data-ttu-id="94b64-118">パート 1 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="94b64-118">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="94b64-119">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="94b64-119">sessionTemplateName</span></span>| <span data-ttu-id="94b64-120">string</span><span class="sxs-lookup"><span data-stu-id="94b64-120">string</span></span>| <span data-ttu-id="94b64-121">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="94b64-121">Name of the current instance of the session template.</span></span> <span data-ttu-id="94b64-122">パート 2 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="94b64-122">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="94b64-123">セッション名</span><span class="sxs-lookup"><span data-stu-id="94b64-123">sessionName</span></span>| <span data-ttu-id="94b64-124">GUID</span><span class="sxs-lookup"><span data-stu-id="94b64-124">GUID</span></span>| <span data-ttu-id="94b64-125">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="94b64-125">Unique ID of the session.</span></span> <span data-ttu-id="94b64-126">パート 3 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="94b64-126">Part 3 of the session identifier.</span></span>|

<a id="ID4E5"></a>


## <a name="http-status-codes"></a><span data-ttu-id="94b64-127">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="94b64-127">HTTP status codes</span></span>
<span data-ttu-id="94b64-128">MPSD に適用される、サービスは、HTTP 状態コードを返します。</span><span class="sxs-lookup"><span data-stu-id="94b64-128">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EFB"></a>


## <a name="request-body"></a><span data-ttu-id="94b64-129">要求本文</span><span class="sxs-lookup"><span data-stu-id="94b64-129">Request body</span></span>
<span data-ttu-id="94b64-130">要求の構造を参照してください。 [MultiplayerSessionRequest (JSON)](../../json/json-multiplayersessionrequest.md)します。</span><span class="sxs-lookup"><span data-stu-id="94b64-130">See the request structure in [MultiplayerSessionRequest (JSON)](../../json/json-multiplayersessionrequest.md).</span></span>  
<a id="ID4EOB"></a>


## <a name="response-body"></a><span data-ttu-id="94b64-131">応答本文</span><span class="sxs-lookup"><span data-stu-id="94b64-131">Response body</span></span>
<span data-ttu-id="94b64-132">応答の構造で表示[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)します。</span><span class="sxs-lookup"><span data-stu-id="94b64-132">See the response structure in [MultiplayerSession (JSON)](../../json/json-multiplayersession.md).</span></span>  
<a id="ID4E1B"></a>


## <a name="see-also"></a><span data-ttu-id="94b64-133">関連項目</span><span class="sxs-lookup"><span data-stu-id="94b64-133">See also</span></span>

<a id="ID4E3B"></a>


##### <a name="parent"></a><span data-ttu-id="94b64-134">Parent</span><span class="sxs-lookup"><span data-stu-id="94b64-134">Parent</span></span>

[<span data-ttu-id="94b64-135">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}</span><span class="sxs-lookup"><span data-stu-id="94b64-135">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservername.md)
