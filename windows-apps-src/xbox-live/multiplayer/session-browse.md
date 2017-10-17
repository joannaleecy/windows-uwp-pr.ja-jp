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
# <a name="multiplayer-session-browse"></a>Multiplayer session browse

Multiplayer session browse is a new feature introduced in November 2016 that enables a title to query for a list of open multiplayer game sessions that meet the specified criteria.

## <a name="what-is-session-browse"></a>What is session browse?

In a session browse scenario, a player in a game is able to retrieve a list of joinable game sessions. Each session entry in this list contains some additional metadata about the game, which a player can use to help them select which session to join.  They can also filter the list of sessions based on the metadata. Once the player sees a game session that appeals to them, they can join the session.

A player can also create a new game session, and use session browse to recruit additional players instead of relying on matchmaking.

セッション参照が従来のマッチメイキング シナリオと異なる点として、マッチメイキングでは通常、プレイヤーは "ゲームの検索" ボタンをクリックすることにより、該当したゲーム セッションに自動的に配置されますが、セッション参照では参加するゲーム セッションをプレイヤーが自分で選択できます。 セッション参照は低速な手動のプロセスであり、客観的に見て常に最適なゲームが選ばれるとは限りませんが、プレイヤーに選択権が与えられるため、ゲームの選択結果は主観的により満足度の高いものになると考えられます。

セッション参照とマッチメイキングの両方のシナリオをゲームに組み込むのが一般的です。 Typically matchmaking is used for commonly played game modes, while session browse is used for custom games.

**Example:** John may be interested in playing a hero battle arena style multiplayer game, but wants to play a game where all players select their hero randomly. He can retrieve a list of open game sessions and find the ones that include "random heroes" in their description, or if the game UI allows it, he can select the "random hero" game mode and retrieve only the sessions that are tagged to indicate that they are "RandomHero" games.

When he finds a game that he likes, he joins the game. When enough people have joined the session, the host of the game session can start the game.

### <a name="roles"></a>Roles

A game in session browse may want to recruit players for specific roles. For example, a player may want to create a game session that specifies that the session contains no more than 5 assault classes, but must contain at least 2 healer roles, and at least 1 tank role.

When another player applies for the session, they can pre-select their role, and the service will not allow them to join the session if there are no open slots for the role they have selected.

Another example would be if a player wants to reserve 2 slots for their friends to join, the game can specify a "friends" role, and only players that are friends with the session host can fill the 2 slots dedicated to the "friends" role.

For more information about roles, see [multiplayer roles](multiplayer-roles.md).



## <a name="how-does-session-browse-work"></a>How does session browse work?

Session browse works primarily on the use of search handles. A search handle is a packet of data that contains a reference to the session, as well as additional metadata about the session, namely search attributes.

When a title creates a new game session that is eligible for session browse, it creates a search handle for the session. The search handle is stored in the Multiplayer Service Directory (MPSD), which maintains the search handles for the title.

When a title needs to retrieve a list of sessions, the title can send a search query to MPSD, which will return a list of search handles that meet the search criteria. The title can then use the list of sessions to display a list of joinable games to the player.

When a session is full, or otherwise cannot be joined, a title can remove the search handle from MPSD so that the session will no longer show up in session browse queries.


## <a name="set-up-a-session-for-session-browse"></a>Set up a session for session browse

セッションで検索ハンドルを使用するには、セッションで次の機能が true に設定されている必要があります。

* `searchable`
* `userAuthorizationStyle`
* `hasOwners`

>[!NOTE]
> `userAuthorizationStyle` 機能と `hasOwners` 機能は UWP ゲームでのみ必須となりますが、XDK ゲームを含むすべての Xbox Live ゲームに実装することをお勧めします。これにより、将来の移植性が保証されます。

>[!NOTE]
> `userAuthorizationStyle` 機能を設定すると、既定でセッションの `readRestriction` と `joinRestriction` が `none` ではなく `local` になります。 つまり、ゲーム セッションに参加するには、タイトルで検索ハンドルまたは転送ハンドルを使う必要があります。

さらに、検索可能なセッションには所有者が必要であるため、`owernshipPolicy.migration` が "oldest" または "endsession" に設定されている必要があります。

You can set these capabilities in the session template when you configure your Xbox Live services.

For session browse, you should only create search handles on sessions that will be used for actual gameplay, not for lobby sessions.

## <a name="what-does-it-mean-to-be-an-owner-of-a-session"></a>What does it mean to be an owner of a session?

While many game session types, such as SmartMatch or a friends only game, do not require an owner, every session browse session must have at least one owner. Only a member that is marked as an owner of a session can create a search handle for that session.

In addition, only owners can remove other members from the session, or change the ownership status of other members.

