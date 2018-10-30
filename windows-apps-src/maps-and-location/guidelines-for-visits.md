---
author: PatrickFarley
Description: Learn how to use the powerful Visits Tracking feature for more practical location tracking.
title: ビジット追跡の使用ガイドライン
ms.assetid: 0c101684-48a9-4592-9ed5-6c20f3b830f2
ms.author: pafarley
ms.date: 05/18/2017
ms.topic: article
keywords: windows 10, uwp, マップ, 位置情報, geovisit, ジオビジット
ms.localizationpriority: medium
ms.openlocfilehash: 3a78b2689a10dff50696e5e65cc44f79a6f1ea7d
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5762953"
---
# <a name="guidelines-for-using-visits-tracking"></a><span data-ttu-id="ed706-103">ビジット追跡の使用ガイドライン</span><span class="sxs-lookup"><span data-stu-id="ed706-103">Guidelines for using Visits tracking</span></span>

<span data-ttu-id="ed706-104">ビジット機能を使用すると、位置追跡のプロセスを合理化し、多くのアプリ実用的な用途について効率化を図ることができます。</span><span class="sxs-lookup"><span data-stu-id="ed706-104">The Visits feature streamlines the process of location tracking to make it more efficient for the practical purposes of many apps.</span></span> <span data-ttu-id="ed706-105">ビジットとは、ユーザーが進入/退出する、意味のある地理的な領域を指します。</span><span class="sxs-lookup"><span data-stu-id="ed706-105">A Visit is defined as a significant geographical area that the user enters and exits.</span></span> <span data-ttu-id="ed706-106">ビジットは、ユーザーが対象領域に進入したときまたは退出したときのみにアプリが通知を受信できるという点で[ジオフェンス](guidelines-for-geofencing.md)に似ています。これにより、バッテリーの消耗につながる継続的な位置追跡が不要になります。</span><span class="sxs-lookup"><span data-stu-id="ed706-106">Visits are similar to [geofences](guidelines-for-geofencing.md) in that they allow the app to be notified only when the user enters or exits certain areas of interest, eliminating the need for continual location tracking which can be a drain on battery life.</span></span> <span data-ttu-id="ed706-107">ただしジオフェンスの場合とは異なり、ビジットの領域はプラットフォーム レベルで動的に識別されるため、個々のアプリで明示的に定義する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="ed706-107">However, unlike geofences, Visit areas are dynamically identified at the platform level and do not need to be defined explicitly by individual apps.</span></span> <span data-ttu-id="ed706-108">また、アプリで追跡する対象ビジットの選択は、個々の場所のサブスクリプションではなく、単一の粒度設定によって処理されます。</span><span class="sxs-lookup"><span data-stu-id="ed706-108">Also, the selection of which Visits an app will track is handled by a single granularity setting, rather than by subscribing to individual places.</span></span>

## <a name="preliminary-setup"></a><span data-ttu-id="ed706-109">準備段階のセットアップ</span><span class="sxs-lookup"><span data-stu-id="ed706-109">Preliminary setup</span></span>

<span data-ttu-id="ed706-110">先へ進む前に、アプリがデバイスの位置情報にアクセスできることを確認します。</span><span class="sxs-lookup"><span data-stu-id="ed706-110">Before going further, make sure your app is capable of accessing the device's location.</span></span> <span data-ttu-id="ed706-111">ユーザーからアプリに位置情報へのアクセスが許可されるように、マニフェスト内に `Location` 機能を宣言し、**[Geolocator.RequestAccessAsync](https://docs.microsoft.com/uwp/api/Windows.Devices.Geolocation.Geolocator.RequestAccessAsync)** メソッドを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed706-111">You will need to declare the `Location` capability in the manifest and call the **[Geolocator.RequestAccessAsync](https://docs.microsoft.com/uwp/api/Windows.Devices.Geolocation.Geolocator.RequestAccessAsync)** method to ensure that users give the app location permissions.</span></span> <span data-ttu-id="ed706-112">方法については、「[ユーザーの位置情報の取得](get-location.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed706-112">See [Get the user's location](get-location.md) for more information on how to do this.</span></span> 

<span data-ttu-id="ed706-113">クラスには、必ず `Geolocation` 名前空間を追加してください。</span><span class="sxs-lookup"><span data-stu-id="ed706-113">Remember to add the `Geolocation` namespace to your class.</span></span> <span data-ttu-id="ed706-114">このガイドに記載されているコード スニペットを使用するには、この処理が必要になります。</span><span class="sxs-lookup"><span data-stu-id="ed706-114">This will be needed for all of the code snippets in this guide to work.</span></span>

