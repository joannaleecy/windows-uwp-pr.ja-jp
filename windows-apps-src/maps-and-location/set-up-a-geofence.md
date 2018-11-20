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
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7294512"
---
# <a name="set-up-a-geofence"></a>ジオフェンスのセットアップ




アプリで[**ジオフェンス**](https://msdn.microsoft.com/library/windows/apps/dn263587)をセットアップし、フォアグラウンドとバックグラウンドで通知を処理する方法について説明します。

**ヒント** アプリで位置情報にアクセスする方法について詳しくは、GitHub の [Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619979)から次のサンプルをダウンロードしてください。

-   [ユニバーサル Windows プラットフォーム (UWP) の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)

## <a name="enable-the-location-capability"></a>位置情報機能を有効にする


1.  **ソリューション エクスプローラー**で、**package.appxmanifest** をダブルクリックし、**[機能]** タブを選びます。
2.  **[機能]** ボックスの一覧で、**[位置情報]** をオンにします。 これにより、`Location` デバイス機能がパッケージ マニフェスト ファイルに追加されます。

```xml
  <Capabilities>
    <!-- DeviceCapability elements must follow Capability elements (if present) -->
    <DeviceCapability Name="location"/>
  </Capabilities>
```

## <a name="set-up-a-geofence"></a>ジオフェンスのセットアップ


### <a name="step-1-request-access-to-the-users-location"></a>手順 1. ユーザーの位置情報へのアクセス許可を求める

**重要** ユーザーの位置情報にアクセスする前に、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) メソッドを使って、ユーザーに位置情報へのアクセス許可を求める必要があります。 **RequestAccessAsync** メソッドは UI スレッドから呼び出す必要があり、アプリがフォアグラウンドで実行されている必要があります。 アプリがユーザーの位置情報にアクセスするには、先にユーザーがその情報へのアクセス許可をアプリに与える必要があります。

```csharp
using Windows.Devices.Geolocation;
...
var accessStatus = await Geolocator.RequestAccessAsync();
```

[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) メソッドを使って、ユーザーに位置情報へのアクセス許可を求めます。 ユーザーに対するこの要求はアプリごとに 1 回だけ行われます。 アクセス許可の付与または拒否を行った後、このメソッドはユーザーにアクセス許可を求めなくなります。 ユーザーが位置情報へのアクセス許可を求められた後にそのアクセス許可を変更できるように、位置情報の設定へのリンクを用意することをお勧めします。これについては、このトピックの後半で紹介します。

### <a name="step-2-register-for-changes-in-geofence-state-and-location-permissions"></a>手順 2. ジオフェンスの状態変更と位置情報のアクセス許可の変更を登録する

この例では、**switch** ステートメントを (前の例で示した) **accessStatus** と共に使って、ユーザーの位置情報へのアクセス許可が与えられている場合にのみ動作するように指定します。 ユーザーの位置情報へのアクセスが許可された場合、コードによって現在のジオフェンスにアクセスされ、ジオフェンスの状態変更が登録されます。また、位置情報のアクセス許可の変更も登録されます。

