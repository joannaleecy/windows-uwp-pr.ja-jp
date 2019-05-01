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
# <a name="connect-to-remote-cameras"></a><span data-ttu-id="a758c-104">リモート カメラへの接続します。</span><span class="sxs-lookup"><span data-stu-id="a758c-104">Connect to remote cameras</span></span>

<span data-ttu-id="a758c-105">この記事では、1 つまたは複数のリモート カメラに接続し、取得する方法を示します、 [ **MediaFrameSourceGroup** ](https://docs.microsoft.com/uwp/api/Windows.Media.Capture.Frames.MediaFrameSourceGroup)各カメラからフレームを読み取ることができるようにするオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="a758c-105">This article shows you how to connect to one or more remote cameras and get a [**MediaFrameSourceGroup**](https://docs.microsoft.com/uwp/api/Windows.Media.Capture.Frames.MediaFrameSourceGroup) object that allows you to read frames from each camera.</span></span> <span data-ttu-id="a758c-106">メディア ソースからのフレームの読み取りの詳細については、次を参照してください。 [MediaFrameReader でメディア フレーム処理](process-media-frames-with-mediaframereader.md)します。</span><span class="sxs-lookup"><span data-stu-id="a758c-106">For more information on reading frames from a media source, see [Process media frames with MediaFrameReader](process-media-frames-with-mediaframereader.md).</span></span> <span data-ttu-id="a758c-107">デバイスとペアリングの詳細については、次を参照してください。[デバイスをペアリング](https://docs.microsoft.com/windows/uwp/devices-sensors/pair-devices)します。</span><span class="sxs-lookup"><span data-stu-id="a758c-107">For more information on pairing with devices, see [Pair devices](https://docs.microsoft.com/windows/uwp/devices-sensors/pair-devices).</span></span>

> [!NOTE] 
> <span data-ttu-id="a758c-108">この記事で説明した機能は、Windows 10、バージョンが 1903 以降で使用できるのみです。</span><span class="sxs-lookup"><span data-stu-id="a758c-108">The features discussed in this article are only available starting with Windows 10, version 1903.</span></span>

## <a name="create-a-devicewatcher-class-to-watch-for-available-remote-cameras"></a><span data-ttu-id="a758c-109">使用可能なリモート カメラを監視する DeviceWatcher クラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="a758c-109">Create a DeviceWatcher class to watch for available remote cameras</span></span>

<span data-ttu-id="a758c-110">[ **DeviceWatcher** ](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher)クラスは、アプリに使用できるデバイスを監視し、デバイスの追加または削除されたときに、アプリに通知します。</span><span class="sxs-lookup"><span data-stu-id="a758c-110">The [**DeviceWatcher**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher) class monitors the devices available to your app and notifies your app when devices are added or removed.</span></span> <span data-ttu-id="a758c-111">インスタンスを取得**DeviceWatcher**呼び出して[ **DeviceInformation.CreateWatcher**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.createwatcher#Windows_Devices_Enumeration_DeviceInformation_CreateWatcher_System_String_)の種類を識別する高度なクエリ構文 (AQS) 文字列を渡して、デバイスを監視します。</span><span class="sxs-lookup"><span data-stu-id="a758c-111">Get an instance of **DeviceWatcher** by calling [**DeviceInformation.CreateWatcher**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.createwatcher#Windows_Devices_Enumeration_DeviceInformation_CreateWatcher_System_String_), passing in an Advanced Query Syntax (AQS) string that identifies the type of devices you want to monitor.</span></span> <span data-ttu-id="a758c-112">カメラのネットワーク デバイスを指定する AQS 文字列次に示します。</span><span class="sxs-lookup"><span data-stu-id="a758c-112">The AQS string specifying network camera devices is the following:</span></span>

```
@"System.Devices.InterfaceClassGuid:=""{B8238652-B500-41EB-B4F3-4234F7F5AE99}"" AND System.Devices.InterfaceEnabled:=System.StructuredQueryType.Boolean#True"
```

> [!NOTE] 
> <span data-ttu-id="a758c-113">ヘルパー メソッド[ **MediaFrameSourceGroup.GetDeviceSelector** ](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframesourcegroup.getdeviceselector)がローカルに接続されていると、リモートのネットワーク カメラを監視する AQS の文字列を返します。</span><span class="sxs-lookup"><span data-stu-id="a758c-113">The helper method [**MediaFrameSourceGroup.GetDeviceSelector**](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframesourcegroup.getdeviceselector) returns an AQS string that will monitor locally-connected and remote network cameras.</span></span> <span data-ttu-id="a758c-114">ネットワーク カメラのみを監視するには、前に示した AQS 文字列を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a758c-114">To monitor only network cameras, you should use the AQS string shown above.</span></span>


<span data-ttu-id="a758c-115">返される開始すると**DeviceWatcher**呼び出すことによって、 [**開始**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.start)発生は、メソッド、 [ **Added** ](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.added)イベントが現在使用できるすべてのネットワーク カメラをします。</span><span class="sxs-lookup"><span data-stu-id="a758c-115">When you start the returned **DeviceWatcher** by calling the [**Start**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.start) method, it will raise the [**Added**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.added) event for every network camera that is currently available.</span></span> <span data-ttu-id="a758c-116">呼び出すことによって、監視を停止するまで[**停止**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.stop)、 **Added**カメラの新しいネットワーク デバイスが利用可能になるときに、イベントが発生しますが、 [ **から削除された**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.enumeration.devicewatcher.removed)カメラ デバイスが使用できなくなったときにイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="a758c-116">Until you stop the watcher by calling [**Stop**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.stop), the **Added** event will be raised when new network camera devices become available and the [**Removed**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.enumeration.devicewatcher.removed) event will be raised when a camera device becomes unavailable.</span></span>

<span data-ttu-id="a758c-117">渡されるイベント引数、 **Added**と**から削除された**イベント ハンドラーは、 [ **DeviceInformation** ](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceInformation)または[ **DeviceInformationUpdate** ](https://docs.microsoft.com/en-us/uwp/api/windows.devices.enumeration.deviceinformationupdate)オブジェクトに、それぞれします。</span><span class="sxs-lookup"><span data-stu-id="a758c-117">The event args passed into the **Added** and **Removed** event handlers are a [**DeviceInformation**](https://docs.microsoft.com/uwp/api/Windows.Devices.Enumeration.DeviceInformation) or a [**DeviceInformationUpdate**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.enumeration.deviceinformationupdate) object, respectively.</span></span> <span data-ttu-id="a758c-118">これらの各オブジェクト、 **Id**プロパティ、イベントが発生した対象のネットワーク カメラの識別子です。</span><span class="sxs-lookup"><span data-stu-id="a758c-118">Each of these objects has an **Id** property that is the identifier for the network camera for which the event was fired.</span></span> <span data-ttu-id="a758c-119">この ID に渡す、 [ **MediaFrameSourceGroup.FromIdAsync** ](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframesourcegroup.fromidasync)を取得するメソッド、 [ **MediaFrameSourceGroup** ](https://docs.microsoft.com/en-us/uwp/api/windows.media.capture.frames.mediaframesourcegroup.fromidasync)に使用できるオブジェクトカメラからフレームを取得します。</span><span class="sxs-lookup"><span data-stu-id="a758c-119">Pass this ID into the [**MediaFrameSourceGroup.FromIdAsync**](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframesourcegroup.fromidasync) method to get a [**MediaFrameSourceGroup**](https://docs.microsoft.com/en-us/uwp/api/windows.media.capture.frames.mediaframesourcegroup.fromidasync) object that you can use to retrieve frames from the camera.</span></span>

## <a name="remote-camera-pairing-helper-class"></a><span data-ttu-id="a758c-120">リモート カメラ ペアリング ヘルパー クラス</span><span class="sxs-lookup"><span data-stu-id="a758c-120">Remote camera pairing helper class</span></span>

<span data-ttu-id="a758c-121">次の例を使用するヘルパー クラスを示しています、 **DeviceWatcher**作成、更新、 **ObservableCollection**の**MediaFrameSourceGroup**をサポートするオブジェクトカメラの一覧へのデータ バインディング。</span><span class="sxs-lookup"><span data-stu-id="a758c-121">The following example shows a helper class that uses a **DeviceWatcher** to create and update an **ObservableCollection** of **MediaFrameSourceGroup** objects to support data binding to the list of cameras.</span></span> <span data-ttu-id="a758c-122">標準的なアプリをラップは、 **MediaFrameSourceGroup**カスタム モデル クラス。</span><span class="sxs-lookup"><span data-stu-id="a758c-122">Typical apps would wrap the **MediaFrameSourceGroup** in a custom model class.</span></span> <span data-ttu-id="a758c-123">ヘルパー クラスが、アプリへの参照を管理していることに注意してください[ **CoreDispatcher** ](https://docs.microsoft.com/uwp/api/Windows.UI.Core.CoreDispatcher)カメラへの呼び出し内のコレクションを更新および[ **RunAsync**](https://docs.microsoft.com/uwp/api/windows.ui.core.coredispatcher.runasync) UI スレッドでコレクションにバインドされている UI が更新されるようにします。</span><span class="sxs-lookup"><span data-stu-id="a758c-123">Note that the helper class maintains a reference to the app's [**CoreDispatcher**](https://docs.microsoft.com/uwp/api/Windows.UI.Core.CoreDispatcher) and updates the collection of cameras within calls to [**RunAsync**](https://docs.microsoft.com/uwp/api/windows.ui.core.coredispatcher.runasync) to ensure that the UI bound to the collection is updated on the UI thread.</span></span>

<span data-ttu-id="a758c-124">また、この例では処理、 [ **DeviceWatcher.Updated** ](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.updated)イベントに加え、 **Added**と**から削除された**イベント。</span><span class="sxs-lookup"><span data-stu-id="a758c-124">Also, this example handles the [**DeviceWatcher.Updated**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.devicewatcher.updated) event in addition to the **Added** and **Removed** events.</span></span> <span data-ttu-id="a758c-125">**Updated**ハンドラー、関連付けられているリモート カメラ デバイスから削除され、再びコレクションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="a758c-125">In the **Updated** handler, the associated remote camera device is removed from and then added back to the collection.</span></span>

[!code-cs[SnippetRemoteCameraPairingHelper](./code/Frames_Win10/Frames_Win10/RemoteCameraPairingHelper.cs#SnippetRemoteCameraPairingHelper)]


## <a name="related-topics"></a><span data-ttu-id="a758c-126">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a758c-126">Related topics</span></span>

* [<span data-ttu-id="a758c-127">カメラ</span><span class="sxs-lookup"><span data-stu-id="a758c-127">Camera</span></span>](camera.md)
* [<span data-ttu-id="a758c-128">MediaCapture で基本的な写真、ビデオ、およびオーディオのキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="a758c-128">Basic photo, video, and audio capture with MediaCapture</span></span>](basic-photo-video-and-audio-capture-with-MediaCapture.md)
* [<span data-ttu-id="a758c-129">カメラのフレームのサンプル</span><span class="sxs-lookup"><span data-stu-id="a758c-129">Camera frames sample</span></span>](https://go.microsoft.com/fwlink/?LinkId=823230)
* [<span data-ttu-id="a758c-130">プロセスのメディア MediaFrameReader フレーム</span><span class="sxs-lookup"><span data-stu-id="a758c-130">Process media frames with MediaFrameReader</span></span>](process-media-frames-with-mediaframereader.md)
 

 




