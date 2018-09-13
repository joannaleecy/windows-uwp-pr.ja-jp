---
title: 取得する (/handles/{ハンドル id を使用}/セッション)
assetID: 1f22954c-e77b-69c2-63f4-741fbd965f8f
permalink: en-us/docs/xboxlive/rest/uri-handleshandleidsessionget.html
author: KevinAsgari
description: " 取得する (/handles/{ハンドル id を使用}/セッション)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0ab3214ca9b2cb2ff8ace11706ceda22885598e1
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3958915"
---
# <a name="get-handleshandleidsession"></a><span data-ttu-id="7c176-104">取得する (/handles/{ハンドル id を使用}/セッション)</span><span class="sxs-lookup"><span data-stu-id="7c176-104">GET (/handles/{handleId}/session)</span></span>
<span data-ttu-id="7c176-105">指定したハンドル識別子セッション オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="7c176-105">Gets a session object for the specified handle identifier.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="7c176-106">このメソッドは、2015年マルチプレイヤーで使用し、以降そのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="7c176-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="7c176-107">テンプレート コントラクト 104/105 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です: 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="7c176-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="7c176-108">注釈</span><span class="sxs-lookup"><span data-stu-id="7c176-108">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="7c176-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7c176-109">URI parameters</span></span>](#ID4EDB)
  * [<span data-ttu-id="7c176-110">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="7c176-110">HTTP status codes</span></span>](#ID4EOB)
  * [<span data-ttu-id="7c176-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="7c176-111">Request body</span></span>](#ID4EVB)
  * [<span data-ttu-id="7c176-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="7c176-112">Response body</span></span>](#ID4E6B)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="7c176-113">注釈</span><span class="sxs-lookup"><span data-stu-id="7c176-113">Remarks</span></span>

<span data-ttu-id="7c176-114">この HTTP/REST メソッドは、セッション (ハンドル) に指定されたサービス側ポインターを使用して、サーバーからセッション オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="7c176-114">This HTTP/REST method retrieves a session object from the server, using the supplied service-side pointer to the session (handle).</span></span> <span data-ttu-id="7c176-115">すべての属性を使用して、セッション オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="7c176-115">The return is the session object, with all its attributes.</span></span> <span data-ttu-id="7c176-116">このメソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionByHandleAsync**でラップすることができます。</span><span class="sxs-lookup"><span data-stu-id="7c176-116">This method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetCurrentSessionByHandleAsync**.</span></span>

<span data-ttu-id="7c176-117">このメソッドの呼び出し元では、プレイヤーの**MultiplayerActivityDetails**オブジェクトからハンドル ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="7c176-117">The caller of this method obtains the handle ID from a player's **MultiplayerActivityDetails** object.</span></span> <span data-ttu-id="7c176-118">または、呼び出し元は、ユーザーがゲームへの招待を受け入れた後、プロトコルのアクティブ化から ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="7c176-118">Alternatively, the caller gets the ID from a protocol activation after a user has accepted a game invite.</span></span>

<a id="ID4EDB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="7c176-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7c176-119">URI parameters</span></span>

| <span data-ttu-id="7c176-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="7c176-120">Parameter</span></span>| <span data-ttu-id="7c176-121">型</span><span class="sxs-lookup"><span data-stu-id="7c176-121">Type</span></span>| <span data-ttu-id="7c176-122">説明</span><span class="sxs-lookup"><span data-stu-id="7c176-122">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="7c176-123">ハンドル id を使用</span><span class="sxs-lookup"><span data-stu-id="7c176-123">handleId</span></span>| <span data-ttu-id="7c176-124">GUID</span><span class="sxs-lookup"><span data-stu-id="7c176-124">GUID</span></span>| <span data-ttu-id="7c176-125">セッション ハンドルの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="7c176-125">The unique ID of the handle for the session.</span></span>|

<a id="ID4EOB"></a>


## <a name="http-status-codes"></a><span data-ttu-id="7c176-126">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="7c176-126">HTTP status codes</span></span>
<span data-ttu-id="7c176-127">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="7c176-127">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EVB"></a>


## <a name="request-body"></a><span data-ttu-id="7c176-128">要求本文</span><span class="sxs-lookup"><span data-stu-id="7c176-128">Request body</span></span>

<span data-ttu-id="7c176-129">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="7c176-129">No objects are sent in the body of this request.</span></span>

<a id="ID4E6B"></a>


## <a name="response-body"></a><span data-ttu-id="7c176-130">応答本文</span><span class="sxs-lookup"><span data-stu-id="7c176-130">Response body</span></span>
<span data-ttu-id="7c176-131">[MultiplayerSession (JSON)](../../json/json-multiplayersession.md)の応答構造を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7c176-131">See the response structure in [MultiplayerSession (JSON)](../../json/json-multiplayersession.md).</span></span>  
<a id="ID4EIC"></a>


## <a name="see-also"></a><span data-ttu-id="7c176-132">関連項目</span><span class="sxs-lookup"><span data-stu-id="7c176-132">See also</span></span>

<a id="ID4EKC"></a>


##### <a name="parent"></a><span data-ttu-id="7c176-133">Parent</span><span class="sxs-lookup"><span data-stu-id="7c176-133">Parent</span></span>

[<span data-ttu-id="7c176-134">/handles/{ハンドル id を使用}/セッション</span><span class="sxs-lookup"><span data-stu-id="7c176-134">/handles/{handleId}/session</span></span>](uri-handleshandleidsession.md)
