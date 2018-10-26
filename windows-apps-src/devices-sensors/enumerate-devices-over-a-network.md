---
author: muhsinking
ms.assetid: E0B9532F-1195-4927-99BE-F41565D891AD
title: ネットワーク経由でデバイスを列挙する
description: Windows.Devices.Enumeration API を使うと、ローカル接続されたデバイスの検出だけでなく、ワイヤレス プロトコルおよびネットワーク プロトコル経由でデバイスを列挙できます。
ms.author: mukin
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 00f8d4314d67828fa30007d3b8af4c4e1d06c154
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5547936"
---
# <a name="enumerate-devices-over-a-network"></a><span data-ttu-id="d9fb6-104">ネットワーク経由でデバイスを列挙する</span><span class="sxs-lookup"><span data-stu-id="d9fb6-104">Enumerate devices over a network</span></span>



**<span data-ttu-id="d9fb6-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="d9fb6-105">Important APIs</span></span>**

- [**<span data-ttu-id="d9fb6-106">Windows.Devices.Enumeration</span><span class="sxs-lookup"><span data-stu-id="d9fb6-106">Windows.Devices.Enumeration</span></span>**](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Enumeration)

<span data-ttu-id="d9fb6-107">[**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) API を使うと、ローカル接続されたデバイスの検出だけでなく、ワイヤレス プロトコルおよびネットワーク プロトコル経由でデバイスを列挙できます。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-107">In addition to discovering locally connected devices, you can use the [**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) APIs to enumerate devices over wireless and networked protocols.</span></span>

## <a name="enumerating-devices-over-networked-or-wireless-protocols"></a><span data-ttu-id="d9fb6-108">ネットワーク プロトコルまたはワイヤレス プロトコルを経由したデバイスの列挙</span><span class="sxs-lookup"><span data-stu-id="d9fb6-108">Enumerating devices over networked or wireless protocols</span></span>

<span data-ttu-id="d9fb6-109">場合によっては、ローカル接続されていない、ワイヤレスまたはネットワーク プロトコル経由でのみ検出できるデバイスを列挙する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-109">Sometimes you need to enumerate devices that are not locally connected and can only be discovered over a wireless or networking protocols.</span></span> <span data-ttu-id="d9fb6-110">これを行うために、[**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) API には、**AssociationEndpoint** (AEP)、**AssociationEndpointContainer** (AEP コンテナー)、**AssociationEndpointService** (AEP サービス) という 3 つの異なる種類のデバイス オブジェクトがあります。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-110">In order to do so, the [**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) APIs have three different kinds of device objects: the **AssociationEndpoint** (AEP), the **AssociationEndpointContainer** (AEP Container), and the **AssociationEndpointService** (AEP Service).</span></span> <span data-ttu-id="d9fb6-111">これらをまとめて AEP または AEP オブジェクトと呼びます。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-111">As a group these are referred to as AEPs or AEP objects.</span></span>

