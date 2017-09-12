---
author: mukin
ms.assetid: E0B9532F-1195-4927-99BE-F41565D891AD
title: "ネットワーク経由でデバイスを列挙する"
description: "Windows.Devices.Enumeration API を使うと、ローカル接続されたデバイスの検出だけでなく、ワイヤレス プロトコルおよびネットワーク プロトコル経由でデバイスを列挙できます。"
ms.author: mukin
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 4f7f6d9e7e92b7b40e23e835394b372358fb41f9
ms.sourcegitcommit: a2908889b3566882c7494dc81fa9ece7d1d19580
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/31/2017
---
# <a name="enumerate-devices-over-a-network"></a><span data-ttu-id="36c47-104">ネットワーク経由でデバイスを列挙する</span><span class="sxs-lookup"><span data-stu-id="36c47-104">Enumerate devices over a network</span></span>

<span data-ttu-id="36c47-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="36c47-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="36c47-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="36c47-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>


**<span data-ttu-id="36c47-107">重要な API</span><span class="sxs-lookup"><span data-stu-id="36c47-107">Important APIs</span></span>**

- [**<span data-ttu-id="36c47-108">Windows.Devices.Enumeration</span><span class="sxs-lookup"><span data-stu-id="36c47-108">Windows.Devices.Enumeration</span></span>**](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Enumeration)

<span data-ttu-id="36c47-109">[**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) API を使うと、ローカル接続されたデバイスの検出だけでなく、ワイヤレス プロトコルおよびネットワーク プロトコル経由でデバイスを列挙できます。</span><span class="sxs-lookup"><span data-stu-id="36c47-109">In addition to discovering locally connected devices, you can use the [**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) APIs to enumerate devices over wireless and networked protocols.</span></span>

## <a name="enumerating-devices-over-networked-or-wireless-protocols"></a><span data-ttu-id="36c47-110">ネットワーク プロトコルまたはワイヤレス プロトコルを経由したデバイスの列挙</span><span class="sxs-lookup"><span data-stu-id="36c47-110">Enumerating devices over networked or wireless protocols</span></span>

<span data-ttu-id="36c47-111">場合によっては、ローカル接続されていない、ワイヤレスまたはネットワーク プロトコル経由でのみ検出できるデバイスを列挙する必要があります。</span><span class="sxs-lookup"><span data-stu-id="36c47-111">Sometimes you need to enumerate devices that are not locally connected and can only be discovered over a wireless or networking protocols.</span></span> <span data-ttu-id="36c47-112">これを行うために、[**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) API には、**AssociationEndpoint** (AEP)、**AssociationEndpointContainer** (AEP コンテナー)、**AssociationEndpointService** (AEP サービス) という 3 つの異なる種類のデバイス オブジェクトがあります。</span><span class="sxs-lookup"><span data-stu-id="36c47-112">In order to do so, the [**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) APIs have three different kinds of device objects: the **AssociationEndpoint** (AEP), the **AssociationEndpointContainer** (AEP Container), and the **AssociationEndpointService** (AEP Service).</span></span> <span data-ttu-id="36c47-113">これらをまとめて AEP または AEP オブジェクトと呼びます。</span><span class="sxs-lookup"><span data-stu-id="36c47-113">As a group these are referred to as AEPs or AEP objects.</span></span>

