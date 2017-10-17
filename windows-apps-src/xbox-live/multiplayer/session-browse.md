---
title: Multiplayer session browse
author: KevinAsgari
description: Learn how to implement multiplayer session browse by using Xbox Live multiplayer.
ms.assetid: b4b3ed67-9e2c-4c14-9b27-083b8bccb3ce
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, games, uwp, windows 10, xbox one
ms.openlocfilehash: 8b68663624c62800c1ab08d7714f6aafe301003c
ms.sourcegitcommit: fc695def93ba79064af709253ded5e0bfd634a9c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/25/2017
---
# <a name="multiplayer-session-browse"></a><span data-ttu-id="5794d-104">Multiplayer session browse</span><span class="sxs-lookup"><span data-stu-id="5794d-104">Multiplayer session browse</span></span>

<span data-ttu-id="5794d-105">Multiplayer session browse is a new feature introduced in November 2016 that enables a title to query for a list of open multiplayer game sessions that meet the specified criteria.</span><span class="sxs-lookup"><span data-stu-id="5794d-105">Multiplayer session browse is a new feature introduced in November 2016 that enables a title to query for a list of open multiplayer game sessions that meet the specified criteria.</span></span>

## <a name="what-is-session-browse"></a><span data-ttu-id="5794d-106">What is session browse?</span><span class="sxs-lookup"><span data-stu-id="5794d-106">What is session browse?</span></span>

<span data-ttu-id="5794d-107">In a session browse scenario, a player in a game is able to retrieve a list of joinable game sessions.</span><span class="sxs-lookup"><span data-stu-id="5794d-107">In a session browse scenario, a player in a game is able to retrieve a list of joinable game sessions.</span></span> <span data-ttu-id="5794d-108">Each session entry in this list contains some additional metadata about the game, which a player can use to help them select which session to join.</span><span class="sxs-lookup"><span data-stu-id="5794d-108">Each session entry in this list contains some additional metadata about the game, which a player can use to help them select which session to join.</span></span>  <span data-ttu-id="5794d-109">They can also filter the list of sessions based on the metadata.</span><span class="sxs-lookup"><span data-stu-id="5794d-109">They can also filter the list of sessions based on the metadata.</span></span> <span data-ttu-id="5794d-110">Once the player sees a game session that appeals to them, they can join the session.</span><span class="sxs-lookup"><span data-stu-id="5794d-110">Once the player sees a game session that appeals to them, they can join the session.</span></span>

<span data-ttu-id="5794d-111">A player can also create a new game session, and use session browse to recruit additional players instead of relying on matchmaking.</span><span class="sxs-lookup"><span data-stu-id="5794d-111">A player can also create a new game session, and use session browse to recruit additional players instead of relying on matchmaking.</span></span>

<span data-ttu-id="5794d-112">セッション参照が従来のマッチメイキング シナリオと異なる点として、マッチメイキングでは通常、プレイヤーは "ゲームの検索" ボタンをクリックすることにより、該当したゲーム セッションに自動的に配置されますが、セッション参照では参加するゲーム セッションをプレイヤーが自分で選択できます。</span><span class="sxs-lookup"><span data-stu-id="5794d-112">Session browse differs from traditional matchmaking scenarios in that the player self-selects which game session they want to join, while in matchmaking, the player typically clicks a "find a game" button that attempts to automatically place the player in an appropriate game session.</span></span> <span data-ttu-id="5794d-113">セッション参照は低速な手動のプロセスであり、客観的に見て常に最適なゲームが選ばれるとは限りませんが、プレイヤーに選択権が与えられるため、ゲームの選択結果は主観的により満足度の高いものになると考えられます。</span><span class="sxs-lookup"><span data-stu-id="5794d-113">While session browse is a manual and slower process that may not always select the objectively best game, it provides more control to the player and can be perceived as the subjectively better game pick.</span></span>

<span data-ttu-id="5794d-114">セッション参照とマッチメイキングの両方のシナリオをゲームに組み込むのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="5794d-114">It is common to include both session browse and matchmaking scenarios in games.</span></span> <span data-ttu-id="5794d-115">Typically matchmaking is used for commonly played game modes, while session browse is used for custom games.</span><span class="sxs-lookup"><span data-stu-id="5794d-115">Typically matchmaking is used for commonly played game modes, while session browse is used for custom games.</span></span>

<span data-ttu-id="5794d-116">**Example:** John may be interested in playing a hero battle arena style multiplayer game, but wants to play a game where all players select their hero randomly.</span><span class="sxs-lookup"><span data-stu-id="5794d-116">**Example:** John may be interested in playing a hero battle arena style multiplayer game, but wants to play a game where all players select their hero randomly.</span></span> <span data-ttu-id="5794d-117">He can retrieve a list of open game sessions and find the ones that include "random heroes" in their description, or if the game UI allows it, he can select the "random hero" game mode and retrieve only the sessions that are tagged to indicate that they are "RandomHero" games.</span><span class="sxs-lookup"><span data-stu-id="5794d-117">He can retrieve a list of open game sessions and find the ones that include "random heroes" in their description, or if the game UI allows it, he can select the "random hero" game mode and retrieve only the sessions that are tagged to indicate that they are "RandomHero" games.</span></span>

<span data-ttu-id="5794d-118">When he finds a game that he likes, he joins the game.</span><span class="sxs-lookup"><span data-stu-id="5794d-118">When he finds a game that he likes, he joins the game.</span></span> <span data-ttu-id="5794d-119">When enough people have joined the session, the host of the game session can start the game.</span><span class="sxs-lookup"><span data-stu-id="5794d-119">When enough people have joined the session, the host of the game session can start the game.</span></span>

### <a name="roles"></a><span data-ttu-id="5794d-120">Roles</span><span class="sxs-lookup"><span data-stu-id="5794d-120">Roles</span></span>

