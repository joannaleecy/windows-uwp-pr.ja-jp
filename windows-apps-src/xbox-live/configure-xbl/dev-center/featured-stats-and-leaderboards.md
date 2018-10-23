---
title: 注目の統計とランキング 2017
author: shrutimundra
description: Windows デベロッパー センターで Xbox Live の注目の統計とランキング 2017 を構成する方法について説明します。
ms.assetid: e0f307d2-ea02-48ea-bcdf-828272a894d4
ms.author: kevinasg
ms.date: 10/30/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
keywords: Xbox Live, Xbox, ゲーム, uwp, windows 10, Xbox one, 注目の統計とランキング, ランキング, 統計 2017, Windows デベロッパー センター
ms.openlocfilehash: dcd73b7b1ea26cd929750ffed325896dfaf2c593
ms.sourcegitcommit: c4d3115348c8b54fcc92aae8e18fdabc3deb301d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/22/2018
ms.locfileid: "5395163"
---
# <a name="configuring-featured-stats-and-leaderboards-2017-on-windows-dev-center"></a>Windows デベロッパー センターで注目の統計とランキング 2017 を構成する

ゲームで統計サービスを操作するには、[Windows デベロッパー センター](https://developer.microsoft.com/dashboard)で統計を定義する必要があります。 注目の統計はすべてゲーム ハブに表示され、自動的にランキングとして機能します。 生の値が保存されますが、ゲームには新しい値が生成する必要があるかどうかを判断するロジックが追加されます。

![ゲーム ハブの実績ページのスクリーンショット](../../images/dev-center/featured-stats-and-leaderboards/featured-stats-and-leaderboards-2.png) 上の図は、タイトルのゲーム ハブに、注目の統計がどのように表示されるかを示しています。 注目の統計は赤のボックス内に表示されています。

データ プラットフォーム 2017 のみに表示されるソーシャル ランキングは、プレイヤーのゲーム ハブ ページで注目としてに使用されます。 統計を構成する必要があります。

Windows デベロッパー センターを使うと、ゲームに関連付けられている注目の統計とランキングを構成することができます。 次の手順に従って、構成を追加します。

1. **[サービス]** > **[Xbox Live]** > **[Featured stats and leaderboards]** (注目の統計とランキング) にある、タイトルの **[Featured stats and leaderboards]** (注目の統計とランキング) セクションに移動します。
2. **[新規作成]** ボタンをクリックすると、モーダル フォームで開きます。 入力したら、**[保存]** をクリックします。

![新しい注目の統計/ランキング ダイアログの画像](../../images/dev-center/featured-stats-and-leaderboards/featured-stats.png)

**[表示名]** フィールドは、ゲーム ハブでユーザーに表示される内容です。 この文字列は、Xbox Live サービス構成の **[Localize strings]** (文字列のローカライズ) でローカライズすることができます。

**[ID]** フィールドは統計の名前です。統計をコードから更新する場合は、この ID で統計を指定します。 詳しくは、「[統計の更新](../../leaderboards-and-stats-2017/player-stats-updating.md)」をご覧ください。

**[形式]** は、統計のデータ形式です。整数、10 進数、パーセンテージ、ショート タイムスパン、ロング タイムスパン、文字列などのオプションがあります。

**[形式]** の各オプションを選択すると、ドロップダウン リストに指定できる値や形式に関する情報が表示されます。

* 整数の統計では、1、2、100 のような整数を使用できます。
* 10 進数の統計では、1.05 や 12.00 などの小数点以下 2 桁は小数を使用できます。
* パーセンテージの統計では、0 ～ 100 の整数を使用できます。 整数の末尾に「%」が追加されます  (例: 0%、100%)。
* ショート タイムスパンの統計では、HH:MM:SS 形式 (02:10:30 など) に従い、統計の時間単位を指定するよう求められます。使用可能な時間単位は、ミリ秒、秒、分、時間、日です。
* ロング タイムスパンの統計では、Xd Xh Xm 形式 (1d 2h 10m など) に従い、この統計も統計の時間単位を指定するよう求められます。

**[並べ替え]** フィールドでは、ランキングの並べ替え順序を昇順または降順に変更できます。

注目の統計とランキングを構成するときは、次の要件に注意してください。

| 開発者の種類 | 要件 | 制限 |
|----------------|-------------|-------|
| Xbox Live クリエーターズ プログラム | 統計を注目の統計として指定するための要件はありません | 20 |
| ID@Xbox および Microsoft パートナー | 注目の統計は、3 個以上指定する必要があります | 20 |

## <a name="next-steps"></a>次のステップ

次に、コードから統計を更新する必要があります。  詳しくは、「[統計の更新](../../leaderboards-and-stats-2017/player-stats-updating.md)」をご覧ください。
