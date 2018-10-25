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
keywords: バック グラウンド タスクの windows 10, uwp,
ms.localizationpriority: medium
ms.openlocfilehash: 25e3c76ae09ed6835f89f0d98c308f11c7a99624
ms.sourcegitcommit: 2c4daa36fb9fd3e8daa83c2bd0825f3989d24be8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5518923"
---
# <a name="run-a-background-task-on-a-timer"></a><span data-ttu-id="9bcc8-104">タイマーでのバックグラウンド タスクの実行</span><span class="sxs-lookup"><span data-stu-id="9bcc8-104">Run a background task on a timer</span></span>

<span data-ttu-id="9bcc8-105">[**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843)を使用して、1 回限りのバック グラウンド タスクをスケジュールまたは定期的なバック グラウンド タスクを実行する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-105">Learn how to use the [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843) to schedule a one-time background task, or run a periodic background task.</span></span>

<span data-ttu-id="9bcc8-106">このトピックでトリガーのバック グラウンド タスクが説明されている時間を実装する方法の例を参照する[バック グラウンドのアクティブ化のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BackgroundActivation)で**Scenario4**を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-106">See **Scenario4** in the [Background activation sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BackgroundActivation) to see an example of how to implement the time triggered background task described in this topic.</span></span>

<span data-ttu-id="9bcc8-107">このトピックでは、定期的に、または特定の時点で実行する必要があるバック グラウンド タスクがあることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-107">This topic assumes that you have a background task that needs to run periodically, or at a specific time.</span></span> <span data-ttu-id="9bcc8-108">バック グラウンド タスクがまだしていない場合は、バック グラウンド タスクのサンプルでは[BackgroundActivity.cs です](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/BackgroundActivation/cs/BackgroundActivity.cs)。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-108">If you don't already have a background task, there is a sample background task at [BackgroundActivity.cs](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/BackgroundActivation/cs/BackgroundActivity.cs).</span></span> <span data-ttu-id="9bcc8-109">またはで[の作成と登録、インプロセス バック グラウンド タスク](create-and-register-an-inproc-background-task.md)[の作成と登録、アウト プロセス バック グラウンド タスク](create-and-register-a-background-task.md)を作成する手順に従います。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-109">Or, follow the steps in [Create and register an in-process background task](create-and-register-an-inproc-background-task.md) or [Create and register an out-of-process background task](create-and-register-a-background-task.md) to create one.</span></span>

## <a name="create-a-time-trigger"></a><span data-ttu-id="9bcc8-110">時刻のトリガーを作る</span><span class="sxs-lookup"><span data-stu-id="9bcc8-110">Create a time trigger</span></span>

<span data-ttu-id="9bcc8-111">新しい [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843) を作ります。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-111">Create a new [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843).</span></span> <span data-ttu-id="9bcc8-112">2 つ目のパラメーター (*OneShot*) では、バックグラウンド タスクを一度だけ実行するか、または定期的に実行を続けるかを指定します。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-112">The second parameter, *OneShot*, specifies whether the background task will run only once or keep running periodically.</span></span> <span data-ttu-id="9bcc8-113">*OneShot* を true に設定する場合は、1 つ目のパラメーター (*FreshnessTime*) に、バックグラウンド タスクをスケジュールするまで待機する時間 (分単位) を指定します。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-113">If *OneShot* is set to true, the first parameter (*FreshnessTime*) specifies the number of minutes to wait before scheduling the background task.</span></span> <span data-ttu-id="9bcc8-114">*OneShot* を false に設定する場合は、*FreshnessTime* に、バックグラウンド タスクを実行する間隔を指定します。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-114">If *OneShot* is set to false, *FreshnessTime* specifies the frequency at which the background task will run.</span></span>

