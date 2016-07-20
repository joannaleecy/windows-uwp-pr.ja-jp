---
author: TylerMSFT
title: "バックグラウンド タスクの作成と登録"
description: "バックグラウンド タスク クラスを作り、アプリがフォアグラウンドにない場合にも実行されるように登録します。"
ms.assetid: 4F98F6A3-0D3D-4EFB-BA8E-30ED37AE098B
translationtype: Human Translation
ms.sourcegitcommit: 579547b7bd2ee76390b8cac66855be4a9dce008e
ms.openlocfilehash: e8da193f96709bdd87bd6a008eb5885cc5c819fd

---

# バックグラウンド タスクの作成と登録


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


**重要な API**

-   [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794)
-   [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768)
-   [**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781)

バックグラウンド タスク クラスを作り、アプリがフォアグラウンドにない場合にも実行されるように登録します。

## バックグラウンド タスク クラスを作る


[**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) インターフェイスを実装するクラスを作ると、コードをバックグラウンドで実行できます。 このコードは、[**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839) や [**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517) などを使って特定のイベントをトリガーすると実行されます。

次の手順では、[**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) インターフェイスを実装する新しいクラスを記述する方法について説明します。 この作業を始める前に、バックグラウンド タスク用の新しいプロジェクトをソリューション内に作ります。 バックグラウンド タスク用の新しい空のクラスを追加し、[Windows.ApplicationModel.Background](https://msdn.microsoft.com/library/windows/apps/br224847) 名前空間をインポートします。

1.  バックグラウンド タスク用に新しいプロジェクトを作ってソリューションに追加します。 このためには、**[ソリューション エクスプローラー]** のソリューション ノードを右クリックし、[追加]、[新しいプロジェクト] を順に選びます。 プロジェクトの種類として **Windows ランタイム コンポーネント (ユニバーサル Windows)** を選び、プロジェクトに名前を付け、[OK] をクリックします。
2.  ユニバーサル Windows プラットフォーム (UWP) アプリ プロジェクトからバックグラウンド タスク プロジェクトを参照します。

    C++ アプリの場合、アプリ プロジェクトを右クリックし、**[プロパティ]** を選びます。 次に **[共通プロパティ]** に移動します。**[新しい参照の追加]** をクリックし、バックグラウンド タスク プロジェクトの横にあるチェック ボックスをオンにして、両方のダイアログで **[OK]** をクリックします。

    C# アプリの場合、アプリ プロジェクトで **[参照]** を右クリックして **[新しい参照の追加]** をクリックします。 **[ソリューション]** で、**[プロジェクト]** を選び、バックグラウンド タスク プロジェクトの名前を選んで **[OK]** をクリックします。

3.  [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) インターフェイスを実装する新しいクラスを作成します。 [**Run**](https://msdn.microsoft.com/library/windows/apps/br224811) メソッドは、指定のイベントがトリガーされたときに呼び出される必須のエントリ ポイントです。このメソッドは、各バックグラウンド タスクに必要です。

    > [!NOTE]
    > バックグラウンド タスク クラス自体と、バックグラウンド タスク プロジェクト内のその他すべてのクラスは、**sealed** **public** クラスである必要があります。

    次のサンプル コードは、バックグラウンド タスク クラスの基本的な開始点を示しています。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     //
    >     // ExampleBackgroundTask.cs
    >     //
    >
    >     using Windows.ApplicationModel.Background;
    >
    >     namespace Tasks
    >     {
    >         public sealed class ExampleBackgroundTask : IBackgroundTask
    >         {
    >             public void Run(IBackgroundTaskInstance taskInstance)
    >             {
    >                 
    >             }        
    >         }
    >     }
    > ```
    > ```cpp
    >     //
    >     // ExampleBackgroundTask.h
    >     //
    >
    >     #pragma once
    >
    >     using namespace Windows::ApplicationModel::Background;
    >
    >     namespace RuntimeComponent1
    >     {
    >         public ref class ExampleBackgroundTask sealed : public IBackgroundTask
    >         {
    >
    >         public:
    >             ExampleBackgroundTask();
    >
    >             virtual void Run(IBackgroundTaskInstance^ taskInstance);
    >             void OnCompleted(
    >                     BackgroundTaskRegistration^ task,
    >                     BackgroundTaskCompletedEventArgs^ args
    >                     );
    >         };
    >     }
    >
    >     //
    >     // ExampleBackgroundTask.cpp
    >     //
    >
    >     #include "ExampleBackgroundTask.h"
    >
    >     using namespace Tasks;
    >
    >     void ExampleBackgroundTask::Run(IBackgroundTaskInstance^ taskInstance)
    >     {
    >
    >     }
    >  ```

4.  バックグラウンド タスクで非同期コードを実行する場合は、バックグラウンド タスクで遅延を使う必要があります。 遅延を使わない場合、非同期メソッドの呼び出しが完了する前に Run メソッドが終了した場合にバックグラウンド タスク プロセスが予期せずに終了することがあります。

    非同期メソッドを呼び出す前に、Run メソッド中で遅延を要求します。 遅延をグローバル変数に保存して、非同期メソッドからアクセスできるようにします。 非同期コードが完了した後、遅延を完了するように宣言します。

    次のサンプル コードでは、遅延を取得して保存し、非同期コードが完了した時点で解放します。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     BackgroundTaskDeferral _deferral = taskInstance.GetDeferral(); // Note: define at class scope
    >     public async void Run(IBackgroundTaskInstance taskInstance)
    >     {
    >         //
    >         // TODO: Insert code to start one or more asynchronous methods using the
    >         //       await keyword, for example:
    >         //
    >         // await ExampleMethodAsync();
    >         //
    >         
    >         _deferral.Complete();
    >     }
    > ```
    > ```cpp
    >     BackgroundTaskDeferral^ deferral = taskInstance->GetDeferral(); // Note: define at class scope
    >     void ExampleBackgroundTask::Run(IBackgroundTaskInstance^ taskInstance)
    >     {
    >         //
    >         // TODO: Modify the following line of code to call a real async function.
    >         //       Note that the task<void> return type applies only to async
    >         //       actions. If you need to call an async operation instead, replace
    >         //       task<void> with the correct return type.
    >         //
    >         task<void> myTask(ExampleFunctionAsync());
    >         
    >         myTask.then([=] () {
    >             deferral->Complete();
    >         });
    >     }
    > ```

> [!NOTE]
> C# では、**async/await** キーワードを使ってバックグラウンド タスクの非同期メソッドを呼び出すことができます。 C++ では、タスク チェーンを使うことで同様の結果が得られます。

非同期パターンについて詳しくは、「[非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187335)」をご覧ください。 遅延を使ってバックグラウンド タスクの早期停止を防ぐ方法に関するその他の例については、[バックグラウンド タスクのサンプルに関するページ](http://go.microsoft.com/fwlink/p/?LinkId=618666)をご覧ください。

次の手順はいずれかのアプリ クラス (MainPage.xaml.cs など) で実行します。

> [!NOTE]
> バックグラウンド タスクを登録するための専用の関数を作成することもできます (「[バックグラウンド タスクの登録](register-a-background-task.md)」を参照)。 その場合、次の 3 つの手順は不要です。単にトリガーを作成し、タスクの名前とエントリ ポイント、(必要に応じて) 条件と併せて登録関数に渡すだけで済みます。


## 実行するバックグラウンド タスクを登録する

1.  同じバックグラウンド タスクが登録されていないかどうかを、[**BackgroundTaskRegistration.AllTasks**](https://msdn.microsoft.com/library/windows/apps/br224787) プロパティを反復処理して確認します。 この確認は重要です。既にあるバックグラウンド タスクの二重登録をアプリで確認しなかった場合、同じタスクが何度も登録され、パフォーマンスが低下したり、タスクの CPU 時間を使い切って処理を完了できなくなるなどの問題が生じます。

    次の例では、AllTasks プロパティを反復処理し、タスクが既に登録されていた場合はフラグ変数を true に設定します。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     var taskRegistered = false;
    >     var exampleTaskName = "ExampleBackgroundTask";
    >
    >     foreach (var task in BackgroundTaskRegistration.AllTasks)
    >     {
    >         if (task.Value.Name == exampleTaskName)
    >         {
    >             taskRegistered = true;
    >             break;
    >         }
    >     }
    > ```
    > ```cpp
    >     boolean taskRegistered = false;
    >     Platform::String^ exampleTaskName = "ExampleBackgroundTask";
    >
    >     auto iter = BackgroundTaskRegistration::AllTasks->First();
    >     auto hascur = iter->HasCurrent;
    >
    >     while (hascur)
    >     {
    >         auto cur = iter->Current->Value;
    >
    >         if(cur->Name == exampleTaskName)
    >         {
    >             taskRegistered = true;
    >             break;
    >         }
    >
    >         hascur = iter->MoveNext();
    >     }
    > ```

2.  バックグラウンド タスクがまだ登録されていない場合は、[**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) を使ってバックグラウンド タスクのインスタンスを作成します。 タスクのエントリ ポイントには、名前空間を含めてバックグラウンド タスク クラスの名前を指定します。

    バックグラウンド タスク トリガーは、バックグラウンド タスクが実行されるタイミングを制御します。 指定できるトリガーの一覧については、「[**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839)」をご覧ください。

    たとえば、次のコードでは、新しいバックグラウンド タスクを作成し、トリガーとして **TimeZoneChanged** を設定しています。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     var builder = new BackgroundTaskBuilder();
    >
    >     builder.Name = exampleTaskName;
    >     builder.TaskEntryPoint = "RuntimeComponent1.ExampleBackgroundTask";
    >     builder.SetTrigger(new SystemTrigger(SystemTriggerType.TimeZoneChange, false));
    > ```
    > ```cpp
    >     auto builder = ref new BackgroundTaskBuilder();
    >
    >     builder->Name = exampleTaskName;
    >     builder->TaskEntryPoint = "RuntimeComponent1.ExampleBackgroundTask";
    >     builder->SetTrigger(ref new SystemTrigger(SystemTriggerType::TimeZoneChange, false));
    > ```

3.  トリガー イベントの発生後、どのようなときにタスクを実行するかという条件を追加することもできます (省略可能)。 たとえば、ユーザーが存在するときにだけタスクを実行する場合、**UserPresent** という条件を使います。 指定できる条件の一覧については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。

    次のサンプル コードでは、"ユーザーの存在" を条件として割り当てています。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     builder.AddCondition(new SystemCondition(SystemConditionType.UserPresent));
    > ```
    > ```cpp
    >     builder->AddCondition(ref new SystemCondition(SystemConditionType::UserPresent));
    > ```

4.  [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) オブジェクトで Register メソッドを呼び出してバックグラウンド タスクを登録します。 [**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786) の結果は、次の手順に備えて保存します。

    バックグラウンド タスクを登録し、その結果を保存するコードを次に示します。

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     BackgroundTaskRegistration task = builder.Register();
    >     ```
    > ```cpp
    >     BackgroundTaskRegistration^ task = builder->Register();
    > ```

> [!NOTE]
> ユニバーサル Windows アプリは、どの種類のバックグラウンド トリガーを登録する場合でも、先に [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出す必要があります。

更新プログラムのリリース後にユニバーサル Windows アプリが引き続き適切に実行されるようにするには、更新後にアプリが起動する際に、[**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471)、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) の順に呼び出す必要があります。 詳しくは、「[バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)」をご覧ください。

## イベント ハンドラーでバックグラウンド タスクの完了を処理する


アプリからバックグラウンド タスクの結果を取得できるように、[**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781) にメソッドを登録します。 アプリが起動、または再開されると、アプリが最後にフォアグラウンドに置かれた後にバックグラウンド タスクが終了していた場合、mark メソッドが呼び出されます (アプリがフォアグラウンドにある間にバックグラウンド タスクが終了した場合は、OnCompleted メソッドが直ちに呼び出されます)。

1.  バックグラウンド タスクの完了を処理する OnCompleted メソッドを記述します。 たとえば、バックグラウンド タスクの結果により UI を更新できます。 ここに示すメソッドのフットプリントは、この例では *args* パラメーターは使われていませんが、OnCompleted イベント ハンドラー メソッドで必須になります。

    次のサンプル コードは、バックグラウンド タスクの完了を認識し、メッセージ文字列を使う UI 更新メソッドの例を呼び出します。

     > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
    >     {
    >         var settings = Windows.Storage.ApplicationData.Current.LocalSettings;
    >         var key = task.TaskId.ToString();
    >         var message = settings.Values[key].ToString();
    >         UpdateUI(message);
    >     }
    > ```
    > ```cpp
    >     void ExampleBackgroundTask::OnCompleted(BackgroundTaskRegistration^ task, BackgroundTaskCompletedEventArgs^ args)
    >     {
    >         auto settings = ApplicationData::Current->LocalSettings->Values;
    >         auto key = task->TaskId.ToString();
    >         auto message = dynamic_cast<String^>(settings->Lookup(key));
    >         UpdateUI(message);
    >     }
    > ```

    > [!NOTE]
    > UI の更新は、UI スレッドを拘束することがないように、非同期で実行する必要があります。 例については、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)の UpdateUI メソッドを参照してください。



2.  バックグラウンド タスクを登録した位置に戻ります。 そのコード行の後に、新しい [**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781) オブジェクトを追加します。 **BackgroundTaskCompletedEventHandler** コンストラクターのパラメーターとして OnCompleted メソッドを指定します。

    次のサンプル コードにより、[**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786) に [**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781) が追加されます。

     > [!div class="tabbedCodeSnippets"]
    > ```cs
    >     task.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted);
    > ```
    > ```cpp
    >     task->Completed += ref new BackgroundTaskCompletedEventHandler(this, &ExampleBackgroundTask::OnCompleted);
    > ```

## アプリがバックグラウンド タスクを使うことをアプリ マニフェストで宣言する

アプリでバックグラウンド タスクを実行する前に、各バックグラウンド タスクをアプリ マニフェストで宣言する必要があります。 マニフェストに記載されていないトリガーでバックグラウンド タスクの登録を試みると、登録は失敗します。

1.  Package.appxmanifest という名前のファイルを開いて、パッケージ マニフェスト デザイナーを開きます。
2.  **[宣言]** タブを開きます。
3.  **[使用可能な宣言]** ボックスの一覧の **[バックグラウンド タスク]** を選び、**[追加]** をクリックします。
4.  **[システム イベント]** チェック ボックスをオンにします。
5.  **[エントリ ポイント]** ボックスに、バックグラウンド クラスの名前空間と名前を入力します。この例の場合、RuntimeComponent1.ExampleBackgroundTask です。
6.  マニフェスト デザイナーを閉じます。

    バック グラウンド タスクを登録するために、次の Extensions 要素が Package.appxmanifest ファイルに追加されます。

    ```xml
    <Extensions>
      <Extension Category="windows.backgroundTasks" EntryPoint="RuntimeComponent1.ExampleBackgroundTask">
        <BackgroundTasks>
          <Task Type="systemEvent" />
        </BackgroundTasks>
      </Extension>
    </Extensions>
    ```

## 要約と次のステップ


ここでは、バックグラウンド タスク クラスの記述方法、アプリ内からバックグラウンド タスクを登録する方法、バックグラウンド タスクが完了したことをアプリで認識する方法の基本について学習しました。 また、アプリで適切にバックグラウンド タスクを登録できるように、アプリ マニフェストを更新する方法についても学習しました。

> [!NOTE]
> [バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)をダウンロードして、バックグラウンド タスクを使う完全で堅牢な UWP アプリのコンテキストで類似のコード例を確認してください。

API リファレンス、バックグラウンド タスクの概念的ガイダンス、バックグラウンド タスクを使ったアプリの作成に関する詳しい説明については、次の関連するトピックを参照してください。

> [!NOTE]
> この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。

## 関連トピック

**バックグラウンド タスクに関する手順を詳しく説明するトピック**

* [バックグラウンド タスクによるシステム イベントへの応答](respond-to-system-events-with-background-tasks.md)
* [バックグラウンド タスクの登録](register-a-background-task.md)
* [バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)
* [メンテナンス トリガーの使用](use-a-maintenance-trigger.md)
* [取り消されたバックグラウンド タスクの処理](handle-a-cancelled-background-task.md)
* [バックグラウンド タスクの進捗状況と完了の監視](monitor-background-task-progress-and-completion.md)
* [タイマーでのバックグラウンド タスクの実行](run-a-background-task-on-a-timer-.md)

**バックグラウンド タスクのガイダンス**

* [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)
* [バックグラウンド タスクのデバッグ](debug-a-background-task.md)
* [Windows ストア アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)](http://go.microsoft.com/fwlink/p/?linkid=254345)

**バックグラウンド タスクの API リファレンス**

* [**Windows.ApplicationModel.Background**](https://msdn.microsoft.com/library/windows/apps/br224847)



<!--HONumber=Jul16_HO1-->


