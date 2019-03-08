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
# <a name="leaderboards-data-in-unity"></a><span data-ttu-id="ae760-104">Unity のランキング データ</span><span class="sxs-lookup"><span data-stu-id="ae760-104">Leaderboards data in Unity</span></span>

<span data-ttu-id="ae760-105">希望するカスタム ランキング エクスペリエンスのため、この記事ではツールを提供 Unity 開発者に利用可能な Api 経由で移動して、独自のスコアボードを実装します。</span><span class="sxs-lookup"><span data-stu-id="ae760-105">For those of you who want a custom leaderboard experience, this article will give you the tools to implement your own leaderboard by going over the APIs available to Unity developers.</span></span> <span data-ttu-id="ae760-106">ランキング データをプルする方法を理解すると、独自のユーザー インターフェイスに適用できるようにします。</span><span class="sxs-lookup"><span data-stu-id="ae760-106">Once you understand how to pull down leaderboard data you will be able to apply it to the user interface of your choosing.</span></span>

[!IMPORTANT]
> <span data-ttu-id="ae760-107">この記事では、更新が (1804 のリリース) を 2018 年の月に行われる前に、プラグインのバージョンに適用されます。</span><span class="sxs-lookup"><span data-stu-id="ae760-107">This article applies to a version of the plugin prior to an update made in May of 2018 (1804 Release).</span></span> <span data-ttu-id="ae760-108">その後は、Xbox Live プラグインをインストールするか、またはまだダウンロードしない場合は、ランキング データを収集するための別の呼び出しを使用して新しいバージョンがあります。</span><span class="sxs-lookup"><span data-stu-id="ae760-108">If you installed the Xbox Live Plugin after that time, or have not yet downloaded it you may have a newer version which uses different calls to collect leaderboard data.</span></span> <span data-ttu-id="ae760-109">これだけでなくこのプラグインのスクリーン ショットが一致しないこと、この最新リリースのものが表示されます。</span><span class="sxs-lookup"><span data-stu-id="ae760-109">In addition to this you will find that the screenshots in this plugin do not match those of the most recent release.</span></span> <span data-ttu-id="ae760-110">代わりを参照してください、[スクラッチ記事から新しい unity ランキング](unity-leaderboard-from-scratch.md)します。</span><span class="sxs-lookup"><span data-stu-id="ae760-110">Please instead refer to the [newer unity leaderboards from scratch article](unity-leaderboard-from-scratch.md).</span></span>


## <a name="call-for-leaderboard-data"></a><span data-ttu-id="ae760-111">ランキング データの呼び出し</span><span class="sxs-lookup"><span data-stu-id="ae760-111">Call for Leaderboard data</span></span>

<span data-ttu-id="ae760-112">Xbox Live サービスを呼び出す必要がありますからランキング データを要求するには  `void GetLeaderboard(XboxLiveUser user,  LeaderboardQuery query)`</span><span class="sxs-lookup"><span data-stu-id="ae760-112">In order to request leaderboard data from the Xbox Live service you must call  `void GetLeaderboard(XboxLiveUser user,  LeaderboardQuery query)`</span></span>