<span data-ttu-id="d9fb6-112">一部のデバイス API には、使用可能な AEP オブジェクトを列挙するためのセレクター文字列が用意されています。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-112">Some device APIs provide a selector string that you can use to enumerate through the available AEP objects.</span></span> <span data-ttu-id="d9fb6-113">これには、システムとペアリングされているデバイスとペアリングされていないデバイスの両方が含まれる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-113">This could include both devices that are paired and are not paired with the system.</span></span> <span data-ttu-id="d9fb6-114">中にはペアリングを必要としないデバイスもあります。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-114">Some of the devices might not require pairing.</span></span> <span data-ttu-id="d9fb6-115">それらのデバイス API では、デバイスを操作する前にペアリングが必要な場合にペアリングが試行されることがあります。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-115">Those device APIs may attempt to pair the device if pairing it is necessary before interacting with it.</span></span> <span data-ttu-id="d9fb6-116">たとえば、Wi-fi Direct はこのパターンに従っている API です。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-116">Wi-Fi Direct is an example of APIs that follow this pattern.</span></span> <span data-ttu-id="d9fb6-117">それらのデバイス API でデバイスのペアリングが自動的に行われない場合は、[**DeviceInformation.Pairing**](https://msdn.microsoft.com/library/windows/apps/Dn705960) から取得できる [**DeviceInformationPairing**](https://msdn.microsoft.com/library/windows/apps/Mt168396) オブジェクトを使ってペアリングを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-117">If those device APIs do not automatically pair the device, you can pair it using the [**DeviceInformationPairing**](https://msdn.microsoft.com/library/windows/apps/Mt168396) object available from [**DeviceInformation.Pairing**](https://msdn.microsoft.com/library/windows/apps/Dn705960).</span></span>

<span data-ttu-id="d9fb6-118">しかし、あらかじめ定義されたセレクター文字列を使わずに手動でデバイスを検出する必要がある場合もあります。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-118">However, there may be cases where you want to manually discover devices on your own without using a pre-defined selector string.</span></span> <span data-ttu-id="d9fb6-119">たとえば、AEP デバイスを操作する必要はなく情報の収集のみが必要な場合や、あらかじめ定義されたセレクター文字列で検出されるより多くの AEP オブジェクトを検索する必要がある場合などが考えられます。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-119">For example, you may just need to gather information about AEP devices without interacting with them or you may want to find more AEP objects than will be discovered with the pre-defined selector string.</span></span> <span data-ttu-id="d9fb6-120">その場合は、「[デバイス セレクターのビルド](build-a-device-selector.md)」の手順に従って、独自のセレクター文字列を作成して使います。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-120">In this case, you will build your own selector string and use it following the instructions under [Build a device selector](build-a-device-selector.md).</span></span>

<span data-ttu-id="d9fb6-121">独自のセレクターを作成する場合は、列挙する範囲を対象プロトコルに絞り込むことを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-121">When you build your own selector, it is strongly recommended that you limit your scope of enumeration to the protocols that you are interested in.</span></span> <span data-ttu-id="d9fb6-122">たとえば、UPnP デバイスのみを対象とする場合は、Wi-Fi Direct デバイスを検索する Wi-Fi 無線を設定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-122">For example, you don't want to have the Wi-Fi radio search for Wi-Fi Direct devices if you are particularly interested in UPnP devices.</span></span> <span data-ttu-id="d9fb6-123">Windows では、列挙範囲を指定するために使うことができるプロトコルの ID が定義されています。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-123">Windows has defined an identity for each protocol that you can use to scope your enumeration.</span></span> <span data-ttu-id="d9fb6-124">次の表では、プロトコルのタイプと ID が一覧表示されています。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-124">The following table lists the protocol types and identifiers.</span></span>

| <span data-ttu-id="d9fb6-125">プロトコルまたはネットワーク デバイスのタイプ</span><span class="sxs-lookup"><span data-stu-id="d9fb6-125">Protocol or network device type</span></span>              | <span data-ttu-id="d9fb6-126">ID</span><span class="sxs-lookup"><span data-stu-id="d9fb6-126">Id</span></span>                                         |
|----------------------------------------------|--------------------------------------------|
| <span data-ttu-id="d9fb6-127">UPnP (DIAL や DLNA など)</span><span class="sxs-lookup"><span data-stu-id="d9fb6-127">UPnP (including DIAL and DLNA)</span></span>               | **<span data-ttu-id="d9fb6-128">{0e261de4-12f0-46e6-91ba-428607ccef64}</span><span class="sxs-lookup"><span data-stu-id="d9fb6-128">{0e261de4-12f0-46e6-91ba-428607ccef64}</span></span>** |
| <span data-ttu-id="d9fb6-129">Web Services on Devices (WSD)</span><span class="sxs-lookup"><span data-stu-id="d9fb6-129">Web services on devices (WSD)</span></span>                | **<span data-ttu-id="d9fb6-130">{782232aa-a2f9-4993-971b-aedc551346b0}</span><span class="sxs-lookup"><span data-stu-id="d9fb6-130">{782232aa-a2f9-4993-971b-aedc551346b0}</span></span>** |
| <span data-ttu-id="d9fb6-131">Wi-Fi Direct</span><span class="sxs-lookup"><span data-stu-id="d9fb6-131">Wi-Fi Direct</span></span>                                 | **<span data-ttu-id="d9fb6-132">{0407d24e-53de-4c9a-9ba1-9ced54641188}</span><span class="sxs-lookup"><span data-stu-id="d9fb6-132">{0407d24e-53de-4c9a-9ba1-9ced54641188}</span></span>** |
| <span data-ttu-id="d9fb6-133">DNS サービス検出 (DNS-SD)</span><span class="sxs-lookup"><span data-stu-id="d9fb6-133">DNS service discovery (DNS-SD)</span></span>               | **<span data-ttu-id="d9fb6-134">{4526e8c1-8aac-4153-9b16-55e86ada0e54}</span><span class="sxs-lookup"><span data-stu-id="d9fb6-134">{4526e8c1-8aac-4153-9b16-55e86ada0e54}</span></span>** |
| <span data-ttu-id="d9fb6-135">Point of Service</span><span class="sxs-lookup"><span data-stu-id="d9fb6-135">Point of service</span></span>                             | **<span data-ttu-id="d9fb6-136">{d4bf61b3-442e-4ada-882d-fa7B70c832d9}</span><span class="sxs-lookup"><span data-stu-id="d9fb6-136">{d4bf61b3-442e-4ada-882d-fa7B70c832d9}</span></span>** |
| <span data-ttu-id="d9fb6-137">ネットワーク プリンター (Active Directory のプリンター)</span><span class="sxs-lookup"><span data-stu-id="d9fb6-137">Network printers (active directory printers)</span></span> | **<span data-ttu-id="d9fb6-138">{37aba761-2124-454c-8d82-c42962c2de2b}</span><span class="sxs-lookup"><span data-stu-id="d9fb6-138">{37aba761-2124-454c-8d82-c42962c2de2b}</span></span>** |
| <span data-ttu-id="d9fb6-139">Windows Connect Now (WNC)</span><span class="sxs-lookup"><span data-stu-id="d9fb6-139">Windows connect now (WNC)</span></span>                    | **<span data-ttu-id="d9fb6-140">{4c1b1ef8-2f62-4b9f-9bc5-b21ab636138f}</span><span class="sxs-lookup"><span data-stu-id="d9fb6-140">{4c1b1ef8-2f62-4b9f-9bc5-b21ab636138f}</span></span>** |
| <span data-ttu-id="d9fb6-141">WiGig ドック</span><span class="sxs-lookup"><span data-stu-id="d9fb6-141">WiGig docks</span></span>                                  | **<span data-ttu-id="d9fb6-142">{a277f3a5-8764-4f88-8045-4c5e962640b1}</span><span class="sxs-lookup"><span data-stu-id="d9fb6-142">{a277f3a5-8764-4f88-8045-4c5e962640b1}</span></span>** |
| <span data-ttu-id="d9fb6-143">HP プリンター用の Wi-Fi プロビジョニング</span><span class="sxs-lookup"><span data-stu-id="d9fb6-143">Wi-Fi provisioning for HP printers</span></span>           | **<span data-ttu-id="d9fb6-144">{c85ef710-f344-4792-bb6d-85a4346f1e69}</span><span class="sxs-lookup"><span data-stu-id="d9fb6-144">{c85ef710-f344-4792-bb6d-85a4346f1e69}</span></span>** |
| <span data-ttu-id="d9fb6-145">Bluetooth</span><span class="sxs-lookup"><span data-stu-id="d9fb6-145">Bluetooth</span></span>                                    | **<span data-ttu-id="d9fb6-146">{e0cbf06c-cd8b-4647-bb8a-263b43f0f974}</span><span class="sxs-lookup"><span data-stu-id="d9fb6-146">{e0cbf06c-cd8b-4647-bb8a-263b43f0f974}</span></span>** |
| <span data-ttu-id="d9fb6-147">Bluetooth LE</span><span class="sxs-lookup"><span data-stu-id="d9fb6-147">Bluetooth LE</span></span>                                 | **<span data-ttu-id="d9fb6-148">{bb7bb05e-5972-42b5-94fc-76eaa7084d49}</span><span class="sxs-lookup"><span data-stu-id="d9fb6-148">{bb7bb05e-5972-42b5-94fc-76eaa7084d49}</span></span>** |

 

## <a name="aqs-examples"></a><span data-ttu-id="d9fb6-149">AQS の例</span><span class="sxs-lookup"><span data-stu-id="d9fb6-149">AQS examples</span></span>

<span data-ttu-id="d9fb6-150">各 AEP の種類には、列挙の対象を特定のプロトコルに制限できるプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-150">Each AEP kind has a property you can use to constrain your enumeration to a specific protocol.</span></span> <span data-ttu-id="d9fb6-151">複数のプロトコルを組み合わせるには、AQS フィルターで OR 演算子を使えることを覚えておいてください。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-151">Keep in mind you can use the OR operator in an AQS filter to combine multiple protocols.</span></span> <span data-ttu-id="d9fb6-152">AEP デバイスの照会方法を示した AQS フィルター文字列の例を以下に紹介します。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-152">Here are some examples of AQS filter strings that show how to query for AEP devices.</span></span>

<span data-ttu-id="d9fb6-153">次の AQS は、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) が **AsssociationEndpoint** に設定されている場合に、すべての UPnP **AssociationEndpoint** オブジェクトを照会します。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-153">This AQS queries for all UPnP **AssociationEndpoint** objects when the [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) is set to **AsssociationEndpoint**.</span></span>

