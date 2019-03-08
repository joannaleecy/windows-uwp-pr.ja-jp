---
title: Bluetooth GATT サーバー
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリ用の Bluetooth 汎用属性プロファイル (GATT) サーバーの概要と、一般的な使用事例のサンプル コードについて説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 551f8b925ffd56950ba893da7b81fefb4579f558
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57635137"
---
# <a name="bluetooth-gatt-server"></a><span data-ttu-id="1bd7a-104">Bluetooth GATT サーバー</span><span class="sxs-lookup"><span data-stu-id="1bd7a-104">Bluetooth GATT Server</span></span>


<span data-ttu-id="1bd7a-105">**重要な API**</span><span class="sxs-lookup"><span data-stu-id="1bd7a-105">**Important APIs**</span></span>
- [<span data-ttu-id="1bd7a-106">**Windows.Devices.Bluetooth**</span><span class="sxs-lookup"><span data-stu-id="1bd7a-106">**Windows.Devices.Bluetooth**</span></span>](https://msdn.microsoft.com/library/windows/apps/Dn263413)
- [<span data-ttu-id="1bd7a-107">**Windows.Devices.Bluetooth.GenericAttributeProfile**</span><span class="sxs-lookup"><span data-stu-id="1bd7a-107">**Windows.Devices.Bluetooth.GenericAttributeProfile**</span></span>](https://msdn.microsoft.com/library/windows/apps/Dn297685)


<span data-ttu-id="1bd7a-108">この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリ用の Bluetooth 汎用属性 (GATT) サーバー API を、一般的な GATT サーバー タスクのサンプル コードを使って示します。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-108">This article demonstrates Bluetooth Generic Attribute (GATT) Server APIs for Universal Windows Platform (UWP) apps, along with sample code for common GATT server tasks:</span></span> 
- <span data-ttu-id="1bd7a-109">サポートされるサービスの定義</span><span class="sxs-lookup"><span data-stu-id="1bd7a-109">Define the supported services</span></span>
- <span data-ttu-id="1bd7a-110">リモート クライアントで検出できるようにするためのサーバーの公開</span><span class="sxs-lookup"><span data-stu-id="1bd7a-110">Publish server so it can be discovered by remote clients</span></span>
- <span data-ttu-id="1bd7a-111">サービスのサポートのアドバタイズ</span><span class="sxs-lookup"><span data-stu-id="1bd7a-111">Advertise support for service</span></span>
- <span data-ttu-id="1bd7a-112">読み取り要求や書き込み要求への応答</span><span class="sxs-lookup"><span data-stu-id="1bd7a-112">Respond to read and write requests</span></span>
- <span data-ttu-id="1bd7a-113">受信登録しているクライアントへの通知の送信</span><span class="sxs-lookup"><span data-stu-id="1bd7a-113">Send notifications to subscribed clients</span></span>

## <a name="overview"></a><span data-ttu-id="1bd7a-114">概要</span><span class="sxs-lookup"><span data-stu-id="1bd7a-114">Overview</span></span>
<span data-ttu-id="1bd7a-115">Windows は、通常、クライアントの役割で動作します。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-115">Windows usually operates in the client role.</span></span> <span data-ttu-id="1bd7a-116">ただし、Windows を Bluetooth LE GATT サーバーとして動作させることが必要なシナリオが数多く発生します。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-116">Nevertheless, many scenarios arise which require Windows to act as a Bluetooth LE GATT Server as well.</span></span> <span data-ttu-id="1bd7a-117">多くのクロスプラットフォーム BLE 通信と共に、IoT デバイス向けのほとんどすべてのシナリオでは、Windows が GATT サーバーとして機能する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-117">Almost all the scenarios for IoT devices, along with most cross-platform BLE communication will require Windows to be a GATT Server.</span></span> <span data-ttu-id="1bd7a-118">さらに、近くのウェアラブル デバイスに通知を送信することも、このテクノロジを必要とする一般的なシナリオになっています。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-118">Additionally, sending notifications to nearby wearable devices has become a popular scenario that requires this technology as well.</span></span>  
> <span data-ttu-id="1bd7a-119">先に進む前に、[GATT クライアント ドキュメント](gatt-client.md)で説明されているすべての概念を理解していることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-119">Make sure all the concepts in the [GATT Client docs](gatt-client.md) are clear before proceeding.</span></span>  

<span data-ttu-id="1bd7a-120">サーバーの処理は、サービス プロバイダーと GattLocalCharacteristic を中心に実行されます。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-120">Server operations will revolve around the Service Provider and the GattLocalCharacteristic.</span></span> <span data-ttu-id="1bd7a-121">これら 2 つのクラス宣言、実装、およびリモート デバイスへのデータの階層を公開するために必要な機能が提供されます。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-121">These two classes will provide the functionality needed to declare, implement and expose a hierarchy of data to a remote device.</span></span>

## <a name="define-the-supported-services"></a><span data-ttu-id="1bd7a-122">サポートされるサービスの定義</span><span class="sxs-lookup"><span data-stu-id="1bd7a-122">Define the supported services</span></span>
<span data-ttu-id="1bd7a-123">アプリでは、Windows によって公開される 1 つまたは複数のサービスを宣言できます。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-123">Your app may declare one or more services that will be published by Windows.</span></span> <span data-ttu-id="1bd7a-124">各サービスは、UUID によって一意に識別されます。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-124">Each service is uniquely identified by a UUID.</span></span> 

### <a name="attributes-and-uuids"></a><span data-ttu-id="1bd7a-125">属性と UUID</span><span class="sxs-lookup"><span data-stu-id="1bd7a-125">Attributes and UUIDs</span></span>
<span data-ttu-id="1bd7a-126">各サービス、特性、記述子は、それぞれ一意の 128 ビット UUID によって定義されます。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-126">Each service, characteristic and descriptor is defined by it's own unique 128-bit UUID.</span></span>
> <span data-ttu-id="1bd7a-127">すべての Windows API では GUID という用語を使用しますが、Bluetooth の標準では、これらを UUID と定義しています。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-127">The Windows APIs all use the term GUID, but the Bluetooth standard defines these as UUIDs.</span></span> <span data-ttu-id="1bd7a-128">このドキュメントの説明では、これら 2 つの用語は入れ替え可能であるため、ここでは UUID という用語を使用します。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-128">For our purposes, these two terms are interchangeable so we'll continue to use the term UUID.</span></span> 

<span data-ttu-id="1bd7a-129">属性が標準であり、Bluetooth SIG によって定義されている属性の場合は、対応する 16 ビットの短い ID もあります (たとえば、バッテリ レベル UUID は 0000**2A19**-0000-1000-8000-00805F9B34FB で、短い ID は 0x2A19 です)。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-129">If the attribute is standard and defined by the Bluetooth SIG-defined, it will also have a corresponding 16-bit short ID (e.g. Battery Level UUID  is 0000**2A19**-0000-1000-8000-00805F9B34FB and the short ID is 0x2A19).</span></span> <span data-ttu-id="1bd7a-130">これらの標準的な UUID については、[GattServiceUuids](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.genericattributeprofile.gattserviceuuids.aspx) と [GattCharacteristicUuids](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.genericattributeprofile.gattcharacteristicuuids.aspx) に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-130">These standard UUIDs can be seen in [GattServiceUuids](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.genericattributeprofile.gattserviceuuids.aspx) and [GattCharacteristicUuids](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.genericattributeprofile.gattcharacteristicuuids.aspx).</span></span>

<span data-ttu-id="1bd7a-131">アプリで独自のカスタム サービスを実装している場合は、カスタム UUID を生成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-131">If your app is implementing it's own custom service, a custom UUID will have to be generated.</span></span> <span data-ttu-id="1bd7a-132">これは、Visual Studio で [ツール] の [GUID の作成] を選択して簡単に作成できます ("xxxxxxxx-xxxx-...xxxx" 形式で取得するにはオプション 5 を使用します)。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-132">This is easily done in Visual Studio through Tools -> CreateGuid (use option 5 to get it in the "xxxxxxxx-xxxx-...xxxx" format).</span></span> <span data-ttu-id="1bd7a-133">この UUID を使用して、新しいローカル サービス、特性、記述子を宣言できます。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-133">This uuid can now be used to declare new local services, characteristics or descriptors.</span></span>

#### <a name="restricted-services"></a><span data-ttu-id="1bd7a-134">制限されているサービス</span><span class="sxs-lookup"><span data-stu-id="1bd7a-134">Restricted Services</span></span>
<span data-ttu-id="1bd7a-135">次のサービスは、システムによって予約されており、現時点で公開することはできません。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-135">The following Services are reserved by the system and cannot be published at this time:</span></span>
1. <span data-ttu-id="1bd7a-136">デバイス情報サービス (DIS)</span><span class="sxs-lookup"><span data-stu-id="1bd7a-136">Device Information Service (DIS)</span></span>
2. <span data-ttu-id="1bd7a-137">汎用属性プロファイル サービス (GATT)</span><span class="sxs-lookup"><span data-stu-id="1bd7a-137">Generic Attribute Profile Service (GATT)</span></span>
3. <span data-ttu-id="1bd7a-138">汎用アクセス プロファイル サービス (GAP)</span><span class="sxs-lookup"><span data-stu-id="1bd7a-138">Generic Access Profile Service (GAP)</span></span>
4. <span data-ttu-id="1bd7a-139">ヒューマン インターフェイス デバイス サービス (HOGP)</span><span class="sxs-lookup"><span data-stu-id="1bd7a-139">Human Interface Device Service (HOGP)</span></span>
5. <span data-ttu-id="1bd7a-140">スキャン パラメーター サービス (SCP)</span><span class="sxs-lookup"><span data-stu-id="1bd7a-140">Scan Parameters Service (SCP)</span></span>

> <span data-ttu-id="1bd7a-141">ブロックされているサービスを作成しようとすると、CreateAsync への呼び出しから BluetoothError.DisabledByPolicy が返されます。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-141">Attempting to create a blocked service will result in BluetoothError.DisabledByPolicy being returned from the call to CreateAsync.</span></span>

#### <a name="generated-attributes"></a><span data-ttu-id="1bd7a-142">生成される属性</span><span class="sxs-lookup"><span data-stu-id="1bd7a-142">Generated Attributes</span></span>
<span data-ttu-id="1bd7a-143">次の記述子は、特性の作成時に指定した GattLocalCharacteristicParameters に基づいて、システムによって自動的に生成されます。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-143">The following descriptors are autogenerated by the system, based on the GattLocalCharacteristicParameters provided during creation of the characteristic:</span></span>
1. <span data-ttu-id="1bd7a-144">Client Characteristic Configuration (特性が指示可能または通知可能とマークされている場合)。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-144">Client Characteristic Configuration (if the characteristic is marked as indicatable or notifiable).</span></span>
2. <span data-ttu-id="1bd7a-145">Characteristic User Description (UserDescription プロパティが設定されている場合)。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-145">Characteristic User Description (if UserDescription property is set).</span></span> <span data-ttu-id="1bd7a-146">詳しくは、GattLocalCharacteristicParameters.UserDescription プロパティをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-146">See GattLocalCharacteristicParameters.UserDescription property for more info.</span></span>
3. <span data-ttu-id="1bd7a-147">Characteristic Format (指定されたプレゼンテーション形式ごとに 1 つの記述子)。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-147">Characteristic Format (one descriptor for each presentation format specified).</span></span>  <span data-ttu-id="1bd7a-148">詳しくは、GattLocalCharacteristicParameters.PresentationFormats プロパティをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-148">See GattLocalCharacteristicParameters.PresentationFormats property for more info.</span></span>
4. <span data-ttu-id="1bd7a-149">Characteristic Aggregate Format (複数の形式を指定した場合)。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-149">Characteristic Aggregate Format (if more than one presentation format is specified).</span></span>  <span data-ttu-id="1bd7a-150">詳しくは、GattLocalCharacteristicParameters.PresentationFormats プロパティをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-150">GattLocalCharacteristicParameters.See PresentationFormats property for more info.</span></span>
5. <span data-ttu-id="1bd7a-151">Characteristic Extended Properties (特性が拡張プロパティ ビットでマークされている場合)。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-151">Characteristic Extended Properties (if the characteristic is marked with the extended properties bit).</span></span>

> <span data-ttu-id="1bd7a-152">Extended Properties 記述子の値は、ReliableWrites および WritableAuxiliaries 特性プロパティによって決まります。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-152">The value of the Extended Properties descriptor is determined via the ReliableWrites and WritableAuxiliaries characteristic properties.</span></span>

> <span data-ttu-id="1bd7a-153">予約済みの記述子を作成しようとすると、例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-153">Attempting to create a reserved descriptor will result in an exception.</span></span>

> <span data-ttu-id="1bd7a-154">現時点では、ブロードキャストはサポートされていないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-154">Note that broadcast is not supported at this time.</span></span>  <span data-ttu-id="1bd7a-155">GattCharacteristicProperty のブロードキャストを指定すると、例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-155">Specifying the Broadcast GattCharacteristicProperty will result in an exception.</span></span>

### <a name="build-up-the-hierarchy-of-services-and-characteristics"></a><span data-ttu-id="1bd7a-156">サービスと特性の階層を構築します。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-156">Build up the hierarchy of services and characteristics</span></span>
<span data-ttu-id="1bd7a-157">ルート プライマリ サービスの定義を作成してアドバタイズするには、GattServiceProvider を使用します。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-157">The GattServiceProvider is used to create and advertise the root primary service definition.</span></span>  <span data-ttu-id="1bd7a-158">各サービスでは、GUID を受け取る独自の ServiceProvider オブジェクトが必要です。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-158">Each service requires it's own ServiceProvider object that takes in a GUID:</span></span> 

```csharp
GattServiceProviderResult result = await GattServiceProvider.CreateAsync(uuid);

if (result.Error == BluetoothError.Success)
{
    serviceProvider = result.ServiceProvider;
    // 
}
```
> <span data-ttu-id="1bd7a-159">プライマリ サービスは、GATT ツリーの最上位レベルです。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-159">Primary services are the top level of the GATT tree.</span></span> <span data-ttu-id="1bd7a-160">プライマリ サービスには、特性とその他のサービス (含まれるサービスまたはセカンダリ サービスと呼ばれます) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-160">Primary services contain characteristics as well as other services (called 'Included' or secondary services).</span></span> 

<span data-ttu-id="1bd7a-161">次に、サービスに、必要な特性と記述子を設定します。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-161">Now, populate the service with the required characteristics and descriptors:</span></span>

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
<span data-ttu-id="1bd7a-162">上記のように、これは、それぞれの特性がサポートしている操作のイベント ハンドラーを宣言する場所としても適しています。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-162">As shown above, this is also a good place to declare event handlers for the operations each characteristic supports.</span></span>  <span data-ttu-id="1bd7a-163">要求に正しく応答するには、属性がサポートしている各種の要求について、アプリがイベント ハンドラーを設定している必要があります。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-163">To respond to requests correctly, an app must defined and set an event handler for each request type the attribute supports.</span></span>  <span data-ttu-id="1bd7a-164">ハンドラーを登録できない場合、システムによって *UnlikelyError* が生成され、要求はすぐに完了します。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-164">Failing to register a handler will result in the request being completed immediately with *UnlikelyError* by the system.</span></span>

### <a name="constant-characteristics"></a><span data-ttu-id="1bd7a-165">定数の特性</span><span class="sxs-lookup"><span data-stu-id="1bd7a-165">Constant characteristics</span></span>
<span data-ttu-id="1bd7a-166">場合によって、アプリの有効期間中に変更されない特性値があります。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-166">Sometimes, there are characteristic values that will not change during the course of the app's lifetime.</span></span> <span data-ttu-id="1bd7a-167">その場合、不要なアプリのアクティブ化を防ぐために、定数の特性を宣言することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-167">In that case, it is advisable to declare a constant characteristic to prevent unnecessary app activation:</span></span> 

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
## <a name="publish-the-service"></a><span data-ttu-id="1bd7a-168">サービスの公開</span><span class="sxs-lookup"><span data-stu-id="1bd7a-168">Publish the service</span></span>
<span data-ttu-id="1bd7a-169">サービスが完全に定義されたら、次の手順は、サービスのサポートを公開することです。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-169">Once the service has been fully defined, the next step is to publish support for the service.</span></span> <span data-ttu-id="1bd7a-170">これにより、リモート デバイスがサービスの検出を実行するときに、サービスが返されることを OS に通知します。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-170">This informs the OS that the service should be returned when remote devices perform a service discovery.</span></span>  <span data-ttu-id="1bd7a-171">IsDiscoverable と IsConnectable の 2 つのプロパティを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-171">You will have to set two properties - IsDiscoverable and IsConnectable:</span></span>  

```csharp
GattServiceProviderAdvertisingParameters advParameters = new GattServiceProviderAdvertisingParameters
{
    IsDiscoverable = true,
    IsConnectable = true
};
serviceProvider.StartAdvertising(advParameters);
```
- <span data-ttu-id="1bd7a-172">**IsDiscoverable**:リモート デバイスでデバイスを探索可能にする提供情報のフレンドリ名をアドバタイズします。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-172">**IsDiscoverable**: Advertises the friendly name to remote devices in the advertisement, making the device discoverable.</span></span>
- <span data-ttu-id="1bd7a-173">**IsConnectable**:周辺のロールで使用するための接続可能な提供情報を通知します。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-173">**IsConnectable**:  Advertises a connectable advertisement for use in peripheral role.</span></span>

> <span data-ttu-id="1bd7a-174">サービスが検出可能で、接続可能である場合、システムはサービス UUID をアドバタイズ パケットに追加します。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-174">When a service is both Discoverable and Connectable, the system will add the Service Uuid to the advertisement packet.</span></span>  <span data-ttu-id="1bd7a-175">アドバタイズ パケットは 31 バイトだけであり、128 ビットの UUID はそのうちの 16 バイトを使用します。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-175">There are only 31 bytes in the Advertisement packet and a 128-bit UUID takes up 16 of them!</span></span>

> <span data-ttu-id="1bd7a-176">あるサービスがフォアグラウンドで公開されている場合、アプリケーションが中断するときに、アプリケーションは StopAdvertising を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-176">Note that when a service is published in the foreground, an application must call StopAdvertising when the application suspends.</span></span>

## <a name="respond-to-read-and-write-requests"></a><span data-ttu-id="1bd7a-177">読み取り要求や書き込み要求への応答</span><span class="sxs-lookup"><span data-stu-id="1bd7a-177">Respond to Read and Write requests</span></span>
<span data-ttu-id="1bd7a-178">上で見たように、必要な特性を宣言するときに、GattLocalCharacteristics では 3 種類のイベント ReadRequested、WriteRequested、SubscribedClientsChanged が発生します。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-178">As we saw above while declaring the required characteristics, GattLocalCharacteristics have 3 types of events - ReadRequested, WriteRequested and SubscribedClientsChanged.</span></span>

### <a name="read"></a><span data-ttu-id="1bd7a-179">Read</span><span class="sxs-lookup"><span data-stu-id="1bd7a-179">Read</span></span>
<span data-ttu-id="1bd7a-180">リモート デバイスが特性から値を読み取る場合 (また、その値が定数値ではない場合)、ReadRequested イベントが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-180">When a remote device tries to read a value from a characteristic (and it's not a constant value), the ReadRequested event is called.</span></span> <span data-ttu-id="1bd7a-181">読み取りが呼び出された特性が、引数 (リモート デバイスに関する情報を含む) と共に、デリゲートに渡されます。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-181">The characteristic the read was called on as well as args (containing information about the remote device) is passed to the delegate:</span></span> 

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

### <a name="write"></a><span data-ttu-id="1bd7a-182">書き込み</span><span class="sxs-lookup"><span data-stu-id="1bd7a-182">Write</span></span>
<span data-ttu-id="1bd7a-183">リモート デバイスが特性に値を書き込む場合、リモート デバイスに関する詳細、書き込み先の特性、書き込む値自体を使用して WriteRequested イベントが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-183">When a remote device tries to write a value to a characteristic, the WriteRequested event is called with details about the remote device, which characteristic to write to and the value itself:</span></span> 

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
<span data-ttu-id="1bd7a-184">書き込みには、応答がある書き込みと応答がない書き込みの 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-184">There are 2 types of Writes - with and without response.</span></span> <span data-ttu-id="1bd7a-185">リモート デバイスが実行している書き込みの種類を特定するには、GattWriteOption (GattWriteRequest オブジェクトのプロパティ) を使用します。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-185">Use GattWriteOption (a property on the GattWriteRequest object) to figure out which type of write the remote device is performing.</span></span> 

## <a name="send-notifications-to-subscribed-clients"></a><span data-ttu-id="1bd7a-186">受信登録しているクライアントへの通知の送信</span><span class="sxs-lookup"><span data-stu-id="1bd7a-186">Send notifications to subscribed clients</span></span>
<span data-ttu-id="1bd7a-187">最も一般的な GATT サーバーの操作である通知によって、データをリモート デバイスにプッシュする重要な機能を実行します。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-187">The most frequent of the GATT Server operations, notifications perform the critical function of pushing data to the remote devices.</span></span> <span data-ttu-id="1bd7a-188">受信登録しているすべてのクライアントに通知する場合もあれば、新しい値の送信先のデバイスを選択することが必要な場合もあります。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-188">Sometimes, you'll want to notify all subscribed clients but othertimes you may want to pick which devices to send the new value to:</span></span> 

```csharp
async void NotifyValue()
{
    var writer = new DataWriter();
    // Populate writer with data
    // ...
    
    await notifyCharacteristic.NotifyValueAsync(writer.DetachBuffer());
}
```

<span data-ttu-id="1bd7a-189">新しいデバイスが通知を受信登録する場合、SubscribedClientsChanged イベントが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-189">When a new device subscribes for notifications, the SubscribedClientsChanged event gets called:</span></span> 

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
> <span data-ttu-id="1bd7a-190">アプリケーションは、MaxNotificationSize プロパティを使用して、特定のクライアントの通知の最大サイズを取得できることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-190">Note that an application can get the maximum notification size for a particular client with the MaxNotificationSize property.</span></span>  <span data-ttu-id="1bd7a-191">最大サイズを超えるすべてのデータは、システムによって切り詰められます。</span><span class="sxs-lookup"><span data-stu-id="1bd7a-191">Any data larger than the maximum size will be truncated by the system.</span></span>
