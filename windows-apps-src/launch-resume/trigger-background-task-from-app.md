---
title: アプリ内からのバックグラウンド タスクのトリガー
description: アプリケーション内からバックグラウンド タスクをトリガーする方法について説明します。
ms.date: 07/06/2018
ms.topic: article
keywords: バック グラウンド タスクのトリガー、バック グラウンド タスク
ms.localizationpriority: medium
ms.openlocfilehash: 02e4bf3d7977c9bdd675f264a37e608a5082ef4c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608097"
---
# <a name="trigger-a-background-task-from-within-your-app"></a><span data-ttu-id="11489-104">アプリ内からのバックグラウンド タスクのトリガー</span><span class="sxs-lookup"><span data-stu-id="11489-104">Trigger a background task from within your app</span></span>

<span data-ttu-id="11489-105">[ApplicationTrigger](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.ApplicationTrigger) を使ってアプリ内からバックグラウンド タスクをアクティブ化する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="11489-105">Learn how to use the [ApplicationTrigger](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.ApplicationTrigger) to activate a background task from within your app.</span></span>

<span data-ttu-id="11489-106">アプリケーション、トリガーを作成する方法の例は、この参照してください[例](https://github.com/Microsoft/Windows-universal-samples/blob/v2.0.0/Samples/BackgroundTask/cs/BackgroundTask/Scenario5_ApplicationTriggerTask.xaml.cs)します。</span><span class="sxs-lookup"><span data-stu-id="11489-106">For an example of how to create an Application trigger, see this [example](https://github.com/Microsoft/Windows-universal-samples/blob/v2.0.0/Samples/BackgroundTask/cs/BackgroundTask/Scenario5_ApplicationTriggerTask.xaml.cs).</span></span>

<span data-ttu-id="11489-107">このトピックでは、アプリケーションからアクティブ化する必要のあるバックグラウンド タスクがあることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="11489-107">This topic assumes that you have a background task that you want to activate from your application.</span></span> <span data-ttu-id="11489-108">まだバックグラウンド タスクがない場合は、[BackgroundActivity.cs](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/BackgroundActivation/cs/BackgroundActivity.cs) にサンプルのバックグラウンド タスクがあります。</span><span class="sxs-lookup"><span data-stu-id="11489-108">If you don't already have a background task, there is a sample background task at [BackgroundActivity.cs](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/BackgroundActivation/cs/BackgroundActivity.cs).</span></span> <span data-ttu-id="11489-109">または、「[アウトプロセス バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)」の手順に従って、バックグラウンド タスクを作成してください。</span><span class="sxs-lookup"><span data-stu-id="11489-109">Or, follow the steps in [Create and register an out-of-process background task](create-and-register-a-background-task.md) to create one.</span></span>

## <a name="why-use-an-application-trigger"></a><span data-ttu-id="11489-110">アプリケーション トリガーを使う理由</span><span class="sxs-lookup"><span data-stu-id="11489-110">Why use an application trigger</span></span>

<span data-ttu-id="11489-111">**ApplicationTrigger** は、フォアグラウンド アプリから別のプロセスのコードを実行するために使用します。</span><span class="sxs-lookup"><span data-stu-id="11489-111">Use an **ApplicationTrigger** to run code in a separate process from the foreground app.</span></span> <span data-ttu-id="11489-112">**ApplicationTrigger** は、ユーザーがフォアグラウンド アプリを閉じた場合でも、バックグラウンドで実行が必要な作業がある場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="11489-112">An **ApplicationTrigger** is appropriate if your app has work that needs to be done in the background--even if the user closes the foreground app.</span></span> <span data-ttu-id="11489-113">アプリが閉じられたらバックグラウンド作業を停止する場合や、バックグラウンド作業がフォアグラウンド プロセスの状態に関連付けられている場合には、代わりに[延長実行](run-minimized-with-extended-execution.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="11489-113">If background work should halt when the app is closed, or should be tied to the state of the foreground process, then [Extended Execution](run-minimized-with-extended-execution.md) should be used, instead.</span></span>

## <a name="create-an-application-trigger"></a><span data-ttu-id="11489-114">アプリケーション トリガーの作成</span><span class="sxs-lookup"><span data-stu-id="11489-114">Create an application trigger</span></span>

<span data-ttu-id="11489-115">新しい [ApplicationTrigger](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.ApplicationTrigger) を作成します。</span><span class="sxs-lookup"><span data-stu-id="11489-115">Create a new [ApplicationTrigger](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.ApplicationTrigger).</span></span> <span data-ttu-id="11489-116">これは、以下のスニペットで行われるように、フィールドに格納されます。</span><span class="sxs-lookup"><span data-stu-id="11489-116">You could store it in a field as is done in the snippet below.</span></span> <span data-ttu-id="11489-117">これは、トリガーに通知する場合に、後で新しいインスタンスを作成する必要がないようにするための利便性を考慮したものです。</span><span class="sxs-lookup"><span data-stu-id="11489-117">This is for convenience so that we don't have to create a new instance later when we want to signal the trigger.</span></span> <span data-ttu-id="11489-118">ただし、トリガーへの通知には、任意の **ApplicationTrigger** インスタンスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="11489-118">But you can use any **ApplicationTrigger** instance to signal the trigger.</span></span>

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

## <a name="optional-add-a-condition"></a><span data-ttu-id="11489-119">(省略可能) 条件の追加</span><span class="sxs-lookup"><span data-stu-id="11489-119">(Optional) Add a condition</span></span>

<span data-ttu-id="11489-120">いつタスクを実行するかを制御するバックグラウンド タスクの条件を作成できます。</span><span class="sxs-lookup"><span data-stu-id="11489-120">You can create a background task condition to control when the task runs.</span></span> <span data-ttu-id="11489-121">条件を指定すると、条件が満たされるまではバックグラウンド タスクが実行されないようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="11489-121">A condition prevents the background task from running until the condition is met.</span></span> <span data-ttu-id="11489-122">詳しくは、「[バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="11489-122">For more information, see [Set conditions for running a background task](set-conditions-for-running-a-background-task.md).</span></span>

<span data-ttu-id="11489-123">この例では、条件に設定されて**InternetAvailable**タスクはインターネット アクセスが使用可能なのみが実行されるため、1 回トリガーされると、します。</span><span class="sxs-lookup"><span data-stu-id="11489-123">In this example the condition is set to **InternetAvailable** so that, once triggered, the task only runs once internet access is available.</span></span> <span data-ttu-id="11489-124">指定できる条件の一覧については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="11489-124">For a list of possible conditions, see [**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835).</span></span>

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

<span data-ttu-id="11489-125">バックグラウンド トリガーの条件と種類について詳しくは、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="11489-125">For more in-depth information on conditions and types of background triggers, see [Support your app with background tasks](support-your-app-with-background-tasks.md).</span></span>

##  <a name="call-requestaccessasync"></a><span data-ttu-id="11489-126">RequestAccessAsync() の呼び出し</span><span class="sxs-lookup"><span data-stu-id="11489-126">Call RequestAccessAsync()</span></span>

<span data-ttu-id="11489-127">**ApplicationTrigger** バックグラウンド タスクを登録する前に、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700494) を呼び出して、ユーザーが許可しているバックグラウンド アクティビティのレベルを判断します。これは、ユーザーがアプリのバックグラウンド アクティビティを無効にしている可能性があるためです。</span><span class="sxs-lookup"><span data-stu-id="11489-127">Before registering the **ApplicationTrigger** background task, call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700494) to determine the level of background activity the user allows because the user may have disabled background activity for your app.</span></span> <span data-ttu-id="11489-128">ユーザーがバックグラウンド アクティビティの設定を制御する方法について詳しくは、「[バックグラウンド アクティビティの最適化](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="11489-128">See [Optimize background activity](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity) for more information about the ways users can control the settings for background activity.</span></span>

```csharp
var requestStatus = await Windows.ApplicationModel.Background.BackgroundExecutionManager.RequestAccessAsync();
if (requestStatus != BackgroundAccessStatus.AlwaysAllowed)
{
   // Depending on the value of requestStatus, provide an appropriate response
   // such as notifying the user which functionality won't work as expected
}
```

## <a name="register-the-background-task"></a><span data-ttu-id="11489-129">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="11489-129">Register the background task</span></span>

<span data-ttu-id="11489-130">バックグラウンド タスクの登録関数を呼び出してバックグラウンド タスクを登録します。</span><span class="sxs-lookup"><span data-stu-id="11489-130">Register the background task by calling your background task registration function.</span></span> <span data-ttu-id="11489-131">バックグラウンド タスクの登録と、以下のコード サンプルの **RegisterBackgroundTask()** メソッドの定義について詳しくは、「[バックグラウンド タスクの登録](register-a-background-task.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="11489-131">For more information on registering background tasks, and to see the definition of the **RegisterBackgroundTask()** method in the sample code below, see [Register a background task](register-a-background-task.md).</span></span>

<span data-ttu-id="11489-132">アプリケーション トリガーを使用してフォアグラウンド プロセスの有効期間を延長することを検討している場合は、代わりに[延長実行](run-minimized-with-extended-execution.md)の使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="11489-132">If you are considering using an Application Trigger to extend the lifetime of your foreground process, consider using [Extended Execution](run-minimized-with-extended-execution.md) instead.</span></span> <span data-ttu-id="11489-133">アプリケーション トリガーは、作業を行うための個別にホストされたプロセスを作成することを目的としています。</span><span class="sxs-lookup"><span data-stu-id="11489-133">The Application Trigger is designed for creating a separately hosted process to do work in.</span></span> <span data-ttu-id="11489-134">次のコード スニペットは、アウトプロセス バックグラウンド トリガーを登録します。</span><span class="sxs-lookup"><span data-stu-id="11489-134">The following code snippet registers an out-of-process background trigger.</span></span>

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

<span data-ttu-id="11489-135">バックグラウンド タスクの登録パラメーターは登録時に検証されます。</span><span class="sxs-lookup"><span data-stu-id="11489-135">Background task registration parameters are validated at the time of registration.</span></span> <span data-ttu-id="11489-136">いずれかの登録パラメーターが有効でない場合は、エラーが返されます。</span><span class="sxs-lookup"><span data-stu-id="11489-136">An error is returned if any of the registration parameters are invalid.</span></span> <span data-ttu-id="11489-137">バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。</span><span class="sxs-lookup"><span data-stu-id="11489-137">Ensure that your app gracefully handles scenarios where background task registration fails - if instead your app depends on having a valid registration object after attempting to register a task, it may crash.</span></span>

## <a name="trigger-the-background-task"></a><span data-ttu-id="11489-138">バックグラウンド タスクのトリガー</span><span class="sxs-lookup"><span data-stu-id="11489-138">Trigger the background task</span></span>

<span data-ttu-id="11489-139">バックグラウンド タスクをトリガーする前に、[BackgroundTaskRegistration](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.BackgroundTaskRegistration) を使って、そのバックグラウンド タスクが登録されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="11489-139">Before you trigger the background task, use [BackgroundTaskRegistration](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.BackgroundTaskRegistration) to verify that the background task is registered.</span></span> <span data-ttu-id="11489-140">すべてのバックグラウンド タスクが登録されていることを確認するのに適したタイミングは、アプリの起動中です。</span><span class="sxs-lookup"><span data-stu-id="11489-140">A good time to verify that all of your background tasks are registered is during app launch.</span></span>

<span data-ttu-id="11489-141">[ApplicationTrigger.RequestAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.applicationtrigger) を呼び出してバックグラウンド タスクをトリガーします。</span><span class="sxs-lookup"><span data-stu-id="11489-141">Trigger the background task by calling [ApplicationTrigger.RequestAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.applicationtrigger).</span></span> <span data-ttu-id="11489-142">どの **ApplicationTrigger** インスタンスでも機能します。</span><span class="sxs-lookup"><span data-stu-id="11489-142">Any **ApplicationTrigger** instance will do.</span></span>

<span data-ttu-id="11489-143">**ApplicationTrigger.RequestAsync** は、バックグラウンド タスク自体からは呼び出すことができません。また、アプリがバックグラウンド実行状態にある場合も呼び出すことはできません (アプリケーションの状態について詳しくは「[アプリのライフサイクル](app-lifecycle.md)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="11489-143">Note that **ApplicationTrigger.RequestAsync** can't be called from the background task itself, or when the app is in the background running state (see [App lifecycle](app-lifecycle.md) for more information about application states).</span></span>
<span data-ttu-id="11489-144">アプリでバックグラウンド アクティビティが実行されないように電源ポリシーやプライバシー ポリシーが設定されている場合は、[DisabledByPolicy](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.applicationtriggerresult) が返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="11489-144">It may return [DisabledByPolicy](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.applicationtriggerresult) if the user has set energy or privacy policies that prevent the app from performing background activity.</span></span>
<span data-ttu-id="11489-145">また、一度に実行できる AppTrigger は 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="11489-145">Also, only one AppTrigger can run at a time.</span></span> <span data-ttu-id="11489-146">AppTrigger の実行中に別の AppTrigger を実行しようとした場合、関数によって [CurrentlyRunning](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.applicationtriggerresult) が返されます。</span><span class="sxs-lookup"><span data-stu-id="11489-146">If you attempt to run an AppTrigger while another is already running, the function will return [CurrentlyRunning](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.applicationtriggerresult).</span></span>

```csharp
var result = await _AppTrigger.RequestAsync();
```

## <a name="manage-resources-for-your-background-task"></a><span data-ttu-id="11489-147">バックグラウンド タスクのリソースの管理</span><span class="sxs-lookup"><span data-stu-id="11489-147">Manage resources for your background task</span></span>

<span data-ttu-id="11489-148">[BackgroundExecutionManager.RequestAccessAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) を使用して、アプリのバックグラウンド アクティビティを制限するようにユーザーが設定しているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="11489-148">Use [BackgroundExecutionManager.RequestAccessAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) to determine if the user has decided that your app’s background activity should be limited.</span></span> <span data-ttu-id="11489-149">バッテリー使用量を注意し、ユーザーが望む操作を完了するために必要な場合にのみ、バックグラウンドで実行するようにしてください。</span><span class="sxs-lookup"><span data-stu-id="11489-149">Be aware of your battery usage and only run in the background when it is necessary to complete an action that the user wants.</span></span> <span data-ttu-id="11489-150">ユーザーがバックグラウンド アクティビティの設定を制御する方法について詳しくは、「[バックグラウンド アクティビティの最適化](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="11489-150">See [Optimize background activity](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity) for more information about the ways users can control the settings for background activity.</span></span>  

- <span data-ttu-id="11489-151">メモリ:チューニングにアプリのメモリとエネルギーの使用は、オペレーティング システムで、バック グラウンド タスクを実行を許可することを保証するキーです。</span><span class="sxs-lookup"><span data-stu-id="11489-151">Memory: Tuning your app's memory and energy use is key to ensuring that the operating system will allow your background task to run.</span></span> <span data-ttu-id="11489-152">[メモリ管理 API](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx) を使用して、バックグラウンド タスクが使用しているメモリ量を確認します。</span><span class="sxs-lookup"><span data-stu-id="11489-152">Use the [Memory Management APIs](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx) to see how much memory your background task is using.</span></span> <span data-ttu-id="11489-153">バックグラウンド タスクが使用するメモリ量が多くなるほど、別のアプリがフォアグラウンドのときに、バックグラウンド タスクの実行を OS が維持することは難しくなります。</span><span class="sxs-lookup"><span data-stu-id="11489-153">The more memory your background task uses, the harder it is for the OS to keep it running when another app is in the foreground.</span></span> <span data-ttu-id="11489-154">アプリが実行できるすべてのバックグラウンド アクティビティについて、最終的に管理できるのはユーザーです。また、ユーザーは、アプリがどの程度バッテリー消費に影響しているかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="11489-154">The user is ultimately in control of all background activity that your app can perform and has visibility on the impact your app has on battery use.</span></span>  
- <span data-ttu-id="11489-155">CPU 時間:バック グラウンド タスクは、トリガーの種類に基づいて、取得、ウォール クロック使用時間の量によって制限されます。</span><span class="sxs-lookup"><span data-stu-id="11489-155">CPU time: Background tasks are limited by the amount of wall-clock usage time they get based on trigger type.</span></span> <span data-ttu-id="11489-156">アプリケーション トリガーによってトリガーされるバックグラウンド タスクは、約 10 分間に制限されます。</span><span class="sxs-lookup"><span data-stu-id="11489-156">Background tasks triggered by the Application trigger are limited to about 10 minutes.</span></span>

<span data-ttu-id="11489-157">バックグラウンド タスクに適用されるリソースの制約については、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="11489-157">See [Support your app with background tasks](support-your-app-with-background-tasks.md) for the resource constraints applied to background tasks.</span></span>

## <a name="remarks"></a><span data-ttu-id="11489-158">注釈</span><span class="sxs-lookup"><span data-stu-id="11489-158">Remarks</span></span>

<span data-ttu-id="11489-159">Windows 10 以降の場合は、バック グラウンド タスクを利用するには、ロック画面にアプリを追加するユーザーのために必要な不要になった。</span><span class="sxs-lookup"><span data-stu-id="11489-159">Starting with Windows 10, it is no longer necessary for the user to add your app to the lock screen in order to utilize background tasks.</span></span>

<span data-ttu-id="11489-160">バックグラウンド タスクが **ApplicationTrigger** を使って実行されるのは、先に [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出した場合のみです。</span><span class="sxs-lookup"><span data-stu-id="11489-160">A background task will only run using an **ApplicationTrigger** if you have called [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) first.</span></span>

## <a name="related-topics"></a><span data-ttu-id="11489-161">関連トピック</span><span class="sxs-lookup"><span data-stu-id="11489-161">Related topics</span></span>

* [<span data-ttu-id="11489-162">バックグラウンド タスクのガイドライン</span><span class="sxs-lookup"><span data-stu-id="11489-162">Guidelines for background tasks</span></span>](guidelines-for-background-tasks.md)
* [<span data-ttu-id="11489-163">バック グラウンド タスクのコード サンプル</span><span class="sxs-lookup"><span data-stu-id="11489-163">Background task code sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BackgroundTask)
* <span data-ttu-id="11489-164">[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)</span><span class="sxs-lookup"><span data-stu-id="11489-164">[Create and register an in-process background task](create-and-register-an-inproc-background-task.md).</span></span>
* [<span data-ttu-id="11489-165">作成して、プロセス外のバック グラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="11489-165">Create and register an out-of-process background task</span></span>](create-and-register-a-background-task.md)
* [<span data-ttu-id="11489-166">バック グラウンド タスクをデバッグします。</span><span class="sxs-lookup"><span data-stu-id="11489-166">Debug a background task</span></span>](debug-a-background-task.md)
* [<span data-ttu-id="11489-167">アプリケーション マニフェストでバック グラウンド タスクを宣言します。</span><span class="sxs-lookup"><span data-stu-id="11489-167">Declare background tasks in the application manifest</span></span>](declare-background-tasks-in-the-application-manifest.md)
* [<span data-ttu-id="11489-168">アプリがバック グラウンドに移動すると、空きメモリ</span><span class="sxs-lookup"><span data-stu-id="11489-168">Free memory when your app moves to the background</span></span>](reduce-memory-usage.md)
* [<span data-ttu-id="11489-169">取り消されたバック グラウンド タスクを処理します。</span><span class="sxs-lookup"><span data-stu-id="11489-169">Handle a cancelled background task</span></span>](handle-a-cancelled-background-task.md)
* [<span data-ttu-id="11489-170">トリガーする方法を中断、再開、および (デバッグ) 場合は、UWP アプリでイベントをバック グラウンド</span><span class="sxs-lookup"><span data-stu-id="11489-170">How to trigger suspend, resume, and background events in UWP apps (when debugging)</span></span>](https://go.microsoft.com/fwlink/p/?linkid=254345)
* [<span data-ttu-id="11489-171">バック グラウンド タスクの進行状況と完了を監視します。</span><span class="sxs-lookup"><span data-stu-id="11489-171">Monitor background task progress and completion</span></span>](monitor-background-task-progress-and-completion.md)
* [<span data-ttu-id="11489-172">延長実行とアプリの中断を延期します。</span><span class="sxs-lookup"><span data-stu-id="11489-172">Postpone app suspension with extended execution</span></span>](run-minimized-with-extended-execution.md)
* [<span data-ttu-id="11489-173">バック グラウンド タスクを登録します。</span><span class="sxs-lookup"><span data-stu-id="11489-173">Register a background task</span></span>](register-a-background-task.md)
* [<span data-ttu-id="11489-174">バック グラウンド タスクでシステム イベントに応答します。</span><span class="sxs-lookup"><span data-stu-id="11489-174">Respond to system events with background tasks</span></span>](respond-to-system-events-with-background-tasks.md)
* [<span data-ttu-id="11489-175">バック グラウンド タスクを実行するための条件を設定します。</span><span class="sxs-lookup"><span data-stu-id="11489-175">Set conditions for running a background task</span></span>](set-conditions-for-running-a-background-task.md)
* [<span data-ttu-id="11489-176">バック グラウンド タスクからのライブ タイルを更新します。</span><span class="sxs-lookup"><span data-stu-id="11489-176">Update a live tile from a background task</span></span>](update-a-live-tile-from-a-background-task.md)
* [<span data-ttu-id="11489-177">メンテナンス トリガーを使用します。</span><span class="sxs-lookup"><span data-stu-id="11489-177">Use a maintenance trigger</span></span>](use-a-maintenance-trigger.md)
