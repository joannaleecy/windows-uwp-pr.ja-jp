---
title: 大規模なセッション
author: KevinAsgari
description: Xbox Live マルチプレイヤー プラットフォームで大規模なセッションを使用する方法について説明します。
ms.author: kevinasg
ms.date: 07/11/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー, 大規模なセッション, 最近のプレイヤー
ms.localizationpriority: medium
ms.openlocfilehash: cead1a3ca1d56185ef97fe3f3271484bfbc58f18
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4619182"
---
# <a name="large-sessions"></a><span data-ttu-id="dddd5-104">大規模なセッション</span><span class="sxs-lookup"><span data-stu-id="dddd5-104">Large sessions</span></span>

<span data-ttu-id="dddd5-105">100 人を超えるメンバーを処理できるマルチプレイヤー セッションが必要な場合は、"大規模なセッション" を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dddd5-105">If you need a multiplayer session that can handle more than 100 members, you'll need to use what is known as a large session.</span></span> <span data-ttu-id="dddd5-106">このシナリオは、大規模マルチプレイヤー オンライン (MMO) のゲームやブロードキャスト (この場合はメンバーの大半が観戦者になります) への適用が最も一般的ですが、他のスタイルのゲームにも応用できることがあります。</span><span class="sxs-lookup"><span data-stu-id="dddd5-106">This scenario is most common to massively multiplayer online (MMO) games and broadcasts (where most of the members are spectators), but may have applications to other styles of games as well.</span></span>

<span data-ttu-id="dddd5-107">状況によっては、もっと少数のプレイヤー グループを扱う場合にも大規模なセッションを使用できます。</span><span class="sxs-lookup"><span data-stu-id="dddd5-107">In some circumstances, you may also wish to use large sessions even when dealing with smaller groups of players.</span></span> <span data-ttu-id="dddd5-108">同じセッションに複数のプレイヤーが参加しても、ゲーム内で遭遇しなければ互いに知らなくても良いという場合は、大規模なセッションの "encounters" プロパティを使用できます。</span><span class="sxs-lookup"><span data-stu-id="dddd5-108">If you want multiple players to be in the same session, but not necessarily be aware of each other if they don't encounter each other in game, you can use the "encounters" property of large sessions.</span></span>

<span data-ttu-id="dddd5-109">現在、[Xbox Integrated Multiplayer (XIM)](../xbox-integrated-multiplayer.md) や [Multiplayer Manager (MPM)](../multiplayer-manager.md) では大規模なセッションがサポートされていないため、Multiplayer 2015 API を使用してマルチプレイヤー サービス ディレクトリ (MPSD) の直接呼び出しを行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="dddd5-109">Large sessions are not currently supported by [Xbox Integrated Multiplayer (XIM)](../xbox-integrated-multiplayer.md) or by [Multiplayer Manager (MPM)](../multiplayer-manager.md), so you must use the Multiplayer 2015 APIs to use direct calls to the Multiplayer Service Directory (MPSD).</span></span>

<span data-ttu-id="dddd5-110">大規模なセッションの扱いは、通常のセッションとは若干異なります。</span><span class="sxs-lookup"><span data-stu-id="dddd5-110">Large sessions are treated slightly differently than regular sessions:</span></span>

* <span data-ttu-id="dddd5-111">通常のセッションより格納できる情報量は少なくなりますが、効率的です。</span><span class="sxs-lookup"><span data-stu-id="dddd5-111">Contains less information than regular sessions, but are more efficient.</span></span>
* <span data-ttu-id="dddd5-112">最大 10,000 人のメンバーがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="dddd5-112">Supports up to 10,000 members.</span></span>
* <span data-ttu-id="dddd5-113">大規模なセッションをサブスクライブすることはできません。</span><span class="sxs-lookup"><span data-stu-id="dddd5-113">You cannot subscribe to a large session.</span></span>
* <span data-ttu-id="dddd5-114">大規模なセッションのメンバーは、自動的にはプレイヤーの履歴 (最近のプレイヤー) 一覧に含まれません。</span><span class="sxs-lookup"><span data-stu-id="dddd5-114">There is no automatic inclusion into the recent player lists for members of a large session.</span></span>

## <a name="recent-players"></a><span data-ttu-id="dddd5-115">プレイヤーの履歴</span><span class="sxs-lookup"><span data-stu-id="dddd5-115">Recent players</span></span>

