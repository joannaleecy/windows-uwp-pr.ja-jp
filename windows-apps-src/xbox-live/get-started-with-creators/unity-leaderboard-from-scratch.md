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
# <a name="script-a-leaderbaord-gameobject"></a><span data-ttu-id="69735-104">Leaderbaord GameObject をスクリプトします。</span><span class="sxs-lookup"><span data-stu-id="69735-104">Script a leaderbaord GameObject</span></span>

<span data-ttu-id="69735-105">希望するカスタム ランキング エクスペリエンスのため、この記事ではツールを提供 Unity 開発者に利用可能な Api 経由で移動して、独自のスコアボードを実装します。</span><span class="sxs-lookup"><span data-stu-id="69735-105">For those of you who want a custom leaderboard experience, this article will give you the tools to implement your own leaderboard by going over the APIs available to Unity developers.</span></span> <span data-ttu-id="69735-106">ランキング データをプルする方法を理解すると、独自のユーザー インターフェイスに適用できるようにします。</span><span class="sxs-lookup"><span data-stu-id="69735-106">Once you understand how to pull down leaderboard data you will be able to apply it to the user interface of your choosing.</span></span>

## <a name="call-for-leaderboard-data"></a><span data-ttu-id="69735-107">ランキング データの呼び出し</span><span class="sxs-lookup"><span data-stu-id="69735-107">Call for Leaderboard data</span></span>

<span data-ttu-id="69735-108">ランキング データを取得する 2 つの API 呼び出しがあります。</span><span class="sxs-lookup"><span data-stu-id="69735-108">There are two API calls to retrieve leaderboard data.</span></span>

- `void GetLeaderboard(XboxLiveUser user, string statName, LeaderboardQuery query)`
- `void GetSocialLeaderboard(XboxLiveUSer user, string statName, string socialGroup, LeaderboardQuery query)`

<span data-ttu-id="69735-109">いずれかを正常に確立するためにこれらの呼び出しに返すデータを取得する必要があります、`XboxLiveUser`によって[サインイン](unity-prefabs-and-sign-in.md)が、 [stat が構成されている](add-stats-and-leaderboards-in-unity.md)値は、少なくとも 1 つのプレーヤーとフォームを`LeaderboardQuery`.</span><span class="sxs-lookup"><span data-stu-id="69735-109">In order to successfully make either of these calls return data you will need to acquire an `XboxLiveUser` by [sign-in](unity-prefabs-and-sign-in.md), have a [configured stat](add-stats-and-leaderboards-in-unity.md) with value for at least one player, and form a `LeaderboardQuery`.</span></span> <span data-ttu-id="69735-110">ユーザーをサインインまたは、ランキングの統計情報を初期化する必要がある方法が既にわかっていない場合は、リンク先の記事を読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="69735-110">You can read the linked articles if you do not already know how to sign-in a user or need to initialize a statistic for your leaderboard.</span></span> <span data-ttu-id="69735-111">統計のプレハブのいずれかに含める leaderboard スクリプトは、初期化の統計情報を簡単に関連付けることにした後: `IntegerStat`、 `DoubleStat`、または`StringStat`パブリック変数として。</span><span class="sxs-lookup"><span data-stu-id="69735-111">Once you have an initialized statistic the easiest way to associate it with your leaderboard script is to include one of the statistic prefabs: `IntegerStat`, `DoubleStat`, or `StringStat` as a public variable.</span></span> <span data-ttu-id="69735-112">ID プロパティでは、少なくともとして構成する必要があります、統計の使用はこれは、 **statName**ランキング データを呼び出すときにパラメーター。</span><span class="sxs-lookup"><span data-stu-id="69735-112">Your stat will need to have it's ID property configured at the very least as this is what we will use for the **statName** parameter when we call for our leaderboard data.</span></span> <span data-ttu-id="69735-113">フォームに必要な最後に、`LeaderboardQuery`オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="69735-113">Finally you will need to form a `LeaderboardQuery` object.</span></span>
<span data-ttu-id="69735-114">A`LeaderboardQuery`がいくつかの属性に設定できる返されるデータに影響を及ぼすあります。</span><span class="sxs-lookup"><span data-stu-id="69735-114">A `LeaderboardQuery` has a few attributes that can be set which will effect the data returned:</span></span>

