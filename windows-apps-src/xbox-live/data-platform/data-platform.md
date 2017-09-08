---
title: "Xbox Live データ プラットフォーム"
author: KevinAsgari
description: "実績、プレイヤーの統計、ランキングを管理するサービスで構成される、Xbox Live データ プラットフォームの概要について説明します。"
ms.assetid: a8bb7c4f-09fe-4dba-b3ce-1fab60453831
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, 統計, 実績, ランキング, 設計, データ プラットフォーム"
ms.openlocfilehash: 86f140744d7a3a90bc3bf5d0e546d8e72b1527d3
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="xbox-live-data-platform---stats-leaderboards-achievements"></a>Xbox Live データ プラットフォーム - 統計、ランキング、実績

ゲーム データを Xbox Live データ プラットフォームに書き込むことにより、タイトルをサービスとして実行できます。 また、Xbox Live データプラットフォームは、統計、ランキング、実績を利用して、ユーザーがタイトルに関心を持つように促したり、本体のシェルと Xbox アプリに注目の統計を表示したりします。

ドラッグ ストリップ モードで走行した全レース数はレーシング ゲームの統計の一例であり、これを使用して、スコアをコミュニティと比較するランキングを作成し、リッチ プレゼンスの文字列にリアルタイムで反映できます (例: "GoTeamEmily はドラッグ ストリップ モードをプレイ中: 523 レースを完了")。 ドラッグ ストリップ モードの全レース数はマッチメイキングの条件としても使用でき、類似した経験を持つプレイヤーどうしが対戦する可能性を高めることができます。

タイトルでは、プレイヤーの統計に基づいてランキングを表示できます。 たとえば、ランキングを完了したレースのグローバル ランキングにすることができます。 これらのサービスは、Xbox Live API を使って直接呼び出すか、Unity などのゲーム エンジンでラッパーを使って呼び出します。

特定の統計を注目の統計として指定できます。 注目の統計は、タイトルのゲーム ハブに表示され、プレイヤーとフレンドの成績を比較することができます。

実績は統計に基づいて動作するのではなく、実績がロック解除されるタイミングはタイトルが決定します。 たとえば、タイトルでは、レースの完了に関する実績を 1 分未満保持することができます。 タイトルは、実績のロック解除に必要なパラメーターを追跡します。 この例では、レースの所要時間を測定して実績を付与する処理はタイトルが行います。 通常、ゲーマースコアは実績の完了と同時に付与されます。 各実績で使用するゲーマースコアの量はユーザーが決定します。

## <a name="features"></a>機能 ##
以下のトピックでは、Xbox Live データ プラットフォームの機能について、さらに詳しく説明します。

* [プレイヤーの統計](../leaderboards-and-stats-2017/player-stats.md)
* [実績](../achievements-2017/achievements.md)
* [ランキング](../leaderboards-and-stats-2017/leaderboards.md)