<span data-ttu-id="ae760-113">正常に取得する必要がこの呼び出しを行う、`XboxLiveUser`から[サインイン](unity-prefabs-and-sign-in.md)が、 [stat が構成されている](add-stats-and-leaderboards-in-unity.md)に少なくとも 1 つのプレーヤーとフォーム値を持つ、 `LeaderboardQuery`。</span><span class="sxs-lookup"><span data-stu-id="ae760-113">To successfully make this call you will need to acquire an `XboxLiveUser` from [sign-in](unity-prefabs-and-sign-in.md), have a [configured stat](add-stats-and-leaderboards-in-unity.md) with value for at least one player, and form a `LeaderboardQuery`.</span></span> <span data-ttu-id="ae760-114">ユーザーをサインインまたは、ランキングの統計情報を初期化する必要がある方法が既にわかっていない場合は、リンク先の記事を読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="ae760-114">You can read the linked articles if you do not already know how to sign-in a user or need to initialize a statistic for your leaderboard.</span></span> <span data-ttu-id="ae760-115">初期化した後、統計、leaderboard スクリプトとの関連付けの最も簡単な方法は、統計プレハブのいずれかに含める: `IntegerStat`、 `DoubleStat`、または`StringStat`パブリック変数として。</span><span class="sxs-lookup"><span data-stu-id="ae760-115">Once you have a initialized a statistic the easiest way to associate it with your leaderboard script is to include one of the statistic prefabs: `IntegerStat`, `DoubleStat`, or `StringStat` as a public variable.</span></span> <span data-ttu-id="ae760-116">ID プロパティでは、少なくともとして構成する必要があります、統計の使用はこれは、 **statName**ランキング データを呼び出すときにパラメーター。</span><span class="sxs-lookup"><span data-stu-id="ae760-116">Your stat will need to have it's ID property configured at the very least as this is what we will use for the **statName** parameter when we call for our leaderboard data.</span></span> <span data-ttu-id="ae760-117">フォームに必要な最後に、`LeaderboardQuery`オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="ae760-117">Finally you will need to form a `LeaderboardQuery` object.</span></span>
<span data-ttu-id="ae760-118">A`LeaderboardQuery`がいくつかの属性に設定できる返されるデータに影響を及ぼすあります。</span><span class="sxs-lookup"><span data-stu-id="ae760-118">A `LeaderboardQuery` has a few attributes that can be set which will effect the data returned:</span></span>

- <span data-ttu-id="ae760-119">**StatName(Required):** ランキングは、データを取得する統計の ID は、これが設定されていない統計の ID 値に設定されていない場合これは、データは返されません。</span><span class="sxs-lookup"><span data-stu-id="ae760-119">**StatName(Required):** this is the ID of the stat your leaderboard will retrieve data for, if this is not set not set to a stats ID value, no data will be returned.</span></span>
- <span data-ttu-id="ae760-120">**SocialGroup:** この文字列の値に応じて、返されたランキング データはフィルター処理に友人、お気に入りの友人またはが設定されていない場合は、フィルター処理されていないグローバルなランキングを取得します。</span><span class="sxs-lookup"><span data-stu-id="ae760-120">**SocialGroup:** depending on the value of this string your returned leaderboard data will be filtered to your friends, your favorite friends, or if not set, will retrieve an unfiltered global leaderboard.</span></span> <span data-ttu-id="ae760-121">値""、フィルター処理されていないリストのみお気に入り友人と存在するリストが返されますが、「お気に入り」友人のみを持つリストを返す"all"は値を返します。</span><span class="sxs-lookup"><span data-stu-id="ae760-121">The value "" will returns an unfiltered list, the value "all" will return a list with only your friends in it, "favorite" will return a list with only your favorite friends present.</span></span>
- <span data-ttu-id="ae760-122">**SkipResultToRank:** 設定すると、この uint 変数が判断されますを返すときにでランキング データを順位付けと開始されます。</span><span class="sxs-lookup"><span data-stu-id="ae760-122">**SkipResultToRank:** if set, this uint variable will determine what ranking the Leaderboard data will start with when returning.</span></span> <span data-ttu-id="ae760-123">順位付けは、ランク 1 から始まります。</span><span class="sxs-lookup"><span data-stu-id="ae760-123">Rankings start at rank 1.</span></span>
- <span data-ttu-id="ae760-124">**SkipResultToMe:** かどうか設定をこのブール値を true には、開始に返されるランキング データ、`XboxLiveUser`で使用される、`GetLeaderboard()`呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ae760-124">**SkipResultToMe:** if set to true this boolean value will cause the leaderboard data returned to start at the `XboxLiveUser` used in the `GetLeaderboard()` call.</span></span>
- <span data-ttu-id="ae760-125">**順序:** 型の列挙型`Microsoft.Xbox.Services.Leaderboard.SortOrder`、昇順と降順の 2 つの可能な値を指定します。</span><span class="sxs-lookup"><span data-stu-id="ae760-125">**Order:** Enums of type `Microsoft.Xbox.Services.Leaderboard.SortOrder` have two possible values, ascending, and descending.</span></span> <span data-ttu-id="ae760-126">クエリには、この変数を設定すると、スコアボードの並べ替え順序を決定します。</span><span class="sxs-lookup"><span data-stu-id="ae760-126">Setting this variable for your query will determine the sort order of your leaderboard.</span></span> <span data-ttu-id="ae760-127">既定では、ランキングは、データを降順で返します。</span><span class="sxs-lookup"><span data-stu-id="ae760-127">By default leaderboards return data in descending order.</span></span>
- <span data-ttu-id="ae760-128">**MaxItems:** この uint への呼び出しごとに返される行の最大数を決定する`GetLeaderboard()`します。</span><span class="sxs-lookup"><span data-stu-id="ae760-128">**MaxItems:** This uint determines the maximum number of rows to return per call to `GetLeaderboard()`.</span></span>