<span data-ttu-id="36c47-114">一部のデバイス API には、使用可能な AEP オブジェクトを列挙するためのセレクター文字列が用意されています。</span><span class="sxs-lookup"><span data-stu-id="36c47-114">Some device APIs provide a selector string that you can use to enumerate through the available AEP objects.</span></span> <span data-ttu-id="36c47-115">これには、システムとペアリングされているデバイスとペアリングされていないデバイスの両方が含まれる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="36c47-115">This could include both devices that are paired and are not paired with the system.</span></span> <span data-ttu-id="36c47-116">中にはペアリングを必要としないデバイスもあります。</span><span class="sxs-lookup"><span data-stu-id="36c47-116">Some of the devices might not require pairing.</span></span> <span data-ttu-id="36c47-117">それらのデバイス API では、デバイスを操作する前にペアリングが必要な場合にペアリングが試行されることがあります。</span><span class="sxs-lookup"><span data-stu-id="36c47-117">Those device APIs may attempt to pair the device if pairing it is necessary before interacting with it.</span></span> <span data-ttu-id="36c47-118">たとえば、Wi-fi Direct はこのパターンに従っている API です。</span><span class="sxs-lookup"><span data-stu-id="36c47-118">Wi-Fi Direct is an example of APIs that follow this pattern.</span></span> <span data-ttu-id="36c47-119">それらのデバイス API でデバイスのペアリングが自動的に行われない場合は、[**DeviceInformation.Pairing**](https://msdn.microsoft.com/library/windows/apps/Dn705960) から取得できる [**DeviceInformationPairing**](https://msdn.microsoft.com/library/windows/apps/Mt168396) オブジェクトを使ってペアリングを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="36c47-119">If those device APIs do not automatically pair the device, you can pair it using the [**DeviceInformationPairing**](https://msdn.microsoft.com/library/windows/apps/Mt168396) object available from [**DeviceInformation.Pairing**](https://msdn.microsoft.com/library/windows/apps/Dn705960).</span></span>

<span data-ttu-id="36c47-120">しかし、あらかじめ定義されたセレクター文字列を使わずに手動でデバイスを検出する必要がある場合もあります。</span><span class="sxs-lookup"><span data-stu-id="36c47-120">However, there may be cases where you want to manually discover devices on your own without using a pre-defined selector string.</span></span> <span data-ttu-id="36c47-121">たとえば、AEP デバイスを操作する必要はなく情報の収集のみが必要な場合や、あらかじめ定義されたセレクター文字列で検出されるより多くの AEP オブジェクトを検索する必要がある場合などが考えられます。</span><span class="sxs-lookup"><span data-stu-id="36c47-121">For example, you may just need to gather information about AEP devices without interacting with them or you may want to find more AEP objects than will be discovered with the pre-defined selector string.</span></span> <span data-ttu-id="36c47-122">その場合は、「[デバイス セレクターのビルド](build-a-device-selector.md)」の手順に従って、独自のセレクター文字列を作成して使います。</span><span class="sxs-lookup"><span data-stu-id="36c47-122">In this case, you will build your own selector string and use it following the instructions under [Build a device selector](build-a-device-selector.md).</span></span>

<span data-ttu-id="36c47-123">独自のセレクターを作成する場合は、列挙する範囲を対象プロトコルに絞り込むことを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="36c47-123">When you build your own selector, it is strongly recommended that you limit your scope of enumeration to the protocols that you are interested in.</span></span> <span data-ttu-id="36c47-124">たとえば、UPnP デバイスのみを対象とする場合は、Wi-Fi Direct デバイスを検索する Wi-Fi 無線を設定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="36c47-124">For example, you don't want to have the Wi-Fi radio search for Wi-Fi Direct devices if you are particularly interested in UPnP devices.</span></span> <span data-ttu-id="36c47-125">Windows では、列挙範囲を指定するために使うことができるプロトコルの ID が定義されています。</span><span class="sxs-lookup"><span data-stu-id="36c47-125">Windows has defined an identity for each protocol that you can use to scope your enumeration.</span></span> <span data-ttu-id="36c47-126">次の表では、プロトコルのタイプと ID が一覧表示されています。</span><span class="sxs-lookup"><span data-stu-id="36c47-126">The following table lists the protocol types and identifiers.</span></span>

| <span data-ttu-id="36c47-127">プロトコルまたはネットワーク デバイスのタイプ</span><span class="sxs-lookup"><span data-stu-id="36c47-127">Protocol or network device type</span></span>              | <span data-ttu-id="36c47-128">ID</span><span class="sxs-lookup"><span data-stu-id="36c47-128">Id</span></span>                                         |
|----------------------------------------------|--------------------------------------------|
| <span data-ttu-id="36c47-129">UPnP (DIAL や DLNA など)</span><span class="sxs-lookup"><span data-stu-id="36c47-129">UPnP (including DIAL and DLNA)</span></span>               | **<span data-ttu-id="36c47-130">{0e261de4-12f0-46e6-91ba-428607ccef64}</span><span class="sxs-lookup"><span data-stu-id="36c47-130">{0e261de4-12f0-46e6-91ba-428607ccef64}</span></span>** |
| <span data-ttu-id="36c47-131">Web Services on Devices (WSD)</span><span class="sxs-lookup"><span data-stu-id="36c47-131">Web services on devices (WSD)</span></span>                | **<span data-ttu-id="36c47-132">{782232aa-a2f9-4993-971b-aedc551346b0}</span><span class="sxs-lookup"><span data-stu-id="36c47-132">{782232aa-a2f9-4993-971b-aedc551346b0}</span></span>** |
| <span data-ttu-id="36c47-133">Wi-Fi Direct</span><span class="sxs-lookup"><span data-stu-id="36c47-133">Wi-Fi Direct</span></span>                                 | **<span data-ttu-id="36c47-134">{0407d24e-53de-4c9a-9ba1-9ced54641188}</span><span class="sxs-lookup"><span data-stu-id="36c47-134">{0407d24e-53de-4c9a-9ba1-9ced54641188}</span></span>** |
| <span data-ttu-id="36c47-135">DNS サービス検出 (DNS-SD)</span><span class="sxs-lookup"><span data-stu-id="36c47-135">DNS service discovery (DNS-SD)</span></span>               | **<span data-ttu-id="36c47-136">{4526e8c1-8aac-4153-9b16-55e86ada0e54}</span><span class="sxs-lookup"><span data-stu-id="36c47-136">{4526e8c1-8aac-4153-9b16-55e86ada0e54}</span></span>** |
| <span data-ttu-id="36c47-137">Point of Service</span><span class="sxs-lookup"><span data-stu-id="36c47-137">Point of service</span></span>                             | **<span data-ttu-id="36c47-138">{d4bf61b3-442e-4ada-882d-fa7B70c832d9}</span><span class="sxs-lookup"><span data-stu-id="36c47-138">{d4bf61b3-442e-4ada-882d-fa7B70c832d9}</span></span>** |
| <span data-ttu-id="36c47-139">ネットワーク プリンター (Active Directory のプリンター)</span><span class="sxs-lookup"><span data-stu-id="36c47-139">Network printers (active directory printers)</span></span> | **<span data-ttu-id="36c47-140">{37aba761-2124-454c-8d82-c42962c2de2b}</span><span class="sxs-lookup"><span data-stu-id="36c47-140">{37aba761-2124-454c-8d82-c42962c2de2b}</span></span>** |
| <span data-ttu-id="36c47-141">Windows Connect Now (WNC)</span><span class="sxs-lookup"><span data-stu-id="36c47-141">Windows connect now (WNC)</span></span>                    | **<span data-ttu-id="36c47-142">{4c1b1ef8-2f62-4b9f-9bc5-b21ab636138f}</span><span class="sxs-lookup"><span data-stu-id="36c47-142">{4c1b1ef8-2f62-4b9f-9bc5-b21ab636138f}</span></span>** |
| <span data-ttu-id="36c47-143">WiGig ドック</span><span class="sxs-lookup"><span data-stu-id="36c47-143">WiGig docks</span></span>                                  | **<span data-ttu-id="36c47-144">{a277f3a5-8764-4f88-8045-4c5e962640b1}</span><span class="sxs-lookup"><span data-stu-id="36c47-144">{a277f3a5-8764-4f88-8045-4c5e962640b1}</span></span>** |
| <span data-ttu-id="36c47-145">HP プリンター用の Wi-Fi プロビジョニング</span><span class="sxs-lookup"><span data-stu-id="36c47-145">Wi-Fi provisioning for HP printers</span></span>           | **<span data-ttu-id="36c47-146">{c85ef710-f344-4792-bb6d-85a4346f1e69}</span><span class="sxs-lookup"><span data-stu-id="36c47-146">{c85ef710-f344-4792-bb6d-85a4346f1e69}</span></span>** |
| <span data-ttu-id="36c47-147">Bluetooth</span><span class="sxs-lookup"><span data-stu-id="36c47-147">Bluetooth</span></span>                                    | **<span data-ttu-id="36c47-148">{e0cbf06c-cd8b-4647-bb8a-263b43f0f974}</span><span class="sxs-lookup"><span data-stu-id="36c47-148">{e0cbf06c-cd8b-4647-bb8a-263b43f0f974}</span></span>** |
| <span data-ttu-id="36c47-149">Bluetooth LE</span><span class="sxs-lookup"><span data-stu-id="36c47-149">Bluetooth LE</span></span>                                 | **<span data-ttu-id="36c47-150">{bb7bb05e-5972-42b5-94fc-76eaa7084d49}</span><span class="sxs-lookup"><span data-stu-id="36c47-150">{bb7bb05e-5972-42b5-94fc-76eaa7084d49}</span></span>** |

 

## <a name="aqs-examples"></a><span data-ttu-id="36c47-151">AQS の例</span><span class="sxs-lookup"><span data-stu-id="36c47-151">AQS examples</span></span>

<span data-ttu-id="36c47-152">各 AEP の種類には、列挙の対象を特定のプロトコルに制限できるプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="36c47-152">Each AEP kind has a property you can use to constrain your enumeration to a specific protocol.</span></span> <span data-ttu-id="36c47-153">複数のプロトコルを組み合わせるには、AQS フィルターで OR 演算子を使えることを覚えておいてください。</span><span class="sxs-lookup"><span data-stu-id="36c47-153">Keep in mind you can use the OR operator in an AQS filter to combine multiple protocols.</span></span> <span data-ttu-id="36c47-154">AEP デバイスの照会方法を示した AQS フィルター文字列の例を以下に紹介します。</span><span class="sxs-lookup"><span data-stu-id="36c47-154">Here are some examples of AQS filter strings that show how to query for AEP devices.</span></span>

<span data-ttu-id="36c47-155">次の AQS は、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) が **AsssociationEndpoint** に設定されている場合に、すべての UPnP **AssociationEndpoint** オブジェクトを照会します。</span><span class="sxs-lookup"><span data-stu-id="36c47-155">This AQS queries for all UPnP **AssociationEndpoint** objects when the [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) is set to **AsssociationEndpoint**.</span></span>

