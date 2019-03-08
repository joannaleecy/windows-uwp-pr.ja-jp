---
title: タイマーでのバックグラウンド タスクの実行
description: 1 回限りのバックグラウンド タスクをスケジュールする方法、または定期的なバックグラウンド タスクを実行する方法について説明します。
ms.assetid: 0B7F0BFF-535A-471E-AC87-783C740A61E9
ms.date: 07/06/2018
ms.topic: article
keywords: windows 10、uwp、バック グラウンド タスク
ms.localizationpriority: medium
ms.openlocfilehash: 46d2b5704fa8a9bf53534ded98647ce57da0f520
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661897"
---
# <a name="run-a-background-task-on-a-timer"></a><span data-ttu-id="7519d-104">タイマーでのバックグラウンド タスクの実行</span><span class="sxs-lookup"><span data-stu-id="7519d-104">Run a background task on a timer</span></span>

<span data-ttu-id="7519d-105">[  **TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843) を使用して 1 回限りのバックグラウンド タスクをスケジュールする方法、または定期的なバックグラウンド タスクを実行する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="7519d-105">Learn how to use the [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843) to schedule a one-time background task, or run a periodic background task.</span></span>

<span data-ttu-id="7519d-106">このトピックで説明する、時間でトリガーされるバックグラウンド タスクを実装する方法の例については、[バックグラウンドのアクティブ化のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BackgroundActivation)の **Scenario4** を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7519d-106">See **Scenario4** in the [Background activation sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BackgroundActivation) to see an example of how to implement the time triggered background task described in this topic.</span></span>

<span data-ttu-id="7519d-107">このトピックは、定期的に、または特定の時刻に実行する必要があるバックグラウンド タスクがあることを前提にしています。</span><span class="sxs-lookup"><span data-stu-id="7519d-107">This topic assumes that you have a background task that needs to run periodically, or at a specific time.</span></span> <span data-ttu-id="7519d-108">まだバックグラウンド タスクがない場合は、[BackgroundActivity.cs](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/BackgroundActivation/cs/BackgroundActivity.cs) にサンプルのバックグラウンド タスクがあります。</span><span class="sxs-lookup"><span data-stu-id="7519d-108">If you don't already have a background task, there is a sample background task at [BackgroundActivity.cs](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/BackgroundActivation/cs/BackgroundActivity.cs).</span></span> <span data-ttu-id="7519d-109">または、「[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)」または「[アウトプロセス バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)」の手順に従って作成してください。</span><span class="sxs-lookup"><span data-stu-id="7519d-109">Or, follow the steps in [Create and register an in-process background task](create-and-register-an-inproc-background-task.md) or [Create and register an out-of-process background task](create-and-register-a-background-task.md) to create one.</span></span>

## <a name="create-a-time-trigger"></a><span data-ttu-id="7519d-110">時刻のトリガーを作る</span><span class="sxs-lookup"><span data-stu-id="7519d-110">Create a time trigger</span></span>

<span data-ttu-id="7519d-111">新しい [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843) を作ります。</span><span class="sxs-lookup"><span data-stu-id="7519d-111">Create a new [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843).</span></span> <span data-ttu-id="7519d-112">2 つ目のパラメーター (*OneShot*) では、バックグラウンド タスクを一度だけ実行するか、または定期的に実行を続けるかを指定します。</span><span class="sxs-lookup"><span data-stu-id="7519d-112">The second parameter, *OneShot*, specifies whether the background task will run only once or keep running periodically.</span></span> <span data-ttu-id="7519d-113">*OneShot* を true に設定する場合は、1 つ目のパラメーター (*FreshnessTime*) に、バックグラウンド タスクをスケジュールするまで待機する時間 (分単位) を指定します。</span><span class="sxs-lookup"><span data-stu-id="7519d-113">If *OneShot* is set to true, the first parameter (*FreshnessTime*) specifies the number of minutes to wait before scheduling the background task.</span></span> <span data-ttu-id="7519d-114">*OneShot* を false に設定する場合は、*FreshnessTime* に、バックグラウンド タスクを実行する間隔を指定します。</span><span class="sxs-lookup"><span data-stu-id="7519d-114">If *OneShot* is set to false, *FreshnessTime* specifies the frequency at which the background task will run.</span></span>

