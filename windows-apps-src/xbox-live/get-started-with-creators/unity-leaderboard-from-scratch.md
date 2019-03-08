---
title: Unity での Leaderboard をスクリプトします。
description: Unity で独自のランキングの構築に関するガイドします。
ms.date: 04/24/2018
ms.topic: get-started-article
keywords: xbox live、xbox、ゲーム、uwp、windows 10、1 つ xbox、unity、ランキング
ms.openlocfilehash: 6e73ffd9b55f3638eb3cf4245c6f7943fe92dc48
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608757"
---
# <a name="script-a-leaderbaord-gameobject"></a>Leaderbaord GameObject をスクリプトします。

希望するカスタム ランキング エクスペリエンスのため、この記事ではツールを提供 Unity 開発者に利用可能な Api 経由で移動して、独自のスコアボードを実装します。 ランキング データをプルする方法を理解すると、独自のユーザー インターフェイスに適用できるようにします。

## <a name="call-for-leaderboard-data"></a>ランキング データの呼び出し

ランキング データを取得する 2 つの API 呼び出しがあります。

- `void GetLeaderboard(XboxLiveUser user, string statName, LeaderboardQuery query)`
- `void GetSocialLeaderboard(XboxLiveUSer user, string statName, string socialGroup, LeaderboardQuery query)`

いずれかを正常に確立するためにこれらの呼び出しに返すデータを取得する必要があります、`XboxLiveUser`によって[サインイン](unity-prefabs-and-sign-in.md)が、 [stat が構成されている](add-stats-and-leaderboards-in-unity.md)値は、少なくとも 1 つのプレーヤーとフォームを`LeaderboardQuery`. ユーザーをサインインまたは、ランキングの統計情報を初期化する必要がある方法が既にわかっていない場合は、リンク先の記事を読み取ることができます。 統計のプレハブのいずれかに含める leaderboard スクリプトは、初期化の統計情報を簡単に関連付けることにした後: `IntegerStat`、 `DoubleStat`、または`StringStat`パブリック変数として。 ID プロパティでは、少なくともとして構成する必要があります、統計の使用はこれは、 **statName**ランキング データを呼び出すときにパラメーター。 フォームに必要な最後に、`LeaderboardQuery`オブジェクト。
A`LeaderboardQuery`がいくつかの属性に設定できる返されるデータに影響を及ぼすあります。

- **SkipResultToRank**: このオプションを設定すると、この uint 変数が判断されますを返すときにでランキング データを順位付けと開始されます。 順位付けは、ランク 1 から始まります。
- **SkipResultToMe**: かどうか設定をこのブール値を true には、開始に返されるランキング データ、`XboxLiveUser`で使用される、`GetLeaderboard()`呼び出します。
- **順序**:型の列挙型`Microsoft.Xbox.Services.Leaderboard.SortOrder`、昇順と降順の 2 つの可能な値を指定します。 クエリには、この変数を設定すると、スコアボードの並べ替え順序を決定します。
- **MaxItems**:この uint への呼び出しごとに返される行の最大数を決定する`GetLeaderboard()`または`GetSocialLeaderboard()`します。

次のようになります可能性があります、leaderboardQuery を形成します。

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

呼び出しのすべての同時取得したので、`GetLeaderboard(XboxLiveUser user, string statName, LeaderboardQuery query)`関数。

`GetSocialLeaderboard(XboxLiveUSer user, string statName, string socialGroup, LeaderboardQuery query)`関数が socialGroup と呼ばれる 1 つの余分なパラメーター。 この文字列は、返されたデータでのリレーションシップのフィルターとして機能します。 SocialGroup に使用できる値は次のとおりです。

- 「すべて」: XboxLiveUser の友人をフィルター処理のランキングが返されます
- 「お気に入り」: XboxLiveUser のお気に入りの友人をフィルター処理のランキングが返されます

使用することができます、`LeaderboardTypes`列挙型に、 `Microsoft.Xbox.Services.Client` 、ランキング socialGroup をラベル付けし、使用する名前空間、`LeaderboardHelper`関数をクラス`GetSocialGroupFromLeaderboardType(LeaderboardTypes leaderboardType)`の適切な文字列を引き出します。

