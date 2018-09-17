---
title: PresenceRecord (JSON)
assetID: 414e6ef5-f7bd-70d0-7386-7aa1c3a56e21
permalink: en-us/docs/xboxlive/rest/json-presencerecord.html
author: KevinAsgari
description: " PresenceRecord (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c365760f68aa7c87422e747606175ae9a12f0574
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3981034"
---
# <a name="presencerecord-json"></a><span data-ttu-id="86f5a-104">PresenceRecord (JSON)</span><span class="sxs-lookup"><span data-stu-id="86f5a-104">PresenceRecord (JSON)</span></span>
<span data-ttu-id="86f5a-105">1 人のユーザーのオンライン プレゼンスに関するデータ。</span><span class="sxs-lookup"><span data-stu-id="86f5a-105">Data about the online presence of a single user.</span></span>
<a id="ID4EN"></a>


## <a name="presencerecord"></a><span data-ttu-id="86f5a-106">Presencerecord を要求して</span><span class="sxs-lookup"><span data-stu-id="86f5a-106">PresenceRecord</span></span>

<span data-ttu-id="86f5a-107">Presencerecord を要求してオブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="86f5a-107">The PresenceRecord object has the following specification.</span></span>

| <span data-ttu-id="86f5a-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="86f5a-108">Member</span></span>| <span data-ttu-id="86f5a-109">種類</span><span class="sxs-lookup"><span data-stu-id="86f5a-109">Type</span></span>| <span data-ttu-id="86f5a-110">説明</span><span class="sxs-lookup"><span data-stu-id="86f5a-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="86f5a-111">xuid</span><span class="sxs-lookup"><span data-stu-id="86f5a-111">xuid</span></span>| <span data-ttu-id="86f5a-112">string</span><span class="sxs-lookup"><span data-stu-id="86f5a-112">string</span></span>| <span data-ttu-id="86f5a-113">Xbox ユーザー ID (XUID) 対象ユーザーのします。</span><span class="sxs-lookup"><span data-stu-id="86f5a-113">The Xbox User ID (XUID) of the target user.</span></span> <span data-ttu-id="86f5a-114">このユーザーはプレゼンス データが提供されます。</span><span class="sxs-lookup"><span data-stu-id="86f5a-114">The presence data provided is for this user.</span></span>|
| <span data-ttu-id="86f5a-115">devices</span><span class="sxs-lookup"><span data-stu-id="86f5a-115">devices</span></span>| <span data-ttu-id="86f5a-116">[DeviceRecord](json-devicerecord.md)の配列</span><span class="sxs-lookup"><span data-stu-id="86f5a-116">array of [DeviceRecord](json-devicerecord.md)</span></span>| <span data-ttu-id="86f5a-117">ユーザーのデバイスのレコードの一覧です。</span><span class="sxs-lookup"><span data-stu-id="86f5a-117">List of the user's device records.</span></span>|
| <span data-ttu-id="86f5a-118">状態</span><span class="sxs-lookup"><span data-stu-id="86f5a-118">state</span></span>| <span data-ttu-id="86f5a-119">string</span><span class="sxs-lookup"><span data-stu-id="86f5a-119">string</span></span>| <span data-ttu-id="86f5a-120">Xbox live ユーザーのアクティビティ。</span><span class="sxs-lookup"><span data-stu-id="86f5a-120">User's activity on Xbox LIVE.</span></span> <span data-ttu-id="86f5a-121">設定可能な値:</span><span class="sxs-lookup"><span data-stu-id="86f5a-121">Possible values:</span></span> <ul><li><span data-ttu-id="86f5a-122">オンライン: ユーザーは、少なくとも 1 つのデバイスのレコードを持っています。</span><span class="sxs-lookup"><span data-stu-id="86f5a-122">Online: User has at least one device record.</span></span></li><li><span data-ttu-id="86f5a-123">離れた: ユーザーが Xbox LIVE にサインインした任意のタイトルでアクティブではありません。</span><span class="sxs-lookup"><span data-stu-id="86f5a-123">Away: User is signed into Xbox LIVE but not active in any title.</span></span></li><li><span data-ttu-id="86f5a-124">オフライン: ユーザーは、任意のデバイスに存在しません。</span><span class="sxs-lookup"><span data-stu-id="86f5a-124">Offline: User is not present on any device.</span></span></li></ul> | 
| <span data-ttu-id="86f5a-125">lastSeen</span><span class="sxs-lookup"><span data-stu-id="86f5a-125">lastSeen</span></span>| [<span data-ttu-id="86f5a-126">LastSeenRecord</span><span class="sxs-lookup"><span data-stu-id="86f5a-126">LastSeenRecord</span></span>](json-lastseenrecord.md)| <span data-ttu-id="86f5a-127">最後に検出された情報は、ユーザーの有効な DeviceRecords があるない場合のみ利用できます。</span><span class="sxs-lookup"><span data-stu-id="86f5a-127">The last seen information is only available when the user has no valid DeviceRecords.</span></span> <span data-ttu-id="86f5a-128">オブジェクトは、キャッシュから削除された場合、データは返されません、永続的なストアがないためです。</span><span class="sxs-lookup"><span data-stu-id="86f5a-128">If the object was removed from the cache, its data might not be returned, because there is no persistent store.</span></span>|

