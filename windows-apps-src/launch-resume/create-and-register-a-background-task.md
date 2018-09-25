---
author: TylerMSFT
title: アウトプロセス バックグラウンド タスクの作成と登録
description: アウトプロセスのバックグラウンド タスク クラスを作り、アプリがフォアグラウンドにない場合に実行されるように登録します。
ms.assetid: 4F98F6A3-0D3D-4EFB-BA8E-30ED37AE098B
ms.author: twhitney
ms.date: 07/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: バック グラウンド タスクの windows 10, uwp,
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
ms.openlocfilehash: a599fdef47bb681ef4909fe5bba2a01a1687ba66
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4176491"
---
# <a name="create-and-register-an-out-of-process-background-task"></a><span data-ttu-id="55f1f-104">アウトプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="55f1f-104">Create and register an out-of-process background task</span></span>

**<span data-ttu-id="55f1f-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="55f1f-105">Important APIs</span></span>**

-   [**<span data-ttu-id="55f1f-106">IBackgroundTask</span><span class="sxs-lookup"><span data-stu-id="55f1f-106">IBackgroundTask</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224794)
-   [**<span data-ttu-id="55f1f-107">BackgroundTaskBuilder</span><span class="sxs-lookup"><span data-stu-id="55f1f-107">BackgroundTaskBuilder</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224768)
-   [**<span data-ttu-id="55f1f-108">BackgroundTaskCompletedEventHandler</span><span class="sxs-lookup"><span data-stu-id="55f1f-108">BackgroundTaskCompletedEventHandler</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224781)

<span data-ttu-id="55f1f-109">バックグラウンド タスク クラスを作り、アプリがフォアグラウンドにない場合にも実行されるように登録します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-109">Create a background task class and register it to run when your app is not in the foreground.</span></span> <span data-ttu-id="55f1f-110">このトピックでは、アプリのプロセスとは別のプロセスで実行されるバックグラウンド タスクを作成して登録する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-110">This topic demonstrates how to create and register a background task that runs in a separate process than your app's process.</span></span> <span data-ttu-id="55f1f-111">フォアグラウンド アプリケーションで直接バックグラウンド作業を実行する方法については、「[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="55f1f-111">To do background work directly in the foreground application, see [Create and register an in-process background task](create-and-register-an-inproc-background-task.md).</span></span>