```csharp
using Windows.Devices.Geolocation;
```

## <a name="check-the-latest-visit"></a><span data-ttu-id="ed706-115">最新のビジットを確認する</span><span class="sxs-lookup"><span data-stu-id="ed706-115">Check the latest Visit</span></span>
<span data-ttu-id="ed706-116">ビジット追跡機能を使用する最も簡単な方法は、ビジットに関して認識された最新の状態変化を取得することです。</span><span class="sxs-lookup"><span data-stu-id="ed706-116">The simplest way to use the Visits tracking feature is to retrieve the last known Visit-related state change.</span></span> <span data-ttu-id="ed706-117">状態変化はプラットフォームによってログ記録されるイベントであり、意味のある場所に対してユーザーが進入または退出したこと、前回のレポート以降に重要な移動が発生したこと、またはユーザーの位置状態が失われたことを示します (**[VisitStateChange](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.visitstatechange)** 列挙をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="ed706-117">A state change is a platform-logged event in which either the user enters/exits a location of significance, there is significant movement since the last report, or the user's location is lost (see the **[VisitStateChange](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.visitstatechange)** enum).</span></span> <span data-ttu-id="ed706-118">状態変化は **[Geovisit](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geovisit)** インスタンスで表されます。</span><span class="sxs-lookup"><span data-stu-id="ed706-118">State changes are represented by **[Geovisit](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geovisit)** instances.</span></span> <span data-ttu-id="ed706-119">**Geovisit** インスタンスを取得して最後に記録された状態変化を調べるには、**[GeovisitMonitor](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geovisitmonitor)** クラスに用意されている指定のメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="ed706-119">To retrieve the **Geovisit** instance for the last recorded state change, simply use the designated method in the **[GeovisitMonitor](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geovisitmonitor)** class.</span></span>

> [!NOTE]
> <span data-ttu-id="ed706-120">最後にログ記録されたビジットを確認しても、システムがビジットを現在追跡中であることの保証にはなりません。</span><span class="sxs-lookup"><span data-stu-id="ed706-120">Checking the last logged Visit does not guarantee that Visits are currently being tracked by the system.</span></span> <span data-ttu-id="ed706-121">ビジットの発生を追跡するには、フォアグラウンドで監視するか、バックグラウンド追跡に登録する必要があります (以下のセクションをご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="ed706-121">In order to track Visits as they happen, you must either be monitoring them in the foreground or register for background tracking (see sections below).</span></span>

```csharp
private async void GetLatestStateChange() {
    // retrieve the Geovisit instance
    Geovisit latestVisit = await GeovisitMonitor.GetLastReportAsync();

    // Using the properties of "latestVisit", parse out the time that the state 
    // change was recorded, the device's location when the change was recorded,
    // and the type of state change.
}
```

### <a name="parse-a-geovisit-instance-optional"></a><span data-ttu-id="ed706-122">Geovisit インスタンスを解析する (オプション)</span><span class="sxs-lookup"><span data-stu-id="ed706-122">Parse a Geovisit instance (optional)</span></span>
<span data-ttu-id="ed706-123">次のメソッドでは、**Geovisit** インスタンスに格納されたすべての情報を、簡単に読み取ることのできる文字列に変換します。</span><span class="sxs-lookup"><span data-stu-id="ed706-123">The following method converts all of the information stored in a **Geovisit** instance into an easily readable string.</span></span> <span data-ttu-id="ed706-124">このメソッドは、このガイド内のどのシナリオでも使用でき、レポート対象のビジットに関するフィードバック提供に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="ed706-124">It can be used in any of the scenarios in this guide to help provide feedback for the Visits being reported.</span></span>

```csharp
private string ParseGeovisit(Geovisit visit){
    string visitString = null;

    // Use a DateTimeFormatter object to process the timestamp. The following
    // format configuration will give an intuitive representation of the date/time
    Windows.Globalization.DateTimeFormatting.DateTimeFormatter formatterLongTime;
    
    formatterLongTime = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter(
        "{hour.integer}:{minute.integer(2)}:{second.integer(2)}", new[] { "en-US" }, "US", 
        Windows.Globalization.CalendarIdentifiers.Gregorian, 
        Windows.Globalization.ClockIdentifiers.TwentyFourHour);
    
    // use this formatter to convert the timestamp to a string, and add to "visitString"
    visitString = formatterLongTime.Format(visit.Timestamp);

    // Next, add on the state change type value
    visitString += " " + visit.StateChange.ToString();

    // Next, add the position information (if any is provided; this will be null if 
    // the reported event was "TrackingLost")
    if (visit.Position != null) {
        visitString += " (" +
        visit.Position.Coordinate.Point.Position.Latitude.ToString() + "," +
        visit.Position.Coordinate.Point.Position.Longitude.ToString() + 
        ")";
    }

    return visitString;
}
```

## <a name="monitor-visits-in-the-foreground"></a><span data-ttu-id="ed706-125">フォアグラウンドでビジットを監視する</span><span class="sxs-lookup"><span data-stu-id="ed706-125">Monitor Visits in the foreground</span></span>

<span data-ttu-id="ed706-126">前のセクションで使用した **GeovisitMonitor** クラスでは、一定時間内の状態変化をリッスンするシナリオも処理できます。</span><span class="sxs-lookup"><span data-stu-id="ed706-126">The **GeovisitMonitor** class used in the previous section also handles the scenario of listening for state changes over a period of time.</span></span> <span data-ttu-id="ed706-127">これを行うには、クラスをインスタンス化し、イベント用のハンドラー メソッドを登録して、`Start` メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ed706-127">You can do this by instantiating this class, registering a handler method for its event, and calling the `Start` method.</span></span>

```csharp
// this GeovisitMonitor instance will belong to the class scope
GeovisitMonitor monitor;

public void RegisterForVisits() {

    // Create and initialize a new monitor instance.
    monitor = new GeovisitMonitor();
    
    // Attach a handler to receive state change notifications.
    monitor.VisitStateChanged += OnVisitStateChanged;
    
    // Calling the start method will start Visits tracking for a specified scope:
    // For higher granularity such as venue/building level changes, choose Venue.
    // For lower granularity in the range of zipcode level changes, choose City.
    monitor.Start(VisitMonitoringScope.Venue);
}
```

<span data-ttu-id="ed706-128">この例の `OnVisitStateChanged` メソッドは、受け取ったビジット レポートを処理します。</span><span class="sxs-lookup"><span data-stu-id="ed706-128">In this example, the `OnVisitStateChanged` method will handle incoming Visit reports.</span></span> <span data-ttu-id="ed706-129">対応する **Geovisit** インスタンスは、イベント パラメーターを介して渡されます。</span><span class="sxs-lookup"><span data-stu-id="ed706-129">The corresponding **Geovisit** instance is passed in through the event parameter.</span></span>

```csharp
private void OnVisitStateChanged(GeoVisitWatcher sender, GeoVisitStateChangedEventArgs args) {
    Geovisit visit = args.Visit;
    
    // Using the properties of "visit", parse out the time that the state 
    // change was recorded, the device's location when the change was recorded,
    // and the type of state change.
}
```
<span data-ttu-id="ed706-130">アプリがビジット関連の状態変化の監視を終了するときには、監視を停止し、イベント ハンドラーの登録を解除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed706-130">When the app is finished monitoring for Visit-related state changes, it should stop the monitor and unregister the event handler(s).</span></span> <span data-ttu-id="ed706-131">これは、アプリが中断したときや終了したときにも実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed706-131">This should also be done whenever the app is suspended or closed.</span></span>

```csharp
public void UnregisterFromVisits() {
    
    // Stop the monitor to stop tracking Visits. Otherwise, tracking will
    // continue until the monitor instance is destroyed.
    monitor.Stop();
    
    // Remove the handler to stop receiving state change events.
    monitor.VisitStateChanged -= OnVisitStateChanged;
}
```

## <a name="monitor-visits-in-the-background"></a><span data-ttu-id="ed706-132">バックグラウンドでビジットを監視する</span><span class="sxs-lookup"><span data-stu-id="ed706-132">Monitor Visits in the background</span></span>

<span data-ttu-id="ed706-133">アプリが開いていなくてもビジット関連のアクティビティをデバイスで処理できるように、ビジットの監視をバックグラウンド タスクに実装することもできます。</span><span class="sxs-lookup"><span data-stu-id="ed706-133">You can also implement Visit monitoring in a background task, so that Visit-related activity can be handled on the device even when your app isn't open.</span></span> <span data-ttu-id="ed706-134">これは、汎用性および省電力という点で推奨される方法です。</span><span class="sxs-lookup"><span data-stu-id="ed706-134">This is the recommended method, as it is more versatile and energy-efficient.</span></span> 

<span data-ttu-id="ed706-135">このガイドでは、「[アウトプロセス バックグラウンド タスクの作成と登録](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)」のモデル (メイン アプリケーションのファイルを 1 つのプロジェクトにまとめ、バックグラウンド タスクのファイルは同じソリューション内の別プロジェクトにまとめる) を使用します。</span><span class="sxs-lookup"><span data-stu-id="ed706-135">This guide will use the model in [Create and register an out-of-process background task](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task), in which the main application files live in one project and the background task file lives in a separate project in the same solution.</span></span> <span data-ttu-id="ed706-136">バックグラウンド タスクを初めて実装する場合、最初のうちはガイダンスに従い、下に示すように必要な置き換えを行ってビジット処理のバックグラウンド タスクを作成することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ed706-136">If you are new to implementing background tasks, it is recommended that you follow that guidance primarily, making the necessary substitutions below to create a Visit-handling background task.</span></span>

> [!NOTE]
> <span data-ttu-id="ed706-137">以下のスニペットでは、わかりやすくするために、エラー処理やローカル ストレージなどいくつかの重要な機能が省略されています。</span><span class="sxs-lookup"><span data-stu-id="ed706-137">In the following snippets, some important functionality such as error handling and local storage is absent for the sake of simplicity.</span></span> <span data-ttu-id="ed706-138">バックグラウンドでのビジット処理の堅牢な実装については、[サンプル アプリ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Geolocation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed706-138">For a robust implementation of background Visits handling, see the [sample app](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Geolocation).</span></span>


<span data-ttu-id="ed706-139">まず、アプリでバックグラウンド タスクのアクセス許可が宣言されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="ed706-139">First, make sure your app has declared background task permissions.</span></span> <span data-ttu-id="ed706-140">*Package.appxmanifest* ファイルの `Application/Extensions` 要素に、以下の拡張機能を追加します (`Extensions` 要素がなければ追加します)。</span><span class="sxs-lookup"><span data-stu-id="ed706-140">In the `Application/Extensions` element of your *Package.appxmanifest* file, add the following extension (add an `Extensions` element if one does not already exist).</span></span>

```xml
<Extension Category="windows.backgroundTasks" EntryPoint="Tasks.VisitBackgroundTask">
    <BackgroundTasks>
        <Task Type="location" />
    </BackgroundTasks>
</Extension>
```

<span data-ttu-id="ed706-141">次に、バックグラウンド タスク クラスの定義部分に、以下のコードに貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="ed706-141">Next, in the definition of the background task class, paste in the following code.</span></span> <span data-ttu-id="ed706-142">このバック グラウンド タスクの `Run` メソッドは、トリガーの詳細情報 (ビジットの情報を含む) を別のメソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="ed706-142">The `Run` method of this background task will simply pass the trigger details (which contain the Visits information) into a separate method.</span></span>

```csharp
using Windows.ApplicationModel.Background;

namespace Tasks {
    
    public sealed class VisitBackgroundTask : IBackgroundTask {
        
        public void Run(IBackgroundTaskInstance taskInstance) {
            
            // get a deferral
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();
            
            // this task's trigger will be a Geovisit trigger
            GeovisitTriggerDetails triggerDetails = taskInstance.TriggerDetails as GeovisitTriggerDetails;

            // Handle Visit reports
            GetVisitReports(triggerDetails);         

            finally {
                deferral.Complete();
            }
        }        
    }
}
```

<span data-ttu-id="ed706-143">同じクラス内に、`GetVisitReports` メソッドを定義します。</span><span class="sxs-lookup"><span data-stu-id="ed706-143">Define the `GetVisitReports` method somewhere in this same class.</span></span>

```csharp
private void GetVisitReports(GeovisitTriggerDetails triggerDetails) {

    // Read reports from the triggerDetails. This populates the "reports" variable 
    // with all of the Geovisit instances that have been logged since the previous
    // report reading.
    IReadOnlyList<Geovisit> reports = triggerDetails.ReadReports();

    foreach (Geovisit report in reports) {
        // Using the properties of "visit", parse out the time that the state 
        // change was recorded, the device's location when the change was recorded,
        // and the type of state change.
    }

    // Note: depending on the intent of the app, you many wish to store the
    // reports in the app's local storage so they can be retrieved the next time 
    // the app is opened in the foreground.
}
```

<span data-ttu-id="ed706-144">次に、アプリのメイン プロジェクトで、このバック グラウンド タスクの登録を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed706-144">Next, in the main project of your app, you'll need to carry out the registration of this background task.</span></span> <span data-ttu-id="ed706-145">クラスがアクティブ化されるたびに呼び出され、なんらかのユーザー アクションで呼び出すこともできる登録メソッドを作成します。</span><span class="sxs-lookup"><span data-stu-id="ed706-145">Create a registering method that can be called by some user action or is called each time the class is activated.</span></span>

```csharp
// a reference to this registration should be declared at the class level
private IBackgroundTaskRegistration visitTask = null;

// The app must call this method at some point to allow future use of 
// the background task. 
private async void RegisterBackgroundTask(object sender, RoutedEventArgs e) {
    
    string taskName = "MyVisitTask";
    string taskEntryPoint = "Tasks.VisitBackgroundTask";

    // First check whether the task in question is already registered
    foreach (var task in BackgroundTaskRegistration.AllTasks) {
        if (task.Value.Name == taskName) {
            // if a task is found with the name of this app's background task, then
            // return and do not attempt to register this task
            return;
        }
    }
    
    // Attempt to register the background task.
    try {
        // Get permission for a background task from the user. If the user has 
        // already responded once, this does nothing and the user must manually 
        // update their preference via Settings.
        BackgroundAccessStatus backgroundAccessStatus = await BackgroundExecutionManager.RequestAccessAsync();

        switch (backgroundAccessStatus) {
            case BackgroundAccessStatus.AlwaysAllowed:
            case BackgroundAccessStatus.AllowedSubjectToSystemPolicy:
                // BackgroundTask is allowed
                break;

            default:
                // notify user that background tasks are disabled for this app
                //...
                break;
        }

        // Create a new background task builder
        BackgroundTaskBuilder visitTaskBuilder = new BackgroundTaskBuilder();

        visitTaskBuilder.Name = exampleTaskName;
        visitTaskBuilder.TaskEntryPoint = taskEntryPoint;

        // Create a new Visit trigger
        var trigger = new GeovisitTrigger();

        // Set the desired monitoring scope.
        // For higher granularity such as venue/building level changes, choose Venue.
        // For lower granularity in the range of zipcode level changes, choose City. 
        trigger.MonitoringScope = VisitMonitoringScope.Venue; 

        // Associate the trigger with the background task builder
        visitTaskBuilder.SetTrigger(trigger);

        // Register the background task
        visitTask = visitTaskBuilder.Register();      
    }
    catch (Exception ex) {
        // notify user that the task failed to register, using ex.ToString()
    }
}
```

<span data-ttu-id="ed706-146">これにより、`Tasks` 名前空間内の `VisitBackgroundTask` というバックグラウンド タスク クラスが `location` トリガー型によって処理を行うことが規定されます。</span><span class="sxs-lookup"><span data-stu-id="ed706-146">This establishes that a background task class called `VisitBackgroundTask` in the namespace `Tasks` will do something with the `location` trigger type.</span></span> 

<span data-ttu-id="ed706-147">これで、アプリはビジット処理のバックグラウンド タスクを登録できるようになります。また、このタスクはビジット関連の状態変化がデバイスによってログ記録されるたびにアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="ed706-147">Your app should now be capable of registering the Visits-handling background task, and this task should be activated whenever the device logs a Visit-related state change.</span></span> <span data-ttu-id="ed706-148">この状態変化情報に対する処理を決定するには、バックグラウンド タスク クラスにロジックを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed706-148">You will need to fill in the logic in your background task class to determine what to do with this state change information.</span></span>

## <a name="related-topics"></a><span data-ttu-id="ed706-149">関連トピック</span><span class="sxs-lookup"><span data-stu-id="ed706-149">Related topics</span></span>
* [<span data-ttu-id="ed706-150">アウトプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="ed706-150">Create and register an out-of-process background task</span></span>](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)
* [<span data-ttu-id="ed706-151">ユーザーの位置情報の取得</span><span class="sxs-lookup"><span data-stu-id="ed706-151">Get the user's location</span></span>](get-location.md)
* [<span data-ttu-id="ed706-152">Windows.Devices.Geolocation 名前空間</span><span class="sxs-lookup"><span data-stu-id="ed706-152">Windows.Devices.Geolocation namespace</span></span>](https://docs.microsoft.com/uwp/api/windows.devices.geolocation)