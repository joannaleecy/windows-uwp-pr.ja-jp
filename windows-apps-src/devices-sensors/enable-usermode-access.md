---
title: GPIO、I2C、SPI へのユーザー モード アクセスの有効化
description: このチュートリアルでは、Windows 10 で GPIO、I2C、SPI、および UART へのユーザー モード アクセスを有効にする方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, UWP, ACPI, GPIO, I2C, SPI, UEFI
ms.assetid: 2fbdfc78-3a43-4828-ae55-fd3789da7b34
ms.localizationpriority: medium
ms.openlocfilehash: 442b3b9328212a5115384b5175b519b76286dd28
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8324294"
---
# <a name="enable-usermode-access-to-gpio-i2c-and-spi"></a>GPIO、I2C、SPI へのユーザー モード アクセスの有効化

Windows 10 には、GPIO、I2C、SPI、UART にユーザー モードから直接アクセスするための新しい API が含まれています。 Raspberry Pi 2 のような開発ボードは、特定のアプリケーションに対処するためにユーザーがカスタム回路を使って基本計算モジュールを拡張できるようにする、これらの接続のサブセットを公開しています。 通常、これらの低レベル バスはその他の重要なオンボード機能と共有され、GPIO ピンのサブセットとバスのみがヘッダーで公開されます。 システムの安定性を維持するために、どのピンとバスの変更が安全かをユーザー モード アプリケーションで指定する必要があります。

このドキュメントでは、ACPI でこの構成を指定する方法を説明し、構成が正しく指定されていることを検証するためのツールを提供します。

> [!IMPORTANT]
> このドキュメントの対象者は、UEFI と ACPI の開発者です。 ACPI、ASL 作成、SpbCx/GpioClx についてある程度の知識があることを前提としています。

Windows での低レベル バスへのユーザー モード アクセスは、既存の `GpioClx` および `SpbCx` フレームワークを通じて組み込まれています。 Windows 10 IoT Core と Windows Enterprise で使用可能な *RhProxy* という新しいドライバーが、`GpioClx` リソースと `SpbCx` リソースをユーザー モードに公開します。 API を有効にするには、ユーザー モードに公開する GPIO リソースと SPB リソースのそれぞれで、ACPI テーブル内で rhproxy 用のデバイス ノードが宣言されている必要があります。 このドキュメントでは、ASL の作成と検証について説明します。

## <a name="asl-by-example"></a>ASL の例

Raspberry Pi 2 での rhproxy デバイス ノードの宣言について説明します。 最初に、\\_SB スコープで ACPI デバイス宣言を作成します。

```cpp
Device(RHPX)
{
    Name(_HID, "MSFT8000")
    Name(_CID, "MSFT8000")
    Name(_UID, 1)
}
```

* _HID: ハードウェア ID です。ベンダー固有のハードウェア ID に設定します。
* _CID: 互換性 ID です。"MSFT8000" にする必要があります。
* _UID: 一意の ID です。1 に設定します。

