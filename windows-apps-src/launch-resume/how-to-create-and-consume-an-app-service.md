---
title: アプリ サービスの作成と利用
description: 他のユニバーサル Windows プラットフォーム (UWP) アプリにサービスを提供できる UWP アプリを作成する方法と、それらのサービスを利用する方法について説明します。
ms.assetid: 6E48B8B6-D3BF-4AE2-85FB-D463C448C9D3
keywords: アプリ間通信, プロセス間通信, IPC, バック グラウンド メッセージング, バック グラウンド通信, アプリをアプリ サービス
ms.date: 1/16/2019
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 9029c8ee3a930e66ebdbd0c4d0681d87486a8393
ms.sourcegitcommit: 6e2027f8ebc1d891d27ea6b2e4676d592871bcc7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/16/2019
ms.locfileid: "9011262"
---
# <a name="create-and-consume-an-app-service"></a><span data-ttu-id="8e184-104">アプリ サービスの作成と利用</span><span class="sxs-lookup"><span data-stu-id="8e184-104">Create and consume an app service</span></span>

<span data-ttu-id="8e184-105">アプリ サービスは、他の UWP アプリにサービスを提供する UWP アプリです。</span><span class="sxs-lookup"><span data-stu-id="8e184-105">App services are UWP apps that provide services to other UWP apps.</span></span> <span data-ttu-id="8e184-106">これは、デバイス上にある Web サービスのようなものです。</span><span class="sxs-lookup"><span data-stu-id="8e184-106">They are analogous to web services, on a device.</span></span> <span data-ttu-id="8e184-107">アプリ サービスは、バック グラウンド タスクとしてホスト アプリで実行され、そのサービスを他のアプリに提供することができます。</span><span class="sxs-lookup"><span data-stu-id="8e184-107">An app service runs as a background task in the host app and can provide its service to other apps.</span></span> <span data-ttu-id="8e184-108">たとえば、アプリ サービスによって、他のアプリで使用できるバー コード スキャナー サービスが提供される場合があります。</span><span class="sxs-lookup"><span data-stu-id="8e184-108">For example, an app service might provide a bar code scanner service that other apps could use.</span></span> <span data-ttu-id="8e184-109">また、アプリのエンタープライズ スイートに共通のスペル チェック アプリ サービスを備えておき、そのサービスを同じスイート内の他のアプリから利用可能にする場合もあるでしょう。</span><span class="sxs-lookup"><span data-stu-id="8e184-109">Or perhaps an Enterprise suite of apps has a common spell checking app service that is available to the other apps in the suite.</span></span>  <span data-ttu-id="8e184-110">アプリ サービスでは、同じデバイス上のアプリから呼び出せる UI を持たないサービスを作成できます。また、Windows 10 バージョン 1607 以降では、リモート デバイスからも呼び出せます。</span><span class="sxs-lookup"><span data-stu-id="8e184-110">App services let you create UI-less services that apps can call on the same device, and starting with Windows 10, version 1607, on remote devices.</span></span>

<span data-ttu-id="8e184-111">Windows 10 バージョン 1607 以降では、ホスト アプリと同じプロセスで実行されるアプリ サービスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="8e184-111">Starting in Windows 10, version 1607, you can create app services that run in the same process as the host app.</span></span> <span data-ttu-id="8e184-112">この記事では、別のバックグラウンド プロセスで実行されるアプリ サービスの作成と利用に重点を置いて説明します。</span><span class="sxs-lookup"><span data-stu-id="8e184-112">This article focuses on creating and consuming an app service that runs in a separate background process.</span></span> <span data-ttu-id="8e184-113">プロバイダーと同じプロセスでアプリ サービスを実行する詳細については、「[ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する](convert-app-service-in-process.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8e184-113">See [Convert an app service to run in the same process as its host app](convert-app-service-in-process.md) for more details about running an app service in the same process as the provider.</span></span>

<span data-ttu-id="8e184-114">アプリ サービスのコード サンプルについては、「[ユニバーサル Windows プラットフォーム (UWP) アプリのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8e184-114">For an app service code sample, see [Universal Windows Platform (UWP) app samples](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices).</span></span>

## <a name="create-a-new-app-service-provider-project"></a><span data-ttu-id="8e184-115">新しいアプリ サービス プロバイダー プロジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="8e184-115">Create a new app service provider project</span></span>

<span data-ttu-id="8e184-116">このトピックでは、わかりやすくするためにすべてを 1 つのソリューションで作成します。</span><span class="sxs-lookup"><span data-stu-id="8e184-116">In this how-to, we'll create everything in one solution for simplicity.</span></span>

1. <span data-ttu-id="8e184-117">Visual Studio 2015 以降では、新しい UWP アプリ プロジェクトを作成し、 **AppServiceProvider**という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="8e184-117">In Visual Studio 2015 or later, create a new UWP app project and name it **AppServiceProvider**.</span></span>
    1. <span data-ttu-id="8e184-118">**ファイル _gt 新しい _gt**プロジェクト]</span><span class="sxs-lookup"><span data-stu-id="8e184-118">Select **File > New > Project...**</span></span> 
    2. <span data-ttu-id="8e184-119">**新しいプロジェクト**] ダイアログ ボックスで、**インストール済み _gt Visual C#] _gt 空白のアプリ (ユニバーサル Windows)** を選択します。</span><span class="sxs-lookup"><span data-stu-id="8e184-119">In the **New Project** dialog box, select **Installed > Visual C# > Blank App (Universal Windows)**.</span></span> <span data-ttu-id="8e184-120">これは、他の UWP アプリがアプリ サービスを利用できるアプリとなります。</span><span class="sxs-lookup"><span data-stu-id="8e184-120">This will be the app that makes the app service available to other UWP apps.</span></span>
    3. <span data-ttu-id="8e184-121">**AppServiceProvider**プロジェクトの名前、場所を選択して、 **[ok]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="8e184-121">Name the project **AppServiceProvider**, choose a location for it, and click **OK**.</span></span>

2. <span data-ttu-id="8e184-122">プロジェクトの**ターゲット**と**最小バージョン**を選択するメッセージが表示されたら、少なくとも選択**10.0.14393**します。</span><span class="sxs-lookup"><span data-stu-id="8e184-122">When asked to select a **Target** and **Minimum version** for the project, select at least **10.0.14393**.</span></span> <span data-ttu-id="8e184-123">Visual Studio 2017 およびターゲット**10.0.15063** (**Windows 10 Creators Update**) が使用する必要があります、新しい**SupportsMultipleInstances**属性を使用する場合は、以上。</span><span class="sxs-lookup"><span data-stu-id="8e184-123">If you want to use the new **SupportsMultipleInstances** attribute, you must be using Visual Studio 2017 and target **10.0.15063** (**Windows 10 Creators Update**) or higher.</span></span>