<span data-ttu-id="ae760-129">次のようになります可能性があります、LeaderboardQuery を形成します。</span><span class="sxs-lookup"><span data-stu-id="ae760-129">Forming your LeaderboardQuery may look like the following:</span></span>

```csharp
using Microsoft.Xbox.Services.Leaderboard;

LeaderboardQuery query = new LeaderboardQuery
        {
            StatName = stat.ID,
            SkipResultToRank = 100,
            MaxItems = 5
        };
```

<span data-ttu-id="ae760-130">このクエリを使用してが返されます、100 から始まるランキングの 5 つの行のランク付けされた個々 の特定の統計。</span><span class="sxs-lookup"><span data-stu-id="ae760-130">Using this query will return five rows of the leaderboard starting at the 100th ranked individual for the given stat.</span></span>

> [!WARNING]
> <span data-ttu-id="ae760-131">SkipResultToRank プレーヤー、ランキング内に含まれる数よりも大きく設定をする 0 行が返されますランキング データとなります。</span><span class="sxs-lookup"><span data-stu-id="ae760-131">Setting SkipResultToRank higher than the number of players contained within the leaderboard will cause the leaderboard data to return with zero rows.</span></span>

<span data-ttu-id="ae760-132">呼び出しのすべての同時取得したので、`GetLeaderboard(XboxLiveUser user,  LeaderboardQuery query)`関数は、ここで使用する、符号付き`XboxLiveUser`(可能性があります、 `XboxLiveUserInfo.User`) サインイン、当社のユーザーとしてから取得した、`LeaderboardQuery`クエリとして作成したばかりです。</span><span class="sxs-lookup"><span data-stu-id="ae760-132">Now that we have all of the pieces together we can call the `GetLeaderboard(XboxLiveUser user,  LeaderboardQuery query)` function, where we will use our signed in `XboxLiveUser` (likely an `XboxLiveUserInfo.User`) obtained from sign-in, as our user, and the `LeaderboardQuery` we just created as our query.</span></span>

<span data-ttu-id="ae760-133">関数を呼び出して、ランキングは、次のようになります可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ae760-133">Your leaderboard calling function may look like the following:</span></span>

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

<span data-ttu-id="ae760-134">ここで、お気付きかもしれませんが、スコアボードの関数を取得する`GetLeaderboard()`void を返すし、したがって、探している leaderboard データは返しません。</span><span class="sxs-lookup"><span data-stu-id="ae760-134">Now, you may have noticed that our leaderboard retrieving function `GetLeaderboard()` returns void and thus does not return the leaderboard data we are looking for.</span></span> <span data-ttu-id="ae760-135">次のセクションで説明されているイベント関数でランキング データの取得が実際にします。</span><span class="sxs-lookup"><span data-stu-id="ae760-135">We will actually retrieve the leaderboard data in an event function discussed in the next section.</span></span>

## <a name="receive-the-leaderboard-data"></a><span data-ttu-id="ae760-136">ランキング データを受け取る</span><span class="sxs-lookup"><span data-stu-id="ae760-136">Receive the Leaderboard data</span></span>

<span data-ttu-id="ae760-137">リッスンしている関数を追加する必要がありますランキング データを取得するために、`StatsManagerComponent`のタイトルのインスタンス。</span><span class="sxs-lookup"><span data-stu-id="ae760-137">In order to retrieve the leaderboard data you will need to add a listening function to the `StatsManagerComponent` instance for your title.</span></span> <span data-ttu-id="ae760-138">次のコードの行を追加する必要があります、 `Awake()` 、コードの関数:`StatsManagerComponent.Instance.GetLeaderboardCompleted += this.MyGetLeaderboardCompletedFunction`します。</span><span class="sxs-lookup"><span data-stu-id="ae760-138">You should add the following line of code to the `Awake()` function of your code: `StatsManagerComponent.Instance.GetLeaderboardCompleted += this.MyGetLeaderboardCompletedFunction`.</span></span>

