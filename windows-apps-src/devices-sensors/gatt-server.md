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
# <a name="bluetooth-gatt-server"></a>Bluetooth GATT サーバー


**重要な API**
- [**Windows.Devices.Bluetooth**](https://msdn.microsoft.com/library/windows/apps/Dn263413)
- [**Windows.Devices.Bluetooth.GenericAttributeProfile**](https://msdn.microsoft.com/library/windows/apps/Dn297685)


この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリ用の Bluetooth 汎用属性 (GATT) サーバー API を、一般的な GATT サーバー タスクのサンプル コードを使って示します。 
- サポートされるサービスの定義
- リモート クライアントで検出できるようにするためのサーバーの公開
- サービスのサポートのアドバタイズ
- 読み取り要求や書き込み要求への応答
- 受信登録しているクライアントへの通知の送信

## <a name="overview"></a>概要
Windows は、通常、クライアントの役割で動作します。 ただし、Windows を Bluetooth LE GATT サーバーとして動作させることが必要なシナリオが数多く発生します。 多くのクロスプラットフォーム BLE 通信と共に、IoT デバイス向けのほとんどすべてのシナリオでは、Windows が GATT サーバーとして機能する必要があります。 さらに、近くのウェアラブル デバイスに通知を送信することも、このテクノロジを必要とする一般的なシナリオになっています。  
> 先に進む前に、[GATT クライアント ドキュメント](gatt-client.md)で説明されているすべての概念を理解していることを確認してください。  

サーバーの処理は、サービス プロバイダーと GattLocalCharacteristic を中心に実行されます。 これら 2 つのクラス宣言、実装、およびリモート デバイスへのデータの階層を公開するために必要な機能が提供されます。

## <a name="define-the-supported-services"></a>サポートされるサービスの定義
アプリでは、Windows によって公開される 1 つまたは複数のサービスを宣言できます。 各サービスは、UUID によって一意に識別されます。 

### <a name="attributes-and-uuids"></a>属性と UUID
各サービス、特性、記述子は、それぞれ一意の 128 ビット UUID によって定義されます。
> すべての Windows API では GUID という用語を使用しますが、Bluetooth の標準では、これらを UUID と定義しています。 このドキュメントの説明では、これら 2 つの用語は入れ替え可能であるため、ここでは UUID という用語を使用します。 

属性が標準であり、Bluetooth SIG によって定義されている属性の場合は、対応する 16 ビットの短い ID もあります (たとえば、バッテリ レベル UUID は 0000**2A19**-0000-1000-8000-00805F9B34FB で、短い ID は 0x2A19 です)。 これらの標準的な UUID については、[GattServiceUuids](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.genericattributeprofile.gattserviceuuids.aspx) と [GattCharacteristicUuids](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.genericattributeprofile.gattcharacteristicuuids.aspx) に関するページをご覧ください。

アプリで独自のカスタム サービスを実装している場合は、カスタム UUID を生成する必要があります。 これは、Visual Studio で [ツール] の [GUID の作成] を選択して簡単に作成できます ("xxxxxxxx-xxxx-...xxxx" 形式で取得するにはオプション 5 を使用します)。 この UUID を使用して、新しいローカル サービス、特性、記述子を宣言できます。

#### <a name="restricted-services"></a>制限されているサービス
次のサービスは、システムによって予約されており、現時点で公開することはできません。
1. デバイス情報サービス (DIS)
2. 汎用属性プロファイル サービス (GATT)
3. 汎用アクセス プロファイル サービス (GAP)
4. ヒューマン インターフェイス デバイス サービス (HOGP)
5. スキャン パラメーター サービス (SCP)

> ブロックされているサービスを作成しようとすると、CreateAsync への呼び出しから BluetoothError.DisabledByPolicy が返されます。

#### <a name="generated-attributes"></a>生成される属性
次の記述子は、特性の作成時に指定した GattLocalCharacteristicParameters に基づいて、システムによって自動的に生成されます。
1. Client Characteristic Configuration (特性が指示可能または通知可能とマークされている場合)。
2. Characteristic User Description (UserDescription プロパティが設定されている場合)。 詳しくは、GattLocalCharacteristicParameters.UserDescription プロパティをご覧ください。
3. Characteristic Format (指定されたプレゼンテーション形式ごとに 1 つの記述子)。  詳しくは、GattLocalCharacteristicParameters.PresentationFormats プロパティをご覧ください。
4. Characteristic Aggregate Format (複数の形式を指定した場合)。  詳しくは、GattLocalCharacteristicParameters.PresentationFormats プロパティをご覧ください。
5. Characteristic Extended Properties (特性が拡張プロパティ ビットでマークされている場合)。

> Extended Properties 記述子の値は、ReliableWrites および WritableAuxiliaries 特性プロパティによって決まります。

> 予約済みの記述子を作成しようとすると、例外が発生します。

> 現時点では、ブロードキャストはサポートされていないことに注意してください。  GattCharacteristicProperty のブロードキャストを指定すると、例外が発生します。

### <a name="build-up-the-hierarchy-of-services-and-characteristics"></a>サービスと特性の階層を構築します。
ルート プライマリ サービスの定義を作成してアドバタイズするには、GattServiceProvider を使用します。  各サービスでは、GUID を受け取る独自の ServiceProvider オブジェクトが必要です。 

```csharp
GattServiceProviderResult result = await GattServiceProvider.CreateAsync(uuid);

if (result.Error == BluetoothError.Success)
{
    serviceProvider = result.ServiceProvider;
    // 
}
```
> プライマリ サービスは、GATT ツリーの最上位レベルです。 プライマリ サービスには、特性とその他のサービス (含まれるサービスまたはセカンダリ サービスと呼ばれます) が含まれます。 

次に、サービスに、必要な特性と記述子を設定します。

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
上記のように、これは、それぞれの特性がサポートしている操作のイベント ハンドラーを宣言する場所としても適しています。  要求に正しく応答するには、属性がサポートしている各種の要求について、アプリがイベント ハンドラーを設定している必要があります。  ハンドラーを登録できない場合、システムによって *UnlikelyError* が生成され、要求はすぐに完了します。

### <a name="constant-characteristics"></a>定数の特性
場合によって、アプリの有効期間中に変更されない特性値があります。 その場合、不要なアプリのアクティブ化を防ぐために、定数の特性を宣言することをお勧めします。 

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
## <a name="publish-the-service"></a>サービスの公開
サービスが完全に定義されたら、次の手順は、サービスのサポートを公開することです。 これにより、リモート デバイスがサービスの検出を実行するときに、サービスが返されることを OS に通知します。  IsDiscoverable と IsConnectable の 2 つのプロパティを設定する必要があります。  

```csharp
GattServiceProviderAdvertisingParameters advParameters = new GattServiceProviderAdvertisingParameters
{
    IsDiscoverable = true,
    IsConnectable = true
};
serviceProvider.StartAdvertising(advParameters);
```
- **IsDiscoverable**:リモート デバイスでデバイスを探索可能にする提供情報のフレンドリ名をアドバタイズします。
- **IsConnectable**:周辺のロールで使用するための接続可能な提供情報を通知します。

> サービスが検出可能で、接続可能である場合、システムはサービス UUID をアドバタイズ パケットに追加します。  アドバタイズ パケットは 31 バイトだけであり、128 ビットの UUID はそのうちの 16 バイトを使用します。

> あるサービスがフォアグラウンドで公開されている場合、アプリケーションが中断するときに、アプリケーションは StopAdvertising を呼び出す必要があります。

## <a name="respond-to-read-and-write-requests"></a>読み取り要求や書き込み要求への応答
上で見たように、必要な特性を宣言するときに、GattLocalCharacteristics では 3 種類のイベント ReadRequested、WriteRequested、SubscribedClientsChanged が発生します。

### <a name="read"></a>Read
リモート デバイスが特性から値を読み取る場合 (また、その値が定数値ではない場合)、ReadRequested イベントが呼び出されます。 読み取りが呼び出された特性が、引数 (リモート デバイスに関する情報を含む) と共に、デリゲートに渡されます。 

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

### <a name="write"></a>書き込み
リモート デバイスが特性に値を書き込む場合、リモート デバイスに関する詳細、書き込み先の特性、書き込む値自体を使用して WriteRequested イベントが呼び出されます。 

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
書き込みには、応答がある書き込みと応答がない書き込みの 2 種類があります。 リモート デバイスが実行している書き込みの種類を特定するには、GattWriteOption (GattWriteRequest オブジェクトのプロパティ) を使用します。 

## <a name="send-notifications-to-subscribed-clients"></a>受信登録しているクライアントへの通知の送信
最も一般的な GATT サーバーの操作である通知によって、データをリモート デバイスにプッシュする重要な機能を実行します。 受信登録しているすべてのクライアントに通知する場合もあれば、新しい値の送信先のデバイスを選択することが必要な場合もあります。 

```csharp
async void NotifyValue()
{
    var writer = new DataWriter();
    // Populate writer with data
    // ...
    
    await notifyCharacteristic.NotifyValueAsync(writer.DetachBuffer());
}
```

新しいデバイスが通知を受信登録する場合、SubscribedClientsChanged イベントが呼び出されます。 

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
> アプリケーションは、MaxNotificationSize プロパティを使用して、特定のクライアントの通知の最大サイズを取得できることに注意してください。  最大サイズを超えるすべてのデータは、システムによって切り詰められます。
