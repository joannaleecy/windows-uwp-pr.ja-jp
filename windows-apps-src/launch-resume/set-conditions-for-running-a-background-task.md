---
title: バックグラウンド タスクを実行するための条件の設定
description: バックグラウンド タスクをいつ実行するかを制御する条件の設定方法について説明します。
ms.assetid: 10ABAC9F-AA8C-41AC-A29D-871CD9AD9471
ms.date: 07/06/2018
ms.topic: article
keywords: windows 10、uwp、バック グラウンド タスク
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
ms.openlocfilehash: 8740829ab95b804afba564110f38116f2c90b416
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57650937"
---
# <a name="set-conditions-for-running-a-background-task"></a>バックグラウンド タスクを実行するための条件の設定

**重要な API**

- [**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834)
- [**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)
- [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768)

バックグラウンド タスクをいつ実行するかを制御する条件の設定方法について説明します。

場合によっては、バックグラウンド タスクを正しく実行するために、特定の条件を満たす必要があります。 バックグラウンド タスクを登録するときに、[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835) で指定される条件を 1 つ以上指定することができます。 条件がチェックされるのは、トリガーが発生した後です。 バックグラウンド タスクは、キューに入れられますが、必要な条件がすべて満たされるまでは実行されません。

バックグラウンド タスクに条件を設定すると、タスクが不必要に実行されなくなるため、バッテリー残量と CPU 実行時間が節約できます。 たとえば、バックグラウンド タスクがタイマーで実行され、インターネット接続が必要な場合は、タスクを登録する前に、**InternetAvailable** 条件を [**TaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) に追加します。 これにより、タイマーの設定時間が経過し、*かつ*インターネットが利用可能な場合にのみバックグラウンド タスクが実行されるため、タスクがシステム リソースやバッテリー残量を無駄に消費することはなくなります。

同じ [**TaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) で **AddCondition** を複数回呼び出すことで、複数の条件を組み合わせることもできます。 **UserPresent** や **UserNotPresent** など競合する条件を追加しないように注意してください。

## <a name="create-a-systemcondition-object"></a>SystemCondition オブジェクトを作る

ここでは、既にバックグラウンド タスクがアプリと関連付けられており、アプリでは、**taskBuilder** という [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) オブジェクトを作るためのコードが記述済みであることを前提とします。  最初にバックグラウンド タスクを作成する必要がある場合は、「[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)」または「[アウトプロセス バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)」をご覧ください。

このトピックの内容は、アウトプロセスで実行されるバックグラウンド タスク、およびフォアグラウンド アプリと同じプロセスで実行されるバックグラウンド タスクに適用されます。

条件を追加する前に、バックグラウンド タスクを実行するために有効にする必要のある条件を表す [**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834) オブジェクトを作ります。 コンストラクターで、[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835) 列挙値を渡して、必要な条件を指定します。

次のコードでは、**InternetAvailable** 条件を指定する [**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834) オブジェクトを作成します。

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

## <a name="add-the-systemcondition-object-to-your-background-task"></a>SystemCondition オブジェクトをバックグラウンド タスクに追加する

条件を追加するには、[**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) オブジェクトで [**AddCondition**](https://msdn.microsoft.com/library/windows/apps/br224769) メソッドを呼び出して、[**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834) オブジェクトに渡します。

次のコードは、**taskBuilder** を使用して **InternetAvailable** 条件を追加します。

```csharp
taskBuilder.AddCondition(internetCondition);
```

```cppwinrt
taskBuilder.AddCondition(internetCondition);
```

```cpp
taskBuilder->AddCondition(internetCondition);
```

## <a name="register-your-background-task"></a>バックグラウンド タスクを登録する

これで、バックグラウンド タスクを [**Register**](https://msdn.microsoft.com/library/windows/apps/br224772) メソッドに登録できます。このバックグラウンド タスクは、指定した条件が満たされるまで、開始されません。

次のコードでは、タスクを登録し、生成される BackgroundTaskRegistration オブジェクトを保存します。

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
> ユニバーサル Windows アプリは、どの種類のバックグラウンド トリガーを登録する場合でも、先に [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出す必要があります。

更新プログラムのリリース後にユニバーサル Windows アプリが引き続き適切に実行されるようにするには、更新後にアプリが起動する際に、[**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471)、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) の順に呼び出す必要があります。 詳しくは、「[バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)」をご覧ください。

> [!NOTE]
> バックグラウンド タスクの登録パラメーターは登録時に検証されます。 いずれかの登録パラメーターが有効でない場合は、エラーが返されます。 バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。

## <a name="place-multiple-conditions-on-your-background-task"></a>バックグラウンド タスクに複数の条件を設定する

複数の条件を追加するには、アプリから [**で**](https://msdn.microsoft.com/library/windows/apps/br224769) メソッドを複数回呼び出します。 呼び出しは必ず、タスクの登録が有効になる前に行います。

> [!NOTE]
> バック グラウンド タスクに競合する条件を追加しないようにしてください。

次のスニペットでは、作成して、バック グラウンド タスクの登録のコンテキストで複数の条件を示します。

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

## <a name="remarks"></a>注釈

> [!NOTE]
> これが必要であり、そうでないときに実行されない場合にのみ実行されるように、バック グラウンド タスクの条件を選択します。 バックグラウンド タスクの各条件については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。

## <a name="related-topics"></a>関連トピック

* [作成して、プロセス外のバック グラウンド タスクの登録](create-and-register-a-background-task.md)
* [作成して、プロセス内のバック グラウンド タスクの登録](create-and-register-an-inproc-background-task.md)
* [アプリケーション マニフェストでバック グラウンド タスクを宣言します。](declare-background-tasks-in-the-application-manifest.md)
* [取り消されたバック グラウンド タスクを処理します。](handle-a-cancelled-background-task.md)
* [バック グラウンド タスクの進行状況と完了を監視します。](monitor-background-task-progress-and-completion.md)
* [バック グラウンド タスクを登録します。](register-a-background-task.md)
* [バック グラウンド タスクでシステム イベントに応答します。](respond-to-system-events-with-background-tasks.md)
* [バック グラウンド タスクからのライブ タイルを更新します。](update-a-live-tile-from-a-background-task.md)
* [メンテナンス トリガーを使用します。](use-a-maintenance-trigger.md)
* [タイマーでバック グラウンド タスクを実行します。](run-a-background-task-on-a-timer-.md)
* [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)
* [バック グラウンド タスクをデバッグします。](debug-a-background-task.md)
* [トリガーする方法を中断、再開、および (デバッグ) 場合は、UWP アプリでイベントをバック グラウンド](https://go.microsoft.com/fwlink/p/?linkid=254345)
