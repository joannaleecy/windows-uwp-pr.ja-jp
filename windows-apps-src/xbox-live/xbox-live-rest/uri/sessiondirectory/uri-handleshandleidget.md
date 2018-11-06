---
title: GET (/handles/{handle-id})
assetID: c95b5ab5-d56a-f70d-20d8-afb48d122ccd
permalink: en-us/docs/xboxlive/rest/uri-handleshandleidget.html
author: KevinAsgari
description: " GET (/handles/{handle-id})"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 39d39db0fa17c85dfad3dcca7526d13618835135
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6026116"
---
# <a name="get-handleshandle-id"></a><span data-ttu-id="8b163-104">GET (/handles/{handle-id})</span><span class="sxs-lookup"><span data-stu-id="8b163-104">GET (/handles/{handle-id})</span></span>
<span data-ttu-id="8b163-105">ハンドル ID で指定されたハンドルを取得します。</span><span class="sxs-lookup"><span data-stu-id="8b163-105">Retrieves handles specified by handle ID.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="8b163-106">このメソッドは、2015年マルチプレイヤーで使用し、以降そのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="8b163-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="8b163-107">テンプレート コントラクト 104/105 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="8b163-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="8b163-108">注釈</span><span class="sxs-lookup"><span data-stu-id="8b163-108">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="8b163-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8b163-109">URI parameters</span></span>](#ID4EDB)
  * [<span data-ttu-id="8b163-110">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="8b163-110">HTTP status codes</span></span>](#ID4EOB)
  * [<span data-ttu-id="8b163-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="8b163-111">Request body</span></span>](#ID4EUB)
  * [<span data-ttu-id="8b163-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="8b163-112">Response body</span></span>](#ID4E5B)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="8b163-113">注釈</span><span class="sxs-lookup"><span data-stu-id="8b163-113">Remarks</span></span>

<span data-ttu-id="8b163-114">この HTTP/REST メソッドでは、指定したハンドル、セッションでは、ユーザーの現在のアクティビティを取得します。</span><span class="sxs-lookup"><span data-stu-id="8b163-114">This HTTP/REST method gets the users' current activity for the session, for the specified handles.</span></span> <span data-ttu-id="8b163-115">すべての属性を使用して、セッション オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="8b163-115">The return is the session object, with all its attributes.</span></span> <span data-ttu-id="8b163-116">このメソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionByHandleAsync**でラップすることができます。</span><span class="sxs-lookup"><span data-stu-id="8b163-116">This method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionByHandleAsync**.</span></span>

<span data-ttu-id="8b163-117">このメソッドの呼び出し元では、プレイヤーの**MultiplayerActivityDetails**オブジェクトからハンドル ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="8b163-117">The caller of this method obtains the handle ID from a player's **MultiplayerActivityDetails** object.</span></span> <span data-ttu-id="8b163-118">または、呼び出し元は、ユーザーがゲームへの招待を受け入れた後、プロトコルのアクティブ化から ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="8b163-118">Alternatively, the caller gets the ID from a protocol activation after a user has accepted a game invite.</span></span>

<a id="ID4EDB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="8b163-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8b163-119">URI parameters</span></span>

| <span data-ttu-id="8b163-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8b163-120">Parameter</span></span>| <span data-ttu-id="8b163-121">型</span><span class="sxs-lookup"><span data-stu-id="8b163-121">Type</span></span>| <span data-ttu-id="8b163-122">説明</span><span class="sxs-lookup"><span data-stu-id="8b163-122">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="8b163-123">ハンドル id を使用</span><span class="sxs-lookup"><span data-stu-id="8b163-123">handleId</span></span>| <span data-ttu-id="8b163-124">GUID</span><span class="sxs-lookup"><span data-stu-id="8b163-124">GUID</span></span>| <span data-ttu-id="8b163-125">セッションのハンドルを一意の ID。</span><span class="sxs-lookup"><span data-stu-id="8b163-125">The unique ID of the handle for the session.</span></span>|

<a id="ID4EOB"></a>


## <a name="http-status-codes"></a><span data-ttu-id="8b163-126">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="8b163-126">HTTP status codes</span></span>
<span data-ttu-id="8b163-127">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="8b163-127">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EUB"></a>


## <a name="request-body"></a><span data-ttu-id="8b163-128">要求本文</span><span class="sxs-lookup"><span data-stu-id="8b163-128">Request body</span></span>

<span data-ttu-id="8b163-129">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="8b163-129">No objects are sent in the body of this request.</span></span>

<a id="ID4E5B"></a>


## <a name="response-body"></a><span data-ttu-id="8b163-130">応答本文</span><span class="sxs-lookup"><span data-stu-id="8b163-130">Response body</span></span>
<span data-ttu-id="8b163-131">[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)の応答構造を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8b163-131">See the response structure in [MultiplayerSession (JSON)](../../json/json-multiplayersession.md).</span></span>  
<a id="ID4EKC"></a>


## <a name="see-also"></a><span data-ttu-id="8b163-132">関連項目</span><span class="sxs-lookup"><span data-stu-id="8b163-132">See also</span></span>

<a id="ID4EMC"></a>


##### <a name="parent"></a><span data-ttu-id="8b163-133">Parent</span><span class="sxs-lookup"><span data-stu-id="8b163-133">Parent</span></span>

[<span data-ttu-id="8b163-134">/handles/{handleId}</span><span class="sxs-lookup"><span data-stu-id="8b163-134">/handles/{handleId}</span></span>](uri-handleshandleid.md)
