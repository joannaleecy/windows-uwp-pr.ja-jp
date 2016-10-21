---
author: TylerMSFT
title: "単一プロセス バックグラウンド タスクの作成と登録"
description: "フォアグラウンド アプリと同じプロセスで実行される単一プロセスのタスクを作成して登録します。"
translationtype: Human Translation
ms.sourcegitcommit: 9e959a8ae6bf9496b658ddfae3abccf4716957a3
ms.openlocfilehash: 5a2461d00114ba71ced7cca64c197f253f33690d

---

# 単一プロセス バックグラウンド タスクの作成と登録

**重要な API**

-   [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794)
-   [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768)
-   [**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781)

このトピックでは、アプリと同じプロセスで実行されるバックグラウンド タスクを作成して登録する方法について説明します。

単一プロセスのバックグラウンド タスクを実装するのは、別のプロセスで実行されるバックグラウンド タスクよりも簡単です。 ただし、単一プロセスのバックグラウンド タスクでは回復力が低下します。 バックグラウンドで実行中のコードがクラッシュすると、アプリがダウンします。 また、[DeviceUseTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx?f=255&MSPPError=-2147217396)、[DeviceServicingTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx)、**IoTStartupTask** は単一プロセス モデルで使用できないことに注意してください。 アプリケーション内で VoIP バックグラウンド タスクをアクティブ化することもできません。 これらのトリガーとタスクは、複数プロセスのバックグラウンド タスク モデルを使用してサポートされています。

バックグラウンド アクティビティは、実行時間制限を超えて実行された場合に、アプリのフォアグラウンド プロセス内で実行されているときでも終了できます。 特定の目的では、別のプロセスで実行するバックグラウンド タスクに作業を分離した場合の回復性が有用です。 バックグラウンドの作業をフォアグラウンド アプリケーションとは別のタスクとして保持することは、フォアグラウンド アプリケーションとの通信を必要としない作業にとって最適なオプションである可能性があります。

## 基本事項

単一プロセス モデルでは、アプリがフォアグラウンドまたはバックグラウンドで実行されるときの改善された通知によってアプリケーションのライフサイクルが強化されます。 これらの切り替え用に、Application オブジェクトから [**EnteredBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.EnteredBackground) と [**LeavingBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.LeavingBackground) という 2 つの新しいイベントを使用できます。 これらのイベントは、アプリケーションの表示状態に基づくアプリケーションのライフサイクルに適合します。これらのイベントの詳細とアプリケーションのライフサイクルに与える影響については、[アプリのライフサイクル](app-lifecycle.md)をご覧ください。

大まかに言うと、**EnteredBackground** イベントは、アプリがバックグラウンドで実行されている間に実行されるコードを実行します。また、**LeavingBackground** イベントは、アプリがフォアグラウンドに移動したことを知るために処理します。

## バックグラウンド タスク トリガーを登録する

単一プロセスのバックグラウンド アクティビティの登録は、複数プロセスのバックグラウンド アクティビティを登録する方法とほぼ同じです。 すべてのバックグラウンド トリガーは、[BackgroundTaskBuilder](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundtaskbuilder.aspx?f=255&MSPPError=-2147217396) を使用した登録から始まります。 ビルダーを使用すると、必要なすべての値を 1 か所で設定できるため、簡単にバックグラウンド タスクを登録できます。

> [!div class="tabbedCodeSnippets"]
> ```cs
> var builder = new BackgroundTaskBuilder();
> builder.Name = "My Background Trigger";
> builder.SetTrigger(new TimeTrigger(15, true));
> // Do not set builder.TaskEntryPoint for single-process background tasks
> // Here we register the task and work will start based on the time trigger.
> BackgroundTaskRegistration task = builder.Register();
> ```

> [!NOTE]
> ユニバーサル Windows アプリは、どの種類のバックグラウンド トリガーを登録する場合でも、先に [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出す必要があります。
> 更新プログラムのリリース後にユニバーサル Windows アプリが引き続き適切に実行されるようにするには、更新後にアプリが起動する際に、[**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471)、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) の順に呼び出す必要があります。 詳しくは、「[バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)」をご覧ください。

単一プロセスのバックグラウンド アクティビティの場合は `TaskEntryPoint.` を設定しません。この値を設定しないと、[OnBackgroundActivated()](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx) と呼ばれる、Application オブジェクトの新しい保護されたメソッドが既定のエントリ ポイントとして有効になります。

