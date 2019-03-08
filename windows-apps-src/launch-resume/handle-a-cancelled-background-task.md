---
title: 取り消されたバックグラウンド タスクの処理
description: 取り消し要求を認識し、作業を停止して、固定ストレージを使っているアプリの取り消しを報告するバックグラウンド タスクの作成方法について説明します。
ms.assetid: B7E23072-F7B0-4567-985B-737DD2A8728E
ms.date: 07/05/2018
ms.topic: article
keywords: windows 10、uwp、バック グラウンド タスク
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
ms.openlocfilehash: 1feffac4d9b616c2fadff0080c3282e4200f3be7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57625577"
---
# <a name="handle-a-cancelled-background-task"></a><span data-ttu-id="78436-104">取り消されたバックグラウンド タスクの処理</span><span class="sxs-lookup"><span data-stu-id="78436-104">Handle a cancelled background task</span></span>

<span data-ttu-id="78436-105">**重要な API**</span><span class="sxs-lookup"><span data-stu-id="78436-105">**Important APIs**</span></span>

-   [<span data-ttu-id="78436-106">**BackgroundTaskCanceledEventHandler**</span><span class="sxs-lookup"><span data-stu-id="78436-106">**BackgroundTaskCanceledEventHandler**</span></span>](https://msdn.microsoft.com/library/windows/apps/br224775)
-   [<span data-ttu-id="78436-107">**IBackgroundTaskInstance**</span><span class="sxs-lookup"><span data-stu-id="78436-107">**IBackgroundTaskInstance**</span></span>](https://msdn.microsoft.com/library/windows/apps/br224797)
-   [<span data-ttu-id="78436-108">**ApplicationData.Current**</span><span class="sxs-lookup"><span data-stu-id="78436-108">**ApplicationData.Current**</span></span>](https://msdn.microsoft.com/library/windows/apps/br241619)

<span data-ttu-id="78436-109">取り消し要求を認識し、作業を停止して、固定ストレージを使っているアプリに取り消しを報告するバックグラウンド タスクの作成方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="78436-109">Learn how to make a background task that recognizes a cancellation request, stops work, and reports the cancellation to the app using persistent storage.</span></span>

<span data-ttu-id="78436-110">このトピックでは、バック グラウンド タスク クラスでは、既に作成している前提としています。 など、**実行**バック グラウンド タスクのエントリ ポイントとして使用されるメソッド。</span><span class="sxs-lookup"><span data-stu-id="78436-110">This topic assumes you have already created a background task class, including the **Run** method that is used as the background task entry point.</span></span> <span data-ttu-id="78436-111">バックグラウンド タスクの作成方法の概要については、「[アウトプロセス バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)」または「[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="78436-111">To get started quickly building a background task, see [Create and register an out-of-process background task](create-and-register-a-background-task.md) or [Create and register an in-process background task](create-and-register-an-inproc-background-task.md).</span></span> <span data-ttu-id="78436-112">条件とトリガーについて詳しくは、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="78436-112">For more in-depth information on conditions and triggers, see [Support your app with background tasks](support-your-app-with-background-tasks.md).</span></span>

<span data-ttu-id="78436-113">このトピックは、インプロセス バックグラウンド タスクにも適用されます。</span><span class="sxs-lookup"><span data-stu-id="78436-113">This topic is also applicable to in-process background tasks.</span></span> <span data-ttu-id="78436-114">代わりに、**実行**メソッドは、代替**OnBackgroundActivated**します。</span><span class="sxs-lookup"><span data-stu-id="78436-114">But instead of the **Run** method, substitute **OnBackgroundActivated**.</span></span> <span data-ttu-id="78436-115">インプロセス バックグラウンド タスクでは、バックグラウンド タスクがフォアグラウンド アプリと同じプロセスで実行されているため、取り消しを通知するために固定ストレージを使用する必要はありません。アプリの状態を使用して、取り消しを伝えることができます。</span><span class="sxs-lookup"><span data-stu-id="78436-115">In-process background tasks do not require you to use persistent storage to signal the cancellation because you can communicate the cancellation using app state since the background task is running in the same process as your foreground app.</span></span>

## <a name="use-the-oncanceled-method-to-recognize-cancellation-requests"></a><span data-ttu-id="78436-116">OnCanceled メソッドにより、取り消し要求を認識します。</span><span class="sxs-lookup"><span data-stu-id="78436-116">Use the OnCanceled method to recognize cancellation requests</span></span>

<span data-ttu-id="78436-117">取り消しイベントを処理するメソッドを作ります。</span><span class="sxs-lookup"><span data-stu-id="78436-117">Write a method to handle the cancellation event.</span></span>

> [!NOTE]
> <span data-ttu-id="78436-118">デスクトップ以外のすべてのデバイス ファミリでは、デバイスのメモリが少なくなった場合、バックグラウンド タスクが終了することがあります。</span><span class="sxs-lookup"><span data-stu-id="78436-118">For all device families except desktop, if the device becomes low on memory, background tasks may be terminated.</span></span> <span data-ttu-id="78436-119">場合は、メモリ不足の例外は表示されませんが、またはアプリ警告と OnCanceled イベントを発生させることがなく、バック グラウンド タスクが終了し、処理されにありません。</span><span class="sxs-lookup"><span data-stu-id="78436-119">If an out of memory exception is not surfaced, or the app doesn't handle it, then the background task will be terminated without warning and without raising the OnCanceled event.</span></span> <span data-ttu-id="78436-120">こうすることで、フォアグラウンドのアプリのユーザー エクスペリエンスが保証されます。</span><span class="sxs-lookup"><span data-stu-id="78436-120">This helps to ensure the user experience of the app in the foreground.</span></span> <span data-ttu-id="78436-121">バックグラウンド タスクは、このシナリオを処理できるように設計する必要があります。</span><span class="sxs-lookup"><span data-stu-id="78436-121">Your background task should be designed to handle this scenario.</span></span>

<span data-ttu-id="78436-122">次のように **OnCanceled** という名前のメソッドを作成します。</span><span class="sxs-lookup"><span data-stu-id="78436-122">Create a method named **OnCanceled** as follows.</span></span> <span data-ttu-id="78436-123">このメソッドは、バックグラウンド タスクに対して取り消し要求が出されると、Windows ランタイムによって呼び出されるエントリ ポイントです。</span><span class="sxs-lookup"><span data-stu-id="78436-123">This method is the entry point called by the Windows Runtime when a cancellation request is made against your background task.</span></span>

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

<span data-ttu-id="78436-124">というフラグ変数を追加 **\_CancelRequested**をバック グラウンド タスク クラスにします。</span><span class="sxs-lookup"><span data-stu-id="78436-124">Add a flag variable called **\_CancelRequested** to the background task class.</span></span> <span data-ttu-id="78436-125">この変数は、いつ取り消し要求が出されたかを示すために使います。</span><span class="sxs-lookup"><span data-stu-id="78436-125">This variable will be used to indicate when a cancellation request has been made.</span></span>

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

<span data-ttu-id="78436-126">**OnCanceled**フラグ変数を設定するメソッドは、手順 1. で作成した **\_CancelRequested**に**true**します。</span><span class="sxs-lookup"><span data-stu-id="78436-126">In the **OnCanceled** method you created in step 1, set the flag variable **\_CancelRequested** to **true**.</span></span>

<span data-ttu-id="78436-127">完全な[バック グラウンド タスクのサンプル]( https://go.microsoft.com/fwlink/p/?linkid=227509) **OnCanceled**メソッド セット **\_CancelRequested**に**true**書き込みます役立つ可能性のあるデバッグ出力します。</span><span class="sxs-lookup"><span data-stu-id="78436-127">The full [background task sample]( https://go.microsoft.com/fwlink/p/?linkid=227509) **OnCanceled** method sets **\_CancelRequested** to **true** and writes potentially useful debug output.</span></span>

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

<span data-ttu-id="78436-128">バック グラウンド タスクの**実行**メソッド、レジスタ、 **OnCanceled**作業を開始する前にイベント ハンドラー メソッド。</span><span class="sxs-lookup"><span data-stu-id="78436-128">In the background task's **Run** method, register the **OnCanceled** event handler method before starting work.</span></span> <span data-ttu-id="78436-129">インプロセス バックグラウンド タスクでは、アプリケーションの初期化の一部としてこの登録を実行できます。</span><span class="sxs-lookup"><span data-stu-id="78436-129">In an in-process background task, you might do this registration as part of your application initialization.</span></span> <span data-ttu-id="78436-130">たとえば、次のコード行を使用します。</span><span class="sxs-lookup"><span data-stu-id="78436-130">For example, use the following line of code.</span></span>

```csharp
taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);
```

```cppwinrt
taskInstance.Canceled({ this, &ExampleBackgroundTask::OnCanceled });
```

```cpp
taskInstance->Canceled += ref new BackgroundTaskCanceledEventHandler(this, &ExampleBackgroundTask::OnCanceled);
```

## <a name="handle-cancellation-by-exiting-your-background-task"></a><span data-ttu-id="78436-131">バックグラウンド タスクを終了することによって、取り消しを処理します。</span><span class="sxs-lookup"><span data-stu-id="78436-131">Handle cancellation by exiting your background task</span></span>

<span data-ttu-id="78436-132">バック グラウンド作業をメソッドが作業を停止し、ときに認識することで終了する必要があります、キャンセル要求が受信されると、  **\_cancelRequested**に設定されている**true**します。</span><span class="sxs-lookup"><span data-stu-id="78436-132">When a cancellation request is received, your method that does background work needs to stop work and exit by recognizing when **\_cancelRequested** is set to **true**.</span></span> <span data-ttu-id="78436-133">プロセス内のバック グラウンド タスクでは、これにはから返すことは意味、 **OnBackgroundActivated**メソッド。</span><span class="sxs-lookup"><span data-stu-id="78436-133">For in-process background tasks, this means returning from the **OnBackgroundActivated** method.</span></span> <span data-ttu-id="78436-134">プロセス外のバック グラウンド タスクでは、これにはから返すことは意味、**実行**メソッド。</span><span class="sxs-lookup"><span data-stu-id="78436-134">For out-of-process background tasks, this means returning from the **Run** method.</span></span>

<span data-ttu-id="78436-135">バックグラウンド タスク クラスの処理中にフラグ変数を確認するようにコードを変更します。</span><span class="sxs-lookup"><span data-stu-id="78436-135">Modify the code of your background task class to check the flag variable while it's working.</span></span> <span data-ttu-id="78436-136">場合 **\_cancelRequested**は続行されません作業は終了します。 true に設定になります。</span><span class="sxs-lookup"><span data-stu-id="78436-136">If **\_cancelRequested** becomes set to true, stop work from continuing.</span></span>

<span data-ttu-id="78436-137">[バック グラウンド タスクのサンプル](https://go.microsoft.com/fwlink/p/?LinkId=618666)バック グラウンド タスクが取り消された場合は、定期的なタイマー コールバックを停止するチェックが含まれています。</span><span class="sxs-lookup"><span data-stu-id="78436-137">The [background task sample](https://go.microsoft.com/fwlink/p/?LinkId=618666) includes a check that stops the periodic timer callback if the background task is canceled.</span></span>

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
> <span data-ttu-id="78436-138">使用前に示したコード サンプル、 [ **IBackgroundTaskInstance**](https://msdn.microsoft.com/library/windows/apps/br224797).[**進行状況**](https://msdn.microsoft.com/library/windows/apps/br224800)バック グラウンド タスクの進行状況を記録するために使用されるプロパティ。</span><span class="sxs-lookup"><span data-stu-id="78436-138">The code sample shown above uses the [**IBackgroundTaskInstance**](https://msdn.microsoft.com/library/windows/apps/br224797).[**Progress**](https://msdn.microsoft.com/library/windows/apps/br224800) property being used to record background task progress.</span></span> <span data-ttu-id="78436-139">進行状況は、[**BackgroundTaskProgressEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224782) クラスを使ってアプリに報告されます。</span><span class="sxs-lookup"><span data-stu-id="78436-139">Progress is reported back to the app using the [**BackgroundTaskProgressEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224782) class.</span></span>

<span data-ttu-id="78436-140">変更、**実行**タスクが完了または取り消されたかどうかを記録、メソッド、その後の処理が停止しました。</span><span class="sxs-lookup"><span data-stu-id="78436-140">Modify the **Run** method so that after work has stopped, it records whether the task completed or was cancelled.</span></span> <span data-ttu-id="78436-141">この手順は、バックグラウンド タスクが取り消されたときにプロセス間で通信する手段が必要となるため、別のプロセスで実行されるアウトプロセス バック グラウンド タスクに適用されます。</span><span class="sxs-lookup"><span data-stu-id="78436-141">This step applies to out-of-process background tasks because you need a way to communicate between processes when the background task was cancelled.</span></span> <span data-ttu-id="78436-142">インプロセス バックグラウンド タスクでは、タスクが取り消されたことを示すために、状態をアプリケーションと共有するだけで十分です。</span><span class="sxs-lookup"><span data-stu-id="78436-142">For in-process background tasks, you can simply share state with the application to indicate the task was cancelled.</span></span>

<span data-ttu-id="78436-143">[バック グラウンド タスクのサンプル](https://go.microsoft.com/fwlink/p/?LinkId=618666)LocalSettings で状態を記録します。</span><span class="sxs-lookup"><span data-stu-id="78436-143">The [background task sample](https://go.microsoft.com/fwlink/p/?LinkId=618666) records status in LocalSettings.</span></span>

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

## <a name="remarks"></a><span data-ttu-id="78436-144">注釈</span><span class="sxs-lookup"><span data-stu-id="78436-144">Remarks</span></span>

<span data-ttu-id="78436-145">[バックグラウンド タスクのサンプル](https://go.microsoft.com/fwlink/p/?LinkId=618666)をダウンロードして、メソッドのコンテキストに従ってコード例を確認できます。</span><span class="sxs-lookup"><span data-stu-id="78436-145">You can download the [background task sample](https://go.microsoft.com/fwlink/p/?LinkId=618666) to see these code examples in the context of methods.</span></span>

<span data-ttu-id="78436-146">サンプル コードは、例示を目的としての部分のみを示しています、**実行**メソッド (およびコールバック タイマー) から、[バック グラウンド タスクのサンプル](https://go.microsoft.com/fwlink/p/?LinkId=618666)します。</span><span class="sxs-lookup"><span data-stu-id="78436-146">For illustrative purposes, the sample code shows only portions of the **Run** method (and callback timer) from the [background task sample](https://go.microsoft.com/fwlink/p/?LinkId=618666).</span></span>

## <a name="run-method-example"></a><span data-ttu-id="78436-147">メソッド例を実行します。</span><span class="sxs-lookup"><span data-stu-id="78436-147">Run method example</span></span>

<span data-ttu-id="78436-148">完全な**実行**メソッド、およびタイマーのコールバック コードから、[バック グラウンド タスクのサンプル](https://go.microsoft.com/fwlink/p/?LinkId=618666)コンテキストを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="78436-148">The complete **Run** method, and timer callback code, from the [background task sample](https://go.microsoft.com/fwlink/p/?LinkId=618666) are shown below for context.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="78436-149">関連トピック</span><span class="sxs-lookup"><span data-stu-id="78436-149">Related topics</span></span>

- <span data-ttu-id="78436-150">[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)</span><span class="sxs-lookup"><span data-stu-id="78436-150">[Create and register an in-process background task](create-and-register-an-inproc-background-task.md).</span></span>
- [<span data-ttu-id="78436-151">作成して、プロセス外のバック グラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="78436-151">Create and register an out-of-process background task</span></span>](create-and-register-a-background-task.md)
- [<span data-ttu-id="78436-152">アプリケーション マニフェストでバック グラウンド タスクを宣言します。</span><span class="sxs-lookup"><span data-stu-id="78436-152">Declare background tasks in the application manifest</span></span>](declare-background-tasks-in-the-application-manifest.md)
- [<span data-ttu-id="78436-153">バックグラウンド タスクのガイドライン</span><span class="sxs-lookup"><span data-stu-id="78436-153">Guidelines for background tasks</span></span>](guidelines-for-background-tasks.md)
- [<span data-ttu-id="78436-154">バック グラウンド タスクの進行状況と完了を監視します。</span><span class="sxs-lookup"><span data-stu-id="78436-154">Monitor background task progress and completion</span></span>](monitor-background-task-progress-and-completion.md)
- [<span data-ttu-id="78436-155">バック グラウンド タスクを登録します。</span><span class="sxs-lookup"><span data-stu-id="78436-155">Register a background task</span></span>](register-a-background-task.md)
- [<span data-ttu-id="78436-156">バック グラウンド タスクでシステム イベントに応答します。</span><span class="sxs-lookup"><span data-stu-id="78436-156">Respond to system events with background tasks</span></span>](respond-to-system-events-with-background-tasks.md)
- [<span data-ttu-id="78436-157">タイマーでバック グラウンド タスクを実行します。</span><span class="sxs-lookup"><span data-stu-id="78436-157">Run a background task on a timer</span></span>](run-a-background-task-on-a-timer-.md)
- [<span data-ttu-id="78436-158">バック グラウンド タスクを実行するための条件を設定します。</span><span class="sxs-lookup"><span data-stu-id="78436-158">Set conditions for running a background task</span></span>](set-conditions-for-running-a-background-task.md)
- [<span data-ttu-id="78436-159">バック グラウンド タスクからのライブ タイルを更新します。</span><span class="sxs-lookup"><span data-stu-id="78436-159">Update a live tile from a background task</span></span>](update-a-live-tile-from-a-background-task.md)
- [<span data-ttu-id="78436-160">メンテナンス トリガーを使用します。</span><span class="sxs-lookup"><span data-stu-id="78436-160">Use a maintenance trigger</span></span>](use-a-maintenance-trigger.md)
- [<span data-ttu-id="78436-161">バック グラウンド タスクをデバッグします。</span><span class="sxs-lookup"><span data-stu-id="78436-161">Debug a background task</span></span>](debug-a-background-task.md)
- [<span data-ttu-id="78436-162">トリガーする方法を中断、再開、および (デバッグ) 場合は、UWP アプリでイベントをバック グラウンド</span><span class="sxs-lookup"><span data-stu-id="78436-162">How to trigger suspend, resume, and background events in UWP apps (when debugging)</span></span>](https://go.microsoft.com/fwlink/p/?linkid=254345)
