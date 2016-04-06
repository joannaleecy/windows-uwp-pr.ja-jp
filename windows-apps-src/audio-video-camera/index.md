---
ms.assetid: 0fc12d26-f1cf-4da7-b5a7-735a5074b74a
description: このセクションでは、写真、ビデオ、オーディオをキャプチャ、再生、または編集するユニバーサル Windows アプリの作成について説明します。
title: オーディオ、ビデオ、およびカメラ
---

# オーディオ、ビデオ、およびカメラ

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

このセクションでは、写真、ビデオ、オーディオをキャプチャ、再生、または編集するユニバーサル Windows アプリの作成について説明します。
 
| トピック                                                                                             | 説明                                                                                                                                                                                                                                                                                    |
|---------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [CameraCaptureUI を使った写真とビデオのキャプチャ](capture-photos-and-video-with-cameracaptureui.md) | この記事では、[CameraCaptureUI](capture-photos-and-video-with-cameracaptureui.md) クラスを使用して、Windows に組み込まれているカメラ UI で写真またはビデオをキャプチャする方法を説明します。                                                                                                            |
| [MediaCapture を使った写真とビデオのキャプチャ](capture-photos-and-video-with-mediacapture.md)       | この記事では、[MediaCapture](https://msdn.microsoft.com/library/windows/apps/br241124) API を使用して写真とビデオをキャプチャする手順について説明します。これには、MediaCapture の初期化とシャットダウン、デバイスの向きに変化が生じた場合の処理などが含まれます。                                  |
| [画像やビデオでの顔の検出](detect-and-track-faces-in-an-image.md)                         | このトピックでは、ビデオ フレームのシーケンスで顔を経時的に追跡するように最適化されている [FaceTracker](https://msdn.microsoft.com/library/windows/apps/dn974150) の使用方法について説明します。                                                                                                               |
| [メディア コンポジションと編集](media-compositions-and-editing.md)                               | [Microsoft メディア ファンデーション](https://msdn.microsoft.com/library/windows/desktop/ms694197) API 内の API。                                                                                                                                                                                 |
| [イメージング](imaging.md)                                                                             | この記事では、[SoftwareBitmap](https://msdn.microsoft.com/library/windows/apps/dn887358) オブジェクトを使って画像の読み込みと保存を行い、ビットマップ画像を表現する方法について説明します。                                                                                                                     |
| [メディア ファイルのコード変換](transcode-media-files.md)                                                 | [Windows.Media.Transcoding](https://msdn.microsoft.com/library/windows/apps/br207105) API を使って、ビデオ ファイルをある形式から別の形式にコード変換できます。                                                                                                                                |
| [バックグラウンドでのメディア ファイルの処理](process-media-files-in-the-background.md)                 | この記事では、[MediaProcessingTrigger](https://msdn.microsoft.com/library/windows/apps/dn806005) とバックグラウンド タスクを使って、バックグラウンドでメディア ファイルを処理する方法について説明します。                                                                                                       |
| [MediaSource を使ったメディアの再生](media-playback-with-mediasource.md)                             | [MediaSource](https://msdn.microsoft.com/library/windows/apps/dn930905) クラスは、ローカル ファイルやリモート ファイルなど、さまざまなソースのメディアを参照および再生するための一般的な方法を提供し、基になるメディア形式に関係なく、メディア データにアクセスするための一般的なモデルを公開します。  |
| [アダプティブ ストリーミング](adaptive-streaming.md)                                                       | この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリにアダプティブ ストリーミング マルチメディア コンテンツの再生を追加する方法について説明します。 現在、この機能では、HTTP ライブ ストリーミング (HLS) と Dynamic Adaptive Streaming over HTTP (DASH) コンテンツの再生がサポートされています。                                          |
| [バックグラウンド オーディオ](background-audio.md)                                                           | この記事では、バックグラウンドでオーディオを再生する UWP アプリを作成する方法について説明します。                                                                                                                                                                                                               |
| [システム メディア トランスポート コントロール](system-media-transport-controls.md)                             | [SystemMediaTransportControls](https://msdn.microsoft.com/library/windows/apps/dn278677) クラスを使うと、Windows に組み込まれているシステム メディア トランスポート コントロールをアプリで使って、現在アプリで再生中のメディアに関してコントロールに表示されるメタデータを更新できるようになります。 |
| [メディアのキャスト](media-casting.md)                                                                 | この記事では、ユニバーサル Windows アプリからリモート デバイスにメディアをキャストする方法について説明します。                                                                                                                                                                                                       |
| [オーディオ グラフ](audio-graphs.md)                                                                   | この記事では、[Windows.Media.Audio](https://msdn.microsoft.com/library/windows/apps/dn914341) 名前空間の API を使ってオーディオのルーティング、ミキシング、処理のシナリオでオーディオ グラフを作成する方法について説明します。                                                                            |
| [MIDI](midi.md)                                                                                   | この記事では、MIDI (Musical Instrument Digital Interface) デバイスを列挙する方法と、ユニバーサル Windows アプリとの間で MIDI メッセージを送受信する方法について説明します。                                                                                                                                   |
| [カメラに依存しない懐中電灯](camera-independent-flashlight.md)                                 | この記事では、デバイスのライトにアクセスして使う方法を説明します (存在する場合)。 ライト機能は、デバイスのカメラやカメラのフラッシュ機能とは別に管理されます。                                                                                                                 |
| [サポートされるコーデック](supported-codecs.md)                                                           | この記事では、UWP アプリ用のオーディオとビデオのコーデックおよび形式のサポートを示します。                                                                                                                                                                                                                  |
| [PlayReady DRM](playready-client-sdk.md)                                                          | このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリに PlayReady で保護されたメディア コンテンツを追加する方法について説明します。                                                                                                                                                                                |
| [PlayReady の Encrypted Media Extension](playready-encrypted-media-extension.md)                     | このセクションでは、以前の Windows 8.1 から、Windows 10 バージョンに加えられた変更をサポートするために、PlayReady Web アプリを変更する方法について説明します。                                                                                                                                       |

 

 

 






<!--HONumber=Mar16_HO1-->


