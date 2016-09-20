---
author: drewbatgit
ms.assetid: 
description: "この記事では、MediaPlayer を使ってユニバーサル Windows アプリでメディアを再生する方法を示します。"
title: "MediaPlayer を使ったオーディオとビデオの再生"
translationtype: Human Translation
ms.sourcegitcommit: 3d6f79ea55718d988415557bc4ac9a1f746f9053
ms.openlocfilehash: 32df2810710e78eeb8c257548c39c0d5d978e888

---

# MediaPlayer を使ったオーディオとビデオの再生

この記事では、[**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer) クラスを使ってユニバーサル Windows アプリでメディアを再生する方法を示します。 Windows 10 バージョン 1607 で、メディア再生 API が大幅に強化されました。これには、バックグラウンド オーディオ向けの簡素化された単一プロセス設計、システム メディア トランスポート コントロール (SMTC) との自動統合、複数のメディア プレーヤーを同期する機能、Windows.UI.Composition サーフェスに対する機能、コンテンツでメディアの中断を作成およびスケジュールするための簡単なインターフェイスなどが含まれます。 これらの強化機能を活用できるように、メディアを再生するためのベスト プラクティスとして、メディア再生に **MediaElement** の代わりに **MediaPlayer** クラスを使うことが推奨されます。 軽量の XAML コントロールである [**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaPlayerElement) が導入され、XAML ページのメディア コンテンツをレンダリングできるようになりました。 **MediaElement** によって提供される再生コントロールと状態 API の多くは、新しい [**MediaPlaybackSession**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession) オブジェクトを通じて利用できるようになりました。 **MediaElement** は下位互換性をサポートするために今後も動作しますが、このクラスには新しい機能は追加されません。

この記事では、一般的なメディア再生アプリで使う **MediaPlayer** の機能について説明します。 **MediaPlayer** は、すべてのメディア項目のコンテナーとして [**MediaSource**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.MediaSource) クラスを使います。 このクラスを使うと、すべて同じインターフェイスを使って、ローカル ファイル、メモリ ストリーム、ネットワーク ソースなど、さまざまなソースからメディアを読み込んで再生できます。 [**MediaPlaybackItem**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItem) や [**MediaPlaybackList**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackList) など、**MediaSource** と共に使用できる上位レベルのクラスもあります。これらは、プレイリストや、複数のオーディオ、ビデオ、メタデータ トラックでメディア ソースを管理する機能など、より高度な機能を提供します。 **MediaSource** および関連 API について詳しくは、「[メディア項目、プレイリスト、トラック](media-playback-with-mediasource.md)」をご覧ください。


##MediaPlayer でメディア ファイルを再生する  
**MediaPlayer** を使った基本的なメディア再生は非常に簡単に実装できます。 まず、**MediaPlayer** クラスの新しいインスタンスを作成します。 アプリは、複数の **MediaPlayer** のインスタンスを同時にアクティブにすることができます。 次に、プレイヤーの [**Source**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.Source) プロパティを、[**MediaSource**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.MediaSource)、[**MediaPlaybackItem**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItem)、[**MediaPlaybackList**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackList) など、[**IMediaPlaybackSource**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.IMediaPlaybackSource) を実装するオブジェクトに設定します。 この例では、アプリのローカル ストレージにあるファイルから **MediaSource** が作成された後、**MediaPlaybackItem** がソースから作成されて、プレイヤーの **Source** プロパティに割り当てられます。

**MediaElement** とは異なり、**MediaPlayer** は既定では自動的に再生を開始しません。 再生を開始するには、[**Play**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.Play) を呼び出すか、[**AutoPlay**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.AutoPlay) プロパティを true に設定するか、またはユーザーが組み込みのメディア コントロールを使って再生を開始するのを待ちます。

[!code-cs[SimpleFilePlayback](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSimpleFilePlayback)]

