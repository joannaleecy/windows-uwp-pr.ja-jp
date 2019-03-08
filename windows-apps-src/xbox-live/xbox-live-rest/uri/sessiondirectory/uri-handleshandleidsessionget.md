---
title: GET (/handles/{handleId}/session)
assetID: 1f22954c-e77b-69c2-63f4-741fbd965f8f
permalink: en-us/docs/xboxlive/rest/uri-handleshandleidsessionget.html
description: " GET (/handles/{handleId}/session)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 41911dc53b316f4f323b9859d9101581ec88e497
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593897"
---
# <a name="get-handleshandleidsession"></a><span data-ttu-id="e0aa6-104">GET (/handles/{handleId}/session)</span><span class="sxs-lookup"><span data-stu-id="e0aa6-104">GET (/handles/{handleId}/session)</span></span>
<span data-ttu-id="e0aa6-105">指定したハンドル識別子のセッション オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="e0aa6-105">Gets a session object for the specified handle identifier.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="e0aa6-106">このメソッドは、2015年マルチ プレーヤーを使用し、以降そのマルチ プレーヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="e0aa6-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="e0aa6-107">104/105 またはそれ以降、テンプレートのコントラクトで使用され、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。</span><span class="sxs-lookup"><span data-stu-id="e0aa6-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="e0aa6-108">注釈</span><span class="sxs-lookup"><span data-stu-id="e0aa6-108">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="e0aa6-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e0aa6-109">URI parameters</span></span>](#ID4EDB)
  * [<span data-ttu-id="e0aa6-110">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="e0aa6-110">HTTP status codes</span></span>](#ID4EOB)
  * [<span data-ttu-id="e0aa6-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="e0aa6-111">Request body</span></span>](#ID4EVB)
  * [<span data-ttu-id="e0aa6-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="e0aa6-112">Response body</span></span>](#ID4E6B)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="e0aa6-113">注釈</span><span class="sxs-lookup"><span data-stu-id="e0aa6-113">Remarks</span></span>

<span data-ttu-id="e0aa6-114">この HTTP/REST メソッドは、セッション (ハンドル) に指定されたサービス側のポインターを使用して、サーバーからセッション オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="e0aa6-114">This HTTP/REST method retrieves a session object from the server, using the supplied service-side pointer to the session (handle).</span></span> <span data-ttu-id="e0aa6-115">すべての属性を持つ、セッション オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="e0aa6-115">The return is the session object, with all its attributes.</span></span> <span data-ttu-id="e0aa6-116">このメソッドによってラップできる**Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionByHandleAsync**します。</span><span class="sxs-lookup"><span data-stu-id="e0aa6-116">This method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionByHandleAsync**.</span></span>

<span data-ttu-id="e0aa6-117">このメソッドの呼び出し元は、プレイヤーからハンドル ID を取得します。 **MultiplayerActivityDetails**オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="e0aa6-117">The caller of this method obtains the handle ID from a player's **MultiplayerActivityDetails** object.</span></span> <span data-ttu-id="e0aa6-118">または、呼び出し元は、ユーザーがゲームへの招待を承諾した後、プロトコルのアクティブ化から ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="e0aa6-118">Alternatively, the caller gets the ID from a protocol activation after a user has accepted a game invite.</span></span>

<a id="ID4EDB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="e0aa6-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e0aa6-119">URI parameters</span></span>

| <span data-ttu-id="e0aa6-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e0aa6-120">Parameter</span></span>| <span data-ttu-id="e0aa6-121">種類</span><span class="sxs-lookup"><span data-stu-id="e0aa6-121">Type</span></span>| <span data-ttu-id="e0aa6-122">説明</span><span class="sxs-lookup"><span data-stu-id="e0aa6-122">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="e0aa6-123">handleId</span><span class="sxs-lookup"><span data-stu-id="e0aa6-123">handleId</span></span>| <span data-ttu-id="e0aa6-124">GUID</span><span class="sxs-lookup"><span data-stu-id="e0aa6-124">GUID</span></span>| <span data-ttu-id="e0aa6-125">セッションのハンドルの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="e0aa6-125">The unique ID of the handle for the session.</span></span>|

<a id="ID4EOB"></a>


## <a name="http-status-codes"></a><span data-ttu-id="e0aa6-126">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="e0aa6-126">HTTP status codes</span></span>
<span data-ttu-id="e0aa6-127">MPSD に適用される、サービスは、HTTP 状態コードを返します。</span><span class="sxs-lookup"><span data-stu-id="e0aa6-127">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EVB"></a>


## <a name="request-body"></a><span data-ttu-id="e0aa6-128">要求本文</span><span class="sxs-lookup"><span data-stu-id="e0aa6-128">Request body</span></span>

<span data-ttu-id="e0aa6-129">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="e0aa6-129">No objects are sent in the body of this request.</span></span>

<a id="ID4E6B"></a>


## <a name="response-body"></a><span data-ttu-id="e0aa6-130">応答本文</span><span class="sxs-lookup"><span data-stu-id="e0aa6-130">Response body</span></span>
<span data-ttu-id="e0aa6-131">応答の構造で表示[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)します。</span><span class="sxs-lookup"><span data-stu-id="e0aa6-131">See the response structure in [MultiplayerSession (JSON)](../../json/json-multiplayersession.md).</span></span>  
<a id="ID4EIC"></a>


## <a name="see-also"></a><span data-ttu-id="e0aa6-132">関連項目</span><span class="sxs-lookup"><span data-stu-id="e0aa6-132">See also</span></span>

<a id="ID4EKC"></a>


##### <a name="parent"></a><span data-ttu-id="e0aa6-133">Parent</span><span class="sxs-lookup"><span data-stu-id="e0aa6-133">Parent</span></span>

[<span data-ttu-id="e0aa6-134">/handles/{handleId}/session</span><span class="sxs-lookup"><span data-stu-id="e0aa6-134">/handles/{handleId}/session</span></span>](uri-handleshandleidsession.md)
