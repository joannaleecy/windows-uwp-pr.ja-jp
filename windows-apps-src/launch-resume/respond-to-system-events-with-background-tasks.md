---
author: TylerMSFT
title: バックグラウンド タスクによるシステム イベントへの応答
description: SystemTrigger イベントに応答するバックグラウンド タスクを作成する方法について説明します。
ms.assetid: 43C21FEA-28B9-401D-80BE-A61B71F01A89
ms.author: twhitney
ms.date: 07/06/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, バック グラウンド タスク
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
ms.openlocfilehash: 45f6e10bc355e3a2dc054d54fef35fbeb1095dc7
ms.sourcegitcommit: 1e5590dd10d606a910da6deb67b6a98f33235959
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/31/2018
ms.locfileid: "3231860"
---
# <a name="respond-to-system-events-with-background-tasks"></a><span data-ttu-id="f1cd9-104">バックグラウンド タスクによるシステム イベントへの応答</span><span class="sxs-lookup"><span data-stu-id="f1cd9-104">Respond to system events with background tasks</span></span>

**<span data-ttu-id="f1cd9-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="f1cd9-105">Important APIs</span></span>**

- [**<span data-ttu-id="f1cd9-106">IBackgroundTask</span><span class="sxs-lookup"><span data-stu-id="f1cd9-106">IBackgroundTask</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224794)
- [**<span data-ttu-id="f1cd9-107">BackgroundTaskBuilder</span><span class="sxs-lookup"><span data-stu-id="f1cd9-107">BackgroundTaskBuilder</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224768)
- [**<span data-ttu-id="f1cd9-108">SystemTrigger</span><span class="sxs-lookup"><span data-stu-id="f1cd9-108">SystemTrigger</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224838)

<span data-ttu-id="f1cd9-109">[**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839) イベントに応答するバックグラウンド タスクを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-109">Learn how to create a background task that responds to [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839) events.</span></span>