<span data-ttu-id="9bcc8-115">デスクトップかモバイル デバイス ファミリを対象とするユニバーサル Windows プラットフォーム (UWP) アプリの組み込みタイマーは、15 分間隔でバックグラウンド タスクを実行します。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-115">The built-in timer for Universal Windows Platform (UWP) apps that target the desktop or mobile device family runs background tasks in 15-minute intervals.</span></span> <span data-ttu-id="9bcc8-116">(タイマーは実行 15 分間隔でように、システムがのみ電力を節約する - TimerTriggers を要求したアプリをスリープ解除する 15 分ごとに 1 回だけをスリープ解除する必要があります。)</span><span class="sxs-lookup"><span data-stu-id="9bcc8-116">(The timer runs in 15-minute intervals so that the system only needs to wake once every 15 minutes to wake up the apps that have requested TimerTriggers--which saves power.)</span></span>

- <span data-ttu-id="9bcc8-117">*FreshnessTime* が 15 分に設定され、*OneShot* が true の場合、タスクは登録された時点から 15 ～ 30 分の間に一度実行されるようにスケジュールされます。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-117">If *FreshnessTime* is set to 15 minutes and *OneShot* is true, the task will be scheduled to run once starting between 15 and 30 minutes from the time it is registered.</span></span> <span data-ttu-id="9bcc8-118">これが 25 分に設定され、*OneShot* が true の場合、タスクは登録された時点から 25 ～ 40 分の間に一度実行されるようにスケジュールされます。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-118">If it is set to 25 minutes and *OneShot* is true, the task will be scheduled to run once starting between 25 and 40 minutes from the time it is registered.</span></span>

- <span data-ttu-id="9bcc8-119">*FreshnessTime* が 15 分に設定され、*OneShot* が false の場合、タスクは登録された時点から 15 ～ 15 分の間に実行され、その後 30 分ごとに実行されるようにスケジュールされます。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-119">If *FreshnessTime* is set to 15 minutes and *OneShot* is false, the task will be scheduled to run every 15 minutes starting between 15 and 30 minutes from the time it is registered.</span></span> <span data-ttu-id="9bcc8-120">これが n 分に設定され、*OneShot* が false の場合、タスクは登録された時点から n ～ n + 15 分の間に実行され、その後 n 分ごとに実行されるようにスケジュールされます。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-120">If it is set to n minutes and *OneShot* is false, the task will be scheduled to run every n minutes starting between n and n + 15 minutes after it is registered.</span></span>

> [!NOTE]
> <span data-ttu-id="9bcc8-121">*FreshnessTime*は 15 分未満に設定されている場合は、バック グラウンド タスクを登録しようとすると、例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-121">If *FreshnessTime* is set to less than 15 minutes, an exception is thrown when attempting to register the background task.</span></span>
 
<span data-ttu-id="9bcc8-122">たとえば、このトリガーには、1 時間に 1 回実行するバック グラウンド タスクが発生します。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-122">For example, this trigger will cause a background task to run once an hour.</span></span>

```cs
TimeTrigger hourlyTrigger = new TimeTrigger(60, false);
```

```cppwinrt
Windows::ApplicationModel::Background::TimeTrigger hourlyTrigger{ 60, false };
```

```cpp
TimeTrigger ^ hourlyTrigger = ref new TimeTrigger(60, false);
```

## <a name="optional-add-a-condition"></a><span data-ttu-id="9bcc8-123">(省略可能) 条件の追加</span><span class="sxs-lookup"><span data-stu-id="9bcc8-123">(Optional) Add a condition</span></span>

