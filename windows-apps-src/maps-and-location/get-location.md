---
author: PatrickFarley
title: ユーザーの位置情報の取得
description: ユーザーの位置情報を検索し、位置の変更に対応します。 ユーザーの位置情報へのアクセスは、設定アプリのプライバシー設定で管理されています。 このトピックでは、アプリにユーザーの位置情報へのアクセス許可が与えられているかどうかを確認する方法についても説明します。
ms.assetid: 24DC9A41-8CC1-48B0-BC6D-24BF571AFCC8
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 地図, 位置情報, 位置情報機能
ms.openlocfilehash: f5af2815783568cb234f1196e065f18b145c7e68
ms.sourcegitcommit: 8c4d50ef819ed1a2f8cac4eebefb5ccdaf3fa898
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/27/2017
ms.locfileid: "695744"
---
# <a name="get-the-users-location"></a><span data-ttu-id="a62b4-106">ユーザーの位置情報の取得</span><span class="sxs-lookup"><span data-stu-id="a62b4-106">Get the user's location</span></span>


<span data-ttu-id="a62b4-107">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="a62b4-107">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="a62b4-108">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]</span><span class="sxs-lookup"><span data-stu-id="a62b4-108">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>


<span data-ttu-id="a62b4-109">ユーザーの位置情報を検索し、位置の変更に対応します。</span><span class="sxs-lookup"><span data-stu-id="a62b4-109">Find the user's location and respond to changes in location.</span></span> <span data-ttu-id="a62b4-110">ユーザーの位置情報へのアクセスは、設定アプリのプライバシー設定で管理されています。</span><span class="sxs-lookup"><span data-stu-id="a62b4-110">Access to the user's location is managed by privacy settings in the Settings app.</span></span> <span data-ttu-id="a62b4-111">このトピックでは、アプリにユーザーの位置情報へのアクセス許可が与えられているかどうかを確認する方法についても説明します。</span><span class="sxs-lookup"><span data-stu-id="a62b4-111">This topic also shows how to check if your app has permission to access the user's location.</span></span>

<span data-ttu-id="a62b4-112">**ヒント:** アプリでユーザーの位置情報にアクセスする方法について詳しくは、GitHub の [Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619979)から次のサンプルをダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="a62b4-112">**Tip** To learn more about accessing the user's location in your app, download the following sample from the [Windows-universal-samples repo](http://go.microsoft.com/fwlink/p/?LinkId=619979) on GitHub.</span></span>

-   [<span data-ttu-id="a62b4-113">ユニバーサル Windows プラットフォーム (UWP) の地図サンプル</span><span class="sxs-lookup"><span data-stu-id="a62b4-113">Universal Windows Platform (UWP) map sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619977)

## <a name="enable-the-location-capability"></a><span data-ttu-id="a62b4-114">位置情報機能を有効にする</span><span class="sxs-lookup"><span data-stu-id="a62b4-114">Enable the location capability</span></span>


1.  <span data-ttu-id="a62b4-115">**ソリューション エクスプローラー**で、**package.appxmanifest** をダブルクリックし、**[機能]** タブを選びます。</span><span class="sxs-lookup"><span data-stu-id="a62b4-115">In **Solution Explorer**, double-click **package.appxmanifest** and select the **Capabilities** tab.</span></span>
2.  <span data-ttu-id="a62b4-116">**[機能]** ボックスの一覧で、**[位置情報]** チェックボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="a62b4-116">In the **Capabilities** list, check the box for **Location**.</span></span> <span data-ttu-id="a62b4-117">これにより、`location` デバイス機能がパッケージ マニフェスト ファイルに追加されます。</span><span class="sxs-lookup"><span data-stu-id="a62b4-117">This adds the `location` device capability to the package manifest file.</span></span>

```XML
  <Capabilities>
    <!-- DeviceCapability elements must follow Capability elements (if present) -->
    <DeviceCapability Name="location"/>
  </Capabilities>
```

## <a name="get-the-current-location"></a><span data-ttu-id="a62b4-118">現在の位置情報を取得する</span><span class="sxs-lookup"><span data-stu-id="a62b4-118">Get the current location</span></span>