- <span data-ttu-id="69735-115">**SkipResultToRank**: このオプションを設定すると、この uint 変数が判断されますを返すときにでランキング データを順位付けと開始されます。</span><span class="sxs-lookup"><span data-stu-id="69735-115">**SkipResultToRank**: if set, this uint variable will determine what ranking the leaderboard data will start with when returning.</span></span> <span data-ttu-id="69735-116">順位付けは、ランク 1 から始まります。</span><span class="sxs-lookup"><span data-stu-id="69735-116">Rankings start at rank 1.</span></span>
- <span data-ttu-id="69735-117">**SkipResultToMe**: かどうか設定をこのブール値を true には、開始に返されるランキング データ、`XboxLiveUser`で使用される、`GetLeaderboard()`呼び出します。</span><span class="sxs-lookup"><span data-stu-id="69735-117">**SkipResultToMe**: if set to true this boolean value will cause the leaderboard data returned to start at the `XboxLiveUser` used in the `GetLeaderboard()` call.</span></span>
- <span data-ttu-id="69735-118">**順序**:型の列挙型`Microsoft.Xbox.Services.Leaderboard.SortOrder`、昇順と降順の 2 つの可能な値を指定します。</span><span class="sxs-lookup"><span data-stu-id="69735-118">**Order**: Enums of type `Microsoft.Xbox.Services.Leaderboard.SortOrder` have two possible values, ascending, and descending.</span></span> <span data-ttu-id="69735-119">クエリには、この変数を設定すると、スコアボードの並べ替え順序を決定します。</span><span class="sxs-lookup"><span data-stu-id="69735-119">Setting this variable for your query will determine the sort order of your leaderboard.</span></span>
- <span data-ttu-id="69735-120">**MaxItems**:この uint への呼び出しごとに返される行の最大数を決定する`GetLeaderboard()`または`GetSocialLeaderboard()`します。</span><span class="sxs-lookup"><span data-stu-id="69735-120">**MaxItems**: This uint determines the maximum number of rows to return per call to `GetLeaderboard()` or `GetSocialLeaderboard()`.</span></span>

<span data-ttu-id="69735-121">次のようになります可能性があります、leaderboardQuery を形成します。</span><span class="sxs-lookup"><span data-stu-id="69735-121">Forming your leaderboardQuery may look like the following:</span></span>

```csharp
using Microsoft.Xbox.Services.Leaderboard;

LeaderboardQuery query = new LeaderboardQuery
        {
            SkipResultToRank = 100,
            MaxItems = 5
        };
```

<span data-ttu-id="69735-122">このクエリは返しません、100 から始まるランキングの 5 つの行のランク付けされた個人です。</span><span class="sxs-lookup"><span data-stu-id="69735-122">This query would return five rows of the leaderboard starting at the 100th ranked individual.</span></span>

> [!WARNING]
> <span data-ttu-id="69735-123">SkipResultToRank プレーヤー、ランキング内に含まれる数よりも大きく設定をする 0 行が返されますランキング データとなります。</span><span class="sxs-lookup"><span data-stu-id="69735-123">Setting SkipResultToRank higher than the number of players contained within the leaderboard will cause the leaderboard data to return with zero rows.</span></span>

<span data-ttu-id="69735-124">呼び出しのすべての同時取得したので、`GetLeaderboard(XboxLiveUser user, string statName, LeaderboardQuery query)`関数。</span><span class="sxs-lookup"><span data-stu-id="69735-124">Now that we have all of the pieces together we can call the `GetLeaderboard(XboxLiveUser user, string statName, LeaderboardQuery query)` function.</span></span>

<span data-ttu-id="69735-125">`GetSocialLeaderboard(XboxLiveUSer user, string statName, string socialGroup, LeaderboardQuery query)`関数が socialGroup と呼ばれる 1 つの余分なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="69735-125">The `GetSocialLeaderboard(XboxLiveUSer user, string statName, string socialGroup, LeaderboardQuery query)` function has one extra parameter called socialGroup.</span></span> <span data-ttu-id="69735-126">この文字列は、返されたデータでのリレーションシップのフィルターとして機能します。</span><span class="sxs-lookup"><span data-stu-id="69735-126">This string acts as a relationship filter on the returned data.</span></span> <span data-ttu-id="69735-127">SocialGroup に使用できる値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="69735-127">The acceptable values for socialGroup are as follows:</span></span>

