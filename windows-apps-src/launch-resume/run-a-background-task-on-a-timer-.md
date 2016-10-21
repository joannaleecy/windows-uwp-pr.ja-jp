---
author: TylerMSFT
title: "タイマーでのバックグラウンド タスクの実行"
description: "1 回限りのバックグラウンド タスクをスケジュールする方法、または定期的なバックグラウンド タスクを実行する方法について説明します。"
ms.assetid: 0B7F0BFF-535A-471E-AC87-783C740A61E9
translationtype: Human Translation
ms.sourcegitcommit: 16202eeb37421acf75a9032dfc1eec397d23ce4f
ms.openlocfilehash: dd0d0fe0081eac112ce22e8a035b4bb70be3bef0

---

# タイマーでのバックグラウンド タスクの実行

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

**重要な API**

-   [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768)
-   [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843)
-   [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700494)

1 回限りのバックグラウンド タスクをスケジュールする方法、または定期的なバックグラウンド タスクを実行する方法について説明します。

-   この例は、アプリをサポートするために、定期的に、または特定の時刻に実行する必要があるバックグラウンド タスクがあることを前提にしています。 バックグラウンド タスクが [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843) を使って実行されるのは、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出した場合のみです。
-   このトピックでは、既にバックグラウンド タスク クラスが作成されていることを前提とします。 バックグラウンド タスクの作成方法の概要については、「[単一プロセス バックグラウンド タスクの作成と登録](create-and-register-a-singleprocess-background-task.md)」または「[別のプロセスで実行するバックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)」をご覧ください。 条件とトリガーについて詳しくは、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。

## 時刻のトリガーを作る

-   新しい [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843) を作ります。 2 つ目のパラメーター (*OneShot*) では、バックグラウンド タスクを一度だけ実行するか、または定期的に実行を続けるかを指定します。 *OneShot* を true に設定する場合は、1 つ目のパラメーター (*FreshnessTime*) に、バックグラウンド タスクをスケジュールするまで待機する時間 (分単位) を指定します。 *OneShot* を false に設定する場合は、*FreshnessTime* に、バックグラウンド タスクを実行する間隔を指定します。

    デスクトップかモバイル デバイス ファミリを対象とするユニバーサル Windows プラットフォーム (UWP) アプリの組み込みタイマーは、15 分間隔でバックグラウンド タスクを実行します。

    -   *FreshnessTime* が 15 分に設定され、*OneShot* が true の場合、タスクは登録された時点から 15 ～ 30 分の間に一度実行されるようにスケジュールされます。 これが 25 分に設定され、*OneShot* が true の場合、タスクは登録された時点から 25 ～ 40 分の間に一度実行されるようにスケジュールされます。

    -   *FreshnessTime* が 15 分に設定され、*OneShot* が false の場合、タスクは登録された時点から 15 ～ 15 分の間に実行され、その後 30 分ごとに実行されるようにスケジュールされます。 これが n 分に設定され、*OneShot* が false の場合、タスクは登録された時点から n ～ n + 15 分の間に実行され、その後 n 分ごとに実行されるようにスケジュールされます。

    **注**  *FreshnessTime* が 15 分未満に設定された場合、バックグラウンド タスクの登録が試行されたときに例外がスローされます。
 

    たとえば、次のトリガーではバックグラウンド タスクは 1 時間に 1 回実行されます。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    > TimeTrigger hourlyTrigger = new TimeTrigger(60, false);
    > ```
    > ```cpp
    > TimeTrigger ^ hourlyTrigger = ref new TimeTrigger(60, false);
    > ```

## (省略可能) 条件の追加

-   いつタスクを実行するかを制御するバックグラウンド タスクの条件を必要に応じて作成します。 条件を指定すると、条件が満たされるまではバックグラウンド タスクが実行されないようにすることができます。詳しくは「[バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)」をご覧ください。

    この例では、条件が **UserPresent** に設定されているため、トリガー後、ユーザーがアクティブになった場合にタスクが 1 回だけ実行されます。 指定できる条件の一覧については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    > SystemCondition userCondition = new SystemCondition(SystemConditionType.UserPresent);
    > ```
    > ```cpp
    > SystemCondition ^ userCondition = ref new SystemCondition(SystemConditionType::UserPresent)
    > ```

##  RequestAccessAsync() の呼び出し

-   [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843) バックグラウンド タスクを登録しようとする前に、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700494) を呼び出します。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    > BackgroundExecutionManager.RequestAccessAsync();
    > ```
    > ```cpp
    > BackgroundExecutionManager::RequestAccessAsync();
    > ```

## バックグラウンド タスクの登録

-   バックグラウンド タスクの登録関数を呼び出してバックグラウンド タスクを登録します。 バックグラウンド タスクの登録について詳しくは、「[バックグラウンド タスクの登録](register-a-background-task.md)」をご覧ください。

> [!Important]
> アプリと同じプロセスで実行されるバックグラウンド タスクについては、`entryPoint` を設定しません。アプリとは別のプロセスで実行されるバックグラウンド タスクについては、`entryPoint` を名前空間 '.' (およびバックグラウンド タスクの実装を含んだクラスの名前) に設定します。

    The following code registers a background task that runs in a separate process:

    > > [!div class="tabbedCodeSnippets"]
    > ```cs
    > string entryPoint = "Tasks.ExampleBackgroundTaskClass";
    > string taskName   = "Example hourly background task";
    >
    > BackgroundTaskRegistration task = RegisterBackgroundTask(entryPoint, taskName, hourlyTrigger, userCondition);
    > ```
    > ```cpp
    > String ^ entryPoint = "Tasks.ExampleBackgroundTaskClass";
    > String ^ taskName   = "Example hourly background task";
    >
    > BackgroundTaskRegistration ^ task = RegisterBackgroundTask(entryPoint, taskName, hourlyTrigger, userCondition);
    > ```

    > **Note**  Background task registration parameters are validated at the time of registration. An error is returned if any of the registration parameters are invalid. Ensure that your app gracefully handles scenarios where background task registration fails - if instead your app depends on having a valid registration object after attempting to register a task, it may crash.


## 注釈

> **注**  Windows 10 以降、ユーザーはバック グラウンド タスクを利用するために、アプリをロック画面に追加する必要はなくなりました。 このようなバックグラウンド タスクのトリガーについては、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。

> **注**  この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブ ドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。

## 関連トピック

* [単一プロセス バックグラウンド タスクの作成と登録](create-and-register-a-singleprocess-background-task.md)
* [別のプロセスで実行するバックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)
* [アプリケーション マニフェストでのバックグラウンド タスクの宣言](declare-background-tasks-in-the-application-manifest.md)
* [取り消されたバックグラウンド タスクの処理](handle-a-cancelled-background-task.md)
* [バックグラウンド タスクの進捗状況と完了の監視](monitor-background-task-progress-and-completion.md)
* [バックグラウンド タスクの登録](register-a-background-task.md)
* [バックグラウンド タスクによるシステム イベントへの応答](respond-to-system-events-with-background-tasks.md)
* [バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)
* [バックグラウンド タスクのライブ タイルの更新](update-a-live-tile-from-a-background-task.md)
* [メンテナンス トリガーの使用](use-a-maintenance-trigger.md)
* [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)
* [バックグラウンド タスクのデバッグ](debug-a-background-task.md)
* [Windows ストア アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)](http://go.microsoft.com/fwlink/p/?linkid=254345)



<!--HONumber=Sep16_HO2-->


