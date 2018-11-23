---
title: MatchTicket (JSON)
assetID: 12617677-47f2-e517-af53-5ab9687eea2a
permalink: en-us/docs/xboxlive/rest/json-matchticket.html
author: KevinAsgari
description: " MatchTicket (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5dbc410c809358c6df7a4eb2686b81c4017ed550
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7575025"
---
# <a name="matchticket-json"></a><span data-ttu-id="bc865-104">MatchTicket (JSON)</span><span class="sxs-lookup"><span data-stu-id="bc865-104">MatchTicket (JSON)</span></span>
<span data-ttu-id="bc865-105">プレイヤーがマルチプレイヤー セッション ディレクトリ (MPSD) を通じて他のプレイヤーを検索に使用するマッチ チケットを表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="bc865-105">A JSON object representing a match ticket, used by players to locate other players through the multiplayer session directory (MPSD).</span></span> 
<a id="ID4EN"></a>

  
 
<span data-ttu-id="bc865-106">MatchTicket JSON オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="bc865-106">The MatchTicket JSON object has the following specification.</span></span>
 
| <span data-ttu-id="bc865-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="bc865-107">Member</span></span>| <span data-ttu-id="bc865-108">種類</span><span class="sxs-lookup"><span data-stu-id="bc865-108">Type</span></span>| <span data-ttu-id="bc865-109">説明</span><span class="sxs-lookup"><span data-stu-id="bc865-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="bc865-110">serviceConfig</span><span class="sxs-lookup"><span data-stu-id="bc865-110">serviceConfig</span></span>| <span data-ttu-id="bc865-111">GUID</span><span class="sxs-lookup"><span data-stu-id="bc865-111">GUID</span></span>| <span data-ttu-id="bc865-112">セッションのサービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="bc865-112">Service configuration identifier (SCID) for the session.</span></span>| 
| <span data-ttu-id="bc865-113">hopperName</span><span class="sxs-lookup"><span data-stu-id="bc865-113">hopperName</span></span>| <span data-ttu-id="bc865-114">string</span><span class="sxs-lookup"><span data-stu-id="bc865-114">string</span></span>| <span data-ttu-id="bc865-115">このチケットを配置する必要があります、ホッパーの名前です。</span><span class="sxs-lookup"><span data-stu-id="bc865-115">Name of the hopper in which this ticket should be placed.</span></span>| 
| <span data-ttu-id="bc865-116">giveUpDuration</span><span class="sxs-lookup"><span data-stu-id="bc865-116">giveUpDuration</span></span>| <span data-ttu-id="bc865-117">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="bc865-117">32-bit signed integer</span></span>| <span data-ttu-id="bc865-118">最大待機時間 (秒の整数)。</span><span class="sxs-lookup"><span data-stu-id="bc865-118">Maximum wait time (integral number of seconds).</span></span>| 
| <span data-ttu-id="bc865-119">preserveSession</span><span class="sxs-lookup"><span data-stu-id="bc865-119">preserveSession</span></span>| <span data-ttu-id="bc865-120">列挙型</span><span class="sxs-lookup"><span data-stu-id="bc865-120">enumeration</span></span>| <span data-ttu-id="bc865-121">一致するセッションとして、セッションを再利用する必要があるかどうかを示す値。</span><span class="sxs-lookup"><span data-stu-id="bc865-121">A value indicating if the session must be reused as the session into which to match.</span></span> <span data-ttu-id="bc865-122">値は、「しない」または"always です"。</span><span class="sxs-lookup"><span data-stu-id="bc865-122">Possible values are "always" or "never".</span></span> | 
| <span data-ttu-id="bc865-123">ticketSessionRef</span><span class="sxs-lookup"><span data-stu-id="bc865-123">ticketSessionRef</span></span>| <span data-ttu-id="bc865-124">MultiplayerSessionReference</span><span class="sxs-lookup"><span data-stu-id="bc865-124">MultiplayerSessionReference</span></span>| <span data-ttu-id="bc865-125">これでプレイヤーまたはグループは、現在再生中のセッションの<b>MultiplayerSessionReference</b>オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="bc865-125"><b>MultiplayerSessionReference</b> object for the session in which the player or group is currently playing.</span></span> <span data-ttu-id="bc865-126">このメンバーは必須です。</span><span class="sxs-lookup"><span data-stu-id="bc865-126">This member is always required.</span></span> | 
| <span data-ttu-id="bc865-127">ticketAttributes</span><span class="sxs-lookup"><span data-stu-id="bc865-127">ticketAttributes</span></span>| <span data-ttu-id="bc865-128">オブジェクトの配列</span><span class="sxs-lookup"><span data-stu-id="bc865-128">array of objects</span></span>| <span data-ttu-id="bc865-129">プレイヤーのユーザーが指定の属性と値について、チケットのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="bc865-129">Collection of user-provided attributes and values about the tickets for the players.</span></span>| 
| <span data-ttu-id="bc865-130">プレイヤー</span><span class="sxs-lookup"><span data-stu-id="bc865-130">players</span></span>| <span data-ttu-id="bc865-131">オブジェクトの配列</span><span class="sxs-lookup"><span data-stu-id="bc865-131">array of objects</span></span>| <span data-ttu-id="bc865-132">ユーザー指定の属性のプロパティ バッグに各プレイヤーのオブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="bc865-132">Collection of player objects, each with a property bag of user-provided attributes.</span></span> | 
  
<a id="ID4EW"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="bc865-133">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="bc865-133">Sample JSON syntax</span></span>
 

```json
{
        "serviceConfig": "07617C5B-3423-4505-B6C6-10A16E1E5DDB",
        "hopperName": "TestHopper",
        "giveUpDuration": 10,
        "preserveSession": "never",
        "ticketSessionRef": {
        "scid": "AFFEABDF-0000-0000-0000-000000000001",
        "templateName": "TestTemplate",
        "sessionName": "5E551041-0000-0000-0000-000000000001"
    },
    "ticketAttributes": {
        "desiredMap": "Test Map",
        "desiredGameType": "Test GameType"
    },
    "players": [
        {
            "xuid": 123412345123,
            "playerAttributes": {
                "skill": 5,
                "ageRange": "teenager"
            }
        },
        {
          "xuid": 123412345124,
          "playerAttributes": {
              "skill": 15,
              "ageRange": "twenty-something"
          }
        }
      ]
    }
  
    
```

  
<a id="ID4EEB"></a>

 
## <a name="see-also"></a><span data-ttu-id="bc865-134">関連項目</span><span class="sxs-lookup"><span data-stu-id="bc865-134">See also</span></span>
 
<a id="ID4EGB"></a>

 
##### <a name="parent"></a><span data-ttu-id="bc865-135">Parent</span><span class="sxs-lookup"><span data-stu-id="bc865-135">Parent</span></span> 

[<span data-ttu-id="bc865-136">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="bc865-136">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   