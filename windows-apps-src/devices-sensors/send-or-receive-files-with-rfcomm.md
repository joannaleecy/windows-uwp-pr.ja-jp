---
author: msatranjr
ms.assetid: 5B3A6326-15EE-4618-AA8C-F1C7FB5232FB
title: Bluetooth RFCOMM
description: この記事では、ファイルの送受信方法に関するコード例と一緒に、ユニバーサル Windows プラットフォーム (UWP) アプリでの Bluetooth RFCOMM の概要を説明します。
ms.author: misatran
ms.date: 07/19/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
ms.openlocfilehash: 27002fed78356c9a93289d1ccabbada04ea5ed30
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4088109"
---
# <a name="bluetooth-rfcomm"></a><span data-ttu-id="d7e81-104">Bluetooth RFCOMM</span><span class="sxs-lookup"><span data-stu-id="d7e81-104">Bluetooth RFCOMM</span></span>

**<span data-ttu-id="d7e81-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="d7e81-105">Important APIs</span></span>**

-   [**<span data-ttu-id="d7e81-106">Windows.Devices.Bluetooth</span><span class="sxs-lookup"><span data-stu-id="d7e81-106">Windows.Devices.Bluetooth</span></span>**](https://msdn.microsoft.com/library/windows/apps/Dn263413)
-   [**<span data-ttu-id="d7e81-107">Windows.Devices.Bluetooth.Rfcomm</span><span class="sxs-lookup"><span data-stu-id="d7e81-107">Windows.Devices.Bluetooth.Rfcomm</span></span>**](https://msdn.microsoft.com/library/windows/apps/Dn263529)

<span data-ttu-id="d7e81-108">この記事では、ファイルの送受信方法に関するコード例と一緒に、ユニバーサル Windows プラットフォーム (UWP) アプリでの Bluetooth RFCOMM の概要を説明します。</span><span class="sxs-lookup"><span data-stu-id="d7e81-108">This article provides an overview of Bluetooth RFCOMM in Universal Windows Platform (UWP) apps, along with example code on how to send or receive a file..</span></span>

## <a name="overview"></a><span data-ttu-id="d7e81-109">概要</span><span class="sxs-lookup"><span data-stu-id="d7e81-109">Overview</span></span>

<span data-ttu-id="d7e81-110">[**Windows.Devices.Bluetooth.Rfcomm**](https://msdn.microsoft.com/library/windows/apps/Dn263529) 名前空間の API は、[**enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) や [**instantiation**](https://msdn.microsoft.com/library/windows/apps/BR225654) など、既にある Windows.Devices のパターンに基づいて作成されています。</span><span class="sxs-lookup"><span data-stu-id="d7e81-110">The APIs in the [**Windows.Devices.Bluetooth.Rfcomm**](https://msdn.microsoft.com/library/windows/apps/Dn263529) namespace build on existing patterns for Windows.Devices, including [**enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) and [**instantiation**](https://msdn.microsoft.com/library/windows/apps/BR225654).</span></span> <span data-ttu-id="d7e81-111">データの読み取りと書き込みは、[**定型的なデータ ストリーム パターン**](https://msdn.microsoft.com/library/windows/apps/BR208119)と [**Windows.Storage.Streams**](https://msdn.microsoft.com/library/windows/apps/BR241791) 内のオブジェクトを有効に活用できるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="d7e81-111">Data reading and writing is designed to take advantage of [**established data stream patterns**](https://msdn.microsoft.com/library/windows/apps/BR208119) and objects in [**Windows.Storage.Streams**](https://msdn.microsoft.com/library/windows/apps/BR241791).</span></span> <span data-ttu-id="d7e81-112">Service Discovery Protocol (SDP) の属性は、値のほかに、想定されている型を持ちます。</span><span class="sxs-lookup"><span data-stu-id="d7e81-112">Service Discovery Protocol (SDP) attributes have a value and an expected type.</span></span> <span data-ttu-id="d7e81-113">ところが、広く普及しているデバイスの中には、SDP の属性の実装に不備のあるものが存在し、値の型が、想定されている型とは異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="d7e81-113">However, some common devices have faulty implementations of SDP attributes where the value is not of the expected type.</span></span> <span data-ttu-id="d7e81-114">加えて、RFCOMM の多くの用法は、SDP の拡張属性を必要としません。</span><span class="sxs-lookup"><span data-stu-id="d7e81-114">Additionally, many usages of RFCOMM do not require additional SDP attributes at all.</span></span> <span data-ttu-id="d7e81-115">そのため、この API は、未解析の SDP データへのアクセスを提供し、開発者が必要に応じて情報を取得できるようになっています。</span><span class="sxs-lookup"><span data-stu-id="d7e81-115">For these reasons, this API offers access to the unparsed SDP data, from which developers can obtain the information they need.</span></span>

<span data-ttu-id="d7e81-116">RFCOMM API にはサービス識別子の概念が使われています。</span><span class="sxs-lookup"><span data-stu-id="d7e81-116">The RFCOMM APIs use the concept of service identifiers.</span></span> <span data-ttu-id="d7e81-117">サービス識別子は単なる 128 ビットの GUID ですが、16 ビットまたは 32 ビットの整数として指定されることも少なくありません。</span><span class="sxs-lookup"><span data-stu-id="d7e81-117">Although a service identifier is simply a 128-bit GUID, it is also commonly specified as either a 16- or 32-bit integer.</span></span> <span data-ttu-id="d7e81-118">RFCOMM API には、サービス識別子を 128 ビットの GUID としてだけでなく、32 ビットの整数として指定したり利用したりするためのラッパーが用意されていますが、16 ビット整数用のラッパーはありません。</span><span class="sxs-lookup"><span data-stu-id="d7e81-118">The RFCOMM API offers a wrapper for service identifiers that allows them be specified and consumed as 128-bit GUIDs as well as 32-bit integers but does not offer 16-bit integers.</span></span> <span data-ttu-id="d7e81-119">API にとってこの点は問題ではありません。言語が自動的に 32 ビット整数に拡大し、識別子は正しく生成されるためです。</span><span class="sxs-lookup"><span data-stu-id="d7e81-119">This is not an issue for the API because languages will automatically upsize to a 32-bit integer and the identifier can still be correctly generated.</span></span>

<span data-ttu-id="d7e81-120">アプリは、複数のステップから成るデバイス操作をバックグラウンド タスクで実行できます。アプリがバックグラウンドへ移動してサスペンド状態となった場合でも処理が続行されるので、</span><span class="sxs-lookup"><span data-stu-id="d7e81-120">Apps can perform multi-step device operations in a background task so that they can run to completion even if the app is moved to the background and suspended.</span></span> <span data-ttu-id="d7e81-121">信頼性の高いデバイス サービス (ファームウェアの更新、永続的な設定の変更など) やデータ同期を実行できます。ユーザーは PC の前で進捗バーを監視している必要がありません。</span><span class="sxs-lookup"><span data-stu-id="d7e81-121">This allows for reliable device servicing such as changes to persistent settings or firmware, and content synchronization, without requiring the user to sit and watch a progress bar.</span></span> <span data-ttu-id="d7e81-122">デバイス操作を実行するときは [**DeviceServicingTrigger**](https://msdn.microsoft.com/library/windows/apps/Dn297315) を使用し、データを同期するときは [**DeviceUseTrigger**](https://msdn.microsoft.com/library/windows/apps/Dn297337) を使用します。</span><span class="sxs-lookup"><span data-stu-id="d7e81-122">Use the [**DeviceServicingTrigger**](https://msdn.microsoft.com/library/windows/apps/Dn297315) for device servicing and the [**DeviceUseTrigger**](https://msdn.microsoft.com/library/windows/apps/Dn297337) for content synchronization.</span></span> <span data-ttu-id="d7e81-123">これらのバックグラウンド タスクはバックグラウンドでのアプリ実行時間を制御するものであり、無制限な操作や無限の同期を目的としていません。</span><span class="sxs-lookup"><span data-stu-id="d7e81-123">Note that these background tasks constrain the amount of time the app can run in the background, and are not intended to allow indefinite operation or infinite synchronization.</span></span>

<span data-ttu-id="d7e81-124">RFCOMM 操作の詳細を示す完全なコード サンプルについては、Github の [**Bluetooth Rfcomm チャット サンプル**](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BluetoothRfcommChat)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d7e81-124">For a complete code sample that details RFCOMM operation, see the [**Bluetooth Rfcomm Chat Sample**](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BluetoothRfcommChat) on Github.</span></span>  

## <a name="send-a-file-as-a-client"></a><span data-ttu-id="d7e81-125">クライアントとしてファイルを送信する</span><span class="sxs-lookup"><span data-stu-id="d7e81-125">Send a file as a client</span></span>

<span data-ttu-id="d7e81-126">ファイルを送信する際の基本的なアプリのシナリオは、必要なサービスに基づいてペアリングされたデバイスに接続することです。</span><span class="sxs-lookup"><span data-stu-id="d7e81-126">When sending a file, the most basic scenario is to connect to a paired device based on a desired service.</span></span> <span data-ttu-id="d7e81-127">これには、次の手順に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7e81-127">This involves the following steps:</span></span>

-   <span data-ttu-id="d7e81-128">**RfcommDeviceService.GetDeviceSelector\*** 関数を使って AQS クエリを作成し、必要なサービスのペアリングされているデバイスのインスタンスを列挙します。</span><span class="sxs-lookup"><span data-stu-id="d7e81-128">Use the **RfcommDeviceService.GetDeviceSelector\*** functions to help generate an AQS query that can be used to enumerated paired device instances of the desired service.</span></span>
-   <span data-ttu-id="d7e81-129">列挙されたデバイスを選んで [**RfcommDeviceService**](https://msdn.microsoft.com/library/windows/apps/Dn263463) を作成し、適宜 SDP 属性を読み取ります ([**established data helpers**](https://msdn.microsoft.com/library/windows/apps/BR208119) を使って属性のデータを解析します)。</span><span class="sxs-lookup"><span data-stu-id="d7e81-129">Pick an enumerated device, create an [**RfcommDeviceService**](https://msdn.microsoft.com/library/windows/apps/Dn263463), and read the SDP attributes as needed (using [**established data helpers**](https://msdn.microsoft.com/library/windows/apps/BR208119) to parse the attribute's data).</span></span>
-   <span data-ttu-id="d7e81-130">ソケットを作成して、[**RfcommDeviceService.ConnectionHostName**](https://msdn.microsoft.com/library/windows/apps/windows.devices.bluetooth.rfcomm.rfcommdeviceservice.connectionhostname.aspx) と [**RfcommDeviceService.ConnectionServiceName**](https://msdn.microsoft.com/library/windows/apps/windows.devices.bluetooth.rfcomm.rfcommdeviceservice.connectionservicename.aspx) プロパティを [**StreamSocket.ConnectAsync**](https://msdn.microsoft.com/library/windows/apps/Hh701504) に渡し、適切なパラメーターでリモート デバイス サービスに接続します。</span><span class="sxs-lookup"><span data-stu-id="d7e81-130">Create a socket and use the [**RfcommDeviceService.ConnectionHostName**](https://msdn.microsoft.com/library/windows/apps/windows.devices.bluetooth.rfcomm.rfcommdeviceservice.connectionhostname.aspx) and [**RfcommDeviceService.ConnectionServiceName**](https://msdn.microsoft.com/library/windows/apps/windows.devices.bluetooth.rfcomm.rfcommdeviceservice.connectionservicename.aspx) properties to [**StreamSocket.ConnectAsync**](https://msdn.microsoft.com/library/windows/apps/Hh701504) to the remote device service with the appropriate parameters.</span></span>
-   <span data-ttu-id="d7e81-131">定型的なデータ ストリーム パターンに従って、ファイルからデータのチャンクを読み取り、ソケットの [**StreamSocket.OutputStream**](https://msdn.microsoft.com/library/windows/apps/BR226920) でデバイスに送信します。</span><span class="sxs-lookup"><span data-stu-id="d7e81-131">Follow established data stream patterns to read chunks of data from the file and send it on the socket's [**StreamSocket.OutputStream**](https://msdn.microsoft.com/library/windows/apps/BR226920) to the device.</span></span>

```csharp
Windows.Devices.Bluetooth.Rfcomm.RfcommDeviceService _service;
Windows.Networking.Sockets.StreamSocket _socket;

async void Initialize()
{
    // Enumerate devices with the object push service
    var services =
        await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(
            RfcommDeviceService.GetDeviceSelector(
                RfcommServiceId.ObexObjectPush));

    if (services.Count > 0)
    {
        // Initialize the target Bluetooth BR device
        var service = await RfcommDeviceService.FromIdAsync(services[0].Id);

        // Check that the service meets this App's minimum requirement
        if (SupportsProtection(service) && IsCompatibleVersion(service))
        {
            _service = service;

            // Create a socket and connect to the target
            _socket = new StreamSocket();
            await _socket.ConnectAsync(
                _service.ConnectionHostName,
                _service.ConnectionServiceName,
                SocketProtectionLevel
                    .BluetoothEncryptionAllowNullAuthentication);

            // The socket is connected. At this point the App can wait for
            // the user to take some action, e.g. click a button to send a
            // file to the device, which could invoke the Picker and then
            // send the picked file. The transfer itself would use the
            // Sockets API and not the Rfcomm API, and so is omitted here for
            // brevity.
        }
    }
}

// This App requires a connection that is encrypted but does not care about
// whether it's authenticated.
bool SupportsProtection(RfcommDeviceService service)
{
    switch (service.ProtectionLevel)
    {
    case SocketProtectionLevel.PlainSocket:
        if ((service.MaxProtectionLevel == SocketProtectionLevel
                .BluetoothEncryptionWithAuthentication)
            || (service.MaxProtectionLevel == SocketProtectionLevel
                .BluetoothEncryptionAllowNullAuthentication))
        {
            // The connection can be upgraded when opening the socket so the
            // App may offer UI here to notify the user that Windows may
            // prompt for a PIN exchange.
            return true;
        }
        else
        {
            // The connection cannot be upgraded so an App may offer UI here
            // to explain why a connection won't be made.
            return false;
        }
    case SocketProtectionLevel.BluetoothEncryptionWithAuthentication:
        return true;
    case SocketProtectionLevel.BluetoothEncryptionAllowNullAuthentication:
        return true;
    }
    return false;
}

// This App relies on CRC32 checking available in version 2.0 of the service.
const uint SERVICE_VERSION_ATTRIBUTE_ID = 0x0300;
const byte SERVICE_VERSION_ATTRIBUTE_TYPE = 0x0A;   // UINT32
const uint MINIMUM_SERVICE_VERSION = 200;
bool IsCompatibleVersion(RfcommDeviceService service)
{
    var attributes = await service.GetSdpRawAttributesAsync(
        BluetothCacheMode.Uncached);
    var attribute = attributes[SERVICE_VERSION_ATTRIBUTE_ID];
    var reader = DataReader.FromBuffer(attribute);

    // The first byte contains the attribute's type
    byte attributeType = reader.ReadByte();
    if (attributeType == SERVICE_VERSION_ATTRIBUTE_TYPE)
    {
        // The remainder is the data
        uint version = reader.ReadUInt32();
        return version >= MINIMUM_SERVICE_VERSION;
    }
}
```

```cppwinrt
...
#include <winrt/Windows.Devices.Bluetooth.Rfcomm.h>
#include <winrt/Windows.Devices.Enumeration.h>
#include <winrt/Windows.Networking.Sockets.h>
#include <winrt/Windows.Storage.Streams.h>
...
Windows::Devices::Bluetooth::Rfcomm::RfcommDeviceService m_service{ nullptr };
Windows::Networking::Sockets::StreamSocket m_socket;

Windows::Foundation::IAsyncAction Initialize()
{
    // Enumerate devices with the object push service.
    Windows::Devices::Enumeration::DeviceInformationCollection services{
        co_await Windows::Devices::Enumeration::DeviceInformation::FindAllAsync(
            Windows::Devices::Bluetooth::Rfcomm::RfcommDeviceService::GetDeviceSelector(
                Windows::Devices::Bluetooth::Rfcomm::RfcommServiceId::ObexObjectPush())) };

    if (services.Size() > 0)
    {
        // Initialize the target Bluetooth BR device.
        Windows::Devices::Bluetooth::Rfcomm::RfcommDeviceService service{
            co_await Windows::Devices::Bluetooth::Rfcomm::RfcommDeviceService::FromIdAsync(services.GetAt(0).Id()) };

        // Check that the service meets this App's minimum
        // requirement
        if (SupportsProtection(service)
            && co_await IsCompatibleVersion(service))
        {
            m_service = service;

            // Create a socket and connect to the target
            co_await m_socket.ConnectAsync(
                m_service.ConnectionHostName(),
                m_service.ConnectionServiceName(),
                Windows::Networking::Sockets::SocketProtectionLevel::BluetoothEncryptionAllowNullAuthentication);

            // The socket is connected. At this point the App can
            // wait for the user to take some action, e.g. click
            // a button to send a file to the device, which could
            // invoke the Picker and then send the picked file.
            // The transfer itself would use the Sockets API and
            // not the Rfcomm API, and so is omitted here for
            //brevity.
        }
    }
}

// This App requires a connection that is encrypted but does not care about
// whether it's authenticated.
bool SupportsProtection(Windows::Devices::Bluetooth::Rfcomm::RfcommDeviceService const& service)
{
    switch (service.ProtectionLevel())
    {
    case Windows::Networking::Sockets::SocketProtectionLevel::PlainSocket:
        if ((service.MaxProtectionLevel() == Windows::Networking::Sockets::SocketProtectionLevel::BluetoothEncryptionWithAuthentication)
            || (service.MaxProtectionLevel() == Windows::Networking::Sockets::SocketProtectionLevel::BluetoothEncryptionAllowNullAuthentication))
        {
            // The connection can be upgraded when opening the socket so the
            // App may offer UI here to notify the user that Windows may
            // prompt for a PIN exchange.
            return true;
        }
        else
        {
            // The connection cannot be upgraded so an App may offer UI here
            // to explain why a connection won't be made.
            return false;
        }
    case Windows::Networking::Sockets::SocketProtectionLevel::BluetoothEncryptionWithAuthentication:
        return true;
    case Windows::Networking::Sockets::SocketProtectionLevel::BluetoothEncryptionAllowNullAuthentication:
        return true;
    }
    return false;
}

// This application relies on CRC32 checking available in version 2.0 of the service.
const uint32_t SERVICE_VERSION_ATTRIBUTE_ID{ 0x0300 };
const byte SERVICE_VERSION_ATTRIBUTE_TYPE{ 0x0A }; // UINT32.
const uint32_t MINIMUM_SERVICE_VERSION{ 200 };

Windows::Foundation::IAsyncOperation<bool> IsCompatibleVersion(Windows::Devices::Bluetooth::Rfcomm::RfcommDeviceService const& service)
{
    auto attributes{
        co_await service.GetSdpRawAttributesAsync(Windows::Devices::Bluetooth::BluetoothCacheMode::Uncached) };

    auto attribute{ attributes.Lookup(SERVICE_VERSION_ATTRIBUTE_ID) };
    auto reader{ Windows::Storage::Streams::DataReader::FromBuffer(attribute) };

    // The first byte contains the attribute's type.
    byte attributeType{ reader.ReadByte() };
    if (attributeType == SERVICE_VERSION_ATTRIBUTE_TYPE)
    {
        // The remainder is the data
        uint32_t version{ reader.ReadUInt32() };
        co_return (version >= MINIMUM_SERVICE_VERSION);
    }
}
...
```

```cpp
Windows::Devices::Bluetooth::Rfcomm::RfcommDeviceService^ _service;
Windows::Networking::Sockets::StreamSocket^ _socket;

void Initialize()
{
    // Enumerate devices with the object push service
    create_task(
        Windows::Devices::Enumeration::DeviceInformation::FindAllAsync(
            RfcommDeviceService::GetDeviceSelector(
                RfcommServiceId::ObexObjectPush)))
    .then([](DeviceInformationCollection^ services)
    {
        if (services->Size > 0)
        {
            // Initialize the target Bluetooth BR device
            create_task(RfcommDeviceService::FromIdAsync(services[0]->Id))
            .then([](RfcommDeviceService^ service)
            {
                // Check that the service meets this App's minimum
                // requirement
                if (SupportsProtection(service)
                    && IsCompatibleVersion(service))
                {
                    _service = service;

                    // Create a socket and connect to the target
                    _socket = ref new StreamSocket();
                    create_task(_socket->ConnectAsync(
                        _service->ConnectionHostName,
                        _service->ConnectionServiceName,
                        SocketProtectionLevel
                            ::BluetoothEncryptionAllowNullAuthentication)
                    .then([](void)
                    {
                        // The socket is connected. At this point the App can
                        // wait for the user to take some action, e.g. click
                        // a button to send a file to the device, which could
                        // invoke the Picker and then send the picked file.
                        // The transfer itself would use the Sockets API and
                        // not the Rfcomm API, and so is omitted here for
                        //brevity.
                    });
                }
            });
        }
    });
}

// This App requires a connection that is encrypted but does not care about
// whether it's authenticated.
bool SupportsProtection(RfcommDeviceService^ service)
{
    switch (service->ProtectionLevel)
    {
    case SocketProtectionLevel->PlainSocket:
        if ((service->MaxProtectionLevel == SocketProtectionLevel
                ::BluetoothEncryptionWithAuthentication)
            || (service->MaxProtectionLevel == SocketProtectionLevel
                ::BluetoothEncryptionAllowNullAuthentication))
        {
            // The connection can be upgraded when opening the socket so the
            // App may offer UI here to notify the user that Windows may
            // prompt for a PIN exchange.
            return true;
        }
        else
        {
            // The connection cannot be upgraded so an App may offer UI here
            // to explain why a connection won't be made.
            return false;
        }
    case SocketProtectionLevel::BluetoothEncryptionWithAuthentication:
        return true;
    case SocketProtectionLevel::BluetoothEncryptionAllowNullAuthentication:
        return true;
    }
    return false;
}

// This App relies on CRC32 checking available in version 2.0 of the service.
const uint SERVICE_VERSION_ATTRIBUTE_ID = 0x0300;
const byte SERVICE_VERSION_ATTRIBUTE_TYPE = 0x0A;   // UINT32
const uint MINIMUM_SERVICE_VERSION = 200;
bool IsCompatibleVersion(RfcommDeviceService^ service)
{
    auto attributes = await service->GetSdpRawAttributesAsync(
        BluetoothCacheMode::Uncached);
    auto attribute = attributes[SERVICE_VERSION_ATTRIBUTE_ID];
    auto reader = DataReader.FromBuffer(attribute);

    // The first byte contains the attribute's type
    byte attributeType = reader->ReadByte();
    if (attributeType == SERVICE_VERSION_ATTRIBUTE_TYPE)
    {
        // The remainder is the data
        uint version = reader->ReadUInt32();
        return version >= MINIMUM_SERVICE_VERSION;
    }
}
```

## <a name="receive-file-as-a-server"></a><span data-ttu-id="d7e81-132">サーバーとしてファイルを受信する</span><span class="sxs-lookup"><span data-stu-id="d7e81-132">Receive File as a Server</span></span>

<span data-ttu-id="d7e81-133">RFCOMM アプリのシナリオとしては、サービスを PC でホストし、他のデバイスに対して公開するケースも一般的です。</span><span class="sxs-lookup"><span data-stu-id="d7e81-133">Another common RFCOMM App scenario is to host a service on the PC and expose it for other devices.</span></span>

-   <span data-ttu-id="d7e81-134">[**RfcommServiceProvider**](https://msdn.microsoft.com/library/windows/apps/Dn263511) を作成して必要なサービスをアドバタイズします。</span><span class="sxs-lookup"><span data-stu-id="d7e81-134">Create a [**RfcommServiceProvider**](https://msdn.microsoft.com/library/windows/apps/Dn263511) to advertise the desired service.</span></span>
-   <span data-ttu-id="d7e81-135">SDP 属性を適宜設定 ([**established data helpers**](https://msdn.microsoft.com/library/windows/apps/BR208119) を使って属性のデータを生成) し、その SDP レコードを他のデバイスが検索できるようにアドバタイズします。</span><span class="sxs-lookup"><span data-stu-id="d7e81-135">Set the SDP attributes as needed (using [**established data helpers**](https://msdn.microsoft.com/library/windows/apps/BR208119) to generate the attribute’s Data) and starts advertising the SDP records for other devices to retrieve.</span></span>
-   <span data-ttu-id="d7e81-136">クライアント デバイスに接続するには、ソケット リスナーを作成して、着信接続要求のリッスンを開始します。</span><span class="sxs-lookup"><span data-stu-id="d7e81-136">To connect to a client device, create a socket listener to start listening for incoming connection requests.</span></span>
-   <span data-ttu-id="d7e81-137">接続を受信したら、接続済みのソケットを後続の処理のために保存します。</span><span class="sxs-lookup"><span data-stu-id="d7e81-137">When a connection is received, store the connected socket for later processing.</span></span>
-   <span data-ttu-id="d7e81-138">定型的なデータ ストリーム パターンに従って、ソケットの InputStream からデータのチャンクを読み取り、ファイルに保存します。</span><span class="sxs-lookup"><span data-stu-id="d7e81-138">Follow established data stream patterns to read chunks of data from the socket's InputStream and save it to a file.</span></span>

<span data-ttu-id="d7e81-139">バックグラウンドで RFCOMM サービスを保持するために、[**RfcommConnectionTrigger**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.rfcommconnectiontrigger.aspx) を使います。</span><span class="sxs-lookup"><span data-stu-id="d7e81-139">In order to persist an RFCOMM service in the background, use the [**RfcommConnectionTrigger**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.rfcommconnectiontrigger.aspx).</span></span> <span data-ttu-id="d7e81-140">サービスに接続されたら、バックグラウンド タスクがトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="d7e81-140">The background task is triggered on connection to the service.</span></span> <span data-ttu-id="d7e81-141">開発者は、バックグラウンド タスクでソケットへのハンドルを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="d7e81-141">The developer receives a handle to the socket in the background task.</span></span> <span data-ttu-id="d7e81-142">バックグラウンド タスクは実行に時間がかかり、ソケットが使用中である限り保持されます。</span><span class="sxs-lookup"><span data-stu-id="d7e81-142">The background task is long running and persists for as long as the socket is in use.</span></span>    

```csharp
Windows.Devices.Bluetooth.Rfcomm.RfcommServiceProvider _provider;

async void Initialize()
{
    // Initialize the provider for the hosted RFCOMM service
    _provider = await Windows.Devices.Bluetooth.
        RfcommServiceProvider.CreateAsync(RfcommServiceId.ObexObjectPush);

    // Create a listener for this service and start listening
    StreamSocketListener listener = new StreamSocketListener();
    listener.ConnectionReceived += OnConnectionReceived;
    await listener.BindServiceNameAsync(
        _provider.ServiceId.AsString(),
        SocketProtectionLevel
            .BluetoothEncryptionAllowNullAuthentication);

    // Set the SDP attributes and start advertising
    InitializeServiceSdpAttributes(_provider);
    _provider.StartAdvertising(listener);
}

const uint SERVICE_VERSION_ATTRIBUTE_ID = 0x0300;
const byte SERVICE_VERSION_ATTRIBUTE_TYPE = 0x0A;   // UINT32
const uint SERVICE_VERSION = 200;
void InitializeServiceSdpAttributes(RfcommServiceProvider provider)
{
    auto writer = new Windows.Storage.Streams.DataWriter();

    // First write the attribute type
    writer.WriteByte(SERVICE_VERSION_ATTRIBUTE_TYPE);
    // Then write the data
    writer.WriteUInt32(SERVICE_VERSION);

    auto data = writer.DetachBuffer();
    provider.SdpRawAttributes.Add(SERVICE_VERSION_ATTRIBUTE_ID, data);
}

void OnConnectionReceived(
    StreamSocketListener listener,
    StreamSocketListenerConnectionReceivedEventArgs args)
{
    // Stop advertising/listening so that we're only serving one client
    _provider.StopAdvertising();
    await listener.Close();
    _socket = args.Socket;

    // The client socket is connected. At this point the App can wait for
    // the user to take some action, e.g. click a button to receive a file
    // from the device, which could invoke the Picker and then save the
    // received file to the picked location. The transfer itself would use
    // the Sockets API and not the Rfcomm API, and so is omitted here for
    // brevity.
}
```

```cppwinrt
...
#include <winrt/Windows.Devices.Bluetooth.Rfcomm.h>
#include <winrt/Windows.Networking.Sockets.h>
#include <winrt/Windows.Storage.Streams.h>
...
Windows::Devices::Bluetooth::Rfcomm::RfcommServiceProvider m_provider{ nullptr };
Windows::Networking::Sockets::StreamSocket m_socket;

Windows::Foundation::IAsyncAction Initialize()
{
    // Initialize the provider for the hosted RFCOMM service.
    auto provider{ co_await Windows::Devices::Bluetooth::Rfcomm::RfcommServiceProvider::CreateAsync(
        Windows::Devices::Bluetooth::Rfcomm::RfcommServiceId::ObexObjectPush()) };

    m_provider = provider;

    // Create a listener for this service and start listening.
    Windows::Networking::Sockets::StreamSocketListener listener;
    listener.ConnectionReceived({ this, &MainPage::OnConnectionReceived });

    co_await listener.BindServiceNameAsync(m_provider.ServiceId().AsString(),
        Windows::Networking::Sockets::SocketProtectionLevel::BluetoothEncryptionAllowNullAuthentication);

    // Set the SDP attributes and start advertising
    InitializeServiceSdpAttributes();
    m_provider.StartAdvertising(listener);
}

const uint32_t SERVICE_VERSION_ATTRIBUTE_ID{ 0x0300 };
const byte SERVICE_VERSION_ATTRIBUTE_TYPE{ 0x0A };   // UINT32.
const uint32_t SERVICE_VERSION{ 200 };

void InitializeServiceSdpAttributes()
{
    Windows::Storage::Streams::DataWriter writer;

    // First write the attribute type
    writer.WriteByte(SERVICE_VERSION_ATTRIBUTE_TYPE);
    // Then write the data
    writer.WriteUInt32(SERVICE_VERSION);

    auto data{ writer.DetachBuffer() };
    m_provider.SdpRawAttributes().Insert(SERVICE_VERSION_ATTRIBUTE_ID, data);
}

void OnConnectionReceived(
    Windows::Networking::Sockets::StreamSocketListener const& listener,
    Windows::Networking::Sockets::StreamSocketListenerConnectionReceivedEventArgs const& args)
{
    // Stop advertising/listening so that we're only serving one client
    m_provider.StopAdvertising();
    listener.Close();
    m_socket = args.Socket();

    // The client socket is connected. At this point the application can wait for
    // the user to take some action, e.g. click a button to receive a
    // file from the device, which could invoke the Picker and then save
    // the received file to the picked location. The transfer itself
    // would use the Sockets API and not the Rfcomm API, and so is
    // omitted here for brevity.
}
...
```

```cpp
Windows::Devices::Bluetooth::Rfcomm::RfcommServiceProvider^ _provider;
Windows::Networking::Sockets::StreamSocket^ _socket;

void Initialize()
{
    // Initialize the provider for the hosted RFCOMM service
    create_task(Windows::Devices::Bluetooth.
        RfcommServiceProvider::CreateAsync(
            RfcommServiceId::ObexObjectPush))
    .then([](RfcommServiceProvider^ provider) -> task<void> {
        _provider = provider;

        // Create a listener for this service and start listening
        auto listener = ref new StreamSocketListener();
        listener->ConnectionReceived += ref new TypedEventHandler<
                StreamSocketListener^,
                StreamSocketListenerConnectionReceivedEventArgs^>
           (&OnConnectionReceived);
        return create_task(listener->BindServiceNameAsync(
            _provider->ServiceId->AsString(),
            SocketProtectionLevel
                ::BluetoothEncryptionAllowNullAuthentication));
    }).then([listener](void) {
        // Set the SDP attributes and start advertising
        InitializeServiceSdpAttributes(_provider);
        _provider->StartAdvertising(listener);
    });
}

const uint SERVICE_VERSION_ATTRIBUTE_ID = 0x0300;
const byte SERVICE_VERSION_ATTRIBUTE_TYPE = 0x0A;   // UINT32
const uint SERVICE_VERSION = 200;
void InitializeServiceSdpAttributes(RfcommServiceProvider^ provider)
{
    auto writer = ref new Windows::Storage::Streams::DataWriter();

    // First write the attribute type
    writer->WriteByte(SERVICE_VERSION_ATTRIBUTE_TYPE);
    // Then write the data
    writer->WriteUInt32(SERVICE_VERSION);

    auto data = writer->DetachBuffer();
    provider->SdpRawAttributes->Add(SERVICE_VERSION_ATTRIBUTE_ID, data);
}

void OnConnectionReceived(
    StreamSocketListener^ listener,
    StreamSocketListenerConnectionReceivedEventArgs^ args)
{
    // Stop advertising/listening so that we're only serving one client
    _provider->StopAdvertising();
    create_task(listener->Close())
    .then([args](void) {
        _socket = args->Socket;

        // The client socket is connected. At this point the App can wait for
        // the user to take some action, e.g. click a button to receive a
        // file from the device, which could invoke the Picker and then save
        // the received file to the picked location. The transfer itself
        // would use the Sockets API and not the Rfcomm API, and so is
        // omitted here for brevity.
    });
}
```
