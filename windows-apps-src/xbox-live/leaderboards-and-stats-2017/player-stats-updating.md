---
title: 統計の更新 2017
author: KevinAsgari
description: 統計 2017 を使用して Xbox Live のプレイヤーの統計を更新する方法について説明します。
ms.assetid: 019723e9-4c36-4059-9377-4a191c8b8775
ms.author: kevinasg
ms.date: 08/24/2018
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, プレイヤーの統計, 統計 2017
ms.localizationpriority: medium
ms.openlocfilehash: 6f61858347955bde007d97420cfb33d8e0298fd2
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5925084"
---
# <a name="updating-stats-2017"></a>統計の更新 2017

統計を更新するには、`StatsManager` API (後で説明します) を使用して Xbox Live サービスに最新の値を送信します。

プレイヤーの統計を追跡するかどうかは、タイトルに応じて決めることができます。また、統計を必要に応じて更新するには `StatsManager` を呼び出します。  `StatsManager` は、あらゆる変更をバッファリングして、定期的にサービスにフラッシュします。  タイトルでは、手動でフラッシュすることもできます。

> [!NOTE]
> 統計を頻繁にフラッシュ避けてください。  頻繁にフラッシュすると、タイトルのレートが制限されます。  多くても 5 分に 1 回フラッシュすることが、ベスト プラクティスです。

### <a name="multiple-devices"></a>複数のデバイス

プレイヤーは複数のデバイスでタイトルをプレイすることができますが、  その場合には同期のための作業が必要になります。

たとえば、プレイヤーが自宅の Xbox で 15 回ヘッドショットに成功したとします。  その後、友人宅の Xbox で さらに 10 回ヘッドショットに成功しました。  2 台目のデバイスで 25 という統計値を送信する必要がありますが、  この情報を同期しないと、正しい統計値を把握することができません。

この同期を実行するための方法を以下に示します。

1. [接続ストレージ](../storage-platform/connected-storage/connected-storage-technical-overview.md)を使用して統計を保存します。  通常、接続ストレージはユーザーごとのセーブ データに使用します。  このデータは、指定されたユーザーの複数のデバイス間で同期が維持されます。
2. タイトルに対して補助的なタスクを実行している独自の Web サービスを既にご利用の場合は、その Web サービスを使用して統計を同期します。

### <a name="offline"></a>オフライン

前述のとおり、タイトルはプレイヤーの統計を追跡し、オフラインのシナリオをサポートする必要があります。 

### <a name="examples"></a>例

これらの概念を 1 つにまとめるために、例を示します。

レーシング ゲームの一般的な統計はラップ タイムです。  通常、こうした統計では、より低い数値がより優れた成績を表します。このため、低い数値を優れた成績とする統計および関連するランキングを作成します。  つまり、このランキングは昇順で並べ替えることになります。

タイトルは、プレイ セッションの間ユーザーのラップ タイムを追跡します。  前回の最高記録よりも短いラップ タイムがある場合のみ、StatsManager を更新します。

前回の最高記録を追跡するには、次に示す方法のいずれかを使用します。
1. 接続ストレージを使用して保存ファイルから取得する。
2. 独自の Web サービスを使用する。

サービスは、どのような場合でも統計値を置き換えます。  つまり、ラップ タイムが前回の最高記録より長い場合でも、前回の最高記録が上書きされます。

このため、タイトルでは、ゲームプレイ シナリオに基づいて適切な統計値のみを送信してください。  低い数値を優れた成績とする場合も、高い数値を優れた成績とする場合もあります。また、これら 2 つのケースとまったく異なる場合もあります。

## <a name="programming-guide"></a>プログラミング ガイド

通常、統計を使用するフローは次のようになります。

1. `StatsManager` API をローカル ユーザーに渡して初期化します。
1. ユーザーがタイトルをプレイしているとき、`set_stat` 関数を使用して統計値を更新します。
1. これらの統計の更新は、定期的にフラッシュされ Xbox Live に書き込まれます。  これは手動でも実行できます。

