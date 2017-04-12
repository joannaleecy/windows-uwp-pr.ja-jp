---
author: mcleanbyron
ms.assetid: 414ACC73-2A72-465C-BD15-1B51CB2334F2
title: "アプリのパッケージの更新をダウンロードしてインストールする"
description: "デベロッパー センター ダッシュ ボードでパッケージを必須としてマークする方法と、パッケージ更新をダウンロードしてインストールするためのコードをアプリ内に記述する方法について説明します。"
ms.author: mcleans
ms.date: 03/15/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 07b8b769cbcaf86bfa70a562de568cab65c91a77
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="download-and-install-package-updates-for-your-app"></a>アプリのパッケージの更新をダウンロードしてインストールする

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

Windows 10 バージョン 1607 以降では、[Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間の API を使用して、現在のアプリに対するパッケージ更新をプログラムからチェックし、更新後のパッケージをダウンロードしてインストールすることができます。 また、[Windows デベロッパー センター ダッシュボードで必須としてマークされている](#mandatory-dashboard)パッケージを照会し、必須の更新がインストールされるまで機能を無効にすることもできます。

これらの機能は、ユーザー ベースが使用しているアプリや関連サービスを、自動的に最新バージョンに維持するために役立ちます。

## <a name="api-overview"></a>API の概要

Windows 10 バージョン 1607 以降を対象としたアプリでは、[StoreContext](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) クラスの次のメソッドを使用して、パッケージの更新をダウンロードし、インストールすることができます。

|  メソッド  |  [説明]  |
|----------|---------------|
| [GetAppAndOptionalStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext#Windows_Services_Store_StoreContext_GetAppAndOptionalStorePackageUpdatesAsync) | 利用できるパッケージの更新の一覧を取得するには、このメソッドを呼び出します。 パッケージが認定プロセスを通過した後、そのパッケージ更新がアプリで利用可能になったことを **GetAppAndOptionalStorePackageUpdatesAsync** メソッドが認識するまでには、最大で 1 日間の遅延が生じる可能性があることに注意してください。 |
| [RequestDownloadStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext#Windows_Services_Store_StoreContext_RequestDownloadStorePackageUpdatesAsync_Windows_Foundation_Collections_IIterable_Windows_Services_Store_StorePackageUpdate__) | このメソッドを呼び出して、利用可能なパッケージの更新をダウンロードします (インストールはされません)。 この OS では、更新プログラムのダウンロードに対してユーザーのアクセス許可を求めるダイアログが表示されます。 |
| [RequestDownloadAndInstallStorePackageUpdatesAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext#Windows_Services_Store_StoreContext_RequestDownloadAndInstallStorePackageUpdatesAsync_Windows_Foundation_Collections_IIterable_Windows_Services_Store_StorePackageUpdate__) | 利用可能なパッケージの更新をダウンロードしてインストールするには、このメソッドを呼び出します。 OS では、更新プログラムのダウンロードとインストールに対してユーザーのアクセス許可を求めるダイアログが表示されます。 **RequestDownloadStorePackageUpdatesAsync** を呼び出すことでパッケージの更新が既にダウンロードされている場合、このメソッドはダウンロード プロセスをスキップし、更新のインストールのみを行います。  |

<span/>

これらのメソッドは [StorePackageUpdate](https://docs.microsoft.com/uwp/api/windows.services.store.storepackageupdate) オブジェクトを使用して、使用可能な更新プログラム パッケージを表します。 次の **StorePackageUpdate** プロパティを使用して、更新プログラム パッケージに関する情報を取得します。

|  プロパティ  |  説明  |
|----------|---------------|
| [Mandatory](https://docs.microsoft.com/uwp/api/windows.services.store.storepackageupdate#Windows_Services_Store_StorePackageUpdate_Mandatory) | このプロパティを使用して、デベロッパー センター ダッシュ ボードでパッケージが必須としてマークされているかどうかを決定します。 |
| [Package](https://docs.microsoft.com/uwp/api/windows.services.store.storepackageupdate#Windows_Services_Store_StorePackageUpdate_Package) | このプロパティを使用して、基になるパッケージ関連データにアクセスします。 |

<span/>

## <a name="code-examples"></a>コード例

次のコード例は、アプリでパッケージの更新をダウンロードし、インストールする方法を示したものです。 これらの例は、次のことを前提としています。
* コードは、[Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) のコンテキスト内で実行されます。
* **Page** には、ダウンロード操作のステータスを提供するための、```downloadProgressBar``` という [ProgressBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressbar.aspx) が含まれます。
* コード ファイルには、**Windows.Services.Store**、**Windows.Threading.Tasks**、および**Windows.UI.Popups** 名前空間の **using** ステートメントがあります。
* アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。 [マルチ ユーザー アプリ](https://msdn.microsoft.com/windows/uwp/xbox-apps/multi-user-applications) の場合は、[GetDefault](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext#Windows_Services_Store_StoreContext_GetDefault) メソッドの代わりに [GetForUser](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext#Windows_Services_Store_StoreContext_GetForUser_Windows_System_User_) メソッドを使用して、**StoreContext** オブジェクトを取得してください。

<span/>

### <a name="download-and-install-all-package-updates"></a>すべてのパッケージ更新をダウンロードしてインストールする

次のコード例は、利用可能なすべてのパッケージ更新をダウンロードしてインストールする方法を示したものです。  

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

### <a name="handle-mandatory-package-updates"></a>必須のパッケージ更新を処理する

次のコード例は、前の例とは別に作成されたもので、[Windows デベロッパー センター ダッシュ ボードで必須としてマークされている](#mandatory-dashboard)更新パッケージがあるかどうかを確認する方法を示したものです。 通常、必須のパッケージ更新を正常にダウンロードまたはインストールできない場合は、ユーザーに不便のない方法でアプリのエクスペリエンスをダウングレードする必要があります。

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

### <a name="display-progress-info-for-the-download-and-install"></a>ダウンロードとインストールの進行状況の情報を表示する

**RequestDownloadStorePackageUpdatesAsync** または **RequestDownloadAndInstallStorePackageUpdatesAsync** を呼び出すときに、この要求で各パッケージのダウンロード (またはダウンロードとインストール) 処理の手順ごとに 1 回呼び出される [Progress](https://docs.microsoft.com/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_#Windows_Foundation_IAsyncOperationWithProgress_2_Progress) ハンドラーを割り当てることができます。 このハンドラーは、進行状況の通知を発生させる更新パッケージに関する情報を提供する [StorePackageUpdateStatus](https://docs.microsoft.com/uwp/api/windows.services.store.storepackageupdatestatus) オブジェクトを受け取ります。 前の例では、**StorePackageUpdateStatus** オブジェクトの **PackageDownloadProgress** フィールドを使用して、ダウンロードとインストールの進行状況を表示します。

**RequestDownloadAndInstallStorePackageUpdatesAsync** を呼び出して 1 つの操作でパッケージの更新プログラムをダウンロードしてインストールする場合、**PackageDownloadProgress** フィールドは、パッケージのダウンロード処理中に 0.0 から 0.8 まで増加した後、インストール時に 0.8 から 1.0 まで増加することに注意してください。 そのため、カスタム進行状況 UI に表示されるパーセンテージを、直接、**PackageDownloadProgress** フィールドの値にマップする場合、パッケージのダウンロードが完了し、OS でインストール ダイアログが表示されたときに、UI には 80% と表示されます。 パッケージがダウンロードされ、インストールの準備ができたときに、カスタム進行状況 UI で 100% と表示するには、**PackageDownloadProgress** が 0.8 に達したときに進行状況 UI に 100% を割り当てるようにコードを変更します。

<span id="mandatory-dashboard" />
## <a name="make-a-package-submission-mandatory-in-the-dev-center-dashboard"></a>デベロッパー センター ダッシュボードでパッケージ申請を必須にする

Windows 10 バージョン 1607 以降を対象としたアプリのパッケージ申請を作成する際には、パッケージを必須としてマークし、それが必須になる日時を指定することができます。 このプロパティが設定されている場合、利用可能なパッケージの更新がこの記事の前半で説明した API を通じて検出されると、アプリは更新パッケージが必須であることを認識し、更新がインストールされるまで、その動作を変更することができます (機能を無効にするなど)。

> [!NOTE]
> パッケージ更新の必須ステータスは Microsoft によって強制されるものではありません。アプリの必須更新プログラムをインストールする必要があることをユーザーに示すための UI は、OS では提供されていません。 必須設定は、開発者が自身のコード内でアプリの必須更新プログラムを強制するために使用するものです。  

パッケージ申請を必須としてマークするには、次の手順に従います。

1. [デベロッパー センター ダッシュ ボード](https://dev.windows.com/overview)にサインインし、アプリの概要ページに移動します。
2. 必須にするパッケージ更新が含まれている申請の名前をクリックします。
3. 申請の **[パッケージ]** ページに移動します。 このページの下部で、**[この更新を必須にします]** を選択した後、パッケージ更新が必須になる日時を選択します。 このオプションは、申請内のすべての UWP パッケージに適用されます。

デベロッパー センター ダッシュボードでのパッケージの構成について詳しくは、「[アプリ パッケージのアップロード](../publish/upload-app-packages.md)」をご覧ください。

  > [!NOTE]
  > [パッケージ フライト](../publish/package-flights.md)を作成する場合は、フライトの**パッケージ** ページで同様の UI を使用して、パッケージを必須としてマークできます。 その場合、必須のパッケージ更新は、フライト グループのメンバーであるユーザーにのみ適用されます。
