---
author: PatrickFarley
title: ジオフェンスのセットアップ
description: アプリでジオフェンスをセットアップし、フォアグラウンドとバックグラウンドで通知を処理する方法について説明します。
ms.assetid: A3A46E03-0751-4DBD-A2A1-2323DB09BDBA
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, 地図, 位置情報, ジオフェンス, 通知
ms.localizationpriority: medium
ms.openlocfilehash: 8e9fa71b3d6ae002aa37e14e23b55793876156c8
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5542276"
---
# <a name="set-up-a-geofence"></a><span data-ttu-id="3cab8-104">ジオフェンスのセットアップ</span><span class="sxs-lookup"><span data-stu-id="3cab8-104">Set up a geofence</span></span>




<span data-ttu-id="3cab8-105">アプリで[**ジオフェンス**](https://msdn.microsoft.com/library/windows/apps/dn263587)をセットアップし、フォアグラウンドとバックグラウンドで通知を処理する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-105">Set up a [**Geofence**](https://msdn.microsoft.com/library/windows/apps/dn263587) in your app, and learn how to handle notifications in the foreground and background.</span></span>

<span data-ttu-id="3cab8-106">**ヒント** アプリで位置情報にアクセスする方法について詳しくは、GitHub の [Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619979)から次のサンプルをダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="3cab8-106">**Tip** To learn more about accessing location in your app, download the following sample from the [Windows-universal-samples repo](http://go.microsoft.com/fwlink/p/?LinkId=619979) on GitHub.</span></span>

-   [<span data-ttu-id="3cab8-107">ユニバーサル Windows プラットフォーム (UWP) の地図サンプル</span><span class="sxs-lookup"><span data-stu-id="3cab8-107">Universal Windows Platform (UWP) map sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619977)

## <a name="enable-the-location-capability"></a><span data-ttu-id="3cab8-108">位置情報機能を有効にする</span><span class="sxs-lookup"><span data-stu-id="3cab8-108">Enable the location capability</span></span>


1.  <span data-ttu-id="3cab8-109">**ソリューション エクスプローラー**で、**package.appxmanifest** をダブルクリックし、**[機能]** タブを選びます。</span><span class="sxs-lookup"><span data-stu-id="3cab8-109">In **Solution Explorer**, double-click on **package.appxmanifest** and select the **Capabilities** tab.</span></span>
2.  <span data-ttu-id="3cab8-110">**[機能]** ボックスの一覧で、**[位置情報]** をオンにします。</span><span class="sxs-lookup"><span data-stu-id="3cab8-110">In the **Capabilities** list, check **Location**.</span></span> <span data-ttu-id="3cab8-111">これにより、`Location` デバイス機能がパッケージ マニフェスト ファイルに追加されます。</span><span class="sxs-lookup"><span data-stu-id="3cab8-111">This adds the `Location` device capability to the package manifest file.</span></span>

```xml
  <Capabilities>
    <!-- DeviceCapability elements must follow Capability elements (if present) -->
    <DeviceCapability Name="location"/>
  </Capabilities>
```

## <a name="set-up-a-geofence"></a><span data-ttu-id="3cab8-112">ジオフェンスのセットアップ</span><span class="sxs-lookup"><span data-stu-id="3cab8-112">Set up a geofence</span></span>


### <a name="step-1-request-access-to-the-users-location"></a><span data-ttu-id="3cab8-113">手順 1. ユーザーの位置情報へのアクセス許可を求める</span><span class="sxs-lookup"><span data-stu-id="3cab8-113">Step 1: Request access to the user's location</span></span>

<span data-ttu-id="3cab8-114">**重要** ユーザーの位置情報にアクセスする前に、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) メソッドを使って、ユーザーに位置情報へのアクセス許可を求める必要があります。</span><span class="sxs-lookup"><span data-stu-id="3cab8-114">**Important** You must request access to the user's location by using the [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) method before attempting to access the user's location.</span></span> <span data-ttu-id="3cab8-115">**RequestAccessAsync** メソッドは UI スレッドから呼び出す必要があり、アプリがフォアグラウンドで実行されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="3cab8-115">You must call the **RequestAccessAsync** method from the UI thread and your app must be in the foreground.</span></span> <span data-ttu-id="3cab8-116">アプリがユーザーの位置情報にアクセスするには、先にユーザーがその情報へのアクセス許可をアプリに与える必要があります。</span><span class="sxs-lookup"><span data-stu-id="3cab8-116">Your app will not be able to access the user's location information until after the user grants permission to your app.</span></span>

```csharp
using Windows.Devices.Geolocation;
...
var accessStatus = await Geolocator.RequestAccessAsync();
```

<span data-ttu-id="3cab8-117">[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) メソッドを使って、ユーザーに位置情報へのアクセス許可を求めます。</span><span class="sxs-lookup"><span data-stu-id="3cab8-117">The [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) method prompts the user for permission to access their location.</span></span> <span data-ttu-id="3cab8-118">ユーザーに対するこの要求はアプリごとに 1 回だけ行われます。</span><span class="sxs-lookup"><span data-stu-id="3cab8-118">The user is only prompted once (per app).</span></span> <span data-ttu-id="3cab8-119">アクセス許可の付与または拒否を行った後、このメソッドはユーザーにアクセス許可を求めなくなります。</span><span class="sxs-lookup"><span data-stu-id="3cab8-119">After the first time they grant or deny permission, this method no longer prompts the user for permission.</span></span> <span data-ttu-id="3cab8-120">ユーザーが位置情報へのアクセス許可を求められた後にそのアクセス許可を変更できるように、位置情報の設定へのリンクを用意することをお勧めします。これについては、このトピックの後半で紹介します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-120">To help the user change location permissions after they've been prompted, we recommend that you provide a link to the location settings as demonstrated later in this topic.</span></span>

### <a name="step-2-register-for-changes-in-geofence-state-and-location-permissions"></a><span data-ttu-id="3cab8-121">手順 2. ジオフェンスの状態変更と位置情報のアクセス許可の変更を登録する</span><span class="sxs-lookup"><span data-stu-id="3cab8-121">Step 2: Register for changes in geofence state and location permissions</span></span>

<span data-ttu-id="3cab8-122">この例では、**switch** ステートメントを (前の例で示した) **accessStatus** と共に使って、ユーザーの位置情報へのアクセス許可が与えられている場合にのみ動作するように指定します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-122">In this example, a **switch** statement is used with **accessStatus** (from the previous example) to act only when access to the user's location is allowed.</span></span> <span data-ttu-id="3cab8-123">ユーザーの位置情報へのアクセスが許可された場合、コードによって現在のジオフェンスにアクセスされ、ジオフェンスの状態変更が登録されます。また、位置情報のアクセス許可の変更も登録されます。</span><span class="sxs-lookup"><span data-stu-id="3cab8-123">If access to the user's location is allowed, the code accesses the current geofences, registers for geofence state changes, and registers for changes in location permissions.</span></span>

<span data-ttu-id="3cab8-124">**ヒント** ジオフェンスを使うときは、Geolocator クラスの StatusChanged イベントではなく、GeofenceMonitor の [**StatusChanged**](https://msdn.microsoft.com/library/windows/apps/dn263646) イベントを使って、位置情報のアクセス許可の変更を監視します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-124">**Tip** When using a geofence, monitor changes in location permissions using the [**StatusChanged**](https://msdn.microsoft.com/library/windows/apps/dn263646) event from the GeofenceMonitor class instead of the StatusChanged event from the Geolocator class.</span></span> <span data-ttu-id="3cab8-125">**Disabled** の [**GeofenceMonitorStatus**](https://msdn.microsoft.com/library/windows/apps/dn263599) は、無効になった [**PositionStatus**](https://msdn.microsoft.com/library/windows/apps/br225599) と同じです。どちらも、ユーザーの位置情報にアクセスするためのアクセス許可がアプリにないことを示します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-125">A [**GeofenceMonitorStatus**](https://msdn.microsoft.com/library/windows/apps/dn263599) of **Disabled** is equivalent to a disabled [**PositionStatus**](https://msdn.microsoft.com/library/windows/apps/br225599) - both indicate that the app does not have permission to access the user's location.</span></span>

```csharp
switch (accessStatus)
{
    case GeolocationAccessStatus.Allowed:
        geofences = GeofenceMonitor.Current.Geofences;

        FillRegisteredGeofenceListBoxWithExistingGeofences();
        FillEventListBoxWithExistingEvents();

        // Register for state change events.
        GeofenceMonitor.Current.GeofenceStateChanged += OnGeofenceStateChanged;
        GeofenceMonitor.Current.StatusChanged += OnGeofenceStatusChanged;
        break;


    case GeolocationAccessStatus.Denied:
        _rootPage.NotifyUser("Access denied.", NotifyType.ErrorMessage);
        break;

    case GeolocationAccessStatus.Unspecified:
        _rootPage.NotifyUser("Unspecified error.", NotifyType.ErrorMessage);
        break;
}
```

<span data-ttu-id="3cab8-126">次に、フォアグラウンド アプリから移動するときに、イベント リスナーの登録を解除します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-126">Then, when navigating away from your foreground app, unregister the event listeners.</span></span>

```csharp
protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
{
    GeofenceMonitor.Current.GeofenceStateChanged -= OnGeofenceStateChanged;
    GeofenceMonitor.Current.StatusChanged -= OnGeofenceStatusChanged;

    base.OnNavigatingFrom(e);
}
```

### <a name="step-3-create-the-geofence"></a><span data-ttu-id="3cab8-127">手順 3. ジオフェンスを作成する</span><span class="sxs-lookup"><span data-stu-id="3cab8-127">Step 3: Create the geofence</span></span>

<span data-ttu-id="3cab8-128">これで、[**Geofence**](https://msdn.microsoft.com/library/windows/apps/dn263587) オブジェクトを定義してセットアップする準備ができました。</span><span class="sxs-lookup"><span data-stu-id="3cab8-128">Now, you are ready to define and set up a [**Geofence**](https://msdn.microsoft.com/library/windows/apps/dn263587) object.</span></span> <span data-ttu-id="3cab8-129">必要に応じて、複数の異なるコンストラクター オーバーロードから選べます。</span><span class="sxs-lookup"><span data-stu-id="3cab8-129">There are several different constructor overloads to choose from, depending on your needs.</span></span> <span data-ttu-id="3cab8-130">最も基本的なジオフェンスのコンストラクターで、次に示すように [**Id**](https://msdn.microsoft.com/library/windows/apps/dn263724) と [**Geoshape**](https://msdn.microsoft.com/library/windows/apps/dn263718) のみを指定します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-130">In the most basic geofence constructor, specify only the [**Id**](https://msdn.microsoft.com/library/windows/apps/dn263724) and the [**Geoshape**](https://msdn.microsoft.com/library/windows/apps/dn263718) as shown here.</span></span>

```csharp
// Set the fence ID.
string fenceId = "fence1";

// Define the fence location and radius.
BasicGeoposition position;
position.Latitude = 47.6510;
position.Longitude = -122.3473;
position.Altitude = 0.0;
double radius = 10; // in meters

// Set a circular region for the geofence.
Geocircle geocircle = new Geocircle(position, radius);

// Create the geofence.
Geofence geofence = new Geofence(fenceId, geocircle);

```

<span data-ttu-id="3cab8-131">他のコンストラクターのいずれかを使用して、ジオフェンスをさらに微調整できます。</span><span class="sxs-lookup"><span data-stu-id="3cab8-131">You can fine-tune your geofence further by using one of the other constructors.</span></span> <span data-ttu-id="3cab8-132">次の例では、ジオフェンスのコンストラクターで次の追加のパラメーターを指定します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-132">In the next example, the geofence constructor specifies these additional parameters:</span></span>

-   <span data-ttu-id="3cab8-133">[**MonitoredStates**](https://msdn.microsoft.com/library/windows/apps/dn263728) - どのジオフェンス イベントで通知を受け取るかを示します。イベントは、定義された領域に入ったとき、定義された領域を離れたとき、ジオフェンスが除去されたときに発生します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-133">[**MonitoredStates**](https://msdn.microsoft.com/library/windows/apps/dn263728) - Indicates what geofence events you want to receive notifications for entering the defined region, leaving the defined region, or removal of the geofence.</span></span>
-   <span data-ttu-id="3cab8-134">[**SingleUse**](https://msdn.microsoft.com/library/windows/apps/dn263732) - ジオフェンスが監視されている状態がすべて満たされるとジオフェンスを除去します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-134">[**SingleUse**](https://msdn.microsoft.com/library/windows/apps/dn263732) - Removes the geofence once all the states the geofence is being monitored for have been met.</span></span>
-   <span data-ttu-id="3cab8-135">[**DwellTime**](https://msdn.microsoft.com/library/windows/apps/dn263703) - 進入または退出イベントがトリガーされる前に、定義された領域の内側または外側にユーザーがどれぐらいとどまる必要があるかを示します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-135">[**DwellTime**](https://msdn.microsoft.com/library/windows/apps/dn263703) - Indicates how long the user must be in or out of the defined area before the enter/exit events are triggered.</span></span>
-   <span data-ttu-id="3cab8-136">[**StartTime**](https://msdn.microsoft.com/library/windows/apps/dn263735) - ジオフェンスの監視を開始する時刻を示します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-136">[**StartTime**](https://msdn.microsoft.com/library/windows/apps/dn263735) - Indicates when to start monitoring the geofence.</span></span>
-   <span data-ttu-id="3cab8-137">[**Duration**](https://msdn.microsoft.com/library/windows/apps/dn263697) - ジオフェンスを監視する期間を示します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-137">[**Duration**](https://msdn.microsoft.com/library/windows/apps/dn263697) - Indicates the period for which to monitor the geofence.</span></span>

```csharp
// Set the fence ID.
string fenceId = "fence2";

// Define the fence location and radius.
BasicGeoposition position;
position.Latitude = 47.6510;
position.Longitude = -122.3473;
position.Altitude = 0.0;
double radius = 10; // in meters

// Set the circular region for geofence.
Geocircle geocircle = new Geocircle(position, radius);

// Remove the geofence after the first trigger.
bool singleUse = true;

// Set the monitored states.
MonitoredGeofenceStates monitoredStates =
                MonitoredGeofenceStates.Entered |
                MonitoredGeofenceStates.Exited |
                MonitoredGeofenceStates.Removed;

// Set how long you need to be in geofence for the enter event to fire.
TimeSpan dwellTime = TimeSpan.FromMinutes(5);

// Set how long the geofence should be active.
TimeSpan duration = TimeSpan.FromDays(1);

// Set up the start time of the geofence.
DateTimeOffset startTime = DateTime.Now;

// Create the geofence.
Geofence geofence = new Geofence(fenceId, geocircle, monitoredStates, singleUse, dwellTime, startTime, duration);
```

<span data-ttu-id="3cab8-138">作成後、新しい [**Geofence**](https://docs.microsoft.com/uwp/api/Windows.Devices.Geolocation.Geofencing.Geofence) を忘れずにモニターに登録してください。</span><span class="sxs-lookup"><span data-stu-id="3cab8-138">After creating, remember to register your new [**Geofence**](https://docs.microsoft.com/uwp/api/Windows.Devices.Geolocation.Geofencing.Geofence) to the monitor.</span></span>

```csharp
// Register the geofence
try {
   GeofenceMonitor.Current.Geofences.Add(geofence);
} catch {
   // Handle failure to add geofence
}
```

### <a name="step-4-handle-changes-in-location-permissions"></a><span data-ttu-id="3cab8-139">手順 4. 位置情報へのアクセス許可の変更を処理する</span><span class="sxs-lookup"><span data-stu-id="3cab8-139">Step 4: Handle changes in location permissions</span></span>

<span data-ttu-id="3cab8-140">[**GeofenceMonitor**](https://msdn.microsoft.com/library/windows/apps/dn263595) オブジェクトは [**StatusChanged**](https://msdn.microsoft.com/library/windows/apps/dn263646) イベントをトリガーして、ユーザーの位置情報設定が変化したことを示します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-140">The [**GeofenceMonitor**](https://msdn.microsoft.com/library/windows/apps/dn263595) object triggers the [**StatusChanged**](https://msdn.microsoft.com/library/windows/apps/dn263646) event to indicate that the user's location settings changed.</span></span> <span data-ttu-id="3cab8-141">このイベントは、引数の **sender.Status** プロパティ ([**GeofenceMonitorStatus**](https://msdn.microsoft.com/library/windows/apps/dn263599) 型) を使って、対応する状態を渡します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-141">That event passes the corresponding status via the argument's **sender.Status** property (of type [**GeofenceMonitorStatus**](https://msdn.microsoft.com/library/windows/apps/dn263599)).</span></span> <span data-ttu-id="3cab8-142">このメソッドは UI スレッドから呼び出されず、[**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) オブジェクトが UI の変更を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-142">Note that this method is not called from the UI thread and the [**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) object invokes the UI changes.</span></span>

```csharp
using Windows.UI.Core;
...
public async void OnGeofenceStatusChanged(GeofenceMonitor sender, object e)
{
   await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
   {
    // Show the location setting message only if the status is disabled.
    LocationDisabledMessage.Visibility = Visibility.Collapsed;

    switch (sender.Status)
    {
     case GeofenceMonitorStatus.Ready:
      _rootPage.NotifyUser("The monitor is ready and active.", NotifyType.StatusMessage);
      break;

     case GeofenceMonitorStatus.Initializing:
      _rootPage.NotifyUser("The monitor is in the process of initializing.", NotifyType.StatusMessage);
      break;

     case GeofenceMonitorStatus.NoData:
      _rootPage.NotifyUser("There is no data on the status of the monitor.", NotifyType.ErrorMessage);
      break;

     case GeofenceMonitorStatus.Disabled:
      _rootPage.NotifyUser("Access to location is denied.", NotifyType.ErrorMessage);

      // Show the message to the user to go to the location settings.
      LocationDisabledMessage.Visibility = Visibility.Visible;
      break;

     case GeofenceMonitorStatus.NotInitialized:
      _rootPage.NotifyUser("The geofence monitor has not been initialized.", NotifyType.StatusMessage);
      break;

     case GeofenceMonitorStatus.NotAvailable:
      _rootPage.NotifyUser("The geofence monitor is not available.", NotifyType.ErrorMessage);
      break;

     default:
      ScenarioOutput_Status.Text = "Unknown";
      _rootPage.NotifyUser(string.Empty, NotifyType.StatusMessage);
      break;
    }
   });
}
```

## <a name="set-up-foreground-notifications"></a><span data-ttu-id="3cab8-143">フォアグラウンド通知のセットアップ</span><span class="sxs-lookup"><span data-stu-id="3cab8-143">Set up foreground notifications</span></span>


<span data-ttu-id="3cab8-144">ジオフェンスを作成した後で、ジオフェンス イベントが発生したときの処理ロジックを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3cab8-144">After your geofences are created, you must add the logic to handle what happens when a geofence event occurs.</span></span> <span data-ttu-id="3cab8-145">セットアップした [**MonitoredStates**](https://msdn.microsoft.com/library/windows/apps/dn263728) に応じて、次の場合にイベントを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="3cab8-145">Depending on the [**MonitoredStates**](https://msdn.microsoft.com/library/windows/apps/dn263728) that you have set up, you may receive an event when:</span></span>

-   <span data-ttu-id="3cab8-146">ユーザーが関心領域に入った。</span><span class="sxs-lookup"><span data-stu-id="3cab8-146">The user enters a region of interest.</span></span>
-   <span data-ttu-id="3cab8-147">ユーザーが関心領域から離れた。</span><span class="sxs-lookup"><span data-stu-id="3cab8-147">The user leaves a region of interest.</span></span>
-   <span data-ttu-id="3cab8-148">ジオフェンスが期限切れになったか、除去された。</span><span class="sxs-lookup"><span data-stu-id="3cab8-148">The geofence has expired or been removed.</span></span> <span data-ttu-id="3cab8-149">除去イベントではバックグラウンド アプリがアクティブ化されないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="3cab8-149">Note that a background app is not activated for a removal event.</span></span>

<span data-ttu-id="3cab8-150">実行中のアプリからイベントを直接リッスンすることも、バックグラウンド タスクの登録を行い、イベントが発生するとバックグラウンド通知を受け取ることもできます。</span><span class="sxs-lookup"><span data-stu-id="3cab8-150">You can listen for events directly from your app when it is running or register for a background task so that you receive a background notification when an event occurs.</span></span>

### <a name="step-1-register-for-geofence-state-change-events"></a><span data-ttu-id="3cab8-151">手順 1. ジオフェンスの状態変更イベントに登録する</span><span class="sxs-lookup"><span data-stu-id="3cab8-151">Step 1: Register for geofence state change events</span></span>

<span data-ttu-id="3cab8-152">アプリでジオフェンスの状態変更についてフォアグラウンド通知を受け取るには、イベント ハンドラーを登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3cab8-152">For your app to receive a foreground notification of a geofence state change, you must register an event handler.</span></span> <span data-ttu-id="3cab8-153">これは一般にジオフェンスの作成時にセットアップします。</span><span class="sxs-lookup"><span data-stu-id="3cab8-153">This is typically set up when you create the geofence.</span></span>

```csharp
private void Initialize()
{
    // Other initialization logic

    GeofenceMonitor.Current.GeofenceStateChanged += OnGeofenceStateChanged;
}

```

### <a name="step-2-implement-the-geofence-event-handler"></a><span data-ttu-id="3cab8-154">手順 2. ジオフェンスのイベント ハンドラーを実装する</span><span class="sxs-lookup"><span data-stu-id="3cab8-154">Step 2: Implement the geofence event handler</span></span>

<span data-ttu-id="3cab8-155">次の手順は、イベント ハンドラーの実装です。</span><span class="sxs-lookup"><span data-stu-id="3cab8-155">The next step is to implement the event handlers.</span></span> <span data-ttu-id="3cab8-156">ここで実行するアクションは、ジオフェンスの利用目的に応じて変わります。</span><span class="sxs-lookup"><span data-stu-id="3cab8-156">The action taken here depends on what your app is using the geofence for.</span></span>

```csharp
public async void OnGeofenceStateChanged(GeofenceMonitor sender, object e)
{
    var reports = sender.ReadReports();

    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
        foreach (GeofenceStateChangeReport report in reports)
        {
            GeofenceState state = report.NewState;

            Geofence geofence = report.Geofence;

            if (state == GeofenceState.Removed)
            {
                // Remove the geofence from the geofences collection.
                GeofenceMonitor.Current.Geofences.Remove(geofence);
            }
            else if (state == GeofenceState.Entered)
            {
                // Your app takes action based on the entered event.

                // NOTE: You might want to write your app to take a particular
                // action based on whether the app has internet connectivity.

            }
            else if (state == GeofenceState.Exited)
            {
                // Your app takes action based on the exited event.

                // NOTE: You might want to write your app to take a particular
                // action based on whether the app has internet connectivity.

            }
        }
    });
}



```

## <a name="set-up-background-notifications"></a><span data-ttu-id="3cab8-157">バックグラウンド通知のセットアップ</span><span class="sxs-lookup"><span data-stu-id="3cab8-157">Set up background notifications</span></span>


<span data-ttu-id="3cab8-158">ジオフェンスを作成した後で、ジオフェンス イベントが発生したときの処理ロジックを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3cab8-158">After your geofences are created, you must add the logic to handle what happens when a geofence event occurs.</span></span> <span data-ttu-id="3cab8-159">セットアップした [**MonitoredStates**](https://msdn.microsoft.com/library/windows/apps/dn263728) に応じて、次の場合にイベントを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="3cab8-159">Depending on the [**MonitoredStates**](https://msdn.microsoft.com/library/windows/apps/dn263728) that you have set up, you may receive an event when:</span></span>

-   <span data-ttu-id="3cab8-160">ユーザーが関心領域に入った。</span><span class="sxs-lookup"><span data-stu-id="3cab8-160">The user enters a region of interest.</span></span>
-   <span data-ttu-id="3cab8-161">ユーザーが関心領域から離れた。</span><span class="sxs-lookup"><span data-stu-id="3cab8-161">The user leaves a region of interest.</span></span>
-   <span data-ttu-id="3cab8-162">ジオフェンスが期限切れになったか、除去された。</span><span class="sxs-lookup"><span data-stu-id="3cab8-162">The geofence has expired or been removed.</span></span> <span data-ttu-id="3cab8-163">除去イベントではバックグラウンド アプリがアクティブ化されないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="3cab8-163">Note that a background app is not activated for a removal event.</span></span>

<span data-ttu-id="3cab8-164">バックグラウンドでのジオフェンス イベントをリッスンするには</span><span class="sxs-lookup"><span data-stu-id="3cab8-164">To listen for a geofence event in the background</span></span>

-   <span data-ttu-id="3cab8-165">アプリのマニフェストでバックグラウンド タスクを宣言します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-165">Declare the background task in your app’s manifest.</span></span>
-   <span data-ttu-id="3cab8-166">アプリでバックグラウンド タスクを登録します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-166">Register the background task in your app.</span></span> <span data-ttu-id="3cab8-167">クラウド サービスへのアクセスなど、インターネット アクセスがアプリに必要な場合は、イベントがトリガーされたときにそのためのフラグを設定できます。</span><span class="sxs-lookup"><span data-stu-id="3cab8-167">If your app needs internet access, say for accessing a cloud service, you can set a flag for that when the event is triggered.</span></span> <span data-ttu-id="3cab8-168">イベントがトリガーされたときにユーザーがその場にいて、ユーザーに通知が確実に届くようにするために、フラグを設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="3cab8-168">You can also set a flag to make sure that the user is present when the event is triggered so that you are sure that the user gets notified.</span></span>
-   <span data-ttu-id="3cab8-169">アプリをフォアグラウンドで実行中に、位置情報のアクセス許可をアプリに与えるようユーザーに求めます。</span><span class="sxs-lookup"><span data-stu-id="3cab8-169">While your app is running in the foreground, prompt the user to grant your app location permissions.</span></span>

### <a name="step-1-register-for-geofence-state-change-events"></a><span data-ttu-id="3cab8-170">手順 1. ジオフェンスの状態変更イベントに登録する</span><span class="sxs-lookup"><span data-stu-id="3cab8-170">Step 1: Register for geofence state change events</span></span>

<span data-ttu-id="3cab8-171">アプリのマニフェストの **[宣言]** タブで、位置情報バックグラウンド タスクの宣言を追加します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-171">In your app's manifest, under the **Declarations** tab, add a declaration for a location background task.</span></span> <span data-ttu-id="3cab8-172">そのためには、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="3cab8-172">To do this:</span></span>

-   <span data-ttu-id="3cab8-173">タイプが **[バックグラウンド タスク]** の宣言を追加します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-173">Add a declaration of type **Background Tasks**.</span></span>
-   <span data-ttu-id="3cab8-174">プロパティのタスク タイプを **[位置情報]** に設定します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-174">Set a property task type of **Location**.</span></span>
-   <span data-ttu-id="3cab8-175">イベントがトリガーされたときに呼び出すアプリのエントリ ポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-175">Set an entry point into your app to call when the event is triggered.</span></span>

### <a name="step-2-register-the-background-task"></a><span data-ttu-id="3cab8-176">手順 2. バックグラウンド タスクを登録する</span><span class="sxs-lookup"><span data-stu-id="3cab8-176">Step 2: Register the background task</span></span>

<span data-ttu-id="3cab8-177">この手順のコードでは、ジオフェンス バックグラウンド タスクを登録しています。</span><span class="sxs-lookup"><span data-stu-id="3cab8-177">The code in this step registers the geofencing background task.</span></span> <span data-ttu-id="3cab8-178">ジオフェンスを作成したときに、位置情報のアクセス許可を確認しました。</span><span class="sxs-lookup"><span data-stu-id="3cab8-178">Recall that when the geofence was created, we checked for location permissions.</span></span>

```csharp
async private void RegisterBackgroundTask(object sender, RoutedEventArgs e)
{
    // Get permission for a background task from the user. If the user has already answered once,
    // this does nothing and the user must manually update their preference via PC Settings.
    BackgroundAccessStatus backgroundAccessStatus = await BackgroundExecutionManager.RequestAccessAsync();

    // Regardless of the answer, register the background task. Note that the user can use
    // the Settings app to prevent your app from running background tasks.
    // Create a new background task builder.
    BackgroundTaskBuilder geofenceTaskBuilder = new BackgroundTaskBuilder();

    geofenceTaskBuilder.Name = SampleBackgroundTaskName;
    geofenceTaskBuilder.TaskEntryPoint = SampleBackgroundTaskEntryPoint;

    // Create a new location trigger.
    var trigger = new LocationTrigger(LocationTriggerType.Geofence);

    // Associate the location trigger with the background task builder.
    geofenceTaskBuilder.SetTrigger(trigger);

    // If it is important that there is user presence and/or
    // internet connection when OnCompleted is called
    // the following could be called before calling Register().
    // SystemCondition condition = new SystemCondition(SystemConditionType.UserPresent | SystemConditionType.InternetAvailable);
    // geofenceTaskBuilder.AddCondition(condition);

    // Register the background task.
    geofenceTask = geofenceTaskBuilder.Register();

    // Associate an event handler with the new background task.
    geofenceTask.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted);

    BackgroundTaskState.RegisterBackgroundTask(BackgroundTaskState.LocationTriggerBackgroundTaskName);

    switch (backgroundAccessStatus)
    {
    case BackgroundAccessStatus.Unspecified:
    case BackgroundAccessStatus.Denied:
        rootPage.NotifyUser("This app is not allowed to run in the background.", NotifyType.ErrorMessage);
        break;

    }
}


```

### <a name="step-3-handling-the-background-notification"></a><span data-ttu-id="3cab8-179">手順 3. バックグラウンド通知を処理する</span><span class="sxs-lookup"><span data-stu-id="3cab8-179">Step 3: Handling the background notification</span></span>

<span data-ttu-id="3cab8-180">ユーザーに通知するためにとるアクションは、アプリの用途に応じて変わりますが、トースト通知の表示、サウンドの再生、ライブ タイルの更新などが考えられます。</span><span class="sxs-lookup"><span data-stu-id="3cab8-180">The action that you take to notify the user depends on what your app does, but you can display a toast notification, play an audio sound, or update a live tile.</span></span> <span data-ttu-id="3cab8-181">この手順のコードは通知を処理します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-181">The code in this step handles the notification.</span></span>

```csharp
async private void OnCompleted(IBackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs e)
{
    if (sender != null)
    {
        // Update the UI with progress reported by the background task.
        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            try
            {
                // If the background task threw an exception, display the exception in
                // the error text box.
                e.CheckResult();

                // Update the UI with the completion status of the background task.
                // The Run method of the background task sets the LocalSettings.
                var settings = ApplicationData.Current.LocalSettings;

                // Get the status.
                if (settings.Values.ContainsKey("Status"))
                {
                    rootPage.NotifyUser(settings.Values["Status"].ToString(), NotifyType.StatusMessage);
                }

                // Do your app work here.

            }
            catch (Exception ex)
            {
                // The background task had an error.
                rootPage.NotifyUser(ex.ToString(), NotifyType.ErrorMessage);
            }
        });
    }
}


```

## <a name="change-the-privacy-settings"></a><span data-ttu-id="3cab8-182">プライバシー設定の変更</span><span class="sxs-lookup"><span data-stu-id="3cab8-182">Change the privacy settings</span></span>


<span data-ttu-id="3cab8-183">位置情報のプライバシー設定でアプリにユーザーの位置情報へのアクセス許可を与えていない場合は、**設定**アプリの **[位置情報のプライバシー設定]** へのリンクを用意することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3cab8-183">If the location privacy settings don't allow your app to access the user's location, we recommend that you provide a convenient link to the **location privacy settings** in the **Settings** app.</span></span> <span data-ttu-id="3cab8-184">この例では、ハイパーリンク コントロールを使って、`ms-settings:privacy-location` という URI に移動します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-184">In this example, a Hyperlink control is used navigate to the `ms-settings:privacy-location` URI.</span></span>

```xml
<!--Set Visibility to Visible when access to the user's location is denied. -->  
<TextBlock x:Name="LocationDisabledMessage" FontStyle="Italic"
                 Visibility="Collapsed" Margin="0,15,0,0" TextWrapping="Wrap" >
          <Run Text="This app is not able to access Location. Go to " />
              <Hyperlink NavigateUri="ms-settings:privacy-location">
                  <Run Text="Settings" />
              </Hyperlink>
          <Run Text=" to check the location privacy settings."/>
</TextBlock>
```

<span data-ttu-id="3cab8-185">また、アプリで [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) メソッドを呼び出し、コードで**設定**アプリを起動することもできます。</span><span class="sxs-lookup"><span data-stu-id="3cab8-185">Alternatively, your app can call the [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) method to launch the **Settings** app from code.</span></span> <span data-ttu-id="3cab8-186">詳しくは、「[Windows 設定アプリの起動](https://msdn.microsoft.com/library/windows/apps/mt228342)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3cab8-186">For more info, see [Launch the Windows Settings app](https://msdn.microsoft.com/library/windows/apps/mt228342).</span></span>

```csharp
using Windows.System;
...
bool result = await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-location"));
```

## <a name="test-and-debug-your-app"></a><span data-ttu-id="3cab8-187">アプリのテストとデバッグ</span><span class="sxs-lookup"><span data-stu-id="3cab8-187">Test and debug your app</span></span>


<span data-ttu-id="3cab8-188">ジオフェンス アプリはデバイスの位置に依存しているため、そのテストとデバッグは容易ではありません。</span><span class="sxs-lookup"><span data-stu-id="3cab8-188">Testing and debugging geofencing apps can be a challenge because they depend on a device's location.</span></span> <span data-ttu-id="3cab8-189">ここでは、フォアグラウンドとバックグラウンドのジオフェンスの両方をテストするいくつかの方法について概略を示します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-189">Here, we outline several methods for testing both foreground and background geofences.</span></span>

**<span data-ttu-id="3cab8-190">ジオフェンス アプリをデバッグするには</span><span class="sxs-lookup"><span data-stu-id="3cab8-190">To debug a geofencing app</span></span>**

1.  <span data-ttu-id="3cab8-191">デバイスを新しい位置に物理的に移動します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-191">Physically move the device to new locations.</span></span>
2.  <span data-ttu-id="3cab8-192">現在の物理的な位置を含むジオフェンス領域を作成して、ジオフェンスへの進入をテストします。ジオフェンスの内部に既にいるため、"ジオフェンス進入" イベントが直ちにトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="3cab8-192">Test entering a geofence by creating a geofence region that includes your current physical location, so you're already inside the geofence and the "geofence entered" event is triggered immediately.</span></span>
3.  <span data-ttu-id="3cab8-193">Microsoft Visual Studio エミュレーターを使って、デバイスの位置をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="3cab8-193">Use the Microsoft Visual Studio emulator to simulate locations for the device.</span></span>

### <a name="test-and-debug-a-geofencing-app-that-is-running-in-the-foreground"></a><span data-ttu-id="3cab8-194">フォアグラウンドで実行中のジオフェンス アプリのテストとデバッグ</span><span class="sxs-lookup"><span data-stu-id="3cab8-194">Test and debug a geofencing app that is running in the foreground</span></span>

**<span data-ttu-id="3cab8-195">フォアグラウンドで実行中のジオフェンス アプリをテストするには</span><span class="sxs-lookup"><span data-stu-id="3cab8-195">To test your geofencing app that is running the foreground</span></span>**

1.  <span data-ttu-id="3cab8-196">Visual Studio でアプリをビルドします。</span><span class="sxs-lookup"><span data-stu-id="3cab8-196">Build your app in Visual Studio.</span></span>
2.  <span data-ttu-id="3cab8-197">Visual Studio エミュレーターでアプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-197">Launch your app in the Visual Studio emulator.</span></span>
3.  <span data-ttu-id="3cab8-198">これらのツールを使って、ジオフェンス領域の内外のさまざまな位置をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="3cab8-198">Use these tools to simulate various locations inside and outside of your geofence region.</span></span> <span data-ttu-id="3cab8-199">[**DwellTime**](https://msdn.microsoft.com/library/windows/apps/dn263703) プロパティで指定した時間が経過してイベントがトリガーされるまで、十分な時間、待ってください。</span><span class="sxs-lookup"><span data-stu-id="3cab8-199">Be sure to wait long enough past the time specified by the [**DwellTime**](https://msdn.microsoft.com/library/windows/apps/dn263703) property to trigger the event.</span></span> <span data-ttu-id="3cab8-200">アプリに位置情報のアクセス許可を与えるというメッセージに同意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3cab8-200">Note that you must accept the prompt to enable location permissions for the app.</span></span> <span data-ttu-id="3cab8-201">位置のシミュレーションについて詳しくは、「シミュレーターでの Windows ストア アプリの実行」の「[デバイスのシミュレートされる地理上の位置を設定する](http://go.microsoft.com/fwlink/p/?LinkID=325245)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3cab8-201">For more info about simulating locations, see [Set the simulated geolocation of the device](http://go.microsoft.com/fwlink/p/?LinkID=325245).</span></span>
4.  <span data-ttu-id="3cab8-202">また、さまざまな速度での検出に必要なおおよそのジオフェンスのサイズとドウェル時間を見積もるためにエミュレーターを使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="3cab8-202">You can also use the emulator to estimate the size of fences and dwell times approximately needed to be detected at different speeds.</span></span>

### <a name="test-and-debug-a-geofencing-app-that-is-running-in-the-background"></a><span data-ttu-id="3cab8-203">バックグラウンドで実行中のジオフェンス アプリのテストとデバッグ</span><span class="sxs-lookup"><span data-stu-id="3cab8-203">Test and debug a geofencing app that is running in the background</span></span>

**<span data-ttu-id="3cab8-204">バックグラウンドで実行中のジオフェンス アプリをテストするには</span><span class="sxs-lookup"><span data-stu-id="3cab8-204">To test your geofencing app that is running the background</span></span>**

1.  <span data-ttu-id="3cab8-205">Visual Studio でアプリをビルドします。</span><span class="sxs-lookup"><span data-stu-id="3cab8-205">Build your app in Visual Studio.</span></span> <span data-ttu-id="3cab8-206">アプリでバックグラウンド タスクの種類を **Location** に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3cab8-206">Note that your app should set the **Location** background task type.</span></span>
2.  <span data-ttu-id="3cab8-207">最初に、アプリをローカルに展開します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-207">Deploy the app locally first.</span></span>
3.  <span data-ttu-id="3cab8-208">ローカルで実行中のアプリを閉じます。</span><span class="sxs-lookup"><span data-stu-id="3cab8-208">Close your app that is running locally.</span></span>
4.  <span data-ttu-id="3cab8-209">Visual Studio エミュレーターでアプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-209">Launch your app in the Visual Studio emulator.</span></span> <span data-ttu-id="3cab8-210">バックグラウンドのジオフェンス シミュレーションは、エミュレーター内では一度に 1 つのアプリでしかサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="3cab8-210">Note that background geofencing simulation is supported on only one app at a time within the emulator.</span></span> <span data-ttu-id="3cab8-211">エミュレーター内で複数のジオフェンス アプリを起動しないでください。</span><span class="sxs-lookup"><span data-stu-id="3cab8-211">Do not launch multiple geofencing apps within the emulator.</span></span>
5.  <span data-ttu-id="3cab8-212">エミュレーターから、ジオフェンス領域の内外のさまざまな位置をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="3cab8-212">From the emulator, simulate various locations inside and outside of your geofence region.</span></span> <span data-ttu-id="3cab8-213">[**DwellTime**](https://msdn.microsoft.com/library/windows/apps/dn263703) の時間が経過してイベントがトリガーされるまで、十分な時間、待ってください。</span><span class="sxs-lookup"><span data-stu-id="3cab8-213">Be sure to wait long enough past the [**DwellTime**](https://msdn.microsoft.com/library/windows/apps/dn263703) to trigger the event.</span></span> <span data-ttu-id="3cab8-214">アプリに位置情報のアクセス許可を与えるというメッセージに同意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3cab8-214">Note that you must accept the prompt to enable location permissions for the app.</span></span>
6.  <span data-ttu-id="3cab8-215">Visual Studio を使って、位置情報バックグラウンド タスクをトリガーします。</span><span class="sxs-lookup"><span data-stu-id="3cab8-215">Use Visual Studio to trigger the location background task.</span></span> <span data-ttu-id="3cab8-216">Visual Studio でのバックグラウンド タスクのトリガーについて詳しくは、「[Visual Studio で Windows ストア アプリの中断イベント、再開イベント、およびバックグラウンド イベントをトリガーする方法](http://go.microsoft.com/fwlink/p/?LinkID=325378)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3cab8-216">For more info about triggering background tasks in Visual Studio, see [How to trigger background tasks](http://go.microsoft.com/fwlink/p/?LinkID=325378).</span></span>

## <a name="troubleshoot-your-app"></a><span data-ttu-id="3cab8-217">アプリのトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="3cab8-217">Troubleshoot your app</span></span>


<span data-ttu-id="3cab8-218">アプリが位置情報にアクセスする前に、デバイスで **[位置情報]** を有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3cab8-218">Before your app can access location, **Location** must be enabled on the device.</span></span> <span data-ttu-id="3cab8-219">**設定**アプリで、次の**位置情報に関するプライバシー設定**がオンになっていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="3cab8-219">In the **Settings** app, check that the following **location privacy settings** are turned on:</span></span>

-   <span data-ttu-id="3cab8-220">**このデバイス] の位置情報\*\*\*\*オン (windows 10 Mobile では適用されません)**</span><span class="sxs-lookup"><span data-stu-id="3cab8-220">**Location for this device...** is turned **on** (not applicable in Windows10 Mobile)</span></span>
-   <span data-ttu-id="3cab8-221">位置情報サービス設定の **[位置情報]** が **オン** になっている</span><span class="sxs-lookup"><span data-stu-id="3cab8-221">The location services setting, **Location**, is turned **on**</span></span>
-   <span data-ttu-id="3cab8-222">**[位置情報を使うことができるアプリを選ぶ]** で、アプリが **オン** になっている</span><span class="sxs-lookup"><span data-stu-id="3cab8-222">Under **Choose apps that can use your location**, your app is set to **on**</span></span>

## <a name="related-topics"></a><span data-ttu-id="3cab8-223">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3cab8-223">Related topics</span></span>

* [<span data-ttu-id="3cab8-224">UWP の位置情報のサンプル</span><span class="sxs-lookup"><span data-stu-id="3cab8-224">UWP geolocation sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=533278)
* [<span data-ttu-id="3cab8-225">ジオフェンスの設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="3cab8-225">Design guidelines for geofencing</span></span>](https://msdn.microsoft.com/library/windows/apps/dn631756)
* [<span data-ttu-id="3cab8-226">位置認識アプリの設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="3cab8-226">Design guidelines for location-aware apps</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465148)
