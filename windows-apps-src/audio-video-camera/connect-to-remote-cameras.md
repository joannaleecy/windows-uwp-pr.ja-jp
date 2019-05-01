---
ms.assetid: ''
description: この記事では、リモート カメラに接続し、各カメラからフレームを取得する MediaFrameSourceGroup を取得する方法を示します。
title: リモート カメラへの接続します。
ms.date: 04/19/2019
ms.topic: article
ms.custom: 19H1
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: bc719b8dad2adef0542edf284d257846052eac21
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63789582"
---
# <a name="connect-to-remote-cameras"></a>リモート カメラへの接続します。

この記事では、1 つまたは複数のリモート カメラに接続し、取得する方法を示します、 [ **MediaFrameSourceGroup** ](https://docs.microsoft.com/uwp/api/Windows.Media.Capture.Frames.MediaFrameSourceGroup)各カメラからフレームを読み取ることができるようにするオブジェクト。 メディア ソースからのフレームの読み取りの詳細については、次を参照してください。 [MediaFrameReader でメディア フレーム処理](process-media-frames-with-mediaframereader.md)します。 デバイスとペアリングの詳細については、次を参照してください。[デバイスをペアリング](https://docs.microsoft.com/windows/uwp/devices-sensors/pair-devices)します。

> [!NOTE] 
> この記事で説明した機能は、Windows 10、バージョンが 1903 以降で使用できるのみです。

## <a name="create-a-devicewatcher-class-to-watch-for-available-remote-cameras"></a>使用可能なリモート カメラを監視する DeviceWatcher クラスを作成します。

[ **DeviceWatcher** ](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher)クラスは、アプリに使用できるデバイスを監視し、デバイスの追加または削除されたときに、アプリに通知します。 インスタンスを取得**DeviceWatcher**呼び出して[ **DeviceInformation.CreateWatcher**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.createwatcher#Windows_Devices_Enumeration_DeviceInformation_CreateWatcher_System_String_)の種類を識別する高度なクエリ構文 (AQS) 文字列を渡して、デバイスを監視します。 カメラのネットワーク デバイスを指定する AQS 文字列次に示します。

```
@"System.Devices.InterfaceClassGuid:=""{B8238652-B500-41EB-B4F3-4234F7F5AE99}"" AND System.Devices.InterfaceEnabled:=System.StructuredQueryType.Boolean#True"
```

> [!NOTE] 
> ヘルパー メソッド[ **MediaFrameSourceGroup.GetDeviceSelector** ](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframesourcegroup.getdeviceselector)がローカルに接続されていると、リモートのネットワーク カメラを監視する AQS の文字列を返します。 ネットワーク カメラのみを監視するには、前に示した AQS 文字列を使用する必要があります。


返される開始すると**DeviceWatcher**呼び出すことによって、 [**開始**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.start)発生は、メソッド、 [ **Added** ](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.added)イベントが現在使用できるすべてのネットワーク カメラをします。 呼び出すことによって、監視を停止するまで[**停止**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.stop)、 **Added**カメラの新しいネットワーク デバイスが利用可能になるときに、イベントが発生しますが、 [ **から削除された**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.enumeration.devicewatcher.removed)カメラ デバイスが使用できなくなったときにイベントが発生します。

渡されるイベント引数、 **Added**と**から削除された**イベント ハンドラーは、 [ **DeviceInformation** ](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceInformation)または[ **DeviceInformationUpdate** ](https://docs.microsoft.com/en-us/uwp/api/windows.devices.enumeration.deviceinformationupdate)オブジェクトに、それぞれします。 これらの各オブジェクト、 **Id**プロパティ、イベントが発生した対象のネットワーク カメラの識別子です。 この ID に渡す、 [ **MediaFrameSourceGroup.FromIdAsync** ](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframesourcegroup.fromidasync)を取得するメソッド、 [ **MediaFrameSourceGroup** ](https://docs.microsoft.com/en-us/uwp/api/windows.media.capture.frames.mediaframesourcegroup.fromidasync)に使用できるオブジェクトカメラからフレームを取得します。

## <a name="remote-camera-pairing-helper-class"></a>リモート カメラ ペアリング ヘルパー クラス

次の例を使用するヘルパー クラスを示しています、 **DeviceWatcher**作成、更新、 **ObservableCollection**の**MediaFrameSourceGroup**をサポートするオブジェクトカメラの一覧へのデータ バインディング。 標準的なアプリをラップは、 **MediaFrameSourceGroup**カスタム モデル クラス。 ヘルパー クラスが、アプリへの参照を管理していることに注意してください[ **CoreDispatcher** ](https://docs.microsoft.com/uwp/api/Windows.UI.Core.CoreDispatcher)カメラへの呼び出し内のコレクションを更新および[ **RunAsync**](https://docs.microsoft.com/uwp/api/windows.ui.core.coredispatcher.runasync) UI スレッドでコレクションにバインドされている UI が更新されるようにします。

また、この例では処理、 [ **DeviceWatcher.Updated** ](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.updated)イベントに加え、 **Added**と**から削除された**イベント。 **Updated**ハンドラー、関連付けられているリモート カメラ デバイスから削除され、再びコレクションに追加されます。

[!code-cs[SnippetRemoteCameraPairingHelper](./code/Frames_Win10/Frames_Win10/RemoteCameraPairingHelper.cs#SnippetRemoteCameraPairingHelper)]


## <a name="related-topics"></a>関連トピック

* [カメラ](camera.md)
* [MediaCapture で基本的な写真、ビデオ、およびオーディオのキャプチャします。](basic-photo-video-and-audio-capture-with-MediaCapture.md)
* [カメラのフレームのサンプル](https://go.microsoft.com/fwlink/?LinkId=823230)
* [プロセスのメディア MediaFrameReader フレーム](process-media-frames-with-mediaframereader.md)
 

 




