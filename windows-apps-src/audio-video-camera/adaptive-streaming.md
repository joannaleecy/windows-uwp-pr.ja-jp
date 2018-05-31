---
author: drewbatgit
ms.assetid: AE98C22B-A071-4206-ABBB-C0F0FB7EF33C
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリにアダプティブ ストリーミング マルチメディア コンテンツの再生を追加する方法について説明します。 現在、この機能では、HTTP ライブ ストリーミング (HLS) と Dynamic Adaptive Streaming over HTTP (DASH) コンテンツの再生がサポートされています。
title: アダプティブ ストリーミング
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: ac00104917d41a48abda97c2d5d37c0ced3ab5e9
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1816647"
---
# <a name="adaptive-streaming"></a>アダプティブ ストリーミング


この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリにアダプティブ ストリーミング マルチメディア コンテンツの再生を追加する方法について説明します。 現在、この機能では、HTTP ライブ ストリーミング (HLS) と Dynamic Adaptive Streaming over HTTP (DASH) コンテンツの再生がサポートされています。

サポートされている HLS プロトコル タグの一覧については、「[HLS タグのサポート](hls-tag-support.md)」をご覧ください。 

サポートされている DASH プロファイルの一覧については、「[DASH プロファイルのサポート](dash-profile-support.md)」をご覧ください。 

> [!NOTE] 
> この記事のコードは、UWP の[アダプティブ ストリーミングのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/AdaptiveStreaming)を基にしています。

## <a name="simple-adaptive-streaming-with-mediaplayer-and-mediaplayerelement"></a>MediaPlayer と MediaPlayerElement を使った簡単なアダプティブ ストリーミング

