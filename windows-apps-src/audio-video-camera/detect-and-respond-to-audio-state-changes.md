---
ms.assetid: EE0C1B28-EF9C-4BD9-A3C0-BDF11E75C752
description: この記事では、オーディオ ストリーム レベルがシステムによって変更された場合に、UWP アプリがそれを検出して対応する方法について説明します。
title: オーディオ状態の変化の検出と対応
ms.date: 04/03/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 69eeb82fd9a1e043e99b7fe0d635ca750779eda5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57631677"
---
# <a name="detect-and-respond-to-audio-state-changes"></a>オーディオ状態の変化の検出と対応
Windows 10、バージョン 1803 以降では、アプリが使用するオーディオ ストリームのオーディオ レベルが、システムによって低下した場合やミュートされた場合に、アプリがそれを検出できます。 特定のオーディオ デバイスとオーディオ カテゴリでは、キャプチャ ストリームとレンダリング ストリームについて通知を受け取ることができます。また [**MediaPlayer**](https://docs.microsoft.com/en-us/uwp/api/Windows.Media.Playback.MediaPlayer) オブジェクトは、アプリがメディア再生のために使用します。 たとえば、アラームが鳴っているときに、システムがオーディオ再生レベルを下げることがあります ("ダッキング" と呼ばれます)。 アプリ マニフェストで *backgroundMediaPlayback* 機能が宣言されていない場合、アプリがバックグラウンドに移動すると、システムによってアプリがミュートされます。 

オーディオ状態の変化を処理するパターンは、サポートされているすべてのオーディオ ストリームで共通です。 まず、[**AudioStateMonitor**](https://docs.microsoft.com/uwp/api/windows.media.audio.audiostatemonitor) クラスのインスタンスを作成します。 以下では、アプリが [**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture) クラスを使用して、ゲーム チャットのオーディオをキャプチャする例を示します。 ファクトリ メソッドが呼び出されて、既定の通信デバイスのゲーム チャットのオーディオ キャプチャー ストリームに関連付けられたオーディオ状態モニターが取得されます。  次に、[**SoundLevelChanged**](https://docs.microsoft.com/uwp/api/windows.media.audio.audiostatemonitor.soundlevelchanged) イベントのハンドラーを登録します。このイベントは、関連付けられたストリームのオーディオ レベルがシステムによって変更されたときに生成されます。

[!code-cs[DeviceIdCategoryVars](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetDeviceIdCategoryVars)]

[!code-cs[SoundLevelDeviceIdCategory](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetSoundLevelDeviceIdCategory)]

**SoundLevelChanged**イベント ハンドラー、チェック、 [ **SoundLevel** ](https://docs.microsoft.com/uwp/api/windows.media.audio.audiostatemonitor.soundlevel)のプロパティ、 **AudioStateMonitor**に送信者が渡される、ストリームの新しいオーディオ レベルを判断するハンドラー。 この例では、サウンド レベルがミュートされるとアプリがオーディオのキャプチャを停止し、オーディオ レベルがフル音量に戻ると、キャプチャが再開します。

[!code-cs[GameChatSoundLevelChanged](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetGameChatSoundLevelChanged)]

**MediaCapture** を使用してオーディオをキャプチャする方法について詳しくは、「[MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)」をご覧ください。

[  **MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer)クラスのすべてのインスタンスには、**AudioStateMonitor** が関連付けられており、現在再生中のコンテンツのボリューム レベルがシステムによって変更されたときに、それを検出するために使用できます。 再生されているコンテンツの種類に応じて、オーディオ状態の変化を異なる方法で処理することができます。 たとえば、ポッドキャストの場合は、オーディオが低下したときに再生を一時停止するが、コンテンツが音楽の場合は、再生を続行するように処理できます。 

[!code-cs[AudioStateVars](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetAudioStateVars)]

[!code-cs[SoundLevelChanged](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSoundLevelChanged)]

**MediaPlayer** の使い方について詳しくは、「[MediaPlayer を使ったオーディオとビデオの再生](play-audio-and-video-with-mediaplayer.md)」をご覧ください。 

## <a name="related-topics"></a>関連トピック