<span data-ttu-id="a62b4-119">このセクションでは、[**Windows.Devices.Geolocation**](https://msdn.microsoft.com/library/windows/apps/br225603) 名前空間の API を使ってユーザーの地理的な位置を検出する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="a62b4-119">This section describes how to detect the user's geographic location using APIs in the [**Windows.Devices.Geolocation**](https://msdn.microsoft.com/library/windows/apps/br225603) namespace.</span></span>

### <a name="step-1-request-access-to-the-users-location"></a><span data-ttu-id="a62b4-120">手順 1. ユーザーの位置情報へのアクセス許可を求める</span><span class="sxs-lookup"><span data-stu-id="a62b4-120">Step 1: Request access to the user's location</span></span>

<span data-ttu-id="a62b4-121">アプリに Consentless Location 機能 (「注意」を参照) がない場合は、ユーザーの位置情報へアクセスする前に、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) メソッドを使用してユーザーの位置情報へのアクセス許可を求める必要があります。</span><span class="sxs-lookup"><span data-stu-id="a62b4-121">Unless your app has Consentless Location capability (see note), you must request access to the user's location by using the [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) method before attempting to access the location.</span></span> <span data-ttu-id="a62b4-122">**RequestAccessAsync** メソッドは UI スレッドから呼び出す必要があり、アプリがフォアグラウンドで実行されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="a62b4-122">You must call the **RequestAccessAsync** method from the UI thread and your app must be in the foreground.</span></span> <span data-ttu-id="a62b4-123">アプリがユーザーの位置情報にアクセスするには、先にユーザーがその情報へのアクセス許可をアプリに与える必要があります。\*</span><span class="sxs-lookup"><span data-stu-id="a62b4-123">Your app will not be able to access the user's location information until after the user grants permission to your app.\*</span></span>

```csharp
using Windows.Devices.Geolocation;
...
var accessStatus = await Geolocator.RequestAccessAsync();
```



<span data-ttu-id="a62b4-124">[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) メソッドを使って、ユーザーに位置情報へのアクセス許可を求めます。</span><span class="sxs-lookup"><span data-stu-id="a62b4-124">The [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) method prompts the user for permission to access their location.</span></span> <span data-ttu-id="a62b4-125">ユーザーに対するこの要求はアプリごとに 1 回だけ行われます。</span><span class="sxs-lookup"><span data-stu-id="a62b4-125">The user is only prompted once (per app).</span></span> <span data-ttu-id="a62b4-126">アクセス許可の付与または拒否を行った後、このメソッドはユーザーにアクセス許可を求めなくなります。</span><span class="sxs-lookup"><span data-stu-id="a62b4-126">After the first time they grant or deny permission, this method no longer prompts the user for permission.</span></span> <span data-ttu-id="a62b4-127">ユーザーが位置情報へのアクセス許可を求められた後にそのアクセス許可を変更できるように、位置情報の設定へのリンクを用意することをお勧めします。これについては、このトピックの後半で紹介します。</span><span class="sxs-lookup"><span data-stu-id="a62b4-127">To help the user change location permissions after they've been prompted, we recommend that you provide a link to the location settings as demonstrated later in this topic.</span></span>

><span data-ttu-id="a62b4-128">注意: Consentless Location 機能により、アプリはユーザーによる明示的な許可を必要とせずに、意図的にあいまいにされた (不正確な) 位置情報を取得できます (ただしシステム全体の位置情報スイッチは **on** のままである必要があります)。</span><span class="sxs-lookup"><span data-stu-id="a62b4-128">Note:  The Consentless Location feature allows your app to obtain an intentionally obfuscated (imprecise) location without getting the user's explicit permission (the system-wide location switch must still be **on**, however).</span></span> <span data-ttu-id="a62b4-129">アプリで Consentless Location を使用する方法について詳しくは、[**Geolocator**](https://msdn.microsoft.com/library/windows/apps/windows.devices.geolocation.geolocator.aspx) クラスの [**AllowFallbackToConsentlessPositions**](https://msdn.microsoft.com/library/windows/apps/Windows.Devices.Geolocation.Geolocator.AllowFallbackToConsentlessPositions) メソッドをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a62b4-129">To learn how to utilize Consentless Location in your app, see the [**AllowFallbackToConsentlessPositions**](https://msdn.microsoft.com/library/windows/apps/Windows.Devices.Geolocation.Geolocator.AllowFallbackToConsentlessPositions) method in the [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/windows.devices.geolocation.geolocator.aspx) class.</span></span>

