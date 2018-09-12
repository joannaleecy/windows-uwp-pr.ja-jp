---
title: MultiplayerSessionRequest (JSON)
assetID: 2e311c6d-3427-5a39-1989-06dc08483057
permalink: en-us/docs/xboxlive/rest/json-multiplayersessionrequest.html
author: KevinAsgari
description: " MultiplayerSessionRequest (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d7c2cb3ca95524b49ea6e0cbe14771036a3e6925
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882422"
---
# <a name="multiplayersessionrequest-json"></a><span data-ttu-id="7210f-104">MultiplayerSessionRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="7210f-104">MultiplayerSessionRequest (JSON)</span></span>
<span data-ttu-id="7210f-105">**MultiplayerSession**オブジェクトで操作の要求の JSON オブジェクトが渡されます。</span><span class="sxs-lookup"><span data-stu-id="7210f-105">The request JSON object passed for an operation on a **MultiplayerSession** object.</span></span> 
<a id="ID4EQ"></a>

  
 
<span data-ttu-id="7210f-106">MultiplayerSessionRequest JSON オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="7210f-106">The MultiplayerSessionRequest JSON object has the following specification.</span></span>
 
| <span data-ttu-id="7210f-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="7210f-107">Member</span></span>| <span data-ttu-id="7210f-108">種類</span><span class="sxs-lookup"><span data-stu-id="7210f-108">Type</span></span>| <span data-ttu-id="7210f-109">説明</span><span class="sxs-lookup"><span data-stu-id="7210f-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="7210f-110">定数</span><span class="sxs-lookup"><span data-stu-id="7210f-110">constants</span></span>| <span data-ttu-id="7210f-111">object</span><span class="sxs-lookup"><span data-stu-id="7210f-111">object</span></span>| <span data-ttu-id="7210f-112">セッションの定数を生成するセッション テンプレートと結合された読み取り専用の設定。</span><span class="sxs-lookup"><span data-stu-id="7210f-112">Read-only settings that are merged with the session template to produce the constants for the session.</span></span> | 
| <span data-ttu-id="7210f-113">プロパティ</span><span class="sxs-lookup"><span data-stu-id="7210f-113">properties</span></span> | <span data-ttu-id="7210f-114">object</span><span class="sxs-lookup"><span data-stu-id="7210f-114">object</span></span> | <span data-ttu-id="7210f-115">セッションのプロパティに結合できることになります。</span><span class="sxs-lookup"><span data-stu-id="7210f-115">Changes to be merged into the session properties.</span></span>| 
| <span data-ttu-id="7210f-116">members.me</span><span class="sxs-lookup"><span data-stu-id="7210f-116">members.me</span></span> | <span data-ttu-id="7210f-117">object</span><span class="sxs-lookup"><span data-stu-id="7210f-117">object</span></span>| <span data-ttu-id="7210f-118">定数と機能の多くのプロパティなどの最上位の相当します。</span><span class="sxs-lookup"><span data-stu-id="7210f-118">Constants and properties that work much like their top-level counterparts.</span></span> <span data-ttu-id="7210f-119">PUT メソッドでは、ユーザーに、セッションのメンバーである必要があり、必要に応じて、ユーザーを追加します。</span><span class="sxs-lookup"><span data-stu-id="7210f-119">Any PUT method requires the user to be a member of the session, and adds the user if necessary.</span></span> <span data-ttu-id="7210f-120">"Me"が null として指定されている場合は、要求を行っているメンバーがセッションから削除されます。</span><span class="sxs-lookup"><span data-stu-id="7210f-120">If "me" is specified as null, the member making the request is removed from the session.</span></span> | 
| <span data-ttu-id="7210f-121">メンバー</span><span class="sxs-lookup"><span data-stu-id="7210f-121">members</span></span> | <span data-ttu-id="7210f-122">object</span><span class="sxs-lookup"><span data-stu-id="7210f-122">object</span></span>| <span data-ttu-id="7210f-123">0 から始まるインデックスでキーを持つ、セッションに追加するユーザーを表すその他のオブジェクトの数。</span><span class="sxs-lookup"><span data-stu-id="7210f-123">Other objects that represent users to add to the session, keyed by a zero-based index.</span></span> <span data-ttu-id="7210f-124">既にセッションには、メンバーが含まれている場合でも、要求内のメンバーの数は常に 0 で始まります。</span><span class="sxs-lookup"><span data-stu-id="7210f-124">The number of members in a request always starts with 0, even if the session already contains members.</span></span> <span data-ttu-id="7210f-125">メンバーは、要求で表示される順序でセッションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="7210f-125">Members are added to the session in the order in which they appear in the request.</span></span> <span data-ttu-id="7210f-126">メンバーのプロパティは、先に属しているユーザーでのみ設定できます。</span><span class="sxs-lookup"><span data-stu-id="7210f-126">Member properties can only be set by the user to whom they belong.</span></span> | 
| <span data-ttu-id="7210f-127">サーバー</span><span class="sxs-lookup"><span data-stu-id="7210f-127">servers</span></span> | <span data-ttu-id="7210f-128">object</span><span class="sxs-lookup"><span data-stu-id="7210f-128">object</span></span>| <span data-ttu-id="7210f-129">関連付けられているサーバーの参加者のセットに更新プログラムと、セッションに追加されたことを示す値。</span><span class="sxs-lookup"><span data-stu-id="7210f-129">Values indicating updates and additions to the session's set of associated server participants.</span></span> <span data-ttu-id="7210f-130">サーバーが null として指定されている場合、そのサーバーのエントリは、セッションから削除されます。</span><span class="sxs-lookup"><span data-stu-id="7210f-130">If a server is specified as null, that server entry is removed from the session.</span></span> | 
  
