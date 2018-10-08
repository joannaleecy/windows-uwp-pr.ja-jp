---
title: ランキング
author: aablackm
description: Xbox Live のランキングを使用してプレイヤーを比較する方法について説明します。
ms.assetid: 132604f9-6107-4479-9246-f8f497978db7
ms.author: aablackm
ms.date: 09/28/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0e65002e173922a989c8194266a1ef109d24e7e4
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4421437"
---
# <a name="leaderboards"></a>ランキング

## <a name="introduction"></a>はじめに

「[データ プラットフォームの概要](../data-platform/data-platform.md)」で説明されているように、ランキングは、プレイヤー間の競争を促し、プレイヤー自身やフレンドが持つベスト スコアの更新に関心を持たせる場合に有効な方法です。

[注目の統計](stats2017.md#configured-stats-and-featured-leaderboards)のランキングは常に、タイトルのゲーム ハブに表示され、ホームページにピン留めされているとき、タイトルの UI の一部として表示される場合があります。 タイトル内でランキングを作成するのに、構成済みの注目の統計を使用することもできます。

## <a name="choosing-good-leaderboards"></a>適切なランキングの選択

「[プレイヤーの統計](player-stats.md)」で説明したように、ランキングは定義した統計に対応しています。  プレイヤーが上を目指して努力し、達成できる実績に対応したランキングを選んでください。

たとえば、レーシング ゲームでのベスト ラップ_タイムはプレイヤーはベスト ラップ_タイムと努力するため、適切なランキングです。  他の例は、ガン、や最大コンボ サイズの戦闘ゲームでの/死亡の割合です。

## <a name="when-to-display-leaderboards"></a>ランキングを表示するタイミング

ランキングはいつでもタイトルに表示できます。  ランキングがゲームプレイやタイトルのフローを邪魔しない時間を選択してください。  ラウンドの合間し、後の一致は両方の適切なタイミングです。

## <a name="how-to-display-leaderboards"></a>ランキングを表示する方法

Xbox Live SDK には、ランキングを表示するためのオプションが多数用意されています。  Xbox Live クリエーターズ プログラムで Unity を使用する場合は、ランキング データを表示する、ランキング プレハブを使用して始めることができます。  詳しくは、「[Unity で Xbox Live を構成する](../get-started-with-creators/configure-xbox-live-in-unity.md)」の記事をご覧ください。

Xbox Live SDK で直接コードを記述している場合、使用できる API についての説明をお読みください。

## <a name="programming-guide"></a>プログラミング ガイド

ランキングの現在の状態を取得する際に使用できるランキング API がいくつか用意されています。  すべての API は非同期であり、ブロックしません。  ランキング データの取得要求を行い、通常のゲーム処理を続行します。  ランキング結果がサービスから返されたら、適切なタイミングで結果を表示できます。

プレイヤーがランキングの表示を待ってブロックされないように、サービスから提供されるランキング データは、表示する少し前に要求してください。

## <a name="leaderboards-2013-apis"></a>ランキング 2013 Api

ご覧の`leaderboard_service`名前空間のすべての統計 2013年のランキング API についてします。

<table>

<tr>
<td>C++ API</td><td>説明</td>
</tr>

<tr>
<td markdown="block">

```cpp

pplx::task<xbox_live_result<leaderboard_result>> get_leaderboard(
        const string_t& scid,
        const string_t& name
        );
```

</td>

<td>API の最も基本的なバージョン。  これにより、ランキング上位のプレイヤーから順番に、特定のランキングのランキング値が返されます。</td>

</tr>

<tr>

<td markdown="block">

```csharp
Windows::Foundation::IAsyncOperation< LeaderboardResult^> ^  GetLeaderboardAsync (
        _In_ Platform::String^ serviceConfigurationId,
         _In_ Platform::String^ leaderboardName
        ) 
```

</td>

<td>WinRT の c# コードでは、サービス構成 ID とランキングの名前を指定する 1 つのランキングのランキングを取得します。</td>

</tr>

<tr>
<td markdown="block">

```cpp

pplx::task<xbox_live_result<leaderboard_result>> get_leaderboard(
    _In_ const string_t& scid,
    _In_ const string_t& name,
    _In_ uint32_t skipToRank,
    _In_ uint32_t maxItems = 0
    );

```

</td>

<td>この API にはある程度の柔軟性があり、表示するランク (順位) と返す項目の最大値を指定できます。  たとえば、順位 1000 から始まるランキングを表示する場合に、この API を使用できます。</td>

</tr>

<tr>

<td markdown="block">

```csharp
Windows::Foundation::IAsyncOperation< LeaderboardResult^> ^  GetLeaderboardAsync (
         _In_ Platform::String^ serviceConfigurationId,
         _In_ Platform::String^ leaderboardName,
         _In_ uint32 skipToRank,
         _In_ uint32 maxItems
        ) 
```

</td>

<td>WinRT の c# コードのランキングのページが 1 つのランキングの結果を入手するには、サービス構成 ID とランキング名、"skipToRank"ランクにランキング結果が開始されます。</td>

</tr>

<tr>

<td markdown="block">

```cpp

pplx::task<xbox_live_result<leaderboard_result>> get_leaderboard_skip_to_xuid(
    _In_ const string_t& scid,
    _In_ const string_t& name,
    _In_ const string_t& skipToXuid = string_t(),
    _In_ uint32_t maxItems = 0
    );

```

</td>

<td>

特定のユーザーまでランキングをスキップする場合に使用します。  `XUID` は、各 Xbox ユーザーの一意識別子です。  サインインしたユーザーや、そのユーザーのフレンドの XUID を取得して、この関数に渡すことができます。

</td>

</tr>

<tr>

<td markdown="block">

```csharp
Windows::Foundation::IAsyncOperation< LeaderboardResult^> ^  GetLeaderboardWithSkipToUserAsync (
         _In_ Platform::String^ serviceConfigurationId,
         _In_ Platform::String^ leaderboardName,
         _In_opt_ Platform::String^ skipToXboxUserId,
         _In_ uint32 maxItems
        )
```

</td>

<td>WinRT の c# コードのプレイヤーのランクに関係なく、指定されたプレイヤーから始まるランキングを取得するスコア、またはプレイヤーの位ランク順</td>

</tr>

</table>

## <a name="2013-c-example"></a>2013 の C++ の例

C++ API レイヤーを使用する場合は、サービスからランキング結果が返されたに呼び出されるコールバックを設定できます。  以下にこの例を示します。

これらの API から返される `pplx::task` について簡単に説明すると、これは Microsoft 並列プログラミング ライブラリ (PPL) からの非同期タスク オブジェクトです。  詳しくは、[https://github.com/Microsoft/cpprestsdk/wiki/Programming-with-Tasks](https://github.com/Microsoft/cpprestsdk/wiki/Programming-with-Tasks) を参照してください。

以下のセクションでは、ランキング結果を取得して使用する方法について説明します。

### <a name="1-create-an-async-task-to-retrieve-leaderboard-results"></a>1. 非同期タスクを作成してランキング結果を取得する

最初の手順として、ランキング サービスを呼び出して特定のランキングの結果を取得します。

```cpp
pplx::task<xbox_live_result<leaderboard_result>> asyncTask;
auto& leaderboardService = xboxLiveContext->leaderboard_service();

asyncTask = leaderboardService.get_leaderboard(m_liveResources->GetServiceConfigId(), LeaderboardIdEnemyDefeats);
```

### <a name="2-setup-a-callback"></a>2. コールバックをセットアップする

ランキング結果が返されると呼び出される[継続タスク](https://msdn.microsoft.com/en-us/library/dd492427(v=vs.110).aspx#continuations)をセットアップすることができます。  以下のように行います。

```cpp
asyncTask.then([this](xbox::services::xbox_live_result<xbox::services::leaderboard::leaderboard_result> result)
{
    // Handle result here
});
```

この継続タスクは、最初に呼び出したオブジェクトのコンテキストで呼び出され、タイトルに合った方法で表示可能な ```leaderboard_result``` を受け取ります。


### <a name="3-display-leaderboard"></a>3. ランキングを表示する

ランキング データは ```leaderboard_result``` に含まれており、フィールドは一目見ただけでその内容がわかります。  以下の例をご覧ください。

```cpp
auto leaderboard = result.payload();

for (const xbox::services::leaderboard::leaderboard_row& row : leaderboard.rows())
{
    string_t colValues;
    for (auto columnValue : row.column_values())
    {
        colValues = colValues + L" ";
        colValues = colValues + columnValue;
    }
    m_console->Format(L"%18s %8d %14f %10s\n", row.gamertag().c_str(), row.rank(), row.percentile(), colValues.c_str());
}

```

## <a name="2013-winrt-c-example"></a>2013 WinRT c# の例

WinRT c# レイヤーを使用する場合は、タスクし、使用する必要があるだけでは、それぞれ個別のコールバックを作成する必要はありません、`await`キーワード ランキング サービスを呼び出すとします。

### <a name="1-access-the-leaderboardservice"></a>1.、LeaderboardService へのアクセスします。

`LeaderboardService`から取得できる、`XboxLiveContext`をゲームにユーザーにサインインするときに作成、必要になるのランキング データを呼び出します。

```csharp
XboxLiveContext xboxLiveContext = idManager.xboxLiveContext;
LeaderboardService boardService = xboxLiveContext.LeaderboardService;
```

### <a name="2-call-the-leaderboardservice"></a>2. 呼び出し、LeaderboardService

```csharp
LeaderboardResult boardResult = await boardService.GetLeaderboardAsync(
     xboxLiveConfig.ServiceConfigurationId,
     leaderboardName
     );
```

### <a name="3-retrieve-leaderboard-data"></a>3. ランキング データを取得します。

`GetLeaderboardAsync()` 返します、`LeaderboardResult`これは、名前付きのランキングを作成する統計情報が含まれます。

`LeaderboardResult` いくつかの関数とプロパティをランキング データの読み取りを容易にあります。

|プロパティ  |説明  |
|---------|---------|
|パブリック IAsyncOperation<LeaderboardResult> GetNextAsync (uint maxItems)。     |次の一連の maxItems パラメーターの数までのランクを取得します。 これは、基本的に別の呼び出し `GetLeaderboard()`         |
|パブリック LeaderboardQuery GetNextQuery() です。     |次の一連のデータを取得するランキングの呼び出しに使用できる LeaderboardQuery を取得します。         |
|パブリック bool HasNext {get;}    |ランキング行が取得するかどうかを指定します。         |
|パブリック IReadOnlyList<LeaderboardRow>行 {get;}     | ランクごとのランキング データを含む行        |
|パブリック IReadOnlyList<LeaderboardColumn>列 {get;}     | ランキングを構成する列のリスト        |
|パブリック uint TotalRowCount {get;}     | ランキングの行の合計金額        |
|パブリック文字列 DisplayName {get;}     | ランキングを表示する名前       |

ランキング データが、一度に 1 つのページを提供されます。 ループがあります、`LeaderboardResult`行と列は、データを取得します。  
使用して、`HasNext`ブール値と`GetNextAsync()`ランキング データの以降のページを取得します。

```csharp
if (boardResult != null)
{
    foreach (LeaderboardRow row in boardResult.Rows)
    {
        Debug.Write(string.Format("Rank: {0} | Gamertag: {1} | {2}\n", row.Rank, row.Gamertag, row.Values.ToString()));
    }
}
```

## <a name="leaderboard-2017"></a>ランキング 2017

使用する統計 2017年ランキング サービスへの呼び出しを`StatisticManager`ランキング api の代わりに、`LeaderboardService`ランキング api です。  

`xbox::services::stats:manager::stats_manager::get_leaderboard`  

```cpp
xbox_live_result< void >  get_leaderboard (
     _In_ const xbox_live_user_t &user,
     _In_ const string_t &statName,
     _In_ leaderboard::leaderboard_query query
     ) 
```  

`xbox::services::stats:manager::stats_manager::get_leaderboard`  

```cpp
xbox_live_result< void >  get_social_leaderboard (_In_ const xbox_live_user_t &user,
     _In_ const string_t &statName,
     _In_ const string_t &socialGroup,
     _In_ leaderboard::leaderboard_query query
)
```  

`Microsoft.Xbox.Services.Statistics.Manager.StatisticManager.GetLeaderboard`  

```csharp
public void GetLeaderboard(
    XboxLiveUser user,
    string statName,
    LeaderboardQuery query
    )
```  

`Microsoft.Xbox.Services.Statistics.Manager.StatisticManager.GetSocialLeaderboard`  

```csharp
public void GetSocialLeaderboard(
    XboxLiveUser user,
    string statName,
    string socialGroup,
    LeaderboardQuery query
    )
```  

## <a name="2017-c-example"></a>2017 C++ の例

### <a name="1-get-a-singleton-instance-of-the-statsmanager"></a>1.、stats_manager のシングルトン インスタンスを取得します。

呼び出す前に、`stats_manager`関数はシングルトン インスタンスに変数を設定する必要があります。

```csharp
m_statsManager = stats_manager::get_singleton_instance();
```

### <a name="2-create-a-leaderboardquery"></a>2.、LeaderboardQuery を作成します。

`leaderboard_query`金額、順序を決定し、ランキングの呼び出しから返されるデータのポイントを開始します。

A`leaderboard_query`いくつかの属性を設定できますが返されるデータに影響するには。

|プロパティ |説明  |
|---------|---------|
|m_skipResultToRank     |この uint 変数を返す場合始まるランキング データをランク付け内容が決定します。 ランキングは、ランク 1 から始まります。         |
|m_skipResultToMe     |かどうかに設定をこのブール値を true には、開始時刻から返されるランキング データ、`XboxLiveUser`で使用される、`get_leaderboard()`呼び出します。  |
|m_order     |列挙型の`xbox::services::leaderboard::sort_order`は昇順であり、降順で 2 つの可能な値があります。 クエリのこの変数を設定すると、ランキングの並べ替え順序を決定します。        |
|m_maxItems     |この uint への呼び出しごとに返される行の最大数を決定します`get_leaderboard`または`get_social_leaderboard()`します。         |

`leaderboard_query` いくつかのセット関数を使って、これらのプロパティに値を割り当てるがあります。 次のコードでは説明をセットアップする方法、 `leaderboard_query`

```cpp
leaderboard::leaderboard_query leaderboardQuery;
leaderboardQuery.set_skip_result_to_rank(10);
leaderboardQuery.set_max_items(10);
leaderboardQuery.set_order(sort_order::descending);
```

このクエリ戻ったら、100 から始まるランキングの 10 行がランク付け個々 します。

> [!WARNING]
> SkipResultToRank ランキング内に含まれるプレイヤー数よりも高いが発生する 0 行が返されますランキング データ。

### <a name="3-call-getleaderboard"></a>3. get_leaderboard を呼び出す

```cpp
leaderboard::leaderboard_query leaderboardQuery;
m_statsManager->get_leaderboard(user, statName, leaderboardQuery);
```

> [!IMPORTANT]
> `statName`で使用される、`GetLeaderboard()`呼び出しは小文字が区別されます、 [Windows デベロッパー センター ダッシュ ボード](https://developer.microsoft.com/en-us/dashboard/windows/overview)でタイトル用に構成された統計の名前と同じである必要があります。

### <a name="4-read-the-leaderboard-data"></a>4. ランキング データを読み取る

呼び出す必要がありますランキング データを読み取るために、`stats_manager::do_work()`の一覧を返す関数`stat_event`値。 ランキング データは含まれている、`stat_event`型の`stat_event_type::get_leaderboard_complete`します。 この種類の一覧でのイベントが発生したとき`stat_event`s に目を通すことがあります、`leaderboard_result`に含まれている、`stat_event`データにアクセスします。

サンプル`do_work()`ハンドラー

```cpp
void Sample::UpdateStatsManager()
{
    // Process events from the stats manager
    // This should be called each frame update

    auto statsEvents = m_statsManager->do_work();
    std::wstring text;

    for (const auto& evt : statsEvents)
    {
        switch (evt.event_type())
        {
            case stat_event_type::local_user_added: 
                text = L"local_user_added"; 
                break;

            case stat_event_type::local_user_removed: 
                text = L"local_user_removed"; 
                break;

            case stat_event_type::stat_update_complete: 
                text = L"stat_update_complete"; 
                break;

            case stat_event_type::get_leaderboard_complete: //leaderboard data is read here
                text = L"get_leaderboard_complete";
                auto getLeaderboardCompleteArgs = std::dynamic_pointer_cast<leaderboard_result_event_args>(evt.event_args());
                ProcessLeaderboards(evt.local_user(), getLeaderboardCompleteArgs->result());
                break;
        }

        stringstream_t source;
        source << _T("StatsManager event: ");
        source << text;
        source << _T(".");
        m_console->WriteLine(source.str().c_str());
    }
}
```

ランキング結果からランキング データを読み取る  

```cpp
void Sample::PrintLeaderboard(const xbox::services::leaderboard::leaderboard_result& leaderboard)
{
    if (leaderboard.rows().size() > 0)
    {
        m_console->Format(L"%16s %6s %12s %12s\n", L"Gamertag", L"Rank", L"Percentile", L"Values");
    }

    for (const xbox::services::leaderboard::leaderboard_row& row : leaderboard.rows())
    {
        string_t colValues;
        for (auto columnValue : row.column_values())
        {
            colValues = colValues + L" ";
            colValues = colValues + columnValue;
        }
        m_console->Format(L"%16s %6d %12f %12s\n", row.gamertag().c_str(), row.rank(), row.percentile(), colValues.c_str());
    }
}
```  

ランキングからさらにページのデータを取得します。  

```cpp
void Sample::ProcessLeaderboards(
    _In_ std::shared_ptr<xbox::services::system::xbox_live_user> user,
    _In_ xbox::services::xbox_live_result<xbox::services::leaderboard::leaderboard_result> result
    )
{
    if (!result.err())
    {
        auto leaderboardResult = result.payload();
        PrintLeaderboard(leaderboardResult);

        // Keep processing if there is more data in the leaderboard
        if (leaderboardResult.has_next())
        {
            if (!leaderboardResult.get_next_query().err())
            {               
                auto lbQuery = leaderboardResult.get_next_query().payload();
                if (lbQuery.social_group().empty())
                {
                    m_statsManager->get_leaderboard(user, lbQuery.stat_name(), lbQuery);
                }
                else
                {
                    m_statsManager->get_social_leaderboard(user, lbQuery.stat_name(), lbQuery.social_group(), lbQuery);
                }
            }
        }
    }
}
```  

## <a name="2017-winrt-c-example"></a>2017 WinRT c# の例

### <a name="1-get-a-singleton-instance-of-the-statisticmanager"></a>1.、StatisticManager のシングルトン インスタンスを取得します。

呼び出す前に、`StatisticManager`関数はシングルトン インスタンスに変数を設定する必要があります。

```csharp
statManager = StatisticManager.SingletonInstance;
```

### <a name="2-create-a-leaderboardquery"></a>2.、LeaderboardQuery を作成します。

`LeaderboardQuery`金額、順序を決定し、ランキングの呼び出しから返されるデータのポイントを開始します。  

```csharp
public sealed class LeaderboardQuery : __ILeaderboardQueryPublicNonVirtuals
    {
        [Overload("CreateInstance1")]
        public LeaderboardQuery();

        public bool HasNext { get; }
        public string SocialGroup { get; }
        public string StatName { get; }
        public SortOrder Order { get; set; }
        public uint MaxItems { get; set; }
        public uint SkipResultToRank { get; set; }
        public bool SkipResultToMe { get; set; }
    }
```

A`LeaderboardQuery`いくつかの属性を設定できますが返されるデータに影響するには。

|プロパティ |説明  |
|---------|---------|
|SkipResultToRank     |この uint 変数を返す場合始まるランキング データをランク付け内容が決定します。 ランキングは、ランク 1 から始まります。         |
|SkipResultToMe     |かどうかに設定をこのブール値を true には、開始時刻から返されるランキング データ、`XboxLiveUser`で使用される、`GetLeaderboard()`呼び出します。  |
|Order     |列挙型の`Microsoft.Xbox.Services.Leaderboard.SortOrder`は昇順であり、降順で 2 つの可能な値があります。 クエリのこの変数を設定すると、ランキングの並べ替え順序を決定します。        |
|MaxItems     |この uint への呼び出しごとに返される行の最大数を決定します`GetLeaderboard()`または`GetSocialLeaderboard()`します。         |

形成、`LeaderboardQuery`は、次のようになります。

```csharp
using Microsoft.Xbox.Services.Leaderboard;

LeaderboardQuery query = new LeaderboardQuery
        {
            SkipResultToRank = 100,
            MaxItems = 5
        };
```

このクエリ戻ったら、5 行、100 から始まるランキングの順位の高い個別します。

> [!WARNING]
> SkipResultToRank ランキング内に含まれるプレイヤー数よりも高いが発生する 0 行が返されますランキング データ。

### <a name="3-call-getleaderboard"></a>3. GetLeaderboard() を呼び出す

これで呼び出すことができます`GetLeaderboard()`で、 `XboxLiveUser`、統計の名前と`LeaderboardQuery`します。

```csharp
statManager.GetLeaderboard(xboxLiveUser, statName, leaderboardQuery);
```

> [!IMPORTANT]
> `statName`で使用される、`GetLeaderboard()`呼び出しは小文字が区別されます、 [Windows デベロッパー センター ダッシュ ボード](https://developer.microsoft.com/en-us/dashboard/windows/overview)でタイトル用に構成された統計の名前と同じである必要があります。

### <a name="4-read-leaderboard-data"></a>4. 読み取りランキング データ

呼び出す必要がありますランキング データを読み取るために、`StatisticManager.DoWork()`の一覧を返す関数`StatisticEvent`値。 ランキング データは含まれている、`StatisticEvent`型の`GetLeaderboardComplete`します。 この種類の一覧でのイベントが発生したとき`StatisticEvent`s に目を通すことがあります、`LeaderboardResult`に含まれている、`StatisticEvent`データにアクセスします。

```csharp
IReadOnlyList<StatisticEvent> statEvents = statManager.DoWork(); //In practice this should be called every update frame

foreach(StatisticEvent statEvent in statEvents)
{
    if(statEvent.EventType == StatisticEventType.GetLeaderboardComplete
        && statEvent.ErrorCode == 0)
    {
        LeaderboardResultEventArgs leaderArgs = (LeaderboardResultEventArgs)statEvent.EventArgs;
        LeaderboardResult leaderboardResult = leaderArgs.Result;
        foreach(LeaderboardRow leaderRow in leaderboardResult.Rows)
        {
            Debug.WriteLine(string.Format("Rank: {0} | Gamertag: {1} | {2}:{3}\n\n", leaderRow.Rank, leaderRow.Gamertag, "test", leaderRow.Values[0]));
        }
    }
}
```

タイトル コードで`StatisticManager.DoWork()`統計情報マネージャーのすべての着信イベントを処理し、ランキング用だけではなくするために使用する必要があります。 

> [!NOTE]
> 取得するために、`LeaderboardResultEventArgs`キャストする必要があります、`StatisticEvent.EventArgs`として、`LeaderboardResultEventArgs`変数です。

### <a name="5-retrieve-more-leaderboard-data"></a>5. より多くのランキング データを取得します。

ランキング データを使用する必要がありますの以降のページを取得するために、`LeaderboardResult.HasNext`プロパティと`LeaderboardResult.GetNextQuery()`を取得する関数、`LeaderboardQuery`データの次のページが表示するされます。

```csharp
while (leaderboardResult.HasNext)
{
    leaderboardQuery = leaderboardResult.GetNextQuery();
    statManager.GetLeaderboard(xboxLiveUser, leaderboardQuery.StatName, leaderboardQuery)
    // StatisticManager.DoWork() is called
    // Leaderboard results are read
}
```