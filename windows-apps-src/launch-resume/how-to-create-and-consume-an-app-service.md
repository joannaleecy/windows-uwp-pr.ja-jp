---
author: TylerMSFT
title: アプリ サービスの作成と利用
description: 他のユニバーサル Windows プラットフォーム (UWP) アプリにサービスを提供できる UWP アプリを作成する方法と、それらのサービスを利用する方法について説明します。
ms.assetid: 6E48B8B6-D3BF-4AE2-85FB-D463C448C9D3
keywords: アプリ間通信, プロセス間通信, IPC, バック グラウンド メッセージング, バック グラウンド通信, アプリをアプリ サービス
ms.author: twhitney
ms.date: 09/18/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 7475ae8db964b23de89488d883c135158ea20e74
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4747129"
---
# <a name="create-and-consume-an-app-service"></a><span data-ttu-id="4519d-104">アプリ サービスの作成と利用</span><span class="sxs-lookup"><span data-stu-id="4519d-104">Create and consume an app service</span></span>

<span data-ttu-id="4519d-105">アプリ サービスは、他の UWP アプリにサービスを提供する UWP アプリです。</span><span class="sxs-lookup"><span data-stu-id="4519d-105">App services are UWP apps that provide services to other UWP apps.</span></span> <span data-ttu-id="4519d-106">これは、デバイス上にある Web サービスのようなものです。</span><span class="sxs-lookup"><span data-stu-id="4519d-106">They are analogous to web services, on a device.</span></span> <span data-ttu-id="4519d-107">アプリ サービスは、バック グラウンド タスクとしてホスト アプリで実行され、そのサービスを他のアプリに提供することができます。</span><span class="sxs-lookup"><span data-stu-id="4519d-107">An app service runs as a background task in the host app and can provide its service to other apps.</span></span> <span data-ttu-id="4519d-108">たとえば、アプリ サービスによって、他のアプリで使用できるバー コード スキャナー サービスが提供される場合があります。</span><span class="sxs-lookup"><span data-stu-id="4519d-108">For example, an app service might provide a bar code scanner service that other apps could use.</span></span> <span data-ttu-id="4519d-109">また、アプリのエンタープライズ スイートに共通のスペル チェック アプリ サービスを備えておき、そのサービスを同じスイート内の他のアプリから利用可能にする場合もあるでしょう。</span><span class="sxs-lookup"><span data-stu-id="4519d-109">Or perhaps an Enterprise suite of apps has a common spell checking app service that is available to the other apps in the suite.</span></span>  <span data-ttu-id="4519d-110">アプリ サービスでは、同じデバイス上のアプリから呼び出せる UI を持たないサービスを作成できます。また、Windows 10 バージョン 1607 以降では、リモート デバイスからも呼び出せます。</span><span class="sxs-lookup"><span data-stu-id="4519d-110">App services let you create UI-less services that apps can call on the same device, and starting with Windows 10, version 1607, on remote devices.</span></span> 

