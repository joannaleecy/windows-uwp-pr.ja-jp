---
author: TylerMSFT
title: アプリ内からのバックグラウンド タスクのトリガー
description: アプリケーション内からバック グラウンド タスクを開始する方法を説明します。
ms.author: twhitney
ms.date: 07/06/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: バック グラウンド タスク トリガーをバック グラウンド タスク
ms.localizationpriority: medium
ms.openlocfilehash: 5ccd171f53795ef71830ffb022d0468facb3ac4f
ms.sourcegitcommit: 9a17266f208ec415fc718e5254d5b4c08835150c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/28/2018
ms.locfileid: "2882750"
---
# <a name="trigger-a-background-task-from-within-your-app"></a>アプリ内からのバックグラウンド タスクのトリガー

[ApplicationTrigger](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.ApplicationTrigger) を使ってアプリ内からバックグラウンド タスクをアクティブ化する方法について説明します。

アプリケーションをトリガーを作成する方法の例については、次の[例](https://github.com/Microsoft/Windows-universal-samples/blob/v2.0.0/Samples/BackgroundTask/cs/BackgroundTask/Scenario5_ApplicationTriggerTask.xaml.cs)を参照してください。

このトピックでは、アプリケーションからのライセンス認証するバック グラウンド タスクがあることを前提としています。 バック グラウンド タスクを持っていない場合は、サンプルのバック グラウンド タスク[BackgroundActivity.cs です](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/BackgroundActivation/cs/BackgroundActivity.cs)。 または、[登録、プロセスのバック グラウンド タスクを作成および](create-and-register-a-background-task.md)作成する 1 つの手順を実行します。

## <a name="why-use-an-application-trigger"></a>アプリケーションをトリガーを使用する理由

フォア グラウンド アプリから別のプロセスでコードを実行するのを**ApplicationTrigger**を使用します。 **ApplicationTrigger**には、アプリがある場合でも、ユーザーが、前景色アプリを閉じる--バック グラウンドで実行する必要のある作業場合に適しています。 バック グラウンド処理を停止する必要がある場合、アプリが閉じているか[拡張の実行](run-minimized-with-extended-execution.md)を使用する代わりに [フォア グラウンド プロセスの状態に関連付ける必要があります。

## <a name="create-an-application-trigger"></a>アプリケーションをトリガーを作成します。

新しい[ApplicationTrigger](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.ApplicationTrigger)を作成します。 可能性のあるに保存するフィールドを次のコードで行われるようにします。 これは、やすくするためにトリガーを通知するときに、後で新しいインスタンスを作成する必要はありません。 トリガーを通知する**ApplicationTrigger**インスタンスを使用することはできます。

```csharp
// _AppTrigger is an ApplicationTrigger field defined at a scope that will keep it alive
// as long as you need to trigger the background task.
// Or, you could create a new ApplicationTrigger instance and use that when you want to
// trigger the background task.
_AppTrigger = new ApplicationTrigger();
```

```cppwinrt
// _AppTrigger is an ApplicationTrigger field defined at a scope that will keep it alive
// as long as you need to trigger the background task.
// Or, you could create a new ApplicationTrigger instance and use that when you want to
// trigger the background task.
Windows::ApplicationModel::Background::ApplicationTrigger _AppTrigger;
```

```cpp
// _AppTrigger is an ApplicationTrigger field defined at a scope that will keep it alive
// as long as you need to trigger the background task.
// Or, you could create a new ApplicationTrigger instance and use that when you want to
// trigger the background task.
ApplicationTrigger ^ _AppTrigger = ref new ApplicationTrigger();
```

## <a name="optional-add-a-condition"></a>(省略可能) 条件の追加

コントロールにバック グラウンド タスク条件を作成するには、タスクの実行時にします。 条件では、バック グラウンド タスクが、条件が満たされるまで実行できなくなります。 詳細については、[バック グラウンド タスクを実行するための条件を設定する](set-conditions-for-running-a-background-task.md)を参照してください。

タスクには、この例では、条件が**InternetAvailable**一度トリガーされるように設定されて、インターネットに接続が表示されたらがのみ実行できます。 指定できる条件の一覧については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。

```csharp
SystemCondition internetCondition = new SystemCondition(SystemConditionType.InternetAvailable);
```

```cppwinrt
Windows::ApplicationModel::Background::SystemCondition internetCondition{
    Windows::ApplicationModel::Background::SystemConditionType::InternetAvailable };
```

```cpp
SystemCondition ^ internetCondition = ref new SystemCondition(SystemConditionType::InternetAvailable)
```

条件と背景トリガーの種類の詳細の詳細については、[サポート アプリがバック グラウンド タスク](support-your-app-with-background-tasks.md)を参照してください。

##  <a name="call-requestaccessasync"></a>RequestAccessAsync() の呼び出し

**ApplicationTrigger**バック グラウンド タスクを登録するには、前に、バック グラウンドのアクティビティのユーザーがアプリがバック グラウンドのアクティビティを無効にいるために、ユーザーが許可のレベルを決定する[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700494)を呼び出します。 バック グラウンドのアクティビティの設定を制御できる方法ユーザーの詳細については、[最適化バック グラウンドのアクティビティ](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity)を参照してください。

```csharp
var requestStatus = await Windows.ApplicationModel.Background.BackgroundExecutionManager.RequestAccessAsync();
if (requestStatus != BackgroundAccessStatus.AlwaysAllowed)
{
   // Depending on the value of requestStatus, provide an appropriate response
   // such as notifying the user which functionality won't work as expected
}
```

## <a name="register-the-background-task"></a>バックグラウンド タスクの登録

バックグラウンド タスクの登録関数を呼び出してバックグラウンド タスクを登録します。 バック グラウンド タスクを登録して、以下のサンプル コードで**RegisterBackgroundTask()** メソッドの定義を表示する詳細については、[バック グラウンド タスクを登録する](register-a-background-task.md)を参照してください。

フォア グラウンド プロセスの有効期間を拡張するアプリケーション トリガーを使用を検討している場合は、代わりに、[拡張の実行](run-minimized-with-extended-execution.md)を使用することを検討します。 アプリケーション トリガー設計されています個別にホストされているプロセスを作成するため作業を実行します。 次のコードでは、プロセスの背景をトリガーを登録します。

```csharp
string entryPoint = "Tasks.ExampleBackgroundTaskClass";
string taskName   = "Example application trigger";

BackgroundTaskRegistration task = RegisterBackgroundTask(entryPoint, taskName, appTrigger, internetCondition);
```

```cppwinrt
std::wstring entryPoint{ L"Tasks.ExampleBackgroundTaskClass" };
std::wstring taskName{ L"Example application trigger" };

Windows::ApplicationModel::Background::BackgroundTaskRegistration task{
    RegisterBackgroundTask(entryPoint, taskName, appTrigger, internetCondition) };
```

```cpp
String ^ entryPoint = "Tasks.ExampleBackgroundTaskClass";
String ^ taskName   = "Example application trigger";

BackgroundTaskRegistration ^ task = RegisterBackgroundTask(entryPoint, taskName, appTrigger, internetCondition);
```

バックグラウンド タスクの登録パラメーターは登録時に検証されます。 いずれかの登録パラメーターが有効でない場合は、エラーが返されます。 バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。

## <a name="trigger-the-background-task"></a>バック グラウンド タスクを開始します。

バック グラウンド タスクを開始する前に、 [BackgroundTaskRegistration](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.BackgroundTaskRegistration)を使用して、バック グラウンド タスクが登録されていることを確認します。 アプリの起動中には、適切な時間をすべてのバック グラウンド タスクが登録されていることを確認します。

バック グラウンド タスクを開始するには、 [ApplicationTrigger.RequestAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.applicationtrigger)を発信します。 任意の**ApplicationTrigger**インスタンスを実行します。

自体には、バック グラウンド タスクを使用するか、アプリがバック グラウンド実行状態に**ApplicationTrigger.RequestAsync**を呼び出すことができないことに注意してください (アプリケーションの状態の詳細については、[アプリのライフ サイクル](app-lifecycle.md)を参照してください)。
アプリがバック グラウンドのアクティビティを実行するを防ぐエネルギーやプライバシーのポリシーを設定している場合、 [DisabledByPolicy](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.applicationtriggerresult)を返すことがあります。
また、一度に 1 つだけ AppTrigger を実行できます。 別の既に実行中に、AppTrigger を実行しようとすると、関数が[助けます](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.applicationtriggerresult)に戻ります。

```csharp
var result = await _AppTrigger.RequestAsync();
```

## <a name="manage-resources-for-your-background-task"></a>バック グラウンド タスクのリソースを管理します。

[BackgroundExecutionManager.RequestAccessAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) を使用して、アプリのバックグラウンド アクティビティを制限するようにユーザーが設定しているかどうかを確認します。 バッテリー使用量を注意し、ユーザーが望む操作を完了するために必要な場合にのみ、バックグラウンドで実行するようにしてください。 バック グラウンドのアクティビティの設定を制御できる方法ユーザーの詳細については、[最適化バック グラウンドのアクティビティ](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity)を参照してください。  

- メモリ: アプリのメモリとエネルギーの使用を調整、オペレーティング システムがバック グラウンド タスクの実行を許可することを確認するキーです。 [メモリ管理 Api](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx)を使用すると、バック グラウンド タスクを使用しているメモリの量を参照してください。 メモリを増設するバック グラウンド タスクを使用して、ほどの状態に保つが、別のアプリをフォア グラウンドで実行されているオペレーティング システムです。 アプリが実行できるすべてのバックグラウンド アクティビティについて、最終的に管理できるのはユーザーです。また、ユーザーは、アプリがどの程度バッテリー消費に影響しているかを確認できます。  
- CPU 時間: 取得トリガーの種類に基づいて、壁時計使用時間の合計をバック グラウンド タスクが制限されます。 アプリケーション トリガーして表示されるバック グラウンド タスクは、約 10 分しか時間に制限されます。

バックグラウンド タスクに適用されるリソースの制約については、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。

## <a name="remarks"></a>注釈

Windows 10 から始めて、それが不要になったバック グラウンド タスクを利用するために、ロック画面にアプリを追加するユーザーのします。

バック グラウンド タスクは、 [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485)を最初に呼び出さがある場合、 **ApplicationTrigger**を使用してのみ実行されます。

## <a name="related-topics"></a>関連トピック

* [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)
* [バック グラウンド タスクの例](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BackgroundTask)
* [インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)。
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
