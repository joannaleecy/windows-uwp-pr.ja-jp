---
author: TylerMSFT
title: "アウトプロセス バックグラウンド タスクの作成と登録"
description: "アウトプロセスのバックグラウンド タスク クラスを作り、アプリがフォアグラウンドにない場合に実行されるように登録します。"
ms.assetid: 4F98F6A3-0D3D-4EFB-BA8E-30ED37AE098B
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 1974c90b89a34f3252face47b9f18786b638adf8
ms.sourcegitcommit: 7540962003b38811e6336451bb03d46538b35671
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/26/2017
---
# <a name="create-and-register-an-out-of-process-background-task"></a><span data-ttu-id="8c4bf-104">アウトプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="8c4bf-104">Create and register an out-of-process background task</span></span>

<span data-ttu-id="8c4bf-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="8c4bf-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]</span><span class="sxs-lookup"><span data-stu-id="8c4bf-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

**<span data-ttu-id="8c4bf-107">重要な API</span><span class="sxs-lookup"><span data-stu-id="8c4bf-107">Important APIs</span></span>**

-   [**<span data-ttu-id="8c4bf-108">IBackgroundTask</span><span class="sxs-lookup"><span data-stu-id="8c4bf-108">IBackgroundTask</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224794)
-   [**<span data-ttu-id="8c4bf-109">BackgroundTaskBuilder</span><span class="sxs-lookup"><span data-stu-id="8c4bf-109">BackgroundTaskBuilder</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224768)
-   [**<span data-ttu-id="8c4bf-110">BackgroundTaskCompletedEventHandler</span><span class="sxs-lookup"><span data-stu-id="8c4bf-110">BackgroundTaskCompletedEventHandler</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224781)

<span data-ttu-id="8c4bf-111">バックグラウンド タスク クラスを作り、アプリがフォアグラウンドにない場合にも実行されるように登録します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-111">Create a background task class and register it to run when your app is not in the foreground.</span></span> <span data-ttu-id="8c4bf-112">このトピックでは、アプリのプロセスとは別のプロセスで実行されるバックグラウンド タスクを作成して登録する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-112">This topic demonstrates how to create and register a background task that runs in a separate process than your app's process.</span></span> <span data-ttu-id="8c4bf-113">フォアグラウンド アプリケーションで直接バックグラウンド作業を実行する方法については、「[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-113">To do background work directly in the foreground application, see [Create and register an in-process background task](create-and-register-an-inproc-background-task.md).</span></span>

