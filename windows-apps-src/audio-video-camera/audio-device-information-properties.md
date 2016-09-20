---
author: drewbatgit
ms.assetid: 3b75d881-bdcf-402b-a330-23cd29d68e53
description: "この記事では、オーディオ デバイスに関連する DeviceInformation プロパティを示します。"
title: "オーディオ デバイス情報プロパティ"
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: b1bcb5b005e82303884c2e096356d5a0f542b1e1

---

# オーディオ デバイス情報プロパティ

この記事では、オーディオ デバイスに関連するデバイス情報プロパティを示します。 Windows では、ハードウェア デバイスにはそれぞれ [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/BR225393) プロパティが関連付けられており、デバイスについての特定の情報が必要な場合やデバイス セレクターを作成する場合に使うことができる、デバイスに関する詳細情報を提供します。 Windows でのデバイスの列挙に関する一般的な情報については、「[**デバイスの列挙**](../devices-sensors/enumerate-devices.md)」と「[**デバイス情報プロパティ**](../devices-sensors/device-information-properties.md)」をご覧ください。


|名前|型|説明|
|------------------------------------------------------------|------------|------------------------------------------------------|
|**System.Devices.AudioDevice.SpeechProcessingSupported**|Boolean|オーディオ デバイスが、音声処理をサポートするかどうかを示します。|
|**System.Devices.AudioDevice.RawProcessingSupported**|Boolean|オーディオ デバイスが、raw 処理をサポートするかどうかを示します。|
|**System.Devices.MicrophoneArray.Geometry**|unsigned char[]|マイク配列のジオメトリ データです。|
## 関連トピック

* [**デバイスの列挙**](../devices-sensors/enumerate-devices.md)
* [**デバイス情報プロパティ**](../devices-sensors/device-information-properties.md)
* [**デバイス セレクターのビルド**](../devices-sensors/build-a-device-selector.md)







<!--HONumber=Jun16_HO4-->


