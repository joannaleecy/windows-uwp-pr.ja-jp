---
title: バックグラウンド タスクを実行するための条件の設定
description: バックグラウンド タスクをいつ実行するかを制御する条件の設定方法について説明します。
ms.assetid: 10ABAC9F-AA8C-41AC-A29D-871CD9AD9471
---

# バックグラウンド タスクを実行するための条件の設定


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


**重要な API**

-   [**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834)
-   [**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)
-   [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768)

バックグラウンド タスクをいつ実行するかを制御する条件の設定方法について説明します。

場合によっては、バックグラウンド タスクを正しく実行するために、タスクをトリガーするイベント以外に特定の条件を満たす必要があります。 バックグラウンド タスクを登録するときに、[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835) で指定される条件を 1 つ以上指定することができます。 条件がチェックされるのは、トリガーが発生した後です。バックグラウンド タスクは、キューに入れられますが、必要な条件がすべて満たされるまでは実行されません。

バックグラウンド タスクに条件を設定すると、タスクが不必要に実行されなくなるため、バッテリ寿命と CPU 実行時間が節約できます。 たとえば、バックグラウンド タスクがタイマーで実行され、インターネット接続が必要な場合は、タスクを登録する前に、**InternetAvailable** 条件を [**TaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) に追加します。 これにより、タイマーの設定時間が経過した後、インターネットが利用可能であれば実行が許可されるため、タスクがシステム リソースやバッテリ寿命を無駄にすることはなくなります。

**注**  同じ [**TaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) で AddCondition を複数回呼び出すことで、複数の条件を組み合わせることができます。 **UserPresent** や **UserNotPresent** など競合する条件を追加しないように注意してください。

 

## SystemCondition オブジェクトを作る


ここでは、既にバックグラウンド タスクがアプリと関連付けられており、アプリでは、**taskBuilder** という [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) オブジェクトを作るためのコードが記述済みであることを前提とします。

条件を追加する前に、バックグラウンド タスクを実行するために有効にする必要のある条件を表す [**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834) オブジェクトを作ります。 コンストラクターで、[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835) 列挙値を渡して、必要な条件を指定します。

次のコードでは、満たす必要のある要件としてインターネットの可用性を条件付ける [**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834) オブジェクトを作ります。

> [!div class="tabbedCodeSnippets"]
> ```cs
> SystemCondition internetCondition = new SystemCondition(SystemConditionType.InternetAvailable);
> ```
> ```cpp
> SystemCondition ^ internetCondition = ref new SystemCondition(SystemConditionType::InternetAvailable);
> ```

## SystemCondition オブジェクトをバックグラウンド タスクに追加する


