---
title: マルチプレイヤー セッション参照
author: KevinAsgari
description: Xbox Live マルチプレイヤーを使用してマルチプレイヤー セッション参照を実装する方法について説明します。
ms.assetid: b4b3ed67-9e2c-4c14-9b27-083b8bccb3ce
ms.author: kevinasg
ms.date: 10/16/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 227cd378a92fcdfec88e1ae0ccd7173986d37abf
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5555540"
---
# <a name="multiplayer-session-browse"></a>マルチプレイヤー セッション参照

マルチプレイヤー セッション参照とは、2016 年 11 月に導入された新機能です。これを使用すると、指定した条件に合う、開いているマルチプレイヤー ゲーム セッションのリストをタイトルで照会できます。

## <a name="what-is-session-browse"></a>セッション参照とは

セッション参照のシナリオでは、ゲームのプレイヤーは参加可能なゲーム セッションのリストを取得できます。 このリストの各セッション エントリにはゲームに関するいくつかの追加メタデータが含まれています。プレイヤーはその情報を使用して、参加するセッションを選択できます。  また、メタデータに基づいてセッションのリストをフィルター処理することもできます。 プレイヤーは興味のあるゲーム セッションを見つけて、セッションに参加できます。

プレイヤーは、新しいゲーム セッションを作成し、マッチメイキングを行う代わりに、セッション参照を使用して他のプレイヤーを集めることもできます。

セッション参照が従来のマッチメイキング シナリオと異なる点として、マッチメイキングでは通常、プレイヤーは "ゲームの検索" ボタンをクリックすることにより、該当したゲーム セッションに自動的に配置されますが、セッション参照では参加するゲーム セッションをプレイヤーが自分で選択できます。 セッション参照は低速な手動のプロセスであり、客観的に見て常に最適なゲームが選ばれるとは限りませんが、プレイヤーに選択権が与えられるため、ゲームの選択結果は主観的により満足度の高いものになると考えられます。

セッション参照とマッチメイキングの両方のシナリオをゲームに組み込むのが一般的です。 通常、マッチメイキングは一般的にプレイされるゲーム モードに使用され、セッション参照はカスタム ゲームに使用されます。

**例:** John はヒーロー バトル アリーナ スタイルのマルチプレイヤー ゲームに関心がありますが、すべてのプレイヤーがヒーローをランダムに選択するゲームをプレイしたいと思っています。 彼は、オープン ゲーム セッションのリストを取得し、"ランダム ヒーロー" が説明に含まれるゲームを探すか、ゲーム UI で可能であれば、"ランダム ヒーロー" ゲーム モードを選択して、"RandomHero" ゲームを示すタグ付きのセッションだけを取得することができます。

気に入ったゲームが見つかれば、ゲームに参加します。 十分なメンバーがセッションに参加すると、ゲーム セッションのホストはゲームを開始できます。

### <a name="roles"></a>ロール

セッション参照のゲームは、特定のロールのプレイヤーを募集できます。 たとえば、プレイヤーは、5 人以下の突撃クラス、2 人以上のヒーラー ロール、1 人以上のタンク ロールを含むセッションを指定するゲーム セッションを作成できます。

別のプレイヤーがセッションに参加するときは、ロールを事前に選択でき、選択したロールに空きスロットがない場合はセッションへの参加が許可されません。

別の例として、プレイヤーがフレンドの参加のために 2 スロットを予約する場合、ゲームは "フレンド" の役割を指定でき、セッション ホストとフレンドであるプレイヤーだけが "フレンド" の役割に専用の 2 スロットを埋めることができます。

ロールについて詳しくは、「[マルチプレイヤーのロール](multiplayer-roles.md)」をご覧ください。



## <a name="how-does-session-browse-work"></a>セッション参照の動作

セッション参照は、主に検索ハンドルの使用時に動作します。 検索ハンドルは、セッションの参照と、検索属性と呼ばれるセッションに関する追加メタデータを含む、データのパケットです。

タイトルは、セッション参照対応の新しいゲーム セッションを作成するとき、セッションの検索ハンドルを作成します。 検索ハンドルは、タイトルの検索ハンドルを管理するマルチプレイヤー サービス ディレクトリ (MPSD) に格納されます。

タイトルは、セッションのリストを取得する必要があるときは、検索クエリを MPSD に送信できます。MPSD は検索条件に一致する検索ハンドルのリストを返します。 その後、タイトルはセッションのリストを使用して、プレイヤーに参加可能なゲームの一覧を表示できます。

