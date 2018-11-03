---
author: jwmsft
ms.assetid: DE5B084C-DAC1-430B-A15B-5B3D5FB698F7
title: アニメーション、メディア、画像の最適化
description: スムーズなアニメーション、高いフレーム レート、およびパフォーマンスの高いメディア キャプチャと再生を備えたユニバーサル Windows プラットフォーム (UWP) アプリを作成します。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 66704daaca67dae2ba4f5a3882f5885ff333d2ce
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5990940"
---
# <a name="optimize-animations-media-and-images"></a>アニメーション、メディア、画像の最適化


スムーズなアニメーション、高いフレーム レート、およびパフォーマンスの高いメディア キャプチャと再生を備えたユニバーサル Windows プラットフォーム (UWP) アプリを作成します。

## <a name="make-animations-smooth"></a>アニメーションのスムーズ化

UWP アプリの重要な側面は、スムーズな対話式操作です。 これには、"指の動きに忠実な" タッチ操作、スムーズな切り替えやアニメーション、入力のフィードバックを返す小さな動作などがあります。 XAML フレームワークには、アプリの視覚要素の合成とアニメーション専用の、合成スレッドと呼ばれるスレッドがあります。 合成スレッドは UI スレッド (フレームワークと開発者コードを実行するスレッド) からは独立しているため、レイアウト パスや拡張計算が複雑でも、一貫したフレーム レートとスムーズなアニメーションをアプリで実現できます。 このセクションでは、合成スレッドを使って、アプリのアニメーションをスムーズにする方法について説明します。 アニメーションについて詳しくは、「[アニメーションの概要](https://msdn.microsoft.com/library/windows/apps/Mt187350)」をご覧ください。 計算を集中的に実行している間のアプリの応答性の向上については、「[UI スレッドの応答性の確保](keep-the-ui-thread-responsive.md)」をご覧ください。

### <a name="use-independent-instead-of-dependent-animations"></a>依存型ではなく、独立型アニメーションを使う

アニメーション化されるプロパティに対する変更は、シーン内の残りのオブジェクトに影響を与えないため、独立型アニメーションは作成時の最初から最後まで計算できます。 そのため、独立型アニメーションは UI スレッドではなく合成スレッドで実行されます。 合成スレッドは一定の間隔で更新されるため、アニメーションをスムーズに実行し続けることができます。

次のようなアニメーションはすべて独立性が保証されます。

-   キー フレームを使ったオブジェクト アニメーション
-   再生時間が 0 のアニメーション
-   [**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/Hh759771) プロパティと [**Canvas.Top**](https://msdn.microsoft.com/library/windows/apps/Hh759772) プロパティに対するアニメーション
-   [**UIElement.Opacity**](/uwp/api/Windows.UI.Xaml.UIElement.Opacity) プロパティに対するアニメーション
-   [**SolidColorBrush.Color**](/uwp/api/Windows.UI.Xaml.Media.SolidColorBrush.Color) サブプロパティをターゲット設定した場合の、[**Brush**](/uwp/api/Windows.UI.Xaml.Media.Brush) 型のプロパティに対するアニメーション
-   これらの戻り値の型のサブプロパティをターゲット設定した場合の、次の [**UIElement**](https://msdn.microsoft.com/library/windows/apps/BR208911) プロパティに対するアニメーション

    -   [**RenderTransform**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.rendertransform)
    -   [**Transform3D**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.transform3d)
    -   [**Projection**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.projection)
    -   [**Clip**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.clip)

依存型アニメーションはレイアウトに影響するため、計算に UI スレッドからの追加の入力が必要です。 依存型アニメーションには、[**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) や [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height) などのプロパティへの変更があります。 依存型アニメーションは、既定では実行されず、アプリ開発者からのオプトインが必要です。 有効になると、UI スレッドがブロックされない限りスムーズに実行されますが、フレームワークやアプリの UI スレッドで他の作業が大量に行われると引っかかりが発生します。

XAML フレームワーク内のほぼすべてのアニメーションは、既定で独立して実行されますが、この最適化が無効になる操作がいくつかあります。 特に次のようなシナリオに注意してください。

-   依存型アニメーションを UI スレッドで実行できるように [**EnableDependentAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210356) プロパティを設定する。 そうしたアニメーションは、独立型バージョンに変換します。 たとえば、オブジェクトの [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) と [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height) ではなく、[**ScaleTransform.ScaleX**](https://msdn.microsoft.com/library/windows/apps/BR242946) と [**ScaleTransform.ScaleY**](https://msdn.microsoft.com/library/windows/apps/BR242948) をアニメーション化します。 画像やテキストなどのオブジェクトも拡大/縮小できます。 [**ScaleTransform**](https://msdn.microsoft.com/library/windows/apps/BR242940) がアニメーション化されている間のみ、フレームワークによってバイリニア スケーリングが適用されます。 画像やテキストは、常にきれいに表示されるように、最終的なサイズでもう一度ラスター化されます。
-   フレームごとに更新する。これは、実質的には依存型アニメーションです。 これの例には、[**CompositonTarget.Rendering**](https://msdn.microsoft.com/library/windows/apps/BR228127) イベントのハンドラーでの変換の適用があります。
-   [**CacheMode**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.cachemode) プロパティを **BitmapCache** に設定した要素で独立型と見なされるアニメーションを実行する。 これは、フレームごとにキャッシュをもう一度ラスター化する必要があるため、依存型と見なされます。

### <a name="dont-animate-a-webview-or-mediaplayerelement"></a>WebView または MediaPlayerElement はアニメーション化しない

[**WebView**](https://msdn.microsoft.com/library/windows/apps/BR227702) コントロール内の Web コンテンツは、XAML フレームワークによって直接レンダリングされることはないため、画面の他の部分と合成する追加の作業が必要になります。 この追加の作業は画面上でコントロールをアニメーション化する際に行われ、同期の問題 (HTML コンテンツがページ上の XAML コンテンツの他の部分と同期して動かないなど) が発生する可能性があります。 **WebView** コントロールをアニメーション化する必要がある場合は、アニメーションを実行している間、そのコントロールを [**WebViewBrush**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.webviewbrush.aspx) に置き換えます。

[**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) のアニメーション化も同様に適切ではない方法です。 パフォーマンスが低下するだけでなく、再生中のビデオ コンテンツに裂け目のようなアーティファクトが発生することがあります。

> **注:**  **MediaPlayerElement**に関するこの記事で推奨事項は、 [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926)にも適用されます。 **MediaPlayerElement** は Windows 10 バージョン 1607 でのみ利用できます。以前のバージョンの Windows 用のアプリを作成する場合は、**MediaElement** を使う必要があります。

### <a name="use-infinite-animations-sparingly"></a>無限アニメーションは慎重に使う

大部分のアニメーションは指定された時間内で実行されますが、[**Timeline.Duration**](https://msdn.microsoft.com/library/windows/apps/BR243207) プロパティを Forever に設定すると、アニメーションを無限に実行できます。 この無限アニメーションを使うのはできるだけ避けてください。これらが CPU リソースを消費し続けることで、CPU が低電力またはアイドル状態に移行できず、非常に短い時間でバッテリーを使い果たす可能性があるためです。

[**CompositionTarget.Rendering**](https://msdn.microsoft.com/library/windows/apps/BR228127) のハンドラーの追加は、無限アニメーションの実行と同じような効果があります。 通常、UI スレッドは実行する作業がある場合にのみアクティブになりますが、このイベントのハンドラーを追加すると、すべてのフレームが強制的に実行されます。 実行する作業がない場合はハンドラーを削除し、再び必要になったときに再登録してください。

### <a name="use-the-animation-library"></a>アニメーション ライブラリを使う

[**Windows.UI.Xaml.Media.Animation**](https://msdn.microsoft.com/library/windows/apps/BR243232) 名前空間には、他の Windows アニメーションとの一貫性を備えた外観を持つ、高パフォーマンスかつスムーズなアニメーションのライブラリが含まれています。 関連クラスは名前に "Theme" が含まれています。関連クラスについては、「[アニメーションの概要](https://msdn.microsoft.com/library/windows/apps/Mt187350)」をご覧ください。 このライブラリは、アプリの最初の表示や、状態とコンテンツの切り替えにアニメーションを設定するなど、一般的なアニメーション シナリオの多くに対応しています。 パフォーマンスを高め UWP UI との一貫性を強化するために、できるだけこのアニメーション ライブラリを使うことをお勧めします。

> **注:** アニメーション ライブラリには、すべてのプロパティがアニメーション化することはできません。 アニメーション ライブラリが適用されない XAML シナリオについては、「[ストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/Mt187354)」を参照してください。


### <a name="animate-compositetransform3d-properties-independently"></a>CompositeTransform3D のプロパティを個別にアニメーション化する

[**CompositeTransform3D**](https://msdn.microsoft.com/library/windows/apps/Dn914714) の各プロパティを個別にアニメーション化して、必要なアニメーションのみを適用できます。 詳しい説明と例については、「[**UIElement.Transform3D**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.transform3d)」をご覧ください。 変換のアニメーション化について詳しくは、「[ストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/Mt187354)」および「[キーフレームとイージング関数のアニメーション](https://msdn.microsoft.com/library/windows/apps/Mt187352)」をご覧ください。

## <a name="optimize-media-resources"></a>メディア リソースの最適化

オーディオ、ビデオ、画像は、ほとんどのアプリがユーザーを引き付けるために使うコンテンツです。 メディアのキャプチャ レートが向上し、コンテンツが標準解像度から高解像度に移行しているため、そうしたコンテンツを格納、デコード、再生するために必要なリソースの量が増えています。 XAML フレームワークは UWP のメディア エンジンに追加された最新機能を基に構築されているため、アプリでそれらの機能を無料で利用できます。 ここでは、UWP アプリでメディアを活用するためのヒントをいくつか紹介します。

### <a name="release-media-streams"></a>メディア ストリームの解放

メディア ファイルは、アプリが通常使うリソースの中で最も一般的かつ負荷の高いリソースに分類されます。 メディア ファイル リソースによってアプリのメモリ使用量のサイズが大幅に増大することがあるため、アプリの使用が終わったらすぐにメディアへのハンドルを忘れずに解放する必要があります。

たとえば、アプリが [**RandomAccessStream**](/uwp/api/Windows.Storage.Streams.RandomAccessStream) または [**IInputStream**](https://msdn.microsoft.com/library/windows/apps/BR241718) オブジェクトを使っている場合は、アプリの使用が終わったらこのオブジェクトで close メソッドを呼び出して、下位にあるオブジェクトを解放します。

### <a name="display-full-screen-video-playback-when-possible"></a>可能な場合はビデオ再生を全画面表示

UWP アプリでは、フル ウィンドウのレンダリングを有効または無効にする場合、常に [**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) の [**IsFullWindow**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.isfullwindow.aspx) プロパティを使います。 そうすることで、メディアの再生中にシステム レベルの最適化が使われることが保証されます。

XAML フレームワークでは、レンダリングの対象がビデオ コンテンツだけの場合は、ビデオ コンテンツの表示を最適化することができます。その結果、消費電力が低減され、フレーム レートが改善されます。 メディアの再生を最適化するには、**MediaPlayerElement** のサイズを画面の幅と高さに設定し、他の XAML 要素を表示しないようにします。

画面全体を占める **MediaPlayerElement** の上に XAML 要素 (クローズド キャプションや一時的なトランスポート コントロールなど) をオーバーレイすることには正当な理由があります。 これらの要素でメディアの再生を最適な状態に戻す必要がない場合は、これらの要素を非表示にしてください (`Visibility="Collapsed"` を設定する)。

### <a name="display-deactivation-and-conserving-power"></a>ディスプレイの非アクティブ化と消費電力の節約

アプリでビデオを再生しているときなど、無操作状態が検出されてもディスプレイの電源が切れないようにするためには、[**DisplayRequest.RequestActive**](https://msdn.microsoft.com/library/windows/apps/BR241818) を呼び出します。

消費電力とバッテリーの駆動時間を節約するため、不要になったらすぐに [**DisplayRequest.RequestRelease**](https://msdn.microsoft.com/library/windows/apps/BR241819) を呼び出して表示要求を解放してください。

表示要求を解放する必要があるのは、次のような場合です。

-   ユーザーの操作、バッファリング、限られた帯域幅のための調整などでビデオの再生が一時停止になる。
-   再生が停止する。 たとえば、ビデオの再生が完了したり、プレゼンテーションが終了したりする。
-   再生エラーが発生した。 たとえば、ネットワーク接続の問題や破損したファイル。

### <a name="put-other-elements-to-the-side-of-embedded-video"></a>埋め込みビデオの横に他の要素を配置

アプリには、ページ内でビデオを再生する埋め込みビューが用意されていることがあります。 その場合は、[**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) がページのサイズではなく、他に描画される XAML オブジェクトがあるため、全画面表示の最適化が行われません。 **MediaPlayerElement** の周りに境界線を描画すると、意図せずにこのモードになることに注意してください。

埋め込みモードの場合は、ビデオの上に重ねて XAML 要素を描画しないでください。 描画すると、画面を合成するためにフレームワークが追加作業を行うことになります。 この場合は、ビデオの上に重ねずに、たとえば、埋め込みメディア要素の下にトランスポート コントロールを配置すると、最適化が行われます。 次の画像では、赤色のバーが一連のトランスポート コントロール (再生、一時停止、停止など) を示しています。

![要素がオーバーレイされている MediaPlayerElement](images/videowithoverlay.png)

メディアが全画面ではないときは、メディアの上にこれらのコントロールを重ねて配置しないでください。 代わりに、メディアがレンダリングされる領域の外にトランスポート コントロールを配置します。 次の画像では、コントロールがメディアの下に配置されています。

![要素が隣接している MediaPlayerElement](images/videowithneighbors.png)

### <a name="delay-setting-the-source-for-a-mediaplayerelement"></a>MediaPlayerElement のソースの遅延設定

メディア エンジンは負荷の高いオブジェクトです。XAML フレームワークでは、dll の読み込みと大きなオブジェクトの作成を可能な限り遅らせます。 [**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) では、ソースが [**Source**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.source.aspx) プロパティによって設定されると、この処理が強制的に実行されます。 ユーザーがメディアを再生する準備が実際に整った時点でソースを設定すると、**MediaPlayerElement** に関連する負担の大部分を可能な限り遅らせることができます。

### <a name="set-mediaplayerelementpostersource"></a>MediaPlayerElement.PosterSource の設定

[**MediaPlayerElement.PosterSource**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.postersource.aspx) を設定すると、XAML は一部の GPU リソースを解放できます。解放しないと、それらのリソースは使われたままになります。 この API を使うことで、アプリが使うメモリを最小限に抑えることができます。

### <a name="improve-media-scrubbing"></a>メディアのスクラブの改善

メディア プラットフォームの応答性を高めるにあたってスクラブは常に困難を伴うタスクです。 一般的には、Slider の値を変更することで、これを実現します。 次に、スクラブ操作をできるだけ効率的にするためのヒントをいくつか示します。

-   [**Slider**](https://msdn.microsoft.com/library/windows/apps/BR209614) の値を [**MediaPlayerElement.MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.mediaplayer.aspx) の [**Position**](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplaybacksession.position.aspx) を照会するタイマーに基づいて更新します。 タイマーに適切な更新頻度を設定します。 **Position** プロパティは再生中に 250 ミリ秒ごとにのみ更新します。
-   Slider のステップ間隔のサイズは、ビデオの長さに合わせて変える必要があります。
-   スライダーの [**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerpressed.aspx)、[**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointermoved.aspx)、[**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerreleased.aspx) イベントを取得して、ユーザーがスライダーのつまみをドラッグしたときに [**PlaybackRate**](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplaybacksession.playbackrate.aspx) プロパティを 0 に設定します。
-   [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerreleased.aspx) イベント ハンドラーで、スクラブ中のつまみのスナップ動作を最適化するために、メディアの位置をスライダーの位置の値に手動で設定します。

### <a name="match-video-resolution-to-device-resolution"></a>ビデオ解像度とデバイス解像度の一致

ビデオのデコードにはメモリと GPU サイクルを大量に使うため、ビデオ形式には、表示するときのものに近い解像度を選んでください。 小さいサイズにスケールダウンするのに、リソースを使って 1080 のビデオをデコードするのは無駄です。 多くのアプリでは同じビデオを異なる解像度でエンコードできませんが、可能であれば、表示される解像度に近いエンコードを使うようにしてください。

### <a name="choose-recommended-formats"></a>お勧めの形式の選択

メディア形式の選択は慎重な判断が必要になる場合があり、多くはビジネス上の意思決定が優先されます。 UWP のパフォーマンスの点から見ると、H.264 ビデオが最優先のビデオ形式で、推奨されるオーディオ形式は AAC と MP3 になります。 ローカル ファイルを再生するためのビデオ コンテンツのファイル コンテナーは MP4 がお勧めです。 最新のグラフィックス ハードウェアのほとんどは H.264 デコードのアクセラレーションに対応しています。 また、VC-1 デコードのハードウェア アクセラレーションは広く利用できるようになっているものの、市場のグラフィックス ハードウェアの多くで、アクセラレーションがフルストリーム レベルのハードウェア オフロード (VLD モード) ではなく、部分的なアクセラレーションのレベル (IDCT レベル) に制限されています。

ビデオ コンテンツ生成プロセスを完全に制御できる場合は、圧縮の効率性と GOP 構造を最適なバランスで両立する方法を見つける必要があります。 B ピクチャを持つ GOP のサイズを比較的小さくすることで、シークまたはトリック モードのパフォーマンスを向上できます。

ゲームなどで、待機時間の短い短時間のオーディオ エフェクトを含める場合、WAV ファイルと非圧縮の PCM データを使います。これにより圧縮オーディオ形式で一般的に発生する処理のオーバーヘッドを削減できます。


## <a name="optimize-image-resources"></a>画像リソースの最適化

### <a name="scale-images-to-the-appropriate-size"></a>画像の適切なサイズへの拡大/縮小

画像が非常に高い解像度でキャプチャされた場合、アプリで画像データをデコードするときに CPU をより多く使用し、ディスクから画像を読み込んだ後でより多くのメモリを使用することにつながる可能性があります。 ただし、画像を元のサイズよりも小さいサイズでのみ表示する場合、高解像度の画像をデコードしてメモリに保存するのは無意味です。 代わりに、[**DecodePixelWidth**](https://msdn.microsoft.com/library/windows/apps/BR243243) プロパティと [**DecodePixelHeight**](https://msdn.microsoft.com/library/windows/apps/BR243241) プロパティを使って、画面上に描画される正確なサイズの画像のバージョンを作成します。

してはいけない例:

```xaml
<Image Source="ms-appx:///Assets/highresCar.jpg"
       Width="300" Height="200"/>    <!-- BAD CODE DO NOT USE.-->
```

代わりに、お勧めする例:

```xaml
<Image>
    <Image.Source>
    <BitmapImage UriSource="ms-appx:///Assets/highresCar.jpg"
                 DecodePixelWidth="300" DecodePixelHeight="200"/>
    </Image.Source>
</Image>
```

[**DecodePixelWidth**](https://msdn.microsoft.com/library/windows/apps/BR243243) と [**DecodePixelHeight**](https://msdn.microsoft.com/library/windows/apps/BR243241) の単位は、既定では物理ピクセルです。 [**DecodePixelType**](https://msdn.microsoft.com/library/windows/apps/Dn298545) プロパティを使って、この動作を変更できます。**DecodePixelType** を **Logical** に設定すると、他の XAML コンテンツと同様に、デコード サイズで自動的に現在の倍率が考慮されます。 したがって、一般的には、**DecodePixelType** を **Logical** に設定することをお勧めします。たとえば、**DecodePixelWidth** と **DecodePixelHeight** を、画像が表示される Image コントロールの Height プロパティと Width プロパティと一致させるような場合です。 物理ピクセルを使用する既定の動作では、システムの現在の倍率を自分で考慮する必要があります。また、ユーザーが表示設定を変更する場合に備えて、スケール変更通知をリッスンする必要があります。

DecodePixelWidth/Height が明示的に画面に表示される画像よりも大きく設定されている場合、アプリは不必要に余分なメモリ (1 ピクセルあたり最大 4 バイト) を使用するため、大きい画像では急速に負荷が大きくなります。 また、画像はバイリニア スケーリングを使って縮小されるため、倍率が大きくなるとぼやけて見える原因となる可能性があります。

DecodePixelWidth/DecodePixelHeight が明示的に画面に表示される画像よりも小さく設定されている場合、画像は拡大され、ピクセル化されたように見える可能性があります。

事前に適切なデコード サイズを特定できない場合には、明示的な DecodePixelWidth/DecodePixelHeight が指定されていないときに、適切なサイズでの画像のデコードをベスト エフォート形式で試行する、XAML の適切なサイズの自動デコードを遅延させる必要があります。

事前に画像コンテンツのサイズがわかっている場合は、明示的にデコード サイズを設定する必要があります。 指定したデコード サイズが他の XAML 要素のサイズを基準としている場合は、併せて [**DecodePixelType**](https://msdn.microsoft.com/library/windows/apps/Dn298545) を **Logical** に設定することも必要です。 たとえば、Image.Width と Image.Height を使ってコンテンツのサイズを明示的に設定する場合、DecodePixelType を DecodePixelType.Logical に設定して Image コントロールと同じ論理ピクセル サイズを使用し、明示的に BitmapImage.DecodePixelWidth や BitmapImage.DecodePixelHeight を使って画像のサイズを制御することによって、大量のメモリ消費を抑えることができる可能性があります。

デコードされたコンテンツのサイズを決定するときに、Image.Stretch を考慮する必要があることに注意してください。

### <a name="right-sized-decoding"></a>適切なサイズのデコード

明示的なデコード サイズを設定していない場合、XAML では、画像を表示するページの初期レイアウトに従って、画面に表示される正確なサイズで画像をデコードすることにより、メモリの消費を最大限に抑えようとします。 可能な限り、この機能を使用するような方法でアプリケーションを作成することをお勧めします。 次の条件のいずれかが満たされる場合、この機能は無効になります。

-   [**SetSourceAsync**](https://msdn.microsoft.com/library/windows/apps/JJ191522) または [**UriSource**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.imaging.bitmapimage.urisource.aspx) を使ってコンテンツを設定した後、[**BitmapImage**](https://msdn.microsoft.com/library/windows/apps/BR243235) がライブ XAML ツリーに接続されている。
-   画像が [**SetSource**](https://msdn.microsoft.com/library/windows/apps/BR243255) などの同期デコードを使用してデコードされる。
-   ホスト画像要素、ブラシ、親要素のいずれかで、[**Opacity**](/uwp/api/Windows.UI.Xaml.UIElement.Opacity) を 0 に設定するか、[**Visibility**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.visibility) を **Collapsed** に設定することによって、画像が非表示になっている。
-   画像コントロールまたはブラシで使用する [**Stretch**](https://msdn.microsoft.com/library/windows/apps/BR242968) が **None** になっている。
-   画像が [**NineGrid**](https://msdn.microsoft.com/library/windows/apps/BR242756) として使用されている。
-   `CacheMode="BitmapCache"` が画像要素またはいずれかの親要素で設定されている。
-   イメージ ブラシが四角形以外である (テキストや図形に適用する場合など)。

上記のシナリオでメモリの節約を実現するための方法は、明示的にデコード サイズを設定することだけです。

ソースを設定する前に、常に [**BitmapImage**](https://msdn.microsoft.com/library/windows/apps/BR243235) をライブ ツリーにアタッチする必要があります。 画像要素またはブラシがマークアップで指定されているときは、常にこれが自動的に適用されます。 例については、後の「ライブ ツリーの例」という見出しのトピックをご覧ください。 ストリーム ソースを設定する場合は、常に [**SetSource**](https://msdn.microsoft.com/library/windows/apps/BR243255) を使わずに、代わりに [**SetSourceAsync**](https://msdn.microsoft.com/library/windows/apps/JJ191522) を使います。 [**ImageOpened**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.imaging.bitmapimage.imageopened.aspx) イベントの発生を待機している間、画像コンテンツを非表示にする (不透明度を 0 にしたり、表示を折りたたむ) ことを回避することをお勧めします。 これを行うかどうかは議論の余地があります。これを行った場合、自動的に適切なサイズに調整されたデコードのメリットが得られません。 アプリで最初に画像コンテンツを非表示にする必要がある場合、可能であれば、明示的にデコード サイズも設定してください。

**ライブ ツリーの例**

例 1 (良い例): Uniform Resource Identifier (URI) をマークアップで指定。

```xaml
<Image x:Name="myImage" UriSource="Assets/cool-image.png"/>
```

例 2 マークアップ: 分離コードで指定された URI。

```xaml
<Image x:Name="myImage"/>
```

例 2 分離コード (良い例): UriSource を設定する前に、ツリーに BitmapImage を接続する。

```csharp
var bitmapImage = new BitmapImage();
myImage.Source = bitmapImage;
bitmapImage.UriSource = new URI("ms-appx:///Assets/cool-image.png", UriKind.RelativeOrAbsolute);
```

例 2 分離コード (悪い例): ツリーに接続する前に、BitmapImage の UriSource を設定します。

```csharp
var bitmapImage = new BitmapImage();
bitmapImage.UriSource = new URI("ms-appx:///Assets/cool-image.png", UriKind.RelativeOrAbsolute);
myImage.Source = bitmapImage;
```

### <a name="caching-optimizations"></a>キャッシュの最適化

キャッシュの最適化は、[**UriSource**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.imaging.bitmapimage.urisource.aspx) を使って、アプリ パッケージまたは Web からコンテンツを読み込む画像について有効です。 URI は基になるコンテンツを一意に識別するために使用され、XAML フレームワークは内部でコンテンツを複数回ダウンロードまたはデコードしません。 代わりに、キャッシュされたソフトウェアまたはハードウェア リソースを使用して、コンテンツが複数回表示されます。

この最適化の例外は、画像がさまざまな解像度で複数回表示される場合 (これは明示的に指定することも、自動的に適切なサイズに調整されたデコードで指定することもできます) です キャッシュの各エントリには、画像の解像度も格納されます。XAML で必要な解像度に一致するソース URI を持つ画像が見つからない場合は、そのサイズで新しいバージョンがデコードされます。 ただし、エンコードされた画像データをもう一度ダウンロードすることはありません。

そのため、アプリ パッケージから画像を読み込む場合は、[**UriSource**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.imaging.bitmapimage.urisource.aspx) の使用を採用する必要があります。また、必要ではない場合に、ファイル ストリームと [**SetSourceAsync**](https://msdn.microsoft.com/library/windows/apps/JJ191522) を使用しないでください。

### <a name="images-in-virtualized-panels-listview-for-instance"></a>仮想化されたパネル内の画像 (ListView など)

画像がツリーから削除された場合 (アプリによって明示的に削除された場合、最新の仮想化されたパネルにある場合やビューの外部にスクロールされて暗黙的に削除された場合)、XAML では、不要になった画像のハードウェア リソースを解放することによってメモリ使用量を最適化します。 メモリはすぐに解放されるのではなく、画像要素がツリーに存在しなくなってから 1 秒後に実行されるフレームの更新時にリリースされます。

そのため、最新の仮想化されたパネルを使用して、画像コンテンツの一覧をホストする必要があります。

### <a name="software-rasterized-images"></a>ソフトウェアでラスタライズされた画像

画像が四角形以外のブラシや [**NineGrid**](https://msdn.microsoft.com/library/windows/apps/BR242756) 用に使用されている場合、画像の拡大縮小が行われない、ソフトウェア ラスタライズ パスが使用されます。 さらに、ソフトウェアとハードウェアの両方のメモリに画像のコピーを保存して必要があります。 たとえば、画像が楕円形のブラシとして使われる場合、大きい可能性がある画像全体は内部で 2 回保存されます。 **NineGrid** または四角形以外のブラシを使用する場合は、アプリで画像を事前に拡大縮小し、レンダリング時のおよそのサイズにしておく必要があります。

### <a name="background-thread-image-loading"></a>バックグラウンド スレッドによる画像の読み込み

XAML には内部の最適化機能があり、ソフトウェア メモリ内の中間サーフェスを使用せずに、ハードウェア メモリ内のサーフェスに非同期的に画像の内容をデコードすることができます。 これにより、ピーク メモリ使用量とレンダリングの待機時間が減少します。 次の条件のいずれかが満たされる場合、この機能は無効になります。

-   画像が [**NineGrid**](https://msdn.microsoft.com/library/windows/apps/BR242756) として使用されている。
-   `CacheMode="BitmapCache"` が画像要素またはいずれかの親要素で設定されている。
-   イメージ ブラシが四角形以外である (テキストや図形に適用する場合など)。

### <a name="softwarebitmapsource"></a>SoftwareBitmapSource

[**SoftwareBitmapSource**](https://msdn.microsoft.com/library/windows/apps/Dn997854) クラスは、さまざまな WinRT 名前空間 ([**BitmapDecoder**](https://msdn.microsoft.com/library/windows/apps/BR226176) など)、カメラ API、XAML の間で、相互運用可能な非圧縮画像を交換します。 このクラスを使用すると、[**WriteableBitmap**](https://msdn.microsoft.com/library/windows/apps/BR243259) で通常必要となる余分なコピーが不要になり、ピーク メモリ使用量とソースから画面表示までの待機時間が削減されます。

ソース情報を提供する [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/Dn887358) は、カスタム [**IWICBitmap**](https://msdn.microsoft.com/library/windows/desktop/Ee719675) を使用するように構成して、再読み込み可能なバッキング ストアを提供することもできます。これにより、アプリは必要に応じてメモリを再マップできます。 これは、高度な C++ の使用事例です。

画像を生成および使用する他の WinRT API と相互運用するには、アプリで [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/Dn887358) と [**SoftwareBitmapSource**](https://msdn.microsoft.com/library/windows/apps/Dn997854) を使う必要があります。 また、アプリで非圧縮画像データを読み込むときには、[**WriteableBitmap**](https://msdn.microsoft.com/library/windows/apps/BR243259) を使用する代わりに、**SoftwareBitmapSource** を使用する必要があります。

### <a name="use-getthumbnailasync-for-thumbnails"></a>GetThumbnailAsync を使ったサムネイル

画像を縮小する使用事例として、サムネイルの作成があります。 [**DecodePixelWidth**](https://msdn.microsoft.com/library/windows/apps/BR243243) と [**DecodePixelHeight**](https://msdn.microsoft.com/library/windows/apps/BR243241) を使って画像の縮小版を作ることができますが、UWP には、サムネイルを取得するためのもっと効率的な API が用意されています。 [**GetThumbnailAsync**](https://msdn.microsoft.com/library/windows/apps/BR227210) ファイル システムに既にキャッシュされている画像のサムネイルを提供します。 この方法では、画像を開いたり、デコードしたりする必要がないため、XAML の API よりもパフォーマンスが向上します。

> [!div class="tabbedCodeSnippets"]
> ```csharp
> FileOpenPicker picker = new FileOpenPicker();
> picker.FileTypeFilter.Add(".bmp");
> picker.FileTypeFilter.Add(".jpg");
> picker.FileTypeFilter.Add(".jpeg");
> picker.FileTypeFilter.Add(".png");
> picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
>
> StorageFile file = await picker.PickSingleFileAsync();
>
> StorageItemThumbnail fileThumbnail = await file.GetThumbnailAsync(ThumbnailMode.SingleItem, 64);
>
> BitmapImage bmp = new BitmapImage();
> bmp.SetSource(fileThumbnail);
>
> Image img = new Image();
> img.Source = bmp;
> ```
> ```vb
> Dim picker As New FileOpenPicker()
> picker.FileTypeFilter.Add(".bmp")
> picker.FileTypeFilter.Add(".jpg")
> picker.FileTypeFilter.Add(".jpeg")
> picker.FileTypeFilter.Add(".png")
> picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary
>
> Dim file As StorageFile = Await picker.PickSingleFileAsync()
>
> Dim fileThumbnail As StorageItemThumbnail = Await file.GetThumbnailAsync(ThumbnailMode.SingleItem, 64)
>
> Dim bmp As New BitmapImage()
> bmp.SetSource(fileThumbnail)
>
> Dim img As New Image()
> img.Source = bmp
> ```

### <a name="decode-images-once"></a>1 回だけの画像のデコード

画像が複数回デコードされないようにするには、メモリ ストリームを使わずに、URI から [**Image.Source**](https://msdn.microsoft.com/library/windows/apps/BR242760) プロパティを割り当てます。 XAML フレームワークでは、複数の場所にある同じ URI をデコードされた 1 つの画像に関連付けることができます。しかし、同じデータを含む複数のメモリ ストリームに対しては同じ処理を行うことができず、メモリ ストリームごとにデコードされた画像を作成します。
