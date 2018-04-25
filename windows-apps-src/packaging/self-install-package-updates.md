---
author: mcleanbyron
ms.assetid: 414ACC73-2A72-465C-BD15-1B51CB2334F2
title: アプリのパッケージの更新をダウンロードしてインストールする
description: デベロッパー センター ダッシュ ボードでパッケージを必須としてマークする方法と、パッケージ更新をダウンロードしてインストールするためのコードをアプリ内に記述する方法について説明します。
ms.author: mcleans
ms.date: 03/22/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP
ms.localizationpriority: high
ms.openlocfilehash: ce2f6d6607f09186a3969f37b6808fa1f04fb338
ms.sourcegitcommit: 6618517dc0a4e4100af06e6d27fac133d317e545
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
---
# <a name="download-and-install-package-updates-for-your-app"></a><span data-ttu-id="3b781-104">アプリのパッケージの更新をダウンロードしてインストールする</span><span class="sxs-lookup"><span data-stu-id="3b781-104">Download and install package updates for your app</span></span>


<span data-ttu-id="3b781-105">Windows 10 バージョン 1607 以降では、[Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間の API を使用して、現在のアプリに対するパッケージ更新をプログラムからチェックし、更新後のパッケージをダウンロードしてインストールすることができます。</span><span class="sxs-lookup"><span data-stu-id="3b781-105">Starting in Windows 10, version 1607, you can use an API in the [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) namespace to programmatically check for package updates for the current app, and download and install the updated packages.</span></span> <span data-ttu-id="3b781-106">また、[Windows デベロッパー センター ダッシュボードで必須としてマークされている](#mandatory-dashboard)パッケージを照会し、必須の更新がインストールされるまで機能を無効にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="3b781-106">You can also query for packages that have been [marked as mandatory on the Windows Dev Center dashboard](#mandatory-dashboard) and disable functionality in your app until the mandatory update is installed.</span></span>

<span data-ttu-id="3b781-107">これらの機能は、ユーザー ベースが使用しているアプリや関連サービスを、自動的に最新バージョンに維持するために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="3b781-107">These features help you to automatically keep your user base up to date with the latest version of your app and related services.</span></span>

## <a name="api-overview"></a><span data-ttu-id="3b781-108">API の概要</span><span class="sxs-lookup"><span data-stu-id="3b781-108">API overview</span></span>

<span data-ttu-id="3b781-109">Windows 10 バージョン 1607 以降を対象としたアプリでは、[StoreContext](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) クラスの次のメソッドを使用して、パッケージの更新をダウンロードし、インストールすることができます。</span><span class="sxs-lookup"><span data-stu-id="3b781-109">Apps that targets Windows 10, version 1607 or later can use the following methods of the [StoreContext](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) class to download and install package updates.</span></span>

|  <span data-ttu-id="3b781-110">メソッド</span><span class="sxs-lookup"><span data-stu-id="3b781-110">Method</span></span>  |  <span data-ttu-id="3b781-111">[説明]</span><span class="sxs-lookup"><span data-stu-id="3b781-111">Description</span></span>  |
|----------|---------------|
| [<span data-ttu-id="3b781-112">GetAppAndOptionalStorePackageUpdatesAsync</span><span class="sxs-lookup"><span data-stu-id="3b781-112">GetAppAndOptionalStorePackageUpdatesAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.GetAppAndOptionalStorePackageUpdatesAsync) | <span data-ttu-id="3b781-113">利用できるパッケージの更新の一覧を取得するには、このメソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="3b781-113">Call this method to get the list of package updates that are available.</span></span> <span data-ttu-id="3b781-114">パッケージが認定プロセスを通過した後、そのパッケージ更新がアプリで利用可能になったことを **GetAppAndOptionalStorePackageUpdatesAsync** メソッドが認識するまでには、最大で 1 日間の遅延が生じる可能性があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="3b781-114">Note that there can be a delay of up to a day between the time when a package passes the certification process and when the **GetAppAndOptionalStorePackageUpdatesAsync** method recognizes that the package update is available to the app.</span></span> |
| [<span data-ttu-id="3b781-115">RequestDownloadStorePackageUpdatesAsync</span><span class="sxs-lookup"><span data-stu-id="3b781-115">RequestDownloadStorePackageUpdatesAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestdownloadstorepackageupdatesasync) | <span data-ttu-id="3b781-116">このメソッドを呼び出して、利用可能なパッケージの更新をダウンロードします (インストールはされません)。</span><span class="sxs-lookup"><span data-stu-id="3b781-116">Call this method to download (but not install) the available package updates.</span></span> <span data-ttu-id="3b781-117">この OS では、更新プログラムのダウンロードに対してユーザーのアクセス許可を求めるダイアログが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3b781-117">This OS displays a dialog that asks the user's permission to download the updates.</span></span> |
| [<span data-ttu-id="3b781-118">RequestDownloadAndInstallStorePackageUpdatesAsync</span><span class="sxs-lookup"><span data-stu-id="3b781-118">RequestDownloadAndInstallStorePackageUpdatesAsync</span></span>](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestdownloadandinstallstorepackageupdatesasync) | <span data-ttu-id="3b781-119">利用可能なパッケージの更新をダウンロードしてインストールするには、このメソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="3b781-119">Call this method to download and install the available package updates.</span></span> <span data-ttu-id="3b781-120">OS では、更新プログラムのダウンロードとインストールに対してユーザーのアクセス許可を求めるダイアログが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3b781-120">The OS displays dialogs that ask the user's permission to download and install the updates.</span></span> <span data-ttu-id="3b781-121">**RequestDownloadStorePackageUpdatesAsync** を呼び出すことでパッケージの更新が既にダウンロードされている場合、このメソッドはダウンロード プロセスをスキップし、更新のインストールのみを行います。</span><span class="sxs-lookup"><span data-stu-id="3b781-121">If you already downloaded the package updates by calling **RequestDownloadStorePackageUpdatesAsync**, this method skips the download process and only installs the updates.</span></span>  |

<span/>

<span data-ttu-id="3b781-122">これらのメソッドは [StorePackageUpdate](https://docs.microsoft.com/uwp/api/windows.services.store.storepackageupdate) オブジェクトを使用して、使用可能な更新プログラム パッケージを表します。</span><span class="sxs-lookup"><span data-stu-id="3b781-122">These methods use [StorePackageUpdate](https://docs.microsoft.com/uwp/api/windows.services.store.storepackageupdate) objects to represent available update packages.</span></span> <span data-ttu-id="3b781-123">次の **StorePackageUpdate** プロパティを使用して、更新プログラム パッケージに関する情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="3b781-123">Use the following **StorePackageUpdate** properties to get information about an update package.</span></span>

|  <span data-ttu-id="3b781-124">プロパティ</span><span class="sxs-lookup"><span data-stu-id="3b781-124">Property</span></span>  |  <span data-ttu-id="3b781-125">説明</span><span class="sxs-lookup"><span data-stu-id="3b781-125">Description</span></span>  |
|----------|---------------|
| [<span data-ttu-id="3b781-126">Mandatory</span><span class="sxs-lookup"><span data-stu-id="3b781-126">Mandatory</span></span>](https://docs.microsoft.com/uwp/api/windows.services.store.storepackageupdate.Mandatory) | <span data-ttu-id="3b781-127">このプロパティを使用して、デベロッパー センター ダッシュ ボードでパッケージが必須としてマークされているかどうかを決定します。</span><span class="sxs-lookup"><span data-stu-id="3b781-127">Use this property to determine whether the package is marked as mandatory in the Dev Center dashboard.</span></span> |
| [<span data-ttu-id="3b781-128">Package</span><span class="sxs-lookup"><span data-stu-id="3b781-128">Package</span></span>](https://docs.microsoft.com/uwp/api/windows.services.store.storepackageupdate.Package) | <span data-ttu-id="3b781-129">このプロパティを使用して、基になるパッケージ関連データにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="3b781-129">Use this property to access the underlying package-related data.</span></span> |

<span/>

## <a name="code-examples"></a><span data-ttu-id="3b781-130">コード例</span><span class="sxs-lookup"><span data-stu-id="3b781-130">Code examples</span></span>

<span data-ttu-id="3b781-131">次のコード例は、アプリでパッケージの更新をダウンロードし、インストールする方法を示したものです。</span><span class="sxs-lookup"><span data-stu-id="3b781-131">The following code examples demonstrate how to download and install package updates in your app.</span></span> <span data-ttu-id="3b781-132">これらの例は、次のことを前提としています。</span><span class="sxs-lookup"><span data-stu-id="3b781-132">These example assume:</span></span>
* <span data-ttu-id="3b781-133">コードは、[Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) のコンテキスト内で実行されます。</span><span class="sxs-lookup"><span data-stu-id="3b781-133">The code runs in the context of a [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx).</span></span>
* <span data-ttu-id="3b781-134">**Page** には、ダウンロード操作のステータスを提供するための、```downloadProgressBar``` という [ProgressBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressbar.aspx) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3b781-134">The **Page** contains a [ProgressBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressbar.aspx) named ```downloadProgressBar``` to provide status for the download operation.</span></span>
* <span data-ttu-id="3b781-135">コード ファイルには、**Windows.Services.Store**、**Windows.Threading.Tasks**、および**Windows.UI.Popups** 名前空間の **using** ステートメントがあります。</span><span class="sxs-lookup"><span data-stu-id="3b781-135">The code file has a **using** statement for the **Windows.Services.Store**, **Windows.Threading.Tasks**, and **Windows.UI.Popups** namespaces.</span></span>
* <span data-ttu-id="3b781-136">アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。</span><span class="sxs-lookup"><span data-stu-id="3b781-136">The app is a single-user app that runs only in the context of the user that launched the app.</span></span> <span data-ttu-id="3b781-137">[マルチ ユーザー アプリ](https://msdn.microsoft.com/windows/uwp/xbox-apps/multi-user-applications) の場合は、[GetDefault](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.GetDefault) メソッドの代わりに [GetForUser](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.User) メソッドを使用して、**StoreContext** オブジェクトを取得してください。</span><span class="sxs-lookup"><span data-stu-id="3b781-137">For a [multi-user app](https://msdn.microsoft.com/windows/uwp/xbox-apps/multi-user-applications), use the [GetForUser](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.User) method to get a **StoreContext** object instead of the [GetDefault](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.GetDefault) method.</span></span>

<span/>

### <a name="download-and-install-all-package-updates"></a><span data-ttu-id="3b781-138">すべてのパッケージ更新をダウンロードしてインストールする</span><span class="sxs-lookup"><span data-stu-id="3b781-138">Download and install all package updates</span></span>

<span data-ttu-id="3b781-139">次のコード例は、利用可能なすべてのパッケージ更新をダウンロードしてインストールする方法を示したものです。</span><span class="sxs-lookup"><span data-stu-id="3b781-139">The following code example demonstrates how to download and install all available package updates.</span></span>  

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

### <a name="handle-mandatory-package-updates"></a><span data-ttu-id="3b781-140">必須のパッケージ更新を処理する</span><span class="sxs-lookup"><span data-stu-id="3b781-140">Handle mandatory package updates</span></span>

<span data-ttu-id="3b781-141">次のコード例は、前の例とは別に作成されたもので、[Windows デベロッパー センター ダッシュ ボードで必須としてマークされている](#mandatory-dashboard)更新パッケージがあるかどうかを確認する方法を示したものです。</span><span class="sxs-lookup"><span data-stu-id="3b781-141">The following code example builds off the previous example, and demonstrates how to determine whether any update packages have been [marked as mandatory on the Windows Dev Center dashboard](#mandatory-dashboard).</span></span> <span data-ttu-id="3b781-142">通常、必須のパッケージ更新を正常にダウンロードまたはインストールできない場合は、ユーザーに不便のない方法でアプリのエクスペリエンスをダウングレードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3b781-142">Typically, you should downgrade your app experience gracefully for the user if a mandatory package update does not successfully download or install.</span></span>

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

### <a name="display-progress-info-for-the-download-and-install"></a><span data-ttu-id="3b781-143">ダウンロードとインストールの進行状況の情報を表示する</span><span class="sxs-lookup"><span data-stu-id="3b781-143">Display progress info for the download and install</span></span>

<span data-ttu-id="3b781-144">**RequestDownloadStorePackageUpdatesAsync** または **RequestDownloadAndInstallStorePackageUpdatesAsync** を呼び出すときに、この要求で各パッケージのダウンロード (またはダウンロードとインストール) 処理の手順ごとに 1 回呼び出される [Progress](https://docs.microsoft.com/uwp/api/windows.foundation.iasyncoperationwithprogress-2.progress) ハンドラーを割り当てることができます。</span><span class="sxs-lookup"><span data-stu-id="3b781-144">When you call **RequestDownloadStorePackageUpdatesAsync** or **RequestDownloadAndInstallStorePackageUpdatesAsync**, you can assign a [Progress](https://docs.microsoft.com/uwp/api/windows.foundation.iasyncoperationwithprogress-2.progress) handler that is called one time for each step in the download (or download and install) process for each package in this request.</span></span> <span data-ttu-id="3b781-145">このハンドラーは、進行状況の通知を発生させる更新パッケージに関する情報を提供する [StorePackageUpdateStatus](https://docs.microsoft.com/uwp/api/windows.services.store.storepackageupdatestatus) オブジェクトを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="3b781-145">The handler receives a [StorePackageUpdateStatus](https://docs.microsoft.com/uwp/api/windows.services.store.storepackageupdatestatus) object that provides info about the update package that raised the progress notification.</span></span> <span data-ttu-id="3b781-146">前の例では、**StorePackageUpdateStatus** オブジェクトの **PackageDownloadProgress** フィールドを使用して、ダウンロードとインストールの進行状況を表示します。</span><span class="sxs-lookup"><span data-stu-id="3b781-146">The previous examples use the **PackageDownloadProgress** field of the **StorePackageUpdateStatus** object to display the progress of the download and install process.</span></span>

<span data-ttu-id="3b781-147">**RequestDownloadAndInstallStorePackageUpdatesAsync** を呼び出して 1 つの操作でパッケージの更新プログラムをダウンロードしてインストールする場合、**PackageDownloadProgress** フィールドは、パッケージのダウンロード処理中に 0.0 から 0.8 まで増加した後、インストール時に 0.8 から 1.0 まで増加することに注意してください。</span><span class="sxs-lookup"><span data-stu-id="3b781-147">Be aware that when you call **RequestDownloadAndInstallStorePackageUpdatesAsync** to download and install package updates in a single operation, the **PackageDownloadProgress** field increases from 0.0 to 0.8 during the download process for a package, and then it increases from 0.8 to 1.0 during the install.</span></span> <span data-ttu-id="3b781-148">そのため、カスタム進行状況 UI に表示されるパーセンテージを、直接、**PackageDownloadProgress** フィールドの値にマップする場合、パッケージのダウンロードが完了し、OS でインストール ダイアログが表示されたときに、UI には 80% と表示されます。</span><span class="sxs-lookup"><span data-stu-id="3b781-148">Therefore, if you map the percentage shown in your custom progress UI directly to the value of the **PackageDownloadProgress** field, your UI will show 80% when the package is finished downloading and the OS displays the installation dialog.</span></span> <span data-ttu-id="3b781-149">パッケージがダウンロードされ、インストールの準備ができたときに、カスタム進行状況 UI で 100% と表示するには、**PackageDownloadProgress** が 0.8 に達したときに進行状況 UI に 100% を割り当てるようにコードを変更します。</span><span class="sxs-lookup"><span data-stu-id="3b781-149">If you want your custom progress UI to display 100% when the package is downloaded and ready to be installed, you can modify your code to assign 100% to your progress UI when the **PackageDownloadProgress** field reaches 0.8.</span></span>

<span id="mandatory-dashboard" />

## <a name="make-a-package-submission-mandatory-in-the-dev-center-dashboard"></a><span data-ttu-id="3b781-150">デベロッパー センター ダッシュボードでパッケージ申請を必須にする</span><span class="sxs-lookup"><span data-stu-id="3b781-150">Make a package submission mandatory in the Dev Center dashboard</span></span>

<span data-ttu-id="3b781-151">Windows 10 バージョン 1607 以降を対象としたアプリのパッケージ申請を作成する際には、パッケージを必須としてマークし、それが必須になる日時を指定することができます。</span><span class="sxs-lookup"><span data-stu-id="3b781-151">When you create a package submission for an app that targets Windows 10, version 1607 or later, you can mark the package as mandatory and the date/time on which it becomes mandatory.</span></span> <span data-ttu-id="3b781-152">このプロパティが設定されている場合、利用可能なパッケージの更新がこの記事の前半で説明した API を通じて検出されると、アプリは更新パッケージが必須であることを認識し、更新がインストールされるまで、その動作を変更することができます (機能を無効にするなど)。</span><span class="sxs-lookup"><span data-stu-id="3b781-152">When this property is set and your app discovers that the package update is available by using the API described earlier in this article, your app can determine whether the update package is mandatory and alter its behavior until the update is installed (for example, your app can disable features).</span></span>

> [!NOTE]
> <span data-ttu-id="3b781-153">パッケージ更新の必須ステータスは Microsoft によって強制されるものではありません。アプリの必須更新プログラムをインストールする必要があることをユーザーに示すための UI は、OS では提供されていません。</span><span class="sxs-lookup"><span data-stu-id="3b781-153">The mandatory status of a package update is not enforced by Microsoft, and the OS does not provide a UI to indicate to users that a mandatory app update must be installed.</span></span> <span data-ttu-id="3b781-154">必須設定は、開発者が自身のコード内でアプリの必須更新プログラムを強制するために使用するものです。</span><span class="sxs-lookup"><span data-stu-id="3b781-154">Developers are intended to use the mandatory setting to enforce mandatory app updates in their own code.</span></span>  

<span data-ttu-id="3b781-155">パッケージ申請を必須としてマークするには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="3b781-155">To mark a package submission as mandatory:</span></span>

1. <span data-ttu-id="3b781-156">[デベロッパー センター ダッシュ ボード](https://dev.windows.com/overview)にサインインし、アプリの概要ページに移動します。</span><span class="sxs-lookup"><span data-stu-id="3b781-156">Sign in to the [Dev Center dashboard](https://dev.windows.com/overview) and navigate to the overview page for your app.</span></span>
2. <span data-ttu-id="3b781-157">必須にするパッケージ更新が含まれている申請の名前をクリックします。</span><span class="sxs-lookup"><span data-stu-id="3b781-157">Click the name of the submission that contains the package update you want to make mandatory.</span></span>
3. <span data-ttu-id="3b781-158">申請の **[パッケージ]** ページに移動します。</span><span class="sxs-lookup"><span data-stu-id="3b781-158">Navigate to the **Packages** page for the submission.</span></span> <span data-ttu-id="3b781-159">このページの下部で、**[この更新を必須にします]** を選択した後、パッケージ更新が必須になる日時を選択します。</span><span class="sxs-lookup"><span data-stu-id="3b781-159">Near the bottom of this page, select **Make this update mandatory** and then choose the day and time on which the package update becomes mandatory.</span></span> <span data-ttu-id="3b781-160">このオプションは、申請内のすべての UWP パッケージに適用されます。</span><span class="sxs-lookup"><span data-stu-id="3b781-160">This option applies to all UWP packages in the submission.</span></span>

<span data-ttu-id="3b781-161">デベロッパー センター ダッシュボードでのパッケージの構成について詳しくは、「[アプリ パッケージのアップロード](../publish/upload-app-packages.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3b781-161">For more information about configuring packages in the Dev Center dashboard, see [Upload app packages](../publish/upload-app-packages.md).</span></span>

  > [!NOTE]
  > <span data-ttu-id="3b781-162">[パッケージ フライト](../publish/package-flights.md)を作成する場合は、フライトの**パッケージ** ページで同様の UI を使用して、パッケージを必須としてマークできます。</span><span class="sxs-lookup"><span data-stu-id="3b781-162">If you create a [package flight](../publish/package-flights.md), you can mark the packages as mandatory using a similar UI on the **Packages** page for the flight.</span></span> <span data-ttu-id="3b781-163">その場合、必須のパッケージ更新は、フライト グループのメンバーであるユーザーにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="3b781-163">In this case, the mandatory package update applies only to the customers who are part of the flight group.</span></span>
