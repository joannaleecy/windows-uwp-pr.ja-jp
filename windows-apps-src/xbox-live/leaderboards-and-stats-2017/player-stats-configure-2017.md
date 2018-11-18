---
title: 統計とランキングの構成 2017
author: KevinAsgari
description: データ プラットフォーム 2017 のパートナー センターで Xbox Live の注目の統計とランキングを構成する方法について説明します。
ms.assetid: e0f307d2-ea02-48ea-bcdf-828272a894d4
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: caea254143561d3e38b6583db90945118671e435
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7160978"
---
# <a name="configuring-featured-stats-or-leaderboards-in-partner-center-with-data-platform-2017"></a>データ プラットフォーム 2017 をパートナー センターでの注目の統計やランキングの構成

データ プラットフォーム 2017 では、統計を構成する必要があるのは次の 2 つの場合のみです。

* 統計がグローバル ランキングの基準として使用される場合
* 統計が、ゲーム ハブ ページに表示される "注目のプレイヤーの統計" として使用される場合

どちらの場合でも、統計とランキングを一緒に構成する必要があります。 すべてのランキングは統計を基準としており、"注目のプレイヤーの統計" でランキングを使用しない場合であっても、関連するグローバル ランキングを構成しないと統計を構成することはできません。

"注目のプレイヤーの統計" 以外の統計、およびグローバル ランキングで使用されない統計は構成する必要がありません。

## <a name="configure-a-global-leaderboard-and-an-associated-player-stat"></a>グローバル ランキング、および関連付するプレイヤーの統計を構成する

まず、次に示すようにタイトルの [プレイヤーの統計] セクションに移動します。

![](../images/omega/dev_center_player_stats_creators.png)

次に [`Create your first featured stat/leaderboard`] ボタンをクリックし、ダイアログに入力したら [保存] をクリックします。

![](../images/omega/dev_center_player_stats_creators_leaderboard.png)

[`Display name`] フィールドは、ゲーム ハブでユーザーに表示される名前です。  この文字列は [`Localize strings`] セクションでローカライズすることができます。  文字列をローカライズする方法の詳細を確認するには、[`Localize strings`] セクションの [`Show Options`] をクリックしてください。

[`ID`] フィールドは統計の名前です。統計をタイトル コードから更新する場合は、この ID で統計を指定します。   詳しくは、「[統計の更新](player-stats-updating.md)」セクションをご覧ください。

[`Format`] は、統計のデータ形式です。

[`Display Logic`] では、[`Player progression`]、[`Personal best`]、[`Counter`] のいずれかを選択します。
- [Player progression] (プレイヤーの進行状況): ゲームでの各プレイヤーのレベルや進行状況を表します。  最新の値セットが、ユーザーに表示されます   (たとえば、現在のラウンドにおける順位など)。
- [Personal Best] (自己ベスト): プレイヤーが投稿した現在のベスト スコアを表します。 並べ替え順序に応じて最大または最小の値セットが、ユーザーに表示されます   (たとえば、最速ラップなど)。
- [Counter] (カウンター): 他のプレイヤーの値に追加され、累積数を計算できます。  

[`Sort`] フィールドでは、ランキングの並べ替え順序を変更することができます。

この統計を `Featured Stat` にすることもできますが、そのためには、[`Feature on players' profiles`] をクリックします。  

## <a name="configure-featured-stats"></a>注目の統計を構成する

プレイヤーの統計を定義するとき、`Featured Stat` を有効にするオプションを使用することができます。  要件は次のとおりです。

| 開発者の種類 | 要件 |
|----------------|-------------|
| Xbox Live クリエーターズ プログラム | 統計を注目の統計として指定するための要件はありませんが、指定できる注目の統計の数は最大 10 個に制限されます。 |
| ID@Xbox および Microsoft パートナー | 注目の統計は、3 ～ 10 個まで指定する必要があります。 |

## <a name="next-steps"></a>次の手順

次に、タイトル コードから統計を更新する必要があります。  詳しくは、「[統計の更新](player-stats-updating.md)」をご覧ください。