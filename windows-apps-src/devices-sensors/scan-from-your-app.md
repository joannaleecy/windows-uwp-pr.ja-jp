---
author: PatrickFarley
ms.assetid: 374D1983-60E0-4E18-ABBB-04775BAA0F0D
title: アプリからスキャンする
description: フラットベッド、フィーダー、自動構成の各スキャン ソースを使ってアプリからコンテンツをスキャンする方法について説明します。
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: f9128056cbb3b9218d164b243948d9dd16af0786
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5815249"
---
# <a name="scan-from-your-app"></a>アプリからスキャンする


**重要な API**

-   [**Windows.Devices.Scanners**](https://msdn.microsoft.com/library/windows/apps/Dn264250)
-   [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/BR225393)
-   [**DeviceClass**](https://msdn.microsoft.com/library/windows/apps/BR225381)

フラットベッド、フィーダー、自動構成の各スキャン ソースを使ってアプリからコンテンツをスキャンする方法について説明します。

**重要な** [**Windows.Devices.Scanners**](https://msdn.microsoft.com/library/windows/apps/Dn264250) Api は、デスクトップ[デバイス ファミリ](https://msdn.microsoft.com/library/windows/apps/Dn894631)の一部です。 アプリでは、windows 10 のデスクトップ バージョンでのみこれらの Api を使用できます。

アプリからスキャンを実行するにはまず、新しい [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/BR225393) オブジェクトを宣言し、[**DeviceClass**](https://msdn.microsoft.com/library/windows/apps/BR225381) 型を取得することによって、利用できるスキャナーをリストする必要があります。 WIA ドライバーと共にインストールされているローカルのスキャナーのみがリストされ、アプリから利用することができます。

利用できるスキャナーをリストしたら、スキャナーの種類に基づく自動構成のスキャン設定を使うか、フラットベッドとフィーダーのいずれかのスキャン ソースを使ってスキャンのみを実行することができます。 自動構成設定を使うには、スキャナーが自動構成に対応し、なおかつ、フラットベッドとフィーダーのどちらか一方のみを備えたスキャナーであることが必要です。 詳細については、[自動構成スキャン](https://msdn.microsoft.com/library/windows/hardware/Ff539393)に関するページを参照してください。

## <a name="enumerate-available-scanners"></a>利用できるスキャナーを列挙する

Windows はスキャナーを自動的には検出しません。 アプリがスキャナーと通信するためには、次の手順を実行する必要があります。 この例では、[**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) 名前空間を使ってスキャナー デバイスの列挙処理を実行しています。

1.  まず、クラス定義ファイルに次の using ステートメントを追加します。

``` csharp
    using Windows.Devices.Enumeration;
    using Windows.Devices.Scanners;
```

2.  次に、スキャナーの列挙処理を開始するためのデバイス ウォッチャーを実装します。 詳しくは、「[デバイスの列挙](enumerate-devices.md)」をご覧ください。

```csharp
    void InitDeviceWatcher()
    {
       // Create a Device Watcher class for type Image Scanner for enumerating scanners
       scannerWatcher = DeviceInformation.CreateWatcher(DeviceClass.ImageScanner);

       scannerWatcher.Added += OnScannerAdded;
       scannerWatcher.Removed += OnScannerRemoved;
       scannerWatcher.EnumerationCompleted += OnScannerEnumerationComplete;
    }
```

3.  スキャナーが追加されたタイミングで実行されるイベント ハンドラーを作成します。

```csharp
    private async void OnScannerAdded(DeviceWatcher sender,  DeviceInformation deviceInfo)
    {
       await
       MainPage.Current.Dispatcher.RunAsync(
             Windows.UI.Core.CoreDispatcherPriority.Normal,
             () =>
             {
                MainPage.Current.NotifyUser(String.Format("Scanner with device id {0} has been added", deviceInfo.Id), NotifyType.StatusMessage);

                // search the device list for a device with a matching device id
                ScannerDataItem match = FindInList(deviceInfo.Id);

                // If we found a match then mark it as verified and return
                if (match != null)
                {
                   match.Matched = true;
                   return;
                }

                // Add the new element to the end of the list of devices
                AppendToList(deviceInfo);
             }
       );
    }
```

## <a name="scan"></a>スキャン

1.  **ImageScanner オブジェクトを取得する**

[**ImageScannerScanSource**](https://msdn.microsoft.com/library/windows/apps/Dn264238) 列挙型の各メンバーに対しては、**Default**、**AutoConfigured**、**Flatbed**、**Feeder** のいずれであれ、最初に [**ImageScanner.FromIdAsync**](https://msdn.microsoft.com/library/windows/apps/windows.devices.scanners.imagescanner.fromidasync) メソッドを呼び出して [**ImageScanner**](https://msdn.microsoft.com/library/windows/apps/Dn263806) オブジェクトを作成する必要があります。その例を次に示します。

 ```csharp
    ImageScanner myScanner = await ImageScanner.FromIdAsync(deviceId);
 ```

2.  **スキャンのみ**

既定の設定でスキャンを行う場合、アプリは、[**Windows.Devices.Scanners**](https://msdn.microsoft.com/library/windows/apps/Dn264250) 名前空間を使ってスキャナーを選び、そのソースからスキャンを実行します。 スキャンの設定は変更されません。 この場合、自動構成、フラットベッド、フィーダーのいずれかのスキャナーが選ばれます。 このタイプのスキャンは、意図しないソースからスキャンが実行されたとしても (意図したフィーダーではなくフラットベッドからスキャンされるなど) スキャン操作が正常に実行される可能性は最も高くなります。

**注:** フィーダーでスキャンするドキュメントを配置して、ユーザー場合と、スキャナーが代わりに、フラット ベッドからスキャンされます。 空のフィーダーからスキャンを実行した場合、スキャン ジョブからは一切、スキャンしたファイルが生成されません。
 
```csharp
    var result = await myScanner.ScanFilesToFolderAsync(ImageScannerScanSource.Default,
        folder).AsTask(cancellationToken.Token, progress);
```

3.  **自動構成、フラットベッド、フィーダーのいずれかのソースからスキャンする**

デバイスの[自動構成スキャン](https://msdn.microsoft.com/library/windows/hardware/Ff539393)を使うと、最適なスキャン設定でスキャンを実行することができます。 このオプションでは、スキャン対象のコンテンツに応じた最適なスキャン設定 (カラー モード、スキャン解像度など) をデバイスが自動的に判断します。 スキャン設定は、新しいスキャン ジョブの実行時にその都度選択されます。

**注:**、アプリでこの設定を使用する前に、スキャナーがこの機能をサポートしているかを確認する必要がありますので、すべてのスキャナーがこの機能をサポートします。

この例では、スキャナーが自動構成に対応しているかどうかをアプリがまずチェックしたうえで、スキャンを実行しています。 フラットベッド スキャナーまたはフィーダー スキャナーを指定する場合は、単に **AutoConfigured** を **Flatbed** または **Feeder** に置き換えます。

```csharp
    if (myScanner.IsScanSourceSupported(ImageScannerScanSource.AutoConfigured))
    {
        ...
        // Scan API call to start scanning with Auto-Configured settings.
        var result = await myScanner.ScanFilesToFolderAsync(
            ImageScannerScanSource.AutoConfigured, folder).AsTask(cancellationToken.Token, progress);
        ...
    }
```

## <a name="preview-the-scan"></a>スキャンをプレビューする

フォルダーに格納する前にスキャン結果をプレビューするコードを追加できます。 以下の例では、**Flatbed** スキャナーがプレビューをサポートしているかどうかをアプリでチェックした後、スキャン結果をプレビューしています。

```csharp
if (myScanner.IsPreviewSupported(ImageScannerScanSource.Flatbed))
{
    rootPage.NotifyUser("Scanning", NotifyType.StatusMessage);
                // Scan API call to get preview from the flatbed.
                var result = await myScanner.ScanPreviewToStreamAsync(
                    ImageScannerScanSource.Flatbed, stream);
```

## <a name="cancel-the-scan"></a>スキャンを取り消す

スキャンの途中でユーザーがスキャン ジョブを取り消すことができるようにする例を次に示します。

```csharp
void CancelScanning()
{
    if (ModelDataContext.ScenarioRunning)
    {
        if (cancellationToken != null)
        {
            cancellationToken.Cancel();
        }                
        DisplayImage.Source = null;
        ModelDataContext.ScenarioRunning = false;
        ModelDataContext.ClearFileList();
    }
}
```

## <a name="scan-with-progress"></a>スキャンの進行状況を表示する

1.  **System.Threading.CancellationTokenSource** オブジェクトを作成します。

```csharp
cancellationToken = new CancellationTokenSource();
```

2.  進行状況のイベント ハンドラーを設定してスキャンの進行状況を取得します。

```csharp
    rootPage.NotifyUser("Scanning", NotifyType.StatusMessage);
    var progress = new Progress<UInt32>(ScanProgress);
```

## <a name="scanning-to-the-pictures-library"></a>画像ライブラリにスキャンする

[**FolderPicker**](https://msdn.microsoft.com/library/windows/apps/BR207881) クラスを使うことで、ユーザーは任意のフォルダーにスキャン結果を動的に格納することができます。ただし、画像ライブラリ フォルダーにスキャン結果を格納できるようにするには、*画像ライブラリ*の機能をマニフェストで宣言する必要があります。 アプリの機能の詳細については、「[アプリ機能の宣言](https://msdn.microsoft.com/library/windows/apps/Mt270968)」を参照してください。
