---
title: ユーザーの位置情報の取得
description: ユーザーの位置情報を検索し、位置の変更に対応します。 ユーザーの位置情報へのアクセスは、設定アプリのプライバシー設定で管理されています。 このトピックでは、アプリにユーザーの位置情報へのアクセス許可が与えられているかどうかを確認する方法についても説明します。
ms.assetid: 24DC9A41-8CC1-48B0-BC6D-24BF571AFCC8
ms.date: 11/28/2017
ms.topic: article
keywords: Windows 10, UWP, 地図, 位置情報, 位置情報機能
ms.localizationpriority: medium
ms.openlocfilehash: fae533e0ce42e14e3c53f5083b746a9aae221adf
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8941359"
---
# <a name="get-the-users-location"></a>ユーザーの位置情報の取得




ユーザーの位置情報を検索し、位置の変更に対応します。 ユーザーの位置情報へのアクセスは、設定アプリのプライバシー設定で管理されています。 このトピックでは、アプリにユーザーの位置情報へのアクセス許可が与えられているかどうかを確認する方法についても説明します。

**ヒント:** アプリでユーザーの位置情報にアクセスする方法について詳しくは、GitHub の [Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619979)から次のサンプルをダウンロードしてください。

-   [ユニバーサル Windows プラットフォーム (UWP) の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)

## <a name="enable-the-location-capability"></a>位置情報機能を有効にする


1.  **ソリューション エクスプローラー**で、**package.appxmanifest** をダブルクリックし、**[機能]** タブを選びます。
2.  **[機能]** ボックスの一覧で、**[位置情報]** チェックボックスをオンにします。 これにより、`location` デバイス機能がパッケージ マニフェスト ファイルに追加されます。

```XML
  <Capabilities>
    <!-- DeviceCapability elements must follow Capability elements (if present) -->
    <DeviceCapability Name="location"/>
  </Capabilities>
```

## <a name="get-the-current-location"></a>現在の位置情報を取得する