<a id="ID4EZ"></a>

 
## <a name="request-structure"></a><span data-ttu-id="7210f-131">要求の構造</span><span class="sxs-lookup"><span data-stu-id="7210f-131">Request Structure</span></span>
 

```json
{
  "constants": { /* Property Bag */ },
  "properties": { /* Property Bag */ },
  "members": {
    // Requires a service principal. Existing members can be deleted by index.
    // Not available on large sessions.
    "5": null,

    // Reservation requests must start with zero. New users will get added in order to the end of the session's member list.
    // Large sessions don't support reservations.
    "reserve_0": {
      "constants": { /* Property Bag */ }
    },
    "reserve_1": {
      "constants": { /* Property Bag */ }
    },

    // Requires a user principal with a xuid claim. Can be 'null' to remove myself from the session.
    "me": {
      "constants": { /* Property Bag */ },
      "properties": { /* Property Bag */ },
    }
  },

  // Requires a server principal.
  "servers": {
    // Can be any name. The value can be 'null' to remove the server from the session.
    "name": {
      "constants": {  /* Property Bag */ },
      "properties": {  /* Property Bag */ }
    }
  }
}
```

  
<a id="ID4EAB"></a>

 
## <a name="see-also"></a><span data-ttu-id="7210f-132">関連項目</span><span class="sxs-lookup"><span data-stu-id="7210f-132">See also</span></span>
 
<a id="ID4ECB"></a>

 
##### <a name="parent"></a><span data-ttu-id="7210f-133">Parent</span><span class="sxs-lookup"><span data-stu-id="7210f-133">Parent</span></span> 

[<span data-ttu-id="7210f-134">JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="7210f-134">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EMB"></a>

 
##### <a name="reference"></a><span data-ttu-id="7210f-135">リファレンス</span><span class="sxs-lookup"><span data-stu-id="7210f-135">Reference</span></span> 

[<span data-ttu-id="7210f-136">MultiplayerSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="7210f-136">MultiplayerSession (JSON)</span></span>](json-multiplayersession.md)

 [<span data-ttu-id="7210f-137">PUT (/serviceconfigs/sessiontemplates/{sessionTemplateName}/sessions/{セッション})</span><span class="sxs-lookup"><span data-stu-id="7210f-137">PUT (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName})</span></span>](../uri/sessiondirectory/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameput.md)

   