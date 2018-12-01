---
ms.assetid: D20C8E01-4E78-4115-A2E8-07BB3E67DDDC
description: この記事では、デバイスのライトにアクセスして使う方法を説明します (存在する場合)。 ライト機能は、デバイスのカメラやカメラのフラッシュ機能とは別に管理されます。
title: カメラに依存しない懐中電灯
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 5fd69900995a51af806c99b25aae43149d6e30a7
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8341113"
---
# <a name="camera-independent-flashlight"></a>カメラに依存しない懐中電灯



この記事では、デバイスのライトにアクセスして使う方法を説明します (存在する場合)。 ライト機能は、デバイスのカメラやカメラのフラッシュ機能とは別に管理されます。 この記事では、ライトへの参照の取得および設定の調整に加えて、使用されていないときにライトのリソースを正しく解放する方法と、ライトが別のアプリで使用されている場合に利用状況の変化を検出する方法も説明します。

## <a name="get-the-devices-default-lamp"></a>デバイスの既定のライトを取得する

デバイスの既定のライトを取得するには、[**Lamp.GetDefaultAsync**](https://msdn.microsoft.com/library/windows/apps/dn894327) を呼び出します。 ライト関連 API は、[**Windows.Devices.Lights**](https://msdn.microsoft.com/library/windows/apps/dn894331) 名前空間にあります。 これらの API にアクセスするには、この名前空間の using ディレクティブをあらかじめ追加しておく必要があります。

[!code-cs[LightsNamespace](./code/Lamp/cs/MainPage.xaml.cs#SnippetLightsNamespace)]


[!code-cs[DeclareLamp](./code/Lamp/cs/MainPage.xaml.cs#SnippetDeclareLamp)]


[!code-cs[GetDefaultLamp](./code/Lamp/cs/MainPage.xaml.cs#SnippetGetDefaultLamp)]

返されたオブジェクトが **null** の場合、そのデバイスでは **Lamp** API がサポートされていません。 一部のデバイスでは、ライトが物理的には存在していても、**Lamp** API がサポートされていないことがあります。

## <a name="get-a-specific-lamp-using-the-lamp-selector-string"></a>ライト セレクター文字列を使って特定のランプを取得する

デバイスによっては、複数のライトが組み込まれている場合があります。 デバイスで利用可能なライトの一覧を取得するには、[**GetDeviceSelector**](https://msdn.microsoft.com/library/windows/apps/dn894328) を呼び出すことによってデバイスのセレクター文字列を取得します。 このセレクター文字列は、[**DeviceInformation.FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/br225432) に渡すことができます。 これは、さまざまな種類の多数のデバイスを列挙するために使うメソッドです。セレクター文字列はこのメソッドに対し、ライト デバイスのみを返すように伝えます。 **FindAllAsync** から返される [**DeviceInformationCollection**](https://msdn.microsoft.com/library/windows/apps/br225395) オブジェクトは、デバイスで利用可能なライトを表す [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/br225393) オブジェクトのコレクションになります。 一覧からいずれかのオブジェクトを選択し、[**Id**](https://msdn.microsoft.com/library/windows/apps/br225437) プロパティを [**Lamp.FromIdAsync**](https://msdn.microsoft.com/library/windows/apps/dn894326) に渡すと、要求されたライトへの参照を取得できます。 この例では、**System.Linq** 名前空間の **GetFirstOrDefault** 拡張メソッドを使って、[**EnclosureLocation.Panel**](https://msdn.microsoft.com/library/windows/apps/br229906) プロパティの値が **Back** である **DeviceInformation** オブジェクトを選択しています。これにより、デバイス エンクロージャの背面にあるライトが選択されます (存在する場合)。

[**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/br225393) API は [**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/br225459) 名前空間にあります。

[!code-cs[EnumerationNamespace](./code/Lamp/cs/MainPage.xaml.cs#SnippetEnumerationNamespace)]

[!code-cs[GetLampWithSelectionString](./code/Lamp/cs/MainPage.xaml.cs#SnippetGetLampWithSelectionString)]

## <a name="adjust-lamp-settings"></a>ライトの設定を調整する

[**Lamp**](https://msdn.microsoft.com/library/windows/apps/dn894310) クラスのインスタンスを作成した後、[**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/dn894330) プロパティを **true** に設定することで、ライトをオンにします。

[!code-cs[LampSettingsOn](./code/Lamp/cs/MainPage.xaml.cs#SnippetLampSettingsOn)]

ライトをオフにするには、[**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/dn894330) プロパティを **false** に設定します。

[!code-cs[LampSettingsOff](./code/Lamp/cs/MainPage.xaml.cs#SnippetLampSettingsOff)]

デバイスによっては、ライトで色の値がサポートされていることがあります。 ライトで色がサポートされているかどうかを確認するには、[**IsColorSettable**](https://msdn.microsoft.com/library/windows/apps/dn894329) プロパティをチェックします。 この値が **true** であれば、[**Color**](https://msdn.microsoft.com/library/windows/apps/dn894322) プロパティを使ってライトの色を設定できます。

[!code-cs[LampSettingsColor](./code/Lamp/cs/MainPage.xaml.cs#SnippetLampSettingsColor)]

## <a name="register-to-be-notified-if-the-lamp-availability-changes"></a>ライトの利用状況が変化したら通知されるよう登録する

ライトへのアクセス権は、アクセスを要求した最新のアプリに付与されます。 このため、別のアプリが起動され、現在のアプリで使用中のライト リソースが要求された場合は、別のアプリからリソースが解放されるまで、現在のアプリではライトを制御できなくなります。 ライトの利用状況が変化したときに通知を受け取るには、[**Lamp.AvailabilityChanged**](https://msdn.microsoft.com/library/windows/apps/dn894317) イベントに対するハンドラーを登録します。

[!code-cs[AvailabilityChanged](./code/Lamp/cs/MainPage.xaml.cs#SnippetAvailabilityChanged)]

このイベントのハンドラーでは、[**LampAvailabilityChanged.IsAvailable**](https://msdn.microsoft.com/library/windows/apps/dn894315) プロパティをチェックして、ライトを使用できるかどうかを確認します。 この例では、ライトの利用可能性に基づいて、ライトをオンまたはオフにするトグル スイッチが有効または無効になります。

[!code-cs[AvailabilityChangedHandler](./code/Lamp/cs/MainPage.xaml.cs#SnippetAvailabilityChangedHandler)]

## <a name="properly-dispose-of-the-lamp-resource-when-not-in-use"></a>使用していないライト リソースを適切に破棄する

ライトの使用が終わったら、ライトを無効にして [**Lamp.Close**](https://msdn.microsoft.com/library/windows/apps/dn894320) を呼び出すことにより、他のアプリがライトにアクセスできるようリソースを解放する必要があります。 C# を使用している場合、このプロパティは **Dispose** メソッドにマップされています。 [**AvailabilityChanged**](https://msdn.microsoft.com/library/windows/apps/dn894317) に登録した場合は、ライト リソースを破棄するときにハンドラーの登録を解除する必要があります。 ライト リソースを破棄するコードの適切な場所は、アプリによって異なります。 ライト アクセスのスコープを単一のページに限定するには、リソースを [**OnNavigatingFrom**](https://msdn.microsoft.com/library/windows/apps/br227509) イベントで解放します。

[!code-cs[DisposeLamp](./code/Lamp/cs/MainPage.xaml.cs#SnippetDisposeLamp)]

## <a name="related-topics"></a>関連トピック
- [メディア再生](media-playback.md)

 




