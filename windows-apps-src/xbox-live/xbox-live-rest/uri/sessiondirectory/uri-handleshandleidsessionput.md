---
title: PUT (/handles/{handle-id}/session)
assetID: d8a3d473-1192-ec0c-3935-c301f4f61e03
permalink: en-us/docs/xboxlive/rest/uri-handleshandleidsessionput.html
author: KevinAsgari
description: " PUT (/handles/{handle-id}/session)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 89572da87f4975aeeaa1ae7506a34f2b9cb4e72a
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4617970"
---
# <a name="put-handleshandle-idsession"></a><span data-ttu-id="44f4e-104">PUT (/handles/{handle-id}/session)</span><span class="sxs-lookup"><span data-stu-id="44f4e-104">PUT (/handles/{handle-id}/session)</span></span>
<span data-ttu-id="44f4e-105">作成またはハンドルを逆参照によってセッションを更新します。</span><span class="sxs-lookup"><span data-stu-id="44f4e-105">Creates or updates a session by dereferencing a handle.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="44f4e-106">このメソッドは、2015年マルチプレイヤーで使用し、および後でそのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="44f4e-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="44f4e-107">テンプレート コントラクト 104/105 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="44f4e-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="44f4e-108">注釈</span><span class="sxs-lookup"><span data-stu-id="44f4e-108">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="44f4e-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="44f4e-109">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="44f4e-110">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="44f4e-110">HTTP status codes</span></span>](#ID4ENB)
  * [<span data-ttu-id="44f4e-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="44f4e-111">Request body</span></span>](#ID4EUB)
  * [<span data-ttu-id="44f4e-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="44f4e-112">Response body</span></span>](#ID4E6B)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="44f4e-113">注釈</span><span class="sxs-lookup"><span data-stu-id="44f4e-113">Remarks</span></span>

<span data-ttu-id="44f4e-114">この HTTP/REST メソッドが提供されているセッション ハンドル ID を使用して、マルチプレイヤー サービスに新規または更新されたセッションを書き込みます</span><span class="sxs-lookup"><span data-stu-id="44f4e-114">This HTTP/REST method writes a new or updated session to the multiplayer service, using the supplied session handle ID.</span></span> <span data-ttu-id="44f4e-115">結果は、サーバーから返される新規または更新されたセッションを表すオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="44f4e-115">The result is an object representing the new or updated session as returned from the server.</span></span> <span data-ttu-id="44f4e-116">このメソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.WriteSessionByHandleAsync**でラップすることができます。</span><span class="sxs-lookup"><span data-stu-id="44f4e-116">This method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.WriteSessionByHandleAsync**.</span></span>

<span data-ttu-id="44f4e-117">このメソッドの呼び出し元では、プレイヤーの**MultiplayerActivityDetails**オブジェクトからハンドル ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="44f4e-117">The caller of this method obtains the handle ID from a player's **MultiplayerActivityDetails** object.</span></span> <span data-ttu-id="44f4e-118">または、呼び出し元は、ユーザーがゲームへの招待を受け入れた後、プロトコルのアクティブ化から ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="44f4e-118">Alternatively, the caller gets the ID from a protocol activation after a user has accepted a game invite.</span></span>

<a id="ID4ECB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="44f4e-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="44f4e-119">URI parameters</span></span>

| <span data-ttu-id="44f4e-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="44f4e-120">Parameter</span></span>| <span data-ttu-id="44f4e-121">型</span><span class="sxs-lookup"><span data-stu-id="44f4e-121">Type</span></span>| <span data-ttu-id="44f4e-122">説明</span><span class="sxs-lookup"><span data-stu-id="44f4e-122">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="44f4e-123">ハンドル id を使用</span><span class="sxs-lookup"><span data-stu-id="44f4e-123">handleId</span></span>| <span data-ttu-id="44f4e-124">GUID</span><span class="sxs-lookup"><span data-stu-id="44f4e-124">GUID</span></span>| <span data-ttu-id="44f4e-125">セッションのハンドルを一意の ID。</span><span class="sxs-lookup"><span data-stu-id="44f4e-125">The unique ID of the handle for the session.</span></span>|

<a id="ID4ENB"></a>


## <a name="http-status-codes"></a><span data-ttu-id="44f4e-126">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="44f4e-126">HTTP status codes</span></span>
<span data-ttu-id="44f4e-127">サービスは、MPSD に適用される、HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="44f4e-127">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EUB"></a>


## <a name="request-body"></a><span data-ttu-id="44f4e-128">要求本文</span><span class="sxs-lookup"><span data-stu-id="44f4e-128">Request body</span></span>

<span data-ttu-id="44f4e-129">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="44f4e-129">No objects are sent in the body of this request.</span></span>

<a id="ID4E6B"></a>


## <a name="response-body"></a><span data-ttu-id="44f4e-130">応答本文</span><span class="sxs-lookup"><span data-stu-id="44f4e-130">Response body</span></span>

<span data-ttu-id="44f4e-131">応答の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="44f4e-131">No objects are sent in the body of the response.</span></span>

<a id="ID4EKC"></a>


## <a name="see-also"></a><span data-ttu-id="44f4e-132">関連項目</span><span class="sxs-lookup"><span data-stu-id="44f4e-132">See also</span></span>

<a id="ID4EMC"></a>


##### <a name="parent"></a><span data-ttu-id="44f4e-133">Parent</span><span class="sxs-lookup"><span data-stu-id="44f4e-133">Parent</span></span>

[<span data-ttu-id="44f4e-134">/handles/{handleId}/session</span><span class="sxs-lookup"><span data-stu-id="44f4e-134">/handles/{handleId}/session</span></span>](uri-handleshandleidsession.md)
