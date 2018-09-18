---
title: DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})
assetID: 39c921d1-a166-74b9-fcbc-ea3c0c58cc40
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservernamedelete.html
author: KevinAsgari
description: " DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 12feca7761faa441023f2f242903d4fec2f0284d
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4016395"
---
# <a name="delete-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameserversserver-name"></a><span data-ttu-id="241a8-104">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})</span><span class="sxs-lookup"><span data-stu-id="241a8-104">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})</span></span>
<span data-ttu-id="241a8-105">指定されたサーバーは、セッションから削除します。</span><span class="sxs-lookup"><span data-stu-id="241a8-105">Removes the specified server from a session.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="241a8-106">この URI メソッドには、X Xbl コントラクト バージョンのヘッダーの要素が必要です: 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="241a8-106">This URI method requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="241a8-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="241a8-107">URI parameters</span></span>](#ID4ET)
  * [<span data-ttu-id="241a8-108">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="241a8-108">HTTP status codes</span></span>](#ID4E5)
  * [<span data-ttu-id="241a8-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="241a8-109">Request body</span></span>](#ID4EFB)
  * [<span data-ttu-id="241a8-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="241a8-110">Response body</span></span>](#ID4EOB)

<a id="ID4ET"></a>


## <a name="uri-parameters"></a><span data-ttu-id="241a8-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="241a8-111">URI parameters</span></span>

| <span data-ttu-id="241a8-112">パラメーター</span><span class="sxs-lookup"><span data-stu-id="241a8-112">Parameter</span></span>| <span data-ttu-id="241a8-113">型</span><span class="sxs-lookup"><span data-stu-id="241a8-113">Type</span></span>| <span data-ttu-id="241a8-114">説明</span><span class="sxs-lookup"><span data-stu-id="241a8-114">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="241a8-115">scid</span><span class="sxs-lookup"><span data-stu-id="241a8-115">scid</span></span>| <span data-ttu-id="241a8-116">GUID</span><span class="sxs-lookup"><span data-stu-id="241a8-116">GUID</span></span>| <span data-ttu-id="241a8-117">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="241a8-117">Service configuration identifier (SCID).</span></span> <span data-ttu-id="241a8-118">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="241a8-118">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="241a8-119">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="241a8-119">sessionTemplateName</span></span>| <span data-ttu-id="241a8-120">string</span><span class="sxs-lookup"><span data-stu-id="241a8-120">string</span></span>| <span data-ttu-id="241a8-121">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="241a8-121">Name of the current instance of the session template.</span></span> <span data-ttu-id="241a8-122">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="241a8-122">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="241a8-123">セッション名</span><span class="sxs-lookup"><span data-stu-id="241a8-123">sessionName</span></span>| <span data-ttu-id="241a8-124">GUID</span><span class="sxs-lookup"><span data-stu-id="241a8-124">GUID</span></span>| <span data-ttu-id="241a8-125">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="241a8-125">Unique ID of the session.</span></span> <span data-ttu-id="241a8-126">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="241a8-126">Part 3 of the session identifier.</span></span>|

<a id="ID4E5"></a>


## <a name="http-status-codes"></a><span data-ttu-id="241a8-127">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="241a8-127">HTTP status codes</span></span>
<span data-ttu-id="241a8-128">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="241a8-128">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EFB"></a>


## <a name="request-body"></a><span data-ttu-id="241a8-129">要求本文</span><span class="sxs-lookup"><span data-stu-id="241a8-129">Request body</span></span>
<span data-ttu-id="241a8-130">[MultiplayerSessionRequest (JSON)](../../json/json-multiplayersessionrequest.md)の要求の構造を参照してください。</span><span class="sxs-lookup"><span data-stu-id="241a8-130">See the request structure in [MultiplayerSessionRequest (JSON)](../../json/json-multiplayersessionrequest.md).</span></span>  
<a id="ID4EOB"></a>


## <a name="response-body"></a><span data-ttu-id="241a8-131">応答本文</span><span class="sxs-lookup"><span data-stu-id="241a8-131">Response body</span></span>
<span data-ttu-id="241a8-132">[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)の応答構造を参照してください。</span><span class="sxs-lookup"><span data-stu-id="241a8-132">See the response structure in [MultiplayerSession (JSON)](../../json/json-multiplayersession.md).</span></span>  
<a id="ID4E1B"></a>


## <a name="see-also"></a><span data-ttu-id="241a8-133">関連項目</span><span class="sxs-lookup"><span data-stu-id="241a8-133">See also</span></span>

<a id="ID4E3B"></a>


##### <a name="parent"></a><span data-ttu-id="241a8-134">Parent</span><span class="sxs-lookup"><span data-stu-id="241a8-134">Parent</span></span>

[<span data-ttu-id="241a8-135">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}</span><span class="sxs-lookup"><span data-stu-id="241a8-135">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservername.md)