If an owner of a session has an Xbox Live member blocked, that member cannot join the session.

If all owners leave a session, then the service takes action on the session based the `ownershipPolicy.migration` policy that is defined for the session. If the policy is "oldest", then the player that has been in the session the longest is set to be the new owner. If the policy is "endsession", then the service ends the session and removes all remaining players from the session.


## <a name="search-handles"></a>Search handles

A search handle is stored in MSPD as a JSON structure. In addition to containing a reference to the session, search handles also contain additional metadata for searches, known as search attributes.

A session can only have one search handle created for it at any time.

To create a search handle for a session in by using the Xbox Live APIs, you first create a `multiplayer::multiplayer_search_handle_request` object, and then pass that object to the `multiplayer::multiplayer_service::set_search_handle()` method.

### <a name="search-attributes"></a>Search attributes

Search attributes consists of the following components:

`tags` - Tags are string descriptors that people can use to categorize a game session, similar to a hashtag. Tags must start with a letter, cannot contain spaces, and must be less than 100 characters.
Example tags: "ProRankOnly", "norocketlaunchers", "cityMaps".

`strings` - Strings are text variables, and the string names must start with a letter, cannot contain spaces, and must be less than 100 characters.

Example string metadata: "Weapons"="knives+pistols+rifles", "MapName"="UrbanCityAssault", "description"="Fun casual game, new people welcome."

`numbers` - Numbers are numeric variables, and the number names must start with a letter, cannot contain spaces, and must be less than 100 characters. The Xbox Live APIs retrieve number values as type float.

Example number metadata: "MinLevel" = 25, "MaxRank" = 10.

>**Note:** The letter casing of tags and string values is preserved in the service, but you must use the tolower() function when you query for tags. This means that tags and string values are currently all treated as lower case, even if they contain upper case characters.

In the Xbox Live APIs, you can set the search attributes by using the `set_tags()`, `set_stringsmetadata()`, and `set_numbers_metadata()` methods of a `multiplayer_search_handle_request` object.


### <a name="additional-details"></a>Additional details

When you retrieve a search handle, the results also include additional useful data about the session, such as if the session is closed, are there any join restrictions on the session, etc.

In the Xbox Live APIs, these details, along with the search attributes, are included in the `multiplayer_search_handle_details` that are returned after a search query.

### <a name="remove-a-search-handle"></a>Remove a search handle

When you want to remove a session from session browse, such as when the session is full, or if the session is closed, you can delete the search handle.

In the Xbox Live APIs, you can use the `multiplayer_service::clear_search_handle()` method to remove a search handle.

### <a name="example-create-a-search-handle-with-metadata"></a>Example: Create a search handle with metadata

The following code shows how to create a search handle for a session by using the C++ Xbox Live multiplayer APIs.

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


## <a name="create-a-search-query-for-sessions"></a>Create a search query for sessions

When retrieving a list of search handles, you can use a search query to restrict the results to the sessions that meet specific criteria.