- <span data-ttu-id="69735-128">「すべて」: XboxLiveUser の友人をフィルター処理のランキングが返されます</span><span class="sxs-lookup"><span data-stu-id="69735-128">"all": this will return a leaderboard filtered to the XboxLiveUser's friends</span></span>
- <span data-ttu-id="69735-129">「お気に入り」: XboxLiveUser のお気に入りの友人をフィルター処理のランキングが返されます</span><span class="sxs-lookup"><span data-stu-id="69735-129">"favorite": this will return a leaderboard filtered to the XboxLiveUser's favorite friends</span></span>

<span data-ttu-id="69735-130">使用することができます、`LeaderboardTypes`列挙型に、 `Microsoft.Xbox.Services.Client` 、ランキング socialGroup をラベル付けし、使用する名前空間、`LeaderboardHelper`関数をクラス`GetSocialGroupFromLeaderboardType(LeaderboardTypes leaderboardType)`の適切な文字列を引き出します。</span><span class="sxs-lookup"><span data-stu-id="69735-130">You can use the `LeaderboardTypes` enum in the `Microsoft.Xbox.Services.Client` namespace to label your leaderboards socialGroup and then use the `LeaderboardHelper` class function `GetSocialGroupFromLeaderboardType(LeaderboardTypes leaderboardType)` to pull out the appropriate string.</span></span>

> [!NOTE]
> <span data-ttu-id="69735-131">空の文字列を渡す socialGroup パラメーターには、呼び出し元と同じ結果が返される、`GetLeaderboard()`関数。</span><span class="sxs-lookup"><span data-stu-id="69735-131">Passing an empty string for the socialGroup parameter will return the same results as calling the `GetLeaderboard()` function.</span></span> <span data-ttu-id="69735-132">フィルター処理されていないが届きます*グローバル*ランキングをランクを持つすべてのユーザーがこのゲームのスコアボードにおける順位を示します。</span><span class="sxs-lookup"><span data-stu-id="69735-132">You will receive an unfiltered *global* leaderboard that shows everyone with a ranking in the leaderboard that has played the game.</span></span>

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

<span data-ttu-id="69735-133">今すぐお気付き、2 つのランキング取得関数は void を返すし、そのため、探している leaderboard データは返されません。</span><span class="sxs-lookup"><span data-stu-id="69735-133">Now you may have noticed that our two leaderboard retrieving functions return void and thus do not return the leaderboard data we are looking for.</span></span> <span data-ttu-id="69735-134">次のセクションで説明されているイベント関数でランキング データの取得が実際にします。</span><span class="sxs-lookup"><span data-stu-id="69735-134">We will actually retrieve the leaderboard data in an event function discussed in the next section.</span></span>

## <a name="receive-the-leaderboard-data"></a><span data-ttu-id="69735-135">ランキング データを受け取る</span><span class="sxs-lookup"><span data-stu-id="69735-135">Receive the Leaderboard data</span></span>

