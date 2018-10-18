---
title: マルチプレイヤー セッション参照
author: KevinAsgari
description: Xbox Live マルチプレイヤーを使用してマルチプレイヤー セッション参照を実装する方法について説明します。
ms.assetid: b4b3ed67-9e2c-4c14-9b27-083b8bccb3ce
ms.author: kevinasg
ms.date: 10/16/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ea47c73cc882db4031f9c43ccbc64030ee039b3f
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/18/2018
ms.locfileid: "4755012"
---
# <a name="multiplayer-session-browse"></a><span data-ttu-id="f6086-104">マルチプレイヤー セッション参照</span><span class="sxs-lookup"><span data-stu-id="f6086-104">Multiplayer session browse</span></span>

<span data-ttu-id="f6086-105">マルチプレイヤー セッション参照とは、2016 年 11 月に導入された新機能です。これを使用すると、指定した条件に合う、開いているマルチプレイヤー ゲーム セッションのリストをタイトルで照会できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-105">Multiplayer session browse is a new feature introduced in November 2016 that enables a title to query for a list of open multiplayer game sessions that meet the specified criteria.</span></span>

## <a name="what-is-session-browse"></a><span data-ttu-id="f6086-106">セッション参照とは</span><span class="sxs-lookup"><span data-stu-id="f6086-106">What is session browse?</span></span>

<span data-ttu-id="f6086-107">セッション参照のシナリオでは、ゲームのプレイヤーは参加可能なゲーム セッションのリストを取得できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-107">In a session browse scenario, a player in a game is able to retrieve a list of joinable game sessions.</span></span> <span data-ttu-id="f6086-108">このリストの各セッション エントリにはゲームに関するいくつかの追加メタデータが含まれています。プレイヤーはその情報を使用して、参加するセッションを選択できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-108">Each session entry in this list contains some additional metadata about the game, which a player can use to help them select which session to join.</span></span>  <span data-ttu-id="f6086-109">また、メタデータに基づいてセッションのリストをフィルター処理することもできます。</span><span class="sxs-lookup"><span data-stu-id="f6086-109">They can also filter the list of sessions based on the metadata.</span></span> <span data-ttu-id="f6086-110">プレイヤーは興味のあるゲーム セッションを見つけて、セッションに参加できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-110">Once the player sees a game session that appeals to them, they can join the session.</span></span>

<span data-ttu-id="f6086-111">プレイヤーは、新しいゲーム セッションを作成し、マッチメイキングを行う代わりに、セッション参照を使用して他のプレイヤーを集めることもできます。</span><span class="sxs-lookup"><span data-stu-id="f6086-111">A player can also create a new game session, and use session browse to recruit additional players instead of relying on matchmaking.</span></span>

<span data-ttu-id="f6086-112">セッション参照が従来のマッチメイキング シナリオと異なる点として、マッチメイキングでは通常、プレイヤーは "ゲームの検索" ボタンをクリックすることにより、該当したゲーム セッションに自動的に配置されますが、セッション参照では参加するゲーム セッションをプレイヤーが自分で選択できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-112">Session browse differs from traditional matchmaking scenarios in that the player self-selects which game session they want to join, while in matchmaking, the player typically clicks a "find a game" button that attempts to automatically place the player in an appropriate game session.</span></span> <span data-ttu-id="f6086-113">セッション参照は低速な手動のプロセスであり、客観的に見て常に最適なゲームが選ばれるとは限りませんが、プレイヤーに選択権が与えられるため、ゲームの選択結果は主観的により満足度の高いものになると考えられます。</span><span class="sxs-lookup"><span data-stu-id="f6086-113">While session browse is a manual and slower process that may not always select the objectively best game, it provides more control to the player and can be perceived as the subjectively better game pick.</span></span>

<span data-ttu-id="f6086-114">セッション参照とマッチメイキングの両方のシナリオをゲームに組み込むのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="f6086-114">It is common to include both session browse and matchmaking scenarios in games.</span></span> <span data-ttu-id="f6086-115">通常、マッチメイキングは一般的にプレイされるゲーム モードに使用され、セッション参照はカスタム ゲームに使用されます。</span><span class="sxs-lookup"><span data-stu-id="f6086-115">Typically matchmaking is used for commonly played game modes, while session browse is used for custom games.</span></span>

<span data-ttu-id="f6086-116">**例:** John はヒーロー バトル アリーナ スタイルのマルチプレイヤー ゲームに関心がありますが、すべてのプレイヤーがヒーローをランダムに選択するゲームをプレイしたいと思っています。</span><span class="sxs-lookup"><span data-stu-id="f6086-116">**Example:** John may be interested in playing a hero battle arena style multiplayer game, but wants to play a game where all players select their hero randomly.</span></span> <span data-ttu-id="f6086-117">彼は、オープン ゲーム セッションのリストを取得し、"ランダム ヒーロー" が説明に含まれるゲームを探すか、ゲーム UI で可能であれば、"ランダム ヒーロー" ゲーム モードを選択して、"RandomHero" ゲームを示すタグ付きのセッションだけを取得することができます。</span><span class="sxs-lookup"><span data-stu-id="f6086-117">He can retrieve a list of open game sessions and find the ones that include "random heroes" in their description, or if the game UI allows it, he can select the "random hero" game mode and retrieve only the sessions that are tagged to indicate that they are "RandomHero" games.</span></span>

<span data-ttu-id="f6086-118">気に入ったゲームが見つかれば、ゲームに参加します。</span><span class="sxs-lookup"><span data-stu-id="f6086-118">When he finds a game that he likes, he joins the game.</span></span> <span data-ttu-id="f6086-119">十分なメンバーがセッションに参加すると、ゲーム セッションのホストはゲームを開始できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-119">When enough people have joined the session, the host of the game session can start the game.</span></span>

### <a name="roles"></a><span data-ttu-id="f6086-120">ロール</span><span class="sxs-lookup"><span data-stu-id="f6086-120">Roles</span></span>

<span data-ttu-id="f6086-121">セッション参照のゲームは、特定のロールのプレイヤーを募集できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-121">A game in session browse may want to recruit players for specific roles.</span></span> <span data-ttu-id="f6086-122">たとえば、プレイヤーは、5 人以下の突撃クラス、2 人以上のヒーラー ロール、1 人以上のタンク ロールを含むセッションを指定するゲーム セッションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-122">For example, a player may want to create a game session that specifies that the session contains no more than 5 assault classes, but must contain at least 2 healer roles, and at least 1 tank role.</span></span>

