---
author: TylerMSFT
title: インプロセス バックグラウンド タスクの作成と登録
description: フォアグラウンド アプリと同じプロセスで実行されるインプロセスのタスクを作成して登録します。
ms.author: twhitney
ms.date: 11/03/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: バック グラウンド タスクの windows 10, uwp,
ms.assetid: d99de93b-e33b-45a9-b19f-31417f1e9354
ms.localizationpriority: medium
ms.openlocfilehash: 5879977662dc2bd609d09e5fe53fc2a2f0b9180f
ms.sourcegitcommit: c4d3115348c8b54fcc92aae8e18fdabc3deb301d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/22/2018
ms.locfileid: "5398918"
---
# <a name="create-and-register-an-in-process-background-task"></a><span data-ttu-id="8c39b-104">インプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="8c39b-104">Create and register an in-process background task</span></span>

**<span data-ttu-id="8c39b-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="8c39b-105">Important APIs</span></span>**

-   [**<span data-ttu-id="8c39b-106">IBackgroundTask</span><span class="sxs-lookup"><span data-stu-id="8c39b-106">IBackgroundTask</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224794)
-   [**<span data-ttu-id="8c39b-107">BackgroundTaskBuilder</span><span class="sxs-lookup"><span data-stu-id="8c39b-107">BackgroundTaskBuilder</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224768)
-   [**<span data-ttu-id="8c39b-108">BackgroundTaskCompletedEventHandler</span><span class="sxs-lookup"><span data-stu-id="8c39b-108">BackgroundTaskCompletedEventHandler</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224781)

<span data-ttu-id="8c39b-109">このトピックでは、アプリと同じプロセスで実行されるバックグラウンド タスクを作成して登録する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="8c39b-109">This topic demonstrates how to create and register a background task that runs in the same process as your app.</span></span>

<span data-ttu-id="8c39b-110">インプロセスのバック グラウンド タスクはアウトプロセスのバック グラウンド タスクよりも実装が簡単です。</span><span class="sxs-lookup"><span data-stu-id="8c39b-110">In-process background tasks are simpler to implement than out-of-process background tasks.</span></span> <span data-ttu-id="8c39b-111">ただし、インプロセスのバックグラウンド タスクでは回復力が低下します。</span><span class="sxs-lookup"><span data-stu-id="8c39b-111">However, they are less resilient.</span></span> <span data-ttu-id="8c39b-112">インプロセスのバックグラウンド タスクで実行中のコードがクラッシュすると、アプリがダウンします。</span><span class="sxs-lookup"><span data-stu-id="8c39b-112">If the code running in an in-process background task crashes, it will take down your app.</span></span> <span data-ttu-id="8c39b-113">また、[DeviceUseTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx)、[DeviceServicingTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx)、**IoTStartupTask** はインプロセス モデルで使用できないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="8c39b-113">Also note that [DeviceUseTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx), [DeviceServicingTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx) and **IoTStartupTask** cannot be used with the in-process model.</span></span> <span data-ttu-id="8c39b-114">アプリケーション内で VoIP バックグラウンド タスクをアクティブ化することもできません。</span><span class="sxs-lookup"><span data-stu-id="8c39b-114">Activating a VoIP background task within your application is also not possible.</span></span> <span data-ttu-id="8c39b-115">これらのトリガーとタスクは、アウトプロセスのバックグラウンド タスク モデルを使用してサポートされています。</span><span class="sxs-lookup"><span data-stu-id="8c39b-115">These triggers and tasks are still supported using the out-of-process background task model.</span></span>

<span data-ttu-id="8c39b-116">バックグラウンド アクティビティは、実行時間制限を超えて実行された場合に、アプリのフォアグラウンド プロセス内で実行されているときでも終了できます。</span><span class="sxs-lookup"><span data-stu-id="8c39b-116">Be aware that background activity can be terminated even when running inside the app's foreground process if it runs past execution time limits.</span></span> <span data-ttu-id="8c39b-117">特定の目的では、別のプロセスで実行するバックグラウンド タスクに作業を分離した場合の回復性が有用です。</span><span class="sxs-lookup"><span data-stu-id="8c39b-117">For some purposes the resiliency of separating work into a background task that runs in a separate process is still useful.</span></span> <span data-ttu-id="8c39b-118">バックグラウンドの作業をフォアグラウンド アプリケーションとは別のタスクとして保持することは、フォアグラウンド アプリケーションとの通信を必要としない作業にとって最適なオプションである可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8c39b-118">Keeping background work as a task separate from the foreground application may be the best option for work that does not require communication with the foreground application.</span></span>

