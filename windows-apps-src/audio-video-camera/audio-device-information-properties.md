---
author: drewbatgit
ms.assetid: 3b75d881-bdcf-402b-a330-23cd29d68e53
description: "この記事では、オーディオ デバイスに関連する DeviceInformation プロパティを示します。"
title: "オーディオ デバイス情報プロパティ"
translationtype: Human Translation
ms.sourcegitcommit: 0745e96715ba49582ab762d4b25f1b8e681116f5
ms.openlocfilehash: 08ebb37679d1dd93458a3ffe846d8bd33574635d

---

# オーディオ デバイス情報プロパティ

この記事では、オーディオ デバイスに関連するデバイス情報プロパティを示します。 Windows では、ハードウェア デバイスにはそれぞれ [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/BR225393) プロパティが関連付けられており、デバイスについての特定の情報が必要な場合やデバイス セレクターを作成する場合に使うことができる、デバイスに関する詳細情報を提供します。 Windows でのデバイスの列挙に関する一般的な情報については、「[デバイスの列挙](../devices-sensors/enumerate-devices.md)」と「[デバイス情報プロパティ](../devices-sensors/device-information-properties.md)」をご覧ください。


|名前|型|説明|
|------------------------------------------------------------|------------|------------------------------------------------------|
|**System.Devices.AudioDevice.Microphone.SensitivityInDbfs**|Double|フルスケール (dBFS) 単位を基準としてマイクの感度を指定します。|
|**System.Devices.AudioDevice.Microphone.SignalToNoiseRationInDb**|Double|デシベル (dB) 単位で測定されたマイクの信号雑音比 (SNR) を指定します。|
|**System.Devices.AudioDevice.SpeechProcessingSupported**|Boolean|オーディオ デバイスが、音声処理をサポートするかどうかを示します。|
|**System.Devices.AudioDevice.RawProcessingSupported**|Boolean|オーディオ デバイスが、raw 処理をサポートするかどうかを示します。|
|**System.Devices.MicrophoneArray.Geometry**|unsigned char[]|マイク配列のジオメトリ データです。|

## 関連トピック

* [デバイスの列挙](../devices-sensors/enumerate-devices.md)
* [デバイス情報プロパティ](../devices-sensors/device-information-properties.md)
* [デバイス セレクターのビルド](../devices-sensors/build-a-device-selector.md)
* [メディア再生](media-playback.md)







<!--HONumber=Aug16_HO3-->