<span data-ttu-id="f1cd9-110">このトピックは、既にアプリにバックグラウンド タスク クラスが作られており、システムがトリガーするイベント (インターネットの可用性が変わる、ユーザーがログインするなど) に応じてこのタスクを実行する必要があることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-110">This topic assumes that you have a background task class written for your app, and that this task needs to run in response to an event triggered by the system such as when internet availability changes or the user logging in.</span></span> <span data-ttu-id="f1cd9-111">ここでは、主に [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839) クラスについて扱います。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-111">This topic focuses on the [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839) class.</span></span> <span data-ttu-id="f1cd9-112">バックグラウンド タスク クラスの作成について詳しくは、「[Create and register an in-process background task (インプロセスのバックグラウンド タスクの作成と登録)](create-and-register-an-inproc-background-task.md)」または「[Create and register an out-of-process background task (アウトプロセスで実行されるバックグラウンド タスクの作成と登録)](create-and-register-a-background-task.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-112">More information on writing a background task class is available in [Create and register an in-process background task](create-and-register-an-inproc-background-task.md) or [Create and register an out-of-process background task](create-and-register-a-background-task.md).</span></span>

## <a name="create-a-systemtrigger-object"></a><span data-ttu-id="f1cd9-113">SystemTrigger オブジェクトを作る</span><span class="sxs-lookup"><span data-stu-id="f1cd9-113">Create a SystemTrigger object</span></span>

<span data-ttu-id="f1cd9-114">アプリ コードで新規の [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224838) オブジェクトを作ります。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-114">In your app code, create a new [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224838) object.</span></span> <span data-ttu-id="f1cd9-115">1 つ目のパラメーター triggerType には、このバックグラウンド タスクをアクティブ化するシステム イベント トリガーの種類を指定します。**</span><span class="sxs-lookup"><span data-stu-id="f1cd9-115">The first parameter, *triggerType*, specifies the type of system event trigger that will activate this background task.</span></span> <span data-ttu-id="f1cd9-116">イベントの種類の一覧については、「[**SystemTriggerType**](https://msdn.microsoft.com/library/windows/apps/br224839)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-116">For a list of event types, see [**SystemTriggerType**](https://msdn.microsoft.com/library/windows/apps/br224839).</span></span>

<span data-ttu-id="f1cd9-117">2 つ目のパラメーター *OneShot* では、次回システム イベントが発生したときに一度だけバックグラウンド タスクを実行するか、それともタスクの登録が解除されるまで、システム イベントが発生するたびにバックグラウンド タスクを実行するかを指定します。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-117">The second parameter, *OneShot*, specifies whether the background task will run only once the next time the system event occurs or every time the system event occurs until the task is unregistered.</span></span>

<span data-ttu-id="f1cd9-118">次のコードでは、インターネットが利用可能になるたびにバックグラウンド タスクを実行するように指定しています。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-118">The following code specifies that the background task runs whenever the Internet becomes available:</span></span>

```csharp
SystemTrigger internetTrigger = new SystemTrigger(SystemTriggerType.InternetAvailable, false);
```

```cppwinrt
Windows::ApplicationModel::Background::SystemTrigger internetTrigger{
    Windows::ApplicationModel::Background::SystemTriggerType::InternetAvailable, false};
```

```cpp
SystemTrigger ^ internetTrigger = ref new SystemTrigger(SystemTriggerType::InternetAvailable, false);
```

## <a name="register-the-background-task"></a><span data-ttu-id="f1cd9-119">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="f1cd9-119">Register the background task</span></span>

<span data-ttu-id="f1cd9-120">バックグラウンド タスクの登録関数を呼び出してバックグラウンド タスクを登録します。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-120">Register the background task by calling your background task registration function.</span></span> <span data-ttu-id="f1cd9-121">バックグラウンド タスクの登録について詳しくは、「[バックグラウンド タスクの登録](register-a-background-task.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-121">For more information on registering background tasks, see [Register a background task](register-a-background-task.md).</span></span>

<span data-ttu-id="f1cd9-122">次のコードは、アウトプロセスで実行されるバックグラウンド プロセスのバックグラウンド タスクを登録するものです。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-122">The following code registers the background task for a background process that runs out-of-process.</span></span> <span data-ttu-id="f1cd9-123">ホスト アプリと同じプロセスで実行されるバッグラウンド タスクを呼び出す場合は、`entrypoint` を設定しません。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-123">If you were calling a background task that runs in the same process as the host app, you would not set `entrypoint`:</span></span>

```csharp
string entryPoint = "Tasks.ExampleBackgroundTaskClass"; // Namespace name, '.', and the name of the class containing the background task
string taskName   = "Internet-based background task";

BackgroundTaskRegistration task = RegisterBackgroundTask(entryPoint, taskName, internetTrigger, exampleCondition);
```

```cppwinrt
std::wstring entryPoint{ L"Tasks.ExampleBackgroundTaskClass" }; // don't set for in-process background tasks.
std::wstring taskName{ L"Internet-based background task" };

Windows::ApplicationModel::Background::BackgroundTaskRegistration task{
    RegisterBackgroundTask(entryPoint, taskName, internetTrigger, exampleCondition) };
```

```cpp
String ^ entryPoint = "Tasks.ExampleBackgroundTaskClass"; // don't set for in-process background tasks
String ^ taskName   = "Internet-based background task";

BackgroundTaskRegistration ^ task = RegisterBackgroundTask(entryPoint, taskName, internetTrigger, exampleCondition);
```

> [!NOTE]
> <span data-ttu-id="f1cd9-124">ユニバーサル Windows プラットフォーム アプリでは、バック グラウンド トリガーの種類のいずれかを登録する前に、 [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485)を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-124">Universal Windows Platform apps must call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) before registering any of the background trigger types.</span></span>

<span data-ttu-id="f1cd9-125">更新プログラムのリリース後にユニバーサル Windows アプリが引き続き適切に実行されるようにするには、更新後にアプリが起動する際に、[**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471)、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) の順に呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-125">To ensure that your Universal Windows app continues to run properly after you release an update, you must call [**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471) and then call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) when your app launches after being updated.</span></span> <span data-ttu-id="f1cd9-126">詳しくは、「[バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-126">For more information, see [Guidelines for background tasks](guidelines-for-background-tasks.md).</span></span>

> [!NOTE]
> <span data-ttu-id="f1cd9-127">バックグラウンド タスクの登録パラメーターは登録時に検証されます。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-127">Background task registration parameters are validated at the time of registration.</span></span> <span data-ttu-id="f1cd9-128">いずれかの登録パラメーターが有効でない場合は、エラーが返されます。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-128">An error is returned if any of the registration parameters are invalid.</span></span> <span data-ttu-id="f1cd9-129">バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-129">Ensure that your app gracefully handles scenarios where background task registration fails - if instead your app depends on having a valid registration object after attempting to register a task, it may crash.</span></span>
 
## <a name="remarks"></a><span data-ttu-id="f1cd9-130">注釈</span><span class="sxs-lookup"><span data-stu-id="f1cd9-130">Remarks</span></span>

<span data-ttu-id="f1cd9-131">バックグラウンド タスクの登録動作を確認するには、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)をダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-131">To see background task registration in action, download the [background task sample](http://go.microsoft.com/fwlink/p/?LinkId=618666).</span></span>