<span data-ttu-id="5794d-121">A game in session browse may want to recruit players for specific roles.</span><span class="sxs-lookup"><span data-stu-id="5794d-121">A game in session browse may want to recruit players for specific roles.</span></span> <span data-ttu-id="5794d-122">For example, a player may want to create a game session that specifies that the session contains no more than 5 assault classes, but must contain at least 2 healer roles, and at least 1 tank role.</span><span class="sxs-lookup"><span data-stu-id="5794d-122">For example, a player may want to create a game session that specifies that the session contains no more than 5 assault classes, but must contain at least 2 healer roles, and at least 1 tank role.</span></span>

<span data-ttu-id="5794d-123">When another player applies for the session, they can pre-select their role, and the service will not allow them to join the session if there are no open slots for the role they have selected.</span><span class="sxs-lookup"><span data-stu-id="5794d-123">When another player applies for the session, they can pre-select their role, and the service will not allow them to join the session if there are no open slots for the role they have selected.</span></span>

<span data-ttu-id="5794d-124">Another example would be if a player wants to reserve 2 slots for their friends to join, the game can specify a "friends" role, and only players that are friends with the session host can fill the 2 slots dedicated to the "friends" role.</span><span class="sxs-lookup"><span data-stu-id="5794d-124">Another example would be if a player wants to reserve 2 slots for their friends to join, the game can specify a "friends" role, and only players that are friends with the session host can fill the 2 slots dedicated to the "friends" role.</span></span>

<span data-ttu-id="5794d-125">For more information about roles, see [multiplayer roles](multiplayer-roles.md).</span><span class="sxs-lookup"><span data-stu-id="5794d-125">For more information about roles, see [multiplayer roles](multiplayer-roles.md).</span></span>



## <a name="how-does-session-browse-work"></a><span data-ttu-id="5794d-126">How does session browse work?</span><span class="sxs-lookup"><span data-stu-id="5794d-126">How does session browse work?</span></span>

<span data-ttu-id="5794d-127">Session browse works primarily on the use of search handles.</span><span class="sxs-lookup"><span data-stu-id="5794d-127">Session browse works primarily on the use of search handles.</span></span> <span data-ttu-id="5794d-128">A search handle is a packet of data that contains a reference to the session, as well as additional metadata about the session, namely search attributes.</span><span class="sxs-lookup"><span data-stu-id="5794d-128">A search handle is a packet of data that contains a reference to the session, as well as additional metadata about the session, namely search attributes.</span></span>

<span data-ttu-id="5794d-129">When a title creates a new game session that is eligible for session browse, it creates a search handle for the session.</span><span class="sxs-lookup"><span data-stu-id="5794d-129">When a title creates a new game session that is eligible for session browse, it creates a search handle for the session.</span></span> <span data-ttu-id="5794d-130">The search handle is stored in the Multiplayer Service Directory (MPSD), which maintains the search handles for the title.</span><span class="sxs-lookup"><span data-stu-id="5794d-130">The search handle is stored in the Multiplayer Service Directory (MPSD), which maintains the search handles for the title.</span></span>

<span data-ttu-id="5794d-131">When a title needs to retrieve a list of sessions, the title can send a search query to MPSD, which will return a list of search handles that meet the search criteria.</span><span class="sxs-lookup"><span data-stu-id="5794d-131">When a title needs to retrieve a list of sessions, the title can send a search query to MPSD, which will return a list of search handles that meet the search criteria.</span></span> <span data-ttu-id="5794d-132">The title can then use the list of sessions to display a list of joinable games to the player.</span><span class="sxs-lookup"><span data-stu-id="5794d-132">The title can then use the list of sessions to display a list of joinable games to the player.</span></span>

<span data-ttu-id="5794d-133">When a session is full, or otherwise cannot be joined, a title can remove the search handle from MPSD so that the session will no longer show up in session browse queries.</span><span class="sxs-lookup"><span data-stu-id="5794d-133">When a session is full, or otherwise cannot be joined, a title can remove the search handle from MPSD so that the session will no longer show up in session browse queries.</span></span>


## <a name="set-up-a-session-for-session-browse"></a><span data-ttu-id="5794d-134">Set up a session for session browse</span><span class="sxs-lookup"><span data-stu-id="5794d-134">Set up a session for session browse</span></span>

<span data-ttu-id="5794d-135">セッションで検索ハンドルを使用するには、セッションで次の機能が true に設定されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="5794d-135">In order to use search handles for a session, the session must have the following capabilities set to true:</span></span>

* `searchable`
* `userAuthorizationStyle`
* `hasOwners`

>[!NOTE]
> <span data-ttu-id="5794d-136">`userAuthorizationStyle` 機能と `hasOwners` 機能は UWP ゲームでのみ必須となりますが、XDK ゲームを含むすべての Xbox Live ゲームに実装することをお勧めします。これにより、将来の移植性が保証されます。</span><span class="sxs-lookup"><span data-stu-id="5794d-136">The `userAuthorizationStyle` and `hasOwners` capabilities are only required for UWP games, but we recommend implementing them for all Xbox Live games, including XDK games, as it ensures future portability.</span></span>

>[!NOTE]
> <span data-ttu-id="5794d-137">`userAuthorizationStyle` 機能を設定すると、既定でセッションの `readRestriction` と `joinRestriction` が `none` ではなく `local` になります。</span><span class="sxs-lookup"><span data-stu-id="5794d-137">Setting the `userAuthorizationStyle` capability defaults the `readRestriction` and `joinRestriction` of the session to `local` instead of `none`.</span></span> <span data-ttu-id="5794d-138">つまり、ゲーム セッションに参加するには、タイトルで検索ハンドルまたは転送ハンドルを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="5794d-138">This means that titles must use search handles or transfer handles to join a game session.</span></span>

<span data-ttu-id="5794d-139">さらに、検索可能なセッションには所有者が必要であるため、`owernshipPolicy.migration` が "oldest" または "endsession" に設定されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="5794d-139">In addition, since searchable sessions must have owners, the `owernshipPolicy.migration` must be set to either "oldest" or "endsession".</span></span>

