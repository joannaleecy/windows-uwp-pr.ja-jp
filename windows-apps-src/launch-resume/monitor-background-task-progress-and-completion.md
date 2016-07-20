---
author: TylerMSFT
title: "バックグラウンド タスクの進捗状況と完了の監視"
description: "バックグラウンド タスクから報告される進行状況と完了をアプリから認識する方法について説明します。"
ms.assetid: 17544FD7-A336-4254-97DC-2BF8994FF9B2
translationtype: Human Translation
ms.sourcegitcommit: 6e6e28bc339364e70282a9db84593188c70a59c4
ms.openlocfilehash: 153895a3ce41e5f4d22067e33cb5e874e89c6069

---

# バックグラウンド タスクの進捗状況と完了の監視


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


**重要な API**

-   [**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786)
-   [**BackgroundTaskProgressEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224785)
-   [**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781)

バックグラウンド タスクから報告される進行状況と完了をアプリから認識する方法について説明します。 バックグラウンド タスクは、アプリから切り離され、個別に実行されますが、バックグラウンド タスクの進行と完了の状況をアプリ コードによって監視することができます。 これを行うために、アプリでは、システムに登録されたバックグラウンド タスクのイベントを受信登録します。

-   このトピックでは、アプリで既にバックグラウンド タスクが登録されていることを前提とします。 バックグラウンド タスクを直ちに構築する場合は、「[バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)」をご覧ください。 条件とトリガーについて詳しくは、「[バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)」をご覧ください。

## 完了したバックグラウンド タスクを処理するイベント ハンドラーの作成

1.  完了したバックグラウンド タスクを処理するイベント ハンドラー関数を作ります。 このコードは、[**IBackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224803) オブジェクトと [**BackgroundTaskCompletedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224778) オブジェクトを受け入れる特定のフットプリントに従っている必要があります。

    OnCompleted バックグラウンド タスク イベント ハンドラー メソッドには次のフットプリントを使います。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >  private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
    >  {
    >      // TODO: Add code that deals with background task completion.
    >  }
    > ```
    > ```cpp
    >  auto completed = [this](BackgroundTaskRegistration^ task, BackgroundTaskCompletedEventArgs^ args)
    >  {
    >      // TODO: Add code that deals with background task completion.
    >  };
    > ```

2.  バックグラウンド タスクの完了を処理するイベント ハンドラーにコードを追加します。

    たとえば、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)は UI を更新します。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
    >     {
    >         UpdateUI();
    >     }
    > ```
    > ```cpp
    >     auto completed = [this](BackgroundTaskRegistration^ task, BackgroundTaskCompletedEventArgs^ args)
    >     {    
    >         UpdateUI();
    >     };
    > ```

## バックグラウンド タスクの進行状況を処理するイベント ハンドラー関数の作成

1.  完了したバックグラウンド タスクを処理するイベント ハンドラー関数を作ります。 このコードは、[**IBackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224803) オブジェクトと [**BackgroundTaskProgressEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224782) オブジェクトを受け入れる特定のフットプリントに従っている必要があります。

    OnProgress バックグラウンド タスク イベント ハンドラー メソッドには次のフットプリントを使います。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     private void OnProgress(IBackgroundTaskRegistration task, BackgroundTaskProgressEventArgs args)
    >     {
    >         // TODO: Add code that deals with background task progress.
    >     }
    > ```
    > ```cpp
    >     auto progress = [this](BackgroundTaskRegistration^ task, BackgroundTaskProgressEventArgs^ args)
    >     {
    >         // TODO: Add code that deals with background task progress.
    >     };
    > ```

2.  バックグラウンド タスクの完了を処理するイベント ハンドラーにコードを追加します。

    たとえば、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)では、*args* パラメーターで渡された進行状態により、UI が更新されます。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     private void OnProgress(IBackgroundTaskRegistration task, BackgroundTaskProgressEventArgs args)
    >     {
    >         var progress = "Progress: " + args.Progress + "%";
    >         BackgroundTaskSample.SampleBackgroundTaskProgress = progress;
    >
    >         UpdateUI();
    >     }
    > ```
    > ```cpp
    >     auto progress = [this](BackgroundTaskRegistration^ task, BackgroundTaskProgressEventArgs^ args)
    >     {
    >         auto progress = "Progress: " + args->Progress + "%";
    >         BackgroundTaskSample::SampleBackgroundTaskProgress = progress;
    >
    >         UpdateUI();
    >     };
    > ```

## 新規および既存のバックグラウンド タスクと共にイベント ハンドラー関数を登録する