<span data-ttu-id="7519d-115">デスクトップかモバイル デバイス ファミリを対象とするユニバーサル Windows プラットフォーム (UWP) アプリの組み込みタイマーは、15 分間隔でバックグラウンド タスクを実行します。</span><span class="sxs-lookup"><span data-stu-id="7519d-115">The built-in timer for Universal Windows Platform (UWP) apps that target the desktop or mobile device family runs background tasks in 15-minute intervals.</span></span> <span data-ttu-id="7519d-116">(要求された TimerTrigger を持つアプリを起動するためにシステムが 15 分に 1 回だけ起動すればよいように、タイマーは 15 分間隔で実行されます。これにより、電力が節約されます)。</span><span class="sxs-lookup"><span data-stu-id="7519d-116">(The timer runs in 15-minute intervals so that the system only needs to wake once every 15 minutes to wake up the apps that have requested TimerTriggers--which saves power.)</span></span>

- <span data-ttu-id="7519d-117">*FreshnessTime* が 15 分に設定され、*OneShot* が true の場合、タスクは登録された時点から 15 ～ 30 分の間に一度実行されるようにスケジュールされます。</span><span class="sxs-lookup"><span data-stu-id="7519d-117">If *FreshnessTime* is set to 15 minutes and *OneShot* is true, the task will be scheduled to run once starting between 15 and 30 minutes from the time it is registered.</span></span> <span data-ttu-id="7519d-118">これが 25 分に設定され、*OneShot* が true の場合、タスクは登録された時点から 25 ～ 40 分の間に一度実行されるようにスケジュールされます。</span><span class="sxs-lookup"><span data-stu-id="7519d-118">If it is set to 25 minutes and *OneShot* is true, the task will be scheduled to run once starting between 25 and 40 minutes from the time it is registered.</span></span>

- <span data-ttu-id="7519d-119">*FreshnessTime* が 15 分に設定され、*OneShot* が false の場合、タスクは登録された時点から 15 ～ 15 分の間に実行され、その後 30 分ごとに実行されるようにスケジュールされます。</span><span class="sxs-lookup"><span data-stu-id="7519d-119">If *FreshnessTime* is set to 15 minutes and *OneShot* is false, the task will be scheduled to run every 15 minutes starting between 15 and 30 minutes from the time it is registered.</span></span> <span data-ttu-id="7519d-120">これが n 分に設定され、*OneShot* が false の場合、タスクは登録された時点から n ～ n + 15 分の間に実行され、その後 n 分ごとに実行されるようにスケジュールされます。</span><span class="sxs-lookup"><span data-stu-id="7519d-120">If it is set to n minutes and *OneShot* is false, the task will be scheduled to run every n minutes starting between n and n + 15 minutes after it is registered.</span></span>

> [!NOTE]
> <span data-ttu-id="7519d-121">場合*FreshnessTime*がバック グラウンド タスクの登録を試みているときに例外がスローに未満、15 分に設定します。</span><span class="sxs-lookup"><span data-stu-id="7519d-121">If *FreshnessTime* is set to less than 15 minutes, an exception is thrown when attempting to register the background task.</span></span>
 
<span data-ttu-id="7519d-122">たとえば、このトリガーでは、1 時間に 1 回実行するバック グラウンド タスクが発生します。</span><span class="sxs-lookup"><span data-stu-id="7519d-122">For example, this trigger will cause a background task to run once an hour.</span></span>

```cs
TimeTrigger hourlyTrigger = new TimeTrigger(60, false);
```

```cppwinrt
Windows::ApplicationModel::Background::TimeTrigger hourlyTrigger{ 60, false };
```

```cpp
TimeTrigger ^ hourlyTrigger = ref new TimeTrigger(60, false);
```

## <a name="optional-add-a-condition"></a><span data-ttu-id="7519d-123">(省略可能) 条件の追加</span><span class="sxs-lookup"><span data-stu-id="7519d-123">(Optional) Add a condition</span></span>