<span data-ttu-id="4519d-111">Windows 10 バージョン 1607 以降では、ホスト アプリと同じプロセスで実行されるアプリ サービスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="4519d-111">Starting in Windows 10, version 1607, you can create app services that run in the same process as the host app.</span></span> <span data-ttu-id="4519d-112">この記事では、別のバックグラウンド プロセスで実行されるアプリ サービスの作成と利用に重点を置いて説明します。</span><span class="sxs-lookup"><span data-stu-id="4519d-112">This article focuses on creating and consuming an app service that runs in a separate background process.</span></span> <span data-ttu-id="4519d-113">プロバイダーと同じプロセスでアプリ サービスを実行する詳細については、「[ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する](convert-app-service-in-process.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4519d-113">See [Convert an app service to run in the same process as its host app](convert-app-service-in-process.md) for more details about running an app service in the same process as the provider.</span></span>

<span data-ttu-id="4519d-114">アプリ サービスのコード サンプルについては、「[ユニバーサル Windows プラットフォーム (UWP) アプリのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="4519d-114">For an app service code sample, see [Universal Windows Platform (UWP) app samples](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices).</span></span>

## <a name="create-a-new-app-service-provider-project"></a><span data-ttu-id="4519d-115">新しいアプリ サービス プロバイダー プロジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="4519d-115">Create a new app service provider project</span></span>

<span data-ttu-id="4519d-116">このトピックでは、わかりやすくするためにすべてを 1 つのソリューションで作成します。</span><span class="sxs-lookup"><span data-stu-id="4519d-116">In this how-to, we'll create everything in one solution for simplicity.</span></span>

-   <span data-ttu-id="4519d-117">Microsoft Visual Studio で、新しい UWP アプリ プロジェクトを作成し、これに **AppServiceProvider** という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="4519d-117">In Microsoft Visual Studio, create a new UWP app project and name it **AppServiceProvider**.</span></span> <span data-ttu-id="4519d-118">(**[新しいプロジェクト]** ダイアログ ボックスで、**[テンプレート] &gt; [他の言語] &gt; [Visual C#] &gt; [Windows] &gt; [Windows ユニバーサル] &gt; [空白のアプリ (Windows ユニバーサル)]** の順にクリックします)。</span><span class="sxs-lookup"><span data-stu-id="4519d-118">(In the **New Project** dialog box, select **Templates &gt; Other Languages &gt; Visual C# &gt; Windows &gt; Windows Universal &gt; Blank app (Windows Universal)**).</span></span> <span data-ttu-id="4519d-119">これは、他の UWP アプリがアプリ サービスを利用できるアプリとなります。</span><span class="sxs-lookup"><span data-stu-id="4519d-119">This will be the app that makes the app service available to other UWP apps.</span></span>
-   <span data-ttu-id="4519d-120">プロジェクトの**ターゲット バージョン**の選択を求められたら、**10.0.14393** 以上を選びます。</span><span class="sxs-lookup"><span data-stu-id="4519d-120">When asked to select a **Target Version** for the project, select at least **10.0.14393**.</span></span> <span data-ttu-id="4519d-121">新しい `SupportsMultipleInstances` 属性を使用する場合には、Visual Studio 2017 を使用して、**10.0.15063** (**Windows 10 Creators Update**) 以降をターゲットとする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4519d-121">If you want to use the new `SupportsMultipleInstances` attribute, you must be using Visual Studio 2017 and target **10.0.15063** (**Windows 10 Creators Update**) or higher.</span></span>

<span id="appxmanifest"/>

## <a name="add-an-app-service-extension-to-packageappxmanifest"></a><span data-ttu-id="4519d-122">package.appxmanifest へのアプリ サービスの拡張機能の追加</span><span class="sxs-lookup"><span data-stu-id="4519d-122">Add an app service extension to package.appxmanifest</span></span>

<span data-ttu-id="4519d-123">AppServiceProvider プロジェクトの Package.appxmanifest ファイルで、次の AppService 拡張機能を `&lt;Application&gt;` 要素内に追加します。</span><span class="sxs-lookup"><span data-stu-id="4519d-123">In the AppServiceProvider project's Package.appxmanifest file, add the following AppService extension inside the `&lt;Application&gt;` element.</span></span> <span data-ttu-id="4519d-124">この例では、`com.Microsoft.Inventory` サービスをアドバタイズし、このアプリをアプリ サービス プロバイダーとして識別します。</span><span class="sxs-lookup"><span data-stu-id="4519d-124">This example advertises the `com.Microsoft.Inventory` service and is what identifies this app as an app service provider.</span></span> <span data-ttu-id="4519d-125">実際のサービスは、バックグラウンド タスクとして実装されます。</span><span class="sxs-lookup"><span data-stu-id="4519d-125">The actual service will be implemented as a background task.</span></span> <span data-ttu-id="4519d-126">アプリ サービスのプロジェクトは、サービスを他のアプリに公開します。</span><span class="sxs-lookup"><span data-stu-id="4519d-126">The app service project exposes the service to other apps.</span></span> <span data-ttu-id="4519d-127">サービス名には逆のドメイン名スタイルを使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4519d-127">We recommend using a reverse domain name style for the service name.</span></span>

<span data-ttu-id="4519d-128">`xmlns:uap4` 名前空間のプレフィックスと `uap4:SupportsMultipleInstances` 属性は、Windows SDK バージョン 10.0.15063 以降をターゲットとしている場合のみ有効です。</span><span class="sxs-lookup"><span data-stu-id="4519d-128">Note that the `xmlns:uap4` namespace prefix and the `uap4:SupportsMultipleInstances` attribute are only valid if you are targeting Windows SDK version 10.0.15063 or higher.</span></span> <span data-ttu-id="4519d-129">以前のバージョンの SDK をターゲットとしている場合には、それらは安全に削除できます。</span><span class="sxs-lookup"><span data-stu-id="4519d-129">You can safely remove them if you are targeting older SDK versions.</span></span>

``` xml
<Package
    ...
    xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
    xmlns:uap4="http://schemas.microsoft.com/appx/manifest/uap/windows10/4"
    ...
    <Applications>
        <Application Id="AppServicesProvider.App"
          Executable="$targetnametoken$.exe"
          EntryPoint="AppServicesProvider.App">
          ...
          <Extensions>
            <uap:Extension Category="windows.appService" EntryPoint="MyAppService.Inventory">
              <uap3:AppService Name="com.microsoft.inventory" uap4:SupportsMultipleInstances="true"/>
            </uap:Extension>
          </Extensions>
          ...
        </Application>
    </Applications>
```

<span data-ttu-id="4519d-130">**Category** 属性は、このアプリケーションをアプリ サービス プロバイダーとして識別します。</span><span class="sxs-lookup"><span data-stu-id="4519d-130">The **Category** attribute identifies this application as an app service provider.</span></span>

<span data-ttu-id="4519d-131">**EntryPoint** 属性は、サービスを実装する名前空間修飾クラスを識別します。これについては、次に実装します。</span><span class="sxs-lookup"><span data-stu-id="4519d-131">The **EntryPoint** attribute identifies the namespace qualified class that implements the service, which we'll implement next.</span></span>

<span data-ttu-id="4519d-132">**SupportsMultipleInstances** 属性は、アプリ サービスが呼び出されるたびに、新しいプロセスで実行する必要があることを示します。</span><span class="sxs-lookup"><span data-stu-id="4519d-132">The **SupportsMultipleInstances** attribute indicates that each time the app service is called that it should run in a new process.</span></span> <span data-ttu-id="4519d-133">これは必須ではありませんが、その機能を必要とし、`10.0.15063` SDK (**Windows 10 Creators Update**) 以降をターゲットとしている場合には、利用できます。</span><span class="sxs-lookup"><span data-stu-id="4519d-133">This is not required but is available to you if you need that functionality and are targeting the `10.0.15063` SDK (**Windows 10 Creators Update**) or higher.</span></span> <span data-ttu-id="4519d-134">また、先頭に `uap4` 名前空間を付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="4519d-134">It also should be prefaced by the `uap4` namespace.</span></span>

## <a name="create-the-app-service"></a><span data-ttu-id="4519d-135">アプリ サービスの作成</span><span class="sxs-lookup"><span data-stu-id="4519d-135">Create the app service</span></span>

1.  <span data-ttu-id="4519d-136">アプリ サービスは、バックグラウンド タスクとして実装できます。</span><span class="sxs-lookup"><span data-stu-id="4519d-136">An app service can be implemented as a background task.</span></span> <span data-ttu-id="4519d-137">これにより、フォアグラウンド アプリケーションは、別のアプリケーションのアプリ サービスを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="4519d-137">This enables a foreground application to invoke an app service in another application.</span></span> <span data-ttu-id="4519d-138">アプリ サービスをバックグラウンド タスクとして作成するには、MyAppService という名前の新しい Windows ランタイム コンポーネント プロジェクトをソリューションに追加 (**[ファイル] &gt; [追加] &gt; [新しいプロジェクト]**) します。</span><span class="sxs-lookup"><span data-stu-id="4519d-138">To create an app service as a background task, add a new Windows Runtime Component project to the solution (**File &gt; Add &gt; New Project**) named MyAppService.</span></span> <span data-ttu-id="4519d-139">(**[新しいプロジェクトの追加]** ダイアログ ボックスで、**[インストール済み] &gt; [他の言語] &gt; [Visual C#] &gt; [Windows] &gt; [Windows ユニバーサル] &gt; [Windows ランタイム コンポーネント (Windows ユニバーサル)]** の順に選びます。)</span><span class="sxs-lookup"><span data-stu-id="4519d-139">(In the **Add New Project** dialog box, choose **Installed &gt; Other Languages &gt; Visual C# &gt; Windows &gt; Windows Universal &gt; Windows Runtime Component (Windows Universal)**</span></span>
2.  <span data-ttu-id="4519d-140">**AppServiceProvider**プロジェクトで、新しい **MyAppService**プロジェクト (ソリューション エクスプ ローラーで、**[AppServiceProvider]** を右クリックし、[プロジェクト] > **[追加]** > **[リファレンス]** > **[プロジェクト]** > **[ソリューション]** から **[MyAppService]** > **[OK]** をクリック) へのプロジェクト間の参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="4519d-140">In the **AppServiceProvider** project, add a project-to-project reference to the new **MyAppService** project (In the Solution Explorer, right-click on the **AppServiceProvider** project > **Add** > **Reference** > **Projects** > **Solution**, select **MyAppService** > **OK**).</span></span> <span data-ttu-id="4519d-141">参照を追加しない場合でも、アプリ サービスは実行時に接続されないため、この手順は重要です。</span><span class="sxs-lookup"><span data-stu-id="4519d-141">This step is critical because if you do not add the reference, the app service won't connect at runtime.</span></span>
3.  <span data-ttu-id="4519d-142">MyappService プロジェクトで、Class1.cs の上部に、次の **using** ステートメントを追加します。</span><span class="sxs-lookup"><span data-stu-id="4519d-142">In the MyappService project, add the following **using** statements to the top of Class1.cs:</span></span>
    ```cs
    using Windows.ApplicationModel.AppService;
    using Windows.ApplicationModel.Background;
    using Windows.Foundation.Collections;
    ```

4.  <span data-ttu-id="4519d-143">**Class1** のスタブ コードを、**Inventory** という名前の新しいバックグラウンド タスク クラスに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="4519d-143">Replace the stub code for **Class1** with a new background task class named **Inventory**:</span></span>

    ```cs
    public sealed class Inventory : IBackgroundTask
    {
        private BackgroundTaskDeferral backgroundTaskDeferral;
        private AppServiceConnection appServiceconnection;
        private String[] inventoryItems = new string[] { "Robot vacuum", "Chair" };
        private double[] inventoryPrices = new double[] { 129.99, 88.99 };

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            this.backgroundTaskDeferral = taskInstance.GetDeferral(); // Get a deferral so that the service isn't terminated.
            taskInstance.Canceled += OnTaskCanceled; // Associate a cancellation handler with the background task.

            // Retrieve the app service connection and set up a listener for incoming app service requests.
            var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            appServiceconnection = details.AppServiceConnection;
            appServiceconnection.RequestReceived += OnRequestReceived;
        }

        private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            // This function is called when the app service receives a request
        }

        private void OnTaskCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            if (this.backgroundTaskDeferral != null)
            {
                // Complete the service deferral.
                this.backgroundTaskDeferral.Complete();
            }
        }
    }
    ```

    <span data-ttu-id="4519d-144">このクラスは、アプリ サービスが作業を実行する場所です。</span><span class="sxs-lookup"><span data-stu-id="4519d-144">This class is where the app service will do its work.</span></span>

    <span data-ttu-id="4519d-145">バックグラウンド タスクが作成されると、**Run()** が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="4519d-145">**Run()** is called when the background task is created.</span></span> <span data-ttu-id="4519d-146">バックグラウンド タスクは **Run** が完了すると終了するため、バックグラウンド タスクが要求に引き続き対応できるように、コードは保留されます。</span><span class="sxs-lookup"><span data-stu-id="4519d-146">Because background tasks are terminated after **Run** completes, the code takes out a deferral so that the background task will stay up to serve requests.</span></span> <span data-ttu-id="4519d-147">バックグラウンド タスクとして実装されたアプリ サービスは、呼び出しを受け取った後、約 30 秒間に再度呼び出されない限り、または保留されない限り、約 30 秒間有効になっています。アプリ サービスが同じプロセスで呼び出し元として実装されると、アプリ サービスの有効期間は呼び出し元の有効期間に関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="4519d-147">An app service that is implemented as a background task will stay alive for about 30 seconds after it receives a call unless it is called again within that time window or a deferral is taken out. If the app service is implemented in the same process as the caller, the lifetime of the app service is tied to the lifetime of the caller.</span></span>

    <span data-ttu-id="4519d-148">アプリ サービスの有効期間は、呼び出し元に依存します。</span><span class="sxs-lookup"><span data-stu-id="4519d-148">The lifetime of the app service depends on the caller:</span></span>

    1. <span data-ttu-id="4519d-149">呼び出し元がフォアグラウンドである場合は、アプリ サービスの有効期間は、呼び出し元と同じです。</span><span class="sxs-lookup"><span data-stu-id="4519d-149">If the caller is in foreground, the app service lifetime is the same as the caller.</span></span>
    2. <span data-ttu-id="4519d-150">呼び出し元がバックグラウンドである場合は、アプリ サービスの有効期間は 30 秒です。</span><span class="sxs-lookup"><span data-stu-id="4519d-150">If the caller is in background, the app service gets 30 seconds to run.</span></span> <span data-ttu-id="4519d-151">保留されると、1 回 5 秒追加されます。</span><span class="sxs-lookup"><span data-stu-id="4519d-151">Taking out a deferral provides an additional one time 5 seconds.</span></span>

    <span data-ttu-id="4519d-152">タスクが取り消されると、**OnTaskCanceled()** が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="4519d-152">**OnTaskCanceled()** is called when the task is canceled.</span></span> <span data-ttu-id="4519d-153">タスクが取り消されるのは、クライアント アプリが [**AppServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn921704) を破棄したとき、クライアント アプリが中断されたとき、OS がシャットダウンまたはスリープ状態になったとき、または OS がリソース不足になりタスクを実行できなくなったときです。</span><span class="sxs-lookup"><span data-stu-id="4519d-153">The task is cancelled when the client app disposes the [**AppServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn921704), the client app is suspended, the OS is shut down or sleeps, or the OS runs out of resources to run the task.</span></span>

## <a name="write-the-code-for-the-app-service"></a><span data-ttu-id="4519d-154">アプリ サービスのコードを記述する</span><span class="sxs-lookup"><span data-stu-id="4519d-154">Write the code for the app service</span></span>

<span data-ttu-id="4519d-155">**OnRequestReceived()** は、アプリ サービスのコードが配置される場所です。</span><span class="sxs-lookup"><span data-stu-id="4519d-155">**OnRequestReceived()** is where the code for the app service goes.</span></span> <span data-ttu-id="4519d-156">MyAppService の Class1.cs のスタブ **OnRequestReceived()** を、次の例のコードに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="4519d-156">Replace the stub **OnRequestReceived()** in MyAppService's Class1.cs with the code from this example.</span></span> <span data-ttu-id="4519d-157">このコードは、インベントリの項目のインデックスを取得し、コマンド文字列と共にサービスに渡して、指定したインベントリ項目の名前と価格を取得します。</span><span class="sxs-lookup"><span data-stu-id="4519d-157">This code gets an index for an inventory item and passes it, along with a command string, to the service to retrieve the name and the price of the specified inventory item.</span></span> <span data-ttu-id="4519d-158">独自のプロジェクトには、エラー処理コードを追加します。</span><span class="sxs-lookup"><span data-stu-id="4519d-158">For your own projects, add error handling code.</span></span>

```cs
private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
{
    // Get a deferral because we use an awaitable API below to respond to the message
    // and we don't want this call to get cancelled while we are waiting.
    var messageDeferral = args.GetDeferral();

    ValueSet message = args.Request.Message;
    ValueSet returnData = new ValueSet();

    string command = message["Command"] as string;
    int? inventoryIndex = message["ID"] as int?;

    if ( inventoryIndex.HasValue &&
         inventoryIndex.Value >= 0 &&
         inventoryIndex.Value < inventoryItems.GetLength(0))
    {
        switch (command)
        {
            case "Price":
            {
                returnData.Add("Result", inventoryPrices[inventoryIndex.Value]);
                returnData.Add("Status", "OK");
                break;
            }

            case "Item":
            {
                returnData.Add("Result", inventoryItems[inventoryIndex.Value]);
                returnData.Add("Status", "OK");
                break;
            }

            default:
            {
                returnData.Add("Status", "Fail: unknown command");
                break;
            }
        }
    }
    else
    {
        returnData.Add("Status", "Fail: Index out of range");
    }

    try
    {
        await args.Request.SendResponseAsync(returnData); // Return the data to the caller.
    }
    catch (Exception e)
    {
        // your exception handling code here
    }
    finally
    {
        // Complete the deferral so that the platform knows that we're done responding to the app service call.
        // Note for error handling: this must be called even if SendResponseAsync() throws an exception.
        messageDeferral.Complete();
    }
}
```

<span data-ttu-id="4519d-159">**OnRequestReceived()** が **async** であることに注意してください。この例では、[**SendResponseAsync**](https://msdn.microsoft.com/library/windows/apps/dn921722) への待機可能なメソッド呼び出しを行うためです。</span><span class="sxs-lookup"><span data-stu-id="4519d-159">Note that **OnRequestReceived()** is **async** because we make an awaitable method call to [**SendResponseAsync**](https://msdn.microsoft.com/library/windows/apps/dn921722) in this example.</span></span>

<span data-ttu-id="4519d-160">保留が行われるのは、サービスが OnRequestReceived ハンドラーで **async** メソッドを使用できるようにするためです。</span><span class="sxs-lookup"><span data-stu-id="4519d-160">A deferral is taken so that the service can use **async** methods in the OnRequestReceived handler.</span></span> <span data-ttu-id="4519d-161">これにより、**OnRequestReceived** への呼び出しは、メッセージの処理が完了するまで完了しません。</span><span class="sxs-lookup"><span data-stu-id="4519d-161">It ensures that the call to **OnRequestReceived** does not complete until it is done processing the message.</span></span>  <span data-ttu-id="4519d-162">[**SendResponseAsync**](https://msdn.microsoft.com/library/windows/apps/dn921722) が結果を呼び出し元に送ります。</span><span class="sxs-lookup"><span data-stu-id="4519d-162">[**SendResponseAsync**](https://msdn.microsoft.com/library/windows/apps/dn921722) sends the result to the caller.</span></span> <span data-ttu-id="4519d-163">**SendResponseAsync** は、呼び出しの完了時に通知しません。</span><span class="sxs-lookup"><span data-stu-id="4519d-163">**SendResponseAsync** does not signal the completion of the call.</span></span> <span data-ttu-id="4519d-164">**OnRequestReceived** が完了したことを [**SendMessageAsync**](https://msdn.microsoft.com/library/windows/apps/dn921712) に通知するのは、保留の完了時です。</span><span class="sxs-lookup"><span data-stu-id="4519d-164">It is the completion of the deferral that signals to [**SendMessageAsync**](https://msdn.microsoft.com/library/windows/apps/dn921712) that **OnRequestReceived** has completed.</span></span> <span data-ttu-id="4519d-165">**SendResponseAsync()** の呼び出しは、**SendResponseAsync()** が例外をスローした場合でも保留を完了する必要があるため、try/finally ブロックでラップされます。</span><span class="sxs-lookup"><span data-stu-id="4519d-165">The call to **SendResponseAsync()** is wrapped in a try/finally block because you must complete the deferral even if **SendResponseAsync()** throws an exception.</span></span>

<span data-ttu-id="4519d-166">アプリ サービスは [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) を使って情報を交換します。</span><span class="sxs-lookup"><span data-stu-id="4519d-166">App services use a [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) to exchange information.</span></span> <span data-ttu-id="4519d-167">渡すことができるデータのサイズは、システム リソースによってのみ制限されます。</span><span class="sxs-lookup"><span data-stu-id="4519d-167">The size of the data you may pass is only limited by system resources.</span></span> <span data-ttu-id="4519d-168">**ValueSet** で使うことができる定義済みのキーはありません。</span><span class="sxs-lookup"><span data-stu-id="4519d-168">There are no predefined keys for you to use in your **ValueSet**.</span></span> <span data-ttu-id="4519d-169">アプリ サービスのプロトコルの定義に使うキーの値を決定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4519d-169">You must determine which key values you will use to define the protocol for your app service.</span></span> <span data-ttu-id="4519d-170">呼び出し元は、そのプロトコルを念頭に置いて記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4519d-170">The caller must be written with that protocol in mind.</span></span> <span data-ttu-id="4519d-171">この例では、アプリ サービスがインベントリ項目またはその価格の名前を提供するかどうかを示す値を持つ、`Command` という名前のキーを選びました。</span><span class="sxs-lookup"><span data-stu-id="4519d-171">In this example, we have chosen a key named `Command` that has a value that indicates whether we want the app service to provide the name of the inventory item or its price.</span></span> <span data-ttu-id="4519d-172">インベントリ名のインデックスは、`ID` キーに保存されています。</span><span class="sxs-lookup"><span data-stu-id="4519d-172">The index of the inventory name is stored under the `ID` key.</span></span> <span data-ttu-id="4519d-173">戻り値は `Result` キーに保存されます。</span><span class="sxs-lookup"><span data-stu-id="4519d-173">The return value is stored under the `Result` key.</span></span>

<span data-ttu-id="4519d-174">[**AppServiceClosedStatus**](https://msdn.microsoft.com/library/windows/apps/dn921703) 列挙体が呼び出し元に返され、アプリ サービスの呼び出した成功したか失敗したかを示します。</span><span class="sxs-lookup"><span data-stu-id="4519d-174">An [**AppServiceClosedStatus**](https://msdn.microsoft.com/library/windows/apps/dn921703) enum is returned to the caller to indicate whether the call to the app service succeeded or failed.</span></span> <span data-ttu-id="4519d-175">アプリ サービスへの呼び出しが失敗する例として、OS がサービスのエンドポイントを中止した、リソースが超過したなどがあります。</span><span class="sxs-lookup"><span data-stu-id="4519d-175">An example of how the call to the app service could fail is if the OS aborts the service endpoint because its resources have been exceeded.</span></span> <span data-ttu-id="4519d-176">[**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) を通じて、さらにエラー情報を取得することができます。</span><span class="sxs-lookup"><span data-stu-id="4519d-176">You can return additional error information via the [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131).</span></span> <span data-ttu-id="4519d-177">この例では、`Status` という名前のキーを使って、より詳細なエラー情報を呼び出し元に返します。</span><span class="sxs-lookup"><span data-stu-id="4519d-177">In this example, we use a key named `Status` to return more detailed error information to the caller.</span></span>

<span data-ttu-id="4519d-178">[**SendResponseAsync**](https://msdn.microsoft.com/library/windows/apps/dn921722) の呼び出しからは、[**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) が呼び出し元に返されます。</span><span class="sxs-lookup"><span data-stu-id="4519d-178">The call to [**SendResponseAsync**](https://msdn.microsoft.com/library/windows/apps/dn921722) returns the [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) to the caller.</span></span>

## <a name="deploy-the-service-app-and-get-the-package-family-name"></a><span data-ttu-id="4519d-179">サービス アプリを展開して、パッケージ ファミリ名を取得する</span><span class="sxs-lookup"><span data-stu-id="4519d-179">Deploy the service app and get the package family name</span></span>

<span data-ttu-id="4519d-180">クライアントから呼び出す前に、アプリ サービス プロバイダーのアプリを展開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4519d-180">The app service provider app must be deployed before you can call it from a client.</span></span> <span data-ttu-id="4519d-181">これを呼び出すには、アプリ サービスのアプリのパッケージ ファミリ名も必要になります。</span><span class="sxs-lookup"><span data-stu-id="4519d-181">You will also need the package family name of the app service app in order to call it.</span></span>

<span data-ttu-id="4519d-182">アプリ サービスのアプリのパッケージ ファミリ名を取得する 1 つの方法は、**AppServiceProvider** プロジェクト内から (たとえば、App.xaml.cs の `public App()` から) [**Windows.ApplicationModel.Package.Current.Id.FamilyName**](https://msdn.microsoft.com/library/windows/apps/br224670) を呼び出し、結果をメモします。</span><span class="sxs-lookup"><span data-stu-id="4519d-182">One way to get the package family name of the app service application is to call [**Windows.ApplicationModel.Package.Current.Id.FamilyName**](https://msdn.microsoft.com/library/windows/apps/br224670) from within the **AppServiceProvider** project (for example, from `public App()` in App.xaml.cs) and note the result.</span></span> <span data-ttu-id="4519d-183">Microsoft Visual Studio で AppServiceProvider を実行するには、ソリューション エクスプローラー ウィンドウで、スタートアップ プロジェクトとして設定し、プロジェクトを実行します。</span><span class="sxs-lookup"><span data-stu-id="4519d-183">To run AppServiceProvider in Microsoft Visual Studio, set it as the startup project in the Solution Explorer window and run the project.</span></span>

<span data-ttu-id="4519d-184">パッケージ ファミリ名を取得する別の方法として、ソリューションを配置し (**[ビルド] &gt; [ソリューションの配置]**)、出力ウィンドウで完全なパッケージ名をメモします (**[表示] &gt; [出力]**)。</span><span class="sxs-lookup"><span data-stu-id="4519d-184">Another way to get the package family name is to deploy the solution (**Build &gt; Deploy solution**) and note the full package name in the output window (**View &gt; Output**).</span></span> <span data-ttu-id="4519d-185">パッケージ名を派生するには、出力ウィンドウの文字列からプラットフォーム情報を削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4519d-185">You must remove the platform information from the string in the output window to derive the package name.</span></span> <span data-ttu-id="4519d-186">たとえば、完全なパッケージ名が出力ウィンドウで `Microsoft.SDKSamples.AppServicesProvider.CPP_1.0.0.0_x86__8wekyb3d8bbwe` と報告された場合、Microsoft.SDKSamples.AppServicesProvider.CPP_8wekyb3d8bbwe" を削除し、"1.0.0.0_x86__"(`1.0.0.0\_x86\_\_" leaving "Microsoft.SDKSamples.AppServicesProvider.CPP_8wekyb3d8bbwe`) がパッケージ ファミリ名となります。</span><span class="sxs-lookup"><span data-stu-id="4519d-186">For example, if the full package name reported in the output window was `Microsoft.SDKSamples.AppServicesProvider.CPP_1.0.0.0_x86__8wekyb3d8bbwe`, you would extract `1.0.0.0\_x86\_\_" leaving "Microsoft.SDKSamples.AppServicesProvider.CPP_8wekyb3d8bbwe` as the package family name.</span></span>

## <a name="write-a-client-to-call-the-app-service"></a><span data-ttu-id="4519d-187">アプリ サービスを呼び出すクライアントを作成する</span><span class="sxs-lookup"><span data-stu-id="4519d-187">Write a client to call the app service</span></span>

1.  <span data-ttu-id="4519d-188">**[ファイル] &gt; [追加] &gt; [新しいプロジェクト]** で、新しい空の Windows ユニバーサル アプリ プロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="4519d-188">Add a new blank Windows Universal app project to the solution with **File &gt; Add &gt; New Project**.</span></span> <span data-ttu-id="4519d-189">**[新しいプロジェクトの追加]** ダイアログ ボックスで、**[インストール済み] &gt; [他の言語] &gt; [Visual C#] &gt; [Windows] &gt; [Windows ユニバーサル] &gt; [空のアプリ (Windows ユニバーサル)] \*\* の順に選び、**[ClientApp]\*\* と名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="4519d-189">In the **Add New Project** dialog box, choose **Installed &gt; Other languages &gt; Visual C# &gt; Windows &gt; Windows Universal &gt; Blank App (Windows Universal)** and name it **ClientApp**.</span></span>
2.  <span data-ttu-id="4519d-190">ClientApp プロジェクトで、MainPage.xaml.cs の上部に、次の **using** ステートメントを追加します。</span><span class="sxs-lookup"><span data-stu-id="4519d-190">In the ClientApp project, add the following **using** statement to the top of MainPage.xaml.cs:</span></span>
    ```cs
    >using Windows.ApplicationModel.AppService;
    ```
3.  <span data-ttu-id="4519d-191">テキスト ボックスとボタンを MainPage.xaml に追加します。</span><span class="sxs-lookup"><span data-stu-id="4519d-191">Add a text box and a button to MainPage.xaml.</span></span>
4.  <span data-ttu-id="4519d-192">ボタンのクリック ハンドラーを追加し、ボタン ハンドラーの署名にキーワード **async** を追加します。</span><span class="sxs-lookup"><span data-stu-id="4519d-192">Add a button click handler for the button and add the keyword **async** to the button handler's signature.</span></span>
5.  <span data-ttu-id="4519d-193">ボタンのクリック ハンドラーのスタブを、次のコードで置き換えます。</span><span class="sxs-lookup"><span data-stu-id="4519d-193">Replace the stub of your button click handler with the following code.</span></span> <span data-ttu-id="4519d-194">必ず、`inventoryService` フィールドの宣言を含めます。</span><span class="sxs-lookup"><span data-stu-id="4519d-194">Be sure to include the `inventoryService` field declaration.</span></span>

   ```cs
   private AppServiceConnection inventoryService;
   private async void button_Click(object sender, RoutedEventArgs e)
   {
       // Add the connection.
       if (this.inventoryService == null)
       {
           this.inventoryService = new AppServiceConnection();

           // Here, we use the app service name defined in the app service provider's Package.appxmanifest file in the <Extension> section.
           this.inventoryService.AppServiceName = "com.microsoft.inventory";

           // Use Windows.ApplicationModel.Package.Current.Id.FamilyName within the app service provider to get this value.
           this.inventoryService.PackageFamilyName = "replace with the package family name";

           var status = await this.inventoryService.OpenAsync();
           if (status != AppServiceConnectionStatus.Success)
           {
               textBox.Text= "Failed to connect";
               return;
           }
       }

       // Call the service.
       int idx = int.Parse(textBox.Text);
       var message = new ValueSet();
       message.Add("Command", "Item");
       message.Add("ID", idx);
       AppServiceResponse response = await this.inventoryService.SendMessageAsync(message);
       string result = "";

       if (response.Status == AppServiceResponseStatus.Success)
       {
           // Get the data  that the service sent  to us.
           if (response.Message["Status"] as string == "OK")
           {
               result = response.Message["Result"] as string;
           }
       }

       message.Clear();
       message.Add("Command", "Price");
       message.Add("ID", idx);
       response = await this.inventoryService.SendMessageAsync(message);

       if (response.Status == AppServiceResponseStatus.Success)
       {
           // Get the data that the service sent to us.
           if (response.Message["Status"] as string == "OK")
           {
               result += " : Price = " + response.Message["Result"] as string;
           }
       }

       textBox.Text = result;
   }
   ```
<span data-ttu-id="4519d-195">行 `this.inventoryService.PackageFamilyName = "replace with the package family name";` のパッケージ ファミリ名を、「[サービス アプリを展開して、パッケージ ファミリ名を取得する](#deploy-the-service-app-and-get-the-package-family-name)」で得た **AppServiceProvider** プロジェクトのパッケージ ファミリ名に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="4519d-195">Replace the package family name in the line `this.inventoryService.PackageFamilyName = "replace with the package family name";` with the package family name of the **AppServiceProvider** project that you obtained above in [Deploy the service app and get the package family name](#deploy-the-service-app-and-get-the-package-family-name).</span></span>

<span data-ttu-id="4519d-196">最初に、コードによってアプリ サービスとの接続が確立されます。</span><span class="sxs-lookup"><span data-stu-id="4519d-196">The code first establishes a connection with the app service.</span></span> <span data-ttu-id="4519d-197">接続は、`this.inventoryService` を破棄するまで開いたままになります。</span><span class="sxs-lookup"><span data-stu-id="4519d-197">The connection will remain open until you dispose `this.inventoryService`.</span></span> <span data-ttu-id="4519d-198">アプリ サービス名は、AppServiceProvider プロジェクトの Package.appxmanifest ファイルに追加した **AppService Name** 属性と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4519d-198">The app service name must match the **AppService Name** attribute that you added to the AppServiceProvider project's Package.appxmanifest file.</span></span> <span data-ttu-id="4519d-199">この例では `<uap:AppService Name="com.microsoft.inventory"/>` です。</span><span class="sxs-lookup"><span data-stu-id="4519d-199">In this example, it is `<uap:AppService Name="com.microsoft.inventory"/>`.</span></span>

<span data-ttu-id="4519d-200">**message** という名前の [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) が、アプリ サービスに送信するコマンドを指定するために作成されます。</span><span class="sxs-lookup"><span data-stu-id="4519d-200">A [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) named **message** is created to specify the command that we want to send to the app service.</span></span> <span data-ttu-id="4519d-201">この例のアプリ サービスでは、2 つのアクションのどちらを実行するかをコマンドが示すことを想定しています。</span><span class="sxs-lookup"><span data-stu-id="4519d-201">The example app service expects a command to indicate which of two actions to take.</span></span> <span data-ttu-id="4519d-202">クライアント アプリのテキスト ボックスからインデックスを取得し、`Item` コマンドでサービスを呼び出して項目の説明を取得します。</span><span class="sxs-lookup"><span data-stu-id="4519d-202">We get the index from the textbox in the client app, and then call the service with the `Item` command to get the description of the item.</span></span> <span data-ttu-id="4519d-203">その後、`Price` コマンドで呼び出しを行い、項目の価格を取得します。</span><span class="sxs-lookup"><span data-stu-id="4519d-203">Then, we make the call with the `Price` command to get the item's price.</span></span> <span data-ttu-id="4519d-204">ボタンのテキストは結果に設定されています。</span><span class="sxs-lookup"><span data-stu-id="4519d-204">The button text is set to the result.</span></span>

<span data-ttu-id="4519d-205">オペレーティング システムがアプリ サービスに呼び出しを接続できたかどうかを示すのは [**AppServiceResponseStatus**](https://msdn.microsoft.com/library/windows/apps/dn921724) のみです。このため、アプリ サービスが要求を満たすことができたことを確認するために、アプリ サービスから受け取る [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) の `Status` キーをチェックします。</span><span class="sxs-lookup"><span data-stu-id="4519d-205">Because [**AppServiceResponseStatus**](https://msdn.microsoft.com/library/windows/apps/dn921724) only indicates whether the operating system was able to connect the call to the app service, we check the `Status` key in the [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) we receive from the app service to ensure that it was able to fulfill the request.</span></span>

6.  <span data-ttu-id="4519d-206">Visual Studio で、ClientApp プロジェクトをソリューション エクスプローラー ウィンドウで、スタートアップ プロジェクトとなるように設定し、プロジェクトを実行します。</span><span class="sxs-lookup"><span data-stu-id="4519d-206">In Visual Studio, set the ClientApp project to be the startup project in the Solution Explorer window and run the solution.</span></span> <span data-ttu-id="4519d-207">数値 1 をテキスト ボックスに入力し、ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="4519d-207">Enter the number 1 into the text box and click the button.</span></span> <span data-ttu-id="4519d-208">サービスから "Chair : Price = 88.99" が返されます。</span><span class="sxs-lookup"><span data-stu-id="4519d-208">You should get "Chair : Price = 88.99" back from the service.</span></span>

    ![Chair : price = 88.99 を表示するサンプル アプリ](images/appserviceclientapp.png)

<span data-ttu-id="4519d-210">アプリ サービスの呼び出しが失敗した場合は、ClientApp で次のことを確認します。</span><span class="sxs-lookup"><span data-stu-id="4519d-210">If the app service call fails, check the following in the ClientApp:</span></span>

1.  <span data-ttu-id="4519d-211">インベントリ サービスの接続に割り当てられたパッケージ ファミリ名が、AppServiceProvider アプリのパッケージ ファミリ名と一致することを確認します。</span><span class="sxs-lookup"><span data-stu-id="4519d-211">Verify that the package family name assigned to the inventory service connection matches the package family name of the AppServiceProvider app.</span></span> <span data-ttu-id="4519d-212">**button\_Click()**`this.inventoryService.PackageFamilyName = "...";` をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4519d-212">See: **button\_Click()**`this.inventoryService.PackageFamilyName = "...";`).</span></span>
2.  <span data-ttu-id="4519d-213">**button\_Click()** で、インベントリ サービスの接続に割り当てられたアプリ サービス名が、AppServiceProvider の Package.appxmanifest ファイルのアプリ サービス名と一致することを確認します。</span><span class="sxs-lookup"><span data-stu-id="4519d-213">In **button\_Click()**, verify that the app service name that is assigned to the inventory service connection matches the app service name in the AppServiceProvider's Package.appxmanifest file.</span></span> <span data-ttu-id="4519d-214">`this.inventoryService.AppServiceName = "com.microsoft.inventory";` をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4519d-214">See: `this.inventoryService.AppServiceName = "com.microsoft.inventory";`.</span></span>
3.  <span data-ttu-id="4519d-215">AppServiceProvider アプリが展開されたことを確認します (ソリューション エクスプローラーでソリューションを右クリックし、**[展開]** をクリックします)。</span><span class="sxs-lookup"><span data-stu-id="4519d-215">Ensure that the AppServiceProvider app has been deployed (In the Solution Explorer, right-click the solution and choose **Deploy**).</span></span>

## <a name="debug-the-app-service"></a><span data-ttu-id="4519d-216">アプリ サービスのデバッグ</span><span class="sxs-lookup"><span data-stu-id="4519d-216">Debug the app service</span></span>

1.  <span data-ttu-id="4519d-217">サービスを呼び出す前にアプリ サービス プロバイダーのアプリが配置される必要があるため、ソリューションがデバッグする前に展開されるようにします。</span><span class="sxs-lookup"><span data-stu-id="4519d-217">Ensure that the solution is deployed before debugging because the app service provider app must be deployed before the service can be called.</span></span> <span data-ttu-id="4519d-218">(Visual Studio で、**[ビルド] &gt; [ソリューションの配置]** の順にクリックします)。</span><span class="sxs-lookup"><span data-stu-id="4519d-218">(In Visual Studio, **Build &gt; Deploy Solution**).</span></span>
2.  <span data-ttu-id="4519d-219">ソリューション エクスプローラーで、**AppServiceProvider** プロジェクトを右クリックして、**[プロパティ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4519d-219">In the Solution Explorer, right-click the **AppServiceProvider** project and choose **Properties**.</span></span> <span data-ttu-id="4519d-220">**[デバッグ]** タブで、**[開始動作]** を **[起動しないが、開始時にマイ コードをデバッグする]** に変更します。</span><span class="sxs-lookup"><span data-stu-id="4519d-220">From the **Debug** tab, change the **Start action** to **Do not launch, but debug my code when it starts**.</span></span> <span data-ttu-id="4519d-221">(C++ を使ってアプリ サービス プロバイダーを実装した場合、**[デバッグ]** タブから **[アプリケーションの起動]** を **[いいえ]** に変更します)。</span><span class="sxs-lookup"><span data-stu-id="4519d-221">(Note, if you were using C++ to implement your app service provider, from the **Debugging** tab you would change **Launch Application** to **No**).</span></span>
3.  <span data-ttu-id="4519d-222">MyAppService プロジェクトの Class1.cs ファイルで、`OnRequestReceived()` にブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="4519d-222">In the MyAppService project, in the Class1.cs file, set a breakpoint in `OnRequestReceived()`.</span></span>
4.  <span data-ttu-id="4519d-223">AppServiceProvider プロジェクトをスタートアップ プロジェクトとなるように設定し、F5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="4519d-223">Set the AppServiceProvider project to be the startup project and press F5.</span></span>
5.  <span data-ttu-id="4519d-224">(Visual Studio からではなく) [スタート] メニューから ClientApp を起動します。</span><span class="sxs-lookup"><span data-stu-id="4519d-224">Start ClientApp from the Start menu (not from Visual Studio).</span></span>
6.  <span data-ttu-id="4519d-225">数値 1 をテキスト ボックスに入力し、ボタンを押します。</span><span class="sxs-lookup"><span data-stu-id="4519d-225">Enter the number 1 into the text box and press the button.</span></span> <span data-ttu-id="4519d-226">デバッガーは、アプリ サービス内のブレークポイントでアプリ サービスの呼び出しを停止します。</span><span class="sxs-lookup"><span data-stu-id="4519d-226">The debugger will stop in the app service call on the breakpoint in your app service.</span></span>

## <a name="debug-the-client"></a><span data-ttu-id="4519d-227">クライアントのデバッグ</span><span class="sxs-lookup"><span data-stu-id="4519d-227">Debug the client</span></span>

1.  <span data-ttu-id="4519d-228">前の手順に従って、アプリ サービスを呼び出すクライアントをデバッグします。</span><span class="sxs-lookup"><span data-stu-id="4519d-228">Follow the instructions in the preceding step to debug the client that calls the app service.</span></span>
2.  <span data-ttu-id="4519d-229">[スタート] メニューから ClientApp を起動します。</span><span class="sxs-lookup"><span data-stu-id="4519d-229">Launch ClientApp from the Start menu.</span></span>
3.  <span data-ttu-id="4519d-230">(ApplicationFrameHost.exe プロセスではなく) ClientApp.exe プロセスにデバッガーをアタッチします。</span><span class="sxs-lookup"><span data-stu-id="4519d-230">Attach the debugger to the ClientApp.exe process (not the ApplicationFrameHost.exe process).</span></span> <span data-ttu-id="4519d-231">(Visual Studio で、**[デバッグ] &gt; [プロセスにアタッチ]** の順に選びます)。</span><span class="sxs-lookup"><span data-stu-id="4519d-231">(In Visual Studio, choose **Debug &gt; Attach to Process...**.)</span></span>
4.  <span data-ttu-id="4519d-232">ClientApp プロジェクトで、**button\_Click()** にブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="4519d-232">In the ClientApp project, set a breakpoint in **button\_Click()**.</span></span>
5.  <span data-ttu-id="4519d-233">ClientApp のテキスト ボックスに数値 1 を入力してボタンをクリックすると、クライアントとアプリ サービスの両方のブレークポイントがヒットするようになります。</span><span class="sxs-lookup"><span data-stu-id="4519d-233">The breakpoints in both the client and the app service will now be hit when you enter the number 1 into the text box of the ClientApp and click the button.</span></span>

## <a name="general-app-service-troubleshooting"></a><span data-ttu-id="4519d-234">一般的なアプリ サービスのトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="4519d-234">General app service troubleshooting</span></span> ##

<span data-ttu-id="4519d-235">アプリ サービスに接続しようとして **AppUnavailable** 状態が発生した場合、以下を確認します。</span><span class="sxs-lookup"><span data-stu-id="4519d-235">If you encounter a **AppUnavailable** status after trying to connect to an app service, check the following:</span></span>

- <span data-ttu-id="4519d-236">アプリ サービス プロバイダー プロジェクトとアプリ サービス プロジェクトが展開されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="4519d-236">Ensure that the app service provider project and app service project are deployed.</span></span> <span data-ttu-id="4519d-237">クライアントを実行する前に、両方が展開されている必要があります。展開されていない場合、クライアントには接続先がありません。</span><span class="sxs-lookup"><span data-stu-id="4519d-237">Both need to be deployed before running the client because otherwise the client won't have anything to connect to.</span></span> <span data-ttu-id="4519d-238">Visual Studio から **[ビルド]** > **[ソリューションの配置]** で展開できます。</span><span class="sxs-lookup"><span data-stu-id="4519d-238">You can deploy from Visual Studio by using **Build** > **Deploy Solution**.</span></span>
- <span data-ttu-id="4519d-239">ソリューション エクスプローラーを使って、アプリ サービス プロバイダー プロジェクトで、アプリ サービスを実装したプロジェクトへの、プロジェクト間の参照が設定されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="4519d-239">In the solution explorer, ensure that your app service provider project has a project-to-project reference to the project that implements the app service.</span></span>
- <span data-ttu-id="4519d-240">`<Extensions>` エントリとその子要素が、アプリ サービス プロバイダー プロジェクトに属する Package.appxmanifest ファイルに追加されていることを確認します。詳しくは上述の「[package.appxmanifest へのアプリ サービスの拡張機能の追加](#appxmanifest)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4519d-240">Verify that the `<Extensions>` entry, and its child elements, have been added to the Package.appxmanifest file belonging to the app service provider project as specified above in [Add an app service extension to package.appxmanifest](#appxmanifest).</span></span>
- <span data-ttu-id="4519d-241">アプリ サービス プロバイダーを呼び出すクライアントの `AppServiceConnection.AppServiceName` 文字列が、アプリ サービス プロバイダー プロジェクトの Package.appxmanifest ファイルで指定された `<uap3:AppService Name="..." />` と一致していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="4519d-241">Ensure that the `AppServiceConnection.AppServiceName` string in your client that calls the app service provider matches the `<uap3:AppService Name="..." />` specified in the app service provider project's Package.appxmanifest file.</span></span>
- <span data-ttu-id="4519d-242">`AppServiceConnection.PackageFamilyName` が、アプリ サービス プロバイダーのコンポーネントのパッケージ ファミリ名と一致していることを確認します。詳しくは上述の「[package.appxmanifest へのアプリ サービスの拡張機能の追加](#appxmanifest)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4519d-242">Ensure that the `AppServiceConnection.PackageFamilyName` matches the package family name of the app service provider component as specified above in [Add an app service extension to package.appxmanifest](#appxmanifest)</span></span>
- <span data-ttu-id="4519d-243">この例のようなアウトプロセスのアプリ サービスでは、アプリ サービス プロバイダー プロジェクトの Package.appxmanifest ファイルの `<uap:Extension ...>` 要素で指定された `EntryPoint` が、アプリ サービス プロジェクトで `IBackgroundTask` を実装する公開クラスの名前空間とクラスの名前と一致していることを検証します。</span><span class="sxs-lookup"><span data-stu-id="4519d-243">For out-of-proc app services such as the one in this example, validate that the `EntryPoint` specified in the `<uap:Extension ...>` element of your app service provider project's Package.appxmanifest file matches the namespace and class name of the public class that implements `IBackgroundTask` in your app service project.</span></span>

### <a name="troubleshoot-debugging"></a><span data-ttu-id="4519d-244">デバッグのトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="4519d-244">Troubleshoot debugging</span></span>

<span data-ttu-id="4519d-245">アプリ サービス プロバイダーまたはアプリ サービス プロジェクトのブレークポイントでデバッガーが停止しない場合は、以下を確認します。</span><span class="sxs-lookup"><span data-stu-id="4519d-245">If the debugger does not stop at breakpoints in your app service provider or app service projects, check the following:</span></span>

- <span data-ttu-id="4519d-246">アプリ サービス プロバイダー プロジェクトとアプリ サービス プロジェクトが展開されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="4519d-246">Ensure that the app service provider project and app service project are deployed.</span></span> <span data-ttu-id="4519d-247">クライアントを実行する前に、両方が展開されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="4519d-247">Both need to be deployed before running the client.</span></span> <span data-ttu-id="4519d-248">Visual Studio から **[ビルド]** > **[ソリューションの配置]** で展開できます。</span><span class="sxs-lookup"><span data-stu-id="4519d-248">You can deploy them from Visual Studio by using **Build** > **Deploy Solution**.</span></span>
- <span data-ttu-id="4519d-249">デバッグするプロジェクトがスタートアップ プロジェクトとして設定されていることを確認します。そのプロジェクトのデバッグ プロパティを確認し、F5 キーが押されたときにプロジェクトを実行しないように設定されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="4519d-249">Ensure that the project you want to debug is set as the startup project and that the debugging properties for that project are set to not run the project when F5 is pressed.</span></span> <span data-ttu-id="4519d-250">プロジェクトを右クリックし、**[プロパティ]**、**[デバッグ]** (または C++ では **[デバッグ]**) の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="4519d-250">Right-click the project, then click **Properties**, and then **Debug** (or **Debugging** in C++).</span></span> <span data-ttu-id="4519d-251">C# では、**[開始動作]** を **[起動しないが、開始時にマイ コードをデバッグする]** に設定します。</span><span class="sxs-lookup"><span data-stu-id="4519d-251">In C#, change the **Start action** to **Do not launch, but debug my code when it starts**.</span></span> <span data-ttu-id="4519d-252">C++ では、**[アプリケーションの起動]** を **[いいえ]** に設定します。</span><span class="sxs-lookup"><span data-stu-id="4519d-252">In C++, set **Launch Application** to **No**.</span></span>

## <a name="remarks"></a><span data-ttu-id="4519d-253">注釈</span><span class="sxs-lookup"><span data-stu-id="4519d-253">Remarks</span></span>

<span data-ttu-id="4519d-254">この例では、バックグラウンド タスクとして実行されるアプリ サービスを作成して、それを別のアプリから呼び出す概要を示しています。</span><span class="sxs-lookup"><span data-stu-id="4519d-254">This example provides an introduction to creating an app service that runs as a background task and calling it from another app.</span></span> <span data-ttu-id="4519d-255">重要な点は、アプリ サービスをホストするためのバックグラウンド タスクの作成、アプリ サービス プロバイダーのアプリの Package.appxmanifest ファイルへの windows.appservice 拡張機能の追加、クライアント アプリから接続するためのアプリ サービス プロバイダーのアプリのパッケージ ファミリ名の取得、アプリ サービス プロバイダー プロジェクトからアプリ サービス プロジェクトへのプロジェクト間の参照の追加、[**Windows.ApplicationModel.AppService.AppServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn921704) を使ったサービスの呼び出しです。</span><span class="sxs-lookup"><span data-stu-id="4519d-255">The key things to note are the creation of a background task to host the app service, the addition of the windows.appservice extension to the app service provider app's Package.appxmanifest file, obtaining the package family name of the app service provider app so that we can connect to it from the client app, adding a project-to-project reference from the app service provider project to the app service project, and using [**Windows.ApplicationModel.AppService.AppServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn921704) to call the service.</span></span>

## <a name="full-code-for-myappservice"></a><span data-ttu-id="4519d-256">MyAppService の完全なコード</span><span class="sxs-lookup"><span data-stu-id="4519d-256">Full code for MyAppService</span></span>

```cs
using System;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;

namespace MyAppService
{
    public sealed class Inventory : IBackgroundTask
    {
        private BackgroundTaskDeferral backgroundTaskDeferral;
        private AppServiceConnection appServiceconnection;
        private String[] inventoryItems = new string[] { "Robot vacuum", "Chair" };
        private double[] inventoryPrices = new double[] { 129.99, 88.99 };

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            this.backgroundTaskDeferral = taskInstance.GetDeferral(); // Get a deferral so that the service isn't terminated.
            taskInstance.Canceled += OnTaskCanceled; // Associate a cancellation handler with the background task.

            // Retrieve the app service connection and set up a listener for incoming app service requests.
            var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            appServiceconnection = details.AppServiceConnection;
            appServiceconnection.RequestReceived += OnRequestReceived;
        }

        private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            // Get a deferral because we use an awaitable API below to respond to the message
            // and we don't want this call to get cancelled while we are waiting.
            var messageDeferral = args.GetDeferral();

            ValueSet message = args.Request.Message;
            ValueSet returnData = new ValueSet();

            string command = message["Command"] as string;
            int? inventoryIndex = message["ID"] as int?;

            if (inventoryIndex.HasValue &&
                 inventoryIndex.Value >= 0 &&
                 inventoryIndex.Value < inventoryItems.GetLength(0))
            {
                switch (command)
                {
                    case "Price":
                        {
                            returnData.Add("Result", inventoryPrices[inventoryIndex.Value]);
                            returnData.Add("Status", "OK");
                            break;
                        }

                    case "Item":
                        {
                            returnData.Add("Result", inventoryItems[inventoryIndex.Value]);
                            returnData.Add("Status", "OK");
                            break;
                        }

                    default:
                        {
                            returnData.Add("Status", "Fail: unknown command");
                            break;
                        }
                }
            }
            else
            {
                returnData.Add("Status", "Fail: Index out of range");
            }

            await args.Request.SendResponseAsync(returnData); // Return the data to the caller.
            // Complete the deferral so that the platform knows that we're done responding to the app service call.
            // Note for error handling: this must be called even if SendResponseAsync() throws an exception.
            messageDeferral.Complete();
        }


        private void OnTaskCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            if (this.backgroundTaskDeferral != null)
            {
                // Complete the service deferral.
                this.backgroundTaskDeferral.Complete();
            }
        }
    }
}
```

## <a name="related-topics"></a><span data-ttu-id="4519d-257">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4519d-257">Related topics</span></span>

* [<span data-ttu-id="4519d-258">ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する</span><span class="sxs-lookup"><span data-stu-id="4519d-258">Convert an app service to run in the same process as its host app</span></span>](convert-app-service-in-process.md)
* [<span data-ttu-id="4519d-259">バックグラウンド タスクによるアプリのサポート</span><span class="sxs-lookup"><span data-stu-id="4519d-259">Support your app with background tasks</span></span>](support-your-app-with-background-tasks.md)
* [<span data-ttu-id="4519d-260">アプリ サービスのコード サンプル (C#、C++、および VB)</span><span class="sxs-lookup"><span data-stu-id="4519d-260">App service code sample (C#, C++, and VB)</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices)
