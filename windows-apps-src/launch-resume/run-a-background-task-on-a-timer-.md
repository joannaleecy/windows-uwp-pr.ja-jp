---
author: TylerMSFT
title: "タイマーでのバックグラウンド タスクの実行"
description: "1 回限りのバックグラウンド タスクをスケジュールする方法、または定期的なバックグラウンド タスクを実行する方法について説明します。"
ms.assetid: 0B7F0BFF-535A-471E-AC87-783C740A61E9
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 6f834c91cd0c71f6d7687d9f69224ed747e45a6d
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="run-a-background-task-on-a-timer"></a>タイマーでのバックグラウンド タスクの実行

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

**重要な API**

-   [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768)
-   [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843)
-   [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700494)

1 回限りのバックグラウンド タスクをスケジュールする方法、または定期的なバックグラウンド タスクを実行する方法について説明します。

-   この例は、アプリをサポートするために、定期的に、または特定の時刻に実行する必要があるバックグラウンド タスクがあることを前提にしています。 バックグラウンド タスクが [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843) を使って実行されるのは、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出した場合のみです。
-   このトピックでは、既にバックグラウンド タスク クラスが作成されていることを前提とします。 バックグラウンド タスクの作成方法の概要については、「[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)」または「[アウト プロセス バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)」をご覧ください。 条件とトリガーについて詳しくは、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。

## <a name="create-a-time-trigger"></a>時刻のトリガーを作る

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

## <a name="optional-add-a-condition"></a>(省略可能) 条件の追加

-   いつタスクを実行するかを制御するバックグラウンド タスクの条件を必要に応じて作成します。 条件を指定すると、条件が満たされるまではバックグラウンド タスクが実行されないようにすることができます。詳しくは「[バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)」をご覧ください。

    この例では、条件が **UserPresent** に設定されているため、トリガー後、ユーザーがアクティブになった場合にタスクが 1 回だけ実行されます。 指定できる条件の一覧については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。

> [!div class="tabbedCodeSnippets"]
> ```cs
> SystemCondition userCondition = new SystemCondition(SystemConditionType.UserPresent);
> ```
> ```cpp
> SystemCondition ^ userCondition = ref new SystemCondition(SystemConditionType::UserPresent)
> ```

##  <a name="call-requestaccessasync"></a>RequestAccessAsync() の呼び出し

-   [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843) バックグラウンド タスクを登録しようとする前に、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700494) を呼び出します。

> [!div class="tabbedCodeSnippets"]
> ```cs
> BackgroundExecutionManager.RequestAccessAsync();
> ```
> ```cpp
> BackgroundExecutionManager::RequestAccessAsync();
> ```

## <a name="register-the-background-task"></a>バックグラウンド タスクの登録

-   バックグラウンド タスクの登録関数を呼び出してバックグラウンド タスクを登録します。 バックグラウンド タスクの登録について詳しくは、「[バックグラウンド タスクの登録](register-a-background-task.md)」をご覧ください。

> [!Important]
> アプリと同じプロセスで実行されるバックグラウンド タスクについては、`entryPoint` を設定しません。アプリとは別のプロセスで実行されるバックグラウンド タスクについては、`entryPoint` を、"名前空間 + '.' + バックグラウンド タスクの実装を含んだクラス名" の形式で設定します。

    The following code registers a background task that runs out-of-process:

> [!div class="tabbedCodeSnippets"]
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

> **注**  バックグラウンド タスクの登録パラメーターは登録時に検証されます。 いずれかの登録パラメーターが有効でない場合は、エラーが返されます。 バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。


## <a name="remarks"></a>注釈

> **注**  Windows 10 以降、ユーザーはバック グラウンド タスクを利用するために、アプリをロック画面に追加する必要はなくなりました。 このようなバックグラウンド タスクのトリガーについては、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。

> **注**  この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。

## <a name="related-topics"></a>関連トピック

* [インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)
* [アウトプロセス バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)
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