<span data-ttu-id="7519d-124">いつタスクを実行するかを制御するバックグラウンド タスクの条件を作成できます。</span><span class="sxs-lookup"><span data-stu-id="7519d-124">You can create a background task condition to control when the task runs.</span></span> <span data-ttu-id="7519d-125">条件を指定すると、条件が満たされるまではバックグラウンド タスクが実行されないようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="7519d-125">A condition prevents the background task from running until the condition is met.</span></span> <span data-ttu-id="7519d-126">詳しくは、「[バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7519d-126">For more information, see [Set conditions for running a background task](set-conditions-for-running-a-background-task.md).</span></span>

<span data-ttu-id="7519d-127">この例では、条件が **UserPresent** に設定されているため、トリガー後、ユーザーがアクティブになった場合にタスクが 1 回だけ実行されます。</span><span class="sxs-lookup"><span data-stu-id="7519d-127">In this example the condition is set to **UserPresent** so that, once triggered, the task only runs once the user is active.</span></span> <span data-ttu-id="7519d-128">指定できる条件の一覧については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7519d-128">For a list of possible conditions, see [**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835).</span></span>

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

<span data-ttu-id="7519d-129">バックグラウンド トリガーの条件と種類について詳しくは、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7519d-129">For more in-depth information on conditions and types of background triggers, see [Support your app with background tasks](support-your-app-with-background-tasks.md).</span></span>

##  <a name="call-requestaccessasync"></a><span data-ttu-id="7519d-130">RequestAccessAsync() の呼び出し</span><span class="sxs-lookup"><span data-stu-id="7519d-130">Call RequestAccessAsync()</span></span>

<span data-ttu-id="7519d-131">**ApplicationTrigger** バックグラウンド タスクを登録する前に、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700494) を呼び出して、ユーザーが許可しているバックグラウンド アクティビティのレベルを判断します。これは、ユーザーがアプリのバックグラウンド アクティビティを無効にしている可能性があるためです。</span><span class="sxs-lookup"><span data-stu-id="7519d-131">Before registering the **ApplicationTrigger** background task, call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700494) to determine the level of background activity the user allows because the user may have disabled background activity for your app.</span></span> <span data-ttu-id="7519d-132">ユーザーがバックグラウンド アクティビティの設定を制御する方法について詳しくは、「[バックグラウンド アクティビティの最適化](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7519d-132">See [Optimize background activity](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity) for more information about the ways users can control the settings for background activity.</span></span>

```cs
var requestStatus = await Windows.ApplicationModel.Background.BackgroundExecutionManager.RequestAccessAsync();
if (requestStatus != BackgroundAccessStatus.AlwaysAllowed)
{
    // Depending on the value of requestStatus, provide an appropriate response
    // such as notifying the user which functionality won't work as expected
}
```

## <a name="register-the-background-task"></a><span data-ttu-id="7519d-133">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="7519d-133">Register the background task</span></span>

<span data-ttu-id="7519d-134">バックグラウンド タスクの登録関数を呼び出してバックグラウンド タスクを登録します。</span><span class="sxs-lookup"><span data-stu-id="7519d-134">Register the background task by calling your background task registration function.</span></span> <span data-ttu-id="7519d-135">バックグラウンド タスクの登録と、以下のコード サンプルの **RegisterBackgroundTask()** メソッドの定義について詳しくは、「[バックグラウンド タスクの登録](register-a-background-task.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7519d-135">For more information on registering background tasks, and to see the definition of the **RegisterBackgroundTask()** method in the sample code below, see [Register a background task](register-a-background-task.md).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="7519d-136">バック グラウンド タスクをアプリと同じプロセスで実行されるは設定しないでください`entryPoint`します。</span><span class="sxs-lookup"><span data-stu-id="7519d-136">For background tasks that run in the same process as your app, do not set `entryPoint`.</span></span> <span data-ttu-id="7519d-137">バック グラウンド タスクをアプリから別のプロセスで実行している設定`entryPoint`を名前空間 '.'、およびバック グラウンド タスクの実装を含むクラスの名前。</span><span class="sxs-lookup"><span data-stu-id="7519d-137">For background tasks that run in a separate process from your app, set `entryPoint` to be the namespace, '.', and the name of the class that contains your background task implementation.</span></span>

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

<span data-ttu-id="7519d-138">バックグラウンド タスクの登録パラメーターは登録時に検証されます。</span><span class="sxs-lookup"><span data-stu-id="7519d-138">Background task registration parameters are validated at the time of registration.</span></span> <span data-ttu-id="7519d-139">いずれかの登録パラメーターが有効でない場合は、エラーが返されます。</span><span class="sxs-lookup"><span data-stu-id="7519d-139">An error is returned if any of the registration parameters are invalid.</span></span> <span data-ttu-id="7519d-140">バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。</span><span class="sxs-lookup"><span data-stu-id="7519d-140">Ensure that your app gracefully handles scenarios where background task registration fails - if instead your app depends on having a valid registration object after attempting to register a task, it may crash.</span></span>

## <a name="manage-resources-for-your-background-task"></a><span data-ttu-id="7519d-141">バックグラウンド タスクのリソースの管理</span><span class="sxs-lookup"><span data-stu-id="7519d-141">Manage resources for your background task</span></span>

<span data-ttu-id="7519d-142">[BackgroundExecutionManager.RequestAccessAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) を使用して、アプリのバックグラウンド アクティビティを制限するようにユーザーが設定しているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="7519d-142">Use [BackgroundExecutionManager.RequestAccessAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) to determine if the user has decided that your app’s background activity should be limited.</span></span> <span data-ttu-id="7519d-143">バッテリー使用量を注意し、ユーザーが望む操作を完了するために必要な場合にのみ、バックグラウンドで実行するようにしてください。</span><span class="sxs-lookup"><span data-stu-id="7519d-143">Be aware of your battery usage and only run in the background when it is necessary to complete an action that the user wants.</span></span> <span data-ttu-id="7519d-144">ユーザーがバックグラウンド アクティビティの設定を制御する方法について詳しくは、「[バックグラウンド アクティビティの最適化](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7519d-144">See [Optimize background activity](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity) for more information about the ways users can control the settings for background activity.</span></span>

- <span data-ttu-id="7519d-145">メモリ:チューニングにアプリのメモリとエネルギーの使用は、オペレーティング システムで、バック グラウンド タスクを実行を許可することを保証するキーです。</span><span class="sxs-lookup"><span data-stu-id="7519d-145">Memory: Tuning your app's memory and energy use is key to ensuring that the operating system will allow your background task to run.</span></span> <span data-ttu-id="7519d-146">[メモリ管理 API](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx) を使用して、バックグラウンド タスクが使用しているメモリ量を確認します。</span><span class="sxs-lookup"><span data-stu-id="7519d-146">Use the [Memory Management APIs](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx) to see how much memory your background task is using.</span></span> <span data-ttu-id="7519d-147">バックグラウンド タスクが使用するメモリ量が多くなるほど、別のアプリがフォアグラウンドのときに、バックグラウンド タスクの実行を OS が維持することは難しくなります。</span><span class="sxs-lookup"><span data-stu-id="7519d-147">The more memory your background task uses, the harder it is for the OS to keep it running when another app is in the foreground.</span></span> <span data-ttu-id="7519d-148">アプリが実行できるすべてのバックグラウンド アクティビティについて、最終的に管理できるのはユーザーです。また、ユーザーは、アプリがどの程度バッテリー消費に影響しているかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="7519d-148">The user is ultimately in control of all background activity that your app can perform and has visibility on the impact your app has on battery use.</span></span>  
- <span data-ttu-id="7519d-149">CPU 時間:バック グラウンド タスクは、トリガーの種類に基づいて、取得、ウォール クロック使用時間の量によって制限されます。</span><span class="sxs-lookup"><span data-stu-id="7519d-149">CPU time: Background tasks are limited by the amount of wall-clock usage time they get based on trigger type.</span></span>

<span data-ttu-id="7519d-150">バックグラウンド タスクに適用されるリソースの制約については、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7519d-150">See [Support your app with background tasks](support-your-app-with-background-tasks.md) for the resource constraints applied to background tasks.</span></span>

## <a name="remarks"></a><span data-ttu-id="7519d-151">注釈</span><span class="sxs-lookup"><span data-stu-id="7519d-151">Remarks</span></span>

<span data-ttu-id="7519d-152">Windows 10 以降の場合は、バック グラウンド タスクを利用するには、ロック画面にアプリを追加するユーザーのために必要な不要になった。</span><span class="sxs-lookup"><span data-stu-id="7519d-152">Starting with Windows 10, it is no longer necessary for the user to add your app to the lock screen in order to utilize background tasks.</span></span>

<span data-ttu-id="7519d-153">バックグラウンド タスクが **TimeTrigger** を使って実行されるのは、先に[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出した場合のみです。</span><span class="sxs-lookup"><span data-stu-id="7519d-153">A background task will only run using a **TimeTrigger** if you have called [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) first.</span></span>

## <a name="related-topics"></a><span data-ttu-id="7519d-154">関連トピック</span><span class="sxs-lookup"><span data-stu-id="7519d-154">Related topics</span></span>

* [<span data-ttu-id="7519d-155">バックグラウンド タスクのガイドライン</span><span class="sxs-lookup"><span data-stu-id="7519d-155">Guidelines for background tasks</span></span>](guidelines-for-background-tasks.md)
* [<span data-ttu-id="7519d-156">バック グラウンド タスクのコード サンプル</span><span class="sxs-lookup"><span data-stu-id="7519d-156">Background task code sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BackgroundTask)
* [<span data-ttu-id="7519d-157">作成して、プロセス内のバック グラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="7519d-157">Create and register an in-process background task</span></span>](create-and-register-an-inproc-background-task.md)
* [<span data-ttu-id="7519d-158">作成して、プロセス外のバック グラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="7519d-158">Create and register an out-of-process background task</span></span>](create-and-register-a-background-task.md)
* [<span data-ttu-id="7519d-159">バック グラウンド タスクをデバッグします。</span><span class="sxs-lookup"><span data-stu-id="7519d-159">Debug a background task</span></span>](debug-a-background-task.md)
* [<span data-ttu-id="7519d-160">アプリケーション マニフェストでバック グラウンド タスクを宣言します。</span><span class="sxs-lookup"><span data-stu-id="7519d-160">Declare background tasks in the application manifest</span></span>](declare-background-tasks-in-the-application-manifest.md)
* [<span data-ttu-id="7519d-161">アプリがバック グラウンドに移動すると、空きメモリ</span><span class="sxs-lookup"><span data-stu-id="7519d-161">Free memory when your app moves to the background</span></span>](reduce-memory-usage.md)
* [<span data-ttu-id="7519d-162">取り消されたバック グラウンド タスクを処理します。</span><span class="sxs-lookup"><span data-stu-id="7519d-162">Handle a cancelled background task</span></span>](handle-a-cancelled-background-task.md)
* [<span data-ttu-id="7519d-163">トリガーする方法を中断、再開、および (デバッグ) 場合は、UWP アプリでイベントをバック グラウンド</span><span class="sxs-lookup"><span data-stu-id="7519d-163">How to trigger suspend, resume, and background events in UWP apps (when debugging)</span></span>](https://go.microsoft.com/fwlink/p/?linkid=254345)
* [<span data-ttu-id="7519d-164">バック グラウンド タスクの進行状況と完了を監視します。</span><span class="sxs-lookup"><span data-stu-id="7519d-164">Monitor background task progress and completion</span></span>](monitor-background-task-progress-and-completion.md)
* [<span data-ttu-id="7519d-165">延長実行とアプリの中断を延期します。</span><span class="sxs-lookup"><span data-stu-id="7519d-165">Postpone app suspension with extended execution</span></span>](run-minimized-with-extended-execution.md)
* [<span data-ttu-id="7519d-166">バック グラウンド タスクを登録します。</span><span class="sxs-lookup"><span data-stu-id="7519d-166">Register a background task</span></span>](register-a-background-task.md)
* [<span data-ttu-id="7519d-167">バック グラウンド タスクでシステム イベントに応答します。</span><span class="sxs-lookup"><span data-stu-id="7519d-167">Respond to system events with background tasks</span></span>](respond-to-system-events-with-background-tasks.md)
* [<span data-ttu-id="7519d-168">バック グラウンド タスクを実行するための条件を設定します。</span><span class="sxs-lookup"><span data-stu-id="7519d-168">Set conditions for running a background task</span></span>](set-conditions-for-running-a-background-task.md)
* [<span data-ttu-id="7519d-169">バック グラウンド タスクからのライブ タイルを更新します。</span><span class="sxs-lookup"><span data-stu-id="7519d-169">Update a live tile from a background task</span></span>](update-a-live-tile-from-a-background-task.md)
* [<span data-ttu-id="7519d-170">メンテナンス トリガーを使用します。</span><span class="sxs-lookup"><span data-stu-id="7519d-170">Use a maintenance trigger</span></span>](use-a-maintenance-trigger.md)
