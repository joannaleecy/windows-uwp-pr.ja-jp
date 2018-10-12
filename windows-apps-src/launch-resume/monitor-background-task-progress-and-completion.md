---
author: TylerMSFT
title: バックグラウンド タスクの進捗状況と完了の監視
description: バックグラウンド タスクから報告される進行状況と完了をアプリから認識する方法について説明します。
ms.assetid: 17544FD7-A336-4254-97DC-2BF8994FF9B2
ms.author: twhitney
ms.date: 07/06/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: バック グラウンド タスクの windows 10, uwp,
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
ms.openlocfilehash: ef57c6293b37f91653b5f825881b1446e38a824b
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4555430"
---
# <a name="monitor-background-task-progress-and-completion"></a><span data-ttu-id="95fa3-104">バックグラウンド タスクの進捗状況と完了の監視</span><span class="sxs-lookup"><span data-stu-id="95fa3-104">Monitor background task progress and completion</span></span>

**<span data-ttu-id="95fa3-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="95fa3-105">Important APIs</span></span>**

- [**<span data-ttu-id="95fa3-106">BackgroundTaskRegistration</span><span class="sxs-lookup"><span data-stu-id="95fa3-106">BackgroundTaskRegistration</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224786)
- [**<span data-ttu-id="95fa3-107">BackgroundTaskProgressEventHandler</span><span class="sxs-lookup"><span data-stu-id="95fa3-107">BackgroundTaskProgressEventHandler</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224785)
- [**<span data-ttu-id="95fa3-108">BackgroundTaskCompletedEventHandler</span><span class="sxs-lookup"><span data-stu-id="95fa3-108">BackgroundTaskCompletedEventHandler</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224781)

<span data-ttu-id="95fa3-109">アウトプロセスで実行されるバックグラウンド タスクから報告される進行状況と完了をアプリから認識する方法について説明します </span><span class="sxs-lookup"><span data-stu-id="95fa3-109">Learn how your app can recognize progress and completion reported by a background task that runs out-of-process.</span></span> <span data-ttu-id="95fa3-110">(インプロセス バックグラウンド タスクの場合、共有変数を設定して進行状況と完了を表すことができます)。</span><span class="sxs-lookup"><span data-stu-id="95fa3-110">(For in-process background tasks, you can set shared variables to signify progress and completion.)</span></span>

<span data-ttu-id="95fa3-111">バック グラウンド タスクの進捗状況と完了は、アプリ コードによって監視することができます。</span><span class="sxs-lookup"><span data-stu-id="95fa3-111">Background task progress and completion can be monitored by app code.</span></span> <span data-ttu-id="95fa3-112">これを行うために、アプリでは、システムに登録されたバックグラウンド タスクのイベントを受信登録します。</span><span class="sxs-lookup"><span data-stu-id="95fa3-112">To do so, the app subscribes to events from the background task(s) it has registered with the system.</span></span>

