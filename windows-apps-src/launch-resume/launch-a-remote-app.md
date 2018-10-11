---
author: PatrickFarley
title: リモート デバイスでのアプリの起動
description: "\"Rome\" プロジェクトを使って、リモート デバイスでアプリを起動する方法について説明します。"
ms.author: pafarley
ms.date: 02/12/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 接続されているデバイス、リモート システム、"rome"、"rome"プロジェクト
ms.assetid: 54f6a33d-a3b5-4169-8664-653dbab09175
ms.localizationpriority: medium
ms.openlocfilehash: 58a420d73ba4a0cd51f909fd5d7d417af1cfb38f
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4529042"
---
# <a name="launch-an-app-on-a-remote-device"></a><span data-ttu-id="6549d-104">リモート デバイスでのアプリの起動</span><span class="sxs-lookup"><span data-stu-id="6549d-104">Launch an app on a remote device</span></span>

<span data-ttu-id="6549d-105">この記事では、Windows アプリをリモート デバイスで起動する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="6549d-105">This article explains how to launch a Windows app on a remote device.</span></span>

<span data-ttu-id="6549d-106">Windows 10 Version 1607 以降で実行される UWP アプリは、同じく Windows Version 1607 を実行し、同じ Microsoft アカウント (MSA) にサインオンしている別のデバイスの UWP アプリまたは Windows デスクトップ アプリケーションをリモートで起動できます。</span><span class="sxs-lookup"><span data-stu-id="6549d-106">Starting in Windows 10, version 1607, a UWP app can launch a UWP app or Windows desktop application remotely on another device that is also running Windows 10, version 1607 or later, provided that both devices are signed on with the same Microsoft Account (MSA).</span></span> <span data-ttu-id="6549d-107">これは Project Rome の最も簡単な使用例です。</span><span class="sxs-lookup"><span data-stu-id="6549d-107">This is the simplest use case of Project Rome.</span></span>

<span data-ttu-id="6549d-108">このリモート起動機能を使うと、ユーザーが 1 台のデバイスでタスクを開始し、別のデバイスでそのタスクを完了するといった、タスク指向のユーザー エクスペリエンスが実現します。</span><span class="sxs-lookup"><span data-stu-id="6549d-108">The remote launch feature enables task-oriented user experiences; a user can start a task on one device and finish it on another.</span></span> <span data-ttu-id="6549d-109">たとえば、車を運転しながらスマートフォンで音楽を聴き、自宅に着いた後は、機器を Xbox One に切り替えて同じ音楽を引き続き再生することができます。</span><span class="sxs-lookup"><span data-stu-id="6549d-109">For example, if the user is listening to music on their phone in their car, they could then hand playback functionality over to their Xbox One when they arrive at home.</span></span> <span data-ttu-id="6549d-110">リモート起動では、中断した箇所からタスクを続行できるように、起動するリモート アプリにコンテキスト データを渡します。</span><span class="sxs-lookup"><span data-stu-id="6549d-110">Remote launch allows apps to pass contextual data to the remote app being launched, in order to pick up where the task was left off.</span></span>

## <a name="preliminary-setup"></a><span data-ttu-id="6549d-111">準備段階のセットアップ</span><span class="sxs-lookup"><span data-stu-id="6549d-111">Preliminary setup</span></span>

### <a name="add-the-remotesystem-capability"></a><span data-ttu-id="6549d-112">remoteSystem 機能を追加する</span><span class="sxs-lookup"><span data-stu-id="6549d-112">Add the remoteSystem capability</span></span>

<span data-ttu-id="6549d-113">アプリでリモート デバイスのアプリを起動するには、`remoteSystem` 機能をアプリ パッケージ マニフェストに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6549d-113">In order for your app to launch an app on a remote device, you must add the `remoteSystem` capability to your app package manifest.</span></span> <span data-ttu-id="6549d-114">これには、マニフェスト デザイナーで  **[機能]** タブの **[リモート システム]** を選んで追加するか、プロジェクトの _Package.appxmanifest_ ファイルに以下のコードを手動で追加します。</span><span class="sxs-lookup"><span data-stu-id="6549d-114">You can use the package manifest designer to add it by selecting **Remote System** on the **Capabilities** tab, or you can manually add the following line to your project's _Package.appxmanifest_ file.</span></span>

