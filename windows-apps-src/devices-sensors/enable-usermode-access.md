---
author: JordanRh1
title: GPIO、I2C、SPI へのユーザー モード アクセスの有効化
description: このチュートリアルでは、Windows 10 で GPIO、I2C、SPI、および UART へのユーザー モード アクセスを有効にする方法について説明します。
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, UWP, ACPI, GPIO, I2C, SPI, UEFI
ms.assetid: 2fbdfc78-3a43-4828-ae55-fd3789da7b34
ms.localizationpriority: medium
ms.openlocfilehash: ead1ef6dc9c9a840b61b1d18567860d85201b26a
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7555413"
---
# <a name="enable-usermode-access-to-gpio-i2c-and-spi"></a><span data-ttu-id="bea62-104">GPIO、I2C、SPI へのユーザー モード アクセスの有効化</span><span class="sxs-lookup"><span data-stu-id="bea62-104">Enable usermode access to GPIO, I2C, and SPI</span></span>

<span data-ttu-id="bea62-105">Windows 10 には、GPIO、I2C、SPI、UART にユーザー モードから直接アクセスするための新しい API が含まれています。</span><span class="sxs-lookup"><span data-stu-id="bea62-105">Windows 10 contains new APIs for accessing GPIO, I2C, SPI, and UART directly from usermode.</span></span> <span data-ttu-id="bea62-106">Raspberry Pi 2 のような開発ボードは、特定のアプリケーションに対処するためにユーザーがカスタム回路を使って基本計算モジュールを拡張できるようにする、これらの接続のサブセットを公開しています。</span><span class="sxs-lookup"><span data-stu-id="bea62-106">Development boards like Raspberry Pi 2 expose a subset of these connections which enable users to extend a base compute module with custom circuitry to address a particular application.</span></span> <span data-ttu-id="bea62-107">通常、これらの低レベル バスはその他の重要なオンボード機能と共有され、GPIO ピンのサブセットとバスのみがヘッダーで公開されます。</span><span class="sxs-lookup"><span data-stu-id="bea62-107">These low level buses are usually shared with other critical onboard functions, with only a subset of GPIO pins and buses exposed on headers.</span></span> <span data-ttu-id="bea62-108">システムの安定性を維持するために、どのピンとバスの変更が安全かをユーザー モード アプリケーションで指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-108">To preserve system stability, it is necessary to specify which pins and buses are safe for modification by usermode applications.</span></span>

<span data-ttu-id="bea62-109">このドキュメントでは、ACPI でこの構成を指定する方法を説明し、構成が正しく指定されていることを検証するためのツールを提供します。</span><span class="sxs-lookup"><span data-stu-id="bea62-109">This document describes how to specify this configuration in ACPI and provides tools to validate that the configuration was specified correctly.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="bea62-110">このドキュメントの対象者は、UEFI と ACPI の開発者です。</span><span class="sxs-lookup"><span data-stu-id="bea62-110">The audience for this document is UEFI and ACPI developers.</span></span> <span data-ttu-id="bea62-111">ACPI、ASL 作成、SpbCx/GpioClx についてある程度の知識があることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="bea62-111">Some familiarity with ACPI, ASL authoring, and SpbCx/GpioClx is assumed.</span></span>

<span data-ttu-id="bea62-112">Windows での低レベル バスへのユーザー モード アクセスは、既存の `GpioClx` および `SpbCx` フレームワークを通じて組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="bea62-112">Usermode access to low level buses on Windows is plumbed through the existing `GpioClx` and `SpbCx` frameworks.</span></span> <span data-ttu-id="bea62-113">Windows 10 IoT Core と Windows Enterprise で使用可能な *RhProxy* という新しいドライバーが、`GpioClx` リソースと `SpbCx` リソースをユーザー モードに公開します。</span><span class="sxs-lookup"><span data-stu-id="bea62-113">A new driver called *RhProxy*, available on Windows IoT Core and Windows Enterprise, exposes `GpioClx` and `SpbCx` resources to usermode.</span></span> <span data-ttu-id="bea62-114">API を有効にするには、ユーザー モードに公開する GPIO リソースと SPB リソースのそれぞれで、ACPI テーブル内で rhproxy 用のデバイス ノードが宣言されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-114">To enable the APIs, a device node for rhproxy must be declared in your ACPI tables with each of the GPIO and SPB resources that should be exposed to usermode.</span></span> <span data-ttu-id="bea62-115">このドキュメントでは、ASL の作成と検証について説明します。</span><span class="sxs-lookup"><span data-stu-id="bea62-115">This document walks through authoring and verifying the ASL.</span></span>

## <a name="asl-by-example"></a><span data-ttu-id="bea62-116">ASL の例</span><span class="sxs-lookup"><span data-stu-id="bea62-116">ASL by example</span></span>

<span data-ttu-id="bea62-117">Raspberry Pi 2 での rhproxy デバイス ノードの宣言について説明します。</span><span class="sxs-lookup"><span data-stu-id="bea62-117">Let’s walk through the rhproxy device node declaration on Raspberry Pi 2.</span></span> <span data-ttu-id="bea62-118">最初に、\\_SB スコープで ACPI デバイス宣言を作成します。</span><span class="sxs-lookup"><span data-stu-id="bea62-118">First, create the ACPI device declaration in the \\_SB scope.</span></span>

```cpp
Device(RHPX)
{
    Name(_HID, "MSFT8000")
    Name(_CID, "MSFT8000")
    Name(_UID, 1)
}
```

* <span data-ttu-id="bea62-119">_HID: ハードウェア ID です。ベンダー固有のハードウェア ID に設定します。</span><span class="sxs-lookup"><span data-stu-id="bea62-119">_HID – Hardware Id. Set this to a vendor-specific hardware ID.</span></span>
* <span data-ttu-id="bea62-120">_CID: 互換性 ID です。"MSFT8000" にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-120">_CID – Compatible Id. Must be “MSFT8000”.</span></span>
* <span data-ttu-id="bea62-121">_UID: 一意の ID です。1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="bea62-121">_UID – Unique Id. Set to 1.</span></span>

