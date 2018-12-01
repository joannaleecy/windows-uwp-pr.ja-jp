---
title: ユーザーの位置情報の取得
description: ユーザーの位置情報を検索し、位置の変更に対応します。 ユーザーの位置情報へのアクセスは、設定アプリのプライバシー設定で管理されています。 このトピックでは、アプリにユーザーの位置情報へのアクセス許可が与えられているかどうかを確認する方法についても説明します。
ms.assetid: 24DC9A41-8CC1-48B0-BC6D-24BF571AFCC8
ms.date: 11/28/2017
ms.topic: article
keywords: Windows 10, UWP, 地図, 位置情報, 位置情報機能
ms.localizationpriority: medium
ms.openlocfilehash: fae533e0ce42e14e3c53f5083b746a9aae221adf
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/01/2018
ms.locfileid: "8351460"
---
# <a name="get-the-users-location"></a><span data-ttu-id="e19d6-106">ユーザーの位置情報の取得</span><span class="sxs-lookup"><span data-stu-id="e19d6-106">Get the user's location</span></span>




<span data-ttu-id="e19d6-107">ユーザーの位置情報を検索し、位置の変更に対応します。</span><span class="sxs-lookup"><span data-stu-id="e19d6-107">Find the user's location and respond to changes in location.</span></span> <span data-ttu-id="e19d6-108">ユーザーの位置情報へのアクセスは、設定アプリのプライバシー設定で管理されています。</span><span class="sxs-lookup"><span data-stu-id="e19d6-108">Access to the user's location is managed by privacy settings in the Settings app.</span></span> <span data-ttu-id="e19d6-109">このトピックでは、アプリにユーザーの位置情報へのアクセス許可が与えられているかどうかを確認する方法についても説明します。</span><span class="sxs-lookup"><span data-stu-id="e19d6-109">This topic also shows how to check if your app has permission to access the user's location.</span></span>

<span data-ttu-id="e19d6-110">**ヒント:** アプリでユーザーの位置情報にアクセスする方法について詳しくは、GitHub の [Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619979)から次のサンプルをダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="e19d6-110">**Tip** To learn more about accessing the user's location in your app, download the following sample from the [Windows-universal-samples repo](http://go.microsoft.com/fwlink/p/?LinkId=619979) on GitHub.</span></span>

-   [<span data-ttu-id="e19d6-111">ユニバーサル Windows プラットフォーム (UWP) の地図サンプル</span><span class="sxs-lookup"><span data-stu-id="e19d6-111">Universal Windows Platform (UWP) map sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619977)

## <a name="enable-the-location-capability"></a><span data-ttu-id="e19d6-112">位置情報機能を有効にする</span><span class="sxs-lookup"><span data-stu-id="e19d6-112">Enable the location capability</span></span>


1.  <span data-ttu-id="e19d6-113">**ソリューション エクスプローラー**で、**package.appxmanifest** をダブルクリックし、**[機能]** タブを選びます。</span><span class="sxs-lookup"><span data-stu-id="e19d6-113">In **Solution Explorer**, double-click **package.appxmanifest** and select the **Capabilities** tab.</span></span>
2.  <span data-ttu-id="e19d6-114">**[機能]** ボックスの一覧で、**[位置情報]** チェックボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="e19d6-114">In the **Capabilities** list, check the box for **Location**.</span></span> <span data-ttu-id="e19d6-115">これにより、`location` デバイス機能がパッケージ マニフェスト ファイルに追加されます。</span><span class="sxs-lookup"><span data-stu-id="e19d6-115">This adds the `location` device capability to the package manifest file.</span></span>

```XML
  <Capabilities>
    <!-- DeviceCapability elements must follow Capability elements (if present) -->
    <DeviceCapability Name="location"/>
  </Capabilities>
```

## <a name="get-the-current-location"></a><span data-ttu-id="e19d6-116">現在の位置情報を取得する</span><span class="sxs-lookup"><span data-stu-id="e19d6-116">Get the current location</span></span>