登録したトリガーは、[SetTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundtaskbuilder.settrigger.aspx) メソッドで設定されたトリガーの種類に基づいて発生します。 上記の例では、[TimeTrigger](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.timetrigger.aspx) が使用されています。これは、登録された時点から 15 分後に発生します。

## どのようなときにタスクを実行するかという条件を追加する (省略可能)

トリガー イベントの発生後、どのようなときにタスクを実行するかという条件を追加することもできます。 たとえば、ユーザーが存在するときにだけタスクを実行する場合、**UserPresent** という条件を使います。 指定できる条件の一覧については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。

    The following sample code assigns a condition requiring the user to be present:

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     builder.AddCondition(new SystemCondition(SystemConditionType.UserPresent));
    > ```

## バックグラウンド アクティビティのコードを OnBackgroundActivated() に配置する

バックグラウンド アクティビティのコードを [OnBackgroundActivated](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx)** に配置して、発生したバックグラウンド トリガーに応答します。**OnBackgroundActivated** は、[IBackgroundTask.Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx?f=255&MSPPError=-2147217396) と同様に処理することができます。 このメソッドには、Run メソッドで提供されるすべての情報が含まれる [BackgroundActivatedEventArgs](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.activation.backgroundactivatedeventargs.aspx) パラメーターがあります。

## バックグラウンド タスクの進捗状況と完了を処理する

タスクの進捗状況と完了は、マルチプロセスのバックグラウンド タスクの場合と同じ方法で監視できます (「[バックグラウンド タスクの進捗状況と完了の監視](monitor-background-task-progress-and-completion.md)」をご覧ください)。ただし、変数を使うと、より簡単にアプリで進捗状況または完了状態を追跡できます。 これは、アプリと同じプロセスでバックグラウンド アクティビティのコードを実行する利点の 1 つです。

## バックグラウンド タスクの取り消しを処理する

単一プロセスのバックグラウンド タスクは、マルチプロセスのバックグラウンド タスクの場合と同じ方法で取り消すことができます (「[取り消されたバックグラウンド タスクの処理](handle-a-cancelled-background-task.md)」をご覧ください)。 取り消しが発生する前に **BackgroundActivated** イベント ハンドラーを終了する必要があります。そうでないと、プロセス全体が終了します。 バックグラウンド タスクを取り消したときにフォアグラウンド アプリが予期せずに終了する場合は、取り消しが発生する前にハンドラーが終了していることを確認してください。

## マニフェスト

複数プロセスのバックグラウンド タスクとは異なり、単一プロセスのバックグラウンド タスクを実行するためにパッケージ マニフェストにバックグラウンド タスクの情報を追加する必要はありません。

## 要約と次のステップ

これで、単一プロセスのバックグラウンド タスクを作成する方法の基本を理解できました。

API リファレンス、バックグラウンド タスクの概念的ガイダンス、バックグラウンド タスクを使ったアプリの作成に関する詳しい説明については、次の関連するトピックをご覧ください。

## 関連トピック

**バックグラウンド タスクに関する手順を詳しく説明するトピック**

* [マルチプロセスのバックグラウンド タスクを単一プロセスのバックグラウンド タスクへ変換](convert-multiple-process-background-task.md)
* [別のプロセスで実行するバックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)
* [バックグラウンドでのメディアの再生](https://msdn.microsoft.com/windows/uwp/audio-video-camera/background-audio)
* [バックグラウンド タスクによるシステム イベントへの応答](respond-to-system-events-with-background-tasks.md)
* [バックグラウンド タスクの登録](register-a-background-task.md)
* [バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)
* [メンテナンス トリガーの使用](use-a-maintenance-trigger.md)
* [取り消されたバックグラウンド タスクの処理](handle-a-cancelled-background-task.md)
* [バックグラウンド タスクの進捗状況と完了の監視](monitor-background-task-progress-and-completion.md)
* [タイマーでのバックグラウンド タスクの実行](run-a-background-task-on-a-timer-.md)
* [単一プロセス バックグラウンド タスクの作成と登録](create-and-register-a-singleprocess-background-task.md)  

**バックグラウンド タスクのガイダンス**

* [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)
* [バックグラウンド タスクのデバッグ](debug-a-background-task.md)
* [Windows ストア アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)](http://go.microsoft.com/fwlink/p/?linkid=254345)

**バックグラウンド タスクの API リファレンス**

* [**Windows.ApplicationModel.Background**](https://msdn.microsoft.com/library/windows/apps/br224847)



<!--HONumber=Aug16_HO3-->