<span id="appxmanifest"/>

## <a name="add-an-app-service-extension-to-packageappxmanifest"></a><span data-ttu-id="8e184-124">Package.appxmanifest へのアプリ サービスの拡張機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="8e184-124">Add an app service extension to Package.appxmanifest</span></span>

<span data-ttu-id="8e184-125">**AppServiceProvider**プロジェクトでは、テキスト エディターで、 **Package.appxmanifest**ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="8e184-125">In the **AppServiceProvider** project, open the **Package.appxmanifest** file in a text editor:</span></span> 

1. <span data-ttu-id="8e184-126">**ソリューション エクスプ ローラー**で右クリックします。</span><span class="sxs-lookup"><span data-stu-id="8e184-126">Right-click it in the **Solution Explorer**.</span></span> 
2. <span data-ttu-id="8e184-127">**[ファイルを開く**を選択します。</span><span class="sxs-lookup"><span data-stu-id="8e184-127">Select **Open With**.</span></span> 
3. <span data-ttu-id="8e184-128">**XML (テキスト) エディター**を選択します。</span><span class="sxs-lookup"><span data-stu-id="8e184-128">Select **XML (Text) Editor**.</span></span> 

<span data-ttu-id="8e184-129">次の追加`AppService`内で拡張機能、`<Application>`要素です。</span><span class="sxs-lookup"><span data-stu-id="8e184-129">Add the following `AppService` extension inside the `<Application>` element.</span></span> <span data-ttu-id="8e184-130">この例では、`com.microsoft.inventory` サービスをアドバタイズし、このアプリをアプリ サービス プロバイダーとして識別します。</span><span class="sxs-lookup"><span data-stu-id="8e184-130">This example advertises the `com.microsoft.inventory` service and is what identifies this app as an app service provider.</span></span> <span data-ttu-id="8e184-131">実際のサービスは、バックグラウンド タスクとして実装されます。</span><span class="sxs-lookup"><span data-stu-id="8e184-131">The actual service will be implemented as a background task.</span></span> <span data-ttu-id="8e184-132">アプリ サービスのプロジェクトは、サービスを他のアプリに公開します。</span><span class="sxs-lookup"><span data-stu-id="8e184-132">The app service project exposes the service to other apps.</span></span> <span data-ttu-id="8e184-133">サービス名には逆のドメイン名スタイルを使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8e184-133">We recommend using a reverse domain name style for the service name.</span></span>

<span data-ttu-id="8e184-134">`xmlns:uap4` 名前空間のプレフィックスと `uap4:SupportsMultipleInstances` 属性は、Windows SDK バージョン 10.0.15063 以降をターゲットとしている場合のみ有効です。</span><span class="sxs-lookup"><span data-stu-id="8e184-134">Note that the `xmlns:uap4` namespace prefix and the `uap4:SupportsMultipleInstances` attribute are only valid if you are targeting Windows SDK version 10.0.15063 or higher.</span></span> <span data-ttu-id="8e184-135">以前のバージョンの SDK をターゲットとしている場合には、それらは安全に削除できます。</span><span class="sxs-lookup"><span data-stu-id="8e184-135">You can safely remove them if you are targeting older SDK versions.</span></span>

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

<span data-ttu-id="8e184-136">`Category`属性は、アプリ サービス プロバイダーとしてこのアプリケーションを識別します。</span><span class="sxs-lookup"><span data-stu-id="8e184-136">The `Category` attribute identifies this application as an app service provider.</span></span>

<span data-ttu-id="8e184-137">`EntryPoint`属性は、次に実装するサービスを実装する名前空間修飾クラスを識別します。</span><span class="sxs-lookup"><span data-stu-id="8e184-137">The `EntryPoint` attribute identifies the namespace qualified class that implements the service, which we'll implement next.</span></span>

<span data-ttu-id="8e184-138">`SupportsMultipleInstances`属性は、アプリ サービスが呼び出されるたびに実行される新しいプロセスでを示します。</span><span class="sxs-lookup"><span data-stu-id="8e184-138">The `SupportsMultipleInstances` attribute indicates that each time the app service is called that it should run in a new process.</span></span> <span data-ttu-id="8e184-139">これは必要ありませんは、その機能を必要し、10.0.15063 をターゲットとしている場合に利用可能な SDK (**Windows 10 Creators Update**) 以上。</span><span class="sxs-lookup"><span data-stu-id="8e184-139">This is not required but is available to you if you need that functionality and are targeting the 10.0.15063 SDK (**Windows 10 Creators Update**) or higher.</span></span> <span data-ttu-id="8e184-140">また、先頭に `uap4` 名前空間を付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="8e184-140">It also should be prefaced by the `uap4` namespace.</span></span>

## <a name="create-the-app-service"></a><span data-ttu-id="8e184-141">アプリ サービスの作成</span><span class="sxs-lookup"><span data-stu-id="8e184-141">Create the app service</span></span>

1.  <span data-ttu-id="8e184-142">アプリ サービスは、バックグラウンド タスクとして実装できます。</span><span class="sxs-lookup"><span data-stu-id="8e184-142">An app service can be implemented as a background task.</span></span> <span data-ttu-id="8e184-143">これにより、フォアグラウンド アプリケーションは、別のアプリケーションのアプリ サービスを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="8e184-143">This enables a foreground application to invoke an app service in another application.</span></span> <span data-ttu-id="8e184-144">バック グラウンド タスクとしてアプリ サービスを作成するには、ソリューションに新しい Windows ランタイム コンポーネント プロジェクトを追加 (**ファイル&gt;追加&gt;新しいプロジェクト**) **MyAppService**という名前です。</span><span class="sxs-lookup"><span data-stu-id="8e184-144">To create an app service as a background task, add a new Windows Runtime Component project to the solution (**File &gt; Add &gt; New Project**) named **MyAppService**.</span></span> <span data-ttu-id="8e184-145">**新しいプロジェクトの追加**] ダイアログ ボックスで、**インストール済み _gt Visual C#] _gt Windows ランタイム コンポーネント (ユニバーサル Windows)** を選択します。</span><span class="sxs-lookup"><span data-stu-id="8e184-145">In the **Add New Project** dialog box, choose **Installed > Visual C# > Windows Runtime Component (Universal Windows)**.</span></span>
2.  <span data-ttu-id="8e184-146">**AppServiceProvider**プロジェクトで、新しい**MyAppService**プロジェクトへのプロジェクト間の参照を追加します (**ソリューション エクスプ ローラー**で、 **AppServiceProvider**プロジェクト _gt**追加**で右クリック > **参照** > **プロジェクト** > **ソリューション**、選択**MyAppService** > **[ok]**)。</span><span class="sxs-lookup"><span data-stu-id="8e184-146">In the **AppServiceProvider** project, add a project-to-project reference to the new **MyAppService** project (in the **Solution Explorer**, right-click on the **AppServiceProvider** project > **Add** > **Reference** > **Projects** > **Solution**, select **MyAppService** > **OK**).</span></span> <span data-ttu-id="8e184-147">参照を追加しない場合でも、アプリ サービスは実行時に接続されないため、この手順は重要です。</span><span class="sxs-lookup"><span data-stu-id="8e184-147">This step is critical because if you do not add the reference, the app service won't connect at runtime.</span></span>
3.  <span data-ttu-id="8e184-148">**MyAppService**プロジェクトで、 **Class1.cs**の上部に、次の**using**ステートメントを追加します。</span><span class="sxs-lookup"><span data-stu-id="8e184-148">In the **MyAppService** project, add the following **using** statements to the top of **Class1.cs**:</span></span>
    ```cs
    using Windows.ApplicationModel.AppService;
    using Windows.ApplicationModel.Background;
    using Windows.Foundation.Collections;
    ```

