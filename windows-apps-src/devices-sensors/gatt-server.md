---
title: Bluetooth GATT サーバー
description: この記事では、一般的な用途のサンプル コードでと一緒に、ユニバーサル Windows プラットフォーム (UWP) アプリの Bluetooth 汎用属性プロファイル (GATT) サーバーの概要を示します。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 551f8b925ffd56950ba893da7b81fefb4579f558
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7987423"
---
# <a name="bluetooth-gatt-server"></a>Bluetooth GATT サーバー


**重要な API**
- [**Windows.Devices.Bluetooth**](https://msdn.microsoft.com/library/windows/apps/Dn263413)
- [**Windows.Devices.Bluetooth.GenericAttributeProfile**](https://msdn.microsoft.com/library/windows/apps/Dn297685)


この記事では、一般的な GATT サーバー タスクのサンプル コードでと一緒に、ユニバーサル Windows プラットフォーム (UWP) アプリ用の Bluetooth Generic Attribute (GATT) サーバー Api を示しています。 
- サポートされているサービスを定義します。
- リモート クライアントが検出できるようにサーバーを公開します。
- サービスのサポートを提供します。
- 読み取りし、書き込み要求に応答するには
- サブスクライブしているクライアントに通知を送信します。

## <a name="overview"></a>概要
Windows は、通常、クライアントの役割で動作します。 それでも、Bluetooth LE GATT サーバーもとして機能する Windows 不要となる多くのシナリオが発生します。 ほとんどのクロス プラットフォーム BLE 通信と共に、IoT デバイスでは、ほぼすべてのシナリオには、GATT サーバーを指定する Windows が必要です。 さらに、近くにあるウェアラブル デバイスへの通知の送信にも、このテクノロジを必要とする一般的なシナリオとなっています。  
> [GATT クライアント ドキュメント](gatt-client.md)の最新情報のすべての概念が先に進む前にオフにすることを確認します。  

サーバーの運用は、サービス プロバイダーや、GattLocalCharacteristic によって中心です。 これら 2 つのクラスを宣言し、実装し、リモート デバイスへのデータの階層を公開するために必要な機能が提供されます。

## <a name="define-the-supported-services"></a>サポートされているサービスを定義します。
アプリが Windows によって公開される 1 つまたは複数のサービスを宣言できます。 各サービスは、UUID を一意に識別します。 

### <a name="attributes-and-uuids"></a>属性と Uuid
各サービス、特性、記述子が定義されているが、独自の一意の 128 ビット UUID します。
> GUID、という用語を使用してすべての Windows Api が、標準の Bluetooth が Uuid としてこれらを定義します。 今回は、これら 2 つの用語は入れ替え可能であるが引き続き UUID 用語を使用するようにします。 

属性が標準および Bluetooth SIG 定義で定義されている場合は、対応する 16 ビットの短い ID がありますも (例: 0000**2A19**は、バッテリ レベル UUID-0000-1000-8000-00805F9B34FB と短い ID は 0x2A19)。 これらの標準的な Uuid は、 [GattServiceUuids](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.genericattributeprofile.gattserviceuuids.aspx)と[GattCharacteristicUuids](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.genericattributeprofile.gattcharacteristicuuids.aspx)で確認できます。

アプリを実装する場合は、独自のカスタム サービスは、カスタム UUID が生成する必要があります。 これは、簡単に行うツールを使って Visual Studio で]-> [CreateGuid (使用オプション 5"xxxx」という-xxxx-."の形式で入手する)。 この uuid は、新しいローカル サービス、特性、または記述子を宣言するようになりました使用できます。

#### <a name="restricted-services"></a>制限付きのサービス
次のサービスは、システムによって予約されており、この時点で公開されることはできません。
1. デバイス情報サービス (無効)
2. 汎用属性プロファイル サービス (GATT)
3. 汎用的なアクセス Profile サービス (ギャップ)
4. ヒューマン インターフェイス デバイス サービス (HOGP)
5. パラメーターのサービス (SCP) をスキャンします。

> ブロックされているサービスを作成しようとすると、CreateAsync への呼び出しから返される BluetoothError.DisabledByPolicy が発生します。

#### <a name="generated-attributes"></a>生成された属性
次の記述子は、特性の作成時に提供される GattLocalCharacteristicParameters に基づいて、システムによって自動的に生成します。
1. クライアントの特性の構成 (indicatable または通知用として、特性が付いている) 場合。
2. 特性ユーザー説明 (場合いることのプロパティが設定されます)。 詳しくは、GattLocalCharacteristicParameters.UserDescription プロパティを参照してください。
3. 特性の形式 (指定されている各プレゼンテーション形式の 1 つの記述子)。  詳しくは、GattLocalCharacteristicParameters.PresentationFormats プロパティを参照してください。
4. 特性集計形式 (1 つ以上の形式が指定されます)。  詳しくは GattLocalCharacteristicParameters.See PresentationFormats プロパティです。
5. (特性は、拡張プロパティのビットが付いている) 場合、特性のことに拡張プロパティ。

> 拡張プロパティ記述子の値は ReliableWrites と WritableAuxiliaries 特性プロパティによって決まります。

> 予約済みの記述子を作成しようとすると、例外が発生します。

> この時点では、ブロードキャストの注はサポートされていません。  ブロードキャスト GattCharacteristicProperty を指定すると、例外が発生します。

### <a name="build-up-the-hierarchy-of-services-and-characteristics"></a>サービスと特性についての階層を作成します。
作成して、ルートの主要なサービスの定義を提供する、GattServiceProvider を使用します。  各サービスでは、GUID では、独自のサービス プロバイダー オブジェクトである必要があります。 

```csharp
GattServiceProviderResult result = await GattServiceProvider.CreateAsync(uuid);

if (result.Error == BluetoothError.Success)
{
    serviceProvider = result.ServiceProvider;
    // 
}
```
> プライマリ サービスは、GATT ツリーの最上位レベルです。 プライマリ サービスには、特性とその他のサービス ('含める' またはセカンダリのサービスと呼ばれます) が含まれます。 

必要な特性、記述子とサービスを読み込みます。

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
上記のように、このもそれぞれの特性がサポートする操作用のイベント ハンドラーを宣言するに適しています。  アプリの必要が正常に要求に応答する定義され、属性は、サポート要求の種類ごとにイベント ハンドラーを設定します。  ハンドラーを登録に失敗すると、システムで*UnlikelyError*をすぐに完了する要求が発生します。

### <a name="constant-characteristics"></a>定数の特徴
場合によっては、これには、アプリの有効期間中は変更されません特性値があります。 その場合は、不要なアプリのアクティブ化を防ぐために定数の特性を宣言することをお勧めします。 

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
## <a name="publish-the-service"></a>サービスを公開します。
サービスが完全に定義した後、次の手順では、サービスのサポートを公開します。 リモート デバイス サービス検出を実行するときに、サービスが返されることを OS に通知されます。  -IsDiscoverable と IsConnectable の 2 つのプロパティを設定する必要があります。  

```csharp
GattServiceProviderAdvertisingParameters advParameters = new GattServiceProviderAdvertisingParameters
{
    IsDiscoverable = true,
    IsConnectable = true
};
serviceProvider.StartAdvertising(advParameters);
```
- **IsDiscoverable**: にデバイスを検出する、アドバタイズのリモート デバイスのフレンドリ名をアドバタイズします。
- **IsConnectable**: 周辺機器ロールで使用するための接続可能な広告をアドバタイズします。

> サービスは、検出可能と Connectable の両方が、システムは、広告のパケットをサービス Uuid を追加します。  広告パケットに 31 バイトのみがあり、それらの 16 占有 128 ビット UUID!

> あるサービスがフォア グラウンドで公開されると、アプリケーション呼び出す必要があります StopAdvertising アプリケーションが中断するときに注意してください。

## <a name="respond-to-read-and-write-requests"></a>読み取りし、書き込み要求に応答するには
必要な特性を宣言するときに、上で見た、として GattLocalCharacteristics はイベント - ReadRequested、WriteRequested および SubscribedClientsChanged の 3 種類があります。

### <a name="read"></a>Read
リモート デバイス特性から値を読み取るしようとする (および定数値ではない)、ReadRequested イベントが呼び出されます。 (リモート デバイスに関する情報を含む) の引数およびに対して読み取りが呼び出された特性は、デリゲートに渡されます。 

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
リモート デバイスは、特性に値を記述する際に、どのへの書き込み特性と値では、リモート デバイスの詳細を WriteRequested イベントが呼び出されます。 

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
-の書き込みと応答がない場合の 2 種類があります。 GattWriteOption (GattWriteRequest オブジェクトのプロパティ) を使用して、リモート デバイスを実行してライトの種類を特定します。 

## <a name="send-notifications-to-subscribed-clients"></a>サブスクライブしているクライアントに通知を送信します。
GATT サーバーの運用、通知の中で最も頻繁にデータをリモート デバイスにプッシュの重要な機能を実行します。 場合によっては、すべてのサブスクライブしているクライアントが othertimes に新しい値を送信するには、どのデバイスを選択することを通知する必要があります。 

```csharp
async void NotifyValue()
{
    var writer = new DataWriter();
    // Populate writer with data
    // ...
    
    await notifyCharacteristic.NotifyValueAsync(writer.DetachBuffer());
}
```

サブスクライブすると、新しいデバイスの通知、SubscribedClientsChanged イベントに呼び出されます。 

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
> アプリケーションが、通知の最大サイズを取得、MaxNotificationSize プロパティを使って特定のクライアントことに注意してください。  最大サイズよりも大きいすべてのデータは、システムによって切り捨てられます。