The search query syntax is an  [OData](http://docs.oasis-open.org/odata/odata/v4.0/errata02/os/complete/part2-url-conventions/odata-v4.0-errata02-os-part2-url-conventions-complete.html#_Toc406398092) style syntax, with only the following operators supported:

 Operator | Description
 --- | ---
 eq | equals (次の値と等しい)
 ne | not equal to (次の値と等しくない)
 gt | greater than
 ge | greater than or equal
 lt | less than
 le | less than or equal
 and | 論理 AND
 or | 論理 OR (下の「注」を参照)

また、ラムダ式と `tolower` 正規関数も使用できます。 No other OData functions are supported currently.

When searching for tags or string values, you must use the 'tolower' function in the search query, as the service only currently supports searching for lower-case strings.

The Xbox Live service only returns the first 100 results that match the search query. ゲームでは、結果が多すぎる場合にプレイヤーが検索クエリを絞り込むことができるようにする必要があります。

>[!NOTE]
>  フィルター文字列のクエリでは論理 OR がサポートされますが、使用できる OR は 1 つだけで、クエリのルートに指定する必要があります。 クエリに複数の OR を含めることはできません。また、OR がクエリ構造の最上位でない位置に出現するクエリを作成することもできません。

### <a name="search-handle-query-examples"></a>検索ハンドルのクエリの例

In a restful call, "Filter" is where you would specify an OData Filter language string that will be run in your query against all search handles.  
In the multiplayer 2015 APIs, you can specify the search filter string in the *searchFilter* parameter of the `multiplayer_service.get_search_handles()` method.  

Currently, the following filter scenarios are supported:

 Filter by | Search filter string
 --- | ---
 A single member xuid '1234566’ | "session/memberXuids/any(d:d eq '1234566')"
 A single owner xuid '1234566’ | "session/ownerXuids/any(d:d eq '1234566')"
 A string 'forzacarclass' equal to 'classb‘ | "tolower(strings/forzacarclass) eq 'classb'"
 A number 'forzaskill' equal to 6 | "numbers/forzaskill eq 6"
 A number 'halokdratio' greater than 1.5 | "numbers/halokdratio gt 1.5"
 A tag 'coolpeopleonly' | "tags/any(d:tolower(d) eq 'coolpeopleonly')"
 タグ 'cursingallowed' を含まないセッション | "tags/any(d:tolower(d) ne 'cursingallowed')"
 数値が 0 に等しい 'rank' を含まないセッション | "numbers/rank ne 0"
 文字列が 'classa' に等しい 'forzacarclass' を含まないセッション | "tolower(strings/forzacarclass) ne 'classa'"
 タグが 'coolpeopleonly' であり、数値 'halokdratio' が 7.5 に等しい | "tags/any(d:tolower(d) eq 'coolpeopleonly') eq true and numbers/halokdratio eq 7.5"
 A number 'halodkratio' greater than or equal to 1.5, a number 'rank' less than 60, and a number 'customnumbervalue' less than or equal to 5 | "numbers/halokdratio ge 1.5 and numbers/rank lt 60 and numbers/customnumbervalue le 5"
 An achievement id '123456' | "achievementIds/any(d:d eq '123456')"
 The language code 'en' | "language eq 'en'"
 Scheduled time, returns all scheduled times less than or equal to the specified time | "session/scheduledTime le '2009-06-15T13:45:30.0900000Z'"
 Posted time, returns all posted times less than the specified time | "session/postedTime lt '2009-06-15T13:45:30.0900000Z'"
 Session registration state | "session/registrationState eq 'registered'"
 Where the number of session members is equal to 5 | "session/membersCount eq 5"
 Where the session member target count is greater than 1 | "session/targetMembersCount gt 1"
 Where the max count of session members is less than 3 | "session/maxMembersCount lt 3"
 Where the difference between the session member target count and the number of session members is less than or equal to 5 | "session/targetMembersCountRemaining le 5"
 Where the difference between the max count of session members and the number of session members is greater than 2 | "session/maxMembersCountRemaining gt 2"
 Where the difference between the session member target count and the number of session members is less than or equal to 15.</br> If the role does not have a target specified, then this query filters against the difference between the max count of session members and the number of session members. | "session/needs le 15"
 Role "confirmed" of the role type "lfg" where the number of members with that role is equal to 5 | "session/roles/lfg/confirmed/count eq 5"
 Role "confirmed" of the role type "lfg" where the target of that role is greater than 1.</br> If the role does not have a target specified, then the max of the role is used instead. | "session/roles/lfg/confirmed/target gt 1"
 Role "confirmed" of the role type "lfg" where the difference between the target of the role and the number of members with that role is less than or equal to 15.</br> If the role does not have a target specified, then this query filters against the difference between the max of the role and the number of members with that role. | "session/roles/lfg/confirmed/needs le 15"
 All search handles that point to a session containing a particular keyword | "session/keywords/any(d:tolower(d) eq 'level2')"
 All search handles that point to a session belonging to a particular scid | "session/scid eq '151512315'"
 All search handles that point to a session that uses a particular template name | "session/templateName eq 'mytemplate1'"
 All search handles that have the tag 'elite' or have a number 'guns' greater than 15 and string 'clan' equal to 'purple' | "tags/any(a:tolower(a) eq 'elite') or number/guns gt 15 and string/clan eq 'purple'"

### <a name="refreshing-search-results"></a>Refreshing search results

 Your game should avoid automatically refreshing a list of sessions, but instead provide UI that allows a player to manually refresh the list (possibly after refining the search criteria to better filter the results).

 If a player attempts to join a session, but that session is full or closed, then your game should refresh the search results as well.

 Too many search refreshes can lead to service throttling, so your title should limit the rate at which the query can be refreshed.

### <a name="example-query-for-search-handles"></a>Example: query for search handles

 The following code shows how to query for search handles. API は、クエリに一致するすべての検索ハンドルを表す `multiplayer_search_handle_details` オブジェクトのコレクションを返します。

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

## <a name="join-a-session-by-using-a-search-handle"></a>検索ハンドルを使ってセッションに参加する

参加するセッションの検索ハンドルを取得したら、タイトルで `MultiplayerService::WriteSessionByHandleAsync()` または `multiplayer_service::write_session_by_handle()` を使って、自身をセッションに追加します。

> [!NOTE]
> `WriteSessionAsync()` メソッドと `write_session()` メソッドは、セッション参照セッションに参加するためには使用できません。

次のコードは、検索ハンドルの取得後にセッションに参加する方法を示します。

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