### <a name="initialization"></a>初期化

必要な情報によって API を初期化するために、ローカル ユーザーを指定して `StatsManager` を呼び出します。

以下の例をご覧ください

```cpp
std::shared_ptr<stats_manager> statsManager = stats_manager::get_singleton_instance();
statsManager->add_local_user(user);
statsManager->do_work();  // returns stat_event_type::local_user_added
```

```csharp
Microsoft.Xbox.Services.Statistics.Manager.StatisticManager statManager = StatisticManager.SingletonInstance;
statManager.AddLocalUser(user);
statEvent = statManager.DoWork();
```

### <a name="writing-stats"></a>統計の書き込み

統計は、関数の `stats_manager::set_stat` ファミリを使用して書き込みます。  この関数には、データ型に応じて次の 3 つのバリエーションがあります。

* `set_stat_number` (浮動小数点型の場合)。
* `set_stat_integer` (整数型の場合)。
* `set_stat_string` (文字列型の場合)。

これらの関数を呼び出すとき、統計の更新はデバイスでローカルにキャッシュされ、  定期的に Xbox Live にフラッシュされます。

`stats_manager::request_flush_to_service` API を使用して、統計を手動でフラッシュすることもできます。  この関数を頻繁に呼び出すとレートが制限されるので注意してください。  頻繁に呼び出した場合でも、統計が更新されなくなるのではなく、  タイムアウト時間が経過してから更新が行われるようになるだけです。

```cpp
statsManager->set_stat_integer(user, L"numHeadshots", 20);
statsManager->request_flush_to_service(user); // requests flush to service, performs a do_work
statsManager->do_work();  // applies the stat changes, returns stat_update_complete after flush to service
```

```csharp
statManager.SetStatisticIntegerData(user, statName, (long)statValue);
statManager.RequestFlushToService(user);
statManager.DoWork();
```

#### <a name="example"></a>例

一人称視点のシューティング ゲームをプレイしているとします。  対戦が行われている間、次の統計を蓄積します。

| 統計の名前 | 形式 |
|-----------|--------|
| ラウンドあたりの最高撃墜数 | 整数型 |
| 全体の時間における撃墜数 | 整数型 |
| 全体の時間における死亡数 | 整数型 |
| 全体の時間における撃墜と死亡の割合 | 数値 |

対戦が進むごとに、*ラウンドあたりの最高撃墜数*、*全体の時間における撃墜数*、および*全体の時間における死亡数*をローカルに増分します。

対戦が終了するときに、以下を実行します。
1. ラウンドでの撃墜数と前回の最高記録を比較します。  今回の方が値が大きい場合は、`StatsManager` を更新します。
2. 全体の時間における撃墜数と死亡数を新しい値で更新し、`StatsManager` を更新します。
3. 撃墜数を死亡数で除算した割合を計算し、次を更新します:  `StatsManager`

手順 1 と 2 では、以前の統計値を知っておく必要があります。  以前の統計値を取得するベスト プラクティスについては、上記のセクションをご覧ください。

これらの統計はどれもランキングに対応させることができます。詳しくは、次の記事で説明します。

### <a name="flushing-stats"></a>統計のフラッシュ

手動で統計をフラッシュするには `stats_manager::request_flush_to_service` を使用します。  ランキングを表示する場合は、手動でフラッシュすることをお勧めします。

たとえば、上記の例の `Lifetime Kills` に関するランキングがある場合、ランキングを表示する前に、この統計に対応する統計の更新がサーバーにフラッシュされているようにする必要があります。  これで、ランキングにはプレイヤーの最新の進行状況が反映されるようになります。

### <a name="cleanup"></a>クリーンアップ
タイトルを終了するときは、StatsManager からユーザーを削除します。 これにより、サービスに最新の統計値がフラッシュされます。

```cpp
statsManager->remove_local_user(user);
statsManager->do_work();  // applies the stat changes, returns local_user_removed after flush to service
```

```csharp
statManager.RemoveLocalUser(user);
statManager.DoWork();
```
