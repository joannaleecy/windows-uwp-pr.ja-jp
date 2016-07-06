---
author: TylerMSFT
title: "バックグラウンド タスクの進捗状況と完了の監視"
description: "バックグラウンド タスクから報告される進行状況と完了をアプリから認識する方法について説明します。"
ms.assetid: 17544FD7-A336-4254-97DC-2BF8994FF9B2
ms.sourcegitcommit: 39a012976ee877d8834b63def04e39d847036132
ms.openlocfilehash: 07d69b63b272153bc784ed19166e649f80a98297

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

>  [!div class="tabbedCodeSnippets"]
>  ```cs
>  private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
>  {
>      // TODO: Add code that deals with background task completion.
>  }
>  ```
>  ```cpp
>  auto completed = [this](BackgroundTaskRegistration^ task, BackgroundTaskCompletedEventArgs^ args)
>  {
>      // TODO: Add code that deals with background task completion.
>  };
>  ```

2.  [!div class="tabbedCodeSnippets"]

    バックグラウンド タスクの完了を処理するイベント ハンドラーにコードを追加します。

    > [!div class="tabbedCodeSnippets"]
    >     ```cs
    >     private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
    >     {
    >         UpdateUI();
    >     }
    >     ```
    >     ```cpp
    >     auto completed = [this](BackgroundTaskRegistration^ task, BackgroundTaskCompletedEventArgs^ args)
    >     {    
    >         UpdateUI();
    >     };
    >     ```

## たとえば、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)は UI を更新します。


1.  [!div class="tabbedCodeSnippets"] ```cs
    private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
    {
        UpdateUI();
    }
    ```
    ```cpp
    auto completed = [this](BackgroundTaskRegistration^ task, BackgroundTaskCompletedEventArgs^ args)
    {    
        UpdateUI();
    };
    ``` バックグラウンド タスクの進行状況を処理するイベント ハンドラー関数を作成する

    完了したバックグラウンド タスクを処理するイベント ハンドラー関数を作ります。

    > [!div class="tabbedCodeSnippets"]
    >     ```cs
    >     private void OnProgress(IBackgroundTaskRegistration task, BackgroundTaskProgressEventArgs args)
    >     {
    >         // TODO: Add code that deals with background task progress.
    >     }
    >     ```
    >     ```cpp
    >     auto progress = [this](BackgroundTaskRegistration^ task, BackgroundTaskProgressEventArgs^ args)
    >     {
    >         // TODO: Add code that deals with background task progress.
    >     };
    >     ```