``` xml
<Capabilities>
   <uap3:Capability Name="remoteSystem"/>
</Capabilities>
```

### <a name="enable-cross-device-sharing"></a><span data-ttu-id="6549d-115">クロスデバイス共有を実現</span><span class="sxs-lookup"><span data-stu-id="6549d-115">Enable cross-device sharing</span></span>

<span data-ttu-id="6549d-116">さらに、クライアントデバイスは、デバイス間の共有を許可するように設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6549d-116">Additionally, the client device must be set to allow cross-device sharing.</span></span> <span data-ttu-id="6549d-117">この設定には **[設定]** : **[システム]** > **[共有エクスペリエンス]** > **[デバイス間で共有します]** でアクセスできます。既定で有効になっています。</span><span class="sxs-lookup"><span data-stu-id="6549d-117">This setting, which is accessed in **Settings**: **System** > **Shared experiences** > **Share across devices**, is enabled by default.</span></span> 

![[共有エクスペリエンス] 設定ページ](images/shared-experiences-settings.png)

## <a name="find-a-remote-device"></a><span data-ttu-id="6549d-119">リモート デバイスを見つける</span><span class="sxs-lookup"><span data-stu-id="6549d-119">Find a remote device</span></span>

<span data-ttu-id="6549d-120">最初に、接続するデバイスを見つける必要があります。</span><span class="sxs-lookup"><span data-stu-id="6549d-120">You must first find the device that you want to connect with.</span></span> <span data-ttu-id="6549d-121">この方法については、「[リモート デバイスの検出](discover-remote-devices.md)」で詳しく説明されています。</span><span class="sxs-lookup"><span data-stu-id="6549d-121">[Discover remote devices](discover-remote-devices.md) discusses how to do this in detail.</span></span> <span data-ttu-id="6549d-122">ここでは、デバイスまたは接続の種類によるフィルタリングを避けた、シンプルなアプローチを使います。</span><span class="sxs-lookup"><span data-stu-id="6549d-122">We'll use a simple approach here that forgoes filtering by device or connectivity type.</span></span> <span data-ttu-id="6549d-123">つまり、リモート デバイスを探すリモート システム ウォッチャーを作成し、デバイスが検出または削除されたときに発生するイベントのハンドラーを記述します。</span><span class="sxs-lookup"><span data-stu-id="6549d-123">We will create a remote system watcher that looks for remote devices, and write handlers for the events that are raised when devices are discovered or removed.</span></span> <span data-ttu-id="6549d-124">これにより、リモート デバイスのコレクションが提供されます。</span><span class="sxs-lookup"><span data-stu-id="6549d-124">This will provide us with a collection of remote devices.</span></span>

<span data-ttu-id="6549d-125">この例のコードでは、クラス ファイルに `using Windows.System.RemoteSystems` ステートメントがあることを利用としています。</span><span class="sxs-lookup"><span data-stu-id="6549d-125">The code in these examples requires that you have a `using Windows.System.RemoteSystems` statement in your class file(s).</span></span>

