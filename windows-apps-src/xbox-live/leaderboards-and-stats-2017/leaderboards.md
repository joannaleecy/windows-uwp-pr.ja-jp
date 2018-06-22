---
title: ランキング
author: KevinAsgari
description: Xbox Live のランキングを使用してプレイヤーを比較する方法について説明します。
ms.assetid: 132604f9-6107-4479-9246-f8f497978db7
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: low
ms.openlocfilehash: 9452956e85c5156503ae15fb2c0880fa06642cfd
ms.sourcegitcommit: f91aa1e402f1bc093b48a03fbae583318fc7e05d
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/24/2018
ms.locfileid: "1917644"
---
# <a name="leaderboards"></a>ランキング

## <a name="introduction"></a>はじめに

「[データ プラットフォームの概要](../data-platform/data-platform.md)」で説明されているように、ランキングは、プレイヤー間の競争を促し、プレイヤー自身やフレンドが持つベスト スコアの更新に関心を持たせる場合に有効な方法です。

[注目の統計](player-stats.md#what-needs-to-be-configured)のランキングは、ゲーム ハブに表示されます。  ただし、注目の統計と通常の統計の両方のランキングの作成は、タイトルから直接実行できます。

## <a name="choosing-good-leaderboards"></a>適切なランキングの選択

「[プレイヤーの統計](player-stats.md)」で説明したように、ランキングは定義した統計に対応しています。  プレイヤーが上を目指して努力し、達成できる実績に対応したランキングを選んでください。

たとえば、カー レーシング ゲームのベスト ラップ タイムは適切なランキングです。プレイヤーはベスト ラップ タイムを更新しようと努力するためです。  他の例としては、戦闘ゲームにおける撃墜と死亡の割合や最大コンボ サイズなどがあります。

## <a name="when-to-display-leaderboards"></a>ランキングを表示するタイミング

ランキングはいつでもタイトルに表示できます。  ランキングがゲームプレイやタイトルのフローを邪魔しない時間を選択してください。  ラウンドの合間、試合後などが適切なタイミングです。

## <a name="how-to-display-leaderboards"></a>ランキングを表示する方法

Xbox Live SDK には、ランキングを表示するためのオプションが多数用意されています。  Xbox Live クリエーターズ プログラム で Unity を使用している場合、ランキング プレハブを使ってランキング データを表示することができます。  詳しくは、「[Unity で Xbox Live を構成する](../get-started-with-creators/configure-xbox-live-in-unity.md)」の記事をご覧ください。

Xbox Live SDK で直接コードを記述している場合、使用できる API についての説明をお読みください。

### <a name="programming-guide"></a>プログラミング ガイド

ランキングの現在の状態を取得する際に使用できるランキング API がいくつか用意されています。  すべての API は非同期であり、ブロックしません。  ランキング データの取得要求を行い、通常のゲーム処理を続行します。  ランキング結果がサービスから返されたら、適切なタイミングで結果を表示できます。

プレイヤーがランキングの表示を待ってブロックされないように、サービスから提供されるランキング データは、表示する少し前に要求してください。

すべてのランキング API については、`leaderboard_service` 名前空間をご覧ください。

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

</table>

次に、サービスからランキング結果が返されたときに呼び出されるコールバックを設定できます。  以下にこの例を示します。

これらの API から返される `pplx::task` について簡単に説明すると、これは Microsoft 並列プログラミング ライブラリ (PPL) からの非同期タスク オブジェクトです。  詳しくは、[https://github.com/Microsoft/cpprestsdk/wiki/Programming-with-Tasks](https://github.com/Microsoft/cpprestsdk/wiki/Programming-with-Tasks) を参照してください。

以下のセクションでは、ランキング結果を取得して使用する方法について説明します。

### <a name="example"></a>例

#### <a name="1-create-an-async-task-to-retrieve-leaderboard-results"></a>1. 非同期タスクを作成してランキング結果を取得する

最初の手順として、ランキング サービスを呼び出して特定のランキングの結果を取得します。

```cpp
pplx::task<xbox_live_result<leaderboard_result>> asyncTask;
auto& leaderboardService = xboxLiveContext->leaderboard_service();

asyncTask = leaderboardService.get_leaderboard(m_liveResources->GetServiceConfigId(), LeaderboardIdEnemyDefeats);
```

#### <a name="2-setup-a-callback"></a>2. コールバックをセットアップする

ランキング結果が返されたときに呼び出されるように、[継続タスク](https://msdn.microsoft.com/en-us/library/dd492427(v=vs.110).aspx#continuations)をセットアップできます。  以下のように行います。

```cpp
asyncTask.then([this](xbox::services::xbox_live_result<xbox::services::leaderboard::leaderboard_result> result)
{
    // Handle result here
});
```

この継続タスクは、最初に呼び出したオブジェクトのコンテキストで呼び出され、タイトルに合った方法で表示可能な ```leaderboard_result``` を受け取ります。


#### <a name="3-display-leaderboard"></a>3. ランキングを表示する

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