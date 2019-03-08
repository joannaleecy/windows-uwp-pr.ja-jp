---
title: バックグラウンド タスクの登録のグループ化
description: バックグラウンド タスクをグループの一部として登録/登録解除し、タスクの登録を分離します。
ms.date: 04/05/2017
ms.topic: article
keywords: Windows 10, バックグラウンド タスク
ms.openlocfilehash: a70c814e5e35359746076c5418d1f1d973e61773
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623857"
---
# <a name="group-background-task-registration"></a><span data-ttu-id="8efef-104">バックグラウンド タスクの登録のグループ化</span><span class="sxs-lookup"><span data-stu-id="8efef-104">Group background task registration</span></span>

<span data-ttu-id="8efef-105">**重要な API**</span><span class="sxs-lookup"><span data-stu-id="8efef-105">**Important APIs**</span></span>

[<span data-ttu-id="8efef-106">BackgroundTaskRegistrationGroup クラス</span><span class="sxs-lookup"><span data-stu-id="8efef-106">BackgroundTaskRegistrationGroup class</span></span>](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskregistrationgroup)

<span data-ttu-id="8efef-107">バックグラウンド タスクは、グループに登録できるようになりました。このグループは、論理的な名前空間と考えることができます。</span><span class="sxs-lookup"><span data-stu-id="8efef-107">Background tasks can now be registered in a group, which you can think of as a logical namespace.</span></span> <span data-ttu-id="8efef-108">このように分離することで、アプリの異なるコンポーネントや異なるライブラリが相互にバックグラウンド タスク登録に干渉しないようにできます。</span><span class="sxs-lookup"><span data-stu-id="8efef-108">This isolation helps ensure that different components of an app, or different libraries, don’t interfere with each other’s background task registration.</span></span>

<span data-ttu-id="8efef-109">アプリと、アプリで使用するフレームワーク (またはライブラリ) がバックグラウンド タスクを同じ名前で登録する場合、フレームワークのバックグラウンド タスク登録がアプリによって誤って削除される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8efef-109">When an app and the framework (or library) it uses registers a background task with the same name, the app could inadvertently remove the framework's background task registrations.</span></span> <span data-ttu-id="8efef-110">また、アプリの作成者も誤ってフレームワークとライブラリのバックグラウンド タスク登録を削除する可能性があります。アプリの作成者は、[BackgroundTaskRegistration.AllTasks](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskregistration.AllTasks) を使用して登録されているすべてのバックグラウンド タスクを解除できるからです。</span><span class="sxs-lookup"><span data-stu-id="8efef-110">App authors could also accidently remove framework and library background task registrations because they could unregister all registered background tasks by using [BackgroundTaskRegistration.AllTasks](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskregistration.AllTasks).</span></span>  <span data-ttu-id="8efef-111">グループを使用すると、バックグラウンド タスク登録を分離できるため、このようなことは発生しません。</span><span class="sxs-lookup"><span data-stu-id="8efef-111">With groups, you can isolate your background task registrations so this doesn't happen.</span></span>

## <a name="features-of-groups"></a><span data-ttu-id="8efef-112">グループの機能</span><span class="sxs-lookup"><span data-stu-id="8efef-112">Features of groups</span></span>

