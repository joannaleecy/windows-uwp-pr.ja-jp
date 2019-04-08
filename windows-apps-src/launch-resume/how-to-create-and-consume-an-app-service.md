---
title: アプリ サービスの作成と利用
description: 他のユニバーサル Windows プラットフォーム (UWP) アプリにサービスを提供できる UWP アプリを作成する方法と、それらのサービスを利用する方法について説明します。
ms.assetid: 6E48B8B6-D3BF-4AE2-85FB-D463C448C9D3
keywords: アプリへの通信、IPC、メッセージング、バック グラウンドの通信、アプリへのアプリ サービス バック グラウンドのプロセス間の通信
ms.date: 01/16/2019
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 96ecad8494ad82dc4927b3675ad322f07a8ca7f3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57643577"
---
# <a name="create-and-consume-an-app-service"></a><span data-ttu-id="39baf-104">アプリ サービスの作成と利用</span><span class="sxs-lookup"><span data-stu-id="39baf-104">Create and consume an app service</span></span>

<span data-ttu-id="39baf-105">アプリ サービスは、他の UWP アプリにサービスを提供する UWP アプリです。</span><span class="sxs-lookup"><span data-stu-id="39baf-105">App services are UWP apps that provide services to other UWP apps.</span></span> <span data-ttu-id="39baf-106">これは、デバイス上にある Web サービスのようなものです。</span><span class="sxs-lookup"><span data-stu-id="39baf-106">They are analogous to web services, on a device.</span></span> <span data-ttu-id="39baf-107">アプリ サービスは、バック グラウンド タスクとしてホスト アプリで実行され、そのサービスを他のアプリに提供することができます。</span><span class="sxs-lookup"><span data-stu-id="39baf-107">An app service runs as a background task in the host app and can provide its service to other apps.</span></span> <span data-ttu-id="39baf-108">たとえば、アプリ サービスによって、他のアプリで使用できるバー コード スキャナー サービスが提供される場合があります。</span><span class="sxs-lookup"><span data-stu-id="39baf-108">For example, an app service might provide a bar code scanner service that other apps could use.</span></span> <span data-ttu-id="39baf-109">また、アプリのエンタープライズ スイートに共通のスペル チェック アプリ サービスを備えておき、そのサービスを同じスイート内の他のアプリから利用可能にする場合もあるでしょう。</span><span class="sxs-lookup"><span data-stu-id="39baf-109">Or perhaps an Enterprise suite of apps has a common spell checking app service that is available to the other apps in the suite.</span></span>  <span data-ttu-id="39baf-110">アプリ サービスでは、同じデバイス上のアプリから呼び出せる UI を持たないサービスを作成できます。また、Windows 10 バージョン 1607 以降では、リモート デバイスからも呼び出せます。</span><span class="sxs-lookup"><span data-stu-id="39baf-110">App services let you create UI-less services that apps can call on the same device, and starting with Windows 10, version 1607, on remote devices.</span></span>

