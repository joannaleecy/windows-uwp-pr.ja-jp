---
author: TylerMSFT
title: バックグラウンド タスクのデバッグ
description: バックグラウンド タスクをデバッグする方法について説明します。バックグラウンド タスクのアクティブ化のほか、Windows イベント ログでのデバッグ トレースなどについて取り上げます。
ms.assetid: 24E5AC88-1FD3-46ED-9811-C7E102E01E9C
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, バック グラウンド タスク
ms.localizationpriority: medium
ms.openlocfilehash: f68c20a545e09d81912b8ef9a97a0ab0237ed0e0
ms.sourcegitcommit: 00d27738325d6db5b5e481911ae7fac0711b05eb
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/07/2018
ms.locfileid: "3662524"
---
# <a name="debug-a-background-task"></a><span data-ttu-id="dcead-104">バックグラウンド タスクのデバッグ</span><span class="sxs-lookup"><span data-stu-id="dcead-104">Debug a background task</span></span>


**<span data-ttu-id="dcead-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="dcead-105">Important APIs</span></span>**
-   [<span data-ttu-id="dcead-106">Windows.ApplicationModel.Background</span><span class="sxs-lookup"><span data-stu-id="dcead-106">Windows.ApplicationModel.Background</span></span>](https://msdn.microsoft.com/library/windows/apps/br224847)

<span data-ttu-id="dcead-107">バックグラウンド タスクをデバッグする方法について説明します。バックグラウンド タスクのアクティブ化のほか、Windows イベント ログでのデバッグ トレースなどについて取り上げます。</span><span class="sxs-lookup"><span data-stu-id="dcead-107">Learn how to debug a background task, including background task activation and debug tracing in the Windows event log.</span></span>

## <a name="debugging-out-of-process-vs-in-process-background-tasks"></a><span data-ttu-id="dcead-108">アウトプロセス バックグラウンド タスクのデバッグとインプロセス バックグラウンド タスクのデバッグ</span><span class="sxs-lookup"><span data-stu-id="dcead-108">Debugging out-of-process vs. in-process background tasks</span></span>
<span data-ttu-id="dcead-109">このトピックでは主に、ホスト アプリとは別のプロセスで実行されているバックグラウンド タスクについて扱います。</span><span class="sxs-lookup"><span data-stu-id="dcead-109">This topic primarily addresses background tasks that run in a separate process than the host app.</span></span> <span data-ttu-id="dcead-110">インプロセス バックグラウンド タスクをデバッグする場合、別個のバックグラウンド タスク プロジェクト タスクはいらず、**OnBackgroundActivated()** (インプロセス バックグラウンド コードが実行される場所) にブレークポイントを設定できます。実行するバックグラウンド コードをトリガーする手順については、以下の「[バックグラウンド タスク コードをデバッグするためバックグラウンド タスクを手動でトリガー](#trigger-background-tasks-manually-to-debug-background-task-code)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dcead-110">If you are debugging an in-process background task, then you won't have a separate background task project and can  set a breakpoint on **OnBackgroundActivated()** (where your in-process background code runs) and see step 2 in [Trigger background tasks manually to debug background task code](#trigger-background-tasks-manually-to-debug-background-task-code), below, for instructions about how to trigger your background code to execute.</span></span>

## <a name="make-sure-the-background-task-project-is-set-up-correctly"></a><span data-ttu-id="dcead-111">バックグラウンド タスク プロジェクトが正しく設定されていることを確認</span><span class="sxs-lookup"><span data-stu-id="dcead-111">Make sure the background task project is set up correctly</span></span>

<span data-ttu-id="dcead-112">このトピックは、デバッグ対象のバックグラウンド タスクを備えたアプリが既に手元にあることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="dcead-112">This topic assumes that you already have an existing app with a background task to debug.</span></span> <span data-ttu-id="dcead-113">以下の内容は、アウトプロセスで実行されるバックグラウンド タスクに固有の内容であり、インプロセス バックグラウンド タスクには適用されません。</span><span class="sxs-lookup"><span data-stu-id="dcead-113">The following is specific to background tasks that run out-of-process and does not apply to in-process background tasks.</span></span>

-   <span data-ttu-id="dcead-114">C# と C++ の場合、メイン プロジェクトがバックグラウンド タスク プロジェクトを参照していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="dcead-114">In C# and C++, make sure the main project references the background task project.</span></span> <span data-ttu-id="dcead-115">この参照が行われない場合、アプリ パッケージにバックグラウンド タスクが含まれていない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="dcead-115">If this reference is not in place, the background task won't be included in the app package.</span></span>
-   <span data-ttu-id="dcead-116">C# と C++ の場合、バックグラウンド タスク プロジェクトの **Output type** が "Windows ランタイム コンポーネント" になっていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="dcead-116">In C# and C++, make sure the **Output type** of the background task project is "Windows Runtime Component".</span></span>
-   <span data-ttu-id="dcead-117">バック グラウンド クラスは、パッケージ マニフェストのエントリ ポイント属性で宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dcead-117">The background class must be declared in the entry point attribute in the package manifest.</span></span>

## <a name="trigger-background-tasks-manually-to-debug-background-task-code"></a><span data-ttu-id="dcead-118">バックグラウンド タスク コードをデバッグするためバックグラウンド タスクを手動でトリガー</span><span class="sxs-lookup"><span data-stu-id="dcead-118">Trigger background tasks manually to debug background task code</span></span>

<span data-ttu-id="dcead-119">バックグラウンド タスクは、Microsoft Visual Studio を使って手動でトリガーできます。</span><span class="sxs-lookup"><span data-stu-id="dcead-119">Background tasks can be triggered manually through Microsoft Visual Studio.</span></span> <span data-ttu-id="dcead-120">その後で、コードをステップ実行してデバッグできます。</span><span class="sxs-lookup"><span data-stu-id="dcead-120">Then you can step through the code and debug it.</span></span>

1.  <span data-ttu-id="dcead-121">C# では、バックグラウンド クラスの Run メソッドにブレークポイントを置き (インプロセス バックグラウンド タスクの場合は、App.OnBackgroundActivated() にブレークポイントを置きます)、[**System.Diagnostics**](https://msdn.microsoft.com/library/windows/apps/xaml/hh441592.aspx) を使ってデバッグ出力を記述します。</span><span class="sxs-lookup"><span data-stu-id="dcead-121">In C#, put a breakpoint in the Run method of the background class (for in-process background tasks put the breakpoint in App.OnBackgroundActivated()), and/or write debugging output by using [**System.Diagnostics**](https://msdn.microsoft.com/library/windows/apps/xaml/hh441592.aspx).</span></span>

    <span data-ttu-id="dcead-122">C++ では、バックグラウンド クラスの Run 関数にブレークポイントを置き (インプロセス バックグラウンド タスクの場合は、App.OnBackgroundActivated() にブレークポイントを置きます)、[**OutputDebugString**](https://msdn.microsoft.com/library/windows/desktop/aa363362) を使ってデバッグ出力を記述します。</span><span class="sxs-lookup"><span data-stu-id="dcead-122">In C++, put a breakpoint in the Run function of the background class (for in-process background tasks put the breakpoint in App.OnBackgroundActivated()), and/or write debugging output by using [**OutputDebugString**](https://msdn.microsoft.com/library/windows/desktop/aa363362).</span></span>

2.  <span data-ttu-id="dcead-123">デバッガーでアプリケーションを実行し、**[ライフサイクル イベント]** ツール バーを使ってバックグラウンド タスクをトリガーします。</span><span class="sxs-lookup"><span data-stu-id="dcead-123">Run your application in the debugger and then trigger the background task using the **Lifecycle Events** toolbar.</span></span> <span data-ttu-id="dcead-124">このドロップダウンには、Visual Studio でアクティブ化できるバックグラウンド タスクの名前が表示されます。</span><span class="sxs-lookup"><span data-stu-id="dcead-124">This drop down shows the names of the background tasks that can be activated by Visual Studio.</span></span>

    <span data-ttu-id="dcead-125">この機能を使うには、バックグラウンド タスクが既に登録されていて、トリガーを待機する状態になっていることが必要です。</span><span class="sxs-lookup"><span data-stu-id="dcead-125">For this to work, the background task must already be registered and it must still be waiting for the trigger.</span></span> <span data-ttu-id="dcead-126">たとえば、1 回限りの TimeTrigger に対してバックグラウンド タスクを登録した場合、そのトリガーが起動された後に Visual Studio からそのタスクを起動しても何も起こりません。</span><span class="sxs-lookup"><span data-stu-id="dcead-126">For example, if a background task was registered with a one-shot TimeTrigger and that trigger has already fired, launching the task through Visual Studio will have no effect.</span></span>

> [!Note]
> <span data-ttu-id="dcead-127">次のトリガーを使ったバックグラウンド タスクを、[**アプリケーション トリガー**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.applicationtrigger.aspx)、[**MediaProcessing トリガー**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.mediaprocessingtrigger.aspx)、[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032)、[**PushNotificationTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700543)、[**SmsReceived**](https://msdn.microsoft.com/library/windows/apps/br224839) トリガー型の [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224838) を使ったバックグラウンド タスク、という方法でアクティブ化することはできません。</span><span class="sxs-lookup"><span data-stu-id="dcead-127">Background tasks using the following triggers cannot be activated in this manner: [**Application trigger**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.applicationtrigger.aspx), [**MediaProcessing trigger**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.mediaprocessingtrigger.aspx),  [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032),  [**PushNotificationTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700543), and background tasks using a [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224838) with the [**SmsReceived**](https://msdn.microsoft.com/library/windows/apps/br224839) trigger type.</span></span>  
> <span data-ttu-id="dcead-128">**Application trigger** と **MediaProcessingTrigger** は、`trigger.RequestAsync()` を使ってコードで手動通知できます。</span><span class="sxs-lookup"><span data-stu-id="dcead-128">**Application trigger** and **MediaProcessingTrigger** can be signaled manually in code with `trigger.RequestAsync()`.</span></span>

![バック グラウンド タスクのデバッグ](images/debugging-activation.png)

3.  <span data-ttu-id="dcead-130">バックグラウンド タスクがアクティブになると、デバッガーがアタッチされて、デバッグ出力が VS に表示されます。</span><span class="sxs-lookup"><span data-stu-id="dcead-130">When the background task activates, the debugger will attach to it and display debug output in VS.</span></span>

## <a name="debug-background-task-activation"></a><span data-ttu-id="dcead-131">バックグラウンド タスクのアクティブ化のデバッグ</span><span class="sxs-lookup"><span data-stu-id="dcead-131">Debug background task activation</span></span>

> [!NOTE]
> <span data-ttu-id="dcead-132">このセクションは、アウトプロセスで実行されるバックグラウンド タスクに固有の内容であり、インプロセス バックグラウンド タスクには適用されません。</span><span class="sxs-lookup"><span data-stu-id="dcead-132">This section is specific to background tasks the run out-of-process and does not apply to in-process background tasks.</span></span>

<span data-ttu-id="dcead-133">バックグラウンド タスクのアクティブ化は、次の 3 つの点に依存します。</span><span class="sxs-lookup"><span data-stu-id="dcead-133">Background task activation depends on three things:</span></span>

-   <span data-ttu-id="dcead-134">バック グラウンド タスク クラスの名前と名前空間</span><span class="sxs-lookup"><span data-stu-id="dcead-134">The name and namespace of the background task class</span></span>
-   <span data-ttu-id="dcead-135">パッケージ マニフェストで指定されたエントリ ポイント属性</span><span class="sxs-lookup"><span data-stu-id="dcead-135">The entry point attribute specified in the package manifest</span></span>
-   <span data-ttu-id="dcead-136">バックグラウンド タスクの登録時にアプリによって指定されたエントリ ポイント</span><span class="sxs-lookup"><span data-stu-id="dcead-136">The entry point specified by your app when registering the background task</span></span>

1.  <span data-ttu-id="dcead-137">Visual Studio を使い、バックグラウンド タスクのエントリ ポイントを確認します。</span><span class="sxs-lookup"><span data-stu-id="dcead-137">Use Visual Studio to note the entry point of the background task:</span></span>

    -   <span data-ttu-id="dcead-138">C# と C++ の場合、バックグラウンド タスク プロジェクトで指定されたバックグラウンド タスク クラスの名前と名前空間を確認します。</span><span class="sxs-lookup"><span data-stu-id="dcead-138">In C# and C++, note the name and namespace of the background task class specified in the background task project.</span></span>

2.  <span data-ttu-id="dcead-139">マニフェスト デザイナーを使い、バックグラウンド タスクがパッケージ マニフェストで正しく宣言されているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="dcead-139">Use the manifest designer to check that the background task is correctly declared in the package manifest:</span></span>

    -   <span data-ttu-id="dcead-140">C# と C++ の場合、エントリ ポイント属性が、クラス名の前のバックグラウンド タスク名前空間と一致している必要があります。</span><span class="sxs-lookup"><span data-stu-id="dcead-140">In C# and C++, the entry point attribute must match the background task namespace followed by the class name.</span></span> <span data-ttu-id="dcead-141">たとえば、RuntimeComponent1.MyBackgroundTask のようになります。</span><span class="sxs-lookup"><span data-stu-id="dcead-141">For example: RuntimeComponent1.MyBackgroundTask.</span></span>
    -   <span data-ttu-id="dcead-142">タスクと共に使われるトリガー タイプがすべて指定されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="dcead-142">All the trigger type(s) used with the task must also be specified.</span></span>
    -   <span data-ttu-id="dcead-143">[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) または [**PushNotificationTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700543) を使う場合以外、実行可能ファイルを指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="dcead-143">The executable MUST NOT be specified unless you are using the [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) or [**PushNotificationTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700543).</span></span>

3.  <span data-ttu-id="dcead-144">Windows のみ。</span><span class="sxs-lookup"><span data-stu-id="dcead-144">Windows only.</span></span> <span data-ttu-id="dcead-145">バックグラウンド タスクをアクティブ化するために Windows で使われるエントリ ポイントを確認するには、デバッグ トレースを有効にして Windows イベント ログを使います。</span><span class="sxs-lookup"><span data-stu-id="dcead-145">To see the entry point used by Windows to activate the background task, enable debug tracing and use the Windows event log.</span></span>

    <span data-ttu-id="dcead-146">この手順を実行し、その結果イベント ログにバックグラウンド タスクの間違ったエントリ ポイントまたはトリガーが表示される場合は、アプリにバックグラウンド タスクが正しく登録されていません。</span><span class="sxs-lookup"><span data-stu-id="dcead-146">If you follow this procedure and the event log shows the wrong entry point or trigger for the background task, your app is not registering the background task correctly.</span></span> <span data-ttu-id="dcead-147">このタスクのヘルプが必要な場合は、「[バックグラウンド タスクの登録](register-a-background-task.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dcead-147">For help with this task see [Register a background task](register-a-background-task.md).</span></span>

    1.  <span data-ttu-id="dcead-148">スタート画面に移動して eventvwr.exe を検索し、イベント ビューアーを開きます。</span><span class="sxs-lookup"><span data-stu-id="dcead-148">Open event viewer by going to the Start screen and searching for eventvwr.exe.</span></span>
    2.  <span data-ttu-id="dcead-149">**アプリケーション**とサービス ログ -&gt; **Microsoft**  - &gt; **Windows**  - &gt; 、イベント ビューアーで**BackgroundTaskInfrastructure**します。</span><span class="sxs-lookup"><span data-stu-id="dcead-149">Go to **Application and Services Logs** -&gt; **Microsoft** -&gt; **Windows** -&gt; **BackgroundTaskInfrastructure** in the event viewer.</span></span>
    3.  <span data-ttu-id="dcead-150">**ビュー**を選択操作ウィンドウで -&gt; **を表示する分析およびデバッグ ログ**診断ログを有効にします。</span><span class="sxs-lookup"><span data-stu-id="dcead-150">In the actions pane, select **View** -&gt; **Show Analytic and Debug Logs** to enable the diagnostic logging.</span></span>
    4.  <span data-ttu-id="dcead-151">**診断ログ**を選び、**[ログの有効化]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="dcead-151">Select the **Diagnostic log** and click **Enable Log**.</span></span>
    5.  <span data-ttu-id="dcead-152">次に、アプリを使ってバックグラウンド タスクの登録とアクティブ化をもう一度試します。</span><span class="sxs-lookup"><span data-stu-id="dcead-152">Now try using your app to register and activate the background task again.</span></span>
    6.  <span data-ttu-id="dcead-153">診断ログで、詳しいエラー情報を確認します。</span><span class="sxs-lookup"><span data-stu-id="dcead-153">View the diagnostic logs for detailed error information.</span></span> <span data-ttu-id="dcead-154">このログには、バックグラウンド タスクに登録されたエントリ ポイントが含まれます。</span><span class="sxs-lookup"><span data-stu-id="dcead-154">This will include the entry point registered for the background task.</span></span>

![イベント ビューアーでバックグラウンド タスクのデバッグ情報を表示](images/event-viewer.png)

## <a name="background-tasks-and-visual-studio-package-deployment"></a><span data-ttu-id="dcead-156">バックグラウンド タスクと Visual Studio パッケージの展開</span><span class="sxs-lookup"><span data-stu-id="dcead-156">Background tasks and Visual Studio package deployment</span></span>

<span data-ttu-id="dcead-157">バックグラウンド タスクを使ったアプリが Visual Studio を使って展開され、その後、マニフェスト デザイナーで指定されたバージョン (メジャー バージョンとマイナー バージョン、またはそのどちらか一方) が更新された場合、以後、Visual Studio を使ってそのアプリを再展開すると、アプリのバックグラウンド タスクが停止することがあります。</span><span class="sxs-lookup"><span data-stu-id="dcead-157">If an app that uses background tasks is deployed using Visual Studio, and the version (major and/or minor) specified in Manifest Designer is then updated, subsequently re-deploying the app with Visual Studio may cause the app’s background tasks to stall.</span></span> <span data-ttu-id="dcead-158">これは、次のようにして対処できます。</span><span class="sxs-lookup"><span data-stu-id="dcead-158">This can be remedied as follows:</span></span>

-   <span data-ttu-id="dcead-159">更新したアプリを (Visual Studio ではなく) Windows PowerShell を使って展開します。パッケージと一緒に生成されるスクリプトを実行してください。</span><span class="sxs-lookup"><span data-stu-id="dcead-159">Use Windows PowerShell to deploy the updated app (instead of Visual Studio) by running the script generated alongside the package.</span></span>
-   <span data-ttu-id="dcead-160">既に Visual Studio でアプリを展開したことによってアプリのバックグラウンド タスクが停止している場合は、再起動するか、いったんログオフしてからログインし直し、アプリのバックグラウンド タスクをもう一度作動させます。</span><span class="sxs-lookup"><span data-stu-id="dcead-160">If you already deployed the app using Visual Studio and its background tasks are now stalled, reboot or log off/log in to get the app’s background tasks working again.</span></span>
-   <span data-ttu-id="dcead-161">C# プロジェクトでは、"パッケージを常に再インストール" というデバッグ オプションを選ぶことで、この問題を回避することができます。</span><span class="sxs-lookup"><span data-stu-id="dcead-161">You can select the "Always re-install my package" debugging option to avoid this in C# projects.</span></span>
-   <span data-ttu-id="dcead-162">展開用にアプリが最終確定するのを待ってパッケージのバージョンをインクリメントします (デバッグ中は変更しない)。</span><span class="sxs-lookup"><span data-stu-id="dcead-162">Wait until the app is ready for final deployment to increment the package version (don’t change it while debugging).</span></span>

## <a name="remarks"></a><span data-ttu-id="dcead-163">注釈</span><span class="sxs-lookup"><span data-stu-id="dcead-163">Remarks</span></span>

-   <span data-ttu-id="dcead-164">バックグラウンド タスクは、同じバックグラウンド タスクが登録されていないことをアプリ側で必ずチェックしたうえで登録してください。</span><span class="sxs-lookup"><span data-stu-id="dcead-164">Make sure your app checks for existing background task registrations before registering the background task again.</span></span> <span data-ttu-id="dcead-165">同じバックグラウンド タスクを重複して登録すると、1 回のトリガーにつきバックグラウンド タスクが複数回実行され、予期しない結果を招きます。</span><span class="sxs-lookup"><span data-stu-id="dcead-165">Multiple registrations of the same background task can cause unexpected results by running the background task more than once each time it is triggered.</span></span>
-   <span data-ttu-id="dcead-166">バックグラウンド タスクがロック画面へのアクセスを必要とする場合は、バックグラウンド タスクをデバッグする前にロック画面にアプリを配置してください。</span><span class="sxs-lookup"><span data-stu-id="dcead-166">If the background task requires lock screen access make sure to put the app on the lock screen before trying to debug the background task.</span></span> <span data-ttu-id="dcead-167">ロック画面対応アプリのマニフェスト オプションを指定する方法については、「[アプリケーション マニフェストでのバックグラウンド タスクの宣言](declare-background-tasks-in-the-application-manifest.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dcead-167">For info on specifying manifest options for lock screen-capable apps, see [Declare background tasks in the application manifest](declare-background-tasks-in-the-application-manifest.md).</span></span>
-   <span data-ttu-id="dcead-168">バックグラウンド タスクの登録パラメーターは登録時に検証されます。</span><span class="sxs-lookup"><span data-stu-id="dcead-168">Background task registration parameters are validated at the time of registration.</span></span> <span data-ttu-id="dcead-169">いずれかの登録パラメーターが有効でない場合は、エラーが返されます。</span><span class="sxs-lookup"><span data-stu-id="dcead-169">An error is returned if any of the registration parameters are invalid.</span></span> <span data-ttu-id="dcead-170">バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。</span><span class="sxs-lookup"><span data-stu-id="dcead-170">Ensure that your app gracefully handles scenarios where background task registration fails - if instead your app depends on having a valid registration object after attempting to register a task, it may crash.</span></span>

<span data-ttu-id="dcead-171">VS を使って、バック グラウンド タスクのデバッグについて詳しくは、以下を参照してください。[をトリガーする方法、中断、再開、および UWP アプリでイベントをバック グラウンド](https://msdn.microsoft.com/library/windows/apps/xaml/hh974425.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="dcead-171">For more info on using VS to debug a background task see [How to trigger suspend, resume, and background events in UWP apps](https://msdn.microsoft.com/library/windows/apps/xaml/hh974425.aspx).</span></span>

## <a name="related-topics"></a><span data-ttu-id="dcead-172">関連トピック</span><span class="sxs-lookup"><span data-stu-id="dcead-172">Related topics</span></span>

* [<span data-ttu-id="dcead-173">アウトプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="dcead-173">Create and register an out-of-process background task</span></span>](create-and-register-a-background-task.md)
* [<span data-ttu-id="dcead-174">インプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="dcead-174">Create and register an in-process background task</span></span>](create-and-register-an-inproc-background-task.md)
* [<span data-ttu-id="dcead-175">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="dcead-175">Register a background task</span></span>](register-a-background-task.md)
* [<span data-ttu-id="dcead-176">アプリケーション マニフェストでのバックグラウンド タスクの宣言</span><span class="sxs-lookup"><span data-stu-id="dcead-176">Declare background tasks in the application manifest</span></span>](declare-background-tasks-in-the-application-manifest.md)
* [<span data-ttu-id="dcead-177">バックグラウンド タスクのガイドライン</span><span class="sxs-lookup"><span data-stu-id="dcead-177">Guidelines for background tasks</span></span>](guidelines-for-background-tasks.md)
* [<span data-ttu-id="dcead-178">トリガーする方法、中断、再開、およびバック グラウンドで UWP アプリのイベント</span><span class="sxs-lookup"><span data-stu-id="dcead-178">How to trigger suspend, resume, and background events in UWP apps</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh974425.aspx)
* [<span data-ttu-id="dcead-179">Visual Studio のコード分析による UWP アプリのコードの品質の分析</span><span class="sxs-lookup"><span data-stu-id="dcead-179">Analyzing the code quality of UWP apps with Visual Studio code analysis</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh441471.aspx)

 

 
