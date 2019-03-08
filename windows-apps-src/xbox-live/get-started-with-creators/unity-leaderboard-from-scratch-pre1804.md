---
title: Unity でのランキングを作成します。
description: Unity で独自のランキングの構築に関するガイドします。
ms.date: 04/24/2018
ms.topic: get-started-article
keywords: xbox live、xbox、ゲーム、uwp、windows 10、1 つ xbox、unity、ランキング
ms.openlocfilehash: a62cb2b3bd4afebcc7aa9060db60ac167f052977
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57657827"
---
# <a name="leaderboards-data-in-unity"></a>Unity のランキング データ

希望するカスタム ランキング エクスペリエンスのため、この記事ではツールを提供 Unity 開発者に利用可能な Api 経由で移動して、独自のスコアボードを実装します。 ランキング データをプルする方法を理解すると、独自のユーザー インターフェイスに適用できるようにします。

[!IMPORTANT]
> この記事では、更新が (1804 のリリース) を 2018 年の月に行われる前に、プラグインのバージョンに適用されます。 その後は、Xbox Live プラグインをインストールするか、またはまだダウンロードしない場合は、ランキング データを収集するための別の呼び出しを使用して新しいバージョンがあります。 これだけでなくこのプラグインのスクリーン ショットが一致しないこと、この最新リリースのものが表示されます。 代わりを参照してください、[スクラッチ記事から新しい unity ランキング](unity-leaderboard-from-scratch.md)します。


## <a name="call-for-leaderboard-data"></a>ランキング データの呼び出し

Xbox Live サービスを呼び出す必要がありますからランキング データを要求するには  `void GetLeaderboard(XboxLiveUser user,  LeaderboardQuery query)`

正常に取得する必要がこの呼び出しを行う、`XboxLiveUser`から[サインイン](unity-prefabs-and-sign-in.md)が、 [stat が構成されている](add-stats-and-leaderboards-in-unity.md)に少なくとも 1 つのプレーヤーとフォーム値を持つ、 `LeaderboardQuery`。 ユーザーをサインインまたは、ランキングの統計情報を初期化する必要がある方法が既にわかっていない場合は、リンク先の記事を読み取ることができます。 初期化した後、統計、leaderboard スクリプトとの関連付けの最も簡単な方法は、統計プレハブのいずれかに含める: `IntegerStat`、 `DoubleStat`、または`StringStat`パブリック変数として。 ID プロパティでは、少なくともとして構成する必要があります、統計の使用はこれは、 **statName**ランキング データを呼び出すときにパラメーター。 フォームに必要な最後に、`LeaderboardQuery`オブジェクト。
A`LeaderboardQuery`がいくつかの属性に設定できる返されるデータに影響を及ぼすあります。

- **StatName(Required):** ランキングは、データを取得する統計の ID は、これが設定されていない統計の ID 値に設定されていない場合これは、データは返されません。
- **SocialGroup:** この文字列の値に応じて、返されたランキング データはフィルター処理に友人、お気に入りの友人またはが設定されていない場合は、フィルター処理されていないグローバルなランキングを取得します。 値""、フィルター処理されていないリストのみお気に入り友人と存在するリストが返されますが、「お気に入り」友人のみを持つリストを返す"all"は値を返します。
- **SkipResultToRank:** 設定すると、この uint 変数が判断されますを返すときにでランキング データを順位付けと開始されます。 順位付けは、ランク 1 から始まります。
- **SkipResultToMe:** かどうか設定をこのブール値を true には、開始に返されるランキング データ、`XboxLiveUser`で使用される、`GetLeaderboard()`呼び出します。
- **順序:** 型の列挙型`Microsoft.Xbox.Services.Leaderboard.SortOrder`、昇順と降順の 2 つの可能な値を指定します。 クエリには、この変数を設定すると、スコアボードの並べ替え順序を決定します。 既定では、ランキングは、データを降順で返します。
- **MaxItems:** この uint への呼び出しごとに返される行の最大数を決定する`GetLeaderboard()`します。

次のようになります可能性があります、LeaderboardQuery を形成します。

```csharp
using Microsoft.Xbox.Services.Leaderboard;

LeaderboardQuery query = new LeaderboardQuery
        {
            StatName = stat.ID,
            SkipResultToRank = 100,
            MaxItems = 5
        };
```

このクエリを使用してが返されます、100 から始まるランキングの 5 つの行のランク付けされた個々 の特定の統計。

> [!WARNING]
> SkipResultToRank プレーヤー、ランキング内に含まれる数よりも大きく設定をする 0 行が返されますランキング データとなります。

呼び出しのすべての同時取得したので、`GetLeaderboard(XboxLiveUser user,  LeaderboardQuery query)`関数は、ここで使用する、符号付き`XboxLiveUser`(可能性があります、 `XboxLiveUserInfo.User`) サインイン、当社のユーザーとしてから取得した、`LeaderboardQuery`クエリとして作成したばかりです。

関数を呼び出して、ランキングは、次のようになります可能性があります。

