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
keywords: バック グラウンド タスクの windows 10, uwp,
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
ms.openlocfilehash: 556a787eb1e92e4c8adb7457235afb45c02df2dc
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4613392"
---
# <a name="set-conditions-for-running-a-background-task"></a>バックグラウンド タスクを実行するための条件の設定

**重要な API**

- [**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834)
- [**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)
- [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768)

バックグラウンド タスクをいつ実行するかを制御する条件の設定方法について説明します。

場合によっては、バック グラウンド タスクでは、特定の条件を満たす、バック グラウンド タスクを完了するが必要です。 バックグラウンド タスクを登録するときに、[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835) で指定される条件を 1 つ以上指定することができます。 トリガーが起動された後、条件をオンになります。 バック グラウンド タスクはキューに入れしが必要なすべての条件が満たされるまでは実行されません。

タスクが不必要に実行されていることを防ぐことで、バッテリーの寿命と CPU を保存するバック グラウンド タスクの条件を配置します。 たとえば、バックグラウンド タスクがタイマーで実行され、インターネット接続が必要な場合は、タスクを登録する前に、**InternetAvailable** 条件を [**TaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) に追加します。 これにより、タイマーの設定時間が経過し、*かつ*インターネットが利用可能な場合にのみバックグラウンド タスクが実行されるため、タスクがシステム リソースやバッテリー残量を無駄に消費することはなくなります。

同じ[**TaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768)上**で AddCondition**が複数回呼び出すことによって、複数の条件を結合することもできます。 **UserPresent** や **UserNotPresent** など競合する条件を追加しないように注意してください。

## <a name="create-a-systemcondition-object"></a>SystemCondition オブジェクトを作る

ここでは、既にバックグラウンド タスクがアプリと関連付けられており、アプリでは、**taskBuilder** という [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) オブジェクトを作るためのコードが記述済みであることを前提とします。  最初にバックグラウンド タスクを作成する必要がある場合は、「[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)」または「[アウトプロセス バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)」をご覧ください。

このトピックの内容は、アウトプロセスで実行されるバックグラウンド タスク、およびフォアグラウンド アプリと同じプロセスで実行されるバックグラウンド タスクに適用されます。

条件を追加する前に、バック グラウンド タスクの実行を有効にする必要のある条件を表す[**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834)オブジェクトを作成します。 コンス トラクターでは、 [**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)列挙値を満たす必要のある条件を指定します。

次のコードは、 **InternetAvailable**条件を指定する[**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834)オブジェクトを作成します。

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

次のコードでは、 **InternetAvailable**条件を追加するのに**taskBuilder**を使用します。

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

[**登録**](https://msdn.microsoft.com/library/windows/apps/br224772)の方法でも、バック グラウンド タスクを登録するようになりましたと、指定した条件が満たされるまで、バック グラウンド タスクは開始されません。

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

次のスニペットでは、作成して、バック グラウンド タスクの登録のコンテキストで複数の条件を示しています。

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
> 必要な適切でないときに実行されないときにのみ実行されるように、バック グラウンド タスクの条件を選択します。 バックグラウンド タスクの各条件については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。

## <a name="related-topics"></a>関連トピック

* [アウトプロセス バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)
* [インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)
* [アプリケーション マニフェストでのバックグラウンド タスクの宣言](declare-background-tasks-in-the-application-manifest.md)
* [取り消されたバックグラウンド タスクの処理](handle-a-cancelled-background-task.md)
* [バックグラウンド タスクの進捗状況と完了の監視](monitor-background-task-progress-and-completion.md)
* [バックグラウンド タスクの登録](register-a-background-task.md)
* [バックグラウンド タスクによるシステム イベントへの応答](respond-to-system-events-with-background-tasks.md)
* [バックグラウンド タスクのライブ タイルの更新](update-a-live-tile-from-a-background-task.md)
* [メンテナンス トリガーの使用](use-a-maintenance-trigger.md)
* [タイマーでのバックグラウンド タスクの実行](run-a-background-task-on-a-timer-.md)
* [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)
* [バックグラウンド タスクのデバッグ](debug-a-background-task.md)
* [UWP アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)](http://go.microsoft.com/fwlink/p/?linkid=254345)
