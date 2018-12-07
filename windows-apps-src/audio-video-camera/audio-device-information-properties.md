---
ms.assetid: 3b75d881-bdcf-402b-a330-23cd29d68e53
description: この記事では、オーディオ デバイスに関連する DeviceInformation プロパティを示します。
title: オーディオ デバイス情報のプロパティ
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 443bcc3c0280aca85de31d8c9f3704302432cb76
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8795255"
---
# <a name="audio-device-information-properties"></a>オーディオ デバイス情報のプロパティ

この記事では、オーディオ デバイスに関連するデバイス情報プロパティを示します。 Windows では、ハードウェア デバイスにはそれぞれ [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/BR225393) プロパティが関連付けられており、デバイスについての特定の情報が必要な場合やデバイス セレクターを作成する場合に使うことができる、デバイスに関する詳細情報を提供します。 Windows でのデバイスの列挙に関する一般的な情報については、「[デバイスの列挙](../devices-sensors/enumerate-devices.md)」と「[デバイス情報プロパティ](../devices-sensors/device-information-properties.md)」をご覧ください。


|名前|種類|説明|
|------------------------------------------------------------|------------|------------------------------------------------------|
|**System.Devices.AudioDevice.Microphone.SensitivityInDbfs**|Double|フルスケール (dBFS) 単位を基準としてマイクの感度を指定します。|
|**System.Devices.AudioDevice.Microphone.SignalToNoiseRatioInDb**|Double|デシベル (dB) 単位で測定されたマイクの信号雑音比 (SNR) を指定します。|
|**System.Devices.AudioDevice.SpeechProcessingSupported**|Boolean|オーディオ デバイスが、音声処理をサポートするかどうかを示します。|
|**System.Devices.AudioDevice.RawProcessingSupported**|Boolean|オーディオ デバイスが、raw 処理をサポートするかどうかを示します。|
|**System.Devices.MicrophoneArray.Geometry**|unsigned char[]|マイク配列のジオメトリ データです。|

## <a name="related-topics"></a>関連トピック

* [デバイスの列挙](../devices-sensors/enumerate-devices.md)
* [デバイス情報プロパティ](../devices-sensors/device-information-properties.md)
* [デバイス セレクターのビルド](../devices-sensors/build-a-device-selector.md)
* [メディア再生](media-playback.md)




