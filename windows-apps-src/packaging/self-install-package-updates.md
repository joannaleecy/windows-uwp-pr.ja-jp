---
ms.assetid: 414ACC73-2A72-465C-BD15-1B51CB2334F2
title: パッケージの更新プログラムを Microsoft Store からダウンロードしてインストールする
description: パートナー センターでのパッケージを必須としてマークし、アプリをダウンロードしてインストール パッケージの更新でコードを記述する方法について説明します。
ms.date: 04/04/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: e73452cdcb02798d4ebd225b48272ab77c40fef9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57604447"
---
# <a name="download-and-install-package-updates-from-the-store"></a>パッケージの更新プログラムを Microsoft Store からダウンロードしてインストールする

Windows 10 バージョン 1607 以降では、[Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間で [StoreContext](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) クラスのメソッドを使用して、現在のアプリに対するパッケージ更新がないかプログラムによって Microsoft Store でチェックし、更新後のパッケージをダウンロードしてインストールすることができます。 パートナー センターで必須としてマークし、必須の更新プログラムがインストールされるまで、アプリで機能を無効にするパッケージを照会できます。

Windows 10 バージョン 1803 で導入された追加の [StoreContext](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) メソッドを使うと、パッケージの更新プログラムを背後で (ユーザーに通知 UI を表示せずに) ダウンロードおよびインストールしたり、[オプション パッケージ](optional-packages.md)をアンインストールしたり、アプリのダウンロードおよびインストール キューにあるパッケージの情報を取得したりすることができます。

これらの機能は、ユーザー ベースが使っているアプリ、オプション パッケージ、関連サービスを、Microsoft Store にある最新バージョンに自動的に維持するために役立ちます。

## <a name="download-and-install-package-updates-with-the-users-permission"></a>ユーザーの許可によるパッケージの更新プログラムのダウンロードとインストール

このコード例は、[GetAppAndOptionalStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getappandoptionalstorepackageupdatesasync) メソッドを使って Microsoft Store から利用可能なパッケージの更新プログラムをすべて見つけ、[RequestDownloadAndInstallStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestdownloadandinstallstorepackageupdatesasync) メソッドを呼び出して更新プログラムをダウンロードおよびインストールする方法を示しています。 このメソッドを使って更新プログラムをダウンロードおよびインストールすると、更新プログラムをダウンロードする前にユーザーの許可を求めるダイアログが OS に表示されます。

> [!NOTE]
> これらのメソッドでは、アプリの必須のパッケージと[オプション パッケージ](optional-packages.md)がサポートされます。 オプション パッケージは、ダウンロード可能なコンテンツ (DLC) アドオン用や、サイズ制約に対応して大規模アプリを分割する場合、コア アプリから分離して追加コンテンツを出荷する場合に便利です。 オプション パッケージ (DLC アドオンを含む) を使うアプリを Microsoft Store に提出する許可を得るには、「[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)」をご覧ください。

このコード例では、次のことを前提条件としています。

* コードは、[Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) のコンテキスト内で実行されます。
* **Page** には、ダウンロード操作のステータスを提供するための、```downloadProgressBar``` という [ProgressBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressbar.aspx) が含まれます。
* コード ファイルには、**Windows.Services.Store**、**Windows.Threading.Tasks**、および**Windows.UI.Popups** 名前空間の **using** ステートメントがあります。
* アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。 [マルチ ユーザー アプリ](https://msdn.microsoft.com/windows/uwp/xbox-apps/multi-user-applications) の場合は、[GetDefault](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.GetDefault) メソッドの代わりに [GetForUser](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.User) メソッドを使用して、**StoreContext** オブジェクトを取得してください。

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
> 利用可能なパッケージの更新プログラムをダウンロードするだけ (インストールしない) の場合は、[RequestDownloadStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestdownloadstorepackageupdatesasync) メソッドを使います。

### <a name="display-download-and-install-progress-info"></a>ダウンロードとインストールの進行状況の情報を表示する

[RequestDownloadStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestdownloadstorepackageupdatesasync) メソッドまたは [RequestDownloadAndInstallStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestdownloadandinstallstorepackageupdatesasync) メソッドを呼び出すときに、この要求で各パッケージのダウンロード (またはダウンロードとインストール) 処理の手順ごとに 1 回呼び出される [Progress](https://docs.microsoft.com/uwp/api/windows.foundation.iasyncoperationwithprogress-2.progress) ハンドラーを割り当てることができます。 このハンドラーは、進行状況の通知を発生させる更新パッケージに関する情報を提供する [StorePackageUpdateStatus](https://docs.microsoft.com/uwp/api/windows.services.store.storepackageupdatestatus) オブジェクトを受け取ります。 前の例では、**StorePackageUpdateStatus** オブジェクトの **PackageDownloadProgress** フィールドを使用して、ダウンロードとインストールの進行状況を表示します。

**RequestDownloadAndInstallStorePackageUpdatesAsync** を呼び出して 1 つの操作でパッケージの更新プログラムをダウンロードしてインストールする場合、**PackageDownloadProgress** フィールドは、パッケージのダウンロード処理中に 0.0 から 0.8 まで増加した後、インストール時に 0.8 から 1.0 まで増加することに注意してください。 そのため、カスタム進行状況 UI に表示されるパーセンテージを、直接、**PackageDownloadProgress** フィールドの値にマップする場合、パッケージのダウンロードが完了し、OS でインストール ダイアログが表示されたときに、UI には 80% と表示されます。 パッケージがダウンロードされ、インストールの準備ができたときに、カスタム進行状況 UI で 100% と表示するには、**PackageDownloadProgress** が 0.8 に達したときに進行状況 UI に 100% を割り当てるようにコードを変更します。

## <a name="download-and-install-package-updates-silently"></a>パッケージの更新プログラムを背後でダウンロードしてインストールする

Windows 10 バージョン 1803 以降では、[TrySilentDownloadStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.trysilentdownloadstorepackageupdatesasync) メソッドと [TrySilentDownloadAndInstallStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.trysilentdownloadandinstallstorepackageupdatesasync) メソッドを使って、ユーザーに通知 UI を表示せずに背後でパッケージの更新プログラムをダウンロードおよびインストールできます。 この操作は、ユーザーが Microsoft Store で **[アプリを自動的に更新]** 設定をオンにしており、ユーザーが従量制課金接続を使っていない場合のみ成功します。 これらのメソッドを呼び出す前に、まず [CanSilentlyDownloadStorePackageUpdates](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.cansilentlydownloadstorepackageupdates) プロパティを確認し、これらの条件を現在満たしているかどうかを判断します。

このコード例は、[GetAppAndOptionalStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getappandoptionalstorepackageupdatesasync) メソッドを使って利用可能なパッケージの更新プログラムをすべて見つけた後、[TrySilentDownloadStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.trysilentdownloadstorepackageupdatesasync) メソッドと [TrySilentDownloadAndInstallStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.trysilentdownloadandinstallstorepackageupdatesasync) メソッドを呼び出して背後で更新プログラムをダウンロードおよびインストールする方法を示しています。

このコード例では、次のことを前提条件としています。
* コード ファイルに **Windows.Services.Store** 名前空間と **System.Threading.Tasks** 名前空間を使うための **using** ステートメントがある。
* アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。 [マルチ ユーザー アプリ](https://msdn.microsoft.com/windows/uwp/xbox-apps/multi-user-applications) の場合は、[GetDefault](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.GetDefault) メソッドの代わりに [GetForUser](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.User) メソッドを使用して、**StoreContext** オブジェクトを取得してください。

> [!NOTE]
> この例のコードにより呼び出されている **IsNowAGoodTimeToRestartApp**、**RetryDownloadAndInstallLater**、**RetryInstallLater** の各メソッドは、アプリの設計の必要に応じて実装することを目的としたプレースホルダー メソッドです。

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

## <a name="mandatory-package-updates"></a>必須のパッケージの更新プログラム

パートナー センターで Windows 10 バージョン 1607 以降を対象とするアプリのパッケージの送信を作成するときに[パッケージを必須としてマーク](../publish/upload-app-packages.md#mandatory-update)日付と時刻を必須になります。 このプロパティが設定されている場合、利用可能なパッケージの更新が検出されると、アプリは更新パッケージが必須であることを認識し、更新がインストールされるまで、その動作を変更することができます (機能を無効にするなど)。

> [!NOTE]
> パッケージ更新の必須ステータスは Microsoft によって強制されるものではありません。アプリの必須更新プログラムをインストールする必要があることをユーザーに示すための UI は、OS では提供されていません。 必須設定は、開発者が自身のコード内でアプリの必須更新プログラムを強制するために使用するものです。  

パッケージ申請を必須としてマークするには、次の手順に従います。

1. サインインする[パートナー センター](https://partner.microsoft.com/dashboard)し、アプリの概要ページに移動します。
2. 必須にするパッケージ更新が含まれている申請の名前をクリックします。
3. 申請の **[パッケージ]** ページに移動します。 このページの下部で、**[この更新を必須にします]** を選択した後、パッケージ更新が必須になる日時を選択します。 このオプションは、申請内のすべての UWP パッケージに適用されます。

詳細については、「[アプリ パッケージのアップロード](../publish/upload-app-packages.md)」を参照してください。

> [!NOTE]
> [パッケージ フライト](../publish/package-flights.md)を作成する場合は、フライトの**パッケージ** ページで同様の UI を使用して、パッケージを必須としてマークできます。 その場合、必須のパッケージ更新は、フライト グループのメンバーであるユーザーにのみ適用されます。

### <a name="code-example-for-mandatory-packages"></a>必須パッケージのコード例

次のコード例は、更新パッケージが必須であるかどうかを調べる方法を示したものです。 通常、必須のパッケージ更新を正常にダウンロードまたはインストールできない場合は、ユーザーに不便のない方法でアプリのエクスペリエンスをダウングレードする必要があります。

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

## <a name="uninstall-optional-packages"></a>オプション パッケージのアンインストール

Windows 10 バージョン 1803 以降では、[RequestUninstallStorePackageAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestuninstallstorepackageasync) メソッドまたは [RequestUninstallStorePackageByStoreIdAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestuninstallstorepackagebystoreidasync) メソッドを使って、現在のアプリの[オプション パッケージ](optional-packages.md) (DLC パッケージを含む) をアンインストールできます。 たとえば、オプション パッケージを通じてインストールされるコンテンツを持つアプリがある場合、ユーザーがオプション パッケージをアンインストールしてディスク領域を解放できる UI を用意できます。

次のコード例は、[RequestUninstallStorePackageAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.requestuninstallstorepackageasync) を呼び出す方法を示しています。 この例では、次のことを前提条件としています。
* コード ファイルに **Windows.Services.Store** 名前空間と **System.Threading.Tasks** 名前空間を使うための **using** ステートメントがある。
* アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。 [マルチ ユーザー アプリ](https://msdn.microsoft.com/windows/uwp/xbox-apps/multi-user-applications) の場合は、[GetDefault](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.GetDefault) メソッドの代わりに [GetForUser](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.User) メソッドを使用して、**StoreContext** オブジェクトを取得してください。

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

## <a name="get-download-queue-info"></a>ダウンロード キューの情報の取得

Windows 10 バージョン 1803 以降では、[GetAssociatedStoreQueueItemsAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getassociatedstorequeueitemsasync) メソッドと [GetStoreQueueItemsAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getstorequeueitemsasync) メソッドを使い、現在のダウンロードおよびインストール キューにあるパッケージの情報を Microsoft Store から取得することができます。 これらのメソッドは、ダウンロードとインストールに数時間から数日かかる可能性がある大規模なオプション パッケージ (DLC を含む) がアプリやゲームでサポートされており、ダウンロードおよびインストール プロセスが完了する前にユーザーがアプリやゲームを閉じるケースを適切に処理する必要がある場合に役立ちます。 ユーザーがアプリやゲームを再度起動すると、コードはこれらのメソッドを使ってダウンロードおよびインストール キューにまだ残っているパッケージの状態に関する情報を取得できるため、各パッケージのステータスをユーザーに表示できます。

次のコード例は、[GetAssociatedStoreQueueItemsAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getassociatedstorequeueitemsasync) を呼び出し、現在のアプリの進行中のパッケージ更新プログラムの一覧を取得して、各パッケージのステータス情報を表示する方法を示しています。 この例では、次のことを前提条件としています。
* コード ファイルに **Windows.Services.Store** 名前空間と **System.Threading.Tasks** 名前空間を使うための **using** ステートメントがある。
* アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。 [マルチ ユーザー アプリ](https://msdn.microsoft.com/windows/uwp/xbox-apps/multi-user-applications) の場合は、[GetDefault](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.GetDefault) メソッドの代わりに [GetForUser](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.User) メソッドを使用して、**StoreContext** オブジェクトを取得してください。

> [!NOTE]
> この例のコードにより呼び出されている **MarkUpdateInProgressInUI**、**RemoveItemFromUI**、**MarkInstallCompleteInUI**、**MarkInstallErrorInUI**、**MarkInstallPausedInUI** の各メソッドは、アプリの設計の必要に応じて実装することを目的としてプレースホルダー メソッドです。

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

## <a name="related-topics"></a>関連トピック

* [オプション パッケージと関連セットの作成](optional-packages.md)
