---
author: PatrickFarley
ms.assetid: 67a46812-881c-404b-9f3b-c6786f39e72b
title: 印刷ワークフローのカスタマイズ
description: 組織のニーズに合うようにカスタムの印刷ワークフロー エクスペリエンスを作成します。
ms.author: pafarley
ms.date: 08/10/2017
ms.topic: article
keywords: windows 10, uwp, 印刷
ms.localizationpriority: medium
ms.openlocfilehash: f58c0c8397831595c237b7bd9fe4eafb25594ab3
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6269141"
---
# <a name="customize-the-print-workflow"></a>印刷ワークフローのカスタマイズ

## <a name="overview"></a>概要
開発者は、印刷ワークフロー アプリを使用して印刷ワークフローのエクスペリエンスをカスタマイズできます。 印刷ワークフロー アプリは、[Microsoft Store デバイス アプリ (MSDA)](https://docs.microsoft.com/windows-hardware/drivers/devapps/) の機能を拡張する UWP アプリです。このアプリを使用すると、MSDA の詳細を習得する前に、MSDA の概要を理解することができます。 

MSDA の場合と同様に、ソース アプリケーションのユーザーが印刷の実行と印刷ダイアログのナビゲーションをする場合、システムによって、ワークフロー アプリがそのプリンターに関連付けられているかどうかが確認されます。 関連付けられている場合は、印刷ワークフロー アプリが起動します (主にバックグラウンド タスクとして起動されます。以下で詳しく説明します)。 ワークフロー アプリは、印刷チケット (現在の印刷タスク向けにプリンター デバイスの設定を構成する XML ドキュメント) と印刷される実際の XPS コンテンツの両方を変更することができます。 必要に応じて、印刷操作を行っているときに UI を起動することにより、この機能をユーザーに公開することもできます。 印刷ワークフロー アプリの処理が終了すると、印刷コンテンツと印刷チケットがドライバーに渡されます。

バックグラウンド コンポーネントとフォアグラウンド コンポーネントが関連しているため、また他のアプリと機能的に組み合わされるため、印刷ワークフロー アプリは、他の種類の UWP アプリと比べると実装が複雑になる可能性があります。 このガイドをお読みになるときは、[ワークフロー アプリのサンプル](https://github.com/Microsoft/print-oem-samples)について調べることをお勧めします。これにより、さまざまな機能の実装方法ついて詳しく理解することができます。 説明を簡単にするために、このガイドでは一部の機能 (さまざまなエラー チェックや UI の管理など) が省略されています。

## <a name="getting-started"></a>はじめに

ワークフロー アプリでは、適切なタイミングで起動できるように、印刷システムへのエントリ ポイントを示す必要があります。 これを行うには、UWP プロジェクトの *package.appxmanifest* ファイルの `Application/Extensions` 要素にある以下の宣言を挿入します。 

```xml
<uap:Extension Category="windows.printWorkflowBackgroundTask"  
    EntryPoint="WFBackgroundTasks.WfBackgroundTask" />
```

> [!IMPORTANT] 
> 印刷のカスタマイズでユーザー入力を必要としないシナリオはたくさんあります。 このため、既定では、印刷ワークフロー アプリはバックグラウンド タスクとして実行されます。

ワークフロー アプリを、印刷ジョブを開始したソース アプリケーションと関連付ける場合 (この手順については後のセクションをご覧ください)、印刷システムによってマニフェスト ファイルが検査され、バックグラウンド タスクのエントリ ポイントが調べられます。

## <a name="do-background-work-on-the-print-ticket"></a>印刷チケットに対するバックグラウンド処理の実行

印刷システムがワークフロー アプリを使用して実行する最初の処理は、バックグラウンド タスク (この場合は `WFBackgroundTasks` 名前空間の `WfBackgroundTask` クラス) のアクティブ化です。 バックグラウンド タスクの `Run` メソッドでは、タスクのトリガーの詳細を **[PrintWorkflowTriggerDetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowtriggerdetails)** インスタンスとしてキャストする必要があります。 これにより、印刷ワークフローのバックグラウンド タスク向けの特別な機能が利用できるようになります。 また、**[PrintWorkFlowBackgroundSession](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowbackgroundsession)** のインスタンスである **[PrintWorkflowSession](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowtriggerdetails.PrintWorkflowSession)** プロパティが公開されます。 印刷ワークフロー セッションのクラス (バックグラウンドとフォアグラウンドの両方に関するクラス) によって、印刷ワークフロー アプリの一連の手順が制御されます。 

次に、このセッションのクラスで発生する 2 つのイベント用のハンドラー メソッドを登録します。 これらのメソッドの定義は、後で行います。

```csharp
public void Run(IBackgroundTaskInstance taskInstance) {
    // Take out a deferral here and complete once all the callbacks are done
    runDeferral = taskInstance.GetDeferral();

    // Associate a cancellation handler with the background task.
    taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);

    // cast the task's trigger details as PrintWorkflowTriggerDetails
    PrintWorkflowTriggerDetails workflowTriggerDetails = taskInstance.TriggerDetails as PrintWorkflowTriggerDetails;

    // Get the session manager, which is unique to this print job
    PrintWorkflowBackgroundSession sessionManager = workflowTriggerDetails.PrintWorkflowSession;

    // add the event handler callback routines
    sessionManager.SetupRequested += OnSetupRequested;
    sessionManager.Submitted += OnXpsOMPrintSubmitted;

    // Allow the event source to start
    // This call blocks until all of the workflow callbacks complete
    sessionManager.Start();
}
```

`Start` メソッドが呼び出されると、まずセッション マネージャーで **[SetupRequested](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowbackgroundsession.SetupRequested)** イベントが発生します。 このイベントによって、印刷タスクと印刷チケットに関する一般的な情報が公開されます。 この段階では、印刷チケットをバックグラウンドで編集できます。 

```csharp
private void OnSetupRequested(PrintWorkflowBackgroundSession sessionManager, PrintWorkflowBackgroundSetupRequestedEventArgs printTaskSetupArgs) {
    // Take out a deferral here and complete once all the callbacks are done
    Deferral setupRequestedDeferral = printTaskSetupArgs.GetDeferral();

    // Get general information about the source application, print job title, and session ID
    string sourceApplicationName = printTaskSetupArgs.Configuration.SourceAppDisplayName;
    string jobTitle = printTaskSetupArgs.Configuration.JobTitle;
    string sessionId = printTaskSetupArgs.Configuration.SessionId;

    // edit the print ticket
    WorkflowPrintTicket printTicket = printTaskSetupArgs.GetUserPrintTicketAsync();

    // ...
```

重要な点は、**SetupRequested** の処理で、アプリがフォアグラウンドコンポーネントを起動するかどうかを決定することです。 これは、ローカル記憶域に以前保存した設定、または印刷チケットの編集中に発生したイベントによって決まります。あるいは、特定のアプリの静的な設定がこの決定に影響する場合もあります。

```csharp
    // ...
    
    if (UIrequested) {
        printTaskSetupArgs.SetRequiresUI();

        // Any data that is to be passed to the foreground task must be stored the app's local storage.
        // It should be prefixed with the sourceApplicationName string and the SessionId string, so that
        // it can be identified as pertaining to this workflow app session.
    }

    // Complete the deferral taken out at the start of OnSetupRequested
    setupRequestedDeferral.Complete();
}
```

## <a name="do-foreground-work-on-the-print-job-optional"></a>印刷ジョブに対するフォアグラウンド処理の実行 (オプション)

**[SetRequiresUI](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowbackgroundsetuprequestedeventargs.SetRequiresUI)** メソッドが呼び出されると、印刷システムによってマニフェスト ファイルが検査され、フォアグラウンド アプリケーションへのエントリ ポイントが調べられます。 *package.appxmanifest* ファイルの `Application/Extensions` 要素には、以下の行が含まれている必要があります。 `EntryPoint` の値は、フォアグラウンド アプリの名前に変更してください。

```xml
<uap:Extension Category="windows.printWorkflowForegroundTask"  
    EntryPoint="MyWorkFlowForegroundApp.App" /> 
```

次に、印刷システムによって、指定されたアプリのエントリ ポイントで **OnActivated** メソッドが呼び出されます。 _App.xaml.cs_ ファイルの **OnActivated** メソッドでは、ワークフロー アプリはアクティブ化の種類を調べ、ワークフローのアクティブ化であることを確認する必要があります。 ワークフローのアクティブ化である場合、ワークフロー アプリではアクティブ化引数を **[PrintWorkflowUIActivatedEventArgs](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowuiactivatedeventargs)** オブジェクトにキャストできます。このオブジェクトでは、**[PrintWorkflowForegroundSession](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowforegroundsession)** オブジェクトがプロパティとして公開されます。 このオブジェクトは、前のセクションのバックグラウンドに対応するもので、印刷システムで発生するイベントを含んでいます。これらのイベントには、ハンドラーを割り当てることができます この場合、イベント処理機能は `WorkflowPage` という個別のクラスに実装されます。

まず、_App.xaml.cs_ ファイルの例を次に示します。

```csharp
protected override void OnActivated(IActivatedEventArgs args){

    if (args.Kind == ActivationKind.PrintWorkflowForegroundTask) {

        // the app should instantiate a new UI view so that it can properly handle the case when 
        // several print jobs are active at the same time.
        Frame rootFrame = new Frame();
        if (null == Window.Current.Content)
        {
            rootFrame.Navigate(typeof(WorkflowPage));
            Window.Current.Content = rootFrame;
        }

        // Get the main page
        WorkflowPage workflowPage = (WorkflowPage)rootFrame.Content;

        // Make sure the page knows it's handling a foreground task activation
        workflowPage.LaunchType = WorkflowPage.WorkflowPageLaunchType.ForegroundTask;

        // Get the activation arguments
        PrintWorkflowUIActivatedEventArgs printTaskUIEventArgs = args as PrintWorkflowUIActivatedEventArgs;

        // Get the session manager
        PrintWorkflowForegroundSession taskSessionManager = printTaskUIEventArgs.PrintWorkflowSession;

        // Add the callback handlers - these methods are in the workflowPage class
        taskSessionManager.SetupRequested += workflowPage.OnSetupRequested;
        taskSessionManager.XpsDataAvailable += workflowPage.OnXpsDataAvailable;

        // start raising the print workflow events
        taskSessionManager.Start();
    }
}
```

UI がイベント ハンドラーをアタッチし、**OnActivated** メソッドが終了すると、UI による処理ができるように、印刷システムでは **[SetupRequested](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowforegroundsession.SetupRequested)** イベントが発生します。 このイベントでは、バックグラウンド タスクのセットアップ イベントで提供されるものと同じデータが提供されます。このデータには、印刷ジョブの情報や印刷チケットのドキュメントが含まれますが、追加の UI の起動を要求する機能は含まれていません。 _WorkflowPage.xaml.cs_ ファイルの例を次に示します。

```csharp
internal void OnSetupRequested(PrintWorkflowForegroundSession sessionManager, PrintWorkflowForegroundSetupRequestedEventArgs printTaskSetupArgs) {
    // If anything asynchronous is going to be done, you need to take out a deferral here,
    // since otherwise the next callback happens once this one exits, which may be premature
    Deferral setupRequestedDeferral = printTaskSetupArgs.GetDeferral();

    // Get information about the source application, print job title, and session ID
    string sourceApplicationName = printTaskSetupArgs.Configuration.SourceAppDisplayName;
    string jobTitle = printTaskSetupArgs.Configuration.JobTitle;
    string sessionId = printTaskSetupArgs.Configuration.SessionId;
    // the following string should be used when storing data that pertains to this workflow session
    // (such as user input data that is meant to change the print content later on)
    string localStorageVariablePrefix = string.Format("{0}::{1}::", sourceApplicationName, sessionID);
    
    try
    {
        // receive and store user input
        // ...
    }
    catch (Exception ex)
    {
        string errorMessage = ex.Message;
        Debug.WriteLine(errorMessage);
    }
    finally
    {
        // Complete the deferral taken out at the start of OnSetupRequested
        setupRequestedDeferral.Complete();
    }
}
```

次に、印刷システムによって、UI 用の **[XpsDataAvailable](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowforegroundsession.XpsDataAvailable)** イベントが発生します。 このイベントのハンドラーでは、ワークフロー アプリはセットアップ イベントで利用できるすべてのデータにアクセスできます。また、追加の XPS データを、未処理のバイトのストリームまたはオブジェクト モデルとして直接読み取ることもできます。 XPS データへのアクセスによって、UI では印刷プレビュー サービスを提供し、ワークフロー アプリがデータに対して実行する処理についての追加情報をユーザーに提供することができます。 

このイベント ハンドラーの一環として、ワークフロー アプリでは、ユーザーとのやり取りを継続する場合に遅延オブジェクトを取得する必要があります。 遅延を使用しないと、印刷システムでは、**XpsDataAvailable** イベント ハンドラーが終了したとき、またはこのハンドラーで非同期メソッドが呼び出されたときに UI タスクが完了したと見なされます。 アプリがユーザーと UI とのやり取りから必要な情報をすべて収集したときに、アプリでは遅延を終了し、印刷システムが次の処理に進めるようにする必要があります。

```csharp
internal async void OnXpsDataAvailable(PrintWorkflowForegroundSession sessionManager, PrintWorkflowXpsDataAvailableEventArgs printTaskXpsAvailableEventArgs)
{
    // Take out a deferral
    Deferral xpsDataAvailableDeferral = printTaskXpsAvailableEventArgs.GetDeferral();

    SpoolStreamContent xpsStream = printTaskXpsAvailableEventArgs.Operation.XpsContent.GetSourceSpoolDataAsStreamContent(); 
 
    IInputStream inputStream = xpsStream.GetInputSpoolStream(); 
 
    using (var inputReader = new Windows.Storage.Streams.DataReader(inputStream)) 
    { 
        // Read the XPS data from input stream 
        byte[] xpsData = new byte[inputReader.UnconsumedBufferLength]; 
        while (inputReader.UnconsumedBufferLength > 0) 
        { 
            inputReader.ReadBytes(xpsData); 
            // Do something with the XPS data, e.g. preview 
            // ...                  
        } 
    } 

    // Complete the deferral taken out at the start of this method
    xpsDataAvailableDeferral.Complete();
}
```

また、イベント引数によって公開される **[PrintWorkflowSubmittedOperation](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsubmittedoperation)** インスタンスでは、印刷ジョブを取り消したり、印刷ジョブは成功したが出力の印刷ジョブが必要ないことを指定したりするためのオプションが提供されます。 これは、**[PrintWorkflowSubmittedStatus](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsubmittedstatus)** 値を使用して **[Complete](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsubmittedoperation.Complete)** メソッドを呼び出すことで実行されます。

> [!NOTE]
> ワークフロー アプリで印刷ジョブを取り消す場合は、ジョブが取り消された理由を示すトースト通知を提供することを強くお勧めします。 


## <a name="do-final-background-work-on-the-print-content"></a>印刷コンテンツに対する最終的なバックグラウンド処理の実行

UI で **PrintTaskXpsDataAvailable** イベントの遅延が完了した場合 (または UI の手順が省略された場合)、印刷システムではバックグラウンド タスク用の **[Submitted](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowbackgroundsession.Submitted)** イベントが発生します。 このイベントのハンドラーでは、ワークフロー アプリは **XpsDataAvailable** イベントで提供されるものと同じすべてのデータにアクセスできます。 ただし、これまでのイベントとは異なり、**Submitted** は **[PrintWorkflowTarget](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowtarget)** インスタンスを使用して、最終的な印刷ジョブのコンテンツに対する*書き込み*アクセスを提供します。 

最終的な印刷で必要となるデータをスプールする場合に使用されるオブジェクトは、ソース データが未処理のバイトのストリームとしてアクセスされるのか、XPS オブジェクト モデルとしてアクセスされるのかによって異なります。 ワークフロー アプリがバイト ストリームを介してソース データにアクセスするときは、最終的なジョブ データを書き込むために、出力のバイト ストリームが提供されます。 ワークフロー アプリがオブジェクト モデルを介してソース データにアクセスするときは、オブジェクトを出力ジョブに書き込むために、ドキュメント ライターが提供されます。 どちらの場合も、ワークフロー アプリでは、すべてのソース データを読み取り、必要なデータを変更し、変更されたデータを出力ターゲットに書き込む必要があります。

バックグラウンド タスクでデータの書き込みが完了したら、対応する **PrintWorkflowSubmittedOperation** オブジェクトで **Complete** を呼び出します。 ワークフロー アプリでこの手順が完了し、**Submitted** イベント ハンドラーが終了すると、ワークフロー セッションが閉じられ、ユーザーは、標準的な印刷ダイアログで最終的な印刷ジョブの状態を監視できます。

## <a name="final-steps"></a>最後の手順

### <a name="register-the-print-workflow-app-to-the-printer"></a>印刷ワークフロー アプリをプリンターに登録する

ワークフロー アプリは、MSDA の場合と同じ種類のメタデータ ファイル送信を使用するプリンターに関連付けられます。 実際には、1 つの UWP アプリケーションが、ワークフロー アプリと、印刷タスクの設定機能を提供する MSDA の両方として機能することができます。 関連する「[MSDA steps for creating the metadata association](https://docs.microsoft.com/windows-hardware/drivers/devapps/step-2--create-device-metadata)」(メタデータの関連付けを作成するための MSDA の手順) に従ってください。

相違点は、MSDA はユーザーに対して自動的にアクティブ化されますが (関連付けられているデバイスでユーザーが印刷を実行すると、アプリは常に起動されます)、ワークフロー アプリは自動的にはアクティブ化されないことです。 これらのアプリに対しては、それぞれ別のポリシーを設定する必要があります。

### <a name="set-the-workflow-apps-policy"></a>ワークフロー アプリのポリシーの設定
ワークフロー アプリのポリシーは、ワークフロー アプリを実行するデバイス上で PowerShell コマンドによって設定されます。 Set-Printer、Add-Printer (既存のポート)、Add-Printer (新しい WSD ポート) の各コマンドを、ワークフロー ポリシーの設定を許可するように変更します。 
* `Disabled`: ワークフロー アプリはアクティブ化されません。
* `Uninitialized`: ワークフロー アプリは、ワークフロー DCA がシステムにインストールされている場合にアクティブ化されます。 アプリがインストールされていない場合は、印刷が引き続き実行されます。 
* `Enabled`: ワークフロー コントラクトは、ワークフロー DCA がシステムにインストールされている場合にアクティブ化されます。 アプリがインストールされていない場合は、印刷は失敗します。 

次のコマンドは、指定されたプリンターでワークフロー アプリを必須のアプリにします。
```Powershell
Set-Printer –Name "Microsoft XPS Document Writer" -WorkflowPolicy On
```

ローカル ユーザーは、このポリシーをローカル プリンタで実行することができます。企業での実装を目的とする場合、プリンターの管理者は、このポリシーをプリント サーバーで実行することができます。 実行後、ポリシーはすべてのクライアント接続に対して同期されます。 プリンターの管理者は、新しいプリンターを追加するたびにこのポリシーを使用できます。

## <a name="see-also"></a>関連項目

[ワークフロー アプリのサンプル](https://github.com/Microsoft/print-oem-samples)

[Windows.Graphics.Printing.Workflow 名前空間](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow)