2.  このコードは、[**IBackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224803) オブジェクトと [**BackgroundTaskProgressEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224782) オブジェクトを受け入れる特定のフットプリントに従っている必要があります。

    OnProgress バックグラウンド タスク イベント ハンドラー メソッドには次のフットプリントを使います。

    > [!div class="tabbedCodeSnippets"]
    >     [!div class="tabbedCodeSnippets"] ```cs
    >     private void OnProgress(IBackgroundTaskRegistration task, BackgroundTaskProgressEventArgs args)
    >     {
    >         // TODO: Add code that deals with background task progress.
    >     }
    ```
    ```cpp
    auto progress = [this](BackgroundTaskRegistration^ task, BackgroundTaskProgressEventArgs^ args)
    {
        // TODO: Add code that deals with background task progress.
    };
    ```
    >
    >         UpdateUI();
    >     }
    >     ```
    >     ```cpp
    >     auto progress = [this](BackgroundTaskRegistration^ task, BackgroundTaskProgressEventArgs^ args)
    >     {
    >         auto progress = "Progress: " + args->Progress + "%";
    >         BackgroundTaskSample::SampleBackgroundTaskProgress = progress;
    >
    >         UpdateUI();
    >     };
    >     ```

## バックグラウンド タスクの完了を処理するイベント ハンドラーにコードを追加します。


1.  たとえば、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)では、*args* パラメーターで渡された進行状態により、UI が更新されます。

    [!div class="tabbedCodeSnippets"]     ```cs     private void OnProgress(IBackgroundTaskRegistration task, BackgroundTaskProgressEventArgs args)     {         var progress = "Progress: " + args.Progress + "%";         BackgroundTaskSample.SampleBackgroundTaskProgress = progress;

    > [!div class="tabbedCodeSnippets"]
    >     ```cs
    >     private void AttachProgressAndCompletedHandlers(IBackgroundTaskRegistration task)
    >     {
    >         task.Progress += new BackgroundTaskProgressEventHandler(OnProgress);
    >         task.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted);
    >     }
    >     ```
    >     新規および既存のバックグラウンド タスクと共にイベント ハンドラー関数を登録する
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
    >     ```

2.  アプリで初めてバックグラウンド タスクを登録するときは、フォアグラウンドでまだアプリがアクティブになっていてタスクか実行されている場合に、進行状況と完了の更新を受け取ることができるように登録する必要があります。 たとえば、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)では、登録するバックグラウンド タスクごとに次の関数を呼び出します。

    [!div class="tabbedCodeSnippets"] ```cs
    private void AttachProgressAndCompletedHandlers(IBackgroundTaskRegistration task)
    {
        task.Progress += new BackgroundTaskProgressEventHandler(OnProgress);
        task.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted);
    }
    ```
    ```cpp     void SampleBackgroundTask::AttachProgressAndCompletedHandlers(IBackgroundTaskRegistration^ task)     {         auto progress = [this](BackgroundTaskRegistration^ task, BackgroundTaskProgressEventArgs^ args)
                  {             auto progress = "Progress: " + args->Progress + "%";             BackgroundTaskSample::SampleBackgroundTaskProgress = progress;             UpdateUI();         };

    > [!div class="tabbedCodeSnippets"]
    >     アプリが起動された時点、またはバックグラウンド タスクの状態が関連する新しいページに移動した時点で、現在登録されているバックグラウンド タスクの一覧を取得し、進行状況と完了に対応するイベント ハンドラー関数に関連付ける必要があります。
    >
    >         UpdateUI();
    >     }
    >     ```
    >     ```cpp
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
    >     ```

## アプリケーションで現在登録されているバックグラウンド タスクの一覧は、[**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786).[**AllTasks**](https://msdn.microsoft.com/library/windows/apps/br224787) プロパティで保持されます。


****

* [たとえば、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)では、次のコードを使って SampleBackgroundTask ページの移動時にイベント ハンドラーをアタッチします。](create-and-register-a-background-task.md)
* [[!div class="tabbedCodeSnippets"]     ```cs     protected override void OnNavigatedTo(NavigationEventArgs e)     {         foreach (var task in BackgroundTaskRegistration.AllTasks)         {             if (task.Value.Name == BackgroundTaskSample.SampleBackgroundTaskName)             {                 AttachProgressAndCompletedHandlers(task.Value);                 BackgroundTaskSample.UpdateBackgroundTaskStatus(BackgroundTaskSample.SampleBackgroundTaskName, true);             }         }](declare-background-tasks-in-the-application-manifest.md)
* [関連トピック](handle-a-cancelled-background-task.md)
* [バックグラウンド タスクの作成と登録](register-a-background-task.md)
* [アプリケーション マニフェストでのバックグラウンド タスクの宣言](respond-to-system-events-with-background-tasks.md)
* [取り消されたバックグラウンド タスクの処理](set-conditions-for-running-a-background-task.md)
* [バックグラウンド タスクの登録](update-a-live-tile-from-a-background-task.md)
* [バックグラウンド タスクによるシステム イベントへの応答](use-a-maintenance-trigger.md)
* [バックグラウンド タスクを実行するための条件の設定](run-a-background-task-on-a-timer-.md)
* [バックグラウンド タスクのライブ タイルの更新](guidelines-for-background-tasks.md)

****

* [メンテナンス トリガーの使用](debug-a-background-task.md)
* [タイマーでのバックグラウンド タスクの実行](http://go.microsoft.com/fwlink/p/?linkid=254345)

 

 



<!--HONumber=Jun16_HO5-->