``` syntax
System.Devices.Aep.ProtocolId:="{0e261de4-12f0-46e6-91ba-428607ccef64}"
```

<span data-ttu-id="36c47-156">次の AQS は、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) が **AsssociationEndpoint** に設定されている場合に、すべての UPnP および WSD **AssociationEndpoint** オブジェクトを照会します。</span><span class="sxs-lookup"><span data-stu-id="36c47-156">This AQS queries for all UPnP and WSD **AssociationEndpoint** objects when the [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) is set to **AsssociationEndpoint**.</span></span>

``` syntax
System.Devices.Aep.ProtocolId:="{782232aa-a2f9-4993-971b-aedc551346b0}" OR
System.Devices.Aep.ProtocolId:="{0e261de4-12f0-46e6-91ba-428607ccef64}"
```

<span data-ttu-id="36c47-157">次の AQS は、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) が **AsssociationEndpointService** に設定されている場合に、すべての UPnP **AssociationEndpointService** オブジェクトを照会します。</span><span class="sxs-lookup"><span data-stu-id="36c47-157">This AQS queries for all UPnP **AssociationEndpointService** objects if the [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) is set to **AsssociationEndpointService**.</span></span>

``` syntax
System.Devices.AepService.ProtocolId:="{0e261de4-12f0-46e6-91ba-428607ccef64}"
```

<span data-ttu-id="36c47-158">次の AQS は、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) が **AssociationEndpointContainer** に設定されている場合に、**AssociationEndpointContainer** オブジェクトを照会しますが、UPnP プロトコルを列挙してオブジェクトを見つけるだけです。</span><span class="sxs-lookup"><span data-stu-id="36c47-158">This AQS queries **AssociationEndpointContainer** objects when the [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) is set to **AssociationEndpointContainer**, but only finds them by enumerating the UPnP protocol.</span></span> <span data-ttu-id="36c47-159">通常、1 つのプロトコルのみが提供するコンテナーを列挙しても役に立ちません。</span><span class="sxs-lookup"><span data-stu-id="36c47-159">Typically, it wouldn't be useful to enumerate containers that only come from one protocol.</span></span> <span data-ttu-id="36c47-160">しかし、デバイスを検出できることがわかっているプロトコルにフィルターを制限すると役に立つ場合もあります。</span><span class="sxs-lookup"><span data-stu-id="36c47-160">However, this might be useful by limiting your filter to protocols where you know your device can be discovered.</span></span>

``` syntax
System.Devices.AepContainer.ProtocolIds:~~"{0e261de4-12f0-46e6-91ba-428607ccef64}"
```

 

 
