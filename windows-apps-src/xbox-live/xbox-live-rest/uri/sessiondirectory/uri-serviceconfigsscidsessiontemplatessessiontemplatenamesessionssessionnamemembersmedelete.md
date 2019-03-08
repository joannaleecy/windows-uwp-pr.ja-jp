---
title: DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)
assetID: aa5de623-7787-a47c-b7e4-305693b9fe35
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersmedelete.html
description: " DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3de35398f4685a0b0cfda1a251c65ed6a74956d7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57637197"
---
# <a name="delete-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme"></a><span data-ttu-id="4cef9-104">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)</span><span class="sxs-lookup"><span data-stu-id="4cef9-104">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)</span></span>
<span data-ttu-id="4cef9-105">セッションからメンバーを削除します。</span><span class="sxs-lookup"><span data-stu-id="4cef9-105">Removes a member from a session.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="4cef9-106">この URI メソッドでは、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。</span><span class="sxs-lookup"><span data-stu-id="4cef9-106">This URI method requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="4cef9-107">注釈</span><span class="sxs-lookup"><span data-stu-id="4cef9-107">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="4cef9-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4cef9-108">URI parameters</span></span>](#ID4E3)
  * [<span data-ttu-id="4cef9-109">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="4cef9-109">HTTP status codes</span></span>](#ID4EHB)
  * [<span data-ttu-id="4cef9-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="4cef9-110">Request body</span></span>](#ID4ENB)
  * [<span data-ttu-id="4cef9-111">応答本文</span><span class="sxs-lookup"><span data-stu-id="4cef9-111">Response body</span></span>](#ID4EYB)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="4cef9-112">注釈</span><span class="sxs-lookup"><span data-stu-id="4cef9-112">Remarks</span></span>
<span data-ttu-id="4cef9-113">すべてのセッションのメンバー リソース操作には、Xbox のユーザー ID (XUID) 承認が必要です。</span><span class="sxs-lookup"><span data-stu-id="4cef9-113">All session member resource operations require an Xbox User ID (XUID) authorization.</span></span>  
<a id="ID4E3"></a>


## <a name="uri-parameters"></a><span data-ttu-id="4cef9-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4cef9-114">URI parameters</span></span>

| <span data-ttu-id="4cef9-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="4cef9-115">Parameter</span></span>| <span data-ttu-id="4cef9-116">種類</span><span class="sxs-lookup"><span data-stu-id="4cef9-116">Type</span></span>| <span data-ttu-id="4cef9-117">説明</span><span class="sxs-lookup"><span data-stu-id="4cef9-117">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="4cef9-118">scid</span><span class="sxs-lookup"><span data-stu-id="4cef9-118">scid</span></span>| <span data-ttu-id="4cef9-119">GUID</span><span class="sxs-lookup"><span data-stu-id="4cef9-119">GUID</span></span>| <span data-ttu-id="4cef9-120">サービス構成の識別子 (SCID) です。</span><span class="sxs-lookup"><span data-stu-id="4cef9-120">Service configuration identifier (SCID).</span></span> <span data-ttu-id="4cef9-121">パート 1 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="4cef9-121">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="4cef9-122">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="4cef9-122">sessionTemplateName</span></span>| <span data-ttu-id="4cef9-123">string</span><span class="sxs-lookup"><span data-stu-id="4cef9-123">string</span></span>| <span data-ttu-id="4cef9-124">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="4cef9-124">Name of the current instance of the session template.</span></span> <span data-ttu-id="4cef9-125">パート 2 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="4cef9-125">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="4cef9-126">セッション名</span><span class="sxs-lookup"><span data-stu-id="4cef9-126">sessionName</span></span>| <span data-ttu-id="4cef9-127">GUID</span><span class="sxs-lookup"><span data-stu-id="4cef9-127">GUID</span></span>| <span data-ttu-id="4cef9-128">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="4cef9-128">Unique ID of the session.</span></span> <span data-ttu-id="4cef9-129">パート 3 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="4cef9-129">Part 3 of the session identifier.</span></span>|

<a id="ID4EHB"></a>


## <a name="http-status-codes"></a><span data-ttu-id="4cef9-130">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="4cef9-130">HTTP status codes</span></span>
<span data-ttu-id="4cef9-131">MPSD に適用される、サービスは、HTTP 状態コードを返します。</span><span class="sxs-lookup"><span data-stu-id="4cef9-131">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4ENB"></a>


## <a name="request-body"></a><span data-ttu-id="4cef9-132">要求本文</span><span class="sxs-lookup"><span data-stu-id="4cef9-132">Request body</span></span>

<span data-ttu-id="4cef9-133">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="4cef9-133">No objects are sent in the body of this request.</span></span>

<a id="ID4EYB"></a>


## <a name="response-body"></a><span data-ttu-id="4cef9-134">応答本文</span><span class="sxs-lookup"><span data-stu-id="4cef9-134">Response body</span></span>
<span data-ttu-id="4cef9-135">応答の構造で表示[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)します。</span><span class="sxs-lookup"><span data-stu-id="4cef9-135">See the response structure in [MultiplayerSession (JSON)](../../json/json-multiplayersession.md).</span></span>  
<a id="ID4EBC"></a>


## <a name="see-also"></a><span data-ttu-id="4cef9-136">関連項目</span><span class="sxs-lookup"><span data-stu-id="4cef9-136">See also</span></span>

<a id="ID4EDC"></a>


##### <a name="parent"></a><span data-ttu-id="4cef9-137">Parent</span><span class="sxs-lookup"><span data-stu-id="4cef9-137">Parent</span></span>

[<span data-ttu-id="4cef9-138">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me</span><span class="sxs-lookup"><span data-stu-id="4cef9-138">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme.md)