> [!Note]
> <span data-ttu-id="8c4bf-114">バックグラウンド タスクを使ってバックグラウンドでメディアを再生する場合、Windows 10 バージョン 1607 で簡単に行うことができる機能強化について、「[バックグラウンドでのメディアの再生](https://msdn.microsoft.com/windows/uwp/audio-video-camera/background-audio)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-114">If you use a background task to play media in the background, see [Play media in the background](https://msdn.microsoft.com/windows/uwp/audio-video-camera/background-audio) for information about improvements in Windows 10, version 1607, that make it much easier.</span></span>

## <a name="create-the-background-task-class"></a><span data-ttu-id="8c4bf-115">バックグラウンド タスク クラスを作る</span><span class="sxs-lookup"><span data-stu-id="8c4bf-115">Create the Background Task class</span></span>

<span data-ttu-id="8c4bf-116">[**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) インターフェイスを実装するクラスを作ると、コードをバックグラウンドで実行できます。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-116">You can run code in the background by writing classes that implement the [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) interface.</span></span> <span data-ttu-id="8c4bf-117">このコードは、[**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839) や [**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517) などを使って特定のイベントをトリガーすると実行されます。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-117">This code will run when a specific event is triggered by using, for example, [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839) or [**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517).</span></span>

<span data-ttu-id="8c4bf-118">次の手順では、[**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) インターフェイスを実装する新しいクラスを記述する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-118">The following steps show you how to write a new class that implements the [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) interface.</span></span> <span data-ttu-id="8c4bf-119">この作業を始める前に、バックグラウンド タスク用の新しいプロジェクトをソリューション内に作ります。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-119">Before getting started, create a new project in your solution for background tasks.</span></span> <span data-ttu-id="8c4bf-120">バックグラウンド タスク用の新しい空のクラスを追加し、[Windows.ApplicationModel.Background](https://msdn.microsoft.com/library/windows/apps/br224847) 名前空間をインポートします。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-120">Add a new empty class for your background task and import the [Windows.ApplicationModel.Background](https://msdn.microsoft.com/library/windows/apps/br224847) namespace.</span></span>

1.  <span data-ttu-id="8c4bf-121">バックグラウンド タスク用に新しいプロジェクトを作ってソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-121">Create a new project for background tasks and add it to your solution.</span></span> <span data-ttu-id="8c4bf-122">このためには、**[ソリューション エクスプローラー]** のソリューション ノードを右クリックし、[追加]、[新しいプロジェクト] を順に選びます。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-122">To do this, right-click on your solution node in the **Solution Explorer** and select Add-&gt;New Project.</span></span> <span data-ttu-id="8c4bf-123">プロジェクトの種類として **Windows ランタイム コンポーネント (ユニバーサル Windows)** を選び、プロジェクトに名前を付け、[OK] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-123">Then select the **Windows Runtime Component (Universal Windows)** project type, name the project, and click OK.</span></span>
2.  <span data-ttu-id="8c4bf-124">ユニバーサル Windows プラットフォーム (UWP) アプリ プロジェクトからバックグラウンド タスク プロジェクトを参照します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-124">Reference the background tasks project from your Universal Windows Platform (UWP) app project.</span></span>

    <span data-ttu-id="8c4bf-125">C++ アプリの場合、アプリ プロジェクトを右クリックし、**[プロパティ]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-125">For a C++ app, right-click on your app project and select **Properties**.</span></span> <span data-ttu-id="8c4bf-126">次に **[共通プロパティ]** に移動します。**[新しい参照の追加]** をクリックし、バックグラウンド タスク プロジェクトの横にあるチェック ボックスをオンにして、両方のダイアログで **[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-126">Then go to **Common Properties** and click **Add New Reference**, check the box next to your background tasks project, and click **OK** on both dialogs.</span></span>

    <span data-ttu-id="8c4bf-127">C# アプリの場合、アプリ プロジェクトで **[参照]** を右クリックして **[新しい参照の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-127">For a C# app, in your app project, right click on **References** and select **Add New Reference**.</span></span> <span data-ttu-id="8c4bf-128">**[ソリューション]** で、**[プロジェクト]** を選び、バックグラウンド タスク プロジェクトの名前を選んで **[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-128">Under **Solution**, select **Projects** and then select the name of your background task project and click **Ok**.</span></span>

3.  <span data-ttu-id="8c4bf-129">[**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) インターフェイスを実装する新しいクラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-129">Create a new class that implements the [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) interface.</span></span> <span data-ttu-id="8c4bf-130">[**Run**](https://msdn.microsoft.com/library/windows/apps/br224811) メソッドは、指定のイベントがトリガーされたときに呼び出される必須のエントリ ポイントです。このメソッドは、各バックグラウンド タスクに必要です。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-130">The [**Run**](https://msdn.microsoft.com/library/windows/apps/br224811) method is a required entry point that will be called when the specified event is triggered; this method is required in every background task.</span></span>

    > [!NOTE]
    > <span data-ttu-id="8c4bf-131">バックグラウンド タスク クラス自体と、バックグラウンド タスク プロジェクト内のその他すべてのクラスは、**sealed** **public** クラスである必要があります。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-131">The background task class itself - and all other classes in the background task project - need to be **public** classes that are **sealed**.</span></span>

    <span data-ttu-id="8c4bf-132">次のサンプル コードは、バックグラウンド タスク クラスの基本的な開始点を示しています。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-132">The following sample code shows a very basic starting point for a background task class:</span></span>

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     //
    >     // ExampleBackgroundTask.cs
    >     //
    >
    >     using Windows.ApplicationModel.Background;
    >
    >     namespace Tasks
    >     {
    >         public sealed class ExampleBackgroundTask : IBackgroundTask
    >         {
    >             public void Run(IBackgroundTaskInstance taskInstance)
    >             {
    >                 
    >             }        
    >         }
    >     }
    > ```
    > ```cpp
    >     //
    >     // ExampleBackgroundTask.h
    >     //
    >
    >     #pragma once
    >
    >     using namespace Windows::ApplicationModel::Background;
    >
    >     namespace RuntimeComponent1
    >     {
    >         public ref class ExampleBackgroundTask sealed : public IBackgroundTask
    >         {
    >
    >         public:
    >             ExampleBackgroundTask();
    >
    >             virtual void Run(IBackgroundTaskInstance^ taskInstance);
    >             void OnCompleted(
    >                     BackgroundTaskRegistration^ task,
    >                     BackgroundTaskCompletedEventArgs^ args
    >                     );
    >         };
    >     }
    >
    >     //
    >     // ExampleBackgroundTask.cpp
    >     //
    >
    >     #include "ExampleBackgroundTask.h"
    >
    >     using namespace Tasks;
    >
    >     void ExampleBackgroundTask::Run(IBackgroundTaskInstance^ taskInstance)
    >     {
    >
    >     }
    >  ```

4.  <span data-ttu-id="8c4bf-133">バックグラウンド タスクで非同期コードを実行する場合は、バックグラウンド タスクで遅延を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-133">If you run any asynchronous code in your background task, then your background task needs to use a deferral.</span></span> <span data-ttu-id="8c4bf-134">遅延を使わない場合、非同期メソッドの呼び出しが完了する前に Run メソッドが終了した場合にバックグラウンド タスク プロセスが予期せずに終了することがあります。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-134">If you don't use a deferral, then the background task process can terminate unexpectedly if the Run method completes before your asynchronous method call has completed.</span></span>

    <span data-ttu-id="8c4bf-135">非同期メソッドを呼び出す前に、Run メソッド中で遅延を要求します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-135">Request the deferral in the Run method before calling the asynchronous method.</span></span> <span data-ttu-id="8c4bf-136">遅延をグローバル変数に保存して、非同期メソッドからアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-136">Save the deferral to a global variable so it can be accessed from the asynchronous method.</span></span> <span data-ttu-id="8c4bf-137">非同期コードが完了した後、遅延を完了するように宣言します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-137">Declare the deferral complete after the asynchronous code completes.</span></span>

    <span data-ttu-id="8c4bf-138">次のサンプル コードでは、遅延を取得して保存し、非同期コードが完了した時点で解放します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-138">The following sample code gets the deferral, saves it, and releases it when the asynchronous code is complete:</span></span>

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     BackgroundTaskDeferral _deferral; // Note: defined at class scope so we can mark it complete inside the OnCancel() callback if we choose to support cancellation
    >     public async void Run(IBackgroundTaskInstance taskInstance)
    >     {
    >         _deferral = taskInstance.GetDeferral()
    >         //
    >         // TODO: Insert code to start one or more asynchronous methods using the
    >         //       await keyword, for example:
    >         //
    >         // await ExampleMethodAsync();
    >         //
    >         
    >         _deferral.Complete();
    >     }
    > ```
    > ```cpp
    >     BackgroundTaskDeferral^ deferral = taskInstance->GetDeferral(); // Note: defined at class scope so we can mark it complete inside the OnCancel() callback if we choose to support cancellation
    >     void ExampleBackgroundTask::Run(IBackgroundTaskInstance^ taskInstance)
    >     {
    >         //
    >         // TODO: Modify the following line of code to call a real async function.
    >         //       Note that the task<void> return type applies only to async
    >         //       actions. If you need to call an async operation instead, replace
    >         //       task<void> with the correct return type.
    >         //
    >         task<void> myTask(ExampleFunctionAsync());
    >         
    >         myTask.then([=] () {
    >             deferral->Complete();
    >         });
    >     }
    > ```

> [!NOTE]
> <span data-ttu-id="8c4bf-139">C# では、**async/await** キーワードを使ってバックグラウンド タスクの非同期メソッドを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-139">In C#, your background task's asynchronous methods can be called using the **async/await** keywords.</span></span> <span data-ttu-id="8c4bf-140">C++ では、タスク チェーンを使うことで同様の結果が得られます。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-140">In C++, a similar result can be achieved by using a task chain.</span></span>

<span data-ttu-id="8c4bf-141">非同期パターンについて詳しくは、「[非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187335)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-141">For more information about asynchronous patterns, see [Asynchronous programming](https://msdn.microsoft.com/library/windows/apps/mt187335).</span></span> <span data-ttu-id="8c4bf-142">遅延を使ってバックグラウンド タスクの早期停止を防ぐ方法に関するその他の例については、[バックグラウンド タスクのサンプルに関するページ](http://go.microsoft.com/fwlink/p/?LinkId=618666)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-142">For additional examples of how to use deferrals to keep a background task from stopping early, see the [background task sample](http://go.microsoft.com/fwlink/p/?LinkId=618666).</span></span>

<span data-ttu-id="8c4bf-143">次の手順はいずれかのアプリ クラス (MainPage.xaml.cs など) で実行します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-143">The following steps are completed in one of your app classes (for example, MainPage.xaml.cs).</span></span>

> [!NOTE]
> <span data-ttu-id="8c4bf-144">バックグラウンド タスクを登録するための専用の関数を作成することもできます (「[バックグラウンド タスクの登録](register-a-background-task.md)」を参照)。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-144">You can also create a function dedicated to registering background tasks - see [Register a background task](register-a-background-task.md).</span></span> <span data-ttu-id="8c4bf-145">その場合、次の 3 つの手順は不要です。単にトリガーを作成し、タスクの名前とエントリ ポイント、(必要に応じて) 条件と併せて登録関数に渡すだけで済みます。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-145">In that case, instead of using the next 3 steps, you can simply construct the trigger and provide it to the registration function along with the task name, task entry point, and (optionally) a condition.</span></span>

## <a name="register-the-background-task-to-run"></a><span data-ttu-id="8c4bf-146">実行するバックグラウンド タスクを登録する</span><span class="sxs-lookup"><span data-stu-id="8c4bf-146">Register the background task to run</span></span>

1.  <span data-ttu-id="8c4bf-147">同じバックグラウンド タスクが登録されていないかどうかを、[**BackgroundTaskRegistration.AllTasks**](https://msdn.microsoft.com/library/windows/apps/br224787) プロパティを反復処理して確認します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-147">Find out if the background task is already registered by iterating through the [**BackgroundTaskRegistration.AllTasks**](https://msdn.microsoft.com/library/windows/apps/br224787) property.</span></span> <span data-ttu-id="8c4bf-148">この確認は重要です。既にあるバックグラウンド タスクの二重登録をアプリで確認しなかった場合、同じタスクが何度も登録され、パフォーマンスが低下したり、タスクの CPU 時間を使い切って処理を完了できなくなるなどの問題が生じます。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-148">This step is important; if your app doesn't check for existing background task registrations, it could easily register the task multiple times, causing issues with performance and maxing out the task's available CPU time before work can complete.</span></span>

    <span data-ttu-id="8c4bf-149">次の例では、AllTasks プロパティを反復処理し、タスクが既に登録されていた場合はフラグ変数を true に設定します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-149">The following example iterates on the AllTasks property and sets a flag variable to true if the task is already registered:</span></span>

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     var taskRegistered = false;
    >     var exampleTaskName = "ExampleBackgroundTask";
    >
    >     foreach (var task in BackgroundTaskRegistration.AllTasks)
    >     {
    >         if (task.Value.Name == exampleTaskName)
    >         {
    >             taskRegistered = true;
    >             break;
    >         }
    >     }
    > ```
    > ```cpp
    >     boolean taskRegistered = false;
    >     Platform::String^ exampleTaskName = "ExampleBackgroundTask";
    >
    >     auto iter = BackgroundTaskRegistration::AllTasks->First();
    >     auto hascur = iter->HasCurrent;
    >
    >     while (hascur)
    >     {
    >         auto cur = iter->Current->Value;
    >
    >         if(cur->Name == exampleTaskName)
    >         {
    >             taskRegistered = true;
    >             break;
    >         }
    >
    >         hascur = iter->MoveNext();
    >     }
    > ```

2.  <span data-ttu-id="8c4bf-150">バックグラウンド タスクがまだ登録されていない場合は、[**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) を使ってバックグラウンド タスクのインスタンスを作成します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-150">If the background task is not already registered, use [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) to create an instance of your background task.</span></span> <span data-ttu-id="8c4bf-151">タスクのエントリ ポイントには、名前空間を含めてバックグラウンド タスク クラスの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-151">The task entry point should be the name of your background task class prefixed by the namespace.</span></span>

    <span data-ttu-id="8c4bf-152">バックグラウンド タスク トリガーは、バックグラウンド タスクが実行されるタイミングを制御します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-152">The background task trigger controls when the background task will run.</span></span> <span data-ttu-id="8c4bf-153">指定できるトリガーの一覧については、「[**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-153">For a list of possible triggers, see [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839).</span></span>

    <span data-ttu-id="8c4bf-154">たとえば、次のコードでは、新しいバックグラウンド タスクを作成し、トリガーとして **TimeZoneChanged** を設定しています。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-154">For example, this code creates a new background task and sets it to run when the **TimeZoneChanged** trigger is fired:</span></span>

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     var builder = new BackgroundTaskBuilder();
    >
    >     builder.Name = exampleTaskName;
    >     builder.TaskEntryPoint = "RuntimeComponent1.ExampleBackgroundTask";
    >     builder.SetTrigger(new SystemTrigger(SystemTriggerType.TimeZoneChange, false));
    > ```
    > ```cpp
    >     auto builder = ref new BackgroundTaskBuilder();
    >
    >     builder->Name = exampleTaskName;
    >     builder->TaskEntryPoint = "RuntimeComponent1.ExampleBackgroundTask";
    >     builder->SetTrigger(ref new SystemTrigger(SystemTriggerType::TimeZoneChange, false));
    > ```

3.  <span data-ttu-id="8c4bf-155">トリガー イベントの発生後、どのようなときにタスクを実行するかという条件を追加することもできます (省略可能)。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-155">You can add a condition to control when your task will run after the trigger event occurs (optional).</span></span> <span data-ttu-id="8c4bf-156">たとえば、ユーザーが存在するときにだけタスクを実行する場合、**UserPresent** という条件を使います。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-156">For example, if you don't want the task to run until the user is present, use the condition **UserPresent**.</span></span> <span data-ttu-id="8c4bf-157">指定できる条件の一覧については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-157">For a list of possible conditions, see [**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835).</span></span>

    <span data-ttu-id="8c4bf-158">次のサンプル コードでは、"ユーザーの存在" を条件として割り当てています。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-158">The following sample code assigns a condition requiring the user to be present:</span></span>

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     builder.AddCondition(new SystemCondition(SystemConditionType.UserPresent));
    > ```
    > ```cpp
    >     builder->AddCondition(ref new SystemCondition(SystemConditionType::UserPresent));
    > ```

4.  <span data-ttu-id="8c4bf-159">[**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) オブジェクトで Register メソッドを呼び出してバックグラウンド タスクを登録します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-159">Register the background task by calling the Register method on the [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) object.</span></span> <span data-ttu-id="8c4bf-160">[**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786) の結果は、次の手順に備えて保存します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-160">Store the [**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786) result so it can be used in the next step.</span></span>

    <span data-ttu-id="8c4bf-161">バックグラウンド タスクを登録し、その結果を保存するコードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-161">The following code registers the background task and stores the result:</span></span>

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     BackgroundTaskRegistration task = builder.Register();
    > ```
    > ```cpp
    >     BackgroundTaskRegistration^ task = builder->Register();
    > ```

> [!NOTE]
> <span data-ttu-id="8c4bf-162">ユニバーサル Windows アプリは、どの種類のバックグラウンド トリガーを登録する場合でも、先に [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-162">Universal Windows apps must call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) before registering any of the background trigger types.</span></span>

<span data-ttu-id="8c4bf-163">更新プログラムのリリース後にユニバーサル Windows アプリが引き続き適切に実行されるようにするには、**ServicingComplete** ([SystemTriggerType](https://msdn.microsoft.com/library/windows/apps/br224839) に関するページをご覧ください) トリガーを使って、アプリのデータベースの移行やバックグラウンド タスクの登録などの更新後の構成の変更を実行します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-163">To ensure that your Universal Windows app continues to run properly after you release an update, use the **ServicingComplete** (see [SystemTriggerType](https://msdn.microsoft.com/library/windows/apps/br224839)) trigger to perform any post-update configuration changes such as migrating the app's database and registering background tasks.</span></span> <span data-ttu-id="8c4bf-164">現時点で、アプリの以前のバージョンに関連付けられたバックグラウンド タスクの登録を解除してから ([**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471) に関するページをご覧ください)、アプリの新しいバージョンのバックグラウンド タスクを登録する ([**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) に関するページをご覧ください) ことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-164">It is best practice to unregister background tasks associated with the previous version of the app (see [**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471)) and register background tasks for the new version of the app (see [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485)) at this time.</span></span>

<span data-ttu-id="8c4bf-165">詳しくは、「[バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-165">For more information, see [Guidelines for background tasks](guidelines-for-background-tasks.md).</span></span>

## <a name="handle-background-task-completion-using-event-handlers"></a><span data-ttu-id="8c4bf-166">イベント ハンドラーでバックグラウンド タスクの完了を処理する</span><span class="sxs-lookup"><span data-stu-id="8c4bf-166">Handle background task completion using event handlers</span></span>

<span data-ttu-id="8c4bf-167">アプリからバックグラウンド タスクの結果を取得できるように、[**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781) にメソッドを登録します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-167">You should register a method with the [**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781), so that your app can get results from the background task.</span></span> <span data-ttu-id="8c4bf-168">アプリが起動、または再開されると、アプリが最後にフォアグラウンドに置かれた後にバックグラウンド タスクが終了していた場合、mark メソッドが呼び出されます</span><span class="sxs-lookup"><span data-stu-id="8c4bf-168">When the app is launched or resumed, the mark method will be called if the background task has completed since the last time the app was in the foreground.</span></span> <span data-ttu-id="8c4bf-169">(アプリがフォアグラウンドにある間にバックグラウンド タスクが終了した場合は、OnCompleted メソッドが直ちに呼び出されます)。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-169">(The OnCompleted method will be called immediately if the background task completes while your app is currently in the foreground.)</span></span>

1.  <span data-ttu-id="8c4bf-170">バックグラウンド タスクの完了を処理する OnCompleted メソッドを記述します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-170">Write an OnCompleted method to handle the completion of background tasks.</span></span> <span data-ttu-id="8c4bf-171">たとえば、バックグラウンド タスクの結果により UI を更新できます。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-171">For example, the background task result might cause a UI update.</span></span> <span data-ttu-id="8c4bf-172">ここに示すメソッドのフットプリントは、この例では *args* パラメーターは使われていませんが、OnCompleted イベント ハンドラー メソッドで必須になります。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-172">The method footprint shown here is required for the OnCompleted event handler method, even though this example does not use the *args* parameter.</span></span>

    <span data-ttu-id="8c4bf-173">次のサンプル コードは、バックグラウンド タスクの完了を認識し、メッセージ文字列を使う UI 更新メソッドの例を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-173">The following sample code recognizes background task completion and calls an example UI update method that takes a message string.</span></span>

     > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
    >     {
    >         var settings = Windows.Storage.ApplicationData.Current.LocalSettings;
    >         var key = task.TaskId.ToString();
    >         var message = settings.Values[key].ToString();
    >         UpdateUI(message);
    >     }
    > ```
    > ```cpp
    >     void ExampleBackgroundTask::OnCompleted(BackgroundTaskRegistration^ task, BackgroundTaskCompletedEventArgs^ args)
    >     {
    >         auto settings = ApplicationData::Current->LocalSettings->Values;
    >         auto key = task->TaskId.ToString();
    >         auto message = dynamic_cast<String^>(settings->Lookup(key));
    >         UpdateUI(message);
    >     }
    > ```

    > [!NOTE]
    > <span data-ttu-id="8c4bf-174">UI の更新は、UI スレッドを拘束することがないように、非同期で実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-174">UI updates should be performed asynchronously, to avoid holding up the UI thread.</span></span> <span data-ttu-id="8c4bf-175">例については、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)の UpdateUI メソッドを参照してください。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-175">For an example, see the UpdateUI method in the [background task sample](http://go.microsoft.com/fwlink/p/?LinkId=618666).</span></span>


2.  <span data-ttu-id="8c4bf-176">バックグラウンド タスクを登録した位置に戻ります。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-176">Go back to where you registered the background task.</span></span> <span data-ttu-id="8c4bf-177">そのコード行の後に、新しい [**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781) オブジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-177">After that line of code, add a new [**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781) object.</span></span> <span data-ttu-id="8c4bf-178">**BackgroundTaskCompletedEventHandler** コンストラクターのパラメーターとして OnCompleted メソッドを指定します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-178">Provide your OnCompleted method as the parameter for the **BackgroundTaskCompletedEventHandler** constructor.</span></span>

    <span data-ttu-id="8c4bf-179">次のサンプル コードにより、[**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786) に [**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781) が追加されます。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-179">The following sample code adds a [**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781) to the [**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786):</span></span>

     > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     task.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted);
    > ```
    > ```cpp
    >     task->Completed += ref new BackgroundTaskCompletedEventHandler(this, &ExampleBackgroundTask::OnCompleted);
    > ```

## <a name="declare-that-your-app-uses-background-tasks-in-the-app-manifest"></a><span data-ttu-id="8c4bf-180">アプリがバックグラウンド タスクを使うことをアプリ マニフェストで宣言する</span><span class="sxs-lookup"><span data-stu-id="8c4bf-180">Declare that your app uses background tasks in the app manifest</span></span>

<span data-ttu-id="8c4bf-181">アプリでバックグラウンド タスクを実行する前に、各バックグラウンド タスクをアプリ マニフェストで宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-181">Before your app can run background tasks, you must declare each background task in the app manifest.</span></span> <span data-ttu-id="8c4bf-182">マニフェストに記載されていないトリガーでバックグラウンド タスクの登録を試みると、登録は失敗します。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-182">If your app attempts to register a background task with a trigger that isn't listed in the manifest, the registration will fail.</span></span>

1.  <span data-ttu-id="8c4bf-183">Package.appxmanifest という名前のファイルを開いて、パッケージ マニフェスト デザイナーを開きます。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-183">Open the package manifest designer by opening the file named Package.appxmanifest.</span></span>
2.  <span data-ttu-id="8c4bf-184">**[宣言]** タブを開きます。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-184">Open the **Declarations** tab.</span></span>
3.  <span data-ttu-id="8c4bf-185">**[使用可能な宣言]** ボックスの一覧の **[バックグラウンド タスク]** を選び、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-185">From the **Available Declarations** drop-down, select **Background Tasks** and click **Add**.</span></span>
4.  <span data-ttu-id="8c4bf-186">**[システム イベント]** チェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-186">Select the **System event** checkbox.</span></span>
5.  <span data-ttu-id="8c4bf-187">**[エントリ ポイント]** ボックスに、バックグラウンド クラスの名前空間と名前を入力します。この例の場合、RuntimeComponent1.ExampleBackgroundTask です。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-187">In the **Entry point:** textbox, enter the namespace and name of your background class which is for this example is RuntimeComponent1.ExampleBackgroundTask.</span></span>
6.  <span data-ttu-id="8c4bf-188">マニフェスト デザイナーを閉じます。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-188">Close the manfiest designer.</span></span>

    <span data-ttu-id="8c4bf-189">バック グラウンド タスクを登録するために、次の Extensions 要素が Package.appxmanifest ファイルに追加されます。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-189">The following Extensions element is added to your Package.appxmanifest file to register the background task:</span></span>

    ```xml
    <Extensions>
      <Extension Category="windows.backgroundTasks" EntryPoint="RuntimeComponent1.ExampleBackgroundTask">
        <BackgroundTasks>
          <Task Type="systemEvent" />
        </BackgroundTasks>
      </Extension>
    </Extensions>
    ```

## <a name="summary-and-next-steps"></a><span data-ttu-id="8c4bf-190">要約と次のステップ</span><span class="sxs-lookup"><span data-stu-id="8c4bf-190">Summary and next steps</span></span>

<span data-ttu-id="8c4bf-191">ここでは、バックグラウンド タスク クラスの記述方法、アプリ内からバックグラウンド タスクを登録する方法、バックグラウンド タスクが完了したことをアプリで認識する方法の基本について学習しました。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-191">You should now understand the basics of how to write a background task class, how to register the background task from within your app, and how to make your app recognize when the background task is complete.</span></span> <span data-ttu-id="8c4bf-192">また、アプリで適切にバックグラウンド タスクを登録できるように、アプリ マニフェストを更新する方法についても学習しました。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-192">You should also understand how to update the application manifest so that your app can successfully register the background task.</span></span>

> [!NOTE]
> <span data-ttu-id="8c4bf-193">[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)をダウンロードして、バックグラウンド タスクを使う完全で堅牢な UWP アプリのコンテキストで類似のコード例を確認してください。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-193">Download the [background task sample](http://go.microsoft.com/fwlink/p/?LinkId=618666) to see similar code examples in the context of a complete and robust UWP app that uses background tasks.</span></span>

<span data-ttu-id="8c4bf-194">API リファレンス、バックグラウンド タスクの概念的ガイダンス、バックグラウンド タスクを使ったアプリの作成に関する詳しい説明については、次の関連するトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-194">See the following related topics for API reference, background task conceptual guidance, and more detailed instructions for writing apps that use background tasks.</span></span>

> [!NOTE]
> <span data-ttu-id="8c4bf-195">この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-195">This article is for Windows 10 developers writing Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="8c4bf-196">Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-196">If you’re developing for Windows 8.x or Windows Phone 8.x, see the [archived documentation](http://go.microsoft.com/fwlink/p/?linkid=619132).</span></span>

## <a name="related-topics"></a><span data-ttu-id="8c4bf-197">関連トピック</span><span class="sxs-lookup"><span data-stu-id="8c4bf-197">Related topics</span></span>

**<span data-ttu-id="8c4bf-198">バックグラウンド タスクに関する手順を詳しく説明するトピック</span><span class="sxs-lookup"><span data-stu-id="8c4bf-198">Detailed background task instructional topics</span></span>**

* [<span data-ttu-id="8c4bf-199">バックグラウンド タスクによるシステム イベントへの応答</span><span class="sxs-lookup"><span data-stu-id="8c4bf-199">Respond to system events with background tasks</span></span>](respond-to-system-events-with-background-tasks.md)
* [<span data-ttu-id="8c4bf-200">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="8c4bf-200">Register a background task</span></span>](register-a-background-task.md)
* [<span data-ttu-id="8c4bf-201">バックグラウンド タスクを実行するための条件の設定</span><span class="sxs-lookup"><span data-stu-id="8c4bf-201">Set conditions for running a background task</span></span>](set-conditions-for-running-a-background-task.md)
* [<span data-ttu-id="8c4bf-202">メンテナンス トリガーの使用</span><span class="sxs-lookup"><span data-stu-id="8c4bf-202">Use a maintenance trigger</span></span>](use-a-maintenance-trigger.md)
* [<span data-ttu-id="8c4bf-203">取り消されたバックグラウンド タスクの処理</span><span class="sxs-lookup"><span data-stu-id="8c4bf-203">Handle a cancelled background task</span></span>](handle-a-cancelled-background-task.md)
* [<span data-ttu-id="8c4bf-204">バックグラウンド タスクの進捗状況と完了の監視</span><span class="sxs-lookup"><span data-stu-id="8c4bf-204">Monitor background task progress and completion</span></span>](monitor-background-task-progress-and-completion.md)
* [<span data-ttu-id="8c4bf-205">タイマーでのバックグラウンド タスクの実行</span><span class="sxs-lookup"><span data-stu-id="8c4bf-205">Run a background task on a timer</span></span>](run-a-background-task-on-a-timer-.md)
* <span data-ttu-id="8c4bf-206">[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)。</span><span class="sxs-lookup"><span data-stu-id="8c4bf-206">[Create and register an in-process background task](create-and-register-an-inproc-background-task.md).</span></span>
* [<span data-ttu-id="8c4bf-207">アウトプロセスのバックグラウンド タスクをインプロセスのバックグラウンド タスクへ変換</span><span class="sxs-lookup"><span data-stu-id="8c4bf-207">Convert an out-of-process background task to an in-process background task</span></span>](convert-out-of-process-background-task.md)  

**<span data-ttu-id="8c4bf-208">バックグラウンド タスクのガイダンス</span><span class="sxs-lookup"><span data-stu-id="8c4bf-208">Background task guidance</span></span>**

* [<span data-ttu-id="8c4bf-209">バックグラウンド タスクのガイドライン</span><span class="sxs-lookup"><span data-stu-id="8c4bf-209">Guidelines for background tasks</span></span>](guidelines-for-background-tasks.md)
* [<span data-ttu-id="8c4bf-210">バックグラウンド タスクのデバッグ</span><span class="sxs-lookup"><span data-stu-id="8c4bf-210">Debug a background task</span></span>](debug-a-background-task.md)
* [<span data-ttu-id="8c4bf-211">Windows ストア アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)</span><span class="sxs-lookup"><span data-stu-id="8c4bf-211">How to trigger suspend, resume, and background events in Windows Store apps (when debugging)</span></span>](http://go.microsoft.com/fwlink/p/?linkid=254345)

**<span data-ttu-id="8c4bf-212">バックグラウンド タスクの API リファレンス</span><span class="sxs-lookup"><span data-stu-id="8c4bf-212">Background Task API Reference</span></span>**

* [**<span data-ttu-id="8c4bf-213">Windows.ApplicationModel.Background</span><span class="sxs-lookup"><span data-stu-id="8c4bf-213">Windows.ApplicationModel.Background</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224847)