<span data-ttu-id="f1cd9-132">バックグラウンド タスクは、[**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224838) イベントと [**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517) イベントに応答して実行できます。ただし、その場合も[アプリケーション マニフェストでバックグラウンド タスクを宣言する](declare-background-tasks-in-the-application-manifest.md)必要があります。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-132">Background tasks can run in response to [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224838) and [**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517) events, but you still need to [Declare background tasks in the application manifest](declare-background-tasks-in-the-application-manifest.md).</span></span> <span data-ttu-id="f1cd9-133">どの種類のバックグラウンド タスクを登録する場合でも、その前に [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) も呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-133">You must also call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) before registering any background task type.</span></span>

<span data-ttu-id="f1cd9-134">アプリでは、[**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843)、[**PushNotificationTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700543)、[**NetworkOperatorNotificationTrigger**](https://msdn.microsoft.com/library/windows/apps/br224831) の各イベントに応答するバックグラウンド タスクを登録することにより、アプリがフォアグラウンドにない場合でも、ユーザーとリアルタイムに通信できるようになります。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-134">Apps can register background tasks that respond to [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843), [**PushNotificationTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700543), and [**NetworkOperatorNotificationTrigger**](https://msdn.microsoft.com/library/windows/apps/br224831) events, enabling them to provide real-time communication with the user even when the app is not in the foreground.</span></span> <span data-ttu-id="f1cd9-135">詳しくは、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f1cd9-135">For more information, see [Support your app with background tasks](support-your-app-with-background-tasks.md).</span></span>

## <a name="related-topics"></a><span data-ttu-id="f1cd9-136">関連トピック</span><span class="sxs-lookup"><span data-stu-id="f1cd9-136">Related topics</span></span>

* [<span data-ttu-id="f1cd9-137">アウトプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="f1cd9-137">Create and register an out-of-process background task</span></span>](create-and-register-a-background-task.md)
* [<span data-ttu-id="f1cd9-138">インプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="f1cd9-138">Create and register an in-process background task</span></span>](create-and-register-an-inproc-background-task.md)
* [<span data-ttu-id="f1cd9-139">アプリケーション マニフェストでのバックグラウンド タスクの宣言</span><span class="sxs-lookup"><span data-stu-id="f1cd9-139">Declare background tasks in the application manifest</span></span>](declare-background-tasks-in-the-application-manifest.md)
* [<span data-ttu-id="f1cd9-140">取り消されたバックグラウンド タスクの処理</span><span class="sxs-lookup"><span data-stu-id="f1cd9-140">Handle a cancelled background task</span></span>](handle-a-cancelled-background-task.md)
* [<span data-ttu-id="f1cd9-141">バックグラウンド タスクの進捗状況と完了の監視</span><span class="sxs-lookup"><span data-stu-id="f1cd9-141">Monitor background task progress and completion</span></span>](monitor-background-task-progress-and-completion.md)
* [<span data-ttu-id="f1cd9-142">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="f1cd9-142">Register a background task</span></span>](register-a-background-task.md)
* [<span data-ttu-id="f1cd9-143">バックグラウンド タスクを実行するための条件の設定</span><span class="sxs-lookup"><span data-stu-id="f1cd9-143">Set conditions for running a background task</span></span>](set-conditions-for-running-a-background-task.md)
* [<span data-ttu-id="f1cd9-144">バックグラウンド タスクのライブ タイルの更新</span><span class="sxs-lookup"><span data-stu-id="f1cd9-144">Update a live tile from a background task</span></span>](update-a-live-tile-from-a-background-task.md)
* [<span data-ttu-id="f1cd9-145">メンテナンス トリガーの使用</span><span class="sxs-lookup"><span data-stu-id="f1cd9-145">Use a maintenance trigger</span></span>](use-a-maintenance-trigger.md)
* [<span data-ttu-id="f1cd9-146">タイマーでのバックグラウンド タスクの実行</span><span class="sxs-lookup"><span data-stu-id="f1cd9-146">Run a background task on a timer</span></span>](run-a-background-task-on-a-timer-.md)
* [<span data-ttu-id="f1cd9-147">バックグラウンド タスクのガイドライン</span><span class="sxs-lookup"><span data-stu-id="f1cd9-147">Guidelines for background tasks</span></span>](guidelines-for-background-tasks.md)
* [<span data-ttu-id="f1cd9-148">バックグラウンド タスクのデバッグ</span><span class="sxs-lookup"><span data-stu-id="f1cd9-148">Debug a background task</span></span>](debug-a-background-task.md)
* [<span data-ttu-id="f1cd9-149">UWP アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)</span><span class="sxs-lookup"><span data-stu-id="f1cd9-149">How to trigger suspend, resume, and background events in UWP apps (when debugging)</span></span>](http://go.microsoft.com/fwlink/p/?linkid=254345)
