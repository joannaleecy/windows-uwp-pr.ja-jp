---
author: TylerMSFT
title: バックグラウンド タスクを実行するための条件の設定
description: バックグラウンド タスクをいつ実行するかを制御する条件の設定方法について説明します。
ms.assetid: 10ABAC9F-AA8C-41AC-A29D-871CD9AD9471
ms.author: twhitney
ms.date: 07/06/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、タスクを背景します。
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
ms.openlocfilehash: 556a787eb1e92e4c8adb7457235afb45c02df2dc
ms.sourcegitcommit: c6d6f8b54253e79354f8db14e5cf3b113a3e5014
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/24/2018
ms.locfileid: "2830451"
---
# <a name="set-conditions-for-running-a-background-task"></a><span data-ttu-id="e2ba0-104">バックグラウンド タスクを実行するための条件の設定</span><span class="sxs-lookup"><span data-stu-id="e2ba0-104">Set conditions for running a background task</span></span>

**<span data-ttu-id="e2ba0-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="e2ba0-105">Important APIs</span></span>**

- [**<span data-ttu-id="e2ba0-106">SystemCondition</span><span class="sxs-lookup"><span data-stu-id="e2ba0-106">SystemCondition</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224834)
- [**<span data-ttu-id="e2ba0-107">SystemConditionType</span><span class="sxs-lookup"><span data-stu-id="e2ba0-107">SystemConditionType</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224835)
- [**<span data-ttu-id="e2ba0-108">BackgroundTaskBuilder</span><span class="sxs-lookup"><span data-stu-id="e2ba0-108">BackgroundTaskBuilder</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224768)

<span data-ttu-id="e2ba0-109">バックグラウンド タスクをいつ実行するかを制御する条件の設定方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-109">Learn how to set conditions that control when your background task will run.</span></span>

<span data-ttu-id="e2ba0-110">場合によっては、バック グラウンド タスクには、特定の条件を満たす必要があるバック グラウンド タスクを完了するが必要です。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-110">Sometimes, background tasks require certain conditions to be met for the background task to succeed.</span></span> <span data-ttu-id="e2ba0-111">バックグラウンド タスクを登録するときに、[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835) で指定される条件を 1 つ以上指定することができます。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-111">You can specify one or more of the conditions specified by [**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835) when registering your background task.</span></span> <span data-ttu-id="e2ba0-112">トリガーが発行された後は、条件がチェックされます。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-112">The condition will be checked after the trigger has been fired.</span></span> <span data-ttu-id="e2ba0-113">[バック グラウンド タスクが保存されるが必要なすべての条件が満たされるまでは実行されません。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-113">The background task will then be queued, but it will not run until all the required conditions are satisfied.</span></span>

<span data-ttu-id="e2ba0-114">バック グラウンド タスクに条件を置くと、タスクが不必要に実行されていることを防ぐことでバッテリと CPU が保存されます。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-114">Putting conditions on background tasks saves battery life and CPU by preventing tasks from running unnecessarily.</span></span> <span data-ttu-id="e2ba0-115">たとえば、バックグラウンド タスクがタイマーで実行され、インターネット接続が必要な場合は、タスクを登録する前に、**InternetAvailable** 条件を [**TaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) に追加します。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-115">For example, if your background task runs on a timer and requires Internet connectivity, add the **InternetAvailable** condition to the [**TaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) before registering the task.</span></span> <span data-ttu-id="e2ba0-116">これにより、タイマーの設定時間が経過し、*かつ*インターネットが利用可能な場合にのみバックグラウンド タスクが実行されるため、タスクがシステム リソースやバッテリー残量を無駄に消費することはなくなります。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-116">This will help prevent the task from using system resources and battery life unnecessarily by only running the background task when the timer has elapsed *and* the Internet is available.</span></span>

<span data-ttu-id="e2ba0-117">同じ[**TaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768)に複数回**AddCondition**を使用して複数の条件を結合することもできます。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-117">It is also possible to combine multiple conditions by calling **AddCondition** multiple times on the same [**TaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768).</span></span> <span data-ttu-id="e2ba0-118">**UserPresent** や **UserNotPresent** など競合する条件を追加しないように注意してください。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-118">Take care not to add conflicting conditions, such as **UserPresent** and **UserNotPresent**.</span></span>

## <a name="create-a-systemcondition-object"></a><span data-ttu-id="e2ba0-119">SystemCondition オブジェクトを作る</span><span class="sxs-lookup"><span data-stu-id="e2ba0-119">Create a SystemCondition object</span></span>

