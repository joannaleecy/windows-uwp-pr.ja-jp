---
author: mcleanbyron
ms.assetid: 414ACC73-2A72-465C-BD15-1B51CB2334F2
title: パッケージの更新プログラムを Microsoft Store からダウンロードしてインストールする
description: デベロッパー センター ダッシュ ボードでパッケージを必須としてマークする方法と、パッケージ更新をダウンロードしてインストールするためのコードをアプリ内に記述する方法について説明します。
ms.author: mcleans
ms.date: 04/04/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 39b3ba05b06b6d484804999a935accc7223b5c60
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5471536"
---
# <a name="download-and-install-package-updates-from-the-store"></a><span data-ttu-id="ec8ec-104">パッケージの更新プログラムを Microsoft Store からダウンロードしてインストールする</span><span class="sxs-lookup"><span data-stu-id="ec8ec-104">Download and install package updates from the Store</span></span>

<span data-ttu-id="ec8ec-105">Windows 10 バージョン 1607 以降では、[Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間で [StoreContext](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) クラスのメソッドを使用して、現在のアプリに対するパッケージ更新がないかプログラムによって Microsoft Store でチェックし、更新後のパッケージをダウンロードしてインストールすることができます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-105">Starting in Windows 10, version 1607, you can use methods of the [StoreContext](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) class in the [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) namespace to programmatically check for package updates for the current app from the Microsoft Store, and download and install the updated packages.</span></span> <span data-ttu-id="ec8ec-106">また、Windows デベロッパー センター ダッシュボードで必須としてマークしたパッケージを照会し、必須の更新がインストールされるまで機能を無効にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-106">You can also query for packages that you have marked as mandatory on the Windows Dev Center dashboard and disable functionality in your app until the mandatory update is installed.</span></span>

<span data-ttu-id="ec8ec-107">Windows 10 バージョン 1803 で導入された追加の [StoreContext](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) メソッドを使うと、パッケージの更新プログラムを背後で (ユーザーに通知 UI を表示せずに) ダウンロードおよびインストールしたり、[オプション パッケージ](optional-packages.md)をアンインストールしたり、アプリのダウンロードおよびインストール キューにあるパッケージの情報を取得したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-107">Additional [StoreContext](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) methods introduced in Windows 10, version 1803 enable you to download and install package updates silently (without displaying a notification UI to the user), uninstall an [optional package](optional-packages.md), and get info about packages in the download and install queue for your app.</span></span>

<span data-ttu-id="ec8ec-108">これらの機能は、ユーザー ベースが使っているアプリ、オプション パッケージ、関連サービスを、Microsoft Store にある最新バージョンに自動的に維持するために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-108">These features help you automatically keep your user base up to date with the latest version of your app, optional packages, and related services in the Store.</span></span>

## <a name="download-and-install-package-updates-with-the-users-permission"></a><span data-ttu-id="ec8ec-109">ユーザーの許可によるパッケージの更新プログラムのダウンロードとインストール</span><span class="sxs-lookup"><span data-stu-id="ec8ec-109">Download and install package updates with the user's permission</span></span>

<span data-ttu-id="ec8ec-110">このコード例は、[GetAppAndOptionalStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getappandoptionalstorepackageupdatesasync) メソッドを使って Microsoft Store から利用可能なパッケージの更新プログラムをすべて見つけ、[RequestDownloadAndInstallStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestdownloadandinstallstorepackageupdatesasync) メソッドを呼び出して更新プログラムをダウンロードおよびインストールする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-110">This code example demonstrates how to use the [GetAppAndOptionalStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getappandoptionalstorepackageupdatesasync) method to discover all available package updates from the Store and then call the [RequestDownloadAndInstallStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestdownloadandinstallstorepackageupdatesasync) method to download and install the updates.</span></span> <span data-ttu-id="ec8ec-111">このメソッドを使って更新プログラムをダウンロードおよびインストールすると、更新プログラムをダウンロードする前にユーザーの許可を求めるダイアログが OS に表示されます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-111">When using this method to download and install updates, the OS displays a dialog that asks the user's permission before downloading the updates.</span></span>

> [!NOTE]
> <span data-ttu-id="ec8ec-112">これらのメソッドでは、アプリの必須のパッケージと[オプション パッケージ](optional-packages.md)がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-112">These methods support required and [optional packages](optional-packages.md) for your app.</span></span> <span data-ttu-id="ec8ec-113">オプション パッケージは、ダウンロード可能なコンテンツ (DLC) アドオン用や、サイズ制約に対応して大規模アプリを分割する場合、コア アプリから分離して追加コンテンツを出荷する場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-113">Optional packages are useful for downloadable content (DLC) add-ons, dividing your large app for size constraints, or for shipping additional content separate from your core app.</span></span> <span data-ttu-id="ec8ec-114">オプション パッケージ (DLC アドオンを含む) を使うアプリを Microsoft Store に提出する許可を得るには、「[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-114">To get permission to submit an app that uses optional packages (including DLC add-ons) to the Store, see [Windows developer support](https://developer.microsoft.com/windows/support).</span></span>

<span data-ttu-id="ec8ec-115">このコード例では、次のことを前提条件としています。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-115">This code example assumes:</span></span>

* <span data-ttu-id="ec8ec-116">コードは、[Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) のコンテキスト内で実行されます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-116">The code runs in the context of a [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx).</span></span>
* <span data-ttu-id="ec8ec-117">**Page** には、ダウンロード操作のステータスを提供するための、```downloadProgressBar``` という [ProgressBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressbar.aspx) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-117">The **Page** contains a [ProgressBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressbar.aspx) named ```downloadProgressBar``` to provide status for the download operation.</span></span>
* <span data-ttu-id="ec8ec-118">コード ファイルには、**Windows.Services.Store**、**Windows.Threading.Tasks**、および**Windows.UI.Popups** 名前空間の **using** ステートメントがあります。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-118">The code file has a **using** statement for the **Windows.Services.Store**, **Windows.Threading.Tasks**, and **Windows.UI.Popups** namespaces.</span></span>
* <span data-ttu-id="ec8ec-119">アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-119">The app is a single-user app that runs only in the context of the user that launched the app.</span></span> <span data-ttu-id="ec8ec-120">[マルチ ユーザー アプリ](https://msdn.microsoft.com/windows/uwp/xbox-apps/multi-user-applications) の場合は、[GetDefault](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.GetDefault) メソッドの代わりに [GetForUser](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.User) メソッドを使用して、**StoreContext** オブジェクトを取得してください。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-120">For a [multi-user app](https://msdn.microsoft.com/windows/uwp/xbox-apps/multi-user-applications), use the [GetForUser](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.User) method to get a **StoreContext** object instead of the [GetDefault](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.GetDefault) method.</span></span>

```csharp
private StoreContext context = null;

public async Task DownloadAndInstallAllUpdatesAsync()
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
    }

    // Get the updates that are available.
    IReadOnlyList<StorePackageUpdate> updates =
        await context.GetAppAndOptionalStorePackageUpdatesAsync();

    if (updates.Count > 0)
    {
        // Alert the user that updates are available and ask for their consent
        // to start the updates.
        MessageDialog dialog = new MessageDialog(
            "Download and install updates now? This may cause the application to exit.", "Download and Install?");
        dialog.Commands.Add(new UICommand("Yes"));
        dialog.Commands.Add(new UICommand("No"));
        IUICommand command = await dialog.ShowAsync();

        if (command.Label.Equals("Yes", StringComparison.CurrentCultureIgnoreCase))
        {
            // Download and install the updates.
            IAsyncOperationWithProgress<StorePackageUpdateResult, StorePackageUpdateStatus> downloadOperation =
                context.RequestDownloadAndInstallStorePackageUpdatesAsync(updates);

            // The Progress async method is called one time for each step in the download
            // and installation process for each package in this request.
            downloadOperation.Progress = async (asyncInfo, progress) =>
            {
                await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                () =>
                {
                    downloadProgressBar.Value = progress.PackageDownloadProgress;
                });
            };

            StorePackageUpdateResult result = await downloadOperation.AsTask();
        }
    }
}
```

> [!NOTE]
> <span data-ttu-id="ec8ec-121">利用可能なパッケージの更新プログラムをダウンロードするだけ (インストールしない) の場合は、[RequestDownloadStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestdownloadstorepackageupdatesasync) メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-121">To only download (but not install) the available package updates, use the [RequestDownloadStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestdownloadstorepackageupdatesasync) method.</span></span>

### <a name="display-download-and-install-progress-info"></a><span data-ttu-id="ec8ec-122">ダウンロードとインストールの進行状況の情報を表示する</span><span class="sxs-lookup"><span data-stu-id="ec8ec-122">Display download and install progress info</span></span>

<span data-ttu-id="ec8ec-123">[RequestDownloadStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestdownloadstorepackageupdatesasync) メソッドまたは [RequestDownloadAndInstallStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestdownloadandinstallstorepackageupdatesasync) メソッドを呼び出すときに、この要求で各パッケージのダウンロード (またはダウンロードとインストール) 処理の手順ごとに 1 回呼び出される [Progress](https://docs.microsoft.com/uwp/api/windows.foundation.iasyncoperationwithprogress-2.progress) ハンドラーを割り当てることができます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-123">When you call the [RequestDownloadStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestdownloadstorepackageupdatesasync) or [RequestDownloadAndInstallStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestdownloadandinstallstorepackageupdatesasync) method, you can assign a [Progress](https://docs.microsoft.com/uwp/api/windows.foundation.iasyncoperationwithprogress-2.progress) handler that is called one time for each step in the download (or download and install) process for each package in this request.</span></span> <span data-ttu-id="ec8ec-124">このハンドラーは、進行状況の通知を発生させる更新パッケージに関する情報を提供する [StorePackageUpdateStatus](https://docs.microsoft.com/uwp/api/windows.services.store.storepackageupdatestatus) オブジェクトを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-124">The handler receives a [StorePackageUpdateStatus](https://docs.microsoft.com/uwp/api/windows.services.store.storepackageupdatestatus) object that provides info about the update package that raised the progress notification.</span></span> <span data-ttu-id="ec8ec-125">前の例では、**StorePackageUpdateStatus** オブジェクトの **PackageDownloadProgress** フィールドを使用して、ダウンロードとインストールの進行状況を表示します。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-125">The previous example uses the **PackageDownloadProgress** field of the **StorePackageUpdateStatus** object to display the progress of the download and install process.</span></span>

<span data-ttu-id="ec8ec-126">**RequestDownloadAndInstallStorePackageUpdatesAsync** を呼び出して 1 つの操作でパッケージの更新プログラムをダウンロードしてインストールする場合、**PackageDownloadProgress** フィールドは、パッケージのダウンロード処理中に 0.0 から 0.8 まで増加した後、インストール時に 0.8 から 1.0 まで増加することに注意してください。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-126">Be aware that when you call **RequestDownloadAndInstallStorePackageUpdatesAsync** to download and install package updates in a single operation, the **PackageDownloadProgress** field increases from 0.0 to 0.8 during the download process for a package, and then it increases from 0.8 to 1.0 during the install.</span></span> <span data-ttu-id="ec8ec-127">そのため、カスタム進行状況 UI に表示されるパーセンテージを、直接、**PackageDownloadProgress** フィールドの値にマップする場合、パッケージのダウンロードが完了し、OS でインストール ダイアログが表示されたときに、UI には 80% と表示されます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-127">Therefore, if you map the percentage shown in your custom progress UI directly to the value of the **PackageDownloadProgress** field, your UI will show 80% when the package is finished downloading and the OS displays the installation dialog.</span></span> <span data-ttu-id="ec8ec-128">パッケージがダウンロードされ、インストールの準備ができたときに、カスタム進行状況 UI で 100% と表示するには、**PackageDownloadProgress** が 0.8 に達したときに進行状況 UI に 100% を割り当てるようにコードを変更します。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-128">If you want your custom progress UI to display 100% when the package is downloaded and ready to be installed, you can modify your code to assign 100% to your progress UI when the **PackageDownloadProgress** field reaches 0.8.</span></span>

## <a name="download-and-install-package-updates-silently"></a><span data-ttu-id="ec8ec-129">パッケージの更新プログラムを背後でダウンロードしてインストールする</span><span class="sxs-lookup"><span data-stu-id="ec8ec-129">Download and install package updates silently</span></span>

<span data-ttu-id="ec8ec-130">Windows 10 バージョン 1803 以降では、[TrySilentDownloadStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.trysilentdownloadstorepackageupdatesasync) メソッドと [TrySilentDownloadAndInstallStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.trysilentdownloadandinstallstorepackageupdatesasync) メソッドを使って、ユーザーに通知 UI を表示せずに背後でパッケージの更新プログラムをダウンロードおよびインストールできます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-130">Starting in Windows 10, version 1803, you can use the [TrySilentDownloadStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.trysilentdownloadstorepackageupdatesasync) and [TrySilentDownloadAndInstallStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.trysilentdownloadandinstallstorepackageupdatesasync) methods to download and install package updates silently, without displaying a notification UI to the user.</span></span> <span data-ttu-id="ec8ec-131">この操作は、ユーザーが Microsoft Store で **[アプリを自動的に更新]** 設定をオンにしており、ユーザーが従量制課金接続を使っていない場合のみ成功します。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-131">This operation will succeed only if the user has enabled the **Update apps automatically** setting in the Store and the user is not on a metered network.</span></span> <span data-ttu-id="ec8ec-132">これらのメソッドを呼び出す前に、まず [CanSilentlyDownloadStorePackageUpdates](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.cansilentlydownloadstorepackageupdates) プロパティを確認し、これらの条件を現在満たしているかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-132">Before calling these methods, you can first check the [CanSilentlyDownloadStorePackageUpdates](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.cansilentlydownloadstorepackageupdates) property to determine whether these conditions are currently met.</span></span>

<span data-ttu-id="ec8ec-133">このコード例は、[GetAppAndOptionalStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getappandoptionalstorepackageupdatesasync) メソッドを使って利用可能なパッケージの更新プログラムをすべて見つけた後、[TrySilentDownloadStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.trysilentdownloadstorepackageupdatesasync) メソッドと [TrySilentDownloadAndInstallStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.trysilentdownloadandinstallstorepackageupdatesasync) メソッドを呼び出して背後で更新プログラムをダウンロードおよびインストールする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-133">This code example demonstrates how to use the [GetAppAndOptionalStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getappandoptionalstorepackageupdatesasync) method to discover all available package updates and then call the [TrySilentDownloadStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.trysilentdownloadstorepackageupdatesasync) and [TrySilentDownloadAndInstallStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.trysilentdownloadandinstallstorepackageupdatesasync) methods to download and install the updates silently.</span></span>

<span data-ttu-id="ec8ec-134">このコード例では、次のことを前提条件としています。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-134">This code example assumes:</span></span>
* <span data-ttu-id="ec8ec-135">コード ファイルに **Windows.Services.Store** 名前空間と **System.Threading.Tasks** 名前空間を使うための **using** ステートメントがある。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-135">The code file has a **using** statement for the **Windows.Services.Store** and  **System.Threading.Tasks** namespaces.</span></span>
* <span data-ttu-id="ec8ec-136">アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリである。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-136">The app is a single-user app that runs only in the context of the user that launched the app.</span></span> <span data-ttu-id="ec8ec-137">[マルチ ユーザー アプリ](https://msdn.microsoft.com/windows/uwp/xbox-apps/multi-user-applications) の場合は、[GetDefault](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.GetDefault) メソッドの代わりに [GetForUser](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.User) メソッドを使用して、**StoreContext** オブジェクトを取得してください。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-137">For a [multi-user app](https://msdn.microsoft.com/windows/uwp/xbox-apps/multi-user-applications), use the [GetForUser](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.User) method to get a **StoreContext** object instead of the [GetDefault](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.GetDefault) method.</span></span>

> [!NOTE]
> <span data-ttu-id="ec8ec-138">この例のコードにより呼び出されている **IsNowAGoodTimeToRestartApp**、**RetryDownloadAndInstallLater**、**RetryInstallLater** の各メソッドは、アプリの設計の必要に応じて実装することを目的としたプレースホルダー メソッドです。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-138">The **IsNowAGoodTimeToRestartApp**, **RetryDownloadAndInstallLater**, and **RetryInstallLater** methods called by the code in this example are placeholder methods that are intended to be implemented as needed according to your own app's design.</span></span>

```csharp
private StoreContext context = null;

public async Task DownloadAndInstallAllUpdatesInBackgroundAsync()
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
    }

    // Get the updates that are available.
    IReadOnlyList<StorePackageUpdate> storePackageUpdates =
        await context.GetAppAndOptionalStorePackageUpdatesAsync();

    if (storePackageUpdates.Count > 0)
    {

        if (!context.CanSilentlyDownloadStorePackageUpdates)
        {
            return;
        }

        // Start the silent downloads and wait for the downloads to complete.
        StorePackageUpdateResult downloadResult =
            await context.TrySilentDownloadStorePackageUpdatesAsync(storePackageUpdates);

        switch (downloadResult.OverallState)
        {
            case StorePackageUpdateState.Completed:
                // The download has completed successfully. At this point, confirm whether your app
                // can restart now and then install the updates (for example, you might only install
                // packages silently if your app has been idle for a certain period of time). The
                // IsNowAGoodTimeToRestartApp method is not implemented in this example, you should
                // implement it as needed for your own app.
                if (IsNowAGoodTimeToRestartApp())
                {
                    await InstallUpdate(storePackageUpdates);
                }
                else
                {
                    // Retry/reschedule the installation later. The RetryInstallLater method is not  
                    // implemented in this example, you should implement it as needed for your own app.
                    RetryInstallLater();
                    return;
                }
                break;
            // If the user cancelled the download or you can't perform the download for some other
            // reason (for example, Wi-Fi might have been turned off and the device is now on
            // a metered network) try again later. The RetryDownloadAndInstallLater method is not  
            // implemented in this example, you should implement it as needed for your own app.
            case StorePackageUpdateState.Canceled:
            case StorePackageUpdateState.ErrorLowBattery:
            case StorePackageUpdateState.ErrorWiFiRecommended:
            case StorePackageUpdateState.ErrorWiFiRequired:
            case StorePackageUpdateState.OtherError:
                RetryDownloadAndInstallLater();
                return;
            default:
                break;
        }
    }
}

private async Task InstallUpdate(IReadOnlyList<StorePackageUpdate> storePackageUpdates)
{
    // Start the silent installation of the packages. Because the packages have already
    // been downloaded in the previous method, the following line of code just installs
    // the downloaded packages.
    StorePackageUpdateResult downloadResult =
        await context.TrySilentDownloadAndInstallStorePackageUpdatesAsync(storePackageUpdates);

    switch (downloadResult.OverallState)
    {
        // If the user cancelled the installation or you can't perform the installation  
        // for some other reason, try again later. The RetryInstallLater method is not  
        // implemented in this example, you should implement it as needed for your own app.
        case StorePackageUpdateState.Canceled:
        case StorePackageUpdateState.ErrorLowBattery:
        case StorePackageUpdateState.OtherError:
            RetryInstallLater();
            return;
        default:
            break;
    }
}
```

## <a name="mandatory-package-updates"></a><span data-ttu-id="ec8ec-139">必須のパッケージの更新プログラム</span><span class="sxs-lookup"><span data-stu-id="ec8ec-139">Mandatory package updates</span></span>

<span data-ttu-id="ec8ec-140">Windows 10 バージョン 1607 以降を対象としたアプリのパッケージ申請を作成する際には、[パッケージを必須としてマーク](../publish/upload-app-packages.md#mandatory-update)し、それが必須になる日時を指定することができます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-140">When you create a package submission for an app that targets Windows 10, version 1607 or later, you can [mark the package as mandatory](../publish/upload-app-packages.md#mandatory-update) and the date and time on which it becomes mandatory.</span></span> <span data-ttu-id="ec8ec-141">このプロパティが設定されている場合、利用可能なパッケージの更新が検出されると、アプリは更新パッケージが必須であることを認識し、更新がインストールされるまで、その動作を変更することができます (機能を無効にするなど)。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-141">When this property is set and your app discovers that the package update is available, your app can determine whether the update package is mandatory and alter its behavior until the update is installed (for example, your app can disable features).</span></span>

> [!NOTE]
> <span data-ttu-id="ec8ec-142">パッケージ更新の必須ステータスは Microsoft によって強制されるものではありません。アプリの必須更新プログラムをインストールする必要があることをユーザーに示すための UI は、OS では提供されていません。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-142">The mandatory status of a package update is not enforced by Microsoft, and the OS does not provide a UI to indicate to users that a mandatory app update must be installed.</span></span> <span data-ttu-id="ec8ec-143">必須設定は、開発者が自身のコード内でアプリの必須更新プログラムを強制するために使用するものです。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-143">Developers are intended to use the mandatory setting to enforce mandatory app updates in their own code.</span></span>  

<span data-ttu-id="ec8ec-144">パッケージ申請を必須としてマークするには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-144">To mark a package submission as mandatory:</span></span>

1. <span data-ttu-id="ec8ec-145">[デベロッパー センター ダッシュ ボード](https://dev.windows.com/overview)にサインインし、アプリの概要ページに移動します。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-145">Sign in to the [Dev Center dashboard](https://dev.windows.com/overview) and navigate to the overview page for your app.</span></span>
2. <span data-ttu-id="ec8ec-146">必須にするパッケージ更新が含まれている申請の名前をクリックします。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-146">Click the name of the submission that contains the package update you want to make mandatory.</span></span>
3. <span data-ttu-id="ec8ec-147">申請の **[パッケージ]** ページに移動します。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-147">Navigate to the **Packages** page for the submission.</span></span> <span data-ttu-id="ec8ec-148">このページの下部で、**[この更新を必須にします]** を選択した後、パッケージ更新が必須になる日時を選択します。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-148">Near the bottom of this page, select **Make this update mandatory** and then choose the day and time on which the package update becomes mandatory.</span></span> <span data-ttu-id="ec8ec-149">このオプションは、申請内のすべての UWP パッケージに適用されます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-149">This option applies to all UWP packages in the submission.</span></span>

<span data-ttu-id="ec8ec-150">詳細については、「[アプリ パッケージのアップロード](../publish/upload-app-packages.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-150">For more information, see [Upload app packages](../publish/upload-app-packages.md).</span></span>

> [!NOTE]
> <span data-ttu-id="ec8ec-151">[パッケージ フライト](../publish/package-flights.md)を作成する場合は、フライトの**パッケージ** ページで同様の UI を使用して、パッケージを必須としてマークできます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-151">If you create a [package flight](../publish/package-flights.md), you can mark the packages as mandatory using a similar UI on the **Packages** page for the flight.</span></span> <span data-ttu-id="ec8ec-152">その場合、必須のパッケージ更新は、フライト グループのメンバーであるユーザーにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-152">In this case, the mandatory package update applies only to the customers who are part of the flight group.</span></span>

### <a name="code-example-for-mandatory-packages"></a><span data-ttu-id="ec8ec-153">必須パッケージのコード例</span><span class="sxs-lookup"><span data-stu-id="ec8ec-153">Code example for mandatory packages</span></span>

<span data-ttu-id="ec8ec-154">次のコード例は、更新パッケージが必須であるかどうかを調べる方法を示したものです。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-154">The following code example demonstrates how to determine whether any update packages are mandatory.</span></span> <span data-ttu-id="ec8ec-155">通常、必須のパッケージ更新を正常にダウンロードまたはインストールできない場合は、ユーザーに不便のない方法でアプリのエクスペリエンスをダウングレードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-155">Typically, you should downgrade your app experience gracefully for the user if a mandatory package update does not successfully download or install.</span></span>

```csharp
private StoreContext context = null;

// Downloads and installs package updates in separate steps.
public async Task DownloadAndInstallAllUpdatesAsync()
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
    }  

    // Get the updates that are available.
    IReadOnlyList<StorePackageUpdate> updates =
        await context.GetAppAndOptionalStorePackageUpdatesAsync();

    if (updates.Count != 0)
    {
        // Download the packages.
        bool downloaded = await DownloadPackageUpdatesAsync(updates);

        if (downloaded)
        {
            // Install the packages.
            await InstallPackageUpdatesAsync(updates);
        }
    }
}

// Helper method for downloading package updates.
private async Task<bool> DownloadPackageUpdatesAsync(IEnumerable<StorePackageUpdate> updates)
{
    bool downloadedSuccessfully = false;

    IAsyncOperationWithProgress<StorePackageUpdateResult, StorePackageUpdateStatus> downloadOperation =
        this.context.RequestDownloadStorePackageUpdatesAsync(updates);

    // The Progress async method is called one time for each step in the download process for each
    // package in this request.
    downloadOperation.Progress = async (asyncInfo, progress) =>
    {
        await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
        () =>
        {
            downloadProgressBar.Value = progress.PackageDownloadProgress;
        });
    };

    StorePackageUpdateResult result = await downloadOperation.AsTask();

    switch (result.OverallState)
    {
        case StorePackageUpdateState.Completed:
            downloadedSuccessfully = true;
            break;
        default:
            // Get the failed updates.
            var failedUpdates = result.StorePackageUpdateStatuses.Where(
                status => status.PackageUpdateState != StorePackageUpdateState.Completed);

            // See if any failed updates were mandatory
            if (updates.Any(u => u.Mandatory && failedUpdates.Any(
                failed => failed.PackageFamilyName == u.Package.Id.FamilyName)))
            {
                // At least one of the updates is mandatory. Perform whatever actions you
                // want to take for your app: for example, notify the user and disable
                // features in your app.
                HandleMandatoryPackageError();
            }
            break;
    }

    return downloadedSuccessfully;
}

// Helper method for installing package updates.
private async Task InstallPackageUpdatesAsync(IEnumerable<StorePackageUpdate> updates)
{
    IAsyncOperationWithProgress<StorePackageUpdateResult, StorePackageUpdateStatus> installOperation =
        this.context.RequestDownloadAndInstallStorePackageUpdatesAsync(updates);

    // The package updates were already downloaded separately, so this method skips the download
    // operatation and only installs the updates; no download progress notifications are provided.
    StorePackageUpdateResult result = await installOperation.AsTask();

    switch (result.OverallState)
    {
        case StorePackageUpdateState.Completed:
            break;
        default:
            // Get the failed updates.
            var failedUpdates = result.StorePackageUpdateStatuses.Where(
                status => status.PackageUpdateState != StorePackageUpdateState.Completed);

            // See if any failed updates were mandatory
            if (updates.Any(u => u.Mandatory && failedUpdates.Any(failed => failed.PackageFamilyName == u.Package.Id.FamilyName)))
            {
                // At least one of the updates is mandatory, so tell the user.
                HandleMandatoryPackageError();
            }
            break;
    }
}

// Helper method for handling the scenario where a mandatory package update fails to
// download or install. Add code to this method to perform whatever actions you want
// to take, such as notifying the user and disabling features in your app.
private void HandleMandatoryPackageError()
{
}
```

## <a name="uninstall-optional-packages"></a><span data-ttu-id="ec8ec-156">オプション パッケージのアンインストール</span><span class="sxs-lookup"><span data-stu-id="ec8ec-156">Uninstall optional packages</span></span>

<span data-ttu-id="ec8ec-157">Windows 10 バージョン 1803 以降では、[RequestUninstallStorePackageAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestuninstallstorepackageasync) メソッドまたは [RequestUninstallStorePackageByStoreIdAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestuninstallstorepackagebystoreidasync) メソッドを使って、現在のアプリの[オプション パッケージ](optional-packages.md) (DLC パッケージを含む) をアンインストールできます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-157">Starting in Windows 10, version 1803, you can use the [RequestUninstallStorePackageAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestuninstallstorepackageasync) or [RequestUninstallStorePackageByStoreIdAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestuninstallstorepackagebystoreidasync) methods to uninstall an [optional package](optional-packages.md) (including a DLC package) for the current app.</span></span> <span data-ttu-id="ec8ec-158">たとえば、オプション パッケージを通じてインストールされるコンテンツを持つアプリがある場合、ユーザーがオプション パッケージをアンインストールしてディスク領域を解放できる UI を用意できます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-158">For example, if you have an app with content that is installed via optional packages, you might want to provide a UI that enables users to uninstall the optional packages to free up disk space.</span></span>

<span data-ttu-id="ec8ec-159">次のコード例は、[RequestUninstallStorePackageAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestuninstallstorepackageasync) を呼び出す方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-159">The following code example demonstrates how to call [RequestUninstallStorePackageAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestuninstallstorepackageasync).</span></span> <span data-ttu-id="ec8ec-160">この例では、次のことを前提条件としています。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-160">This example assumes:</span></span>
* <span data-ttu-id="ec8ec-161">コード ファイルに **Windows.Services.Store** 名前空間と **System.Threading.Tasks** 名前空間を使うための **using** ステートメントがある。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-161">The code file has a **using** statement for the **Windows.Services.Store** and  **System.Threading.Tasks** namespaces.</span></span>
* <span data-ttu-id="ec8ec-162">アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリである。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-162">The app is a single-user app that runs only in the context of the user that launched the app.</span></span> <span data-ttu-id="ec8ec-163">[マルチ ユーザー アプリ](https://msdn.microsoft.com/windows/uwp/xbox-apps/multi-user-applications) の場合は、[GetDefault](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.GetDefault) メソッドの代わりに [GetForUser](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.User) メソッドを使用して、**StoreContext** オブジェクトを取得してください。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-163">For a [multi-user app](https://msdn.microsoft.com/windows/uwp/xbox-apps/multi-user-applications), use the [GetForUser](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.User) method to get a **StoreContext** object instead of the [GetDefault](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.GetDefault) method.</span></span>

```csharp
public async Task UninstallPackage(Windows.ApplicationModel.Package package)
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
    }

    var storeContext = StoreContext.GetDefault();
    IAsyncOperation<StoreUninstallStorePackageResult> uninstallOperation =
        storeContext.RequestUninstallStorePackageAsync(package);

    // At this point, you can update your app UI to show that the package
    // is installing.

    uninstallOperation.Completed += (asyncInfo, status) =>
    {
        StoreUninstallStorePackageResult result = uninstallOperation.GetResults();
        switch (result.Status)
        {
            case StoreUninstallStorePackageStatus.Succeeded:
                {
                    // Update your app UI to show the package as uninstalled.
                    break;
                }
            default:
                {
                    // Update your app UI to show that the package uninstall failed.
                    break;
                }
        }
    };
}
```

## <a name="get-download-queue-info"></a><span data-ttu-id="ec8ec-164">ダウンロード キューの情報の取得</span><span class="sxs-lookup"><span data-stu-id="ec8ec-164">Get download queue info</span></span>

<span data-ttu-id="ec8ec-165">Windows 10 バージョン 1803 以降では、[GetAssociatedStoreQueueItemsAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getassociatedstorequeueitemsasync) メソッドと [GetStoreQueueItemsAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getstorequeueitemsasync) メソッドを使い、現在のダウンロードおよびインストール キューにあるパッケージの情報を Microsoft Store から取得することができます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-165">Starting in Windows 10, version 1803, you can use the [GetAssociatedStoreQueueItemsAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getassociatedstorequeueitemsasync) and [GetStoreQueueItemsAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getstorequeueitemsasync) methods to get info about the packages that are in the current download and installation queue from the Store.</span></span> <span data-ttu-id="ec8ec-166">これらのメソッドは、ダウンロードとインストールに数時間から数日かかる可能性がある大規模なオプション パッケージ (DLC を含む) がアプリやゲームでサポートされており、ダウンロードおよびインストール プロセスが完了する前にユーザーがアプリやゲームを閉じるケースを適切に処理する必要がある場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-166">These methods are useful if your app or game supports large optional packages (including DLCs) that can take hours or days to download and install, and you want to gracefully handle the case where a customer closes your app or game before the download and installation process is complete.</span></span> <span data-ttu-id="ec8ec-167">ユーザーがアプリやゲームを再度起動すると、コードはこれらのメソッドを使ってダウンロードおよびインストール キューにまだ残っているパッケージの状態に関する情報を取得できるため、各パッケージのステータスをユーザーに表示できます。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-167">When the customer starts your app or game again, your code can use these methods to get info about the state of the packages that are still in the download and installation queue so you can display the status of each package to the customer.</span></span>

<span data-ttu-id="ec8ec-168">次のコード例は、[GetAssociatedStoreQueueItemsAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getassociatedstorequeueitemsasync) を呼び出し、現在のアプリの進行中のパッケージ更新プログラムの一覧を取得して、各パッケージのステータス情報を表示する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-168">The following code example demonstrates how to call [GetAssociatedStoreQueueItemsAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getassociatedstorequeueitemsasync) to get the list of in-progress package updates for the current app and retrieve status info for each package.</span></span> <span data-ttu-id="ec8ec-169">この例では、次のことを前提条件としています。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-169">This example assumes:</span></span>
* <span data-ttu-id="ec8ec-170">コード ファイルに **Windows.Services.Store** 名前空間と **System.Threading.Tasks** 名前空間を使うための **using** ステートメントがある。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-170">The code file has a **using** statement for the **Windows.Services.Store** and  **System.Threading.Tasks** namespaces.</span></span>
* <span data-ttu-id="ec8ec-171">アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリである。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-171">The app is a single-user app that runs only in the context of the user that launched the app.</span></span> <span data-ttu-id="ec8ec-172">[マルチ ユーザー アプリ](https://msdn.microsoft.com/windows/uwp/xbox-apps/multi-user-applications) の場合は、[GetDefault](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.GetDefault) メソッドの代わりに [GetForUser](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.User) メソッドを使用して、**StoreContext** オブジェクトを取得してください。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-172">For a [multi-user app](https://msdn.microsoft.com/windows/uwp/xbox-apps/multi-user-applications), use the [GetForUser](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.User) method to get a **StoreContext** object instead of the [GetDefault](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.GetDefault) method.</span></span>

> [!NOTE]
> <span data-ttu-id="ec8ec-173">この例のコードにより呼び出されている **MarkUpdateInProgressInUI**、**RemoveItemFromUI**、**MarkInstallCompleteInUI**、**MarkInstallErrorInUI**、**MarkInstallPausedInUI** の各メソッドは、アプリの設計の必要に応じて実装することを目的としてプレースホルダー メソッドです。</span><span class="sxs-lookup"><span data-stu-id="ec8ec-173">The **MarkUpdateInProgressInUI**, **RemoveItemFromUI**, **MarkInstallCompleteInUI**, **MarkInstallErrorInUI**, and **MarkInstallPausedInUI** methods called by the code in this example are placeholder methods that are intended to be implemented as needed according to your own app's design.</span></span>

```csharp
private StoreContext context = null;

private async Task GetQueuedInstallItemsAndBuildInitialStoreUI()
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
    }

    // Get the Store packages in the install queue.
    IReadOnlyList<StoreQueueItem> storeUpdateItems = await context.GetAssociatedStoreQueueItemsAsync();

    foreach (StoreQueueItem storeItem in storeUpdateItems)
    {
        // In this example we only care about package updates.
        if (storeItem.InstallKind != StoreQueueItemKind.Update)
            continue;

        StoreQueueItemStatus currentStatus = storeItem.GetCurrentStatus();
        StoreQueueItemState installState = currentStatus.PackageInstallState;
        StoreQueueItemExtendedState extendedInstallState =
            currentStatus.PackageInstallExtendedState;

        // Handle the StatusChanged event to display current status to the customer.
        storeItem.StatusChanged += StoreItem_StatusChanged;

        switch (installState)
        {
            // Download and install are still in progress, so update the status for this  
            // item and provide the extended state info. The following methods are not
            // implemented in this example; you should implement them as needed for your
            // app's UI.
            case StoreQueueItemState.Active:
                MarkUpdateInProgressInUI(storeItem, extendedInstallState);
                break;
            case StoreQueueItemState.Canceled:
                RemoveItemFromUI(storeItem);
                break;
            case StoreQueueItemState.Completed:
                MarkInstallCompleteInUI(storeItem);
                break;
            case StoreQueueItemState.Error:
                MarkInstallErrorInUI(storeItem);
                break;
            case StoreQueueItemState.Paused:
                MarkInstallPausedInUI(storeItem, installState, extendedInstallState);
                break;
        }
    }
}

private void StoreItem_StatusChanged(StoreQueueItem sender, object args)
{
    StoreQueueItemStatus currentStatus = sender.GetCurrentStatus();
    StoreQueueItemState installState = currentStatus.PackageInstallState;
    StoreQueueItemExtendedState extendedInstallState = currentStatus.PackageInstallExtendedState;

    switch (installState)
    {
        // Download and install are still in progress, so update the status for this  
        // item and provide the extended state info. The following methods are not
        // implemented in this example; you should implement them as needed for your
        // app's UI.
        case StoreQueueItemState.Active:
            MarkUpdateInProgressInUI(sender, extendedInstallState);
            break;
        case StoreQueueItemState.Canceled:
            RemoveItemFromUI(sender);
            break;
        case StoreQueueItemState.Completed:
            MarkInstallCompleteInUI(sender);
            break;
        case StoreQueueItemState.Error:
            MarkInstallErrorInUI(sender);
            break;
        case StoreQueueItemState.Paused:
            MarkInstallPausedInUI(sender, installState, extendedInstallState);
            break;
    }
}
```

## <a name="related-topics"></a><span data-ttu-id="ec8ec-174">関連トピック</span><span class="sxs-lookup"><span data-stu-id="ec8ec-174">Related topics</span></span>

* [<span data-ttu-id="ec8ec-175">オプション パッケージと関連セットの作成</span><span class="sxs-lookup"><span data-stu-id="ec8ec-175">Optional packages and related set authoring</span></span>](optional-packages.md)
