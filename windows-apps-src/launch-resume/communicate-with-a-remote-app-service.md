---
author: PatrickFarley
title: リモート アプリ サービスとの通信
description: "\"Rome\" プロジェクトを使って、リモート デバイスで実行されているアプリ サービスとメッセージをやり取りします。"
ms.assetid: a0261e7a-5706-4f9a-b79c-46a3c81b136f
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、接続されているデバイス、リモート システム、ローマ、プロジェクト ローマ、バック グラウンド タスク、アプリのサービス
ms.localizationpriority: medium
ms.openlocfilehash: 72a8a02d14a4fa9287c987150a526745b294b65f
ms.sourcegitcommit: 753dfcd0f9fdfc963579dd0b217b445c4b110a18
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/27/2018
ms.locfileid: "2863124"
---
# <a name="communicate-with-a-remote-app-service"></a><span data-ttu-id="6b0ee-104">リモート アプリ サービスとの通信</span><span class="sxs-lookup"><span data-stu-id="6b0ee-104">Communicate with a remote app service</span></span>

<span data-ttu-id="6b0ee-105">URI を使ってリモート デバイスでアプリを起動するのに加えて、リモート デバイスでも*アプリ サービス*を実行して通信できます。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-105">In addition to launching an app on a remote device using a URI, you can run and communicate with *app services* on remote devices as well.</span></span> <span data-ttu-id="6b0ee-106">どの Windows ベースのデバイスでも、クライアント デバイス、またはホスト デバイスのいずれかとして使うことができます。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-106">Any Windows-based device can be used as either the client or host device.</span></span> <span data-ttu-id="6b0ee-107">これにより、アプリをフォアグラウンドにしなくても、接続されているデバイスとやり取りする方法がほぼ無限になります。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-107">This gives you an almost limitless number of ways to interact with connected devices without needing to bring an app to the foreground.</span></span>

## <a name="set-up-the-app-service-on-the-host-device"></a><span data-ttu-id="6b0ee-108">ホスト デバイスでアプリ サービスをセットアップする</span><span class="sxs-lookup"><span data-stu-id="6b0ee-108">Set up the app service on the host device</span></span>
<span data-ttu-id="6b0ee-109">リモート デバイスでアプリ サービスを実行するには、アプリ サービスのプロバイダーが既にそのデバイスにインストールされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-109">In order to run an app service on a remote device, you must already have a provider of that app service installed on that device.</span></span> <span data-ttu-id="6b0ee-110">このガイドでは、[ユニバーサル Windows アプリ サンプルのリポジトリ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices)で入手可能な[乱数ジェネレーター アプリ サービス](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices)の CSharp バージョンを使います。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-110">This guide will use CSharp version of the [Random Number Generator app service sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices), which is available on the [Windows universal samples repo](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices).</span></span> <span data-ttu-id="6b0ee-111">独自のアプリ サービスを記述する方法については、「[アプリ サービスの作成と利用](how-to-create-and-consume-an-app-service.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-111">For instructions on how to write your own app service, see [Create and consume an app service](how-to-create-and-consume-an-app-service.md).</span></span>

<span data-ttu-id="6b0ee-112">既製のアプリ サービスを使うか独自のアプリ サービスを記述するかにかかわらず、リモート システムとの互換性を確保するにはいくらかの編集を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-112">Whether you are using an already-made app service or writing your own, you will need to make a few edits in order to make the service compatible with remote systems.</span></span> <span data-ttu-id="6b0ee-113">Visual Studio で、アプリ サービス プロバイダーのプロジェクト (サンプルでは「AppServicesProvider」と呼ばれます) に移動し、その _Package.appxmanifest_ ファイルを選びます。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-113">In Visual Studio, go to the app service provider's project (called "AppServicesProvider" in the sample) and select its _Package.appxmanifest_ file.</span></span> <span data-ttu-id="6b0ee-114">右クリックして **[コードの表示]** を選び、ファイルの全内容を表示します。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-114">Right-click and select **View Code** to view the full contents of the file.</span></span> <span data-ttu-id="6b0ee-115">メインの**アプリケーション**要素内**の拡張機能**要素を作成する (または方が既に存在する場合)。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-115">Create an **Extensions** element inside of the main **Application** element (or find it if it already exists).</span></span> <span data-ttu-id="6b0ee-116">[アプリ サービスとして、プロジェクトの定義し、その親のプロジェクトを参照する**内線番号**を作成します。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-116">Then create an **Extension** to define the project as an app service and reference its parent project.</span></span>

``` xml
...
<Extensions>
    <uap:Extension Category="windows.appService" EntryPoint="RandomNumberService.RandomNumberGeneratorTask">
        <uap3:AppService Name="com.microsoft.randomnumbergenerator"/>
    </uap:Extension>
</Extensions>
...
```

<span data-ttu-id="6b0ee-117">**AppService**要素] の横にある**SupportsRemoteSystems**属性を追加します。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-117">Next to the **AppService** element, add the **SupportsRemoteSystems** attribute:</span></span>

