---
title: DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index})
assetID: 00aa2f3d-69a6-6d68-e99b-aad4b102aba3
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersindexdelete.html
description: " DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fbe1942d32ee8facc83f1c723cee2aedaa1078d2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618227"
---
# <a name="delete-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersindex"></a><span data-ttu-id="781b9-104">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index})</span><span class="sxs-lookup"><span data-stu-id="781b9-104">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index})</span></span>
<span data-ttu-id="781b9-105">セッションから、指定したメンバーを削除します。</span><span class="sxs-lookup"><span data-stu-id="781b9-105">Removes the specified members from a session.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="781b9-106">この URI メソッドでは、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。</span><span class="sxs-lookup"><span data-stu-id="781b9-106">This URI method requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="781b9-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="781b9-107">URI parameters</span></span>](#ID4ET)
  * [<span data-ttu-id="781b9-108">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="781b9-108">HTTP status codes</span></span>](#ID4E5)
  * [<span data-ttu-id="781b9-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="781b9-109">Request body</span></span>](#ID4EFB)
  * [<span data-ttu-id="781b9-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="781b9-110">Response body</span></span>](#ID4EOB)

<a id="ID4ET"></a>


## <a name="uri-parameters"></a><span data-ttu-id="781b9-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="781b9-111">URI parameters</span></span>

| <span data-ttu-id="781b9-112">パラメーター</span><span class="sxs-lookup"><span data-stu-id="781b9-112">Parameter</span></span>| <span data-ttu-id="781b9-113">種類</span><span class="sxs-lookup"><span data-stu-id="781b9-113">Type</span></span>| <span data-ttu-id="781b9-114">説明</span><span class="sxs-lookup"><span data-stu-id="781b9-114">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="781b9-115">scid</span><span class="sxs-lookup"><span data-stu-id="781b9-115">scid</span></span>| <span data-ttu-id="781b9-116">GUID</span><span class="sxs-lookup"><span data-stu-id="781b9-116">GUID</span></span>| <span data-ttu-id="781b9-117">サービス構成の識別子 (SCID) です。</span><span class="sxs-lookup"><span data-stu-id="781b9-117">Service configuration identifier (SCID).</span></span> <span data-ttu-id="781b9-118">パート 1 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="781b9-118">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="781b9-119">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="781b9-119">sessionTemplateName</span></span>| <span data-ttu-id="781b9-120">string</span><span class="sxs-lookup"><span data-stu-id="781b9-120">string</span></span>| <span data-ttu-id="781b9-121">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="781b9-121">Name of the current instance of the session template.</span></span> <span data-ttu-id="781b9-122">パート 2 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="781b9-122">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="781b9-123">セッション名</span><span class="sxs-lookup"><span data-stu-id="781b9-123">sessionName</span></span>| <span data-ttu-id="781b9-124">GUID</span><span class="sxs-lookup"><span data-stu-id="781b9-124">GUID</span></span>| <span data-ttu-id="781b9-125">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="781b9-125">Unique ID of the session.</span></span> <span data-ttu-id="781b9-126">パート 3 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="781b9-126">Part 3 of the session identifier.</span></span>|

<a id="ID4E5"></a>


## <a name="http-status-codes"></a><span data-ttu-id="781b9-127">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="781b9-127">HTTP status codes</span></span>
<span data-ttu-id="781b9-128">MPSD に適用される、サービスは、HTTP 状態コードを返します。</span><span class="sxs-lookup"><span data-stu-id="781b9-128">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EFB"></a>


## <a name="request-body"></a><span data-ttu-id="781b9-129">要求本文</span><span class="sxs-lookup"><span data-stu-id="781b9-129">Request body</span></span>
<span data-ttu-id="781b9-130">要求の構造を参照してください。 [MultiplayerSessionRequest (JSON)](../../json/json-multiplayersessionrequest.md)します。</span><span class="sxs-lookup"><span data-stu-id="781b9-130">See the request structure in [MultiplayerSessionRequest (JSON)](../../json/json-multiplayersessionrequest.md).</span></span>  
<a id="ID4EOB"></a>


## <a name="response-body"></a><span data-ttu-id="781b9-131">応答本文</span><span class="sxs-lookup"><span data-stu-id="781b9-131">Response body</span></span>
<span data-ttu-id="781b9-132">応答の構造で表示[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)します。</span><span class="sxs-lookup"><span data-stu-id="781b9-132">See the response structure in [MultiplayerSession (JSON)](../../json/json-multiplayersession.md).</span></span>  
<a id="ID4EYB"></a>


## <a name="see-also"></a><span data-ttu-id="781b9-133">関連項目</span><span class="sxs-lookup"><span data-stu-id="781b9-133">See also</span></span>

<a id="ID4E1B"></a>


##### <a name="parent"></a><span data-ttu-id="781b9-134">Parent</span><span class="sxs-lookup"><span data-stu-id="781b9-134">Parent</span></span>

[<span data-ttu-id="781b9-135">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index}</span><span class="sxs-lookup"><span data-stu-id="781b9-135">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index}</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersindex.md)
