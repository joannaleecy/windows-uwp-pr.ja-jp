---
author: drewbatgit
ms.assetid: 58af5e9d-37a1-4f42-909c-db7cb02a0d12
description: この記事では、MediaPlayer を使ってユニバーサル Windows アプリでメディアを再生する方法を示します。
title: MediaPlayer を使ったオーディオとビデオの再生
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 6b83be1dee4e23fa6974e39fbfb0f9ce26529274
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5924659"
---
# <a name="play-audio-and-video-with-mediaplayer"></a>MediaPlayer を使ったオーディオとビデオの再生

この記事では、[**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer) クラスを使ってユニバーサル Windows アプリでメディアを再生する方法を示します。 Windows 10 バージョン 1607 で、メディア再生 API が大幅に強化されました。これには、バックグラウンド オーディオ向けの簡素化された単一プロセス設計、システム メディア トランスポート コントロール (SMTC) との自動統合、複数のメディア プレーヤーを同期する機能、Windows.UI.Composition サーフェスに対する機能、コンテンツでメディアの中断を作成およびスケジュールするための簡単なインターフェイスなどが含まれます。 これらの強化機能を活用できるように、メディアを再生するためのベスト プラクティスとして、メディア再生に **MediaElement** の代わりに **MediaPlayer** クラスを使うことが推奨されます。 軽量の XAML コントロールである [**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaPlayerElement) が導入され、XAML ページのメディア コンテンツをレンダリングできるようになりました。 **MediaElement** によって提供される再生コントロールと状態 API の多くは、新しい [**MediaPlaybackSession**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession) オブジェクトを通じて利用できるようになりました。 **MediaElement** は下位互換性をサポートするために今後も動作しますが、このクラスには新しい機能は追加されません。

この記事では、一般的なメディア再生アプリで使う **MediaPlayer** の機能について説明します。 **MediaPlayer** は、すべてのメディア項目のコンテナーとして [**MediaSource**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.MediaSource) クラスを使います。 このクラスを使うと、すべて同じインターフェイスを使って、ローカル ファイル、メモリ ストリーム、ネットワーク ソースなど、さまざまなソースからメディアを読み込んで再生できます。 [**MediaPlaybackItem**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItem) や [**MediaPlaybackList**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackList) など、**MediaSource** と共に使用できる上位レベルのクラスもあります。これらは、プレイリストや、複数のオーディオ、ビデオ、メタデータ トラックでメディア ソースを管理する機能など、より高度な機能を提供します。 **MediaSource** および関連 API について詳しくは、「[メディア項目、プレイリスト、トラック](media-playback-with-mediasource.md)」をご覧ください。

