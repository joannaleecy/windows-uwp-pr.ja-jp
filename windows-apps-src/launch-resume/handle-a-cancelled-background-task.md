---
author: TylerMSFT
title: 取り消されたバックグラウンド タスクの処理
description: 取り消し要求を認識し、作業を停止して、固定ストレージを使っているアプリの取り消しを報告するバックグラウンド タスクの作成方法について説明します。
ms.assetid: B7E23072-F7B0-4567-985B-737DD2A8728E
ms.author: twhitney
ms.date: 07/05/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: バック グラウンド タスクの windows 10, uwp,
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
ms.openlocfilehash: 2c78f5f43d93002b90902a7f9e5a943c7239946c
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4020600"
---
# <a name="handle-a-cancelled-background-task"></a>取り消されたバックグラウンド タスクの処理

**重要な API**

-   [**BackgroundTaskCanceledEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224775)
-   [**IBackgroundTaskInstance**](https://msdn.microsoft.com/library/windows/apps/br224797)
-   [**ApplicationData.Current**](https://msdn.microsoft.com/library/windows/apps/br241619)

取り消し要求を認識し、作業を停止して、固定ストレージを使っているアプリに取り消しを報告するバックグラウンド タスクの作成方法について説明します。

このトピックでは、既にバック グラウンド タスクのエントリ ポイントとして使用される**実行**メソッドも含めて、バック グラウンド タスク クラスを作成するいると想定します。 バックグラウンド タスクの作成方法の概要については、「[アウトプロセス バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)」または「[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)」をご覧ください。 条件とトリガーについて詳しくは、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。

このトピックは、インプロセス バックグラウンド タスクにも適用されます。 ただし、 **Run**メソッドではなく**OnBackgroundActivated**。 インプロセス バックグラウンド タスクでは、バックグラウンド タスクがフォアグラウンド アプリと同じプロセスで実行されているため、取り消しを通知するために固定ストレージを使用する必要はありません。アプリの状態を使用して、取り消しを伝えることができます。

## <a name="use-the-oncanceled-method-to-recognize-cancellation-requests"></a>OnCanceled メソッドにより、取り消し要求を認識します。

取り消しイベントを処理するメソッドを作ります。

> [!NOTE]
> デスクトップ以外のすべてのデバイス ファミリでは、デバイスのメモリが少なくなった場合、バックグラウンド タスクが終了することがあります。 場合は、メモリ不足の例外はされないか、アプリが処理されない、後に警告と OnCanceled イベントの発生せず、バック グラウンド タスクが終了されます。 こうすることで、フォアグラウンドのアプリのユーザー エクスペリエンスが保証されます。 バックグラウンド タスクは、このシナリオを処理できるように設計する必要があります。

次のように **OnCanceled** という名前のメソッドを作成します。 このメソッドは、バックグラウンド タスクに対して取り消し要求が出されると、Windows ランタイムによって呼び出されるエントリ ポイントです。

```csharp
private void OnCanceled(
    IBackgroundTaskInstance sender,
    BackgroundTaskCancellationReason reason)
{
    // TODO: Add code to notify the background task that it is cancelled.
}
```

```cppwinrt
void ExampleBackgroundTask::OnCanceled(
    Windows::ApplicationModel::Background::IBackgroundTaskInstance const& taskInstance,
    Windows::ApplicationModel::Background::BackgroundTaskCancellationReason reason)
{
    // TODO: Add code to notify the background task that it is cancelled.
}
```

```cpp
void ExampleBackgroundTask::OnCanceled(
    IBackgroundTaskInstance^ taskInstance,
    BackgroundTaskCancellationReason reason)
{
    // TODO: Add code to notify the background task that it is cancelled.
}
```

バックグラウンド タスク クラスに **\_CancelRequested** というフラグ変数を追加します。 この変数は、取り消し要求が出されたことを示すために使います。

```csharp
volatile bool _CancelRequested = false;
```

```cppwinrt
private:
    volatile bool m_cancelRequested;
```

```cpp
private:
    volatile bool CancelRequested;
```

手順 1 で作成した**OnCanceled**メソッドでフラグ変数**\_CancelRequested**を**true**に設定します。

完全な[バック グラウンド タスクのサンプル]( http://go.microsoft.com/fwlink/p/?linkid=227509) **OnCanceled**メソッドでは、 **\_CancelRequested**を**true**に設定し、可能性のある有用なデバッグ出力に書き込みます。

```csharp
private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
{
    // Indicate that the background task is canceled.
    _cancelRequested = true;

    Debug.WriteLine("Background " + sender.Task.Name + " Cancel Requested...");
}
```

```cppwinrt
void ExampleBackgroundTask::OnCanceled(
    Windows::ApplicationModel::Background::IBackgroundTaskInstance const& taskInstance,
    Windows::ApplicationModel::Background::BackgroundTaskCancellationReason reason)
{
    // Indicate that the background task is canceled.
    m_cancelRequested = true;
}
```

```cpp
void ExampleBackgroundTask::OnCanceled(IBackgroundTaskInstance^ taskInstance, BackgroundTaskCancellationReason reason)
{
    // Indicate that the background task is canceled.
    CancelRequested = true;
}
```

バック グラウンド タスクの**Run**メソッドでは、作業を開始する前に**OnCanceled**イベント ハンドラー メソッドを登録します。 インプロセス バックグラウンド タスクでは、アプリケーションの初期化の一部としてこの登録を実行できます。 たとえば、次のコード行を使用します。

```csharp
taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);
```

```cppwinrt
taskInstance.Canceled({ this, &ExampleBackgroundTask::OnCanceled });
```

```cpp
taskInstance->Canceled += ref new BackgroundTaskCanceledEventHandler(this, &ExampleBackgroundTask::OnCanceled);
```

## <a name="handle-cancellation-by-exiting-your-background-task"></a>バックグラウンド タスクを終了することによって、取り消しを処理します。

バックグラウンド処理を実行しているメソッドは、**\_cancelRequested** が **true** に設定されたタイミングを認識し、処理を停止して終了する必要があります。 インプロセス バック グラウンド タスクの場合、 **OnBackgroundActivated**メソッドから戻ることを意味します。 アウト プロセス バック グラウンド タスクの場合、 **Run**メソッドから戻ることを意味します。

バックグラウンド タスク クラスの処理中にフラグ変数を確認するようにコードを変更します。 **\_CancelRequested**になる続行 true に設定場合します。

[バック グラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)では、バック グラウンド タスクが取り消された場合、定期タイマーのコールバックを停止することを確認するが含まれます。

```csharp
if ((_cancelRequested == false) && (_progress < 100))
{
    _progress += 10;
    _taskInstance.Progress = _progress;
}
else
{
    _periodicTimer.Cancel();
    // TODO: Record whether the task completed or was cancelled.
}
```

```cppwinrt
if (!m_cancelRequested && m_progress < 100)
{
    m_progress += 10;
    m_taskInstance.Progress(m_progress);
}
else
{
    m_periodicTimer.Cancel();
    // TODO: Record whether the task completed or was cancelled.
}
```

```cpp
if ((CancelRequested == false) && (Progress < 100))
{
    Progress += 10;
    TaskInstance->Progress = Progress;
}
else
{
    PeriodicTimer->Cancel();
    // TODO: Record whether the task completed or was cancelled.
}
```

> [!NOTE]
> 上記のコード サンプルでは、 [**IBackgroundTaskInstance**](https://msdn.microsoft.com/library/windows/apps/br224797)を使用します。[**進行状況**](https://msdn.microsoft.com/library/windows/apps/br224800)のプロパティがバック グラウンド タスクの進捗状況を記録するために使用されています。 進行状況は、[**BackgroundTaskProgressEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224782) クラスを使ってアプリに報告されます。

**Run**メソッドは、処理が停止した後、タスクが完了したか、取り消されたかどうかを記録するように変更します。 この手順は、バックグラウンド タスクが取り消されたときにプロセス間で通信する手段が必要となるため、別のプロセスで実行されるアウトプロセス バック グラウンド タスクに適用されます。 インプロセス バックグラウンド タスクでは、タスクが取り消されたことを示すために、状態をアプリケーションと共有するだけで十分です。

[バック グラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)では、LocalSettings に状態を記録します。

```csharp
if ((_cancelRequested == false) && (_progress < 100))
{
    _progress += 10;
    _taskInstance.Progress = _progress;
}
else
{
    _periodicTimer.Cancel();

    var settings = ApplicationData.Current.LocalSettings;
    var key = _taskInstance.Task.TaskId.ToString();

    // Write to LocalSettings to indicate that this background task ran.
    if (_cancelRequested)
    {
        settings.Values[key] = "Canceled";
    }
    else
    {
        settings.Values[key] = "Completed";
    }
        
    Debug.WriteLine("Background " + _taskInstance.Task.Name + (_cancelRequested ? " Canceled" : " Completed"));
        
    // Indicate that the background task has completed.
    _deferral.Complete();
}
```

```cppwinrt
if (!m_cancelRequested && m_progress < 100)
{
    m_progress += 10;
    m_taskInstance.Progress(m_progress);
}
else
{
    m_periodicTimer.Cancel();

    // Write to LocalSettings to indicate that this background task ran.
    auto settings{ Windows::Storage::ApplicationData::Current().LocalSettings() };
    auto key{ m_taskInstance.Task().Name() };
    settings.Values().Insert(key, (m_progress < 100) ? winrt::box_value(L"Canceled") : winrt::box_value(L"Completed"));

    // Indicate that the background task has completed.
    m_deferral.Complete();
}
```

```cpp
if ((CancelRequested == false) && (Progress < 100))
{
    Progress += 10;
    TaskInstance->Progress = Progress;
}
else
{
    PeriodicTimer->Cancel();
        
    // Write to LocalSettings to indicate that this background task ran.
    auto settings = ApplicationData::Current->LocalSettings;
    auto key = TaskInstance->Task->Name;
    settings->Values->Insert(key, (Progress < 100) ? "Canceled" : "Completed");
        
    // Indicate that the background task has completed.
    Deferral->Complete();
}
```

## <a name="remarks"></a>注釈

[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)をダウンロードして、メソッドのコンテキストに従ってコード例を確認できます。

説明のためのサンプル コードは、[バック グラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)からの**Run**メソッド (およびコールバック タイマー) の部分だけを示しています。

## <a name="run-method-example"></a>メソッド例を実行します。

**Run**メソッドとタイマーのコールバック コード一式、[バック グラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)から次のとおりのコンテキストにします。

```csharp
// The Run method is the entry point of a background task.
public void Run(IBackgroundTaskInstance taskInstance)
{
    Debug.WriteLine("Background " + taskInstance.Task.Name + " Starting...");

    // Query BackgroundWorkCost
    // Guidance: If BackgroundWorkCost is high, then perform only the minimum amount
    // of work in the background task and return immediately.
    var cost = BackgroundWorkCost.CurrentBackgroundWorkCost;
    var settings = ApplicationData.Current.LocalSettings;
    settings.Values["BackgroundWorkCost"] = cost.ToString();

    // Associate a cancellation handler with the background task.
    taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);

    // Get the deferral object from the task instance, and take a reference to the taskInstance;
    _deferral = taskInstance.GetDeferral();
    _taskInstance = taskInstance;

    _periodicTimer = ThreadPoolTimer.CreatePeriodicTimer(new TimerElapsedHandler(PeriodicTimerCallback), TimeSpan.FromSeconds(1));
}

// Simulate the background task activity.
private void PeriodicTimerCallback(ThreadPoolTimer timer)
{
    if ((_cancelRequested == false) && (_progress < 100))
    {
        _progress += 10;
        _taskInstance.Progress = _progress;
    }
    else
    {
        _periodicTimer.Cancel();

        var settings = ApplicationData.Current.LocalSettings;
        var key = _taskInstance.Task.Name;

        // Write to LocalSettings to indicate that this background task ran.
        settings.Values[key] = (_progress < 100) ? "Canceled with reason: " + _cancelReason.ToString() : "Completed";
        Debug.WriteLine("Background " + _taskInstance.Task.Name + settings.Values[key]);

        // Indicate that the background task has completed.
        _deferral.Complete();
    }
}
```

```cppwinrt
void ExampleBackgroundTask::Run(Windows::ApplicationModel::Background::IBackgroundTaskInstance const& taskInstance)
{
    // Query BackgroundWorkCost
    // Guidance: If BackgroundWorkCost is high, then perform only the minimum amount
    // of work in the background task and return immediately.
    auto cost{ Windows::ApplicationModel::Background::BackgroundWorkCost::CurrentBackgroundWorkCost() };
    auto settings{ Windows::Storage::ApplicationData::Current().LocalSettings() };
    std::wstring costAsString{ L"Low" };
    if (cost == Windows::ApplicationModel::Background::BackgroundWorkCostValue::Medium) costAsString = L"Medium";
    else if (cost == Windows::ApplicationModel::Background::BackgroundWorkCostValue::High) costAsString = L"High";
    settings.Values().Insert(L"BackgroundWorkCost", winrt::box_value(costAsString));

    // Associate a cancellation handler with the background task.
    taskInstance.Canceled({ this, &ExampleBackgroundTask::OnCanceled });

    // Get the deferral object from the task instance, and take a reference to the taskInstance.
    m_deferral = taskInstance.GetDeferral();
    m_taskInstance = taskInstance;

    Windows::Foundation::TimeSpan period{ std::chrono::seconds{1} };
    m_periodicTimer = Windows::System::Threading::ThreadPoolTimer::CreatePeriodicTimer([this](Windows::System::Threading::ThreadPoolTimer timer)
    {
        if (!m_cancelRequested && m_progress < 100)
        {
            m_progress += 10;
            m_taskInstance.Progress(m_progress);
        }
        else
        {
            m_periodicTimer.Cancel();

            // Write to LocalSettings to indicate that this background task ran.
            auto settings{ Windows::Storage::ApplicationData::Current().LocalSettings() };
            auto key{ m_taskInstance.Task().Name() };
            settings.Values().Insert(key, (m_progress < 100) ? winrt::box_value(L"Canceled") : winrt::box_value(L"Completed"));

            // Indicate that the background task has completed.
            m_deferral.Complete();
        }
    }, period);
}
```

```cpp
void ExampleBackgroundTask::Run(IBackgroundTaskInstance^ taskInstance)
{
    // Query BackgroundWorkCost
    // Guidance: If BackgroundWorkCost is high, then perform only the minimum amount
    // of work in the background task and return immediately.
    auto cost = BackgroundWorkCost::CurrentBackgroundWorkCost;
    auto settings = ApplicationData::Current->LocalSettings;
    settings->Values->Insert("BackgroundWorkCost", cost.ToString());

    // Associate a cancellation handler with the background task.
    taskInstance->Canceled += ref new BackgroundTaskCanceledEventHandler(this, &ExampleBackgroundTask::OnCanceled);

    // Get the deferral object from the task instance, and take a reference to the taskInstance.
    TaskDeferral = taskInstance->GetDeferral();
    TaskInstance = taskInstance;

    auto timerDelegate = [this](ThreadPoolTimer^ timer)
    {
        if ((CancelRequested == false) &&
            (Progress < 100))
        {
            Progress += 10;
            TaskInstance->Progress = Progress;
        }
        else
        {
            PeriodicTimer->Cancel();

            // Write to LocalSettings to indicate that this background task ran.
            auto settings = ApplicationData::Current->LocalSettings;
            auto key = TaskInstance->Task->Name;
            settings->Values->Insert(key, (Progress < 100) ? "Canceled with reason: " + CancelReason.ToString() : "Completed");

            // Indicate that the background task has completed.
            TaskDeferral->Complete();
        }
    };

    TimeSpan period;
    period.Duration = 1000 * 10000; // 1 second
    PeriodicTimer = ThreadPoolTimer::CreatePeriodicTimer(ref new TimerElapsedHandler(timerDelegate), period);
}
```

## <a name="related-topics"></a>関連トピック

- [インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)。
- [アウトプロセス バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)
- [アプリケーション マニフェストでのバックグラウンド タスクの宣言](declare-background-tasks-in-the-application-manifest.md)
- [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)
- [バックグラウンド タスクの進捗状況と完了の監視](monitor-background-task-progress-and-completion.md)
- [バックグラウンド タスクの登録](register-a-background-task.md)
- [バックグラウンド タスクによるシステム イベントへの応答](respond-to-system-events-with-background-tasks.md)
- [タイマーでのバックグラウンド タスクの実行](run-a-background-task-on-a-timer-.md)
- [バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)
- [バックグラウンド タスクのライブ タイルの更新](update-a-live-tile-from-a-background-task.md)
- [メンテナンス トリガーの使用](use-a-maintenance-trigger.md)
- [バックグラウンド タスクのデバッグ](debug-a-background-task.md)
- [UWP アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)](http://go.microsoft.com/fwlink/p/?linkid=254345)