<span data-ttu-id="e19d6-117">このセクションでは、[**Windows.Devices.Geolocation**](https://msdn.microsoft.com/library/windows/apps/br225603) 名前空間の API を使ってユーザーの地理的な位置を検出する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e19d6-117">This section describes how to detect the user's geographic location using APIs in the [**Windows.Devices.Geolocation**](https://msdn.microsoft.com/library/windows/apps/br225603) namespace.</span></span>

### <a name="step-1-request-access-to-the-users-location"></a><span data-ttu-id="e19d6-118">手順 1. ユーザーの位置情報へのアクセス許可を求める</span><span class="sxs-lookup"><span data-stu-id="e19d6-118">Step 1: Request access to the user's location</span></span>

<span data-ttu-id="e19d6-119">粗い位置情報機能は、アプリがあるない限り (注をご覧ください)、位置情報にアクセスする前に、 [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152)メソッドを使用してユーザーの位置情報へのアクセスを要求する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e19d6-119">Unless your app has coarse location capability (see note), you must request access to the user's location by using the [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) method before attempting to access the location.</span></span> <span data-ttu-id="e19d6-120">**RequestAccessAsync** メソッドは UI スレッドから呼び出す必要があり、アプリがフォアグラウンドで実行されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="e19d6-120">You must call the **RequestAccessAsync** method from the UI thread and your app must be in the foreground.</span></span> <span data-ttu-id="e19d6-121">アプリがユーザーの位置情報にアクセスするには、先にユーザーがその情報へのアクセス許可をアプリに与える必要があります。\*</span><span class="sxs-lookup"><span data-stu-id="e19d6-121">Your app will not be able to access the user's location information until after the user grants permission to your app.\*</span></span>

```csharp
using Windows.Devices.Geolocation;
...
var accessStatus = await Geolocator.RequestAccessAsync();
```



<span data-ttu-id="e19d6-122">[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) メソッドを使って、ユーザーに位置情報へのアクセス許可を求めます。</span><span class="sxs-lookup"><span data-stu-id="e19d6-122">The [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) method prompts the user for permission to access their location.</span></span> <span data-ttu-id="e19d6-123">ユーザーに対するこの要求はアプリごとに 1 回だけ行われます。</span><span class="sxs-lookup"><span data-stu-id="e19d6-123">The user is only prompted once (per app).</span></span> <span data-ttu-id="e19d6-124">アクセス許可の付与または拒否を行った後、このメソッドはユーザーにアクセス許可を求めなくなります。</span><span class="sxs-lookup"><span data-stu-id="e19d6-124">After the first time they grant or deny permission, this method no longer prompts the user for permission.</span></span> <span data-ttu-id="e19d6-125">ユーザーが位置情報へのアクセス許可を求められた後にそのアクセス許可を変更できるように、位置情報の設定へのリンクを用意することをお勧めします。これについては、このトピックの後半で紹介します。</span><span class="sxs-lookup"><span data-stu-id="e19d6-125">To help the user change location permissions after they've been prompted, we recommend that you provide a link to the location settings as demonstrated later in this topic.</span></span>

><span data-ttu-id="e19d6-126">注: 粗い位置情報機能により、(システム全体の位置情報スイッチする必要があります**で**、ただし)、ユーザーの明示的なアクセス許可を取得することがなく、意図的に暗号化されている (不正確な) 位置情報を取得するアプリです。</span><span class="sxs-lookup"><span data-stu-id="e19d6-126">Note:  The coarse location feature allows your app to obtain an intentionally obfuscated (imprecise) location without getting the user's explicit permission (the system-wide location switch must still be **on**, however).</span></span> <span data-ttu-id="e19d6-127">アプリの粗い場所を利用する方法については、 [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/windows.devices.geolocation.geolocator.aspx)クラスの[**AllowFallbackToConsentlessPositions**](https://msdn.microsoft.com/library/windows/apps/Windows.Devices.Geolocation.Geolocator.AllowFallbackToConsentlessPositions)メソッドを参照してください。</span><span class="sxs-lookup"><span data-stu-id="e19d6-127">To learn how to utilize coarse location in your app, see the [**AllowFallbackToConsentlessPositions**](https://msdn.microsoft.com/library/windows/apps/Windows.Devices.Geolocation.Geolocator.AllowFallbackToConsentlessPositions) method in the [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/windows.devices.geolocation.geolocator.aspx) class.</span></span>

### <a name="step-2-get-the-users-location-and-register-for-changes-in-location-permissions"></a><span data-ttu-id="e19d6-128">手順 2. ユーザーの位置情報を取得し、位置情報のアクセス許可の変更を登録する</span><span class="sxs-lookup"><span data-stu-id="e19d6-128">Step 2: Get the user's location and register for changes in location permissions</span></span>

<span data-ttu-id="e19d6-129">[**GetGeopositionAsync**](https://msdn.microsoft.com/library/windows/apps/hh973536) メソッドは、現在の位置情報に対して 1 回限りの読み取りを実行します。</span><span class="sxs-lookup"><span data-stu-id="e19d6-129">The [**GetGeopositionAsync**](https://msdn.microsoft.com/library/windows/apps/hh973536) method performs a one-time reading of the current location.</span></span> <span data-ttu-id="e19d6-130">ここでは、**switch** ステートメントを (前の例で示した) **accessStatus** と共に使って、ユーザーの位置情報へのアクセス許可が与えられている場合にのみ動作するように指定します。</span><span class="sxs-lookup"><span data-stu-id="e19d6-130">Here, a **switch** statement is used with **accessStatus** (from the previous example) to act only when access to the user's location is allowed.</span></span> <span data-ttu-id="e19d6-131">ユーザーの位置情報へのアクセス許可が与えられた場合は、コードによって [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) オブジェクトが作成され、位置情報へのアクセス許可の変更が登録され、ユーザーの位置情報が要求されます。</span><span class="sxs-lookup"><span data-stu-id="e19d6-131">If access to the user's location is allowed, the code creates a [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) object, registers for changes in location permissions, and requests the user's location.</span></span>

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

### <a name="step-3-handle-changes-in-location-permissions"></a><span data-ttu-id="e19d6-132">手順 3. 位置情報へのアクセス許可の変更を処理する</span><span class="sxs-lookup"><span data-stu-id="e19d6-132">Step 3: Handle changes in location permissions</span></span>

<span data-ttu-id="e19d6-133">[**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) オブジェクトは [**StatusChanged**](https://msdn.microsoft.com/library/windows/apps/br225542) イベントをトリガーして、ユーザーの位置情報設定が変化したことを示します。</span><span class="sxs-lookup"><span data-stu-id="e19d6-133">The [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) object triggers the [**StatusChanged**](https://msdn.microsoft.com/library/windows/apps/br225542) event to indicate that the user's location settings changed.</span></span> <span data-ttu-id="e19d6-134">このイベントは、引数の **Status**  プロパティ ([**PositionStatus**](https://msdn.microsoft.com/library/windows/apps/br225599) 型) を使って、対応する状態を渡します。</span><span class="sxs-lookup"><span data-stu-id="e19d6-134">That event passes the corresponding status via the argument's **Status** property (of type [**PositionStatus**](https://msdn.microsoft.com/library/windows/apps/br225599)).</span></span> <span data-ttu-id="e19d6-135">このメソッドは UI スレッドから呼び出されず、[**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) オブジェクトが UI の変更を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e19d6-135">Note that this method is not called from the UI thread and the [**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) object invokes the UI changes.</span></span>

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

## <a name="respond-to-location-updates"></a><span data-ttu-id="e19d6-136">位置情報の更新への対応</span><span class="sxs-lookup"><span data-stu-id="e19d6-136">Respond to location updates</span></span>


<span data-ttu-id="e19d6-137">このセクションでは、[**PositionChanged**](https://msdn.microsoft.com/library/windows/apps/br225540) イベントを使って、特定の期間におけるユーザーの位置の更新情報を受け取る方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e19d6-137">This section describes how to use the [**PositionChanged**](https://msdn.microsoft.com/library/windows/apps/br225540) event to receive updates of the user's location over a period of time.</span></span> <span data-ttu-id="e19d6-138">ユーザーはいつでも位置情報へのアクセス許可を取り消すことができるため、前のセクションで説明したように、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) を呼び出して [**StatusChanged**](https://msdn.microsoft.com/library/windows/apps/br225542) イベントを使うことが重要になります。</span><span class="sxs-lookup"><span data-stu-id="e19d6-138">Because the user could revoke access to location at any time, it's important call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) and use the [**StatusChanged**](https://msdn.microsoft.com/library/windows/apps/br225542) event as shown in the previous section.</span></span>

<span data-ttu-id="e19d6-139">このセクションでは、既に位置情報機能を有効にし、フォアグラウンド アプリの UI スレッドから [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) を呼び出していることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="e19d6-139">This section assumes that you've already enabled the location capability and called [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) from the UI thread of your foreground app.</span></span>

### <a name="step-1-define-the-report-interval-and-register-for-location-updates"></a><span data-ttu-id="e19d6-140">手順 1. レポート間隔を定義し、位置情報の更新を登録する</span><span class="sxs-lookup"><span data-stu-id="e19d6-140">Step 1: Define the report interval and register for location updates</span></span>

<span data-ttu-id="e19d6-141">この例では、**switch** ステートメントを (前の例で示した) **accessStatus** と共に使って、ユーザーの位置情報へのアクセス許可が与えられている場合にのみ動作するように指定します。</span><span class="sxs-lookup"><span data-stu-id="e19d6-141">In this example, a **switch** statement is used with **accessStatus** (from the previous example) to act only when access to the user's location is allowed.</span></span> <span data-ttu-id="e19d6-142">ユーザーの位置情報へのアクセス許可が与えられた場合は、コードによって [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) オブジェクトが作成され、追跡の種類の指定と位置情報の更新の登録が行われます。</span><span class="sxs-lookup"><span data-stu-id="e19d6-142">If access to the user's location is allowed, the code creates a [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) object, specifies the tracking type, and registers for location updates.</span></span>

<span data-ttu-id="e19d6-143">[**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) オブジェクトは、位置の変化 (距離に基づく追跡) または時間の変化 (期間に基づく追跡) に基づいて [**PositionChanged**](https://msdn.microsoft.com/library/windows/apps/br225540) イベントをトリガーできます。</span><span class="sxs-lookup"><span data-stu-id="e19d6-143">The [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) object can trigger the [**PositionChanged**](https://msdn.microsoft.com/library/windows/apps/br225540) event based on a change in position (distance-based tracking) or a change in time (periodic-based tracking).</span></span>

-   <span data-ttu-id="e19d6-144">距離に基づく追跡の場合は、[**MovementThreshold**](https://msdn.microsoft.com/library/windows/apps/br225539) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="e19d6-144">For distance-based tracking, set the [**MovementThreshold**](https://msdn.microsoft.com/library/windows/apps/br225539) property.</span></span>
-   <span data-ttu-id="e19d6-145">期間に基づく追跡の場合は、[**ReportInterval**](https://msdn.microsoft.com/library/windows/apps/br225541) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="e19d6-145">For periodic-based tracking, set the [**ReportInterval**](https://msdn.microsoft.com/library/windows/apps/br225541) property.</span></span>

<span data-ttu-id="e19d6-146">どちらのプロパティも設定されていない場合は、位置が 1 秒ごとが返されます (`ReportInterval = 1000` と同じです)。</span><span class="sxs-lookup"><span data-stu-id="e19d6-146">If neither property is set, a position is returned every 1 second (equivalent to `ReportInterval = 1000`).</span></span> <span data-ttu-id="e19d6-147">ここでは、2 秒 (`ReportInterval = 2000`) のレポート間隔を使います。</span><span class="sxs-lookup"><span data-stu-id="e19d6-147">Here, a 2 second (`ReportInterval = 2000`) report interval is used.</span></span>
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

### <a name="step-2-handle-location-updates"></a><span data-ttu-id="e19d6-148">手順 2. 位置情報の更新を処理する</span><span class="sxs-lookup"><span data-stu-id="e19d6-148">Step 2: Handle location updates</span></span>

<span data-ttu-id="e19d6-149">[**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) オブジェクトは [**PositionChanged**](https://msdn.microsoft.com/library/windows/apps/br225540) イベントをトリガーし、構成方法に応じて、ユーザーの位置が変化したことまたは時間が経過したことを示します。</span><span class="sxs-lookup"><span data-stu-id="e19d6-149">The [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) object triggers the [**PositionChanged**](https://msdn.microsoft.com/library/windows/apps/br225540) event to indicate that the user's location changed or time has passed, depending on how you've configured it.</span></span> <span data-ttu-id="e19d6-150">このイベントは、引数の **Position** プロパティ ([**Geoposition**](https://msdn.microsoft.com/library/windows/apps/br225543)) を使って、対応する位置を渡します。</span><span class="sxs-lookup"><span data-stu-id="e19d6-150">That event passes the corresponding location via the argument's **Position** property (of type [**Geoposition**](https://msdn.microsoft.com/library/windows/apps/br225543)).</span></span> <span data-ttu-id="e19d6-151">この例では、メソッドは UI スレッドから呼び出されず、[**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) オブジェクトが UI の変更を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e19d6-151">In this example, the method is not called from the UI thread and the [**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) object invokes the UI changes.</span></span>

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

## <a name="change-the-location-privacy-settings"></a><span data-ttu-id="e19d6-152">位置情報のプライバシー設定を変更する</span><span class="sxs-lookup"><span data-stu-id="e19d6-152">Change the location privacy settings</span></span>


<span data-ttu-id="e19d6-153">位置情報のプライバシー設定でアプリにユーザーの位置情報へのアクセス許可を与えていない場合は、**設定**アプリの **[位置情報のプライバシー設定]** へのリンクを用意することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e19d6-153">If the location privacy settings don't allow your app to access the user's location, we recommend that you provide a convenient link to the **location privacy settings** in the **Settings** app.</span></span> <span data-ttu-id="e19d6-154">この例では、ハイパーリンク コントロールを使って、`ms-settings:privacy-location` という URI に移動します。</span><span class="sxs-lookup"><span data-stu-id="e19d6-154">In this example, a Hyperlink control is used navigate to the `ms-settings:privacy-location` URI.</span></span>

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

<span data-ttu-id="e19d6-155">また、アプリで [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) メソッドを呼び出し、コードで**設定**アプリを起動することもできます。</span><span class="sxs-lookup"><span data-stu-id="e19d6-155">Alternatively, your app can call the [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) method to launch the **Settings** app from code.</span></span> <span data-ttu-id="e19d6-156">詳しくは、「[Windows 設定アプリの起動](https://msdn.microsoft.com/library/windows/apps/mt228342)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e19d6-156">For more info, see [Launch the Windows Settings app](https://msdn.microsoft.com/library/windows/apps/mt228342).</span></span>

```csharp
using Windows.System;
...
bool result = await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-location"));
```

## <a name="troubleshoot-your-app"></a><span data-ttu-id="e19d6-157">アプリのトラブルシューティングを行う</span><span class="sxs-lookup"><span data-stu-id="e19d6-157">Troubleshoot your app</span></span>


<span data-ttu-id="e19d6-158">アプリがユーザーの位置情報にアクセスする前に、デバイスで **[位置情報]** を有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e19d6-158">Before your app can access the user's location, **Location** must be enabled on the device.</span></span> <span data-ttu-id="e19d6-159">**設定**アプリで、次の**位置情報に関するプライバシー設定**がオンになっていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="e19d6-159">In the **Settings** app, check that the following **location privacy settings** are turned on:</span></span>

-   <span data-ttu-id="e19d6-160">**このデバイス] の位置情報\*\*\*\*オン (windows 10 Mobile には適用されません)**</span><span class="sxs-lookup"><span data-stu-id="e19d6-160">**Location for this device...** is turned **on** (not applicable in Windows10 Mobile)</span></span>
-   <span data-ttu-id="e19d6-161">位置情報サービス設定の **[位置情報]** が **オン** になっている</span><span class="sxs-lookup"><span data-stu-id="e19d6-161">The location services setting, **Location**, is turned **on**</span></span>
-   <span data-ttu-id="e19d6-162">**[位置情報を使うことができるアプリを選ぶ]** で、アプリが **オン** になっている</span><span class="sxs-lookup"><span data-stu-id="e19d6-162">Under **Choose apps that can use your location**, your app is set to **on**</span></span>

## <a name="related-topics"></a><span data-ttu-id="e19d6-163">関連トピック</span><span class="sxs-lookup"><span data-stu-id="e19d6-163">Related topics</span></span>

* [<span data-ttu-id="e19d6-164">UWP の位置情報のサンプル</span><span class="sxs-lookup"><span data-stu-id="e19d6-164">UWP geolocation sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=533278)
* [<span data-ttu-id="e19d6-165">ジオフェンスの設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="e19d6-165">Design guidelines for geofencing</span></span>](https://msdn.microsoft.com/library/windows/apps/dn631756)
* [<span data-ttu-id="e19d6-166">位置認識アプリの設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="e19d6-166">Design guidelines for location-aware apps</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465148)