<span data-ttu-id="bea62-122">次に、ユーザー モードに公開する GPIO リソースと SPB リソースをそれぞれ宣言します。</span><span class="sxs-lookup"><span data-stu-id="bea62-122">Next we declare each of the GPIO and SPB resources that should be exposed to usermode.</span></span> <span data-ttu-id="bea62-123">プロパティとリソースを関連付けるためにリソース インデックスが使われるため、リソースが宣言される順序は重要です。</span><span class="sxs-lookup"><span data-stu-id="bea62-123">The order in which resources are declared is important because resource indexes are used to associate properties with resources.</span></span> <span data-ttu-id="bea62-124">複数の I2C または SPI バスが公開されている場合は、最初に宣言されているバスがその種類のバスの '既定' と見なされ、[Windows.Devices.I2c.I2cController](https://msdn.microsoft.com/library/windows/apps/windows.devices.i2c.i2ccontroller.aspx) および [Windows.Devices.Spi.SpiController](https://msdn.microsoft.com/library/windows/apps/windows.devices.spi.spicontroller.aspx) の `GetDefaultAsync()` メソッドによって返されるインスタンスになります。</span><span class="sxs-lookup"><span data-stu-id="bea62-124">If there are multiple I2C or SPI busses exposed, the first declared bus is considered the ‘default’ bus for that type, and will be the instance returned by the `GetDefaultAsync()` methods of [Windows.Devices.I2c.I2cController](https://msdn.microsoft.com/library/windows/apps/windows.devices.i2c.i2ccontroller.aspx) and [Windows.Devices.Spi.SpiController](https://msdn.microsoft.com/library/windows/apps/windows.devices.spi.spicontroller.aspx).</span></span>

### <a name="spi"></a><span data-ttu-id="bea62-125">SPI</span><span class="sxs-lookup"><span data-stu-id="bea62-125">SPI</span></span>

<span data-ttu-id="bea62-126">Raspberry Pi には 2 つの公開されている SPI バスがあります。</span><span class="sxs-lookup"><span data-stu-id="bea62-126">Raspberry Pi has two exposed SPI buses.</span></span> <span data-ttu-id="bea62-127">SPI0 には 2 つのハードウェア チップ選択線があり、SPI1 には 1 つのハードウェア チップ選択線があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-127">SPI0 has two hardware chip select lines and SPI1 has one hardware chip select line.</span></span> <span data-ttu-id="bea62-128">各バスの各チップ選択線に 1 つの SPISerialBus() リソース宣言が必要です。</span><span class="sxs-lookup"><span data-stu-id="bea62-128">One SPISerialBus() resource declaration is required for each chip select line for each bus.</span></span> <span data-ttu-id="bea62-129">次の 2 つの SPISerialBus リソース宣言は、SPI0 の 2 つのチップ選択線用です。</span><span class="sxs-lookup"><span data-stu-id="bea62-129">The following two SPISerialBus resource declarations are for the two chip select lines on SPI0.</span></span> <span data-ttu-id="bea62-130">DeviceSelection フィールドには、ドライバーがハードウェア チップ選択線識別子として解釈する一意の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="bea62-130">The DeviceSelection field contains a unique value which the driver interprets as a hardware chip select line identifier.</span></span> <span data-ttu-id="bea62-131">DeviceSelection フィールドに入れる正確な値は、ACPI 接続記述子のこのフィールドをドライバーがどのように解釈するかによって異なります。</span><span class="sxs-lookup"><span data-stu-id="bea62-131">The exact value that you put in the DeviceSelection field depends on how your driver interprets this field of the ACPI connection descriptor.</span></span>

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

<span data-ttu-id="bea62-132">ソフトウェアはどのようにしてこれらの 2 つのリソースを同じバスに関連付ける必要があることを把握するのでしょうか。</span><span class="sxs-lookup"><span data-stu-id="bea62-132">How does software know that these two resources should be associated with the same bus?</span></span> <span data-ttu-id="bea62-133">バスのフレンドリ名とリソース インデックスの間のマッピングが DSD で指定されます。</span><span class="sxs-lookup"><span data-stu-id="bea62-133">The mapping between bus friendly name and resource index is specified in the DSD:</span></span>

```cpp
Package(2) { "bus-SPI-SPI0", Package() { 0, 1 }},
```

<span data-ttu-id="bea62-134">これにより、2 つのチップ選択線 (リソース インデックス 0 および 1) を持つ “SPI0” という名前のバスが作成されます。</span><span class="sxs-lookup"><span data-stu-id="bea62-134">This creates a bus named “SPI0” with two chip select lines – resource indexes 0 and 1.</span></span> <span data-ttu-id="bea62-135">SPI バスの機能を宣言するには、さらにいくつかのプロパティが必要です。</span><span class="sxs-lookup"><span data-stu-id="bea62-135">Several more properties are required to declare the capabilities of the SPI bus.</span></span>

```cpp
Package(2) { "SPI0-MinClockInHz", 7629 },
Package(2) { "SPI0-MaxClockInHz", 125000000 },
```

<span data-ttu-id="bea62-136">**MinClockInHz** および **MaxClockInHz** プロパティは、コントローラーでサポートされる最小および最大のクロック速度を指定します。</span><span class="sxs-lookup"><span data-stu-id="bea62-136">The **MinClockInHz** and **MaxClockInHz** properties specify the minimum and maximum clock speeds that are supported by the controller.</span></span> <span data-ttu-id="bea62-137">API はこの範囲外の値をユーザーが指定できないようにします。</span><span class="sxs-lookup"><span data-stu-id="bea62-137">The API will prevent users from specifying values outside this range.</span></span> <span data-ttu-id="bea62-138">クロック速度は接続記述子の _SPE フィールドの SPB ドライバーに渡されます (ACPI セクション 6.4.3.8.2.2)。</span><span class="sxs-lookup"><span data-stu-id="bea62-138">The clock speed is passed to your SPB driver in the _SPE field of the connection descriptor (ACPI section 6.4.3.8.2.2).</span></span>

```cpp
Package(2) { "SPI0-SupportedDataBitLengths", Package() { 8 }},
```

<span data-ttu-id="bea62-139">**SupportedDataBitLengths** プロパティには、コントローラーでサポートされるデータのビット長が一覧表示されます。</span><span class="sxs-lookup"><span data-stu-id="bea62-139">The **SupportedDataBitLengths** property lists the data bit lengths supported by the controller.</span></span> <span data-ttu-id="bea62-140">コンマ区切りの一覧で複数の値を指定することができます。</span><span class="sxs-lookup"><span data-stu-id="bea62-140">Multiple values can be specified in a comma-separated list.</span></span> <span data-ttu-id="bea62-141">API はこの一覧以外の値をユーザーが指定できないようにします。</span><span class="sxs-lookup"><span data-stu-id="bea62-141">The API will prevent users from specifying values outside this list.</span></span> <span data-ttu-id="bea62-142">データのビット長は接続記述子の _LEN フィールドの SPB ドライバーに渡されます (ACPI セクション 6.4.3.8.2.2)。</span><span class="sxs-lookup"><span data-stu-id="bea62-142">The data bit length is passed to your SPB driver in the _LEN field of the connection descriptor (ACPI section 6.4.3.8.2.2).</span></span>

<span data-ttu-id="bea62-143">これらのリソース宣言は “テンプレート” として考えることができます。</span><span class="sxs-lookup"><span data-stu-id="bea62-143">You can think of these resource declarations as “templates.”</span></span> <span data-ttu-id="bea62-144">システムの起動時に固定されるフィールドと、実行時に動的に指定されるフィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="bea62-144">Some of the fields are fixed at system boot while others are specified dynamically at runtime.</span></span> <span data-ttu-id="bea62-145">SPISerialBus 記述子の次のフィールドは固定されています。</span><span class="sxs-lookup"><span data-stu-id="bea62-145">The following fields of the SPISerialBus descriptor are fixed:</span></span>

* <span data-ttu-id="bea62-146">DeviceSelection</span><span class="sxs-lookup"><span data-stu-id="bea62-146">DeviceSelection</span></span>
* <span data-ttu-id="bea62-147">DeviceSelectionPolarity</span><span class="sxs-lookup"><span data-stu-id="bea62-147">DeviceSelectionPolarity</span></span>
* <span data-ttu-id="bea62-148">WireMode</span><span class="sxs-lookup"><span data-stu-id="bea62-148">WireMode</span></span>
* <span data-ttu-id="bea62-149">SlaveMode</span><span class="sxs-lookup"><span data-stu-id="bea62-149">SlaveMode</span></span>
* <span data-ttu-id="bea62-150">ResourceSource</span><span class="sxs-lookup"><span data-stu-id="bea62-150">ResourceSource</span></span>

<span data-ttu-id="bea62-151">次のフィールドは、実行時にユーザーによって指定される値のプレースホルダーです。</span><span class="sxs-lookup"><span data-stu-id="bea62-151">The following fields are placeholders for values specified by the user at runtime:</span></span>

* <span data-ttu-id="bea62-152">DataBitLength</span><span class="sxs-lookup"><span data-stu-id="bea62-152">DataBitLength</span></span>
* <span data-ttu-id="bea62-153">ConnectionSpeed</span><span class="sxs-lookup"><span data-stu-id="bea62-153">ConnectionSpeed</span></span>
* <span data-ttu-id="bea62-154">ClockPolarity</span><span class="sxs-lookup"><span data-stu-id="bea62-154">ClockPolarity</span></span>
* <span data-ttu-id="bea62-155">ClockPhase</span><span class="sxs-lookup"><span data-stu-id="bea62-155">ClockPhase</span></span>

<span data-ttu-id="bea62-156">SPI1 には単一のチップ選択行のみが含まれているため、単一の `SPISerialBus()` リソースが宣言されます。</span><span class="sxs-lookup"><span data-stu-id="bea62-156">Since SPI1 contains only a single chip select line, a single `SPISerialBus()` resource is declared:</span></span>

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

<span data-ttu-id="bea62-157">付随する必須のフレンドリ名宣言は DSD で指定され、このリソース宣言のインデックスを参照します。</span><span class="sxs-lookup"><span data-stu-id="bea62-157">The accompanying friendly name declaration – which is required – is specified in the DSD and refers to the index of this resource declaration.</span></span>

```cpp
Package(2) { "bus-SPI-SPI1", Package() { 2 }},
```

<span data-ttu-id="bea62-158">これにより “SPI1” という名前のバスが作成され、リソース インデックス 2 に関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="bea62-158">This creates a bus named “SPI1” and associates it with resource index 2.</span></span>

#### <a name="spi-driver-requirements"></a><span data-ttu-id="bea62-159">SPI ドライバーの要件</span><span class="sxs-lookup"><span data-stu-id="bea62-159">SPI Driver Requirements</span></span>

* <span data-ttu-id="bea62-160">`SpbCx` を使うか、SpbCx と互換性がある必要があります</span><span class="sxs-lookup"><span data-stu-id="bea62-160">Must use `SpbCx` or be SpbCx-compatible</span></span>
* <span data-ttu-id="bea62-161">[MITT SPI テスト](https://msdn.microsoft.com/library/windows/hardware/dn919873.aspx)に合格している必要があります</span><span class="sxs-lookup"><span data-stu-id="bea62-161">Must have passed the [MITT SPI Tests](https://msdn.microsoft.com/library/windows/hardware/dn919873.aspx)</span></span>
* <span data-ttu-id="bea62-162">4 Mhz のクロック周波数をサポートしている必要があります</span><span class="sxs-lookup"><span data-stu-id="bea62-162">Must support 4Mhz clock speed</span></span>
* <span data-ttu-id="bea62-163">8 ビットのデータ長をサポートしている必要があります</span><span class="sxs-lookup"><span data-stu-id="bea62-163">Must support 8-bit data length</span></span>
* <span data-ttu-id="bea62-164">すべての SPI モード (0、1、2、3) をサポートしている必要があります</span><span class="sxs-lookup"><span data-stu-id="bea62-164">Must support all SPI Modes: 0, 1, 2, 3</span></span>

### <a name="i2c"></a><span data-ttu-id="bea62-165">I2C</span><span class="sxs-lookup"><span data-stu-id="bea62-165">I2C</span></span>

<span data-ttu-id="bea62-166">次に、I2C リソースを宣言します。</span><span class="sxs-lookup"><span data-stu-id="bea62-166">Next, we declare the I2C resources.</span></span> <span data-ttu-id="bea62-167">Raspberry Pi はピン 3 および 5 で単一の I2C バスを公開しています。</span><span class="sxs-lookup"><span data-stu-id="bea62-167">Raspberry Pi exposes a single I2C bus on pins 3 and 5.</span></span>

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

<span data-ttu-id="bea62-168">付随する必須のフレンドリ名宣言は DSD で指定されます。</span><span class="sxs-lookup"><span data-stu-id="bea62-168">The accompanying friendly name declaration – which is required – is specified in the DSD:</span></span>

```cpp
Package(2) { "bus-I2C-I2C1", Package() { 3 }},
```

<span data-ttu-id="bea62-169">これは、上記の説明で宣言した I2CSerialBus() リソースのインデックスであるリソース インデックス 3 を参照する、フレンドリ名 “I2C1” の I2C バスを宣言します。</span><span class="sxs-lookup"><span data-stu-id="bea62-169">This declares an I2C bus with friendly name “I2C1” that refers to resource index 3, which is the index of the I2CSerialBus() resource that we declared above.</span></span>

<span data-ttu-id="bea62-170">I2CSerialBus() 記述子の次のフィールドは固定されています。</span><span class="sxs-lookup"><span data-stu-id="bea62-170">The following fields of the I2CSerialBus() descriptor are fixed:</span></span>

* <span data-ttu-id="bea62-171">SlaveMode</span><span class="sxs-lookup"><span data-stu-id="bea62-171">SlaveMode</span></span>
* <span data-ttu-id="bea62-172">ResourceSource</span><span class="sxs-lookup"><span data-stu-id="bea62-172">ResourceSource</span></span>

<span data-ttu-id="bea62-173">次のフィールドは、実行時にユーザーによって指定される値のプレースホルダーです。</span><span class="sxs-lookup"><span data-stu-id="bea62-173">The following fields are placeholders for values specified by the user at runtime.</span></span>

* <span data-ttu-id="bea62-174">SlaveAddress</span><span class="sxs-lookup"><span data-stu-id="bea62-174">SlaveAddress</span></span>
* <span data-ttu-id="bea62-175">ConnectionSpeed</span><span class="sxs-lookup"><span data-stu-id="bea62-175">ConnectionSpeed</span></span>
* <span data-ttu-id="bea62-176">AddressingMode</span><span class="sxs-lookup"><span data-stu-id="bea62-176">AddressingMode</span></span>

#### <a name="i2c-driver-requirements"></a><span data-ttu-id="bea62-177">I2C ドライバーの要件</span><span class="sxs-lookup"><span data-stu-id="bea62-177">I2C Driver Requirements</span></span>

* <span data-ttu-id="bea62-178">SpbCx を使うか、SpbCx と互換性がある必要があります</span><span class="sxs-lookup"><span data-stu-id="bea62-178">Must use SpbCx or be SpbCx-compatible</span></span>
* <span data-ttu-id="bea62-179">[MITT I2C テスト](https://msdn.microsoft.com/library/windows/hardware/dn919852.aspx)に合格している必要があります</span><span class="sxs-lookup"><span data-stu-id="bea62-179">Must have passed the [MITT I2C Tests](https://msdn.microsoft.com/library/windows/hardware/dn919852.aspx)</span></span>
* <span data-ttu-id="bea62-180">7 ビットのアドレス指定をサポートしている必要があります</span><span class="sxs-lookup"><span data-stu-id="bea62-180">Must support 7-bit addressing</span></span>
* <span data-ttu-id="bea62-181">100 kHz のクロック周波数をサポートしている必要があります</span><span class="sxs-lookup"><span data-stu-id="bea62-181">Must support 100kHz clock speed</span></span>
* <span data-ttu-id="bea62-182">400 kHz のクロック周波数をサポートしている必要があります</span><span class="sxs-lookup"><span data-stu-id="bea62-182">Must support 400kHz clock speed</span></span>

### <a name="gpio"></a><span data-ttu-id="bea62-183">GPIO</span><span class="sxs-lookup"><span data-stu-id="bea62-183">GPIO</span></span>

<span data-ttu-id="bea62-184">次に、ユーザー モードに公開されるすべての GPIO ピンを宣言します。</span><span class="sxs-lookup"><span data-stu-id="bea62-184">Next, we declare all the GPIO pins that are exposed to usermode.</span></span> <span data-ttu-id="bea62-185">どのピンを公開するかを判断するために、次のガイダンスを提供しています。</span><span class="sxs-lookup"><span data-stu-id="bea62-185">We offer the following guidance in deciding which pins to expose:</span></span>

* <span data-ttu-id="bea62-186">公開されるヘッダーのすべてのピンを宣言します。</span><span class="sxs-lookup"><span data-stu-id="bea62-186">Declare all pins on exposed headers.</span></span>
* <span data-ttu-id="bea62-187">ボタンや LED などの役立つオンボード機能に接続されているピンを宣言します。</span><span class="sxs-lookup"><span data-stu-id="bea62-187">Declare pins that are connected to useful onboard functions like buttons and LEDs.</span></span>
* <span data-ttu-id="bea62-188">システム機能のために予約されているピン、または何にも接続されていないピンは宣言しません。</span><span class="sxs-lookup"><span data-stu-id="bea62-188">Do not declare pins that are reserved for system functions or are not connected to anything.</span></span>

<span data-ttu-id="bea62-189">ASL の次のブロックでは、GPIO4 と GPIO5 の 2 つのピンが宣言されます。</span><span class="sxs-lookup"><span data-stu-id="bea62-189">The following block of ASL declares two pins – GPIO4 and GPIO5.</span></span> <span data-ttu-id="bea62-190">簡潔にするために、その他のピンはここでは示しません。</span><span class="sxs-lookup"><span data-stu-id="bea62-190">The other pins are not shown here for brevity.</span></span> <span data-ttu-id="bea62-191">付録 C には、GPIO リソースを生成するために使うことができるサンプル powershell スクリプトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="bea62-191">Appendix C contains a sample powershell script which can be used to generate the GPIO resources.</span></span>

```cpp
// Index 4 – GPIO 4
GpioIO(Shared, PullUp, , , , “\\_SB.GPI0”, , , , ) { 4 }
GpioInt(Edge, ActiveBoth, Shared, PullUp, 0, “\\_SB.GPI0”,) { 4 }

// Index 6 – GPIO 5
GpioIO(Shared, PullUp, , , , “\\_SB.GPI0”, , , , ) { 5 }
GpioInt(Edge, ActiveBoth, Shared, PullUp, 0, “\\_SB.GPI0”,) { 5 }
```

<span data-ttu-id="bea62-192">GPIO ピンを宣言するときは、次の要件を順守する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-192">The following requirements must be observed when declaring GPIO pins:</span></span>

* <span data-ttu-id="bea62-193">メモリ マップ GPIO コントローラーのみがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="bea62-193">Only memory mapped GPIO controllers are supported.</span></span> <span data-ttu-id="bea62-194">I2C/SPI 経由で接続された GPIO コントローラーはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="bea62-194">GPIO controllers interfaced over I2C/SPI are not supported.</span></span> <span data-ttu-id="bea62-195">[CLIENT_QueryControllerBasicInformation](https://msdn.microsoft.com/library/windows/hardware/hh439399.aspx) コールバックへの応答で [CLIENT_CONTROLLER_BASIC_INFORMATION](https://msdn.microsoft.com/library/windows/hardware/hh439358.aspx) 構造に [MemoryMappedController](https://msdn.microsoft.com/library/windows/hardware/hh439449.aspx) フラグを設定する場合、コントローラー ドライバーはメモリ マップ コントローラーです。</span><span class="sxs-lookup"><span data-stu-id="bea62-195">The controller driver is a memory mapped controller if it sets the [MemoryMappedController](https://msdn.microsoft.com/library/windows/hardware/hh439449.aspx) flag in the [CLIENT_CONTROLLER_BASIC_INFORMATION](https://msdn.microsoft.com/library/windows/hardware/hh439358.aspx) structure in response to the [CLIENT_QueryControllerBasicInformation](https://msdn.microsoft.com/library/windows/hardware/hh439399.aspx) callback.</span></span>
* <span data-ttu-id="bea62-196">各ピンに GpioIO リソースと GpioInt リソースの両方が必要です。</span><span class="sxs-lookup"><span data-stu-id="bea62-196">Each pin requires both a GpioIO and a GpioInt resource.</span></span> <span data-ttu-id="bea62-197">GpioInt リソースは GpioIO リソースの直後に続き、同じピン番号を参照する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-197">The GpioInt resource must immediately follow the GpioIO resource and must refer to the same pin number.</span></span>
* <span data-ttu-id="bea62-198">GPIO リソースはピン番号の昇順で並べる必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-198">GPIO resources must be ordered by increasing pin number.</span></span>
* <span data-ttu-id="bea62-199">各 GpioIO リソースと GpioInt リソースには、ピン一覧に正確に 1 つのピン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-199">Each GpioIO and GpioInt resource must contain exactly one pin number in the pin list.</span></span>
* <span data-ttu-id="bea62-200">両方の記述子の ShareType フィールドが Shared である必要があります</span><span class="sxs-lookup"><span data-stu-id="bea62-200">The ShareType field of both descriptors must be Shared</span></span>
* <span data-ttu-id="bea62-201">GpioInt 記述子の EdgeLevel フィールドが Edge である必要があります</span><span class="sxs-lookup"><span data-stu-id="bea62-201">The EdgeLevel field of the GpioInt descriptor must be Edge</span></span>
* <span data-ttu-id="bea62-202">GpioInt 記述子の ActiveLevel フィールドが ActiveBoth である必要があります</span><span class="sxs-lookup"><span data-stu-id="bea62-202">The ActiveLevel field of the GpioInt descriptor must be ActiveBoth</span></span>
* <span data-ttu-id="bea62-203">PinConfig フィールド</span><span class="sxs-lookup"><span data-stu-id="bea62-203">The PinConfig field</span></span>
  * <span data-ttu-id="bea62-204">GpioIO 記述子と GpioInt 記述子の両方で同じである必要があります</span><span class="sxs-lookup"><span data-stu-id="bea62-204">Must be the same in both the GpioIO and GpioInt descriptors</span></span>
  * <span data-ttu-id="bea62-205">PullUp、PullDown、PullNone のいずれかである必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-205">Must be one of PullUp, PullDown, or PullNone.</span></span> <span data-ttu-id="bea62-206">PullDefault は指定できません。</span><span class="sxs-lookup"><span data-stu-id="bea62-206">It cannot be PullDefault.</span></span>
  * <span data-ttu-id="bea62-207">プル構成がピンの電源投入時の状態と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-207">The pull configuration must match the power-on state of the pin.</span></span> <span data-ttu-id="bea62-208">ピンを電源投入時の状態から指定されたプル モードにしてもピンの状態が変更されないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-208">Putting the pin in the specified pull mode from power-on state must not change the state of the pin.</span></span> <span data-ttu-id="bea62-209">たとえば、ピンでプル アップを使うようにデータシートで指定されている場合には、PinConfig を PullUp に指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-209">For example, if the datasheet specifies that the pin comes up with a pull up, specify PinConfig as PullUp.</span></span>

<span data-ttu-id="bea62-210">ファームウェア、UEFI、ドライバーの初期化コードが起動中の電源投入時の状態からピンの状態を変更しないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-210">Firmware, UEFI, and driver initialization code should not change the state of a pin from its power-on state during boot.</span></span> <span data-ttu-id="bea62-211">ユーザーのみがピンに何が接続されているかを把握しているため、どの状態遷移が安全かが分かります。</span><span class="sxs-lookup"><span data-stu-id="bea62-211">Only the user knows what’s attached to a pin and therefore which state transitions are safe.</span></span> <span data-ttu-id="bea62-212">ピンと正しく接続されるハードウェアをユーザーが設計できるように、各ピンの電源投入時の状態を文書化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-212">The power-on state of each pin must be documented so that users can design hardware that correctly interfaces with a pin.</span></span> <span data-ttu-id="bea62-213">起動中にピンの状態が予期せず変更されないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-213">A pin must not change state unexpectedly during boot.</span></span>

#### <a name="supported-drive-modes"></a><span data-ttu-id="bea62-214">サポートされるドライバー モデル</span><span class="sxs-lookup"><span data-stu-id="bea62-214">Supported Drive Modes</span></span>

<span data-ttu-id="bea62-215">GPIO コントローラーで高インピーダンス入力と CMOS 出力に加えて組み込みのプル アップおよびプル ダウン抵抗がサポートされている場合は、オプションの SupportedDriveModes プロパティを使って指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-215">If your GPIO controller supports built-in pull up and pull down resistors in addition to high impedance input and CMOS output, you must specify this with the optional SupportedDriveModes property.</span></span>

```cpp
Package (2) { “GPIO-SupportedDriveModes”, 0xf },
```

<span data-ttu-id="bea62-216">SupportedDriveModes プロパティは、GPIO コントローラーによってどのドライブ モードがサポートされるかを示します。</span><span class="sxs-lookup"><span data-stu-id="bea62-216">The SupportedDriveModes property indicates which drive modes are supported by the GPIO controller.</span></span> <span data-ttu-id="bea62-217">上記の例では、次のドライブ モードがすべてサポートされます。</span><span class="sxs-lookup"><span data-stu-id="bea62-217">In the example above, all of the following drive modes are supported.</span></span> <span data-ttu-id="bea62-218">このプロパティは、次の値のビットマスクです。</span><span class="sxs-lookup"><span data-stu-id="bea62-218">The property is a bitmask of the following values:</span></span>

| <span data-ttu-id="bea62-219">フラグ値</span><span class="sxs-lookup"><span data-stu-id="bea62-219">Flag Value</span></span> | <span data-ttu-id="bea62-220">ドライブ モード</span><span class="sxs-lookup"><span data-stu-id="bea62-220">Drive Mode</span></span> | <span data-ttu-id="bea62-221">説明</span><span class="sxs-lookup"><span data-stu-id="bea62-221">Description</span></span> |
|------------|------------|-------------|
| <span data-ttu-id="bea62-222">0x1</span><span class="sxs-lookup"><span data-stu-id="bea62-222">0x1</span></span>        | <span data-ttu-id="bea62-223">InputHighImpedance</span><span class="sxs-lookup"><span data-stu-id="bea62-223">InputHighImpedance</span></span> | <span data-ttu-id="bea62-224">ピンが高インピーダンス入力をサポートします。ACPI の “PullNone” 値に対応します。</span><span class="sxs-lookup"><span data-stu-id="bea62-224">The pin supports high impedance input, which corresponds to the “PullNone” value in ACPI.</span></span> |
| <span data-ttu-id="bea62-225">0x2</span><span class="sxs-lookup"><span data-stu-id="bea62-225">0x2</span></span>        | <span data-ttu-id="bea62-226">InputPullUp</span><span class="sxs-lookup"><span data-stu-id="bea62-226">InputPullUp</span></span> | <span data-ttu-id="bea62-227">ピンが組み込みのプル アップ抵抗をサポートします。ACPI の “PullUp” 値に対応します。</span><span class="sxs-lookup"><span data-stu-id="bea62-227">The pin supports a built-in pull-up resistor, which corresponds to the “PullUp” value in ACPI.</span></span> |
| <span data-ttu-id="bea62-228">0x4</span><span class="sxs-lookup"><span data-stu-id="bea62-228">0x4</span></span>        | <span data-ttu-id="bea62-229">InputPullDown</span><span class="sxs-lookup"><span data-stu-id="bea62-229">InputPullDown</span></span> | <span data-ttu-id="bea62-230">ピンが組み込みのプル ダウン抵抗をサポートします。ACPI の “PullDown” 値に対応します。</span><span class="sxs-lookup"><span data-stu-id="bea62-230">The pin supports a built-in pull-down resistor, which corresponds to the “PullDown” value in ACPI.</span></span> |
| <span data-ttu-id="bea62-231">0x8</span><span class="sxs-lookup"><span data-stu-id="bea62-231">0x8</span></span>        | <span data-ttu-id="bea62-232">OutputCmos</span><span class="sxs-lookup"><span data-stu-id="bea62-232">OutputCmos</span></span> | <span data-ttu-id="bea62-233">ピンが (オープン ドレインとは対照的に) ストロング ハイとストロング ローの両方の生成をサポートします。</span><span class="sxs-lookup"><span data-stu-id="bea62-233">The pin supports generating both strong highs and strong lows (as opposed to open drain).</span></span> |

<span data-ttu-id="bea62-234">InputHighImpedance と OutputCmos はほぼすべての GPIO コントローラーでサポートされています。</span><span class="sxs-lookup"><span data-stu-id="bea62-234">InputHighImpedance and OutputCmos are supported by almost all GPIO controllers.</span></span> <span data-ttu-id="bea62-235">SupportedDriveModes プロパティが指定されていない場合は、既定になります。</span><span class="sxs-lookup"><span data-stu-id="bea62-235">If the SupportedDriveModes property is not specified, this is the default.</span></span>

<span data-ttu-id="bea62-236">GPIO 信号が公開されているヘッダーに到達する前にレベル シフターを通過する場合は、ドライブ モードが外部ヘッダーで監視可能でない場合でも、SOC によってサポートされているドライブ モードを宣言します。</span><span class="sxs-lookup"><span data-stu-id="bea62-236">If a GPIO signal goes through a level shifter before reaching an exposed header, declare the drive modes supported by the SOC, even if the drive mode would not be observable on the external header.</span></span> <span data-ttu-id="bea62-237">たとえば、ピンを抵抗プル アップを備えたオープン ドレインとして表す双方向レベル シフターをピンが通過する場合は、ピンが高インピーダンス入力として構成されている場合でも、公開されたヘッダーで高インピーダンス状態は観測されません。</span><span class="sxs-lookup"><span data-stu-id="bea62-237">For example, if a pin goes through a bidirectional level shifter that makes a pin appear as open drain with resistive pull up, you will never observe a high impedance state on the exposed header even if the pin is configured as a high impedance input.</span></span> <span data-ttu-id="bea62-238">この場合も、ピンが高インピーダンス入力をサポートすることを宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-238">You should still declare that the pin supports high impedance input.</span></span>

#### <a name="pin-numbering"></a><span data-ttu-id="bea62-239">ピンの番号付け</span><span class="sxs-lookup"><span data-stu-id="bea62-239">Pin Numbering</span></span>

<span data-ttu-id="bea62-240">Windows は、2 つのピンの番号付けスキームをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="bea62-240">Windows supports two pin numbering schemes:</span></span>

* <span data-ttu-id="bea62-241">連番のピンの番号付け: 0、1、2 ... のように、公開されているピンの数までの番号がユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="bea62-241">Sequential Pin Numbering – Users see numbers like 0, 1, 2... up to the number of exposed pins.</span></span> <span data-ttu-id="bea62-242">0 は ASL で宣言されている最初の GpioIo リソース、1 は ASL で宣言されている 2 番目の GpioIo リソースなどのようになります。</span><span class="sxs-lookup"><span data-stu-id="bea62-242">0 is the first GpioIo resource declared in ASL, 1 is the second GpioIo resource declared in ASL, and so on.</span></span>
* <span data-ttu-id="bea62-243">ネイティブのピンの番号付け: 4、5、12、13 ... などの、GpioIo 記述子で指定されたピン番号がユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="bea62-243">Native Pin Numbering – Users see the pin numbers specified in GpioIo descriptors, e.g. 4, 5, 12, 13, ... .</span></span>

```cpp
Package (2) { “GPIO-UseDescriptorPinNumbers”, 1 },
```

<span data-ttu-id="bea62-244">**UseDescriptorPinNumbers** プロパティは、Windows が連番のピンの番号付けではなくネイティブのピンの番号付けを使うようにします。</span><span class="sxs-lookup"><span data-stu-id="bea62-244">The **UseDescriptorPinNumbers** property tells Windows to use native pin numbering instead of sequential pin numbering.</span></span> <span data-ttu-id="bea62-245">UseDescriptorPinNumbers プロパティが指定されていない場合、または値が 0 の場合は、Windows は既定の連番のピンの番号付けを使います。</span><span class="sxs-lookup"><span data-stu-id="bea62-245">If the UseDescriptorPinNumbers property is not specified or its value is zero, Windows will default to Sequential pin numbering.</span></span>

<span data-ttu-id="bea62-246">ネイティブのピンの番号付けを使う場合は、**PinCount** プロパティも指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-246">If native pin numbering is used, you must also specify the **PinCount** property.</span></span>

```cpp
Package (2) { “GPIO-PinCount”, 54 },
```

<span data-ttu-id="bea62-247">**PinCount** プロパティは、`GpioClx` ドライバーの [CLIENT_QueryControllerBasicInformation](https://msdn.microsoft.com/library/windows/hardware/hh439399.aspx) コールバックの **TotalPins** プロパティから返された値と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-247">The **PinCount** property should match the value returned through the **TotalPins** property in the [CLIENT_QueryControllerBasicInformation](https://msdn.microsoft.com/library/windows/hardware/hh439399.aspx) callback of the `GpioClx` driver.</span></span>

<span data-ttu-id="bea62-248">ボードの既存の公開されたドキュメントと最も互換性のある番号付けスキームを選択します。</span><span class="sxs-lookup"><span data-stu-id="bea62-248">Choose the numbering scheme that is most compatible with existing published documentation for your board.</span></span> <span data-ttu-id="bea62-249">たとえば、多くの既存のピン配列図が BCM2835 ピン番号を使っているため、Raspberry Pi はネイティブのピンの番号付けを使います。</span><span class="sxs-lookup"><span data-stu-id="bea62-249">For example, Raspberry Pi uses native pin numbering because many existing pinout diagrams use the BCM2835 pin numbers.</span></span> <span data-ttu-id="bea62-250">200 個を超えるピンから 10 個のピンのみが公開されるため、既存のピン配列図が少なく、連番のピンの番号付けでは開発者のエクスペリエンスが単純化されるので、MinnowBoardMax は連番のピンの番号付けを使います。</span><span class="sxs-lookup"><span data-stu-id="bea62-250">MinnowBoardMax uses sequential pin numbering because there are few existing pinout diagrams, and sequential pin numbering simplifies the developer experience because only 10 pins are exposed out of more than 200 pins.</span></span> <span data-ttu-id="bea62-251">連番のピンの番号付けを使うかネイティブのピンの番号付けを使うかの決定は、開発者の混乱を少なくすることを目的として行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-251">The decision to use sequential or native pin numbering should aim to reduce developer confusion.</span></span>

#### <a name="gpio-driver-requirements"></a><span data-ttu-id="bea62-252">GPIO ドライバーの要件</span><span class="sxs-lookup"><span data-stu-id="bea62-252">GPIO Driver Requirements</span></span>

* <span data-ttu-id="bea62-253">を使う必要があります</span><span class="sxs-lookup"><span data-stu-id="bea62-253">Must use</span></span> `GpioClx`
* <span data-ttu-id="bea62-254">SOC 上でメモリ マッピングする必要があります</span><span class="sxs-lookup"><span data-stu-id="bea62-254">Must be on-SOC memory mapped</span></span>
* <span data-ttu-id="bea62-255">エミュレートされた ActiveBoth 割り込み処理を使う必要があります</span><span class="sxs-lookup"><span data-stu-id="bea62-255">Must use emulated ActiveBoth interrupt handling</span></span>

### <a name="uart"></a><span data-ttu-id="bea62-256">UART</span><span class="sxs-lookup"><span data-stu-id="bea62-256">UART</span></span>

<span data-ttu-id="bea62-257">UART ドライバーが `SerCx` または `SerCx2` を使用する場合、rhproxy を使用してこのドライバーをユーザー モードに公開することができます。</span><span class="sxs-lookup"><span data-stu-id="bea62-257">If your UART driver uses `SerCx` or `SerCx2`, you can use rhproxy to expose the driver to usermode.</span></span> <span data-ttu-id="bea62-258">`GUID_DEVINTERFACE_COMPORT` 型のデバイス インターフェイスを作成する UART ドライバーでは、rhproxy を使用する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="bea62-258">UART drivers that create a device interface of type `GUID_DEVINTERFACE_COMPORT` do not need to use rhproxy.</span></span> <span data-ttu-id="bea62-259">インボックス `Serial.sys` ドライバーも、このようなドライバーの 1 つです。</span><span class="sxs-lookup"><span data-stu-id="bea62-259">The inbox `Serial.sys` driver is one of these cases.</span></span>

<span data-ttu-id="bea62-260">`SerCx` スタイルの UART をユーザー モードに公開するには、次のように `UARTSerialBus` リソースを宣言します。</span><span class="sxs-lookup"><span data-stu-id="bea62-260">To expose a `SerCx`-style UART to usermode, declare a `UARTSerialBus` resource as follows.</span></span>

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

<span data-ttu-id="bea62-261">ResourceSource フィールドのみが固定され、その他のすべてのフィールドは実行時にユーザーによって指定される値のプレースホルダーとなります。</span><span class="sxs-lookup"><span data-stu-id="bea62-261">Only the ResourceSource field is fixed while all other fields are placeholders for values specified at runtime by the user.</span></span>

<span data-ttu-id="bea62-262">付随するフレンドリ名の宣言は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="bea62-262">The accompanying friendly name declaration is:</span></span>

```cpp
Package(2) { "bus-UART-UART2", Package() { 2 }},
```

<span data-ttu-id="bea62-263">ユーザーがユーザー モードからバスにアクセスするために使う識別子である、フレンドリ名 “UART2” がコントローラーに割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="bea62-263">This assigns the friendly name “UART2” to the controller, which is the identifier users will use to access the bus from usermode.</span></span>

## <a name="runtime-pin-muxing"></a><span data-ttu-id="bea62-264">実行時のピンの多重化</span><span class="sxs-lookup"><span data-stu-id="bea62-264">Runtime Pin Muxing</span></span>

<span data-ttu-id="bea62-265">ピンの多重化は、同じ物理ピンをさまざまな機能のために使う機能です。</span><span class="sxs-lookup"><span data-stu-id="bea62-265">Pin muxing is the ability to use the same physical pin for different functions.</span></span> <span data-ttu-id="bea62-266">I2C コントローラー、SPI コントローラー、GPIO コントローラーなどのいくつかのオンチップ周辺機器が、SOC の同じ物理ピンにルーティングされる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-266">Several different on-chip peripherals, such as an I2C controller, SPI controller, and GPIO controller, might be routed to the same physical pin on a SOC.</span></span> <span data-ttu-id="bea62-267">多重化ブロックは、任意の時間にどの機能がピンでアクティブになるかを制御します。</span><span class="sxs-lookup"><span data-stu-id="bea62-267">The mux block controls which function is active on the pin at any given time.</span></span> <span data-ttu-id="bea62-268">従来は、ファームウェアが機能の割り当てを起動時に確立し、この割り当ては起動セッションを通じて静的なままでした。</span><span class="sxs-lookup"><span data-stu-id="bea62-268">Traditionally, firmware is responsible for establishing function assignments at boot, and this assignment remains static through the boot session.</span></span> <span data-ttu-id="bea62-269">実行時のピンの多重化は、実行時にピンの機能の割り当てを再構成する機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="bea62-269">Runtime pin muxing adds the ability to reconfigure pin function assignments at runtime.</span></span> <span data-ttu-id="bea62-270">実行時にユーザーがピンの機能を選択できるようにすると、ユーザーがボードのピンをすばやく再構成できるようになることで開発が高速化され、静的な構成の場合よりもハードウェアが広い範囲のアプリケーションをサポートできるようになります。</span><span class="sxs-lookup"><span data-stu-id="bea62-270">Enabling users to choose a pin’s function at runtime speeds development by enabling users to quickly reconfigure a board’s pins, and enables hardware to support a broader range of applications than would a static configuration.</span></span>

<span data-ttu-id="bea62-271">追加のコードを記述しなくても、ユーザーは GPIO、I2C、SPI、UART の多重化のサポートを利用できます。</span><span class="sxs-lookup"><span data-stu-id="bea62-271">Users consume muxing support for GPIO, I2C, SPI, and UART without writing any additional code.</span></span> <span data-ttu-id="bea62-272">ユーザーが [OpenPin()](https://msdn.microsoft.com/library/dn960157.aspx) または [FromIdAsync()](https://msdn.microsoft.com/windows.devices.i2c.i2cdevice.fromidasync) を使って GPIO を開くと、基になる物理ピンが要求された機能に対して自動的に多重化されます。</span><span class="sxs-lookup"><span data-stu-id="bea62-272">When a user opens a GPIO or bus using [OpenPin()](https://msdn.microsoft.com/library/dn960157.aspx) or [FromIdAsync()](https://msdn.microsoft.com/windows.devices.i2c.i2cdevice.fromidasync), the underlying physical pins are automatically muxed to the requested function.</span></span> <span data-ttu-id="bea62-273">ピンが既に別の機能により使われている場合は、OpenPin() または FromIdAsync() の呼び出しは失敗します。</span><span class="sxs-lookup"><span data-stu-id="bea62-273">If the pins are already in use by a different function, the OpenPin() or FromIdAsync() call will fail.</span></span> <span data-ttu-id="bea62-274">[GpioPin](https://msdn.microsoft.com/library/windows/apps/windows.devices.gpio.gpiopin.aspx)、[I2cDevice](https://msdn.microsoft.com/library/windows/apps/windows.devices.i2c.i2cdevice.aspx)、[SpiDevice](https://msdn.microsoft.com/library/windows/apps/windows.devices.spi.spidevice.aspx)、[SerialDevice](https://msdn.microsoft.com/library/windows/apps/windows.devices.serialcommunication.serialdevice.aspx) オブジェクトを廃棄することでユーザーがデバイスを閉じると、ピンが解放され、後で別の機能のために開くことができるようになります。</span><span class="sxs-lookup"><span data-stu-id="bea62-274">When the user closes the device by disposing the [GpioPin](https://msdn.microsoft.com/library/windows/apps/windows.devices.gpio.gpiopin.aspx), [I2cDevice](https://msdn.microsoft.com/library/windows/apps/windows.devices.i2c.i2cdevice.aspx), [SpiDevice](https://msdn.microsoft.com/library/windows/apps/windows.devices.spi.spidevice.aspx), or [SerialDevice](https://msdn.microsoft.com/library/windows/apps/windows.devices.serialcommunication.serialdevice.aspx) object, the pins are released, allowing them to later be opened for a different function.</span></span>

<span data-ttu-id="bea62-275">Windows では、[GpioClx](https://msdn.microsoft.com/library/windows/hardware/hh439515.aspx)、[SpbCx](https://msdn.microsoft.com/library/windows/hardware/hh406203.aspx)、[SerCx](https://msdn.microsoft.com/library/windows/hardware/dn265349.aspx) フレームワークにピンの多重化の組み込みサポートが含まれています。</span><span class="sxs-lookup"><span data-stu-id="bea62-275">Windows contains built-in support for pin muxing in the [GpioClx](https://msdn.microsoft.com/library/windows/hardware/hh439515.aspx), [SpbCx](https://msdn.microsoft.com/library/windows/hardware/hh406203.aspx), and [SerCx](https://msdn.microsoft.com/library/windows/hardware/dn265349.aspx) frameworks.</span></span> <span data-ttu-id="bea62-276">これらのフレームワークは、GPIO ピンまたはバスがアクセスされたときに正しい機能にピンを自動的に切り替えるために、連携して機能します。</span><span class="sxs-lookup"><span data-stu-id="bea62-276">These frameworks work together to automatically switch a pin to the correct function when a GPIO pin or bus is accessed.</span></span> <span data-ttu-id="bea62-277">複数のクライアント間での競合を避けるために、ピンへのアクセスは適切に判別されます。</span><span class="sxs-lookup"><span data-stu-id="bea62-277">Access to the pins is arbitrated to prevent conflicts among multiple clients.</span></span> <span data-ttu-id="bea62-278">この組み込みサポートに加えて、ピンの多重化のためのインターフェイスとプロトコルは汎用のため、追加のデバイスとシナリオをサポートするために拡張できます。</span><span class="sxs-lookup"><span data-stu-id="bea62-278">In addition to this built-in support, the interfaces and protocols for pin muxing are general purpose and can be extended to support additional devices and scenarios.</span></span>

<span data-ttu-id="bea62-279">このドキュメントでは、まずピンの多重化に関与する基となるインターフェイスとプロトコルについて説明してから、GpioClx、SpbCx、SerCx コントローラー ドライバーに対してピンの多重化のサポートを追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="bea62-279">This document first describes the underlying interfaces and protocols involved in pin muxing, and then describes how to add support for pin muxing to GpioClx, SpbCx, and SerCx controller drivers.</span></span>

### <a name="pin-muxing-architecture"></a><span data-ttu-id="bea62-280">ピンの多重化のアーキテクチャ</span><span class="sxs-lookup"><span data-stu-id="bea62-280">Pin Muxing Architecture</span></span>

<span data-ttu-id="bea62-281">このセクションでは、ピンの多重化に関与する基となるインターフェイスとプロトコルについて説明します。</span><span class="sxs-lookup"><span data-stu-id="bea62-281">This section describes the underlying interfaces and protocols involved in pin muxing.</span></span> <span data-ttu-id="bea62-282">基となるプロトコルの知識は、GpioClx/SpbCx/SerCx ドライバーによるピンの多重化のサポートに必ずしも必要ではありません。</span><span class="sxs-lookup"><span data-stu-id="bea62-282">Knowledge of the underlying protocols is not necessarily needed to support pin muxing with GpioClx/SpbCx/SerCx drivers.</span></span> <span data-ttu-id="bea62-283">GpioCls/SpbCx/SerCx ドライバーによるピンの多重化のサポート方法について詳しくは、「[GpioClx クライアント ドライバーでのピンの多重化のサポートの実装](#supporting-muxing-support-in-gpioclx-client-drivers)」と「[SpbCx および SerCx コントローラー ドライバーでの多重化のサポートの使用](#supporting-muxing-in-spbcx-and-sercx-controller-drivers)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bea62-283">For details on how to support pin muxing with GpioCls/SpbCx/SerCx drivers, see [Implementing pin muxing support in GpioClx client drivers](#supporting-muxing-support-in-gpioclx-client-drivers) and [Consuming muxing support in SpbCx and SerCx controller drivers](#supporting-muxing-in-spbcx-and-sercx-controller-drivers).</span></span>

<span data-ttu-id="bea62-284">ピンの多重化は、複数のコンポーネントが連携することで行われます。</span><span class="sxs-lookup"><span data-stu-id="bea62-284">Pin muxing is accomplished by the cooperation of several components.</span></span>

* <span data-ttu-id="bea62-285">ピンの多重化のサーバーは、ピンの多重化の制御ブロックを制御するドライバーです。</span><span class="sxs-lookup"><span data-stu-id="bea62-285">Pin muxing servers – these are drivers that control the pin muxing control block.</span></span> <span data-ttu-id="bea62-286">ピンの多重化のサーバーは、多重化のリソースを予約するための要求 (*IRP_MJ_CREATE* 要求を使用) と、ピンの機能を切り替えるための要求 (*IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* 要求を使用) を介して、クライアントからピンの多重化の要求を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="bea62-286">Pin muxing servers receive pin muxing requests from clients via requests to reserve muxing resources (via *IRP_MJ_CREATE*) requests, and requests to switch a pin’s function (via *IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* requests).</span></span> <span data-ttu-id="bea62-287">多重化ブロックが GPIO ブロックの一部である場合があるため、通常はピンの多重化のサーバーは GPIO ドライバーです。</span><span class="sxs-lookup"><span data-stu-id="bea62-287">The pin muxing server is usually the GPIO driver, since the muxing block is sometimes part of the GPIO block.</span></span> <span data-ttu-id="bea62-288">多重化ブロックが別個の周辺機器の場合でも、GPIO ドライバーは多重化機能を配置するための理にかなった場所となります。</span><span class="sxs-lookup"><span data-stu-id="bea62-288">Even if the muxing block is a separate peripheral, the GPIO driver is a logical place to put muxing functionality.</span></span>
* <span data-ttu-id="bea62-289">ピンの多重化のクライアントは、ピンの多重化を使うドライバーです。</span><span class="sxs-lookup"><span data-stu-id="bea62-289">Pin muxing clients – these are drivers that consume pin muxing.</span></span> <span data-ttu-id="bea62-290">ピンの多重化のクライアントは ACPI ファームウェアからピンの多重化のリソースを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="bea62-290">Pin muxing clients receive pin muxing resources from ACPI firmware.</span></span> <span data-ttu-id="bea62-291">ピンの多重化のリソースは接続リソースの一種で、リソース ハブによって管理されます。</span><span class="sxs-lookup"><span data-stu-id="bea62-291">Pin muxing resources are a type of connection resource and are managed by the resource hub.</span></span> <span data-ttu-id="bea62-292">ピンの多重化のクライアントは、ハンドルをリソースに対して開くことでピンの多重化のリソースを予約します。</span><span class="sxs-lookup"><span data-stu-id="bea62-292">Pin muxing clients reserve pin muxing resources by opening a handle to the resource.</span></span> <span data-ttu-id="bea62-293">ハードウェアの変更を有効にするために、クライアントは *IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* 要求を送信して構成をコミットする必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-293">To effect a hardware change, clients must commit the configuration by sending an *IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* request.</span></span> <span data-ttu-id="bea62-294">クライアントはハンドルを閉じることでピンの多重化のリソースを解放し、この時点で多重化構成は既定の状態に戻ります。</span><span class="sxs-lookup"><span data-stu-id="bea62-294">Clients release pin muxing resources by closing the handle, at which point muxing configuration is reverted to its default state.</span></span>
* <span data-ttu-id="bea62-295">ACPI ファームウェアは、`MsftFunctionConfig()` リソースにより多重化構成を指定します。</span><span class="sxs-lookup"><span data-stu-id="bea62-295">ACPI firmware – specifies muxing configuration with `MsftFunctionConfig()` resources.</span></span> <span data-ttu-id="bea62-296">MsftFunctionConfig リソースは、どのピンがどの多重化構成でクライアントにより必要とされるかを表します。</span><span class="sxs-lookup"><span data-stu-id="bea62-296">MsftFunctionConfig resources express which pins, in which muxing configuration, are required by a client.</span></span> <span data-ttu-id="bea62-297">MsftFunctionConfig リソースには、機能番号、プル構成、ピン番号の一覧が含まれます。</span><span class="sxs-lookup"><span data-stu-id="bea62-297">MsftFunctionConfig resources contain function number, pull configuration, and list of pin numbers.</span></span> <span data-ttu-id="bea62-298">MsftFunctionConfig リソースはハードウェア リソースとしてピンの多重化のクライアントに提供され、GPIO および SPB 接続リソースと同様に、ドライバーによって PrepareHardware コールバックで受け取られます。</span><span class="sxs-lookup"><span data-stu-id="bea62-298">MsftFunctionConfig resources are supplied to pin muxing clients as hardware resources, which are received by drivers in their PrepareHardware callback similarly to GPIO and SPB connection resources.</span></span> <span data-ttu-id="bea62-299">クライアントは、リソースに対してハンドルを開くために使うことができるリソース ハブ ID を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="bea62-299">Clients receive a resource hub ID which can be used to open a handle to the resource.</span></span>

> <span data-ttu-id="bea62-300">`MsftFunctionConfig()` 記述子を含んでいる ASL ファイルをコンパイルするには、`/MsftInternal` コマンド ライン スイッチを `asl.exe` に渡す必要があります。これは、これらの記述子が、ACPI 作業部会で現在検討中であるためです。</span><span class="sxs-lookup"><span data-stu-id="bea62-300">You must pass the `/MsftInternal` command line switch to `asl.exe` to compile ASL files containing `MsftFunctionConfig()` descriptors since these descriptors are currently under review by the ACPI working committee.</span></span> <span data-ttu-id="bea62-301">たとえば、次のように指定します。</span><span class="sxs-lookup"><span data-stu-id="bea62-301">For example:</span></span> `asl.exe /MsftInternal dsdt.asl`

<span data-ttu-id="bea62-302">ピンの多重化に関連する操作の順序を次に示します。</span><span class="sxs-lookup"><span data-stu-id="bea62-302">The sequence of operations involved in pin muxing is shown below.</span></span>

![ピンの多重化のクライアントとサーバーの相互作用](images/usermode-access-diagram-1.png)

1. <span data-ttu-id="bea62-304">クライアントは、[EvtDevicePrepareHardware()](https://msdn.microsoft.com/library/windows/hardware/ff540880.aspx) コールバックで、ACPI ファームウェアから MsftFunctionConfig リソースを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="bea62-304">The client receives MsftFunctionConfig resources from ACPI firmware in its [EvtDevicePrepareHardware()](https://msdn.microsoft.com/library/windows/hardware/ff540880.aspx) callback.</span></span>
2. <span data-ttu-id="bea62-305">クライアントはリソース ハブ ヘルパー関数 `RESOURCE_HUB_CREATE_PATH_FROM_ID()` を使ってリソース ID からパスを作成し、([ZwCreateFile()](https://msdn.microsoft.com/library/windows/hardware/ff566424.aspx)、[IoGetDeviceObjectPointer()](https://msdn.microsoft.com/library/windows/hardware/ff549198.aspx)、または [WdfIoTargetOpen()](https://msdn.microsoft.com/library/windows/hardware/ff548634.aspx) を使って) そのパスに対してハンドルを開きます。</span><span class="sxs-lookup"><span data-stu-id="bea62-305">The client uses the resource hub helper function `RESOURCE_HUB_CREATE_PATH_FROM_ID()` to create a path from the resource ID, then opens a handle to the path (using [ZwCreateFile()](https://msdn.microsoft.com/library/windows/hardware/ff566424.aspx), [IoGetDeviceObjectPointer()](https://msdn.microsoft.com/library/windows/hardware/ff549198.aspx), or [WdfIoTargetOpen()](https://msdn.microsoft.com/library/windows/hardware/ff548634.aspx)).</span></span>
3. <span data-ttu-id="bea62-306">サーバーがリソース ハブ ヘルパー関数 `RESOURCE_HUB_ID_FROM_FILE_NAME()` を使ってファイル パスからリソース ハブ ID を抽出してから、リソース ハブを照会してリソース記述子を取得します。</span><span class="sxs-lookup"><span data-stu-id="bea62-306">The server extracts the resource hub ID from the file path using resource hub helper functions `RESOURCE_HUB_ID_FROM_FILE_NAME()`, then queries the resource hub to get the resource descriptor.</span></span>
4. <span data-ttu-id="bea62-307">サーバーは記述子内の各ピンの共有の判別を実行し、IRP_MJ_CREATE 要求を完了します。</span><span class="sxs-lookup"><span data-stu-id="bea62-307">The server performs sharing arbitration for each pin in the descriptor and completes the IRP_MJ_CREATE request.</span></span>
5. <span data-ttu-id="bea62-308">クライアントが受け取ったハンドルに対する *IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* 要求を生成します。</span><span class="sxs-lookup"><span data-stu-id="bea62-308">The client issues an *IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* request on the received handle.</span></span>
6. <span data-ttu-id="bea62-309">*IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* に応えて、指定された機能を各ピンでアクティブにすることで、サーバーがハードウェアの多重化操作を実行します。</span><span class="sxs-lookup"><span data-stu-id="bea62-309">In response to *IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS*, the server performs the hardware muxing operation by making the specified function active on each pin.</span></span>
7. <span data-ttu-id="bea62-310">要求されたピンの多重化構成に応じた操作でクライアントの処理が先に進みます。</span><span class="sxs-lookup"><span data-stu-id="bea62-310">The client proceeds with operations that depend on the requested pin muxing configuration.</span></span>
8. <span data-ttu-id="bea62-311">クライアントでピンの多重化が不要になると、ハンドルが閉じられます。</span><span class="sxs-lookup"><span data-stu-id="bea62-311">When the client no longer requires the pins to be muxed, it closes the handle.</span></span>
9. <span data-ttu-id="bea62-312">閉じられたハンドルに応じて、サーバーがピンを初期状態に戻します。</span><span class="sxs-lookup"><span data-stu-id="bea62-312">In response to the handle being closed, the server reverts the pins back to their initial state.</span></span>

### <a name="protocol-description-for-pin-muxing-clients"></a><span data-ttu-id="bea62-313">ピンの多重化のクライアントのためのプロトコルの説明</span><span class="sxs-lookup"><span data-stu-id="bea62-313">Protocol description for pin muxing clients</span></span>

<span data-ttu-id="bea62-314">このセクションでは、クライアントがピンの多重化機能を使う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="bea62-314">This section describes how a client consumes pin muxing functionality.</span></span> <span data-ttu-id="bea62-315">コントローラー ドライバーの代わりにフレームワークがこのプロトコルを実装するため、`SerCx` および `SpbCx` コントローラー ドライバーには適用されません。</span><span class="sxs-lookup"><span data-stu-id="bea62-315">This does not apply to `SerCx` and `SpbCx` controller drivers, since the frameworks implement this protocol on behalf of controller drivers.</span></span>

#### <a name="parsing-resources"></a><span data-ttu-id="bea62-316">リソースの解析</span><span class="sxs-lookup"><span data-stu-id="bea62-316">Parsing resources</span></span>

<span data-ttu-id="bea62-317">WDF ドライバーが [EvtDevicePrepareHardware()](https://msdn.microsoft.com/library/windows/hardware/ff540880.aspx) ルーチンで `MsftFunctionConfig()` リソースを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="bea62-317">A WDF driver receives `MsftFunctionConfig()` resources in its [EvtDevicePrepareHardware()](https://msdn.microsoft.com/library/windows/hardware/ff540880.aspx) routine.</span></span> <span data-ttu-id="bea62-318">MsftFunctionConfig リソースは、次のフィールドで識別できます。</span><span class="sxs-lookup"><span data-stu-id="bea62-318">MsftFunctionConfig resources can be identified by the following fields:</span></span>

```cpp
CM_PARTIAL_RESOURCE_DESCRIPTOR::Type = CmResourceTypeConnection
CM_PARTIAL_RESOURCE_DESCRIPTOR::u.Connection.Class = CM_RESOURCE_CONNECTION_CLASS_FUNCTION_CONFIG
CM_PARTIAL_RESOURCE_DESCRIPTOR::u.Connection.Type = CM_RESOURCE_CONNECTION_TYPE_FUNCTION_CONFIG
```

<span data-ttu-id="bea62-319">`EvtDevicePrepareHardware()` ルーチンは、次のように MsftFunctionConfig リソースを展開します。</span><span class="sxs-lookup"><span data-stu-id="bea62-319">An `EvtDevicePrepareHardware()` routine might extract MsftFunctionConfig resources as follows:</span></span>

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

#### <a name="reserving-and-committing-resources"></a><span data-ttu-id="bea62-320">リソースの予約とコミット</span><span class="sxs-lookup"><span data-stu-id="bea62-320">Reserving and committing resources</span></span>

<span data-ttu-id="bea62-321">クライアントでピンの多重化が必要な場合、MsftFunctionConfig リソースを予約してコミットします。</span><span class="sxs-lookup"><span data-stu-id="bea62-321">When a client wants to mux pins, it reserves and commits the MsftFunctionConfig resource.</span></span> <span data-ttu-id="bea62-322">次の例は、クライアントが MsftFunctionConfig リソースを予約してコミットする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="bea62-322">The following example shows how a client might reserve and commit MsftFunctionConfig resources.</span></span>

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

<span data-ttu-id="bea62-323">ドライバーは、後で閉じることができるように、WDFIOTARGET をいずれかのコンテキスト領域に格納する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-323">The driver should store the WDFIOTARGET in one of its context areas so that it can be closed later.</span></span> <span data-ttu-id="bea62-324">ドライバーが多重化構成を解放する準備ができたら、[WdfObjectDelete()](https://msdn.microsoft.com/library/windows/hardware/ff548734.aspx) を呼び出すか、WDFIOTARGET を再利用する場合には [WdfIoTargetClose()](https://msdn.microsoft.com/library/windows/hardware/ff548586.aspx) を呼び出してリソース ハンドルを閉じる必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-324">When the driver is ready to release the muxing configuration, it should close the resource handle by calling [WdfObjectDelete()](https://msdn.microsoft.com/library/windows/hardware/ff548734.aspx), or [WdfIoTargetClose()](https://msdn.microsoft.com/library/windows/hardware/ff548586.aspx) if you intend to reuse the WDFIOTARGET.</span></span>

```cpp
    WdfObjectDelete(resourceHandle);
```

<span data-ttu-id="bea62-325">クライアントがそのリソース ハンドルを閉じると、ピンは多重化されて初期状態に戻され、別のクライアントで取得できるようになります。</span><span class="sxs-lookup"><span data-stu-id="bea62-325">When the client closes its resource handle, the pins are muxed back to their initial state, and can now be acquired by a different client.</span></span>

### <a name="protocol-description-for-pin-muxing-servers"></a><span data-ttu-id="bea62-326">ピンの多重化のサーバーのためのプロトコルの説明</span><span class="sxs-lookup"><span data-stu-id="bea62-326">Protocol description for pin muxing servers</span></span>

<span data-ttu-id="bea62-327">このセクションでは、ピンの多重化のサーバーがその機能をクライアントに公開する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="bea62-327">This section describes how a pin muxing server exposes its functionality to clients.</span></span> <span data-ttu-id="bea62-328">クライアント ドライバーの代わりにフレームワークがこのプロトコルを実装するため、`GpioClx` ミニポート ドライバーには適用されません。</span><span class="sxs-lookup"><span data-stu-id="bea62-328">This does not apply to `GpioClx` miniport drivers, since the framework implements this protocol on behalf of client drivers.</span></span> <span data-ttu-id="bea62-329">`GpioClx` クライアント ドライバーでピンの多重化をサポートする方法について詳しくは、「[GpioClx クライアント ドライバーでの多重化のサポートの実装](#supporting-muxing-support-in-gpioclx-client-drivers)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bea62-329">For details on how to support pin muxing in `GpioClx` client drivers, see [Implementing muxing support in GpioClx Client Drivers](#supporting-muxing-support-in-gpioclx-client-drivers).</span></span>

#### <a name="handling-irpmjcreate-requests"></a><span data-ttu-id="bea62-330">IRP_MJ_CREATE 要求の処理</span><span class="sxs-lookup"><span data-stu-id="bea62-330">Handling IRP_MJ_CREATE requests</span></span>

<span data-ttu-id="bea62-331">クライアントは、ピンの多重化のリソースを予約するときにリソースに対してハンドルを開きます。</span><span class="sxs-lookup"><span data-stu-id="bea62-331">Clients open a handle to a resource when they want to reserve a pin muxing resource.</span></span> <span data-ttu-id="bea62-332">ピンの多重化のサーバーが、リソース ハブからの再解析操作により *IRP_MJ_CREATE* 要求を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="bea62-332">A pin muxing server receives *IRP_MJ_CREATE* requests by way of a reparse operation from the resource hub.</span></span> <span data-ttu-id="bea62-333">*IRP_MJ_CREATE* 要求の末尾のパス コンポーネントには、16 進数形式の 64 ビット整数であるリソース ハブ ID が含まれています。</span><span class="sxs-lookup"><span data-stu-id="bea62-333">The trailing path component of the *IRP_MJ_CREATE* request contains the resource hub ID, which is a 64-bit integer in hexadecimal format.</span></span> <span data-ttu-id="bea62-334">サーバーは、reshub.h から `RESOURCE_HUB_ID_FROM_FILE_NAME()` を使ってファイル名からリソース ハブ ID を抽出し、*IOCTL_RH_QUERY_CONNECTION_PROPERTIES* をリソース ハブに送信して `MsftFunctionConfig()` 記述子を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-334">The server should extract the resource hub ID from the filename using `RESOURCE_HUB_ID_FROM_FILE_NAME()` from reshub.h, and send *IOCTL_RH_QUERY_CONNECTION_PROPERTIES* to the resource hub to obtain the `MsftFunctionConfig()` descriptor.</span></span>

<span data-ttu-id="bea62-335">サーバーは記述子を検証して、共有モードとピンの一覧を記述子から抽出する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-335">The server should validate the descriptor and extract the sharing mode and pin list from the descriptor.</span></span> <span data-ttu-id="bea62-336">その後、ピンの共有の判別を実行し、成功した場合には、要求を完了する前にピンを予約済みとしてマークします。</span><span class="sxs-lookup"><span data-stu-id="bea62-336">It should then perform sharing arbitration for the pins, and if successful, mark the pins as reserved before completing the request.</span></span>

<span data-ttu-id="bea62-337">ピンの一覧の各ピンで共有の判別が成功すると、全体的な共有の判別が成功します。</span><span class="sxs-lookup"><span data-stu-id="bea62-337">Sharing arbitration succeeds overall if sharing arbitration succeeds for each pin in the pin list.</span></span> <span data-ttu-id="bea62-338">各ピンは次のように判別する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-338">Each pin should be arbitrated as follows:</span></span>

* <span data-ttu-id="bea62-339">ピンがまだ予約されていない場合、共有の判別は成功します。</span><span class="sxs-lookup"><span data-stu-id="bea62-339">If the pin is not already reserved, sharing arbitration succeeds.</span></span>
* <span data-ttu-id="bea62-340">ピンが既に排他的に予約されている場合、共有の判別は失敗します。</span><span class="sxs-lookup"><span data-stu-id="bea62-340">If the pin is already reserved as exclusive, sharing arbitration fails.</span></span>
* <span data-ttu-id="bea62-341">ピンが既に共有として予約されていて、</span><span class="sxs-lookup"><span data-stu-id="bea62-341">If the pin is already reserved as shared,</span></span>
  * <span data-ttu-id="bea62-342">着信要求が共有されている場合、共有の判定は成功します。</span><span class="sxs-lookup"><span data-stu-id="bea62-342">and the incoming request is shared, sharing arbitration succeeds.</span></span>
  * <span data-ttu-id="bea62-343">着信要求が排他的な場合、共有の判別は失敗します。</span><span class="sxs-lookup"><span data-stu-id="bea62-343">and the incoming request is exclusive, sharing arbitration fails.</span></span>

<span data-ttu-id="bea62-344">共有の判別に失敗した場合は、*STATUS_GPIO_INCOMPATIBLE_CONNECT_MODE* で要求を完了する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-344">If sharing arbitration fails, the request should be completed with *STATUS_GPIO_INCOMPATIBLE_CONNECT_MODE*.</span></span> <span data-ttu-id="bea62-345">共有の判別に成功した場合は、*STATUS_SUCCESS* で要求を完了する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-345">If sharing arbitration succeeds, the request should completed with *STATUS_SUCCESS*.</span></span>

<span data-ttu-id="bea62-346">着信要求の共有モードは、[IrpSp->Parameters.Create.ShareAccess](https://msdn.microsoft.com/library/windows/hardware/ff548630.aspx) ではなく MsftFunctionConfig 記述子から取得する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="bea62-346">Note that the sharing mode of the incoming request should be taken from the MsftFunctionConfig descriptor, not [IrpSp->Parameters.Create.ShareAccess](https://msdn.microsoft.com/library/windows/hardware/ff548630.aspx).</span></span>

#### <a name="handling-ioctlgpiocommitfunctionconfigpins-requests"></a><span data-ttu-id="bea62-347">IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS 要求の処理</span><span class="sxs-lookup"><span data-stu-id="bea62-347">Handling IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS requests</span></span>

<span data-ttu-id="bea62-348">クライアントがハンドルを開くことで MsftFunctionConfig リソースの予約に成功した後は、*IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* を送信して実際のハードウェア多重化操作を実行するようサーバーに要求することができます。</span><span class="sxs-lookup"><span data-stu-id="bea62-348">After the client has successfully reserved a MsftFunctionConfig resource by opening a handle, it can send *IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* to request the server to perform the actual hardware muxing operation.</span></span> <span data-ttu-id="bea62-349">サーバーが *IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* を受け取ると、ピンの一覧の各ピンは、</span><span class="sxs-lookup"><span data-stu-id="bea62-349">When the server receives *IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS*, for each pin in the pin list it should</span></span>

* <span data-ttu-id="bea62-350">PNP_FUNCTION_CONFIG_DESCRIPTOR 構造の PinConfiguration メンバーで指定されたプル モードをハードウェアに設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-350">Set the pull mode specified in the PinConfiguration member of the PNP_FUNCTION_CONFIG_DESCRIPTOR structure into hardware.</span></span>
* <span data-ttu-id="bea62-351">PNP_FUNCTION_CONFIG_DESCRIPTOR 構造の FunctionNumber メンバーによって指定された機能に対してピンを多重化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-351">Mux the pin to the function specified by the FunctionNumber member of the PNP_FUNCTION_CONFIG_DESCRIPTOR structure.</span></span>

<span data-ttu-id="bea62-352">サーバーはその後、*STATUS_SUCCESS* を使って要求を完了する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-352">The server should then complete the request with *STATUS_SUCCESS*.</span></span>

<span data-ttu-id="bea62-353">FunctionNumber の意味はサーバーによって定義され、サーバーが MsftFunctionConfig のフィールドをどのように解釈して、MsftFunctionConfig 記述子が作成されたかがわかります。</span><span class="sxs-lookup"><span data-stu-id="bea62-353">The meaning of FunctionNumber is defined by the server, and it is understood that the MsftFunctionConfig descriptor was authored with knowledge of how the server interprets this field.</span></span>

<span data-ttu-id="bea62-354">ハンドルが閉じられたときにサーバーは IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS が受け取られたときの構成にピンを戻す必要があるため、ピンの状態を変更する前に保存する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="bea62-354">Remember that when the handle is closed, the server will have to revert the pins to the configuration they were in when IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS was received, so the server may need to save the pins’ state before modifying them.</span></span>

#### <a name="handling-irpmjclose-requests"></a><span data-ttu-id="bea62-355">IRP_MJ_CLOSE 要求の処理</span><span class="sxs-lookup"><span data-stu-id="bea62-355">Handling IRP_MJ_CLOSE requests</span></span>

<span data-ttu-id="bea62-356">クライアントで多重化のリソースが不要になったときは、そのハンドルを閉じます。</span><span class="sxs-lookup"><span data-stu-id="bea62-356">When a client no longer requires a muxing resource, it closes its handle.</span></span> <span data-ttu-id="bea62-357">サーバーが *IRP_MJ_CLOSE* 要求を受け取ったときに、*IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* が受け取られたときの状態にピンを戻す必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-357">When a server receives a *IRP_MJ_CLOSE* request, it should revert the pins to the state they were in when *IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* was received.</span></span> <span data-ttu-id="bea62-358">クライアントが *IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS* を送信しない場合、操作は不要です。</span><span class="sxs-lookup"><span data-stu-id="bea62-358">If the client never sent a *IOCTL_GPIO_COMMIT_FUNCTION_CONFIG_PINS*, no action is necessary.</span></span> <span data-ttu-id="bea62-359">サーバーはその後、共有の判別に関して利用可能とピンをマークし、*STATUS_SUCCESS* を使って要求を完了する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-359">The server should then mark the pins as available with respect to sharing arbitration, and complete the request with *STATUS_SUCCESS*.</span></span> <span data-ttu-id="bea62-360">*IRP_MJ_CLOSE* の処理と *IRP_MJ_CREATE* の処理を正しく同期してください。</span><span class="sxs-lookup"><span data-stu-id="bea62-360">Be sure to properly synchronize *IRP_MJ_CLOSE* handling with *IRP_MJ_CREATE* handling.</span></span>

### <a name="authoring-guidelines-for-acpi-tables"></a><span data-ttu-id="bea62-361">ACPI テーブルの作成のガイドライン</span><span class="sxs-lookup"><span data-stu-id="bea62-361">Authoring guidelines for ACPI tables</span></span>

<span data-ttu-id="bea62-362">このセクションでは、クライアント ドライバーに多重化のリソースを指定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="bea62-362">This section describes how to supply muxing resources to client drivers.</span></span> <span data-ttu-id="bea62-363">`MsftFunctionConfig()` リソースを含むテーブルをコンパイルするために、Microsoft ASL コンパイラ ビルド 14327 以降が必要となることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="bea62-363">Note that you will need Microsoft ASL compiler build 14327 or later to compile tables containing `MsftFunctionConfig()` resources.</span></span> `MsftFunctionConfig()` <span data-ttu-id="bea62-364">リソースは、ピンの多重化のクライアントにハードウェア リソースとして提供されます。</span><span class="sxs-lookup"><span data-stu-id="bea62-364">resources are supplied to pin muxing clients as hardware resources.</span></span> `MsftFunctionConfig()` <span data-ttu-id="bea62-365">リソースは、ピンの多重化の変更が必要なドライバーに提供する必要があります。これは通常 SPB およびシリアル コントローラー ドライバーですが、コントローラー ドライバーが多重化構成を扱うため、SPB およびシリアル周辺機器ドライバーには提供しません。</span><span class="sxs-lookup"><span data-stu-id="bea62-365">resources should be supplied to drivers that require pin muxing changes, which are typically SPB and serial controller drivers, but should not be supplied to SPB and serial peripheral drivers, since the controller driver handles muxing configuration.</span></span>
<span data-ttu-id="bea62-366">`MsftFunctionConfig()` ACPI マクロは、次のように定義されています。</span><span class="sxs-lookup"><span data-stu-id="bea62-366">The `MsftFunctionConfig()` ACPI macro is defined as follows:</span></span>

```cpp
  MsftFunctionConfig(Shared/Exclusive
                PinPullConfig,
                FunctionNumber,
                ResourceSource,
                ResourceSourceIndex,
                ResourceConsumer/ResourceProducer,
                VendorData) { Pin List }

```

* <span data-ttu-id="bea62-367">Shared/Exclusive – 排他的な場合、このピンは一度に単一のクライアントで取得できます。</span><span class="sxs-lookup"><span data-stu-id="bea62-367">Shared/Exclusive – If exclusive, this pin can be acquired by a single client at a time.</span></span> <span data-ttu-id="bea62-368">共有の場合、複数の共有クライアントがリソースを取得できます。</span><span class="sxs-lookup"><span data-stu-id="bea62-368">If shared, multiple shared clients can acquire the resource.</span></span> <span data-ttu-id="bea62-369">調整がされていない複数のクライアントによる変更可能なリソースへのアクセスを許可すると、データの競合につながり、予期しない結果となる可能性があるため、常に排他的に設定します。</span><span class="sxs-lookup"><span data-stu-id="bea62-369">Always set this to exclusive since allowing multiple uncoordinated clients to access a mutable resource can lead to data races and therefore unpredictable results.</span></span>
* <span data-ttu-id="bea62-370">PinPullConfig – 次のいずれかに設定します。</span><span class="sxs-lookup"><span data-stu-id="bea62-370">PinPullConfig – one of</span></span>
  * <span data-ttu-id="bea62-371">PullDefault – SOC 定義の電源投入時の既定のプル構成を使います</span><span class="sxs-lookup"><span data-stu-id="bea62-371">PullDefault – use the SOC-defined power-on default pull configuration</span></span>
  * <span data-ttu-id="bea62-372">PullUp – プル アップ抵抗を有効にします</span><span class="sxs-lookup"><span data-stu-id="bea62-372">PullUp – enable pull-up resistor</span></span>
  * <span data-ttu-id="bea62-373">PullDown – プル ダウン抵抗を有効にします</span><span class="sxs-lookup"><span data-stu-id="bea62-373">PullDown – enable pull-down resistor</span></span>
  * <span data-ttu-id="bea62-374">PullNone – すべてのプル抵抗を無効にします</span><span class="sxs-lookup"><span data-stu-id="bea62-374">PullNone – disable all pull resistors</span></span>
* <span data-ttu-id="bea62-375">FunctionNumber – 多重化にプログラムする機能番号です。</span><span class="sxs-lookup"><span data-stu-id="bea62-375">FunctionNumber – the function number to program into the mux.</span></span>
* <span data-ttu-id="bea62-376">ResourceSource – ピンの多重化のサーバーの ACPI 名前空間パスです</span><span class="sxs-lookup"><span data-stu-id="bea62-376">ResourceSource – The ACPI namespace path of the pin muxing server</span></span>
* <span data-ttu-id="bea62-377">ResourceSourceIndex – 0 に設定します</span><span class="sxs-lookup"><span data-stu-id="bea62-377">ResourceSourceIndex – set this to 0</span></span>
* <span data-ttu-id="bea62-378">ResourceConsumer/ResourceProducer – ResourceConsumer に設定します</span><span class="sxs-lookup"><span data-stu-id="bea62-378">ResourceConsumer/ResourceProducer – set this to ResourceConsumer</span></span>
* <span data-ttu-id="bea62-379">VendorData – ピンの多重化のサーバーによって意味が定義される、オプションのバイナリ データです。</span><span class="sxs-lookup"><span data-stu-id="bea62-379">VendorData – optional binary data whose meaning is defined by the pin muxing server.</span></span> <span data-ttu-id="bea62-380">通常は空白のままにします</span><span class="sxs-lookup"><span data-stu-id="bea62-380">This should usually be left blank</span></span>
* <span data-ttu-id="bea62-381">Pin List – 構成を適用するピン番号のコンマ区切りの一覧です。</span><span class="sxs-lookup"><span data-stu-id="bea62-381">Pin List – a comma separated list of pin numbers to which the configuration applies.</span></span> <span data-ttu-id="bea62-382">ピンの多重化のサーバーが GpioClx ドライバーの場合、これらは GPIO ピン番号になり、GpioIo 記述子のピン番号と同じ意味を持ちます。</span><span class="sxs-lookup"><span data-stu-id="bea62-382">When the pin muxing server is a GpioClx driver, these are GPIO pin numbers and have the same meaning as pin numbers in a GpioIo descriptor.</span></span>

<span data-ttu-id="bea62-383">次の例では、MsftFunctionConfig() リソースを I2C コントローラー ドライバーに提供する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="bea62-383">The following example shows how one might supply a MsftFunctionConfig() resource to an I2C controller driver.</span></span>

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

<span data-ttu-id="bea62-384">通常コントローラー ドライバーに必要なメモリと割り込みリソースに加えて、`MsftFunctionConfig()` リソースも指定します。</span><span class="sxs-lookup"><span data-stu-id="bea62-384">In addition to the memory and interrupt resources typically required by a controller driver, a `MsftFunctionConfig()` resource is also specified.</span></span> <span data-ttu-id="bea62-385">このリソースにより、I2C コントローラー ドライバーが (\\_SB.GPIO0 でデバイス ノードにより管理された) ピン 2 および 3 をプル アップ抵抗が有効になった状態で機能 4 に配置することができます。</span><span class="sxs-lookup"><span data-stu-id="bea62-385">This resource enables the I2C controller driver to put pins 2 and 3 - managed by the device node at \\_SB.GPIO0 – in function 4 with pull-up resistor enabled.</span></span>

## <a name="supporting-muxing-support-in-gpioclx-client-drivers"></a><span data-ttu-id="bea62-386">GpioClx クライアント ドライバーでの多重化サポートのサポート</span><span class="sxs-lookup"><span data-stu-id="bea62-386">Supporting muxing support in GpioClx client drivers</span></span>

`GpioClx` <span data-ttu-id="bea62-387">には、ピンの多重化のための組み込みサポートがあります。</span><span class="sxs-lookup"><span data-stu-id="bea62-387">has built-in support for pin muxing.</span></span> <span data-ttu-id="bea62-388">GpioClx ミニポート ドライバー (“GpioClx クライアント ドライバー” とも呼ばれます) が GPIO コントローラー ハードウェアを制御します。</span><span class="sxs-lookup"><span data-stu-id="bea62-388">GpioClx miniport drivers (also referred to as “GpioClx client drivers”), drive GPIO controller hardware.</span></span> <span data-ttu-id="bea62-389">Windows 10 ビルド 14327 以降では、GpioClx ミニポート ドライバーは 2 つの新しい DDI を実装することでピンの多重化のサポートを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="bea62-389">As of Windows 10 build 14327, GpioClx miniport drivers can add support for pin muxing by implementing two new DDIs:</span></span>

* <span data-ttu-id="bea62-390">CLIENT_ConnectFunctionConfigPins – `GpioClx` によって呼び出され、ミニポート ドライバーが指定された多重化構成を適用するように指示を出します。</span><span class="sxs-lookup"><span data-stu-id="bea62-390">CLIENT_ConnectFunctionConfigPins – called by `GpioClx` to command the miniport driver to apply the specified muxing configuration.</span></span>
* <span data-ttu-id="bea62-391">CLIENT_DisconnectFunctionConfigPins – `GpioClx` によって呼び出され、ミニポート ドライバーが多重化構成を戻すように指示を出します。</span><span class="sxs-lookup"><span data-stu-id="bea62-391">CLIENT_DisconnectFunctionConfigPins – called by `GpioClx` to command the miniport driver to revert the muxing configuration.</span></span>

<span data-ttu-id="bea62-392">これらのルーチンの説明については、「[GpioClx イベント コールバック関数](https://msdn.microsoft.com/library/windows/hardware/hh439464.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bea62-392">See [GpioClx Event Callback Functions](https://msdn.microsoft.com/library/windows/hardware/hh439464.aspx) for a description of these routines.</span></span>

<span data-ttu-id="bea62-393">これらの 2 つの新しい DDI に加えて、既存の DDI もピンの多重化の互換性の監査対象とする必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-393">In addition to these two new DDIs, existing DDIs should be audited for pin muxing compatibility:</span></span>

* <span data-ttu-id="bea62-394">CLIENT_ConnectIoPins/CLIENT_ConnectInterrupt – CLIENT_ConnectIoPins は GpioClx によって呼び出され、ミニポート ドライバーが GPIO 入力または出力のための一連のピンを構成するように指示を出します。</span><span class="sxs-lookup"><span data-stu-id="bea62-394">CLIENT_ConnectIoPins/CLIENT_ConnectInterrupt – CLIENT_ConnectIoPins is called by GpioClx to command the miniport driver to configure a set pins for GPIO input or output.</span></span> <span data-ttu-id="bea62-395">GPIO は MsftFunctionConfig と相互に排他的なため、GPIO と MsftFunctionConfig に同時にピンが接続されることはありません。</span><span class="sxs-lookup"><span data-stu-id="bea62-395">GPIO is mutually exclusive with MsftFunctionConfig, meaning a pin will never be connected for GPIO and MsftFunctionConfig at the same time.</span></span> <span data-ttu-id="bea62-396">ピンの既定の機能が GPIO である必要はないため、ConnectIoPins が呼び出されたときにピンが必ずしも GPIO に多重化されないとは限りません。</span><span class="sxs-lookup"><span data-stu-id="bea62-396">Since a pin’s default function is not required to be GPIO, a pin may not necessarily not be muxed to GPIO when ConnectIoPins is called.</span></span> <span data-ttu-id="bea62-397">ConnectIoPins は、多重化操作を含む、GPIO IO のためのピンの準備に必要なすべての操作を実行するために必要です。</span><span class="sxs-lookup"><span data-stu-id="bea62-397">ConnectIoPins is required to perform all operations necessary to make the pin ready for GPIO IO, including muxing operations.</span></span> <span data-ttu-id="bea62-398">割り込みは GPIO 入力の特殊なケースと考えることができるため、*CLIENT_ConnectInterrupt* も同様に動作する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-398">*CLIENT_ConnectInterrupt* should behave similarly, since interrupts can be thought of as a special case of GPIO input.</span></span>
* <span data-ttu-id="bea62-399">CLIENT_DisconnectIoPins/CLIENT_DisconnectInterrupt – これらのルーチンは、PreserveConfiguration フラグが指定されていない限り、CLIENT_ConnectIoPins/CLIENT_ConnectInterrupt が呼び出されたときの状態にピンを戻す必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-399">CLIENT_DisconnectIoPins/CLIENT_DisconnectInterrupt – These routine should return pins to the state they were in when CLIENT_ConnectIoPins/CLIENT_ConnectInterrupt was called, unless the PreserveConfiguration flag is specified.</span></span> <span data-ttu-id="bea62-400">ピンの方向を既定の状態に戻すだけでなく、ミニポートが各ピンの多重化の状態を _Connect routine が呼び出されたときの状態に戻す必要もあります。</span><span class="sxs-lookup"><span data-stu-id="bea62-400">In addition to reverting the direction of pins to their default state, the miniport should also revert each pin’s muxing state to the state it was in when the _Connect routine was called.</span></span>

<span data-ttu-id="bea62-401">たとえば、ピンの既定の多重化構成が UART で、ピンが GPIO としても使うことができると想定します。</span><span class="sxs-lookup"><span data-stu-id="bea62-401">For example, assume that a pin’s default muxing configuration is UART, and the pin can also be used as GPIO.</span></span> <span data-ttu-id="bea62-402">GPIO のピンの接続のために CLIENT_ConnectIoPins が呼び出されると、ピンを GPIO に多重化する必要があり、CLIENT_DisconnectIoPins でピンを UART に多重化して戻す必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-402">When CLIENT_ConnectIoPins is called to connect the pin for GPIO, it should mux the pin to GPIO, and in CLIENT_DisconnectIoPins, it should mux the pin back to UART.</span></span> <span data-ttu-id="bea62-403">一般的に、_Disconnect ルーチンは _Connect ルーチンによって行われた操作を元に戻す必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-403">In general, the _Disconnect routines should undo operations done by the _Connect routines.</span></span>

## <a name="supporting-muxing-in-spbcx-and-sercx-controller-drivers"></a><span data-ttu-id="bea62-404">SpbCx および SerCx コントローラー ドライバーでの多重化のサポート</span><span class="sxs-lookup"><span data-stu-id="bea62-404">Supporting muxing in SpbCx and SerCx controller drivers</span></span>

<span data-ttu-id="bea62-405">Windows 10 ビルド 14327 以降では、`SpbCx` および `SerCx` コントローラー ドライバーをコントローラー ドライバー自体のコードを変更せずにピンの多重化のクライアントにできるようにする、ピンの多重化のための組み込みサポートが `SpbCx` および `SerCx` フレームワークに含まれています。</span><span class="sxs-lookup"><span data-stu-id="bea62-405">As of Windows 10 build 14327, the `SpbCx` and `SerCx` frameworks contain built-in support for pin muxing that enables `SpbCx` and `SerCx` controller drivers to be pin muxing clients without any code changes to the controller drivers themselves.</span></span> <span data-ttu-id="bea62-406">拡張機能によって、多重化対応の SpbCx/SerCx コントローラー ドライバーに接続する SpbCx/SerCx 周辺機器ドライバーがピンの多重化アクティビティをトリガーします。</span><span class="sxs-lookup"><span data-stu-id="bea62-406">By extension, any SpbCx/SerCx peripheral driver that connects to a muxing-enabled SpbCx/SerCx controller driver will trigger pin muxing activity.</span></span>

<span data-ttu-id="bea62-407">次の図は、これらの各コンポーネント間の依存関係を示しています。</span><span class="sxs-lookup"><span data-stu-id="bea62-407">The following diagram shows the dependencies between each of these components.</span></span> <span data-ttu-id="bea62-408">図に示されているように、ピンの多重化は SerCx および SpbCx コントローラー ドライバーからの依存関係を GPIO ドライバーに導入し、通常はこれにより多重化が行われます。</span><span class="sxs-lookup"><span data-stu-id="bea62-408">As you can see, pin muxing introduces a dependency from SerCx and SpbCx controller drivers to the GPIO driver, which is usually responsible for muxing.</span></span>

![ピンの多重化の依存関係](images/usermode-access-diagram-2.png)

<span data-ttu-id="bea62-410">デバイスの初期化時に、`SpbCx` および `SerCx` フレームワークがハードウェア リソースとしてデバイスに提供されたすべての `MsftFunctionConfig()` リソースを解析します。</span><span class="sxs-lookup"><span data-stu-id="bea62-410">At device initialization time, the `SpbCx` and `SerCx` frameworks parse all `MsftFunctionConfig()` resources supplied as hardware resources to the device.</span></span> <span data-ttu-id="bea62-411">SpbCx/SerCx はその後、必要に応じてピンの多重化のリソースを取得および解放します。</span><span class="sxs-lookup"><span data-stu-id="bea62-411">SpbCx/SerCx then acquire and release the pin muxing resources on demand.</span></span>

`SpbCx` <span data-ttu-id="bea62-412">は、クライアント ドライバーの [EvtSpbTargetConnect()](https://msdn.microsoft.com/library/windows/hardware/hh450818.aspx) コールバックの呼び出しの直前に、*IRP_MJ_CREATE* ハンドラー内のピンの多重化構成を適用します。</span><span class="sxs-lookup"><span data-stu-id="bea62-412">applies pin muxing configuration in its *IRP_MJ_CREATE* handler, just before calling the client driver’s [EvtSpbTargetConnect()](https://msdn.microsoft.com/library/windows/hardware/hh450818.aspx) callback.</span></span> <span data-ttu-id="bea62-413">多重化構成を適用できなかった場合、コントローラー ドライバーの `EvtSpbTargetConnect()` コールバックは呼び出されません。</span><span class="sxs-lookup"><span data-stu-id="bea62-413">If muxing configuration could not be applied, the controller driver’s `EvtSpbTargetConnect()` callback will not be called.</span></span> <span data-ttu-id="bea62-414">そのため、SPB コントローラー ドライバーは `EvtSpbTargetConnect()` が呼び出されたときまでにピンが SPB 機能に対して多重化されていると想定することができます。</span><span class="sxs-lookup"><span data-stu-id="bea62-414">Therefore, an SPB controller driver may assume that pins are muxed to the SPB function by the time `EvtSpbTargetConnect()` is called.</span></span>

`SpbCx` <span data-ttu-id="bea62-415">は、コントローラー ドライバーの [EvtSpbTargetDisconnect()](https://msdn.microsoft.com/library/windows/hardware/hh450820.aspx) コールバックを呼び出した直後に、*IRP_MJ_CLOSE* ハンドラー内のピンの多重化構成に戻します。</span><span class="sxs-lookup"><span data-stu-id="bea62-415">reverts pin muxing configuration in its *IRP_MJ_CLOSE* handler, just after invoking the controller driver’s [EvtSpbTargetDisconnect()](https://msdn.microsoft.com/library/windows/hardware/hh450820.aspx) callback.</span></span> <span data-ttu-id="bea62-416">その結果、周辺機器ドライバーが SPB コントローラー ドライバーに対してハンドルを開くたびにピンが SPB 機能に対して多重化され、周辺機器ドライバーがハンドルを閉じると多重化が終了します。</span><span class="sxs-lookup"><span data-stu-id="bea62-416">The result is that pins are muxed to the SPB function whenever a peripheral driver opens a handle to the SPB controller driver, and are muxed away when the peripheral driver closes their handle.</span></span>

`SerCx` <span data-ttu-id="bea62-417">も同様に動作します。</span><span class="sxs-lookup"><span data-stu-id="bea62-417">behaves similarly.</span></span> `SerCx` <span data-ttu-id="bea62-418">は、コントローラー ドライバーの [EvtSerCx2FileOpen()](https://msdn.microsoft.com/library/windows/hardware/dn265209.aspx) コールバックの呼び出しの直前に *IRP_MJ_CREATE* ハンドラー内のすべての `MsftFunctionConfig()` リソースを取得し、コントローラー ドライバーの [EvtSerCx2FileClose](https://msdn.microsoft.com/library/windows/hardware/dn265208.aspx) コールバックが呼び出された直後に IRP_MJ_CLOSE ハンドラー内のすべてのリソースを解放します。</span><span class="sxs-lookup"><span data-stu-id="bea62-418">acquires all `MsftFunctionConfig()` resources in its *IRP_MJ_CREATE* handler just before invoking the controller driver’s [EvtSerCx2FileOpen()](https://msdn.microsoft.com/library/windows/hardware/dn265209.aspx) callback, and releases all resources in its IRP_MJ_CLOSE handler, just after invoking the controller driver’s [EvtSerCx2FileClose](https://msdn.microsoft.com/library/windows/hardware/dn265208.aspx) callback.</span></span>

<span data-ttu-id="bea62-419">`SerCx` および `SpbCx` コントローラー ドライバーのための動的なピンの多重化の実装では、特定の時間で SPB/UART 機能のピンの多重化が終了することを許容できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-419">The implication of dynamic pin muxing for `SerCx` and `SpbCx` controller drivers is that they must be able to tolerate pins being muxed away from SPB/UART function at certain times.</span></span> <span data-ttu-id="bea62-420">コントローラー ドライバーは、`EvtSpbTargetConnect()` または `EvtSerCx2FileOpen()` が呼び出されるまでピンが多重化されないことを前提とする必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-420">Controller drivers need to assume that pins will not be muxed until `EvtSpbTargetConnect()` or `EvtSerCx2FileOpen()` is called.</span></span> <span data-ttu-id="bea62-421">次のコールバック中に必ずしもピンが SPB/UART 機能に多重化される必要はありません。</span><span class="sxs-lookup"><span data-stu-id="bea62-421">Pins are not necessary muxed to SPB/UART function during the following callbacks.</span></span> <span data-ttu-id="bea62-422">次に示すのは完全な一覧ではありませんが、コントローラー ドライバーによって実装される最も一般的な PNP ルーチンを示しています。</span><span class="sxs-lookup"><span data-stu-id="bea62-422">The following is not a complete list, but represents the most common PNP routines implemented by controller drivers.</span></span>

* <span data-ttu-id="bea62-423">DriverEntry</span><span class="sxs-lookup"><span data-stu-id="bea62-423">DriverEntry</span></span>
* <span data-ttu-id="bea62-424">EvtDriverDeviceAdd</span><span class="sxs-lookup"><span data-stu-id="bea62-424">EvtDriverDeviceAdd</span></span>
* <span data-ttu-id="bea62-425">EvtDevicePrepareHardware/EvtDeviceReleaseHardware</span><span class="sxs-lookup"><span data-stu-id="bea62-425">EvtDevicePrepareHardware/EvtDeviceReleaseHardware</span></span>
* <span data-ttu-id="bea62-426">EvtDeviceD0Entry/EvtDeviceD0Exit</span><span class="sxs-lookup"><span data-stu-id="bea62-426">EvtDeviceD0Entry/EvtDeviceD0Exit</span></span>

## <a name="verification"></a><span data-ttu-id="bea62-427">検証</span><span class="sxs-lookup"><span data-stu-id="bea62-427">Verification</span></span>

<span data-ttu-id="bea62-428">rhproxy をテストする準備ができたら、次の手順を使用すると便利です。</span><span class="sxs-lookup"><span data-stu-id="bea62-428">When you're ready to test rhproxy, it's helpful to use the following step-by-step procedure.</span></span>

1. <span data-ttu-id="bea62-429">`SpbCx`、`GpioClx`、`SerCx` の各コントローラー ドライバーの読み込みと正しい動作を確認します。</span><span class="sxs-lookup"><span data-stu-id="bea62-429">Verify that each `SpbCx`, `GpioClx`, and `SerCx` controller driver is loading and operating correctly</span></span>
1. <span data-ttu-id="bea62-430">`rhproxy` がシステムに存在することを確認します。</span><span class="sxs-lookup"><span data-stu-id="bea62-430">Verify that `rhproxy` is present on the system.</span></span> <span data-ttu-id="bea62-431">Windows のエディションやビルドによっては、これが含まれていない場合があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-431">Some editions and builds of Windows do not have it.</span></span>
1. <span data-ttu-id="bea62-432">次を使用して rhproxy ノードをコンパイルして読み込みます。</span><span class="sxs-lookup"><span data-stu-id="bea62-432">Compile and load your rhproxy node using</span></span> `ACPITABL.dat`
1. <span data-ttu-id="bea62-433">`rhproxy` デバイス ノードが存在することを確認します。</span><span class="sxs-lookup"><span data-stu-id="bea62-433">Verify that the `rhproxy` device node exists</span></span>
1. <span data-ttu-id="bea62-434">`rhproxy` が読み込まれ、開始されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="bea62-434">Verify that `rhproxy` is loading and starting</span></span>
1. <span data-ttu-id="bea62-435">想定されているデバイスがユーザー モードに公開されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="bea62-435">Verify that the expected devices are exposed to usermode</span></span>
1. <span data-ttu-id="bea62-436">コマンド ラインから各デバイスを操作できることを確認します。</span><span class="sxs-lookup"><span data-stu-id="bea62-436">Verify that you can interact with each device from the command line</span></span>
1. <span data-ttu-id="bea62-437">UWP アプリから各デバイスを操作できることを確認します。</span><span class="sxs-lookup"><span data-stu-id="bea62-437">Verify that you can interact with each device from a UWP app</span></span>
1. <span data-ttu-id="bea62-438">HLK テストを実行します。</span><span class="sxs-lookup"><span data-stu-id="bea62-438">Run HLK tests</span></span>

### <a name="verify-controller-drivers"></a><span data-ttu-id="bea62-439">コントローラー ドライバーを確認する</span><span class="sxs-lookup"><span data-stu-id="bea62-439">Verify controller drivers</span></span>

<span data-ttu-id="bea62-440">rhproxy は、システム上の他のデバイスもユーザー モードに公開するため、それらのデバイスが既に動作している場合にのみ動作します。</span><span class="sxs-lookup"><span data-stu-id="bea62-440">Since rhproxy exposes other devices on the system to usermode, it only works if those devices are already working.</span></span> <span data-ttu-id="bea62-441">最初の手順では、それらのデバイス (公開する I2C、SPI、GPIO コントローラー) が既に動作していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="bea62-441">The first step is to verify that those devices - the I2C, SPI, GPIO controllers you wish to expose - are already working.</span></span>

<span data-ttu-id="bea62-442">コマンド プロンプトで、次のコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="bea62-442">At the command prompt, run</span></span>

```ps
devcon status *
```

<span data-ttu-id="bea62-443">出力を確認し、対象となるすべてのデバイスが起動されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="bea62-443">Look at the output and verify that all devices of interest are started.</span></span> <span data-ttu-id="bea62-444">デバイスに問題コードがある場合は、そのデバイスが読み込まれなかった理由を解決する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-444">If a device has a problem code, you need to troubleshoot why that device is not loading.</span></span> <span data-ttu-id="bea62-445">プラットフォームの最初の起動時にすべてのデバイスが有効になっている必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-445">All devices should have been enabled during initial platform bringup.</span></span> <span data-ttu-id="bea62-446">`SpbCx`、`GpioClx`、または `SerCx` コントローラー ドライバーのトラブルシューティングについては、このドキュメントでは説明しません。</span><span class="sxs-lookup"><span data-stu-id="bea62-446">Troubleshooting `SpbCx`, `GpioClx`, or `SerCx` controller drivers is beyond the scope of this document.</span></span>

### <a name="verify-that-rhproxy-is-present-on-the-system"></a><span data-ttu-id="bea62-447">rhproxy がシステムに存在することを確認する</span><span class="sxs-lookup"><span data-stu-id="bea62-447">Verify that rhproxy is present on the system</span></span>

<span data-ttu-id="bea62-448">`rhproxy` サービスがシステムに存在することを確認します。</span><span class="sxs-lookup"><span data-stu-id="bea62-448">Verify that the `rhproxy` service is present on the system.</span></span>

```ps
reg query HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Services\rhproxy
```

<span data-ttu-id="bea62-449">このレジストリ キーが存在しない場合、rhproxy はシステムに存在しません。</span><span class="sxs-lookup"><span data-stu-id="bea62-449">If the reg key is not present, rhproxy doesn't exist on your system.</span></span> <span data-ttu-id="bea62-450">rhproxy は、IoT Core のすべてのビルドと Windows Enterprise ビルド 15063 以降に存在します。</span><span class="sxs-lookup"><span data-stu-id="bea62-450">Rhproxy is present on all builds of IoT Core and Windows Enterprise build 15063 and later.</span></span>

### <a name="compile-and-load-asl-with-acpitabldat"></a><span data-ttu-id="bea62-451">ACPITABL.dat を使用して ASL をコンパイルして読み込む</span><span class="sxs-lookup"><span data-stu-id="bea62-451">Compile and load ASL with ACPITABL.dat</span></span>

<span data-ttu-id="bea62-452">rhproxy ASL ノードを作成したら、これをコンパイルして読み込みます。</span><span class="sxs-lookup"><span data-stu-id="bea62-452">Now that you've authored an rhproxy ASL node, it's time to compile and load it.</span></span> <span data-ttu-id="bea62-453">システムの ACPI テーブルに追加できるスタンドアロン AML ファイルに、rhproxy ノードをコンパイルすることができます。</span><span class="sxs-lookup"><span data-stu-id="bea62-453">You can compile the rhproxy node into a standalone AML file that can be appended to the system ACPI tables.</span></span> <span data-ttu-id="bea62-454">または、システムの ACPI ソースにアクセスできる場合は、プラットフォームの ACPI テーブルに直接 rhproxy ノードを挿入できます。</span><span class="sxs-lookup"><span data-stu-id="bea62-454">Alternatively, if you have access to your system's ACPI sources, you can insert the rhproxy node directly to your platform's ACPI tables.</span></span> <span data-ttu-id="bea62-455">ただし、最初の起動時には、`ACPITABL.dat` を使用する方が容易な場合があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-455">However, during initial bringup it may be easier to use `ACPITABL.dat`.</span></span>

1. <span data-ttu-id="bea62-456">yourboard.asl という名前のファイルを作成し、DefinitionBlock 内に RHPX デバイス ノードを配置します。</span><span class="sxs-lookup"><span data-stu-id="bea62-456">Create a file named yourboard.asl and put the RHPX device node inside a DefinitionBlock:</span></span>

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

2. <span data-ttu-id="bea62-457">[WDK](https://docs.microsoft.com/windows-hardware/drivers/download-the-wdk) をダウンロードし、次の場所で `asl.exe` を検索します。</span><span class="sxs-lookup"><span data-stu-id="bea62-457">Download the [WDK](https://docs.microsoft.com/windows-hardware/drivers/download-the-wdk) and find `asl.exe` at</span></span> `C:\Program Files (x86)\Windows Kits\10\Tools\x64\ACPIVerify`
3. <span data-ttu-id="bea62-458">次のコマンドを実行して ACPITABL.dat を生成します。</span><span class="sxs-lookup"><span data-stu-id="bea62-458">Run the following command to generate ACPITABL.dat:</span></span>

```ps
asl.exe yourboard.asl
```

4. <span data-ttu-id="bea62-459">生成された ACPITABL.dat ファイルを、テスト対象のシステムの c:\windows\system32 にコピーします。</span><span class="sxs-lookup"><span data-stu-id="bea62-459">Copy the resulting ACPITABL.dat file to c:\windows\system32 on your system under test.</span></span>
5. <span data-ttu-id="bea62-460">テスト対象のシステムでテスト署名を有効にします。</span><span class="sxs-lookup"><span data-stu-id="bea62-460">Turn on testsigning on your system under test:</span></span>

```ps
bcdedit /set testsigning on
```

6. <span data-ttu-id="bea62-461">テスト対象のシステムを再起動します。</span><span class="sxs-lookup"><span data-stu-id="bea62-461">Reboot the system under test.</span></span> <span data-ttu-id="bea62-462">システムが ACPITABL.dat で定義された ACPI テーブルをシステム ファームウェア テーブルに追加します。</span><span class="sxs-lookup"><span data-stu-id="bea62-462">The system will append the ACPI tables defined in ACPITABL.dat to the system firmware tables.</span></span>

### <a name="verify-that-the-rhproxy-device-node-exists"></a><span data-ttu-id="bea62-463">rhproxy デバイス ノードが存在することを確認する</span><span class="sxs-lookup"><span data-stu-id="bea62-463">Verify that the rhproxy device node exists</span></span>

<span data-ttu-id="bea62-464">次のコマンドを実行して、rhproxy デバイス ノードを列挙します。</span><span class="sxs-lookup"><span data-stu-id="bea62-464">Run the following command to enumerate the rhproxy device node.</span></span>

```ps
devcon status *msft8000
```

<span data-ttu-id="bea62-465">devcon の出力は、デバイスが存在することを示している必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-465">The output of devcon should indicate that the device is present.</span></span> <span data-ttu-id="bea62-466">デバイス ノードが存在しない場合、ACPI テーブルはシステムに正常に追加されていません。</span><span class="sxs-lookup"><span data-stu-id="bea62-466">If the device node is not present, the ACPI tables were not successfully added to the system.</span></span>

### <a name="verify-that-rhproxy-is-loading-and-starting"></a><span data-ttu-id="bea62-467">rhproxy が読み込まれ、開始されていることを確認する</span><span class="sxs-lookup"><span data-stu-id="bea62-467">Verify that rhproxy is loading and starting</span></span>

<span data-ttu-id="bea62-468">rhproxy の状態を確認します。</span><span class="sxs-lookup"><span data-stu-id="bea62-468">Check the status of rhproxy:</span></span>

```ps
devcon status *msft8000
```

<span data-ttu-id="bea62-469">出力が rhproxy が開始されていることを示している場合、rhproxy は正常に読み込まれて開始されています。</span><span class="sxs-lookup"><span data-stu-id="bea62-469">If the output indicates that rhproxy is started, rhproxy has loaded and started successfully.</span></span> <span data-ttu-id="bea62-470">問題のコードが表示された場合は、調査する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bea62-470">If you see a problem code, you need to investigate.</span></span> <span data-ttu-id="bea62-471">一般的な問題コードには次のようなものがあります。</span><span class="sxs-lookup"><span data-stu-id="bea62-471">Some common problem codes are:</span></span>

* <span data-ttu-id="bea62-472">問題 51 - `CM_PROB_WAITING_ON_DEPENDENCY` -その依存関係のいずれかが読み込みに失敗したため、システムは rhproxy を開始していません。</span><span class="sxs-lookup"><span data-stu-id="bea62-472">Problem 51 - `CM_PROB_WAITING_ON_DEPENDENCY` - The system is not starting rhproxy because one of it's dependencies has failed to load.</span></span> <span data-ttu-id="bea62-473">これは、rhproxy に渡されたリソースが無効な ACPI ノードを指しているか、ターゲット デバイスが起動していないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="bea62-473">This means that either the resources passed to rhproxy point to invalid ACPI nodes, or the target devices are not starting.</span></span> <span data-ttu-id="bea62-474">最初に、すべてのデバイスが正常に実行されていることを再確認します (上記の「コントローラー ドライバーを確認する」を参照)。</span><span class="sxs-lookup"><span data-stu-id="bea62-474">First, double check that all devices are running successfully (see 'Verify controller drivers' above).</span></span> <span data-ttu-id="bea62-475">次に、ASL を再確認し、すべてのリソース パス (例: `\_SB.I2C1`) が正しく、DSDT 内の有効なノードを指していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="bea62-475">Then, double check your ASL and ensure that all your resource paths (e.g. `\_SB.I2C1`) are correct and point to valid nodes in your DSDT.</span></span>
* <span data-ttu-id="bea62-476">問題 10 - `CM_PROB_FAILED_START` - rhproxy を開始できませんでした。ほとんどの場合、リソースの解析の問題が原因です。</span><span class="sxs-lookup"><span data-stu-id="bea62-476">Problem 10 - `CM_PROB_FAILED_START` - Rhproxy failed to start, most likely because of a resource parsing issue.</span></span> <span data-ttu-id="bea62-477">ASL を調べて、DSD 内のリソースのインデックスを再確認し、ピン番号の昇順で GPIO リソースが指定されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="bea62-477">Go over your ASL and double check resource indices in the DSD, and verify that GPIO resources are specified in increasing pin number order.</span></span>

### <a name="verify-that-the-expected-devices-are-exposed-to-usermode"></a><span data-ttu-id="bea62-478">想定されているデバイスがユーザー モードに公開されていることを確認する</span><span class="sxs-lookup"><span data-stu-id="bea62-478">Verify that the expected devices are exposed to usermode</span></span>

<span data-ttu-id="bea62-479">rhproxy が実行されると、ユーザー モードからアクセスできるデバイス インターフェイスが作成されています。</span><span class="sxs-lookup"><span data-stu-id="bea62-479">Now that rhproxy is running, it should have created devices interfaces that can be accessed by usermode.</span></span> <span data-ttu-id="bea62-480">いくつかのコマンド ライン ツールを使用してデバイスを列挙し、デバイスが存在していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="bea62-480">We will use several command line tools to enumerate devices and see that they're present.</span></span>

<span data-ttu-id="bea62-481">複製、[https://github.com/ms-iot/samples](https://github.com/ms-iot/samples)リポジトリとビルド、 `GpioTestTool`、 `I2cTestTool`、 `SpiTestTool`、および`Mincomm`サンプル。</span><span class="sxs-lookup"><span data-stu-id="bea62-481">Clone the [https://github.com/ms-iot/samples](https://github.com/ms-iot/samples) repository and build the `GpioTestTool`, `I2cTestTool`, `SpiTestTool`, and `Mincomm` samples.</span></span> <span data-ttu-id="bea62-482">テスト対象デバイスにツールをコピーし、次のコマンドを使用してデバイスを列挙します。</span><span class="sxs-lookup"><span data-stu-id="bea62-482">Copy the tools to your device under test and use the following commands to enumerate devices.</span></span>

```ps
I2cTestTool.exe -list
SpiTestTool.exe -list
GpioTestTool.exe -list
MinComm.exe -list
```

<span data-ttu-id="bea62-483">デバイスとフレンドリ名の一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="bea62-483">You should see your devices and friendly names listed.</span></span> <span data-ttu-id="bea62-484">右側のデバイスとフレンドリ名が表示されない場合は、ASL を再確認してください。</span><span class="sxs-lookup"><span data-stu-id="bea62-484">If you don't see the right devices and friendly names, double check your ASL.</span></span>

### <a name="verify-each-device-on-the-command-line"></a><span data-ttu-id="bea62-485">コマンド ラインで各デバイスを確認する</span><span class="sxs-lookup"><span data-stu-id="bea62-485">Verify each device on the command line</span></span>

<span data-ttu-id="bea62-486">次の手順では、コマンド ライン ツールを使用して、デバイスを開き、操作します。</span><span class="sxs-lookup"><span data-stu-id="bea62-486">The next step is to use the command line tools to open and interact with the devices.</span></span>

<span data-ttu-id="bea62-487">I2CTestTool の例:</span><span class="sxs-lookup"><span data-stu-id="bea62-487">I2CTestTool example:</span></span>

```ps
I2cTestTool.exe 0x55 I2C1
> write {1 2 3}
> read 3
> writeread {1 2 3} 3
```

<span data-ttu-id="bea62-488">SpiTestTool の例:</span><span class="sxs-lookup"><span data-stu-id="bea62-488">SpiTestTool example:</span></span>

```ps
SpiTestTool.exe -n SPI1
> write {1 2 3}
> read 3
```

<span data-ttu-id="bea62-489">GpioTestTool の例:</span><span class="sxs-lookup"><span data-stu-id="bea62-489">GpioTestTool example:</span></span>

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

<span data-ttu-id="bea62-490">MinComm (シリアル) の例。</span><span class="sxs-lookup"><span data-stu-id="bea62-490">MinComm (serial) example.</span></span> <span data-ttu-id="bea62-491">実行する前に Tx に Rx を接続します。</span><span class="sxs-lookup"><span data-stu-id="bea62-491">Connect Rx to Tx before running:</span></span>

```ps
MinComm "\\?\ACPI#FSCL0007#3#{86e0d1e0-8089-11d0-9ce4-08003e301f73}\0000000000000006"
(type characters and see them echoed back)
```

### <a name="verify-each-device-from-a-uwp-app"></a><span data-ttu-id="bea62-492">UWP アプリから各デバイスを確認する</span><span class="sxs-lookup"><span data-stu-id="bea62-492">Verify each device from a UWP app</span></span>

<span data-ttu-id="bea62-493">次のサンプルを使用して、UWP からデバイスが動作することを確認します。</span><span class="sxs-lookup"><span data-stu-id="bea62-493">Use the following samples to validate that devices work from UWP.</span></span>

| <span data-ttu-id="bea62-494">サンプル</span><span class="sxs-lookup"><span data-stu-id="bea62-494">Sample</span></span> | <span data-ttu-id="bea62-495">リンク</span><span class="sxs-lookup"><span data-stu-id="bea62-495">Link</span></span> |
|------|------|
| <span data-ttu-id="bea62-496">IoT-GPIO</span><span class="sxs-lookup"><span data-stu-id="bea62-496">IoT-GPIO</span></span> | https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/IoT-GPIO |
| <span data-ttu-id="bea62-497">IoT-I2C</span><span class="sxs-lookup"><span data-stu-id="bea62-497">IoT-I2C</span></span> | https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/IoT-I2C |
| <span data-ttu-id="bea62-498">IoT-SPI</span><span class="sxs-lookup"><span data-stu-id="bea62-498">IoT-SPI</span></span> | https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/IoT-SPI |
| <span data-ttu-id="bea62-499">CustomSerialDeviceAccess</span><span class="sxs-lookup"><span data-stu-id="bea62-499">CustomSerialDeviceAccess</span></span> | https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CustomSerialDeviceAccess |

### <a name="run-the-hlk-tests"></a><span data-ttu-id="bea62-500">HLK テストの実行</span><span class="sxs-lookup"><span data-stu-id="bea62-500">Run the HLK Tests</span></span>

<span data-ttu-id="bea62-501">[Hardware Lab Kit (HLK)](https://docs.microsoft.com/windows-hardware/test/hlk/windows-hardware-lab-kit) をダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="bea62-501">Download the [Hardware Lab Kit (HLK)](https://docs.microsoft.com/windows-hardware/test/hlk/windows-hardware-lab-kit).</span></span> <span data-ttu-id="bea62-502">以下のテストが用意されています。</span><span class="sxs-lookup"><span data-stu-id="bea62-502">The following tests are availble:</span></span>

* [<span data-ttu-id="bea62-503">GPIO WinRT 機能とストレス テスト</span><span class="sxs-lookup"><span data-stu-id="bea62-503">GPIO WinRT Functional and Stress Tests</span></span>](https://docs.microsoft.com/windows-hardware/test/hlk/testref/f1fc0922-1186-48bd-bfcd-c7385a2f6f96)
* [<span data-ttu-id="bea62-504">I2C WinRT 書き込みテスト (EEPROM が必要)</span><span class="sxs-lookup"><span data-stu-id="bea62-504">I2C WinRT Write Tests (EEPROM Required)</span></span>](https://docs.microsoft.com/windows-hardware/test/hlk/testref/2ab0df1b-3369-4aaf-a4d5-d157cb7bf578)
* [<span data-ttu-id="bea62-505">I2C WinRT 読み取りテスト (EEPROM が必要)</span><span class="sxs-lookup"><span data-stu-id="bea62-505">I2C WinRT Read Tests (EEPROM Required)</span></span>](https://docs.microsoft.com/windows-hardware/test/hlk/testref/ca91c2d2-4615-4a1b-928e-587ab2b69b04)
* [<span data-ttu-id="bea62-506">I2C WinRT 存在しないスレーブ アドレス テスト</span><span class="sxs-lookup"><span data-stu-id="bea62-506">I2C WinRT Nonexistent Slave Address Tests</span></span>](https://docs.microsoft.com/windows-hardware/test/hlk/testref/2746ad72-fe5c-4412-8231-f7ed53d95e71)
* [<span data-ttu-id="bea62-507">I2C WinRT 高度な機能テスト (mbed LPC1768 が必要)</span><span class="sxs-lookup"><span data-stu-id="bea62-507">I2C WinRT Advanced Functional Tests (mbed LPC1768 Required)</span></span>](https://docs.microsoft.com/windows-hardware/test/hlk/testref/a60f5a94-12b2-4905-8416-e9774f539f1d)
* [<span data-ttu-id="bea62-508">SPI WinRT クロック周波数検証テスト (mbed LPC1768 が必要)</span><span class="sxs-lookup"><span data-stu-id="bea62-508">SPI WinRT Clock Frequency Verification Tests (mbed LPC1768 Required)</span></span>](https://docs.microsoft.com/windows-hardware/test/hlk/testref/50cf9ccc-bbd3-4514-979f-b0499cb18ed8)
* [<span data-ttu-id="bea62-509">SPI WinRT IO 転送テスト (mbed LPC1768 が必要)</span><span class="sxs-lookup"><span data-stu-id="bea62-509">SPI WinRT IO Transfer Tests (mbed LPC1768 Required)</span></span>](https://docs.microsoft.com/windows-hardware/test/hlk/testref/00c892e8-c226-4c71-9c2a-68349fed7113)
* [<span data-ttu-id="bea62-510">SPI WinRT ストライド検証テスト</span><span class="sxs-lookup"><span data-stu-id="bea62-510">SPI WinRT Stride Verification Tests</span></span>](https://docs.microsoft.com/windows-hardware/test/hlk/testref/20c6b079-62f7-4067-953f-e252bd271938)
* [<span data-ttu-id="bea62-511">SPI WinRT 転送ギャップ検出テスト (mbed LPC1768 が必要)</span><span class="sxs-lookup"><span data-stu-id="bea62-511">SPI WinRT Transfer Gap Detection Tests (mbed LPC1768 Required)</span></span>](https://docs.microsoft.com/windows-hardware/test/hlk/testref/6da79d04-940b-4c49-8f00-333bf0cfbb19)

<span data-ttu-id="bea62-512">HLK マネージャーで rhproxy デバイス ノードを選択すると、適用できるテストが自動的に選択されます。</span><span class="sxs-lookup"><span data-stu-id="bea62-512">When you select the rhproxy device node in HLK manager, the applicable tests will automatically be selected.</span></span>

<span data-ttu-id="bea62-513">HLK マネージャーで、[Resource Hub Proxy device] を選択します。</span><span class="sxs-lookup"><span data-stu-id="bea62-513">In the HLK manager, select “Resource Hub Proxy device”:</span></span>

![HLK マネージャーのスクリーンショット](images/usermode-hlk-1.png)

<span data-ttu-id="bea62-515">その後、[テスト] タブをクリックし、I2C WinRT、Gpio WinRT、Spi WinRT のテストを選択します。</span><span class="sxs-lookup"><span data-stu-id="bea62-515">Then click the Tests tab, and select I2C WinRT, Gpio WinRT, and Spi WinRT tests.</span></span>

![HLK マネージャーのスクリーンショット](images/usermode-hlk-2.png)

<span data-ttu-id="bea62-517">[選択したテストの実行] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="bea62-517">Click Run Selected.</span></span> <span data-ttu-id="bea62-518">各テストに関するその他のドキュメントは、テストを右クリックして [テストの説明] をクリックすることで利用できます。</span><span class="sxs-lookup"><span data-stu-id="bea62-518">Further documentation on each test is available by right clicking on the test and clicking “Test Description.”</span></span>

## <a name="resources"></a><span data-ttu-id="bea62-519">リソース</span><span class="sxs-lookup"><span data-stu-id="bea62-519">Resources</span></span>

| <span data-ttu-id="bea62-520">移動先</span><span class="sxs-lookup"><span data-stu-id="bea62-520">Destination</span></span> | <span data-ttu-id="bea62-521">リンク</span><span class="sxs-lookup"><span data-stu-id="bea62-521">Link</span></span> |
|-------------|------|
| <span data-ttu-id="bea62-522">ACPI 5.0 の仕様</span><span class="sxs-lookup"><span data-stu-id="bea62-522">ACPI 5.0 specification</span></span> | http://acpi.info/spec.htm |
| <span data-ttu-id="bea62-523">Asl.exe (Microsoft ASL Compiler)</span><span class="sxs-lookup"><span data-stu-id="bea62-523">Asl.exe (Microsoft ASL Compiler)</span></span> | https://msdn.microsoft.com/library/windows/hardware/dn551195.aspx |
| <span data-ttu-id="bea62-524">Windows.Devices.Gpio</span><span class="sxs-lookup"><span data-stu-id="bea62-524">Windows.Devices.Gpio</span></span> | https://msdn.microsoft.com/library/windows/apps/windows.devices.gpio.aspx |
| <span data-ttu-id="bea62-525">Windows.Devices.I2c</span><span class="sxs-lookup"><span data-stu-id="bea62-525">Windows.Devices.I2c</span></span> | https://msdn.microsoft.com/library/windows/apps/windows.devices.i2c.aspx |
| <span data-ttu-id="bea62-526">Windows.Devices.Spi</span><span class="sxs-lookup"><span data-stu-id="bea62-526">Windows.Devices.Spi</span></span> | https://msdn.microsoft.com/library/windows/apps/windows.devices.spi.aspx |
| <span data-ttu-id="bea62-527">Windows.Devices.SerialCommunication</span><span class="sxs-lookup"><span data-stu-id="bea62-527">Windows.Devices.SerialCommunication</span></span> | https://msdn.microsoft.com/library/windows/apps/windows.devices.serialcommunication.aspx |
| <span data-ttu-id="bea62-528">Test Authoring and Execution Framework (TAEF)</span><span class="sxs-lookup"><span data-stu-id="bea62-528">Test Authoring and Execution Framework (TAEF)</span></span> | https://msdn.microsoft.com/library/windows/hardware/hh439725.aspx |
| <span data-ttu-id="bea62-529">SpbCx</span><span class="sxs-lookup"><span data-stu-id="bea62-529">SpbCx</span></span> | https://msdn.microsoft.com/library/windows/hardware/hh450906.aspx |
| <span data-ttu-id="bea62-530">GpioClx</span><span class="sxs-lookup"><span data-stu-id="bea62-530">GpioClx</span></span> | https://msdn.microsoft.com/library/windows/hardware/hh439508.aspx |
| <span data-ttu-id="bea62-531">SerCx</span><span class="sxs-lookup"><span data-stu-id="bea62-531">SerCx</span></span> | https://msdn.microsoft.com/library/windows/hardware/ff546939.aspx |
| <span data-ttu-id="bea62-532">MITT I2C テスト</span><span class="sxs-lookup"><span data-stu-id="bea62-532">MITT I2C Tests</span></span> | https://msdn.microsoft.com/library/windows/hardware/dn919852.aspx |
| <span data-ttu-id="bea62-533">GpioTestTool</span><span class="sxs-lookup"><span data-stu-id="bea62-533">GpioTestTool</span></span> | https://developer.microsoft.com/windows/iot/samples/GPIOTestTool |
| <span data-ttu-id="bea62-534">I2cTestTool</span><span class="sxs-lookup"><span data-stu-id="bea62-534">I2cTestTool</span></span> | https://developer.microsoft.com/windows/iot/samples/I2cTestTool |
| <span data-ttu-id="bea62-535">SpiTestTool</span><span class="sxs-lookup"><span data-stu-id="bea62-535">SpiTestTool</span></span> | https://developer.microsoft.com/windows/iot/samples/spitesttool |
| <span data-ttu-id="bea62-536">MinComm (シリアル)</span><span class="sxs-lookup"><span data-stu-id="bea62-536">MinComm (Serial)</span></span> | https://github.com/ms-iot/samples/tree/develop/MinComm |
| <span data-ttu-id="bea62-537">ハードウェア ラボ キット (HLK)</span><span class="sxs-lookup"><span data-stu-id="bea62-537">Hardware Lab Kit (HLK)</span></span> | https://msdn.microsoft.com/library/windows/hardware/dn930814.aspx |

## <a name="apendix"></a><span data-ttu-id="bea62-538">付録</span><span class="sxs-lookup"><span data-stu-id="bea62-538">Apendix</span></span>

### <a name="appendix-a---raspberry-pi-asl-listing"></a><span data-ttu-id="bea62-539">付録 A - Raspberry Pi ASL の一覧</span><span class="sxs-lookup"><span data-stu-id="bea62-539">Appendix A - Raspberry Pi ASL Listing</span></span>

<span data-ttu-id="bea62-540">ヘッダーのピン配列:https://developer.microsoft.com/windows/iot/samples/PinMappingsRPi2</span><span class="sxs-lookup"><span data-stu-id="bea62-540">Header pinout: https://developer.microsoft.com/windows/iot/samples/PinMappingsRPi2</span></span>

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

### <a name="appendix-b---minnowboardmax-asl-listing"></a><span data-ttu-id="bea62-541">付録 B - MinnowBoardMax ASL の一覧</span><span class="sxs-lookup"><span data-stu-id="bea62-541">Appendix B - MinnowBoardMax ASL Listing</span></span>

<span data-ttu-id="bea62-542">ヘッダーのピン配列:https://developer.microsoft.com/windows/iot/samples/PinMappingsMBM</span><span class="sxs-lookup"><span data-stu-id="bea62-542">Header pinout: https://developer.microsoft.com/windows/iot/samples/PinMappingsMBM</span></span>

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

### <a name="appendix-c---sample-powershell-script-to-generate-gpio-resources"></a><span data-ttu-id="bea62-543">付録 C - GPIO リソースを生成するためのサンプル Powershell スクリプト</span><span class="sxs-lookup"><span data-stu-id="bea62-543">Appendix C - Sample Powershell script to generate GPIO resources</span></span>

<span data-ttu-id="bea62-544">次のスクリプトを使って、Raspberry Pi の GPIO リソース宣言を生成することができます。</span><span class="sxs-lookup"><span data-stu-id="bea62-544">The following script can be used to generate the GPIO resource declarations for Raspberry Pi:</span></span>

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
