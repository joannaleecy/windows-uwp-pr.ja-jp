---
title: MatchTicket (JSON)
assetID: 12617677-47f2-e517-af53-5ab9687eea2a
permalink: en-us/docs/xboxlive/rest/json-matchticket.html
description: " MatchTicket (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4bc638dfe7735856295ed92f35e244213be7bc1e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608337"
---
# <a name="matchticket-json"></a><span data-ttu-id="5cae0-104">MatchTicket (JSON)</span><span class="sxs-lookup"><span data-stu-id="5cae0-104">MatchTicket (JSON)</span></span>
<span data-ttu-id="5cae0-105">一致するチケット、プレイヤー、マルチ プレーヤーのセッション ディレクトリ (MPSD) を介して他のプレーヤーを見つけたりするために使用を表す JSON オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="5cae0-105">A JSON object representing a match ticket, used by players to locate other players through the multiplayer session directory (MPSD).</span></span> 
<a id="ID4EN"></a>

  
 
<span data-ttu-id="5cae0-106">MatchTicket JSON オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="5cae0-106">The MatchTicket JSON object has the following specification.</span></span>
 
| <span data-ttu-id="5cae0-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="5cae0-107">Member</span></span>| <span data-ttu-id="5cae0-108">種類</span><span class="sxs-lookup"><span data-stu-id="5cae0-108">Type</span></span>| <span data-ttu-id="5cae0-109">説明</span><span class="sxs-lookup"><span data-stu-id="5cae0-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="5cae0-110">serviceConfig</span><span class="sxs-lookup"><span data-stu-id="5cae0-110">serviceConfig</span></span>| <span data-ttu-id="5cae0-111">GUID</span><span class="sxs-lookup"><span data-stu-id="5cae0-111">GUID</span></span>| <span data-ttu-id="5cae0-112">セッションのサービス構成識別子 (SCID)。</span><span class="sxs-lookup"><span data-stu-id="5cae0-112">Service configuration identifier (SCID) for the session.</span></span>| 
| <span data-ttu-id="5cae0-113">hopperName</span><span class="sxs-lookup"><span data-stu-id="5cae0-113">hopperName</span></span>| <span data-ttu-id="5cae0-114">string</span><span class="sxs-lookup"><span data-stu-id="5cae0-114">string</span></span>| <span data-ttu-id="5cae0-115">このチケットの配置の hopper の名前です。</span><span class="sxs-lookup"><span data-stu-id="5cae0-115">Name of the hopper in which this ticket should be placed.</span></span>| 
| <span data-ttu-id="5cae0-116">giveUpDuration</span><span class="sxs-lookup"><span data-stu-id="5cae0-116">giveUpDuration</span></span>| <span data-ttu-id="5cae0-117">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="5cae0-117">32-bit signed integer</span></span>| <span data-ttu-id="5cae0-118">最大待機時間 (秒単位の整数)。</span><span class="sxs-lookup"><span data-stu-id="5cae0-118">Maximum wait time (integral number of seconds).</span></span>| 
| <span data-ttu-id="5cae0-119">preserveSession</span><span class="sxs-lookup"><span data-stu-id="5cae0-119">preserveSession</span></span>| <span data-ttu-id="5cae0-120">列挙</span><span class="sxs-lookup"><span data-stu-id="5cae0-120">enumeration</span></span>| <span data-ttu-id="5cae0-121">一致するセッションとしてセッションを再利用する必要があるかどうかを示す値。</span><span class="sxs-lookup"><span data-stu-id="5cae0-121">A value indicating if the session must be reused as the session into which to match.</span></span> <span data-ttu-id="5cae0-122">指定できる値は、"never"または「常に」です。</span><span class="sxs-lookup"><span data-stu-id="5cae0-122">Possible values are "always" or "never".</span></span> | 
| <span data-ttu-id="5cae0-123">ticketSessionRef</span><span class="sxs-lookup"><span data-stu-id="5cae0-123">ticketSessionRef</span></span>| <span data-ttu-id="5cae0-124">MultiplayerSessionReference</span><span class="sxs-lookup"><span data-stu-id="5cae0-124">MultiplayerSessionReference</span></span>| <span data-ttu-id="5cae0-125"><b>MultiplayerSessionReference</b>プレーヤーまたはグループが現在を再生中のセッションのオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="5cae0-125"><b>MultiplayerSessionReference</b> object for the session in which the player or group is currently playing.</span></span> <span data-ttu-id="5cae0-126">このメンバーが常に必要です。</span><span class="sxs-lookup"><span data-stu-id="5cae0-126">This member is always required.</span></span> | 
| <span data-ttu-id="5cae0-127">ticketAttributes</span><span class="sxs-lookup"><span data-stu-id="5cae0-127">ticketAttributes</span></span>| <span data-ttu-id="5cae0-128">オブジェクトの配列</span><span class="sxs-lookup"><span data-stu-id="5cae0-128">array of objects</span></span>| <span data-ttu-id="5cae0-129">プレイヤーのユーザーが指定した属性と、チケットに関する値のコレクションです。</span><span class="sxs-lookup"><span data-stu-id="5cae0-129">Collection of user-provided attributes and values about the tickets for the players.</span></span>| 
| <span data-ttu-id="5cae0-130">プレーヤー</span><span class="sxs-lookup"><span data-stu-id="5cae0-130">players</span></span>| <span data-ttu-id="5cae0-131">オブジェクトの配列</span><span class="sxs-lookup"><span data-stu-id="5cae0-131">array of objects</span></span>| <span data-ttu-id="5cae0-132">ユーザーが指定した属性のプロパティ バッグと各プレイヤーのオブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="5cae0-132">Collection of player objects, each with a property bag of user-provided attributes.</span></span> | 
  
<a id="ID4EW"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="5cae0-133">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="5cae0-133">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="5cae0-134">関連項目</span><span class="sxs-lookup"><span data-stu-id="5cae0-134">See also</span></span>
 
<a id="ID4EGB"></a>

 
##### <a name="parent"></a><span data-ttu-id="5cae0-135">Parent</span><span class="sxs-lookup"><span data-stu-id="5cae0-135">Parent</span></span> 

[<span data-ttu-id="5cae0-136">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="5cae0-136">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   