```csharp
private void Awake()
    {
        this.EnsureEventSystem();
        XboxLiveServicesSettings.EnsureXboxLiveServicesSettings();

        StatsManagerComponent.Instance.GetLeaderboardCompleted += this.GetLeaderboardCompleted;
    }
```

<span data-ttu-id="ae760-139">`StatsManagerComponent`ランキング完了イベントを待機します。</span><span class="sxs-lookup"><span data-stu-id="ae760-139">The `StatsManagerComponent` listens for leaderboard completion events.</span></span> <span data-ttu-id="ae760-140">次のコードを実行すると、ランキングの完了イベントが発生したときに呼び出される関数の一覧に関数を追加します。</span><span class="sxs-lookup"><span data-stu-id="ae760-140">By running this line of code, you will add a function  to the list of functions to be called when a leaderboard completion event occurs.</span></span> <span data-ttu-id="ae760-141">この例でその関数が呼び出される`MyGetLeaderBoardCompletedFunction()`、独自のスクリプトで好きなように関数を付けることができます。</span><span class="sxs-lookup"><span data-stu-id="ae760-141">In this example that function is called `MyGetLeaderBoardCompletedFunction()`, you can name the function as you like in your own script.</span></span> <span data-ttu-id="ae760-142">2 つのパラメーターは、送信者を表すオブジェクトを実行する必要があります"MyGetLeaderboardCompletedFunction"関数と`Microsoft.Xbox.Services.Client.StatEventArgs`パラメーター。</span><span class="sxs-lookup"><span data-stu-id="ae760-142">The function "MyGetLeaderboardCompletedFunction" will need to take two parameters, an object that represents the sender, and a `Microsoft.Xbox.Services.Client.StatEventArgs` parameter.</span></span> <span data-ttu-id="ae760-143">関数のシェルは、これのようになります可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ae760-143">The shell of your function may look something like this:</span></span>

```csharp
using Microsoft.Xbox.Services.Statistics.Manager;

private void MyGetLeaderBoardCompletedFunction(object sender, StatEventArgs statArgs)
    {
        //Do Something;
    }
```

<span data-ttu-id="ae760-144">まず、この関数が行う必要がありますが記載されているエラーを確認、`StatEventArgs`パラメーター statArgs します。</span><span class="sxs-lookup"><span data-stu-id="ae760-144">The first thing this function should do is check for errors which can be found in the `StatEventArgs` parameter statArgs.</span></span> <span data-ttu-id="ae760-145">StatArgs が含まれています、`StatisticEvent`を含む EventData と呼ばれる、 `System.Exception` ErrorInfo と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="ae760-145">StatArgs contains a `StatisticEvent` called EventData which contains the `System.Exception` called ErrorInfo.</span></span> <span data-ttu-id="ae760-146">ランキング データの取得中にエラーがあった場合は、statArgs.EventData.ErrorInfo で見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="ae760-146">If there was an error in retrieving the leaderboard data you can find it in statArgs.EventData.ErrorInfo.</span></span> <span data-ttu-id="ae760-147">簡単な if を追加する前のコードのエラーをチェックするステートメント。</span><span class="sxs-lookup"><span data-stu-id="ae760-147">You can add a simple if statement to the previous code to check for errors.</span></span>

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

<span data-ttu-id="ae760-148">エラーがないことを確定した後はランキング要求の結果を格納する`statArgs.EventData.EventArgs.Result`します。</span><span class="sxs-lookup"><span data-stu-id="ae760-148">After confirming that there are no errors, store the results of the leaderboard request which are found in `statArgs.EventData.EventArgs.Result`.</span></span> <span data-ttu-id="ae760-149">`Result` `LeaderBoardResult`ランキングを設定する必要があるデータを格納するオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="ae760-149">`Result` is a `LeaderBoardResult` object which contains the data you need to populate your leaderboard.</span></span> <span data-ttu-id="ae760-150">サンプル コードはこのデータを抽出し、LoadResult と呼ばれる別の関数に送信します。</span><span class="sxs-lookup"><span data-stu-id="ae760-150">In our example code we will extract this data and send it to another function called LoadResult.</span></span>

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

