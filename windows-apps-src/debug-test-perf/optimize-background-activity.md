---
author: PatrickFarley
ms.assetid: 24351dad-2ee3-462a-ae78-2752bb3374c2
title: "バッテリー節約機能の利用"
description: "システムと連携して、バッテリー効率の高い方法でバックグラウンド タスクを使用する UWP アプリを作成します。"
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 045dfeb4696a4854b114d88da2a2cbb75d621a58
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="optimize-background-activity"></a>バックグラウンド アクティビティの最適化

ユニバーサル Windows アプリは、すべてのデバイス ファミリで一貫して動作する必要があります。 バッテリー駆動デバイスにおいて、消費電力は、アプリの全体的なユーザー エクスペリエンスを左右する重要な要因です。 バッテリー残量が 1 日中持続する終日バッテリー駆動はすべてのユーザーにとって望ましい機能ですが、それにはデバイスにインストールされているすべてのソフトウェアが効率的に動作する必要があるため、その点を考慮した開発が求められます。 

バックグラウンド タスクの動作は、ほとんどの場合、アプリの合計電力コストを決定する最大の要因です。 バックグラウンド タスクとは、アプリを開かずにシステムに登録されるあらゆるプログラムの動作を指します。 詳しくは、「[アウトプロセス バックグラウンド タスクの作成と登録](https://msdn.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)」をご覧ください

## <a name="background-activity-allowance"></a>バックグラウンド アクティビティの許容量

Windows 10 Version 1607 では、ユーザーは設定アプリの **[バッテリー]** セクションにある [アプリによるバッテリーの使用] をクリックして使用率を確認できます。 ここでは、アプリの一覧と各アプリが消費したバッテリー残量の割合 (最後の充電時以降に使用された全バッテリー残量に対する) が表示されます。 

![アプリによるバッテリーの使用](images/battery-usage-by-app.png)

この一覧の UWPアプリに対して、ユーザーは、システムがバック グラウンド アクティビティを扱う方法をある程度制御できます。 バックグラウンド アクティビティについては、[常に許可]、[Windows で管理] （既定の設定）、または [バックグラウンドで許可しない] （詳細は以下を参照） のいずれかを指定できます。 アプリに許容されているバックグラウンド アクティビティの上限を確認するには、[**BackgroundExecutionManager.RequestAccessAsync()**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.requestaccessasync.aspx) メソッドから返される **BackgroundAccessStatus** 列挙値を使います。

![バックグラウンド タスクのアクセス許可](images/background-task-permissions.png)

しかし、アプリに信頼できるアクティビティ管理が実装されていない場合、ユーザーはそのアプリに対するバックグラウンドのアクセス許可を一切拒否する可能性があります。このことは、開発者とユーザーの双方にとって望ましいことではありません。

## <a name="work-with-the-battery-saver-feature"></a>バッテリー節約機能の使用
バッテリー節約機能は、ユーザーが設定で構成できるシステム レベルの機能です。 バッテリー レベルがユーザーによって定義されたしきい値を下回った場合、*[常に許可] に設定されたアプリを除いて*、すべてのアプリのバックグラウンド アクティビティが中断されます。

アプリが [Windows で管理] に指定されている場合、バッテリー節約機能がオンのときに **BackgroundExecutionManager.RequestAccessAsync()** を呼び出してバックグラウンド アクティビティを登録すると、**DeniedSubjectToSystemPolicy** 値が返されます。 この場合、アプリはユーザーに対し、目的のバックグラウンド タスクは、バッテリー節約機能をオフにし、システムにタスクを再登録するまで実行されないことを通知する必要があります。 バック グラウンド タスクを実行用に登録したが、トリガーの時点でバッテリー節約機能がオンになっている場合、タスクは実行されず、ユーザーには通知されません。 このような事態が発生する可能性を減らすためには、アプリを開くたびにバックグラウンド タスクを再登録するようにアプリをプログラミングすることをお勧めします。

バックグラウンド アクティビティの管理は、バッテリー節約機能の主要目的ですが、バッテリー節約機能をオンにした場合、アプリはさらに電力を節約するための追加の調整を実行できます。 アプリ内からバッテリー節約機能モードの状態を確認するには、[**PowerManager.PowerSavingMode**](https://msdn.microsoft.com/library/windows/apps/windows.phone.system.power.powermanager.powersavingmode.aspx) プロパティを参照します。 このプロパティは、**PowerSavingMode.Off** または **PowerSavingMode.On** のいずれかの列挙値です。 バッテリー節約機能がオンの場合、アプリは、アニメーションの使用を減らし、位置のポーリングを停止できるほか、同期やバックアップを遅らせることができます。 

## <a name="further-optimize-background-tasks"></a>バックグラウンド タスクのさらなる最適化
バックグラウンド タスクを登録する場合に、さらにバッテリー効率を高めるためのその他の手順を次に示します。

メンテナンス トリガーを使います。 [**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.maintenancetrigger.aspx) オブジェクトを [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.systemtrigger.aspx) オブジェクトの代わりに使用すると、バックグラウンド タスクを開始するタイミングを判断できます。 メンテナンス トリガーを使用するタスクは、デバイスが AC 電源に接続され、長時間実行できる場合のみ実行されます。 使い方については、「[メンテナンス トリガーの使用](https://msdn.microsoft.com/windows/uwp/launch-resume/use-a-maintenance-trigger)」をご覧ください。

**BackgroundWorkCostNotHigh** システム条件型を使います。 これにより、システム条件が満たされている場合のみバックグラウンド タスクが実行されます (詳しくは、「[バック グラウンド タスクを実行するための条件の設定](https://msdn.microsoft.com/windows/uwp/launch-resume/set-conditions-for-running-a-background-task)」をご覧ください)。 バック グラウンド作業のコストとは、バックグラウンド タスクの実行が消費電力にもたらす*相対的な*影響を示す尺度です。 デバイスが AC 電源に接続されているときに実行されるタスクは、**low**(低。バッテリーへの影響がわずかまたはなし) としてマークされます。 バッテリー電源で稼働していて、画面がオフのときに実行されるタスクは、**high** (高) としてマークされます。そのような場合には、デバイス上でほとんどプログラム アクティビティが行われていないため、バックグラウンド タスクの相対的コストが大きくなります。 バッテリー電源で稼働していて、画面が*オン*のときに実行されるタスクは、**medium** (中) としてマークされます。そのような場合には、おそらく何らかのプログラム アクティビティが既に実行されていて、バックグラウンド タスクはそのエネルギー コストを少し追加する程度であるためです。 **BackgroundWorkCostNotHigh** システム条件は、画面がオンになるか、デバイスが AC 電源に接続されるまで、単純にタスクの実行を遅らせます。

## <a name="test-battery-efficiency"></a>バッテリー効率のテスト

必ず大きな消費電力のシナリオを使って、実際のデバイス上でアプリをテストしてください。 多様なサービス上で、バッテリー節約機能のオンとオフを切り替え、さまざまなネットワーク強度の環境でアプリをテストすることをお勧めします。

## <a name="related-topics"></a>関連トピック

* [アウトプロセス バックグラウンド タスクの作成と登録](https://msdn.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)  
* [パフォーマンスの計画](https://msdn.microsoft.com/windows/uwp/debug-test-perf/planning-and-measuring-performance)  

