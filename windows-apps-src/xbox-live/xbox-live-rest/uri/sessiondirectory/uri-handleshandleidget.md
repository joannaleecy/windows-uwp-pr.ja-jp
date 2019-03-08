---
title: GET (/handles/{handle-id})
assetID: c95b5ab5-d56a-f70d-20d8-afb48d122ccd
permalink: en-us/docs/xboxlive/rest/uri-handleshandleidget.html
description: " GET (/handles/{handle-id})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 501d36f4d1ac079af15d6bb7f35a90d5328fc8db
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57598467"
---
# <a name="get-handleshandle-id"></a><span data-ttu-id="c23e7-104">GET (/handles/{handle-id})</span><span class="sxs-lookup"><span data-stu-id="c23e7-104">GET (/handles/{handle-id})</span></span>
<span data-ttu-id="c23e7-105">ハンドルの ID で指定されたハンドルを取得します。</span><span class="sxs-lookup"><span data-stu-id="c23e7-105">Retrieves handles specified by handle ID.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="c23e7-106">このメソッドは、2015年マルチ プレーヤーを使用し、以降そのマルチ プレーヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="c23e7-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="c23e7-107">104/105 またはそれ以降、テンプレートのコントラクトで使用され、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。</span><span class="sxs-lookup"><span data-stu-id="c23e7-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="c23e7-108">注釈</span><span class="sxs-lookup"><span data-stu-id="c23e7-108">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="c23e7-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c23e7-109">URI parameters</span></span>](#ID4EDB)
  * [<span data-ttu-id="c23e7-110">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c23e7-110">HTTP status codes</span></span>](#ID4EOB)
  * [<span data-ttu-id="c23e7-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="c23e7-111">Request body</span></span>](#ID4EUB)
  * [<span data-ttu-id="c23e7-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="c23e7-112">Response body</span></span>](#ID4E5B)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="c23e7-113">注釈</span><span class="sxs-lookup"><span data-stu-id="c23e7-113">Remarks</span></span>

<span data-ttu-id="c23e7-114">この HTTP/REST メソッドは、指定したハンドルのため、セッションのユーザーの現在のアクティビティを取得します。</span><span class="sxs-lookup"><span data-stu-id="c23e7-114">This HTTP/REST method gets the users' current activity for the session, for the specified handles.</span></span> <span data-ttu-id="c23e7-115">すべての属性を持つ、セッション オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="c23e7-115">The return is the session object, with all its attributes.</span></span> <span data-ttu-id="c23e7-116">このメソッドによってラップできる**Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionByHandleAsync**します。</span><span class="sxs-lookup"><span data-stu-id="c23e7-116">This method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionByHandleAsync**.</span></span>

<span data-ttu-id="c23e7-117">このメソッドの呼び出し元は、プレイヤーからハンドル ID を取得します。 **MultiplayerActivityDetails**オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="c23e7-117">The caller of this method obtains the handle ID from a player's **MultiplayerActivityDetails** object.</span></span> <span data-ttu-id="c23e7-118">または、呼び出し元は、ユーザーがゲームへの招待を承諾した後、プロトコルのアクティブ化から ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="c23e7-118">Alternatively, the caller gets the ID from a protocol activation after a user has accepted a game invite.</span></span>

<a id="ID4EDB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="c23e7-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c23e7-119">URI parameters</span></span>

| <span data-ttu-id="c23e7-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c23e7-120">Parameter</span></span>| <span data-ttu-id="c23e7-121">種類</span><span class="sxs-lookup"><span data-stu-id="c23e7-121">Type</span></span>| <span data-ttu-id="c23e7-122">説明</span><span class="sxs-lookup"><span data-stu-id="c23e7-122">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="c23e7-123">handleId</span><span class="sxs-lookup"><span data-stu-id="c23e7-123">handleId</span></span>| <span data-ttu-id="c23e7-124">GUID</span><span class="sxs-lookup"><span data-stu-id="c23e7-124">GUID</span></span>| <span data-ttu-id="c23e7-125">セッションのハンドルの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="c23e7-125">The unique ID of the handle for the session.</span></span>|

<a id="ID4EOB"></a>


## <a name="http-status-codes"></a><span data-ttu-id="c23e7-126">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c23e7-126">HTTP status codes</span></span>
<span data-ttu-id="c23e7-127">MPSD に適用される、サービスは、HTTP 状態コードを返します。</span><span class="sxs-lookup"><span data-stu-id="c23e7-127">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EUB"></a>


## <a name="request-body"></a><span data-ttu-id="c23e7-128">要求本文</span><span class="sxs-lookup"><span data-stu-id="c23e7-128">Request body</span></span>

<span data-ttu-id="c23e7-129">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="c23e7-129">No objects are sent in the body of this request.</span></span>

<a id="ID4E5B"></a>


## <a name="response-body"></a><span data-ttu-id="c23e7-130">応答本文</span><span class="sxs-lookup"><span data-stu-id="c23e7-130">Response body</span></span>
<span data-ttu-id="c23e7-131">応答の構造で表示[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)します。</span><span class="sxs-lookup"><span data-stu-id="c23e7-131">See the response structure in [MultiplayerSession (JSON)](../../json/json-multiplayersession.md).</span></span>  
<a id="ID4EKC"></a>


## <a name="see-also"></a><span data-ttu-id="c23e7-132">関連項目</span><span class="sxs-lookup"><span data-stu-id="c23e7-132">See also</span></span>

<a id="ID4EMC"></a>


##### <a name="parent"></a><span data-ttu-id="c23e7-133">Parent</span><span class="sxs-lookup"><span data-stu-id="c23e7-133">Parent</span></span>

[<span data-ttu-id="c23e7-134">/handles/{handleId}</span><span class="sxs-lookup"><span data-stu-id="c23e7-134">/handles/{handleId}</span></span>](uri-handleshandleid.md)