<span data-ttu-id="69735-136">リッスンしている関数を追加する必要がありますランキング データを取得するために、`StatsManagerComponent`のタイトルのインスタンス。</span><span class="sxs-lookup"><span data-stu-id="69735-136">In order to retrieve the leaderboard data you will need to add a listening function to the `StatsManagerComponent` instance for your title.</span></span> <span data-ttu-id="69735-137">次のコードの行を追加する必要があります、 `Awake()` 、コードの関数:`StatsManagerComponent.Instance.GetLeaderboardCompleted += this.MyGetLeaderboardCompletedFunction`します。</span><span class="sxs-lookup"><span data-stu-id="69735-137">You should add the following line of code to the `Awake()` function of your code: `StatsManagerComponent.Instance.GetLeaderboardCompleted += this.MyGetLeaderboardCompletedFunction`.</span></span> <span data-ttu-id="69735-138">`StatsManagerComponent`で、`Microsoft.Xbox.Services.Client`名前空間がランキング完了イベントをリッスンします。</span><span class="sxs-lookup"><span data-stu-id="69735-138">The `StatsManagerComponent` in the `Microsoft.Xbox.Services.Client` namespace listens for leaderboard completion events.</span></span> <span data-ttu-id="69735-139">次のコードを実行すると、ランキングの完了イベントが発生したときに呼び出される関数の一覧に関数を追加します。</span><span class="sxs-lookup"><span data-stu-id="69735-139">By running this line of code, you will add a function  to the list of functions to be called when a leaderboard completion event occurs.</span></span> <span data-ttu-id="69735-140">MyGetLeaderBoardCompletedFunction を関数はこの例で、独自のスクリプトで好きなように、関数に名前をことができます。</span><span class="sxs-lookup"><span data-stu-id="69735-140">In this example that function is called MyGetLeaderBoardCompletedFunction, you can name the function as you like in your own script.</span></span> <span data-ttu-id="69735-141">2 つのパラメーターは、送信者を表すオブジェクトを実行する必要があります"MyGetLeaderboardCompletedFunction"関数と`Microsoft.Xbox.Services.Client.StatEventArgs`パラメーター。</span><span class="sxs-lookup"><span data-stu-id="69735-141">The function "MyGetLeaderboardCompletedFunction" will need to take two parameters, an object that represents the sender, and a `Microsoft.Xbox.Services.Client.StatEventArgs` parameter.</span></span> <span data-ttu-id="69735-142">関数のシェルは、これのようになります可能性があります。</span><span class="sxs-lookup"><span data-stu-id="69735-142">The shell of your function may look something like this:</span></span>

```csharp
using Microsoft.Xbox.Services.Client;
using Microsoft.Xbox.Services.Statistics.Manager;

private void GetLeaderboardCompleted(object sender, StatEventArgs statArgs)
    {
        //Do Something;
    }
```

<span data-ttu-id="69735-143">まず、この関数が行う必要がありますが記載されているエラーを確認、`StatEventArgs`パラメーター statArgs します。</span><span class="sxs-lookup"><span data-stu-id="69735-143">The first thing this function should do is check for errors which can be found in the `StatEventArgs` parameter statArgs.</span></span> <span data-ttu-id="69735-144">StatArgs が含まれています、`StatisticEvent`エラー データが含まれる、EventData します。</span><span class="sxs-lookup"><span data-stu-id="69735-144">StatArgs contains a `StatisticEvent` EventData which contains error data.</span></span> <span data-ttu-id="69735-145">ランキング データの取得中にエラーがあった場合でを見つける`statArgs.EventData.ErrorCode`または`statArgs.EventData.ErrorMessage`します。</span><span class="sxs-lookup"><span data-stu-id="69735-145">If there was an error in retrieving the leaderboard data you can find it in `statArgs.EventData.ErrorCode` or `statArgs.EventData.ErrorMessage`.</span></span> <span data-ttu-id="69735-146">エラーがない場合、エラー コードの場合は 0 と、エラー メッセージは空の文字列になります""です。</span><span class="sxs-lookup"><span data-stu-id="69735-146">If there was no error the ErrorCode will be 0 and the ErrorMessage will be the empty string "".</span></span> <span data-ttu-id="69735-147">簡単な if を追加する前のコードのエラーをチェックするステートメント。</span><span class="sxs-lookup"><span data-stu-id="69735-147">You can add a simple if statement to the previous code to check for errors.</span></span>

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

<span data-ttu-id="69735-148">エラーがないことを確定した後はランキング要求の結果を格納する`statArgs.EventData.EventArgs.Result`します。</span><span class="sxs-lookup"><span data-stu-id="69735-148">After confirming that there are no errors, store the results of the leaderboard request which are found in `statArgs.EventData.EventArgs.Result`.</span></span> <span data-ttu-id="69735-149">`Result` `LeaderBoardResult`ランキングを設定する必要があるデータを格納するオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="69735-149">`Result` is a `LeaderBoardResult` object which contains the data you need to populate your leaderboard.</span></span> <span data-ttu-id="69735-150">サンプル コードはこのデータを抽出し、という別の関数に送信`LoadResult()`します。</span><span class="sxs-lookup"><span data-stu-id="69735-150">In our example code we will extract this data and send it to another function called `LoadResult()`.</span></span>

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

