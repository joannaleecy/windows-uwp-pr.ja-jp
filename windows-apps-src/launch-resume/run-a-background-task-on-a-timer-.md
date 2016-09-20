---
author: TylerMSFT
title: "タイマーでのバックグラウンド タスクの実行"
description: "1 回限りのバックグラウンド タスクをスケジュールする方法、または定期的なバックグラウンド タスクを実行する方法について説明します。"
ms.assetid: 0B7F0BFF-535A-471E-AC87-783C740A61E9
ms.sourcegitcommit: 39a012976ee877d8834b63def04e39d847036132
ms.openlocfilehash: 3fc1e3efa742ff8ab24f78856872fe322703f152

---

# タイマーでのバックグラウンド タスクの実行


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


**重要な API**

-   [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768)
-   [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843)
-   [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700494)

1 回限りのバックグラウンド タスクをスケジュールする方法、または定期的なバックグラウンド タスクを実行する方法について説明します。

-   この例は、アプリをサポートするために、定期的に、または特定の時刻に実行する必要があるバックグラウンド タスクがあることを前提にしています。 バックグラウンド タスクが [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843) を使って実行されるのは、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出した場合のみです。
-   このトピックでは、バックグラウンド タスクのエントリ ポイントとして使う Run メソッドも含めて、既にバックグラウンド タスク クラスが作られていることを前提とします。 バックグラウンド タスクを直ちに構築する場合は、「[バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)」をご覧ください。 条件とトリガーについて詳しくは、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。

## 時刻のトリガーを作る


-   新しい [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843) を作ります。 2 つ目のパラメーター (*OneShot*) では、バックグラウンド タスクを一度だけ実行するか、または定期的に実行を続けるかを指定します。 *OneShot* を true に設定する場合は、1 つ目のパラメーター (*FreshnessTime*) に、バックグラウンド タスクをスケジュールするまで待機する時間 (分単位) を指定します。 *OneShot* を false に設定する場合は、*FreshnessTime* に、バックグラウンド タスクを実行する間隔を指定します。

    デスクトップかモバイル デバイス ファミリを対象とするユニバーサル Windows プラットフォーム (UWP) アプリの組み込みタイマーは、15 分間隔でバックグラウンド タスクを実行します。

    -   *FreshnessTime* が 15 分に設定され、*OneShot* が true の場合、タスクは登録された時点から 0 ～ 15 分の間に一度実行されます。

    -   *FreshnessTime* が 15 分に設定され、*OneShot* が false の場合、タスクは登録された時点から 0 ～ 15 分の間に実行され、その後 15 分ごとに実行されます。

    
            **注**  *FreshnessTime* が 15 分未満に設定された場合、バックグラウンド タスクの登録が試行されたときに例外がスローされます。

     

    たとえば、次のトリガーではバックグラウンド タスクは 1 時間に 1 回実行されます。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    > TimeTrigger hourlyTrigger = new TimeTrigger(60, false);
    > ```
    > ```cpp
    > TimeTrigger ^ hourlyTrigger = ref new TimeTrigger(60, false);
    > ```

## [!div class="tabbedCodeSnippets"]


-   (省略可能) 条件の追加 いつタスクを実行するかを制御するバックグラウンド タスクの条件を必要に応じて作成します。

    条件を指定すると、条件が満たされるまではバックグラウンド タスクが実行されないようにすることができます。詳しくは「[バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)」をご覧ください。 この例では、条件が **UserPresent** に設定されているため、トリガー後、ユーザーがアクティブになった場合にタスクが 1 回だけ実行されます。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    > SystemCondition userCondition = new SystemCondition(SystemConditionType.UserPresent);
    > ```
    > ```cpp
    > SystemCondition ^ userCondition = ref new SystemCondition(SystemConditionType::UserPresent)
    > ```

##  指定できる条件の一覧については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。


-   [!div class="tabbedCodeSnippets"]

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    > BackgroundExecutionManager.RequestAccessAsync();
    > ```
    > ```cpp
    > BackgroundExecutionManager::RequestAccessAsync();
    > ```

## RequestAccessAsync() の呼び出し


-   [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843) バックグランド タスクを登録しようとする前に、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700494) を呼び出します。 [!div class="tabbedCodeSnippets"]

    バックグラウンド タスクの登録

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

    > バックグラウンド タスクの登録関数を呼び出してバックグラウンド タスクを登録します。 バックグラウンド タスクの登録について詳しくは、「[バックグラウンド タスクの登録](register-a-background-task.md)」をご覧ください。 次のコードでは、バックグラウンド タスクを登録しています。


## [!div class="tabbedCodeSnippets"]

> 
            **注**  バックグラウンド タスクの登録パラメーターは登録時に検証されます。 いずれかの登録パラメーターが有効でない場合は、エラーが返されます。

> バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。 注釈


## 
            **注**  Windows 10 以降、ユーザーはバック グラウンド タスクを利用するために、アプリをロック画面に追加する必要はなくなりました。


* [このようなバックグラウンド タスクのトリガーについては、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。](create-and-register-a-background-task.md)
* [
            **注:** この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。](declare-background-tasks-in-the-application-manifest.md)
* [Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。](handle-a-cancelled-background-task.md)
* [関連トピック](monitor-background-task-progress-and-completion.md)
* [バックグラウンド タスクの作成と登録](register-a-background-task.md)
* [アプリケーション マニフェストでのバックグラウンド タスクの宣言](respond-to-system-events-with-background-tasks.md)
* [取り消されたバックグラウンド タスクの処理](set-conditions-for-running-a-background-task.md)
* [バックグラウンド タスクの進捗状況と完了の監視](update-a-live-tile-from-a-background-task.md)
* [バックグラウンド タスクの登録](use-a-maintenance-trigger.md)
* [バックグラウンド タスクによるシステム イベントへの応答](guidelines-for-background-tasks.md)

* [バックグラウンド タスクを実行するための条件の設定](debug-a-background-task.md)
* [バックグラウンド タスクのライブ タイルの更新](http://go.microsoft.com/fwlink/p/?linkid=254345)

 

 



<!--HONumber=Jun16_HO5-->


