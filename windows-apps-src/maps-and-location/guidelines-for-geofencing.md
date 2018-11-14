---
author: PatrickFarley
Description: Follow these best practices for geofencing in your app.
title: ジオフェンス アプリのガイドライン
ms.assetid: F817FA55-325F-4302-81BE-37E6C7ADC281
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, 地図, 位置情報, ジオフェンス
ms.localizationpriority: medium
ms.openlocfilehash: 86104f00ed0189290fd0cd718042573d9d592cc3
ms.sourcegitcommit: bdc40b08cbcd46fc379feeda3c63204290e055af
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/08/2018
ms.locfileid: "6144707"
---
# <a name="guidelines-for-geofencing-apps"></a><span data-ttu-id="3c74f-103">ジオフェンス アプリのガイドライン</span><span class="sxs-lookup"><span data-stu-id="3c74f-103">Guidelines for geofencing apps</span></span>




**<span data-ttu-id="3c74f-104">重要な API</span><span class="sxs-lookup"><span data-stu-id="3c74f-104">Important APIs</span></span>**

-   [**<span data-ttu-id="3c74f-105">Geofence クラス (XAML)</span><span class="sxs-lookup"><span data-stu-id="3c74f-105">Geofence class (XAML)</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn263587)
-   [**<span data-ttu-id="3c74f-106">Geolocator クラス (XAML)</span><span class="sxs-lookup"><span data-stu-id="3c74f-106">Geolocator class (XAML)</span></span>**](https://msdn.microsoft.com/library/windows/apps/br225534)

<span data-ttu-id="3c74f-107">アプリの [\*\* ジオフェンス \*\*](https://msdn.microsoft.com/library/windows/apps/dn263744) については、次のベスト プラクティスに従ってください。</span><span class="sxs-lookup"><span data-stu-id="3c74f-107">Follow these best practices for [**geofencing**](https://msdn.microsoft.com/library/windows/apps/dn263744) in your app.</span></span>

## <a name="recommendations"></a><span data-ttu-id="3c74f-108">推奨事項</span><span class="sxs-lookup"><span data-stu-id="3c74f-108">Recommendations</span></span>


-   <span data-ttu-id="3c74f-109">[**Geofence**](https://msdn.microsoft.com/library/windows/apps/dn263587) イベントが発生したときにインターネット アクセスが必要な場合は、ジオフェンスを作成する前にインターネット アクセスを確認します。</span><span class="sxs-lookup"><span data-stu-id="3c74f-109">If your app will need internet access when a [**Geofence**](https://msdn.microsoft.com/library/windows/apps/dn263587) event occurs, check for internet access before creating the geofence.</span></span>
    -   <span data-ttu-id="3c74f-110">アプリで現在インターネットにアクセスできない場合、ジオフェンスをセットアップする前にユーザーに対してインターネットに接続するようメッセージを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="3c74f-110">If the app doesn't currently have internet access, you can prompt the user to connect to the internet before you set up the geofence.</span></span>
    -   <span data-ttu-id="3c74f-111">インターネット アクセスが不可能である場合は、ジオフェンスの位置確認に必要な電力を消費しないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="3c74f-111">If internet access isn't possible, avoid consuming the power required for the geofencing location checks.</span></span>
-   <span data-ttu-id="3c74f-112">ジオフェンス イベントが [**Entered**](https://msdn.microsoft.com/library/windows/apps/dn263660) 状態または **Exited** 状態に対する変更を示す場合、タイム スタンプと現在の位置をチェックしてジオフェンス通知の関連性を確認します。</span><span class="sxs-lookup"><span data-stu-id="3c74f-112">Ensure the relevance of geofencing notifications by checking the time stamp and current location when a geofence event indicates changes to an [**Entered**](https://msdn.microsoft.com/library/windows/apps/dn263660) or **Exited** state.</span></span> <span data-ttu-id="3c74f-113">詳しくは、次の「**タイム スタンプと現在位置の確認**」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3c74f-113">See **Checking the time stamp and current location** below for more information.</span></span>
<span data-ttu-id="3c74f-114">詳細については、次の「(#timestamp)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3c74f-114">(#timestamp) below for more information.</span></span>
-   <span data-ttu-id="3c74f-115">デバイスで位置情報にアクセスできない場合は、ケースを管理する例外を作成し、必要に応じてユーザーに通知します。</span><span class="sxs-lookup"><span data-stu-id="3c74f-115">Create exceptions to manage cases when a device can't access location info, and notify the user if necessary.</span></span> <span data-ttu-id="3c74f-116">アクセス許可がオフになっている、デバイスに GPS 機能が付いていない、GPS 信号がブロックされている、Wi-Fi 信号が弱いなどの理由で、位置情報が利用できない場合があります。</span><span class="sxs-lookup"><span data-stu-id="3c74f-116">Location info may be unavailable because permissions are turned off, the device doesn't contain a GPS radio, the GPS signal is blocked, or the Wi-Fi signal isn't strong enough.</span></span>
-   <span data-ttu-id="3c74f-117">一般に、フォアグラウンドとバックグラウンドの両方で同時にジオフェンス イベントをリッスンする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="3c74f-117">In general, it isn't necessary to listen for geofence events in the foreground and background at the same time.</span></span> <span data-ttu-id="3c74f-118">ただし、アプリがフォアグラウンドとバックグラウンドの両方で同時にジオフェンス イベントをリッスンする必要がある場合は、次の手順を行います。</span><span class="sxs-lookup"><span data-stu-id="3c74f-118">However, if your app needs to listen for geofence events in both the foreground and background:</span></span>

    -   <span data-ttu-id="3c74f-119">[**ReadReports**](https://msdn.microsoft.com/library/windows/apps/dn263633) メソッドを呼び出して、イベントが発生したかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="3c74f-119">Call the [**ReadReports**](https://msdn.microsoft.com/library/windows/apps/dn263633) method to find out if an event has occurred.</span></span>
    -   <span data-ttu-id="3c74f-120">ユーザーからアプリが見えなくなったときはフォアグラウンド イベント リスナーの登録を解除し、再び見えるようになったときにもう一度登録します。</span><span class="sxs-lookup"><span data-stu-id="3c74f-120">Unregister your foreground event listener when your app isn't visible to the user and re-register when it becomes visible again.</span></span>

    <span data-ttu-id="3c74f-121">コード例と詳しい情報については、「[バックグラウンドとフォアグラウンドのリスナー](#background-and-foreground-listeners)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3c74f-121">See [Background and foreground listeners](#background-and-foreground-listeners) for code examples and more information.</span></span>

-   <span data-ttu-id="3c74f-122">1 つのアプリに 1000 以上のジオフェンスを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="3c74f-122">Don't use more than 1000 geofences per app.</span></span> <span data-ttu-id="3c74f-123">システムは実際にはアプリごとに数千のジオフェンスをサポートしますが、1000 以下のジオフェンスを使用することによってアプリのメモリ使用量を減らしてアプリの高パフォーマンスを維持できます。</span><span class="sxs-lookup"><span data-stu-id="3c74f-123">The system actually supports thousands of geofences per app, you can maintain good app performance to help reduce the app's memory usage by using no more than 1000.</span></span>
-   <span data-ttu-id="3c74f-124">半径が 50 m 未満のジオフェンスを作成しないでください。</span><span class="sxs-lookup"><span data-stu-id="3c74f-124">Don't create a geofence with a radius smaller than 50 meters.</span></span> <span data-ttu-id="3c74f-125">アプリで小さなジオフェンスを使う必要がある場合は、最高のパフォーマンスを実現するために GPS 機能付きのデバイスでアプリを使うようユーザーに勧めてください。</span><span class="sxs-lookup"><span data-stu-id="3c74f-125">If your app needs to use a geofence with a small radius, advise users to use your app on a device with a GPS radio to ensure the best performance.</span></span>

## <a name="additional-usage-guidance"></a><span data-ttu-id="3c74f-126">その他の使い方のガイダンス</span><span class="sxs-lookup"><span data-stu-id="3c74f-126">Additional usage guidance</span></span>

### <a name="checking-the-time-stamp-and-current-location"></a><span data-ttu-id="3c74f-127">タイム スタンプと現在位置の確認</span><span class="sxs-lookup"><span data-stu-id="3c74f-127">Checking the time stamp and current location</span></span>

<span data-ttu-id="3c74f-128">イベントにより [**Entered**](https://msdn.microsoft.com/library/windows/apps/dn263660) または **Exited** 状態に変化したときは、イベントのタイム スタンプと現在位置の両方を確認します。</span><span class="sxs-lookup"><span data-stu-id="3c74f-128">When an event indicates a change to an [**Entered**](https://msdn.microsoft.com/library/windows/apps/dn263660) or **Exited** state, check both the time stamp of the event and your current location.</span></span> <span data-ttu-id="3c74f-129">イベントが実際にユーザーによって処理される時期は、システムでバックグラウンド タスクを起動するリソースが不足していたり、ユーザーが通知に気付かなかったり、デバイスがスタンバイ中であったり (Windows の場合) など、さまざまな要因によって影響を受けます。</span><span class="sxs-lookup"><span data-stu-id="3c74f-129">Various factors, such as the system not having enough resources to launch a background task, the user not noticing the notification, or the device being in standby (on Windows), may affect when the event is actually processed by the user.</span></span> <span data-ttu-id="3c74f-130">たとえば、次のような順序で事態が進む可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3c74f-130">For example, the following sequence may occur:</span></span>

-   <span data-ttu-id="3c74f-131">アプリがジオフェンスを作成して、ジオフェンスの進入イベントと退出イベントを監視します。</span><span class="sxs-lookup"><span data-stu-id="3c74f-131">Your app creates a geofence and monitors the geofence for enter and exit events.</span></span>
-   <span data-ttu-id="3c74f-132">ユーザーがデバイスをジオフェンスの内側に移動して、進入イベントをトリガーします。</span><span class="sxs-lookup"><span data-stu-id="3c74f-132">The user moves the device inside of the geofence, causing an enter event to be triggered.</span></span>
-   <span data-ttu-id="3c74f-133">ジオフェンスの内側に入ったという通知をアプリがユーザーに送信します。</span><span class="sxs-lookup"><span data-stu-id="3c74f-133">Your app sends a notification to the user that they are now inside the geofence.</span></span>
-   <span data-ttu-id="3c74f-134">ユーザーが忙しく、通知に気付いたのは 10 分後でした。</span><span class="sxs-lookup"><span data-stu-id="3c74f-134">The user was busy and does not notice the notification until 10 minutes later.</span></span>
-   <span data-ttu-id="3c74f-135">その 10 分間の間に、ユーザーはジオフェンスの外側に移動していました。</span><span class="sxs-lookup"><span data-stu-id="3c74f-135">During that 10 minute delay, the user has moved back outside of the geofence.</span></span>

<span data-ttu-id="3c74f-136">タイム スタンプをみれば、アクションが過去に起こったことを判断できます。</span><span class="sxs-lookup"><span data-stu-id="3c74f-136">From the timestamp, you can tell that the action occurred in the past.</span></span> <span data-ttu-id="3c74f-137">現在位置をみれば、ユーザーがジオフェンスの外側に戻ったことが確認できます。</span><span class="sxs-lookup"><span data-stu-id="3c74f-137">From the current location, you can see that the user is now back outside of the geofence.</span></span> <span data-ttu-id="3c74f-138">アプリの機能によっては、このイベントを無視することもできます。</span><span class="sxs-lookup"><span data-stu-id="3c74f-138">Depending on the functionality of your app, you may want to filter out this event.</span></span>

### <a name="background-and-foreground-listeners"></a><span data-ttu-id="3c74f-139">バックグラウンドとフォアグラウンドのリスナー</span><span class="sxs-lookup"><span data-stu-id="3c74f-139">Background and foreground listeners</span></span>

<span data-ttu-id="3c74f-140">一般に、アプリは、フォアグラウンド タスクとバックグラウンド タスクの両方で同時に [**Geofence**](https://msdn.microsoft.com/library/windows/apps/dn263587) イベントをリッスンする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="3c74f-140">In general, your app doesn't need to listen for [**Geofence**](https://msdn.microsoft.com/library/windows/apps/dn263587) events both in the foreground and in a background task at the same time.</span></span> <span data-ttu-id="3c74f-141">両方が必要になる場合に最も明確な処理方法は、バックグラウンド タスクに通知処理を任せることです。</span><span class="sxs-lookup"><span data-stu-id="3c74f-141">The cleanest method for handling a case where you might need both is to let the background task handle the notifications.</span></span> <span data-ttu-id="3c74f-142">実際にフォアグラウンドとバックグラウンドの両方でジオフェンス リスナーをセットアップした場合、どちらが最初にトリガーされるか不明であるため、常に [**ReadReports**](https://msdn.microsoft.com/library/windows/apps/dn263633) メソッドを呼び出してイベントが発生したか確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3c74f-142">If you do set up both foreground and background geofence listeners, there is no guarantee which will be triggered first and so you must always call the [**ReadReports**](https://msdn.microsoft.com/library/windows/apps/dn263633) method to find out if an event has occurred.</span></span>

<span data-ttu-id="3c74f-143">また、フォアグラウンドとバックグラウンドの両方でジオフェンス リスナーをセットアップした場合、ユーザーからアプリが見えなくなるたびにフォアグラウンド イベント リスナーの登録を解除し、再び見えるようになったときにアプリを再登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3c74f-143">If you have set up both foreground and background geofence listeners, you should unregister your foreground event listener whenever your app is not visible to the user and re-register your app when it becomes visible again.</span></span> <span data-ttu-id="3c74f-144">表示イベントに登録するコード例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3c74f-144">Here's some example code that registers for the visibility event.</span></span>

```csharp
    Windows.UI.Core.CoreWindow coreWindow;    

    // This needs to be set before InitializeComponent sets up event registration for app visibility
    coreWindow = CoreWindow.GetForCurrentThread();
    coreWindow.VisibilityChanged += OnVisibilityChanged;
```

```javascript
 document.addEventListener("visibilitychange", onVisibilityChanged, false);
```

<span data-ttu-id="3c74f-145">表示が変わると、ここで示したようにフォアグラウンド イベント ハンドラーの有効または無効を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="3c74f-145">When the visibility changes, you can then enable or disable the foreground event handlers as shown here.</span></span>

```csharp
private void OnVisibilityChanged(CoreWindow sender, VisibilityChangedEventArgs args)
{
    // NOTE: After the app is no longer visible on the screen and before the app is suspended
    // you might want your app to use toast notification for any geofence activity.
    // By registering for VisibiltyChanged the app is notified when the app is no longer visible in the foreground.

    if (args.Visible)
    {
        // register for foreground events
        GeofenceMonitor.Current.GeofenceStateChanged += OnGeofenceStateChanged;
        GeofenceMonitor.Current.StatusChanged += OnGeofenceStatusChanged;
    }
    else
    {
        // unregister foreground events (let background capture events)
        GeofenceMonitor.Current.GeofenceStateChanged -= OnGeofenceStateChanged;
        GeofenceMonitor.Current.StatusChanged -= OnGeofenceStatusChanged;
    }
}
```

```javascript
function onVisibilityChanged() {
    // NOTE: After the app is no longer visible on the screen and before the app is suspended
    // you might want your app to use toast notification for any geofence activity.
    // By registering for VisibiltyChanged the app is notified when the app is no longer visible in the foreground.

    if (document.msVisibilityState === "visible") {
        // register for foreground events
        Windows.Devices.Geolocation.Geofencing.GeofenceMonitor.current.addEventListener("geofencestatechanged", onGeofenceStateChanged);
        Windows.Devices.Geolocation.Geofencing.GeofenceMonitor.current.addEventListener("statuschanged", onGeofenceStatusChanged);
    } else {
        // unregister foreground events (let background capture events)
        Windows.Devices.Geolocation.Geofencing.GeofenceMonitor.current.removeEventListener("geofencestatechanged", onGeofenceStateChanged);
        Windows.Devices.Geolocation.Geofencing.GeofenceMonitor.current.removeEventListener("statuschanged", onGeofenceStatusChanged);
    }
}
```

### <a name="sizing-your-geofences"></a><span data-ttu-id="3c74f-146">ジオフェンスのサイズ変更</span><span class="sxs-lookup"><span data-stu-id="3c74f-146">Sizing your geofences</span></span>

<span data-ttu-id="3c74f-147">GPS を使うと最も正確な位置情報が得られますが、ジオフェンスでは Wi-Fi などの位置センサーを使ってユーザーの現在位置を判断することもできます。</span><span class="sxs-lookup"><span data-stu-id="3c74f-147">While GPS can provide the most accurate location info, geofencing can also use Wi-Fi or other location sensors to determine the user's current position.</span></span> <span data-ttu-id="3c74f-148">しかし、GPS とは別のこういった方法を使うと、作成できるジオフェンスのサイズが影響を受けます。</span><span class="sxs-lookup"><span data-stu-id="3c74f-148">But using these other methods can affect the size of the geofences you can create.</span></span> <span data-ttu-id="3c74f-149">精度が低い場合、小さなジオフェンスを作成しても役に立ちません。</span><span class="sxs-lookup"><span data-stu-id="3c74f-149">If the accuracy level is low, creating small geofences won't be useful.</span></span> <span data-ttu-id="3c74f-150">通常、50 m より半径が小さいジオフェンスを作らないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3c74f-150">In general, it is recommended that you do not create a geofence with a radius smaller than 50 meters.</span></span> <span data-ttu-id="3c74f-151">また、Windows ではジオフェンスのバックグラウンド タスクが周期的にしか実行されないため、小さなジオフェンスを使った場合、[**Enter**](https://msdn.microsoft.com/library/windows/apps/dn263660) イベントや **Exit** イベントをまったく認識できない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3c74f-151">Also, geofence background tasks only run periodically on Windows; if you use a small geofence, there's a possibility that you could miss an [**Enter**](https://msdn.microsoft.com/library/windows/apps/dn263660) or **Exit** event entirely.</span></span>

<span data-ttu-id="3c74f-152">アプリで小さなジオフェンスを使う必要がある場合は、最高のパフォーマンスを実現するために GPS 機能付きのデバイスでアプリを使うようユーザーに勧めてください。</span><span class="sxs-lookup"><span data-stu-id="3c74f-152">If your app needs to use a geofence with a small radius, advise users to use your app on a device with a GPS radio to ensure the best performance.</span></span>

## <a name="related-topics"></a><span data-ttu-id="3c74f-153">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3c74f-153">Related topics</span></span>


* [<span data-ttu-id="3c74f-154">ジオフェンスのセットアップ</span><span class="sxs-lookup"><span data-stu-id="3c74f-154">Set up a geofence</span></span>](https://msdn.microsoft.com/library/windows/apps/mt219702)
* [<span data-ttu-id="3c74f-155">現在の位置情報の取得</span><span class="sxs-lookup"><span data-stu-id="3c74f-155">Get current location</span></span>](https://msdn.microsoft.com/library/windows/apps/mt219698)
* [<span data-ttu-id="3c74f-156">UWP の位置情報サンプル (Geolocation)</span><span class="sxs-lookup"><span data-stu-id="3c74f-156">UWP location sample (geolocation)</span></span>](http://go.microsoft.com/fwlink/p/?linkid=533278)
 

 