<span data-ttu-id="e2ba0-120">ここでは、既にバックグラウンド タスクがアプリと関連付けられており、アプリでは、**taskBuilder** という [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) オブジェクトを作るためのコードが記述済みであることを前提とします。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-120">This topic assumes that you have a background task already associated with your app, and that your app already includes code that creates a [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) object named **taskBuilder**.</span></span>  <span data-ttu-id="e2ba0-121">最初にバックグラウンド タスクを作成する必要がある場合は、「[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)」または「[アウトプロセス バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-121">See [Create and register an in-process background task](create-and-register-an-inproc-background-task.md) or [Create and register an out-of-process background task](create-and-register-a-background-task.md) if you need to create a background task first.</span></span>

<span data-ttu-id="e2ba0-122">このトピックの内容は、アウトプロセスで実行されるバックグラウンド タスク、およびフォアグラウンド アプリと同じプロセスで実行されるバックグラウンド タスクに適用されます。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-122">This topic applies to background tasks that run out-of-process as well as those that run in the same process as the foreground app.</span></span>

<span data-ttu-id="e2ba0-123">条件を追加する前に、バック グラウンド タスクの実行を有効にする必要がある条件を表す[**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834)オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-123">Before adding the condition, create a [**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834) object to represent the condition that must be in effect for a background task to run.</span></span> <span data-ttu-id="e2ba0-124">段階では、 [**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)列挙値が満たす必要がある条件を指定します。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-124">In the constructor, specify the condition that must be met with a [**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835) enumeration value.</span></span>

<span data-ttu-id="e2ba0-125">次のコードでは、 **InternetAvailable**条件を指定する[**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834)オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-125">The following code creates a [**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834) object that specifies the **InternetAvailable** condition:</span></span>

```csharp
SystemCondition internetCondition = new SystemCondition(SystemConditionType.InternetAvailable);
```

```cppwinrt
Windows::ApplicationModel::Background::SystemCondition internetCondition{
    Windows::ApplicationModel::Background::SystemConditionType::InternetAvailable };
```

```cpp
SystemCondition ^ internetCondition = ref new SystemCondition(SystemConditionType::InternetAvailable);
```

## <a name="add-the-systemcondition-object-to-your-background-task"></a><span data-ttu-id="e2ba0-126">SystemCondition オブジェクトをバックグラウンド タスクに追加する</span><span class="sxs-lookup"><span data-stu-id="e2ba0-126">Add the SystemCondition object to your background task</span></span>

