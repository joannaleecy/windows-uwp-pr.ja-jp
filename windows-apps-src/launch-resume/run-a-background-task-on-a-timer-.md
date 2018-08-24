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
keywords: windows 10、uwp、タスクを背景します。
ms.localizationpriority: medium
ms.openlocfilehash: 25e3c76ae09ed6835f89f0d98c308f11c7a99624
ms.sourcegitcommit: c6d6f8b54253e79354f8db14e5cf3b113a3e5014
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/24/2018
ms.locfileid: "2836344"
---
# <a name="run-a-background-task-on-a-timer"></a>タイマーでのバックグラウンド タスクの実行

[**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843)を使用して、1 回限りのバック グラウンド タスクのスケジュールを設定または背景の定期的なタスクを実行する方法について説明します。

このトピックでトリガー付きのバック グラウンド タスクが記載されている時刻を実装する方法の例を確認するための[背景のライセンス認証のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BackgroundActivation)の**Scenario4**を参照してください。

このトピックでは、定期的に、または特定の時間を実行する必要があるバック グラウンド タスクがあると仮定します。 バック グラウンド タスクを持っていない場合は、サンプルのバック グラウンド タスク[BackgroundActivity.cs です](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/BackgroundActivation/cs/BackgroundActivity.cs)。 または、 [register、プロセスのバック グラウンド タスクを作成および](create-and-register-an-inproc-background-task.md)または[登録、プロセスのバック グラウンド タスクを作成および](create-and-register-a-background-task.md)いずれかを作成する手順を実行します。

## <a name="create-a-time-trigger"></a>時刻のトリガーを作る

新しい [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843) を作ります。 2 つ目のパラメーター (*OneShot*) では、バックグラウンド タスクを一度だけ実行するか、または定期的に実行を続けるかを指定します。 *OneShot* を true に設定する場合は、1 つ目のパラメーター (*FreshnessTime*) に、バックグラウンド タスクをスケジュールするまで待機する時間 (分単位) を指定します。 *OneShot* を false に設定する場合は、*FreshnessTime* に、バックグラウンド タスクを実行する間隔を指定します。

デスクトップかモバイル デバイス ファミリを対象とするユニバーサル Windows プラットフォーム (UWP) アプリの組み込みタイマーは、15 分間隔でバックグラウンド タスクを実行します。 (タイマーで実行される 15 分間の間隔をシステムがのみ TimerTriggers - power 保存がリクエストしたアプリを起動する 15 分ごとに 1 回を解除する必要があります。)

- *FreshnessTime* が 15 分に設定され、*OneShot* が true の場合、タスクは登録された時点から 15 ～ 30 分の間に一度実行されるようにスケジュールされます。 これが 25 分に設定され、*OneShot* が true の場合、タスクは登録された時点から 25 ～ 40 分の間に一度実行されるようにスケジュールされます。

- *FreshnessTime* が 15 分に設定され、*OneShot* が false の場合、タスクは登録された時点から 15 ～ 15 分の間に実行され、その後 30 分ごとに実行されるようにスケジュールされます。 これが n 分に設定され、*OneShot* が false の場合、タスクは登録された時点から n ～ n + 15 分の間に実行され、その後 n 分ごとに実行されるようにスケジュールされます。

> [!NOTE]
> *FreshnessTime*は 15 分以内に設定されている場合は、バック グラウンド タスクを登録しようとしたときに例外が発生します。
 
たとえば、このトリガーには、1 時間に 1 回実行するには、バック グラウンド タスクが、します。

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

コントロールにバック グラウンド タスク条件を作成するには、タスクの実行時にします。 条件では、バック グラウンド タスクが、条件が満たされるまで実行できなくなります。 詳細については、[バック グラウンド タスクを実行するための条件を設定する](set-conditions-for-running-a-background-task.md)を参照してください。

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

条件と背景トリガーの種類の詳細の詳細については、[サポート アプリがバック グラウンド タスク](support-your-app-with-background-tasks.md)を参照してください。

##  <a name="call-requestaccessasync"></a>RequestAccessAsync() の呼び出し

**ApplicationTrigger**バック グラウンド タスクを登録するには、前に、バック グラウンドのアクティビティのユーザーがアプリがバック グラウンドのアクティビティを無効にいるために、ユーザーが許可のレベルを決定する[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700494)を呼び出します。 バック グラウンドのアクティビティの設定を制御できる方法ユーザーの詳細については、[最適化バック グラウンドのアクティビティ](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity)を参照してください。

```cs
var requestStatus = await Windows.ApplicationModel.Background.BackgroundExecutionManager.RequestAccessAsync();
if (requestStatus != BackgroundAccessStatus.AlwaysAllowed)
{
    // Depending on the value of requestStatus, provide an appropriate response
    // such as notifying the user which functionality won't work as expected
}
```

## <a name="register-the-background-task"></a>バックグラウンド タスクの登録

バックグラウンド タスクの登録関数を呼び出してバックグラウンド タスクを登録します。 バック グラウンド タスクを登録して、以下のサンプル コードで**RegisterBackgroundTask()** メソッドの定義を表示する詳細については、[バック グラウンド タスクを登録する](register-a-background-task.md)を参照してください。

> [!IMPORTANT]
> バック グラウンド タスクのアプリと同じプロセスで実行されているを設定しない`entryPoint`します。 バック グラウンド タスクを別のプロセスでアプリを実行している、設定`entryPoint`、名前空間 '.' と、バック グラウンド タスクの実装を含むクラスの名前。

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

[BackgroundExecutionManager.RequestAccessAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) を使用して、アプリのバックグラウンド アクティビティを制限するようにユーザーが設定しているかどうかを確認します。 バッテリー使用量を注意し、ユーザーが望む操作を完了するために必要な場合にのみ、バックグラウンドで実行するようにしてください。 バック グラウンドのアクティビティの設定を制御できる方法ユーザーの詳細については、[最適化バック グラウンドのアクティビティ](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity)を参照してください。

- メモリ: アプリのメモリとエネルギーの使用を調整、オペレーティング システムがバック グラウンド タスクの実行を許可することを確認するキーです。 [メモリ管理 Api](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx)を使用すると、バック グラウンド タスクを使用しているメモリの量を参照してください。 メモリを増設するバック グラウンド タスクを使用して、ほどの状態に保つが、別のアプリをフォア グラウンドで実行されているオペレーティング システムです。 アプリが実行できるすべてのバックグラウンド アクティビティについて、最終的に管理できるのはユーザーです。また、ユーザーは、アプリがどの程度バッテリー消費に影響しているかを確認できます。  
- CPU 時間: 取得トリガーの種類に基づいて、壁時計使用時間の合計をバック グラウンド タスクが制限されます。

バックグラウンド タスクに適用されるリソースの制約については、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。

## <a name="remarks"></a>注釈

Windows 10 から始めて、それが不要になったバック グラウンド タスクを利用するために、ロック画面にアプリを追加するユーザーのします。

バック グラウンド タスクは、まず[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485)を呼び出した場合の**TimeTrigger**を使用してのみ実行されます。

## <a name="related-topics"></a>関連トピック

* [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)
* [バック グラウンド タスクの例](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BackgroundTask)
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