* <span data-ttu-id="8efef-113">グループは、GUID で一意に識別できます。</span><span class="sxs-lookup"><span data-stu-id="8efef-113">Groups can be uniquely identified by a GUID.</span></span> <span data-ttu-id="8efef-114">また、デバッグ中に読みやすい、関連するフレンドリ名文字列を設定できます。</span><span class="sxs-lookup"><span data-stu-id="8efef-114">They can also have an associated friendly name string which is easier to read while debugging.</span></span>
* <span data-ttu-id="8efef-115">複数のバックグラウンド タスクをグループに登録できます。</span><span class="sxs-lookup"><span data-stu-id="8efef-115">Multiple background tasks can be registered in a group.</span></span>
* <span data-ttu-id="8efef-116">グループに登録されているバックグラウンド タスクは、[BackgroundTaskRegistration.AllTasks](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskregistration.AllTasks) には表示されません。</span><span class="sxs-lookup"><span data-stu-id="8efef-116">Background tasks registered in a group won't appear in [BackgroundTaskRegistration.AllTasks](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskregistration.AllTasks).</span></span> <span data-ttu-id="8efef-117">そのため、現在 **BackgroundTaskRegistration.AllTasks** を使用してタスクの登録を解除しているアプリでは、グループに登録したバックグラウンド タスクを誤って登録解除することはありません。</span><span class="sxs-lookup"><span data-stu-id="8efef-117">Thus apps that currently use **BackgroundTaskRegistration.AllTasks** to unregister their tasks won't inadvertently unregister background tasks registered in a group.</span></span> <span data-ttu-id="8efef-118">参照してください[グループ内のバック グラウンド タスクの登録を解除](#unregister-background-tasks-in-a-group)をグループの一部として登録されているすべてのバック グラウンドのトリガーの登録を解除する方法を確認します。</span><span class="sxs-lookup"><span data-stu-id="8efef-118">See [Unregister background tasks in a group](#unregister-background-tasks-in-a-group) below to see how to unregister all background triggers that have been registered as part of a group.</span></span>
* <span data-ttu-id="8efef-119">各バックグラウンド タスク登録では、関連付けられているグループを判断するための Group プロパティが設定されます。</span><span class="sxs-lookup"><span data-stu-id="8efef-119">Each Background Task Registration will have a Group property to determine which group it is associated with.</span></span>
* <span data-ttu-id="8efef-120">登録のインプロセスのバック グラウンド タスク グループを経由するアクティブ化と、 [BackgroundTaskRegistrationGroup.BackgroundActivated](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskregistrationgroup.BackgroundActivated)イベントの代わりに[Application.OnBackgroundActivated](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.onbackgroundactivated#Windows_UI_Xaml_Application_OnBackgroundActivated_Windows_ApplicationModel_Activation_BackgroundActivatedEventArgs_).</span><span class="sxs-lookup"><span data-stu-id="8efef-120">Registering In-Process background tasks with a group will cause the activation to go through [BackgroundTaskRegistrationGroup.BackgroundActivated](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskregistrationgroup.BackgroundActivated) event instead of [Application.OnBackgroundActivated](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.onbackgroundactivated#Windows_UI_Xaml_Application_OnBackgroundActivated_Windows_ApplicationModel_Activation_BackgroundActivatedEventArgs_).</span></span>

## <a name="register-a-background-task-in-a-group"></a><span data-ttu-id="8efef-121">グループにバックグラウンド タスクを登録する</span><span class="sxs-lookup"><span data-stu-id="8efef-121">Register a background task in a group</span></span>

<span data-ttu-id="8efef-122">以下では、バックグラウンド タスクをグループの一部として登録する方法を示しています (この例では、タイム ゾーンの変更によってタスクがトリガーされます)。</span><span class="sxs-lookup"><span data-stu-id="8efef-122">The following shows how to register a background task (triggered by a time zone change, in this example) as part of a group.</span></span>

```csharp
private const string groupFriendlyName = "myGroup";
private const string groupId = "3F2504E0-4F89-41D3-9A0C-0305E82C3301";
private const string myTaskName = "My Background Trigger";

public static void RegisterBackgroundTaskInGroup()
{
   BackgroundTaskRegistrationGroup group = BackgroundTaskRegistration.GetTaskGroup(groupId);
   bool isTaskRegistered = false;

   // See if this task already belongs to a group
   if (group != null)
   {
       foreach (var taskKeyValue in group.AllTasks)
       {
           if (taskKeyValue.Value.Name == myTaskName)
           {
               isTaskRegistered = true;
               break;
           }
       }
   }

   // If the background task is not in a group, register it
   if (!isTaskRegistered)
   {
       if (group == null)
       {
           group = new BackgroundTaskRegistrationGroup(groupId, groupFriendlyName);
       }

       var builder = new BackgroundTaskBuilder();
       builder.Name = myTaskName;
       builder.TaskGroup = group; // we specify the group, here
       builder.SetTrigger(new SystemTrigger(SystemTriggerType.TimeZoneChange, false));

       // Because builder.TaskEntryPoint is not specified, OnBackgroundActivated() will be raised when the background task is triggered
       BackgroundTaskRegistration task = builder.Register();
   }
}
```

## <a name="unregister-background-tasks-in-a-group"></a><span data-ttu-id="8efef-123">グループのバックグラウンド タスクの登録を解除する</span><span class="sxs-lookup"><span data-stu-id="8efef-123">Unregister background tasks in a group</span></span>

<span data-ttu-id="8efef-124">以下では、グループの一部として登録されたバックグラウンド タスクの登録を解除する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="8efef-124">The following shows how to unregister background tasks that were registered as part of a group.</span></span>
<span data-ttu-id="8efef-125">グループに登録されているバックグラウンド タスクは [BackgroundTaskRegistration.AllTasks](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskregistration.AllTasks) に表示されないため、グループを反復処理して、各グループに登録されたバックグラウンド タスクを見つけ、登録を解除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8efef-125">Because background tasks registered in a group don't appear in [BackgroundTaskRegistration.AllTasks](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskregistration.AllTasks), you must iterate through the groups, find the background tasks registered to each group, and unregister them.</span></span>

```csharp
private static void UnRegisterAllTasks()
{
    // Unregister tasks that are part of a group
    foreach (var groupKeyValue in BackgroundTaskRegistration.AllTaskGroups)
    {
        foreach (var groupedTask in groupKeyValue.Value.AllTasks)
        {
            groupedTask.Value.Unregister(true); // passing true to cancel currently running instances of this background task
        }
    }

    // Unregister tasks that aren't part of a group
    foreach(var taskKeyValue in BackgroundTaskRegistration.AllTasks)
    {
        taskKeyValue.Value.Unregister(true); // passing true to cancel currently running instances of this background task
    }
}
```

## <a name="register-persistent-events"></a><span data-ttu-id="8efef-126">永続イベントを登録する</span><span class="sxs-lookup"><span data-stu-id="8efef-126">Register Persistent Events</span></span>

<span data-ttu-id="8efef-127">インプロセス バックグラウンド タスクと一緒にバックグラウンド タスク登録グループを使用している場合、バックグラウンド アクティブ化は、Application オブジェクトと CoreApplication オブジェクトのいずれでもなく、グループのイベントに伝達されます。</span><span class="sxs-lookup"><span data-stu-id="8efef-127">When using Background Task Registration Groups with in-process background tasks, the background activations are directed towards the group's event instead of the one on the Application or CoreApplication object.</span></span> <span data-ttu-id="8efef-128">これにより、Application オブジェクトにすべてのアクティブ化コード パスを配置せずに、アプリ内の複数のコンポーネントでアクティブ化を処理できるようになります。</span><span class="sxs-lookup"><span data-stu-id="8efef-128">This enables multiple components within your app to handle the activation rather than place all activation code paths in the Application object.</span></span> <span data-ttu-id="8efef-129">以下では、グループのバックグラウンド アクティブ化イベントの登録方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="8efef-129">The following shows how to register for the group's background activated event.</span></span> <span data-ttu-id="8efef-130">まず、[BackgroundTaskRegistration.GetTaskGroup](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskregistration.gettaskgroup) を確認して、グループが既に登録されているかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="8efef-130">First check [BackgroundTaskRegistration.GetTaskGroup](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskregistration.gettaskgroup) to determine if the group has already been registered.</span></span> <span data-ttu-id="8efef-131">登録されていない場合、指定の ID とフレンドリ名で新しいグループを作成します。</span><span class="sxs-lookup"><span data-stu-id="8efef-131">If not then create a new group with your id and friendly name.</span></span> <span data-ttu-id="8efef-132">その後、グループの BackgroundActivated イベントにイベント ハンドラーを登録します。</span><span class="sxs-lookup"><span data-stu-id="8efef-132">Then register an event handler to the BackgroundActivated event on the group.</span></span>

```csharp
void RegisterPersistentEvent()
{
    var group = BackgroundTaskRegistration.GetTaskGroup(groupId);
    if (group == null)
    {
        group = new BackgroundTaskRegistrationGroup(groupId, groupFriendlyName);
    }

    group.BackgroundActivated += MyEventHandler;
}
```
