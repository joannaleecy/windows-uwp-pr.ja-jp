---
author: drewbatgit
ms.assetid: C5623861-6280-4352-8F22-80EB009D662C
description: この記事では、ローカル ファイルやリモート ファイルなど、さまざまなソースのメディアを参照および再生するための一般的な方法を提供し、基になるメディア形式に関係なく、メディア データにアクセスするための一般的なモデルを公開する MediaSource の使い方について説明します。
title: メディア項目、プレイリスト、トラック
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 73b6a19e2385f1a9b8afa4672df50d17ac16ec97
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5863936"
---
# <a name="media-items-playlists-and-tracks"></a>メディア項目、プレイリスト、トラック


 この記事では、ローカル ファイルやリモート ファイルなど、さまざまなソースのメディアを参照および再生するための一般的な方法を提供し、基になるメディア形式に関係なく、メディア データにアクセスするための一般的なモデルを公開する [**MediaSource**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.MediaSource) クラスの使い方について説明します。 [**MediaPlaybackItem**](https://msdn.microsoft.com/library/windows/apps/dn930939) クラスは、メディア項目に含まれている複数のオーディオ、ビデオ、メタデータ トラックを管理および選択できるようにして、**MediaSource** の機能を拡張します。 [**MediaPlaybackList**](https://msdn.microsoft.com/library/windows/apps/dn930955) を使用すると、1 つまたは複数のメディア再生項目から再生リストを作成できます。


## <a name="create-and-play-a-mediasource"></a>MediaSource を作成および再生する

クラスによって公開されているファクトリ メソッドのいずれかを呼び出すことによって、**MediaSource** の新しいインスタンスを作成します。

-   [**CreateFromAdaptiveMediaSource**](https://msdn.microsoft.com/library/windows/apps/dn930906)
-   [**CreateFromIMediaSource**](https://msdn.microsoft.com/library/windows/apps/dn965527)
-   [**CreateFromMediaStreamSource**](https://msdn.microsoft.com/library/windows/apps/dn930907)
-   [**CreateFromMseStreamSource**](https://msdn.microsoft.com/library/windows/apps/dn930908)
-   [**CreateFromStorageFile**](https://msdn.microsoft.com/library/windows/apps/dn930909)
-   [**CreateFromStream**](https://msdn.microsoft.com/library/windows/apps/dn930910)
-   [**CreateFromStreamReference**](https://msdn.microsoft.com/library/windows/apps/dn930911)
-   [**CreateFromUri**](https://msdn.microsoft.com/library/windows/apps/dn930912)
-   [**CreateFromDownloadOperation**](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource.createfromdownloadoperation)

作成した **MediaSource** は、[**Source**](https://msdn.microsoft.com/library/windows/apps/dn987010) プロパティを設定すると、[**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/dn652535) を使用して再生できます。 Windows 10 バージョン 1607 以降では、XAML ページでメディア プレイヤー コンテンツをレンダリングするには、[**SetMediaPlayer**](https://msdn.microsoft.com/library/windows/apps/mt708764) を呼び出して **MediaPlayer** を [**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaPlayerElement) に割り当てます。 これは、**MediaElement** を使用するよりもお勧めの方法です。 **MediaPlayer** の使い方について詳しくは、「[**MediaPlayer を使ったオーディオとビデオの再生**](play-audio-and-video-with-mediaplayer.md)」をご覧ください。

次の例では、**MediaSource** を使って **MediaPlayer** でユーザーが選択したメディア ファイルを再生する方法を示します。

このシナリオを実現するには、[**Windows.Media.Core**](https://msdn.microsoft.com/library/windows/apps/dn278962) および [**Windows.Media.Playback**](https://msdn.microsoft.com/library/windows/apps/dn640562) 名前空間を含める必要があります。

[!code-cs[Using](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetUsing)]

**MediaSource** 型の変数を宣言します。 この記事の例では、複数の場所からアクセスできるように、メディア ソースはクラス メンバーとして宣言されています。

[!code-cs[DeclareMediaSource](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetDeclareMediaSource)]

**MediaPlayer** オブジェクトを格納するための変数を宣言します。XAML でメディア コンテンツをレンダリングする場合は、**MediaPlayerElement** コントロールをページに追加します。

[!code-cs[DeclareMediaPlayer](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetDeclareMediaPlayer)]

[!code-xml[MediaPlayerElement](./code/MediaSource_RS1/cs/MainPage.xaml#SnippetMediaPlayerElement)]

再生するメディア ファイルの選択をユーザーに求めるには、[**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) を使います。 ピッカーの [**PickSingleFileAsync**](https://msdn.microsoft.com/library/windows/apps/jj635275) メソッドから返された [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを使って、[**MediaSource.CreateFromStorageFile**](https://msdn.microsoft.com/library/windows/apps/dn930909) を呼び出すことにより、新しい MediaObject を初期化します。 最後に、[**SetPlaybackSource**](https://msdn.microsoft.com/library/windows/apps/dn899085) メソッドを呼び出すことによって、メディア ソースを、**MediaElement** の再生ソースとして設定します。

[!code-cs[PlayMediaSource](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetPlayMediaSource)]

既定では、メディア ソースが設定されても **MediaPlayer** では自動的に再生が開始されません。 [**Play**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.Play) を呼び出すことにより手動で再生を開始できます。

[!code-cs[Play](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetPlay)]

**MediaPlayer** の [**AutoPlay**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.AutoPlay) プロパティを true に設定して、メディア ソースが設定されたらすぐに再生を開始するようにプレイヤーに指示することもできます。

[!code-cs[AutoPlay](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetAutoPlay)]

### <a name="create-a-mediasource-from-a-downloadoperation"></a>DownloadOperation から MediaSource を作成する
Windows、バージョン 1803 以降では、**DownloadOperation** から **MediaSource**オブジェクトを作成できます。

[!code-cs[CreateMediaSourceFromDownload](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetCreateMediaSourceFromDownload)]

ダウンロードを開始したり、その **IsRandomAccessRequired** プロパティを true に設定したりしなくても、ダウンロードから **MediaSource** を作成できますが、**MediaSource** を **MediaPlayer** や **MediaPlayerElement** にアタッチするには、その前にこれら両方の操作を行う必要があります。

[!code-cs[StartDownload](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetStartDownload)]


## <a name="handle-multiple-audio-video-and-metadata-tracks-with-mediaplaybackitem"></a>MediaPlaybackItem を使って複数のオーディオ、ビデオ、メタデータ トラックを処理する

[**MediaSource**](https://msdn.microsoft.com/library/windows/apps/dn930905) を使った再生では、さまざまな種類のソースからメディアを再生するための共通の方法が提供されるため便利ですが、**MediaSource** から [**MediaPlaybackItem**](https://msdn.microsoft.com/library/windows/apps/dn930939) を作成することにより、さらに高度な動作を実現できます。 これには、メディアの項目の複数のオーディオ、ビデオ、データのトラックにアクセスして管理する機能が含まれます。

**MediaPlaybackItem** を格納するための変数を宣言します。

[!code-cs[DeclareMediaPlaybackItem](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetDeclareMediaPlaybackItem)]

コンストラクターを呼び出して、初期化された **MediaSource** オブジェクトを渡すことによって、**MediaPlaybackItem** を作成します。

アプリがメディア再生項目で複数のオーディオ、ビデオ、データのトラックをサポートしている場合は、[**AudioTracksChanged**](https://msdn.microsoft.com/library/windows/apps/dn930948)、[**VideoTracksChanged**](https://msdn.microsoft.com/library/windows/apps/dn930954)、または [**TimedMetadataTracksChanged**](https://msdn.microsoft.com/library/windows/apps/dn930952) イベントのイベント ハンドラーを登録します。

最後に、**MediaElement** または **MediaPlayer** の再生ソースを **MediaPlaybackItem** に設定します。

[!code-cs[PlayMediaPlaybackItem](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetPlayMediaPlaybackItem)]

> [!NOTE] 
> **MediaSource** は、単一の **MediaPlaybackItem** にのみ関連付けることができます。 ソースから **MediaPlaybackItem** を作成した後、同じソースから別の再生項目を作成しようとすると、エラーが発生します。 また、メディア ソースから **MediaPlaybackItem** を作成した後、**MediaSource** オブジェクトを **MediaPlayer** のソースとして直接設定することはできません。この場合は、代わりに **MediaPlaybackItem** を使う必要があります。

複数のビデオ トラックを含む **MediaPlaybackItem** が再生ソースとして割り当てられると、[**VideoTracksChanged**](https://msdn.microsoft.com/library/windows/apps/dn930954) イベントが発生します。項目の変更としてビデオ トラックのリストが変更された場合は、再びイベントが発生することがあります。 このイベントのハンドラーを使うと、ユーザーが利用可能なトラックを切り替えることができるように UI を更新する機会が提供されます。 この例では、[**ComboBox**](https://msdn.microsoft.com/library/windows/apps/br209348) を使って利用可能なビデオ トラックを表示します。

[!code-xml[VideoComboBox](./code/MediaSource_RS1/cs/MainPage.xaml#SnippetVideoComboBox)]

**VideoTracksChanged** ハンドラーで、再生の項目の [**VideoTracks**](https://msdn.microsoft.com/library/windows/apps/dn930953) のリストにあるすべてのトラックをループ処理します。 各トラックについて、新しい [**ComboBoxItem**](https://msdn.microsoft.com/library/windows/apps/br209349) が作成されます。 トラックにまだラベルがない場合、トラックのインデックスからラベルが生成されます。 コンボ ボックス項目の [**Tag**](https://msdn.microsoft.com/library/windows/apps/br208745) プロパティが、後で識別できるようにトラックのインデックスに設定されます。 最後に、コンボ ボックスに項目が追加されます。 これらの処理は [**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) の呼び出し内で実行されます。UI の変更はすべて UI スレッドで実行される必要があり、このイベントは別のスレッドで発生しているためです。

[!code-cs[VideoTracksChanged](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetVideoTracksChanged)]

コンボ ボックスの [**SelectionChanged**](https://msdn.microsoft.com/library/windows/apps/br209776) ハンドラーで、選択した項目の **Tag** プロパティからトラックのインデックスが取得されます。 メディア再生項目の [**VideoTracks**](https://msdn.microsoft.com/library/windows/apps/dn930953) リストの [**SelectedIndex**](https://msdn.microsoft.com/library/windows/apps/dn956634) プロパティを設定すると、**MediaElement** または **MediaPlayer** はアクティブなビデオ トラックを、指定されたインデックスに切り替えます。

[!code-cs[VideoTracksSelectionChanged](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetVideoTracksSelectionChanged)]

複数のオーディオ トラックを含むメディア項目の管理は、ビデオ トラックの場合とまったく同じです。 [**AudioTracksChanged**](https://msdn.microsoft.com/library/windows/apps/dn930948) を処理し、再生項目の [**AudioTracks**](https://msdn.microsoft.com/library/windows/apps/dn930947) リストで見つかったオーディオ トラックを使って、UI を更新します。 ユーザーがオーディオ トラックを選んだときに、**AudioTracks** リストの [**SelectedIndex**](https://msdn.microsoft.com/library/windows/apps/dn930937) プロパティを設定すると、**MediaElement** または **MediaPlayer** はアクティブなオーディオ トラックを、指定されたインデックスに切り替えます。

[!code-xml[AudioComboBox](./code/MediaSource_RS1/cs/MainPage.xaml#SnippetAudioComboBox)]

[!code-cs[AudioTracksChanged](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetAudioTracksChanged)]

[!code-cs[AudioTracksSelectionChanged](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetAudioTracksSelectionChanged)]

オーディオとビデオに加え、**MediaPlaybackItem** オブジェクトは 0 個以上の [**TimedMetadataTrack**](https://msdn.microsoft.com/library/windows/apps/dn956580) オブジェクトを格納する場合があります。 タイミングが設定されたメタデータ トラックは、サブタイトルまたはキャプション テキストを含めることができます。またはアプリに固有のカスタム データを含めることができます。 タイミングが設定されたメタデータ トラックには、[**DataCue**](https://msdn.microsoft.com/library/windows/apps/dn930892) や [**TimedTextCue**](https://msdn.microsoft.com/library/windows/apps/dn956655) など、[**IMediaCue**](https://msdn.microsoft.com/library/windows/apps/dn930899) を継承するオブジェクトで表されるキューのリストが含まれます。 各キューには開始時刻と継続時間があり、キューがいつアクティブ化され、どのくらいの時間アクティブ化されているかを決定します。

オーディオ トラックやビデオ トラックと同様に、**MediaPlaybackItem** の [**TimedMetadataTracksChanged**](https://msdn.microsoft.com/library/windows/apps/dn930952) イベントを処理することによって、メディア項目のタイミングが設定されたメタデータ トラックを検出できます。 ただし、タイミングが設定されたメタデータ トラックを使って、ユーザーは一度に複数のメタデータ トラックを有効にすることができます。 また、アプリ シナリオに応じて、ユーザーの介入なしに、自動的にメタデータ トラックを有効または無効にすることもできます。 この例では、わかりやすくするために、メディア項目で各メタデータ トラック用の [**ToggleButton**](https://msdn.microsoft.com/library/windows/apps/br209795) を追加することで、ユーザーがトラックを有効または無効に設定できるようにしています。の各メタデータ トラックを無効にするユーザーを許可するように、メディア項目で追跡します。各ボタンの **Tag** プロパティは、ボタンが切り替えられたときに識別できるように、関連付けられたメタデータ トラックのインデックスに設定されます。

[!code-xml[MetaStackPanel](./code/MediaSource_RS1/cs/MainPage.xaml#SnippetMetaStackPanel)]

[!code-cs[TimedMetadataTrackschanged](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetTimedMetadataTrackschanged)]

一度に複数のメタデータ トラックをアクティブ化することができるため、メタデータ トラック リストについて、単にアクティブなインデックスを設定しません。 代わりに、**MediaPlaybackItem** オブジェクトの [**SetPresentationMode**](https://msdn.microsoft.com/library/windows/apps/dn986977) メソッドを呼び出して、切り替えるトラックのインデックスを渡し、[**TimedMetadataTrackPresentationMode**](https://msdn.microsoft.com/library/windows/apps/dn987016) 列挙体から値を指定します。 選択する表示モードは、アプリの実装によって異なります。 この例では、メタデータ トラックは、有効な場合 **PlatformPresented** に設定されます。 テキスト ベースのトラックの場合、これは、システムが自動的にトラックにテキスト キューを表示することを意味します。トグル ボタンをオフにすると、表示モードは **Disabled** に設定されます。つまり、テキストは表示されず、キュー イベントは発生しません。 キュー イベントについては、この記事で後述します。

[!code-cs[ToggleChecked](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetToggleChecked)]

[!code-cs[ToggleUnchecked](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetToggleUnchecked)]

メタデータ トラックを処理している場合は、[**Cues**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.TimedMetadataTrack.Cues) プロパティまたは [**ActiveCues**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.TimedMetadataTrack.ActiveCues) プロパティにアクセスすることで、トラック内の一連のキューにアクセスできます。 こうすることで、UI を更新して、メディア項目のキューの場所を表示することができます。

## <a name="handle-unsupported-codecs-and-unknown-errors-when-opening-media-items"></a>メディア項目を開く際にサポートされていないコーデックと不明なエラーを処理する
Windows 10 バージョン 1607 以降では、アプリが実行されているデバイスでメディア項目の再生に必要なコーデックがサポートされているかどうか、または部分的にサポートされているかどうかを確認できます。 まず、[**AudioTracksChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItem.AudioTracksChanged) などの **MediaPlaybackItem** トラック変更イベントのイベント ハンドラーで、その変更が新しいトラックの挿入かどうかを確認します。そうである場合は、[**AudioTracks**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItem.AudioTracks) コレクションなど、**MediaPlaybackItem** パラメーターの適切なトラック コレクションと共に、**IVectorChangedEventArgs.Index** パラメーターで渡されるインデックスを使用することにより、挿入されるトラックへの参照を取得できます。

挿入されるトラックへの参照を取得したら、そのトラックの [**SupportInfo**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.AudioTrack.SupportInfo) プロパティの [**DecoderStatus**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.AudioTrackSupportInfo.DecoderStatus) を確認します。 この値が [**FullySupported**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.MediaDecoderStatus) の場合は、トラックの再生に必要な適切なコーデックがデバイス上に存在します。 この値が [**Degraded**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.MediaDecoderStatus) の場合は、システムでトラックを再生することはできるものの、何らかの方法で再生が劣化することになります。 たとえば、5.1 オーディオ トラックが、2 チャンネル ステレオで再生される可能性があります。 このような場合は、UI を更新して、ユーザーに対し品質の低下を通知することをお勧めします。 この値が [**UnsupportedSubtype**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.MediaDecoderStatus) または [**UnsupportedEncoderProperties**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.MediaDecoderStatus) の場合は、デバイス上に存在する現在のコーデックではトラックを再生できません。 ユーザーに通知してその項目の再生をスキップするか、ユーザーが正しいコーデックをダウンロードできる UI の実装が必要になる場合があります。 トラックの [**GetEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.AudioTrack.GetEncodingProperties) メソッドは、再生に必要なコーデックを確認するために使用します。

最後に、トラックの [**OpenFailed**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.AudioTrack.OpenFailed) イベントを登録します。このイベントは、デバイス上でトラックがサポートされているものの、パイプラインの不明なエラーによってトラックを開けなかった場合に発生します。

[!code-cs[AudioTracksChanged_CodecCheck](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetAudioTracksChanged_CodecCheck)]

[**OpenFailed**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.AudioTrack.OpenFailed) イベント ハンドラーでは、**MediaSource** ステータスが不明かどうかを確認できます。不明な場合は、プログラムによって別のトラックを選択して再生できるようにしたり、ユーザーが別のトラックを選べるようにしたり、再生を無視することができます。

[!code-cs[OpenFailed](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetOpenFailed)]

## <a name="set-display-properties-used-by-the-system-media-transport-controls"></a>システム メディア トランスポート コントロールで使用する表示プロパティを設定する
Windows 10 バージョン 1607 以降、[**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer) で再生されるメディアは既定では自動的にシステム メディア トランスポート コントロール (SMTC) に統合されます。 SMTC で表示されるメタデータを指定するには、**MediaPlaybackItem** の表示プロパティを更新します。 項目の表示プロパティを表すオブジェクトを取得するには、[**GetDisplayProperties**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItem.GetDisplayProperties) を呼び出します。 [**Type**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaItemDisplayProperties.Type) プロパティを設定することによって、再生項目が音楽かビデオかを設定し、 次に、オブジェクトの [**VideoProperties**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaItemDisplayProperties.VideoProperties) または [**MusicProperties**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaItemDisplayProperties.MusicProperties) を設定します。 項目のプロパティを与えた値に更新するには、[**ApplyDisplayProperties**](https://msdn.microsoft.com/library/windows/apps/mt489923) を呼び出します。 通常、アプリは Web サービスから表示値を動的に取得しますが、次の例はこのプロセスをハードコードされた値を使って示しています。

[!code-cs[SetVideoProperties](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetSetVideoProperties)]

[!code-cs[SetMusicProperties](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetSetMusicProperties)]

## <a name="add-external-timed-text-with-timedtextsource"></a>TimedTextSource を使って外部のタイミングが設定されたテキストを追加する

シナリオによっては、さまざまなロケールのサブタイトルが含まれる個別のファイルなど、メディア項目に関連付けられているタイミングが設定されたテキストが外部のファイルに含まれている場合があります。 ストリームや URI から外部のタイミングが設定されたテキスト ファイルを読み込むには、[**TimedTextSource**](https://msdn.microsoft.com/library/windows/apps/dn956679) クラスを使います。

この例では、**Dictionary** コレクションでソース URI を使ってメディア項目のタイミングが設定されたテキスト ソースのリストを格納し、解決された後のトラックを識別するためにキーと値のペアとして **TimedTextSource** オブジェクトを使用します。

[!code-cs[TimedTextSourceMap](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetTimedTextSourceMap)]

[**CreateFromUri**](https://msdn.microsoft.com/library/windows/apps/dn708190) を呼び出すことによって、外部のタイミングが設定されたテキスト ファイルごとに新しい **TimedTextSource** を作成します。 タイミングが設定されたテキスト ソース用のエントリを **Dictionary** に追加します。 [**TimedTextSource.Resolved**](https://msdn.microsoft.com/library/windows/apps/dn965540) イベントのハンドラーを追加して、項目の読み込みに失敗した場合の処理をしたり、項目が正常に読み込まれた後で追加のプロパティを設定したりします。

**TimedTextSource** オブジェクトを [**ExternalTimedTextSources**](https://msdn.microsoft.com/library/windows/apps/dn930916) コレクションに追加して、すべてのオブジェクトを **MediaSource** に登録します。 タイミングが設定された外部のテキスト ソースは、ソースから作成された **MediaPlaybackItem** ではなく、**MediaSource** に直接追加されることに注意してください。 外部のテキスト トラックを反映するように UI を更新するには、この記事で既に説明したように、**TimedMetadataTracksChanged** イベントを登録して処理します。

[!code-cs[TimedTextSource](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetTimedTextSource)]

[**TimedTextSource.Resolved**](https://msdn.microsoft.com/library/windows/apps/dn965540) イベントのハンドラーで、ハンドラーに渡された [**TimedTextSourceResolveResultEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn965537) の **Error** プロパティを確認して、タイミングが設定されたテキスト データの読み込み中にエラーが発生したかどうかを判断します。 項目が正しく解決された場合は、このハンドラーを使って、解決されたトラックの他のプロパティを更新できます。この例では、以前に **Dictionary** に格納された URI に基づいて、各トラックのラベルを追加します。

[!code-cs[TimedTextSourceResolved](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetTimedTextSourceResolved)]

## <a name="add-additional-metadata-tracks"></a>その他のメタデータ トラックを追加する

コードで動的にカスタム メタデータ トラックを作成し、メディア ソースを関連付けることができます。 作成するトラックにサブタイトルやキャプション テキストを含めたり、独自のアプリ データを含めたりすることができます。

コンストラクターを呼び出して、ID、言語識別子、および [**TimedMetadataKind**](https://msdn.microsoft.com/library/windows/apps/dn956578) 列挙体からの値を指定することによって、新しい [**TimedMetadataTrack**](https://msdn.microsoft.com/library/windows/apps/dn956580) を作成します。 [**CueEntered**](https://msdn.microsoft.com/library/windows/apps/dn956583) イベントと [**CueExited**](https://msdn.microsoft.com/library/windows/apps/dn956584) イベントのハンドラーを登録します。 これらのイベントはそれぞれ、キューの開始時刻になったときと、キューの継続時間が終了したときに発生します。

作成するメタデータ トラックの種類に適切な新しいキュー オブジェクトを作成し、トラックの ID、開始時刻、継続時間を設定します。この例では、データ トラックが作成されるため、一連の [**DataCue**](https://msdn.microsoft.com/library/windows/apps/dn930892) オブジェクトが生成され、アプリ固有のデータを格納するバッファーが各キューに提供されます。 新しいトラックを登録するには、**MediaSource** オブジェクトの [**ExternalTimedMetadataTracks**](https://msdn.microsoft.com/library/windows/apps/dn930915) コレクションにトラックを追加します。

Windows 10 Version 1703 以降では、**DataCue.Properties** プロパティが [**PropertySet**](https://docs.microsoft.com/uwp/api/windows.foundation.collections.propertyset) を公開します。これを使用して、**CueEntered** と **CueExited** イベントで取得できるキー/データのペアにカスタム プロパティを格納することができます。  

[!code-cs[AddDataTrack](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetAddDataTrack)]

**CueEntered** イベントは、関連付けられたトラックの表示モードが **ApplicationPresented**、**Hidden**、または **PlatformPresented** である限り、キューの開始時間になると発生します。 トラックの表示モードが **Disabled** である場合、メタデータ トラックのキュー イベントは発生しません。 この例では、キューに関連付けられているカスタム データを、単にデバッグ ウィンドウに出力します。

[!code-cs[DataCueEntered](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetDataCueEntered)]

この例では、トラックを作成するときに **TimedMetadataKind.Caption** を指定し、[**TimedTextCue**](https://msdn.microsoft.com/library/windows/apps/dn956655) オブジェクトを使ってトラックにキューを追加することによって、カスタム テキスト トラックを追加します。

[!code-cs[AddTextTrack](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetAddTextTrack)]

[!code-cs[TextCueEntered](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetTextCueEntered)]

## <a name="play-a-list-of-media-items-with-mediaplaybacklist"></a>MediaPlaybackList を使ってメディア項目のリストを再生する

[**MediaPlaybackList**](https://msdn.microsoft.com/library/windows/apps/dn930955) を使うことにより、**MediaPlaybackItem** オブジェクトによって表されるメディア項目の再生リストを作成できます。

**注:** [**MediaPlaybackList**](https://msdn.microsoft.com/library/windows/apps/dn930955)内の項目は、ギャップレス再生を使用してレンダリングされます。 システムは、MP3 または AAC でエンコードされたファイルで提供されるメタデータを使用して、ギャップレス再生に必要な遅延またはパディングの補正を決定します。 MP3 または AAC でエンコードされているファイルでこのメタデータが提供されない場合は、システムがヒューリスティックによって遅延またはパディングを決定します。 ロスレス形式 (PCM、FLAC、ALAC など) の場合、これらのエンコーダーによる遅延やパディングが発生しないため、システムが実行する処理はありません。

最初に、**MediaPlaybackList** を格納するための変数を宣言します。

[!code-cs[DeclareMediaPlaybackList](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetDeclareMediaPlaybackList)]

この記事で既に説明した手順と同じ手順で、リストに追加する各メディア項目について **MediaPlaybackItem** を作成します。 **MediaPlaybackList** オブジェクトを初期化し、メディア再生項目を追加します。 [**CurrentItemChanged**](https://msdn.microsoft.com/library/windows/apps/dn930957) イベントのハンドラーを登録します。 このイベントによって、UI を更新して現在再生中のメディア項目を反映できます。 リスト内の項目が正常に開かれたときに発生する [ItemOpened](https://docs.microsoft.com/uwp/api/Windows.Media.Playback.MediaPlaybackList.ItemOpened)イベントや、リスト内の項目を開くことができないときに発生する [ItemFailed](https://docs.microsoft.com/uwp/api/Windows.Media.Playback.MediaPlaybackList.ItemFailed) イベントに登録することもできます。

Windows 10 Version 1703 以降では、[MaxPlayedItemsToKeepOpen](https://docs.microsoft.com/uwp/api/Windows.Media.Playback.MediaPlaybackList.MaxPlayedItemsToKeepOpen) プロパティを設定することによって、システムが再生後に開いたままにしておく、**MediaPlaybackList** 内の **MediaPlaybackItem** オブジェクトの最大数を指定できます。 **MediaPlaybackItem** を開いたままにしておくと、ユーザーがその項目に切り替えたときに、項目を再び読み込む必要がないため、すぐに項目の再生を開始できます。 ただし、項目を開いたままにしておくと、アプリのメモリ消費量も増加するため、この値を設定する場合は、応答性とメモリ使用量のバランスを考慮する必要があります。 

リストの再生を有効にするには、**MediaPlayer** の再生ソースを **MediaPlaybackList** に設定します。

[!code-cs[PlayMediaPlaybackList](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetPlayMediaPlaybackList)]

**CurrentItemChanged** イベント ハンドラーで、UI を更新して現在再生中の項目を反映します。再生中の項目は、イベントに渡された [**CurrentMediaPlaybackItemChangedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn930929) オブジェクトの [**NewItem**](https://msdn.microsoft.com/library/windows/apps/dn930930) プロパティを使って取得できます。 このイベントから UI を更新する場合は、更新が UI スレッドで行われるように、[**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) の呼び出し内で実行する必要があります。

Windows 10 Version 1703 以降では、[CurrentMediaPlaybackItemChangedEventArgs.Reason](https://docs.microsoft.com/uwp/api/windows.media.playback.currentmediaplaybackitemchangedeventargs.Reason) プロパティを調べて、項目が変更された理由 (アプリがプログラムによって項目を切り替えた、以前に再生していた項目の末尾に到達した、エラーが発生したなど) を示す値を取得できます。

[!code-cs[MediaPlaybackListItemChanged](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetMediaPlaybackListItemChanged)]


メディア プレーヤーで **MediaPlaybackList** の前の項目や次の項目を再生するには、[**MovePrevious**](https://msdn.microsoft.com/library/windows/apps/mt146455) または [**MoveNext**](https://msdn.microsoft.com/library/windows/apps/mt146454) を呼び出します。

[!code-cs[PrevButton](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetPrevButton)]

[!code-cs[NextButton](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetNextButton)]

[**ShuffleEnabled**](https://msdn.microsoft.com/library/windows/apps/mt146457) プロパティを設定して、メディア プレーヤーがリスト内の項目をランダムな順序で再生するかどうかを指定します。

[!code-cs[ShuffleButton](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetShuffleButton)]

[**AutoRepeatEnabled**](https://msdn.microsoft.com/library/windows/apps/mt146452) プロパティを設定して、メディア プレーヤーがリストをループ再生するかどうかを指定します。

[!code-cs[RepeatButton](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetRepeatButton)]


### <a name="handle-the-failure-of-media-items-in-a-playback-list"></a>再生リスト内のメディア項目のエラーへの対処
[**ItemFailed**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackList.ItemFailed) イベントは、リスト内の項目を開けない場合に発生します。 ハンドラーに渡された [**MediaPlaybackItemError**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItemError) オブジェクトの [**ErrorCode**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItemError.ErrorCode) プロパティは、ネットワーク エラー、デコード エラー、暗号化エラーなど、可能であればエラーの具体的な原因を列挙します。

[!code-cs[ItemFailed](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetItemFailed)]

### <a name="disable-playback-of-items-in-a-playback-list"></a>再生リストの項目の再生の無効化
Windows 10 Version 1703 以降では、[MediaPlaybackItem](https://docs.microsoft.com/uwp/api/Windows.Media.Playback.MediaPlaybackItem) の [IsDisabledInPlaybackList](https://docs.microsoft.com/uwp/api/Windows.Media.Playback.MediaPlaybackItem.IsDisabledInPlaybackList) プロパティを false に設定することにより、**MediaPlaybackItemList** 内の 1 つまたは複数の項目の再生を無効にすることができます。 

この機能の一般的なシナリオは、インターネットからストリーム配信される音楽を再生するアプリです。 このアプリでは、デバイスのネットワーク接続状態の変化をリッスンし、完全にダウンロードされていない項目の再生を無効にすることができます。 次の例では、[NetworkInformation.NetworkStatusChanged](https://docs.microsoft.com/uwp/api/Windows.Networking.Connectivity.NetworkInformation.NetworkStatusChanged) イベントのハンドラーが登録されています。

[!code-cs[RegisterNetworkStatusChanged](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetRegisterNetworkStatusChanged)]

**NetworkStatusChanged** のハンドラーで、[GetInternetConnectionProfile](https://docs.microsoft.com/uwp/api/Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile) が null (ネットワークが接続されていないことを示す) を返すかどうかを確認します。 これに該当する場合、再生リスト内のすべての項目をループ処理し、項目の [TotalDownloadProgress](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem.TotalDownloadProgress) が 1 未満である (つまり項目が完全にダウンロードされていない) 場合は、項目を無効にします。 ネットワーク接続が有効である場合は、再生リスト内のすべての項目をループ処理し、各項目を有効にします。

[!code-cs[NetworkStatusChanged](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetNetworkStatusChanged)]

### <a name="defer-binding-of-media-content-for-items-in-a-playback-list-by-using-mediabinder"></a>MediaBinder を使用して再生リスト内の項目に対するメディア コンテンツのバインドを延期する
前の例では、ファイル、URL、ストリームから **MediaSource** が作成され、その後 **MediaPlaybackItem** が作成され、**MediaPlaybackList** に追加されます。 ユーザーがコンテンツを表示する際に課金されている場合など、いくつかのシナリオでは、再生リスト内の項目を実際に再生する準備ができるまで、**MediaSource** のコンテンツの取得を延期することができます。 このシナリオを実装するには、[**MediaBinder**](https://docs.microsoft.com/uwp/api/Windows.Media.Core.MediaBinder) クラスのインスタンスを作成します。 [**Token**](https://docs.microsoft.com/uwp/api/Windows.Media.Core.MediaBinder.Token) プロパティを、取得を延期するコンテンツを識別するための、アプリで定義された文字列に設定し、[**Binding**](https://docs.microsoft.com/uwp/api/Windows.Media.Core.MediaBinder.Binding) イベントのハンドラーを登録します。 次に、[**MediaSource.CreateFromMediaBinder**](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource.createfrommediabinder) を呼び出すことによって、**Binder** から **MediaSource** を作成します。 その後、通常の手順で、**MediaSource** から **MediaPlaybackItem** を作成し、再生リストに追加します。

[!code-cs[InitMediaBinder](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetInitMediaBinder)]

システムは、**MediaBinder** に関連付けられているコンテンツを取得する必要があることを特定すると、**Binding** イベントを発生させます。 このイベントのハンドラーで、イベントに渡された [**MediaBindingEventArgs**](https://docs.microsoft.com/uwp/api/windows.media.core.mediabindingeventargs) から **MediaBinder** インスタンスを取得できます。 **Token** プロパティに指定された文字列を取得し、その文字列を使用して取得する必要があるコンテンツを特定します。 **MediaBindingEventArgs** は、いくつかの異なる表現でバインドされるコンテンツを設定するためのメソッド ([**SetStorageFile**](https://docs.microsoft.com/uwp/api/windows.media.core.mediabindingeventargs.setstoragefile)、[**SetStream**](https://docs.microsoft.com/uwp/api/windows.media.core.mediabindingeventargs.setstream)、[**SetStreamReference**](https://docs.microsoft.com/uwp/api/windows.media.core.mediabindingeventargs.setstreamreference)、[**SetUri**](https://docs.microsoft.com/uwp/api/windows.media.core.mediabindingeventargs.seturi) など) を提供します。 

[!code-cs[BinderBinding](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetBinderBinding)]

**Binding** イベント ハンドラーで、Web 要求などの非同期操作を実行している場合、[**MediaBindingEventArgs.GetDeferral**](https://docs.microsoft.com/uwp/api/windows.media.core.mediabindingeventargs.GetDeferral) メソッドを呼び出して、操作が完了するまで待機してから続行するようにシステムに指示する必要があります。 操作が完了した後、[**Deferral.Complete**](https://docs.microsoft.com/uwp/api/windows.foundation.deferral.Complete) を呼び出して、システムに続行を指示します。

Windows 10 Version 1703 以降では、[**SetAdaptiveMediaSource**](https://docs.microsoft.com/uwp/api/windows.media.core.mediabindingeventargs.setadaptivemediasource) を呼び出すことによって、バインドされているコンテンツとして [**AdaptiveMediaSource**](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasource) を指定できます。 アプリでのアダプティブ ストリーミングの使用について詳しくは、「[アダプティブ ストリーミング](adaptive-streaming.md)」をご覧ください。



## <a name="related-topics"></a>関連トピック
* [メディア再生](media-playback.md)
* [MediaPlayer を使ったオーディオとビデオの再生](play-audio-and-video-with-mediaplayer.md)
* [システム メディア トランスポート コントロールとの統合](integrate-with-systemmediatransportcontrols.md)
* [バックグラウンドでのメディアの再生](background-audio.md)

