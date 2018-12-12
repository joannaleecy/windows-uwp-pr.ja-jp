---
ms.assetid: E0B9532F-1195-4927-99BE-F41565D891AD
title: ネットワーク経由でデバイスを列挙する
description: Windows.Devices.Enumeration API を使うと、ローカル接続されたデバイスの検出だけでなく、ワイヤレス プロトコルおよびネットワーク プロトコル経由でデバイスを列挙できます。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: e80d16b3338291c756b543018812e9db1370a4ac
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8944910"
---
# <a name="enumerate-devices-over-a-network"></a>ネットワーク経由でデバイスを列挙する



**重要な API**

- [**Windows.Devices.Enumeration**](https://docs.microsoft.com/en-us/uwp/api/Windows.Devices.Enumeration)

[**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) API を使うと、ローカル接続されたデバイスの検出だけでなく、ワイヤレス プロトコルおよびネットワーク プロトコル経由でデバイスを列挙できます。

## <a name="enumerating-devices-over-networked-or-wireless-protocols"></a>ネットワーク プロトコルまたはワイヤレス プロトコルを経由したデバイスの列挙

場合によっては、ローカル接続されていない、ワイヤレスまたはネットワーク プロトコル経由でのみ検出できるデバイスを列挙する必要があります。 これを行うために、[**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459) API には、**AssociationEndpoint** (AEP)、**AssociationEndpointContainer** (AEP コンテナー)、**AssociationEndpointService** (AEP サービス) という 3 つの異なる種類のデバイス オブジェクトがあります。 これらをまとめて AEP または AEP オブジェクトと呼びます。

一部のデバイス API には、使用可能な AEP オブジェクトを列挙するためのセレクター文字列が用意されています。 これには、システムとペアリングされているデバイスとペアリングされていないデバイスの両方が含まれる場合もあります。 中にはペアリングを必要としないデバイスもあります。 それらのデバイス API では、デバイスを操作する前にペアリングが必要な場合にペアリングが試行されることがあります。 たとえば、Wi-fi Direct はこのパターンに従っている API です。 それらのデバイス API でデバイスのペアリングが自動的に行われない場合は、[**DeviceInformation.Pairing**](https://msdn.microsoft.com/library/windows/apps/Dn705960) から取得できる [**DeviceInformationPairing**](https://msdn.microsoft.com/library/windows/apps/Mt168396) オブジェクトを使ってペアリングを行うことができます。

しかし、あらかじめ定義されたセレクター文字列を使わずに手動でデバイスを検出する必要がある場合もあります。 たとえば、AEP デバイスを操作する必要はなく情報の収集のみが必要な場合や、あらかじめ定義されたセレクター文字列で検出されるより多くの AEP オブジェクトを検索する必要がある場合などが考えられます。 その場合は、「[デバイス セレクターのビルド](build-a-device-selector.md)」の手順に従って、独自のセレクター文字列を作成して使います。

独自のセレクターを作成する場合は、列挙する範囲を対象プロトコルに絞り込むことを強くお勧めします。 たとえば、UPnP デバイスのみを対象とする場合は、Wi-Fi Direct デバイスを検索する Wi-Fi 無線を設定する必要はありません。 Windows では、列挙範囲を指定するために使うことができるプロトコルの ID が定義されています。 次の表では、プロトコルのタイプと ID が一覧表示されています。

| プロトコルまたはネットワーク デバイスのタイプ              | ID                                         |
|----------------------------------------------|--------------------------------------------|
| UPnP (DIAL や DLNA など)               | **{0e261de4-12f0-46e6-91ba-428607ccef64}** |
| Web Services on Devices (WSD)                | **{782232aa-a2f9-4993-971b-aedc551346b0}** |
| Wi-Fi Direct                                 | **{0407d24e-53de-4c9a-9ba1-9ced54641188}** |
| DNS サービス検出 (DNS-SD)               | **{4526e8c1-8aac-4153-9b16-55e86ada0e54}** |
| Point of Service                             | **{d4bf61b3-442e-4ada-882d-fa7B70c832d9}** |
| ネットワーク プリンター (Active Directory のプリンター) | **{37aba761-2124-454c-8d82-c42962c2de2b}** |
| Windows Connect Now (WNC)                    | **{4c1b1ef8-2f62-4b9f-9bc5-b21ab636138f}** |
| WiGig ドック                                  | **{a277f3a5-8764-4f88-8045-4c5e962640b1}** |
| HP プリンター用の Wi-Fi プロビジョニング           | **{c85ef710-f344-4792-bb6d-85a4346f1e69}** |
| Bluetooth                                    | **{e0cbf06c-cd8b-4647-bb8a-263b43f0f974}** |
| Bluetooth LE                                 | **{bb7bb05e-5972-42b5-94fc-76eaa7084d49}** |

 

## <a name="aqs-examples"></a>AQS の例

各 AEP の種類には、列挙の対象を特定のプロトコルに制限できるプロパティがあります。 複数のプロトコルを組み合わせるには、AQS フィルターで OR 演算子を使えることを覚えておいてください。 AEP デバイスの照会方法を示した AQS フィルター文字列の例を以下に紹介します。

次の AQS は、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) が **AsssociationEndpoint** に設定されている場合に、すべての UPnP **AssociationEndpoint** オブジェクトを照会します。

``` syntax
System.Devices.Aep.ProtocolId:="{0e261de4-12f0-46e6-91ba-428607ccef64}"
```

次の AQS は、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) が **AsssociationEndpoint** に設定されている場合に、すべての UPnP および WSD **AssociationEndpoint** オブジェクトを照会します。

``` syntax
System.Devices.Aep.ProtocolId:="{782232aa-a2f9-4993-971b-aedc551346b0}" OR
System.Devices.Aep.ProtocolId:="{0e261de4-12f0-46e6-91ba-428607ccef64}"
```

次の AQS は、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) が **AsssociationEndpointService** に設定されている場合に、すべての UPnP **AssociationEndpointService** オブジェクトを照会します。

``` syntax
System.Devices.AepService.ProtocolId:="{0e261de4-12f0-46e6-91ba-428607ccef64}"
```

次の AQS は、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/Dn948991) が **AssociationEndpointContainer** に設定されている場合に、**AssociationEndpointContainer** オブジェクトを照会しますが、UPnP プロトコルを列挙してオブジェクトを見つけるだけです。 通常、1 つのプロトコルのみが提供するコンテナーを列挙しても役に立ちません。 しかし、デバイスを検出できることがわかっているプロトコルにフィルターを制限すると役に立つ場合もあります。

``` syntax
System.Devices.AepContainer.ProtocolIds:~~"{0e261de4-12f0-46e6-91ba-428607ccef64}"
```

 

 