> [!NOTE] 
> Windows 10 N および Windows 10 KN エディションには、再生用の **MediaPlayer** を使用するために必要なメディア機能が含まれません。 これらの機能は手動でインストールすることができます。 詳細については、「[Windows 10 N エディションおよび Windows 10 KN エディション用の Media Feature Pack](https://support.microsoft.com/en-us/help/3010081/media-feature-pack-for-windows-10-n-and-windows-10-kn-editions)」を参照してください。

## <a name="play-a-media-file-with-mediaplayer"></a>MediaPlayer でメディア ファイルを再生する  
**MediaPlayer** を使った基本的なメディア再生は非常に簡単に実装できます。 まず、**MediaPlayer** クラスの新しいインスタンスを作成します。 アプリは、複数の **MediaPlayer** のインスタンスを同時にアクティブにすることができます。 次に、プレイヤーの [**Source**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.Source) プロパティを、[**MediaSource**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.MediaSource)、[**MediaPlaybackItem**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItem)、[**MediaPlaybackList**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackList) など、[**IMediaPlaybackSource**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.IMediaPlaybackSource) を実装するオブジェクトに設定します。 この例では、アプリのローカル ストレージにあるファイルから **MediaSource** が作成された後、**MediaPlaybackItem** がソースから作成されて、プレイヤーの **Source** プロパティに割り当てられます。

**MediaElement** とは異なり、**MediaPlayer** は既定では自動的に再生を開始しません。 再生を開始するには、[**Play**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.Play) を呼び出すか、[**AutoPlay**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.AutoPlay) プロパティを true に設定するか、またはユーザーが組み込みのメディア コントロールを使って再生を開始するのを待ちます。

[!code-cs[SimpleFilePlayback](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSimpleFilePlayback)]

アプリが **MediaPlayer** を使って実行されたときは、[**Close**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.Close) メソッド (C# で **Dispose** に投影される) を呼び出して、プレーヤーで使われるリソースをクリーンアップしてください。

[!code-cs[CloseMediaPlayer](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetCloseMediaPlayer)]

## <a name="use-mediaplayerelement-to-render-video-in-xaml"></a>MediaPlayerElement を使って XAML でビデオをレンダリングする
メディアを XAML で表示せずに **MediaPlayer** で再生することはできますが、多くのメディア再生アプリは XAML ページでメディアをレンダリングします。 これを行うには、軽量な [**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaPlayerElement) コントロールを使います。 **MediaElement** と同様に、**MediaPlayerElement** でも組み込みのトランスポート コントロールを表示するかどうかを指定することができます。

[!code-xml[MediaPlayerElementXAML](./code/MediaPlayer_RS1/cs/MainPage.xaml#SnippetMediaPlayerElementXAML)]

[**SetMediaPlayer**](https://msdn.microsoft.com/library/windows/apps/mt708764) を呼び出して、要素がバインドされている **MediaPlayer** インスタンスを設定することができます。

[!code-cs[SetMediaPlayer](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSetMediaPlayer)]

**MediaPlayerElement** での再生ソースを設定することもできます。その場合、要素は自動的に [**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaPlayerElement.MediaPlayer) プロパティを使ってアクセスできる新しい **MediaPlayer** インスタンスを作成します。

[!code-cs[GetPlayerFromElement](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetGetPlayerFromElement)]

> [!NOTE] 
> [**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManager.IsEnabled) を false に設定して、[**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer) の [**MediaPlaybackCommandManager**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManager) を無効にすると、**MediaPlayerElement** で提供される **MediaPlayer** と [**TransportControls**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaPlayerElement.TransportControls) の間のリンクが解除されます。このため組み込みトランスポート コントロールはプレーヤーの再生を自動的に制御しなくなります。 代わりに、独自のコントロールを実装して、**MediaPlayer** を制御する必要があります。

## <a name="common-mediaplayer-tasks"></a>MediaPlayer の一般的なタスク
このセクションでは、**MediaPlayer** の一部の機能の使用方法を示します。

### <a name="set-the-audio-category"></a>オーディオ カテゴリの設定
**MediaPlayer** の [**AudioCategory**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.AudioCategory) プロパティを [**MediaPlayerAudioCategory**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayerAudioCategory) 列挙値のいずれかの値に設定して、再生しているメディアの種類をシステムに知らせます。 ゲームでは、別のアプリケーションがバックグラウンドで音楽を再生する場合にゲームの音楽が自動的にミュートされるように、ゲームの音楽ストリームを **GameMedia** として分類してください。 音楽またはビデオ アプリケーションでは、ストリームの優先順位が **GameMedia** ストリームより高くなるように、ストリームを **Media** または **Movie** として分類してください。

[!code-cs[SetAudioCategory](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSetAudioCategory)]

### <a name="output-to-a-specific-audio-endpoint"></a>特定のオーディオ エンドポイントへの出力
既定では、**MediaPlayer** からのオーディオ出力はシステムの既定のオーディオ エンドポイントに送られますが、**MediaPlayer** が出力用に使う特定のオーディオ エンドポイントを指定することもできます。 下の例では、[**MediaDevice.GetAudioRenderSelector**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Devices.MediaDevice.GetAudioRenderSelector) がデバイスのオーディオ レンダリング カテゴリを一意に識別する文字列を返します。 次に、[**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/Windows.Devices.Enumeration.DeviceInformation) メソッドの [**FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Devices.Enumeration.DeviceInformation.FindAllAsync) を呼び出して、選択した種類の利用可能なデバイスの一覧を取得します。 プログラムを使ってどのデバイスを使うかを判断することも、返されたデバイスを [**ComboBox**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ComboBox) に追加してユーザーがデバイスを選択できるようにすることもできます。

[!code-cs[SetAudioEndpointEnumerate](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSetAudioEndpointEnumerate)]

デバイス コンボ ボックスの [**SelectionChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.Primitives.Selector.SelectionChanged) イベントで、**MediaPlayer** の [**AudioDevice**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.AudioDevice) プロパティが選択されたデバイスに設定されます。これは、**ComboBoxItem** の [**Tag**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.FrameworkElement.Tag) プロパティに格納されていました。

[!code-cs[SetAudioEndpontSelectionChanged](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSetAudioEndpontSelectionChanged)]

### <a name="playback-session"></a>再生セッション
この記事の前の方で説明したように、**MediaElement** クラスによって公開される関数の多くは [**MediaPlaybackSession**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession) クラスに移されました。 これには、現在の再生位置、プレーヤーが一時停止しているか再生中か、現在の再生速度など、プレーヤーの再生状態に関する情報が含まれています。 **MediaPlaybackSession** は、再生中のコンテンツの現在のバッファリングおよびダウンロードの状態や、現在再生中のビデオ コンテンツの自然なサイズと縦横比などの状態が変わったときに通知するイベントもいくつか提供します。

次の例は、コンテンツを 10 秒前にスキップするボタン クリック ハンドラーを実装する方法を示しています。 まず、プレイヤーの **MediaPlaybackSession** オブジェクトが [**PlaybackSession**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.PlaybackSession) プロパティで取得されます。 次に、[**Position**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession.Position) プロパティが現在の再生位置に 10 秒加えた位置に設定されます。

[!code-cs[SkipForwardClick](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSkipForwardClick)]

次の例は、セッションの [**PlaybackRate**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession.PlaybackRate) プロパティを設定して通常の再生速度と 2 倍の速度を切り替えるトグル ボタンを示しています。

[!code-cs[SpeedChecked](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSpeedChecked)]

Windows 10 バージョン 1803 以降では、**MediaPlayer** でビデオが表示される回転を 90 度単位で設定できます。

[!code-cs[SetRotation](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSetRotation)]

### <a name="detect-expected-and-unexpected-buffering"></a>予期されたバッファー処理と予期しないバッファー処理の検出
前のセクションで説明した **MediaPlaybackSession** オブジェクトでは、**[BufferingStarted](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacksession.BufferingStarted)** と **[BufferingEnded](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacksession.BufferingEnded)** という 2 つのイベントによって、現在再生中のメディアファイルが開始および停止した時点を検出します。 これにより、バッファー処理が行われていることを UI を更新の更新によってユーザーに表示できます。 初期バッファー処理は、メディア ファイルが最初に開かれたとき、またはユーザーが再生リスト内の新しい項目に切り替えたときに発生する予期されるバッファー処理です。 予期しないバッファー処理は、ネットワーク速度が低下したとき、またはコンテンツを提供するコンテンツ管理システムに、技術的な問題が起こった場合に発生する可能性があります。 RS3 以降では、**BufferingStarted** イベントを使用して、バッファー処理イベントが予期されたものか、それとも予期しないイベントであって、再生が中断されるのかを判断できます。 この情報は、アプリまたはメディア配信サービスのテレメトリ データとして使用できます。 

バッファー処理の状態通知を受け取るには、**BufferingStarted** イベントと **BufferingEnded** イベントのハンドラーを登録します。

[!code-cs[RegisterBufferingHandlers](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetRegisterBufferingHandlers)]

**BufferingStarted**イベント ハンドラーで、このイベントに渡されたイベント引数を **[MediaPlaybackSessionBufferingStartedEventArgs](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacksessionbufferingstartedeventargs)** オブジェクトにキャストし、**[IsPlaybackInterruption](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacksessionbufferingstartedeventargs.IsPlaybackInterruption)** プロパティを確認します。 この値が true の場合、イベントをトリガーしたバッファー処理は予期しないものであり、再生が中断されます。 そうでない場合は、予想された初期バッファー処理です。 

[!code-cs[BufferingHandlers](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetBufferingHandlers)]


### <a name="pinch-and-zoom-video"></a>ビデオのピンチおよびズーム
**MediaPlayer** では、ビデオ コンテンツの中にレンダリングするソースの四角形を指定して、効果的にビデオを拡大することができます。 指定する四角形は、正規化された四角形 (0,0,1,1) を基準とします。0,0 はフレームの左上、1,1 はフレームの全幅と全高です。 たとえば、ビデオを 4 分割した右上の領域がレンダリングされるようにズーム四角形を設定するには、四角形 (.5,0,.5,.5) を指定します。  ソースの四角形が正規化された四角形 (0,0,1,1) の内部にあるように値を確認することが重要です。 この範囲外の値を設定しようとすると、例外がスローされます。

マルチタッチ ジェスチャを使ってピンチおよびズームを実装するには、まずどのジェスチャをサポートするかを指定する必要があります。 この例では、拡大縮小と移動のジェスチャが要求されています。 サブスクライブしているジェスチャのいずれかが発生すると、[**ManipulationDelta**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.ManipulationDelta) イベントが発生します。 ズームをフレーム全体にリセットするために、[**DoubleTapped**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.DoubleTapped) イベントが使用されます。 

[!code-cs[RegisterPinchZoomEvents](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetRegisterPinchZoomEvents)]

次に、現在のズーム ソースの四角形を格納する **Rect** オブジェクトを宣言します。

[!code-cs[DeclareSourceRect](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetDeclareSourceRect)]

**ManipulationDelta** ハンドラーは、ズーム四角形の拡大縮小または移動を調整します。 デルタ スケールの値が 1 でない場合、それはユーザーがピンチ ジェスチャを実行したことを意味します。 値が 1 より大きい場合、コンテンツを拡大するにはソースの四角形を小さくする必要があります。 値が 1 より小さい場合、縮小するにはソースの四角形を大きくする必要があります。 新しいスケール値を設定する前に、結果の四角形がチェックされ、全体が (0,0,1,1) の範囲内にあることが確認されます。

スケール値が 1 の場合、移動ジェスチャが処理されます。 四角形は、ジェスチャのピクセル数をコントロールの幅と高さで割った値だけ移動されます。 ここでも、結果の四角形がチェックされ、(0,0,1,1) の範囲内にあることが確認されます。

最後に、**MediaPlaybackSession** の [**NormalizedSourceRect**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession.NormalizedSourceRect) が新たに調整された四角形に設定され、レンダリングするビデオ フレーム内の領域が指定されます。

[!code-cs[ManipulationDelta](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetManipulationDelta)]

[**DoubleTapped**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.UIElement.DoubleTapped) イベント ハンドラーで、ビデオ フレーム全体がレンダリングされるようにソースの四角形が (0,0,1,1) に戻されます。

[!code-cs[DoubleTapped](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetDoubleTapped)]

### <a name="handling-policy-based-playback-degradation"></a>ポリシーベースの再生品質低下の処理

状況によっては、システムが、パフォーマンスの問題ではなく、ポリシーに基づいて、メディア項目の再生品質を低下させることがあります。これは解像度の低下 (圧縮) などの形で行われます。 たとえば、符号なしのビデオ ドライバーを使用して再生されている場合、システムによってビデオが低下する可能性があります。 この場合、[**MediaPlaybackSession.GetOutputDegradationPolicyState**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacksession.getoutputdegradationpolicystate#Windows_Media_Playback_MediaPlaybackSession_GetOutputDegradationPolicyState) を呼び出して、このポリシーベースの低下が発生しているかどうか、また発生理由を判定した上で、ユーザーに通知し、またはテレメトリ目的で理由を記録することができます。

次の例では、プレイヤーが新しいメディア項目を開いたときに発生する **MediaPlayer.MediaOpened** イベントのハンドラーの実装を示します。 ハンドラーに渡された **MediaPlayer** に対して **GetOutputDegradationPolicyState**が呼び出されます。 [**VideoConstrictionReason**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacksessionoutputdegradationpolicystate.videoconstrictionreason#Windows_Media_Playback_MediaPlaybackSessionOutputDegradationPolicyState_VideoConstrictionReason) の値は、ビデオが圧縮されているポリシー上の理由を示します。 以下の例では、値が **None** 以外の場合、テレメトリの目的で低下理由をログに記録します。 この例ではまた、ビデオが圧縮されていて、いずれにしても高品位で表示されないときに、データ使用量を節減するために、現在再生中の **AdaptiveMediaSource** のビットレートを最低帯域幅に設定する方法が示されています。 **AdaptiveMediaSource** の使用方法について詳しくは、「[アダプティブ ストリーミング](adaptive-streaming.md)」をご覧ください。

[!code-cs[PolicyDegradation](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetPolicyDegradation)]
        
## <a name="use-mediaplayersurface-to-render-video-to-a-windowsuicomposition-surface"></a>MediaPlayerSurface を使って、Windows.UI.Composition サーフェスにビデオをレンダリングする
Windows 10 バージョン 1607 からは、**MediaPlayer** を使って [**ICompositionSurface**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Composition.ICompositionSurface) にビデオをレンダリングできるため、プレイヤーは [**Windows.UI.Composition**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Composition) 名前空間で API と相互運用することができます。 コンポジション フレームワークを使うと、XAML と低レベルの DirectX グラフィックス API の間のビジュアル レイヤーでグラフィックスを操作することができます。 これにより、任意の XAML コントロールにビデオをレンダリングするようなシナリオが可能になります。 コンポジション API の使い方について詳しくは、「[ビジュアル レイヤー](https://msdn.microsoft.com/windows/uwp/composition/visual-layer)」をご覧ください。

次の例に、ビデオ プレーヤーのコンテンツを [**Canvas**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.Canvas) コントロールにレンダリングする方法を示します。 この例でのメディア プレーヤー固有の呼び出しは、[**SetSurfaceSize**](https://msdn.microsoft.com/library/windows/apps/mt489968) と [**GetSurface**](https://msdn.microsoft.com/library/windows/apps/mt489963) です。 **SetSurfaceSize** は、コンテンツのレンダリングに割り当てるバッファのサイズをシステムに伝えます。 **GetSurface** は、引数として [**Compositor**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Composition.Compositor) を受け取り、[**MediaPlayerSurface**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayerSurface) クラスのインスタンスを取得します。 このクラスは、サーフェスを作成するために使われる **MediaPlayer** と **Compositor** へのアクセスを提供し、[**CompositionSurface**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayerSurface.CompositionSurface) プロパティを通じてサーフェス自体を公開します。

この例の残りのコードでは、ビデオをレンダリングする [**SpriteVisual**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Composition.SpriteVisual) を作成し、そのサイズをビジュアルを表示するキャンバス要素のサイズに設定します。 次に、[**MediaPlayerSurface**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayerSurface) から [**CompositionBrush**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Composition.CompositionBrush) が作成され、ビジュアルの [**Brush**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Composition.SpriteVisual.Brush) プロパティに割り当てられます。 そして、[**ContainerVisual**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Composition.ContainerVisual) が作成され、そのビジュアル ツリーの一番上に **SpriteVisual** が挿入されます。 最後に、[**SetElementChildVisual**](https://msdn.microsoft.com/library/windows/apps/mt608981) を呼び出してコンテナー ビジュアルを **Canvas** に割り当てます。

[!code-cs[Compositor](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetCompositor)]
        
## <a name="use-mediatimelinecontroller-to-synchronize-content-across-multiple-players"></a>MediaTimelineController を使って複数のプレイヤー全体でコンテンツを同期する
この記事で前に説明したように、アプリは複数の **MediaPlayer** オブジェクトを一度にアクティブにすることができます。 既定では、作成する **MediaPlayer** はそれぞれ独立して動作します。 コメント トラックからビデオへの同期などの一部のシナリオでは、複数のプレーヤーの状態、再生位置、および再生速度を同期することもできます。 Windows 10 バージョン 1607 以降では、[**MediaTimelineController**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.MediaTimelineController) クラスを使ってこの動作を実装できます。

### <a name="implement-playback-controls"></a>再生コントロールを実装する
次の例は、**MediaTimelineController** を使って **MediaPlayer** の 2 つのインスタンスを制御する方法を示しています。 まず、**MediaPlayer** の各インスタンスがインスタンス化され、**Source** がメディア ファイルに設定されます。 次に、新しい **MediaTimelineController** が作成されます。 **MediaPlayer** ごとに、[**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManager.IsEnabled) プロパティを false に設定することで、各プレーヤー関連付けられている [**MediaPlaybackCommandManager**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManager) が無効にされます。 次に、[**TimelineController**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.TimelineController) プロパティがタイムライン コント ローラー オブジェクトに設定されます。

[!code-cs[DeclareMediaTimelineController](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetDeclareMediaTimelineController)]

[!code-cs[SetTimelineController](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSetTimelineController)]

**注意** [**MediaPlaybackCommandManager**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManager) は、**MediaPlayer** とシステム メディア トランスポート コントロール (SMTC) の間の自動統合を提供しますが、この自動統合は **MediaTimelineController** で制御されるメディア プレイヤーでは使うことはできません。 そのため、プレーヤーのタイムライン コント ローラーを設定する前に、メディア プレイヤーのコマンド マネージャーを無効にする必要があります。 こうしないと、例外がスローされ、"オブジェクトの現在の状態により、メディア タイムライン コントローラーのアタッチがブロックされています。" というメッセージが表示されます。 メディア プレーヤーの SMTC との統合について詳しくは、「[システム メディア トランスポート コントロールとの統合](integrate-with-systemmediatransportcontrols.md)」をご覧ください。 **MediaTimelineController** 使っている場合は、SMTC を手動で制御できます。 詳しくは、「[システム メディア トランスポート コントロールの手動制御](system-media-transport-controls.md)」をご覧ください。

1 つ以上のメディア プレーヤーに **MediaTimelineController** をアタッチしている場合は、コント ローラーによって公開されているメソッドを使って再生状態を制御できます。 次の例では、[**Start**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.MediaTimelineController.Start) を呼び出して、メディアの開始部で関連付けられたすべてのメディア プレーヤーの再生を開始します。

[!code-cs[PlayButtonClick](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetPlayButtonClick)]

この例は、アタッチされたすべてのメディア プレーヤーの一時停止と再開を示しています。

[!code-cs[PauseButtonClick](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetPauseButtonClick)]

接続されているすべてのメディア プレーヤーを早送りするには、再生速度を 1 より大きい値に設定します。

[!code-cs[FastForwardButtonClick](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetFastForwardButtonClick)]

次の例は、**スライダー** コントロールを使って、接続されているメディア プレーヤーの 1 つのコンテンツの再生時間を基準としてタイムライン コント ローラーの現在の再生位置を表示する方法を示しています。 まず、新しい **MediaSource** が作成され、メディア ソースの [ **OpenOperationCompleted** ](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.MediaSource.OpenOperationCompleted) のハンドラーが登録されます。 

[!code-cs[CreateSourceWithOpenCompleted](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetCreateSourceWithOpenCompleted)]

**OpenOperationCompleted** ハンドラーは、メディア ソースのコンテンツの再生時間を検出する契機になります。 再生時間が決定されると、**Slider** コントロールの最大値がメディア項目の合計秒数に設定されます。 [**RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) の呼び出しの中で値を設定して、UI スレッドで実行されていることを確認します。

[!code-cs[DeclareDuration](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetDeclareDuration)]

[!code-cs[OpenCompleted](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetOpenCompleted)]

次に、タイムライン コント ローラーの [**PositionChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.MediaTimelineController.PositionChanged) イベントのハンドラーを登録します。 これは 1 秒間に 4 回程度、システムによって定期的に呼び出されます。

[!code-cs[RegisterPositionChanged](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetRegisterPositionChanged)]

**PositionChanged** のハンドラーで、タイムライン コント ローラーの現在位置を反映するようにスライダーの値が更新されます。

[!code-cs[PositionChanged](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetPositionChanged)]

### <a name="offset-the-playback-position-from-the-timeline-position"></a>タイムラインの位置から再生位置をオフセットする
場合によっては、タイムライン コント ローラーに関連付けられている 1 つ以上のメディア プレーヤーの再生位置に、他のプレーヤーからのオフセットを付けたいことがあります。 これを行うには、オフセットを付ける **MediaPlayer** オブジェクトの [ **TimelineControllerPositionOffset** ](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.TimelineControllerPositionOffset) プロパティを設定します。 次の例では、2 つのメディア プレーヤーのコンテンツの再生時間を使って、項目の長さを加えるか差し引くように 2 つのスライダー コントロールの最小値と最大値を設定しています。  

[!code-cs[OffsetSliders](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetOffsetSliders)]

各スライダーの [**ValueChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.Primitives.RangeBase.ValueChanged) イベントで、各プレーヤーの **TimelineControllerPositionOffset** が対応する値に設定されます。

[!code-cs[TimelineOffset](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetTimelineOffset)]

プレーヤーのオフセット値が負の再生位置にマップされる場合は、オフセットがゼロになるまでクリップは一時停止のままになり、その後に再生が開始されます。 同様に、オフセット値がメディア項目の再生時間を超える再生位置にマップされる場合は、1 つのメディア プレーヤーがそのコンテンツの最後に達したときのように最終フレームが表示されます。

## <a name="play-spherical-video-with-mediaplayer"></a>MediaPlayer を使った球面ビデオの再生
Windows 10 Version 1703 以降、**MediaPlayer** は、球面ビデオ再生のための正距円筒図法をサポートしています。 球面ビデオ コンテンツは、ビデオ エンコードがサポートされている限り、**MediaPlayer** がビデオを表示するという点において、通常の平面ビデオと同じです。 ビデオが正距円筒図法を使用することを指定するメタデータ タグを含む球面ビデオの場合、**MediaPlayer** は、指定された視野とビューの向きを使ってビデオを表示できます。 これにより、ヘッド マウント ディスプレイによる仮想現実ビデオの再生や、ユーザーがマウスまたはキーボード入力で球面ビデオ コンテンツ内でパンできるようにするなどのシナリオが実現されます。

球面ビデオを再生するには、この記事で既に説明したビデオ コンテンツを再生するための手順を使用します。 1 つ追加される手順は、[**MediaPlayer.MediaOpened**](https://docs.microsoft.com/uwp/api/Windows.Media.Playback.MediaPlayer#Windows_Media_Playback_MediaPlayer_MediaOpened) イベントのハンドラーを登録することです。 このイベントにより、球面ビデオの再生パラメーターが有効化され、制御できるようになります。

[!code-cs[OpenSphericalVideo](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetOpenSphericalVideo)]

**MediaOpened** ハンドラーで、最初に [**PlaybackSession.SphericalVideoProjection.FrameFormat**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacksphericalvideoprojection.FrameFormat) プロパティを調べて、新しく開かれたメディア項目のフレーム形式を確認します。 この値が [**SphericaVideoFrameFormat.Equirectangular**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.sphericalvideoframeformat) である場合、システムは自動的にビデオ コンテンツを投影できます。 最初に、[**PlaybackSession.SphericalVideoProjection.IsEnabled**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacksphericalvideoprojection.IsEnabled) プロパティを **true** に設定します。 メディア プレーヤーがビデオ コンテンツを投影する際に使用するビューの向きや視野などのプロパティを調整することもできます。 この例では、[**HorizontalFieldOfViewInDegrees**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacksphericalvideoprojection.HorizontalFieldOfViewInDegrees) プロパティを設定することによって、120 度という広い視野の値を設定しています。

ビデオ コンテンツが球面でも、正距円筒図法以外の形式である場合は、メディア プレーヤーのフレーム サーバー モードを使用して個々のフレームを受信し、処理することで、独自の投影アルゴリズムを実装できます。

[!code-cs[SphericalMediaOpened](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSphericalMediaOpened)]

次のコード例は、左右の方向キーを使って球面ビデオのビューの向きを調整する方法を示しています。

[!code-cs[SphericalOnKeyDown](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSphericalOnKeyDown)]

アプリでビデオの再生リストをサポートしている場合、UI で球面ビデオを含む再生項目の識別が必要になることがあります。 メディアの再生リストについて詳しくは、「[メディア項目、プレイリスト、トラック](media-playback-with-mediasource.md)」の記事をご覧ください。 次の例では、新しい再生リストの作成、項目の追加、[**MediaPlaybackItem.VideoTracksChanged**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem.VideoTracksChanged) イベント (メディア項目のビデオ トラックを解決するときに発生する) のハンドラーの登録の方法を示します。

[!code-cs[SphericalList](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSphericalList)]

**VideoTracksChanged**イベント ハンドラーで、[**VideoTrack.GetEncodingProperties**](https://docs.microsoft.com/uwp/api/windows.media.core.videotrack.GetEncodingProperties) を呼び出すことによって、追加されたビデオ トラックのエンコード プロパティを取得します。 エンコード プロパティの [**SphericalVideoFrameFormat**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.videoencodingproperties.SphericalVideoFrameFormat) プロパティが、[**SphericaVideoFrameFormat.None**](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.sphericalvideoframeformat) 以外の値である場合、ビデオ トラックには球面ビデオが含まれており、選択した場合は適切に UI を更新できます。

[!code-cs[SphericalTracksChanged](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSphericalTracksChanged)]

## <a name="use-mediaplayer-in-frame-server-mode"></a>フレーム サーバー モードでの MediaPlayer の使用
Windows 10 Version 1703 以降では、フレーム サーバー モードで **MediaPlayer** を使用できます。 このモードでは、**MediaPlayer** は、関連付けられている **MediaPlayerElement** にフレームを自動的には表示しません。 代わりに、アプリが、**MediaPlayer** から [**IDirect3DSurface**](https://docs.microsoft.com/uwp/api/windows.graphics.directx.direct3d11.idirect3dsurface) を実装するオブジェクトに現在のフレームをコピーします。 この機能により実現される主要なシナリオは、**MediaPlayer** によって提供されるビデオ フレームをピクセル シェーダーを使用して処理することです。 処理後、アプリが XAML [**Image**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.image) コントロールでフレームを表示するなどの方法で、各フレームを表示します。

次の例では、新しい **MediaPlayer** が初期化され、ビデオ コンテンツが読み込まれます。 次に、[**VideoFrameAvailable**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer.VideoFrameAvailable) のハンドラーが登録されます。 **MediaPlayer** オブジェクトの [**IsVideoFrameServerEnabled**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer.IsVideoFrameServerEnabled) プロパティを **true** に設定することによって、フレーム サーバー モードが有効になります。 最後に、[**Play**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer.Play) の呼び出しによってメディアの再生が開始されます。

[!code-cs[FrameServerInit](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetFrameServerInit)]

次の例は、[Win2D](https://github.com/Microsoft/Win2D) を使用してビデオの各フレームに単純なぼかし効果を追加し、処理されたフレームを XAML [Image](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.image) コントロールで表示する **VideoFrameAvailable** ハンドラーを示しています。

**VideoFrameAvailable** ハンドラーが呼び出されるたびに、[**CopyFrameToVideoSurface**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer.copyframetovideosurface) メソッドを使用して、フレームの内容が [**IDirect3DSurface**](https://docs.microsoft.com/uwp/api/windows.graphics.directx.direct3d11.idirect3dsurface) にコピーされます。 [**CopyFrameToStereoscopicVideoSurfaces**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer.copyframetostereoscopicvideosurfaces) を使用して 3D コンテンツを 2 つのサーフェスにコピーし、左目用と右目用のコンテンツを個別に処理することもできます。 **IDirect3DSurface** を実装するオブジェクトを取得するため、この例では、[**SoftwareBitmap**](https://docs.microsoft.com/uwp/api/windows.graphics.imaging.softwarebitmap) を作成し、そのオブジェクトを使って、必要なインターフェイスを実装する Win2D **CanvasBitmap** を作成します。 **CanvasImageSource** は **Image** コントロールのソースとして使用できる Win2D オブジェクトであるため、新しいオブジェクトを作成し、コンテンツを表示する **Image** のソースとして設定しています。 次に、**CanvasDrawingSession** が作成されます。 これは、Win2D でぼかし効果のレンダリングに使用されます。

必要なオブジェクトがすべてインスタンス化されると、**CopyFrameToVideoSurface** が呼び出され、**MediaPlayer** から **CanvasBitmap** に現在のフレームがコピーされます。 次に、Win2D **GaussianBlurEffect**が作成され、操作のソースとして **CanvasBitmap** が設定されます。 最後に、**CanvasDrawingSession.DrawImage** が呼び出され、ぼかし効果が適用されたソース画像が、**Image** コントロールに関連付けられた **CanvasImageSource** に描画され、それが UI に描画されます。

[!code-cs[VideoFrameAvailable](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetVideoFrameAvailable)]

Win2D について詳しくは、[Win2D の GitHub リポジトリ](https://github.com/Microsoft/Win2D)をご覧ください。 上記のサンプル コードを試すには、次の手順でプロジェクトにWin2D NuGet パッケージを追加する必要があります。

**効果のプロジェクトに Win2D NuGet パッケージを追加するには**

1.  **ソリューション エクスプローラー**で、プロジェクトを右クリックし、**[NuGet パッケージの管理]** をクリックします。
2.  ウィンドウの上部で **[参照]** タブをクリックします。
3.  検索ボックスに **「Win2D」** と入力します。
4.  **[Win2D.uwp]** を選択し、右のウィンドウで **[インストール]** を選択します。
5.  **[変更の確認]** ダイアログに、インストールするパッケージが表示されます。 **[OK]** をクリックします。
6.  パッケージのライセンスに同意します。

## <a name="detect-and-respond-to-audio-level-changes-by-the-system"></a>システムによるオーディオ レベルの変更を検出して対応する
Windows 10、バージョン 1803 以降では、現在 **MediaPlayer** で再生されているオーディオ レベルが、システムによって低下した場合やミュートされた場合に、アプリがそれを検出できます。 たとえば、アラームが鳴っているときに、システムがオーディオ再生レベルを下げることがあります ("ダッキング" と呼ばれます)。 アプリ マニフェストで *backgroundMediaPlayback* 機能が宣言されていない場合、アプリがバックグラウンドに移動すると、システムによってアプリがミュートされます。 [**AudioStateMonitor**](https://docs.microsoft.comuwp/api/windows.media.audio.audiostatemonitor) クラスを使用すると、オーディオ ストリームの音量がシステムによって変更されたときに、イベントを受け取るように登録できます。 その **MediaPlayer** のオーディオ レベルがシステムによって変更されたときに通知を受け取るには、**MediaPlayer** の **AudioStateMonitor** プロパティにアクセスし、[**SoundLevelChanged**](https://docs.microsoft.com/uwp/api/windows.media.audio.audiostatemonitor.soundlevelchanged) イベントのハンドラーを登録します。

[!code-cs[RegisterAudioStateMonitor](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetRegisterAudioStateMonitor)]

**SoundLevelChanged**イベントを処理するときは、再生中のコンテンツの種類に応じてさまざまな方法を取ることができます。 たとえば現在音楽を再生中の場合は、ボリュームがダッキングされている間も、そのまま音楽を再生し続けることが考えられます。 しかしポッドキャストを再生中の場合は、ユーザーがコンテンツを聞き逃さないように、ダッキングされている間、再生を一時停止するのが普通です。

以下の例では、現在再生されているコンテンツがポッドキャストかどうかを追跡する変数を宣言しています。この変数は、**MediaPlayer** のコンテンツを選択するときに、アプリによって適切な値に設定されるものと想定します。 またオーディオ レベルが変更されたためにプログラムによって再生が一時停止された場合に、それを追跡するクラス変数も作成しています。

[!code-cs[AudioStateVars](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetAudioStateVars)]

**SoundLevelChanged** イベント ハンドラーで、**AudioStateMonitor** センダーの [**SoundLevel**](https://docs.microsoft.com/uwp/api/windows.media.audio.audiostatemonitor.soundlevel) プロパティを確認すると、新しいサウンド レベルを判定できます。 以下の例では、新しいサウンド レベルがフル音量かどうか、つまりシステムが音量のミュートまたはダッキングを停止したかどうか、またはサウンド レベルは低いままだが、ポッドキャスト以外のコンテンツを再生しているかどうかを確認しています。 これらのいずれかが true で、コンテンツがプログラムによって一時停止されている場合、再生が再開されます。 新しいサウンド レベルがミュートされている場合、または現在のコンテンツがポッドキャストでサウンドレベルが低い場合、再生が一時停止され、プログラムによって一時停止が開始されたことを追跡する変数が設定されます。

[!code-cs[SoundLevelChanged](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSoundLevelChanged)]

オーディオがシステムによってダッキングされている場合でも、再生を一時停止するか続行するかをユーザーが選択することがあります。 以下の例では、再生と一時停止ボタンのイベント ハンドラーを示します。 一時停止ボタンのクリック ハンドラーでは、再生がプログラムによって既に一時停止されている場合、この変数を更新して、ユーザーがコンテンツを一時停止したことを示します。 再生ボタンのクリック ハンドラーでは、再生を再開し、追跡変数をクリアします。

[!code-cs[ButtonUserClick](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetButtonUserClick)]

## <a name="related-topics"></a>関連トピック
* [メディア再生](media-playback.md)
* [メディア項目、プレイリスト、トラック](media-playback-with-mediasource.md)
* [システム メディア トランスポート コントロールとの統合](integrate-with-systemmediatransportcontrols.md)
* [メディアの中断の作成、スケジュール、管理](create-schedule-and-manage-media-breaks.md)
* [バックグラウンドでのメディアの再生](background-audio.md)





 

 




