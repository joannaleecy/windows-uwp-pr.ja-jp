---
author: DBirtolo
ms.assetid: 4A4C2802-E674-4C04-8A6D-D7C1BBF1BD20
title: デバイス情報プロパティ
description: デバイスにはそれぞれ DeviceInformation プロパティが関連付けられており、特定の情報が必要な場合やデバイス セレクターを作成する場合に使うことができます。
---
# デバイス情報プロパティ

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


** 重要な API **

-   [**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/BR225459)

デバイスにはそれぞれ [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/BR225393) プロパティが関連付けられており、特定の情報が必要な場合やデバイス セレクターを作成する場合に使うことができます。 これらのプロパティを AQS フィルターとして指定して、列挙するデバイスを絞り込むことにより、指定した特徴を持つデバイスを見つけることができます。 また、各デバイスについて返される情報を指定するために使うこともできます。 これにより、アプリケーションに返されるデバイス情報を指定できます。

デバイス セレクターでの [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/BR225393) プロパティの使い方について詳しくは、「[デバイス セレクターのビルド](build-a-device-selector.md)」をご覧ください。 このトピックでは、情報プロパティを要求する方法や、一般的なプロパティとその目的を確認できます。

[
            **DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/BR225393) オブジェクトは、ID ([**DeviceInformation.Id**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation.id))、種類 ([**DeviceInformation.Kind**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.deviceinformation.kind.aspx))、プロパティ バック ([**DeviceInformation.Properties**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.deviceinformation.properties.aspx)) で構成されています。 **DeviceInformation** オブジェクトのその他のプロパティはすべて **Properties** プロパティ バッグから派生します。 たとえば、[**Name**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation.name) は **System.ItemNameDisplay** から派生します。 つまり、このプロパティ バッグには、その他のプロパティを決定するために必要な情報が常に含まれています。

## プロパティの要求

