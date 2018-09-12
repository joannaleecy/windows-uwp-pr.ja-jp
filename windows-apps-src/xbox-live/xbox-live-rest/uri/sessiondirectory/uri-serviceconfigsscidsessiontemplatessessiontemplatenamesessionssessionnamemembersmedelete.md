---
title: 削除 (/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/メンバー/me)
assetID: aa5de623-7787-a47c-b7e4-305693b9fe35
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersmedelete.html
author: KevinAsgari
description: " 削除 (/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/メンバー/me)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 273819165e5dcf6b6398cd5b62e99be358e5ae9b
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881580"
---
# <a name="delete-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme"></a><span data-ttu-id="b4530-104">削除 (/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/メンバー/me)</span><span class="sxs-lookup"><span data-stu-id="b4530-104">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me)</span></span>
<span data-ttu-id="b4530-105">メンバーをセッションから削除します。</span><span class="sxs-lookup"><span data-stu-id="b4530-105">Removes a member from a session.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="b4530-106">この URI メソッドには、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="b4530-106">This URI method requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="b4530-107">注釈</span><span class="sxs-lookup"><span data-stu-id="b4530-107">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="b4530-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b4530-108">URI parameters</span></span>](#ID4E3)
  * [<span data-ttu-id="b4530-109">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="b4530-109">HTTP status codes</span></span>](#ID4EHB)
  * [<span data-ttu-id="b4530-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="b4530-110">Request body</span></span>](#ID4ENB)
  * [<span data-ttu-id="b4530-111">応答本文</span><span class="sxs-lookup"><span data-stu-id="b4530-111">Response body</span></span>](#ID4EYB)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="b4530-112">注釈</span><span class="sxs-lookup"><span data-stu-id="b4530-112">Remarks</span></span>
<span data-ttu-id="b4530-113">すべてのセッション メンバー リソースの操作には、Xbox ユーザー ID (XUID) 承認が必要です。</span><span class="sxs-lookup"><span data-stu-id="b4530-113">All session member resource operations require an Xbox User ID (XUID) authorization.</span></span>  
<a id="ID4E3"></a>


## <a name="uri-parameters"></a><span data-ttu-id="b4530-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b4530-114">URI parameters</span></span>

| <span data-ttu-id="b4530-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b4530-115">Parameter</span></span>| <span data-ttu-id="b4530-116">型</span><span class="sxs-lookup"><span data-stu-id="b4530-116">Type</span></span>| <span data-ttu-id="b4530-117">説明</span><span class="sxs-lookup"><span data-stu-id="b4530-117">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="b4530-118">scid</span><span class="sxs-lookup"><span data-stu-id="b4530-118">scid</span></span>| <span data-ttu-id="b4530-119">GUID</span><span class="sxs-lookup"><span data-stu-id="b4530-119">GUID</span></span>| <span data-ttu-id="b4530-120">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="b4530-120">Service configuration identifier (SCID).</span></span> <span data-ttu-id="b4530-121">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="b4530-121">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="b4530-122">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="b4530-122">sessionTemplateName</span></span>| <span data-ttu-id="b4530-123">string</span><span class="sxs-lookup"><span data-stu-id="b4530-123">string</span></span>| <span data-ttu-id="b4530-124">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="b4530-124">Name of the current instance of the session template.</span></span> <span data-ttu-id="b4530-125">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="b4530-125">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="b4530-126">セッション名</span><span class="sxs-lookup"><span data-stu-id="b4530-126">sessionName</span></span>| <span data-ttu-id="b4530-127">GUID</span><span class="sxs-lookup"><span data-stu-id="b4530-127">GUID</span></span>| <span data-ttu-id="b4530-128">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="b4530-128">Unique ID of the session.</span></span> <span data-ttu-id="b4530-129">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="b4530-129">Part 3 of the session identifier.</span></span>|

<a id="ID4EHB"></a>


## <a name="http-status-codes"></a><span data-ttu-id="b4530-130">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="b4530-130">HTTP status codes</span></span>
<span data-ttu-id="b4530-131">サービスは、MPSD に適用される、HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="b4530-131">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4ENB"></a>


## <a name="request-body"></a><span data-ttu-id="b4530-132">要求本文</span><span class="sxs-lookup"><span data-stu-id="b4530-132">Request body</span></span>

<span data-ttu-id="b4530-133">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="b4530-133">No objects are sent in the body of this request.</span></span>

<a id="ID4EYB"></a>


## <a name="response-body"></a><span data-ttu-id="b4530-134">応答本文</span><span class="sxs-lookup"><span data-stu-id="b4530-134">Response body</span></span>
<span data-ttu-id="b4530-135">[MultiplayerSession (](../../json/json-multiplayersession.md)json) 応答構造を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b4530-135">See the response structure in [MultiplayerSession (JSON)](../../json/json-multiplayersession.md).</span></span>  
<a id="ID4EBC"></a>


## <a name="see-also"></a><span data-ttu-id="b4530-136">関連項目</span><span class="sxs-lookup"><span data-stu-id="b4530-136">See also</span></span>

<a id="ID4EDC"></a>


##### <a name="parent"></a><span data-ttu-id="b4530-137">Parent</span><span class="sxs-lookup"><span data-stu-id="b4530-137">Parent</span></span>

[<span data-ttu-id="b4530-138">/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション}/メンバー/me</span><span class="sxs-lookup"><span data-stu-id="b4530-138">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/members/me</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnamemembersme.md)
