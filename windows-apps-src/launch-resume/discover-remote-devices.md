---
author: PatrickFarley
title: リモート デバイスの検出
description: "\"Rome\" プロジェクトを使ってアプリからリモート デバイスを検出する方法について説明します。"
ms.assetid: 5b4231c0-5060-49e2-a577-b747e20cf633
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: e5b30e9fe2fb4f3bfbec81366a920cd74a19dcec
ms.sourcegitcommit: 2470c6596d67e1f5ca26b44fad56a2f89773e9cc
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/22/2018
ms.locfileid: "1673879"
---
# <a name="discover-remote-devices"></a><span data-ttu-id="29a6d-104">リモート デバイスの検出</span><span class="sxs-lookup"><span data-stu-id="29a6d-104">Discover remote devices</span></span>
<span data-ttu-id="29a6d-105">アプリは、ワイヤレス ネットワーク、Bluetooth、およびクラウド接続を使って、検出側デバイスと同じ Microsoft アカウントでサインインしている Windows デバイスを検出できます。</span><span class="sxs-lookup"><span data-stu-id="29a6d-105">Your app can use the wireless network, Bluetooth, and cloud connection to discover Windows devices that are signed on with the same Microsoft account as the discovering device.</span></span> <span data-ttu-id="29a6d-106">リモート デバイスを検出するために特別なソフトウェアをインストールする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="29a6d-106">The remote devices do not need to have any special software installed in order to be discoverable.</span></span>

> [!NOTE]
> <span data-ttu-id="29a6d-107">このガイドでは、「[リモート アプリの起動](launch-a-remote-app.md)」の手順に従うことで、リモート システム機能へのアクセスが既に許可されていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="29a6d-107">This guide assumes you have already been granted access to the Remote Systems feature by following the steps in [Launch a remote app](launch-a-remote-app.md).</span></span>

