---
author: msatranjr
title: Bluetooth GATT サーバー
description: この記事では、一般的な用途のサンプル コードでと一緒に、ユニバーサル Windows プラットフォーム (UWP) アプリの Bluetooth 汎用属性プロファイル (GATT) サーバーの概要を示します。
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: b8a941b7b80bd5d34e88798ec586d9c1d52e2887
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6024446"
---
# <a name="bluetooth-gatt-server"></a><span data-ttu-id="07b7f-104">Bluetooth GATT サーバー</span><span class="sxs-lookup"><span data-stu-id="07b7f-104">Bluetooth GATT Server</span></span>


**<span data-ttu-id="07b7f-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="07b7f-105">Important APIs</span></span>**
- [**<span data-ttu-id="07b7f-106">Windows.Devices.Bluetooth</span><span class="sxs-lookup"><span data-stu-id="07b7f-106">Windows.Devices.Bluetooth</span></span>**](https://msdn.microsoft.com/library/windows/apps/Dn263413)
- [**<span data-ttu-id="07b7f-107">Windows.Devices.Bluetooth.GenericAttributeProfile</span><span class="sxs-lookup"><span data-stu-id="07b7f-107">Windows.Devices.Bluetooth.GenericAttributeProfile</span></span>**](https://msdn.microsoft.com/library/windows/apps/Dn297685)


<span data-ttu-id="07b7f-108">この記事では、一般的な GATT サーバー タスクのサンプル コードでと一緒に、ユニバーサル Windows プラットフォーム (UWP) アプリ用の Bluetooth Generic Attribute (GATT) サーバーの Api を示しています。</span><span class="sxs-lookup"><span data-stu-id="07b7f-108">This article demonstrates Bluetooth Generic Attribute (GATT) Server APIs for Universal Windows Platform (UWP) apps, along with sample code for common GATT server tasks:</span></span> 
- <span data-ttu-id="07b7f-109">サポートされているサービスを定義します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-109">Define the supported services</span></span>
- <span data-ttu-id="07b7f-110">リモート クライアントが検出できるようにサーバーを公開します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-110">Publish server so it can be discovered by remote clients</span></span>
- <span data-ttu-id="07b7f-111">サービスのサポートを提供します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-111">Advertise support for service</span></span>
- <span data-ttu-id="07b7f-112">読み取りし、書き込み要求に応答するには</span><span class="sxs-lookup"><span data-stu-id="07b7f-112">Respond to read and write requests</span></span>
- <span data-ttu-id="07b7f-113">サブスクライブしているクライアントに通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-113">Send notifications to subscribed clients</span></span>

## <a name="overview"></a><span data-ttu-id="07b7f-114">概要</span><span class="sxs-lookup"><span data-stu-id="07b7f-114">Overview</span></span>
<span data-ttu-id="07b7f-115">Windows は、通常、クライアントの役割で動作します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-115">Windows usually operates in the client role.</span></span> <span data-ttu-id="07b7f-116">それでも、Bluetooth LE GATT サーバーもとして機能する Windows 不要となる多くのシナリオが発生します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-116">Nevertheless, many scenarios arise which require Windows to act as a Bluetooth LE GATT Server as well.</span></span> <span data-ttu-id="07b7f-117">IoT デバイスでは、ほとんどのクロス プラットフォーム BLE 通信と共に、ほぼすべてのシナリオは、Windows GATT サーバーを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="07b7f-117">Almost all the scenarios for IoT devices, along with most cross-platform BLE communication will require Windows to be a GATT Server.</span></span> <span data-ttu-id="07b7f-118">さらに、近くにあるウェアラブル デバイスへの通知の送信にも、このテクノロジを必要とする一般的なシナリオとなっています。</span><span class="sxs-lookup"><span data-stu-id="07b7f-118">Additionally, sending notifications to nearby wearable devices has become a popular scenario that requires this technology as well.</span></span>  
> <span data-ttu-id="07b7f-119">[GATT クライアント ドキュメント](gatt-client.md)の最新情報のすべての概念が先に進む前にオフにすることを確認します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-119">Make sure all the concepts in the [GATT Client docs](gatt-client.md) are clear before proceeding.</span></span>  

<span data-ttu-id="07b7f-120">サーバーの運用は、サービス プロバイダーと、GattLocalCharacteristic によって中心です。</span><span class="sxs-lookup"><span data-stu-id="07b7f-120">Server operations will revolve around the Service Provider and the GattLocalCharacteristic.</span></span> <span data-ttu-id="07b7f-121">これら 2 つのクラスを宣言し、実装し、リモート デバイスへのデータの階層を公開するために必要な機能が提供されます。</span><span class="sxs-lookup"><span data-stu-id="07b7f-121">These two classes will provide the functionality needed to declare, implement and expose a heirarchy of data to a remote device.</span></span>

## <a name="define-the-supported-services"></a><span data-ttu-id="07b7f-122">サポートされているサービスを定義します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-122">Define the supported services</span></span>
<span data-ttu-id="07b7f-123">アプリが Windows によって公開される 1 つまたは複数のサービスを宣言できます。</span><span class="sxs-lookup"><span data-stu-id="07b7f-123">Your app may declare one or more services that will be published by Windows.</span></span> <span data-ttu-id="07b7f-124">各サービスは、UUID を一意に識別します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-124">Each service is uniquely identified by a UUID.</span></span> 

### <a name="attributes-and-uuids"></a><span data-ttu-id="07b7f-125">属性と Uuid</span><span class="sxs-lookup"><span data-stu-id="07b7f-125">Attributes and UUIDs</span></span>
<span data-ttu-id="07b7f-126">各サービス、特性、記述子が定義されているが、独自の一意の 128 ビット UUID します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-126">Each service, characteristic and descriptor is defined by it's own unique 128-bit UUID.</span></span>
> <span data-ttu-id="07b7f-127">GUID、という用語を使用してすべての Windows Api が、標準の Bluetooth が Uuid としてこれらを定義します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-127">The Windows APIs all use the term GUID, but the Bluetooth standard defines these as UUIDs.</span></span> <span data-ttu-id="07b7f-128">今回は、これら 2 つの用語は入れ替え可能であるが引き続き UUID 用語を使用するようにします。</span><span class="sxs-lookup"><span data-stu-id="07b7f-128">For our purposes, these two terms are interchangeable so we'll continue to use the term UUID.</span></span> 

<span data-ttu-id="07b7f-129">属性が標準および Bluetooth SIG 定義で定義されている場合は、対応する、16 ビットの短い ID がありますも (例: 0000**2A19**は、バッテリ レベル UUID-0000-1000-8000-00805F9B34FB と短い ID は 0x2A19)。</span><span class="sxs-lookup"><span data-stu-id="07b7f-129">If the attribute is standard and defined by the Bluetooth SIG-defined, it will also have a corresponding 16-bit short ID (e.g. Battery Level UUID  is 0000**2A19**-0000-1000-8000-00805F9B34FB and the short ID is 0x2A19).</span></span> <span data-ttu-id="07b7f-130">これらの標準的な Uuid は、 [GattServiceUuids](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.genericattributeprofile.gattserviceuuids.aspx)と[GattCharacteristicUuids](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.genericattributeprofile.gattcharacteristicuuids.aspx)で確認できます。</span><span class="sxs-lookup"><span data-stu-id="07b7f-130">These standard UUIDs can be seen in [GattServiceUuids](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.genericattributeprofile.gattserviceuuids.aspx) and [GattCharacteristicUuids](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.genericattributeprofile.gattcharacteristicuuids.aspx).</span></span>

<span data-ttu-id="07b7f-131">アプリを実装する場合は、独自のカスタム サービスは、カスタム UUID が生成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="07b7f-131">If your app is implementing it's own custom service, a custom UUID will have to be generated.</span></span> <span data-ttu-id="07b7f-132">これは、簡単に行うツールを使って Visual Studio で]-> [CreateGuid (使用オプション 5"xxxx」という-xxxx-."の形式で入手する)。</span><span class="sxs-lookup"><span data-stu-id="07b7f-132">This is easily done in Visual Studio through Tools -> CreateGuid (use option 5 to get it in the "xxxxxxxx-xxxx-...xxxx" format).</span></span> <span data-ttu-id="07b7f-133">この uuid は、新しいローカル サービス、特性、または記述子を宣言するようになりました使用できます。</span><span class="sxs-lookup"><span data-stu-id="07b7f-133">This uuid can now be used to declare new local services, characteristics or descriptors.</span></span>

#### <a name="restricted-services"></a><span data-ttu-id="07b7f-134">制限付きのサービス</span><span class="sxs-lookup"><span data-stu-id="07b7f-134">Restricted Services</span></span>
<span data-ttu-id="07b7f-135">次のサービスは、システムによって予約されており、この時点で公開されることはできません。</span><span class="sxs-lookup"><span data-stu-id="07b7f-135">The following Services are reserved by the system and cannot be published at this time:</span></span>
1. <span data-ttu-id="07b7f-136">デバイス情報サービス (無効)</span><span class="sxs-lookup"><span data-stu-id="07b7f-136">Device Information Service (DIS)</span></span>
2. <span data-ttu-id="07b7f-137">汎用属性プロファイル サービス (GATT)</span><span class="sxs-lookup"><span data-stu-id="07b7f-137">Generic Attribute Profile Service (GATT)</span></span>
3. <span data-ttu-id="07b7f-138">汎用的なアクセス Profile サービス (ギャップ)</span><span class="sxs-lookup"><span data-stu-id="07b7f-138">Generic Access Profile Service (GAP)</span></span>
4. <span data-ttu-id="07b7f-139">ヒューマン インターフェイス デバイス サービス (HOGP)</span><span class="sxs-lookup"><span data-stu-id="07b7f-139">Human Interface Device Service (HOGP)</span></span>
5. <span data-ttu-id="07b7f-140">スキャン パラメーター サービス (SCP)</span><span class="sxs-lookup"><span data-stu-id="07b7f-140">Scan Parameters Service (SCP)</span></span>

> <span data-ttu-id="07b7f-141">ブロックされているサービスを作成しようとすると、CreateAsync への呼び出しから返される BluetoothError.DisabledByPolicy が発生します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-141">Attempting to create a blocked service will result in BluetoothError.DisabledByPolicy being returned from the call to CreateAsync.</span></span>

#### <a name="generated-attributes"></a><span data-ttu-id="07b7f-142">生成された属性</span><span class="sxs-lookup"><span data-stu-id="07b7f-142">Generated Attributes</span></span>
<span data-ttu-id="07b7f-143">次の記述子は、特性の作成時に提供される GattLocalCharacteristicParameters に基づいて、システムによって自動的に生成します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-143">The following descriptors are autogenerated by the system, based on the GattLocalCharacteristicParameters provided during creation of the characteristic:</span></span>
1. <span data-ttu-id="07b7f-144">クライアントの特性の構成 (indicatable または通知用として、特性が付いている) 場合。</span><span class="sxs-lookup"><span data-stu-id="07b7f-144">Client Characteristic Configuration (if the characteristic is marked as indicatable or notifiable).</span></span>
2. <span data-ttu-id="07b7f-145">特性ユーザー説明 (場合いることのプロパティが設定されます)。</span><span class="sxs-lookup"><span data-stu-id="07b7f-145">Characteristic User Description (if UserDescription property is set).</span></span> <span data-ttu-id="07b7f-146">詳しくは、GattLocalCharacteristicParameters.UserDescription プロパティを参照してください。</span><span class="sxs-lookup"><span data-stu-id="07b7f-146">See GattLocalCharacteristicParameters.UserDescription property for more info.</span></span>
3. <span data-ttu-id="07b7f-147">特性の形式 (指定された各プレゼンテーション形式の 1 つの記述子)。</span><span class="sxs-lookup"><span data-stu-id="07b7f-147">Characteristic Format (one descriptor for each presentation format specified).</span></span>  <span data-ttu-id="07b7f-148">詳しくは、GattLocalCharacteristicParameters.PresentationFormats プロパティを参照してください。</span><span class="sxs-lookup"><span data-stu-id="07b7f-148">See GattLocalCharacteristicParameters.PresentationFormats property for more info.</span></span>
4. <span data-ttu-id="07b7f-149">特性集計形式 (1 つ以上の形式が指定されます)。</span><span class="sxs-lookup"><span data-stu-id="07b7f-149">Characteristic Aggregate Format (if more than one presentation format is specified).</span></span>  <span data-ttu-id="07b7f-150">詳しくは GattLocalCharacteristicParameters.See PresentationFormats プロパティです。</span><span class="sxs-lookup"><span data-stu-id="07b7f-150">GattLocalCharacteristicParameters.See PresentationFormats property for more info.</span></span>
5. <span data-ttu-id="07b7f-151">(特性には、拡張プロパティのビットが付いている) 場合、特性のことに拡張プロパティ。</span><span class="sxs-lookup"><span data-stu-id="07b7f-151">Characteristic Extended Properties (if the characteristic is marked with the extended properties bit).</span></span>

> <span data-ttu-id="07b7f-152">拡張プロパティ記述子の値は ReliableWrites と WritableAuxiliaries 特性プロパティによって決まります。</span><span class="sxs-lookup"><span data-stu-id="07b7f-152">The value of the Extended Properties descriptor is determined via the ReliableWrites and WritableAuxiliaries characteristic properties.</span></span>

> <span data-ttu-id="07b7f-153">予約済みの記述子を作成しようとすると、例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-153">Attempting to create a reserved descriptor will result in an exception.</span></span>

> <span data-ttu-id="07b7f-154">この時点では、ブロードキャストの注はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="07b7f-154">Note that broadcast is not supported at this time.</span></span>  <span data-ttu-id="07b7f-155">ブロードキャスト GattCharacteristicProperty を指定すると、例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-155">Specifying the Broadcast GattCharacteristicProperty will result in an exception.</span></span>

### <a name="build-up-the-heirarchy-of-services-and-characteristics"></a><span data-ttu-id="07b7f-156">サービスと特性についての階層を作成します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-156">Build up the heirarchy of services and characteristics</span></span>
<span data-ttu-id="07b7f-157">作成して、ルートの主要なサービスの定義を提供する、GattServiceProvider を使用します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-157">The GattServiceProvider is used to create and advertise the root primary service definition.</span></span>  <span data-ttu-id="07b7f-158">各サービスでは、GUID では、独自のサービス プロバイダー オブジェクトである必要があります。</span><span class="sxs-lookup"><span data-stu-id="07b7f-158">Each service requires it's own ServiceProvider object that takes in a GUID:</span></span> 

```csharp
GattServiceProviderResult result = await GattServiceProvider.CreateAsync(uuid);

if (result.Error == BluetoothError.Success)
{
    serviceProvider = result.ServiceProvider;
    // 
}
```
> <span data-ttu-id="07b7f-159">プライマリ サービスは、GATT ツリーの最上位レベルです。</span><span class="sxs-lookup"><span data-stu-id="07b7f-159">Primary services are the top level of the GATT tree.</span></span> <span data-ttu-id="07b7f-160">プライマリ サービスには、('含める' またはセカンダリのサービスと呼ばれます)、その他のサービスと特性が含まれます。</span><span class="sxs-lookup"><span data-stu-id="07b7f-160">Primary services contain characteristics as well as other services (called 'Included' or secondary services).</span></span> 

<span data-ttu-id="07b7f-161">これで、必要な特性、記述子とサービスを設定します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-161">Now, populate the service with the required characteristics and descriptors:</span></span>

```csharp
GattLocalCharacteristicResult characteristicResult = await serviceProvider.Service.CreateCharacteristicAsync(uuid1, ReadParameters);
if (characteristicResult.Error != BluetoothError.Success)
{
    // An error occurred.
    return;
}
_readCharacteristic = characteristicResult.Characteristic;
_readCharacteristic.ReadRequested += ReadCharacteristic_ReadRequested;

characteristicResult = await serviceProvider.Service.CreateCharacteristicAsync(uuid2, WriteParameters);
if (characteristicResult.Error != BluetoothError.Success)
{
    // An error occurred.
    return;
}
_writeCharacteristic = characteristicResult.Characteristic;
_writeCharacteristic.WriteRequested += WriteCharacteristic_WriteRequested;

characteristicResult = await serviceProvider.Service.CreateCharacteristicAsync(uuid3, NotifyParameters);
if (characteristicResult.Error != BluetoothError.Success)
{
    // An error occurred.
    return;
}
_notifyCharacteristic = characteristicResult.Characteristic;
_notifyCharacteristic.SubscribedClientsChanged += SubscribedClientsChanged;
```
<span data-ttu-id="07b7f-162">上記のように、このも各特性がサポートする操作用のイベント ハンドラーを宣言するに適しています。</span><span class="sxs-lookup"><span data-stu-id="07b7f-162">As shown above, this is also a good place to declare event handlers for the operations each characteristic supports.</span></span>  <span data-ttu-id="07b7f-163">正常に要求に応答するアプリがする必要があります定義され、属性は、サポート要求の種類ごとにイベント ハンドラーを設定します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-163">To respond to requests correctly, an app must defined and set an event handler for each request type the attribute supports.</span></span>  <span data-ttu-id="07b7f-164">ハンドラーを登録に失敗すると、システムで*UnlikelyError*をすぐに完了する要求が発生します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-164">Failing to register a handler will result in the request being completed immediately with *UnlikelyError* by the system.</span></span>

### <a name="constant-characteristics"></a><span data-ttu-id="07b7f-165">定数の特性</span><span class="sxs-lookup"><span data-stu-id="07b7f-165">Constant characteristics</span></span>
<span data-ttu-id="07b7f-166">場合によっては、これには、アプリの有効期間中は変更されません特性値があります。</span><span class="sxs-lookup"><span data-stu-id="07b7f-166">Sometimes, there are characteristic values that will not change during the course of the app's lifetime.</span></span> <span data-ttu-id="07b7f-167">その場合は、不要なアプリのアクティブ化を防ぐために定数の特性を宣言することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="07b7f-167">In that case, it is advisable to declare a constant characteristic to prevent unnecessary app activation:</span></span> 

```csharp
byte[] value = new byte[] {0x21};
var constantParameters = new GattLocalCharacteristicParameters
{
    CharacteristicProperties = (GattCharacteristicProperties.Read),
    StaticValue = value.AsBuffer(),
    ReadProtectionLevel = GattProtectionLevel.Plain,
};

var characteristicResult = await serviceProvider.Service.CreateCharacteristicAsync(uuid4, constantParameters);
if (characteristicResult.Error != BluetoothError.Success)
{
    // An error occurred.
    return;
}
```
## <a name="publish-the-service"></a><span data-ttu-id="07b7f-168">サービスを公開します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-168">Publish the service</span></span>
<span data-ttu-id="07b7f-169">サービスが完全に定義した後、次の手順では、サービスのサポートを公開します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-169">Once the service has been fully defined, the next step is to publish support for the service.</span></span> <span data-ttu-id="07b7f-170">リモート デバイス サービス検出を実行するときに、サービスが返されることを OS に通知されます。</span><span class="sxs-lookup"><span data-stu-id="07b7f-170">This informs the OS that the service should be returned when remote devices perform a service discovery.</span></span>  <span data-ttu-id="07b7f-171">-IsDiscoverable と IsConnectable の 2 つのプロパティを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="07b7f-171">You will have to set two properties - IsDiscoverable and IsConnectable:</span></span>  

```csharp
GattServiceProviderAdvertisingParameters advParameters = new GattServiceProviderAdvertisingParameters
{
    IsDiscoverable = true,
    IsConnectable = true
};
serviceProvider.StartAdvertising(advParameters);
```
- <span data-ttu-id="07b7f-172">**IsDiscoverable**: にデバイスを検出する、アドバタイズのリモート デバイスのフレンドリ名をアドバタイズします。</span><span class="sxs-lookup"><span data-stu-id="07b7f-172">**IsDiscoverable**: Advertises the friendly name to remote devices in the advertisement, making the device discoverable.</span></span>
- <span data-ttu-id="07b7f-173">**IsConnectable**: 周辺機器ロールで使用するための接続可能な広告をアドバタイズします。</span><span class="sxs-lookup"><span data-stu-id="07b7f-173">**IsConnectable**:  Advertises a connectable advertisement for use in peripheral role.</span></span>

> <span data-ttu-id="07b7f-174">サービスは、検出可能と Connectable の両方が、システムは、広告のパケットをサービス Uuid を追加します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-174">When a service is both Discoverable and Connectable, the system will add the Service Uuid to the advertisement packet.</span></span>  <span data-ttu-id="07b7f-175">広告パケットに 31 バイトだけがあり、それらの 16 占有 128 ビット UUID!</span><span class="sxs-lookup"><span data-stu-id="07b7f-175">There are only 31 bytes in the Advertisement packet and a 128-bit UUID takes up 16 of them!</span></span>

> <span data-ttu-id="07b7f-176">いるサービスがフォア グラウンドで公開されてから、アプリケーション呼び出す必要があります StopAdvertising アプリケーションが中断するときに注意してください。</span><span class="sxs-lookup"><span data-stu-id="07b7f-176">Note that when a service is published in the foreground, an application must call StopAdvertising when the application suspends.</span></span>

## <a name="respond-to-read-and-write-requests"></a><span data-ttu-id="07b7f-177">読み取りし、書き込み要求に応答するには</span><span class="sxs-lookup"><span data-stu-id="07b7f-177">Respond to Read and Write requests</span></span>
<span data-ttu-id="07b7f-178">必要な特性を宣言するときに、上で見た、として GattLocalCharacteristics はイベント - ReadRequested、WriteRequested および SubscribedClientsChanged の 3 種類があります。</span><span class="sxs-lookup"><span data-stu-id="07b7f-178">As we saw above while declaring the required characteristics, GattLocalCharacteristics have 3 types of events - ReadRequested, WriteRequested and SubscribedClientsChanged.</span></span>

### <a name="read"></a><span data-ttu-id="07b7f-179">Read</span><span class="sxs-lookup"><span data-stu-id="07b7f-179">Read</span></span>
<span data-ttu-id="07b7f-180">リモート デバイス特性から値を読み取るしようとする (および定数値ではない)、ReadRequested イベントが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="07b7f-180">When a remote device tries to read a value from a characteristic (and it's not a constant value), the ReadRequested event is called.</span></span> <span data-ttu-id="07b7f-181">(リモート デバイスに関する情報を含む) の引数およびに対して読み取りが呼び出された特性は、デリゲートに渡されます。</span><span class="sxs-lookup"><span data-stu-id="07b7f-181">The characteristic the read was called on as well as args (containing information about the remote device) is passed to the delegate:</span></span> 

```csharp
characteristic.ReadRequested += Characteristic_ReadRequested;
// ... 

async void ReadCharacteristic_ReadRequested(GattLocalCharacteristic sender, GattReadRequestedEventArgs args)
{
    var deferral = args.GetDeferral();
    
    // Our familiar friend - DataWriter.
    var writer = new DataWriter();
    // populate writer w/ some data. 
    // ... 

    var request = await args.GetRequestAsync();
    request.RespondWithValue(writer.DetachBuffer());
    
    deferral.Complete();
}
``` 

### <a name="write"></a><span data-ttu-id="07b7f-182">書き込み</span><span class="sxs-lookup"><span data-stu-id="07b7f-182">Write</span></span>
<span data-ttu-id="07b7f-183">リモート デバイスでは、特性値を書き込むしようとして、リモート デバイスの詳細がどの特性を記述して、値そのもので WriteRequested イベントが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="07b7f-183">When a remote device tries to write a value to a characteristic, the WriteRequested event is called with details about the remote device, which characteristic to write to and the value itself:</span></span> 

```csharp
characteristic.ReadRequested += Characteristic_ReadRequested;
// ...

async void WriteCharacteristic_WriteRequested(GattLocalCharacteristic sender, GattWriteRequestedEventArgs args)
{
    var deferral = args.GetDeferral();
    
    var request = await args.GetRequestAsync();
    var reader = DataReader.FromBuffer(request.Value);
    // Parse data as necessary. 

    if (request.Option == GattWriteOption.WriteWithResponse)
    {
        request.Respond();
    }
    
    deferral.Complete();
}
```
<span data-ttu-id="07b7f-184">-の書き込みと応答がない場合の 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="07b7f-184">There are 2 types of Writes - with and without response.</span></span> <span data-ttu-id="07b7f-185">GattWriteOption (GattWriteRequest オブジェクトのプロパティ) を使用して、リモート デバイスを実行する書き込みの種類を特定します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-185">Use GattWriteOption (a property on the GattWriteRequest object) to figure out which type of write the remote device is performing.</span></span> 

## <a name="send-notifications-to-subscribed-clients"></a><span data-ttu-id="07b7f-186">サブスクライブしているクライアントに通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-186">Send notifications to subscribed clients</span></span>
<span data-ttu-id="07b7f-187">最も一般的な GATT サーバーの運用、通知は、データをリモート デバイスにプッシュの重要な機能を実行します。</span><span class="sxs-lookup"><span data-stu-id="07b7f-187">The most frequent of the GATT Server operations, notifications perform the critical function of pushing data to the remote devices.</span></span> <span data-ttu-id="07b7f-188">場合によっては、すべてのサブスクライブしているクライアントが othertimes に新しい値を送信するには、どのデバイスを選択することを通知する必要があります。</span><span class="sxs-lookup"><span data-stu-id="07b7f-188">Sometimes, you'll want to notify all subscribed clients but othertimes you may want to pick which devices to send the new value to:</span></span> 

```csharp
async void NotifyValue()
{
    var writer = new DataWriter();
    // Populate writer with data
    // ...
    
    await notifyCharacteristic.NotifyValueAsync(writer.DetachBuffer());
}
```

<span data-ttu-id="07b7f-189">サブスクライブすると、新しいデバイスの通知、SubscribedClientsChanged イベントに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="07b7f-189">When a new device subscribes for notifications, the SubscribedClientsChanged event gets called:</span></span> 

```csharp
characteristic.SubscribedClientsChanged += SubscribedClientsChanged;
// ...

void _notifyCharacteristic_SubscribedClientsChanged(GattLocalCharacteristic sender, object args)
{
    List<GattSubscribedClient> clients = sender.SubscribedClients;
    // Diff the new list of clients from a previously saved one 
    // to get which device has subscribed for notifications. 

    // You can also just validate that the list of clients is expected for this app.  
}

```
> <span data-ttu-id="07b7f-190">アプリケーションが、通知の最大サイズを取得、MaxNotificationSize プロパティを使って特定のクライアントのことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="07b7f-190">Note that an application can get the maximum notification size for a particular client with the MaxNotificationSize property.</span></span>  <span data-ttu-id="07b7f-191">最大サイズよりも大きいすべてのデータは、システムによって切り捨てられます。</span><span class="sxs-lookup"><span data-stu-id="07b7f-191">Any data larger than the maximum size will be truncated by the system.</span></span>