[!code-cs[Main](./code/RemoteLaunchScenario/MainPage.xaml.cs#SnippetBuildDeviceList)]

<span data-ttu-id="6549d-126">リモート起動を作成する前に、最初に `RemoteSystem.RequestAccessAsync()` を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="6549d-126">The first thing you must do before making a remote launch is call `RemoteSystem.RequestAccessAsync()`.</span></span> <span data-ttu-id="6549d-127">戻り値を確認して、お使いのアプリがリモート デバイスにアクセスする許可を持っていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="6549d-127">Check the return value to make sure your app is allowed to access remote devices.</span></span> <span data-ttu-id="6549d-128">このチェックが失敗する理由の 1 つは、アプリに `remoteSystem` 機能を追加していないことです。</span><span class="sxs-lookup"><span data-stu-id="6549d-128">One reason this check could fail is if you haven't added the `remoteSystem` capability to your app.</span></span>

<span data-ttu-id="6549d-129">システム ウォッチャーのイベント ハンドラーは、接続可能なデバイスが検出されたとき、または接続できなくなったときに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="6549d-129">The system watcher event handlers are called when a device that we can connect with is discovered or is no longer available.</span></span> <span data-ttu-id="6549d-130">これらのイベント ハンドラーを使用して、接続可能なデバイスの一覧を最新に保ちます。</span><span class="sxs-lookup"><span data-stu-id="6549d-130">We will use these event handlers to keep an updated list of devices that we can connect to.</span></span>

[!code-cs[Main](./code/RemoteLaunchScenario/MainPage.xaml.cs#SnippetEventHandlers)]


<span data-ttu-id="6549d-131">**Dictionary** を使って、リモート システム ID によってデバイスを追跡します。</span><span class="sxs-lookup"><span data-stu-id="6549d-131">We will track the devices by remote system ID using a **Dictionary**.</span></span> <span data-ttu-id="6549d-132">**ObservableCollection** を使って、列挙可能なデバイスの一覧を保持します。</span><span class="sxs-lookup"><span data-stu-id="6549d-132">An **ObservableCollection** is used to hold the list of devices that we can enumerate.</span></span> <span data-ttu-id="6549d-133">**ObservableCollection** ではデバイスの一覧を UI にバインドすることも簡単にできますが、この例では行いません。</span><span class="sxs-lookup"><span data-stu-id="6549d-133">An **ObservableCollection** also makes it easy to bind the list of devices to UI, though we won't do that in this example.</span></span>

[!code-cs[Main](./code/RemoteLaunchScenario/MainPage.xaml.cs#SnippetMembers)]

<span data-ttu-id="6549d-134">リモート アプリの起動を試みる前に、アプリのスタートアップ コードに `BuildDeviceList()` への呼び出しを追加します。</span><span class="sxs-lookup"><span data-stu-id="6549d-134">Add a call to `BuildDeviceList()` in your app startup code before you attempt to launch a remote app.</span></span>

## <a name="launch-an-app-on-a-remote-device"></a><span data-ttu-id="6549d-135">リモート デバイスでのアプリの起動</span><span class="sxs-lookup"><span data-stu-id="6549d-135">Launch an app on a remote device</span></span>

<span data-ttu-id="6549d-136">接続するデバイスを [**RemoteLauncher.LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/windows.system.remotelauncher.launchuriasync.aspx) API に渡すことによって、アプリをリモートで起動します。</span><span class="sxs-lookup"><span data-stu-id="6549d-136">Launch an app remotely by passing the device you wish to connect with to the [**RemoteLauncher.LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/windows.system.remotelauncher.launchuriasync.aspx) API.</span></span> <span data-ttu-id="6549d-137">このメソッドには 3 つのオーバーロードがあります。</span><span class="sxs-lookup"><span data-stu-id="6549d-137">There are three overloads for this method.</span></span> <span data-ttu-id="6549d-138">この例で示されている最も単純なオーバーロードでは、リモート デバイス上のアプリをアクティブ化する URI を指定します。</span><span class="sxs-lookup"><span data-stu-id="6549d-138">The simplest, which this example demonstrates, specifies the URI that will activate the app on the remote device.</span></span> <span data-ttu-id="6549d-139">この例では、URI によって、リモート コンピューター上のマップ アプリがスペース ニードルの 3D ビューで開かれます。</span><span class="sxs-lookup"><span data-stu-id="6549d-139">In this example the URI opens the Maps app on the remote machine with a 3D view of the Space Needle.</span></span>

<span data-ttu-id="6549d-140">その他の **RemoteLauncher.LaunchUriAsync** のオーバーロードでは、適切なアプリがリモート デバイスで起動できない場合に参照する Web サイトの URI などのオプションや、リモート デバイスでの URI の起動に使用できるパッケージ ファミリ名のオプションの一覧を指定できます。</span><span class="sxs-lookup"><span data-stu-id="6549d-140">Other **RemoteLauncher.LaunchUriAsync** overloads allow you to specify options such as the URI of the web site to view if no appropriate app can be launched on the remote device, and an optional list of package family names that could be used to launch the URI on the remote device.</span></span> <span data-ttu-id="6549d-141">キーと値のペアの形式でデータを提供することもできます。</span><span class="sxs-lookup"><span data-stu-id="6549d-141">You can also provide data in the form of key/value pairs.</span></span> <span data-ttu-id="6549d-142">音楽の再生をデバイスから別のデバイスへと切り替えるとき、アクティブ化しているアプリにデータを渡して、再生する曲名や現在の再生位置などのコンテキストをリモート アプリに提供する場合があります。</span><span class="sxs-lookup"><span data-stu-id="6549d-142">You might pass data to the app you are activating to provide context to the remote app, such as the name of the song to play and the current playback location when you hand off playback from one device to another.</span></span>

<span data-ttu-id="6549d-143">実際には、使用するデバイスを選ぶための UI を表示するのが普通です。</span><span class="sxs-lookup"><span data-stu-id="6549d-143">In practical scenarios, you might provide UI to select the device you want to target.</span></span> <span data-ttu-id="6549d-144">しかしこの例では単純にするために、一覧の最初のリモート デバイスのみを使います。</span><span class="sxs-lookup"><span data-stu-id="6549d-144">But to simplify this example, we'll just use the first remote device on the list.</span></span>

[!code-cs[Main](./code/RemoteLaunchScenario/MainPage.xaml.cs#SnippetRemoteUriLaunch)]

<span data-ttu-id="6549d-145">**RemoteLauncher.LaunchUriAsync()** から返される [**RemoteLaunchUriStatus**](https://msdn.microsoft.com/library/windows/apps/windows.system.remotelaunchuristatus.aspx) オブジェクトは、リモートの起動が成功したかどうか、さらに、失敗した場合はその理由についての情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="6549d-145">The [**RemoteLaunchUriStatus**](https://msdn.microsoft.com/library/windows/apps/windows.system.remotelaunchuristatus.aspx) object that is returned from **RemoteLauncher.LaunchUriAsync()** provides information about whether the remote launch succeeded, and if not, the reason why.</span></span>

## <a name="related-topics"></a><span data-ttu-id="6549d-146">関連トピック</span><span class="sxs-lookup"><span data-stu-id="6549d-146">Related topics</span></span>

[<span data-ttu-id="6549d-147">リモート システムの API リファレンス</span><span class="sxs-lookup"><span data-stu-id="6549d-147">Remote Systems API reference</span></span>](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems)  
[<span data-ttu-id="6549d-148">接続されるアプリやデバイス ("Rome" プロジェクト) の概要</span><span class="sxs-lookup"><span data-stu-id="6549d-148">Connected apps and devices (Project Rome) overview</span></span>](connected-apps-and-devices.md)  
[<span data-ttu-id="6549d-149">リモート デバイスの検出</span><span class="sxs-lookup"><span data-stu-id="6549d-149">Discover remote devices</span></span>](discover-remote-devices.md)  
<span data-ttu-id="6549d-150">[リモート システムのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/RemoteSystems)では、リモート システムを検出する方法、リモート システムでアプリを起動する方法、アプリ サービスを使って 2 つのシステム上で実行しているアプリ間でメッセージを送信する方法が説明されています。</span><span class="sxs-lookup"><span data-stu-id="6549d-150">[Remote Systems sample](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/RemoteSystems) demonstrates how to discover a remote system, launch an app on a remote system, and use app services to send messages between apps running on two systems.</span></span>