> [!NOTE]
> <span data-ttu-id="55f1f-112">バックグラウンド タスクを使ってバックグラウンドでメディアを再生する場合、Windows 10 バージョン 1607 で簡単に行うことができる機能強化について、「[バックグラウンドでのメディアの再生](https://msdn.microsoft.com/windows/uwp/audio-video-camera/background-audio)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="55f1f-112">If you use a background task to play media in the background, see [Play media in the background](https://msdn.microsoft.com/windows/uwp/audio-video-camera/background-audio) for information about improvements in Windows 10, version 1607, that make it much easier.</span></span>

## <a name="create-the-background-task-class"></a><span data-ttu-id="55f1f-113">バックグラウンド タスク クラスを作る</span><span class="sxs-lookup"><span data-stu-id="55f1f-113">Create the Background Task class</span></span>

<span data-ttu-id="55f1f-114">[**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) インターフェイスを実装するクラスを作ると、コードをバックグラウンドで実行できます。</span><span class="sxs-lookup"><span data-stu-id="55f1f-114">You can run code in the background by writing classes that implement the [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) interface.</span></span> <span data-ttu-id="55f1f-115">このコードは、 [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839)または[**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517)例を使用して特定のイベントがトリガーされたときに実行されます。</span><span class="sxs-lookup"><span data-stu-id="55f1f-115">This code runs when a specific event is triggered by using, for example, [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839) or [**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517).</span></span>

<span data-ttu-id="55f1f-116">次の手順では、[**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) インターフェイスを実装する新しいクラスを記述する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-116">The following steps show you how to write a new class that implements the [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) interface.</span></span>

1.  <span data-ttu-id="55f1f-117">バックグラウンド タスク用に新しいプロジェクトを作ってソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-117">Create a new project for background tasks and add it to your solution.</span></span> <span data-ttu-id="55f1f-118">これを行うには、**ソリューション エクスプ ローラー**でソリューション ノードを右クリックし、[**追加** \> **新しいプロジェクト**です。</span><span class="sxs-lookup"><span data-stu-id="55f1f-118">To do this, right-click on your solution node in the **Solution Explorer** and select **Add** \> **New Project**.</span></span> <span data-ttu-id="55f1f-119">**Windows ランタイム コンポーネント**プロジェクトの種類、プロジェクトに名前を選択し、[ok] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="55f1f-119">Then select the **Windows Runtime Component** project type, name the project, and click OK.</span></span>
2.  <span data-ttu-id="55f1f-120">ユニバーサル Windows プラットフォーム (UWP) アプリ プロジェクトからバックグラウンド タスク プロジェクトを参照します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-120">Reference the background tasks project from your Universal Windows Platform (UWP) app project.</span></span> <span data-ttu-id="55f1f-121">C# または C++ アプリの場合、アプリ プロジェクトで**参照**で右クリックし、**新しい参照の追加**を選択します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-121">For a C# or C++ app, in your app project, right-click on **References** and select **Add New Reference**.</span></span> <span data-ttu-id="55f1f-122">**[ソリューション]** で、**[プロジェクト]** を選び、バックグラウンド タスク プロジェクトの名前を選んで **[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="55f1f-122">Under **Solution**, select **Projects** and then select the name of your background task project and click **Ok**.</span></span>
3.  <span data-ttu-id="55f1f-123">バック グラウンド タスク プロジェクトでは、 [**IBackgroundTask**](/uwp/api/Windows.ApplicationModel.Background.IBackgroundTask)インターフェイスを実装する新しいクラスを追加します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-123">To the background tasks project, add a new class that implements the [**IBackgroundTask**](/uwp/api/Windows.ApplicationModel.Background.IBackgroundTask) interface.</span></span> <span data-ttu-id="55f1f-124">[**IBackgroundTask.Run**](/uwp/api/windows.applicationmodel.background.ibackgroundtask.run)メソッドは、指定されたイベントがトリガーされた; ときに呼び出される必須のエントリ ポイントです。すべてのバック グラウンド タスクでは、このメソッドが必要です。</span><span class="sxs-lookup"><span data-stu-id="55f1f-124">The [**IBackgroundTask.Run**](/uwp/api/windows.applicationmodel.background.ibackgroundtask.run) method is a required entry point that will be called when the specified event is triggered; this method is required in every background task.</span></span>

> [!NOTE]
> <span data-ttu-id="55f1f-125">バック グラウンド タスク クラス自体&mdash;と他のクラスをバック グラウンド タスク プロジェクト&mdash; **sealed** (または**最終的な**) は**パブリック**クラスを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="55f1f-125">The background task class itself&mdash;and all other classes in the background task project&mdash;need to be **public** classes that are **sealed** (or **final**).</span></span>

<span data-ttu-id="55f1f-126">次のサンプル コードでは、バック グラウンド タスク クラスの非常に基本的な開始点を示します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-126">The following sample code shows a very basic starting point for a background task class.</span></span>

```csharp
// ExampleBackgroundTask.cs
using Windows.ApplicationModel.Background;

namespace Tasks
{
    public sealed class ExampleBackgroundTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            
        }        
    }
}
```

```cppwinrt
// First, add ExampleBackgroundTask.idl, and then build.
// ExampleBackgroundTask.idl
namespace Tasks
{
    [default_interface]
    runtimeclass ExampleBackgroundTask : Windows.ApplicationModel.Background.IBackgroundTask
    {
        ExampleBackgroundTask();
    }
}

// ExampleBackgroundTask.h
#pragma once

#include "ExampleBackgroundTask.g.h"

namespace winrt::Tasks::implementation
{
    struct ExampleBackgroundTask : ExampleBackgroundTaskT<ExampleBackgroundTask>
    {
        ExampleBackgroundTask() = default;

        void Run(Windows::ApplicationModel::Background::IBackgroundTaskInstance const& taskInstance);
    };
}

namespace winrt::Tasks::factory_implementation
{
    struct ExampleBackgroundTask : ExampleBackgroundTaskT<ExampleBackgroundTask, implementation::ExampleBackgroundTask>
    {
    };
}

// ExampleBackgroundTask.cpp
#include "pch.h"
#include "ExampleBackgroundTask.h"

namespace winrt::Tasks::implementation
{
    void ExampleBackgroundTask::Run(Windows::ApplicationModel::Background::IBackgroundTaskInstance const& taskInstance)
    {
        throw hresult_not_implemented();
    }
}
```

```cpp
// ExampleBackgroundTask.h
#pragma once

using namespace Windows::ApplicationModel::Background;

namespace Tasks
{
    public ref class ExampleBackgroundTask sealed : public IBackgroundTask
    {

    public:
        ExampleBackgroundTask();

        virtual void Run(IBackgroundTaskInstance^ taskInstance);
        void OnCompleted(
            BackgroundTaskRegistration^ task,
            BackgroundTaskCompletedEventArgs^ args
        );
    };
}

// ExampleBackgroundTask.cpp
#include "ExampleBackgroundTask.h"

using namespace Tasks;

void ExampleBackgroundTask::Run(IBackgroundTaskInstance^ taskInstance)
{
}
```

4.  <span data-ttu-id="55f1f-127">バックグラウンド タスクで非同期コードを実行する場合は、バックグラウンド タスクで遅延を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="55f1f-127">If you run any asynchronous code in your background task, then your background task needs to use a deferral.</span></span> <span data-ttu-id="55f1f-128">遅延を使わない場合し、バック グラウンド タスクの処理を終了できますが予期せず、非同期処理の実行が完了する前に、 **Run**メソッドが返す場合。</span><span class="sxs-lookup"><span data-stu-id="55f1f-128">If you don't use a deferral, then the background task process can terminate unexpectedly if the **Run** method returns before any asynchronous work has run to completion.</span></span>

<span data-ttu-id="55f1f-129">非同期メソッドを呼び出す前に、 **Run**メソッドでは、保留を要求します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-129">Request the deferral in the **Run** method before calling the asynchronous method.</span></span> <span data-ttu-id="55f1f-130">非同期メソッドからアクセスできるように、クラスのデータ メンバーには、保留を保存します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-130">Save the deferral to a class data member so that it can be accessed from the asynchronous method.</span></span> <span data-ttu-id="55f1f-131">非同期コードが完了した後、遅延を完了するように宣言します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-131">Declare the deferral complete after the asynchronous code completes.</span></span>

<span data-ttu-id="55f1f-132">次のサンプル コードは、保留を取得するには、保存、および非同期コードが完了したら、それを解放します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-132">The following sample code gets the deferral, saves it, and releases it when the asynchronous code is complete.</span></span>

```csharp
BackgroundTaskDeferral _deferral; // Note: defined at class scope so that we can mark it complete inside the OnCancel() callback if we choose to support cancellation
public async void Run(IBackgroundTaskInstance taskInstance)
{
    _deferral = taskInstance.GetDeferral()
    //
    // TODO: Insert code to start one or more asynchronous methods using the
    //       await keyword, for example:
    //
    // await ExampleMethodAsync();
    //

    _deferral.Complete();
}
```

```cppwinrt
// ExampleBackgroundTask.h
...
private:
    Windows::ApplicationModel::Background::BackgroundTaskDeferral m_deferral{ nullptr };

// ExampleBackgroundTask.cpp
...
Windows::Foundation::IAsyncAction ExampleBackgroundTask::Run(
    Windows::ApplicationModel::Background::IBackgroundTaskInstance const& taskInstance)
{
    m_deferral = taskInstance.GetDeferral(); // Note: defined at class scope so that we can mark it complete inside the OnCancel() callback if we choose to support cancellation.
    // TODO: Modify the following line of code to call a real async function.
    co_await ExampleCoroutineAsync(); // Run returns at this point, and resumes when ExampleCoroutineAsync completes.
    m_deferral.Complete();
}
```

```cpp
void ExampleBackgroundTask::Run(IBackgroundTaskInstance^ taskInstance)
{
    m_deferral = taskInstance->GetDeferral(); // Note: defined at class scope so that we can mark it complete inside the OnCancel() callback if we choose to support cancellation.

    //
    // TODO: Modify the following line of code to call a real async function.
    //       Note that the task<void> return type applies only to async
    //       actions. If you need to call an async operation instead, replace
    //       task<void> with the correct return type.
    //
    task<void> myTask(ExampleFunctionAsync());

    myTask.then([=]() {
        m_deferral->Complete();
    });
}
```

> [!NOTE]
> <span data-ttu-id="55f1f-133">C# では、**async/await** キーワードを使ってバックグラウンド タスクの非同期メソッドを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="55f1f-133">In C#, your background task's asynchronous methods can be called using the **async/await** keywords.</span></span> <span data-ttu-id="55f1f-134">C++/cli CX、同様の結果は、タスク チェーンを使用して実現できます。</span><span class="sxs-lookup"><span data-stu-id="55f1f-134">In C++/CX, a similar result can be achieved by using a task chain.</span></span>

<span data-ttu-id="55f1f-135">非同期パターンについて詳しくは、「[非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187335)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="55f1f-135">For more information about asynchronous patterns, see [Asynchronous programming](https://msdn.microsoft.com/library/windows/apps/mt187335).</span></span> <span data-ttu-id="55f1f-136">遅延を使ってバックグラウンド タスクの早期停止を防ぐ方法に関するその他の例については、[バックグラウンド タスクのサンプルに関するページ](http://go.microsoft.com/fwlink/p/?LinkId=618666)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="55f1f-136">For additional examples of how to use deferrals to keep a background task from stopping early, see the [background task sample](http://go.microsoft.com/fwlink/p/?LinkId=618666).</span></span>

<span data-ttu-id="55f1f-137">次の手順はいずれかのアプリ クラス (MainPage.xaml.cs など) で実行します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-137">The following steps are completed in one of your app classes (for example, MainPage.xaml.cs).</span></span>

> [!NOTE]
> <span data-ttu-id="55f1f-138">バック グラウンド タスクを登録するための専用の関数を作成することもできます。&mdash;[バック グラウンド タスクの登録](register-a-background-task.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="55f1f-138">You can also create a function dedicated to registering background tasks&mdash;see [Register a background task](register-a-background-task.md).</span></span> <span data-ttu-id="55f1f-139">その場合は、次の 3 つの手順ではなく単にトリガーを作成してタスク名、タスクのエントリ ポイントと (必要に応じて) 条件併せて登録関数を提供できます。</span><span class="sxs-lookup"><span data-stu-id="55f1f-139">In that case, instead of using the next three steps, you can simply construct the trigger and provide it to the registration function along with the task name, task entry point, and (optionally) a condition.</span></span>

## <a name="register-the-background-task-to-run"></a><span data-ttu-id="55f1f-140">実行するバックグラウンド タスクを登録する</span><span class="sxs-lookup"><span data-stu-id="55f1f-140">Register the background task to run</span></span>

1.  <span data-ttu-id="55f1f-141">[**BackgroundTaskRegistration.AllTasks**](https://msdn.microsoft.com/library/windows/apps/br224787)プロパティを反復処理によって、バック グラウンド タスクが既に登録されているかどうかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-141">Find out whether the background task is already registered by iterating through the [**BackgroundTaskRegistration.AllTasks**](https://msdn.microsoft.com/library/windows/apps/br224787) property.</span></span> <span data-ttu-id="55f1f-142">この確認は重要です。既にあるバックグラウンド タスクの二重登録をアプリで確認しなかった場合、同じタスクが何度も登録され、パフォーマンスが低下したり、タスクの CPU 時間を使い切って処理を完了できなくなるなどの問題が生じます。</span><span class="sxs-lookup"><span data-stu-id="55f1f-142">This step is important; if your app doesn't check for existing background task registrations, it could easily register the task multiple times, causing issues with performance and maxing out the task's available CPU time before work can complete.</span></span>

<span data-ttu-id="55f1f-143">次の例では、 **AllTasks**プロパティを反復処理し、タスクが既に登録されている場合は true にフラグ変数を設定します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-143">The following example iterates on the **AllTasks** property and sets a flag variable to true if the task is already registered.</span></span>

```csharp
var taskRegistered = false;
var exampleTaskName = "ExampleBackgroundTask";

foreach (var task in BackgroundTaskRegistration.AllTasks)
{
    if (task.Value.Name == exampleTaskName)
    {
        taskRegistered = true;
        break;
    }
}
```

```cppwinrt
std::wstring exampleTaskName{ L"ExampleBackgroundTask" };

auto allTasks{ Windows::ApplicationModel::Background::BackgroundTaskRegistration::AllTasks() };

bool taskRegistered{ false };
for (auto const& task : allTasks)
{
    if (task.Value().Name() == exampleTaskName)
    {
        taskRegistered = true;
        break;
    }
}

// The code in the next step goes here.
```

```cpp
boolean taskRegistered = false;
Platform::String^ exampleTaskName = "ExampleBackgroundTask";

auto iter = BackgroundTaskRegistration::AllTasks->First();
auto hascur = iter->HasCurrent;

while (hascur)
{
    auto cur = iter->Current->Value;

    if(cur->Name == exampleTaskName)
    {
        taskRegistered = true;
        break;
    }

    hascur = iter->MoveNext();
}
```

2.  <span data-ttu-id="55f1f-144">バックグラウンド タスクがまだ登録されていない場合は、[**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) を使ってバックグラウンド タスクのインスタンスを作成します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-144">If the background task is not already registered, use [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) to create an instance of your background task.</span></span> <span data-ttu-id="55f1f-145">タスクのエントリ ポイントには、名前空間を含めてバックグラウンド タスク クラスの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-145">The task entry point should be the name of your background task class prefixed by the namespace.</span></span>

<span data-ttu-id="55f1f-146">バックグラウンド タスク トリガーは、バックグラウンド タスクが実行されるタイミングを制御します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-146">The background task trigger controls when the background task will run.</span></span> <span data-ttu-id="55f1f-147">指定できるトリガーの一覧については、「[**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="55f1f-147">For a list of possible triggers, see [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839).</span></span>

<span data-ttu-id="55f1f-148">たとえば、このコードは、新しいバック グラウンド タスクを作成し、 **TimeZoneChanged**トリガーが発生したときに実行するように設定します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-148">For example, this code creates a new background task and sets it to run when the **TimeZoneChanged** trigger occurs:</span></span>

```csharp
var builder = new BackgroundTaskBuilder();

builder.Name = exampleTaskName;
builder.TaskEntryPoint = "Tasks.ExampleBackgroundTask";
builder.SetTrigger(new SystemTrigger(SystemTriggerType.TimeZoneChange, false));
```

```cppwinrt
if (!taskRegistered)
{
    Windows::ApplicationModel::Background::BackgroundTaskBuilder builder;
    builder.Name(exampleTaskName);
    builder.TaskEntryPoint(L"Tasks.ExampleBackgroundTask");
    builder.SetTrigger(Windows::ApplicationModel::Background::SystemTrigger{
        Windows::ApplicationModel::Background::SystemTriggerType::TimeZoneChange, false });
    // The code in the next step goes here.
}
```

```cpp
auto builder = ref new BackgroundTaskBuilder();

builder->Name = exampleTaskName;
builder->TaskEntryPoint = "Tasks.ExampleBackgroundTask";
builder->SetTrigger(ref new SystemTrigger(SystemTriggerType::TimeZoneChange, false));
```

3.  <span data-ttu-id="55f1f-149">トリガー イベントの発生後、どのようなときにタスクを実行するかという条件を追加することもできます (省略可能)。</span><span class="sxs-lookup"><span data-stu-id="55f1f-149">You can add a condition to control when your task will run after the trigger event occurs (optional).</span></span> <span data-ttu-id="55f1f-150">たとえば、ユーザーが存在するときにだけタスクを実行する場合、**UserPresent** という条件を使います。</span><span class="sxs-lookup"><span data-stu-id="55f1f-150">For example, if you don't want the task to run until the user is present, use the condition **UserPresent**.</span></span> <span data-ttu-id="55f1f-151">指定できる条件の一覧については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="55f1f-151">For a list of possible conditions, see [**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835).</span></span>

<span data-ttu-id="55f1f-152">次のサンプル コードでは、"ユーザーの存在" を条件として割り当てています。</span><span class="sxs-lookup"><span data-stu-id="55f1f-152">The following sample code assigns a condition requiring the user to be present:</span></span>

```csharp
builder.AddCondition(new SystemCondition(SystemConditionType.UserPresent));
```

```cppwinrt
builder.AddCondition(Windows::ApplicationModel::Background::SystemCondition{ Windows::ApplicationModel::Background::SystemConditionType::UserPresent });
// The code in the next step goes here.
```

```cpp
builder->AddCondition(ref new SystemCondition(SystemConditionType::UserPresent));
```

4.  <span data-ttu-id="55f1f-153">[**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) オブジェクトで Register メソッドを呼び出してバックグラウンド タスクを登録します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-153">Register the background task by calling the Register method on the [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) object.</span></span> <span data-ttu-id="55f1f-154">[**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786) の結果は、次の手順に備えて保存します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-154">Store the [**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786) result so it can be used in the next step.</span></span>

<span data-ttu-id="55f1f-155">バックグラウンド タスクを登録し、その結果を保存するコードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-155">The following code registers the background task and stores the result:</span></span>

```csharp
BackgroundTaskRegistration task = builder.Register();
```

```cppwinrt
Windows::ApplicationModel::Background::BackgroundTaskRegistration task{ builder.Register() };
```

```cpp
BackgroundTaskRegistration^ task = builder->Register();
```

> [!NOTE]
> <span data-ttu-id="55f1f-156">ユニバーサル Windows アプリは、どの種類のバックグラウンド トリガーを登録する場合でも、先に [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="55f1f-156">Universal Windows apps must call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) before registering any of the background trigger types.</span></span>

<span data-ttu-id="55f1f-157">更新プログラムのリリース後にユニバーサル Windows アプリが引き続き適切に実行されるようにするには、**ServicingComplete** ([SystemTriggerType](https://msdn.microsoft.com/library/windows/apps/br224839) に関するページをご覧ください) トリガーを使って、アプリのデータベースの移行やバックグラウンド タスクの登録などの更新後の構成の変更を実行します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-157">To ensure that your Universal Windows app continues to run properly after you release an update, use the **ServicingComplete** (see [SystemTriggerType](https://msdn.microsoft.com/library/windows/apps/br224839)) trigger to perform any post-update configuration changes such as migrating the app's database and registering background tasks.</span></span> <span data-ttu-id="55f1f-158">現時点で、アプリの以前のバージョンに関連付けられたバックグラウンド タスクの登録を解除してから ([**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471) に関するページをご覧ください)、アプリの新しいバージョンのバックグラウンド タスクを登録する ([**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) に関するページをご覧ください) ことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="55f1f-158">It is best practice to unregister background tasks associated with the previous version of the app (see [**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471)) and register background tasks for the new version of the app (see [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485)) at this time.</span></span>

<span data-ttu-id="55f1f-159">詳しくは、「[バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="55f1f-159">For more information, see [Guidelines for background tasks](guidelines-for-background-tasks.md).</span></span>

## <a name="handle-background-task-completion-using-event-handlers"></a><span data-ttu-id="55f1f-160">イベント ハンドラーでバックグラウンド タスクの完了を処理する</span><span class="sxs-lookup"><span data-stu-id="55f1f-160">Handle background task completion using event handlers</span></span>

<span data-ttu-id="55f1f-161">アプリからバックグラウンド タスクの結果を取得できるように、[**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781) にメソッドを登録します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-161">You should register a method with the [**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781), so that your app can get results from the background task.</span></span> <span data-ttu-id="55f1f-162">アプリが起動、または再開するときは、前回がアプリをフォア グラウンドからバック グラウンド タスクが完了した場合マークされたメソッドが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="55f1f-162">When the app is launched or resumed, the marked method will be called if the background task has completed since the last time the app was in the foreground.</span></span> <span data-ttu-id="55f1f-163">(アプリがフォアグラウンドにある間にバックグラウンド タスクが終了した場合は、OnCompleted メソッドが直ちに呼び出されます)。</span><span class="sxs-lookup"><span data-stu-id="55f1f-163">(The OnCompleted method will be called immediately if the background task completes while your app is currently in the foreground.)</span></span>

1.  <span data-ttu-id="55f1f-164">バックグラウンド タスクの完了を処理する OnCompleted メソッドを記述します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-164">Write an OnCompleted method to handle the completion of background tasks.</span></span> <span data-ttu-id="55f1f-165">たとえば、バックグラウンド タスクの結果により UI を更新できます。</span><span class="sxs-lookup"><span data-stu-id="55f1f-165">For example, the background task result might cause a UI update.</span></span> <span data-ttu-id="55f1f-166">ここに示すメソッドのフットプリントは、この例では *args* パラメーターは使われていませんが、OnCompleted イベント ハンドラー メソッドで必須になります。</span><span class="sxs-lookup"><span data-stu-id="55f1f-166">The method footprint shown here is required for the OnCompleted event handler method, even though this example does not use the *args* parameter.</span></span>

<span data-ttu-id="55f1f-167">次のサンプル コードは、バックグラウンド タスクの完了を認識し、メッセージ文字列を使う UI 更新メソッドの例を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-167">The following sample code recognizes background task completion and calls an example UI update method that takes a message string.</span></span>

```csharp
private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
{
    var settings = Windows.Storage.ApplicationData.Current.LocalSettings;
    var key = task.TaskId.ToString();
    var message = settings.Values[key].ToString();
    UpdateUI(message);
}
```

```cppwinrt
void UpdateUI(winrt::hstring const& message)
{
    MyTextBlock().Dispatcher().RunAsync(Windows::UI::Core::CoreDispatcherPriority::Normal, [=]()
    {
        MyTextBlock().Text(message);
    });
}

void OnCompleted(
    Windows::ApplicationModel::Background::BackgroundTaskRegistration const& sender,
    Windows::ApplicationModel::Background::BackgroundTaskCompletedEventArgs const& /* args */)
{
    // You'll previously have inserted this key into local settings.
    auto settings{ Windows::Storage::ApplicationData::Current().LocalSettings().Values() };
    auto key{ winrt::to_hstring(sender.TaskId()) };
    auto message{ winrt::unbox_value<winrt::hstring>(settings.Lookup(key)) };

    UpdateUI(message);
}
```

```cpp
void MainPage::OnCompleted(BackgroundTaskRegistration^ task, BackgroundTaskCompletedEventArgs^ args)
{
    auto settings = ApplicationData::Current->LocalSettings->Values;
    auto key = task->TaskId.ToString();
    auto message = dynamic_cast<String^>(settings->Lookup(key));
    UpdateUI(message);
}
```

> [!NOTE]
> <span data-ttu-id="55f1f-168">UI の更新は、UI スレッドを拘束することがないように、非同期で実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="55f1f-168">UI updates should be performed asynchronously, to avoid holding up the UI thread.</span></span> <span data-ttu-id="55f1f-169">例については、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)の UpdateUI メソッドを参照してください。</span><span class="sxs-lookup"><span data-stu-id="55f1f-169">For an example, see the UpdateUI method in the [background task sample](http://go.microsoft.com/fwlink/p/?LinkId=618666).</span></span>

2.  <span data-ttu-id="55f1f-170">バックグラウンド タスクを登録した位置に戻ります。</span><span class="sxs-lookup"><span data-stu-id="55f1f-170">Go back to where you registered the background task.</span></span> <span data-ttu-id="55f1f-171">そのコード行の後に、新しい [**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781) オブジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-171">After that line of code, add a new [**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781) object.</span></span> <span data-ttu-id="55f1f-172">**BackgroundTaskCompletedEventHandler** コンストラクターのパラメーターとして OnCompleted メソッドを指定します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-172">Provide your OnCompleted method as the parameter for the **BackgroundTaskCompletedEventHandler** constructor.</span></span>

<span data-ttu-id="55f1f-173">次のサンプル コードにより、[**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786) に [**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781) が追加されます。</span><span class="sxs-lookup"><span data-stu-id="55f1f-173">The following sample code adds a [**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781) to the [**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786):</span></span>

```csharp
task.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted);
```

```cppwinrt
task.Completed({ this, &MainPage::OnCompleted });
```

```cpp
task->Completed += ref new BackgroundTaskCompletedEventHandler(this, &MainPage::OnCompleted);
```

## <a name="declare-in-the-app-manifest-that-your-app-uses-background-tasks"></a><span data-ttu-id="55f1f-174">アプリがバック グラウンド タスクを使っているアプリ マニフェストで宣言します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-174">Declare in the app manifest that your app uses background tasks</span></span>

<span data-ttu-id="55f1f-175">アプリでバックグラウンド タスクを実行する前に、各バックグラウンド タスクをアプリ マニフェストで宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="55f1f-175">Before your app can run background tasks, you must declare each background task in the app manifest.</span></span> <span data-ttu-id="55f1f-176">アプリがマニフェストに記載されていないトリガーでバック グラウンド タスクを登録しようとすると、バック グラウンド タスクの登録は"ランタイム クラスが登録されていない"というエラーで失敗します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-176">If your app attempts to register a background task with a trigger that isn't listed in the manifest, the registration of the background task will fail with a "runtime class not registered" error.</span></span>

1.  <span data-ttu-id="55f1f-177">Package.appxmanifest という名前のファイルを開いて、パッケージ マニフェスト デザイナーを開きます。</span><span class="sxs-lookup"><span data-stu-id="55f1f-177">Open the package manifest designer by opening the file named Package.appxmanifest.</span></span>
2.  <span data-ttu-id="55f1f-178">**[宣言]** タブを開きます。</span><span class="sxs-lookup"><span data-stu-id="55f1f-178">Open the **Declarations** tab.</span></span>
3.  <span data-ttu-id="55f1f-179">**[使用可能な宣言]** ボックスの一覧の **[バックグラウンド タスク]** を選び、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="55f1f-179">From the **Available Declarations** drop-down, select **Background Tasks** and click **Add**.</span></span>
4.  <span data-ttu-id="55f1f-180">**[システム イベント]** チェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="55f1f-180">Select the **System event** checkbox.</span></span>
5.  <span data-ttu-id="55f1f-181">**エントリ ポイント:** textbox、名前空間と次の例は Tasks.ExampleBackgroundTask ですが、バック グラウンド クラスの名前を入力します。</span><span class="sxs-lookup"><span data-stu-id="55f1f-181">In the **Entry point:** textbox, enter the namespace and name of your background class which is for this example is Tasks.ExampleBackgroundTask.</span></span>
6.  <span data-ttu-id="55f1f-182">マニフェスト デザイナーを閉じます。</span><span class="sxs-lookup"><span data-stu-id="55f1f-182">Close the manfiest designer.</span></span>

<span data-ttu-id="55f1f-183">バック グラウンド タスクを登録するために、次の Extensions 要素が Package.appxmanifest ファイルに追加されます。</span><span class="sxs-lookup"><span data-stu-id="55f1f-183">The following Extensions element is added to your Package.appxmanifest file to register the background task:</span></span>

```xml
<Extensions>
  <Extension Category="windows.backgroundTasks" EntryPoint="Tasks.ExampleBackgroundTask">
    <BackgroundTasks>
      <Task Type="systemEvent" />
    </BackgroundTasks>
  </Extension>
</Extensions>
```

## <a name="summary-and-next-steps"></a><span data-ttu-id="55f1f-184">要約と次のステップ</span><span class="sxs-lookup"><span data-stu-id="55f1f-184">Summary and next steps</span></span>

<span data-ttu-id="55f1f-185">ここでは、バックグラウンド タスク クラスの記述方法、アプリ内からバックグラウンド タスクを登録する方法、バックグラウンド タスクが完了したことをアプリで認識する方法の基本について学習しました。</span><span class="sxs-lookup"><span data-stu-id="55f1f-185">You should now understand the basics of how to write a background task class, how to register the background task from within your app, and how to make your app recognize when the background task is complete.</span></span> <span data-ttu-id="55f1f-186">また、アプリで適切にバックグラウンド タスクを登録できるように、アプリ マニフェストを更新する方法についても学習しました。</span><span class="sxs-lookup"><span data-stu-id="55f1f-186">You should also understand how to update the application manifest so that your app can successfully register the background task.</span></span>

> [!NOTE]
> <span data-ttu-id="55f1f-187">[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)をダウンロードして、バックグラウンド タスクを使う完全で堅牢な UWP アプリのコンテキストで類似のコード例を確認してください。</span><span class="sxs-lookup"><span data-stu-id="55f1f-187">Download the [background task sample](http://go.microsoft.com/fwlink/p/?LinkId=618666) to see similar code examples in the context of a complete and robust UWP app that uses background tasks.</span></span>

<span data-ttu-id="55f1f-188">API リファレンス、バックグラウンド タスクの概念的ガイダンス、バックグラウンド タスクを使ったアプリの作成に関する詳しい説明については、次の関連するトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="55f1f-188">See the following related topics for API reference, background task conceptual guidance, and more detailed instructions for writing apps that use background tasks.</span></span>

## <a name="related-topics"></a><span data-ttu-id="55f1f-189">関連トピック</span><span class="sxs-lookup"><span data-stu-id="55f1f-189">Related topics</span></span>

**<span data-ttu-id="55f1f-190">バックグラウンド タスクに関する手順を詳しく説明するトピック</span><span class="sxs-lookup"><span data-stu-id="55f1f-190">Detailed background task instructional topics</span></span>**

* [<span data-ttu-id="55f1f-191">バックグラウンド タスクによるシステム イベントへの応答</span><span class="sxs-lookup"><span data-stu-id="55f1f-191">Respond to system events with background tasks</span></span>](respond-to-system-events-with-background-tasks.md)
* [<span data-ttu-id="55f1f-192">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="55f1f-192">Register a background task</span></span>](register-a-background-task.md)
* [<span data-ttu-id="55f1f-193">バックグラウンド タスクを実行するための条件の設定</span><span class="sxs-lookup"><span data-stu-id="55f1f-193">Set conditions for running a background task</span></span>](set-conditions-for-running-a-background-task.md)
* [<span data-ttu-id="55f1f-194">メンテナンス トリガーの使用</span><span class="sxs-lookup"><span data-stu-id="55f1f-194">Use a maintenance trigger</span></span>](use-a-maintenance-trigger.md)
* [<span data-ttu-id="55f1f-195">取り消されたバックグラウンド タスクの処理</span><span class="sxs-lookup"><span data-stu-id="55f1f-195">Handle a cancelled background task</span></span>](handle-a-cancelled-background-task.md)
* [<span data-ttu-id="55f1f-196">バックグラウンド タスクの進捗状況と完了の監視</span><span class="sxs-lookup"><span data-stu-id="55f1f-196">Monitor background task progress and completion</span></span>](monitor-background-task-progress-and-completion.md)
* [<span data-ttu-id="55f1f-197">タイマーでのバックグラウンド タスクの実行</span><span class="sxs-lookup"><span data-stu-id="55f1f-197">Run a background task on a timer</span></span>](run-a-background-task-on-a-timer-.md)
* <span data-ttu-id="55f1f-198">[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)。</span><span class="sxs-lookup"><span data-stu-id="55f1f-198">[Create and register an in-process background task](create-and-register-an-inproc-background-task.md).</span></span>
* [<span data-ttu-id="55f1f-199">アウトプロセスのバックグラウンド タスクをインプロセスのバックグラウンド タスクへ変換</span><span class="sxs-lookup"><span data-stu-id="55f1f-199">Convert an out-of-process background task to an in-process background task</span></span>](convert-out-of-process-background-task.md)  

**<span data-ttu-id="55f1f-200">バックグラウンド タスクのガイダンス</span><span class="sxs-lookup"><span data-stu-id="55f1f-200">Background task guidance</span></span>**

* [<span data-ttu-id="55f1f-201">バックグラウンド タスクのガイドライン</span><span class="sxs-lookup"><span data-stu-id="55f1f-201">Guidelines for background tasks</span></span>](guidelines-for-background-tasks.md)
* [<span data-ttu-id="55f1f-202">バックグラウンド タスクのデバッグ</span><span class="sxs-lookup"><span data-stu-id="55f1f-202">Debug a background task</span></span>](debug-a-background-task.md)
* [<span data-ttu-id="55f1f-203">UWP アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)</span><span class="sxs-lookup"><span data-stu-id="55f1f-203">How to trigger suspend, resume, and background events in UWP apps (when debugging)</span></span>](http://go.microsoft.com/fwlink/p/?linkid=254345)

**<span data-ttu-id="55f1f-204">バックグラウンド タスクの API リファレンス</span><span class="sxs-lookup"><span data-stu-id="55f1f-204">Background Task API Reference</span></span>**

* [**<span data-ttu-id="55f1f-205">Windows.ApplicationModel.Background</span><span class="sxs-lookup"><span data-stu-id="55f1f-205">Windows.ApplicationModel.Background</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224847)
