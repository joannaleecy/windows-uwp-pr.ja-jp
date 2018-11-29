---
Description: Follow these best practices for geofencing in your app.
title: ジオフェンス アプリのガイドライン
ms.assetid: F817FA55-325F-4302-81BE-37E6C7ADC281
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, 地図, 位置情報, ジオフェンス
ms.localizationpriority: medium
ms.openlocfilehash: e29bcdb8c36cc8cbbb5de11d669da1249e10d706
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8197227"
---
# <a name="guidelines-for-geofencing-apps"></a>ジオフェンス アプリのガイドライン




**重要な API**

-   [**Geofence クラス (XAML)**](https://msdn.microsoft.com/library/windows/apps/dn263587)
-   [**Geolocator クラス (XAML)**](https://msdn.microsoft.com/library/windows/apps/br225534)

アプリの [** ジオフェンス **](https://msdn.microsoft.com/library/windows/apps/dn263744) については、次のベスト プラクティスに従ってください。

## <a name="recommendations"></a>推奨事項


-   [**Geofence**](https://msdn.microsoft.com/library/windows/apps/dn263587) イベントが発生したときにインターネット アクセスが必要な場合は、ジオフェンスを作成する前にインターネット アクセスを確認します。
    -   アプリで現在インターネットにアクセスできない場合、ジオフェンスをセットアップする前にユーザーに対してインターネットに接続するようメッセージを表示することができます。
    -   インターネット アクセスが不可能である場合は、ジオフェンスの位置確認に必要な電力を消費しないようにしてください。
-   ジオフェンス イベントが [**Entered**](https://msdn.microsoft.com/library/windows/apps/dn263660) 状態または **Exited** 状態に対する変更を示す場合、タイム スタンプと現在の位置をチェックしてジオフェンス通知の関連性を確認します。 詳しくは、次の「**タイム スタンプと現在位置の確認**」をご覧ください。
詳細については、次の「(#timestamp)」をご覧ください。
-   デバイスで位置情報にアクセスできない場合は、ケースを管理する例外を作成し、必要に応じてユーザーに通知します。 アクセス許可がオフになっている、デバイスに GPS 機能が付いていない、GPS 信号がブロックされている、Wi-Fi 信号が弱いなどの理由で、位置情報が利用できない場合があります。
-   一般に、フォアグラウンドとバックグラウンドの両方で同時にジオフェンス イベントをリッスンする必要はありません。 ただし、アプリがフォアグラウンドとバックグラウンドの両方で同時にジオフェンス イベントをリッスンする必要がある場合は、次の手順を行います。

    -   [**ReadReports**](https://msdn.microsoft.com/library/windows/apps/dn263633) メソッドを呼び出して、イベントが発生したかどうかを確認します。
    -   ユーザーからアプリが見えなくなったときはフォアグラウンド イベント リスナーの登録を解除し、再び見えるようになったときにもう一度登録します。

    コード例と詳しい情報については、「[バックグラウンドとフォアグラウンドのリスナー](#background-and-foreground-listeners)」をご覧ください。

-   1 つのアプリに 1000 以上のジオフェンスを使わないでください。 システムは実際にはアプリごとに数千のジオフェンスをサポートしますが、1000 以下のジオフェンスを使用することによってアプリのメモリ使用量を減らしてアプリの高パフォーマンスを維持できます。
-   半径が 50 m 未満のジオフェンスを作成しないでください。 アプリで小さなジオフェンスを使う必要がある場合は、最高のパフォーマンスを実現するために GPS 機能付きのデバイスでアプリを使うようユーザーに勧めてください。

## <a name="additional-usage-guidance"></a>その他の使い方のガイダンス

### <a name="checking-the-time-stamp-and-current-location"></a>タイム スタンプと現在位置の確認

イベントにより [**Entered**](https://msdn.microsoft.com/library/windows/apps/dn263660) または **Exited** 状態に変化したときは、イベントのタイム スタンプと現在位置の両方を確認します。 イベントが実際にユーザーによって処理される時期は、システムでバックグラウンド タスクを起動するリソースが不足していたり、ユーザーが通知に気付かなかったり、デバイスがスタンバイ中であったり (Windows の場合) など、さまざまな要因によって影響を受けます。 たとえば、次のような順序で事態が進む可能性があります。

-   アプリがジオフェンスを作成して、ジオフェンスの進入イベントと退出イベントを監視します。
-   ユーザーがデバイスをジオフェンスの内側に移動して、進入イベントをトリガーします。
-   ジオフェンスの内側に入ったという通知をアプリがユーザーに送信します。
-   ユーザーが忙しく、通知に気付いたのは 10 分後でした。
-   その 10 分間の間に、ユーザーはジオフェンスの外側に移動していました。

タイム スタンプをみれば、アクションが過去に起こったことを判断できます。 現在位置をみれば、ユーザーがジオフェンスの外側に戻ったことが確認できます。 アプリの機能によっては、このイベントを無視することもできます。

### <a name="background-and-foreground-listeners"></a>バックグラウンドとフォアグラウンドのリスナー

一般に、アプリは、フォアグラウンド タスクとバックグラウンド タスクの両方で同時に [**Geofence**](https://msdn.microsoft.com/library/windows/apps/dn263587) イベントをリッスンする必要はありません。 両方が必要になる場合に最も明確な処理方法は、バックグラウンド タスクに通知処理を任せることです。 実際にフォアグラウンドとバックグラウンドの両方でジオフェンス リスナーをセットアップした場合、どちらが最初にトリガーされるか不明であるため、常に [**ReadReports**](https://msdn.microsoft.com/library/windows/apps/dn263633) メソッドを呼び出してイベントが発生したか確認する必要があります。

また、フォアグラウンドとバックグラウンドの両方でジオフェンス リスナーをセットアップした場合、ユーザーからアプリが見えなくなるたびにフォアグラウンド イベント リスナーの登録を解除し、再び見えるようになったときにアプリを再登録する必要があります。 表示イベントに登録するコード例を次に示します。

```csharp
    Windows.UI.Core.CoreWindow coreWindow;    

    // This needs to be set before InitializeComponent sets up event registration for app visibility
    coreWindow = CoreWindow.GetForCurrentThread();
    coreWindow.VisibilityChanged += OnVisibilityChanged;
```

```javascript
 document.addEventListener("visibilitychange", onVisibilityChanged, false);
```

表示が変わると、ここで示したようにフォアグラウンド イベント ハンドラーの有効または無効を切り替えることができます。

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

### <a name="sizing-your-geofences"></a>ジオフェンスのサイズ変更

GPS を使うと最も正確な位置情報が得られますが、ジオフェンスでは Wi-Fi などの位置センサーを使ってユーザーの現在位置を判断することもできます。 しかし、GPS とは別のこういった方法を使うと、作成できるジオフェンスのサイズが影響を受けます。 精度が低い場合、小さなジオフェンスを作成しても役に立ちません。 通常、50 m より半径が小さいジオフェンスを作らないことをお勧めします。 また、Windows ではジオフェンスのバックグラウンド タスクが周期的にしか実行されないため、小さなジオフェンスを使った場合、[**Enter**](https://msdn.microsoft.com/library/windows/apps/dn263660) イベントや **Exit** イベントをまったく認識できない可能性があります。

アプリで小さなジオフェンスを使う必要がある場合は、最高のパフォーマンスを実現するために GPS 機能付きのデバイスでアプリを使うようユーザーに勧めてください。

## <a name="related-topics"></a>関連トピック


* [ジオフェンスのセットアップ](https://msdn.microsoft.com/library/windows/apps/mt219702)
* [現在の位置情報の取得](https://msdn.microsoft.com/library/windows/apps/mt219698)
* [UWP の位置情報サンプル (Geolocation)](http://go.microsoft.com/fwlink/p/?linkid=533278)
 

 