<span data-ttu-id="69735-151">`LeaderboardResult`に送信結果、`LoadResult()`関数で両方が返されたランキング データを読み取るだけでなくされていない元の呼び出しによって返されるランクを取得する追加の呼び出しを行う必要がありますすべてのデータが必要があります。</span><span class="sxs-lookup"><span data-stu-id="69735-151">The `LeaderboardResult` result that we send to the `LoadResult()` function will have all the data we need to both read the leaderboard data that was returned as well as make additional calls to retrieve ranks not yet returned by the original call.</span></span> <span data-ttu-id="69735-152">Leaderboard スクリプト クラスの変数に結果を格納するようになります。</span><span class="sxs-lookup"><span data-stu-id="69735-152">You will want to store the results in a class variable for your leaderboard script like so:</span></span>

```csharp
using Microsoft.Xbox.Services.Leaderboard;

void LoadResult(LeaderboardResult result)
    {
        this.leaderboardData = result;
    }
```

<span data-ttu-id="69735-153">これは重要ですので、`LeaderboardResult`が含まれています、`HasNext`取得できる、スコアボードの後のセクションがあるかどうかを決定するプロパティも含まれています、スコアボードを構成する行の合計数の結果。</span><span class="sxs-lookup"><span data-stu-id="69735-153">This is important because the `LeaderboardResult` contains a `HasNext` property that determines whether or not there is a later section of the leaderboard that can be retrieved, the result also contains a total count of the rows that make up the leaderboard.</span></span> <span data-ttu-id="69735-154">これらのプロパティは、ランキングを移動する場合に重要になります。</span><span class="sxs-lookup"><span data-stu-id="69735-154">These properties will be important to navigating your leaderboard.</span></span> <span data-ttu-id="69735-155">データをプルする、`LeaderBoardResult`単純に実装するループを使用するため、`LeaderboardResults`の一覧`LeaderboardRow`と呼ばれる`Rows`。</span><span class="sxs-lookup"><span data-stu-id="69735-155">To pull data from your `LeaderBoardResult` simply implement a for loop using the `LeaderboardResults` list of `LeaderboardRow` called `Rows`.</span></span> <span data-ttu-id="69735-156">サンプル コードで単にここでは、各値を連結する`LeaderboardRow`を表示する文字列。</span><span class="sxs-lookup"><span data-stu-id="69735-156">In our sample code we are simply going to concatenate the values in each `LeaderboardRow` into a string to be displayed.</span></span>


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

<span data-ttu-id="69735-157">この例では、LeaderBoardResult のランク、ゲーマータグ、および値プロパティを使用して、文字列だけでなく、スコアボードに関連付けられている状態の表示名を設定しました。</span><span class="sxs-lookup"><span data-stu-id="69735-157">In our example we used the Rank, Gamertag, and Values properties of LeaderBoardResult to populate our strings, as well as the DisplayName of the stat associated with the leaderboard.</span></span>

<span data-ttu-id="69735-158">すべてのランキング データをいっそうクリエイティブな処理を行うことができますと思います。</span><span class="sxs-lookup"><span data-stu-id="69735-158">I am sure you'll be able to do something more creative with all of this leaderboard data.</span></span>

## <a name="navigating-the-leaderboard-data"></a><span data-ttu-id="69735-159">ランキング データを移動します。</span><span class="sxs-lookup"><span data-stu-id="69735-159">Navigating the Leaderboard data</span></span>

