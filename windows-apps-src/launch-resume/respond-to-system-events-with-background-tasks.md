---
author: TylerMSFT
title: "バックグラウンド タスクによるシステム イベントへの応答"
description: "SystemTrigger イベントに応答するバックグラウンド タスクを作成する方法について説明します。"
ms.assetid: 43C21FEA-28B9-401D-80BE-A61B71F01A89
ms.sourcegitcommit: 39a012976ee877d8834b63def04e39d847036132
ms.openlocfilehash: f6845dce428f5e22ec68744293b1668da52002bf

---

# バックグラウンド タスクによるシステム イベントへの応答


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


**重要な API**

-   [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794)
-   [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768)
-   [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224838)

[
            **SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839) イベントに応答するバックグラウンド タスクを作成する方法について説明します。

このトピックは、既にアプリにバックグラウンド タスク クラスが作られており、システムがトリガーするイベント (インターネットが利用できるようになる、ユーザーがログインするなど) に応じてこのタスクを実行する必要があることを前提としています。 ここでは、主に [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839) クラスについて扱います。 バックグラウンド タスク クラスの作成について詳しくは、「[バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)」をご覧ください。

## SystemTrigger オブジェクトを作る


-   アプリ コードで新規の [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224838) オブジェクトを作ります。 1 つ目のパラメーター triggerType には、このバックグラウンド タスクをアクティブ化するシステム イベント トリガーの種類を指定します。** イベントの種類の一覧については、「[**SystemTriggerType**](https://msdn.microsoft.com/library/windows/apps/br224839)」をご覧ください。

    2 つ目のパラメーター OneShot では、次回システム イベントが発生してバックグラウンド タスクをトリガーしたときに一度だけバックグラウンド タスクを実行するか、それともタスクの登録が解除されるまで、システム イベントが発生するたびにバックグラウンド タスクを実行するかを指定します。**

    次のコードでは、インターネットが利用可能になるたびにバックグラウンド タスクを実行するように指定しています。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    > SystemTrigger internetTrigger = new SystemTrigger(SystemTriggerType.InternetAvailable, false);
    > ```
    > ```cpp
    > SystemTrigger ^ internetTrigger = ref new SystemTrigger(SystemTriggerType::InternetAvailable, false);
    > ```

## バックグラウンド タスクの登録


-   バックグラウンド タスクの登録関数を呼び出してバックグラウンド タスクを登録します。 バックグラウンド タスクの登録について詳しくは、「[バックグラウンド タスクの登録](register-a-background-task.md)」をご覧ください。

    次のコードでは、バックグラウンド タスクを登録しています。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    > string entryPoint = "Tasks.ExampleBackgroundTaskClass";
    > string taskName   = "Internet-based background task";
    >
    > BackgroundTaskRegistration task = RegisterBackgroundTask(entryPoint, taskName, internetTrigger, exampleCondition);
    > ```
    > ```cpp
    > String ^ entryPoint = "Tasks.ExampleBackgroundTaskClass";
    > String ^ taskName   = "Internet-based background task";
    >
    > BackgroundTaskRegistration ^ task = RegisterBackgroundTask(entryPoint, taskName, internetTrigger, exampleCondition);
    > ```

    > **注**  ユニバーサル Windows アプリは、どの種類のバックグラウンド トリガーを登録する場合でも、先に [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出す必要があります。

    更新プログラムのリリース後にユニバーサル Windows アプリが引き続き適切に実行されるようにするには、更新後にアプリが起動する際に、[**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471)、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) の順に呼び出す必要があります。 詳しくは、「[バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)」をご覧ください。

    > **注**  バックグラウンド タスクの登録パラメーターは登録時に検証されます。 いずれかの登録パラメーターが有効でない場合は、エラーが返されます。 バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。

     

## 注釈


バックグラウンド タスクの登録動作を確認するには、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)をダウンロードしてください。

バックグラウンド タスクは、[**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224838) イベントと [**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517) イベントに応答して実行できます。ただし、その場合も[アプリケーション マニフェストでバックグラウンド タスクを宣言する](declare-background-tasks-in-the-application-manifest.md)必要があります。 どの種類のバックグラウンド タスクを登録する場合でも、その前に [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) も呼び出す必要があります。

アプリでは、[**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843)、[**PushNotificationTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700543)、[**NetworkOperatorNotificationTrigger**](https://msdn.microsoft.com/library/windows/apps/br224831) の各イベントに応答するバックグラウンド タスクを登録することにより、アプリがフォアグラウンドにない場合でも、ユーザーとリアルタイムに通信できるようになります。 詳しくは、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。

> **注:** この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。

 
## 関連トピック


****

* [バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)
* [アプリケーション マニフェストでのバックグラウンド タスクの宣言](declare-background-tasks-in-the-application-manifest.md)
* [取り消されたバックグラウンド タスクの処理](handle-a-cancelled-background-task.md)
* [バックグラウンド タスクの進捗状況と完了の監視](monitor-background-task-progress-and-completion.md)
* [バックグラウンド タスクの登録](register-a-background-task.md)
* [バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)
* [バックグラウンド タスクのライブ タイルの更新](update-a-live-tile-from-a-background-task.md)
* [メンテナンス トリガーの使用](use-a-maintenance-trigger.md)
* [タイマーでのバックグラウンド タスクの実行](run-a-background-task-on-a-timer-.md)
* [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)

****

* [バックグラウンド タスクのデバッグ](debug-a-background-task.md)
* [Windows ストア アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)](http://go.microsoft.com/fwlink/p/?linkid=254345)

 

 



<!--HONumber=Jun16_HO4-->


