---
author: TylerMSFT
title: アプリ内からのバックグラウンド タスクのトリガー
description: アプリケーション内からバック グラウンド タスクをトリガーする方法について説明します
ms.author: twhitney
ms.date: 07/06/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: バック グラウンド タスク トリガーのバック グラウンド タスク
ms.localizationpriority: medium
ms.openlocfilehash: 5ccd171f53795ef71830ffb022d0468facb3ac4f
ms.sourcegitcommit: 7efffcc715a4be26f0cf7f7e249653d8c356319b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/30/2018
ms.locfileid: "3121836"
---
# <a name="trigger-a-background-task-from-within-your-app"></a><span data-ttu-id="53a42-104">アプリ内からのバックグラウンド タスクのトリガー</span><span class="sxs-lookup"><span data-stu-id="53a42-104">Trigger a background task from within your app</span></span>

<span data-ttu-id="53a42-105">[ApplicationTrigger](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.ApplicationTrigger) を使ってアプリ内からバックグラウンド タスクをアクティブ化する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="53a42-105">Learn how to use the [ApplicationTrigger](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.ApplicationTrigger) to activate a background task from within your app.</span></span>

<span data-ttu-id="53a42-106">なアプリケーション トリガーを作成する方法の例では、次の[例](https://github.com/Microsoft/Windows-universal-samples/blob/v2.0.0/Samples/BackgroundTask/cs/BackgroundTask/Scenario5_ApplicationTriggerTask.xaml.cs)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="53a42-106">For an example of how to create an Application trigger, see this [example](https://github.com/Microsoft/Windows-universal-samples/blob/v2.0.0/Samples/BackgroundTask/cs/BackgroundTask/Scenario5_ApplicationTriggerTask.xaml.cs).</span></span>

<span data-ttu-id="53a42-107">このトピックでは、アプリケーションからライセンス認証を実行するバック グラウンド タスクがあることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="53a42-107">This topic assumes that you have a background task that you want to activate from your application.</span></span> <span data-ttu-id="53a42-108">バック グラウンド タスクがまだしていない場合、サンプルのバック グラウンド タスクでは[BackgroundActivity.cs です](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/BackgroundActivation/cs/BackgroundActivity.cs)。</span><span class="sxs-lookup"><span data-stu-id="53a42-108">If you don't already have a background task, there is a sample background task at [BackgroundActivity.cs](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/BackgroundActivation/cs/BackgroundActivity.cs).</span></span> <span data-ttu-id="53a42-109">または[の作成と登録、アウト プロセス バック グラウンド タスク](create-and-register-a-background-task.md)を作成する 1 つの手順に従います。</span><span class="sxs-lookup"><span data-stu-id="53a42-109">Or, follow the steps in [Create and register an out-of-process background task](create-and-register-a-background-task.md) to create one.</span></span>

## <a name="why-use-an-application-trigger"></a><span data-ttu-id="53a42-110">アプリケーション、トリガーを使う理由</span><span class="sxs-lookup"><span data-stu-id="53a42-110">Why use an application trigger</span></span>

<span data-ttu-id="53a42-111">フォア グラウンド アプリから別のプロセスでコードを実行するのに、 **ApplicationTrigger**を使用します。</span><span class="sxs-lookup"><span data-stu-id="53a42-111">Use an **ApplicationTrigger** to run code in a separate process from the foreground app.</span></span> <span data-ttu-id="53a42-112">**ApplicationTrigger**は、アプリがフォア グラウンド アプリでユーザーが閉じる場合でも、- バック グラウンドで実行する必要がある作業する場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="53a42-112">An **ApplicationTrigger** is appropriate if your app has work that needs to be done in the background--even if the user closes the foreground app.</span></span> <span data-ttu-id="53a42-113">バック グラウンドの作業を停止する必要があるとき、アプリが閉じられたか[延長実行](run-minimized-with-extended-execution.md)を使用して代わりに、フォア グラウンド プロセスの状態に関連付けられる必要があります。</span><span class="sxs-lookup"><span data-stu-id="53a42-113">If background work should halt when the app is closed, or should be tied to the state of the foreground process, then [Extended Execution](run-minimized-with-extended-execution.md) should be used, instead.</span></span>

## <a name="create-an-application-trigger"></a><span data-ttu-id="53a42-114">アプリケーション、トリガーを作成します。</span><span class="sxs-lookup"><span data-stu-id="53a42-114">Create an application trigger</span></span>

<span data-ttu-id="53a42-115">新しい[ApplicationTrigger](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.ApplicationTrigger)を作成します。</span><span class="sxs-lookup"><span data-stu-id="53a42-115">Create a new [ApplicationTrigger](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.ApplicationTrigger).</span></span> <span data-ttu-id="53a42-116">次のスニペットで実行される、フィールドにそれを格納可能性があります。</span><span class="sxs-lookup"><span data-stu-id="53a42-116">You could store it in a field as is done in the snippet below.</span></span> <span data-ttu-id="53a42-117">これにより、しますが、トリガーを通知するとき、後で、新しいインスタンスを作成する必要があるないように、便利なです。</span><span class="sxs-lookup"><span data-stu-id="53a42-117">This is for convenience so that we don't have to create a new instance later when we want to signal the trigger.</span></span> <span data-ttu-id="53a42-118">ただし、 **ApplicationTrigger**インスタンスを使用して、トリガーを通知することができます。</span><span class="sxs-lookup"><span data-stu-id="53a42-118">But you can use any **ApplicationTrigger** instance to signal the trigger.</span></span>

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

## <a name="optional-add-a-condition"></a><span data-ttu-id="53a42-119">(省略可能) 条件の追加</span><span class="sxs-lookup"><span data-stu-id="53a42-119">(Optional) Add a condition</span></span>

<span data-ttu-id="53a42-120">タスクが実行されている場合は、コントロールにバック グラウンド タスクの条件を作成できます。</span><span class="sxs-lookup"><span data-stu-id="53a42-120">You can create a background task condition to control when the task runs.</span></span> <span data-ttu-id="53a42-121">条件によって、バック グラウンド タスクは、条件が満たされるまでを実行できなくなります。</span><span class="sxs-lookup"><span data-stu-id="53a42-121">A condition prevents the background task from running until the condition is met.</span></span> <span data-ttu-id="53a42-122">詳しくは、[バック グラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="53a42-122">For more information, see [Set conditions for running a background task](set-conditions-for-running-a-background-task.md).</span></span>

<span data-ttu-id="53a42-123">タスクの条件が**InternetAvailable**に設定されているため、1 回のトリガーこの例では、インターネット アクセスが利用可能ながのみ実行できます。</span><span class="sxs-lookup"><span data-stu-id="53a42-123">In this example the condition is set to **InternetAvailable** so that, once triggered, the task only runs once internet access is available.</span></span> <span data-ttu-id="53a42-124">指定できる条件の一覧については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="53a42-124">For a list of possible conditions, see [**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835).</span></span>

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

<span data-ttu-id="53a42-125">詳細については条件とバック グラウンド トリガーの種類で、[バック グラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="53a42-125">For more in-depth information on conditions and types of background triggers, see [Support your app with background tasks](support-your-app-with-background-tasks.md).</span></span>

##  <a name="call-requestaccessasync"></a><span data-ttu-id="53a42-126">RequestAccessAsync() の呼び出し</span><span class="sxs-lookup"><span data-stu-id="53a42-126">Call RequestAccessAsync()</span></span>

<span data-ttu-id="53a42-127">**ApplicationTrigger**バック グラウンド タスクを登録する前に、ユーザーは、ユーザーがアプリのバック グラウンド アクティビティを無効にいるため、バック グラウンド アクティビティのレベルを判定[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700494)を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="53a42-127">Before registering the **ApplicationTrigger** background task, call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700494) to determine the level of background activity the user allows because the user may have disabled background activity for your app.</span></span> <span data-ttu-id="53a42-128">表示方法のユーザーの詳細については、[バック グラウンド アクティビティの最適化](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity)は、バック グラウンド アクティビティの設定を制御できます。</span><span class="sxs-lookup"><span data-stu-id="53a42-128">See [Optimize background activity](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity) for more information about the ways users can control the settings for background activity.</span></span>

```csharp
var requestStatus = await Windows.ApplicationModel.Background.BackgroundExecutionManager.RequestAccessAsync();
if (requestStatus != BackgroundAccessStatus.AlwaysAllowed)
{
   // Depending on the value of requestStatus, provide an appropriate response
   // such as notifying the user which functionality won't work as expected
}
```

## <a name="register-the-background-task"></a><span data-ttu-id="53a42-129">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="53a42-129">Register the background task</span></span>

<span data-ttu-id="53a42-130">バックグラウンド タスクの登録関数を呼び出してバックグラウンド タスクを登録します。</span><span class="sxs-lookup"><span data-stu-id="53a42-130">Register the background task by calling your background task registration function.</span></span> <span data-ttu-id="53a42-131">次のサンプル コードで**RegisterBackgroundTask()** メソッドの定義を参照して、バック グラウンド タスクの登録の詳細については、[バック グラウンド タスクの登録](register-a-background-task.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="53a42-131">For more information on registering background tasks, and to see the definition of the **RegisterBackgroundTask()** method in the sample code below, see [Register a background task](register-a-background-task.md).</span></span>

<span data-ttu-id="53a42-132">アプリケーション トリガーを使用して、フォア グラウンド プロセスの有効期間を拡張するを検討している場合は、[延長実行](run-minimized-with-extended-execution.md)を代わりに使用を検討します。</span><span class="sxs-lookup"><span data-stu-id="53a42-132">If you are considering using an Application Trigger to extend the lifetime of your foreground process, consider using [Extended Execution](run-minimized-with-extended-execution.md) instead.</span></span> <span data-ttu-id="53a42-133">アプリケーション トリガーは、個別にホストされているプロセスを作成するための処理を実行設計されています。</span><span class="sxs-lookup"><span data-stu-id="53a42-133">The Application Trigger is designed for creating a separately hosted process to do work in.</span></span> <span data-ttu-id="53a42-134">次のコード スニペットは、アウト プロセス バック グラウンド トリガーを登録します。</span><span class="sxs-lookup"><span data-stu-id="53a42-134">The following code snippet registers an out-of-process background trigger.</span></span>

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

<span data-ttu-id="53a42-135">バックグラウンド タスクの登録パラメーターは登録時に検証されます。</span><span class="sxs-lookup"><span data-stu-id="53a42-135">Background task registration parameters are validated at the time of registration.</span></span> <span data-ttu-id="53a42-136">いずれかの登録パラメーターが有効でない場合は、エラーが返されます。</span><span class="sxs-lookup"><span data-stu-id="53a42-136">An error is returned if any of the registration parameters are invalid.</span></span> <span data-ttu-id="53a42-137">バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。</span><span class="sxs-lookup"><span data-stu-id="53a42-137">Ensure that your app gracefully handles scenarios where background task registration fails - if instead your app depends on having a valid registration object after attempting to register a task, it may crash.</span></span>

## <a name="trigger-the-background-task"></a><span data-ttu-id="53a42-138">バック グラウンド タスクをトリガーします。</span><span class="sxs-lookup"><span data-stu-id="53a42-138">Trigger the background task</span></span>

<span data-ttu-id="53a42-139">バック グラウンド タスクをトリガーする前に、 [BackgroundTaskRegistration](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.BackgroundTaskRegistration)を使用して、バック グラウンド タスクが登録されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="53a42-139">Before you trigger the background task, use [BackgroundTaskRegistration](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.BackgroundTaskRegistration) to verify that the background task is registered.</span></span> <span data-ttu-id="53a42-140">すべてのバック グラウンド タスクが登録されていることを確認する良い機会は、アプリの起動中にです。</span><span class="sxs-lookup"><span data-stu-id="53a42-140">A good time to verify that all of your background tasks are registered is during app launch.</span></span>

<span data-ttu-id="53a42-141">[ApplicationTrigger.RequestAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.applicationtrigger)を呼び出すことによって、バック グラウンド タスクをトリガーします。</span><span class="sxs-lookup"><span data-stu-id="53a42-141">Trigger the background task by calling [ApplicationTrigger.RequestAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.applicationtrigger).</span></span> <span data-ttu-id="53a42-142">任意の**ApplicationTrigger**インスタンスを実行します。</span><span class="sxs-lookup"><span data-stu-id="53a42-142">Any **ApplicationTrigger** instance will do.</span></span>

<span data-ttu-id="53a42-143">自体には、バック グラウンド タスクから、または、アプリがバック グラウンドの実行状態に**ApplicationTrigger.RequestAsync**を呼び出すことができないことに注意してください (アプリケーションの状態の詳細については、[アプリのライフ サイクル](app-lifecycle.md)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="53a42-143">Note that **ApplicationTrigger.RequestAsync** can't be called from the background task itself, or when the app is in the background running state (see [App lifecycle](app-lifecycle.md) for more information about application states).</span></span>
<span data-ttu-id="53a42-144">アプリがバック グラウンド アクティビティを実行するを防ぐエネルギーまたはプライバシーのポリシーを設定している場合、 [DisabledByPolicy](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.applicationtriggerresult)を返すこと可能性があります。</span><span class="sxs-lookup"><span data-stu-id="53a42-144">It may return [DisabledByPolicy](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.applicationtriggerresult) if the user has set energy or privacy policies that prevent the app from performing background activity.</span></span>
<span data-ttu-id="53a42-145">また、一度に 1 つだけ AppTrigger を実行できます。</span><span class="sxs-lookup"><span data-stu-id="53a42-145">Also, only one AppTrigger can run at a time.</span></span> <span data-ttu-id="53a42-146">別が既に実行されているときに、AppTrigger を実行しようとする場合、関数は[助けます](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.applicationtriggerresult)を返します。</span><span class="sxs-lookup"><span data-stu-id="53a42-146">If you attempt to run an AppTrigger while another is already running, the function will return [CurrentlyRunning](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.applicationtriggerresult).</span></span>

```csharp
var result = await _AppTrigger.RequestAsync();
```

## <a name="manage-resources-for-your-background-task"></a><span data-ttu-id="53a42-147">バック グラウンド タスクのリソースを管理します。</span><span class="sxs-lookup"><span data-stu-id="53a42-147">Manage resources for your background task</span></span>

<span data-ttu-id="53a42-148">[BackgroundExecutionManager.RequestAccessAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) を使用して、アプリのバックグラウンド アクティビティを制限するようにユーザーが設定しているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="53a42-148">Use [BackgroundExecutionManager.RequestAccessAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) to determine if the user has decided that your app’s background activity should be limited.</span></span> <span data-ttu-id="53a42-149">バッテリー使用量を注意し、ユーザーが望む操作を完了するために必要な場合にのみ、バックグラウンドで実行するようにしてください。</span><span class="sxs-lookup"><span data-stu-id="53a42-149">Be aware of your battery usage and only run in the background when it is necessary to complete an action that the user wants.</span></span> <span data-ttu-id="53a42-150">表示方法のユーザーの詳細については、[バック グラウンド アクティビティの最適化](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity)は、バック グラウンド アクティビティの設定を制御できます。</span><span class="sxs-lookup"><span data-stu-id="53a42-150">See [Optimize background activity](https://docs.microsoft.com/windows/uwp/debug-test-perf/optimize-background-activity) for more information about the ways users can control the settings for background activity.</span></span>  

- <span data-ttu-id="53a42-151">メモリ: アプリのメモリや電力使用を調整、オペレーティング システムで実行するバック グラウンド タスクを許可することを保証するキーです。</span><span class="sxs-lookup"><span data-stu-id="53a42-151">Memory: Tuning your app's memory and energy use is key to ensuring that the operating system will allow your background task to run.</span></span> <span data-ttu-id="53a42-152">[メモリ管理 Api](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx)を使用すると、バック グラウンド タスクを使用してメモリの量を参照してください。</span><span class="sxs-lookup"><span data-stu-id="53a42-152">Use the [Memory Management APIs](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx) to see how much memory your background task is using.</span></span> <span data-ttu-id="53a42-153">多くのメモリ、バック グラウンド タスクを使用して、実行中に別のアプリがフォア グラウンドでに保つために、OS がは難しくなります。</span><span class="sxs-lookup"><span data-stu-id="53a42-153">The more memory your background task uses, the harder it is for the OS to keep it running when another app is in the foreground.</span></span> <span data-ttu-id="53a42-154">アプリが実行できるすべてのバックグラウンド アクティビティについて、最終的に管理できるのはユーザーです。また、ユーザーは、アプリがどの程度バッテリー消費に影響しているかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="53a42-154">The user is ultimately in control of all background activity that your app can perform and has visibility on the impact your app has on battery use.</span></span>  
- <span data-ttu-id="53a42-155">CPU 時間: バック グラウンド タスクがトリガーの種類に基づいて取得するウォールク ロック時間の使用状況の時間の長さによって制限されます。</span><span class="sxs-lookup"><span data-stu-id="53a42-155">CPU time: Background tasks are limited by the amount of wall-clock usage time they get based on trigger type.</span></span> <span data-ttu-id="53a42-156">アプリケーション トリガーによってトリガーされるバック グラウンド タスクは、約 10 分間に制限されます。</span><span class="sxs-lookup"><span data-stu-id="53a42-156">Background tasks triggered by the Application trigger are limited to about 10 minutes.</span></span>

<span data-ttu-id="53a42-157">バックグラウンド タスクに適用されるリソースの制約については、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="53a42-157">See [Support your app with background tasks](support-your-app-with-background-tasks.md) for the resource constraints applied to background tasks.</span></span>

## <a name="remarks"></a><span data-ttu-id="53a42-158">注釈</span><span class="sxs-lookup"><span data-stu-id="53a42-158">Remarks</span></span>

<span data-ttu-id="53a42-159">Windows 10 以降、場合は、ユーザーはロック画面にバック グラウンド タスクを利用するために、アプリを追加する必要なくなりました。</span><span class="sxs-lookup"><span data-stu-id="53a42-159">Starting with Windows 10, it is no longer necessary for the user to add your app to the lock screen in order to utilize background tasks.</span></span>

<span data-ttu-id="53a42-160">バック グラウンド タスクでは、まず[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485)を呼び出した場合、 **ApplicationTrigger**を使用してのみ実行されます。</span><span class="sxs-lookup"><span data-stu-id="53a42-160">A background task will only run using an **ApplicationTrigger** if you have called [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) first.</span></span>

## <a name="related-topics"></a><span data-ttu-id="53a42-161">関連トピック</span><span class="sxs-lookup"><span data-stu-id="53a42-161">Related topics</span></span>

* [<span data-ttu-id="53a42-162">バックグラウンド タスクのガイドライン</span><span class="sxs-lookup"><span data-stu-id="53a42-162">Guidelines for background tasks</span></span>](guidelines-for-background-tasks.md)
* [<span data-ttu-id="53a42-163">バック グラウンド タスクのコード サンプル</span><span class="sxs-lookup"><span data-stu-id="53a42-163">Background task code sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BackgroundTask)
* <span data-ttu-id="53a42-164">[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)。</span><span class="sxs-lookup"><span data-stu-id="53a42-164">[Create and register an in-process background task](create-and-register-an-inproc-background-task.md).</span></span>
* [<span data-ttu-id="53a42-165">アウトプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="53a42-165">Create and register an out-of-process background task</span></span>](create-and-register-a-background-task.md)
* [<span data-ttu-id="53a42-166">バックグラウンド タスクのデバッグ</span><span class="sxs-lookup"><span data-stu-id="53a42-166">Debug a background task</span></span>](debug-a-background-task.md)
* [<span data-ttu-id="53a42-167">アプリケーション マニフェストでのバックグラウンド タスクの宣言</span><span class="sxs-lookup"><span data-stu-id="53a42-167">Declare background tasks in the application manifest</span></span>](declare-background-tasks-in-the-application-manifest.md)
* [<span data-ttu-id="53a42-168">アプリがバックグラウンドに移動したときのメモリの解放</span><span class="sxs-lookup"><span data-stu-id="53a42-168">Free memory when your app moves to the background</span></span>](reduce-memory-usage.md)
* [<span data-ttu-id="53a42-169">取り消されたバックグラウンド タスクの処理</span><span class="sxs-lookup"><span data-stu-id="53a42-169">Handle a cancelled background task</span></span>](handle-a-cancelled-background-task.md)
* [<span data-ttu-id="53a42-170">UWP アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)</span><span class="sxs-lookup"><span data-stu-id="53a42-170">How to trigger suspend, resume, and background events in UWP apps (when debugging)</span></span>](http://go.microsoft.com/fwlink/p/?linkid=254345)
* [<span data-ttu-id="53a42-171">バックグラウンド タスクの進捗状況と完了の監視</span><span class="sxs-lookup"><span data-stu-id="53a42-171">Monitor background task progress and completion</span></span>](monitor-background-task-progress-and-completion.md)
* [<span data-ttu-id="53a42-172">延長実行を使ってアプリの中断を延期する</span><span class="sxs-lookup"><span data-stu-id="53a42-172">Postpone app suspension with extended execution</span></span>](run-minimized-with-extended-execution.md)
* [<span data-ttu-id="53a42-173">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="53a42-173">Register a background task</span></span>](register-a-background-task.md)
* [<span data-ttu-id="53a42-174">バックグラウンド タスクによるシステム イベントへの応答</span><span class="sxs-lookup"><span data-stu-id="53a42-174">Respond to system events with background tasks</span></span>](respond-to-system-events-with-background-tasks.md)
* [<span data-ttu-id="53a42-175">バックグラウンド タスクを実行するための条件の設定</span><span class="sxs-lookup"><span data-stu-id="53a42-175">Set conditions for running a background task</span></span>](set-conditions-for-running-a-background-task.md)
* [<span data-ttu-id="53a42-176">バックグラウンド タスクのライブ タイルの更新</span><span class="sxs-lookup"><span data-stu-id="53a42-176">Update a live tile from a background task</span></span>](update-a-live-tile-from-a-background-task.md)
* [<span data-ttu-id="53a42-177">メンテナンス トリガーの使用</span><span class="sxs-lookup"><span data-stu-id="53a42-177">Use a maintenance trigger</span></span>](use-a-maintenance-trigger.md)
