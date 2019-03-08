---
title: PUT (/handles/{handle-id}/session)
assetID: d8a3d473-1192-ec0c-3935-c301f4f61e03
permalink: en-us/docs/xboxlive/rest/uri-handleshandleidsessionput.html
description: " PUT (/handles/{handle-id}/session)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3a1872857d8b8e692f67e3c7b2a067ae86663c00
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641607"
---
# <a name="put-handleshandle-idsession"></a><span data-ttu-id="2087e-104">PUT (/handles/{handle-id}/session)</span><span class="sxs-lookup"><span data-stu-id="2087e-104">PUT (/handles/{handle-id}/session)</span></span>
<span data-ttu-id="2087e-105">作成またはハンドルの逆参照でセッションを更新します。</span><span class="sxs-lookup"><span data-stu-id="2087e-105">Creates or updates a session by dereferencing a handle.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="2087e-106">このメソッドは、2015年マルチ プレーヤーを使用し、以降そのマルチ プレーヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="2087e-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="2087e-107">104/105 またはそれ以降、テンプレートのコントラクトで使用され、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。</span><span class="sxs-lookup"><span data-stu-id="2087e-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="2087e-108">注釈</span><span class="sxs-lookup"><span data-stu-id="2087e-108">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="2087e-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2087e-109">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="2087e-110">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="2087e-110">HTTP status codes</span></span>](#ID4ENB)
  * [<span data-ttu-id="2087e-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="2087e-111">Request body</span></span>](#ID4EUB)
  * [<span data-ttu-id="2087e-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="2087e-112">Response body</span></span>](#ID4E6B)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="2087e-113">注釈</span><span class="sxs-lookup"><span data-stu-id="2087e-113">Remarks</span></span>

<span data-ttu-id="2087e-114">この HTTP/REST メソッドが提供されているセッション ハンドル ID を使用して、マルチ プレーヤー サービスを新規または更新されたセッションを書き込みます</span><span class="sxs-lookup"><span data-stu-id="2087e-114">This HTTP/REST method writes a new or updated session to the multiplayer service, using the supplied session handle ID.</span></span> <span data-ttu-id="2087e-115">結果は、サーバーから返される、新しいまたは更新されたセッションを表すオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="2087e-115">The result is an object representing the new or updated session as returned from the server.</span></span> <span data-ttu-id="2087e-116">このメソッドによってラップできる**Microsoft.Xbox.Services.Multiplayer.MultiplayerService.WriteSessionByHandleAsync**します。</span><span class="sxs-lookup"><span data-stu-id="2087e-116">This method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.WriteSessionByHandleAsync**.</span></span>

<span data-ttu-id="2087e-117">このメソッドの呼び出し元は、プレイヤーからハンドル ID を取得します。 **MultiplayerActivityDetails**オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="2087e-117">The caller of this method obtains the handle ID from a player's **MultiplayerActivityDetails** object.</span></span> <span data-ttu-id="2087e-118">または、呼び出し元は、ユーザーがゲームへの招待を承諾した後、プロトコルのアクティブ化から ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="2087e-118">Alternatively, the caller gets the ID from a protocol activation after a user has accepted a game invite.</span></span>

<a id="ID4ECB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="2087e-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2087e-119">URI parameters</span></span>

| <span data-ttu-id="2087e-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="2087e-120">Parameter</span></span>| <span data-ttu-id="2087e-121">種類</span><span class="sxs-lookup"><span data-stu-id="2087e-121">Type</span></span>| <span data-ttu-id="2087e-122">説明</span><span class="sxs-lookup"><span data-stu-id="2087e-122">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="2087e-123">handleId</span><span class="sxs-lookup"><span data-stu-id="2087e-123">handleId</span></span>| <span data-ttu-id="2087e-124">GUID</span><span class="sxs-lookup"><span data-stu-id="2087e-124">GUID</span></span>| <span data-ttu-id="2087e-125">セッションのハンドルの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="2087e-125">The unique ID of the handle for the session.</span></span>|

<a id="ID4ENB"></a>


## <a name="http-status-codes"></a><span data-ttu-id="2087e-126">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="2087e-126">HTTP status codes</span></span>
<span data-ttu-id="2087e-127">MPSD に適用される、サービスは、HTTP 状態コードを返します。</span><span class="sxs-lookup"><span data-stu-id="2087e-127">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EUB"></a>


## <a name="request-body"></a><span data-ttu-id="2087e-128">要求本文</span><span class="sxs-lookup"><span data-stu-id="2087e-128">Request body</span></span>

<span data-ttu-id="2087e-129">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="2087e-129">No objects are sent in the body of this request.</span></span>

<a id="ID4E6B"></a>


## <a name="response-body"></a><span data-ttu-id="2087e-130">応答本文</span><span class="sxs-lookup"><span data-stu-id="2087e-130">Response body</span></span>

<span data-ttu-id="2087e-131">応答の本文では、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="2087e-131">No objects are sent in the body of the response.</span></span>

<a id="ID4EKC"></a>


## <a name="see-also"></a><span data-ttu-id="2087e-132">関連項目</span><span class="sxs-lookup"><span data-stu-id="2087e-132">See also</span></span>

<a id="ID4EMC"></a>


##### <a name="parent"></a><span data-ttu-id="2087e-133">Parent</span><span class="sxs-lookup"><span data-stu-id="2087e-133">Parent</span></span>

[<span data-ttu-id="2087e-134">/handles/{handleId}/session</span><span class="sxs-lookup"><span data-stu-id="2087e-134">/handles/{handleId}/session</span></span>](uri-handleshandleidsession.md)
