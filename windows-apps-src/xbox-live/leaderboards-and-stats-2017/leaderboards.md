---
title: スコアボード
description: Xbox Live のランキングを使用してプレイヤーを比較する方法について説明します。
ms.assetid: 132604f9-6107-4479-9246-f8f497978db7
ms.date: 09/28/2018
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8fd7e30b99418fda614a888d9269548cdc57a88a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57662027"
---
# <a name="leaderboards"></a>スコアボード

## <a name="introduction"></a>概要

「[データ プラットフォームの概要](../data-platform/data-platform.md)」で説明されているように、ランキングは、プレイヤー間の競争を促し、プレイヤー自身やフレンドが持つベスト スコアの更新に関心を持たせる場合に有効な方法です。

ランキング[機能を備えた Stats](stats2017.md#configured-stats-and-featured-leaderboards)はタイトルのゲームのハブで常に表示されのホームページにピン設定されているときにタイトル用の UI の一部として表示される場合があります。 タイトルの内部でランキングを作成するのに、構成済みの機能を備えた統計を使用することもできます。

## <a name="choosing-good-leaderboards"></a>適切なランキングの選択

「[プレイヤーの統計](player-stats.md)」で説明したように、ランキングは定義した統計に対応しています。  プレイヤーが上を目指して努力し、達成できる実績に対応したランキングを選んでください。

たとえば、レーシング ゲームのベストの膝時間では、プレーヤーは作業の最適な膝の時間を改善するために、適切なランキングがれます。  その他の例は、Kill 生と死の比は、戦闘ゲームでは連発銃、またはコンボの最大サイズです。

## <a name="when-to-display-leaderboards"></a>ランキングを表示するタイミング

ランキングはいつでもタイトルに表示できます。  ランキングがゲームプレイやタイトルのフローを邪魔しない時間を選択してください。  ラウンド間との一致が両方の良い時間後にします。

## <a name="how-to-display-leaderboards"></a>ランキングを表示する方法

Xbox Live SDK には、ランキングを表示するためのオプションが多数用意されています。  Xbox Live クリエーターズ プログラムで Unity を使用する場合は、ランキング データを表示、ランキング プレハブを使用して開始できます。  詳しくは、「[Unity で Xbox Live を構成する](../get-started-with-creators/configure-xbox-live-in-unity.md)」の記事をご覧ください。

Xbox Live SDK で直接コードを記述している場合、使用できる API についての説明をお読みください。

## <a name="programming-guide"></a>プログラミング ガイド

ランキングの現在の状態を取得する際に使用できるランキング API がいくつか用意されています。  すべての API は非同期であり、ブロックしません。  ランキング データの取得要求を行い、通常のゲーム処理を続行します。  ランキング結果がサービスから返されたら、適切なタイミングで結果を表示できます。

プレイヤーがランキングの表示を待ってブロックされないように、サービスから提供されるランキング データは、表示する少し前に要求してください。

## <a name="leaderboards-2013-apis"></a>ランキング 2013 Api

確認できます、 `leaderboard_service` Stats 2013 ランキングのすべての API の名前空間。

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

<td>WinRTC#コード - サービス構成の ID とランキングの名前を指定して 1 つのランキングのランキングを取得します。</td>

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

<td>WinRTC#コード - 1 つのランキング、サービス構成の ID とランキング名、スコアボードの結果が"skipToRank"ランクの開始のスコアボードの結果のページが表示されます。</td>

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

<td>WinRTC#コード - プレーヤーのランクや、プレイヤーのパーセン タイル順位で順序付けのスコアに関係なく、指定したプレーヤーから始まるランキングの取得</td>

</tr>

</table>

## <a name="2013-c-example"></a>2013 の C++ の例

C++ API レイヤーを使用する場合は、スコアボードの結果は、サービスから返された後に呼び出されるコールバックを設定できます。  以下にこの例を示します。

これらの API から返される `pplx::task` について簡単に説明すると、これは Microsoft 並列プログラミング ライブラリ (PPL) からの非同期タスク オブジェクトです。  詳しくは、[https://github.com/Microsoft/cpprestsdk/wiki/Programming-with-Tasks](https://github.com/Microsoft/cpprestsdk/wiki/Programming-with-Tasks) を参照してください。

以下のセクションでは、ランキング結果を取得して使用する方法について説明します。

### <a name="1-create-an-async-task-to-retrieve-leaderboard-results"></a>1. スコアボードの結果を取得する非同期タスクを作成します。

最初の手順として、ランキング サービスを呼び出して特定のランキングの結果を取得します。

```cpp
pplx::task<xbox_live_result<leaderboard_result>> asyncTask;
auto& leaderboardService = xboxLiveContext->leaderboard_service();

asyncTask = leaderboardService.get_leaderboard(m_liveResources->GetServiceConfigId(), LeaderboardIdEnemyDefeats);
```

### <a name="2-setup-a-callback"></a>2. コールバックを設定します。

設定することができます、[継続タスク](https://msdn.microsoft.com/en-us/library/dd492427(v=vs.110).aspx#continuations)スコアボードの結果が返された後に呼び出されます。  以下のように行います。

```cpp
asyncTask.then([this](xbox::services::xbox_live_result<xbox::services::leaderboard::leaderboard_result> result)
{
    // Handle result here
});
```

この継続タスクは、最初に呼び出したオブジェクトのコンテキストで呼び出され、タイトルに合った方法で表示可能な ```leaderboard_result``` を受け取ります。


### <a name="3-display-leaderboard"></a>3.ランキングを表示します。

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

## <a name="2013-winrt-c-example"></a>2013 WinRTC#例

WinRT を使用する場合C#レイヤーのタスクし、は単に使用する必要が別個のコールバックを作成する必要はありません、`await`ランキング サービスを呼び出すときに、キーワード。

### <a name="1-access-the-leaderboardservice"></a>1. アクセス、LeaderboardService

`LeaderboardService`から取得できる、`XboxLiveContext`ゲームにユーザーをサインインするときに作成された、必要になるランキング データを呼び出すためです。

```csharp
XboxLiveContext xboxLiveContext = idManager.xboxLiveContext;
LeaderboardService boardService = xboxLiveContext.LeaderboardService;
```

### <a name="2-call-the-leaderboardservice"></a>2. LeaderboardService を呼び出す

```csharp
LeaderboardResult boardResult = await boardService.GetLeaderboardAsync(
     xboxLiveConfig.ServiceConfigurationId,
     leaderboardName
     );
```

### <a name="3-retrieve-leaderboard-data"></a>3.ランキング データを取得します。

`GetLeaderboardAsync()` 返します、`LeaderboardResult`これは名前付きのランキングを作成する統計情報が含まれます。

`LeaderboardResult` いくつかの関数とランキング データの読み取りを容易にプロパティがあります。

|プロパティ  |説明  |
|---------|---------|
|public IAsyncOperation<LeaderboardResult> GetNextAsync(uint maxItems);     |次の一連の maxItems パラメーターの数までのランクを取得します。 これは、本質的に別の呼び出し `GetLeaderboard()`         |
|public LeaderboardQuery GetNextQuery();     |次のデータ セットを取得するランキングの呼び出しに使用できる LeaderboardQuery を取得します。         |
|public bool HasNext { get; }    |ランキング行が取得するかどうかを指定します。         |
|public IReadOnlyList<LeaderboardRow> Rows { get; }     | ランクあたりランキング データを含む行        |
|public IReadOnlyList<LeaderboardColumn> Columns { get; }     | スコアボードを構成する列の一覧        |
|public uint TotalRowCount { get; }     | ランキング内の行の合計金額        |
|public string DisplayName { get; }     | ランキングに表示される名前       |

ランキング データを一度に 1 ページを提供されます。 ループすることがあります、`LeaderboardResult`行と列データを取得します。  
使用して、`HasNext`ブールと`GetNextAsync()`ランキング データの以降のページを取得します。

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

使用する統計 2017年ランキング サービスを呼び出すことに、`StatisticManager`ランキング api の代わりに、`LeaderboardService`ランキング api。  

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

## <a name="2017-c-example"></a>2017 の C++ の例

### <a name="1-get-a-singleton-instance-of-the-statsmanager"></a>1. Stats_manager のシングルトン インスタンスを取得します。

呼び出すには、`stats_manager`関数、変数のシングルトン インスタンスに設定する必要があります。

```csharp
m_statsManager = stats_manager::get_singleton_instance();
```

### <a name="2-create-a-leaderboardquery"></a>2. 作成、LeaderboardQuery

`leaderboard_query`金額、順を決定し、ランキング呼び出しから返されるデータの出発点です。

A`leaderboard_query`がいくつかの属性に設定できる返されるデータに影響を及ぼすあります。

|プロパティ |説明  |
|---------|---------|
|m_skipResultToRank     |この uint 変数を返すときにで開始されますランキング データを順位付け何かが決まります。 順位付けは、ランク 1 から始まります。         |
|m_skipResultToMe     |かどうか設定をこのブール値を true には、開始に返されるランキング データ、`XboxLiveUser`で使用される、`get_leaderboard()`呼び出します。  |
|m_order     |型の列挙型`xbox::services::leaderboard::sort_order`、昇順と降順の 2 つの可能な値を指定します。 クエリには、この変数を設定すると、スコアボードの並べ替え順序を決定します。        |
|m_maxItems     |この uint への呼び出しごとに返される行の最大数を決定する`get_leaderboard`または`get_social_leaderboard()`します。         |

`leaderboard_query` いくつかのセット関数を使って、これらのプロパティに値を代入しています 次のコードでは説明を設定する方法、 `leaderboard_query`

```cpp
leaderboard::leaderboard_query leaderboardQuery;
leaderboardQuery.set_skip_result_to_rank(10);
leaderboardQuery.set_max_items(10);
leaderboardQuery.set_order(sort_order::descending);
```

このクエリは返しません 10 行、100 から始まる、スコアボードのランク付けされた個人です。

> [!WARNING]
> SkipResultToRank プレーヤー、ランキング内に含まれる数よりも大きく設定をする 0 行が返されますランキング データとなります。

### <a name="3-call-getleaderboard"></a>3.Get_leaderboard を呼び出す

```cpp
leaderboard::leaderboard_query leaderboardQuery;
m_statsManager->get_leaderboard(user, statName, leaderboardQuery);
```

> [!IMPORTANT]
> `statName`で使用される、`GetLeaderboard()`呼び出しは、タイトル用に構成された状態の名前と同じである必要があります[パートナー センター](https://partner.microsoft.com/dashboard)、これは大文字小文字を区別します。

### <a name="4-read-the-leaderboard-data"></a>4。ランキング データを読み取る

呼び出す必要がありますランキング データを読み取るために、`stats_manager::do_work()`関数の一覧が返されます`stat_event`値。 ランキング データが含まれる、`stat_event`型の`stat_event_type::get_leaderboard_complete`します。 この型の一覧でのイベントが発生したときに`stat_event`s に目を通すことがあります、`leaderboard_result`に含まれている、`stat_event`データにアクセスします。

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

スコアボードの結果からランキング データを読み取る  

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

スコア_ボードからさらにデータのページを取得します。  

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

## <a name="2017-winrt-c-example"></a>2017 WinRTC#例

### <a name="1-get-a-singleton-instance-of-the-statisticmanager"></a>1. StatisticManager のシングルトン インスタンスを取得します。

呼び出すには、`StatisticManager`関数、変数のシングルトン インスタンスに設定する必要があります。

```csharp
statManager = StatisticManager.SingletonInstance;
```

### <a name="2-create-a-leaderboardquery"></a>2. 作成、LeaderboardQuery

`LeaderboardQuery`金額、順を決定し、ランキング呼び出しから返されるデータの出発点です。  

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

A`LeaderboardQuery`がいくつかの属性に設定できる返されるデータに影響を及ぼすあります。

|プロパティ |説明  |
|---------|---------|
|SkipResultToRank     |この uint 変数を返すときにで開始されますランキング データを順位付け何かが決まります。 順位付けは、ランク 1 から始まります。         |
|SkipResultToMe     |かどうか設定をこのブール値を true には、開始に返されるランキング データ、`XboxLiveUser`で使用される、`GetLeaderboard()`呼び出します。  |
|[オーダー]     |型の列挙型`Microsoft.Xbox.Services.Leaderboard.SortOrder`、昇順と降順の 2 つの可能な値を指定します。 クエリには、この変数を設定すると、スコアボードの並べ替え順序を決定します。        |
|maxItems     |この uint への呼び出しごとに返される行の最大数を決定する`GetLeaderboard()`または`GetSocialLeaderboard()`します。         |

形成、`LeaderboardQuery`は、次のようになります。

```csharp
using Microsoft.Xbox.Services.Leaderboard;

LeaderboardQuery query = new LeaderboardQuery
        {
            SkipResultToRank = 100,
            MaxItems = 5
        };
```

このクエリは返しません、100 から始まるランキングの 5 つの行のランク付けされた個人です。

> [!WARNING]
> SkipResultToRank プレーヤー、ランキング内に含まれる数よりも大きく設定をする 0 行が返されますランキング データとなります。

### <a name="3-call-getleaderboard"></a>3.GetLeaderboard() を呼び出す

呼び出せます`GetLeaderboard()`で、`XboxLiveUser`の統計の名前と`LeaderboardQuery`。

```csharp
statManager.GetLeaderboard(xboxLiveUser, statName, leaderboardQuery);
```

> [!IMPORTANT]
> `statName`で使用される、`GetLeaderboard()`呼び出しは、タイトル用に構成された状態の名前と同じである必要があります[パートナー センター](https://partner.microsoft.com/dashboard)、これは大文字小文字を区別します。

### <a name="4-read-leaderboard-data"></a>4。データの読み取りのランキング

呼び出す必要がありますランキング データを読み取るために、`StatisticManager.DoWork()`関数の一覧が返されます`StatisticEvent`値。 ランキング データが含まれる、`StatisticEvent`型の`GetLeaderboardComplete`します。 この型の一覧でのイベントが発生したときに`StatisticEvent`s に目を通すことがあります、`LeaderboardResult`に含まれている、`StatisticEvent`データにアクセスします。

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

見出しのコードで`StatisticManager.DoWork()`統計 Manager のすべての受信イベントを処理し、スコアボードのだけでなく使用する必要があります。 

> [!NOTE]
> 取得するために、`LeaderboardResultEventArgs`にキャストする必要があります、`StatisticEvent.EventArgs`として、`LeaderboardResultEventArgs`変数。

### <a name="5-retrieve-more-leaderboard-data"></a>5。多くのランキング データを取得します。

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