セッションに空きがない場合、またはそれ以外の理由で参加できない場合は、タイトルは MPSD からの検索ハンドルを削除して、セッション参照クエリにセッションが表示されないようにできます。

>[!NOTE]
> 検索ハンドルは、ユーザーに表示するセッションの一覧を表示するために使用します。 可能であれば、バックグラウンドのマッチメイキングには検索ハンドルを使わないでください。代わりに、[SmartMatch](multiplayer-manager/play-multiplayer-with-matchmaking.md) の使用を検討してください。

## <a name="set-up-a-session-for-session-browse"></a>セッション参照用にセッションを設定する

セッションで検索ハンドルを使用するには、セッションで次の機能が true に設定されている必要があります。

* `searchable`
* `userAuthorizationStyle`

>[!NOTE]
> `userAuthorizationStyle` 機能は UWP ゲームでのみ必須となりますが、XDK ゲームを含むすべての Xbox Live ゲームに実装することをお勧めします。これにより、将来の移植性が保証されます。

>[!NOTE]
> `userAuthorizationStyle` 機能を設定すると、既定でセッションの `readRestriction` と `joinRestriction` が `none` ではなく `local` になります。 つまり、ゲーム セッションに参加するには、タイトルで検索ハンドルまたは転送ハンドルを使う必要があります。

これらの機能は、Xbox Live サービスを構成するときにセッション テンプレートで設定できます。

セッション参照の場合、ロビー セッションではなく、実際のゲームプレイに使用されるセッションでのみ検索ハンドルを作成する必要があります。

## <a name="what-does-it-mean-to-be-an-owner-of-a-session"></a>セッションの所有者とは

SmartMatch やフレンドのみのゲームなど、多くのゲーム セッションの種類では所有者は必要ありませんが、セッション参照セッションには所有者を設定できます。 

所有者によって管理されたセッションには、所有者によっていくつかの利点があります。 所有者は、セッションから他のメンバーを削除したり、他のメンバーの所有権の状態を変更できます。

セッションで所有者を使用するには、セッションで次の機能が true に設定されている必要があります。

* `hasOwners`

セッションの所有者が Xbox Live メンバーをブロックすると、そのメンバーはセッションに参加できません。

[マルチプレイヤーのロール](multiplayer-roles.md)を使っている場合、所有者だけがユーザーにロールを割り当てることができるように設定できます。

すべての所有者がセッションから退出した場合、サービスはセッションに対して定義されている `ownershipPolicy.migration` ポリシーに基づいてセッションを処理します。 ポリシーが "oldest" の場合は、セッションに最も長くいるプレイヤーが新しい所有者として設定されます。 ポリシーが "endsession" (指定されていない場合は既定値) の場合は、サービスはセッションを終了し、残っているすべてのプレイヤーをセッションから削除します。


## <a name="search-handles"></a>検索ハンドル

検索ハンドルは、JSON 構造として MSPD に格納されます。 検索ハンドルには、セッションへの参照だけでなく、検索属性と呼ばれる検索のための追加メタデータも含まれます。

セッションが任意の時点で作成できる検索ハンドルは 1 つだけです。

Xbox Live API を使用してセッションの検索ハンドルを作成するには、最初に `multiplayer::multiplayer_search_handle_request` オブジェクトを作成した後、そのオブジェクトを `multiplayer::multiplayer_service::set_search_handle()` メソッドに渡します。

### <a name="search-attributes"></a>検索属性

検索属性は、次のコンポーネントで構成されます。

`tags` - タグは、ユーザーがゲーム セッションの分類に使用できる、ハッシュタグのような文字列記述子です。 タグは、文字で始まる必要があり、スペースを含むことはできず、100 文字未満にする必要があります。
タグの例: "ProRankOnly"、"norocketlaunchers"、"cityMaps"。

`strings` - 文字列は、テキスト変数であり、文字列名は文字で始まる必要があり、スペースを含むことはできず、100 文字未満にする必要があります。

文字列メタデータの例: "Weapons"="knives+pistols+rifles"、"MapName"="UrbanCityAssault"、"description"="Fun casual game, new people welcome"。

`numbers` - 数値は、数値変数であり、数値名は文字で始まる必要があり、スペースを含むことはできず、100 文字未満にする必要があります。 Xbox Live API は、float 型として数値を取得します。