**ヒント** ジオフェンスを使うときは、Geolocator クラスの StatusChanged イベントではなく、GeofenceMonitor の [**StatusChanged**](https://msdn.microsoft.com/library/windows/apps/dn263646) イベントを使って、位置情報のアクセス許可の変更を監視します。 **Disabled** の [**GeofenceMonitorStatus**](https://msdn.microsoft.com/library/windows/apps/dn263599) は、無効になった [**PositionStatus**](https://msdn.microsoft.com/library/windows/apps/br225599) と同じです。どちらも、ユーザーの位置情報にアクセスするためのアクセス許可がアプリにないことを示します。

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

次に、フォアグラウンド アプリから移動するときに、イベント リスナーの登録を解除します。

```csharp
protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
{
    GeofenceMonitor.Current.GeofenceStateChanged -= OnGeofenceStateChanged;
    GeofenceMonitor.Current.StatusChanged -= OnGeofenceStatusChanged;

    base.OnNavigatingFrom(e);
}
```

### <a name="step-3-create-the-geofence"></a>手順 3. ジオフェンスを作成する

これで、[**Geofence**](https://msdn.microsoft.com/library/windows/apps/dn263587) オブジェクトを定義してセットアップする準備ができました。 必要に応じて、複数の異なるコンストラクター オーバーロードから選べます。 最も基本的なジオフェンスのコンストラクターで、次に示すように [**Id**](https://msdn.microsoft.com/library/windows/apps/dn263724) と [**Geoshape**](https://msdn.microsoft.com/library/windows/apps/dn263718) のみを指定します。

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

他のコンストラクターのいずれかを使用して、ジオフェンスをさらに微調整できます。 次の例では、ジオフェンスのコンストラクターで次の追加のパラメーターを指定します。

-   [**MonitoredStates**](https://msdn.microsoft.com/library/windows/apps/dn263728) - どのジオフェンス イベントで通知を受け取るかを示します。イベントは、定義された領域に入ったとき、定義された領域を離れたとき、ジオフェンスが除去されたときに発生します。
-   [**SingleUse**](https://msdn.microsoft.com/library/windows/apps/dn263732) - ジオフェンスが監視されている状態がすべて満たされるとジオフェンスを除去します。
-   [**DwellTime**](https://msdn.microsoft.com/library/windows/apps/dn263703) - 進入または退出イベントがトリガーされる前に、定義された領域の内側または外側にユーザーがどれぐらいとどまる必要があるかを示します。
-   [**StartTime**](https://msdn.microsoft.com/library/windows/apps/dn263735) - ジオフェンスの監視を開始する時刻を示します。
-   [**Duration**](https://msdn.microsoft.com/library/windows/apps/dn263697) - ジオフェンスを監視する期間を示します。

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

作成後、新しい [**Geofence**](https://docs.microsoft.com/uwp/api/Windows.Devices.Geolocation.Geofencing.Geofence) を忘れずにモニターに登録してください。

```csharp
// Register the geofence
try {
   GeofenceMonitor.Current.Geofences.Add(geofence);
} catch {
   // Handle failure to add geofence
}
```

### <a name="step-4-handle-changes-in-location-permissions"></a>手順 4. 位置情報へのアクセス許可の変更を処理する

[**GeofenceMonitor**](https://msdn.microsoft.com/library/windows/apps/dn263595) オブジェクトは [**StatusChanged**](https://msdn.microsoft.com/library/windows/apps/dn263646) イベントをトリガーして、ユーザーの位置情報設定が変化したことを示します。 このイベントは、引数の **sender.Status** プロパティ ([**GeofenceMonitorStatus**](https://msdn.microsoft.com/library/windows/apps/dn263599) 型) を使って、対応する状態を渡します。 このメソッドは UI スレッドから呼び出されず、[**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) オブジェクトが UI の変更を呼び出します。

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

## <a name="set-up-foreground-notifications"></a>フォアグラウンド通知のセットアップ


ジオフェンスを作成した後で、ジオフェンス イベントが発生したときの処理ロジックを追加する必要があります。 セットアップした [**MonitoredStates**](https://msdn.microsoft.com/library/windows/apps/dn263728) に応じて、次の場合にイベントを受け取ります。

-   ユーザーが関心領域に入った。
-   ユーザーが関心領域から離れた。
-   ジオフェンスが期限切れになったか、除去された。 除去イベントではバックグラウンド アプリがアクティブ化されないことに注意してください。

実行中のアプリからイベントを直接リッスンすることも、バックグラウンド タスクの登録を行い、イベントが発生するとバックグラウンド通知を受け取ることもできます。

### <a name="step-1-register-for-geofence-state-change-events"></a>手順 1. ジオフェンスの状態変更イベントに登録する

アプリでジオフェンスの状態変更についてフォアグラウンド通知を受け取るには、イベント ハンドラーを登録する必要があります。 これは一般にジオフェンスの作成時にセットアップします。

```csharp
private void Initialize()
{
    // Other initialization logic

    GeofenceMonitor.Current.GeofenceStateChanged += OnGeofenceStateChanged;
}

```

### <a name="step-2-implement-the-geofence-event-handler"></a>手順 2. ジオフェンスのイベント ハンドラーを実装する

次の手順は、イベント ハンドラーの実装です。 ここで実行するアクションは、ジオフェンスの利用目的に応じて変わります。

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

## <a name="set-up-background-notifications"></a>バックグラウンド通知のセットアップ


ジオフェンスを作成した後で、ジオフェンス イベントが発生したときの処理ロジックを追加する必要があります。 セットアップした [**MonitoredStates**](https://msdn.microsoft.com/library/windows/apps/dn263728) に応じて、次の場合にイベントを受け取ります。

-   ユーザーが関心領域に入った。
-   ユーザーが関心領域から離れた。
-   ジオフェンスが期限切れになったか、除去された。 除去イベントではバックグラウンド アプリがアクティブ化されないことに注意してください。

バックグラウンドでのジオフェンス イベントをリッスンするには

-   アプリのマニフェストでバックグラウンド タスクを宣言します。
-   アプリでバックグラウンド タスクを登録します。 クラウド サービスへのアクセスなど、インターネット アクセスがアプリに必要な場合は、イベントがトリガーされたときにそのためのフラグを設定できます。 イベントがトリガーされたときにユーザーがその場にいて、ユーザーに通知が確実に届くようにするために、フラグを設定することもできます。
-   アプリをフォアグラウンドで実行中に、位置情報のアクセス許可をアプリに与えるようユーザーに求めます。

### <a name="step-1-register-for-geofence-state-change-events"></a>手順 1. ジオフェンスの状態変更イベントに登録する

アプリのマニフェストの **[宣言]** タブで、位置情報バックグラウンド タスクの宣言を追加します。 そのためには、次のようにします。

-   タイプが **[バックグラウンド タスク]** の宣言を追加します。
-   プロパティのタスク タイプを **[位置情報]** に設定します。
-   イベントがトリガーされたときに呼び出すアプリのエントリ ポイントを設定します。

### <a name="step-2-register-the-background-task"></a>手順 2. バックグラウンド タスクを登録する

この手順のコードでは、ジオフェンス バックグラウンド タスクを登録しています。 ジオフェンスを作成したときに、位置情報のアクセス許可を確認しました。

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

### <a name="step-3-handling-the-background-notification"></a>手順 3. バックグラウンド通知を処理する

ユーザーに通知するためにとるアクションは、アプリの用途に応じて変わりますが、トースト通知の表示、サウンドの再生、ライブ タイルの更新などが考えられます。 この手順のコードは通知を処理します。

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

## <a name="change-the-privacy-settings"></a>プライバシー設定の変更


位置情報のプライバシー設定でアプリにユーザーの位置情報へのアクセス許可を与えていない場合は、**設定**アプリの **[位置情報のプライバシー設定]** へのリンクを用意することをお勧めします。 この例では、ハイパーリンク コントロールを使って、`ms-settings:privacy-location` という URI に移動します。

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

また、アプリで [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) メソッドを呼び出し、コードで**設定**アプリを起動することもできます。 詳しくは、「[Windows 設定アプリの起動](https://msdn.microsoft.com/library/windows/apps/mt228342)」をご覧ください。

```csharp
using Windows.System;
...
bool result = await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-location"));
```

## <a name="test-and-debug-your-app"></a>アプリのテストとデバッグ


ジオフェンス アプリはデバイスの位置に依存しているため、そのテストとデバッグは容易ではありません。 ここでは、フォアグラウンドとバックグラウンドのジオフェンスの両方をテストするいくつかの方法について概略を示します。

**ジオフェンス アプリをデバッグするには**

1.  デバイスを新しい位置に物理的に移動します。
2.  現在の物理的な位置を含むジオフェンス領域を作成して、ジオフェンスへの進入をテストします。ジオフェンスの内部に既にいるため、"ジオフェンス進入" イベントが直ちにトリガーされます。
3.  Microsoft Visual Studio エミュレーターを使って、デバイスの位置をシミュレートします。

### <a name="test-and-debug-a-geofencing-app-that-is-running-in-the-foreground"></a>フォアグラウンドで実行中のジオフェンス アプリのテストとデバッグ

**フォアグラウンドで実行中のジオフェンス アプリをテストするには**

1.  Visual Studio でアプリをビルドします。
2.  Visual Studio エミュレーターでアプリを起動します。
3.  これらのツールを使って、ジオフェンス領域の内外のさまざまな位置をシミュレートします。 [**DwellTime**](https://msdn.microsoft.com/library/windows/apps/dn263703) プロパティで指定した時間が経過してイベントがトリガーされるまで、十分な時間、待ってください。 アプリに位置情報のアクセス許可を与えるというメッセージに同意する必要があります。 位置のシミュレーションについて詳しくは、「シミュレーターでの Windows ストア アプリの実行」の「[デバイスのシミュレートされる地理上の位置を設定する](http://go.microsoft.com/fwlink/p/?LinkID=325245)」をご覧ください。
4.  また、さまざまな速度での検出に必要なおおよそのジオフェンスのサイズとドウェル時間を見積もるためにエミュレーターを使うこともできます。

### <a name="test-and-debug-a-geofencing-app-that-is-running-in-the-background"></a>バックグラウンドで実行中のジオフェンス アプリのテストとデバッグ

**バックグラウンドで実行中のジオフェンス アプリをテストするには**

1.  Visual Studio でアプリをビルドします。 アプリでバックグラウンド タスクの種類を **Location** に設定する必要があります。
2.  最初に、アプリをローカルに展開します。
3.  ローカルで実行中のアプリを閉じます。
4.  Visual Studio エミュレーターでアプリを起動します。 バックグラウンドのジオフェンス シミュレーションは、エミュレーター内では一度に 1 つのアプリでしかサポートされていません。 エミュレーター内で複数のジオフェンス アプリを起動しないでください。
5.  エミュレーターから、ジオフェンス領域の内外のさまざまな位置をシミュレートします。 [**DwellTime**](https://msdn.microsoft.com/library/windows/apps/dn263703) の時間が経過してイベントがトリガーされるまで、十分な時間、待ってください。 アプリに位置情報のアクセス許可を与えるというメッセージに同意する必要があります。
6.  Visual Studio を使って、位置情報バックグラウンド タスクをトリガーします。 Visual Studio でのバックグラウンド タスクのトリガーについて詳しくは、「[Visual Studio で Windows ストア アプリの中断イベント、再開イベント、およびバックグラウンド イベントをトリガーする方法](http://go.microsoft.com/fwlink/p/?LinkID=325378)」をご覧ください。

## <a name="troubleshoot-your-app"></a>アプリのトラブルシューティング


アプリが位置情報にアクセスする前に、デバイスで **[位置情報]** を有効にする必要があります。 **設定**アプリで、次の**位置情報に関するプライバシー設定**がオンになっていることを確認します。

-   **このデバイス] の位置情報****オン (windows 10 Mobile では適用されません)**
-   位置情報サービス設定の **[位置情報]** が **オン** になっている
-   **[位置情報を使うことができるアプリを選ぶ]** で、アプリが **オン** になっている

## <a name="related-topics"></a>関連トピック

* [UWP の位置情報のサンプル](http://go.microsoft.com/fwlink/p/?linkid=533278)
* [ジオフェンスの設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn631756)
* [位置認識アプリの設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465148)
