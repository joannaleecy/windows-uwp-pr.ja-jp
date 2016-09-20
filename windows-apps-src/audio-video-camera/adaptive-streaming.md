---
author: drewbatgit
ms.assetid: AE98C22B-A071-4206-ABBB-C0F0FB7EF33C
description: "この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリにアダプティブ ストリーミング マルチメディア コンテンツの再生を追加する方法について説明します。 現在、この機能では、HTTP ライブ ストリーミング (HLS) と Dynamic Adaptive Streaming over HTTP (DASH) コンテンツの再生がサポートされています。"
title: "アダプティブ ストリーミング"
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: 8ebf90b02fcfbb4349ba2b303d9c91727b731ad7

---

# アダプティブ ストリーミング

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください \]

この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリにアダプティブ ストリーミング マルチメディア コンテンツの再生を追加する方法について説明します。 現在、この機能では、HTTP ライブ ストリーミング (HLS) と Dynamic Adaptive Streaming over HTTP (DASH) コンテンツの再生がサポートされています。

## MediaElement を使った簡単なアダプティブ ストリーミング

XAML ベースのアプリでアダプティブ ストリーミング マルチメディアを表示するには、ページに [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) コントロールを追加します。

[!code-xml[MediaElementXAML](./code/AdaptiveStreaming_Win10/cs/MainPage.xaml#SnippetMediaElementXAML)]

**MediaElement** の [**Source**](https://msdn.microsoft.com/library/windows/apps/br227420) プロパティを、DASH や HLS のマニフェスト ファイルの URI に設定します。

[!code-cs[ManifestSource](./code/AdaptiveStreaming_Win10/cs/MainPage.xaml.cs#SnippetManifestSource)]

## AdaptiveMediaSource を使ったアダプティブ ストリーミング

アプリで、より高度なアダプティブ ストリーミング機能 (カスタム HTTP ヘッダーの指定、現在のダウンロードや再生のビットレートの監視、アダプティブ ストリーミングのビットレートをシステムで切り替えるタイミングを決定する比率の調整など) を必要とする場合は、[**AdaptiveMediaSource**](https://msdn.microsoft.com/library/windows/apps/dn946912) オブジェクトを使います。

アダプティブ ストリーミング API は、[**Windows.Media.Streaming.Adaptive**](https://msdn.microsoft.com/library/windows/apps/dn931279) 名前空間にあります。

[!code-cs[AdaptiveStreamingUsing](./code/AdaptiveStreaming_Win10/cs/MainPage.xaml.cs#SnippetAdaptiveStreamingUsing)]

[**CreateFromUriAsync**](https://msdn.microsoft.com/library/windows/apps/dn931261) を呼び出し、アダプティブ ストリーミング マニフェスト ファイルの URI で、**AdaptiveMediaSource** を初期化します。 このメソッドから返される [**AdaptiveMediaSourceCreationStatus**](https://msdn.microsoft.com/library/windows/apps/dn946917) の値を利用して、メディア ソースが正しく作成されたかどうかを確認できます。 正しく作成された場合、[**SetMediaStreamSource**](https://msdn.microsoft.com/library/windows/apps/dn299029) を呼び出すことにより、オブジェクトを **MediaElement** のストリーム ソースとして設定できます。 この例では、[**AvailableBitrates**](https://msdn.microsoft.com/library/windows/apps/dn931257) プロパティを照会することによって、このストリームで利用できる最大ビットレートを特定し、その値が初期ビットレートとして設定されます。 またこの例では、[**DownloadRequested**](https://msdn.microsoft.com/library/windows/apps/dn931272) イベント、[**DownloadBitrateChanged**](https://msdn.microsoft.com/library/windows/apps/dn931269) イベント、および [**PlaybackBitrateChanged**](https://msdn.microsoft.com/library/windows/apps/dn931278) イベントのハンドラーも登録します。これらのイベントについては、この記事の後半で説明します。

[!code-cs[InitializeAMS](./code/AdaptiveStreaming_Win10/cs/MainPage.xaml.cs#SnippetInitializeAMS)]

マニフェスト ファイルを取得するためにカスタム HTTP ヘッダーを設定する場合は、[**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) オブジェクトを作成し、目的のヘッダーを設定してから、そのオブジェクトを **CreateFromUriAsync** のオーバーロードに渡すことができます。

[!code-cs[InitializeAMSWithHttpClient](./code/AdaptiveStreaming_Win10/cs/MainPage.xaml.cs#SnippetInitializeAMSWithHttpClient)]

[**DownloadRequested**](https://msdn.microsoft.com/library/windows/apps/dn931272) イベントは、システムがサーバーからリソースを取得しようとするときに発生します。 イベント ハンドラーに渡される [**AdaptiveMediaSourceDownloadRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn946935) によって、要求されているリソースに関する情報 (リソースの種類や URI など) を提供するプロパティが公開されます。

**DownloadRequested** イベント ハンドラーを使って、リソース要求を変更することができます。この場合、イベント引数によって提供される [**AdaptiveMediaSourceDownloadResult**](https://msdn.microsoft.com/library/windows/apps/dn946942) オブジェクトのプロパティを更新します。 次の例では、結果オブジェクトの [**ResourceUri**](https://msdn.microsoft.com/library/windows/apps/dn931250) プロパティを更新して、リソースの取得元となる URI を変更します。

結果オブジェクトの [**Buffer**](https://msdn.microsoft.com/library/windows/apps/dn946943) プロパティや [**InputStream**](https://msdn.microsoft.com/library/windows/apps/dn931249) プロパティを設定することによって、要求したリソースの内容を置き換えることができます。 次の例では、**Buffer** プロパティを設定することによって、マニフェスト リソースの内容が置き換わります。 非同期的に取得したデータを使ってリソース要求を更新する場合は (リモート サーバーや非同期ユーザー認証からデータを取得する場合など)、[**AdaptiveMediaSourceDownloadRequestedEventArgs.GetDeferral**](https://msdn.microsoft.com/library/windows/apps/dn946936) を呼び出して遅延を取得する必要があります。その後、操作が完了して、ダウンロード要求操作が継続可能なことをシステムに通知するときに、[**Complete**](https://msdn.microsoft.com/library/windows/apps/dn946934) を呼び出してください。

[!code-cs[AMSDownloadRequested](./code/AdaptiveStreaming_Win10/cs/MainPage.xaml.cs#SnippetAMSDownloadRequested)]

**AdaptiveMediaSource** オブジェクトは、ダウンロードや再生のビットレートが変わったときに対応できるようにするイベントを提供します。 この例では、現在のビットレートが UI で簡単に更新されます。 また、アダプティブ ストリーミングのビットレートをシステムで切り替えるタイミングを決定する比率を変更できることに注意してください。 詳しくは、[**AdvancedSettings**](https://msdn.microsoft.com/library/windows/apps/mt628697) プロパティをご覧ください。

[!code-cs[AMSBitrateEvents](./code/AdaptiveStreaming_Win10/cs/MainPage.xaml.cs#SnippetAMSBitrateEvents)]

 

 







<!--HONumber=Jun16_HO4-->