<span data-ttu-id="69735-160">最も一般的なインスタンスでは読み込まれませんすべて 1 つのランクのランキングで 1 回と、ユーザーのランキングのさまざまなセクションを表示するランクを移動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="69735-160">In the most common instances you will not load every single rank in your leaderboard at once, and will need to be able to navigate the ranks to display different sections of the leaderboard for the user.</span></span> <span data-ttu-id="69735-161">100 の位のプレイヤーがランキングがあることをお知らせとします。</span><span class="sxs-lookup"><span data-stu-id="69735-161">Let us say that you have a leaderboard with 100 ranked players.</span></span> <span data-ttu-id="69735-162">最初の呼び出しで`GetLeaderboard()`または`GetSocialLeaderboard`10 を取得する`LeaderboardRows`し、プレーヤーを表示します。</span><span class="sxs-lookup"><span data-stu-id="69735-162">In your initial call to `GetLeaderboard()` or `GetSocialLeaderboard` you retrieve 10 `LeaderboardRows` and display them for the player.</span></span> <span data-ttu-id="69735-163">プレーヤーは、複数のトップ 10 プレーヤーを参照してくださいする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="69735-163">The player may want to see more than the top ten players.</span></span> <span data-ttu-id="69735-164">10 人のユーザーの [次へ] のセットを取得する最も簡単な方法は、決定するかどうか、 `LeaderboardResult` 、最後から格納されているクエリに行を取得して、呼び出し元が`GetLeaderboard()`その LeaderboardResult の次のクエリでします。</span><span class="sxs-lookup"><span data-stu-id="69735-164">The easiest way to get the next set of ten users is to determine whether or not the `LeaderboardResult` you stored from your last query has more rows to retrieve and then calling `GetLeaderboard()` with that LeaderboardResult's next query.</span></span> <span data-ttu-id="69735-165">LeaderBoardResult を使用する*nextQuery*関数を使用する必要があります`LeaderBoardResult.GetNextQuery()`します。</span><span class="sxs-lookup"><span data-stu-id="69735-165">To use a LeaderBoardResult's *nextQuery* you must use the function `LeaderBoardResult.GetNextQuery()`.</span></span> <span data-ttu-id="69735-166">次の一連の順位を取得するコードは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="69735-166">The code to retrieve the next set of ranks would look like the following.</span></span>

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

<span data-ttu-id="69735-167">ランキングで内を後方に向かって移動することは、前の X、スコアボードのランクの数を取得する関数が存在しないため、もう少し困難です。</span><span class="sxs-lookup"><span data-stu-id="69735-167">Moving backwards in your leaderboard is a little more difficult as there is no function to pull the previous X number of ranks from your leaderboard.</span></span> <span data-ttu-id="69735-168">前のランクを取得するためには、独自のロジックを記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="69735-168">In order to retrieve previous rankings you will have to write your own logic.</span></span> <span data-ttu-id="69735-169">1 つのメソッドを格納することも、`MaxItems`あたり`LeaderboardQuery`を使用してにスキップする必要があります。 どのような順位付けの計算と、`SkipToRank`の属性、`LeaderboardQuery`します。</span><span class="sxs-lookup"><span data-stu-id="69735-169">One method would be to store your `MaxItems` per `LeaderboardQuery` and calculate what rank you need to skip to using the `SkipToRank` attribute of your `LeaderboardQuery`.</span></span> <span data-ttu-id="69735-170">そのコードは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="69735-170">That code might look something like this:</span></span>

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

<span data-ttu-id="69735-171">最後の最も一般的なシナリオは、いるプレーヤーをすることも、スコアボードのスポットを参照してください。</span><span class="sxs-lookup"><span data-stu-id="69735-171">The final most common scenario is that a player may simply want to see their spot on the Leaderboard.</span></span> <span data-ttu-id="69735-172">呼び出すことによってこれを簡単に行う、`GetLeaderboard()`クエリで関数を場所、`SkipResultToMe`属性が設定を true にします。</span><span class="sxs-lookup"><span data-stu-id="69735-172">This is easily achieved by calling the `GetLeaderboard()` function with a query where the `SkipResultToMe` attribute is set to true.</span></span>

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

<span data-ttu-id="69735-173">詳細なランキング例に詳細を知りたい場合は、資産下 XboxLive プラグインのフォルダーに Leaderboard.cs スクリプトを常に読み取ることができます >> XboxLive >> スクリプト >> Leaderboard.cs します。</span><span class="sxs-lookup"><span data-stu-id="69735-173">If you want to dive into a more detailed Leaderboard example you can always read the Leaderboard.cs script in the XboxLive Plugin folder under Assets >> XboxLive >> Scripts >> Leaderboard.cs.</span></span>