<span data-ttu-id="5794d-140">You can set these capabilities in the session template when you configure your Xbox Live services.</span><span class="sxs-lookup"><span data-stu-id="5794d-140">You can set these capabilities in the session template when you configure your Xbox Live services.</span></span>

<span data-ttu-id="5794d-141">For session browse, you should only create search handles on sessions that will be used for actual gameplay, not for lobby sessions.</span><span class="sxs-lookup"><span data-stu-id="5794d-141">For session browse, you should only create search handles on sessions that will be used for actual gameplay, not for lobby sessions.</span></span>

## <a name="what-does-it-mean-to-be-an-owner-of-a-session"></a><span data-ttu-id="5794d-142">What does it mean to be an owner of a session?</span><span class="sxs-lookup"><span data-stu-id="5794d-142">What does it mean to be an owner of a session?</span></span>

<span data-ttu-id="5794d-143">While many game session types, such as SmartMatch or a friends only game, do not require an owner, every session browse session must have at least one owner.</span><span class="sxs-lookup"><span data-stu-id="5794d-143">While many game session types, such as SmartMatch or a friends only game, do not require an owner, every session browse session must have at least one owner.</span></span> <span data-ttu-id="5794d-144">Only a member that is marked as an owner of a session can create a search handle for that session.</span><span class="sxs-lookup"><span data-stu-id="5794d-144">Only a member that is marked as an owner of a session can create a search handle for that session.</span></span>

<span data-ttu-id="5794d-145">In addition, only owners can remove other members from the session, or change the ownership status of other members.</span><span class="sxs-lookup"><span data-stu-id="5794d-145">In addition, only owners can remove other members from the session, or change the ownership status of other members.</span></span>

<span data-ttu-id="5794d-146">If an owner of a session has an Xbox Live member blocked, that member cannot join the session.</span><span class="sxs-lookup"><span data-stu-id="5794d-146">If an owner of a session has an Xbox Live member blocked, that member cannot join the session.</span></span>

<span data-ttu-id="5794d-147">If all owners leave a session, then the service takes action on the session based the `ownershipPolicy.migration` policy that is defined for the session.</span><span class="sxs-lookup"><span data-stu-id="5794d-147">If all owners leave a session, then the service takes action on the session based the `ownershipPolicy.migration` policy that is defined for the session.</span></span> <span data-ttu-id="5794d-148">If the policy is "oldest", then the player that has been in the session the longest is set to be the new owner.</span><span class="sxs-lookup"><span data-stu-id="5794d-148">If the policy is "oldest", then the player that has been in the session the longest is set to be the new owner.</span></span> <span data-ttu-id="5794d-149">If the policy is "endsession", then the service ends the session and removes all remaining players from the session.</span><span class="sxs-lookup"><span data-stu-id="5794d-149">If the policy is "endsession", then the service ends the session and removes all remaining players from the session.</span></span>


## <a name="search-handles"></a><span data-ttu-id="5794d-150">Search handles</span><span class="sxs-lookup"><span data-stu-id="5794d-150">Search handles</span></span>

<span data-ttu-id="5794d-151">A search handle is stored in MSPD as a JSON structure.</span><span class="sxs-lookup"><span data-stu-id="5794d-151">A search handle is stored in MSPD as a JSON structure.</span></span> <span data-ttu-id="5794d-152">In addition to containing a reference to the session, search handles also contain additional metadata for searches, known as search attributes.</span><span class="sxs-lookup"><span data-stu-id="5794d-152">In addition to containing a reference to the session, search handles also contain additional metadata for searches, known as search attributes.</span></span>

<span data-ttu-id="5794d-153">A session can only have one search handle created for it at any time.</span><span class="sxs-lookup"><span data-stu-id="5794d-153">A session can only have one search handle created for it at any time.</span></span>

<span data-ttu-id="5794d-154">To create a search handle for a session in by using the Xbox Live APIs, you first create a `multiplayer::multiplayer_search_handle_request` object, and then pass that object to the `multiplayer::multiplayer_service::set_search_handle()` method.</span><span class="sxs-lookup"><span data-stu-id="5794d-154">To create a search handle for a session in by using the Xbox Live APIs, you first create a `multiplayer::multiplayer_search_handle_request` object, and then pass that object to the `multiplayer::multiplayer_service::set_search_handle()` method.</span></span>

### <a name="search-attributes"></a><span data-ttu-id="5794d-155">Search attributes</span><span class="sxs-lookup"><span data-stu-id="5794d-155">Search attributes</span></span>

<span data-ttu-id="5794d-156">Search attributes consists of the following components:</span><span class="sxs-lookup"><span data-stu-id="5794d-156">Search attributes consists of the following components:</span></span>

`tags` <span data-ttu-id="5794d-157">- Tags are string descriptors that people can use to categorize a game session, similar to a hashtag.</span><span class="sxs-lookup"><span data-stu-id="5794d-157">- Tags are string descriptors that people can use to categorize a game session, similar to a hashtag.</span></span> <span data-ttu-id="5794d-158">Tags must start with a letter, cannot contain spaces, and must be less than 100 characters.</span><span class="sxs-lookup"><span data-stu-id="5794d-158">Tags must start with a letter, cannot contain spaces, and must be less than 100 characters.</span></span>
<span data-ttu-id="5794d-159">Example tags: "ProRankOnly", "norocketlaunchers", "cityMaps".</span><span class="sxs-lookup"><span data-stu-id="5794d-159">Example tags: "ProRankOnly", "norocketlaunchers", "cityMaps".</span></span>

`strings` <span data-ttu-id="5794d-160">- Strings are text variables, and the string names must start with a letter, cannot contain spaces, and must be less than 100 characters.</span><span class="sxs-lookup"><span data-stu-id="5794d-160">- Strings are text variables, and the string names must start with a letter, cannot contain spaces, and must be less than 100 characters.</span></span>