次に、ユーザー モードに公開する GPIO リソースと SPB リソースをそれぞれ宣言します。 プロパティとリソースを関連付けるためにリソース インデックスが使われるため、リソースが宣言される順序は重要です。 複数の I2C または SPI バスが公開されている場合は、最初に宣言されているバスがその種類のバスの '既定' と見なされ、[Windows.Devices.I2c.I2cController](https://msdn.microsoft.com/library/windows/apps/windows.devices.i2c.i2ccontroller.aspx) および [Windows.Devices.Spi.SpiController](https://msdn.microsoft.com/library/windows/apps/windows.devices.spi.spicontroller.aspx) の `GetDefaultAsync()` メソッドによって返されるインスタンスになります。

### <a name="spi"></a>SPI

Raspberry Pi には 2 つの公開されている SPI バスがあります。 SPI0 には 2 つのハードウェア チップ選択線があり、SPI1 には 1 つのハードウェア チップ選択線があります。 各バスの各チップ選択線に 1 つの SPISerialBus() リソース宣言が必要です。 次の 2 つの SPISerialBus リソース宣言は、SPI0 の 2 つのチップ選択線用です。 DeviceSelection フィールドには、ドライバーがハードウェア チップ選択線識別子として解釈する一意の値が含まれます。 DeviceSelection フィールドに入れる正確な値は、ACPI 接続記述子のこのフィールドをドライバーがどのように解釈するかによって異なります。

```cpp
// Index 0
SPISerialBus(              // SCKL - GPIO 11 - Pin 23
                           // MOSI - GPIO 10 - Pin 19
                           // MISO - GPIO 9  - Pin 21
                           // CE0  - GPIO 8  - Pin 24
    0,                     // Device selection (CE0)
    PolarityLow,           // Device selection polarity
    FourWireMode,          // wiremode
    0,                     // databit len: placeholder
    ControllerInitiated,   // slave mode
    0,                     // connection speed: placeholder
    ClockPolarityLow,      // clock polarity: placeholder
    ClockPhaseFirst,       // clock phase: placeholder
    "\\_SB.SPI0",          // ResourceSource: SPI bus controller name
    0,                     // ResourceSourceIndex
                           // Resource usage
    )                      // Vendor Data

// Index 1
SPISerialBus(              // SCKL - GPIO 11 - Pin 23
                           // MOSI - GPIO 10 - Pin 19
                           // MISO - GPIO 9  - Pin 21
                           // CE1  - GPIO 7  - Pin 26
    1,                     // Device selection (CE1)
    PolarityLow,           // Device selection polarity
    FourWireMode,          // wiremode
    0,                     // databit len: placeholder
    ControllerInitiated,   // slave mode
    0,                     // connection speed: placeholder
    ClockPolarityLow,      // clock polarity: placeholder
    ClockPhaseFirst,       // clock phase: placeholder
    "\\_SB.SPI0",          // ResourceSource: SPI bus controller name
    0,                     // ResourceSourceIndex
                           // Resource usage
    )                      // Vendor Data

```

ソフトウェアはどのようにしてこれらの 2 つのリソースを同じバスに関連付ける必要があることを把握するのでしょうか。 バスのフレンドリ名とリソース インデックスの間のマッピングが DSD で指定されます。

```cpp
Package(2) { "bus-SPI-SPI0", Package() { 0, 1 }},
```

これにより、2 つのチップ選択線 (リソース インデックス 0 および 1) を持つ “SPI0” という名前のバスが作成されます。 SPI バスの機能を宣言するには、さらにいくつかのプロパティが必要です。

```cpp
Package(2) { "SPI0-MinClockInHz", 7629 },
Package(2) { "SPI0-MaxClockInHz", 125000000 },
```

**MinClockInHz** および **MaxClockInHz** プロパティは、コントローラーでサポートされる最小および最大のクロック速度を指定します。 API はこの範囲外の値をユーザーが指定できないようにします。 クロック速度は接続記述子の _SPE フィールドの SPB ドライバーに渡されます (ACPI セクション 6.4.3.8.2.2)。

```cpp
Package(2) { "SPI0-SupportedDataBitLengths", Package() { 8 }},
```

**SupportedDataBitLengths** プロパティには、コントローラーでサポートされるデータのビット長が一覧表示されます。 コンマ区切りの一覧で複数の値を指定することができます。 API はこの一覧以外の値をユーザーが指定できないようにします。 データのビット長は接続記述子の _LEN フィールドの SPB ドライバーに渡されます (ACPI セクション 6.4.3.8.2.2)。

これらのリソース宣言は “テンプレート” として考えることができます。 システムの起動時に固定されるフィールドと、実行時に動的に指定されるフィールドがあります。 SPISerialBus 記述子の次のフィールドは固定されています。

* DeviceSelection
* DeviceSelectionPolarity
* WireMode
* SlaveMode
* ResourceSource

次のフィールドは、実行時にユーザーによって指定される値のプレースホルダーです。

* DataBitLength
* ConnectionSpeed
* ClockPolarity
* ClockPhase

SPI1 には単一のチップ選択行のみが含まれているため、単一の `SPISerialBus()` リソースが宣言されます。

```cpp
// Index 2
SPISerialBus(              // SCKL - GPIO 21 - Pin 40
                           // MOSI - GPIO 20 - Pin 38
                           // MISO - GPIO 19 - Pin 35
                           // CE1  - GPIO 17 - Pin 11
    1,                     // Device selection (CE1)
    PolarityLow,           // Device selection polarity
    FourWireMode,          // wiremode
    0,                     // databit len: placeholder
    ControllerInitiated,   // slave mode
    0,                     // connection speed: placeholder
    ClockPolarityLow,      // clock polarity: placeholder
    ClockPhaseFirst,       // clock phase: placeholder
    "\\_SB.SPI1",          // ResourceSource: SPI bus controller name
    0,                     // ResourceSourceIndex
                           // Resource usage
    )                      // Vendor Data

```

付随する必須のフレンドリ名宣言は DSD で指定され、このリソース宣言のインデックスを参照します。

```cpp
Package(2) { "bus-SPI-SPI1", Package() { 2 }},
```

これにより “SPI1” という名前のバスが作成され、リソース インデックス 2 に関連付けられます。

#### <a name="spi-driver-requirements"></a>SPI ドライバーの要件

* `SpbCx` を使うか、SpbCx と互換性がある必要があります
* [MITT SPI テスト](https://msdn.microsoft.com/library/windows/hardware/dn919873.aspx)に合格している必要があります
* 4 Mhz のクロック周波数をサポートしている必要があります
* 8 ビットのデータ長をサポートしている必要があります
* すべての SPI モード (0、1、2、3) をサポートしている必要があります

### <a name="i2c"></a>I2C

次に、I2C リソースを宣言します。 Raspberry Pi はピン 3 および 5 で単一の I2C バスを公開しています。

```cpp
// Index 3
I2CSerialBus(              // Pin 3 (GPIO2, SDA1), 5 (GPIO3, SCL1)
    0xFFFF,                // SlaveAddress: placeholder
    ,                      // SlaveMode: default to ControllerInitiated
    0,                     // ConnectionSpeed: placeholder
    ,                      // Addressing Mode: placeholder
    "\\_SB.I2C1",          // ResourceSource: I2C bus controller name
    ,
    ,
    )                      // VendorData

```

付随する必須のフレンドリ名宣言は DSD で指定されます。

```cpp
Package(2) { "bus-I2C-I2C1", Package() { 3 }},
```

これは、上記の説明で宣言した I2CSerialBus() リソースのインデックスであるリソース インデックス 3 を参照する、フレンドリ名 “I2C1” の I2C バスを宣言します。

I2CSerialBus() 記述子の次のフィールドは固定されています。

* SlaveMode
* ResourceSource

次のフィールドは、実行時にユーザーによって指定される値のプレースホルダーです。

* SlaveAddress
* ConnectionSpeed
* AddressingMode

#### <a name="i2c-driver-requirements"></a>I2C ドライバーの要件

* SpbCx を使うか、SpbCx と互換性がある必要があります
* [MITT I2C テスト](https://msdn.microsoft.com/library/windows/hardware/dn919852.aspx)に合格している必要があります
* 7 ビットのアドレス指定をサポートしている必要があります
* 100 kHz のクロック周波数をサポートしている必要があります
* 400 kHz のクロック周波数をサポートしている必要があります

### <a name="gpio"></a>GPIO

次に、ユーザー モードに公開されるすべての GPIO ピンを宣言します。 どのピンを公開するかを判断するために、次のガイダンスを提供しています。

* 公開されるヘッダーのすべてのピンを宣言します。
* ボタンや LED などの役立つオンボード機能に接続されているピンを宣言します。
* システム機能のために予約されているピン、または何にも接続されていないピンは宣言しません。

ASL の次のブロックでは、GPIO4 と GPIO5 の 2 つのピンが宣言されます。 簡潔にするために、その他のピンはここでは示しません。 付録 C には、GPIO リソースを生成するために使うことができるサンプル powershell スクリプトが含まれています。

```cpp
// Index 4 – GPIO 4
GpioIO(Shared, PullUp, , , , “\\_SB.GPI0”, , , , ) { 4 }
GpioInt(Edge, ActiveBoth, Shared, PullUp, 0, “\\_SB.GPI0”,) { 4 }

// Index 6 – GPIO 5
GpioIO(Shared, PullUp, , , , “\\_SB.GPI0”, , , , ) { 5 }
GpioInt(Edge, ActiveBoth, Shared, PullUp, 0, “\\_SB.GPI0”,) { 5 }
```

GPIO ピンを宣言するときは、次の要件を順守する必要があります。

* メモリ マップ GPIO コントローラーのみがサポートされています。 I2C/SPI 経由で接続された GPIO コントローラーはサポートされていません。 [CLIENT_QueryControllerBasicInformation](https://msdn.microsoft.com/library/windows/hardware/hh439399.aspx) コールバックへの応答で [CLIENT_CONTROLLER_BASIC_INFORMATION](https://msdn.microsoft.com/library/windows/hardware/hh439358.aspx) 構造に [MemoryMappedController](https://msdn.microsoft.com/library/windows/hardware/hh439449.aspx) フラグを設定する場合、コントローラー ドライバーはメモリ マップ コントローラーです。
* 各ピンに GpioIO リソースと GpioInt リソースの両方が必要です。 GpioInt リソースは GpioIO リソースの直後に続き、同じピン番号を参照する必要があります。
* GPIO リソースはピン番号の昇順で並べる必要があります。
* 各 GpioIO リソースと GpioInt リソースには、ピン一覧に正確に 1 つのピン番号を含める必要があります。
* 両方の記述子の ShareType フィールドが Shared である必要があります
* GpioInt 記述子の EdgeLevel フィールドが Edge である必要があります
* GpioInt 記述子の ActiveLevel フィールドが ActiveBoth である必要があります
* PinConfig フィールド
  * GpioIO 記述子と GpioInt 記述子の両方で同じである必要があります
  * PullUp、PullDown、PullNone のいずれかである必要があります。 PullDefault は指定できません。
  * プル構成がピンの電源投入時の状態と一致する必要があります。 ピンを電源投入時の状態から指定されたプル モードにしてもピンの状態が変更されないようにする必要があります。 たとえば、ピンでプル アップを使うようにデータシートで指定されている場合には、PinConfig を PullUp に指定する必要があります。

ファームウェア、UEFI、ドライバーの初期化コードが起動中の電源投入時の状態からピンの状態を変更しないようにする必要があります。 ユーザーのみがピンに何が接続されているかを把握しているため、どの状態遷移が安全かが分かります。 ピンと正しく接続されるハードウェアをユーザーが設計できるように、各ピンの電源投入時の状態を文書化する必要があります。 起動中にピンの状態が予期せず変更されないようにする必要があります。

#### <a name="supported-drive-modes"></a>サポートされるドライバー モデル

GPIO コントローラーで高インピーダンス入力と CMOS 出力に加えて組み込みのプル アップおよびプル ダウン抵抗がサポートされている場合は、オプションの SupportedDriveModes プロパティを使って指定する必要があります。

```cpp
Package (2) { “GPIO-SupportedDriveModes”, 0xf },
```

SupportedDriveModes プロパティは、GPIO コントローラーによってどのドライブ モードがサポートされるかを示します。 上記の例では、次のドライブ モードがすべてサポートされます。 このプロパティは、次の値のビットマスクです。

| フラグ値 | ドライブ モード | 説明 |
|------------|------------|-------------|
| 0x1        | InputHighImpedance | ピンが高インピーダンス入力をサポートします。ACPI の “PullNone” 値に対応します。 |
| 0x2        | InputPullUp | ピンが組み込みのプル アップ抵抗をサポートします。ACPI の “PullUp” 値に対応します。 |
| 0x4        | InputPullDown | ピンが組み込みのプル ダウン抵抗をサポートします。ACPI の “PullDown” 値に対応します。 |
| 0x8        | OutputCmos | ピンが (オープン ドレインとは対照的に) ストロング ハイとストロング ローの両方の生成をサポートします。 |

InputHighImpedance と OutputCmos はほぼすべての GPIO コントローラーでサポートされています。 SupportedDriveModes プロパティが指定されていない場合は、既定になります。

GPIO 信号が公開されているヘッダーに到達する前にレベル シフターを通過する場合は、ドライブ モードが外部ヘッダーで監視可能でない場合でも、SOC によってサポートされているドライブ モードを宣言します。 たとえば、ピンを抵抗プル アップを備えたオープン ドレインとして表す双方向レベル シフターをピンが通過する場合は、ピンが高インピーダンス入力として構成されている場合でも、公開されたヘッダーで高インピーダンス状態は観測されません。 この場合も、ピンが高インピーダンス入力をサポートすることを宣言する必要があります。

#### <a name="pin-numbering"></a>ピンの番号付け

Windows は、2 つのピンの番号付けスキームをサポートしています。

* 連番のピンの番号付け: 0、1、2 ... のように、公開されているピンの数までの番号がユーザーに表示されます。 0 は ASL で宣言されている最初の GpioIo リソース、1 は ASL で宣言されている 2 番目の GpioIo リソースなどのようになります。
* ネイティブのピンの番号付け: 4、5、12、13 ... などの、GpioIo 記述子で指定されたピン番号がユーザーに表示されます。

```cpp
Package (2) { “GPIO-UseDescriptorPinNumbers”, 1 },
```

**UseDescriptorPinNumbers** プロパティは、Windows が連番のピンの番号付けではなくネイティブのピンの番号付けを使うようにします。 UseDescriptorPinNumbers プロパティが指定されていない場合、または値が 0 の場合は、Windows は既定の連番のピンの番号付けを使います。

ネイティブのピンの番号付けを使う場合は、**PinCount** プロパティも指定する必要があります。

```cpp
Package (2) { “GPIO-PinCount”, 54 },
```

**PinCount** プロパティは、`GpioClx` ドライバーの [CLIENT_QueryControllerBasicInformation](https://msdn.microsoft.com/library/windows/hardware/hh439399.aspx) コールバックの **TotalPins** プロパティから返された値と一致する必要があります。

ボードの既存の公開されたドキュメントと最も互換性のある番号付けスキームを選択します。 たとえば、多くの既存のピン配列図が BCM2835 ピン番号を使っているため、Raspberry Pi はネイティブのピンの番号付けを使います。 200 個を超えるピンから 10 個のピンのみが公開されるため、既存のピン配列図が少なく、連番のピンの番号付けでは開発者のエクスペリエンスが単純化されるので、MinnowBoardMax は連番のピンの番号付けを使います。 連番のピンの番号付けを使うかネイティブのピンの番号付けを使うかの決定は、開発者の混乱を少なくすることを目的として行う必要があります。

#### <a name="gpio-driver-requirements"></a>GPIO ドライバーの要件

* を使う必要があります `GpioClx`
* SOC 上でメモリ マッピングする必要があります
* エミュレートされた ActiveBoth 割り込み処理を使う必要があります

### <a name="uart"></a>UART

UART ドライバーが `SerCx` または `SerCx2` を使用する場合、rhproxy を使用してこのドライバーをユーザー モードに公開することができます。 `GUID_DEVINTERFACE_COMPORT` 型のデバイス インターフェイスを作成する UART ドライバーでは、rhproxy を使用する必要はありません。 インボックス `Serial.sys` ドライバーも、このようなドライバーの 1 つです。

`SerCx` スタイルの UART をユーザー モードに公開するには、次のように `UARTSerialBus` リソースを宣言します。

```cpp
// Index 2
UARTSerialBus(           // Pin 17, 19 of JP1, for SIO_UART2
    115200,                // InitialBaudRate: in bits ber second
    ,                      // BitsPerByte: default to 8 bits
    ,                      // StopBits: Defaults to one bit
    0xfc,                  // LinesInUse: 8 1-bit flags to declare line enabled
    ,                      // IsBigEndian: default to LittleEndian
    ,                      // Parity: Defaults to no parity
    ,                      // FlowControl: Defaults to no flow control
    32,                    // ReceiveBufferSize
    32,                    // TransmitBufferSize
    "\\_SB.URT2",          // ResourceSource: UART bus controller name
    ,
    ,
    ,
    )
```

ResourceSource フィールドのみが固定され、その他のすべてのフィールドは実行時にユーザーによって指定される値のプレースホルダーとなります。

付随するフレンドリ名の宣言は次のようになります。

```cpp
Package(2) { "bus-UART-UART2", Package() { 2 }},
```

ユーザーがユーザー モードからバスにアクセスするために使う識別子である、フレンドリ名 “UART2” がコントローラーに割り当てられます。

## <a name="runtime-pin-muxing"></a>実行時のピンの多重化

ピンの多重化は、同じ物理ピンをさまざまな機能のために使う機能です。 I2C コントローラー、SPI コントローラー、GPIO コントローラーなどのいくつかのオンチップ周辺機器が、SOC の同じ物理ピンにルーティングされる可能性があります。 多重化ブロックは、任意の時間にどの機能がピンでアクティブになるかを制御します。 従来は、ファームウェアが機能の割り当てを起動時に確立し、この割り当ては起動セッションを通じて静的なままでした。 実行時のピンの多重化は、実行時にピンの機能の割り当てを再構成する機能を追加します。 実行時にユーザーがピンの機能を選択できるようにすると、ユーザーがボードのピンをすばやく再構成できるようになることで開発が高速化され、静的な構成の場合よりもハードウェアが広い範囲のアプリケーションをサポートできるようになります。

追加のコードを記述しなくても、ユーザーは GPIO、I2C、SPI、UART の多重化のサポートを利用できます。 ユーザーが [OpenPin()](https://msdn.microsoft.com/library/dn960157.aspx) または [FromIdAsync()](https://msdn.microsoft.com/windows.devices.i2c.i2cdevice.fromidasync) を使って GPIO を開くと、基になる物理ピンが要求された機能に対して自動的に多重化されます。 ピンが既に別の機能により使われている場合は、OpenPin() または FromIdAsync() の呼び出しは失敗します。 [GpioPin](https://msdn.microsoft.com/library/windows/apps/windows.devices.gpio.gpiopin.aspx)、[I2cDevice](https://msdn.microsoft.com/library/windows/apps/windows.devices.i2c.i2cdevice.aspx)、[SpiDevice](https://msdn.microsoft.com/library/windows/apps/windows.devices.spi.spidevice.aspx)、[SerialDevice](https://msdn.microsoft.com/library/windows/apps/windows.devices.serialcommunication.serialdevice.aspx) オブジェクトを廃棄することでユーザーがデバイスを閉じると、ピンが解放され、後で別の機能のために開くことができるようになります。

Windows では、[GpioClx](https://msdn.microsoft.com/library/windows/hardware/hh439515.aspx)、[SpbCx](https://msdn.microsoft.com/library/windows/hardware/hh406203.aspx)、[SerCx](https://msdn.microsoft.com/library/windows/hardware/dn265349.aspx) フレームワークにピンの多重化の組み込みサポートが含まれています。 これらのフレームワークは、GPIO ピンまたはバスがアクセスされたときに正しい機能にピンを自動的に切り替えるために、連携して機能します。 複数のクライアント間での競合を避けるために、ピンへのアクセスは適切に判別されます。 この組み込みサポートに加えて、ピンの多重化のためのインターフェイスとプロトコルは汎用のため、追加のデバイスとシナリオをサポートするために拡張できます。

このドキュメントでは、まずピンの多重化に関与する基となるインターフェイスとプロトコルについて説明してから、GpioClx、SpbCx、SerCx コントローラー ドライバーに対してピンの多重化のサポートを追加する方法について説明します。

### <a name="pin-muxing-architecture"></a>ピンの多重化のアーキテクチャ

このセクションでは、ピンの多重化に関与する基となるインターフェイスとプロトコルについて説明します。 基となるプロトコルの知識は、GpioClx/SpbCx/SerCx ドライバーによるピンの多重化のサポートに必ずしも必要ではありません。 GpioCls/SpbCx/SerCx ドライバーによるピンの多重化のサポート方法について詳しくは、「[GpioClx クライアント ドライバーでのピンの多重化のサポートの実装](#supporting-muxing-support-in-gpioclx-client-drivers)」と「[SpbCx および SerCx コントローラー ドライバーでの多重化のサポートの使用](#supporting-muxing-in-spbcx-and-sercx-controller-drivers)」をご覧ください。

ピンの多重化は、複数のコンポーネントが連携することで行われます。

* ピンの多重化のサーバーは、ピンの多重化の制御ブロックを制御するドライバーです。 ピンの多重化のサーバーは、多重化のリソースを予約するための要求 (*IRP_MJ_CREATE* 要求を使用) と、ピンの機能を切り替えるための要求 (*IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* 要求を使用) を介して、クライアントからピンの多重化の要求を受け取ります。 多重化ブロックが GPIO ブロックの一部である場合があるため、通常はピンの多重化のサーバーは GPIO ドライバーです。 多重化ブロックが別個の周辺機器の場合でも、GPIO ドライバーは多重化機能を配置するための理にかなった場所となります。
* ピンの多重化のクライアントは、ピンの多重化を使うドライバーです。 ピンの多重化のクライアントは ACPI ファームウェアからピンの多重化のリソースを受け取ります。 ピンの多重化のリソースは接続リソースの一種で、リソース ハブによって管理されます。 ピンの多重化のクライアントは、ハンドルをリソースに対して開くことでピンの多重化のリソースを予約します。 ハードウェアの変更を有効にするために、クライアントは *IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* 要求を送信して構成をコミットする必要があります。 クライアントはハンドルを閉じることでピンの多重化のリソースを解放し、この時点で多重化構成は既定の状態に戻ります。
* ACPI ファームウェアは、`MsftFunctionConfig()` リソースにより多重化構成を指定します。 MsftFunctionConfig リソースは、どのピンがどの多重化構成でクライアントにより必要とされるかを表します。 MsftFunctionConfig リソースには、機能番号、プル構成、ピン番号の一覧が含まれます。 MsftFunctionConfig リソースはハードウェア リソースとしてピンの多重化のクライアントに提供され、GPIO および SPB 接続リソースと同様に、ドライバーによって PrepareHardware コールバックで受け取られます。 クライアントは、リソースに対してハンドルを開くために使うことができるリソース ハブ ID を受け取ります。

> `MsftFunctionConfig()` 記述子を含んでいる ASL ファイルをコンパイルするには、`/MsftInternal` コマンド ライン スイッチを `asl.exe` に渡す必要があります。これは、これらの記述子が、ACPI 作業部会で現在検討中であるためです。 たとえば、次のように指定します。 `asl.exe /MsftInternal dsdt.asl`

ピンの多重化に関連する操作の順序を次に示します。

![ピンの多重化のクライアントとサーバーの相互作用](images/usermode-access-diagram-1.png)

1. クライアントは、[EvtDevicePrepareHardware()](https://msdn.microsoft.com/library/windows/hardware/ff540880.aspx) コールバックで、ACPI ファームウェアから MsftFunctionConfig リソースを受け取ります。
2. クライアントはリソース ハブ ヘルパー関数 `RESOURCE_HUB_CREATE_PATH_FROM_ID()` を使ってリソース ID からパスを作成し、([ZwCreateFile()](https://msdn.microsoft.com/library/windows/hardware/ff566424.aspx)、[IoGetDeviceObjectPointer()](https://msdn.microsoft.com/library/windows/hardware/ff549198.aspx)、または [WdfIoTargetOpen()](https://msdn.microsoft.com/library/windows/hardware/ff548634.aspx) を使って) そのパスに対してハンドルを開きます。
3. サーバーがリソース ハブ ヘルパー関数 `RESOURCE_HUB_ID_FROM_FILE_NAME()` を使ってファイル パスからリソース ハブ ID を抽出してから、リソース ハブを照会してリソース記述子を取得します。
4. サーバーは記述子内の各ピンの共有の判別を実行し、IRP_MJ_CREATE 要求を完了します。
5. クライアントが受け取ったハンドルに対する *IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* 要求を生成します。
6. *IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* に応えて、指定された機能を各ピンでアクティブにすることで、サーバーがハードウェアの多重化操作を実行します。
7. 要求されたピンの多重化構成に応じた操作でクライアントの処理が先に進みます。
8. クライアントでピンの多重化が不要になると、ハンドルが閉じられます。
9. 閉じられたハンドルに応じて、サーバーがピンを初期状態に戻します。

### <a name="protocol-description-for-pin-muxing-clients"></a>ピンの多重化のクライアントのためのプロトコルの説明

このセクションでは、クライアントがピンの多重化機能を使う方法について説明します。 コントローラー ドライバーの代わりにフレームワークがこのプロトコルを実装するため、`SerCx` および `SpbCx` コントローラー ドライバーには適用されません。

#### <a name="parsing-resources"></a>リソースの解析

WDF ドライバーが [EvtDevicePrepareHardware()](https://msdn.microsoft.com/library/windows/hardware/ff540880.aspx) ルーチンで `MsftFunctionConfig()` リソースを受け取ります。 MsftFunctionConfig リソースは、次のフィールドで識別できます。

```cpp
CM_PARTIAL_RESOURCE_DESCRIPTOR::Type = CmResourceTypeConnection
CM_PARTIAL_RESOURCE_DESCRIPTOR::u.Connection.Class = CM_RESOURCE_CONNECTION_CLASS_FUNCTION_CONFIG
CM_PARTIAL_RESOURCE_DESCRIPTOR::u.Connection.Type = CM_RESOURCE_CONNECTION_TYPE_FUNCTION_CONFIG
```

`EvtDevicePrepareHardware()` ルーチンは、次のように MsftFunctionConfig リソースを展開します。

```cpp
EVT_WDF_DEVICE_PREPARE_HARDWARE evtDevicePrepareHardware;

_Use_decl_annotations_
NTSTATUS
evtDevicePrepareHardware (
    WDFDEVICE WdfDevice,
    WDFCMRESLIST ResourcesTranslated
    )
{
    PAGED_CODE();

    LARGE_INTEGER connectionId;
    ULONG functionConfigCount = 0;

    const ULONG resourceCount = WdfCmResourceListGetCount(ResourcesTranslated);
    for (ULONG index = 0; index < resourceCount; ++index) {
        const CM_PARTIAL_RESOURCE_DESCRIPTOR* resDescPtr =
            WdfCmResourceListGetDescriptor(ResourcesTranslated, index);

        switch (resDescPtr->Type) {
        case CmResourceTypeConnection:
            switch (resDescPtr->u.Connection.Class) {
            case CM_RESOURCE_CONNECTION_CLASS_FUNCTION_CONFIG:
                switch (resDescPtr->u.Connection.Type) {
                case CM_RESOURCE_CONNECTION_TYPE_FUNCTION_CONFIG:
                    switch (functionConfigCount) {
                    case 0:
                        // save the connection ID
                        connectionId.LowPart = resDescPtr->u.Connection.IdLowPart;
                        connectionId.HighPart = resDescPtr->u.Connection.IdHighPart;
                        break;
                    } // switch (functionConfigCount)
                    ++functionConfigCount;
                    break; // CM_RESOURCE_CONNECTION_TYPE_FUNCTION_CONFIG

                } // switch (resDescPtr->u.Connection.Type)
                break; // CM_RESOURCE_CONNECTION_CLASS_FUNCTION_CONFIG
            } // switch (resDescPtr->u.Connection.Class)
            break;
        } // switch
    } // for (resource list)

    if (functionConfigCount < 1) {
        return STATUS_INVALID_DEVICE_CONFIGURATION;
    }
    // TODO: save connectionId in the device context for later use

    return STATUS_SUCCESS;
}
```

#### <a name="reserving-and-committing-resources"></a>リソースの予約とコミット

クライアントでピンの多重化が必要な場合、MsftFunctionConfig リソースを予約してコミットします。 次の例は、クライアントが MsftFunctionConfig リソースを予約してコミットする方法を示しています。

```cpp
_IRQL_requires_max_(PASSIVE_LEVEL)
NTSTATUS AcquireFunctionConfigResource (
    WDFDEVICE WdfDevice,
    LARGE_INTEGER ConnectionId,
    _Out_ WDFIOTARGET* ResourceHandlePtr
    )
{
    PAGED_CODE();

    //
    // Form the resource path from the connection ID
    //
    DECLARE_UNICODE_STRING_SIZE(resourcePath, RESOURCE_HUB_PATH_CHARS);
    NTSTATUS status = RESOURCE_HUB_CREATE_PATH_FROM_ID(
            &resourcePath,
            ConnectionId.LowPart,
            ConnectionId.HighPart);
    if (!NT_SUCCESS(status)) {
        return status;
    }

    //
    // Create a WDFIOTARGET
    //
    WDFIOTARGET resourceHandle;
    status = WdfIoTargetCreate(WdfDevice, WDF_NO_ATTRIBUTES, &resourceHandle);
    if (!NT_SUCCESS(status)) {
        return status;
    }

    //
    // Reserve the resource by opening a WDFIOTARGET to the resource
    //
    WDF_IO_TARGET_OPEN_PARAMS openParams;
    WDF_IO_TARGET_OPEN_PARAMS_INIT_OPEN_BY_NAME(
        &openParams,
        &resourcePath,
        FILE_GENERIC_READ | FILE_GENERIC_WRITE);

    status = WdfIoTargetOpen(resourceHandle, &openParams);
    if (!NT_SUCCESS(status)) {
        return status;
    }
    //
    // Commit the resource
    //
    status = WdfIoTargetSendIoctlSynchronously(
            resourceHandle,
            WDF_NO_HANDLE,      // WdfRequest
            IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS,
            nullptr,            // InputBuffer
            nullptr,            // OutputBuffer
            nullptr,            // RequestOptions
            nullptr);           // BytesReturned

    if (!NT_SUCCESS(status)) {
        WdfIoTargetClose(resourceHandle);
        return status;
    }

    //
    // Pins were successfully muxed, return the handle to the caller
    //
    *ResourceHandlePtr = resourceHandle;
    return STATUS_SUCCESS;
}
```

ドライバーは、後で閉じることができるように、WDFIOTARGET をいずれかのコンテキスト領域に格納する必要があります。 ドライバーが多重化構成を解放する準備ができたら、[WdfObjectDelete()](https://msdn.microsoft.com/library/windows/hardware/ff548734.aspx) を呼び出すか、WDFIOTARGET を再利用する場合には [WdfIoTargetClose()](https://msdn.microsoft.com/library/windows/hardware/ff548586.aspx) を呼び出してリソース ハンドルを閉じる必要があります。

```cpp
    WdfObjectDelete(resourceHandle);
```

クライアントがそのリソース ハンドルを閉じると、ピンは多重化されて初期状態に戻され、別のクライアントで取得できるようになります。

### <a name="protocol-description-for-pin-muxing-servers"></a>ピンの多重化のサーバーのためのプロトコルの説明

このセクションでは、ピンの多重化のサーバーがその機能をクライアントに公開する方法について説明します。 クライアント ドライバーの代わりにフレームワークがこのプロトコルを実装するため、`GpioClx` ミニポート ドライバーには適用されません。 `GpioClx` クライアント ドライバーでピンの多重化をサポートする方法について詳しくは、「[GpioClx クライアント ドライバーでの多重化のサポートの実装](#supporting-muxing-support-in-gpioclx-client-drivers)」をご覧ください。

#### <a name="handling-irpmjcreate-requests"></a>IRP_MJ_CREATE 要求の処理

クライアントは、ピンの多重化のリソースを予約するときにリソースに対してハンドルを開きます。 ピンの多重化のサーバーが、リソース ハブからの再解析操作により *IRP_MJ_CREATE* 要求を受け取ります。 *IRP_MJ_CREATE* 要求の末尾のパス コンポーネントには、16 進数形式の 64 ビット整数であるリソース ハブ ID が含まれています。 サーバーは、reshub.h から `RESOURCE_HUB_ID_FROM_FILE_NAME()` を使ってファイル名からリソース ハブ ID を抽出し、*IOCTL_RH_QUERY_CONNECTION_PROPERTIES* をリソース ハブに送信して `MsftFunctionConfig()` 記述子を取得する必要があります。

サーバーは記述子を検証して、共有モードとピンの一覧を記述子から抽出する必要があります。 その後、ピンの共有の判別を実行し、成功した場合には、要求を完了する前にピンを予約済みとしてマークします。

ピンの一覧の各ピンで共有の判別が成功すると、全体的な共有の判別が成功します。 各ピンは次のように判別する必要があります。

* ピンがまだ予約されていない場合、共有の判別は成功します。
* ピンが既に排他的に予約されている場合、共有の判別は失敗します。
* ピンが既に共有として予約されていて、
  * 着信要求が共有されている場合、共有の判定は成功します。
  * 着信要求が排他的な場合、共有の判別は失敗します。

共有の判別に失敗した場合は、*STATUS_GPIO_INCOMPATIBLE_CONNECT_MODE* で要求を完了する必要があります。 共有の判別に成功した場合は、*STATUS_SUCCESS* で要求を完了する必要があります。

着信要求の共有モードは、[IrpSp->Parameters.Create.ShareAccess](https://msdn.microsoft.com/library/windows/hardware/ff548630.aspx) ではなく MsftFunctionConfig 記述子から取得する必要があることに注意してください。

#### <a name="handling-ioctlgpiocommitfunctionconfigpins-requests"></a>IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS 要求の処理

クライアントがハンドルを開くことで MsftFunctionConfig リソースの予約に成功した後は、*IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* を送信して実際のハードウェア多重化操作を実行するようサーバーに要求することができます。 サーバーが *IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* を受け取ると、ピンの一覧の各ピンは、

* PNP_FUNCTION_CONFIG_DESCRIPTOR 構造の PinConfiguration メンバーで指定されたプル モードをハードウェアに設定する必要があります。
* PNP_FUNCTION_CONFIG_DESCRIPTOR 構造の FunctionNumber メンバーによって指定された機能に対してピンを多重化する必要があります。

サーバーはその後、*STATUS_SUCCESS* を使って要求を完了する必要があります。

FunctionNumber の意味はサーバーによって定義され、サーバーが MsftFunctionConfig のフィールドをどのように解釈して、MsftFunctionConfig 記述子が作成されたかがわかります。

ハンドルが閉じられたときにサーバーは IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS が受け取られたときの構成にピンを戻す必要があるため、ピンの状態を変更する前に保存する必要があることに注意してください。

#### <a name="handling-irpmjclose-requests"></a>IRP_MJ_CLOSE 要求の処理

クライアントで多重化のリソースが不要になったときは、そのハンドルを閉じます。 サーバーが *IRP_MJ_CLOSE* 要求を受け取ったときに、*IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* が受け取られたときの状態にピンを戻す必要があります。 クライアントが *IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* を送信しない場合、操作は不要です。 サーバーはその後、共有の判別に関して利用可能とピンをマークし、*STATUS_SUCCESS* を使って要求を完了する必要があります。 *IRP_MJ_CLOSE* の処理と *IRP_MJ_CREATE* の処理を正しく同期してください。

### <a name="authoring-guidelines-for-acpi-tables"></a>ACPI テーブルの作成のガイドライン

このセクションでは、クライアント ドライバーに多重化のリソースを指定する方法について説明します。 `MsftFunctionConfig()` リソースを含むテーブルをコンパイルするために、Microsoft ASL コンパイラ ビルド 14327 以降が必要となることに注意してください。 `MsftFunctionConfig()` リソースは、ピンの多重化のクライアントにハードウェア リソースとして提供されます。 `MsftFunctionConfig()` リソースは、ピンの多重化の変更が必要なドライバーに提供する必要があります。これは通常 SPB およびシリアル コントローラー ドライバーですが、コントローラー ドライバーが多重化構成を扱うため、SPB およびシリアル周辺機器ドライバーには提供しません。
`MsftFunctionConfig()` ACPI マクロは、次のように定義されています。

```cpp
  MsftFunctionConfig(Shared/Exclusive
                PinPullConfig,
                FunctionNumber,
                ResourceSource,
                ResourceSourceIndex,
                ResourceConsumer/ResourceProducer,
                VendorData) { Pin List }

```

* Shared/Exclusive – 排他的な場合、このピンは一度に単一のクライアントで取得できます。 共有の場合、複数の共有クライアントがリソースを取得できます。 調整がされていない複数のクライアントによる変更可能なリソースへのアクセスを許可すると、データの競合につながり、予期しない結果となる可能性があるため、常に排他的に設定します。
* PinPullConfig – 次のいずれかに設定します。
  * PullDefault – SOC 定義の電源投入時の既定のプル構成を使います
  * PullUp – プル アップ抵抗を有効にします
  * PullDown – プル ダウン抵抗を有効にします
  * PullNone – すべてのプル抵抗を無効にします
* FunctionNumber – 多重化にプログラムする機能番号です。
* ResourceSource – ピンの多重化のサーバーの ACPI 名前空間パスです
* ResourceSourceIndex – 0 に設定します
* ResourceConsumer/ResourceProducer – ResourceConsumer に設定します
* VendorData – ピンの多重化のサーバーによって意味が定義される、オプションのバイナリ データです。 通常は空白のままにします
* Pin List – 構成を適用するピン番号のコンマ区切りの一覧です。 ピンの多重化のサーバーが GpioClx ドライバーの場合、これらは GPIO ピン番号になり、GpioIo 記述子のピン番号と同じ意味を持ちます。

次の例では、MsftFunctionConfig() リソースを I2C コントローラー ドライバーに提供する方法を示します。

```cpp
Device(I2C1)
{
    Name(_HID, "BCM2841")
    Name(_CID, "BCMI2C")
    Name(_UID, 0x1)
    Method(_STA)
    {
        Return(0xf)
    }
    Method(_CRS, 0x0, NotSerialized)
    {
        Name(RBUF, ResourceTemplate()
        {
            Memory32Fixed(ReadWrite, 0x3F804000, 0x20)
            Interrupt(ResourceConsumer, Level, ActiveHigh, Shared) { 0x55 }
            MsftFunctionConfig(Exclusive, PullUp, 4, "\\_SB.GPI0", 0, ResourceConsumer, ) { 2, 3 }
        })
        Return(RBUF)
    }
}
```

通常コントローラー ドライバーに必要なメモリと割り込みリソースに加えて、`MsftFunctionConfig()` リソースも指定します。 このリソースにより、I2C コントローラー ドライバーが (\\_SB.GPIO0 でデバイス ノードにより管理された) ピン 2 および 3 をプル アップ抵抗が有効になった状態で機能 4 に配置することができます。

## <a name="supporting-muxing-support-in-gpioclx-client-drivers"></a>GpioClx クライアント ドライバーでの多重化サポートのサポート

`GpioClx` には、ピンの多重化のための組み込みサポートがあります。 GpioClx ミニポート ドライバー (“GpioClx クライアント ドライバー” とも呼ばれます) が GPIO コントローラー ハードウェアを制御します。 Windows 10 ビルド 14327 以降では、GpioClx ミニポート ドライバーは 2 つの新しい DDI を実装することでピンの多重化のサポートを追加することができます。

* CLIENT_ConnectFunctionConfigPins – `GpioClx` によって呼び出され、ミニポート ドライバーが指定された多重化構成を適用するように指示を出します。
* CLIENT_DisconnectFunctionConfigPins – `GpioClx` によって呼び出され、ミニポート ドライバーが多重化構成を戻すように指示を出します。

これらのルーチンの説明については、「[GpioClx イベント コールバック関数](https://msdn.microsoft.com/library/windows/hardware/hh439464.aspx)」をご覧ください。

これらの 2 つの新しい DDI に加えて、既存の DDI もピンの多重化の互換性の監査対象とする必要があります。

* CLIENT_ConnectIoPins/CLIENT_ConnectInterrupt – CLIENT_ConnectIoPins は GpioClx によって呼び出され、ミニポート ドライバーが GPIO 入力または出力のための一連のピンを構成するように指示を出します。 GPIO は MsftFunctionConfig と相互に排他的なため、GPIO と MsftFunctionConfig に同時にピンが接続されることはありません。 ピンの既定の機能が GPIO である必要はないため、ConnectIoPins が呼び出されたときにピンが必ずしも GPIO に多重化されないとは限りません。 ConnectIoPins は、多重化操作を含む、GPIO IO のためのピンの準備に必要なすべての操作を実行するために必要です。 割り込みは GPIO 入力の特殊なケースと考えることができるため、*CLIENT_ConnectInterrupt* も同様に動作する必要があります。
* CLIENT_DisconnectIoPins/CLIENT_DisconnectInterrupt – これらのルーチンは、PreserveConfiguration フラグが指定されていない限り、CLIENT_ConnectIoPins/CLIENT_ConnectInterrupt が呼び出されたときの状態にピンを戻す必要があります。 ピンの方向を既定の状態に戻すだけでなく、ミニポートが各ピンの多重化の状態を _Connect routine が呼び出されたときの状態に戻す必要もあります。

たとえば、ピンの既定の多重化構成が UART で、ピンが GPIO としても使うことができると想定します。 GPIO のピンの接続のために CLIENT_ConnectIoPins が呼び出されると、ピンを GPIO に多重化する必要があり、CLIENT_DisconnectIoPins でピンを UART に多重化して戻す必要があります。 一般的に、_Disconnect ルーチンは _Connect ルーチンによって行われた操作を元に戻す必要があります。

## <a name="supporting-muxing-in-spbcx-and-sercx-controller-drivers"></a>SpbCx および SerCx コントローラー ドライバーでの多重化のサポート

Windows 10 ビルド 14327 以降では、`SpbCx` および `SerCx` コントローラー ドライバーをコントローラー ドライバー自体のコードを変更せずにピンの多重化のクライアントにできるようにする、ピンの多重化のための組み込みサポートが `SpbCx` および `SerCx` フレームワークに含まれています。 拡張機能によって、多重化対応の SpbCx/SerCx コントローラー ドライバーに接続する SpbCx/SerCx 周辺機器ドライバーがピンの多重化アクティビティをトリガーします。

次の図は、これらの各コンポーネント間の依存関係を示しています。 図に示されているように、ピンの多重化は SerCx および SpbCx コントローラー ドライバーからの依存関係を GPIO ドライバーに導入し、通常はこれにより多重化が行われます。

![ピンの多重化の依存関係](images/usermode-access-diagram-2.png)

デバイスの初期化時に、`SpbCx` および `SerCx` フレームワークがハードウェア リソースとしてデバイスに提供されたすべての `MsftFunctionConfig()` リソースを解析します。 SpbCx/SerCx はその後、必要に応じてピンの多重化のリソースを取得および解放します。

`SpbCx` は、クライアント ドライバーの [EvtSpbTargetConnect()](https://msdn.microsoft.com/library/windows/hardware/hh450818.aspx) コールバックの呼び出しの直前に、*IRP_MJ_CREATE* ハンドラー内のピンの多重化構成を適用します。 多重化構成を適用できなかった場合、コントローラー ドライバーの `EvtSpbTargetConnect()` コールバックは呼び出されません。 そのため、SPB コントローラー ドライバーは `EvtSpbTargetConnect()` が呼び出されたときまでにピンが SPB 機能に対して多重化されていると想定することができます。

`SpbCx` は、コントローラー ドライバーの [EvtSpbTargetDisconnect()](https://msdn.microsoft.com/library/windows/hardware/hh450820.aspx) コールバックを呼び出した直後に、*IRP_MJ_CLOSE* ハンドラー内のピンの多重化構成に戻します。 その結果、周辺機器ドライバーが SPB コントローラー ドライバーに対してハンドルを開くたびにピンが SPB 機能に対して多重化され、周辺機器ドライバーがハンドルを閉じると多重化が終了します。

`SerCx` も同様に動作します。 `SerCx` は、コントローラー ドライバーの [EvtSerCx2FileOpen()](https://msdn.microsoft.com/library/windows/hardware/dn265209.aspx) コールバックの呼び出しの直前に *IRP_MJ_CREATE* ハンドラー内のすべての `MsftFunctionConfig()` リソースを取得し、コントローラー ドライバーの [EvtSerCx2FileClose](https://msdn.microsoft.com/library/windows/hardware/dn265208.aspx) コールバックが呼び出された直後に IRP_MJ_CLOSE ハンドラー内のすべてのリソースを解放します。

`SerCx` および `SpbCx` コントローラー ドライバーのための動的なピンの多重化の実装では、特定の時間で SPB/UART 機能のピンの多重化が終了することを許容できる必要があります。 コントローラー ドライバーは、`EvtSpbTargetConnect()` または `EvtSerCx2FileOpen()` が呼び出されるまでピンが多重化されないことを前提とする必要があります。 次のコールバック中に必ずしもピンが SPB/UART 機能に多重化される必要はありません。 次に示すのは完全な一覧ではありませんが、コントローラー ドライバーによって実装される最も一般的な PNP ルーチンを示しています。

* DriverEntry
* EvtDriverDeviceAdd
* EvtDevicePrepareHardware/EvtDeviceReleaseHardware
* EvtDeviceD0Entry/EvtDeviceD0Exit

## <a name="verification"></a>検証

rhproxy をテストする準備ができたら、次の手順を使用すると便利です。

1. `SpbCx`、`GpioClx`、`SerCx` の各コントローラー ドライバーの読み込みと正しい動作を確認します。
1. `rhproxy` がシステムに存在することを確認します。 Windows のエディションやビルドによっては、これが含まれていない場合があります。
1. 次を使用して rhproxy ノードをコンパイルして読み込みます。 `ACPITABL.dat`
1. `rhproxy` デバイス ノードが存在することを確認します。
1. `rhproxy` が読み込まれ、開始されていることを確認します。
1. 想定されているデバイスがユーザー モードに公開されていることを確認します。
1. コマンド ラインから各デバイスを操作できることを確認します。
1. UWP アプリから各デバイスを操作できることを確認します。
1. HLK テストを実行します。

### <a name="verify-controller-drivers"></a>コントローラー ドライバーを確認する

rhproxy は、システム上の他のデバイスもユーザー モードに公開するため、それらのデバイスが既に動作している場合にのみ動作します。 最初の手順では、それらのデバイス (公開する I2C、SPI、GPIO コントローラー) が既に動作していることを確認します。

コマンド プロンプトで、次のコマンドを実行します。

```ps
devcon status *
```

出力を確認し、対象となるすべてのデバイスが起動されていることを確認します。 デバイスに問題コードがある場合は、そのデバイスが読み込まれなかった理由を解決する必要があります。 プラットフォームの最初の起動時にすべてのデバイスが有効になっている必要があります。 `SpbCx`、`GpioClx`、または `SerCx` コントローラー ドライバーのトラブルシューティングについては、このドキュメントでは説明しません。

### <a name="verify-that-rhproxy-is-present-on-the-system"></a>rhproxy がシステムに存在することを確認する

`rhproxy` サービスがシステムに存在することを確認します。

```ps
reg query HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Services\rhproxy
```

このレジストリ キーが存在しない場合、rhproxy はシステムに存在しません。 rhproxy は、IoT Core のすべてのビルドと Windows Enterprise ビルド 15063 以降に存在します。

### <a name="compile-and-load-asl-with-acpitabldat"></a>ACPITABL.dat を使用して ASL をコンパイルして読み込む

rhproxy ASL ノードを作成したら、これをコンパイルして読み込みます。 システムの ACPI テーブルに追加できるスタンドアロン AML ファイルに、rhproxy ノードをコンパイルすることができます。 または、システムの ACPI ソースにアクセスできる場合は、プラットフォームの ACPI テーブルに直接 rhproxy ノードを挿入できます。 ただし、最初の起動時には、`ACPITABL.dat` を使用する方が容易な場合があります。

1. yourboard.asl という名前のファイルを作成し、DefinitionBlock 内に RHPX デバイス ノードを配置します。

```cpp
DefinitionBlock ("ACPITABL.dat", "SSDT", 1, "MSFT", "RHPROXY", 1)
{
    Scope (\_SB)
    {
        Device(RHPX)
        {
        ...
        }
    }
}
```

2. [WDK](https://docs.microsoft.com/windows-hardware/drivers/download-the-wdk) をダウンロードし、次の場所で `asl.exe` を検索します。 `C:\Program Files (x86)\Windows Kits\10\Tools\x64\ACPIVerify`
3. 次のコマンドを実行して ACPITABL.dat を生成します。

```ps
asl.exe yourboard.asl
```

4. 生成された ACPITABL.dat ファイルを、テスト対象のシステムの c:\windows\system32 にコピーします。
5. テスト対象のシステムでテスト署名を有効にします。

```ps
bcdedit /set testsigning on
```

6. テスト対象のシステムを再起動します。 システムが ACPITABL.dat で定義された ACPI テーブルをシステム ファームウェア テーブルに追加します。

### <a name="verify-that-the-rhproxy-device-node-exists"></a>rhproxy デバイス ノードが存在することを確認する

次のコマンドを実行して、rhproxy デバイス ノードを列挙します。

```ps
devcon status *msft8000
```

devcon の出力は、デバイスが存在することを示している必要があります。 デバイス ノードが存在しない場合、ACPI テーブルはシステムに正常に追加されていません。

### <a name="verify-that-rhproxy-is-loading-and-starting"></a>rhproxy が読み込まれ、開始されていることを確認する

rhproxy の状態を確認します。

```ps
devcon status *msft8000
```

出力が rhproxy が開始されていることを示している場合、rhproxy は正常に読み込まれて開始されています。 問題のコードが表示された場合は、調査する必要があります。 一般的な問題コードには次のようなものがあります。

* 問題 51 - `CM_PROB_WAITING_ON_DEPENDENCY` -その依存関係のいずれかが読み込みに失敗したため、システムは rhproxy を開始していません。 これは、rhproxy に渡されたリソースが無効な ACPI ノードを指しているか、ターゲット デバイスが起動していないことを意味します。 最初に、すべてのデバイスが正常に実行されていることを再確認します (上記の「コントローラー ドライバーを確認する」を参照)。 次に、ASL を再確認し、すべてのリソース パス (例: `\_SB.I2C1`) が正しく、DSDT 内の有効なノードを指していることを確認します。
* 問題 10 - `CM_PROB_FAILED_START` - rhproxy を開始できませんでした。ほとんどの場合、リソースの解析の問題が原因です。 ASL を調べて、DSD 内のリソースのインデックスを再確認し、ピン番号の昇順で GPIO リソースが指定されていることを確認します。

### <a name="verify-that-the-expected-devices-are-exposed-to-usermode"></a>想定されているデバイスがユーザー モードに公開されていることを確認する

rhproxy が実行されると、ユーザー モードからアクセスできるデバイス インターフェイスが作成されています。 いくつかのコマンド ライン ツールを使用してデバイスを列挙し、デバイスが存在していることを確認します。

複製、[https://github.com/ms-iot/samples](https://github.com/ms-iot/samples)リポジトリとビルド、 `GpioTestTool`、 `I2cTestTool`、 `SpiTestTool`、および`Mincomm`サンプルです。 テスト対象デバイスにツールをコピーし、次のコマンドを使用してデバイスを列挙します。

```ps
I2cTestTool.exe -list
SpiTestTool.exe -list
GpioTestTool.exe -list
MinComm.exe -list
```

デバイスとフレンドリ名の一覧が表示されます。 右側のデバイスとフレンドリ名が表示されない場合は、ASL を再確認してください。

### <a name="verify-each-device-on-the-command-line"></a>コマンド ラインで各デバイスを確認する

次の手順では、コマンド ライン ツールを使用して、デバイスを開き、操作します。

I2CTestTool の例:

```ps
I2cTestTool.exe 0x55 I2C1
> write {1 2 3}
> read 3
> writeread {1 2 3} 3
```

SpiTestTool の例:

```ps
SpiTestTool.exe -n SPI1
> write {1 2 3}
> read 3
```

GpioTestTool の例:

```ps
GpioTestTool.exe 12
> setdrivemode output
> write 0
> write 1
> setdrivemode input
> read
> interrupt on
> interrupt off
```

MinComm (シリアル) の例。 実行する前に Tx に Rx を接続します。

```ps
MinComm "\\?\ACPI#FSCL0007#3#{86e0d1e0-8089-11d0-9ce4-08003e301f73}\0000000000000006"
(type characters and see them echoed back)
```

### <a name="verify-each-device-from-a-uwp-app"></a>UWP アプリから各デバイスを確認する

次のサンプルを使用して、UWP からデバイスが動作することを確認します。

| サンプル | リンク |
|------|------|
| IoT-GPIO | https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/IoT-GPIO |
| IoT-I2C | https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/IoT-I2C |
| IoT-SPI | https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/IoT-SPI |
| CustomSerialDeviceAccess | https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CustomSerialDeviceAccess |

### <a name="run-the-hlk-tests"></a>HLK テストの実行

[Hardware Lab Kit (HLK)](https://docs.microsoft.com/windows-hardware/test/hlk/windows-hardware-lab-kit) をダウンロードします。 以下のテストが用意されています。

* [GPIO WinRT 機能とストレス テスト](https://docs.microsoft.com/windows-hardware/test/hlk/testref/f1fc0922-1186-48bd-bfcd-c7385a2f6f96)
* [I2C WinRT 書き込みテスト (EEPROM が必要)](https://docs.microsoft.com/windows-hardware/test/hlk/testref/2ab0df1b-3369-4aaf-a4d5-d157cb7bf578)
* [I2C WinRT 読み取りテスト (EEPROM が必要)](https://docs.microsoft.com/windows-hardware/test/hlk/testref/ca91c2d2-4615-4a1b-928e-587ab2b69b04)
* [I2C WinRT 存在しないスレーブ アドレス テスト](https://docs.microsoft.com/windows-hardware/test/hlk/testref/2746ad72-fe5c-4412-8231-f7ed53d95e71)
* [I2C WinRT 高度な機能テスト (mbed LPC1768 が必要)](https://docs.microsoft.com/windows-hardware/test/hlk/testref/a60f5a94-12b2-4905-8416-e9774f539f1d)
* [SPI WinRT クロック周波数検証テスト (mbed LPC1768 が必要)](https://docs.microsoft.com/windows-hardware/test/hlk/testref/50cf9ccc-bbd3-4514-979f-b0499cb18ed8)
* [SPI WinRT IO 転送テスト (mbed LPC1768 が必要)](https://docs.microsoft.com/windows-hardware/test/hlk/testref/00c892e8-c226-4c71-9c2a-68349fed7113)
* [SPI WinRT ストライド検証テスト](https://docs.microsoft.com/windows-hardware/test/hlk/testref/20c6b079-62f7-4067-953f-e252bd271938)
* [SPI WinRT 転送ギャップ検出テスト (mbed LPC1768 が必要)](https://docs.microsoft.com/windows-hardware/test/hlk/testref/6da79d04-940b-4c49-8f00-333bf0cfbb19)

HLK マネージャーで rhproxy デバイス ノードを選択すると、適用できるテストが自動的に選択されます。

HLK マネージャーで、[Resource Hub Proxy device] を選択します。

![HLK マネージャーのスクリーンショット](images/usermode-hlk-1.png)

その後、[テスト] タブをクリックし、I2C WinRT、Gpio WinRT、Spi WinRT のテストを選択します。

![HLK マネージャーのスクリーンショット](images/usermode-hlk-2.png)

[選択したテストの実行] をクリックします。 各テストに関するその他のドキュメントは、テストを右クリックして [テストの説明] をクリックすることで利用できます。

## <a name="resources"></a>リソース

| 移動先 | リンク |
|-------------|------|
| ACPI 5.0 の仕様 | http://acpi.info/spec.htm |
| Asl.exe (Microsoft ASL Compiler) | https://msdn.microsoft.com/library/windows/hardware/dn551195.aspx |
| Windows.Devices.Gpio | https://msdn.microsoft.com/library/windows/apps/windows.devices.gpio.aspx |
| Windows.Devices.I2c | https://msdn.microsoft.com/library/windows/apps/windows.devices.i2c.aspx |
| Windows.Devices.Spi | https://msdn.microsoft.com/library/windows/apps/windows.devices.spi.aspx |
| Windows.Devices.SerialCommunication | https://msdn.microsoft.com/library/windows/apps/windows.devices.serialcommunication.aspx |
| Test Authoring and Execution Framework (TAEF) | https://msdn.microsoft.com/library/windows/hardware/hh439725.aspx |
| SpbCx | https://msdn.microsoft.com/library/windows/hardware/hh450906.aspx |
| GpioClx | https://msdn.microsoft.com/library/windows/hardware/hh439508.aspx |
| SerCx | https://msdn.microsoft.com/library/windows/hardware/ff546939.aspx |
| MITT I2C テスト | https://msdn.microsoft.com/library/windows/hardware/dn919852.aspx |
| GpioTestTool | https://developer.microsoft.com/windows/iot/samples/GPIOTestTool |
| I2cTestTool | https://developer.microsoft.com/windows/iot/samples/I2cTestTool |
| SpiTestTool | https://developer.microsoft.com/windows/iot/samples/spitesttool |
| MinComm (シリアル) | https://github.com/ms-iot/samples/tree/develop/MinComm |
| ハードウェア ラボ キット (HLK) | https://msdn.microsoft.com/library/windows/hardware/dn930814.aspx |

## <a name="apendix"></a>付録

### <a name="appendix-a---raspberry-pi-asl-listing"></a>付録 A - Raspberry Pi ASL の一覧

ヘッダーのピン配列:https://developer.microsoft.com/windows/iot/samples/PinMappingsRPi2

```cpp
DefinitionBlock ("ACPITABL.dat", "SSDT", 1, "MSFT", "RHPROXY", 1)
{

    Scope (\_SB)
    {
        //
        // RHProxy Device Node to enable WinRT API
        //
        Device(RHPX)
        {
            Name(_HID, "MSFT8000")
            Name(_CID, "MSFT8000")
            Name(_UID, 1)

            Name(_CRS, ResourceTemplate()
            {
                // Index 0
                SPISerialBus(              // SCKL - GPIO 11 - Pin 23
                                           // MOSI - GPIO 10 - Pin 19
                                           // MISO - GPIO 9  - Pin 21
                                           // CE0  - GPIO 8  - Pin 24
                    0,                     // Device selection (CE0)
                    PolarityLow,           // Device selection polarity
                    FourWireMode,          // wiremode
                    0,                     // databit len: placeholder
                    ControllerInitiated,   // slave mode
                    0,                     // connection speed: placeholder
                    ClockPolarityLow,      // clock polarity: placeholder
                    ClockPhaseFirst,       // clock phase: placeholder
                    "\\_SB.SPI0",          // ResourceSource: SPI bus controller name
                    0,                     // ResourceSourceIndex
                                           // Resource usage
                    )                      // Vendor Data

                // Index 1
                SPISerialBus(              // SCKL - GPIO 11 - Pin 23
                                           // MOSI - GPIO 10 - Pin 19
                                           // MISO - GPIO 9  - Pin 21
                                           // CE1  - GPIO 7  - Pin 26
                    1,                     // Device selection (CE1)
                    PolarityLow,           // Device selection polarity
                    FourWireMode,          // wiremode
                    0,                     // databit len: placeholder
                    ControllerInitiated,   // slave mode
                    0,                     // connection speed: placeholder
                    ClockPolarityLow,      // clock polarity: placeholder
                    ClockPhaseFirst,       // clock phase: placeholder
                    "\\_SB.SPI0",          // ResourceSource: SPI bus controller name
                    0,                     // ResourceSourceIndex
                                           // Resource usage
                    )                      // Vendor Data

                // Index 2
                SPISerialBus(              // SCKL - GPIO 21 - Pin 40
                                           // MOSI - GPIO 20 - Pin 38
                                           // MISO - GPIO 19 - Pin 35
                                           // CE1  - GPIO 17 - Pin 11
                    1,                     // Device selection (CE1)
                    PolarityLow,           // Device selection polarity
                    FourWireMode,          // wiremode
                    0,                     // databit len: placeholder
                    ControllerInitiated,   // slave mode
                    0,                     // connection speed: placeholder
                    ClockPolarityLow,      // clock polarity: placeholder
                    ClockPhaseFirst,       // clock phase: placeholder
                    "\\_SB.SPI1",          // ResourceSource: SPI bus controller name
                    0,                     // ResourceSourceIndex
                                           // Resource usage
                    )                      // Vendor Data
                // Index 3
                I2CSerialBus(              // Pin 3 (GPIO2, SDA1), 5 (GPIO3, SCL1)
                    0xFFFF,                // SlaveAddress: placeholder
                    ,                      // SlaveMode: default to ControllerInitiated
                    0,                     // ConnectionSpeed: placeholder
                    ,                      // Addressing Mode: placeholder
                    "\\_SB.I2C1",          // ResourceSource: I2C bus controller name
                    ,
                    ,
                    )                      // VendorData

                // Index 4 - GPIO 4 -
                GpioIO(Shared, PullUp, , , , "\\_SB.GPI0", , , , ) { 4 }
                GpioInt(Edge, ActiveBoth, Shared, PullUp, 0, "\\_SB.GPI0",) { 4 }
                // Index 6 - GPIO 5 -
                GpioIO(Shared, PullUp, , , , "\\_SB.GPI0", , , , ) { 5 }
                GpioInt(Edge, ActiveBoth, Shared, PullUp, 0, "\\_SB.GPI0",) { 5 }
                // Index 8 - GPIO 6 -
                GpioIO(Shared, PullUp, , , , "\\_SB.GPI0", , , , ) { 6 }
                GpioInt(Edge, ActiveBoth, Shared, PullUp, 0, "\\_SB.GPI0",) { 6 }
                // Index 10 - GPIO 12 -
                GpioIO(Shared, PullDown, , , , "\\_SB.GPI0", , , , ) { 12 }
                GpioInt(Edge, ActiveBoth, Shared, PullDown, 0, "\\_SB.GPI0",) { 12 }
                // Index 12 - GPIO 13 -
                GpioIO(Shared, PullDown, , , , "\\_SB.GPI0", , , , ) { 13 }
                GpioInt(Edge, ActiveBoth, Shared, PullDown, 0, "\\_SB.GPI0",) { 13 }
                // Index 14 - GPIO 16 -
                GpioIO(Shared, PullDown, , , , "\\_SB.GPI0", , , , ) { 16 }
                GpioInt(Edge, ActiveBoth, Shared, PullDown, 0, "\\_SB.GPI0",) { 16 }
                // Index 16 - GPIO 18 -
                GpioIO(Shared, PullDown, , , , "\\_SB.GPI0", , , , ) { 18 }
                GpioInt(Edge, ActiveBoth, Shared, PullDown, 0, "\\_SB.GPI0",) { 18 }
                // Index 18 - GPIO 22 -
                GpioIO(Shared, PullDown, , , , "\\_SB.GPI0", , , , ) { 22 }
                GpioInt(Edge, ActiveBoth, Shared, PullDown, 0, "\\_SB.GPI0",) { 22 }
                // Index 20 - GPIO 23 -
                GpioIO(Shared, PullDown, , , , "\\_SB.GPI0", , , , ) { 23 }
                GpioInt(Edge, ActiveBoth, Shared, PullDown, 0, "\\_SB.GPI0",) { 23 }
                // Index 22 - GPIO 24 -
                GpioIO(Shared, PullDown, , , , "\\_SB.GPI0", , , , ) { 24 }
                GpioInt(Edge, ActiveBoth, Shared, PullDown, 0, "\\_SB.GPI0",) { 24 }
                // Index 24 - GPIO 25 -
                GpioIO(Shared, PullDown, , , , "\\_SB.GPI0", , , , ) { 25 }
                GpioInt(Edge, ActiveBoth, Shared, PullDown, 0, "\\_SB.GPI0",) { 25 }
                // Index 26 - GPIO 26 -
                GpioIO(Shared, PullDown, , , , "\\_SB.GPI0", , , , ) { 26 }
                GpioInt(Edge, ActiveBoth, Shared, PullDown, 0, "\\_SB.GPI0",) { 26 }
                // Index 28 - GPIO 27 -
                GpioIO(Shared, PullDown, , , , "\\_SB.GPI0", , , , ) { 27 }
                GpioInt(Edge, ActiveBoth, Shared, PullDown, 0, "\\_SB.GPI0",) { 27 }
                // Index 30 - GPIO 35 -
                GpioIO(Shared, PullUp, , , , "\\_SB.GPI0", , , , ) { 35 }
                GpioInt(Edge, ActiveBoth, Shared, PullUp, 0, "\\_SB.GPI0",) { 35 }
                // Index 32 - GPIO 47 -
                GpioIO(Shared, PullUp, , , , "\\_SB.GPI0", , , , ) { 47 }
                GpioInt(Edge, ActiveBoth, Shared, PullUp, 0, "\\_SB.GPI0",) { 47 }
            })

            Name(_DSD, Package()
            {
                ToUUID("daffd814-6eba-4d8c-8a91-bc9bbf4aa301"),
                Package()
                {
                    // Reference http://www.raspberrypi.org/documentation/hardware/raspberrypi/spi/README.md
                    // SPI 0
                    Package(2) { "bus-SPI-SPI0", Package() { 0, 1 }},                       // Index 0 & 1
                    Package(2) { "SPI0-MinClockInHz", 7629 },                               // 7629 Hz
                    Package(2) { "SPI0-MaxClockInHz", 125000000 },                          // 125 MHz
                    Package(2) { "SPI0-SupportedDataBitLengths", Package() { 8 }},          // Data Bit Length
                    // SPI 1
                    Package(2) { "bus-SPI-SPI1", Package() { 2 }},                          // Index 2
                    Package(2) { "SPI1-MinClockInHz", 30518 },                              // 30518 Hz
                    Package(2) { "SPI1-MaxClockInHz", 125000000 },                          // 125 MHz
                    Package(2) { "SPI1-SupportedDataBitLengths", Package() { 8 }},          // Data Bit Length
                    // I2C1
                    Package(2) { "bus-I2C-I2C1", Package() { 3 }},
                    // GPIO Pin Count and supported drive modes
                    Package (2) { "GPIO-PinCount", 54 },
                    Package (2) { "GPIO-UseDescriptorPinNumbers", 1 },
                    Package (2) { "GPIO-SupportedDriveModes", 0xf },                        // InputHighImpedance, InputPullUp, InputPullDown, OutputCmos
                }
            })
        }
    }
}

```

### <a name="appendix-b---minnowboardmax-asl-listing"></a>付録 B - MinnowBoardMax ASL の一覧

ヘッダーのピン配列:https://developer.microsoft.com/windows/iot/samples/PinMappingsMBM

```cpp
DefinitionBlock ("ACPITABL.dat", "SSDT", 1, "MSFT", "RHPROXY", 1)
{
    Scope (\_SB)
    {
        Device(RHPX)
        {
            Name(_HID, "MSFT8000")
            Name(_CID, "MSFT8000")
            Name(_UID, 1)

            Name(_CRS, ResourceTemplate()
            {
                // Index 0
                SPISerialBus(            // Pin 5, 7, 9 , 11 of JP1 for SIO_SPI
                    1,                     // Device selection
                    PolarityLow,           // Device selection polarity
                    FourWireMode,          // wiremode
                    8,                     // databit len
                    ControllerInitiated,   // slave mode
                    8000000,               // Connection speed
                    ClockPolarityLow,      // Clock polarity
                    ClockPhaseSecond,      // clock phase
                    "\\_SB.SPI1",          // ResourceSource: SPI bus controller name
                    0,                     // ResourceSourceIndex
                    ResourceConsumer,      // Resource usage
                    JSPI,                  // DescriptorName: creates name for offset of resource descriptor
                    )                      // Vendor Data

                // Index 1
                I2CSerialBus(            // Pin 13, 15 of JP1, for SIO_I2C5 (signal)
                    0xFF,                  // SlaveAddress: bus address
                    ,                      // SlaveMode: default to ControllerInitiated
                    400000,                // ConnectionSpeed: in Hz
                    ,                      // Addressing Mode: default to 7 bit
                    "\\_SB.I2C6",          // ResourceSource: I2C bus controller name (For MinnowBoard Max, hardware I2C5(0-based) is reported as ACPI I2C6(1-based))
                    ,
                    ,
                    JI2C,                  // Descriptor Name: creates name for offset of resource descriptor
                    )                      // VendorData

                // Index 2
                UARTSerialBus(           // Pin 17, 19 of JP1, for SIO_UART2
                    115200,                // InitialBaudRate: in bits ber second
                    ,                      // BitsPerByte: default to 8 bits
                    ,                      // StopBits: Defaults to one bit
                    0xfc,                  // LinesInUse: 8 1-bit flags to declare line enabled
                    ,                      // IsBigEndian: default to LittleEndian
                    ,                      // Parity: Defaults to no parity
                    ,                      // FlowControl: Defaults to no flow control
                    32,                    // ReceiveBufferSize
                    32,                    // TransmitBufferSize
                    "\\_SB.URT2",          // ResourceSource: UART bus controller name
                    ,
                    ,
                    UAR2,                  // DescriptorName: creates name for offset of resource descriptor
                    )

                // Index 3
                GpioIo (Shared, PullNone, 0, 0, IoRestrictionNone, "\\_SB.GPO2",) {0}  // Pin 21 of JP1 (GPIO_S5[00])
                // Index 4
                GpioInt(Edge, ActiveBoth, SharedAndWake, PullNone, 0,"\\_SB.GPO2",) {0}

                // Index 5
                GpioIo (Shared, PullNone, 0, 0, IoRestrictionNone, "\\_SB.GPO2",) {1}  // Pin 23 of JP1 (GPIO_S5[01])
                // Index 6
                GpioInt(Edge, ActiveBoth, SharedAndWake, PullNone, 0,"\\_SB.GPO2",) {1}

                // Index 7
                GpioIo (Shared, PullNone, 0, 0, IoRestrictionNone, "\\_SB.GPO2",) {2}  // Pin 25 of JP1 (GPIO_S5[02])
                // Index 8
                GpioInt(Edge, ActiveBoth, SharedAndWake, PullNone, 0,"\\_SB.GPO2",) {2}

                // Index 9
                UARTSerialBus(           // Pin 6, 8, 10, 12 of JP1, for SIO_UART1
                    115200,                // InitialBaudRate: in bits ber second
                    ,                      // BitsPerByte: default to 8 bits
                    ,                      // StopBits: Defaults to one bit
                    0xfc,                  // LinesInUse: 8 1-bit flags to declare line enabled
                    ,                      // IsBigEndian: default to LittleEndian
                    ,                      // Parity: Defaults to no parity
                    FlowControlHardware,   // FlowControl: Defaults to no flow control
                    32,                    // ReceiveBufferSize
                    32,                    // TransmitBufferSize
                    "\\_SB.URT1",          // ResourceSource: UART bus controller name
                    ,
                    ,
                    UAR1,              // DescriptorName: creates name for offset of resource descriptor
                    )

                // Index 10
                GpioIo (Shared, PullNone, 0, 0, IoRestrictionNone, "\\_SB.GPO0",) {62}  // Pin 14 of JP1 (GPIO_SC[62])
                // Index 11
                GpioInt(Edge, ActiveBoth, SharedAndWake, PullNone, 0,"\\_SB.GPO0",) {62}

                // Index 12
                GpioIo (Shared, PullNone, 0, 0, IoRestrictionNone, "\\_SB.GPO0",) {63}  // Pin 16 of JP1 (GPIO_SC[63])
                // Index 13
                GpioInt(Edge, ActiveBoth, SharedAndWake, PullNone, 0,"\\_SB.GPO0",) {63}

                // Index 14
                GpioIo (Shared, PullNone, 0, 0, IoRestrictionNone, "\\_SB.GPO0",) {65}  // Pin 18 of JP1 (GPIO_SC[65])
                // Index 15
                GpioInt(Edge, ActiveBoth, SharedAndWake, PullNone, 0,"\\_SB.GPO0",) {65}

                // Index 16
                GpioIo (Shared, PullNone, 0, 0, IoRestrictionNone, "\\_SB.GPO0",) {64}  // Pin 20 of JP1 (GPIO_SC[64])
                // Index 17
                GpioInt(Edge, ActiveBoth, SharedAndWake, PullNone, 0,"\\_SB.GPO0",) {64}

                // Index 18
                GpioIo (Shared, PullNone, 0, 0, IoRestrictionNone, "\\_SB.GPO0",) {94}  // Pin 22 of JP1 (GPIO_SC[94])
                // Index 19
                GpioInt(Edge, ActiveBoth, SharedAndWake, PullNone, 0,"\\_SB.GPO0",) {94}

                // Index 20
                GpioIo (Shared, PullNone, 0, 0, IoRestrictionNone, "\\_SB.GPO0",) {95}  // Pin 24 of JP1 (GPIO_SC[95])
                // Index 21
                GpioInt(Edge, ActiveBoth, SharedAndWake, PullNone, 0,"\\_SB.GPO0",) {95}

                // Index 22
                GpioIo (Shared, PullNone, 0, 0, IoRestrictionNone, "\\_SB.GPO0",) {54}  // Pin 26 of JP1 (GPIO_SC[54])
                // Index 23
                GpioInt(Edge, ActiveBoth, SharedAndWake, PullNone, 0,"\\_SB.GPO0",) {54}
            })

            Name(_DSD, Package()
            {
                ToUUID("daffd814-6eba-4d8c-8a91-bc9bbf4aa301"),
                Package()
                {
                    // SPI Mapping
                    Package(2) { "bus-SPI-SPI0", Package() { 0 }},

                    Package(2) { "SPI0-MinClockInHz", 100000 },
                    Package(2) { "SPI0-MaxClockInHz", 15000000 },
                    // SupportedDataBitLengths takes a list of support data bit length
                    // Example : Package(2) { "SPI0-SupportedDataBitLengths", Package() { 8, 7, 16 }},
                    Package(2) { "SPI0-SupportedDataBitLengths", Package() { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 }},
                     // I2C Mapping
                    Package(2) { "bus-I2C-I2C5", Package() { 1 }},
                    // UART Mapping
                    Package(2) { "bus-UART-UART2", Package() { 2 }},
                    Package(2) { "bus-UART-UART1", Package() { 9 }},
                }
            })
        }
    }
}
```

### <a name="appendix-c---sample-powershell-script-to-generate-gpio-resources"></a>付録 C - GPIO リソースを生成するためのサンプル Powershell スクリプト

次のスクリプトを使って、Raspberry Pi の GPIO リソース宣言を生成することができます。

```ps
$pins = @(
    @{PinNumber=4;PullConfig='PullUp'},
    @{PinNumber=5;PullConfig='PullUp'},
    @{PinNumber=6;PullConfig='PullUp'},
    @{PinNumber=12;PullConfig='PullDown'},
    @{PinNumber=13;PullConfig='PullDown'},
    @{PinNumber=16;PullConfig='PullDown'},
    @{PinNumber=18;PullConfig='PullDown'},
    @{PinNumber=22;PullConfig='PullDown'},
    @{PinNumber=23;PullConfig='PullDown'},
    @{PinNumber=24;PullConfig='PullDown'},
    @{PinNumber=25;PullConfig='PullDown'},
    @{PinNumber=26;PullConfig='PullDown'},
    @{PinNumber=27;PullConfig='PullDown'},
    @{PinNumber=35;PullConfig='PullUp'},
    @{PinNumber=47;PullConfig='PullUp'})

# generate the resources
$FIRST_RESOURCE_INDEX = 4
$resourceIndex = $FIRST_RESOURCE_INDEX
$pins | % {
    $a = @"
// Index $resourceIndex - GPIO $($_.PinNumber) - $($_.Name)
GpioIO(Shared, $($_.PullConfig), , , , "\\_SB.GPI0", , , , ) { $($_.PinNumber) }
GpioInt(Edge, ActiveBoth, Shared, $($_.PullConfig), 0, "\\_SB.GPI0",) { $($_.PinNumber) }
"@
    Write-Host $a
    $resourceIndex += 2;
}
```