<span data-ttu-id="ae760-151">`LeaderboardResult` LoadResult 関数に送信する結果が両方が返されたランキング データを読み取るだけでなくされていない元の呼び出しによって返されるランクを取得する追加の呼び出しを行う必要がありますすべてのデータが必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae760-151">The `LeaderboardResult` result that we send to the LoadResult function will have all the data we need to both read the leaderboard data that was returned as well as make additional calls to retrieve ranks not yet returned by the original call.</span></span> <span data-ttu-id="ae760-152">Leaderboard スクリプト クラスの変数に結果を格納するようになります。</span><span class="sxs-lookup"><span data-stu-id="ae760-152">You will want to store the results in a class variable for your leaderboard script like so:</span></span>

```csharp
using Microsoft.Xbox.Services.Leaderboard;

void LoadResult(LeaderboardResult result)
    {
        this.leaderboardData = result;
    }
```

<span data-ttu-id="ae760-153">これは重要ですので、`LeaderboardResult`取得できる、スコアボードの後のセクションがあるかどうかを決定する HasNext プロパティが含まれています。</span><span class="sxs-lookup"><span data-stu-id="ae760-153">This is important because the `LeaderboardResult` contains a HasNext property that determines whether or not there is a later section of the leaderboard that can be retrieved.</span></span> <span data-ttu-id="ae760-154">`LeaderboardResult`も、スコアボードを構成する行の合計の変数を格納します。</span><span class="sxs-lookup"><span data-stu-id="ae760-154">The `LeaderboardResult` also stores a variable for the total of rows that make up the leaderboard.</span></span> <span data-ttu-id="ae760-155">これらのプロパティは、ランキングを移動する場合に重要になります。</span><span class="sxs-lookup"><span data-stu-id="ae760-155">These properties will be important to navigating your leaderboard.</span></span> <span data-ttu-id="ae760-156">データをプルする、`LeaderBoardResult`単純に実装するループを使用するため、`LeaderboardResults`の一覧`LeaderboardRow`と呼ばれる`Rows`。</span><span class="sxs-lookup"><span data-stu-id="ae760-156">To pull data from your `LeaderBoardResult` simply implement a for loop using the `LeaderboardResults` list of `LeaderboardRow` called `Rows`.</span></span> <span data-ttu-id="ae760-157">サンプル コードで単にここでは、各値を連結する`LeaderboardRow`を表示する文字列。</span><span class="sxs-lookup"><span data-stu-id="ae760-157">In our sample code we are simply going to concatenate the values in each `LeaderboardRow` into a string to be displayed.</span></span>

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

<span data-ttu-id="ae760-158">この例でのランク、ゲーマータグ、および値プロパティを使用して`LeaderBoardResult`、文字列だけでなく、スコアボードに関連付けられている状態の表示名を設定します。</span><span class="sxs-lookup"><span data-stu-id="ae760-158">In our example we used the Rank, Gamertag, and Values properties of `LeaderBoardResult` to populate our strings, as well as the DisplayName of the stat associated with the leaderboard.</span></span>

<span data-ttu-id="ae760-159">すべてのランキング データをいっそうクリエイティブな処理を行うことができますと思います。</span><span class="sxs-lookup"><span data-stu-id="ae760-159">I am sure you'll be able to do something more creative with all of this leaderboard data.</span></span>

## <a name="navigating-the-leaderboard-data"></a><span data-ttu-id="ae760-160">ランキング データを移動します。</span><span class="sxs-lookup"><span data-stu-id="ae760-160">Navigating the Leaderboard data</span></span>

