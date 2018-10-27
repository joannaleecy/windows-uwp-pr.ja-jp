---
author: drewbatgit
ms.assetid: EFCF84D0-2F4C-454D-97DA-249E9EAA806C
description: SystemMediaTransportControls クラスを使うと、Windows に組み込まれているシステム メディア トランスポート コントロールをアプリで使って、現在アプリで再生中のメディアに関してコントロールに表示されるメタデータを更新できるようになります。
title: システム メディア トランスポート コントロールの手動制御
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: b0ece9a25a2fd2892553d66847c39637e7faae70
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5710481"
---
# <a name="manual-control-of-the-system-media-transport-controls"></a>システム メディア トランスポート コントロールの手動制御


Windows 10 バージョン 1607 以降、[ **MediaPlayer** ](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer) クラスを使ってメディアを再生する UWP アプリは、既定でシステム メディア トランスポート コントロール (SMTC) と自動的に統合されます。 これは、ほとんどのシナリオの SMTC と対話するための推奨される方法です。 SMTC の **MediaPlayer** との既定の統合のカスタマイズについて詳しくは、「[システム メディア トランスポート コントロールとの統合](integrate-with-systemmediatransportcontrols.md)」をご覧ください。

SMTC の手動コントロールの実装が必要になるシナリオがいくつかあります。 たとえば、[ **MediaTimelineController** ](https://msdn.microsoft.com/library/windows/apps/Windows.Media.MediaTimelineController) を使って 1 つ以上のメディア プレーヤーの再生を制御する場合です。 複数のメディア プレーヤーを使用していて、アプリ用に SMTC の 1 つのインスタンスだけが必要な場合もそうです。 [ **MediaElement** ](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaElement) を使ってメディアを再生する場合は、SMTC を手動で制御する必要があります。

## <a name="set-up-transport-controls"></a>トランスポート コントロールをセットアップする
**MediaPlayer** 使ってメディアを再生している場合は、[**MediaPlayer.SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer.SystemMediaTransportControls) プロパティにアクセスして [**SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.SystemMediaTransportControls) のインスタンスを取得できます。 SMTC を手動で制御する場合は、[ **CommandManager.IsEnabled** ](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManager.IsEnabled) プロパティを false に設定して、**MediaPlayer** によって提供される自動統合を無効にする必要があります。

> [!NOTE] 
> [**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManager.IsEnabled) を false に設定して、[**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlayer) の [**MediaPlaybackCommandManager**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManager) を無効にすると、**MediaPlayerElement** で提供される **MediaPlayer** と [**TransportControls**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.MediaPlayerElement.TransportControls) の間のリンクが解除されます。このため組み込みトランスポート コントロールはプレーヤーの再生を自動的に制御しなくなります。 代わりに、独自のコントロールを実装して、**MediaPlayer** を制御する必要があります。

[!code-cs[InitSMTCMediaPlayer](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetInitSMTCMediaPlayer)]

[**GetForCurrentView**](https://msdn.microsoft.com/library/windows/apps/dn278708) を呼び出して、[**SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn278677) のインスタンスを取得することもできます。 **MediaElement** を使ってメディアを再生している場合は、この方法でオブジェクトを取得する必要があります。

[!code-cs[InitSMTCMediaElement](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetInitSMTCMediaElement)]

**SystemMediaTransportControls** オブジェクトの対応する "is enabled" プロパティ ([**IsPlayEnabled**](https://msdn.microsoft.com/library/windows/apps/dn278714)、[**IsPauseEnabled**](https://msdn.microsoft.com/library/windows/apps/dn278713)、[**IsNextEnabled**](https://msdn.microsoft.com/library/windows/apps/dn278712)、[**IsPreviousEnabled**](https://msdn.microsoft.com/library/windows/apps/dn278715) など) を設定することで、アプリで使うボタンを有効にします。 利用可能なすべてのコントロールの一覧については、**SystemMediaTransportControls** のリファレンス ドキュメントをご覧ください。

[!code-cs[EnableContols](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetEnableContols)]

ユーザーがボタンを押したときに通知を受信するために、[**ButtonPressed**](https://msdn.microsoft.com/library/windows/apps/dn278706) イベントのハンドラーを登録します。

[!code-cs[RegisterButtonPressed](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetRegisterButtonPressed)]

## <a name="handle-system-media-transport-controls-button-presses"></a>システム メディア トランスポート コントロールの押されたボタンを処理する

[**ButtonPressed**](https://msdn.microsoft.com/library/windows/apps/dn278706) イベントは、有効なボタンの 1 つが押されたときにシステム トランスポート コントロールで発生します。 イベント ハンドラーに渡される [**SystemMediaTransportControlsButtonPressedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn278683) の [**Button**](https://msdn.microsoft.com/library/windows/apps/dn278685) プロパティは、有効なボタンのうちどれが押されたかを示す [**SystemMediaTransportControlsButton**](https://msdn.microsoft.com/library/windows/apps/dn278681) 列挙体のメンバーです。

[**ButtonPressed**](https://msdn.microsoft.com/library/windows/apps/dn278706) イベント ハンドラーから UI スレッド上のオブジェクト ([**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) オブジェクトなど) を更新するには、[**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) を介して呼び出しをマーシャリングする必要があります。 これは、**ButtonPressed** イベント ハンドラーが UI スレッドから呼び出されず、UI を直接変更しようとすると例外が発生するためです。

[!code-cs[SystemMediaTransportControlsButtonPressed](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetSystemMediaTransportControlsButtonPressed)]

## <a name="update-the-system-media-transport-controls-with-the-current-media-status"></a>現在のメディアの状態でシステム メディア トランスポート コントロールを更新する

システムで現在の状態を反映してコントロールを更新できるように、メディアの状態が変更されたときには、それを [**SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn278677) に通知する必要があります。 そのためには、メディアの状態が変更されたときに発生する [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) の [**CurrentStateChanged**](https://msdn.microsoft.com/library/windows/apps/br227375) イベント内から、[**PlaybackStatus**](https://msdn.microsoft.com/library/windows/apps/dn278719) プロパティを適切な [**MediaPlaybackStatus**](https://msdn.microsoft.com/library/windows/apps/dn278665) 値に設定します。

[!code-cs[SystemMediaTransportControlsStateChange](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetSystemMediaTransportControlsStateChange)]

## <a name="update-the-system-media-transport-controls-with-media-info-and-thumbnails"></a>メディアの情報と縮小表示でシステム メディア トランスポート コントロールを更新する

[**SystemMediaTransportControlsDisplayUpdater**](https://msdn.microsoft.com/library/windows/apps/dn278686) クラスを使って、現在再生されているメディア項目の曲のタイトルやアルバム アートなど、トランスポート コントロールに表示されるメディア情報を更新します。 [**SystemMediaTransportControls.DisplayUpdater**](https://msdn.microsoft.com/library/windows/apps/dn278707) プロパティを使って、このクラスのインスタンスを取得します。 一般的なシナリオの場合、メタデータを渡すための推奨される方法は、現在再生中のメディア ファイルを渡して [**CopyFromFileAsync**](https://msdn.microsoft.com/library/windows/apps/dn278694) を呼び出すことです。 表示アップデーターによって、ファイルからメタデータと縮小表示画像が自動的に抽出されます。

[**Update**](https://msdn.microsoft.com/library/windows/apps/dn278701) を呼び出すことで、システム メディア トランスポート コントロールの UI が新しいメタデータと縮小表示によって更新されます。

[!code-cs[SystemMediaTransportControlsUpdater](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetSystemMediaTransportControlsUpdater)]

必要に応じて、[**DisplayUpdater**](https://msdn.microsoft.com/library/windows/apps/dn278707) クラスによって公開される [**MusicProperties**](https://msdn.microsoft.com/library/windows/apps/dn278696)、[**ImageProperties**](https://msdn.microsoft.com/library/windows/apps/dn278695)、または [**VideoProperties**](https://msdn.microsoft.com/library/windows/apps/dn278702) オブジェクトの値を設定することにより、システム メディア トランスポート コントロールに表示されるメタデータを手動で更新できます。

[!code-cs[SystemMediaTransportControlsUpdaterManual](./code/SMTCWin10/cs/MainPage.xaml.cs#SystemMediaTransportControlsUpdaterManual)]

## <a name="update-the-system-media-transport-controls-timeline-properties"></a>システム メディア トランスポート コントロールのタイムライン プロパティを更新する

システム トランスポート コントロールには、メディア項目の現在の再生位置、開始時刻、終了時刻など、現在再生中のメディア項目のタイムラインに関する情報が表示されます。 システム メディア トランスポート コントロールのタイムライン プロパティを更新するには、新しい [**SystemMediaTransportControlsTimelineProperties**](https://msdn.microsoft.com/library/windows/apps/mt218746) オブジェクトを作成します。 再生中のメディア項目の現在の状態を反映するように、オブジェクトのプロパティを設定します。 [**SystemMediaTransportControls.UpdateTimelineProperties**](https://msdn.microsoft.com/library/windows/apps/mt218760) を呼び出して、コントロールのタイムラインを更新します。

[!code-cs[UpdateTimelineProperties](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetUpdateTimelineProperties)]

-   再生中の項目のタイムラインをシステム コントロールに表示するには、[**StartTime**](https://msdn.microsoft.com/library/windows/apps/mt218751)、[**EndTime**](https://msdn.microsoft.com/library/windows/apps/mt218747)、および [**Position**](https://msdn.microsoft.com/library/windows/apps/mt218755) の値を指定する必要があります。

-   [**MinSeekTime**](https://msdn.microsoft.com/library/windows/apps/mt218749) と [**MaxSeekTime**](https://msdn.microsoft.com/library/windows/apps/mt218748) を使うと、ユーザーがシークできるタイムライン内の範囲を指定できます。 一般的なシナリオとしては、コンテンツ プロバイダーがメディアに広告を含める場合などがあります。

    [**PositionChangeRequest**](https://msdn.microsoft.com/library/windows/apps/mt218755) を発生させるには、[**MinSeekTime**](https://msdn.microsoft.com/library/windows/apps/mt218749) と [**MaxSeekTime**](https://msdn.microsoft.com/library/windows/apps/mt218748) を設定する必要があります。

-   システム コントロールは、メディアの再生と同期させておくことをお勧めします。そのためには、再生中にこれらのプロパティを約 5 秒ごとに更新し、一時停止や新しい位置へのシークなど、再生に変更が加えられたときには、再度更新します。

## <a name="respond-to-player-property-changes"></a>プレーヤーのプロパティの変更に応答する

再生中のメディア項目の状態ではなく、メディア プレーヤー自体の現在の状態に関連した、一連のシステム トランスポート コントロール プロパティがあります。 これらの各プロパティは、ユーザーが関連するコントロールを調整したときに発生するイベントと対応しています。 これらのプロパティとイベントを次に示します。

| プロパティ                                                                  | イベント                                                                                                   |
|---------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------|
| [**AutoRepeatMode**](https://msdn.microsoft.com/library/windows/apps/mt218753) | [**AutoRepeatModeChangeRequested**](https://msdn.microsoft.com/library/windows/apps/mt218754) |
| [**PlaybackRate**](https://msdn.microsoft.com/library/windows/apps/mt218756)     | [**PlaybackRateChangeRequested**](https://msdn.microsoft.com/library/windows/apps/mt218757)     |
| [**ShuffleEnabled**](https://msdn.microsoft.com/library/windows/apps/mt218758) | [**ShuffleEnabledChangeRequested**](https://msdn.microsoft.com/library/windows/apps/mt218759) |

 
これらのコントロールの 1 つに対するユーザーの操作を処理するには、最初に、関連付けられているイベントのハンドラーを登録します。

[!code-cs[RegisterPlaybackChangedHandler](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetRegisterPlaybackChangedHandler)]

まず、イベントのハンドラーで、要求された値が有効な予想される範囲内にあることを確認します。 範囲内の場合は、[**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) の対応するプロパティを設定してから、[**SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn278677) オブジェクトの対応するプロパティを設定します。

[!code-cs[PlaybackChangedHandler](./code/SMTCWin10/cs/MainPage.xaml.cs#SnippetPlaybackChangedHandler)]

-   これらのプレーヤー プロパティ イベントの 1 つが発生するためには、プロパティの初期値を設定する必要があります。 たとえば、[**PlaybackRateChangeRequested**](https://msdn.microsoft.com/library/windows/apps/mt218757) は、[**PlaybackRate**](https://msdn.microsoft.com/library/windows/apps/mt218756) プロパティの値を少なくとも 1 回設定するまでは発生しません。

## <a name="use-the-system-media-transport-controls-for-background-audio"></a>バックグラウンド オーディオに対してシステム メディア トランスポート コントロールを使う

**MediaPlayer** によって提供される自動 SMTC 統合を使用していない場合は、SMTC と手動で統合してバック グラウンド オーディオを有効にする必要があります。 少なくとも、アプリで [ **IsPlayEnabled** ](https://msdn.microsoft.com/library/windows/apps/dn278714) と [**IsPauseEnabled** ](https://msdn.microsoft.com/library/windows/apps/dn278713) を true に設定して、再生ボタンと一時停止ボタンを有効にする必要があります。 アプリは、[**ButtonPressed**](https://msdn.microsoft.com/library/windows/apps/dn278706) イベントも処理する必要があります。 アプリがこれらの要件を満たしていない場合、アプリがバックグラウンドに移動したときにオーディオ再生は停止します。

バックグラウンド オーディオ用に新しい 1 プロセスのモデルを使うアプリは、[**GetForCurrentView**](https://msdn.microsoft.com/library/windows/apps/dn278708) を呼び出して [**SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn278677) のインスタンスを取得する必要があります。 バックグラウンド オーディオ用に従来の 2 プロセスのモデルを使うアプリは、[ **BackgroundMediaPlayer.Current.SystemMediaTransportControls** ](https://msdn.microsoft.com/library/windows/apps/dn926635) を使ってバックグラウンド プロセスから SMTC にアクセスする必要があります

バックグラウンドでのオーディオ再生について詳しくは、「[バックグラウンドでのメディアの再生](background-audio.md)」をご覧ください。

## <a name="related-topics"></a>関連トピック
* [メディア再生](media-playback.md)
* [システム メディア トランスポート コントロールとの統合](integrate-with-systemmediatransportcontrols.md) 
* [システム メディア トランスポートのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/SystemMediaTransportControls) 

 