``` xml
...
<uap3:AppService Name="com.microsoft.randomnumbergenerator" SupportsRemoteSystems="true"/>
...
```

<span data-ttu-id="6b0ee-118">この**uap3**名前空間の要素を使用するためにいない場合は、マニフェスト ファイルの上部にある名前空間の定義を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-118">In order to use elements in this **uap3** namespace, you must add the namespace definition at the top of the manifest file if it isn't already there.</span></span>

```xml
<?xml version="1.0" encoding="utf-8"?>
<Package
  xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
  xmlns:mp="http://schemas.microsoft.com/appx/2014/phone/manifest"
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3">
  ...
</Package>
```

<span data-ttu-id="6b0ee-119">アプリケーション サービス プロバイダー プロジェクトを作成し、[host デバイスに展開します。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-119">Then build your app service provider project and deploy it to the host device(s).</span></span>

## <a name="target-the-app-service-from-the-client-device"></a><span data-ttu-id="6b0ee-120">クライアント デバイスからアプリ サービスをターゲットにする</span><span class="sxs-lookup"><span data-stu-id="6b0ee-120">Target the app service from the client device</span></span>
<span data-ttu-id="6b0ee-121">呼び出すリモート アプリ サービスの元となるデバイスには、リモート システム機能を備えたアプリが必要です。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-121">The device from which the remote app service is to be called needs an app with Remote Systems functionality.</span></span> <span data-ttu-id="6b0ee-122">これは、ホスト デバイスでアプリ サービスを提供する同じアプリに追加するか (この場合、両方のデバイスに同じアプリをインストールします)、完全に別のアプリに実装することができます。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-122">This can be added into the same app that provides the app service on the host device (in which case you would install the same app on both devices), or implemented in a completely different app.</span></span>

<span data-ttu-id="6b0ee-123">このセクションのコードをそのまま実行するには、次の **using** ステートメントが必要です。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-123">The following **using** statements are needed for the code in this section to run as-is:</span></span>

[!code-cs[Main](./code/RemoteAppService/MainPage.xaml.cs#SnippetUsings)]


<span data-ttu-id="6b0ee-124">まず、アプリ サービスをローカルで呼び出すのと同じように [**AppServiceConnection**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.AppService.AppServiceConnection) オブジェクトをインスタンス化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-124">You must first instantiate an [**AppServiceConnection**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.AppService.AppServiceConnection) object, just as if you were to call an app service locally.</span></span> <span data-ttu-id="6b0ee-125">このプロセスについては、「[アプリ サービスの作成と利用](how-to-create-and-consume-an-app-service.md)」で詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-125">This process is covered in more detail in [Create and consume an app service](how-to-create-and-consume-an-app-service.md).</span></span> <span data-ttu-id="6b0ee-126">この例では、ターゲットにアプリ サービスは乱数ジェネレーター サービスです。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-126">In this example, the app service to target is the Random Number Generator service.</span></span>

> [!NOTE]
> <span data-ttu-id="6b0ee-127">次のメソッドを呼び出すコード内で、何らかの方法で [RemoteSystem](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystem) オブジェクトが既に取得されていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-127">It is assumed that a [RemoteSystem](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystem) object has already been acquired by some means within the code that would call the following method.</span></span> <span data-ttu-id="6b0ee-128">これをセットアップする方法については、「[リモート アプリの起動](launch-a-remote-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-128">See [Launch a remote app](launch-a-remote-app.md) for instructions on how to set this up.</span></span>

[!code-cs[Main](./code/RemoteAppService/MainPage.xaml.cs#SnippetAppService)]

<span data-ttu-id="6b0ee-129">次に、目的のリモート デバイスに [**RemoteSystemConnectionRequest**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemConnectionRequest) オブジェクトが作成されます。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-129">Next, a [**RemoteSystemConnectionRequest**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemConnectionRequest) object is created for the intended remote device.</span></span> <span data-ttu-id="6b0ee-130">これは、そのサービスに対して **AppServiceConnection** を開くために使われます。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-130">It is then used to open the **AppServiceConnection** to that device.</span></span> <span data-ttu-id="6b0ee-131">次の例では、簡単にするためにエラー処理とレポートが大幅に簡略化されている点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-131">Note that in the example below, error handling and reporting is greatly simplified for brevity.</span></span>

[!code-cs[Main](./code/RemoteAppService/MainPage.xaml.cs#SnippetRemoteConnection)]

<span data-ttu-id="6b0ee-132">現時点では、リモート コンピューター上のアプリ サービスへの接続が開かれている必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-132">At this point, you should have an open connection to an app service on a remote machine.</span></span>

## <a name="exchange-service-specific-messages-over-the-remote-connection"></a><span data-ttu-id="6b0ee-133">リモート接続経由でサービス固有のメッセージをやり取りする</span><span class="sxs-lookup"><span data-stu-id="6b0ee-133">Exchange service-specific messages over the remote connection</span></span>

<span data-ttu-id="6b0ee-134">ここでは、[**ValueSet**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.collections.valueset) オブジェクトの形式を使ってサービスとの間でメッセージを送受信できます (詳しくは「[アプリ サービスの作成と利用](how-to-create-and-consume-an-app-service.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-134">From here, you can send and receive messages to and from the service in the form of [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.collections.valueset) objects (for more information, see [Create and consume an app service](how-to-create-and-consume-an-app-service.md)).</span></span> <span data-ttu-id="6b0ee-135">乱数ジェネレーター サービスは、キー `"minvalue"` と `"maxvalue"` と共に 2 つの整数を入力として取得し、その範囲内の整数をランダムに選んで、キー `"Result"` と共に呼び出し元プロセスに返します。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-135">The Random number generator service takes two integers with the keys `"minvalue"` and `"maxvalue"` as inputs, randomly selects an integer within their range, and returns it to the calling process with the key `"Result"`.</span></span>

[!code-cs[Main](./code/RemoteAppService/MainPage.xaml.cs#SnippetSendMessage)]

<span data-ttu-id="6b0ee-136">ここでは、ターゲットとなるホスト デバイス上のアプリ サービスに接続して、そのデバイスで操作を実行し、応答でクライアント デバイスへのデータを受信しました。</span><span class="sxs-lookup"><span data-stu-id="6b0ee-136">Now you have connected to an app service on a targeted host device, run an operation on that device, and received data to your client device in response.</span></span>

## <a name="related-topics"></a><span data-ttu-id="6b0ee-137">関連トピック</span><span class="sxs-lookup"><span data-stu-id="6b0ee-137">Related topics</span></span>

[<span data-ttu-id="6b0ee-138">接続されるアプリやデバイス ("Rome" プロジェクト) の概要</span><span class="sxs-lookup"><span data-stu-id="6b0ee-138">Connected apps and devices (Project Rome) overview</span></span>](connected-apps-and-devices.md)  
[<span data-ttu-id="6b0ee-139">リモート アプリの起動</span><span class="sxs-lookup"><span data-stu-id="6b0ee-139">Launch a remote app</span></span>](launch-a-remote-app.md)  
[<span data-ttu-id="6b0ee-140">アプリ サービスの作成と利用</span><span class="sxs-lookup"><span data-stu-id="6b0ee-140">Create and consume an app service</span></span>](how-to-create-and-consume-an-app-service.md)  
[<span data-ttu-id="6b0ee-141">リモート システムの API リファレンス</span><span class="sxs-lookup"><span data-stu-id="6b0ee-141">Remote Systems API reference</span></span>](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems)  
[<span data-ttu-id="6b0ee-142">リモート システムのサンプル</span><span class="sxs-lookup"><span data-stu-id="6b0ee-142">Remote Systems sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/RemoteSystems)
