---
title: リモート デバイスの検出
description: "\"Rome\" プロジェクトを使ってアプリからリモート デバイスを検出する方法について説明します。"
ms.assetid: 5b4231c0-5060-49e2-a577-b747e20cf633
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10、uwp、接続されているデバイス、リモート システム、ローマ、プロジェクトのローマ
ms.localizationpriority: medium
ms.openlocfilehash: 7788cb546eddf77292210b5b1e8268239504a843
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57592137"
---
# <a name="discover-remote-devices"></a><span data-ttu-id="a9751-104">リモート デバイスの検出</span><span class="sxs-lookup"><span data-stu-id="a9751-104">Discover remote devices</span></span>
<span data-ttu-id="a9751-105">アプリは、ワイヤレス ネットワーク、Bluetooth、およびクラウド接続を使って、検出側デバイスと同じ Microsoft アカウントでサインインしている Windows デバイスを検出できます。</span><span class="sxs-lookup"><span data-stu-id="a9751-105">Your app can use the wireless network, Bluetooth, and cloud connection to discover Windows devices that are signed on with the same Microsoft account as the discovering device.</span></span> <span data-ttu-id="a9751-106">リモート デバイスを検出するために特別なソフトウェアをインストールする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="a9751-106">The remote devices do not need to have any special software installed in order to be discoverable.</span></span>

> [!NOTE]
> <span data-ttu-id="a9751-107">このガイドでは、「[リモート アプリの起動](launch-a-remote-app.md)」の手順に従うことで、リモート システム機能へのアクセスが既に許可されていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="a9751-107">This guide assumes you have already been granted access to the Remote Systems feature by following the steps in [Launch a remote app](launch-a-remote-app.md).</span></span>