<span data-ttu-id="dddd5-116">Xbox Live の機能の 1 つは、Xbox Live プレイヤーがマルチプレイヤー ゲームを新しいユーザーとプレイする場合、ゲームの後に、これらのプレイヤーがダッシュボードの **[プレイヤーの履歴]** 一覧に表示されることです。</span><span class="sxs-lookup"><span data-stu-id="dddd5-116">One of the features of Xbox Live is that when Xbox Live players play multiplayer games with new people, after the game they can see those players on their dashboard in the **recent players** list.</span></span> <span data-ttu-id="dddd5-117">プレイヤーが新しいプレイヤーと楽しくゲームをプレイできた場合は、これらのプレイヤーと再度プレイしたり、フレンドに追加することができます。</span><span class="sxs-lookup"><span data-stu-id="dddd5-117">If a player had a great experience with a new player in a game, they may want to play with them again, or add them as a friend.</span></span> <span data-ttu-id="dddd5-118">あるプレイヤーとプレイした際に楽しくなかった場合は、今後はこれらのプレイヤーとのプレイを避けたり、ゲームの終了後にそのプレイヤーの不快な行為を報告することもできます。</span><span class="sxs-lookup"><span data-stu-id="dddd5-118">If they had a poor experience with a player, they may wish to avoid them in the future, and/or report the bad behavior after the game is over.</span></span>

<span data-ttu-id="dddd5-119">通常のセッションでは、同じセッションのプレイヤーが Xbox Live によって自動的にプレイヤーの履歴一覧に追加されます。</span><span class="sxs-lookup"><span data-stu-id="dddd5-119">With regular sessions, Xbox Live automatically adds players in the same session to the recent players list.</span></span> <span data-ttu-id="dddd5-120">大規模なセッションでは、プレイヤーの履歴一覧が正しく設定されているか確認するには、追加の手順が必要になります。</span><span class="sxs-lookup"><span data-stu-id="dddd5-120">If you use large sessions however, you must take some extra steps to ensure that the recent player lists are properly populated.</span></span>

## <a name="set-up-a-large-session"></a><span data-ttu-id="dddd5-121">大規模なセッションのセットアップ</span><span class="sxs-lookup"><span data-stu-id="dddd5-121">Set up a large session</span></span>

<span data-ttu-id="dddd5-122">大規模なセッションをセットアップするには、セッション テンプレートの capabilities セクションに `“large”: true` を追加します。</span><span class="sxs-lookup"><span data-stu-id="dddd5-122">To set sessions up as large, add `“large”: true` to the capabilities section in the session template.</span></span> <span data-ttu-id="dddd5-123">これにより、`maxMembersCount` に 10,000 までの値を設定できます。</span><span class="sxs-lookup"><span data-stu-id="dddd5-123">That lets you set the `maxMembersCount` up to 10,000.</span></span> <span data-ttu-id="dddd5-124">次のようなセッション テンプレートを使用できます。</span><span class="sxs-lookup"><span data-stu-id="dddd5-124">A session template like the below should work:</span></span>

```json
{
    "constants": {
        "system": {
            "version": 1,
            "maxMembersCount": 2000,
            "visibility": "open",
            "capabilities": {
                "gameplay": true,
                "large": true
            },
            "timeouts": {
                "inactive": 0,
                "ready": 180000,
                "sessionEmpty": 0
            }
        },
        "custom": { }
    }
}
```

## <a name="working-with-large-sessions"></a><span data-ttu-id="dddd5-125">大規模なセッションの操作</span><span class="sxs-lookup"><span data-stu-id="dddd5-125">Working with large sessions</span></span>

<span data-ttu-id="dddd5-126">大規模なセッションを MPSD に書き込む場合、1 秒あたりの書き込みが 10 件を超えないようにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="dddd5-126">When writing large sessions to MPSD, we recommend that you do not to exceed 10 writes per second.</span></span> <span data-ttu-id="dddd5-127">これは、1000 プレイヤーのセッションで各プレイヤーの書き込み (参加/退出など) が 2 分ごとに発生することを想定した場合の一般的な設定です。</span><span class="sxs-lookup"><span data-stu-id="dddd5-127">This is typically a 1000 player session with a write every 2 minutes on average per player (e.g. join/leave).</span></span>

<span data-ttu-id="dddd5-128">その他のプロパティは、大規模なセッションでは管理しないでください。</span><span class="sxs-lookup"><span data-stu-id="dddd5-128">Other properties should not be maintained in the large sessions.</span></span>

### <a name="associating-players-from-the-same-large-session"></a><span data-ttu-id="dddd5-129">同じ大規模セッションのプレイヤーどうしを関連付ける</span><span class="sxs-lookup"><span data-stu-id="dddd5-129">Associating players from the same large session</span></span>

<span data-ttu-id="dddd5-130">MPSD から大規模なセッションを取得する場合、応答と共にメンバーの一覧が返されず、完全な一覧を取得する方法はありません。</span><span class="sxs-lookup"><span data-stu-id="dddd5-130">When you retrieve a large session from MPSD, the list of members doesn't come back with the response, and in fact there’s no way to get the full list.</span></span> <span data-ttu-id="dddd5-131">呼び出し元がセッションに参加している場合、"members" コレクション内にあるのは、そのメンバーのメンバー レコードのみです (要求内の場合と同様、"me" というラベルが付いています)。</span><span class="sxs-lookup"><span data-stu-id="dddd5-131">Instead, if the caller is in the session, their member record will be the only one in the “members” collection, labelled as “me” (just like in the request).</span></span>

