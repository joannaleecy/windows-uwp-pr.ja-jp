---
author: msatranjr
title: Bluetooth GATT サーバー
description: ここでは、一般的な用途のサンプル コードのほか、どこからでも Windows プラットフォーム (UWP) のアプリの Bluetooth 汎用属性プロファイル (GATT) サーバーの概要を説明します。
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 27154fbb535b76995fba97702e65a9c0b2a8291c
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "610765"
---
# <a name="bluetooth-gatt-server"></a><span data-ttu-id="3e6f5-104">Bluetooth GATT サーバー</span><span class="sxs-lookup"><span data-stu-id="3e6f5-104">Bluetooth GATT Server</span></span>


**<span data-ttu-id="3e6f5-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="3e6f5-105">Important APIs</span></span>**
- [**<span data-ttu-id="3e6f5-106">Windows.Devices.Bluetooth</span><span class="sxs-lookup"><span data-stu-id="3e6f5-106">Windows.Devices.Bluetooth</span></span>**](https://msdn.microsoft.com/library/windows/apps/Dn263413)
- [**<span data-ttu-id="3e6f5-107">Windows.Devices.Bluetooth.GenericAttributeProfile</span><span class="sxs-lookup"><span data-stu-id="3e6f5-107">Windows.Devices.Bluetooth.GenericAttributeProfile</span></span>**](https://msdn.microsoft.com/library/windows/apps/Dn297685)


<span data-ttu-id="3e6f5-108">この記事では、GATT サーバーの一般的なタスクのサンプル コードのほか、どこからでも Windows プラットフォーム (UWP) のアプリの Bluetooth 汎用属性 (GATT) サーバー Api を示します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-108">This article demonstrates Bluetooth Generic Attribute (GATT) Server APIs for Universal Windows Platform (UWP) apps, along with sample code for common GATT server tasks:</span></span> 
- <span data-ttu-id="3e6f5-109">サポートされているサービスを定義します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-109">Define the supported services</span></span>
- <span data-ttu-id="3e6f5-110">リモート クライアントを検出できるようにサーバーを公開します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-110">Publish server so it can be discovered by remote clients</span></span>
- <span data-ttu-id="3e6f5-111">サービスのサポートを提供します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-111">Advertise support for service</span></span>
- <span data-ttu-id="3e6f5-112">読み取りおよび書き込み要求に応答します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-112">Respond to read and write requests</span></span>
- <span data-ttu-id="3e6f5-113">購読しているクライアントに通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-113">Send notifications to subscribed clients</span></span>

## <a name="overview"></a><span data-ttu-id="3e6f5-114">概要</span><span class="sxs-lookup"><span data-stu-id="3e6f5-114">Overview</span></span>
<span data-ttu-id="3e6f5-115">Windows は、通常の役割は、クライアントで動作します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-115">Windows usually operates in the client role.</span></span> <span data-ttu-id="3e6f5-116">ただし、Windows も Bluetooth LE GATT サーバーとして機能が必要な多くのシナリオが発生します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-116">Nevertheless, many scenarios arise which require Windows to act as a Bluetooth LE GATT Server as well.</span></span> <span data-ttu-id="3e6f5-117">IoT デバイスでは、ほとんどのプラットフォーム BLE コミュニケーションと、ほぼすべてのシナリオには、Windows GATT サーバーが必要です。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-117">Almost all the scenarios for IoT devices, along with most cross-platform BLE communication will require Windows to be a GATT Server.</span></span> <span data-ttu-id="3e6f5-118">さらに、携帯機器の近くに通知を送信する一般的なシナリオにも、このテクノロジが必要なとなっています。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-118">Additionally, sending notifications to nearby wearable devices has become a popular scenario that requires this technology as well.</span></span>  
> <span data-ttu-id="3e6f5-119">[GATT クライアント ドキュメント](gatt-client.md)内のすべての概念は続行する前にクリアすることを確認します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-119">Make sure all the concepts in the [GATT Client docs](gatt-client.md) are clear before proceeding.</span></span>  

<span data-ttu-id="3e6f5-120">サーバーの処理がサービス プロバイダーと、GattLocalCharacteristic の中心です。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-120">Server operations will revolve around the Service Provider and the GattLocalCharacteristic.</span></span> <span data-ttu-id="3e6f5-121">これら 2 つのクラスは宣言、実装およびリモート デバイスへのデータの階層を公開するために必要な機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-121">These two classes will provide the functionality needed to declare, implement and expose a heirarchy of data to a remote device.</span></span>

## <a name="define-the-supported-services"></a><span data-ttu-id="3e6f5-122">サポートされているサービスを定義します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-122">Define the supported services</span></span>
<span data-ttu-id="3e6f5-123">アプリでは、Windows で公開される 1 つ以上のサービスを宣言可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-123">Your app may declare one or more services that will be published by Windows.</span></span> <span data-ttu-id="3e6f5-124">各サービスは、UUID を一意に識別します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-124">Each service is uniquely identified by a UUID.</span></span> 

### <a name="attributes-and-uuids"></a><span data-ttu-id="3e6f5-125">属性と Uuid</span><span class="sxs-lookup"><span data-stu-id="3e6f5-125">Attributes and UUIDs</span></span>
<span data-ttu-id="3e6f5-126">各サービス、特徴および表してが定義されている独自の一意の 128 ビット UUID はでします。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-126">Each service, characteristic and descriptor is defined by it's own unique 128-bit UUID.</span></span>
> <span data-ttu-id="3e6f5-127">GUID、用語を使用するすべての Windows Api が Bluetooth 標準 Uuid としてを定義します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-127">The Windows APIs all use the term GUID, but the Bluetooth standard defines these as UUIDs.</span></span> <span data-ttu-id="3e6f5-128">今回は、次の 2 つの用語は互換性 UUID 用語を使用するためされます。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-128">For our purposes, these two terms are interchangeable so we'll continue to use the term UUID.</span></span> 

<span data-ttu-id="3e6f5-129">対応する 16 ビット短い ID があります属性が標準および Bluetooth 署名定義して定義済みの場合は、(バッテリ レベル UUID 0000**2A19**は、たとえば-0000-1000-8000-00805F9B34FB 短い ID、0x2A19)。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-129">If the attribute is standard and defined by the Bluetooth SIG-defined, it will also have a corresponding 16-bit short ID (e.g. Battery Level UUID  is 0000**2A19**-0000-1000-8000-00805F9B34FB and the short ID is 0x2A19).</span></span> <span data-ttu-id="3e6f5-130">これらの標準的な Uuid [GattServiceUuids](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.genericattributeprofile.gattserviceuuids.aspx)および[GattCharacteristicUuids](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.genericattributeprofile.gattcharacteristicuuids.aspx)で表示できます。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-130">These standard UUIDs can be seen in [GattServiceUuids](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.genericattributeprofile.gattserviceuuids.aspx) and [GattCharacteristicUuids](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.genericattributeprofile.gattcharacteristicuuids.aspx).</span></span>

<span data-ttu-id="3e6f5-131">アプリを実装する場合は、独自のカスタム サービスは、カスタム UUID が生成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-131">If your app is implementing it's own custom service, a custom UUID will have to be generated.</span></span> <span data-ttu-id="3e6f5-132">これは、簡単に完了ツールを使って、Visual Studio でクリックし、[CreateGuid (使用オプション 5 を実行して、"xxxx チーム-xxxx-..."の形式で)。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-132">This is easily done in Visual Studio through Tools -> CreateGuid (use option 5 to get it in the "xxxxxxxx-xxxx-...xxxx" format).</span></span> <span data-ttu-id="3e6f5-133">この uuid は、新しいローカル サービス、特性などの宣言を今すぐ使用できます。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-133">This uuid can now be used to declare new local services, characteristics or descriptors.</span></span>

#### <a name="restricted-services"></a><span data-ttu-id="3e6f5-134">サービスの制限</span><span class="sxs-lookup"><span data-stu-id="3e6f5-134">Restricted Services</span></span>
<span data-ttu-id="3e6f5-135">次のサービスでは、システムによって予約されており、現時点で公開することはできません。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-135">The following Services are reserved by the system and cannot be published at this time:</span></span>
1. <span data-ttu-id="3e6f5-136">デバイス情報サービス (無効)</span><span class="sxs-lookup"><span data-stu-id="3e6f5-136">Device Information Service (DIS)</span></span>
2. <span data-ttu-id="3e6f5-137">一般的な属性プロファイル サービス (GATT)</span><span class="sxs-lookup"><span data-stu-id="3e6f5-137">Generic Attribute Profile Service (GATT)</span></span>
3. <span data-ttu-id="3e6f5-138">Access の一般的なプロファイル サービス (ギャップ)</span><span class="sxs-lookup"><span data-stu-id="3e6f5-138">Generic Access Profile Service (GAP)</span></span>
4. <span data-ttu-id="3e6f5-139">ヒューマン インターフェイス デバイス サービス (HOGP)</span><span class="sxs-lookup"><span data-stu-id="3e6f5-139">Human Interface Device Service (HOGP)</span></span>
5. <span data-ttu-id="3e6f5-140">スキャン パラメーター サービス (SCP)</span><span class="sxs-lookup"><span data-stu-id="3e6f5-140">Scan Parameters Service (SCP)</span></span>

> <span data-ttu-id="3e6f5-141">ブロックされているサービスを作成しようとしていますが、CreateAsync に通話から返される BluetoothError.DisabledByPolicy で発生します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-141">Attempting to create a blocked service will result in BluetoothError.DisabledByPolicy being returned from the call to CreateAsync.</span></span>

#### <a name="generated-attributes"></a><span data-ttu-id="3e6f5-142">生成された属性</span><span class="sxs-lookup"><span data-stu-id="3e6f5-142">Generated Attributes</span></span>
<span data-ttu-id="3e6f5-143">次の記述子は、自動生成された特性の作成時に提供された GattLocalCharacteristicParameters に基づいて、システムによってです。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-143">The following descriptors are autogenerated by the system, based on the GattLocalCharacteristicParameters provided during creation of the characteristic:</span></span>
1. <span data-ttu-id="3e6f5-144">クライアントの特性の構成 (特性が、indicatable または通知用としてマークされている) 場合。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-144">Client Characteristic Configuration (if the characteristic is marked as indicatable or notifiable).</span></span>
2. <span data-ttu-id="3e6f5-145">特性ユーザーに応じて説明も入力 (いることのプロパティが設定されます)。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-145">Characteristic User Description (if UserDescription property is set).</span></span> <span data-ttu-id="3e6f5-146">さらに詳しい情報の GattLocalCharacteristicParameters.UserDescription プロパティを参照してください。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-146">See GattLocalCharacteristicParameters.UserDescription property for more info.</span></span>
3. <span data-ttu-id="3e6f5-147">特性の形式 (指定された各プレゼンテーション形式で表してを 1 つ)。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-147">Characteristic Format (one descriptor for each presentation format specified).</span></span>  <span data-ttu-id="3e6f5-148">さらに詳しい情報の GattLocalCharacteristicParameters.PresentationFormats プロパティを参照してください。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-148">See GattLocalCharacteristicParameters.PresentationFormats property for more info.</span></span>
4. <span data-ttu-id="3e6f5-149">特性集計書式設定 (この場合は、複数のプレゼンテーション形式を指定した場合)。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-149">Characteristic Aggregate Format (if more than one presentation format is specified).</span></span>  <span data-ttu-id="3e6f5-150">さらに詳しい情報の GattLocalCharacteristicParameters.See PresentationFormats プロパティ。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-150">GattLocalCharacteristicParameters.See PresentationFormats property for more info.</span></span>
5. <span data-ttu-id="3e6f5-151">(特性には、拡張されたプロパティのビットが付いている) 場合、特性のことに拡張されたプロパティ。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-151">Characteristic Extended Properties (if the characteristic is marked with the extended properties bit).</span></span>

> <span data-ttu-id="3e6f5-152">拡張プロパティ表しての値は ReliableWrites と WritableAuxiliaries 特性プロパティを使用して決定されます。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-152">The value of the Extended Properties descriptor is determined via the ReliableWrites and WritableAuxiliaries characteristic properties.</span></span>

> <span data-ttu-id="3e6f5-153">予約表してを作成しようとすると、例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-153">Attempting to create a reserved descriptor will result in an exception.</span></span>

> <span data-ttu-id="3e6f5-154">現時点では、ブロードキャスト メモはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-154">Note that broadcast is not supported at this time.</span></span>  <span data-ttu-id="3e6f5-155">ブロードキャスト GattCharacteristicProperty を指定すると、例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-155">Specifying the Broadcast GattCharacteristicProperty will result in an exception.</span></span>

### <a name="build-up-the-heirarchy-of-services-and-characteristics"></a><span data-ttu-id="3e6f5-156">サービスと特性の階層を作成します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-156">Build up the heirarchy of services and characteristics</span></span>
<span data-ttu-id="3e6f5-157">作成してルート プライマリ サービスの定義を提供する、GattServiceProvider を使用します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-157">The GattServiceProvider is used to create and advertise the root primary service definition.</span></span>  <span data-ttu-id="3e6f5-158">各サービスでは、GUID では、独自のサービス プロバイダー オブジェクトが必要です。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-158">Each service requires it's own ServiceProvider object that takes in a GUID:</span></span> 

```csharp
GattServiceProviderResult result = await GattServiceProvider.CreateAsync(uuid);

if (result.Error == BluetoothError.Success)
{
    serviceProvider = result.ServiceProvider;
    // 
}
```
> <span data-ttu-id="3e6f5-159">GATT ツリーの最上位レベルのプライマリ サービスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-159">Primary services are the top level of the GATT tree.</span></span> <span data-ttu-id="3e6f5-160">プライマリ サービスには、特性とその他のサービス ('含める' または第 2 のサービスと呼ばれる) が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-160">Primary services contain characteristics as well as other services (called 'Included' or secondary services).</span></span> 

<span data-ttu-id="3e6f5-161">これで、必要な特性記述子とサービスを設定します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-161">Now, populate the service with the required characteristics and descriptors:</span></span>

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
<span data-ttu-id="3e6f5-162">上記のように、これは、それぞれの特性がサポートしている操作のイベント ハンドラーを宣言する適切な場所。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-162">As shown above, this is also a good place to declare event handlers for the operations each characteristic supports.</span></span>  <span data-ttu-id="3e6f5-163">正常に要求に応答するアプリ必要があります定義され、属性がサポートしている各要求の種類のイベント ハンドラーを設定します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-163">To respond to requests correctly, an app must defined and set an event handler for each request type the attribute supports.</span></span>  <span data-ttu-id="3e6f5-164">わかりませんハンドラーを登録すると、システムで*UnlikelyError*とすぐに完了する要求が発生します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-164">Failing to register a handler will result in the request being completed immediately with *UnlikelyError* by the system.</span></span>

### <a name="constant-characteristics"></a><span data-ttu-id="3e6f5-165">一定の特性</span><span class="sxs-lookup"><span data-stu-id="3e6f5-165">Constant characteristics</span></span>
<span data-ttu-id="3e6f5-166">場合によっては、アプリの有効期間中に変更はありません特性の値があります。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-166">Sometimes, there are characteristic values that will not change during the course of the app's lifetime.</span></span> <span data-ttu-id="3e6f5-167">その場合は、不要なアプリのライセンス認証を防ぐために一定の特性を宣言することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-167">In that case, it is advisable to declare a constant characteristic to prevent unnecessary app activation:</span></span> 

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
## <a name="publish-the-service"></a><span data-ttu-id="3e6f5-168">サービスを発行します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-168">Publish the service</span></span>
<span data-ttu-id="3e6f5-169">サービスが完全に定義した後、次の手順では、サービスのサポートを発行します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-169">Once the service has been fully defined, the next step is to publish support for the service.</span></span> <span data-ttu-id="3e6f5-170">リモート デバイス サービスの検索を実行するときに、サービスが返されることを OS に通知されます。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-170">This informs the OS that the service should be returned when remote devices perform a service discovery.</span></span>  <span data-ttu-id="3e6f5-171">-IsDiscoverable と IsConnectable の 2 つのプロパティを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-171">You will have to set two properties - IsDiscoverable and IsConnectable:</span></span>  

```csharp
GattServiceProviderAdvertisingParameters advParameters = new GattServiceProviderAdvertisingParameters
{
    IsDiscoverable = true,
    IsConnectable = true
};
serviceProvider.StartAdvertising(advParameters);
```
- <span data-ttu-id="3e6f5-172">**IsDiscoverable**: デバイスを検出できること、広告にリモート デバイスにわかりやすい名前を通知します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-172">**IsDiscoverable**: Advertises the friendly name to remote devices in the advertisement, making the device discoverable.</span></span>
- <span data-ttu-id="3e6f5-173">**IsConnectable**: 周辺の役割で使用する接続可能な広告を通知します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-173">**IsConnectable**:  Advertises a connectable advertisement for use in peripheral role.</span></span>

> <span data-ttu-id="3e6f5-174">サービスは、検出可能と Connectable の両方が、システムは広告パケットにサービス Uuid を追加します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-174">When a service is both Discoverable and Connectable, the system will add the Service Uuid to the advertisement packet.</span></span>  <span data-ttu-id="3e6f5-175">広告パケットに 31 バイトだけが、それらの 16 占めます、128 ビット UUID.</span><span class="sxs-lookup"><span data-stu-id="3e6f5-175">There are only 31 bytes in the Advertisement packet and a 128-bit UUID takes up 16 of them!</span></span>

> <span data-ttu-id="3e6f5-176">いるサービスが前面に公開されると、アプリケーションを呼び出す必要があります StopAdvertising アプリケーションを中断するときに注意してください。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-176">Note that when a service is published in the foreground, an application must call StopAdvertising when the application suspends.</span></span>

## <a name="respond-to-read-and-write-requests"></a><span data-ttu-id="3e6f5-177">読み取りおよび書き込み要求に応答します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-177">Respond to Read and Write requests</span></span>
<span data-ttu-id="3e6f5-178">見たよう上に必要な特性を宣言するときに、GattLocalCharacteristics は 3 種類のイベントの ReadRequested、WriteRequested および SubscribedClientsChanged があります。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-178">As we saw above while declaring the required characteristics, GattLocalCharacteristics have 3 types of events - ReadRequested, WriteRequested and SubscribedClientsChanged.</span></span>

### <a name="read"></a><span data-ttu-id="3e6f5-179">Read</span><span class="sxs-lookup"><span data-stu-id="3e6f5-179">Read</span></span>
<span data-ttu-id="3e6f5-180">リモート デバイス特性から値を読み取るしようとする (と定数の値になっていません)、ReadRequested イベントが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-180">When a remote device tries to read a value from a characteristic (and it's not a constant value), the ReadRequested event is called.</span></span> <span data-ttu-id="3e6f5-181">読み取りが引数 (リモート デバイスに関する情報を含む) だけでなく上と呼ばれる特徴は、代理人に渡されます。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-181">The characteristic the read was called on as well as args (containing information about the remote device) is passed to the delegate:</span></span> 

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

### <a name="write"></a><span data-ttu-id="3e6f5-182">書き込み</span><span class="sxs-lookup"><span data-stu-id="3e6f5-182">Write</span></span>
<span data-ttu-id="3e6f5-183">リモート デバイス特性に値を作成しようとすると、書き込みをする特徴と、値そのものリモート デバイスに関する詳細を含む WriteRequested イベントが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-183">When a remote device tries to write a value to a characteristic, the WriteRequested event is called with details about the remote device, which characteristic to write to and the value itself:</span></span> 

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
<span data-ttu-id="3e6f5-184">応答がないと書き込みの 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-184">There are 2 types of Writes - with and without response.</span></span> <span data-ttu-id="3e6f5-185">GattWriteOption (GattWriteRequest オブジェクトのプロパティ) を使用して、リモートのデバイスを実行している [文章入力の種類を把握します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-185">Use GattWriteOption (a property on the GattWriteRequest object) to figure out which type of write the remote device is performing.</span></span> 

## <a name="send-notifications-to-subscribed-clients"></a><span data-ttu-id="3e6f5-186">購読しているクライアントに通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-186">Send notifications to subscribed clients</span></span>
<span data-ttu-id="3e6f5-187">GATT サーバーの操作、通知の中で最も頻繁には、リモート デバイスにデータを遅らせての重要な機能を実行します。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-187">The most frequent of the GATT Server operations, notifications perform the critical function of pushing data to the remote devices.</span></span> <span data-ttu-id="3e6f5-188">場合によっては、[すべての購読しているクライアントが othertimes に新しい値を送信するには、どのデバイスを選択することを通知する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-188">Sometimes, you'll want to notify all subscribed clients but othertimes you may want to pick which devices to send the new value to:</span></span> 

```csharp
async void NotifyValue()
{
    var writer = new DataWriter();
    // Populate writer with data
    // ...
    
    await notifyCharacteristic.NotifyValueAsync(writer.DetachBuffer());
}
```

<span data-ttu-id="3e6f5-189">新しいデバイスでは、通知をサブスクライブするときに SubscribedClientsChanged イベントが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-189">When a new device subscribes for notifications, the SubscribedClientsChanged event gets called:</span></span> 

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
> <span data-ttu-id="3e6f5-190">アプリケーションが MaxNotificationSize プロパティを使用して特定のクライアントの通知の最大サイズを取得することに注意してください。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-190">Note that an application can get the maximum notification size for a particular client with the MaxNotificationSize property.</span></span>  <span data-ttu-id="3e6f5-191">システムの最大サイズを超えるデータが切り捨てられます。</span><span class="sxs-lookup"><span data-stu-id="3e6f5-191">Any data larger than the maximum size will be truncated by the system.</span></span>
