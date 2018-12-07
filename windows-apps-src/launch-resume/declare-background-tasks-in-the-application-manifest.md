---
title: アプリケーション マニフェストでのバックグラウンド タスクの宣言
description: アプリ マニフェストでバックグラウンド タスクを拡張機能として宣言し、バックグラウンド タスクを使うことができるようにします。
ms.assetid: 6B4DD3F8-3C24-4692-9084-40999A37A200
ms.date: 02/08/2017
ms.topic: article
keywords: バック グラウンド タスクの windows 10, uwp,
ms.localizationpriority: medium
ms.openlocfilehash: 4527cface4681bf4866249c6398d43e6af782725
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8779872"
---
# <a name="declare-background-tasks-in-the-application-manifest"></a><span data-ttu-id="9c1ab-104">アプリケーション マニフェストでのバックグラウンド タスクの宣言</span><span class="sxs-lookup"><span data-stu-id="9c1ab-104">Declare background tasks in the application manifest</span></span>




**<span data-ttu-id="9c1ab-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="9c1ab-105">Important APIs</span></span>**

-   [**<span data-ttu-id="9c1ab-106">BackgroundTasks スキーマ</span><span class="sxs-lookup"><span data-stu-id="9c1ab-106">BackgroundTasks Schema</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224794)
-   [**<span data-ttu-id="9c1ab-107">Windows.ApplicationModel.Background</span><span class="sxs-lookup"><span data-stu-id="9c1ab-107">Windows.ApplicationModel.Background</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224847)

<span data-ttu-id="9c1ab-108">アプリ マニフェストでバックグラウンド タスクを拡張機能として宣言し、バックグラウンド タスクを使うことができるようにします。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-108">Enable the use of background tasks by declaring them as extensions in the app manifest.</span></span>

> [!Important]
>  <span data-ttu-id="9c1ab-109">この記事は、アウトプロセスのバック グラウンド タスクに固有です。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-109">This article is specific to out-of-process background tasks.</span></span> <span data-ttu-id="9c1ab-110">インプロセスのバックグラウンド タスクは、マニフェストで宣言されていません。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-110">In-process background tasks are not declared in the manifest.</span></span>

<span data-ttu-id="9c1ab-111">アウトプロセスのバックグラウンド タスクはアプリ マニフェストで宣言されている必要があります。このようにしないと、アプリはバックグラウンド タスクを登録できません (例外がスローされます)。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-111">Out-of-process background tasks must be declared in the app manifest or else your app will not be able to register them (an exception will be thrown).</span></span> <span data-ttu-id="9c1ab-112">また、認定に合格するには、アプリケーション マニフェストでアウトプロセスのバックグラウンド タスクを宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-112">Additionally, out-of-process background tasks must be declared in the application manifest to pass certification.</span></span>

<span data-ttu-id="9c1ab-113">このトピックでは、1 つ以上のバックグラウンド タスク クラスが作られていて、少なくとも 1 つのトリガーに応答して実行されるようにアプリで各バックグラウンド タスクを登録するものとします。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-113">This topic assumes you have a created one or more background task classes, and that your app registers each background task to run in response to at least one trigger.</span></span>

## <a name="add-extensions-manually"></a><span data-ttu-id="9c1ab-114">手動での拡張機能の追加</span><span class="sxs-lookup"><span data-stu-id="9c1ab-114">Add Extensions Manually</span></span>


<span data-ttu-id="9c1ab-115">アプリケーション マニフェスト (Package.appxmanifest) を開き、Application 要素に移動します。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-115">Open the application manifest (Package.appxmanifest) and go to the Application element.</span></span> <span data-ttu-id="9c1ab-116">Extensions 要素を作ります (まだ存在していない場合)。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-116">Create an Extensions element (if one doesn't already exist).</span></span>

<span data-ttu-id="9c1ab-117">次に示す例は、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)から抜粋したものです。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-117">The following snippet is taken from the [background task sample](http://go.microsoft.com/fwlink/p/?LinkId=618666):</span></span>

```xml
<Application Id="App"
   ...
   <Extensions>
     <Extension Category="windows.backgroundTasks" EntryPoint="Tasks.SampleBackgroundTask">
       <BackgroundTasks>
         <Task Type="systemEvent" />
         <Task Type="timer" />
       </BackgroundTasks>
     </Extension>
     <Extension Category="windows.backgroundTasks" EntryPoint="Tasks.ServicingComplete">
       <BackgroundTasks>
         <Task Type="systemEvent"/>
       </BackgroundTasks>
     </Extension>
   </Extensions>
 </Application>
```

## <a name="add-a-background-task-extension"></a><span data-ttu-id="9c1ab-118">バックグラウンド タスク拡張機能の追加</span><span class="sxs-lookup"><span data-stu-id="9c1ab-118">Add a Background Task Extension</span></span>  

