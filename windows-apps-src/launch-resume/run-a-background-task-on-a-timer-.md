---
author: TylerMSFT
title: タイマーでのバックグラウンド タスクの実行
description: 1 回限りのバックグラウンド タスクをスケジュールする方法、または定期的なバックグラウンド タスクを実行する方法について説明します。
ms.assetid: 0B7F0BFF-535A-471E-AC87-783C740A61E9
ms.author: twhitney
ms.date: 07/06/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, バック グラウンド タスク
ms.localizationpriority: medium
ms.openlocfilehash: 25e3c76ae09ed6835f89f0d98c308f11c7a99624
ms.sourcegitcommit: 1e5590dd10d606a910da6deb67b6a98f33235959
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/31/2018
ms.locfileid: "3231974"
---
# <a name="run-a-background-task-on-a-timer"></a>タイマーでのバックグラウンド タスクの実行

[**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843)を使用して、1 回限りのバック グラウンド タスクをスケジュールまたは定期的なバック グラウンド タスクを実行する方法について説明します。

このトピックでトリガーのバック グラウンド タスク説明されている時間を実装する方法の例を確認するための[バック グラウンドのアクティブ化のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BackgroundActivation)で**Scenario4**を参照してください。

このトピックでは、定期的に、または特定の時点で実行する必要があるバック グラウンド タスクがあることを前提としています。 バック グラウンド タスクがまだしていない場合、サンプルのバック グラウンド タスクでは[BackgroundActivity.cs です](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/BackgroundActivation/cs/BackgroundActivity.cs)。 または[の作成と登録、インプロセスのバック グラウンド タスク](create-and-register-an-inproc-background-task.md)か[の作成と登録、アウト プロセス バック グラウンド タスク](create-and-register-a-background-task.md)を作成する 1 つの手順に従います。

## <a name="create-a-time-trigger"></a>時刻のトリガーを作る

新しい [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843) を作ります。 2 つ目のパラメーター (*OneShot*) では、バックグラウンド タスクを一度だけ実行するか、または定期的に実行を続けるかを指定します。 *OneShot* を true に設定する場合は、1 つ目のパラメーター (*FreshnessTime*) に、バックグラウンド タスクをスケジュールするまで待機する時間 (分単位) を指定します。 *OneShot* を false に設定する場合は、*FreshnessTime* に、バックグラウンド タスクを実行する間隔を指定します。

デスクトップかモバイル デバイス ファミリを対象とするユニバーサル Windows プラットフォーム (UWP) アプリの組み込みタイマーは、15 分間隔でバックグラウンド タスクを実行します。 (、タイマー実行 15 分間隔で、システムがのみ 15 分ごとに 1 回をスリープ解除電力を節約する - TimerTriggers を要求したアプリをスリープ解除する必要があるようにします。)

- *FreshnessTime* が 15 分に設定され、*OneShot* が true の場合、タスクは登録された時点から 15 ～ 30 分の間に一度実行されるようにスケジュールされます。 これが 25 分に設定され、*OneShot* が true の場合、タスクは登録された時点から 25 ～ 40 分の間に一度実行されるようにスケジュールされます。

- *FreshnessTime* が 15 分に設定され、*OneShot* が false の場合、タスクは登録された時点から 15 ～ 15 分の間に実行され、その後 30 分ごとに実行されるようにスケジュールされます。 これが n 分に設定され、*OneShot* が false の場合、タスクは登録された時点から n ～ n + 15 分の間に実行され、その後 n 分ごとに実行されるようにスケジュールされます。

> [!NOTE]
> *FreshnessTime*は 15 分未満に設定されている場合は、バック グラウンド タスクを登録しようとすると、例外がスローされます。
 
たとえば、このトリガーには、1 時間に 1 回実行するバック グラウンド タスクが発生します。

```cs
TimeTrigger hourlyTrigger = new TimeTrigger(60, false);
```

```cppwinrt
Windows::ApplicationModel::Background::TimeTrigger hourlyTrigger{ 60, false };
```

```cpp
TimeTrigger ^ hourlyTrigger = ref new TimeTrigger(60, false);
```

## <a name="optional-add-a-condition"></a>(省略可能) 条件の追加

タスクが実行されている場合は、コントロールにバック グラウンド タスクの条件を作成できます。 条件によって、バック グラウンド タスクは、条件が満たされるまでを実行できなくなります。 詳しくは、[バック グラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)を参照してください。

この例では、条件が **UserPresent** に設定されているため、トリガー後、ユーザーがアクティブになった場合にタスクが 1 回だけ実行されます。 指定できる条件の一覧については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。

```cs
SystemCondition userCondition = new SystemCondition(SystemConditionType.UserPresent);
```

```cppwinrt
Windows::ApplicationModel::Background::SystemCondition userCondition{
    Windows::ApplicationModel::Background::SystemConditionType::UserPresent };
```

```cpp
SystemCondition ^ userCondition = ref new SystemCondition(SystemConditionType::UserPresent);
```

詳細については条件とバック グラウンド トリガーの種類で、[バック グラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)を参照してください。

##  <a name="call-requestaccessasync"></a>RequestAccessAsync() の呼び出し

