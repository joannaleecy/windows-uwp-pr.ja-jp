---
Description: 実用的な位置情報追跡に役立つ強力なビジット追跡機能を使用する方法について説明します。
title: ビジット追跡の使用ガイドライン
ms.assetid: 0c101684-48a9-4592-9ed5-6c20f3b830f2
ms.date: 05/18/2017
ms.topic: article
keywords: windows 10, uwp, マップ, 位置情報, geovisit, ジオビジット
ms.localizationpriority: medium
ms.openlocfilehash: db351660722cd13a4e8f14bebb651d60f33d1671
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57640777"
---
# <a name="guidelines-for-using-visits-tracking"></a>ビジット追跡の使用ガイドライン

ビジット機能を使用すると、位置追跡のプロセスを合理化し、多くのアプリ実用的な用途について効率化を図ることができます。 ビジットとは、ユーザーが進入/退出する、意味のある地理的な領域を指します。 ビジットは、ユーザーが対象領域に進入したときまたは退出したときのみにアプリが通知を受信できるという点で[ジオフェンス](guidelines-for-geofencing.md)に似ています。これにより、バッテリーの消耗につながる継続的な位置追跡が不要になります。 ただしジオフェンスの場合とは異なり、ビジットの領域はプラットフォーム レベルで動的に識別されるため、個々のアプリで明示的に定義する必要はありません。 また、アプリで追跡する対象ビジットの選択は、個々の場所のサブスクリプションではなく、単一の粒度設定によって処理されます。

## <a name="preliminary-setup"></a>準備段階のセットアップ

