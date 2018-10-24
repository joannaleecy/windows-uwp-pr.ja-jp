---
author: TylerMSFT
title: アプリ内からのバックグラウンド タスクのトリガー
description: アプリケーション内からバック グラウンド タスクをトリガーする方法について説明します。
ms.author: twhitney
ms.date: 07/06/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: バック グラウンド タスク トリガー、バック グラウンド タスク
ms.localizationpriority: medium
ms.openlocfilehash: 5ccd171f53795ef71830ffb022d0468facb3ac4f
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5469862"
---
# <a name="trigger-a-background-task-from-within-your-app"></a>アプリ内からのバックグラウンド タスクのトリガー

[ApplicationTrigger](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.ApplicationTrigger) を使ってアプリ内からバックグラウンド タスクをアクティブ化する方法について説明します。

なアプリケーションのトリガーを作成する方法の例では、次の[例](https://github.com/Microsoft/Windows-universal-samples/blob/v2.0.0/Samples/BackgroundTask/cs/BackgroundTask/Scenario5_ApplicationTriggerTask.xaml.cs)を参照してください。

このトピックでは、アプリケーションからライセンス認証を実行するバック グラウンド タスクがあると想定します。 バック グラウンド タスクがまだしていない場合は、バック グラウンド タスクのサンプルでは[BackgroundActivity.cs です](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/BackgroundActivation/cs/BackgroundActivity.cs)。 または[の作成と登録、アウト プロセス バック グラウンド タスク](create-and-register-a-background-task.md)を作成する 1 つの手順に従います。

## <a name="why-use-an-application-trigger"></a>アプリケーション、トリガーを使用する理由

フォア グラウンド アプリから別のプロセスでコードを実行するのに、 **ApplicationTrigger**を使用します。 **ApplicationTrigger**は、アプリにユーザーがフォア グラウンド アプリを閉じた場合でも、- バック グラウンドで実行する必要がある作業に適しています。 バック グラウンドの作業を停止する必要があるとき、アプリが閉じられたか[延長実行](run-minimized-with-extended-execution.md)を使用して代わりにし、フォア グラウンド プロセスの状態に関連付けられてする必要があります。

## <a name="create-an-application-trigger"></a>なアプリケーションのトリガーを作成します。

新しい[ApplicationTrigger](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.ApplicationTrigger)を作成します。 次のスニペットで実行される、フィールドにそれを格納可能性があります。 これは便利なしますが、トリガーを通知するとき、後で新しいインスタンスを作成する必要があるないようにします。 ただし、トリガーを通知する任意の**ApplicationTrigger**インスタンスを使用することができます。

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

タスクが実行されている場合は、コントロールにバック グラウンド タスクの条件を作成できます。 条件では、バック グラウンド タスクが、条件が満たされるまでを実行できなくなります。 詳細については、[バック グラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)を参照してください。

タスクでは、この例では、条件が**InternetAvailable**に設定されているため、1 回のトリガーでインターネット アクセスが利用可能ながのみ実行できます。 指定できる条件の一覧については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。

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

詳細については条件とバック グラウンド トリガーの種類で、[バック グラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)を参照してください。

##  <a name="call-requestaccessasync"></a>RequestAccessAsync() の呼び出し

**ApplicationTrigger**バック グラウンド タスクを登録する前に、ユーザーは、ユーザーがアプリのバック グラウンド アクティビティを無効にいるため、バック グラウンド アクティビティのレベルを決定する[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700494)を呼び出します。 表示方法のユーザーの詳細については、[バック グラウンド アクティビティの最適化](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity)は、バック グラウンド アクティビティの設定を制御できます。

```csharp
var requestStatus = await Windows.ApplicationModel.Background.BackgroundExecutionManager.RequestAccessAsync();
if (requestStatus != BackgroundAccessStatus.AlwaysAllowed)
{
   // Depending on the value of requestStatus, provide an appropriate response
   // such as notifying the user which functionality won't work as expected
}
```

## <a name="register-the-background-task"></a>バックグラウンド タスクの登録

バックグラウンド タスクの登録関数を呼び出してバックグラウンド タスクを登録します。 詳細については、バック グラウンド タスクの登録にし、次のサンプル コードで**RegisterBackgroundTask()** メソッドの定義を参照する、[バック グラウンド タスクの登録](register-a-background-task.md)を参照してください。

アプリケーション トリガーを使用して、フォア グラウンド プロセスの有効期間を延長するを検討している場合は、代わりに、[延長実行](run-minimized-with-extended-execution.md)を使用することを検討します。 Application Trigger は個別にホストされているプロセスを作成するため作業を実行する設計されています。 次のコード スニペットは、アウト プロセス バック グラウンド トリガーを登録します。

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

## <a name="trigger-the-background-task"></a>バック グラウンド タスクをトリガーします。

バック グラウンド タスクをトリガーする前に、 [BackgroundTaskRegistration](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.BackgroundTaskRegistration)を使用して、バック グラウンド タスクが登録されていることを確認します。 すべてのバック グラウンド タスクが登録されていることを確認する良い機会は、アプリの起動中にです。

[ApplicationTrigger.RequestAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.applicationtrigger)を呼び出すことによって、バック グラウンド タスクをトリガーします。 **ApplicationTrigger**インスタンスが実行されます。

自体には、バック グラウンド タスクから、またはアプリがバック グラウンドの実行状態で**ApplicationTrigger.RequestAsync**を呼び出すことができないことに注意してください (アプリケーションの状態の詳細については、[アプリのライフ サイクル](app-lifecycle.md)をご覧ください)。
[DisabledByPolicy](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.applicationtriggerresult)は、アプリがバック グラウンド アクティビティを実行するを防ぐエネルギーまたはプライバシーのポリシーを設定している場合に返すことがあります。
また、一度に 1 つだけ AppTrigger を実行できます。 別が既に実行されている間に、AppTrigger を実行しようとすると、この関数は[助けます](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.applicationtriggerresult)を返します。

```csharp
var result = await _AppTrigger.RequestAsync();
```

## <a name="manage-resources-for-your-background-task"></a>バック グラウンド タスクのリソースを管理します。

[BackgroundExecutionManager.RequestAccessAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) を使用して、アプリのバックグラウンド アクティビティを制限するようにユーザーが設定しているかどうかを確認します。 バッテリー使用量を注意し、ユーザーが望む操作を完了するために必要な場合にのみ、バックグラウンドで実行するようにしてください。 表示方法のユーザーの詳細については、[バック グラウンド アクティビティの最適化](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity)は、バック グラウンド アクティビティの設定を制御できます。  

- メモリ: アプリのメモリや電力使用を調整、オペレーティング システムで実行するバック グラウンド タスクを許可することを保証するキーです。 [メモリ管理 Api](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx)を使用すると、バック グラウンド タスクを使用してメモリの量を参照してください。 多くのメモリ、バック グラウンド タスクを使用して、状態を維持が、別のアプリをフォア グラウンドで実行されている OS がは難しくなります。 アプリが実行できるすべてのバックグラウンド アクティビティについて、最終的に管理できるのはユーザーです。また、ユーザーは、アプリがどの程度バッテリー消費に影響しているかを確認できます。  
- CPU 時間: バック グラウンド タスクがトリガーの種類に基づいて取得するウォールク ロック時間の使用状況の時間の長さによって制限されます。 Application trigger によってトリガーされるバック グラウンド タスクは、約 10 分間に制限されます。

バックグラウンド タスクに適用されるリソースの制約については、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。

## <a name="remarks"></a>注釈

Windows 10 以降、場合は、バック グラウンド タスクを利用するために、ロック画面にアプリを追加するユーザーのために必要なしなくなった。

バック グラウンド タスクでは、まず[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485)を呼び出した場合、 **ApplicationTrigger**を使用してのみ実行されます。

## <a name="related-topics"></a>関連トピック

* [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)
* [バック グラウンド タスクのコード サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BackgroundTask)
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