4.  <span data-ttu-id="8e184-149">**Inventory.cs**、 **Class1.cs**の名前を変更し、 **Class1**の**インベントリ**をという名前の新しいバック グラウンド タスク クラスのスタブ コードを置き換えます。</span><span class="sxs-lookup"><span data-stu-id="8e184-149">Rename **Class1.cs** to **Inventory.cs**, and replace the stub code for **Class1** with a new background task class named **Inventory**:</span></span>

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

    <span data-ttu-id="8e184-150">このクラスは、アプリ サービスが作業を実行する場所です。</span><span class="sxs-lookup"><span data-stu-id="8e184-150">This class is where the app service will do its work.</span></span>

    <span data-ttu-id="8e184-151">**実行**は、バック グラウンド タスクが作成されたときに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="8e184-151">**Run** is called when the background task is created.</span></span> <span data-ttu-id="8e184-152">バックグラウンド タスクは **Run** が完了すると終了するため、バックグラウンド タスクが要求に引き続き対応できるように、コードは保留されます。</span><span class="sxs-lookup"><span data-stu-id="8e184-152">Because background tasks are terminated after **Run** completes, the code takes out a deferral so that the background task will stay up to serve requests.</span></span> <span data-ttu-id="8e184-153">バックグラウンド タスクとして実装されたアプリ サービスは、呼び出しを受け取った後、約 30 秒間に再度呼び出されない限り、または保留されない限り、約 30 秒間有効になっています。アプリ サービスが同じプロセスで呼び出し元として実装されると、アプリ サービスの有効期間は呼び出し元の有効期間に関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="8e184-153">An app service that is implemented as a background task will stay alive for about 30 seconds after it receives a call unless it is called again within that time window or a deferral is taken out. If the app service is implemented in the same process as the caller, the lifetime of the app service is tied to the lifetime of the caller.</span></span>

    <span data-ttu-id="8e184-154">アプリ サービスの有効期間は、呼び出し元に依存します。</span><span class="sxs-lookup"><span data-stu-id="8e184-154">The lifetime of the app service depends on the caller:</span></span>

    * <span data-ttu-id="8e184-155">呼び出し元がフォア グラウンドである場合は、アプリ サービスの有効期間は、呼び出し元と同じです。</span><span class="sxs-lookup"><span data-stu-id="8e184-155">If the caller is in the foreground, the app service lifetime is the same as the caller.</span></span>
    * <span data-ttu-id="8e184-156">呼び出し元がバック グラウンドである場合は、アプリ サービスは 30 秒間実行を取得します。</span><span class="sxs-lookup"><span data-stu-id="8e184-156">If the caller is in the background, the app service gets 30 seconds to run.</span></span> <span data-ttu-id="8e184-157">保留されると、1 回 5 秒追加されます。</span><span class="sxs-lookup"><span data-stu-id="8e184-157">Taking out a deferral provides an additional one time 5 seconds.</span></span>

    <span data-ttu-id="8e184-158">タスクが取り消さ**OnTaskCanceled**が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="8e184-158">**OnTaskCanceled** is called when the task is canceled.</span></span> <span data-ttu-id="8e184-159">クライアント アプリ破棄[AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/dn921704)、クライアント アプリが一時停止、OS がシャット ダウンまたはスリープ状態になり、または OS がタスクを実行するリソース不足と、タスクが取り消されます。</span><span class="sxs-lookup"><span data-stu-id="8e184-159">The task is canceled when the client app disposes the [AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/dn921704), the client app is suspended, the OS is shut down or sleeps, or the OS runs out of resources to run the task.</span></span>

## <a name="write-the-code-for-the-app-service"></a><span data-ttu-id="8e184-160">アプリ サービスのコードを記述する</span><span class="sxs-lookup"><span data-stu-id="8e184-160">Write the code for the app service</span></span>

<span data-ttu-id="8e184-161">**OnRequestReceived**は、アプリ サービスのコードが移動します。</span><span class="sxs-lookup"><span data-stu-id="8e184-161">**OnRequestReceived** is where the code for the app service goes.</span></span> <span data-ttu-id="8e184-162">**OnRequestReceived** **MyAppService**を**Inventory.cs**でスタブを次の例のコードに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="8e184-162">Replace the stub **OnRequestReceived** in **MyAppService**'s **Inventory.cs** with the code from this example.</span></span> <span data-ttu-id="8e184-163">このコードは、インベントリの項目のインデックスを取得し、コマンド文字列と共にサービスに渡して、指定したインベントリ項目の名前と価格を取得します。</span><span class="sxs-lookup"><span data-stu-id="8e184-163">This code gets an index for an inventory item and passes it, along with a command string, to the service to retrieve the name and the price of the specified inventory item.</span></span> <span data-ttu-id="8e184-164">独自のプロジェクトには、エラー処理コードを追加します。</span><span class="sxs-lookup"><span data-stu-id="8e184-164">For your own projects, add error handling code.</span></span>

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

