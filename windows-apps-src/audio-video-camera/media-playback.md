---
author: drewbatgit
ms.assetid: 25553c4d-fa4f-4130-af9b-97f993fefd43
description: このセクションでは、オーディオとビデオを再生するユニバーサル Windows アプリの作成について説明します。
title: メディア再生
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: dbcd2a4f9cec02882c62c7d6493746931b7919a8
ms.sourcegitcommit: b7e3d222e229cdbf04e837fcb94fb7d84a93de09
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5593180"
---
# <a name="media-playback"></a>メディア再生


このセクションでは、オーディオとビデオを再生するユニバーサル Windows アプリの作成について説明します。 

## <a name="media-playback-developer-features"></a>開発者向けメディア再生機能

次の表に、メディア再生機能をアプリに追加するための詳しいガイダンスを提供するハウツー記事の一覧を示します。
 
| トピック                                                                                             | 説明                                                                                                                                                                                                                                                                                    |
|---------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [MediaPlayer を使ったオーディオとビデオの再生](play-audio-and-video-with-mediaplayer.md) | この記事では、UWP アプリ用のメディア再生システムに追加された新しい機能や機能強化を活用する方法について説明します。 Windows 10 バージョン 1607 以降、メディアの再生で推奨されるベスト プラクティスは、[**MediaElement**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaElement) ではなく、[**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer) クラスを使ってメディアを再生することです。 軽量の XAML コントロールである [**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaPlayerElement) が導入され、XAML ページのメディア コンテンツをレンダリングできるようになりました。 **MediaPlayer** には、システム メディア トランスポート コントロールとの自動統合や、バックグラウンド オーディオで使用できるシンプルな 1 プロセスのモデルなど、複数の利点があります。 この記事では、ビデオを Windows.UI.Composition サーフェスにレンダリングする方法や、[**MediaTimelineController**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.MediaTimelineController) を使って複数のメディア プレーヤーを同期する方法についても説明します。                                                                                                          |
| [メディア項目、プレイリスト、トラック](media-playback-with-mediasource.md)                         | この記事では、ローカル ファイルやリモート ファイルなど、さまざまなソースのメディアを参照および再生するための一般的な方法を提供し、基になるメディア形式に関係なく、メディア データにアクセスするための一般的なモデルを公開する [**MediaSource**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.MediaSource) クラスの使い方について説明します。 [**MediaPlaybackItem**](https://msdn.microsoft.com/library/windows/apps/dn930939) クラスは、メディア項目に含まれている複数のオーディオ、ビデオ、メタデータ トラックを管理および選択できるようにして、**MediaSource** の機能を拡張します。 [**MediaPlaybackList**](https://msdn.microsoft.com/library/windows/apps/dn930955) を使用すると、1 つまたは複数のメディア再生項目から再生リストを作成できます。                                                                                                               |
| [システム メディア トランスポート コントロールとの統合](integrate-with-systemmediatransportcontrols.md)                               | この記事では、システム メディア トランスポート コントロール (SMTC) とアプリを統合する方法について説明します。 Windows 10 バージョン 1607 以降、メディアを再生するために作成した **MediaPlayer** のすべてのインスタンスは、SMTC によって自動的に表示されます。 この記事では、再生中のコンテンツに関するメタデータを SMTC に提供する方法や、SMTC コントロールの既定の動作を増強または完全に上書きする方法について説明します。                                   |
| [システムでサポートされているタイミングが設定されたメタデータのキュー](system-supported-metadata-cues.md)                               | この記事では、メディア ファイルやストリームに埋め込まれる可能性がある、タイミングが設定されたメタデータのいくつかの形式を活用する方法について説明します。                                   |
| [メディアの中断の作成、スケジュール、管理](create-schedule-and-manage-media-breaks.md)                                                                             | この記事では、メディア再生アプリ用にメディアの中断を作成、スケジュール、管理する方法について説明します。 Windows 10 バージョン 1607 以降では、[**MediaBreakManager**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaBreakManager) クラスを使って、[**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer) で再生する任意の [**MediaPlaybackItem**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackItem) にメディアの中断を簡単かつ迅速に追加できます。 通常、メディアの中断は、オーディオ広告やビデオ広告をメディア コンテンツに挿入する目的で使います。 メディアの中断を 1 つ以上スケジュールすると、再生中の指定した時間に、システムがメディア コンテンツを自動的に再生します。 **MediaBreakManager** では、ユーザーがメディアを中断、終了、またはスキップしたときにアプリが反応できるように、イベントが提供されています。 [**MediaPlaybackSession**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackSession) にアクセスしてメディアの中断を確認し、ダウンロードや進行状況の更新のバッファリングなどのイベントを監視することもできます。                                                                                                                     |
| [バックグラウンドでのメディアの再生](background-audio.md)                                                                             | この記事では、アプリをフォアグラウンドからバックグラウンドに移動してもメディアの再生を続行できるように、アプリを構成する方法について説明します。 バックグラウンドでの再生とは、ユーザーがアプリを最小化してホーム画面に戻った後や、それ以外の方法でアプリから離れた後も、アプリでオーディオの再生を続行できることを意味します。 Windows 10 バージョン 1607 では、バックグラウンドでのメディアの再生用に新しい 1 プロセスのモデルが導入されているため、従来の 2 プロセスのモデルよりも迅速かつ簡単に実装できます。 この記事には、新しいアプリケーション ライフサイクル イベントである [**EnteredBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.EnteredBackground) と [**LeavingBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.LeavingBackground) を使って、バックグラウンドでのアプリの実行中にメモリ使用量を管理することに関する情報が含まれています。                                                                                                                    |
| [アダプティブ ストリーミング](adaptive-streaming.md)                                                       | この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリにアダプティブ ストリーミング マルチメディア コンテンツの再生を追加する方法について説明します。 現在、この機能では、HTTP ライブ ストリーミング (HLS) と Dynamic Adaptive Streaming over HTTP (DASH) コンテンツの再生がサポートされています。                                          |
| [メディアのキャスト](media-casting.md)                                                                 | この記事では、ユニバーサル Windows アプリからリモート デバイスにメディアをキャストする方法について説明します。                                                                                                                                                                                                       |
| [PlayReady DRM](playready-client-sdk.md)                                                          | このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリに PlayReady で保護されたメディア コンテンツを追加する方法について説明します。                                                                                                                                                                                |
| [PlayReady の Encrypted Media Extension](playready-encrypted-media-extension.md)                     | このセクションでは、以前の Windows 8.1 から、Windows 10 バージョンに加えられた変更をサポートするために、PlayReady Web アプリを変更する方法について説明します。                                                                                                                                       |

## <a name="media-playback-sdk-samples"></a>メディア再生の SDK サンプル

次の SDK サンプルでは、Windows 10 の UWP アプリで利用できるメディア再生機能が示されています。 コンテキスト内でメディア再生 API を使用する方法を確認したり、独自のアプリを作成し始める場合は、以下のサンプルをご利用ください。

* [アダプティブ ストリーミングのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/AdaptiveStreaming)
* [バックグラウンド オーディオのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BackgroundMediaPlayback)
* [システム メディア トランスポートのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/SystemMediaTransportControls)                                                                                               
 




