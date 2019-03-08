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
# <a name="group-background-task-registration"></a>バックグラウンド タスクの登録のグループ化

**重要な API**

[BackgroundTaskRegistrationGroup クラス](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskregistrationgroup)

バックグラウンド タスクは、グループに登録できるようになりました。このグループは、論理的な名前空間と考えることができます。 このように分離することで、アプリの異なるコンポーネントや異なるライブラリが相互にバックグラウンド タスク登録に干渉しないようにできます。

アプリと、アプリで使用するフレームワーク (またはライブラリ) がバックグラウンド タスクを同じ名前で登録する場合、フレームワークのバックグラウンド タスク登録がアプリによって誤って削除される可能性があります。 また、アプリの作成者も誤ってフレームワークとライブラリのバックグラウンド タスク登録を削除する可能性があります。アプリの作成者は、[BackgroundTaskRegistration.AllTasks](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskregistration.AllTasks) を使用して登録されているすべてのバックグラウンド タスクを解除できるからです。  グループを使用すると、バックグラウンド タスク登録を分離できるため、このようなことは発生しません。

## <a name="features-of-groups"></a>グループの機能

* グループは、GUID で一意に識別できます。 また、デバッグ中に読みやすい、関連するフレンドリ名文字列を設定できます。
* 複数のバックグラウンド タスクをグループに登録できます。
* グループに登録されているバックグラウンド タスクは、[BackgroundTaskRegistration.AllTasks](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskregistration.AllTasks) には表示されません。 そのため、現在 **BackgroundTaskRegistration.AllTasks** を使用してタスクの登録を解除しているアプリでは、グループに登録したバックグラウンド タスクを誤って登録解除することはありません。 参照してください[グループ内のバック グラウンド タスクの登録を解除](#unregister-background-tasks-in-a-group)をグループの一部として登録されているすべてのバック グラウンドのトリガーの登録を解除する方法を確認します。
* 各バックグラウンド タスク登録では、関連付けられているグループを判断するための Group プロパティが設定されます。
* 登録のインプロセスのバック グラウンド タスク グループを経由するアクティブ化と、 [BackgroundTaskRegistrationGroup.BackgroundActivated](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskregistrationgroup.BackgroundActivated)イベントの代わりに[Application.OnBackgroundActivated](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.onbackgroundactivated#Windows_UI_Xaml_Application_OnBackgroundActivated_Windows_ApplicationModel_Activation_BackgroundActivatedEventArgs_).

## <a name="register-a-background-task-in-a-group"></a>グループにバックグラウンド タスクを登録する

以下では、バックグラウンド タスクをグループの一部として登録する方法を示しています (この例では、タイム ゾーンの変更によってタスクがトリガーされます)。

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

## <a name="unregister-background-tasks-in-a-group"></a>グループのバックグラウンド タスクの登録を解除する

以下では、グループの一部として登録されたバックグラウンド タスクの登録を解除する方法を示しています。
グループに登録されているバックグラウンド タスクは [BackgroundTaskRegistration.AllTasks](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskregistration.AllTasks) に表示されないため、グループを反復処理して、各グループに登録されたバックグラウンド タスクを見つけ、登録を解除する必要があります。

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

## <a name="register-persistent-events"></a>永続イベントを登録する

インプロセス バックグラウンド タスクと一緒にバックグラウンド タスク登録グループを使用している場合、バックグラウンド アクティブ化は、Application オブジェクトと CoreApplication オブジェクトのいずれでもなく、グループのイベントに伝達されます。 これにより、Application オブジェクトにすべてのアクティブ化コード パスを配置せずに、アプリ内の複数のコンポーネントでアクティブ化を処理できるようになります。 以下では、グループのバックグラウンド アクティブ化イベントの登録方法を示しています。 まず、[BackgroundTaskRegistration.GetTaskGroup](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskregistration.gettaskgroup) を確認して、グループが既に登録されているかどうかを判断します。 登録されていない場合、指定の ID とフレンドリ名で新しいグループを作成します。 その後、グループの BackgroundActivated イベントにイベント ハンドラーを登録します。

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
