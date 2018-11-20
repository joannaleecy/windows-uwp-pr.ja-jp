---
author: jwmsft
ms.assetid: 24351dad-2ee3-462a-ae78-2752bb3374c2
title: バックグラウンド アクティビティの最適化
description: システムと連携して、バッテリー効率の高い方法でバックグラウンド タスクを使用する UWP アプリを作成します。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 932dd3c89933eab9baefe6ff2c45359db6efbb14
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7296869"
---
# <a name="optimize-background-activity"></a>バックグラウンド アクティビティの最適化

ユニバーサル Windows アプリは、すべてのデバイス ファミリで一貫して動作する必要があります。 バッテリー駆動デバイスにおいて、消費電力は、アプリの全体的なユーザー エクスペリエンスを左右する重要な要因です。 バッテリー残量が 1 日中持続する終日バッテリー駆動はすべてのユーザーにとって望ましい機能ですが、それにはデバイスにインストールされているすべてのソフトウェアが効率的に動作する必要があるため、その点を考慮した開発が求められます。 

バックグラウンド タスクの動作は、ほとんどの場合、アプリの合計電力コストを決定する最も重要な要因です。 バックグラウンド タスクとは、アプリを開かずにシステムに登録されるあらゆるプログラムの動作を指します。 詳しくは、「[アウトプロセス バックグラウンド タスクの作成と登録](https://msdn.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)」をご覧ください

## <a name="background-activity-permissions"></a>バックグラウンド アクティビティのアクセス許可

Windows 10 Version 1607 以降を実行するデスクトップ デバイスやモバイル デバイスでは、ユーザーは設定アプリの [バッテリー] セクションにある [アプリによるバッテリーの使用] をクリックして使用率を確認できます。 ここでは、アプリの一覧と各アプリが消費したバッテリー残量の割合 (最後の充電時以降に使用された全バッテリー残量に対する) が表示されます。 この一覧の UWP アプリについては、ユーザーはアプリを選択して、バックグラウンド アクティビティに関連するコントロールを開くことができます。

![アプリによるバッテリーの使用](images/battery-usage-by-app.png)

### <a name="background-permissions-on-mobile"></a>モバイルでのバックグラウンドのアクセス許可

モバイル デバイスでは、ユーザーに対して、そのアプリのバックグラウンド タスクのアクセス許可の設定を指定するラジオ ボタンの一覧が表示されます。 バックグラウンド アクティビティは、[常に許可]、[バックグラウンドで許可しない]、[Windows で管理] のいずれかに設定できます。[Windows で管理] の場合、アプリのバックグラウンド アクティビティは、さまざまな要因に応じて、システムによって規制されます。 

![バックグラウンド タスクのアクセス許可のラジオ ボタン](images/background-task-permissions.png)

### <a name="background-permissions-on-desktop"></a>デスクトップでのバックグラウンドのアクセス許可

デスクトップ デバイスでは、[Windows で管理] の設定はトグル スイッチとして表示され、既定では**オン**に設定されています。 ユーザーが**オフ**に切り替えた場合、バックグラウンド アクティビティのアクセス許可を手動で定義できるチェック ボックスが表示されます。 チェック ボックスをオンにした場合、アプリでバックグラウンド タスクの実行が常に許可されます。 チェック ボックスがオフにした場合、バックグラウンド アクティビティは無効になります。

![バックグラウンド タスクのアクセス許可がオン](images/background-task-permissions-on.png)

![バックグラウンド タスクのアクセス許可がオフ](images/background-task-permissions-off.png)

アプリでは、[**BackgroundExecutionManager.RequestAccessAsync()**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.requestaccessasync.aspx) メソッドの呼び出しによって返される [**BackgroundAccessStatus**](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.background.backgroundaccessstatus) 列挙値で、現在のバックグラウンド アクティビティのアクセス許可の設定を確認できます。

しかし、アプリに信頼できるアクティビティ管理が実装されていない場合、ユーザーはそのアプリに対するバックグラウンドのアクセス許可を一切拒否する可能性があります。このことは、開発者とユーザーの双方にとって望ましいことではありません。 アプリをバックグラウンドで実行するためのアクセス許可が拒否されているときに、ユーザーの操作を完了するためにバックグラウンド アクティビティが必要である場合は、ユーザーに通知し、設定アプリに誘導することができます。 これを行うには、[設定アプリを起動](https://docs.microsoft.com/en-us/windows/uwp/launch-resume/launch-settings-app)して、[バックグラウンド アプリ] ページや [バッテリ使用量の詳細] ページに移動します。

## <a name="work-with-the-battery-saver-feature"></a>バッテリー節約機能の使用
バッテリー節約機能は、ユーザーが設定で構成できるシステム レベルの機能です。 バッテリー レベルがユーザーによって定義されたしきい値を下回った場合、*[常に許可] に設定されたアプリを除いて*、すべてのアプリのバックグラウンド アクティビティが中断されます。

アプリ内からバッテリー節約機能モードの状態を確認するには、[**PowerManager.EnergySaverStatus**](https://docs.microsoft.com/en-us/uwp/api/windows.system.power.energysaverstatus) プロパティを参照します。 これは列挙値で、**EnergySaverStatus.Disabled**、**EnergySaverStatus.Off**、**EnergySaverStatus.On** のいずれかです。 アプリがバックグラウンド アクティビティを必要とし、[常に許可] に設定されていない場合、特定の指定されたバックグラウンド タスクは、バッテリー節約機能がオフになるまで実行されないことをユーザーに通知することにより、**EnergySaverStatus.On** を処理する必要があります。 バックグラウンド アクティビティの管理は、バッテリー節約機能の主要目的ですが、バッテリー節約機能をオンにした場合、アプリはさらに電力を節約するための追加の調整を実行できます。  バッテリー節約機能がオンの場合、アプリは、アニメーションの使用を減らし、位置のポーリングを停止できるほか、同期やバックアップを遅らせることができます。 

## <a name="further-optimize-background-tasks"></a>バックグラウンド タスクのさらなる最適化
バックグラウンド タスクを登録する場合に、さらにバッテリー効率を高めるためのその他の手順を次に示します。

### <a name="use-a-maintenance-trigger"></a>メンテナンス トリガーの使用 
[**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.maintenancetrigger.aspx) オブジェクトを [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.systemtrigger.aspx) オブジェクトの代わりに使用すると、バックグラウンド タスクを開始するタイミングを判断できます。 メンテナンス トリガーを使用するタスクは、デバイスが AC 電源に接続され、長時間実行できる場合のみ実行されます。 使い方については、「[メンテナンス トリガーの使用](https://msdn.microsoft.com/windows/uwp/launch-resume/use-a-maintenance-trigger)」をご覧ください。

### <a name="use-the-backgroundworkcostnothigh-system-condition-type"></a>**BackgroundWorkCostNotHigh** システム条件型の使用
これにより、システム条件が満たされている場合のみバックグラウンド タスクが実行されます (詳しくは、「[バック グラウンド タスクを実行するための条件の設定](https://msdn.microsoft.com/windows/uwp/launch-resume/set-conditions-for-running-a-background-task)」をご覧ください)。 バック グラウンド作業のコストとは、バックグラウンド タスクの実行が消費電力にもたらす*相対的な*影響を示す尺度です。 デバイスが AC 電源に接続されているときに実行されるタスクは、**low**(低。バッテリーへの影響がわずかまたはなし) としてマークされます。 バッテリー電源で稼働していて、画面がオフのときに実行されるタスクは、**high** (高) としてマークされます。そのような場合には、デバイス上でほとんどプログラム アクティビティが行われていないため、バックグラウンド タスクの相対的コストが大きくなります。 バッテリー電源で稼働していて、画面が*オン*のときに実行されるタスクは、**medium** (中) としてマークされます。そのような場合には、おそらく何らかのプログラム アクティビティが既に実行されていて、バックグラウンド タスクはそのエネルギー コストを少し追加する程度であるためです。 **BackgroundWorkCostNotHigh** システム条件は、画面がオンになるか、デバイスが AC 電源に接続されるまで、単純にタスクの実行を遅らせます。

## <a name="test-battery-efficiency"></a>バッテリー効率のテスト

必ず大きな消費電力のシナリオを使って、実際のデバイス上でアプリをテストしてください。 多様なサービス上で、バッテリー節約機能のオンとオフを切り替え、さまざまなネットワーク強度の環境でアプリをテストすることをお勧めします。

## <a name="related-topics"></a>関連トピック

* [アウトプロセス バックグラウンド タスクの作成と登録](https://msdn.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)  
* [パフォーマンスの計画](https://msdn.microsoft.com/windows/uwp/debug-test-perf/planning-and-measuring-performance)  

