---
title: DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)
assetID: aa5de623-7787-a47c-b7e4-305693b9fe35
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersmedelete.html
author: KevinAsgari
description: " DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e67b48653b7cccb3a9ff30bc833df0f9d3189638
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5918361"
---
# <a name="delete-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme"></a><span data-ttu-id="8d7b1-104">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)</span><span class="sxs-lookup"><span data-stu-id="8d7b1-104">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)</span></span>
<span data-ttu-id="8d7b1-105">メンバーをセッションから削除します。</span><span class="sxs-lookup"><span data-stu-id="8d7b1-105">Removes a member from a session.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="8d7b1-106">この URI メソッドには、X Xbl コントラクト バージョンのヘッダーの要素が必要があります: 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="8d7b1-106">This URI method requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="8d7b1-107">注釈</span><span class="sxs-lookup"><span data-stu-id="8d7b1-107">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="8d7b1-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8d7b1-108">URI parameters</span></span>](#ID4E3)
  * [<span data-ttu-id="8d7b1-109">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="8d7b1-109">HTTP status codes</span></span>](#ID4EHB)
  * [<span data-ttu-id="8d7b1-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="8d7b1-110">Request body</span></span>](#ID4ENB)
  * [<span data-ttu-id="8d7b1-111">応答本文</span><span class="sxs-lookup"><span data-stu-id="8d7b1-111">Response body</span></span>](#ID4EYB)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="8d7b1-112">注釈</span><span class="sxs-lookup"><span data-stu-id="8d7b1-112">Remarks</span></span>
<span data-ttu-id="8d7b1-113">すべてのセッション メンバー リソースの操作には、Xbox ユーザー ID (XUID) 承認が必要です。</span><span class="sxs-lookup"><span data-stu-id="8d7b1-113">All session member resource operations require an Xbox User ID (XUID) authorization.</span></span>  
<a id="ID4E3"></a>


## <a name="uri-parameters"></a><span data-ttu-id="8d7b1-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8d7b1-114">URI parameters</span></span>

| <span data-ttu-id="8d7b1-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8d7b1-115">Parameter</span></span>| <span data-ttu-id="8d7b1-116">型</span><span class="sxs-lookup"><span data-stu-id="8d7b1-116">Type</span></span>| <span data-ttu-id="8d7b1-117">説明</span><span class="sxs-lookup"><span data-stu-id="8d7b1-117">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="8d7b1-118">scid</span><span class="sxs-lookup"><span data-stu-id="8d7b1-118">scid</span></span>| <span data-ttu-id="8d7b1-119">GUID</span><span class="sxs-lookup"><span data-stu-id="8d7b1-119">GUID</span></span>| <span data-ttu-id="8d7b1-120">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="8d7b1-120">Service configuration identifier (SCID).</span></span> <span data-ttu-id="8d7b1-121">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="8d7b1-121">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="8d7b1-122">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="8d7b1-122">sessionTemplateName</span></span>| <span data-ttu-id="8d7b1-123">string</span><span class="sxs-lookup"><span data-stu-id="8d7b1-123">string</span></span>| <span data-ttu-id="8d7b1-124">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="8d7b1-124">Name of the current instance of the session template.</span></span> <span data-ttu-id="8d7b1-125">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="8d7b1-125">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="8d7b1-126">セッション名</span><span class="sxs-lookup"><span data-stu-id="8d7b1-126">sessionName</span></span>| <span data-ttu-id="8d7b1-127">GUID</span><span class="sxs-lookup"><span data-stu-id="8d7b1-127">GUID</span></span>| <span data-ttu-id="8d7b1-128">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="8d7b1-128">Unique ID of the session.</span></span> <span data-ttu-id="8d7b1-129">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="8d7b1-129">Part 3 of the session identifier.</span></span>|

<a id="ID4EHB"></a>


## <a name="http-status-codes"></a><span data-ttu-id="8d7b1-130">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="8d7b1-130">HTTP status codes</span></span>
<span data-ttu-id="8d7b1-131">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="8d7b1-131">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4ENB"></a>


## <a name="request-body"></a><span data-ttu-id="8d7b1-132">要求本文</span><span class="sxs-lookup"><span data-stu-id="8d7b1-132">Request body</span></span>

<span data-ttu-id="8d7b1-133">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="8d7b1-133">No objects are sent in the body of this request.</span></span>

<a id="ID4EYB"></a>


## <a name="response-body"></a><span data-ttu-id="8d7b1-134">応答本文</span><span class="sxs-lookup"><span data-stu-id="8d7b1-134">Response body</span></span>
<span data-ttu-id="8d7b1-135">[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)の応答構造を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8d7b1-135">See the response structure in [MultiplayerSession (JSON)](../../json/json-multiplayersession.md).</span></span>  
<a id="ID4EBC"></a>


## <a name="see-also"></a><span data-ttu-id="8d7b1-136">関連項目</span><span class="sxs-lookup"><span data-stu-id="8d7b1-136">See also</span></span>

<a id="ID4EDC"></a>


##### <a name="parent"></a><span data-ttu-id="8d7b1-137">Parent</span><span class="sxs-lookup"><span data-stu-id="8d7b1-137">Parent</span></span>

[<span data-ttu-id="8d7b1-138">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me</span><span class="sxs-lookup"><span data-stu-id="8d7b1-138">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme.md)
