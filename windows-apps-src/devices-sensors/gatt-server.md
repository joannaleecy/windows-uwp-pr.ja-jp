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
# <a name="bluetooth-gatt-server"></a>Bluetooth GATT サーバー


**重要な API**
- [**Windows.Devices.Bluetooth**](https://msdn.microsoft.com/library/windows/apps/Dn263413)
- [**Windows.Devices.Bluetooth.GenericAttributeProfile**](https://msdn.microsoft.com/library/windows/apps/Dn297685)


この記事では、GATT サーバーの一般的なタスクのサンプル コードのほか、どこからでも Windows プラットフォーム (UWP) のアプリの Bluetooth 汎用属性 (GATT) サーバー Api を示します。 
- サポートされているサービスを定義します。
- リモート クライアントを検出できるようにサーバーを公開します。
- サービスのサポートを提供します。
- 読み取りおよび書き込み要求に応答します。
- 購読しているクライアントに通知を送信します。

## <a name="overview"></a>概要
Windows は、通常の役割は、クライアントで動作します。 ただし、Windows も Bluetooth LE GATT サーバーとして機能が必要な多くのシナリオが発生します。 IoT デバイスでは、ほとんどのプラットフォーム BLE コミュニケーションと、ほぼすべてのシナリオには、Windows GATT サーバーが必要です。 さらに、携帯機器の近くに通知を送信する一般的なシナリオにも、このテクノロジが必要なとなっています。  
> [GATT クライアント ドキュメント](gatt-client.md)内のすべての概念は続行する前にクリアすることを確認します。  

サーバーの処理がサービス プロバイダーと、GattLocalCharacteristic の中心です。 これら 2 つのクラスは宣言、実装およびリモート デバイスへのデータの階層を公開するために必要な機能を提供します。

## <a name="define-the-supported-services"></a>サポートされているサービスを定義します。
アプリでは、Windows で公開される 1 つ以上のサービスを宣言可能性があります。 各サービスは、UUID を一意に識別します。 

### <a name="attributes-and-uuids"></a>属性と Uuid
各サービス、特徴および表してが定義されている独自の一意の 128 ビット UUID はでします。
> GUID、用語を使用するすべての Windows Api が Bluetooth 標準 Uuid としてを定義します。 今回は、次の 2 つの用語は互換性 UUID 用語を使用するためされます。 

対応する 16 ビット短い ID があります属性が標準および Bluetooth 署名定義して定義済みの場合は、(バッテリ レベル UUID 0000**2A19**は、たとえば-0000-1000-8000-00805F9B34FB 短い ID、0x2A19)。 これらの標準的な Uuid [GattServiceUuids](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.genericattributeprofile.gattserviceuuids.aspx)および[GattCharacteristicUuids](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.genericattributeprofile.gattcharacteristicuuids.aspx)で表示できます。

アプリを実装する場合は、独自のカスタム サービスは、カスタム UUID が生成する必要があります。 これは、簡単に完了ツールを使って、Visual Studio でクリックし、[CreateGuid (使用オプション 5 を実行して、"xxxx チーム-xxxx-..."の形式で)。 この uuid は、新しいローカル サービス、特性などの宣言を今すぐ使用できます。

#### <a name="restricted-services"></a>サービスの制限
次のサービスでは、システムによって予約されており、現時点で公開することはできません。
1. デバイス情報サービス (無効)
2. 一般的な属性プロファイル サービス (GATT)
3. Access の一般的なプロファイル サービス (ギャップ)
4. ヒューマン インターフェイス デバイス サービス (HOGP)
5. スキャン パラメーター サービス (SCP)

> ブロックされているサービスを作成しようとしていますが、CreateAsync に通話から返される BluetoothError.DisabledByPolicy で発生します。

#### <a name="generated-attributes"></a>生成された属性
次の記述子は、自動生成された特性の作成時に提供された GattLocalCharacteristicParameters に基づいて、システムによってです。
1. クライアントの特性の構成 (特性が、indicatable または通知用としてマークされている) 場合。
2. 特性ユーザーに応じて説明も入力 (いることのプロパティが設定されます)。 さらに詳しい情報の GattLocalCharacteristicParameters.UserDescription プロパティを参照してください。
3. 特性の形式 (指定された各プレゼンテーション形式で表してを 1 つ)。  さらに詳しい情報の GattLocalCharacteristicParameters.PresentationFormats プロパティを参照してください。
4. 特性集計書式設定 (この場合は、複数のプレゼンテーション形式を指定した場合)。  さらに詳しい情報の GattLocalCharacteristicParameters.See PresentationFormats プロパティ。
5. (特性には、拡張されたプロパティのビットが付いている) 場合、特性のことに拡張されたプロパティ。

> 拡張プロパティ表しての値は ReliableWrites と WritableAuxiliaries 特性プロパティを使用して決定されます。

> 予約表してを作成しようとすると、例外が発生します。

> 現時点では、ブロードキャスト メモはサポートされていません。  ブロードキャスト GattCharacteristicProperty を指定すると、例外が発生します。

### <a name="build-up-the-heirarchy-of-services-and-characteristics"></a>サービスと特性の階層を作成します。
作成してルート プライマリ サービスの定義を提供する、GattServiceProvider を使用します。  各サービスでは、GUID では、独自のサービス プロバイダー オブジェクトが必要です。 

```csharp
GattServiceProviderResult result = await GattServiceProvider.CreateAsync(uuid);

if (result.Error == BluetoothError.Success)
{
    serviceProvider = result.ServiceProvider;
    // 
}
```
> GATT ツリーの最上位レベルのプライマリ サービスが表示されます。 プライマリ サービスには、特性とその他のサービス ('含める' または第 2 のサービスと呼ばれる) が含まれています。 

これで、必要な特性記述子とサービスを設定します。

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
上記のように、これは、それぞれの特性がサポートしている操作のイベント ハンドラーを宣言する適切な場所。  正常に要求に応答するアプリ必要があります定義され、属性がサポートしている各要求の種類のイベント ハンドラーを設定します。  わかりませんハンドラーを登録すると、システムで*UnlikelyError*とすぐに完了する要求が発生します。

### <a name="constant-characteristics"></a>一定の特性
場合によっては、アプリの有効期間中に変更はありません特性の値があります。 その場合は、不要なアプリのライセンス認証を防ぐために一定の特性を宣言することをお勧めします。 

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
## <a name="publish-the-service"></a>サービスを発行します。
サービスが完全に定義した後、次の手順では、サービスのサポートを発行します。 リモート デバイス サービスの検索を実行するときに、サービスが返されることを OS に通知されます。  -IsDiscoverable と IsConnectable の 2 つのプロパティを設定する必要があります。  

```csharp
GattServiceProviderAdvertisingParameters advParameters = new GattServiceProviderAdvertisingParameters
{
    IsDiscoverable = true,
    IsConnectable = true
};
serviceProvider.StartAdvertising(advParameters);
```
- **IsDiscoverable**: デバイスを検出できること、広告にリモート デバイスにわかりやすい名前を通知します。
- **IsConnectable**: 周辺の役割で使用する接続可能な広告を通知します。

> サービスは、検出可能と Connectable の両方が、システムは広告パケットにサービス Uuid を追加します。  広告パケットに 31 バイトだけが、それらの 16 占めます、128 ビット UUID.

> いるサービスが前面に公開されると、アプリケーションを呼び出す必要があります StopAdvertising アプリケーションを中断するときに注意してください。

## <a name="respond-to-read-and-write-requests"></a>読み取りおよび書き込み要求に応答します。
見たよう上に必要な特性を宣言するときに、GattLocalCharacteristics は 3 種類のイベントの ReadRequested、WriteRequested および SubscribedClientsChanged があります。

### <a name="read"></a>Read
リモート デバイス特性から値を読み取るしようとする (と定数の値になっていません)、ReadRequested イベントが呼び出されます。 読み取りが引数 (リモート デバイスに関する情報を含む) だけでなく上と呼ばれる特徴は、代理人に渡されます。 

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
リモート デバイス特性に値を作成しようとすると、書き込みをする特徴と、値そのものリモート デバイスに関する詳細を含む WriteRequested イベントが呼び出されます。 

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
応答がないと書き込みの 2 種類があります。 GattWriteOption (GattWriteRequest オブジェクトのプロパティ) を使用して、リモートのデバイスを実行している [文章入力の種類を把握します。 

## <a name="send-notifications-to-subscribed-clients"></a>購読しているクライアントに通知を送信します。
GATT サーバーの操作、通知の中で最も頻繁には、リモート デバイスにデータを遅らせての重要な機能を実行します。 場合によっては、[すべての購読しているクライアントが othertimes に新しい値を送信するには、どのデバイスを選択することを通知する必要があります。 

```csharp
async void NotifyValue()
{
    var writer = new DataWriter();
    // Populate writer with data
    // ...
    
    await notifyCharacteristic.NotifyValueAsync(writer.DetachBuffer());
}
```

新しいデバイスでは、通知をサブスクライブするときに SubscribedClientsChanged イベントが呼び出されます。 

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
> アプリケーションが MaxNotificationSize プロパティを使用して特定のクライアントの通知の最大サイズを取得することに注意してください。  システムの最大サイズを超えるデータが切り捨てられます。