<span data-ttu-id="5794d-161">Example string metadata: "Weapons"="knives+pistols+rifles", "MapName"="UrbanCityAssault", "description"="Fun casual game, new people welcome."</span><span class="sxs-lookup"><span data-stu-id="5794d-161">Example string metadata: "Weapons"="knives+pistols+rifles", "MapName"="UrbanCityAssault", "description"="Fun casual game, new people welcome."</span></span>

`numbers` <span data-ttu-id="5794d-162">- Numbers are numeric variables, and the number names must start with a letter, cannot contain spaces, and must be less than 100 characters.</span><span class="sxs-lookup"><span data-stu-id="5794d-162">- Numbers are numeric variables, and the number names must start with a letter, cannot contain spaces, and must be less than 100 characters.</span></span> <span data-ttu-id="5794d-163">The Xbox Live APIs retrieve number values as type float.</span><span class="sxs-lookup"><span data-stu-id="5794d-163">The Xbox Live APIs retrieve number values as type float.</span></span>

<span data-ttu-id="5794d-164">Example number metadata: "MinLevel" = 25, "MaxRank" = 10.</span><span class="sxs-lookup"><span data-stu-id="5794d-164">Example number metadata: "MinLevel" = 25, "MaxRank" = 10.</span></span>

><span data-ttu-id="5794d-165">**Note:** The letter casing of tags and string values is preserved in the service, but you must use the tolower() function when you query for tags.</span><span class="sxs-lookup"><span data-stu-id="5794d-165">**Note:** The letter casing of tags and string values is preserved in the service, but you must use the tolower() function when you query for tags.</span></span> <span data-ttu-id="5794d-166">This means that tags and string values are currently all treated as lower case, even if they contain upper case characters.</span><span class="sxs-lookup"><span data-stu-id="5794d-166">This means that tags and string values are currently all treated as lower case, even if they contain upper case characters.</span></span>

<span data-ttu-id="5794d-167">In the Xbox Live APIs, you can set the search attributes by using the `set_tags()`, `set_stringsmetadata()`, and `set_numbers_metadata()` methods of a `multiplayer_search_handle_request` object.</span><span class="sxs-lookup"><span data-stu-id="5794d-167">In the Xbox Live APIs, you can set the search attributes by using the `set_tags()`, `set_stringsmetadata()`, and `set_numbers_metadata()` methods of a `multiplayer_search_handle_request` object.</span></span>


### <a name="additional-details"></a><span data-ttu-id="5794d-168">Additional details</span><span class="sxs-lookup"><span data-stu-id="5794d-168">Additional details</span></span>

<span data-ttu-id="5794d-169">When you retrieve a search handle, the results also include additional useful data about the session, such as if the session is closed, are there any join restrictions on the session, etc.</span><span class="sxs-lookup"><span data-stu-id="5794d-169">When you retrieve a search handle, the results also include additional useful data about the session, such as if the session is closed, are there any join restrictions on the session, etc.</span></span>

<span data-ttu-id="5794d-170">In the Xbox Live APIs, these details, along with the search attributes, are included in the `multiplayer_search_handle_details` that are returned after a search query.</span><span class="sxs-lookup"><span data-stu-id="5794d-170">In the Xbox Live APIs, these details, along with the search attributes, are included in the `multiplayer_search_handle_details` that are returned after a search query.</span></span>

### <a name="remove-a-search-handle"></a><span data-ttu-id="5794d-171">Remove a search handle</span><span class="sxs-lookup"><span data-stu-id="5794d-171">Remove a search handle</span></span>

<span data-ttu-id="5794d-172">When you want to remove a session from session browse, such as when the session is full, or if the session is closed, you can delete the search handle.</span><span class="sxs-lookup"><span data-stu-id="5794d-172">When you want to remove a session from session browse, such as when the session is full, or if the session is closed, you can delete the search handle.</span></span>

<span data-ttu-id="5794d-173">In the Xbox Live APIs, you can use the `multiplayer_service::clear_search_handle()` method to remove a search handle.</span><span class="sxs-lookup"><span data-stu-id="5794d-173">In the Xbox Live APIs, you can use the `multiplayer_service::clear_search_handle()` method to remove a search handle.</span></span>

### <a name="example-create-a-search-handle-with-metadata"></a><span data-ttu-id="5794d-174">Example: Create a search handle with metadata</span><span class="sxs-lookup"><span data-stu-id="5794d-174">Example: Create a search handle with metadata</span></span>

<span data-ttu-id="5794d-175">The following code shows how to create a search handle for a session by using the C++ Xbox Live multiplayer APIs.</span><span class="sxs-lookup"><span data-stu-id="5794d-175">The following code shows how to create a search handle for a session by using the C++ Xbox Live multiplayer APIs.</span></span>

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


## <a name="create-a-search-query-for-sessions"></a><span data-ttu-id="5794d-176">Create a search query for sessions</span><span class="sxs-lookup"><span data-stu-id="5794d-176">Create a search query for sessions</span></span>

<span data-ttu-id="5794d-177">When retrieving a list of search handles, you can use a search query to restrict the results to the sessions that meet specific criteria.</span><span class="sxs-lookup"><span data-stu-id="5794d-177">When retrieving a list of search handles, you can use a search query to restrict the results to the sessions that meet specific criteria.</span></span>