<span data-ttu-id="e2ba0-127">条件を追加するには、[**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) オブジェクトで [**AddCondition**](https://msdn.microsoft.com/library/windows/apps/br224769) メソッドを呼び出して、[**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834) オブジェクトに渡します。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-127">To add the condition, call the [**AddCondition**](https://msdn.microsoft.com/library/windows/apps/br224769) method on the [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) object, and pass it the [**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834) object.</span></span>

<span data-ttu-id="e2ba0-128">次のコードでは、 **taskBuilder**を使用して、 **InternetAvailable**条件を追加します。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-128">The following code uses **taskBuilder** to add the **InternetAvailable** condition.</span></span>

```csharp
taskBuilder.AddCondition(internetCondition);
```

```cppwinrt
taskBuilder.AddCondition(internetCondition);
```

```cpp
taskBuilder->AddCondition(internetCondition);
```

## <a name="register-your-background-task"></a><span data-ttu-id="e2ba0-129">バックグラウンド タスクを登録する</span><span class="sxs-lookup"><span data-stu-id="e2ba0-129">Register your background task</span></span>

<span data-ttu-id="e2ba0-130">[**登録**](https://msdn.microsoft.com/library/windows/apps/br224772)メソッド] で、バック グラウンド タスクを登録するようになりましたと、指定した条件が満たされるまで、バック グラウンド タスクは開始されません。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-130">Now you can register your background task with the [**Register**](https://msdn.microsoft.com/library/windows/apps/br224772) method, and the background task will not start until the specified condition is met.</span></span>

<span data-ttu-id="e2ba0-131">次のコードでは、タスクを登録し、生成される BackgroundTaskRegistration オブジェクトを保存します。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-131">The following code registers the task and stores the resulting BackgroundTaskRegistration object:</span></span>

```csharp
BackgroundTaskRegistration task = taskBuilder.Register();
```

```cppwinrt
Windows::ApplicationModel::Background::BackgroundTaskRegistration task{ recurringTaskBuilder.Register() };
```

```cpp
BackgroundTaskRegistration ^ task = taskBuilder->Register();
```

> [!NOTE]
> <span data-ttu-id="e2ba0-132">ユニバーサル Windows アプリは、どの種類のバックグラウンド トリガーを登録する場合でも、先に [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-132">Universal Windows apps must call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) before registering any of the background trigger types.</span></span>

<span data-ttu-id="e2ba0-133">更新プログラムのリリース後にユニバーサル Windows アプリが引き続き適切に実行されるようにするには、更新後にアプリが起動する際に、[**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471)、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) の順に呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-133">To ensure that your Universal Windows app continues to run properly after you release an update, you must call [**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471) and then call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) when your app launches after being updated.</span></span> <span data-ttu-id="e2ba0-134">詳しくは、「[バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-134">For more information, see [Guidelines for background tasks](guidelines-for-background-tasks.md).</span></span>

> [!NOTE]
> <span data-ttu-id="e2ba0-135">バックグラウンド タスクの登録パラメーターは登録時に検証されます。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-135">Background task registration parameters are validated at the time of registration.</span></span> <span data-ttu-id="e2ba0-136">いずれかの登録パラメーターが有効でない場合は、エラーが返されます。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-136">An error is returned if any of the registration parameters are invalid.</span></span> <span data-ttu-id="e2ba0-137">バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-137">Ensure that your app gracefully handles scenarios where background task registration fails - if instead your app depends on having a valid registration object after attempting to register a task, it may crash.</span></span>

## <a name="place-multiple-conditions-on-your-background-task"></a><span data-ttu-id="e2ba0-138">バックグラウンド タスクに複数の条件を設定する</span><span class="sxs-lookup"><span data-stu-id="e2ba0-138">Place multiple conditions on your background task</span></span>

<span data-ttu-id="e2ba0-139">複数の条件を追加するには、アプリから [**で**](https://msdn.microsoft.com/library/windows/apps/br224769) メソッドを複数回呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-139">To add multiple conditions, your app makes multiple calls to the [**AddCondition**](https://msdn.microsoft.com/library/windows/apps/br224769) method.</span></span> <span data-ttu-id="e2ba0-140">呼び出しは必ず、タスクの登録が有効になる前に行います。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-140">These calls must come before task registration to be effective.</span></span>

> [!NOTE]
> <span data-ttu-id="e2ba0-141">バック グラウンド タスクに競合する条件を追加しないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-141">Take care not to add conflicting conditions to a background task.</span></span>

<span data-ttu-id="e2ba0-142">次のコードを作成して、バック グラウンド タスクを登録のコンテキストで複数の条件を示します。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-142">The following snippet shows multiple conditions in the context of creating and registering a background task.</span></span>

```csharp
// Set up the background task.
TimeTrigger hourlyTrigger = new TimeTrigger(60, false);

var recurringTaskBuilder = new BackgroundTaskBuilder();

recurringTaskBuilder.Name           = "Hourly background task";
recurringTaskBuilder.TaskEntryPoint = "Tasks.ExampleBackgroundTaskClass";
recurringTaskBuilder.SetTrigger(hourlyTrigger);

// Begin adding conditions.
SystemCondition userCondition     = new SystemCondition(SystemConditionType.UserPresent);
SystemCondition internetCondition = new SystemCondition(SystemConditionType.InternetAvailable);

recurringTaskBuilder.AddCondition(userCondition);
recurringTaskBuilder.AddCondition(internetCondition);

// Done adding conditions, now register the background task.

BackgroundTaskRegistration task = recurringTaskBuilder.Register();
```

```cppwinrt
// Set up the background task.
Windows::ApplicationModel::Background::TimeTrigger hourlyTrigger{ 60, false };

Windows::ApplicationModel::Background::BackgroundTaskBuilder recurringTaskBuilder;

recurringTaskBuilder.Name(L"Hourly background task");
recurringTaskBuilder.TaskEntryPoint(L"Tasks.ExampleBackgroundTaskClass");
recurringTaskBuilder.SetTrigger(hourlyTrigger);

// Begin adding conditions.
Windows::ApplicationModel::Background::SystemCondition userCondition{
    Windows::ApplicationModel::Background::SystemConditionType::UserPresent };
Windows::ApplicationModel::Background::SystemCondition internetCondition{
    Windows::ApplicationModel::Background::SystemConditionType::InternetAvailable };

recurringTaskBuilder.AddCondition(userCondition);
recurringTaskBuilder.AddCondition(internetCondition);

// Done adding conditions, now register the background task.
Windows::ApplicationModel::Background::BackgroundTaskRegistration task{ recurringTaskBuilder.Register() };
```

```cpp
// Set up the background task.
TimeTrigger ^ hourlyTrigger = ref new TimeTrigger(60, false);

auto recurringTaskBuilder = ref new BackgroundTaskBuilder();

recurringTaskBuilder->Name           = "Hourly background task";
recurringTaskBuilder->TaskEntryPoint = "Tasks.ExampleBackgroundTaskClass";
recurringTaskBuilder->SetTrigger(hourlyTrigger);

// Begin adding conditions.
SystemCondition ^ userCondition     = ref new SystemCondition(SystemConditionType::UserPresent);
SystemCondition ^ internetCondition = ref new SystemCondition(SystemConditionType::InternetAvailable);

recurringTaskBuilder->AddCondition(userCondition);
recurringTaskBuilder->AddCondition(internetCondition);

// Done adding conditions, now register the background task.
BackgroundTaskRegistration ^ task = recurringTaskBuilder->Register();
```

## <a name="remarks"></a><span data-ttu-id="e2ba0-143">注釈</span><span class="sxs-lookup"><span data-stu-id="e2ba0-143">Remarks</span></span>

> [!NOTE]
> <span data-ttu-id="e2ba0-144">不要なときに実行されないし、必要なタイミングのみが実行されるように、バック グラウンド タスクに条件を選択します。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-144">Choose conditions for your background task so that it only runs when it's needed, and doesn't run when it shouldn't.</span></span> <span data-ttu-id="e2ba0-145">バックグラウンド タスクの各条件については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e2ba0-145">See [**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835) for descriptions of the different background task conditions.</span></span>

## <a name="related-topics"></a><span data-ttu-id="e2ba0-146">関連トピック</span><span class="sxs-lookup"><span data-stu-id="e2ba0-146">Related topics</span></span>

* [<span data-ttu-id="e2ba0-147">アウトプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="e2ba0-147">Create and register an out-of-process background task</span></span>](create-and-register-a-background-task.md)
* [<span data-ttu-id="e2ba0-148">インプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="e2ba0-148">Create and register an in-process background task</span></span>](create-and-register-an-inproc-background-task.md)
* [<span data-ttu-id="e2ba0-149">アプリケーション マニフェストでのバックグラウンド タスクの宣言</span><span class="sxs-lookup"><span data-stu-id="e2ba0-149">Declare background tasks in the application manifest</span></span>](declare-background-tasks-in-the-application-manifest.md)
* [<span data-ttu-id="e2ba0-150">取り消されたバックグラウンド タスクの処理</span><span class="sxs-lookup"><span data-stu-id="e2ba0-150">Handle a cancelled background task</span></span>](handle-a-cancelled-background-task.md)
* [<span data-ttu-id="e2ba0-151">バックグラウンド タスクの進捗状況と完了の監視</span><span class="sxs-lookup"><span data-stu-id="e2ba0-151">Monitor background task progress and completion</span></span>](monitor-background-task-progress-and-completion.md)
* [<span data-ttu-id="e2ba0-152">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="e2ba0-152">Register a background task</span></span>](register-a-background-task.md)
* [<span data-ttu-id="e2ba0-153">バックグラウンド タスクによるシステム イベントへの応答</span><span class="sxs-lookup"><span data-stu-id="e2ba0-153">Respond to system events with background tasks</span></span>](respond-to-system-events-with-background-tasks.md)
* [<span data-ttu-id="e2ba0-154">バックグラウンド タスクのライブ タイルの更新</span><span class="sxs-lookup"><span data-stu-id="e2ba0-154">Update a live tile from a background task</span></span>](update-a-live-tile-from-a-background-task.md)
* [<span data-ttu-id="e2ba0-155">メンテナンス トリガーの使用</span><span class="sxs-lookup"><span data-stu-id="e2ba0-155">Use a maintenance trigger</span></span>](use-a-maintenance-trigger.md)
* [<span data-ttu-id="e2ba0-156">タイマーでのバックグラウンド タスクの実行</span><span class="sxs-lookup"><span data-stu-id="e2ba0-156">Run a background task on a timer</span></span>](run-a-background-task-on-a-timer-.md)
* [<span data-ttu-id="e2ba0-157">バックグラウンド タスクのガイドライン</span><span class="sxs-lookup"><span data-stu-id="e2ba0-157">Guidelines for background tasks</span></span>](guidelines-for-background-tasks.md)
* [<span data-ttu-id="e2ba0-158">バックグラウンド タスクのデバッグ</span><span class="sxs-lookup"><span data-stu-id="e2ba0-158">Debug a background task</span></span>](debug-a-background-task.md)
* [<span data-ttu-id="e2ba0-159">UWP アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)</span><span class="sxs-lookup"><span data-stu-id="e2ba0-159">How to trigger suspend, resume, and background events in UWP apps (when debugging)</span></span>](http://go.microsoft.com/fwlink/p/?linkid=254345)