条件を追加するには、[**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) オブジェクトで [**AddCondition**](https://msdn.microsoft.com/library/windows/apps/br224769) メソッドを呼び出して、[**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834) オブジェクトに渡します。

次のコードでは、InternetAvailable バックグラウンド タスク条件を TaskBuilder に登録します。

> [!div class="tabbedCodeSnippets"]
> ```cs
> taskBuilder.AddCondition(internetCondition);
> ```
> ```cpp
> taskBuilder->AddCondition(internetCondition);
> ```

## バックグラウンド タスクを登録する


これで、バックグラウンド タスクを [**Register**](https://msdn.microsoft.com/library/windows/apps/br224772) メソッドに登録できます。このタスクは、指定した条件が満たされるまで、開始されません。

次のコードでは、タスクを登録し、生成される BackgroundTaskRegistration オブジェクトを保存します。

> [!div class="tabbedCodeSnippets"]
> ```cs
> BackgroundTaskRegistration task = taskBuilder.Register();
> ```
> ```cpp
> BackgroundTaskRegistration ^ task = taskBuilder->Register();
> ```

> **注**  ユニバーサル Windows アプリは、どの種類のバックグラウンド トリガーを登録する場合でも、先に [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出す必要があります。

更新プログラムのリリース後にユニバーサル Windows アプリが引き続き適切に実行されるようにするには、更新後にアプリが起動する際に、[**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471)、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) の順に呼び出す必要があります。 詳しくは、「[バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)」をご覧ください。

> **注**  バックグラウンド タスクの登録パラメーターは登録時に検証されます。 いずれかの登録パラメーターが有効でない場合は、エラーが返されます。 バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。

## バックグラウンド タスクに複数の条件を設定する

複数の条件を追加するには、アプリから [**で**](https://msdn.microsoft.com/library/windows/apps/br224769) メソッドを複数回呼び出します。 呼び出しは必ず、タスクの登録が有効になる前に行います。

> **注**  1 つのバックグラウンド タスクに競合する条件を追加しないように注意してください。
 

次のスニペットでは、バックグラウンド タスクを作り、登録するコンテキストでの複数の条件を示したものです。

> [!div class="tabbedCodeSnippets"]
```cs
> // 
> // Set up the background task.
> // 
> 
> TimeTrigger hourlyTrigger = new TimeTrigger(60, false);
> 
> var recurringTaskBuilder = new BackgroundTaskBuilder();
> 
> recurringTaskBuilder.Name           = "Hourly background task";
> recurringTaskBuilder.TaskEntryPoint = "Tasks.ExampleBackgroundTaskClass";
> recurringTaskBuilder.SetTrigger(hourlyTrigger);
> 
> // 
> // Begin adding conditions.
> // 
> 
> SystemCondition userCondition     = new SystemCondition(SystemConditionType.UserPresent);
> SystemCondition internetCondition = new SystemCondition(SystemConditionType.InternetAvailable);
> 
> recurringTaskBuilder.AddCondition(userCondition);
> recurringTaskBuilder.AddCondition(internetCondition);
> 
> // 
> // Done adding conditions, now register the background task.
> // 
> 
> BackgroundTaskRegistration task = recurringTaskBuilder.Register();
> ```
> ```cpp
> // 
> // Set up the background task.
> // 
> 
> TimeTrigger ^ hourlyTrigger = ref new TimeTrigger(60, false);
> 
> auto recurringTaskBuilder = ref new BackgroundTaskBuilder();
> 
> recurringTaskBuilder->Name           = "Hourly background task";
> recurringTaskBuilder->TaskEntryPoint = "Tasks.ExampleBackgroundTaskClass";
> recurringTaskBuilder->SetTrigger(hourlyTrigger);
> 
> // 
> // Begin adding conditions.
> // 
> 
> SystemCondition ^ userCondition     = ref new SystemCondition(SystemConditionType::UserPresent);
> SystemCondition ^ internetCondition = ref new SystemCondition(SystemConditionType::InternetAvailable);
> 
> recurringTaskBuilder->AddCondition(userCondition);
> recurringTaskBuilder->AddCondition(internetCondition);
> 
> // 
> // Done adding conditions, now register the background task.
> // 
> 
> BackgroundTaskRegistration ^ task = recurringTaskBuilder->Register();
> ```

## Remarks


> **Note**  Chose the right conditions for your background task so that it only runs when it's needed, and doesn't run when it won't work. See [**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835) for descriptions of the different background task conditions.

> **Note**  This article is for Windows 10 developers writing Universal Windows Platform (UWP) apps. If you’re developing for Windows 8.x or Windows Phone 8.x, see the [archived documentation](http://go.microsoft.com/fwlink/p/?linkid=619132).

 

## Related topics


****

* [Create and register a background task](create-and-register-a-background-task.md)
* [Declare background tasks in the application manifest](declare-background-tasks-in-the-application-manifest.md)
* [Handle a cancelled background task](handle-a-cancelled-background-task.md)
* [Monitor background task progress and completion](monitor-background-task-progress-and-completion.md)
* [Register a background task](register-a-background-task.md)
* [Respond to system events with background tasks](respond-to-system-events-with-background-tasks.md)
* [Update a live tile from a background task](update-a-live-tile-from-a-background-task.md)
* [Use a maintenance trigger](use-a-maintenance-trigger.md)
* [Run a background task on a timer](run-a-background-task-on-a-timer-.md)
* [Guidelines for background tasks](guidelines-for-background-tasks.md)

****

* [Debug a background task](debug-a-background-task.md)
* [How to trigger suspend, resume, and background events in Windows Store apps (when debugging)](http://go.microsoft.com/fwlink/p/?linkid=254345)

 

 





<!--HONumber=Mar16_HO1-->


