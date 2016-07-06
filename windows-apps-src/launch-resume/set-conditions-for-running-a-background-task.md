---
author: TylerMSFT
title: "バックグラウンド タスクを実行するための条件の設定"
description: "バックグラウンド タスクをいつ実行するかを制御する条件の設定方法について説明します。"
ms.assetid: 10ABAC9F-AA8C-41AC-A29D-871CD9AD9471
ms.sourcegitcommit: 39a012976ee877d8834b63def04e39d847036132
ms.openlocfilehash: 0f95bdcb197f472b743f81c0d941196d5e53f60a

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

## [!div class="tabbedCodeSnippets"]


SystemCondition オブジェクトをバックグラウンド タスクに追加する

条件を追加するには、[**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) オブジェクトで [**AddCondition**](https://msdn.microsoft.com/library/windows/apps/br224769) メソッドを呼び出して、[**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834) オブジェクトに渡します。

> [!div class="tabbedCodeSnippets"]
> ```cs
> taskBuilder.AddCondition(internetCondition);
> ```
> ```cpp
> taskBuilder->AddCondition(internetCondition);
> ```

## 次のコードでは、InternetAvailable バックグラウンド タスク条件を TaskBuilder に登録します。


[!div class="tabbedCodeSnippets"]

バックグラウンド タスクを登録する

> [!div class="tabbedCodeSnippets"]
> ```cs
> BackgroundTaskRegistration task = taskBuilder.Register();
> ```
> ```cpp
> BackgroundTaskRegistration ^ task = taskBuilder->Register();
> ```

> これで、バックグラウンド タスクを [**Register**](https://msdn.microsoft.com/library/windows/apps/br224772) メソッドに登録できます。このタスクは、指定した条件が満たされるまで、開始されません。

次のコードでは、タスクを登録し、生成される BackgroundTaskRegistration オブジェクトを保存します。 [!div class="tabbedCodeSnippets"]

> **注**  ユニバーサル Windows アプリは、どの種類のバックグラウンド トリガーを登録する場合でも、先に [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出す必要があります。 更新プログラムのリリース後にユニバーサル Windows アプリが引き続き適切に実行されるようにするには、更新後にアプリが起動する際に、[**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471)、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) の順に呼び出す必要があります。 詳しくは、「[バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)」をご覧ください。

## **注**  バックグラウンド タスクの登録パラメーターは登録時に検証されます。

いずれかの登録パラメーターが有効でない場合は、エラーが返されます。 バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。

> バックグラウンド タスクに複数の条件を設定する
 

複数の条件を追加するには、アプリから [**で**](https://msdn.microsoft.com/library/windows/apps/br224769) メソッドを複数回呼び出します。

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
```
```cpp
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
```

## 呼び出しは必ず、タスクの登録が有効になる前に行います。


> **注**  1 つのバックグラウンド タスクに競合する条件を追加しないように注意してください。 次のスニペットでは、バックグラウンド タスクを作り、登録するコンテキストでの複数の条件を示したものです。

> [!div class="tabbedCodeSnippets"] 注釈

 

## **注**  バックグラウンド タスクが必要なときに実行され、機能しない場合には実行されないようにするために、バックグラウンド タスクには正しい条件を選んでください。


****

* [バックグラウンド タスクの各条件については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。](create-and-register-a-background-task.md)
* [**注**  この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。](declare-background-tasks-in-the-application-manifest.md)
* [Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。](handle-a-cancelled-background-task.md)
* [関連トピック](monitor-background-task-progress-and-completion.md)
* [バックグラウンド タスクの作成と登録](register-a-background-task.md)
* [アプリケーション マニフェストでのバックグラウンド タスクの宣言](respond-to-system-events-with-background-tasks.md)
* [取り消されたバックグラウンド タスクの処理](update-a-live-tile-from-a-background-task.md)
* [バックグラウンド タスクの進捗状況と完了の監視](use-a-maintenance-trigger.md)
* [バックグラウンド タスクの登録](run-a-background-task-on-a-timer-.md)
* [バックグラウンド タスクによるシステム イベントへの応答](guidelines-for-background-tasks.md)

****

* [バックグラウンド タスクのライブ タイルの更新](debug-a-background-task.md)
* [メンテナンス トリガーの使用](http://go.microsoft.com/fwlink/p/?linkid=254345)

 

 



<!--HONumber=Jun16_HO5-->