<span data-ttu-id="39baf-111">Windows 10 バージョン 1607 以降では、ホスト アプリと同じプロセスで実行されるアプリ サービスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="39baf-111">Starting in Windows 10, version 1607, you can create app services that run in the same process as the host app.</span></span> <span data-ttu-id="39baf-112">この記事では、別のバックグラウンド プロセスで実行されるアプリ サービスの作成と利用に重点を置いて説明します。</span><span class="sxs-lookup"><span data-stu-id="39baf-112">This article focuses on creating and consuming an app service that runs in a separate background process.</span></span> <span data-ttu-id="39baf-113">プロバイダーと同じプロセスでアプリ サービスを実行する詳細については、「[ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する](convert-app-service-in-process.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="39baf-113">See [Convert an app service to run in the same process as its host app](convert-app-service-in-process.md) for more details about running an app service in the same process as the provider.</span></span>

<span data-ttu-id="39baf-114">アプリ サービスのコード サンプルについては、「[ユニバーサル Windows プラットフォーム (UWP) アプリのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="39baf-114">For an app service code sample, see [Universal Windows Platform (UWP) app samples](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices).</span></span>

## <a name="create-a-new-app-service-provider-project"></a><span data-ttu-id="39baf-115">新しいアプリ サービス プロバイダー プロジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="39baf-115">Create a new app service provider project</span></span>

<span data-ttu-id="39baf-116">このトピックでは、わかりやすくするためにすべてを 1 つのソリューションで作成します。</span><span class="sxs-lookup"><span data-stu-id="39baf-116">In this how-to, we'll create everything in one solution for simplicity.</span></span>

1. <span data-ttu-id="39baf-117">Visual Studio 2015 以降では、新しい UWP アプリ プロジェクトを作成し、名前**AppServiceProvider**します。</span><span class="sxs-lookup"><span data-stu-id="39baf-117">In Visual Studio 2015 or later, create a new UWP app project and name it **AppServiceProvider**.</span></span>
    1. <span data-ttu-id="39baf-118">選択**ファイル > 新規 > プロジェクト.**</span><span class="sxs-lookup"><span data-stu-id="39baf-118">Select **File > New > Project...**</span></span> 
    2. <span data-ttu-id="39baf-119">**新しいプロジェクト**ダイアログ ボックスで、**インストール済み > Visual C# > 空のアプリ (ユニバーサル Windows)** します。</span><span class="sxs-lookup"><span data-stu-id="39baf-119">In the **New Project** dialog box, select **Installed > Visual C# > Blank App (Universal Windows)**.</span></span> <span data-ttu-id="39baf-120">これは、他の UWP アプリがアプリ サービスを利用できるアプリとなります。</span><span class="sxs-lookup"><span data-stu-id="39baf-120">This will be the app that makes the app service available to other UWP apps.</span></span>
    3. <span data-ttu-id="39baf-121">プロジェクトに名前を**AppServiceProvider**の場所の選択およびクリックして**OK**します。</span><span class="sxs-lookup"><span data-stu-id="39baf-121">Name the project **AppServiceProvider**, choose a location for it, and click **OK**.</span></span>

2. <span data-ttu-id="39baf-122">選択を求められたら、**ターゲット**と**最小バージョン**、プロジェクトの選択には少なくとも**10.0.14393**します。</span><span class="sxs-lookup"><span data-stu-id="39baf-122">When asked to select a **Target** and **Minimum version** for the project, select at least **10.0.14393**.</span></span> <span data-ttu-id="39baf-123">新たに使用する場合**SupportsMultipleInstances**属性に、Visual Studio 2017 とターゲットを使用する必要があります**10.0.15063 追加されたため**(**Windows 10 Creators Update**) またはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="39baf-123">If you want to use the new **SupportsMultipleInstances** attribute, you must be using Visual Studio 2017 and target **10.0.15063** (**Windows 10 Creators Update**) or higher.</span></span>

<span id="appxmanifest"/>

## <a name="add-an-app-service-extension-to-packageappxmanifest"></a><span data-ttu-id="39baf-124">Package.appxmanifest にアプリ サービスの拡張機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="39baf-124">Add an app service extension to Package.appxmanifest</span></span>

<span data-ttu-id="39baf-125">**AppServiceProvider**プロジェクトを開き、 **Package.appxmanifest**ファイルをテキスト エディターで。</span><span class="sxs-lookup"><span data-stu-id="39baf-125">In the **AppServiceProvider** project, open the **Package.appxmanifest** file in a text editor:</span></span> 

1. <span data-ttu-id="39baf-126">を右クリックし、**ソリューション エクスプ ローラー**します。</span><span class="sxs-lookup"><span data-stu-id="39baf-126">Right-click it in the **Solution Explorer**.</span></span> 
2. <span data-ttu-id="39baf-127">選択**プログラムから開く**します。</span><span class="sxs-lookup"><span data-stu-id="39baf-127">Select **Open With**.</span></span> 
3. <span data-ttu-id="39baf-128">選択**XML (テキスト) エディター**します。</span><span class="sxs-lookup"><span data-stu-id="39baf-128">Select **XML (Text) Editor**.</span></span> 

<span data-ttu-id="39baf-129">次の追加`AppService`内に拡張機能、`<Application>`要素。</span><span class="sxs-lookup"><span data-stu-id="39baf-129">Add the following `AppService` extension inside the `<Application>` element.</span></span> <span data-ttu-id="39baf-130">この例では、`com.microsoft.inventory` サービスをアドバタイズし、このアプリをアプリ サービス プロバイダーとして識別します。</span><span class="sxs-lookup"><span data-stu-id="39baf-130">This example advertises the `com.microsoft.inventory` service and is what identifies this app as an app service provider.</span></span> <span data-ttu-id="39baf-131">実際のサービスは、バックグラウンド タスクとして実装されます。</span><span class="sxs-lookup"><span data-stu-id="39baf-131">The actual service will be implemented as a background task.</span></span> <span data-ttu-id="39baf-132">アプリ サービスのプロジェクトは、サービスを他のアプリに公開します。</span><span class="sxs-lookup"><span data-stu-id="39baf-132">The app service project exposes the service to other apps.</span></span> <span data-ttu-id="39baf-133">サービス名には逆のドメイン名スタイルを使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="39baf-133">We recommend using a reverse domain name style for the service name.</span></span>

<span data-ttu-id="39baf-134">`xmlns:uap4` 名前空間のプレフィックスと `uap4:SupportsMultipleInstances` 属性は、Windows SDK バージョン 10.0.15063 以降をターゲットとしている場合のみ有効です。</span><span class="sxs-lookup"><span data-stu-id="39baf-134">Note that the `xmlns:uap4` namespace prefix and the `uap4:SupportsMultipleInstances` attribute are only valid if you are targeting Windows SDK version 10.0.15063 or higher.</span></span> <span data-ttu-id="39baf-135">以前のバージョンの SDK をターゲットとしている場合には、それらは安全に削除できます。</span><span class="sxs-lookup"><span data-stu-id="39baf-135">You can safely remove them if you are targeting older SDK versions.</span></span>

``` xml
<Package
    ...
    xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
    xmlns:uap4="http://schemas.microsoft.com/appx/manifest/uap/windows10/4"
    ...
    <Applications>
        <Application Id="AppServiceProvider.App"
          Executable="$targetnametoken$.exe"
          EntryPoint="AppServiceProvider.App">
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

<span data-ttu-id="39baf-136">`Category`属性は、アプリのサービス プロバイダーとしては、このアプリケーションを識別します。</span><span class="sxs-lookup"><span data-stu-id="39baf-136">The `Category` attribute identifies this application as an app service provider.</span></span>

<span data-ttu-id="39baf-137">`EntryPoint`属性は、次を実装すると、サービスを実装する名前空間で修飾クラスを識別します。</span><span class="sxs-lookup"><span data-stu-id="39baf-137">The `EntryPoint` attribute identifies the namespace qualified class that implements the service, which we'll implement next.</span></span>

<span data-ttu-id="39baf-138">`SupportsMultipleInstances`属性は、app service が呼び出されるたびに実行する新しいプロセスを示します。</span><span class="sxs-lookup"><span data-stu-id="39baf-138">The `SupportsMultipleInstances` attribute indicates that each time the app service is called that it should run in a new process.</span></span> <span data-ttu-id="39baf-139">これは必要ありませんが、その機能を必要とし、10.0.15063 追加されたため、対象とする場合は、使用する SDK (**Windows 10 Creators Update**) またはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="39baf-139">This is not required but is available to you if you need that functionality and are targeting the 10.0.15063 SDK (**Windows 10 Creators Update**) or higher.</span></span> <span data-ttu-id="39baf-140">また、先頭に `uap4` 名前空間を付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="39baf-140">It also should be prefaced by the `uap4` namespace.</span></span>

## <a name="create-the-app-service"></a><span data-ttu-id="39baf-141">アプリ サービスの作成</span><span class="sxs-lookup"><span data-stu-id="39baf-141">Create the app service</span></span>

1.  <span data-ttu-id="39baf-142">アプリ サービスは、バックグラウンド タスクとして実装できます。</span><span class="sxs-lookup"><span data-stu-id="39baf-142">An app service can be implemented as a background task.</span></span> <span data-ttu-id="39baf-143">これにより、フォアグラウンド アプリケーションは、別のアプリケーションのアプリ サービスを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="39baf-143">This enables a foreground application to invoke an app service in another application.</span></span> <span data-ttu-id="39baf-144">バック グラウンド タスクとして、app service を作成するには、ソリューションに新しい Windows ランタイム コンポーネント プロジェクトを追加 (**ファイル&gt;追加&gt;新しいプロジェクト**) という名前の**MyAppService**します。</span><span class="sxs-lookup"><span data-stu-id="39baf-144">To create an app service as a background task, add a new Windows Runtime Component project to the solution (**File &gt; Add &gt; New Project**) named **MyAppService**.</span></span> <span data-ttu-id="39baf-145">**新しいプロジェクトの追加** ダイアログ ボックスで、選択**インストール済み > Visual C# > Windows ランタイム コンポーネント (ユニバーサル Windows)** します。</span><span class="sxs-lookup"><span data-stu-id="39baf-145">In the **Add New Project** dialog box, choose **Installed > Visual C# > Windows Runtime Component (Universal Windows)**.</span></span>
2.  <span data-ttu-id="39baf-146">**AppServiceProvider**プロジェクトに、新しいプロジェクト間参照を追加**MyAppService**プロジェクト (で、**ソリューション エクスプ ローラー**、右クリックし、 **AppServiceProvider**プロジェクト >**追加** > **参照** > **プロジェクト** >  **ソリューション**、 **MyAppService** > **OK**)。</span><span class="sxs-lookup"><span data-stu-id="39baf-146">In the **AppServiceProvider** project, add a project-to-project reference to the new **MyAppService** project (in the **Solution Explorer**, right-click on the **AppServiceProvider** project > **Add** > **Reference** > **Projects** > **Solution**, select **MyAppService** > **OK**).</span></span> <span data-ttu-id="39baf-147">参照を追加しない場合でも、アプリ サービスは実行時に接続されないため、この手順は重要です。</span><span class="sxs-lookup"><span data-stu-id="39baf-147">This step is critical because if you do not add the reference, the app service won't connect at runtime.</span></span>
3.  <span data-ttu-id="39baf-148">**MyAppService**プロジェクトで、次の追加**を使用して**ステートメントの先頭に**Class1.cs**:</span><span class="sxs-lookup"><span data-stu-id="39baf-148">In the **MyAppService** project, add the following **using** statements to the top of **Class1.cs**:</span></span>
    ```cs
    using Windows.ApplicationModel.AppService;
    using Windows.ApplicationModel.Background;
    using Windows.Foundation.Collections;
    ```

4.  <span data-ttu-id="39baf-149">名前を変更**Class1.cs**に**Inventory.cs**のスタブのコードに置き換えます**Class1**という名前の新しいバック グラウンド タスク クラスを使用して**インベントリ**:</span><span class="sxs-lookup"><span data-stu-id="39baf-149">Rename **Class1.cs** to **Inventory.cs**, and replace the stub code for **Class1** with a new background task class named **Inventory**:</span></span>

    ```cs
    public sealed class Inventory : IBackgroundTask
    {
        private BackgroundTaskDeferral backgroundTaskDeferral;
        private AppServiceConnection appServiceconnection;
        private String[] inventoryItems = new string[] { "Robot vacuum", "Chair" };
        private double[] inventoryPrices = new double[] { 129.99, 88.99 };

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // Get a deferral so that the service isn't terminated.
            this.backgroundTaskDeferral = taskInstance.GetDeferral();

            // Associate a cancellation handler with the background task.
            taskInstance.Canceled += OnTaskCanceled;

            // Retrieve the app service connection and set up a listener for incoming app service requests.
            var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            appServiceconnection = details.AppServiceConnection;
            appServiceconnection.RequestReceived += OnRequestReceived;
        }

        private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            // This function is called when the app service receives a request.
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

    <span data-ttu-id="39baf-150">このクラスは、アプリ サービスが作業を実行する場所です。</span><span class="sxs-lookup"><span data-stu-id="39baf-150">This class is where the app service will do its work.</span></span>

    <span data-ttu-id="39baf-151">**実行**バック グラウンド タスクが作成されるときに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="39baf-151">**Run** is called when the background task is created.</span></span> <span data-ttu-id="39baf-152">バックグラウンド タスクは **Run** が完了すると終了するため、バックグラウンド タスクが要求に引き続き対応できるように、コードは保留されます。</span><span class="sxs-lookup"><span data-stu-id="39baf-152">Because background tasks are terminated after **Run** completes, the code takes out a deferral so that the background task will stay up to serve requests.</span></span> <span data-ttu-id="39baf-153">バック グラウンド タスクとして実装されている app service は、その時間枠内でもう一度呼び出されたか、遅延を除外しない限り、呼び出しを受信した後、約 30 秒間有効で維持されます。App service は、呼び出し元と同じプロセスで実装されている場合、app service の有効期間は、呼び出し元の有効期間に関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="39baf-153">An app service that is implemented as a background task will stay alive for about 30 seconds after it receives a call unless it is called again within that time window or a deferral is taken out. If the app service is implemented in the same process as the caller, the lifetime of the app service is tied to the lifetime of the caller.</span></span>

    <span data-ttu-id="39baf-154">アプリ サービスの有効期間は、呼び出し元に依存します。</span><span class="sxs-lookup"><span data-stu-id="39baf-154">The lifetime of the app service depends on the caller:</span></span>

    * <span data-ttu-id="39baf-155">呼び出し元がフォア グラウンドである場合は、アプリ サービスの有効期間は、呼び出し元の場合と同じです。</span><span class="sxs-lookup"><span data-stu-id="39baf-155">If the caller is in the foreground, the app service lifetime is the same as the caller.</span></span>
    * <span data-ttu-id="39baf-156">呼び出し元は、バック グラウンドでは、app service は 30 秒の実行を取得します。</span><span class="sxs-lookup"><span data-stu-id="39baf-156">If the caller is in the background, the app service gets 30 seconds to run.</span></span> <span data-ttu-id="39baf-157">保留されると、1 回 5 秒追加されます。</span><span class="sxs-lookup"><span data-stu-id="39baf-157">Taking out a deferral provides an additional one time 5 seconds.</span></span>

    <span data-ttu-id="39baf-158">**OnTaskCanceled**タスクが取り消されたときに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="39baf-158">**OnTaskCanceled** is called when the task is canceled.</span></span> <span data-ttu-id="39baf-159">クライアント アプリを破棄するときにタスクが取り消された、 [AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/dn921704)、クライアント アプリケーションが中断された、OS がシャット ダウンしたり、スリープ状態になり、または OS のタスクを実行するリソースが不足します。</span><span class="sxs-lookup"><span data-stu-id="39baf-159">The task is canceled when the client app disposes the [AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/dn921704), the client app is suspended, the OS is shut down or sleeps, or the OS runs out of resources to run the task.</span></span>

## <a name="write-the-code-for-the-app-service"></a><span data-ttu-id="39baf-160">アプリ サービスのコードを記述する</span><span class="sxs-lookup"><span data-stu-id="39baf-160">Write the code for the app service</span></span>

<span data-ttu-id="39baf-161">**OnRequestReceived** app service のコードの行き先が。</span><span class="sxs-lookup"><span data-stu-id="39baf-161">**OnRequestReceived** is where the code for the app service goes.</span></span> <span data-ttu-id="39baf-162">スタブを置換**OnRequestReceived**で**MyAppService**の**Inventory.cs**この例のコードを使用します。</span><span class="sxs-lookup"><span data-stu-id="39baf-162">Replace the stub **OnRequestReceived** in **MyAppService**'s **Inventory.cs** with the code from this example.</span></span> <span data-ttu-id="39baf-163">このコードは、インベントリの項目のインデックスを取得し、コマンド文字列と共にサービスに渡して、指定したインベントリ項目の名前と価格を取得します。</span><span class="sxs-lookup"><span data-stu-id="39baf-163">This code gets an index for an inventory item and passes it, along with a command string, to the service to retrieve the name and the price of the specified inventory item.</span></span> <span data-ttu-id="39baf-164">独自のプロジェクトには、エラー処理コードを追加します。</span><span class="sxs-lookup"><span data-stu-id="39baf-164">For your own projects, add error handling code.</span></span>

```cs
private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
{
    // Get a deferral because we use an awaitable API below to respond to the message
    // and we don't want this call to get canceled while we are waiting.
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

    try
    {
        // Return the data to the caller.
        await args.Request.SendResponseAsync(returnData);
    }
    catch (Exception e)
    {
        // Your exception handling code here.
    }
    finally
    {
        // Complete the deferral so that the platform knows that we're done responding to the app service call.
        // Note for error handling: this must be called even if SendResponseAsync() throws an exception.
        messageDeferral.Complete();
    }
}
```

<span data-ttu-id="39baf-165">なお**OnRequestReceived**は**async** 、この待機可能なメソッドを呼び出すため、 [SendResponseAsync](https://msdn.microsoft.com/library/windows/apps/dn921722)この例では。</span><span class="sxs-lookup"><span data-stu-id="39baf-165">Note that **OnRequestReceived** is **async** because we make an awaitable method call to [SendResponseAsync](https://msdn.microsoft.com/library/windows/apps/dn921722) in this example.</span></span>

<span data-ttu-id="39baf-166">サービスが使用できるように、遅延が実行される**async**メソッド、 **OnRequestReceived**ハンドラー。</span><span class="sxs-lookup"><span data-stu-id="39baf-166">A deferral is taken so that the service can use **async** methods in the **OnRequestReceived** handler.</span></span> <span data-ttu-id="39baf-167">これにより、**OnRequestReceived** への呼び出しは、メッセージの処理が完了するまで完了しません。</span><span class="sxs-lookup"><span data-stu-id="39baf-167">It ensures that the call to **OnRequestReceived** does not complete until it is done processing the message.</span></span>  <span data-ttu-id="39baf-168">[SendResponseAsync](https://msdn.microsoft.com/library/windows/apps/dn921722)呼び出し元に結果を送信します。</span><span class="sxs-lookup"><span data-stu-id="39baf-168">[SendResponseAsync](https://msdn.microsoft.com/library/windows/apps/dn921722) sends the result to the caller.</span></span> <span data-ttu-id="39baf-169">**SendResponseAsync** は、呼び出しの完了時に通知しません。</span><span class="sxs-lookup"><span data-stu-id="39baf-169">**SendResponseAsync** does not signal the completion of the call.</span></span> <span data-ttu-id="39baf-170">信号を遅延の完了が[SendMessageAsync](https://msdn.microsoft.com/library/windows/apps/dn921712)を**OnRequestReceived**が完了します。</span><span class="sxs-lookup"><span data-stu-id="39baf-170">It is the completion of the deferral that signals to [SendMessageAsync](https://msdn.microsoft.com/library/windows/apps/dn921712) that **OnRequestReceived** has completed.</span></span> <span data-ttu-id="39baf-171">呼び出し**SendResponseAsync**いても、遅延を完了する必要がありますので、try/finally ブロックでラップされて**SendResponseAsync**例外をスローします。</span><span class="sxs-lookup"><span data-stu-id="39baf-171">The call to **SendResponseAsync** is wrapped in a try/finally block because you must complete the deferral even if **SendResponseAsync** throws an exception.</span></span>

<span data-ttu-id="39baf-172">App services の使用[ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131)情報を交換するオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="39baf-172">App services use [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131) objects to exchange information.</span></span> <span data-ttu-id="39baf-173">渡すことができるデータのサイズは、システム リソースによってのみ制限されます。</span><span class="sxs-lookup"><span data-stu-id="39baf-173">The size of the data you may pass is only limited by system resources.</span></span> <span data-ttu-id="39baf-174">**ValueSet** で使うことができる定義済みのキーはありません。</span><span class="sxs-lookup"><span data-stu-id="39baf-174">There are no predefined keys for you to use in your **ValueSet**.</span></span> <span data-ttu-id="39baf-175">アプリ サービスのプロトコルの定義に使うキーの値を決定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="39baf-175">You must determine which key values you will use to define the protocol for your app service.</span></span> <span data-ttu-id="39baf-176">呼び出し元は、そのプロトコルを念頭に置いて記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="39baf-176">The caller must be written with that protocol in mind.</span></span> <span data-ttu-id="39baf-177">この例では、アプリ サービスがインベントリ項目またはその価格の名前を提供するかどうかを示す値を持つ、`Command` という名前のキーを選びました。</span><span class="sxs-lookup"><span data-stu-id="39baf-177">In this example, we have chosen a key named `Command` that has a value that indicates whether we want the app service to provide the name of the inventory item or its price.</span></span> <span data-ttu-id="39baf-178">インベントリ名のインデックスは、`ID` キーに保存されています。</span><span class="sxs-lookup"><span data-stu-id="39baf-178">The index of the inventory name is stored under the `ID` key.</span></span> <span data-ttu-id="39baf-179">戻り値は `Result` キーに保存されます。</span><span class="sxs-lookup"><span data-stu-id="39baf-179">The return value is stored under the `Result` key.</span></span>

<span data-ttu-id="39baf-180">[AppServiceClosedStatus](https://msdn.microsoft.com/library/windows/apps/dn921703)列挙型は、app service への呼び出しが成功または失敗するかどうかを示すために、呼び出し元に返されます。</span><span class="sxs-lookup"><span data-stu-id="39baf-180">An [AppServiceClosedStatus](https://msdn.microsoft.com/library/windows/apps/dn921703) enum is returned to the caller to indicate whether the call to the app service succeeded or failed.</span></span> <span data-ttu-id="39baf-181">アプリ サービスへの呼び出しが失敗する例として、OS がサービスのエンドポイントを中止した、リソースが超過したなどがあります。</span><span class="sxs-lookup"><span data-stu-id="39baf-181">An example of how the call to the app service could fail is if the OS aborts the service endpoint because its resources have been exceeded.</span></span> <span data-ttu-id="39baf-182">使用して追加のエラー情報を返すことができます、 [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131)します。</span><span class="sxs-lookup"><span data-stu-id="39baf-182">You can return additional error information via the [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131).</span></span> <span data-ttu-id="39baf-183">この例では、`Status` という名前のキーを使って、より詳細なエラー情報を呼び出し元に返します。</span><span class="sxs-lookup"><span data-stu-id="39baf-183">In this example, we use a key named `Status` to return more detailed error information to the caller.</span></span>

<span data-ttu-id="39baf-184">呼び出し[SendResponseAsync](https://msdn.microsoft.com/library/windows/apps/dn921722)を返します、 [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131)呼び出し元にします。</span><span class="sxs-lookup"><span data-stu-id="39baf-184">The call to [SendResponseAsync](https://msdn.microsoft.com/library/windows/apps/dn921722) returns the [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131) to the caller.</span></span>

## <a name="deploy-the-service-app-and-get-the-package-family-name"></a><span data-ttu-id="39baf-185">サービス アプリを展開して、パッケージ ファミリ名を取得する</span><span class="sxs-lookup"><span data-stu-id="39baf-185">Deploy the service app and get the package family name</span></span>

<span data-ttu-id="39baf-186">クライアントから呼び出せる前に、アプリのサービス プロバイダーを配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="39baf-186">The app service provider must be deployed before you can call it from a client.</span></span> <span data-ttu-id="39baf-187">選択してデプロイする**ビルド > ソリューションの配置**Visual Studio でします。</span><span class="sxs-lookup"><span data-stu-id="39baf-187">You can deploy it by selecting **Build > Deploy Solution** in Visual Studio.</span></span>

<span data-ttu-id="39baf-188">これを呼び出すために、アプリのサービス プロバイダーのパッケージ ファミリ名も必要になります。</span><span class="sxs-lookup"><span data-stu-id="39baf-188">You will also need the package family name of the app service provider in order to call it.</span></span> <span data-ttu-id="39baf-189">開いて表示できます、 **AppServiceProvider**プロジェクトの**Package.appxmanifest**デザイナーのビュー内のファイル (でそれをダブルクリックして、**ソリューション エクスプ ローラー**)。</span><span class="sxs-lookup"><span data-stu-id="39baf-189">You can get it by opening the **AppServiceProvider** project's **Package.appxmanifest** file in the designer view (double-click it in the **Solution Explorer**).</span></span> <span data-ttu-id="39baf-190">選択、**パッケージ** タブで、次に、値をコピーします。**パッケージ ファミリ名**、などに貼り付けメモ帳の今とします。</span><span class="sxs-lookup"><span data-stu-id="39baf-190">Select the **Packaging** tab, copy the value next to **Package family name**, and paste it somewhere like Notepad for now.</span></span>

## <a name="write-a-client-to-call-the-app-service"></a><span data-ttu-id="39baf-191">アプリ サービスを呼び出すクライアントを作成する</span><span class="sxs-lookup"><span data-stu-id="39baf-191">Write a client to call the app service</span></span>

1.  <span data-ttu-id="39baf-192">**[ファイル] &gt; [追加] &gt; [新しいプロジェクト]** で、新しい空の Windows ユニバーサル アプリ プロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="39baf-192">Add a new blank Windows Universal app project to the solution with **File &gt; Add &gt; New Project**.</span></span> <span data-ttu-id="39baf-193">**新しいプロジェクトの追加** ダイアログ ボックスで、選択**インストール済み > Visual C# > 空のアプリ (ユニバーサル Windows)** 名前を付けます**ClientApp**します。</span><span class="sxs-lookup"><span data-stu-id="39baf-193">In the **Add New Project** dialog box, choose **Installed > Visual C# > Blank App (Universal Windows)** and name it **ClientApp**.</span></span>

2.  <span data-ttu-id="39baf-194">**ClientApp**プロジェクトで、次の追加**を使用して**ステートメントの先頭に**MainPage.xaml.cs**:</span><span class="sxs-lookup"><span data-stu-id="39baf-194">In the **ClientApp** project, add the following **using** statement to the top of **MainPage.xaml.cs**:</span></span>
    ```cs
    using Windows.ApplicationModel.AppService;
    ```

3.  <span data-ttu-id="39baf-195">呼ばれるテキスト ボックスを追加**textBox**ボタンを**MainPage.xaml**します。</span><span class="sxs-lookup"><span data-stu-id="39baf-195">Add a text box called **textBox** and a button to **MainPage.xaml**.</span></span>

4.  <span data-ttu-id="39baf-196">ボタンを追加するハンドラーというボタンをクリックします**button_Click**、キーワードを追加および**非同期**をボタン ハンドラーのシグネチャにします。</span><span class="sxs-lookup"><span data-stu-id="39baf-196">Add a button click handler for the button called **button_Click**, and add the keyword **async** to the button handler's signature.</span></span>

5. <span data-ttu-id="39baf-197">ボタンのクリック ハンドラーのスタブを、次のコードで置き換えます。</span><span class="sxs-lookup"><span data-stu-id="39baf-197">Replace the stub of your button click handler with the following code.</span></span> <span data-ttu-id="39baf-198">必ず、`inventoryService` フィールドの宣言を含めます。</span><span class="sxs-lookup"><span data-stu-id="39baf-198">Be sure to include the `inventoryService` field declaration.</span></span>
    ```cs
   private AppServiceConnection inventoryService;

   private async void button_Click(object sender, RoutedEventArgs e)
   {
       // Add the connection.
       if (this.inventoryService == null)
       {
           this.inventoryService = new AppServiceConnection();

           // Here, we use the app service name defined in the app service 
           // provider's Package.appxmanifest file in the <Extension> section.
           this.inventoryService.AppServiceName = "com.microsoft.inventory";

           // Use Windows.ApplicationModel.Package.Current.Id.FamilyName 
           // within the app service provider to get this value.
           this.inventoryService.PackageFamilyName = "Replace with the package family name";

           var status = await this.inventoryService.OpenAsync();

           if (status != AppServiceConnectionStatus.Success)
           {
               textBox.Text= "Failed to connect";
               this.inventoryService = null;
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
           // Get the data  that the service sent to us.
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
    
    <span data-ttu-id="39baf-199">行 `this.inventoryService.PackageFamilyName = "Replace with the package family name";` のパッケージ ファミリ名を、「[サービス アプリを展開して、パッケージ ファミリ名を取得する](#deploy-the-service-app-and-get-the-package-family-name)」で得た **AppServiceProvider** プロジェクトのパッケージ ファミリ名に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="39baf-199">Replace the package family name in the line `this.inventoryService.PackageFamilyName = "Replace with the package family name";` with the package family name of the **AppServiceProvider** project that you obtained above in [Deploy the service app and get the package family name](#deploy-the-service-app-and-get-the-package-family-name).</span></span>

    > [!NOTE]
    > <span data-ttu-id="39baf-200">必ず、文字列リテラルに配置し、変数に貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="39baf-200">Make sure to paste in the string literal, rather than putting it in a variable.</span></span> <span data-ttu-id="39baf-201">変数を使用する場合は機能しません。</span><span class="sxs-lookup"><span data-stu-id="39baf-201">It will not work if you use a variable.</span></span>

    <span data-ttu-id="39baf-202">最初に、コードによってアプリ サービスとの接続が確立されます。</span><span class="sxs-lookup"><span data-stu-id="39baf-202">The code first establishes a connection with the app service.</span></span> <span data-ttu-id="39baf-203">接続は、`this.inventoryService` を破棄するまで開いたままになります。</span><span class="sxs-lookup"><span data-stu-id="39baf-203">The connection will remain open until you dispose `this.inventoryService`.</span></span> <span data-ttu-id="39baf-204">App service の名前に一致する必要があります、`AppService`要素の`Name`に追加する属性、 **AppServiceProvider**プロジェクトの**Package.appxmanifest**ファイル。</span><span class="sxs-lookup"><span data-stu-id="39baf-204">The app service name must match the `AppService` element's `Name` attribute that you added to the **AppServiceProvider** project's **Package.appxmanifest** file.</span></span> <span data-ttu-id="39baf-205">この例では `<uap3:AppService Name="com.microsoft.inventory"/>` です。</span><span class="sxs-lookup"><span data-stu-id="39baf-205">In this example, it is `<uap3:AppService Name="com.microsoft.inventory"/>`.</span></span>

    <span data-ttu-id="39baf-206">A [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131)という`message`を app service に送信するコマンドを指定するが作成されます。</span><span class="sxs-lookup"><span data-stu-id="39baf-206">A [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131) named `message` is created to specify the command that we want to send to the app service.</span></span> <span data-ttu-id="39baf-207">この例のアプリ サービスでは、2 つのアクションのどちらを実行するかをコマンドが示すことを想定しています。</span><span class="sxs-lookup"><span data-stu-id="39baf-207">The example app service expects a command to indicate which of two actions to take.</span></span> <span data-ttu-id="39baf-208">クライアント アプリでテキスト ボックスからインデックスを取得し、使用して、サービスを呼び出して、`Item`項目の説明を取得するコマンド。</span><span class="sxs-lookup"><span data-stu-id="39baf-208">We get the index from the text box in the client app, and then call the service with the `Item` command to get the description of the item.</span></span> <span data-ttu-id="39baf-209">その後、`Price` コマンドで呼び出しを行い、項目の価格を取得します。</span><span class="sxs-lookup"><span data-stu-id="39baf-209">Then, we make the call with the `Price` command to get the item's price.</span></span> <span data-ttu-id="39baf-210">ボタンのテキストは結果に設定されています。</span><span class="sxs-lookup"><span data-stu-id="39baf-210">The button text is set to the result.</span></span>

    <span data-ttu-id="39baf-211">[AppServiceResponseStatus](https://msdn.microsoft.com/library/windows/apps/dn921724)オペレーティング システムがチェックを app service への呼び出しに接続できるかどうかを示します、`Status`キー、 [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131)アプリからの受信サービス要求を処理することであったことをします。</span><span class="sxs-lookup"><span data-stu-id="39baf-211">Because [AppServiceResponseStatus](https://msdn.microsoft.com/library/windows/apps/dn921724) only indicates whether the operating system was able to connect the call to the app service, we check the `Status` key in the [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131) we receive from the app service to ensure that it was able to fulfill the request.</span></span>

6. <span data-ttu-id="39baf-212">設定、 **ClientApp**プロジェクトをスタートアップ プロジェクト (で右クリックし、**ソリューション エクスプ ローラー** > **スタートアップ プロジェクトとして設定**) し、ソリューションを実行します。</span><span class="sxs-lookup"><span data-stu-id="39baf-212">Set the **ClientApp** project to be the startup project (right-click it in the **Solution Explorer** > **Set as StartUp Project**) and run the solution.</span></span> <span data-ttu-id="39baf-213">数値 1 をテキスト ボックスに入力し、ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="39baf-213">Enter the number 1 into the text box and click the button.</span></span> <span data-ttu-id="39baf-214">取得する必要があります"椅子。価格 = 88.99"、サービスから返信します。</span><span class="sxs-lookup"><span data-stu-id="39baf-214">You should get "Chair : Price = 88.99" back from the service.</span></span>

    ![Chair : price = 88.99 を表示するサンプル アプリ](images/appserviceclientapp.png)

<span data-ttu-id="39baf-216">アプリ サービスの呼び出しに失敗した場合、次を確認してください。、 **ClientApp**プロジェクト。</span><span class="sxs-lookup"><span data-stu-id="39baf-216">If the app service call fails, check the following in the **ClientApp** project:</span></span>

1.  <span data-ttu-id="39baf-217">インベントリ サービスの接続に割り当てられたパッケージ ファミリ名のパッケージ ファミリ名と一致していることを確認、 **AppServiceProvider**アプリ。</span><span class="sxs-lookup"><span data-stu-id="39baf-217">Verify that the package family name assigned to the inventory service connection matches the package family name of the **AppServiceProvider** app.</span></span> <span data-ttu-id="39baf-218">内の行を参照してください**ボタン\_クリックして**で`this.inventoryService.PackageFamilyName = "...";`します。</span><span class="sxs-lookup"><span data-stu-id="39baf-218">See the line in **button\_Click** with `this.inventoryService.PackageFamilyName = "...";`.</span></span>
2.  <span data-ttu-id="39baf-219">**ボタン\_クリックして**、インベントリ サービスの接続に割り当てられている app service の名前の app service の名前と一致していることを確認、 **AppServiceProvider**の**Package.appxmanifest**ファイル。</span><span class="sxs-lookup"><span data-stu-id="39baf-219">In **button\_Click**, verify that the app service name that is assigned to the inventory service connection matches the app service name in the **AppServiceProvider**'s **Package.appxmanifest** file.</span></span> <span data-ttu-id="39baf-220">`this.inventoryService.AppServiceName = "com.microsoft.inventory";` をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="39baf-220">See: `this.inventoryService.AppServiceName = "com.microsoft.inventory";`.</span></span>
3.  <span data-ttu-id="39baf-221">いることを確認、 **AppServiceProvider**アプリが展開されています。</span><span class="sxs-lookup"><span data-stu-id="39baf-221">Ensure that the **AppServiceProvider** app has been deployed.</span></span> <span data-ttu-id="39baf-222">(で、**ソリューション エクスプ ローラー**ソリューションを右クリックし、選択、**ソリューションの配置**)。</span><span class="sxs-lookup"><span data-stu-id="39baf-222">(In the **Solution Explorer**, right-click the solution and choose **Deploy Solution**).</span></span>

## <a name="debug-the-app-service"></a><span data-ttu-id="39baf-223">アプリ サービスのデバッグ</span><span class="sxs-lookup"><span data-stu-id="39baf-223">Debug the app service</span></span>

1.  <span data-ttu-id="39baf-224">サービスを呼び出す前にアプリ サービス プロバイダーのアプリが配置される必要があるため、ソリューションがデバッグする前に展開されるようにします。</span><span class="sxs-lookup"><span data-stu-id="39baf-224">Ensure that the solution is deployed before debugging because the app service provider app must be deployed before the service can be called.</span></span> <span data-ttu-id="39baf-225">(Visual Studio で、**[ビルド] &gt; [ソリューションの配置]** の順にクリックします)。</span><span class="sxs-lookup"><span data-stu-id="39baf-225">(In Visual Studio, **Build &gt; Deploy Solution**).</span></span>
2.  <span data-ttu-id="39baf-226">**ソリューション エクスプ ローラー**を右クリックし、 **AppServiceProvider**プロジェクト**プロパティ**します。</span><span class="sxs-lookup"><span data-stu-id="39baf-226">In the **Solution Explorer**, right-click the **AppServiceProvider** project and choose **Properties**.</span></span> <span data-ttu-id="39baf-227">**[デバッグ]** タブで、**[開始動作]** を **[起動しないが、開始時にマイ コードをデバッグする]** に変更します。</span><span class="sxs-lookup"><span data-stu-id="39baf-227">From the **Debug** tab, change the **Start action** to **Do not launch, but debug my code when it starts**.</span></span> <span data-ttu-id="39baf-228">(C++ を使ってアプリ サービス プロバイダーを実装した場合、**[デバッグ]** タブから **[アプリケーションの起動]** を **[いいえ]** に変更します)。</span><span class="sxs-lookup"><span data-stu-id="39baf-228">(Note, if you were using C++ to implement your app service provider, from the **Debugging** tab you would change **Launch Application** to **No**).</span></span>
3.  <span data-ttu-id="39baf-229">**MyAppService**プロジェクトの**Inventory.cs**にブレークポイントを設定ファイルで、 **OnRequestReceived**します。</span><span class="sxs-lookup"><span data-stu-id="39baf-229">In the **MyAppService** project, in the **Inventory.cs** file, set a breakpoint in **OnRequestReceived**.</span></span>
4.  <span data-ttu-id="39baf-230">設定、 **AppServiceProvider**プロジェクトをスタートアップ プロジェクトとキーを押して**F5**します。</span><span class="sxs-lookup"><span data-stu-id="39baf-230">Set the **AppServiceProvider** project to be the startup project and press **F5**.</span></span>
5.  <span data-ttu-id="39baf-231">開始**ClientApp** (Visual Studio) からではなく [スタート] メニューから。</span><span class="sxs-lookup"><span data-stu-id="39baf-231">Start **ClientApp** from the Start menu (not from Visual Studio).</span></span>
6.  <span data-ttu-id="39baf-232">数値 1 をテキスト ボックスに入力し、ボタンを押します。</span><span class="sxs-lookup"><span data-stu-id="39baf-232">Enter the number 1 into the text box and press the button.</span></span> <span data-ttu-id="39baf-233">デバッガーは、アプリ サービス内のブレークポイントでアプリ サービスの呼び出しを停止します。</span><span class="sxs-lookup"><span data-stu-id="39baf-233">The debugger will stop in the app service call on the breakpoint in your app service.</span></span>

## <a name="debug-the-client"></a><span data-ttu-id="39baf-234">クライアントのデバッグ</span><span class="sxs-lookup"><span data-stu-id="39baf-234">Debug the client</span></span>

1.  <span data-ttu-id="39baf-235">前の手順に従って、アプリ サービスを呼び出すクライアントをデバッグします。</span><span class="sxs-lookup"><span data-stu-id="39baf-235">Follow the instructions in the preceding step to debug the client that calls the app service.</span></span>
2.  <span data-ttu-id="39baf-236">起動**ClientApp** [スタート] メニュー。</span><span class="sxs-lookup"><span data-stu-id="39baf-236">Launch **ClientApp** from the Start menu.</span></span>
3.  <span data-ttu-id="39baf-237">デバッガーをアタッチ、 **ClientApp.exe**プロセス (いない、 **ApplicationFrameHost.exe**プロセス)。</span><span class="sxs-lookup"><span data-stu-id="39baf-237">Attach the debugger to the **ClientApp.exe** process (not the **ApplicationFrameHost.exe** process).</span></span> <span data-ttu-id="39baf-238">(Visual Studio で、**[デバッグ] &gt; [プロセスにアタッチ]** の順に選びます)。</span><span class="sxs-lookup"><span data-stu-id="39baf-238">(In Visual Studio, choose **Debug &gt; Attach to Process...**.)</span></span>
4.  <span data-ttu-id="39baf-239">**ClientApp**プロジェクトでのブレークポイントを設定、**ボタン\_クリックして**。</span><span class="sxs-lookup"><span data-stu-id="39baf-239">In the **ClientApp** project, set a breakpoint in **button\_Click**.</span></span>
5.  <span data-ttu-id="39baf-240">テキスト ボックスに数字 1 を入力すると、クライアントと、app service の両方でブレークポイントにヒット今すぐ**ClientApp**ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="39baf-240">The breakpoints in both the client and the app service will now be hit when you enter the number 1 into the text box of **ClientApp** and click the button.</span></span>

## <a name="general-app-service-troubleshooting"></a><span data-ttu-id="39baf-241">一般的なアプリ サービスのトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="39baf-241">General app service troubleshooting</span></span>

<span data-ttu-id="39baf-242">発生した場合、 **AppUnavailable** app service に接続しようとしました。 後のステータスは、次を確認します。</span><span class="sxs-lookup"><span data-stu-id="39baf-242">If you encounter an **AppUnavailable** status after trying to connect to an app service, check the following:</span></span>

- <span data-ttu-id="39baf-243">アプリ サービス プロバイダー プロジェクトとアプリ サービス プロジェクトが展開されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="39baf-243">Ensure that the app service provider project and app service project are deployed.</span></span> <span data-ttu-id="39baf-244">クライアントを実行する前に、両方が展開されている必要があります。展開されていない場合、クライアントには接続先がありません。</span><span class="sxs-lookup"><span data-stu-id="39baf-244">Both need to be deployed before running the client because otherwise the client won't have anything to connect to.</span></span> <span data-ttu-id="39baf-245">Visual Studio から **[ビルド]** > **[ソリューションの配置]** で展開できます。</span><span class="sxs-lookup"><span data-stu-id="39baf-245">You can deploy from Visual Studio by using **Build** > **Deploy Solution**.</span></span>
- <span data-ttu-id="39baf-246">**ソリューション エクスプ ローラー**、アプリ サービスのプロバイダー プロジェクトが、app service を実装するプロジェクトへのプロジェクト間参照であることを確認します。</span><span class="sxs-lookup"><span data-stu-id="39baf-246">In the **Solution Explorer**, ensure that your app service provider project has a project-to-project reference to the project that implements the app service.</span></span>
- <span data-ttu-id="39baf-247">いることを確認、`<Extensions>`エントリとその子要素が追加されました、 **Package.appxmanifest**で上で指定したアプリ サービス プロバイダーのプロジェクトに属しているファイル[するアプリ サービスの拡張機能の追加Package.appxmanifest](#appxmanifest)します。</span><span class="sxs-lookup"><span data-stu-id="39baf-247">Verify that the `<Extensions>` entry, and its child elements, have been added to the **Package.appxmanifest** file belonging to the app service provider project as specified above in [Add an app service extension to Package.appxmanifest](#appxmanifest).</span></span>
- <span data-ttu-id="39baf-248">いることを確認、 [AppServiceConnection.AppServiceName](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appservice.appserviceconnection.appservicename)をアプリのサービス プロバイダーを呼び出すクライアントでの文字列に一致する、`<uap3:AppService Name="..." />`アプリ サービス プロバイダー プロジェクトで指定された**Package.appxmanifest**ファイル。</span><span class="sxs-lookup"><span data-stu-id="39baf-248">Ensure that the [AppServiceConnection.AppServiceName](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appservice.appserviceconnection.appservicename) string in your client that calls the app service provider matches the `<uap3:AppService Name="..." />` specified in the app service provider project's **Package.appxmanifest** file.</span></span>
- <span data-ttu-id="39baf-249">いることを確認、 [AppServiceConnection.PackageFamilyName](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appservice.appserviceconnection.packagefamilyname)で上で指定したアプリのサービス プロバイダー コンポーネントのパッケージ ファミリ名と一致する[Package.appxmanifest にアプリ サービスの拡張機能を追加します。](#appxmanifest)</span><span class="sxs-lookup"><span data-stu-id="39baf-249">Ensure that the [AppServiceConnection.PackageFamilyName](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appservice.appserviceconnection.packagefamilyname) matches the package family name of the app service provider component as specified above in [Add an app service extension to Package.appxmanifest](#appxmanifest)</span></span>
- <span data-ttu-id="39baf-250">この例では、1 つなど、アウト プロセス アプリケーション サービスのことを検証、`EntryPoint`で指定されている、`<uap:Extension ...>`アプリ サービス プロバイダー プロジェクトの要素**Package.appxmanifest**ファイル名前空間に一致し、実装するパブリック クラスのクラス名[IBackgroundTask](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.ibackgroundtask)アプリ サービス プロジェクト。</span><span class="sxs-lookup"><span data-stu-id="39baf-250">For out-of-proc app services such as the one in this example, validate that the `EntryPoint` specified in the `<uap:Extension ...>` element of your app service provider project's **Package.appxmanifest** file matches the namespace and class name of the public class that implements [IBackgroundTask](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.ibackgroundtask) in your app service project.</span></span>

### <a name="troubleshoot-debugging"></a><span data-ttu-id="39baf-251">デバッグのトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="39baf-251">Troubleshoot debugging</span></span>

<span data-ttu-id="39baf-252">アプリ サービス プロバイダーまたはアプリ サービス プロジェクトのブレークポイントでデバッガーが停止しない場合は、以下を確認します。</span><span class="sxs-lookup"><span data-stu-id="39baf-252">If the debugger does not stop at breakpoints in your app service provider or app service projects, check the following:</span></span>

- <span data-ttu-id="39baf-253">アプリ サービス プロバイダー プロジェクトとアプリ サービス プロジェクトが展開されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="39baf-253">Ensure that the app service provider project and app service project are deployed.</span></span> <span data-ttu-id="39baf-254">クライアントを実行する前に、両方が展開されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="39baf-254">Both need to be deployed before running the client.</span></span> <span data-ttu-id="39baf-255">Visual Studio から **[ビルド]** > **[ソリューションの配置]** で展開できます。</span><span class="sxs-lookup"><span data-stu-id="39baf-255">You can deploy them from Visual Studio by using **Build** > **Deploy Solution**.</span></span>
- <span data-ttu-id="39baf-256">デバッグするプロジェクトがスタートアップ プロジェクトとして設定されていると、プロジェクトを実行しない、そのプロジェクトのデバッグのプロパティが設定されていることを確認時に**F5**が押されました。</span><span class="sxs-lookup"><span data-stu-id="39baf-256">Ensure that the project you want to debug is set as the startup project and that the debugging properties for that project are set to not run the project when **F5** is pressed.</span></span> <span data-ttu-id="39baf-257">プロジェクトを右クリックし、**[プロパティ]**、**[デバッグ]** (または C++ では **[デバッグ]**) の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="39baf-257">Right-click the project, then click **Properties**, and then **Debug** (or **Debugging** in C++).</span></span> <span data-ttu-id="39baf-258">C# では、**[開始動作]** を **[起動しないが、開始時にマイ コードをデバッグする]** に設定します。</span><span class="sxs-lookup"><span data-stu-id="39baf-258">In C#, change the **Start action** to **Do not launch, but debug my code when it starts**.</span></span> <span data-ttu-id="39baf-259">C++ では、**[アプリケーションの起動]** を **[いいえ]** に設定します。</span><span class="sxs-lookup"><span data-stu-id="39baf-259">In C++, set **Launch Application** to **No**.</span></span>

## <a name="remarks"></a><span data-ttu-id="39baf-260">注釈</span><span class="sxs-lookup"><span data-stu-id="39baf-260">Remarks</span></span>

<span data-ttu-id="39baf-261">この例では、バックグラウンド タスクとして実行されるアプリ サービスを作成して、それを別のアプリから呼び出す概要を示しています。</span><span class="sxs-lookup"><span data-stu-id="39baf-261">This example provides an introduction to creating an app service that runs as a background task and calling it from another app.</span></span> <span data-ttu-id="39baf-262">注意することは、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="39baf-262">The key things to note are:</span></span>

* <span data-ttu-id="39baf-263">アプリ サービスをホストするバック グラウンド タスクを作成します。</span><span class="sxs-lookup"><span data-stu-id="39baf-263">Create a background task to host the app service.</span></span>
* <span data-ttu-id="39baf-264">追加、`windows.appService`をアプリ サービス プロバイダーの拡張機能**Package.appxmanifest**ファイル。</span><span class="sxs-lookup"><span data-stu-id="39baf-264">Add the `windows.appService` extension to the app service provider's **Package.appxmanifest** file.</span></span>
* <span data-ttu-id="39baf-265">クライアント アプリからそれに接続できるように、アプリのサービス プロバイダーのパッケージ ファミリ名を取得します。</span><span class="sxs-lookup"><span data-stu-id="39baf-265">Obtain the package family name of the app service provider so that we can connect to it from the client app.</span></span>
* <span data-ttu-id="39baf-266">アプリのサービス プロバイダーのプロジェクトからアプリ サービスのプロジェクトにプロジェクト間参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="39baf-266">Add a project-to-project reference from the app service provider project to the app service project.</span></span>
* <span data-ttu-id="39baf-267">使用[Windows.ApplicationModel.AppService.AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/dn921704)サービスを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="39baf-267">Use [Windows.ApplicationModel.AppService.AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/dn921704) to call the service.</span></span>

## <a name="full-code-for-myappservice"></a><span data-ttu-id="39baf-268">MyAppService の完全なコード</span><span class="sxs-lookup"><span data-stu-id="39baf-268">Full code for MyAppService</span></span>

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
            // Get a deferral so that the service isn't terminated.
            this.backgroundTaskDeferral = taskInstance.GetDeferral();

            // Associate a cancellation handler with the background task.
            taskInstance.Canceled += OnTaskCanceled;

            // Retrieve the app service connection and set up a listener for incoming app service requests.
            var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            appServiceconnection = details.AppServiceConnection;
            appServiceconnection.RequestReceived += OnRequestReceived;
        }

        private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            // Get a deferral because we use an awaitable API below to respond to the message
            // and we don't want this call to get canceled while we are waiting.
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

            // Return the data to the caller.
            await args.Request.SendResponseAsync(returnData);

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

## <a name="related-topics"></a><span data-ttu-id="39baf-269">関連トピック</span><span class="sxs-lookup"><span data-stu-id="39baf-269">Related topics</span></span>

* [<span data-ttu-id="39baf-270">ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する</span><span class="sxs-lookup"><span data-stu-id="39baf-270">Convert an app service to run in the same process as its host app</span></span>](convert-app-service-in-process.md)
* [<span data-ttu-id="39baf-271">バックグラウンド タスクによるアプリのサポート</span><span class="sxs-lookup"><span data-stu-id="39baf-271">Support your app with background tasks</span></span>](support-your-app-with-background-tasks.md)
* [<span data-ttu-id="39baf-272">アプリ サービスのコード サンプル (C#、C++、および VB)</span><span class="sxs-lookup"><span data-stu-id="39baf-272">App service code sample (C#, C++, and VB)</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices)