アプリが **MediaPlayer** を使って実行されたときは、[**Close**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.Close) メソッド (C# で **Dispose** に投影される) を呼び出して、プレーヤーで使われるリソースをクリーンアップしてください。

[!code-cs[CloseMediaPlayer](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetCloseMediaPlayer)]

##MediaPlayerElement を使って XAML でビデオをレンダリングする
メディアを XAML で表示せずに **MediaPlayer** で再生することはできますが、多くのメディア再生アプリは XAML ページでメディアをレンダリングします。 これを行うには、軽量な [**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaPlayerElement) コントロールを使います。 **MediaElement** と同様に、**MediaPlayerElement** でも組み込みのトランスポート コントロールを表示するかどうかを指定することができます。

[!code-xml[MediaPlayerElementXAML](./code/MediaPlayer_RS1/cs/MainPage.xaml#SnippetMediaPlayerElementXAML)]

[**SetMediaPlayer**](https://msdn.microsoft.com/library/windows/apps/mt708764) を呼び出して、要素がバインドされている **MediaPlayer** インスタンスを設定することができます。

[!code-cs[SetMediaPlayer](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSetMediaPlayer)]

**MediaPlayerElement** での再生ソースを設定することもできます。その場合、要素は自動的に [**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaPlayerElement.MediaPlayer) プロパティを使ってアクセスできる新しい **MediaPlayer** インスタンスを作成します。

[!code-cs[GetPlayerFromElement](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetGetPlayerFromElement)]

##MediaPlayer の一般的なタスク
このセクションでは、**MediaPlayer** の一部の機能の使用方法を示します。

###オーディオ カテゴリの設定
**MediaPlayer** の [**AudioCategory**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.AudioCategory) プロパティを [**MediaPlayerAudioCategory**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayerAudioCategory) 列挙値のいずれかの値に設定して、再生しているメディアの種類をシステムに知らせます。 ゲームでは、別のアプリケーションがバックグラウンドで音楽を再生する場合にゲームの音楽が自動的にミュートされるように、ゲームの音楽ストリームを **GameMedia** として分類してください。 音楽またはビデオ アプリケーションでは、ストリームの優先順位が **GameMedia** ストリームより高くなるように、ストリームを **Media** または **Movie** として分類してください。

[!code-cs[SetAudioCategory](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSetAudioCategory)]

###特定のオーディオ エンドポイントへの出力
既定では、**MediaPlayer** からのオーディオ出力はシステムの既定のオーディオ エンドポイントに送られますが、**MediaPlayer** が出力用に使う特定のオーディオ エンドポイントを指定することもできます。 下の例では、[**MediaDevice.GetAudioRenderSelector**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Devices.MediaDevice.GetAudioRenderSelector) がデバイスのオーディオ レンダリング カテゴリを一意に識別する文字列を返します。 次に、[**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/Windows.Devices.Enumeration.DeviceInformation) メソッドの [**FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/Windows.Devices.Enumeration.DeviceInformation.FindAllAsync) を呼び出して、選択した種類の利用可能なデバイスの一覧を取得します。 プログラムを使ってどのデバイスを使うかを判断することも、返されたデバイスを [**ComboBox**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ComboBox) に追加してユーザーがデバイスを選択できるようにすることもできます。

[!code-cs[SetAudioEndpointEnumerate](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSetAudioEndpointEnumerate)]

デバイス コンボ ボックスの [**SelectionChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.Primitives.Selector.SelectionChanged) イベントで、**MediaPlayer** の [**AudioDevice**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.AudioDevice) プロパティが選択されたデバイスに設定されます。これは、**ComboBoxItem** の [**Tag**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.FrameworkElement.Tag) プロパティに格納されていました。

[!code-cs[SetAudioEndpontSelectionChanged](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSetAudioEndpontSelectionChanged)]

###再生セッション
この記事の前の方で説明したように、**MediaElement** クラスによって公開される関数の多くは [**MediaPlaybackSession**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession) クラスに移されました。 これには、現在の再生位置、プレーヤーが一時停止しているか再生中か、現在の再生速度など、プレーヤーの再生状態に関する情報が含まれています。 **MediaPlaybackSession** は、再生中のコンテンツの現在のバッファリングおよびダウンロードの状態や、現在再生中のビデオ コンテンツの自然なサイズと縦横比などの状態が変わったときに通知するイベントもいくつか提供します。

次の例は、コンテンツを 10 秒前にスキップするボタン クリック ハンドラーを実装する方法を示しています。 まず、プレイヤーの **MediaPlaybackSession** オブジェクトが [**PlaybackSession**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.PlaybackSession) プロパティで取得されます。 次に、[**Position**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession.Position) プロパティが現在の再生位置に 10 秒加えた位置に設定されます。

[!code-cs[SkipForwardClick](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSkipForwardClick)]

次の例は、セッションの [**PlaybackRate**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession.PlaybackRate) プロパティを設定して通常の再生速度と 2 倍の速度を切り替えるトグル ボタンを示しています。

[!code-cs[SpeedChecked](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetSpeedChecked)]

###ビデオのピンチおよびズーム
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
        
##MediaPlayerSurface を使って、Windows.UI.Composition サーフェスにビデオをレンダリングします。
Windows 10 バージョン 1607 からは、**MediaPlayer** を使って [**ICompositionSurface**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Composition.ICompositionSurface) にビデオをレンダリングできるため、プレイヤーは [**Windows.UI.Composition**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Composition) 名前空間で API と相互運用することができます。 コンポジション フレームワークを使うと、XAML と低レベルの DirectX グラフィックス API の間のビジュアル レイヤーでグラフィックスを操作することができます。 これにより、任意の XAML コントロールにビデオをレンダリングするようなシナリオが可能になります。 コンポジション API の使い方について詳しくは、「[ビジュアル レイヤー](https://msdn.microsoft.com/windows/uwp/graphics/visual-layer)」をご覧ください。

次の例に、ビデオ プレーヤーのコンテンツを [**Canvas**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.Canvas) コントロールにレンダリングする方法を示します。 この例でのメディア プレーヤー固有の呼び出しは、[**SetSurfaceSize**](https://msdn.microsoft.com/library/windows/apps/mt489968) と [**GetSurface**](https://msdn.microsoft.com/library/windows/apps/mt489963) です。 **SetSurfaceSize** は、コンテンツのレンダリングに割り当てるバッファのサイズをシステムに伝えます。 **GetSurface** は、引数として [**Compositor**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Composition.Compositor) を受け取り、[**MediaPlayerSurface**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayerSurface) クラスのインスタンスを取得します。 このクラスは、サーフェスを作成するために使われる **MediaPlayer** と **Compositor** へのアクセスを提供し、[**CompositionSurface**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayerSurface.CompositionSurface) プロパティを通じてサーフェス自体を公開します。

この例の残りのコードでは、ビデオをレンダリングする [**SpriteVisual**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Composition.SpriteVisual) を作成し、そのサイズをビジュアルを表示するキャンバス要素のサイズに設定します。 次に、[**MediaPlayerSurface**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayerSurface) から [**CompositionBrush**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Composition.CompositionBrush) が作成され、ビジュアルの [**Brush**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Composition.SpriteVisual.Brush) プロパティに割り当てられます。 そして、[**ContainerVisual**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Composition.ContainerVisual) が作成され、そのビジュアル ツリーの一番上に **SpriteVisual** が挿入されます。 最後に、[**SetElementChildVisual**](https://msdn.microsoft.com/library/windows/apps/mt608981) を呼び出してコンテナー ビジュアルを **Canvas** に割り当てます。

[!code-cs[Compositor](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetCompositor)]
        
##MediaTimelineController を使って複数のプレイヤー全体でコンテンツを同期する
この記事で前に説明したように、アプリは複数の **MediaPlayer** オブジェクトを一度にアクティブにすることができます。 既定では、作成する **MediaPlayer** はそれぞれ独立して動作します。 コメント トラックからビデオへの同期などの一部のシナリオでは、複数のプレーヤーの状態、再生位置、および再生速度を同期することもできます。 Windows 10 バージョン 1607 以降では、[**MediaTimelineController**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.MediaTimelineController) クラスを使ってこの動作を実装できます。

###再生コントロールを実装する
次の例は、**MediaTimelineController** を使って **MediaPlayer** の 2 つのインスタンスを制御する方法を示しています。 まず、**MediaPlayer** の各インスタンスがインスタンス化され、**Source** がメディア ファイルに設定されます。 次に、新しい **MediaTimelineController** が作成されます。 **MediaPlayer** ごとに、[**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManager.IsEnabled) プロパティを false に設定することで、各プレーヤー関連付けられている [**MediaPlaybackCommandManager**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManager) が無効にされます。 そして、[**TimelineController**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.TimelineController) プロパティがタイムライン コント ローラー オブジェクトに設定されます。

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

###タイムラインの位置から再生位置をオフセットする
場合によっては、タイムライン コント ローラーに関連付けられている 1 つ以上のメディア プレーヤーの再生位置に、他のプレーヤーからのオフセットを付けたいことがあります。 これを行うには、オフセットを付ける **MediaPlayer** オブジェクトの [ **TimelineControllerPositionOffset** ](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.TimelineControllerPositionOffset) プロパティを設定します。 次の例では、2 つのメディア プレーヤーのコンテンツの再生時間を使って、項目の長さを加えるか差し引くように 2 つのスライダー コントロールの最小値と最大値を設定しています。  

[!code-cs[OffsetSliders](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetOffsetSliders)]

各スライダーの [**ValueChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.Primitives.RangeBase.ValueChanged) イベントで、各プレーヤーの **TimelineControllerPositionOffset** が対応する値に設定されます。

[!code-cs[TimelineOffset](./code/MediaPlayer_RS1/cs/MainPage.xaml.cs#SnippetTimelineOffset)]

プレーヤーのオフセット値が負の再生位置にマップされる場合は、オフセットがゼロになるまでクリップは一時停止のままになり、その後に再生が開始されます。 同様に、オフセット値がメディア項目の再生時間を超える再生位置にマップされる場合は、1 つのメディア プレーヤーがそのコンテンツの最後に達したときのように最終フレームが表示されます。

## 関連トピック
* [メディア再生](media-playback.md)
* [メディア項目、プレイリスト、トラック](media-playback-with-mediasource.md)
* [システム メディア トランスポート コントロールとの統合](integrate-with-systemmediatransportcontrols.md)
* [メディアの中断の作成、スケジュール、管理](create-schedule-and-manage-media-breaks.md)
* [バックグラウンドでのメディアの再生](background-audio.md)





 

 







<!--HONumber=Aug16_HO3-->