先へ進む前に、アプリがデバイスの位置情報にアクセスできることを確認します。 ユーザーからアプリに位置情報へのアクセスが許可されるように、マニフェスト内に `Location` 機能を宣言し、**[Geolocator.RequestAccessAsync](https://docs.microsoft.com/uwp/api/Windows.Devices.Geolocation.Geolocator.RequestAccessAsync)** メソッドを呼び出す必要があります。 方法については、「[ユーザーの位置情報の取得](get-location.md)」をご覧ください。 

クラスには、必ず `Geolocation` 名前空間を追加してください。 このガイドに記載されているコード スニペットを使用するには、この処理が必要になります。

```csharp
using Windows.Devices.Geolocation;
```

## <a name="check-the-latest-visit"></a>最新のビジットを確認する
ビジット追跡機能を使用する最も簡単な方法は、ビジットに関して認識された最新の状態変化を取得することです。 状態変化はプラットフォームによってログ記録されるイベントであり、意味のある場所に対してユーザーが進入または退出したこと、前回のレポート以降に重要な移動が発生したこと、またはユーザーの位置状態が失われたことを示します (**[VisitStateChange](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.visitstatechange)** 列挙をご覧ください)。 状態変化は **[Geovisit](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geovisit)** インスタンスで表されます。 **Geovisit** インスタンスを取得して最後に記録された状態変化を調べるには、**[GeovisitMonitor](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geovisitmonitor)** クラスに用意されている指定のメソッドを使用します。

> [!NOTE]
> 最後にログ記録されたビジットを確認しても、システムがビジットを現在追跡中であることの保証にはなりません。 ビジットの発生を追跡するには、フォアグラウンドで監視するか、バックグラウンド追跡に登録する必要があります (以下のセクションをご覧ください)。

```csharp
private async void GetLatestStateChange() {
    // retrieve the Geovisit instance
    Geovisit latestVisit = await GeovisitMonitor.GetLastReportAsync();

    // Using the properties of "latestVisit", parse out the time that the state 
    // change was recorded, the device's location when the change was recorded,
    // and the type of state change.
}
```

### <a name="parse-a-geovisit-instance-optional"></a>Geovisit インスタンスを解析する (オプション)
次のメソッドでは、**Geovisit** インスタンスに格納されたすべての情報を、簡単に読み取ることのできる文字列に変換します。 このメソッドは、このガイド内のどのシナリオでも使用でき、レポート対象のビジットに関するフィードバック提供に役立ちます。

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

## <a name="monitor-visits-in-the-foreground"></a>フォアグラウンドでビジットを監視する

前のセクションで使用した **GeovisitMonitor** クラスでは、一定時間内の状態変化をリッスンするシナリオも処理できます。 これを行うには、クラスをインスタンス化し、イベント用のハンドラー メソッドを登録して、`Start` メソッドを呼び出します。

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

この例の `OnVisitStateChanged` メソッドは、受け取ったビジット レポートを処理します。 対応する **Geovisit** インスタンスは、イベント パラメーターを介して渡されます。

```csharp
private void OnVisitStateChanged(GeoVisitWatcher sender, GeoVisitStateChangedEventArgs args) {
    Geovisit visit = args.Visit;
    
    // Using the properties of "visit", parse out the time that the state 
    // change was recorded, the device's location when the change was recorded,
    // and the type of state change.
}
```
アプリがビジット関連の状態変化の監視を終了するときには、監視を停止し、イベント ハンドラーの登録を解除する必要があります。 これは、アプリが中断したときや終了したときにも実行する必要があります。

```csharp
public void UnregisterFromVisits() {
    
    // Stop the monitor to stop tracking Visits. Otherwise, tracking will
    // continue until the monitor instance is destroyed.
    monitor.Stop();
    
    // Remove the handler to stop receiving state change events.
    monitor.VisitStateChanged -= OnVisitStateChanged;
}
```

## <a name="monitor-visits-in-the-background"></a>バックグラウンドでビジットを監視する

アプリが開いていなくてもビジット関連のアクティビティをデバイスで処理できるように、ビジットの監視をバックグラウンド タスクに実装することもできます。 これは、汎用性および省電力という点で推奨される方法です。 

このガイドでは、「[アウトプロセス バックグラウンド タスクの作成と登録](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)」のモデル (メイン アプリケーションのファイルを 1 つのプロジェクトにまとめ、バックグラウンド タスクのファイルは同じソリューション内の別プロジェクトにまとめる) を使用します。 バックグラウンド タスクを初めて実装する場合、最初のうちはガイダンスに従い、下に示すように必要な置き換えを行ってビジット処理のバックグラウンド タスクを作成することをお勧めします。

> [!NOTE]
> 以下のスニペットでは、わかりやすくするために、エラー処理やローカル ストレージなどいくつかの重要な機能が省略されています。 バックグラウンドでのビジット処理の堅牢な実装については、[サンプル アプリ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Geolocation)をご覧ください。


まず、アプリでバックグラウンド タスクのアクセス許可が宣言されていることを確認します。 *Package.appxmanifest* ファイルの `Application/Extensions` 要素に、以下の拡張機能を追加します (`Extensions` 要素がなければ追加します)。

```xml
<Extension Category="windows.backgroundTasks" EntryPoint="Tasks.VisitBackgroundTask">
    <BackgroundTasks>
        <Task Type="location" />
    </BackgroundTasks>
</Extension>
```

次に、バックグラウンド タスク クラスの定義部分に、以下のコードに貼り付けます。 このバック グラウンド タスクの `Run` メソッドは、トリガーの詳細情報 (ビジットの情報を含む) を別のメソッドに渡します。

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

同じクラス内に、`GetVisitReports` メソッドを定義します。

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

次に、アプリのメイン プロジェクトで、このバック グラウンド タスクの登録を実行する必要があります。 クラスがアクティブ化されるたびに呼び出され、なんらかのユーザー アクションで呼び出すこともできる登録メソッドを作成します。

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

これにより、`Tasks` 名前空間内の `VisitBackgroundTask` というバックグラウンド タスク クラスが `location` トリガー型によって処理を行うことが規定されます。 

これで、アプリはビジット処理のバックグラウンド タスクを登録できるようになります。また、このタスクはビジット関連の状態変化がデバイスによってログ記録されるたびにアクティブ化されます。 この状態変化情報に対する処理を決定するには、バックグラウンド タスク クラスにロジックを指定する必要があります。

## <a name="related-topics"></a>関連トピック
* [作成して、プロセス外のバック グラウンド タスクの登録](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)
* [ユーザーの位置情報の取得](get-location.md)
* [Windows.Devices.Geolocation 名前空間](https://docs.microsoft.com/uwp/api/windows.devices.geolocation)