> [!NOTE]
> 空の文字列を渡す socialGroup パラメーターには、呼び出し元と同じ結果が返される、`GetLeaderboard()`関数。 フィルター処理されていないが届きます*グローバル*ランキングをランクを持つすべてのユーザーがこのゲームのスコアボードにおける順位を示します。

```csharp
using Microsoft.Xbox.Services.Leaderboard;
using Microsoft.Xbox.Services.Statistics.Manager;
using Microsoft.Xbox.Services;

public void LoadLeaderboard()
{

    if (this.stat == null)
    {
        // TO DO: Display "Stat not specified" error message!
        return;
    }

    if (this.xboxLiveUser == null)
    {
        if (SignInManager.Instance.GetCurrentNumberOfPlayers() > 0)
        {
            this.xboxLiveUser = SignInManager.Instance.GetPlayer(1);
            this.isLocalUserAdded = true;
        }
        else
        {
            // TO DO: Display "No user signed-in" error message!
            return;
        }
    }

    LeaderboardQuery query = new LeaderboardQuery
    {
        MaxItems = 5,
    };

    XboxLive.Instance.StatsManager.GetLeaderboard(this.xboxLiveUser, this.stat.ID, otherQuery);
}

```

今すぐお気付き、2 つのランキング取得関数は void を返すし、そのため、探している leaderboard データは返されません。 次のセクションで説明されているイベント関数でランキング データの取得が実際にします。

## <a name="receive-the-leaderboard-data"></a>ランキング データを受け取る

リッスンしている関数を追加する必要がありますランキング データを取得するために、`StatsManagerComponent`のタイトルのインスタンス。 次のコードの行を追加する必要があります、 `Awake()` 、コードの関数:`StatsManagerComponent.Instance.GetLeaderboardCompleted += this.MyGetLeaderboardCompletedFunction`します。 `StatsManagerComponent`で、`Microsoft.Xbox.Services.Client`名前空間がランキング完了イベントをリッスンします。 次のコードを実行すると、ランキングの完了イベントが発生したときに呼び出される関数の一覧に関数を追加します。 MyGetLeaderBoardCompletedFunction を関数はこの例で、独自のスクリプトで好きなように、関数に名前をことができます。 2 つのパラメーターは、送信者を表すオブジェクトを実行する必要があります"MyGetLeaderboardCompletedFunction"関数と`Microsoft.Xbox.Services.Client.StatEventArgs`パラメーター。 関数のシェルは、これのようになります可能性があります。

```csharp
using Microsoft.Xbox.Services.Client;
using Microsoft.Xbox.Services.Statistics.Manager;

private void GetLeaderboardCompleted(object sender, StatEventArgs statArgs)
    {
        //Do Something;
    }
```

まず、この関数が行う必要がありますが記載されているエラーを確認、`StatEventArgs`パラメーター statArgs します。 StatArgs が含まれています、`StatisticEvent`エラー データが含まれる、EventData します。 ランキング データの取得中にエラーがあった場合でを見つける`statArgs.EventData.ErrorCode`または`statArgs.EventData.ErrorMessage`します。 エラーがない場合、エラー コードの場合は 0 と、エラー メッセージは空の文字列になります""です。 簡単な if を追加する前のコードのエラーをチェックするステートメント。

```csharp
using Microsoft.Xbox.Services.Client;
using Microsoft.Xbox.Services.Statistics.Manager;

private void GetLeaderboardCompleted(object sender, StatEventArgs statArgs)
    {
        if (statArgs.EventData.ErrorCode != 0) //if there is an error
        {
            // TO DO: Display error message
            return;
        }
    }
```

エラーがないことを確定した後はランキング要求の結果を格納する`statArgs.EventData.EventArgs.Result`します。 `Result` `LeaderBoardResult`ランキングを設定する必要があるデータを格納するオブジェクト。 サンプル コードはこのデータを抽出し、という別の関数に送信`LoadResult()`します。