``` syntax
System.Devices.Aep.ProtocolId:="{0e261de4-12f0-46e6-91ba-428607ccef64}"
```

<span data-ttu-id="d9fb6-154">次の AQS は、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) が **AsssociationEndpoint** に設定されている場合に、すべての UPnP および WSD **AssociationEndpoint** オブジェクトを照会します。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-154">This AQS queries for all UPnP and WSD **AssociationEndpoint** objects when the [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) is set to **AsssociationEndpoint**.</span></span>

``` syntax
System.Devices.Aep.ProtocolId:="{782232aa-a2f9-4993-971b-aedc551346b0}" OR
System.Devices.Aep.ProtocolId:="{0e261de4-12f0-46e6-91ba-428607ccef64}"
```

<span data-ttu-id="d9fb6-155">次の AQS は、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) が **AsssociationEndpointService** に設定されている場合に、すべての UPnP **AssociationEndpointService** オブジェクトを照会します。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-155">This AQS queries for all UPnP **AssociationEndpointService** objects if the [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) is set to **AsssociationEndpointService**.</span></span>

``` syntax
System.Devices.AepService.ProtocolId:="{0e261de4-12f0-46e6-91ba-428607ccef64}"
```

<span data-ttu-id="d9fb6-156">次の AQS は、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) が **AssociationEndpointContainer** に設定されている場合に、**AssociationEndpointContainer** オブジェクトを照会しますが、UPnP プロトコルを列挙してオブジェクトを見つけるだけです。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-156">This AQS queries **AssociationEndpointContainer** objects when the [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) is set to **AssociationEndpointContainer**, but only finds them by enumerating the UPnP protocol.</span></span> <span data-ttu-id="d9fb6-157">通常、1 つのプロトコルのみが提供するコンテナーを列挙しても役に立ちません。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-157">Typically, it wouldn't be useful to enumerate containers that only come from one protocol.</span></span> <span data-ttu-id="d9fb6-158">しかし、デバイスを検出できることがわかっているプロトコルにフィルターを制限すると役に立つ場合もあります。</span><span class="sxs-lookup"><span data-stu-id="d9fb6-158">However, this might be useful by limiting your filter to protocols where you know your device can be discovered.</span></span>

``` syntax
System.Devices.AepContainer.ProtocolIds:~~"{0e261de4-12f0-46e6-91ba-428607ccef64}"
```

 

 