## <a name="fundamentals"></a><span data-ttu-id="8c39b-119">基本事項</span><span class="sxs-lookup"><span data-stu-id="8c39b-119">Fundamentals</span></span>

<span data-ttu-id="8c39b-120">インプロセス モデルでは、アプリがフォアグラウンドまたはバックグラウンドで実行されるときの改善された通知によってアプリケーションのライフサイクルが強化されます。</span><span class="sxs-lookup"><span data-stu-id="8c39b-120">The in-process model enhances the application lifecycle with improved notifications for when your app is in the foreground or in the background.</span></span> <span data-ttu-id="8c39b-121">これらの切り替え用に、Application オブジェクトから [**EnteredBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.EnteredBackground) と [**LeavingBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.LeavingBackground) という 2 つの新しいイベントを使用できます。</span><span class="sxs-lookup"><span data-stu-id="8c39b-121">Two new events are available from the Application object for these transitions: [**EnteredBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.EnteredBackground) and [**LeavingBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.LeavingBackground).</span></span> <span data-ttu-id="8c39b-122">これらのイベントは、アプリケーションの表示状態に基づくアプリケーションのライフサイクルに適合します。これらのイベントの詳細とアプリケーションのライフサイクルに与える影響については、[アプリのライフサイクル](app-lifecycle.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8c39b-122">These events fit into the application lifecycle based on the visibility state of your application Read more about these events and how they affect the application lifecycle at [App lifecycle](app-lifecycle.md).</span></span>

<span data-ttu-id="8c39b-123">大まかに言うと、**EnteredBackground** イベントは、アプリがバックグラウンドで実行されている間に実行されるコードを実行します。また、**LeavingBackground** イベントは、アプリがフォアグラウンドに移動したことを知るために処理します。</span><span class="sxs-lookup"><span data-stu-id="8c39b-123">At a high level, you will handle the **EnteredBackground** event to run your code that will execute while your app is running in the background, and handle **LeavingBackground** to know when your app has moved to the foreground.</span></span>

## <a name="register-your-background-task-trigger"></a><span data-ttu-id="8c39b-124">バックグラウンド タスク トリガーを登録する</span><span class="sxs-lookup"><span data-stu-id="8c39b-124">Register your background task trigger</span></span>

<span data-ttu-id="8c39b-125">インプロセスのバックグラウンド アクティビティの登録は、アウトプロセスのバックグラウンド アクティビティを登録する方法とほぼ同じです。</span><span class="sxs-lookup"><span data-stu-id="8c39b-125">In-process background activity is registered much the same as out-of-process background activity.</span></span> <span data-ttu-id="8c39b-126">すべてのバックグラウンド トリガーは、[BackgroundTaskBuilder](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundtaskbuilder.aspx?f=255&MSPPError=-2147217396) を使用した登録から始まります。</span><span class="sxs-lookup"><span data-stu-id="8c39b-126">All background triggers start with registration using the [BackgroundTaskBuilder](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundtaskbuilder.aspx?f=255&MSPPError=-2147217396).</span></span> <span data-ttu-id="8c39b-127">ビルダーを使用すると、必要なすべての値を 1 か所で設定できるため、簡単にバックグラウンド タスクを登録できます。</span><span class="sxs-lookup"><span data-stu-id="8c39b-127">The builder makes it easy to register a background task by setting all required values in one place:</span></span>

> [!div class="tabbedCodeSnippets"]
> ```cs
> var builder = new BackgroundTaskBuilder();
> builder.Name = "My Background Trigger";
> builder.SetTrigger(new TimeTrigger(15, true));
> // Do not set builder.TaskEntryPoint for in-process background tasks
> // Here we register the task and work will start based on the time trigger.
> BackgroundTaskRegistration task = builder.Register();
> ```

> [!NOTE]
> <span data-ttu-id="8c39b-128">ユニバーサル Windows アプリは、どの種類のバックグラウンド トリガーを登録する場合でも、先に [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="8c39b-128">Universal Windows apps must call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) before registering any of the background trigger types.</span></span>
> <span data-ttu-id="8c39b-129">更新プログラムのリリース後にユニバーサル Windows アプリが引き続き適切に実行されるようにするには、更新後にアプリが起動する際に、[**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471)、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) の順に呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="8c39b-129">To ensure that your Universal Windows app continues to run properly after you release an update, you must call [**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471) and then call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) when your app launches after being updated.</span></span> <span data-ttu-id="8c39b-130">詳しくは、「[バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8c39b-130">For more information, see [Guidelines for background tasks](guidelines-for-background-tasks.md).</span></span>

<span data-ttu-id="8c39b-131">インプロセスのバックグラウンド アクティビティの場合は `TaskEntryPoint.` を設定しません。この値を設定しないと、[OnBackgroundActivated()](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx) と呼ばれる、Application オブジェクトの新しい保護されたメソッドが既定のエントリ ポイントとして有効になります。</span><span class="sxs-lookup"><span data-stu-id="8c39b-131">For in-process background activities you do not set `TaskEntryPoint.` Leaving it blank enables the default entry point, a new protected method on the Application object called [OnBackgroundActivated()](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx).</span></span>

<span data-ttu-id="8c39b-132">登録したトリガーは、[SetTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundtaskbuilder.settrigger.aspx) メソッドで設定されたトリガーの種類に基づいて発生します。</span><span class="sxs-lookup"><span data-stu-id="8c39b-132">Once a trigger is registered, it will fire based on the type of trigger set in the [SetTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundtaskbuilder.settrigger.aspx) method.</span></span> <span data-ttu-id="8c39b-133">上記の例では、[TimeTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.timetrigger.aspx) が使用されています。これは、登録された時点から 15 分後に発生します。</span><span class="sxs-lookup"><span data-stu-id="8c39b-133">In the example above a [TimeTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.timetrigger.aspx) is used, which will fire fifteen minutes from the time it was registered.</span></span>

## <a name="add-a-condition-to-control-when-your-task-will-run-optional"></a><span data-ttu-id="8c39b-134">どのようなときにタスクを実行するかという条件を追加する (省略可能)</span><span class="sxs-lookup"><span data-stu-id="8c39b-134">Add a condition to control when your task will run (optional)</span></span>

<span data-ttu-id="8c39b-135">トリガー イベントの発生後、どのようなときにタスクを実行するかという条件を追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="8c39b-135">You can add a condition to control when your task will run after the trigger event occurs.</span></span> <span data-ttu-id="8c39b-136">たとえば、ユーザーが存在するときにだけタスクを実行する場合、**UserPresent** という条件を使います。</span><span class="sxs-lookup"><span data-stu-id="8c39b-136">For example, if you don't want the task to run until the user is present, use the condition **UserPresent**.</span></span> <span data-ttu-id="8c39b-137">指定できる条件の一覧については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8c39b-137">For a list of possible conditions, see [**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835).</span></span>

<span data-ttu-id="8c39b-138">次のサンプル コードでは、"ユーザーの存在" を条件として割り当てています。</span><span class="sxs-lookup"><span data-stu-id="8c39b-138">The following sample code assigns a condition requiring the user to be present:</span></span>

> [!div class="tabbedCodeSnippets"]
> ```cs
> builder.AddCondition(new SystemCondition(SystemConditionType.UserPresent));
> ```

## <a name="place-your-background-activity-code-in-onbackgroundactivated"></a><span data-ttu-id="8c39b-139">バックグラウンド アクティビティのコードを OnBackgroundActivated() に配置する</span><span class="sxs-lookup"><span data-stu-id="8c39b-139">Place your background activity code in OnBackgroundActivated()</span></span>

<span data-ttu-id="8c39b-140">[OnBackgroundActivated](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx)発生したときに、バック グラウンド トリガーに応答するには、バック グラウンド アクティビティのコードを配置します。</span><span class="sxs-lookup"><span data-stu-id="8c39b-140">Put your background activity code in [OnBackgroundActivated](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx) to respond to your background trigger when it fires.</span></span> <span data-ttu-id="8c39b-141">**OnBackgroundActivated**は[IBackgroundTask.Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx?f=255&MSPPError=-2147217396)と同じように扱うことができます。</span><span class="sxs-lookup"><span data-stu-id="8c39b-141">**OnBackgroundActivated** can be treated just like [IBackgroundTask.Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx?f=255&MSPPError=-2147217396).</span></span> <span data-ttu-id="8c39b-142">メソッドでは、 **Run**メソッドを提供するすべての情報が含まれている、 [BackgroundActivatedEventArgs](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.activation.backgroundactivatedeventargs.aspx)パラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="8c39b-142">The method has a [BackgroundActivatedEventArgs](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.activation.backgroundactivatedeventargs.aspx) parameter, which contains everything that the **Run** method delivers.</span></span> <span data-ttu-id="8c39b-143">たとえば、App.xaml.cs: で</span><span class="sxs-lookup"><span data-stu-id="8c39b-143">For example, in App.xaml.cs:</span></span>

``` cs
using Windows.ApplicationModel.Background;

...

sealed partial class App : Application
{
  ...

  protected override void OnBackgroundActivated(BackgroundActivatedEventArgs args)
  {
      base.OnBackgroundActivated(args);
      IBackgroundTaskInstance taskInstance = args.TaskInstance;
      DoYourBackgroundWork(taskInstance);  
  }
}
```

<span data-ttu-id="8c39b-144">豊富な**OnBackgroundActivated**の例では、[アプリ サービスをホスト アプリと同じプロセスで実行する変換](convert-app-service-in-process.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8c39b-144">For a richer **OnBackgroundActivated** example, see [Convert an app service to run in the same process as its host app](convert-app-service-in-process.md).</span></span>

## <a name="handle-background-task-progress-and-completion"></a><span data-ttu-id="8c39b-145">バックグラウンド タスクの進捗状況と完了を処理する</span><span class="sxs-lookup"><span data-stu-id="8c39b-145">Handle background task progress and completion</span></span>

<span data-ttu-id="8c39b-146">タスクの進捗状況と完了は、マルチプロセスのバックグラウンド タスクの場合と同じ方法で監視できます (「[バックグラウンド タスクの進捗状況と完了の監視](monitor-background-task-progress-and-completion.md)」をご覧ください)。ただし、変数を使うと、より簡単にアプリで進捗状況または完了状態を追跡できます。</span><span class="sxs-lookup"><span data-stu-id="8c39b-146">Task progress and completion can be monitored the same way as for multi-process background tasks (see [Monitor background task progress and completion](monitor-background-task-progress-and-completion.md)) but you will likely find that you can more easily track them by using variables to track progress or completion status in your app.</span></span> <span data-ttu-id="8c39b-147">これは、アプリと同じプロセスでバックグラウンド アクティビティのコードを実行する利点の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="8c39b-147">This is one of the advantages of having your background activity code running in the same process as your app.</span></span>

## <a name="handle-background-task-cancellation"></a><span data-ttu-id="8c39b-148">バックグラウンド タスクの取り消しを処理する</span><span class="sxs-lookup"><span data-stu-id="8c39b-148">Handle background task cancellation</span></span>

<span data-ttu-id="8c39b-149">インプロセスのバックグラウンド タスクは、アウトプロセスのバックグラウンド タスクの場合と同じ方法で取り消すことができます (「[取り消されたバックグラウンド タスクの処理](handle-a-cancelled-background-task.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="8c39b-149">In-process background tasks are cancelled the same way as out-of-process background tasks are (see [Handle a cancelled background task](handle-a-cancelled-background-task.md)).</span></span> <span data-ttu-id="8c39b-150">取り消しが発生する前に **BackgroundActivated** イベント ハンドラーを終了する必要があります。そうでないと、プロセス全体が終了します。</span><span class="sxs-lookup"><span data-stu-id="8c39b-150">Be aware that your **BackgroundActivated** event handler must exit before the cancellation occurs, or the whole process will be terminated.</span></span> <span data-ttu-id="8c39b-151">バックグラウンド タスクを取り消したときにフォアグラウンド アプリが予期せずに終了する場合は、取り消しが発生する前にハンドラーが終了していることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="8c39b-151">If your foreground app closes unexpectedly when you cancel the background task, verify that your handler exited before the cancellation occured.</span></span>

## <a name="the-manifest"></a><span data-ttu-id="8c39b-152">マニフェスト</span><span class="sxs-lookup"><span data-stu-id="8c39b-152">The manifest</span></span>

<span data-ttu-id="8c39b-153">アウトプロセスのバックグラウンド タスクとは異なり、インプロセスのバックグラウンド タスクを実行するためにパッケージ マニフェストにバックグラウンド タスクの情報を追加する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="8c39b-153">Unlike out-of-process background tasks, you are not required to add background task information to the package manifest in order to run in-process background tasks.</span></span>

## <a name="summary-and-next-steps"></a><span data-ttu-id="8c39b-154">要約と次のステップ</span><span class="sxs-lookup"><span data-stu-id="8c39b-154">Summary and next steps</span></span>

<span data-ttu-id="8c39b-155">インプロセスのバックグラウンド タスクを作成する方法の基本を説明しました。</span><span class="sxs-lookup"><span data-stu-id="8c39b-155">You should now understand the basics of how to write a in-process background task.</span></span>

<span data-ttu-id="8c39b-156">API リファレンス、バックグラウンド タスクの概念的ガイダンス、バックグラウンド タスクを使ったアプリの作成に関する詳しい説明については、次の関連するトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8c39b-156">See the following related topics for API reference, background task conceptual guidance, and more detailed instructions for writing apps that use background tasks.</span></span>

## <a name="related-topics"></a><span data-ttu-id="8c39b-157">関連トピック</span><span class="sxs-lookup"><span data-stu-id="8c39b-157">Related topics</span></span>

**<span data-ttu-id="8c39b-158">バックグラウンド タスクに関する手順を詳しく説明するトピック</span><span class="sxs-lookup"><span data-stu-id="8c39b-158">Detailed background task instructional topics</span></span>**

* [<span data-ttu-id="8c39b-159">アウトプロセスのバックグラウンド タスクをインプロセスのバックグラウンド タスクへ変換</span><span class="sxs-lookup"><span data-stu-id="8c39b-159">Convert an out-of-process background task to an in-process background task</span></span>](convert-out-of-process-background-task.md)
* [<span data-ttu-id="8c39b-160">アウトプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="8c39b-160">Create and register an out-of-process background task</span></span>](create-and-register-a-background-task.md)
* [<span data-ttu-id="8c39b-161">バックグラウンドでのメディアの再生</span><span class="sxs-lookup"><span data-stu-id="8c39b-161">Play media in the background</span></span>](https://msdn.microsoft.com/windows/uwp/audio-video-camera/background-audio)
* [<span data-ttu-id="8c39b-162">バックグラウンド タスクによるシステム イベントへの応答</span><span class="sxs-lookup"><span data-stu-id="8c39b-162">Respond to system events with background tasks</span></span>](respond-to-system-events-with-background-tasks.md)
* [<span data-ttu-id="8c39b-163">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="8c39b-163">Register a background task</span></span>](register-a-background-task.md)
* [<span data-ttu-id="8c39b-164">バックグラウンド タスクを実行するための条件の設定</span><span class="sxs-lookup"><span data-stu-id="8c39b-164">Set conditions for running a background task</span></span>](set-conditions-for-running-a-background-task.md)
* [<span data-ttu-id="8c39b-165">メンテナンス トリガーの使用</span><span class="sxs-lookup"><span data-stu-id="8c39b-165">Use a maintenance trigger</span></span>](use-a-maintenance-trigger.md)
* [<span data-ttu-id="8c39b-166">取り消されたバックグラウンド タスクの処理</span><span class="sxs-lookup"><span data-stu-id="8c39b-166">Handle a cancelled background task</span></span>](handle-a-cancelled-background-task.md)
* [<span data-ttu-id="8c39b-167">バックグラウンド タスクの進捗状況と完了の監視</span><span class="sxs-lookup"><span data-stu-id="8c39b-167">Monitor background task progress and completion</span></span>](monitor-background-task-progress-and-completion.md)
* [<span data-ttu-id="8c39b-168">タイマーでのバックグラウンド タスクの実行</span><span class="sxs-lookup"><span data-stu-id="8c39b-168">Run a background task on a timer</span></span>](run-a-background-task-on-a-timer-.md)

**<span data-ttu-id="8c39b-169">バックグラウンド タスクのガイダンス</span><span class="sxs-lookup"><span data-stu-id="8c39b-169">Background task guidance</span></span>**

* [<span data-ttu-id="8c39b-170">バックグラウンド タスクのガイドライン</span><span class="sxs-lookup"><span data-stu-id="8c39b-170">Guidelines for background tasks</span></span>](guidelines-for-background-tasks.md)
* [<span data-ttu-id="8c39b-171">バックグラウンド タスクのデバッグ</span><span class="sxs-lookup"><span data-stu-id="8c39b-171">Debug a background task</span></span>](debug-a-background-task.md)
* [<span data-ttu-id="8c39b-172">UWP アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)</span><span class="sxs-lookup"><span data-stu-id="8c39b-172">How to trigger suspend, resume, and background events in UWP apps (when debugging)</span></span>](http://go.microsoft.com/fwlink/p/?linkid=254345)

**<span data-ttu-id="8c39b-173">バックグラウンド タスクの API リファレンス</span><span class="sxs-lookup"><span data-stu-id="8c39b-173">Background Task API Reference</span></span>**

* [**<span data-ttu-id="8c39b-174">Windows.ApplicationModel.Background</span><span class="sxs-lookup"><span data-stu-id="8c39b-174">Windows.ApplicationModel.Background</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224847)