```csharp
using Microsoft.Xbox.Services.Client;
using Microsoft.Xbox.Services.Statistics.Manager;

private void GetLeaderboardCompleted(object sender, StatEventArgs statArgs)
    {
        if (statArgs.EventData.ErrorCode != 0)
        {
            // TO DO: Display error message
            return;
        }

        LeaderboardResultEventArgs leaderboardArgs = (LeaderboardResultEventArgs)statArgs.EventData.EventArgs;
        this.LoadResult(leaderboardArgs.Result);
    }
```

`LeaderboardResult`に送信結果、`LoadResult()`関数で両方が返されたランキング データを読み取るだけでなくされていない元の呼び出しによって返されるランクを取得する追加の呼び出しを行う必要がありますすべてのデータが必要があります。 Leaderboard スクリプト クラスの変数に結果を格納するようになります。

```csharp
using Microsoft.Xbox.Services.Leaderboard;

void LoadResult(LeaderboardResult result)
    {
        this.leaderboardData = result;
    }
```

これは重要ですので、`LeaderboardResult`が含まれています、`HasNext`取得できる、スコアボードの後のセクションがあるかどうかを決定するプロパティも含まれています、スコアボードを構成する行の合計数の結果。 これらのプロパティは、ランキングを移動する場合に重要になります。 データをプルする、`LeaderBoardResult`単純に実装するループを使用するため、`LeaderboardResults`の一覧`LeaderboardRow`と呼ばれる`Rows`。 サンプル コードで単にここでは、各値を連結する`LeaderboardRow`を表示する文字列。


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

この例では、LeaderBoardResult のランク、ゲーマータグ、および値プロパティを使用して、文字列だけでなく、スコアボードに関連付けられている状態の表示名を設定しました。

すべてのランキング データをいっそうクリエイティブな処理を行うことができますと思います。

## <a name="navigating-the-leaderboard-data"></a>ランキング データを移動します。

最も一般的なインスタンスでは読み込まれませんすべて 1 つのランクのランキングで 1 回と、ユーザーのランキングのさまざまなセクションを表示するランクを移動する必要があります。 100 の位のプレイヤーがランキングがあることをお知らせとします。 最初の呼び出しで`GetLeaderboard()`または`GetSocialLeaderboard`10 を取得する`LeaderboardRows`し、プレーヤーを表示します。 プレーヤーは、複数のトップ 10 プレーヤーを参照してくださいする可能性があります。 10 人のユーザーの [次へ] のセットを取得する最も簡単な方法は、決定するかどうか、 `LeaderboardResult` 、最後から格納されているクエリに行を取得して、呼び出し元が`GetLeaderboard()`その LeaderboardResult の次のクエリでします。 LeaderBoardResult を使用する*nextQuery*関数を使用する必要があります`LeaderBoardResult.GetNextQuery()`します。 次の一連の順位を取得するコードは、次のようになります。

```csharp
using Microsoft.Xbox.Services;
using Microsoft.Xbox.Services.Leaderboard;

void GetNextLeaders()
    {
        if(this.leaderboardData.HasNext)
        {
            LeaderboardQuery query = this.leaderboardData.GetNextQuery();
            XboxLive.Instance.StatsManager.GetLeaderboard(this.xboxLiveUser, this.stat.ID, query);
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
        SkipResultToRank = targetRank,
        MaxItems = this.maxItems
    };

    XboxLive.Instance.StatsManager.GetLeaderboard(this.xboxLiveUser, this.stat.ID, query); // call the GetLeaderboard() function with the new query
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
            SkipResultToMe = true,
            MaxItems = this.maxItems
        };

        XboxLive.Instance.StatsManager.GetLeaderboard(this.xboxLiveUser, this.stat.ID, query); // call the GetLeaderboard() function with the new query
    }
```

詳細なランキング例に詳細を知りたい場合は、資産下 XboxLive プラグインのフォルダーに Leaderboard.cs スクリプトを常に読み取ることができます >> XboxLive >> スクリプト >> Leaderboard.cs します。