<a id="ID4E2C"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="86f5a-129">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="86f5a-129">Sample JSON syntax</span></span>


```json
{
  xuid:"0123456789",
  state:"online",
  devices:
  [{
    type:"D",
    titles:
    [{
      id:"12341234",
      name:"Contoso 5",
      state:"active",
      placement:"fill",
      timestamp:"2012-09-17T07:15:23.4930000",
      activity:
      {
        richPresence:"Team Deathmatch on Nirvana"
      }
    },
    {
      id:"12341235",
      name:"Contoso Waypoint",
      timestamp:"2012-09-17T07:15:23.4930000",
      placement:"snapped",
      state:"active",
      activity:
      {
        richPresence:"Using radar"
      }
    }]
  },
  {
    type:"W8",
    titles:
    [{
      id:"23452345",
      name:"Contoso Gamehelp",
      state:"active",
      placement:"full",
      timestamp:"2012-09-17T07:15:23.4930000",
      activity:
      {
        richPresence:"Nirvana page"
      }
    }]
  }]
}

```


<a id="ID4EED"></a>


## <a name="see-also"></a><span data-ttu-id="86f5a-130">関連項目</span><span class="sxs-lookup"><span data-stu-id="86f5a-130">See also</span></span>

<a id="ID4EGD"></a>


##### <a name="parent"></a><span data-ttu-id="86f5a-131">Parent</span><span class="sxs-lookup"><span data-stu-id="86f5a-131">Parent</span></span>

[<span data-ttu-id="86f5a-132">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="86f5a-132">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)


<a id="ID4EQD"></a>


##### <a name="reference"></a><span data-ttu-id="86f5a-133">リファレンス</span><span class="sxs-lookup"><span data-stu-id="86f5a-133">Reference</span></span>

[<span data-ttu-id="86f5a-134">POST (/users/batch)</span><span class="sxs-lookup"><span data-stu-id="86f5a-134">POST (/users/batch)</span></span>](../uri/presence/uri-usersbatchpost.md)

 [<span data-ttu-id="86f5a-135">GET (/users/me)</span><span class="sxs-lookup"><span data-stu-id="86f5a-135">GET (/users/me)</span></span>](../uri/presence/uri-usersmeget.md)

 [<span data-ttu-id="86f5a-136">DELETE (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="86f5a-136">DELETE (/users/xuid({xuid})/devices/current/titles/current)</span></span>](../uri/presence/uri-usersxuiddevicescurrenttitlescurrentdelete.md)

 [<span data-ttu-id="86f5a-137">GET (/users/xuid({xuid}))</span><span class="sxs-lookup"><span data-stu-id="86f5a-137">GET (/users/xuid({xuid}))</span></span>](../uri/presence/uri-usersxuidget.md)