数値メタデータの例: "MinLevel" = 25、"MaxRank" = 10。

>**注意:** サービスではタグと文字列値の大文字小文字の区別が維持されますが、タグを照会するときは tolower() 関数を使用する必要があります。 つまり、タグと文字列の値は、現在、大文字が含まれる場合でも、すべて小文字として扱われます。

Xbox Live API では、`multiplayer_search_handle_request` オブジェクトの `set_tags()` メソッド、`set_stringsmetadata()` メソッド、および `set_numbers_metadata()` メソッドを使用して検索属性を設定できます。


### <a name="additional-details"></a>追加情報

検索ハンドルを取得した結果には、セッションに関する他の有用なデータも含まれます (セッションが閉じられているかどうか、セッションに何らかの参加制限があるか、など)。

Xbox Live API では、これらの詳細と検索属性は、検索クエリの後で返される `multiplayer_search_handle_details` に含まれます。

### <a name="remove-a-search-handle"></a>検索ハンドルを削除する

セッションに空きがない場合や、セッションが閉じられた場合など、セッション参照からセッションを削除するときは、検索ハンドルを削除できます。

Xbox Live API では、`multiplayer_service::clear_search_handle()` メソッドを使用して検索ハンドルを削除できます。

### <a name="example-create-a-search-handle-with-metadata"></a>例: メタデータで検索ハンドルを作成する

次のコードでは、C++ Xbox Live マルチプレイヤー API を使用してセッションの検索ハンドルを作成する方法を示します。

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


## <a name="create-a-search-query-for-sessions"></a>セッションの検索クエリを作成する

検索ハンドルのリストを取得するときは、検索クエリを使用して、特定の条件に一致するセッションに結果を限定できます。