```csharp
using Microsoft.Xbox.Services.Leaderboard;

public void LoadLeaderboard()
    {
        // check to make sure you have a valid stat
        if (this.stat == null)
        {
            // TO DO: Display "Stat not specified" error message!
            return;
        }

        // check to make sure you have an XboxLiveUser
        if (this.xboxLiveUser == null)
        {
            if (XboxLiveUserManager.Instance.UserForSingleUserMode != null
                && XboxLiveUserManager.Instance.UserForSingleUserMode.User != null)
            {
                // set the XboxLiveUser if one is available
                this.xboxLiveUser = XboxLiveUserManager.Instance.UserForSingleUserMode.User;
            }
            else // if you don't have a user signed in display an error message and exit. 
            {
                // TO DO: Display "User Not logged In" error message
                return;
            }
        }

        LeaderboardQuery query;

        query = new LeaderboardQuery
        {
            StatName = this.stat.ID,
            MaxItems = this.maxItems,

        };

        XboxLive.Instance.StatsManager.GetLeaderboard(this.xboxLiveUser, query);
    }
```

ここで、お気付きかもしれませんが、スコアボードの関数を取得する`GetLeaderboard()`void を返すし、したがって、探している leaderboard データは返しません。 次のセクションで説明されているイベント関数でランキング データの取得が実際にします。

## <a name="receive-the-leaderboard-data"></a>ランキング データを受け取る

リッスンしている関数を追加する必要がありますランキング データを取得するために、`StatsManagerComponent`のタイトルのインスタンス。 次のコードの行を追加する必要があります、 `Awake()` 、コードの関数:`StatsManagerComponent.Instance.GetLeaderboardCompleted += this.MyGetLeaderboardCompletedFunction`します。

```csharp
private void Awake()
    {
        this.EnsureEventSystem();
        XboxLiveServicesSettings.EnsureXboxLiveServicesSettings();

        StatsManagerComponent.Instance.GetLeaderboardCompleted += this.GetLeaderboardCompleted;
    }
```

`StatsManagerComponent`ランキング完了イベントを待機します。 次のコードを実行すると、ランキングの完了イベントが発生したときに呼び出される関数の一覧に関数を追加します。 この例でその関数が呼び出される`MyGetLeaderBoardCompletedFunction()`、独自のスクリプトで好きなように関数を付けることができます。 2 つのパラメーターは、送信者を表すオブジェクトを実行する必要があります"MyGetLeaderboardCompletedFunction"関数と`Microsoft.Xbox.Services.Client.StatEventArgs`パラメーター。 関数のシェルは、これのようになります可能性があります。

```csharp
using Microsoft.Xbox.Services.Statistics.Manager;

private void MyGetLeaderBoardCompletedFunction(object sender, StatEventArgs statArgs)
    {
        //Do Something;
    }
```

まず、この関数が行う必要がありますが記載されているエラーを確認、`StatEventArgs`パラメーター statArgs します。 StatArgs が含まれています、`StatisticEvent`を含む EventData と呼ばれる、 `System.Exception` ErrorInfo と呼ばれます。 ランキング データの取得中にエラーがあった場合は、statArgs.EventData.ErrorInfo で見つけることができます。 簡単な if を追加する前のコードのエラーをチェックするステートメント。

```csharp
using Microsoft.Xbox.Services.Statistics.Manager;

private void MyGetLeaderBoardCompletedFunction(object sender, StatEventArgs statArgs)
    {
        if (e.EventData.ErrorInfo != null && e.EventData.ErrorInfo.Message == "")
        {
            // TO DO: Display error message
            return;
        }
    }
```

エラーがないことを確定した後はランキング要求の結果を格納する`statArgs.EventData.EventArgs.Result`します。 `Result` `LeaderBoardResult`ランキングを設定する必要があるデータを格納するオブジェクト。 サンプル コードはこのデータを抽出し、LoadResult と呼ばれる別の関数に送信します。

```csharp
using Microsoft.Xbox.Services.Statistics.Manager;

private void MyGetLeaderBoardCompletedFunction(object sender, StatEventArgs statArgs)
    {
        if (e.EventData.ErrorInfo != null && e.EventData.ErrorInfo.Message == "")
        {
            // TO DO: Display error message
            return;
        }

        LeaderboardResultEventArgs leaderboardArgs = (LeaderboardResultEventArgs)statArgs.EventData.EventArgs;
        this.LoadResult(leaderboardArgs.Result);
    }
```

`LeaderboardResult` LoadResult 関数に送信する結果が両方が返されたランキング データを読み取るだけでなくされていない元の呼び出しによって返されるランクを取得する追加の呼び出しを行う必要がありますすべてのデータが必要があります。 Leaderboard スクリプト クラスの変数に結果を格納するようになります。

```csharp
using Microsoft.Xbox.Services.Leaderboard;

void LoadResult(LeaderboardResult result)
    {
        this.leaderboardData = result;
    }
```

