---
author: msatranjr
title: Bluetooth 低エネルギー
description: ここでは、UWP アプリで Bluetooth LE の概要を紹介します。
ms.author: misatran
ms.date: 03/15/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、bluetooth、bluetooth LE、低エネルギー、gatt、ギャップ、中央、周辺、クライアント、サーバー、監視、publisher
ms.localizationpriority: medium
ms.openlocfilehash: 0d6cc1fb5a0b3cb96748b99c490b23a9e1df128f
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "608806"
---
# <a name="bluetooth-low-energy"></a><span data-ttu-id="62953-104">Bluetooth 低エネルギー</span><span class="sxs-lookup"><span data-stu-id="62953-104">Bluetooth Low Energy</span></span>
<span data-ttu-id="62953-105">Bluetooth 低エネルギー (LE) は、プロトコルの検出 power を効率的に使用するデバイス間の通信を定義する仕様です。</span><span class="sxs-lookup"><span data-stu-id="62953-105">Bluetooth Low Energy (LE) is a specification that defines protocols for discovery and communication between power-efficient devices.</span></span> <span data-ttu-id="62953-106">一般的なアクセス プロファイル (ギャップ) プロトコルを使って、デバイスの検出が行われます。</span><span class="sxs-lookup"><span data-stu-id="62953-106">Discovery of devices is done through the Generic Access Profile (GAP) protocol.</span></span> <span data-ttu-id="62953-107">検出後は、一般的な属性 (GATT) プロトコルを使ってデバイスとデバイス通信が行われます。</span><span class="sxs-lookup"><span data-stu-id="62953-107">After discovery, device-to-device communication is done through the Generic Attribute (GATT) protocol.</span></span> <span data-ttu-id="62953-108">ここでは、UWP アプリで Bluetooth LE の概要を紹介します。</span><span class="sxs-lookup"><span data-stu-id="62953-108">This topic provides a quick overview of Bluetooth LE in UWP apps.</span></span> <span data-ttu-id="62953-109">Bluetooth LE に関する詳細情報を参照してください[Bluetooth コア仕様](https://www.bluetooth.com/specifications/bluetooth-core-specification)バージョン 4.0、Bluetooth LE が導入されました。</span><span class="sxs-lookup"><span data-stu-id="62953-109">To see more detail about Bluetooth LE, see the [Bluetooth Core Specification](https://www.bluetooth.com/specifications/bluetooth-core-specification) version 4.0, where Bluetooth LE was introduced.</span></span> 

![Bluetooth LE の役割](images/gatt-roles.png)

*<span data-ttu-id="62953-111">Windows 10 版 1703 で導入された GATT との間隔の役割</span><span class="sxs-lookup"><span data-stu-id="62953-111">GATT and GAP roles were introduced in Windows 10 version 1703</span></span>*

<span data-ttu-id="62953-112">次の名前空間を使用して、UWP アプリで GATT との間隔のプロトコルを実装できます。</span><span class="sxs-lookup"><span data-stu-id="62953-112">GATT and GAP protocols can be implemented in your UWP app by using the following namespaces.</span></span>
- [<span data-ttu-id="62953-113">Windows.Devices.Bluetooth.GenericAttributeProfile</span><span class="sxs-lookup"><span data-stu-id="62953-113">Windows.Devices.Bluetooth.GenericAttributeProfile</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)
- [<span data-ttu-id="62953-114">Windows.Devices.Bluetooth.Advertisement</span><span class="sxs-lookup"><span data-stu-id="62953-114">Windows.Devices.Bluetooth.Advertisement</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)

## <a name="central-and-peripheral"></a><span data-ttu-id="62953-115">中央および周辺</span><span class="sxs-lookup"><span data-stu-id="62953-115">Central and Peripheral</span></span>
<span data-ttu-id="62953-116">検出の 2 つの主要な役割は、中央と周辺と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="62953-116">The two primary roles of discovery are called Central and Peripheral.</span></span> <span data-ttu-id="62953-117">一般に、Windows では、サーバーの全体のモードで動作し、周辺のさまざまなデバイスを接続します。</span><span class="sxs-lookup"><span data-stu-id="62953-117">In general, Windows operates in Central mode and connects to various Peripheral devices.</span></span> 

## <a name="attributes"></a><span data-ttu-id="62953-118">属性</span><span class="sxs-lookup"><span data-stu-id="62953-118">Attributes</span></span>
<span data-ttu-id="62953-119">Windows Bluetooth Api に表示される共通の略語は、一般的な属性 (GATT) です。</span><span class="sxs-lookup"><span data-stu-id="62953-119">A common acronym you will see in the Windows Bluetooth APIs is Generic Attribute (GATT).</span></span> <span data-ttu-id="62953-120">GATT プロファイルは、データの構造と通信する 2 つの Bluetooth LE デバイスでの操作のモードを定義します。</span><span class="sxs-lookup"><span data-stu-id="62953-120">The GATT Profile defines the structure of data and modes of operation by which two Bluetooth LE devices communicate.</span></span> <span data-ttu-id="62953-121">属性は、GATT のメインの文書パーツです。</span><span class="sxs-lookup"><span data-stu-id="62953-121">The attribute is the main building block of GATT.</span></span> <span data-ttu-id="62953-122">属性のメインの種類は、サービス、特性記述子します。</span><span class="sxs-lookup"><span data-stu-id="62953-122">The main types of attributes are services, characteristics and descriptors.</span></span> <span data-ttu-id="62953-123">これらの属性を実行する異なるクライアントとサーバーのために、関連セクション内の相互作用を問い合わせて方が便利です。</span><span class="sxs-lookup"><span data-stu-id="62953-123">These attributes perform differently between clients and servers, so it is more useful to discuss their interaction in the relevant sections.</span></span> 

![一般的なプロファイルで一般的な属性の階層](images/gatt-service.png)

*<span data-ttu-id="62953-125">ハート単価サービスは、GATT サーバー API フォームで表されます。</span><span class="sxs-lookup"><span data-stu-id="62953-125">The heart rate service is expressed in GATT Server API form</span></span>*

## <a name="client-and-server"></a><span data-ttu-id="62953-126">クライアントとサーバー</span><span class="sxs-lookup"><span data-stu-id="62953-126">Client and Server</span></span>
<span data-ttu-id="62953-127">接続を確立後は、(通常は小さい IoT センサーまたはウェアラブル) データが含まれているデバイスがサーバーと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="62953-127">After a connection has been established, the device that contains the data (usually a small IoT sensor or wearable) is known as the Server.</span></span> <span data-ttu-id="62953-128">そのデータを使用して関数を実行するデバイスは、クライアントと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="62953-128">The device that uses that data to perform a function is known as the Client.</span></span> <span data-ttu-id="62953-129">たとえば、Windows PC の場合 (クライアント) からデータを読み取りハート単価モニター (サーバー) を追跡するユーザー最適に動作しています。</span><span class="sxs-lookup"><span data-stu-id="62953-129">For example, a Windows PC (Client) reads data from a heart rate monitor (Server) to track that a user is working out optimally.</span></span> <span data-ttu-id="62953-130">詳細については、 [GATT クライアント](gatt-client.md)と[GATT サーバー](gatt-server.md)のトピックを参照してください。</span><span class="sxs-lookup"><span data-stu-id="62953-130">For more information, see the [GATT Client](gatt-client.md) and [GATT Server](gatt-server.md) topics.</span></span>

## <a name="watchers-and-publishers-beacons"></a><span data-ttu-id="62953-131">ウォッチャーと発行元 (ビーコン)</span><span class="sxs-lookup"><span data-stu-id="62953-131">Watchers and Publishers (Beacons)</span></span>
<span data-ttu-id="62953-132">中央と周辺の役割のほか、オブザーバーとブロードキャスト発信元の役割があります。</span><span class="sxs-lookup"><span data-stu-id="62953-132">In addition to the Central and Peripheral roles, there are Observer and Broadcaster roles.</span></span> <span data-ttu-id="62953-133">アナウンサーはビーコンとも呼ばれます] がない間の通信 GATT コミュニケーションの広告パケットに表示される限られたスペースを使用するため。</span><span class="sxs-lookup"><span data-stu-id="62953-133">Broadcasters are commonly referred to as Beacons, they don't communicate over GATT because they use the limited space provided in the Advertisement packet for communication.</span></span> <span data-ttu-id="62953-134">同様に、データを受信する接続を確立する第三者がないの近くにある広告をスキャンします。</span><span class="sxs-lookup"><span data-stu-id="62953-134">Similarly, an Observer does not have to establish a connection to receive data, it scans for nearby advertisements.</span></span> <span data-ttu-id="62953-135">広告の近くに表示する Windows を設定するのには、 [BluetoothLEAdvertisementWatcher](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher)クラスを使用します。</span><span class="sxs-lookup"><span data-stu-id="62953-135">To configure Windows to observe nearby advertisements, use the [BluetoothLEAdvertisementWatcher](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher) class.</span></span> <span data-ttu-id="62953-136">ビーコン ペイロードをブロードキャストするために、 [BluetoothLEAdvertisementPublisher](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement.bluetoothleadvertisementpublisher)クラスを使用します。</span><span class="sxs-lookup"><span data-stu-id="62953-136">In order to broadcast beacon payloads, use the [BluetoothLEAdvertisementPublisher](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.advertisement.bluetoothleadvertisementpublisher) class.</span></span> <span data-ttu-id="62953-137">詳細については、[広告](ble-beacon.md)のトピックを参照してください。</span><span class="sxs-lookup"><span data-stu-id="62953-137">For more information, see the [Advertisement](ble-beacon.md) topic.</span></span>

## <a name="see-also"></a><span data-ttu-id="62953-138">関連項目</span><span class="sxs-lookup"><span data-stu-id="62953-138">See Also</span></span>
- [<span data-ttu-id="62953-139">Windows.Devices.Bluetooth.GenericAttributeProfile</span><span class="sxs-lookup"><span data-stu-id="62953-139">Windows.Devices.Bluetooth.GenericAttributeProfile</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)
- [<span data-ttu-id="62953-140">Windows.Devices.Bluetooth.Advertisement</span><span class="sxs-lookup"><span data-stu-id="62953-140">Windows.Devices.Bluetooth.Advertisement</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.devices.bluetooth.genericattributeprofile)
- [<span data-ttu-id="62953-141">Bluetooth コアの仕様</span><span class="sxs-lookup"><span data-stu-id="62953-141">Bluetooth Core Specification</span></span>](https://www.bluetooth.com/specifications/bluetooth-core-specification)