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
# <a name="use-a-maintenance-trigger"></a>メンテナンス トリガーの使用

**重要な API**

- [**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517)
- [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768)
- [**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834)

デバイスが接続されているときに、[**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517) クラスを使って軽量のコードをバックグラウンドで実行する方法について説明します。

## <a name="create-a-maintenance-trigger-object"></a>メンテナンス トリガー オブジェクトを作る

この例は、デバイスが接続されているときにアプリを拡張するためにバックグラウンドで実行できる軽量のコードがあることを前提にしています。 ここでは主に、[**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839) に似た [**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517) について扱います。

バックグラウンド タスク クラスの作成について詳しくは、「[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)」または「[アウトプロセス バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)」をご覧ください。

新しい [**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517) オブジェクトを作成します。 2 つ目のパラメーター (*OneShot*) では、メンテナンス タスクを一度だけ実行するか、定期的に実行を続けるかを指定します。 *OneShot* を true に設定する場合は、1 つ目のパラメーター (*FreshnessTime*) に、バックグラウンド タスクをスケジュールするまで待機する時間 (分単位) を指定します。 *OneShot* を false に設定する場合は、*FreshnessTime* でバックグラウンド タスクを実行する間隔を指定します。

> [!NOTE]
> 場合*FreshnessTime*がバック グラウンド タスクの登録を試みているときに例外がスローに未満、15 分に設定します。

このコード例では、1 時間に 1 回実行するトリガーを作成します。

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

## <a name="optional-add-a-condition"></a>(省略可能) 条件の追加

- いつタスクを実行するかを制御するバックグラウンド タスクの条件を必要に応じて作成します。 条件を指定すると、条件が満たされるまではバックグラウンド タスクが実行されないようにすることができます。詳しくは「[バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)」をご覧ください。

次の例では、インターネットが利用できる場合 (またはインターネットが利用できるようになった場合) にメンテナンスが実行されるように、条件を **InternetAvailable** に設定します。 指定できるバックグラウンド タスク条件の一覧については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。

次のコードでは、メンテナンス タスク ビルダーに条件を追加します。

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

## <a name="register-the-background-task"></a>バックグラウンド タスクの登録

- バックグラウンド タスクの登録関数を呼び出してバックグラウンド タスクを登録します。 バックグラウンド タスクの登録について詳しくは、「[バックグラウンド タスクの登録](register-a-background-task.md)」をご覧ください。

次のコードでは、メンテナンス タスクを登録します。 `entryPoint` と指定しているので、バックグラウンド タスクとアプリを異なるプロセスで実行するように想定されていることに注意してください。 バックグラウンド タスクとアプリを同じプロセスで実行する場合は、`entryPoint` を指定しません。

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
> デスクトップ以外のすべてのデバイス ファミリでは、デバイスのメモリが少なくなった場合、バックグラウンド タスクが終了することがあります。 メモリ不足の例外が検出されないか、検出されてもアプリによって処理されない場合、バックグラウンド タスクは、警告や OnCanceled イベントの発生なしに終了します。 こうすることで、フォアグラウンドのアプリのユーザー エクスペリエンスが保証されます。 バックグラウンド タスクは、このシナリオを処理できるように設計する必要があります。

> [!NOTE]
> ユニバーサル Windows プラットフォーム アプリを呼び出す必要があります[ **RequestAccessAsync** ](https://msdn.microsoft.com/library/windows/apps/hh700485)バック グラウンドのトリガーの種類のいずれかを登録する前にします。

アプリに対する更新プログラムのリリース後にユニバーサル Windows アプリが引き続き適切に実行されるようにするには、更新後にアプリが起動する際に、[**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471)、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) の順に呼び出す必要があります。 詳しくは、「[バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)」をご覧ください。

> [!NOTE]
> バックグラウンド タスクの登録パラメーターは登録時に検証されます。 いずれかの登録パラメーターが有効でない場合は、エラーが返されます。 バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。

## <a name="related-topics"></a>関連トピック

* [インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)
* [作成して、プロセス外のバック グラウンド タスクの登録](create-and-register-a-background-task.md)
* [アプリケーション マニフェストでバック グラウンド タスクを宣言します。](declare-background-tasks-in-the-application-manifest.md)
* [取り消されたバック グラウンド タスクを処理します。](handle-a-cancelled-background-task.md)
* [バック グラウンド タスクの進行状況と完了を監視します。](monitor-background-task-progress-and-completion.md)
* [バック グラウンド タスクを登録します。](register-a-background-task.md)
* [バック グラウンド タスクでシステム イベントに応答します。](respond-to-system-events-with-background-tasks.md)
* [バック グラウンド タスクを実行するための条件を設定します。](set-conditions-for-running-a-background-task.md)
* [バック グラウンド タスクからのライブ タイルを更新します。](update-a-live-tile-from-a-background-task.md)
* [タイマーでバック グラウンド タスクを実行します。](run-a-background-task-on-a-timer-.md)
* [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)
* [バック グラウンド タスクをデバッグします。](debug-a-background-task.md)
* [トリガーする方法を中断、再開、および (デバッグ) 場合は、UWP アプリでイベントをバック グラウンド](https://go.microsoft.com/fwlink/p/?linkid=254345)