<span data-ttu-id="9c1ab-119">最初のバックグラウンド タスクを宣言します。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-119">Declare your first background task.</span></span>

<span data-ttu-id="9c1ab-120">このコードを Extensions 要素にコピーします (次の手順で属性を追加します)。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-120">Copy this code into the Extensions element (you will add attributes in the following steps).</span></span>

```xml
<Extensions>
    <Extension Category="windows.backgroundTasks" EntryPoint="">
      <BackgroundTasks>
        <Task Type="" />
      </BackgroundTasks>
    </Extension>
</Extensions>
```

1.  <span data-ttu-id="9c1ab-121">EntryPoint 属性を、バックグラウンド タスクの登録時にエントリ ポイントとしてコードで使ったものと同じ文字列に変更します (**namespace.classname**)。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-121">Change the EntryPoint attribute to have the same string used by your code as the entry point when registering your background task (**namespace.classname**).</span></span>

    <span data-ttu-id="9c1ab-122">この例のエントリ ポイントは、ExampleBackgroundTaskNameSpace.ExampleBackgroundTaskClassName です。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-122">In this example, the entry point is ExampleBackgroundTaskNameSpace.ExampleBackgroundTaskClassName:</span></span>

```xml
<Extensions>
    <Extension Category="windows.backgroundTasks" EntryPoint="Tasks.ExampleBackgroundTaskClassName">
       <BackgroundTasks>
         <Task Type="" />
       </BackgroundTasks>
    </Extension>
</Extensions>
```

