---
title: 投稿 (/処理)
assetID: 21f3e289-0b0e-2731-befb-bd4c0d71973e
permalink: en-us/docs/xboxlive/rest/uri-handlespost.html
author: KevinAsgari
description: " 投稿 (/処理)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4eaddef523fcfa3b794c421acbe6c1aac4785b68
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3931333"
---
# <a name="post-handles"></a><span data-ttu-id="0366c-104">投稿 (/処理)</span><span class="sxs-lookup"><span data-stu-id="0366c-104">POST (/handles)</span></span>
<span data-ttu-id="0366c-105">ユーザーの現在のアクティビティのマルチプレイヤー セッションを設定し、必要な場合は、セッション メンバーを招待します。</span><span class="sxs-lookup"><span data-stu-id="0366c-105">Sets the multiplayer session for the user's current activity, and invites session members if required.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="0366c-106">このメソッドは、2015年マルチプレイヤーで使用し、以降そのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="0366c-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="0366c-107">テンプレート コントラクト 104/105 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です: 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="0366c-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="0366c-108">注釈</span><span class="sxs-lookup"><span data-stu-id="0366c-108">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="0366c-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0366c-109">URI parameters</span></span>](#ID4EHB)
  * [<span data-ttu-id="0366c-110">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="0366c-110">HTTP status codes</span></span>](#ID4EPB)
  * [<span data-ttu-id="0366c-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="0366c-111">Request body</span></span>](#ID4EVB)
  * [<span data-ttu-id="0366c-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="0366c-112">Response body</span></span>](#ID4EJC)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="0366c-113">注釈</span><span class="sxs-lookup"><span data-stu-id="0366c-113">Remarks</span></span>

<span data-ttu-id="0366c-114">現在のアクティビティのセッションを設定するは、この HTTP/REST メソッドを使用できます。</span><span class="sxs-lookup"><span data-stu-id="0366c-114">This HTTP/REST method can be used to set the session for current activity.</span></span> <span data-ttu-id="0366c-115">この場合、メソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.SetActivityAsync**でラップすることができます。</span><span class="sxs-lookup"><span data-stu-id="0366c-115">In this case, the method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.SetActivityAsync**.</span></span> <span data-ttu-id="0366c-116">要求本文には、「アクティビティ」の種類] フィールドに、JSON ファイルで**sessionRef**オブジェクトを使用して、セッションの参照を定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0366c-116">The request body must define the session reference, using the **sessionRef** object in the JSON file, with the type field to "activity".</span></span> <span data-ttu-id="0366c-117">応答本文は取得されません。</span><span class="sxs-lookup"><span data-stu-id="0366c-117">No response body is retrieved.</span></span> <span data-ttu-id="0366c-118">セッション参照で指定された項目の定義、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionReference**を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0366c-118">For definitions of the items specified in a session reference, see **Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionReference**.</span></span>

<span data-ttu-id="0366c-119">この POST メソッドは、セッションへのハンドルによって指定されたユーザーを招待するも使用できます。</span><span class="sxs-lookup"><span data-stu-id="0366c-119">This POST method can also be used to invite users specified by the handles to a session.</span></span> <span data-ttu-id="0366c-120">この場合、メソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.SendInvitesAsync**でラップすることができます。</span><span class="sxs-lookup"><span data-stu-id="0366c-120">In this case, the method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.SendInvitesAsync**.</span></span> <span data-ttu-id="0366c-121">このような POST メソッドの使用には、セッションの参照を定義する、要求本文が必要ですが、型フィールド「招待」に設定します。</span><span class="sxs-lookup"><span data-stu-id="0366c-121">This use of the POST method requires your request body to define the session reference, but with the type field set to "invite".</span></span> <span data-ttu-id="0366c-122">応答本文では、招待ハンドルです。</span><span class="sxs-lookup"><span data-stu-id="0366c-122">The response body is an invite handle.</span></span>

<a id="ID4EHB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="0366c-123">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0366c-123">URI parameters</span></span>

<span data-ttu-id="0366c-124">なし</span><span class="sxs-lookup"><span data-stu-id="0366c-124">None</span></span>

<a id="ID4EPB"></a>


## <a name="http-status-codes"></a><span data-ttu-id="0366c-125">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="0366c-125">HTTP status codes</span></span>
<span data-ttu-id="0366c-126">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="0366c-126">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EVB"></a>


## <a name="request-body"></a><span data-ttu-id="0366c-127">要求本文</span><span class="sxs-lookup"><span data-stu-id="0366c-127">Request body</span></span>

<a id="ID4E1B"></a>


### <a name="request-body-for-setting-activity"></a><span data-ttu-id="0366c-128">要求本文のアクティビティを設定します。</span><span class="sxs-lookup"><span data-stu-id="0366c-128">Request body for setting activity</span></span>


```cpp
{
  "version": 1,
  "type": "activity",
  "sessionRef": {
    "scid": "bd6c41c3-01c3-468a-a3b5-3e0fe8133862",
    "templateName": "deathmatch",
    // The session name is optional in a POST; if not specified, MPSD fills in a GUID.//
    "name": "session-49"
  },
}

```


<a id="ID4EBC"></a>


### <a name="request-body-for-sending-invites"></a><span data-ttu-id="0366c-129">招待を送信するための要求本文</span><span class="sxs-lookup"><span data-stu-id="0366c-129">Request body for sending invites</span></span>


```cpp
{
  // Common handle fields
  "id: "47ca0049-a5ba-4bc1-aa22-fcf834ce4c13",
  "version": 1,
  "type": "invite",
  "sessionRef": {
    "scid": "bd6c41c3-01c3-468a-a3b5-3e0fe8133862",
    "templateName": "deathmatch",
    "name": "session-49"
   },
   "inviteAttributes": {
     "titleId" : {titleId}, // The title being invited to, in decimal uint32. This value is used to find the title name and/or image.
     "context" : {context}, // The title defined context token. Must be 256 characters or less when URI-encoded.
     "contextString" : {contextstring}, // The string name of a custom invite string to display in the invite notification.
     "senderString" : {sender} // The string name of the sender when the sender is a service.
   },
   "invitedXuid": "3210",
}

```


<a id="ID4EJC"></a>


## <a name="response-body"></a><span data-ttu-id="0366c-130">応答本文</span><span class="sxs-lookup"><span data-stu-id="0366c-130">Response body</span></span>

<a id="ID4EOC"></a>


### <a name="response-body-for-setting-activity"></a><span data-ttu-id="0366c-131">アクティビティを設定するための応答本文</span><span class="sxs-lookup"><span data-stu-id="0366c-131">Response body for setting activity</span></span>
<span data-ttu-id="0366c-132">なし。</span><span class="sxs-lookup"><span data-stu-id="0366c-132">None.</span></span>  
<a id="ID4ESC"></a>


### <a name="response-body-for-sending-invites"></a><span data-ttu-id="0366c-133">招待を送信するための応答本文</span><span class="sxs-lookup"><span data-stu-id="0366c-133">Response body for sending invites</span></span>
<span data-ttu-id="0366c-134">招待ハンドル。</span><span class="sxs-lookup"><span data-stu-id="0366c-134">An invite handle.</span></span>   
<a id="ID4EXC"></a>


## <a name="see-also"></a><span data-ttu-id="0366c-135">関連項目</span><span class="sxs-lookup"><span data-stu-id="0366c-135">See also</span></span>

<a id="ID4EZC"></a>


##### <a name="parent"></a><span data-ttu-id="0366c-136">Parent</span><span class="sxs-lookup"><span data-stu-id="0366c-136">Parent</span></span>

[<span data-ttu-id="0366c-137">/handles</span><span class="sxs-lookup"><span data-stu-id="0366c-137">/handles</span></span>](uri-handles.md)