<span data-ttu-id="8e184-165">**OnRequestReceived**が**非同期の**ため、この例では[SendResponseAsync](https://msdn.microsoft.com/library/windows/apps/dn921722)を呼び出して待機可能なメソッドに注意してください。</span><span class="sxs-lookup"><span data-stu-id="8e184-165">Note that **OnRequestReceived** is **async** because we make an awaitable method call to [SendResponseAsync](https://msdn.microsoft.com/library/windows/apps/dn921722) in this example.</span></span>

<span data-ttu-id="8e184-166">サービスが**OnRequestReceived**ハンドラーで**非同期**メソッドを使用できるように、遅延が取得されます。</span><span class="sxs-lookup"><span data-stu-id="8e184-166">A deferral is taken so that the service can use **async** methods in the **OnRequestReceived** handler.</span></span> <span data-ttu-id="8e184-167">これにより、**OnRequestReceived** への呼び出しは、メッセージの処理が完了するまで完了しません。</span><span class="sxs-lookup"><span data-stu-id="8e184-167">It ensures that the call to **OnRequestReceived** does not complete until it is done processing the message.</span></span>  <span data-ttu-id="8e184-168">[SendResponseAsync](https://msdn.microsoft.com/library/windows/apps/dn921722) が結果を呼び出し元に送ります。</span><span class="sxs-lookup"><span data-stu-id="8e184-168">[SendResponseAsync](https://msdn.microsoft.com/library/windows/apps/dn921722) sends the result to the caller.</span></span> <span data-ttu-id="8e184-169">**SendResponseAsync** は、呼び出しの完了時に通知しません。</span><span class="sxs-lookup"><span data-stu-id="8e184-169">**SendResponseAsync** does not signal the completion of the call.</span></span> <span data-ttu-id="8e184-170">**OnRequestReceived**が完了したことを[SendMessageAsync](https://msdn.microsoft.com/library/windows/apps/dn921712)に通知するは、保留の完了することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8e184-170">It is the completion of the deferral that signals to [SendMessageAsync](https://msdn.microsoft.com/library/windows/apps/dn921712) that **OnRequestReceived** has completed.</span></span> <span data-ttu-id="8e184-171">**SendResponseAsync**への呼び出しは、 **SendResponseAsync**例外をスローする場合でも、保留を完了する必要があるために、try/finally ブロックでラップされます。</span><span class="sxs-lookup"><span data-stu-id="8e184-171">The call to **SendResponseAsync** is wrapped in a try/finally block because you must complete the deferral even if **SendResponseAsync** throws an exception.</span></span>

<span data-ttu-id="8e184-172">アプリ サービスは、情報を交換[ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131)オブジェクトを使用します。</span><span class="sxs-lookup"><span data-stu-id="8e184-172">App services use [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131) objects to exchange information.</span></span> <span data-ttu-id="8e184-173">渡すことができるデータのサイズは、システム リソースによってのみ制限されます。</span><span class="sxs-lookup"><span data-stu-id="8e184-173">The size of the data you may pass is only limited by system resources.</span></span> <span data-ttu-id="8e184-174">**ValueSet** で使うことができる定義済みのキーはありません。</span><span class="sxs-lookup"><span data-stu-id="8e184-174">There are no predefined keys for you to use in your **ValueSet**.</span></span> <span data-ttu-id="8e184-175">アプリ サービスのプロトコルの定義に使うキーの値を決定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8e184-175">You must determine which key values you will use to define the protocol for your app service.</span></span> <span data-ttu-id="8e184-176">呼び出し元は、そのプロトコルを念頭に置いて記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8e184-176">The caller must be written with that protocol in mind.</span></span> <span data-ttu-id="8e184-177">この例では、アプリ サービスがインベントリ項目またはその価格の名前を提供するかどうかを示す値を持つ、`Command` という名前のキーを選びました。</span><span class="sxs-lookup"><span data-stu-id="8e184-177">In this example, we have chosen a key named `Command` that has a value that indicates whether we want the app service to provide the name of the inventory item or its price.</span></span> <span data-ttu-id="8e184-178">インベントリ名のインデックスは、`ID` キーに保存されています。</span><span class="sxs-lookup"><span data-stu-id="8e184-178">The index of the inventory name is stored under the `ID` key.</span></span> <span data-ttu-id="8e184-179">戻り値は `Result` キーに保存されます。</span><span class="sxs-lookup"><span data-stu-id="8e184-179">The return value is stored under the `Result` key.</span></span>

<span data-ttu-id="8e184-180">[AppServiceClosedStatus](https://msdn.microsoft.com/library/windows/apps/dn921703) 列挙体が呼び出し元に返され、アプリ サービスの呼び出した成功したか失敗したかを示します。</span><span class="sxs-lookup"><span data-stu-id="8e184-180">An [AppServiceClosedStatus](https://msdn.microsoft.com/library/windows/apps/dn921703) enum is returned to the caller to indicate whether the call to the app service succeeded or failed.</span></span> <span data-ttu-id="8e184-181">アプリ サービスへの呼び出しが失敗する例として、OS がサービスのエンドポイントを中止した、リソースが超過したなどがあります。</span><span class="sxs-lookup"><span data-stu-id="8e184-181">An example of how the call to the app service could fail is if the OS aborts the service endpoint because its resources have been exceeded.</span></span> <span data-ttu-id="8e184-182">[ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131) を通じて、さらにエラー情報を取得することができます。</span><span class="sxs-lookup"><span data-stu-id="8e184-182">You can return additional error information via the [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131).</span></span> <span data-ttu-id="8e184-183">この例では、`Status` という名前のキーを使って、より詳細なエラー情報を呼び出し元に返します。</span><span class="sxs-lookup"><span data-stu-id="8e184-183">In this example, we use a key named `Status` to return more detailed error information to the caller.</span></span>

<span data-ttu-id="8e184-184">[SendResponseAsync](https://msdn.microsoft.com/library/windows/apps/dn921722) の呼び出しからは、[ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131) が呼び出し元に返されます。</span><span class="sxs-lookup"><span data-stu-id="8e184-184">The call to [SendResponseAsync](https://msdn.microsoft.com/library/windows/apps/dn921722) returns the [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131) to the caller.</span></span>

## <a name="deploy-the-service-app-and-get-the-package-family-name"></a><span data-ttu-id="8e184-185">サービス アプリを展開して、パッケージ ファミリ名を取得する</span><span class="sxs-lookup"><span data-stu-id="8e184-185">Deploy the service app and get the package family name</span></span>

<span data-ttu-id="8e184-186">アプリ サービス プロバイダーは、クライアントから呼び出すことができます前に展開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8e184-186">The app service provider must be deployed before you can call it from a client.</span></span> <span data-ttu-id="8e184-187">これを呼び出すに、アプリ サービスのパッケージ ファミリ名も必要になります。</span><span class="sxs-lookup"><span data-stu-id="8e184-187">You will also need the package family name of the app service in order to call it.</span></span>

<span data-ttu-id="8e184-188">**AppServiceProvider**プロジェクト内で (たとえば**で**アプリ**のコンス トラクターからから[Windows.ApplicationModel.Package.Current.Id.FamilyName](https://msdn.microsoft.com/library/windows/apps/br224670)を呼び出すアプリ サービスのアプリケーションのパッケージ ファミリ名を取得する方法の 1 つは、します。App.xaml.cs**) 結果をメモします。</span><span class="sxs-lookup"><span data-stu-id="8e184-188">One way to get the package family name of the app service application is to call [Windows.ApplicationModel.Package.Current.Id.FamilyName](https://msdn.microsoft.com/library/windows/apps/br224670) from within the **AppServiceProvider** project (for example, from the **App** constructor in **App.xaml.cs**) and note the result.</span></span> <span data-ttu-id="8e184-189">Visual Studio で**AppServiceProvider**を実行するには、**ソリューション エクスプ**ローラー ウィンドウで、スタートアップ プロジェクトとして設定し、プロジェクトを実行します。</span><span class="sxs-lookup"><span data-stu-id="8e184-189">To run **AppServiceProvider** in Visual Studio, set it as the startup project in the **Solution Explorer** window and run the project.</span></span>

<span data-ttu-id="8e184-190">パッケージ ファミリ名を取得する別の方法は、ソリューションの展開する (**ビルド&gt;ソリューションの配置**) し、**出力**ウィンドウに完全なパッケージ名に注意してください (**ビュー&gt;出力**)。</span><span class="sxs-lookup"><span data-stu-id="8e184-190">Another way to get the package family name is to deploy the solution (**Build &gt; Deploy Solution**) and note the full package name in the **Output** window (**View &gt; Output**).</span></span> <span data-ttu-id="8e184-191">パッケージ名を派生する**出力**ウィンドウ内の文字列からプラットフォーム情報を削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8e184-191">You must remove the platform information from the string in the **Output** window to derive the package name.</span></span> <span data-ttu-id="8e184-192">たとえば、完全なパッケージ名が**出力**ウィンドウで報告された場合のとおりです。</span><span class="sxs-lookup"><span data-stu-id="8e184-192">For example, if the full package name reported in the **Output** window were:</span></span>

`Microsoft.SDKSamples.AppServicesProvider.CPP_1.0.0.0_x86__8wekyb3d8bbwe`

<span data-ttu-id="8e184-193">抽出し、 `1.0.0.0\_x86\_\_`、パッケージ ファミリ名として、次から離れること。</span><span class="sxs-lookup"><span data-stu-id="8e184-193">Then you would extract `1.0.0.0\_x86\_\_`, leaving the following as the package family name:</span></span>

`Microsoft.SDKSamples.AppServicesProvider.CPP_8wekyb3d8bbwe`

## <a name="write-a-client-to-call-the-app-service"></a><span data-ttu-id="8e184-194">アプリ サービスを呼び出すクライアントを作成する</span><span class="sxs-lookup"><span data-stu-id="8e184-194">Write a client to call the app service</span></span>

1.  <span data-ttu-id="8e184-195">**[ファイル] &gt; [追加] &gt; [新しいプロジェクト]** で、新しい空の Windows ユニバーサル アプリ プロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="8e184-195">Add a new blank Windows Universal app project to the solution with **File &gt; Add &gt; New Project**.</span></span> <span data-ttu-id="8e184-196">**新しいプロジェクトの追加**] ダイアログ ボックスで、**インストール済み _gt Visual C#] _gt 空白のアプリ (ユニバーサル Windows)** を選択し、 **ClientApp**名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="8e184-196">In the **Add New Project** dialog box, choose **Installed > Visual C# > Blank App (Universal Windows)** and name it **ClientApp**.</span></span>

2.  <span data-ttu-id="8e184-197">**ClientApp**プロジェクトで、 **MainPage.xaml.cs**の上部に、次の**using**ステートメントを追加します。</span><span class="sxs-lookup"><span data-stu-id="8e184-197">In the **ClientApp** project, add the following **using** statement to the top of **MainPage.xaml.cs**:</span></span>
    ```cs
    using Windows.ApplicationModel.AppService;
    ```

3.  <span data-ttu-id="8e184-198">**テキスト ボックス**とボタンを**MainPage.xaml**と呼ばれるテキスト ボックスを追加します。</span><span class="sxs-lookup"><span data-stu-id="8e184-198">Add a text box called **textBox** and a button to **MainPage.xaml**.</span></span>

4.  <span data-ttu-id="8e184-199">ボタンを追加する**button_Click**と呼ばれるボタンのクリックしてハンドラーと、ボタン ハンドラーの署名にキーワード**非同期**を追加します。</span><span class="sxs-lookup"><span data-stu-id="8e184-199">Add a button click handler for the button called **button_Click**, and add the keyword **async** to the button handler's signature.</span></span>

5. <span data-ttu-id="8e184-200">ボタンのクリック ハンドラーのスタブを、次のコードで置き換えます。</span><span class="sxs-lookup"><span data-stu-id="8e184-200">Replace the stub of your button click handler with the following code.</span></span> <span data-ttu-id="8e184-201">必ず、`inventoryService` フィールドの宣言を含めます。</span><span class="sxs-lookup"><span data-stu-id="8e184-201">Be sure to include the `inventoryService` field declaration.</span></span>
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
    
    <span data-ttu-id="8e184-202">行 `this.inventoryService.PackageFamilyName = "Replace with the package family name";` のパッケージ ファミリ名を、「[サービス アプリを展開して、パッケージ ファミリ名を取得する](#deploy-the-service-app-and-get-the-package-family-name)」で得た **AppServiceProvider** プロジェクトのパッケージ ファミリ名に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="8e184-202">Replace the package family name in the line `this.inventoryService.PackageFamilyName = "Replace with the package family name";` with the package family name of the **AppServiceProvider** project that you obtained above in [Deploy the service app and get the package family name](#deploy-the-service-app-and-get-the-package-family-name).</span></span>

    > [!NOTE]
    > <span data-ttu-id="8e184-203">文字列リテラルに配置し、変数にペーストすることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="8e184-203">Make sure to paste in the string literal, rather than putting it in a variable.</span></span> <span data-ttu-id="8e184-204">変数を使用する場合は機能しません。</span><span class="sxs-lookup"><span data-stu-id="8e184-204">It will not work if you use a variable.</span></span>

    <span data-ttu-id="8e184-205">最初に、コードによってアプリ サービスとの接続が確立されます。</span><span class="sxs-lookup"><span data-stu-id="8e184-205">The code first establishes a connection with the app service.</span></span> <span data-ttu-id="8e184-206">接続は、`this.inventoryService` を破棄するまで開いたままになります。</span><span class="sxs-lookup"><span data-stu-id="8e184-206">The connection will remain open until you dispose `this.inventoryService`.</span></span> <span data-ttu-id="8e184-207">アプリ サービス名に一致する必要があります、`AppService`要素の`Name`属性**AppServiceProvider**プロジェクトの**Package.appxmanifest**ファイルに追加します。</span><span class="sxs-lookup"><span data-stu-id="8e184-207">The app service name must match the `AppService` element's `Name` attribute that you added to the **AppServiceProvider** project's **Package.appxmanifest** file.</span></span> <span data-ttu-id="8e184-208">この例では `<uap3:AppService Name="com.microsoft.inventory"/>` です。</span><span class="sxs-lookup"><span data-stu-id="8e184-208">In this example, it is `<uap3:AppService Name="com.microsoft.inventory"/>`.</span></span>

    <span data-ttu-id="8e184-209">名前付き[ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131) `message`アプリ サービスに送信するコマンドを指定するために作成されます。</span><span class="sxs-lookup"><span data-stu-id="8e184-209">A [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131) named `message` is created to specify the command that we want to send to the app service.</span></span> <span data-ttu-id="8e184-210">この例のアプリ サービスでは、2 つのアクションのどちらを実行するかをコマンドが示すことを想定しています。</span><span class="sxs-lookup"><span data-stu-id="8e184-210">The example app service expects a command to indicate which of two actions to take.</span></span> <span data-ttu-id="8e184-211">ここでは、クライアント アプリ内のテキスト ボックスからインデックスを取得し、サービスを呼び出して、`Item`コマンドの項目の説明を取得します。</span><span class="sxs-lookup"><span data-stu-id="8e184-211">We get the index from the text box in the client app, and then call the service with the `Item` command to get the description of the item.</span></span> <span data-ttu-id="8e184-212">その後、`Price` コマンドで呼び出しを行い、項目の価格を取得します。</span><span class="sxs-lookup"><span data-stu-id="8e184-212">Then, we make the call with the `Price` command to get the item's price.</span></span> <span data-ttu-id="8e184-213">ボタンのテキストは結果に設定されています。</span><span class="sxs-lookup"><span data-stu-id="8e184-213">The button text is set to the result.</span></span>

    <span data-ttu-id="8e184-214">オペレーティング システムがアプリ サービスに呼び出しを接続できたかどうかを示すのは [AppServiceResponseStatus](https://msdn.microsoft.com/library/windows/apps/dn921724) のみです。このため、アプリ サービスが要求を満たすことができたことを確認するために、アプリ サービスから受け取る [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131) の `Status` キーをチェックします。</span><span class="sxs-lookup"><span data-stu-id="8e184-214">Because [AppServiceResponseStatus](https://msdn.microsoft.com/library/windows/apps/dn921724) only indicates whether the operating system was able to connect the call to the app service, we check the `Status` key in the [ValueSet](https://msdn.microsoft.com/library/windows/apps/dn636131) we receive from the app service to ensure that it was able to fulfill the request.</span></span>

6. <span data-ttu-id="8e184-215">**ClientApp**プロジェクトをスタートアップ プロジェクトに設定 (**ソリューション エクスプ ローラー**で右クリックして > **スタートアップ プロジェクトとして設定**) とソリューションを実行します。</span><span class="sxs-lookup"><span data-stu-id="8e184-215">Set the **ClientApp** project to be the startup project (right-click it in the **Solution Explorer** > **Set as StartUp Project**) and run the solution.</span></span> <span data-ttu-id="8e184-216">数値 1 をテキスト ボックスに入力し、ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="8e184-216">Enter the number 1 into the text box and click the button.</span></span> <span data-ttu-id="8e184-217">サービスから "Chair : Price = 88.99" が返されます。</span><span class="sxs-lookup"><span data-stu-id="8e184-217">You should get "Chair : Price = 88.99" back from the service.</span></span>

    ![Chair : price = 88.99 を表示するサンプル アプリ](images/appserviceclientapp.png)

<span data-ttu-id="8e184-219">アプリ サービスの呼び出しが失敗した場合は、 **ClientApp**プロジェクトで、以下を確認します。</span><span class="sxs-lookup"><span data-stu-id="8e184-219">If the app service call fails, check the following in the **ClientApp** project:</span></span>

1.  <span data-ttu-id="8e184-220">インベントリ サービスの接続に割り当てられたパッケージ ファミリ名が、 **AppServiceProvider**アプリのパッケージ ファミリ名と一致することを確認します。</span><span class="sxs-lookup"><span data-stu-id="8e184-220">Verify that the package family name assigned to the inventory service connection matches the package family name of the **AppServiceProvider** app.</span></span> <span data-ttu-id="8e184-221">**Button \_click**での行が表示`this.inventoryService.PackageFamilyName = "...";`します。</span><span class="sxs-lookup"><span data-stu-id="8e184-221">See the line in **button\_Click** with `this.inventoryService.PackageFamilyName = "...";`.</span></span>
2.  <span data-ttu-id="8e184-222">**Button \_click**では、インベントリ サービスの接続に割り当てられているアプリ サービス名が、 **AppServiceProvider**の**Package.appxmanifest**ファイルでアプリ サービス名に一致することを確認します。</span><span class="sxs-lookup"><span data-stu-id="8e184-222">In **button\_Click**, verify that the app service name that is assigned to the inventory service connection matches the app service name in the **AppServiceProvider**'s **Package.appxmanifest** file.</span></span> <span data-ttu-id="8e184-223">`this.inventoryService.AppServiceName = "com.microsoft.inventory";` をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8e184-223">See: `this.inventoryService.AppServiceName = "com.microsoft.inventory";`.</span></span>
3.  <span data-ttu-id="8e184-224">**AppServiceProvider**アプリが展開されたことを確認します。</span><span class="sxs-lookup"><span data-stu-id="8e184-224">Ensure that the **AppServiceProvider** app has been deployed.</span></span> <span data-ttu-id="8e184-225">(**ソリューション エクスプ ローラー**で、ソリューションを右クリックし、[**ソリューションの配置**) します。</span><span class="sxs-lookup"><span data-stu-id="8e184-225">(In the **Solution Explorer**, right-click the solution and choose **Deploy Solution**).</span></span>

## <a name="debug-the-app-service"></a><span data-ttu-id="8e184-226">アプリ サービスのデバッグ</span><span class="sxs-lookup"><span data-stu-id="8e184-226">Debug the app service</span></span>

1.  <span data-ttu-id="8e184-227">サービスを呼び出す前にアプリ サービス プロバイダーのアプリが配置される必要があるため、ソリューションがデバッグする前に展開されるようにします。</span><span class="sxs-lookup"><span data-stu-id="8e184-227">Ensure that the solution is deployed before debugging because the app service provider app must be deployed before the service can be called.</span></span> <span data-ttu-id="8e184-228">(Visual Studio で、**[ビルド] &gt; [ソリューションの配置]** の順にクリックします)。</span><span class="sxs-lookup"><span data-stu-id="8e184-228">(In Visual Studio, **Build &gt; Deploy Solution**).</span></span>
2.  <span data-ttu-id="8e184-229">**ソリューション エクスプ ローラー**で、 **AppServiceProvider**プロジェクトを右クリックし、**プロパティ**を選択します。</span><span class="sxs-lookup"><span data-stu-id="8e184-229">In the **Solution Explorer**, right-click the **AppServiceProvider** project and choose **Properties**.</span></span> <span data-ttu-id="8e184-230">**[デバッグ]** タブで、**[開始動作]** を **[起動しないが、開始時にマイ コードをデバッグする]** に変更します。</span><span class="sxs-lookup"><span data-stu-id="8e184-230">From the **Debug** tab, change the **Start action** to **Do not launch, but debug my code when it starts**.</span></span> <span data-ttu-id="8e184-231">(C++ を使ってアプリ サービス プロバイダーを実装した場合、**[デバッグ]** タブから **[アプリケーションの起動]** を **[いいえ]** に変更します)。</span><span class="sxs-lookup"><span data-stu-id="8e184-231">(Note, if you were using C++ to implement your app service provider, from the **Debugging** tab you would change **Launch Application** to **No**).</span></span>
3.  <span data-ttu-id="8e184-232">**MyAppService**プロジェクトで、 **Inventory.cs**ファイルで**OnRequestReceived**内のブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="8e184-232">In the **MyAppService** project, in the **Inventory.cs** file, set a breakpoint in **OnRequestReceived**.</span></span>
4.  <span data-ttu-id="8e184-233">**AppServiceProvider**プロジェクトをスタートアップ プロジェクトとなるし、 **f5 キー**を押してを設定します。</span><span class="sxs-lookup"><span data-stu-id="8e184-233">Set the **AppServiceProvider** project to be the startup project and press **F5**.</span></span>
5.  <span data-ttu-id="8e184-234">(Visual Studio) からではなく [スタート] メニューから**ClientApp**を起動します。</span><span class="sxs-lookup"><span data-stu-id="8e184-234">Start **ClientApp** from the Start menu (not from Visual Studio).</span></span>
6.  <span data-ttu-id="8e184-235">数値 1 をテキスト ボックスに入力し、ボタンを押します。</span><span class="sxs-lookup"><span data-stu-id="8e184-235">Enter the number 1 into the text box and press the button.</span></span> <span data-ttu-id="8e184-236">デバッガーは、アプリ サービス内のブレークポイントでアプリ サービスの呼び出しを停止します。</span><span class="sxs-lookup"><span data-stu-id="8e184-236">The debugger will stop in the app service call on the breakpoint in your app service.</span></span>

## <a name="debug-the-client"></a><span data-ttu-id="8e184-237">クライアントのデバッグ</span><span class="sxs-lookup"><span data-stu-id="8e184-237">Debug the client</span></span>

1.  <span data-ttu-id="8e184-238">前の手順に従って、アプリ サービスを呼び出すクライアントをデバッグします。</span><span class="sxs-lookup"><span data-stu-id="8e184-238">Follow the instructions in the preceding step to debug the client that calls the app service.</span></span>
2.  <span data-ttu-id="8e184-239">[スタート] メニューから**ClientApp**を起動します。</span><span class="sxs-lookup"><span data-stu-id="8e184-239">Launch **ClientApp** from the Start menu.</span></span>
3.  <span data-ttu-id="8e184-240">( **ApplicationFrameHost.exe**プロセスではなく) **ClientApp.exe**プロセスにデバッガーをアタッチします。</span><span class="sxs-lookup"><span data-stu-id="8e184-240">Attach the debugger to the **ClientApp.exe** process (not the **ApplicationFrameHost.exe** process).</span></span> <span data-ttu-id="8e184-241">(Visual Studio で、**[デバッグ] &gt; [プロセスにアタッチ]** の順に選びます)。</span><span class="sxs-lookup"><span data-stu-id="8e184-241">(In Visual Studio, choose **Debug &gt; Attach to Process...**.)</span></span>
4.  <span data-ttu-id="8e184-242">**ClientApp**プロジェクトでは、 **button \_click**にブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="8e184-242">In the **ClientApp** project, set a breakpoint in **button\_Click**.</span></span>
5.  <span data-ttu-id="8e184-243">**ClientApp**のテキスト ボックスに数値 1 を入力ボタンをクリックすると、クライアントと、アプリ サービスの両方のブレークポイントにヒットできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="8e184-243">The breakpoints in both the client and the app service will now be hit when you enter the number 1 into the text box of **ClientApp** and click the button.</span></span>

## <a name="general-app-service-troubleshooting"></a><span data-ttu-id="8e184-244">一般的なアプリ サービスのトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="8e184-244">General app service troubleshooting</span></span>

<span data-ttu-id="8e184-245">アプリ サービスに接続しようとした後、 **AppUnavailable**状態が発生した場合は、次を確かめます。</span><span class="sxs-lookup"><span data-stu-id="8e184-245">If you encounter an **AppUnavailable** status after trying to connect to an app service, check the following:</span></span>

- <span data-ttu-id="8e184-246">アプリ サービス プロバイダー プロジェクトとアプリ サービス プロジェクトが展開されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="8e184-246">Ensure that the app service provider project and app service project are deployed.</span></span> <span data-ttu-id="8e184-247">クライアントを実行する前に、両方が展開されている必要があります。展開されていない場合、クライアントには接続先がありません。</span><span class="sxs-lookup"><span data-stu-id="8e184-247">Both need to be deployed before running the client because otherwise the client won't have anything to connect to.</span></span> <span data-ttu-id="8e184-248">Visual Studio から **[ビルド]** > **[ソリューションの配置]** で展開できます。</span><span class="sxs-lookup"><span data-stu-id="8e184-248">You can deploy from Visual Studio by using **Build** > **Deploy Solution**.</span></span>
- <span data-ttu-id="8e184-249">**ソリューション エクスプ ローラー**では、アプリ サービス プロバイダー プロジェクトにアプリ サービスを実装するプロジェクトへの参照をプロジェクトにいることを確認します。</span><span class="sxs-lookup"><span data-stu-id="8e184-249">In the **Solution Explorer**, ensure that your app service provider project has a project-to-project reference to the project that implements the app service.</span></span>
- <span data-ttu-id="8e184-250">確認、`<Extensions>`エントリとその子要素が[Package.appxmanifest をアプリ サービスの拡張機能](#appxmanifest)の追加は、上記で説明したアプリ サービス プロバイダー プロジェクトに属する**Package.appxmanifest**ファイルに追加されました。</span><span class="sxs-lookup"><span data-stu-id="8e184-250">Verify that the `<Extensions>` entry, and its child elements, have been added to the **Package.appxmanifest** file belonging to the app service provider project as specified above in [Add an app service extension to Package.appxmanifest](#appxmanifest).</span></span>
- <span data-ttu-id="8e184-251">アプリ サービス プロバイダーを呼び出すクライアントの[AppServiceConnection.AppServiceName](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appservice.appserviceconnection.appservicename)文字列と一致するように、`<uap3:AppService Name="..." />`アプリ サービス プロバイダー プロジェクトの**Package.appxmanifest**ファイルで指定します。</span><span class="sxs-lookup"><span data-stu-id="8e184-251">Ensure that the [AppServiceConnection.AppServiceName](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appservice.appserviceconnection.appservicename) string in your client that calls the app service provider matches the `<uap3:AppService Name="..." />` specified in the app service provider project's **Package.appxmanifest** file.</span></span>
- <span data-ttu-id="8e184-252">[AppServiceConnection.PackageFamilyName](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appservice.appserviceconnection.packagefamilyname)が[Package.appxmanifest をアプリ サービスの拡張機能を追加するの](#appxmanifest)には、上記で説明したアプリ サービス プロバイダーのコンポーネントのパッケージ ファミリ名と一致していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="8e184-252">Ensure that the [AppServiceConnection.PackageFamilyName](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appservice.appserviceconnection.packagefamilyname) matches the package family name of the app service provider component as specified above in [Add an app service extension to Package.appxmanifest](#appxmanifest)</span></span>
- <span data-ttu-id="8e184-253">アウト アプリなどのサービスのいずれかのこの例では、検証、`EntryPoint`で指定されている、`<uap:Extension ...>`アプリ サービス プロバイダー プロジェクトの**Package.appxmanifest**ファイルの要素に一致する名前空間とクラスのパブリックのクラス名アプリ サービス プロジェクトで、 [IBackgroundTask](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.ibackgroundtask)を実装します。</span><span class="sxs-lookup"><span data-stu-id="8e184-253">For out-of-proc app services such as the one in this example, validate that the `EntryPoint` specified in the `<uap:Extension ...>` element of your app service provider project's **Package.appxmanifest** file matches the namespace and class name of the public class that implements [IBackgroundTask](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.ibackgroundtask) in your app service project.</span></span>

### <a name="troubleshoot-debugging"></a><span data-ttu-id="8e184-254">デバッグのトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="8e184-254">Troubleshoot debugging</span></span>

<span data-ttu-id="8e184-255">アプリ サービス プロバイダーまたはアプリ サービス プロジェクトのブレークポイントでデバッガーが停止しない場合は、以下を確認します。</span><span class="sxs-lookup"><span data-stu-id="8e184-255">If the debugger does not stop at breakpoints in your app service provider or app service projects, check the following:</span></span>

- <span data-ttu-id="8e184-256">アプリ サービス プロバイダー プロジェクトとアプリ サービス プロジェクトが展開されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="8e184-256">Ensure that the app service provider project and app service project are deployed.</span></span> <span data-ttu-id="8e184-257">クライアントを実行する前に、両方が展開されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="8e184-257">Both need to be deployed before running the client.</span></span> <span data-ttu-id="8e184-258">Visual Studio から **[ビルド]** > **[ソリューションの配置]** で展開できます。</span><span class="sxs-lookup"><span data-stu-id="8e184-258">You can deploy them from Visual Studio by using **Build** > **Deploy Solution**.</span></span>
- <span data-ttu-id="8e184-259">デバッグするプロジェクトをスタートアップ プロジェクトとして設定されていると、 **f5 キー**が押されたときに、プロジェクトを実行しないようにそのプロジェクトのデバッグ プロパティを設定することを確認します。</span><span class="sxs-lookup"><span data-stu-id="8e184-259">Ensure that the project you want to debug is set as the startup project and that the debugging properties for that project are set to not run the project when **F5** is pressed.</span></span> <span data-ttu-id="8e184-260">プロジェクトを右クリックし、**[プロパティ]**、**[デバッグ]** (または C++ では **[デバッグ]**) の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="8e184-260">Right-click the project, then click **Properties**, and then **Debug** (or **Debugging** in C++).</span></span> <span data-ttu-id="8e184-261">C# では、**[開始動作]** を **[起動しないが、開始時にマイ コードをデバッグする]** に設定します。</span><span class="sxs-lookup"><span data-stu-id="8e184-261">In C#, change the **Start action** to **Do not launch, but debug my code when it starts**.</span></span> <span data-ttu-id="8e184-262">C++ では、**[アプリケーションの起動]** を **[いいえ]** に設定します。</span><span class="sxs-lookup"><span data-stu-id="8e184-262">In C++, set **Launch Application** to **No**.</span></span>

## <a name="remarks"></a><span data-ttu-id="8e184-263">注釈</span><span class="sxs-lookup"><span data-stu-id="8e184-263">Remarks</span></span>

<span data-ttu-id="8e184-264">この例では、バックグラウンド タスクとして実行されるアプリ サービスを作成して、それを別のアプリから呼び出す概要を示しています。</span><span class="sxs-lookup"><span data-stu-id="8e184-264">This example provides an introduction to creating an app service that runs as a background task and calling it from another app.</span></span> <span data-ttu-id="8e184-265">重要な点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="8e184-265">The key things to note are:</span></span>

* <span data-ttu-id="8e184-266">アプリ サービスをホストするバック グラウンド タスクを作成します。</span><span class="sxs-lookup"><span data-stu-id="8e184-266">Create a background task to host the app service.</span></span>
* <span data-ttu-id="8e184-267">追加の`windows.appService`アプリ サービス プロバイダーの**Package.appxmanifest**ファイルに拡張します。</span><span class="sxs-lookup"><span data-stu-id="8e184-267">Add the `windows.appService` extension to the app service provider's **Package.appxmanifest** file.</span></span>
* <span data-ttu-id="8e184-268">クライアント アプリからそれに接続できるように、アプリ サービス プロバイダーのパッケージ ファミリ名を取得します。</span><span class="sxs-lookup"><span data-stu-id="8e184-268">Obtain the package family name of the app service provider so that we can connect to it from the client app.</span></span>
* <span data-ttu-id="8e184-269">アプリ サービス プロジェクトに、アプリ サービス プロバイダー プロジェクトからプロジェクト間の参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="8e184-269">Add a project-to-project reference from the app service provider project to the app service project.</span></span>
* <span data-ttu-id="8e184-270">[Windows.ApplicationModel.AppService.AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/dn921704)を使用して、サービスを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="8e184-270">Use [Windows.ApplicationModel.AppService.AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/dn921704) to call the service.</span></span>

## <a name="full-code-for-myappservice"></a><span data-ttu-id="8e184-271">MyAppService の完全なコード</span><span class="sxs-lookup"><span data-stu-id="8e184-271">Full code for MyAppService</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="8e184-272">関連トピック</span><span class="sxs-lookup"><span data-stu-id="8e184-272">Related topics</span></span>

* [<span data-ttu-id="8e184-273">ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する</span><span class="sxs-lookup"><span data-stu-id="8e184-273">Convert an app service to run in the same process as its host app</span></span>](convert-app-service-in-process.md)
* [<span data-ttu-id="8e184-274">バックグラウンド タスクによるアプリのサポート</span><span class="sxs-lookup"><span data-stu-id="8e184-274">Support your app with background tasks</span></span>](support-your-app-with-background-tasks.md)
* [<span data-ttu-id="8e184-275">アプリ サービスのコード サンプル (C#、C++、および VB)</span><span class="sxs-lookup"><span data-stu-id="8e184-275">App service code sample (C#, C++, and VB)</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices)