- <span data-ttu-id="95fa3-113">このトピックでは、アプリで既にバックグラウンド タスクが登録されていることを前提とします。</span><span class="sxs-lookup"><span data-stu-id="95fa3-113">This topic assumes that you have an app that registers background tasks.</span></span> <span data-ttu-id="95fa3-114">バックグラウンド タスクの作成方法の概要については、「[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)」または「[アウト プロセス バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="95fa3-114">To get started quickly building a background task, see [Create and register an in-process background task](create-and-register-an-inproc-background-task.md) or [Create and register an out-of-process background task](create-and-register-a-background-task.md).</span></span> <span data-ttu-id="95fa3-115">条件とトリガーについて詳しくは、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="95fa3-115">For more in-depth information on conditions and triggers, see [Support your app with background tasks](support-your-app-with-background-tasks.md).</span></span>

## <a name="create-an-event-handler-to-handle-completed-background-tasks"></a><span data-ttu-id="95fa3-116">完了したバックグラウンド タスクを処理するイベント ハンドラーの作成</span><span class="sxs-lookup"><span data-stu-id="95fa3-116">Create an event handler to handle completed background tasks</span></span>

### <a name="step-1"></a><span data-ttu-id="95fa3-117">手順 1.</span><span class="sxs-lookup"><span data-stu-id="95fa3-117">Step 1</span></span>
<span data-ttu-id="95fa3-118">完了したバックグラウンド タスクを処理するイベント ハンドラー関数を作ります。</span><span class="sxs-lookup"><span data-stu-id="95fa3-118">Create an event handler function to handle completed background tasks.</span></span> <span data-ttu-id="95fa3-119">このコードは、 [**IBackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224803)オブジェクトと[**BackgroundTaskCompletedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224778)オブジェクトを受け取る特定のフット プリントに従って必要があります。</span><span class="sxs-lookup"><span data-stu-id="95fa3-119">This code needs to follow a specific footprint, which takes an [**IBackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224803) object and a [**BackgroundTaskCompletedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224778) object.</span></span>

<span data-ttu-id="95fa3-120">**OnCompleted**バック グラウンド タスク イベント ハンドラー メソッドには、次のフット プリントを使います。</span><span class="sxs-lookup"><span data-stu-id="95fa3-120">Use the following footprint for the **OnCompleted** background task event handler method.</span></span>

```csharp
private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
{
    // TODO: Add code that deals with background task completion.
}
```

```cppwinrt
auto completed{ [this](
        Windows::ApplicationModel::Background::BackgroundTaskRegistration const& /* sender */,
        Windows::ApplicationModel::Background::BackgroundTaskCompletedEventArgs const& /* args */)
{
    // TODO: Add code that deals with background task completion.
} };
```

```cpp
auto completed = [this](BackgroundTaskRegistration^ task, BackgroundTaskCompletedEventArgs^ args)
{
    // TODO: Add code that deals with background task completion.
};
```

### <a name="step-2"></a><span data-ttu-id="95fa3-121">手順 2.</span><span class="sxs-lookup"><span data-stu-id="95fa3-121">Step 2</span></span>
<span data-ttu-id="95fa3-122">バックグラウンド タスクの完了を処理するイベント ハンドラーにコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="95fa3-122">Add code to the event handler that deals with the background task completion.</span></span>

<span data-ttu-id="95fa3-123">たとえば、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)は UI を更新します。</span><span class="sxs-lookup"><span data-stu-id="95fa3-123">For example, the [background task sample](http://go.microsoft.com/fwlink/p/?LinkId=618666) updates the UI.</span></span>

```csharp
private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
{
    UpdateUI();
}
```

```cppwinrt
auto completed{ [this](
        Windows::ApplicationModel::Background::BackgroundTaskRegistration const& /* sender */,
        Windows::ApplicationModel::Background::BackgroundTaskCompletedEventArgs const& /* args */)
{
    UpdateUI();
} };
```

```cpp
auto completed = [this](BackgroundTaskRegistration^ task, BackgroundTaskCompletedEventArgs^ args)
{    
    UpdateUI();
};
```

## <a name="create-an-event-handler-function-to-handle-background-task-progress"></a><span data-ttu-id="95fa3-124">バックグラウンド タスクの進行状況を処理するイベント ハンドラー関数の作成</span><span class="sxs-lookup"><span data-stu-id="95fa3-124">Create an event handler function to handle background task progress</span></span>

### <a name="step-1"></a><span data-ttu-id="95fa3-125">手順 1.</span><span class="sxs-lookup"><span data-stu-id="95fa3-125">Step 1</span></span>
<span data-ttu-id="95fa3-126">完了したバックグラウンド タスクを処理するイベント ハンドラー関数を作ります。</span><span class="sxs-lookup"><span data-stu-id="95fa3-126">Create an event handler function to handle completed background tasks.</span></span> <span data-ttu-id="95fa3-127">このコードは、[**IBackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224803) オブジェクトと [**BackgroundTaskProgressEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224782) オブジェクトを受け入れる特定のフットプリントに従っている必要があります。</span><span class="sxs-lookup"><span data-stu-id="95fa3-127">This code needs to follow a specific footprint, which takes in an [**IBackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224803) object and a [**BackgroundTaskProgressEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224782) object:</span></span>

<span data-ttu-id="95fa3-128">OnProgress バックグラウンド タスク イベント ハンドラー メソッドには次のフットプリントを使います。</span><span class="sxs-lookup"><span data-stu-id="95fa3-128">Use the following footprint for the OnProgress background task event handler method:</span></span>

```csharp
private void OnProgress(IBackgroundTaskRegistration task, BackgroundTaskProgressEventArgs args)
{
    // TODO: Add code that deals with background task progress.
}
```

```cppwinrt
auto progress{ [this](
    Windows::ApplicationModel::Background::BackgroundTaskRegistration const& /* sender */,
    Windows::ApplicationModel::Background::BackgroundTaskProgressEventArgs const& /* args */)
{
    // TODO: Add code that deals with background task progress.
} };
```

```cpp
auto progress = [this](BackgroundTaskRegistration^ task, BackgroundTaskProgressEventArgs^ args)
{
    // TODO: Add code that deals with background task progress.
};
```

### <a name="step-2"></a><span data-ttu-id="95fa3-129">手順 2.</span><span class="sxs-lookup"><span data-stu-id="95fa3-129">Step 2</span></span>
<span data-ttu-id="95fa3-130">バックグラウンド タスクの完了を処理するイベント ハンドラーにコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="95fa3-130">Add code to the event handler that deals with the background task completion.</span></span>

<span data-ttu-id="95fa3-131">たとえば、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)では、*args* パラメーターで渡された進行状態により、UI が更新されます。</span><span class="sxs-lookup"><span data-stu-id="95fa3-131">For example, the [background task sample](http://go.microsoft.com/fwlink/p/?LinkId=618666) updates the UI with the progress status passed in via the *args* parameter:</span></span>

```csharp
private void OnProgress(IBackgroundTaskRegistration task, BackgroundTaskProgressEventArgs args)
{
    var progress = "Progress: " + args.Progress + "%";
    BackgroundTaskSample.SampleBackgroundTaskProgress = progress;
    UpdateUI();
}
```

```cppwinrt
auto progress{ [this](
    Windows::ApplicationModel::Background::BackgroundTaskRegistration const& /* sender */,
    Windows::ApplicationModel::Background::BackgroundTaskProgressEventArgs const& args)
{
    winrt::hstring progress{ L"Progress: " + winrt::to_hstring(args.Progress()) + L"%" };
    BackgroundTaskSample::SampleBackgroundTaskProgress = progress;
    UpdateUI();
} };
```

```cpp
auto progress = [this](BackgroundTaskRegistration^ task, BackgroundTaskProgressEventArgs^ args)
{
    auto progress = "Progress: " + args->Progress + "%";
    BackgroundTaskSample::SampleBackgroundTaskProgress = progress;
    UpdateUI();
};
```

## <a name="register-the-event-handler-functions-with-new-and-existing-background-tasks"></a><span data-ttu-id="95fa3-132">新規および既存のバックグラウンド タスクと共にイベント ハンドラー関数を登録する</span><span class="sxs-lookup"><span data-stu-id="95fa3-132">Register the event handler functions with new and existing background tasks</span></span>

### <a name="step-1"></a><span data-ttu-id="95fa3-133">手順 1.</span><span class="sxs-lookup"><span data-stu-id="95fa3-133">Step 1</span></span>
<span data-ttu-id="95fa3-134">アプリで初めてバックグラウンド タスクを登録するときは、フォアグラウンドでまだアプリがアクティブになっていてタスクか実行されている場合に、進行状況と完了の更新を受け取ることができるように登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="95fa3-134">When the app registers a background task for the first time, it should register to receive progress and completion updates for it, in case the task runs while the app is still active in the foreground.</span></span>

<span data-ttu-id="95fa3-135">たとえば、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)では、登録するバックグラウンド タスクごとに次の関数を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="95fa3-135">For example, the [background task sample](http://go.microsoft.com/fwlink/p/?LinkId=618666) calls the following function on each background task that it registers:</span></span>

```csharp
private void AttachProgressAndCompletedHandlers(IBackgroundTaskRegistration task)
{
    task.Progress += new BackgroundTaskProgressEventHandler(OnProgress);
    task.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted);
}
```

```cppwinrt
void SampleBackgroundTask::AttachProgressAndCompletedHandlers(Windows::ApplicationModel::Background::IBackgroundTaskRegistration const& task)
{
    auto progress{ [this](
        Windows::ApplicationModel::Background::BackgroundTaskRegistration const& /* sender */,
        Windows::ApplicationModel::Background::BackgroundTaskProgressEventArgs const& args)
    {
        winrt::hstring progress{ L"Progress: " + winrt::to_hstring(args.Progress()) + L"%" };
        BackgroundTaskSample::SampleBackgroundTaskProgress = progress;
        UpdateUI();
    } };

    task.Progress(progress);

    auto completed{ [this](
        Windows::ApplicationModel::Background::BackgroundTaskRegistration const& /* sender */,
        Windows::ApplicationModel::Background::BackgroundTaskCompletedEventArgs const& /* args */)
    {
        UpdateUI();
    } };

    task.Completed(completed);
}
```

```cpp
void SampleBackgroundTask::AttachProgressAndCompletedHandlers(IBackgroundTaskRegistration^ task)
{
    auto progress = [this](BackgroundTaskRegistration^ task, BackgroundTaskProgressEventArgs^ args)
    {
        auto progress = "Progress: " + args->Progress + "%";
        BackgroundTaskSample::SampleBackgroundTaskProgress = progress;
        UpdateUI();
    };

    task->Progress += ref new BackgroundTaskProgressEventHandler(progress);

    auto completed = [this](BackgroundTaskRegistration^ task, BackgroundTaskCompletedEventArgs^ args)
    {
        UpdateUI();
    };

    task->Completed += ref new BackgroundTaskCompletedEventHandler(completed);
}
```

### <a name="step-2"></a><span data-ttu-id="95fa3-136">手順 2.</span><span class="sxs-lookup"><span data-stu-id="95fa3-136">Step 2</span></span>
<span data-ttu-id="95fa3-137">アプリが起動された時点、またはバックグラウンド タスクの状態が関連する新しいページに移動した時点で、現在登録されているバックグラウンド タスクの一覧を取得し、進行状況と完了に対応するイベント ハンドラー関数に関連付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="95fa3-137">When the app launches, or navigates to a new page where background task status is relevant, it should get a list of background tasks currently registered and associate them with the progress and completion event handler functions.</span></span> <span data-ttu-id="95fa3-138">アプリケーションで現在登録されているバックグラウンド タスクの一覧は、[**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786).[**AllTasks**](https://msdn.microsoft.com/library/windows/apps/br224787) プロパティで保持されます。</span><span class="sxs-lookup"><span data-stu-id="95fa3-138">The list of background tasks currently registered by the application is kept in the [**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786).[**AllTasks**](https://msdn.microsoft.com/library/windows/apps/br224787) property.</span></span>

<span data-ttu-id="95fa3-139">たとえば、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)では、次のコードを使って SampleBackgroundTask ページの移動時にイベント ハンドラーをアタッチします。</span><span class="sxs-lookup"><span data-stu-id="95fa3-139">For example, the [background task sample](http://go.microsoft.com/fwlink/p/?LinkId=618666) uses the following code to attach event handlers when the SampleBackgroundTask page is navigated to:</span></span>

```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    foreach (var task in BackgroundTaskRegistration.AllTasks)
    {
        if (task.Value.Name == BackgroundTaskSample.SampleBackgroundTaskName)
        {
            AttachProgressAndCompletedHandlers(task.Value);
            BackgroundTaskSample.UpdateBackgroundTaskStatus(BackgroundTaskSample.SampleBackgroundTaskName, true);
        }
    }

    UpdateUI();
}
```

```cppwinrt
void SampleBackgroundTask::OnNavigatedTo(Windows::UI::Xaml::Navigation::NavigationEventArgs const& /* e */)
{
    // A pointer back to the main page. This is needed if you want to call methods in MainPage such
    // as NotifyUser().
    m_rootPage = MainPage::Current;

    // Attach progress and completed handlers to any existing tasks.
    auto allTasks{ Windows::ApplicationModel::Background::BackgroundTaskRegistration::AllTasks() };

    for (auto const& task : allTasks)
    {
        if (task.Value().Name() == SampleBackgroundTaskName)
        {
            AttachProgressAndCompletedHandlers(task.Value());
            break;
        }
    }

    UpdateUI();
}
```

```cpp
void SampleBackgroundTask::OnNavigatedTo(NavigationEventArgs^ e)
{
    // A pointer back to the main page.  This is needed if you want to call methods in MainPage such
    // as NotifyUser().
    rootPage = MainPage::Current;

    // Attach progress and completed handlers to any existing tasks.
    auto iter = BackgroundTaskRegistration::AllTasks->First();
    auto hascur = iter->HasCurrent;
    while (hascur)
    {
        auto cur = iter->Current->Value;

        if (cur->Name == SampleBackgroundTaskName)
        {
            AttachProgressAndCompletedHandlers(cur);
            break;
        }

        hascur = iter->MoveNext();
    }

    UpdateUI();
}
```

## <a name="related-topics"></a><span data-ttu-id="95fa3-140">関連トピック</span><span class="sxs-lookup"><span data-stu-id="95fa3-140">Related topics</span></span>

* <span data-ttu-id="95fa3-141">[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)。</span><span class="sxs-lookup"><span data-stu-id="95fa3-141">[Create and register an in-process background task](create-and-register-an-inproc-background-task.md).</span></span>
* [<span data-ttu-id="95fa3-142">アウトプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="95fa3-142">Create and register an out-of-process background task</span></span>](create-and-register-a-background-task.md)
* [<span data-ttu-id="95fa3-143">アプリケーション マニフェストでのバックグラウンド タスクの宣言</span><span class="sxs-lookup"><span data-stu-id="95fa3-143">Declare background tasks in the application manifest</span></span>](declare-background-tasks-in-the-application-manifest.md)
* [<span data-ttu-id="95fa3-144">取り消されたバックグラウンド タスクの処理</span><span class="sxs-lookup"><span data-stu-id="95fa3-144">Handle a cancelled background task</span></span>](handle-a-cancelled-background-task.md)
* [<span data-ttu-id="95fa3-145">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="95fa3-145">Register a background task</span></span>](register-a-background-task.md)
* [<span data-ttu-id="95fa3-146">バックグラウンド タスクによるシステム イベントへの応答</span><span class="sxs-lookup"><span data-stu-id="95fa3-146">Respond to system events with background tasks</span></span>](respond-to-system-events-with-background-tasks.md)
* [<span data-ttu-id="95fa3-147">バックグラウンド タスクを実行するための条件の設定</span><span class="sxs-lookup"><span data-stu-id="95fa3-147">Set conditions for running a background task</span></span>](set-conditions-for-running-a-background-task.md)
* [<span data-ttu-id="95fa3-148">バックグラウンド タスクのライブ タイルの更新</span><span class="sxs-lookup"><span data-stu-id="95fa3-148">Update a live tile from a background task</span></span>](update-a-live-tile-from-a-background-task.md)
* [<span data-ttu-id="95fa3-149">メンテナンス トリガーの使用</span><span class="sxs-lookup"><span data-stu-id="95fa3-149">Use a maintenance trigger</span></span>](use-a-maintenance-trigger.md)
* [<span data-ttu-id="95fa3-150">タイマーでのバックグラウンド タスクの実行</span><span class="sxs-lookup"><span data-stu-id="95fa3-150">Run a background task on a timer</span></span>](run-a-background-task-on-a-timer-.md)
* [<span data-ttu-id="95fa3-151">バックグラウンド タスクのガイドライン</span><span class="sxs-lookup"><span data-stu-id="95fa3-151">Guidelines for background tasks</span></span>](guidelines-for-background-tasks.md)
* [<span data-ttu-id="95fa3-152">バックグラウンド タスクのデバッグ</span><span class="sxs-lookup"><span data-stu-id="95fa3-152">Debug a background task</span></span>](debug-a-background-task.md)
* [<span data-ttu-id="95fa3-153">UWP アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)</span><span class="sxs-lookup"><span data-stu-id="95fa3-153">How to trigger suspend, resume, and background events in UWP apps (when debugging)</span></span>](http://go.microsoft.com/fwlink/p/?linkid=254345)