<span data-ttu-id="dddd5-132">つまり、クライアント メンバーがセッション内で更新できるのは自身のエントリのみです。一緒にプレイしたプレイヤーどうしを関連付けるために Xbox Live で使用できる共通の識別子は、サーバーから取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dddd5-132">This means that clients members will only be able to update their own entry in the session, and will rely on the server to provide them with a common identifier that Xbox Live can use to associate players that played together.</span></span>

<span data-ttu-id="dddd5-133">セッションで一緒にプレイしたユーザーを示す方法 (評判や最近のプレイヤーの状態を更新する目的で必要になります) は 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="dddd5-133">There are two ways to indicate that people in a session played together (for updating reputation and recent players status).</span></span>

#### <a name="1-persistent-groups"></a><span data-ttu-id="dddd5-134">1. 永続的なグループの場合</span><span class="sxs-lookup"><span data-stu-id="dddd5-134">1. Persistent groups</span></span>

<span data-ttu-id="dddd5-135">ユーザーのグループが継続的に行動を共にしている場合 (ユーザーの参加や退出は可能)、そのグループに名前を付けることができます (通常のセッションについては同じ名前付け規則に従い、guid などを使用します)。</span><span class="sxs-lookup"><span data-stu-id="dddd5-135">If a group of people is staying together on an ongoing basis, potentially with people coming and going from it, you can give the group a name (for example, a guid – following the same naming rules as for regular sessions).</span></span>  <span data-ttu-id="dddd5-136">各メンバーがグループに参加またはグループから退出する際には、このグループ名を自身の "groups" プロパティ (文字列の配列) に対して追加または削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dddd5-136">As each member comes and goes from the group, they should add or remove the group name to their own “groups” property, which is an array of strings:</span></span>

```json
{
    "members": {
        "me": {
            "properties": {
                "system": {
                    "groups": [ "boffins-posse" ]
                }
            }
        }
    }
}
```

#### <a name="2-brief-encounters"></a><span data-ttu-id="dddd5-137">2. 一時的な遭遇の場合</span><span class="sxs-lookup"><span data-stu-id="dddd5-137">2. Brief encounters</span></span>

<span data-ttu-id="dddd5-138">2 人のユーザーが一時的に遭遇した場合、ゲームでは "encounters" 配列を使用します。</span><span class="sxs-lookup"><span data-stu-id="dddd5-138">If two people have a brief one-time encounter, the game can instead use the “encounters” array.</span></span> <span data-ttu-id="dddd5-139">各遭遇に名前を付けておき、遭遇の後、両方 (すべて) の参加者はその名前を自身の "encounters" に書き込みます。</span><span class="sxs-lookup"><span data-stu-id="dddd5-139">Give each encounter a name, and after the encounter, both (or all) participants would write the name to their own “encounters” property:</span></span>

```json
{
    "members": {
        "me": {
            "properties": {
                "system": {
                    "encounters": [ "trade.0c7bbbbf-1e49-40a1-a354-0a9a9e23d26a" ]
                }
            }
        }
    }
}
```

<span data-ttu-id="dddd5-140">同じ名前を "groups" と "encounters" の両方に使うことができます。たとえば、1 人のプレイヤーがグループと遭遇した場合、グループ内のユーザーは (グループ名を自身の "groups" に追加していれば) 何もする必要がありません。遭遇した個人のプレイヤーは、グループ名を自身の "encounters" リストにアップロードします。</span><span class="sxs-lookup"><span data-stu-id="dddd5-140">You can use the same name for both “groups” and “encounters” – for example, if one player “trades with” a group, the people in the group won’t need to do anything (assuming they previously added the group name to their “groups”), and the person who had the encounter would upload the group name in their “encounters” list.</span></span> <span data-ttu-id="dddd5-141">これで、個人のプレイヤーの [プレイヤーの履歴] に、グループ内のすべてのメンバーが表示されます (その逆も同様)。</span><span class="sxs-lookup"><span data-stu-id="dddd5-141">That will cause the individual to see all the members of the group as recent players and vice versa.</span></span>

<span data-ttu-id="dddd5-142">遭遇は、30 秒の間グループのメンバーであったとしてカウントされます。</span><span class="sxs-lookup"><span data-stu-id="dddd5-142">Encounters count as having been a member of the group for 30 seconds.</span></span> <span data-ttu-id="dddd5-143">遭遇は偶発的な出来事であると見なされるため、"encounters" 配列は常に即時処理され、セッションからクリアされます。</span><span class="sxs-lookup"><span data-stu-id="dddd5-143">Since the encounters are considered one-off events, the “encounters” array is always immediately processed and then cleared from the session.</span></span>  <span data-ttu-id="dddd5-144">応答に含まれることはありません </span><span class="sxs-lookup"><span data-stu-id="dddd5-144">It will never appear in a response.</span></span>  <span data-ttu-id="dddd5-145">("groups" 配列は変更または削除されるか、メンバーがセッションから退出するまで存続します)。</span><span class="sxs-lookup"><span data-stu-id="dddd5-145">(The “groups” array sticks around until altered or removed, or the member leaves the session.)</span></span>