<span data-ttu-id="9bcc8-124">タスクが実行されている場合は、コントロールにバック グラウンド タスクの条件を作成できます。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-124">You can create a background task condition to control when the task runs.</span></span> <span data-ttu-id="9bcc8-125">条件では、バック グラウンド タスクが、条件が満たされるまでを実行できなくなります。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-125">A condition prevents the background task from running until the condition is met.</span></span> <span data-ttu-id="9bcc8-126">詳細については、[バック グラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-126">For more information, see [Set conditions for running a background task](set-conditions-for-running-a-background-task.md).</span></span>

<span data-ttu-id="9bcc8-127">この例では、条件が **UserPresent** に設定されているため、トリガー後、ユーザーがアクティブになった場合にタスクが 1 回だけ実行されます。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-127">In this example the condition is set to **UserPresent** so that, once triggered, the task only runs once the user is active.</span></span> <span data-ttu-id="9bcc8-128">指定できる条件の一覧については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-128">For a list of possible conditions, see [**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835).</span></span>

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

<span data-ttu-id="9bcc8-129">詳細については条件とバック グラウンド トリガーの種類で、[バック グラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-129">For more in-depth information on conditions and types of background triggers, see [Support your app with background tasks](support-your-app-with-background-tasks.md).</span></span>

##  <a name="call-requestaccessasync"></a><span data-ttu-id="9bcc8-130">RequestAccessAsync() の呼び出し</span><span class="sxs-lookup"><span data-stu-id="9bcc8-130">Call RequestAccessAsync()</span></span>

<span data-ttu-id="9bcc8-131">**ApplicationTrigger**バック グラウンド タスクを登録する前に、ユーザーは、ユーザーがアプリのバック グラウンド アクティビティを無効にいるため、バック グラウンド アクティビティのレベルを決定する[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700494)を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-131">Before registering the **ApplicationTrigger** background task, call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700494) to determine the level of background activity the user allows because the user may have disabled background activity for your app.</span></span> <span data-ttu-id="9bcc8-132">表示方法のユーザーの詳細については、[バック グラウンド アクティビティの最適化](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity)は、バック グラウンド アクティビティの設定を制御できます。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-132">See [Optimize background activity](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity) for more information about the ways users can control the settings for background activity.</span></span>

```cs
var requestStatus = await Windows.ApplicationModel.Background.BackgroundExecutionManager.RequestAccessAsync();
if (requestStatus != BackgroundAccessStatus.AlwaysAllowed)
{
    // Depending on the value of requestStatus, provide an appropriate response
    // such as notifying the user which functionality won't work as expected
}
```

## <a name="register-the-background-task"></a><span data-ttu-id="9bcc8-133">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="9bcc8-133">Register the background task</span></span>

<span data-ttu-id="9bcc8-134">バックグラウンド タスクの登録関数を呼び出してバックグラウンド タスクを登録します。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-134">Register the background task by calling your background task registration function.</span></span> <span data-ttu-id="9bcc8-135">詳細については、バック グラウンド タスクの登録にし、次のサンプル コードで**RegisterBackgroundTask()** メソッドの定義を参照する、[バック グラウンド タスクの登録](register-a-background-task.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-135">For more information on registering background tasks, and to see the definition of the **RegisterBackgroundTask()** method in the sample code below, see [Register a background task](register-a-background-task.md).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="9bcc8-136">バック グラウンド タスクは、アプリと同じプロセスで実行されるを設定しない`entryPoint`します。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-136">For background tasks that run in the same process as your app, do not set `entryPoint`.</span></span> <span data-ttu-id="9bcc8-137">バック グラウンド タスクをアプリから別のプロセスで実行される、設定`entryPoint`を名前空間 '.' とバック グラウンド タスクの実装を含んだクラスの名前。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-137">For background tasks that run in a separate process from your app, set `entryPoint` to be the namespace, '.', and the name of the class that contains your background task implementation.</span></span>

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

<span data-ttu-id="9bcc8-138">バックグラウンド タスクの登録パラメーターは登録時に検証されます。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-138">Background task registration parameters are validated at the time of registration.</span></span> <span data-ttu-id="9bcc8-139">いずれかの登録パラメーターが有効でない場合は、エラーが返されます。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-139">An error is returned if any of the registration parameters are invalid.</span></span> <span data-ttu-id="9bcc8-140">バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-140">Ensure that your app gracefully handles scenarios where background task registration fails - if instead your app depends on having a valid registration object after attempting to register a task, it may crash.</span></span>

## <a name="manage-resources-for-your-background-task"></a><span data-ttu-id="9bcc8-141">バック グラウンド タスクのリソースを管理します。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-141">Manage resources for your background task</span></span>

<span data-ttu-id="9bcc8-142">[BackgroundExecutionManager.RequestAccessAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) を使用して、アプリのバックグラウンド アクティビティを制限するようにユーザーが設定しているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-142">Use [BackgroundExecutionManager.RequestAccessAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) to determine if the user has decided that your app’s background activity should be limited.</span></span> <span data-ttu-id="9bcc8-143">バッテリー使用量を注意し、ユーザーが望む操作を完了するために必要な場合にのみ、バックグラウンドで実行するようにしてください。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-143">Be aware of your battery usage and only run in the background when it is necessary to complete an action that the user wants.</span></span> <span data-ttu-id="9bcc8-144">表示方法のユーザーの詳細については、[バック グラウンド アクティビティの最適化](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity)は、バック グラウンド アクティビティの設定を制御できます。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-144">See [Optimize background activity](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity) for more information about the ways users can control the settings for background activity.</span></span>

- <span data-ttu-id="9bcc8-145">メモリ: アプリのメモリや電力使用を調整、オペレーティング システムで実行するバック グラウンド タスクを許可することを保証するキーです。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-145">Memory: Tuning your app's memory and energy use is key to ensuring that the operating system will allow your background task to run.</span></span> <span data-ttu-id="9bcc8-146">[メモリ管理 Api](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx)を使用すると、バック グラウンド タスクを使用してメモリの量を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-146">Use the [Memory Management APIs](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx) to see how much memory your background task is using.</span></span> <span data-ttu-id="9bcc8-147">多くのメモリ、バック グラウンド タスクを使用して、状態を維持が、別のアプリをフォア グラウンドで実行されている OS がは難しくなります。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-147">The more memory your background task uses, the harder it is for the OS to keep it running when another app is in the foreground.</span></span> <span data-ttu-id="9bcc8-148">アプリが実行できるすべてのバックグラウンド アクティビティについて、最終的に管理できるのはユーザーです。また、ユーザーは、アプリがどの程度バッテリー消費に影響しているかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-148">The user is ultimately in control of all background activity that your app can perform and has visibility on the impact your app has on battery use.</span></span>  
- <span data-ttu-id="9bcc8-149">CPU 時間: バック グラウンド タスクがトリガーの種類に基づいて取得するウォールク ロック時間の使用状況の時間の長さによって制限されます。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-149">CPU time: Background tasks are limited by the amount of wall-clock usage time they get based on trigger type.</span></span>

<span data-ttu-id="9bcc8-150">バックグラウンド タスクに適用されるリソースの制約については、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-150">See [Support your app with background tasks](support-your-app-with-background-tasks.md) for the resource constraints applied to background tasks.</span></span>

## <a name="remarks"></a><span data-ttu-id="9bcc8-151">注釈</span><span class="sxs-lookup"><span data-stu-id="9bcc8-151">Remarks</span></span>

<span data-ttu-id="9bcc8-152">Windows 10 以降、場合は、バック グラウンド タスクを利用するために、ロック画面にアプリを追加するユーザーのために必要なしなくなった。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-152">Starting with Windows10, it is no longer necessary for the user to add your app to the lock screen in order to utilize background tasks.</span></span>

<span data-ttu-id="9bcc8-153">バック グラウンド タスクでは、まず[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485)を呼び出した場合、 **TimeTrigger**を使用してのみ実行されます。</span><span class="sxs-lookup"><span data-stu-id="9bcc8-153">A background task will only run using a **TimeTrigger** if you have called [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) first.</span></span>

## <a name="related-topics"></a><span data-ttu-id="9bcc8-154">関連トピック</span><span class="sxs-lookup"><span data-stu-id="9bcc8-154">Related topics</span></span>

* [<span data-ttu-id="9bcc8-155">バックグラウンド タスクのガイドライン</span><span class="sxs-lookup"><span data-stu-id="9bcc8-155">Guidelines for background tasks</span></span>](guidelines-for-background-tasks.md)
* [<span data-ttu-id="9bcc8-156">バック グラウンド タスクのコード サンプル</span><span class="sxs-lookup"><span data-stu-id="9bcc8-156">Background task code sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BackgroundTask)
* [<span data-ttu-id="9bcc8-157">インプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="9bcc8-157">Create and register an in-process background task</span></span>](create-and-register-an-inproc-background-task.md)
* [<span data-ttu-id="9bcc8-158">アウトプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="9bcc8-158">Create and register an out-of-process background task</span></span>](create-and-register-a-background-task.md)
* [<span data-ttu-id="9bcc8-159">バックグラウンド タスクのデバッグ</span><span class="sxs-lookup"><span data-stu-id="9bcc8-159">Debug a background task</span></span>](debug-a-background-task.md)
* [<span data-ttu-id="9bcc8-160">アプリケーション マニフェストでのバックグラウンド タスクの宣言</span><span class="sxs-lookup"><span data-stu-id="9bcc8-160">Declare background tasks in the application manifest</span></span>](declare-background-tasks-in-the-application-manifest.md)
* [<span data-ttu-id="9bcc8-161">アプリがバックグラウンドに移動したときのメモリの解放</span><span class="sxs-lookup"><span data-stu-id="9bcc8-161">Free memory when your app moves to the background</span></span>](reduce-memory-usage.md)
* [<span data-ttu-id="9bcc8-162">取り消されたバックグラウンド タスクの処理</span><span class="sxs-lookup"><span data-stu-id="9bcc8-162">Handle a cancelled background task</span></span>](handle-a-cancelled-background-task.md)
* [<span data-ttu-id="9bcc8-163">UWP アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)</span><span class="sxs-lookup"><span data-stu-id="9bcc8-163">How to trigger suspend, resume, and background events in UWP apps (when debugging)</span></span>](http://go.microsoft.com/fwlink/p/?linkid=254345)
* [<span data-ttu-id="9bcc8-164">バックグラウンド タスクの進捗状況と完了の監視</span><span class="sxs-lookup"><span data-stu-id="9bcc8-164">Monitor background task progress and completion</span></span>](monitor-background-task-progress-and-completion.md)
* [<span data-ttu-id="9bcc8-165">延長実行を使ってアプリの中断を延期する</span><span class="sxs-lookup"><span data-stu-id="9bcc8-165">Postpone app suspension with extended execution</span></span>](run-minimized-with-extended-execution.md)
* [<span data-ttu-id="9bcc8-166">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="9bcc8-166">Register a background task</span></span>](register-a-background-task.md)
* [<span data-ttu-id="9bcc8-167">バックグラウンド タスクによるシステム イベントへの応答</span><span class="sxs-lookup"><span data-stu-id="9bcc8-167">Respond to system events with background tasks</span></span>](respond-to-system-events-with-background-tasks.md)
* [<span data-ttu-id="9bcc8-168">バックグラウンド タスクを実行するための条件の設定</span><span class="sxs-lookup"><span data-stu-id="9bcc8-168">Set conditions for running a background task</span></span>](set-conditions-for-running-a-background-task.md)
* [<span data-ttu-id="9bcc8-169">バックグラウンド タスクのライブ タイルの更新</span><span class="sxs-lookup"><span data-stu-id="9bcc8-169">Update a live tile from a background task</span></span>](update-a-live-tile-from-a-background-task.md)
* [<span data-ttu-id="9bcc8-170">メンテナンス トリガーの使用</span><span class="sxs-lookup"><span data-stu-id="9bcc8-170">Use a maintenance trigger</span></span>](use-a-maintenance-trigger.md)