UWP アプリでアダプティブ ストリーミング メディアを再生するには、DASH または HLS のマニフェスト ファイルを指す **Uri** オブジェクトを作成します。 [**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer) クラスのインスタンスを作成します。 [**MediaSource.CreateFromUri**](https://msdn.microsoft.com/library/windows/apps/dn930912) を呼び出して新しい **MediaSource** オブジェクトを作成し、それを **MediaPlayer** の [**Source**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.Source) プロパティに設定します。 [**Play**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.Play) を呼び出してメディア コンテンツの作成を開始します。

[!code-cs[DeclareMediaPlayer](./code/AdaptiveStreaming_RS1/cs/MainPage.xaml.cs#SnippetDeclareMediaPlayer)]

[!code-cs[ManifestSourceNoUI](./code/AdaptiveStreaming_RS1/cs/MainPage.xaml.cs#SnippetManifestSourceNoUI)]

上の例では、メディア コンテンツのオーディオが再生されますが、UI 内のコンテンツは自動的にレンダリングされません。 ビデオ コンテンツを再生するほとんどのアプリは、XAML ページでコンテンツをレンダリングします。  これを行うには、XAML ページに [ **MediaPlayerElement** ](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaPlayerElement) コントロールを追加します。

[!code-xml[MediaPlayerElementXAML](./code/AdaptiveStreaming_RS1/cs/MainPage.xaml#SnippetMediaPlayerElementXAML)]

[**MediaSource.CreateFromUri**](https://msdn.microsoft.com/library/windows/apps/dn930912) を呼び出して、DASH や HLS のマニフェスト ファイルの URI から **MediaSource** を作成します。 その後、**MediaPlayerElement** の [**Source**](https://msdn.microsoft.com/library/windows/apps/br227420) プロパティを設定します。 **MediaPlayerElement**によって、コンテンツの新しい **MediaPlayer** オブジェクトが自動的に作成されます。 **MediaPlayer** で **Play** を呼び出して、コンテンツの再生を開始できます。

[!code-cs[ManifestSource](./code/AdaptiveStreaming_RS1/cs/MainPage.xaml.cs#SnippetManifestSource)]

> [!NOTE] 
> Windows 10 バージョン 1607 以降、メディア項目の再生には、**MediaPlayer** クラスを使うことをお勧めします。 **MediaPlayerElement** は、XAML ページの **MediaPlayer** コンテンツをレンダリングするために使われる軽量の XAML コントロールです。 下位互換性を確保するため、**MediaElement**コントロールも引き続きサポートされています。 **MediaPlayer** と **MediaPlayerElement** を使ってメディア コンテンツを再生する方法について詳しくは、「[MediaPlayer を使ったオーディオとビデオの再生](play-audio-and-video-with-mediaplayer.md)」をご覧ください。 **MediaSource** と関連の API を使ってメディア コンテンツを操作する方法について詳しくは、「[メディア項目、プレイリスト、トラック](media-playback-with-mediasource.md)」をご覧ください。

## <a name="adaptive-streaming-with-adaptivemediasource"></a>AdaptiveMediaSource を使ったアダプティブ ストリーミング

アプリで、より高度なアダプティブ ストリーミング機能 (カスタム HTTP ヘッダーの指定、現在のダウンロードや再生のビットレートの監視、アダプティブ ストリーミングのビットレートをシステムで切り替えるタイミングを決定する比率の調整など) を必要とする場合は、**[AdaptiveMediaSource](https://docs.microsoft.com/uwp/api/Windows.Media.Streaming.Adaptive.AdaptiveMediaSource)** オブジェクトを使います。

アダプティブ ストリーミング API は、[**Windows.Media.Streaming.Adaptive**](https://msdn.microsoft.com/library/windows/apps/dn931279) 名前空間にあります。 この記事の例には、以下の名前空間の API が使われています。

[!code-cs[AdaptiveStreamingUsing](./code/AdaptiveStreaming_RS1/cs/MainPage.xaml.cs#SnippetAdaptiveStreamingUsing)]

## <a name="initialize-an-adaptivemediasource-from-a-uri"></a>URI から AdaptiveMediaSource を初期化する

[**CreateFromUriAsync**](https://msdn.microsoft.com/library/windows/apps/dn931261) を呼び出し、アダプティブ ストリーミング マニフェスト ファイルの URI で、**AdaptiveMediaSource** を初期化します。 このメソッドから返される [**AdaptiveMediaSourceCreationStatus**](https://msdn.microsoft.com/library/windows/apps/dn946917) の値を利用して、メディア ソースが正しく作成されたかどうかを確認できます。 正しく作成されている場合、オブジェクトを **MediaPlayer** のストリーム ソースとして設定できます。そのためには、[**MediaSource.CreateFromAdaptiveMediaSource**](https://docs.microsoft.com/uwp/api/Windows.Media.Core.MediaSource.AdaptiveMediaSource) を呼び出して **MediaSource** オブジェクトを作成し、このオブジェクトをメディア プレーヤーの [**Source**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer.Source) プロパティに割り当てます。 この例では、[**AvailableBitrates**](https://msdn.microsoft.com/library/windows/apps/dn931257) プロパティを照会することによって、このストリームで利用できる最大ビットレートを特定し、その値が初期ビットレートとして設定されます。 またこの例では、**AdaptiveMediaSource** のいくつかのイベントのハンドラーも登録します。これらのイベントについては、この記事の後半で説明します。

[!code-cs[InitializeAMS](./code/AdaptiveStreaming_RS1/cs/MainPage.xaml.cs#SnippetInitializeAMS)]

## <a name="initialize-an-adaptivemediasource-using-httpclient"></a>HttpClient を使用して AdaptiveMediaSource を初期化する

マニフェスト ファイルを取得するためにカスタム HTTP ヘッダーを設定する場合は、[**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) オブジェクトを作成し、目的のヘッダーを設定してから、そのオブジェクトを **CreateFromUriAsync** のオーバーロードに渡すことができます。

[!code-cs[InitializeAMSWithHttpClient](./code/AdaptiveStreaming_RS1/cs/MainPage.xaml.cs#SnippetInitializeAMSWithHttpClient)]

[**DownloadRequested**](https://msdn.microsoft.com/library/windows/apps/dn931272) イベントは、システムがサーバーからリソースの取得を試みるときに発生します。 イベント ハンドラーに渡される [**AdaptiveMediaSourceDownloadRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn946935) によって、要求されているリソースに関する情報 (リソースの種類や URI など) を提供するプロパティが公開されます。

## <a name="modify-resource-request-properties-using-the-downloadrequested-event"></a>DownloadRequested イベントを使ってリソース要求プロパティを変更する

**DownloadRequested** イベント ハンドラーを使って、リソース要求を変更することができます。この場合、イベント引数によって提供される [**AdaptiveMediaSourceDownloadResult**](https://msdn.microsoft.com/library/windows/apps/dn946942) オブジェクトのプロパティを更新します。 次の例では、結果オブジェクトの [**ResourceUri**](https://msdn.microsoft.com/library/windows/apps/dn931250) プロパティを更新して、リソースの取得元となる URI を変更します。 メディア セグメントのバイト範囲オフセットや長さを書き換えたり、次の例に示すようにリソース URI を変更して完全なリソースをダウンロードし、バイト範囲のオフセットと長さを null に設定することもできます。

結果オブジェクトの [**Buffer**](https://msdn.microsoft.com/library/windows/apps/dn946943) プロパティや [**InputStream**](https://msdn.microsoft.com/library/windows/apps/dn931249) プロパティを設定することによって、要求したリソースの内容を置き換えることができます。 次の例では、**Buffer** プロパティを設定することによって、マニフェスト リソースの内容が置き換わります。 非同期的に取得したデータを使ってリソース要求を更新する場合は (リモート サーバーや非同期ユーザー認証からデータを取得する場合など)、[**AdaptiveMediaSourceDownloadRequestedEventArgs.GetDeferral**](https://msdn.microsoft.com/library/windows/apps/dn946936) を呼び出して遅延を取得する必要があります。その後、操作が完了して、ダウンロード要求操作が継続可能なことをシステムに通知するときに、[**Complete**](https://msdn.microsoft.com/library/windows/apps/dn946934) を呼び出してください。

[!code-cs[AMSDownloadRequested](./code/AdaptiveStreaming_RS1/cs/MainPage.xaml.cs#SnippetAMSDownloadRequested)]

## <a name="use-bitrate-events-to-manage-and-respond-to-bitrate-changes"></a>ビットレート イベントを使用して、ビットレートの変更を管理し変更に応答する

**AdaptiveMediaSource** オブジェクトは、ダウンロードや再生のビットレートが変わったときに対応できるようにするイベントを提供します。 この例では、現在のビットレートが UI で簡単に更新されます。 また、アダプティブ ストリーミングのビットレートをシステムで切り替えるタイミングを決定する比率を変更できることに注意してください。 詳しくは、[**AdvancedSettings**](https://msdn.microsoft.com/library/windows/apps/mt628697) プロパティをご覧ください。

[!code-cs[AMSBitrateEvents](./code/AdaptiveStreaming_RS1/cs/MainPage.xaml.cs#SnippetAMSBitrateEvents)]

## <a name="handle-download-completion-and-failure-events"></a>ダウンロードの完了と失敗イベントを処理する
**AdaptiveMediaSource** オブジェクトは、要求されたリソースのダウンロードが失敗したときに、[**DownloadFailed**](https://docs.microsoft.com/uwp/api/Windows.Media.Streaming.Adaptive.AdaptiveMediaSource.DownloadFailed) イベントを生成します。 このイベントを使用して、エラーに応じて UI を更新できます。 このイベントを使用して、ダウンロード操作とエラーに関する統計情報をログに記録することもできます。 

イベント ハンドラーに渡される [**AdaptiveMediaSourceDownloadFailedEventArgs**](https://docs.microsoft.com/uwp/api/Windows.Media.Streaming.Adaptive.AdaptiveMediaSourceDownloadFailedEventArgs) オブジェクトには、リソースの種類、リソースの URI、ストリーム内のエラーが発生した位置など、失敗したリソースのダウンロードに関するメタデータが含まれています。 [**RequestId**](https://docs.microsoft.com/uwp/api/Windows.Media.Streaming.Adaptive.AdaptiveMediaSourceDownloadFailedEventArgs.RequestId) は、複数のイベント間で、個々の要求に関する状態情報を関連付けるために使用できる、システムで生成された一意の識別子を取得します。

[**Statistics**](https://docs.microsoft.com/uwp/api/Windows.Media.Streaming.Adaptive.AdaptiveMediaSourceDownloadFailedEventArgs.Statistics) プロパティは、[**AdaptiveMediaSourceDownloadStatistics**](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasourcedownloadstatistics) オブジェクトを返します。このオブジェクトは、イベントの発生時や、ダウンロード操作のさまざまなマイルストーンのタイミングで受信したバイト数に関する詳細情報を提供します。 この情報は、アダプティブ ストリーミングの実装でパフォーマンスの問題を識別するためにろぐに記録できます。

[!code-cs[AMSDownloadFailed](./code/AdaptiveStreaming_RS1/cs/MainPage.xaml.cs#SnippetAMSDownloadFailed)]


[**DownloadCompleted**](https://docs.microsoft.com/uwp/api/Windows.Media.Streaming.Adaptive.AdaptiveMediaSource.DownloadCompleted) イベントは、リソースのダウンロードが完了したときに発生し、**DownloadFailed** イベントと同様のデータを提供します。 ここでも、1 つの要求のイベントを関連付けるために **RequestId** が提供されます。 また、ダウンロード統計情報のログ記録を有効にするために、**AdaptiveMediaSourceDownloadStatistics** オブジェクトが提供されます。

[!code-cs[AMSDownloadCompleted](./code/AdaptiveStreaming_RS1/cs/MainPage.xaml.cs#SnippetAMSDownloadCompleted)]

## <a name="gather-adaptive-streaming-telemetry-data-with-adaptivemediasourcediagnostics"></a>AdaptiveMediaSourceDiagnostics によってアダプティブ ストリーミングの利用統計情報を収集する
**AdaptiveMediaSource** は、[**AdaptiveMediaSourceDiagnostics**](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasourcediagnostics) オブジェクトを返す [**Diagnostics**](https://docs.microsoft.com/uwp/api/Windows.Media.Streaming.Adaptive.AdaptiveMediaSource?branch=master.Diagnostics) プロパティを公開します。 このオブジェクトを使って、[**DiagnosticAvailable**](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasourcediagnostics.DiagnosticAvailable) イベントを登録します。 このイベントは、利用統計情報の収集に使用することを目的としており、実行時にアプリの動作を変更するために使用することはできません。 この診断イベントは、さまざまな理由で発生します。 イベントが発生した理由を特定するには、イベントに渡される [**AdaptiveMediaSourceDiagnosticAvailableEventArgs**](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasourcediagnosticavailableeventargs) オブジェクトの [**DiagnosticType**](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasourcediagnosticavailableeventargs.DiagnosticType) プロパティを確認します。 潜在的な理由には、要求されたリソースへのアクセス時のエラーや、ストリーミング マニフェスト ファイルの解析時のエラーが含まれます。 診断イベントをトリガーできる状況の一覧については、[**AdaptiveMediaSourceDiagnosticType**](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasourcediagnostictype) を参照してください。 他のアダプティブ ストリーミング イベントの引数と同様に、**AdaptiveMediaSourceDiagnosticAvailableEventArgs** は、さまざまなイベントの間で要求情報を関連付けるための **RequestId** プロパティを提供します。

[!code-cs[AMSDiagnosticAvailable](./code/AdaptiveStreaming_RS1/cs/MainPage.xaml.cs#SnippetAMSDiagnosticAvailable)]

## <a name="defer-binding-of-adaptive-streaming-content-for-items-in-a-playback-list-by-using-mediabinder"></a>MediaBinder を使用して、再生リスト内の項目のアダプティブ ストリーミング コンテンツのバインドを延期する
[**MediaBinder**](https://docs.microsoft.com/uwp/api/Windows.Media.Core.MediaBinder) クラスによって、[**MediaPlaybackList**](https://msdn.microsoft.com/library/windows/apps/dn930955) 内のメディア コンテンツのバインドを延期することができます。 Windows 10 Version 1703 以降では、バインドされるコンテンツとして [**AdaptiveMediaSource**](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasource) を指定できます。 アダプティブ メディア ソースの遅延バインドのプロセスの大部分は、「[メディア項目、プレイリスト、トラック](media-playback-with-mediasource.md)」で説明されている、他の種類のメディアのバインドと同じです。 

**MediaBinder** インスタンスを作成し、アプリで定義された、バインドされるコンテンツを識別するための [**Token**](https://docs.microsoft.com/uwp/api/Windows.Media.Core.MediaBinder.Token) 文字列を設定して、[**Binding**](https://docs.microsoft.com/uwp/api/Windows.Media.Core.MediaBinder.Binding) イベントに登録します。 [**MediaSource.CreateFromMediaBinder**](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource.createfrommediabinder) を呼び出すことによって、**Binder** から **MediaSource** を作成します。 次に、**MediaSource** から **MediaPlaybackItem** を作成し、再生リストに追加します。

[!code-cs[InitMediaBinder](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetInitMediaBinder)]

**Binding** イベント ハンドラーでは、トークン文字列を使用してバインドされるコンテンツを識別し、**[CreateFromStreamAsync](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasource.createfromstreamasync)** または **[CreateFromUriAsync](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasource.createfromuriasync)** のオーバーロードを呼び出すことによってアダプティブ メディア ソースを作成します。 これらは非同期メソッドであるため、最初に [**MediaBindingEventArgs.GetDeferral**](https://docs.microsoft.com/uwp/api/windows.media.core.mediabindingeventargs.GetDeferral) メソッドを呼び出して、操作が完了するまで待機してから続行するようにシステムに指示する必要があります。  **[SetAdaptiveMediaSource](https://docs.microsoft.com/uwp/api/windows.media.core.mediabindingeventargs.setadaptivemediasource)** を呼び出すことによって、バインドされるコンテンツとして、アダプティブ メディア ソースを設定します。 最後に、操作が完了した後、[**Deferral.Complete**](https://docs.microsoft.com/uwp/api/windows.foundation.deferral.Complete) を呼び出して、システムに続行を指示します。

[!code-cs[BinderBindingAMS](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetBinderBindingAMS)]

バインドされているアダプティブ メディア ソースのイベント ハンドラーを登録する場合は、**MediaPlaybackList** の [**CurrentItemChanged**](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacklist.CurrentItemChanged) イベントのハンドラーでこれを実行できます。 [**CurrentMediaPlaybackItemChangedEventArgs.NewItem**](https://docs.microsoft.com/uwp/api/windows.media.playback.currentmediaplaybackitemchangedeventargs.NewItem) プロパティには、リスト内で現在再生中の新しい **MediaPlaybackItem** が含まれます。 新しい項目を表す **AdaptiveMediaSource** インスタンスを取得するには、**MediaPlaybackItem** の [**Source**](https://docs.microsoft.com/uwp/api/Windows.Media.Playback.MediaPlaybackItem.Source) プロパティにアクセスし、次にメディア ソースの [**AdaptiveMediaSource**](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource.AdaptiveMediaSource) プロパティにアクセスします。 新しい再生項目が **AdaptiveMediaSource** ではない場合、このプロパティは null になるため、このオブジェクトのイベントのハンドラーを登録する前に、これが null であることをテストする必要があります。

[!code-cs[AMSBindingCurrentItemChanged](./code/MediaSource_RS1/cs/MainPage.xaml.cs#SnippetAMSBindingCurrentItemChanged)]

## <a name="related-topics"></a>関連トピック
* [メディア再生](media-playback.md)
* [HLS タグのサポート](hls-tag-support.md) 
* [DASH プロファイルのサポート](dash-profile-support.md) 
* [MediaPlayer を使ったオーディオとビデオの再生](play-audio-and-video-with-mediaplayer.md)
* [バックグラウンドでのメディアの再生](background-audio.md) 