## <a name="filter-the-set-of-discoverable-devices"></a><span data-ttu-id="29a6d-108">検出可能な一連のデバイスのフィルター処理</span><span class="sxs-lookup"><span data-stu-id="29a6d-108">Filter the set of discoverable devices</span></span>
<span data-ttu-id="29a6d-109">フィルターに [ **RemoteSystemWatcher** ](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemWatcher) を使うことで、検出可能な一連のデバイスを絞り込むことができます。</span><span class="sxs-lookup"><span data-stu-id="29a6d-109">You can narrow the set of discoverable devices by using a [**RemoteSystemWatcher**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemWatcher) with filters.</span></span> <span data-ttu-id="29a6d-110">フィルターは、検出の種類 (隣接ネットワーク、ローカル ネットワーク、またはクラウド接続)、デバイスの種類 (デスクトップ、モバイル デバイス、Xbox、Hub、ホログラフィック)、利用可能ステータス (デバイスがリモート システム機能を利用可能かどうかのステータス) を検出できます。</span><span class="sxs-lookup"><span data-stu-id="29a6d-110">Filters can detect the discovery type (proximal vs. local network vs. cloud connection), device type (desktop, mobile device, Xbox, Hub, and Holographic), and availability status (the status of a device's availability to use Remote System features).</span></span>

<span data-ttu-id="29a6d-111">**RemoteSystemWatcher** オブジェクトを初期化する前か、その初期化中に、フィルター オブジェクトを作成する必要があります。コンストラクターにパラメーターとして渡されるためです。</span><span class="sxs-lookup"><span data-stu-id="29a6d-111">Filter objects must be constructed before or while the **RemoteSystemWatcher** object is initialized, because they are passed as a parameter into its constructor.</span></span> <span data-ttu-id="29a6d-112">次のコードでは、利用可能な各種類のフィルターを作成し、一覧に追加します。</span><span class="sxs-lookup"><span data-stu-id="29a6d-112">The following code creates a filter of each type available and then adds them to a list.</span></span>

> [!NOTE]
> <span data-ttu-id="29a6d-113">この例のコードでは、ファイルに `using Windows.System.RemoteSystems` ステートメントがあることを利用としています。</span><span class="sxs-lookup"><span data-stu-id="29a6d-113">The code in these examples requires that you have a `using Windows.System.RemoteSystems` statement in your file.</span></span>

[!code-cs[Main](./code/DiscoverDevices/MainPage.xaml.cs#SnippetMakeFilterList)]

> [!TIP]
> <span data-ttu-id="29a6d-114">"proximal" フィルター値は、物理的な近さの度合いを保証するものではありません。</span><span class="sxs-lookup"><span data-stu-id="29a6d-114">The "proximal" filter value does not guarantee the degree of physical proximity.</span></span> <span data-ttu-id="29a6d-115">確実に物理的に近いことが求められるシナリオでは、フィルターに [**RemoteSystemDiscoveryType.SpatiallyProximal**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemdiscoverytype) を使用します。</span><span class="sxs-lookup"><span data-stu-id="29a6d-115">For scenarios that require reliable physical proximity, use the value [**RemoteSystemDiscoveryType.SpatiallyProximal**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemdiscoverytype) in your filter.</span></span> <span data-ttu-id="29a6d-116">現時点では、このフィルターで許容されるデバイスは Bluetooth 経由で検出されたものに限られます。</span><span class="sxs-lookup"><span data-stu-id="29a6d-116">Currently, this filter only allows devices that are discovered by Bluetooth.</span></span> <span data-ttu-id="29a6d-117">物理的に隣接していることを保証する新しい検出メカニズムとプロトコルがサポートされたら、このフィルターにも組み込まれます。</span><span class="sxs-lookup"><span data-stu-id="29a6d-117">As new discovery mechanisms and protocols which guarantee physical proximity are supported, they will be included here as well.</span></span>  
<span data-ttu-id="29a6d-118">また、検出したデバイスが実際に物理的に近い範囲内にあるかどうかを示す、[**RemoteSystem.IsAvailableBySpatialProximity**](https://docs.microsoft.com/uwp/api/Windows.System.RemoteSystems.RemoteSystem.IsAvailableByProximity) という、[**RemoteSystem**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystem) クラスのプロパティもあります。</span><span class="sxs-lookup"><span data-stu-id="29a6d-118">There is also a property in the [**RemoteSystem**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystem) class that indicates whether a discovered device is in fact within physical proximity: [**RemoteSystem.IsAvailableBySpatialProximity**](https://docs.microsoft.com/uwp/api/Windows.System.RemoteSystems.RemoteSystem.IsAvailableByProximity).</span></span>

<span data-ttu-id="29a6d-119">[**IRemoteSystemFilter**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.IRemoteSystemFilter) オブジェクトの一覧を作成すると、**RemoteSystemWatcher** のコンストラクターに渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="29a6d-119">Once a list of [**IRemoteSystemFilter**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.IRemoteSystemFilter) objects is created, it can be passed into the constructor of a **RemoteSystemWatcher**.</span></span>

[!code-cs[Main](./code/DiscoverDevices/MainPage.xaml.cs#SnippetCreateWatcher)]

<span data-ttu-id="29a6d-120">このウォッチャーの [**Start**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemWatcher.Start) メソッドが呼び出されると、次の条件を満たすデバイスが検出された場合のみ [**RemoteSystemAdded**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemWatcher.RemoteSystemAdded) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="29a6d-120">When this watcher's [**Start**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemWatcher.Start) method is called, it will raise the [**RemoteSystemAdded**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemWatcher.RemoteSystemAdded) event only if a device is detected that meets all of the following criteria:</span></span>
* <span data-ttu-id="29a6d-121">近接接続によって検出可能</span><span class="sxs-lookup"><span data-stu-id="29a6d-121">It is discoverable by proximal connection</span></span>
* <span data-ttu-id="29a6d-122">デスクトップまたは携帯電話である</span><span class="sxs-lookup"><span data-stu-id="29a6d-122">It is a desktop or phone</span></span>
* <span data-ttu-id="29a6d-123">利用可能として分類されている</span><span class="sxs-lookup"><span data-stu-id="29a6d-123">It is classified as available</span></span>

<span data-ttu-id="29a6d-124">これ以降、イベントの処理、[**RemoteSystem**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystem) オブジェクトの取得、リモート デバイスへの接続の手順は「[リモート アプリの起動](launch-a-remote-app.md)」とまったく同じ手順です。</span><span class="sxs-lookup"><span data-stu-id="29a6d-124">From there, the procedure for handling events, retrieving [**RemoteSystem**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystem) objects, and connecting to remote devices is exactly the same as in [Launch a remote app](launch-a-remote-app.md).</span></span> <span data-ttu-id="29a6d-125">つまり、**RemoteSystem** オブジェクトは、各 **RemoteSystemAdded** イベントで渡される [**RemoteSystemAddedEventArgs**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemAddedEventArgs) オブジェクトのプロパティとして格納されます。</span><span class="sxs-lookup"><span data-stu-id="29a6d-125">In short, the **RemoteSystem** objects are stored as properties of [**RemoteSystemAddedEventArgs**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemAddedEventArgs) objects, which are passed in with each **RemoteSystemAdded** event.</span></span>

## <a name="discover-devices-by-address-input"></a><span data-ttu-id="29a6d-126">アドレス入力によるデバイスの検出</span><span class="sxs-lookup"><span data-stu-id="29a6d-126">Discover devices by address input</span></span>
<span data-ttu-id="29a6d-127">ユーザーに関連付けられていないか、スキャンで検出することができないデバイスでも、検出側のアプリが直接アドレスを使う場合はアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="29a6d-127">Some devices may not be associated with a user or discoverable with a scan, but they can still be reached if the discovering app uses a direct address.</span></span> <span data-ttu-id="29a6d-128">リモート デバイスのアドレスを表すには、[ **HostName** ](https://msdn.microsoft.com/library/windows/apps/windows.networking.hostname.aspx) クラスを使います。</span><span class="sxs-lookup"><span data-stu-id="29a6d-128">The [**HostName**](https://msdn.microsoft.com/library/windows/apps/windows.networking.hostname.aspx) class is used to represent the address of a remote device.</span></span> <span data-ttu-id="29a6d-129">これは多くの場合 IP アドレスの形式で保存されますが、他のいくつかの形式も使うことができます (詳しくは、「[ **HostName コンス トラクター** ](https://msdn.microsoft.com/library/windows/apps/br207118.aspx)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="29a6d-129">This is often stored in the form of an IP address, but several other formats are allowed (see the [**HostName constructor**](https://msdn.microsoft.com/library/windows/apps/br207118.aspx) for details).</span></span>

<span data-ttu-id="29a6d-130">**RemoteSystem** オブジェクトは、有効な **HostName** オブジェクトが指定された場合に取得されます。</span><span class="sxs-lookup"><span data-stu-id="29a6d-130">A **RemoteSystem** object is retrieved if a valid **HostName** object is provided.</span></span> <span data-ttu-id="29a6d-131">アドレス データが無効な場合、`null` オブジェクト参照が返されます。</span><span class="sxs-lookup"><span data-stu-id="29a6d-131">If the address data is invalid, a `null` object reference is returned.</span></span>

[!code-cs[Main](./code/DiscoverDevices/MainPage.xaml.cs#SnippetFindByHostName)]

## <a name="querying-a-capability-on-a-remote-system"></a><span data-ttu-id="29a6d-132">リモート システムの機能の照会</span><span class="sxs-lookup"><span data-stu-id="29a6d-132">Querying a capability on a remote system</span></span>

<span data-ttu-id="29a6d-133">検出フィルタリングからは分離されていますが、デバイスの機能を照会することが検出プロセスの重要な要素になることがあります。</span><span class="sxs-lookup"><span data-stu-id="29a6d-133">Although separate from discovery filtering, querying device capabilities can be an important part of the discovery process.</span></span> <span data-ttu-id="29a6d-134">[**RemoteSystem.GetCapabilitySupportedAsync**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystem#Windows_System_RemoteSystems_RemoteSystem_GetCapabilitySupportedAsync_System_String_) メソッドを使うと、リモート セッション接続や空間エンティティ (ホログラフィック) 共有などの特定の機能が、検出されたリモートシステムでサポートされているかどうかを照会できます。</span><span class="sxs-lookup"><span data-stu-id="29a6d-134">Using the [**RemoteSystem.GetCapabilitySupportedAsync**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystem#Windows_System_RemoteSystems_RemoteSystem_GetCapabilitySupportedAsync_System_String_) method, you can query discovered remote systems for support of certain capabilities such as remote session connectivity or spatial entity (holographic) sharing.</span></span> <span data-ttu-id="29a6d-135">照会可能な機能の一覧については、[**KnownRemoteSystemCapabilities**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.knownremotesystemcapabilities) クラスをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="29a6d-135">See the [**KnownRemoteSystemCapabilities**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.knownremotesystemcapabilities) class for the list of queryable capabilities.</span></span>

```csharp
// Check to see if the given remote system can accept LaunchUri requests
bool isRemoteSystemLaunchUriCapable = remoteSystem.GetCapabilitySupportedAsync(KnownRemoteSystemCapabilities.LaunchUri);
```

## <a name="cross-user-discovery"></a><span data-ttu-id="29a6d-136">ユーザー間の検出</span><span class="sxs-lookup"><span data-stu-id="29a6d-136">Cross-user discovery</span></span>

> [!WARNING]
> <span data-ttu-id="29a6d-137">このセクションの機能は現在、開発者が利用することはできません。</span><span class="sxs-lookup"><span data-stu-id="29a6d-137">The features in this section are not currently available to developers.</span></span>

<span data-ttu-id="29a6d-138">開発者は、同一ユーザーに登録されているデバイスだけでなく、クライアント デバイスの近くにある_すべての_デバイスを検出するように指定できます。</span><span class="sxs-lookup"><span data-stu-id="29a6d-138">Developers can specify the discovery of _all_ devices in proximity to the client device, not just devices registered to the same user.</span></span> <span data-ttu-id="29a6d-139">これは、特別な **IRemoteSystemFilter** である、[**RemoteSystemAuthorizationKindFilter**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemauthorizationkindfilter) を通じて実装されます。</span><span class="sxs-lookup"><span data-stu-id="29a6d-139">This is implemented through a special **IRemoteSystemFilter**, [**RemoteSystemAuthorizationKindFilter**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemauthorizationkindfilter).</span></span> <span data-ttu-id="29a6d-140">その実装は、他の種類のフィルターと同じように行われます。</span><span class="sxs-lookup"><span data-stu-id="29a6d-140">It is implemented like the other filter types:</span></span>

```csharp
// Construct a user type filter that includes anonymous devices
RemoteSystemAuthorizationKindFilter authorizationKindFilter = new RemoteSystemAuthorizationKindFilter(RemoteSystemAuthorizationKind.Anonymous);
// then add this filter to the RemoteSystemWatcher
```

* <span data-ttu-id="29a6d-141">[**RemoteSystemAuthorizationKind**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemauthorizationkind) の値 **Anonymous** では、信頼されていないユーザーのデバイスも含めて、すべての近接デバイスを検出できるようになります。</span><span class="sxs-lookup"><span data-stu-id="29a6d-141">A [**RemoteSystemAuthorizationKind**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemauthorizationkind) value of **Anonymous** will allow the discovery of all proximal devices, even those from non-trusted users.</span></span>
* <span data-ttu-id="29a6d-142">値 **SameUser** では、クライアント デバイスと同じユーザーに登録されているデバイスのみを検出するようにフィルター処理が行われます。</span><span class="sxs-lookup"><span data-stu-id="29a6d-142">A value of **SameUser** filters the discovery to only devices registered to the same user as the client device.</span></span> <span data-ttu-id="29a6d-143">これは既定の動作です。</span><span class="sxs-lookup"><span data-stu-id="29a6d-143">This is the default behavior.</span></span>

### <a name="checking-the-cross-user-sharing-settings"></a><span data-ttu-id="29a6d-144">ユーザー間共有設定の確認</span><span class="sxs-lookup"><span data-stu-id="29a6d-144">Checking the Cross-User Sharing settings</span></span>

<span data-ttu-id="29a6d-145">サインイン済みのデバイスで他のユーザーとエクスペリエンスを共有できるようにするには、検出アプリで上記のフィルターを指定することに加えて、クライアント デバイス自体の構成も必要になります。</span><span class="sxs-lookup"><span data-stu-id="29a6d-145">In addition to the above filter being specified in your discovery app, the client device itself must also be configured to allow shared experiences from devices signed in with other users.</span></span> <span data-ttu-id="29a6d-146">このシステム設定は、次のように **RemoteSystem** クラスで静的メソッドを使用することで照会できます。</span><span class="sxs-lookup"><span data-stu-id="29a6d-146">This is a system setting that can be queried with a static method in the **RemoteSystem** class:</span></span>

```csharp
if (!RemoteSystem.IsAuthorizationKindEnabled(RemoteSystemAuthorizationKind.Anonymous)) {
    // The system is not authorized to connect to cross-user devices. 
    // Inform the user that they can discover more devices if they
    // update the setting to "Anonymous".
}
```

<span data-ttu-id="29a6d-147">この設定を変更するには、ユーザーが**設定**アプリを開く必要があります。</span><span class="sxs-lookup"><span data-stu-id="29a6d-147">To change this setting, the user must open the **Settings** app.</span></span> <span data-ttu-id="29a6d-148">**[システム]** > **[共有エクスペリエンス]** > **[デバイス間で共有します]** メニューの順に移動すると、システムで共有可能なデバイスをユーザーが指定できるドロップダウン ボックスがあります。</span><span class="sxs-lookup"><span data-stu-id="29a6d-148">In the **System** > **Shared experiences** > **Share across devices** menu, there is a drop-down box where the user can specify which devices their system can share with.</span></span>

![[共有エクスペリエンス] 設定ページ](images/shared-experiences-settings.png)

## <a name="related-topics"></a><span data-ttu-id="29a6d-150">関連トピック</span><span class="sxs-lookup"><span data-stu-id="29a6d-150">Related topics</span></span>
* [<span data-ttu-id="29a6d-151">接続されるアプリやデバイス ("Rome" プロジェクト)</span><span class="sxs-lookup"><span data-stu-id="29a6d-151">Connected apps and devices (Project Rome)</span></span>](connected-apps-and-devices.md)
* [<span data-ttu-id="29a6d-152">リモート アプリの起動</span><span class="sxs-lookup"><span data-stu-id="29a6d-152">Launch a remote app</span></span>](launch-a-remote-app.md)
* [<span data-ttu-id="29a6d-153">リモート システムの API リファレンス</span><span class="sxs-lookup"><span data-stu-id="29a6d-153">Remote Systems API reference</span></span>](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems)
* [<span data-ttu-id="29a6d-154">リモート システムのサンプル</span><span class="sxs-lookup"><span data-stu-id="29a6d-154">Remote Systems sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/RemoteSystems)
