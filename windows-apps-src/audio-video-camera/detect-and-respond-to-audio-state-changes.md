---
author: drewbatgit
ms.assetid: EE0C1B28-EF9C-4BD9-A3C0-BDF11E75C752
description: この記事では、オーディオ ストリーム レベルがシステムによって変更された場合に、UWP アプリがそれを検出して対応する方法について説明します。
title: オーディオ状態の変化の検出と対応
ms.author: drewbat
ms.date: 04/03/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: c60fcd705acf2d0d1e3162e80bc1d85095aa0fb4
ms.sourcegitcommit: 310a4555fedd4246188a98b31f6c094abb33ec60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "5132248"
---
# <a name="detect-and-respond-to-audio-state-changes"></a><span data-ttu-id="cf421-104">オーディオ状態の変化の検出と対応</span><span class="sxs-lookup"><span data-stu-id="cf421-104">Detect and respond to audio state changes</span></span>
<span data-ttu-id="cf421-105">Windows 10、バージョン 1803 以降では、アプリが使用するオーディオ ストリームのオーディオ レベルが、システムによって低下した場合やミュートされた場合に、アプリがそれを検出できます。</span><span class="sxs-lookup"><span data-stu-id="cf421-105">Starting with Windows 10, version 1803, your app can detect when the system lowers or mutes the audio level of an audio stream your app is using.</span></span> <span data-ttu-id="cf421-106">特定のオーディオ デバイスとオーディオ カテゴリでは、キャプチャ ストリームとレンダリング ストリームについて通知を受け取ることができます。また [**MediaPlayer**](https://docs.microsoft.com/en-us/uwp/api/Windows.Media.Playback.MediaPlayer) オブジェクトは、アプリがメディア再生のために使用します。</span><span class="sxs-lookup"><span data-stu-id="cf421-106">You can receive notifications for capture and render streams, for a particular audio device and audio category, or for a [**MediaPlayer**](https://docs.microsoft.com/en-us/uwp/api/Windows.Media.Playback.MediaPlayer) object your app is using for media playback.</span></span> <span data-ttu-id="cf421-107">たとえば、アラームが鳴っているときに、システムがオーディオ再生レベルを下げることがあります ("ダッキング" と呼ばれます)。</span><span class="sxs-lookup"><span data-stu-id="cf421-107">For example, the system may lower, or "duck", the audio playback level when an alarm is ringing.</span></span> <span data-ttu-id="cf421-108">アプリ マニフェストで *backgroundMediaPlayback* 機能が宣言されていない場合、アプリがバックグラウンドに移動すると、システムによってアプリがミュートされます。</span><span class="sxs-lookup"><span data-stu-id="cf421-108">The system will mute your app when it goes into the background if your app has not declared the *backgroundMediaPlayback* capability in the app manifest.</span></span> 

<span data-ttu-id="cf421-109">オーディオ状態の変化を処理するパターンは、サポートされているすべてのオーディオ ストリームで共通です。</span><span class="sxs-lookup"><span data-stu-id="cf421-109">The pattern for handling audio state changes is the same for all supported audio streams.</span></span> <span data-ttu-id="cf421-110">まず、[**AudioStateMonitor**](https://docs.microsoft.comuwp/api/windows.media.audio.audiostatemonitor) クラスのインスタンスを作成します。</span><span class="sxs-lookup"><span data-stu-id="cf421-110">First, create an instance of the [**AudioStateMonitor**](https://docs.microsoft.comuwp/api/windows.media.audio.audiostatemonitor) class.</span></span> <span data-ttu-id="cf421-111">以下では、アプリが [**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture) クラスを使用して、ゲーム チャットのオーディオをキャプチャする例を示します。</span><span class="sxs-lookup"><span data-stu-id="cf421-111">In the following example, the app is using the [**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Capture.MediaCapture) class to capture audio for game chat.</span></span> <span data-ttu-id="cf421-112">ファクトリ メソッドが呼び出されて、既定の通信デバイスのゲーム チャットのオーディオ キャプチャー ストリームに関連付けられたオーディオ状態モニターが取得されます。</span><span class="sxs-lookup"><span data-stu-id="cf421-112">A factory method is called to get an audio state monitor associated with the game chat audio capture stream of the default communications device.</span></span>  <span data-ttu-id="cf421-113">次に、[**SoundLevelChanged**](https://docs.microsoft.com/uwp/api/windows.media.audio.audiostatemonitor.soundlevelchanged) イベントのハンドラーを登録します。このイベントは、関連付けられたストリームのオーディオ レベルがシステムによって変更されたときに生成されます。</span><span class="sxs-lookup"><span data-stu-id="cf421-113">Next, a handler is registered for the [**SoundLevelChanged**](https://docs.microsoft.com/uwp/api/windows.media.audio.audiostatemonitor.soundlevelchanged) event, which will be raised when the audio level for the associated stream is changed by the system.</span></span>

[!code-cs[DeviceIdCategoryVars](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetDeviceIdCategoryVars)]

[!code-cs[SoundLevelDeviceIdCategory](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetSoundLevelDeviceIdCategory)]

<span data-ttu-id="cf421-114">**SoundLevelChanged**イベント ハンドラーで、ストリームの新しいオーディオ レベルを確認する、ハンドラーに渡された**AudioStateMonitor**送信者の[**センダー**](https://docs.microsoft.com/uwp/api/windows.media.audio.audiostatemonitor.soundlevel)プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="cf421-114">In the **SoundLevelChanged** event handler, check the [**SoundLevel**](https://docs.microsoft.com/uwp/api/windows.media.audio.audiostatemonitor.soundlevel) property of the **AudioStateMonitor** sender passed into the handler to determine what the new audio level for the stream is.</span></span> <span data-ttu-id="cf421-115">この例では、サウンド レベルがミュートされるとアプリがオーディオのキャプチャを停止し、オーディオ レベルがフル音量に戻ると、キャプチャが再開します。</span><span class="sxs-lookup"><span data-stu-id="cf421-115">In this example, the app stops capturing audio when the sound level is muted and resumes capturing when the audio level returns to full volume.</span></span>

[!code-cs[GameChatSoundLevelChanged](./code/SimpleCameraPreview_Win10/cs/MainPage.xaml.cs#SnippetGameChatSoundLevelChanged)]

<span data-ttu-id="cf421-116">**MediaCapture** を使用してオーディオをキャプチャする方法について詳しくは、「[MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ](basic-photo-video-and-audio-capture-with-MediaCapture.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cf421-116">For more information on capturing audio with **MediaCapture**, see [Basic photo, video, and audio capture with MediaCapture](basic-photo-video-and-audio-capture-with-MediaCapture.md).</span></span>

<span data-ttu-id="cf421-117">[**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer)クラスのすべてのインスタンスには、**AudioStateMonitor** が関連付けられており、現在再生中のコンテンツのボリューム レベルがシステムによって変更されたときに、それを検出するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="cf421-117">Every instance of the [**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer) class has an **AudioStateMonitor** associated with it that you can use to detect when the system changes the volume level of the content currently being played.</span></span> <span data-ttu-id="cf421-118">再生されているコンテンツの種類に応じて、オーディオ状態の変化を異なる方法で処理することができます。</span><span class="sxs-lookup"><span data-stu-id="cf421-118">You may decide to handle audio state changes differently depending on what type of content is being played.</span></span> <span data-ttu-id="cf421-119">たとえば、ポッドキャストの場合は、オーディオが低下したときに再生を一時停止するが、コンテンツが音楽の場合は、再生を続行するように処理できます。</span><span class="sxs-lookup"><span data-stu-id="cf421-119">For example, you may decide to pause playback of a podcast when the audio is lowered, but continue playback if the content is music.</span></span> 

[!code-cs[AudioStateVars](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetAudioStateVars)]

[!code-cs[SoundLevelChanged](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSoundLevelChanged)]

<span data-ttu-id="cf421-120">**MediaPlayer** の使い方について詳しくは、「[MediaPlayer を使ったオーディオとビデオの再生](play-audio-and-video-with-mediaplayer.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cf421-120">For more information on using **MediaPlayer**, see [Play audio and video with MediaPlayer](play-audio-and-video-with-mediaplayer.md).</span></span> 

## <a name="related-topics"></a><span data-ttu-id="cf421-121">関連トピック</span><span class="sxs-lookup"><span data-stu-id="cf421-121">Related topics</span></span>