---
author: drewbatgit
ms.assetid: F28162D4-AACC-4EE0-B243-5878F870F87F
description: メディアの再生中にシステムでサポートされているメタデータ キューを処理します
title: システムでサポートされているタイミングが設定されたメタデータのキュー
ms.author: drewbat
ms.date: 04/18/2017
ms.topic: article
keywords: Windows 10, UWP, メタデータ, キュー, 音声, チャプター
ms.localizationpriority: medium
ms.openlocfilehash: 1e97c913764db24c68ce7becdba0fc283e1a3b73
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6470730"
---
# <a name="system-supported-timed-metadata-cues"></a>システムでサポートされているタイミングが設定されたメタデータのキュー
この記事では、メディア ファイルやストリームに埋め込まれる可能性がある、タイミングが設定されたメタデータのいくつかの形式を活用する方法について説明します。 UWP アプリは、これらのメタデータ キューが発生したときに、メディア パイプラインで再生中に発生したイベントについて登録できます。 アプリでは、[**DataCue**](https://docs.microsoft.com/uwp/api/Windows.Media.Core.DataCue) クラスを使って独自のカスタム メタデータ キューを実装できますが、この記事ではメディア パイプラインで自動的に検出される、次のようなメタデータ標準に重点を置いて説明します。

* VobSub 形式の画像ベースの字幕
* 単語の境界、文の境界、音声合成マークアップ言語 (SSML) のブックマークなど、音声キュー
* チャプター キュー
* Extended M3U コメント
* ID3 タグ
* Fragmented mp4 emsg ボックス


この記事は、「[メディア項目、プレイリスト、トラック](media-playback-with-mediasource.md)」の記事で説明されている概念に基づいています。この概念には、[**MediaSource**](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource)、[**MediaPlaybackItem**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem)、[**TimedMetadataTrack**](https://msdn.microsoft.com/library/windows/apps/dn956580) クラスの操作の基本や、アプリでタイミングが設定されたメタデータを使用するための一般的なガイダンスが含まれます。

基本的な実装手順は、この記事で説明されている、さまざまな種類のタイミングが設定されたメタデータと同じです。

1. [**MediaSource**](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource) を作成した後、再生されるコンテンツの [**MediaPlaybackItem**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem) を作成します。
2. [**MediaPlaybackItem.TimedMetadataTracksChanged**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem.TimedMetadataTracksChanged) イベントに登録します。このイベントは、メディア項目のサブトラックがメディア パイプラインで解決されるときに発生します。
3. 使用するタイミングが設定されたメタデータ トラックの [**TimedMetadataTrack.CueEntered**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.CueEntered) イベントと [**TimedMetadataTrack.CueExited**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.CueExited) イベントに登録します。
4. **CueEntered** イベント ハンドラーで、イベント引数で渡されたメタデータに基づいて UI を更新します。 **CueExited** イベントで、もう一度 UI を更新して、現在の字幕テキストを削除するなどの処理を行います。

この記事では、個別のシナリオで各種のメタデータの処理について説明しますが、ほとんどが共有されるコードを使用して、さまざまな種類のメタデータを処理 (または無視) することができます。 このプロセスの複数のポイントで、[**TimedMetadataTrack**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack) オブジェクトの [**TimedMetadataKind**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.TimedMetadataKind) プロパティを確認できます。 そのため、たとえば、値が **TimedMetadataKind.ImageSubtitle** であるメタデータ トラックについては **CueEntered** イベントに登録し、値が **TimedMetadataKind.Speech** であるトラックについては登録しないことを選択できます。 この代わりに、すべての種類のメタデータ トラックのハンドラーを登録し、**CueEntered** ハンドラー内で **TimedMetadataKind** の値を確認して、キューへの応答で実行するアクションを決定することもできます。

## <a name="image-based-subtitles"></a>画像ベースの字幕
Windows 10 Version 1703 以降では、UWP アプリで、VobSub 形式の外部の画像ベースの字幕をサポートできます。 この機能を使用するには、最初に、画像の字幕を表示するメディア コンテンツの [**MediaSource**](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource) オブジェクトを作成します。 次に、[**CreateFromUriWithIndex**](https://docs.microsoft.com/uwp/api/windows.media.core.timedtextsource.CreateFromUriWithIndex) または [**CreateFromStreamWithIndex**](https://docs.microsoft.com/uwp/api/windows.media.core.timedtextsource.CreateFromStreamWithIndex) を呼び出し、字幕の画像データを含む .sub ファイルと、字幕のタイミング情報を含む .idx ファイルの Uri を渡して、[**TimedTextSource**](https://docs.microsoft.com/uwp/api/windows.media.core.timedtextsource) オブジェクトを作成します。 **TimedTextSource** をソースの [**ExternalTimedTextSources**](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource.ExternalTimedTextSources) コレクションに追加することにより、**MediaSource** に追加します。 **MediaSource** から [**MediaPlaybackItem**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem) を作成します。

[!code-cs[ImageSubtitleLoadContent](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetImageSubtitleLoadContent)]

前の手順で作成された **MediaPlaybackItem** オブジェクトを使用して、画像字幕メタデータ イベントに登録します。 この例では、ヘルパー メソッド **RegisterMetadataHandlerForImageSubtitles** を使用して、イベントに登録します。 ラムダ式を使用して、[**TimedMetadataTracksChanged**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem.TimedMetadataTracksChanged) イベントのハンドラーを実装します。このイベントは、システムが **MediaPlaybackItem** に関連付けられたメタデータ トラック内の変更を検出したときに発生します。 状況によっては、再生項目が最初に解決されたときにメタデータ トラックが利用可能な場合があるため、**TimedMetadataTracksChanged** ハンドラーの外部でも、利用可能なメタデータ トラックをループ処理し、**RegisterMetadataHandlerForImageSubtitles** を呼び出します。

[!code-cs[ImageSubtitleTracksChanged](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetImageSubtitleTracksChanged)]

画像字幕メタデータ イベントに登録した後、[**MediaPlayerElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.mediaplayerelement) 内で再生するために、**MediaItem** が [**MediaPlayer**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer) に割り当てられます。

[!code-cs[ImageSubtitlePlay](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetImageSubtitlePlay)]

**RegisterMetadataHandlerForImageSubtitles** ヘルパー メソッドで、**MediaPlaybackItem** の **TimedMetadataTracks** コレクション内のインデックスを指定して、[**TimedMetadataTrack**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack) クラスのインスタンスを取得します。 [**CueEntered**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.CueEntered) イベントと [**CueExited**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.CueExited) イベントに登録します。 次に、再生項目の **TimedMetadataTracks** コレクションで [**SetPresentationMode**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacktimedmetadatatracklist.SetPresentationMode) を呼び出して、アプリでこの再生項目のメタデータ キュー イベントを受信する必要があることをシステムに指示します。

[!code-cs[RegisterMetadataHandlerForImageSubtitles](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetRegisterMetadataHandlerForImageSubtitles)]

**CueEntered** イベントのハンドラーで、ハンドラーに渡された [**TimedMetadataTrack**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack) オブジェクトの [**TimedMetadataKind**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.TimedMetadataKind) プロパティを調べて、メタデータが画像字幕用であるかどうかを確認します。 これは、複数の種類のメタデータについて、同じデータ キュー イベント ハンドラーを使っている場合に必要です。 関連付けられたメタデータ トラックが **TimedMetadataKind.ImageSubtitle** 型である場合は、[**MediaCueEventArgs**](https://docs.microsoft.com/uwp/api/windows.media.core.mediacueeventargs) の **Cue** プロパティに格納されているデータ キューを、[**ImageCue**](https://docs.microsoft.com/uwp/api/windows.media.core.imagecue) にキャストします。 **ImageCue** の [**SoftwareBitmap**](https://docs.microsoft.com/uwp/api/windows.media.core.imagecue.SoftwareBitmap) プロパティには、字幕画像の [**SoftwareBitmap**](https://docs.microsoft.com/uwp/api/windows.graphics.imaging.softwarebitmap) 表現が格納されています。 [**SoftwareBitmapSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.imaging.softwarebitmapsource) を作成し、[**SetBitmapAsync**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.imaging.softwarebitmapsource.SetBitmapAsync) を呼び出して、画像を XAML [**Image**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.image) コントロールに割り当てます。 **ImageCue** の [**Extent**](https://docs.microsoft.com/uwp/api/windows.media.core.imagecue.Extent) プロパティと [**Position**](https://docs.microsoft.com/uwp/api/windows.media.core.imagecue.Position) プロパティは、字幕画像のサイズと位置に関する情報を提供します。

[!code-cs[ImageSubtitleCueEntered](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetImageSubtitleCueEntered)]

## <a name="speech-cues"></a>音声キュー
Windows 10 Version 1703 以降では、UWP アプリで、再生されるメディアの単語の境界、文の境界、音声合成マークアップ言語 (SSML) ブックマークに応答するイベントの受信を登録できます。 これによって、[**SpeechSynthesizer**](https://docs.microsoft.com/uwp/api/Windows.Media.SpeechSynthesis.SpeechSynthesizer) クラスを使用して生成されたオーディオ ストリームを再生し、現在再生中の単語や文のテキストを表示するなど、これらのイベントに基づいて UI を更新できます。

このセクションに示した例では、クラス メンバー変数を使用して、合成および再生されるテキスト文字列を格納します。

[!code-cs[SpeechInputText](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetSpeechInputText)]

**SpeechSynthesizer** クラスの新しいインスタンスを作成します。 シンセサイザーの [**IncludeWordBoundaryMetadata**](https://docs.microsoft.com/uwp/api/windows.media.speechsynthesis.speechsynthesizeroptions.IncludeWordBoundaryMetadata) オプションと [**IncludeSentenceBoundaryMetadata**](https://docs.microsoft.com/uwp/api/windows.media.speechsynthesis.speechsynthesizeroptions.IncludeSentenceBoundaryMetadata) オプションを **true** に設定して、生成されたメディア ストリームにメタデータを含める必要があることを指定します。 [**SynthesizeTextToStreamAsync**](https://docs.microsoft.com/uwp/api/Windows.Media.SpeechSynthesis.SpeechSynthesizer.SynthesizeTextToStreamAsync) を呼び出して、合成された音声と対応するメタデータを含むストリームを生成します。 合成されたストリームから [**MediaSource**](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource) と [**MediaPlaybackItem**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem) を作成します。

[!code-cs[SynthesizeSpeech](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetSynthesizeSpeech)]

**MediaPlaybackItem** オブジェクトを使って音声メタデータ イベントを登録します。 この例では、ヘルパー メソッド **RegisterMetadataHandlerForSpeech** を使用して、イベントに登録します。 ラムダ式を使用して、[**TimedMetadataTracksChanged**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem.TimedMetadataTracksChanged) イベントのハンドラーを実装します。このイベントは、システムが **MediaPlaybackItem** に関連付けられたメタデータ トラック内の変更を検出したときに発生します。  状況によっては、再生項目が最初に解決されたときにメタデータ トラックが利用可能な場合があるため、**TimedMetadataTracksChanged** ハンドラーの外部でも、利用可能なメタデータ トラックをループ処理し、**RegisterMetadataHandlerForSpeech** を呼び出します。

[!code-cs[SpeechTracksChanged](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetSpeechTracksChanged)]

音声メタデータ イベントに登録した後、[**MediaPlayerElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.mediaplayerelement) 内で再生するために、**MediaItem** が [**MediaPlayer**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer) に割り当てられます。

[!code-cs[SpeechPlay](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetSpeechPlay)]

**RegisterMetadataHandlerForSpeech** ヘルパー メソッドで、**MediaPlaybackItem** の **TimedMetadataTracks** コレクション内のインデックスを指定して、[**TimedMetadataTrack**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack) クラスのインスタンスを取得します。 [**CueEntered**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.CueEntered) イベントと [**CueExited**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.CueExited) イベントに登録します。 次に、再生項目の **TimedMetadataTracks** コレクションで [**SetPresentationMode**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacktimedmetadatatracklist.SetPresentationMode) を呼び出して、アプリでこの再生項目のメタデータ キュー イベントを受信する必要があることをシステムに指示します。

[!code-cs[RegisterMetadataHandlerForWords](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetRegisterMetadataHandlerForWords)]

**CueEntered** イベントのハンドラーで、ハンドラーに渡された [**TimedMetadataTrack**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack) オブジェクトの [**TimedMetadataKind**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.TimedMetadataKind) プロパティを調べて、メタデータが音声用であるかどうかを確認します。 これは、複数の種類のメタデータについて、同じデータ キュー イベント ハンドラーを使っている場合に必要です。 関連付けられたメタデータ トラックが **TimedMetadataKind.Speech** 型である場合は、[**MediaCueEventArgs**](https://docs.microsoft.com/uwp/api/windows.media.core.mediacueeventargs) の **Cue** プロパティに格納されているデータ キューを、[**SpeechCue**](https://docs.microsoft.com/uwp/api/windows.media.core.speechcue) にキャストします。 音声キューの場合、メタデータ トラックに含まれている音声キューの種類は、**Label** プロパティを調べることによって特定されます。 このプロパティの値は、単語の境界の場合は "SpeechWord"、文の境界の場合は "SpeechSentence"、SSML ブックマークの場合は "SpeechBookmark" になります。 この例では、"SpeechWord" 値を検索し、この値が見つかった場合、**SpeechCue** の [**StartPositionInInput**](https://docs.microsoft.com/uwp/api/windows.media.core.speechcue.StartPositionInInput) プロパティと [**EndPositionInInput**](https://docs.microsoft.com/uwp/api/windows.media.core.speechcue.EndPositionInInput) プロパティを使用して、現在再生中の単語の入力テキスト内の場所を特定します。 この例では、単にデバッグ出力に各単語を出力します。

[!code-cs[SpeechWordCueEntered](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetSpeechWordCueEntered)]

## <a name="chapter-cues"></a>チャプター キュー
Windows 10 Version 1703 以降では、UWP アプリはメディア項目内のチャプターに対応するキューに登録できます。 この機能を使用するには、メディア コンテキストの [**MediaSource**](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource) オブジェクトを作成し、**MediaSource** から [**MediaPlaybackItem**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem) を作成します。

[!code-cs[ChapterCueLoadContent](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetChapterCueLoadContent)]

前の手順で作成された **MediaPlaybackItem** オブジェクトを使用して、チャプター メタデータ イベントに登録します。 この例では、ヘルパー メソッド **RegisterMetadataHandlerForChapterCues** を使用して、イベントに登録します。 ラムダ式を使用して、[**TimedMetadataTracksChanged**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem.TimedMetadataTracksChanged) イベントのハンドラーを実装します。このイベントは、システムが **MediaPlaybackItem** に関連付けられたメタデータ トラック内の変更を検出したときに発生します。 状況によっては、再生項目が最初に解決されたときにメタデータ トラックが利用可能な場合があるため、**TimedMetadataTracksChanged** ハンドラーの外部でも、利用可能なメタデータ トラックをループ処理し、**RegisterMetadataHandlerForChapterCues** を呼び出します。

[!code-cs[ChapterCueTracksChanged](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetChapterCueTracksChanged)]

チャプター メタデータ イベントに登録した後、[**MediaPlayerElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.mediaplayerelement) 内で再生するために、**MediaItem** が [**MediaPlayer**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer) に割り当てられます。

[!code-cs[ChapterCuePlay](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetChapterCuePlay)]

**RegisterMetadataHandlerForChapterCues** ヘルパー メソッドで、**MediaPlaybackItem** の **TimedMetadataTracks** コレクション内のインデックスを指定して、[**TimedMetadataTrack**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack) クラスのインスタンスを取得します。 [**CueEntered**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.CueEntered) イベントと [**CueExited**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.CueExited) イベントに登録します。 次に、再生項目の **TimedMetadataTracks** コレクションで [**SetPresentationMode**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacktimedmetadatatracklist.SetPresentationMode) を呼び出して、アプリでこの再生項目のメタデータ キュー イベントを受信する必要があることをシステムに指示します。

[!code-cs[RegisterMetadataHandlerForChapterCues](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetRegisterMetadataHandlerForChapterCues)]

**CueEntered** イベントのハンドラーで、ハンドラーに渡された [**TimedMetadataTrack**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack) オブジェクトの [**TimedMetadataKind**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.TimedMetadataKind) プロパティを調べて、メタデータがチャプター キュー用であるかどうかを確認します。これは、複数の種類のメタデータについて、同じデータ キュー イベント ハンドラーを使っている場合に必要です。 関連付けられたメタデータ トラックが **TimedMetadataKind.Chapter** 型である場合は、[**MediaCueEventArgs**](https://docs.microsoft.com/uwp/api/windows.media.core.mediacueeventargs) の **Cue** プロパティに格納されているデータ キューを、[**ChapterCue**](https://docs.microsoft.com/uwp/api/windows.media.core.chaptercue) にキャストします。 **ChapterCue** の [**Title**](https://docs.microsoft.com/uwp/api/windows.media.core.chaptercue.Title) プロパティには、再生中に到達したチャプターのタイトルが含まれています。

[!code-cs[ChapterCueEntered](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetChapterCueEntered)]

### <a name="seek-to-the-next-chapter-using-chapter-cues"></a>チャプター キューを使用して、次のチャプターをシークします。
再生中の項目内で現在のチャプターが変更されたときに通知を受け取るだけでなく、チャプター キューを使用して、再生中の項目内の次のチャプターをシークすることもできます。 次に示す例のメソッドでは、引数として、[**MediaPlayer**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer) と、現在再生中のメディア項目を表す [**MediaPlaybackItem**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem) を受け取ります。 [**TimedMetadataTracks**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem.TimedMetadataTracks) コレクションを検索して、いずれかのトラックで、[**TimedMetadataTrack**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack) の [**TimedMetadataKind**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.TimedMetadataKind) プロパティの値が **TimedMetadataKind.Chapter** であるかどうかを確認します。  チャプター トラックが見つかった場合、メソッドはトラックの [**Cues**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.Cues) コレクション内で各キューをループ処理し、[**StartTime**](https://docs.microsoft.com/uwp/api/windows.media.core.chaptercue.StartTime) がメディア プレーヤーの再生セッションの現在の [**Position**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacksession.Position) よりも大きい最初のキューを見つけます。 適切なキューが見つかったら、再生セッションの位置が更新され、UI でチャプター タイトルが更新されます。

[!code-cs[GoToNextChapter](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetGoToNextChapter)]

## <a name="extended-m3u-comments"></a>Extended M3U コメント
Windows 10 Version 1703 以降では、UWP アプリは、Extended M3U マニフェスト ファイル内のコメントに対応するキューに登録できます。 この例では、[**AdaptiveMediaSource**](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasource) を使用してメディア コンテンツを再生します。 詳しくは、「[アダプティブ ストリーミング](adaptive-streaming.md)」をご覧ください。 [**CreateFromUriAsync**](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasource.CreateFromUriAsync) または [**CreateFromStreamAsync**](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasource.CreateFromStreamAsync) を呼び出すことによって、コンテンツの **AdaptiveMediaSource** を作成します。 [**CreateFromAdaptiveMediaSource**](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource.CreateFromAdaptiveMediaSource) を呼び出して [**MediaSource**](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource) オブジェクトを作成し、**MediaSource** から [**MediaPlaybackItem**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem) を作成します。

[!code-cs[EXTM3ULoadContent](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetEXTM3ULoadContent)]

前の手順で作成された **MediaPlaybackItem** オブジェクトを使用して、M3U メタデータ イベントに登録します。 この例では、ヘルパー メソッド **RegisterMetadataHandlerForEXTM3UCues** を使用して、イベントに登録します。 ラムダ式を使用して、[**TimedMetadataTracksChanged**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem.TimedMetadataTracksChanged) イベントのハンドラーを実装します。このイベントは、システムが **MediaPlaybackItem** に関連付けられたメタデータ トラック内の変更を検出したときに発生します。 状況によっては、再生項目が最初に解決されたときにメタデータ トラックが利用可能な場合があるため、**TimedMetadataTracksChanged** ハンドラーの外部でも、利用可能なメタデータ トラックをループ処理し、**RegisterMetadataHandlerForEXTM3UCues** を呼び出します。

[!code-cs[EXTM3UCueTracksChanged](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetEXTM3UCueTracksChanged)]

M3U メタデータ イベントに登録した後、[**MediaPlayerElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.mediaplayerelement) 内で再生するために、**MediaItem** が [**MediaPlayer**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer) に割り当てられます。

[!code-cs[EXTM3UCuePlay](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetEXTM3UCuePlay)]

**RegisterMetadataHandlerForEXTM3UCues** ヘルパー メソッドで、**MediaPlaybackItem** の **TimedMetadataTracks** コレクション内のインデックスを指定して、[**TimedMetadataTrack**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack) クラスのインスタンスを取得します。 メタデータ トラックの DispatchType プロパティを確認します。トラックが M3U コメントを表す場合、この値は "EXTM3U" になります。 [**CueEntered**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.CueEntered) イベントと [**CueExited**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.CueExited) イベントに登録します。 次に、再生項目の **TimedMetadataTracks** コレクションで [**SetPresentationMode**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacktimedmetadatatracklist.SetPresentationMode) を呼び出して、アプリでこの再生項目のメタデータ キュー イベントを受信する必要があることをシステムに指示します。

[!code-cs[RegisterMetadataHandlerForEXTM3UCues](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetRegisterMetadataHandlerForEXTM3UCues)]

**CueEntered** イベントのハンドラーで、[**MediaCueEventArgs**](https://docs.microsoft.com/uwp/api/windows.media.core.mediacueeventargs) の **Cue** プロパティに含まれるデータ キューを、[**DataCue**](https://docs.microsoft.com/uwp/api/windows.media.core.datacue) にキャストします。  **DataCue** とキューの [**Data**](https://docs.microsoft.com/uwp/api/windows.media.core.datacue.Data) プロパティが null ではないことを確認します。 Extended EMU コメントは、UTF-16、リトル エンディアン、null 終了文字列の形式で提供されます。 新しい **DataReader** を作成し、[**DataReader.FromBuffer**](https://docs.microsoft.com/uwp/api/windows.storage.streams.datareader.FromBuffer) を呼び出してキューのデータを読み取ります。 リーダーの [**UnicodeEncoding**](https://docs.microsoft.com/uwp/api/windows.storage.streams.datareader.UnicodeEncoding) プロパティを [**Utf16LE**](https://docs.microsoft.com/uwp/api/windows.storage.streams.unicodeencoding) に設定して、正しい形式でデータを読み取ります。 **Data** フィールドの半分の長さを指定して、[**ReadString**](https://docs.microsoft.com/uwp/api/windows.storage.streams.datareader.ReadString) を呼び出してデータを読み取ります。各文字は 2 バイトのサイズであるため、null 終端文字を削除するには、1を減算します。 この例では、M3U コメントは、単にデバッグ出力に書き込まれます。

[!code-cs[EXTM3UCueEntered](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetEXTM3UCueEntered)]

## <a name="id3-tags"></a>ID3 タグ
Windows 10 Version 1703 以降では、UWP アプリは、Http Live Streaming (HLS) コンテンツ内の ID3 タグに対応するキューに登録できます。 この例では、[**AdaptiveMediaSource**](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasource) を使用してメディア コンテンツを再生します。 詳しくは、「[アダプティブ ストリーミング](adaptive-streaming.md)」をご覧ください。 [**CreateFromUriAsync**](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasource.CreateFromUriAsync) または [**CreateFromStreamAsync**](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasource.CreateFromStreamAsync) を呼び出すことによって、コンテンツの **AdaptiveMediaSource** を作成します。 [**CreateFromAdaptiveMediaSource**](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource.CreateFromAdaptiveMediaSource) を呼び出して [**MediaSource**](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource) オブジェクトを作成し、**MediaSource** から [**MediaPlaybackItem**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem) を作成します。

[!code-cs[EXTM3ULoadContent](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetEXTM3ULoadContent)]

前の手順で作成された **MediaPlaybackItem** オブジェクトを使用して、ID3 タグ イベントに登録します。 この例では、ヘルパー メソッド **RegisterMetadataHandlerForID3Cues** を使用して、イベントに登録します。 ラムダ式を使用して、[**TimedMetadataTracksChanged**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem.TimedMetadataTracksChanged) イベントのハンドラーを実装します。このイベントは、システムが **MediaPlaybackItem** に関連付けられたメタデータ トラック内の変更を検出したときに発生します。 状況によっては、再生項目が最初に解決されたときにメタデータ トラックが利用可能な場合があるため、**TimedMetadataTracksChanged** ハンドラーの外部でも、利用可能なメタデータ トラックをループ処理し、**RegisterMetadataHandlerForID3Cues** を呼び出します。

[!code-cs[ID3LoadContent](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetID3LoadContent)]

ID3 メタデータ イベントに登録した後、[**MediaPlayerElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.mediaplayerelement) 内で再生するために、**MediaItem** が [**MediaPlayer**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer) に割り当てられます。

[!code-cs[ID3CuePlay](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetID3CuePlay)]


**RegisterMetadataHandlerForID3Cues** ヘルパー メソッドで、**MediaPlaybackItem** の **TimedMetadataTracks** コレクション内のインデックスを指定して、[**TimedMetadataTrack**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack) クラスのインスタンスを取得します。 メタデータ トラックの DispatchType プロパティを確認します。トラックが ID3 タグを表す場合、GUID 文字列 "15260DFFFF49443320FF49443320000F" を含む値になります。 [**CueEntered**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.CueEntered) イベントと [**CueExited**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.CueExited) イベントに登録します。 次に、再生項目の **TimedMetadataTracks** コレクションで [**SetPresentationMode**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacktimedmetadatatracklist.SetPresentationMode) を呼び出して、アプリでこの再生項目のメタデータ キュー イベントを受信する必要があることをシステムに指示します。

[!code-cs[RegisterMetadataHandlerForID3Cues](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetRegisterMetadataHandlerForID3Cues)]

**CueEntered** イベントのハンドラーで、[**MediaCueEventArgs**](https://docs.microsoft.com/uwp/api/windows.media.core.mediacueeventargs) の **Cue** プロパティに含まれるデータ キューを、[**DataCue**](https://docs.microsoft.com/uwp/api/windows.media.core.datacue) にキャストします。  **DataCue** とキューの [**Data**](https://docs.microsoft.com/uwp/api/windows.media.core.datacue.Data) プロパティが null ではないことを確認します。 Extended EMU コメントは、トランスポート ストリーム内の未加工のバイトの形式で提供されます ([http://id3.org/id3v2.4.0-structure](http://id3.org/id3v2.4.0-structure) をご覧ください)。 新しい **DataReader** を作成し、[**DataReader.FromBuffer**](https://docs.microsoft.com/uwp/api/windows.storage.streams.datareader.FromBuffer) を呼び出してキューのデータを読み取ります。  この例では、ID3 タグのヘッダー値が、キュー データから読み取られ、デバッグ出力に書き込まれます。

[!code-cs[ID3CueEntered](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetID3CueEntered)]

## <a name="fragmented-mp4-emsg-boxes"></a>Fragmented mp4 emsg ボックス
Windows 10 Version 1703 以降では、UWP アプリは、Fragmented mp4 ストリームの emsg ボックスに対応するキューに登録できます。 この種類のメタデータの使用例として、コンテンツのライブ ストリーミング中に広告を再生することをクライアント アプリケーションに通知するコンテンツ プロバイダーがあります。 この例では、[**AdaptiveMediaSource**](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasource) を使用してメディア コンテンツを再生します。 詳しくは、「[アダプティブ ストリーミング](adaptive-streaming.md)」をご覧ください。 [**CreateFromUriAsync**](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasource.CreateFromUriAsync) または [**CreateFromStreamAsync**](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasource.CreateFromStreamAsync) を呼び出すことによって、コンテンツの **AdaptiveMediaSource** を作成します。 [**CreateFromAdaptiveMediaSource**](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource.CreateFromAdaptiveMediaSource) を呼び出して [**MediaSource**](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource) オブジェクトを作成し、**MediaSource** から [**MediaPlaybackItem**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem) を作成します。

[!code-cs[EmsgLoadContent](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetEmsgLoadContent)]

前の手順で作成された **MediaPlaybackItem** オブジェクトを使用して、emsg ボックス イベントに登録します。 この例では、ヘルパー メソッド **RegisterMetadataHandlerForEmsgCues** を使用して、イベントに登録します。 ラムダ式を使用して、[**TimedMetadataTracksChanged**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybackitem.TimedMetadataTracksChanged) イベントのハンドラーを実装します。このイベントは、システムが **MediaPlaybackItem** に関連付けられたメタデータ トラック内の変更を検出したときに発生します。 状況によっては、再生項目が最初に解決されたときにメタデータ トラックが利用可能な場合があるため、**TimedMetadataTracksChanged** ハンドラーの外部でも、利用可能なメタデータ トラックをループ処理し、**RegisterMetadataHandlerForEmsgCues** を呼び出します。

[!code-cs[ID3LoadContent](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetID3LoadContent)]

emsg ボックス メタデータ イベントに登録した後、[**MediaPlayerElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.mediaplayerelement) 内で再生するために、**MediaItem** が [**MediaPlayer**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer) に割り当てられます。

[!code-cs[EmsgCuePlay](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetEmsgCuePlay)]


**RegisterMetadataHandlerForEmsgCues** ヘルパー メソッドで、**MediaPlaybackItem** の **TimedMetadataTracks** コレクション内のインデックスを指定して、[**TimedMetadataTrack**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack) クラスのインスタンスを取得します。 メタデータ トラックの DispatchType プロパティを確認します。トラックが emsg ボックスを表す場合、この値は "emsg:mp4" になります。 [**CueEntered**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.CueEntered) イベントと [**CueExited**](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatatrack.CueExited) イベントに登録します。 次に、再生項目の **TimedMetadataTracks** コレクションで [**SetPresentationMode**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacktimedmetadatatracklist.SetPresentationMode) を呼び出して、アプリでこの再生項目のメタデータ キュー イベントを受信する必要があることをシステムに指示します。


[!code-cs[RegisterMetadataHandlerForEmsgCues](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetRegisterMetadataHandlerForEmsgCues)]


**CueEntered** イベントのハンドラーで、[**MediaCueEventArgs**](https://docs.microsoft.com/uwp/api/windows.media.core.mediacueeventargs) の **Cue** プロパティに含まれるデータ キューを、[**DataCue**](https://docs.microsoft.com/uwp/api/windows.media.core.datacue) にキャストします。  **DataCue** オブジェクトが null でないことを確認します。 emsg ボックスのプロパティは、メディア パイプラインによって、DataCue オブジェクトの [**Properties**](https://docs.microsoft.com/uwp/api/windows.media.core.datacue.Properties) コレクション内のカスタム プロパティとして提供されます。 この例では、**[TryGetValue](https://docs.microsoft.com/uwp/api/windows.foundation.collections.propertyset.trygetvalue)** メソッドを使用して、複数の異なるプロパティ値の抽出を試行します。 このメソッドが null を返す場合、要求したプロパティが emsg ボックス内に存在しないことを意味するため、代わりに既定値が設定されます。

この例の次の部分は、広告の再生がトリガーされるがシナリオを示しています。これに該当するのは、前の手順で取得した *scheme_id_uri* プロパティの値が "urn:scte:scte35:2013:xml" である場合です ([http://dashif.org/identifiers/event-schemes/](http://dashif.org/identifiers/event-schemes/) をご覧ください)。 標準では、冗長性のために、この emsg を複数回送信することを推奨しているため、この例では、処理済みの emsg ID のリストを保持し、新しいメッセージのみを処理していることに注意してください。 [**DataReader.FromBuffer**](https://docs.microsoft.com/uwp/api/windows.storage.streams.datareader.FromBuffer) を呼び出してキュー データを読み取る新しい **DataReader** を作成し、[**UnicodeEncoding**](https://docs.microsoft.com/uwp/api/windows.storage.streams.datareader.UnicodeEncoding) プロパティを設定してエンコードを UTF-8 に設定した後、データを読み取ります。 この例では、メッセージ ペイロードがデバッグ出力に書き込まれます。 実際のアプリは、ペイロード データを使用して広告の再生をスケジュールします。

[!code-cs[EmsgCueEntered](./code/MediaSource_RS1/cs/MainPage_Cues.xaml.cs#SnippetEmsgCueEntered)]


## <a name="related-topics"></a>関連トピック

* [メディア再生](media-playback.md)
* [メディア項目、プレイリスト、トラック](media-playback-with-mediasource.md)


 