検索クエリの構文は [OData](http://docs.oasis-open.org/odata/odata/v4.0/errata02/os/complete/part2-url-conventions/odata-v4.0-errata02-os-part2-url-conventions-complete.html#_Toc406398092) スタイルであり、次の演算子だけがサポートされます。

 演算子 | 説明
 --- | ---
 eq | equals (次の値と等しい)
 ne | not equal to (次の値と等しくない)
 gt | greater than (次の値より大きい)
 ge | greater than or equal (次の値以上)
 lt | less than (次の値より小さい)
 le | less than or equal (次の値以下)
 and | 論理 AND
 or | 論理 OR (下の「注」を参照)

また、ラムダ式と `tolower` 正規関数も使用できます。 現在、他の OData 関数はサポートされていません。

タグまたは文字列値を検索するときは、検索クエリで "tolower" 関数を使用する必要があります。現在、サービスは小文字の文字列の検索のみをサポートします。

Xbox Live サービスは、検索クエリに一致する最初の 100 個の結果のみを返します。 ゲームでは、結果が多すぎる場合にプレイヤーが検索クエリを絞り込むことができるようにする必要があります。

>[!NOTE]
>  フィルター文字列のクエリでは論理 OR がサポートされますが、使用できる OR は 1 つだけで、クエリのルートに指定する必要があります。 クエリに複数の OR を含めることはできません。また、OR がクエリ構造の最上位でない位置に出現するクエリを作成することもできません。

### <a name="search-handle-query-examples"></a>検索ハンドルのクエリの例

RESTful 呼び出しの "Filter" では、すべての検索ハンドルに対するクエリで使用する OData Filter 言語文字列を指定します。  
Multiplayer 2015 API では、`multiplayer_service.get_search_handles()` メソッドの *searchFilter* パラメーターにフィルター文字列を指定できます。  

現在サポートされているフィルター シナリオは次のとおりです。

 フィルター | フィルターを適用した検索文字列
 --- | ---
 xuid が '1234566' である 1 人のメンバー | "session/memberXuids/any(d:d eq '1234566')"
 xuid が '1234566' である 1 人の所有者 | "session/ownerXuids/any(d:d eq '1234566')"
 文字列 'forzacarclass' が 'classb' に等しい | "tolower(strings/forzacarclass) eq 'classb'"
 数値 'forzaskill' が 6 に等しい | "numbers/forzaskill eq 6"
 数値 'halokdratio' が 1.5 より大きい | "numbers/halokdratio gt 1.5"
 タグ 'coolpeopleonly' である | "tags/any(d:tolower(d) eq 'coolpeopleonly')"
 タグ 'cursingallowed' を含まないセッション | "tags/any(d:tolower(d) ne 'cursingallowed')"
 数値が 0 に等しい 'rank' を含まないセッション | "numbers/rank ne 0"
 文字列が 'classa' に等しい 'forzacarclass' を含まないセッション | "tolower(strings/forzacarclass) ne 'classa'"
 タグが 'coolpeopleonly' であり、数値 'halokdratio' が 7.5 に等しい | "tags/any(d:tolower(d) eq 'coolpeopleonly') eq true and numbers/halokdratio eq 7.5"
 数値 'halodkratio' が 1.5 以上であり、数値 'rank' が 60 より小さく、数値 'customnumbervalue' が 5 以下である | "numbers/halokdratio ge 1.5 and numbers/rank lt 60 and numbers/customnumbervalue le 5"
 実績 ID が '123456' | "achievementIds/any(d:d eq '123456')"
 言語コード 'en' | "language eq 'en'"
 指定された時刻以下のスケジュールされた時刻をすべて返す | "session/scheduledTime le '2009-06-15T13:45:30.0900000Z'"
 指定された時刻より小さい投稿時刻をすべて返す | "session/postedTime lt '2009-06-15T13:45:30.0900000Z'"
 セッション登録状態 | "session/registrationState eq 'registered'"
 セッション メンバーの数が 5 に等しい | "session/membersCount eq 5"
 セッション メンバーの目標数が 1 より大きい | "session/targetMembersCount gt 1"
 セッション メンバーの最大数が 3 より小さい | "session/maxMembersCount lt 3"
 セッション メンバーの目標数とセッション メンバー数の差異が 5 以下 | "session/targetMembersCountRemaining le 5"
 セッション メンバーの最大数とセッション メンバー数の差異が 2 より大きい | "session/maxMembersCountRemaining gt 2"
 セッション メンバーの目標数とセッション メンバー数の差異が 15 以下。</br> ロールに目標数が指定されていない場合、このクエリでは、セッション メンバーの最大数とセッション メンバー数の差異を使用してフィルター処理が行われます。 | "session/needs le 15"
 ロールの種類 "lfg" のロール "confirmed" で、このロールのメンバー数が 5 に等しい | "session/roles/lfg/confirmed/count eq 5"
 ロールの種類 "lfg" のロール "confirmed" で、このロールの目標数が 1 より大きい。</br> ロールに目標数が指定されていない場合、ロールの最大数が代わりに使用されます。 | "session/roles/lfg/confirmed/target gt 1"
 ロールの種類 "lfg" のロール "confirmed" で、ロールの目標数とロールのメンバー数の差異が 15 以下。</br> ロールに目標数が指定されていない場合、このクエリでは、ロールの最大数とロールのメンバー数の差異を使用してフィルター処理が行われます。 | "session/roles/lfg/confirmed/needs le 15"
 特定のキーワードを含むセッションを指すすべての検索ハンドル | "session/keywords/any(d:tolower(d) eq 'level2')"
 特定の scid に属するセッションを指すすべての検索ハンドル | "session/scid eq '151512315'"
 特定のテンプレート名が使用されているセッションを指すすべての検索ハンドル | "session/templateName eq 'mytemplate1'"
 'elite' というタグを持っているか、'guns' の数が 15 より大きく、文字列 'clan' が 'purple' に等しいすべての検索ハンドル | "tags/any(a:tolower(a) eq 'elite') or number/guns gt 15 and string/clan eq 'purple'"

### <a name="refreshing-search-results"></a>検索結果を更新する

 ゲームでは、セッションの一覧を自動的に更新せず、代わりにプレイヤーが一覧を手動で更新できる UI を提供する必要があります (たとえば、より望ましいフィルター結果が得られるように検索条件を調整した後)。

 プレイヤーがセッションに参加しようとしてもセッションに空きがないか閉じている場合も、ゲームは検索結果を更新する必要があります。

 検索の更新が多すぎるとサービスのスロットリングにつながるため、タイトルではクエリの更新頻度を制限する必要があります。

### <a name="example-query-for-search-handles"></a>例: 検索ハンドルの照会

 次のコードでは、検索ハンドルを照会する方法を示します。 API は、クエリに一致するすべての検索ハンドルを表す `multiplayer_search_handle_details` オブジェクトのコレクションを返します。

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