1.  アプリで初めてバックグラウンド タスクを登録するときは、フォアグラウンドでまだアプリがアクティブになっていてタスクか実行されている場合に、進行状況と完了の更新を受け取ることができるように登録する必要があります。

    たとえば、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)では、登録するバックグラウンド タスクごとに次の関数を呼び出します。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     private void AttachProgressAndCompletedHandlers(IBackgroundTaskRegistration task)
    >     {
    >         task.Progress += new BackgroundTaskProgressEventHandler(OnProgress);
    >         task.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted);
    >     }
    > ```
    > ```cpp
    >     void SampleBackgroundTask::AttachProgressAndCompletedHandlers(IBackgroundTaskRegistration^ task)
    >     {
    >         auto progress = [this](BackgroundTaskRegistration^ task, BackgroundTaskProgressEventArgs^ args)
    >         {
    >             auto progress = "Progress: " + args->Progress + "%";
    >             BackgroundTaskSample::SampleBackgroundTaskProgress = progress;
    >             UpdateUI();
    >         };
    >
    >         task->Progress += ref new BackgroundTaskProgressEventHandler(progress);
    >         
    >
    >         auto completed = [this](BackgroundTaskRegistration^ task, BackgroundTaskCompletedEventArgs^ args)
    >         {
    >             UpdateUI();
    >         };
    >
    >         task->Completed += ref new BackgroundTaskCompletedEventHandler(completed);
    >     }
    > ```

2.  アプリが起動された時点、またはバックグラウンド タスクの状態が関連する新しいページに移動した時点で、現在登録されているバックグラウンド タスクの一覧を取得し、進行状況と完了に対応するイベント ハンドラー関数に関連付ける必要があります。 アプリケーションで現在登録されているバックグラウンド タスクの一覧は、[**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786).[**AllTasks**](https://msdn.microsoft.com/library/windows/apps/br224787) プロパティで保持されます。

    たとえば、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)では、次のコードを使って SampleBackgroundTask ページの移動時にイベント ハンドラーをアタッチします。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     protected override void OnNavigatedTo(NavigationEventArgs e)
    >     {
    >         foreach (var task in BackgroundTaskRegistration.AllTasks)
    >         {
    >             if (task.Value.Name == BackgroundTaskSample.SampleBackgroundTaskName)
    >             {
    >                 AttachProgressAndCompletedHandlers(task.Value);
    >                 BackgroundTaskSample.UpdateBackgroundTaskStatus(BackgroundTaskSample.SampleBackgroundTaskName, true);
    >             }
    >         }
    >
    >         UpdateUI();
    >     }
    > ```
    > ```cpp
    >     void SampleBackgroundTask::OnNavigatedTo(NavigationEventArgs^ e)
    >     {
    >         // A pointer back to the main page.  This is needed if you want to call methods in MainPage such
    >         // as NotifyUser()
    >         rootPage = MainPage::Current;
    >
    >         //
    >         // Attach progress and completed handlers to any existing tasks.
    >         //
    >         auto iter = BackgroundTaskRegistration::AllTasks->First();
    >         auto hascur = iter->HasCurrent;
    >         while (hascur)
    >         {
    >             auto cur = iter->Current->Value;
    >
    >             if (cur->Name == SampleBackgroundTaskName)
    >             {
    >                 AttachProgressAndCompletedHandlers(cur);
    >                 break;
    >             }
    >
    >             hascur = iter->MoveNext();
    >         }
    >
    >         UpdateUI();
    >     }
    > ```

## 関連トピック

* [バックグラウンド タスクの作成と登録](create-and-register-a-background-task.md)
* [アプリケーション マニフェストでのバックグラウンド タスクの宣言](declare-background-tasks-in-the-application-manifest.md)
* [取り消されたバックグラウンド タスクの処理](handle-a-cancelled-background-task.md)
* [バックグラウンド タスクの登録](register-a-background-task.md)
* [バックグラウンド タスクによるシステム イベントへの応答](respond-to-system-events-with-background-tasks.md)
* [バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)
* [バックグラウンド タスクのライブ タイルの更新](update-a-live-tile-from-a-background-task.md)
* [メンテナンス トリガーの使用](use-a-maintenance-trigger.md)
* [タイマーでのバックグラウンド タスクの実行](run-a-background-task-on-a-timer-.md)
* [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)
* [バックグラウンド タスクのデバッグ](debug-a-background-task.md)
* [Windows ストア アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)](http://go.microsoft.com/fwlink/p/?linkid=254345)




<!--HONumber=Jul16_HO1-->