このセクションでは、[**Windows.Devices.Geolocation**](https://msdn.microsoft.com/library/windows/apps/br225603) 名前空間の API を使ってユーザーの地理的な位置を検出する方法について説明します。

### <a name="step-1-request-access-to-the-users-location"></a>手順 1. ユーザーの位置情報へのアクセス許可を求める

粗い位置情報機能は、アプリがあるない限り (注をご覧ください)、位置情報にアクセスする前に、 [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152)メソッドを使用してユーザーの位置情報へのアクセスを要求する必要があります。 **RequestAccessAsync** メソッドは UI スレッドから呼び出す必要があり、アプリがフォアグラウンドで実行されている必要があります。 アプリがユーザーの位置情報にアクセスするには、先にユーザーがその情報へのアクセス許可をアプリに与える必要があります。\*

```csharp
using Windows.Devices.Geolocation;
...
var accessStatus = await Geolocator.RequestAccessAsync();
```



[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) メソッドを使って、ユーザーに位置情報へのアクセス許可を求めます。 ユーザーに対するこの要求はアプリごとに 1 回だけ行われます。 アクセス許可の付与または拒否を行った後、このメソッドはユーザーにアクセス許可を求めなくなります。 ユーザーが位置情報へのアクセス許可を求められた後にそのアクセス許可を変更できるように、位置情報の設定へのリンクを用意することをお勧めします。これについては、このトピックの後半で紹介します。

>注: 粗い位置情報機能では、ユーザーの明示的なアクセス許可 (システム全体の位置情報スイッチする必要があります**で**、ただし) を取得することがなく、意図的に暗号化されている (不正確な) 位置情報を取得するアプリができます。 アプリの粗い場所を利用する方法については、 [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/windows.devices.geolocation.geolocator.aspx)クラスで[**AllowFallbackToConsentlessPositions**](https://msdn.microsoft.com/library/windows/apps/Windows.Devices.Geolocation.Geolocator.AllowFallbackToConsentlessPositions)メソッドを参照してください。

### <a name="step-2-get-the-users-location-and-register-for-changes-in-location-permissions"></a>手順 2. ユーザーの位置情報を取得し、位置情報のアクセス許可の変更を登録する

[**GetGeopositionAsync**](https://msdn.microsoft.com/library/windows/apps/hh973536) メソッドは、現在の位置情報に対して 1 回限りの読み取りを実行します。 ここでは、**switch** ステートメントを (前の例で示した) **accessStatus** と共に使って、ユーザーの位置情報へのアクセス許可が与えられている場合にのみ動作するように指定します。 ユーザーの位置情報へのアクセス許可が与えられた場合は、コードによって [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) オブジェクトが作成され、位置情報へのアクセス許可の変更が登録され、ユーザーの位置情報が要求されます。

```csharp
switch (accessStatus)
{
    case GeolocationAccessStatus.Allowed:
        _rootPage.NotifyUser("Waiting for update...", NotifyType.StatusMessage);

        // If DesiredAccuracy or DesiredAccuracyInMeters are not set (or value is 0), DesiredAccuracy.Default is used.
        Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = _desireAccuracyInMetersValue };

        // Subscribe to the StatusChanged event to get updates of location status changes.
        _geolocator.StatusChanged += OnStatusChanged;

        // Carry out the operation.
        Geoposition pos = await geolocator.GetGeopositionAsync();

        UpdateLocationData(pos);
        _rootPage.NotifyUser("Location updated.", NotifyType.StatusMessage);
        break;

    case GeolocationAccessStatus.Denied:
        _rootPage.NotifyUser("Access to location is denied.", NotifyType.ErrorMessage);
        LocationDisabledMessage.Visibility = Visibility.Visible;
        UpdateLocationData(null);
        break;

    case GeolocationAccessStatus.Unspecified:
        _rootPage.NotifyUser("Unspecified error.", NotifyType.ErrorMessage);
        UpdateLocationData(null);
        break;
}
```

### <a name="step-3-handle-changes-in-location-permissions"></a>手順 3. 位置情報へのアクセス許可の変更を処理する

[**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) オブジェクトは [**StatusChanged**](https://msdn.microsoft.com/library/windows/apps/br225542) イベントをトリガーして、ユーザーの位置情報設定が変化したことを示します。 このイベントは、引数の **Status**  プロパティ ([**PositionStatus**](https://msdn.microsoft.com/library/windows/apps/br225599) 型) を使って、対応する状態を渡します。 このメソッドは UI スレッドから呼び出されず、[**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) オブジェクトが UI の変更を呼び出します。

```csharp
using Windows.UI.Core;
...
async private void OnStatusChanged(Geolocator sender, StatusChangedEventArgs e)
{
    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
        // Show the location setting message only if status is disabled.
        LocationDisabledMessage.Visibility = Visibility.Collapsed;

        switch (e.Status)
        {
            case PositionStatus.Ready:
                // Location platform is providing valid data.
                ScenarioOutput_Status.Text = "Ready";
                _rootPage.NotifyUser("Location platform is ready.", NotifyType.StatusMessage);
                break;

            case PositionStatus.Initializing:
                // Location platform is attempting to acquire a fix.
                ScenarioOutput_Status.Text = "Initializing";
                _rootPage.NotifyUser("Location platform is attempting to obtain a position.", NotifyType.StatusMessage);
                break;

            case PositionStatus.NoData:
                // Location platform could not obtain location data.
                ScenarioOutput_Status.Text = "No data";
                _rootPage.NotifyUser("Not able to determine the location.", NotifyType.ErrorMessage);
                break;

            case PositionStatus.Disabled:
                // The permission to access location data is denied by the user or other policies.
                ScenarioOutput_Status.Text = "Disabled";
                _rootPage.NotifyUser("Access to location is denied.", NotifyType.ErrorMessage);

                // Show message to the user to go to location settings.
                LocationDisabledMessage.Visibility = Visibility.Visible;

                // Clear any cached location data.
                UpdateLocationData(null);
                break;

            case PositionStatus.NotInitialized:
                // The location platform is not initialized. This indicates that the application
                // has not made a request for location data.
                ScenarioOutput_Status.Text = "Not initialized";
                _rootPage.NotifyUser("No request for location is made yet.", NotifyType.StatusMessage);
                break;

            case PositionStatus.NotAvailable:
                // The location platform is not available on this version of the OS.
                ScenarioOutput_Status.Text = "Not available";
                _rootPage.NotifyUser("Location is not available on this version of the OS.", NotifyType.ErrorMessage);
                break;

            default:
                ScenarioOutput_Status.Text = "Unknown";
                _rootPage.NotifyUser(string.Empty, NotifyType.StatusMessage);
                break;
        }
    });
}
```

## <a name="respond-to-location-updates"></a>位置情報の更新への対応


このセクションでは、[**PositionChanged**](https://msdn.microsoft.com/library/windows/apps/br225540) イベントを使って、特定の期間におけるユーザーの位置の更新情報を受け取る方法について説明します。 ユーザーはいつでも位置情報へのアクセス許可を取り消すことができるため、前のセクションで説明したように、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) を呼び出して [**StatusChanged**](https://msdn.microsoft.com/library/windows/apps/br225542) イベントを使うことが重要になります。

このセクションでは、既に位置情報機能を有効にし、フォアグラウンド アプリの UI スレッドから [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) を呼び出していることを前提としています。

### <a name="step-1-define-the-report-interval-and-register-for-location-updates"></a>手順 1. レポート間隔を定義し、位置情報の更新を登録する

この例では、**switch** ステートメントを (前の例で示した) **accessStatus** と共に使って、ユーザーの位置情報へのアクセス許可が与えられている場合にのみ動作するように指定します。 ユーザーの位置情報へのアクセス許可が与えられた場合は、コードによって [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) オブジェクトが作成され、追跡の種類の指定と位置情報の更新の登録が行われます。

[**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) オブジェクトは、位置の変化 (距離に基づく追跡) または時間の変化 (期間に基づく追跡) に基づいて [**PositionChanged**](https://msdn.microsoft.com/library/windows/apps/br225540) イベントをトリガーできます。

-   距離に基づく追跡の場合は、[**MovementThreshold**](https://msdn.microsoft.com/library/windows/apps/br225539) プロパティを設定します。
-   期間に基づく追跡の場合は、[**ReportInterval**](https://msdn.microsoft.com/library/windows/apps/br225541) プロパティを設定します。

どちらのプロパティも設定されていない場合は、位置が 1 秒ごとが返されます (`ReportInterval = 1000` と同じです)。 ここでは、2 秒 (`ReportInterval = 2000`) のレポート間隔を使います。
```csharp
using Windows.Devices.Geolocation;
...
var accessStatus = await Geolocator.RequestAccessAsync();

switch (accessStatus)
{
    case GeolocationAccessStatus.Allowed:
        // Create Geolocator and define perodic-based tracking (2 second interval).
        _geolocator = new Geolocator { ReportInterval = 2000 };

        // Subscribe to the PositionChanged event to get location updates.
        _geolocator.PositionChanged += OnPositionChanged;

        // Subscribe to StatusChanged event to get updates of location status changes.
        _geolocator.StatusChanged += OnStatusChanged;

        _rootPage.NotifyUser("Waiting for update...", NotifyType.StatusMessage);
        LocationDisabledMessage.Visibility = Visibility.Collapsed;
        StartTrackingButton.IsEnabled = false;
        StopTrackingButton.IsEnabled = true;
        break;

    case GeolocationAccessStatus.Denied:
        _rootPage.NotifyUser("Access to location is denied.", NotifyType.ErrorMessage);
        LocationDisabledMessage.Visibility = Visibility.Visible;
        break;

    case GeolocationAccessStatus.Unspecified:
        _rootPage.NotifyUser("Unspecificed error!", NotifyType.ErrorMessage);
        LocationDisabledMessage.Visibility = Visibility.Collapsed;
        break;
}
```

### <a name="step-2-handle-location-updates"></a>手順 2. 位置情報の更新を処理する

[**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) オブジェクトは [**PositionChanged**](https://msdn.microsoft.com/library/windows/apps/br225540) イベントをトリガーし、構成方法に応じて、ユーザーの位置が変化したことまたは時間が経過したことを示します。 このイベントは、引数の **Position** プロパティ ([**Geoposition**](https://msdn.microsoft.com/library/windows/apps/br225543)) を使って、対応する位置を渡します。 この例では、メソッドは UI スレッドから呼び出されず、[**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) オブジェクトが UI の変更を呼び出します。

```csharp
using Windows.UI.Core;
...
async private void OnPositionChanged(Geolocator sender, PositionChangedEventArgs e)
{
    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
        _rootPage.NotifyUser("Location updated.", NotifyType.StatusMessage);
        UpdateLocationData(e.Position);
    });
}
```

## <a name="change-the-location-privacy-settings"></a>位置情報のプライバシー設定を変更する


位置情報のプライバシー設定でアプリにユーザーの位置情報へのアクセス許可を与えていない場合は、**設定**アプリの **[位置情報のプライバシー設定]** へのリンクを用意することをお勧めします。 この例では、ハイパーリンク コントロールを使って、`ms-settings:privacy-location` という URI に移動します。

```xml
<!--Set Visibility to Visible when access to location is denied -->  
<TextBlock x:Name="LocationDisabledMessage" FontStyle="Italic"
                 Visibility="Collapsed" Margin="0,15,0,0" TextWrapping="Wrap" >
          <Run Text="This app is not able to access Location. Go to " />
              <Hyperlink NavigateUri="ms-settings:privacy-location">
                  <Run Text="Settings" />
              </Hyperlink>
          <Run Text=" to check the location privacy settings."/>
</TextBlock>
```

また、アプリで [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) メソッドを呼び出し、コードで**設定**アプリを起動することもできます。 詳しくは、「[Windows 設定アプリの起動](https://msdn.microsoft.com/library/windows/apps/mt228342)」をご覧ください。

```csharp
using Windows.System;
...
bool result = await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-location"));
```

## <a name="troubleshoot-your-app"></a>アプリのトラブルシューティングを行う


アプリがユーザーの位置情報にアクセスする前に、デバイスで **[位置情報]** を有効にする必要があります。 **設定**アプリで、次の**位置情報に関するプライバシー設定**がオンになっていることを確認します。

-   **このデバイス] の位置情報****オン (windows 10 Mobile では適用されません)**
-   位置情報サービス設定の **[位置情報]** が **オン** になっている
-   **[位置情報を使うことができるアプリを選ぶ]** で、アプリが **オン** になっている

## <a name="related-topics"></a>関連トピック

* [UWP の位置情報のサンプル](http://go.microsoft.com/fwlink/p/?linkid=533278)
* [ジオフェンスの設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn631756)
* [位置認識アプリの設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465148)