<span data-ttu-id="f6086-123">別のプレイヤーがセッションに参加するときは、ロールを事前に選択でき、選択したロールに空きスロットがない場合はセッションへの参加が許可されません。</span><span class="sxs-lookup"><span data-stu-id="f6086-123">When another player applies for the session, they can pre-select their role, and the service will not allow them to join the session if there are no open slots for the role they have selected.</span></span>

<span data-ttu-id="f6086-124">別の例として、プレイヤーがフレンドの参加のために 2 スロットを予約する場合、ゲームは "フレンド" の役割を指定でき、セッション ホストとフレンドであるプレイヤーだけが "フレンド" の役割に専用の 2 スロットを埋めることができます。</span><span class="sxs-lookup"><span data-stu-id="f6086-124">Another example would be if a player wants to reserve 2 slots for their friends to join, the game can specify a "friends" role, and only players that are friends with the session host can fill the 2 slots dedicated to the "friends" role.</span></span>

<span data-ttu-id="f6086-125">ロールについて詳しくは、「[マルチプレイヤーのロール](multiplayer-roles.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f6086-125">For more information about roles, see [multiplayer roles](multiplayer-roles.md).</span></span>



## <a name="how-does-session-browse-work"></a><span data-ttu-id="f6086-126">セッション参照の動作</span><span class="sxs-lookup"><span data-stu-id="f6086-126">How does session browse work?</span></span>

<span data-ttu-id="f6086-127">セッション参照は、主に検索ハンドルの使用時に動作します。</span><span class="sxs-lookup"><span data-stu-id="f6086-127">Session browse works primarily on the use of search handles.</span></span> <span data-ttu-id="f6086-128">検索ハンドルは、セッションの参照と、検索属性と呼ばれるセッションに関する追加メタデータを含む、データのパケットです。</span><span class="sxs-lookup"><span data-stu-id="f6086-128">A search handle is a packet of data that contains a reference to the session, as well as additional metadata about the session, namely search attributes.</span></span>

<span data-ttu-id="f6086-129">タイトルは、セッション参照対応の新しいゲーム セッションを作成するとき、セッションの検索ハンドルを作成します。</span><span class="sxs-lookup"><span data-stu-id="f6086-129">When a title creates a new game session that is eligible for session browse, it creates a search handle for the session.</span></span> <span data-ttu-id="f6086-130">検索ハンドルは、タイトルの検索ハンドルを管理するマルチプレイヤー サービス ディレクトリ (MPSD) に格納されます。</span><span class="sxs-lookup"><span data-stu-id="f6086-130">The search handle is stored in the Multiplayer Service Directory (MPSD), which maintains the search handles for the title.</span></span>

<span data-ttu-id="f6086-131">タイトルは、セッションのリストを取得する必要があるときは、検索クエリを MPSD に送信できます。MPSD は検索条件に一致する検索ハンドルのリストを返します。</span><span class="sxs-lookup"><span data-stu-id="f6086-131">When a title needs to retrieve a list of sessions, the title can send a search query to MPSD, which will return a list of search handles that meet the search criteria.</span></span> <span data-ttu-id="f6086-132">その後、タイトルはセッションのリストを使用して、プレイヤーに参加可能なゲームの一覧を表示できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-132">The title can then use the list of sessions to display a list of joinable games to the player.</span></span>

<span data-ttu-id="f6086-133">セッションに空きがない場合、またはそれ以外の理由で参加できない場合は、タイトルは MPSD からの検索ハンドルを削除して、セッション参照クエリにセッションが表示されないようにできます。</span><span class="sxs-lookup"><span data-stu-id="f6086-133">When a session is full, or otherwise cannot be joined, a title can remove the search handle from MPSD so that the session will no longer show up in session browse queries.</span></span>

>[!NOTE]
> <span data-ttu-id="f6086-134">検索ハンドルは、ユーザーに表示するセッションの一覧を表示するために使用します。</span><span class="sxs-lookup"><span data-stu-id="f6086-134">Search handles are intended to be used when displaying a list of sessions to be presented to a user.</span></span> <span data-ttu-id="f6086-135">可能であれば、バックグラウンドのマッチメイキングには検索ハンドルを使わないでください。代わりに、[SmartMatch](multiplayer-manager/play-multiplayer-with-matchmaking.md) の使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="f6086-135">Using search handles for background matchmaking should be avoided if possible, and instead consider using [SmartMatch](multiplayer-manager/play-multiplayer-with-matchmaking.md)</span></span>

## <a name="set-up-a-session-for-session-browse"></a><span data-ttu-id="f6086-136">セッション参照用にセッションを設定する</span><span class="sxs-lookup"><span data-stu-id="f6086-136">Set up a session for session browse</span></span>

<span data-ttu-id="f6086-137">セッションで検索ハンドルを使用するには、セッションで次の機能が true に設定されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="f6086-137">In order to use search handles for a session, the session must have the following capabilities set to true:</span></span>

* `searchable`
* `userAuthorizationStyle`

>[!NOTE]
> <span data-ttu-id="f6086-138">`userAuthorizationStyle` 機能は UWP ゲームでのみ必須となりますが、XDK ゲームを含むすべての Xbox Live ゲームに実装することをお勧めします。これにより、将来の移植性が保証されます。</span><span class="sxs-lookup"><span data-stu-id="f6086-138">The `userAuthorizationStyle` capability is only required for UWP games, but we recommend implementing them for all Xbox Live games, including XDK games, as it ensures future portability.</span></span>

>[!NOTE]
> <span data-ttu-id="f6086-139">`userAuthorizationStyle` 機能を設定すると、既定でセッションの `readRestriction` と `joinRestriction` が `none` ではなく `local` になります。</span><span class="sxs-lookup"><span data-stu-id="f6086-139">Setting the `userAuthorizationStyle` capability defaults the `readRestriction` and `joinRestriction` of the session to `local` instead of `none`.</span></span> <span data-ttu-id="f6086-140">つまり、ゲーム セッションに参加するには、タイトルで検索ハンドルまたは転送ハンドルを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="f6086-140">This means that titles must use search handles or transfer handles to join a game session.</span></span>

<span data-ttu-id="f6086-141">これらの機能は、Xbox Live サービスを構成するときにセッション テンプレートで設定できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-141">You can set these capabilities in the session template when you configure your Xbox Live services.</span></span>

<span data-ttu-id="f6086-142">セッション参照の場合、ロビー セッションではなく、実際のゲームプレイに使用されるセッションでのみ検索ハンドルを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f6086-142">For session browse, you should only create search handles on sessions that will be used for actual gameplay, not for lobby sessions.</span></span>

## <a name="what-does-it-mean-to-be-an-owner-of-a-session"></a><span data-ttu-id="f6086-143">セッションの所有者とは</span><span class="sxs-lookup"><span data-stu-id="f6086-143">What does it mean to be an owner of a session?</span></span>

<span data-ttu-id="f6086-144">SmartMatch やフレンドのみのゲームなど、多くのゲーム セッションの種類では所有者は必要ありませんが、セッション参照セッションには所有者を設定できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-144">While many game session types, such as SmartMatch or a friends only game, do not require an owner, for session browse sessions you may wish to have an owner.</span></span> 

<span data-ttu-id="f6086-145">所有者によって管理されたセッションには、所有者によっていくつかの利点があります。</span><span class="sxs-lookup"><span data-stu-id="f6086-145">Having an owner-managed session has some benefits for the owner.</span></span> <span data-ttu-id="f6086-146">所有者は、セッションから他のメンバーを削除したり、他のメンバーの所有権の状態を変更できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-146">Owners can remove other members from the session, or change the ownership status of other members.</span></span>

<span data-ttu-id="f6086-147">セッションで所有者を使用するには、セッションで次の機能が true に設定されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="f6086-147">In order to use owners for a session, the session must have the following capabilities set to true:</span></span>

* `hasOwners`

<span data-ttu-id="f6086-148">セッションの所有者が Xbox Live メンバーをブロックすると、そのメンバーはセッションに参加できません。</span><span class="sxs-lookup"><span data-stu-id="f6086-148">If an owner of a session has an Xbox Live member blocked, that member cannot join the session.</span></span>

<span data-ttu-id="f6086-149">[マルチプレイヤーのロール](multiplayer-roles.md)を使っている場合、所有者だけがユーザーにロールを割り当てることができるように設定できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-149">When using [multiplayer roles](multiplayer-roles.md), you can set it so only owners can assign roles to users.</span></span>

<span data-ttu-id="f6086-150">すべての所有者がセッションから退出した場合、サービスはセッションに対して定義されている `ownershipPolicy.migration` ポリシーに基づいてセッションを処理します。</span><span class="sxs-lookup"><span data-stu-id="f6086-150">If all owners leave a session, then the service takes action on the session based the `ownershipPolicy.migration` policy that is defined for the session.</span></span> <span data-ttu-id="f6086-151">ポリシーが "oldest" の場合は、セッションに最も長くいるプレイヤーが新しい所有者として設定されます。</span><span class="sxs-lookup"><span data-stu-id="f6086-151">If the policy is "oldest", then the player that has been in the session the longest is set to be the new owner.</span></span> <span data-ttu-id="f6086-152">ポリシーが "endsession" (指定されていない場合は既定値) の場合は、サービスはセッションを終了し、残っているすべてのプレイヤーをセッションから削除します。</span><span class="sxs-lookup"><span data-stu-id="f6086-152">If the policy is "endsession" (the default if not supplied), then the service ends the session and removes all remaining players from the session.</span></span>


## <a name="search-handles"></a><span data-ttu-id="f6086-153">検索ハンドル</span><span class="sxs-lookup"><span data-stu-id="f6086-153">Search handles</span></span>

<span data-ttu-id="f6086-154">検索ハンドルは、JSON 構造として MSPD に格納されます。</span><span class="sxs-lookup"><span data-stu-id="f6086-154">A search handle is stored in MSPD as a JSON structure.</span></span> <span data-ttu-id="f6086-155">検索ハンドルには、セッションへの参照だけでなく、検索属性と呼ばれる検索のための追加メタデータも含まれます。</span><span class="sxs-lookup"><span data-stu-id="f6086-155">In addition to containing a reference to the session, search handles also contain additional metadata for searches, known as search attributes.</span></span>

<span data-ttu-id="f6086-156">セッションが任意の時点で作成できる検索ハンドルは 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="f6086-156">A session can only have one search handle created for it at any time.</span></span>

<span data-ttu-id="f6086-157">Xbox Live API を使用してセッションの検索ハンドルを作成するには、最初に `multiplayer::multiplayer_search_handle_request` オブジェクトを作成した後、そのオブジェクトを `multiplayer::multiplayer_service::set_search_handle()` メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="f6086-157">To create a search handle for a session in by using the Xbox Live APIs, you first create a `multiplayer::multiplayer_search_handle_request` object, and then pass that object to the `multiplayer::multiplayer_service::set_search_handle()` method.</span></span>

### <a name="search-attributes"></a><span data-ttu-id="f6086-158">検索属性</span><span class="sxs-lookup"><span data-stu-id="f6086-158">Search attributes</span></span>

<span data-ttu-id="f6086-159">検索属性は、次のコンポーネントで構成されます。</span><span class="sxs-lookup"><span data-stu-id="f6086-159">Search attributes consists of the following components:</span></span>

`tags` <span data-ttu-id="f6086-160">- タグは、ユーザーがゲーム セッションの分類に使用できる、ハッシュタグのような文字列記述子です。</span><span class="sxs-lookup"><span data-stu-id="f6086-160">- Tags are string descriptors that people can use to categorize a game session, similar to a hashtag.</span></span> <span data-ttu-id="f6086-161">タグは、文字で始まる必要があり、スペースを含むことはできず、100 文字未満にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="f6086-161">Tags must start with a letter, cannot contain spaces, and must be less than 100 characters.</span></span>
<span data-ttu-id="f6086-162">タグの例: "ProRankOnly"、"norocketlaunchers"、"cityMaps"。</span><span class="sxs-lookup"><span data-stu-id="f6086-162">Example tags: "ProRankOnly", "norocketlaunchers", "cityMaps".</span></span>

`strings` <span data-ttu-id="f6086-163">- 文字列は、テキスト変数であり、文字列名は文字で始まる必要があり、スペースを含むことはできず、100 文字未満にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="f6086-163">- Strings are text variables, and the string names must start with a letter, cannot contain spaces, and must be less than 100 characters.</span></span>

<span data-ttu-id="f6086-164">文字列メタデータの例: "Weapons"="knives+pistols+rifles"、"MapName"="UrbanCityAssault"、"description"="Fun casual game, new people welcome"。</span><span class="sxs-lookup"><span data-stu-id="f6086-164">Example string metadata: "Weapons"="knives+pistols+rifles", "MapName"="UrbanCityAssault", "description"="Fun casual game, new people welcome."</span></span>

`numbers` <span data-ttu-id="f6086-165">- 数値は、数値変数であり、数値名は文字で始まる必要があり、スペースを含むことはできず、100 文字未満にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="f6086-165">- Numbers are numeric variables, and the number names must start with a letter, cannot contain spaces, and must be less than 100 characters.</span></span> <span data-ttu-id="f6086-166">Xbox Live API は、float 型として数値を取得します。</span><span class="sxs-lookup"><span data-stu-id="f6086-166">The Xbox Live APIs retrieve number values as type float.</span></span>

<span data-ttu-id="f6086-167">数値メタデータの例: "MinLevel" = 25、"MaxRank" = 10。</span><span class="sxs-lookup"><span data-stu-id="f6086-167">Example number metadata: "MinLevel" = 25, "MaxRank" = 10.</span></span>

><span data-ttu-id="f6086-168">**注意:** サービスではタグと文字列値の大文字小文字の区別が維持されますが、タグを照会するときは tolower() 関数を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f6086-168">**Note:** The letter casing of tags and string values is preserved in the service, but you must use the tolower() function when you query for tags.</span></span> <span data-ttu-id="f6086-169">つまり、タグと文字列の値は、現在、大文字が含まれる場合でも、すべて小文字として扱われます。</span><span class="sxs-lookup"><span data-stu-id="f6086-169">This means that tags and string values are currently all treated as lower case, even if they contain upper case characters.</span></span>

<span data-ttu-id="f6086-170">Xbox Live API では、`multiplayer_search_handle_request` オブジェクトの `set_tags()` メソッド、`set_stringsmetadata()` メソッド、および `set_numbers_metadata()` メソッドを使用して検索属性を設定できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-170">In the Xbox Live APIs, you can set the search attributes by using the `set_tags()`, `set_stringsmetadata()`, and `set_numbers_metadata()` methods of a `multiplayer_search_handle_request` object.</span></span>


### <a name="additional-details"></a><span data-ttu-id="f6086-171">追加情報</span><span class="sxs-lookup"><span data-stu-id="f6086-171">Additional details</span></span>

<span data-ttu-id="f6086-172">検索ハンドルを取得した結果には、セッションに関する他の有用なデータも含まれます (セッションが閉じられているかどうか、セッションに何らかの参加制限があるか、など)。</span><span class="sxs-lookup"><span data-stu-id="f6086-172">When you retrieve a search handle, the results also include additional useful data about the session, such as if the session is closed, are there any join restrictions on the session, etc.</span></span>

<span data-ttu-id="f6086-173">Xbox Live API では、これらの詳細と検索属性は、検索クエリの後で返される `multiplayer_search_handle_details` に含まれます。</span><span class="sxs-lookup"><span data-stu-id="f6086-173">In the Xbox Live APIs, these details, along with the search attributes, are included in the `multiplayer_search_handle_details` that are returned after a search query.</span></span>

### <a name="remove-a-search-handle"></a><span data-ttu-id="f6086-174">検索ハンドルを削除する</span><span class="sxs-lookup"><span data-stu-id="f6086-174">Remove a search handle</span></span>

<span data-ttu-id="f6086-175">セッションに空きがない場合や、セッションが閉じられた場合など、セッション参照からセッションを削除するときは、検索ハンドルを削除できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-175">When you want to remove a session from session browse, such as when the session is full, or if the session is closed, you can delete the search handle.</span></span>

<span data-ttu-id="f6086-176">Xbox Live API では、`multiplayer_service::clear_search_handle()` メソッドを使用して検索ハンドルを削除できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-176">In the Xbox Live APIs, you can use the `multiplayer_service::clear_search_handle()` method to remove a search handle.</span></span>

### <a name="example-create-a-search-handle-with-metadata"></a><span data-ttu-id="f6086-177">例: メタデータで検索ハンドルを作成する</span><span class="sxs-lookup"><span data-stu-id="f6086-177">Example: Create a search handle with metadata</span></span>

<span data-ttu-id="f6086-178">次のコードでは、C++ Xbox Live マルチプレイヤー API を使用してセッションの検索ハンドルを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="f6086-178">The following code shows how to create a search handle for a session by using the C++ Xbox Live multiplayer APIs.</span></span>

```cpp
auto searchHandleReq = multiplayer_search_handle_request(sessionBrowseRef);

searchHandleReq.set_tags(std::vector<string_t> val);
searchHandleReq.set_numbers_metadata(std::unordered_map<string_t, double> metadata);
searchHandleReq.set_strings_metadata(std::unordered_map<string_t, string_t> metadata);

auto result = xboxLiveContext->multiplayer_service().set_search_handle(searchHandleReq)
.then([](xbox_live_result<void> result)
{
  if (result.err())
  {
    // handle error
  }
});
```


## <a name="create-a-search-query-for-sessions"></a><span data-ttu-id="f6086-179">セッションの検索クエリを作成する</span><span class="sxs-lookup"><span data-stu-id="f6086-179">Create a search query for sessions</span></span>

<span data-ttu-id="f6086-180">検索ハンドルのリストを取得するときは、検索クエリを使用して、特定の条件に一致するセッションに結果を限定できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-180">When retrieving a list of search handles, you can use a search query to restrict the results to the sessions that meet specific criteria.</span></span>

<span data-ttu-id="f6086-181">検索クエリの構文は [OData](http://docs.oasis-open.org/odata/odata/v4.0/errata02/os/complete/part2-url-conventions/odata-v4.0-errata02-os-part2-url-conventions-complete.html#_Toc406398092) スタイルであり、次の演算子だけがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="f6086-181">The search query syntax is an  [OData](http://docs.oasis-open.org/odata/odata/v4.0/errata02/os/complete/part2-url-conventions/odata-v4.0-errata02-os-part2-url-conventions-complete.html#_Toc406398092) style syntax, with only the following operators supported:</span></span>

 <span data-ttu-id="f6086-182">演算子</span><span class="sxs-lookup"><span data-stu-id="f6086-182">Operator</span></span> | <span data-ttu-id="f6086-183">説明</span><span class="sxs-lookup"><span data-stu-id="f6086-183">Description</span></span>
 --- | ---
 <span data-ttu-id="f6086-184">eq</span><span class="sxs-lookup"><span data-stu-id="f6086-184">eq</span></span> | <span data-ttu-id="f6086-185">equals (次の値と等しい)</span><span class="sxs-lookup"><span data-stu-id="f6086-185">equals</span></span>
 <span data-ttu-id="f6086-186">ne</span><span class="sxs-lookup"><span data-stu-id="f6086-186">ne</span></span> | <span data-ttu-id="f6086-187">not equal to (次の値と等しくない)</span><span class="sxs-lookup"><span data-stu-id="f6086-187">not equal to</span></span>
 <span data-ttu-id="f6086-188">gt</span><span class="sxs-lookup"><span data-stu-id="f6086-188">gt</span></span> | <span data-ttu-id="f6086-189">greater than (次の値より大きい)</span><span class="sxs-lookup"><span data-stu-id="f6086-189">greater than</span></span>
 <span data-ttu-id="f6086-190">ge</span><span class="sxs-lookup"><span data-stu-id="f6086-190">ge</span></span> | <span data-ttu-id="f6086-191">greater than or equal (次の値以上)</span><span class="sxs-lookup"><span data-stu-id="f6086-191">greater than or equal</span></span>
 <span data-ttu-id="f6086-192">lt</span><span class="sxs-lookup"><span data-stu-id="f6086-192">lt</span></span> | <span data-ttu-id="f6086-193">less than (次の値より小さい)</span><span class="sxs-lookup"><span data-stu-id="f6086-193">less than</span></span>
 <span data-ttu-id="f6086-194">le</span><span class="sxs-lookup"><span data-stu-id="f6086-194">le</span></span> | <span data-ttu-id="f6086-195">less than or equal (次の値以下)</span><span class="sxs-lookup"><span data-stu-id="f6086-195">less than or equal</span></span>
 <span data-ttu-id="f6086-196">and</span><span class="sxs-lookup"><span data-stu-id="f6086-196">and</span></span> | <span data-ttu-id="f6086-197">論理 AND</span><span class="sxs-lookup"><span data-stu-id="f6086-197">logical AND</span></span>
 <span data-ttu-id="f6086-198">or</span><span class="sxs-lookup"><span data-stu-id="f6086-198">or</span></span> | <span data-ttu-id="f6086-199">論理 OR (下の「注」を参照)</span><span class="sxs-lookup"><span data-stu-id="f6086-199">logical OR (see note below)</span></span>

<span data-ttu-id="f6086-200">また、ラムダ式と `tolower` 正規関数も使用できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-200">You can also use lambda expressions and the `tolower` canonical function.</span></span> <span data-ttu-id="f6086-201">現在、他の OData 関数はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="f6086-201">No other OData functions are supported currently.</span></span>

<span data-ttu-id="f6086-202">タグまたは文字列値を検索するときは、検索クエリで "tolower" 関数を使用する必要があります。現在、サービスは小文字の文字列の検索のみをサポートします。</span><span class="sxs-lookup"><span data-stu-id="f6086-202">When searching for tags or string values, you must use the 'tolower' function in the search query, as the service only currently supports searching for lower-case strings.</span></span>

<span data-ttu-id="f6086-203">Xbox Live サービスは、検索クエリに一致する最初の 100 個の結果のみを返します。</span><span class="sxs-lookup"><span data-stu-id="f6086-203">The Xbox Live service only returns the first 100 results that match the search query.</span></span> <span data-ttu-id="f6086-204">ゲームでは、結果が多すぎる場合にプレイヤーが検索クエリを絞り込むことができるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="f6086-204">Your game should allow players to refine their search query if the results are too broad.</span></span>

>[!NOTE]
>  <span data-ttu-id="f6086-205">フィルター文字列のクエリでは論理 OR がサポートされますが、使用できる OR は 1 つだけで、クエリのルートに指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f6086-205">Logical ORs are supported in filter string queries; however only one OR is allowed and it must be at the root of your query.</span></span> <span data-ttu-id="f6086-206">クエリに複数の OR を含めることはできません。また、OR がクエリ構造の最上位でない位置に出現するクエリを作成することもできません。</span><span class="sxs-lookup"><span data-stu-id="f6086-206">You cannot have multiple ORs in your query, nor can you create a query that would result in OR not being at the top most level of the query structure.</span></span>

### <a name="search-handle-query-examples"></a><span data-ttu-id="f6086-207">検索ハンドルのクエリの例</span><span class="sxs-lookup"><span data-stu-id="f6086-207">Search handle query examples</span></span>

<span data-ttu-id="f6086-208">RESTful 呼び出しの "Filter" では、すべての検索ハンドルに対するクエリで使用する OData Filter 言語文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="f6086-208">In a restful call, "Filter" is where you would specify an OData Filter language string that will be run in your query against all search handles.</span></span>  
<span data-ttu-id="f6086-209">Multiplayer 2015 API では、`multiplayer_service.get_search_handles()` メソッドの *searchFilter* パラメーターにフィルター文字列を指定できます。</span><span class="sxs-lookup"><span data-stu-id="f6086-209">In the multiplayer 2015 APIs, you can specify the search filter string in the *searchFilter* parameter of the `multiplayer_service.get_search_handles()` method.</span></span>  

<span data-ttu-id="f6086-210">現在サポートされているフィルター シナリオは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="f6086-210">Currently, the following filter scenarios are supported:</span></span>

 <span data-ttu-id="f6086-211">フィルター</span><span class="sxs-lookup"><span data-stu-id="f6086-211">Filter by</span></span> | <span data-ttu-id="f6086-212">フィルターを適用した検索文字列</span><span class="sxs-lookup"><span data-stu-id="f6086-212">Search filter string</span></span>
 --- | ---
 <span data-ttu-id="f6086-213">xuid が '1234566' である 1 人のメンバー</span><span class="sxs-lookup"><span data-stu-id="f6086-213">A single member xuid '1234566’</span></span> | <span data-ttu-id="f6086-214">"session/memberXuids/any(d:d eq '1234566')"</span><span class="sxs-lookup"><span data-stu-id="f6086-214">"session/memberXuids/any(d:d eq '1234566')"</span></span>
 <span data-ttu-id="f6086-215">xuid が '1234566' である 1 人の所有者</span><span class="sxs-lookup"><span data-stu-id="f6086-215">A single owner xuid '1234566’</span></span> | <span data-ttu-id="f6086-216">"session/ownerXuids/any(d:d eq '1234566')"</span><span class="sxs-lookup"><span data-stu-id="f6086-216">"session/ownerXuids/any(d:d eq '1234566')"</span></span>
 <span data-ttu-id="f6086-217">文字列 'forzacarclass' が 'classb' に等しい</span><span class="sxs-lookup"><span data-stu-id="f6086-217">A string 'forzacarclass' equal to 'classb‘</span></span> | <span data-ttu-id="f6086-218">"tolower(strings/forzacarclass) eq 'classb'"</span><span class="sxs-lookup"><span data-stu-id="f6086-218">"tolower(strings/forzacarclass) eq 'classb'"</span></span>
 <span data-ttu-id="f6086-219">数値 'forzaskill' が 6 に等しい</span><span class="sxs-lookup"><span data-stu-id="f6086-219">A number 'forzaskill' equal to 6</span></span> | <span data-ttu-id="f6086-220">"numbers/forzaskill eq 6"</span><span class="sxs-lookup"><span data-stu-id="f6086-220">"numbers/forzaskill eq 6"</span></span>
 <span data-ttu-id="f6086-221">数値 'halokdratio' が 1.5 より大きい</span><span class="sxs-lookup"><span data-stu-id="f6086-221">A number 'halokdratio' greater than 1.5</span></span> | <span data-ttu-id="f6086-222">"numbers/halokdratio gt 1.5"</span><span class="sxs-lookup"><span data-stu-id="f6086-222">"numbers/halokdratio gt 1.5"</span></span>
 <span data-ttu-id="f6086-223">タグ 'coolpeopleonly' である</span><span class="sxs-lookup"><span data-stu-id="f6086-223">A tag 'coolpeopleonly'</span></span> | <span data-ttu-id="f6086-224">"tags/any(d:tolower(d) eq 'coolpeopleonly')"</span><span class="sxs-lookup"><span data-stu-id="f6086-224">"tags/any(d:tolower(d) eq 'coolpeopleonly')"</span></span>
 <span data-ttu-id="f6086-225">タグ 'cursingallowed' を含まないセッション</span><span class="sxs-lookup"><span data-stu-id="f6086-225">Sessions that do not contain the tag 'cursingallowed'</span></span> | <span data-ttu-id="f6086-226">"tags/any(d:tolower(d) ne 'cursingallowed')"</span><span class="sxs-lookup"><span data-stu-id="f6086-226">"tags/any(d:tolower(d) ne 'cursingallowed')"</span></span>
 <span data-ttu-id="f6086-227">数値が 0 に等しい 'rank' を含まないセッション</span><span class="sxs-lookup"><span data-stu-id="f6086-227">Sessions that do not contain a number 'rank' that is equal to 0</span></span> | <span data-ttu-id="f6086-228">"numbers/rank ne 0"</span><span class="sxs-lookup"><span data-stu-id="f6086-228">"numbers/rank ne 0"</span></span>
 <span data-ttu-id="f6086-229">文字列が 'classa' に等しい 'forzacarclass' を含まないセッション</span><span class="sxs-lookup"><span data-stu-id="f6086-229">Sessions that do not contain a string 'forzacarclass' that is equal to 'classa'</span></span> | <span data-ttu-id="f6086-230">"tolower(strings/forzacarclass) ne 'classa'"</span><span class="sxs-lookup"><span data-stu-id="f6086-230">"tolower(strings/forzacarclass) ne 'classa'"</span></span>
 <span data-ttu-id="f6086-231">タグが 'coolpeopleonly' であり、数値 'halokdratio' が 7.5 に等しい</span><span class="sxs-lookup"><span data-stu-id="f6086-231">A tag 'coolpeopleonly' and a number 'halokdratio' equal to 7.5</span></span> | <span data-ttu-id="f6086-232">"tags/any(d:tolower(d) eq 'coolpeopleonly') eq true and numbers/halokdratio eq 7.5"</span><span class="sxs-lookup"><span data-stu-id="f6086-232">"tags/any(d:tolower(d) eq 'coolpeopleonly') eq true and numbers/halokdratio eq 7.5"</span></span>
 <span data-ttu-id="f6086-233">数値 'halodkratio' が 1.5 以上であり、数値 'rank' が 60 より小さく、数値 'customnumbervalue' が 5 以下である</span><span class="sxs-lookup"><span data-stu-id="f6086-233">A number 'halodkratio' greater than or equal to 1.5, a number 'rank' less than 60, and a number 'customnumbervalue' less than or equal to 5</span></span> | <span data-ttu-id="f6086-234">"numbers/halokdratio ge 1.5 and numbers/rank lt 60 and numbers/customnumbervalue le 5"</span><span class="sxs-lookup"><span data-stu-id="f6086-234">"numbers/halokdratio ge 1.5 and numbers/rank lt 60 and numbers/customnumbervalue le 5"</span></span>
 <span data-ttu-id="f6086-235">実績 ID が '123456'</span><span class="sxs-lookup"><span data-stu-id="f6086-235">An achievement id '123456'</span></span> | <span data-ttu-id="f6086-236">"achievementIds/any(d:d eq '123456')"</span><span class="sxs-lookup"><span data-stu-id="f6086-236">"achievementIds/any(d:d eq '123456')"</span></span>
 <span data-ttu-id="f6086-237">言語コード 'en'</span><span class="sxs-lookup"><span data-stu-id="f6086-237">The language code 'en'</span></span> | <span data-ttu-id="f6086-238">"language eq 'en'"</span><span class="sxs-lookup"><span data-stu-id="f6086-238">"language eq 'en'"</span></span>
 <span data-ttu-id="f6086-239">指定された時刻以下のスケジュールされた時刻をすべて返す</span><span class="sxs-lookup"><span data-stu-id="f6086-239">Scheduled time, returns all scheduled times less than or equal to the specified time</span></span> | <span data-ttu-id="f6086-240">"session/scheduledTime le '2009-06-15T13:45:30.0900000Z'"</span><span class="sxs-lookup"><span data-stu-id="f6086-240">"session/scheduledTime le '2009-06-15T13:45:30.0900000Z'"</span></span>
 <span data-ttu-id="f6086-241">指定された時刻より小さい投稿時刻をすべて返す</span><span class="sxs-lookup"><span data-stu-id="f6086-241">Posted time, returns all posted times less than the specified time</span></span> | <span data-ttu-id="f6086-242">"session/postedTime lt '2009-06-15T13:45:30.0900000Z'"</span><span class="sxs-lookup"><span data-stu-id="f6086-242">"session/postedTime lt '2009-06-15T13:45:30.0900000Z'"</span></span>
 <span data-ttu-id="f6086-243">セッション登録状態</span><span class="sxs-lookup"><span data-stu-id="f6086-243">Session registration state</span></span> | <span data-ttu-id="f6086-244">"session/registrationState eq 'registered'"</span><span class="sxs-lookup"><span data-stu-id="f6086-244">"session/registrationState eq 'registered'"</span></span>
 <span data-ttu-id="f6086-245">セッション メンバーの数が 5 に等しい</span><span class="sxs-lookup"><span data-stu-id="f6086-245">Where the number of session members is equal to 5</span></span> | <span data-ttu-id="f6086-246">"session/membersCount eq 5"</span><span class="sxs-lookup"><span data-stu-id="f6086-246">"session/membersCount eq 5"</span></span>
 <span data-ttu-id="f6086-247">セッション メンバーの目標数が 1 より大きい</span><span class="sxs-lookup"><span data-stu-id="f6086-247">Where the session member target count is greater than 1</span></span> | <span data-ttu-id="f6086-248">"session/targetMembersCount gt 1"</span><span class="sxs-lookup"><span data-stu-id="f6086-248">"session/targetMembersCount gt 1"</span></span>
 <span data-ttu-id="f6086-249">セッション メンバーの最大数が 3 より小さい</span><span class="sxs-lookup"><span data-stu-id="f6086-249">Where the max count of session members is less than 3</span></span> | <span data-ttu-id="f6086-250">"session/maxMembersCount lt 3"</span><span class="sxs-lookup"><span data-stu-id="f6086-250">"session/maxMembersCount lt 3"</span></span>
 <span data-ttu-id="f6086-251">セッション メンバーの目標数とセッション メンバー数の差異が 5 以下</span><span class="sxs-lookup"><span data-stu-id="f6086-251">Where the difference between the session member target count and the number of session members is less than or equal to 5</span></span> | <span data-ttu-id="f6086-252">"session/targetMembersCountRemaining le 5"</span><span class="sxs-lookup"><span data-stu-id="f6086-252">"session/targetMembersCountRemaining le 5"</span></span>
 <span data-ttu-id="f6086-253">セッション メンバーの最大数とセッション メンバー数の差異が 2 より大きい</span><span class="sxs-lookup"><span data-stu-id="f6086-253">Where the difference between the max count of session members and the number of session members is greater than 2</span></span> | <span data-ttu-id="f6086-254">"session/maxMembersCountRemaining gt 2"</span><span class="sxs-lookup"><span data-stu-id="f6086-254">"session/maxMembersCountRemaining gt 2"</span></span>
 <span data-ttu-id="f6086-255">セッション メンバーの目標数とセッション メンバー数の差異が 15 以下。</span><span class="sxs-lookup"><span data-stu-id="f6086-255">Where the difference between the session member target count and the number of session members is less than or equal to 15.</span></span></br> <span data-ttu-id="f6086-256">ロールに目標数が指定されていない場合、このクエリでは、セッション メンバーの最大数とセッション メンバー数の差異を使用してフィルター処理が行われます。</span><span class="sxs-lookup"><span data-stu-id="f6086-256">If the role does not have a target specified, then this query filters against the difference between the max count of session members and the number of session members.</span></span> | <span data-ttu-id="f6086-257">"session/needs le 15"</span><span class="sxs-lookup"><span data-stu-id="f6086-257">"session/needs le 15"</span></span>
 <span data-ttu-id="f6086-258">ロールの種類 "lfg" のロール "confirmed" で、このロールのメンバー数が 5 に等しい</span><span class="sxs-lookup"><span data-stu-id="f6086-258">Role "confirmed" of the role type "lfg" where the number of members with that role is equal to 5</span></span> | <span data-ttu-id="f6086-259">"session/roles/lfg/confirmed/count eq 5"</span><span class="sxs-lookup"><span data-stu-id="f6086-259">"session/roles/lfg/confirmed/count eq 5"</span></span>
 <span data-ttu-id="f6086-260">ロールの種類 "lfg" のロール "confirmed" で、このロールの目標数が 1 より大きい。</span><span class="sxs-lookup"><span data-stu-id="f6086-260">Role "confirmed" of the role type "lfg" where the target of that role is greater than 1.</span></span></br> <span data-ttu-id="f6086-261">ロールに目標数が指定されていない場合、ロールの最大数が代わりに使用されます。</span><span class="sxs-lookup"><span data-stu-id="f6086-261">If the role does not have a target specified, then the max of the role is used instead.</span></span> | <span data-ttu-id="f6086-262">"session/roles/lfg/confirmed/target gt 1"</span><span class="sxs-lookup"><span data-stu-id="f6086-262">"session/roles/lfg/confirmed/target gt 1"</span></span>
 <span data-ttu-id="f6086-263">ロールの種類 "lfg" のロール "confirmed" で、ロールの目標数とロールのメンバー数の差異が 15 以下。</span><span class="sxs-lookup"><span data-stu-id="f6086-263">Role "confirmed" of the role type "lfg" where the difference between the target of the role and the number of members with that role is less than or equal to 15.</span></span></br> <span data-ttu-id="f6086-264">ロールに目標数が指定されていない場合、このクエリでは、ロールの最大数とロールのメンバー数の差異を使用してフィルター処理が行われます。</span><span class="sxs-lookup"><span data-stu-id="f6086-264">If the role does not have a target specified, then this query filters against the difference between the max of the role and the number of members with that role.</span></span> | <span data-ttu-id="f6086-265">"session/roles/lfg/confirmed/needs le 15"</span><span class="sxs-lookup"><span data-stu-id="f6086-265">"session/roles/lfg/confirmed/needs le 15"</span></span>
 <span data-ttu-id="f6086-266">特定のキーワードを含むセッションを指すすべての検索ハンドル</span><span class="sxs-lookup"><span data-stu-id="f6086-266">All search handles that point to a session containing a particular keyword</span></span> | <span data-ttu-id="f6086-267">"session/keywords/any(d:tolower(d) eq 'level2')"</span><span class="sxs-lookup"><span data-stu-id="f6086-267">"session/keywords/any(d:tolower(d) eq 'level2')"</span></span>
 <span data-ttu-id="f6086-268">特定の scid に属するセッションを指すすべての検索ハンドル</span><span class="sxs-lookup"><span data-stu-id="f6086-268">All search handles that point to a session belonging to a particular scid</span></span> | <span data-ttu-id="f6086-269">"session/scid eq '151512315'"</span><span class="sxs-lookup"><span data-stu-id="f6086-269">"session/scid eq '151512315'"</span></span>
 <span data-ttu-id="f6086-270">特定のテンプレート名が使用されているセッションを指すすべての検索ハンドル</span><span class="sxs-lookup"><span data-stu-id="f6086-270">All search handles that point to a session that uses a particular template name</span></span> | <span data-ttu-id="f6086-271">"session/templateName eq 'mytemplate1'"</span><span class="sxs-lookup"><span data-stu-id="f6086-271">"session/templateName eq 'mytemplate1'"</span></span>
 <span data-ttu-id="f6086-272">'elite' というタグを持っているか、'guns' の数が 15 より大きく、文字列 'clan' が 'purple' に等しいすべての検索ハンドル</span><span class="sxs-lookup"><span data-stu-id="f6086-272">All search handles that have the tag 'elite' or have a number 'guns' greater than 15 and string 'clan' equal to 'purple'</span></span> | <span data-ttu-id="f6086-273">"tags/any(a:tolower(a) eq 'elite') or number/guns gt 15 and string/clan eq 'purple'"</span><span class="sxs-lookup"><span data-stu-id="f6086-273">"tags/any(a:tolower(a) eq 'elite') or number/guns gt 15 and string/clan eq 'purple'"</span></span>

### <a name="refreshing-search-results"></a><span data-ttu-id="f6086-274">検索結果を更新する</span><span class="sxs-lookup"><span data-stu-id="f6086-274">Refreshing search results</span></span>

 <span data-ttu-id="f6086-275">ゲームでは、セッションの一覧を自動的に更新せず、代わりにプレイヤーが一覧を手動で更新できる UI を提供する必要があります (たとえば、より望ましいフィルター結果が得られるように検索条件を調整した後)。</span><span class="sxs-lookup"><span data-stu-id="f6086-275">Your game should avoid automatically refreshing a list of sessions, but instead provide UI that allows a player to manually refresh the list (possibly after refining the search criteria to better filter the results).</span></span>

 <span data-ttu-id="f6086-276">プレイヤーがセッションに参加しようとしてもセッションに空きがないか閉じている場合も、ゲームは検索結果を更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f6086-276">If a player attempts to join a session, but that session is full or closed, then your game should refresh the search results as well.</span></span>

 <span data-ttu-id="f6086-277">検索の更新が多すぎるとサービスのスロットリングにつながるため、タイトルではクエリの更新頻度を制限する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f6086-277">Too many search refreshes can lead to service throttling, so your title should limit the rate at which the query can be refreshed.</span></span>

### <a name="example-query-for-search-handles"></a><span data-ttu-id="f6086-278">例: 検索ハンドルの照会</span><span class="sxs-lookup"><span data-stu-id="f6086-278">Example: query for search handles</span></span>

 <span data-ttu-id="f6086-279">次のコードでは、検索ハンドルを照会する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="f6086-279">The following code shows how to query for search handles.</span></span> <span data-ttu-id="f6086-280">API は、クエリに一致するすべての検索ハンドルを表す `multiplayer_search_handle_details` オブジェクトのコレクションを返します。</span><span class="sxs-lookup"><span data-stu-id="f6086-280">The API returns a collection of `multiplayer_search_handle_details` objects that represent all the search handles that match the query.</span></span>

```cpp
 auto result = multiplayer_service().get_search_handles(scid, template, orderBy, orderAscending, searchFilter)
 .then([](xbox_live_result<std::vector<multiplayer_search_handle_details>> result)
 {
   if (result.err())
   {
      // handle error
   }
   else
   {
      // parse result.payload
   }
 });

 /* Payload element properties

 multiplayer_search_handle_details
 {
   string_t& handle_id();
   multiplayer_session_reference& session_reference();
   std::vector<string_t>& session_owner_xbox_user_ids();
   std::vector<string_t>& tags();
   std::unordered_map<string_t, double>& numbers_metadata();
   std::unordered_map<string_t, string_t>& strings_metadata();
   std::unordered_map<string_t, multiplayer_role_type>& role_types();
 }
 */
```

## <a name="join-a-session-by-using-a-search-handle"></a><span data-ttu-id="f6086-281">検索ハンドルを使ってセッションに参加する</span><span class="sxs-lookup"><span data-stu-id="f6086-281">Join a session by using a search handle</span></span>

<span data-ttu-id="f6086-282">参加するセッションの検索ハンドルを取得したら、タイトルで `MultiplayerService::WriteSessionByHandleAsync()` または `multiplayer_service::write_session_by_handle()` を使って、自身をセッションに追加します。</span><span class="sxs-lookup"><span data-stu-id="f6086-282">Once you have retrieved a search handle for a session that you want to join, the title should use  `MultiplayerService::WriteSessionByHandleAsync()` or `multiplayer_service::write_session_by_handle()` to add themselves to the session.</span></span>

> [!NOTE]
> <span data-ttu-id="f6086-283">`WriteSessionAsync()` メソッドと `write_session()` メソッドは、セッション参照セッションに参加するためには使用できません。</span><span class="sxs-lookup"><span data-stu-id="f6086-283">The `WriteSessionAsync()` and `write_session()` methods cannot be used to join a session browse session.</span></span>

<span data-ttu-id="f6086-284">次のコードは、検索ハンドルの取得後にセッションに参加する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="f6086-284">The following code demonstrates how to join a session after retrieving a search handle.</span></span>

```cpp
void Sample::BrowseSearchHandles()
{
    auto context = m_liveResources->GetLiveContext();
    context->multiplayer_service().get_search_handles(...)
    .then([this](xbox_live_result<std::vector<multiplayer_search_handle_details>> searchHandles)
    {
        if (searchHandles.err())
        {
            LogErrorFormat( L"BrowseSearchHandles failed: %S\n", searchHandles.err_message().c_str() );
        }
        else
        {
            m_searchHandles = searchHandles.payload();

            // Join the game session

            auto handleId = m_searchHandles.at(0).handle_id();
            auto sessionRef = multiplayer_session_reference(m_searchHandles.at(0).session_reference());
            auto gameSession = std::make_shared<multiplayer_session>(m_liveResources->GetLiveContext()->xbox_live_user_id(), sessionRef);
            gameSession->join(web::json::value::null(), false, false, false);

            context->multiplayer_service().write_session_by_handle(gameSession, multiplayer_session_write_mode::update_existing, handleId)
            .then([this, sessionRef](xbox_live_result<std::shared_ptr<multiplayer_session>> writeResult)
            {
                if (!writeResult.err())
                {
                    // Join the game session via MPM
                    m_multiplayerManager->join_game(sessionRef.session_name(), sessionRef.session_template_name());
                }
            });
        }
    });
}
```