<span data-ttu-id="5794d-178">The search query syntax is an  [OData](http://docs.oasis-open.org/odata/odata/v4.0/errata02/os/complete/part2-url-conventions/odata-v4.0-errata02-os-part2-url-conventions-complete.html#_Toc406398092) style syntax, with only the following operators supported:</span><span class="sxs-lookup"><span data-stu-id="5794d-178">The search query syntax is an  [OData](http://docs.oasis-open.org/odata/odata/v4.0/errata02/os/complete/part2-url-conventions/odata-v4.0-errata02-os-part2-url-conventions-complete.html#_Toc406398092) style syntax, with only the following operators supported:</span></span>

 <span data-ttu-id="5794d-179">Operator</span><span class="sxs-lookup"><span data-stu-id="5794d-179">Operator</span></span> | <span data-ttu-id="5794d-180">Description</span><span class="sxs-lookup"><span data-stu-id="5794d-180">Description</span></span>
 --- | ---
 <span data-ttu-id="5794d-181">eq</span><span class="sxs-lookup"><span data-stu-id="5794d-181">eq</span></span> | <span data-ttu-id="5794d-182">equals (次の値と等しい)</span><span class="sxs-lookup"><span data-stu-id="5794d-182">equals</span></span>
 <span data-ttu-id="5794d-183">ne</span><span class="sxs-lookup"><span data-stu-id="5794d-183">ne</span></span> | <span data-ttu-id="5794d-184">not equal to (次の値と等しくない)</span><span class="sxs-lookup"><span data-stu-id="5794d-184">not equal to</span></span>
 <span data-ttu-id="5794d-185">gt</span><span class="sxs-lookup"><span data-stu-id="5794d-185">gt</span></span> | <span data-ttu-id="5794d-186">greater than</span><span class="sxs-lookup"><span data-stu-id="5794d-186">greater than</span></span>
 <span data-ttu-id="5794d-187">ge</span><span class="sxs-lookup"><span data-stu-id="5794d-187">ge</span></span> | <span data-ttu-id="5794d-188">greater than or equal</span><span class="sxs-lookup"><span data-stu-id="5794d-188">greater than or equal</span></span>
 <span data-ttu-id="5794d-189">lt</span><span class="sxs-lookup"><span data-stu-id="5794d-189">lt</span></span> | <span data-ttu-id="5794d-190">less than</span><span class="sxs-lookup"><span data-stu-id="5794d-190">less than</span></span>
 <span data-ttu-id="5794d-191">le</span><span class="sxs-lookup"><span data-stu-id="5794d-191">le</span></span> | <span data-ttu-id="5794d-192">less than or equal</span><span class="sxs-lookup"><span data-stu-id="5794d-192">less than or equal</span></span>
 <span data-ttu-id="5794d-193">and</span><span class="sxs-lookup"><span data-stu-id="5794d-193">and</span></span> | <span data-ttu-id="5794d-194">論理 AND</span><span class="sxs-lookup"><span data-stu-id="5794d-194">logical AND</span></span>
 <span data-ttu-id="5794d-195">or</span><span class="sxs-lookup"><span data-stu-id="5794d-195">or</span></span> | <span data-ttu-id="5794d-196">論理 OR (下の「注」を参照)</span><span class="sxs-lookup"><span data-stu-id="5794d-196">logical OR (see note below)</span></span>

<span data-ttu-id="5794d-197">また、ラムダ式と `tolower` 正規関数も使用できます。</span><span class="sxs-lookup"><span data-stu-id="5794d-197">You can also use lambda expressions and the `tolower` canonical function.</span></span> <span data-ttu-id="5794d-198">No other OData functions are supported currently.</span><span class="sxs-lookup"><span data-stu-id="5794d-198">No other OData functions are supported currently.</span></span>

<span data-ttu-id="5794d-199">When searching for tags or string values, you must use the 'tolower' function in the search query, as the service only currently supports searching for lower-case strings.</span><span class="sxs-lookup"><span data-stu-id="5794d-199">When searching for tags or string values, you must use the 'tolower' function in the search query, as the service only currently supports searching for lower-case strings.</span></span>

<span data-ttu-id="5794d-200">The Xbox Live service only returns the first 100 results that match the search query.</span><span class="sxs-lookup"><span data-stu-id="5794d-200">The Xbox Live service only returns the first 100 results that match the search query.</span></span> <span data-ttu-id="5794d-201">ゲームでは、結果が多すぎる場合にプレイヤーが検索クエリを絞り込むことができるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="5794d-201">Your game should allow players to refine their search query if the results are too broad.</span></span>

>[!NOTE]
>  <span data-ttu-id="5794d-202">フィルター文字列のクエリでは論理 OR がサポートされますが、使用できる OR は 1 つだけで、クエリのルートに指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5794d-202">Logical ORs are supported in filter string queries; however only one OR is allowed and it must be at the root of your query.</span></span> <span data-ttu-id="5794d-203">クエリに複数の OR を含めることはできません。また、OR がクエリ構造の最上位でない位置に出現するクエリを作成することもできません。</span><span class="sxs-lookup"><span data-stu-id="5794d-203">You cannot have multiple ORs in your query, nor can you create a query that would result in OR not being at the top most level of the query structure.</span></span>

### <a name="search-handle-query-examples"></a><span data-ttu-id="5794d-204">検索ハンドルのクエリの例</span><span class="sxs-lookup"><span data-stu-id="5794d-204">Search handle query examples</span></span>

<span data-ttu-id="5794d-205">In a restful call, "Filter" is where you would specify an OData Filter language string that will be run in your query against all search handles.</span><span class="sxs-lookup"><span data-stu-id="5794d-205">In a restful call, "Filter" is where you would specify an OData Filter language string that will be run in your query against all search handles.</span></span>  
<span data-ttu-id="5794d-206">In the multiplayer 2015 APIs, you can specify the search filter string in the *searchFilter* parameter of the `multiplayer_service.get_search_handles()` method.</span><span class="sxs-lookup"><span data-stu-id="5794d-206">In the multiplayer 2015 APIs, you can specify the search filter string in the *searchFilter* parameter of the `multiplayer_service.get_search_handles()` method.</span></span>  

<span data-ttu-id="5794d-207">Currently, the following filter scenarios are supported:</span><span class="sxs-lookup"><span data-stu-id="5794d-207">Currently, the following filter scenarios are supported:</span></span>

 <span data-ttu-id="5794d-208">Filter by</span><span class="sxs-lookup"><span data-stu-id="5794d-208">Filter by</span></span> | <span data-ttu-id="5794d-209">Search filter string</span><span class="sxs-lookup"><span data-stu-id="5794d-209">Search filter string</span></span>
 --- | ---
 <span data-ttu-id="5794d-210">A single member xuid '1234566’</span><span class="sxs-lookup"><span data-stu-id="5794d-210">A single member xuid '1234566’</span></span> | <span data-ttu-id="5794d-211">"session/memberXuids/any(d:d eq '1234566')"</span><span class="sxs-lookup"><span data-stu-id="5794d-211">"session/memberXuids/any(d:d eq '1234566')"</span></span>
 <span data-ttu-id="5794d-212">A single owner xuid '1234566’</span><span class="sxs-lookup"><span data-stu-id="5794d-212">A single owner xuid '1234566’</span></span> | <span data-ttu-id="5794d-213">"session/ownerXuids/any(d:d eq '1234566')"</span><span class="sxs-lookup"><span data-stu-id="5794d-213">"session/ownerXuids/any(d:d eq '1234566')"</span></span>
 <span data-ttu-id="5794d-214">A string 'forzacarclass' equal to 'classb‘</span><span class="sxs-lookup"><span data-stu-id="5794d-214">A string 'forzacarclass' equal to 'classb‘</span></span> | <span data-ttu-id="5794d-215">"tolower(strings/forzacarclass) eq 'classb'"</span><span class="sxs-lookup"><span data-stu-id="5794d-215">"tolower(strings/forzacarclass) eq 'classb'"</span></span>
 <span data-ttu-id="5794d-216">A number 'forzaskill' equal to 6</span><span class="sxs-lookup"><span data-stu-id="5794d-216">A number 'forzaskill' equal to 6</span></span> | <span data-ttu-id="5794d-217">"numbers/forzaskill eq 6"</span><span class="sxs-lookup"><span data-stu-id="5794d-217">"numbers/forzaskill eq 6"</span></span>
 <span data-ttu-id="5794d-218">A number 'halokdratio' greater than 1.5</span><span class="sxs-lookup"><span data-stu-id="5794d-218">A number 'halokdratio' greater than 1.5</span></span> | <span data-ttu-id="5794d-219">"numbers/halokdratio gt 1.5"</span><span class="sxs-lookup"><span data-stu-id="5794d-219">"numbers/halokdratio gt 1.5"</span></span>
 <span data-ttu-id="5794d-220">A tag 'coolpeopleonly'</span><span class="sxs-lookup"><span data-stu-id="5794d-220">A tag 'coolpeopleonly'</span></span> | <span data-ttu-id="5794d-221">"tags/any(d:tolower(d) eq 'coolpeopleonly')"</span><span class="sxs-lookup"><span data-stu-id="5794d-221">"tags/any(d:tolower(d) eq 'coolpeopleonly')"</span></span>
 <span data-ttu-id="5794d-222">タグ 'cursingallowed' を含まないセッション</span><span class="sxs-lookup"><span data-stu-id="5794d-222">Sessions that do not contain the tag 'cursingallowed'</span></span> | <span data-ttu-id="5794d-223">"tags/any(d:tolower(d) ne 'cursingallowed')"</span><span class="sxs-lookup"><span data-stu-id="5794d-223">"tags/any(d:tolower(d) ne 'cursingallowed')"</span></span>
 <span data-ttu-id="5794d-224">数値が 0 に等しい 'rank' を含まないセッション</span><span class="sxs-lookup"><span data-stu-id="5794d-224">Sessions that do not contain a number 'rank' that is equal to 0</span></span> | <span data-ttu-id="5794d-225">"numbers/rank ne 0"</span><span class="sxs-lookup"><span data-stu-id="5794d-225">"numbers/rank ne 0"</span></span>
 <span data-ttu-id="5794d-226">文字列が 'classa' に等しい 'forzacarclass' を含まないセッション</span><span class="sxs-lookup"><span data-stu-id="5794d-226">Sessions that do not contain a string 'forzacarclass' that is equal to 'classa'</span></span> | <span data-ttu-id="5794d-227">"tolower(strings/forzacarclass) ne 'classa'"</span><span class="sxs-lookup"><span data-stu-id="5794d-227">"tolower(strings/forzacarclass) ne 'classa'"</span></span>
 <span data-ttu-id="5794d-228">タグが 'coolpeopleonly' であり、数値 'halokdratio' が 7.5 に等しい</span><span class="sxs-lookup"><span data-stu-id="5794d-228">A tag 'coolpeopleonly' and a number 'halokdratio' equal to 7.5</span></span> | <span data-ttu-id="5794d-229">"tags/any(d:tolower(d) eq 'coolpeopleonly') eq true and numbers/halokdratio eq 7.5"</span><span class="sxs-lookup"><span data-stu-id="5794d-229">"tags/any(d:tolower(d) eq 'coolpeopleonly') eq true and numbers/halokdratio eq 7.5"</span></span>
 <span data-ttu-id="5794d-230">A number 'halodkratio' greater than or equal to 1.5, a number 'rank' less than 60, and a number 'customnumbervalue' less than or equal to 5</span><span class="sxs-lookup"><span data-stu-id="5794d-230">A number 'halodkratio' greater than or equal to 1.5, a number 'rank' less than 60, and a number 'customnumbervalue' less than or equal to 5</span></span> | <span data-ttu-id="5794d-231">"numbers/halokdratio ge 1.5 and numbers/rank lt 60 and numbers/customnumbervalue le 5"</span><span class="sxs-lookup"><span data-stu-id="5794d-231">"numbers/halokdratio ge 1.5 and numbers/rank lt 60 and numbers/customnumbervalue le 5"</span></span>
 <span data-ttu-id="5794d-232">An achievement id '123456'</span><span class="sxs-lookup"><span data-stu-id="5794d-232">An achievement id '123456'</span></span> | <span data-ttu-id="5794d-233">"achievementIds/any(d:d eq '123456')"</span><span class="sxs-lookup"><span data-stu-id="5794d-233">"achievementIds/any(d:d eq '123456')"</span></span>
 <span data-ttu-id="5794d-234">The language code 'en'</span><span class="sxs-lookup"><span data-stu-id="5794d-234">The language code 'en'</span></span> | <span data-ttu-id="5794d-235">"language eq 'en'"</span><span class="sxs-lookup"><span data-stu-id="5794d-235">"language eq 'en'"</span></span>
 <span data-ttu-id="5794d-236">Scheduled time, returns all scheduled times less than or equal to the specified time</span><span class="sxs-lookup"><span data-stu-id="5794d-236">Scheduled time, returns all scheduled times less than or equal to the specified time</span></span> | <span data-ttu-id="5794d-237">"session/scheduledTime le '2009-06-15T13:45:30.0900000Z'"</span><span class="sxs-lookup"><span data-stu-id="5794d-237">"session/scheduledTime le '2009-06-15T13:45:30.0900000Z'"</span></span>
 <span data-ttu-id="5794d-238">Posted time, returns all posted times less than the specified time</span><span class="sxs-lookup"><span data-stu-id="5794d-238">Posted time, returns all posted times less than the specified time</span></span> | <span data-ttu-id="5794d-239">"session/postedTime lt '2009-06-15T13:45:30.0900000Z'"</span><span class="sxs-lookup"><span data-stu-id="5794d-239">"session/postedTime lt '2009-06-15T13:45:30.0900000Z'"</span></span>
 <span data-ttu-id="5794d-240">Session registration state</span><span class="sxs-lookup"><span data-stu-id="5794d-240">Session registration state</span></span> | <span data-ttu-id="5794d-241">"session/registrationState eq 'registered'"</span><span class="sxs-lookup"><span data-stu-id="5794d-241">"session/registrationState eq 'registered'"</span></span>
 <span data-ttu-id="5794d-242">Where the number of session members is equal to 5</span><span class="sxs-lookup"><span data-stu-id="5794d-242">Where the number of session members is equal to 5</span></span> | <span data-ttu-id="5794d-243">"session/membersCount eq 5"</span><span class="sxs-lookup"><span data-stu-id="5794d-243">"session/membersCount eq 5"</span></span>
 <span data-ttu-id="5794d-244">Where the session member target count is greater than 1</span><span class="sxs-lookup"><span data-stu-id="5794d-244">Where the session member target count is greater than 1</span></span> | <span data-ttu-id="5794d-245">"session/targetMembersCount gt 1"</span><span class="sxs-lookup"><span data-stu-id="5794d-245">"session/targetMembersCount gt 1"</span></span>
 <span data-ttu-id="5794d-246">Where the max count of session members is less than 3</span><span class="sxs-lookup"><span data-stu-id="5794d-246">Where the max count of session members is less than 3</span></span> | <span data-ttu-id="5794d-247">"session/maxMembersCount lt 3"</span><span class="sxs-lookup"><span data-stu-id="5794d-247">"session/maxMembersCount lt 3"</span></span>
 <span data-ttu-id="5794d-248">Where the difference between the session member target count and the number of session members is less than or equal to 5</span><span class="sxs-lookup"><span data-stu-id="5794d-248">Where the difference between the session member target count and the number of session members is less than or equal to 5</span></span> | <span data-ttu-id="5794d-249">"session/targetMembersCountRemaining le 5"</span><span class="sxs-lookup"><span data-stu-id="5794d-249">"session/targetMembersCountRemaining le 5"</span></span>
 <span data-ttu-id="5794d-250">Where the difference between the max count of session members and the number of session members is greater than 2</span><span class="sxs-lookup"><span data-stu-id="5794d-250">Where the difference between the max count of session members and the number of session members is greater than 2</span></span> | <span data-ttu-id="5794d-251">"session/maxMembersCountRemaining gt 2"</span><span class="sxs-lookup"><span data-stu-id="5794d-251">"session/maxMembersCountRemaining gt 2"</span></span>
 <span data-ttu-id="5794d-252">Where the difference between the session member target count and the number of session members is less than or equal to 15.</span><span class="sxs-lookup"><span data-stu-id="5794d-252">Where the difference between the session member target count and the number of session members is less than or equal to 15.</span></span></br> <span data-ttu-id="5794d-253">If the role does not have a target specified, then this query filters against the difference between the max count of session members and the number of session members.</span><span class="sxs-lookup"><span data-stu-id="5794d-253">If the role does not have a target specified, then this query filters against the difference between the max count of session members and the number of session members.</span></span> | <span data-ttu-id="5794d-254">"session/needs le 15"</span><span class="sxs-lookup"><span data-stu-id="5794d-254">"session/needs le 15"</span></span>
 <span data-ttu-id="5794d-255">Role "confirmed" of the role type "lfg" where the number of members with that role is equal to 5</span><span class="sxs-lookup"><span data-stu-id="5794d-255">Role "confirmed" of the role type "lfg" where the number of members with that role is equal to 5</span></span> | <span data-ttu-id="5794d-256">"session/roles/lfg/confirmed/count eq 5"</span><span class="sxs-lookup"><span data-stu-id="5794d-256">"session/roles/lfg/confirmed/count eq 5"</span></span>
 <span data-ttu-id="5794d-257">Role "confirmed" of the role type "lfg" where the target of that role is greater than 1.</span><span class="sxs-lookup"><span data-stu-id="5794d-257">Role "confirmed" of the role type "lfg" where the target of that role is greater than 1.</span></span></br> <span data-ttu-id="5794d-258">If the role does not have a target specified, then the max of the role is used instead.</span><span class="sxs-lookup"><span data-stu-id="5794d-258">If the role does not have a target specified, then the max of the role is used instead.</span></span> | <span data-ttu-id="5794d-259">"session/roles/lfg/confirmed/target gt 1"</span><span class="sxs-lookup"><span data-stu-id="5794d-259">"session/roles/lfg/confirmed/target gt 1"</span></span>
 <span data-ttu-id="5794d-260">Role "confirmed" of the role type "lfg" where the difference between the target of the role and the number of members with that role is less than or equal to 15.</span><span class="sxs-lookup"><span data-stu-id="5794d-260">Role "confirmed" of the role type "lfg" where the difference between the target of the role and the number of members with that role is less than or equal to 15.</span></span></br> <span data-ttu-id="5794d-261">If the role does not have a target specified, then this query filters against the difference between the max of the role and the number of members with that role.</span><span class="sxs-lookup"><span data-stu-id="5794d-261">If the role does not have a target specified, then this query filters against the difference between the max of the role and the number of members with that role.</span></span> | <span data-ttu-id="5794d-262">"session/roles/lfg/confirmed/needs le 15"</span><span class="sxs-lookup"><span data-stu-id="5794d-262">"session/roles/lfg/confirmed/needs le 15"</span></span>
 <span data-ttu-id="5794d-263">All search handles that point to a session containing a particular keyword</span><span class="sxs-lookup"><span data-stu-id="5794d-263">All search handles that point to a session containing a particular keyword</span></span> | <span data-ttu-id="5794d-264">"session/keywords/any(d:tolower(d) eq 'level2')"</span><span class="sxs-lookup"><span data-stu-id="5794d-264">"session/keywords/any(d:tolower(d) eq 'level2')"</span></span>
 <span data-ttu-id="5794d-265">All search handles that point to a session belonging to a particular scid</span><span class="sxs-lookup"><span data-stu-id="5794d-265">All search handles that point to a session belonging to a particular scid</span></span> | <span data-ttu-id="5794d-266">"session/scid eq '151512315'"</span><span class="sxs-lookup"><span data-stu-id="5794d-266">"session/scid eq '151512315'"</span></span>
 <span data-ttu-id="5794d-267">All search handles that point to a session that uses a particular template name</span><span class="sxs-lookup"><span data-stu-id="5794d-267">All search handles that point to a session that uses a particular template name</span></span> | <span data-ttu-id="5794d-268">"session/templateName eq 'mytemplate1'"</span><span class="sxs-lookup"><span data-stu-id="5794d-268">"session/templateName eq 'mytemplate1'"</span></span>
 <span data-ttu-id="5794d-269">All search handles that have the tag 'elite' or have a number 'guns' greater than 15 and string 'clan' equal to 'purple'</span><span class="sxs-lookup"><span data-stu-id="5794d-269">All search handles that have the tag 'elite' or have a number 'guns' greater than 15 and string 'clan' equal to 'purple'</span></span> | <span data-ttu-id="5794d-270">"tags/any(a:tolower(a) eq 'elite') or number/guns gt 15 and string/clan eq 'purple'"</span><span class="sxs-lookup"><span data-stu-id="5794d-270">"tags/any(a:tolower(a) eq 'elite') or number/guns gt 15 and string/clan eq 'purple'"</span></span>

### <a name="refreshing-search-results"></a><span data-ttu-id="5794d-271">Refreshing search results</span><span class="sxs-lookup"><span data-stu-id="5794d-271">Refreshing search results</span></span>

 <span data-ttu-id="5794d-272">Your game should avoid automatically refreshing a list of sessions, but instead provide UI that allows a player to manually refresh the list (possibly after refining the search criteria to better filter the results).</span><span class="sxs-lookup"><span data-stu-id="5794d-272">Your game should avoid automatically refreshing a list of sessions, but instead provide UI that allows a player to manually refresh the list (possibly after refining the search criteria to better filter the results).</span></span>

 <span data-ttu-id="5794d-273">If a player attempts to join a session, but that session is full or closed, then your game should refresh the search results as well.</span><span class="sxs-lookup"><span data-stu-id="5794d-273">If a player attempts to join a session, but that session is full or closed, then your game should refresh the search results as well.</span></span>

 <span data-ttu-id="5794d-274">Too many search refreshes can lead to service throttling, so your title should limit the rate at which the query can be refreshed.</span><span class="sxs-lookup"><span data-stu-id="5794d-274">Too many search refreshes can lead to service throttling, so your title should limit the rate at which the query can be refreshed.</span></span>

### <a name="example-query-for-search-handles"></a><span data-ttu-id="5794d-275">Example: query for search handles</span><span class="sxs-lookup"><span data-stu-id="5794d-275">Example: query for search handles</span></span>

 <span data-ttu-id="5794d-276">The following code shows how to query for search handles.</span><span class="sxs-lookup"><span data-stu-id="5794d-276">The following code shows how to query for search handles.</span></span> <span data-ttu-id="5794d-277">API は、クエリに一致するすべての検索ハンドルを表す `multiplayer_search_handle_details` オブジェクトのコレクションを返します。</span><span class="sxs-lookup"><span data-stu-id="5794d-277">The API returns a collection of `multiplayer_search_handle_details` objects that represent all the search handles that match the query.</span></span>

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

## <a name="join-a-session-by-using-a-search-handle"></a><span data-ttu-id="5794d-278">検索ハンドルを使ってセッションに参加する</span><span class="sxs-lookup"><span data-stu-id="5794d-278">Join a session by using a search handle</span></span>

<span data-ttu-id="5794d-279">参加するセッションの検索ハンドルを取得したら、タイトルで `MultiplayerService::WriteSessionByHandleAsync()` または `multiplayer_service::write_session_by_handle()` を使って、自身をセッションに追加します。</span><span class="sxs-lookup"><span data-stu-id="5794d-279">Once you have retrieved a search handle for a session that you want to join, the title should use  `MultiplayerService::WriteSessionByHandleAsync()` or `multiplayer_service::write_session_by_handle()` to add themselves to the session.</span></span>

> [!NOTE]
> <span data-ttu-id="5794d-280">`WriteSessionAsync()` メソッドと `write_session()` メソッドは、セッション参照セッションに参加するためには使用できません。</span><span class="sxs-lookup"><span data-stu-id="5794d-280">The `WriteSessionAsync()` and `write_session()` methods cannot be used to join a session browse session.</span></span>

<span data-ttu-id="5794d-281">次のコードは、検索ハンドルの取得後にセッションに参加する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="5794d-281">The following code demonstrates how to join a session after retrieving a search handle.</span></span>

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