**ApplicationTrigger**バック グラウンド タスクを登録する前に、ユーザーは、ユーザーがアプリのバック グラウンド アクティビティを無効にいるため、バック グラウンド アクティビティのレベルを判定[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700494)を呼び出します。 表示方法のユーザーの詳細については、[バック グラウンド アクティビティの最適化](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity)は、バック グラウンド アクティビティの設定を制御できます。

```cs
var requestStatus = await Windows.ApplicationModel.Background.BackgroundExecutionManager.RequestAccessAsync();
if (requestStatus != BackgroundAccessStatus.AlwaysAllowed)
{
    // Depending on the value of requestStatus, provide an appropriate response
    // such as notifying the user which functionality won't work as expected
}
```

## <a name="register-the-background-task"></a>バックグラウンド タスクの登録

バックグラウンド タスクの登録関数を呼び出してバックグラウンド タスクを登録します。 次のサンプル コードで**RegisterBackgroundTask()** メソッドの定義を参照して、バック グラウンド タスクの登録の詳細については、[バック グラウンド タスクの登録](register-a-background-task.md)をご覧ください。

> [!IMPORTANT]
> バック グラウンド タスクは、アプリと同じプロセスで実行されるを設定しない`entryPoint`します。 バック グラウンド タスクをアプリから別のプロセスで実行される、設定`entryPoint`、名前空間 '.' とバック グラウンド タスクの実装を含んだクラスの名前。

```cs
string entryPoint = "Tasks.ExampleBackgroundTaskClass";
string taskName   = "Example hourly background task";

BackgroundTaskRegistration task = RegisterBackgroundTask(entryPoint, taskName, hourlyTrigger, userCondition);
```

```cppwinrt
std::wstring entryPoint{ L"Tasks.ExampleBackgroundTaskClass" };
std::wstring taskName{ L"Example hourly background task" };

Windows::ApplicationModel::Background::BackgroundTaskRegistration task{
    RegisterBackgroundTask(entryPoint, taskName, hourlyTrigger, userCondition) };
```

```cpp
String ^ entryPoint = "Tasks.ExampleBackgroundTaskClass";
String ^ taskName   = "Example hourly background task";

BackgroundTaskRegistration ^ task = RegisterBackgroundTask(entryPoint, taskName, hourlyTrigger, userCondition);
```

バックグラウンド タスクの登録パラメーターは登録時に検証されます。 いずれかの登録パラメーターが有効でない場合は、エラーが返されます。 バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。

## <a name="manage-resources-for-your-background-task"></a>バック グラウンド タスクのリソースを管理します。

[BackgroundExecutionManager.RequestAccessAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) を使用して、アプリのバックグラウンド アクティビティを制限するようにユーザーが設定しているかどうかを確認します。 バッテリー使用量を注意し、ユーザーが望む操作を完了するために必要な場合にのみ、バックグラウンドで実行するようにしてください。 表示方法のユーザーの詳細については、[バック グラウンド アクティビティの最適化](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity)は、バック グラウンド アクティビティの設定を制御できます。

- メモリ: アプリのメモリや電力使用を調整、オペレーティング システムで実行するバック グラウンド タスクを許可することを保証するキーです。 [メモリ管理 Api](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx)を使用すると、バック グラウンド タスクを使用してメモリの量を参照してください。 多くのメモリ、バック グラウンド タスクを使用して、実行中に別のアプリがフォア グラウンドでに保つために、OS がは難しくなります。 アプリが実行できるすべてのバックグラウンド アクティビティについて、最終的に管理できるのはユーザーです。また、ユーザーは、アプリがどの程度バッテリー消費に影響しているかを確認できます。  
- CPU 時間: バック グラウンド タスクがトリガーの種類に基づいて取得するウォールク ロック時間の使用状況の時間の長さによって制限されます。

バックグラウンド タスクに適用されるリソースの制約については、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。

## <a name="remarks"></a>注釈

Windows 10 以降、場合は、ユーザーはロック画面にバック グラウンド タスクを利用するために、アプリを追加する必要なくなりました。

バック グラウンド タスクでは、まず[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485)を呼び出した場合、 **TimeTrigger**を使用してのみ実行されます。

## <a name="related-topics"></a>関連トピック

* [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)
* [バック グラウンド タスクのコード サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BackgroundTask)
* [インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)
* [アウトプロセス バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)
* [バックグラウンド タスクのデバッグ](debug-a-background-task.md)
* [アプリケーション マニフェストでのバックグラウンド タスクの宣言](declare-background-tasks-in-the-application-manifest.md)
* [アプリがバックグラウンドに移動したときのメモリの解放](reduce-memory-usage.md)
* [取り消されたバックグラウンド タスクの処理](handle-a-cancelled-background-task.md)
* [UWP アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)](http://go.microsoft.com/fwlink/p/?linkid=254345)
* [バックグラウンド タスクの進捗状況と完了の監視](monitor-background-task-progress-and-completion.md)
* [延長実行を使ってアプリの中断を延期する](run-minimized-with-extended-execution.md)
* [バックグラウンド タスクの登録](register-a-background-task.md)
* [バックグラウンド タスクによるシステム イベントへの応答](respond-to-system-events-with-background-tasks.md)
* [バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)
* [バックグラウンド タスクのライブ タイルの更新](update-a-live-tile-from-a-background-task.md)
* [メンテナンス トリガーの使用](use-a-maintenance-trigger.md)
