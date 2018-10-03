---
author: PatrickFarley
ms.assetid: 67a46812-881c-404b-9f3b-c6786f39e72b
title: 印刷ワークフローのカスタマイズ
description: 組織のニーズに合うようにカスタムの印刷ワークフロー エクスペリエンスを作成します。
ms.author: pafarley
ms.date: 08/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 印刷
ms.localizationpriority: medium
ms.openlocfilehash: 9e53c15b01a08c8c617529fe074929ce89a68ce9
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4312622"
---
# <a name="customize-the-print-workflow"></a><span data-ttu-id="3f830-104">印刷ワークフローのカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="3f830-104">Customize the print workflow</span></span>

## <a name="overview"></a><span data-ttu-id="3f830-105">概要</span><span class="sxs-lookup"><span data-stu-id="3f830-105">Overview</span></span>
<span data-ttu-id="3f830-106">開発者は、印刷ワークフロー アプリを使用して印刷ワークフローのエクスペリエンスをカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="3f830-106">Developers can customize the printing workflow experience through the use of a print workflow app.</span></span> <span data-ttu-id="3f830-107">印刷ワークフロー アプリは、[Microsoft Store デバイス アプリ (MSDA)](https://docs.microsoft.com/windows-hardware/drivers/devapps/) の機能を拡張する UWP アプリです。このアプリを使用すると、MSDA の詳細を習得する前に、MSDA の概要を理解することができます。</span><span class="sxs-lookup"><span data-stu-id="3f830-107">Print workflow apps are UWP apps that expand on the functionality of [Microsoft Store devices apps (WSDAs)](https://docs.microsoft.com/windows-hardware/drivers/devapps/), so it will be helpful to have some familiarity with WSDAs before going further.</span></span> 

<span data-ttu-id="3f830-108">MSDA の場合と同様に、ソース アプリケーションのユーザーが印刷の実行と印刷ダイアログのナビゲーションをする場合、システムによって、ワークフロー アプリがそのプリンターに関連付けられているかどうかが確認されます。</span><span class="sxs-lookup"><span data-stu-id="3f830-108">Just as in the case of WSDAs, when the user of a source application elects to print something and navigates through the print dialog, the system checks whether a workflow app is associated with that printer.</span></span> <span data-ttu-id="3f830-109">関連付けられている場合は、印刷ワークフロー アプリが起動します (主にバックグラウンド タスクとして起動されます。以下で詳しく説明します)。</span><span class="sxs-lookup"><span data-stu-id="3f830-109">If it is, the print workflow app launches (primarily as a background task; more on this below).</span></span> <span data-ttu-id="3f830-110">ワークフロー アプリは、印刷チケット (現在の印刷タスク向けにプリンター デバイスの設定を構成する XML ドキュメント) と印刷される実際の XPS コンテンツの両方を変更することができます。</span><span class="sxs-lookup"><span data-stu-id="3f830-110">A workflow app is able to alter both the print ticket (the XML document that configures the printer device settings for the current print task) and the actual XPS content to be printed.</span></span> <span data-ttu-id="3f830-111">必要に応じて、印刷操作を行っているときに UI を起動することにより、この機能をユーザーに公開することもできます。</span><span class="sxs-lookup"><span data-stu-id="3f830-111">It can optionally expose this functionality to the user by launching a UI midway through the process.</span></span> <span data-ttu-id="3f830-112">印刷ワークフロー アプリの処理が終了すると、印刷コンテンツと印刷チケットがドライバーに渡されます。</span><span class="sxs-lookup"><span data-stu-id="3f830-112">After doing its work, it passes the print content and print ticket on to the driver.</span></span>

<span data-ttu-id="3f830-113">バックグラウンド コンポーネントとフォアグラウンド コンポーネントが関連しているため、また他のアプリと機能的に組み合わされるため、印刷ワークフロー アプリは、他の種類の UWP アプリと比べると実装が複雑になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3f830-113">Because it involves background and foreground components, and because it is functionally coupled with other app(s), a print workflow app can be more complicated to implement than other categories of UWP apps.</span></span> <span data-ttu-id="3f830-114">このガイドをお読みになるときは、[ワークフロー アプリのサンプル](https://github.com/Microsoft/print-oem-samples)について調べることをお勧めします。これにより、さまざまな機能の実装方法ついて詳しく理解することができます。</span><span class="sxs-lookup"><span data-stu-id="3f830-114">It is recommended that you inspect the [Workflow app sample](https://github.com/Microsoft/print-oem-samples) while reading this guide to better understand how the different features can be implemented.</span></span> <span data-ttu-id="3f830-115">説明を簡単にするために、このガイドでは一部の機能 (さまざまなエラー チェックや UI の管理など) が省略されています。</span><span class="sxs-lookup"><span data-stu-id="3f830-115">Some features, such as various error checks and UI management, are absent from this guide for the sake of simplicity.</span></span>

## <a name="getting-started"></a><span data-ttu-id="3f830-116">はじめに</span><span class="sxs-lookup"><span data-stu-id="3f830-116">Getting started</span></span>

<span data-ttu-id="3f830-117">ワークフロー アプリでは、適切なタイミングで起動できるように、印刷システムへのエントリ ポイントを示す必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f830-117">The workflow app must indicate its entry point to the print system so that it can be launched at the appropriate time.</span></span> <span data-ttu-id="3f830-118">これを行うには、UWP プロジェクトの *package.appxmanifest* ファイルの `Application/Extensions` 要素にある以下の宣言を挿入します。</span><span class="sxs-lookup"><span data-stu-id="3f830-118">This is done by inserting the following declaration in the `Application/Extensions` element of the UWP project's *package.appxmanifest* file.</span></span> 

```xml
<uap:Extension Category="windows.printWorkflowBackgroundTask"  
    EntryPoint="WFBackgroundTasks.WfBackgroundTask" />
```

> [!IMPORTANT] 
> <span data-ttu-id="3f830-119">印刷のカスタマイズでユーザー入力を必要としないシナリオはたくさんあります。</span><span class="sxs-lookup"><span data-stu-id="3f830-119">There are many scenarios in which the print customization does not require user input.</span></span> <span data-ttu-id="3f830-120">このため、既定では、印刷ワークフロー アプリはバックグラウンド タスクとして実行されます。</span><span class="sxs-lookup"><span data-stu-id="3f830-120">For this reason, Print workflow apps run as background tasks by default.</span></span>

<span data-ttu-id="3f830-121">ワークフロー アプリを、印刷ジョブを開始したソース アプリケーションと関連付ける場合 (この手順については後のセクションをご覧ください)、印刷システムによってマニフェスト ファイルが検査され、バックグラウンド タスクのエントリ ポイントが調べられます。</span><span class="sxs-lookup"><span data-stu-id="3f830-121">If a workflow app is associated with the source application that started the print job (see later section for instructions on this), the print system examines its manifest files for a background task entry point.</span></span>

## <a name="do-background-work-on-the-print-ticket"></a><span data-ttu-id="3f830-122">印刷チケットに対するバックグラウンド処理の実行</span><span class="sxs-lookup"><span data-stu-id="3f830-122">Do background work on the print ticket</span></span>

<span data-ttu-id="3f830-123">印刷システムがワークフロー アプリを使用して実行する最初の処理は、バックグラウンド タスク (この場合は `WFBackgroundTasks` 名前空間の `WfBackgroundTask` クラス) のアクティブ化です。</span><span class="sxs-lookup"><span data-stu-id="3f830-123">The first thing the print system does with the workflow app is activate its background task (In this case, the `WfBackgroundTask` class in the `WFBackgroundTasks` namespace).</span></span> <span data-ttu-id="3f830-124">バックグラウンド タスクの `Run` メソッドでは、タスクのトリガーの詳細を **[PrintWorkflowTriggerDetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowtriggerdetails)** インスタンスとしてキャストする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f830-124">In the background task's `Run` method, you should cast the task's trigger details as a **[PrintWorkflowTriggerDetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowtriggerdetails)** instance.</span></span> <span data-ttu-id="3f830-125">これにより、印刷ワークフローのバックグラウンド タスク向けの特別な機能が利用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="3f830-125">This will provide the special functionality for a print workflow background task.</span></span> <span data-ttu-id="3f830-126">また、**[PrintWorkFlowBackgroundSession](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowbackgroundsession)** のインスタンスである **[PrintWorkflowSession](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowtriggerdetails.PrintWorkflowSession)** プロパティが公開されます。</span><span class="sxs-lookup"><span data-stu-id="3f830-126">It exposes the **[PrintWorkflowSession](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowtriggerdetails.PrintWorkflowSession)** property, which is an instance of **[PrintWorkFlowBackgroundSession](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowbackgroundsession)**.</span></span> <span data-ttu-id="3f830-127">印刷ワークフロー セッションのクラス (バックグラウンドとフォアグラウンドの両方に関するクラス) によって、印刷ワークフロー アプリの一連の手順が制御されます。</span><span class="sxs-lookup"><span data-stu-id="3f830-127">Print workflow session classes - both the background and foreground varieties - will control the sequential steps of the print workflow app.</span></span> 

<span data-ttu-id="3f830-128">次に、このセッションのクラスで発生する 2 つのイベント用のハンドラー メソッドを登録します。</span><span class="sxs-lookup"><span data-stu-id="3f830-128">Then register handler methods for the two events that this session class will raise.</span></span> <span data-ttu-id="3f830-129">これらのメソッドの定義は、後で行います。</span><span class="sxs-lookup"><span data-stu-id="3f830-129">You will define these methods later on.</span></span>

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

<span data-ttu-id="3f830-130">`Start` メソッドが呼び出されると、まずセッション マネージャーで **[SetupRequested](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowbackgroundsession.SetupRequested)** イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="3f830-130">When the `Start` method is called, the session manager will raise the **[SetupRequested](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowbackgroundsession.SetupRequested)** event first.</span></span> <span data-ttu-id="3f830-131">このイベントによって、印刷タスクと印刷チケットに関する一般的な情報が公開されます。</span><span class="sxs-lookup"><span data-stu-id="3f830-131">This event exposes general information about the print task, as well as the print ticket.</span></span> <span data-ttu-id="3f830-132">この段階では、印刷チケットをバックグラウンドで編集できます。</span><span class="sxs-lookup"><span data-stu-id="3f830-132">At this stage, the print ticket can be edited in the background.</span></span> 

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

<span data-ttu-id="3f830-133">重要な点は、**SetupRequested** の処理で、アプリがフォアグラウンドコンポーネントを起動するかどうかを決定することです。</span><span class="sxs-lookup"><span data-stu-id="3f830-133">Importantly, it is in the handling of the **SetupRequested** that the app will determine whether to launch a foreground component.</span></span> <span data-ttu-id="3f830-134">これは、ローカル記憶域に以前保存した設定、または印刷チケットの編集中に発生したイベントによって決まります。あるいは、特定のアプリの静的な設定がこの決定に影響する場合もあります。</span><span class="sxs-lookup"><span data-stu-id="3f830-134">This could depend on a setting that was previously saved to local storage, or an event that occurred during the editing of the print ticket, or it may be a static setting of your particular app.</span></span>

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

## <a name="do-foreground-work-on-the-print-job-optional"></a><span data-ttu-id="3f830-135">印刷ジョブに対するフォアグラウンド処理の実行 (オプション)</span><span class="sxs-lookup"><span data-stu-id="3f830-135">Do foreground work on the print job (optional)</span></span>

<span data-ttu-id="3f830-136">**[SetRequiresUI](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowbackgroundsetuprequestedeventargs.SetRequiresUI)** メソッドが呼び出されると、印刷システムによってマニフェスト ファイルが検査され、フォアグラウンド アプリケーションへのエントリ ポイントが調べられます。</span><span class="sxs-lookup"><span data-stu-id="3f830-136">If the **[SetRequiresUI](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowbackgroundsetuprequestedeventargs.SetRequiresUI)** method was called, then the print system will examine the manifest file for the entry point to the foreground application.</span></span> <span data-ttu-id="3f830-137">*package.appxmanifest* ファイルの `Application/Extensions` 要素には、以下の行が含まれている必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f830-137">The `Application/Extensions` element of your *package.appxmanifest* file must have the following lines.</span></span> <span data-ttu-id="3f830-138">`EntryPoint` の値は、フォアグラウンド アプリの名前に変更してください。</span><span class="sxs-lookup"><span data-stu-id="3f830-138">Replace the value of `EntryPoint` with name of the foreground app.</span></span>

```xml
<uap:Extension Category="windows.printWorkflowForegroundTask"  
    EntryPoint="MyWorkFlowForegroundApp.App" /> 
```

<span data-ttu-id="3f830-139">次に、印刷システムによって、指定されたアプリのエントリ ポイントで **OnActivated** メソッドが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="3f830-139">Next, the print system calls the **OnActivated** method for the given app entry point.</span></span> <span data-ttu-id="3f830-140">_App.xaml.cs_ ファイルの **OnActivated** メソッドでは、ワークフロー アプリはアクティブ化の種類を調べ、ワークフローのアクティブ化であることを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f830-140">In the **OnActivated** method of its _App.xaml.cs_ file, the workflow app should check the activation kind to verify that it is a workflow activation.</span></span> <span data-ttu-id="3f830-141">ワークフローのアクティブ化である場合、ワークフロー アプリではアクティブ化引数を **[PrintWorkflowUIActivatedEventArgs](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowuiactivatedeventargs)** オブジェクトにキャストできます。このオブジェクトでは、**[PrintWorkflowForegroundSession](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowforegroundsession)** オブジェクトがプロパティとして公開されます。</span><span class="sxs-lookup"><span data-stu-id="3f830-141">If so, the workflow app can cast the activation arguments to a **[PrintWorkflowUIActivatedEventArgs](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowuiactivatedeventargs)** object, which exposes a **[PrintWorkflowForegroundSession](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowforegroundsession)** object as a property.</span></span> <span data-ttu-id="3f830-142">このオブジェクトは、前のセクションのバックグラウンドに対応するもので、印刷システムで発生するイベントを含んでいます。これらのイベントには、ハンドラーを割り当てることができます</span><span class="sxs-lookup"><span data-stu-id="3f830-142">This object, like its background counterpart in the previous section, contains events that are raised by the print system, and you can assign handlers to these.</span></span> <span data-ttu-id="3f830-143">この場合、イベント処理機能は `WorkflowPage` という個別のクラスに実装されます。</span><span class="sxs-lookup"><span data-stu-id="3f830-143">In this case, the event-handling functionality will be implemented in a separate class called `WorkflowPage`.</span></span>

<span data-ttu-id="3f830-144">まず、_App.xaml.cs_ ファイルの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3f830-144">First, in the _App.xaml.cs_ file:</span></span>

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

<span data-ttu-id="3f830-145">UI がイベント ハンドラーをアタッチし、**OnActivated** メソッドが終了すると、UI による処理ができるように、印刷システムでは **[SetupRequested](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowforegroundsession.SetupRequested)** イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="3f830-145">Once the UI has attached event handlers and the **OnActivated** method has exited, the print system will fire the **[SetupRequested](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowforegroundsession.SetupRequested)** event for the UI to handle.</span></span> <span data-ttu-id="3f830-146">このイベントでは、バックグラウンド タスクのセットアップ イベントで提供されるものと同じデータが提供されます。このデータには、印刷ジョブの情報や印刷チケットのドキュメントが含まれますが、追加の UI の起動を要求する機能は含まれていません。</span><span class="sxs-lookup"><span data-stu-id="3f830-146">This event provides the same data that the background task setup event provided, including the print job info and print ticket document, but without the ability to request the launch of additional UI.</span></span> <span data-ttu-id="3f830-147">_WorkflowPage.xaml.cs_ ファイルの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3f830-147">In the _WorkflowPage.xaml.cs_ file:</span></span>

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

<span data-ttu-id="3f830-148">次に、印刷システムによって、UI 用の **[XpsDataAvailable](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowforegroundsession.XpsDataAvailable)** イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="3f830-148">Next, the print system will raise the **[XpsDataAvailable](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowforegroundsession.XpsDataAvailable)** event for the UI.</span></span> <span data-ttu-id="3f830-149">このイベントのハンドラーでは、ワークフロー アプリはセットアップ イベントで利用できるすべてのデータにアクセスできます。また、追加の XPS データを、未処理のバイトのストリームまたはオブジェクト モデルとして直接読み取ることもできます。</span><span class="sxs-lookup"><span data-stu-id="3f830-149">In the handler for this event, the workflow app can access all of the data available to the setup event and can additionally read the XPS data directly, either as a stream of raw bytes or as an object model.</span></span> <span data-ttu-id="3f830-150">XPS データへのアクセスによって、UI では印刷プレビュー サービスを提供し、ワークフロー アプリがデータに対して実行する処理についての追加情報をユーザーに提供することができます。</span><span class="sxs-lookup"><span data-stu-id="3f830-150">Access to the XPS data allows the UI to provide print preview services and to provide additional information to the user about the operations that the workflow app will execute on the data.</span></span> 

<span data-ttu-id="3f830-151">このイベント ハンドラーの一環として、ワークフロー アプリでは、ユーザーとのやり取りを継続する場合に遅延オブジェクトを取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f830-151">As part of this event handler, the workflow app must acquire a deferral object if it will continue to interact with the user.</span></span> <span data-ttu-id="3f830-152">遅延を使用しないと、印刷システムでは、**XpsDataAvailable** イベント ハンドラーが終了したとき、またはこのハンドラーで非同期メソッドが呼び出されたときに UI タスクが完了したと見なされます。</span><span class="sxs-lookup"><span data-stu-id="3f830-152">Without a deferral, the print system will consider the UI task complete when the **XpsDataAvailable** event handler exits or when it calls an async method.</span></span> <span data-ttu-id="3f830-153">アプリがユーザーと UI とのやり取りから必要な情報をすべて収集したときに、アプリでは遅延を終了し、印刷システムが次の処理に進めるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f830-153">When the app has gathered all required information from the user's interaction with the UI, it should complete the deferral so that the print system can then advance.</span></span>

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

<span data-ttu-id="3f830-154">また、イベント引数によって公開される **[PrintWorkflowSubmittedOperation](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsubmittedoperation)** インスタンスでは、印刷ジョブを取り消したり、印刷ジョブは成功したが出力の印刷ジョブが必要ないことを指定したりするためのオプションが提供されます。</span><span class="sxs-lookup"><span data-stu-id="3f830-154">Additionally, the **[PrintWorkflowSubmittedOperation](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsubmittedoperation)** instance exposed by the event args provides the option to cancel the print job or to indicate that the job is successful but that no output print job will be needed.</span></span> <span data-ttu-id="3f830-155">これは、**[PrintWorkflowSubmittedStatus](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsubmittedstatus)** 値を使用して **[Complete](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsubmittedoperation.Complete)** メソッドを呼び出すことで実行されます。</span><span class="sxs-lookup"><span data-stu-id="3f830-155">This is done by calling the **[Complete](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsubmittedoperation.Complete)** method with a **[PrintWorkflowSubmittedStatus](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsubmittedstatus)** value.</span></span>

> [!NOTE]
> <span data-ttu-id="3f830-156">ワークフロー アプリで印刷ジョブを取り消す場合は、ジョブが取り消された理由を示すトースト通知を提供することを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3f830-156">If the workflow app cancels the print job, it is highly recommended that it provide a toast notification indicating why the job was cancelled.</span></span> 


## <a name="do-final-background-work-on-the-print-content"></a><span data-ttu-id="3f830-157">印刷コンテンツに対する最終的なバックグラウンド処理の実行</span><span class="sxs-lookup"><span data-stu-id="3f830-157">Do final background work on the print content</span></span>

<span data-ttu-id="3f830-158">UI で **PrintTaskXpsDataAvailable** イベントの遅延が完了した場合 (または UI の手順が省略された場合)、印刷システムではバックグラウンド タスク用の **[Submitted](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowbackgroundsession.Submitted)** イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="3f830-158">Once the UI has completed the deferral in the **PrintTaskXpsDataAvailable** event (or if the UI step was bypassed), the print system will fire the **[Submitted](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowbackgroundsession.Submitted)** event for the background task.</span></span> <span data-ttu-id="3f830-159">このイベントのハンドラーでは、ワークフロー アプリは **XpsDataAvailable** イベントで提供されるものと同じすべてのデータにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="3f830-159">In the handler for this event, the workflow app can get access to all of the same data provided by the **XpsDataAvailable** event.</span></span> <span data-ttu-id="3f830-160">ただし、これまでのイベントとは異なり、**Submitted** は **[PrintWorkflowTarget](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowtarget)** インスタンスを使用して、最終的な印刷ジョブのコンテンツに対する*書き込み*アクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="3f830-160">However, unlike any of the previous events, **Submitted** also provides *write* access to the final print job content through a **[PrintWorkflowTarget](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowtarget)** instance.</span></span> 

<span data-ttu-id="3f830-161">最終的な印刷で必要となるデータをスプールする場合に使用されるオブジェクトは、ソース データが未処理のバイトのストリームとしてアクセスされるのか、XPS オブジェクト モデルとしてアクセスされるのかによって異なります。</span><span class="sxs-lookup"><span data-stu-id="3f830-161">The object that is used to spool the data for final printing depends on whether the source data is accessed as a raw byte stream or as the XPS object model.</span></span> <span data-ttu-id="3f830-162">ワークフロー アプリがバイト ストリームを介してソース データにアクセスするときは、最終的なジョブ データを書き込むために、出力のバイト ストリームが提供されます。</span><span class="sxs-lookup"><span data-stu-id="3f830-162">When the workflow app accesses the source data through a byte stream, an output byte stream is provided to write the final job data to.</span></span> <span data-ttu-id="3f830-163">ワークフロー アプリがオブジェクト モデルを介してソース データにアクセスするときは、オブジェクトを出力ジョブに書き込むために、ドキュメント ライターが提供されます。</span><span class="sxs-lookup"><span data-stu-id="3f830-163">When the workflow app accesses the source data through the object model, a document writer is provided to write objects to the output job.</span></span> <span data-ttu-id="3f830-164">どちらの場合も、ワークフロー アプリでは、すべてのソース データを読み取り、必要なデータを変更し、変更されたデータを出力ターゲットに書き込む必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f830-164">In either case, the workflow app should read all of the source data, modify any data required, and write the modified data to the output target.</span></span>

<span data-ttu-id="3f830-165">バックグラウンド タスクでデータの書き込みが完了したら、対応する **PrintWorkflowSubmittedOperation** オブジェクトで **Complete** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="3f830-165">When the background task finishes writing the data, it should call **Complete** on the corresponding **PrintWorkflowSubmittedOperation** object.</span></span> <span data-ttu-id="3f830-166">ワークフロー アプリでこの手順が完了し、**Submitted** イベント ハンドラーが終了すると、ワークフロー セッションが閉じられ、ユーザーは、標準的な印刷ダイアログで最終的な印刷ジョブの状態を監視できます。</span><span class="sxs-lookup"><span data-stu-id="3f830-166">Once the workflow app completes this step and the **Submitted** event handler exits, the workflow session is closed and the user can monitor the status of the final print job through the standard print dialogs.</span></span>

## <a name="final-steps"></a><span data-ttu-id="3f830-167">最後の手順</span><span class="sxs-lookup"><span data-stu-id="3f830-167">Final steps</span></span>

### <a name="register-the-print-workflow-app-to-the-printer"></a><span data-ttu-id="3f830-168">印刷ワークフロー アプリをプリンターに登録する</span><span class="sxs-lookup"><span data-stu-id="3f830-168">Register the print workflow app to the printer</span></span>

<span data-ttu-id="3f830-169">ワークフロー アプリは、MSDA の場合と同じ種類のメタデータ ファイル送信を使用するプリンターに関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="3f830-169">Your workflow app is associated with a printer using the same type of metadata file submission as for WSDAs.</span></span> <span data-ttu-id="3f830-170">実際には、1 つの UWP アプリケーションが、ワークフロー アプリと、印刷タスクの設定機能を提供する MSDA の両方として機能することができます。</span><span class="sxs-lookup"><span data-stu-id="3f830-170">In fact, a single UWP application can act as both a workflow app and a WSDA that provides print task settings functionality.</span></span> <span data-ttu-id="3f830-171">関連する「[MSDA steps for creating the metadata association](https://docs.microsoft.com/windows-hardware/drivers/devapps/step-2--create-device-metadata)」(メタデータの関連付けを作成するための MSDA の手順) に従ってください。</span><span class="sxs-lookup"><span data-stu-id="3f830-171">Follow the corresponding [WSDA steps for creating the metadata association](https://docs.microsoft.com/windows-hardware/drivers/devapps/step-2--create-device-metadata).</span></span>

<span data-ttu-id="3f830-172">相違点は、MSDA はユーザーに対して自動的にアクティブ化されますが (関連付けられているデバイスでユーザーが印刷を実行すると、アプリは常に起動されます)、ワークフロー アプリは自動的にはアクティブ化されないことです。</span><span class="sxs-lookup"><span data-stu-id="3f830-172">The difference is that while WSDAs are automatically activated for the user (the app will always launch when that user prints on the associated device), workflow apps are not.</span></span> <span data-ttu-id="3f830-173">これらのアプリに対しては、それぞれ別のポリシーを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f830-173">They have a separate policy that must be set.</span></span>

### <a name="set-the-workflow-apps-policy"></a><span data-ttu-id="3f830-174">ワークフロー アプリのポリシーの設定</span><span class="sxs-lookup"><span data-stu-id="3f830-174">Set the workflow app's policy</span></span>
<span data-ttu-id="3f830-175">ワークフロー アプリのポリシーは、ワークフロー アプリを実行するデバイス上で PowerShell コマンドによって設定されます。</span><span class="sxs-lookup"><span data-stu-id="3f830-175">The workflow app policy is set by Powershell commands on the device that is to run the workflow app.</span></span> <span data-ttu-id="3f830-176">Set-Printer、Add-Printer (既存のポート)、Add-Printer (新しい WSD ポート) の各コマンドを、ワークフロー ポリシーの設定を許可するように変更します。</span><span class="sxs-lookup"><span data-stu-id="3f830-176">The Set-Printer, Add-Printer (existing port) and Add-Printer (new WSD port) commands will be modified to allow Workflow policies to be set.</span></span> 
* `Disabled`<span data-ttu-id="3f830-177">: ワークフロー アプリはアクティブ化されません。</span><span class="sxs-lookup"><span data-stu-id="3f830-177">: Workflow apps will not be activated.</span></span>
* `Uninitialized`<span data-ttu-id="3f830-178">: ワークフロー アプリは、ワークフロー DCA がシステムにインストールされている場合にアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="3f830-178">: Workflow apps will be activated if the Workflow DCA is installed in the system.</span></span> <span data-ttu-id="3f830-179">アプリがインストールされていない場合は、印刷が引き続き実行されます。</span><span class="sxs-lookup"><span data-stu-id="3f830-179">If the app is not installed, printing will still proceed.</span></span> 
* `Enabled`<span data-ttu-id="3f830-180">: ワークフロー コントラクトは、ワークフロー DCA がシステムにインストールされている場合にアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="3f830-180">: Workflow contract will be activated if the Workflow DCA is installed in the system.</span></span> <span data-ttu-id="3f830-181">アプリがインストールされていない場合は、印刷は失敗します。</span><span class="sxs-lookup"><span data-stu-id="3f830-181">If the app is not installed, printing will fail.</span></span> 

<span data-ttu-id="3f830-182">次のコマンドは、指定されたプリンターでワークフロー アプリを必須のアプリにします。</span><span class="sxs-lookup"><span data-stu-id="3f830-182">The following command makes the workflow app required on the specified printer.</span></span>
```Powershell
Set-Printer –Name "Microsoft XPS Document Writer" -WorkflowPolicy On
```

<span data-ttu-id="3f830-183">ローカル ユーザーは、このポリシーをローカル プリンタで実行することができます。企業での実装を目的とする場合、プリンターの管理者は、このポリシーをプリント サーバーで実行することができます。</span><span class="sxs-lookup"><span data-stu-id="3f830-183">A local user can run this policy on a local printer, or, for enterprise implementation, the printer administrator can run this policy on the Print Server.</span></span> <span data-ttu-id="3f830-184">実行後、ポリシーはすべてのクライアント接続に対して同期されます。</span><span class="sxs-lookup"><span data-stu-id="3f830-184">The policy will then be synchronized to all client connections.</span></span> <span data-ttu-id="3f830-185">プリンターの管理者は、新しいプリンターを追加するたびにこのポリシーを使用できます。</span><span class="sxs-lookup"><span data-stu-id="3f830-185">The printer admin can use this policy whenever a new printer is added.</span></span>

## <a name="see-also"></a><span data-ttu-id="3f830-186">関連項目</span><span class="sxs-lookup"><span data-stu-id="3f830-186">See also</span></span>

[<span data-ttu-id="3f830-187">ワークフロー アプリのサンプル</span><span class="sxs-lookup"><span data-stu-id="3f830-187">Workflow app sample</span></span>](https://github.com/Microsoft/print-oem-samples)

[<span data-ttu-id="3f830-188">Windows.Graphics.Printing.Workflow 名前空間</span><span class="sxs-lookup"><span data-stu-id="3f830-188">Windows.Graphics.Printing.Workflow namespace</span></span>](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow)