[
            **DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/BR225393) オブジェクトには、[**Id**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation.id) や [**Kind**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.deviceinformation.kind.aspx) などの基本的なプロパティがいくつか用意されていますが、ほとんどのプロパティは、[**Properties**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.deviceinformation.properties.aspx) の下にあるプロパティ バッグに格納されています。 このため、プロパティ バッグには、プロパティ バッグからプロパティを提供するのに使われるプロパティが含まれています。 たとえば、[System.ItemNameDisplay](https://msdn.microsoft.com/library/windows/desktop/Bb760770) を使うと、[**Name**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation.name) プロパティを提供できます。 これは、わかりやすい名前を持つ一般的な既知のプロパティの一例です。 このように、Windows はわかりやすい名前を付け、プロパティの照会を簡単にしています。

要求できるプロパティは、わかりやすい名前を持つ一般的なプロパティだけではありません。 基になる GUID とプロパティ ID (PID) を指定することで、個別のデバイスまたはドライバーによって提供されたカスタム プロパティも含め、利用可能なすべてのプロパティを要求できます。 カスタム プロパティの指定形式は「`{GUID} PID`」です。 たとえば、「`{744e3bed-3684-4e16-9f8a-07953a8bf2ab} 7`」のように指定します。

一部のプロパティは、[**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/BR225393kind) のすべてのオブジェクトで共通していますが、ほとんどのプロパティは特定の種類に固有です。 以下のセクションでは、**DeviceInformationKind** ごとに並べ替えた共通プロパティの一部を紹介しています。 さまざまな種類の関係性について詳しくは、「**DeviceInformationKind**」をご覧ください。

## DeviceInterface プロパティ

**DeviceInterface** は既定で最も一般的な [**DeviceInformationKind**](https://msdn.microsoft.com/library/windows/apps/BR225393kind) オブジェクトで、アプリのシナリオに使われます。 これは、デバイス API が別の特定の **DeviceInformationKind** を示さない限り使用すべきオブジェクトの種類です。

| 名前                                  | タイプ    | 説明                                                                                                                                                                                                                                                                                                                                                                                               |
|---------------------------------------|---------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **System.Devices.ContainerId**        | GUID    | この **DeviceInterface** を含む **Device** が含まれている **DeviceInformationKind.DeviceContainer** の ID。 この値を **DeviceInformationKind.DeviceContainer** と共に [**CreateFromIdAsync**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation.createfromidasync) に渡すと、適切なコンテナーを見つけることができます。                                                                                    |
| **System.Devices.InterfaceClassGuid** | GUID    | このインターフェイスが表すインターフェイス クラス GUID。                                                                                                                                                                                                                                                                                                                                                       |
| **System.Devices.DeviceInstanceId**   | 文字列  | 親 **DeviceInformationKind.Device** の ID。 この値を **DeviceInformationKind.Device** と共に [**CreateFromIdAsync**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation.createfromidasync) に渡すと、適切なデバイスを見つけることができます。                                                                                                                                                                   |
| **System.Devices.InterfaceEnabled**   | Boolean | インターフェイスが有効かどうかを示します。 [
              **DeviceInformation.IsEnabled**
            ](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation.isenabled) はこのプロパティから派生します。                                                                                                                                                                                                                                                           |
| **System.Devices.GlyphIcon**          | 文字列  | グリフのアイコン パス。                                                                                                                                                                                                                                                                                                                                                                                  |
| **System.Devices.IsDefault**          | Boolean | これが **System.Devices.InterfaceClassGuid** の既定のデバイスかどうかを示します。 これは主にプリンターに使われます。 オーディオの既定値が複数存在するため、これはオーディオでは機能しません。 オーディオの既定値を取得するには、[**GetDefaultAudioRenderId**](https://msdn.microsoft.com/library/windows/apps/BR226819) または [**GetDefaultAudioCaptureId**](https://msdn.microsoft.com/library/windows/apps/BR226818) を使います。 |
| **System.Devices.Icon**               | 文字列  | アイコンのパス。                                                                                                                                                                                                                                                                                                                                                                                                |
| **System.ItemNameDisplay**            | 文字列  | デバイス オブジェクトに最適な表示名。                                                                                                                                                                                                                                                                                                                                                              |

 

## デバイスのプロパティ

| 名前                                  | タイプ       | 説明                                                                                                                                                                                                                                                                              |
|---------------------------------------|------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **System.Devices.ClassGuid**          | GUID       | デバイスのインストール時に使われるデバイス クラス。 詳しくは、「[デバイス セットアップ クラス](https://msdn.microsoft.com/library/windows/hardware/Ff541509)」をご覧ください。                                                                                                                                                            |
| **System.Devices.CompatibleIds**      | 文字列\[\] | デバイスの互換性 ID。 Windows がデバイスにインストールする最適なドライバーを決める場合に、これらが使われます。 詳しくは、「[互換性 ID](https://msdn.microsoft.com/library/windows/hardware/Ff539950)」をご覧ください。                                                                                                |
| **System.Devices.ContainerId**        | GUID       | このデバイスを含む **DeviceInformationKind.DeviceContainer** の ID。 この値を **DeviceInformationKind.DeviceContainer** と共に [**CreateFromIdAsync**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation.createfromidasync) に渡すと、適切なコンテナーを見つけることができます。          |
| **System.Devices.DeviceCapabilities** | UInt32     | **CfgMgr32.h** で定義された CM\_DEVCAP\_X 機能フラグのビット単位の OR。 詳しくは、「[**DEVPKEY\_Device\_Capabilities**](https://msdn.microsoft.com/library/windows/hardware/Ff542373)」をご覧ください。                                                                                             |
| **System.Devices.DeviceHasProblem**   | Boolean    | デバイスには現在問題があり、正しく機能していないと考えられます。 ドライバーが古いか、見つからないか、無効である可能性があります。                                                                                                                                                |
| **System.Devices.DeviceInstanceId**   | 文字列     | デバイスの ID。 これは [**DeviceInformation.Id**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation.id) の値でもあります。                                                                                                                                                                       |
| **System.Devices.DeviceManufacturer** | 文字列     | デバイスの製造元。                                                                                                                                                                                                                                                          |
| **System.Devices.HardwareIds**        | 文字列\[\] | デバイスのハードウェア ID。 インストールに最適なドライバーを決める場合に、Windows がこれらの ID を使います。 デバイスのベンダーは、このプロパティを使ってアプリからデバイスを識別します。 詳しくは、「[ハードウェア ID](https://msdn.microsoft.com/library/windows/hardware/Ff546152)」をご覧ください。                                         |
| **System.Devices.Parent**             | 文字列     | 親デバイスの [**DeviceInformation.Id**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation.id)。 これは接続親であり、**DeviceContainer** 親ではありません。                                                                                                                                 |
| **System.Devices.Present**            | Boolean    | デバイスが現在存在し、利用できるかどうかを示します。                                                                                                                                                                                                                         |
| **System.ItemNameDisplay**            | 文字列     | このデバイス オブジェクトに最適な表示名。 この場合は、これがユーザーにとって最適な名前であるとは限りません。 関連付けられている **DeviceContainer** または **DeviceInterface** の **System.ItemNameDisplay** を参照すると、もっとわかりやすい名前が見つかる可能性があります。 |

 

## DeviceContainer プロパティ

| 名前                              | タイプ       | 説明                                                                                                                                                        |
|-----------------------------------|------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **System.Devices.Category**       | 文字列\[\] | デバイスが属しているカテゴリの説明の一覧。 この一覧で提供されるカテゴリは単数形です。 たとえば、「Display」、「Phone」、または「Audio device」です。  |
| **System.Devices.CategoryIds**    | 文字列\[\] | このデバイスが属しているカテゴリの一覧が含まれています。 たとえば、**Audio.Headphone**、**Display.Monitor**、または **Input.Gaming** です。                                  |
| **System.Devices.CateogryPlural** | 文字列\[\] | デバイスが属しているカテゴリの説明の一覧。 この一覧で提供されるカテゴリは複数形です。 たとえば、「Displays」、「Phones」、または「Audio devices」です。 |
| **System.Devices.CompatibleIds**  | 文字列\[\] | すべての **DeviceInformationKind.Device** 子オブジェクトの互換性 ID のコレクション。                                                                       |
| **System.Devices.Connected**      | Boolean    | デバイスが現在システムに接続されているかどうかを示します。                                                                                          |
| **System.Devices.GlyphIcon**      | 文字列     | グリフのアイコン パス。                                                                                                                                           |
| **System.Devices.HardwareIds**    | 文字列\[\] | すべての **DeviceInformationKind.Device** 子オブジェクトのハードウェア ID のコレクション。                                                                         |
| **System.Devices.Icon**           | 文字列     | アイコンのパス。                                                                                                                                                         |
| **System.Devices.LocalMachine**   | Boolean    | この **DeviceContainer** がシステム自体を示す場合は **True**、デバイスがシステム外部にある場合は **false**。                                              |
| **System.Devices.Manufacturer**   | 文字列     | デバイスの製造元。                                                                                                                                    |
| **System.Devices.ModelName**      | 文字列     | デバイス コンテナーのモデル名。                                                                                                                                |
| **System.Devices.Paired**         | Boolean    | **DeviceInformationKind.Device** 子オブジェクトのどれかが、現在システムとペアリングされたワイヤレス デバイスまたはネットワーク デバイスであるかどうかを示します。             |
| **System.ItemNameDisplay**        | 文字列     | このデバイスに最適な表示名。                                                                                                                             |

 

## DeviceInterfaceClass プロパティ

| 名前                       | タイプ   | 説明                            |
|----------------------------|--------|----------------------------------------|
| **System.ItemNameDisplay** | 文字列 | このデバイスに最適な表示名。 |

 

## AssociationEndpoint プロパティ

| 名前                                  | タイプ       | 説明                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
|---------------------------------------|------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **System.Devices.Aep.AepId**          | 文字列     | このデバイスの ID。 これは [**DeviceInformation.Id**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation.id) の値でもあります。                                                                                                                                                                                                                                                                                                                                                                        |
| **System.Devices.Aep.CanPair**        | Boolean    | デバイスがシステムとペアリングされているかどうかを示します。 [
              **DeviceInformationPairing.CanPair**
            ](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.deviceinformation.pairing.aspx_canpair) はこのプロパティから派生します。                                                                                                                                                                                                                                                                                                       |
| **System.Devices.Aep.Category**       | 文字列\[\] | デバイスが含まれるカテゴリ。 たとえば、プリンターやカメラです。                                                                                                                                                                                                                                                                                                                                                                                                             |
| **System.Devices.Aep.ContainerId**    | GUID       | **AssociationEndpointContainer** 親オブジェクトの ID。                                                                                                                                                                                                                                                                                                                                                                                                                          |
| **System.Devices.Aep.DeviceAddress**  | 文字列     | デバイスのアドレス。 デバイスがネットワーク デバイスの場合、これは IP アドレスです。                                                                                                                                                                                                                                                                                                                                                                                                  |
| **System.Devices.Aep.IsConnected**    | Boolean    | デバイスが現在システムに接続されているかどうかを示します。                                                                                                                                                                                                                                                                                                                                                                                                                          |
| **System.Devices.Aep.IsPaired**       | Boolean    | デバイスが現在ペアリングされているかどうかを示します。 [
              **DeviceInformationPairing.IsPaired**
            ](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.deviceinformation.pairing.aspx_ispaired) はこのプロパティから派生します。                                                                                                                                                                                                                                                                                                                      |
| **System.Devices.Aep.IsPresent**      | Boolean    | デバイスが現在存在するかどうか、つまり、デバイスが使用されていて、ネットワーク プロトコルまたはワイヤレス プロトコル経由で検出されているかどうかを示します。 デバイスとシステムをペアリングすると、デバイスはキャッシュされます。 この後、**AssociationEndpoint** オブジェクトを照会すると、デバイスは自動的に検出されます。 そのため、デバイスがクエリで検出されても、現在使用可能かどうかはわかりません。 したがって、このプロパティが重要になります。 |
| **System.Devices.Aep.Manufacturer**   | 文字列     | デバイスの製造元。                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| **System.Devices.Aep.ModelId**        | GUID       | デバイスのモデル ID。                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| **System.Devices.Aep.ModelName**      | 文字列     | デバイスのモデル名。                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| **System.Devices.Aep.ProtocolId**     | GUID       | この **AssocationEndpoint** デバイスの検出に使われたプロトコルを示します。                                                                                                                                                                                                                                                                                                                                                                                                            |
| **System.Devices.Aep.SignalStrength** | Int32      | デバイスのシグナルの強さ。 このプロパティは、一部のプロトコルにのみ適用されます。                                                                                                                                                                                                                                                                                                                                                                                                |
| **System.ItemNameDisplay**            | 文字列     | デバイスに最適な表示名。                                                                                                                                                                                                                                                                                                                                                                                                                                                  |

 

## AssociationEndpointContainer プロパティ

| 名前                                                | タイプ       | 説明                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
|-----------------------------------------------------|------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **System.Devices.AepContainer.Categories**          | 文字列\[\] | デバイスが含まれるカテゴリ。 たとえば、プリンターやカメラです。                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| **System.Devices.AepContainer.Children**            | 文字列\[\] | このコンテナーに格納される **AssocationEndpoint** オブジェクトの ID のコレクション。                                                                                                                                                                                                                                                                                                                                                                                                                                |
| **System.Devices.AepContainer.CanPair**             | Boolean    | 子 **AssociationEndpoint** デバイスのいずれかをシステムとペアリングできるかどうかを示します。 [
              **DeviceInformationPairing.CanPair**
            ](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.deviceinformation.pairing.aspx_canpair) はこのプロパティから派生します。                                                                                                                                                                                                                                                                                                       |
| **System.Devices.AepContainer.ContainerId**         | GUID       | このデバイスの ID。 これは [**DeviceInformation.Id**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation.id) の値ですが、GUID 形式の値でもあります。                                                                                                                                                                                                                                                                                                                                                                                            |
| **System.Devices.AepContainer.IsPaired**            | Boolean    | 子 **AssociationEndpoint** デバイスのいずれかが現在ペアリングされているかどうかを示します。 [
              **DeviceInformationPairing.IsPaired**
            ](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.deviceinformation.pairing.aspx_ispaired) はこのプロパティから派生します。                                                                                                                                                                                                                                                                                                                      |
| **System.Devices.AepContainer.IsPresent**           | Boolean    | 子 **AssociationEndpoint** デバイスのいずれかが現在存在するかどうか、つまり、デバイスが使用されていて、ネットワーク プロトコルまたはワイヤレス プロトコル経由で検出されているかどうかを示します。 デバイスとシステムをペアリングすると、デバイスはキャッシュされます。 この後、**AssociationEndpoint** オブジェクトを照会すると、デバイスは自動的に検出されます。 そのため、デバイスがクエリで検出されても、現在使用可能かどうかはわかりません。 したがって、このプロパティが重要になります。 |
| **System.Devices.AepContainer.Manufacturer**        | 文字列     | デバイスの製造元。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| **System.Devices.AepContainer.ModelIds**            | 文字列\[\] | デバイスのモデル ID の一覧。 各モデルは、文字列の形式の GUID です。                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
| **System.Devices.AepContainer.ModelName**           | 文字列     | デバイスのモデル名。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
| **System.Devices.AepContainer.ProtocolIds**         | GUID\[\]   | この **AssociationEndpointContainer** オブジェクトの構築に関係するプロトコル ID の一覧。 **AssociationEndpointContainer** デバイスは、同じ物理デバイスについてさまざまなプロトコルで検出された **AssociationEndpoint** デバイスをすべて集めて作成されることに注意してください。                                                                                                                                                                                                                           |
| **System.Devices.AepContainer.SupportedUriSchemes** | 文字列\[\] | このデバイスでサポートされているキャスト URI スキームの一覧。                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| **System.Devices.AepContainer.SupportsAudio**       | Boolean    | このデバイスがオーディオのキャストをサポートしているかどうかを示します。                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| **System.Devices.AepContainer.SupportsImages**      | Boolean    | このデバイスがイメージのキャストをサポートしているかどうかを示します。                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| **System.Devices.AepContainer.SupportsVideo**       | Boolean    | このデバイスがビデオのキャストをサポートしているかどうかを示します。                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| **System.ItemNameDisplay**                          | 文字列     | デバイスに最適な表示名。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |

 

## AssociationEndpointService プロパティ

| 名前                                            | タイプ    | 説明                                                                                                      |
|-------------------------------------------------|---------|------------------------------------------------------------------------------------------------------------------|
| **System.Devices.AepService.AepId**             | 文字列  | **AssociationEndpoint** 親オブジェクトの ID。                                                     |
| **System.Devices.AepService.ContainerId**       | GUID    | **AssociationEndpointContainer** 親オブジェクトの ID。                                            |
| **System.Devices.AepService.ParentAepIsPaired** | Boolean | **AssociationEndpoint** 親オブジェクトがシステムとペアリングしているかどうかを示します。                           |
| **System.Devices.AepService.ProtocolId**        | GUID    | このデバイスの検出に使われるプロトコルの ID。                                                           |
| **System.Devices.AepService.ServiceClassId**    | GUID    | このデバイスで表されるサービスの ID。                                                             |
| **System.Devices.AeoService.ServiceId**         | 文字列  | このサービスの ID。 これは [**DeviceInformation.Id**](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation.id) の値でもあります。 |
| **System.ItemNameDisplay**                      | 文字列  | このサービスに最適な表示名。                                                                           |

 

 

 






<!--HONumber=May16_HO2-->