### <a name="step-2-get-the-users-location-and-register-for-changes-in-location-permissions"></a><span data-ttu-id="a62b4-130">手順 2. ユーザーの位置情報を取得し、位置情報のアクセス許可の変更を登録する</span><span class="sxs-lookup"><span data-stu-id="a62b4-130">Step 2: Get the user's location and register for changes in location permissions</span></span>

<span data-ttu-id="a62b4-131">[**GetGeopositionAsync**](https://msdn.microsoft.com/library/windows/apps/hh973536) メソッドは、現在の位置情報に対して 1 回限りの読み取りを実行します。</span><span class="sxs-lookup"><span data-stu-id="a62b4-131">The [**GetGeopositionAsync**](https://msdn.microsoft.com/library/windows/apps/hh973536) method performs a one-time reading of the current location.</span></span> <span data-ttu-id="a62b4-132">ここでは、**switch** ステートメントを (前の例で示した) **accessStatus** と共に使って、ユーザーの位置情報へのアクセス許可が与えられている場合にのみ動作するように指定します。</span><span class="sxs-lookup"><span data-stu-id="a62b4-132">Here, a **switch** statement is used with **accessStatus** (from the previous example) to act only when access to the user's location is allowed.</span></span> <span data-ttu-id="a62b4-133">ユーザーの位置情報へのアクセス許可が与えられた場合は、コードによって [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) オブジェクトが作成され、位置情報へのアクセス許可の変更が登録され、ユーザーの位置情報が要求されます。</span><span class="sxs-lookup"><span data-stu-id="a62b4-133">If access to the user's location is allowed, the code creates a [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) object, registers for changes in location permissions, and requests the user's location.</span></span>

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

### <a name="step-3-handle-changes-in-location-permissions"></a><span data-ttu-id="a62b4-134">手順 3. 位置情報へのアクセス許可の変更を処理する</span><span class="sxs-lookup"><span data-stu-id="a62b4-134">Step 3: Handle changes in location permissions</span></span>

<span data-ttu-id="a62b4-135">[**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) オブジェクトは [**StatusChanged**](https://msdn.microsoft.com/library/windows/apps/br225542) イベントをトリガーして、ユーザーの位置情報設定が変化したことを示します。</span><span class="sxs-lookup"><span data-stu-id="a62b4-135">The [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) object triggers the [**StatusChanged**](https://msdn.microsoft.com/library/windows/apps/br225542) event to indicate that the user's location settings changed.</span></span> <span data-ttu-id="a62b4-136">このイベントは、引数の **Status**  プロパティ ([**PositionStatus**](https://msdn.microsoft.com/library/windows/apps/br225599) 型) を使って、対応する状態を渡します。</span><span class="sxs-lookup"><span data-stu-id="a62b4-136">That event passes the corresponding status via the argument's **Status** property (of type [**PositionStatus**](https://msdn.microsoft.com/library/windows/apps/br225599)).</span></span> <span data-ttu-id="a62b4-137">このメソッドは UI スレッドから呼び出されず、[**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) オブジェクトが UI の変更を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="a62b4-137">Note that this method is not called from the UI thread and the [**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) object invokes the UI changes.</span></span>

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

## <a name="respond-to-location-updates"></a><span data-ttu-id="a62b4-138">位置情報の更新への対応</span><span class="sxs-lookup"><span data-stu-id="a62b4-138">Respond to location updates</span></span>


<span data-ttu-id="a62b4-139">このセクションでは、[**PositionChanged**](https://msdn.microsoft.com/library/windows/apps/br225540) イベントを使って、特定の期間におけるユーザーの位置の更新情報を受け取る方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="a62b4-139">This section describes how to use the [**PositionChanged**](https://msdn.microsoft.com/library/windows/apps/br225540) event to receive updates of the user's location over a period of time.</span></span> <span data-ttu-id="a62b4-140">ユーザーはいつでも位置情報へのアクセス許可を取り消すことができるため、前のセクションで説明したように、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) を呼び出して [**StatusChanged**](https://msdn.microsoft.com/library/windows/apps/br225542) イベントを使うことが重要になります。</span><span class="sxs-lookup"><span data-stu-id="a62b4-140">Because the user could revoke access to location at any time, it's important call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) and use the [**StatusChanged**](https://msdn.microsoft.com/library/windows/apps/br225542) event as shown in the previous section.</span></span>

<span data-ttu-id="a62b4-141">このセクションでは、既に位置情報機能を有効にし、フォアグラウンド アプリの UI スレッドから [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) を呼び出していることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="a62b4-141">This section assumes that you've already enabled the location capability and called [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) from the UI thread of your foreground app.</span></span>

### <a name="step-1-define-the-report-interval-and-register-for-location-updates"></a><span data-ttu-id="a62b4-142">手順 1. レポート間隔を定義し、位置情報の更新を登録する</span><span class="sxs-lookup"><span data-stu-id="a62b4-142">Step 1: Define the report interval and register for location updates</span></span>

<span data-ttu-id="a62b4-143">この例では、**switch** ステートメントを (前の例で示した) **accessStatus** と共に使って、ユーザーの位置情報へのアクセス許可が与えられている場合にのみ動作するように指定します。</span><span class="sxs-lookup"><span data-stu-id="a62b4-143">In this example, a **switch** statement is used with **accessStatus** (from the previous example) to act only when access to the user's location is allowed.</span></span> <span data-ttu-id="a62b4-144">ユーザーの位置情報へのアクセス許可が与えられた場合は、コードによって [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) オブジェクトが作成され、追跡の種類の指定と位置情報の更新の登録が行われます。</span><span class="sxs-lookup"><span data-stu-id="a62b4-144">If access to the user's location is allowed, the code creates a [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) object, specifies the tracking type, and registers for location updates.</span></span>

<span data-ttu-id="a62b4-145">[**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) オブジェクトは、位置の変化 (距離に基づく追跡) または時間の変化 (期間に基づく追跡) に基づいて [**PositionChanged**](https://msdn.microsoft.com/library/windows/apps/br225540) イベントをトリガーできます。</span><span class="sxs-lookup"><span data-stu-id="a62b4-145">The [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) object can trigger the [**PositionChanged**](https://msdn.microsoft.com/library/windows/apps/br225540) event based on a change in position (distance-based tracking) or a change in time (periodic-based tracking).</span></span>

-   <span data-ttu-id="a62b4-146">距離に基づく追跡の場合は、[**MovementThreshold**](https://msdn.microsoft.com/library/windows/apps/br225539) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="a62b4-146">For distance-based tracking, set the [**MovementThreshold**](https://msdn.microsoft.com/library/windows/apps/br225539) property.</span></span>
-   <span data-ttu-id="a62b4-147">期間に基づく追跡の場合は、[**ReportInterval**](https://msdn.microsoft.com/library/windows/apps/br225541) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="a62b4-147">For periodic-based tracking, set the [**ReportInterval**](https://msdn.microsoft.com/library/windows/apps/br225541) property.</span></span>

<span data-ttu-id="a62b4-148">どちらのプロパティも設定されていない場合は、位置が 1 秒ごとが返されます (`ReportInterval = 1000` と同じです)。</span><span class="sxs-lookup"><span data-stu-id="a62b4-148">If neither property is set, a position is returned every 1 second (equivalent to `ReportInterval = 1000`).</span></span> <span data-ttu-id="a62b4-149">ここでは、2 秒 (`ReportInterval = 2000`) のレポート間隔を使います。</span><span class="sxs-lookup"><span data-stu-id="a62b4-149">Here, a 2 second (`ReportInterval = 2000`) report interval is used.</span></span>
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

### <a name="step-2-handle-location-updates"></a><span data-ttu-id="a62b4-150">手順 2. 位置情報の更新を処理する</span><span class="sxs-lookup"><span data-stu-id="a62b4-150">Step 2: Handle location updates</span></span>

<span data-ttu-id="a62b4-151">[**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) オブジェクトは [**PositionChanged**](https://msdn.microsoft.com/library/windows/apps/br225540) イベントをトリガーし、構成方法に応じて、ユーザーの位置が変化したことまたは時間が経過したことを示します。</span><span class="sxs-lookup"><span data-stu-id="a62b4-151">The [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) object triggers the [**PositionChanged**](https://msdn.microsoft.com/library/windows/apps/br225540) event to indicate that the user's location changed or time has passed, depending on how you've configured it.</span></span> <span data-ttu-id="a62b4-152">このイベントは、引数の **Position** プロパティ ([**Geoposition**](https://msdn.microsoft.com/library/windows/apps/br225543)) を使って、対応する位置を渡します。</span><span class="sxs-lookup"><span data-stu-id="a62b4-152">That event passes the corresponding location via the argument's **Position** property (of type [**Geoposition**](https://msdn.microsoft.com/library/windows/apps/br225543)).</span></span> <span data-ttu-id="a62b4-153">この例では、メソッドは UI スレッドから呼び出されず、[**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) オブジェクトが UI の変更を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="a62b4-153">In this example, the method is not called from the UI thread and the [**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) object invokes the UI changes.</span></span>

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

## <a name="change-the-location-privacy-settings"></a><span data-ttu-id="a62b4-154">位置情報のプライバシー設定を変更する</span><span class="sxs-lookup"><span data-stu-id="a62b4-154">Change the location privacy settings</span></span>


<span data-ttu-id="a62b4-155">位置情報のプライバシー設定でアプリにユーザーの位置情報へのアクセス許可を与えていない場合は、**設定**アプリの **[位置情報のプライバシー設定]** へのリンクを用意することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a62b4-155">If the location privacy settings don't allow your app to access the user's location, we recommend that you provide a convenient link to the **location privacy settings** in the **Settings** app.</span></span> <span data-ttu-id="a62b4-156">この例では、ハイパーリンク コントロールを使って、`ms-settings:privacy-location` という URI に移動します。</span><span class="sxs-lookup"><span data-stu-id="a62b4-156">In this example, a Hyperlink control is used navigate to the `ms-settings:privacy-location` URI.</span></span>

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

<span data-ttu-id="a62b4-157">また、アプリで [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) メソッドを呼び出し、コードで**設定**アプリを起動することもできます。</span><span class="sxs-lookup"><span data-stu-id="a62b4-157">Alternatively, your app can call the [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) method to launch the **Settings** app from code.</span></span> <span data-ttu-id="a62b4-158">詳しくは、「[Windows 設定アプリの起動](https://msdn.microsoft.com/library/windows/apps/mt228342)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a62b4-158">For more info, see [Launch the Windows Settings app](https://msdn.microsoft.com/library/windows/apps/mt228342).</span></span>

```csharp
using Windows.System;
...
bool result = await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-location"));
```

## <a name="troubleshoot-your-app"></a><span data-ttu-id="a62b4-159">アプリのトラブルシューティングを行う</span><span class="sxs-lookup"><span data-stu-id="a62b4-159">Troubleshoot your app</span></span>


<span data-ttu-id="a62b4-160">アプリがユーザーの位置情報にアクセスする前に、デバイスで **[位置情報]** を有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="a62b4-160">Before your app can access the user's location, **Location** must be enabled on the device.</span></span> <span data-ttu-id="a62b4-161">**設定**アプリで、次の**位置情報に関するプライバシー設定**がオンになっていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="a62b4-161">In the **Settings** app, check that the following **location privacy settings** are turned on:</span></span>

-   <span data-ttu-id="a62b4-162">**[このデバイスの位置情報]** が **オン**  になっている (Windows 10 Mobile には適用されません)</span><span class="sxs-lookup"><span data-stu-id="a62b4-162">**Location for this device...** is turned **on** (not applicable in Windows 10 Mobile)</span></span>
-   <span data-ttu-id="a62b4-163">位置情報サービス設定の **[位置情報]** が **オン** になっている</span><span class="sxs-lookup"><span data-stu-id="a62b4-163">The location services setting, **Location**, is turned **on**</span></span>
-   <span data-ttu-id="a62b4-164">**[位置情報を使うことができるアプリを選ぶ]** で、アプリが **オン** になっている</span><span class="sxs-lookup"><span data-stu-id="a62b4-164">Under **Choose apps that can use your location**, your app is set to **on**</span></span>

## <a name="related-topics"></a><span data-ttu-id="a62b4-165">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a62b4-165">Related topics</span></span>

* [<span data-ttu-id="a62b4-166">UWP の位置情報のサンプル</span><span class="sxs-lookup"><span data-stu-id="a62b4-166">UWP geolocation sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=533278)
* [<span data-ttu-id="a62b4-167">ジオフェンスの設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="a62b4-167">Design guidelines for geofencing</span></span>](https://msdn.microsoft.com/library/windows/apps/dn631756)
* [<span data-ttu-id="a62b4-168">位置認識アプリの設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="a62b4-168">Design guidelines for location-aware apps</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465148)