2.  <span data-ttu-id="9c1ab-123">Task Type 属性のリストを、このバックグラウンド タスクで使われるタスク登録の種類を示すように変更します。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-123">Change the list of Task Type attribute to indicate the type of task registration used with this background task.</span></span> <span data-ttu-id="9c1ab-124">バックグラウンド タスクを複数の種類のトリガーで登録する場合は、必要な Task 要素と Type 属性を個々に追加します。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-124">If the background task is registered with multiple trigger types, add additional Task elements and Type attributes for each one.</span></span>

    <span data-ttu-id="9c1ab-125">**注:** トリガーの種類の各リストを使用している、または宣言されていないトリガーの種類 ([**登録**](https://msdn.microsoft.com/library/windows/apps/br224772)メソッドが失敗し、例外がスロー) と、バック グラウンド タスクは登録されないかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-125">**Note**Make sure to list each of the trigger types you're using, or the background task will not register with the undeclared trigger types (the [**Register**](https://msdn.microsoft.com/library/windows/apps/br224772) method will fail and throw an exception).</span></span>

    <span data-ttu-id="9c1ab-126">次の抜粋例は、システム イベント トリガーとプッシュ通知の使用法を示します。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-126">This snippet example indicates the use of system event triggers and push notifications:</span></span>

```xml
<Extension Category="windows.backgroundTasks" EntryPoint="Tasks.BackgroundTaskClass">
    <BackgroundTasks>
        <Task Type="systemEvent" />
        <Task Type="pushNotification" />
    </BackgroundTasks>
</Extension>
```

### <a name="add-multiple-background-task-extensions"></a><span data-ttu-id="9c1ab-127">複数のバックグラウンド タスク拡張機能の追加</span><span class="sxs-lookup"><span data-stu-id="9c1ab-127">Add multiple background task extensions</span></span>

<span data-ttu-id="9c1ab-128">アプリで登録する追加のバックグラウンド タスク クラスごとに、手順 2. を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-128">Repeat step 2 for each additional background task class registered by your app.</span></span>

<span data-ttu-id="9c1ab-129">次に、[バックグラウンド タスク サンプル]( http://go.microsoft.com/fwlink/p/?linkid=227509)の完全な Application 要素の例を示します。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-129">The following example is the complete Application element from the [background task sample]( http://go.microsoft.com/fwlink/p/?linkid=227509).</span></span> <span data-ttu-id="9c1ab-130">これは、計 3 種類のトリガーで 2 つのバックグラウンド タスク クラスを使う例を示します。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-130">This shows the use of 2 background task classes with a total of 3 trigger types.</span></span> <span data-ttu-id="9c1ab-131">この例の Extensions セクションをコピーし、必要に応じて変更して、アプリケーション マニフェストでバックグラウンド タスクを宣言します。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-131">Copy the Extensions section of this example, and modify it as needed, to declare background tasks in your application manifest.</span></span>

```xml
<Applications>
    <Application Id="App"
      Executable="$targetnametoken$.exe"
      EntryPoint="BackgroundTask.App">
        <uap:VisualElements
          DisplayName="BackgroundTask"
          Square150x150Logo="Assets\StoreLogo-sdk.png"
          Square44x44Logo="Assets\SmallTile-sdk.png"
          Description="BackgroundTask"

          BackgroundColor="#00b2f0">
          <uap:LockScreen Notification="badgeAndTileText" BadgeLogo="Assets\smalltile-Windows-sdk.png" />
            <uap:SplashScreen Image="Assets\Splash-sdk.png" />
            <uap:DefaultTile DefaultSize="square150x150Logo" Wide310x150Logo="Assets\tile-sdk.png" >
                <uap:ShowNameOnTiles>
                    <uap:ShowOn Tile="square150x150Logo" />
                    <uap:ShowOn Tile="wide310x150Logo" />
                </uap:ShowNameOnTiles>
            </uap:DefaultTile>
        </uap:VisualElements>

      <Extensions>
        <Extension Category="windows.backgroundTasks" EntryPoint="Tasks.SampleBackgroundTask">
          <BackgroundTasks>
            <Task Type="systemEvent" />
            <Task Type="timer" />
          </BackgroundTasks>
        </Extension>
        <Extension Category="windows.backgroundTasks" EntryPoint="Tasks.ServicingComplete">
          <BackgroundTasks>
            <Task Type="systemEvent"/>
          </BackgroundTasks>
        </Extension>
      </Extensions>
    </Application>
</Applications>
```

## <a name="declare-where-your-background-task-will-run"></a><span data-ttu-id="9c1ab-132">バック グラウンド タスクの実行先の宣言</span><span class="sxs-lookup"><span data-stu-id="9c1ab-132">Declare where your background task will run</span></span>

<span data-ttu-id="9c1ab-133">バックグラウンド タスクの実行先を指定することができます。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-133">You can specify where your background tasks run:</span></span>

* <span data-ttu-id="9c1ab-134">既定では、BackgroundTaskHost.exe プロセスで実行されます。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-134">By default, they run in the BackgroundTaskHost.exe process.</span></span>
* <span data-ttu-id="9c1ab-135">フォアグラウンド アプリケーションと同じプロセスで実行できます。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-135">In the same process as your foreground application.</span></span>
* <span data-ttu-id="9c1ab-136">`ResourceGroup` を使用すると、複数のバックグラウンド タスクを同じホスティング プロセスに配置したり、異なるプロセスに分離したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-136">Use `ResourceGroup` to place multiple background tasks into the same hosting process, or to separate them into different processes.</span></span>
* <span data-ttu-id="9c1ab-137">`SupportsMultipleInstances` を使用すると、新しいトリガーが発生するたびに、独自のリソース制限 (メモリ、CPU) を持つ新しいプロセスでバックグラウンド プロセスが実行されます。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-137">Use `SupportsMultipleInstances` to run the background process in a new process that gets its own resource limits (memory, cpu) each time a new trigger is fired.</span></span>

### <a name="run-in-the-same-process-as-your-foreground-application"></a><span data-ttu-id="9c1ab-138">フォアグラウンド アプリケーションと同じプロセスでの実行</span><span class="sxs-lookup"><span data-stu-id="9c1ab-138">Run in the same process as your foreground application</span></span>

<span data-ttu-id="9c1ab-139">フォアグラウンド アプリケーションと同じプロセスで実行されるバック グラウンド タスクを宣言する XML の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-139">Here is example XML that declares a background task that runs in the same process as the foreground application.</span></span>

```xml
<Extensions>
    <Extension Category="windows.backgroundTasks" EntryPoint="ExecModelTestBackgroundTasks.ApplicationTriggerTask">
        <BackgroundTasks>
            <Task Type="systemEvent" />
        </BackgroundTasks>
    </Extension>
</Extensions>
```

<span data-ttu-id="9c1ab-140">**EntryPoint** を指定すると、アプリケーションは指定されたメソッドへのコールバックをトリガーの発生時に受け取ります。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-140">When you specify **EntryPoint**, your application receives a callback to the specified method when the trigger fires.</span></span> <span data-ttu-id="9c1ab-141">**EntryPoint** を指定していない場合、アプリケーションは [OnBackgroundActivated()](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx) を介してコールバックを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-141">If you do not specify an **EntryPoint**, your application receives the callback via  [OnBackgroundActivated()](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx).</span></span>  <span data-ttu-id="9c1ab-142">詳しくは、「[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="9c1ab-142">See [Create and register an in-process background task](create-and-register-an-inproc-background-task.md) for details.</span></span>

### <a name="specify-where-your-background-task-runs-with-the-resourcegroup-attribute"></a><span data-ttu-id="9c1ab-143">ResourceGroup 属性を使用して、バックグラウンド タスクの実行先を指定</span><span class="sxs-lookup"><span data-stu-id="9c1ab-143">Specify where your background task runs with the ResourceGroup attribute.</span></span>

<span data-ttu-id="9c1ab-144">BackgroundTaskHost.exe プロセスで実行されるが、同じアプリのバックグラウンド タスクの他のインスタンスとは別に実行される、バックグラウンド タスクを宣言する XML の例を示します。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-144">Here is example XML that declares a background task that runs in a BackgroundTaskHost.exe process, but in a separate one than other instances of background tasks from the same app.</span></span> <span data-ttu-id="9c1ab-145">共に実行されるバックグラウンド タスクを指定する、`ResourceGroup` 属性に注意してください。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-145">Note the `ResourceGroup` attribute, which identifies which background tasks will run together.</span></span>

```xml
<Extensions>
    <Extension Category="windows.backgroundTasks" EntryPoint="BackgroundTasks.SessionConnectedTriggerTask" ResourceGroup="foo">
      <BackgroundTasks>
        <Task Type="systemEvent" />
      </BackgroundTasks>
    </Extension>
    <Extension Category="windows.backgroundTasks" EntryPoint="BackgroundTasks.TimeZoneTriggerTask" ResourceGroup="foo">
      <BackgroundTasks>
        <Task Type="systemEvent" />
      </BackgroundTasks>
    </Extension>
    <Extension Category="windows.backgroundTasks" EntryPoint="BackgroundTasks.TimerTriggerTask" ResourceGroup="bar">
      <BackgroundTasks>
        <Task Type="timer" />
      </BackgroundTasks>
    </Extension>
    <Extension Category="windows.backgroundTasks" EntryPoint="BackgroundTasks.ApplicationTriggerTask" ResourceGroup="bar">
      <BackgroundTasks>
        <Task Type="general" />
      </BackgroundTasks>
    </Extension>
    <Extension Category="windows.backgroundTasks" EntryPoint="BackgroundTasks.MaintenanceTriggerTask" ResourceGroup="foobar">
      <BackgroundTasks>
        <Task Type="general" />
      </BackgroundTasks>
    </Extension>
</Extensions>
```

### <a name="run-in-a-new-process-each-time-a-trigger-fires-with-the-supportsmultipleinstances-attribute"></a><span data-ttu-id="9c1ab-146">SupportsMultipleInstances 属性を使用して、トリガーが発生するたびに新しいプロセスで実行</span><span class="sxs-lookup"><span data-stu-id="9c1ab-146">Run in a new process each time a trigger fires with the SupportsMultipleInstances attribute</span></span>

<span data-ttu-id="9c1ab-147">この例では、新しいトリガーが発生するたびに独自のリソース制限 (メモリと CPU) を持つ新しいプロセスで実行される、バックグラウンド タスクを宣言します。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-147">This example declares a background task that runs in a new process that gets its own resource limits (memory and CPU) every time a new trigger is fired.</span></span> <span data-ttu-id="9c1ab-148">`SupportsMultipleInstances` を使っていることに注目してください。この属性がこの動作を実現します。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-148">Note the use of `SupportsMultipleInstances` which enables this behavior.</span></span> <span data-ttu-id="9c1ab-149">この属性を使用するためにはターゲット SDK バージョン '10.0.15063' (Windows 10 Creators Update) 以上。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-149">In order to use this attribute you must target SDK version '10.0.15063' (Windows 10 Creators Update) or higher.</span></span>

```xml
<Package
    xmlns:uap4="http://schemas.microsoft.com/appx/manifest/uap/windows10/4"
    ...
    <Applications>
        <Application ...>
            ...
            <Extensions>
                <Extension Category="windows.backgroundTasks" EntryPoint="BackgroundTasks.TimerTriggerTask">
                    <BackgroundTasks uap4:SupportsMultipleInstances=“True”>
                        <Task Type="timer" />
                    </BackgroundTasks>
                </Extension>
            </Extensions>
        </Application>
    </Applications>
```

> [!NOTE]
> <span data-ttu-id="9c1ab-150">`SupportsMultipleInstances` と共に `ResourceGroup` または `ServerName` を指定することはできません。</span><span class="sxs-lookup"><span data-stu-id="9c1ab-150">You cannot specify `ResourceGroup` or `ServerName` in conjunction with `SupportsMultipleInstances`.</span></span>

## <a name="related-topics"></a><span data-ttu-id="9c1ab-151">関連トピック</span><span class="sxs-lookup"><span data-stu-id="9c1ab-151">Related topics</span></span>

* [<span data-ttu-id="9c1ab-152">バックグラウンド タスクのデバッグ</span><span class="sxs-lookup"><span data-stu-id="9c1ab-152">Debug a background task</span></span>](debug-a-background-task.md)
* [<span data-ttu-id="9c1ab-153">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="9c1ab-153">Register a background task</span></span>](register-a-background-task.md)
* [<span data-ttu-id="9c1ab-154">バックグラウンド タスクのガイドライン</span><span class="sxs-lookup"><span data-stu-id="9c1ab-154">Guidelines for background tasks</span></span>](guidelines-for-background-tasks.md)
