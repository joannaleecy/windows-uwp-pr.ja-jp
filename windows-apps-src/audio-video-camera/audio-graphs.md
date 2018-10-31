---
author: drewbatgit
ms.assetid: CB924E17-C726-48E7-A445-364781F4CCA1
description: この記事では、Windows.Media.Audio 名前空間の API を使ってオーディオのルーティング、ミキシング、処理のシナリオでオーディオ グラフを作成する方法について説明します。
title: オーディオ グラフ
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: cdd1548a4d120027afd06a178cc338c88cb5cc4b
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5866048"
---
# <a name="audio-graphs"></a>オーディオ グラフ



この記事では、[**Windows.Media.Audio**](https://msdn.microsoft.com/library/windows/apps/dn914341) 名前空間の API を使ってオーディオのルーティング、ミキシング、処理のシナリオでオーディオ グラフを作成する方法について説明します。

*オーディオ グラフ*は、相互接続されたオーディオ ノードのセットです。オーディオ データは、ここを通って流れます。 

- *オーディオ入力ノード*は、オーディオ入力デバイス、オーディオ ファイル、またはカスタム コードから、オーディオ データをグラフに提供します。 

- *オーディオ出力ノード*は、グラフで処理されたオーディオの目的地です。 オーディオは、グラフからオーディオ出力デバイス、オーディオ ファイル、またはカスタム コードにルーティングできます。 

- *サブミックス ノード*は、1 つまたは複数のノードからのオーディオを結合して 1 つの出力にします。この出力は、グラフ内の他のノードにルーティングすることができます。 

すべてのノードが作成され、ノード間の接続が設定された後、オーディオ グラフを開始すると、オーディオ データが入力ノードからサブミックス ノードを通って出力ノードまで流れます。 このモデルでは、デバイスのマイクからオーディオ ファイルへの録音、ファイルからデバイスのスピーカーへのオーディオ再生、複数ソースからのオーディオ ミキシングなどのシナリオが、すばやく簡単に実装できるようになります。

オーディオ エフェクトをオーディオ グラフに追加することで、その他のシナリオも有効になります。 オーディオ グラフ内の各ノードには、ノードを通過するオーディオに対してオーディオ処理を実行するオーディオ エフェクトを 0 個以上設定できます。 エコー、イコライザー、リミッティング、リバーブなど、いくつかの組み込みエフェクトがあり、これらはわずか数行のコードでオーディオ ノードにアタッチできます。 組み込みエフェクトとまったく同様に動作するカスタム オーディオ エフェクトを独自に作成することもできます。

> [!NOTE]
> [AudioGraph UWP サンプル](http://go.microsoft.com/fwlink/?LinkId=619481)は、この概要で説明するコードを実装します。 サンプルをダウンロードすると、コンテキスト内のコードを確認できます。独自のアプリの出発点として使うこともできます。

## <a name="choosing-windows-runtime-audiograph-or-xaudio2"></a>Windows ランタイム AudioGraph または XAudio2 の選択

Windows ランタイム オーディオ グラフ API で提供される機能は、COM ベースの [XAudio2 API](https://msdn.microsoft.com/library/windows/desktop/hh405049) を使って実装することもできます。 XAudio2 とは異なる Windows ランタイム オーディオ グラフ フレームワークの特徴を次に示します。

Windows ランタイム オーディオ グラフ API:

-   XAudio2 よりもずっと簡単です。
-   C++ 用にサポートされていますが、C# からも使用できます。
-   オーディオ ファイル (圧縮ファイル形式など) を使うことができます。 XAudio2 はオーディオ バッファーのみで動作します。ファイル I/O 機能はありません。
-   Windows 10 では、低待機時間オーディオ パイプラインを使用できます。
-   既定のエンドポイント パラメーターの使用時にエンドポイントの自動切り替えをサポートします。 たとえば、ユーザーがデバイスのスピーカーからヘッドホンに切り替えると、オーディオが自動的に新しい入力にリダイレクトされます。

## <a name="audiograph-class"></a>AudioGraph クラス

[**AudioGraph**](https://msdn.microsoft.com/library/windows/apps/dn914176) クラスは、グラフを構成するすべてのノードの親です。 すべての種類のオーディオ ノードのインスタンス作成に、このオブジェクトを使います。 **AudioGraph** クラスのインスタンスを作成するには、[**AudioGraphSettings**](https://msdn.microsoft.com/library/windows/apps/dn914185) オブジェクトを初期化し、グラフの構成設定を含めて、[**AudioGraph.CreateAsync**](https://msdn.microsoft.com/library/windows/apps/dn914216) を呼び出します。 返された [**CreateAudioGraphResult**](https://msdn.microsoft.com/library/windows/apps/dn914273) により、作成されたオーディオ グラフへのアクセスが可能になります。オーディオ グラフの作成に失敗すると、エラー値が返されます。

[!code-cs[DeclareAudioGraph](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetDeclareAudioGraph)]

[!code-cs[InitAudioGraph](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetInitAudioGraph)]

-   オーディオ ノードのすべての種類は、**AudioGraph** クラスの Create\* メソッドで作成します。
-   [**AudioGraph.Start**](https://msdn.microsoft.com/library/windows/apps/dn914244) メソッドを呼び出すと、オーディオ グラフによってオーディオ データの処理が開始されます。 [**AudioGraph.Stop**](https://msdn.microsoft.com/library/windows/apps/dn914245) メソッドは、オーディオ処理を停止します。 グラフの実行中、グラフ内の各ノードは個別に開始および停止できますが、グラフが停止すると、すべてのノードが非アクティブになります。 [**ResetAllNodes**](https://msdn.microsoft.com/library/windows/apps/dn914242) を呼び出すと、グラフ内のすべてのノードで、現在のオーディオ バッファー内にあるすべてのデータが破棄されます。
-   グラフで、オーディオ データの新しいクォンタムの処理が開始されると、[**QuantumStarted**](https://msdn.microsoft.com/library/windows/apps/dn914241) イベントが発生します。 クォンタムの処理が完了すると、[**QuantumProcessed**](https://msdn.microsoft.com/library/windows/apps/dn914240) イベントが発生します。

-   [**AudioGraphSettings**](https://msdn.microsoft.com/library/windows/apps/dn914185) プロパティのうち、必須であるのは [**AudioRenderCategory**](https://msdn.microsoft.com/library/windows/apps/dn297724) のみです。 この値を指定することにより、システムは指定されたカテゴリについてオーディオ パイプラインを最適化します。
-   オーディオ グラフのクォンタム サイズにより、同時に処理されるサンプルの数が決定します。 既定では、既定のサンプル レートのクォンタム サイズは 10 ミリ秒ベースです。 [**DesiredSamplesPerQuantum**](https://msdn.microsoft.com/library/windows/apps/dn914205) プロパティを設定することでカスタムのクォンタム サイズを指定する場合は、[**QuantumSizeSelectionMode**](https://msdn.microsoft.com/library/windows/apps/dn914208) プロパティを **ClosestToDesired** に設定しないと、指定した値が無視されます。 この値を使うと、指定した値にできる限り近いクォンタム サイズがシステムによって選択されます。 実際のクォンタム サイズを確認するには、**AudioGraph** の [**SamplesPerQuantum**](https://msdn.microsoft.com/library/windows/apps/dn914243) を作成後にチェックします。
-   オーディオ グラフの使用対象がファイルのみであり、オーディオ デバイスに出力する予定がない場合は、[**DesiredSamplesPerQuantum**](https://msdn.microsoft.com/library/windows/apps/dn914205) プロパティを設定せずに、既定のクォンタム サイズを使うことをお勧めします。
-   [**DesiredRenderDeviceAudioProcessing**](https://msdn.microsoft.com/library/windows/apps/dn958522) プロパティは、オーディオ グラフの出力に対してプライマリ レンダリング デバイスで実行される処理の量を決定します。 **Default** 設定を使うと、指定されたオーディオ レンダリング カテゴリに対してシステムが既定のオーディオ処理を使用できるようになります。 この処理により、一部のデバイス (特に、小型スピーカーが搭載されているモバイル デバイス) ではオーディオのサウンドが大幅に改善される場合があります。 **Raw** 設定を使うと、実行する信号処理の量を最小化してパフォーマンスを向上できることがありますが、一部のデバイスでは音質が低下する場合があります。
-   [**QuantumSizeSelectionMode**](https://msdn.microsoft.com/library/windows/apps/dn914208) が **LowestLatency** に設定されていると、オーディオ グラフは [**DesiredRenderDeviceAudioProcessing**](https://msdn.microsoft.com/library/windows/apps/dn958522) に対して自動的に **Raw** を使います。
- Windows 10、バージョン 1803 では、[**AudioGraphSettings.MaxPlaybackSpeedFactor**](https://docs.microsoft.com/uwp/api/windows.media.audio.audiographsettings.maxplaybackspeedfactor) プロパティを設定することで、[**AudioFileInputNode.PlaybackSpeedFactor**](https://docs.microsoft.com/uwp/api/windows.media.audio.audiofileinputnode.playbackspeedfactor) プロパティ、[**AudioFrameInputNode.PlaybackSpeedFactor**](https://docs.microsoft.com/uwp/api/windows.media.audio.audioframeinputnode.playbackspeedfactor) プロパティ、[**MediaSourceInputNode.PlaybackSpeedFactor**](https://docs.microsoft.com/uwp/api/windows.media.audio.mediasourceinputnode.playbackspeedfactor) プロパティに使用する最大値を設定できます。 オーディオ グラフが、1 より大きい再生速度係数をサポートしている場合、システムは、オーディオ データの十分なバッファーを維持するために、追加のメモリを割り当てる必要があります。 このため、**MaxPlaybackSpeedFactor** をアプリで必要な最小値に設定すると、アプリによるメモリ消費量が減少します。 アプリが、通常の速度でのみコンテンツを再生する場合は、MaxPlaybackSpeedFactor を 1 に設定することをお勧めします。
-   [**EncodingProperties**](https://msdn.microsoft.com/library/windows/apps/dn958523) は、グラフで使用されるオーディオ形式を決定します。 サポートされているのは 32 ビットの浮動小数点形式のみです。
-   [**PrimaryRenderDevice**](https://msdn.microsoft.com/library/windows/apps/dn958524) は、オーディオ グラフのプライマリ レンダリング デバイスを設定します。 このプロパティを設定しなかった場合は、既定のシステム デバイスが使われます。 プライマリ レンダリング デバイスは、グラフの他のノードのクォンタム サイズの計算に使われます。 システムにオーディオ レンダリング デバイスが存在しない場合、オーディオ グラフの作成は失敗します。

オーディオ グラフでは、既定のオーディオ レンダリング デバイスを使うことも、[**Windows.Devices.Enumeration.DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/br225393) クラスを使ってシステムで利用可能なオーディオ レンダリング デバイスの一覧を取得することもできます。これには、[**FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/br225432) を呼び出して、[**Windows.Media.Devices.MediaDevice.GetAudioRenderSelector**](https://msdn.microsoft.com/library/windows/apps/br226817) から返されるオーディオ レンダリング デバイス セレクターを渡します。 返された **DeviceInformation** オブジェクトのうちいずれかをプログラムで選択するか、ユーザーがデバイスを選択できるように UI を表示して、選択されたデバイスを [**PrimaryRenderDevice**](https://msdn.microsoft.com/library/windows/apps/dn958524) プロパティに設定します。

[!code-cs[EnumerateAudioRenderDevices](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetEnumerateAudioRenderDevices)]

##  <a name="device-input-node"></a>デバイス入力ノード

デバイス入力ノードは、システムに接続されているオーディオ キャプチャ デバイス (マイクなど) からオーディオを取得し、グラフに渡します。 システムの既定オーディオ キャプチャ デバイスを使う [**DeviceInputNode**](https://msdn.microsoft.com/library/windows/apps/dn914082) オブジェクトを作成するには、[**CreateDeviceInputNodeAsync**](https://msdn.microsoft.com/library/windows/apps/dn914218) を呼び出します。 [**AudioRenderCategory**](https://msdn.microsoft.com/library/windows/apps/dn297724) を指定すると、指定されたカテゴリのオーディオ パイプラインがシステムによって最適化されます。

[!code-cs[DeclareDeviceInputNode](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetDeclareDeviceInputNode)]


[!code-cs[CreateDeviceInputNode](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetCreateDeviceInputNode)]

デバイス入力ノードに特定のオーディオ キャプチャ デバイスを指定する場合は、[**Windows.Devices.Enumeration.DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/br225393) クラスを使ってシステムで利用可能なオーディオ キャプチャ デバイスの一覧を取得することもできます。これには、[**FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/br225432) を呼び出して、[**Windows.Media.Devices.MediaDevice.GetAudioRenderSelector**](https://msdn.microsoft.com/library/windows/apps/br226817) から返されるオーディオ レンダリング デバイス セレクターを渡します。 返された **DeviceInformation** オブジェクトのうちいずれかをプログラムで選択するか、ユーザーがデバイスを選択できるように UI を表示して、選択されたデバイスを [**CreateDeviceInputNodeAsync**](https://msdn.microsoft.com/library/windows/apps/dn914218) に渡します。

[!code-cs[EnumerateAudioCaptureDevices](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetEnumerateAudioCaptureDevices)]

##  <a name="device-output-node"></a>デバイス出力ノード

デバイス出力ノードは、オーディオをグラフからスピーカーやヘッドセットなどのオーディオ レンダリング デバイスにプッシュします。 [**DeviceOutputNode**](https://msdn.microsoft.com/library/windows/apps/dn914098) を作成するには、[**CreateDeviceOutputNodeAsync**](https://msdn.microsoft.com/library/windows/apps/dn958525) を呼び出します。 出力ノードでは、オーディオ グラフの [**PrimaryRenderDevice**](https://msdn.microsoft.com/library/windows/apps/dn958524) が使われます。

[!code-cs[DeclareDeviceOutputNode](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetDeclareDeviceOutputNode)]

[!code-cs[CreateDeviceOutputNode](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetCreateDeviceOutputNode)]

##  <a name="file-input-node"></a>ファイル入力ノード

ファイル入力ノードを使うと、データをオーディオ ファイルからグラフに渡すことができます。 [**AudioFileInputNode**](https://msdn.microsoft.com/library/windows/apps/dn914108) を作成するには、[**CreateFileInputNodeAsync**](https://msdn.microsoft.com/library/windows/apps/dn914226) を呼び出します。

[!code-cs[DeclareFileInputNode](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetDeclareFileInputNode)]


[!code-cs[CreateFileInputNode](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetCreateFileInputNode)]

-   ファイル入力ノードでは、ファイル形式として mp3、wav、wma、m4a がサポートされています。
-   ファイル内の再生開始位置にタイム オフセットを指定するには、[**StartTime**](https://msdn.microsoft.com/library/windows/apps/dn914130) プロパティを設定します。 このプロパティが null の場合は、ファイルの先頭が使用されます。 ファイル内の再生終了位置にタイム オフセットを指定するには、[**EndTime**](https://msdn.microsoft.com/library/windows/apps/dn914118) プロパティを設定します。 このプロパティが null の場合は、ファイルの末尾が使用されます。 開始時刻の値は、終了時刻の値より小さくする必要があります。また、終了時刻の値はオーディオ ファイルの長さを超えないように設定する必要があります。オーディオ ファイルの長さを確認するには、[**Duration**](https://msdn.microsoft.com/library/windows/apps/dn914116) プロパティの値をチェックします。
-   オーディオ ファイル内の位置をシークするには、[**Seek**](https://msdn.microsoft.com/library/windows/apps/dn914127) を呼び出し、ファイル内の再生位置の移動先にタイム オフセットを指定します。 指定された値は、[**StartTime**](https://msdn.microsoft.com/library/windows/apps/dn914130) から [**EndTime**](https://msdn.microsoft.com/library/windows/apps/dn914118) の範囲内である必要があります。 ノードの現在の再生位置を取得するには、読み取り専用の [**Position**](https://msdn.microsoft.com/library/windows/apps/dn914124) プロパティを使います。
-   オーディオ ファイルのループ処理を有効にするには、[**LoopCount**](https://msdn.microsoft.com/library/windows/apps/dn914120) プロパティを設定します。 この値は、null 以外であれば、初回の再生後にファイルが再生される回数を示します。 たとえば、**LoopCount** を 1 に設定すると、このファイルは合計 2 回再生されます。値を 5 に設定すると、ファイルは合計 6 回再生されます。 **LoopCount** を null に設定すると、ファイルが無限にループされます。 ループを停止するには、値を 0 に設定します。
-   オーディオ ファイルの再生速度を調整するには、[**PlaybackSpeedFactor**](https://msdn.microsoft.com/library/windows/apps/dn914123) を設定します。 値 1 は、ファイルの元の速度を示します、0.5 は半分の速度、2 は 2 倍の速度を示します。

##  <a name="mediasource-input-node"></a>MediaSource 入力ノード

[**MediaSource**](https://docs.microsoft.com/uwp/api/Windows.Media.Core.MediaSource) クラスは、さまざまなソースのメディアを参照するための一般的な方法を提供し、基になるメディア形式 (ディスク上のファイル、ストリーム、アダプティブ ストリーミング ネットワーク ソースなど) に関係なく、メディア データにアクセスするための一般的なモデルを公開します。 [**MediaSourceAudioInputNode](https://docs.microsoft.com/uwp/api/windows.media.audio.mediasourceaudioinputnode) ノードを使用すると、**MediaSource** からオーディオ グラフにオーディオ データを渡すことができます。 **MediaSourceAudioInputNode** を作成するには、[**CreateMediaSourceAudioInputNodeAsync**](https://docs.microsoft.com/uwp/api/windows.media.audio.audiograph.createmediasourceaudioinputnodeasync#Windows_Media_Audio_AudioGraph_CreateMediaSourceAudioInputNodeAsync_Windows_Media_Core_MediaSource_) を呼び出して、再生するコンテンツを表す **MediaSource** オブジェクトを渡します。 [* * CreateMediaSourceAudioInputNodeResult](https://docs.microsoft.com/uwp/api/windows.media.audio.createmediasourceaudioinputnoderesult) が返され、その [**Status**](https://docs.microsoft.com/uwp/api/windows.media.audio.createmediasourceaudioinputnoderesult.status) プロパティを確認すると、操作の状態を判断できます。 状態が **Success** の場合は、[**Node**](https://docs.microsoft.com/uwp/api/windows.media.audio.createmediasourceaudioinputnoderesult.node) プロパティにアクセスして、作成された **MediaSourceAudioInputNode ** を取得できます。 以下では、ネットワーク経由のコンテンツのストリーミングを表す AdaptiveMediaSource オブジェクトからノードを作成する例を示します。 **MediaSource** の使用方法について詳しくは、「[メディア項目、プレイリスト、トラック](media-playback-with-mediasource.md)」をご覧ください。 インターネット経由のストリーミング メディア コンテンツについて詳しくは、「[アダプティブ ストリーミング](adaptive-streaming.md)」をご覧ください。

[!code-cs[DeclareMediaSourceInputNode](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetDeclareMediaSourceInputNode)]

[!code-cs[CreateMediaSourceInputNode](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetCreateMediaSourceInputNode)]

再生が **MediaSource** コンテンツの最後に達したときに通知を受け取るには、[**MediaSourceCompleted**](https://docs.microsoft.com/uwp/api/windows.media.audio.mediasourceaudioinputnode.mediasourcecompleted) イベントのハンドラーを登録します。 

[!code-cs[RegisterMediaSourceCompleted](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetRegisterMediaSourceCompleted)]

[!code-cs[MediaSourceCompleted](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetMediaSourceCompleted)]

ディスクからファイルを再生した場合は、ほとんどが正常に完了しますが、ネットワーク ソースからストリームされたメディアは、ネットワーク接続状況の変化など、オーディオ グラフの制御の及ばない問題によって再生中に失敗することがあります。 **MediaSource** が再生中に再生できなくなった場合、オーディオ グラフで [**UnrecoverableErrorOccurred**](https://docs.microsoft.com/uwp/api/windows.media.audio.audiograph.unrecoverableerroroccurred) イベントが発生します。 このイベントのハンドラーを使用して、オーディオ グラフを停止および破棄すると、グラフを再初期化できるようになります。 

[!code-cs[RegisterUnrecoverableError](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetRegisterUnrecoverableError)]

[!code-cs[UnrecoverableError](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetUnrecoverableError)]

##  <a name="file-output-node"></a>ファイル出力ノード

ファイル出力ノードを使用すると、オーディオ データをグラフからオーディオ ファイルに渡すことができます。 [**AudioFileOutputNode**](https://msdn.microsoft.com/library/windows/apps/dn914133) を作成するには、[**CreateFileOutputNodeAsync**](https://msdn.microsoft.com/library/windows/apps/dn914227) を呼び出します。

[!code-cs[DeclareFileOutputNode](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetDeclareFileOutputNode)]


[!code-cs[CreateFileOutputNode](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetCreateFileOutputNode)]

-   ファイル出力ノードでは、ファイル形式として mp3、wav、wma、m4a がサポートされています。
-   [**AudioFileOutputNode.FinalizeAsync**](https://msdn.microsoft.com/library/windows/apps/dn914140) を呼び出す前に、[**AudioFileOutputNode.Stop**](https://msdn.microsoft.com/library/windows/apps/dn914144) を呼び出して、ノードの処理を停止する必要があります。そうしないと例外がスローされます。

##  <a name="audio-frame-input-node"></a>オーディオ フレーム入力ノード

オーディオ フレーム入力ノードでは、独自のコードで生成したオーディオ データをオーディオ グラフにプッシュすることができます。 これにより、カスタムのソフトウェア シンセサイザーを作成するなどのシナリオが可能になります。 [**AudioFrameInputNode**](https://msdn.microsoft.com/library/windows/apps/dn914147) を作成するには、[**CreateFrameInputNode**](https://msdn.microsoft.com/library/windows/apps/dn914230) を呼び出します。

[!code-cs[DeclareFrameInputNode](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetDeclareFrameInputNode)]


[!code-cs[CreateFrameInputNode](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetCreateFrameInputNode)]

オーディオ グラフでオーディオ データの次のクォンタムの処理を開始する準備ができると、[**FrameInputNode.QuantumStarted**](https://msdn.microsoft.com/library/windows/apps/dn958507) イベントが発生します。 カスタム生成したオーディオ データは、このイベントに対するハンドラー内で指定します。

[!code-cs[QuantumStarted](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetQuantumStarted)]

-   **QuantumStarted** イベント ハンドラーに渡された [**FrameInputNodeQuantumStartedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn958533) オブジェクトには [**RequiredSamples**](https://msdn.microsoft.com/library/windows/apps/dn958534) プロパティがあります。このプロパティは、クォンタムを処理するためにオーディオ グラフが必要とするサンプル数を示します。
-   オーディオ データを設定した [**AudioFrame**](https://msdn.microsoft.com/library/windows/apps/dn930871) オブジェクトをグラフに渡すには、[**AudioFrameInputNode.AddFrame**](https://msdn.microsoft.com/library/windows/apps/dn914148) を呼び出します。
- Windows 10、バージョン 1803 では、オーディオ データで **MediaFrameReader** を使用するための新しい API セットが導入されました。 これらの API を使用すると、メディア フレーム ソースから **AudioFrame** オブジェクトを取得し、それを **AddFrame** メソッドを使用して **FrameInputNode** に渡すことができます。 詳しくは、「[MediaFrameReader を使ったオーディオ フレームの処理](process-audio-frames-with-mediaframereader.md)」をご覧ください。
-   **GenerateAudioData** ヘルパー メソッドの実装例を下に示します。

[**AudioFrame**](https://msdn.microsoft.com/library/windows/apps/dn930871) にオーディオ データを設定するには、オーディオ フレームの基になるメモリ バッファーにアクセスできる必要があります。 これには、該当する名前空間に以下のコードを追加して、COM インターフェイス **IMemoryBufferByteAccess** を初期化する必要があります。

[!code-cs[ComImportIMemoryBufferByteAccess](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetComImportIMemoryBufferByteAccess)]

次のコードは、[**AudioFrame**](https://msdn.microsoft.com/library/windows/apps/dn930871) を作成し、オーディオ データを設定する **GenerateAudioData** ヘルパー メソッドの実装例を示しています。

[!code-cs[GenerateAudioData](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetGenerateAudioData)]

-   このメソッドは、Windows ランタイム型よりも低いレベルの RAW バッファーにアクセスするため、**unsafe** キーワードを使って宣言する必要があります。 また、Microsoft Visual Studio でアンセーフ コードのコンパイルを許可するようにプロジェクトを構成する必要があります。プロジェクトの **[プロパティ]** ページを開き、**[ビルド]** プロパティ ページをクリックして、**[アンセーフ コードの許可]** チェック ボックスをオンにしてください。
-   **Windows.Media** 名前空間で [**AudioFrame**](https://msdn.microsoft.com/library/windows/apps/dn930871) の新しいインスタンスを初期化するには、必要なバッファー サイズをコンストラクターに渡します。 バッファー サイズとは、サンプル数に各サンプルのサイズを掛けた値です。
-   オーディオ フレームの [**AudioBuffer**](https://msdn.microsoft.com/library/windows/apps/dn958454) を取得するには、[**LockBuffer**](https://msdn.microsoft.com/library/windows/apps/dn930878) を呼び出します。
-   オーディオ バッファーから [**IMemoryBufferByteAccess**](https://msdn.microsoft.com/library/windows/desktop/mt297505) COM インターフェイスのインスタンスを取得するには、[**CreateReference**](https://msdn.microsoft.com/library/windows/apps/dn958457) を呼び出します。
-   生のオーディオ バッファー データへのポインターを取得するには、[**IMemoryBufferByteAccess.GetBuffer**](https://msdn.microsoft.com/library/windows/desktop/mt297506) を呼び出してオーディオ データのサンプル データ型にキャストします。
-   オーディオ グラフへの提出用に、バッファーにデータを設定して [**AudioFrame**](https://msdn.microsoft.com/library/windows/apps/dn930871) を返します。

##  <a name="audio-frame-output-node"></a>オーディオ フレーム出力ノード

オーディオ フレーム出力ノードでは、独自に作成したカスタム コードを使い、オーディオ グラフからオーディオ データ出力を受信し、処理することができます。 サンプル シナリオでは、オーディオ出力に対して信号分析を実行します。 [**AudioFrameOutputNode**](https://msdn.microsoft.com/library/windows/apps/dn914166) を作成するには、[**CreateFrameOutputNode**](https://msdn.microsoft.com/library/windows/apps/dn914233) を呼び出します。

[!code-cs[DeclareFrameOutputNode](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetDeclareFrameOutputNode)]

[!code-cs[CreateFrameOutputNode](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetCreateFrameOutputNode)]

オーディオ グラフでオーディオ データのクォンタムの処理が開始すると、[**AudioGraph.QuantumStarted**](https://docs.microsoft.com/uwp/api/Windows.Media.Audio.AudioGraph.QuantumStarted) イベントが発生します。 オーディオ データには、このイベントのハンドラー内からアクセスすることができます。 

> [!NOTE]
> オーディオ フレームを一定間隔で、オーディオ グラフと同期させて取得する場合は、同期 **QuantumStarted** イベント ハンドラー内から [AudioFrameOutputNode.GetFrame](https://docs.microsoft.com/uwp/api/windows.media.audio.audioframeoutputnode.GetFrame) を呼び出します。 **QuantumProcessed** イベントは、オーディオ エンジンがオーディオ処理を完了した後、非同期的に発生するため、一定間隔でない可能性があります。 したがって、オーディオ フレーム データの同期処理に **QuantumProcessed** イベントを使用することはできません。

[!code-cs[SnippetQuantumStartedFrameOutput](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetQuantumStartedFrameOutput)]

-   オーディオ データを設定した [**AudioFrame**](https://msdn.microsoft.com/library/windows/apps/dn930871) オブジェクトをグラフから取得するには、[**GetFrame**](https://msdn.microsoft.com/library/windows/apps/dn914171) を呼び出します。
-   **ProcessFrameOutput** ヘルパー メソッドの実装例を下に示します。

[!code-cs[ProcessFrameOutput](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetProcessFrameOutput)]

-   上に示したオーディオ フレーム入力ノードの例と同様、基になっているオーディオ バッファーにアクセスするために、**IMemoryBufferByteAccess** COM インターフェイスを宣言して、アンセーフ コードが許可されるようにプロジェクトを構成する必要があります。
-   オーディオ フレームの [**AudioBuffer**](https://msdn.microsoft.com/library/windows/apps/dn958454) を取得するには、[**LockBuffer**](https://msdn.microsoft.com/library/windows/apps/dn930878) を呼び出します。
-   オーディオ バッファーから **IMemoryBufferByteAccess** COM インターフェイスのインスタンスを取得するには、[**CreateReference**](https://msdn.microsoft.com/library/windows/apps/dn958457) を呼び出します。
-   生のオーディオ バッファー データへのポインターを取得するには、**IMemoryBufferByteAccess.GetBuffer** を呼び出してオーディオ データのサンプル データ型にキャストします。

## <a name="node-connections-and-submix-nodes"></a>ノード接続とサブミックス ノード

すべての種類の入力ノードには **AddOutgoingConnection** メソッドがあります。このメソッドでは、そのノードで生成されたオーディオをメソッドに渡されたノードにルーティングします。 次の例では、[**AudioFileInputNode**](https://msdn.microsoft.com/library/windows/apps/dn914108) を [**AudioDeviceOutputNode**](https://msdn.microsoft.com/library/windows/apps/dn914098) に接続します。これは、デバイスのスピーカーでオーディオ ファイルを再生するための単純な設定です。

[!code-cs[AddOutgoingConnection1](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetAddOutgoingConnection1)]

入力ノードから別ノードへは、複数の接続を作成できます。 次の例では、[**AudioFileInputNode**](https://msdn.microsoft.com/library/windows/apps/dn914108) から [**AudioFileOutputNode**](https://msdn.microsoft.com/library/windows/apps/dn914133) への接続を追加しています。 ここで、オーディオ ファイルからのオーディオがデバイスのスピーカーで再生され、オーディオ ファイルにも出力されます。

[!code-cs[AddOutgoingConnection2](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetAddOutgoingConnection2)]

出力ノードでも、他のノードから複数の接続を受け取ることができます。 次の例では、[**AudioDeviceInputNode**](https://msdn.microsoft.com/library/windows/apps/dn914082) から [**AudioDeviceOutput**](https://msdn.microsoft.com/library/windows/apps/dn914098) ノードへの接続が作成されています。 この出力ノードには、ファイル入力ノードとデバイス入力ノードからの接続があるため、出力には両方のソースからのオーディオのミックスが含まれます。 **AddOutgoingConnection** には、接続を通過する信号のゲイン値を指定するためのオーバーロードが用意されています。

[!code-cs[AddOutgoingConnection3](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetAddOutgoingConnection3)]

出力ノードでは複数ノードからの接続を許容できますが、ミックスを出力に渡す前に、1 つ以上のノードからの信号の中間ミックスを作成することも検討してください。 たとえば、グラフ内のオーディオ信号のサブセットに対し、レベルの設定やエフェクトの適用を行うことができます。 そのためには、[**AudioSubmixNode**](https://msdn.microsoft.com/library/windows/apps/dn914247) を使用します。 サブミックス ノードには、1 つ以上の入力ノードまたは他のサブミックス ノードから接続することができます。 次の例では、[**AudioGraph.CreateSubmixNode**](https://msdn.microsoft.com/library/windows/apps/dn914236) で新しいサブミックス ノードを作成しています。 次に、ファイル入力ノードとフレーム出力ノードからサブミックス ノードへの接続が追加されています。 最後に、サブミックス ノードがファイル出力ノードに接続されています。

[!code-cs[CreateSubmixNode](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetCreateSubmixNode)]

## <a name="starting-and-stopping-audio-graph-nodes"></a>オーディオ グラフ ノードの開始と停止

[**AudioGraph.Start**](https://msdn.microsoft.com/library/windows/apps/dn914244) が呼び出されると、オーディオ グラフはオーディオ データの処理を開始します。 すべてのノードの種類に、個々のノードでデータの処理を開始または停止する **Start** メソッドと **Stop** メソッドが用意されています。 [**AudioGraph.Stop**](https://msdn.microsoft.com/library/windows/apps/dn914245) が呼び出されると、個々のノードの状態に関係なく、すべてのノードでのすべてのオーディオ処理が停止しますが、オーディオ グラフが停止している間も各ノードの状態が設定されることは考えられます。 たとえば、グラフの停止中に各ノードで **Stop** を呼び出してから **AudioGraph.Start** を呼び出した場合、個々のノードは停止状態のままです。

すべてのノードの種類には **ConsumeInput** プロパティが用意されています。これが false に設定されると、ノードではオーディオ処理を続行できますが、他のノードから入力されているオーディオ データの使用が停止されます。

すべてのノードの種類には **Reset** メソッドが用意されています。このメソッドが呼び出されると、ノードのバッファーにある現在のオーディオ データがすべて破棄されます。

## <a name="adding-audio-effects"></a>オーディオ エフェクトの追加

オーディオ グラフ API を使うと、グラフ内のすべての種類のノードに、オーディオ エフェクトを追加することができます。 個々の出力ノード、入力ノード、およびサブミックス ノードに追加できるオーディオ エフェクトの数に制限はありません (ハードウェア性能によってのみ制限されます)。次の例では、組み込みのエコー エフェクトをサブミックス ノードに追加する方法を示しています。

[!code-cs[AddEffect](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetAddEffect)]

-   すべてのオーディオ エフェクトには、[**IAudioEffectDefinition**](https://msdn.microsoft.com/library/windows/apps/dn608044) が実装されています。 すべてのノードには、そのノードに適用されたエフェクトの一覧を表す **EffectDefinitions** プロパティが用意されています。 エフェクトを追加するには、エフェクトの定義オブジェクトをこの一覧に追加します。
-   **Windows.Media.Audio** 名前空間には、複数のエフェクト定義クラスがあります。 次のようなクラスがあります。
    -   [**EchoEffectDefinition**](https://msdn.microsoft.com/library/windows/apps/dn914276)
    -   [**EqualizerEffectDefinition**](https://msdn.microsoft.com/library/windows/apps/dn914287)
    -   [**LimiterEffectDefinition**](https://msdn.microsoft.com/library/windows/apps/dn914306)
    -   [**ReverbEffectDefinition**](https://msdn.microsoft.com/library/windows/apps/dn914313)
-   [**IAudioEffectDefinition**](https://msdn.microsoft.com/library/windows/apps/dn608044) を実装する独自のオーディオ エフェクトを作成し、オーディオ グラフ内の任意のノードに適用することができます。
-   すべてのノードの種類には、**DisableEffectsByDefinition** メソッドが用意されています。このメソッドは、ノードの **EffectDefinitions** リストに含まれる、指定の定義を使って追加されたすべてのエフェクトを無効にします。 **EnableEffectsByDefinition** は、指定の定義を持つエフェクトを有効にします。

## <a name="spatial-audio"></a>空間オーディオ
Windows 10 バージョン 1607 以降、**AudioGraph** は空間オーディオをサポートしています。これにより、任意の入力またはサブミックス ノードからのオーディオが出力される 3D 空間内の場所を指定することができます。 また、オーディオ出力の形状や方向、ノードのオーディオのドップラー偏移に使用される速度を指定することや、距離に応じたオーディオの減衰を記述する減衰モデルを定義することもできます。 

エミッターを作成するには、最初に、エミッターから出力されるサウンドの形状を作成します。これには、円すい状または無指向性を指定できます。 [**AudioNodeEmitterShape**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Audio.AudioNodeEmitterShape) クラスは、これらの各形状を作成するための静的メソッドを提供します。 次に、減衰モデルを作成します。 これは、リスナーからの距離が増加するにつれて、エミッターからのオーディオの音量をどのように減少させるかを定義します。 [**CreateNatural**](https://msdn.microsoft.com/library/windows/apps/mt711740) メソッドは、距離二乗減衰モデルを使用してサウンドの自然減衰をエミュレートする減衰モデルを作成します。 最後に、[**AudioNodeEmitterSettings**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Audio.AudioNodeEmitterSettings) オブジェクトを作成します。 現時点では、このオブジェクトは、エミッターのオーディオの速度ベースのドップラー減衰を有効または無効にするためにのみ使用されます。 [**AudioNodeEmitter**](https://msdn.microsoft.com/library/windows/apps/mt694324.aspx) コンストラクターを呼び出して、作成した初期化オブジェクトを渡します。 既定では、エミッターは原点に置かれますが、エミッターの位置は [**Position**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Audio.AudioNodeEmitter.Position) プロパティで設定できます。

> [!NOTE]
> オーディオ ノード エミッターは、48 kHz のサンプル レートとモノラルでフォーマットされているオーディオのみを処理できます。 ステレオ オーディオや別のサンプル レートのオーディオを使用しようとすると、例外が発生します。

目的のノードの種類の作成メソッドをオーバーロードした作成メソッドを使用してオーディオ ノードを作成する場合、オーディオ ノードにエミッターを割り当てます。 この例では、[**CreateFileInputNodeAsync**](https://msdn.microsoft.com/library/windows/apps/dn914225) を使用して、指定されたファイルとノードに関連付ける [**AudioNodeEmitter**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Audio.AudioNodeEmitter) オブジェクトから、ファイル入力ノードを作成しています。

[!code-cs[CreateEmitter](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetCreateEmitter)]

グラフからのオーディオをユーザーに対して出力する [**AudioDeviceOutputNode**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Audio.AudioDeviceOutputNode) には、[**Listener**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Audio.AudioDeviceOutputNode.Listener) プロパティでアクセスできるリスナー オブジェクトがあります。このオブジェクトは、3D 空間でのユーザーの位置、向き、速度を表します。 グラフ内のすべてのエミッターの位置は、エミッター オブジェクトの位置と向きを基準とします。 既定では、リスナーは原点 (0,0,0) に位置し、Z 軸に沿って前向きですが、リスナーの位置と向きは、[**Position**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Audio.AudioNodeListener.Position) プロパティと [**Orientation**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Audio.AudioNodeListener.Orientation) プロパティを使って設定できます。

[!code-cs[Listener](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetListener)]

実行時にエミッターの位置、速度、方向を更新することで、3D 空間でのオーディオ ソースの動きをシミュレートすることができます。

[!code-cs[UpdateEmitter](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetUpdateEmitter)]

また、実行時にリスナー オブジェクトの位置、速度、向きを更新することで、3D 空間でのユーザーの動きをシミュレートすることができます。

[!code-cs[UpdateListener](./code/AudioGraph/cs/MainPage.xaml.cs#SnippetUpdateListener)]

既定では、空間オーディオは、リスナーを基準とするオーディオの形状、速度、位置に基づいてオーディオを減衰する、Microsoft の頭部伝達関数 (HRTF) アルゴリズムを使用して計算されます。 [**SpatialAudioModel**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Audio.AudioNodeEmitter.SpatialAudioModel) プロパティを **FoldDown** に設定することにより、単純なステレオ ミックス メソッドを使用して、正確性は下がるが、必要な CPU とメモリ リソースが少ない空間オーディオをシミュレートすることができます。

## <a name="see-also"></a>関連項目
- [メディア再生](media-playback.md)
 

 