これは重要ですので、`LeaderboardResult`取得できる、スコアボードの後のセクションがあるかどうかを決定する HasNext プロパティが含まれています。 `LeaderboardResult`も、スコアボードを構成する行の合計の変数を格納します。 これらのプロパティは、ランキングを移動する場合に重要になります。 データをプルする、`LeaderBoardResult`単純に実装するループを使用するため、`LeaderboardResults`の一覧`LeaderboardRow`と呼ばれる`Rows`。 サンプル コードで単にここでは、各値を連結する`LeaderboardRow`を表示する文字列。

```csharp
using Microsoft.Xbox.Services.Leaderboard

void LoadResult(LeaderboardResult result)
{

    this.leaderboardData = result;

    this.leaderBoardText.text = "" // leaderBoardText is a UnityEngine.UI text box.

    foreach (LeaderboardRow row in this.leaderboardData.Rows)
    {
        leaderBoardText.text += string.Format("Rank: {0} | Gamertag: {1} | {2}:{3}\n\n", row.Rank, row.Gamertag, this.stat.DisplayName, row.Values[0]);
    }
}
```

この例でのランク、ゲーマータグ、および値プロパティを使用して`LeaderBoardResult`、文字列だけでなく、スコアボードに関連付けられている状態の表示名を設定します。

すべてのランキング データをいっそうクリエイティブな処理を行うことができますと思います。

## <a name="navigating-the-leaderboard-data"></a>ランキング データを移動します。

最も一般的なインスタンスでは読み込まれませんすべて 1 つのランクのランキングで 1 回と、ユーザーのランキングのさまざまなセクションを表示するランクを移動する必要があります。 ランキングは、100 個のプレーヤーのランクがあることをお知らせとします。 最初の呼び出しで`GetLeaderboard()`10 個を取得する`LeaderboardRows`し、プレーヤーを表示します。 プレーヤーは、複数のトップ 10 プレーヤーを参照してくださいする可能性があります。 10 人のユーザーの [次へ] のセットを取得する最も簡単な方法は、決定するかどうか、 `LeaderboardResult` 、最後から格納されているクエリに行を取得して、呼び出し元が`GetLeaderboard()`でその LeaderboardResult の`NextQuery`プロパティ。 次のコードでは、次のランキング データ セットを取得します。

```csharp
using Microsoft.Xbox.Services;
using Microsoft.Xbox.Services.Leaderboard;

void GetNextLeaders()
    {
        if(this.leaderboardData.HasNext)
        {
            LeaderboardQuery query = this.leaderboardData.NextQuery;
            XboxLive.Instance.StatsManager.GetLeaderboard(this.xboxLiveUser, query);
        }
        else
        {
            //TO DO: Display an error message or go back to the beginning of the leaderboard as the situation demands.
        }
    }
```

ランキングで内を後方に向かって移動することは、前の X、スコアボードのランクの数を取得する関数が存在しないため、もう少し困難です。 前のランクを取得するためには、独自のロジックを記述する必要があります。 1 つのメソッドを格納することも、`MaxItems`あたり`LeaderboardQuery`を使用してにスキップする必要があります。 どのような順位付けの計算と、`SkipToRank`の属性、`LeaderboardQuery`します。 そのコードは、次のようになります。

```csharp
using Microsoft.Xbox.Services;
using Microsoft.Xbox.Services.Leaderboard;

void GetPreviousLeader()
{
    if(leaderboardData == null || leaderboardData.Rows.Count < 1)
    {
        return;
    }

    uint topRank = leaderboardData.Rows[0].Rank; //get the first rank of the leaderboard.
    uint targetRank = topRank - this.maxItems > 0 ? topRank - this.maxItems : 0; //set your targetRank equal to the current top rank of your leaderboard minus the configured number of rows to display at a time.

    LeaderboardQuery query = new LeaderboardQuery // make a new query with the calculated targetRank
    {
        StatName = stat.ID,
        SkipResultToRank = targetRank,
        MaxItems = this.maxItems
    };

    XboxLive.Instance.StatsManager.GetLeaderboard(this.xboxLiveUser, query); // call the GetLeaderboard() function with the new query
}
```

最後の最も一般的なシナリオは、いるプレーヤーをすることも、スコアボードのスポットを参照してください。 呼び出すことによってこれを簡単に行う、`GetLeaderboard()`クエリで関数を場所、`SkipResultToMe`属性が設定を true にします。

```csharp
using Microsoft.Xbox.Services;
using Microsoft.Xbox.Services.Leaderboard;

    void GetRankForTag()
    {

        LeaderboardQuery query = new LeaderboardQuery // make a new query with the calculated targetRank
        {
            StatName = stat.ID,
            SkipResultToMe = true,
            MaxItems = this.maxItems
        };

        XboxLive.Instance.StatsManager.GetLeaderboard(this.xboxLiveUser, query); // call the GetLeaderboard() function with the new query
    }
```

詳細なランキング例に詳細を知りたい場合は、資産下 XboxLive プラグインのフォルダーに Leaderboard.cs スクリプトを常に読み取ることができます >> XboxLive >> スクリプト >> Leaderboard.cs します。