## <a name="filter-the-set-of-discoverable-devices"></a><span data-ttu-id="a9751-108">検出可能な一連のデバイスのフィルター処理</span><span class="sxs-lookup"><span data-stu-id="a9751-108">Filter the set of discoverable devices</span></span>
<span data-ttu-id="a9751-109">フィルターに [**RemoteSystemWatcher**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemWatcher) を使うことで、検出可能な一連のデバイスを絞り込むことができます。</span><span class="sxs-lookup"><span data-stu-id="a9751-109">You can narrow the set of discoverable devices by using a [**RemoteSystemWatcher**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemWatcher) with filters.</span></span> <span data-ttu-id="a9751-110">フィルターは、検出の種類 (隣接ネットワーク、ローカル ネットワーク、またはクラウド接続)、デバイスの種類 (デスクトップ、モバイル デバイス、Xbox、Hub、ホログラフィック)、利用可能ステータス (デバイスがリモート システム機能を利用可能かどうかのステータス) を検出できます。</span><span class="sxs-lookup"><span data-stu-id="a9751-110">Filters can detect the discovery type (proximal vs. local network vs. cloud connection), device type (desktop, mobile device, Xbox, Hub, and Holographic), and availability status (the status of a device's availability to use Remote System features).</span></span>

<span data-ttu-id="a9751-111">**RemoteSystemWatcher** オブジェクトを初期化する前か、その初期化中に、フィルター オブジェクトを作成する必要があります。コンストラクターにパラメーターとして渡されるためです。</span><span class="sxs-lookup"><span data-stu-id="a9751-111">Filter objects must be constructed before or while the **RemoteSystemWatcher** object is initialized, because they are passed as a parameter into its constructor.</span></span> <span data-ttu-id="a9751-112">次のコードでは、利用可能な各種類のフィルターを作成し、一覧に追加します。</span><span class="sxs-lookup"><span data-stu-id="a9751-112">The following code creates a filter of each type available and then adds them to a list.</span></span>

> [!NOTE]
> <span data-ttu-id="a9751-113">この例のコードでは、ファイルに `using Windows.System.RemoteSystems` ステートメントがあることを利用としています。</span><span class="sxs-lookup"><span data-stu-id="a9751-113">The code in these examples requires that you have a `using Windows.System.RemoteSystems` statement in your file.</span></span>

[!code-cs[Main](./code/DiscoverDevices/MainPage.xaml.cs#SnippetMakeFilterList)]

> [!NOTE]
> <span data-ttu-id="a9751-114">"proximal" フィルター値は、物理的な近さの度合いを保証するものではありません。</span><span class="sxs-lookup"><span data-stu-id="a9751-114">The "proximal" filter value does not guarantee the degree of physical proximity.</span></span> <span data-ttu-id="a9751-115">確実に物理的に近いことが求められるシナリオでは、フィルターに [**RemoteSystemDiscoveryType.SpatiallyProximal**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemdiscoverytype) を使用します。</span><span class="sxs-lookup"><span data-stu-id="a9751-115">For scenarios that require reliable physical proximity, use the value [**RemoteSystemDiscoveryType.SpatiallyProximal**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemdiscoverytype) in your filter.</span></span> <span data-ttu-id="a9751-116">現時点では、このフィルターで許容されるデバイスは Bluetooth 経由で検出されたものに限られます。</span><span class="sxs-lookup"><span data-stu-id="a9751-116">Currently, this filter only allows devices that are discovered by Bluetooth.</span></span> <span data-ttu-id="a9751-117">物理的に隣接していることを保証する新しい検出メカニズムとプロトコルがサポートされたら、このフィルターにも組み込まれます。</span><span class="sxs-lookup"><span data-stu-id="a9751-117">As new discovery mechanisms and protocols which guarantee physical proximity are supported, they will be included here as well.</span></span>  
<span data-ttu-id="a9751-118">プロパティがありますも、 [ **RemoteSystem** ](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystem)クラスを検出されたデバイスが実際の物理的近接内かどうかを示します。[**RemoteSystem.IsAvailableBySpatialProximity**](https://docs.microsoft.com/uwp/api/Windows.System.RemoteSystems.RemoteSystem.IsAvailableByProximity)します。</span><span class="sxs-lookup"><span data-stu-id="a9751-118">There is also a property in the [**RemoteSystem**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystem) class that indicates whether a discovered device is in fact within physical proximity: [**RemoteSystem.IsAvailableBySpatialProximity**](https://docs.microsoft.com/uwp/api/Windows.System.RemoteSystems.RemoteSystem.IsAvailableByProximity).</span></span>

> [!NOTE]
> <span data-ttu-id="a9751-119">ローカル ネットワーク経由でデバイスを検出する場合 (検出の種類のフィルターの選択で決定されます)、ネットワークで "プライベート" または "ドメイン" プロファイルを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a9751-119">If you intend to discover devices over a local network (determined by your discovery type filter selection), your network needs to be using a "private" or "domain" profile.</span></span> <span data-ttu-id="a9751-120">デバイスでは、"パブリック" ネットワーク経由で他のデバイスを検出しません。</span><span class="sxs-lookup"><span data-stu-id="a9751-120">Your device will not discover other devices over a "public" network.</span></span>

<span data-ttu-id="a9751-121">[  **IRemoteSystemFilter**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.IRemoteSystemFilter) オブジェクトの一覧を作成すると、**RemoteSystemWatcher** のコンストラクターに渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="a9751-121">Once a list of [**IRemoteSystemFilter**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.IRemoteSystemFilter) objects is created, it can be passed into the constructor of a **RemoteSystemWatcher**.</span></span>

[!code-cs[Main](./code/DiscoverDevices/MainPage.xaml.cs#SnippetCreateWatcher)]

<span data-ttu-id="a9751-122">このウォッチャーの [**Start**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemWatcher.Start) メソッドが呼び出されると、次の条件を満たすデバイスが検出された場合のみ [**RemoteSystemAdded**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemWatcher.RemoteSystemAdded) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="a9751-122">When this watcher's [**Start**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemWatcher.Start) method is called, it will raise the [**RemoteSystemAdded**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemWatcher.RemoteSystemAdded) event only if a device is detected that meets all of the following criteria:</span></span>
* <span data-ttu-id="a9751-123">近接接続によって検出可能</span><span class="sxs-lookup"><span data-stu-id="a9751-123">It is discoverable by proximal connection</span></span>
* <span data-ttu-id="a9751-124">デスクトップまたは携帯電話である</span><span class="sxs-lookup"><span data-stu-id="a9751-124">It is a desktop or phone</span></span>
* <span data-ttu-id="a9751-125">利用可能として分類されている</span><span class="sxs-lookup"><span data-stu-id="a9751-125">It is classified as available</span></span>

<span data-ttu-id="a9751-126">これ以降、イベントの処理、[**RemoteSystem**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystem) オブジェクトの取得、リモート デバイスへの接続の手順は「[リモート アプリの起動](launch-a-remote-app.md)」とまったく同じ手順です。</span><span class="sxs-lookup"><span data-stu-id="a9751-126">From there, the procedure for handling events, retrieving [**RemoteSystem**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystem) objects, and connecting to remote devices is exactly the same as in [Launch a remote app](launch-a-remote-app.md).</span></span> <span data-ttu-id="a9751-127">つまり、**RemoteSystem** オブジェクトは、各 **RemoteSystemAdded** イベントで渡される [**RemoteSystemAddedEventArgs**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemAddedEventArgs) オブジェクトのプロパティとして格納されます。</span><span class="sxs-lookup"><span data-stu-id="a9751-127">In short, the **RemoteSystem** objects are stored as properties of [**RemoteSystemAddedEventArgs**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemAddedEventArgs) objects, which are passed in with each **RemoteSystemAdded** event.</span></span>

## <a name="discover-devices-by-address-input"></a><span data-ttu-id="a9751-128">アドレス入力によるデバイスの検出</span><span class="sxs-lookup"><span data-stu-id="a9751-128">Discover devices by address input</span></span>
<span data-ttu-id="a9751-129">ユーザーに関連付けられていないか、スキャンで検出することができないデバイスでも、検出側のアプリが直接アドレスを使う場合はアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="a9751-129">Some devices may not be associated with a user or discoverable with a scan, but they can still be reached if the discovering app uses a direct address.</span></span> <span data-ttu-id="a9751-130">リモート デバイスのアドレスを表すには、[**HostName**](https://msdn.microsoft.com/library/windows/apps/windows.networking.hostname.aspx) クラスを使います。</span><span class="sxs-lookup"><span data-stu-id="a9751-130">The [**HostName**](https://msdn.microsoft.com/library/windows/apps/windows.networking.hostname.aspx) class is used to represent the address of a remote device.</span></span> <span data-ttu-id="a9751-131">これは多くの場合 IP アドレスの形式で保存されますが、他のいくつかの形式も使うことができます (詳しくは、「[**HostName コンス トラクター**](https://msdn.microsoft.com/library/windows/apps/br207118.aspx)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="a9751-131">This is often stored in the form of an IP address, but several other formats are allowed (see the [**HostName constructor**](https://msdn.microsoft.com/library/windows/apps/br207118.aspx) for details).</span></span>

<span data-ttu-id="a9751-132">**RemoteSystem** オブジェクトは、有効な **HostName** オブジェクトが指定された場合に取得されます。</span><span class="sxs-lookup"><span data-stu-id="a9751-132">A **RemoteSystem** object is retrieved if a valid **HostName** object is provided.</span></span> <span data-ttu-id="a9751-133">アドレス データが無効な場合、`null` オブジェクト参照が返されます。</span><span class="sxs-lookup"><span data-stu-id="a9751-133">If the address data is invalid, a `null` object reference is returned.</span></span>

[!code-cs[Main](./code/DiscoverDevices/MainPage.xaml.cs#SnippetFindByHostName)]

## <a name="querying-a-capability-on-a-remote-system"></a><span data-ttu-id="a9751-134">リモート システムの機能の照会</span><span class="sxs-lookup"><span data-stu-id="a9751-134">Querying a capability on a remote system</span></span>

<span data-ttu-id="a9751-135">検出フィルタリングからは分離されていますが、デバイスの機能を照会することが検出プロセスの重要な要素になることがあります。</span><span class="sxs-lookup"><span data-stu-id="a9751-135">Although separate from discovery filtering, querying device capabilities can be an important part of the discovery process.</span></span> <span data-ttu-id="a9751-136">[  **RemoteSystem.GetCapabilitySupportedAsync**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystem.GetCapabilitySupportedAsync) メソッドを使うと、リモート セッション接続や空間エンティティ (ホログラフィック) 共有などの特定の機能が、検出されたリモートシステムでサポートされているかどうかを照会できます。</span><span class="sxs-lookup"><span data-stu-id="a9751-136">Using the [**RemoteSystem.GetCapabilitySupportedAsync**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystem.GetCapabilitySupportedAsync) method, you can query discovered remote systems for support of certain capabilities such as remote session connectivity or spatial entity (holographic) sharing.</span></span> <span data-ttu-id="a9751-137">照会可能な機能の一覧については、[**KnownRemoteSystemCapabilities**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.knownremotesystemcapabilities) クラスをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a9751-137">See the [**KnownRemoteSystemCapabilities**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.knownremotesystemcapabilities) class for the list of queryable capabilities.</span></span>

```csharp
// Check to see if the given remote system can accept LaunchUri requests
bool isRemoteSystemLaunchUriCapable = remoteSystem.GetCapabilitySupportedAsync(KnownRemoteSystemCapabilities.LaunchUri);
```

## <a name="cross-user-discovery"></a><span data-ttu-id="a9751-138">ユーザー間の検出</span><span class="sxs-lookup"><span data-stu-id="a9751-138">Cross-user discovery</span></span>

<span data-ttu-id="a9751-139">開発者は、同一ユーザーに登録されているデバイスだけでなく、クライアント デバイスの近くにある_すべての_デバイスを検出するように指定できます。</span><span class="sxs-lookup"><span data-stu-id="a9751-139">Developers can specify the discovery of _all_ devices in proximity to the client device, not just devices registered to the same user.</span></span> <span data-ttu-id="a9751-140">これは、特別な **IRemoteSystemFilter** である、[**RemoteSystemAuthorizationKindFilter**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemauthorizationkindfilter) を通じて実装されます。</span><span class="sxs-lookup"><span data-stu-id="a9751-140">This is implemented through a special **IRemoteSystemFilter**, [**RemoteSystemAuthorizationKindFilter**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemauthorizationkindfilter).</span></span> <span data-ttu-id="a9751-141">その実装は、他の種類のフィルターと同じように行われます。</span><span class="sxs-lookup"><span data-stu-id="a9751-141">It is implemented like the other filter types:</span></span>

```csharp
// Construct a user type filter that includes anonymous devices
RemoteSystemAuthorizationKindFilter authorizationKindFilter = new RemoteSystemAuthorizationKindFilter(RemoteSystemAuthorizationKind.Anonymous);
// then add this filter to the RemoteSystemWatcher
```

* <span data-ttu-id="a9751-142">[  **RemoteSystemAuthorizationKind**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemauthorizationkind) の値 **Anonymous** では、信頼されていないユーザーのデバイスも含めて、すべての近接デバイスを検出できるようになります。</span><span class="sxs-lookup"><span data-stu-id="a9751-142">A [**RemoteSystemAuthorizationKind**](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemauthorizationkind) value of **Anonymous** will allow the discovery of all proximal devices, even those from non-trusted users.</span></span>
* <span data-ttu-id="a9751-143">値 **SameUser** では、クライアント デバイスと同じユーザーに登録されているデバイスのみを検出するようにフィルター処理が行われます。</span><span class="sxs-lookup"><span data-stu-id="a9751-143">A value of **SameUser** filters the discovery to only devices registered to the same user as the client device.</span></span> <span data-ttu-id="a9751-144">これは既定の動作です。</span><span class="sxs-lookup"><span data-stu-id="a9751-144">This is the default behavior.</span></span>

### <a name="checking-the-cross-user-sharing-settings"></a><span data-ttu-id="a9751-145">ユーザー間共有設定の確認</span><span class="sxs-lookup"><span data-stu-id="a9751-145">Checking the Cross-User Sharing settings</span></span>

<span data-ttu-id="a9751-146">サインイン済みのデバイスで他のユーザーとエクスペリエンスを共有できるようにするには、検出アプリで上記のフィルターを指定することに加えて、クライアント デバイス自体の構成も必要になります。</span><span class="sxs-lookup"><span data-stu-id="a9751-146">In addition to the above filter being specified in your discovery app, the client device itself must also be configured to allow shared experiences from devices signed in with other users.</span></span> <span data-ttu-id="a9751-147">このシステム設定は、次のように **RemoteSystem** クラスで静的メソッドを使用することで照会できます。</span><span class="sxs-lookup"><span data-stu-id="a9751-147">This is a system setting that can be queried with a static method in the **RemoteSystem** class:</span></span>

```csharp
if (!RemoteSystem.IsAuthorizationKindEnabled(RemoteSystemAuthorizationKind.Anonymous)) {
    // The system is not authorized to connect to cross-user devices. 
    // Inform the user that they can discover more devices if they
    // update the setting to "Anonymous".
}
```

<span data-ttu-id="a9751-148">この設定を変更するには、ユーザーが**設定**アプリを開く必要があります。</span><span class="sxs-lookup"><span data-stu-id="a9751-148">To change this setting, the user must open the **Settings** app.</span></span> <span data-ttu-id="a9751-149">**[システム]** > **[共有エクスペリエンス]** > **[デバイス間で共有します]** メニューの順に移動すると、システムで共有可能なデバイスをユーザーが指定できるドロップダウン ボックスがあります。</span><span class="sxs-lookup"><span data-stu-id="a9751-149">In the **System** > **Shared experiences** > **Share across devices** menu, there is a drop-down box where the user can specify which devices their system can share with.</span></span>

![[共有エクスペリエンス] 設定ページ](images/shared-experiences-settings.png)

## <a name="related-topics"></a><span data-ttu-id="a9751-151">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a9751-151">Related topics</span></span>
* [<span data-ttu-id="a9751-152">接続されているアプリとデバイス (プロジェクト ローマ)</span><span class="sxs-lookup"><span data-stu-id="a9751-152">Connected apps and devices (Project Rome)</span></span>](connected-apps-and-devices.md)
* [<span data-ttu-id="a9751-153">リモート アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="a9751-153">Launch a remote app</span></span>](launch-a-remote-app.md)
* [<span data-ttu-id="a9751-154">リモート システムの API のリファレンス</span><span class="sxs-lookup"><span data-stu-id="a9751-154">Remote Systems API reference</span></span>](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems)
* [<span data-ttu-id="a9751-155">リモート システムのサンプル</span><span class="sxs-lookup"><span data-stu-id="a9751-155">Remote Systems sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/RemoteSystems)
