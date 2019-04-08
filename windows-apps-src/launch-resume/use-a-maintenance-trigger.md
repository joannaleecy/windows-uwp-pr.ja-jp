---
title: メンテナンス トリガーの使用
description: デバイスが接続されているときに、MaintenanceTrigger クラスを使って軽量のコードをバックグラウンドで実行する方法について説明します。
ms.assetid: 727D9D84-6C1D-4DF3-B3B0-2204EA4D76DD
ms.date: 07/06/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
ms.openlocfilehash: 53107ca6add4193737ab0d00497bbe6324bee44f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661857"
---
# <a name="use-a-maintenance-trigger"></a><span data-ttu-id="62936-104">メンテナンス トリガーの使用</span><span class="sxs-lookup"><span data-stu-id="62936-104">Use a maintenance trigger</span></span>

<span data-ttu-id="62936-105">**重要な API**</span><span class="sxs-lookup"><span data-stu-id="62936-105">**Important APIs**</span></span>

- [<span data-ttu-id="62936-106">**MaintenanceTrigger**</span><span class="sxs-lookup"><span data-stu-id="62936-106">**MaintenanceTrigger**</span></span>](https://msdn.microsoft.com/library/windows/apps/hh700517)
- [<span data-ttu-id="62936-107">**BackgroundTaskBuilder**</span><span class="sxs-lookup"><span data-stu-id="62936-107">**BackgroundTaskBuilder**</span></span>](https://msdn.microsoft.com/library/windows/apps/br224768)
- [<span data-ttu-id="62936-108">**SystemCondition**</span><span class="sxs-lookup"><span data-stu-id="62936-108">**SystemCondition**</span></span>](https://msdn.microsoft.com/library/windows/apps/br224834)

<span data-ttu-id="62936-109">デバイスが接続されているときに、[**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517) クラスを使って軽量のコードをバックグラウンドで実行する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="62936-109">Learn how to use the [**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517) class to run lightweight code in the background while the device is plugged in.</span></span>

## <a name="create-a-maintenance-trigger-object"></a><span data-ttu-id="62936-110">メンテナンス トリガー オブジェクトを作る</span><span class="sxs-lookup"><span data-stu-id="62936-110">Create a maintenance trigger object</span></span>

<span data-ttu-id="62936-111">この例は、デバイスが接続されているときにアプリを拡張するためにバックグラウンドで実行できる軽量のコードがあることを前提にしています。</span><span class="sxs-lookup"><span data-stu-id="62936-111">This example assumes that you have lightweight code you can run in the background to enhance your app while the device is plugged in.</span></span> <span data-ttu-id="62936-112">ここでは主に、[**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839) に似た [**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517) について扱います。</span><span class="sxs-lookup"><span data-stu-id="62936-112">This topic focuses on the [**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517), which is similar to [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839).</span></span>

<span data-ttu-id="62936-113">バックグラウンド タスク クラスの作成について詳しくは、「[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)」または「[アウトプロセス バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="62936-113">More information on writing a background task class is available in [Create and register an in-process background task](create-and-register-an-inproc-background-task.md) or [Create and register an out-of-process background task](create-and-register-a-background-task.md).</span></span>

<span data-ttu-id="62936-114">新しい [**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517) オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="62936-114">Create a new [**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517) object.</span></span> <span data-ttu-id="62936-115">2 つ目のパラメーター (*OneShot*) では、メンテナンス タスクを一度だけ実行するか、定期的に実行を続けるかを指定します。</span><span class="sxs-lookup"><span data-stu-id="62936-115">The second parameter, *OneShot*, specifies whether the maintenance task will run only once or continue to run periodically.</span></span> <span data-ttu-id="62936-116">*OneShot* を true に設定する場合は、1 つ目のパラメーター (*FreshnessTime*) に、バックグラウンド タスクをスケジュールするまで待機する時間 (分単位) を指定します。</span><span class="sxs-lookup"><span data-stu-id="62936-116">If *OneShot* is set to true, the first parameter (*FreshnessTime*) specifies the number of minutes to wait before scheduling the background task.</span></span> <span data-ttu-id="62936-117">*OneShot* を false に設定する場合は、*FreshnessTime* でバックグラウンド タスクを実行する間隔を指定します。</span><span class="sxs-lookup"><span data-stu-id="62936-117">If *OneShot* is set to false, *FreshnessTime* specifies how often the background task will run.</span></span>

> [!NOTE]
> <span data-ttu-id="62936-118">場合*FreshnessTime*がバック グラウンド タスクの登録を試みているときに例外がスローに未満、15 分に設定します。</span><span class="sxs-lookup"><span data-stu-id="62936-118">If *FreshnessTime* is set to less than 15 minutes, an exception is thrown when attempting to register the background task.</span></span>

<span data-ttu-id="62936-119">このコード例では、1 時間に 1 回実行するトリガーを作成します。</span><span class="sxs-lookup"><span data-stu-id="62936-119">This example code creates a trigger that runs once an hour.</span></span>

```csharp
uint waitIntervalMinutes = 60;
MaintenanceTrigger taskTrigger = new MaintenanceTrigger(waitIntervalMinutes, false);
```

```cppwinrt
uint32_t waitIntervalMinutes{ 60 };
Windows::ApplicationModel::Background::MaintenanceTrigger taskTrigger{ waitIntervalMinutes, false };
```

```cpp
unsigned int waitIntervalMinutes = 60;
MaintenanceTrigger ^ taskTrigger = ref new MaintenanceTrigger(waitIntervalMinutes, false);
```

## <a name="optional-add-a-condition"></a><span data-ttu-id="62936-120">(省略可能) 条件の追加</span><span class="sxs-lookup"><span data-stu-id="62936-120">(Optional) Add a condition</span></span>

- <span data-ttu-id="62936-121">いつタスクを実行するかを制御するバックグラウンド タスクの条件を必要に応じて作成します。</span><span class="sxs-lookup"><span data-stu-id="62936-121">If necessary, create a background task condition to control when the task runs.</span></span> <span data-ttu-id="62936-122">条件を指定すると、条件が満たされるまではバックグラウンド タスクが実行されないようにすることができます。詳しくは「[バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="62936-122">A condition prevents your background task from running until the condition is met - for more information, see [Set conditions for running a background task](set-conditions-for-running-a-background-task.md)</span></span>

<span data-ttu-id="62936-123">次の例では、インターネットが利用できる場合 (またはインターネットが利用できるようになった場合) にメンテナンスが実行されるように、条件を **InternetAvailable** に設定します。</span><span class="sxs-lookup"><span data-stu-id="62936-123">In this example, the condition is set to **InternetAvailable** so that maintenance runs when the Internet is available (or when it becomes available).</span></span> <span data-ttu-id="62936-124">指定できるバックグラウンド タスク条件の一覧については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="62936-124">For a list of possible background task conditions, see [**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835).</span></span>

<span data-ttu-id="62936-125">次のコードでは、メンテナンス タスク ビルダーに条件を追加します。</span><span class="sxs-lookup"><span data-stu-id="62936-125">The following code adds a condition to the maintenance task builder:</span></span>

```csharp
SystemCondition exampleCondition = new SystemCondition(SystemConditionType.InternetAvailable);
```

```cppwinrt
Windows::ApplicationModel::Background::SystemCondition exampleCondition{
    Windows::ApplicationModel::Background::SystemConditionType::InternetAvailable };
```

```cpp
SystemCondition ^ exampleCondition = ref new SystemCondition(SystemConditionType::InternetAvailable);
```

## <a name="register-the-background-task"></a><span data-ttu-id="62936-126">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="62936-126">Register the background task</span></span>

- <span data-ttu-id="62936-127">バックグラウンド タスクの登録関数を呼び出してバックグラウンド タスクを登録します。</span><span class="sxs-lookup"><span data-stu-id="62936-127">Register the background task by calling your background task registration function.</span></span> <span data-ttu-id="62936-128">バックグラウンド タスクの登録について詳しくは、「[バックグラウンド タスクの登録](register-a-background-task.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="62936-128">For more information on registering background tasks, see [Register a background task](register-a-background-task.md).</span></span>

<span data-ttu-id="62936-129">次のコードでは、メンテナンス タスクを登録します。</span><span class="sxs-lookup"><span data-stu-id="62936-129">The following code registers the maintenance task.</span></span> <span data-ttu-id="62936-130">`entryPoint` と指定しているので、バックグラウンド タスクとアプリを異なるプロセスで実行するように想定されていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="62936-130">Note that it assumes your background task runs in a separate process from your app because it specifies `entryPoint`.</span></span> <span data-ttu-id="62936-131">バックグラウンド タスクとアプリを同じプロセスで実行する場合は、`entryPoint` を指定しません。</span><span class="sxs-lookup"><span data-stu-id="62936-131">If your background task runs in the same process as your app, you do not specify `entryPoint`.</span></span>

```csharp
string entryPoint = "Tasks.ExampleBackgroundTaskClass";
string taskName   = "Maintenance background task example";

BackgroundTaskRegistration task = RegisterBackgroundTask(entryPoint, taskName, taskTrigger, exampleCondition);
```

```cppwinrt
std::wstring entryPoint{ L"Tasks.ExampleBackgroundTaskClass" };
std::wstring taskName{ L"Maintenance background task example" };

Windows::ApplicationModel::Background::BackgroundTaskRegistration task{
    RegisterBackgroundTask(entryPoint, taskName, taskTrigger, exampleCondition) };
```

```cpp
String ^ entryPoint = "Tasks.ExampleBackgroundTaskClass";
String ^ taskName   = "Maintenance background task example";

BackgroundTaskRegistration ^ task = RegisterBackgroundTask(entryPoint, taskName, taskTrigger, exampleCondition);
```

> [!NOTE]
> <span data-ttu-id="62936-132">デスクトップ以外のすべてのデバイス ファミリでは、デバイスのメモリが少なくなった場合、バックグラウンド タスクが終了することがあります。</span><span class="sxs-lookup"><span data-stu-id="62936-132">For all device families except desktop, if the device becomes low on memory, background tasks may be terminated.</span></span> <span data-ttu-id="62936-133">メモリ不足の例外が検出されないか、検出されてもアプリによって処理されない場合、バックグラウンド タスクは、警告や OnCanceled イベントの発生なしに終了します。</span><span class="sxs-lookup"><span data-stu-id="62936-133">If an out of memory exception is not surfaced, or the app does not handle it, then the background task will be terminated without warning and without raising the OnCanceled event.</span></span> <span data-ttu-id="62936-134">こうすることで、フォアグラウンドのアプリのユーザー エクスペリエンスが保証されます。</span><span class="sxs-lookup"><span data-stu-id="62936-134">This helps to ensure the user experience of the app in the foreground.</span></span> <span data-ttu-id="62936-135">バックグラウンド タスクは、このシナリオを処理できるように設計する必要があります。</span><span class="sxs-lookup"><span data-stu-id="62936-135">Your background task should be designed to handle this scenario.</span></span>

> [!NOTE]
> <span data-ttu-id="62936-136">ユニバーサル Windows プラットフォーム アプリを呼び出す必要があります[ **RequestAccessAsync** ](https://msdn.microsoft.com/library/windows/apps/hh700485)バック グラウンドのトリガーの種類のいずれかを登録する前にします。</span><span class="sxs-lookup"><span data-stu-id="62936-136">Universal Windows Platform apps must call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) before registering any of the background trigger types.</span></span>

<span data-ttu-id="62936-137">アプリに対する更新プログラムのリリース後にユニバーサル Windows アプリが引き続き適切に実行されるようにするには、更新後にアプリが起動する際に、[**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471)、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) の順に呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="62936-137">To ensure that your Universal Windows app continues to run properly after you release an update to your app, you must call [**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471) and then call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) when your app launches after being updated.</span></span> <span data-ttu-id="62936-138">詳しくは、「[バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="62936-138">For more information, see [Guidelines for background tasks](guidelines-for-background-tasks.md).</span></span>

> [!NOTE]
> <span data-ttu-id="62936-139">バックグラウンド タスクの登録パラメーターは登録時に検証されます。</span><span class="sxs-lookup"><span data-stu-id="62936-139">Background task registration parameters are validated at the time of registration.</span></span> <span data-ttu-id="62936-140">いずれかの登録パラメーターが有効でない場合は、エラーが返されます。</span><span class="sxs-lookup"><span data-stu-id="62936-140">An error is returned if any of the registration parameters are invalid.</span></span> <span data-ttu-id="62936-141">バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。</span><span class="sxs-lookup"><span data-stu-id="62936-141">Ensure that your app gracefully handles scenarios where background task registration fails - if instead your app depends on having a valid registration object after attempting to register a task, it may crash.</span></span>

## <a name="related-topics"></a><span data-ttu-id="62936-142">関連トピック</span><span class="sxs-lookup"><span data-stu-id="62936-142">Related topics</span></span>

* <span data-ttu-id="62936-143">[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)</span><span class="sxs-lookup"><span data-stu-id="62936-143">[Create and register an in-process background task](create-and-register-an-inproc-background-task.md).</span></span>
* [<span data-ttu-id="62936-144">アウトプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="62936-144">Create and register an out-of-process background task</span></span>](create-and-register-a-background-task.md)
* [<span data-ttu-id="62936-145">アプリケーション マニフェストでのバックグラウンド タスクの宣言</span><span class="sxs-lookup"><span data-stu-id="62936-145">Declare background tasks in the application manifest</span></span>](declare-background-tasks-in-the-application-manifest.md)
* [<span data-ttu-id="62936-146">取り消されたバックグラウンド タスクの処理</span><span class="sxs-lookup"><span data-stu-id="62936-146">Handle a cancelled background task</span></span>](handle-a-cancelled-background-task.md)
* [<span data-ttu-id="62936-147">バックグラウンド タスクの進捗状況と完了の監視</span><span class="sxs-lookup"><span data-stu-id="62936-147">Monitor background task progress and completion</span></span>](monitor-background-task-progress-and-completion.md)
* [<span data-ttu-id="62936-148">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="62936-148">Register a background task</span></span>](register-a-background-task.md)
* [<span data-ttu-id="62936-149">バックグラウンド タスクによるシステム イベントへの応答</span><span class="sxs-lookup"><span data-stu-id="62936-149">Respond to system events with background tasks</span></span>](respond-to-system-events-with-background-tasks.md)
* [<span data-ttu-id="62936-150">バックグラウンド タスクを実行するための条件の設定</span><span class="sxs-lookup"><span data-stu-id="62936-150">Set conditions for running a background task</span></span>](set-conditions-for-running-a-background-task.md)
* [<span data-ttu-id="62936-151">バックグラウンド タスクのライブ タイルの更新</span><span class="sxs-lookup"><span data-stu-id="62936-151">Update a live tile from a background task</span></span>](update-a-live-tile-from-a-background-task.md)
* [<span data-ttu-id="62936-152">タイマーでのバックグラウンド タスクの実行</span><span class="sxs-lookup"><span data-stu-id="62936-152">Run a background task on a timer</span></span>](run-a-background-task-on-a-timer-.md)
* [<span data-ttu-id="62936-153">バックグラウンド タスクのガイドライン</span><span class="sxs-lookup"><span data-stu-id="62936-153">Guidelines for background tasks</span></span>](guidelines-for-background-tasks.md)
* [<span data-ttu-id="62936-154">バックグラウンド タスクのデバッグ</span><span class="sxs-lookup"><span data-stu-id="62936-154">Debug a background task</span></span>](debug-a-background-task.md)
* [<span data-ttu-id="62936-155">トリガーする方法を中断、再開、および (デバッグ) 場合は、UWP アプリでイベントをバック グラウンド</span><span class="sxs-lookup"><span data-stu-id="62936-155">How to trigger suspend, resume, and background events in UWP apps (when debugging)</span></span>](https://go.microsoft.com/fwlink/p/?linkid=254345)