<span data-ttu-id="ae760-161">最も一般的なインスタンスでは読み込まれませんすべて 1 つのランクのランキングで 1 回と、ユーザーのランキングのさまざまなセクションを表示するランクを移動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae760-161">In the most common instances you will not load every single rank in your leaderboard at once, and will need to be able to navigate the ranks to display different sections of the leaderboard for the user.</span></span> <span data-ttu-id="ae760-162">ランキングは、100 個のプレーヤーのランクがあることをお知らせとします。</span><span class="sxs-lookup"><span data-stu-id="ae760-162">Let us say that you have a leaderboard with one-hundred ranked players.</span></span> <span data-ttu-id="ae760-163">最初の呼び出しで`GetLeaderboard()`10 個を取得する`LeaderboardRows`し、プレーヤーを表示します。</span><span class="sxs-lookup"><span data-stu-id="ae760-163">In your initial call to `GetLeaderboard()` you retrieve ten `LeaderboardRows` and display them for the player.</span></span> <span data-ttu-id="ae760-164">プレーヤーは、複数のトップ 10 プレーヤーを参照してくださいする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ae760-164">The player may want to see more than the top ten players.</span></span> <span data-ttu-id="ae760-165">10 人のユーザーの [次へ] のセットを取得する最も簡単な方法は、決定するかどうか、 `LeaderboardResult` 、最後から格納されているクエリに行を取得して、呼び出し元が`GetLeaderboard()`でその LeaderboardResult の`NextQuery`プロパティ。</span><span class="sxs-lookup"><span data-stu-id="ae760-165">The easiest way to get the next set of ten users is to determine whether or not the `LeaderboardResult` you stored from your last query has more rows to retrieve and then calling `GetLeaderboard()` with that LeaderboardResult's `NextQuery` property.</span></span> <span data-ttu-id="ae760-166">次のコードでは、次のランキング データ セットを取得します。</span><span class="sxs-lookup"><span data-stu-id="ae760-166">The following code will retrieve the next set of leaderboard data.</span></span>

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

<span data-ttu-id="ae760-167">ランキングで内を後方に向かって移動することは、前の X、スコアボードのランクの数を取得する関数が存在しないため、もう少し困難です。</span><span class="sxs-lookup"><span data-stu-id="ae760-167">Moving backwards in your leaderboard is a little more difficult as there is no function to pull the previous X number of ranks from your leaderboard.</span></span> <span data-ttu-id="ae760-168">前のランクを取得するためには、独自のロジックを記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae760-168">In order to retrieve previous rankings you will have to write your own logic.</span></span> <span data-ttu-id="ae760-169">1 つのメソッドを格納することも、`MaxItems`あたり`LeaderboardQuery`を使用してにスキップする必要があります。 どのような順位付けの計算と、`SkipToRank`の属性、`LeaderboardQuery`します。</span><span class="sxs-lookup"><span data-stu-id="ae760-169">One method would be to store your `MaxItems` per `LeaderboardQuery` and calculate what rank you need to skip to using the `SkipToRank` attribute of your `LeaderboardQuery`.</span></span> <span data-ttu-id="ae760-170">そのコードは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="ae760-170">That code might look something like this:</span></span>

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

<span data-ttu-id="ae760-171">最後の最も一般的なシナリオは、いるプレーヤーをすることも、スコアボードのスポットを参照してください。</span><span class="sxs-lookup"><span data-stu-id="ae760-171">The final most common scenario is that a player may simply want to see their spot on the leaderboard.</span></span> <span data-ttu-id="ae760-172">呼び出すことによってこれを簡単に行う、`GetLeaderboard()`クエリで関数を場所、`SkipResultToMe`属性が設定を true にします。</span><span class="sxs-lookup"><span data-stu-id="ae760-172">This is easily achieved by calling the `GetLeaderboard()` function with a query where the `SkipResultToMe` attribute is set to true.</span></span>

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

<span data-ttu-id="ae760-173">詳細なランキング例に詳細を知りたい場合は、資産下 XboxLive プラグインのフォルダーに Leaderboard.cs スクリプトを常に読み取ることができます >> XboxLive >> スクリプト >> Leaderboard.cs します。</span><span class="sxs-lookup"><span data-stu-id="ae760-173">If you want to dive into a more detailed leaderboard example you can always read the Leaderboard.cs script in the XboxLive Plugin folder under Assets >> XboxLive >> Scripts >> Leaderboard.cs.</span></span>