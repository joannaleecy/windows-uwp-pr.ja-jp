---
title: DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index})
assetID: 00aa2f3d-69a6-6d68-e99b-aad4b102aba3
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersindexdelete.html
author: KevinAsgari
description: " DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index})"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1c9d6ea4151acec6c7644d106db28f2820153dd2
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6208150"
---
# <a name="delete-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersindex"></a><span data-ttu-id="e4a27-104">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index})</span><span class="sxs-lookup"><span data-stu-id="e4a27-104">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index})</span></span>
<span data-ttu-id="e4a27-105">指定されたメンバーをセッションから削除します。</span><span class="sxs-lookup"><span data-stu-id="e4a27-105">Removes the specified members from a session.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="e4a27-106">この URI メソッドには、X Xbl コントラクト バージョンのヘッダーの要素が必要があります: 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="e4a27-106">This URI method requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="e4a27-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e4a27-107">URI parameters</span></span>](#ID4ET)
  * [<span data-ttu-id="e4a27-108">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="e4a27-108">HTTP status codes</span></span>](#ID4E5)
  * [<span data-ttu-id="e4a27-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="e4a27-109">Request body</span></span>](#ID4EFB)
  * [<span data-ttu-id="e4a27-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="e4a27-110">Response body</span></span>](#ID4EOB)

<a id="ID4ET"></a>


## <a name="uri-parameters"></a><span data-ttu-id="e4a27-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e4a27-111">URI parameters</span></span>

| <span data-ttu-id="e4a27-112">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e4a27-112">Parameter</span></span>| <span data-ttu-id="e4a27-113">型</span><span class="sxs-lookup"><span data-stu-id="e4a27-113">Type</span></span>| <span data-ttu-id="e4a27-114">説明</span><span class="sxs-lookup"><span data-stu-id="e4a27-114">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="e4a27-115">scid</span><span class="sxs-lookup"><span data-stu-id="e4a27-115">scid</span></span>| <span data-ttu-id="e4a27-116">GUID</span><span class="sxs-lookup"><span data-stu-id="e4a27-116">GUID</span></span>| <span data-ttu-id="e4a27-117">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="e4a27-117">Service configuration identifier (SCID).</span></span> <span data-ttu-id="e4a27-118">パート 1 セッション識別子です。</span><span class="sxs-lookup"><span data-stu-id="e4a27-118">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="e4a27-119">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="e4a27-119">sessionTemplateName</span></span>| <span data-ttu-id="e4a27-120">string</span><span class="sxs-lookup"><span data-stu-id="e4a27-120">string</span></span>| <span data-ttu-id="e4a27-121">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="e4a27-121">Name of the current instance of the session template.</span></span> <span data-ttu-id="e4a27-122">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="e4a27-122">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="e4a27-123">セッション名</span><span class="sxs-lookup"><span data-stu-id="e4a27-123">sessionName</span></span>| <span data-ttu-id="e4a27-124">GUID</span><span class="sxs-lookup"><span data-stu-id="e4a27-124">GUID</span></span>| <span data-ttu-id="e4a27-125">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="e4a27-125">Unique ID of the session.</span></span> <span data-ttu-id="e4a27-126">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="e4a27-126">Part 3 of the session identifier.</span></span>|

<a id="ID4E5"></a>


## <a name="http-status-codes"></a><span data-ttu-id="e4a27-127">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="e4a27-127">HTTP status codes</span></span>
<span data-ttu-id="e4a27-128">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="e4a27-128">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EFB"></a>


## <a name="request-body"></a><span data-ttu-id="e4a27-129">要求本文</span><span class="sxs-lookup"><span data-stu-id="e4a27-129">Request body</span></span>
<span data-ttu-id="e4a27-130">[MultiplayerSessionRequest (JSON)](../../json/json-multiplayersessionrequest.md)の要求の構造を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e4a27-130">See the request structure in [MultiplayerSessionRequest (JSON)](../../json/json-multiplayersessionrequest.md).</span></span>  
<a id="ID4EOB"></a>


## <a name="response-body"></a><span data-ttu-id="e4a27-131">応答本文</span><span class="sxs-lookup"><span data-stu-id="e4a27-131">Response body</span></span>
<span data-ttu-id="e4a27-132">[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)で応答構造を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e4a27-132">See the response structure in [MultiplayerSession (JSON)](../../json/json-multiplayersession.md).</span></span>  
<a id="ID4EYB"></a>


## <a name="see-also"></a><span data-ttu-id="e4a27-133">関連項目</span><span class="sxs-lookup"><span data-stu-id="e4a27-133">See also</span></span>

<a id="ID4E1B"></a>


##### <a name="parent"></a><span data-ttu-id="e4a27-134">Parent</span><span class="sxs-lookup"><span data-stu-id="e4a27-134">Parent</span></span>

[<span data-ttu-id="e4a27-135">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index}</span><span class="sxs-lookup"><span data-stu-id="e4a27-135">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/{index}</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersindex.md)
